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
    public class HisOperatorsController : Controller
    {
        private His10DBContainer db = new His10DBContainer();

        // GET: HIS10/HisOperators
        public ActionResult Index()
        {
            return View(db.HisOperators.ToList());
        }

        // GET: HIS10/HisOperators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisOperator hisOperator = db.HisOperators.Find(id);
            if (hisOperator == null)
            {
                return HttpNotFound();
            }
            return View(hisOperator);
        }

        // GET: HIS10/HisOperators/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HIS10/HisOperators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Remarks,AccntUserId")] HisOperator hisOperator)
        {
            if (ModelState.IsValid)
            {
                db.HisOperators.Add(hisOperator);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hisOperator);
        }

        // GET: HIS10/HisOperators/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisOperator hisOperator = db.HisOperators.Find(id);
            if (hisOperator == null)
            {
                return HttpNotFound();
            }
            return View(hisOperator);
        }

        // POST: HIS10/HisOperators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Remarks,AccntUserId")] HisOperator hisOperator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hisOperator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hisOperator);
        }

        // GET: HIS10/HisOperators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisOperator hisOperator = db.HisOperators.Find(id);
            if (hisOperator == null)
            {
                return HttpNotFound();
            }
            return View(hisOperator);
        }

        // POST: HIS10/HisOperators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HisOperator hisOperator = db.HisOperators.Find(id);
            db.HisOperators.Remove(hisOperator);
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
