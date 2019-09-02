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

namespace RP_Project
{
    public partial class frmLeaveMaster : Form
    {
        public frmLeaveMaster()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLeaveMaster_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 fc = (Form1)Application.OpenForms["form1"];
            if (fc != null)
            {
                fc.cmb_openedpages.Items.Remove("Leave Master");
            }
        }

        string st = "P";
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(RayedoxVariables.connectionstring);
                SqlCommand cmd = new SqlCommand("insert into leavemaster values(@leavecode,@leavename,@leavemarkitas)", conn);
                cmd.Parameters.AddWithValue("leavecode", textBox1.Text);
                cmd.Parameters.AddWithValue("leavename", st);
                cmd.Parameters.AddWithValue("leavemarkitas", st);
                int k = cmd.ExecuteNonQuery();
            }
            catch (Exception ae)
            {
                MessageBox.Show("Please try another Leave code as it's already present.");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            st = "P";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            st = "A";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            st = "L";
        }

        private void button3_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(RayedoxVariables.connectionstring);
            SqlCommand cmd = new SqlCommand("delete from leavemaster where leavecode=@leavecode", conn);
            cmd.Parameters.AddWithValue("leavecode", textBox1.Text);
            int k = cmd.ExecuteNonQuery();
        }
    }
}
