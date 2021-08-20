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
	public partial class PDSInfo : ContentPage
	{
		public PDSInfo ()
		{
			InitializeComponent ();
		}
        public void Refresh()
        {

        }
	}
}