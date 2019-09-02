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
    public partial class frmAddEmployee : Form
    {
        public frmAddEmployee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmAddEmployee_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 fc = (Form1)(Application.OpenForms)["form1"];
            if (fc != null)
            {
                fc.cmb_openedpages.Items.Remove("Add Employee");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "" &&  textBox1.Text!="" && comboBox16.Text!="" && comboBox15.Text != "" && comboBox14.Text != "" && comboBox13.Text != "" && comboBox12.Text != "")
            {
                try
                {
                    SqlConnection conn = new SqlConnection(RayedoxVariables.connectionstring);
                    SqlCommand cmd = new SqlCommand(@"insert into TblEmployee(ACTIVE,PAYCODE,EMPNAME,GUARDIANNAME,DateOFBIRTH,DateOfJOIN,COMPANYCODE,DEPARTMENTCODE,SEX,ISMARRIED
        ,QUALIFICATION,EXPERIENCE,DESIGNATION,ADDRESS1,PINCODE1,TELEPHONE1,E_MAIL1,ADDRESS2,PINCODE2,TELEPHONE2,EMPPHOTO,EMPSIGNATURE,DivisionCode,GradeCode,PFNO,ESINO,EMPTYPE) values(@ACTIVE,@PAYCODE,@EMPNAME,@GUARDIANNAME,@DateOFBIRTH,@DateOfJOIN,@COMPANYCODE,@DEPARTMENTCODE,@SEX,@ISMARRIED
        ,@QUALIFICATION,@EXPERIENCE,@DESIGNATION,@ADDRESS1,@PINCODE1,@TELEPHONE1,@E_MAIL1,@ADDRESS2,@PINCODE2,@TELEPHONE2,@EMPPHOTO,@EMPSIGNATURE,@DivisionCode,@GradeCode,@PFNO,@ESINO,@EMPTYPE)", conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("ACTIVE", "Y");
                    cmd.Parameters.AddWithValue("PAYCODE", textBox1.Text);
                    cmd.Parameters.AddWithValue("EMPNAME", textBox2.Text);
                    cmd.Parameters.AddWithValue("GUARDIANNAME", textBox3.Text);
                    cmd.Parameters.AddWithValue("DateOFBIRTH", Convert.ToDateTime(dateTimePicker1.Text));
                    cmd.Parameters.AddWithValue("DateOFJOIN", Convert.ToDateTime(dateTimePicker2.Text));
                    cmd.Parameters.AddWithValue("COMPANYCODE", comboBox5.Text);
                    cmd.Parameters.AddWithValue("DEPARTMENTCODE", comboBox7.Text);
                    cmd.Parameters.AddWithValue("SEX", comboBox4.Text);
                    cmd.Parameters.AddWithValue("ISMARRIED", comboBox3.Text);
                    cmd.Parameters.AddWithValue("QUALIFICATION", comboBox2.Text);
                    cmd.Parameters.AddWithValue("EXPERIENCE", comboBox1.Text);
                    cmd.Parameters.AddWithValue("DESIGNATION", comboBox6.Text);
                    cmd.Parameters.AddWithValue("ADDRESS1", textBox8.Text);
                    cmd.Parameters.AddWithValue("PINCODE1", textBox17.Text);
                    cmd.Parameters.AddWithValue("TELEPHONE1", textBox11.Text);
                    cmd.Parameters.AddWithValue("E_MAIL1", textBox10.Text);
                    cmd.Parameters.AddWithValue("ADDRESS2", textBox9.Text);
                    cmd.Parameters.AddWithValue("PINCODE2", textBox18.Text);
                    cmd.Parameters.AddWithValue("TELEPHONE2", textBox4.Text);
                    cmd.Parameters.AddWithValue("EMPPHOTO", "");
                    cmd.Parameters.AddWithValue("EMPSIGNATURE", "");
                    cmd.Parameters.AddWithValue("DivisionCode", comboBox9.Text);
                    cmd.Parameters.AddWithValue("GradeCode", comboBox10.Text);
                    cmd.Parameters.AddWithValue("PFNO", textBox21.Text);
                    cmd.Parameters.AddWithValue("ESINO", textBox20.Text);
                    cmd.Parameters.AddWithValue("EMPTYPE", comboBox8.Text);
                    cmd.ExecuteNonQuery();


                    cmd.Dispose();

                    cmd = new SqlCommand("insert into tblEmployeeShiftMaster(paycode,shift1,s1remainingdays,timelossin,timelossout,s1days,offday1) values(@PAYCODE,@shift1,@s1remainingdays,@timelossin,@timelossout,@s1days,@offday1)", conn);

                    cmd.Parameters.AddWithValue("PAYCODE", textBox1.Text);
                    cmd.Parameters.AddWithValue("shift1", comboBox16.Text.Substring(comboBox16.Text.IndexOf('(')).Replace(")", "").Replace("(",""));
                    cmd.Parameters.AddWithValue("s1remainingdays", comboBox11.Text);
                    cmd.Parameters.AddWithValue("timelossin", Convert.ToDateTime((comboBox15.Text + ":" + comboBox13.Text)));
                    cmd.Parameters.AddWithValue("timelossout", Convert.ToDateTime((comboBox14.Text + ":" + comboBox12.Text)));
                    cmd.Parameters.AddWithValue("s1days", comboBox11.Text);
                    cmd.Parameters.AddWithValue("offday1", "SUNDAY");
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Employee added successfully");
                }
                catch { MessageBox.Show("Employee with the similar Paycode may already exists \n or \n If Problem continues everytime contact to your service provider"); }
            }
            else
            {
                MessageBox.Show("Please fill the form completely !");
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void frmAddEmployee_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(RayedoxVariables.connectionstring);
            SqlCommand cmd = new SqlCommand("select SHIFT,shifttime from tblShiftMaster", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                comboBox16.Items.Add(dr[0].ToString()+" ("+dr[1].ToString()+")");
            }
            cmd.Dispose();
            dr.Dispose();
            conn.Close();
        }
    }
}
