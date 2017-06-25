<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true" CodeFile="AuctionDetails.aspx.cs" Inherits="MODULES_OAS_Inventory_ReportForms_AuctionDetails" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
    &nbsp;<br />
    &nbsp; &nbsp;&nbsp;
    <asp:Label ID="Label1" runat="server" SkinID="UnicodeHeadlbl" Text="निलामी विवरण रिपोर्ट"></asp:Label><br />
    <br />
    <table width="900">
        <tr>
            <td style="width: 15px">
            </td>
            <td style="width: 37px" valign="top">
                <asp:Label ID="lblAuctionDate" runat="server" Text="निलामी मिति" SkinID="Unicodelbl"
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
            <td style="width: 15px">
            </td>
            <td colspan="6">
                <hr />
            </td>
        </tr>
        <tr>
            <td style="width: 15px">
            </td>
            <td style="width: 37px" valign="top">
                <asp:Label ID="Label2" runat="server" Text="समुह" SkinID="Unicodelbl" Width="37px"></asp:Label></td>
            <td style="width: 183px" valign="top">
                <asp:DropDownList ID="ddlItemCategory" runat="server" AutoPostBack="True" SkinID="Unicodeddl"
                    Width="166px" OnSelectedIndexChanged="ddlItemCategory_SelectedIndexChanged1">
                </asp:DropDownList></td>
            <td style="width: 64px" valign="top">
                <asp:Label ID="Label3" runat="server" Text="उप-समुह" SkinID="Unicodelbl" Width="62px"></asp:Label></td>
            <td style="width: 185px" valign="top">
                <asp:DropDownList ID="ddlItemSubCategory" runat="server" SkinID="Unicodeddl" Width="166px"
                    AutoPostBack="True" OnSelectedIndexChanged="ddlItemSubCategory_SelectedIndexChanged">
                </asp:DropDownList></td>
            <td style="width: 46px" valign="top">
                <asp:Label ID="Label4" runat="server" Text="सामान" SkinID="Unicodelbl" Width="46px"></asp:Label></td>
            <td valign="top">
                <asp:DropDownList ID="ddlItem" runat="server" SkinID="Unicodeddl" Width="166px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 15px; height: 19px">
            </td>
        </tr>
        <tr>
            <td style="width: 15px">
            </td>
            <td style="width: 37px">
                <asp:Button ID="btnCreate" runat="server" Text="View Report" SkinID="Normal" OnClick="btnCreate_Click" /></td>
            <td style="width: 183px">
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" SkinID="Cancel" OnClick="btnCancel_Click" /></td>
            <td style="width: 64px">
            </td>
            <td style="width: 185px">
            </td>
            <td style="width: 46px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="7" style="height: 170px">
            </td>
        </tr>
    </table>
</asp:Content>

