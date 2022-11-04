using SevTeachersApp.DTO;

namespace SevTeachersApp.Validator
{
    public class TeacherValidator
    {
        //No instances of this class should be available
        private TeacherValidator() { }

        public static string Validate(TeacherDTO? dto)
        {
            if ((dto!.Firstname!.Length <= 2) ||
                (dto!.Lastname!.Length <= 2))
            {
                return "Firstname or Lastname should not be less than three characters";
            }

            return "";
        }
    }
}