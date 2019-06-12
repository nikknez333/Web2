using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
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
        public IHttpActionResult PutRegistrationStatus(string id, RegistrationStatus registrationStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var account = db.RegistrationStatuses.FirstOrDefault(x => x.UserEmail.Equals(id));
            if (account == null)
                return NotFound();

            account.Status = registrationStatus.Status;
            db.Entry(account).State = EntityState.Modified;

            Korisnik user = db.Korisnici.FirstOrDefault(x => x.Email.Equals(id));
            if (registrationStatus.Status.Equals("Potvrdjen"))
            {
                user.IsVerified = true;
            }
            else
            {
                user.IsVerified = false;
            }
            user.Status = registrationStatus.Status;
            //user.ImageUrl = registrationStatus.ImageUrl;

            db.Entry(user).State = EntityState.Modified;
            
            

            //db.Entry(registrationStatus).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
                //sendEmailNotification(account, user.Ime+" "+user.Prezime);
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

        private async void sendEmailNotification(RegistrationStatus rs, string fullName)
        {
            var fromAddress = new MailAddress("apartmanbranislava@gmail.com", "Autobusi NS");
            var toAddress = new MailAddress(rs.UserEmail, fullName);
            const string fromPassword = "AWjBkfVXyovOQ48k";
            const string subject = "Account status changed";
            string body = string.Format("Dear {0}, \nWe inform you that the status of your account has been changed to: {1}.\n\nBest Wishes, AutobusiNS", fullName, rs.Status); 

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                await smtp.SendMailAsync(message);
            }
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