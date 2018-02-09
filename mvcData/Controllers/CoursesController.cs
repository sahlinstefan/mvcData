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
    public class CoursesController : Controller
    {
        private dbStudentsEntities db = new dbStudentsEntities();
        public ActionResult Index()
        {
           
            return View(db.Courses.ToList());
        }
        public ActionResult Details(int id)
        {
           
            //if (id == null)
            //{
               
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            Courses courses = db.Courses.Find(id);
            if (courses == null)
            {
                return HttpNotFound();
            }
            myMethods obj = new myMethods();
            List<Teachers> tlist = new List<Teachers>();

            tlist = obj.findTeacher(id);
            Teachers teacherobj = new Teachers();
            teacherobj = tlist.ElementAt(0);
            ViewData["Teacher"] = teacherobj.Name;
            return View(courses);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Course,Title,Description")] Courses courses)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(courses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courses);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Courses courses = db.Courses.Find(id);
            if (courses == null)
            {
                return HttpNotFound();
            }
            return View(courses);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Course_Id,Course,Title,Description")] Courses courses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courses);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Courses courses = db.Courses.Find(id);
            if (courses == null)
            {
                return HttpNotFound();
            }
            return View(courses);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Courses courses = db.Courses.Find(id);
            db.Courses.Remove(courses);
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



        public ActionResult StudentsInCourse(int id)
        {
            myMethods obj = new myMethods();
            myMethods._listOfStudentsInCourse = obj.studentsInCourseList(id);
            return PartialView("partialStudentsInCourse", myMethods._listOfStudentsInCourse);
        }
        public ActionResult AssignmentsInCourse(int id)
        {
            myMethods obj = new myMethods();
            myMethods._listOfAssignmentsInCourse = obj.AssignmentsInCourseList(id);
            return PartialView("partialAssignmentsInCourse", myMethods._listOfAssignmentsInCourse);
        }

        
       
    }
}
