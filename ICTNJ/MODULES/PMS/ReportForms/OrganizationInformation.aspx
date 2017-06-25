<%@ Page Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master" AutoEventWireup="true" CodeFile="OrganizationInformation.aspx.cs" Inherits="MODULES_PMS_ReportForms_OrganizationInformation" Title="PMS | Organization Information" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager runat="server" ID="sct">
    </asp:ScriptManager>

    <div style="width: 100%; height: auto">
        <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" style="display:none"/>
        <ajaxToolkit:ModalPopupExtender runat="server" ID="programmaticModalPopup"
            BehaviorID="programmaticModalPopupBehavior"
            TargetControlID="hiddenTargetControlForModalPopup"
            PopupControlID="programmaticPopup" 
            BackgroundCssClass="modalBackground"
            DropShadow="True"
            PopupDragHandleControlID="programmaticPopupDragHandle"
            RepositionMode="RepositionOnWindowScroll" >
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel runat="server" CssClass="modalPopup" ID="programmaticPopup" style="display:none;width:350px;padding:10px">
            <asp:Panel runat="Server" ID="programmaticPopupDragHandle" Style="cursor: move;background-color:#DDDDDD;border:solid 1px Gray;color:Black;text-align:center;">
                Status
            </asp:Panel>
                
            <asp:UpdatePanel id="UpdatePanel3" runat="server">
                <contenttemplate>
                    <br />
                    <asp:Label ID="lblStatusMessage" runat="server" Height="19px" Text="Label"></asp:Label>
                </contenttemplate>
            </asp:UpdatePanel>
           <%-- <asp:Label ID="lblStatusMessage" runat="server" Height="19px" Text="Label"></asp:Label>--%>
                <asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click" Width="58px" />    
             <br />
        </asp:Panel>
        <br />
        &nbsp; &nbsp; &nbsp;
        <asp:Label ID="Label2" runat="server" SkinID="UnicodeHeadlbl" Text="कार्यालयको विवरण"></asp:Label>
        <br />
    <br />
    <table width="900" style="height: 476px">
        <tr>
            <td style="width: 11px; height: 200px;">
            </td>
            <td colspan="2" style="height: 200px" valign="top">
                <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="कार्यालय छान्नुहोस्"></asp:Label><br />
                <asp:Panel ID="Panel1" runat="server" Height="200px" Width="400px" ScrollBars="Auto">
                    <asp:CheckBoxList ID="chkLstOrganization" runat="server">
                    </asp:CheckBoxList></asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="width: 11px">
            </td>
            <td colspan="2" valign="top">
                &nbsp;<table>
                    <tr>
                        <td style="width: 100px">
                <asp:Button ID="btnViewReport" runat="server" SkinID="Normal" Text="ViewReport" OnClick="btnViewReport_Click" /></td>
                        <td style="width: 100px">
                <asp:Button ID="btnCancel" runat="server" SkinID="Cancel" Text="Cancel" OnClick="btnCancel_Click1" /></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

