<%@ Page Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" AutoEventWireup="true" CodeFile="CauseList.aspx.cs" Inherits="MODULES_CMS_ReportForms_CauseList" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <script language="javascript" src="../../COMMON/JS/Validation.js" type="text/javascript"></script>

    <script language="javascript" src="../../COMMON/JS/DateValidator.js" type="text/javascript"></script>

    <script language="javascript" src="../../COMMON/JS/EnglishDateValidator.js" type="text/javascript"></script>

    <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground"
        BehaviorID="programmaticModalPopupBehavior" DropShadow="True" PopupControlID="programmaticPopup"
        PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
        TargetControlID="hiddenTargetControlForModalPopup">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none;
        width: 350px; padding: 10px">
        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD;
            border: solid 1px Gray; color: Black; text-align: center;">
            <asp:Label ID="lblStatus" runat="server" Text="Label"></asp:Label>&nbsp;</asp:Panel>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <contenttemplate>
        <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
            </contenttemplate>
        </asp:UpdatePanel>
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
            Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    <br />
    <br />
    <br />
    <table style="width: 824px">
        <tr>
            <td align="left" colspan="2" valign="top">
                <asp:RadioButtonList ID="RDLTime" runat="server" RepeatDirection="Horizontal" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="RDLTime_SelectedIndexChanged">
                    <asp:ListItem Selected="True">Daily</asp:ListItem>
                    <asp:ListItem>Weekly</asp:ListItem>
                </asp:RadioButtonList></td>
            <td align="left" style="width: 100px" valign="top">
            </td>
            <td align="left" style="width: 100px" valign="top">
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 100px;" valign="top">
                <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="कार्यालय"></asp:Label></td>
            <td align="left" style="width: 100px;" valign="top">
                <asp:DropDownList ID="DDLOrg" runat="server" AutoPostBack="True" SkinID="Unicodeddl" Width="250px" OnSelectedIndexChanged="DDLOrg_SelectedIndexChanged">
                </asp:DropDownList></td>
            <td align="left" style="width: 100px;" valign="top">
                <asp:Label ID="Label2" runat="server" Text="मुदा किसिम" SkinID="Unicodelbl"></asp:Label></td>
            <td align="left" style="width: 100px;" valign="top">
                <asp:DropDownList ID="DDLCaseType" runat="server" SkinID="Unicodeddl" Width="250px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td align="left" style="width: 100px" valign="top">
                <asp:Label ID="Label3" runat="server" SkinID="Unicodelbl" Text="अव्धी देखि"></asp:Label></td>
            <td align="left" style="width: 100px" valign="top">
                <asp:TextBox ID="txtFromDate_RQD" runat="server" SkinID="Unicodetxt" Width="100px"></asp:TextBox>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <ajaxToolkit:MaskedEditExtender ID="mskFromdate" runat="server" AutoComplete="False"
                    ClearMaskOnLostFocus="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtFromDate_RQD">
                </ajaxToolkit:MaskedEditExtender>
            </td>
            <td align="left" style="width: 100px" valign="top">
                <asp:Label ID="lblToDate" runat="server" SkinID="Unicodelbl" Text="अव्धी सम्म"></asp:Label></td>
            <td align="left" style="width: 100px" valign="top">
                <asp:TextBox ID="txtToDate_RQD" runat="server" SkinID="Unicodetxt" Width="100px"></asp:TextBox>
                <ajaxToolkit:MaskedEditExtender ID="mskTodate" runat="server" AutoComplete="False"
                    ClearMaskOnLostFocus="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtToDate_RQD">
                </ajaxToolkit:MaskedEditExtender>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top" colspan="4">
                <asp:Button ID="btnGenerate" runat="server" SkinID="Normal" Text="Generate" OnClick="btnGenerate_Click" />
                <asp:Button ID="btnCancel" runat="server" SkinID="Cancel" Text="Cancel" /></td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>

