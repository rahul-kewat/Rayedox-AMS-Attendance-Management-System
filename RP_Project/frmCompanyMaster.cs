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
    public partial class frmCompanyMaster : Form
    {
        public frmCompanyMaster()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCompanyMaster_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 fc = (Form1)Application.OpenForms["form1"];
            if (fc != null)
            {
                fc.cmb_openedpages.Items.Remove("Company Master");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection conn = new SqlConnection(RayedoxVariables.connectionstring);
                SqlCommand cmd = new SqlCommand("insert into companymaster values(@COMPANYCODE,@COMPANYNAME,@COMPANYADDRESS,@SHORTNAME,@PANNUM,@TANNUMBER,@TDSCIRCLE,@LCNO,@PFNO)", conn);
                cmd.Parameters.AddWithValue("COMPANYCODE", textBox1.Text);
                cmd.Parameters.AddWithValue("COMPANYNAME", textBox3.Text);
                cmd.Parameters.AddWithValue("COMPANYADDRESS", textBox2.Text);
                cmd.Parameters.AddWithValue("SHORTNAME", textBox5.Text);
                cmd.Parameters.AddWithValue("PANNUM", textBox6.Text);
                cmd.Parameters.AddWithValue("TANNUMBER", textBox7.Text);
                cmd.Parameters.AddWithValue("TDSCIRCLE", textBox8.Text);
                cmd.Parameters.AddWithValue("LCNO", textBox9.Text);
                cmd.Parameters.AddWithValue("PFNO", textBox10.Text);
                int k = cmd.ExecuteNonQuery();
            }
            catch (Exception ae)
            {
                MessageBox.Show("Please try another Company code as it's already present.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(RayedoxVariables.connectionstring);
            SqlCommand cmd = new SqlCommand("delete from bankmaster where COMPANYCODE=@COMPANYCODE", conn);
            cmd.Parameters.AddWithValue("COMPANYCODE", textBox1.Text);
            int k = cmd.ExecuteNonQuery();
        }
    }
}
