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
    public partial class frmDepartmentMaster : Form
    {
        public frmDepartmentMaster()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDepartmentMaster_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 fc = (Form1)Application.OpenForms["form1"];
            if (fc != null)
            {
                fc.cmb_openedpages.Items.Remove("Department Master");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(RayedoxVariables.connectionstring);
                SqlCommand cmd = new SqlCommand("insert into departmentmaster values(@departmentcode,@departmentname,@departmentremark)", conn);
                cmd.Parameters.AddWithValue("departmentcode", textBox1.Text);
                cmd.Parameters.AddWithValue("departmentname", textBox3.Text);
                cmd.Parameters.AddWithValue("departmentremark", textBox2.Text);
                int k = cmd.ExecuteNonQuery();
            }
            catch (Exception ae)
            {
                MessageBox.Show("Please try another Department code as it's already present.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(RayedoxVariables.connectionstring);
            SqlCommand cmd = new SqlCommand("delete from departmentmaster where departmentcode=@departmentcode", conn);
            cmd.Parameters.AddWithValue("departmentcode", textBox1.Text);
            int k = cmd.ExecuteNonQuery();
        }
    }
}
