using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace HealthCare_System
{
    public partial class UserScreencs : Form
    {
        SqlDataReader reader;
        SqlConnection conn;
        String uid = null;
        String uname = null;
        String uage = null;
        String uaddress = null;
        String upassword = null;

        String apdate = null;
        String doctorid = null;

        String doctorName = null;
        String doctorEmail = null;

        public UserScreencs()
        {
            InitializeComponent();
        }


        private void UserScreencs_Load(object sender, EventArgs e)
        {
            uid = Form1.uid;
            uname = Form1.uname;
            uage = Form1.uage;
            uaddress = Form1.uaddress;
            upassword = Form1.upassword;

            label4.Text = uname;
            label5.Text = uage;
            label6.Text = uaddress;

            loadDataForDoctorComboBox();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public string[] SplitStringByComma(string input)
        {
            string[] result = input.Split(',');
            return result;
        }

        private void loadDataForDoctorComboBox()
        {
            conn = new SqlConnection("Data Source=INT-LPT-06\\SQLEXPRESS;Initial Catalog=HealthcareManagementSystem;Integrated Security=True");

            // try
            // {
            //    SqlDataAdapter da = new SqlDataAdapter("select name, speciality from Doctor", conn);
            //    conn.Open();
            //    DataSet ds = new DataSet();
            //    da.Fill(ds, "Doctor");
            //    comboBox1.DisplayMember = "name";
            //   comboBox1.ValueMember = "speciality";
            //    comboBox1.DataSource = ds.Tables["Doctor"];
            // }
            // catch (Exception ex)
            // {
            // write exception info to log or anything else
            //   MessageBox.Show("Error occured!");
            //}
            SqlCommand cmd = new SqlCommand();
            List<String> str = new List<String>();
            cmd.Connection = conn;
            cmd.Connection.Open();
            cmd.CommandText = "SELECT * from Doctor";
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                var data = new
                {
                    id = dr.GetValue(0).ToString(),
                    name = dr.GetValue(1).ToString(),
                    age = dr.GetValue(2).ToString(),
                    address = dr.GetValue(3).ToString(),
                    email = dr.GetValue(4).ToString(),
                    speciality = dr.GetValue(5).ToString()
                };
                String connectedData = data.speciality + "," + data.id;
                str.Add(connectedData);
            }
            comboBox1.DataSource = str;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn = new SqlConnection("Data Source=INT-LPT-06\\SQLEXPRESS;Initial Catalog=HealthcareManagementSystem;Integrated Security=True");
            String selectedValue = comboBox1.Text;
            String[] arr = SplitStringByComma(selectedValue);
            String doctorSpeciality = arr[0];
            int doctorId = int.Parse(arr[1]);
            SqlCommand cmd = new SqlCommand();
            List<String> str = new List<String>();
            cmd.Connection = conn;
            cmd.Connection.Open();
            cmd.CommandText = "select Timing.date,Doctor.name,Doctor.email,Doctor.speciality,Doctor.id from Timing inner join Doctor on Timing.doctorid= Doctor.id where Doctor.id = '" + doctorId + "' and Doctor.speciality = '" + doctorSpeciality + "';";
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                var data = new
                {
                    date = dr.GetValue(0).ToString(),
                    name = dr.GetValue(1).ToString(),
                    email = dr.GetValue(2).ToString(),
                    speciality = dr.GetValue(3).ToString(),
                    id = dr.GetValue(4).ToString()
                };
                String connectedData = data.date + "," + data.id;
                str.Add(connectedData);
            }
            comboBox2.DataSource = str;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn = new SqlConnection("Data Source=INT-LPT-06\\SQLEXPRESS;Initial Catalog=HealthcareManagementSystem;Integrated Security=True");
            String selectedValue = comboBox2.Text;
            String[] arr = SplitStringByComma(selectedValue);
            String datetime = arr[0];
            int doctorId = int.Parse(arr[1]);
            apdate = datetime;
            doctorid = doctorId.ToString();
            SqlCommand cmd = new SqlCommand();
            List<Object> str = new List<Object>();
            cmd.Connection = conn;
            cmd.Connection.Open();
            cmd.CommandText = "Select * from[Doctor] where id = '" + doctorId + "'";
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                var data = new
                {
                    date = dr.GetValue(0).ToString(),
                    name = dr.GetValue(1).ToString(),
                    email = dr.GetValue(2).ToString(),
                    speciality = dr.GetValue(3).ToString(),
                    id = dr.GetValue(4).ToString()
                };
                str.Add(data);
                label12.Text = data.name;
            }
        }

        private void getDetailsOfDoctor(int id)
        {
            conn = new SqlConnection("Data Source=INT-LPT-06\\SQLEXPRESS;Initial Catalog=HealthcareManagementSystem;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            List<Object> str = new List<Object>();
            cmd.Connection = conn;
            cmd.Connection.Open();
            cmd.CommandText = "Select name,email from[Doctor] where id = '" + id + "'";
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                var data = new
                {
                    name = dr.GetValue(0).ToString(),
                    email = dr.GetValue(1).ToString(),
                };

                doctorName = data.name;
                doctorEmail = data.email;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String apoint = apdate.Substring(0, 10);
            string convertedDate = apoint.Replace("/", "-");
            apdate = convertedDate;
            conn = new SqlConnection("Data Source=INT-LPT-06\\SQLEXPRESS;Initial Catalog=HealthcareManagementSystem;Integrated Security=True");
            SqlCommand command = new SqlCommand("INSERT INTO AppointmentHistorys(date,userId,doctorId) values ('" + convertedDate + "'," +
                "'" + uid + "','" + doctorid + "')", conn);
            try
            {
                conn.Open();
                command.ExecuteNonQuery();
                getDetailsOfDoctor(int.Parse(doctorid));
                sendMailToDoctor();
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

        private void sendMailToDoctor()
        {
            MailAddress from = new MailAddress("sanabil.52864@iqra.edu.pk", "SANABIL SALEEM");
            String email = doctorEmail;
            String name = doctorName;
            MailAddress to = new MailAddress(email, name);
            List<MailAddress> cc = new List<MailAddress>();
            cc.Add(new MailAddress("haris.53321@iqra.edu.pk", "HARIS YOUNUS"));
            SendEmail("Your appointment is scheduled", from, to, cc);
            Form1 form = new Form1();
            this.Hide();
            form.Show();
        }

        protected void SendEmail(string _subject, MailAddress _from, MailAddress _to, List<MailAddress> _cc, List<MailAddress> _bcc = null)
        {
            string Text = "Your appointment is booked";
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;
            //kindly add your gmail account for google authorization 
            string email = "";
            // add a 16bit password of your two factor authenticated password genrated by google to verify credentials
            string password = "";
            // without this email and passwoRD email wont shoot
            SmtpClient mailClient = new SmtpClient();
            mailClient.Host = smtpServer;
            mailClient.Port = smtpPort;
            mailClient.EnableSsl = true;
            mailClient.UseDefaultCredentials = false;
            mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            mailClient.Credentials = new NetworkCredential(email, password);            
            MailMessage msgMail;
            Text = "your appointment date is " + apdate;
            msgMail = new MailMessage();
            msgMail.From = _from;
            msgMail.To.Add(_to);
            foreach (MailAddress addr in _cc)
            {
                msgMail.CC.Add(addr);
            }
            if (_bcc != null)
            {
                foreach (MailAddress addr in _bcc)
                {
                    msgMail.Bcc.Add(addr);
                }
            }
            msgMail.Subject = _subject;
            msgMail.Body = Text;
            msgMail.IsBodyHtml = true;
            mailClient.Send(msgMail);
            msgMail.Dispose();

            MessageBox.Show("Appointment Booked");
        }

        private void printReceipt()
        {

        }




    }
}
