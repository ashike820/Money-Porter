using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;


namespace Mobile_Banking
{
    public partial class Form13 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public static string Personal_Number = null;
        public String x = Form1.n;

        public Form13()
        {
            InitializeComponent(); 
            SqlConnection con = new SqlConnection(cs);
            Personal_Number = x;
            SqlCommand cmd = new SqlCommand(" Select Round(balance,2) from user_information where mobile_number='" + Personal_Number + "' ", con);
            SqlCommand cmd1 = new SqlCommand(" Select username from user_information where mobile_number='" + Personal_Number + "' ", con);
            con.Open();

            label3.Text = cmd1.ExecuteScalar().ToString();
            label1.Text = cmd.ExecuteScalar().ToString() + " Taka";


            con.Close();
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            Form14 obj = new Form14();
            obj.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
            Form1.n = null;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form20 obj = new Form20();
            obj.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form17 obj = new Form17();
            obj.Show();
            this.Hide();
        }

        private void Form13_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }
    }
}
