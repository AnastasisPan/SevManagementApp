using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevTeachersApp.DAO;
using SevTeachersApp.Models;
using SevTeachersApp.Service;

namespace SevTeachersApp.Pages.Teachers
{
    public class IndexModel : PageModel
    {

        private readonly ITeacherDAO teacherDAO= new TeacherDAOImpl();
        private readonly ITeacherService? service;

        internal List<Teacher> teachers = new();

        public IndexModel()
        {
            service = new TeacherServiceImpl(teacherDAO);
        }

        public IActionResult OnGet()
        {
            teachers = service!.GetAllTeachers();
            return Page();
        }
    }
}
