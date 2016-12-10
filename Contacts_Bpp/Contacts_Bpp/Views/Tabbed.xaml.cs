using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Contacts_Bpp.Views
{
    public partial class Tabbed : TabbedPage
    {
        public Tabbed()
        {
            InitializeComponent();
            Tabbed_l lefTabbed = new Tabbed_l();
            lefTabbed.Title = "通话";
            Tabbed_r righTabbed = new Tabbed_r();
            righTabbed.Title = "联系人";
            this.Children.Add(righTabbed);
            this.Children.Add(lefTabbed);
        }
    }
}
