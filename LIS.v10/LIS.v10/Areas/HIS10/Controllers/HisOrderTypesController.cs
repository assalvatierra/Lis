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
    public class HisOrderTypesController : Controller
    {
        private His10DBContainer db = new His10DBContainer();

        // GET: HIS10/HisOrderTypes
        public ActionResult Index()
        {
            return View(db.HisOrderTypes.ToList());
        }

        // GET: HIS10/HisOrderTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisOrderType hisOrderType = db.HisOrderTypes.Find(id);
            if (hisOrderType == null)
            {
                return HttpNotFound();
            }
            return View(hisOrderType);
        }

        // GET: HIS10/HisOrderTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HIS10/HisOrderTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,Remarks")] HisOrderType hisOrderType)
        {
            if (ModelState.IsValid)
            {
                db.HisOrderTypes.Add(hisOrderType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hisOrderType);
        }

        // GET: HIS10/HisOrderTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisOrderType hisOrderType = db.HisOrderTypes.Find(id);
            if (hisOrderType == null)
            {
                return HttpNotFound();
            }
            return View(hisOrderType);
        }

        // POST: HIS10/HisOrderTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,Remarks")] HisOrderType hisOrderType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hisOrderType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hisOrderType);
        }

        // GET: HIS10/HisOrderTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisOrderType hisOrderType = db.HisOrderTypes.Find(id);
            if (hisOrderType == null)
            {
                return HttpNotFound();
            }
            return View(hisOrderType);
        }

        // POST: HIS10/HisOrderTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HisOrderType hisOrderType = db.HisOrderTypes.Find(id);
            db.HisOrderTypes.Remove(hisOrderType);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ResultFields(int? id)
        {
            return RedirectToAction("OrderTypeFields", "HisResultFields", new { typeId = id, area = "HIS10" });
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
