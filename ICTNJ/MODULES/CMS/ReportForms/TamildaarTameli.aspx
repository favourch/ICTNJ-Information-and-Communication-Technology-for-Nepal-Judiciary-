<%@ Page AutoEventWireup="true" CodeFile="TamildaarTameli.aspx.cs" Inherits="MODULES_CMS_ReportForms_TamildaarTameli"
    Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" Title="Untitled Page" %>

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
    <br />
    <table style="width: 826px">
        <tr>
            <td align="left" colspan="4" valign="middle">
                <asp:RadioButtonList ID="rdblTameli" runat="server" SkinID="Unicoderadio" Width="330px">
                    <asp:ListItem Value="TV" Selected="True">तामेलि भएका र रुजु भएका मुदाहरु</asp:ListItem>
                    <asp:ListItem Value="TUV">तामेलि भएका र रुजु नभएका मुदाहरु</asp:ListItem>
                    <asp:ListItem Value="TN">तामेलि नभएका मुदाहरु</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td align="left" valign="middle">
                <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="कार्यालय"></asp:Label></td>
            <td align="left" style="width: 258px" valign="middle">
                <asp:DropDownList ID="DDLOrgWithChilds" runat="server" SkinID="Unicodeddl" Width="250px" AutoPostBack="True" OnSelectedIndexChanged="DDLOrgWithChilds_SelectedIndexChanged">
                </asp:DropDownList></td>
            <td align="left" style="width: 128px" valign="middle">
                <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="मुदाको प्रकार"></asp:Label></td>
            <td align="left" valign="middle">
                <asp:DropDownList ID="DDLCaseType" runat="server" SkinID="Unicodeddl" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="DDLCaseType_SelectedIndexChanged">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td align="left" style="height: 21px" valign="top">
                <asp:Label ID="Label4" runat="server" SkinID="Unicodelbl" Text="तामिलदार" Width="76px"></asp:Label></td>
            <td align="left" style="width: 258px; height: 21px" valign="middle">
                <asp:Panel ID="Panel1" runat="server" Height="150px" Width="300px" ScrollBars="Auto">
                    <asp:CheckBoxList ID="chkTamildaar" runat="server" Height="129px" Width="277px">
                    </asp:CheckBoxList></asp:Panel>
            </td>
            <td align="left" style="width: 128px; height: 21px" valign="top">
                <asp:Label ID="Label3" runat="server" SkinID="Unicodelbl" Text="दर्ता किताब" Width="76px"></asp:Label></td>
            <td align="left" style="height: 21px" valign="top">
                <asp:Panel ID="Panel2" runat="server" Height="150px" ScrollBars="Auto" Width="300px">
                <asp:CheckBoxList ID="chkregDiry" runat="server" Height="143px" Width="277px">
                </asp:CheckBoxList></asp:Panel>
            </td>
        </tr>
        <tr>
            <td align="left" style="height: 21px" valign="middle">
            </td>
            <td align="left" style="width: 258px; height: 21px" valign="middle">
            </td>
            <td align="left" style="width: 128px; height: 21px" valign="middle">
            </td>
            <td align="left" style="height: 21px" valign="middle">
                <asp:Button ID="btnGenerate" runat="server" OnClick="btnGenerate_Click" SkinID="Normal"
                    Text="Generate" />
                <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" SkinID="Cancel"
                    Text="Cancel" /></td>
        </tr>
    </table>
    <br />
</asp:Content>

