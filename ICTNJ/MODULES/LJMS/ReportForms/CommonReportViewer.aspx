<%@ Page AutoEventWireup="true" Buffer="true" CodeFile="CommonReportViewer.aspx.cs" EnableViewState="false" Inherits="MODULES_PMS_ReportForms_CommonReportViewer"
    Language="C#" ViewStateEncryptionMode="Never" Title ="NBA | Report Viewer" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=11.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <script language="javascript" type="text/javascript">
        function printRPT()
        {
            alert('upto here ....');
            
            var prm = new Object();
            prm.codebase = "../../crystalreportviewers115/ActiveXControls/PrintControl.cab";
            prm.url = window.location;
            prm.postbackdata = "__EVENTTARGET=rptComViewer&__EVENTARGUMENT=print&__LASTFOCUS=&__VIEWSTATE=%2fwEPDwUJNjA1ODQzOTQyZBgBBR5fX0NvbnRyb2xzUmVxdWlyZVBvc3RCYWNrS2V5X18WEAUYcnB0Q29tVmlld2VyJGN0bDAyJGN0bDAwBRhycHRDb21WaWV3ZXIkY3RsMDIkY3RsMDEFGHJwdENvbVZpZXdlciRjdGwwMiRjdGwwMgUYcnB0Q29tVmlld2VyJGN0bDAyJGN0bDAzBRhycHRDb21WaWV3ZXIkY3RsMDIkY3RsMDQFGHJwdENvbVZpZXdlciRjdGwwMiRjdGwwNQUYcnB0Q29tVmlld2VyJGN0bDAyJGN0bDA2BRhycHRDb21WaWV3ZXIkY3RsMDIkY3RsMDcFGHJwdENvbVZpZXdlciRjdGwwMiRjdGwwOAUYcnB0Q29tVmlld2VyJGN0bDAyJGN0bDEyBRhycHRDb21WaWV3ZXIkY3RsMDIkY3RsMTQFGHJwdENvbVZpZXdlciRjdGwwNSRjdGwwMAUYcnB0Q29tVmlld2VyJGN0bDA1JGN0bDAxBRhycHRDb21WaWV3ZXIkY3RsMDUkY3RsMDIFGHJwdENvbVZpZXdlciRjdGwwNSRjdGwwMwUYcnB0Q29tVmlld2VyJGN0bDA1JGN0bDA0R4y53Lk%2bLSKIt3czp8i2uPdosV8%3d&__SCROLLPOSITIONX=0&__SCROLLPOSITIONY=0&__EVENTVALIDATION=%2fwEWGwLo18D1AwLmt8igAwLmt7TFCgLmt6DqAQLmt%2bTYBwLmt9D9DgLmt7yiBgLmt6jHDQLmt5TsBALLzoLVBwLLzu75DgLLztqeBgLLzsbDDQLFoZCuAQLAoayuAQLCoZCuAQLi4Mv5BgL78tznAwLi4L%2f6BgLj4Mv5BgLs4Mv5BgLt4Mv5BgLmt8ynAwLmt7jMCgLmt6TxAQLmt5CWCQLmt%2fw6%2fdb8duhO6Rj9dliYEQAz5LL5oho%3d&rptComViewer%24ctl02%24ctl09=1&rptComViewer%24ctl02%24ctl13=&rptComViewer%24ctl02%24ctl15=100";
            prm.title = "form1";
            prm.paperorientation = "2";
            prm.papersize = "9";
            prm.drivername = "DISPLAY";
            prm.usedefprinter = "1";
            prm.usedefprintersettings = "0";
            prm.sendpostdataonce = "0";
            window.showModalDialog('../../../../aspnet_client/System_Web/2_0_50727/crystalreportviewers115/html/crystalprinthost.html', prm, 'dialogHeight:250px;dialogWidth:300px;scroll:no;status:no');
            
            var obj = document.getElementById('__VIEWSTATE');
            alert(obj.value);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblEllapsedTime" runat="server" SkinID="Unicodelbl"></asp:Label><br />
            <CR:CrystalReportViewer ID="rptComViewer" runat="server" AutoDataBind="true" DisplayGroupTree="False" HasCrystalLogo="False" HasToggleGroupTreeButton="False"
                HasViewList="False" PrintMode="ActiveX" />
        </div>
    </form>
</body>
</html>
