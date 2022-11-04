using Microsoft.AspNetCore.Mvc.RazorPages;
using SevStudentCoursesApp.DAO;
using SevStudentCoursesApp.DTO;
using SevStudentCoursesApp.Models;
using SevStudentCoursesApp.Service;

namespace SevStudentCoursesApp.Pages.StudentCourses
{
    public class DeleteModel : PageModel
    {
        private readonly IStudentCourseDAO studentcourseDAO = new StudentCourseDAOImpl();
        private readonly IStudentCourseService? service;

        internal string errorMessage = "";

        public DeleteModel()
        {
            service = new StudentCourseServiceImpl(studentcourseDAO);
        }

        public void OnGet()
        {
            StudentCourseDTO studentcourseDTO = new();

            try
            {
                StudentCourse? studentcourse;

                int student_id = int.Parse(Request.Query["student_id"]);

                studentcourseDTO.StudentId = student_id;
                studentcourse = service?.DeleteStudentCourse(studentcourseDTO);
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
