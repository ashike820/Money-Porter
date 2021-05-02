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
    public partial class Form1 : Form
    {
        public static string n;
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Please Enter your Mobile Number");
            }
            else { errorProvider1.Clear(); }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, "Please Enter your Password");
            }
            else { errorProvider2.Clear(); }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool status = checkBox1.Checked;
            switch (status)
            {
                case true:
                    textBox2.UseSystemPasswordChar = false;
                    break;
                default:
                    textBox2.UseSystemPasswordChar = true;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                String query = "select * from user_information where  mobile_number=@mobile_number and pass=@pass ";
                SqlCommand cmd = new SqlCommand(query,con);
                cmd.Parameters.AddWithValue("@mobile_number ", textBox1.Text);
                cmd.Parameters.AddWithValue("@pass", textBox2.Text);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    MessageBox.Show("Login successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    n =textBox1.Text;
                    dr.Read();
                    if (dr[4].ToString() == "Admin"|| dr[4].ToString() == "Admin ")
                    {      
                        Form9 obj = new Form9();
                        obj.Show();
                        this.Hide();
                    }
                    else if(dr[4].ToString() == "Personal User "|| dr[4].ToString() == "Personal User")
                    {
                        Form2 obj = new Form2();
                        obj.Show();
                        this.Hide();
                    }
                    else if (dr[4].ToString() == "Agent " || dr[4].ToString() == "Agent")
                    {
                        Form8 obj = new Form8();
                        obj.Show();
                        this.Hide();
                    }
                    else if (dr[4].ToString() == "Merchandiser " || dr[4].ToString() == "Merchandiser")
                    {
                        Form13 obj = new Form13();
                        obj.Show();
                        this.Hide();
                    }
                    
                }
                else 
                {
                    MessageBox.Show("Wrong Mobile Number or password", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                con.Close();
                
                 
            }
            else
            {
                MessageBox.Show("Please fill up the information");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void textBox2_Leave_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, "Please Enter Password");
            }
            else { errorProvider2.Clear(); }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 obj = new Form7();
            obj.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form21 obj = new Form21();
            obj.Show();
            this.Hide();
        }
    }
}
