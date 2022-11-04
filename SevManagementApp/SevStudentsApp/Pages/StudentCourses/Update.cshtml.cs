using Microsoft.AspNetCore.Mvc.RazorPages;
using SevStudentCoursesApp.DAO;
using SevStudentCoursesApp.DTO;
using SevStudentCoursesApp.Models;
using SevStudentCoursesApp.Service;
using SevStudentCoursesApp.Validator;

namespace SevStudentCoursesApp.Pages.StudentCourses
{
    public class UpdateModel : PageModel
    {

        private readonly IStudentCourseDAO studentcourseDAO = new StudentCourseDAOImpl();
        private readonly IStudentCourseService service;


        public UpdateModel()
        {
            service = new StudentCourseServiceImpl(studentcourseDAO);
        }

        internal StudentCourseDTO studentcourseDto = new();
        internal string errorMessage = "";


        public void OnGet()
        {
            try
            {
                StudentCourse? studentcourse;

                int student_id = int.Parse(Request.Query["student_id"]);
                studentcourse = service.GetStudentCourse(student_id);

                if (studentcourse != null)
                {
                    studentcourseDto = ConvertToDto(studentcourse);
                }
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }

        public void OnPost()
        {
            errorMessage = "";
            // Get DTO
            studentcourseDto.StudentId = int.Parse(Request.Form["student_id"]);
            studentcourseDto.CourseId = int.Parse(Request.Form["course_id"]);

            // validate
            errorMessage = StudentCourseValidator.Validate(studentcourseDto);

            if (!errorMessage.Equals("")) return;

            try
            {
                service.UpdateStudentCourse(studentcourseDto);
                Response.Redirect("/StudentCourses/Index");
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }


        private StudentCourseDTO ConvertToDto(StudentCourse studentcourse)
        {
            return new StudentCourseDTO()
            {
                StudentId = studentcourse.StudentId,
                CourseId = studentcourse.CourseId
            };
        }
    }
}
