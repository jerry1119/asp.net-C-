using RentHouse.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentHouse.Models
{
    public class HouseSearchViewModel
    {
        public RegionDTO[] Regions { get; set; }
        public HouseDTO[] Houses { get; set; }
    }
}