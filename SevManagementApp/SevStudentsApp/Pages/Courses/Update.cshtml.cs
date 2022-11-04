using Microsoft.AspNetCore.Mvc.RazorPages;
using SevCoursesApp.DAO;
using SevCoursesApp.DTO;
using SevCoursesApp.Models;
using SevCoursesApp.Service;
using SevCoursesApp.Validator;

namespace SevCoursesApp.Pages.Courses
{
    public class UpdateModel : PageModel
    {

        private readonly ICourseDAO courseDAO = new CourseDAOImpl();
        private readonly ICourseService service;


        public UpdateModel()
        {
            service = new CourseServiceImpl(courseDAO);
        }

        internal CourseDTO courseDto = new();
        internal string errorMessage = "";


        public void OnGet()
        {
            try
            {
                Course? course;

                int id = int.Parse(Request.Query["id"]);
                course = service.GetCourse(id);

                if (course != null)
                {
                    courseDto = ConvertToDto(course);
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
            courseDto.Id = int.Parse(Request.Form["id"]);
            courseDto.Description = Request.Form["description"];
            courseDto.TeacherId = int.Parse(Request.Form["teacherid"]);

            // validate
            errorMessage = CourseValidator.Validate(courseDto);

            if (!errorMessage.Equals("")) return;

            try
            {
                service.UpdateCourse(courseDto);
                Response.Redirect("/Courses/Index");
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }


        private CourseDTO ConvertToDto(Course course)
        {
            return new CourseDTO()
            {
                Id = course.Id,
                Description = course.Description,
                TeacherId = course.TeacherId
            };
        }
    }
}
