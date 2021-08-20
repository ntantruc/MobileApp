using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace BomNuoc.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = new System.Globalization.CultureInfo("ja-JP");
            System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = new System.Globalization.CultureInfo("ja-JP");

            //ZXing.Net.Mobile.Forms.WindowsUniversal.ZXingScannerViewRenderer.Init();
            //var app = new BomNuoc.App();
            //BomNuoc.Globals.TryEnterFullScreenEvent += TryEnterFullScreen;
            LoadApplication(new BomNuoc.App());
            //this.LoadApplication(app);
        }
        /*
        public void TryEnterFullScreen(object sender, EventArgs e)
        {
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().FullScreenSystemOverlayMode = Windows.UI.ViewManagement.FullScreenSystemOverlayMode.Minimal;
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().TryEnterFullScreenMode();
        }

        ~MainPage()
        {
            Globals.TryEnterFullScreenEvent -= TryEnterFullScreen;
        }
        */
    }
}
