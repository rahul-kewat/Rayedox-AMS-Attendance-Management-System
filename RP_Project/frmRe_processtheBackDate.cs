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
    public partial class frmRe_processtheBackDate : Form
    {
        public frmRe_processtheBackDate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
            this.Invoke(new MethodInvoker(delegate ()
            {
                toolStripLabel2.Text = "Working on it Please wait";
                button1.Enabled = false;
            }));
            SqlConnection conn = new SqlConnection(RayedoxVariables.connectionstring);
            SqlCommand cmd;
            conn.Open();
            try
            {
                
                cmd = new SqlCommand(@"create PROCEDURE proce_ProcessAttendanceWhichisNotProcessed
AS
BEGIN
DECLARE @MyCursor CURSOR;
DECLARE @paycode int;
DECLARE @date date;
DECLARE @time varchar(255);

insert tempProgressTrack values(0);
BEGIN
    SET @MyCursor = CURSOR FOR
     
     select t.paycode,t.date,t.time from TEMPORARYTT t inner join tblattendance a on t.paycode=a.paycode where a.timelossin is null

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
				update tblattendance set paycode=@paycode,date=@date,time=@time,timelossin= @timelossin,timelossout= @timelossout,entrytime= @entryin, outime= @entryout,currentshift=@shift1,shiftendtime= @shiftendtime,shiftcode= @shiftcode,present= @present,shift1= @shift1,s1remdays= @s1remainingdays, s1days= @s1days,shift2= @shift2,s2remdays= @s2remainingdays,s2days= @s2days, shift3=@shift3, s3remdays= @s3remainingdays,s3days= @s3days,shift4= @shift4, s4remdays= @s4remainingdays ,s4days= @s4days,shift5= @shift5, s5remdays= @s5remainingdays,s5days= @s5days where paycode=@paycode and date=@date
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
                cmd.CommandTimeout = 3600;
                int k = cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch { }



            try
            {
                cmd = new SqlCommand("proce_ProcessAttendanceWhichisNotProcessed", conn);
                cmd.CommandTimeout = 3600;
                int k = cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch { }
        }

        private void frmRe_processtheBackDate_Load(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                toolStripLabel2.Text = "Successfully Completed";
                button1.Enabled = true;
            }));
            
        }
    }
}

