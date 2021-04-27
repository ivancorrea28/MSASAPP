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
    public partial class VarianceBreakdownSummary : Form
    {
        public VarianceBreakdownSummary()
        {
            InitializeComponent();
        }
        SqlConnection con;
        DataTable dt;
        private void VarianceBreakdownSummary_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(LoginForm.localConnectionString);
            loadSummary();
            //hide Column IDs
        }
        public static string rpcode;
        public static string terminal;
        public static string sdate;
        
        public void loadSummary()
        {
            dgvSummary.DataSource = null;
            dt = new DataTable();
            dt.Columns.Add("Date");
            dt.Columns.Add("Classification");
            dt.Columns.Add("ClassificationID");
            dt.Columns.Add("Component");
            dt.Columns.Add("ComponentID");
            //dt.Columns.Add("Nature of Error");
            dt.Columns.Add("Amount");
            //dt.Columns.Add("Remarks");
            dt.Columns.Add("Added");
            string edate = (Convert.ToDateTime(sdate).AddMonths(1).AddDays(-1)).ToString("MMMM dd, yyyy");
            con.Open();
            for (int i = 1; i <= 6; i++)//1-6 is component
            {
                for (int x = 1; x <= 4; x++)//1-4 is Classification
                {
                    //get Days-String Format
                    string sql = "SELECT DISTINCT(DAY(date)) AS 'Day', amount, CASE WHEN summarized IS NULL THEN 'NO'  ELSE summarized END AS [summarized] FROM VarianceBreakdown WHERE tenantcode=@rpcode AND machine=@terminal AND classification=@class AND component=@comp AND date BETWEEN @sdate AND @edate AND amount IS NOT NULL AND amount <>0 ORDER BY 1";
                    //string sql = "SELECT DISTINCT date FROM VarianceBreakdown ORDER BY 1";
                    SqlCommand cmd = new SqlCommand(sql,con);
                    cmd.Parameters.AddWithValue("rpcode", rpcode);
                    cmd.Parameters.AddWithValue("terminal", terminal);
                    cmd.Parameters.AddWithValue("sdate", sdate);
                    cmd.Parameters.AddWithValue("edate", edate);
                    cmd.Parameters.AddWithValue("class", x);
                    cmd.Parameters.AddWithValue("comp", i);
                    //MessageBox.Show(rpcode + " " + terminal + " " + sdate + " " + edate + " " + x.ToString() + " " + i.ToString());
                    SqlDataReader sread= cmd.ExecuteReader();
                    string dates="";
                    string lastday="-1";
                    bool continuousDays=false;
                    bool loop =true;
                    string summarized = "YES";
                    double total = 0.00;
                    //bool isLastSingleDayAdded = false;
                    while(loop){
                        loop = sread.Read();
                        if(loop){//Not Last Record
                            //
                            total += Convert.ToDouble(sread[1]);
                            //MessageBox.Show(continuousDays.ToString());
                            if (sread[2].ToString() == "NO")
                            {
                                summarized = "NO";
                            }
                            if ((int)sread[0] == Convert.ToInt16(lastday) + 1)//Current Day == lastday+1
                            {//Continuous Days
                                continuousDays = true;
                            }
                            else
                            {//Skipped Days
                                if (continuousDays) //if continuous days, dash
                                {
                                    dates += " - " + lastday;
                                    continuousDays = false;
                                }

                                if (dates != "")// with comma if not initial 
                                {
                                    dates += ", ";
                                    dates += sread[0].ToString();
                                }
                                else// no comma if initial
                                {
                                    dates += sread[0].ToString();
                                }
                            }
                            lastday = sread[0].ToString();
                        }
                        else// Last Record
                        {
                            //MessageBox.Show(dates.Substring(dates.LastIndexOf(',') + 1) + "vs" + lastday);
                            if (continuousDays)
                            {
                                dates += " - " + lastday;
                                continuousDays = false;
                            }
                            else if (dates!="" && dates.Substring(dates.LastIndexOf(',') + 1).Trim() != lastday.Trim())
                            {
                                dates += ", ";
                                dates += lastday;
                            }
                        }

                    }
                    sread.Close();
                    if (dates != "")
                    {
                        //Month + dates + year
                        //MessageBox.Show(dates);
                        string rowDates = Convert.ToDateTime(sdate).ToString("MMMM")+" "+dates+", "+Convert.ToDateTime(sdate).ToString("yyyy");
                        //Component String
                        string component = "";
                        switch (i)
                        {
                            case 1:
                                component = "Cash";
                                break;
                            case 2:
                                component = "Charge";
                                break;
                            case 3:
                                component = "GC/Others";
                                break;
                            case 4:
                                component = "Senior Discount";
                                break;
                            case 5:
                                component = "Other Discount";
                                break;
                            case 6:
                                component = "Service Charge";
                                break;
                        }
                        //classification string
                        string classif = "";
                        switch (x)
                        {
                            case 1:
                                classif = "Textfile Problem";
                                break;
                            case 2:
                                classif = "Misclassified";
                                break;
                            case 3:
                                classif = "Other Findings";
                                break;
                            case 4:
                                classif = "Unreported";
                                break;
                        }
                        DataRow dr = dt.NewRow();
                        dr["Date"] = rowDates;
                        dr["Classification"] = classif;
                        dr["ClassificationID"] = x;
                        dr["Component"] = component;
                        dr["ComponentID"] = i;
                        //dr["Nature of Error"]="";
                        //dr["Amount"] = total;
                        dr["Amount"] = total.ToString("#,0.00");
                        //dr["Remarks"] = "";
                        dr["Added"] = summarized;
                        dt.Rows.Add(dr);
                    }
                }
                //i = 6;
            }
            con.Close();
            dgvSummary.DataSource = dt;
            dgvSummary.Columns[2].Visible = false;
            dgvSummary.Columns[4].Visible = false;
            for (int i = 0; i < dgvSummary.Columns.Count; i++)
            {
                dgvSummary.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void dgvSummary_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dgvSummary.CurrentCell.RowIndex;
            
            
            SaveVarianceBreakdownSummary svbs = new SaveVarianceBreakdownSummary();
            SaveVarianceBreakdownSummary.rpcode = rpcode;
            SaveVarianceBreakdownSummary.terminal = terminal;
            SaveVarianceBreakdownSummary.sdate = sdate;
            SaveVarianceBreakdownSummary.classif = Convert.ToInt32(dgvSummary.Rows[row].Cells[2].Value.ToString());//classid;
            SaveVarianceBreakdownSummary.comp = Convert.ToInt32(dgvSummary.Rows[row].Cells[4].Value.ToString());//comp;
            SaveVarianceBreakdownSummary.selectedDays = dgvSummary.Rows[row].Cells[0].Value.ToString();//date
            svbs.txtClassif.Text = dgvSummary.Rows[row].Cells[1].Value.ToString();//class
            svbs.txtComponent.Text = dgvSummary.Rows[row].Cells[3].Value.ToString();//comp
            svbs.txtAmount.Text = dgvSummary.Rows[row].Cells[5].Value.ToString();//amount
            svbs.StartPosition = FormStartPosition.CenterParent;
            svbs.ShowDialog();
            loadSummary();
        }
    }
}
