using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Drawing;

namespace MSAS
{
    public partial class EditWorkingPaper : Form
    {
        public EditWorkingPaper()
        {
            InitializeComponent();
        }
        public static string month;
        public static string year;
        public static string rp;

        string localConnectionString = LoginForm.localConnectionString;
        DataTable dt;

        string ServiceCharge = "ServiceCharge";
        string SCAudited = "SCAudited";
        string SCVariance = "SCVariance";

        string SeniorDiscount = "SeniorDiscount";
        string SDAudited = "SDAudited";
        string SDVariance = "SDVariance";

        string VATExempt = "VAT-Exempt";
        string VEAudited = "VEAudited";
        string VEVariance = "VEVariance";

        string NonVat = "Non-VAT";
        string NVAudited = "NVAudited";
        string NVVariance = "NVVariance";

        string OtherNonvat = "OtherNonVat";
        string AD = "AD";
        string ADAudited = "ADAudited";

        string OtherDiscount = "OtherDiscount";
        string ODAudited = "ODAudited";
        string ODVariance = "ODVariance";

        string GSC = "GSC";
        string GSCAudited = "GSCAudited";
        string GSCTick = "."; //Added 05-18-2020
        string GSCVariance = "GSCVariance";

        string Cash = "Cash";
        string CaAudited = "CaAudited";
        string CaVariance = "CaVariance";

        string Charge = "Charge";
        string ChAudited = "ChAudited";
        string ChVariance = "ChVariance";

        string GCOthers = "GC/Others";
        string GCAudited = "GCAudited";
        string GCVariance = "GCVariance";

        bool tableIsLoading = true;

        SqlConnection con;
        private void EditWorkingPaper_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(localConnectionString);

            rp = txtRPCode.Text;
            month = txtMonth.Text;
            year = txtYear.Text;
            adjustWindowSizes();
            //MessageBox.Show("" + (this.Height).ToString() + "-" + (this.Width-1).ToString());
            bool proceed=true;
            if (checkSalesData()>0)//12072020
            {

            }
            else
            {

                DialogResult msg = MessageBox.Show("RP Has no Sales Data, Click Yes to Proceed Editing, Click No to Close the module then try to redownload Data", "NO DATA CONFIRMATION", MessageBoxButtons.YesNo);
                if (msg == DialogResult.Yes)
                {
                }
                else
                {
                    proceed = false;
                    //MessageBox.Show("RP Has no Sales Data, Consider Redownloading Data, Closing Module");
                    this.Close();
                }
            }
            if (proceed)
            {
                loadTerminal();
                rdbSelectedCol.Checked = true;
                chkSC.Checked = true;
                chkOD.Checked = true;
                chkSD.Checked = true;
                chkCash.Checked = true;
                chkCharge.Checked = true;
                chkGSC.Checked = true;
                chkGC.Checked = true;
                reloadTable();
                loadSupportingDocs();
            }
        }
        int checkSalesData()
        { 
            string startDate =  txtMonth.Text + " 01, " + txtYear.Text; 
            string endDate = (Convert.ToDateTime(startDate).AddMonths(1).AddDays(-1)).ToString("MMMM dd, yyyy");
            //MessageBox.Show(endDate);
            con.Open();
            string sql = "SELECT COUNT(*) FROM DAILYMOD WHERE tenantcode=@rp AND date BETWEEN @sdate AND @edate";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("rp", txtRPCode.Text);
            cmd.Parameters.AddWithValue("sdate", startDate);
            cmd.Parameters.AddWithValue("edate", endDate);
            int count = (int)cmd.ExecuteScalar();
            con.Close();
            return count;
        }
        public void adjustWindowSizes()
        {
            this.WindowState = FormWindowState.Maximized;
            //groupBox1.Location = new Point((this.Width - groupBox1.Width) / 2, 0);
            groupBox1.Size = new Size(this.Width - 10, this.Height - 10);
            gbxDocuments.Location = new Point(groupBox1.Width - 20 - gbxDocuments.Width, 10);
            txtLocationd.Location = new Point(groupBox1.Width / 2 - txtLocationd.Width / 2, 12);
            lblLocationd.Location = new Point((groupBox1.Width / 2 - txtLocationd.Width / 2) - 10 - lblLocationd.Width, 14);
            txtRP.Location = new Point(groupBox1.Width / 2 - txtRP.Width / 2, 38);
            lblRP.Location = new Point((groupBox1.Width / 2 - txtRP.Width / 2) - 10 - lblRP.Width, 40);
            txtMonth.Location = new Point(groupBox1.Width / 2 - txtRP.Width / 2, 64);
            lblDate.Location = new Point((groupBox1.Width / 2 - txtRP.Width / 2) - 10 - lblDate.Width, 66);
            txtYear.Location = new Point((groupBox1.Width / 2 - txtRP.Width / 2) + txtMonth.Width, 64);
            cmbTerminal.Location = new Point(groupBox1.Width / 2 - cmbTerminal.Width / 2, 90);
            lblTerminal.Location = new Point((groupBox1.Width / 2 - cmbTerminal.Width / 2) - 10 - lblTerminal.Width, 92);
            chkEnableAFBreakdown.Location = new Point(groupBox1.Width / 2 - cmbTerminal.Width / 2, 120);
            btnRedo.Location = new Point(groupBox1.Width - 20 - btnRedo.Width, 120);
            btnUndo.Location = new Point(groupBox1.Width - 20 - btnRedo.Width - 10 - btnUndo.Width, 120);
            dgvWorkingPaper.Location = new Point(20, 150);
            dgvWorkingPaper.Size = new Size(groupBox1.Width - 40, groupBox1.Height - Convert.ToInt32(0.35 * (groupBox1.Height)));
            dgvWPTotal.Location = new Point(20, 150 + groupBox1.Height - Convert.ToInt32(0.35 * (groupBox1.Height)));
            dgvWPTotal.Size = new Size(groupBox1.Width - 40, 60);
            btnDeleteAll.Location = new Point(groupBox1.Width - 20 - btnDeleteAll.Width, groupBox1.Height - 20 - btnDeleteAll.Height);
            btnDeleteRow.Location = new Point(groupBox1.Width - 20 - btnDeleteAll.Width - 10 - btnDeleteRow.Width, groupBox1.Height - 20 - btnDeleteRow.Height);
            btnAFBreakdown.Location = new Point(groupBox1.Width - 20 - btnDeleteAll.Width - 10 - btnDeleteRow.Width - 10 - btnAFBreakdown.Width, groupBox1.Height - 20 - btnAFBreakdown.Height);
            btnFindings.Location = new Point(20, groupBox1.Height - 20 - btnFindings.Height);
            btnSpecialCase.Location = new Point(20+10 + btnFindings.Width, groupBox1.Height - 20 - btnSpecialCase.Height);
        }
        //SupportingDocs INITIAL LOADING
        bool suppDocsEntry = true;
        bool msr = true;
        bool reading = true;
        bool cashDeposit = true;
        bool chargeDeposit = true;
        public void loadSupportingDocs()
        {
            con.Open();
            string sqlCount = "SELECT COUNT(*) FROM AuditSupportingDocs WHERE tenantcode=@tenantcode AND machine=@machine AND date=@date";
            SqlCommand cmdCount = new SqlCommand(sqlCount, con);
            cmdCount.Parameters.AddWithValue("tenantcode", txtRPCode.Text);
            cmdCount.Parameters.AddWithValue("machine", cmbTerminal.SelectedItem.ToString());
            cmdCount.Parameters.AddWithValue("date", txtMonth.Text + " 01, " + txtYear.Text);
            if ((int)cmdCount.ExecuteScalar() > 0)
            {//
                suppDocsEntry = true;
                string sql = "SELECT MSR,Readings,Deposits,OtherDocs FROM AuditSupportingDocs WHERE tenantcode=@tenantcode AND machine=@machine AND date=@date";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("tenantcode", txtRPCode.Text);
                cmd.Parameters.AddWithValue("machine", cmbTerminal.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("date", txtMonth.Text + " 01, " + txtYear.Text);
                SqlDataReader sreader = cmd.ExecuteReader();
                while (sreader.Read())
                {
                    msr = Convert.ToBoolean(sreader[0]);
                    reading = Convert.ToBoolean(sreader[1]);
                    cashDeposit = Convert.ToBoolean(sreader[2]);
                    chargeDeposit = Convert.ToBoolean(sreader[3]);
                }
            }
            else // Create New Entry
            {
                for (int i = 0; i < cmbTerminal.Items.Count; i++)
                {
                    string sql = "INSERT INTO AuditSupportingDocs VALUES (@tenantcode,@machine,@date,@msr,@reading,@dep,@other)";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("tenantcode", txtRPCode.Text);
                    cmd.Parameters.AddWithValue("machine", cmbTerminal.Items[i].ToString());
                    cmd.Parameters.AddWithValue("date", txtMonth.Text + " 01, " + txtYear.Text);
                    cmd.Parameters.AddWithValue("msr", true);
                    cmd.Parameters.AddWithValue("reading", true);
                    cmd.Parameters.AddWithValue("dep", true);
                    cmd.Parameters.AddWithValue("other", true);
                    cmd.ExecuteNonQuery();
                }
            }
            chkMSR.Checked = msr;
            chkReadings.Checked = reading;
            chkDeposits.Checked = cashDeposit;
            chkOtherDocs.Checked = chargeDeposit;

            //chkMSR.Enabled = !msr;
            //chkReadings.Enabled = !reading;
            //chkCashDep.Enabled = !cashDeposit;
            //chkCreditDep.Enabled = !chargeDeposit;

            con.Close();
        }
        public void SaveSupportingDocs()
        {
            bool allCurrentAndDBValues = true;//
            if (chkMSR.Checked != msr)
            {
                allCurrentAndDBValues = false;
            }
            else if (chkReadings.Checked != reading)
            {
                allCurrentAndDBValues = false;
            }
            else if (chkDeposits.Checked != cashDeposit)
            {
                allCurrentAndDBValues = false;
            }
            else if (chkOtherDocs.Checked != chargeDeposit)
            {
                allCurrentAndDBValues = false;
            } 

            //Added checkSales Count Handler 12072020 for Auto Exit if RP has no Data 
            if (checkSalesData() > 0 &&(!allCurrentAndDBValues || !suppDocsEntry))//Not Same Current and DB OR No Entry Yet
            {
                con.Open();
                if (suppDocsEntry)
                {//Have Entry then update
                    string sql = "UPDATE AuditSupportingDocs SET MSR=@msr,Readings=@reading,Deposits=@dep,OtherDocs=@other WHERE tenantcode=@tenantcode AND machine=@machine AND date=@date";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("msr", chkMSR.Checked);
                    cmd.Parameters.AddWithValue("reading", chkReadings.Checked);
                    cmd.Parameters.AddWithValue("dep", chkDeposits.Checked);
                    cmd.Parameters.AddWithValue("other", chkOtherDocs.Checked);
                    cmd.Parameters.AddWithValue("tenantcode", txtRPCode.Text);
                    cmd.Parameters.AddWithValue("machine", cmbTerminal.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("date", txtMonth.Text + " 01, " + txtYear.Text);
                    cmd.ExecuteNonQuery();
                }

                con.Close();
            }
        }
        public static string asTerminal = "";
        public void loadTerminal()
        {
            cmbTerminal.Items.Clear();
            DateTime startDate = Convert.ToDateTime(txtMonth.Text + " 01, " + txtYear.Text);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);

            con.Open();
            //Count Terminals used for the Audit Period
            //string sql = "SELECT COUNT(DISTINCT(machine)) FROM dailymod WHERE tenantcode=@tenantcode AND date BETWEEN @startDate AND @endDate";
            string sql = "SELECT COUNT(DISTINCT(machine)) FROM dailymod WHERE tenantcode=@tenantcode ";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("tenantcode", txtRPCode.Text);
            cmd.Parameters.AddWithValue("startDate", startDate.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("endDate", endDate.ToString("yyyy-MM-dd"));
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            //CHECK if Tenant has Sales Breakdown
            //IF Tenant has Sales Breakdown, ALL terminal is not added on the items
            sql = "SELECT COUNT(DISTINCT(tenantcode)) AS 'tenantcode' FROM TenantWPSBDN WHERE tenantcode=@tenantcode AND ((@startDate>=startDate AND endDate IS NULL) OR (@startDate BETWEEN startDate AND endDate))";
            SqlCommand cmd2 = new SqlCommand(sql, con);
            cmd2.Parameters.Clear();
            cmd2.Parameters.AddWithValue("tenantcode", txtRPCode.Text);
            cmd2.Parameters.AddWithValue("startDate", startDate.ToString("yyyy-MM-dd"));
            if ((int)cmd2.ExecuteScalar() == 0 && count > 0)
            {//Not on the list and more than 1 terminal lang ang pwede mag ALL
                cmbTerminal.Items.Add("ALL");
                count = 0;//Dont Add Machine if RP doesn't have SBDN
            }
            if (count > 0)
            {//list Terminal used
                //sql = "SELECT DISTINCT(machine) AS 'machine' FROM dailymod WHERE tenantcode=@tenantcode AND date BETWEEN @startDate AND @endDate";
                sql = "SELECT DISTINCT(machine) AS 'machine' FROM dailymod WHERE tenantcode=@tenantcode";
                SqlCommand cmd3 = new SqlCommand(sql, con);
                cmd3.Parameters.Clear();
                cmd3.Parameters.AddWithValue("tenantcode", txtRPCode.Text);
                cmd3.Parameters.AddWithValue("startDate", startDate.ToString("yyyy-MM-dd"));
                cmd3.Parameters.AddWithValue("endDate", endDate.ToString("yyyy-MM-dd"));
                SqlDataReader sReader = cmd3.ExecuteReader();
                while (sReader.Read())
                {
                    cmbTerminal.Items.Add(sReader["machine"].ToString());
                }
            }
            if (cmbTerminal.Items.Count>0)
            {
                cmbTerminal.SelectedIndex = 0;
            }
            //AuditSchedTerminal   
            //if (asTerminal != "" && asTerminal!="ALL")
            //{
            //    //cmbTerminal.SelectedValue = asTerminal;
            //    cmbTerminal.SelectedItem = asTerminal.ToString();
            //    //cmbTerminal.SelectedItem = asTerminal;
            //    //cmbTerminal.SelectedIndex = cmbTerminal.Items.IndexOf(asTerminal);
            //}
            //else
            //{
            //    cmbTerminal.SelectedItem = "ALL";
            //}
            ////MessageBox.Show(asTerminal); 
            lastTerminal = cmbTerminal.SelectedItem.ToString();//04062021
            con.Close();
        }
        string currentCheckedDays = "";
        public string getCheckedDays()
        {
            string cd = "";
            con.Open();
            string sqlCount = "SELECT COUNT(*) FROM CheckedWorkingPaper WHERE tenantcode=@rp AND machine=@terminal AND auditPeriod=@auditPeriod";
            SqlCommand cmdCount = new SqlCommand(sqlCount, con);
            cmdCount.Parameters.AddWithValue("rp", rp);
            cmdCount.Parameters.AddWithValue("terminal", cmbTerminal.Items[cmbTerminal.SelectedIndex].ToString());
            cmdCount.Parameters.AddWithValue("auditPeriod", txtMonth.Text + " 01, " + txtYear.Text);
            //MessageBox.Show(cmbTerminal.Items[cmbTerminal.SelectedIndex].ToString());
            if (Convert.ToInt16(cmdCount.ExecuteScalar()) > 0)
            {
                string sql = "SELECT checkedLevel1 FROM CheckedWorkingPaper WHERE tenantcode=@rp AND machine=@terminal AND auditPeriod=@auditPeriod";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("rp", rp);
                cmd.Parameters.AddWithValue("terminal", cmbTerminal.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("auditPeriod", txtMonth.Text + " 01, " + txtYear.Text);
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
                    cmdIns.Parameters.AddWithValue("terminal", cmbTerminal.SelectedItem.ToString());
                    cmdIns.Parameters.AddWithValue("auditPeriod", txtMonth.Text + " 01, " + txtYear.Text);
                    cmdIns.Parameters.AddWithValue("checkedDays", "");
                    cmdIns.Parameters.AddWithValue("checker1", AuditSchedule.auditor);
                    cmdIns.ExecuteNonQuery();
                }

            }
            //MessageBox.Show(cd);

            con.Close();
            return cd;
        }
        public void reloadTable()
        {
            tableIsLoading = true;
            DateTime startDate = Convert.ToDateTime(txtMonth.Text + " 01, " + txtYear.Text);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);
            //DateTime endDate = Convert.ToDateTime(txtMonth.Text + DateTime.DaysInMonth(Convert.ToInt32(txtYear.Text), Convert.ToInt32(startDate.ToString("MM"))));
            //Get SelectedDates only
            //List<DateTime> selectedDates = new List<DateTime>();
            string selectedDates = "";
            for (int i = 0; i < dgvWorkingPaper.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgvWorkingPaper.Rows[i].Cells[0].Value))
                {
                    //selectedDates.Add(Convert.ToDateTime(dgvWorkingPaper.Rows[i].Cells[1].Value));
                    selectedDates += "'" + dgvWorkingPaper.Rows[i].Cells[1].Value.ToString() + "',";
                }
            }
            if (selectedDates != "")
            {
                selectedDates = selectedDates.Substring(0, selectedDates.LastIndexOf(","));
            }

