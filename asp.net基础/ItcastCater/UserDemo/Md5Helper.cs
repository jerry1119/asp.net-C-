using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UserDemo
{
    public class Md5Helper
    {
        public static string EncryptString(string str)
        {
            //utf8,x2
            //创建对象的方法：构造方法，静态方法（工厂）
            MD5 md5 = MD5.Create();
            byte[] byteOld = Encoding.UTF8.GetBytes(str);
            byte[] byteNew = md5.ComputeHash(byteOld);
            StringBuilder sb = new StringBuilder();
            foreach (byte item in byteNew)
            {
                sb.Append(item.ToString("x2"));
            }
            return sb.ToString();
        }

    }
}
