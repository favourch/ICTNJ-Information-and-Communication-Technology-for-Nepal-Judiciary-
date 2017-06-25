<%@ Page AutoEventWireup="true" CodeFile="MaterialReport.aspx.cs" Inherits="MODULES_LIS_Forms_MaterialReport" Language="C#" MasterPageFile="~/MODULES/COMMON/MasterPage.master"
    Title="Material Report" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=11.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager id="scrptUpdPanel" runat="server">
    </asp:ScriptManager>
    <asp:Label ID="lblStatus" runat="server" SkinID="Unicodelbl"></asp:Label><br />
    <div style="width: 100%; min-height:500px; padding-left:5px">
        <table width="600">
            <tr>
                <td colspan="3" style="height: 34px">
                    <asp:Label ID="Label2" runat="server" SkinID="UnicodeHeadlbl" Text="Library Material Report"></asp:Label></td>
            </tr>
            <tr>
                <td width="100">
                    <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="Organization"></asp:Label></td>
                <td width="200">
                    <asp:DropDownList ID="drpOrganisation" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpOrganisation_SelectedIndexChanged" SkinID="Unicodeddl"
                        ToolTip="Select Organisation" Width="200px">
                    </asp:DropDownList></td>
                <td width="300">
                </td>
            </tr>
            <tr>
                <td width="100">
                    <asp:Label ID="lblLibrary" runat="server" SkinID="Unicodelbl" Text="Library"></asp:Label></td>
                <td width="200">
                    <asp:UpdatePanel id="updLibrary" runat="server">
                        <contenttemplate>
<asp:DropDownList id="drpLibrary" runat="server" Width="200px" SkinID="Unicodeddl" ToolTip="Select Library" Enabled="false"></asp:DropDownList> 
</contenttemplate>
                        <triggers>
<asp:AsyncPostBackTrigger ControlID="drpOrganisation" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
                    </asp:UpdatePanel></td>
                <td width="300">
                    <asp:Button ID="btnGenerateRpt" runat="server" OnClick="btnGenerateRpt_Click" SkinID="Dynamic" Text="Generate Report" ToolTip="Generate Report" Width="130px" /></td>
            </tr>
            <tr>
                <td style="height: 10px" width="100">
                </td>
                <td style="height: 10px" width="200">
                </td>
                <td style="height: 10px" width="300">
                </td>
            </tr>
        </table>
        <CR:CrystalReportViewer ID="ReportViewer" runat="server" AutoDataBind="true" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" DisplayGroupTree="False"
            EnableDatabaseLogonPrompt="False" EnableDrillDown="False" EnableParameterPrompt="False" EnableTheming="True" HasCrystalLogo="False" HasDrillUpButton="False"
            HasSearchButton="False" HasToggleGroupTreeButton="False" HasViewList="False" HasZoomFactorList="False" PrintMode="ActiveX" ToolTip="Crystal Report Data"
            Width="350px" />
    </div>
</asp:Content>
