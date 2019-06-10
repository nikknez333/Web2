﻿using System;
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

        // GET: api/Kartas/5
        [ResponseType(typeof(Karta))]
        public IHttpActionResult GetKarta(int id)
        {
            Karta karta = db.Karte.Find(id);
            if (karta == null)
            {
                return NotFound();
            }

            return Ok(karta);
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