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
using ExperienceParser;
using ExperienceParser.Context;

namespace ExperienceParser.Controllers.Data
{
    public class SkillsController : ApiController
    {
        private SkillsContext db = new SkillsContext();

        // GET: api/Skills
        public IQueryable<Skills> GetSkills()
        {
            return db.Skills;
        }

        // GET: api/Skills/5
        [ResponseType(typeof(Skills))]
        public IHttpActionResult GetSkills(int id)
        {
            Skills skills = db.Skills.Find(id);
            if (skills == null)
            {
                return NotFound();
            }

            return Ok(skills);
        }

        // PUT: api/Skills/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSkills(int id, Skills skills)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != skills.SkillID)
            {
                return BadRequest();
            }

            db.Entry(skills).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkillsExists(id))
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

        // POST: api/Skills
        [ResponseType(typeof(Skills))]
        public IHttpActionResult PostSkills(Skills skills)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Skills.Add(skills);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = skills.SkillID }, skills);
        }

        // DELETE: api/Skills/5
        [ResponseType(typeof(Skills))]
        public IHttpActionResult DeleteSkills(int id)
        {
            Skills skills = db.Skills.Find(id);
            if (skills == null)
            {
                return NotFound();
            }

            db.Skills.Remove(skills);
            db.SaveChanges();

            return Ok(skills);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SkillsExists(int id)
        {
            return db.Skills.Count(e => e.SkillID == id) > 0;
        }
    }
}