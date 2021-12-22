using BeanAndBrew.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BeanAndBrew.Data
{
    public class CoffeeDAO
    {
        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\0008959\Downloads\_Code_Projects\ASPNET\BeanAndBrew\App_Data\BeanAndBrew.mdf;Integrated Security=True";

        public List<CoffeeViewModel> FetchAll()
        {
            List<CoffeeViewModel> returnCoffeeList = new List<CoffeeViewModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM dbo.Coffee";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        CoffeeViewModel coffee = new CoffeeViewModel();
                        coffee.Id = dr.GetInt32(0);
                        coffee.Name = dr.GetString(1);
                        coffee.Description = dr.GetString(2);
                        coffee.Price = dr.GetDecimal(3);

                        returnCoffeeList.Add(coffee);
                    }
                }
            }
            return returnCoffeeList;

        }
        public CoffeeViewModel FetchOne(int id)
        {
            CoffeeViewModel coffee = new CoffeeViewModel();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM dbo.Coffee WHERE Id=@id";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        coffee.Id = dr.GetInt32(0);
                        coffee.Name = dr.GetString(1);
                        coffee.Description = dr.GetString(2);
                        coffee.Price = dr.GetDecimal(3);
                    }
                }
                return coffee;
            }
        }
    }
}