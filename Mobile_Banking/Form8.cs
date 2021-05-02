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
    public partial class Form8 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public static string b = null;
        public String x = Form1.n;

        public Form8()
        {
            InitializeComponent();
            b = x;
            SqlConnection con = new SqlConnection(cs);

            SqlCommand cmd = new SqlCommand(" Select Round(balance,2) from user_information where mobile_number='" + b + "' ", con);
            SqlCommand cmd1 = new SqlCommand(" Select username from user_information where mobile_number='" + b + "' ", con);
            con.Open();

            label3.Text = cmd1.ExecuteScalar().ToString();
            label1.Text = cmd.ExecuteScalar().ToString() + " Taka";


            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form10 obj = new Form10();
            obj.Show();
            this.Hide();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Form12 obj = new Form12();
            obj.Show();
            this.Hide();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Form11 obj = new Form11();
            obj.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
            Form1.n = null;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form19 obj = new Form19();
            obj.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form16 obj = new Form16();
            obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form8_Load(object sender, EventArgs e)
        {

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
