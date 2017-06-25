<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true" CodeFile="InvItemsTransfered.aspx.cs" Inherits="MODULES_OAS_Inventory_ReportForms_InvItemsTransfered" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground"
        BehaviorID="programmaticModalPopupBehavior" DropShadow="True" PopupControlID="programmaticPopup"
        PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
        TargetControlID="hiddenTargetControlForModalPopup">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="padding-right: 10px;
        display: none; padding-left: 10px; padding-bottom: 10px; width: 350px; padding-top: 10px">
        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD;
            border: solid 1px Gray; color: Black; text-align: center;">
            <asp:Label ID="lblStatus" runat="server" SkinID="Unicodelbl" Text="Status"></asp:Label></asp:Panel>
        <asp:Label ID="lblStatusMessage" runat="server" SkinID="Unicodelbl" Text="Label"></asp:Label><br />
        <asp:Button ID="OkButton" runat="server" Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    <table>
        <tr>
            <td style="width: 105px; height: 24px" valign="top">
                <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="समुह" Width="91px"></asp:Label></td>
            <td style="width: 100px; height: 24px" valign="top">
                <asp:DropDownList ID="ddlCategory" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                </asp:DropDownList></td>
            <td style="width: 100px; height: 24px" valign="top">
                <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="उप-समुह" Width="100px"></asp:Label></td>
            <td style="width: 122px; height: 24px" valign="top">
                <asp:DropDownList ID="ddlSubCategory" runat="server" SkinID="Unicodeddl" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddlSubCategory_SelectedIndexChanged">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 105px" valign="top">
                <asp:Label ID="Label3" runat="server" SkinID="Unicodelbl" Text="समानको नाम"></asp:Label></td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddlItems" runat="server" SkinID="Unicodeddl" Width="200px">
                </asp:DropDownList></td>
            <td style="width: 100px">
            </td>
            <td style="width: 112px">
            </td>
        </tr>
        <tr>
            <td style="width: 105px" valign="top">
                <asp:Label ID="Label6" runat="server" SkinID="Unicodelbl" Text="समानको किसिम" Width="120px"></asp:Label></td>
            <td colspan="3" valign="top">
                <asp:RadioButtonList ID="rdoItemType" runat="server" RepeatDirection="Horizontal"
                    SkinID="Unicoderadio" Width="566px">
                    <asp:ListItem Selected="True">सबै</asp:ListItem>
                    <asp:ListItem>खर्च भई जाने</asp:ListItem>
                    <asp:ListItem>खर्च नभई जाने</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td style="width: 105px" valign="top">
                </td>
            <td colspan="3" valign="top">
                </td>
        </tr>
        <tr>
            <td align="right" style="width: 105px" valign="top">
                <asp:Button ID="btnGenereate" runat="server" OnClick="btnGenereate_Click" SkinID="Normal"
                    Text="Generate" Width="81px" /></td>
            <td align="left" colspan="3" valign="top">
    &nbsp;<asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" SkinID="Cancel"
                    Text="Cancel" Width="77px" /></td>
        </tr>
    </table>
    <asp:Panel ID="Panel1" runat="server" Height="50px" Visible="False" Width="125px">
                <asp:Label ID="Label4" runat="server" SkinID="Unicodelbl" Text="From Date"></asp:Label>
                <asp:Label ID="Label5" runat="server" SkinID="Unicodelbl" Text="To Date"></asp:Label>
                <asp:TextBox ID="txtFromDate" runat="server" SkinID="Unicodetxt" Width="90px"></asp:TextBox>
                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="9999/99/99"
                    MaskType="Date" TargetControlID="txtToDate">
                </ajaxToolkit:MaskedEditExtender>
                <asp:TextBox ID="txtToDate" runat="server" SkinID="Unicodetxt" Width="90px"></asp:TextBox>
                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="9999/99/99"
                    MaskType="Date" TargetControlID="txtFromDate">
                </ajaxToolkit:MaskedEditExtender>
    </asp:Panel>
</asp:Content>

