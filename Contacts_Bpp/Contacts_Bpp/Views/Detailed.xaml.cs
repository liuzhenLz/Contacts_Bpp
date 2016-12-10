using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Contacts_Bpp.Views
{
    public partial class Detailed : ContentPage
    {
        public Detailed()
        {
            InitializeComponent();
            
        }
        public Detailed( Data.people mi)
        {
            InitializeComponent();
            this.BindingContext = mi;
        }
    }
}
