using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Contacts_Bpp.Data;
using Xamarin.Forms;

namespace Contacts_Bpp.Views
{
    public partial class Tabbed_r : ContentPage
    {
        public Tabbed_r()
        {
            InitializeComponent();
          
        }

        async void Tabbed_rappearing(object sender, EventArgs e)
        {
            string url = Tools.NetClass.ExSqlUrl + "Contact_/ExSql?SQL=GetAll";
            var a = await Tools.NetClass.GetStringByUrl(url);
            List<Data.people> contactman = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Data.people>>(a.ToString());
            listview_contact.ItemsSource = contactman;
        }

        void brn_wdqz(object sender, object e)
        {
            DisplayAlert("1", "brn_wdqz", "3");
        }
        void brn_aqcz(object sender, object e)
        {
            DisplayAlert("1", "brn_aqcz", "3");
        }

        void btn_add(object sender, EventArgs e)
        {
            
        }

        void list_contact_itemselected(object sender, SelectedItemChangedEventArgs e)
        {
            var mi = (people)e.SelectedItem;
            Tools.Classviews.OpenPage(new Views.Detailed(mi), false, true);
            
        }
    }
}
