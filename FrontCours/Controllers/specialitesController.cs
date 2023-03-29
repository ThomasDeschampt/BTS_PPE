using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model;
using ORM_PPE_SLAM;

namespace FrontCours.Controllers
{
    public class specialitesController : Controller
    {
        private data_model db = new data_model();

        // GET: specialites
        public async Task<ActionResult> Index()
        {
            return View(await db.specialites.ToListAsync());
        }

        // GET: specialites/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            specialite specialite = await db.specialites.FindAsync(id);
            if (specialite == null)
            {
                return HttpNotFound();
            }
            return View(specialite);
        }

        // GET: specialites/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: specialites/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_spe,lib_spe")] specialite specialite)
        {
            if (ModelState.IsValid)
            {
                db.specialites.Add(specialite);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(specialite);
        }

        // GET: specialites/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            specialite specialite = await db.specialites.FindAsync(id);
            if (specialite == null)
            {
                return HttpNotFound();
            }
            return View(specialite);
        }

        // POST: specialites/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_spe,lib_spe")] specialite specialite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(specialite).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(specialite);
        }

        // GET: specialites/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            specialite specialite = await db.specialites.FindAsync(id);
            if (specialite == null)
            {
                return HttpNotFound();
            }
            return View(specialite);
        }

        // POST: specialites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            specialite specialite = await db.specialites.FindAsync(id);
            db.specialites.Remove(specialite);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
