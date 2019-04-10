using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace practice.缩略图
{
    /// <summary>
    /// Summary description for Thumb
    /// </summary>
    public class Thumb : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            //创建缩略图，定义一个小的画布，将图片画到该画布上，最后保存
            string filePath = context.Request.MapPath("/FileUpload/ImageUpload/water_9a4f9ea6-fe2a-4bbc-94e6-720a3460262e.jpg");
            #region 自己不成熟的缩略图
            //using (Bitmap map = new Bitmap(80, 80))
            //{
            //    using (Image img = Image.FromFile(filePath))
            //    {
            //        using (Graphics g = Graphics.FromImage(map))
            //        {
            //            g.DrawImage(img, 0, 0, map.Width, map.Height);
            //            string fileName = Guid.NewGuid().ToString();
            //            map.Save(context.Request.MapPath("/FileUpload/ImageUpload/" + fileName + ".jpg"), System.Drawing.Imaging.ImageFormat.Jpeg);
            //        }
            //    }
            //} 
            #endregion
            //用别人的类
            string thumb = context.Request.MapPath("/FileUpload/ImageUpload/"+Guid.NewGuid().ToString()+".jpg");
            ChinaOl.ImageClass.MakeThumbnail(filePath, thumb, 100, 100, "w");
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