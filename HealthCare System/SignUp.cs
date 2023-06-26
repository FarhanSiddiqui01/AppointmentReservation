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
using System.Xml.Linq;

namespace HealthCare_System
{
    public partial class SignUp : Form
    {
        SqlConnection conn;
        SqlCommand command;
        SqlDataReader reader;
        public SignUp()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String name = textBox1.Text;
            String age = textBox2.Text;
            String address = textBox3.Text;
            String password = textBox4.Text;
            conn = new SqlConnection("Data Source=INT-LPT-06\\SQLEXPRESS;Initial Catalog=HealthcareManagementSystem;Integrated Security=True");
            command = new SqlCommand("INSERT INTO [dbo].Users(name,age,address,password) values ('" + name + "'," +
                "'" + age + "','" + address + "','" + password + "')", conn);
            try
            {
                conn.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("user inserted");
                this.Hide();
                Form1 f1 = new Form1();
                f1.Show();
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
    }
}
