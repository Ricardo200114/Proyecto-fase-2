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
    public class InstitucionController : Controller
    {
        private UDBSiteEntities db = new UDBSiteEntities();

        // GET: Institucions/Details/5
        [Authorize]
        public ActionResult Details()
        {
            Institucion institucion = db.Instituciones.FirstOrDefault();
            if (institucion == null)
            {
                return HttpNotFound();
            }
            return View(institucion);
        }


        // GET: Institucions/Edit/5
        [Authorize]
        public ActionResult Edit()
        {
            Institucion institucion = db.Instituciones.FirstOrDefault();
            if (institucion == null)
            {
                return HttpNotFound();
            }
            return View(institucion);
        }

        // POST: Institucions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Descripcion,URLVideo")] Institucion institucion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(institucion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details");
            }
            return View(institucion);
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
