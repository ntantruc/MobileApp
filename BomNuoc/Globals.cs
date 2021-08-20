using Acr.UserDialogs;
using BomNuoc.Contents;
using PDS.Xamarin.Data;
//using ASK.Xamarin.Audio;
//using ASK.Xamarin.BluetoothLE;
//using ASK.Xamarin.Data;
//using ASK.Xamarin.Generic;
using PDS.Xamarin.Generic;
//using ASK.Xamarin.SQL;
using PDS.Xamarin.SQL;
//using HeartLine.Core.Contents;
//using BomNuoc.Contents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BomNuoc
{
    public static class CR
    {
        public static string LF = "\r\n";
    }
    
    public static class Globals
    {
        public static string ServerIPAddress = "103.77.167.95";

        //public static string ServerIPAddress = "192.168.1.241"; // Wifi IP
        
        //public static string ServerIPAddress = "192.168.1.5"; // LAN cable IP

        public static int ServerPort = 16008;
        public static string CurrentToken { get; set; }

        public static SSLClient sslClient;
        public static SQLite localDB = new SQLite(DependencyService.Get<IFileHelper>().GetLocalFilePath("PDSCom11.db"));
        public static Contents.MainPagePhone MainPagePhone = null;
        public static Contents.MainPagePC MainPagePC = null;
        public static Page CurrentPagePhone = null;
        public static AsyncLock asyncLock = new AsyncLock();

        public static Config config = new Config();

        public static SQL.SQLTables.Province ProvinceData = null;
        public static SQL.SQLTables.Cooperative CooperativeData = null;
        public static SQL.SQLTables.User CurrentUserData = null;
        public static SQL.SQLTables.Cabinets CurrentCabinets = null;        
        public static List<SQL.SQLTables.Field> CurrentFieldsList = new List<SQL.SQLTables.Field>();
        public static SQL.SQLTables.Field CurrentSettingFieldData = null;
        public static SQL.SQLTables.Water CurrentSettingWaterData = null;

        public static UpdateDataScheduling updateDataScheduler = new UpdateDataScheduling();
        public static List<string> ReminderListAll = new List<string>();

        public static Dictionary<string, string> doctorList = new Dictionary<string, string>();
        public static List<string> FollowList = new List<string>();
        public static event EventHandler TryEnterFullScreenEvent;
        public static void TryEnterFullScreen()
        {
            TryEnterFullScreenEvent?.Invoke(null, EventArgs.Empty);
        }


        public static int ReminderThresholdDate = 120; // 5 days
        public static int ReminderDisplayHour = 3; // 3h default.
        //public static SQL.SQLTables.FacilityFlags CurrentFacilityFlags = null;
        public static bool DoctorCheckBoxTodayList = true;
        public static bool AdminCheckBoxNextDayList = true;

        public static string CommonFolder = System.AppDomain.CurrentDomain.BaseDirectory;

        public static string AppID = "BomNuoc";        
        public static Random Random = new Random();
        
        public class Config
        {
            public string DisplayHour { get; set; } = "";
            public string UserName { get; set; } = "";
            public string Password { get; set; } = "";
            public bool IsUserNameSaved { get; set; }
            public bool IsAutoLogin { get; set; }


            public double ViewScale { get; set; } = 1.0;
            public string QRSerialPortId { get; set; }
            string appPath = System.AppDomain.CurrentDomain.BaseDirectory;
            public void Save()
            {
                try
                {
                    //  File.WriteAllText(appPath + "\\" + nameof(Config) + ".json", Json.Serializer.Serialize(config));
                    var file = DependencyService.Get<IDataFileStream>();
                    file.WriteData(nameof(Config) + ".json", Json.Serializer.Serialize(config));

                    System.Diagnostics.Debug.WriteLine("Save configuration file completely.");
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine("ERROR: when saving configuration file.");
                }
            }

            public async Task LoadAsync()
            {

                try
                {
                    System.Diagnostics.Debug.WriteLine("Reading configuration file completely. Path: " + appPath + "\\" + nameof(Config) + ".json");
                    var file = DependencyService.Get<IDataFileStream>();
                    config = Json.Serializer.Deserialize<Config>(await file.ReadDataAsync(nameof(Config) + ".json"));
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine("ERROR: when reading configuration file.");
                }

            }
        }


        #region "Page display"

        public static Dictionary<Page, Action> LoadedPages = new Dictionary<Page, Action>();

        public static Page GetCurrentViewPage()
        {
            
            if (Globals.MainPagePhone != null) return Globals.MainPagePhone;
            if (Globals.MainPagePC != null)
            {
            /*    if (Globals.MainPagePC.mainPageView.IsVisible == false && Globals.MainPagePC.mainPageViewNurseRecord.IsVisible)
                {
                    return Globals.MainPagePC.mainPageViewNurseRecord.ViewPage;
                }
                else if (Globals.MainPagePC.mainPageView.IsVisible == false && Globals.MainPagePC.mainPageViewVitalSign.IsVisible)
                {
                    return Globals.MainPagePC.mainPageViewVitalSign.ViewPage;
                }
                else
                */
                {
                    return Globals.MainPagePC.mainPageView.ViewPage;
                }
            }
            return null;
        }

        public static async void ChangeDetailPage<T>(Page newPage = null, Action refresh = null)
        {
            await ShowLoading("Đang chuyển đổi trang .... ");
            System.Diagnostics.Debug.WriteLine("=========ChangeDetailPage 1");
                System.Diagnostics.Debug.WriteLine("=========ChangeDetailPage 3");
                if (newPage == null)
                {
                    foreach (var p in Globals.LoadedPages)
                    {
                        if (p.Key.GetType() == typeof(T))
                        {
                            newPage = p.Key;
                            refresh = p.Value;
                            System.Diagnostics.Debug.WriteLine("=========ChangeDetailPage 4");
                            break;
                        }
                    }
                }
                if (newPage == null)
                {
                    System.Diagnostics.Debug.WriteLine("=========ChangeDetailPage 4---NULLLL");
                    newPage = (Page)Activator.CreateInstance(typeof(T));
                }
                    
                if (Device.Idiom == TargetIdiom.Phone)
                {
                    System.Diagnostics.Debug.WriteLine("=========ChangeDetailPage 5");
                    Globals.CurrentPagePhone = newPage;
                    Globals.ReplaceRoot(newPage);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("=========ChangeDetailPage 6");
                    Globals.MainPagePC.mainPageView.IsVisible = true;
                    Globals.MainPagePC.mainPageView.ViewPage = (ContentPage)newPage;

                }
                System.Diagnostics.Debug.WriteLine("=========ChangeDetailPage 7");
                refresh?.Invoke();
            System.Diagnostics.Debug.WriteLine("=========ChangeDetailPage 8");
            HideLoading();
            return;
        }

        public static T GetLoadedPage<T>() where T : Page
        {
            foreach (var p in Globals.LoadedPages)
            {
                if (p.Key.GetType() == typeof(T))
                {
                    return (T)p.Key;
                }
            }
            return null;
        }

        public static NavigationPage Navigation
        {
            get
            {
                return (((App)Application.Current).MainPage as MasterDetailPage).Detail as NavigationPage;
            }
            set
            {
                (((App)Application.Current).MainPage as MasterDetailPage).Detail = value;
            }
        }

        public static async void ReplaceRoot(Page page)
        {
            System.Diagnostics.Debug.WriteLine("=========ReplaceRoot 1");
            var navi = new NavigationPage(page)
            {
                Title = page.Title,
                BarBackgroundColor = Resource.Colors.ASKBlue,
                BarTextColor = Color.White,
            };
            System.Diagnostics.Debug.WriteLine("=========ReplaceRoot 2");
            page.Title = Device.OnPlatform<string>(" ", "≡", "≡");
            System.Diagnostics.Debug.WriteLine("=========ReplaceRoot 2 - 111");
            if (navi == null)
                System.Diagnostics.Debug.WriteLine("=========ReplaceRoot 2 - 111 nulllllllllllll");
            Navigation = navi;
        /*                 var root = Navigation.Navigation.NavigationStack[0];
                       if (page != root)
                       {
                           Navigation.Navigation.InsertPageBefore(page, root);
                           page.Title = Device.OnPlatform<string>(" ", "≡", "≡");
                           await PopToRootAsync();
                       }
            */          
            System.Diagnostics.Debug.WriteLine("=========ReplaceRoot 3");
            CloseMenu();
            System.Diagnostics.Debug.WriteLine("=========ReplaceRoot 4");
        }

        public static void OpenMenu()
        {
            if (Device.Idiom == TargetIdiom.Phone) (((App)Application.Current).MainPage as MasterDetailPage).IsPresented = true;
        }

        public static void CloseMenu()
        {
            if (Device.Idiom == TargetIdiom.Phone) (((App)Application.Current).MainPage as MasterDetailPage).IsPresented = false;
        }

        public static async Task PopToRootAsync()
        {
            while (Navigation.Navigation.ModalStack.Count > 0)
            {
                await Navigation.Navigation.PopModalAsync(false);
            }
            while (Navigation.CurrentPage != Navigation.Navigation.NavigationStack[0])
            {
                await Navigation.PopAsync(false);
            }
        }
        #endregion
        //ForUWP
        #region "Show loading progress"
        private static int loadingShowCount = 0;

        public static async Task ShowLoading(string message)
        {
            using (await asyncLock.LockAsync())
            {
                loadingShowCount++;
                if (loadingShowCount == 1)
                {
                    UserDialogs.Instance.ShowLoading(Device.OnPlatform<string>(message, message, CR.LF + message + CR.LF), MaskType.Gradient);
                    await Task.Delay(100);
                }
                Debug.Log("loadingShowCount(show):" + loadingShowCount.ToString(), Debug.LogLevel.Unknown);
            }
        }
        public static async Task ShowLoading5Sec(string message)
        {
            using (await asyncLock.LockAsync())
            {
                loadingShowCount++;
                if (loadingShowCount == 1)
                {
                    UserDialogs.Instance.ShowLoading(Device.OnPlatform<string>(message, message, CR.LF + message + CR.LF), MaskType.Gradient);
                    await Task.Delay(5000);
                }
                Debug.Log("loadingShowCount(show):" + loadingShowCount.ToString(), Debug.LogLevel.Unknown);
            }
        }
        public static async void HideLoading()
        {
            using (await asyncLock.LockAsync())
            {
                if (loadingShowCount == 1) UserDialogs.Instance.HideLoading();
                if (loadingShowCount > 0) loadingShowCount--;
                Debug.Log("loadingShowCount(hide):" + loadingShowCount.ToString(), Debug.LogLevel.Unknown);
            }
        }

        public static async Task ShowToast(string message)
        {
            using (await asyncLock.LockAsync())
            {                
                UserDialogs.Instance.ShowLoading(Device.OnPlatform<string>(message, message, CR.LF + message + CR.LF), MaskType.Gradient);
                await Task.Delay(1500);
                UserDialogs.Instance.HideLoading();
                Debug.Log("loadingShowCount(show):" + loadingShowCount.ToString(), Debug.LogLevel.Unknown);
            }
        }
        #endregion



        public static async void RefreshPage()
        {
            if (Device.Idiom == TargetIdiom.Phone)
            {
                var newPage = Globals.CurrentPagePhone;
                    Action refresh = null;
                if (newPage == null) return;
                foreach (var p in Globals.LoadedPages)
                {
                    if (p.Key == newPage)
                    {
                        newPage = p.Key;
                        refresh = p.Value;
                        break;
                    }
                }
                refresh?.Invoke();
                HideLoading();
            }
            else
            {
                await ShowLoading("Đang đọc dữ liệu mới cập nhật...");
                var newPage = Globals.MainPagePC.mainPageView.ViewPage as Page;
                Action refresh = null;
                if (newPage == null) return;
                foreach (var p in Globals.LoadedPages)
                {
                    if (p.Key == newPage)
                    {
                        newPage = p.Key;
                        refresh = p.Value;
                        break;
                    }
                }
                refresh?.Invoke();
                HideLoading();
            }
            return;
        }


        //Send updating Data Sync.

        public static async Task SendUpdateDataAsync(SQL.SQLTables.Cabinets curentCabinets, SSL.SSLCommands.UpdateDataTypes datatype, object Data = null)
        {
            if (curentCabinets == null) return;
            // get all user belong currentCabinets.
            var users = await Globals.sslClient.GetTableAllDataAsync<SQL.SQLTables.User>("`CabinetsID`='" + curentCabinets.ID + "'", true);
            users.Remove(Globals.CurrentUserData);
            var command = new SSL.SSLCommands.UpdateData
            {
                token = Globals.CurrentToken,
                //CallFromJson = Json.Serializer.Serialize(Globals.CurrentUserData),
                CallToJson = Json.Serializer.Serialize(users),
                DataJson = Data == null ? "" : Json.Serializer.Serialize(Data),
                DataType = (int)datatype,                
                CabinetsJson = Json.Serializer.Serialize(Globals.CurrentCabinets),
            };
            await sslClient?.SendCommand(command);
        }
        public class UpdateDataScheduling
        {
            public class UpdateDataInfo
            {
                public SSL.SSLCommands.UpdateDataTypes type;
                public int callFromCabinetsID;
            }
            private static Queue<UpdateDataInfo> UpdateDataQueue = new Queue<UpdateDataInfo>();
            private static System.Threading.Thread mThread = null;
            private static bool UpdateFlag = false;
            public UpdateDataScheduling()
            {
                mThread = new System.Threading.Thread(mainThread);
                mThread.IsBackground = true;
                mThread.Start();
            }
            public void UpdateFlagEnable()
            {
                UpdateFlag = true;
            }
            private async void mainThread()
            {
                try
                {
                    while (true)
                    {
                        if (UpdateDataQueue.Count > 0)
                        {
                            if (UpdateFlag == false)
                            {
                                UpdateDataQueue.Dequeue();
                                continue;
                            }    
                            UpdateDataInfo data = UpdateDataQueue.Dequeue();
                            await BackgroundUpdate(data.type, data.callFromCabinetsID);
                            try
                            {
                                Device.BeginInvokeOnMainThread(() =>
                                {
                                    Type windowType = Globals.GetCurrentViewPage().GetType();
                                    bool NeedUpdate = false;
                                    System.Diagnostics.Debug.WriteLine("==========update background: " + windowType.ToString() + "  -  " + windowType + " = " + (SSL.SSLCommands.UpdateDataTypes)data.type);
                                    switch ((SSL.SSLCommands.UpdateDataTypes)data.type)
                                    {
                                        case SSL.SSLCommands.UpdateDataTypes.Cabinets:
                                            if (windowType == typeof(PumpControlList)) NeedUpdate = true;
                                            break;
                                        case SSL.SSLCommands.UpdateDataTypes.Water:
                                            if (windowType == typeof(PumpControlList)) NeedUpdate = true;
                                            break;
                                        
                                    }
                                    
                                    if ((NeedUpdate) || (windowType == typeof(MainPagePhone)))
                                    {
                                        System.Diagnostics.Debug.WriteLine("==========update background PHONE: " + windowType.ToString() );
                                        Globals.RefreshPage();
                                    }
                                    
                                });
                            }
                            catch
                            {
                                UpdateDataQueue.Enqueue(data);
                            }
                        }
                        //else
                        //{
                            System.Threading.Thread.Sleep(500);
                        //}

                    }
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine("================MAIN THREAD EXCEPTION");
                }

            }
            public void UpdateDataQueueAdd(UpdateDataInfo data)
            {
                try
                {
                    UpdateDataQueue.Enqueue(data);
                    System.Diagnostics.Debug.WriteLine("===============Add=QUEUE: " + data.callFromCabinetsID);
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine("================EXCEPTION of adding queue");
                }


            }
            public async Task BackgroundUpdate(SSL.SSLCommands.UpdateDataTypes type, int cabinetsID)
            {
            }

        }
    }
}
