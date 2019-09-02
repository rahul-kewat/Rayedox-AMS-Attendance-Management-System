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
    public partial class findEmploWhoseDataIsNotPresent : Form
    {
        public findEmploWhoseDataIsNotPresent()
        {
            InitializeComponent();
        }

        private void findEmploWhoseDataIsNotPresent_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(RayedoxVariables.connectionstring);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select paycode from tblattendance where timelossin is NULL", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                   listBox1.Items.Add( dr[0].ToString());
                }));

            }
        }
    }
}
