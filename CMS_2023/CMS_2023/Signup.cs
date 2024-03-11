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
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=J:\CMS_Database\CMSdb.mdf;Integrated Security=True;Connect Timeout=30");


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (npasstb.Text == agnpasstb.Text)
                {
                    if (nusertb.Text == "" || npasstb.Text == "" || agnpasstb.Text == "")
                    {
                        MessageBox.Show("Missing Information");
                    }
                    else
                    {
                        Con.Open();
                        SqlCommand cmd = new SqlCommand("insert into UserTbl values(" +nid.Text + ",'" + nusertb.Text + "','" + npasstb.Text + "')", Con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("User Successfully Added");

                        Con.Close();
                        // populate();
                    }
                }
                else
                {
                    MessageBox.Show("password and Retype password are not match");
                }
            }
            catch
            {
                MessageBox.Show("Something Went Wrong");
            }
        }

        private void Signup_Load(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            login login = new login();  
            this.Hide();
            login.Show();
        }
    }
}
