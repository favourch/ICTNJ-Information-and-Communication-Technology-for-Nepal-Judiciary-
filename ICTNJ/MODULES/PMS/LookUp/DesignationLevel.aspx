<%@ Page Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master" AutoEventWireup="true" CodeFile="DesignationLevel.aspx.cs" Inherits="MODULES_PMS_LookUp_DesignationLevel" Title="PMS | Designation Level" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
    <ajaxtoolkit:modalpopupextender id="programmaticModalPopup" runat="server" backgroundcssclass="modalBackground"
        behaviorid="programmaticModalPopupBehavior" dropshadow="True" popupcontrolid="programmaticPopup"
        popupdraghandlecontrolid="programmaticPopupDragHandle" repositionmode="RepositionOnWindowScroll"
        targetcontrolid="hiddenTargetControlForModalPopup">
    </ajaxtoolkit:modalpopupextender>
    <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none;
        width: 350px; padding: 10px">
        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD;
            border: solid 1px Gray; color: Black; text-align: center;">
            Status
        </asp:Panel>
        <contenttemplate></contenttemplate>
        <asp:UpdatePanel id="UpdatePanel3" runat="server">
            <contenttemplate>
<BR /><asp:Label id="lblStatusMessage" runat="server" Height="19px" Text="Label"></asp:Label> <BR />
</contenttemplate>
        </asp:UpdatePanel>
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
            Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    <br />
    &nbsp; &nbsp; &nbsp;&nbsp;
    <asp:Label ID="Label3" runat="server" SkinID="UnicodeHeadlbl" Text="श्रेणीको विवरण"></asp:Label>
    <br />
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<TABLE style="WIDTH: 517px"><TBODY><TR><TD style="WIDTH: 21px" vAlign=top rowSpan=2></TD><TD style="WIDTH: 197px" vAlign=top rowSpan=2><asp:ListBox id="lstDesignationLevel" runat="server" Width="159px" Height="210px" SkinID="Unicodelst" OnSelectedIndexChanged="lstDesignationLevel_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox></TD><TD style="WIDTH: 51px; HEIGHT: 11px" vAlign=top><asp:Label id="Label1" runat="server" Width="50px" Text="श्रेणी" SkinID="Unicodelbl"></asp:Label></TD><TD style="HEIGHT: 11px" vAlign=top><asp:TextBox id="txtLevel" runat="server" Width="225px" SkinID="Unicodetxt" MaxLength="30"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 51px; HEIGHT: 162px">&nbsp;</TD><TD style="HEIGHT: 162px" vAlign=top><asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Width="59px" Text="Submit" SkinID="Normal"></asp:Button> <asp:Button id="btnCancel" onclick="btnCancel_Click" runat="server" Text="Cancel" SkinID="Cancel"></asp:Button> </TD></TR></TBODY></TABLE>
</contenttemplate>
    </asp:UpdatePanel>
    <br />
    <div style="width:100%; height:386px">
    
    </div>
</asp:Content>


