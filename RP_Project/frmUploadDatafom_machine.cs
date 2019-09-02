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
using System.IO;


namespace RP_Project
{
    public partial class frmUploadDatafom_machine : Form
    {
        
        public frmUploadDatafom_machine()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUploadDatafom_machine_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 fc = (Form1)Application.OpenForms["form1"];
            if (fc != null)
            {
                fc.cmb_openedpages.Items.Remove("Upload Data : Attendance");
            }
        }

        private void frmUploadDatafom_machine_Load(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            label2.Visible = false;
            panel4.Visible = false;
            label19.Visible = false;
            label23.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            toolStripStatusLabel1.Text = "";
            textBox1.Text = openFileDialog1.FileName;
            button2.Enabled = false;
            if(textBox1.Text.Substring(textBox1.Text.Length-4,4)==".txt")
            {
                button2.Enabled = true;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            backgroundWorker1.RunWorkerAsync();
            pictureBox1.Visible = true;
            label2.Visible = true;
            label19.Visible = true;

        }
        string mindate = "";
        string maxdate = "";
         
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
         
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox1.Visible = false;
            label2.Visible = false;
            label19.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
        }

        private void label18_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
        }


        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            
            SqlConnection conn = new SqlConnection(RayedoxVariables.connectionstring);
            SqlCommand cmd1;
            conn.Open();
            if (mindate == "")
            {
                cmd1 = new SqlCommand("select min(date) from temporarytt", conn);
                cmd1.CommandTimeout = 3600;
                SqlDataReader dr = cmd1.ExecuteReader();
                while (dr.Read())
                {
                    mindate = dr[0].ToString();
                }
                cmd1.Dispose();
                dr.Dispose();
            }

            cmd1 = new SqlCommand("proce_ProcessMissingDates", conn);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add("@startingdate1", SqlDbType.VarChar, 50).Value = mindate;
            cmd1.Parameters.Add("@endingdate1", SqlDbType.VarChar, 50).Value = maxdate;

            cmd1.CommandTimeout = 3600;
            int k = cmd1.ExecuteNonQuery();

            conn.Close();
           
            
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
