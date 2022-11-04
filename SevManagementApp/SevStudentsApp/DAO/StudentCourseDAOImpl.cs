using SevStudentsApp.DAO.DBUtil;
using SevStudentCoursesApp.Models;
using System.Data.SqlClient;

namespace SevStudentCoursesApp.DAO
{
    public class StudentCourseDAOImpl : IStudentCourseDAO
    {
        public StudentCourse? Delete(StudentCourse? studentcourse)
        {
            if (studentcourse == null) return null;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open(); else return null;

                string sql = "DELETE FROM STUDENTS_COURSES WHERE STUDENT_ID = @student_id";

                using SqlCommand command = new SqlCommand(@sql, conn);

                command.Parameters.AddWithValue("@student_id", studentcourse.StudentId);

                int rowsAffected = command.ExecuteNonQuery();
                return (rowsAffected > 0) ? studentcourse : null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public List<StudentCourse> GetAll()
        {
            List<StudentCourse> studentcourses = new List<StudentCourse>();

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open();

                string sql = "SELECT * FROM STUDENTS_COURSES";

                using SqlCommand command = new SqlCommand(sql, conn);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    StudentCourse studentcourse = new StudentCourse()
                    {
                        StudentId = reader.GetInt32(0),
                        CourseId = reader.GetInt32(1)
                    };

                    studentcourses.Add(studentcourse);
                }

                return studentcourses;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public StudentCourse? GetStudentCourse(int student_id)
        {
            StudentCourse? studentcourse = null;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open();

                string sql = "SELECT * FROM STUDENTS_COURSES WHERE STUDENT_ID = @student_id";

                using SqlCommand command = new SqlCommand(sql, conn);

                command.Parameters.AddWithValue("@student_id", student_id);

                using SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    studentcourse = new StudentCourse()
                    {
                        StudentId = reader.GetInt32(0),
                        CourseId = reader.GetInt32(1)
                    };
                }

                return studentcourse;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public void Insert(StudentCourse? studentcourse)
        {
            if (studentcourse == null) return;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open(); else return;

                string sql = "INSERT INTO STUDENTS_COURSES " +
                    "(STUDENT_ID, COURSE_ID) VALUES " +
                    "(@student_id, @course_id)";

                using SqlCommand command = new SqlCommand(@sql, conn);

                command.Parameters.AddWithValue("@student_id", studentcourse.StudentId);
                command.Parameters.AddWithValue("@course_id", studentcourse.CourseId);

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public void Update(StudentCourse? studentcourse)
        {
            if (studentcourse == null) return;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open(); else return;

                string sql = "UPDATE STUDENTS_COURSES SET STUDENT_ID = @student_id, " +
                    "COURSE_ID = @course_id";

                using SqlCommand command = new SqlCommand(@sql, conn);

                command.Parameters.AddWithValue("@student_id", studentcourse.StudentId);
                command.Parameters.AddWithValue("@course_id", studentcourse.CourseId);

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }
    }
}
