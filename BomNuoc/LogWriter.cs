//using ASK.Xamarin.Data;
using PDS.Xamarin.Data;
//using ASK.Xamarin.Generic;
using PDS.Xamarin.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BomNuoc
{
    public class LogWriter
    {

        private static IDataFileStream LogFileStream = null;
        private static string LogFileName = null;

        public static void Start()
        {
            LogFileStream = DependencyService.Get<IDataFileStream>();
            LogFileName = "AppLog_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".log";
            Debug.LogEvent += Debug_Log;
        }

        private static AsyncLock LogAsyncLock = new AsyncLock();

        private static async void Debug_Log(string message)
        {
            using (await LogAsyncLock.LockAsync())
            {
                try
                {
                    await LogFileStream.AppendData(LogFileName, message + CR.LF);
                }
                catch { }
            }
        }
    }
}
