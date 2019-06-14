using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models.Gradski_Saobracaj
{
    public class RedVoznje
    {
        public DateTime Polazak { get; set; }

        public int Id { get; set; }

        public Linija IzabranaLinija { get; set; }

        public TipSaobracaja IzabranTipSaobracaja { get; set; }

        public TipDana IzabranTipDana { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }
    }
}