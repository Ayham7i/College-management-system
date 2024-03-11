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

namespace CMS_2023
{
    public partial class Departments : Form
    {
        public Departments()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=J:\CMS_Database\CMSdb.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string query = "select * from Deptbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DepDGV.DataSource = ds.Tables[0];

            Con.Close();
        }
        private void search()
        {
            Con.Open();
            string query = "select * from Deptbl where Depid = " + Depid.Text + "";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DepDGV.DataSource = ds.Tables[0];

            Con.Close();
        }


        private void Departments_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();   
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Depid.Text == "" || DepName.Text == "" || teachername.Text == "" || Coursestype.Text == "" || depmajor.Text == "" || Deplevel.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Deptbl values(" + Depid.Text + ",N'" + DepName.Text + "',N'" + Coursestype.Text + "',N'" + Deplevel.Text + "',N'" + depmajor.Text + "',N'" + teachername.Text + "')", Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Department Successfully Added");

                    Con.Close();
                    populate();
                }
            }
            catch
            {
                MessageBox.Show("Something Went Wrong");
            }
        }

        private void DepDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Depid.Text = DepDGV.SelectedRows[0].Cells[0].Value.ToString();
            DepName.Text = DepDGV.SelectedRows[0].Cells[1].Value.ToString();
            Coursestype.Text = DepDGV.SelectedRows[0].Cells[2].Value.ToString();
            Deplevel.Text = DepDGV.SelectedRows[0].Cells[3].Value.ToString();
            depmajor.Text = DepDGV.SelectedRows[0].Cells[4].Value.ToString();
            teachername.Text = DepDGV.SelectedRows[0].Cells[5].Value.ToString();

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (Depid.Text == "")
                {
                    MessageBox.Show("Enter The Department Id");
                }
                else
                {
                    Con.Open();
                    string query = "delete from Deptbl where Depid=" + Depid.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Department Deleted Successfully");
                    Con.Close();
                    populate();

                }

            }
            catch
            {
                MessageBox.Show("Opps....!! Department Not Deleted");
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Depid.Text == "" || DepName.Text == "" || Coursestype.Text == "")
                {
                    MessageBox.Show("Missing Data");
                }
                else
                {
                    Con.Open();
                    string query = "update Deptbl set DepName=N'" + DepName.Text + "',CoursesType=N'" + Coursestype.Text + "',level=N'" + Deplevel.Text + "',Major=N'" + depmajor.Text + "',TeacherName=N'" + teachername.Text + "' where Depid=" + Depid.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Department Updated Successfully");
                    Con.Close();
                    populate();
                }

            }
            catch
            {
                MessageBox.Show("Ooops...!! Teacher not Updated");

            }
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            Fees fees = new Fees();
            this.Hide();
            fees.Show();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu menu3 = new menu();
            menu3.Show();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            this.Hide();
            users.Show();
        }

        private void guna2Button18_Click(object sender, EventArgs e)
        {
            search();

        }

        private void guna2Button20_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void guna2CustomGradientPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    }
    

