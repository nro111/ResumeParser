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
    public class DegreesController : ApiController
    {
        private readonly DegreesContext db = new DegreesContext();

        // GET: api/Degrees
        public IQueryable<Degrees> GetDegrees()
        {
            return db.Degrees;
        }

        // GET: api/Degrees/5
        [ResponseType(typeof(Degrees))]
        public IHttpActionResult GetDegrees(int id)
        {
            Degrees degrees = db.Degrees.Find(id);
            if (degrees == null)
            {
                return NotFound();
            }

            return Ok(degrees);
        }

        // PUT: api/Degrees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDegrees(int id, Degrees degrees)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != degrees.DegreeID)
            {
                return BadRequest();
            }

            db.Entry(degrees).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DegreesExists(id))
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

        // POST: api/Degrees
        [ResponseType(typeof(Degrees))]
        public IHttpActionResult PostDegrees(Degrees degrees)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Degrees.Add(degrees);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = degrees.DegreeID }, degrees);
        }

        // DELETE: api/Degrees/5
        [ResponseType(typeof(Degrees))]
        public IHttpActionResult DeleteDegrees(int id)
        {
            Degrees degrees = db.Degrees.Find(id);
            if (degrees == null)
            {
                return NotFound();
            }

            db.Degrees.Remove(degrees);
            db.SaveChanges();

            return Ok(degrees);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DegreesExists(int id)
        {
            return db.Degrees.Count(e => e.DegreeID == id) > 0;
        }
    }
}