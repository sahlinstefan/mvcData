using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace mvcData.Models
{
    public class myMethods

    {
        public static List<Students> _listOfStudentsInCourse = new List<Students>();
        public static List<Assignments> _listOfAssignmentsInCourse = new List<Assignments>();

        private dbStudentsEntities db = new dbStudentsEntities();

        public List<Students> studentsInCourseList(int id)
        {
            string sql = "SELECT Students.* FROM Students,StudentCourse WHERE ";
            sql += "StudentCourse.Student_Id = Students.Student_Id";
            sql += " AND StudentCourse.Course_Id = '" + id + "'";
            return db.Students.SqlQuery(sql).ToList();
        }

        public List<Assignments> AssignmentsInCourseList(int id)
        {
            string sql = "SELECT Assignments.* FROM Assignments,AssignmentCourse WHERE ";
            sql += "AssignmentCourse.Assignment_Id = Assignments.Assignment_Id";
            sql += " AND AssignmentCourse.Course_Id = '" + id + "'";
            return db.Assignments.SqlQuery(sql).ToList();
        }
        public List<Teachers> findTeacher(int id)
        {
            string sql = "SELECT Teachers.* FROM Teachers,TeacherCourse WHERE ";
            sql += "Teachers.Teacher_Id = TeacherCourse.Teacher_Id";
            sql += " AND TeacherCourse.Course_Id = '" + id + "'";
            return db.Teachers.SqlQuery(sql).ToList();
        }
    }
}