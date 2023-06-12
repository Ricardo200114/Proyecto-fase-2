using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UDBSite.Models;

namespace UDBSite.Controllers
{
    [Authorize]
    public class TipoConsultasController : Controller
    {
        private UDBSiteEntities db = new UDBSiteEntities();

        // GET: TipoConsultas
        public ActionResult Index()
        {
            return View(db.TipoConsultas.ToList());
        }

        // GET: TipoConsultas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoConsulta tipoConsulta = db.TipoConsultas.Find(id);
            if (tipoConsulta == null)
            {
                return HttpNotFound();
            }
            return View(tipoConsulta);
        }

        // GET: TipoConsultas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoConsultas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Visible")] TipoConsulta tipoConsulta)
        {
            if (ModelState.IsValid)
            {
                db.TipoConsultas.Add(tipoConsulta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoConsulta);
        }

        // GET: TipoConsultas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoConsulta tipoConsulta = db.TipoConsultas.Find(id);
            if (tipoConsulta == null)
            {
                return HttpNotFound();
            }
            return View(tipoConsulta);
        }

        // POST: TipoConsultas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Visible")] TipoConsulta tipoConsulta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoConsulta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoConsulta);
        }

        // GET: TipoConsultas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoConsulta tipoConsulta = db.TipoConsultas.Find(id);
            if (tipoConsulta == null)
            {
                return HttpNotFound();
            }
            return View(tipoConsulta);
        }

        // POST: TipoConsultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoConsulta tipoConsulta = db.TipoConsultas.Find(id);
            db.TipoConsultas.Remove(tipoConsulta);
            db.SaveChanges();
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
