using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts_Bpp.Tools
{
    public interface IHUD
    {
        void Show_StatusMessage(string StatusMessage);
        void Show_Success(string Message);
        void Show_Error(string Message);
        void Show_Toast(string Message);
        void Dismiss();
    }
}
