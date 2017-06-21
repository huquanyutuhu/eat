using System;
using System.IO;
using System.Text;

namespace GOGOGO.Commons
{
    public class FileHelper
    {
        public static void Write(string str,string shopName)
        {
            FileStream fs = new FileStream($"{System.Web.HttpContext.Current.Server.MapPath($"~/Files/{shopName}.txt")}", FileMode.Append);
            //获得字节数组
            byte[] data = Encoding.GetEncoding("gb2312").GetBytes(str);
            //开始写入
            fs.Write(data, 0, data.Length);
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();
        }


        public static void WriteNew(string str, string shopName)
        {
            FileStream fs = new FileStream($"{System.Web.HttpContext.Current.Server.MapPath($"~/Files/{shopName}.txt")}", FileMode.Create);
            //获得字节数组
            byte[] data = Encoding.GetEncoding("gb2312").GetBytes(str);
            //开始写入
            fs.Write(data, 0, data.Length);
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();
        }

        public static string Read(string shopName)
        {
            StringBuilder sb = new StringBuilder();
            StreamReader sr = new StreamReader($"{System.Web.HttpContext.Current.Server.MapPath($"~/Files/{shopName}.txt")}", Encoding.GetEncoding("gb2312"));
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                sb.Append(line);
            }
            sr.Close();
            return sb.ToString();
        }
    }
}