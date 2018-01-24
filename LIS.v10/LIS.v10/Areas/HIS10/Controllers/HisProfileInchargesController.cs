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
    public class HisProfileInchargesController : Controller
    {
        private His10DBContainer db = new His10DBContainer();

        // GET: HIS10/HisProfileIncharges
        public ActionResult Index()
        {
            if (Session["CURRENT_INCHARGE_ID"] == null)
                return RedirectToAction("ListInCharge");

            int TmpId = (int)Session["CURRENT_INCHARGE_ID"];
            ViewBag.CurrentIncharge = TmpId;

            HisIncharge profile = db.HisIncharges.Find(TmpId);
            //if (tmpdata == null) 

            ViewBag.InChargeDetail = profile.Id + " - " + profile.Name;

            var hisProfileIncharges = db.HisProfileIncharges.Include(h => h.HisProfile).Include(h => h.HisIncharge)
                .Where(d=>d.HisInchargeId==TmpId);
            return View(hisProfileIncharges.ToList());
        }

        public ActionResult ListInCharge()
        {
            var list = db.HisIncharges;
            return View(list);
        }

        public ActionResult SelectIncharge(int? id)
        {
            Session["CURRENT_INCHARGE_ID"] = (int)id;
            return RedirectToAction("index");
        }

        // GET: HIS10/HisProfileIncharges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisProfileIncharge hisProfileIncharge = db.HisProfileIncharges.Find(id);
            if (hisProfileIncharge == null)
            {
                return HttpNotFound();
            }
            return View(hisProfileIncharge);
        }

        // GET: HIS10/HisProfileIncharges/Create
        public ActionResult Create()
        {
            ViewBag.HisProfileId = new SelectList(db.HisProfiles, "Id", "Name");
            ViewBag.HisInchargeId = new SelectList(db.HisIncharges, "Id", "Name");
            return View();
        }

        // POST: HIS10/HisProfileIncharges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,HisProfileId,HisInchargeId")] HisProfileIncharge hisProfileIncharge)
        {
            if (ModelState.IsValid)
            {
                db.HisProfileIncharges.Add(hisProfileIncharge);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HisProfileId = new SelectList(db.HisProfiles, "Id", "Name", hisProfileIncharge.HisProfileId);
            ViewBag.HisInchargeId = new SelectList(db.HisIncharges, "Id", "Name", hisProfileIncharge.HisInchargeId);
            return View(hisProfileIncharge);
        }

        // GET: HIS10/HisProfileIncharges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisProfileIncharge hisProfileIncharge = db.HisProfileIncharges.Find(id);
            if (hisProfileIncharge == null)
            {
                return HttpNotFound();
            }
            ViewBag.HisProfileId = new SelectList(db.HisProfiles, "Id", "Name", hisProfileIncharge.HisProfileId);
            ViewBag.HisInchargeId = new SelectList(db.HisIncharges, "Id", "Name", hisProfileIncharge.HisInchargeId);
            return View(hisProfileIncharge);
        }

        // POST: HIS10/HisProfileIncharges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,HisProfileId,HisInchargeId")] HisProfileIncharge hisProfileIncharge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hisProfileIncharge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HisProfileId = new SelectList(db.HisProfiles, "Id", "Name", hisProfileIncharge.HisProfileId);
            ViewBag.HisInchargeId = new SelectList(db.HisIncharges, "Id", "Name", hisProfileIncharge.HisInchargeId);
            return View(hisProfileIncharge);
        }

        // GET: HIS10/HisProfileIncharges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisProfileIncharge hisProfileIncharge = db.HisProfileIncharges.Find(id);
            if (hisProfileIncharge == null)
            {
                return HttpNotFound();
            }
            return View(hisProfileIncharge);
        }

        // POST: HIS10/HisProfileIncharges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HisProfileIncharge hisProfileIncharge = db.HisProfileIncharges.Find(id);
            db.HisProfileIncharges.Remove(hisProfileIncharge);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ListItem(int? id)
        {
            ViewBag.Incharge = (int)id;
            var list = db.HisProfiles;
            return View(list);
        }
        public ActionResult AddToInCharge(int? pId, int? iId)
        {
            var data = db.HisProfileIncharges.Where(d => d.HisProfileId == (int)pId && d.HisInchargeId == (int)iId).FirstOrDefault();
            if(data==null)
            {
                db.HisProfileIncharges.Add(new HisProfileIncharge { HisProfileId = (int)pId, HisInchargeId = (int)iId });
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult ListGroup()
        {
            var list = db.HisGroupings;
            return View(list);
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
