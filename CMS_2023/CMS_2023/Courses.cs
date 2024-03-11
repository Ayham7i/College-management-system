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
    public partial class Courses : Form
    {
        public Courses()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=J:\CMS_Database\CMSdb.mdf;Integrated Security=True;Connect Timeout=30");
        private void fillDepartment()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select DepName from Deptbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("DepName", typeof(string));
            dt.Load(rdr);
            Cdepartment.ValueMember = "DepName";
            Cdepartment.DataSource = dt;

            Con.Close();


        }
        private void populate()
        {
            Con.Open();
            string query = "select * from coursestbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CoursesDGV.DataSource = ds.Tables[0];

            Con.Close();
        }
        private void search()
        {
            Con.Open();
            string query = "select * from coursestbl where coursesid = " + courseid.Text + "";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CoursesDGV.DataSource = ds.Tables[0];

            Con.Close();
        }


        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu menu2 = new menu();
            menu2.Show();
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button19_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (courseid.Text == "" || coursename.Text == "" || coursemajor.Text == "" || courselevel.Text == "" || coursetype.Text == "" || Cdepartment.Text== "" || teachername.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into coursestbl values(" + courseid.Text + ",N'" + coursename.Text + "',N'" + courselevel.Text + "',N'" + coursetype.Text + "',N'" + coursemajor.Text + "',N'" + Cdepartment.SelectedValue.ToString() + "',N'" + teachername.Text + "')", Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Courses Successfully Added");

                    Con.Close();
                    populate();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Courses_Load(object sender, EventArgs e)
        {
            fillDepartment();
            populate();


        }

        private void CoursesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            courseid.Text = CoursesDGV.SelectedRows[0].Cells[0].Value.ToString();
            coursename.Text = CoursesDGV.SelectedRows[0].Cells[1].Value.ToString();
            courselevel.Text = CoursesDGV.SelectedRows[0].Cells[2].Value.ToString();
            coursetype.Text = CoursesDGV.SelectedRows[0].Cells[3].Value.ToString();
            coursemajor.Text = CoursesDGV.SelectedRows[0].Cells[4].Value.ToString();
            Cdepartment.Text = CoursesDGV.SelectedRows[0].Cells[5].Value.ToString();
            teachername.Text = CoursesDGV.SelectedRows[0].Cells[6].Value.ToString();
           
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (courseid.Text == "")
                {
                    MessageBox.Show("Enter The Course Id");
                }
                else
                {
                    Con.Open();
                    string query = "delete from coursestbl where coursesid=" + courseid.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Courses Deleted Successfully");
                    Con.Close();
                    populate();

                }

            }
            catch
            {
                MessageBox.Show("Opps....!! Course is Not Deleted");
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (courseid.Text == "" || coursename.Text == "" || coursemajor.Text == "" || courselevel.Text == "" || coursetype.Text == "" || Cdepartment.Text == "" || teachername.Text == "")
                {
                    MessageBox.Show("Missing Data");
                }
                else
                {
                    Con.Open();
                    string query = "update coursestbl set coursesname=N'" + coursename.Text + "',courseslevel=N'" + courselevel.Text + "',coursestype=N'" + coursetype.Text + "',coursesmajor=N'" + coursemajor.Text + "',departmentid=N'" + Cdepartment.SelectedValue.ToString() + "',teachername=N'" + teachername.Text +"' where coursesid=" + courseid.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Courses Updated Successfully");
                    Con.Close();
                    populate();
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            Fees fees = new Fees();
            this.Hide();
            fees.Show();
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

        private void Cdepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
