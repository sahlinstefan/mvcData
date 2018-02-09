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
    public class StudentCoursesController : Controller
    {
        private dbStudentsEntities db = new dbStudentsEntities();

        // GET: StudentCourses
        public ActionResult Index()
        {
            var studentCourse = db.StudentCourse.Include(s => s.Courses).Include(s => s.Students);
            return View(studentCourse.ToList());
        }

        // GET: StudentCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCourse studentCourse = db.StudentCourse.Find(id);
            if (studentCourse == null)
            {
                return HttpNotFound();
            }
            return View(studentCourse);
        }

        // GET: StudentCourses/Create
        public ActionResult Create()
        {
            ViewBag.Course_Id = new SelectList(db.Courses, "Course_Id", "Course");
            ViewBag.Student_Id = new SelectList(db.Students, "Student_Id", "Name");
            return View();
        }

        // POST: StudentCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Student_Id,Course_Id")] StudentCourse studentCourse)
        {
            if (ModelState.IsValid)
            {
                db.StudentCourse.Add(studentCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Course_Id = new SelectList(db.Courses, "Course_Id", "Course", studentCourse.Course_Id);
            ViewBag.Student_Id = new SelectList(db.Students, "Student_Id", "Name", studentCourse.Student_Id);
            return View(studentCourse);
        }

        // GET: StudentCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCourse studentCourse = db.StudentCourse.Find(id);
            if (studentCourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.Course_Id = new SelectList(db.Courses, "Course_Id", "Course", studentCourse.Course_Id);
            ViewBag.Student_Id = new SelectList(db.Students, "Student_Id", "Name", studentCourse.Student_Id);
            return View(studentCourse);
        }

        // POST: StudentCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudCourse_Id,Student_Id,Course_Id")] StudentCourse studentCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Course_Id = new SelectList(db.Courses, "Course_Id", "Course", studentCourse.Course_Id);
            ViewBag.Student_Id = new SelectList(db.Students, "Student_Id", "Name", studentCourse.Student_Id);
            return View(studentCourse);
        }

        // GET: StudentCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCourse studentCourse = db.StudentCourse.Find(id);
            if (studentCourse == null)
            {
                return HttpNotFound();
            }
            return View(studentCourse);
        }

        // POST: StudentCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentCourse studentCourse = db.StudentCourse.Find(id);
            db.StudentCourse.Remove(studentCourse);
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
