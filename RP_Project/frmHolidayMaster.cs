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
    public partial class frmHolidayMaster : Form
    {
        public frmHolidayMaster()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmHolidayMaster_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 fc = (Form1)Application.OpenForms["form1"];
            if (fc != null)
            {
                fc.cmb_openedpages.Items.Remove("Holiday Master");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(RayedoxVariables.connectionstring);
                SqlCommand cmd = new SqlCommand("insert into holidaymaster values(@holidayname,@holidaydate,@holidayremark)", conn);
                cmd.Parameters.AddWithValue("holidayname", textBox1.Text);
                cmd.Parameters.AddWithValue("holidaydate", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("holidayremark", textBox2.Text);
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
            SqlCommand cmd = new SqlCommand("delete from holidaymaster where holidayname=@holidayname", conn);
            cmd.Parameters.AddWithValue("holidayname", textBox1.Text);
            int k = cmd.ExecuteNonQuery();
        }
    }
}
