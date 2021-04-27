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
    public partial class AuditFindings : Form
    {
        string localConnection = LoginForm.localConnectionString;
        SqlConnection con;
        public AuditFindings()
        {
            InitializeComponent();
        }
        public static string month;
        public static string year;
        public static string rp;
        public static string terminal;
        public static bool hide;
        private void btnAddFindings_Click(object sender, EventArgs e)
        {
            AddFindings addFindings = new AddFindings();
            addFindings.ShowDialog();
            //after exiting add Findings Form
            reloadTables();
        }

        private void AuditFindings_Load(object sender, EventArgs e)
        {
            hideButtons();
            con = new SqlConnection(localConnection);
            reloadTables();
        }
        public void hideButtons(){
            if (hide)
            {
                btnAFBreakdown.Visible = false;
                btnAddFindings.Visible = false;
                btnDeleteCash.Visible = false;
                btnDeleteCharge.Visible = false;
                btnDeleteGC.Visible = false;
                btnDeleteSD.Visible = false;
                btnDeleteOD.Visible = false;
                btnDeleteSC.Visible = false;
            }
        }
        public void reloadTables()
        {
            dgvCash.DataSource = loadTable(1);
            dgvCharge.DataSource = loadTable(2);
            dgvGC.DataSource = loadTable(3);
            dgvSD.DataSource = loadTable(4);
            dgvOD.DataSource = loadTable(5);
            dgvSC.DataSource = loadTable(6);
            //SUM OF FINDINGS
            string sign = ">";
            if (!chkPositiveNegative.Checked)//unchecked
            {
                sign = "<";
            }
            //auditFindings
            txtFindingsCash.Text = sumFindings(1,sign).ToString("0.00");
            txtFindingsCharge.Text = sumFindings(2, sign).ToString("0.00");
            txtFindingsGC.Text = sumFindings(3, sign).ToString("0.00");
            txtFindingsSD.Text = sumFindings(4, sign).ToString("0.00");
            txtFindingsOD.Text = sumFindings(5, sign).ToString("0.00");
            txtFindingsSC.Text = sumFindings(6, sign).ToString("0.00");
            //Audited Values
            txtAuditedCash.Text = sumAudited("cash",sign).ToString("0.00");
            txtAuditedCharge.Text = sumAudited("charge", sign).ToString("0.00");
            txtAuditedGC.Text = sumAudited("gift", sign).ToString("0.00");
            txtAuditedSD.Text = sumAudited("senior", sign).ToString("0.00");
            txtAuditedOD.Text = sumAudited("other", sign).ToString("0.00");
            txtAuditedSC.Text = sumAudited("surcharge", sign).ToString("0.00");
            //sumAudited(sign);

        }
        public DataTable loadTable(int component)
        {
            con.Open();
            string date = month + " 01, " + year;
            DataTable dt = new DataTable();
            string sql = "SELECT FindingsDate,Classification,NatureOfError,NetAGSC,Remarks FROM AuditFindings a ";
            sql += " JOIN ProblemClass b ON a.ClassID=b.ClassID WHERE ComponentID=@component AND DateNormal=@date AND tenantcode=@rp";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("component", component);
            cmd.Parameters.AddWithValue("date", date);
            cmd.Parameters.AddWithValue("rp", rp);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public double sumFindings(int component,string sign){
            string date = month + " 01, " + year;
            string sql = "SELECT CASE WHEN total IS NULL THEN 0.00 ELSE total END AS 'total' FROM";
            sql += " (SELECT SUM(NetAGSC) AS 'total' FROM AuditFindings";
            sql += " WHERE DateNormal = @date";
            sql += " AND ComponentId=@component";
            sql += " AND TenantCode =@rp";
            sql += " AND NETAGSC"+sign+"0) a";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("component", component);
            cmd.Parameters.AddWithValue("date", date);
            cmd.Parameters.AddWithValue("rp", rp);
            double sum = Convert.ToDouble(cmd.ExecuteScalar());
            con.Close();
            return sum;
        }
        public double sumAudited(string column,string sign)
        {
            double value = 0.00;
            string sdate = month + " 01, " + year;
            string edate = (Convert.ToDateTime(sdate).AddMonths(1).AddDays(-1)).ToString("MMMM dd, yyyy");
            string sql = "SELECT CASE WHEN " + column + " IS NULL then 0.00 ELSE " + column + " END as '" + column + "'";
            sql += " FROM (SELECT SUM(" + column + "Var) AS '" + column + "' FROM auditedTenders WHERE tenantcode= @rp";
            sql += " AND date BETWEEN @sdate AND @edate";
            sql += " AND "+column+"Var "+sign+"0) a";
            //sql+= " CASE WHEN charge IS NULL then 0.00 ELSE charge END as 'charge',";
            //sql+= " CASE WHEN gift IS NULL then 0.00 ELSE gift END as 'gift',";
            //sql+= " CASE WHEN senior IS NULL then 0.00 ELSE senior END as 'senior',";
            //sql+= " CASE WHEN other IS NULL then 0.00 ELSE other END as 'other',";
            //sql+= " CASE WHEN surcharge IS NULL then 0.00 ELSE surcharge END as 'surcharge' FROM";
            //sql+= " (SELECT SUM(cashVar) AS 'cash',SUM(chargeVar) AS 'charge',SUM(giftVar) AS 'gift'";
            //sql+= " ,SUM(seniorVar) AS 'senior',SUM(otherVar) AS 'other',SUM(surchargeVar) AS 'surcharge'";
            //sql+= " FROM AuditedTenders WHERE tenantcode= @rp ";
            //sql+= " AND date BETWEEN @sdate AND @edate";
            //sql += " AND cashVar" + sign + "0 AND chargeVar" + sign + "0 AND giftVar" + sign + "0";
            //sql += " AND seniorVar" + sign + "0 AND otherVar" + sign + "0 AND surchargeVar" + sign + "0";
            //sql+= " ) a";
            con.Open();
            //MessageBox.Show(sql);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("rp", rp);
            cmd.Parameters.AddWithValue("sdate", sdate);
            cmd.Parameters.AddWithValue("edate", edate);
            value = Convert.ToDouble(cmd.ExecuteScalar());
            //SqlDataReader sReader = cmd.ExecuteReader();
            //while (sReader.Read())
            //{
            //    txtAuditedCash.Text = sReader[0].ToString();
            //    txtAuditedCharge.Text = sReader[1].ToString();
            //    txtAuditedGC.Text = sReader[2].ToString();
            //    txtAuditedSD.Text = sReader[3].ToString();
            //    txtAuditedOD.Text = sReader[4].ToString();
            //    txtAuditedSC.Text = sReader[5].ToString();
            //}
            con.Close();

            return value;
        }


        private void btnDeleteFindings_Click(object sender, EventArgs e)
        {
            
        }
        public void deleteFindings(string fd, string cl, string noe, double amount, string remarks, int comp)
        {
            cl = getClassificationID(cl);//not yet id so... get
            con.Open();
            string auditPeriod = month + " 01, " + year;
            string sql = "DELETE FROM AuditFindings WHERE tenantcode=@rp AND FindingsDate=@fd AND ClassId =@cl AND NatureOfError=@noe AND NETAGSC=@amount AND Remarks=@remarks AND ComponentId=@comp AND DateNormal=@auditPeriod";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("fd", fd);
            cmd.Parameters.AddWithValue("cl", cl);
            cmd.Parameters.AddWithValue("noe", noe);
            cmd.Parameters.AddWithValue("amount", amount);
            cmd.Parameters.AddWithValue("remarks", remarks);
            cmd.Parameters.AddWithValue("comp", comp);
            cmd.Parameters.AddWithValue("auditPeriod", auditPeriod);
            cmd.Parameters.AddWithValue("rp", rp);
            cmd.ExecuteNonQuery();
            con.Close();
            reloadTables();
        }
        string getClassificationID(string cl){
            string id="";
            string sql = "SELECT ClassID FROM ProblemClass WHERE Classification=@cl";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("cl", cl);
            id = cmd.ExecuteScalar().ToString();
            con.Close();
        return id;
        }
        private void btnDeleteCash_Click(object sender, EventArgs e)
        {
            int row = -1;
            try
            {
                row = dgvCash.CurrentCell.RowIndex;
            }
            catch (Exception) { row = -1; }
            if (row >= 0)
            {
                string fd=dgvCash.Rows[row].Cells[0].Value.ToString();
                string cl=dgvCash.Rows[row].Cells[1].Value.ToString();
                string noe=dgvCash.Rows[row].Cells[2].Value.ToString();
                double amount=Convert.ToDouble(dgvCash.Rows[row].Cells[3].Value.ToString());
                string remarks=dgvCash.Rows[row].Cells[4].Value.ToString();
                int comp = 1;
                //MessageBox.Show(fd+"\n"+cl+"\n"+noe+"\n"+amount.ToString()+"\n"+remarks);
                DialogResult dr = MessageBox.Show("Delete Selected Cash Findings?", "Warning", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    deleteFindings(fd, cl, noe, amount, remarks, comp);
                }
            }
        }

        private void btnDeleteCharge_Click(object sender, EventArgs e)
        {
            int row = -1;
            try
            {
                row = dgvCharge.CurrentCell.RowIndex;
            }
            catch (Exception) { row = -1; }
            if (row >= 0)
            {
                string fd = dgvCharge.Rows[row].Cells[0].Value.ToString();
                string cl = dgvCharge.Rows[row].Cells[1].Value.ToString();
                string noe = dgvCharge.Rows[row].Cells[2].Value.ToString();
                double amount = Convert.ToDouble(dgvCharge.Rows[row].Cells[3].Value.ToString());
                string remarks = dgvCharge.Rows[row].Cells[4].Value.ToString();
                int comp = 2;
                DialogResult dr = MessageBox.Show("Delete Selected Charge Findings?", "Warning", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    deleteFindings(fd, cl, noe, amount, remarks, comp);
                }
            }
        }

        private void btnDeleteGC_Click(object sender, EventArgs e)
        {
            int row = -1;
            try
            {
                row = dgvGC.CurrentCell.RowIndex;
            }
            catch (Exception) { row = -1; }
            if (row >= 0)
            {
                string fd = dgvGC.Rows[row].Cells[0].Value.ToString();
                string cl = dgvGC.Rows[row].Cells[1].Value.ToString();
                string noe = dgvGC.Rows[row].Cells[2].Value.ToString();
                double amount = Convert.ToDouble(dgvGC.Rows[row].Cells[3].Value.ToString());
                string remarks = dgvGC.Rows[row].Cells[4].Value.ToString();
                int comp = 3;
                DialogResult dr = MessageBox.Show("Delete Selected GC/Other Findings?", "Warning", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    deleteFindings(fd, cl, noe, amount, remarks, comp);
                }
            }
        }


        private void btnDeleteSD_Click(object sender, EventArgs e)
        {
            int row = -1;
            try
            {
                row = dgvSD.CurrentCell.RowIndex;
            }
            catch (Exception) { row = -1; }
            if (row >= 0)
            {
                string fd = dgvSD.Rows[row].Cells[0].Value.ToString();
                string cl = dgvSD.Rows[row].Cells[1].Value.ToString();
                string noe = dgvSD.Rows[row].Cells[2].Value.ToString();
                double amount = Convert.ToDouble(dgvSD.Rows[row].Cells[3].Value.ToString());
                string remarks = dgvSD.Rows[row].Cells[4].Value.ToString();
                int comp = 4;
                DialogResult dr = MessageBox.Show("Delete Selected SeniorDiscount Findings?", "Warning", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    deleteFindings(fd, cl, noe, amount, remarks, comp);
                }
            }
        }
        private void btnDeleteOD_Click(object sender, EventArgs e)
        {
            int row = -1;
            try
            {
                row = dgvOD.CurrentCell.RowIndex;
            }
            catch (Exception) { row = -1; }
            if (row >= 0)
            {
                string fd = dgvOD.Rows[row].Cells[0].Value.ToString();
                string cl = dgvOD.Rows[row].Cells[1].Value.ToString();
                string noe = dgvOD.Rows[row].Cells[2].Value.ToString();
                double amount = Convert.ToDouble(dgvOD.Rows[row].Cells[3].Value.ToString());
                string remarks = dgvOD.Rows[row].Cells[4].Value.ToString();
                int comp = 5;
                DialogResult dr = MessageBox.Show("Delete Selected OtherDiscount Findings?", "Warning", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    deleteFindings(fd, cl, noe, amount, remarks, comp);
                }
            }
        }

        private void btnDeleteSC_Click(object sender, EventArgs e)
        {
            int row = -1;
            try
            {
                row = dgvSC.CurrentCell.RowIndex;
            }
            catch (Exception) { row = -1; }
            if (row >= 0)
            {
                string fd = dgvSC.Rows[row].Cells[0].Value.ToString();
                string cl = dgvSC.Rows[row].Cells[1].Value.ToString();
                string noe = dgvSC.Rows[row].Cells[2].Value.ToString();
                double amount = Convert.ToDouble(dgvSC.Rows[row].Cells[3].Value.ToString());
                string remarks = dgvSC.Rows[row].Cells[4].Value.ToString();
                int comp = 6;
                DialogResult dr = MessageBox.Show("Delete Selected ServiceCharge Findings?", "Warning", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    deleteFindings(fd, cl, noe, amount, remarks, comp);
                }
            }
        }

        private void txtFindingsCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtAuditedCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtAuditedCharge_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtFindingsCharge_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtAuditedGC_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtFindingsGC_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtAuditedOD_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtFindingsOD_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtAuditedSD_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtFindingsSD_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtAuditedSC_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtFindingsSC_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void chkPositiveNegative_CheckedChanged(object sender, EventArgs e)
        {
            reloadTables();
        }

        private void btnAFBreakdown_Click(object sender, EventArgs e)
        {
            VarianceBreakdownSummary.rpcode = rp;
            VarianceBreakdownSummary.terminal = terminal;
            VarianceBreakdownSummary.sdate = month + " 01, " + year;
            VarianceBreakdownSummary vbs = new VarianceBreakdownSummary();
            vbs.StartPosition = FormStartPosition.CenterParent;
            vbs.ShowDialog();
            reloadTables();
        }

    }
}
