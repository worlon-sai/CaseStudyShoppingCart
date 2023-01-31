using CaseStudy_19_1_23_.Models;
using CaseWebapi.ModelContext;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace CaseWebapi.Controllers
{
    public class MyWebAPIController : ApiController
    {
        public Test_CaseStudyEntities  _Context=new Test_CaseStudyEntities();
        // GET: MyWebAPI

        //[System.Web.Http.HttpGet]
        //public IEnumerable<Product> Data()
        //{ ViewModel v= new ViewModel();
        //    var pr= _Context.Products.ToList();
        //    List<Products> prod = new List<Products>();
        //    foreach(var p in pr)
        //    {
        //        prod.Add(new Products()
        //        {PId=p.PId,
        //        PImage=p.PImage,
        //        PName=p.PName,
        //        PPrice=p.PPrice,
        //        PStocks=p.PStocks,
        //        subCategory=p.SubCategory,
        //        SuId=p.SuId,

        //        });
        //    }
        //    v.Lproducts = (prod);
        //    var jsondata = JsonConvert.SerializeObject(v, new JsonSerializerSettings
        //    {
        //        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        //    });
        //    // var content = new StringContent(jsondata, Encoding.UTF8, "application/json");

        //    var z = _Context.Products.ToList();
        //    return z;
        //}

        [System.Web.Http.HttpPost]
        public string TransferData(ViewModel viewModel)
        {
            var products = _Context.Products.ToList();
            var z = products.FindAll(x => x.PName.ToLower() == viewModel.search.ToLower() || x.SubCategory.SuName.ToLower()== viewModel.search.ToLower() || x.SubCategory.Category.CAName.ToLower() == viewModel.search.ToLower());
            //ViewModel ve= new ViewModel();
            //List<Products> prod = new List<Products>();
            List<string> res = new List<string>();
            foreach (var p in z)
            {
                res.Add(p.PId.ToString());
                //prod.Add(new Products()
                //{
                //    PId = p.PId,
                //    PImage = p.PImage,
                //    PName = p.PName,
                //    PPrice = p.PPrice,
                //    PStocks = p.PStocks,
                //    subCategory = p.SubCategory,
                //    SuId = p.SuId,

                //});
            }
            //ve.Lproducts = prod;
            //ve.search= viewModel.search;
            //var jsondata = JsonConvert.SerializeObject(ve, new JsonSerializerSettings
            //{
            //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            //});
            //var content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var rew = String.Join(",",res);
            return rew;
        }
    }
}