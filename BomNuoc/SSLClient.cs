using Acr.UserDialogs;
//using ASK.Xamarin.Generic;
using PDS.Xamarin.Generic;
//using ASK.Xamarin.SkyWay;
//using ASK.Xamarin.SSL;
using PDS.Xamarin.SSL;
//using HeartLine.Core.Contents;
using BomNuoc.Contents;
//using HeartLine.Core.SQL;
using BomNuoc.SQL;
//using HeartLine.Core.SSL;
using BomNuoc.SSL;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MessagePack;

namespace BomNuoc
{
    public class SSLClient
    {
        public static string defaultToken = "login";

        ISSLClient sslClient;
        IDictionary<string, Action<SSLCommands.SSLCommandBase>> SendWaitDictionary = new ConcurrentDictionary<string, Action<SSLCommands.SSLCommandBase>>();

        private ConcurrentQueue<SSLCommands.SSLCommandBase> ResendQueue = new ConcurrentQueue<SSLCommands.SSLCommandBase>();
        private class TaskCanceller { public bool Cancel { get; set; } = false; };
        private Task ReconnectTask = null;
        private TaskCanceller ReconnectTaskCanceller = null;
        private Task SendAckTask = null;
        private TaskCanceller SendAckTaskCanceller = null;
        private static AsyncLock asyncLock = new AsyncLock();


        public bool IsConnect { get; set; } = false;
        public bool Disconnected { get; set; } = false;

        private static bool UseOldReconnect = false;

        public SSLClient()
        {
            sslClient = DependencyService.Get<ISSLClient>();
        }

        public async Task<bool> Connect()
        {
            Disconnected = false;
            var ret = await ConnectInternal();
            if (ret)
            {
                ReconnectTaskCanceller = new TaskCanceller();
                var taskCanceller = ReconnectTaskCanceller;
                ReconnectTask = Task.Run(async () =>
                {
                    while (Disconnected == false && taskCanceller.Cancel == false)
                    {
                        if (UseOldReconnect)
                        {

                            if (IsConnect == false)
                            {
                                if (await ConnectInternal())
                                {
                                    //Ackを送ってTokenをサーバーに認識させる
                                    await SendCommand(new SSLCommands.Acknowledgement { token = Globals.CurrentToken });
                                    //再接続時溜まっているコマンドを送信
                                    SSLCommands.SSLCommandBase sendData;
                                    while (ResendQueue.TryDequeue(out sendData))
                                    {
                                        if (await SendCommand(sendData) == false) break; //また送信失敗したらやり直し
                                    }
                                }
                            }
                        }
                        else
                        {
                            using (await asyncLock.LockAsync())
                            {
                                if (IsConnect == false)
                                {
                                    if (await ConnectInternal())
                                    {
                                        //Ackを送ってTokenをサーバーに認識させる
                                        await SendCommand(new SSLCommands.Acknowledgement { token = Globals.CurrentToken });
                                        //再接続時溜まっているコマンドを送信
                                        SSLCommands.SSLCommandBase sendData;
                                        while (ResendQueue.TryDequeue(out sendData))
                                        {
                                            if (await SendCommand(sendData) == false) break; //また送信失敗したらやり直し
                                        }
                                    }
                                }
                            }
                        }
                        await Task.Delay(5000);
                    }
                });
            }
            return ret;
        }

        public void StartSendAck()
        {
            if (SendAckTask == null)
            {
                SendAckTaskCanceller = new TaskCanceller();
                var taskCanceller = SendAckTaskCanceller;
                SendAckTask = Task.Run(async () =>
                {
                    while (Disconnected == false && taskCanceller.Cancel == false)
                    {
                        if (IsConnect == true)
                        {
                            await SendCommand(new SSLCommands.Acknowledgement { token = Globals.CurrentToken }, false);
                        }
                        await Task.Delay(60000);
                    }
                });
            }
        }

        private void StopAllTasks()
        {
            if (ReconnectTask != null) ReconnectTaskCanceller.Cancel = true;
            if (SendAckTask != null) SendAckTaskCanceller.Cancel = true;
        }

        private async Task<bool> ConnectInternal()
        {
            var ipAddress = Globals.ServerIPAddress.Split(",");
            foreach (var ip in ipAddress)
            {
                try
                {
                    if (sslClient != null)
                    {
                        sslClient.SSLSocketReadEvent -= SslClient_SSLSocketReadEvent;
                        sslClient.SSLSocketReadEvent += SslClient_SSLSocketReadEvent;
                        sslClient.SSLSocketReadBinaryEvent -= SslClient_SSLSocketReadBinaryEvent;
                        sslClient.SSLSocketReadBinaryEvent += SslClient_SSLSocketReadBinaryEvent;

                    }
                    //接続
                    Debug.Log("接続開始 " + ip + ":" + Globals.ServerPort.ToString());
                    await sslClient?.Connect(ip, Globals.ServerPort);

                    if (sslClient != null)
                    {
                        sslClient.SSLSocketDisconnectEvent -= SslClient_SSLSocketDisconnectEvent;
                        sslClient.SSLSocketDisconnectEvent += SslClient_SSLSocketDisconnectEvent;

                    }
                    Debug.Log("接続完了");
                    StartRead();
                    IsConnect = true;
                    return true;
                }
                catch (Exception ex)
                {
                    if (sslClient != null)
                    {
                        sslClient.SSLSocketReadEvent -= SslClient_SSLSocketReadEvent;
                        sslClient.SSLSocketReadBinaryEvent -= SslClient_SSLSocketReadBinaryEvent;
                    }
                    Debug.Log("接続失敗:" + ex.ToString(), Debug.LogLevel.Error);
                }
            }
            return false;
        }

        public async void StartRead()
        {
            //受信開始
            try
            {
                Debug.Log("データ読み取り開始");
                await sslClient?.read();
            }
            catch (SSLSocketException ex)
            {
                Debug.Log("ソケットRead終了:" + ex.Message + CR.LF + "Inner Exception:" + ex.InnerException.Message, Debug.LogLevel.Error);
            }
        }

