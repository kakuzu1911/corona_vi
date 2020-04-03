using Corona.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Corona.Controllers
{
    public class HomeController : Controller
    {
        public string GetStr()
        {
            string json = "[]";
            try
            {
                json = new WebClient().DownloadString("https://corona.lmao.ninja/countries").Replace("null", "0").Replace("long", "_long");
            }
            catch (Exception)
            {

            }
            return json;
        }
        [OutputCache(Duration =20*60,VaryByParam ="*")]
        public ActionResult Index(string _or)
        {
            if(string.IsNullOrEmpty(_or))
            {
                _or = "0";
            }
            string json = GetStr();
            IEnumerable<ObjectCorona> tmp = null;
            if(json!= "[]")
            {
                tmp = JsonConvert.DeserializeObject<IEnumerable<ObjectCorona>>(json);
                switch(_or)
                {
                    case "1":
                        tmp = tmp.ToList().OrderByDescending(m => m.todayDeaths);
                        break;
                    case "2":
                        tmp = tmp.ToList().OrderByDescending(m => m.deaths);
                        break;
                    case "3":
                        tmp = tmp.ToList().OrderByDescending(m => m.cases);
                        break;
                }
            }
            ViewBag.or = _or;
            return View(tmp);
        }
        public ActionResult ReturnMap()
        {
            List<ListMap> map = new List<ListMap>();
            IEnumerable<ObjectCorona> tmp = null;
            string json = GetStr();
            if (json != "[]")
            {
                tmp = JsonConvert.DeserializeObject<IEnumerable<ObjectCorona>>(json);
            }
            if (tmp != null && tmp.Count() > 0)
            {
                foreach (var it in tmp)
                {
                    ListMap ite = new ListMap();
                    ite.cases = it.cases;
                    ite.deaths = it.deaths;
                    ite.country = it.country;
                    ite._long = it.countryInfo._long;
                    ite.lat = it.countryInfo.lat;
                    map.Add(ite);
                }
            }
            return Json(map, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Map()
        {
            return View();
        }
    }
}
