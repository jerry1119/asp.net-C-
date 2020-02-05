using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using RentHouse.DTO;

namespace RentHouse.AdminWeb.Models
{
    public class AdminUserEditGetModel
    {
        public AdminUserDTO User { get; set; }
        public CityDTO[] Cities { get; set; }
        public RoleDTO[] AllRoles { get; set; }
        public RoleDTO[] UserRoles { get; set; }
    }
}