using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BomNuoc
{
    public class Device
    {
        //デバッグ用
        private static bool IsDebug = false;                
        private static Xamarin.Forms.TargetIdiom DebugPlatform = Xamarin.Forms.TargetIdiom.Phone;
        private static string DebugRuntimePlatform = Windows;


        public static T OnPlatform<T>(T iOS, T Android, T Windows, T WinPhone)
        {
            switch (RuntimePlatform)
            {
                case Xamarin.Forms.Device.iOS:
                    return iOS;
                case Xamarin.Forms.Device.Android:
                    return Android;
                //case Xamarin.Forms.Device.d:
                  //  return WinPhone;
                case Xamarin.Forms.Device.UWP:
                    return Windows;
                default:
                    return Windows;
            }
        }

        public static T OnPlatform<T>(T iOS, T Android, T Windows)
        {
            return OnPlatform<T>(iOS, Android, Windows, Windows);
        }

        public static void BeginInvokeOnMainThread(Action action)
        {
            Xamarin.Forms.Device.BeginInvokeOnMainThread(action);
        }

        public static Xamarin.Forms.TargetIdiom Idiom { get { return IsDebug ? DebugPlatform : Xamarin.Forms.Device.Idiom; } }

        public static string RuntimePlatform { get { return IsDebug ? DebugRuntimePlatform : Xamarin.Forms.Device.RuntimePlatform; } }

        public static string iOS { get { return Xamarin.Forms.Device.iOS; } }
        public static string Android { get { return Xamarin.Forms.Device.Android; } }
        //public static string WinPhone { get { return Xamarin.Forms.Device.WinPhone; } }
        public static string Windows { get { return Xamarin.Forms.Device.UWP; } }
    }
}
