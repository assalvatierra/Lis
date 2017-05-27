﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LIS.v10.Areas.Core.Models;
using LIS.v10.Areas.HIS10.Models;

namespace LIS.v10.Areas.HIS10.Controllers
{
    public class HisPhysiciansController : Controller
    {
        private His10DBContainer db = new His10DBContainer();

        // GET: HIS10/HisPhysicians
        public ActionResult Index()
        {
            return View(db.HisPhysicians.ToList());
        }

        // GET: HIS10/HisPhysicians/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisPhysician hisPhysician = db.HisPhysicians.Find(id);
            if (hisPhysician == null)
            {
                return HttpNotFound();
            }
            return View(hisPhysician);
        }

        // GET: HIS10/HisPhysicians/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HIS10/HisPhysicians/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Remarks")] HisPhysician hisPhysician)
        {
            if (ModelState.IsValid)
            {
                db.HisPhysicians.Add(hisPhysician);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hisPhysician);
        }

        // GET: HIS10/HisPhysicians/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisPhysician hisPhysician = db.HisPhysicians.Find(id);
            if (hisPhysician == null)
            {
                return HttpNotFound();
            }
            return View(hisPhysician);
        }

        // POST: HIS10/HisPhysicians/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Remarks")] HisPhysician hisPhysician)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hisPhysician).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hisPhysician);
        }

        // GET: HIS10/HisPhysicians/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisPhysician hisPhysician = db.HisPhysicians.Find(id);
            if (hisPhysician == null)
            {
                return HttpNotFound();
            }
            return View(hisPhysician);
        }

        // POST: HIS10/HisPhysicians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HisPhysician hisPhysician = db.HisPhysicians.Find(id);
            db.HisPhysicians.Remove(hisPhysician);
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