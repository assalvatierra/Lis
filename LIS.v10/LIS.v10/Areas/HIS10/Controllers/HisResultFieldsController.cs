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
            if (Session["ORDERTYPEID"] != null)
            {
                int ordertypeid = (int)Session["ORDERTYPEID"];
                hisResultFields = hisResultFields.Where(d => d.HisOrderTypeId == ordertypeid);
            }

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
            int ordertypeid = 0;
            int seqno = 0;
            Models.HisResultField hrf = new HisResultField();

            if (Session["ORDERTYPEID"]!=null)
                ordertypeid = (int)Session["ORDERTYPEID"];

            if (ordertypeid != 0)
            {
                hrf.HisOrderTypeId = ordertypeid;

                var tmp1 = db.HisResultFields.Where(d => d.HisOrderTypeId == ordertypeid);
                seqno = 10 * ( tmp1.Count() + 1 );
                hrf.SeqNo = seqno;
            }

            ViewBag.HisOrderTypeId = new SelectList(db.HisOrderTypes, "Id", "Description", ordertypeid);
            ViewBag.AddForType = new SelectList(new List<SelectListItem> {
                new SelectListItem { Text = "Optional", Value = "0"},
                new SelectListItem { Text = "Always Add to Service", Value = "1" }
            }, "Value", "Text");

            return View(hrf);
        }

        // POST: HIS10/HisResultFields/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,HisOrderTypeId,Name,Desc,SeqNo, minValue, maxValue, Uom, AddForType")] HisResultField hisResultField)
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
            ViewBag.AddForType = new SelectList(new List<SelectListItem> {
                new SelectListItem { Text = "Optional", Value = "0"},
                new SelectListItem { Text = "Always Add to Service", Value = "1" }
            }, "Value","Text", hisResultField.AddForType);

            return View(hisResultField);
        }

        // POST: HIS10/HisResultFields/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,HisOrderTypeId,Name,Desc,SeqNo, minValue, maxValue, Uom, AddForType")] HisResultField hisResultField)
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


        public ActionResult OrderTypeFields(int? typeId)
        {
            Session["ORDERTYPEID"] = (int)typeId;

            if( typeId != null && typeId > 0)
            {
                ViewBag.orderType = db.HisOrderTypes.Find(typeId);
            }

            var hisResultFields = db.HisResultFields.Include(h => h.HisOrderType).Where(d=>d.HisOrderTypeId==typeId);
            return View("index", hisResultFields.ToList());
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
