<%@ Page Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master" AutoEventWireup="true" CodeFile="RelationType.aspx.cs" Inherits="MODULES_PMS_LookUp_RelationType" Title="PMS | Relation Type" %>
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
            <br />
            <asp:UpdatePanel id="UpdatePanel1" runat="server">
                <contenttemplate>
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
</contenttemplate>
            </asp:UpdatePanel>
            <br />
<asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click" Width="58px" />           <br />
        </asp:Panel>
    <br />
    &nbsp; &nbsp; &nbsp;
                <asp:Label ID="Label2" runat="server" SkinID="UnicodeHeadlbl" Text="सम्बन्ध"
                    Width="73px"></asp:Label>
    <br />
    <asp:UpdatePanel id="UpdatePanel2" runat="server">
        <contenttemplate>
    <table style="width: 912px">
        <tr>
            <td style="width: 18px" valign="top">
            </td>
            <td style="width: 211px" valign="top">
                <asp:Panel ID="Panel1" runat="server" Height="250px" Width="200px" ScrollBars="Auto">
                <asp:ListBox ID="lstRelationTypes" runat="server" Height="241px" Width="200px" OnSelectedIndexChanged="lstRelationTypes_SelectedIndexChanged" AutoPostBack="True" SkinID="Unicodelst"></asp:ListBox></asp:Panel>
            </td>
            <td valign="top">
                <table style="width: 400px">
                    <tr>
                        <td style="width: 114px" valign="top">
                            <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="सम्बन्धको नाम" Width="105px"></asp:Label></td>
                        <td valign="top">
                            <asp:TextBox ID="txtRelationType_Rqd" runat="server" MaxLength="25" SkinID="Unicodetxt"
                                Width="203px" ToolTip="सम्बन्धको नाम"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 114px" valign="top">
                            <asp:Label ID="Label3" runat="server" SkinID="Unicodelbl" Text="संख्या" Width="105px"></asp:Label></td>
                        <td valign="top">
                            <asp:TextBox ID="txtCardinality" runat="server" Width="36px" MaxLength="2" SkinID="Unicodetxt"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers" TargetControlID="txtCardinality">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
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
    </table></contenttemplate>
    </asp:UpdatePanel>
    <br />
</asp:Content>

