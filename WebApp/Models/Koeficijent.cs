using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Koeficijent
    {
        public int Id { get; set; }

        public string Naziv { get; set; }

        public double Value { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }
    }
}