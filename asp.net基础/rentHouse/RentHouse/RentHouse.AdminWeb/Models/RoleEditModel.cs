using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentHouse.AdminWeb.Models
{
    public class RoleEditModel
    {
        public long  Id { get; set; }
        public long [] PermissionIds { get; set; }
        public string Name { get; set; }
    }
}