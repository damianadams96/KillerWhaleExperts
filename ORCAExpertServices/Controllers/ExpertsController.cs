using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ORCAExpertServices.Models;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Web.Security;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ORCAExpertServices.Controllers
{
    public class ExpertsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Experts
        public ActionResult Index()
        {
            var applicationUsers = db.ApplicationUsers.Include(e => e.ListExpertise);
            return View(applicationUsers.ToList());
        }

        // GET: Experts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expert expert = db.ApplicationUsers.Find(id);
            if (expert == null)
            {
                return HttpNotFound();
            }
            return View(expert);
        }

        // GET: Experts/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.ListExpertises, "ExpertID", "ExpertID");
            return View();
        }

        // POST: Experts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,PhoneNumber,UserName,IsAnExpert,Validated")] Expert expert)
        {
            if (ModelState.IsValid)
            {
                var manager = new UserManager<ApplicationUser>(new Microsoft.AspNet.Identity.EntityFramework.UserStore<ApplicationUser>(new ApplicationDbContext()));
                IdentityUser currentUser = manager.FindById(User.Identity.GetUserId());

                manager.AddToRole(currentUser.Id, "Expert");
                manager.RemoveFromRole(currentUser.Id, "User");

                db.ApplicationUsers.Add(expert);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.ListExpertises, "ExpertID", "ExpertID", expert.Id);
            return View(expert);
        }

        // GET: Experts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expert expert = db.ApplicationUsers.Find(id);
            if (expert == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.ListExpertises, "ExpertID", "ExpertID", expert.Id);
            return View(expert);
        }

        // POST: Experts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,IsAnExpert,Validated")] Expert expert)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expert).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.ListExpertises, "ExpertID", "ExpertID", expert.Id);
            return View(expert);
        }

        // GET: Experts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expert expert = db.ApplicationUsers.Find(id);
            if (expert == null)
            {
                return HttpNotFound();
            }
            return View(expert);
        }

        // POST: Experts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Expert expert = db.ApplicationUsers.Find(id);
            db.ApplicationUsers.Remove(expert);
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
