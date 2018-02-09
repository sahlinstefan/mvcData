SELECT Students.* FROM Students,StudentCourse WHERE
            StudentCourse.Student_Id = Students.Student_Id
            AND StudentCourse.Course_Id = 1