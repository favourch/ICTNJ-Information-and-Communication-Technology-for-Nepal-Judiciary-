<%@ Page Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master" AutoEventWireup="true" CodeFile="Designation.aspx.cs" Inherits="MODULES_PMS_LookUp_Designation" Title="PMS | Designation" %>

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
            <asp:UpdatePanel id="UpdatePanel2" runat="server">
                <contenttemplate>
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
</contenttemplate>
            </asp:UpdatePanel>
            <br />
<asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click" Width="58px" />           <br />
        </asp:Panel>    
    <br />
    <asp:Label ID="Label3" runat="server" SkinID="UnicodeHeadlbl" Text="पदको विवरण"></asp:Label>
    <br />
    <br />
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<TABLE style="WIDTH: 800px"><TBODY><TR><TD style="WIDTH: 270px" vAlign=top><asp:ListBox id="lstDesignation" runat="server" Width="255px" Height="207px" SkinID="Unicodelst" AutoPostBack="True" OnSelectedIndexChanged="lstDesignation_SelectedIndexChanged"></asp:ListBox></TD><TD vAlign=top><TABLE style="WIDTH: 400px"><TBODY><TR><TD style="WIDTH: 110px"><asp:Label id="lblDesignation" runat="server" Width="95px" Text="पद" SkinID="Unicodelbl"></asp:Label></TD><TD><asp:TextBox id="txtDesignation_Rqd" runat="server" Width="265px" SkinID="Unicodetxt" MaxLength="30" ToolTip="पद"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 110px" vAlign=top><asp:Label id="Label1" runat="server" Text="सेवा अवधि" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:TextBox id="txtServicePeriod" runat="server" Width="27px" MaxLength="2"></asp:TextBox> <asp:Label id="Label4" runat="server" Text="वर्ष" SkinID="Unicodelbl" __designer:wfdid="w1"></asp:Label> <ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender1" runat="server" TargetControlID="txtServicePeriod" FilterType="Numbers"></ajaxToolkit:FilteredTextBoxExtender></TD></TR><TR><TD style="WIDTH: 110px" vAlign=top><asp:Label id="Label2" runat="server" Text="उमेर सिमा" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:TextBox id="txtAgeLimit" runat="server" Width="27px" MaxLength="2"></asp:TextBox> <asp:Label id="Label5" runat="server" Text="वर्ष" SkinID="Unicodelbl" __designer:wfdid="w2"></asp:Label> <ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender2" runat="server" TargetControlID="txtAgeLimit" FilterType="Numbers"></ajaxToolkit:FilteredTextBoxExtender></TD></TR><TR><TD style="WIDTH: 110px">&nbsp; </TD><TD><asp:Button id="btnSubmit" onclick="btnSubmit_Click" runat="server" Text="Submit" SkinID="Normal" OnClientClick="javascript:return validate();"></asp:Button><asp:Button id="btnCancel" onclick="btnCancel_Click" runat="server" Text="Cancel" SkinID="Cancel"></asp:Button> <asp:Button id="btnDelete" onclick="btnDelete_Click" runat="server" Text="Delete" Visible="False"></asp:Button></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
</contenttemplate>
    </asp:UpdatePanel>
    <br />
    <br />

        <script language="javascript" type="text/javascript" src="../JS/Validation.js"></script>

    &nbsp;



</asp:Content>

