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
    public class CenaStavkesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/CenaStavkes
        public IQueryable<CenaStavke> GetCeneStavki()
        {
            return db.CeneStavki.Include(cenn => cenn.Cenovnik).Include(svk => svk.Stavka);
        }

        // GET: api/CenaStavkes/5
        [ResponseType(typeof(CenaStavke))]
        public IHttpActionResult GetCenaStavke(int id)
        {
            CenaStavke cenaStavke = db.CeneStavki.Find(id);
            if (cenaStavke == null)
            {
                return NotFound();
            }

            return Ok(cenaStavke);
        }

        // PUT: api/CenaStavkes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCenaStavke(int id, CenaStavke cenaStavke)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cenaStavke.Id)
            {
                return BadRequest();
            }

            db.Entry(cenaStavke).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CenaStavkeExists(id))
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

        public class CenaStavkeWrapper
        {
            public int CenovnikID { get; set; }
            public int StavkaID { get; set; }
            public double Cena { get; set; }
        }

        // POST: api/CenaStavkes
        [ResponseType(typeof(CenaStavke))]
        public IHttpActionResult PostCenaStavke(CenaStavkeWrapper cenaStavkeWrapper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CenaStavke cs = new CenaStavke()
            {
                Cena = cenaStavkeWrapper.Cena,
                Cenovnik = db.Cenovnici.Find(cenaStavkeWrapper.CenovnikID),
                Stavka = db.Stavke.Find(cenaStavkeWrapper.StavkaID),
            };

            db.CeneStavki.Add(cs);
            db.SaveChanges();

            // return CreatedAtRoute("DefaultApi", new { id = cenaStavke.Id }, cenaStavke);
            return Ok();
        }

        // DELETE: api/CenaStavkes/5
        [ResponseType(typeof(CenaStavke))]
        public IHttpActionResult DeleteCenaStavke(int id)
        {
            CenaStavke cenaStavke = db.CeneStavki.Find(id);
            if (cenaStavke == null)
            {
                return NotFound();
            }

            db.CeneStavki.Remove(cenaStavke);
            db.SaveChanges();

            return Ok(cenaStavke);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CenaStavkeExists(int id)
        {
            return db.CeneStavki.Count(e => e.Id == id) > 0;
        }
    }
}