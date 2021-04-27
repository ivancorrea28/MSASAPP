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

namespace MSAS
{
    public partial class frmAdjustmentRequest : Form
    {
        public frmAdjustmentRequest()
        {
            InitializeComponent();
        }


        SqlConnection con;
        string localConnection = LoginForm.localConnectionString;
        public static string rp;
        public static string selectedDate;
        private void frmAdjustmentRequest_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(localConnection);
            dtpSdate.Value = Convert.ToDateTime(DateTime.Now.AddMonths(-2).ToString("MMMM 01, yyyy"));
            dtpEdate.Value = Convert.ToDateTime(DateTime.Now.AddMonths(-1).ToString("MMMM 01, yyyy")).AddDays(-1);
            loadSAF();
        }
        void loadSAF()
        {
            con.Open();
            string sqlcount = "SELECT COUNT(*) FROM SalesAdjustmentRequest WHERE tenantcode=@rp AND @selectedDate BETWEEN startDate AND endDate";
            SqlCommand cmdcount = new SqlCommand(sqlcount, con);
            cmdcount.Parameters.AddWithValue("rp", rp);
            cmdcount.Parameters.AddWithValue("selectedDate", selectedDate);
            if((int)cmdcount.ExecuteScalar()>0){
                btnSaveOk.Text = "Ok";
                dtpSdate.Enabled = false;
                dtpEdate.Enabled = false;
                string sql = "SELECT startdate,enddate,reason FROM SalesAdjustmentRequest WHERE tenantcode=@rp AND @selectedDate BETWEEN startDate AND endDate";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("rp", rp);
                cmd.Parameters.AddWithValue("selectedDate", selectedDate);
                SqlDataReader sReader = cmd.ExecuteReader();
                while (sReader.Read())
                {
                    dtpSdate.Value = Convert.ToDateTime(sReader[0]);
                    dtpEdate.Value = Convert.ToDateTime(sReader[1]);
                    txtReason.Text = sReader[2].ToString();
                }
            }
            con.Close();
            loadLocName();
        }
        void loadLocName(){
            con.Open();
            string sql = "SELECT locationd FROM location a JOIN tenantmod b ON a.location=b.location WHERE tenantcode=@rp";
            SqlCommand cmd = new SqlCommand(sql,con);
            cmd.Parameters.AddWithValue("rp",rp);
            lblLocRPname.Text = cmd.ExecuteScalar().ToString().Trim()+" - "+lblLocRPname.Text;
            con.Close();
        }
        private void btnSaveOk_Click(object sender, EventArgs e)
        {
            if (btnSaveOk.Text == "Save")
            {
                string sdate = dtpSdate.Value.ToString("MMMM 01, yyyy");
                string edate = Convert.ToDateTime(dtpEdate.Value.AddMonths(1).ToString("MMMM 01, yyyy")).AddDays(-1).ToString("MMMM dd, yyyy");
                MessageBox.Show(edate);
                con.Open();
                string sql = "INSERT INTO SalesAdjustmentRequest VALUES (@rp,@sdate,@edate,'',null,null,null,@reason,getdate())";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@rp", rp);
                cmd.Parameters.AddWithValue("@sdate", sdate);
                cmd.Parameters.AddWithValue("@edate", edate);
                cmd.Parameters.AddWithValue("@reason", txtReason.Text);
                cmd.ExecuteNonQuery();
                con.Close(); 
                btnSaveOk.Text = "Ok";
                dtpSdate.Enabled = false;
                dtpEdate.Enabled = false;
            }
            else
            {
                this.Close();
            }
        }

        private void txtReason_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (btnSaveOk.Text != "Save")
            {
                e.Handled = true;
            }
        }

    }
}
