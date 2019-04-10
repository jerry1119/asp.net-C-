using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 日记demo
{
    class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Pwd { get; set; }
        public override string ToString()
        {
            return this.UserName;
        }
    }
}
