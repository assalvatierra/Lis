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
    public class HisProfileReqsController : Controller
    {
        private His10DBContainer db = new His10DBContainer();

        // GET: HIS10/HisProfileReqs
        public ActionResult Index()
        {
            var hisProfileReqs = db.HisProfileReqs.Include(h => h.HisProfile).Include(h => h.HisRequest);
            return View(hisProfileReqs.ToList());
        }

        // GET: HIS10/HisProfileReqs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisProfileReq hisProfileReq = db.HisProfileReqs.Find(id);
            if (hisProfileReq == null)
            {
                return HttpNotFound();
            }
            return View(hisProfileReq);
        }

        // GET: HIS10/HisProfileReqs/Create
        public ActionResult Create()
        {
            ViewBag.HisProfileId = new SelectList(db.HisProfiles, "Id", "Name");
            ViewBag.HisRequestId = new SelectList(db.HisRequests, "Id", "Title");
            return View();
        }

        // POST: HIS10/HisProfileReqs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,HisProfileId,HisRequestId,dtRequested,dtSchedule,dtPerformed,Remarks")] HisProfileReq hisProfileReq)
        {
            if (ModelState.IsValid)
            {
                db.HisProfileReqs.Add(hisProfileReq);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HisProfileId = new SelectList(db.HisProfiles, "Id", "Name", hisProfileReq.HisProfileId);
            ViewBag.HisRequestId = new SelectList(db.HisRequests, "Id", "Title", hisProfileReq.HisRequestId);
            return View(hisProfileReq);
        }

        // GET: HIS10/HisProfileReqs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisProfileReq hisProfileReq = db.HisProfileReqs.Find(id);
            if (hisProfileReq == null)
            {
                return HttpNotFound();
            }
            ViewBag.HisProfileId = new SelectList(db.HisProfiles, "Id", "Name", hisProfileReq.HisProfileId);
            ViewBag.HisRequestId = new SelectList(db.HisRequests, "Id", "Title", hisProfileReq.HisRequestId);
            return View(hisProfileReq);
        }

        // POST: HIS10/HisProfileReqs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,HisProfileId,HisRequestId,dtRequested,dtSchedule,dtPerformed,Remarks")] HisProfileReq hisProfileReq)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hisProfileReq).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HisProfileId = new SelectList(db.HisProfiles, "Id", "Name", hisProfileReq.HisProfileId);
            ViewBag.HisRequestId = new SelectList(db.HisRequests, "Id", "Title", hisProfileReq.HisRequestId);
            return View(hisProfileReq);
        }

        // GET: HIS10/HisProfileReqs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisProfileReq hisProfileReq = db.HisProfileReqs.Find(id);
            if (hisProfileReq == null)
            {
                return HttpNotFound();
            }
            return View(hisProfileReq);
        }

        // POST: HIS10/HisProfileReqs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HisProfileReq hisProfileReq = db.HisProfileReqs.Find(id);
            db.HisProfileReqs.Remove(hisProfileReq);
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
