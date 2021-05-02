using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Mobile_Banking
{
    public partial class Form7 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
       
        public Form7()
        {
            InitializeComponent(); 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = checkedListBox1.SelectedIndex;
            int count = checkedListBox1.Items.Count;
            for (int x = 0; x < count; x++)
            {
                if (index != x)
                {
                    checkedListBox1.SetItemChecked(x, false);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = 0;
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && checkedListBox1.SelectedItem != null && textBox4.Text == textBox5.Text)
            {

                SqlConnection con = new SqlConnection(cs);
                string query = " insert into user_information values (@username,@nid,@mobile_number,@pass,@user_type,@balance)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", textBox1.Text);
                cmd.Parameters.AddWithValue("@nid", textBox2.Text);
                cmd.Parameters.AddWithValue("@mobile_number", textBox3.Text);
                cmd.Parameters.AddWithValue("@pass", textBox4.Text);
                cmd.Parameters.AddWithValue("@user_type", checkedListBox1.SelectedItem);
                cmd.Parameters.AddWithValue( "@balance",0.00);
                con.Open();

                String qurey4 = " Select mobile_number from user_information  where mobile_number=@mobile_number";
                SqlCommand cmd4 = new SqlCommand(qurey4, con);
                cmd4.Parameters.AddWithValue("@mobile_number", textBox3.Text);

                if (cmd4.ExecuteScalar() != null)
                {

                    MessageBox.Show("Mobile Number is already Exist !! ");

                }
                else { a = cmd.ExecuteNonQuery(); }

                if (a > 0)
                {
                   
                    MessageBox.Show("Accounted Created");
                    Form1 obj = new Form1();
                    obj.Show();
                    this.Hide();
                }
                else {
                    MessageBox.Show("Accounted not created");
                }
               
                checkedListBox1.ClearSelected();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                
                

            }
            else
            {
                MessageBox.Show("Please fill up the information Properly");
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Please Enter valid Name");
            }
            else { errorProvider1.Clear(); }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox2.Text) == true)
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, "Please Enter NID");
            }
            else { errorProvider2.Clear(); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text) == true)
            {
                textBox4.Focus();
                errorProvider4.SetError(this.textBox4, "Please Enter Password");
            }
            else { errorProvider4.Clear(); }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;

            
        }

        private void checkedListBox1_Leave(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedItem == null)
            {
                checkedListBox1.Focus();
                errorProvider6.SetError(this.checkedListBox1, "Please select first");
            }
            else
            {
                errorProvider6.Clear();
            }
        }

        private void button1_Leave(object sender, EventArgs e)
        {

        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text) == true)
            {
                textBox5.Focus();
                errorProvider5.SetError(this.textBox5, "Please Confirm Password");
            }
            else { errorProvider5.Clear(); }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text) == true)
            {
                textBox3.Focus();
                errorProvider3.SetError(this.textBox3, "Please Enter Mobile Number");
            }
            else { errorProvider3.Clear(); }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           

        }
    }
}
