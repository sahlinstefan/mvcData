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
    public class TeacherCoursesController : Controller
    {
        private dbStudentsEntities db = new dbStudentsEntities();

        // GET: TeacherCourses
        public ActionResult Index()
        {
            var teacherCourse = db.TeacherCourse.Include(t => t.Courses).Include(t => t.Teachers);
            return View(teacherCourse.ToList());
        }

        // GET: TeacherCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherCourse teacherCourse = db.TeacherCourse.Find(id);
            if (teacherCourse == null)
            {
                return HttpNotFound();
            }
            return View(teacherCourse);
        }

        // GET: TeacherCourses/Create
        public ActionResult Create()
        {
            ViewBag.Course_Id = new SelectList(db.Courses, "Course_Id", "Course");
            ViewBag.Teacher_Id = new SelectList(db.Teachers, "Teacher_Id", "Name");
            return View();
        }

        // POST: TeacherCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Teacher_Id,Course_Id")] TeacherCourse teacherCourse)
        {
            if (ModelState.IsValid)
            {
                db.TeacherCourse.Add(teacherCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Course_Id = new SelectList(db.Courses, "Course_Id", "Course", teacherCourse.Course_Id);
            ViewBag.Teacher_Id = new SelectList(db.Teachers, "Teacher_Id", "Name", teacherCourse.Teacher_Id);
            return View(teacherCourse);
        }

        // GET: TeacherCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherCourse teacherCourse = db.TeacherCourse.Find(id);
            if (teacherCourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.Course_Id = new SelectList(db.Courses, "Course_Id", "Course", teacherCourse.Course_Id);
            ViewBag.Teacher_Id = new SelectList(db.Teachers, "Teacher_Id", "Name", teacherCourse.Teacher_Id);
            return View(teacherCourse);
        }

        // POST: TeacherCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeacherCourse_Id,Teacher_Id,Course_Id")] TeacherCourse teacherCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacherCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Course_Id = new SelectList(db.Courses, "Course_Id", "Course", teacherCourse.Course_Id);
            ViewBag.Teacher_Id = new SelectList(db.Teachers, "Teacher_Id", "Name", teacherCourse.Teacher_Id);
            return View(teacherCourse);
        }

        // GET: TeacherCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherCourse teacherCourse = db.TeacherCourse.Find(id);
            if (teacherCourse == null)
            {
                return HttpNotFound();
            }
            return View(teacherCourse);
        }

        // POST: TeacherCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeacherCourse teacherCourse = db.TeacherCourse.Find(id);
            db.TeacherCourse.Remove(teacherCourse);
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
