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
    public class HisOrdersController : Controller
    {
        public class cOrderList
        {
            public int orderid { get; set; }
            public Models.HisOrder Order { get; set; }
            public int Required { get; set; }
            public int Completed { get; set; }
            public int Processed { get; set; }
        }
        
        private His10DBContainer db = new His10DBContainer();

        // GET: HIS10/HisOrders
        public ActionResult Index(int? status)
        {
            IQueryable<Models.HisOrder> hisOrders = db.HisOrders.Include(h => h.HisOrderType).Include(h => h.HisProfile).Include(h => h.HisPhysician).Include(h => h.HisInstrument);
            ViewBag.PageLabel = "Laboratory List";

            if (User.Identity.IsAuthenticated)
            {
                string userAccntId = User.Identity.GetUserId();

                //check if physician account
                int iPhysician = 0;
                var physician = db.HisPhysicians.Where(d => d.AccntUserId == userAccntId).FirstOrDefault();
                if (physician != null) iPhysician = (int)physician.Id;
                if (iPhysician != 0)
                {
                    hisOrders = hisOrders.Where(d => d.HisPhysicianId == iPhysician);
                    ViewBag.PageLabel = "Doctor's Requests";
                    ViewBag.PageType = "DOCTOR";
                }

                //check if Patient account
                int iPatient = 0;
                var patient = db.HisProfiles.Where(d => d.AccntUserId == userAccntId).FirstOrDefault();
                if (patient != null) iPatient = (int)patient.Id;
                if (iPatient != 0)
                {
                    hisOrders = hisOrders.Where(d => d.HisProfileId == iPatient);
                    ViewBag.PageLabel = "Patient's Laboratory";
                    ViewBag.PageType = "PATIENT";
                }

                //check if MedTech account
                var oper = db.HisOperators.Where(d => d.AccntUserId == userAccntId).FirstOrDefault();
                if (oper != null) ViewBag.PageType = "MEDTECH";

            }

            List<cOrderList> orderList = new List<cOrderList>();
            foreach (var tmpOrder in hisOrders)
            {
                int iRequired = tmpOrder.HisResults.Count;
                int iCompleted = 0;

                if (tmpOrder.HisResults.Count == 0) iCompleted = 0;
                if (tmpOrder.HisResults.Count >= 1) iCompleted = tmpOrder.HisResults.Where(d => d.Value1 != null && d.Value1.Trim() != "").ToList().Count;


                int iProcessed = 0;
                if (iRequired > 0) iProcessed = (100 * iCompleted / iRequired);
                if (iProcessed > 100) iProcessed = 100;

                orderList.Add(new cOrderList
                {
                    orderid = tmpOrder.Id,
                    Order = tmpOrder,
                    Required = iRequired, Completed = iCompleted,
                    Processed = iProcessed
                });

            }
//            if (orderList.Count > 0) ViewBag.orderList = orderList;

            //if ((int)status == 1)
            //{
            //}


            return View(orderList.ToList());
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
                hisOrder.dtRequest = DateTime.Now;
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

        public ActionResult ResultList(int? id)
        {
            return RedirectToAction("ResultList", "HisResults", new { orderId = id, area = "HIS10" });
        }
        public ActionResult ResultView(int? id)
        {
            return RedirectToAction("ResultView", "HisResults", new { orderId = id, area = "HIS10" });
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
