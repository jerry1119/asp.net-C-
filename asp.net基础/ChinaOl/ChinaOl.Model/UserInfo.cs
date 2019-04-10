using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinaOl.Model
{
   public class UserInfo
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public string Email { get; set; }
        public DateTime RegTime { get; set; }
    }
}
