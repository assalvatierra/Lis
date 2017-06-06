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
    public class HisResultsController : Controller
    {
        private His10DBContainer db = new His10DBContainer();

        // GET: HIS10/HisResults
        public ActionResult Index()
        {
            int orderid = (int)Session["ORDERID"];
            if(orderid==0) return RedirectToAction("index", "HisOrders");

            return RedirectToAction("ResultList", new { orderId = orderid });
        }

        public ActionResult ResultList(int? orderId)
        {
            Session["ORDERID"] = (int)orderId;

            Models.HisOrder order = db.HisOrders.Find((int)orderId);
            var hisResults = db.HisResults.Include(h => h.HisOrder).Include(h => h.HisResultField).Where(d=>d.HisOrderId==orderId);
            if(hisResults.Count()==0)
            {
                //generate fields results

                //get order type
                int ordertype = order.HisOrderTypeId;

                //get fields for the type
                var OrderTypeFields = db.HisResultFields.Where(d => d.HisOrderTypeId == ordertype && d.AddForType == 1);
                
                //add types to result 
                foreach(var tmpField in OrderTypeFields)
                {
                    Models.HisResult hrf = new HisResult();
                    hrf.HisOrderId = (int)orderId;
                    hrf.HisResultFieldId = tmpField.Id;
                    hrf.Remarks = "";

                    db.HisResults.Add(hrf);
                }

                db.SaveChanges();
            }

            ViewBag.Order = order;

            return View(hisResults.ToList());
        }

        public ActionResult ResultView(int? orderId)
        {
            Models.HisOrder order = db.HisOrders.Find((int)orderId);
            var hisResults = db.HisResults.Include(h => h.HisOrder).Include(h => h.HisResultField).Where(d => d.HisOrderId == orderId);
            ViewBag.Order = order;
            return View(hisResults.ToList());
        }

        // GET: HIS10/HisResults/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisResult hisResult = db.HisResults.Find(id);
            if (hisResult == null)
            {
                return HttpNotFound();
            }
            return View(hisResult);
        }

        // GET: HIS10/HisResults/Create
        public ActionResult Create()
        {
            int orderid = (int)Session["ORDERID"];
            ViewBag.HisOrderId = new SelectList(db.HisOrders, "Id", "SpecimenId", orderid);
            ViewBag.HisResultFieldId = new SelectList(db.HisResultFields, "Id", "Name");
            return View();
        }

        // POST: HIS10/HisResults/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,HisOrderId,HisResultFieldId,Value1,Value2,Value3,Remarks")] HisResult hisResult)
        {
            if (ModelState.IsValid)
            {
                db.HisResults.Add(hisResult);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HisOrderId = new SelectList(db.HisOrders, "Id", "SpecimenId", hisResult.HisOrderId);
            ViewBag.HisResultFieldId = new SelectList(db.HisResultFields, "Id", "Name", hisResult.HisResultFieldId);
            return View(hisResult);
        }

        // GET: HIS10/HisResults/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisResult hisResult = db.HisResults.Find(id);
            if (hisResult == null)
            {
                return HttpNotFound();
            }
            ViewBag.HisOrderId = new SelectList(db.HisOrders, "Id", "SpecimenId", hisResult.HisOrderId);
            ViewBag.HisResultFieldId = new SelectList(db.HisResultFields, "Id", "Name", hisResult.HisResultFieldId);
            return View(hisResult);
        }

        // POST: HIS10/HisResults/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,HisOrderId,HisResultFieldId,Value1,Value2,Value3,Remarks")] HisResult hisResult)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hisResult).State = EntityState.Modified;

                var hisOrder = db.HisOrders.Find(hisResult.HisOrderId);
                if (hisOrder.dtProcessed == null)
                {
                    hisOrder.dtProcessed = DateTime.Now;
                    db.Entry(hisOrder).State = EntityState.Modified;
                }

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.HisOrderId = new SelectList(db.HisOrders, "Id", "SpecimenId", hisResult.HisOrderId);
            ViewBag.HisResultFieldId = new SelectList(db.HisResultFields, "Id", "Name", hisResult.HisResultFieldId);
            return View(hisResult);
        }

        // GET: HIS10/HisResults/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisResult hisResult = db.HisResults.Find(id);
            if (hisResult == null)
            {
                return HttpNotFound();
            }
            return View(hisResult);
        }

        // POST: HIS10/HisResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HisResult hisResult = db.HisResults.Find(id);
            db.HisResults.Remove(hisResult);
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
