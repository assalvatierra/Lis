using System;
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
    public class HisEntitiesController : Controller
    {
        private His10DBContainer db = new His10DBContainer();

        // GET: HIS10/HisEntities
        public ActionResult Index()
        {
            return View(db.HisEntities.ToList());
        }

        // GET: HIS10/HisEntities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisEntity hisEntity = db.HisEntities.Find(id);
            if (hisEntity == null)
            {
                return HttpNotFound();
            }
            return View(hisEntity);
        }

        // GET: HIS10/HisEntities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HIS10/HisEntities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Remarks,Address,Contact")] HisEntity hisEntity)
        {
            if (ModelState.IsValid)
            {
                db.HisEntities.Add(hisEntity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hisEntity);
        }


        // GET: HIS10/HisEntities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisEntity hisEntity = db.HisEntities.Find(id);
            if (hisEntity == null)
            {
                return HttpNotFound();
            }

            ViewBag.Categories = db.HisEntCats.Include(d => d.HisCategory).Where(d => d.HisEntityId == id).ToList();
            ViewBag.Administrators = db.HisEntAdmins.Include(d => d.HisAdmin).Where(d => d.HisEntityId == id).ToList();

            return View(hisEntity);
        }

        // POST: HIS10/HisEntities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Remarks,Address,Contact")] HisEntity hisEntity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hisEntity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categories = db.HisEntCats.Include(d => d.HisCategory).Where(d => d.HisEntityId == hisEntity.Id ).ToList();
            ViewBag.Administrators = db.HisEntAdmins.Include(d => d.HisAdmin).Where(d => d.HisEntityId == hisEntity.Id ).ToList();

            return View(hisEntity);
        }

        // GET: HIS10/HisEntities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisEntity hisEntity = db.HisEntities.Find(id);
            if (hisEntity == null)
            {
                return HttpNotFound();
            }
            return View(hisEntity);
        }

        // POST: HIS10/HisEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HisEntity hisEntity = db.HisEntities.Find(id);
            db.HisEntities.Remove(hisEntity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Categories(int? id)
        {
            var data = db.HisCategories.OrderBy(s => s.SeqNo);
            ViewBag.entCat = db.HisEntCats.Where(d => d.HisEntityId == id).Select(s=> s.HisEntityId ).ToList();
            ViewBag.EntId = (int)id;

            return View(data);
        }

        public ActionResult Administrators(int? id)
        {
            var data = db.HisAdmins;
            return View(data);
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
