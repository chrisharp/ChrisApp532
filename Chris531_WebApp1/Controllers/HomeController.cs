using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chris531_WebApp1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var title = ConfigurationManager.AppSettings["PageTitle"];
            if(string.IsNullOrEmpty(title))
            {                
                var url = Request.Url.ToString();
                if (url.StartsWith("http://"))
                {
                    if(url.IndexOf('.') > -1)
                        ViewBag.Title = url.Substring(7, url.IndexOf('.')) + " (add PageTitle to appsettings)";
                    else
                        ViewBag.Title = url.Substring(7) + " (add PageTitle to appsettings)";
                }
                else
                {
                    if (url.IndexOf('.') > -1)
                        ViewBag.Title = url.Substring(0, url.IndexOf('.')) + " (add PageTitle to appsettings)";
                    else
                        ViewBag.Title = url + " (add PageTitle to appsettings)";
                }
            }
            else
            {
                ViewBag.Title = ConfigurationManager.AppSettings["PageTitle"];
            }

            return View();
        }
    }
}
