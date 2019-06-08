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
    [Authorize(Roles = "Controller")]
    public class RegistrationStatusController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/RegistrationStatus
        
        public IQueryable<RegistrationStatus> GetRegistrationStatuses()
        {
            return db.RegistrationStatuses.Where(x => x.Status.Equals("Expecting verification"));
        }

        // GET: api/RegistrationStatus/5
        [ResponseType(typeof(RegistrationStatus))]
        public IHttpActionResult GetRegistrationStatus(string id)
        {
            RegistrationStatus registrationStatus = db.RegistrationStatuses.Find(id);
            if (registrationStatus == null)
            {
                return NotFound();
            }

            return Ok(registrationStatus);
        }

        // PUT: api/RegistrationStatus/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRegistrationStatus(string id/*, RegistrationStatus registrationStatus*/)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if (id != registrationStatus.UserEmail)
            //{
            //    return BadRequest();
            //}
            var account = db.RegistrationStatuses.FirstOrDefault(x => x.UserEmail.Equals(id));
            if (account == null)
                return NotFound();

            account.Status = "Verified";
            db.Entry(account).State = EntityState.Modified;

            //db.Entry(registrationStatus).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistrationStatusExists(id))
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

        // POST: api/RegistrationStatus
        [ResponseType(typeof(RegistrationStatus))]
        public IHttpActionResult PostRegistrationStatus(RegistrationStatus registrationStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RegistrationStatuses.Add(registrationStatus);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RegistrationStatusExists(registrationStatus.UserEmail))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = registrationStatus.UserEmail }, registrationStatus);
        }

        // DELETE: api/RegistrationStatus/5
        [ResponseType(typeof(RegistrationStatus))]
        public IHttpActionResult DeleteRegistrationStatus(string id)
        {
            RegistrationStatus registrationStatus = db.RegistrationStatuses.Find(id);
            if (registrationStatus == null)
            {
                return NotFound();
            }

            db.RegistrationStatuses.Remove(registrationStatus);
            db.SaveChanges();

            return Ok(registrationStatus);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RegistrationStatusExists(string id)
        {
            return db.RegistrationStatuses.Count(e => e.UserEmail == id) > 0;
        }
    }
}