using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IService
{
    public interface IUserService
    {
        bool UserLogin(string userName, string userPwd);
        bool CheckUserExist(string userName);
    }
}
