using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RentHouse.DTO;

namespace RentHouse.Models
{
    public class HouseIndexModel
    {
        public HouseDTO House { get; set; }
        public AttachmentDTO[] Attachments { get; set; }
        public HousePicDTO[] HousePics { get; set; }
    }
}