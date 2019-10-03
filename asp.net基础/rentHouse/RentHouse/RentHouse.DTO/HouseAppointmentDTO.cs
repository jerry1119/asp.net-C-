using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentHouse.DTO
{
    /// <summary>
    /// 租房预约
    /// </summary>
    public class HouseAppointmentDTO : BaseDTO
    {
        public long? UserId { get; set; }
        public String Name { get; set; }
        public String PhoneNum { get; set; }
        public DateTime VisitDate { get; set; }
        public long HouseId { get; set; }
        public String Status { get; set; }
        public long? FollowAdminUserId { get; set; }
        public String FollowAdminUserName { get; set; }
        public DateTime? FollowDateTime { get; set; }
        public String RegionName { get; set; }
        public String CommunityName { get; set; }
        //这个给忘了，只能直接去改数据库了,不对，这个是DTO，没有影响，跟数据库没关系
        public String HouseAddress { get; set; }
    }
}
