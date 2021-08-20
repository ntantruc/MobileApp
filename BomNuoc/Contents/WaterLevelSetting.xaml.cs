using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BomNuoc.Contents
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WaterLevelSetting : ContentPage
	{
        Dictionary<string, int> WaterLevelMap = new Dictionary<string, int>();
        Dictionary<string, int> LimitedTimeMap = new Dictionary<string, int>();
        Dictionary<string, double> RiverLevelMap = new Dictionary<string, double>();
        public WaterLevelSetting ()
		{
			InitializeComponent ();
            for (int i =1; i < 11; i++)
            {
                WaterLevelMap[i.ToString() + " cm"] = i;
            }
            for (int i = 1; i < 23; i++)
            {
                LimitedTimeMap[i.ToString() + " giờ"] = i;
            }
            LimitedTimeMap["25 giờ"] = 25;
            LimitedTimeMap["30 giờ"] = 30;
            LimitedTimeMap["35 giờ"] = 35;
            LimitedTimeMap["40 giờ"] = 40;
            LimitedTimeMap["45 giờ"] = 45;
            LimitedTimeMap["50 giờ"] = 50;
            LimitedTimeMap["55 giờ"] = 55;
            LimitedTimeMap["60 giờ"] = 60;
            LimitedTimeMap["65 giờ"] = 65;
            LimitedTimeMap["100 giờ"] = 100;
            LimitedTimeMap["150 giờ"] = 150;
            LimitedTimeMap["240 giờ"] = 240;

            RiverLevelMap["1 mét"] = 100;
            RiverLevelMap["1.25 mét"] = 125;
            RiverLevelMap["1.5 mét"] = 150;
            RiverLevelMap["1.75 mét"] = 175;
            RiverLevelMap["2 mét"] = 200;
            RiverLevelMap["2.25 mét"] = 225;
            RiverLevelMap["2.5 mét"] = 250;
            RiverLevelMap["2.75 mét"] = 275;
            RiverLevelMap["3 mét"] = 300;
            RiverLevelMap["3.25 mét"] = 325;
            RiverLevelMap["3.5 mét"] = 350;
            RiverLevelMap["3.75 mét"] = 375;
            RiverLevelMap["4 mét"] = 400;
            RiverLevelMap["5 mét"] = 500;
        }
        public void Refresh()
        {
            try
            {
                CooperativeName.Text = Globals.CooperativeData.CooperateName;
                FieldDescription.Text = Globals.CurrentSettingFieldData.FieldDescription;
                int WaterIndex = GetIndexOfWaterLevel(Globals.CurrentSettingWaterData.WaterMaxLevel);
                int TimeIndex = GetIndexOfLimitedTime(Globals.CurrentSettingFieldData.LimitedWatteringTime);

                int RiverlevelIndex = GetIndexOfRiverLevel(Globals.CurrentSettingFieldData.RiverLevelMin);
                SelecteWaterLevel.SelectedIndex = WaterIndex;
                LimitedWateringTime.SelectedIndex = TimeIndex;
                RiverLevel.SelectedIndex = RiverlevelIndex;
            }
            catch
            {

            }
            
        }
        private int GetIndexOfWaterLevel(int level)
        {
            int ret = 0;
            foreach (var item in WaterLevelMap)
            {
                if (level == item.Value)
                {
                    return ret;
                }
                ret++;
            }
            if (ret >= WaterLevelMap.Count)
                ret = WaterLevelMap.Count - 1;
            return ret;
        }

        private int GetIndexOfLimitedTime(int level)
        {
            int ret = 0;
            foreach (var item in LimitedTimeMap)
            {
                if (level == item.Value)
                {
                    return ret;
                }
                ret++;
            }
            if (ret >= LimitedTimeMap.Count)
                ret = LimitedTimeMap.Count - 1;
            return ret;
        }

        private int GetIndexOfRiverLevel(double? level)
        {
            int ret = 0;
            if (level == null)
                return ret;
            foreach (var item in RiverLevelMap)
            {
                if (level == item.Value)
                {
                    return ret;
                }
                ret++;
            }
            if (ret >= RiverLevelMap.Count)
                ret = RiverLevelMap.Count - 1;
            return ret;
        }
        private async void SettingButton_Clicked(object sender, EventArgs e)
        {
            bool changedFlag = false;
            bool WaterchangedFlag = false;
            if (Globals.CurrentSettingWaterData.WaterMaxLevel != WaterLevelMap.ElementAt(SelecteWaterLevel.SelectedIndex).Value)
            {
                WaterchangedFlag = true;
                Globals.CurrentSettingWaterData.WaterMaxLevel = WaterLevelMap.ElementAt(SelecteWaterLevel.SelectedIndex).Value;
            }    
            if (Globals.CurrentSettingFieldData.LimitedWatteringTime != LimitedTimeMap.ElementAt(LimitedWateringTime.SelectedIndex).Value)
            {
                changedFlag = true;
                Globals.CurrentSettingFieldData.LimitedWatteringTime = LimitedTimeMap.ElementAt(LimitedWateringTime.SelectedIndex).Value;
            }    
            if (Globals.CurrentSettingFieldData.RiverLevelMin != RiverLevelMap.ElementAt(RiverLevel.SelectedIndex).Value)
            {
                changedFlag = true;
                Globals.CurrentSettingFieldData.RiverLevelMin = RiverLevelMap.ElementAt(RiverLevel.SelectedIndex).Value;
            }
            if (FieldDescription.Text.Equals(Globals.CurrentSettingFieldData.FieldDescription) == false)
            {
                changedFlag = true;
                Globals.CurrentSettingFieldData.FieldDescription = FieldDescription.Text;
            }

            if (WaterchangedFlag)
            {
                Globals.CurrentSettingWaterData.UpdateDate = DateTime.Now;
                await Globals.sslClient.UpdateTableDataAsync<SQL.SQLTables.Water>(Globals.CurrentSettingWaterData);             
            }

            if (changedFlag)
            {
                Globals.CurrentSettingFieldData.UpdateDate = DateTime.Now;            
                await Globals.sslClient.UpdateTableDataAsync<SQL.SQLTables.Field>(Globals.CurrentSettingFieldData);
            }

            if (changedFlag | WaterchangedFlag)
            {
                await Globals.ShowToast("Cài đặt THÀNH CÔNG.");
            }               

            Globals.ChangeDetailPage<PumpControlList>();
        }
    }

}