        private void SslClient_SSLSocketDisconnectEvent(object sender, EventArgs e)
        {
            sslClient.SSLSocketDisconnectEvent -= SslClient_SSLSocketDisconnectEvent;
            sslClient.SSLSocketReadEvent -= SslClient_SSLSocketReadEvent;
            IsConnect = false;
            Debug.Log("切断されました", Debug.LogLevel.Info);
        }

        private async void SslClient_SSLSocketReadEvent(object sender, SSLSocketReadEventArgs e)
        {
            Debug.Log($"SslClient_SSLSocketReadEvent[{e.readString.Length}]");
            await Task.Delay(1);
            string decompressedString;
            byte[] bs = System.Convert.FromBase64String(e.readString);
            using (var ms = new System.IO.MemoryStream(bs))
            using (var ms2 = new System.IO.MemoryStream())
            using (var cs = new System.IO.Compression.DeflateStream(ms, System.IO.Compression.CompressionMode.Decompress))
            {
                while (true)
                {
                    int rb = cs.ReadByte();
                    if (rb == -1) break;
                    if (rb == 0) rb = 125;
                    ms2.WriteByte((byte)rb);
                }
                var ms2arr = ms2.ToArray();
                decompressedString = Encoding.UTF8.GetString(ms2arr, 0, ms2arr.Length);
            }
            var tmp = decompressedString.Split(new char[] { '|' }, 2);
            string commandStr = tmp[0];
            string json = tmp[1];

            var command = SSLCommands.GetCommandType(commandStr);
            //Debug.Log(json);

            try
            {
                var obj = Json.Serializer.Deserialize(command, json);
                await ProcessCommand((SSLCommands.SSLCommandBase)obj);
            }
            catch (Exception ex)
            {
                Debug.Log("ParseError:" + ex.Message);
            }
        }
        private async void SslClient_SSLSocketReadBinaryEvent(object sender, SSLSocketReadBinaryEventArgs e)
        {
            Debug.Log($"SslClient_SSLSocketReadEvent[{e.data.Length}]");

            var command = SSLCommands.GetCommandType(e.CommandTypeString);
            //Debug.Log(json);
            try
            {
                var obj = MessagePack.LZ4MessagePackSerializer.NonGeneric.Deserialize(command, e.data/* resolver set in app.xaml.cs */);
                await ProcessBinaryCommand((SSLCommands.SSLCommandBase)obj);
            }
            catch (Exception ex)
            {
                Debug.Log("ParseError:" + ex.Message);
            }
        }


        public enum ReadError
        {
            OK = 0,
            NotIncludeToken = 1,
            TokenIncorrect = 2,
        }

