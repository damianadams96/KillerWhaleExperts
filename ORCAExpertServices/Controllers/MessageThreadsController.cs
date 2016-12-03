﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ORCAExpertServices.Models;

namespace ORCAExpertServices.Controllers
{
    public class MessageThreadsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MessageThreads
        public ActionResult Index()
        {
            var messageThreads = db.MessageThreads.Include(m => m.ApplicationUser).Include(m => m.Expert);
            return View(messageThreads.ToList());
        }

        // GET: MessageThreads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageThread messageThread = db.MessageThreads.Find(id);
            if (messageThread == null)
            {
                return HttpNotFound();
            }
            return View(messageThread);
        }

        // GET: MessageThreads/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.ApplicationUsers, "Id", "Email");
            ViewBag.ExpertID = new SelectList(db.ApplicationUsers, "Id", "Email");
            return View();
        }

        // POST: MessageThreads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MessageThreadID,startDate,subject,UserID,ExpertID")] MessageThread messageThread)
        {
            if (ModelState.IsValid)
            {
                db.MessageThreads.Add(messageThread);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.ApplicationUsers, "Id", "Email", messageThread.UserID);
            ViewBag.ExpertID = new SelectList(db.ApplicationUsers, "Id", "Email", messageThread.ExpertID);
            return View(messageThread);
        }

        // GET: MessageThreads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageThread messageThread = db.MessageThreads.Find(id);
            if (messageThread == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.ApplicationUsers, "Id", "Email", messageThread.UserID);
            ViewBag.ExpertID = new SelectList(db.ApplicationUsers, "Id", "Email", messageThread.ExpertID);
            return View(messageThread);
        }

        // POST: MessageThreads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MessageThreadID,startDate,subject,UserID,ExpertID")] MessageThread messageThread)
        {
            if (ModelState.IsValid)
            {
                db.Entry(messageThread).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.ApplicationUsers, "Id", "Email", messageThread.UserID);
            ViewBag.ExpertID = new SelectList(db.ApplicationUsers, "Id", "Email", messageThread.ExpertID);
            return View(messageThread);
        }

        // GET: MessageThreads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageThread messageThread = db.MessageThreads.Find(id);
            if (messageThread == null)
            {
                return HttpNotFound();
            }
            return View(messageThread);
        }

        // POST: MessageThreads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MessageThread messageThread = db.MessageThreads.Find(id);
            db.MessageThreads.Remove(messageThread);
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
