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
    public class medecinsController : Controller
    {
        private data_model db = new data_model();

        // GET: medecins
        public async Task<ActionResult> Index()
        {
            var medecins = db.medecins.Include(m => m.departement).Include(m => m.specialite);
            return View(await medecins.ToListAsync());
        }

        // GET: medecins/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medecin medecin = await db.medecins.FindAsync(id);
            if (medecin == null)
            {
                return HttpNotFound();
            }
            return View(medecin);
        }

        // GET: medecins/Create
        public ActionResult Create()
        {
            ViewBag.C_FK_id_dep = new SelectList(db.departements, "id_dep", "nom_dep");
            ViewBag.C_FK_id_spe = new SelectList(db.specialites, "id_spe", "lib_spe");
            return View();
        }

        // POST: medecins/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_med,nom_med,pre_med,adr_med,tel_med,C_FK_id_spe,C_FK_id_dep")] medecin medecin)
        {
            if (ModelState.IsValid)
            {
                db.medecins.Add(medecin);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.C_FK_id_dep = new SelectList(db.departements, "id_dep", "nom_dep", medecin.C_FK_id_dep);
            ViewBag.C_FK_id_spe = new SelectList(db.specialites, "id_spe", "lib_spe", medecin.C_FK_id_spe);
            return View(medecin);
        }

        // GET: medecins/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medecin medecin = await db.medecins.FindAsync(id);
            if (medecin == null)
            {
                return HttpNotFound();
            }
            ViewBag.C_FK_id_dep = new SelectList(db.departements, "id_dep", "nom_dep", medecin.C_FK_id_dep);
            ViewBag.C_FK_id_spe = new SelectList(db.specialites, "id_spe", "lib_spe", medecin.C_FK_id_spe);
            return View(medecin);
        }

        // POST: medecins/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_med,nom_med,pre_med,adr_med,tel_med,C_FK_id_spe,C_FK_id_dep")] medecin medecin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medecin).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.C_FK_id_dep = new SelectList(db.departements, "id_dep", "nom_dep", medecin.C_FK_id_dep);
            ViewBag.C_FK_id_spe = new SelectList(db.specialites, "id_spe", "lib_spe", medecin.C_FK_id_spe);
            return View(medecin);
        }

        // GET: medecins/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medecin medecin = await db.medecins.FindAsync(id);
            if (medecin == null)
            {
                return HttpNotFound();
            }
            return View(medecin);
        }

        // POST: medecins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            medecin medecin = await db.medecins.FindAsync(id);
            db.medecins.Remove(medecin);
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
