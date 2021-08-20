using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
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
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = new System.Globalization.CultureInfo("ja-JP");
            System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = new System.Globalization.CultureInfo("ja-JP");

        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {


            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;
                var info = Windows.Graphics.Display.DisplayInformation.GetForCurrentView();
                BomNuoc.Resource.Size.Init(500, 500, info.LogicalDpi / 96.0);
                info.DpiChanged += (s, arg) => BomNuoc.Resource.Size.Init(500, 500, s.LogicalDpi / 96.0);
                var titleBar = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().TitleBar;
                titleBar.BackgroundColor = Windows.UI.Color.FromArgb(0xFF, 0x00, 0x7A, 0xCC);
                titleBar.ForegroundColor = Windows.UI.Colors.White;
                titleBar.InactiveBackgroundColor = Windows.UI.Color.FromArgb(0xFF, 74, 138, 181);
                titleBar.InactiveForegroundColor = Windows.UI.Colors.DarkGray;

                titleBar.ButtonBackgroundColor = Windows.UI.Color.FromArgb(0xFF, 0x00, 0x7A, 0xCC);
                titleBar.ButtonHoverBackgroundColor = Windows.UI.Color.FromArgb(0xFF, 0x00, 0x92, 0xF2);
                titleBar.ButtonPressedBackgroundColor = Windows.UI.Color.FromArgb(0xFF, 0x2B, 0xAA, 0xFF);
                titleBar.ButtonInactiveBackgroundColor = Windows.UI.Color.FromArgb(0xFF, 74, 138, 181);

                titleBar.ButtonForegroundColor = Windows.UI.Colors.White;
                titleBar.ButtonHoverForegroundColor = Windows.UI.Colors.White;
                titleBar.ButtonPressedForegroundColor = Windows.UI.Colors.White;
                titleBar.ButtonInactiveForegroundColor = Windows.UI.Colors.DarkGray;
                List<Assembly> assembliesToInclude = new List<Assembly>();
                assembliesToInclude.Add(typeof(BomNuoc.App).GetTypeInfo().Assembly);
                assembliesToInclude.Add(typeof(Acr.UserDialogs.UserDialogs).GetTypeInfo().Assembly);
                //assembliesToInclude.Add(typeof(PDS.Xamarin.Generic.Array).GetTypeInfo().Assembly);
                assembliesToInclude.Add(typeof(PDS.Xamarin.SSL.ISSLClient).GetTypeInfo().Assembly);
                assembliesToInclude.Add(typeof(PDS.Xamarin.SSL.UWP.SSLClient).GetTypeInfo().Assembly);
                assembliesToInclude.Add(typeof(PDS.Xamarin.Data.IDataFileStream).GetTypeInfo().Assembly);
                assembliesToInclude.Add(typeof(PDS.Xamarin.Data.UWP.DataFileStream).GetTypeInfo().Assembly);
                assembliesToInclude.Add(typeof(PDS.Xamarin.SQL.IFileHelper).GetTypeInfo().Assembly);
                assembliesToInclude.Add(typeof(PDS.Xamarin.SQL.UWP.FileHelper).GetTypeInfo().Assembly);
                //assembliesToInclude.Add(typeof(ASK.Xamarin.Assembly.IAssemblyService).GetTypeInfo().Assembly);
                //assembliesToInclude.Add(typeof(ASK.Xamarin.Assembly.UWP.AssemblyService).GetTypeInfo().Assembly);

                Xamarin.Forms.Forms.Init(e, assembliesToInclude);

                //Xamarin.Forms.Forms.Init(e);
                Xamarin.Forms.DependencyService.Register<BomNuoc.App>();
                //Xamarin.Forms.DependencyService.Register<Acr.UserDialogs.Command>();
                //Xamarin.Forms.DependencyService.Register<PDS.Xamarin.Generic>();
                Xamarin.Forms.DependencyService.Register<PDS.Xamarin.SSL.ISSLClient, PDS.Xamarin.SSL.UWP.SSLClient>();
                Xamarin.Forms.DependencyService.Register<PDS.Xamarin.Data.IDataFileStream, PDS.Xamarin.Data.UWP.DataFileStream>();
                
                Xamarin.Forms.DependencyService.Register<PDS.Xamarin.SQL.IFileHelper, PDS.Xamarin.SQL.UWP.FileHelper>();
                                //Xamarin.Forms.DependencyService.Register<ASK.Xamarin.Assembly.IAssemblyService, ASK.Xamarin.Assembly.UWP.AssemblyService>();

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                rootFrame.Navigate(typeof(MainPage), e.Arguments);
            }
            // Ensure the current window is active
            Window.Current.Activate();
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
