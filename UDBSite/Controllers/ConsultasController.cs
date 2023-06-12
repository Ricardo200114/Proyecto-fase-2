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
    public class ConsultasController : Controller
    {
        private UDBSiteEntities db = new UDBSiteEntities();

        // GET: Consultas
        [Authorize]
        public ActionResult Index()
        {
            var consultas = db.Consultas.Include(c => c.TipoConsulta);
            return View(consultas.ToList());
        }

        // GET: Consultas/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulta consulta = db.Consultas.Find(id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            return View(consulta);
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
