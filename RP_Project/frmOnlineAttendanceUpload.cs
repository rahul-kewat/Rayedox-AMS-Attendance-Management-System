using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace RP_Project
{
    public partial class frmOnlineAttendanceUpload : Form
    {
        public frmOnlineAttendanceUpload()
        {
            InitializeComponent();
        }
        int isuploading = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            if(isuploading==1)
            {
                this.WindowState = FormWindowState.Minimized;
            }
            else
            {
                this.Close();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        static string connstring = "SERVER=166.62.10.48;PORT=3306;DATABASE=rayedox;UID=rayedoxadmin;PASSWORD=rahul123";
        MySqlConnection conn = new MySqlConnection(connstring);

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            button1.Enabled = false;
        }

        private void frmOnlineAttendanceUpload_Load(object sender, EventArgs e)
        {
            label5.Text = "";
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            isuploading = 1;
            try
            {
                this.Invoke(new MethodInvoker(delegate ()
                {

                    label5.Text = "Connecting to server..";

                }));

                int check = 0;
                try
                {
                    conn.Open();
                    this.Invoke(new MethodInvoker(delegate ()
                    {

                        label5.Text = "Connected to the server ...";

                    }));

                }
                catch (Exception ae)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {

                        label5.Text = "Unable to connect to the server. Please connect to the Internet and try again.";

                    }));


                    check = 1;
                }

                if (check == 0)
                {
                    try
                    {
                        int countofrecords = 0;
                        SqlConnection connss = new SqlConnection(RayedoxVariables.connectionstring);
                        connss.Open();
                        SqlCommand cmd = new SqlCommand("select count(*) as totalcount from tblattendance where date>='" + dateTimePicker1.Text + "' and date<='" + dateTimePicker2.Text + "'", connss);
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            countofrecords = Convert.ToInt32(dr["totalcount"].ToString());
                            this.Invoke(new MethodInvoker(delegate ()
                            {

                                progressBar1.Maximum = countofrecords;

                            }));

                        }
                        cmd.Dispose();
                        dr.Dispose();
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            label5.Text = "Uploading Data ...";
                        }));

                        cmd = new SqlCommand("select *  from tblattendance where date>='" + dateTimePicker1.Text + "' and date<='" + dateTimePicker2.Text + "'", connss);
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            MySqlCommand cmd1 = new MySqlCommand("insert into tblattendance values('" + dr[0].ToString() + "','" + dr[1].ToString() + "','" + dr[2].ToString() + "','" + dr[3].ToString() + "','" + dr[4].ToString() + "','" + dr[5].ToString() + "','" + dr[6].ToString() + "','" + dr[7].ToString() + "','" + dr[8].ToString() + "','" + dr[9].ToString() + "','" + dr[10].ToString() + "','" + dr[11].ToString() + "','" + dr[12].ToString() + "','" + dr[13].ToString() + "','" + dr[14].ToString() + "','" + dr[15].ToString() + "','" + dr[16].ToString() + "','" + dr[17].ToString() + "','" + dr[18].ToString() + "','" + dr[19].ToString() + "','" + dr[20].ToString() + "','" + dr[21].ToString() + "','" + dr[22].ToString() + "','" + dr[23].ToString() + "','" + dr[24].ToString() + "','" + dr[25].ToString() + "')", conn);
                            cmd1.ExecuteNonQuery();
                            this.Invoke(new MethodInvoker(delegate ()
                            {

                                progressBar1.Value = progressBar1.Value + 1;

                            }));

                        }
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            label5.Text = "Data Uploaded Sucessfully";

                        }));

                        MessageBox.Show("Data Upload Completed");
                    }
                    catch (Exception ae)
                    {
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            label5.Text = "Something went wrong. Please try again...";

                        }));

                        MessageBox.Show("Something went wrong. Please try again...");
                    }
                }
            }
            catch { }
            try
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    button1.Enabled = false;

                }));
            }
            catch { }
        }

        private void frmOnlineAttendanceUpload_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isuploading == 1)
            {
                this.WindowState= FormWindowState.Minimized;
            }
            else
            {
                this.Close();
            }
        }
    }
}
