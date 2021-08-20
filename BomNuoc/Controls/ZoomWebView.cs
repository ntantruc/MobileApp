using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BomNuoc.Controls
{
    public class ZoomWebView : WebView
    {
        #region Zoom BindableProperty
        public static readonly BindableProperty ZoomProperty =
            BindableProperty.Create(
                nameof(Zoom),
                typeof(double),
                typeof(ContentButton),
                0.0,
                BindingMode.Default,
                null,
                (bindable, oldValue, newValue) => { }
            );

        public double Zoom
        {
            get { return (double)GetValue(ZoomProperty); }
            set
            {
                SetValue(ZoomProperty, value);
            }
        }
        #endregion

        public bool DoScrollToEnd = false;

        public void StartNavigation()
        {
            this.IsVisible = false;
        }
#if __ANDROID__
        public new event EventHandler<WebNavigatedEventArgs> Navigated;
        public new event EventHandler<WebNavigatingEventArgs> Navigating;

        public void SendNavigated(WebNavigatedEventArgs args)
        {
            Navigated?.Invoke(this, args);
        }
        public void SendNavigating(WebNavigatingEventArgs args)
        {
            Navigating?.Invoke(this, args);
        }
#endif
        public async void RefreshView()
        {
            this.IsVisible = false;
            await Task.Delay(100);
            this.IsVisible = true;
#if __ANDROID__
            await Task.Delay(100);
            this.IsVisible = true;
            await Task.Delay(100);
            this.InvalidateMeasure();
#endif
        }

        public static string androidurl = Device.OnPlatform<string>("file://dummy/iOSDummy.html", "file:///android_asset/dummy.html", "");

        public class EvalJavascriptEventArgs : EventArgs
        {
            public string ScriptName { get; set; }
            public IEnumerable<string> Arguments { get; set; }
            public string ReturnString { get; set; }
            public bool ReturnFinished { get; set; }
            public EvalJavascriptEventArgs() : base() { }
            public EvalJavascriptEventArgs(string script) : this()
            {
                ScriptName = script;
            }
            public EvalJavascriptEventArgs(string script, IEnumerable<string> arguments) : this(script)
            {
                Arguments = arguments;
            }
        }

        public event EventHandler<EvalJavascriptEventArgs> EvalJavascriptRequested;

        public async Task<string> EvalJavascriptAsync(string scriptName, IEnumerable<string> arguments)
        {
            var args = new EvalJavascriptEventArgs(scriptName, arguments);
            EvalJavascriptRequested?.Invoke(this, args);
            while (args.ReturnFinished == false)
            {
                await Task.Delay(50);
            }
            return args.ReturnString;
        }
    }
}
