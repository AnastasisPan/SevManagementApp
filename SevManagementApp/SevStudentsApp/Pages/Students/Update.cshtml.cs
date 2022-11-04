using Microsoft.AspNetCore.Mvc.RazorPages;
using SevStudentsApp.DAO;
using SevStudentsApp.DTO;
using SevStudentsApp.Models;
using SevStudentsApp.Service;
using SevStudentsApp.Validator;

namespace SevStudentsApp.Pages.Students
{
    public class UpdateModel : PageModel
    {

        private readonly IStudentDAO studentDAO = new StudentDAOImpl();
        private readonly IStudentService service;


        public UpdateModel()
        {
            service = new StudentServiceImpl(studentDAO);
        }

        internal StudentDTO studentDto = new();
        internal string errorMessage = "";


        public void OnGet()
        {
            try
            {
                Student? student;

                int id = int.Parse(Request.Query["id"]);
                student = service.GetStudent(id);

                if (student != null)
                {
                    studentDto = ConvertToDto(student);
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
            studentDto.Id = int.Parse(Request.Form["id"]);
            studentDto.Firstname = Request.Form["firstname"];
            studentDto.Lastname = Request.Form["lastname"];

            // validate
            errorMessage = StudentValidator.Validate(studentDto);

            if (!errorMessage.Equals("")) return;

            try
            {
                service.UpdateStudent(studentDto);
                Response.Redirect("/Students/Index");
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }


        private StudentDTO ConvertToDto(Student student)
        {
            return new StudentDTO()
            {
                Id = student.Id,
                Firstname = student.Firstname,
                Lastname = student.Lastname
            };
        }
    }
}
