using BeanAndBrew.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BeanAndBrew.Data
{
    public class OrderDAO
    {
        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\0008959\Downloads\_Code_Projects\ASPNET\BeanAndBrew\App_Data\BeanAndBrew.mdf;Integrated Security=True";

        public bool OrderCoffee(OrderModel orderModel)
        {
            bool success = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "INSERT INTO dbo.[Order] (CoffeeId, Quantity, Name) VALUES (@coffeeId, @quantity, @name)";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@coffeeId", SqlDbType.Int, 150).Value = orderModel.CoffeeId;
                command.Parameters.Add("@quantity", SqlDbType.Int, 150).Value = orderModel.Quantity;
                command.Parameters.Add("@name", SqlDbType.VarChar, 150).Value = orderModel.Name;

                connection.Open();

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