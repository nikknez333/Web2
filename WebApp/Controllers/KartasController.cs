using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApp.Models;
using WebApp.Persistence;

namespace WebApp.Controllers
{
    public class KartasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Kartas
        public IQueryable<Karta> GetKarte()
        {
            return db.Karte;
        }

        [Authorize(Roles ="Controller")]
        // GET: api/Kartas/5
        [ResponseType(typeof(bool))]
        public IHttpActionResult GetKarta(int id)
        {
            
            Karta karta = db.Karte.Include(x => x.CenaStavke.Stavka).FirstOrDefault(x => x.Id == id);
            //Karta kartaDrugi = 
            if (karta == null)
            {
                return NotFound();
            }



            int tipKarte = karta.CenaStavke.Stavka.Id;
            bool isValid = false;

            //validate karta
            switch (tipKarte)
            {                
                case 1: //vremenska
                    if (DateTime.Now <= karta.VremeKupovine.AddHours(1))
                        isValid = true;
                    break;

                case 2: //dnevna
                    if (DateTime.Now <= karta.VremeKupovine.AddDays(1))
                        isValid = true;
                    break;

                case 3: //mesecna
                    if (DateTime.Now <= karta.VremeKupovine.AddMonths(1))
                        isValid = true;
                    break;

                case 4: //godisnja
                    if (DateTime.Now <= karta.VremeKupovine.AddYears(1))
                        isValid = true;
                    break;

                default:
                    isValid = false;
                    break;
            }

            return Ok(isValid);
        }

        // PUT: api/Kartas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKarta(int id, Karta karta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != karta.Id)
            {
                return BadRequest();
            }

            db.Entry(karta).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KartaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Kartas

        [ResponseType(typeof(void))]
        //[ResponseType(typeof(Karta))]
        public IHttpActionResult PostKarta(int stavkaId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(stavkaId != 1 && User.Identity.Name == null)
            {
                return Unauthorized();
            }

            var aktivanCenovnik = db.Cenovnici.FirstOrDefault(cen => cen.IsActive == true);

            Karta karta = new Karta();
            karta.VremeKupovine = DateTime.Now;
            karta.CenaStavke = db.CeneStavki.FirstOrDefault(stv => stv.Id == stavkaId && stv.Cenovnik.Id == aktivanCenovnik.Id);
            karta.Kupac = db.Korisnici.FirstOrDefault(kor => kor.Email == User.Identity.Name);


            double cenaKarte = karta.CenaStavke.Cena;
            var kors = db.Putnici.Include(x => x.TipPutnika).FirstOrDefault(x => x.Korisnik.Email.Equals(karta.Kupac.Email));

            string tipPutnika = kors.TipPutnika.Naziv;

            if (tipPutnika != "Regularni")
            {
                //kartu je kupio neko od povlascenih korisnika
                //proveri da li je verifikovan status i primeni popust
                if(karta.Kupac.IsVerified)
                {
                    double popustKoef = db.Koeficijenti.FirstOrDefault(x => x.Naziv.Equals(tipPutnika)).Value;
                    cenaKarte *= popustKoef;
                }                    
            }
            karta.Cena = cenaKarte;
            

            db.Karte.Add(karta);
            db.SaveChanges();

            //return CreatedAtRoute("DefaultApi", new { id = karta.Id }, karta);
            return Ok();
        }

        // DELETE: api/Kartas/5
        [ResponseType(typeof(Karta))]
        public IHttpActionResult DeleteKarta(int id)
        {
            Karta karta = db.Karte.Find(id);
            if (karta == null)
            {
                return NotFound();
            }

            db.Karte.Remove(karta);
            db.SaveChanges();

            return Ok(karta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KartaExists(int id)
        {
            return db.Karte.Count(e => e.Id == id) > 0;
        }
    }
}