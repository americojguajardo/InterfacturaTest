using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class AlumnosController : Controller
    {
        private AlumnoDBContext3 db = new AlumnoDBContext3();

        // GET: Alumnos
        public ActionResult Index()
        {
            return View(db.Alumnos.ToList());
        }

        // GET: Alumnos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumno alumno = db.Alumnos.Find(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View(alumno);
        }

        // GET: Alumnos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alumnos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,ApellidoPaterno,ApellidoMaterno,Genero,Activo,FechaDeNacimiento,FechaDeIngreso,RFC")] Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                db.Alumnos.Add(alumno);
                db.SaveChanges();

                //Add Textfile
                var string_with_your_data = "Nombre: " + alumno.Nombre;
                string_with_your_data += "\n Apellido Paterno: " + alumno.ApellidoPaterno;
                string_with_your_data += "\n Apellido Materno: " + alumno.ApellidoMaterno;
                string_with_your_data += "\n Genero: " + alumno.Genero;
                string_with_your_data += "\n Activo: " + alumno.Activo;
                string_with_your_data += "\n Fecha De Nacimiento: " + alumno.FechaDeNacimiento;
                string_with_your_data += "\n FechaDeIngreso: " + alumno.FechaDeIngreso;
                string_with_your_data += "\n RFC: " + alumno.RFC;

                var byteArray = Encoding.ASCII.GetBytes(string_with_your_data);
                var stream = new MemoryStream(byteArray);

                return File(stream, "text/plain", alumno.RFC+".txt");

                //return RedirectToAction("Index");
            }

            return View(alumno);
        }

        // GET: Alumnos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumno alumno = db.Alumnos.Find(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View(alumno);
        }

        // POST: Alumnos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,ApellidoPaterno,ApellidoMaterno,Genero,Activo,FechaDeNacimiento,FechaDeIngreso,RFC")] Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alumno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(alumno);
        }

        // GET: Alumnos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumno alumno = db.Alumnos.Find(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View(alumno);
        }

        // POST: Alumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alumno alumno = db.Alumnos.Find(id);
            db.Alumnos.Remove(alumno);
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
