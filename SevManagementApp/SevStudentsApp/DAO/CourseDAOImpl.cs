﻿using SevStudentsApp.DAO.DBUtil;
using SevCoursesApp.Models;
using System.Data.SqlClient;

namespace SevCoursesApp.DAO
{
    public class CourseDAOImpl : ICourseDAO
    {
        public Course? Delete(Course? course)
        {
            if (course == null) return null;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open(); else return null;

                string sql = "DELETE FROM COURSES WHERE ID = @id";

                using SqlCommand command = new SqlCommand(@sql, conn);

                command.Parameters.AddWithValue("@id", course.Id);

                int rowsAffected = command.ExecuteNonQuery();
                return (rowsAffected > 0) ? course : null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public List<Course> GetAll()
        {
            List<Course> courses = new List<Course>();

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open();

                string sql = "SELECT * FROM COURSES";

                using SqlCommand command = new SqlCommand(sql, conn);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Course course = new Course()
                    {
                        Id = reader.GetInt32(0),
                        Description = reader.GetString(1),
                        TeacherId = reader.GetInt32(2)
                    };

                    courses.Add(course);
                }

                return courses;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public Course? GetCourse(int id)
        {
            Course? course = null;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open();

                string sql = "SELECT * FROM COURSES WHERE ID = @id";

                using SqlCommand command = new SqlCommand(sql, conn);

                command.Parameters.AddWithValue("@id", id);

                using SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    course = new Course()
                    {
                        Id = reader.GetInt32(0),
                        Description = reader.GetString(1),
                        TeacherId = reader.GetInt32(2)
                    };
                }

                return course;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public void Insert(Course? course)
        {
            if (course == null) return;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open(); else return;

                string sql = "INSERT INTO COURSES " +
                    "(DESCRIPTION, TEACHER_ID) VALUES " +
                    "(@description, @teacherid)";

                using SqlCommand command = new SqlCommand(@sql, conn);

                command.Parameters.AddWithValue("@description", course.Description);
                command.Parameters.AddWithValue("@teacherid", course.TeacherId);

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public void Update(Course? course)
        {
            if (course == null) return;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open(); else return;

                string sql = "UPDATE COURSES SET DESCRIPTION = @description, " +
                    "TEACHER_ID = @teacherid WHERE ID = @id";

                using SqlCommand command = new SqlCommand(@sql, conn);

                command.Parameters.AddWithValue("@description", course.Description);
                command.Parameters.AddWithValue("@teacherid", course.TeacherId);
                command.Parameters.AddWithValue("@id", course.Id);

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