        private async Task<ReadError> ProcessCommand(SSLCommands.SSLCommandBase readData)
        {

            var command = readData.GetType();
            Debug.Log($"ProcessCommand[{command.ToString()}] RequestID:{readData.RequestID}");
            if (!string.IsNullOrWhiteSpace(readData.RequestID))
            {
                if (SendWaitDictionary.ContainsKey(readData.RequestID))
                {
                    Debug.Log("SendWaitDictionary Contains RequestID");
                    //登録されたイベント実行
                    SendWaitDictionary[readData.RequestID](readData);
                    SendWaitDictionary.Remove(readData.RequestID);
                    return ReadError.OK;
                }
            }

            if (command == typeof(SSLCommands.NeedRelogin))
            { //再ログイン要求コマンド
                Debug.Log("再ログイン要求");
                var data = (SSLCommands.NeedRelogin)readData;
                Globals.CurrentToken = data.token; //token:login
                //await Globals.sslClient.SendCommandWait(new SSLCommands.Login() { UserName = Globals.CurrentUserData.UserName, Password = Globals.CurrentUserData.Password, token = Globals.CurrentToken },
                await Globals.sslClient.SendCommandBinaryWait(new SSLCommands.Login() { UserName = Globals.CurrentUserData.UserName, Password = Globals.CurrentUserData.Password, token = Globals.CurrentToken },
                    async (ret) =>
                    {
                        if (ret.GetType() == typeof(SSLCommands.ErrorMessage))
                        {
                            var errordata = (SSLCommands.ErrorMessage)ret;
                            //await UserDialogs.Instance.AlertAsync("ユーザー名またはパスワードが間違っています", "エラー", "OK");
                            Debug.Log("再ログイン失敗：" + errordata.message, Debug.LogLevel.Error);
                        }
                        else if (ret.GetType() == typeof(SSLCommands.UpdateToken))
                        {
                            var tokendata = (SSLCommands.UpdateToken)ret;
                            Globals.CurrentToken = tokendata.token;
                            //ユーザー情報を取得
                            Globals.CurrentUserData = (await Globals.sslClient.GetTableAllDataAsync<SQL.SQLTables.User>("`UserName`='" + Globals.CurrentUserData.UserName + "' AND `token`='" + Globals.CurrentToken + "'", true)).First();
                            Debug.Log("再ログイン成功：" + Globals.CurrentToken);
                        }
                    });
            }
            else if (command == typeof(SSLCommands.TestMessage))
            { //テストメッセージ受信
                var data = (SSLCommands.TestMessage)readData;
                await UserDialogs.Instance.AlertAsync(data.message, "受信");
            }
            else if (command == typeof(SSLCommands.ErrorMessage))
            { //エラーメッセージ受信
                var data = (SSLCommands.ErrorMessage)readData;
                await UserDialogs.Instance.AlertAsync(data.message, "エラー");
            }
            else if (command == typeof(SSLCommands.UpdateToken))
            { //トークン更新・ログイン成功
                var data = (SSLCommands.UpdateToken)readData;
                Globals.CurrentToken = data.token;
                //ユーザー情報を取得
                Globals.CurrentUserData = (await Globals.sslClient.GetTableAllDataAsync<SQL.SQLTables.User>("`UserName`='" + Globals.CurrentUserData.UserName + "' AND `token`='" + Globals.CurrentToken + "'", true)).First();
            }
            else if (command == typeof(SSLCommands.UpdateData))
            { //データ更新通知
            }
            else if (command == typeof(SSLCommands.RequestCabinetsOnOffData))
            {//心電波形送信要求
            }
            else if (command == typeof(SSLCommands.SendCabinetsOnOffData))
            {//心電波形
            }
            else if (command == typeof(SSLCommands.Acknowledgement))
            {
                var data = (SSLCommands.Acknowledgement)readData;
                Debug.Log("Received Acknowledgement");
            }
            else
            {
                //await UserDialogs.Instance.AlertAsync("不明なコマンドを受信しました。通信状況を確認してやり直してください。コマンド:" + command.Name + " 内容:" + Json.Serializer.Serialize(readData), "受信");
                Debug.Log("process Nguyen Tan Truc");
            }
            return ReadError.OK;
        }
        private async Task<ReadError> ProcessBinaryCommand(SSLCommands.SSLCommandBase readData)
        {

            var command = readData.GetType();
            Debug.Log($"ProcessBinaryCommand[{command.ToString()}] RequestID:{readData.RequestID}");
            if (!string.IsNullOrWhiteSpace(readData.RequestID))
            {
                if (SendWaitDictionary.ContainsKey(readData.RequestID))
                {
                    Debug.Log("SendWaitDictionary Contains RequestID");
                    //登録されたイベント実行
                    SendWaitDictionary[readData.RequestID](readData);
                    SendWaitDictionary.Remove(readData.RequestID);
                    return ReadError.OK;
                }
            }

            if (command == typeof(SSLCommands.NeedRelogin))
            { //再ログイン要求コマンド
                Debug.Log("再ログイン要求");
                var data = (SSLCommands.NeedRelogin)readData;
                Globals.CurrentToken = data.token; //token:login
                //await Globals.sslClient.SendCommandWait(new SSLCommands.Login() { UserName = Globals.CurrentUserData.UserName, Password = Globals.CurrentUserData.Password, token = Globals.CurrentToken },
                await Globals.sslClient.SendCommandBinaryWait(new SSLCommands.Login() { UserName = Globals.CurrentUserData.UserName, Password = Globals.CurrentUserData.Password, token = Globals.CurrentToken },
                    async (ret) =>
                    {
                        if (ret.GetType() == typeof(SSLCommands.ErrorMessage))
                        {
                            var errordata = (SSLCommands.ErrorMessage)ret;
                            //await UserDialogs.Instance.AlertAsync("ユーザー名またはパスワードが間違っています", "エラー", "OK");
                            Debug.Log("再ログイン失敗：" + errordata.message, Debug.LogLevel.Error);
                        }
                        else if (ret.GetType() == typeof(SSLCommands.UpdateToken))
                        {
                            var tokendata = (SSLCommands.UpdateToken)ret;
                            Globals.CurrentToken = tokendata.token;
                            //ユーザー情報を取得
                            Globals.CurrentUserData = (await Globals.sslClient.GetTableAllDataAsync<SQL.SQLTables.User>("`UserName`='" + Globals.CurrentUserData.UserName + "' AND `token`='" + Globals.CurrentToken + "'", true)).First();
                            Debug.Log("再ログイン成功：" + Globals.CurrentToken);
                        }
                    });
            }
            else if (command == typeof(SSLCommands.TestMessage))
            { //テストメッセージ受信
                var data = (SSLCommands.TestMessage)readData;
                await UserDialogs.Instance.AlertAsync(data.message, "受信");
            }
            else if (command == typeof(SSLCommands.ErrorMessage))
            { //エラーメッセージ受信
                var data = (SSLCommands.ErrorMessage)readData;
                await UserDialogs.Instance.AlertAsync(data.message, "エラー");
            }
            else if (command == typeof(SSLCommands.UpdateToken))
            { //トークン更新・ログイン成功
                Debug.Log("====1");
                var data = (SSLCommands.UpdateToken)readData;
                Globals.CurrentToken = data.token;
                //ユーザー情報を取得
                Globals.CurrentUserData = (await Globals.sslClient.GetTableAllDataAsync<SQL.SQLTables.User>("`UserName`='" + Globals.CurrentUserData.UserName + "' AND `token`='" + Globals.CurrentToken + "'", true)).First();
            }
            else if (command == typeof(SSLCommands.UpdateData))
            { //データ更新通知
                Debug.Log("====2");
                var data = (SSLCommands.UpdateData)readData;
                //var cabinetsUser = Json.Serializer.Deserialize(typeof(SQL.SQLTables.User), data.CallFromJson) as SQL.SQLTables.User;
                var cabinets = Json.Serializer.Deserialize(typeof(SQL.SQLTables.Cabinets), data.CabinetsJson) as SQL.SQLTables.Cabinets;
                Globals.UpdateDataScheduling.UpdateDataInfo dataInfo = new Globals.UpdateDataScheduling.UpdateDataInfo();
                dataInfo.type = (SSLCommands.UpdateDataTypes)data.DataType;
                dataInfo.callFromCabinetsID = cabinets.ID;
                Globals.updateDataScheduler.UpdateDataQueueAdd(dataInfo);

            }
            else if (command == typeof(SSLCommands.RequestCabinetsOnOffData))
            {//心電波形送信要求

            }
            else if (command == typeof(SSLCommands.SendCabinetsOnOffData))
            {//心電波形
            }
            else if (command == typeof(SSLCommands.Acknowledgement))
            {
                Debug.Log("====3");
                var data = (SSLCommands.Acknowledgement)readData;
                Debug.Log("Received Acknowledgement");
            }
            else
            {
                //await UserDialogs.Instance.AlertAsync(command.Name + " " + Json.Serializer.Serialize(readData), "受信");
                Debug.Log("process Nguyen Tan Truc");
            }
            return ReadError.OK;
        }

//        public delegate void ReceivedWaveDataEventHandler(SQL.SQLTables.Patient Patient, System.DateTime WaveDate, int[] WaveData);
//        public event ReceivedWaveDataEventHandler ReceivedWaveData;

//        public delegate void ReceivedHeartRateDataEventHandler(SQL.SQLTables.Cabinets cabinets, System.DateTime WaveDate, int[] WaveData);
//        public event ReceivedHeartRateDataEventHandler ReceivedHeartRateData;

