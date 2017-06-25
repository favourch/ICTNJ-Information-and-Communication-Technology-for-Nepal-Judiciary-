<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true" CodeFile="InvItemsTransferedReport.aspx.cs" Inherits="MODULES_OAS_Inventory_ReportForms_InvItemsTransferedReport" Title="Untitled Page" %>
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
            <td style="width: 100px; height: 21px">
                <asp:Label ID="Label7" runat="server" Font-Size="11pt" SkinID="Unicodelbl" Text="समानको किसिम"
                    Width="107px"></asp:Label></td>
            <td style="width: 100px; height: 21px">
                <asp:DropDownList ID="ddlItemsType" runat="server" Width="233px">
                </asp:DropDownList></td>
            <td style="width: 100px; height: 21px">
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 100px; height: 26px">
                <asp:Button ID="btnGenerate" runat="server" SkinID="Normal" Text="Generate" OnClick="btnGenerate_Click" /></td>
            <td align="left" style="width: 100px; height: 26px">
                <asp:Button ID="btnCancel" runat="server" SkinID="Cancel" Text="Cancel" OnClick="btnCancel_Click" /></td>
            <td style="width: 100px; height: 26px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
</asp:Content>

