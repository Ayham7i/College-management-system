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
    public partial class Fees : Form
    {
        public Fees()
        {
            InitializeComponent();
            
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=J:\CMS_Database\CMSdb.mdf;Integrated Security=True;Connect Timeout=30");
        private void fillDepartment()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select studentid from Studenttbl ", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("studentid", typeof(int));
            dt.Load(rdr);
            stutbl.ValueMember = "studentid";
            stutbl.DataSource = dt;

            Con.Close();


        }
        private void populate()
        {
            Con.Open();
            string query = "select * from feestbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            FeesDGV.DataSource = ds.Tables[0];

            Con.Close();
        }
        private void search()
        {
            Con.Open();
            string query = "select * from feestbl where feesnumber = " + feesnum.Text + "";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            FeesDGV.DataSource = ds.Tables[0];

            Con.Close();
        }

        private void updatestd()
        {
            Con.Open();
            string query = "update Studenttbl set studentfees='" + feesamount.Text +"' where studentid=" + stutbl.SelectedValue.ToString() + ";";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            //MessageBox.Show("User Updated Successfully");
            Con.Close();

        }


        private void guna2CustomGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu menu4 = new menu();
            menu4.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (feesnum.Text == "" || studentname.Text == "" || stutbl.Text == "" || feesperiod.Text == "" || feesamount.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    Con.Open();
                    string date = feesperiod.Value.Year.ToString();
                    SqlDataAdapter da = new SqlDataAdapter("select count(*) from feestbl where studentid="+stutbl.SelectedValue.ToString()+" and feesperiod='"+date+"'",Con );
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        MessageBox.Show("No Dues For the selected Period");
                        Con.Close();
                    }
                    else
                    {

                        //Con.Open();

                        SqlCommand cmd = new SqlCommand("insert into feestbl values(" + feesnum.Text + ",'" + studentname.Text + "','" + stutbl.SelectedValue.ToString() + "','" + date + "','" + feesamount.Text + "')", Con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Fees Successfully Added");

                        Con.Close();
                        populate();
                        updatestd();
                    }

                }
            }
            catch
            {
                MessageBox.Show("Something Went Wrong");
            }
        }

        private void Fees_Load(object sender, EventArgs e)
        {
            fillDepartment();
            populate();
            


        }

        private void stutbl_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Con.Open();
            string query = "select * from Studenttbl where studentid=" + stutbl.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                studentname.Text = dr["studentname"].ToString();
            }

            Con.Close();

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("FEES RECEIPT", new Font("Century", 25, FontStyle.Bold),Brushes.Black,new Point(230) );
            e.Graphics.DrawString("Receipt Number: ", new Font("Century", 20, FontStyle.Bold), Brushes.BlueViolet, new Point(40,50));
            e.Graphics.DrawString(FeesDGV.SelectedRows[0].Cells[0].Value.ToString(), new Font("Century", 20, FontStyle.Bold), Brushes.Black, new Point(300, 50));

            e.Graphics.DrawString("Student Usn: ", new Font("Century", 20, FontStyle.Bold), Brushes.BlueViolet, new Point(40, 85));
            e.Graphics.DrawString(FeesDGV.SelectedRows[0].Cells[1].Value.ToString(), new Font("Century", 20, FontStyle.Bold), Brushes.Black, new Point(300, 85));

            e.Graphics.DrawString("Student Name: ", new Font("Century", 20, FontStyle.Bold), Brushes.BlueViolet, new Point(40, 115));
            e.Graphics.DrawString(FeesDGV.SelectedRows[0].Cells[2].Value.ToString(), new Font("Century", 20, FontStyle.Bold), Brushes.Black, new Point(300, 115));

            e.Graphics.DrawString("Period:  ", new Font("Century", 20, FontStyle.Bold), Brushes.BlueViolet, new Point(40, 145));
            e.Graphics.DrawString(FeesDGV.SelectedRows[0].Cells[3].Value.ToString(), new Font("Century", 20, FontStyle.Bold), Brushes.Black, new Point(300, 145));

            e.Graphics.DrawString("Amount: ", new Font("Century", 20, FontStyle.Bold), Brushes.BlueViolet, new Point(40, 175));
            e.Graphics.DrawString("YER " + FeesDGV.SelectedRows[0].Cells[4].Value.ToString(), new Font("Century", 20, FontStyle.Bold), Brushes.Black, new Point(300, 175));






        }

        private void FeesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(printPreviewDialog1.ShowDialog()==DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (feesnum.Text == "")
                {
                    MessageBox.Show("Enter The Fees Id");
                }
                else
                {
                    Con.Open();
                    string query = "delete from feestbl where feesnumber=" + feesnum.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Fees Deleted Successfully");
                    Con.Close();
                    populate();

                }

            }
            catch
            {
                MessageBox.Show("Opps....!! Fees is Not Deleted");
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

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();  
            this.Hide();
            dashboard.Show();
        }

        private void guna2Button18_Click(object sender, EventArgs e)
        {
            search();
        }

        private void guna2Button20_Click(object sender, EventArgs e)
        {
            populate();
        }
    }
}
