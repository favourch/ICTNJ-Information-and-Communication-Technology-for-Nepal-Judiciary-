<%@ Page Language="C#" MasterPageFile="~/MODULES/LJMS/LJMSMasterPage.master" AutoEventWireup="true" CodeFile="PublicationType.aspx.cs" Inherits="MODULES_LJMS_LookUp_PublicationType" Title="Publication Type" %>

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
    <br />
    <br />
        
        
    <table width="900" style="height: 367px">
        <tr>
            <td rowspan="4" style="width: 215px" valign="top">
                <asp:ListBox ID="lstPubType" runat="server" Height="229px" SkinID="Unicodelst" Width="217px" AutoPostBack="True" OnSelectedIndexChanged="lstPubType_SelectedIndexChanged">
                </asp:ListBox></td>
            <td style="width: 150px">
                <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="पब्लिकेशनको किसिम"
                    Width="150px"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtPublicationType" runat="server" SkinID="Unicodetxt" Width="255px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 150px">
                <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="सक्रिय"></asp:Label></td>
            <td>
                <asp:CheckBox ID="chkActive" runat="server" SkinID="smallChk" /></td>
        </tr>
        <tr>
            <td style="width: 150px; height: 118px;" valign="top">
                <asp:Button ID="btnSubmit" runat="server" SkinID="Normal" Text="Submit" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnCancel" runat="server" SkinID="Cancel" Text="Cancel" OnClick="btnCancel_Click" /></td>
            <td style="height: 118px">
            </td>
        </tr>
    </table>
</asp:Content>

