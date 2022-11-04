using SevStudentCoursesApp.Models;

namespace SevStudentCoursesApp.DAO
{
    public interface IStudentCourseDAO
    {
        void Insert(StudentCourse? studentcourse);
        void Update(StudentCourse? studentcourse);
        StudentCourse? Delete(StudentCourse? studentcourse);
        StudentCourse? GetStudentCourse(int student_id);
        List<StudentCourse> GetAll();
    }
}
