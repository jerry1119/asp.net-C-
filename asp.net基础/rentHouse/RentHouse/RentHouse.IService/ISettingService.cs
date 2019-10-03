using RentHouse.DTO;

namespace RentHouse.IService
{
    public interface ISettingService:IServiceMark
    {
        //设置配置项name的值为value
        void SetValue(string name,string value);//SetValue("SmtpServer","smtp.qq.com")
        string GetValue(string name);//GetValue("SmtpServer")

        void SetIntValue(string name, int value);//SetIntValue(" 秒数",5);
        int? GetIntValue(string name);

        void SetBoolValue(string name, bool value);
        bool? GetBoolValue(string name);

        SettingDTO[] GetAll();
    }
}