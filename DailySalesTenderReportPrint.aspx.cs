using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Reporting;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using CrystalDecisions.ReportAppServer.ClientDoc;
using System.Configuration;
using System.Data;
using System.Collections;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Drawing;
using System.Windows.Forms;
using System.IO;


public partial class Report_PrintDailySalesTenderReport : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RPSMSConnectionString"].ConnectionString);
    ReportDocument report = new ReportDocument();

    protected void Page_unLoad(object sender, EventArgs e)
    {
        report.Close();
        report.Dispose();
    }
    protected void Page_Init(object sender, EventArgs e)
    {


        //try
        //{
        con.Open();
        DateTime df = Convert.ToDateTime(Session["DateFrom"].ToString());
        DateTime dt = Convert.ToDateTime(Session["DateTo"].ToString());
        string Loc = Session["hdnSearchedLoc"].ToString();
        string RP = Session["hdnSearchedRP"].ToString();
        //txtdatefrom.Text = Session["DateFrom"].ToString();
        //txtdateto.Text = Session["DateTo"].ToString();
        //DateTime df = Convert.ToDateTime(txtdatefrom.Text); // converted this para pag pasa sa crystal report date na sya
        //DateTime dt = Convert.ToDateTime(txtdateto.Text); // kumbaga dito ginawa yung conversion di na sa parameter formula filed
        //hdnSearchedLoc.Value = Session["hdnSearchedLoc"].ToString();
        //hdnSearchedRP.Value = Session["hdnSearchedRP"].ToString();
        string FullName = Session["UserFullName"].ToString();
        string PrintType = Session["PrintType"].ToString();
        //determine what button is clicked, print or preview uisng query string to
        string PrintNow = Request.QueryString["ID"];
        string Terminal = Session["Terminal"].ToString();
        string printExcel = Session["PrintExcel"].ToString();
        string printPDF = Session["PrintPDF"].ToString();
        string printCSV = Session["PrintCSV"].ToString();

        string Filename = "Daily Sales Tender Report -" + DateTime.Now.ToString("dd/MM/yy");
        //CHOOSE PRINT OR PREVIEW
       
            report.Load(Server.MapPath("DailySalesTenderReport.rpt"));
            
            report.SetDatabaseLogon
                //("sa", "IT-@ud1t", @"RPSMS", "CMEGAWORLDMALLS");
                //("sa", "IT-@ud1t", @"RPSMS-DEV", "CMEGAWORLDMALLS");
                //("sa", "IT-@ud1t", @"RPSMS", "TESTDATA");
                 ("sa", "IT-@ud1t", @"RPSMS-CLOUD\CLOUDSVR", "CMEGAWORLDMALLS");
            //("sa", "IT-@ud1t", @"RPSMS-CLOUD\CLOUDSVR", "RPSMSBETA");


            // datefrom and dateto here are parameters made in crystal need sya e... pass the variable to cystal
            report.SetParameterValue("@dateFrom", df);
            report.SetParameterValue("@dateTo", dt);
            report.SetParameterValue("@Location", Loc);
            report.SetParameterValue("@RP", RP);
            report.SetParameterValue(4, FullName);
            report.SetParameterValue("@Terminal", Terminal);

            if (printExcel == "Excel")
            {
                report.ExportToDisk(ExportFormatType.Excel, Server.MapPath("PDF_Files/DailySalesTenderReport.xls"));
                ClientScript.RegisterStartupScript(this.Page.GetType(), "popupOpener", "var popup=window.open('PDF_Files/DailySalesTenderReport.xls');popup.focus();", true);
            }
            else if (printPDF == "PDF")
            {
                report.ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("PDF_Files/DailySalesTenderReport.pdf"));
                ClientScript.RegisterStartupScript(this.Page.GetType(), "popupOpener", "var popup=window.open('PDF_Files/DailySalesTenderReport.pdf');popup.focus();", true);
            }
            else if (printCSV == "CSV")
            {
                report.ExportToDisk(ExportFormatType.CharacterSeparatedValues, Server.MapPath("PDF_Files/DailySalesTenderReport.csv"));
                ClientScript.RegisterStartupScript(this.Page.GetType(), "popupOpener", "var popup=window.open('PDF_Files/DailySalesTenderReport.csv');popup.focus();", true);
            }

            ClientScript.RegisterStartupScript(this.Page.GetType(), "windowclose", "var closer=window.close();closer.focus();", true);

            con.Close();
        

    }
}
   
