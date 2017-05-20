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
    public class HisOrdersController : Controller
    {
        private His10DBContainer db = new His10DBContainer();

        // GET: HIS10/HisOrders
        public ActionResult Index()
        {
            var hisOrders = db.HisOrders.Include(h => h.HisOrderType).Include(h => h.HisProfile).Include(h => h.HisPhysician).Include(h => h.HisInstrument);
            return View(hisOrders.ToList());
        }

        // GET: HIS10/HisOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisOrder hisOrder = db.HisOrders.Find(id);
            if (hisOrder == null)
            {
                return HttpNotFound();
            }
            return View(hisOrder);
        }

        // GET: HIS10/HisOrders/Create
        public ActionResult Create()
        {
            ViewBag.HisOrderTypeId = new SelectList(db.HisOrderTypes, "Id", "Description");
            ViewBag.HisProfileId = new SelectList(db.HisProfiles, "Id", "Name");
            ViewBag.HisPhysicianId = new SelectList(db.HisPhysicians, "Id", "Name");
            ViewBag.HisInstrumentId = new SelectList(db.HisInstruments, "Id", "Name");
            return View();
        }

        // POST: HIS10/HisOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SpecimenId,HisOrderTypeId,HisProfileId,HisPhysicianId,HisInstrumentId,dtRequest,dtProcessed,dtReleased")] HisOrder hisOrder)
        {
            if (ModelState.IsValid)
            {
                db.HisOrders.Add(hisOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HisOrderTypeId = new SelectList(db.HisOrderTypes, "Id", "Description", hisOrder.HisOrderTypeId);
            ViewBag.HisProfileId = new SelectList(db.HisProfiles, "Id", "Name", hisOrder.HisProfileId);
            ViewBag.HisPhysicianId = new SelectList(db.HisPhysicians, "Id", "Name", hisOrder.HisPhysicianId);
            ViewBag.HisInstrumentId = new SelectList(db.HisInstruments, "Id", "Name", hisOrder.HisInstrumentId);
            return View(hisOrder);
        }

        // GET: HIS10/HisOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisOrder hisOrder = db.HisOrders.Find(id);
            if (hisOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.HisOrderTypeId = new SelectList(db.HisOrderTypes, "Id", "Description", hisOrder.HisOrderTypeId);
            ViewBag.HisProfileId = new SelectList(db.HisProfiles, "Id", "Name", hisOrder.HisProfileId);
            ViewBag.HisPhysicianId = new SelectList(db.HisPhysicians, "Id", "Name", hisOrder.HisPhysicianId);
            ViewBag.HisInstrumentId = new SelectList(db.HisInstruments, "Id", "Name", hisOrder.HisInstrumentId);
            return View(hisOrder);
        }

        // POST: HIS10/HisOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SpecimenId,HisOrderTypeId,HisProfileId,HisPhysicianId,HisInstrumentId,dtRequest,dtProcessed,dtReleased")] HisOrder hisOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hisOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HisOrderTypeId = new SelectList(db.HisOrderTypes, "Id", "Description", hisOrder.HisOrderTypeId);
            ViewBag.HisProfileId = new SelectList(db.HisProfiles, "Id", "Name", hisOrder.HisProfileId);
            ViewBag.HisPhysicianId = new SelectList(db.HisPhysicians, "Id", "Name", hisOrder.HisPhysicianId);
            ViewBag.HisInstrumentId = new SelectList(db.HisInstruments, "Id", "Name", hisOrder.HisInstrumentId);
            return View(hisOrder);
        }

        // GET: HIS10/HisOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisOrder hisOrder = db.HisOrders.Find(id);
            if (hisOrder == null)
            {
                return HttpNotFound();
            }
            return View(hisOrder);
        }

        // POST: HIS10/HisOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HisOrder hisOrder = db.HisOrders.Find(id);
            db.HisOrders.Remove(hisOrder);
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