        public async Task<bool> SendCommand(SSLCommands.SSLCommandBase sendData, bool ReSend = true)
        {
            return (await SendCommandBinary(sendData, ReSend));
        }

        private static int requestIDNo = 0;
        public async Task<string> SendCommandWait(SSLCommands.SSLCommandBase sendData, Action<SSLCommands.SSLCommandBase> action, string RequestID = null, bool ReSend = true)
        {
            string requestID = RequestID.IsNullOrWhiteSpace() == false ? RequestID : DateTime.Now.ToString("yyMMddHHmmssff") + requestIDNo++.ToString("0000000000");
            SendWaitDictionary.AddOrReplace(requestID, action);
            sendData.RequestID = requestID;
            if (await SendCommand(sendData, ReSend))
            {
                return requestID;
            }
            else
            {
                return null;
            }
        }
        public async Task<bool> SendCommandBinary(SSLCommands.SSLCommandBase sendData, bool ReSend = true)
        {
            var sendArray = new List<byte>();
            sendArray.Add((byte)0x04);
            var sendtypename = Encoding.UTF8.GetBytes(sendData.GetType().Name);
            sendArray.AddRange(BitConverter.GetBytes(sendtypename.Length));
            sendArray.AddRange(sendtypename);
            byte[] serializetemp = MessagePack.LZ4MessagePackSerializer.NonGeneric.Serialize(sendData.GetType(), sendData);
            sendArray.AddRange(BitConverter.GetBytes(serializetemp.Length));
            sendArray.AddRange(serializetemp);

            if (doDebugDisconnect)
            {
                Debug.Log($"切断開始 doDebugDisconnect == {doDebugDisconnect}", Debug.LogLevel.Warning);
                doDebugDisconnect = false;
                sslClient?.disconnect(true);
                Debug.Log($"切断終了 doDebugDisconnect == {doDebugDisconnect}", Debug.LogLevel.Warning);
            }

            if (UseOldReconnect)
            {
                try
                {
                    await sslClient.sendBinary(sendArray.ToArray());
                }
                catch (SSLSocketException ex)
                {
                    Debug.Log("送信失敗:" + ex.Message + CR.LF + "Inner Exception:" + ex.InnerException.Message, Debug.LogLevel.Error);
                    if (ReSend) ResendQueue.Enqueue(sendData);
                    return false;
                }
                return true;
            }
            else
            {
                var retrycount = 3;
                while (retrycount > 0)
                {
                    try
                    {
                        await sslClient.sendBinary(sendArray.ToArray());
                        retrycount = 0;
                    }
                    catch (SSLSocketException ex)
                    {
                        Debug.Log("送信失敗:" + ex.Message + CR.LF + "Inner Exception:" + ex.InnerException.Message, Debug.LogLevel.Error);

                        using (await asyncLock.LockAsync())
                        {
                            if (IsConnect == false)
                            {
                                Debug.Log($"再接続開始 IsConnect == {IsConnect}", Debug.LogLevel.Warning);
                                if (await ConnectInternal())
                                {
                                    Debug.Log($"再接続完了 IsConnect == {IsConnect}", Debug.LogLevel.Warning);
                                    Debug.Log($"Ackを送ってTokenをサーバーに認識させる", Debug.LogLevel.Warning);
                                    await SendCommand(new SSLCommands.Acknowledgement { token = Globals.CurrentToken }, false);
                                    Debug.Log($"Ack送信完了、通常送信再試行", Debug.LogLevel.Warning);
                                    retrycount--;
                                    //サーバーに再接続できた場合はやり直す。
                                    continue;
                                }
                            }
                            else
                            {
                                //別の誰かがコネクトに成功した場合、そのままやり直す
                                retrycount--;
                                continue;
                            }
                        }
                        if (ReSend)
                        {
                            Debug.Log($"サーバーに再接続できなかった場合はキューに入れて終了", Debug.LogLevel.Warning);
                            ResendQueue.Enqueue(sendData);
                        }
                        return false;
                    }
                }
                return true;
            }
        }

        private static int BinaryrequestIDNo = 0;
        public async Task<string> SendCommandBinaryWait(SSLCommands.SSLCommandBase sendData, Action<SSLCommands.SSLCommandBase> action, string RequestID = null, bool ReSend = true)
        {
            string requestID = RequestID.IsNullOrWhiteSpace() == false ? RequestID : DateTime.Now.ToString("yyMMddHHmmssff") + BinaryrequestIDNo++.ToString("0000000000");
            SendWaitDictionary.AddOrReplace(requestID, action);
            sendData.RequestID = requestID;
            if (await SendCommandBinary(sendData, ReSend))
            {
                return requestID;
            }
            else
            {
                return null;
            }
        }


        public void CancelSendCommandWait(string requestID)
        {
            if (SendWaitDictionary.ContainsKey(requestID)) SendWaitDictionary.Remove(requestID);
        }

