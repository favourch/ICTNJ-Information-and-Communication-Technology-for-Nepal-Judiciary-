<%@ Page Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" AutoEventWireup="true" CodeFile="SectionCaseType.aspx.cs" Inherits="MODULES_CMS_LookUp_SectionCaseType" Title="CMS | Section Case Type" %>
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
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<TABLE style="WIDTH: 829px"><TBODY><TR><TD vAlign=top align=left><asp:Label id="Label1" runat="server" Text="कार्यालय" SkinID="UnicodeHeadlbl"></asp:Label> </TD><TD vAlign=top align=left>&nbsp;<asp:Label id="Label3" runat="server" Text="मुदा किसिमहरु" SkinID="UnicodeHeadlbl">
</asp:Label></TD><TD vAlign=top align=left><asp:Label id="Label2" runat="server" Text="शाखाहरु" SkinID="UnicodeHeadlbl">
</asp:Label></TD></TR><TR><TD vAlign=top align=left><asp:Panel id="Panel1" runat="server" Width="250px" Height="250px">
                    <asp:ListBox ID="lstOrganization" runat="server" AutoPostBack="True" Height="250px"
                        OnSelectedIndexChanged="lstOrganization_SelectedIndexChanged" SkinID="Unicodelst"
                        Width="250px"></asp:ListBox></asp:Panel> </TD><TD vAlign=top align=left><asp:Panel id="Panel2" runat="server" Width="250px" Height="250px"><asp:ListBox id="lstCaseTypes" runat="server" Width="250px" Height="250px" SkinID="Unicodelst" OnSelectedIndexChanged="lstCaseTypes_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox></asp:Panel> </TD><TD vAlign=top align=left><asp:Panel id="Panel3" runat="server" Width="250px" Height="250px"><asp:GridView id="grdOrgUnits" runat="server" Width="250px" SkinID="Unicodegrd" OnRowDataBound="grdOrgUnits_RowDataBound" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" __designer:wfdid="w1">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:TemplateField ShowHeader="False"><ItemTemplate>
<asp:CheckBox id="chkSelect" runat="server" __designer:wfdid="w2"></asp:CheckBox>
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="UnitID" HeaderText="Unit ID"></asp:BoundField>
<asp:BoundField DataField="UnitName" HeaderText="शाखा"></asp:BoundField>
<asp:BoundField HeaderText="Action"></asp:BoundField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView></asp:Panel> </TD></TR><TR><TD vAlign=top align=right colSpan=1><ajaxToolkit:MaskedEditExtender id="mskFromDate" runat="server" AutoComplete="False" ClearMaskOnLostFocus="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtFromDate_RQD">
                </ajaxToolkit:MaskedEditExtender> </TD><TD vAlign=top align=right colSpan=1><asp:Label id="Label4" runat="server" Text="मिति" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top align=left colSpan=3><asp:TextBox id="txtFromDate_RQD" runat="server" Width="100px" SkinID="Unicodetxt"></asp:TextBox></TD></TR><TR><TD vAlign=top align=right colSpan=3><asp:Button id="btnSubmit" onclick="btnSubmit_Click" runat="server" Text="Submit" SkinID="Normal"></asp:Button> <asp:Button id="btnCancel" onclick="btnCancel_Click" runat="server" Text="Cancel" SkinID="Cancel"></asp:Button></TD></TR></TBODY></TABLE>
</contenttemplate>
    </asp:UpdatePanel>
    <br />
   
</asp:Content>

