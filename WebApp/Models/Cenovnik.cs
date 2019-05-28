using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Cenovnik
    {
        public DateTime Datum_Pocetak { get; set; }
        public DateTime Datum_Kraj { get; set; }
        public int Id { get; set; }
        public bool IsActive { get; set; }

    }
}