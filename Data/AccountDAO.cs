using BeanAndBrew.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BeanAndBrew.Data
{
    public class AccountDAO
    {
        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\0008959\Downloads\_Code_Projects\ASPNET\BeanAndBrew\App_Data\BeanAndBrew.mdf;Integrated Security=True";

        public int ValidateLogin(string email, string password)
        {
            int userRole = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlQuery = "SELECT * FROM dbo.account WHERE Email=@email AND Password=@password";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@email", SqlDbType.VarChar, 255).Value = email;
                command.Parameters.Add("@password", SqlDbType.VarChar, 150).Value = password;

                SqlDataReader dr = command.ExecuteReader();
                AccountModel user = new AccountModel();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        user.Role = dr.GetInt32(4);
                        userRole = user.Role;
                    }
                }
                return userRole;
            }
        }

        public bool RegisterAccount(AccountModel accountModel)
        {
            bool success = false;
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlQuery = "INSERT INTO dbo.account (Name, Email, Password, Role) VALUES (@name,@email,@password,default)";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@name", SqlDbType.VarChar, 150).Value = accountModel.Name;
                command.Parameters.Add("@email", SqlDbType.VarChar, 255).Value = accountModel.Email;
                command.Parameters.Add("@password", SqlDbType.VarChar, 150).Value = accountModel.Password;

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected == 1)
                {
                    success = true;
                }
            }
            return success;
        }
    }
}