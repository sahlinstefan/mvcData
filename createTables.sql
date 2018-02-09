

Drop table [Assignments];
Drop table [Teachers];
Drop table [TeacherCourse];
Drop table [Assignments];
Drop table [AssignmentCourse];
Drop table [StudentCourse];
Drop table [Students];

Drop table [Courses];

CREATE TABLE [dbo].[Students] (
    [Student_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name]       NCHAR (20) NOT NULL,
    [Phone]      NCHAR (10) NOT NULL,
    [City]       NCHAR (20) NOT NULL
   
);

CREATE TABLE [dbo].[Teachers](
[Teacher_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NCHAR(10) NULL, 
    [Phone] NCHAR(10) NULL
);

CREATE TABLE [dbo].[Courses] (
    [Course_Id]  INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name]        NCHAR (10) NOT NULL,
    [Title]       NCHAR (10) NOT NULL,
    [Description] NCHAR (10) NOT NULL,
);

CREATE TABLE [dbo].[StudentCourse]
(
	[StudCourse_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Student_Id] INT NOT NULL, 
    [Course_Id] INT NOT NULL,
	 CONSTRAINT [FK_StudentCources_Student_Id] FOREIGN KEY ([Student_Id]) REFERENCES [Students]([Student_Id]),
	 CONSTRAINT [FK_StudentCourses_Course_Id] FOREIGN KEY ([Course_Id]) REFERENCES [Courses]([Course_Id])
);

CREATE TABLE [dbo].[Assignments]
(
	[Assignment_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NCHAR(15) NOT NULL, 
    [Description] NCHAR(30) NOT NULL
 
);
CREATE TABLE [dbo].[TeacherCourse]
(
	[TeacherCourse_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Teacher_Id] INT NOT NULL, 
    [Course_Id] INT NOT NULL,
	 CONSTRAINT [FK_TeacherCourse_Teacher_Id] FOREIGN KEY ([Teacher_Id]) REFERENCES [Teachers]([Teacher_Id]),
	 CONSTRAINT [FK_TeacherCourse_Course_Id] FOREIGN KEY ([Course_Id]) REFERENCES [Courses]([Course_Id])
);
CREATE TABLE [dbo].[AssignmentCourse]
(
	[AssignmentCourse_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Assignment_Id] INT NOT NULL, 
    [Course_Id] INT NOT NULL,
	 CONSTRAINT [FK_AssignmentCourse_Assignment_Id] FOREIGN KEY ([Assignment_Id]) REFERENCES [Assignments]([Assignment_Id]),
	 CONSTRAINT [FK_AssignmentCourse_Course_Id] FOREIGN KEY ([Course_Id]) REFERENCES [Courses]([Course_Id])
);
