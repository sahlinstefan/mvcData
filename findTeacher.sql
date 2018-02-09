SELECT Teachers.Name FROM Teachers,TeacherCourse WHERE 
TeacherCourse.Course_Id = 1
           AND TeacherCourse.Teacher_Id = Teachers.Teacher_Id 
           