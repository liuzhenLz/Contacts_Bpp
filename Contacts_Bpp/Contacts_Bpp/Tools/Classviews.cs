using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts_Bpp.Tools
{
   public class Classviews
    {
        public static Xamarin.Forms.NavigationPage AppNtp
        {
            set; get;
        }

        public static void OpenPage(Xamarin.Forms.Page NewPage, bool Modal, bool animated)
        {
            if (Modal)
            {
                Tools.Classviews.AppNtp.Navigation.PushModalAsync(NewPage, animated);
            }
            else
            {
                Tools.Classviews.AppNtp.Navigation.PushAsync(NewPage, animated);

            }
        }
        public static void ClosePage()
        {
            Tools.Classviews.AppNtp.Navigation.PopAsync(true);
        }
        public static void CloseModalPage()
        {
            Tools.Classviews.AppNtp.Navigation.PopModalAsync(true);
        }
    }
}
