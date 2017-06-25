<%@ Page Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" AutoEventWireup="true" CodeFile="CaseProceeding.aspx.cs" Inherits="MODULES_CMS_LookUp_CaseProceeding" Title="CMS | Case Proceeding" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   <script language="javascript" src="../../COMMON/JS/Validation.js" type="text/javascript"></script>
        <script language="javascript" src="../../COMMON/JS/Validation.js" type="text/javascript"></script>
    <script language="javascript" src="../../COMMON/JS/DateValidator.js" type="text/javascript"></script>
    <script language="javascript" src="../../COMMON/JS/EnglishDateValidator.js" type="text/javascript"></script>

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
            Save Status
        </asp:Panel>
        <asp:UpdatePanel id="UpdatePanel2" runat="server">
            <contenttemplate>
        <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
</contenttemplate>
        </asp:UpdatePanel>
        <br />
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
            Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    <br />
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<TABLE style="WIDTH: 700px"><TBODY><TR><TD style="HEIGHT: 1px" vAlign=top align=center><asp:Label id="Label3" runat="server" Text="कामको किसिमहरु" SkinID="UnicodeHeadlbl"></asp:Label></TD><TD style="HEIGHT: 1px" vAlign=top></TD></TR><TR><TD style="HEIGHT: 1px" vAlign=top align=center><DIV style="OVERFLOW: scroll; WIDTH: 300px; HEIGHT: 400px"><asp:ListBox id="lstCaseProceeding" runat="server" Width="300px" Height="380px" SkinID="Unicodelst" AutoPostBack="True" OnSelectedIndexChanged="lstCaseProceeding_SelectedIndexChanged"></asp:ListBox> </DIV></TD><TD style="HEIGHT: 1px" vAlign=top><TABLE style="WIDTH: 340px"><TBODY><TR><TD style="WIDTH: 65px; HEIGHT: 1px" vAlign=top><asp:Label id="Label1" runat="server" Width="60px" Text="काम" SkinID="Unicodelbl"></asp:Label></TD><TD style="HEIGHT: 1px" vAlign=top><asp:TextBox id="txtCaseProceedingName_RQD" runat="server" Width="240px" Height="60px" SkinID="Unicodetxt" ToolTip="कामको किसिम" TextMode="MultiLine"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 65px" vAlign=top><asp:Label id="Label2" runat="server" Width="46px" Text="सक्रिय" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:CheckBox id="chkActive" runat="server" SkinID="smallChk"></asp:CheckBox></TD></TR><TR><TD style="WIDTH: 65px" vAlign=top></TD><TD vAlign=top><asp:Button id="btnSubmit" onclick="btnSubmit_Click" runat="server" Text="Submit" SkinID="Normal" ToolTip="काम" OnClientClick="javascript:return validate(0);"></asp:Button> <asp:Button id="btnCancel" onclick="btnCancel_Click" runat="server" Text="Cancel" SkinID="Cancel"></asp:Button></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
</contenttemplate>
    </asp:UpdatePanel>
    <br />

</asp:Content>
