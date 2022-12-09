using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RestaurantManagerSystem.DAO
{
    public class SqlDataAccessHelper
    {
        //Chuỗi kết nối
        private static String _connectionString = @"Data Source=LAPTOP-3D14HVD5\SQLEXPRESS;Initial Catalog=ResManager;Integrated Security=True";
        //ExecuteQuery : Select
        public static DataTable ExecuteQuery(String sql)
        {
            DataTable dt = new DataTable();
            SqlConnection connect = new SqlConnection(_connectionString);
            connect.Open();
            SqlCommand command = connect.CreateCommand();
            command.CommandText = sql;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            connect.Close();
            return dt;
        }
        //ExecuteNonQuery: Insert, Update, Delete
        public static bool ExecuteNonQuery(String sql)
        {
            bool kq;
            SqlConnection connect = new SqlConnection(_connectionString);
            connect.Open();
            SqlCommand command = connect.CreateCommand();
            command.CommandText = sql;
            int n = command.ExecuteNonQuery();
            if (n > 0)
            {
                kq = true;
            }
            else
            {
                kq = false;
            }
            connect.Close();
            return kq;
        }

        //View Stored Procedure
        public static DataTable ViewStoredProc(string procName, int SoHD)
        {
            DataTable dt = new DataTable();
            SqlConnection connect = new SqlConnection(_connectionString);
            SqlCommand command = connect.CreateCommand();
            command.CommandText = procName;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@SoHD", SoHD);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            connect.Close();
            return dt;
        }
    }
}
