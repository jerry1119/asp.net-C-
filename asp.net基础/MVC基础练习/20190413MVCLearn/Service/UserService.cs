using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IService;

namespace Service
{
    public class UserService:IUserService
    {
        public IAddNews AddService { get; set; } //属性注入
        public bool UserLogin(string userName, string userPwd)
        {
            AddService.AddNews("123","123");

            return true;
        }

        public bool CheckUserExist(string userName)
        {
            return false;
        }
    }
}
