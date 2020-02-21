using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDatabase
{
    public class DatabaseHelper
    {

        string connectionString;
        public static SqlConnection sqlConnection;

        public DatabaseHelper()
        {
            connectionString = @"Data Source=DESKTOP-TCN5K6B\SQLEXPRESS; Initial Catalog=practice; User ID = sa;Password=123456";
            sqlConnection = new SqlConnection(connectionString);
        }

        public void Insert(SqlCommand sqlCommand)
        {
            sqlConnection.Open();

            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

        }

        public void Delete(SqlCommand sqlCommand)
        {
            sqlConnection.Open();

            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public void Update(SqlCommand sqlCommand)
        {
            sqlConnection.Open();

            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }
    }
}
