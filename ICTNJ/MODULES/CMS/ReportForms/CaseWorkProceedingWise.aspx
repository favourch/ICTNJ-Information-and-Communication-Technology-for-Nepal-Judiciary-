<%@ Page Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" AutoEventWireup="true" CodeFile="CaseWorkProceedingWise.aspx.cs" Inherits="MODULES_CMS_ReportForms_CaseWorkProceedingWise" Title="Case work Proceeding Wise" %>

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
        <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
            Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    <br />
    <table style="width: 829px">
        <tr>
            <td align="left" rowspan="3" style="width: 1px" valign="top">
                <asp:Panel ID="Panel1" runat="server" Height="250px" ScrollBars="Auto" Width="300px">
                    <asp:CheckBoxList ID="cbOrgWithChilds" runat="server">
                    </asp:CheckBoxList></asp:Panel>
            </td>
            <td align="left" valign="top">
                <asp:Label ID="Label1" runat="server" Text="आर्थिक वर्ष" Width="120px" SkinID="Unicodelbl"></asp:Label></td>
            <td align="left" valign="top">
                <asp:TextBox ID="txtFY_RQD" runat="server" SkinID="Unicodetxt" Width="50px"></asp:TextBox>
                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AutoComplete="False"
                    ClearMaskOnLostFocus="False" Mask="99/99" MaskType="Number" TargetControlID="txtFY_RQD">
                </ajaxToolkit:MaskedEditExtender>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" colspan="2" valign="top">
                <asp:Button ID="btnGenerate" runat="server" OnClick="btnGenerate_Click" SkinID="Normal"
                    Text="Generate" />
                <asp:Button ID="btnCancel" runat="server" SkinID="Cancel" Text="Cancel" OnClick="btnCancel_Click" /></td>
        </tr>
    </table>
</asp:Content>

