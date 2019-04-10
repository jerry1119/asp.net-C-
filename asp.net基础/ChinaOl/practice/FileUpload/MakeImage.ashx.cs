using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace practice.FileUpload
{
    /// <summary>
    /// Summary description for MakeImage
    /// </summary>
    public class MakeImage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            //给用户创建一张图片，并且把这张图片保存
            //创建一张画布
            using (Bitmap map = new Bitmap(333, 444))
            {
                //给画布创建一个画笔
                using (Graphics pen = Graphics.FromImage(map))
                {
                    pen.Clear(Color.Pink);
                    //在画布上写字

                    //1.写的什么字
                    //2.字体的样式，字体大小等
                    //3.用什么颜色填充字体
                    //4.在画布的什么位置写字

                    pen.DrawString("ChinaOl",new Font("宋体",14.0f,FontStyle.Bold),Brushes.Green,new PointF(50,50));

                    //将画布保存成一张图片,并指定图片的类型
                    string fileName = Guid.NewGuid().ToString();
                    map.Save(context.Request.MapPath("/FileUpload/ImageUpload/"+fileName+".jpg"),System.Drawing.Imaging.ImageFormat.Jpeg);
                    context.Response.Write("<html><body><img src='/FileUpload/ImageUpload/"+fileName+".jpg'></body></html>");
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}