using MessagePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomNuoc.SQL.SQLTables
{
    //public class TableBase : ViewModels.ViewModelBase
    [MessagePackObject(keyAsPropertyName: true)]
    public class TableBase 
    {
        public int ID { get; set; }
    }
    [MessagePackObject(keyAsPropertyName: true)]
    public class TestTable : TableBase
    {
        public DateTime CreateDate { get; set; }
        public string AppID { get; set; }
        public string TestField { get; set; }
    }

    [MessagePackObject(keyAsPropertyName: true)]
    public class UserListFormatter
    {
        public List<User> UserList { get; set; }
    }

    [MessagePackObject(keyAsPropertyName: true)]
    public class Province : TableBase
    {
        public DateTime? CreateDate { get; set; }        //Ngày tạo
        public string ProvinceName { get; set; }//added
        public string Reserved1 { get; set; }
        public string Reserved2 { get; set; }
    }
    [MessagePackObject(keyAsPropertyName: true)]
    public class Cooperative : TableBase
    {
        public DateTime? CreateDate { get; set; }        //Ngày tạo
        public string CooperateName { get; set; }//added
        public string ProvinceName { get; set; }//added
        public int CabinetsID { get; set; }//added
        public string Reserved1 { get; set; }
        public string Reserved2 { get; set; }
    }

    [MessagePackObject(keyAsPropertyName: true)]
    public class User : TableBase, IEquatable<User>
    {
        public DateTime? CreateDate { get; set; }        //Ngày tạo
        public string AppID { get; set; }               //Tên ứng dụng: BomNuoc or some key work
        public string UserName { get; set; }            //Tên người dùng.
        public string Password { get; set; }            //Mật khẩu
        public string ViewName { get; set; }            //Tên đầy đủ
        public string UserType { get; set; }            //Admin, Monitor, user        
        public int CabinetsID { get; set; }           //Tủ điện
        public string MailAddress { get; set; }         //Email
        public bool IsEnable { get; set; }              //
        public string token { get; set; }               //
        public DateTime? tokenDate { get; set; }        //
        public string CreateUser { get; set; }          //Người tạo 
        public DateTime? LastLoginDate { get; set; }    //
        public DateTime? LastLogoutDate { get; set; }   //
        public string LastLoginIP { get; set; }         //
        public string ProvinceName { get; set; }        // Tỉnh thành
        public string CooperateName { get; set; }        // Hợp tác xã
        public DateTime? ExpiredDate { get; set; }
        public bool IsExpired { get; set; }  
        public string Reserved1 { get; set; } 
        public string Reserved2 { get; set; }
        public string Reserved3 { get; set; }
        public string Reserved4 { get; set; }


        public override bool Equals(object obj) { return base.Equals(obj); }
        public override int GetHashCode()
        {
            return (CreateDate == null ? 0 : CreateDate.GetHashCode()) ^
                   (AppID == null ? 0 : AppID.GetHashCode()) ^
                   (UserName == null ? 0 : UserName.GetHashCode()) ^
                   (Password == null ? 0 : Password.GetHashCode()) ^
                   (ViewName == null ? 0 : ViewName.GetHashCode()) ^
                   (UserType == null ? 0 : UserType.GetHashCode()) ^
                   (MailAddress == null ? 0 : MailAddress.GetHashCode()) ^
                   (IsEnable == false ? 0 : 1) ^
                   (token == null ? 0 : token.GetHashCode()) ^
                   (tokenDate == null ? 0 : tokenDate.GetHashCode()) ^
                   (CreateUser == null ? 0 : CreateUser.GetHashCode()) ^
                   (LastLoginDate == null ? 0 : LastLoginDate.GetHashCode()) ^
                   (LastLogoutDate == null ? 0 : LastLogoutDate.GetHashCode()) ^
                   (LastLoginIP == null ? 0 : LastLoginIP.GetHashCode());
        }

        public bool Equals(User other)
        {
            return this == other;
        }

        public static bool operator ==(User a, User b)
        {
            if ((object)a == null && (object)b == null)
            {
                return true;
            }
            else if ((object)a == null && (object)b != null)
            {
                return false;
            }
            else if ((object)a != null && (object)b == null)
            {
                return false;
            }
            else
            {                
                return a.CreateDate == b.CreateDate && a.AppID == b.AppID && a.UserName == b.UserName && a.Password == b.Password && a.ViewName == b.ViewName && a.UserType == b.UserType && a.MailAddress == b.MailAddress && a.IsEnable == b.IsEnable && a.token == b.token && a.tokenDate == b.tokenDate && a.CreateUser == b.CreateUser && a.LastLoginDate == b.LastLoginDate && a.LastLogoutDate == b.LastLogoutDate && a.LastLoginIP == b.LastLoginIP;
            }
        }
        public static bool operator !=(User a, User b) { return !(a == b); }
    }
    [MessagePackObject(keyAsPropertyName: true)]
    public class UserTypes
    {
        /// <summary>
        /// 管理者
        /// </summary>
        public static string Admin { get { return "Admin"; } }
        /// <summary>
        /// 医師
        /// </summary>
        public static string Monitor { get { return "Monitor"; } }
        /// 薬剤師
        /// </summary>
        public static string User { get { return "User"; } }
    }
    [MessagePackObject(keyAsPropertyName: true)]
    public class Cabinets : TableBase
    {
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; } //Added
        public string AppID { get; set; }
        public string CabinetsProductKey { get; set; }
        public string GatewaySerialNumber { get; set; }
        public DateTime? GatewayLastLoginDate { get; set; }    //
        public DateTime? GatewayLastLogoutDate { get; set; }   //
        public string GatewayLastLoginIP { get; set; }         //
        public string Reserved1 { get; set; }
        public string Reserved2 { get; set; }
        public string Reserved3 { get; set; }
        public string Reserved4 { get; set; }
        public string Reserved5 { get; set; }
        public string Reserved6 { get; set; }
    }
    [MessagePackObject(keyAsPropertyName: true)]
    public class CabinetsRecords : TableBase
    {        
        public DateTime? CreateDate { get; set; }
        public int CabinetsID { get; set; }
        public int FieldID { get; set; }
        public DateTime? TimeOn { get; set; }
        public DateTime? TimeOff { get; set; }
        public int TotalWateringTime { get; set; }
        public int CompletedWateringLevel { get; set; }
        public DateTime? InsertDate { get; set; }
        public string Reserved1 { get; set; }
        public string Reserved2 { get; set; }
    }
    [MessagePackObject(keyAsPropertyName: true)]
    public class Notifications : TableBase
    {
        public int CabinetsID { get; set; }
        public int FieldID { get; set; }
        public int UserID { get; set; }
        public DateTime? NotificationTime { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string Reserved1 { get; set; }
        public string Reserved2 { get; set; }
        public string Reserved3 { get; set; }
        public string Reserved4 { get; set; }
        public string Reserved5 { get; set; }
        public string Reserved6 { get; set; }

    }
    [MessagePackObject(keyAsPropertyName: true)]
    public class Field : TableBase
    {
        public int FieldOrder { get; set; }
        public string FieldNameNumber { get; set; }
        public string FieldDescription { get; set; }
        public int CabinetsID { get; set; }
        public bool PowerOnOff { get; set; }
        public DateTime? TimeOn { get; set; }
        public DateTime? TimeOff { get; set; }
        public int TotalWateringTime { get; set; } //Minutes
        public int NotificationsID { get; set; } //added
        public int LimitedWatteringTime { get; set; }
        public bool IsAlive { get; set; }
        public DateTime? UpdateDate { get; set; }
        public double? RiverLevelMin { get; set; }  //River level
        public double? RiverLevelValue { get; set; }
        public int NumberACLostPhases { get; set; }
        public string Reserved1 { get; set; }
        public string Reserved2 { get; set; }
        public string Reserved3 { get; set; }
        public string Reserved4 { get; set; }
        public string Reserved5 { get; set; }
        public string Reserved6 { get; set; }
    }
    [MessagePackObject(keyAsPropertyName: true)]
    public class Water : TableBase
    {
        public int FieldID { get; set; }
        public int WaterMinLevel { get; set; }
        public int WaterMaxLevel { get; set; }
        public int WaterLevelValue { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string Reserved1 { get; set; }
        public string Reserved2 { get; set; }
        public string Reserved3 { get; set; }
        public string Reserved4 { get; set; }
        public string Reserved5 { get; set; }
        public string Reserved6 { get; set; }
    }
    [MessagePackObject(keyAsPropertyName: true)]
    public class Environment : TableBase
    {
        public int FieldID { get; set; }
        public int TempMinLevel { get; set; }
        public int TempMaxLevel { get; set; }
        public int TempLevelValue { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string Reserved1 { get; set; }
        public string Reserved2 { get; set; }
        public string Reserved3 { get; set; }
        public string Reserved4 { get; set; }
        public string Reserved5 { get; set; }
        public string Reserved6 { get; set; }
    }
    [MessagePackObject(keyAsPropertyName: true)]
    public class Ground : TableBase
    {
        public int FieldID { get; set; }
        public int GroundMinLevel { get; set; }
        public int GroundMaxLevel { get; set; }
        public int GroundLevelValue { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string Reserved1 { get; set; }
        public string Reserved2 { get; set; }
        public string Reserved3 { get; set; }
        public string Reserved4 { get; set; }
        public string Reserved5 { get; set; }
        public string Reserved6 { get; set; }
    }
}









