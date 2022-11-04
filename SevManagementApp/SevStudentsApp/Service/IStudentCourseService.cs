using SevStudentCoursesApp.DTO;
using SevStudentCoursesApp.Models;

namespace SevStudentCoursesApp.Service
{
    public interface IStudentCourseService
    {
        List<StudentCourse> GetAllStudentCourses();
        void InsertStudentCourse(StudentCourseDTO? dto);
        void UpdateStudentCourse(StudentCourseDTO? dto);
        StudentCourse? DeleteStudentCourse(StudentCourseDTO? dto);
        StudentCourse? GetStudentCourse(int student_id);


    }
}
