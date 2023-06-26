using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthCare_System
{
    public partial class AppointmentHistory : Form
    {
        SqlConnection conn;
        public AppointmentHistory()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminScreen asc = new AdminScreen();
            asc.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void loadDataFromDb()
        {
            try
            {
                conn = new SqlConnection("Data Source=INT-LPT-06\\SQLEXPRESS;Initial Catalog=HealthcareManagementSystem;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("select AppointmentHistorys.date,Users.name,Users.age,Users.address,Doctor.name,Doctor.email,Doctor.speciality from AppointmentHistorys inner join Users on AppointmentHistorys.userId = Users.id join Doctor on AppointmentHistorys.doctorId = Doctor.id order by AppointmentHistorys.date asc", conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void AppointmentHistory_Load(object sender, EventArgs e)
        {
            loadDataFromDb();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var name = textBox1.Text;

            try
            {
                conn = new SqlConnection("Data Source=INT-LPT-06\\SQLEXPRESS;Initial Catalog=HealthcareManagementSystem;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("select AppointmentHistory.date,Users.name,Users.age,Users.address,Doctor.name,Doctor.email,Doctor.speciality from AppointmentHistory inner join Users on AppointmentHistory.userId = Users.id join Doctor on AppointmentHistory.doctorId = Doctor.id where Users.name = '" + name + "' order by AppointmentHistory.date asc", conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dts = new DataTable();
                sda.Fill(dts);
                dataGridView1.DataSource = dts;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadDataFromDb();
        }
    }
}
