using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UDBSite.Models;

namespace UDBSite.Controllers
{
    public class HomeController : Controller
    {
        UDBSiteEntities _db = new UDBSiteEntities();
        public ActionResult Index()
        {
            var udb = _db.Instituciones.FirstOrDefault();
            ViewBag.Noticias = _db.Noticias.Where(x => x.Visible == true).ToList();
            return View(udb);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Carreras()
        {
            ViewBag.Message = "Nuestras carreras.";
            var carreras = _db.Carreras.Where(x => x.Visible == true && x.Facultad.Visible == true).ToList();
            return View(carreras);
        }

        public ActionResult Contact()
        {

            ViewBag.IdTipoConsulta = new SelectList(_db.TipoConsultas, "Id", "Nombre");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "Id,Correo,TextoConsulta,IdTipoConsulta")] Consulta consulta)
        {
            consulta.Fecha = DateTime.Now;
            if (ModelState.IsValid)
            {
                _db.Consultas.Add(consulta);
                _db.SaveChanges();
                return RedirectToAction("Success", new { correo = consulta.Correo });
            }

            ViewBag.IdTipoConsulta = new SelectList(_db.TipoConsultas, "Id", "Nombre", consulta.IdTipoConsulta);
            return View(consulta);
        }

        public ActionResult Success(string correo)
        {

            ViewBag.Correo = correo;
            return View();
        }

    }
}