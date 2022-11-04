using Microsoft.AspNetCore.Mvc.RazorPages;
using SevTeachersApp.DAO;
using SevTeachersApp.DTO;
using SevTeachersApp.Service;
using SevTeachersApp.Validator;

namespace SevTeachersApp.Pages.Teachers
{
    public class CreateModel : PageModel
    {
        private readonly ITeacherDAO teacherDAO = new TeacherDAOImpl();
        private readonly ITeacherService service;


        public CreateModel()
        {
            service = new TeacherServiceImpl(teacherDAO);
        }

        internal TeacherDTO teacherDto = new();
        internal string errorMessage = "";

        public void OnGet()
        {
        }

        public void OnPost()
        {
            teacherDto.Firstname = Request.Form["firstname"];
            teacherDto.Lastname = Request.Form["lastname"];

            errorMessage = TeacherValidator.Validate(teacherDto);

            if (!errorMessage.Equals("")) return;

            try
            {
                service.InsertTeacher(teacherDto);
                Response.Redirect("/Teachers/Index");

            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }
    }
}
