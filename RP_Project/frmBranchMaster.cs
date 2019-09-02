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
    public partial class frmBranchMaster : Form
    {
        public frmBranchMaster()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBranchMaster_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 fc = (Form1)Application.OpenForms["form1"];
            if (fc != null)
            {
                fc.cmb_openedpages.Items.Remove("Branch Master");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(RayedoxVariables.connectionstring);
                SqlCommand cmd = new SqlCommand("insert into branchmaster values(@branchcode,@branchname,@branchremark)", conn);
                cmd.Parameters.AddWithValue("branchcode", textBox1.Text);
                cmd.Parameters.AddWithValue("branchname", textBox3.Text);
                cmd.Parameters.AddWithValue("branchremark", textBox2.Text);
                int k = cmd.ExecuteNonQuery();
            }
            catch (Exception ae)
            {
                MessageBox.Show("Please try another Branch code as it's already present.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(RayedoxVariables.connectionstring);
            SqlCommand cmd = new SqlCommand("delete from branchmaster where branchcode=@branchcode", conn);
            cmd.Parameters.AddWithValue("branchcode", textBox1.Text);
            int k = cmd.ExecuteNonQuery();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
