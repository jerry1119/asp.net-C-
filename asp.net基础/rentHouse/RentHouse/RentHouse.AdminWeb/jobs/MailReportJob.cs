using Autofac;
using Autofac.Integration.Mvc;
using log4net;
using Quartz;
using RentHouse.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RentHouse.AdminWeb.jobs
{
    public class MailReportJob : IJob
    {
        private static ILog log = LogManager.GetLogger(typeof(MailReportJob));
        public Task Execute(IJobExecutionContext context)
        {
            return Task.Factory.StartNew(() =>
            {
                try
                {
                    log.Info("准备收集新增房源信息");
                    var container = AutofacDependencyResolver.Current.ApplicationContainer;
                    using (container.BeginLifetimeScope())
                    {
                        StringBuilder sb = new StringBuilder();
                        var cityService = container.Resolve<ICityService>();
                        var houseService = container.Resolve<IHouseService>();
                        var settingService = container.Resolve<ISettingService>();
                        var cities = cityService.GetAll();
                        foreach (var city in cities)
                        {
                            var count = houseService.GetTodayNewHouseCount(city.Id);
                            sb.Append(city.Name).Append("   今天新增房源: ").Append(count).AppendLine(" 套");
                        }
                        log.Info("收集新增房源数量完成 "+sb.ToString());
                        var receiveMails = settingService.GetValue("邮箱定时任务收件人");
                        var smtpServer = settingService.GetValue("qq邮箱smtpServer");
                        var smtpUserName = settingService.GetValue("qq邮箱smtpUserName");
                        var smtpPwd = settingService.GetValue("qq邮箱客户端授权码");
                        var smtpUserMail = settingService.GetValue("qq邮箱发送人邮箱");
                        //要使用System.Net.Mail下的类，不要用System.Web.Mail下的类
                        using (MailMessage mailMessage = new MailMessage())
                        //这些配置信息可能会更改，所以应该存到数据库 setting表，方便读取和更改，类似winform的.ini文件的功能
                        using (SmtpClient smtpClient = new SmtpClient("smtp.qq.com"))
                        {
                            foreach (var mail in receiveMails.Split(';'))
                            {
                                mailMessage.To.Add(mail);//收信人
                            }
                            mailMessage.Body = sb.ToString(); //邮件正文
                            mailMessage.From = new MailAddress(smtpUserMail); //发送邮箱
                            mailMessage.Subject = "发送邮件测试";
                            smtpClient.Credentials = new System.Net.NetworkCredential(smtpUserName, smtpPwd);//如果启用了“客户端授权码”，要用授权码代替密码  
                            smtpClient.Send(mailMessage);
                        }
                    }
                    log.Info("发送邮件完成");
                }
                catch (Exception ex)
                {
                    log.Error("定时发邮件任务出错", ex);
                }
            });
        }
    }
}