using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models.Gradski_Saobracaj
{
    public class Stanica
    {
        public string Adresa { get; set; }

        public double Lat { get; set; }
        public double Lon { get; set; }

        public int Id { get; set; }

        public string Naziv { get; set; }

        public List<Linija> Linije { get; set; }
    }
}