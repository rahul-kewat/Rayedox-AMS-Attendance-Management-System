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
    public partial class frmShiftRoaster : Form
    {
        public frmShiftRoaster()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(RayedoxVariables.connectionstring);
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void empWiseShiftRoasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        private void bulkShiftRoasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn.Open();
            panel5.Visible = false;
            if (available_shifts.Text == "Shift 1")
            {
                SqlCommand cmd = new SqlCommand("update tblEmployeeShiftMaster set shift1='"+label22.Text+"-"+label23.Text+ "',s1days=" + textBox2.Text + " where paycode=" + emp_code.Text+"", conn);
                cmd.ExecuteNonQuery();
            }
            if (available_shifts.Text == "Shift 2")
            {
                SqlCommand cmd = new SqlCommand("update tblEmployeeShiftMaster set shift2='" + label22.Text + "-" + label23.Text + "',s2days=" + textBox2.Text + " where paycode=" + emp_code.Text + "", conn);
                cmd.ExecuteNonQuery();
            }
            if (available_shifts.Text == "Shift 3")
            {
                SqlCommand cmd = new SqlCommand("update tblEmployeeShiftMaster set shift3='" + label22.Text + "-" + label23.Text + "',s3days=" + textBox2.Text + " where paycode=" + emp_code.Text + "", conn);
                cmd.ExecuteNonQuery();
            }
            if (available_shifts.Text == "Shift 4")
            {
                SqlCommand cmd = new SqlCommand("update tblEmployeeShiftMaster set shift4='" + label22.Text + "-" + label23.Text + "',s4days=" + textBox2.Text + " where paycode=" + emp_code.Text + "", conn);
                cmd.ExecuteNonQuery();
            }
            if (available_shifts.Text == "Shift 5")
            {
                SqlCommand cmd = new SqlCommand("update tblEmployeeShiftMaster set shift5='" + label22.Text + "-" + label23.Text + "',s5days=" + textBox2.Text + " where paycode=" + emp_code.Text + "", conn);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
            MessageBox.Show("Done");
        }
        
        private void frmShiftRoaster_Load(object sender, EventArgs e)
        {
            label18.Text = "";
            label22.Text = ""; label23.Text = ""; label26.Text = ""; label27.Text = ""; 
            conn.Open();
            SqlCommand cmd = new SqlCommand("select distinct(paycode) from tblEmployeeShiftMaster", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                emp_code.Items.Add(dr[0].ToString());
            }
            cmd.Dispose();
            dr.Dispose();


            cmd = new SqlCommand("select * from tblShiftMaster", conn);
            dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                shift_code.Items.Add(dr[0].ToString() + " ("+dr[1].ToString()+" )");
                shift_code1.Items.Add(dr[0].ToString() + " (" + dr[1].ToString() + " )");
            }
            conn.Close();
        }

        private void emp_code_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            label22.Text=""; label23.Text = ""; label26.Text = ""; label27.Text = "";
            RemoveWorkingShifts.Items.Clear();
            UpdateWorkingshift.Items.Clear();
            available_shifts.Items.Clear();
            label3.Text = "";
            label18.Text = "";
            SqlCommand cmd = new SqlCommand("select empname,shift1,shift2,shift3,shift4,shift5 from TblEmployee inner join tblEmployeeShiftMaster on TblEmployee.PAYCODE=tblEmployeeShiftMaster.paycode where tblEmployeeShiftMaster.paycode='"+emp_code.Text+"'", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                label3.Text= (dr[0].ToString());
                if (dr[1].ToString() != "") { label18.Text = label18.Text + " Shift 1(" + dr[1].ToString() + ")"; }
                if (dr[2].ToString() != "") { label18.Text = label18.Text + "Shift 2 (" + dr[2].ToString() + ")"; }
                if (dr[3].ToString() != "") { label18.Text = label18.Text + "Shift 3 (" + dr[3].ToString() + ")"; }
                if (dr[4].ToString() != "") { label18.Text = label18.Text + "Shift 4 (" + dr[4].ToString() + ")"; }
                if (dr[5].ToString() != "") { label18.Text = label18.Text + "Shift 5 (" + dr[5].ToString() + ")"; }


                if (dr[1].ToString() == "")
                {
                    available_shifts.Items.Add("Shift 1");
                }

                if (dr[1].ToString() != "" && dr[2].ToString()=="")
                {
                    available_shifts.Items.Add("Shift 2");
                }
                if (dr[2].ToString() != "" && dr[3].ToString() == "")
                {
                    available_shifts.Items.Add("Shift 3");
                }
                if (dr[3].ToString() != "" && dr[4].ToString() == "")
                {
                    available_shifts.Items.Add("Shift 4");
                }
                if (dr[4].ToString() != "" && dr[5].ToString() == "")
                {
                    available_shifts.Items.Add("Shift 5");
                }
                if (dr[5].ToString() != "")
                {
                    available_shifts.Items.Add("No Shift Available");
                }

                // add those shifts which are not added to the employee
                if (dr[1].ToString() != "")
                {
                    UpdateWorkingshift.Items.Add("Shift 1");
                    RemoveWorkingShifts.Items.Add("Shift 1");
                }
                if (dr[2].ToString() != "")
                {
                    UpdateWorkingshift.Items.Add("Shift 2");
                    RemoveWorkingShifts.Items.Add("Shift 2");
                }
                if (dr[3].ToString() != "")
                {
                    UpdateWorkingshift.Items.Add("Shift 3");
                    RemoveWorkingShifts.Items.Add("Shift 3");
                }
                if (dr[4].ToString() != "")
                {
                    UpdateWorkingshift.Items.Add("Shift 4");
                    RemoveWorkingShifts.Items.Add("Shift 4");
                }
                if (dr[5].ToString() != "")
                {
                    UpdateWorkingshift.Items.Add("Shift 5");
                    RemoveWorkingShifts.Items.Add("Shift 5");
                }



            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel6.Visible = true;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel7.Visible = true;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel6.Visible = false;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;

            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel7.Visible = false;

            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
        }

        private void shift_code_SelectedIndexChanged(object sender, EventArgs e)
        {
            label22.Text = shift_code.Text.Substring(5,5);
            label23.Text = shift_code.Text.Substring(11,5);
        }

        private void shift_code2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void shift_code1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label26.Text = shift_code1.Text.Substring(5, 5);
            label27.Text = shift_code1.Text.Substring(11, 5);

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            conn.Open();
            if (RemoveWorkingShifts.Text == "Shift 1")
            {
                MessageBox.Show("You Cant remove shift1 ");
            }
            if (RemoveWorkingShifts.Text == "Shift 2")
            {
                SqlCommand cmd = new SqlCommand("update tblEmployeeShiftMaster set shift2='',s2days='' where paycode=" + emp_code.Text + "", conn);
                cmd.ExecuteNonQuery();
            }
            if (RemoveWorkingShifts.Text == "Shift 3")
            {
                SqlCommand cmd = new SqlCommand("update tblEmployeeShiftMaster set shift3='',s3days='' where paycode=" + emp_code.Text + "", conn);
                cmd.ExecuteNonQuery();
            }
            if (RemoveWorkingShifts.Text == "Shift 4")
            {
                SqlCommand cmd = new SqlCommand("update tblEmployeeShiftMaster set shift4='',s4days='' where paycode=" + emp_code.Text + "", conn);
                cmd.ExecuteNonQuery();
            }
            if (RemoveWorkingShifts.Text == "Shift 5")
            {
                SqlCommand cmd = new SqlCommand("update tblEmployeeShiftMaster set shift5='',s5days='' where paycode=" + emp_code.Text + "", conn);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
            MessageBox.Show("Done");
        }

        private void button7_ChangeUICues(object sender, UICuesEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (UpdateWorkingshift.Text == "Shift 1")
            {
                SqlCommand cmd = new SqlCommand("update tblEmployeeShiftMaster set shift1='" + label26.Text + "-" + label27.Text + "' , s1days="+textBox1.Text+ ",timelossin='"+comboBox15.Text+":"+comboBox13.Text+"' , timelossout='"+comboBox14.Text+":"+comboBox12.Text+"' where paycode=" + emp_code.Text + "", conn);
                cmd.ExecuteNonQuery();
            }
            if (UpdateWorkingshift.Text == "Shift 2")
            {
                SqlCommand cmd = new SqlCommand("update tblEmployeeShiftMaster set shift2='" + label26.Text + "-" + label27.Text + "' ,s2days=" + textBox1.Text + ",timelossin='" + comboBox15.Text + ":" + comboBox13.Text + "' , timelossout='" + comboBox14.Text + ":" + comboBox12.Text + "' where paycode=" + emp_code.Text + "", conn);
                cmd.ExecuteNonQuery();
            }
            if (UpdateWorkingshift.Text == "Shift 3")
            {
                SqlCommand cmd = new SqlCommand("update tblEmployeeShiftMaster set shift3='" + label26.Text + "-" + label27.Text + "',s3days=" + textBox1.Text + ",timelossin='" + comboBox15.Text + ":" + comboBox13.Text + "' , timelossout='" + comboBox14.Text + ":" + comboBox12.Text + "' where paycode=" + emp_code.Text + "", conn);
                cmd.ExecuteNonQuery();
            }
            if (UpdateWorkingshift.Text == "Shift 4")
            {
                SqlCommand cmd = new SqlCommand("update tblEmployeeShiftMaster set shift4='" + label26.Text + "-" + label27.Text + "',s4days=" + textBox1.Text + ",timelossin='" + comboBox15.Text + ":" + comboBox13.Text + "' , timelossout='" + comboBox14.Text + ":" + comboBox12.Text + "' where paycode=" + emp_code.Text + "", conn);
                cmd.ExecuteNonQuery();
            }
            if (UpdateWorkingshift.Text == "Shift 5")
            {
                SqlCommand cmd = new SqlCommand("update tblEmployeeShiftMaster set shift5='" + label26.Text + "-" + label27.Text + "',s5days=" + textBox1.Text + ",timelossin='" + comboBox15.Text + ":" + comboBox13.Text + "' , timelossout='" + comboBox14.Text + ":" + comboBox12.Text + "' where paycode=" + emp_code.Text + "", conn);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
            MessageBox.Show("Done");
        }
        int countofclickonlink = 0;
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel8.Visible = true;
            countofclickonlink = countofclickonlink + 1;
            if (countofclickonlink == 1)
            {
                SqlConnection conn = new SqlConnection(RayedoxVariables.connectionstring);
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from tblShiftMaster", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox3.Items.Add(dr[0].ToString() + "(" + dr[1].ToString() + ")");
                    comboBox6.Items.Add(dr[0].ToString() + "(" + dr[1].ToString() + ")");

                }
                conn.Close();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text != "")
            {

                string newtime = comboBox6.Text.Substring(4).Replace("(", "").Replace(")", "").Trim();
                string oldtime = comboBox3.Text.Substring(4).Replace("(", "").Replace(")", "").Trim();
                SqlConnection conn = new SqlConnection(RayedoxVariables.connectionstring);
                conn.Open();
                SqlCommand cmd = new SqlCommand("update tblEmployeeShiftMaster set shift1=convert(text,'"+newtime+"') where shift1 like convert(text,'"+oldtime+"')", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update data successfully");
                conn.Close();
            }
            else
            {
                MessageBox.Show("Please specify the old shift and new shift timings");
            }
        }
    }
}
