<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true" CodeFile="PurchaseReport.aspx.cs" Inherits="MODULES_OAS_Inventory_ReportForms_PurchaseReport" Title="OAS|PurchaseOrder Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="width:100%; height:auto">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <br />
   
    
    <div style ="PADDING-LEFT: 50px;">
    <table  style="PADDING-LEFT: 20px; WIDTH: 685px" border ="0" cellpadding ="1" cellspacing="1">
        <TR>
           <TD style=" HEIGHT: 30px" vAlign=baseline align=left colSpan=4>
           <asp:Label id="Label2" runat="server" Text="खरिद विवरण रिपोर्ट" SkinID="UnicodeHeadlbl" Width="213px"></asp:Label></TD>
        </TR>
      
        
        <tr>
            <td style="width: 79px; height: 84px" >
                <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="अर्डर नं."></asp:Label></td>
            <td style="width: 129px; height: 84px"><asp:UpdatePanel id="UpdatePanel2" runat="server">
                <contenttemplate>
                    &nbsp;<asp:TextBox id="txtOrderNo" runat="server" Width="90px" __designer:dtid="562949953421327" __designer:wfdid="w32" MaxLength="4"></asp:TextBox>
                    </contenttemplate>
                                    <triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click"></asp:AsyncPostBackTrigger>
                    </triggers>
            </asp:UpdatePanel></td>
            <td style="width: 76px;">
                <asp:Button ID="btnGenerateReport" runat="server" OnClick="btnGenerateReport_Click"
                    SkinID="Normal" Text="रिपोर्ट हेर्नहोस्" />
            </td>
            <td style="height: 84px">
                <asp:UpdatePanel id="UpdatePanel1" runat="server">
                    <contenttemplate>
                        <asp:Button id="btnCancel" onclick="btnCancel_Click" runat="server" Text="Cancel" SkinID="Cancel" __designer:wfdid="w29"></asp:Button>
                        </contenttemplate>
                                            <triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click"></asp:AsyncPostBackTrigger>
                        </triggers>
                </asp:UpdatePanel></td>
        </tr>
        <tr>
            <td style="height:280px;">
            </td>
        </tr>
              
     </table>
     
</div>
</asp:Content>