        /// <summary>
        /// where == "`ID`>0"を指定したときだけ全更新処理を通ります。それ以外はキャッシュのlastID以降を取得
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <param name="needUpdate"></param>
        /// <returns></returns>
        public async Task<List<T>> GetTableAllDataAsync<T>(string where, bool needUpdate = false, bool dropCache = false, bool afterCache = false) where T : SQL.SQLTables.TableBase, new()
        {
            Debug.Log("GetTableAllDataAsync Table:" + typeof(T).Name + " Update:" + needUpdate.ToString() + " Where:" + where);
            var firstwhere = where;
            while (where.Contains("DATETIME("))
            {
                var startindex = where.IndexOf("DATETIME(");
                var endindex = where.IndexOf(")", startindex);
                var datetimeindex = startindex + "DATETIME(".Length;
                var setdatetime = DateTime.Parse(where.Substring(datetimeindex, endindex - datetimeindex).Replace("'", ""));
                where = where.Remove(endindex, ")".Length);
                where = where.Remove(startindex, "DATETIME(".Length);
                firstwhere = where.Remove(startindex, endindex - datetimeindex).Insert(startindex, setdatetime.Ticks.ToString());
            }
             List<T> list = await Globals.localDB.GetAllDataAsync<T>(firstwhere);
            bool isWait = true;
            
            var lastID = needUpdate ? null : list.Max(d => (int?)d.ID);

            if (lastID.HasValue) where += (where.IsNullOrWhiteSpace() ? "" : " AND ") + "`ID`>" + lastID.Value.ToString();
            if (needUpdate && list.Count > 0 && (where != "`ID`>0" || dropCache))
            {
                if (where.IsNullOrWhiteSpace() == false)
                {
                    where = "(" + where + ") OR ";
                    where += "`ID` in (" + string.Join(",", list.Select(d => "'" + d.ID.ToString() + "'")) + ")";
                }
            }
            var RequestID = await Globals.sslClient?.SendCommandBinaryWait(new SSLCommands.SQLExecuteReaderBinary
            {
                token = Globals.CurrentToken,
                TableName = typeof(T).Name,
                Command = SSLCommands.SQLExecuteReaderBinary.SQLCommands.getAllDataBinary,
                Where = where
            }, async (ret) =>
            {
                Debug.Log("GetTableAllDataAsync(Return) Table:" + typeof(T).Name + " Update:" + needUpdate.ToString() + " Where:" + where);
                var receiveList = MessagePack.LZ4MessagePackSerializer.Deserialize<List<T>>(((SSLCommands.SQLExecuteReaderBinary)ret).DataBinary);
                
                if (where == "`ID`>0" || dropCache)
                {//全更新
                    await Globals.localDB.DropTableAsync<T>();
                    Globals.localDB.CreateTable<T>();
                    await Globals.localDB.InsertDataAsync(receiveList);
                }
                else
                {
                    if (afterCache == false)
                    {
                        var ColumnList = GetColumnList<T>();
                        foreach (var d in receiveList)
                        {
                            var ColumnData = new List<object>();
                            foreach (var s in ColumnList)
                            {
                                ColumnData.Add(GetValue(d, s));
                            }
                            await Globals.localDB.UpdateDataAsync(d, ColumnList, ColumnData, d.ID);
                            if (needUpdate == false)
                            {
                                if (list.Any(item => item.ID == d.ID))
                                {
                                    list[list.FindIndex(item => item.ID == d.ID)] = d;
                                }
                                else
                                {
                                    list.Add(d);
                                }
                            }
                        }
                    }
                    else
                    { //ローカルキャッシュへの書き込みを後回しにする(afterCache == true)
                        foreach (var d in receiveList)
                        {
                            if (list.Any(item => item.ID == d.ID)) //オンメモリで過去のキャッシュと合体
                            {
                                list[list.FindIndex(item => item.ID == d.ID)] = d;
                            }
                            else
                            {
                                list.Add(d);
                            }
                        }
                        isWait = false;
                        Debug.Log("GetTableAllDataAsync(StartUpdateCache) Table:" + typeof(T).Name + " Update:" + needUpdate.ToString() + " Where:" + where);
                        var ColumnList = GetColumnList<T>();
                        foreach (var d in receiveList)
                        {
                            var ColumnData = new List<object>();
                            foreach (var s in ColumnList)
                            {
                                ColumnData.Add(GetValue(d, s));
                            }
                            await Globals.localDB.UpdateDataAsync(d, ColumnList, ColumnData, d.ID);
                        }
                        Debug.Log("GetTableAllDataAsync(EndUpdateCache) Table:" + typeof(T).Name + " Update:" + needUpdate.ToString() + " Where:" + where);
                    }
                }
                
                isWait = false;
            }, null, false);
            if (RequestID.IsNullOrWhiteSpace() == false)
            {
                DateTime startTime = DateTime.Now;
                Debug.Log("GetTableAllDataAsync(WaitStart) Table:" + typeof(T).Name + " Update:" + needUpdate.ToString() + " Where:" + where);
                while (isWait)
                {
                    TimeSpan diffTime = DateTime.Now - startTime;
                    if ((IsConnect == false) || (diffTime.TotalMinutes > 10))
                    {
                        Debug.Log("GetTableAllDataAsync(WaitError) 接続が切れました。処理を抜けます。 Table:" + typeof(T).Name + " Update:" + needUpdate.ToString() + " Where:" + where);
                        CancelSendCommandWait(RequestID);
                        break;
                    }
                    await Task.Delay(10);

                }
                Debug.Log("GetTableAllDataAsync(WaitEnd) Table:" + typeof(T).Name + " Update:" + needUpdate.ToString() + " Where:" + where);
            }
            if (needUpdate && afterCache == false)
            {
                list = await Globals.localDB.GetAllDataAsync<T>(firstwhere);
            }

            return list;
            
        }
        public async Task<List<T>> GetTableAllDataAsyncForOlderData<T>(string where, bool needUpdate = false, bool dropCache = false, bool afterCache = false, int limit = 100) where T : SQL.SQLTables.TableBase, new()
        {
            Debug.Log("GetTableAllDataAsyncForOlderData Table:" + typeof(T).Name + " Update:" + needUpdate.ToString() + " Where:" + where);
            var firstwhere = where;
            while (where.Contains("DATETIME("))
            {
                var startindex = where.IndexOf("DATETIME(");
                var endindex = where.IndexOf(")", startindex);
                var datetimeindex = startindex + "DATETIME(".Length;
                var setdatetime = DateTime.Parse(where.Substring(datetimeindex, endindex - datetimeindex).Replace("'", ""));
                where = where.Remove(endindex, ")".Length);
                where = where.Remove(startindex, "DATETIME(".Length);
                firstwhere = where.Remove(startindex, endindex - datetimeindex).Insert(startindex, setdatetime.Ticks.ToString());
            }
            List<T> list = await Globals.localDB.GetAllDataAsync<T>(firstwhere);
            bool isWait = true;
            /*
            var minID = needUpdate ? null : list.Min(d => (int?)d.ID);

            if (minID.HasValue) where += (where.IsNullOrWhiteSpace() ? "" : " AND ") + "`ID` < " + minID.Value.ToString() + " ORDER BY id DESC LIMIT " + limit.ToString();
            if (needUpdate && list.Count > 0 && (where != "`ID`>0" || dropCache))
            {
                if (where.IsNullOrWhiteSpace() == false)
                {
                    where = "(" + where + ") OR ";
                    where += "`ID` in (" + string.Join(",", list.Select(d => "'" + d.ID.ToString() + "'")) + ")";
                }
            }
            list.Clear();
            var RequestID = await Globals.sslClient?.SendCommandBinaryWait(new SSLCommands.SQLExecuteReaderBinary
            {
                token = Globals.CurrentToken,
                TableName = typeof(T).Name,
                Command = SSLCommands.SQLExecuteReaderBinary.SQLCommands.getAllDataBinary,
                Where = where
            }, async (ret) =>
            {
                Debug.Log("GetTableAllDataAsyncForOlderData(Return) Table:" + typeof(T).Name + " Update:" + needUpdate.ToString() + " Where:" + where);
                var receiveList = MessagePack.LZ4MessagePackSerializer.Deserialize<List<T>>(((SSLCommands.SQLExecuteReaderBinary)ret).DataBinary);
                if (where == "`ID`>0" || dropCache)
                {//全更新
                    await Globals.localDB.DropTableAsync<T>();
                    Globals.localDB.CreateTable<T>();
                    await Globals.localDB.InsertDataAsync(receiveList);
                }
                else
                {
                    if (afterCache == false)
                    {
                        var ColumnList = GetColumnList<T>();
                        foreach (var d in receiveList)
                        {
                            var ColumnData = new List<object>();
                            foreach (var s in ColumnList)
                            {
                                ColumnData.Add(GetValue(d, s));
                            }
                            await Globals.localDB.UpdateDataAsync(d, ColumnList, ColumnData, d.ID);
                            if (needUpdate == false)
                            {
                                if (list.Any(item => item.ID == d.ID))
                                {
                                    list[list.FindIndex(item => item.ID == d.ID)] = d;
                                }
                                else
                                {
                                    list.Add(d);
                                }
                            }
                        }
                    }
                    else
                    { //ローカルキャッシュへの書き込みを後回しにする(afterCache == true)
                        foreach (var d in receiveList)
                        {
                            if (list.Any(item => item.ID == d.ID)) //オンメモリで過去のキャッシュと合体
                            {
                                list[list.FindIndex(item => item.ID == d.ID)] = d;
                            }
                            else
                            {
                                list.Add(d);
                            }
                        }
                        isWait = false;
                        Debug.Log("GetTableAllDataAsyncForOlderData(StartUpdateCache) Table:" + typeof(T).Name + " Update:" + needUpdate.ToString() + " Where:" + where);
                        var ColumnList = GetColumnList<T>();
                        foreach (var d in receiveList)
                        {
                            var ColumnData = new List<object>();
                            foreach (var s in ColumnList)
                            {
                                ColumnData.Add(GetValue(d, s));
                            }
                            await Globals.localDB.UpdateDataAsync(d, ColumnList, ColumnData, d.ID);
                        }
                        Debug.Log("GetTableAllDataAsyncForOlderData(EndUpdateCache) Table:" + typeof(T).Name + " Update:" + needUpdate.ToString() + " Where:" + where);
                    }
                }
                isWait = false;
            }, null, false);
            if (RequestID.IsNullOrWhiteSpace() == false)
            {
                DateTime startTime = DateTime.Now;
                Debug.Log("GetTableAllDataAsyncForOlderData(WaitStart) Table:" + typeof(T).Name + " Update:" + needUpdate.ToString() + " Where:" + where);
                while (isWait)
                {
                    TimeSpan diffTime = DateTime.Now - startTime;
                    if ((IsConnect == false) || (diffTime.TotalMinutes > 10))
                    {
                        Debug.Log("GetTableAllDataAsyncForOlderData(WaitError) 接続が切れました。処理を抜けます。 Table:" + typeof(T).Name + " Update:" + needUpdate.ToString() + " Where:" + where);
                        CancelSendCommandWait(RequestID);
                        break;
                    }
                    await Task.Delay(10);

                }
                Debug.Log("GetTableAllDataAsyncForOlderData(WaitEnd) Table:" + typeof(T).Name + " Update:" + needUpdate.ToString() + " Where:" + where);
            }
            if (needUpdate && afterCache == false)
            {
                list = await Globals.localDB.GetAllDataAsync<T>(firstwhere);
            }
            */
            return list;
        }

