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
        public class SearchConfig
        {
            public string ActionOnUse { get; set; }
            public string ControllerOnUse { get; set; }
        }


        private His10DBContainer db = new His10DBContainer();

        // GET: HIS10/HisOperators
        public ActionResult Index()
        {
            return View(db.HisOperators.ToList());
        }

        public ActionResult SearchPage()
        {
            ViewBag.Search = "Start searching.";
            return View();
        }

        [HttpPost]
        public JsonResult Search(string search)
        {
            var data = db.HisOperators.Where(d => d.Name.Contains(search)).Select(s => new { name = s.Name, id = s.Id });
            var ret = new { message = "server: SearchOperator=" + search, code = "110" };

            return Json(data);
        }

        public ActionResult SearchUseItem(int? id)
        {
            SearchConfig config = (SearchConfig)TempData["SEARCHOBJ"];
            if (config != null)
                return RedirectToAction(config.ActionOnUse, config.ControllerOnUse, new { SearchData = id });

            return View();
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

        public ActionResult CreateLogin(int? id)
        {
            var data = db.HisOperators.Find(id);

            TempData["CREATELOGINOPERATORID"] = id;
            TempData["CREATELOGINCONFIG"] = new Core.Controllers.usersController.CreateLoginConfig
            { AccntName = data.Name, AccntRemarks = data.Remarks, ActionAfterCreate = "CreateLoginDone", ControllerAfterCreate = "HisOperators", AreaAfterCreate = "HIS10" };

            return RedirectToAction("Create", "users", new { area = "CORE" });

        }

        public ActionResult CreateLoginDone(string data)
        {
            int id = (int)TempData["CREATELOGINOPERATORID"];

            db.Database.ExecuteSqlCommand(
            "update HisOperators set AccntUserId = '" + data + "' where Id=" + id.ToString()
                );
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
