using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LIS.v10.Areas.HIS10.Models;
using Microsoft.AspNet.Identity;

namespace LIS.v10.Areas.HIS10.Controllers
{
    public class HisProfilesController : Controller
    {
        private His10DBContainer db = new His10DBContainer();

        // GET: HIS10/HisProfiles
        public ActionResult Index()
        {
            return View(db.HisProfiles.ToList());
        }

        // GET: HIS10/HisProfiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisProfile hisProfile = db.HisProfiles.Find(id);
            if (hisProfile == null)
            {
                return HttpNotFound();
            }
            return View(hisProfile);
        }

        // GET: HIS10/HisProfiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HIS10/HisProfiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Remarks,AccntUserId")] HisProfile hisProfile)
        {
            if (ModelState.IsValid)
            {
                db.HisProfiles.Add(hisProfile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hisProfile);
        }

        // GET: HIS10/HisProfiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisProfile hisProfile = db.HisProfiles.Find(id);
            if (hisProfile == null)
            {
                return HttpNotFound();
            }
            return View(hisProfile);
        }

        // POST: HIS10/HisProfiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Remarks,AccntUserId")] HisProfile hisProfile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hisProfile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hisProfile);
        }
        // GET: HIS10/HisProfiles/Edit/5
        public ActionResult Patient(int? id)
        {
            if (id == null)
            {
                string userAccntId = User.Identity.GetUserId();
                var profile = db.HisProfiles.Where(d => d.AccntUserId == userAccntId).FirstOrDefault();
                if (profile != null) id = (int)profile.Id;
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisProfile hisProfile = db.HisProfiles.Find(id);
            if (hisProfile == null)
            {
                return HttpNotFound();
            }
            return View(hisProfile);
        }

        // POST: HIS10/HisProfiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Patient([Bind(Include = "Id,Name,Remarks,AccntUserId")] HisProfile hisProfile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hisProfile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            return View(hisProfile);
        }

        // GET: HIS10/HisProfiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisProfile hisProfile = db.HisProfiles.Find(id);
            if (hisProfile == null)
            {
                return HttpNotFound();
            }
            return View(hisProfile);
        }

        // POST: HIS10/HisProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HisProfile hisProfile = db.HisProfiles.Find(id);
            db.HisProfiles.Remove(hisProfile);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CreateLogin(int? id)
        {
            var data = db.HisProfiles.Find(id);

            TempData["CREATELOGINPROFILEID"] = id;
            TempData["CREATELOGINCONFIG"] = new Core.Controllers.usersController.CreateLoginConfig
            { AccntName = data.Name, AccntRemarks = data.Remarks, ActionAfterCreate = "CreateLoginDone", ControllerAfterCreate = "HisProfiles", AreaAfterCreate = "HIS10" };

            return RedirectToAction("Create", "users", new { area = "CORE" });

        }

        public ActionResult CreateLoginDone(string data)
        {
            int id = (int)TempData["CREATELOGINPROFILEID"];

            db.Database.ExecuteSqlCommand(
            "update HisProfiles set AccntUserId = '" + data + "' where Id=" + id.ToString()
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