        public async Task<List<T>> GetTableSelectedColumnDataAsync<T>(List<string> ColumnList, string where) where T : SQL.SQLTables.TableBase, new()
        {
            var ColumnListStr = string.Join(",", ColumnList);
            Debug.Log("GetTableSelectedColumnDataAsync Table:" + typeof(T).Name + " ColumnList:" + ColumnListStr + " Where:" + where);
            ColumnList.AddNotContains("ID");
            List<T> list = await Globals.localDB.GetSelectColumnDataAsync<T>(ColumnList, where);
            bool isWait = true;
            bool isNull = false;
            
            foreach (var d in list)
            {
                foreach (var s in ColumnList)
                {
                    if (GetValue(d, s) == null) isNull = true;
                }
            }

            var lastID = list.Max(d => (int?)d.ID);

            if (lastID.HasValue && isNull == false) where += (where.IsNullOrWhiteSpace() ? "" : " AND ") + "`ID`>" + lastID.Value.ToString();
            var RequestID = await Globals.sslClient?.SendCommandBinaryWait(new SSLCommands.SQLExecuteReaderBinary
            {
                token = Globals.CurrentToken,
                TableName = typeof(T).Name,
                Command = SSLCommands.SQLExecuteReaderBinary.SQLCommands.GetSelectColumnDataBinary,
                DataBinary = MessagePack.LZ4MessagePackSerializer.NonGeneric.Serialize(ColumnList.GetType(), ColumnList),
                Where = where
            }, async (ret) =>
            {
                Debug.Log("GetTableSelectedColumnDataAsync(Return) Table:" + typeof(T).Name + " ColumnList:" + ColumnListStr + " Where:" + where);
                var receiveList = MessagePack.LZ4MessagePackSerializer.Deserialize<List<T>>(((SSLCommands.SQLExecuteReaderBinary)ret).DataBinary);
                foreach (var d in receiveList)
                {
                    var ColumnData = new List<object>();
                    foreach (var s in ColumnList)
                    {
                        ColumnData.Add(GetValue(d, s));
                    }
                    await Globals.localDB.UpdateDataAsync(d, ColumnList, ColumnData, d.ID);
                    if (list.Any(item => item.ID == d.ID))
                    {
                        list[list.FindIndex(item => item.ID == d.ID)] = d;
                    }
                    else
                    {
                        list.Add(d);
                    }
                }

                isWait = false;
            }, null, false);
            if (RequestID.IsNullOrWhiteSpace() == false)
            {
                Debug.Log("GetTableSelectedColumnDataAsync(WaitStart) Table:" + typeof(T).Name + " ColumnList:" + ColumnListStr + " Where:" + where);
                while (isWait)
                {
                    if (IsConnect == false)
                    {
                        Debug.Log("GetTableAllDataAsync(WaitError) 接続が切れました。処理を抜けます。 Table:" + typeof(T).Name + " ColumnList:" + ColumnListStr + " Where:" + where);
                        CancelSendCommandWait(RequestID);
                        break;
                    }
                    await Task.Delay(10);
                }
                Debug.Log("GetTableSelectedColumnDataAsync(WaitEnd) Table:" + typeof(T).Name + " ColumnList:" + ColumnListStr + " Where:" + where);
            }
            
            return list;
        }
        public async Task<List<T>> GetTableSelectedColumnDataBinaryAsync<T>(List<string> ColumnList, string where) where T : SQL.SQLTables.TableBase, new()
        {
            var ColumnListStr = string.Join(",", ColumnList);
            Debug.Log("GetTableSelectedColumnDataBinaryAsync Table:" + typeof(T).Name + " ColumnList:" + ColumnListStr + " Where:" + where);
            ColumnList.AddNotContains("ID");
            List<T> list = await Globals.localDB.GetSelectColumnDataAsync<T>(ColumnList, where);
            bool isWait = true;
            bool isNull = false;
            
            foreach (var d in list)
            {
                foreach (var s in ColumnList)
                {
                    if (GetValue(d, s) == null) isNull = true;
                }
            }

            var lastID = list.Max(d => (int?)d.ID);

            if (lastID.HasValue && isNull == false) where += (where.IsNullOrWhiteSpace() ? "" : " AND ") + "`ID`>" + lastID.Value.ToString();
            var RequestID = await Globals.sslClient?.SendCommandBinaryWait(new SSLCommands.SQLExecuteReaderBinary
            {
                token = Globals.CurrentToken,
                TableName = typeof(T).Name,
                Command = SSLCommands.SQLExecuteReaderBinary.SQLCommands.GetSelectColumnDataBinary,
                //DataJson = Json.Serializer.Serialize(ColumnList),
                DataBinary = MessagePack.LZ4MessagePackSerializer.NonGeneric.Serialize(ColumnList.GetType(), ColumnList),
                Where = where
            }, async (ret) =>
            {
                Debug.Log("GetTableSelectedColumnDataBinaryAsync(Return) Table:" + typeof(T).Name + " ColumnList:" + ColumnListStr + " Where:" + where);
                var receiveList = MessagePack.LZ4MessagePackSerializer.Deserialize<List<T>>(((SSLCommands.SQLExecuteReaderBinary)ret).DataBinary);


                foreach (var d in receiveList)
                {
                    var ColumnData = new List<object>();
                    foreach (var s in ColumnList)
                    {
                        ColumnData.Add(GetValue(d, s));
                    }
                    await Globals.localDB.UpdateDataAsync(d, ColumnList, ColumnData, d.ID);
                    if (list.Any(item => item.ID == d.ID))
                    {
                        list[list.FindIndex(item => item.ID == d.ID)] = d;
                    }
                    else
                    {
                        list.Add(d);
                    }
                }

                isWait = false;
            }, null, false);
            if (RequestID.IsNullOrWhiteSpace() == false)
            {
                Debug.Log("GetTableSelectedColumnDataAsync(WaitStart) Table:" + typeof(T).Name + " ColumnList:" + ColumnListStr + " Where:" + where);
                while (isWait)
                {
                    if (IsConnect == false)
                    {
                        Debug.Log("GetTableAllDataAsync(WaitError) 接続が切れました。処理を抜けます。 Table:" + typeof(T).Name + " ColumnList:" + ColumnListStr + " Where:" + where);
                        CancelSendCommandWait(RequestID);
                        break;
                    }
                    await Task.Delay(10);
                }
                Debug.Log("GetTableSelectedColumnDataAsync(WaitEnd) Table:" + typeof(T).Name + " ColumnList:" + ColumnListStr + " Where:" + where);
            }
            
            return list;
        }

