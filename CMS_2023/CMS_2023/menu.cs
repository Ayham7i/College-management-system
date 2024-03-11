using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS_2023
{
    public partial class menu : Form
    {
        public menu()
        {
           
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
                   }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleProgressBar1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            this.Hide();
            login login = new login();
            login.Show();
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            students students = new students();
            students.Show();
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
           Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            teachers teachers = new teachers();
            teachers.Show();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Students_Click(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Courses courses = new Courses();
            courses.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Departments departments = new Departments();    
            departments.Show();
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Fees fees = new Fees();
            fees.Show();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Users users = new Users();
            users.Show();
            
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            this.Hide();
            dashboard.Show();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu menu3 = new menu();
            menu3.Show();
        }

        private void label2_Click_2(object sender, EventArgs e)
        {
          //  tim.Text = DateTime.Now.ToLongTimeString();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
