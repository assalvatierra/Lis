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
    public class HisProfileReqsController : Controller
    {
        private His10DBContainer db = new His10DBContainer();

        // GET: HIS10/HisProfileReqs
        //public ActionResult Index()
        //{
        //    var hisProfileReqs = db.HisProfileReqs.Include(h => h.HisProfile).Include(h => h.HisRequest);
        //    return View(hisProfileReqs.ToList());
        //}

        public ActionResult Index(int? RptType, int? status)
        {
            if (RptType == null)
                RptType = (int)Session["RPTTYPE"];
            else
                Session["RPTTYPE"] = RptType;

            if (status == null)
                status = (int)Session["RPTSTATUS"];
            else
                Session["RPTSTATUS"] = status;

            var hisProfileReqs = db.HisProfileReqs.Include(h => h.HisProfile).Include(h => h.HisRequest);
            if(RptType==1) //All requests
                hisProfileReqs = hisProfileReqs.OrderBy(d => d.dtRequested);
            if (RptType == 2) //By Schedule
                hisProfileReqs = hisProfileReqs.OrderBy(d => d.dtSchedule);
            if (RptType == 3) //By Item
                hisProfileReqs = hisProfileReqs.OrderBy(d => d.HisProfileId);

            return View(hisProfileReqs.ToList());
        }

        public ActionResult TheraphyTasks(int? RptType, int? status)
        {
            if (RptType == null)
                RptType = (int)Session["RPTTYPE"];
            else
                Session["RPTTYPE"] = RptType;

            if (status == null)
                status = (int)Session["RPTSTATUS"];
            else
                Session["RPTSTATUS"] = status;

            if (User.Identity.IsAuthenticated)
            {
                string userAccntId = User.Identity.GetUserId();
                var therapy = db.HisIncharges.Where(d => d.AccntUserId == userAccntId).FirstOrDefault();
                if (therapy != null)
                {
                    var HisProInchg = db.HisProfileIncharges.Where(d => d.HisInchargeId == therapy.Id).Select( s=> s.HisProfileId );
                    var hisProfileReqs = db.HisProfileReqs.Include(h => h.HisProfile).Include(h => h.HisRequest)
                        .Where( d=> HisProInchg.Contains(d.HisProfileId) );

                    if(status==1)
                        hisProfileReqs = hisProfileReqs.Where(d=>d.dtPerformed == null );

                    if (RptType == 1) //All requests
                        hisProfileReqs = hisProfileReqs.OrderBy(d => d.dtRequested);
                    if (RptType == 2) //By Schedule
                        hisProfileReqs = hisProfileReqs.OrderBy(d => d.dtSchedule);
                    if (RptType == 3) //By Item
                        hisProfileReqs = hisProfileReqs.OrderBy(d => d.HisProfileId);

                    return View(hisProfileReqs.ToList());
                }
            }

            return RedirectToAction("Login", "Account");
        }
        public ActionResult TaskDone(int? id)
        {
            var data = db.HisProfileReqs.Find(id);
            data.dtPerformed = System.DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("TheraphyTasks");
        }
        public ActionResult TaskUndone(int? id)
        {
            var data = db.HisProfileReqs.Find(id);
            data.dtPerformed = null;
            db.SaveChanges();
            return RedirectToAction("TheraphyTasks");
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
            var newreq = new HisProfileReq();
            newreq.dtRequested = System.DateTime.Today;

            ViewBag.HisProfileId = new SelectList(db.HisProfiles, "Id", "Name");
            ViewBag.HisRequestId = new SelectList(db.HisRequests, "Id", "Title");
            return View(newreq);
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


        public string hasNotif(int? id)
        {
            var data = db.HisNotifications.Where(s => s.RefId == id).Select(s => s.Id).FirstOrDefault();
            string message = "id: " +id.ToString() +" data:"+data.ToString();
            return data.ToString();
            //return db1.getData(id);
        }
        
    }
}