        public object GetValue(object data, string propertyName)
        {

            var typeinfo = data.GetType().GetTypeInfo();
            var propertyInfo = GetProperty(typeinfo, propertyName);
            if (propertyInfo != null)
            {
                return propertyInfo.GetValue(data);
            }
            else
            {
                return null;
            }
        }

        private static PropertyInfo GetProperty(TypeInfo typeInfo, string propertyName)
        {
            var propertyInfo = typeInfo.GetDeclaredProperty(propertyName);
            if (propertyInfo == null && typeInfo.BaseType != null)
            {
                propertyInfo = GetProperty(typeInfo.BaseType.GetTypeInfo(), propertyName);
            }
            return propertyInfo;
        }

        private static List<string> GetColumnList<T>()
        {
            var list = new List<string>();
            GetPropertyList(list, typeof(T).GetTypeInfo());
            return list;
        }

        private static void GetPropertyList(List<string> list, TypeInfo typeInfo)
        {
            if (typeInfo.BaseType != null) GetPropertyList(list, typeInfo.BaseType.GetTypeInfo());
            list.AddRange(typeInfo.DeclaredProperties.Select(d => d.Name));
        }

        public async Task<long> InsertTableDataAsync<T>(T insertData, bool sendNotifyInsertFlag = false, SQL.SQLTables.Cabinets notifyCabinets = null)
        {
            Debug.Log("InsertTableDataAsync Table:" + typeof(T).Name);
            bool isWait = true;
            long LastInsertId = -1;
            
            string RequestID = null;
            while (isWait)
            {
                while (true)
                {
                    RequestID = await Globals.sslClient?.SendCommandBinaryWait(new SSLCommands.SQLExecuteReaderBinary
                    {
                        token = Globals.CurrentToken,
                        TableName = typeof(T).Name,
                        Command = SSLCommands.SQLExecuteReaderBinary.SQLCommands.InsertDataBinary,
                        DataBinary = MessagePack.LZ4MessagePackSerializer.NonGeneric.Serialize(typeof(T), insertData)
                    }, (ret) =>
                    {
                        Debug.Log("InsertTableDataAsync(Return) Table:" + typeof(T).Name);
                        var data = (SSLCommands.SQLExecuteReaderBinary)ret;
                        LastInsertId = data.LastInsertId;
                        isWait = false;
                    }, RequestID, false);
                    if (RequestID.IsNullOrWhiteSpace() == false) break;
                    await Task.Delay(2000);
                }
                var StartTime = DateTime.Now;
                Debug.Log("InsertTableDataAsync(WaitStart) Table:" + typeof(T).Name);
                while (isWait)
                {
                    if (StartTime.AddSeconds(10) < DateTime.Now)
                    {
                        Debug.Log("InsertTableDataAsync(WaitTimeout) Table:" + typeof(T).Name);
                        break; // Timeout
                    }
                    await Task.Delay(10);
                }
                Debug.Log("InsertTableDataAsync(WaitEnd) Table:" + typeof(T).Name);
            }
            //if (sendNotifyInsertFlag == false)
            {
                //await CheckToSendUpdateDataSync(typeof(T).Name, insertData, notifyCabinets);
            }
            
            return LastInsertId;
        }

