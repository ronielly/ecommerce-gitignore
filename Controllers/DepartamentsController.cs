using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ecommerce.Models;

namespace Ecommerce.Controllers
{
    public class DepartamentsController : Controller
    {
        private EcommerceContext db = new EcommerceContext();

        // GET: Departaments
        public ActionResult Index()
        {
            return View(db.Departaments.ToList());
        }

        // GET: Departaments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departaments departaments = db.Departaments.Find(id);
            if (departaments == null)
            {
                return HttpNotFound();
            }
            return View(departaments);
        }

        // GET: Departaments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departaments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartamentsId,Name")] Departaments departaments)
        {
            if (ModelState.IsValid)
            {
                db.Departaments.Add(departaments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(departaments);
        }

        // GET: Departaments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departaments departaments = db.Departaments.Find(id);
            if (departaments == null)
            {
                return HttpNotFound();
            }
            return View(departaments);
        }

        // POST: Departaments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepartamentsId,Name")] Departaments departaments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departaments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(departaments);
        }

        // GET: Departaments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departaments departaments = db.Departaments.Find(id);
            if (departaments == null)
            {
                return HttpNotFound();
            }
            return View(departaments);
        }

        // POST: Departaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Departaments departament = db.Departaments.Find(id);
            db.Departaments.Remove(departament);
            try
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                if(ex.InnerException != null && ex.InnerException.InnerException != null &&
                        ex.InnerException.InnerException.Message.Contains("REFERENCE")){
                    ModelState.AddModelError(string.Empty, "Não é possivel excluir departamentos porque existe cidades relacionadas a ele, primeiro remova a cidade, volte a excluir");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }

                return View(departament);
            }
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
