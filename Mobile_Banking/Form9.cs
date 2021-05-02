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
    public partial class Form9 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public static string b = null;
        public String x = Form1.n;
        public Form9()
        {
            InitializeComponent();
            b = x;
            SqlConnection con = new SqlConnection(cs);

            SqlCommand cmd = new SqlCommand(" Select Round(balance,2) from user_information where mobile_number='" + b + "' ", con);
            SqlCommand cmd1 = new SqlCommand(" Select username from user_information where mobile_number='" + b + "' ", con);
            con.Open();

            label3.Text = cmd1.ExecuteScalar().ToString();
            label2.Text = cmd.ExecuteScalar().ToString() + " Taka";


            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            crud obj = new crud();
            obj.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            crud obj = new crud();
            obj.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            crud obj = new crud();
            obj.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            crud obj = new crud();
            obj.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            crud obj = new crud();
            obj.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
            Form1.n = null;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form22 obj = new Form22();
            obj.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
