using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LIS.v10.Areas.Core.Models;

//FOR ASP NET ACCOUNT REGISTRATION
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using LIS.v10.Models;

namespace LIS.v10.Areas.Core.Controllers
{
    public class usersController : Controller
    {
        public class CreateLoginConfig
        {
            public string AccntName { get; set; }
            public string AccntRemarks { get; set; }
            public string ActionAfterCreate { get; set; }
            public string ControllerAfterCreate { get; set; }
            public string AreaAfterCreate { get; set; }
        }

        private CoreDBContainer db = new CoreDBContainer();

        // GET: Core/users
        public ActionResult Index()
        {
            return View(db.users.ToList());
        }

        // GET: Core/users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Core/users/Create
        public ActionResult Create()
        {
            Core.Models.user newuser = new user();
            if (TempData.ContainsKey("CREATELOGINCONFIG"))
            {
                CreateLoginConfig actionConfig = (CreateLoginConfig)TempData.Peek("CREATELOGINCONFIG");
                newuser.Fullname = actionConfig.AccntName;
                newuser.Remarks = actionConfig.AccntRemarks;
            }

            return View(newuser);
        }

        // POST: Core/users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,Fullname,Remarks,Email,Password,Status")] user user)
        {
            if (ModelState.IsValid)
            {
                ApplicationUserManager _UserManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var newuser = new ApplicationUser { UserName = user.Email, Email = user.Email };

                try
                {
                    var result = _UserManager.Create(newuser, user.Password);

                    if (result.Succeeded)
                    {
                        user.Status = "ACT";
                        user.UserId = newuser.Id;

                        db.users.Add(user);
                        db.SaveChanges();
                    }
                }
                catch( Exception e)
                {
                    ViewBag.errorMsg = e.Message;
                }

                if ( TempData.ContainsKey("CREATELOGINCONFIG") )
                {
                    CreateLoginConfig actionConfig = (CreateLoginConfig)TempData["CREATELOGINCONFIG"];
                    return RedirectToAction(actionConfig.ActionAfterCreate, actionConfig.ControllerAfterCreate, new { area = actionConfig.AreaAfterCreate, data = newuser.Id });
                }
                
                return RedirectToAction("Index");
            }

            return View(user);
        }


        // GET: Core/users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Core/users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,Fullname,Remarks,Email,Password,Status")] user user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Core/users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Core/users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            user user = db.users.Find(id);
            db.users.Remove(user);
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
