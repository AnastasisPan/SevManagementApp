using SevStudentCoursesApp.DTO;

namespace SevStudentCoursesApp.Validator
{
    public class StudentCourseValidator
    {
        //No instances of this class should be available
        private StudentCourseValidator() { }

        public static string Validate(StudentCourseDTO? dto)
        {
            if ((dto!.StudentId!.ToString().Length <= 1))
            {
                return "Student ID and Course ID should not be less than one digit";
            }

            return "";
        }
    }
}
