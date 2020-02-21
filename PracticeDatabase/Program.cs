using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeDatabase
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //String connectionString;
            //SqlConnection sqlConnection;

            //connectionString = @"Data Source=DESKTOP-TCN5K6B\SQLEXPRESS
            //                    ;Initial Catalog=practice; 
            //                    User ID = sa;Password=123456";

            //sqlConnection = new SqlConnection(connectionString);

            //sqlConnection.Open();

            //MessageBox.Show("Connection Established");

            //sqlConnection.Close();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

          
        }
    }
}
