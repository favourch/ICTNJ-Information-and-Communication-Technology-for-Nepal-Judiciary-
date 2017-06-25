<%@ Page Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" AutoEventWireup="true" CodeFile="CaseProceedingWise.aspx.cs" Inherits="MODULES_CMS_Reports_CaseProceedingWise" Title="CMS | Case Proceeding Wise Report" %>


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
    <table style="width: 561px">
        <tr>
            <td align="left" style="width: 1px" valign="top">
                <asp:Label ID="Label1" runat="server" Text="अदालत " SkinID="Unicodelbl" Width="56px"></asp:Label></td>
            <td align="left" valign="top">
                <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Auto" Width="300px">
                    <asp:CheckBoxList ID="cbOrg" runat="server">
                    </asp:CheckBoxList></asp:Panel>
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 1px" valign="top">
                <asp:Label ID="Label2" runat="server" Text="मिति देखि" SkinID="Unicodelbl" Width="83px"></asp:Label></td>
            <td align="left" style="width: 100px" valign="top">
                <asp:TextBox ID="txtFromDate_RQD" runat="server" SkinID="Unicodetxt" Width="100px"></asp:TextBox>
                <ajaxToolkit:MaskedEditExtender ID="mskFD" runat="server" AutoComplete="False" ClearMaskOnLostFocus="False"
                    Mask="9999/99/99" MaskType="Date" TargetControlID="txtFromDate_RQD">
                </ajaxToolkit:MaskedEditExtender>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 1px" valign="top">
                <asp:Label ID="Label3" runat="server" Text="मिति सम्म" SkinID="Unicodelbl" Width="89px"></asp:Label></td>
            <td align="left" style="width: 100px" valign="top">
                <asp:TextBox ID="txtToDate_RQD" runat="server" SkinID="Unicodetxt" Width="100px"></asp:TextBox>
                <ajaxToolkit:MaskedEditExtender ID="mskTD" runat="server" AutoComplete="False" ClearMaskOnLostFocus="False"
                    Mask="9999/99/99" MaskType="Date" TargetControlID="txtToDate_RQD">
                </ajaxToolkit:MaskedEditExtender>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2" valign="top">
                <asp:Button ID="btnGenerate" runat="server" Text="Generate" OnClick="btnGenerate_Click" SkinID="Normal" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" SkinID="Cancel" /></td>
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
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>

