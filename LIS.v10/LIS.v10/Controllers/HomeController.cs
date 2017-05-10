using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.Entity;
using System.Net;
using LIS.v10.Models;

namespace LIS.v10.Controllers
{
    public class HomeController : Controller
    {
        private LisDBContainer db = new LisDBContainer();

        public ActionResult Index()
        {
            Models.AppInformation appInfo_app = db.AppInformations.Where(d=> d.Key == "APP").FirstOrDefault();
            Models.AppInformation appInfo_desc = db.AppInformations.Where(d => d.Key == "DESC").FirstOrDefault();
            Models.AppInformation appInfo_ver = db.AppInformations.Where(d => d.Key == "VER").FirstOrDefault();
            Models.AppInformation appInfo_rem = db.AppInformations.Where(d => d.Key == "REMARKS").FirstOrDefault();

            ViewBag.AppName = "Default App";
            ViewBag.AppDescription = "Laboratory Information System";
            ViewBag.AppVersion = "Prototype 1.0";

            if (appInfo_app != null) ViewBag.AppName = appInfo_app.Data;
            if (appInfo_desc != null) ViewBag.AppDescription = appInfo_desc.Data;
            if (appInfo_ver != null) ViewBag.AppVersion = appInfo_ver.Data;
            if (appInfo_rem != null) ViewBag.AppRemarks = appInfo_rem.Data;

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
    }
}