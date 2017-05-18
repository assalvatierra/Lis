using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LIS.v10.Areas.Core.Models;

namespace LIS.v10.Areas.Core.Controllers
{
    public class userGroupsController : Controller
    {
        private CoreDBContainer db = new CoreDBContainer();

        // GET: Core/userGroups
        public ActionResult Index()
        {
            return View(db.userGroups.ToList());
        }

        // GET: Core/userGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userGroup userGroup = db.userGroups.Find(id);
            if (userGroup == null)
            {
                return HttpNotFound();
            }
            return View(userGroup);
        }

        // GET: Core/userGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Core/userGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] userGroup userGroup)
        {
            if (ModelState.IsValid)
            {
                db.userGroups.Add(userGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userGroup);
        }

        // GET: Core/userGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userGroup userGroup = db.userGroups.Find(id);
            if (userGroup == null)
            {
                return HttpNotFound();
            }
            return View(userGroup);
        }

        // POST: Core/userGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] userGroup userGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userGroup);
        }

        // GET: Core/userGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userGroup userGroup = db.userGroups.Find(id);
            if (userGroup == null)
            {
                return HttpNotFound();
            }
            return View(userGroup);
        }

        // POST: Core/userGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            userGroup userGroup = db.userGroups.Find(id);
            db.userGroups.Remove(userGroup);
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
