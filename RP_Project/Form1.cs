using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RP_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.Dispose();
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backgroundWorker1.Dispose();
            Application.Exit();
        }

        private void uploadDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ifNoItemthen = 0;
            foreach (Control c in panel2.Controls) //assuming this is a Form
            {
                ifNoItemthen = 1;
                if (c.Text == "Upload Data : Attendance")
                {
                    c.BringToFront();
                }
                else
                {
                    frmUploadDatafom_machine myForm = new frmUploadDatafom_machine();
                    myForm.TopLevel = false;
                    myForm.AutoScroll = true;
                    panel2.Controls.Add(myForm);
                    myForm.Show();
                    myForm.BringToFront();
                    cmb_openedpages.Items.Add(myForm.Text);
                   
                }

            }
            if(ifNoItemthen==0)
            {
                frmUploadDatafom_machine myForm = new frmUploadDatafom_machine();
                myForm.TopLevel = false;
                myForm.AutoScroll = true;
                panel2.Controls.Add(myForm);
                myForm.Show();
                myForm.BringToFront();
                cmb_openedpages.Items.Add(myForm.Text);
               
            }

           
        }

        private void cmb_openedpages_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Control c in panel2.Controls) //assuming this is a Form
            {

                if (c.Text == cmb_openedpages.SelectedText)
                {
                    c.BringToFront();
                }
                
               
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        

        private void manageConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ifNoItemthen = 0;
            foreach (Control c in panel2.Controls) //assuming this is a Form
            {
                ifNoItemthen = 1;
                if (c.Text == "Manage Connection")
                {
                    c.BringToFront();
                }
                else
                {
                    frmManageConnection myForm = new frmManageConnection();
                    myForm.TopLevel = false;
                    myForm.AutoScroll = true;
                    panel2.Controls.Add(myForm);
                    myForm.Show();
                    myForm.BringToFront();
                    cmb_openedpages.Items.Add(myForm.Text);

                }

            }
            if (ifNoItemthen == 0)
            {
                frmManageConnection myForm = new frmManageConnection();
                myForm.TopLevel = false;
                myForm.AutoScroll = true;
                panel2.Controls.Add(myForm);
                myForm.Show();
                myForm.BringToFront();
                cmb_openedpages.Items.Add(myForm.Text);

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //registry 
            RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Rayedox_AMS");
            //storing the values   
            int continueapplication = 0;
            if (key.GetValue("connectionstring") != null)
            {
                continueapplication = 1;
            }

            if (continueapplication == 0)
            {
                frmManageConnection frm = new frmManageConnection();
                frm.ShowDialog();
                toolStripStatusLabel2.Text = key.GetValue("connectionstring").ToString();
                toolStripStatusLabel4.Text = key.GetValue("authenticationmode").ToString();
                RayedoxVariables.connectionstring = key.GetValue("stringss").ToString();
            }
            else
            {

                toolStripStatusLabel2.Text = key.GetValue("connectionstring").ToString();
                toolStripStatusLabel4.Text = key.GetValue("authenticationmode").ToString();
                RayedoxVariables.connectionstring = key.GetValue("stringss").ToString();
            }
            backgroundWorker1.RunWorkerAsync();
            mainpage myForm = new mainpage();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            panel2.Controls.Add(myForm);
            myForm.Show();
            myForm.BringToFront();
        }

        private void backDateProcessingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ifNoItemthen = 0;
            foreach (Control c in panel2.Controls) //assuming this is a Form
            {
                ifNoItemthen = 1;
                if (c.Text == "Back Date Processing")
                {
                    c.BringToFront();
                }
                else
                {
                    frmBackDateProcessing myForm = new frmBackDateProcessing();
                    myForm.TopLevel = false;
                    myForm.AutoScroll = true;
                    panel2.Controls.Add(myForm);
                    myForm.Show();
                    myForm.BringToFront();
                    cmb_openedpages.Items.Add(myForm.Text);

                }

            }
            if (ifNoItemthen == 0)
            {
                frmBackDateProcessing myForm = new frmBackDateProcessing();
                myForm.TopLevel = false;
                myForm.AutoScroll = true;
                panel2.Controls.Add(myForm);
                myForm.Show();
                myForm.BringToFront();
                cmb_openedpages.Items.Add(myForm.Text);

            }

        }

        private void addEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ifNoItemthen = 0;
            foreach (Control c in panel2.Controls) //assuming this is a Form
            {
                ifNoItemthen = 1;
                if (c.Text == "Add Employee")
                {
                    c.BringToFront();
                }
                else
                {
                    frmAddEmployee myForm = new frmAddEmployee();
                    myForm.TopLevel = false;
                    myForm.AutoScroll = true;
                    panel2.Controls.Add(myForm);
                    myForm.Show();
                    myForm.BringToFront();
                    cmb_openedpages.Items.Add(myForm.Text);

                }

            }
            if (ifNoItemthen == 0)
            {
                frmAddEmployee myForm = new frmAddEmployee();
                myForm.TopLevel = false;
                myForm.AutoScroll = true;
                panel2.Controls.Add(myForm);
                myForm.Show();
                myForm.BringToFront();
                cmb_openedpages.Items.Add(myForm.Text);

            }
        }

        private void viewEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ifNoItemthen = 0;
            foreach (Control c in panel2.Controls) //assuming this is a Form
            {
                ifNoItemthen = 1;
                if (c.Text == "View Employee")
                {
                    c.BringToFront();
                }
                else
                {
                    frmViewEmployee myForm = new frmViewEmployee();
                    myForm.TopLevel = false;
                    myForm.AutoScroll = true;
                    panel2.Controls.Add(myForm);
                    myForm.Show();
                    myForm.BringToFront();
                    cmb_openedpages.Items.Add(myForm.Text);

                }

            }
            if (ifNoItemthen == 0)
            {
                frmViewEmployee myForm = new frmViewEmployee();
                myForm.TopLevel = false;
                myForm.AutoScroll = true;
                panel2.Controls.Add(myForm);
                myForm.Show();
                myForm.BringToFront();
                cmb_openedpages.Items.Add(myForm.Text);

            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (1 == 1)
            {
                try
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        label4.Text = System.DateTime.Now.Hour.ToString()+":" + System.DateTime.Now.Minute.ToString()+":" + System.DateTime.Now.Second.ToString()+ ":" + System.DateTime.Now.Millisecond.ToString();

                    }));
                }
                catch(Exception ae)
                {

                }
               
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            backgroundWorker1.Dispose();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void shiftMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ifNoItemthen = 0;
            foreach (Control c in panel2.Controls) //assuming this is a Form
            {
                ifNoItemthen = 1;
                if (c.Text == "Shift Master")
                {
                    c.BringToFront();
                }
                else
                {
                    frmShiftMaster myForm = new frmShiftMaster();
                    myForm.TopLevel = false;
                    myForm.AutoScroll = true;
                    panel2.Controls.Add(myForm);
                    myForm.Show();
                    myForm.BringToFront();
                    cmb_openedpages.Items.Add(myForm.Text);

                }

            }
            if (ifNoItemthen == 0)
            {
                frmShiftMaster myForm = new frmShiftMaster();
                myForm.TopLevel = false;
                myForm.AutoScroll = true;
                panel2.Controls.Add(myForm);
                myForm.Show();
                myForm.BringToFront();
                cmb_openedpages.Items.Add(myForm.Text);

            }
        }

        private void leaveMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int ifNoItemthen = 0;
            foreach (Control c in panel2.Controls) //assuming this is a Form
            {
                ifNoItemthen = 1;
                if (c.Text == "Shift Master")
                {
                    c.BringToFront();
                }
                else
                {
                    frmLeaveMaster myForm = new frmLeaveMaster();
                    myForm.TopLevel = false;
                    myForm.AutoScroll = true;
                    panel2.Controls.Add(myForm);
                    myForm.Show();
                    myForm.BringToFront();
                    cmb_openedpages.Items.Add(myForm.Text);

                }

            }
            if (ifNoItemthen == 0)
            {
                frmLeaveMaster myForm = new frmLeaveMaster();
                myForm.TopLevel = false;
                myForm.AutoScroll = true;
                panel2.Controls.Add(myForm);
                myForm.Show();
                myForm.BringToFront();
                cmb_openedpages.Items.Add(myForm.Text);

            }
        }

        private void holidayMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ifNoItemthen = 0;
            foreach (Control c in panel2.Controls) //assuming this is a Form
            {
                ifNoItemthen = 1;
                if (c.Text == "Holiday Master")
                {
                    c.BringToFront();
                }
                else
                {
                    frmHolidayMaster myForm = new frmHolidayMaster();
                    myForm.TopLevel = false;
                    myForm.AutoScroll = true;
                    panel2.Controls.Add(myForm);
                    myForm.Show();
                    myForm.BringToFront();
                    cmb_openedpages.Items.Add(myForm.Text);

                }

            }
            if (ifNoItemthen == 0)
            {
                frmHolidayMaster myForm = new frmHolidayMaster();
                myForm.TopLevel = false;
                myForm.AutoScroll = true;
                panel2.Controls.Add(myForm);
                myForm.Show();
                myForm.BringToFront();
                cmb_openedpages.Items.Add(myForm.Text);

            }
        }

        private void bankMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ifNoItemthen = 0;
            foreach (Control c in panel2.Controls) //assuming this is a Form
            {
                ifNoItemthen = 1;
                if (c.Text == "Bank Master")
                {
                    c.BringToFront();
                }
                else
                {
                    frmBankMaster myForm = new frmBankMaster();
                    myForm.TopLevel = false;
                    myForm.AutoScroll = true;
                    panel2.Controls.Add(myForm);
                    myForm.Show();
                    myForm.BringToFront();
                    cmb_openedpages.Items.Add(myForm.Text);

                }

            }
            if (ifNoItemthen == 0)
            {
                frmBankMaster myForm = new frmBankMaster();
                myForm.TopLevel = false;
                myForm.AutoScroll = true;
                panel2.Controls.Add(myForm);
                myForm.Show();
                myForm.BringToFront();
                cmb_openedpages.Items.Add(myForm.Text);

            }
        }

        private void branchMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ifNoItemthen = 0;
            foreach (Control c in panel2.Controls) //assuming this is a Form
            {
                ifNoItemthen = 1;
                if (c.Text == "Branch Master")
                {
                    c.BringToFront();
                }
                else
                {
                    frmBranchMaster myForm = new frmBranchMaster();
                    myForm.TopLevel = false;
                    myForm.AutoScroll = true;
                    panel2.Controls.Add(myForm);
                    myForm.Show();
                    myForm.BringToFront();
                    cmb_openedpages.Items.Add(myForm.Text);

                }

            }
            if (ifNoItemthen == 0)
            {
                frmBranchMaster myForm = new frmBranchMaster();
                myForm.TopLevel = false;
                myForm.AutoScroll = true;
                panel2.Controls.Add(myForm);
                myForm.Show();
                myForm.BringToFront();
                cmb_openedpages.Items.Add(myForm.Text);

            }
        }

        private void companyMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ifNoItemthen = 0;
            foreach (Control c in panel2.Controls) //assuming this is a Form
            {
                ifNoItemthen = 1;
                if (c.Text == "Company Master")
                {
                    c.BringToFront();
                }
                else
                {
                    frmCompanyMaster myForm = new frmCompanyMaster();
                    myForm.TopLevel = false;
                    myForm.AutoScroll = true;
                    panel2.Controls.Add(myForm);
                    myForm.Show();
                    myForm.BringToFront();
                    cmb_openedpages.Items.Add(myForm.Text);

                }

            }
            if (ifNoItemthen == 0)
            {
                frmCompanyMaster myForm = new frmCompanyMaster();
                myForm.TopLevel = false;
                myForm.AutoScroll = true;
                panel2.Controls.Add(myForm);
                myForm.Show();
                myForm.BringToFront();
                cmb_openedpages.Items.Add(myForm.Text);

            }
        }

        private void departmentMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ifNoItemthen = 0;
            foreach (Control c in panel2.Controls) //assuming this is a Form
            {
                ifNoItemthen = 1;
                if (c.Text == "Department Master")
                {
                    c.BringToFront();
                }
                else
                {
                    frmDepartmentMaster myForm = new frmDepartmentMaster();
                    myForm.TopLevel = false;
                    myForm.AutoScroll = true;
                    panel2.Controls.Add(myForm);
                    myForm.Show();
                    myForm.BringToFront();
                    cmb_openedpages.Items.Add(myForm.Text);

                }

            }
            if (ifNoItemthen == 0)
            {
                frmDepartmentMaster myForm = new frmDepartmentMaster();
                myForm.TopLevel = false;
                myForm.AutoScroll = true;
                panel2.Controls.Add(myForm);
                myForm.Show();
                myForm.BringToFront();
                cmb_openedpages.Items.Add(myForm.Text);

            }
        }

        private void deleteEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void userControlsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void attendanceReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backgroundWorker2.RunWorkerAsync();
        }

        private void bulkInsertionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBulkInsertionEmployee frm = new frmBulkInsertionEmployee();
            frm.Show();
        }

        private void uploadAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOnlineAttendanceUpload frm = new frmOnlineAttendanceUpload();
            frm.Show();
        }

        private void uploadCredentialsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            int ifNoItemthen = 0;
            foreach (Control c in panel2.Controls) //assuming this is a Form
            {
                ifNoItemthen = 1;
                if (c.Text == "Attendance Report")
                {
                    c.BringToFront();
                }
                else
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        frmAttendanceReport myForm = new frmAttendanceReport();
                    myForm.TopLevel = false;
                    myForm.AutoScroll = true;
                    panel2.Controls.Add(myForm);
                    myForm.Show();
                    myForm.BringToFront();
                    cmb_openedpages.Items.Add(myForm.Text);
                    }));
                }

            }
            if (ifNoItemthen == 0)
            {
               
                this.Invoke(new MethodInvoker(delegate ()
                {
                    frmAttendanceReport myForm = new frmAttendanceReport();
                    myForm.TopLevel = false;
                    myForm.AutoScroll = true;

                    panel2.Controls.Add(myForm);

                    myForm.Show();
                    myForm.BringToFront();
                    cmb_openedpages.Items.Add(myForm.Text);
                }));
                

            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void shiftRoasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ifNoItemthen = 0;
            foreach (Control c in panel2.Controls) //assuming this is a Form
            {
                ifNoItemthen = 1;
                if (c.Text == "Employee Shift Roaster")
                {
                    c.BringToFront();
                }
                else
                {
                    frmShiftRoaster myForm = new frmShiftRoaster();
                    myForm.TopLevel = false;
                    myForm.AutoScroll = true;
                    panel2.Controls.Add(myForm);
                    myForm.Show();
                    myForm.BringToFront();
                    cmb_openedpages.Items.Add(myForm.Text);

                }

            }
            if (ifNoItemthen == 0)
            {
                frmShiftRoaster myForm = new frmShiftRoaster();
                myForm.TopLevel = false;
                myForm.AutoScroll = true;
                panel2.Controls.Add(myForm);
                myForm.Show();
                myForm.BringToFront();
                cmb_openedpages.Items.Add(myForm.Text);

            }
        }

        private void masterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            
        }

        private void findEmploWhoseDataIsNotPresentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            findEmploWhoseDataIsNotPresent frm = new findEmploWhoseDataIsNotPresent();
            frm.Show();
        }

        private void reprocessTheAttendanceWhoseAttendanceIsNotBeingMarkedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRe_processtheBackDate frm = new frmRe_processtheBackDate();
            frm.Show();
        }

        private void changeEntryLossTimeAndOutTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangeEntryTime frm = new frmChangeEntryTime();
            frm.Show();
        }
    }
}
