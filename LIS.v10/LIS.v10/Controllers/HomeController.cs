using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.Entity;
using System.Net;
using LIS.v10.Models;
using LIS.v10.Areas.HIS10.Models;
using LIS.v10.Areas.Core.Models;

using Microsoft.AspNet.Identity;

namespace LIS.v10.Controllers
{
    public class HomeController : Controller
    {
        private LisDBContainer db = new LisDBContainer();
        private His10DBContainer Hisdb = new His10DBContainer();
        private CoreDBContainer Coredb = new CoreDBContainer();

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


            // check for the user type (doctor, patient, medtech )
            ViewBag.PageLabel = "Laboratory List";

            if (User.Identity.IsAuthenticated)
            {
                string userAccntId = User.Identity.GetUserId();

                //check if physician account
                int iPhysician = 0;
                var physician = Hisdb.HisPhysicians.Where(d => d.AccntUserId == userAccntId).FirstOrDefault();
                if (physician != null) iPhysician = (int)physician.Id;
                if (iPhysician != 0)
                {
                    ViewBag.PageType = "DOCTOR";
                }

                //check if Patient account
                int iPatient = 0;
                var patient = Hisdb.HisProfiles.Where(d => d.AccntUserId == userAccntId).FirstOrDefault();
                if (patient != null) iPatient = (int)patient.Id;
                if (iPatient != 0)
                {
                    ViewBag.PageType = "PATIENT";
                }

                //check if MedTech account
                var oper = Hisdb.HisOperators.Where(d => d.AccntUserId == userAccntId).FirstOrDefault();
                if (oper != null) ViewBag.PageType = "MEDTECH";

                //check if Admin
                var gAdmin = Coredb.userGroupAdmins.Where(d => d.UserId == userAccntId ).FirstOrDefault();
                if (gAdmin != null) ViewBag.PageType = "ADMIN";
            }


            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}