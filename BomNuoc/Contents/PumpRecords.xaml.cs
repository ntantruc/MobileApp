using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BomNuoc.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BomNuoc.Contents
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PumpRecords : ContentPage
    {
        private string htmlheader = @"
<html>
<head>
    <meta charset=""utf-8"">
    <meta name=""viewport"" content=""initial-scale=1"">
    <script type=""text/javascript"">
        function setZoomLevel(newZoom) {
            document.styleSheets[0]['rules'][0].style['zoom'] = newZoom;
        }
        function clearChild() {
            document.body.innerHTML = """";
        }
        function addChild(FieldNumber ,TimeOn, TotalWateringTime, CompletedWateringLevel, InsertDate) {
            document.body.insertAdjacentHTML('beforeend', createElement(FieldNumber, TimeOn, TotalWateringTime, CompletedWateringLevel, InsertDate));
        }
        function insertChild(FieldNumber, TimeOn, TotalWateringTime, CompletedWateringLevel, InsertDate) {
            document.body.insertAdjacentHTML('afterbegin', createElement(FieldNumber, TimeOn, TotalWateringTime, CompletedWateringLevel, InsertDate));
	        window.scrollTo(0,0);
        }
        function createElement(FieldNumber, TimeOn, TotalWateringTime, CompletedWateringLevel, InsertDate) {
            return  '<div class=""stacklayouthorizontal"">' +
                    '  <div class=""stacklayout"" style=""background-color:#FFFFFF;"">' +
                    '    <div class=""stacklayoutvertical"">' +
                    '      <div class=""stacklayout"" style=""margin:0 0 0 2px;background-color:#FFFFFF;"">' +
                    '        <div class=""stacklayoutvertical"">' +
                    '          <div class=""label"" style=""font-size:8;text-align:center;color:#FFFFFF;vertical-align:bottom;background-color:#404040;height:25px;width:56px;"">' +
                    '            '+FieldNumber+'' +
                    '          </div>' +
                    '        </div>' +
                    '        <div class=""stacklayoutvertical"">' +
                    '          <div class=""label"" style=""font-size:8;text-align:center;background-color:#FFFFFF;height:25px;width:56px;"">' +
                    '            '+TimeOn+'' +
                    '          </div>' +
                    '        </div>' +
                    '        <div class=""stacklayoutvertical"">' +
                    '          <div class=""label"" style=""font-size:8;text-align:right;vertical-align:middle;background-color:#EEEEEE;height:16px;width:56px;"">' +
                    '            '+TotalWateringTime+'' +
                    '          </div>' +
                    '        </div>' +
                    '        <div class=""stacklayoutvertical"">' +
                    '          <div class=""label"" style=""font-size:8;text-align:right;vertical-align:middle;background-color:#FFFFFF;height:16px;width:56px;"">' +
                    '            '+CompletedWateringLevel+'' +
                    '          </div>' +
                    '        </div>' +
                    '          <div class=""stacklayoutvertical"">' +
                    '            <div class=""label"" style=""font-size:8;text-align:right;vertical-align:middle;background-color:#EEEEEE;height:25px;width:56px;"">' +
                    '              '+InsertDate+'' +
                    '            </div>' +
                    '          </div>' +
                    '        </div>' +
                    '      </div>' +
                    '    </div>' +
                    '  </div>' +
                    '</div>';
        }
    </script>
    <style>
		body { zoom:100%; font-family: ""Yu Gothic UI""; margin: 0;padding: 0; }
        /* Switch */
        .switch {
            border: 1px solid #e0e0e0;
            border-radius: 48px;
            display: inline-block;
            width: 50px;
            position: relative;
            height: 25px;
        }

            .switch .handle {
                border-radius: 50%;
                width: 25px;
                height: 25px;
                background: #fff;
                position: absolute;
                box-shadow: 0px 2px 4px rgba(0,0,0,.2);
            }

            .switch.on {
                background: #4cd864;
                border-color: #4cd864;
            }

                .switch.on .handle {
                    right: 0;
                }

        /* Label */
        .labelbase {
            display: inline-block;
            font-size: 17;
        }
        .label {
            display: inline-block;
            font-size: 17;
        }

        /* ExpandableEditor */
        .expandableeditor {
            display: inline-block;
            font-size: 17;
            border: 2px solid #888888;
            min-height: 20px;
            min-width: 30px;
            vertical-align: bottom;
        }

        /* Entry */
        .entry {
            display: inline-block;
            font-size: 17;
            border: 2px solid #888888;
            min-height: 20px;
            min-width: 30px;
            vertical-align: bottom;
        }

        /* Grid */
        .grid {
            display: table;
            table-layout: fixed;
            height: 1px;
        }

        .gridrow {
            display: table-row;
        }

        .gridcolumn {
            display: table-cell;
            vertical-align: top;
            position: relative;
        }

            .gridcolumn > div {
                width: 100%;
                height: 100%;
            }

        /* WrapLayout */
        .wraplayout {
            display: inline-block;
        }

        /* StackLayout */
        .stacklayout {
            display: table;
            width:100%;
        }
        .stacklayouthorizontal {
            display: table-cell;
            vertical-align: top;
        }

        
        /* ベース */
        #bg {
            background-color: #eeeeee;
            padding: 7px 10px 7px 10px;
        }

        #round {
            background-color: #ffffff;
            border-radius: 15;
            padding: 10px 10px 10px 10px;
        }

        #title {
            display: inline-block;
            font-size: 23;
            margin: 0 10px 0 0;
        }

        #sender {
            display: inline-block;
            font-size: 18;
        }

        #date {
            float: right;
            font-size: 18;
            margin: 0 10px 0 0;
        }

        #readuser {
            font-size: 17;
        }

        #content {
            font-size: 17;
            margin: 5px 5 5 5;
        }

        #edit {
            font-size: 17;
            padding: 5px 10px 5px 10px;
            border: 1px solid #007ACC;
            border-radius: 8;
            text-decoration: none;
        }

        #edit2 {
            font-size: 17;
            padding: 2px 4px 2px 4px;
            border: 1px solid #007ACC;
            border-radius: 8;
            text-decoration: none;
        }

        a:link {
            color: #007ACC;
        }

        a:visited {
            color: #007ACC;
        }

        a:hover {
            color: #007ACC;
        }

        a:active {
            color: #007ACC;
        }
    </style>
</head>
<body>
";

        private string htmlfooter = @"
</body>
</html>
";
        private static List<SQL.SQLTables.Field> AllFieldsList = null;
        private static Dictionary<int, string> FieldsDictionary = new Dictionary<int, string>();
        private static string QueryCommand = "";
        
        private List<SQL.SQLTables.CabinetsRecords> AllRecords = null;
        private ObservableCollection<SQL.SQLTables.CabinetsRecords> Records = null;
        CancellationTask UpdateViewTask = new CancellationTask();

        private ZoomWebView MainWebView = null;

        public PumpRecords()
        {
            InitializeComponent();
            SelectFields.Items.Clear();
            MainWebView = new ZoomWebView
            {
                BackgroundColor = Color.Brown,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            }.Bind(ZoomWebView.ZoomProperty, Converters.FromCode.ScaleBinding(1));
            MainWebView.Navigated += MainWebView_Navigated;
            
            WebViewGrid.Children.Add(MainWebView);

        }
        private bool IsNavigated = false;
        private bool firsttime = true;
        protected async override void OnAppearing()
        {
           
            base.OnAppearing();
            if (firsttime)
            {
                System.Diagnostics.Debug.WriteLine("============================================= OnAppearing");
                Device.BeginInvokeOnMainThread(() =>
                {
                    MainWebView.Source = new HtmlWebViewSource { Html = htmlheader + htmlfooter + $"<!-- {Globals.Random.Next().ToString()} -->" };                    
                });
            }
        }

        protected override async void OnDisappearing()
        {
            System.Diagnostics.Debug.WriteLine("============================================= On Disappearing ");
            using (await UpdateViewTask.LockAsync())
            {
                await UpdateViewTask.CancelAsync();
            }
            using (await BackGroundUpateTask.LockAsync())
            {
                await BackGroundUpateTask.CancelAsync();
            }
            using (await UpdateOldDataTask.LockAsync())
            {
                await UpdateOldDataTask.CancelAsync();
            }
            base.OnDisappearing();
        }
        public async void Refresh()
        {
            System.Diagnostics.Debug.WriteLine("=>>>>> BEGIN refresh()");
            //Read at first time only
            if (AllFieldsList == null)
            {
                
                AllFieldsList = await Globals.sslClient.GetTableAllDataAsync<SQL.SQLTables.Field>("`CabinetsID`='" + Globals.CurrentCabinets.ID + "' AND `IsAlive`=1", true);
                if (AllFieldsList.Count == 0)
                {
                    AllFieldsList = null;
                }  else
                {
                    SelectFields.SelectedIndexChanged -= FieldSelected_Changed;
                    foreach (var item in AllFieldsList)
                    {
                        SelectFields.Items.Add(item.FieldNameNumber);
                        FieldsDictionary[item.ID] = item.FieldNameNumber;
                    }
                    FieldsDictionary[0] = "Tất cả";
                    SelectFields.Items.Add("Tất cả");
                    
                    SelectFields.SelectedIndex = 0;
                    SelectFields.SelectedIndexChanged += FieldSelected_Changed;
                    QueryCommand = GetWhereScript(SelectFields.SelectedItem.ToString());
                    System.Diagnostics.Debug.WriteLine("=>>>>> Query command " + QueryCommand);
                }  
            }
            
            if (Globals.CurrentCabinets == null)
            {                
                return;
            }
            await Globals.ShowLoading("Đang tải dữ liệu ...");
            LoadingLabel.Text = "Loading ...";
            LoadingActivityIndicator.IsRunning = true;
            LoadingStackLayout.IsVisible = true;
            try
            {  // Read at local DB firstly
                if (string.IsNullOrEmpty(QueryCommand))
                {
                    QueryCommand = GetWhereScript(SelectFields.SelectedItem.ToString());
                }    
                AllRecords = await Globals.localDB.GetAllDataAsync<SQL.SQLTables.CabinetsRecords>(QueryCommand);
                if (AllRecords.Count == 0)
                {  // If data is not available, read from server.
                    AllRecords = await Globals.sslClient.GetTableAllDataAsync<SQL.SQLTables.CabinetsRecords>(QueryCommand);
                }
                firsttime = false;
                if (isLoadingDictionary.ContainsKey(QueryCommand) == false)
                {                                     
                    BackgroundUpdate(QueryCommand);                    
                }
            }
            catch
            {
            }
            Globals.HideLoading();
            LoadLocalCache(AllRecords);
            System.Diagnostics.Debug.WriteLine("=>>>>> END refresh()" + AllRecords.Count);
        }
        private void MainWebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("MainWebView_Navigated");
            System.Diagnostics.Debug.WriteLine("====================================== MainWebView_Navigated");
            IsNavigated = true;
        }
        private  void FieldSelected_Changed(object sender, EventArgs e)
        {
            QueryCommand = GetWhereScript(SelectFields.SelectedItem.ToString());
            System.Diagnostics.Debug.WriteLine("=>>>>> Query command " + QueryCommand);
            Refresh();
        }
        private string GetWhereScript(string selectedField)
        {
            string ret = "";          
            int idvalue = -1;
            foreach (var item in FieldsDictionary)
            {
                if (item.Value.Equals(selectedField))
                {
                    idvalue = item.Key;
                }    
            }
            if (idvalue == -1)
                return ret;
            if (idvalue == 0)
            {//All

                ret = "`CabinetsID`='" + Globals.CurrentCabinets.ID + "'";
            } else
            {//Each field
                ret = "`CabinetsID`='" + Globals.CurrentCabinets.ID + "' AND `FieldID`='" + idvalue +"'";
            } 
            return ret;
        }
        private async void LoadLocalCache(List<SQL.SQLTables.CabinetsRecords> data)
        {
            var EditedList = new List<SQL.SQLTables.CabinetsRecords>();

            if (data == null) data = await Globals.localDB.GetAllDataAsync<SQL.SQLTables.CabinetsRecords>( QueryCommand);
            EditedList.AddRange(data);
            Records = new ObservableCollection<SQL.SQLTables.CabinetsRecords>(EditedList.OrderByDescending(d => d.InsertDate));
            UpdateView(new ObservableCollection<SQL.SQLTables.CabinetsRecords>(Records));
        }

       
        private async void UpdateView(ObservableCollection<SQL.SQLTables.CabinetsRecords> vitals)
        {
            System.Diagnostics.Debug.WriteLine("=>>>BEGIN       UpdateView" + vitals.Count);
            using (await UpdateViewTask.LockAsync())
            {
                await UpdateViewTask.CancelAsync();

                await Task.Delay(100);

                var webview = MainWebView;

                if (vitals.Any() == false)
                {
                    UpdateViewTask.Run(async task =>
                    {
                        await webview.EvalJavascriptAsync($@"clearChild()", null);
                    });
                    return;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("=>>>BEGIN       UpdateView  => 1  " + vitals.Count);
                    UpdateViewTask.Run(async task =>
                    {
                        System.Diagnostics.Debug.WriteLine("=>>>BEGIN       UpdateView  => 1-1  " + vitals.Count);
                        //clear view
                        await webview.EvalJavascriptAsync($@"clearChild()", null);
                        var script = "";
                        System.Diagnostics.Debug.WriteLine("=>>>BEGIN       UpdateView  => 1-2  " + vitals.Count);                        
                        for (int i = 0; i < vitals.Count; i++)
                        {
                            System.Diagnostics.Debug.WriteLine("=>>>BEGIN       UpdateView  => 1-3  " + vitals.Count);
                            var v = vitals[i];
                            System.Diagnostics.Debug.WriteLine($"UpdateViewTask Vitals:{i + 1}/{vitals.Count}");
                            if (i < 1000)
                            {
                                //script += $"addChild('{"A"}','{"B"}','{"C"}','{"D"}');";
                                script += $"addChild('{GetFieldNumber(v.FieldID)}','{((DateTime)(v.TimeOn)).ToString("yyyy/MM/dd HH:mm:ss")}','{v.TotalWateringTime.ToString()}','{v.CompletedWateringLevel.ToString()}','{((DateTime)(v.InsertDate)).ToString("yyyy/MM/dd HH:mm:ss")}');";
                                //script += $"addChild('{v.InsertDate.ToString("yyyy/MM/dd")}','{v.InsertDate.ToString("HH:mm:ss")}{(v.ID == 0 ? "" : "")}','{v.BPH.ToString():0}','{v.BPL.ToString():0}','{v.HB.ToString():0}','{v.WB.ToString():0.0}','{v.WA.ToString():0.0}');";
                                if (i <= 20 || (i > 20 && i % 10 == 0) || i == vitals.Count - 1)
                                {
                                    System.Diagnostics.Debug.WriteLine("=>>>BEGIN       UpdateView  => Begin Truc  ");
                                    await webview.EvalJavascriptAsync(script, null);
                                    System.Diagnostics.Debug.WriteLine("=>>>BEGIN       UpdateView  => End Truc  ");
                                    script = "";
                                }
                            }
                            else
                            {
                                break;
                            }
                            System.Diagnostics.Debug.WriteLine("=>>>BEGIN       UpdateView  => 2  " + vitals.Count);
                            await Task.Delay(10);
                            if (task.IsCancellationRequested) { return; };
                            if (await task.PauseWait()) { return; }
                        }
                        // Get all old data
                        System.Diagnostics.Debug.WriteLine("=>>>BEGIN       UpdateView  => 3  " + vitals.Count);
                       // UpdateOldData(vitals);
                    });

                }
            }
            System.Diagnostics.Debug.WriteLine("=>>>END       UpdateView");
            //  await UpdateOldData(vitals);
        }
        CancellationTask UpdateOldDataTask = new CancellationTask();
        private async Task UpdateOldData(ObservableCollection<SQL.SQLTables.CabinetsRecords> recList)
        {
            using (await UpdateOldDataTask.LockAsync())
            {
                await UpdateOldDataTask.CancelAsync();

                if (recList.Any() == false)
                    return;
                var webview = MainWebView;
                // Currently, get 1000 latest data              
                int counter = recList.Count;
                UpdateOldDataTask.Run(async task =>
                {

                    while (true)
                    {
                        var data = await Globals.sslClient.GetTableAllDataAsyncForOlderData<SQL.SQLTables.CabinetsRecords>(QueryCommand);
                        if (data.Count == 0) { return; }
                        if (task.IsCancellationRequested) { return; };
                        if (await task.PauseWait()) { return; }
                        var script = "";
                        if (counter > 1000)
                        {
                            continue;
                        }
                        for (int i = 0; i < data.Count; i++)
                        {

                            var v = data[i];
                            counter++;
                            System.Diagnostics.Debug.WriteLine($"UpdateViewTask Vitals:{counter}");
                            if (counter < 1000)
                            {
                                // await webview.EvalJavascriptAsync($"insertChild('{((DateTime)(v.TimeOn)).ToString("yyyy/MM/dd HH:mm:ss")}','{v.TotalWateringTime.ToString()}','{v.CompletedWateringLevel.ToString()}','{((DateTime)(v.InsertDate)).ToString("yyyy/MM/dd HH:mm:ss")}');", null);
                                //script += $"addChild('{v.InsertDate.ToString("yyyy/MM/dd")}','{v.InsertDate.ToString("HH:mm:ss")}{(v.ID == 0 ? "" : "")}','{v.BPH.ToString():0}','{v.BPL.ToString():0}','{v.HB.ToString():0}','{v.WB.ToString():0.0}','{v.WA.ToString():0.0}');";
                                script += $"addChild('{GetFieldNumber(v.FieldID)}','{((DateTime)(v.TimeOn)).ToString("yyyy/MM/dd HH:mm:ss")}','{v.TotalWateringTime.ToString()}','{v.CompletedWateringLevel.ToString()}','{((DateTime)(v.InsertDate)).ToString("yyyy/MM/dd HH:mm:ss")}');";
                                if ((i > 9 && i % 10 == 0) || i == data.Count - 1)
                                {
                                    await webview.EvalJavascriptAsync(script, null);
                                    script = "";
                                }
                            }
                            else
                            {
                                break;
                            }
                            await Task.Delay(10);
                            if (task.IsCancellationRequested) { return; };
                            if (await task.PauseWait()) { return; }
                        }
                    }
                });

            }
        }

        private void addChild(StringBuilder sb, string FieldNumber, string TimeOn, string TotalWateringTime, string CompletedWateringLevel, string InsertDate)
        {
            sb.Append(@"<div class=""stacklayouthorizontal""><div class=""stacklayout"" style=""background-color:#FFFFFF;""><div class=""stacklayoutvertical""><div class=""stacklayout"" style=""margin:0 0 0 2px;background-color:#FFFFFF;""><div class=""stacklayoutvertical""><div class=""label"" style=""font-size:8;text-align:center;color:#FFFFFF;vertical-align:bottom;background-color:#404040;height:22px;width:56px;"">");
            sb.Append($"{FieldNumber}");
            sb.Append(@"</div></div><div class=""stacklayoutvertical""><div class=""label"" style=""font-size:8;text-align:center;color:#FFFFFF;background-color:#FFFFFF;height:22px;width:56px;"">");
            sb.Append($"{TimeOn}");
            sb.Append(@"</div></div></div></div><div class=""stacklayoutvertical""><div class=""label"" style=""font-size:8;text-align:right;vertical-align:middle;background-color:#EEEEEE;");
            sb.Append(@";height:30px;width:56px;"">");
            sb.Append($"{TotalWateringTime}");
            sb.Append(@"</div></div><div class=""stacklayoutvertical""><div class=""label"" style=""font-size:8;text-align:right;vertical-align:middle;background-color:#FFFFFF;");
            sb.Append(@";height:30px;width:56px;"">");
            sb.Append($"{CompletedWateringLevel}");
            sb.Append(@"</div></div><div class=""stacklayoutvertical""><div class=""label"" style=""font-size:8;text-align:right;vertical-align:middle;background-color:#EEEEEE;");
            sb.Append(@";height:30px;width:56px;"">");
            //sb.Append(@";height:30px;width:156px;"">");
            sb.Append($"{InsertDate}");
            sb.Append(@""" id=""edit2"">Dữ liệu</a></div></div></div></div>");
        }
        private void BackgroundUpdate(string qcommand)
        {
            var t = Task.Run(async () =>
            {
                //記録
                //Update Cache
                StartLoading(qcommand);
                //await ReloadRef(patient);
                var data = await Globals.sslClient.GetTableAllDataAsync<SQL.SQLTables.CabinetsRecords>(qcommand, false, false, true);
                //if ((Globals.MainPagePC != null && (Globals.MainPagePC.mainPageView.IsVisible == false && Globals.MainPagePC.mainPageViewVitalSign.IsVisible && patient.IsEqualTo(Globals.CurrentPatientData)))
                //    || (Globals.MainPagePhone != null && (Globals.Navigation.CurrentPage is DialysisPage)) || (Globals.GetCurrentViewPage().GetType() == typeof(DialysisPage)))
                if (Globals.GetCurrentViewPage().GetType() == typeof(PumpRecords))
                {
                    CheckUpdate(data);
                }
                //else
                {
                    EndLoading(qcommand);
                }
            });
        }
        CancellationTask BackGroundUpateTask = new CancellationTask();
        private async void CheckUpdate(List<SQL.SQLTables.CabinetsRecords> data)
        {
            System.Diagnostics.Debug.WriteLine("=>>>BEGIN       CheckUpdate");
            using (await BackGroundUpateTask.LockAsync())
            {
                await BackGroundUpateTask.CancelAsync();
                if (AllRecords == null)
                {
                    EndLoading(QueryCommand);
                    return;
                }
                System.Diagnostics.Debug.WriteLine("=>>>BEGIN       CheckUpdate 1");
                var lastCount = AllRecords.Count();
                //すでに表示済みの内容と比較
                System.Diagnostics.Debug.WriteLine("=>>>BEGIN       CheckUpdate 2 " + lastCount);
                var NewRecordList = new List<SQL.SQLTables.CabinetsRecords>();
                BackGroundUpateTask.Run(async task =>
                {
                    foreach (var r in data)
                    {
                        if (AllRecords.Any(d => d.ID == r.ID) == false)
                        {
                            NewRecordList.Add(r);
                        };
                        if (task.IsCancellationRequested) { return; };
                        if (await task.PauseWait()) { return; }
                    }
                });
                System.Diagnostics.Debug.WriteLine("=>>>BEGIN       CheckUpdate 3 " + lastCount);
                DetailLoading(NewRecordList.Count, QueryCommand);
                if (lastCount == 0 && NewRecordList.Count > 0)
                {

                    LoadLocalCache(data);
                    return;
                }
                System.Diagnostics.Debug.WriteLine("=>>>BEGIN       CheckUpdate 4 " + lastCount);
                if (NewRecordList.Any() == false)
                {
                    return;
                }
                var NewVitals = new ObservableCollection<SQL.SQLTables.CabinetsRecords>(NewRecordList.OrderBy(d => d.InsertDate));
                System.Diagnostics.Debug.WriteLine("=>>>BEGIN       CheckUpdate 5 " + lastCount);
                await Task.Delay(100);
                var webview = MainWebView;
                BackGroundUpateTask.Run(async task =>
                {
                    foreach (var v in NewVitals)
                    {                       

                        await webview.EvalJavascriptAsync($"insertChild('{GetFieldNumber(v.FieldID)}','{((DateTime)(v.TimeOn)).ToString("yyyy/MM/dd HH:mm:ss")}','{v.TotalWateringTime.ToString()}','{v.CompletedWateringLevel.ToString()}','{((DateTime)(v.InsertDate)).ToString("yyyy/MM/dd HH:mm:ss")}');", null);
                        if (task.IsCancellationRequested) { return; };
                        if (await task.PauseWait()) { return; }
                    }
                });
            }
            System.Diagnostics.Debug.WriteLine("=>>>END       CheckUpdate");
        }
        private string GetFieldNumber(int fieldid)
        {
            if (FieldsDictionary.ContainsKey(fieldid))
                return FieldsDictionary[fieldid];
            return "";
        }
        CancellationTask LoadingTask = new CancellationTask();
        Dictionary<string, bool> isLoadingDictionary = new Dictionary<string, bool>();

        //private void StartLoading(SQL.SQLTables.Patient patient)
        private void StartLoading(string qcommand)
        {
            if (isLoadingDictionary.ContainsKey(qcommand))
            {
                isLoadingDictionary[qcommand] = true;
            }
            else
            {
                isLoadingDictionary.Add(qcommand, true);
            }
            Device.BeginInvokeOnMainThread(() =>
            {
                //if ((Globals.MainPagePC != null && (Globals.MainPagePC.mainPageView.IsVisible == false && Globals.MainPagePC.mainPageViewVitalSign.IsVisible && patient.IsEqualTo(Globals.CurrentPatientData)))
                //    || (Globals.MainPagePhone != null && (Globals.Navigation.CurrentPage is DialysisPage)) || (Globals.GetCurrentViewPage().GetType() == typeof(DialysisPage)))
                if (Globals.GetCurrentViewPage().GetType() == typeof(PumpRecords))
                {
                    LoadingLabel.Text = "Đang nhận dữ liệu ...";
                    LoadingActivityIndicator.IsRunning = true;
                    LoadingStackLayout.IsVisible = true;
                }
            });
        }
        private async void DetailLoading(int count, string qcommand)
        {
            using (await LoadingTask.LockAsync())
            {
                //var loadPatient = qcommand;
                if (isLoadingDictionary.ContainsKey(qcommand))
                {
                    isLoadingDictionary[qcommand] = false;
                } else
                {
                    isLoadingDictionary.Add(qcommand, false);
                }   
                
                await LoadingTask.CancelAsync();

                LoadingTask.Run(async task =>
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        LoadingLabel.Text = count == 0 ? "Dữ liệu được cập nhật" : $"{count} dữ liệu mới.";
                        LoadingActivityIndicator.IsRunning = false;
                        LoadingStackLayout.IsVisible = true;
                    });
                    if (await task.CancelDelay(5000)) return;
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        LoadingStackLayout.IsVisible = false;
                    });
                });
            }
        }
        private void EndLoading(string qcmd)
        {         
            
            if (isLoadingDictionary.ContainsKey(qcmd))
            {
                isLoadingDictionary[qcmd] = false;
            }
            else
            {
                isLoadingDictionary.Add(qcmd, false);
            }
            Device.BeginInvokeOnMainThread(() =>
            {
                LoadingStackLayout.IsVisible = false;
            });
        }
    }
}