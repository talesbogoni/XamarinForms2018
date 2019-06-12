using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_master_detail.Menu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Menu : MasterDetailPage
	{
		public Menu ()
		{
			InitializeComponent ();
		}

        private void Btpg1_Clicked(object sender, EventArgs e)
        {
            Detail = new Paginas.Page1();
            IsPresented = false;
        }

        private void Btpg2_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage (new Paginas.Page2());
        }

        private void Btpg3_Clicked(object sender, EventArgs e)
        {
            Detail = new Paginas.Page3();
        }
    }
}