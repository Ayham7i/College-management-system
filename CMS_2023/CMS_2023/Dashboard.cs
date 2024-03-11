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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=J:\CMS_Database\CMSdb.mdf;Integrated Security=True;Connect Timeout=30");


        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            Con.Open();
            SqlDataAdapter sda1 = new SqlDataAdapter("select count(*) from Studenttbl ",Con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            Stddash.Text = dt1.Rows[0][0].ToString();

            SqlDataAdapter sda2 = new SqlDataAdapter("select count(*) from teachertbl ", Con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            techdash.Text = dt2.Rows[0][0].ToString();

            SqlDataAdapter sda3 = new SqlDataAdapter("select count(*) from  feestbl ", Con);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            feesdash.Text = "YER "+Convert.ToInt32( dt3.Rows[0][0].ToString());

            SqlDataAdapter sda4 = new SqlDataAdapter("select count(*) from Deptbl ", Con);
            DataTable dt4 = new DataTable();
            sda4.Fill(dt4);
            depdash.Text = dt4.Rows[0][0].ToString();
            Con.Close();

            SqlDataAdapter sda5 = new SqlDataAdapter("select count(*) from coursestbl ", Con);
            DataTable dt5 = new DataTable();
            sda4.Fill(dt5);
            Coursesdash.Text = dt5.Rows[0][0].ToString();
            Con.Close();

            SqlDataAdapter sda6 = new SqlDataAdapter("select count(*) from UserTbl ", Con);
            DataTable dt6 = new DataTable();
            sda4.Fill(dt6);
            Usersdash.Text = dt6.Rows[0][0].ToString();
            Con.Close();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            menu menu5 = new menu();
            this.Hide();
            menu5.Show();
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

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();  
            dashboard.Show();
            this.Hide();
        }
    }
}
