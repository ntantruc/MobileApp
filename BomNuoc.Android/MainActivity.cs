using System;
using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
namespace BomNuoc.Droid
{
    [Activity(Label = "BomNuoc", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        WindowSoftInputMode = SoftInput.AdjustResize,
        NoHistory = false,
        LaunchMode = LaunchMode.SingleInstance) ]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            //Modified
            var w = (int)(Resources.DisplayMetrics.WidthPixels / Resources.DisplayMetrics.Density);
            var h = (int)(Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density);
            BomNuoc.Resource.Size.Init(
                w, // device independent pixels
                h // device independent pixels
            );
            ZXing.Net.Mobile.Forms.Android.Platform.Init();
            Xamarin.Forms.DependencyService.Register<PDS.Xamarin.SSL.ISSLClient, PDS.Xamarin.SSL.Droid.SSLClient>();
            Xamarin.Forms.DependencyService.Register<PDS.Xamarin.Data.IDataFileStream, PDS.Xamarin.Data.Droid.DataFileStream>();
            Xamarin.Forms.DependencyService.Register<PDS.Xamarin.SQL.IFileHelper, PDS.Xamarin.SQL.Droid.FileHelper>();

            //Xamarin.Forms.DependencyService.Register<ASK.Xamarin.Assembly.IAssemblyService, ASK.Xamarin.Assembly.Droid.AssemblyService>();
            Acr.UserDialogs.UserDialogs.Init(this);
            AndroidEnvironment.UnhandledExceptionRaiser += (sender, e) =>
            {
                System.Diagnostics.Debug.WriteLine(e.Exception.Message + "\r\n" + e.Exception.StackTrace);
                e.Handled = true;
            };
            LoadApplication(new BomNuoc.App());

            BomNuoc.App.Current.On<Xamarin.Forms.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);

            //LoadApplication(new App());

        }
        public override void OnBackPressed()
        {
            //base.OnBackPressed();
        }

    }
}