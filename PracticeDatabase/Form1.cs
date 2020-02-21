using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeDatabase
{
    public partial class Form1 : Form
    {

        DatabaseHelper databaseHelper = new DatabaseHelper();
        SqlDataAdapter sqlDataAdapter;
        int id = 0;

        public Form1()
        {
            InitializeComponent();
            Display();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            

            string name = tbName.Text;
            string contact = tbContact.Text;

            string query = "Insert into studentInfo (Name, Contact) values (@name, @contact)";

            SqlCommand sqlCommand = new SqlCommand(query,DatabaseHelper.sqlConnection);
            sqlCommand.Parameters.AddWithValue("@name", name);
            sqlCommand.Parameters.AddWithValue("@contact", contact);

            databaseHelper.Insert(sqlCommand);

            ResetField();
            Display();

        }

        void Display()
        {
            DatabaseHelper.sqlConnection.Open();

            DataTable dataTable = new DataTable();
            string query = "Select * from studentInfo";
            SqlCommand sqlCommand = new SqlCommand(query);

            sqlDataAdapter = new SqlDataAdapter(query,DatabaseHelper.sqlConnection);

            sqlDataAdapter.Fill(dataTable);

            dataGridView.DataSource = dataTable;

            dataGridView.AllowUserToAddRows = false;
            dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
           

            DatabaseHelper.sqlConnection.Close();

        }

        void ResetField()
        {
            tbName.Text = "";
            tbContact.Text = "";
            id = 0;
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                if(e.RowIndex>=0)
                 {

                    int index = e.RowIndex;

                    DataGridViewRow selectedRow = dataGridView.Rows[index];
                    tbName.Text = selectedRow.Cells[1].Value.ToString();
                    tbContact.Text = selectedRow.Cells[2].Value.ToString();
                    id = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());
                 }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(id>0)
            {
                
                string query = "delete from studentInfo where Id = @id";

                SqlCommand sqlCommand = new SqlCommand(query, DatabaseHelper.sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Id", id);
                databaseHelper.Delete(sqlCommand);


                ResetField();
                Display();
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(id>0)
            {
                string name = tbName.Text;
                string contact = tbContact.Text;

                string query = "update studentInfo set Name = @name , Contact = @contact where Id = @id";
                SqlCommand sqlCommand = new SqlCommand(query,DatabaseHelper.sqlConnection);
                sqlCommand.Parameters.AddWithValue("@name", name);
                sqlCommand.Parameters.AddWithValue("@contact", contact);
                sqlCommand.Parameters.AddWithValue("@id", id);
                databaseHelper.Update(sqlCommand);


                ResetField();
                Display();
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetField();
        }
    }
}
