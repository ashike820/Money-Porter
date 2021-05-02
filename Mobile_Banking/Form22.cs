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
    public partial class Form22 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form22()
        {
            InitializeComponent(); 
            BindGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form9 obj = new Form9();
            obj.Show();
        }
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from HISTORY_TABLE";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                String qurey4 = " Select * from HISTORY_TABLE  where SENDER=@mobile_number or RECEIVER=@mobile_number ";
                SqlCommand cmd4 = new SqlCommand(qurey4, con);
                cmd4.Parameters.AddWithValue("@mobile_number", textBox1.Text);
                con.Open();
                if (cmd4.ExecuteScalar() != null)
                {
                    
                    string query = "select * from HISTORY_TABLE where SENDER='" + textBox1.Text + "' OR RECEIVER='" + textBox1.Text + "' ";
                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    DataTable data = new DataTable();
                    sda.Fill(data);
                    dataGridView1.DataSource = data;

                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                }
                else
                {
                    MessageBox.Show("Enter a valid number");
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Enter a  number");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form22_Load(object sender, EventArgs e)
        {

        }
    }
}
