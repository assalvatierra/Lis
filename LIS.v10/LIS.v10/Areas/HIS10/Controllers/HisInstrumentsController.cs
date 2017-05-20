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
    public class HisInstrumentsController : Controller
    {
        private His10DBContainer db = new His10DBContainer();

        // GET: HIS10/HisInstruments
        public ActionResult Index()
        {
            var hisInstruments = db.HisInstruments.Include(h => h.HisEntity);
            return View(hisInstruments.ToList());
        }

        // GET: HIS10/HisInstruments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisInstrument hisInstrument = db.HisInstruments.Find(id);
            if (hisInstrument == null)
            {
                return HttpNotFound();
            }
            return View(hisInstrument);
        }

        // GET: HIS10/HisInstruments/Create
        public ActionResult Create()
        {
            ViewBag.HisEntityId = new SelectList(db.HisEntities, "Id", "Name");
            return View();
        }

        // POST: HIS10/HisInstruments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,HisEntityId,Name,InsCode,Description,Specification,Remarks,Status")] HisInstrument hisInstrument)
        {
            if (ModelState.IsValid)
            {
                db.HisInstruments.Add(hisInstrument);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HisEntityId = new SelectList(db.HisEntities, "Id", "Name", hisInstrument.HisEntityId);
            return View(hisInstrument);
        }

        // GET: HIS10/HisInstruments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisInstrument hisInstrument = db.HisInstruments.Find(id);
            if (hisInstrument == null)
            {
                return HttpNotFound();
            }
            ViewBag.HisEntityId = new SelectList(db.HisEntities, "Id", "Name", hisInstrument.HisEntityId);
            return View(hisInstrument);
        }

        // POST: HIS10/HisInstruments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,HisEntityId,Name,InsCode,Description,Specification,Remarks,Status")] HisInstrument hisInstrument)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hisInstrument).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HisEntityId = new SelectList(db.HisEntities, "Id", "Name", hisInstrument.HisEntityId);
            return View(hisInstrument);
        }

        // GET: HIS10/HisInstruments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisInstrument hisInstrument = db.HisInstruments.Find(id);
            if (hisInstrument == null)
            {
                return HttpNotFound();
            }
            return View(hisInstrument);
        }

        // POST: HIS10/HisInstruments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HisInstrument hisInstrument = db.HisInstruments.Find(id);
            db.HisInstruments.Remove(hisInstrument);
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
