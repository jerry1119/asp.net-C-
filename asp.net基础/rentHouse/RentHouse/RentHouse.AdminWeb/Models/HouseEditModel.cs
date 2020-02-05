using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentHouse.AdminWeb.Models
{
    public class HouseEditModel
    {
        public long HouseId { get; set; }
        public long CommunityId { get; set; }
        public long RoomTypeId { get; set; }
        public string Address { get; set; }
        public int MonthRent { get; set; }
        public long DecorateStatusId { get; set; } //DecorateStatusId
        public decimal Area { get; set; }  //房屋面积
        public long StatusId { get; set; }
        public int TotalFloorCount { get; set; }
        public int FloorIndex { get; set; }
        public String Direction { get; set; }
        public DateTime LookableDateTime { get; set; }
        public DateTime CheckInDateTime { get; set; }
        public String OwnerName { get; set; }
        public String OwnerPhoneNum { get; set; }
        public String Description { get; set; }
        public long[] AttachmentIds { get; set; }
        public long TypeId { get; set; }
    }
}