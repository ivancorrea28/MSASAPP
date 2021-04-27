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
    public partial class AddFindings : Form
    {
        public AddFindings()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        string localConnection = LoginForm.localConnectionString;
        private void AddFindings_Load(object sender, EventArgs e)
        {
            txtMonth.Text = EditWorkingPaper.month;
            dt.Columns.Add("ComponentID");
            dt.Columns.Add("Component");
            dt.Columns.Add("ClassificationID");
            dt.Columns.Add("Classification");
            dt.Columns.Add("NoEID");
            dt.Columns.Add("Nature of Error");
            dt.Columns.Add("Amount");
            dt.Columns.Add("Remarks");
            dgvFindings.DataSource = dt;
            dgvFindings.ReadOnly = true;
            dgvFindings.Columns[0].Visible = false;//ComponentID
            dgvFindings.Columns[2].Visible = false;//classification
            dgvFindings.Columns[4].Visible = false;//NOEID
        }

        private void dgvFindings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        public static bool yes = false;
        private void btnAddFindings_Click(object sender, EventArgs e)
        {
            dgvFindings.ReadOnly = false;
            FindingsInfo fi = new FindingsInfo();
            fi.ShowDialog();
            
            if (yes)
            {
                //Add New Row with Values From findings info
                DataRow dr = dt.NewRow();
                dr["ComponentID"] = FindingsInfo.compID;
                dr["Component"] = FindingsInfo.comp;
                dr["ClassificationID"] = FindingsInfo.clasID;
                dr["Classification"] = FindingsInfo.clas;
                dr["NoEID"] = FindingsInfo.NOEID;
                dr["Nature of Error"] = FindingsInfo.NoE;
                dr["Amount"] = FindingsInfo.amount;
                dr["Remarks"] = FindingsInfo.remarks;
                dt.Rows.Add(dr);
                dgvFindings.DataSource = dt;
                yes = false;
            }
            fi.Dispose();
            dgvFindings.ReadOnly = true;
        }

        private void AddFindings_Shown(object sender, EventArgs e)
        {
            //openSelectDate();
        }

        private void txtDays_Click(object sender, EventArgs e)
        {
            openSelectDate();
        }
        public void openSelectDate()
        {
            SelectDate sd = new SelectDate();
            sd.StartPosition = FormStartPosition.CenterParent;
            SelectDate.selectedDays = txtDays.Text;
            sd.ShowDialog();
            txtDays.Text = SelectDate.selectedDays;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDays.Text != "Click to Set Date Day(s)")
            {
                SqlConnection con = new SqlConnection(localConnection);
                string rp = EditWorkingPaper.rp;
                string auditor = AuditSchedule.auditor;
                string year = EditWorkingPaper.year;

                con.Open();
                for (int i = 0; i < dgvFindings.Rows.Count; i++)
                {
                    string sql = "INSERT INTO AuditFindings VALUES(null,@rp,@class,@dates,@comp,@NoE,@amount,@remarks,@auditor,@status,null,@MonthYear)";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("rp", rp);
                    cmd.Parameters.AddWithValue("class", dgvFindings.Rows[i].Cells[2].Value.ToString());
                    cmd.Parameters.AddWithValue("dates", txtMonth.Text + " " + txtDays.Text + ", " + year);
                    cmd.Parameters.AddWithValue("comp", dgvFindings.Rows[i].Cells[0].Value.ToString());
                    cmd.Parameters.AddWithValue("NoE", dgvFindings.Rows[i].Cells[5].Value.ToString());
                    cmd.Parameters.AddWithValue("amount", dgvFindings.Rows[i].Cells[6].Value.ToString());
                    cmd.Parameters.AddWithValue("remarks", dgvFindings.Rows[i].Cells[7].Value.ToString());
                    cmd.Parameters.AddWithValue("auditor", auditor);
                    cmd.Parameters.AddWithValue("status", "Approved");
                    cmd.Parameters.AddWithValue("MonthYear ", txtMonth.Text + " 01, " + year);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
                saved = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Set Selected Days to save.");
            }
            
        }
        bool saved = false;
        private void AddFindings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(saved){

            }
            else
            {
                DialogResult dr = MessageBox.Show("Your Findings Has Not been Saved yet! Exit module?", "Warning", MessageBoxButtons.YesNo);
                if (dr != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
