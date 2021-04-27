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

namespace MSAS
{
    public partial class AuditSchedule : Form
    {
        public static string auditor;
        string localConnection = LoginForm.localConnectionString;
        string remoteConnection = LoginForm.remoteConnectionString;
        //DataTable dt;

        string username;
        string auditMonth;
        string auditYear;
        DateTime selectedMonthYear;
        string completionMonth;
        string completionYear;
        string firstDayAudit;
        string lastDayAudit;

        string locSvr;
        string locDb;
        string rmtSvr;
        string rmtDb;

        string dLTenantcodes;
        string selectedDLTenantcodes;//12072020
        public AuditSchedule()
        {
            InitializeComponent();
        }
        bool initialTableLoad = true;
        public void reloadTable()
        {
            resetInputs();
            generateCheckedWorkingPaper();//10152020
            dgvAuditSchedule.DataSource = null;
            dgvAuditSchedule.ReadOnly = false;
            DataTable dt = new DataTable();
            //SET columns
            dt.Columns.Add("Select", typeof(bool));
            dt.Columns.Add("AuditSchedId");
            dt.Columns.Add("tenantcode");
            dt.Columns.Add("RP");
            dt.Columns.Add("Location");
            dt.Columns.Add("DataVerified", typeof(bool));
            dt.Columns.Add("High Risk", typeof(bool));
            dt.Columns.Add("Approved Discount", typeof(bool));
            dt.Columns.Add("Checked Dates -WP");
            dt.Columns.Add("Adjustment Request Status");
            dt.Columns.Add("Sales Adjustment");
            //Get Rows From DB
            SqlConnection con = new SqlConnection(localConnection);
            con.Open();
            //string sql = " SELECT b.AuditSchedId,a.tenantcode,c.name AS 'RP',locationd AS 'Location',IsPrinted,HasCorrection as 'High Risk',DateofAudit";
            string sql = " SELECT b.AuditSchedId,a.tenantcode,c.name AS 'RP',locationd AS 'Location',CASE WHEN Verified IS NULL THEN 0 ELSE 1 END AS Verified,[High Risk],";
            sql += " Approved AS 'Approved Discount','(Terminal: '+g.machine+ ') - '+checkedLevel1 AS checkedLevel1";
            sql += " ,DateofAudit";
            sql += " from AssignedRP a ";
            sql += " LEFT JOIN (SELECT * FROM AuditSchedule WHERE MonthofAudit=@month AND YearofAudit=@year) b ";
            sql += " ON ";
            sql += " a.tenantcode=b.tenantcode";
            sql += " JOIN (SELECT tenantcode,name,location,status, CASE WHEN cdate>edate THEN cdate ELSE edate END AS ClosingDate  FROM TENANTMOD) c";
            sql += " ON";
            sql += " c.tenantcode=a.tenantcode";
            sql += " JOIN location d";
            sql += " ON";
            sql += " c.location=d.location";
            sql += " LEFT JOIN (SELECT tenantcode,CAST ((CASE WHEN RiskAssessment IS NULL THEN 0  ELSE 1 END) AS BIT) AS 'Verified',CAST ((CASE WHEN RiskAssessment='HIGH' THEN 1 WHEN RiskAssessment IS NULL THEN 0 ELSE 0 END) AS BIT) AS 'High Risk' FROM salesAnalysisVerifySales WHERE date=@firstDayAudit) e";
            sql += " ON";
            sql += " a.tenantcode=e.tenantcode";
            sql += " LEFT JOIN (SELECT tenantcode,";
            sql += " CAST((CASE WHEN SUM(CAST(approved AS INT))>0  THEN 1";
            sql += " ELSE 0 END) AS BIT)";
            sql += " AS 'Approved' FROM dailymod ";
            sql += " WHERE date BETWEEN @firstDayAudit AND @lastDayAudit GROUP BY tenantcode) f";
            sql += " ON";
            sql += " a.tenantcode=f.tenantcode";
            sql += " LEFT JOIN (SELECT tenantcode,auditPeriod,machine,CheckedLevel1 FROM CheckedWorkingPaper GROUP BY tenantcode,auditperiod,machine,checkedlevel1) g ON";
            sql += " b.tenantcode=g.tenantcode AND";
            //sql += " b.MonthofAudit=FORMAT(auditPeriod,'MMMM') AND";//sql2014+
            sql += " b.MonthofAudit=DATENAME(MONTH,auditPeriod) AND";
            //sql += " b.YearofAudit= FORMAT(auditPeriod,'yyyy')";//sql2014+
            sql += " b.YearofAudit= YEAR(auditPeriod)";
            sql += " WHERE a.Username=@user AND (c.ClosingDate>=@firstDayAudit OR c.ClosingDate='1900-01-01 00:00:00.000')";
            //sql += " AND g.AuditPeriod = @firstDayAudit";
            if (chkHighRisk.Checked)
            {
                sql += " AND [High Risk]=1";
            }
            if (chkVerified.Checked)
            {
                sql += " AND [Verified]=1";
            }
            if(cmbLocations.SelectedIndex>0){ 
                sql += " AND d.location="+locationsID[cmbLocations.SelectedIndex].ToString();
                //MessageBox.Show(locationsID[cmbLocations.SelectedIndex].ToString());
            }
            sql += " ORDER BY c.name";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("user", txtUsername.Text);
            cmd.Parameters.AddWithValue("month", cmbMonths.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("year", cmbYears.SelectedItem.ToString());
            //cmd.Parameters.AddWithValue("completionMonthYear", completionMonth + " " + completionYear);
            cmd.Parameters.AddWithValue("firstDayAudit", firstDayAudit);
            cmd.Parameters.AddWithValue("lastDayAudit", lastDayAudit);
            SqlDataReader sRead = cmd.ExecuteReader();

            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //da.Fill(dt);
            while (sRead.Read())
            {
                DataRow dr = dt.NewRow();
                dr["Select"] = (bool)false;
                dr["AuditSchedId"] = sRead[0];
                dr["tenantcode"] = sRead[1];
                dr["RP"] = sRead[2];
                dr["Location"] = sRead[3];
                dr["DataVerified"] = sRead[4];
                dr["High Risk"] = sRead[5];
                dr["Approved Discount"] = sRead[6];
                dr["Checked Dates -WP"] = sRead[7];
                dr["Adjustment Request Status"] = "";
                dr["Sales Adjustment"] = "";
                dt.Rows.Add(dr);
            }
            con.Close();
            dgvAuditSchedule.DataSource = dt;
            //Autosize Columns
            for (int i = 0; i < dgvAuditSchedule.Columns.Count; i++)
            {
                dgvAuditSchedule.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //GridView ReadOnly Except Select Checkbox
                if (i > 0)
                {
                    dgvAuditSchedule.Columns[i].ReadOnly = true;
                }
            }
            for (int i = 0; i < dgvAuditSchedule.Rows.Count; i++)
            {
                if (dgvAuditSchedule.Rows[i].Cells[5].Value.ToString() == "")//Error on Else if upon null
                {
                    //Removed 12072020 for Multiple Selection Download Data
                    //dgvAuditSchedule.Rows[i].ReadOnly = true;
                }
                //else if (!Convert.ToBoolean(dgvAuditSchedule.Rows[i].Cells[5].Value.ToString()))
                //{//False values
                //    dgvAuditSchedule.Rows[i].ReadOnly = true;
                //}
                //MessageBox.Show(dgvAuditSchedule.Rows[i].Cells[5].Value.ToString());
            }
            dgvAuditSchedule.ClearSelection();
            loadRPandVerifiedCount();
        }
        void loadRPandVerifiedCount()
        {
            SqlConnection con = new SqlConnection(localConnection);
            con.Open();
            string sql1 = "SELECT COUNT(*) FROM AssignedRP a JOIN (SELECT tenantcode, CASE WHEN cdate>edate THEN cdate ELSE edate END AS closingDate FROM TENANTMOD) b";
            sql1 += " ON a.tenantcode=b.tenantcode";
            sql1 += " WHERE Username = @user";
            sql1 += " AND (closingDate>=@sdate OR  closingDate='1900-01-01 00:00:00.000')";
            SqlCommand cmd1 = new SqlCommand(sql1, con);
            cmd1.Parameters.AddWithValue("user", txtUsername.Text);
            cmd1.Parameters.AddWithValue("sdate", cmbMonths.SelectedItem.ToString()+" 1, "+cmbYears.SelectedItem.ToString());

            string sql2 = " SELECT COUNT(*) FROM assignedRP  a JOIN SalesAnalysisVerifySALES b";
            sql2 += " ON a.tenantcode=b.tenantcode";
            sql2 += " WHERE username=@user";
            sql2 += " AND date=@sdate ";
            SqlCommand cmd2 = new SqlCommand(sql2, con);
            cmd2.Parameters.AddWithValue("user", txtUsername.Text);
            cmd2.Parameters.AddWithValue("sdate", cmbMonths.SelectedItem.ToString() + " 1, " + cmbYears.SelectedItem.ToString());


            lblRPCount.Text = "Total RP: " + cmd1.ExecuteScalar().ToString();
            lblVerifiedRPCount.Text = "Total Verified: "+cmd2.ExecuteScalar().ToString();
            con.Close();
        }

        public void loadInitial()
        {
            //for (int i = 1; i < 13; i++)
            //{
            //    cmbMonths.Items.Add((Convert.ToDateTime(i.ToString() + "-01-2020")).ToString("MMMM"));
            //}

            cmbMonths.Items.Add("January");
            cmbMonths.Items.Add("February");
            cmbMonths.Items.Add("March");
            cmbMonths.Items.Add("April");
            cmbMonths.Items.Add("May");
            cmbMonths.Items.Add("June");
            cmbMonths.Items.Add("July");
            cmbMonths.Items.Add("August");
            cmbMonths.Items.Add("September");
            cmbMonths.Items.Add("October");
            cmbMonths.Items.Add("November");
            cmbMonths.Items.Add("December");

            int setSelectedMonth = Convert.ToInt16(DateTime.Today.ToString("MM")) - 2;
            if (setSelectedMonth < 0) { setSelectedMonth = 11; }
            cmbMonths.SelectedIndex = setSelectedMonth;
            //cmbMonths.SelectedItem=
            //set Year Combo Box
            for (int i = 0; i < 10; i++)
            {
                cmbYears.Items.Add(Convert.ToInt32(DateTime.Today.Year) - i);
                if (Convert.ToInt32((DateTime.Today).AddMonths(-1).Year) == Convert.ToInt32(DateTime.Today.Year) - i)
                {
                    cmbYears.SelectedIndex = i;
                }
            }
            pbxLoading.SizeMode = PictureBoxSizeMode.StretchImage;
            lblLoad.Text = "";
        }
        int[] locationsID= new int[100];
        void loadLocationsComboBox()
        {
            locationsID = new int[100];
            SqlConnection con = new SqlConnection(localConnection);
            con.Open();
            string sql = "SELECT location,locationd FROM location";
            sql += " WHERE location IN (SELECT location FROM TENANTMOD WHERE tenantcode IN (SELECT DISTINCT (tenantcode) FROM AssignedRP WHERE Username=@user))";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("user",txtUsername.Text);
            SqlDataReader sReader = cmd.ExecuteReader();
            cmbLocations.Invoke((MethodInvoker)delegate { cmbLocations.Items.Clear(); });
            cmbLocations.Invoke((MethodInvoker)delegate { cmbLocations.Items.Add("ALL"); }); 

            int i = 1;// 0 is ALL
            while (sReader.Read()){
                cmbLocations.Invoke((MethodInvoker)delegate { cmbLocations.Items.Add(sReader[1].ToString()); }); 
                locationsID[i] = Convert.ToInt32(sReader[0].ToString());
                i++; 
            }
            cmbLocations.Invoke((MethodInvoker)delegate { cmbLocations.SelectedIndex = 0; }); 
            con.Close();
            cmbLocations.DropDownWidth = DropDownWidth(cmbLocations);
        } 
        int DropDownWidth(ComboBox myCombo)
        {
            int maxWidth = 0;
            int temp = 0;
            Label label = new Label();
            label.BorderStyle = BorderStyle.None;
            foreach (var obj in myCombo.Items)
            {
                label.Text = obj.ToString();
                temp = label.PreferredWidth;
                if (temp > maxWidth)
                {
                    maxWidth = temp;
                }
            }
            label.Dispose();
            return maxWidth;
        }
        private void chkHighRisk_CheckedChanged(object sender, EventArgs e)
        {
            if (!initialTableLoad)
            {
                reloadTable();
            }
        }

        private void AuditSchedule_Load(object sender, EventArgs e)
        {
            auditor = txtAuditor.Text;
            //set ComboBox values and selected values
            loadInitial();
            //MessageBox.Show(txtUsername.Text+" "+cmbMonths.SelectedItem.ToString()+" "+cmbYears.SelectedItem.ToString());
            loadLocationsComboBox();
            initialTableLoad = true;
            reloadTable();
            initialTableLoad = false;
            //resetInputs();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            reloadTable();
        }
        public void resetInputs()
        {
            string path = @AppDomain.CurrentDomain.BaseDirectory;
            string fileName = "app.config";
            string newPath = Path.Combine(path, fileName);
            string[] appConfig = System.IO.File.ReadAllLines(Path.Combine(path, fileName));
            locSvr = appConfig[0];
            locDb = appConfig[1];
            rmtSvr = appConfig[4];
            rmtDb = appConfig[5];
            txtUsername.Invoke((MethodInvoker)delegate { username = txtUsername.Text; });
            cmbMonths.Invoke((MethodInvoker)delegate { auditMonth = cmbMonths.SelectedItem.ToString(); });
            cmbYears.Invoke((MethodInvoker)delegate { auditYear = cmbYears.SelectedItem.ToString(); });
            selectedMonthYear = Convert.ToDateTime(auditMonth + " 01," + auditYear);
            completionMonth = selectedMonthYear.AddMonths(1).ToString("MMMM");
            completionYear = selectedMonthYear.AddMonths(1).ToString("yyyy");
            firstDayAudit = selectedMonthYear.ToString("yyyy-MM-dd");
            lastDayAudit = auditYear + "-" + selectedMonthYear.ToString("MM") + "-" + DateTime.DaysInMonth(Convert.ToInt32(selectedMonthYear.ToString("yyyy")), Convert.ToInt32(selectedMonthYear.ToString("MM")));
            dLTenantcodes = getTenantCodes();
            selectedDLTenantcodes = multipleRP();
            //MessageBox.Show(username);
            //MessageBox.Show(auditMonth);
            //MessageBox.Show(auditYear);
            //MessageBox.Show(completionMonth);
            //MessageBox.Show(completionYear);
            //MessageBox.Show(firstDayAudit);
            //MessageBox.Show(lastDayAudit);
            //MessageBox.Show(dLTenantcodes);
            //MessageBox.Show(selectedDLTenantcodes);
        }

        private void btnDownloadRPA_Click(object sender, EventArgs e)
        {
            resetInputs();
            //UL/DL 
            if (locSvr.Contains("CLOUD"))
            {
                MessageBox.Show("Local Server Cannot Contain the word \"Cloud\", Contact a System Administrator or Developer for Assistance." + Environment.NewLine + "Canceling Download...");
            }
            else
            {
                btnDownloadRejected.Enabled = false;
                btnDownload.Enabled = false;
                btnDownloadRPA.Enabled = false;
                btnUpload.Enabled = false;
                //Variables
                cmbMonths.Enabled = false;
                cmbYears.Enabled = false;
                lblLoad.Text = "Downloading RP Assignments...";
                bgwDownloadRPA.RunWorkerAsync();
            }
        }

        private void bgwDownloadRPA_DoWork(object sender, DoWorkEventArgs e)
        {
            //1
            bool fail = true;
            pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Visible = true; });
            while (fail)
            {
                pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 10; });
                try
                {
                    pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 15; });
                    downloadRPAssignments();
                    fail = false;
                    lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Successfully Downloaded RP Assignments"; });
                    System.Threading.Thread.Sleep(2000);//2secs
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                    lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Download RP Assignments Failed, Retrying..."; });
                    pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 10; });
                    System.Threading.Thread.Sleep(2000);//2secs
                }
            }
            pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 25; });
            fail = true;
            //2
            while (fail)
            {
                lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Downloading Tenants Data..."; });
                System.Threading.Thread.Sleep(1000);//2secs
                try
                {
                    pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 40; });
                    downloadTenants();
                    fail = false;
                    lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Successfully Downloaded Tenants Data"; });
                    System.Threading.Thread.Sleep(2000);//2secs
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                    lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Download Tenants Data Failed, Retrying..."; });
                    pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 25; });
                    System.Threading.Thread.Sleep(2000);//2secs
                }
            }
            pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 50; });
            fail = true;
            //3
            while (fail)
            {
                lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Downloading Locations Data..."; });
                System.Threading.Thread.Sleep(1000);//2secs
                try
                {
                    pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 65; });
                    downloadLocations();
                    fail = false;
                    lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Successfully Downloaded Locations Data"; });
                    System.Threading.Thread.Sleep(2000);//2secs
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                    lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Download Locations Data Failed, Retrying..."; });
                    pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 50; });
                    System.Threading.Thread.Sleep(2000);//2secs
                }
            }
            pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 75; });
            fail = true;
            //4
            while (fail)
            {
                lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Downloading RPs with Breakdown..."; });
                System.Threading.Thread.Sleep(1000);//2secs
                try
                {
                    pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 90; });
                    downloadTenantswBreakdown();
                    fail = false;
                    lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Successfully Downloading RPs with Breakdown"; });
                    pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 100; });
                    System.Threading.Thread.Sleep(2000);//2secs
                    lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = ""; });
                    btnUpload.Invoke((MethodInvoker)delegate { btnUpload.Enabled = true; });
                    btnDownload.Invoke((MethodInvoker)delegate { btnDownload.Enabled = true; });
                    btnDownloadRPA.Invoke((MethodInvoker)delegate { btnDownloadRPA.Enabled = true; });
                    btnDownloadRejected.Invoke((MethodInvoker)delegate { btnDownloadRejected.Enabled = true; });
                    cmbMonths.Invoke((MethodInvoker)delegate { cmbMonths.Enabled = true; });
                    cmbYears.Invoke((MethodInvoker)delegate { cmbYears.Enabled = true; });
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                    pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 75; });
                    lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Download RPs with Breakdown Failed, Retrying..."; });
                    System.Threading.Thread.Sleep(2000);//2secs
                }
            }
            pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Visible = false; });
            pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 0; });
            loadLocationsComboBox();
        }

        public void downloadRPAssignments()
        {
            SqlConnection con = new SqlConnection(remoteConnection);
            con.Open();
            string sql = "spMSASDLRPAssignments";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;
            cmd.Parameters.AddWithValue("locSvr", locSvr);
            cmd.Parameters.AddWithValue("locDb", locDb);
            cmd.Parameters.AddWithValue("rmtSvr", rmtSvr);
            cmd.Parameters.AddWithValue("rmtDb", rmtDb);
            cmd.Parameters.AddWithValue("@username", username);

            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void downloadTenants()
        {
            SqlConnection con = new SqlConnection(remoteConnection);
            con.Open();
            string sql = "spMSASDLTenant";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;
            cmd.Parameters.AddWithValue("locSvr", locSvr);
            cmd.Parameters.AddWithValue("locDb", locDb);
            cmd.Parameters.AddWithValue("rmtSvr", rmtSvr);
            cmd.Parameters.AddWithValue("rmtDb", rmtDb);
            cmd.Parameters.AddWithValue("rp", getTenantCodes());

            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void downloadLocations()
        {
            SqlConnection con = new SqlConnection(remoteConnection);
            con.Open();
            string sql = "spMSASDLLocation";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;
            cmd.Parameters.AddWithValue("locSvr", locSvr);
            cmd.Parameters.AddWithValue("locDb", locDb);
            cmd.Parameters.AddWithValue("rmtSvr", rmtSvr);
            cmd.Parameters.AddWithValue("rmtDb", rmtDb);
            cmd.Parameters.AddWithValue("rp", getTenantCodes());

            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void downloadTenantswBreakdown()
        {
            SqlConnection con = new SqlConnection(remoteConnection);
            con.Open();
            string sql = "spMSASDLTenantwSBDN";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;
            cmd.Parameters.AddWithValue("locSvr", locSvr);
            cmd.Parameters.AddWithValue("locDb", locDb);
            cmd.Parameters.AddWithValue("rmtSvr", rmtSvr);
            cmd.Parameters.AddWithValue("rmtDb", rmtDb);

            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void btnDownload_Click(object sender, EventArgs e)
        {
            resetInputs();
            //MessageBox.Show(username);
            //MessageBox.Show(auditMonth);
            //MessageBox.Show(auditYear);
            //MessageBox.Show(completionMonth);
            //MessageBox.Show(completionYear);
            //MessageBox.Show(firstDayAudit);
            //MessageBox.Show(lastDayAudit);
            //MessageBox.Show(dLTenantcodes);
            //MessageBox.Show(selectedDLTenantcodes);
            //uL/DL
            if (selectedDLTenantcodes=="")
            {
                MessageBox.Show("Select/Check RPs to Download Data");
            }
            else if (locSvr.Contains("CLOUD"))
            {
                MessageBox.Show("Local Server Cannot Contain the word \"Cloud\", Contact a System Administrator or Developer for Assistance." + Environment.NewLine + "Canceling Download...");
            }
            else
            {
                btnDownloadRejected.Enabled = false;
                btnDownload.Enabled = false;
                btnDownloadRPA.Enabled = false;
                btnUpload.Enabled = false;

                cmbMonths.Enabled = false;
                cmbYears.Enabled = false;
                lblLoad.Text = "Downloading Audit Schedule...";
                bgwDownload.RunWorkerAsync();
            }
        }

        private void bgwDownload_DoWork(object sender, DoWorkEventArgs e)
        {
            bool fail = true;
            pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Visible = true; });
            pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 0; });
            //1
            lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Downloading Audit Schedule..."; });
            while (fail)
            {
                pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 5; });
                try
                {
                    downloadAuditSchedule();
                    fail = false;
                    lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Successfully Downloaded Audit Schedule Data"; });
                    System.Threading.Thread.Sleep(2000);//2secs
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                    lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Download Audit Schedule Data Failed, Retrying..."; });
                    pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 7; });
                    System.Threading.Thread.Sleep(2000);//2secs
                    lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Downloading Audit Schedule..."; });
                }
            }
            pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 20; });
            fail = true;
            lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Downloading WP Status..."; });
            //2
            while (fail)
            {
                try
                {
                    downloadWorkingPaperStatus();//SalesAnalysisVerifySales
                    pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 40; });
                    fail = false;
                    lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Successfully Downloaded WP Status"; });
                    System.Threading.Thread.Sleep(2000);//2secs
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                    lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Download WP Status Failed, Retrying..."; });
                    pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 25; });
                    System.Threading.Thread.Sleep(2000);//2secs
                    lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Downloading WP Status..."; });
                }
            } 
            fail = true;
            lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Downloading Daily Sales Data..."; });
            //3
            while (fail)
            { 
                try
                {
                    downloadDailyMod();
                    fail = false;
                    lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Successfully Downloaded Daily Sales Data"; });
                    pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 60; });
                    System.Threading.Thread.Sleep(2000);//2secs
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                    pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 45; });
                    lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Download Daily Sales Data Failed, Retrying..."; });
                    System.Threading.Thread.Sleep(2000);//2secs
                    lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Downloading Daily Sales Data..."; });
                }
            }
             
            fail = true;
            lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Downloading RP Status History..."; });
            //4
            while (fail)
            { 
                try
                {
                    downloadRPStatusHistory();
                    fail = false;
                    lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Successfully Downloaded RP Status History"; });
                    pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 90; });
                    System.Threading.Thread.Sleep(2000);//2secs
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                    pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 65; });
                    lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Download RP Status History Failed, Retrying..."; });
                    System.Threading.Thread.Sleep(2000);//2secs
                    lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Downloading RP Status History..."; });
                }
            }


            lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Recomputing VES..."; });
            //5
            try
            {
                updateVES();
                lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "VES Recomputed!"; });
                pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 100; });
                System.Threading.Thread.Sleep(2000);//2secs
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = ""; });
            //pbxLoading.Invoke((MethodInvoker)delegate { pbxLoading.Visible = false; });
            btnUpload.Invoke((MethodInvoker)delegate { btnUpload.Enabled = true; });
            btnDownload.Invoke((MethodInvoker)delegate { btnDownload.Enabled = true; });
            btnDownloadRPA.Invoke((MethodInvoker)delegate { btnDownloadRPA.Enabled = true; });
            btnDownloadRejected.Invoke((MethodInvoker)delegate { btnDownloadRejected.Enabled = true; });
            cmbMonths.Invoke((MethodInvoker)delegate { cmbMonths.Enabled = true; });
            cmbYears.Invoke((MethodInvoker)delegate { cmbYears.Enabled = true; });

            pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 0; });
            pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Visible = false; });
        }
        public void updateVES()
        {
            string tenantcodes = getTenantCodes();

            string[] tenants = tenantcodes.Split(',');
            tenantcodes = "";
            for (int i = 0; i < tenants.Length; i++)
            {
                tenantcodes += "'" + tenants[i] + "',";
            }
            if (tenantcodes != "")
            {
                tenantcodes = tenantcodes.Substring(0, tenantcodes.LastIndexOf(','));
                SqlConnection con = new SqlConnection(localConnection);
                con.Open();
                string sql = "UPDATE dailymod SET vat=(senior*0.8)/0.2 WHERE tenantcode IN (" + tenantcodes + ") AND DATE BETWEEN @firstDayData AND @lastDayData";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("firstDayData", firstDayAudit);
                cmd.Parameters.AddWithValue("lastDayData", lastDayAudit);
                //cmd.Parameters.AddWithValue("rp", getTenantCodes());
                cmd.ExecuteNonQuery();
                //01082020 Delete Copies
                string sql2 = "with cte(rownum,tenantcode ,date,machine)"; 
                sql2 +=" as ( select row_number() over ( partition by tenantcode, [date], machine order by tenantcode, [date], [machine] )"; 
                sql2 +=" , tenantcode , date , machine from dailymod  )";
                sql2 +=" DELETE  from cte where rownum > 1";
                SqlCommand cmd2 = new SqlCommand(sql2, con);
                cmd2.ExecuteNonQuery();
                con.Close();
            }
        }
        public void downloadAuditSchedule()
        {
            SqlConnection con = new SqlConnection(remoteConnection);
            con.Open();
            //MessageBox.Show(getTenantCodes());
            string sql = "spMSASDLAudSched";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;
            cmd.Parameters.AddWithValue("locSvr", locSvr);
            cmd.Parameters.AddWithValue("locDb", locDb);
            cmd.Parameters.AddWithValue("rmtSvr", rmtSvr);
            cmd.Parameters.AddWithValue("rmtDb", rmtDb);
            cmd.Parameters.AddWithValue("auditMonth", auditMonth);
            cmd.Parameters.AddWithValue("auditYear", auditYear);
            cmd.Parameters.AddWithValue("rp", selectedDLTenantcodes);
            cmd.Parameters.AddWithValue("version", getMSASVersion());

            cmd.ExecuteNonQuery();
            con.Close();
        }
        string getMSASVersion()
        {
            string text = this.Text;
            string version = text.Substring(text.IndexOf('v'));
            return version;
        }
        public void downloadWorkingPaperStatus()
        {
            SqlConnection con = new SqlConnection(remoteConnection);
            con.Open();
            string sql = "spMSASDLWPStatus";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;
            cmd.Parameters.AddWithValue("locSvr", locSvr);
            cmd.Parameters.AddWithValue("locDb", locDb);
            cmd.Parameters.AddWithValue("rmtSvr", rmtSvr);
            cmd.Parameters.AddWithValue("rmtDb", rmtDb);
            cmd.Parameters.AddWithValue("firstDayData", firstDayAudit);
            cmd.Parameters.AddWithValue("rp", selectedDLTenantcodes);

            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void downloadDailyMod()
        {
            //12092020//12102020Adjusted 
            string rpsToDL = "";
            SqlConnection locCon = new SqlConnection(localConnection);
            locCon.Open();
            string locSql = "SELECT tenantcode FROM tenantmod WHERE TENANTCODE IN("+multipleRPwithSingleQuote()+")";
            locSql += "AND tenantcode NOT IN (SELECT DISTINCT(tenantcode) FROM dailymod WHERE DATE BETWEEN @sdate and @edate )";
            SqlCommand locCmd = new SqlCommand(locSql, locCon);
            locCmd.Parameters.AddWithValue("sdate", firstDayAudit);
            locCmd.Parameters.AddWithValue("edate", firstDayAudit);
            SqlDataReader sReader = locCmd.ExecuteReader();
            while (sReader.Read())
            {
                rpsToDL += sReader["tenantcode"].ToString() +",";
            }
            locCon.Close();
            //12092020//12102020Adjusted

            if (rpsToDL != "")
            {
                rpsToDL = rpsToDL.Substring(0, rpsToDL.LastIndexOf(','));
                SqlConnection con = new SqlConnection(remoteConnection);
                con.Open();

                string sql = "spMSASDLDaily";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
                cmd.Parameters.AddWithValue("locSvr", locSvr);
                cmd.Parameters.AddWithValue("locDb", locDb);
                cmd.Parameters.AddWithValue("rmtSvr", rmtSvr);
                cmd.Parameters.AddWithValue("rmtDb", rmtDb);
                cmd.Parameters.AddWithValue("firstDayData", firstDayAudit);
                cmd.Parameters.AddWithValue("lastDayData", lastDayAudit);
                //12102020Adjusted
                cmd.Parameters.AddWithValue("rp", rpsToDL);
                cmd.ExecuteNonQuery();
                con.Close(); 
            }
        }
        public void downloadRPStatusHistory()
        {
            SqlConnection con = new SqlConnection(remoteConnection);
            con.Open();

            string sql = "spMSASDLRPStatusHistory";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 300;
            cmd.Parameters.AddWithValue("locSvr", locSvr);
            cmd.Parameters.AddWithValue("locDb", locDb);
            cmd.Parameters.AddWithValue("rmtSvr", rmtSvr);
            cmd.Parameters.AddWithValue("rmtDb", rmtDb);
            cmd.Parameters.AddWithValue("firstDayData", firstDayAudit);
            cmd.Parameters.AddWithValue("lastDayData", lastDayAudit);
            cmd.Parameters.AddWithValue("rp", selectedDLTenantcodes);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public string getTenantCodes()
        {
            SqlConnection con = new SqlConnection(localConnection);
            con.Open();
            string sql = "SELECT tenantcode FROM AssignedRP WHERE username=@user";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("user", username);
            SqlDataReader sReader = cmd.ExecuteReader();
            string tenantcodes = "";
            while (sReader.Read())
            {
                tenantcodes += sReader[0].ToString() + ",";
            }
            tenantcodes = (tenantcodes == "" ? "" : tenantcodes.Substring(0, tenantcodes.LastIndexOf(",")));
            con.Close();
            return tenantcodes;
        }

        private void btnEditWP_Click(object sender, EventArgs e)
        {
            EditWorkingPaper editWP = new EditWorkingPaper();
            int selectedRow = Convert.ToInt32(dgvAuditSchedule.SelectedCells[0].RowIndex);
            editWP.txtLocationd.Text = dgvAuditSchedule.Rows[selectedRow].Cells[4].Value.ToString().Trim();
            editWP.txtRP.Text = dgvAuditSchedule.Rows[selectedRow].Cells[3].Value.ToString().Trim();
            editWP.txtRPCode.Text = dgvAuditSchedule.Rows[selectedRow].Cells[2].Value.ToString().Trim();
            editWP.txtMonth.Text = cmbMonths.SelectedItem.ToString().Trim();
            editWP.txtYear.Text = cmbYears.SelectedItem.ToString().Trim();
            //get selected checkdates value
            string cd = dgvAuditSchedule.Rows[selectedRow].Cells[8].Value.ToString().Trim();
            //format to get terminal
            //string asTerminal = cd.Substring(cd.IndexOf(' '), cd.IndexOf(')') - cd.IndexOf(' '));
            //EditWorkingPaper.asTerminal = asTerminal;
            this.Visible = false;
            editWP.ShowDialog();
            reloadCheckedDates();
            //reloadTable();
            this.Visible = true;
            //btnEditWP.Enabled = false;
            //btnViewWP.Enabled = false;
            //btnAWP.Enabled = false;
            //btnViewFindings.Enabled = false;
            //MessageBox.Show();
        }

        private void dgvAuditSchedule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRow = dgvAuditSchedule.CurrentCell.RowIndex;
            //column 0 = AssignedID 
            //colum 4 = isPrinted
            string auditSchedID = dgvAuditSchedule.Rows[selectedRow].Cells[1].Value.ToString();
            string uploaded = dgvAuditSchedule.Rows[selectedRow].Cells[8].Value.ToString(); ;
            bool isPrinted = false;
            try { isPrinted = Convert.ToBoolean(dgvAuditSchedule.Rows[selectedRow].Cells[5].Value); }
            catch (Exception) { }
            if (auditSchedID != "" && isPrinted)
            {
                btnEditWP.Enabled = true;
                btnViewWP.Enabled = true;
                btnAWP.Enabled = true;
                btnViewFindings.Enabled = true;
                btnSpecialCase.Enabled = true;
            }
            else
            {
                btnEditWP.Enabled = false;
                btnViewWP.Enabled = false;
                btnAWP.Enabled = false;
                btnViewFindings.Enabled = false;
                btnSpecialCase.Enabled = false;
            }
            if (uploaded.Contains( "Uploaded"))
            {
                btnEditWP.Enabled = false;
            }
            checkSelectedRowsDGV();//For Multiple Printing/Uploading
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            resetInputs();
            //updateUploadedTenantsWP(); ;
            //UL/DL

            if (locSvr.Contains("CLOUD"))
            {
                MessageBox.Show("Local Server Cannot Contain the word \"Cloud\", Contact a System Administrator or Developer for Assistance." + Environment.NewLine + "Canceling Download...");
            }
            else if (multipleRPwithSingleQuote()=="")
            {
                MessageBox.Show("Select RPs to Upload");
            }
            else
            {
                MessageBox.Show(getTenantCodesForUpload());

                //btnDownloadRejected.Enabled = false;
                //btnDownload.Enabled = false;
                //btnDownloadRPA.Enabled = false;
                //btnUpload.Enabled = false;
                ////Variables
                //cmbMonths.Enabled = false;
                //cmbYears.Enabled = false;
                //lblLoad.Text = "Uploading Audited Values...";
                //bgwUpload.RunWorkerAsync();
            }
        }
        private void bgwUpload_DoWork(object sender, DoWorkEventArgs e)
        {
            //1
            bool fail = true;
            pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Visible = true; });
            pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 0; });
            while (fail)
            {
                pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 0; });
                try
                {
                    uploadAuditedTenders();
                    pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 17; });
                    fail = false;
                    lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Successfully Uploaded Audited Values!"; });
                    System.Threading.Thread.Sleep(2000);//2secs
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                    lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Upload Audited Values Failed, Retrying..."; });
                    pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 0; });
                    System.Threading.Thread.Sleep(2000);//2secs
                    lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Uploading Audited Values..."; });
                }
            }
            //2
            fail = true;
            lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Uploading Audit Findings..."; });
            while (fail)
            {
                pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 17; });
                try
                {
                    uploadAuditFindings();
                    pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 34; });
                    fail = false;
                    lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Successfully Uploaded Audit Findings"; });
                    System.Threading.Thread.Sleep(2000);//2secs
                }
                catch (Exception er)
                {
                    //MessageBox.Show(er.Message);
                    lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Upload Audit Findings Failed, Retrying..."; });
                    pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 17; });
                    MessageBox.Show(er.Message);
                    System.Threading.Thread.Sleep(2000);//2secs
                    lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Uploading Audit Findings..."; });
                }
            }
            //3
            fail = true;
            lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Uploading Supporting Documents..."; });
            while (fail)
            {
                pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 34; });
                try
                {
                    uploadSupportingDocs();
                    fail = false;
                    lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Successfully Uploaded Supporting Documents"; });
                    pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 50; });
                    System.Threading.Thread.Sleep(2000);//2secs
                }
                catch (Exception ER)
                {
                    MessageBox.Show(ER.Message);
                    pbxLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 34; });
                    lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Upload Supporting Documents Failed, Retrying..."; });
                    System.Threading.Thread.Sleep(2000);//2secs
                    lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Uploading Supporting Documents..."; });
                }
            }
            //4 
            fail = true;
            lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Uploading Daily Documents Ticking..."; });
            while (fail)
            {
                pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 50; });
                try
                {
                    uploadDocTicks();
                    fail = false;
                    lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Successfully Uploaded Daily Documents Ticking"; });
                    pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 67; });
                    System.Threading.Thread.Sleep(2000);//2secs
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                    pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 50; });
                    lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Upload Daily Documents Ticking Failed, Retrying..."; });
                    System.Threading.Thread.Sleep(2000);//2secs
                    lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Uploading Daily Documents Ticking..."; });
                }
            }
            //5
            fail = true;
            lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Uploading Special Case Breakdown..."; });
            while (fail)
            {
                pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 67; });
                try
                {
                    uploadPublishReportSBDN();
                    fail = false;
                    lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Successfully Uploaded Special Case Breakdown!"; });
                    pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 83; });
                    System.Threading.Thread.Sleep(2000);//2secs
                }
                catch (Exception ER)
                {
                    MessageBox.Show(ER.Message);
                    pbxLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 67; });
                    lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Upload Special Case Breakdown Failed, Retrying..."; });
                    System.Threading.Thread.Sleep(2000);//2secs
                    lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Uploading Special Case Breakdown..."; });
                }
            }
            //6
            fail = true;
            lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Uploading Checked Working Paper Values..."; });
            while (fail)
            {
                pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 83; });
                try
                {
                    uploadCheckedWP();
                    fail = false;
                    lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Successfully Uploaded Checked Working Papers"; });
                    pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 100; });
                    System.Threading.Thread.Sleep(2000);//2secs
                    lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = ""; });
                    //pbxLoading.Invoke((MethodInvoker)delegate { pbxLoading.Visible = false; });
                    btnUpload.Invoke((MethodInvoker)delegate { btnUpload.Enabled = true; });
                    btnDownload.Invoke((MethodInvoker)delegate { btnDownload.Enabled = true; });
                    btnDownloadRPA.Invoke((MethodInvoker)delegate { btnDownloadRPA.Enabled = true; });
                    btnDownloadRejected.Invoke((MethodInvoker)delegate { btnDownloadRejected.Enabled = true; });
                    cmbMonths.Invoke((MethodInvoker)delegate { cmbMonths.Enabled = true; });
                    cmbYears.Invoke((MethodInvoker)delegate { cmbYears.Enabled = true; });
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                    pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 83; });
                    lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Upload Checked Working Paper Values Failed, Retrying..."; });
                    System.Threading.Thread.Sleep(2000);//2secs
                    lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Uploading Checked Working Paper Values..."; });
                }
            }
            pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 0; });
            pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Visible = false; });
            updateUploadedTenantsWP();
        }
        public void uploadDocTicks()
        {
            SqlConnection con = new SqlConnection(remoteConnection);
            con.Open();
            string sql = "spMSASULSuppgDocTick";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;
            cmd.Parameters.AddWithValue("locSvr", locSvr);
            cmd.Parameters.AddWithValue("locDb", locDb);
            cmd.Parameters.AddWithValue("rmtSvr", rmtSvr);
            cmd.Parameters.AddWithValue("rmtDb", rmtDb);
            cmd.Parameters.AddWithValue("rp", getTenantCodesForUpload());
            cmd.Parameters.AddWithValue("sdate", firstDayAudit);
            cmd.Parameters.AddWithValue("edate", lastDayAudit);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void updateUploadedTenantsWP()
        {
            string tenantcodes = getTenantCodesForUpload();
            string[] tenants = tenantcodes.Split(',');
            tenantcodes = "";
            for (int i = 0; i < tenants.Length; i++)
            {
                tenantcodes += "'" + tenants[i] + "',";
            }
            if (tenantcodes != "")
            {
                tenantcodes = tenantcodes.Substring(0, tenantcodes.LastIndexOf(','));
                SqlConnection con = new SqlConnection(localConnection);
                con.Open();
                string sql = "UPDATE CheckedWorkingPaper SET checkedLevel1=checkedLevel1+'-Uploaded' WHERE tenantcode in (" + tenantcodes + ") AND auditPeriod=@auditPeriod";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("auditPeriod", firstDayAudit);

                cmd.ExecuteNonQuery();
                con.Close();
            }
            //MessageBox.Show(tenantcodes);
        }
        public void uploadAuditedTenders()
        { 
            SqlConnection con = new SqlConnection(remoteConnection);
            con.Open();

            string sql = "spMSASULAuditedTenders";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;
            cmd.Parameters.AddWithValue("locSvr", locSvr);
            cmd.Parameters.AddWithValue("locDb", locDb);
            cmd.Parameters.AddWithValue("rmtSvr", rmtSvr);
            cmd.Parameters.AddWithValue("rmtDb", rmtDb);
            cmd.Parameters.AddWithValue("rp", getTenantCodesForUpload());
            //cmd.Parameters.AddWithValue("completionMonth", completionMonth);
            //cmd.Parameters.AddWithValue("completionYear", completionYear);
            cmd.Parameters.AddWithValue("sdate", firstDayAudit);
            cmd.Parameters.AddWithValue("edate", lastDayAudit);
            //MessageBox.Show(firstDayAudit +"///"+lastDayAudit +"///" +getTenantCodes());
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void uploadAuditFindings()
        { 
            SqlConnection con = new SqlConnection(remoteConnection);
            con.Open();

            string sql = "spMSASULAuditFindings";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;
            cmd.Parameters.AddWithValue("locSvr", locSvr);
            cmd.Parameters.AddWithValue("locDb", locDb);
            cmd.Parameters.AddWithValue("rmtSvr", rmtSvr);
            cmd.Parameters.AddWithValue("rmtDb", rmtDb);
            cmd.Parameters.AddWithValue("rp", getTenantCodesForUpload());
            cmd.Parameters.AddWithValue("month", auditMonth);
            cmd.Parameters.AddWithValue("year", auditYear);
            cmd.Parameters.AddWithValue("auditPeriod", firstDayAudit);
            //cmd.Parameters.AddWithValue("lastDayData", lastDayAudit);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void updateWPAuditedStatus()
        { 
            SqlConnection con = new SqlConnection(remoteConnection);
            con.Open();

            string sql = "spMSASUpdateWP";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;
            cmd.Parameters.AddWithValue("locSvr", locSvr);
            cmd.Parameters.AddWithValue("locDb", locDb);
            cmd.Parameters.AddWithValue("rmtSvr", rmtSvr);
            cmd.Parameters.AddWithValue("rmtDb", rmtDb);
            cmd.Parameters.AddWithValue("rp", getTenantCodesForUpload());
            cmd.Parameters.AddWithValue("sdate", firstDayAudit);
            cmd.Parameters.AddWithValue("edate", lastDayAudit);

            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void uploadCheckedWP()
        { 
            SqlConnection con = new SqlConnection(remoteConnection);
            con.Open();

            string sql = "spMSASULCheckedWP";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;
            cmd.Parameters.AddWithValue("locSvr", locSvr);
            cmd.Parameters.AddWithValue("locDb", locDb);
            cmd.Parameters.AddWithValue("rmtSvr", rmtSvr);
            cmd.Parameters.AddWithValue("rmtDb", rmtDb);
            cmd.Parameters.AddWithValue("rp", getTenantCodesForUpload());
            cmd.Parameters.AddWithValue("AuditPeriod", firstDayAudit);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void uploadSupportingDocs()
        { 
            SqlConnection con = new SqlConnection(remoteConnection);
            con.Open();

            string sql = "spMSASULSupportingDocs";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;
            cmd.Parameters.AddWithValue("locSvr", locSvr);
            cmd.Parameters.AddWithValue("locDb", locDb);
            cmd.Parameters.AddWithValue("rmtSvr", rmtSvr);
            cmd.Parameters.AddWithValue("rmtDb", rmtDb);
            cmd.Parameters.AddWithValue("rp", getTenantCodesForUpload());
            cmd.Parameters.AddWithValue("AuditPeriod", firstDayAudit);

            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void uploadPublishReportSBDN()
        {
            SqlConnection con = new SqlConnection(remoteConnection);
            con.Open();
            string sql = "spMSASULPublishReportSBDN";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;
            cmd.Parameters.AddWithValue("locSvr", locSvr);
            cmd.Parameters.AddWithValue("locDb", locDb);
            cmd.Parameters.AddWithValue("rmtSvr", rmtSvr);
            cmd.Parameters.AddWithValue("rmtDb", rmtDb);
            cmd.Parameters.AddWithValue("rp", getTenantCodesForUpload());
            cmd.Parameters.AddWithValue("AuditPeriod", firstDayAudit);

            cmd.ExecuteNonQuery();
            con.Close();
        }
        public string getTenantCodesForUpload()
        {
            string tenantcodes = "";
            //HIGH RISK
            //string sql = "SELECT b.tenantcode FROM AssignedRP a JOIN";
            //sql += " CheckedWorkingPaper b";
            //sql += " ON a.tenantcode=b.tenantcode";
            //sql += " JOIN SalesAnalysisVerifySales c ";
            //sql += " ON c.tenantcode=b.tenantcode";
            //sql += " AND c.date=b.auditPeriod";
            //sql += " WHERE auditPeriod=@auditperiod";
            //sql += " AND checkedLevel1= 'ALL'";
            //sql += " AND c.RiskAssessment= 'High'";
            //sql += " AND a.Username=@username AND b.tenantcode NOT IN (SELECT tenantcode FROM CheckedWorkingPaper WHERE checkedLevel1<>'ALL' AND auditPeriod=@auditperiod)";
            string sql = "SELECT b.tenantcode,b.checkedLevel1,c.RiskAssessment FROM AssignedRP a JOIN";
            sql += " CheckedWorkingPaper b";
            sql += " ON a.tenantcode=b.tenantcode";
            sql += " JOIN SalesAnalysisVerifySales c ";
            sql += " ON c.tenantcode=b.tenantcode";
            sql += " AND b.auditPeriod=c.date";
            sql += " WHERE auditPeriod=@auditperiod";
            sql += " AND b.checkedLevel1 NOT LIKE '%Uploaded%'";
            sql += " AND b.machine = 'All'";
            //sql += " AND (c.RiskAssessment= 'High' OR c.RiskAssessment)";
            sql += " AND a.Username=@username";
            sql += " AND a.tenantcode IN ("+multipleRPwithSingleQuote()+")";
            //sql += " AND a.tenantcode IN (SELECT tenantcode FROM CheckedWorkingPaper WHERE)";
            SqlConnection con = new SqlConnection(localConnection);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("username", username);
            cmd.Parameters.AddWithValue("auditperiod", firstDayAudit);
            SqlDataReader sReader = cmd.ExecuteReader();
            while (sReader.Read())
            { 
                if (!sReader.IsDBNull(1) && sReader[1].ToString() != "" && !sReader[1].ToString().Contains("Reject"))
                {
                    string[] checkedDates = sReader[1].ToString().Split(','); 
                    if (!sReader.IsDBNull(2) && sReader[2].ToString()=="High")//Check High or Low Risk
                    {
                        if (LoginForm.highRiskDays == "ALL") //Check if Configuration High Risk Days is set to ALL
                        {
                            if (sReader[1].ToString() == "ALL")
                            {
                                tenantcodes += sReader[0].ToString() + ",";
                            }
                        }
                        else //NOT ALL, check if checked dates is equal or more than config
                        {
                            if (sReader[1].ToString() == "ALL" || checkedDates.Length >= Convert.ToInt32(LoginForm.highRiskDays))
                            {
                                tenantcodes += sReader[0].ToString() + ",";
                            }
                        }
                    }
                    else// LOW RISK
                    {
                        if (LoginForm.lowRiskDays == "ALL") //Check if Configuration High Risk Days is set to ALL
                        {
                            if (sReader[1].ToString() == "ALL")
                            {
                                tenantcodes += sReader[0].ToString() + ",";
                            }
                        }
                        else //NOT ALL, check if checked dates is equal or more than config
                        {
                            if (sReader[1].ToString() == "ALL" || checkedDates.Length >= Convert.ToInt32(LoginForm.lowRiskDays))
                            {
                                tenantcodes += sReader[0].ToString() + ",";
                            }
                        }
                    }

                }
            }
            sReader.Close();
            //SPECIFIC TERMINAL RPs
            string sql2 = "SELECT b.tenantcode,b.checkedLevel1,RiskAssessment FROM AssignedRP a JOIN";
            sql2 += " CheckedWorkingPaper b";
            sql2 += " ON a.tenantcode=b.tenantcode";
            sql2 += " JOIN SalesAnalysisVerifySales c ";
            sql2 += " ON c.tenantcode=b.tenantcode";
            sql2 += " AND b.auditPeriod=c.date";
            sql2 += " WHERE auditPeriod=@auditperiod";
            sql2 += " AND b.checkedLevel1 NOT LIKE '%Uploaded%'";
            sql2 += " AND b.machine <> 'All'";
            //sql2 += " AND c.RiskAssessment= 'Low'";
            sql2 += " AND a.Username=@username";
            sql2 += " AND a.tenantcode IN (" + multipleRPwithSingleQuote() + ")";
            SqlCommand cmd2 = new SqlCommand(sql2, con);
            cmd2.Parameters.AddWithValue("username", username);
            cmd2.Parameters.AddWithValue("auditperiod", firstDayAudit);
            SqlDataReader sReader2 = cmd2.ExecuteReader();
            string lastTenantcode = "";
            bool addTenantcode = true;
            while (sReader2.Read())
            {
                if (!sReader2.IsDBNull(1) && sReader2[1].ToString() != "" && !sReader2[1].ToString().Contains("Reject"))
                {
                    //MessageBox.Show(lastTenantcode + " " + sReader2[0].ToString());
                    //lastTenantcode=(lastTenantcode!="" || lastTenantcode!=sReader2[0].ToString()?lastTenantcode=sReader2[0].ToString():lastTenantcode);
                    if (addTenantcode&& lastTenantcode != "" && lastTenantcode != sReader2[0].ToString())
                    {
                        //MessageBox.Show(addTenantcode.ToString()+"- "+lastTenantcode + " vs " + sReader2[0].ToString());
                        tenantcodes += (addTenantcode?lastTenantcode+",":"");
                        addTenantcode = true; 
                        lastTenantcode = sReader2[0].ToString().Trim();//update lastTenantcode
                    }
                    else if (lastTenantcode != sReader2[0].ToString())
                    {
                        addTenantcode = true;
                    }
                    string[] checkedDates = sReader2[1].ToString().Split(','); 
                    if (!sReader2.IsDBNull(2) && sReader2[2].ToString() == "High")//Check High or Low Risk
                    {
                        //MessageBox.Show("HighRisk");
                        if (LoginForm.highRiskDays == "ALL")
                        {
                            //MessageBox.Show("ConfigALL");
                            if (sReader2[1].ToString() == "ALL")
                            {
                                // okay for Upload
                                //MessageBox.Show("OK-" + sReader2[0].ToString().Trim());
                            }
                            else
                            {
                                addTenantcode = false;// not okay for upload
                            }
                        }
                        else
                        {
                            //MessageBox.Show("ConfigNotALL");
                            if (sReader2[1].ToString() == "ALL" || checkedDates.Length >= Convert.ToInt32(LoginForm.highRiskDays))
                            {
                                // okay for Upload
                                //MessageBox.Show("OK-" + sReader2[0].ToString().Trim());
                            }
                            else
                            {
                                addTenantcode = false;// not okay for upload
                            }
                        }
                    }
                    else// LOW RISK
                    {
                        if (LoginForm.lowRiskDays == "ALL")
                        {
                            if (sReader2[1].ToString() == "ALL")
                            {
                                // okay for Upload
                            }
                            else
                            {
                                addTenantcode = false;// not okay for upload
                            }
                        }
                        else
                        {
                            if (sReader2[1].ToString() == "ALL" || checkedDates.Length >= Convert.ToInt32(LoginForm.lowRiskDays))
                            {
                                // okay for Upload
                            }
                            else
                            {
                                addTenantcode = false;// not okay for upload
                            }
                        }
                    }

                    lastTenantcode = sReader2[0].ToString().Trim();
                }
                //MessageBox.Show(lastTenantcode);
            }
            //MessageBox.Show(addTenantcode.ToString() + " " + lastTenantcode);
            if(addTenantcode && lastTenantcode!=""){
                //MessageBox.Show(addTenantcode.ToString() + " " + lastTenantcode);
                tenantcodes += lastTenantcode + ",";
            }

            tenantcodes = (tenantcodes == "" ? "" : tenantcodes.Substring(0, tenantcodes.LastIndexOf(",")));
            con.Close();
            return tenantcodes;
        }
        

        private void cmbMonths_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!initialTableLoad)
            {
                reloadTable();
            }
        }

        private void cmbYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!initialTableLoad)
            {
                reloadTable();
            }
        }

        private void btnViewWP_Click(object sender, EventArgs e)
        {
            //string str1 = "All-Uploaded";
            //string str2 = "1,2,3,4,5,Upload";
            //string str3 = "Uploaded";
            //string str = "Uploaded"; 
            //MessageBox.Show(getTenantCodesForUpload());
            int selectedRow = Convert.ToInt32(dgvAuditSchedule.SelectedCells[0].RowIndex);
            WorkingPaper wp = new WorkingPaper();
            wp.txtLoc.Text = dgvAuditSchedule.Rows[selectedRow].Cells[4].Value.ToString().Trim();
            wp.txtRP.Text = dgvAuditSchedule.Rows[selectedRow].Cells[3].Value.ToString().Trim();
            wp.txtMonthYear.Text = cmbMonths.SelectedItem.ToString().Trim() + " " + cmbYears.SelectedItem.ToString().Trim();
            WorkingPaper.wp = "RAW";
            WorkingPaper.rpcode = dgvAuditSchedule.Rows[selectedRow].Cells[2].Value.ToString().Trim();
            WorkingPaper.auditPeriod = cmbMonths.SelectedItem.ToString() + " 01, " + cmbYears.SelectedItem.ToString();
            WorkingPaper.auditorFullName = txtAuditor.Text;
            WorkingPaper.multipleRP = "";
            this.Visible = false;
            wp.ShowDialog();
            this.Visible = true;
        }

        private void btnAWP_Click(object sender, EventArgs e)
        {
            int selectedRow = Convert.ToInt32(dgvAuditSchedule.SelectedCells[0].RowIndex);
            WorkingPaper wp = new WorkingPaper();
            wp.txtLoc.Text = dgvAuditSchedule.Rows[selectedRow].Cells[4].Value.ToString().Trim();
            wp.txtRP.Text = dgvAuditSchedule.Rows[selectedRow].Cells[3].Value.ToString().Trim();
            wp.txtMonthYear.Text = cmbMonths.SelectedItem.ToString().Trim() + " " + cmbYears.SelectedItem.ToString().Trim();
            WorkingPaper.wp = "AUDITED";
            WorkingPaper.rpcode = dgvAuditSchedule.Rows[selectedRow].Cells[2].Value.ToString().Trim();
            WorkingPaper.auditPeriod = cmbMonths.SelectedItem.ToString() + " 01, " + cmbYears.SelectedItem.ToString();
            WorkingPaper.auditorFullName = txtAuditor.Text;
            WorkingPaper.multipleRP = "";

            this.Visible = false;
            wp.ShowDialog();
            //reloadTable();
            reloadCheckedDates();
            this.Visible = true;
            //btnEditWP.Enabled = false;
            //btnViewWP.Enabled = false;
            //btnAWP.Enabled = false;
            //btnViewFindings.Enabled = false;
        }
        private void btnPrintRaw_Click(object sender, EventArgs e)
        {
            string selectedRPs = multipleRPwithSingleQuote();
            if (selectedRPs != "")
            {
                int selectedRow = Convert.ToInt32(dgvAuditSchedule.SelectedCells[0].RowIndex);
                WorkingPaper wp = new WorkingPaper();
                wp.txtLoc.Text = "SELECTED Locations";
                wp.txtRP.Text = "SELECTED RPs";
                wp.txtMonthYear.Text = cmbMonths.SelectedItem.ToString().Trim() + " " + cmbYears.SelectedItem.ToString().Trim();
                WorkingPaper.wp = "RAW";
                WorkingPaper.rpcode = dgvAuditSchedule.Rows[selectedRow].Cells[2].Value.ToString().Trim();
                WorkingPaper.auditPeriod = cmbMonths.SelectedItem.ToString() + " 01, " + cmbYears.SelectedItem.ToString();
                WorkingPaper.auditorFullName = txtAuditor.Text;
                WorkingPaper.multipleRP = selectedRPs;
                wp.ShowDialog();
            }
            else
            {
            }
        }
        private void btnPrintAudited_Click(object sender, EventArgs e)
        {
            string selectedRPs = multipleRPwithSingleQuote();
            if (selectedRPs != "")
            {
                int selectedRow = Convert.ToInt32(dgvAuditSchedule.SelectedCells[0].RowIndex);
                WorkingPaper wp = new WorkingPaper();
                wp.txtLoc.Text = "SELECTED Locations";
                wp.txtRP.Text = "SELECTED RPs";
                wp.txtMonthYear.Text = cmbMonths.SelectedItem.ToString().Trim() + " " + cmbYears.SelectedItem.ToString().Trim();
                WorkingPaper.wp = "AUDITED";
                WorkingPaper.rpcode = dgvAuditSchedule.Rows[selectedRow].Cells[2].Value.ToString().Trim();
                WorkingPaper.auditPeriod = cmbMonths.SelectedItem.ToString() + " 01, " + cmbYears.SelectedItem.ToString();
                WorkingPaper.auditorFullName = txtAuditor.Text;
                WorkingPaper.multipleRP = selectedRPs;
                this.Visible = false;
                wp.ShowDialog();
                this.Visible = true;
            }

        }
        public string multipleRPwithSingleQuote()
        {
            string multipleRP = "";
            for (int i = 0; i < dgvAuditSchedule.Rows.Count; i++)
            {//dgvAuditSchedule.Rows.Count
                if (Convert.ToBoolean(dgvAuditSchedule.Rows[i].Cells[0].Value.ToString()))
                {
                    multipleRP += "'" + dgvAuditSchedule.Rows[i].Cells[2].Value.ToString() + "',";
                }
            }
            //MessageBox.Show(multipleRP);
            if (multipleRP != "")
            {
                multipleRP = multipleRP.Substring(0, multipleRP.LastIndexOf(","));
            }
            return multipleRP;
        }
        public string multipleRP()
        {
            string multipleRP = "";
            for (int i = 0; i < dgvAuditSchedule.Rows.Count; i++)
            {//
                if (Convert.ToBoolean(dgvAuditSchedule.Rows[i].Cells[0].Value.ToString()))
                {
                    multipleRP += dgvAuditSchedule.Rows[i].Cells[2].Value.ToString() + ",";
                }
            }
            if (multipleRP != "")
            {
                multipleRP = multipleRP.Substring(0, multipleRP.LastIndexOf(","));
            }
            return multipleRP;
        }

        private void dgvAuditSchedule_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            checkSelectedRowsDGV();
        }

        private void dgvAuditSchedule_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            checkSelectedRowsDGV();
        }

        public void checkSelectedRowsDGV()
        {
            if (!initialTableLoad)
            {
                for (int i = 0; i < dgvAuditSchedule.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgvAuditSchedule.Rows[i].Cells[0].Value.ToString()) && Convert.ToBoolean(dgvAuditSchedule.Rows[i].Cells[5].Value.ToString()))
                    {
                        btnPrintRaw.Enabled = true;
                        btnPrintAudited.Enabled = true;
                        break;
                    }
                    else
                    {
                        btnPrintRaw.Enabled = false;
                        btnPrintAudited.Enabled = false;
                    }
                }
            }
        }

        private void btnViewFindings_Click(object sender, EventArgs e)
        {
            getTenantCodesForUpload();
            int selectedRow = Convert.ToInt32(dgvAuditSchedule.SelectedCells[0].RowIndex);
            AuditFindings af = new AuditFindings();
            AuditFindings.month = cmbMonths.SelectedItem.ToString();
            AuditFindings.year = cmbYears.SelectedItem.ToString();
            AuditFindings.rp = dgvAuditSchedule.Rows[selectedRow].Cells[2].Value.ToString().Trim();
            AuditFindings.hide = true;
            af.ShowDialog();
        }

        private void bgwDownload_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            reloadTable();
        }

        private void bgwDownloadRPA_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            reloadTable();
        }

        private void bgwUpload_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            reloadTable();
        }

        private void AuditSchedule_SizeChanged(object sender, EventArgs e)
        {

        }

        private void btnDownloadRejected_Click(object sender, EventArgs e)
        {
            //UL/DL
            resetInputs();

            if (locSvr.Contains("CLOUD"))
            {
                MessageBox.Show("Local Server Cannot Contain the word \"Cloud\", Contact a System Administrator or Developer for Assistance." + Environment.NewLine + "Canceling Download...");
            }
            else
            {
                btnDownloadRejected.Enabled = false;
                btnDownload.Enabled = false;
                btnDownloadRPA.Enabled = false;
                btnUpload.Enabled = false;
                //Variables
                cmbMonths.Enabled = false;
                cmbYears.Enabled = false;

                bgwDownloadRejected.RunWorkerAsync();
            }
        }

        private void bgwDownloadRejected_DoWork(object sender, DoWorkEventArgs e)
        {
            bool fail = true;
            pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Visible = true; });
            while (fail)
            {
                lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Downloading Rejected RPs..."; });
                pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 15; });
                try
                {
                    downloadRejected();
                    fail = false;
                    pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 100; });
                    lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Successfully Downloaded Rejected RPs!"; });
                    System.Threading.Thread.Sleep(2000);//2secs
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                    lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = "Download Rejected RPs Failed, Retrying..."; });
                    pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 10; });
                    System.Threading.Thread.Sleep(2000);//2secs
                }
            }

            lblLoad.Invoke((MethodInvoker)delegate { lblLoad.Text = ""; });
            pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Visible = false; });
            pgbLoading.Invoke((MethodInvoker)delegate { pgbLoading.Value = 0; });
            btnUpload.Invoke((MethodInvoker)delegate { btnUpload.Enabled = true; });
            btnDownload.Invoke((MethodInvoker)delegate { btnDownload.Enabled = true; });
            btnDownloadRPA.Invoke((MethodInvoker)delegate { btnDownloadRPA.Enabled = true; });
            btnDownloadRejected.Invoke((MethodInvoker)delegate { btnDownloadRejected.Enabled = true; });
            cmbMonths.Invoke((MethodInvoker)delegate { cmbMonths.Enabled = true; });
            cmbYears.Invoke((MethodInvoker)delegate { cmbYears.Enabled = true; });
        }
        public void downloadRejected()
        { 
            SqlConnection con = new SqlConnection(remoteConnection);
            con.Open();

            string sql = "spMSASDLRejected";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;
            cmd.Parameters.AddWithValue("locSvr", locSvr);
            cmd.Parameters.AddWithValue("locDb", locDb);
            cmd.Parameters.AddWithValue("rmtSvr", rmtSvr);
            cmd.Parameters.AddWithValue("rmtDb", rmtDb);
            //cmd.Parameters.AddWithValue("rp", getTenantCodesForUpload());
            cmd.Parameters.AddWithValue("AuditPeriod", firstDayAudit);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void bgwDownloadRejected_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            reloadTable();
        }

        private void dgvAuditSchedule_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnEditWP.Enabled = false;
            btnViewWP.Enabled = false;
            btnAWP.Enabled = false;
            btnViewFindings.Enabled = false;
        }
        void reloadCheckedDates()
        { 
            SqlConnection con = new SqlConnection(localConnection);
            con.Open();
            string sql = "SELECT tenantcode,'Terminal: '+machine,checkedLevel1 FROM CheckedWorkingPaper ";
            sql+=" WHERE auditPeriod=@firstDayAudit AND tenantcode IN (SELECT tenantcode FROM AssignedRP WHERE Username=@user)";
            SqlCommand cmd = new SqlCommand(sql, con); 
            cmd.Parameters.AddWithValue("firstDayAudit", firstDayAudit);
            cmd.Parameters.AddWithValue("user", txtUsername.Text);
            SqlDataReader sReader = cmd.ExecuteReader();
            while (sReader.Read())
            {
                for (int i = 0; i < dgvAuditSchedule.Rows.Count; i++)
                {
                    //CHeck if Same tenantcodes
                    string dgvTenantcode=dgvAuditSchedule.Rows[i].Cells[2].Value.ToString().Trim() ;
                    if (dgvTenantcode == sReader[0].ToString().Trim())
                    {
                        //Check if Same Terminal
                        string checkedDatesValue = dgvAuditSchedule.Rows[i].Cells[8].Value.ToString();
                        string terminalValue=sReader[1].ToString(); //EX: Terminal: 1 Terminal: ALL
                        if (checkedDatesValue.Contains(terminalValue))//
                        {
                            dgvAuditSchedule.Rows[i].Cells[8].Value = "(" + terminalValue + ") - " + sReader[2].ToString().Trim();
                            break;
                        }
                    }
                }
            }
            con.Close();
        }
        void generateCheckedWorkingPaper()
        {
            SqlConnection con = new SqlConnection(localConnection);
            con.Open();
            string sql = "INSERT INTO CHECKEDWORKINGPAPER (tenantcode,machine,auditPeriod,checkedLevel1,AuditorInCharge)";
            sql+= " SELECT a.tenantcode";
            sql+= " ,'ALL' AS machine";
            sql+= " ,a.date,'' AS checkedLevel1,@fullName AS AuditorIncharge";
            sql+= " FROM SalesAnalysisVerifySales a  ";
            sql+= " WHERE a.Date =@firstDayAudit";
            sql+= " AND a.TenantCode NOT IN (SELECT tenantcode FROM CheckedWorkingPaper WHERE auditPeriod=@firstDayAudit)";
            sql+= " AND a.TenantCode IN (SELECT tenantcode FROM AssignedRP WHERE Username=@user) ";
            sql += " AND a.TenantCode NOT IN (SELECT TenantCode FROM TenantWPSBDN WHERE ((@firstDayAudit>=startDate AND endDate IS NULL) OR (@firstDayAudit BETWEEN startDate AND endDate)))";
            sql+= " GROUP BY a.tenantcode,a.Date ";
            sql+= " UNION ALL";
            sql+= " SELECT x.tenantcode";
            sql+= " ,CAST (y.machine AS varchar) AS machine";
            sql+= " ,x.date,'' AS checkedLevel1,@fullName AS AuditorIncharge";
            sql+= " FROM SalesAnalysisVerifySales x";
            sql+= " LEFT JOIN dailymod y";
            sql+= " ON x.tenantcode=y.tenantcode";
            sql+= " AND y.date BETWEEN x.Date AND DATEADD(day,-1,DATEADD(Month,1,x.Date))";
            sql+= " WHERE x.Date =@firstDayAudit";
            sql+= " AND x.TenantCode NOT IN (SELECT tenantcode FROM CheckedWorkingPaper WHERE auditPeriod=@firstDayAudit)";
            sql += " AND x.TenantCode IN (SELECT tenantcode FROM AssignedRP WHERE Username=@user ) ";
            sql += " AND x.TenantCode IN (SELECT tenantcode FROM TenantWPSBDN WHERE ((@firstDayAudit>=startDate AND endDate IS NULL) OR (@firstDayAudit BETWEEN startDate AND endDate))) ";
            sql+= " GROUP BY x.tenantcode,x.Date ,y.machine";
            SqlCommand cmd = new SqlCommand(sql,con);
            cmd.Parameters.AddWithValue("fullName", txtAuditor.Text);
            cmd.Parameters.AddWithValue("firstDayAudit", firstDayAudit);
            cmd.Parameters.AddWithValue("user", txtUsername.Text);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void btnSpecialCase_Click(object sender, EventArgs e)
        {
            int selectedRow = Convert.ToInt32(dgvAuditSchedule.SelectedCells[0].RowIndex);
            SpecialCase sc = new SpecialCase();
            SpecialCase.rp = dgvAuditSchedule.Rows[selectedRow].Cells[2].Value.ToString().Trim();
            //SpecialCase.loc = txtLocation.Text;
            SpecialCase.monthYear = cmbMonths.SelectedItem.ToString().Trim() + " " + cmbYears.SelectedItem.ToString().Trim();
            SpecialCase.action = "VIEW";
            sc.StartPosition = FormStartPosition.CenterParent;
            sc.ShowDialog(); 
        }

        private void chkVerified_CheckedChanged(object sender, EventArgs e)
        { 
            if (!initialTableLoad)
            {
                reloadTable();
            }
        }

        private void cmbLocations_SelectedIndexChanged(object sender, EventArgs e)
        { 
            if (!initialTableLoad)
            {
                reloadTable();
            }
        }

        private void txtAuditor_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnAdjRequest_Click(object sender, EventArgs e)
        {
            int selectedRow = Convert.ToInt32(dgvAuditSchedule.SelectedCells[0].RowIndex);
            frmAdjustmentRequest FAR = new frmAdjustmentRequest();
            frmAdjustmentRequest.rp = dgvAuditSchedule.Rows[selectedRow].Cells[2].Value.ToString().Trim();
            frmAdjustmentRequest.selectedDate = cmbMonths.SelectedItem.ToString() + " 01, " + cmbYears.SelectedItem.ToString();
            FAR.lblLocRPname.Text = dgvAuditSchedule.Rows[selectedRow].Cells[3].Value.ToString().Trim();
            FAR.StartPosition = FormStartPosition.CenterParent;
            FAR.ShowDialog(); 
        }

        private void btnAdjustments_Click(object sender, EventArgs e)
        {

        }
    }
}
