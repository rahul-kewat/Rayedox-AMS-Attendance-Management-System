using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RP_Project
{
    public partial class frmLoginPage : Form
    {
        public frmLoginPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="" && textBox2.Text!="")
            {
                if(textBox1.Text == "admin" && textBox2.Text == "kscm12345")
                {
                    this.Hide();
                    frmSplashScreen frm = new frmSplashScreen();
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show(this,"Invalid Login Username and Password","Rayedox Technologies",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(this, "Invalid Login Username and Password", "Rayedox Technologies", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLoginPage_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
