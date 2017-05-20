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
    public class HisResultFieldsController : Controller
    {
        private His10DBContainer db = new His10DBContainer();

        // GET: HIS10/HisResultFields
        public ActionResult Index()
        {
            var hisResultFields = db.HisResultFields.Include(h => h.HisOrderType);
            return View(hisResultFields.ToList());
        }

        // GET: HIS10/HisResultFields/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisResultField hisResultField = db.HisResultFields.Find(id);
            if (hisResultField == null)
            {
                return HttpNotFound();
            }
            return View(hisResultField);
        }

        // GET: HIS10/HisResultFields/Create
        public ActionResult Create()
        {
            ViewBag.HisOrderTypeId = new SelectList(db.HisOrderTypes, "Id", "Description");
            return View();
        }

        // POST: HIS10/HisResultFields/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,HisOrderTypeId,Name,Desc,SeqNo")] HisResultField hisResultField)
        {
            if (ModelState.IsValid)
            {
                db.HisResultFields.Add(hisResultField);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HisOrderTypeId = new SelectList(db.HisOrderTypes, "Id", "Description", hisResultField.HisOrderTypeId);
            return View(hisResultField);
        }

        // GET: HIS10/HisResultFields/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisResultField hisResultField = db.HisResultFields.Find(id);
            if (hisResultField == null)
            {
                return HttpNotFound();
            }
            ViewBag.HisOrderTypeId = new SelectList(db.HisOrderTypes, "Id", "Description", hisResultField.HisOrderTypeId);
            return View(hisResultField);
        }

        // POST: HIS10/HisResultFields/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,HisOrderTypeId,Name,Desc,SeqNo")] HisResultField hisResultField)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hisResultField).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HisOrderTypeId = new SelectList(db.HisOrderTypes, "Id", "Description", hisResultField.HisOrderTypeId);
            return View(hisResultField);
        }

        // GET: HIS10/HisResultFields/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisResultField hisResultField = db.HisResultFields.Find(id);
            if (hisResultField == null)
            {
                return HttpNotFound();
            }
            return View(hisResultField);
        }

        // POST: HIS10/HisResultFields/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HisResultField hisResultField = db.HisResultFields.Find(id);
            db.HisResultFields.Remove(hisResultField);
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