            dgvWorkingPaper.DataSource = null;
            dt = new DataTable();
            //Set Static Columns
            dt.Columns.Add(" ", typeof(bool));
            dt.Columns.Add("Date");
            dt.Columns.Add("Day");
            //Set Dynamic Columns
            if (chkSC.Checked == true || rdbAllCol.Checked == true)//1
            {
                dt.Columns.Add(ServiceCharge);
                dt.Columns.Add(SCAudited);
                dt.Columns.Add(SCVariance);
                if (chkDocTicks.Checked)
                {
                    dt.Columns.Add("SCDocs", typeof(string));
                }
            }
            if (chkSD.Checked == true || rdbAllCol.Checked == true)//2
            {
                dt.Columns.Add(SeniorDiscount);
                dt.Columns.Add(SDAudited);
                dt.Columns.Add(SDVariance);
                if (chkDocTicks.Checked)
                {
                    dt.Columns.Add("SDDocs", typeof(string));
                }
            }
            if (chkVE.Checked == true || rdbAllCol.Checked == true)//3
            {
                dt.Columns.Add(VATExempt);
                dt.Columns.Add(VEAudited);
                dt.Columns.Add(VEVariance);
                if (chkDocTicks.Checked)
                {
                    dt.Columns.Add("VESDocs", typeof(string));
                }
            }
            //if (chkNV.Checked == true || rdbAllCol.Checked == true)//3
            //{
            //    dt.Columns.Add(NonVat);
            //    dt.Columns.Add(NVAudited);
            //    dt.Columns.Add(NVVariance);
            //}
            if (chkONV.Checked == true || rdbAllCol.Checked == true)//3
            {
                dt.Columns.Add(OtherNonvat);
            }
            if (chkOD.Checked == true || rdbAllCol.Checked == true)//4
            {
                dt.Columns.Add(OtherDiscount);
                dt.Columns.Add(ODAudited);
                dt.Columns.Add(ODVariance); 
                if (chkDocTicks.Checked)
                {
                    dt.Columns.Add("ODDocs", typeof(string));
                }
            }
            if (chkAD.Checked == true || rdbAllCol.Checked == true)//4
            {
                dt.Columns.Add(AD, typeof(bool));
                dt.Columns.Add(ADAudited, typeof(bool));
            }
            if (chkGSC.Checked == true || rdbAllCol.Checked == true)//5
            {
                dt.Columns.Add(GSC);
                dt.Columns.Add(GSCAudited);
                dt.Columns.Add(GSCTick, typeof(bool));
                dt.Columns.Add(GSCVariance);
            }
            if (chkCash.Checked == true || rdbAllCol.Checked == true)//6
            {
                dt.Columns.Add(Cash);
                dt.Columns.Add(CaAudited);
                dt.Columns.Add(CaVariance);
                if (chkDocTicks.Checked)
                {
                    dt.Columns.Add("CaDocs", typeof(string));
                    //dt.Columns.Add("CaMSR", typeof(bool));
                    //dt.Columns.Add("CaRead", typeof(bool));
                    //dt.Columns.Add("CaDepo", typeof(bool));
                    //dt.Columns.Add("CaOther", typeof(bool));
                }
            }
            if (chkCharge.Checked == true || rdbAllCol.Checked == true)//7
            {
                dt.Columns.Add(Charge);
                dt.Columns.Add(ChAudited);
                dt.Columns.Add(ChVariance);
                if (chkDocTicks.Checked)
                {
                    dt.Columns.Add("ChDocs", typeof(string));
                    //dt.Columns.Add("Ch1", typeof(bool));
                    //dt.Columns.Add("Ch2", typeof(bool));
                    //dt.Columns.Add("Ch3", typeof(bool));
                    //dt.Columns.Add("Ch4", typeof(bool));
                }
            }
            if (chkGC.Checked == true || rdbAllCol.Checked == true)//8
            {
                dt.Columns.Add(GCOthers);
                dt.Columns.Add(GCAudited);
                dt.Columns.Add(GCVariance);
                if (chkDocTicks.Checked)
                {
                    dt.Columns.Add("GCDocs", typeof(string));
                }
            }
            string sql = "SELECT d.date,";
            sql += " SUM(a.surcharge) AS '" + ServiceCharge + "',";
            sql += " c.surcharge AS '" + SCAudited + "',";
            sql += " c.surchargeVar AS '" + SCVariance + "',";
            sql += " e.surchargeDoc,";
            sql += " SUM(a.senior) AS '" + SeniorDiscount + "',";
            sql += " c.senior AS '" + SDAudited + "',";
            sql += " c.seniorVar AS '" + SDVariance + "',";
            sql += " e.seniorDoc,";
            sql += " SUM(a.other) AS '" + OtherDiscount + "',";
            sql += " c.other AS '" + ODAudited + "',";
            sql += " c.otherVar AS '" + ODVariance + "',";
            sql += " e.otherDoc,";
            sql += " SUM(a.vat) AS '" + VATExempt + "',";
            sql += " c.vat AS '" + VEAudited + "',";
            sql += " c.vatVar AS '" + VEVariance + "',";
            sql += " e.vatDoc AS 'vatDoc',";
            sql += " SUM(a.nonvat) AS '" + NonVat + "',";
            sql += " c.nonvat AS '" + NVAudited + "',";
            sql += " c.nonvatVar AS '" + NVVariance + "',";
            //sql += "--SUM(othernonvat),"; NO NEED PALA
            sql += " c.otherNonVat AS '" + OtherNonvat + "',";
            sql += " a.approved AS '" + AD + "',";
            sql += " c.approved AS '" + ADAudited + "',";
            sql += " SUM(a.gsc) AS '" + GSC + "',";
            sql += " c.gsc AS '" + GSCAudited + "',";
            sql += " CAST(0 AS BIT) AS '.',"; //Checked Date, Added 05-18-2020
            sql += " c.gscVar AS '" + GSCVariance + "',";
            sql += " SUM(a.cash) AS '" + Cash + "',";
            sql += " c.cash AS '" + CaAudited + "',";
            sql += " c.cashVar AS '" + CaVariance + "',";
            sql += " e.cashDoc,";
            sql += " SUM(a.charge) AS '" + Charge + "',";
            sql += " c.charge AS '" + ChAudited + "',";
            sql += " c.chargeVar AS '" + ChVariance + "',";
            sql += " e.chargeDoc,";
            sql += " SUM(a.gift) AS '" + GCOthers + "',";
            sql += " c.gift AS '" + GCAudited + "',";
            sql += " c.giftVar AS '" + GCVariance + "',";
            sql += " e.giftDoc";
            sql += " FROM (SELECT * FROM dailymod WHERE date BETWEEN @firstDayAudit  AND @lastDayAudit AND tenantcode = @rpcode";
            if (cmbTerminal.SelectedItem.ToString() != "ALL")
            {
                sql += " AND machine=@terminal";
            }
            sql += " ) a JOIN";
            sql += " (Select COUNT(machine) as 'machine', tenantcode, date";
            sql += " from DAILYMOD ";
            sql += " WHERE date BETWEEN @firstDayAudit  AND @lastDayAudit AND tenantcode = @rpcode";
            sql += " GROUP BY tenantcode,date) b";
            sql += " ON a.tenantcode=b.tenantcode AND a.date=b.date";
            //Added 08-03-2020
            sql += " RIGHT JOIN (SELECT Date= DATEADD(Day,Number,@firstDayAudit), @rpcode AS [tenantcode]";
            if (cmbTerminal.SelectedItem.ToString() != "ALL")
            {
                sql += ",@terminal AS[machine]";
            }
            sql += " FROM master..spt_values";
            sql += " WHERE Type='P' AND DATEADD(Day,Number,@firstDayAudit) <=@lastDayAudit) d";
            sql += " ON a.date=d.date AND a.tenantcode=d.tenantcode AND a.tenantcode= @rpcode";
            if (cmbTerminal.SelectedItem.ToString() != "ALL")
            {
                sql += " AND a.machine=d.machine";
            }
            //Moved 08-04-2020 FROM joining dailymod table to Days Table
            sql += " LEFT JOIN (SELECT * FROM AuditedTenders WHERE date BETWEEN @firstDayAudit  AND @lastDayAudit AND tenantcode = @rpcode AND machine=@terminal) c";
            sql += " ON d.tenantcode=c.tenantcode";
            sql += " AND d.date=c.date";
            if (cmbTerminal.SelectedItem.ToString() != "ALL")
            {
                sql += " AND c.machine=d.machine";
            }
            sql += " LEFT JOIN DailySuppDocTick e ON d.tenantcode=e.tenantcode AND d.date=e.date";
            if (cmbTerminal.SelectedItem.ToString() != "ALL")
            {
                sql += " AND e.machine=d.machine";
            }
            sql += " WHERE 1=1";

            if (selectedDates != "")
            {
                sql += " AND d.date IN (" + selectedDates + ")";
            }
            sql += " GROUP BY a.tenantcode,d.date,a.approved,c.surcharge,c.senior,c.other,c.vat,c.nonvat,c.otherNonVat,a.approved,c.approved,c.gsc,c.cash,c.charge,c.gift";
            sql += " ,c.surchargeVar,seniorVar,otherVar,vatVar,nonvatVar,gscVar,cashVar,chargeVar,giftVar";
            sql += ", e.surchargeDoc,e.seniorDoc,e.otherDoc,e.vatDoc,e.cashDoc,e.chargeDoc,e.giftDoc";
            sql += " ORDER BY d.date";

