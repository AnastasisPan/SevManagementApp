using Microsoft.AspNetCore.Mvc.RazorPages;
using SevStudentCoursesApp.DAO;
using SevStudentCoursesApp.DTO;
using SevStudentCoursesApp.Service;
using SevStudentCoursesApp.Validator;

namespace SevStudentCoursesApp.Pages.StudentCourses
{
    public class CreateModel : PageModel
    {
        private readonly IStudentCourseDAO studentcourseDAO = new StudentCourseDAOImpl();
        private readonly IStudentCourseService service;


        public CreateModel()
        {
            service = new StudentCourseServiceImpl(studentcourseDAO);
        }

        internal StudentCourseDTO studentcourseDto = new();
        internal string errorMessage = "";

        public void OnGet()
        {
        }

        public void OnPost()
        {
            studentcourseDto.StudentId = int.Parse(Request.Form["student_id"]);
            studentcourseDto.CourseId = int.Parse(Request.Form["course_id"]);

            errorMessage = StudentCourseValidator.Validate(studentcourseDto);

            if (!errorMessage.Equals("")) return;

            try
            {
                service.InsertStudentCourse(studentcourseDto);
                Response.Redirect("/StudentCourses/Index");

            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }
    }
}
