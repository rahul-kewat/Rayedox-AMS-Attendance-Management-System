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
using Microsoft.Win32;

namespace RP_Project
{
    public partial class frmSplashScreen : Form
    {
        public frmSplashScreen()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {

                label7.Text = "Please Wait ...";

            }));
            try
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
                    frmBasicManageConnection frm = new frmBasicManageConnection();
                    frm.ShowDialog();
                    RayedoxVariables.connectionstring = key.GetValue("stringss").ToString();
                }
                else
                {
                    RayedoxVariables.connectionstring = key.GetValue("stringss").ToString();
                }

            }
            catch
            {
                MessageBox.Show("Please try to manage connection ");
                Application.Exit();
            }

            int checkingconnection = 0;
            try
            {
                SqlConnection conntry = new SqlConnection(RayedoxVariables.connectionstring);
                conntry.Open();
                conntry.Close();
            }
            catch {
                checkingconnection = 1;
            }



            this.Invoke(new MethodInvoker(delegate ()
            {

                label7.Text = "Initializing Application ...";

            }));




            if (checkingconnection == 1)
            {
                //connecting to master database
                string st = RayedoxVariables.connectionstring.Replace("Rayedox_AMS", "master");
                SqlConnection conn = new SqlConnection(st);
                conn.Open();
               


                try
                {
                    //creating database
                    SqlCommand cmd = new SqlCommand("CREATE DATABASE Rayedox_AMS;", conn);
                    int k1 = cmd.ExecuteNonQuery();
                    cmd.Dispose();


                    //creating tables
                    cmd = new SqlCommand(@"
use  Rayedox_AMS;

CREATE TABLE [dbo].[Holiday](
	[HDate] [datetime] NOT NULL,
	[HOLIDAY] [char](20) NULL,
	[ADJUSTMENTHOLIDAY] [datetime] NULL,
	[OT_FACTOR] [float] NULL,
	[COMPANYCODE] [char](3) NOT NULL,
	[DEPARTMENTCODE] [char](3) NOT NULL,
 CONSTRAINT [PK_HOLIDAY] PRIMARY KEY CLUSTERED 
(
	[HDate] ASC,
	[COMPANYCODE] ASC,
	[DEPARTMENTCODE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]





CREATE TABLE [dbo].[LeaveCredit](
	[Paycode] [char](10) NULL,
	[ForMonth] [datetime] NULL,
	[LeaveCode] [char](3) NULL,
	[CreditAmount] [float] NULL,
	[RunDate] [datetime] NULL
) ON [PRIMARY]




CREATE TABLE [dbo].[MachineRawPunch](
	[CARDNO] [char](10) NOT NULL,
	[OFFICEPUNCH] [datetime] NOT NULL,
	[P_DAY] [char](1) NULL,
	[ISMANUAL] [char](1) NULL,
	[ReasonCode] [char](3) NULL,
	[MC_NO] [char](3) NULL,
	[INOUT] [char](1) NULL,
	[PAYCODE] [char](10) NULL,
 CONSTRAINT [PK_MRP] PRIMARY KEY CLUSTERED 
(
	[CARDNO] ASC,
	[OFFICEPUNCH] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]





CREATE TABLE [dbo].[tblattendance](
	[paycode] [int] NOT NULL,
	[date] [date] NOT NULL,
	[time] [varchar](255) NULL,
	[timelossin] [time](7) NULL,
	[timelossout] [nchar](10) NULL,
	[entrytime] [time](7) NULL,
	[outime] [time](7) NULL,
	[currentshift] [varchar](255) NULL,
	[shiftendtime] [varchar](255) NULL,
	[shiftcode] [varchar](3) NULL,
	[present] [varchar](3) NULL,
	[shift1] [varchar](255) NULL,
	[s1remdays] [int] NULL,
	[s1days] [int] NULL,
	[shift2] [varchar](255) NULL,
	[s2remdays] [int] NULL,
	[s2days] [int] NULL,
	[shift3] [varchar](255) NULL,
	[s3remdays] [int] NULL,
	[s3days] [int] NULL,
	[shift4] [varchar](255) NULL,
	[s4remdays] [int] NULL,
	[s4days] [int] NULL,
	[shift5] [varchar](255) NULL,
	[s5remdays] [int] NULL,
	[s5days] [int] NULL,
 CONSTRAINT [PAYCODE_DATE_PK] PRIMARY KEY CLUSTERED 
(
	[paycode] ASC,
	[date] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]







CREATE TABLE [dbo].[tblBankMaster](
	[BANKCODE] [char](3) NOT NULL,
	[BANKNAME] [char](50) NULL,
	[BANKADDRESS] [char](150) NULL,
	[SHORTNAME] [char](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[BANKCODE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]





CREATE TABLE [dbo].[tblbranch](
	[BRANCHCODE] [char](3) NOT NULL,
	[BRANCHNAME] [char](35) NULL,
PRIMARY KEY CLUSTERED 
(
	[BRANCHCODE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]







CREATE TABLE [dbo].[tblCalander](
	[MDate] [datetime] NOT NULL,
	[PROCess] [char](1) NULL,
	[NRTCPROC] [char](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[MDate] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]






CREATE TABLE [dbo].[tblCompany](
	[COMPANYCODE] [char](3) NOT NULL,
	[COMPANYNAME] [char](50) NULL,
	[COMPANYADDRESS] [char](150) NULL,
	[SHORTNAME] [char](10) NULL,
	[PANNUM] [char](25) NULL,
	[TANNUMBER] [char](25) NULL,
	[TDSCIRCLE] [char](25) NULL,
	[LCNO] [char](25) NULL,
	[PFNO] [char](12) NULL,
PRIMARY KEY CLUSTERED 
(
	[COMPANYCODE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]






CREATE TABLE [dbo].[tblcustomer](
	[PAYCODE] [char](10) NOT NULL,
	[CARDNO] [char](8) NULL,
	[EMPLOYEE_NAME] [char](25) NULL,
	[FATHER_NAME] [char](30) NULL,
	[DATEOFBIRTH] [datetime] NULL,
	[DATEOFJOIN] [datetime] NULL,
	[LEAVINGDATE] [datetime] NULL,
	[LEAVINGREASON] [char](35) NULL,
	[COMPANYNAME] [char](50) NULL,
	[DEPARTMENTNAME] [char](45) NULL,
	[CATAGORYNAME] [char](35) NULL,
	[DIVISIONNAME] [char](45) NULL,
	[GRADENAME] [char](45) NULL,
	[SEX] [char](1) NULL,
	[MARRIED] [char](1) NULL,
	[BUS] [char](10) NULL,
	[QUALIFICATION] [char](20) NULL,
	[EXPERIENCE] [char](20) NULL,
	[DESIGNATION] [char](25) NULL,
	[ADDRESS1] [char](100) NULL,
	[PINCODE1] [char](8) NULL,
	[TELEPHONE1] [char](20) NULL,
	[E_MAIL1] [char](50) NULL,
	[ADDRESS2] [char](100) NULL,
	[PINCODE2] [char](10) NULL,
	[TELEPHONE2] [char](20) NULL,
	[BLOODGROUP] [char](3) NULL,
	[GROSS] [numeric](10, 2) NULL,
	[BASIC] [numeric](10, 2) NULL,
	[PAYMENTBY] [char](1) NULL,
	[BANKACC] [char](25) NULL,
	[EMPLOYEETYPE] [char](1) NULL,
	[PF_CODE] [char](12) NULL,
	[PF_NO] [numeric](5, 0) NULL,
	[ESI_NO] [char](12) NULL,
	[PAN_NO] [char](12) NULL,
	[DA_RATE] [numeric](10, 2) NULL,
	[HRA_RATE] [numeric](10, 2) NULL,
	[CONV_RATE] [numeric](8, 2) NULL,
	[MED_RATE] [numeric](8, 2) NULL,
	[EARNING_1] [numeric](8, 2) NULL,
	[EARNING_2] [numeric](8, 2) NULL,
	[EARNING_3] [numeric](8, 2) NULL,
	[EARNING_4] [numeric](8, 2) NULL,
	[EARNING_5] [numeric](8, 2) NULL,
	[EARNING_6] [numeric](8, 2) NULL,
	[EARNING_7] [numeric](8, 2) NULL,
	[EARNING_8] [numeric](8, 2) NULL,
	[EARNING_9] [numeric](8, 2) NULL,
	[EARNING_10] [numeric](8, 2) NULL,
	[DEDUCTION_1] [numeric](8, 2) NULL,
	[DEDUCTION_2] [numeric](8, 2) NULL,
	[DEDUCTION_3] [numeric](8, 2) NULL,
	[DEDUCTION_4] [numeric](8, 2) NULL,
	[DEDUCTION_5] [numeric](8, 2) NULL,
	[DEDUCTION_6] [numeric](8, 2) NULL,
	[DEDUCTION_7] [numeric](8, 2) NULL,
	[DEDUCTION_8] [numeric](8, 2) NULL,
	[DEDUCTION_9] [numeric](8, 2) NULL,
	[DEDUCTION_10] [numeric](8, 2) NULL,
	[TDS_RATE] [numeric](8, 2) NULL,
	[PF_ALLOWED] [char](1) NULL,
	[ESI_ALLOWED] [char](1) NULL,
	[VPF_ALLOWED] [char](1) NULL,
	[BONUS_ALLOWED] [char](1) NULL,
	[GRADUTY_ALLOWED] [char](1) NULL,
	[PROF_TAX_ALLOWED] [char](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[PAYCODE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]





ALTER TABLE [dbo].[tblcustomer] ADD  DEFAULT (0) FOR [GROSS]


ALTER TABLE [dbo].[tblcustomer] ADD  DEFAULT (0) FOR [BASIC]


ALTER TABLE [dbo].[tblcustomer] ADD  DEFAULT ('') FOR [BANKACC]


ALTER TABLE [dbo].[tblcustomer] ADD  DEFAULT (0) FOR [DA_RATE]


ALTER TABLE [dbo].[tblcustomer] ADD  DEFAULT (0) FOR [HRA_RATE]


ALTER TABLE [dbo].[tblcustomer] ADD  DEFAULT (0) FOR [CONV_RATE]


ALTER TABLE [dbo].[tblcustomer] ADD  DEFAULT (0) FOR [MED_RATE]


ALTER TABLE [dbo].[tblcustomer] ADD  DEFAULT (0) FOR [EARNING_1]


ALTER TABLE [dbo].[tblcustomer] ADD  DEFAULT (0) FOR [EARNING_2]


ALTER TABLE [dbo].[tblcustomer] ADD  DEFAULT (0) FOR [EARNING_3]


ALTER TABLE [dbo].[tblcustomer] ADD  DEFAULT (0) FOR [EARNING_4]


ALTER TABLE [dbo].[tblcustomer] ADD  DEFAULT (0) FOR [EARNING_5]


ALTER TABLE [dbo].[tblcustomer] ADD  DEFAULT (0) FOR [EARNING_6]


ALTER TABLE [dbo].[tblcustomer] ADD  DEFAULT (0) FOR [EARNING_7]


ALTER TABLE [dbo].[tblcustomer] ADD  DEFAULT (0) FOR [EARNING_8]


ALTER TABLE [dbo].[tblcustomer] ADD  DEFAULT (0) FOR [EARNING_9]


ALTER TABLE [dbo].[tblcustomer] ADD  DEFAULT (0) FOR [EARNING_10]


ALTER TABLE [dbo].[tblcustomer] ADD  DEFAULT (0) FOR [DEDUCTION_1]


ALTER TABLE [dbo].[tblcustomer] ADD  DEFAULT (0) FOR [DEDUCTION_2]


ALTER TABLE [dbo].[tblcustomer] ADD  DEFAULT (0) FOR [DEDUCTION_3]


ALTER TABLE [dbo].[tblcustomer] ADD  DEFAULT (0) FOR [DEDUCTION_4]


ALTER TABLE [dbo].[tblcustomer] ADD  DEFAULT (0) FOR [DEDUCTION_5]


ALTER TABLE [dbo].[tblcustomer] ADD  DEFAULT (0) FOR [DEDUCTION_6]


ALTER TABLE [dbo].[tblcustomer] ADD  DEFAULT (0) FOR [DEDUCTION_7]


ALTER TABLE [dbo].[tblcustomer] ADD  DEFAULT (0) FOR [DEDUCTION_8]


ALTER TABLE [dbo].[tblcustomer] ADD  DEFAULT (0) FOR [DEDUCTION_9]


ALTER TABLE [dbo].[tblcustomer] ADD  DEFAULT (0) FOR [DEDUCTION_10]


ALTER TABLE [dbo].[tblcustomer] ADD  DEFAULT (0) FOR [TDS_RATE]


ALTER TABLE [dbo].[tblcustomer] ADD  DEFAULT ('N') FOR [PF_ALLOWED]


ALTER TABLE [dbo].[tblcustomer] ADD  DEFAULT ('N') FOR [ESI_ALLOWED]


ALTER TABLE [dbo].[tblcustomer] ADD  DEFAULT ('N') FOR [VPF_ALLOWED]


ALTER TABLE [dbo].[tblcustomer] ADD  DEFAULT ('N') FOR [BONUS_ALLOWED]


ALTER TABLE [dbo].[tblcustomer] ADD  DEFAULT ('N') FOR [GRADUTY_ALLOWED]


ALTER TABLE [dbo].[tblcustomer] ADD  DEFAULT ('N') FOR [PROF_TAX_ALLOWED]





CREATE TABLE [dbo].[tblDepartment](
	[DEPARTMENTCODE] [char](3) NOT NULL,
	[DEPARTMENTNAME] [char](45) NULL,
	[DEPARTMENTHEAD] [char](35) NULL,
	[EMAIL_ID] [char](35) NULL,
PRIMARY KEY CLUSTERED 
(
	[DEPARTMENTCODE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]




CREATE TABLE [dbo].[tblDESPANSARY](
	[DESPANSARYCODE] [char](3) NOT NULL,
	[DESPANSARYNAME] [char](50) NULL,
	[DESPANSARYADDRESS] [char](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[DESPANSARYCODE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]



CREATE TABLE [dbo].[tblDivision](
	[DivisionCode] [char](3) NOT NULL,
	[DivisionName] [char](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[DivisionCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]





CREATE TABLE [dbo].[TblEmployee](
	[ACTIVE] [char](6) NULL,
	[PAYCODE] [char](10) NOT NULL,
	[EMPNAME] [char](100) NULL,
	[GUARDIANNAME] [char](100) NULL,
	[DateOFBIRTH] [datetime] NULL,
	[DateOFJOIN] [datetime] NULL,
	[COMPANYCODE] [char](6) NULL,
	[DEPARTMENTCODE] [char](6) NULL,
	[SEX] [char](6) NULL,
	[ISMARRIED] [char](6) NULL,
	[QUALIFICATION] [char](20) NULL,
	[EXPERIENCE] [char](20) NULL,
	[DESIGNATION] [char](100) NULL,
	[ADDRESS1] [char](100) NULL,
	[PINCODE1] [char](8) NULL,
	[TELEPHONE1] [char](20) NULL,
	[E_MAIL1] [char](50) NULL,
	[ADDRESS2] [char](100) NULL,
	[PINCODE2] [char](10) NULL,
	[TELEPHONE2] [char](20) NULL,
	[EMPPHOTO] [char](100) NULL,
	[EMPSIGNATURE] [char](100) NULL,
	[DivisionCode] [char](6) NULL,
	[GradeCode] [char](6) NULL,
	[PFNO] [char](12) NULL,
	[ESINO] [char](12) NULL,
	[EMPTYPE] [char](6) NULL,
PRIMARY KEY CLUSTERED 
(
	[PAYCODE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]




CREATE TABLE [dbo].[tblEmployeeShiftMaster](
	[paycode] [int] NULL,
	[shift1] [text] NULL,
	[shift2] [text] NULL,
	[shift3] [text] NULL,
	[shift4] [text] NULL,
	[shift5] [text] NULL,
	[s1remainingdays] [int] NULL,
	[s2remainingdays] [int] NULL,
	[s3remainingdays] [int] NULL,
	[s4remainingdays] [int] NULL,
	[s5remainingdays] [int] NULL,
	[timelossin] [time](7) NULL,
	[timelossout] [time](7) NULL,
	[s1days] [int] NULL,
	[s2days] [int] NULL,
	[s3days] [int] NULL,
	[s4days] [int] NULL,
	[s5days] [int] NULL,
	[offday1] [varchar](50) NULL,
	[offday2] [varchar](50) NULL,
	[offday3] [varchar](50) NULL,
	[offday4] [varchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]






CREATE TABLE [dbo].[tblGrade](
	[GradeCode] [char](3) NOT NULL,
	[GradeName] [char](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[GradeCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]







CREATE TABLE [dbo].[tblHODremarks](
	[USER_R] [char](20) NOT NULL,
	[Date] [datetime] NULL,
	[Remarks] [char](250) NULL
) ON [PRIMARY]




CREATE TABLE [dbo].[tblLeaveMaster](
	[LEAVEFIELD] [char](3) NOT NULL,
	[LEAVECODE] [char](3) NULL,
	[LEAVEDESCRIPTION] [char](50) NULL,
	[ISOFFINCLUDE] [char](1) NULL,
	[ISHOLIDAYINCLUDE] [char](1) NULL,
	[ISLEAVEACCRUAL] [char](1) NULL,
	[LEAVETYPE] [char](1) NULL,
	[SMIN] [numeric](7, 2) NULL,
	[SMAX] [numeric](7, 2) NULL,
	[PRESENT] [numeric](7, 2) NULL,
	[LEAVE] [numeric](7, 2) NULL,
	[LEAVELIMIT] [numeric](7, 2) NULL,
	[FIXED] [char](1) NULL,
	[isMonthly] [char](1) NULL,
	[isCompOffType] [char](1) NULL,
	[ExpiryDays] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[LEAVEFIELD] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]





CREATE TABLE [dbo].[tblShiftMaster](
	[SHIFT] [char](3) NOT NULL,
	[shifttime] [varchar](255) NULL,
 CONSTRAINT [PK__tblShiftMaster__014935CB] PRIMARY KEY CLUSTERED 
(
	[SHIFT] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]




CREATE TABLE [dbo].[tblSMS](
	[SMSKey] [varchar](200) NULL,
	[SenderID] [varchar](100) NULL,
	[IsAbsent] [char](1) NULL,
	[AbsentSMSFor] [char](1) NULL,
	[AbsentSMSAfter] [bigint] NULL,
	[AbsentSMSTime] [datetime] NULL,
	[AbsentSMS1] [varchar](80) NULL,
	[AbsentSMS2] [varchar](80) NULL,
	[AbsentName] [char](1) NULL,
	[AbsentDate] [char](1) NULL,
	[IsLate] [char](1) NULL,
	[LateSMS1] [char](80) NULL,
	[LateSMS2] [char](80) NULL,
	[IsIn] [char](1) NULL,
	[InSMS1] [char](80) NULL,
	[InSMS2] [char](80) NULL,
	[IsOut] [char](1) NULL,
	[OutSMS1] [char](80) NULL,
	[OutSMS2] [char](80) NULL,
	[OutSMSAfter] [bigint] NULL,
	[isCalled] [char](1) NULL,
	[dbType] [char](1) NULL
) ON [PRIMARY]




CREATE TABLE [dbo].[TEMPORARYT](
	[PAYCODE] [varchar](255) NULL,
	[DATE] [varchar](255) NULL,
	[TIME] [varchar](255) NULL
) ON [PRIMARY]


create table tempProgressTrack(progress int);





 ", conn);
                    int k = cmd.ExecuteNonQuery();







                    // creating view
                    cmd.Dispose();
                    cmd = new SqlCommand(@"
 CREATE VIEW [dbo].[TEMPORARYTT] AS
  select DISTINCT(PAYCODE),substring(CONVERT(varchar,officepunch,120),0,12) AS DATE
  ,STUFF(( select ',' + substring(CONVERT(varchar,A.officepunch,120),12,19) from MachineRawPunch A  where a.PAYCODE=b.PAYCODE and substring(CONVERT(varchar,a.officepunch,120),0,12)=substring(CONVERT(varchar,b.officepunch,120),0,12) for xml path('')),1,1,'') as time
  from MachineRawPunch B
  group by PAYCODE,substring(CONVERT(varchar,officepunch,120),0,12), substring(CONVERT(varchar,officepunch,120),12,19)

", conn);
                    cmd.ExecuteNonQuery();



                    // creating view
                    cmd.Dispose();
                    cmd = new SqlCommand(@"create view [dbo].[view_attendance]
as
select tblattendance.paycode,date,time,timelossin,timelossout,entrytime,outime,currentshift,shiftendtime,shiftcode,present,shift1,s1remdays,s1days
,shift2,s2remdays,s2days,shift3,s3remdays,s3days,shift4,s4remdays,s4days,shift5,s5remdays,s5days,EMPNAME,GUARDIANNAME
,DateOFBIRTH,DateOFJOIN,COMPANYCODE,DEPARTMENTCODE,DESIGNATION,DivisionCode,GradeCode,EMPTYPE from tblattendance 
INNER JOIN TblEmployee on tblattendance.paycode= TblEmployee.paycode


", conn);
                    cmd.ExecuteNonQuery();



                    // creating procedure bulk_uploadMachineData
                    cmd.Dispose();
                    cmd = new SqlCommand(@"

CREATE PROCEDURE [dbo].[Bulk_uploadMachineData]
as
begin
BEGIN TRY
CREATE TABLE glog(
	[No] [varchar](255) NULL,
	[Mchn] [varchar](255) NULL,
	[EnNo] [varchar](255) NOT NULL,
	[Name] [varchar](255) NULL,
	[Mode] [varchar](255) NULL,
	[IOMd] [varchar](255) NULL,
	[DateTime] [varchar](255) NOT NULL,
 CONSTRAINT [PK_glog_1] PRIMARY KEY CLUSTERED 
(
	[EnNo] ASC,
	[DateTime] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END TRY
BEGIN CATCH
END CATCH

bulk insert glog
from 'C:\Users\Public\Documents\glog.txt'
with (
 FIRSTROW = 2,
fieldterminator = '\t',
rowterminator = '\n'
 )
INSERT INTO MachineRawPunch(CARDNO,OFFICEPUNCH,P_DAY,ISMANUAL,ReasonCode,MC_NO,INOUT,PAYCODE)
select substring(EnNo,3,9) AS CARDNO,REPLACE(datetime,'/','-')+'.000' AS OFFICEPUNCH,NULL AS P_DAY,NULL AS ISMANUAL,NULL AS ReasonCode,
NULL AS MC_NO,NULL AS INOUT,substring(EnNo,5,9) AS PAYCODE  FROM glog

drop table glog
 end;

", conn);
                    cmd.ExecuteNonQuery();





                    // creating procedure
                    cmd.Dispose();
                    cmd = new SqlCommand(@"

CREATE PROCEDURE [dbo].[proce_ProcessMissingDates]  @startingdate1 varchar(255),@endingdate1 varchar(255)
AS 
BEGIN
DECLARE @STARTINGDATE DATETIME
DECLARE @ENDINGDATE DATETIME
SET @STARTINGDATE=@startingdate1
SET @ENDINGDATE =@endingdate1

	WHILE(@STARTINGDATE!=@ENDINGDATE )				
		BEGIN
				DECLARE @MyCursor CURSOR;
				DECLARE @paycode int;
				DECLARE @paycode1 CHAR(10);
				BEGIN
						SET @MyCursor = CURSOR FOR
						(/* EMPLOYEES WHICH ARE ABSENT ON THE SPECIFIC DATE*/
						select distinct(paycode) from TEMPORARYTT 
						where paycode not in(
						select distinct(paycode) from TEMPORARYTT where date=@STARTINGDATE GROUP BY PAYCODE 
						))
				OPEN @MyCursor 
				FETCH NEXT FROM @MyCursor 
				INTO @paycode
					
				WHILE @@FETCH_STATUS = 0
					BEGIN
						SET @paycode1='00'+CONVERT(CHAR(10), @paycode)
						BEGIN TRY
						INSERT INTO MachineRawPunch(CARDNO,OFFICEPUNCH,PAYCODE) VALUES(@PAYCODE1,@STARTINGDATE,@PAYCODE)
						END TRY
						BEGIN CATCH
						END CATCH
						FETCH NEXT FROM @MyCursor 
						INTO @paycode
					END;
				END
				CLOSE @MyCursor ;
				DEALLOCATE @MyCursor;
				SET @STARTINGDATE=DATEADD(DAY,1,@STARTINGDATE)
		END;		
END


", conn);
                    cmd.ExecuteNonQuery();












                    // creating procedure

                    cmd.Dispose();
                    cmd = new SqlCommand(@"
CREATE PROCEDURE proce_ProcessShifts @startingdate varchar(255),@endingdate varchar(255)
AS
BEGIN
DECLARE @MyCursor CURSOR;
DECLARE @paycode int;
DECLARE @date date;
DECLARE @time varchar(255);

insert tempProgressTrack values(0);
BEGIN
    SET @MyCursor = CURSOR FOR
     select paycode,date,time from TEMPORARYTT where date>=@startingdate and date<=@endingdate
             

    OPEN @MyCursor 
    FETCH NEXT FROM @MyCursor 
    INTO @paycode,@date,@time
	DECLARE @countrecord INT
		SET @countrecord=0
    WHILE @@FETCH_STATUS = 0
    BEGIN
		declare @continue varchar(255)
		set @continue=(select count(paycode) from tblEmployeeShiftMaster where paycode=@paycode)
		if(@continue>0)
			begin
		DECLARE @entryin time
		DECLARE @entryout time
		DECLARE @timelossin time
		DECLARE @timelossout time
		DECLARE @shift1 varchar(255)
		DECLARE @shift11 varchar(255)
		DECLARE @shift2 varchar(255)
		DECLARE @shift3 varchar(255)
		DECLARE @shift4 varchar(255)
		DECLARE @shift5 varchar(255)
		DECLARE @s1remainingdays INT
		DECLARE @s2remainingdays INT
		DECLARE @s3remainingdays INT
		DECLARE @s4remainingdays INT
		DECLARE @s5remainingdays INT
		DECLARE @s1days INT
		DECLARE @s2days INT
		DECLARE @s3days INT
		DECLARE @s4days INT
		DECLARE @s5days INT
		DECLARE @present VARCHAR(3)
		
		SET @shift1=(select shift1 from tblEmployeeShiftMaster where paycode=@paycode)
		SET @shift11=(select shift1 from tblEmployeeShiftMaster where paycode=@paycode)
		SET @shift2=(select shift2 from tblEmployeeShiftMaster where paycode=@paycode)
		SET @shift3=(select shift3 from tblEmployeeShiftMaster where paycode=@paycode)
		SET @shift4=(select shift4 from tblEmployeeShiftMaster where paycode=@paycode)
		SET @shift5=(select shift5 from tblEmployeeShiftMaster where paycode=@paycode)
		SET @s1remainingdays=(select s1remainingdays from tblEmployeeShiftMaster where paycode=@paycode)
		SET @s2remainingdays=(select s2remainingdays from tblEmployeeShiftMaster where paycode=@paycode)
		SET @s3remainingdays=(select s3remainingdays from tblEmployeeShiftMaster where paycode=@paycode)
		SET @s4remainingdays=(select s4remainingdays from tblEmployeeShiftMaster where paycode=@paycode)
		SET @s5remainingdays=(select s5remainingdays from tblEmployeeShiftMaster where paycode=@paycode)
		SET @s1days=(select s1days from tblEmployeeShiftMaster where paycode=@paycode)
		SET @s2days=(select s2days from tblEmployeeShiftMaster where paycode=@paycode)
		SET @s3days=(select s3days from tblEmployeeShiftMaster where paycode=@paycode)
		SET @s4days=(select s4days from tblEmployeeShiftMaster where paycode=@paycode)
		SET @s5days=(select s5days from tblEmployeeShiftMaster where paycode=@paycode)
		
		IF((@s1remainingdays=0 or @s1remainingdays=NULL) and (@s2remainingdays=0 or @s2remainingdays=NULL) and (@s3remainingdays=0 or @s3remainingdays=NULL) and (@s4remainingdays=0 or @s4remainingdays=NULL) and (@s5remainingdays=0 or @s5remainingdays=NULL))
		BEGIN
			update tblEmployeeShiftMaster set s1remainingdays=@s1days where paycode=@paycode
			
		END
		
		DECLARE @flag int
		SET @flag=0
		SET @entryin= CONVERT(time,SUBSTRING(@time,0,9))
		SET @entryout= CONVERT(time,RIGHT(@time,8),9)
		/* Checking shift 1*/
			IF(@shift1!='' or @shift1!=NULL)
				BEGIN
					IF(@s1remainingdays>1  AND @flag=0)
						BEGIN
							SET @shift1=@shift1
							SET @s1remainingdays=@s1remainingdays-1
							update tblEmployeeShiftMaster set s1remainingdays=@s1remainingdays where paycode=@paycode
							SET @flag=1
						END
					IF(@s1remainingdays=1 AND @flag=0)
						BEGIN
							SET @flag=1
							SET @shift1=@shift1
							SET @s1remainingdays=@s1remainingdays-1
							update tblEmployeeShiftMaster set s1remainingdays=@s1remainingdays where paycode=@paycode
								IF(@shift2!=NULL or @shift2!='')
									BEGIN
									SET @s2remainingdays=@s2days
									update tblEmployeeShiftMaster set s2remainingdays=@s2remainingdays where paycode=@paycode
									END
								ELSE
									BEGIN
									SET @s1remainingdays=@s1days
									update tblEmployeeShiftMaster set s1remainingdays=@s1remainingdays where paycode=@paycode
									END
						END
					IF(@s1remainingdays=0 AND @flag=0)
					BEGIN
						IF(@shift2!='' or @shift2!=NULL)
						BEGIN
							IF(@s2remainingdays>1 AND @flag=0)
							BEGIN
								SET @shift1=@shift2
								SET @flag=1
								SET @s2remainingdays=@s2remainingdays-1
								update tblEmployeeShiftMaster set s2remainingdays=@s2remainingdays where paycode=@paycode
							END
							IF(@s2remainingdays=1 AND @flag=0)
							BEGIN
								SET @shift1=@shift2
								SET @flag=1
								SET @s2remainingdays=@s2remainingdays-1
								update tblEmployeeShiftMaster set s2remainingdays=@s2remainingdays where paycode=@paycode
								IF(@shift3!=NULL or @shift3!='')
									BEGIN
									SET @s3remainingdays=@s3days
									update tblEmployeeShiftMaster set s3remainingdays=@s3remainingdays where paycode=@paycode
									END
								ELSE
									BEGIN
									SET @s1remainingdays=@s1days
									update tblEmployeeShiftMaster set s1remainingdays=@s1remainingdays where paycode=@paycode
									END
							END
							IF(@s2remainingdays=0 AND @flag=0)
							BEGIN
								IF(@shift3!='' or @shift3!=NULL)
									BEGIN
										IF(@s3remainingdays>1 AND @flag=0)
											BEGIN
												SET @flag=1
												SET @shift1=@shift3
												SET @s3remainingdays=@s3remainingdays-1
												update tblEmployeeShiftMaster set s3remainingdays=@s3remainingdays where paycode=@paycode
											END
										IF(@s3remainingdays=1 AND @flag=0)
											BEGIN
												SET @shift1=@shift3
												SET @flag=1
												SET @s3remainingdays=@s3remainingdays-1
												update tblEmployeeShiftMaster set s3remainingdays=@s3remainingdays where paycode=@paycode
											
											
												IF(@shift4!=NULL or @shift4!='')
													BEGIN
														SET @s4remainingdays=@s4days
														update tblEmployeeShiftMaster set s4remainingdays=@s4remainingdays where paycode=@paycode
													END
												ELSE
													BEGIN
														SET @s1remainingdays=@s1days
														update tblEmployeeShiftMaster set s1remainingdays=@s1remainingdays where paycode=@paycode
													END
											END
									END
								END
								IF(@s3remainingdays=0 AND @flag=0)
									BEGIN
									IF(@shift4!='' or @shift4!=NULL)
										BEGIN
											IF(@s4remainingdays>1 AND @flag=0)
												BEGIN
													SET @flag=1
													SET @shift1=@shift4
													SET @s4remainingdays= @s4remainingdays - 1
													update tblEmployeeShiftMaster set s4remainingdays=@s4remainingdays where paycode=@paycode
												END
											IF(@s4remainingdays=1 AND @flag=0)
												BEGIN
													SET @shift1=@shift4
													SET @flag=1
													SET @s4remainingdays=@s4remainingdays-1
													update tblEmployeeShiftMaster set s4remainingdays=@s4remainingdays where paycode=@paycode
													IF(@shift5!=NULL or @shift5!='')
														BEGIN
														SET @s5remainingdays=@s5days
														update tblEmployeeShiftMaster set s5remainingdays=@s5remainingdays where paycode=@paycode
														END
													ELSE
														BEGIN
														SET @s1remainingdays=@s1days
														update tblEmployeeShiftMaster set s1remainingdays=@s1remainingdays where paycode=@paycode
														END
												END
											IF(@s4remainingdays=0 AND  @flag=0)
												BEGIN
													IF(@shift5!='' or @shift5!=NULL)
														BEGIN
															IF(@s5remainingdays>0 AND @flag=0)
																BEGIN
																	SET @flag=1
																	SET @shift1=@shift5
																	SET @s5remainingdays=@s5remainingdays-1
																	update tblEmployeeShiftMaster set s5remainingdays=@s5remainingdays where paycode=@paycode
																END
															IF(@s5remainingdays=1 AND @flag=0)
																BEGIN
																	SET @flag=1
																	SET @shift1=@shift5
																	SET @s5remainingdays=@s5remainingdays-1
																	update tblEmployeeShiftMaster set s5remainingdays=@s5remainingdays where paycode=@paycode
																	SET @s1remainingdays=@s1days
																	update tblEmployeeShiftMaster set s1remainingdays=@s1remainingdays where paycode=@paycode
																END
														END
												END
										END
									END
						END
					END	
			
			
							
				
	
		
		
		DECLARE @shiftendtime varchar(255);
		set @shiftendtime=RIGHT(@shift1,5);
		SET @shift1=SUBSTRING(@shift1,0,6) /* This is new shift which will be used to calculate the attendance */
		
		
		SET @timelossin= (select timelossin from tblEmployeeShiftMaster where paycode=@paycode)
		SET @timelossout= (select timelossout from tblEmployeeShiftMaster where paycode=@paycode)
		
		IF(@entryin>DATEADD(ss,-DATEDIFF(SECOND,0,@timelossin),CONVERT(time, @shift1)))
		BEGIN
				IF(@entryin>DATEADD(ss,DATEDIFF(SECOND,0,@timelossin),CONVERT(time, @shift1)))
				BEGIN
					SET @present='WTP'
				END
				ELSE
				BEGIN
				/* IF Entrytime is Okay means within the time loss upper bound and time losss lower bound then
					check for exit time if it is within the time loss then mark it as present otherwise mark it as absent */
					
				/*Entry Out Calculation whether timeout is greater then timeloss */
							IF(@entryout>DATEADD(ss,-DATEDIFF(SECOND,0,@timelossout),CONVERT(time, @shiftendtime)))
							BEGIN
									IF(@entryout>DATEADD(ss,DATEDIFF(SECOND,0,@timelossout),CONVERT(time, @shiftendtime)))
										BEGIN
											SET @present='P'
										END
									ELSE
										BEGIN
											SET @present='P'
										END
							END
							ELSE
							BEGIN
									SET @present='A'
							END
				END
		END
		ELSE
		BEGIN
				SET @present='WTP'
		END
		
		
		
		
		
		
		
		/* If hours, minutes, seconds are 0,0,0 then it means emp. was absent on that day */
		IF(DATEPART(SS,@entryin)=0 and DATEPART(MINUTE,@entryin)=0 and DATEPART(HH,@entryin)=0)
		BEGIN
			SET @present='A'
		END
		
		DECLARE @dayoff1 varchar(50)
		DECLARE @dayoff2 varchar(50)
		DECLARE @dayoff3 varchar(50)
		DECLARE @dayoff4 varchar(50)
		SET @dayoff1=(select offday1 from tblEmployeeShiftMaster where paycode=@paycode)
		SET @dayoff2=(select offday2 from tblEmployeeShiftMaster where paycode=@paycode)
		SET @dayoff3=(select offday3 from tblEmployeeShiftMaster where paycode=@paycode)
		SET @dayoff4=(select offday4 from tblEmployeeShiftMaster where paycode=@paycode)
		
		/* SETTING THE SUNDAY AND OFF FOR GIVEN DAY */
		IF(UPPER( DATENAME(DW,@date))=UPPER(@dayoff1))
			BEGIN
				IF(UPPER(@dayoff1)='SUNDAY')
					SET @present='SUN'
				ELSE 
					SET @present='OFF'
			END
		IF(UPPER( DATENAME(DW,@date))=UPPER(@dayoff2))
			BEGIN
				IF(UPPER(@dayoff2)='SUNDAY')
					SET @present='SUN'
				ELSE
					SET @present='OFF'
			END
		IF(UPPER( DATENAME(DW,@date))=UPPER(@dayoff3))
			BEGIN
				IF(UPPER(@dayoff3)='SUNDAY')
					SET @present='SUN'
				ELSE 
					SET @present='OFF'
			END
		IF(UPPER( DATENAME(DW,@date))=UPPER(@dayoff4))
			BEGIN
				IF(UPPER(@dayoff4)='SUNDAY')
					SET @present='SUN'
				ELSE 
					SET @present='OFF'
			END
		/* COMPLETED CODE FOR SETTING OFF */
		
		/* Checking shift code */
			DECLARE @shiftcode varchar(3)
			SET @shiftcode= (select SHIFT from tblShiftMaster where  SUBSTRING(shifttime,0,6) =SUBSTRING(@shift1,0,6))
		/* Completed code for shiftcode */
		
		
		
		/* If the data of the user is already present then no updation will be done */
			BEGIN TRY 
				INSERT INTO tblattendance VALUES(@paycode,@date,@time,@timelossin,@timelossout,@entryin,@entryout,@shift1,@shiftendtime,@shiftcode,@present,@shift1,@s1remainingdays,@s1days,@shift2,@s2remainingdays,@s2days,@shift3,@s3remainingdays,@s3days,@shift4,@s4remainingdays,@s4days,@shift5,@s5remainingdays,@s5days)
			END TRY
			BEGIN CATCH
			
			END CATCH
			SET @countrecord=@countrecord+1
			update tempProgressTrack set progress=@countrecord
      FETCH NEXT FROM @MyCursor 
      INTO @paycode,@date,@time
    END;
    end
    else
    begin
    INSERT INTO tblattendance(paycode,date,time) VALUES(@paycode,@date,@time)
     FETCH NEXT FROM @MyCursor 
      INTO @paycode,@date,@time
    end
				END
		

    CLOSE @MyCursor ;
    DEALLOCATE @MyCursor;
    
END;
END;", conn);
                    cmd.ExecuteNonQuery();




                    cmd.Dispose();


                }
                catch (Exception ae)
                {
                    
                }
            }
            this.Invoke(new MethodInvoker(delegate ()
            {

                label7.Text = "Starting Application ...";

            }));

        }

        private void frmSplashScreen_Load(object sender, EventArgs e)
        {
            label7.Text = "";
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Hide();
            Form1 frm = new Form1();
            frm.Show();
        }
    }
}
