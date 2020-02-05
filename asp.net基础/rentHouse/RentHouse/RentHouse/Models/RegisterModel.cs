using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentHouse.Models
{
    public class RegisterModel
    {
        [Required]
        [StringLength(11)]
        public string PhoneNum { get; set; }

        public string SmsCode { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        public string Password2 { get; set; }
    }
}