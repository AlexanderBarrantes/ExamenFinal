using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Examen.Models;
using Modelos.Modelos;

namespace Examen.Controllers
{
    public class InventariosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Inventarios
        public ActionResult Index()
        {
            return View(db.Inventarios.ToList());
        }

        // GET: Inventarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventarios inventarios = db.Inventarios.Find(id);
            if (inventarios == null)
            {
                return HttpNotFound();
            }
            return View(inventarios);
        }

        // GET: Inventarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inventarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Identificador,Producto,Cantidad,CantidadMinima,CantidadMaxima,GravadoExento")] Inventarios inventarios)
        {
            if (ModelState.IsValid)
            {
                db.Inventarios.Add(inventarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inventarios);
        }

        // GET: Inventarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventarios inventarios = db.Inventarios.Find(id);
            if (inventarios == null)
            {
                return HttpNotFound();
            }
            return View(inventarios);
        }

        // POST: Inventarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Identificador,Producto,Cantidad,CantidadMinima,CantidadMaxima,GravadoExento")] Inventarios inventarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inventarios);
        }

        // GET: Inventarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventarios inventarios = db.Inventarios.Find(id);
            if (inventarios == null)
            {
                return HttpNotFound();
            }
            return View(inventarios);
        }

        // POST: Inventarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inventarios inventarios = db.Inventarios.Find(id);
            db.Inventarios.Remove(inventarios);
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
