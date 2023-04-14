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
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using FrontCours.Models;

namespace FrontCours.Controllers
{
    public class medecinsController : Controller
    {
        private data_model db = new data_model();

        // GET: medecins
        public async Task<ActionResult> Index()
        {
            // url de l'api
            string url = "https://localhost:44345/api/medecins";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("token", "123456789");
                HttpResponseMessage response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception();
                }

                var liste = await response.Content.ReadAsAsync<IEnumerable<medecin>>();

                return View(liste);

            }
        }

        // GET: medecins/Details/5
        public async Task<ActionResult> Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // url de l'api
            string url = "https://localhost:44345/api/medecins/" + id;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("token", "123456789");
                HttpResponseMessage response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                    throw new Exception();

                var medecin = await response.Content.ReadAsAsync<medecin>();
                ViewBag.C_FK_id_dep = new SelectList(db.departements, "id_dep", "nom_dep", medecin.C_FK_id_dep);
                ViewBag.C_FK_id_spe = new SelectList(db.specialites, "id_spe", "lib_spe", medecin.C_FK_id_spe);
                return View(medecin);
            }

        }

        // GET: medecins
        public async Task<ActionResult> SearchMedecins(string nom)
        {
            // url de l'api
            string url = "https://localhost:44345/api/medecins?nom=" + nom;


            using (HttpClient client = new HttpClient())
            {

                if (string.IsNullOrEmpty(nom) || nom.Length < 2)
                {
                    return HttpNotFound();
                }

                client.DefaultRequestHeaders.Add("token", "123456789");
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    if (!string.IsNullOrEmpty(content))
                    {
                        var liste = JsonConvert.DeserializeObject<IEnumerable<medecin>>(content);
                        return View("Index", liste);
                    }
                }

                throw new Exception();

            }
        }



        // GET: medecins/Create
        [Authorize]
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
                string json = JsonConvert.SerializeObject(medecin);

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("token", "123456789");
                    using (var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44345/api/medecins"))
                    {
                        request.Content = new StringContent(json, Encoding.UTF8, "application/json");

                        var reponse = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

                        if (!reponse.IsSuccessStatusCode)
                        {
                            throw new Exception();
                        }

                        reponse.EnsureSuccessStatusCode();
                        ViewBag.C_FK_id_dep = new SelectList(db.departements, "id_dep", "nom_dep", medecin.C_FK_id_dep);
                        ViewBag.C_FK_id_spe = new SelectList(db.specialites, "id_spe", "lib_spe", medecin.C_FK_id_spe);
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(medecin);
        }

        // GET: medecins/Edit/5
        [Authorize]
        public async Task<ActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // url de l'api
            string url = "https://localhost:44345/api/medecins/" + id;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("token", "123456789");
                HttpResponseMessage response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                    throw new Exception();

                var medecin = await response.Content.ReadAsAsync<medecin>();
                ViewBag.C_FK_id_dep = new SelectList(db.departements, "id_dep", "nom_dep", medecin.C_FK_id_dep);
                ViewBag.C_FK_id_spe = new SelectList(db.specialites, "id_spe", "lib_spe", medecin.C_FK_id_spe);
                return View(medecin);
            }

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
                string json = JsonConvert.SerializeObject(medecin);
                
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("token", "123456789");
                    HttpContent cont = new StringContent(json, Encoding.UTF8, "application/json");

                    var send = await client.PutAsync("https://localhost:44345/api/medecins/" + medecin.id_med, cont).ConfigureAwait(false);
                    if (!send.IsSuccessStatusCode)
                        throw new Exception();

                    send.EnsureSuccessStatusCode();
                    ViewBag.C_FK_id_dep = new SelectList(db.departements, "id_dep", "nom_dep", medecin.C_FK_id_dep);
                    ViewBag.C_FK_id_spe = new SelectList(db.specialites, "id_spe", "lib_spe", medecin.C_FK_id_spe);

                    return RedirectToAction("Index");
                    
                }
            }
            return View(medecin);
        }

        // GET: medecins/Delete/5
        [Authorize]
        public async Task<ActionResult> Delete(int? id)
        {
            string url = "https://localhost:44345/api/medecins/" + id;

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("token", "123456789");

                HttpResponseMessage response = await client.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                    throw new Exception();

                var medecin = await response.Content.ReadAsAsync<medecin>();
                return View(medecin);
            }
        }

        // POST: medecins/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            string url = "https://localhost:44345/api/medecins/" + id;

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("token", "123456789");
                HttpResponseMessage response = await client.DeleteAsync(url);

                if (!response.IsSuccessStatusCode)
                    throw new Exception();
            }
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
