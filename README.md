# EFCore_API_Demo

-- This is a simple API demo using Entity Framework Core and SQLSERVER.
-- The API has 1 controllers: 
	1. CourseContrlloer: 
		- GET: api/Course
		- GET: api/Course/{id}
		- POST: api/Course
		- PUT: api/Course/{id}
		- DELETE: api/Course/{id}
-- The API has 1 model:
	1. Course
		- CourseId
		- CourseName
-- The API has 1 DbContext:
	1. CourseContext
		- Course
-- The API has 1 Repository:
	1. CourseRepository
		- GetCourses
		- GetCourse
		- AddCourse
		- UpdateCourse
		- DeleteCourse
