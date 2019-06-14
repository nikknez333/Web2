using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Korisnik
    {
        //public int Id { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        [Key]
        public string Email { get; set; }

        public DateTime DatumRodjenja { get; set; }

        public string Adresa { get; set; }

        public string Password { get; set; }

        public bool IsVerified { get; set; } = false;

        public List<Karta> KupljenjeKarte { get; set; }

        public Rola Rola { get; set; }

        public string Status { get; set; }
        public string ImageUrl { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }
    }

}