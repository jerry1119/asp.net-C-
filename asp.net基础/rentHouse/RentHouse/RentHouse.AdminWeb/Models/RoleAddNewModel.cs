using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentHouse.AdminWeb.Models
{
    public class RoleAddNewModel
    {
        [Required]
        [StringLength(15)]
        public string Name { get; set; }
        public long []  PermissionIds { get; set; }
    }
}