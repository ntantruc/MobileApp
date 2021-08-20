//using ASK.Xamarin.Generic;
using PDS.Xamarin.Generic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BomNuoc
{
    public static class Resource
    {
        public static class Size
        {
            private const int BaseScreenWidth = 320;   //基準解像度iPhone 5/5s/5c/SE 相当(ポイント基準)
            private const int BaseScreenHeight = 568;

            public static int ScreenWidth = 320;
            public static int ScreenHeight = 568;

            public static double scale = 1.0;

            public static double dpiScale = 1.0;

            private static double viewScale = 1.0;
            public static double ViewScale
            {
                get { return viewScale; }
                set
                {
                    var minSize = 0.8;
                    var maxSize = 1.7;
                    value = Math.Max(value, minSize);
                    value = Math.Min(value, maxSize);
                    viewScale = value;
                    ViewModels.calc.i.Refresh();
                    Globals.config.ViewScale = value;
                    Globals.config.Save();
                }
            }

            public static void Init(int screenWidth, int screenHeight,double dpiscale) 
            {
                dpiScale = dpiscale;
                Init(screenWidth, screenHeight);
            }

            public static void Init(int screenWidth, int screenHeight)
            {
                if (Device.Idiom == TargetIdiom.Phone && screenWidth > screenHeight)
                {
                    ScreenWidth = screenHeight;
                    ScreenHeight = screenWidth;
                }
                else
                {
                    ScreenWidth = screenWidth;
                    ScreenHeight = screenHeight;
                }
                scale = (double)ScreenWidth / (double)BaseScreenWidth;
                Debug.Log($"SizeInit Width:{ScreenWidth} Height:{ScreenHeight} Scale:{scale}");
            }
            public static double calc(double x)
            {
                if (Device.Idiom == TargetIdiom.Phone)
                {
                    //if (scale < 1.0)
                    {
                        x *= scale;
                    }
                }
                else
                {
                    if (scale > 1.5)
                    {
                        if (Device.RuntimePlatform == Device.iOS)
                        {
                            //Debug.Log($"calc x before:{x} x after:{x * 1.5} viewScale:{viewScale} return:{x * 1.5 * viewScale}");
                            if (Device.Idiom == TargetIdiom.Tablet) { x *= 1.5; }
                        }
                        else if (Device.RuntimePlatform == Device.Android)
                        {
                            if (Device.Idiom == TargetIdiom.Tablet) { x *= 1.5; }
                        }
                        else if (Device.RuntimePlatform == Device.Windows) //UWP
                        {
                            if (Device.Idiom == TargetIdiom.Tablet) { }
                            else if (Device.Idiom == TargetIdiom.Desktop) { }
                        }
                    }
                }
                if (Device.RuntimePlatform == Device.iOS && Device.Idiom == TargetIdiom.Tablet) x *= 0.5;
                if (Device.RuntimePlatform == Device.Android && Device.Idiom == TargetIdiom.Tablet) x *= 0.5;
                var ret = x * ViewScale;
                if (Device.RuntimePlatform == Device.Android && ret > 0.0 && ret < 1.0) return 1.0;
                else return ret;
            }


        }

        public static class Colors
        {
            /// <summary>#007ACC</summary>
            public static Color ASKBlue { get; } = Color.FromUint(0xFF007ACC);
            /// <summary>#F0FFFF</summary>
            public static Color Saturday { get; } = Color.FromUint(0xFFF0FFFF);
            /// <summary>#FFF0F5</summary>
            public static Color Sunday { get; } = Color.FromUint(0xFFFFF0F5);
            /// <summary>#ADD8E6</summary>
            public static Color Doctor { get; } = Color.FromHex("#ADD8E6");
            /// <summary>#FFC0CB</summary>
            public static Color Nurse { get; } = Color.FromHex("#FFC0CB");
            /// <summary>#8DE49C</summary>
            public static Color Helper { get; } = Color.FromHex("#8DE49C");
            /// <summary>#007ACC</summary>
            public static Color Pharmacist { get; } = Color.Orange;
            /// <summary>#FFFF66</summary>
            public static Color Patient { get; } = Color.FromHex("#FFFF66");
        }

        public static class Icons
        {

            public static string MedicineIconRegular { get { return SelectImageFileFromOS(nameof(MedicineIconRegular)); } }
            public static string MedicineIconChange { get { return SelectImageFileFromOS(nameof(MedicineIconChange)); } }
            public static string MedicineIconExtra { get { return SelectImageFileFromOS(nameof(MedicineIconExtra)); } }
            public static string MedicineIconRegularExtra { get { return SelectImageFileFromOS(nameof(MedicineIconRegularExtra)); } }
            public static string MedicineIconChangeExtra { get { return SelectImageFileFromOS(nameof(MedicineIconChangeExtra)); } }
            public static string MedicineIconNone { get { return SelectImageFileFromOS(nameof(MedicineIconNone)); } }

            private static string SelectImageFileFromOS(string ImageName)
            {
                if (Device.RuntimePlatform == Device.iOS)
                {
                    if (Device.Idiom == TargetIdiom.Phone) { if (Size.scale < 1.29) return ImageName + "_Small.png"; }
                    else if (Device.Idiom == TargetIdiom.Tablet) { }
                }
                else if (Device.RuntimePlatform == Device.Android)
                {
                    if (Device.Idiom == TargetIdiom.Phone) { }
                    else if (Device.Idiom == TargetIdiom.Tablet) { }
                }
                else if (Device.RuntimePlatform == Device.Windows) //UWP
                {
                    if (Device.Idiom == TargetIdiom.Phone) { }
                    else if (Device.Idiom == TargetIdiom.Tablet) { }
                    else if (Device.Idiom == TargetIdiom.Desktop) { }
                }
                return ImageName + ".png";
            }
        }

    }
    [ContentProperty("Source")]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
                return null;

            // Do your translation lookup here, using whatever method you require
            //var assembly = typeof(HeartLine.Core.App).GetTypeInfo().Assembly; //For UWP リソース問題
            var assembly = typeof(BomNuoc.App).GetTypeInfo().Assembly; //For UWP リソース問題
            var imageSource = ImageSource.FromResource(Source, assembly);

            return imageSource;
        }
    }
}
