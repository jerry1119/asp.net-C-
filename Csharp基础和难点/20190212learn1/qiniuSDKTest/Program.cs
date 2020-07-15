using Qiniu.Http;
using Qiniu.Storage;
using Qiniu.Util;
using System;

namespace qiniuSDKTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string AccessKey = "nDdaH3SGk5NXCyQ8eZMsnRTApJndj0fOKy_f6Lix";
            string SecretKey = "HgxcM58TEplyx6H9CBJTbYDqpF4uXAKsiBp-W6u4";
            Mac mac = new Mac(AccessKey, SecretKey);
            // 上传文件名
            string key = "fg.jpg";
            // 本地文件路径
            string filePath = "D:\\fgnb.jpg";
            // 存储空间名
            string Bucket = "renthouse2019";
            // 设置上传策略，详见：https://developer.qiniu.com/kodo/manual/1206/put-policy
            PutPolicy putPolicy = new PutPolicy();
            // 设置要上传的目标空间
            putPolicy.Scope = Bucket;
            // 上传策略的过期时间(单位:秒)
            putPolicy.SetExpires(3600);
            // 文件上传完毕后，在多少天后自动被删除
            putPolicy.DeleteAfterDays = 1;
            //putPolicy.SaveKey = "fg1.jpg";
            // 生成上传token
            string token = Auth.CreateUploadToken(mac, putPolicy.ToJsonString());
            Config config = new Config();
            // 设置上传区域
            config.Zone = Zone.ZONE_CN_South;
            // 设置 http 或者 https 上传
            config.UseHttps = true;
            config.UseCdnDomains = true;
            config.ChunkSize = ChunkUnit.U512K;
            // 表单上传
            FormUploader target = new FormUploader(config);
            HttpResult result = target.UploadFile(filePath, key, token, null);
            Console.WriteLine("form upload result: " + result.ToString());

            //UploadManager um = new UploadManager(config);
            //HttpResult result2 = um.UploadFile(filePath, key, token, null);
            //Console.WriteLine("form upload result: " + result2.ToString());
            Console.ReadKey();
        }
    }
}
