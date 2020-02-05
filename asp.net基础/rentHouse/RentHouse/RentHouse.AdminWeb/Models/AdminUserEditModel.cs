using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentHouse.AdminWeb.Models
{
    public class AdminUserEditModel
    {
        [Required]
        public String Name { get; set; }
        [Required]
        public String PhoneNum { get; set; }
        [Required]
        public string PassWord { get; set; }
        [Required]
        public String Email { get; set; }

        public long[] RoleIds { get; set; }
        public long? CityId { get; set; }
    }
}