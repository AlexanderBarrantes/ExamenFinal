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
    public class ClientesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Clientes
        public ActionResult Index()
        {
            return View(db.Clientes.ToList());
            //return Json(db.Clientes.ToList(), JsonRequestBehavior.AllowGet);
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
      //  [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Cedula,Nombre,Apellido,FechaNacimiento,Dirección,EstadoCivil,Sexo,FechaIngreso,Tipo,Descuento")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(clientes);
                db.SaveChanges();
               return RedirectToAction("Index");
             
            }

            return View(clientes);
        }
        [HttpPost]
        public ActionResult addt(string id_number, string first_name, string last_name, string birthday, string address, string civil_status, string sex, string admission_date, string client_type, double discount)
        {
            
            Clientes cliente = new Clientes();
            cliente.Cedula = id_number;
            cliente.Apellido = last_name;
            cliente.Descuento = discount;
            cliente.Dirección = address;
            cliente.FechaIngreso = Convert.ToDateTime(admission_date);
            cliente.FechaNacimiento = Convert.ToDateTime( birthday);
            cliente.Nombre = first_name;
            cliente.Sexo = sex;
            cliente.Tipo = client_type;
            cliente.EstadoCivil = civil_status;
            db.Clientes.Add(cliente);
             db.SaveChanges();
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
        [HttpPost]
        public ActionResult editar(int id,string id_number, string first_name, string last_name, string birthday, string address, string civil_status, string sex, string admission_date, string client_type, double discount)
        {

            Clientes cliente = db.Clientes.Find(id);

            cliente.Cedula = id_number;
            cliente.Apellido = last_name;
            cliente.Descuento = discount;
            cliente.Dirección = address;
            cliente.FechaIngreso = Convert.ToDateTime(admission_date);
            cliente.FechaNacimiento = Convert.ToDateTime(birthday);
            cliente.Nombre = first_name;
            cliente.Sexo = sex;
            cliente.Tipo = client_type;
            cliente.EstadoCivil = civil_status;
            db.Entry(cliente).State = EntityState.Modified;
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
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            db.Clientes.Remove(clientes);
            db.SaveChanges();
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Cedula,Nombre,Apellido,FechaNacimiento,Dirección,EstadoCivil,Sexo,FechaIngreso,Tipo,Descuento")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientes);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clientes clientes = db.Clientes.Find(id);
            db.Clientes.Remove(clientes);
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
