<%@ Page Language="C#" MasterPageFile="~/MODULES/LJMS/LJMSMasterPage.master" AutoEventWireup="true" CodeFile="Designation.aspx.cs" Inherits="MODULES_LJMS_LookUp_Designation" Title="LJMS | Designation" %>

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
    <asp:Label ID="Label3" runat="server" SkinID="UnicodeHeadlbl" Text="पदको विवरण"></asp:Label>
    <table style="width: 800px">
        <tr>
            <td valign="top" style="width: 270px">
                <asp:ListBox ID="lstDesignation" runat="server" AutoPostBack="True" Height="207px"
                    OnSelectedIndexChanged="lstDesignation_SelectedIndexChanged" Width="255px" SkinID="Unicodelst"></asp:ListBox></td>
            <td valign="top">
                <table style="width: 400px">
                    <tr>
                        <td style="width: 110px">
                <asp:Label ID="lblDesignation" runat="server" Text="पद" Width="95px" SkinID="Unicodelbl"></asp:Label></td>
                        <td>
                <asp:TextBox ID="txtDesignation_Rqd" runat="server" MaxLength="20" Width="200px" ToolTip="पद" SkinID="Unicodetxt"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 110px">
                            &nbsp;
                        </td>
                        <td>
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" OnClientClick="javascript:return validate();" SkinID="Normal" /><asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" SkinID="Cancel" />
                            <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" Visible="False" /></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <br />

        <script language="javascript" type="text/javascript" src="../JS/Validation.js"></script>

    &nbsp;



</asp:Content>

