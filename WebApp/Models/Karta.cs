using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Karta
    {
        public int Id { get; set; }

        public DateTime VremeKupovine { get; set; }

        public CenaStavke CenaStavke { get; set; }

        public Korisnik Kupac { get; set; }

        public double Cena { get; set; }
    }

}