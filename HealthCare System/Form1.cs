using System.Data.SqlClient;
namespace HealthCare_System
{
    public partial class Form1 : Form
    {

        SqlConnection conn;
        SqlCommand command;
        SqlDataReader reader;

        public static string uid = null;
        public static string uname = null;
        public static string uage = null;
        public static string uaddress = null;
        public static string upassword = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void login_Click(object sender, EventArgs e)
        {
            String name = textBox1.Text;
            String password = textBox2.Text;
            if (name == "Admin" && password == "123")
            {
                AdminScreen asc = new AdminScreen();
                asc.Show();
                this.Hide();
            }
            else
            {
                conn = new SqlConnection("Data Source=INT-LPT-06\\SQLEXPRESS;Initial Catalog=HealthcareManagementSystem;Integrated Security=True");
                command = new SqlCommand("Select * from [dbo].[Users] where name='" + name + "' and password='" + password + "'", conn);
                try
                {
                    conn.Open();
                    reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                             uid = reader["id"].ToString();
                             uname = reader["name"].ToString();
                             uage = reader["age"].ToString();
                             uaddress = reader["address"].ToString();
                             upassword = reader["password"].ToString();
                        }
                        MessageBox.Show("Signed In sucessfully");
                        UserScreencs us = new UserScreencs();
                        us.Show();
                        this.Hide();
                    }
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

        private void Signup_Click(object sender, EventArgs e)
        {
            SignUp su = new SignUp();
            su.Show();
            this.Hide();
        }
    }
}