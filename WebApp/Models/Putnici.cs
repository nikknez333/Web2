using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Putnici
    {
        public int Id { get; set; }

        public TipPutnika TipPutnika { get; set; }

        public Korisnik Korisnik { get; set; }

    }
}