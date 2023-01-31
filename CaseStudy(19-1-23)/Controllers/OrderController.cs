using CaseStudy_19_1_23_.Context;
using CaseStudy_19_1_23_.Models;
using CaseStudy_19_1_23_.Repo;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace CaseStudy_19_1_23_.Controllers
{
    public class OrderController : Controller
    { 
        private IGenericRepo<Order> order=null;
        public Cases_Context _Context = new Cases_Context();
        public ViewModel viewModel;

        

        // GET: Order
        public ActionResult Index()
        {   var Uname=User.Identity.Name;
            CartsController cartsController = new CartsController();
            cartsController.Counts();
            if (User.Identity.Name == "")
            {
                return RedirectToAction("Login", "Account", "");
            }

            List<ViewModel> viewModel1= new List< ViewModel>();
            var re=_Context.orders.ToList().FindAll(x=>x.OUName==Uname);
            
            foreach(var item in re)
            {
                var c = _Context.products.Find(item.PId);
                if (c != null && c.SuId != null)
                    viewModel1.Add(new ViewModel() { order = item,
                    products=c,
                    subCategory= _Context.subcategories.Find(c.SuId) });
            }
            return View(viewModel1);
        }

        public ActionResult Details(int id) 
        {
            var or = _Context.orders.Find(id);
           
            var pro = _Context.products.Find(or.PId);
            viewModel = new ViewModel();
            viewModel.products=pro;
            viewModel.order=or;
            viewModel.subCategory = _Context.subcategories.Find(pro.SuId);


            return View(viewModel); 
        }

        public ActionResult Add(int PId)
        {
            var pro = _Context.products.Find(PId);
            Order order1 = new Order();
            order1.PId = PId;
            order1.OUName = User.Identity.Name;
            if (User.Identity.Name == ""  )
            {
               return RedirectToAction("Login", "Account", "");
            }
            order1.payment = (string)TempData["payment"];
            order1.OrAdress = (string)TempData["Adress"];
            
            order1.dateTime = DateTime.Now;

            if (pro.PStocks > 0)
            {
                pro.PStocks = pro.PStocks - 1;
                _Context.orders.Add(order1);
                _Context.SaveChanges();

                /* MailMessage mailMessage = new MailMessage();

                 mailMessage.From = new MailAddress("sample@gmail.com");
                 mailMessage.Subject = "ABout order"+pro.PName;
                 mailMessage.To.Add(new MailAddress("order1.OUName"));
                 mailMessage.Body = "order Successfull of amount "+pro.PPrice;

                 var smtp = new SmtpClient("smtp.gmail.com")
                 {
                     Port = 587,
                     Credentials = new NetworkCredential("sample@gmail.com", "pass"),
                     EnableSsl = true,

                 };
                 smtp.Send(mailMessage); */
                var z =_Context.orders.Find(order1.PId);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Remove(int PId)
        {
            

            _Context.orders.Remove(_Context.orders.ToList().Find(x=>x.PId==PId));
            _Context.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Buy(int PId)
        {
            if (User.Identity.Name == "")
            {
                return RedirectToAction("Login", "Account", "");
            }
            return RedirectToAction("OrderDetails",new {PId=PId});

            

        }

        public ActionResult OrderDetails(int PId)
        {
            Order orders = new Order();
            orders.PId = PId;
            orders.OUName = User.Identity.Name;
            orders.dateTime = DateTime.Now;
            return View(orders);
        }

            [HttpPost]
        public ActionResult OrderDetails(Order order)
        {
            
            var ca = _Context.carts.ToList().Find(x => x.PId == order.PId );
            if (ca != null && ca.CId > 0)
            {
                _Context.carts.Remove(ca);
                _Context.SaveChanges();
            }
            Order orders = order;
            orders.payment = "card";
            TempData["payment"] = orders.payment;
            TempData["Adress"] = order.OrAdress;
            TempData["dateTime"] = order.dateTime;
            return RedirectToAction("Add", new { PId = order.PId });

        }


    }
}