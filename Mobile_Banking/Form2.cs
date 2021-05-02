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
    public partial class Form2 : Form
    {
        public static string b = null;
        public String x = Form1.n;
       
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public Form2()
        {
            InitializeComponent(); 
            SqlConnection con = new SqlConnection(cs);
            b = x;
            SqlCommand cmd = new SqlCommand(" Select Round(balance,2) from user_information where mobile_number='" + b + "' ", con);
            SqlCommand cmd1 = new SqlCommand(" Select username from user_information where mobile_number='" + b + "' ", con);
            con.Open();
            label3.Text = cmd1.ExecuteScalar().ToString() ;
            label1.Text = cmd.ExecuteScalar().ToString() + " Taka";
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Form3 obj = new Form3();
            obj.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 obj = new Form4();
            obj.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 obj = new Form5();
            obj.Show();
            this.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form6 obj = new Form6();
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


        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form15 obj = new Form15();
            obj.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form18 obj = new Form18();
            obj.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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
