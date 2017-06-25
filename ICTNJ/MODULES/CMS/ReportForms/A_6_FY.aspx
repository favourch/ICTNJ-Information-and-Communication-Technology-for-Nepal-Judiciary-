<%@ Page Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" AutoEventWireup="true" CodeFile="A_6_FY.aspx.cs" Inherits="MODULES_CMS_ReportForms_A_6_FY" Title="Untitled Page" %>

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
    <table style="width: 824px">
        <tr>
            <td align="left" rowspan="1" style="width: 128px;" valign="top">
                <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="कार्यालय"></asp:Label></td>
            <td align="left" colspan="2" valign="top">
                <asp:DropDownList ID="DDLOrgWithChilds" runat="server" SkinID="Unicodeddl" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="DDLOrgWithChilds_SelectedIndexChanged">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td align="left" rowspan="1" style="width: 128px" valign="top">
                <asp:Label ID="Label4" runat="server" SkinID="Unicodelbl" Text="मुदाको किसिम"></asp:Label></td>
            <td align="left" colspan="2" valign="top">
                <asp:DropDownList ID="DDLCaseType" runat="server" SkinID="Unicodeddl" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="DDLCaseType_SelectedIndexChanged">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td align="left" rowspan="1" style="width: 128px" valign="top">
                <asp:Label ID="Label3" runat="server" SkinID="Unicodelbl" Text="दर्ताको किसिम"></asp:Label></td>
            <td align="left" colspan="2" valign="top">
                
                <asp:CheckBoxList ID="chkRegType" runat="server">
                </asp:CheckBoxList></td>
        </tr>
        <tr>
            <td align="left" rowspan="2" style="width: 128px" valign="top">
                <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="आ.व."></asp:Label></td>
            <td align="left" colspan="2" rowspan="2" valign="top">
                <asp:TextBox ID="txtFY_RQD" runat="server" SkinID="Unicodetxt" Width="70px"></asp:TextBox>
                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AutoComplete="False"
                    Mask="99/99" MaskType="Number" TargetControlID="txtFY_RQD">
                </ajaxToolkit:MaskedEditExtender>
            </td>
        </tr>
        <tr>
        </tr>
        <tr>
            <td align="left" style="width: 128px" valign="top">
            </td>
            <td align="center" colspan="2" valign="top">
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" SkinID="Normal"
                    Text="Submit" />
                <asp:Button ID="btnCancel" runat="server" SkinID="Cancel" Text="Cancel" /></td>
        </tr>
    </table>
    <br />
</asp:Content>