        public async Task<bool> UpdateTableDataAsync<T>(T insertData, bool sendNotifyUpdateFlag = false, SQL.SQLTables.Cabinets notifyCabinets = null)
        {
            Debug.Log("UpdateTableDataAsync Table:" + typeof(T).Name);
            bool isWait = true;
            bool isSuccess = false;
            
            string RequestID = null;
            while (isWait)
            {
                while (true)
                {
                    RequestID = await Globals.sslClient?.SendCommandBinaryWait(new SSLCommands.SQLExecuteReaderBinary
                    {
                        token = Globals.CurrentToken,
                        TableName = typeof(T).Name,
                        Command = SSLCommands.SQLExecuteReaderBinary.SQLCommands.UpdateDataBinary,
                        DataBinary = MessagePack.LZ4MessagePackSerializer.NonGeneric.Serialize(typeof(T), insertData)
                    }, (ret) =>
                    {
                        Debug.Log("UpdateTableDataAsync(Return) Table:" + typeof(T).Name);
                        var data = (SSLCommands.SQLExecuteReaderBinary)ret;
                        if (data.SuccessExecute)
                            isSuccess = true;
                        else
                            isSuccess = false;
                        isWait = false;
                    }, RequestID, false);
                    if (RequestID.IsNullOrWhiteSpace() == false) break;
                    await Task.Delay(2000);
                }
                var StartTime = DateTime.Now;
                Debug.Log("UpdateTableDataAsync(WaitStart) Table:" + typeof(T).Name);
                while (isWait)
                {
                    if (StartTime.AddSeconds(10) < DateTime.Now)
                    {
                        Debug.Log("UpdateTableDataAsync(WaitTimeout) Table:" + typeof(T).Name);
                        break; // Timeout
                    }
                    await Task.Delay(10);
                }
                Debug.Log("UpdateTableDataAsync(WaitEnd) Table:" + typeof(T).Name);
            }
            //if ((isSuccess) && (sendNotifyUpdateFlag == false))
            {
                await CheckToSendUpdateDataSync(typeof(T).Name, insertData);

            }
            return isSuccess;
        }
        public async Task CheckToSendUpdateDataSync(string typeUpdate, object data = null )
        {
            if ((typeUpdate == null)|| (data == null)) return;
            switch (typeUpdate)
            {
                case "Field":
                    await Globals.SendUpdateDataAsync(Globals.CurrentCabinets, SSL.SSLCommands.UpdateDataTypes.Fields, data);
                    break;
                case "Water":
                    await Globals.SendUpdateDataAsync(Globals.CurrentCabinets, SSL.SSLCommands.UpdateDataTypes.Water, data);
                    break;
            }
        }
        public void Disconnect()
        {
            StopAllTasks();
            Disconnected = true;
            Debug.Log("Disconnect");
            sslClient?.disconnect();
            sslClient.SSLSocketDisconnectEvent -= SslClient_SSLSocketDisconnectEvent;
            sslClient.SSLSocketReadEvent -= SslClient_SSLSocketReadEvent;

            sslClient.SSLSocketReadBinaryEvent -= SslClient_SSLSocketReadBinaryEvent;

        }

        private bool doDebugDisconnect = false;

        public void DebugDisconnect()
        {
            doDebugDisconnect = true;
        }
    }
}
