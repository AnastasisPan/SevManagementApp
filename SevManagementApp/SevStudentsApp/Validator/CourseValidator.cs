using SevCoursesApp.DTO;

namespace SevCoursesApp.Validator
{
    public class CourseValidator
    {
        //No instances of this class should be available
        private CourseValidator() { }

        public static string Validate(CourseDTO? dto)
        {
            if ((dto!.Description!.Length <= 1))
            {
                return "Description should not be less than two characters";
            }

            return "";
        }
    }
}
