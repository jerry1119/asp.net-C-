﻿using System;

namespace RentHouse.DTO
{
    public class HouseAddNewDTO:BaseDTO
    {
        
        public long CommunityId { get; set; }
        
        public long RoomTypeId { get; set; }
       
        public String Address { get; set; }
        public int MonthRent { get; set; }
        public long StatusId { get; set; }
        public decimal Area { get; set; }
        public long DecorateStatusId { get; set; }  //装修状态
        public int TotalFloorCount { get; set; }
        public int FloorIndex { get; set; }
        public long TypeId { get; set; }
        public String Direction { get; set; }
        public DateTime LookableDateTime { get; set; }
        public DateTime CheckInDateTime { get; set; }
        public String OwnerName { get; set; }
        public String OwnerPhoneNum { get; set; }
        public String Description { get; set; }
        public long[] AttachmentIds { get; set; }
        //public String FirstThumbUrl { get; set; }  这个图片位置是算出来的，数据库中没有
    }
}