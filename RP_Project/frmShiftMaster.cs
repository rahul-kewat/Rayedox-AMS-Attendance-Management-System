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
    public partial class frmShiftMaster : Form
    {
        public frmShiftMaster()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShiftMaster_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 fc = (Form1)Application.OpenForms["form1"];
            if (fc != null)
            {
                fc.cmb_openedpages.Items.Remove("Shift Master");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(RayedoxVariables.connectionstring);
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into tblShiftMaster values(@shift,@shifttime)", conn);
                cmd.Parameters.AddWithValue("shift", textBox1.Text);
                cmd.Parameters.AddWithValue("shifttime", (comboBox1.Text + ":" + comboBox2.Text +"-"+ comboBox4.Text + ":" + comboBox5.Text));
                int k = cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Insertion Successfull");
            }
            catch (Exception ae)
            {
                MessageBox.Show("Shift name may already exists! \n or \n If problem exists always then contact your service provider");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(RayedoxVariables.connectionstring);
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete from tblShiftMaster where shift=@shift", conn);
                cmd.Parameters.AddWithValue("shift", textBox1.Text);
                int k = cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Deleted Successfull");
            }
            catch(Exception ae)
            {
                MessageBox.Show("Something went wrong!");
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmShiftMaster_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(RayedoxVariables.connectionstring);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from tblShiftMaster", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
               listBox1.Items.Add(dr[0].ToString() );

            }
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

    }
}
