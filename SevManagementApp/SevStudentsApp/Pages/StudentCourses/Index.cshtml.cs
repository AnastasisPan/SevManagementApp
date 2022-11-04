using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevStudentCoursesApp.DAO;
using SevStudentCoursesApp.Models;
using SevStudentCoursesApp.Service;

namespace SevStudentCoursesApp.Pages.StudentCourses
{
    public class IndexModel : PageModel
    {

        private readonly IStudentCourseDAO studentcourseDAO= new StudentCourseDAOImpl();
        private readonly IStudentCourseService? service;

        internal List<StudentCourse> studentcourses = new();

        public IndexModel()
        {
            service = new StudentCourseServiceImpl(studentcourseDAO);
        }

        public IActionResult OnGet()
        {
            studentcourses = service!.GetAllStudentCourses();
            return Page();
        }
    }
}
