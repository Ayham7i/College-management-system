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
    public partial class teachers : Form
    {
        public teachers()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=J:\CMS_Database\CMSdb.mdf;Integrated Security=True;Connect Timeout=30");
        private void fillDepartment()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select DepName from Deptbl",Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("DepName", typeof(string));
            dt.Load(rdr);
            Tdepartment.ValueMember = "DepName";
            Tdepartment.DataSource = dt;

            Con.Close();


        }
        private void fillteachcourses()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select coursesname from coursestbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("coursesname", typeof(string));
            dt.Load(rdr);
            teachercourses.ValueMember = "coursesname";
            teachercourses.DataSource = dt;

            Con.Close();


        }
        private void populate()
        {
            Con.Open();
            string query = "select * from teachertbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            TeacherDGV.DataSource = ds.Tables[0];

            Con.Close();
        }
        private void search()
        {
            Con.Open();
            string query = "select * from teachertbl where teacherid = " + teacherid.Text + "";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            TeacherDGV.DataSource = ds.Tables[0];

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

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CustomGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {

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
        

        private void teachers_Load(object sender, EventArgs e)
        {
            
            fillDepartment();
            fillteachcourses();
            populate();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (teacherid.Text == "" || Teachername.Text == "" || teachermajor.Text == "" || teacherphone.Text == "" || teachergender.Text == "" || teacherdegree.Text == "" || Tdepartment.Text == "" || teacherdob.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into teachertbl values(" + teacherid.Text + ",N'" + Teachername.Text + "',N'" + Tdepartment.SelectedValue.ToString() + "',N'" + teachercourses.Text + "',N'" + teachermajor.Text + "',N'" + teachergender.SelectedItem.ToString() + "',N'" + teacherphone.Text + "',N'" + teacherdob.Text + "',N'" + teacherdegree.Text + "')", Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Teacher Successfully Added");

                    Con.Close();
                    populate();
                }
            }
            catch
            {
                MessageBox.Show("Something Went Wrong");
            }
        }

        private void TeacherDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            teacherid.Text = TeacherDGV.SelectedRows[0].Cells[0].Value.ToString();
            Teachername.Text = TeacherDGV.SelectedRows[0].Cells[1].Value.ToString();
            Tdepartment.Text = TeacherDGV.SelectedRows[0].Cells[2].Value.ToString();
            teachercourses.Text = TeacherDGV.SelectedRows[0].Cells[3].Value.ToString();
            teachermajor.Text = TeacherDGV.SelectedRows[0].Cells[4].Value.ToString();
            teachergender.Text = TeacherDGV.SelectedRows[0].Cells[5].Value.ToString();
            teacherphone.Text = TeacherDGV.SelectedRows[0].Cells[6].Value.ToString();
            teacherdob.Text = TeacherDGV.SelectedRows[0].Cells[7].Value.ToString();
            teacherdegree.Text = TeacherDGV.SelectedRows[0].Cells[8].Value.ToString();

        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (teacherid.Text == "")
                {
                    MessageBox.Show("Enter The Teacher Id");
                }
                else
                {
                    Con.Open();
                    string query = "delete from teachertbl where teacherid=" + teacherid.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Teacher Deleted Successfully");
                    Con.Close();
                    populate();

                }

            }
            catch
            {
                MessageBox.Show("Opps....!! Teacher is Not Deleted");
            }
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (teacherid.Text == "" || Teachername.Text == "" || teachermajor.Text == "" || teacherphone.Text == "" || teachergender.Text == "" || teacherdegree.Text == "" || Tdepartment.Text == "" || teacherdob.Text == "")
                {
                    MessageBox.Show("Missing Data");
                }
                else
                {
                    Con.Open();
                    string query = "update teachertbl set teachername=N'" + Teachername.Text + "',Tdepartment=N'" + Tdepartment.SelectedValue.ToString() + "',teachcourses=N'" + teachercourses.Text + "',teachermajor=N'" + teachermajor.Text + "',teachergender=N'" + teachergender.SelectedItem.ToString() + "',teacherphone=N'" + teacherphone.Text + "',teacherDOB=N'" + teacherdob.Text + "',teacherdegree=N'" + teacherdegree.Text + "' where teacherid=" + teacherid.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Teacher Updated Successfully");
                    Con.Close();
                    populate();
                }

            }
            catch
            {
                MessageBox.Show("Ooops...!! Teacher not Updated");

            }
        }

        private void teacherdob_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button18_Click(object sender, EventArgs e)
        {
            search();

        }

        private void guna2Button20_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void teachercourses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Tdepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
