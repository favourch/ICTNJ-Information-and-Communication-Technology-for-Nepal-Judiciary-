<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Tippani.ascx.cs" Inherits="MODULES_OAS_UserControls_Tippani" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<div style="width:100%; height:auto">
    <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground"
        DropShadow="True" PopupControlID="programmaticPopup" PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
        TargetControlID="hiddenTargetControlForModalPopup">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none; width: 350px; padding: 10px">
        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD; border: solid 1px Gray; color: Black; text-align: center;">
            Save Status
        </asp:Panel>
        <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label><br />
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click" Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    <table style="width: 630px">
        <tr>
            <td colspan="4">
                <asp:Label ID="lblPersonStatus" runat="server" SkinID="UnicodeHeadlbl" Visible="False"></asp:Label>
                <ajaxToolkit:FilteredTextBoxExtender ID="fltFileNo" runat="server" FilterType="Numbers" TargetControlID="txtFileNo">
                </ajaxToolkit:FilteredTextBoxExtender>
            </td>
        </tr>
        <tr>
            <td style="width: 138px">
                &nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="सस्थां"></asp:Label></td>
            <td style="width: 205px">
                <asp:DropDownList ID="ddlOrg" runat="server" SkinID="Unicodeddl" Width="200px" Enabled="False">
                </asp:DropDownList></td>
            <td style="width: 80px">
                &nbsp;&nbsp;
                <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="टिप्पणी"></asp:Label></td>
            <td style="width: 207px">
                <asp:DropDownList ID="ddlTippaniSubject" runat="server" SkinID="Unicodeddl" Width="200px" Enabled="False">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 138px">
                &nbsp;&nbsp;
                <asp:Label ID="Label3" runat="server" SkinID="Unicodelbl" Text="बिषय"></asp:Label></td>
            <td style="width: 205px">
                <asp:TextBox ID="txtTippaniText" runat="server" SkinID="Unicodetxt" Width="196px"></asp:TextBox></td>
            <td style="width: 80px">
                &nbsp;&nbsp;
                <asp:Label ID="Label4" runat="server" SkinID="Unicodelbl" Text="फइल नं"></asp:Label></td>
            <td style="width: 207px">
                <asp:TextBox ID="txtFileNo" runat="server" SkinID="Unicodetxt" Width="196px" MaxLength="8"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 138px">
                &nbsp;&nbsp;
                <asp:Label ID="Label5" runat="server" SkinID="Unicodelbl" Text="प्राथमिक्ता"></asp:Label></td>
            <td style="width: 205px">
                <asp:DropDownList ID="ddlPriority" runat="server" SkinID="Unicodeddl" Width="200px">
                </asp:DropDownList></td>
            <td style="width: 80px">
            </td>
            <td style="width: 207px">
                <asp:HiddenField ID="hdnIDS" runat="server" />
            </td>
        </tr>
    </table>
    
</div>
