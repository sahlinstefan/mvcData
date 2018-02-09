SELECT Assignments.* FROM Assignments,AssignmentCourse WHERE
          AssignmentCourse.Assignment_Id = Assignments.Assignment_Id
           AND AssignmentCourse.Course_Id = 1