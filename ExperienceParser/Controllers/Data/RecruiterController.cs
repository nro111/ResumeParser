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
    public class RecruiterController : ApiController
    {
        private readonly RecruiterContext db = new RecruiterContext();

        // GET: api/Recruiters
        public IQueryable<AppUser> GetRecruiters()
        {
            return db.Recruiters;
        }

        // GET: api/Recruiters/5
        [ResponseType(typeof(AppUser))]
        public IHttpActionResult GetRecruiter(int id)
        {
            AppUser recruiter = db.Recruiters.Find(id);
            if (recruiter == null)
            {
                return NotFound();
            }

            return Ok(recruiter);
        }

        // PUT: api/Recruiters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRecruiter(int id, AppUser recruiter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recruiter.ID)
            {
                return BadRequest();
            }

            db.Entry(recruiter).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecruiterExists(id))
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

        // POST: api/Recruiters
        [ResponseType(typeof(AppUser))]
        public IHttpActionResult PostRecruiter(AppUser recruiter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Recruiters.Add(recruiter);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = recruiter.ID }, recruiter);
        }

        // DELETE: api/Recruiters/5
        [ResponseType(typeof(AppUser))]
        public IHttpActionResult DeleteRecruiter(int id)
        {
            AppUser recruiter = db.Recruiters.Find(id);
            if (recruiter == null)
            {
                return NotFound();
            }

            db.Recruiters.Remove(recruiter);
            db.SaveChanges();

            return Ok(recruiter);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecruiterExists(int id)
        {
            return db.Recruiters.Count(e => e.ID == id) > 0;
        }
    }
}