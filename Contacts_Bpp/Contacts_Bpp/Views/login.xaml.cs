using Contacts_Bpp.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Contacts_Bpp.Views
{
    public partial class login : ContentPage
    {
        public login()
        {
            InitializeComponent();

        }

        async void clicked_login(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ety_account.Text) && !string.IsNullOrWhiteSpace(ety_pwd.Text))
            {
                var url = NetClass.ExSqlUrl + "Contact_/UserLogin?username=" + ety_account.Text + "&password=" +
                          ety_pwd.Text;
                try
                {
                    var result = await NetClass.GetStringByUrl(url);
                }
                catch (Exception)
                {
                    IHUD ihud = DependencyService.Get<IHUD>();
                    ihud.Show_Toast("请链接网络！");
                }
                
                switch (result)
                {
                    case "0":
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            IHUD ihud = DependencyService.Get<IHUD>();
                            ihud.Show_Toast("用户名不存在，请检查用户名！");
                            // DisplayAlert("1", "账号不存在", "3");
                        });
                        break;
                    case "1":
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            IHUD ihud = DependencyService.Get<IHUD>();
                            ihud.Show_Toast("密码错误！");
                            // DisplayAlert("1", "密码错误", "3");
                        });
                        break;
                    case "2":
                        Tools.Classviews.OpenPage(new Tabbed(), false, true);
                        break;
                }

            }


            // Tools.Classviews.OpenPage(new Tabbed(), false,true);
        }

       
    }
}
