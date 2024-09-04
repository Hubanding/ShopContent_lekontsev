using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ShopContent_lekontsev.Classes
{
    public class Connection
    {
        private static readonly string config = "server=student.permaviat.ru;" +
                    "Trusted_Connection=No;" +
                    "database=base1_ISW_21_3_13;" +
                    "uid=ISW_21_3_13;" +
                    "pwd=Asdfg1234#;";
        public static SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection(config);
            connection.Open();
            return connection;
        }
        public static SqlDataReader Query(string SQL, out SqlConnection connection)
        {
            connection = OpenConnection();
            return new SqlCommand(SQL, connection).ExecuteReader();
        }
        public static void CloseConnection(SqlConnection connection)
        {
            connection.Close();
            SqlConnection.ClearPool(connection);
        }
    }
}

