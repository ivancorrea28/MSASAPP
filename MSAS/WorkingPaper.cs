using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Microsoft;
using System.Text;
using System.Collections.Generic;
//using Microsoft.Interop.Excel;

namespace MSAS
{
    public partial class WorkingPaper : Form
    {
        public WorkingPaper()
        {
            InitializeComponent();
        }
        SqlConnection con;
        string localConnection = LoginForm.localConnectionString;
        public static string rpcode;
        public static string auditPeriod;
        public static string auditorFullName;
        public static string multipleRP;
        string auditPeriodEnd;
        string rp;


        bool firstTableLoad = true;//For cmb index change
        private void WorkingPaperRaw_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(localConnection);
            if (multipleRP != "")
            {
                rpcode = multipleRP;
                txtFileName.Visible = true;
                lblFileName.Visible = true;
            }
            else
            {
                rp = rpcode;
                rpcode = "'" + rpcode + "'"; //RPCODE FOR TABLE
                txtFileName.Visible = false;
                lblFileName.Visible = false;
                setLocation();//for Printing
            }
            loadTexts();
            loadTerminal();
            //try
            //{
            loadTable();
            //}
            //catch (Exception er)
            //{
            //    MessageBox.Show(er.Message);
            //}
            firstTableLoad = false;
            //MessageBox.Show(dgvWP.Columns.Count.ToString());
        } 
        void generateSupportingDocs() // 3 22 2021
        {
            con.Open();
            string sqlCount = "SELECT COUNT(*) FROM AuditSupportingDocs WHERE tenantcode=@tenantcode AND machine=@machine AND date=@date";
            SqlCommand cmdCount = new SqlCommand(sqlCount, con);
            cmdCount.Parameters.AddWithValue("tenantcode", rpcode);
            cmdCount.Parameters.AddWithValue("machine", cmbTerminal.SelectedItem.ToString());
            cmdCount.Parameters.AddWithValue("date", auditPeriod);
            if ((int)cmdCount.ExecuteScalar() > 0)
            {//  
            }
            else // Create New Entry
            {
                for (int i = 0; i < cmbTerminal.Items.Count; i++)
                {
                    string sql = "INSERT INTO AuditSupportingDocs VALUES (@tenantcode,@machine,@date,@msr,@reading,@dep,@other)";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("tenantcode", rpcode);
                    cmd.Parameters.AddWithValue("machine", cmbTerminal.Items[i].ToString());
                    cmd.Parameters.AddWithValue("date", auditPeriod);
                    cmd.Parameters.AddWithValue("msr", true);
                    cmd.Parameters.AddWithValue("reading", true);
                    cmd.Parameters.AddWithValue("dep", true);
                    cmd.Parameters.AddWithValue("other", true);
                    cmd.ExecuteNonQuery();
                }
            }  

            con.Close();
        }
        public void gridViewFormat()
        {
            dgvWP.Columns[4].DefaultCellStyle.Format = "#,#";
            //ReadOnly All Columns Except Ticking Column
            for (int i = 0; i < dgvWP.Columns.Count; i++)
            {
                //dgvWP.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                int size = 75;
                dgvWP.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                if (i <= 1 || dgvWP.Columns[i].Name == "." || dgvWP.Columns[i].Name == "DATE2")
                {
                    size = 60;
                    dgvWP.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                dgvWP.Columns[i].Width = size;

                dgvWP.Columns[i].ReadOnly = true;
                if (dgvWP.Columns[i].Name == ".")
                {
                    dgvWP.Columns[i].ReadOnly = false;
                }
            }

            if (multipleRP == "" && wp == "AUDITED")//Single RP and Audited Only
            {
                currentCheckedDays = getCheckedDays();
                string[] days = currentCheckedDays.Split(',');
                //Check/Tick IF already Saved.
                //ReadOnly tickRows w/ True Value
                for (int i = 0; i < dgvWP.Rows.Count; i++)
                {
                    if (days.Contains(dgvWP.Rows[i].Cells[0].Value.ToString()) || currentCheckedDays == "ALL" || currentCheckedDays.Contains("UPLOADED"))
                    {
                        //dgvWP.Rows[i].Cells[13].ReadOnly = true;
                        dgvWP.Rows[i].Cells[13].Value = true;
                    }
                }
            }
        }
        string currentCheckedDays = "";
        public string getCheckedDays()
        {
            string cd = ""; 
            con.Open();
            string sqlCount = "SELECT COUNT(*) FROM CheckedWorkingPaper WHERE tenantcode=@rp AND machine=@terminal AND auditPeriod=@auditPeriod";
            SqlCommand cmdCount = new SqlCommand(sqlCount, con);
            cmdCount.Parameters.AddWithValue("rp", rp);
            cmdCount.Parameters.AddWithValue("terminal", cmbTerminal.SelectedItem.ToString());
            cmdCount.Parameters.AddWithValue("auditPeriod", auditPeriod);
            if (Convert.ToInt16(cmdCount.ExecuteScalar()) > 0)
            {
                string sql = "SELECT checkedLevel1 FROM CheckedWorkingPaper WHERE tenantcode=@rp AND machine=@terminal AND auditPeriod=@auditPeriod";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("rp", rp);
                cmd.Parameters.AddWithValue("terminal", cmbTerminal.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("auditPeriod", auditPeriod);
                try
                {
                    cd = cmd.ExecuteScalar().ToString();
                }
                catch (Exception) { }
            }
            else
            {//Insert if no DATA YET
                for (int i = 0; i < cmbTerminal.Items.Count; i++)
                {
                    string sqlIns = "INSERT INTO CheckedWorkingPaper (tenantcode,machine,auditPeriod,checkedLevel1,AuditorInCharge) VALUES(@rp,@terminal,@auditPeriod,@checkedDays,@checker1)";
                    SqlCommand cmdIns = new SqlCommand(sqlIns, con);
                    cmdIns.Parameters.AddWithValue("rp", rp);
                    cmdIns.Parameters.AddWithValue("terminal", cmbTerminal.Items[i].ToString());
                    cmdIns.Parameters.AddWithValue("auditPeriod", auditPeriod);
                    cmdIns.Parameters.AddWithValue("checkedDays", "");
                    cmdIns.Parameters.AddWithValue("checker1", AuditSchedule.auditor);
                    cmdIns.ExecuteNonQuery();
                }
            }
            con.Close();
            return cd;
        }
        public void loadTexts()
        {
            txtDate.Text= DateTime.Now.ToString("MMMM dd, yyyy");
            this.Text= "Working Paper (" + wp + ")";
            if (wp == "RAW" || multipleRP!="")
            {
                btnCheckDates.Visible = false;
            }
        }
        public void loadTerminal()
        {
            cmbTerminal.Items.Clear();
            DateTime startDate = Convert.ToDateTime(auditPeriod);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);

            con.Open();
            //Count Terminals used for the Audit Period
            //string sql = "SELECT COUNT(DISTINCT(machine)) FROM dailymod WHERE tenantcode IN ("+rpcode+") AND date BETWEEN @startDate AND @endDate";
            string sql = "SELECT COUNT(DISTINCT(machine)) FROM dailymod WHERE tenantcode IN (" + rpcode + ")";
            
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Clear();
            //cmd.Parameters.AddWithValue("tenantcode", rpcode);
            cmd.Parameters.AddWithValue("startDate", startDate.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("endDate", endDate.ToString("yyyy-MM-dd"));
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            //CHECK if Tenant has Sales Breakdown
            //IF Tenant has Sales Breakdown, ALL terminal is not added on the items
            sql = "SELECT COUNT(DISTINCT(tenantcode)) AS 'tenantcode' FROM TenantWPSBDN WHERE tenantcode IN (" + rpcode + ") AND ((@sdate>=startDate AND endDate IS NULL) OR (@sdate BETWEEN startDate AND endDate))";
            
            SqlCommand cmd2 = new SqlCommand(sql, con);
            cmd2.Parameters.Clear();
            cmd2.Parameters.AddWithValue("sdate", startDate.ToString("yyyy-MM-dd"));
            //cmd2.Parameters.AddWithValue("tenantcode", rpcode);
            if ((int)cmd2.ExecuteScalar() == 0 && count > 0)
            {//Not on the list and more than 1 terminal lang ang pwede mag ALL
                cmbTerminal.Items.Add("ALL");
                count = 0;//Dont Add Machine if RP have SBDN
            }
            if (count > 0)
            {//list Terminal used
                //sql = "SELECT DISTINCT(machine) AS 'machine' FROM dailymod WHERE tenantcode IN (" + rpcode + ") AND date BETWEEN @startDate AND @endDate";
                sql = "SELECT DISTINCT(machine) AS 'machine' FROM dailymod WHERE tenantcode IN (" + rpcode + ")";
                
                SqlCommand cmd3 = new SqlCommand(sql, con);
                cmd3.Parameters.Clear();
                //cmd3.Parameters.AddWithValue("tenantcode", rpcode);
                cmd3.Parameters.AddWithValue("startDate", startDate.ToString("yyyy-MM-dd"));
                cmd3.Parameters.AddWithValue("endDate", endDate.ToString("yyyy-MM-dd"));
                SqlDataReader sReader = cmd3.ExecuteReader();
                while (sReader.Read())
                {
                    cmbTerminal.Items.Add(sReader["machine"].ToString());
                }
            }


            cmbTerminal.SelectedIndex = 0;
            lastTerminal = cmbTerminal.SelectedItem.ToString();
            con.Close();
        }
        public static string wp = "";
        DataTable dt =new DataTable();
        DataTable dtPrinting = new DataTable(); // FOR PRINTING, NO - CHECKED COLUMN
        public void loadTable()
        {
            generateSupportingDocs();
            string terminal = cmbTerminal.SelectedItem.ToString();
            auditPeriodEnd = (Convert.ToDateTime(auditPeriod)).AddMonths(1).AddDays(-1).ToString("MMMM dd, yyyy");
            con.Open();
            dt = new DataTable();
            dtPrinting = new DataTable();
            //MessageBox.Show(rpcode + " " + auditPeriod + " " + (Convert.ToDateTime(auditPeriod)).AddMonths(1).AddDays(-1).ToString("MMMM dd, yyyy"));
            string sql = "";
            if(wp=="RAW"){
                sql += "SELECT DAY(z.date) as 'DATE1',DATENAME(WEEKDAY,z.date) AS 'DAY'";
                sql += " ,SUM(surcharge)  AS 'SERVICE CHARGE'";
                sql += " ,null 'surchargeVar'";
                sql += " ,SUM(senior)  AS 'SENIOR DISC'";
                sql += " ,null 'seniorVar'";
                sql += " ,SUM(vat)  AS 'VAT EXEMPT SALES'";
                sql += " ,null 'vatVar'";
                sql += " ,SUM(other)  AS 'OTHER DISC'";
                sql += " ,null 'otherVar'";
                sql += " ,SUM(refund)  AS 'REFUND'";
                sql += " ,SUM(void)  AS 'VOID / CANCEL'";
                sql += " ,SUM(gsc)  AS 'GROSS SALES CHARGEABLE'";
                sql += " ,CAST(0 AS BIT) AS '.'";
                sql += " ,null 'gscVar'";
                sql += " ,SUM(cash)  AS 'CASH'";
                sql += " ,null 'cashVar'";
                sql += " ,SUM(charge)  AS 'CHARGE'";
                sql += " ,null 'chargeVar'";
                sql += " ,SUM(gift)  AS 'GC / OTHERS'";
                sql += " ,null 'giftVar'";
                sql += " ,DAY(z.date) as 'DATE2'";
                sql += " ,z.tenantcode";
                sql += " ,b.name";
                sql += " ,c.location";
                sql += " ,c.locationd,statusdesc";
                sql += " INTO #TempTbl ";
                sql += " FROM dailymod a ";
                sql += "RIGHT JOIN (SELECT tenantcode,date FROM TENANTMOD x";
                sql+= " CROSS JOIN";
                sql+= " ( SELECT DATEADD(Day,Number,@sdate) as DATE";
                sql+= "   FROM master..spt_values";
                sql += "   WHERE Type='P' AND DATEADD(Day,Number,@sdate) <=@edate) y";
                sql+= " WHERE x.tenantcode IN ("+rpcode+")) z";
                sql += " ON a.tenantcode=z.tenantcode AND a.date=z.date";
                sql+= "  JOIN tenantmod b ON z.tenantcode=b.tenantcode";
                sql += " JOIN location c ON b.location=c.location";
                //RPStatusHistory
                sql += " LEFT JOIN ( ";
                sql += " SELECT DATEADD(Day,Number,StartDate) as Date,Tenantcode,RTRIM(zz.[desc]) as StatusDesc";
                sql += " FROM master..spt_values yy";
                sql += " JOIN RPStatusHistory xx";
                sql += " ON Type='P' AND DATEADD(Day,Number,StartDate) <=EndDate";
                sql += " JOIN RPStatus zz ON xx.Status=zz.code";
                sql += " WHERE Tenantcode IN (" + rpcode + ")) f";
                sql += " ON z.tenantcode=f.tenantcode AND z.date=f.date";
                //-
                sql += " WHERE z.tenantcode IN("+rpcode+ ")";
                sql += " AND z.DATE BETWEEN @sdate AND @edate";
                if (terminal != "ALL"){
                    sql += " AND machine=" + terminal;
                }
                sql+= " GROUP BY z.tenantcode,z.date,b.tenantcode,b.name,c.location,c.locationd,statusdesc ORDER BY c.locationd,b.name";
                sql += " SELECT [Date1],[DAY]";
                sql += " ,CASE WHEN [SERVICE CHARGE] IS NULL THEN '0.00' ELSE CONVERT(varchar,CAST([SERVICE CHARGE] AS money),1) END AS 'SERVICE CHARGE'";
                sql += " ,null 'surchargeVar'";
                sql += " ,CASE WHEN [SENIOR DISC] IS NULL THEN '0.00' ELSE CONVERT(varchar,CAST([SENIOR DISC] AS money),1) END AS 'SENIOR DISC'";
                sql += " ,null 'seniorVar'";
                sql += " ,CASE WHEN [VAT EXEMPT SALES] IS NULL THEN '0.00' ELSE CONVERT(varchar,CAST([VAT EXEMPT SALES] AS money),1) END AS 'VAT EXEMPT SALES'";
                sql += " ,null 'vatVar'";
                sql += " ,CASE WHEN [OTHER DISC] IS NULL THEN '0.00' ELSE CONVERT(varchar,CAST([OTHER DISC] AS money),1) END AS 'OTHER DISC'";
                sql += " ,null 'otherVar'";
                sql += " ,CASE WHEN [REFUND] IS NULL THEN '0.00' ELSE CONVERT(varchar,CAST([REFUND] AS money),1) END AS 'REFUND'";
                sql += " ,CASE WHEN [VOID / CANCEL] IS NULL THEN '0.00' ELSE CONVERT(varchar,CAST([VOID / CANCEL] AS money),1) END AS 'VOID / CANCEL'";
                sql += " ,CASE WHEN [GROSS SALES CHARGEABLE] IS NULL THEN [StatusDesc] ELSE CONVERT(varchar,CAST([GROSS SALES CHARGEABLE] AS money),1) END AS 'GROSS SALES CHARGEABLE'";
                sql += " ,CAST(0 AS BIT) AS '.'";
                sql += " ,null 'gscVar'";
                sql += " ,CASE WHEN [CASH] IS NULL THEN '0.00' ELSE CONVERT(varchar,CAST(CASH AS money),1) END AS 'CASH'";
                sql += " ,null 'cashVar'";
                sql += " ,CASE WHEN [charge] IS NULL THEN '0.00' ELSE CONVERT(varchar,CAST(charge AS money),1) END AS 'CHARGE'";
                sql += " ,null 'chargeVar'";
                sql += " ,CASE WHEN [GC / OTHERS] IS NULL THEN '0.00' ELSE CONVERT(varchar,CAST([GC / OTHERS] AS money),1) END AS 'GC / OTHERS'";
                sql += " ,null 'giftVar'";
                sql += " ,[DATE2],tenantcode,name,location,locationd";
                sql+= " FROM #TempTbl";
                sql += " UNION ALL";
                sql += " SELECT * FROM";
                sql += " (SELECT 999 AS [DATE1],'TOTAL' AS DAY,CONVERT(varchar,CAST(SUM([SERVICE CHARGE]) AS MONEY),1) AS [SERVICE CHARGE],SUM([surchargeVar]) AS surchargevar";
                sql += " ,CONVERT(varchar,CAST(SUM([SENIOR DISC]) AS MONEY),1) AS [SENIOR DISC],SUM([SENIORVAR]) AS seniorvar";
                sql += " ,CONVERT(varchar,CAST(SUM([VAT EXEMPT SALES]) AS MONEY),1) AS [VAT EXEMPT SALES],SUM([vatVar]) AS vatVar";
                sql += " ,CONVERT(varchar,CAST(SUM([OTHER DISC]) AS MONEY),1) AS [OTHER DISC] ,SUM([otherVar]) AS otherVar";
                sql += " ,CONVERT(varchar,CAST(SUM([REFUND]) AS MONEY),1) AS [REFUND],CONVERT(varchar,CAST(SUM([VOID / CANCEL]) AS MONEY),1) AS [VOID / CANCEL]";
                sql += " ,CONVERT(varchar,CAST(SUM([GROSS SALES CHARGEABLE]) AS MONEY),1) AS [GROSS SALES CHARGEABLE],0 AS [.],SUM([gscVar]) AS gscVar";
                sql += " ,CONVERT(varchar,CAST(SUM([CASH]) AS MONEY),1) AS [CASH],SUM([cashVar]) AS cashVar";
                sql += " ,CONVERT(varchar,CAST(SUM([charge]) AS MONEY),1) AS [charge],SUM([chargeVar]) AS chargeVar";
                sql += " ,CONVERT(varchar,CAST(SUM([GC / OTHERS]) AS MONEY),1) AS [GC / OTHERS],SUM([giftVar]) AS giftVar";
                sql += " ,null AS[DATE2],tenantcode,name,location,locationd";
                sql += " FROM #TempTbl";
                sql += " GROUP BY tenantcode,location,name,locationd) xx ORDER BY Name,tenantcode,DATE1";
            }
            else
            {//AUDITED
                sql += " SELECT  DAY(z.date) as 'DATE1',DATENAME(WEEKDAY,z.date) AS 'DAY'";
                sql += " ,CASE WHEN b.surcharge IS NULL THEN SUM(a.surcharge) ELSE b.surcharge END AS [SERVICE CHARGE],surchargeVar";
                sql += " ,CASE WHEN b.senior IS NULL THEN SUM(a.senior) ELSE b.senior END AS [SENIOR DISC],seniorVar";
                sql += " ,CASE WHEN b.vat IS NULL THEN SUM(a.vat) ELSE b.vat END AS [VAT EXEMPT SALES],vatVar";
                sql += " ,CASE WHEN b.other IS NULL THEN SUM(a.other) ELSE b.other END AS [OTHER DISC],otherVar";
                sql += " ,SUM(refund) AS [REFUND]";
                sql += " ,SUM(void) AS [VOID / CANCEL]";
                sql += " ,CASE WHEN b.gsc IS NULL THEN SUM(a.gsc) ELSE b.gsc END AS [GROSS SALES CHARGEABLE],CAST(0 AS BIT) AS '.',gscVar";
                sql += " ,CASE WHEN b.cash IS NULL THEN SUM(a.cash) ELSE b.cash END AS [CASH],cashVar";
                sql += " ,CASE WHEN b.charge IS NULL THEN SUM(a.charge) ELSE b.charge END AS [CHARGE],chargeVar";
                sql += " ,CASE WHEN b.gift IS NULL THEN SUM(a.gift) ELSE b.gift END AS [GC / OTHERS],giftVar";
                sql += " ,DAY(z.date) as 'DATE2', z.tenantcode,name,e.location,locationd,[StatusDesc]";
                sql += " INTO #TempTbl  FROM ";
                sql += " (SELECT tenantcode,date";
                if (terminal != "ALL")
                {
                    sql += " ,machine";
                }
                
                sql += " FROM TENANTMOD x CROSS JOIN";
                sql += " ( SELECT DATEADD(Day,Number,@sdate) as [DATE]";
                if (terminal != "ALL")
                {
                    sql += " ,@terminal as [machine]";
                }
                sql += "   FROM master..spt_values";
                sql += "   WHERE Type='P' AND DATEADD(Day,Number,@sdate) <=@edate) y";
                sql += " WHERE x.tenantcode IN ("+rpcode+")) z";
                sql += " LEFT JOIN dailymod a";
                sql += " ON a.tenantcode=z.tenantcode";
                sql += " AND a.date=z.date";
                if (terminal != "ALL")
                {
                    sql += " AND a.machine=z.machine";
                }
                sql += " LEFT JOIN (SELECT * FROM AuditedTenders WHERE date BETWEEN @sdate AND @edate";
                if (terminal != "ALL")
                {
                    sql += " AND machine !='ALL'";
                }
                sql += " ) b";
                sql += " ON b.tenantcode=z.tenantcode";
                sql += " AND b.date=z.date";
                    if (terminal != "ALL"){
                       sql += " AND b.machine=z.machine";
                    }
                sql += " LEFT JOIN (Select COUNT(machine) as 'machine', tenantcode, date from DAILYMOD WHERE date";
                sql += " BETWEEN @sdate  AND @edate AND tenantcode IN (" + rpcode + ") GROUP BY tenantcode,date) c";
                sql += " ON a.tenantcode=c.tenantcode AND a.date=c.date";
                sql += " JOIN TENANTMOD d";
                sql += " ON z.tenantcode=d.tenantcode";
                sql += " JOIN location e";
                sql += " ON d.location=e.location";
                //RPSTATUS HISTORY
                sql += " LEFT JOIN ( ";
                sql += " SELECT DATEADD(Day,Number,StartDate) as Date,Tenantcode,RTRIM(zz.[desc]) as StatusDesc";
                sql += " FROM master..spt_values yy";
                sql += " JOIN RPStatusHistory xx";
                sql += " ON Type='P' AND DATEADD(Day,Number,StartDate) <=EndDate";
                sql += " JOIN RPStatus zz ON xx.Status=zz.code";
                sql += " WHERE Tenantcode IN ("+rpcode+")) f";
                sql += " ON z.tenantcode=f.tenantcode AND z.date=f.date";
                //sql += " --WHERE a.machine=@terminal";
                sql += " GROUP BY z.date,b.surcharge,b.surchargeVar,b.senior,b.seniorVar,b.vat,b.vatVar,b.other,b.otherVar,b.gsc,b.gscVar,b.cash,b.cashVar,b.charge,b.chargeVar,b.surcharge,b.surchargeVar,b.gift,b.giftVar,z.tenantcode,d.name,e.location,e.locationd,f.statusdesc";
                    if (terminal != "ALL"){
                    sql += " ,a.machine";
                    }
                sql += " SELECT * INTO #FinalTBL";
                sql += " FROM #TempTbl";
                sql += " UNION ALL";
                //Sum Row
                sql += " SELECT * FROM";
                sql += " (SELECT 999 AS [DATE1],'TOTAL' AS DAY,SUM([SERVICE CHARGE]) AS [SERVICE CHARGE],SUM([surchargeVar]) AS surchargevar";
                sql += " ,SUM([SENIOR DISC]) AS [SENIOR DISC],SUM([SENIORVAR]) AS seniorvar";
                sql += " ,SUM([VAT EXEMPT SALES]) AS [VAT EXEMPT SALES],SUM([vatVar]) AS vatVar";
                sql += " ,SUM([OTHER DISC])AS [OTHER DISC] ,SUM([otherVar]) AS otherVar";
                sql += " ,SUM([REFUND]) AS [REFUND],SUM([VOID / CANCEL]) AS [VOID / CANCEL]";
                sql += " ,SUM([GROSS SALES CHARGEABLE]) AS [GROSS SALES CHARGEABLE],0 AS [.],SUM([gscVar]) AS gscVar";
                sql += " ,SUM([CASH]) AS [CASH],SUM([cashVar]) AS cashVar";
                sql += " ,SUM([charge]) AS [CHARGE],SUM([chargeVar]) AS chargeVar";
                sql += " ,SUM([GC / OTHERS]) AS [GC / OTHERS],SUM([giftVar]) AS giftVar";
                sql += " ,null AS[DATE2],tenantcode,name,location,locationd,'' as statusdesc";
                sql += " FROM #TempTbl";
                sql += " GROUP BY tenantcode,location,name,locationd) xx";
                //Final FOrmat
                sql += " SELECT DATE1,DAY,";
                sql += " CASE WHEN [SERVICE CHARGE] IS NULL THEN '0.00' ELSE CONVERT(varchar,CAST([SERVICE CHARGE] AS money),1) END [SERVICE CHARGE]";
                sql += " ,CONVERT(varchar,CAST([surchargeVar] AS money),1) [surchargeVar]";
                sql += " ,CASE WHEN [SENIOR DISC] IS NULL THEN '0.00' ELSE CONVERT(varchar,CAST([SENIOR DISC] AS money),1) END [SENIOR DISC]";
                sql += " ,CONVERT(varchar,CAST([seniorVar] AS money),1) [seniorVar]";
                sql += " ,CASE WHEN [VAT EXEMPT SALES] IS NULL THEN '0.00' ELSE CONVERT(varchar,CAST([VAT EXEMPT SALES] AS money),1) END [VAT EXEMPT SALES]";
                sql += " ,CONVERT(varchar,CAST([vatVar] AS money),1) [vatVar]";
                sql += " ,CASE WHEN [OTHER DISC] IS NULL THEN '0.00' ELSE CONVERT(varchar,CAST([OTHER DISC] AS money),1) END [OTHER DISC]";
                sql += " ,CONVERT(varchar,CAST([otherVar] AS money),1) [otherVar]";
                sql += " ,CASE WHEN [REFUND] IS NULL THEN '0.00' ELSE CONVERT(varchar,CAST([REFUND] AS money),1) END [REFUND]";
                sql += " ,CASE WHEN [VOID / CANCEL] IS NULL THEN '0.00' ELSE CONVERT(varchar,CAST([VOID / CANCEL] AS money),1) END [VOID / CANCEL]";
                sql += " ,CASE WHEN [GROSS SALES CHARGEABLE] IS NULL THEN [StatusDesc] ELSE CONVERT(varchar,CAST([GROSS SALES CHARGEABLE] AS money),1) END [GROSS SALES CHARGEABLE]";
                sql += " ,CAST([.] AS BIT) [.]";
                sql += " ,CONVERT(varchar,CAST([gscVar] AS money),1) [gscVar]";
                sql += " ,CASE WHEN [CASH]  IS NULL THEN '0.00' ELSE CONVERT(varchar,CAST([CASH] AS money),1) END [CASH]";
                sql += " ,CONVERT(varchar,CAST(cashVar AS money),1) cashVar";
                sql += " ,CASE WHEN [CHARGE] IS NULL THEN '0.00' ELSE CONVERT(varchar,CAST([CHARGE] AS money),1) END [CHARGE]";
                sql += " ,CONVERT(varchar,CAST([chargeVar] AS money),1) [chargeVar]";
                sql += " ,CASE WHEN [GC / OTHERS] IS NULL THEN '0.00' ELSE CONVERT(varchar,CAST([GC / OTHERS] AS money),1) END [GC / OTHERS]";
                sql += " ,CONVERT(varchar,CAST(giftVar AS money),1) giftVar,";
                sql += " DATE2,tenantcode,name,location,locationd";       
                
                sql += " FROM #FinalTBL ORDER BY Name,tenantcode,DATE1";
                
            }
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("rp", rpcode);
            cmd.Parameters.AddWithValue("sdate", auditPeriod);
            cmd.Parameters.AddWithValue("edate", (Convert.ToDateTime(auditPeriod)).AddMonths(1).AddDays(-1).ToString("MMMM dd, yyyy"));
            cmd.Parameters.AddWithValue("terminal", terminal);
            //cmd.ExecuteReader();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            da.Fill(dtPrinting);
            dtPrinting.Columns.Remove(".");
            con.Close();
            int deductColumn = 0;
            if (multipleRP == "" && wp =="AUDITED")
            {
                dgvWP.DataSource = dt;
            }
            else
            {
                dgvWP.DataSource = dtPrinting;
                deductColumn = 1;
            }

            //Hide Variance Columns
            dgvWP.Columns[3].Visible = false;
            dgvWP.Columns[5].Visible = false;
            dgvWP.Columns[7].Visible = false;
            dgvWP.Columns[9].Visible = false;
            dgvWP.Columns[14 - deductColumn].Visible = false;
            dgvWP.Columns[16 - deductColumn].Visible = false;
            dgvWP.Columns[18 - deductColumn].Visible = false;
            dgvWP.Columns[20 - deductColumn].Visible = false;
            dgvWP.Columns[22 - deductColumn].Visible = false;//tenantcode
            if (multipleRP == ""){
                dgvWP.Columns[23 - deductColumn].Visible = false;//name
                dgvWP.Columns[25 - deductColumn].Visible = false;//locationd
            }
            dgvWP.Columns[24 - deductColumn].Visible = false;//location
            for (int i = 0; i < dgvWP.Rows.Count; i++)
            {
                if(dgvWP.Rows[i].Cells[0].Value.ToString()=="999"){
                    dgvWP.Rows[i].Cells[0].Value = DBNull.Value;
                }
                for (int x = 0; x < dgvWP.Columns.Count; x++)
                {
                    double re;
                    string txtValue = dgvWP.Rows[i].Cells[x].Value.ToString();
                    bool isNumber =double.TryParse(txtValue, out re);
                    if (!isNumber && x>=2 && x<21 && x != 13)
                    {
                        dgvWP.Rows[i].Cells[x].Style.BackColor = Color.Gray;
                    }
                }
            }
                if (wp != "RAW")
                {
                    highlightAudited();
                }
            gridViewFormat();//Readonly, Autosize, Checked GSC
            if (multipleRP == "" && wp == "AUDITED")
            {
                loadDailyDocumentsTicked();
            }
        }
        void loadDailyDocumentsTicked()
        {
            DateTime startDate = Convert.ToDateTime(auditPeriod);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);
            con.Open();
            string sql = "SELECT * FROM DailySuppDocTick WHERE tenantcode=@rp AND date BETWEEN @sdate AND @edate AND machine=@terminal ORDER BY DATE";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("rp", rp);
            cmd.Parameters.AddWithValue("sdate", startDate);
            cmd.Parameters.AddWithValue("edate", endDate);
            cmd.Parameters.AddWithValue("terminal", cmbTerminal.SelectedItem.ToString());
            SqlDataReader sReader = cmd.ExecuteReader(); 
            while(sReader.Read()){
                for (int i = 0; i < dgvWP.Rows.Count; i++)
                {
                    if (Convert.ToDateTime(sReader["date"]).Day == (int)dgvWP.Rows[i].Cells[0].Value)
                    {
                        int row = i;
                        if (!sReader.IsDBNull(3))//SurchargeDoc
                        {
                            //MessageBox.Show(Convert.ToDateTime(sReader["date"]).Day.ToString() + "Color " + dgvWP.Rows[row].Cells[2].Style.BackColor.ToString() +rp);
                            dgvWP.Rows[row].Cells[2].Style.BackColor = (dgvWP.Rows[row].Cells[2].Style.BackColor != Color.Empty ? Color.LightGreen : Color.LightBlue);
                        }
                        if (!sReader.IsDBNull(5))//SeniorDoc
                        {
                            dgvWP.Rows[row].Cells[4].Style.BackColor = (dgvWP.Rows[row].Cells[4].Style.BackColor != Color.Empty ? Color.LightGreen : Color.LightBlue);
                        }
                        if (!sReader.IsDBNull(7))//VatDoc
                        {
                            dgvWP.Rows[row].Cells[6].Style.BackColor = (dgvWP.Rows[row].Cells[6].Style.BackColor != Color.Empty ? Color.LightGreen : Color.LightBlue);
                        }
                        if (!sReader.IsDBNull(9))//OtherDoc
                        {
                            dgvWP.Rows[row].Cells[8].Style.BackColor = (dgvWP.Rows[row].Cells[8].Style.BackColor != Color.Empty ? Color.LightGreen : Color.LightBlue);
                        }
                        if (!sReader.IsDBNull(11))//CashDoc
                        {
                            dgvWP.Rows[row].Cells[15].Style.BackColor = (dgvWP.Rows[row].Cells[15].Style.BackColor != Color.Empty ? Color.LightGreen : Color.LightBlue);
                        }
                        if (!sReader.IsDBNull(13))//ChargeDoc
                        {
                            dgvWP.Rows[row].Cells[17].Style.BackColor = (dgvWP.Rows[row].Cells[17].Style.BackColor != Color.Empty ? Color.LightGreen : Color.LightBlue);
                        }
                        if (!sReader.IsDBNull(15))//GiftDoc
                        {
                            dgvWP.Rows[row].Cells[19].Style.BackColor = (dgvWP.Rows[row].Cells[19].Style.BackColor != Color.Empty ? Color.LightGreen : Color.LightBlue);
                        }
                        break;
                    }
                }
            }

            con.Close(); 
        }
        public void highlightAudited()
        {
            //2 SC
            //4 sd
            //6 vat
            //8 od
            //12 gsc
            //15 ca
            //17 ch
            //19 gc
            int colDeduct = 0;
            if (multipleRP != "" || wp != "AUDITED")
            {
                colDeduct = 1;
                //MessageBox.Show(colDeduct.ToString());
            }
            for (int i = 0; i < dgvWP.Rows.Count; i++)
            {
                if (dgvWP.Rows[i].Cells[3].Value.ToString() != "")
                {
                    dgvWP.Rows[i].Cells[2].Style.BackColor = Color.Yellow;
                }
                if (dgvWP.Rows[i].Cells[5].Value.ToString() != "")
                {
                    dgvWP.Rows[i].Cells[4].Style.BackColor = Color.Yellow;
                }
                if (dgvWP.Rows[i].Cells[7].Value.ToString() != "")
                {
                    dgvWP.Rows[i].Cells[6].Style.BackColor = Color.Yellow;
                }
                if (dgvWP.Rows[i].Cells[9].Value.ToString() != "")
                {
                    dgvWP.Rows[i].Cells[8].Style.BackColor = Color.Yellow;
                }
                if (dgvWP.Rows[i].Cells[14 - colDeduct].Value.ToString() != "")
                {
                    dgvWP.Rows[i].Cells[12].Style.BackColor = Color.Yellow;
                }
                if (dgvWP.Rows[i].Cells[16 - colDeduct].Value.ToString() != "")
                {
                    dgvWP.Rows[i].Cells[15 - colDeduct].Style.BackColor = Color.Yellow;
                }
                if (dgvWP.Rows[i].Cells[18 - colDeduct].Value.ToString() != "")
                {
                    dgvWP.Rows[i].Cells[17 - colDeduct].Style.BackColor = Color.Yellow;
                }
                if (dgvWP.Rows[i].Cells[20 - colDeduct].Value.ToString() != "")
                {
                    dgvWP.Rows[i].Cells[19 - colDeduct].Style.BackColor = Color.Yellow;
                }
            }
        }
        
        private void txtMonthYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        string location = "";
        void setLocation()
        {
            //if (location != "")
            //{
                con.Open();
                string sql = "SELECT location FROM tenantmod WHERE tenantcode=@rp";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("rp", rp);
                location=cmd.ExecuteScalar().ToString();
                con.Close();
                //MessageBox.Show(location);
            //}  
        }
        private void btnExcel_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(location);
            //MessageBox.Show(rp);
            if (txtFileName.Text == "" && multipleRP!="")
            {
                MessageBox.Show("Please Input a File Name");
                txtFileName.Focus();
            }
            else
            {
                try { 
                crWorkingPaper cr1 = new crWorkingPaper();
                cr1.SetDataSource(dtPrinting);
                cr1.SetParameterValue(0, auditPeriod);
                cr1.SetParameterValue(1, auditPeriodEnd);
                cr1.SetParameterValue(2, cmbTerminal.SelectedItem.ToString());
                cr1.SetParameterValue(3, auditorFullName);
                //printWorkingPaper wpcr = new printWorkingPaper();
                //wpcr.crystalReportViewer1.ReportSource = cr1; 
                //string basePath = @AppDomain.CurrentDomain.BaseDirectory;
                string basePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string fileName = wp + "_" + txtFileName.Text + txtMonthYear.Text + ".xls";
                if (multipleRP == "")//single RP
                {
                    fileName = wp + "_" + txtRP.Text+location + txtMonthYear.Text + ".xls";
                }
                string path = Path.Combine(basePath, fileName);
                FileInfo logFileInfo = new FileInfo(path);
                DirectoryInfo logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
                if (!logDirInfo.Exists) logDirInfo.Create(); 
                    cr1.ExportToDisk(ExportFormatType.Excel, path);
                    if (File.Exists(path))
                    {
                        System.Diagnostics.Process.Start(path);
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
            //wpcr.ShowDialog();
            //wpcr.Refresh(); 
        }
        private void btnExcelCopy_Click(object sender, EventArgs e)
        {
            try
            {
                copyAlltoClipboard();
                Microsoft.Office.Interop.Excel.Application xlexcel;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlexcel = new Microsoft.Office.Interop.Excel.Application();
                xlexcel.Visible = true;
                xlWorkBook = xlexcel.Workbooks.Add(misValue);
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
                string basePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string fileName = wp + "_" + txtFileName.Text + txtMonthYear.Text + "NoFormat";
                if (multipleRP == "")
                {//single RP
                    //MessageBox.Show(multipleRP);
                    fileName = wp + "_" + txtRP.Text + location + txtMonthYear.Text + "NoFormat";
                }
                string path = Path.Combine(basePath, fileName);
                xlWorkBook.SaveAs(path);
            }
            catch(Exception er){
                MessageBox.Show(er.Message);
            }

        }
         private void copyAlltoClipboard()
        {
            dgvWP.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dgvWP.MultiSelect = true;
            dgvWP.SelectAll();
            DataObject dataObj = dgvWP.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
            dgvWP.ClearSelection();
        }
        private void btnPDF_Click(object sender, EventArgs e)
         {
            if (txtFileName.Text == "" && multipleRP != "")
            {
                MessageBox.Show("Please Input a File Name");
                txtFileName.Focus();
            }
            else
            {
                crWorkingPaper cr1 = new crWorkingPaper();
                cr1.SetDataSource(dtPrinting);
                cr1.SetParameterValue(0, auditPeriod);
                cr1.SetParameterValue(1, auditPeriodEnd);
                cr1.SetParameterValue(2, cmbTerminal.SelectedItem.ToString());
                cr1.SetParameterValue(3, auditorFullName);
                //printWorkingPaper wpcr = new printWorkingPaper();
                //wpcr.crystalReportViewer1.ReportSource = cr1; 
                string basePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string fileName = wp + "_" + txtFileName.Text + txtMonthYear.Text + ".pdf";
                if (multipleRP == "")//Single RP
                {
                    fileName = wp + "_" + txtRP.Text + location + txtMonthYear.Text + ".pdf";
                }
                string path = Path.Combine(basePath, fileName);
                FileInfo logFileInfo = new FileInfo(path);
                DirectoryInfo logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
                if (!logDirInfo.Exists) logDirInfo.Create();
                try
                {
                    cr1.ExportToDisk(ExportFormatType.PortableDocFormat, path);
                    if (File.Exists(path))
                    {
                        System.Diagnostics.Process.Start(path);
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }

            //wpcr.ShowDialog();
            //wpcr.Refresh();
        }

        private void dgvWP_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //int row = dgvWP.CurrentCell.RowIndex;
            //int col = dgvWP.CurrentCell.ColumnIndex;
            //if (dgvWP.Columns[col].Name == ".")
            //{
            //    dgvWP.Rows[row].Cells[col].Value = true;
            //    dgvWP.Rows[row].ReadOnly = true;

            //}
        }

        private void dgvWP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dgvWP.CurrentCell.RowIndex;
            int col = dgvWP.CurrentCell.ColumnIndex;
            if (dgvWP.Columns[col].Name == ".")
            {
                dgvWP.Rows[row].Cells[col].Value = true;
                //dgvWP.Rows[row].ReadOnly = true;
            } 
        }
        public void updateCheckAudited(string terminal)
        {
            string currentChecked = currentCheckedDays;//Got From Initial Loading of Form
            //if(currentChecked!="ALL" && !currentChecked.Contains("Uploaded")){
            if( !currentChecked.Contains("Uploaded")){
                string checkedDays = "";
                bool all = true;
                for (int i = 0; i < dgvWP.Rows.Count-1; i++)
                {
                    if (Convert.ToBoolean(dgvWP.Rows[i].Cells[13].Value))
                    {//CheckBox is Checked
                        checkedDays += dgvWP.Rows[i].Cells[0].Value.ToString() + ",";//Add Day to String
                    }
                    else
                    {
                        all = false;
                    }
                }
                if (all)
                {
                    checkedDays = "ALL";
                }
                else if (checkedDays!="")
                {
                    checkedDays = checkedDays.Substring(0,checkedDays.LastIndexOf(','));//Remove Last Comma
                }

                //No Insert Or Update if No Checked Days
                if (checkedDays != "")
                {
                    if (con.State!= ConnectionState.Open)
                    {
                        con.Open();
                    }
                    string sqlcount = "SELECT COUNT(*) FROM CheckedWorkingPaper WHERE tenantcode=@rp AND machine=@terminal AND auditPeriod=@auditPeriod";
                    SqlCommand cmdCount = new SqlCommand(sqlcount, con);
                    cmdCount.Parameters.AddWithValue("rp", rp);
                    cmdCount.Parameters.AddWithValue("terminal", terminal);
                    cmdCount.Parameters.AddWithValue("auditPeriod", auditPeriod);
                    int count = (int)cmdCount.ExecuteScalar();
                    if (count > 0){// UPDATE
                        string sql2 = "UPDATE CheckedWorkingPaper SET checkedLevel1 =@checkedDays WHERE tenantcode=@rp AND machine=@terminal AND auditPeriod=@auditPeriod";
                        SqlCommand cmd = new SqlCommand(sql2, con);
                        cmd.Parameters.AddWithValue("checkedDays", checkedDays);
                        cmd.Parameters.AddWithValue("rp", rp);
                        cmd.Parameters.AddWithValue("terminal", terminal);
                        cmd.Parameters.AddWithValue("auditPeriod", auditPeriod);
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
                
            }
        }
        private void WorkingPaper_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(wp=="AUDITED" && multipleRP==""){
                updateCheckAudited(cmbTerminal.SelectedItem.ToString());
            }
        }
        string lastTerminal = "";
        private void cmbTerminal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!firstTableLoad)
            {
                updateCheckAudited(lastTerminal);
                lastTerminal = cmbTerminal.SelectedItem.ToString();
                loadTable();
            }
        }

        private void btnCheckDates_Click(object sender, EventArgs e)
        {
            if (wp == "AUDITED" && multipleRP == "")
            {
                for (int i = 0; i < dgvWP.Rows.Count; i++)
                {
                    dgvWP.Rows[i].Cells[13].Value = true;
                    //dgvWP.Rows[i].Cells[13].ReadOnly = true;
                }
            }
        }

        private void cmbTerminal_DropDown(object sender, EventArgs e)
        {

            if (wp == "AUDITED" && multipleRP == "")
            {
                //updateCheckAudited();
            }
        }

        private void dgvWP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvWP.Rows.Count > 0)
            {
                int row = dgvWP.CurrentCell.RowIndex;
                int col = dgvWP.CurrentCell.ColumnIndex;
                if (dgvWP.Rows[row].Cells[col].Style.BackColor == Color.LightGreen || dgvWP.Rows[row].Cells[col].Style.BackColor == Color.LightBlue)
                {   
                    frmTickDoc ftd = new frmTickDoc();
                    ftd.StartPosition = FormStartPosition.Manual;
                    frmTickDoc.rp = rp;
                    frmTickDoc.date = Convert.ToDateTime(auditPeriod).ToString("MMMM") + " " + dgvWP.Rows[row].Cells[0].Value.ToString() + ", " + Convert.ToDateTime(auditPeriod).ToString("yyyy");
                    frmTickDoc.terminal = cmbTerminal.SelectedItem.ToString();
                    frmTickDoc.colName = dgvWP.Columns[col].Name;
                    frmTickDoc.viewing = true;
                    Point pt = new Point(Cursor.Position.X, Cursor.Position.Y);
                    //pt.Y + ftd.btnOK.Top;
                    ftd.Top = pt.Y - ftd.btnOK.Top - 2*ftd.btnOK.Height;
                    //ftd.Top = (int)(pt.Y - (ftd.Height * .5));
                    ftd.Left = (int)(pt.X - (ftd.Width * .5));
                    //if (pt.X + (ftd.Width * .5) > this.Width)
                    //{
                    //    ftd.Left = this.Width - ftd.Width;
                    //}
                    //else
                    //{
                    //    ftd.Left = (int)(pt.X - (ftd.Width * .5));
                    //}
                    ftd.Text = "Check Documents - " + dgvWP.Columns[col].Name + " " + Convert.ToDateTime(auditPeriod).ToString("MMMM") + " " + dgvWP.Rows[row].Cells[0].Value.ToString() + ", " + Convert.ToDateTime(auditPeriod).ToString("yyyy");
                    ftd.ShowDialog(); 
               }
            }  
        }

         
    }
}