            //Set Dynamic Columns End
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Clear();
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;
            //MessageBox.Show(startDate.ToString("yyyy-MM-dd") + " " + endDate.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@firstDayAudit", startDate.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@lastDayAudit", endDate.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@rpcode", txtRPCode.Text);
            cmd.Parameters.AddWithValue("@terminal", cmbTerminal.SelectedItem.ToString());
            SqlDataReader sReader = cmd.ExecuteReader();
            while (sReader.Read())
            {
                DataRow dr = dt.NewRow();
                dr[" "] = (bool)false;
                dr["date"] = (Convert.ToDateTime(sReader["date"])).ToString("MMMM dd, yyyy");
                dr["Day"] = Convert.ToDateTime(sReader["date"]).ToString("ddd");

                if (chkSC.Checked == true || rdbAllCol.Checked == true)//1
                {//NULL ERROR
                    dr[ServiceCharge] = (!sReader.IsDBNull(sReader.GetOrdinal(ServiceCharge)) ? Convert.ToDouble(sReader[ServiceCharge]).ToString("#,0.00") : "");
                    dr[SCAudited] = (!sReader.IsDBNull(sReader.GetOrdinal(SCAudited)) ? Convert.ToDouble(sReader[SCAudited]).ToString("#,0.00") : "");
                    dr[SCVariance] = (!sReader.IsDBNull(sReader.GetOrdinal(SCVariance)) ? Convert.ToDouble(sReader[SCVariance]).ToString("#,0.00") : "");
                    if (chkDocTicks.Checked)
                    {
                        dr["SCDocs"] = sReader["surchargeDoc"].ToString();
                    }
                }
                if (chkSD.Checked == true || rdbAllCol.Checked == true)//2
                {
                    dr[SeniorDiscount] = (!sReader.IsDBNull(sReader.GetOrdinal(SeniorDiscount)) ? Convert.ToDouble(sReader[SeniorDiscount]).ToString("#,0.00") : "");
                    dr[SDAudited] = (!sReader.IsDBNull(sReader.GetOrdinal(SDAudited)) ? Convert.ToDouble(sReader[SDAudited]).ToString("#,0.00") : "");
                    dr[SDVariance] = (!sReader.IsDBNull(sReader.GetOrdinal(SDVariance)) ? Convert.ToDouble(sReader[SDVariance]).ToString("#,0.00") : "");
                    if (chkDocTicks.Checked)
                    {
                        dr["SDDocs"] = sReader["seniorDoc"].ToString();
                    }
                }
                if (chkVE.Checked == true || rdbAllCol.Checked == true)//3
                {
                    dr[VATExempt] = (!sReader.IsDBNull(sReader.GetOrdinal(VATExempt)) ? Convert.ToDouble(sReader[VATExempt]).ToString("#,0.00") : "");
                    dr[VEAudited] = (!sReader.IsDBNull(sReader.GetOrdinal(VEAudited)) ? Convert.ToDouble(sReader[VEAudited]).ToString("#,0.00") : "");
                    dr[VEVariance] = (!sReader.IsDBNull(sReader.GetOrdinal(VEVariance)) ? Convert.ToDouble(sReader[VEVariance]).ToString("#,0.00") : "");
                    if (chkDocTicks.Checked)
                    {
                        dr["VESDocs"] = sReader["VatDoc"].ToString();
                    }
                }
                //NONVAT
                //if (chkNV.Checked == true || rdbAllCol.Checked == true)//
                //{
                //    dr[NonVat] = (!sReader.IsDBNull(sReader.GetOrdinal(NonVat)) ? Convert.ToDouble(sReader[NonVat]).ToString("#,0.00") : "");
                //    dr[NVAudited] = (!sReader.IsDBNull(sReader.GetOrdinal(NVAudited)) ? Convert.ToDouble(sReader[NVAudited]).ToString("#,0.00") : "");
                //    dr[NVVariance] = (!sReader.IsDBNull(sReader.GetOrdinal(NVVariance)) ? Convert.ToDouble(sReader[NVVariance]).ToString("#,0.00") : "");
                //}
                if (chkONV.Checked == true || rdbAllCol.Checked == true)//4
                {
                    dr[OtherNonvat] = (!sReader.IsDBNull(sReader.GetOrdinal(OtherNonvat)) ? Convert.ToDouble(sReader[OtherNonvat]).ToString("#,0.00") : "");
                }
                if (chkOD.Checked == true || rdbAllCol.Checked == true)//4
                {
                    dr[OtherDiscount] = (!sReader.IsDBNull(sReader.GetOrdinal(OtherDiscount)) ? Convert.ToDouble(sReader[OtherDiscount]).ToString("#,0.00") : "");
                    dr[ODAudited] = (!sReader.IsDBNull(sReader.GetOrdinal(ODAudited)) ? Convert.ToDouble(sReader[ODAudited]).ToString("#,0.00") : "");
                    dr[ODVariance] = (!sReader.IsDBNull(sReader.GetOrdinal(ODVariance)) ? Convert.ToDouble(sReader[ODVariance]).ToString("#,0.00") : "");
                    if (chkDocTicks.Checked)
                    {
                        dr["ODDocs"] = sReader["otherDoc"].ToString();
                    }
                }
                //AD
                if (chkAD.Checked == true || rdbAllCol.Checked == true)//
                {
                    dr[AD] = (!sReader.IsDBNull(sReader.GetOrdinal(AD)) ? Convert.ToBoolean(sReader[AD]) : false);
                    if(!sReader.IsDBNull(sReader.GetOrdinal(ADAudited))){
                        dr[ADAudited] = Convert.ToBoolean(sReader[ADAudited]);
                    }
                    else
                    {
                        dr[ADAudited] = (!sReader.IsDBNull(sReader.GetOrdinal(AD)) ? Convert.ToBoolean(sReader[AD]) : false);
                    }
                    
                }
                if (chkGSC.Checked == true || rdbAllCol.Checked == true)//5
                {
                    dr[GSC] = (!sReader.IsDBNull(sReader.GetOrdinal(GSC)) ? Convert.ToDouble(sReader[GSC]).ToString("#,0.00") : "");
                    dr[GSCAudited] = (!sReader.IsDBNull(sReader.GetOrdinal(GSCAudited)) ? Convert.ToDouble(sReader[GSCAudited]).ToString("#,0.00") : "");
                    dr[GSCTick] = false;
                    dr[GSCVariance] = (!sReader.IsDBNull(sReader.GetOrdinal(GSCVariance)) ? Convert.ToDouble(sReader[GSCVariance]).ToString("#,0.00") : "");
                }
                if (chkCash.Checked == true || rdbAllCol.Checked == true)//6
                {
                    dr[Cash] = (!sReader.IsDBNull(sReader.GetOrdinal(Cash)) ? Convert.ToDouble(sReader[Cash]).ToString("#,0.00") : "");
                    dr[CaAudited] = (!sReader.IsDBNull(sReader.GetOrdinal(CaAudited)) ? Convert.ToDouble(sReader[CaAudited]).ToString("#,0.00") : "");
                    dr[CaVariance] = (!sReader.IsDBNull(sReader.GetOrdinal(CaVariance)) ? Convert.ToDouble(sReader[CaVariance]).ToString("#,0.00") : "");
                    if (chkDocTicks.Checked)
                    {
                        dr["CaDocs"] = sReader["CashDoc"].ToString();
                    }
                }
                if (chkCharge.Checked == true || rdbAllCol.Checked == true)//7
                {
                    dr[Charge] = (!sReader.IsDBNull(sReader.GetOrdinal(Charge)) ? Convert.ToDouble(sReader[Charge]).ToString("#,0.00") : "");
                    dr[ChAudited] = (!sReader.IsDBNull(sReader.GetOrdinal(ChAudited)) ? Convert.ToDouble(sReader[ChAudited]).ToString("#,0.00") : "");
                    dr[ChVariance] = (!sReader.IsDBNull(sReader.GetOrdinal(ChVariance)) ? Convert.ToDouble(sReader[ChVariance]).ToString("#,0.00") : "");
                    if (chkDocTicks.Checked)
                    {
                        dr["ChDocs"] = sReader["chargeDoc"].ToString();
                    }
                }
                if (chkGC.Checked == true || rdbAllCol.Checked == true)//8
                {
                    dr[GCOthers] = (!sReader.IsDBNull(sReader.GetOrdinal(GCOthers)) ? Convert.ToDouble(sReader[GCOthers]).ToString("#,0.00") : "");
                    dr[GCAudited] = (!sReader.IsDBNull(sReader.GetOrdinal(GCAudited)) ? Convert.ToDouble(sReader[GCAudited]).ToString("#,0.00") : "");
                    dr[GCVariance] = (!sReader.IsDBNull(sReader.GetOrdinal(GCVariance)) ? Convert.ToDouble(sReader[GCVariance]).ToString("#,0.00") : "");
                    if (chkDocTicks.Checked)
                    {
                        dr["GCDocs"] = sReader["GiftDoc"].ToString();
                    }
                }
                dt.Rows.Add(dr);
            }
            con.Close();
            dgvWorkingPaper.DataSource = dt;


