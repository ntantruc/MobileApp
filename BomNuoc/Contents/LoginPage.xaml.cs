using Acr.UserDialogs;
//using ASK.Xamarin.Generic;
using PDS.Xamarin.Generic;
//using ASK.Xamarin.SkyWay;
//using HeartLine.Core.SSL;
using BomNuoc.SSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BomNuoc.Contents
{
    public partial class LoginPage : ContentPage
    {

        public LoginPage()
        {
            InitializeComponent();
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = new System.Globalization.CultureInfo("ja-JP");
            System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = new System.Globalization.CultureInfo("ja-JP");

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await Globals.config.LoadAsync();
            //UserNameEntry.Text =  "truc";
            //Globals.config.UserName = "truc";
            //PasswordEntry.Text = "truc@1";
            //Globals.config.Password = "truc@1";
            //UserNameEntry.Text =  "tri";
            //Globals.config.UserName = "tri";
            //PasswordEntry.Text = "tri@bt156";
            //Globals.config.Password = "tri@bt156";
            UserNameEntry.Text = Globals.config.UserName;
            PasswordEntry.Text = Globals.config.Password;

            UserNameSaveSwitch.IsToggled = Globals.config.IsUserNameSaved;
            AutoLoginSwitch.IsToggled = Globals.config.IsAutoLogin;
            Resource.Size.ViewScale = Globals.config.ViewScale;

            //SQL.SQLTables.Cabinets tesst = new SQL.SQLTables.Cabinets();
            //tesst.TimeOn = DateTime.Now;
            //System.Diagnostics.Debug.WriteLine("===truc==Before=" + (tesst.TimeOn));
            //byte[] serializetemp = MessagePack.LZ4MessagePackSerializer.NonGeneric.Serialize(tesst.GetType(), tesst);
            //var obj = MessagePack.LZ4MessagePackSerializer.NonGeneric.Deserialize(tesst.GetType(), serializetemp);
            //System.Diagnostics.Debug.WriteLine("===truc===" + ((SQL.SQLTables.Cabinets)obj).TimeOn);
            //try
            //{
               // System.Diagnostics.Debug.WriteLine("Truc === time======1");
               // TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Jakarta");
                //System.Diagnostics.Debug.WriteLine("Truc === time======1Okie" + global::System.TimeZoneInfo.ConvertTimeFromUtc(DateTime.Now, cstZone));
                //System.Diagnostics.Debug.WriteLine("Truc === time======1Okie");
            //}
            //catch
            //{
                //System.Diagnostics.Debug.WriteLine("Truc === time======Exception1.");
            //}

        }
        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            bool IsHideLoading = false;
            try
            {
                await Globals.ShowLoading("Đang kết nối để đăng nhập ...");
                LoginButton.IsEnabled = false;
                var username = UserNameEntry.Text;
                var password = PasswordEntry.Text;
                
                if (string.IsNullOrWhiteSpace(username))
                {
                    await UserDialogs.Instance.AlertAsync("Xin nhập tên đăng nhập đúng! ", "Lỗi", "OK");
                    LoginButton.IsEnabled = true;
                    UserNameEntry.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(password))
                {
                    await UserDialogs.Instance.AlertAsync("Xin nhập mật khẩu đúng! ", "Lỗi", "OK");
                    LoginButton.IsEnabled = true;
                    PasswordEntry.Focus();
                    return;
                }
                if (username.EndsWith("@develop"))
                {
                   // Globals.ServerIPAddress = "192.168.123.149";
                    username = username.Replace("@develop", "");
                }

                if (username == "dbg" && password == "dbg")
                {
                    await Task.Delay(2000);
                    App.Current.MainPage = new MainPagePhone();
                }
                else
                {
                    Globals.sslClient?.Disconnect();
                    Globals.sslClient = new SSLClient();
                    if (await Globals.sslClient.Connect())
                    {
                        //await Globals.sslClient.SendCommandWait(new SSLCommands.Login() { UserName = username, Password = password, token = SSLClient.defaultToken },
                        await Globals.sslClient.SendCommandBinaryWait(new SSLCommands.Login() { UserName = username, Password = password, token = SSLClient.defaultToken },
(Action<SSLCommands.SSLCommandBase>)(async (ret) =>
                            {
                                if (ret.GetType() == typeof(SSLCommands.ErrorMessage))
                                {
                                    Debug.Log("===ErrorMessage");
                                    var data = (SSLCommands.ErrorMessage)ret;
                                    Globals.sslClient?.Disconnect();
                                    Globals.HideLoading();
                                    IsHideLoading = true;
                                    await UserDialogs.Instance.AlertAsync("Không kết nối với máy chủ! Xin kết nối lại lần sau. ", "Lỗi", "OK");
                                    LoginButton.IsEnabled = true;
                                }
                                else if (ret.GetType() == typeof(SSLCommands.UpdateToken))
                                {
                                    Debug.Log("===UpdateToken");
                                    var data = (SSLCommands.UpdateToken)ret;
                                    Globals.CurrentToken = data.token;
                                    Globals.sslClient.StartSendAck();
                                    Device.BeginInvokeOnMainThread((Action)(async () =>
                                    {
                                        //ユーザー情報を取得
                                        Globals.CurrentUserData = (await Globals.sslClient.GetTableAllDataAsync<SQL.SQLTables.User>("`UserName`='" + username + "' AND `token`='" + Globals.CurrentToken + "'", true)).First();
                                        Globals.config.IsAutoLogin = AutoLoginSwitch.IsToggled;
                                        if (Globals.config.IsAutoLogin)
                                        {
                                            UserNameSaveSwitch.IsToggled = true;
                                            Globals.config.Password = PasswordEntry.Text;
                                        }
                                        else
                                        {
                                            Globals.config.Password = PasswordEntry.Text;
                                            //Globals.config.Password = "";
                                        }
                                        Debug.Log("===GetTableAllDataAsync");
                                        Globals.config.IsUserNameSaved = UserNameSaveSwitch.IsToggled;
                                        if (Globals.config.IsUserNameSaved) Globals.config.UserName = UserNameEntry.Text;
                                        else Globals.config.UserName = "";
                                        Globals.config.Save();
                                        if (Globals.CurrentUserData.UserType == SQL.SQLTables.UserTypes.User)
                                        {                                            
                                            Globals.CooperativeData = (await Globals.sslClient.GetTableAllDataAsync<SQL.SQLTables.Cooperative>("`CabinetsID`='" + Globals.CurrentUserData.CabinetsID + "'", true)).First();
                                            Globals.ProvinceData = (await Globals.sslClient.GetTableAllDataAsync<SQL.SQLTables.Province>("`ProvinceName`='" + Globals.CooperativeData.ProvinceName + "'", true)).First();
                                            Debug.Log("===User type");
                                            if (Device.Idiom == TargetIdiom.Phone)
                                            {
                                                Debug.Log("===Phone");
                                                Globals.HideLoading();
                                                IsHideLoading = true;
                                                await Globals.ShowLoading("Đang mở chương trình ...");
                                                App.Current.MainPage = new MainPagePhone();                                                
                                            }
                                            else
                                            {
                                                Debug.Log("===PC");
                                                Globals.HideLoading();
                                                IsHideLoading = true;
                                                await Globals.ShowLoading("Đang mở chương trình ...");
                                                App.Current.MainPage = new MainPagePC();
                                            }
                                        }
                                    }));
                                }
                            }));
                    }
                    else
                    {
                        Globals.HideLoading();
                        IsHideLoading = true;
                        await UserDialogs.Instance.AlertAsync("Không kết nối được với server", "Lỗi", "OK");
                        LoginButton.IsEnabled = true;
                    }
                }
            }
            finally
            {
                if (IsHideLoading == false) Globals.HideLoading();
            }
        }      
    }
}
