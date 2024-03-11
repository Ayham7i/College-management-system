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
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }

        private void guna2CustomGradientPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
 SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=J:\CMS_Database\CMSdb.mdf;Integrated Security=True;Connect Timeout=30");
        private void Users_Load(object sender, EventArgs e)
        {
            populate();
        }
        private void populate()
        {
            Con.Open();
            string query = "select * from UserTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet(); 
            sda.Fill(ds);
            UserDGV.DataSource = ds.Tables[0];

            Con.Close();
            
        }
        private void search()
        {
            Con.Open();
            string query = "select * from UserTbl where Userid = " + Userid.Text + "";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            UserDGV.DataSource = ds.Tables[0];

            Con.Close();
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
         try
            {
                if(Userid.Text ==""|| Username.Text ==""||Userpass.Text =="")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                 Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into UserTbl values("+ Userid.Text +",'"+Username.Text+"','"+Userpass.Text+"')",Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Successfully Added");

                 Con.Close();
                populate();
                }   
            }
            catch
            {
                MessageBox.Show("Something Went Wrong");
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu menu3 = new menu();
            menu3.Show();
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UserDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        Userid.Text = UserDGV.SelectedRows[0].Cells[0].Value.ToString();
        Username.Text = UserDGV.SelectedRows[0].Cells[1].Value.ToString();
        Userpass.Text = UserDGV.SelectedRows[0].Cells[2].Value.ToString();

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
         try
            {
                if(Userid.Text =="")
                {
                    MessageBox.Show("Enter The User Id");
                }
                else
                {
                    Con.Open();
                    string query = "delete from UserTbl where Userid=" + Userid.Text + ";";
                    SqlCommand cmd = new SqlCommand(query,Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Deleted Successfully");
                    Con.Close();
                    populate();

                }

            }
            catch
            {
                MessageBox.Show("Opps....!! User Not Deleted");
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Userid.Text == "" || Username.Text == "" || Userpass.Text == "")
                {
                    MessageBox.Show("Missing Data");
                }
                else
                {
                    Con.Open();
                    string query = "update UserTbl set UserName='" + Username.Text + "',password='" + Userpass.Text + "' where Userid=" + Userid.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Updated Successfully");
                    Con.Close();
                    populate();
                }

            }
            catch
            {
                MessageBox.Show("Ooops...!! User not Updated");

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

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            search();
        }

        private void guna2Button20_Click(object sender, EventArgs e)
        {
            populate();
        }
    }
}
