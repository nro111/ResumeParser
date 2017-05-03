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
using ExperienceParser.Context;
using ExperienceParser.Models;

namespace ExperienceParser.Controllers.Data
{
    public class CertificationsController : ApiController
    {
        private CertificationsContext db = new CertificationsContext();

        // GET: api/Certifications
        public IQueryable<Certifications> GetCertifications()
        {
            return db.Certifications;
        }

        // GET: api/Certifications/5
        [ResponseType(typeof(Certifications))]
        public IHttpActionResult GetCertifications(int id)
        {
            Certifications certifications = db.Certifications.Find(id);
            if (certifications == null)
            {
                return NotFound();
            }

            return Ok(certifications);
        }

        // PUT: api/Certifications/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCertifications(int id, Certifications certifications)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != certifications.CertificationID)
            {
                return BadRequest();
            }

            db.Entry(certifications).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CertificationsExists(id))
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

        // POST: api/Certifications
        [ResponseType(typeof(Certifications))]
        public IHttpActionResult PostCertifications(Certifications certifications)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Certifications.Add(certifications);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = certifications.CertificationID }, certifications);
        }

        // DELETE: api/Certifications/5
        [ResponseType(typeof(Certifications))]
        public IHttpActionResult DeleteCertifications(int id)
        {
            Certifications certifications = db.Certifications.Find(id);
            if (certifications == null)
            {
                return NotFound();
            }

            db.Certifications.Remove(certifications);
            db.SaveChanges();

            return Ok(certifications);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CertificationsExists(int id)
        {
            return db.Certifications.Count(e => e.CertificationID == id) > 0;
        }
    }
}