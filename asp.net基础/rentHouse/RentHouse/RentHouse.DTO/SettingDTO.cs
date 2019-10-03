using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentHouse.DTO
{
    /// <summary>
    /// 配置表，比如存配置smtp服务器的用户名，密码
    /// </summary>
    public class SettingDTO : BaseDTO
    {
        public String Name { set; get; }
        public String Value { set; get; }
    }
}
