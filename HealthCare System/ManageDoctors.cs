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

namespace HealthCare_System
{
    public partial class ManageDoctors : Form
    {
        SqlConnection conn;
        DataSet ds;
        SqlDataAdapter adapter;
        SqlCommandBuilder cmdBuilder;
        public ManageDoctors()
        {
            InitializeComponent();
            conn = new SqlConnection("Data Source=INT-LPT-06\\SQLEXPRESS;Initial Catalog=HealthcareManagementSystem;Integrated Security=True");
        }

        private void ManageDoctors_Load(object sender, EventArgs e)
        {
            loadDataFromDb();
        }

        public void loadDataFromDb()
        {
            adapter = new SqlDataAdapter("Select * from [dbo].[Doctor]", conn);
            ds = new DataSet();
            adapter.Fill(ds, "Doctor");
            dataGridView1.DataSource = ds.Tables["Doctor"];
        }

        private void back_Click(object sender, EventArgs e)
        {
            AdminScreen adminScreen = new AdminScreen();
            adminScreen.Show();
            this.Hide();
        }

        private void add_Click(object sender, EventArgs e)
        {
            DataRow newRow = ds.Tables["Doctor"].NewRow();
            newRow["name"] = textBox1.Text;
            newRow["age"] = textBox2.Text;
            newRow["address"] = textBox3.Text;
            newRow["email"] = textBox4.Text;
            newRow["speciality"] = textBox5.Text;

            ds.Tables["Doctor"].Rows.Add(newRow);
            cmdBuilder = new SqlCommandBuilder(adapter);
            adapter.Update(ds, "Doctor");
            loadDataFromDb();
        }

        private void update_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dataGridView1.CurrentRow;
            DataColumn[] keyCol = new DataColumn[1];
            keyCol[0] = ds.Tables["Doctor"].Columns["id"];
            ds.Tables["Doctor"].PrimaryKey = keyCol;

            DataRow update = ds.Tables["Doctor"].Rows.Find(Convert.ToInt32(dr.Cells[0].Value));

            update["name"] = textBox1.Text;
            update["age"] = textBox2.Text;
            update["address"] = textBox3.Text;
            update["email"] = textBox4.Text;
            update["speciality"] = textBox5.Text;
            
            cmdBuilder = new SqlCommandBuilder(adapter);

            adapter.Update(ds, "Doctor");
            loadDataFromDb();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dataGridView1.CurrentRow;
            DataColumn[] keyCol = new DataColumn[1];
            keyCol[0] = ds.Tables["Doctor"].Columns["id"];
            ds.Tables["Doctor"].PrimaryKey = keyCol;

            DataRow delRow = ds.Tables["Doctor"].Rows.Find(Convert.ToInt32(dr.Cells[0].Value));
            delRow.Delete();
            cmdBuilder = new SqlCommandBuilder(adapter);
            adapter.Update(ds, "Doctor"); 
            loadDataFromDb();

        }
    }
}
