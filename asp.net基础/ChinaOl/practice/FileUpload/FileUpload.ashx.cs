using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace practice.FileUpload
{
    /// <summary>
    /// Summary description for FileUpload
    /// </summary>
    public class FileUpload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            HttpPostedFile postFile = context.Request.Files[0];//获取上传的文件
            if (postFile.ContentLength > 0)
            {
                //对上传的文件进行校验
                string fileName = Path.GetFileName(postFile.FileName);//获取上传文件的名称包括扩展名
                string fileExt = Path.GetExtension(fileName);//获得后缀名
                List<string> fileExtList = new List<string>();
                string[] fileE = new string[] { ".jpg",".png",".bmp",".jpeg",".gif"};
                fileExtList.AddRange(fileE);
                if (fileExtList.Contains(fileExt))
                {
                    //1.对上传的文件进行重命名
                    string newFileName = Guid.NewGuid().ToString();
                    //2/将上传的文件放在不同的目录下面
                    string dir = "/FileUpload/ImageUpload/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/";
                    //创建文件夹
                    if (!Directory.Exists(context.Request.MapPath(dir)))
                    {
                        Directory.CreateDirectory(context.Request.MapPath(dir));
                    }
                    string fullDir = dir + newFileName + fileExt;//完整路径

                    postFile.SaveAs(context.Request.MapPath(fullDir));

                    //创建图片的水印
                    //using (Image img = Image.FromStream(postFile.InputStream))//用上传文件的文件流创建上传的图片的实例，
                    //根据上传的图片创建一个Image
                    using (Image img = Image.FromFile(context.Request.MapPath(fullDir)))
                    {
                        using (Bitmap map = new Bitmap(img.Width,img.Height))//根据画布的宽度与高度创建画布
                        {
                            //为画布创建画笔
                            using (Graphics g = Graphics.FromImage(map))
                            {
                                //用画笔在画布上画图，从画布的左上角开始，将整个图片画到画布上
                                g.DrawImage(img,0,0,img.Width,img.Height);
                                g.DrawString("ChinaOl",new Font("宋体",30.0f,FontStyle.Bold),Brushes.Pink,new PointF(map.Width-170,map.Height-50));
                                string waterImageName = "water_" + Guid.NewGuid().ToString();
                                map.Save(context.Request.MapPath("/FileUpload/ImageUpload/"+waterImageName+".jpg"),System.Drawing.Imaging.ImageFormat.Jpeg);
                                context.Response.Write("<html><body><img src='/FileUpload/ImageUpload/" + waterImageName + ".jpg'></body></html>");
                            }
                            
                        }
                    }



                       // context.Response.Write("<html><body><img src='" + fullDir + "'></body></html>");

                   // postFile.SaveAs(context.Request.MapPath("/FileUpload/ImageUpload/"+newFileName+fileExt));
                }
                else
                {
                    context.Response.Write("只能上传图片文件");
                }
            }
            else
            {
                context.Response.Write("请选择文件");
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