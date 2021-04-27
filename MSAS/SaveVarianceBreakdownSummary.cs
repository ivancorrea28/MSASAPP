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

namespace MSAS
{
    public partial class SaveVarianceBreakdownSummary : Form
    {
        public SaveVarianceBreakdownSummary()
        {
            InitializeComponent();
        }

        SqlConnection con;
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cmbNOE.SelectedIndex < 0)
            {
                MessageBox.Show("Select Nature of Error");
            }
            else
            {
                saveFindings();
                //updateSupportingDocs();
                updateVarianceBreakdown();
                this.Close();
            }
        }
        void updateVarianceBreakdown(){
            con.Open();
            string sql = "UPDATE VarianceBreakdown SET summarized='YES' WHERE tenantcode=@rpcode AND classification=@class AND component=@comp AND date BETWEEN @sdate AND @edate AND machine=@terminal";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("rpcode", rpcode);
            cmd.Parameters.AddWithValue("class", classif);
            cmd.Parameters.AddWithValue("comp", comp);
            cmd.Parameters.AddWithValue("sdate", sdate);
            cmd.Parameters.AddWithValue("edate", Convert.ToDateTime(sdate).AddMonths(1).AddDays(-1).ToString("MMMM dd, yyyy"));
            cmd.Parameters.AddWithValue("terminal", terminal);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void saveFindings()
        {
            string remarks = txtRemarks.Text;
            string rdbText = "";
            if (rdbFirst.Checked)
            {
                rdbText = rdbFirst.Text;
            }
            else if (rdbRecur.Checked)
            {
                rdbText = rdbRecur.Text;
            }
            else if (rdbNonRecur.Checked)
            {
                rdbText = rdbRecur.Text;
            }
            if (chkDeposits.Checked || chkReadings.Checked || chkMSR.Checked || chkOther.Checked)
            {
                remarks += "- Supporting Document: ";
                if (chkMSR.Checked)
                {
                    remarks += "MSR, ";
                }
                if (chkReadings.Checked)
                {
                    remarks += "Readings, ";
                }
                if (chkDeposits.Checked)
                {
                    remarks += "Cash/Credit Card Deposit, ";
                }
                if (chkOther.Checked)
                {
                    remarks += "Other Document, ";
                }
                //remarks = remarks.Substring(0, remarks.LastIndexOf(','));
                remarks += ".";
            }
            remarks += " - " + rdbText;
            con.Open();
            //Check if Findings already Exists ~ Component,classification,Audit Period
            string sqlCount = "SELECT COUNT(*) FROM AuditFindings WHERE tenantcode=@rpcode AND ClassID=@class AND ComponentID=@comp AND DateNormal=@sdate";
            SqlCommand cmdCount = new SqlCommand(sqlCount, con);
            cmdCount.Parameters.AddWithValue("rpcode", rpcode);
            cmdCount.Parameters.AddWithValue("class", classif);
            cmdCount.Parameters.AddWithValue("comp", comp);
            cmdCount.Parameters.AddWithValue("sdate", sdate);
            if((int)cmdCount.ExecuteScalar()>0){
                DialogResult dr = MessageBox.Show("There's an Existing Findings with the Same Classification, Add Again?", "Warning", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    //string sql = "UPDATE AuditFindings SET FindingsDate=@dates,NatureOfError=@NoE,NETAGSC=@amount,Remarks=@remarks WHERE tenantcode=@rpcode AND ClassID=@class AND ComponentID=@comp AND DateNormal=@sdate";
                    //SqlCommand cmd = new SqlCommand(sql, con);
                    //cmd.Parameters.AddWithValue("rpcode", rpcode);
                    //cmd.Parameters.AddWithValue("class", classif);
                    //cmd.Parameters.AddWithValue("dates", selectedDays);
                    //cmd.Parameters.AddWithValue("comp", comp);
                    //cmd.Parameters.AddWithValue("NoE", cmbNOE.SelectedItem.ToString());
                    //cmd.Parameters.AddWithValue("amount", txtAmount.Text);
                    //cmd.Parameters.AddWithValue("remarks", remarks);
                    //cmd.Parameters.AddWithValue("auditor", AuditSchedule.auditor);
                    //cmd.Parameters.AddWithValue("sdate", sdate);
                    //cmd.ExecuteNonQuery();
                    string sql = "INSERT INTO AuditFindings Values (null,@rpcode,@class,@dates,@comp,@NoE,@amount,@remarks,@auditor,'Approved',null,@sdate)";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("rpcode", rpcode);
                    cmd.Parameters.AddWithValue("class", classif);
                    cmd.Parameters.AddWithValue("dates", selectedDays);
                    cmd.Parameters.AddWithValue("comp", comp);
                    cmd.Parameters.AddWithValue("NoE", cmbNOE.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("amount", Convert.ToDouble(txtAmount.Text));
                    cmd.Parameters.AddWithValue("remarks", remarks);
                    cmd.Parameters.AddWithValue("auditor", AuditSchedule.auditor);
                    cmd.Parameters.AddWithValue("sdate", sdate);
                    cmd.ExecuteNonQuery();
                }
            }
            else
            {
                string sql = "INSERT INTO AuditFindings Values (null,@rpcode,@class,@dates,@comp,@NoE,@amount,@remarks,@auditor,'Approved',null,@sdate)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("rpcode", rpcode);
                cmd.Parameters.AddWithValue("class", classif);
                cmd.Parameters.AddWithValue("dates", selectedDays);
                cmd.Parameters.AddWithValue("comp", comp);
                cmd.Parameters.AddWithValue("NoE", cmbNOE.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("amount", Convert.ToDouble(txtAmount.Text));
                cmd.Parameters.AddWithValue("remarks", remarks);
                cmd.Parameters.AddWithValue("auditor", AuditSchedule.auditor);
                cmd.Parameters.AddWithValue("sdate", sdate);
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }
        public static string rpcode;
        public static string terminal;
        public static string sdate;
        public void updateSupportingDocs()
        {
            con.Open();
            bool currentMSR = false;
            bool currentRead = false;
            bool currentDeposit = false;
            bool currentOther = false;
            string sql = "SELECT MSR,Readings,Deposits,OtherDocs FROM AuditSupportingDocs WHERE tenantcode=@rpcode AND machine=@terminal AND date=@date";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("rpcode", rpcode);
            cmd.Parameters.AddWithValue("terminal", terminal);
            cmd.Parameters.AddWithValue("date", sdate);
            SqlDataReader sRead = cmd.ExecuteReader();
            while (sRead.Read())
            {
                currentMSR = Convert.ToBoolean(sRead[0]);
                currentRead = Convert.ToBoolean(sRead[1]);
                currentDeposit = Convert.ToBoolean(sRead[2]);
                currentOther = Convert.ToBoolean(sRead[3]);
            }
            sRead.Close();
            string updSql = "UPDATE AuditSupportingDocs SET MSR=@msr, Readings=@read, Deposits=@dep, OtherDocs=@other WHERE tenantcode=@rpcode AND machine=@terminal AND date=@date";
            SqlCommand updCmd = new SqlCommand(updSql, con);
            updCmd.Parameters.AddWithValue("msr", (!currentMSR == !chkMSR.Checked ? false : true));
            updCmd.Parameters.AddWithValue("read", (!currentRead == !chkReadings.Checked ? false : true));
            updCmd.Parameters.AddWithValue("dep", (!currentDeposit == !chkDeposits.Checked ? false : true));
            updCmd.Parameters.AddWithValue("other", (!currentOther == !chkOther.Checked ? false : true));
            updCmd.Parameters.AddWithValue("rpcode", rpcode);
            updCmd.Parameters.AddWithValue("terminal", terminal);
            updCmd.Parameters.AddWithValue("date", sdate);
            updCmd.ExecuteNonQuery();
            con.Close();
        }
        private void SaveVarianceBreakdownSummary_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(LoginForm.localConnectionString);
            loadSUpportingDocs();
            loadNoE();
        }
        public void loadSUpportingDocs()
        {
            con.Open();
            string sql = "SELECT * FROM AuditSupportingDocs WHERE machine='1' OR machine='ALL' AND tenantcode=@rpcode AND date=@sdate";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("rpcode", rpcode);
            cmd.Parameters.AddWithValue("sdate", sdate);
            SqlDataReader sRead = cmd.ExecuteReader();
            while (sRead.Read())
            {
                chkMSR.Checked = Convert.ToBoolean(sRead["MSR"]);
                chkReadings.Checked = Convert.ToBoolean(sRead["Readings"]);
                chkDeposits.Checked = Convert.ToBoolean(sRead["Deposits"]);
                chkOther.Checked = Convert.ToBoolean(sRead["OtherDocs"]);
            }
            con.Close();
        }

        int[] NOE;
        public static int comp;
        public static int classif;
        public static string selectedDays;
        
        public void loadNoE()
        {
            cmbNOE.Items.Clear();
            NOE = new int[100];
            con.Open();
            string sql;
            sql = "SELECT * FROM NatureofError WHERE Classification=@classify ORDER BY 1";
            SqlCommand cmd1 = new SqlCommand(sql, con);
            cmd1.Parameters.AddWithValue("classify", txtClassif.Text);
            SqlDataReader sReader1 = cmd1.ExecuteReader();
            int arraySize = 0;
            while (sReader1.Read())
            {
                NOE[arraySize] = Convert.ToInt32(sReader1["NatureofErrorID"]);
                cmbNOE.Items.Add(sReader1["NatureOfError"].ToString());
                arraySize += 1;
            }
            sReader1.Close();
            Array.Resize(ref NOE, arraySize);
            con.Close();
            cmbNOE.DropDownWidth = DropDownWidth(cmbNOE);
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

        private void txtComponent_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }


        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtClassif_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

    }
}
