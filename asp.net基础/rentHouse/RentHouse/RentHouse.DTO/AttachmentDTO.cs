using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentHouse.DTO
{
    /// <summary>
    /// 房屋设施
    /// </summary>
    public class AttachmentDTO : BaseDTO
    {
        public String Name { get; set; }
        public String IconName { get; set; }
    }
}
