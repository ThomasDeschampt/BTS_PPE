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
    public class medecinsController : ApiController
    {
        private data_model db = new data_model();

        // GET: api/medecins
        // en utilsant l'authentification avec le token
        [Authentification]
        public IQueryable<medecin> Getmedecins()
        {
            return db.medecins;
        }

        // GET: api/medecins/5
        [Authentification]
        [ResponseType(typeof(medecin))]
        public async Task<IHttpActionResult> Getmedecin(int id)
        {
            medecin medecin = await db.medecins.FindAsync(id);
            if (medecin == null)
            {
                return NotFound();
            }

            return Ok(medecin);
        }

        // PUT: api/medecins/5
        [Authentification]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putmedecin(int id, medecin medecin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medecin.id_med)
            {
                return BadRequest();
            }

            db.Entry(medecin).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!medecinExists(id))
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

        // POST: api/medecins
        [Authentification]
        [ResponseType(typeof(medecin))]
        public async Task<IHttpActionResult> Postmedecin(medecin medecin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.medecins.Add(medecin);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = medecin.id_med }, medecin);
        }

        // DELETE: api/medecins/5
        [Authentification]
        [ResponseType(typeof(medecin))]
        public async Task<IHttpActionResult> Deletemedecin(int id)
        {
            medecin medecin = await db.medecins.FindAsync(id);
            if (medecin == null)
            {
                return NotFound();
            }

            db.medecins.Remove(medecin);
            await db.SaveChangesAsync();

            return Ok(medecin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool medecinExists(int id)
        {
            return db.medecins.Count(e => e.id_med == id) > 0;
        }
    }
}