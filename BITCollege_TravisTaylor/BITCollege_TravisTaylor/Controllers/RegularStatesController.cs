﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BITCollege_TravisTaylor.Models;

namespace BITCollege_TravisTaylor.Controllers
{
    public class RegularStatesController : Controller
    {
        private BITCollege_TravisTaylorContext db = new BITCollege_TravisTaylorContext();

        // GET: RegularStates
        public ActionResult Index()
        {
            return View(RegularState.getInstance());
        }

        // GET: RegularStates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegularState regularState = (RegularState)db.GPAStates.Find(id);
            if (regularState == null)
            {
                return HttpNotFound();
            }
            return View(regularState);
        }

        // GET: RegularStates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegularStates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GPAStateId,LowerLimit,UpperLimit,TuitionRateFactor")] RegularState regularState)
        {
            if (ModelState.IsValid)
            {
                db.GPAStates.Add(regularState);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(regularState);
        }

        // GET: RegularStates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegularState regularState = (RegularState)db.GPAStates.Find(id);
            if (regularState == null)
            {
                return HttpNotFound();
            }
            return View(regularState);
        }

        // POST: RegularStates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GPAStateId,LowerLimit,UpperLimit,TuitionRateFactor")] RegularState regularState)
        {
            if (ModelState.IsValid)
            {
                db.Entry(regularState).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(regularState);
        }

        // GET: RegularStates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegularState regularState = (RegularState)db.GPAStates.Find(id);
            if (regularState == null)
            {
                return HttpNotFound();
            }
            return View(regularState);
        }

        // POST: RegularStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegularState regularState = (RegularState)db.GPAStates.Find(id);
            db.GPAStates.Remove(regularState);
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
