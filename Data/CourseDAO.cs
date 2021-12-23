using BeanAndBrew.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BeanAndBrew.Data
{
    public class CourseDAO
    {
        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\0008959\Downloads\_Code_Projects\ASPNET\BeanAndBrew\App_Data\BeanAndBrew.mdf;Integrated Security=True";

        public List<CourseModel> FetchAll()
        {
            List<CourseModel> returnCourseList = new List<CourseModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM dbo.Course";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        CourseModel course = new CourseModel();
                        course.CourseId = dr.GetInt32(0);
                        course.Title = dr.GetString(1);
                        course.Description = dr.GetString(2);
                        course.Date = dr.GetDateTime(3);
                        course.Price = dr.GetDecimal(4);

                        returnCourseList.Add(course);
                    }
                }
            }
            return returnCourseList;

        }
        public CourseModel FetchOne(int id)
        {
            CourseModel course = new CourseModel();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM dbo.Course WHERE CourseId=@id";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        course.CourseId = dr.GetInt32(0);
                        course.Title = dr.GetString(1);
                        course.Description = dr.GetString(2);
                        course.Date = dr.GetDateTime(3);
                        course.Price = dr.GetDecimal(4);
                    }
                }
                return course;
            }
        }
    }
}
