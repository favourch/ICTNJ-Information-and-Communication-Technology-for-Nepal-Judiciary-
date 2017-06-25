<%@ Page Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master" AutoEventWireup="true" CodeFile="LeaveType.aspx.cs" Inherits="MODULES_PMS_LookUp_LeaveType" Title="PMS | Leave Type" %>

<%@ Register 
    Assembly="AjaxControlToolkit" 
    Namespace="AjaxControlToolkit" 
    TagPrefix="ajaxToolkit" %>
    
  <script runat="server">

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
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
            Status
        </asp:Panel>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
        <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
            Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    <br />
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
    <table style="width: 642px; height: 347px">
        <tr>
            <td colspan="1" rowspan="1" style="width: 17px" valign="top">
            </td>
            <td colspan="3" rowspan="1" valign="top">
                <asp:Label ID="Label1" runat="server" Font-Bold="False" Text="बिदाको किसिम" SkinID="UnicodeHeadlbl"></asp:Label></td>
        </tr>
        <tr>
            <td rowspan="4" style="width: 17px" valign="top">
            </td>
            <td rowspan="4" valign="top" style="width: 190px">
                <asp:ListBox ID="lstLeaveType" runat="server" AutoPostBack="True" Height="254px"
                    Width="184px" OnSelectedIndexChanged="lstLeaveType_SelectedIndexChanged" SkinID="Unicodelst"></asp:ListBox></td>
            <td style="width: 110px" valign="top">
                <asp:Label ID="lblLeaveType" runat="server" Text="बिदाको किसिम" Width="100px" SkinID="Unicodelbl"></asp:Label></td>
            <td style="width: 252px" valign="top">
                <asp:TextBox ID="txtLeveType_Rqd" runat="server" MaxLength="15" ToolTip="बिदाको किसिम"
                    Width="129px" SkinID="Unicodetxt"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 110px" valign="top">
                <asp:Label ID="Label3" runat="server" SkinID="Unicodelbl" Text="लिंग"></asp:Label></td>
            <td style="width: 252px" valign="top">
                <asp:DropDownList ID="ddlGender" runat="server" SkinID="Unicodeddl" Width="135px">
                    <asp:ListItem Value="SG">छान्नुहोस</asp:ListItem>
                    <asp:ListItem Value="M">पुरुष</asp:ListItem>
                    <asp:ListItem Value="F">महिला</asp:ListItem>
                    <asp:ListItem Value="O">अन्य</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 110px" valign="top">
                <asp:Label ID="Label2" runat="server" Text="सक्रिय" SkinID="Unicodelbl"></asp:Label></td>
            <td style="width: 252px" valign="top">
                <asp:CheckBox ID="chkLeaveType" runat="server" SkinID="smallChk" /></td>
        </tr>
        <tr>
            <td align="left" colspan="2" style="height: 173px" valign="top">
                <asp:Button
                    ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" OnClientClick="javascript:return validate();" Width="55px" SkinID="Normal" /><asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" Width="55px" SkinID="Cancel" />
                <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click"
                    Text="Delete" Width="55px" Visible="False" SkinID="Normal" /></td>
        </tr>
    </table></contenttemplate>
    </asp:UpdatePanel>
    &nbsp;<br />
    <br />

        <script language="javascript" type="text/javascript" src="../JS/Validation.js"></script>

    &nbsp;



</asp:Content>

