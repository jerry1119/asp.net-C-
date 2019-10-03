using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentHouse.DTO
{
    /// <summary>
    /// 数据字典表
    /// </summary>
    public class IdNameDTO : BaseDTO
    {
        public String Name { get; set; }
        public String TypeName { get; set; }
    }
}
