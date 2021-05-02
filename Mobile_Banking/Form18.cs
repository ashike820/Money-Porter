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
    public partial class Form18 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public static string Personal_Number = null;
        public String x = Form1.n;
        public Form18()
        {
            InitializeComponent();
            Personal_Number = x;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);

                String qurey = " Select mobile_number from user_information  where mobile_number=@mobile_number and pass=@pass";
                SqlCommand cmd = new SqlCommand(qurey, con);
                cmd.Parameters.AddWithValue("@mobile_number", Personal_Number);
                cmd.Parameters.AddWithValue("@pass", textBox1.Text);
                con.Open();
                if (cmd.ExecuteScalar() != null)
                {
                    if(textBox2.Text==textBox3.Text)
                    {
                        String qurey1 = " Update  user_information set PASS=@password where mobile_number=@mobile_number and PASS=@pass";
                        SqlCommand cmd1 = new SqlCommand(qurey1, con);
                        cmd1.Parameters.AddWithValue("@mobile_number", Personal_Number);
                        cmd1.Parameters.AddWithValue("@pass", textBox1.Text);
                        cmd1.Parameters.AddWithValue("@password", textBox2.Text);
                        
                        int a = cmd1.ExecuteNonQuery();
                        if(a>0)
                        {
                            MessageBox.Show("PASSSWORD CHANGE SUCCESSFULLY");
                            textBox1.Clear();
                            textBox2.Clear();
                            textBox3.Clear();
                            Form1 obj = new Form1();
                            obj.Show();
                            this.Hide();
                            Form1.n = null;
                        }
                        else
                        {
                            MessageBox.Show("PASSSWORD CHANGE DECLINED");
                        }


                    }
                    else
                    {
                        MessageBox.Show("PLEASE CONFIRM PASSWORD INVALID");
                    }

                }
                else
                {
                    MessageBox.Show("PLEASE ENTER CORRECT PASSWORD");
                }
            }
            else
            {
                MessageBox.Show("YOU HAVE TO  FILL EVERYTHING ");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 obj = new Form2();
            obj.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 obj = new Form2();
            obj.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
