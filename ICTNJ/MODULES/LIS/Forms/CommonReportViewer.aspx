<%@ Page AutoEventWireup="true" Buffer="true" CodeFile="CommonReportViewer.aspx.cs" EnableViewState="false" Inherits="MODULES_PMS_ReportForms_CommonReportViewer"
    Language="C#" ViewStateEncryptionMode="Never" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=11.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
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
