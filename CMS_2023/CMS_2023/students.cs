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
    public partial class students : Form
    {
        public students()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=J:\CMS_Database\CMSdb.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string query = "select * from Studenttbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            StudentDGV.DataSource = ds.Tables[0];

            Con.Close();
        }
        private void noduelist()
        {
            Con.Open();
            string query = "select * from Studenttbl where studentfees > "+0+"";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            StudentDGV.DataSource = ds.Tables[0];

            Con.Close();
        }
        private void search()
        {
            Con.Open();
            string query = "select * from Studenttbl where studentid = " + studentid.Text + "";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            StudentDGV.DataSource = ds.Tables[0];

            Con.Close();
        }

        private void guna2CustomGradientPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu menu1 = new menu();
            menu1.Show();
        }

        private void guna2TextBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (studentid.Text == "" || studentname.Text == "" || studentmajor.Text == "" ||  studentphone.Text == "" || studentgender.Text == "" || studentdob.Text == "" || studentsystem.Text == "" || studentlevel.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Studenttbl values(N'" + studentid.Text + "',N'" + studentname.Text + "',N'" + studentlevel.Text + "',N'" + studentsystem.Text + "',N'" + studentmajor.Text + "',N'" + studentgender.SelectedItem.ToString() + "',N'" + studentphone.Text + "','" + studentdob.Text + "',N'" + studentfees.Text + "')", Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student Successfully Added");

                    Con.Close();
                    populate();
                }
            }
            catch
            {
                MessageBox.Show("Something Went Wrong");
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (studentid.Text == "" || studentname.Text == "" || studentmajor.Text == "" || studentphone.Text == "" || studentgender.Text == "" || studentdob.Text == "" || studentsystem.Text == "" || studentlevel.Text == "")
                {
                    MessageBox.Show("Missing Data");
                }
                else
                {
                    Con.Open();
                    string query = "update Studenttbl set studentname=N'" + studentname.Text + "',studentlevel=N'" + studentlevel.Text + "',studentsysa=N'" + studentsystem.Text + "',studentmajor=N'" + studentmajor.Text + "',studentgender=N'" + studentgender.SelectedItem.ToString() + "',studentphone=N'" + studentphone.Text + "',studentdDOB=N'" + studentdob.Text + "',studentfees=N'" + studentfees.Text + "' where studentid=" + studentid.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student Updated Successfully");
                    Con.Close();
                    populate();
                }

            }
            catch
            {
                MessageBox.Show("Ooops...!! User not Updated");

            }

        }

        private void students_Load(object sender, EventArgs e)
        {
            populate(); 
        }

        private void StudentDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            studentid.Text = StudentDGV.SelectedRows[0].Cells[0].Value.ToString();
            studentname.Text = StudentDGV.SelectedRows[0].Cells[1].Value.ToString();
            studentlevel.Text = StudentDGV.SelectedRows[0].Cells[2].Value.ToString();
            studentsystem.Text = StudentDGV.SelectedRows[0].Cells[3].Value.ToString();
            studentmajor.Text = StudentDGV.SelectedRows[0].Cells[4].Value.ToString();
            studentgender.Text = StudentDGV.SelectedRows[0].Cells[5].Value.ToString();
            studentphone.Text = StudentDGV.SelectedRows[0].Cells[6].Value.ToString();
            studentdob.Text = StudentDGV.SelectedRows[0].Cells[7].Value.ToString();
            studentfees.Text = StudentDGV.SelectedRows[0].Cells[8].Value.ToString();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (studentid.Text == "")
                {
                    MessageBox.Show("Enter The Student Id");
                }
                else
                {
                    Con.Open();
                    string query = "delete from Studenttbl where studentid=" + studentid.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student Deleted Successfully");
                    Con.Close();
                    populate();

                }

            }
            catch
            {
                MessageBox.Show("Opps....!! Student is Not Deleted");
            }
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button19_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void guna2Button20_Click(object sender, EventArgs e)
        {
            noduelist();
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
            if (studentid.Text != "")
            {
                search();
            }
            else
            {
                MessageBox.Show("Please Enter The Student id ");
            }
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            dashboard.BringToFront();
          
        }
    }
}
