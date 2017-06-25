<%@ Page Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" AutoEventWireup="true" CodeFile="FYWiseCaseRegistration.aspx.cs" Inherits="MODULES_CMS_ReportForms_FYWiseCaseRegistration" Title="Untitled Page" %>
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
    <table style="width: 785px">
        <tr>
            <td align="left" colspan="4" valign="top">
                <asp:RadioButtonList ID="rdblVeryfied" runat="server" RepeatDirection="Horizontal" SkinID="Unicoderadio" Width="424px">
                    <asp:ListItem Selected="True">सबै मुदाहरु</asp:ListItem>
                    <asp:ListItem Value="V">रुजी भऐका मुदाहरु</asp:ListItem>
                    <asp:ListItem Value="UV">रुजी नभऐका मुदाहरु</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td align="left" style="width: 1px" valign="top">
                <asp:Label ID="Label4" runat="server" SkinID="Unicodelbl" Text="कार्यालय"></asp:Label></td>
            <td align="left" style="width: 100px" valign="top">
                <asp:DropDownList ID="DDLOrg" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLOrg_SelectedIndexChanged"
                    SkinID="Unicodeddl" Width="300px">
                </asp:DropDownList></td>
            <td align="left" style="width: 58px" valign="top">
                <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="आ.व."></asp:Label></td>
            <td align="left" valign="top">
                <asp:TextBox ID="txtFY_RQD" runat="server" SkinID="Unicodetxt" Width="50px"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="left" style="width: 1px; height: 24px;" valign="top">
                <asp:Label ID="Label5" runat="server" SkinID="Unicodelbl" Text="मुदा प्रकार" Width="78px"></asp:Label></td>
            <td align="left" style="width: 100px; height: 24px;" valign="top"><asp:DropDownList ID="DDLCaseType" runat="server" SkinID="Unicodeddl" Width="300px" OnSelectedIndexChanged="DDLCaseType_SelectedIndexChanged" AutoPostBack="True">
            </asp:DropDownList></td>
            <td align="left" colspan="1" style="width: 58px; height: 24px" valign="top">
            </td>
            <td align="left" style="height: 24px;" valign="top" colspan="2">
                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AutoComplete="False"
                    ClearMaskOnLostFocus="False" Mask="99/99" MaskType="Number" TargetControlID="txtFY_RQD">
                </ajaxToolkit:MaskedEditExtender>
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 1px;" valign="top">
                <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="दर्ता किताब"
                    Width="76px"></asp:Label></td>
            <td align="left" colspan="2" valign="top">
                <asp:CheckBoxList ID="chkregDiry" runat="server" Width="297px">
                </asp:CheckBoxList></td>
            <td align="left" valign="top">
            </td>
        </tr>
        <tr>
            <td align="right" colspan="4" valign="top">
                <asp:Button ID="btnGenerate" runat="server" SkinID="Normal" Text="Generate" OnClick="btnGenerate_Click" />
                <asp:Button ID="btnCancel" runat="server" SkinID="Cancel" Text="Cancel" OnClick="btnCancel_Click" /></td>
        </tr>
    </table>
    <br />
    <br />
    <br />
</asp:Content>


