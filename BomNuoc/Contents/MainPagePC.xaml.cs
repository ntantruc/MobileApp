using Acr.UserDialogs;
//using ASK.Xamarin.Audio;
//using ASK.Xamarin.Generic;
using PDS.Xamarin.Generic;
//using HeartLine.Core.Controls;
using BomNuoc.Controls;
//using HeartLine.Core.SSL;
using BomNuoc.SSL;
//using HeartLine.Core.ViewModels;
using BomNuoc.ViewModels;
//using Plugin.Share;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace BomNuoc.Contents
{
    public partial class MainPagePC : ContentPage
    {
       // public PatientInfoViewModel patientInfoViewModel = new PatientInfoViewModel();
        public PageView mainPageView;
        //public PageView mainPageViewNurseRecord;
       // public PageView mainPageViewVitalSign;
        //public PageView sidePageView;
        //public VideoCallPage videoCallPage;
        //public PageView videoCallPageView;
        //public Grid videoCallGrid;
        public AbsoluteLayout topAbsoluteLayout;
        public MainPagePC()
        {

            InitializeComponent();
            if (Device.RuntimePlatform == Device.Android)
            {
                var scrollview = new ScrollView
                {
                    Padding = new Thickness(0),
                    Margin = new Thickness(0),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    Orientation = ScrollOrientation.Vertical,
                };
                scrollview.SizeChanged += Scrollview_SizeChanged;
                this.Content = scrollview;
                scrollview.Content = TopAbsoluteLayout;
                TopAbsoluteLayout.HorizontalOptions = LayoutOptions.Start;
                TopAbsoluteLayout.VerticalOptions = LayoutOptions.Start;
            }
            Globals.MainPagePC = this;
            mainPageView = MainPageView;
            /*
            UpdateFontSizeView();

            Globals.Ble = new BLEWrapper();
            Globals.Ble.Init();

            //QRCodeReader
            if (Globals.config.QRSerialPortId.IsNullOrWhiteSpace() == false)
            {
                var serialDevice = Globals.SerialDeviceList.FirstOrDefault(_ => _.Id == Globals.config.QRSerialPortId);
                if (serialDevice != null)
                {
                    Globals.StartSerialDevice?.Invoke(serialDevice);
                }
            }

            if (Globals.CurrentFacilityFlags.IsFreeVersion())
            {
                HealthCarePageButton.SetDisable();
                PrescriptionPageButton.SetDisable();
                TestResultPageButton.SetDisable();
                NurseRecordPageButton.SetDisable();
                ManageInstructionPageButton.SetDisable();
                PrescriptionInstructionPageButton.SetDisable();
                InjectionInstructionPageButton.SetDisable();
                NursingInstructionPageButton.SetDisable();
            }
            if (Globals.CurrentFacilityFlags.UseVideoCall == false)
            {
                PatientVideoCallButton.SetDisable();
            }
            if (Globals.CurrentFacilityFlags.Flag2 == false)
            {
                DialysisManagementPageButton.IsVisible = false;
            }
                

            PatientInfoLayout.BindingContext = patientInfoViewModel;

            ViewNameLabel.Text = Globals.CurrentUserData.ViewName;

            //SpacerPageView.ViewPage = new SpacerPage();

            mainPageView = MainPageView;
            mainPageViewNurseRecord = MainPageViewNurseRecord;
            mainPageViewVitalSign = MainPageViewVitalSign;
            sidePageView = SidePageView;
            SidePageView.ViewPage = new DoctorCallListPage();
            videoCallPage = new VideoCallPage();
            videoCallPageView = VideoCallPageView;
            videoCallPageView.ViewPage = videoCallPage;
            videoCallGrid = VideoCallGrid;
            topAbsoluteLayout = TopAbsoluteLayout;
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
                Globals.MainPagePC.mainPageViewVitalSign.ViewPage = page;
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
                var page = new GlucosePage();
                Globals.LoadedPages.Add(page, page.Refresh);
            }
            {
                var page = new SettingPage();
                Globals.LoadedPages.Add(page, null);
            }
            {
                var page = new NurseRecordPage();
                Globals.LoadedPages.Add(page, page.Refresh);
                Globals.MainPagePC.mainPageViewNurseRecord.ViewPage = page;
            }
            {
                var page = new ManageInstructionPage();
                Globals.LoadedPages.Add(page, page.Refresh);
            }
            {
                var page = new PrescriptionInstructionPage();
                Globals.LoadedPages.Add(page, page.Refresh);
            }
            {
                var page = new DuplicatePrescriptionHistoryPage();
                Globals.LoadedPages.Add(page, page.Refresh);
            }
            {
                var page = new InjectionInstructionPage();
                Globals.LoadedPages.Add(page, page.Refresh);
            }
            {
                var page = new HealthCarePage();
                Globals.LoadedPages.Add(page, page.Refresh);
            }
            {
                var page = new DialysisPage();
                Globals.LoadedPages.Add(page, page.Refresh);
            }
            {
                var page = new DialysisConditionPage();
                Globals.LoadedPages.Add(page, page.Refresh);
            }
            {
                var page = new DocumentPage();
                Globals.LoadedPages.Add(page, page.Refresh);
            }
            {
                var page = new NursingInstructionPage();
                Globals.LoadedPages.Add(page, page.Refresh);
            }
            {
                var page = new PatientListPage();
                Globals.LoadedPages.Add(page, page.Refresh);
                mainPageView.ViewPage = page;
                if (Globals.CurrentUserData.UserType == SQL.SQLTables.UserTypes.Patient)
                {
                    LoadPatientUser();
                }
                else
                {
                    page.Refresh();
                }
            }
            */
            {
                var page = new ProfileSetting();
                Globals.LoadedPages.Add(page, page.Refresh);
            }
            {
                var page = new PDSInfo();
                Globals.LoadedPages.Add(page, page.Refresh);
            }
            {
                var page = new WaterLevelSetting();
                Globals.LoadedPages.Add(page, page.Refresh);
            }

            {
                var page = new PumpControlList();
                Globals.LoadedPages.Add(page, page.Refresh);
                mainPageView.ViewPage = page;               
            }

            {
                var page = new PumpRecords();
                Globals.LoadedPages.Add(page, page.Refresh);
                mainPageView.ViewPage = page;
            }
        }

        private double oldwidth = -1;
        private double oldheight = -1;
        //Android Only
        private void Scrollview_SizeChanged(object sender, EventArgs e)
        {
            var view = (ScrollView)sender;
            if (oldwidth != view.Width && oldheight != view.Height)
            {
                if ((oldwidth == -1) ||
                    (oldwidth > oldheight && view.Width < view.Height) ||
                    (oldwidth < oldheight && view.Width > view.Height) ||
                    (oldwidth == view.Width && oldheight < view.Height))
                {//初回 or 横向きが縦向きに or 縦向きが横向きに or 幅がそのまま高さ拡大時(キーボード開いたまま回転して、その後キーボード閉じたとき)
                    oldwidth = view.Width;
                    oldheight = view.Height;
                    TopAbsoluteLayout.WidthRequest = oldwidth;
                    TopAbsoluteLayout.HeightRequest = oldheight;
                }
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Globals.HideLoading();
            LoadPatientUser();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
          //  Globals.StopSerialDevice?.Invoke();
        }

        private async void LoadPatientUser()
        {
            //PatientListPageButton.IsVisible = false;

            // var list = await Globals.sslClient.GetTableAllDataAsync<SQL.SQLTables.Patient>(
            //        "`GroupName` = '" + Globals.CurrentUserData.GroupName + "' AND `FacilityName`='" + Globals.CurrentUserData.FacilityName + "' AND `PatientID`='" + Globals.CurrentUserData.PatientID + "'"
            //        , true);

            // Globals.SelectPatient(list.FirstOrDefault());
            Globals.CurrentCabinets = (await Globals.sslClient.GetTableAllDataAsync<SQL.SQLTables.Cabinets>("`ID`='" + Globals.CurrentUserData.CabinetsID + "'", true)).First(); ;
            Globals.CurrentFieldsList = await Globals.sslClient.GetTableAllDataAsync<SQL.SQLTables.Field>("`CabinetsID`='" + Globals.CurrentCabinets.ID + "' AND `IsAlive`=1", true);
            
            System.Diagnostics.Debug.WriteLine("======NGUYEN TAN TRUC:" + Globals.CurrentFieldsList.Count);
            Globals.ChangeDetailPage<PumpControlList>();
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
           // Globals.ChangeDetailPage<PrescriptionPage>();
        }

        private void VitalPageButton_Clicked(object sender, EventArgs e)
        {
            //Globals.ChangeDetailPage<VitalPage>();
        }

        private void PictureListPageButton_Clicked(object sender, EventArgs e)
        {
           // Globals.ChangeDetailPage<PictureListPage>();
        }

        private void TestResultPageButton_Clicked(object sender, EventArgs e)
        {
           // Globals.ChangeDetailPage<TestResultPage>();
        }

        private void GlucosePageButton_Clicked(object sender, EventArgs e)
        {
          //  Globals.ChangeDetailPage<GlucosePage>();
        }

        private void NurseRecordPageButton_Clicked(object sender, EventArgs e)
        {
           // Globals.ChangeDetailPage<NurseRecordPage>();
        }

        private void ManageInstructionPageButton_Clicked(object sender, EventArgs e)
        {
           // Globals.ChangeDetailPage<ManageInstructionPage>();
        }

        private void InjectionInstructionPageButton_Clicked(object sender, EventArgs e)
        {
           // Globals.ChangeDetailPage<InjectionInstructionPage>();
        }

        private void PrescriptionInstructionPageButton_Clicked(object sender, EventArgs e)
        {
           // Globals.ChangeDetailPage<PrescriptionInstructionPage>();
        }

        private void HealthCarePageButton_Clicked(object sender, EventArgs e)
        {
            //Globals.ChangeDetailPage<HealthCarePage>();
        }
        private void DialysisManagementPageButton_Clicked(object sender, EventArgs e)
        {
           // Globals.ChangeDetailPage<DialysisPage>();
        }
        private void DocumentPageButton_Clicked(object sender, EventArgs e)
        {
           // Globals.ChangeDetailPage<DocumentPage>();
        }

        private void NursingInstructionPageButton_Clicked(object sender, EventArgs e)
        {
            //Globals.ChangeDetailPage<NursingInstructionPage>();
        }

        private void LogoutButton_Clicked(object sender, EventArgs e)
        {
            Globals.CurrentToken = SSLClient.defaultToken;
            Globals.sslClient?.Disconnect();
            App.Current.MainPage = new LoginPage();
        }

        //private double s = 1.0;
        private async void FontSizeDownButton_Clicked(object sender, EventArgs e)
        {
            await Globals.ShowLoading("設定中");
            Resource.Size.ViewScale -= 0.1;
            UpdateFontSizeView();
            //Globals.HideLoading();

        }

        private async void FontSizeUpButton_Clicked(object sender, EventArgs e)
        {
            await Globals.ShowLoading("設定中");
            Resource.Size.ViewScale += 0.1;
            UpdateFontSizeView();
           // Globals.HideLoading();
        }

        private void UpdateFontSizeView()
        {
            var scale = Resource.Size.ViewScale;
            FontSizeLabel.Text = "文字サイズ:x" + scale.ToString("0.0");
            FontSizeStackLayout.Children.Clear();
            for (int i = 0; i < 10; i++)
            {
                if (Math.Round(0.8 + 0.1 * i, 1) == Math.Round(scale, 1))
                {
                    FontSizeStackLayout.Children.Add(new BoxView { BackgroundColor = Color.Black, WidthRequest = calc.i.c4, HeightRequest = calc.i.c20, Margin = new Thickness(calc.i.c1), VerticalOptions = LayoutOptions.Center });
                }
                else
                {
                    FontSizeStackLayout.Children.Add(new BoxView { BackgroundColor = Color.Gray, WidthRequest = calc.i.c3, HeightRequest = calc.i.c3, Margin = new Thickness(calc.i.c1, calc.i.c1, calc.i.c2, calc.i.c3), VerticalOptions = LayoutOptions.Center });
                }
            }
        }

        private void PatientSelectExpand_Clicked(object sender, EventArgs e)
        {
            //Globals.ChangeDetailPage<PatientListPage>();
        }

        private bool IsShowSidePageView = true;
        public void ShowSidePageView()
        {
            //SidePageView.IsVisible = true;
           // SidePageView.Bind(PageView.WidthRequestProperty, Converters.FromCode.CalcBinding(260));
            IsShowSidePageView = true;
        }

        public void HideSidePageView()
        {
            //SidePageView.IsVisible = false;
            //SidePageView.RemoveBinding(PageView.WidthRequestProperty);
            //SidePageView.WidthRequest = 0;
            IsShowSidePageView = false;
        }

        private void DoctorCallExpand_Clicked(object sender, EventArgs e)
        {
            /*
            if (IsShowSidePageView && SidePageView.ViewPage.GetType() == typeof(DoctorCallListPage))
            {
                HideSidePageView();
            }
            else
            {
                ShowSidePageView();
                SidePageView.ViewPage = new DoctorCallListPage();
            }
            */
        }

        private void DoctorCallButton_Clicked(object sender, EventArgs e)
        {
          
        }

        private void DoctorCallHistoryButton_Clicked(object sender, EventArgs e)
        {
          
        }

        private void DoctorCallSendHistoryButton_Clicked(object sender, EventArgs e)
        {
            
        }

        private async void PatientInfoButton_Clicked(object sender, EventArgs e)
        {
           
        }
        private async void PatientVideoCallButton_Clicked(object sender, EventArgs e)
        {
            
        }

        private async void TestButton_Clicked(object sender, EventArgs e)
        {
          
        }

     
        private void ListInputButton_Clicked(object sender, EventArgs e)
        {
           
        }

        private async void RefreshButton_Clicked(object sender, EventArgs e)
        {
           
        }

        private async void PatientNoticeButton_Clicked(object sender, EventArgs e)
        {
          
        }

        private void InputHelperButton_Clicked(object sender, EventArgs e)
        {
           
           
        }

        private void ContentPage_SizeChanged(object sender, EventArgs e)
        {

        }

        private void BomNuocPage_Clicked(object sender, EventArgs e)
        {
            Globals.ChangeDetailPage<PumpControlList>();
        }
        //Phong Đạt solution 
        private void ProfileSettingButton_Clicked(object sender, EventArgs e)
        {
            Globals.ChangeDetailPage<ProfileSetting>();
        }
        private void SettingPageButton_Clicked(object sender, EventArgs e)
        {
            Globals.ChangeDetailPage<PDSInfo>();
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
