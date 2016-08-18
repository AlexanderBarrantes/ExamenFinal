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
    public class ProductosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Productos
        public ActionResult Index()
        {
            return View(db.Productos.ToList());
        }

        // GET: Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
    //   [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Nombre,Marca,Familia,CasaFabricación,TipoUnidad,Departamento,Activo,Descuento,FechaIngreso,Unidad,Impuesto")] Productos productos)
        {
            if (ModelState.IsValid)
            {
                db.Productos.Add(productos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productos);
        }
        [HttpPost]
        public ActionResult addt(string id_number, string Marca, string Familia,string CasaFabricación, string TipoUnidad, string Departamento,bool  Activo,
            double Descuento,string FechaIngreso,int Unidad,double Impuesto)
            
        {
            Productos producto = new Productos();
            producto.Nombre = id_number;
            producto.Marca = Marca;
            producto.Familia = Familia;
            producto.CasaFabricación = CasaFabricación;
            producto.TipoUnidad = TipoUnidad;
            producto.Departamento = Departamento;
            producto.Activo = Activo;
            producto.Descuento = Descuento;
            producto.FechaIngreso = Convert.ToDateTime(FechaIngreso);
            producto.Unidad = Unidad;
            producto.Impuesto = Impuesto;
            db.Productos.Add(producto);
            db.SaveChanges();
            return new HttpStatusCodeResult(HttpStatusCode.OK);


        }
        [HttpPost]
        public ActionResult eliminar(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            db.Productos.Remove(productos);
            db.SaveChanges();
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
        // GET: Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Nombre,Marca,Familia,CasaFabricación,TipoUnidad,Departamento,Activo,Descuento,FechaIngreso,Unidad,Impuesto")] Productos productos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productos);
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Productos productos = db.Productos.Find(id);
            db.Productos.Remove(productos);
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
