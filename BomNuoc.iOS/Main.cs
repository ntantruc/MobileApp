using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace BomNuoc.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            //SetMessagePackResolver to generated version ( for iOS AOT)
            MessagePack.Resolvers.CompositeResolver.RegisterAndSetAsDefault(
                //MessagePack.Resolvers.NativeDateTimeResolver.Instance,
                // use generated resolver first, and combine many other generated/custom resolvers
                BomNuoc.Resolvers.GeneratedResolver.Instance,

                // finally, use builtin/primitive resolver(don't use StandardResolver, it includes dynamic generation)
                MessagePack.Resolvers.BuiltinResolver.Instance,
                MessagePack.Resolvers.AttributeFormatterResolver.Instance,
                MessagePack.Resolvers.PrimitiveObjectResolver.Instance
            );
            //Xamarin.Forms.DependencyService.Register<ASK.Xamarin.SSL.ISSLClient, ASK.Xamarin.SSL.iOS.SSLClient>();
            //Xamarin.Forms.DependencyService.Register<ASK.Xamarin.BluetoothLE.IAdapter, ASK.Xamarin.BluetoothLE.iOS.Adapter>();
            //Xamarin.Forms.DependencyService.Register<ASK.Xamarin.Data.IDataFileStream, ASK.Xamarin.Data.iOS.DataFileStream>();
            //Xamarin.Forms.DependencyService.Register<ASK.Xamarin.SkyWay.ISkyWayWrapper, ASK.Xamarin.SkyWay.iOS.SkyWayWrapper>();
            //Xamarin.Forms.DependencyService.Register<ASK.Xamarin.Image.IImageResizer, ASK.Xamarin.Image.iOS.ImageResizer>();
            //Xamarin.Forms.DependencyService.Register<ASK.Xamarin.Audio.IAudioPlayer, ASK.Xamarin.Audio.iOS.AudioPlayer>();
            //Xamarin.Forms.DependencyService.Register<ASK.Xamarin.SQL.IFileHelper, ASK.Xamarin.SQL.iOS.FileHelper>();
            //Xamarin.Forms.DependencyService.Register<ASK.Xamarin.Print.IPrintService, ASK.Xamarin.Print.iOS.PrintService>();
            //Xamarin.Forms.DependencyService.Register<ASK.Xamarin.Assembly.IAssemblyService, ASK.Xamarin.Assembly.iOS.AssemblyService>();

            Xamarin.Forms.DependencyService.Register<PDS.Xamarin.SSL.ISSLClient, PDS.Xamarin.SSL.iOS.SSLClient>();
            Xamarin.Forms.DependencyService.Register<PDS.Xamarin.Data.IDataFileStream, PDS.Xamarin.Data.iOS.DataFileStream>();
            Xamarin.Forms.DependencyService.Register<PDS.Xamarin.SQL.IFileHelper, PDS.Xamarin.SQL.iOS.FileHelper>();
            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}
