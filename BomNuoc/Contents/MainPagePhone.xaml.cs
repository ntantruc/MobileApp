using Acr.UserDialogs;
//using ASK.Xamarin.Audio;
//using ASK.Xamarin.Generic;
using PDS.Xamarin.Generic;
//using HeartLine.Core.Controls;
using BomNuoc.Controls;
//using HeartLine.Core.SSL;
using BomNuoc.SSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace BomNuoc.Contents
{
    public partial class MainPagePhone : MasterDetailPage
    {

        public MainPagePhone()
        {
            InitializeComponent();
            Globals.MainPagePhone = this;
            System.Diagnostics.Debug.WriteLine("=========main phone init BEGIN");
            /*
     
            if (Globals.CurrentFacilityFlags.IsFreeVersion())
            {
                PictureListPageButton.SetDisable();
                VitalPageButton.SetDisable();
                PrescriptionPageButton.SetDisable();
                TestResultPageButton.SetDisable();
                //VideoCallPageButton.SetDisable();
            }

            patientIDLabel = PatientIDLabel;
            patientNameLabel = PatientNameLabel;
            {
                var page = new PatientListPage();
                Globals.LoadedPages.Add(page, page.Refresh);
                var navi = new NavigationPage(page)
                {
                    Title = page.Title,
                    BarBackgroundColor = Resource.Colors.ASKBlue,
                    BarTextColor = Color.White,
                };
                page.Title = Device.OnPlatform<string>(" ", "≡", "≡");
                Detail = navi;
            }
            {
                var page = new VideoCallPagePhone();
                Globals.LoadedPages.Add(page, null);
                videoCallPage = page;
            }
            {
                var page = new VideoCallListPage();
                Globals.LoadedPages.Add(page, page.Refresh);
            }
            {
                var page = new PrescriptionPage();
                Globals.LoadedPages.Add(page, page.Refresh);
            }
            {
                var page = new VitalPage();
                Globals.LoadedPages.Add(page, page.Refresh);
            }
            {
                var page = new PictureListPage();
                Globals.LoadedPages.Add(page, page.Refresh);
            }
            {
                var page = new TestResultPage();
                Globals.LoadedPages.Add(page, page.Refresh);
            }
            {
                var page = new SettingPage();
                Globals.LoadedPages.Add(page, null);
            }
            {
                var page = new GlucosePage();
                Globals.LoadedPages.Add(page, page.Refresh);
            }
            {
                var page = new NurseRecordPage();
                Globals.LoadedPages.Add(page, page.Refresh);
            }
            if (Globals.CurrentUserData != null && Globals.CurrentUserData.UserType == SQL.SQLTables.UserTypes.Patient)
            {
                LoadPatientUser();
            
    */
            {
                var page = new ProfileSetting();
                Globals.LoadedPages.Add(page, page.Refresh);
            }
            {
                var page = new WaterLevelSetting();
                Globals.LoadedPages.Add(page, page.Refresh);
            }
            {
                var page = new PDSInfo();
                Globals.LoadedPages.Add(page, page.Refresh);
            }

            {
                var page = new PumpControlList();
                Globals.LoadedPages.Add(page, page.Refresh);
                var navi = new NavigationPage(page)
                {
                    Title = page.Title,
                    BarBackgroundColor = Resource.Colors.ASKBlue,
                    BarTextColor = Color.White,
                };
                page.Title = Device.OnPlatform<string>(" ", "≡", "≡");
                Detail = navi;
            }
            {
                var page = new PumpRecords();
                Globals.LoadedPages.Add(page, page.Refresh);
            }


            //var page = new ContentPage();
            //System.Diagnostics.Debug.WriteLine("=========main phone init 1");
            // Globals.LoadedPages.Add(page, null);

            System.Diagnostics.Debug.WriteLine("=========main phone init 2");
           
          //  LoadPumpList();
            System.Diagnostics.Debug.WriteLine("=========main phone init END");
            IsPresented = true;
        }
        private async void LoadPumpList()
        {
            Globals.CurrentCabinets = (await Globals.sslClient.GetTableAllDataAsync<SQL.SQLTables.Cabinets>("`ID`='" + Globals.CurrentUserData.CabinetsID + "'", true)).First(); ;
            Globals.CurrentFieldsList = await Globals.sslClient.GetTableAllDataAsync<SQL.SQLTables.Field>("`CabinetsID`='" + Globals.CurrentCabinets.ID + "' AND `IsAlive`=1", true);

            System.Diagnostics.Debug.WriteLine("======NGUYEN TAN TRUC:" + Globals.CurrentFieldsList.Count);
            Globals.ChangeDetailPage<PumpControlList>();
        }
        /*
        private async void LoadPatientUser()
        {
            PatientListPageButton.IsVisible = false;

            var list = await Globals.sslClient.GetTableAllDataAsync<SQL.SQLTables.Patient>(
                    "`GroupName` = '" + Globals.CurrentUserData.GroupName + "' AND `FacilityName`='" + Globals.CurrentUserData.FacilityName + "' AND `PatientID`='" + Globals.CurrentUserData.PatientID + "'"
                    , true);

            Globals.SelectPatient(list.FirstOrDefault());
            Globals.ChangeDetailPage<GlucosePage>();
        }
        */
        protected override void OnAppearing()
        {
            System.Diagnostics.Debug.WriteLine("========OnAppearing1");
            base.OnAppearing();
            //Navigation.PushAsync(new LoginPage());
            IsPresented = true;
            System.Diagnostics.Debug.WriteLine("========OnAppearing2");
            Globals.HideLoading();
            System.Diagnostics.Debug.WriteLine("========OnAppearing3");
            LoadPumpList();
            //BLEの開始
        }

        private void PatientListPageButton_Clicked(object sender, EventArgs e)
        {
           // Globals.ChangeDetailPage<PatientListPage>();
        }

        private void VideoCallPageButton_Clicked(object sender, EventArgs e)
        {
           // Globals.ChangeDetailPage<VideoCallListPage>();
        }

        private void PrescriptionPageButton_Clicked(object sender, EventArgs e)
        {
            //Globals.ChangeDetailPage<PrescriptionPage>();
        }

        private void VitalPageButton_Clicked(object sender, EventArgs e)
        {
           // Globals.ChangeDetailPage<VitalPage>();
        }

        private void PictureListPageButton_Clicked(object sender, EventArgs e)
        {
            //Globals.ChangeDetailPage<PictureListPage>();
        }

        private void TestResultPageButton_Clicked(object sender, EventArgs e)
        {
           // Globals.ChangeDetailPage<TestResultPage>();
        }

        private void SettingPageButton_Clicked(object sender, EventArgs e)
        {
            Globals.ChangeDetailPage<ProfileSetting>();
        }
        private void GlucosePageButton_Clicked(object sender, EventArgs e)
        {
           // Globals.ChangeDetailPage<GlucosePage>();
        }

        private void LogoutButton_Clicked(object sender, EventArgs e)
        {
            Globals.CurrentToken = SSLClient.defaultToken;
            Globals.sslClient?.Disconnect();
            App.Current.MainPage = new LoginPage();
        }

        private void PumpButton_Clicked(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("============Bơm tưới is Clicked.");
            Globals.ChangeDetailPage<PumpControlList>();
        }

        private void PDSCompanyButton_Clicked(object sender, EventArgs e)
        {
            Globals.ChangeDetailPage<PDSInfo>();
        }

        private void PumpRecords_Clicked(object sender, EventArgs e)
        {
            Globals.ChangeDetailPage<PumpRecords>();
        }
    }
}
