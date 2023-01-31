using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CaseStudy_19_1_23_.Context;
using CaseStudy_19_1_23_.CustomFilter;
using CaseStudy_19_1_23_.Models;

namespace CaseStudy_19_1_23_.Controllers
{
    public class SubCategoriesController : Controller
    {
        private Cases_Context db = new Cases_Context();

        // GET: SubCategories
        public ActionResult Index()
        {
            var subcategories = db.subcategories.Include(s => s.category);
            return View(subcategories.ToList());
        }

        // GET: SubCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory subCategory = db.subcategories.Find(id);
            if (subCategory == null)
            {
                return HttpNotFound();
            }
            return View(subCategory);
        }

        // GET: SubCategories/Create
        [RoleAuthorization(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.CAId = new SelectList(db.categories, "CAId", "CAName");
            return View();
        }

        // POST: SubCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SuId,SuName,CAId")] SubCategory subCategory)
        {
            if (ModelState.IsValid)
            {
                db.subcategories.Add(subCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CAId = new SelectList(db.categories, "CAId", "CAName", subCategory.CAId);
            return View(subCategory);
        }

        // GET: SubCategories/Edit/5
        [RoleAuthorization(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory subCategory = db.subcategories.Find(id);
            if (subCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CAId = new SelectList(db.categories, "CAId", "CAName", subCategory.CAId);
            return View(subCategory);
        }

        // POST: SubCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [RoleAuthorization(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "SuId,SuName,CAId")] SubCategory subCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CAId = new SelectList(db.categories, "CAId", "CAName", subCategory.CAId);
            return View(subCategory);
        }

        // GET: SubCategories/Delete/5
        [RoleAuthorization(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory subCategory = db.subcategories.Find(id);
            if (subCategory == null)
            {
                return HttpNotFound();
            }
            return View(subCategory);
        }

        // POST: SubCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [RoleAuthorization(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            SubCategory subCategory = db.subcategories.Find(id);
            db.subcategories.Remove(subCategory);
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
