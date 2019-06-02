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
using WebApp.Models.Gradski_Saobracaj;
using WebApp.Persistence;
using WebApp.Persistence.Repository;
using WebApp.Persistence.UnitOfWork;

namespace WebApp.Controllers
{
    public class RedVoznjesController : ApiController
    {
        private readonly IRedoviVoznjeRepository _repo;
        private readonly IUnitOfWork _unit;

        public RedVoznjesController(IRedoviVoznjeRepository repo, IUnitOfWork unit)
        {
            _repo = repo;
            _unit = unit;
        }
        // GET: api/RedVoznjes
        //public IEnumerable<RedVoznje> GetRedVoznjes()
        //{
        //    return _repo.GetAll();
        //}

        public string[] GetRedVoznjeString()
        {            
            List<RedVoznje> redVoznje = _repo.GetAll().ToList();
            string[] polasci = new string[redVoznje.Count];


            for (int i = 0; i < redVoznje.Count; i++)
            {
                polasci[i] = (redVoznje[i] as RedVoznje).Polazak.ToShortTimeString();
            }

            return polasci;
        }

        // GET: api/RedVoznjes/5
        [ResponseType(typeof(RedVoznje))]
        public IHttpActionResult GetRedVoznjeById(int id)
        {
            RedVoznje redVoznje = _repo.Get(id);
            if (redVoznje == null)
            {
                return NotFound();
            }

            return Ok(redVoznje);
        }

        // PUT: api/RedVoznjes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRedVoznje(int id, RedVoznje redVoznje)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != redVoznje.Id)
            {
                return BadRequest();
            }

            _repo.Update(redVoznje);

            try
            {
                _unit.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RedVoznjeExists(id))
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

        [ResponseType(typeof(RedVoznje))]
        public IEnumerable<RedVoznje> GetRedVoznje(int idLinija, int idDan, int idSaobracaj)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
            }

            return _repo.Find(x => x.IzabranaLinija.Id == idLinija && x.IzabranTipDana.Id == idDan && x.IzabranTipSaobracaja.Id == idSaobracaj);
            

            //return CreatedAtRoute("DefaultApi", new { id = redVoznje.Id }, redVoznje);
        }

        // POST: api/RedVoznjes
        [ResponseType(typeof(RedVoznje))]
        public IHttpActionResult PostRedVoznje(RedVoznje redVoznje)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repo.Add(redVoznje);
            _unit.Complete();

            return CreatedAtRoute("DefaultApi", new { id = redVoznje.Id }, redVoznje);
        }

        // DELETE: api/RedVoznjes/5
        [ResponseType(typeof(RedVoznje))]
        public IHttpActionResult DeleteRedVoznje(int id)
        {
            RedVoznje redVoznje = _repo.Get(id);
            if (redVoznje == null)
            {
                return NotFound();
            }

            _repo.Remove(redVoznje);
            _unit.Complete();

            return Ok(redVoznje);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unit.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RedVoznjeExists(int id)
        {
            return _repo.Find(e => e.Id == id).Count() > 0;
        }
    }
}