using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ecommerce.Classes;
using Ecommerce.Models;

namespace Ecommerce.Controllers
{
    public class CompaniesController : Controller
    {
        private EcommerceContext db = new EcommerceContext();

        public JsonResult GetCities(int departamentId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var cities = db.Cities.Where(c => c.DepartamentsId == departamentId);
            return Json(cities);
        }

        // GET: Companies
        public ActionResult Index()
        {
            var companies = db.Companies.Include(c => c.Cities).Include(c => c.Departaments);
            return View(companies.ToList());
        }

        // GET: Companies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Companies companies = db.Companies.Find(id);
            if (companies == null)
            {
                return HttpNotFound();
            }
            return View(companies);
        }

        // GET: Companies/Create
        public ActionResult Create()
        {
            ViewBag.CitiesId = new SelectList(ComboHelper.GetCities(), "CitiesId", "Name");
            ViewBag.DepartamentsId = new SelectList(ComboHelper.GetDepartaments(), "DepartamentsId", "Name");
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompaniesId,Name,Phone,Address,Logo,LogoFile,DepartamentsId,CitiesId")] Companies companies)
        {
            if (ModelState.IsValid)
            {
                var picture = string.Empty;
                var folder = "~/Content/Logos";

                if (companies.LogoFile != null)
                {
                    picture = FilesHelper.UploadPhoto(companies.LogoFile, folder);
                    picture = string.Format("{0}/{1}", folder, picture);
                }

                companies.Logo = picture;
                db.Companies.Add(companies);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CitiesId = new SelectList(ComboHelper.GetCities(), "CitiesId", "Name", companies.CitiesId);
            ViewBag.DepartamentsId = new SelectList(ComboHelper.GetDepartaments(), "DepartamentsId", "Name", companies.DepartamentsId);
            return View(companies);
        }

        // GET: Companies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Companies companies = db.Companies.Find(id);
            if (companies == null)
            {
                return HttpNotFound();
            }
            ViewBag.CitiesId = new SelectList(db.Cities, "CitiesId", "Name", companies.CitiesId);
            ViewBag.DepartamentsId = new SelectList(db.Departaments, "DepartamentsId", "Name", companies.DepartamentsId);
            return View(companies);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Companies companies)
        {
            if (ModelState.IsValid)
            {
                var picture = string.Empty;
                var folder = "~/Content/Logos";

                if (companies.LogoFile != null)
                {
                    picture = FilesHelper.UploadPhoto(companies.LogoFile, folder);
                    picture = string.Format("{0}/{1}", folder, picture);
                    companies.Logo = picture;
                }

                db.Entry(companies).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CitiesId = new SelectList(ComboHelper.GetCities(), "CitiesId", "Name", companies.CitiesId);
            ViewBag.DepartamentsId = new SelectList(ComboHelper.GetDepartaments(), "DepartamentsId", "Name", companies.DepartamentsId);
            return View(companies);
        }

        // GET: Companies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Companies companies = db.Companies.Find(id);
            if (companies == null)
            {
                return HttpNotFound();
            }
            return View(companies);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Companies companies = db.Companies.Find(id);
            db.Companies.Remove(companies);
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
