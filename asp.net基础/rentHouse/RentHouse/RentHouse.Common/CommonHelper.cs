using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RentHouse.Common
{
    public class CommonHelper
    {
        public static string CalcMd5(string str)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(str);//先把字符串转成bytes字节数组
            return CalcMd5(bytes);
        }

        public static string CalcMd5(byte[] bytes)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] computeBytes = md5.ComputeHash(bytes); //再算出bytes的hash值
                string result = "";
                for (int i = 0; i < computeBytes.Length; i++)
                {
                    //将hash值转成16进制，如果只有一位的在前面填0
                    result += computeBytes[i].ToString("X").Length == 1 ? "0" +
                    computeBytes[i].ToString("X") : computeBytes[i].ToString("X");
                }
                return result;

            }
        }
        public static string CalcMd5(Stream stream)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] computeBytes = md5.ComputeHash(stream);
                string result = "";
                for (int i = 0; i < computeBytes.Length; i++)
                {
                    result += computeBytes[i].ToString("X").Length == 1 ? "0" +
                                                                          computeBytes[i].ToString("X") : computeBytes[i].ToString("X");
                }
                return result;
            }
        }
        public static string GenerateCaptchaCode(int len)
        {
            char[] data = { 'a', 'c', 'd', 'e', 'f', 'g', 'k', 'm', 'p', 'r', 's', 't', 'w', 'x', 'y', '3', '4', '5', '7', '8' };
            StringBuilder sbCode = new StringBuilder();
            Random rand = new Random();
            for (int i = 0; i < len; i++)
            {
                char ch = data[rand.Next(data.Length)];
                sbCode.Append(ch);
            }
            return sbCode.ToString();
        }
    }
}