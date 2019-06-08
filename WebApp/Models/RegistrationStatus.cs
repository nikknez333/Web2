using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class RegistrationStatus
    {
        [Key]
        public string UserEmail { get; set; }
        public string ImageUrl { get; set; }
        public string Status { get; set; }
    }
}