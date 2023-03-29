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
    public class departementsController : Controller
    {
        private data_model db = new data_model();

        // GET: departements
        public async Task<ActionResult> Index()
        {
            return View(await db.departements.ToListAsync());
        }

        // GET: departements/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            departement departement = await db.departements.FindAsync(id);
            if (departement == null)
            {
                return HttpNotFound();
            }
            return View(departement);
        }

        // GET: departements/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: departements/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_dep,nom_dep,reg_dep")] departement departement)
        {
            if (ModelState.IsValid)
            {
                db.departements.Add(departement);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(departement);
        }

        // GET: departements/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            departement departement = await db.departements.FindAsync(id);
            if (departement == null)
            {
                return HttpNotFound();
            }
            return View(departement);
        }

        // POST: departements/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_dep,nom_dep,reg_dep")] departement departement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departement).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(departement);
        }

        // GET: departements/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            departement departement = await db.departements.FindAsync(id);
            if (departement == null)
            {
                return HttpNotFound();
            }
            return View(departement);
        }

        // POST: departements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            departement departement = await db.departements.FindAsync(id);
            db.departements.Remove(departement);
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
