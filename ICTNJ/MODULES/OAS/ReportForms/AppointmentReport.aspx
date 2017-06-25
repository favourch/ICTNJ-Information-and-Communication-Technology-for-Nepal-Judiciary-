<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true" CodeFile="AppointmentReport.aspx.cs" Inherits="MODULES_OAS_ReportForms_AppointmentReport" Title="OAS|Appointment_Report" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <div style="width:100%; height:370px">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager> 
    <script language="javascript" src="../../COMMON/JS/Validation.js" type="text/javascript"></script>
    <script language="javascript" src="../../COMMON/JS/DateValidator.js" type="text/javascript"></script>

    
    <br />
   
   <div style ="PADDING-LEFT: 50px;">
    <table  style="PADDING-LEFT: 20px; WIDTH: 685px"  border ="0" cellpadding ="1" cellspacing="1">
        <tr>
            <td colspan="2" style="height: 44px">
                <asp:Label ID="lblTitle" runat="server" SkinID="UnicodeHeadlbl" Text="एपोइन्टमेन्ट रिपोर्ट"></asp:Label></td>
            <td style="width: 68px; height: 44px">
            </td>
            <td style="height: 44px">
            </td>
        </tr>
        
        <tr>
            <td style="width: 73px; height: 31px">
                <asp:Label ID="lblOrgName" runat="server" Text="कार्यलय" SkinID="Unicodelbl"></asp:Label>
                <asp:Label ID="Label3" runat="server" CssClass="simplelabel" EnableTheming="False"
                    ForeColor="Red" Text="*"></asp:Label></td>
            <td style="width: 249px; height: 31px">
                <asp:UpdatePanel id="UpdatePanel1" runat="server">
                    <contenttemplate>
<asp:DropDownList id="ddlOrg_rqd" runat="server" Width="221px" SkinID="Unicodeddl" ToolTip="कार्यलय"></asp:DropDownList> 
</contenttemplate>
                </asp:UpdatePanel></td>
            <td style="width: 68px; height: 31px">
                <asp:Label ID="lblDate" runat="server" Text="मिति" SkinID="Unicodelbl"></asp:Label></td>
            <td style="height: 31px">
                <asp:UpdatePanel id="UpdatePanel2" runat="server">
                    <contenttemplate>
<asp:TextBox id="txtDate_DT" runat="server" Width="77px" MaxLength="10" ToolTip="मिटिङ्ग मिति"></asp:TextBox> <cc1:MaskedEditExtender id="MaskedEditExtender1" runat="server" TargetControlID="txtDate_DT" MaskType="Date" Mask="9999/99/99" AutoComplete="False"></cc1:MaskedEditExtender> 
</contenttemplate>
                </asp:UpdatePanel></td>
        </tr>
        <tr>
            <td style="width: 73px">
            </td>
            <td style="width: 249px">
            </td>
            <td style="width: 68px">
            </td>
            <td>
                <table border ="0" cellpadding="1" cellspacing="1">
                    <tr>
                        <td style="width: 91px">   <asp:Button ID="btnGenerateReport" runat="server" OnClick="btnGenerateReport_Click"
                                SkinID="Normal" Text="रिपोर्ट हेर्नहोस्" OnClientClick="javascript:return validate(1);" Width="85px" /></td>
                        <td>   
                            <asp:UpdatePanel id="UpdatePanel3" runat="server">
                                <contenttemplate>
<asp:Button id="btnCancel" runat="server" Text="Cancel" SkinID="Cancel" OnClick="btnCancel_Click"></asp:Button> 
</contenttemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
             </td>
        </tr>
    </table>
    </div>
    
   
    &nbsp;&nbsp;
   </div>
</asp:Content>

