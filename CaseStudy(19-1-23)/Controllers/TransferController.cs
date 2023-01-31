using CaseStudy_19_1_23_.Context;
using CaseStudy_19_1_23_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.CodeDom;
using System.Threading.Tasks;

namespace CaseStudy_19_1_23_.Controllers
{
    public class TransferController : Controller
    {

        public Cases_Context _Context= new Cases_Context();

        


        // GET: Transfer
       
        public async Task<ActionResult> TransferDataAsync()
        {
            var pro= _Context.products.Include(s => s.subCategory).ToList();
            
            ViewModel vie =new ViewModel();
            vie.search = (string)TempData["s"];

            var jsondata= JsonConvert.SerializeObject(vie, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            var content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var client = new HttpClient();
           
            string baseurl = "https://localhost:44304/api/";
            client.BaseAddress = new Uri(baseurl);

            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.PostAsync("MyWebAPI/TransferData", content).Result;
            // Get data from Web API
            var s2 = response.StatusCode;
            var s1 = response.ReasonPhrase;
            var z = response.Content;
            if (response.IsSuccessStatusCode)
            {
                //var responseData = response.Content.ReadAsAsync<ViewModel>().Result;
               // var responseData =  response.Content.ReadAsAsync<ViewModel>().Result;
                var rew = await response.Content.ReadAsStringAsync();
                var result =

                    JsonConvert.DeserializeObject<string>(rew);
                var sp = result.Split(',');
                var result1 = _Context.products.ToList();
                List<Products> results = new List<Products>();
                foreach(var i in sp)
                {
                    var q = result1.Find(x => x.PId == Convert.ToInt32(i));
                    if (q != null)
                    {
                        results.Add(q);
                    }
                }

                if (results.Count() >=0)
                {
                    TempData["Products"] = results;
                    return RedirectToAction("UIndex", "Products");
                }
                return RedirectToAction("Search", "Products");
            }
            else
            {
                return RedirectToAction("Search","Products");
            }


        }


    }
}