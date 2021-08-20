using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace BomNuoc.Contents
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PumpControlList : ContentPage
	{

        private ObservableCollection<ListData> AllFields = null;
        public static List<SQL.SQLTables.CabinetsRecords> CabinetsRecordList = new List<SQL.SQLTables.CabinetsRecords>();
        public class ListData : ViewModels.ViewModelBase
        {
            public string LastWateringDaysAgo { get => Getter<string>(); set => Setter(value); }  //FieldID=>CabinetRecord=>Get the latest InsertDate=>Days ago
            public string LastTotalWateringHours { get => Getter<string>(); set => Setter(value); }  //FieldID=>CabinetRecord=>TotalWateringTime
            public string LastWateringLevel { get => Getter<string>(); set => Setter(value); } ////FieldID=>=>CabinetRecord=>Get the latest CompletedWateringlevel
            public string CurrentWateringLevel { get => Getter<string>(); set => Setter(value); } // FieldID=>water => current level
            public string CurrentWateringSettingLevel { get => Getter<string>(); set => Setter(value); } //FieldID=>water=> Maximum level
            public SQL.SQLTables.Field FieldInfo { get { return Getter<SQL.SQLTables.Field>(); } set { Setter(value); } }
            public SQL.SQLTables.Water WaterInfo { get { return Getter<SQL.SQLTables.Water>(); } set { Setter(value); } }
            //public string WateringButtonText { get => Getter<string>(); set => Setter(value); }
            public bool WateringButtonEnable { get => Getter<bool>(); set => Setter(value); }
            public Color WateringButtonColor { get => Getter<Color>(); set => Setter(value); }
            public bool StopButtonEnable { get => Getter<bool>(); set => Setter(value); }
            public Color StopButtonColor { get => Getter<Color>(); set => Setter(value); }
            public bool SettingButtonEnable { get => Getter<bool>(); set => Setter(value); }
            public Color SettingButtonColor { get => Getter<Color>(); set => Setter(value); }
            public float ProgressValue { get => Getter<float>(); set => Setter(value); }
            public Animation animationHandler { get { return Getter<Animation>(); } set { Setter(value); } }
            public string ACLostPhase { get => Getter<string>(); set => Setter(value); }
            public string CurrentWateringDurationValue { get => Getter<string>(); set => Setter(value); }
            
            public string CurrentRiverLevelValue { get => Getter<string>(); set => Setter(value); }
            

        }
        
        ObservableCollection<ListData> Items = new ObservableCollection<ListData>();
        public PumpControlList ()
		{
			InitializeComponent ();
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = new System.Globalization.CultureInfo("ja-JP");
            System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = new System.Globalization.CultureInfo("ja-JP");
            CooperativeName.Text = Globals.CooperativeData.CooperateName;        
            
            this.FieldListView.ItemsSource = Items;
            //System.Diagnostics.Debug.WriteLine("===========================================================================================PumpControlList");
        }
        public async void Refresh()
        {
           // System.Diagnostics.Debug.WriteLine("=================================================================================PumpControlList==========Refresh");
           //UPDATE CURRENT VIEW
            if (Globals.CurrentFieldsList.Count != Items.Count)
            {  // At the first time
                Items.Clear();
                ListData datalist = null;
                foreach (var fielditem in Globals.CurrentFieldsList)
                {
                    datalist = new ListData();
                    datalist.FieldInfo = fielditem;
                    datalist.WateringButtonEnable = true;
                    datalist.WateringButtonColor = Color.Green;
                    datalist.StopButtonEnable = false;
                    datalist.StopButtonColor = Color.Gray;
                    
                    datalist.SettingButtonEnable = true;
                    datalist.SettingButtonColor = Color.White;
                    await GetAllCabinetsRecords(Globals.CurrentCabinets.ID, fielditem.ID);
                    datalist.WaterInfo = await GetWaterData(fielditem.ID);
                    SQL.SQLTables.CabinetsRecords lastRecord = GetTheLastCabinetsRecords(fielditem.ID);
                    datalist.LastWateringDaysAgo = GetTheLastWatteringDay(lastRecord);
                    datalist.LastTotalWateringHours = GetLastWatteringHours(lastRecord);
                    datalist.LastWateringLevel  = GetLastWatteringLevel(lastRecord);
                    datalist.CurrentWateringLevel = GetCurrentWatteringlevel(datalist.WaterInfo);
                    datalist.CurrentWateringSettingLevel  = GetWatteringSettingLevel(datalist.WaterInfo);
                    datalist.ACLostPhase = GetACLostPhase(fielditem);
                    datalist.CurrentWateringDurationValue = GetCurrentWateringDurationValue(fielditem);
                    datalist.CurrentRiverLevelValue = GetRiverLevel(fielditem);
                    Items.Add(datalist);                    
                }
                this.FieldListView.ItemsSource = Items;
                System.Diagnostics.Debug.WriteLine("======size:" + Items.Count);
                Globals.updateDataScheduler.UpdateFlagEnable();
            } else
            { // Update new value from server.
              //UPDATE CABINET WORKING
              // Read cabinet
                Globals.CurrentFieldsList = await Globals.sslClient.GetTableAllDataAsync<SQL.SQLTables.Field>("`CabinetsID`='" + Globals.CurrentCabinets.ID + "' AND `IsAlive`=1", true);
                //Globals.CurrentFieldsList = await Globals.sslClient.GetTableAllDataAsync<SQL.SQLTables.Field>("`CabinetsID`='" + Globals.CurrentCabinets.ID + "' AND `IsAlive`=1");
                //Get all new value: field, water, cabinetsRecord
                //Update GUI
                await GetAllCabinetsRecords(Globals.CurrentCabinets.ID, 0);
                bool foundflag = false;
                foreach (var item in Items)
                {   // cabinets Record
                    //await GetAllCabinetsRecords(item.FieldInfo.CabinetsID, item.FieldInfo.ID);
                    //field
                    foundflag = false;
                    //if (fieldtmp.UpdateDate.Equals(item.FieldInfo.UpdateDate) == false)
                    System.Diagnostics.Debug.WriteLine("======size:" + Items.Count);
                    foreach (var eachfield in Globals.CurrentFieldsList)
                    {
                        //if ((eachfield.ID == item.FieldInfo.ID) && (eachfield.UpdateDate.Equals(item.FieldInfo.UpdateDate) == false))
                        if (eachfield.ID == item.FieldInfo.ID)
                        {
                            System.Diagnostics.Debug.WriteLine("======Correct field:" + item.FieldInfo.FieldOrder);
                            foundflag = true;
                            item.FieldInfo = eachfield;
                            break;
                        }
                            
                    }
                    if (foundflag == false)
                    {
                        item.WaterInfo = await GetWaterData(item.FieldInfo.ID);
                        SQL.SQLTables.CabinetsRecords lastRecord = GetTheLastCabinetsRecords(item.FieldInfo.ID);
                        item.LastWateringDaysAgo = GetTheLastWatteringDay(lastRecord);
                        item.CurrentWateringLevel = GetCurrentWatteringlevel(item.WaterInfo);
                        item.CurrentWateringSettingLevel = GetWatteringSettingLevel(item.WaterInfo);
                        item.ACLostPhase = GetACLostPhase(item.FieldInfo);
                        item.CurrentWateringDurationValue = GetCurrentWateringDurationValue(item.FieldInfo);                        
                        item.CurrentRiverLevelValue = GetRiverLevel(item.FieldInfo);
                    } else
                    {
                        //water
                        item.WaterInfo = await GetWaterData(item.FieldInfo.ID);
                        SQL.SQLTables.CabinetsRecords lastRecord = GetTheLastCabinetsRecords(item.FieldInfo.ID);
                        item.LastWateringDaysAgo = GetTheLastWatteringDay(lastRecord);
                        item.LastTotalWateringHours = GetLastWatteringHours(lastRecord);
                        item.LastWateringLevel = GetLastWatteringLevel(lastRecord);
                        item.CurrentWateringLevel = GetCurrentWatteringlevel(item.WaterInfo);
                        item.CurrentWateringSettingLevel = GetWatteringSettingLevel(item.WaterInfo);
                        item.ACLostPhase = GetACLostPhase(item.FieldInfo);
                        item.CurrentWateringDurationValue = GetCurrentWateringDurationValue(item.FieldInfo);
                        item.CurrentRiverLevelValue = GetRiverLevel(item.FieldInfo);
                    }
                }              
            }
            // Power on/off cabinets
            PowerOnOffCabinets();
        }
        private async Task GetAllCabinetsRecords(int CabinetsID, int fieldID)
        {
            CabinetsRecordList = await Globals.sslClient.GetTableAllDataAsync<SQL.SQLTables.CabinetsRecords>("`CabinetsID`='" + CabinetsID + "'", true);
            // CabinetsRecordList = await Globals.sslClient.GetTableAllDataAsync<SQL.SQLTables.CabinetsRecords>("`CabinetsID`='" + CabinetsID + "' AND `FieldID`='" + fieldID + "'", true);
            //CabinetsRecordList = await Globals.sslClient.GetTableAllDataAsync<SQL.SQLTables.CabinetsRecords>("`CabinetsID`='" + CabinetsID + "' AND `FieldID`='" + fieldID + "'");
        }
        private SQL.SQLTables.CabinetsRecords GetTheLastCabinetsRecords(int FieldID)
        {
            SQL.SQLTables.CabinetsRecords ret = null;
            DateTime LatestTime = new DateTime(2000, 1, 1, 6, 20, 40);
            //System.Diagnostics.Debug.WriteLine("================================Time cann't get count: " + CabinetsRecordList.Count);
            foreach (var item in CabinetsRecordList)
            {
              //  System.Diagnostics.Debug.WriteLine("================================Time cann't get index " );
                if (item.FieldID == FieldID)
                {
                //    System.Diagnostics.Debug.WriteLine("================================Time cann't get CORRECT ID ");
                    if (DateTime.Compare(LatestTime, (DateTime)item.TimeOff) <= 0)
                    {
                  //      System.Diagnostics.Debug.WriteLine("================================Time cann't get Okie ");
                        LatestTime = (DateTime)item.TimeOff;
                        ret = item;
                        //break;
                    }
                    
                }
            }
            if (ret == null)
                System.Diagnostics.Debug.WriteLine("================================Time cann't get");
            return ret;
        }
        private async Task<SQL.SQLTables.Water> GetWaterData(int FieldID)
        {
            SQL.SQLTables.Water ret = (await Globals.sslClient.GetTableAllDataAsync<SQL.SQLTables.Water>("`FieldID`='" + FieldID + "'", true)).First();
            return ret;
        }

        //FieldID=>CabinetRecord=>Get the latest InsertDate=>Days ago
        private string GetTheLastWatteringDay(SQL.SQLTables.CabinetsRecords cabinetsRecord)
        {
            string ret = "";

            if (cabinetsRecord == null)
            {
                ret = "Chưa tưới bao giờ.";
                return ret;
            }
            try
            {
                TimeSpan timediff = DateTime.Now.Subtract((DateTime)cabinetsRecord.TimeOff);
                ret = "Tưới cách đây: ";
                if ((int)timediff.TotalDays > 0)
                    ret = ret + (int)timediff.TotalDays + " ngày";
                if ((int)(timediff.TotalHours % 24) > 0)
                    ret = ret + (int)(timediff.TotalHours % 24) + " giờ ";
                ret = ret + (int)(timediff.TotalMinutes % 60) + " phút";
            }
            catch { }
            return ret;
        }
        //FieldID=>CabinetRecord=>TotalWateringTime
        private string GetLastWatteringHours(SQL.SQLTables.CabinetsRecords cabinetsRecord)
        {
            string ret = "";
            if (cabinetsRecord == null)
            {
                return ret;
            }
            if (cabinetsRecord.TotalWateringTime < 60)
            {
                ret = "Thời gian bơm lần trước là:  " + cabinetsRecord.TotalWateringTime + " phút";
            } else
            {
                ret = "Thời gian bơm lần trước là:  " + (int)(cabinetsRecord.TotalWateringTime/60) + " giờ" + (int)(cabinetsRecord.TotalWateringTime % 60) + " phút";
            }
            

            return ret;
        }
        //FieldID=>=>CabinetRecord=>Get the latest CompletedWateringlevel
        private string GetLastWatteringLevel(SQL.SQLTables.CabinetsRecords cabinetsRecord)
        {
            string ret = "";
            if (cabinetsRecord == null)
            {
                return ret;
            }
            ret = "Lần trước bơm mực nước  " + cabinetsRecord.CompletedWateringLevel + " cm";


            return ret;
        }

        // FieldID=>water => current level
        private string GetCurrentWatteringlevel(SQL.SQLTables.Water water)
        {
            string ret = "0";
            if (water != null)
            {
                int temp = (int)(water.WaterLevelValue * 100 / water.WaterMaxLevel);
                if (temp > 100)
                    temp = 100;
                ret = temp.ToString() + "%";
            }
            return ret;
        }
        //FieldID=>water=> Maximum level
        private string GetWatteringSettingLevel(SQL.SQLTables.Water water)
        {
            string ret = "Chưa cài đặt";
            if (water != null)
            {
                ret = water.WaterMaxLevel.ToString() + " cm";
            }
            return ret;
        }

        private string GetACLostPhase(SQL.SQLTables.Field field)
        {
            string ret = "";            
            if (field != null)
            {
                if (field.PowerOnOff)
                {
                    if (field.NumberACLostPhases < 3)
                    {
                        ret = "SỐ PHA MẤT ĐIỆN LÀ: " + (3 - field.NumberACLostPhases) + "PHA";
                    } else
                    {
                        ret = "ĐIỆN ỔN ĐỊNH: TỐT";
                    }
                }
            }
            return ret;
        }
        private string GetCurrentWateringDurationValue(SQL.SQLTables.Field field)
        {
            string ret = "";
            if (field != null)
            {
                if (field.PowerOnOff)
                {
                    // int durTime = (DateTime.Now.Minute - ((DateTime)field.TimeOn).Minute);
                    TimeSpan difTime = (DateTime.Now - ((DateTime)field.TimeOn));
                    //double durTime = difTime.TotalMinutes;
                    if (difTime.TotalHours < 1)
                    {
                        ret = "Đang bơm được: " + difTime.Minutes + " phút";
                    }  else
                    {
                        ret = "Đang bơm được: " + (int)(difTime.TotalHours) + " giờ " + difTime.Minutes + " phút";
                    }
                    
                }
            }
            return ret;
        }
        private string GetRiverLevel(SQL.SQLTables.Field field)
        {
            string ret = "Chưa cập nhật được mức nước sông";
            if (field != null)
            {
                if (field.RiverLevelValue > 0)
                    ret = "Mực nước sông hiện tại là: " + field.RiverLevelValue + " cm";
            }
            return ret;
        }


        private void PowerOnOffCabinets()
        {
            foreach (var item in Items)
            {
                if (item.FieldInfo.PowerOnOff)
                {
                    if (item.animationHandler == null)
                    { // turn on
                        item.WateringButtonEnable = false;
                        item.WateringButtonColor = Color.Gray;
                        item.StopButtonEnable = true;
                        item.StopButtonColor = Color.Red;
                        item.SettingButtonEnable = false;
                        item.SettingButtonColor = Color.Gray;
                        item.animationHandler = new Animation();
                        item.animationHandler.Add(0, 1, new Animation());
                        //item.animationHandler.Commit(this, "Truc", 10, 1100, null, (double v, bool c) => {
                        item.animationHandler.Commit(this, item.FieldInfo.ID.ToString(), 16, 100, null, (double v, bool c) => {
                            if (item.ProgressValue >= 100)
                                item.ProgressValue = item.WaterInfo.WaterLevelValue*100/item.WaterInfo.WaterMaxLevel;
                            else 
                                item.ProgressValue = item.ProgressValue + 10;
                            System.Diagnostics.Debug.WriteLine("==" + item.ProgressValue);
                        }, () => true);                       
                    }
                   // item.WateringButtonText = item.SettingButtonEnable ? "Bật máy bơm" : "Tắt máy bơm"   ;
                }
                else
                {
                    if (item.animationHandler != null)
                    {
                        item.WateringButtonEnable = true;
                        item.WateringButtonColor = Color.Green;
                        item.StopButtonEnable = false;
                        item.StopButtonColor = Color.Gray;
                        item.SettingButtonEnable = true;
                        item.SettingButtonColor = Color.White;

                        item.animationHandler = null;
                        try
                        {
                            this.AbortAnimation(item.FieldInfo.ID.ToString());
                        }
                        catch { }
                        item.ProgressValue = 0;
                    }
                    item.ProgressValue = item.WaterInfo.WaterLevelValue * 100 / item.WaterInfo.WaterMaxLevel;
                   // item.WateringButtonText = item.SettingButtonEnable ? "Bật máy bơm" : "Tắt máy bơm";
                }                
            }
        }
        private bool WatteringFlag = true;
        private async void WateringButton_Clicked(object sender, EventArgs e)
        {
            if (await isGateWayOnline() == false)
            {
                await Globals.ShowLoading5Sec("Không kết nối được với tủ điện! Xin kiểm tra lại kết nối.");
                Globals.HideLoading();
                return;
            }

            if (WatteringFlag == false)
                return;
            WatteringFlag = false;
            Button item = (sender as Button);
            var bc = item.BindingContext as ListData;
            // System.Diagnostics.Debug.WriteLine("======FieldID:" + bc.FieldInfo.ID + "Time on " + Globals.CurrentCabinets.TimeOn + "Time off " + Globals.CurrentCabinets.TimeOff);            
            await GetAllCabinetsRecords(Globals.CurrentCabinets.ID, 0);
            foreach (var eachdata in Items)
            {
                if (eachdata.FieldInfo.ID == bc.FieldInfo.ID)
                {
                    
                    if (eachdata.FieldInfo.PowerOnOff)
                    {   //ON => OFF
                        /*
                        eachdata.FieldInfo.PowerOnOff = false;

                        eachdata.FieldInfo.TimeOff = DateTime.Now;

                        eachdata.FieldInfo.TotalWateringTime = DateTime.Now.Minute - ((DateTime)eachdata.FieldInfo.TimeOn).Minute; ;
                        eachdata.FieldInfo.UpdateDate = DateTime.Now;
                        //await GetAllCabinetsRecords(Globals.CurrentCabinets.ID, eachdata.FieldInfo.ID);
                        int currentwaterleve = 0;
                        foreach (var fielditem in Items)
                            if (eachdata.FieldInfo.ID == fielditem.FieldInfo.ID)
                            {
                                currentwaterleve = fielditem.WaterInfo.WaterLevelValue;
                                break;
                            }
                        bool found = false;
                        SQL.SQLTables.CabinetsRecords record = null;
                        foreach(var eachrecord in CabinetsRecordList)
                        {
                            if (eachrecord.FieldID == eachdata.FieldInfo.ID)
                            {
                                record = eachrecord;
                                break;
                            }    
                        }    

                    //    if (record != null)
                        {
                        //    record.TimeOff = eachdata.FieldInfo.TimeOff;
                      //      record.TimeOn = eachdata.FieldInfo.TimeOn;
                       //     record.TotalWateringTime = eachdata.FieldInfo.TotalWateringTime;
                       //     record.InsertDate = eachdata.FieldInfo.UpdateDate;
                      ////      record.CompletedWateringLevel = currentwaterleve;
                        //    await Globals.sslClient.UpdateTableDataAsync(record);
                        }
                        //else
                        {
                            record = new SQL.SQLTables.CabinetsRecords
                            {
                                CreateDate = DateTime.Now,
                                CabinetsID = Globals.CurrentCabinets.ID,
                                FieldID = eachdata.FieldInfo.ID,
                                TimeOn = eachdata.FieldInfo.TimeOn,
                                TimeOff = eachdata.FieldInfo.TimeOff,
                                TotalWateringTime = eachdata.FieldInfo.TotalWateringTime,
                                CompletedWateringLevel = currentwaterleve,
                                InsertDate = DateTime.Now
                            };
                            await Globals.sslClient.InsertTableDataAsync(record);
                        }
                        eachdata.LastWateringDaysAgo = GetTheLastWatteringDay(record);
                        eachdata.LastTotalWateringHours = GetLastWatteringHours(record);
                        eachdata.LastWateringLevel = GetLastWatteringLevel(record);
                    */
                        continue;
                    }
                    else
                    {   //Turn on
                        //CHECK THE RIVER LEVEL
                        if (eachdata.FieldInfo.RiverLevelMin < eachdata.FieldInfo.RiverLevelValue)
                        {
                            await Globals.ShowToast("KHÔNG THỂ BƠM VÀO LÚC NÀY VÌ MỰC NƯỚC SÔNG QUÁ THẤP ĐỂ BƠM! \n XIN ĐỢI 1 THỜI GIAN NỮA!");
                            Refresh();
                            return;
                        }    
                        //END CHECK
                        eachdata.FieldInfo.PowerOnOff = true;
                        eachdata.FieldInfo.TimeOn = DateTime.Now;
                        eachdata.FieldInfo.TimeOff = DateTime.Now;
                        eachdata.FieldInfo.TotalWateringTime = 0;
                        eachdata.FieldInfo.UpdateDate = DateTime.Now;
                    }
                    PowerOnOffCabinets();
                    //System.Diagnostics.Debug.WriteLine("======FieldID Change::" + bc.FieldInfo.ID + "Time on " + Globals.CurrentCabinets.TimeOn + "Time off " + Globals.CurrentCabinets.TimeOff);
                    //System.Diagnostics.Debug.WriteLine("======FieldID:" + bc.FieldInfo.ID + "Time on " + eachdata.FieldInfo.TimeOn + "Time off " + eachdata.FieldInfo.TimeOff);
                    await Globals.sslClient.UpdateTableDataAsync<SQL.SQLTables.Field>(eachdata.FieldInfo);
                    //System.Diagnostics.Debug.WriteLine("======FieldID:" + bc.FieldInfo.ID + "Time on " + eachdata.FieldInfo.TimeOn + "Time off " + eachdata.FieldInfo.TimeOff);
                    //Refresh();
                }
            }
            WatteringFlag = true;
        }
/*
        private void SettingButton_Clicked(object sender, EventArgs e)
        {
            Button item = (sender as Button);
            var bc = item.BindingContext as ListData;
            Globals.CurrentSettingWaterData = bc.WaterInfo;
            Globals.CurrentSettingFieldData = bc.FieldInfo;
            Globals.ChangeDetailPage<WaterLevelSetting>();
        }
*/
 

        private void TramSettingButton_Clicked(object sender, EventArgs e)
        {
            ContentView item = (sender as ContentView);
            var bc = item.BindingContext as ListData;
            Globals.CurrentSettingWaterData = bc.WaterInfo;
            Globals.CurrentSettingFieldData = bc.FieldInfo;
            Globals.ChangeDetailPage<WaterLevelSetting>();
        }
        private bool StopFlag = true;
        private async void StopWateringButton_Clicked(object sender, EventArgs e)
        {
            if (await isGateWayOnline() == false)
            {
                await Globals.ShowLoading5Sec("Không kết nối được với tủ điện! Xin kiểm tra lại kết nối.");
                Globals.HideLoading();
                return;
            }
            if (StopFlag == false)
                return;
            StopFlag = false;
            Button item = (sender as Button);
            var bc = item.BindingContext as ListData;
            // System.Diagnostics.Debug.WriteLine("======FieldID:" + bc.FieldInfo.ID + "Time on " + Globals.CurrentCabinets.TimeOn + "Time off " + Globals.CurrentCabinets.TimeOff);            
            await GetAllCabinetsRecords(Globals.CurrentCabinets.ID, 0);
            foreach (var eachdata in Items)
            {
                if (eachdata.FieldInfo.ID == bc.FieldInfo.ID)
                {

                    if (eachdata.FieldInfo.PowerOnOff)
                    {   //ON => OFF
                        eachdata.FieldInfo.PowerOnOff = false;

                        eachdata.FieldInfo.TimeOff = DateTime.Now;
                        TimeSpan difTime = (DateTime.Now - ((DateTime)eachdata.FieldInfo.TimeOn));
                        //eachdata.FieldInfo.TotalWateringTime = DateTime.Now.Minute - ((DateTime)eachdata.FieldInfo.TimeOn).Minute; ;
                        eachdata.FieldInfo.TotalWateringTime = (int)(difTime.TotalMinutes);
                        System.Diagnostics.Debug.WriteLine("============Field Info time: " + eachdata.FieldInfo.TotalWateringTime);
                        eachdata.FieldInfo.UpdateDate = DateTime.Now;
                        //await GetAllCabinetsRecords(Globals.CurrentCabinets.ID, eachdata.FieldInfo.ID);
                        int currentwaterleve = 0;
                        foreach (var fielditem in Items)
                            if (eachdata.FieldInfo.ID == fielditem.FieldInfo.ID)
                            {
                                currentwaterleve = fielditem.WaterInfo.WaterLevelValue;
                                break;
                            }
                        SQL.SQLTables.CabinetsRecords  record = new SQL.SQLTables.CabinetsRecords
                        {
                            CreateDate = DateTime.Now,
                            CabinetsID = Globals.CurrentCabinets.ID,
                            FieldID = eachdata.FieldInfo.ID,
                            TimeOn = eachdata.FieldInfo.TimeOn,
                            TimeOff = eachdata.FieldInfo.TimeOff,
                            TotalWateringTime = eachdata.FieldInfo.TotalWateringTime,
                            CompletedWateringLevel = currentwaterleve,
                            InsertDate = DateTime.Now
                        };
                        System.Diagnostics.Debug.WriteLine("============Record Info time: " + record.TotalWateringTime);
                        await Globals.sslClient.InsertTableDataAsync(record);
                        eachdata.LastWateringDaysAgo = GetTheLastWatteringDay(record);
                        eachdata.LastTotalWateringHours = GetLastWatteringHours(record);
                        eachdata.LastWateringLevel = GetLastWatteringLevel(record);
                        PowerOnOffCabinets();
                        //System.Diagnostics.Debug.WriteLine("======FieldID Change::" + bc.FieldInfo.ID + "Time on " + Globals.CurrentCabinets.TimeOn + "Time off " + Globals.CurrentCabinets.TimeOff);
                        //System.Diagnostics.Debug.WriteLine("======FieldID:" + bc.FieldInfo.ID + "Time on " + eachdata.FieldInfo.TimeOn + "Time off " + eachdata.FieldInfo.TimeOff);
                        await Globals.sslClient.UpdateTableDataAsync<SQL.SQLTables.Field>(eachdata.FieldInfo);
                        //System.Diagnostics.Debug.WriteLine("======FieldID:" + bc.FieldInfo.ID + "Time on " + eachdata.FieldInfo.TimeOn + "Time off " + eachdata.FieldInfo.TimeOff);
                        //Refresh();
                    }

                }
            }
            StopFlag = true;
        }
        private async Task<bool> isGateWayOnline()
        {
            try
            {
                SQL.SQLTables.Cabinets ret = (await Globals.sslClient.GetTableAllDataAsync<SQL.SQLTables.Cabinets>("`ID`='" + Globals.CurrentCabinets.ID + "'", true)).First();
                if (ret == null)
                    return false;
                if (string.IsNullOrEmpty(ret.Reserved1))
                    return false;
                if (ret.Reserved1.Equals("Offline"))
                    return false;
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}