            tableAdjustments();
            //DateTime ate = Convert.ToDateTime("February 09, 2020");
            ////MessageBox.Show(dgvWorkingPaper.Rows[0].Cells[indx].Value.ToString());
            //MessageBox.Show(ate.ToString("%d"));
            //dgvWorkingPaper.Rows[0].Frozen = true;
            dgvWorkingPaper.Columns[0].Frozen = true;
            dgvWorkingPaper.Columns[1].Frozen = true;
            reloadWPTotal();
            tableIsLoading = false;
            resetUndoRedoVariables();
        }
        void resetUndoRedoVariables()
        {
            //Reset Undo/Redo Values
            actionsRow = new int[100];
            actionsCol = new int[100];
            undoValues = new string[100];
            redoValues = new string[100];
            actionIndex = 0;
            actionSize = 0;
            undoTP = new string[100];
            redoTP = new string[100];
            undoMisclass = new string[100];
            redoMisclass = new string[100];
            undoMisclassTo = new string[100];
            redoMisclassTo = new string[100];
            undoOtherF = new string[100];
            redoOtherF = new string[100];
            undoUnreported = new string[100];
            redoUnreported = new string[100];
            btnUndo.Enabled = false;
            btnRedo.Enabled = false;
        }
        void tableAdjustments()
        {
            int increment =(chkDocTicks.Checked?4:3); 
            //Set Colors
            for (int i = 0; i < dgvWorkingPaper.Rows.Count; i++)
            {
                //checkdates WP
                dgvWorkingPaper.Rows[i].Cells[0].Value = true;
                //Added 080122020 , Color Gray everything
                for (int y = 0; y < dgvWorkingPaper.Columns.Count; y++)
                {
                    dgvWorkingPaper.Rows[i].Cells[y].Style.BackColor = Color.LightGray;
                    if (dgvWorkingPaper.Columns[y].Name.Contains("Doc"))
                    {
                        dgvWorkingPaper.Rows[i].Cells[y].Style.BackColor = Color.SkyBlue;
                    }
                }
                for (int x = 4; x < dgvWorkingPaper.Columns.Count; x += increment)
                {
                    dgvWorkingPaper.Rows[i].Cells[x].Style.BackColor = Color.White;
                    //Approve Discount
                    if (dgvWorkingPaper.Columns[x].Name == ADAudited)
                    {
                        if (Convert.ToBoolean(dgvWorkingPaper.Rows[i].Cells[x].Value) != false)
                        {
                            dgvWorkingPaper.Rows[i].Cells[x].Style.BackColor = Color.Yellow;
                        }
                        x-=(!chkDocTicks.Checked?1:2);
                        
                    }
                    //Other Audited Values
                    else if (dgvWorkingPaper.Rows[i].Cells[x].Value.ToString() != "" && x + 1 < dgvWorkingPaper.Columns.Count)
                    {
                        dgvWorkingPaper.Rows[i].Cells[x].Style.BackColor = Color.Yellow;
                        dgvWorkingPaper.Rows[i].Cells[x + 1].Style.ForeColor = Color.Red;
                        if (chkGSC.Checked)//Color of GSC Variance
                        {
                            if (dgvWorkingPaper.Columns[GSCAudited].Index == x)
                            {
                                dgvWorkingPaper.Rows[i].Cells[x + 2].Style.ForeColor = Color.Red;
                            }
                        }
                    }
                    else
                    {
                        //dgvWorkingPaper.Rows[i].Cells[x].Style.BackColor = Color.Gray;
                    }
                    //Other NonVat
                    if (x + increment-1 < dgvWorkingPaper.Columns.Count)
                    {
                        if (dgvWorkingPaper.Columns[x + increment-1].Name == OtherNonvat)
                        {
                            dgvWorkingPaper.Rows[i].Cells[x+increment-1].Style.BackColor = Color.White;
                            if (dgvWorkingPaper.Rows[i].Cells[x +increment-1].Value.ToString() != "")
                            {
                                dgvWorkingPaper.Rows[i].Cells[x +increment-1].Style.BackColor = Color.Yellow;
                            }
                            x += 1;
                        }
                    }

                    if (dgvWorkingPaper.Columns[x].Name == GSCAudited && !chkDocTicks.Checked) { x++; } // Added 05-18-2020 for GSC Tick//Removed02262021
                }
                if (chkNV.Checked || rdbAllCol.Checked)
                {
                    //dgvWorkingPaper.Columns[NVAudited].Visible = false;
                    //dgvWorkingPaper.Columns[NVVariance].Visible = false;
                }
            }
            chkAll.Checked = true;

            //autosize columns
            for (int i = 0; i < dgvWorkingPaper.Columns.Count; i++)//
            {
                //AutoSize Columns
                dgvWorkingPaper.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //Set Alignments
                if (i <= 2 || dgvWorkingPaper.Columns[i].Name == AD || dgvWorkingPaper.Columns[i].Name == ADAudited)
                {
                    dgvWorkingPaper.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else
                {
                    dgvWorkingPaper.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                //ReadOnly ALL Cols
                dgvWorkingPaper.Columns[i].ReadOnly = true;
            }
            //remove readonlys on selected cols
            dgvWorkingPaper.Columns[0].ReadOnly = false;
            for (int i = 4; i < dgvWorkingPaper.Columns.Count; i += increment)
            {

                if (dgvWorkingPaper.Columns[i].Name != GSCAudited)
                {
                    dgvWorkingPaper.Columns[i].ReadOnly = false;
                }
                if (dgvWorkingPaper.Columns[i].Name == ADAudited) { i-=(!chkDocTicks.Checked?1:2); }
                if (dgvWorkingPaper.Columns[i].Name == GSCAudited)
                {
                    if (!chkDocTicks.Checked) //Added02262021
                        i++; //Added 05-18-2020, for GSC Ticking//
                    dgvWorkingPaper.Columns[i+1].ReadOnly = false;
                } 

                if (i +increment-1 < dgvWorkingPaper.Columns.Count)
                {//Readonly = no
                    if (dgvWorkingPaper.Columns[i + increment - 1].Name == OtherNonvat)
                    {
                        dgvWorkingPaper.Columns[i + increment - 1].ReadOnly = false;
                        i += 1;
                    }
                }
            }
            if (chkGSC.Checked)
            {
                currentCheckedDays = "";
                currentCheckedDays = getCheckedDays();
                //MessageBox.Show(currentCheckedDays);

                string[] days = currentCheckedDays.Split(',');
                //Check/Tick IF already Saved.
                //ReadOnly tickRows w/ True Value
                int indx = dgvWorkingPaper.Columns[GSCTick].Index;//GSC TICK COLUMN INDEX
                for (int i = 0; i < dgvWorkingPaper.Rows.Count; i++)
                {
                    //MessageBox.Show(indx.ToString());
                    //MessageBox.Show(Convert.ToDateTime(dgvWorkingPaper.Rows[i].Cells[indx].Value).ToString("dd"));
                    if (days.Contains(Convert.ToDateTime(dgvWorkingPaper.Rows[i].Cells[1].Value).ToString("%d")) || currentCheckedDays == "ALL" || currentCheckedDays.Contains("UPLOADED"))
                    {
                        //dgvWorkingPaper.Rows[i].Cells[indx].ReadOnly = true;
                        dgvWorkingPaper.Rows[i].Cells[indx].Value = true;
                    }
                }
            }

        }
        bool dgvWPHeaderClick = false;
        private void dgvWorkingPaper_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvWPHeaderClick = true;
            tableAdjustments();
            dgvWPHeaderClick = false;
        }
        public void reloadWPTotal()
        {
            dgvWPTotal.DataSource = null;
            DataTable dtSum = new DataTable();
            dtSum.Columns.Add("  ");
            dtSum.Columns.Add("   ");
            dtSum.Columns.Add(" ");
            if (chkSC.Checked || rdbAllCol.Checked)
            {
                dtSum.Columns.Add(ServiceCharge);
                dtSum.Columns.Add(SCAudited);
                dtSum.Columns.Add(SCVariance);
            }
            if (chkSD.Checked || rdbAllCol.Checked)
            {
                dtSum.Columns.Add(SeniorDiscount);
                dtSum.Columns.Add(SDAudited);
                dtSum.Columns.Add(SDVariance);
            }

            if (chkVE.Checked || rdbAllCol.Checked)
            {
                dtSum.Columns.Add(VATExempt);
                dtSum.Columns.Add(VEAudited);
                dtSum.Columns.Add(VEVariance);
            }

            if (chkNV.Checked || rdbAllCol.Checked)
            {
                dtSum.Columns.Add(NonVat);
                dtSum.Columns.Add(NVAudited);
                dtSum.Columns.Add(NVVariance);
            }

            if (chkONV.Checked || rdbAllCol.Checked)
            {
                dtSum.Columns.Add(OtherNonvat);
            }

            if (chkOD.Checked || rdbAllCol.Checked)
            {
                dtSum.Columns.Add(OtherDiscount);
                dtSum.Columns.Add(ODAudited);
                dtSum.Columns.Add(ODVariance);
            }

            if (chkAD.Checked || rdbAllCol.Checked)
            {
                dtSum.Columns.Add(AD, typeof(bool));
                dtSum.Columns.Add(ADAudited, typeof(bool));
            }

            if (chkGSC.Checked || rdbAllCol.Checked)
            {
                dtSum.Columns.Add(GSC);
                dtSum.Columns.Add(GSCAudited);
                //dtSum.Columns.Add(GSCTick, typeof(bool));
                dtSum.Columns.Add(GSCVariance);
            }

            if (chkCash.Checked || rdbAllCol.Checked)
            {
                dtSum.Columns.Add(Cash);
                dtSum.Columns.Add(CaAudited);
                dtSum.Columns.Add(CaVariance);
            }

            if (chkCharge.Checked || rdbAllCol.Checked)
            {
                dtSum.Columns.Add(Charge);
                dtSum.Columns.Add(ChAudited);
                dtSum.Columns.Add(ChVariance);
            }

            if (chkGC.Checked || rdbAllCol.Checked)
            {
                dtSum.Columns.Add(GCOthers);
                dtSum.Columns.Add(GCAudited);
                dtSum.Columns.Add(GCVariance);
            }

            string sql = "SELECT";
            sql += " SUM(a.surcharge) AS '" + ServiceCharge + "',";
            sql += " SUM(CASE WHEN c.surcharge IS NOT NULL THEN c.surcharge ELSE a.surcharge END) AS '" + SCAudited + "',";
            sql += " SUM(a.senior) AS '" + SeniorDiscount + "',";
            sql += " SUM(CASE WHEN c.senior IS NOT NULL THEN c.senior ELSE a.senior END) AS '" + SDAudited + "',";
            sql += " SUM(a.vat) AS '" + VATExempt + "',";
            sql += " SUM(CASE WHEN c.vat IS NOT NULL THEN c.vat ELSE a.vat END) AS '" + VEAudited + "',";
            sql += " SUM(a.nonvat) AS '" + NonVat + "',";
            sql += " SUM(CASE WHEN c.nonvat IS NOT NULL THEN c.nonvat ELSE a.nonvat END) AS '" + NVAudited + "',";
            sql += " SUM(c.OtherNonVat) AS '" + OtherNonvat + "',";
            sql += " SUM(a.other) AS '" + OtherDiscount + "',";
            sql += " SUM(CASE WHEN c.other IS NOT NULL THEN c.other ELSE a.other END) AS '" + ODAudited + "',";
            sql += " (CASE WHEN SUM(CAST(a.approved AS INT))>0 THEN 1 ELSE 0 END) AS '" + AD + "',";
            sql += " (CASE WHEN SUM(CAST(c.approved AS INT))>0  THEN 1 ELSE 0 END) AS '" + ADAudited + "',";
            sql += " SUM(a.gsc) AS '" + GSC + "',";
            sql += " SUM(CASE WHEN c.gsc IS NOT NULL THEN c.gsc ELSE a.gsc END) AS '" + GSCAudited + "',";
            //sql += "CAST(0 AS BIT) AS '.',";
            sql += " SUM(a.cash) AS '" + Cash + "',";
            sql += " SUM(CASE WHEN c.cash IS NOT NULL THEN c.cash ELSE a.cash END) AS '" + CaAudited + "',";
            sql += " SUM(a.charge) AS '" + Charge + "',";
            sql += " SUM(CASE WHEN c.charge IS NOT NULL THEN c.charge ELSE a.charge END) AS '" + ChAudited + "',";
            sql += " SUM(a.gift) AS '" + GCOthers + "',";
            sql += " SUM(CASE WHEN c.gift IS NOT NULL THEN c.gift ELSE a.gift END) AS '" + GCAudited + "'";
            sql += "  FROM ( SELECT y.tenantcode ";
            if (cmbTerminal.SelectedItem.ToString() != "ALL")
            {
                sql += " ,y.machine";
            }
            // subquery table  y is added 09302020
            //x=dailymod
            sql += " ,y.date,SUM(surcharge) AS surcharge,SUM(senior) AS senior,SUM(vat) AS vat,SUM(nonvat) AS nonvat,SUM(other) AS other, approved,SUM(gsc) AS gsc,SUM(cash) AS cash,SUM(charge) AS charge,SUM(gift) AS gift  FROM dailymod x";
            //y=tenantcode+dates
            sql += " RIGHT JOIN (SELECT @tenantcode AS [tenantcode],@terminal AS [machine], DATEADD(Day,Number,@firstDayAudit) AS [date] FROM master..spt_values WHERE Type='P' AND DATEADD(Day,Number,@firstDayAudit) <=@lastDayAudit) y";
            sql += " ON x.tenantcode=y.tenantcode AND x.date=y.date";
            if (cmbTerminal.SelectedItem.ToString() != "ALL")
            {
                sql += " AND x.machine=y.machine ";
            }
            sql += " WHERE y.date BETWEEN @firstDayAudit  AND @lastDayAudit AND y.tenantcode = @tenantcode";
            if (cmbTerminal.SelectedItem.ToString() != "ALL")
            {
                sql += " AND y.machine=@terminal ";
            }
            sql += " GROUP BY y.tenantcode,y.date,approved";
            if (cmbTerminal.SelectedItem.ToString() != "ALL")
            {
                sql += " ,y.machine";
            }
            sql += ") a ";
            sql += " LEFT JOIN (Select COUNT(machine) as 'machine', tenantcode, date from DAILYMOD WHERE date ";
            sql += " BETWEEN @firstDayAudit  AND @lastDayAudit AND tenantcode = @tenantcode GROUP BY tenantcode,date) b";
            sql += " ON a.tenantcode=b.tenantcode AND a.date=b.date";
            sql += " LEFT JOIN (SELECT * FROM AuditedTenders WHERE date BETWEEN @firstDayAudit  AND @lastDayAudit AND tenantcode = @tenantcode AND machine=@terminal)c";
            sql += " ON a.tenantcode=c.tenantcode AND a.date=c.date";
            
            sql += " GROUP BY a.tenantcode";


            DateTime startDate = Convert.ToDateTime(txtMonth.Text + " 01, " + txtYear.Text);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);
            //DateTime endDate = Convert.ToDateTime(txtMonth.Text + DateTime.DaysInMonth(Convert.ToInt32(txtYear.Text), Convert.ToInt32(startDate.ToString("MM"))));
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Clear();
            cmd.CommandTimeout = 120;
            cmd.Parameters.AddWithValue("@firstDayAudit", startDate.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@lastDayAudit", endDate.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("tenantcode", txtRPCode.Text);
            cmd.Parameters.AddWithValue("terminal", cmbTerminal.SelectedItem.ToString());
            SqlDataReader sReader = cmd.ExecuteReader();
            while (sReader.Read())
            {
                DataRow dr = dtSum.NewRow();
                dr[" "] = "Grand Total";
                if (chkSC.Checked || rdbAllCol.Checked)
                {
                    dr[ServiceCharge] = (!sReader.IsDBNull(sReader.GetOrdinal(ServiceCharge)) ? Convert.ToDouble(sReader[ServiceCharge]).ToString("#,0.00") : "");
                    dr[SCAudited] = (!sReader.IsDBNull(sReader.GetOrdinal(SCAudited)) ? Convert.ToDouble(sReader[SCAudited]).ToString("#,0.00") : "");
                    dr[SCVariance] = (!sReader.IsDBNull(sReader.GetOrdinal(SCAudited)) && !sReader.IsDBNull(sReader.GetOrdinal(ServiceCharge)) ? (Convert.ToDouble(sReader[SCAudited]) - Convert.ToDouble(sReader[ServiceCharge])).ToString("#,0.00") : "");
                }
                if (chkSD.Checked || rdbAllCol.Checked)
                {
                    dr[SeniorDiscount] = (!sReader.IsDBNull(sReader.GetOrdinal(SeniorDiscount)) ? Convert.ToDouble(sReader[SeniorDiscount]).ToString("#,0.00") : "");
                    dr[SDAudited] = (!sReader.IsDBNull(sReader.GetOrdinal(SDAudited)) ? Convert.ToDouble(sReader[SDAudited]).ToString("#,0.00") : "");
                    dr[SDVariance] = (!sReader.IsDBNull(sReader.GetOrdinal(SDAudited)) && !sReader.IsDBNull(sReader.GetOrdinal(SeniorDiscount)) ? (Convert.ToDouble(sReader[SDAudited]) - Convert.ToDouble(sReader[SeniorDiscount])).ToString("#,0.00") : "");
                }

                if (chkVE.Checked || rdbAllCol.Checked)
                {
                    dr[VATExempt] = (!sReader.IsDBNull(sReader.GetOrdinal(VATExempt)) ? Convert.ToDouble(sReader[VATExempt]).ToString("#,0.00") : "");
                    dr[VEAudited] = (!sReader.IsDBNull(sReader.GetOrdinal(VEAudited)) ? Convert.ToDouble(sReader[VEAudited]).ToString("#,0.00") : "");
                    dr[VEVariance] = (!sReader.IsDBNull(sReader.GetOrdinal(VEAudited)) && !sReader.IsDBNull(sReader.GetOrdinal(VATExempt)) ? (Convert.ToDouble(sReader[VEAudited]) - Convert.ToDouble(sReader[VATExempt])).ToString("#,0.00") : "");

                }

                if (chkNV.Checked || rdbAllCol.Checked)
                {
                    dr[NonVat] = (!sReader.IsDBNull(sReader.GetOrdinal(NonVat)) ? Convert.ToDouble(sReader[NonVat]).ToString("#,0.00") : "");
                    dr[NVAudited] = (!sReader.IsDBNull(sReader.GetOrdinal(NVAudited)) ? Convert.ToDouble(sReader[NVAudited]).ToString("#,0.00") : "");
                    dr[NVVariance] = (!sReader.IsDBNull(sReader.GetOrdinal(NVAudited)) && !sReader.IsDBNull(sReader.GetOrdinal(NonVat)) ? (Convert.ToDouble(sReader[NVAudited]) - Convert.ToDouble(sReader[NonVat])).ToString("#,0.00") : "");
                }

                if (chkONV.Checked || rdbAllCol.Checked)
                {
                    dr[OtherNonvat] = (!sReader.IsDBNull(sReader.GetOrdinal(OtherNonvat)) ? Convert.ToDouble(sReader[OtherNonvat]).ToString("#,0.00") : "");
                }

                if (chkOD.Checked || rdbAllCol.Checked)
                {
                    dr[OtherDiscount] = (!sReader.IsDBNull(sReader.GetOrdinal(OtherDiscount)) ? Convert.ToDouble(sReader[OtherDiscount]).ToString("#,0.00") : "");
                    dr[ODAudited] = (!sReader.IsDBNull(sReader.GetOrdinal(ODAudited)) ? Convert.ToDouble(sReader[ODAudited]).ToString("#,0.00") : "");
                    dr[ODVariance] = (!sReader.IsDBNull(sReader.GetOrdinal(ODAudited)) && !sReader.IsDBNull(sReader.GetOrdinal(OtherDiscount)) ? (Convert.ToDouble(sReader[ODAudited]) - Convert.ToDouble(sReader[OtherDiscount])).ToString("#,0.00") : "");
                }

                if (chkAD.Checked || rdbAllCol.Checked)
                {
                    dr[AD] = (sReader[AD]);
                    dr[ADAudited] = (sReader[ADAudited]);
                }

                if (chkGSC.Checked || rdbAllCol.Checked)
                {
                    dr[GSC] = (!sReader.IsDBNull(sReader.GetOrdinal(GSC)) ? Convert.ToDouble(sReader[GSC]).ToString("#,0.00") : "");
                    dr[GSCAudited] = (!sReader.IsDBNull(sReader.GetOrdinal(GSCAudited)) ? Convert.ToDouble(sReader[GSCAudited]).ToString("#,0.00") : "");
                    //dr[GSCTick] = (sReader[GSCTick]);
                    dr[GSCVariance] = (!sReader.IsDBNull(sReader.GetOrdinal(GSCAudited)) && !sReader.IsDBNull(sReader.GetOrdinal(GSC)) ? (Convert.ToDouble(sReader[GSCAudited]) - Convert.ToDouble(sReader[GSC])).ToString("#,0.00") : "");
                }

                if (chkCash.Checked || rdbAllCol.Checked)
                {
                    dr[Cash] = (!sReader.IsDBNull(sReader.GetOrdinal(Cash)) ? Convert.ToDouble(sReader[Cash]).ToString("#,0.00") : "");
                    dr[CaAudited] = (!sReader.IsDBNull(sReader.GetOrdinal(CaAudited)) ? Convert.ToDouble(sReader[CaAudited]).ToString("#,0.00") : "");
                    dr[CaVariance] = (!sReader.IsDBNull(sReader.GetOrdinal(CaAudited)) && !sReader.IsDBNull(sReader.GetOrdinal(Cash)) ? (Convert.ToDouble(sReader[CaAudited]) - Convert.ToDouble(sReader[Cash])).ToString("#,0.00") : "");
                }

                if (chkCharge.Checked || rdbAllCol.Checked)
                {
                    dr[Charge] = (!sReader.IsDBNull(sReader.GetOrdinal(Charge)) ? Convert.ToDouble(sReader[Charge]).ToString("#,0.00") : "");
                    dr[ChAudited] = (!sReader.IsDBNull(sReader.GetOrdinal(ChAudited)) ? Convert.ToDouble(sReader[ChAudited]).ToString("#,0.00") : "");
                    dr[ChVariance] = (!sReader.IsDBNull(sReader.GetOrdinal(ChAudited)) && !sReader.IsDBNull(sReader.GetOrdinal(Charge)) ? (Convert.ToDouble(sReader[ChAudited]) - Convert.ToDouble(sReader[Charge])).ToString("#,0.00") : "");
                }
                if (chkGC.Checked || rdbAllCol.Checked)
                {
                    dr[GCOthers] = (!sReader.IsDBNull(sReader.GetOrdinal(GCOthers)) ? Convert.ToDouble(sReader[GCOthers]).ToString("#,0.00") : "");
                    dr[GCAudited] = (!sReader.IsDBNull(sReader.GetOrdinal(GCAudited)) ? Convert.ToDouble(sReader[GCAudited]).ToString("#,0.00") : "");
                    dr[GCVariance] = (!sReader.IsDBNull(sReader.GetOrdinal(GCAudited)) && !sReader.IsDBNull(sReader.GetOrdinal(GCOthers)) ? (Convert.ToDouble(sReader[GCAudited]) - Convert.ToDouble(sReader[GCOthers])).ToString("#,0.00") : "");
                }
                dtSum.Rows.Add(dr);
            }
            dgvWPTotal.DataSource = dtSum;
            for (int i = 0; i < dgvWPTotal.Columns.Count; i++)//i=4, first audited column
            {
                dgvWPTotal.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                if (i > 2)
                {
                    dgvWPTotal.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                else
                {
                    dgvWPTotal.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                dgvWPTotal.Columns[i].ReadOnly = true;
            }
            con.Close();

            if (chkNV.Checked || rdbAllCol.Checked)
            {
                dgvWPTotal.Columns[NVAudited].Visible = false;
                dgvWPTotal.Columns[NVVariance].Visible = false;
            }
        }
        private void btnReloadTable_Click(object sender, EventArgs e)
        {
            reloadTable();
        }

        private void rdbSelectedCol_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbSelectedCol.Checked != true)
            {
                gbxCols.Enabled = false;
                reloadTable();
            }
            else
            {
                gbxCols.Enabled = true;
            }
        }
        string lastTerminal = "";
        private void cmbTerminal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!tableIsLoading)
            {
                //MessageBox.Show(lastTerminal);
                updateCheckAudited(lastTerminal);
                SaveSupportingDocs();
                reloadTable();
                lastTerminal = cmbTerminal.SelectedItem.ToString();
                //MessageBox.Show(lastTerminal);
            }
        }
        //What For? Infinite loop Cell Value Changed
        //Cause, Gridview autocomputes variance(Another Cell Change causes infinite loop)
        //to Prevent, compare current row and column from previous last row and column
        //int lastrow=-1;
        //int lastcol=-1;
        //Gago, wla na kwenta ngayon 03-11-2020^^^^^^^
        //Last Value in case input error
        string lastValue = "";
        private void dgvWorkingPaper_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int row = 0;
            int col = 0;
            if (!tableIsLoading && !undoRedo && !misclassBreakdown)//When Table is Loading, and not triggered by undoRedo
            {

                row = dgvWorkingPaper.CurrentCell.RowIndex;
                col = dgvWorkingPaper.CurrentCell.ColumnIndex;

                if(dgvWorkingPaper.Columns[col].Name.Contains("Docs")){

                }
                else if (dgvWorkingPaper.Rows[row].Cells[col].Value.ToString() == "null")
                {
                    cellsChanged(row, col);
                }
                else
                {
                    //cellsChanged(row, col);
                    try
                    {
                        Convert.ToDouble(dgvWorkingPaper.Rows[row].Cells[col].Value);
                        cellsChanged(row, col);
                    }
                    catch (Exception er)
                    {
                        dgvWorkingPaper.Rows[row].Cells[col].Value = lastValue;
                        MessageBox.Show("Error" + er.Message);
                    }
                }
            }



        }
        public void cellsChanged(int row, int col)
        {
            if (!tableIsLoading)//(lastrow!=row && lastcol!=col)// no need na lastrow and lastcol
            {
                string colName = dgvWorkingPaper.Columns[col].Name;
                if (colName == GSCTick)
                {
                    tableIsLoading = true;
                   // dgvWorkingPaper.Rows[row].Cells[col].Value = true;
                    //dgvWorkingPaper.Rows[row].ReadOnly = true;
                    tableIsLoading = false;
                }else if(colName.Contains("Doc")){
                    colName.Contains("Doc");
                }
                else
                {
                    tableIsLoading = true;
                    string sql1 = "SELECT COUNT(*) AS [count] FROM AuditedTenders WHERE tenantcode=@rpcode AND date=@date";
                    sql1 += " AND machine=@terminal";
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand(sql1, con);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("rpcode", txtRPCode.Text);
                    cmd.Parameters.AddWithValue("date", dgvWorkingPaper.Rows[row].Cells[1].Value.ToString());
                    cmd.Parameters.AddWithValue("terminal", cmbTerminal.SelectedItem.ToString());
                    //MessageBox.Show(DateTime.Now.ToString("MM-dd-yyyy H:i:s"));
                    string sql = "";
                    string column = "";
                    //update table column
                    if (colName == SCAudited)
                    {
                        column = "surcharge";
                    }

                    else if (colName == SDAudited)
                    {
                        column = "senior";
                    }

                    else if (colName == VEAudited)
                    {
                        column = "vat";
                    }

                    else if (colName == NVAudited)
                    {
                        column = "nonvat";
                    }
                    else if (colName == OtherNonvat)
                    {
                        column = "OtherNonVat"; 
                    }

                    else if (colName == ODAudited)
                    {
                        column = "other";
                    }

                    //else if(colName==GSCAudited     ){}

                    else if (colName == CaAudited)
                    {
                        column = "cash";
                    }

                    else if (colName == ChAudited)
                    {
                        column = "charge";
                    }

                    else if (colName == GCAudited)
                    {
                        column = "gift";
                    }
                    else if (colName == ADAudited)
                    {
                        column = "approved";
                    }
                    else
                    {
                        column = "";
                        colName = "";
                    }
                    bool isValueEqualRaw = false;
                    if (column != "approved" && column != "vat")
                    {
                        try
                        {
                            //MessageBox.Show("ColumnIsNotEmpty");
                            if (column != "" && Convert.ToDouble(dgvWorkingPaper.Rows[row].Cells[col].Value) == Convert.ToDouble(dgvWorkingPaper.Rows[row].Cells[col - 1].Value))
                            {
                                isValueEqualRaw = true;
                                MessageBox.Show("Raw Value is equal to the amount inputted, Data will not be saved!");
                                dgvWorkingPaper.Rows[row].Cells[col].Value = lastValue;
                            }
                        }
                        catch (Exception)
                        {

                        }
                    }

                    if ((int)cmd.ExecuteScalar() == 0 && !isValueEqualRaw) // Check if it has Entry
                    //Insert Entry if no data yet
                    {                                                                     //gross gsc gscvar nvatn nvatvar senior seniorVar othr othrVar appr vat vatVar ovat schj schjVar net cash cashVar charg chargVar gc    gcVar create  modify
                        sql1 = "INSERT INTO AuditedTenders VALUES(@tenantcode,@terminal,@date,null,null,null,null, null,    null,  null,     null, null,  null,null,null, null, null,null,   null,null ,null  ,null  ,null  ,null ,null , @today,null)";
                        cmd = new SqlCommand(sql1, con);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("tenantcode", txtRPCode.Text);
                        cmd.Parameters.AddWithValue("date", dgvWorkingPaper.Rows[row].Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("terminal", cmbTerminal.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("today", DateTime.Now.ToString("MM-dd-yyyy H:mm:s"));
                        cmd.ExecuteNonQuery();
                    }
                    if (column != "" && !isValueEqualRaw)
                    {
                        //dgvWorkingPaper.Rows[row].Cells[]
                        //Compute Variance
                        string value = "0";
                        if (dgvWorkingPaper.Rows[row].Cells[col].Value.ToString() == "null")
                        {
                            value = "null";
                        }
                        else if (dgvWorkingPaper.Rows[row].Cells[col].Value.ToString() != "")
                        {
                            value = Convert.ToDouble(dgvWorkingPaper.Rows[row].Cells[col].Value).ToString("#0.00");
                        }

                        string rawValue = "0";

                        if (dgvWorkingPaper.Rows[row].Cells[col - 1].Value.ToString() != "" && colName!= OtherNonvat)
                        {
                            rawValue = (Convert.ToDouble(dgvWorkingPaper.Rows[row].Cells[col - 1].Value)).ToString("#0.00");
                        }

                        sql = "UPDATE AuditedTenders SET " + column + "=" + value;
                        string variance = "";
                        if (colName != ADAudited && colName != OtherNonvat)//update Variance if not Approve Discount or OTherNonvat
                        {
                            if (value == "null")
                            {
                                variance = "null";
                            }
                            else
                            {
                                variance = ((Convert.ToDouble(value) - Convert.ToDouble(rawValue)).ToString("#0.00")).ToString();
                                //MessageBox.Show(variance);
                            }
                            sql += "," + column + "Var" + "=" + variance;
                        }
                        sql += ",dateModified=@dateModify WHERE tenantcode=@rpcode AND date=@date AND machine=@terminal";
                        //MessageBox.Show(sql);
                        //try {
                        //Update database (column value)
                        cmd = new SqlCommand(sql, con);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("rpcode", txtRPCode.Text);
                        cmd.Parameters.AddWithValue("date", dgvWorkingPaper.Rows[row].Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("terminal", cmbTerminal.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("dateModify", DateTime.Now.ToString("MM-dd-yyyy H:mm:s"));
                        cmd.ExecuteNonQuery();
                        if (colName == ADAudited || colName == OtherNonvat)//AD and OtherNonvat ~ no Variance Columns
                        {
                            dgvWorkingPaper.Rows[row].Cells[col].Style.BackColor = Color.Yellow;
                        }
                        else
                        {
                            if (value == "null")
                            {
                                dgvWorkingPaper.Rows[row].Cells[col].Value = "";
                                dgvWorkingPaper.Rows[row].Cells[col + 1].Value = "";
                                dgvWorkingPaper.Rows[row].Cells[col + 1].Style.ForeColor = Color.Black;
                                dgvWorkingPaper.Rows[row].Cells[col].Style.BackColor = Color.White;
                            }
                            else
                            {
                                dgvWorkingPaper.Rows[row].Cells[col + 1].Value = (Convert.ToDouble(value) - Convert.ToDouble(rawValue)).ToString("#,0.00");
                                dgvWorkingPaper.Rows[row].Cells[col + 1].Style.ForeColor = Color.Red;
                                dgvWorkingPaper.Rows[row].Cells[col].Style.BackColor = Color.Yellow;
                            }
                        }
                        //
                        //update Database GSC+Variance if cash/charge/gc/otherdisc/surcharge is updated
                        if (colName == CaAudited || colName == ChAudited || colName == GCAudited || colName == ODAudited || colName == ADAudited || colName == SCAudited)
                        {
                            updateGSC(txtRPCode.Text, dgvWorkingPaper.Rows[row].Cells[1].Value.ToString(), row);//RPcode and Date
                        }
                        if (colName == SDAudited)
                        {
                            updateVes(txtRPCode.Text, dgvWorkingPaper.Rows[row].Cells[1].Value.ToString(), value, row,rawValue);
                        }

                        //}
                        //catch (Exception er)
                        //{
                        //    MessageBox.Show("Error: " + er.Message);
                        //}
                        //RPSMS Components
                        if ((chkEnableAFBreakdown.Checked) && (colName == CaAudited || colName == ChAudited || colName == GCAudited || colName == SDAudited || colName == ODAudited || colName == SCAudited))
                        {
                            if (variance == "null")
                            {
                                variance = "0.00";
                            }
                            if (!misclassBreakdown)
                            {
                                string component = dgvWorkingPaper.Columns[col - 1].Name;
                                openVarianceBreakdown(variance, component, dgvWorkingPaper.Rows[row].Cells[1].Value.ToString(), row);
                            }
                        }
                        //For Undo/Redo 08-06-2020
                        addAction(row, col, lastValue, value);

                        tableIsLoading = false;
                        reloadWPTotal();
                    }
                    con.Close();
                    tableIsLoading = false;
                }
            }
        }
        void updateVes(string rp,string date,string value,int row,string rawVES)
        {
            string vesValue = value;
            if (value != "null")
            {
                 vesValue = (Convert.ToDouble(value) * .8 / .2).ToString();
            }
            string vesVariance = vesValue;
            if (vesValue != "null")
            {
                vesVariance = (Convert.ToDouble(vesValue) - Convert.ToDouble(rawVES)*4 ).ToString();
            }
            string sql = "UPDATE AuditedTenders SET VAT=" + vesValue + ", vatVar=" + vesVariance + " WHERE tenantcode=@rp AND date=@date AND machine=@terminal";
            SqlConnection con3 = new SqlConnection(localConnectionString);
            con3.Open();
            SqlCommand cmd = new SqlCommand(sql, con3);
            cmd.Parameters.AddWithValue("rp", rp);
            cmd.Parameters.AddWithValue("date", date);
            cmd.Parameters.AddWithValue("terminal", cmbTerminal.SelectedItem.ToString());
            //cmd.Parameters.AddWithValue("ves", vesValue);
            //cmd.Parameters.AddWithValue("vesVar", vesVariance);
            cmd.ExecuteNonQuery();
            con3.Close();
            if (chkVE.Checked)
            {
                if (vesVariance != "null")
                {
                    vesValue=Convert.ToDouble(vesValue).ToString("#,0.00");
                    vesVariance = Convert.ToDouble(vesVariance).ToString("#,0.00");
                    dgvWorkingPaper.Rows[row].Cells[dgvWorkingPaper.Columns[VEAudited].Index].Value = vesValue;
                    dgvWorkingPaper.Rows[row].Cells[dgvWorkingPaper.Columns[VEAudited].Index + 1].Value = vesVariance;
                    dgvWorkingPaper.Rows[row].Cells[dgvWorkingPaper.Columns[VEAudited].Index].Style.BackColor = Color.Yellow;
                    dgvWorkingPaper.Rows[row].Cells[dgvWorkingPaper.Columns[VEAudited].Index + 1].Style.ForeColor = Color.Red;
                }
                else
                {
                    dgvWorkingPaper.Rows[row].Cells[dgvWorkingPaper.Columns[VEAudited].Index].Value = "";
                    dgvWorkingPaper.Rows[row].Cells[dgvWorkingPaper.Columns[VEAudited].Index + 1].Value = "";
                    dgvWorkingPaper.Rows[row].Cells[dgvWorkingPaper.Columns[VEAudited].Index].Style.BackColor = Color.White;
                    dgvWorkingPaper.Rows[row].Cells[dgvWorkingPaper.Columns[VEAudited].Index + 1].Style.ForeColor = Color.Red;
                }
            }
        }
        //Arrays for Actions, These will be reset when the table is reloaded.
        int[] actionsRow = new int[100];
        int[] actionsCol = new int[100];
        string[] undoValues = new string[100];
        string[] redoValues = new string[100];
        int actionIndex = 0;
        int actionSize = 0;
        string[] undoTP = new string[100];
        string[] redoTP = new string[100];
        string[] undoMisclass = new string[100];
        string[] redoMisclass = new string[100];
        string[] undoMisclassTo = new string[100];
        string[] redoMisclassTo = new string[100];
        string[] undoOtherF = new string[100];
        string[] redoOtherF = new string[100];
        string[] undoUnreported = new string[100];
        string[] redoUnreported = new string[100];
        public void addAction(int row, int col, string lastValue, string newValue)
        {
            if (!undoRedo)
            {
                //MessageBox.Show(value);
                actionsCol[actionIndex] = col;
                actionsRow[actionIndex] = row;
                undoValues[actionIndex] = lastValue;
                redoValues[actionIndex] = newValue;
                actionIndex++;
                actionSize = actionIndex;
                btnRedo.Enabled = false;
                if (actionIndex <= 0)
                {
                    btnUndo.Enabled = false;
                }
                else
                {
                    btnUndo.Enabled = true;
                }
            }
        }
        public static bool saveBreakdown;
        public static bool misclassBreakdown = false;
        public static int misclassComponentTo;
        public static double[] misclassValue;
        SqlConnection con2;
        public void openVarianceBreakdown(string variance, string component, string date, int row)
        {
            saveBreakdown = true;//will be modified/handled in varianceBreakdown form
            VarianceBreakdown vb = new VarianceBreakdown();
            VarianceBreakdown.rpcode = txtRPCode.Text;
            VarianceBreakdown.terminal = cmbTerminal.SelectedItem.ToString();
            vb.txtVariance.Text = variance;
            vb.lblDate.Text = date;
            vb.lblComponent.Text = (component.Substring(0, 1)).ToUpper() + component.Substring(1);
            //MessageBox.Show(undoTP[actionIndex]);
            //Set Values if triggered by undo/redo button //Added 10-13-2020
            if (undo)
            {
                vb.undo = undo;
                vb.txtTxtProb.Text = undoTP[actionIndex];
                vb.txtMisclass.Text = undoMisclass[actionIndex];
                vb.txtUnrep.Text = undoUnreported[actionIndex];
                vb.txtOtherFind.Text = undoOtherF[actionIndex];
            }
            else if (redo)
            {
                vb.redo = redo;
                vb.txtTxtProb.Text = redoTP[actionIndex];
                vb.txtMisclass.Text = redoMisclass[actionIndex];
                vb.txtUnrep.Text = redoUnreported[actionIndex];
                vb.txtOtherFind.Text = redoOtherF[actionIndex];
            }
            vb.StartPosition = FormStartPosition.CenterParent;
            vb.ShowDialog();

            //get Values for Undo/Redo //Added 10-13-2020
            undoTP[actionIndex] = vb.oldTP;
            redoTP[actionIndex] = vb.newTP;

            if (!saveBreakdown)
            {
                chkEnableAFBreakdown.Checked = false;
                MessageBox.Show("Data is saved, but inputting of Variance Breakdown is Cancelled.");
            }
            //misclassBreakdown = false;
            if (misclassBreakdown)//there's auto-misclassified in openVarianceBreakdown
            {
                string colName = "";
                string rawColName = "";
                string dbCol = "";
                bool updateDGV = false;
                for (int i = 0; i < misclassValue.Length; i++)
                {
                    //MessageBox.Show("Transfer #: " + i.ToString());
                    //misclassValue[i] = misclassValue[i] * (-1);
                    misclassComponentTo = i + 1;
                    switch (misclassComponentTo)
                    {
                        case 1: colName = CaAudited;
                            rawColName = Cash;
                            dbCol = "cash";
                            updateDGV = chkCash.Checked;
                            break;
                        case 2: colName = ChAudited;
                            rawColName = Charge;
                            dbCol = "charge";
                            updateDGV = chkCharge.Checked;
                            break;
                        case 3: colName = GCAudited;
                            rawColName = GCOthers;
                            dbCol = "gift";
                            updateDGV = chkGC.Checked;
                            break;
                        case 4: colName = SDAudited;
                            rawColName = SeniorDiscount;
                            dbCol = "senior";
                            updateDGV = chkSD.Checked;
                            break;
                        case 5: colName = ODAudited;
                            rawColName = OtherDiscount;
                            dbCol = "other";
                            updateDGV = chkOD.Checked;
                            break;
                        case 6: colName = SCAudited;
                            rawColName = ServiceCharge;
                            dbCol = "surcharge";
                            updateDGV = chkSC.Checked;
                            break;
                    }
                    con2 = new SqlConnection(localConnectionString);
                    con2.Open();
                    string sqlRaw = "SELECT CASE WHEN a." + dbCol + " IS NULL AND c." + dbCol + " IS NULL then 0.00  WHEN c." + dbCol + " IS NULL THEN  SUM(a." + dbCol + ") ELSE c." + dbCol + " END AS [" + dbCol + "], CASE WHEN [" + dbCol + "Var] IS NULL THEN 0.00 ELSE [" + dbCol + "Var] END AS  [" + dbCol + "Var] ";
                    sqlRaw += " FROM (SELECT tenantcode";
                    if (cmbTerminal.SelectedItem.ToString() != "ALL")
                    {
                        sqlRaw += ",machine";
                    }
                    sqlRaw+=" ,date,SUM(" + dbCol + ") AS [" + dbCol + "] FROM dailymod GROUP BY tenantcode,date";
                    if (cmbTerminal.SelectedItem.ToString() != "ALL")
                    {
                        sqlRaw += ",machine";
                    }
                    sqlRaw+=") a ";
                    sqlRaw += " RIGHT JOIN (SELECT @date as [date], @rp as[tenantcode] ";
                    if (cmbTerminal.SelectedItem.ToString() != "ALL")
                    {
                        sqlRaw += ", @terminal AS [machine]";
                    }
                    sqlRaw += ") b ON a.date=b.date AND a.tenantcode=b.tenantcode ";
                    if (cmbTerminal.SelectedItem.ToString() != "ALL")
                    {
                        sqlRaw += " AND a.machine=b.machine";
                    }
                    //Table2
                    sqlRaw += " LEFT JOIN AuditedTenders c ON c.date=b.date AND c.tenantcode=b.tenantcode  ";
                    if (cmbTerminal.SelectedItem.ToString() != "ALL")
                    {
                        sqlRaw += " AND c.machine=b.machine";
                    }
                    //WHERE
                    sqlRaw += " WHERE b.tenantcode=@rp AND b.date=@date";
                    if (cmbTerminal.SelectedItem.ToString() != "ALL")
                    {
                        sqlRaw += " AND b.machine=@terminal";
                    }
                    sqlRaw+=" GROUP BY b.tenantcode,a." + dbCol + ",c." + dbCol + ",c." + dbCol + "Var";
                    SqlCommand cmdRaw = new SqlCommand(sqlRaw, con2);
                    cmdRaw.Parameters.AddWithValue("rp", txtRPCode.Text);
                    cmdRaw.Parameters.AddWithValue("date", date);
                    cmdRaw.Parameters.AddWithValue("terminal", cmbTerminal.SelectedItem.ToString());
                    SqlDataReader sread = cmdRaw.ExecuteReader();
                    string dbValue = "0.00";
                    string dbVar = "0.00";
                    while (sread.Read())
                    {
                        dbValue = sread[0].ToString();
                        dbVar = sread[1].ToString();
                    }
                    sread.Close();
                    //MessageBox.Show(dbValue + " " + dbVar);
                    double componentValue = 0.00;//new Value
                    componentValue = Convert.ToDouble(dbValue) +misclassValue[i];//.ToString("#,0.00");
                    if (componentValue != Convert.ToDouble(dbValue)) //Only update tenders when value is different from raw
                    {//UPDATE BACKEND Audited Tenders
                    //MessageBox.Show(componentValue.ToString()+" vs. "+dbValue );
                        string sqlCount = "SELECT COUNT(*) FROM AuditedTenders WHERE tenantcode=@rp AND date=@date";
                        if (cmbTerminal.SelectedItem.ToString() != "ALL")
                        {
                            sqlCount += " AND machine=@terminal";
                        }
                        SqlCommand cmdCount = new SqlCommand(sqlCount, con2);
                        cmdCount.Parameters.AddWithValue("rp", txtRPCode.Text);
                        cmdCount.Parameters.AddWithValue("date", date);
                        cmdCount.Parameters.AddWithValue("terminal", cmbTerminal.SelectedItem.ToString());
                        if ((int)cmdCount.ExecuteScalar() > 0)
                        {
                            //Update
                            string sql = "UPDATE AuditedTenders SET " + dbCol + "=@newValue," + dbCol + "Var=@newVar WHERE tenantcode=@rp AND date=@date  AND machine=@terminal";
                            SqlCommand cmd = new SqlCommand(sql, con2);
                            cmd.Parameters.AddWithValue("rp", txtRPCode.Text);
                            cmd.Parameters.AddWithValue("date", date);
                            cmd.Parameters.AddWithValue("terminal", cmbTerminal.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("newValue", componentValue);
                            cmd.Parameters.AddWithValue("newVar", misclassValue[i]);
                            cmd.ExecuteNonQuery();
                        }
                        else//Insert
                        {
                            string sql = "INSERT INTO AuditedTenders(tenantcode,date,terminal," + dbCol + "," + dbCol + "Var) VALUES(@rp,@date,@terminal,@newValue,@newVar)";
                            SqlCommand cmd = new SqlCommand(sql, con2);
                            cmd.Parameters.AddWithValue("rp", txtRPCode.Text);
                            cmd.Parameters.AddWithValue("date", date);
                            cmd.Parameters.AddWithValue("terminal", cmbTerminal.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("newValue", componentValue);
                            cmd.Parameters.AddWithValue("newVar", misclassValue[i]);
                            cmd.ExecuteNonQuery();
                        }
                        con2.Close();
                        //ADD/Update Audited Value DGV

                        if (dbVar != "0.00")
                        {
                            //misclassValue = (Convert.ToDouble(dbVar) + Convert.ToDouble(misclassValue)).ToString();
                        }
                        //Compute the new Audited Value, negating the sign of the misclassifiedValue

                        //Update GSC
                        if (updateDGV)
                        {
                            dgvWorkingPaper.Rows[row].Cells[dgvWorkingPaper.Columns[colName].Index].Value = Convert.ToDouble(componentValue).ToString("#,0.00");
                            dgvWorkingPaper.Rows[row].Cells[dgvWorkingPaper.Columns[colName].Index].Style.BackColor = Color.Yellow;
                            dgvWorkingPaper.Rows[row].Cells[dgvWorkingPaper.Columns[colName].Index + 1].Value = (misclassValue[i]).ToString("#,0.00"); ;
                            dgvWorkingPaper.Rows[row].Cells[dgvWorkingPaper.Columns[colName].Index + 1].Style.ForeColor = Color.Red;
                        }
                        if (colName != SDAudited)
                        {
                            updateGSC(txtRPCode.Text, date, row);
                        }
                    }

                }
                misclassBreakdown = false;
            }
        }
        public void updateGSC(string rpcode, string selectedDate, int row)
        {
            //GET Tenders (Audited or RAW, whichever is available)
            string sql = "SELECT ";
            sql += "  CASE WHEN b.cash IS NULL AND c.cash IS NULL THEN 0 ";
            sql += " 		WHEN c.cash IS NULL then sum(b.cash)";
            sql += " 		ELSE c.cash END AS cash,";
            sql += "  CASE WHEN b.charge IS NULL AND c.charge IS NULL THEN 0 ";
            sql += " 		WHEN c.charge IS NULL then sum(b.charge)";
            sql += " 		ELSE c.charge END AS charge,";
            sql += "  CASE WHEN b.gift IS NULL AND c.gift IS NULL THEN 0 ";
            sql += " 		WHEN c.gift IS NULL then sum(b.gift) ";
            sql += " 		ELSE c.gift END AS gift,";
            sql += "  CASE WHEN b.other IS NULL AND c.other IS NULL THEN 0 ";
            sql += " 		WHEN c.other IS NULL then sum(b.other) ";
            sql += " 		ELSE c.other END AS other,";
            sql += "  CASE WHEN b.surcharge IS NULL AND c.surcharge IS NULL THEN 0 ";
            sql += " 		WHEN c.surcharge IS NULL  then sum(b.surcharge)";
            sql += " 		ELSE c.surcharge END AS surcharge,";
            sql += "  CASE WHEN b.approved IS NULL AND c.approved IS NULL THEN 0 ";
            sql += " 		WHEN c.approved IS NULL then b.approved ";
            sql += " 		ELSE  c.approved END AS approved ";
            sql += "   FROM";
            sql += "  (SELECT @date AS date,@rp AS tenantcode";

            if (cmbTerminal.SelectedItem.ToString() != "ALL")
            {
                sql += "  ,@terminal AS [machine]";
            }
            sql += "  ) a";

            sql += "  LEFT JOIN (SELECT tenantcode,date,SUM(cash) as [cash],SUM(charge) as [charge],SUM(gift) as [gift],SUM(other) as [other],SUM(surcharge) as [surcharge], CASE WHEN SUM(CAST(approved AS INT))>0 THEN 1 ELSE 0 END as approved ";
            if (cmbTerminal.SelectedItem.ToString() != "ALL")
            {
                sql += " ,machine";
            }
            
            sql += "  FROM dailymod WHERE tenantcode =@rp AND date= @date";
            if (cmbTerminal.SelectedItem.ToString() != "ALL")
            {
                sql += " AND machine=@terminal";
            }
            sql += "  GROUP BY tenantcode,date";
            if (cmbTerminal.SelectedItem.ToString() != "ALL")
            {
                sql += ",machine";
            }
            sql += ") b";
            sql += "  ON a.tenantcode=b.tenantcode";
            sql += " AND a.date=b.date";

            if (cmbTerminal.SelectedItem.ToString() != "ALL")
            {
                sql += " AND a.machine=b.machine";
            }
            sql += " LEFT JOIN AuditedTenders c";
            sql += " ON a.tenantcode=c.tenantcode";
            sql += " AND a.date=c.date";

            if (cmbTerminal.SelectedItem.ToString() != "ALL")
            {
                sql += " AND a.machine=c.machine";
            }

            sql += " GROUP BY";
            sql += " b.cash,c.cash,b.charge,c.charge,b.gift,c.gift,b.other,c.other,";
            sql += " b.surcharge,c.surcharge,b.approved,c.approved";
            SqlConnection gsccon = new SqlConnection(localConnectionString);
            gsccon.Open();
            SqlCommand cmd = new SqlCommand(sql, gsccon);
            cmd.Parameters.AddWithValue("rp", rpcode);
            cmd.Parameters.AddWithValue("date", selectedDate);
            cmd.Parameters.AddWithValue("terminal", cmbTerminal.SelectedItem.ToString());
            SqlDataReader sRead = cmd.ExecuteReader();
            double cash = 0;
            double charge = 0;
            double gift = 0;
            double other = 0;
            double surcharge = 0;
            bool approved = false;
            while (sRead.Read())
            {
                cash = Convert.ToDouble(sRead["cash"]);
                charge = Convert.ToDouble(sRead["charge"]);
                gift = Convert.ToDouble(sRead["gift"]);
                other = Convert.ToDouble(sRead["other"]);
                surcharge = Convert.ToDouble(sRead["surcharge"]);
                approved = Convert.ToBoolean(sRead["approved"]);
            }
            sRead.Close();
            //Compute GSC
            //MessageBox.Show("Cash:" + cash.ToString() + "charge:" + charge.ToString() + "gift:" + gift.ToString() + "other:" + other.ToString() + "surcharge:" + surcharge.ToString() + "approved:" + approved.ToString());
            double newGSC = cash + charge + gift - surcharge;
            if (!approved)
            {
                newGSC += other;
            }
            //MessageBox.Show(newGSC.ToString());
            sql = "SELECT CASE WHEN SUM(gsc) IS NULL THEN 0 ELSE SUM(gsc) END AS 'gsc' FROM dailymod WHERE tenantcode=@rp AND date=@date";
            if (cmbTerminal.SelectedItem.ToString() != "ALL")
            {
                sql += " AND machine=@terminal";
            }
            cmd = new SqlCommand(sql, gsccon);
            cmd.Parameters.AddWithValue("rp", rpcode);
            cmd.Parameters.AddWithValue("date", selectedDate);
            if (cmbTerminal.SelectedItem.ToString() != "ALL")
            {
                cmd.Parameters.AddWithValue("terminal", cmbTerminal.SelectedItem.ToString());
            }
            sRead = cmd.ExecuteReader();
            double rawGSC = 0;
            while (sRead.Read())
            {
                rawGSC = Convert.ToDouble(sRead[0]);
            }
            //Compute Variance
            sRead.Close();
            double gscVariance = newGSC - rawGSC;
            //Update Database Table
            sql = "UPDATE AuditedTenders SET gsc=@gsc, gscVar=@variance WHERE tenantcode=@rp AND date=@date AND machine=@terminal";
            cmd = new SqlCommand(sql, gsccon);
            cmd.Parameters.AddWithValue("gsc", newGSC);
            cmd.Parameters.AddWithValue("variance", gscVariance);
            cmd.Parameters.AddWithValue("rp", rpcode);
            cmd.Parameters.AddWithValue("date", selectedDate);
            cmd.Parameters.AddWithValue("terminal", cmbTerminal.SelectedItem.ToString());
            cmd.ExecuteNonQuery();
            gsccon.Close();


            if (chkGSC.Checked)//update Gridview GSC Column/Variance
            {

                dgvWorkingPaper.Rows[row].Cells[dgvWorkingPaper.Columns[GSCAudited].Index].Value = newGSC.ToString("#,0.00");
                dgvWorkingPaper.Rows[row].Cells[dgvWorkingPaper.Columns[GSCAudited].Index].Style.BackColor = Color.Yellow;
                dgvWorkingPaper.Rows[row].Cells[dgvWorkingPaper.Columns[GSCVariance].Index].Value = gscVariance.ToString("#,0.00");
                dgvWorkingPaper.Rows[row].Cells[dgvWorkingPaper.Columns[GSCVariance].Index].Style.ForeColor = Color.Red;
            }

        }
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            tableIsLoading = true;
            if (chkAll.Checked == true)
            {
                for (int i = 0; i < dgvWorkingPaper.Rows.Count; i++)
                {
                    dgvWorkingPaper.Rows[i].Cells[0].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < dgvWorkingPaper.Rows.Count; i++)
                {
                    dgvWorkingPaper.Rows[i].Cells[0].Value = false;
                }
            }
            tableIsLoading = false;
        }

        private void dgvWorkingPaper_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!tableIsLoading)
            {
                int row = dgvWorkingPaper.CurrentCell.RowIndex;
                int col = dgvWorkingPaper.CurrentCell.ColumnIndex;
                lastValue = dgvWorkingPaper.Rows[row].Cells[col].Value.ToString();
                //MessageBox.Show(lastValue);
            }
        }

        private void dgvWorkingPaper_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (!tableIsLoading)
            {
                dgvWorkingPaper.BeginEdit(true);
            }
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            if (dgvWorkingPaper.CurrentCell != null)
            {
                int row = dgvWorkingPaper.CurrentCell.RowIndex;
                DialogResult dialogResult = MessageBox.Show("Delete Row of " + dgvWorkingPaper.Rows[row].Cells[1].Value.ToString() + " And Terminal: " + cmbTerminal.SelectedItem.ToString(), "Some Title", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string selectedDate = dgvWorkingPaper.Rows[row].Cells[1].Value.ToString();
                    string selectedTerminal = cmbTerminal.SelectedItem.ToString();
                    string rpcode = txtRPCode.Text.ToString();
                    con.Open();
                    string sql = "DELETE FROM AuditedTenders WHERE tenantcode=@rpcode AND date=@date AND machine=@terminal";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("rpcode", rpcode);
                    cmd.Parameters.AddWithValue("date", selectedDate);
                    cmd.Parameters.AddWithValue("terminal", selectedTerminal);
                    cmd.ExecuteNonQuery();
                    string sql2 = "DELETE FROM VarianceBreakdown WHERE tenantcode=@rpcode AND date=@date AND machine=@terminal";
                    SqlCommand cmd2 = new SqlCommand(sql2, con);
                    cmd2.Parameters.Clear();
                    cmd2.Parameters.AddWithValue("rpcode", rpcode);
                    cmd2.Parameters.AddWithValue("date", selectedDate);
                    cmd2.Parameters.AddWithValue("terminal", selectedTerminal);
                    cmd2.ExecuteNonQuery();
                    con.Close();
                    reloadTable();
                }

            }
        }
        //FindingsSupportingDocs
        public static bool fMSR;
        public static bool fReading;
        public static bool fCashDep;
        public static bool fChargeDep;
        private void btnFindings_Click(object sender, EventArgs e)
        {
            SaveSupportingDocs();
            fMSR = false;
            fReading = false;
            fCashDep = false;
            fChargeDep = false;
            AuditFindings auditFindings = new AuditFindings();
            AuditFindings.month = txtMonth.Text;
            AuditFindings.year = txtYear.Text;
            AuditFindings.rp = txtRPCode.Text;
            AuditFindings.terminal = cmbTerminal.SelectedItem.ToString();
            AuditFindings.hide = false;
            auditFindings.StartPosition = FormStartPosition.CenterParent;
            auditFindings.ShowDialog();
            //if (fMSR)
            //{
            //    chkMSR.Checked = true;
            //}
            //if (fReading)
            //{
            //    chkReadings.Checked = true;
            //}
            //if (fCashDep)
            //{
            //    chkDeposits.Checked = true;
            //}
            //if (fChargeDep)
            //{
            //    chkOtherDocs.Checked = true;
            //}
        }

        private void EditWorkingPaper_Shown(object sender, EventArgs e)
        {

        }

        private void EditWorkingPaper_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dgvWorkingPaper.Rows.Count > 0)
            {
                deleteAuditedTendersAllNulls();
                bool check1 = checkFindingsVsBreakdownAmount(">");
                bool check2 = false;
                if (check1 || check2)
                {
                    e.Cancel = true;
                }
                updateCheckAudited(cmbTerminal.SelectedItem.ToString());
                SaveSupportingDocs();
            }
        }
        public bool checkFindingsVsBreakdownAmount(string sign)
        {
            //con = new SqlConnection(localConnectionString);
            bool withError = false;
            //Array Declaration TENDERS Column Names
            string[] columnComponent = new string[6];
            columnComponent[0] = "Cash";
            columnComponent[1] = "Charge";
            columnComponent[2] = "gift";
            columnComponent[3] = "senior";
            columnComponent[4] = "other";
            columnComponent[5] = "surcharge";
            //SQL Parameters
            DateTime startDate = Convert.ToDateTime(txtMonth.Text + " 01, " + txtYear.Text);

            DateTime endDate = startDate.AddMonths(1).AddDays(-1);
            //DateTime endDate = Convert.ToDateTime(txtMonth.Text + DateTime.DaysInMonth(Convert.ToInt32(txtYear.Text), Convert.ToInt32(startDate.ToString("MM"))));

            for (int i = 0; i < columnComponent.Count(); i++)
            {
                //string sql = "SELECT CAST(CASE WHEN a.var <>b.auditVal THEN 1 ";
                //sql += "    WHEN a.var IS NULL AND b.auditVal IS NOT NULL THEN 1";
                //sql += "    WHEN a.var IS NOT NULL AND b.auditVal IS NULL THEN 1";
                //sql += " ELSE 0 END AS BIT) AS 'TF'  ";
                //sql += " FROM";
                //sql += " (SELECT tenantcode,SUM(" + columnComponent[i] + "Var) AS 'var' FROM AuditedTenders ";
                //sql += " WHERE tenantcode =@rp AND date BETWEEN @sdate AND @edate AND " + columnComponent[i] + sign + "0";
                //sql += " GROUP BY tenantcode) a ";
                //sql += " FULL OUTER JOIN";
                //sql += " (SELECT tenantcode,SUM(NetAGSC) AS 'auditVal' FROM AuditFindings ";
                //sql += " WHERE tenantcode = @rp AND ComponentId=@comp  AND DateNormal=@sdate AND NetAGSC"+sign+"0";
                //sql += " GROUP BY tenantcode) b ON a.tenantcode=b.TenantCode";

                //con.Open();
                //SqlCommand cmd = new SqlCommand(sql, con);
                //cmd.Parameters.AddWithValue("rp", txtRPCode.Text);
                //cmd.Parameters.AddWithValue("sdate", startDate.ToString("yyyy-MM-dd"));
                //cmd.Parameters.AddWithValue("edate", endDate.ToString("yyyy-MM-dd"));
                //cmd.Parameters.AddWithValue("comp", i+1);
                //try { withError = Convert.ToBoolean(cmd.ExecuteScalar()); //MessageBox.Show(withError.ToString()); 
                //}
                //catch (Exception er) { //MessageBox.Show("Error Converting: " + er); 
                //}
                con.Open();
                //MessageBox.Show((i + 1).ToString());
                int x = i + 1;

                //string sqlcount1 = "SELECT COUNT(*) FROM VarianceBreakdown  WHERE tenantcode=@rp AND date BETWEEN @sdate AND @edate AND Component=@comp AND Amount" + sign + "0";
                string sqlcount1 = "SELECT COUNT(*) FROM VarianceBreakdown  WHERE tenantcode=@rp AND date BETWEEN @sdate AND @edate AND Component=@comp AND AMOUNT <> 0 AND AMOUNT IS NOT NULL";

                SqlCommand cmdcount1 = new SqlCommand(sqlcount1, con);
                cmdcount1.Parameters.AddWithValue("rp", txtRPCode.Text);
                cmdcount1.Parameters.AddWithValue("sdate", startDate.ToString("yyyy-MM-dd"));
                cmdcount1.Parameters.AddWithValue("edate", startDate.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd"));
                cmdcount1.Parameters.AddWithValue("comp", x);
                //MessageBox.Show(i.ToString() + " vs " +x.ToString());
                double amount1 = 0.00;
                if (Convert.ToInt16(cmdcount1.ExecuteScalar()) > 0)
                {
                    string sql1 = "SELECT SUM(Amount) FROM VarianceBreakdown ";
                    //sql1 += " WHERE tenantcode=@rp  AND date BETWEEN @sdate AND @edate AND Component=@comp AND Amount" + sign + "0";
                    sql1 += " WHERE tenantcode=@rp  AND date BETWEEN @sdate AND @edate AND Component=@comp AND AMOUNT <> 0 AND AMOUNT IS NOT NULL";
                    SqlCommand cmd1 = new SqlCommand(sql1, con);
                    cmd1.Parameters.AddWithValue("rp", txtRPCode.Text);
                    cmd1.Parameters.AddWithValue("sdate", startDate.ToString("yyyy-MM-dd"));
                    cmd1.Parameters.AddWithValue("edate", startDate.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd"));
                    cmd1.Parameters.AddWithValue("comp", x);
                    amount1 = Convert.ToDouble(cmd1.ExecuteScalar());
                    //MessageBox.Show(sql2);
                }

                //string sqlcount2 = "SELECT COUNT(*) FROM AuditFindings  WHERE tenantcode=@rp AND DateNormal=@sdate AND ComponentId=@comp AND NetAGSC" + sign + "0";
                string sqlcount2 = "SELECT COUNT(*) FROM AuditFindings  WHERE tenantcode=@rp AND DateNormal=@sdate AND ComponentId=@comp AND NetAGSC <>0 AND NETAGSC IS NOT NULL ";
                SqlCommand cmdcount2 = new SqlCommand(sqlcount2, con);
                cmdcount2.Parameters.AddWithValue("rp", txtRPCode.Text);
                cmdcount2.Parameters.AddWithValue("sdate", startDate.ToString("yyyy-MM-dd"));
                cmdcount2.Parameters.AddWithValue("comp", x);
                //MessageBox.Show(i.ToString() + " vs " +x.ToString());
                double amount2 = 0.00;
                if (Convert.ToInt16(cmdcount2.ExecuteScalar()) > 0)
                {
                    string sql2 = "SELECT SUM(NetAGSC) FROM AuditFindings ";
                    sql2 += " WHERE tenantcode=@rp AND DateNormal=@sdate AND ComponentId=@comp AND NetAGSC <>0 AND NETAGSC IS NOT NULL ";
                    //sql2 += " WHERE tenantcode=@rp AND DateNormal=@sdate AND ComponentId=@comp AND NetAGSC" + sign + "0";
                    SqlCommand cmd2 = new SqlCommand(sql2, con);
                    cmd2.Parameters.AddWithValue("rp", txtRPCode.Text);
                    cmd2.Parameters.AddWithValue("sdate", startDate.ToString("yyyy-MM-dd"));
                    cmd2.Parameters.AddWithValue("comp", x);
                    amount2 = Convert.ToDouble(cmd2.ExecuteScalar());
                    //MessageBox.Show(sql2);
                }
                if (amount1 != amount2)
                {
                    withError = true;
                    //MessageBox.Show(sign);
                    //MessageBox.Show(amount1.ToString() + " vs " + amount2.ToString()+ " Component :"+(x).ToString());
                }

                con.Close();
                //MessageBox.Show(withError.ToString());
                if (withError)
                {
                    //MessageBox.Show(sql);
                    //MessageBox.Show("Tenantcode: " + txtRPCode.Text + "Component: " + (i + 1).ToString());
                    if (i == 2)
                    {
                        columnComponent[i] = "GC / Others";
                    }
                    else if (i == 3)
                    {
                        columnComponent[i] = "Senior Discount";
                    }
                    else if (i == 4)
                    {
                        columnComponent[i] = "Other Discount";
                    }
                    else if (i == 5)
                    {
                        columnComponent[i] = "Service Charge";
                    }
                    string signMsg = "Positive";
                    if (sign != ">")
                    {
                        signMsg = "Negative";
                    }
                    //MessageBox.Show(x.ToString()+"  "+amount1.ToString()+" vs "+amount2.ToString());
                    //MessageBox.Show("Breakdown not Equal to Audit Findings : [" + signMsg + " Total] " + columnComponent[i]);
                    MessageBox.Show("Breakdown not Equal to Audit Findings " + columnComponent[i]);
                    //break;
                    return withError;
                    //i = columnComponent.Count();//break is not working
                }
            }
            return withError;
        }
        public void deleteAuditedTendersAllNulls()
        {
            string sql = "DELETE FROM AuditedTenders";
            sql += " WHERE (nonvat IS NULL AND senior IS NULL AND other IS NULL AND approved IS NULL ";
            sql += " AND VAT IS NULL AND otherNonVat IS NULL AND surcharge IS NULL ";
            sql += " AND cash IS NULL AND charge IS NULL AND gift IS NULL)";

            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void dgvWorkingPaper_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!tableIsLoading && !dgvWPHeaderClick)
            {
                int row = dgvWorkingPaper.CurrentCell.RowIndex;
                int col = dgvWorkingPaper.CurrentCell.ColumnIndex;
                if (dgvWorkingPaper.Columns[col].Name.Contains("Doc"))
                {
                    tableIsLoading = true;
                    frmTickDoc ftd = new frmTickDoc();
                    ftd.StartPosition = FormStartPosition.Manual;
                    frmTickDoc.rp = txtRPCode.Text;
                    frmTickDoc.date = dgvWorkingPaper.Rows[row].Cells[1].Value.ToString();
                    frmTickDoc.terminal = cmbTerminal.SelectedItem.ToString();
                    frmTickDoc.viewing = false;
                    frmTickDoc.colName = dgvWorkingPaper.Columns[col - 3].Name;
                    Point pt = new Point(Cursor.Position.X, Cursor.Position.Y);
                    ftd.Top = (int)(pt.Y - (ftd.Height * .5));
                    if (pt.X + (ftd.Width * .5) > this.Width)
                    {
                        ftd.Left = this.Width - ftd.Width;
                    }
                    else
                    {
                        ftd.Left = (int)(pt.X - (ftd.Width * .5));
                    }
                    ftd.Text="Check Documents - "+dgvWorkingPaper.Columns[col - 3].Name;
                    ftd.ShowDialog();
                    dgvWorkingPaper.Rows[row].Cells[col].Value = frmTickDoc.symbols;
                    tableIsLoading = false;
                }
                dgvWPHeaderClick = false;
            }
        }

        public void updateCheckAudited(string terminal)//terminal/lasterminal added 04062021
        {
            string currentChecked = currentCheckedDays;//Got From Initial Loading of Form
            //MessageBox.Show(currentChecked);
            
            //Added Rows Count Handler 12072020 for Auto Exit if RP has no Data
            if (checkSalesData() > 0   && !currentChecked.Contains("UPLOADED"))
            {
                string checkedDays = "";
                bool all = true;
                int indx = dgvWorkingPaper.Columns[GSCTick].Index;
                for (int i = 0; i < dgvWorkingPaper.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgvWorkingPaper.Rows[i].Cells[indx].Value))
                    {//CheckBox is Checked
                        checkedDays += Convert.ToDateTime(dgvWorkingPaper.Rows[i].Cells[1].Value).ToString("%d") + ",";//Add Day to String
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
                else if (checkedDays != "")
                {
                    //MessageBox.Show(checkedDays);
                    checkedDays = checkedDays.Substring(0, checkedDays.LastIndexOf(','));//Remove Last Comma
                }

                //No Insert Or Update if No Checked Days
                //if (checkedDays != "")
                //{
                string auditPeriod = txtMonth.Text + " 01, " + txtYear.Text;
                con.Open();
                string sqlcount = "SELECT COUNT(*) FROM CheckedWorkingPaper WHERE tenantcode=@rp AND machine=@terminal AND auditPeriod=@auditPeriod";
                SqlCommand cmdCount = new SqlCommand(sqlcount, con);
                cmdCount.Parameters.AddWithValue("rp", rp);
                //MessageBox.Show(cmbTerminal.SelectedItem.ToString());
                cmdCount.Parameters.AddWithValue("terminal", terminal);
                cmdCount.Parameters.AddWithValue("auditPeriod", auditPeriod);
                int count = (int)cmdCount.ExecuteScalar();
                if (count > 0)
                {// UPDATE
                    string sql2 = "UPDATE CheckedWorkingPaper SET checkedLevel1 =@checkedDays WHERE tenantcode=@rp AND machine=@terminal AND auditPeriod=@auditPeriod";
                    SqlCommand cmd = new SqlCommand(sql2, con);
                    cmd.Parameters.AddWithValue("checkedDays", checkedDays);
                    cmd.Parameters.AddWithValue("rp", rp);
                    cmd.Parameters.AddWithValue("terminal", terminal);
                    cmd.Parameters.AddWithValue("auditPeriod", auditPeriod);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
                //}

            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            //checkFindingsVsTendersAmount(">");
            //bool check1 = checkFindingsVsBreakdownAmount(">");
            //bool check2 = checkFindingsVsBreakdownAmount("<");
            DialogResult dialogResult = MessageBox.Show("Are you Sure to Delete All Changes?", "Some Title", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string sdate = txtMonth.Text + " 01, " + txtYear.Text;
                string edate = Convert.ToDateTime(sdate).AddMonths(1).AddDays(-1).ToString("MMMM dd, yyyy");
                string selectedTerminal = cmbTerminal.SelectedItem.ToString();
                string rpcode = txtRPCode.Text.ToString();
                con.Open();
                string sql = "DELETE FROM AuditedTenders WHERE tenantcode=@rpcode AND machine=@terminal AND date BETWEEN @sdate AND @edate ";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("rpcode", rpcode);
                cmd.Parameters.AddWithValue("sdate", sdate);
                cmd.Parameters.AddWithValue("edate", edate);
                cmd.Parameters.AddWithValue("terminal", selectedTerminal);
                cmd.ExecuteNonQuery();
                string sql2 = "DELETE FROM VarianceBreakdown WHERE tenantcode=@rpcode AND machine=@terminal AND date BETWEEN @sdate AND @edate";
                SqlCommand cmd2 = new SqlCommand(sql2, con);
                cmd2.Parameters.Clear();
                cmd2.Parameters.AddWithValue("rpcode", rpcode);
                cmd2.Parameters.AddWithValue("sdate", sdate);
                cmd2.Parameters.AddWithValue("edate", edate);
                cmd2.Parameters.AddWithValue("terminal", selectedTerminal);
                cmd2.ExecuteNonQuery();
                string sql3 = "DELETE FROM AuditFindings WHERE tenantcode=@rpcode AND dateNormal=@sdate";
                SqlCommand cmd3 = new SqlCommand(sql3, con);
                cmd3.Parameters.AddWithValue("rpcode", rpcode);
                cmd3.Parameters.AddWithValue("sdate", sdate);
                cmd3.ExecuteNonQuery();
                con.Close();
                reloadTable();
            }
        }

        private void btnAFBreakdown_Click(object sender, EventArgs e)
        {
            VarianceBreakdownSummary.rpcode = txtRPCode.Text;
            VarianceBreakdownSummary.terminal = cmbTerminal.SelectedItem.ToString();
            VarianceBreakdownSummary.sdate = txtMonth.Text + " 01," + txtYear.Text;
            VarianceBreakdownSummary vbs = new VarianceBreakdownSummary();
            vbs.ShowDialog();
        }

        private void chkEnableAFBreakdown_CheckedChanged(object sender, EventArgs e)
        {
            btnAFBreakdown.Enabled = chkEnableAFBreakdown.Checked;
        }
        //to Cancel- Cell-ValueChanged Event
        bool undoRedo = false;
        public bool undo = false;
        bool redo = false;
        private void btnUndo_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < 2; i++)
            //{
            //    int row = actionsRow[i];
            //    int col = actionsCol[i];
            //    string value = actionValues[i];
            //    MessageBox.Show(row.ToString() + "," + col.ToString() + ",value:" + value);
            //}


            undoRedo = true;
            undo = true;
            int row = actionsRow[actionIndex - 1];
            int col = actionsCol[actionIndex - 1];
            string value = undoValues[actionIndex - 1];//last value
            //string currentValue = dgvWorkingPaper.Rows[row].Cells[col].Value.ToString();// for redo
            actionIndex--;

            //MessageBox.Show(row.ToString() + "," + col.ToString() + ",value:" + value);
            if (value == "")
            {
                value = "null";
            }
            //MessageBox.Show(actionIndex.ToString());
            //MessageBox.Show(row.ToString() + "," + col.ToString() + ",value:" + value);
            dgvWorkingPaper.Rows[row].Cells[col].Value = value;
            cellsChanged(row, col);
            btnRedo.Enabled = true;
            undoRedo = false;
            undo = false;

            if (actionIndex == 0)
            {
                btnUndo.Enabled = false;
            }

        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            redo = true;
            undoRedo = true;
            int row = actionsRow[actionIndex];
            int col = actionsCol[actionIndex];
            string value = redoValues[actionIndex];
            //MessageBox.Show(row.ToString() + "," + col.ToString() + ",value:" + value);
            if (value == "")
            {
                value = "null";
            }
            actionIndex++;
            //MessageBox.Show(actionIndex.ToString());
            dgvWorkingPaper.Rows[row].Cells[col].Value = value;
            cellsChanged(row, col);
            undoRedo = false;
            redo = false;

            if (actionIndex >= actionSize)
            {
                btnRedo.Enabled = false;
            }
            if (actionIndex > 0)
            {
                btnUndo.Enabled = true;
            }
        }

        private void btnSpecialCase_Click(object sender, EventArgs e)
        {
            string sql = "SELECT location FROM tenantmod WHERE tenantcode=@rp";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql,con);
            cmd.Parameters.AddWithValue("rp",txtRPCode.Text);
            string locID= cmd.ExecuteScalar().ToString();
            con.Close();
            


            SpecialCase sc = new SpecialCase();
            SpecialCase.rp = txtRPCode.Text;
            SpecialCase.loc = locID;
            SpecialCase.monthYear = txtMonth.Text + " " + txtYear.Text;
            SpecialCase.action = "EDIT";
            SpecialCase.rpName = txtRP.Text;
            sc.StartPosition = FormStartPosition.CenterParent;
            sc.ShowDialog();
        }

        private void chkDocTicks_CheckedChanged(object sender, EventArgs e)
        {

        }



    }
}
