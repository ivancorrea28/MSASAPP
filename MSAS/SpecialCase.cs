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
    public partial class SpecialCase : Form
    {
        public SpecialCase()
        {
            InitializeComponent();
        }
        //The Values of these Variables are set from the parent form
        public static string action;
        public static string rp;
        public static string monthYear;
        public static string loc;
        public static string rpName;

        string conString = LoginForm.localConnectionString;
        SqlConnection con;
        private void SpecialCase_Load(object sender, EventArgs e)
        {
            //cmbCase.Items.Add("VES Breakdown");
            cmbCase.Items.Add("Sales Breakdown");
            //cmbCase.SelectedItem
            if ((action == "EDIT") || (action == "VIEW"))
            {
            }
            else
            { 
                this.Close();
            }
            con = new SqlConnection(conString);
            if(action=="EDIT"){
            }
            else if(action=="VIEW")
            {
                dgvSalesBreakdown.Location = new Point(10, 10);
                dgvSalesBreakdown.Height = this.Height - 50;
                dgvSalesBreakdown.Width = this.Width - 50;
                cmbCase.Visible = false;
                lblDescription.Visible = false;
                lblGSC.Visible = false;
                lblONV.Visible = false;
                lblVES.Visible = false;
                cmbDescription.Visible = false;
                txtGSC.Visible = false;
                txtONV.Visible = false;
                txtVES.Visible = false;
                btnAdd.Visible = false;
                btnDelete.Visible = false;
                chkSublease.Visible = false;
            }
            cmbCase.SelectedIndex = 0;
            loadBreakdown();
        }
        void loadBreakdown() {
            string sql = "SELECT DataClassification,Descript AS Description,SalesCurrentMonth AS GSC,VatESales AS VES,OtherNVSales AS OtherNonVat FROM PUBLISHREPORTSBDN WHERE tenantcode=@rp AND MonthYear=@monthYear";
            
            SqlConnection loadCon = new SqlConnection(conString);
            loadCon.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("rp", rp);
            cmd.Parameters.AddWithValue("monthYear", monthYear);
            //cmd.ExecuteReader(); ;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvSalesBreakdown.DataSource = dt;
            loadCon.Close();
            for (int i = 0; i < dgvSalesBreakdown.Rows.Count; i++)
            {
                if (dgvSalesBreakdown.Rows[i].Cells[0].Value.ToString() == "Dual Classification")
                {
                    dgvSalesBreakdown.Rows[i].Cells[0].Value = "VES Breakdown";
                }
                string desc = dgvSalesBreakdown.Rows[i].Cells[1].Value.ToString().ToUpper() ;
                if(desc.Contains("&&")){ // FORMAT TEXT REMOVE 'RPNAME + && '
                    dgvSalesBreakdown.Rows[i].Cells[1].Value = desc.Substring(desc.LastIndexOf("&&")+3);
                }
            }
        }

        private void cmbCase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (action == "EDIT")
            {
                string specialCase=cmbCase.SelectedItem.ToString();
                switch (specialCase)
                {
                    case "Sublease": txtONV.Visible = false;
                        txtVES.Visible = false;
                        txtGSC.Visible = true;
                        lblONV.Visible = false;
                        lblVES.Visible = false;
                        lblGSC.Visible = true;
                        break;
                    case "VES Breakdown": txtONV.Visible = true;
                        txtVES.Visible = true;
                        txtGSC.Visible = false;
                        lblONV.Visible = true;
                        lblVES.Visible = true;
                        lblGSC.Visible = false;
                        chkSublease.Visible = false;
                        break;
                    case "Sales Breakdown": txtONV.Visible = true;
                        txtVES.Visible = true;
                        txtGSC.Visible = true;
                        lblONV.Visible = true;
                        lblVES.Visible = true;
                        lblGSC.Visible = true;
                        chkSublease.Visible = true;
                        break;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool hasError = false;
            if(cmbDescription.Text==""){
                hasError = true;
                cmbDescription.Focus();
            } 
            cmbDescription.Text = cmbDescription.Text.ToUpper();



            //Values Handler

            string specialCase = cmbCase.SelectedItem.ToString();
            switch (specialCase)
            {
                case "Sublease":
                    txtVES.Text = "";
                    txtONV.Text = "";
                    if (txtGSC.Text == "")
                    {
                        MessageBox.Show("Amount is Required!");
                        txtGSC.Focus();
                        hasError = true;
                    }
                    break;
                case "VES Breakdown":
                    txtGSC.Text = "";
                    if (txtVES.Text == "" && txtONV.Text=="")
                    {
                        MessageBox.Show("Please Input an Amount!");
                        //txtGSC.Focus();
                        hasError = true;
                    }
                    break;
                case "Sales Breakdown":
                    if (txtGSC.Text == "")
                    {
                        MessageBox.Show("Amount is Required!");
                        txtGSC.Focus();
                        hasError = true;
                    }
                    break;
            }
            string inputtedClassification = "";
            for (int i = 0; i < dgvSalesBreakdown.Rows.Count; i++)
            {
                inputtedClassification += dgvSalesBreakdown.Rows[i].Cells[0].Value.ToString()+", ";
            }
                if (!hasError)
                {
                    string dataCLass = "";
                    if (cmbCase.SelectedItem.ToString() == "VES Breakdown")
                    {
                        dataCLass = "Dual Classification";
                    }
                    else if (cmbCase.SelectedItem.ToString() == "Sales Breakdown" && chkSublease.Checked)
                    {
                        dataCLass = "Sublease";
                    }
                    else
                    {
                        dataCLass = cmbCase.SelectedItem.ToString();
                    }
                    if (!inputtedClassification.Contains(dataCLass) && inputtedClassification != "") {
                        MessageBox.Show(dataCLass+" is not allowed"+Environment.NewLine
                            + "You can only input 1 type of Classification" + Environment.NewLine
                            + "Check/Uncheck Sublease to Continue");
                    }
                    else if (rpName == cmbDescription.Text && chkSublease.Checked)
                    {
                        MessageBox.Show("Cannot Input Mother Tenant as Sublease");
                    }
                    else
                    {

                        con.Open();
                        double gsc = Convert.ToDouble(txtGSC.Text == "" ? "0" : txtGSC.Text);
                        double ves = Convert.ToDouble(txtVES.Text == "" ? "0" : txtVES.Text);
                        double onv = Convert.ToDouble(txtONV.Text == "" ? "0" : txtONV.Text);
                        string strVes = (txtVES.Text == "" && txtONV.Text == "" ? "null" : "@vat");
                        string strOnv = (txtONV.Text == "" && txtVES.Text == "" ? "null" : "@onv"); 
                        for (int i = 0; i < dgvSalesBreakdown.Rows.Count; i++)
                        {
                            if ((strVes!="@vat"&&strOnv!="@onv")&&(dgvSalesBreakdown.Rows[i].Cells[3].Value.ToString() != "" || dgvSalesBreakdown.Rows[i].Cells[4].Value.ToString() != ""))
                            {
                                strVes = "@vat";
                                strOnv = "@onv";
                                break;
                            }
                        }
                        string sql = "INSERT INTO PUBLISHREPORTSBDN VALUES(null,@loc,@rp,@gsc," + strVes + "," + strOnv + ",@monthYear,@desc,@auditor,@class)";
                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.Parameters.AddWithValue("@loc", loc);
                        cmd.Parameters.AddWithValue("@rp", rp);
                        cmd.Parameters.AddWithValue("@gsc", gsc);
                        cmd.Parameters.AddWithValue("@vat", ves);
                        cmd.Parameters.AddWithValue("@onv", onv);
                        cmd.Parameters.AddWithValue("@monthYear", monthYear);
                        cmd.Parameters.AddWithValue("@desc", rpName + " && " + cmbDescription.Text);
                        cmd.Parameters.AddWithValue("@auditor", AuditSchedule.auditor);
                        cmd.Parameters.AddWithValue("@class", dataCLass);

                        try
                        {
                            cmd.ExecuteNonQuery();
                            txtGSC.Text = "";
                            txtVES.Text = "";
                            txtONV.Text = "";
                        }
                        catch (Exception er)
                        {
                            MessageBox.Show("Error: " + er);
                        }
                        int blankCount = 0;
                        int numberCount = 0; 
                        loadBreakdown();
                        for (int i = 0; i < dgvSalesBreakdown.Rows.Count; i++)
                        {
                            if (dgvSalesBreakdown.Rows[i].Cells[3].Value.ToString() != "" || dgvSalesBreakdown.Rows[i].Cells[4].Value.ToString() != "")
                            {
                                numberCount++;
                            }
                            else
                            {
                                blankCount++;
                            }
                        }
                        if(blankCount>0 && numberCount>0){
                            string sqlUpdate = "UPDATE PUBLISHREPORTSBDN SET VATESALES=0.00, OtherNVSales=0.00 WHERE tenantcode=@rp AND Monthyear=@monthYear AND (VATESALES IS NULL OR OTHERNVSales IS NULL)";
                            SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, con);
                            cmdUpdate.Parameters.AddWithValue("rp",rp);
                            cmdUpdate.Parameters.AddWithValue("@monthYear", monthYear);
                            cmdUpdate.ExecuteNonQuery();
                        }
                        con.Close();
                        loadBreakdown();

                    }

                }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSalesBreakdown.Rows.Count > 0)
            {
                int selectedRow = Convert.ToInt32(dgvSalesBreakdown.SelectedCells[0].RowIndex);
                DialogResult dialogResult = MessageBox.Show("Delete " + dgvSalesBreakdown.Rows[selectedRow].Cells[0].Value.ToString() +" : "+ dgvSalesBreakdown.Rows[selectedRow].Cells[1].Value.ToString(), "Some Title", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    con.Open();
                    string dataClass = "";
                    if (dgvSalesBreakdown.Rows[selectedRow].Cells[0].Value.ToString() == "VES Breakdown")
                    {
                        dataClass = "Dual Classification";
                    }
                    else
                    {
                        dataClass = dgvSalesBreakdown.Rows[selectedRow].Cells[0].Value.ToString();
                    }
                    string whereGSC = (dgvSalesBreakdown.Rows[selectedRow].Cells[2].Value.ToString()  == "" ? "" : "AND SalesCurrentMonth=@gsc");
                    string whereVES = (dgvSalesBreakdown.Rows[selectedRow].Cells[3].Value.ToString() == "" ? "" : "AND VatESales=@vat");
                    string whereONV = (dgvSalesBreakdown.Rows[selectedRow].Cells[4].Value.ToString() == "" ? "" : "AND OtherNVSales=@onv");
                    string sql = "DELETE FROM PUBLISHREPORTSBDN WHERE tenantcode=@rp AND Descript=@desc  "+whereGSC+" "+whereVES+" "+whereONV+" AND MonthYear=@monthYear AND DataClassification=@class";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@loc", loc);
                    cmd.Parameters.AddWithValue("@rp", rp);
                    cmd.Parameters.AddWithValue("@gsc", dgvSalesBreakdown.Rows[selectedRow].Cells[2].Value.ToString());
                    cmd.Parameters.AddWithValue("@vat", dgvSalesBreakdown.Rows[selectedRow].Cells[3].Value.ToString());
                    cmd.Parameters.AddWithValue("@onv", dgvSalesBreakdown.Rows[selectedRow].Cells[4].Value.ToString());
                    cmd.Parameters.AddWithValue("@monthYear", monthYear);
                    cmd.Parameters.AddWithValue("@desc", rpName+" && "+dgvSalesBreakdown.Rows[selectedRow].Cells[1].Value.ToString());
                    cmd.Parameters.AddWithValue("@class", dataClass);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    loadBreakdown();
                }
                
            }
        }

        private void txtGSC_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Number,dot,negativeSIgn Only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
            if ((txtGSC.Text.IndexOf('.') >= 0) && (e.KeyChar == '.'))
            {//Only one dot (.)
                e.Handled = true;
            }
            if ((e.KeyChar == '-') && (txtGSC.Text.Length > 0 || (txtGSC.Text.IndexOf('-') == 0)))
            {//Only one negative sign (-) and starting position only
                e.Handled = true;
            }
            if (e.KeyChar == '.' && txtGSC.Text.IndexOf('-') == 0 && txtGSC.Text.Length == 1)
            {//dot(.) cannot be next to negative sign(-)
                e.Handled = true;
            }
        }

        private void txtVES_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Number,dot,negativeSIgn Only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
            if ((txtVES.Text.IndexOf('.') >= 0) && (e.KeyChar == '.'))
            {//Only one dot (.)
                e.Handled = true;
            }
            if ((e.KeyChar == '-') && (txtVES.Text.Length > 0 || (txtVES.Text.IndexOf('-') == 0)))
            {//Only one negative sign (-) and starting position only
                e.Handled = true;
            }
            if (e.KeyChar == '.' && txtVES.Text.IndexOf('-') == 0 && txtVES.Text.Length == 1)
            {//dot(.) cannot be next to negative sign(-)
                e.Handled = true;
            }
        }

        private void txtONV_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Number,dot,negativeSIgn Only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
            if ((txtONV.Text.IndexOf('.') >= 0) && (e.KeyChar == '.'))
            {//Only one dot (.)
                e.Handled = true;
            }
            if ((e.KeyChar == '-') && (txtONV.Text.Length > 0 || (txtONV.Text.IndexOf('-') == 0)))
            {//Only one negative sign (-) and starting position only
                e.Handled = true;
            }
            if (e.KeyChar == '.' && txtONV.Text.IndexOf('-') == 0 && txtONV.Text.Length == 1)
            {//dot(.) cannot be next to negative sign(-)
                e.Handled = true;
            }
        }

        private void cmbDescription_DropDown(object sender, EventArgs e)
        {
            cmbDescription.Items.Clear();
            con.Open();
            string sql = "SELECT DISTINCT(Descript) FROM PublishReportSBDN WHERE tenantcode=@rp ORDER BY 1";
            SqlCommand cmd = new SqlCommand(sql,con);
            cmd.Parameters.AddWithValue("rp", rp);
            SqlDataReader sReader=cmd.ExecuteReader();
            while(sReader.Read()){
                string desc = sReader[0].ToString().Trim().ToUpper(); 
                cmbDescription.Items.Add((desc.Contains("&&") ? desc.Substring(desc.LastIndexOf("&&") + 3) : desc));
            }
            con.Close();
            cmbDescription.DropDownWidth = DropDownWidth(cmbDescription);
        }
        int DropDownWidth(ComboBox myCombo)
        {
            int maxWidth = cmbDescription.DropDownWidth;
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
    }
}
