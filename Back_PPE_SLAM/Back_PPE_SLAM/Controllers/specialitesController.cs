using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Model;
using ORM_PPE_SLAM;

namespace Back_PPE_SLAM.Controllers
{
    public class specialitesController : ApiController
    {
        private data_model db = new data_model();

        // GET: api/specialites
        public IQueryable<specialite> Getspecialites()
        {
            return db.specialites;
        }

        // GET: api/specialites/5
        [ResponseType(typeof(specialite))]
        public async Task<IHttpActionResult> Getspecialite(int id)
        {
            specialite specialite = await db.specialites.FindAsync(id);
            if (specialite == null)
            {
                return NotFound();
            }

            return Ok(specialite);
        }

        // PUT: api/specialites/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putspecialite(int id, specialite specialite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != specialite.id_spe)
            {
                return BadRequest();
            }

            db.Entry(specialite).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!specialiteExists(id))
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

        // POST: api/specialites
        [ResponseType(typeof(specialite))]
        public async Task<IHttpActionResult> Postspecialite(specialite specialite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.specialites.Add(specialite);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = specialite.id_spe }, specialite);
        }

        // DELETE: api/specialites/5
        [ResponseType(typeof(specialite))]
        public async Task<IHttpActionResult> Deletespecialite(int id)
        {
            specialite specialite = await db.specialites.FindAsync(id);
            if (specialite == null)
            {
                return NotFound();
            }

            db.specialites.Remove(specialite);
            await db.SaveChangesAsync();

            return Ok(specialite);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool specialiteExists(int id)
        {
            return db.specialites.Count(e => e.id_spe == id) > 0;
        }
    }
}