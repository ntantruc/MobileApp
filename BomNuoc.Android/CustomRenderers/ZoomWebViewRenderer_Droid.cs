using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
//using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using BomNuoc.Controls;
using System.ComponentModel;
using Android.Webkit;
using System.Threading.Tasks;
using Android.Graphics;
using AWebView = Android.Webkit.WebView;
using Java.Util.Regex;

[assembly: ExportRenderer(typeof(ZoomWebView), typeof(BomNuoc.Droid.CustomRenderers.ZoomWebViewRenderer_Droid))]

namespace BomNuoc.Droid.CustomRenderers
{
    public class ZoomWebViewRenderer_Droid : WebViewRenderer
    {
        public ZoomWebViewRenderer_Droid(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
        {
            try
            {
                base.OnElementChanged(e);
                if (e.OldElement != null)
                {
                    Control.Touch -= Control_Touch;
                }

                if (e.NewElement != null)
                {
                    Control.Touch += Control_Touch;
                }

                if (Element != null)
                {

                    //view.LoadFinished -= View_LoadFinished;
                    //view.LoadFinished += View_LoadFinished;
                    //view.LoadStarted -= View_LoadStarted;
                    //view.LoadStarted += View_LoadStarted;

                    var element = Element as ZoomWebView;
                    element.Navigated -= Element_Navigated;
                    element.Navigated += Element_Navigated;
                    SetZoomLevel(element.Zoom);
                }

                if (Control != null && Element != null)
                {
                    Control.SetWebViewClient(new MyWebViewClient(Element as ZoomWebView, this));
                }
                if (e.NewElement != null)
                {
                    ((ZoomWebView)e.NewElement).EvalJavascriptRequested += OnEvalJavascriptRequested;
                }
                if (e.OldElement != null)
                {
                    ((ZoomWebView)e.OldElement).EvalJavascriptRequested -= OnEvalJavascriptRequested;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Assert(false, ex.Message);
            }
        }

        private void OnEvalJavascriptRequested(object sender, ZoomWebView.EvalJavascriptEventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                //while (loading)
                //{
                //    await Task.Delay(50);
                //}
                var retry = 1;
                while (true)
                {
                    try
                    {
                        var callback = new JavascriptCallback();
                        Control.EvaluateJavascript(e.ScriptName + (e.Arguments != null ? ("(" + string.Join(",", e.Arguments) + ");") : ""), callback);
                        while (callback.IsReceived == false)
                        {
                            await Task.Delay(1);
                        }
                        e.ReturnString = callback.ReceivedValue;
                        break;
                    }
                    catch
                    {
                        PDS.Xamarin.Generic.Debug.Log("ZoomWebViewRenderer_Droid OnEvalJavascriptRequested RetryCount:" + retry++.ToString());
                    }
                    await Task.Delay(50);
                    if (retry > 5) break;
                }
                e.ReturnFinished = true;
            });
        }

        void Control_Touch(object sender, Android.Views.View.TouchEventArgs e)
        {
            try
            {
                // Executing this will prevent the Scrolling to be intercepted by parent views
                switch (e.Event.Action)
                {
                    case MotionEventActions.Down:
                        Control.Parent.RequestDisallowInterceptTouchEvent(true);
                        break;
                    case MotionEventActions.Up:
                        Control.Parent.RequestDisallowInterceptTouchEvent(false);
                        break;
                }
                // Calling this will allow the scrolling event to be executed in the WebView
                Control.OnTouchEvent(e.Event);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Assert(false, ex.Message);
            }
        }

