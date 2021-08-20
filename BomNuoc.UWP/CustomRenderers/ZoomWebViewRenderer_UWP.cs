using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using System.Reflection;
using System.Collections.Generic;
using Xamarin.Forms.Internals;
using BomNuoc.Controls;
using PDS.Xamarin.Generic;

[assembly: ExportRenderer(typeof(ZoomWebView), typeof(BomNuoc.UWP.CustomRenderers.ZoomWebViewRenderer_UWP))]

namespace BomNuoc.UWP.CustomRenderers
{
    public class ZoomWebViewRenderer_UWP : WebViewRenderer, IWebViewDelegate
    {
        void IWebViewDelegate.LoadHtml(string html, string baseUrl)
        {
            if (Element.Source is HtmlWebViewSource && baseUrl.IsNullOrWhiteSpace())
                Control.NavigateToString(html);
            else
                LoadHtml(html, baseUrl);
        }

        //bool loading = true;
        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || Element == null)
            {
                return;
            }

            if (Control != null)
            {
                Control.NavigationCompleted -= Control_NavigationCompleted;
                Control.NavigationCompleted += Control_NavigationCompleted;
                Control.NavigationStarting -= Control_NavigationStarting;
                Control.NavigationStarting += Control_NavigationStarting;
                Control.DOMContentLoaded -= Control_DOMContentLoaded;
                Control.DOMContentLoaded += Control_DOMContentLoaded;
                var element = Element as ZoomWebView;
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

        private void Control_DOMContentLoaded(Windows.UI.Xaml.Controls.WebView sender, Windows.UI.Xaml.Controls.WebViewDOMContentLoadedEventArgs args)
        {
            Debug.Log("ZoomWebViewRenderer_UWP Control_DOMContentLoaded:" + args.Uri?.ToString());
            //loading = false;
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
                        e.ReturnString = await Control.InvokeScriptAsync("eval", new string[] { e.ScriptName + (e.Arguments != null ? ("(" + e.Arguments.Join(",") + ");") : "") });
                        break;
                    }
                    catch
                    {
                        Debug.Log("ZoomWebViewRenderer_UWP OnEvalJavascriptRequested RetryCount:" + retry++.ToString());
                    }
                    await Task.Delay(50);
                    if (retry > 5) break;
                }
                e.ReturnFinished = true;
            });
        }

        private void Control_NavigationStarting(Windows.UI.Xaml.Controls.WebView sender, Windows.UI.Xaml.Controls.WebViewNavigationStartingEventArgs args)
        {
            if (args.Cancel == false)
            {
                NavigationCompleted = false;
                var element = Element as ZoomWebView;
                element?.StartNavigation();
            }
        }

        private bool NavigationCompleted = false;

        private async void Control_NavigationCompleted(Windows.UI.Xaml.Controls.WebView sender, Windows.UI.Xaml.Controls.WebViewNavigationCompletedEventArgs args)
        {
            Debug.Log("ZoomWebViewRenderer_UWP Control_NavigationCompleted:" + args.Uri?.ToString());
            if (Control != null && NavigationCompleted == false)
            {
                NavigationCompleted = true;
                var element = Element as ZoomWebView;
                SetZoomLevel((int)(element.Zoom * 100));
                //var parent = (ZoomWebViewRenderer_UWP)Control.Parent;
                //var parent2 = parent.Parent;
                //var grid = new Windows.UI.Xaml.Controls.Grid { Background = new SolidColorBrush(Windows.UI.Colors.White) };
                //parent.Children.Add(grid);
                await Task.Delay(500);
                //Control.UpdateLayout();
                //parent.UpdateLayout();
                //parent.Children.Remove(grid);
                //parent.UpdateLayout();
                element.RefreshView();
            }

        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Zoom")
            {
                if (Control != null)
                {
                    var element = Element as ZoomWebView;
                    SetZoomLevel((int)(element.Zoom * 100));
                }
            }
            else if (e.PropertyName == ZoomWebView.SourceProperty.PropertyName)
            {
                //loading = true;
            }
            Debug.Log("ZoomWebViewRenderer_UWP OnElementPropertyChanged:" + e.PropertyName);
            base.OnElementPropertyChanged(sender, e);
        }
        private async void SetZoomLevel(int level)
        {
            if (Control != null && NavigationCompleted)
            {
                string slevel = string.Format("{0}%", level);
                try
                {
                    await Control.InvokeScriptAsync("setZoomLevel", new string[] { slevel });
                }
                catch { }
            }
        }

        protected override void Dispose(bool disposing)
        {
            NavigationCompleted = false;
            Control.NavigationCompleted -= Control_NavigationCompleted;
            Control.NavigationStarting -= Control_NavigationStarting;
            Control.DOMContentLoaded -= Control_DOMContentLoaded;
        }
    }

}
