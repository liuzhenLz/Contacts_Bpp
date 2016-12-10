using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Contacts_Bpp.Views
{
    public partial class Tabbed_l : ContentPage
    {
        public Tabbed_l()
        {
            InitializeComponent();
        }

        async void btn_getdata(object sender, EventArgs e)
        {
            string url = Tools.NetClass.ExSqlUrl + "Contact_/ExSql?SQL=GetAll";
           // string url = NetHelper.ExSqlUrl + "Hero/ExSql?SQL=Sql_GetData";
           // string para = "";
          var a= await Tools.NetClass.GetStringByUrl(url);
            my_entry.Text = a;
        }
    }
}
