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
    public partial class Form6 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public static string Personal_Number = null;
        public String x = Form1.n;
        Double Ppn = 0, Aan = 0, A = 0;
        float Pn = 0, An = 0;
        String Amount;
        public Form6()
        {
            InitializeComponent();
            Personal_Number = x;
        }
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        { 
            Amount = textBox2.Text;

            if (textBox1.Text != "" && textBox2.Text != "" && checkedListBox1.SelectedItem != null)
            {
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlCommand cmd = new SqlCommand(" Select balance from user_information where mobile_number='" + Personal_Number + " ' ", con);

                Ppn = Convert.ToDouble(cmd.ExecuteScalar().ToString());

               
                A = Convert.ToDouble(Amount);
                if (Ppn >= A)
                {
                    Ppn = Ppn - A;
                  
                    Pn = (float)Ppn;
                    An = (float)Aan;

                    String qurey = " Update USER_INFORMATION set BALANCE=@Pn where mobile_number='" + Personal_Number + " ' ";
                    SqlCommand cmd3 = new SqlCommand(qurey, con);
                    cmd3.Parameters.AddWithValue("@Pn", Pn);
                    int a = cmd3.ExecuteNonQuery();
                    if (a > 0  )
                    {
                        String qurey5 = " Insert into HISTORY_TABLE values  (@DATE,@TYPE,@SENDER,@RECEIVER,@AMOUNT)";
                        SqlCommand cmd6 = new SqlCommand(qurey5, con);

                        cmd6.Parameters.AddWithValue("@DATE", dateTimePicker2.Value);
                        cmd6.Parameters.AddWithValue("@TYPE", " Mobile recharge ");
                        cmd6.Parameters.AddWithValue("@SENDER", Personal_Number);
                        cmd6.Parameters.AddWithValue("@RECEIVER", textBox1.Text );
                        cmd6.Parameters.AddWithValue("@AMOUNT", A);
                        int HISTORY = cmd6.ExecuteNonQuery();
                        MessageBox.Show("Recharge  Successful");
                        textBox1.Clear();
                        textBox2.Clear();
                        checkedListBox1.ClearSelected();
                    }
                    else
                    {
                        MessageBox.Show("Recharge UnSuccessful");
                        textBox1.Clear();
                        textBox2.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Insufficient Balance ");
                    textBox1.Clear();
                    textBox2.Clear();
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

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
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
            Form2 obj = new Form2();
            obj.Show();
            this.Hide();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Please Enter valid number");
            }
            else { errorProvider1.Clear(); }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox2.Text) == true)
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, "Please Enter Amount");
            }
            else { errorProvider2.Clear(); }
        }

        private void checkedListBox1_Leave(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedItem == null)
            {
                checkedListBox1.Focus();
                errorProvider3.SetError(this.checkedListBox1, "Please select first");
            }
            else
            {
                errorProvider3.Clear();
            }
        }
    }
}
