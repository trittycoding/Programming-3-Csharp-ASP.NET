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
    public class StudentsController : Controller
    {
        private BITCollege_TravisTaylorContext db = new BITCollege_TravisTaylorContext();

        // GET: Students
        public ActionResult Index()
        {
            
            var students = db.Students.Include(s => s.gPAState).Include(s => s.program);
            string names = students.First().gPAState.Description;

            return View(students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.GPAStateId = new SelectList(db.GPAStates, "GPAStateId", "Description");
            ViewBag.ProgramId = new SelectList(db.Programs, "ProgramId", "ProgramAcronym");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "StudentId,GPAStateId,ProgramId,StudentNumber,FirstName,LastName,Address,City,Province,PostalCode,DateCreated,GradePointAverage,OutstandingFees,Notes")] Student student)
        public ActionResult Create([Bind(Include = "StudentId,GPAStateId,ProgramId,FirstName,LastName,Address,City,Province,PostalCode,DateCreated,GradePointAverage,OutstandingFees,Notes")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                student.changeState();
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GPAStateId = new SelectList(db.GPAStates, "GPAStateId", "Description", student.GPAStateId);
            ViewBag.ProgramId = new SelectList(db.Programs, "ProgramId", "ProgramAcronym", student.ProgramId);
            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.GPAStateId = new SelectList(db.GPAStates, "GPAStateId", "Description", student.GPAStateId);
            ViewBag.ProgramId = new SelectList(db.Programs, "ProgramId", "ProgramAcronym", student.ProgramId);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,GPAStateId,ProgramId,StudentNumber,FirstName,LastName,Address,City,Province,PostalCode,DateCreated,GradePointAverage,OutstandingFees,Notes")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                student.changeState();
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GPAStateId = new SelectList(db.GPAStates, "GPAStateId", "Description", student.GPAStateId);
            ViewBag.ProgramId = new SelectList(db.Programs, "ProgramId", "ProgramAcronym", student.ProgramId);
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
