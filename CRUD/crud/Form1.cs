using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace crud
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-0AMODP1;Initial Catalog=crud;Integrated Security=True;");

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (txt1.Text != "" && txt2.Text !="" && txt3.Text != "")
            {
                string query = "insert into students values(@id,@name,@class)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("id", txt1.Text);
                cmd.Parameters.AddWithValue("name", txt2.Text);
                cmd.Parameters.AddWithValue("class", txt3.Text);
  int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {

                    MessageBox.Show("Inserted Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showdata();
                    txt1.Text = "";
                    txt2.Text = "";
                    txt3.Text = "";
                }
                else
                {
                    MessageBox.Show("Insertion Failed !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            }
            else
            {
                MessageBox.Show("Please fill input fields first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

           
            conn.Close();
        }

        private void showdata()
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-0AMODP1;Initial Catalog=crud;Integrated Security=True;");
            string query = "select * from students";
            SqlDataAdapter save = new SqlDataAdapter(query, conn);
            DataTable data = new DataTable();
            save.Fill(data);
            grid.DataSource = data;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            showdata();
        }


        private void grid_data(object sender, DataGridViewCellEventArgs e)
        {
            txt1.Text = Convert.ToInt32(grid.SelectedRows[0].Cells[0].Value).ToString();
            txt2.Text = grid.SelectedRows[0].Cells[1].Value.ToString();
            txt3.Text = grid.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (txt1.Text != "" && txt2.Text != "" && txt3.Text != "")
            {
                string query = "update students set id=@id, name=@name,class=@class where id=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("id", txt1.Text);
                cmd.Parameters.AddWithValue("name", txt2.Text);
                cmd.Parameters.AddWithValue("class", txt3.Text);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showdata();
                    txt1.Text = "";
                    txt2.Text = "";
                    txt3.Text = "";
                }
                else
                {
                    MessageBox.Show("Updation Failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select data first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            conn.Close();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (txt1.Text != "" && txt2.Text != "" && txt3.Text != "")
            {
                string query = "delete from students where id=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("id", txt1.Text);
                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {
                    MessageBox.Show("Deleted Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showdata();
                    txt1.Text = "";
                    txt2.Text = "";
                    txt3.Text = "";
                }
                else
                {
                    MessageBox.Show("Deletetion Failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
             
            }
            else
            {
                MessageBox.Show("Please select data first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            conn.Close();

        }



        }
    }

