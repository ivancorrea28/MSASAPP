<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DailySalesTenderReportPrint.aspx.cs" Inherits="Report_PrintDailySalesTenderReport" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

     <script type="text/javascript">
          function Print() {
              var dvReport = document.getElementById("dvReport");
              var frame1 = dvReport.getElementsByTagName("iframe")[0];
              if (navigator.appName.indexOf("Internet Explorer") != -1) {
                  frame1.name = frame1.id;
                  window.frames[frame1.id].focus();
                  window.frames[frame1.id].print();
              }
              else {
                  var frameDoc = frame1.contentWindow ? frame1.contentWindow : frame1.contentDocument.document ? frame1.contentDocument.document : frame1.contentDocument;
                  frameDoc.print();
              }
          }
</script>

</head>
<body>
    <form id="form1" runat="server">
    <%--<asp:Button ID="btnPrint" runat="server" Text="Print Directly" OnClientClick="Print()"></asp:Button>
    
        <div id="dvReport">
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" ToolPanelView="None" EnableDatabaseLogonPrompt="false"  />
    
         <br />

      
    </div>

          for testing: display passed records--%>
       <%-- <asp:Panel ID="Panel1" runat="server" >

            <asp:TextBox ID="txtdatefrom" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtdateto" runat="server"></asp:TextBox>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <asp:HiddenField ID="hdnSearchedLoc" runat="server" />
            <asp:HiddenField ID="hdnSearchedRP" runat="server" />
        </asp:Panel>--%>
    </form>
</body>
</html>
