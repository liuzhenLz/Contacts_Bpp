using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Xamarin.Forms;
using AndroidHUD;

[assembly: Xamarin.Forms.Dependency(typeof(Contacts_Bpp.Droid.Tools.HUD))]

namespace Contacts_Bpp.Droid.Tools
{
   public class HUD:Contacts_Bpp.Tools.IHUD
    {

        /// <summary>
        /// ��ʾ��ת + �ı�
        /// </summary>
        /// <param name="StatusMessage"></param>
        public void Show_StatusMessage(string StatusMessage)
        {
            AndHUD.Shared.Show(Forms.Context, StatusMessage, -1, MaskType.Clear);
        }
        /// <summary>
        /// �ر�
        /// </summary>
        public void Dismiss()
        {
            AndHUD.Shared.Dismiss();
        }
        /// <summary>
        /// һ���ɹ���ͼ����ʾһ����Ϣ����һ����ȷ�ı��������Զ��ų���2��
        /// </summary>
        /// <param name="Message"></param>
        public void Show_Success(string Message)
        {
            AndHUD.Shared.ShowSuccess(Forms.Context, Message, MaskType.Clear, TimeSpan.FromSeconds(2));
        }
        /// <summary>
        /// ��ʾһ������ͼ����һ��ģ���ı�������Ϣ�����Զ��ų���2��
        /// </summary>
        /// <param name="Message"></param>
        public void Show_Error(string Message)
        {
            AndHUD.Shared.ShowError(Forms.Context, Message, MaskType.Clear, TimeSpan.FromSeconds(2));
        }
        /// <summary>
        /// ��ʾһ����׿������˾
        /// </summary>
        /// <param name="Message"></param>
        public void Show_Toast(string Message)
        {
            AndHUD.Shared.ShowToast(Forms.Context, Message, MaskType.Clear, TimeSpan.FromSeconds(2));
        }

    }



}