using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports;

namespace MSAS
{
    public partial class printWorkingPaper : Form
    {
        public printWorkingPaper()
        {
            InitializeComponent();
        }

        private void WorkingPaperCrystalReport_Load(object sender, EventArgs e)
        {
            //CrystalReportViewer1.
            this.WindowState = FormWindowState.Maximized;
            
        }
    }
}
