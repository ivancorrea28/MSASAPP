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
    public partial class FindingsInfo : Form
    {
        public FindingsInfo()
        {
            InitializeComponent();
        }
        string localConnection = LoginForm.localConnectionString;
        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Number,dot,negativeSIgn Only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
            if ((txtAmount.Text.IndexOf('.') >= 0)&&(e.KeyChar == '.'))
            {//Only one dot (.)
                e.Handled = true;
            }
            if ((e.KeyChar == '-') && (txtAmount.Text.Length >0 ||(txtAmount.Text.IndexOf('-') == 0)))
            {//Only one negative sign (-) and starting position only
                e.Handled = true;
            }
            if (e.KeyChar == '.' && txtAmount.Text.IndexOf('-') == 0 && txtAmount.Text.Length ==1)
            {//dot(.) cannot be next to negative sign(-)
                e.Handled = true;
            }

        }
        int[] component = new int[100];
        int[] classification = new int[100];
        int[] NOE = new int[100];
        private void FindingsInfo_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(localConnection);
            con.Open();
            string sql;
            sql = "SELECT * FROM RPSMSComponent ORDER BY 1";
            SqlCommand cmd1 = new SqlCommand(sql,con);
            SqlDataReader sReader1 =cmd1.ExecuteReader();
            int arraySize = 0;
            while(sReader1.Read()){
                component[arraySize] = Convert.ToInt32(sReader1["ComponentID"]);
                cmbComponent.Items.Add(sReader1["Component"].ToString());
                arraySize += 1;
            }
            sReader1.Close();
            Array.Resize(ref component,arraySize);

            arraySize=0;
            sql = "SELECT * FROM ProblemClass ORDER BY 1";
            SqlCommand cmd2 = new SqlCommand(sql, con);
            SqlDataReader sReader2 = cmd2.ExecuteReader();
            while (sReader2.Read())
            {
                classification[arraySize] = Convert.ToInt32(sReader2["ClassID"]);
                cmbClassification.Items.Add(sReader2["Classification"].ToString());
                arraySize += 1;
            }
            sReader2.Close();
            Array.Resize(ref classification, arraySize);

            con.Close();

        }

        private void cmbClassification_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(cmbClassification.SelectedItem.ToString());
            cmbNOE.Items.Clear();
            NOE = new int[100];
            SqlConnection con = new SqlConnection(localConnection);
            con.Open();
            string sql;
            sql = "SELECT * FROM NatureofError WHERE Classification=@classify ORDER BY 1";
            SqlCommand cmd1 = new SqlCommand(sql, con);
            cmd1.Parameters.AddWithValue("classify", cmbClassification.SelectedItem.ToString());
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
        public static string compID;
        public static string comp;
        public static string clasID;
        public static string clas;
        public static string NOEID;
        public static string NoE;
        public static string amount;
        public static string remarks;
        private void btnOk_Click(object sender, EventArgs e)
        {
            if(validation()){
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
                    rdbText = rdbNonRecur.Text;
                }
                //
                EditWorkingPaper.fCashDep = chkDeposits.Checked;
                EditWorkingPaper.fReading = chkReadings.Checked;
                EditWorkingPaper.fMSR = chkMSR.Checked;
                EditWorkingPaper.fChargeDep = chkOther.Checked;

                compID = component[cmbComponent.SelectedIndex].ToString();
                comp = cmbComponent.SelectedItem.ToString();
                clasID = classification[cmbClassification.SelectedIndex].ToString();
                clas = cmbClassification.SelectedItem.ToString();
                NOEID = NOE[cmbNOE.SelectedIndex].ToString();
                NoE = cmbNOE.SelectedItem.ToString();
                amount = txtAmount.Text;
                remarks = txtRemarks.Text;
                //Add Supporting Docs Remarks
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
                    if (chkMSR.Checked)
                    {
                        remarks += "Cash/Credit Card Deposit, ";
                    }
                    if (chkOther.Checked)
                    {
                        remarks += "Other Document, ";
                    }
                    remarks = remarks.Substring(0, remarks.LastIndexOf(','));
                    remarks += ".";
                }

                //Add RadioButton Remarks
                remarks +=" - "+rdbText; 
                AddFindings.yes = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please fill up all the required Fields.");
            }
            
        }
        public bool validation()
        {
            bool returnValue = true;
            if(cmbClassification.SelectedIndex<0){
                returnValue = false;
            }
            else if (cmbComponent.SelectedIndex < 0)
            {
                returnValue = false;
            }else if(cmbNOE.SelectedIndex<0)
            {
                returnValue = false;
            }
            else if (txtAmount.Text == "")
            {
                returnValue = false;
            }
            return returnValue;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FindingsInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(AddFindings.yes == true){

            }else{
                DialogResult dr =MessageBox.Show("Cancel Add Findings?","Warning",MessageBoxButtons.OKCancel);
                if(dr!=DialogResult.OK){
                    e.Cancel = true;
                }
            }
        }
    }
}
