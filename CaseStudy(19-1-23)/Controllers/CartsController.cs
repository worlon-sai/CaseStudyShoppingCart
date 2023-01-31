using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CaseStudy_19_1_23_.Context;
using CaseStudy_19_1_23_.Models;
using Microsoft.AspNet.Identity;

namespace CaseStudy_19_1_23_.Controllers
{
    public class CartsController : Controller
    {
        private Cases_Context db = new Cases_Context();
        public ViewModel viewModel;

        public void Counts()
        {
           
            
                //var cart = db.carts.ToList().FindAll(x => x.CUName == (string)Session["User"]);
                //var z = cart.Count();
                //Session["Carts"] = z;
            


            

        }

        // GET: Carts
        public ActionResult Index()
        {
            CartsController cartsController = new CartsController();
            cartsController.Counts();

            if (User.Identity.Name == "")
            {
                return RedirectToAction("Login", "Account", "");
            }
            var cart = db.carts.ToList().FindAll(x=>x.CUName==User.Identity.Name);
            List<ViewModel> viewModels= new List<ViewModel>();
           
            foreach(var c in cart)
            {
                var p = db.products.Find(c.PId);
                if(p != null &&p.SuId!=null)
                viewModels.Add(new ViewModel() {cart= c 
                    ,
                    products=p,
                    subCategory=db.subcategories.Find(p.SuId) });
            }

            return View(viewModels);
        }

        // GET: Carts/Details/5
        public ActionResult Details(int? id)
        { viewModel=new ViewModel();
            var c= db.carts.Find(id);
            viewModel.category = db.categories.Find(id);
            viewModel.products = db.products.Find(c.PId);
            viewModel.subCategory = db.subcategories.Find(db.products.Find(c.PId).SuId);
            
            return View(viewModel);
        }

        
        
        
        public ActionResult Create(int PId)
        {
            if (User.Identity.Name == "")
            {
                return RedirectToAction("Login", "Account", "");
            }
            Cart cart = new Cart();
            
            cart.PId = PId;
            cart.CUName= User.Identity.Name;
           var z= db.carts.ToList().Find(x=>x.PId==PId);
            if(true)
            {
                db.carts.Add(cart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
               
            

            //return View(cart);
        }

    

        // GET: Carts/Delete/5
        public ActionResult Delete(int? id)
        {
            
            Cart cart = db.carts.Find(id);
            db.carts.Remove(cart);
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
