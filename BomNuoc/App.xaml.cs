using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BomNuoc
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = new System.Globalization.CultureInfo("ja-JP");
            System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = new System.Globalization.CultureInfo("ja-JP");

            Globals.CurrentToken = SSLClient.defaultToken;

            LogWriter.Start();
            MessagePack.MessagePackSerializer.SetDefaultResolver(Resolvers.GeneratedResolver.Instance);
            //SetMessagePackResolver to generated version ( for iOS AOT)
            MessagePack.Resolvers.CompositeResolver.RegisterAndSetAsDefault(
                //MessagePack.Resolvers.NativeDateTimeResolver.Instance,
                // use generated resolver first, and combine many other generated/custom resolvers
                Resolvers.GeneratedResolver.Instance,

                // finally, use builtin/primitive resolver(don't use StandardResolver, it includes dynamic generation)
                MessagePack.Resolvers.BuiltinResolver.Instance,
                MessagePack.Resolvers.AttributeFormatterResolver.Instance,
                MessagePack.Resolvers.PrimitiveObjectResolver.Instance
            );

            //Test for List<UserClass> Resolver
            var datalist = new List<SQL.SQLTables.User> { new SQL.SQLTables.User() { CreateDate = DateTime.Now } };
           // var serialized = MessagePack.LZ4MessagePackSerializer.Serialize<List<SQL.SQLTables.User>>(datalist);
           // var receiveList = MessagePack.LZ4MessagePackSerializer.Deserialize<List<SQL.SQLTables.User>>(serialized);

            MainPage = new Contents.LoginPage();

            //MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
