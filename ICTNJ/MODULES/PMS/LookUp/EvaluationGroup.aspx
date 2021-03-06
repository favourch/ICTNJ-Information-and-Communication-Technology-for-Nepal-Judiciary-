<%@ Page Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master" AutoEventWireup="true" CodeFile="EvaluationGroup.aspx.cs" Inherits="MODULES_PMS_LookUp_EvaluationGroup" Title="PMS | Evaluation Group" %>
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
<script language="javascript" type="text/javascript" src="../COMMON/JS/Validation.js"></script>
                <asp:ScriptManager id="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" style="display:none"/>
        <ajaxToolkit:ModalPopupExtender runat="server" ID="programmaticModalPopup"
            BehaviorID="programmaticModalPopupBehavior"
            TargetControlID="hiddenTargetControlForModalPopup"
            PopupControlID="programmaticPopup" 
            BackgroundCssClass="modalBackground"
            DropShadow="True"
            PopupDragHandleControlID="programmaticPopupDragHandle"
            RepositionMode="RepositionOnWindowScroll" >
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel runat="server" CssClass="modalPopup" ID="programmaticPopup" style="display:none;width:350px;padding:10px">
            <asp:Panel runat="Server" ID="programmaticPopupDragHandle" Style="cursor: move;background-color:#DDDDDD;border:solid 1px Gray;color:Black;text-align:center;">
                Status
            </asp:Panel>
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label><br />
<asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click" Width="58px" />           <br />
        </asp:Panel>
    <table style="width: 912px">
        <tr>
            <td colspan="1" style="width: 25px">
            </td>
            <td colspan="2">
                <asp:Label ID="Label2" runat="server" SkinID="UnicodeHeadlbl" Text="मुम्यांकन समूह"
                    Width="271px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 25px" valign="top">
            </td>
            <td style="width: 365px" valign="top">
                <asp:Panel ID="Panel1" runat="server" Height="400px" Width="100%">
                <asp:ListBox ID="lstEvaluationGroup" runat="server" Height="241px" Width="340px" OnSelectedIndexChanged="lstEvaluationGroup_SelectedIndexChanged" AutoPostBack="True" SkinID="Unicodelst"></asp:ListBox></asp:Panel>
            </td>
            <td valign="top">
                <table style="width: 400px">
                    <tr>
                        <td style="width: 114px" valign="top">
                            <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="मुम्यांकन समूह" Width="105px"></asp:Label></td>
                        <td valign="top">
                            <asp:TextBox ID="txtEvaluationGroup_Rqd" runat="server" MaxLength="100" SkinID="Unicodetxt"
                                Width="203px" ToolTip="Evaluation Group"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 114px">
                        </td>
                        <td>
                            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit"
                                Width="65px" OnClientClick="javascript:return validate();" SkinID="Normal" />
                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel"
                                Width="65px" SkinID="Cancel" /></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

