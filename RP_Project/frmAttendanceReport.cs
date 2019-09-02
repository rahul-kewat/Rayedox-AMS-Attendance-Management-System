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
using CrystalDecisions.CrystalReports.Engine;

namespace RP_Project
{
    public partial class frmAttendanceReport : Form
    {
        public frmAttendanceReport()
        {
            InitializeComponent();
        }

        private void frmAttendanceReport_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAttendanceReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 fc = (Form1)Application.OpenForms["form1"];
            if (fc != null)
            {
                fc.cmb_openedpages.Items.Remove("Attendance Report");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dailyAttendanceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RayedoxVariables.currentReport = "Absentee Monthly Report";
            // Absentee Monthly Report
            frmReportOrderBy frm = new frmReportOrderBy("D");
            frm.ShowDialog();
            if (frm.orderby != "")
            {
                SqlConnection conn = new SqlConnection(RayedoxVariables.connectionstring);
                SqlCommand cmd;
                SqlDataAdapter da;
                DataSet1 ds = new DataSet1();
                string stingadd1 = "select * from view_attendance where 1=1" + frm.orderby;
                conn.Open();
                cmd = new SqlCommand(stingadd1, conn);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds.tblAttendance);
                cmd.Dispose();
                da.Dispose();



                rptDailyAttendance rpt = new rptDailyAttendance();                
                rpt.SetDataSource(ds);


                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.RefreshReport();

                cmd.Dispose();
                da.Dispose();
                conn.Close();
                try
                {
                    try
                    {
                        rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Text, "D:\\Rayedoxreport.txt" + ".txt");
                    }
                    catch
                    {
                        rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Text, "E:\\Rayedoxreport.txt" + ".txt");
                    }
                }
                catch
                {
                    rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Text, "F:\\Rayedoxreport.txt" + ".txt");
                }

            }
        }

        private void dailyAbsenteeReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportOrderBy frm = new frmReportOrderBy("D");
            frm.ShowDialog();
            if (frm.orderby != "")
            {
                SqlConnection conn = new SqlConnection(RayedoxVariables.connectionstring);
                SqlCommand cmd;
                SqlDataAdapter da;
                DataSet1 ds = new DataSet1();
                string stingadd1 = "select * from view_attendance  where present='A' or present='WTP' or present='SUN'" + frm.orderby;
                conn.Open();
                cmd = new SqlCommand(stingadd1, conn);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds.tblAttendance);
                cmd.Dispose();
                da.Dispose();



                rptDailyAbsentReport rpt = new rptDailyAbsentReport();
                rpt.SetDataSource(ds);


                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.RefreshReport();

                cmd.Dispose();
                da.Dispose();
                conn.Close();
                try
                {
                    try
                    {
                        rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Text, "D:\\Rayedoxreport.txt" + ".txt");
                    }
                    catch
                    {
                        rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Text, "E:\\Rayedoxreport.txt" + ".txt");
                    }
                }
                catch
                {
                    rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Text, "F:\\Rayedoxreport.txt" + ".txt");
                }

            }
        }

        private void dailyPresentReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportOrderBy frm = new frmReportOrderBy("D");
            frm.ShowDialog();
            if (frm.orderby != "")
            {
                SqlConnection conn = new SqlConnection(RayedoxVariables.connectionstring);
                SqlCommand cmd;
                SqlDataAdapter da;
                DataSet1 ds = new DataSet1();
                string stingadd1 = "select * from view_attendance  where present='P'" + frm.orderby;
                conn.Open();
                cmd = new SqlCommand(stingadd1, conn);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds.tblAttendance);
                cmd.Dispose();
                da.Dispose();


                rptDailyPresentReport rpt = new rptDailyPresentReport();
                rpt.SetDataSource(ds);


                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.RefreshReport();

                cmd.Dispose();
                da.Dispose();
                conn.Close();
                try
                {
                    try
                    {
                        rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Text, "D:\\Rayedoxreport.txt" + ".txt");
                    }
                    catch
                    {
                        rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Text, "E:\\Rayedoxreport.txt" + ".txt");
                    }
                }
                catch
                {
                    rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Text, "F:\\Rayedoxreport.txt" + ".txt");
                }

            }
        }

        private void attendanceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportOrderBy frm = new frmReportOrderBy("M");
            frm.ShowDialog();
            if (frm.orderby != "")
            {
                SqlConnection conn = new SqlConnection(RayedoxVariables.connectionstring);
                SqlCommand cmd;
                SqlDataAdapter da;
                DataSet1 ds = new DataSet1();
                string stingadd1 = "select * from view_attendance where 1=1" + frm.orderby;
                conn.Open();
                cmd = new SqlCommand(stingadd1, conn);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds.tblAttendance);
                cmd.Dispose();
                da.Dispose();



                rptMonthlyAttendanceReport rpt = new rptMonthlyAttendanceReport();
                rpt.SetDataSource(ds);


                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.RefreshReport();

                cmd.Dispose();
                da.Dispose();
                conn.Close();
                try
                {
                    try
                    {
                        rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Text, "D:\\Rayedoxreport.txt" + ".txt");
                    }
                    catch
                    {
                        rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Text, "E:\\Rayedoxreport.txt" + ".txt");
                    }
                }
                catch
                {
                    rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Text, "F:\\Rayedoxreport.txt" + ".txt");
                }
            }
        }

        private void absenteeReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportOrderBy frm = new frmReportOrderBy("M");
            frm.ShowDialog();
            if (frm.orderby != "")
            {
                SqlConnection conn = new SqlConnection(RayedoxVariables.connectionstring);
                SqlCommand cmd;
                SqlDataAdapter da;
                DataSet1 ds = new DataSet1();
                string stingadd1 = "select * from view_attendance where present='A' or present='WTP' or present='SUN'" + frm.orderby;
                conn.Open();
                cmd = new SqlCommand(stingadd1, conn);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds.tblAttendance);
                cmd.Dispose();
                da.Dispose();



                rptMonthlyAbsentReport rpt = new rptMonthlyAbsentReport();
                rpt.SetDataSource(ds);


                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.RefreshReport();

                cmd.Dispose();
                da.Dispose();
                conn.Close();
                try
                {
                    try
                    {
                        rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Text, "D:\\Rayedoxreport.txt" + ".txt");
                    }
                    catch
                    {
                        rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Text, "E:\\Rayedoxreport.txt" + ".txt");
                    }
                }
                catch
                {
                    rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Text, "F:\\Rayedoxreport.txt" + ".txt");
                }

            }
        }

        private void presentReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportOrderBy frm = new frmReportOrderBy("M");
            frm.ShowDialog();
            if (frm.orderby != "")
            {
                SqlConnection conn = new SqlConnection(RayedoxVariables.connectionstring);
                SqlCommand cmd;
                SqlDataAdapter da;
                DataSet1 ds = new DataSet1();
                string stingadd1 = "select * from view_attendance where present='P' " + frm.orderby;
                conn.Open();
                cmd = new SqlCommand(stingadd1, conn);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds.tblAttendance);
                cmd.Dispose();
                da.Dispose();



                rptMonthlyPresentReport rpt = new rptMonthlyPresentReport();
                rpt.SetDataSource(ds);


                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.RefreshReport();

                cmd.Dispose();
                da.Dispose();
                conn.Close();
                try
                {
                    try
                    {
                        rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Text, "D:\\Rayedoxreport.txt" + ".txt");
                    }
                    catch
                    {
                        rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Text, "E:\\Rayedoxreport.txt" + ".txt");
                    }
                }
                catch
                {
                    rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Text, "F:\\Rayedoxreport.txt" + ".txt");
                }

            }

        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {

        }

      

        private void saveAsTXTToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dailyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
