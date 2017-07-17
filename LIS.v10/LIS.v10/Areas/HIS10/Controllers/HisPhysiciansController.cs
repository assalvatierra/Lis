using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LIS.v10.Areas.Core.Models;
using LIS.v10.Areas.HIS10.Models;
using Microsoft.AspNet.Identity;

namespace LIS.v10.Areas.HIS10.Controllers
{
    public class HisPhysiciansController : Controller
    {
        public class SearchPhysicianConfig
        {
            public string ActionOnUse { get; set; }
            public string ControllerOnUse { get; set; }
        }

        private His10DBContainer db = new His10DBContainer();

        // GET: HIS10/HisPhysicians
        public ActionResult Index()
        {
            return View(db.HisPhysicians.ToList());
        }

        public ActionResult SearchPhysicianPage()
        {
            ViewBag.Search = "Start searching.";
            return View();
        }

        [HttpPost]
        public JsonResult SearchPhysician(string search)
        {
            var data = db.HisPhysicians.Where(d => d.Name.Contains(search)).Select(s => new { name = s.Name, id = s.Id });
            var ret = new { message = "server: SearchPhysician=" + search, code = "110" };

            return Json(data);
        }
        
        public ActionResult SearchUseItem(int? id)
        {
            SearchPhysicianConfig config = (SearchPhysicianConfig)TempData["SEARCHOBJ"];
            if (config != null)
                return RedirectToAction(config.ActionOnUse, config.ControllerOnUse, new { SearchData = id });

            return View();
        }

        // GET: HIS10/HisPhysicians/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisPhysician hisPhysician = db.HisPhysicians.Find(id);
            if (hisPhysician == null)
            {
                return HttpNotFound();
            }
            return View(hisPhysician);
        }

        // GET: HIS10/HisPhysicians/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HIS10/HisPhysicians/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Remarks,AccntUserId")] HisPhysician hisPhysician)
        {
            if (ModelState.IsValid)
            {
                db.HisPhysicians.Add(hisPhysician);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hisPhysician);
        }

        // GET: HIS10/HisPhysicians/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisPhysician hisPhysician = db.HisPhysicians.Find(id);
            if (hisPhysician == null)
            {
                return HttpNotFound();
            }

            ViewBag.Specs = db.HisPhysicianSpecializations.Where(d=>d.HisPhysicianId==id).ToList();
            ViewBag.Clinics = db.HisPhysicianClinics.Where(d => d.HisPhysicianId == id).ToList();

            return View(hisPhysician);
        }

        // POST: HIS10/HisPhysicians/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Remarks,AccntUserId")] HisPhysician hisPhysician)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hisPhysician).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hisPhysician);
        }

        // GET: HIS10/HisPhysicians/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisPhysician hisPhysician = db.HisPhysicians.Find(id);
            if (hisPhysician == null)
            {
                return HttpNotFound();
            }
            return View(hisPhysician);
        }

        // POST: HIS10/HisPhysicians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HisPhysician hisPhysician = db.HisPhysicians.Find(id);
            db.HisPhysicians.Remove(hisPhysician);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Doctors profile
        // GET: HIS10/HisPhysicians/Edit/5
        public ActionResult profile(int? id)
        {
            if (id == null)
            {
                string userAccntId = User.Identity.GetUserId();
                var physician = db.HisPhysicians.Where(d => d.AccntUserId == userAccntId).FirstOrDefault();
                if (physician != null) id = (int)physician.Id;
            }
        
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisPhysician hisPhysician = db.HisPhysicians.Find(id);
            if (hisPhysician == null)
            {
                return HttpNotFound();
            }
            return View(hisPhysician);
        }

        // POST: HIS10/HisPhysicians/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult profile([Bind(Include = "Id,Name,Remarks,AccntUserId")] HisPhysician hisPhysician)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hisPhysician).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","Home",new { area = "" });
            }
            return View(hisPhysician);
        }

        public ActionResult ListSpecialization(int? id)
        {
            var data = db.HisSpecializations.ToList();
            ViewBag.PhysicianId = id;

            return View(data);
        }

        public ActionResult UseSpecialization(int? SpecId, int? physicianId)
        {
            string sqlExec = "Insert Into HisPhysicianSpecializations([HisSpecializationId],[HisPhysicianId]) Values(" + SpecId.ToString() + ",'" + physicianId.ToString() + "')";
            db.Database.ExecuteSqlCommand(sqlExec);
            return RedirectToAction("Edit", new { id = physicianId });
        }

        public ActionResult RemoveSpecialization(int? SpecId, int? physicianId)
        {
            string sqlExec = "delete from HisPhysicianSpecializations where HisSpecializationId = '"+ SpecId.ToString() + "' and HisPhysicianId = '" + physicianId.ToString() +"'";
            db.Database.ExecuteSqlCommand(sqlExec);
            return RedirectToAction("Edit", new { id = physicianId });
        }

        public ActionResult AddClinic(int? id)
        {
            Models.HisPhysicianClinic clinic = new HisPhysicianClinic();
            clinic.HisPhysicianId = (int)id;
            clinic.Days = "Mon-Fri";
            clinic.Time = "10am - 3pm";
            return View(clinic);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddClinic([Bind(Include = "Id,HisPhysicianId,Location,Days,Time,Remarks,Telephone")] HisPhysicianClinic clinic)
        {
            if(ModelState.IsValid)
            {
                db.HisPhysicianClinics.Add(clinic);
                db.SaveChanges();
                return RedirectToAction("Edit", new { id = clinic.HisPhysicianId });
            }

            return View(clinic);
        }

        public ActionResult EditClinic(int? id)
        {
            var data = db.HisPhysicianClinics.Find(id);
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditClinic( [Bind( Include = "Id,HisPhysicianId,Location,Days,Time,Remarks,Telephone")] HisPhysicianClinic clinic)
        {
            if(ModelState.IsValid)
            {
                db.Entry(clinic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit", new { id = clinic.HisPhysicianId });
            }

            return View(clinic);

        }

        public ActionResult RemoveClinic(int? id)
        {
            var data = db.HisPhysicianClinics.Find(id);
            int pId = data.HisPhysicianId;

            db.HisPhysicianClinics.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Edit", new { id = pId });
        }

        public ActionResult CreateLogin (int? id)
        {
            var data = db.HisPhysicians.Find(id);

            TempData["CREATELOGINPHYSICIANID"] = id;
            TempData["CREATELOGINCONFIG"] = new Core.Controllers.usersController.CreateLoginConfig
                    { AccntName=data.Name, AccntRemarks=data.Remarks, ActionAfterCreate = "CreateLoginDone", ControllerAfterCreate = "HisPhysicians", AreaAfterCreate="HIS10" };

            return RedirectToAction("Create", "users", new { area = "CORE" });

        }

        public ActionResult CreateLoginDone(string data)
        {
            int id = (int)TempData["CREATELOGINPHYSICIANID"];

            db.Database.ExecuteSqlCommand(
            "update HisPhysicians set AccntUserId = '" + data + "' where Id=" + id.ToString()
                );
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
