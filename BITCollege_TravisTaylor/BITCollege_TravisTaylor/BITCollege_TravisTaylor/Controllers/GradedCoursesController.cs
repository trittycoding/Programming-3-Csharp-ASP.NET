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
    public class GradedCoursesController : Controller
    {
        private BITCollege_TravisTaylorContext db = new BITCollege_TravisTaylorContext();

        // GET: GradedCourses
        public ActionResult Index()
        {
            var courses = db.Courses.Include(g => g.program);
            return View(db.GradedCourses.ToList());
        }

        // GET: GradedCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GradedCourse gradedCourse = (GradedCourse)db.Courses.Find(id);
            if (gradedCourse == null)
            {
                return HttpNotFound();
            }
            return View(gradedCourse);
        }

        // GET: GradedCourses/Create
        public ActionResult Create()
        {
            ViewBag.ProgramId = new SelectList(db.Programs, "ProgramId", "Description");
            return View();
        }

        // POST: GradedCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseId,ProgramId,Title,CreditHours,TuitionAmount,Notes,AssignmentWeight,MidtermWeight,FinalWeight")] GradedCourse gradedCourse)
        //public ActionResult Create([Bind(Include = "CourseId,ProgramId,CourseNumber,Title,CreditHours,TuitionAmount,Notes,AssignmentWeight,MidtermWeight,FinalWeight")] GradedCourse gradedCourse)
        {
            if (ModelState.IsValid)
            {
                gradedCourse.setNextCourseNumber(); //is this right
                db.Courses.Add(gradedCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProgramId = new SelectList(db.Programs, "ProgramId", "Description", gradedCourse.ProgramId);
            return View(gradedCourse);
        }

        // GET: GradedCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GradedCourse gradedCourse = (GradedCourse)db.Courses.Find(id);
            if (gradedCourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProgramId = new SelectList(db.Programs, "ProgramId", "Description", gradedCourse.ProgramId);
            return View(gradedCourse);
        }

        // POST: GradedCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseId,ProgramId,CourseNumber,Title,CreditHours,TuitionAmount,Notes,AssignmentWeight,MidtermWeight,FinalWeight")] GradedCourse gradedCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gradedCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProgramId = new SelectList(db.Programs, "ProgramId", "Description", gradedCourse.ProgramId);
            return View(gradedCourse);
        }

        // GET: GradedCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GradedCourse gradedCourse = (GradedCourse)db.Courses.Find(id);
            if (gradedCourse == null)
            {
                return HttpNotFound();
            }
            return View(gradedCourse);
        }

        // POST: GradedCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GradedCourse gradedCourse = (GradedCourse)db.Courses.Find(id);
            db.Courses.Remove(gradedCourse);
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
