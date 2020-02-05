using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RentHouse.DTO;

namespace RentHouse.AdminWeb.Models
{
    public class AdminUserAddNewGetModel
    {
        public CityDTO[] Cities { get; set; }
        public RoleDTO[] Roles { get; set; }
    }
}