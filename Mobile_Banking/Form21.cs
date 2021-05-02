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
    public partial class Form21 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        int OTP;
        public Form21()
        {
            InitializeComponent(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                String qurey = " Select mobile_number from user_information where mobile_number=@mobile_number";
                SqlCommand cmd = new SqlCommand(qurey, con);
                cmd.Parameters.AddWithValue("@mobile_number", textBox1.Text);
                con.Open();
                if (cmd.ExecuteScalar() != null)
                {
                    Random random = new System.Random();
                    int value = random.Next(1000, 10000);
                    OTP = value;
                    MessageBox.Show("OTPS IS: " + OTP);
                    textBox5.Text = OTP.ToString();
                }
                else
                {
                    MessageBox.Show("PLEASE ENTER CORRECT MOBILE NUMBER");
                }
            }
            else
            {
                MessageBox.Show("YOU HAVE TO FILL MOBILE NUMBER ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                String qurey = " Select mobile_number from user_information where mobile_number=@mobile_number";
                SqlCommand cmd = new SqlCommand(qurey, con);
                cmd.Parameters.AddWithValue("@mobile_number", textBox1.Text);
                con.Open();
                if (cmd.ExecuteScalar() != null)
                {
                    if (textBox5.Text == OTP.ToString())
                    {
                        if (textBox3.Text == textBox4.Text)
                        {
                            String qurey1 = " Update user_information set PASS=@password where mobile_number=@mobile_number";
                            SqlCommand cmd1 = new SqlCommand(qurey1, con);
                            cmd1.Parameters.AddWithValue("@mobile_number", textBox1.Text);
                            cmd1.Parameters.AddWithValue("@password", textBox3.Text);
                            int a = cmd1.ExecuteNonQuery();
                            if (a > 0)
                            {
                                MessageBox.Show("PASSSWORD CHANGE SUCCESSFULLY");
                                textBox1.Clear();
                                textBox3.Clear();
                                textBox4.Clear();
                                textBox5.Clear();
                            }
                            else
                            {
                                MessageBox.Show("PASSSWORD CHANGE DECLINED");
                            }
                        }
                        else
                        {
                            MessageBox.Show("PREVIOUS AND CONFIRM PASSWORD DOESN'T MATCH");
                        }
                    }
                    else
                    {
                        MessageBox.Show("INCORRECT OTP");
                    }
                }
                else
                {
                    MessageBox.Show("PLEASE ENTER CORRECT PASSWORD");
                }
            }
            else
            {
                MessageBox.Show("YOU HAVE TO FILL EVERYTHING ");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form21_Load(object sender, EventArgs e)
        {

        }
    }
}
