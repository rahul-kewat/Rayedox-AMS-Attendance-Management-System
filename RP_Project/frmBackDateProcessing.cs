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
    public partial class frmBackDateProcessing : Form
    {
        public int stop = 1;


        public frmBackDateProcessing()
        {
            InitializeComponent();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            label19.Visible = true;
            label2.Visible = true;
            backgroundWorker1.RunWorkerAsync();
            backgroundWorker2.RunWorkerAsync();
            button3.Enabled = false;
            label8.Text = "";

        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int k = 0;

            SqlConnection conn = new SqlConnection(RayedoxVariables.connectionstring);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from TEMPORARYTT where date >='"+dateTimePicker1.Text+"' and date <='"+dateTimePicker2.Text+"';", conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                k = Convert.ToInt32( dr[0].ToString());
            }

           
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            
        }

        private void frmBackDateProcessing_Load(object sender, EventArgs e)
        {
            label19.Visible = false;
            label2.Visible = false;
            label8.Text = "";
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBackDateProcessing_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 fc = (Form1)(Application.OpenForms)["form1"];
            if (fc != null)
            {
                fc.cmb_openedpages.Items.Remove("Back Date Processing");
            }
        }
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
           
            SqlConnection conn = new SqlConnection(RayedoxVariables.connectionstring);
            conn.Open();
            SqlCommand cmd;
            cmd = new SqlCommand("select count(*) from TEMPORARYTT where date >='" + dateTimePicker1.Text + "' and date <='" + dateTimePicker2.Text + "';", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                this.Invoke(new MethodInvoker(delegate ()
                {

                    progressBar2.Maximum = Convert.ToInt32(dr[0].ToString());

                }));
               
            }
            cmd.Dispose();
            dr.Dispose();
            backgroundWorker3.WorkerSupportsCancellation = true;
            if (!backgroundWorker3.IsBusy)
            {
                backgroundWorker3.CancelAsync();
                backgroundWorker3.RunWorkerAsync();
                backgroundWorker3.WorkerSupportsCancellation = true;

            }
            
            
            try
            {
                cmd = new SqlCommand("proce_ProcessShifts", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@startingdate", SqlDbType.VarChar, 255).Value = dateTimePicker1.Text;
                cmd.Parameters.Add("@endingdate", SqlDbType.VarChar, 255).Value = dateTimePicker2.Text;
                cmd.CommandTimeout = 3600;
                int k = cmd.ExecuteNonQuery();
                cmd.Dispose();
                dr.Dispose();

                cmd = new SqlCommand("SELECT paycode  FROM tblattendance where timelossin is NULL;", conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {

                        listBox1.Items.Add(dr[0].ToString() + " record doesn't Exists");

                    }));

                }

                cmd.Dispose();
                dr.Dispose();
                this.Invoke(new MethodInvoker(delegate ()
                {

                    label8.Text = "Processing Completed";

                }));
               
            }
            catch { }

        }
        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            stop = 0;
            
            button3.Enabled = true;

            label19.Visible = false;
            label2.Visible = false;
            progressBar2.Hide();
            backgroundWorker3.Dispose();
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
           
        }
        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                while (1 == 1)
                {
                    SqlConnection conn = new SqlConnection(RayedoxVariables.connectionstring);
                    conn.Open();
                    SqlCommand cmd;
                    cmd = new SqlCommand("select progress from tempProgressTrack", conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        try
                        {
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                try
                                {
                                    progressBar2.Value = Convert.ToInt32(dr[0].ToString());
                                }
                                catch
                                {

                                }
                            }));
                        }
                        catch
                        {


                        }


                    }
                }
            }
            catch { backgroundWorker3.Dispose(); }


        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            stop = 0;
        }
        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            label19.Visible = false;
            label2.Visible = false;
           
        }
    }
}
