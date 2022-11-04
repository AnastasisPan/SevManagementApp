using Microsoft.AspNetCore.Mvc.RazorPages;
using SevCoursesApp.DAO;
using SevCoursesApp.DTO;
using SevCoursesApp.Service;
using SevCoursesApp.Validator;

namespace SevCoursesApp.Pages.Courses
{
    public class CreateModel : PageModel
    {
        private readonly ICourseDAO courseDAO = new CourseDAOImpl();
        private readonly ICourseService service;


        public CreateModel()
        {
            service = new CourseServiceImpl(courseDAO);
        }

        internal CourseDTO courseDto = new();
        internal string errorMessage = "";

        public void OnGet()
        {
        }

        public void OnPost()
        {
            courseDto.Description = Request.Form["description"];
            courseDto.TeacherId = int.Parse(Request.Form["teacherid"]);

            errorMessage = CourseValidator.Validate(courseDto);

            if (!errorMessage.Equals("")) return;

            try
            {
                service.InsertCourse(courseDto);
                Response.Redirect("/Courses/Index");

            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }
    }
}
