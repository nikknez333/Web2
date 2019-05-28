using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Gradski_Saobracaj
{
    public class Linija
    {
        public int Id { get; set; }

        public string RedniBroj { get; set; }

        public List<Stanica> Stanice { get; set; }
    }
}