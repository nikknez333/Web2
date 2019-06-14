﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class TipPutnika
    {
        public int Sifra { get; set; }

        [Key]
        public string Naziv { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }
    }
}