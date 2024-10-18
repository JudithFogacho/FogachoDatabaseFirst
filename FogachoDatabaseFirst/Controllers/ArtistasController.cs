using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FogachoDatabaseFirst.Models;

namespace FogachoDatabaseFirst.Controllers
{
    public class ArtistasController : Controller
    {
        private CancionesLocalDBEntities db = new CancionesLocalDBEntities();

        // GET: Artistas
        public ActionResult Index()
        {
            return View(db.Artistas.ToList());
        }

        // GET: Artistas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artistas artistas = db.Artistas.Find(id);
            if (artistas == null)
            {
                return HttpNotFound();
            }
            return View(artistas);
        }

        // GET: Artistas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artistas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArtistaID,NombrePilaArtista,NombreArtistico,FechaNacimiento")] Artistas artistas)
        {
            if (ModelState.IsValid)
            {
                db.Artistas.Add(artistas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artistas);
        }

        // GET: Artistas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artistas artistas = db.Artistas.Find(id);
            if (artistas == null)
            {
                return HttpNotFound();
            }
            return View(artistas);
        }

        // POST: Artistas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArtistaID,NombrePilaArtista,NombreArtistico,FechaNacimiento")] Artistas artistas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artistas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artistas);
        }

        // GET: Artistas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artistas artistas = db.Artistas.Find(id);
            if (artistas == null)
            {
                return HttpNotFound();
            }
            return View(artistas);
        }

        // POST: Artistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artistas artistas = db.Artistas.Find(id);
            db.Artistas.Remove(artistas);
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
