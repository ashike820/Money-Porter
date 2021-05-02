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
    public partial class crud : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public crud()
        {
            InitializeComponent();
            BindGridView();
            
        }
        
        private void crud_Load(object sender, EventArgs e)
        {
            BindGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form9 obj = new Form9();
            obj.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = 0;
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && checkedListBox1.SelectedItem!= null && textBox4.Text == textBox5.Text)
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "insert into user_information values(@username,@nid,@mobile_number,@pass,@user_type,@balance)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", textBox1.Text);
                cmd.Parameters.AddWithValue("@nid", textBox2.Text);
                cmd.Parameters.AddWithValue("@mobile_number", textBox3.Text);
                cmd.Parameters.AddWithValue("@pass", textBox4.Text);
                cmd.Parameters.AddWithValue("@user_type",checkedListBox1.SelectedItem);
                cmd.Parameters.AddWithValue("@balance", textBox7.Text);

                con.Open();

                String qurey4 = " Select mobile_number from user_information  where mobile_number=@mobile_number";
                SqlCommand cmd4 = new SqlCommand(qurey4, con);
                cmd4.Parameters.AddWithValue("@mobile_number", textBox3.Text);

                if (cmd4.ExecuteScalar() != null)
                {
                    MessageBox.Show("MOBILE NUMBER IS ALREADY EXIST !! ");


                }
                else { a = cmd.ExecuteNonQuery(); }

                if (a > 0)
                {
                    MessageBox.Show("Data Inserted Successfully ! ");

                    BindGridView();
                    ResetControl();
                }
                else
                {
                    MessageBox.Show("Data not Inserted ! ");
                }
            }

            else { MessageBox.Show("Data not Inserted ! "); }
           
        }
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from user_information";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


        }

        private void button5_Click(object sender, EventArgs e)
        {
            ResetControl();
        }
        void ResetControl()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            checkedListBox1.ClearSelected();
            textBox7.Clear();
            
        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" &&  checkedListBox1.SelectedItem != null )
            {
                string mobile_number = textBox3.Text;
                SqlConnection con = new SqlConnection(cs);
                string query = "update user_information set username=@username,nid=@nid,pass=@pass,user_type=@user_type,balance=@balance where mobile_number= '" + mobile_number + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", textBox1.Text);
                cmd.Parameters.AddWithValue("@nid", textBox2.Text);
                cmd.Parameters.AddWithValue("@mobile_number", textBox3.Text);
                cmd.Parameters.AddWithValue("@pass", textBox4.Text);
                cmd.Parameters.AddWithValue("@user_type", checkedListBox1.SelectedItem);
                cmd.Parameters.AddWithValue("@balance", textBox7.Text);

                con.Open();
                int a = cmd.ExecuteNonQuery();//0 1
                if (a > 0)
                {
                    MessageBox.Show("Data Updated Successfully ! ");
                    BindGridView();
                    ResetControl();
                }
                else
                {
                    MessageBox.Show("Data not Updated ! ");
                }
            }
            else
            {
                MessageBox.Show("Fill up all textbox");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from user_information where MOBILE_NUMBER=@MOBILE_NUMBER";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("MOBILE_NUMBER", textBox3.Text);
            con.Open();
            int a = cmd.ExecuteNonQuery();//0 1
            if (a >= 0&& textBox3.Text!="")
            {
                MessageBox.Show("Data Deleted Successfully ! ");
                BindGridView();
                ResetControl();
            }
            else
            {
                MessageBox.Show("Data not Deleted ! ");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            return;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)

            {
                textBox1.Text= dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                checkedListBox1.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = checkedListBox1.SelectedIndex;
            int count = checkedListBox1.Items.Count;
            for(int x=0; x<count;x++)
            {
                if (index!=x)
                {
                    checkedListBox1.SetItemChecked(x, false);
                }
            }
        }
    }
}
