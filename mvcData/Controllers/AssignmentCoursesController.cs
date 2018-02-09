using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvcData.Models;

namespace mvcData.Controllers
{
    public class AssignmentCoursesController : Controller
    {
        private dbStudentsEntities db = new dbStudentsEntities();

        // GET: AssignmentCourses
        public ActionResult Index()
        {
            var assignmentCourse = db.AssignmentCourse.Include(a => a.Assignments).Include(a => a.Courses);
            return View(assignmentCourse.ToList());
        }

        // GET: AssignmentCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignmentCourse assignmentCourse = db.AssignmentCourse.Find(id);
            if (assignmentCourse == null)
            {
                return HttpNotFound();
            }
            return View(assignmentCourse);
        }

        // GET: AssignmentCourses/Create
        public ActionResult Create()
        {
            ViewBag.Assignment_Id = new SelectList(db.Assignments, "Assignment_Id", "Name");
            ViewBag.Course_Id = new SelectList(db.Courses, "Course_Id", "Course");
            return View();
        }

        // POST: AssignmentCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Assignment_Id,Course_Id")] AssignmentCourse assignmentCourse)
        {
            if (ModelState.IsValid)
            {
                db.AssignmentCourse.Add(assignmentCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Assignment_Id = new SelectList(db.Assignments, "Assignment_Id", "Name", assignmentCourse.Assignment_Id);
            ViewBag.Course_Id = new SelectList(db.Courses, "Course_Id", "Course", assignmentCourse.Course_Id);
            return View(assignmentCourse);
        }

        // GET: AssignmentCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignmentCourse assignmentCourse = db.AssignmentCourse.Find(id);
            if (assignmentCourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.Assignment_Id = new SelectList(db.Assignments, "Assignment_Id", "Name", assignmentCourse.Assignment_Id);
            ViewBag.Course_Id = new SelectList(db.Courses, "Course_Id", "Course", assignmentCourse.Course_Id);
            return View(assignmentCourse);
        }

        // POST: AssignmentCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssignmentCourse_Id,Assignment_Id,Course_Id")] AssignmentCourse assignmentCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assignmentCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Assignment_Id = new SelectList(db.Assignments, "Assignment_Id", "Name", assignmentCourse.Assignment_Id);
            ViewBag.Course_Id = new SelectList(db.Courses, "Course_Id", "Course", assignmentCourse.Course_Id);
            return View(assignmentCourse);
        }

        // GET: AssignmentCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignmentCourse assignmentCourse = db.AssignmentCourse.Find(id);
            if (assignmentCourse == null)
            {
                return HttpNotFound();
            }
            return View(assignmentCourse);
        }

        // POST: AssignmentCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssignmentCourse assignmentCourse = db.AssignmentCourse.Find(id);
            db.AssignmentCourse.Remove(assignmentCourse);
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
