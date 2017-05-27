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
    public class ApplicantsController : ApiController
    {
        private readonly ApplicantContext db = new ApplicantContext();

        // GET: api/Applicants
        public IQueryable<AppUser> GetApplicants()
        {
            return db.Applicants;
        }

        // GET: api/Applicants/5
        [ResponseType(typeof(AppUser))]
        public IHttpActionResult GetApplicant(int id)
        {
            AppUser applicant = db.Applicants.Find(id);
            if (applicant == null)
            {
                return NotFound();
            }

            return Ok(applicant);
        }

        // PUT: api/Applicants/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutApplicant(int id, AppUser applicant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != applicant.ApplicantID)
            {
                return BadRequest();
            }

            db.Entry(applicant).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicantExists(id))
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

        // POST: api/Applicants
        [ResponseType(typeof(AppUser))]
        public IHttpActionResult PostApplicant(AppUser applicant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Applicants.Add(applicant);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = applicant.ApplicantID }, applicant);
        }

        // DELETE: api/Applicants/5
        [ResponseType(typeof(AppUser))]
        public IHttpActionResult DeleteApplicant(int id)
        {
            AppUser applicant = db.Applicants.Find(id);
            if (applicant == null)
            {
                return NotFound();
            }

            db.Applicants.Remove(applicant);
            db.SaveChanges();

            return Ok(applicant);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApplicantExists(int id)
        {
            return db.Applicants.Count(e => e.ApplicantID == id) > 0;
        }
    }
}