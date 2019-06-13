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
    class ResponseData
    {
        public List<string> Linije { get; set; }
        public List<string> Dani { get; set; }
        public List<string> Saobracaji { get; set; }
    }


    [Authorize(Roles = "Admin")]
    public class RedVoznjesController : ApiController
    {
        private readonly IRedoviVoznjeRepository _repo;
        private readonly IUnitOfWork _unit;

        public RedVoznjesController(IRedoviVoznjeRepository repo, IUnitOfWork unit)
        {
            _repo = repo;
            _unit = unit;
        }


        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: api/RedVoznjes
        [AllowAnonymous]
  
        public IHttpActionResult GetRedVoznjeString()
        {
            ResponseData responseData = new ResponseData();

            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                var linijeList = ctx.Linije.ToArray();
                var daniList = ctx.TipoviDana.ToList();
                var saobList = ctx.TipoviSaobracaja.ToList();
                

                responseData.Linije = linijeList.Select(s => s.RedniBroj).ToList();
                responseData.Saobracaji = saobList.Select(s => s.Naziv).ToList();
                responseData.Dani = daniList.Select(s => s.Naziv).ToList();
            }
                

            return Ok(responseData);
        }

        [Route("RedVoznjes/AllRedoviVoznje")]
        public IQueryable<RedVoznje> GetAllRedoviVoznji()
        {
            return db.RedoviVoznji.Include(lin => lin.IzabranaLinija).Include(dan => dan.IzabranTipDana).Include(sao => sao.IzabranTipSaobracaja);
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
        //[Authorize(Roles ="Administrators")]
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


        [AllowAnonymous]
        [ResponseType(typeof(RedVoznje))]
        public string[] GetRedVoznje(string linija, string dan, string saobracaj)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
                return null;
            }

            List<RedVoznje> redVoznjes = _repo.Find(x => x.IzabranaLinija.RedniBroj.ToLower() == linija.ToLower() &&
                                   x.IzabranTipDana.Naziv.ToLower() == dan.ToLower() &&
                                   x.IzabranTipSaobracaja.Naziv.ToLower() == saobracaj.ToLower()).ToList();

            string[] polasci = new string[redVoznjes.Count];
            for (int i = 0; i < redVoznjes.Count; i++)
            {
                polasci[i] = (redVoznjes[i] as RedVoznje).Polazak.ToShortTimeString();
            }

            return polasci;
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
            RedVoznje redVoznje = db.RedoviVoznji.Include(x=>x.IzabranaLinija).Include(x=>x.IzabranTipDana).Include(x=>x.IzabranTipSaobracaja).FirstOrDefault(x => x.Id.Equals(id)); //_repo.Get(id);
            if (redVoznje == null)
            {
                return NotFound();
            }

            //_repo.Remove(redVoznje);
            //_unit.Complete();
            db.RedoviVoznji.Remove(redVoznje);
            db.SaveChanges();

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