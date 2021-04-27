using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSAS
{
    public partial class SelectDate : Form
    {
        public SelectDate()
        {
            InitializeComponent();
        }

        private void rdbSingleDate_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbSingleDate.Checked)
            {
                dtpEndDate.Visible = false;
            }
            else
            {
                dtpEndDate.Visible = true;
            }
            dtpStartDate.Focus();
        }
        public static string selectedDays="";
        private void SelectDate_Load(object sender, EventArgs e)
        {
            loadDateTimePickers();
            
        }
        public void loadDateTimePickers()
        {
            if (selectedDays == "Click to Set Date Day(s)")
            {
                selectedDays = "";
            }
            txtDays.Text = selectedDays;
            DateTime auditDate = Convert.ToDateTime(AuditFindings.month + " 01," + AuditFindings.year);
            if (txtDays.Text == "")//No Selected Days
            {
                dtpStartDate.Value = Convert.ToDateTime(auditDate.ToString("MMMM") + " 01, " + auditDate.ToString("yyyy"));
                dtpStartDate.MinDate = Convert.ToDateTime(auditDate.ToString("MMMM") + " 01, " + auditDate.ToString("yyyy"));
                dtpEndDate.MinDate = dtpStartDate.Value.AddDays(2);
            }
            else//There are already selected days.
            {
                if(txtDays.Text.IndexOf(",")<0){//Single Value
                    string lastDay = txtDays.Text;
                    if(lastDay.IndexOf("-")>0){//if Value is DateRange
                        lastDay = lastDay.Substring(lastDay.IndexOf("-") + 2);
                    }
                    int endDayPicker = Convert.ToInt32(lastDay) + 2;
                    dtpStartDate.Value = Convert.ToDateTime(auditDate.ToString("MMMM") + " " + lastDay + ", " + auditDate.ToString("yyyy"));
                    dtpStartDate.MinDate = Convert.ToDateTime(auditDate.ToString("MMMM") + " " + lastDay + ", " + auditDate.ToString("yyyy"));
                    dtpEndDate.MinDate = Convert.ToDateTime(auditDate.ToString("MMMM") + " " + endDayPicker.ToString() + ", " + auditDate.ToString("yyyy"));
                }
                else//Multiple Values
                {
                    string days = txtDays.Text;
                    days=days.Substring(days.LastIndexOf(",") + 2);//Get Last Value
                    if (days.IndexOf("-") > 0){// Get End Day if Value is DateRange
                        days = days.Substring(days.IndexOf("-") + 2);
                    }
                    int lastday = Convert.ToInt32(days);
                    //MessageBox.Show(lastday);
                    dtpStartDate.Value = Convert.ToDateTime(auditDate.ToString("MMMM") + " " + lastday.ToString() + ", " + auditDate.ToString("yyyy"));
                    dtpStartDate.MinDate = Convert.ToDateTime(auditDate.ToString("MMMM") + " " + lastday.ToString() + ", " + auditDate.ToString("yyyy"));
                    dtpEndDate.MinDate = Convert.ToDateTime(auditDate.ToString("MMMM") + " " + (lastday + 2).ToString() + ", " + auditDate.ToString("yyyy"));
                }
            }
            dtpEndDate.Value = dtpStartDate.Value.AddDays(2);
            dtpStartDate.MaxDate = Convert.ToDateTime(auditDate.AddMonths(1).ToString("MMMM") + " 01, " + auditDate.AddMonths(1).ToString("yyyy")).AddDays(-1);
            dtpEndDate.MaxDate = (Convert.ToDateTime(auditDate.AddMonths(1).ToString("MMMM") + " 01, " + auditDate.AddMonths(1).ToString("yyyy"))).AddDays(-1);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtDays.Text=="Click to Set Date Day(s)"){
                txtDays.Text = "";
            }
            if (rdbSingleDate.Checked)
            {
                if (txtDays.Text != "") {
                    txtDays.Text += ", ";
                }
                txtDays.Text += dtpStartDate.Value.Day;
                dtpStartDate.MinDate = dtpStartDate.Value.AddDays(1);
                dtpEndDate.MinDate = dtpStartDate.Value.AddDays(2);
                //dtpStartDate.Value = dtpStartDate.Value.AddDays(1);
                //dtpEndDate.Value = dtpStartDate.Value.AddDays(1);
            }
            else
            {
                if (txtDays.Text != "")//IF wala pang Current dates na sinet, dont add Comma
                {
                    txtDays.Text += ", ";
                }
                txtDays.Text += dtpStartDate.Value.Day.ToString() + " - " + dtpEndDate.Value.Day.ToString();
                //disable dates upto last day selected
                if (dtpEndDate.Value.AddDays(1) > dtpEndDate.MaxDate)
                {
                    dtpEndDate.Enabled = false;
                    dtpStartDate.Enabled = false;
                    btnAdd.Enabled = false;
                }
                else
                {
                    dtpStartDate.MinDate = dtpEndDate.Value.AddDays(1);
                    dtpEndDate.MinDate = dtpStartDate.Value.AddDays(2);
                }
                //set days to available dates
                //dtpStartDate.Value = dtpEndDate.Value.AddDays(1);
                //dtpEndDate.Value = dtpEndDate.Value.AddDays(1);
            }
        }

        private void SelectDate_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (txtDays.Text == "")
            {
                selectedDays = "Click to Set Date Day(s)";
            }
            else
            {
                selectedDays = txtDays.Text;
            }
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpEndDate.MaxDate > dtpStartDate.Value.AddDays(2)){
                dtpEndDate.MinDate = dtpStartDate.Value.AddDays(2);
            }
            else
            {
                rdbSingleDate.Checked = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            selectedDays = "Click to Set Date Day(s)";
            loadDateTimePickers();
        }
    }
}
