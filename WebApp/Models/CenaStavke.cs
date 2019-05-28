using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class CenaStavke
    {
        public double Cena { get; set; }
        public int Id { get; set; }

        public Cenovnik Cenovnik { get; set; }

        public Stavka Stavka { get; set; }
    }
}