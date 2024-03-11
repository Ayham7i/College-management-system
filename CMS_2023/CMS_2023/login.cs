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
    public partial class login : Form
    {
        
        public login()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=J:\CMS_Database\CMSdb.mdf;Integrated Security=True;Connect Timeout=30");


        private void login_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
           menu menu10 = new menu();
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from UserTbl where UserName='"+usertb.Text+"' and password='"+passtb.Text+"'",Con);  
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows[0][0].ToString()=="1")
            {
                menu10.Show();
                this.Hide();
                Con.Close();
            }
            else
            {
                MessageBox.Show("Wrong UserName or Password");
            }
            Con.Close();


        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Signup signup = new Signup();
            this.Hide();
            signup.Show();
        }
    }
}
