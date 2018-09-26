using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShowTemperatureData.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace ShowTemperatureData.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public async System.Threading.Tasks.Task<ActionResult> Weather()
        {

            string Baseurl = "https://sensortestwipro.azurewebsites.net/";
            List<Weather> wetherInfo = new List<Weather>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("/api/HttpTriggerJS/");

                if (Res.IsSuccessStatusCode)
                {
                    var wetherResponse = Res.Content.ReadAsStringAsync().Result;
                    wetherInfo = JsonConvert.DeserializeObject<List<Weather>>(wetherResponse);

                }
                return View(wetherInfo);
            }
        }

    }
}