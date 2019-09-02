using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelDataReader;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace RP_Project
{
    public partial class frmBulkInsertionEmployee : Form
    {
        public frmBulkInsertionEmployee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            string fileExt = string.Empty;
            OpenFileDialog file = new OpenFileDialog(); //open dialog to choose file  
            this.Invoke(new MethodInvoker(delegate ()
            {

                label2.Text = "Reterieving Data from file ...";

            }));
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK) //if there is a file choosen by the user  
            {
                filePath = file.FileName; //get the path of the file  
                textBox1.Text = filePath;
                if (0 == 0)
                {
                    try
                    {
                        DataTable dtExcel = new DataTable();
                        dtExcel = ReadExcel(filePath, fileExt); //read excel file  
                        dataGridView1.Visible = true;
                        dataGridView1.DataSource = dtExcel;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }

            this.Invoke(new MethodInvoker(delegate ()
            {

                label2.Text = "Completed.. Now click on the upload button to upload the data";

            }));

        }
        public DataTable ReadExcel(string fileName, string fileExt)
        {
            string conn = string.Empty;
            DataTable dtexcel = new DataTable();
            if (fileExt.CompareTo(".xls") == 0)
                conn = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';"; //for below excel 2007  
            else
                conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=Yes';"; //for above excel 2007  
            using (OleDbConnection con = new OleDbConnection(conn))
            {
                try
                {
                    OleDbDataAdapter oleAdpt = new OleDbDataAdapter("select * from [MASTER$]", con); //here we read data from sheet1  
                    
                    oleAdpt.Fill(dtexcel); //fill excel data into dataTable  
                }
                catch { }
            }
            return dtexcel;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            backgroundWorker1.RunWorkerAsync();

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            string StrQuery;
            this.Invoke(new MethodInvoker(delegate ()
            {
                label2.Text = "Gathering Data ...";
            }));

            try
            {
                using (SqlConnection conn = new SqlConnection(RayedoxVariables.connectionstring))
                {
                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        conn.Open();
                        for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                        {

                            StrQuery = @"INSERT INTO TblEmployee VALUES ('"
                                + dataGridView1.Rows[i].Cells["ACTIVE"].Value.ToString().Trim() + "', '"
                                + dataGridView1.Rows[i].Cells["PAYCODE"].Value.ToString().Trim() + "', '"
                                + dataGridView1.Rows[i].Cells["EMPNAME"].Value.ToString().Trim() + "', '"
                                + dataGridView1.Rows[i].Cells["GUARDIANNAME"].Value.ToString().Trim() + "', '"
                                + Convert.ToDateTime(dataGridView1.Rows[i].Cells["DateOFBIRTH"].Value.ToString()) + "', '"
                                + Convert.ToDateTime(dataGridView1.Rows[i].Cells["DateOFJOIN"].Value.ToString()) + "', '"
                                + dataGridView1.Rows[i].Cells["COMPANYCODE"].Value.ToString().Trim() + "', '"
                                + dataGridView1.Rows[i].Cells["DEPARTMENTCODE"].Value.ToString().Trim() + "', '"
                                + dataGridView1.Rows[i].Cells["SEX"].Value.ToString().Trim() + "', '"
                                + dataGridView1.Rows[i].Cells["ISMARRIED"].Value.ToString().Trim() + "', '"
                                + dataGridView1.Rows[i].Cells["QUALIFICATION"].Value.ToString().Trim() + "', '"
                                + dataGridView1.Rows[i].Cells["EXPERIENCE"].Value.ToString().Trim() + "', '"
                                + dataGridView1.Rows[i].Cells["DESIGNATION"].Value.ToString().Trim() + "',' "
                                + dataGridView1.Rows[i].Cells["ADDRESS1"].Value.ToString().Trim() + "', '"
                                + dataGridView1.Rows[i].Cells["PINCODE1"].Value.ToString().Trim() + "', '"
                                + dataGridView1.Rows[i].Cells["TELEPHONE1"].Value.ToString().Trim() + "', '"
                                + dataGridView1.Rows[i].Cells["E_MAIL1"].Value.ToString().Trim() + "', '"
                                + dataGridView1.Rows[i].Cells["ADDRESS2"].Value.ToString().Trim() + "', '"
                                + dataGridView1.Rows[i].Cells["PINCODE2"].Value.ToString().Trim() + "', '"
                                + dataGridView1.Rows[i].Cells["TELEPHONE2"].Value.ToString().Trim() + "', '"
                                + dataGridView1.Rows[i].Cells["EMPPHOTO"].Value.ToString().Trim() + "', '"
                                + dataGridView1.Rows[i].Cells["EMPSIGNATURE"].Value.ToString().Trim() + "', '"
                                + dataGridView1.Rows[i].Cells["DivisionCode"].Value.ToString().Trim() + "', '"
                                + dataGridView1.Rows[i].Cells["GradeCode"].Value.ToString().Trim() + "', '"
                                + dataGridView1.Rows[i].Cells["PFNO"].Value.ToString().Trim() + "', '"
                                + dataGridView1.Rows[i].Cells["ESINO"].Value.ToString().Trim() + "', '"
                                + dataGridView1.Rows[i].Cells["EMPTYPE"].Value.ToString().Trim() + "');";
                            comm.CommandText = StrQuery;
                            comm.ExecuteNonQuery();


                        }
                    }

                }
            }
            catch(Exception ae) { MessageBox.Show(ae.ToString()); }

            this.Invoke(new MethodInvoker(delegate ()
            {

                label2.Text = "Inserting Data ...";

            }));


            SqlCommand cmd1;
           
                SqlConnection conn2 = new SqlConnection(RayedoxVariables.connectionstring);
                conn2.Open();
            try
            {
                cmd1 = new SqlCommand("insert into tblShiftMaster(SHIFT,shifttime) values('A','09:00-16:00')", conn2);
                cmd1.ExecuteNonQuery();
                cmd1.Dispose();
            }
            catch { }
               

                SqlConnection conn1 = new SqlConnection(RayedoxVariables.connectionstring);
                conn1.Open();
                
                SqlCommand cmd = new SqlCommand("select paycode from tblEmployee", conn1);
                SqlDataReader dr12 = cmd.ExecuteReader();
                while (dr12.Read())
                {
                    cmd1 = new SqlCommand("insert into tblEmployeeShiftMaster(paycode,shift1,s1remainingdays,timelossin,timelossout,s1days,offday1) values ('" + dr12[0].ToString() + "','09:00-16:00',7,'00:20:00.0000000','00:10:00.0000000',7,'SUNDAY')", conn2);
                    cmd1.ExecuteNonQuery();
                    cmd1.Dispose();
                }
             
                conn2.Close();
            

            this.Invoke(new MethodInvoker(delegate ()
            {

                label2.Text = "Uploading Completed ...";

            }));
        }

        private void frmBulkInsertionEmployee_Load(object sender, EventArgs e)
        {
            label2.Text = "";
            
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button2.Enabled = true;
        }
    }
}
