using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LIS.v10.Areas.Core.Models;
using LIS.v10.Areas.HIS10.Models;

namespace LIS.v10.Areas.HIS10.Controllers
{
    public class AccntUsers
    {
        public string email { get; set; }
        public string UserId { get; set; }
    }

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

            string sqlExec = 
                "select A.Email, A.Id as UserId from AspNetUsers A left outer join HisEntAdmins B on A.Id = B.AccntUserId where B.HisEntityId = " + id.ToString();
            //DbRawSqlQuery<AccntUsers> adminAccnts = db.Database.SqlQuery<AccntUsers>(sqlExec).ToList();
            List<AccntUsers> adminAccnts = db.Database.SqlQuery<AccntUsers>(sqlExec).ToList();
            ViewBag.Administrators = adminAccnts;

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
            //ViewBag.Administrators = db.HisEntAdmins.Include(d => d.HisAdmin).Where(d => d.HisEntityId == hisEntity.Id ).ToList();

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
            ViewBag.entCat = db.HisEntCats.Where(d => d.HisEntityId == id).Select(s=> s.HisCategoryId ).ToList();
            ViewBag.EntId = (int)id;

            return View(data);
        }

        [HttpPost]
        public JsonResult UpdateCategory(int catid, int entityid, string sVal)
        {
            string sqlExec = "";

            if (sVal.ToUpper() == "TRUE")
            {
                sqlExec = "Insert Into HisEntCats([HisCategoryId],[HisEntityId]) Values(" + catid.ToString() + "," + entityid.ToString() + ")";
            }
            else
            {
                sqlExec = "delete from HisEntCats where HisCategoryId = " + catid.ToString() + " AND HisEntityId = " + entityid.ToString();
            }
            if (sqlExec != "")
            {
                db.Database.ExecuteSqlCommand(sqlExec);
                db.SaveChanges();
            }

            return Json(new { code = 0, message = "Server:" + sVal });
        }

        public ActionResult Administrators(int? id)
        {
            string sqlExec = "select Email, Id as UserId from AspNetUsers";
            DbRawSqlQuery<AccntUsers> data = db.Database.SqlQuery<AccntUsers>(sqlExec);

            ViewBag.EntId = (int)id;
            ViewBag.entAdmin = db.HisEntAdmins.Where(d => d.HisEntityId == id).Select(s => s.AccntUserId).ToList();

            return View(data);
        }

        [HttpPost]
        public JsonResult UpdateAdmin(string UserId, int entityid, string sVal)
        {
            string sqlExec = "";

            if (sVal.ToUpper() == "TRUE")
            {
                sqlExec = "Insert Into HisEntAdmins([HisEntityId],[AccntUserId]) Values(" + entityid.ToString() + ",'" + UserId + "')";
            }
            else
            {
                sqlExec = "delete from HisEntAdmins where HisEntityId = " + entityid.ToString() + " AND AccntUserId = '" + UserId + "'";
            }
            if (sqlExec != "")
            {
                db.Database.ExecuteSqlCommand(sqlExec);
                db.SaveChanges();
            }

            return Json(new { code = 0, message = "Server:" + sVal });

        }

        #region Physician List
        public ActionResult EntityPhysicianList(int? id)
        {
            Session["ENTITYID"] = (int)id;
            var pIDs = db.HisEntPhysicians.Where(d => d.HisEntityId == id).Select(s => s.HisPhysicianId);
            var data = db.HisPhysicians.Where(d => pIDs.Contains(d.Id));
            return View(data);
        }

        public ActionResult AddPhysician(int? id)
        {
            //initialize Search config. to be called upon selecting an item
            TempData["SEARCHOBJ"] = new Controllers.HisPhysiciansController.SearchPhysicianConfig
            { ActionOnUse = "AddingPhysician", ControllerOnUse = "HisEntities" };

            return RedirectToAction("SearchPhysicianPage", "HisPhysicians");
        }

        public ActionResult AddingPhysician (int? SearchData)
        {
            int entityId = (int)Session["ENTITYID"];
            int pId = (int)SearchData;

            db.Database.ExecuteSqlCommand(
                "delete from HisEntPhysicians where HisPhysicianId='" + pId.ToString() + "' and HisEntityId = '" + entityId.ToString() + "'"
                );
            db.SaveChanges();


            db.Database.ExecuteSqlCommand(
                "Insert into HisEntPhysicians(HisPhysicianId,HisEntityId) values ('"+ pId.ToString() +"','"+ entityId.ToString() +"')"
                );
            db.SaveChanges();

            return RedirectToAction("EntityPhysicianList", new { id = entityId });
        }
        #endregion
        #region Operator List
        public ActionResult EntityOperatorList(int? id)
        {
            Session["ENTITYID"] = (int)id;
            var pIDs = db.HisEntOperators.Where(d => d.HisEntityId == id).Select(s => s.HisOperatorId);
            var data = db.HisOperators.Where(d => pIDs.Contains(d.Id));
            return View(data);
        }
        public ActionResult AddOperator(int? id)
        {
            //initialize Search config. to be called upon selecting an item
            TempData["SEARCHOBJ"] = new Controllers.HisOperatorsController.SearchConfig
            { ActionOnUse = "AddingOperator", ControllerOnUse = "HisEntities" };

            return RedirectToAction("SearchPage", "HisOperators");
        }
        public ActionResult AddingOperator(int? SearchData)
        {
            int entityId = (int)Session["ENTITYID"];
            int pId = (int)SearchData;

            db.Database.ExecuteSqlCommand(
                "delete from HisEntOperators where HisOperatorId='" + pId.ToString() + "' and HisEntityId = '" + entityId.ToString() + "'"
                );
            db.SaveChanges();


            db.Database.ExecuteSqlCommand(
                "Insert into HisEntOperators(HisOperatorId,HisEntityId) values ('" + pId.ToString() + "','" + entityId.ToString() + "')"
                );
            db.SaveChanges();

            return RedirectToAction("EntityOperatorList", new { id = entityId });
        }
        #endregion
        #region Instrument List
        public ActionResult EntityInstrumentList(int? id)
        {
            Session["ENTITYID"] = (int)id;
            var data = db.HisInstruments.Where(d => d.HisEntityId == id);
            return View(data);
        }

        #endregion

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

