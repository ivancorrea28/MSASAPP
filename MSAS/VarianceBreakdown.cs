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
    public partial class VarianceBreakdown : Form
    {
        public VarianceBreakdown()
        {
            InitializeComponent();
        }

        SqlConnection con;
        private void VarianceBreakdown_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(LoginForm.localConnectionString);
            if (lblComponent.Text == "Cash")
            {
                component = 1;
            }
            else if (lblComponent.Text == "Charge")
            {
                component = 2;
            }
            else if (lblComponent.Text == "GC/Others")
            {
                component = 3;
            }
            else if (lblComponent.Text == "SeniorDiscount")
            {
                component = 4;
            }
            else if (lblComponent.Text == "OtherDiscount")
            {
                component = 5;
            }
            else if (lblComponent.Text == "ServiceCharge")
            {
                component = 6;
            }
            cmbComponent.Items.Add("Select Component Misclassification");
            cmbComponent.Items.Add("Cash");
            cmbComponent.Items.Add("Charge");
            cmbComponent.Items.Add("GC/Others");
            //cmbComponent.Items.Add("SeniorDiscount");
            //cmbComponent.Items.Add("OtherDiscount");
            //cmbComponent.Items.Add("ServiceCharge");
            cmbComponent.SelectedIndex = 0;
            loadValues();
            oldTP = txtTxtProb.Text;
            oldMisclass = txtMisclass.Text;
            oldOtherF = txtOtherFind.Text;
            oldUnreported = txtUnrep.Text;

            //10-13-2020 , Textboxes not combo box anymore
            if (lblComponent.Text == lblCash.Text)
            {
                txtCash.Visible = false;
            }else if (lblComponent.Text == lblCharge.Text)
            {
                txtCharge.Visible = false;
            }else if (lblComponent.Text == lblGC.Text)
            {
                txtGC.Visible = false;
            }
            else
            {
                txtCash.Visible = false;
                txtCharge.Visible = false;
                txtGC.Visible = false;
            }
        }
        public bool undo = false;
        public bool redo = false;
        public string oldTP = "";
        public string newTP = "";
        public string oldMisclass = "";
        public string newMisclass = "";
        public string oldOtherF = "";
        public string newOtherF = "";
        public string oldUnreported = "";
        public string newUnreported = "";

        public void loadValues()
        {
            if(undo||redo){
                //Textbox Values loaded from Edit WP 
            }
            else
            {
                con.Open();
                string sql = "SELECT Classification,amount FROM VarianceBreakdown WHERE tenantcode=@rp AND machine=@terminal  AND date=@date AND component=@comp ORDER BY 1";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("rp", rpcode);
                cmd.Parameters.AddWithValue("terminal", terminal);
                cmd.Parameters.AddWithValue("comp", component);
                cmd.Parameters.AddWithValue("date", lblDate.Text);
                SqlDataReader sread = cmd.ExecuteReader();
                while (sread.Read())
                {
                    switch ((int)sread[0])
                    {
                        case 1:
                            txtTxtProb.Text = sread[1].ToString();
                            break;
                        case 2:
                            txtMisclass.Text = sread[1].ToString();
                            break;
                        case 3:
                            txtOtherFind.Text = sread[1].ToString();
                            break;
                        case 4:
                            txtUnrep.Text = sread[1].ToString();
                            break;
                    } 
                }
                con.Close();
            }
            
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            EditWorkingPaper.saveBreakdown = false;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            double[] values = new double[4];
            double[] misclassifiedValues = new double[3];
            double misclassifiedTotal = 0.00;
            //Get Misclassified Values
            misclassifiedValues[0] += (txtCash.Text == "" ? 0.00 : Convert.ToDouble(txtCash.Text));
            misclassifiedValues[1] += (txtCharge.Text == "" ? 0.00 : Convert.ToDouble(txtCharge.Text));
            misclassifiedValues[2] += (txtGC.Text == "" ? 0.00 : Convert.ToDouble(txtGC.Text));
            //Total
            for (int i = 0; i < misclassifiedValues.Length; i++)
            {
                misclassifiedTotal += misclassifiedValues[i];
            } 
            //Get Classification Breakdown Values
            values[0] = (txtTxtProb.Text == "" ? 0.00 : Convert.ToDouble(txtTxtProb.Text));
            values[1] = (misclassifiedTotal != 0 ? misclassifiedTotal : (txtMisclass.Text == "" ? 0.00 : Convert.ToDouble(txtMisclass.Text)));
            values[2] = (txtOtherFind.Text == "" ? 0.00 : Convert.ToDouble(txtOtherFind.Text));
            values[3] = (txtUnrep.Text == "" ? 0.00 : Convert.ToDouble(txtUnrep.Text));
            double variance = Convert.ToDouble(txtVariance.Text);
            double total = 0;
            for (int i = 0; i < values.Length; i++)
            {
                total += values[i];
                //MessageBox.Show(values[i].ToString());
            }
            //MessageBox.Show(total.ToString("#,0.00"));
            //MessageBox.Show(variance.ToString("#,0.00"));
            //MessageBox.Show(values[1].ToString() + " total: " +total.ToString());

            //MessageBox.Show(total.ToString() + "vs " + variance.ToString());
            if (total.ToString("#,0.00") != variance.ToString("#,0.00"))
            {
                MessageBox.Show("Total Breakdown is not equal to Variance");
            } 
            
            //else if(txtMisclass.Text!="" && cmbComponent.SelectedIndex<0){
            //    MessageBox.Show("Select Component for Misclassified");
            //}
            //else if(lblComponent.Text == cmbComponent.SelectedItem.ToString()){
            //    MessageBox.Show("Selected Component cannot be the same");
            //}
            else
            {
                saveBreakdown(values);
                if (!undo)
                {
                    newTP = txtTxtProb.Text;
                    newMisclass = txtMisclass.Text;
                    newUnreported = txtUnrep.Text;
                    newOtherF = txtOtherFind.Text;
                }
                //Misclassified Components
                if (txtCash.Text != "" || txtCharge.Text != ""|| txtGC.Text!="")
                {
                    saveMisclassifiedTo(misclassifiedValues);//Will Save Misclassified to if There are value(s)
                    EditWorkingPaper.misclassBreakdown = true;
                    EditWorkingPaper.misclassValue = misclassifiedValues;
                }
                deleteZeroAmount();
                this.Close();
            }
        }

        public static string rpcode;
        public static string terminal;
        int component=0;
        void deleteZeroAmount()
        {
            con.Open();
            string sql = "DELETE FROM VarianceBreakdown WHERE amount=0";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void saveBreakdown(double[] values)
        {
            con.Open();
            for (int i = 0; i < values.Length; i++)
            { 
                if (true)//previously value !=0
                {
                    string sqlCount = "SELECT COUNT(*) FROM VarianceBreakdown WHERE tenantcode=@rp AND machine=@terminal AND date=@date AND classification=@class AND component=@comp";
                    SqlCommand cmdCount = new SqlCommand(sqlCount, con);
                    cmdCount.Parameters.AddWithValue("rp", rpcode);
                    cmdCount.Parameters.AddWithValue("terminal", terminal);
                    cmdCount.Parameters.AddWithValue("date", lblDate.Text);
                    cmdCount.Parameters.AddWithValue("comp", component);
                    cmdCount.Parameters.AddWithValue("class", i + 1);
                    int count = (int)cmdCount.ExecuteScalar();
                    //MessageBox.Show(count.ToString() + " and valuetoinsert: "+values[i].ToString());
                    if (count == 0 && values[i] != 0)//Check if may existing
                    {
                        string sql = "INSERT INTO VarianceBreakdown VALUES(@rp,@terminal,@date,@class,@comp,@amount,null)";
                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.Parameters.AddWithValue("rp", rpcode);
                        cmd.Parameters.AddWithValue("terminal", terminal);
                        cmd.Parameters.AddWithValue("date", lblDate.Text);
                        cmd.Parameters.AddWithValue("comp", component);
                        cmd.Parameters.AddWithValue("class", i + 1);
                        cmd.Parameters.AddWithValue("amount", values[i]);
                        cmd.ExecuteNonQuery();
                        //MessageBox.Show("Passed Insert Self amount value:" + values[i].ToString());
                    }
                    else//else update
                    {
                        double currentValue = 0.00; 
                        string sql = "UPDATE VarianceBreakdown SET amount=@amount WHERE tenantcode=@rp AND machine=@terminal AND date=@date AND classification=@class AND component=@comp";
                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.Parameters.AddWithValue("rp", rpcode);
                        cmd.Parameters.AddWithValue("terminal", terminal);
                        cmd.Parameters.AddWithValue("date", lblDate.Text);
                        cmd.Parameters.AddWithValue("class", i + 1);
                        cmd.Parameters.AddWithValue("comp", component);
                        cmd.Parameters.AddWithValue("amount", values[i]+currentValue);
                        cmd.ExecuteNonQuery();
                        //MessageBox.Show("Passed Update Self amount value:" + values[i].ToString());
                    }
                } 
            }
            con.Close();
        }
        void saveMisclassifiedTo(double[] values)
        {
            con.Open();
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = -1*values[i];
                string sqlCount = "SELECT COUNT(*) FROM VarianceBreakdown WHERE tenantcode=@rp AND machine='"+terminal+"' AND date=@date AND classification=@class AND component=@comp";
                SqlCommand cmdCount = new SqlCommand(sqlCount, con);
                cmdCount.Parameters.AddWithValue("rp", rpcode);
                cmdCount.Parameters.AddWithValue("terminal", terminal);
                cmdCount.Parameters.AddWithValue("date", lblDate.Text);
                cmdCount.Parameters.AddWithValue("comp", i+1);
                cmdCount.Parameters.AddWithValue("class", 2);
                if ((int)cmdCount.ExecuteScalar() == 0 && values[i] != 0)//Check if may existing
                {
                    string sql = "INSERT INTO VarianceBreakdown VALUES(@rp,@terminal,@date,@class,@comp,@amount,null)";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("rp", rpcode);
                    cmd.Parameters.AddWithValue("terminal", terminal);
                    cmd.Parameters.AddWithValue("date", lblDate.Text);
                    cmd.Parameters.AddWithValue("comp", i+1);
                    cmd.Parameters.AddWithValue("class",2);
                    cmd.Parameters.AddWithValue("amount", values[i]);
                    cmd.ExecuteNonQuery();
                    //MessageBox.Show("Passed Insert amount value:" + values[i].ToString());
                }
                else if (values[i]!=0)//else update
                {
                    double currentValue = 0.00;
                    string sql = "UPDATE VarianceBreakdown SET amount=@amount WHERE tenantcode=@rp AND machine=@terminal AND date=@date AND classification=@class AND component=@comp";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("rp", rpcode);
                    cmd.Parameters.AddWithValue("terminal", terminal);
                    cmd.Parameters.AddWithValue("date", lblDate.Text);
                    cmd.Parameters.AddWithValue("comp", i + 1);
                    cmd.Parameters.AddWithValue("class", 2);
                    cmd.Parameters.AddWithValue("amount", values[i] + currentValue);
                    cmd.ExecuteNonQuery();
                    //MessageBox.Show("Passed Update amount value:" + values[i].ToString());
                }
            }
            con.Close();
        }
        private void txtTxtProb_KeyPress(object sender, KeyPressEventArgs e)
        {

            //Number,dot,negativeSIgn Only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
            if ((txtTxtProb.Text.IndexOf('.') >= 0) && (e.KeyChar == '.'))
            {//Only one dot (.)
                e.Handled = true;
            }
            if ((e.KeyChar == '-') && (txtTxtProb.Text.Length > 0 || (txtTxtProb.Text.IndexOf('-') == 0)))
            {//Only one negative sign (-) and starting position only
                e.Handled = true;
            }
            if (e.KeyChar == '.' && txtTxtProb.Text.IndexOf('-') == 0 && txtTxtProb.Text.Length == 1)
            {//dot(.) cannot be next to negative sign(-)
                e.Handled = true;
            }
        }

        private void txtMisclass_KeyPress(object sender, KeyPressEventArgs e)
        {

            //Number,dot,negativeSIgn Only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
            if ((txtMisclass.Text.IndexOf('.') >= 0) && (e.KeyChar == '.'))
            {//Only one dot (.)
                e.Handled = true;
            }
            if ((e.KeyChar == '-') && (txtMisclass.Text.Length > 0 || (txtMisclass.Text.IndexOf('-') == 0)))
            {//Only one negative sign (-) and starting position only
                e.Handled = true;
            }
            if (e.KeyChar == '.' && txtMisclass.Text.IndexOf('-') == 0 && txtMisclass.Text.Length == 1)
            {//dot(.) cannot be next to negative sign(-)
                e.Handled = true;
            }
        }

        private void txtUnrep_KeyPress(object sender, KeyPressEventArgs e)
        {

            //Number,dot,negativeSIgn Only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
            if ((txtUnrep.Text.IndexOf('.') >= 0) && (e.KeyChar == '.'))
            {//Only one dot (.)
                e.Handled = true;
            }
            if ((e.KeyChar == '-') && (txtUnrep.Text.Length > 0 || (txtUnrep.Text.IndexOf('-') == 0)))
            {//Only one negative sign (-) and starting position only
                e.Handled = true;
            }
            if (e.KeyChar == '.' && txtUnrep.Text.IndexOf('-') == 0 && txtUnrep.Text.Length == 1)
            {//dot(.) cannot be next to negative sign(-)
                e.Handled = true;
            }
        }

        private void txtOtherFind_KeyPress(object sender, KeyPressEventArgs e)
        {

            //Number,dot,negativeSIgn Only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
            if ((txtOtherFind.Text.IndexOf('.') >= 0) && (e.KeyChar == '.'))
            {//Only one dot (.)
                e.Handled = true;
            }
            if ((e.KeyChar == '-') && (txtOtherFind.Text.Length > 0 || (txtOtherFind.Text.IndexOf('-') == 0)))
            {//Only one negative sign (-) and starting position only
                e.Handled = true;
            }
            if (e.KeyChar == '.' && txtOtherFind.Text.IndexOf('-') == 0 && txtOtherFind.Text.Length == 1)
            {//dot(.) cannot be next to negative sign(-)
                e.Handled = true;
            }
        }

        private void txtVariance_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        private void txtCash_KeyPress(object sender, KeyPressEventArgs e)
        {

            //Number,dot,negativeSIgn Only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
            if ((txtCash.Text.IndexOf('.') >= 0) && (e.KeyChar == '.'))
            {//Only one dot (.)
                e.Handled = true;
            }
            if ((e.KeyChar == '-') && (txtCash.Text.Length > 0 || (txtCash.Text.IndexOf('-') == 0)))
            {//Only one negative sign (-) and starting position only
                e.Handled = true;
            }
            if (e.KeyChar == '.' && txtCash.Text.IndexOf('-') == 0 && txtCash.Text.Length == 1)
            {//dot(.) cannot be next to negative sign(-)
                e.Handled = true;
            }
        }

        private void txtCharge_KeyPress(object sender, KeyPressEventArgs e)
        {

            //Number,dot,negativeSIgn Only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
            if ((txtCharge.Text.IndexOf('.') >= 0) && (e.KeyChar == '.'))
            {//Only one dot (.)
                e.Handled = true;
            }
            if ((e.KeyChar == '-') && (txtCharge.Text.Length > 0 || (txtCharge.Text.IndexOf('-') == 0)))
            {//Only one negative sign (-) and starting position only
                e.Handled = true;
            }
            if (e.KeyChar == '.' && txtCharge.Text.IndexOf('-') == 0 && txtCharge.Text.Length == 1)
            {//dot(.) cannot be next to negative sign(-)
                e.Handled = true;
            }
        }

        private void txtGC_KeyPress(object sender, KeyPressEventArgs e)
        {

            //Number,dot,negativeSIgn Only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
            if ((txtGC.Text.IndexOf('.') >= 0) && (e.KeyChar == '.'))
            {//Only one dot (.)
                e.Handled = true;
            }
            if ((e.KeyChar == '-') && (txtGC.Text.Length > 0 || (txtGC.Text.IndexOf('-') == 0)))
            {//Only one negative sign (-) and starting position only
                e.Handled = true;
            }
            if (e.KeyChar == '.' && txtGC.Text.IndexOf('-') == 0 && txtGC.Text.Length == 1)
            {//dot(.) cannot be next to negative sign(-)
                e.Handled = true;
            }
        }
    }
}
