<%@ Page Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" AutoEventWireup="true" CodeFile="OrganizationCaseRegistrationtype.aspx.cs" Inherits="MODULES_CMS_LookUp_OrganizationCaseRegistrationtype" Title="CMS | Case Registration Type" %>
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
        <br />
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
<TABLE style="WIDTH: 837px"><TBODY><TR><TD style="HEIGHT: 21px" align=center><asp:Label id="Label1" runat="server" Text="कार्यालयहरू" SkinID="UnicodeHeadlbl"></asp:Label></TD><TD style="HEIGHT: 21px" align=center><asp:Label id="Label2" runat="server" Text="मूदाको किसिमहरु" SkinID="UnicodeHeadlbl"></asp:Label></TD><TD style="HEIGHT: 21px" align=center><asp:Label id="Label3" runat="server" Text="दर्ताको किसिमहरु" SkinID="UnicodeHeadlbl"></asp:Label></TD></TR><TR><TD style="WIDTH: 250px; HEIGHT: 300px" vAlign=top align=center rowSpan=2><asp:Panel id="Panel1" runat="server" Width="200px" Height="50px"><asp:ListBox id="lstOrganization" runat="server" Width="225px" Height="300px" SkinID="Unicodelst" AutoPostBack="True" OnSelectedIndexChanged="lstOrganization_SelectedIndexChanged"></asp:ListBox></asp:Panel></TD><TD style="WIDTH: 250px; HEIGHT: 300px" vAlign=top align=right rowSpan=2><asp:Panel id="Panel2" runat="server" Width="250px" Height="50px"><asp:ListBox id="lstCaseType" runat="server" Width="250px" Height="300px" SkinID="Unicodelst" AutoPostBack="True" OnSelectedIndexChanged="lstCaseType_SelectedIndexChanged"></asp:ListBox></asp:Panel></TD><TD style="WIDTH: 250px; HEIGHT: 300px" vAlign=top align=left rowSpan=2><asp:Panel id="Panel3" runat="server" Width="250px" Height="300px"><asp:GridView id="grdRegType" runat="server" SkinID="Unicodegrd" __designer:wfdid="w14" ForeColor="#333333" CellPadding="4" GridLines="None" AutoGenerateColumns="False" OnRowDataBound="grdRegType_RowDataBound">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:TemplateField><ItemTemplate>
<asp:CheckBox id="chkSelect" runat="server" __designer:wfdid="w3"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="RegTypeID" HeaderText="Registration Type ID"></asp:BoundField>
<asp:BoundField DataField="RegTypeName" HeaderText="Registration Type  Name"></asp:BoundField>
<asp:BoundField HeaderText="Active"></asp:BoundField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView></asp:Panel> </TD></TR><TR></TR><TR><TD rowSpan=1></TD><TD rowSpan=1></TD><TD vAlign=top align=left><asp:Button id="btnSubmit" onclick="btnSubmit_Click" runat="server" Text="Submit" SkinID="Normal"></asp:Button> <asp:Button id="btnCancel" runat="server" Text="Cancel" SkinID="Cancel" OnClick="btnCancel_Click"></asp:Button></TD></TR></TBODY></TABLE>
</contenttemplate>
    </asp:UpdatePanel>
    <br />
    <br />
    <br />
    
</asp:Content>

