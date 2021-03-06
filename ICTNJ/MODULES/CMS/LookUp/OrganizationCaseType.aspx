<%@ Page Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" AutoEventWireup="true" CodeFile="OrganizationCaseType.aspx.cs" Inherits="MODULES_CMS_LookUp_OrganizationCaseType" Title="PMS | Case Type" %>
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
    &nbsp;
    <br />
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<TABLE style="WIDTH: 800px"><TBODY><TR><TD vAlign=top align=right><asp:HiddenField id="hdnCaseTypeID" runat="server" __designer:wfdid="w23"></asp:HiddenField></TD><TD style="WIDTH: 442px" vAlign=top></TD></TR><TR><TD vAlign=top><TABLE width="100%"><TBODY><TR><TD style="WIDTH: 100px; HEIGHT: 21px"><asp:Label id="Label1" runat="server" Text="मुदाको नाम" SkinID="Unicodelbl" __designer:wfdid="w14"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 21px"><asp:TextBox id="txtCaseTypeName_RQD" runat="server" Width="260px" SkinID="Unicodetxt" __designer:wfdid="w15"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 100px"><asp:Label id="Label2" runat="server" Text="वादि" SkinID="Unicodelbl" __designer:wfdid="w14"></asp:Label></TD><TD style="WIDTH: 100px"><asp:TextBox id="txtAppellant" runat="server" Width="259px" SkinID="Unicodetxt" __designer:wfdid="w16"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 26px"><asp:Label id="Label3" runat="server" Text="प्रतिवादि" SkinID="Unicodelbl" __designer:wfdid="w14"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 26px"><asp:TextBox id="txtRespondant" runat="server" Width="258px" SkinID="Unicodetxt" __designer:wfdid="w17"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 100px"></TD><TD align=right><asp:CheckBox id="chkActive" runat="server" __designer:wfdid="w22"></asp:CheckBox></TD></TR></TBODY></TABLE></TD><TD style="WIDTH: 442px" vAlign=top align=left rowSpan=2><asp:Panel id="Panel3" runat="server" Width="400px" Height="300px" __designer:wfdid="w20" ScrollBars="Auto"><asp:GridView id="grdOrganization" runat="server" Width="350px" __designer:wfdid="w24" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="grdOrganization_RowDataBound">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:TemplateField><ItemTemplate>
<asp:CheckBox id="chkSelect" runat="server" __designer:wfdid="w1"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="OrgID" HeaderText="Org ID"></asp:BoundField>
<asp:BoundField DataField="OrgName" HeaderText="कार्यालयको नाम"></asp:BoundField>
<asp:BoundField HeaderText="सर्किय"></asp:BoundField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView></asp:Panel></TD></TR><TR><TD style="WIDTH: 350px" vAlign=top><asp:Panel id="Panel1" runat="server" Width="300px" Height="200px" __designer:wfdid="w11"><asp:GridView id="grdCaseType" runat="server" SkinID="Unicodegrd" __designer:wfdid="w13" AutoGenerateColumns="False" OnSelectedIndexChanged="grdCaseType_SelectedIndexChanged"><Columns>
<asp:BoundField DataField="CaseTypeID" HeaderText="CaseTpeID"></asp:BoundField>
<asp:BoundField DataField="CaseTypeName" HeaderText="मुद्दाको नाम"></asp:BoundField>
<asp:BoundField DataField="Appellant" HeaderText="वादि"></asp:BoundField>
<asp:BoundField DataField="Respondant" HeaderText="प्रतिवादि"></asp:BoundField>
<asp:BoundField DataField="Active" HeaderText="सकृय"></asp:BoundField>
<asp:CommandField ShowSelectButton="True"></asp:CommandField>
</Columns>
</asp:GridView></asp:Panel></TD></TR><TR><TD style="WIDTH: 350px" vAlign=top></TD><TD style="WIDTH: 442px" vAlign=top align=right><asp:Button id="btnSubmit" onclick="btnSubmit_Click" runat="server" Text="Submit" SkinID="Normal"></asp:Button><asp:Button id="btnCancel" onclick="btnCancel_Click" runat="server" Text="Cancel" SkinID="Cancel"></asp:Button></TD></TR></TBODY></TABLE>
</contenttemplate>
    </asp:UpdatePanel>
    &nbsp;&nbsp;<br />
    
    </asp:Content>

