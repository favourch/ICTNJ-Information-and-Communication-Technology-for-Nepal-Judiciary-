<%@ Page Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master" AutoEventWireup="true" CodeFile="PostingType.aspx.cs" Inherits="MODULES_PMS_LookUp_PostingType" Title="Untitled Page" %>
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
    <script language="javascript" type="text/javascript" src ="../../COMMON/JS/Validation.js"></script>

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
                Save Status
            </asp:Panel>
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label><br />
<asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click" Width="58px" />           <br />
        </asp:Panel>   
    <table style="width: 943px">
        <tr>
            <td colspan="2">
                <asp:Label ID="Label2" runat="server" SkinID="UnicodeHeadlbl" Text="नियुक्तिको प्रकार"
                    Width="151px"></asp:Label></td>
        </tr>
        <tr>
            <td rowspan="1" style="width: 235px; height: 350px;" valign="top">
                <asp:ListBox ID="lstPostingType" runat="server" Height="190px" Width="225px" AutoPostBack="True" OnSelectedIndexChanged="lstPostingType_SelectedIndexChanged" SkinID="Unicodelst"></asp:ListBox></td>
            <td valign="top" style="height: 350px">
                <table style="width: 366px">
                    <tr>
                        <td style="width: 120px" valign="top">
                            <asp:Label ID="Label1" runat="server" Text="नियुक्तिको प्रकार" SkinID="Unicodelbl" Width="115px"></asp:Label></td>
                        <td valign="top">
                            <asp:TextBox ID="txtPostingType_Rqd" runat="server" MaxLength="30" Width="166px" ToolTip="नियुक्तिको प्रकार" SkinID="Unicodetxt"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 120px">
                        </td>
                        <td valign="top">
                            <asp:Button ID="btnSave" runat="server" Text="Save" Width="60px" OnClick="btnSave_Click" OnClientClick="javascript:return validate();" SkinID="Normal" /><asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="60px" OnClick="btnCancel_Click" SkinID="Cancel" /></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

