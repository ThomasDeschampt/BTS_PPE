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
    public class departementsController : ApiController
    {
        private data_model db = new data_model();

        // GET: api/departements
        public IQueryable<departement> Getdepartements()
        {
            return db.departements;
        }

        // GET: api/departements/5
        [ResponseType(typeof(departement))]
        public async Task<IHttpActionResult> Getdepartement(int id)
        {
            departement departement = await db.departements.FindAsync(id);
            if (departement == null)
            {
                return NotFound();
            }

            return Ok(departement);
        }

        ////PUT: api/departements/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> Putdepartement(int id, departement departement)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != departement.id_dep)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(departement).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!departementExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/departements
        //[ResponseType(typeof(departement))]
        //public async Task<IHttpActionResult> Postdepartement(departement departement)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.departements.Add(departement);

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (departementExists(departement.id_dep))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = departement.id_dep }, departement);
        //}

        // DELETE: api/departements/5
        //[ResponseType(typeof(departement))]
        //public async Task<IHttpActionResult> Deletedepartement(int id)
        //{
        //    departement departement = await db.departements.FindAsync(id);
        //    if (departement == null)
        //    {
        //        return NotFound();
        //    }

        //    db.departements.Remove(departement);
        //    await db.SaveChangesAsync();

        //    return Ok(departement);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool departementExists(int id)
        {
            return db.departements.Count(e => e.id_dep == id) > 0;
        }
    }
}