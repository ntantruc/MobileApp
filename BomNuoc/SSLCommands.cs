using MessagePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomNuoc.SSL
{
    [MessagePackObject(keyAsPropertyName: true)]
    public class SSLCommands
    {
        private static List<Type> commands = new List<Type> {
            typeof(TestMessage),
            typeof(Login),
            typeof(SQLExecuteReader),
            typeof(SQLExecuteReaderBinary),
            typeof(NeedRelogin),
            typeof(UpdateToken),
            typeof(ErrorMessage),
            typeof(UpdateData),
            typeof(Acknowledgement),
            typeof(RequestCabinetsOnOffData),
            typeof(SendCabinetsOnOffData),
        };
        public static Type GetCommandType(string commandStr)
        {
            foreach (var command in commands)
            {
                if (command.Name == commandStr) return command;
            }
            return null;
        }
        [MessagePackObject(keyAsPropertyName: true)]
        public class SSLCommandBase
        {
            public string token { get; set; }
            public string AppID { get { return Globals.AppID; } set { } }
            public string RequestID { get; set; }
        }
        [MessagePackObject(keyAsPropertyName: true)]
        public class Acknowledgement : SSLCommandBase { }
        [MessagePackObject(keyAsPropertyName: true)]
        public class TestMessage : SSLCommandBase
        {
            public string message { get; set; }
        }
        [MessagePackObject(keyAsPropertyName: true)]
        public class Login : SSLCommandBase
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }
        [MessagePackObject(keyAsPropertyName: true)]
        public class UpdateToken : SSLCommandBase { }
        [MessagePackObject(keyAsPropertyName: true)]
        public class NeedRelogin : SSLCommandBase { }
        [MessagePackObject(keyAsPropertyName: true)]
        public class SQLExecuteReader : SSLCommandBase
        {
            public enum SQLCommands
            {
                getAllData = 0,
                InsertData = 1,
                UpdateData = 2,
                GetSelectColumnData = 3,
                DeleteData = 4,
            }

            public string TableName { get; set; }
            public SQLCommands Command { get; set; }
            public string DataJson { get; set; }
            public bool SuccessExecute { get; set; }
            public string Where { get; set; }
            public long LastInsertId { get; set; }
        }
        [MessagePackObject(keyAsPropertyName: true)]
        public class ErrorMessage : SSLCommandBase
        {
            public string message { get; set; }
        }



        [MessagePackObject(keyAsPropertyName: true)]
        public class SQLExecuteReaderBinary : SSLCommandBase
        {
            public enum SQLCommands
            {
                getAllDataBinary = 0,
                InsertDataBinary = 1,
                UpdateDataBinary = 2,
                GetSelectColumnDataBinary = 3,
                InsertListDataBinary = 4,
            }

            public string TableName { get; set; }
            public SQLCommands Command { get; set; }
            public string DataJson { get; set; }
            public byte[] DataBinary { get; set; }
            public bool SuccessExecute { get; set; }
            public string Where { get; set; }
            public long LastInsertId { get; set; }
        }
        [MessagePackObject(keyAsPropertyName: true)]
        public class UpdateData : SSLCommandBase
        {
            /// <summary>
            /// SQLTables.User
            /// </summary>
            public string CallFromJson { get; set; }
            /// <summary>
            /// List&lt;SQLTables.User&gt;
            /// </summary>
            public string CallToJson { get; set; }
            /// <summary>
            /// SQLTables.Cabinets
            /// </summary>
            public string CabinetsJson { get; set; }
            /// <summary>
            /// enum UpdateDataTypes
            /// </summary>
            public int DataType { get; set; }
            public string DataJson { get; set; }
        }
        public enum UpdateDataTypes
        {
            Cooperative = 0,
            User = 1,
            Cabinets = 2,
            CabinetsRecords=3,
            Fields = 4,
            Environments = 5,
            Water = 6,
            Ground = 7,
            Notifications =8,
            UpdateReserved2 = 9,
        }
        [MessagePackObject(keyAsPropertyName: true)]
        public class RequestCabinetsOnOffData : SSLCommandBase
        {
            public string CabinetsJson { get; set; }
            public bool IsStart { get; set; }
            public bool IsError { get; set; }
            public string reserved { get; set; }
        }
        [MessagePackObject(keyAsPropertyName: true)]
        public class SendCabinetsOnOffData : SSLCommandBase
        {
            public string FromCabinetsJson { get; set; }
            public DateTime SendDate { get; set; }
            public string SendDataJson { get; set; }
            public string reserved { get; set; }
        }
    }
}
