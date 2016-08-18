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
    public class EncabezadoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Encabezadoes
        public ActionResult Index()
        {
            return View(db.Encabezadoes.ToList());
        }

        // GET: Encabezadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encabezado encabezado = db.Encabezadoes.Find(id);
            if (encabezado == null)
            {
                return HttpNotFound();
            }
            return View(encabezado);
        }

        // GET: Encabezadoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Encabezadoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Cliente,Fecha,Subtotal,Impuestos,Total")] Encabezado encabezado)
        {
            if (ModelState.IsValid)
            {
                db.Encabezadoes.Add(encabezado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(encabezado);
        }

        // GET: Encabezadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encabezado encabezado = db.Encabezadoes.Find(id);
            if (encabezado == null)
            {
                return HttpNotFound();
            }
            return View(encabezado);
        }

        // POST: Encabezadoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Cliente,Fecha,Subtotal,Impuestos,Total")] Encabezado encabezado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(encabezado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(encabezado);
        }

        // GET: Encabezadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encabezado encabezado = db.Encabezadoes.Find(id);
            if (encabezado == null)
            {
                return HttpNotFound();
            }
            return View(encabezado);
        }

        // POST: Encabezadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Encabezado encabezado = db.Encabezadoes.Find(id);
            db.Encabezadoes.Remove(encabezado);
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
