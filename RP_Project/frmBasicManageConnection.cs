using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Data.SqlClient;

namespace RP_Project
{
    public partial class frmBasicManageConnection : Form
    {
        public frmBasicManageConnection()
        {
            InitializeComponent();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        int authentication_mode = 1;//means by default windows authentication mode will be used
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (authentication_mode == 1)
                {
                    try
                    {
                        SqlConnection conn = new SqlConnection("Data Source=" + CmbServerName.Text + ";Initial Catalog=master;Integrated Security=True");
                        conn.Open();
                        conn.Close();
                        MessageBox.Show("Connection Made Successfully! ", "Rayedox Technologies Connection Event", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //registry 
                        RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Rayedox_AMS");
                        //storing the values   
                        key.SetValue("ConnectionString", CmbServerName.Text);
                        key.SetValue("stringss", "Data Source=" + CmbServerName.Text + ";Initial Catalog=Rayedox_AMS;Integrated Security=True");
                        key.SetValue("AuthenticationMode", "1");
                        key.SetValue("Username", "");
                        key.SetValue("Password", "");
                        this.Close();
                    }
                    catch (Exception ae)
                    {
                        MessageBox.Show("Logon failed. \nTry using different authentication mode or different Username and Password", "Rayedox Technologies Login Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (authentication_mode == 2)
                {
                    try
                    {
                        SqlConnection conn = new SqlConnection("Data Source=" + CmbServerName.Text + ";Initial Catalog=master;User ID=" + txtUserName.Text + ";Password=" + txtPassword.Text + ";");
                        conn.Open();
                        conn.Close();
                        MessageBox.Show("Connection Made Successfully! ", "Rayedox Technologies Connection Event", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //registry 
                        RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Rayedox_AMS");
                        //storing the values   
                        key.SetValue("ConnectionString", CmbServerName.Text);
                        key.SetValue("stringss", "Data Source=" + CmbServerName.Text + ";Initial Catalog=Rayedox_AMS;User ID=" + txtUserName.Text + ";Password=" + txtPassword.Text + ";");
                        key.SetValue("AuthenticationMode", "2");
                        key.SetValue("Username", txtUserName.Text);
                        key.SetValue("Password", txtPassword.Text);

                        this.Close();
                    }
                    catch (Exception ae)
                    {
                        MessageBox.Show("Logon failed. \nTry using different authentication mode or different Username and Password", "Rayedox Technologies Login Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ae)
            {
                this.Close();
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Windows Authentication")
            {
                txtUserName.Enabled = false;
                txtPassword.Enabled = false;
                authentication_mode = 1;
            }
            if (comboBox1.Text == "Mixed Authentication")
            {
                txtUserName.Enabled = true;
                txtPassword.Enabled = true;
                authentication_mode = 2;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Windows Authentication")
            {
                txtUserName.Enabled = false;
                txtPassword.Enabled = false;
                authentication_mode = 1;
            }
            if (comboBox1.Text == "Mixed Authentication")
            {
                txtUserName.Enabled = true;
                txtPassword.Enabled = true;
                authentication_mode = 2;
            }
        }

 
        private void label10_Click(object sender, EventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
           
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void frmBasicManageConnection_Load(object sender, EventArgs e)
        {
            txtUserName.Enabled = false;
            txtPassword.Enabled = false;
        }
    }
}
