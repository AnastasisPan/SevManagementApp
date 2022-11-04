using SevStudentsApp.DTO;
using SevStudentsApp.Models;

namespace SevStudentsApp.Service
{
    public interface IStudentService
    {
        List<Student> GetAllStudents();
        void InsertStudent(StudentDTO? dto);
        void UpdateStudent(StudentDTO? dto);
        Student? DeleteStudent(StudentDTO? dto);
        Student? GetStudent(int id);


    }
}
