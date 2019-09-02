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
    public partial class deleteEmployee : Form
    {
        public deleteEmployee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {

                SqlConnection conn = new SqlConnection(RayedoxVariables.connectionstring);
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete from TblEmployee where paycode=" + textBox1.Text + "", conn);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("The Employee with such paycode does not exists \n or\n If Problem persists again and again then contact your service provider");
            }
        }
    }
}
