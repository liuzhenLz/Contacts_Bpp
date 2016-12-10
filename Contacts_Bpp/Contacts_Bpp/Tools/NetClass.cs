using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Contacts_Bpp.Tools
{
    public class NetClass
    {
        public NetClass()
        {

        }
        private static string _ExSqlUrl = "http://192.168.0.144:2992/api/";
       //改成服务端的IP地址和端口
       // private static string _ExSqlUrl = "http://localhost:2992/api/";


        public static string ExSqlUrl
        {
            get
            {
                return _ExSqlUrl;
            }
            set
            {
                _ExSqlUrl = value;
            }
        }
        public async static Task<string> GetStringByUrl(string url)
        {
            //创建一个请求
            System.Net.HttpWebRequest httpReq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(new Uri(url));
            System.Net.HttpWebResponse httpRes = (System.Net.HttpWebResponse)await httpReq.GetResponseAsync();

            if (httpRes.StatusCode == System.Net.HttpStatusCode.OK)
            {
                System.IO.Stream s = httpRes.GetResponseStream();
                System.IO.StreamReader reader = new System.IO.StreamReader(s);//如有意外乱码，可在s后面加（,gb2312）
                return reader.ReadToEnd();
            }
            else
            {
                return "";
            }
        }

        public async static Task<Newtonsoft.Json.Linq.JArray> GetJosnBySql(string sqlName, string para)
        {
            if (para.Trim() == "")
            { }
            else
            {
                para = "&" + para;
            }
            var ExSQLUrl = ExSqlUrl + "Contact_/ExSql?SQL={SQL}";
            //para = System.Net.WebUtility.UrlEncode(para); //%20
            string url = ExSQLUrl.Replace("{SQL}", sqlName + para);
            string json = await GetStringByUrl(url);
            json = "{\"T\":" + json + "}";
            Newtonsoft.Json.Linq.JObject Jo = Newtonsoft.Json.Linq.JObject.Parse(json);
            Newtonsoft.Json.Linq.JArray jar = Newtonsoft.Json.Linq.JArray.Parse(Jo["T"].ToString());
            if (json.Contains(@"""ErrMessage"":"""))
            {
                throw new System.Exception(jar[0]["ErrMessage"].ToString());
            }
            return jar;
        }

        public async static Task<string> PostData(string url, string postData)
        {
            //定义request并设置request的路径
            WebRequest request = WebRequest.Create(url);
            request.Method = "post";
            //设置参数的编码格式，解决中文乱码
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            //设置request的MIME类型及内容长度
            request.ContentType = "application/json";
            //request.ContentLength = byteArray.Length;
            //打开request字符流
            Task<System.IO.Stream> dataStream_Task = request.GetRequestStreamAsync();
            System.IO.Stream dataStream = await dataStream_Task;
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Dispose();
            //定义response为前面的request响应
            WebResponse response = await request.GetResponseAsync();
            //定义response字符流
            dataStream = response.GetResponseStream();
            System.IO.StreamReader reader = new System.IO.StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();//读取所有

            return responseFromServer;
        }

        public async static Task<string> Post_FormData(string url, string postData)
        {
            //定义request并设置request的路径
            WebRequest request = WebRequest.Create(url);
            request.Method = "post";
            //设置参数的编码格式，解决中文乱码
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            //设置request的MIME类型及内容长度
            request.ContentType = "application/x-www-form-urlencoded";
            //request.ContentLength = byteArray.Length;
            //打开request字符流
            Task<System.IO.Stream> dataStream_Task = request.GetRequestStreamAsync();
            System.IO.Stream dataStream = await dataStream_Task;
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Dispose();
            //定义response为前面的request响应
            WebResponse response = await request.GetResponseAsync();
            //定义response字符流
            dataStream = response.GetResponseStream();
            System.IO.StreamReader reader = new System.IO.StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();//读取所有

            return responseFromServer;
        }

      
    }
}
