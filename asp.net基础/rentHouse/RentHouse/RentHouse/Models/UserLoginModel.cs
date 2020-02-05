using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentHouse.Models
{
    public class UserLoginModel
    {
        [Required]
        [Phone]
        public string PhoneNum { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}