        private void Element_Navigated(object sender, WebNavigatedEventArgs e)
        {
            try
            {
                if (Element != null)
                {
                    var element = Element as ZoomWebView;
                    SetZoomLevel(element.Zoom);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Assert(false, ex.Message);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                base.OnElementPropertyChanged(sender, e);
                if (e.PropertyName == "Zoom")
                {
                    if (Element != null)
                    {
                        var element = Element as ZoomWebView;
                        SetZoomLevel(element.Zoom);
                    }
                }
                PDS.Xamarin.Generic.Debug.Log("ZoomWebViewRenderer_Droid OnElementPropertyChanged:" + e.PropertyName);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Assert(false, ex.Message);
            }
        }

        private void SetZoomLevel(double level)
        {
            try
            {
                if (Control != null)
                {
                    //await Task.Delay(1000);
                    string slevel = $"setZoomLevel(\"{level}\");";
                    var view = Control;
                    //view.SetInitialScale(level);
                    //view.ZoomBy((float)(level / 100.0));
                    view.EvaluateJavascript(slevel, new JavascriptCallback());
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Assert(false, ex.Message);
            }
        }
        private class MyWebViewClient : WebViewClient
        {

            private ZoomWebView element;
            public MyWebViewClient(ZoomWebView Element, WebViewRenderer renderer) : base() { element = Element; _renderer = renderer; }
            public override void OnPageFinished(Android.Webkit.WebView view, string url)
            {

                try
                {
                    var source = new UrlWebViewSource { Url = url };

                    var args = new WebNavigatedEventArgs(WebNavigationEvent.NewPage, source, url, _navigationResult);

                    base.OnPageFinished(view, url);
                    var level = element.Zoom;
                    string slevel = $"setZoomLevel(\"{level}\");";
                    //view.SetInitialScale(level);
                    //view.ZoomBy((float)(level / 100.0));
                    view.EvaluateJavascript(slevel, new JavascriptCallback());
                    if (element.DoScrollToEnd)
                    {
                        view.EvaluateJavascript("window.scrollTo(0, document.body.scrollHeight);", new JavascriptCallback());
                    }

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Assert(false, ex.Message);
                }
            }

            WebNavigationResult _navigationResult = WebNavigationResult.Success;
            WebViewRenderer _renderer;


            [Obsolete("OnReceivedError is obsolete as of version 2.3.0. This method was deprecated in API level 23.")]
            public override void OnReceivedError(AWebView view, ClientError errorCode, string description, string failingUrl)
            {
                try
                {
                    _navigationResult = WebNavigationResult.Failure;
                    if (errorCode == ClientError.Timeout)
                        _navigationResult = WebNavigationResult.Timeout;
#pragma warning disable 618
                    base.OnReceivedError(view, errorCode, description, failingUrl);
#pragma warning restore 618
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Assert(false, ex.Message);
                }
            }

            public override void OnReceivedError(AWebView view, IWebResourceRequest request, WebResourceError error)
            {
                try
                {
                    _navigationResult = WebNavigationResult.Failure;
                    if (error.ErrorCode == ClientError.Timeout)
                        _navigationResult = WebNavigationResult.Timeout;
                    base.OnReceivedError(view, request, error);

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Assert(false, ex.Message);
                }
            }

            [Obsolete]
            public override bool ShouldOverrideUrlLoading(AWebView view, string url)
            {
                try
                {
                    if (_renderer.Element == null)
                        return true;

                    var args = new WebNavigatingEventArgs(WebNavigationEvent.NewPage, new UrlWebViewSource { Url = url }, url);

                    element.SendNavigating(args);
                    _navigationResult = WebNavigationResult.Success;

                    return args.Cancel;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Assert(false, ex.Message);
                }
                return false;
            }

            protected override void Dispose(bool disposing)
            {
                try
                {
                    base.Dispose(disposing);
                    if (disposing)
                        _renderer = null;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Assert(false, ex.Message);
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (Element != null)
                {
                    var element = Element as ZoomWebView;
                    element.Navigated -= Element_Navigated;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Assert(false, ex.Message);
            }
        }

        private class JavascriptCallback : Java.Lang.Object, IValueCallback
        {
            public bool IsReceived { get; set; } = false;
            public string ReceivedValue { get; set; }
            public void OnReceiveValue(Java.Lang.Object value)
            {
                try
                {
                    ReceivedValue = removeUTFCharacters(value.ToString())
                                    .Replace("\\\\", "\\")
                                    .Replace("\\\"", "\"")
                                    .Replace("\\'", "'")
                                    .Replace("\\", "");
                    if (string.IsNullOrWhiteSpace(ReceivedValue) == false)
                    {
                        if (ReceivedValue.First() == '"')
                        {
                            ReceivedValue = ReceivedValue.Substring(1);
                        }
                        if (ReceivedValue.Last() == '"')
                        {
                            ReceivedValue = ReceivedValue.Substring(0, ReceivedValue.Length - 1);
                        }
                    }
                    IsReceived = true;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Assert(false, ex.Message);
                }
            }
            public static string removeUTFCharacters(string data)
            {
                Pattern p = Pattern.Compile("\\\\u(\\p{XDigit}{4})");
                Matcher m = p.Matcher(data);
                Java.Lang.StringBuffer buf = new Java.Lang.StringBuffer(data.Length);
                while (m.Find())
                {
                    string ch = Java.Lang.String.ValueOf((char)Java.Lang.Integer.ParseInt(m.Group(1), 16));
                    m.AppendReplacement(buf, Matcher.QuoteReplacement(ch));
                }
                m.AppendTail(buf);
                return buf.ToString();
            }
        }
    }
}