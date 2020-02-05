using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentHouse.AdminWeb.Models
{
    public class PermissionEditModel
    {
        public long id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}