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
            <br />
            <asp:UpdatePanel id="UpdatePanel1" runat="server">
                <contenttemplate>
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
</contenttemplate>
            </asp:UpdatePanel>
            <br />
<asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click" Width="58px" />           <br />
        </asp:Panel>   &nbsp;<br />
    &nbsp; &nbsp; &nbsp;
    <asp:Label ID="Label2" runat="server" SkinID="UnicodeHeadlbl" Text="नियुक्तिको प्रकार"
                    Width="151px"></asp:Label><br />
    <asp:UpdatePanel id="UpdatePanel2" runat="server">
        <contenttemplate>
<TABLE style="WIDTH: 943px"><TBODY><TR><TD style="WIDTH: 20px; HEIGHT: 350px" vAlign=top rowSpan=1></TD><TD style="WIDTH: 253px; HEIGHT: 350px" vAlign=top rowSpan=1><asp:ListBox id="lstPostingType" runat="server" Width="239px" Height="190px" SkinID="Unicodelst" OnSelectedIndexChanged="lstPostingType_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox></TD><TD style="HEIGHT: 350px" vAlign=top><TABLE style="WIDTH: 366px"><TBODY><TR><TD style="WIDTH: 116px" vAlign=top><asp:Label id="Label1" runat="server" Width="115px" Text="नियुक्तिको प्रकार" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top>&nbsp;<asp:TextBox id="txtPostingType_Rqd" runat="server" Width="166px" SkinID="Unicodetxt" ToolTip="नियुक्तिको प्रकार" MaxLength="30"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 116px" vAlign=top><asp:Label id="Label3" runat="server" Text="सक्रिय" SkinID="Unicodelbl" __designer:wfdid="w3"></asp:Label></TD><TD vAlign=top><asp:CheckBox id="chkPostingType" runat="server" SkinID="smallChk" __designer:wfdid="w4"></asp:CheckBox></TD></TR><TR><TD style="WIDTH: 116px"></TD><TD vAlign=top><asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Width="60px" Text="Submit" SkinID="Normal"></asp:Button><asp:Button id="btnCancel" onclick="btnCancel_Click" runat="server" Width="60px" Text="Cancel" SkinID="Cancel"></asp:Button></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
</contenttemplate>
    </asp:UpdatePanel>
    <br />
</asp:Content>

