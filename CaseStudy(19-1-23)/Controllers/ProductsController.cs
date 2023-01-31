using CaseStudy_19_1_23_.Context;
using CaseStudy_19_1_23_.CustomFilter;
using CaseStudy_19_1_23_.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.Security;

namespace CaseStudy_19_1_23_.Controllers
{
    
    public class ProductsController : Controller
    {
        public Cases_Context _Context = new Cases_Context();
        ApplicationDbContext DbContext_context =new ApplicationDbContext();

        public ViewModel viewModel;
        // GET: Products

        [RoleAuthorization(Roles = "Admin")]
        public ActionResult Index()
        {
            var res = (List<Products>)TempData["Products"];
            var e = DbContext_context.Roles.ToList();
            var re = _Context.products.ToList();
            if (res == null || res.Count==0 )
            {
                return View(re);
            }

          
            return View(res);
        }

        
        public ActionResult UIndex()
        { CartsController cartsController = new CartsController();
            cartsController.Counts();
            var res = (List<Products>)TempData["Products"];
            var re = _Context.products.Include(s => s.subCategory).ToList();
            if (res == null || res.Count == 0  )
            {
                
                return View(re);
                
            }
            
            return View(res);
        }

        public ActionResult Details(int id)
        {
            var re= _Context.products.Find(id);
            return View(re);

        }
        [RoleAuthorization(Roles = "Admin")]
        public ActionResult Add()
        {
            ViewBag.SuId = new SelectList(_Context.subcategories, "SuId", "SuName");
            return View();
        }
        [HttpPost]
        [RoleAuthorization(Roles = "Admin")]
        public ActionResult Add(Products product)
        {
            _Context.products.Add(product);
            _Context.SaveChanges();
            var user = User.Identity.Name;
            return RedirectToAction("Index");
        }

        [RoleAuthorization(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var re = _Context.products.Find(id);
            ViewBag.SuId = new SelectList(_Context.subcategories, "SuId", "SuName");
            return View(re);
        }
        [HttpPost]
        [RoleAuthorization(Roles = "Admin")]
        public ActionResult Edit(Products product)
        {
            _Context.Entry(product).State = EntityState.Modified;
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }
        [RoleAuthorization(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var re = _Context.products.Find(id);
            return View(re);
        }
        [HttpPost,ActionName("Delete")]
        [RoleAuthorization(Roles = "Admin")]
        public ActionResult Deleted(int id)
        {
            var re=_Context.products.Find(id);
            _Context.products.Remove(re);
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Search()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Search(string s)
        {
            var re = _Context.products.Include(S1=>S1.subCategory).ToList().FindAll(x => x.PName.ToLower() == s);
            if (re.Count > 0)
            {
                TempData["Products"] = re;
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult USearch(string s)
        {
            TempData["s"] = s;

            return RedirectToAction("TransferDataAsync", "Transfer");
           /* var re = _Context.products.Include(s1=>s1.subCategory).ToList().FindAll(x => x.PName.ToLower() == s);
            if (re.Count > 0)
            {
                TempData["Products"] = re;
                return RedirectToAction("UIndex");
            }
            else
            {
                return RedirectToAction("Search");
            }

            */
            
        }
    }
}