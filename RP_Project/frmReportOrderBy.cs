using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RP_Project
{
    public partial class frmReportOrderBy : Form
    {
        string a_getinfo = "";
        public frmReportOrderBy(string getinfo)
        {
            InitializeComponent();
            a_getinfo = getinfo;
        }

        private void frmReportOrderBy_Load(object sender, EventArgs e)
        {

        }
        public string orderby
        {
            get
            {
                return stingadd;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stingadd = "";
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            stingadd = "";
            this.Close();
        }
        string stingadd = "order by paycode";
        private void button2_Click(object sender, EventArgs e)
        {
            if(a_getinfo=="D")
            { stingadd = " and date='" + dateTimePicker1.Text+"'"; }
            if (a_getinfo == "M")
            { stingadd = " and date>='" + dateTimePicker1.Text + "' and date<='" + dateTimePicker2.Text + "'" +stingadd+""; }
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            stingadd = "order by paycode";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            stingadd = "order by DEPARTMENTCODE";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            stingadd = "order by designation";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            stingadd = "order by paycode,DEPARTMENTCODE";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            stingadd = "order by paycode,designation";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
