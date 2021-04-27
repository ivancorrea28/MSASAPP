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
    public partial class frmTickDoc : Form
    {
        public frmTickDoc()
        {
            InitializeComponent();
        }
        public static string symbols = "";
        public static string rp = "";
        public static string terminal = "";
        public static string date = "";
        public static string colName = "";
        string remarks = "";
        public static bool viewing = false;
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!viewing)
            {
                symbols = "";
                if (chkDoc1.Checked)
                {
                    symbols += chkDoc1.Text;
                }
                if (chkDoc2.Checked)
                {
                    symbols += chkDoc2.Text;
                }
                if (chkDoc3.Checked)
                {
                    symbols += chkDoc3.Text;
                }
                if (chkDoc4.Checked)
                {
                    symbols += chkDoc4.Text;
                }
                if (txtDoc1.Text != "")
                {
                    remarks += "1. " + txtDoc1.Text + "+/";
                }
                if (txtDoc2.Text != "")
                {
                    remarks += "2. " + txtDoc2.Text + "+/";
                }
                if (txtDoc3.Text != "")
                {
                    remarks += "3. " + txtDoc3.Text + "+/";
                }
                if (txtDoc4.Text != "")
                {
                    remarks += "4. " + txtDoc4.Text + "+/";
                }
                //MessageBox.Show(symbols);
                //MessageBox.Show(remarks);
                updateSymbol();
            }
            this.Close();
        }
        void updateSymbol()
        { 
            con.Open();
            string sqlCount = " SELECT COUNT(*) FROM DailySuppDocTick WHERE tenantcode=@rp AND date=@date AND machine=@terminal";
            SqlCommand cmdCount = new SqlCommand(sqlCount, con);
            cmdCount.Parameters.AddWithValue("rp", rp);
            cmdCount.Parameters.AddWithValue("date", date);
            cmdCount.Parameters.AddWithValue("terminal", terminal);
            int count=(int)cmdCount.ExecuteScalar() ;
            if(count ==0 && (chkDoc1.Checked ||chkDoc2.Checked||chkDoc3.Checked ||chkDoc4.Checked)){
                //Insert
                string sqlIns = "INSERT INTO DailySuppDocTick(tenantcode,date,machine) VALUES(@rp,@date,@terminal)";
                SqlCommand cmdIns = new SqlCommand(sqlIns, con);
                cmdIns.Parameters.AddWithValue("rp", rp);
                cmdIns.Parameters.AddWithValue("date", date);
                cmdIns.Parameters.AddWithValue("terminal", terminal);
                cmdIns.ExecuteNonQuery();
            }
            //if 
            string val = "@val";
            string remarkList = "@remark";
            if(!chkDoc1.Checked&&!chkDoc2.Checked&&!chkDoc3.Checked&&!chkDoc4.Checked) 
                val="null";
            if(txtDoc1.Text=="" &&txtDoc2.Text=="" &&txtDoc3.Text=="" &&txtDoc4.Text=="")
                remarkList="null";
            //if((initialDoc1||initialDoc2||initialDoc3||initialDoc4)&&(chkDoc1.Checked ||chkDoc2.Checked||chkDoc3.Checked ||chkDoc4.Checked)){ 
                string sql = "UPDATE DailySuppDocTick SET " + colName + "Doc="+val+", " + colName + "Remarks="+remarkList+" WHERE tenantcode=@rp AND date=@date AND machine=@terminal";
            
                SqlCommand cmd = new SqlCommand(sql, con);
                //MessageBox.Show(sql);
                cmd.Parameters.AddWithValue("rp", rp);
                cmd.Parameters.AddWithValue("date", date);
                cmd.Parameters.AddWithValue("terminal", terminal);
                cmd.Parameters.AddWithValue("val", symbols);
                cmd.Parameters.AddWithValue("remark", remarks);
                cmd.ExecuteNonQuery();
                //}
            con.Close();
        }
        SqlConnection con;
        string startingSymbol = "";
        private void frmTickDoc_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(LoginForm.localConnectionString);
            switch (colName)
            {
                case "ServiceCharge":  case "SERVICE CHARGE":
                    colName="surcharge";
                    break;
                case "OtherDiscount": case "OTHER DISC":
                    colName = "other";
                    break;
                case "SeniorDiscount": case "SENIOR DISC":
                    colName = "senior";
                    break;
                case "VAT-Exempt": case "VAT EXEMPT SALES":
                    colName = "vat";
                    break;
                case "GC/Others": case "GC / OTHERS":
                    colName = "gift";
                    break; 
            }
            //MessageBox.Show(colName);
            loadDocTicks();
            if(viewing){
                btnAllDocs.Visible = false;
                btnMainDocs.Visible = false;
                //btnOK.Visible = false;
                chkDoc1.Enabled = false;
                chkDoc2.Enabled = false;
                chkDoc3.Enabled = false;
                chkDoc4.Enabled = false;
                txtDoc1.Enabled = false;
                txtDoc2.Enabled = false;
                txtDoc3.Enabled = false;
                txtDoc4.Enabled = false;
            }
        }
        bool initialDoc1 = false;
        bool initialDoc2 = false;
        bool initialDoc3 = false;
        bool initialDoc4 = false;

        void loadDocTicks()
        {
            con.Open();
            string sql = " SELECT "+colName+"Doc,"+colName+"Remarks FROM DailySuppDocTick WHERE tenantcode=@rp AND date=@date AND machine=@terminal"; 
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("rp", rp);
            cmd.Parameters.AddWithValue("date", date);
            cmd.Parameters.AddWithValue("terminal", terminal);
            SqlDataReader sRead=cmd.ExecuteReader();
            string docs = "";
            string docRemarks = "";
            while(sRead.Read()){
                docs=sRead[0].ToString();
                docRemarks = sRead[1].ToString();
            }
            if (docs.Contains("^"))
            {
                chkDoc1.Checked = true;
                initialDoc1 = true;
            }
            if (docs.Contains("/"))
            {
                chkDoc2.Checked = true;
                initialDoc2 = true;
            }
            if (docs.Contains("*"))
            {
                chkDoc3.Checked = true;
                initialDoc3 = true;
            }
            if (docs.Contains("@"))
            {
                chkDoc4.Checked = true;
                initialDoc4 = true;
            } 
            for (int i = 1; i <= 4 && docRemarks.Contains("+/");i++ )
            {
                string remark = docRemarks.Substring(3, docRemarks.IndexOf("+/") - 3);
                if (docRemarks.Contains("1. "))
                {
                    txtDoc1.Text = remark;
                }
                if (docRemarks.Contains("2. "))
                {
                    txtDoc2.Text = remark;
                }
                if (docRemarks.Contains("3. "))
                {
                    txtDoc3.Text = remark;
                }
                if (docRemarks.Contains("4. "))
                {
                    txtDoc4.Text = remark;
                }
                docRemarks = docRemarks.Substring(docRemarks.IndexOf("+/")+2);
            }
            con.Close();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnAllDocs_Click(object sender, EventArgs e)
        {
            chkDoc1.Checked = true;
            chkDoc2.Checked = true;
            chkDoc3.Checked = true;
            chkDoc4.Checked = true;
        }

        private void btnMainDocs_Click(object sender, EventArgs e)
        {
            chkDoc1.Checked = true;
            chkDoc2.Checked = true;
            chkDoc3.Checked = true;
            chkDoc4.Checked = false;
        }
    }
}
