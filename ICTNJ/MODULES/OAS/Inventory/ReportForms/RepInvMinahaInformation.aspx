<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true"
    CodeFile="RepInvMinahaInformation.aspx.cs" Inherits="MODULES_OAS_Inventory_ReportForms_RepInvMinahaInformation"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager runat="server" ID="sct">
    </asp:ScriptManager>
    <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="programmaticModalPopup" BehaviorID="programmaticModalPopupBehavior"
        TargetControlID="hiddenTargetControlForModalPopup" PopupControlID="programmaticPopup"
        BackgroundCssClass="modalBackground" DropShadow="True" PopupDragHandleControlID="programmaticPopupDragHandle"
        RepositionMode="RepositionOnWindowScroll">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel runat="server" CssClass="modalPopup" ID="programmaticPopup" Style="display: none;
        width: 350px; padding: 10px">
        <asp:Panel runat="Server" ID="programmaticPopupDragHandle" Style="cursor: move; background-color: #DDDDDD;
            border: solid 1px Gray; color: Black; text-align: center;">
            Save Status
        </asp:Panel>
        <asp:UpdatePanel id="UpdatePanel3" runat="server">
            <contenttemplate>
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
</contenttemplate>
        </asp:UpdatePanel>
        <br />
        <asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click"
            Width="58px" />
        <br />
    </asp:Panel>
    <asp:Label ID="lblStatus" runat="server" Font-Bold="True" SkinID="Unicodelbl"></asp:Label>
    <table width="900">
        <tr>
            <td style="width: 160px">
            </td>
            <td style="width: 100px" valign="top">
                <asp:Label ID="lblAuctionDate" runat="server" Text="मीनहा मिति" SkinID="Unicodelbl"
                    Width="99px"></asp:Label></td>
            <td colspan="5" valign="top">
                <table>
                    <tr>
                        <td style="width: 100px">
                            <asp:TextBox ID="txtMinahaDate" runat="server" SkinID="Unicodetxt" Width="73px"></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtMinahaDate"
                                AutoComplete="False" Mask="9999/99/99" MaskType="Date">
                            </ajaxToolkit:MaskedEditExtender>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 160px">
            </td>
            <td colspan="6">
                <hr />
            </td>
        </tr>
        <tr>
            <td style="width: 160px">
            </td>
            <td style="width: 100px" valign="top">
                <asp:Label ID="Label2" runat="server" Text="समुह" SkinID="Unicodelbl"></asp:Label></td>
            <td style="width: 100px" valign="top">
                <asp:DropDownList ID="ddlItemCategory" runat="server" AutoPostBack="True" SkinID="Unicodeddl"
                    Width="154px" OnSelectedIndexChanged="ddlItemCategory_SelectedIndexChanged1">
                </asp:DropDownList></td>
            <td style="width: 100px" valign="top">
                <asp:Label ID="Label3" runat="server" Text="उप-समुह" SkinID="Unicodelbl"></asp:Label></td>
            <td style="width: 100px" valign="top">
                <asp:DropDownList ID="ddlItemSubCategory" runat="server" SkinID="Unicodeddl" Width="153px"
                    AutoPostBack="True" OnSelectedIndexChanged="ddlItemSubCategory_SelectedIndexChanged">
                </asp:DropDownList></td>
            <td style="width: 100px" valign="top">
                <asp:Label ID="Label4" runat="server" Text="सामान" SkinID="Unicodelbl"></asp:Label></td>
            <td valign="top">
                <asp:DropDownList ID="ddlItem" runat="server" SkinID="Unicodeddl" Width="155px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 160px; height: 19px">
            </td>
        </tr>
        <tr>
            <td style="width: 160px">
            </td>
            <td style="width: 100px">
                <asp:Button ID="btnCreate" runat="server" Text="Create" SkinID="Normal" OnClick="btnCreate_Click" /></td>
            <td style="width: 100px">
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" SkinID="Cancel" OnClick="btnCancel_Click" /></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
