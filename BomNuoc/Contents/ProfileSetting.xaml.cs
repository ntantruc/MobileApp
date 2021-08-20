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
	public partial class ProfileSetting : ContentPage
	{
		public ProfileSetting ()
		{
			InitializeComponent ();
		}
        public  void Refresh()
        {
            CooperativeName.Text = Globals.CooperativeData.CooperateName;
        }

        private async void ChangePasswordButton_Clicked(object sender, EventArgs e)
        {
            string oldpass = OldPassword.Text.Trim();
            string newpass = NewPassword.Text.Trim();
            string newpassrepeat = NewPasswordOnemore.Text.Trim();
            if (string.IsNullOrEmpty(oldpass) || string.IsNullOrEmpty(newpass) || string.IsNullOrEmpty(newpassrepeat))
            {
                //Show message
                await Globals.ShowToast("Bạn chưa nhập các mật khẩu đúng. Xin nhập lại.");                
                return;
            }
            if (newpass.Equals(newpassrepeat) == false)
            {
                //Show message
                await Globals.ShowToast("Mật khẩu chưa đúng. Xin nhập lại.");
                return;
            }
            // Get latest user info
            Globals.CurrentUserData = (await Globals.sslClient.GetTableAllDataAsync<SQL.SQLTables.User>("`UserName`='" + Globals.CurrentUserData.UserName + "'", true)).First();
            //compare old password
            if (oldpass.Equals(Globals.CurrentUserData.Password) == false)
            {
                //Show message
                await Globals.ShowToast("Mật khẩu chưa đúng! Xin nhập lại.");
                return;
            }
            //update user info
            Globals.CurrentUserData.Password = newpass;
            await Globals.sslClient.UpdateTableDataAsync<SQL.SQLTables.User>(Globals.CurrentUserData);
            await Globals.ShowToast("Thay đổi mật khẩu THÀNH CÔNG.");
            Globals.ChangeDetailPage<PumpControlList>();
        }
    }
}