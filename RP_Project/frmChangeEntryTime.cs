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
    public partial class frmChangeEntryTime : Form
    {
        public frmChangeEntryTime()
        {
            InitializeComponent();
        }

        private void comboBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            listBox1.Items.Add(comboBox3.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
           
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmChangeEntryTime_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(RayedoxVariables.connectionstring);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select distinct(paycode) from tblEmployee", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox3.Items.Add(dr[0].ToString());

            }
            conn.Close();
            comboBox6.Items.Add("All");
            cmd.Dispose();
            dr.Dispose();
            conn = new SqlConnection(RayedoxVariables.connectionstring);
            conn.Open();
            cmd = new SqlCommand("select distinct(paycode) from tblEmployee", conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox3.Items.Add(dr[0].ToString());

            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(RayedoxVariables.connectionstring);
                conn.Open();
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    SqlCommand cmd = new SqlCommand("update tblEmployeeShiftMaster set timelossin='" + comboBox1.Text + ":" + comboBox2.Text + "', timelossout='" + comboBox4.Text + ":" + comboBox5.Text + "' where paycode='"+listBox1.Items[i].ToString().Trim()+"'", conn);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Updated Successfully");
                conn.Close();
            }
            catch { MessageBox.Show("Something went wrong"); }
        }
    }
}
