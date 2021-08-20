using PDS.Xamarin.Generic;
using BomNuoc.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ZoomWebView), typeof(BomNuoc.iOS.CustomRenderers.ZoomWebViewRenderer_iOS))]

namespace BomNuoc.iOS.CustomRenderers
{
    public class ZoomWebViewRenderer_iOS : WebViewRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            //ZoomWebView.androidurl = Foundation.NSBundle.MainBundle.BundlePath;
            base.OnElementChanged(e);

            if (NativeView != null)
            {
                var view = (UIWebView)NativeView;
                //view.UpdateConstraints();
                view.Opaque = false;
                view.BackgroundColor = UIColor.Clear;
            }

            if (e.OldElement != null) e.OldElement.PropertyChanged -= OnElementPropertyChanged;
            if (e.NewElement != null) e.NewElement.PropertyChanged += OnElementPropertyChanged;
            if (e.OldElement != null || Element == null)
            {
                return;
            }

            if (Element != null)
            {
                var view = (UIWebView)NativeView;
                view.ScalesPageToFit = false;

                //view.LoadFinished -= View_LoadFinished;
                //view.LoadFinished += View_LoadFinished;
                //view.LoadStarted -= View_LoadStarted;
                //view.LoadStarted += View_LoadStarted;

                var element = Element as ZoomWebView;
                element.Navigated -= Element_Navigated;
                element.Navigated += Element_Navigated;
                SetZoomLevel((int)(element.Zoom * 100));
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
                        var view = (UIWebView)NativeView;
                        e.ReturnString = view.EvaluateJavascript(e.ScriptName + (e.Arguments != null ? ("(" + e.Arguments.Join(",") + ");") : ""));
                        break;
                    }
                    catch
                    {
                        Debug.Log("ZoomWebViewRenderer_iOS OnEvalJavascriptRequested RetryCount:" + retry++.ToString());
                    }
                    await Task.Delay(50);
                    if (retry > 5) break;
                }
                e.ReturnFinished = true;
            });
        }
        private void Element_Navigated(object sender, WebNavigatedEventArgs e)
        {
            if (Element != null)
            {
                var element = Element as ZoomWebView;
                SetZoomLevel((int)(element.Zoom * 100));
            }
        }

        private async void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Zoom")
            {
                if (NativeView != null)
                {
                    var element = Element as ZoomWebView;
                    SetZoomLevel((int)(element.Zoom * 100));
                }
            }
            if (/*e.PropertyName == WebView.WidthProperty.PropertyName || */e.PropertyName == WebView.HeightProperty.PropertyName)
            {
                if (NativeView != null)
                {
                    var element = Element as ZoomWebView;
                    var view = (UIWebView)NativeView;
                    //view.UpdateConstraints();
                    element.RefreshView();
                    Debug.Log($"ZoomWebView SizeChanged: {element.Width},{element.Height} {view.Bounds.Width},{view.Bounds.Height}");
                }
            }
            Debug.Log("ZoomWebViewRenderer_iOS OnElementPropertyChanged:" + e.PropertyName);
        }

        private void SetZoomLevel(int level)
        {
            if (NativeView != null)
            {
                string slevel = $"setZoomLevel(\"{level}%\");";
                var view = (UIWebView)NativeView;
                view.EvaluateJavascript(slevel);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (Element != null)
            {
                var element = Element as ZoomWebView;
                element.Navigated -= Element_Navigated;
            }
        }
    }
}
