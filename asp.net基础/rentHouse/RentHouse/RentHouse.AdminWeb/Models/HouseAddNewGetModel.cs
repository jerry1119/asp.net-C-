using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RentHouse.DTO;

namespace RentHouse.AdminWeb.Models
{
    public class HouseAddNewGetModel
    {
        public RegionDTO[] Regions { get; set; } //区域
        public IdNameDTO[] RoomTypes { get; set; } //房型
        public IdNameDTO[] Status { get; set; } //状态
        public IdNameDTO[] DecorateStatus { get; set; } //装修状态
        public AttachmentDTO[] Attachments { get; set; } //配置设施
        public IdNameDTO[] Types { get; set; }   //出租类别
    }
}