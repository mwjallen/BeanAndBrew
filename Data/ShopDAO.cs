using BeanAndBrew.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BeanAndBrew.Data
{
    public class ShopDAO
    {
        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\0008959\Downloads\_Code_Projects\ASPNET\BeanAndBrew\App_Data\BeanAndBrew.mdf;Integrated Security=True";

        public List<ShopModel> FetchAll()
        {
            List<ShopModel> returnShopList = new List<ShopModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM dbo.Shop";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ShopModel shop = new ShopModel
                        {
                            ShopId = dr.GetInt32(0),
                            ShopName = dr.GetString(1),
                            NoOfTables = dr.GetInt32(2)
                        };

                        returnShopList.Add(shop);
                    }
                }
            }
            return returnShopList;

        }
        public ShopModel FetchOne(int id)
        {
            ShopModel shop = new ShopModel();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM dbo.Shop WHERE ShopId=@id";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        shop.ShopId = dr.GetInt32(0);
                        shop.ShopName = dr.GetString(1);
                        shop.NoOfTables = dr.GetInt32(2);
                    }
                }
                return shop;
            }
        }
    }
}