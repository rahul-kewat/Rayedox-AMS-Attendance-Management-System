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
    public partial class frmBankMaster : Form
    {
        public frmBankMaster()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBankMaster_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 fc = (Form1)Application.OpenForms["form1"];
            if (fc != null)
            {
                fc.cmb_openedpages.Items.Remove("Bank Master");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(RayedoxVariables.connectionstring);
                SqlCommand cmd = new SqlCommand("insert into bankmaster values(@BANKCODE,@BANKNAME,@BANKADDRESS)", conn);
                cmd.Parameters.AddWithValue("BANKCODE", textBox1.Text);
                cmd.Parameters.AddWithValue("BANKNAME", textBox3.Text);
                cmd.Parameters.AddWithValue("BANKADDRESS", textBox2.Text);
                int k = cmd.ExecuteNonQuery();
            }catch(Exception ae)
            {
                MessageBox.Show("Something went wrong");
            }

      
        }
           

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(RayedoxVariables.connectionstring);
            SqlCommand cmd = new SqlCommand("delete from bankmaster where BANKCODE=@bankcode", conn);
            cmd.Parameters.AddWithValue("BANKCODE", textBox1.Text);
            int k = cmd.ExecuteNonQuery();

        }
    }
}
