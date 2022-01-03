using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using static Kitchen.GlobalVar;

namespace Kitchen
{
    public static class SQL
    {
        
        
        public static bool CheckLogin(string email, string password)
        {
            using(SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "SELECT Id FROM Staff WHERE Email='" + email + "' AND Password='" + password + "'",
                    Connection = connection
                };

                object result = cmd.ExecuteScalar();

                if(result == DBNull.Value || result == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public static void ReadOrder(int orderId)
        {
            _Order.Clear();
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "SELECT * FROM Orders WHERE Id='" + orderId + "'",

                    Connection = connection
                };
                SqlDataReader reader = cmd.ExecuteReader();              

                while (reader.Read())
                {
                    _Order.Add(new Order
                    {
                        Status = reader["Status"].ToString(),
                        StatusChanged = reader["StatusChanged"].ToString(),
                        Items = reader["Items"].ToString().Split(';'),
                        OrderId = int.Parse(reader["Id"].ToString()),
                        Eta = reader["Eta"].ToString()
                    });
                };
                connection.Close();
            }
        }

        public static void UpdateOrder(Order order)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "UPDATE Orders SET Status='" + order.Status + "', StatusChanged='" + order.StatusChanged + "', Eta='" + order.Eta + "' WHERE Id='" + order.OrderId + "'",

                    Connection = connection
                };

                cmd.ExecuteNonQuery();
            }

        }
    }
}
