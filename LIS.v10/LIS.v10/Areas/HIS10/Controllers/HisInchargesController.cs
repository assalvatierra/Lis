using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LIS.v10.Areas.HIS10.Models;

namespace LIS.v10.Areas.HIS10.Controllers
{
    public class HisInchargesController : Controller
    {
        private His10DBContainer db = new His10DBContainer();

        // GET: HIS10/HisIncharges
        public ActionResult Index()
        {
            return View(db.HisIncharges.ToList());
        }

        // GET: HIS10/HisIncharges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisIncharge hisIncharge = db.HisIncharges.Find(id);
            if (hisIncharge == null)
            {
                return HttpNotFound();
            }
            return View(hisIncharge);
        }

        // GET: HIS10/HisIncharges/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HIS10/HisIncharges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Remarks,AccntUserId")] HisIncharge hisIncharge)
        {
            if (ModelState.IsValid)
            {
                db.HisIncharges.Add(hisIncharge);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hisIncharge);
        }

        // GET: HIS10/HisIncharges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisIncharge hisIncharge = db.HisIncharges.Find(id);
            if (hisIncharge == null)
            {
                return HttpNotFound();
            }
            return View(hisIncharge);
        }

        // POST: HIS10/HisIncharges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Remarks,AccntUserId")] HisIncharge hisIncharge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hisIncharge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hisIncharge);
        }

        // GET: HIS10/HisIncharges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisIncharge hisIncharge = db.HisIncharges.Find(id);
            if (hisIncharge == null)
            {
                return HttpNotFound();
            }
            return View(hisIncharge);
        }

        // POST: HIS10/HisIncharges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HisIncharge hisIncharge = db.HisIncharges.Find(id);
            db.HisIncharges.Remove(hisIncharge);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CreateLogin(int? id)
        {
            var data = db.HisIncharges.Find(id);

            TempData["CREATELOGININCHARGEID"] = id;
            TempData["CREATELOGINCONFIG"] = new Core.Controllers.usersController.CreateLoginConfig
            { AccntName = data.Name, AccntRemarks = data.Remarks, ActionAfterCreate = "CreateLoginDone", ControllerAfterCreate = "HisIncharges", AreaAfterCreate = "HIS10" };

            return RedirectToAction("Create", "users", new { area = "CORE" });

        }

        public ActionResult CreateLoginDone(string data)
        {
            int id = (int)TempData["CREATELOGININCHARGEID"];

            db.Database.ExecuteSqlCommand(
            "update HisIncharges set AccntUserId = '" + data + "' where Id=" + id.ToString()
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
