<%@ Page Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" AutoEventWireup="true" CodeFile="OrganizationDecisionType.aspx.cs" Inherits="MODULES_CMS_LookUp_OrganizationDecisionType" Title="CMS | Decision Type" %>
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
    &nbsp; &nbsp;<br />
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<TABLE style="WIDTH: 800px"><TBODY><TR><TD style="WIDTH: 21px; HEIGHT: 1px" vAlign=top></TD><TD style="WIDTH: 129px; HEIGHT: 1px" vAlign=top></TD><TD style="WIDTH: 251px; HEIGHT: 1px" vAlign=top><asp:HiddenField id="hdnDecTypeID" runat="server" __designer:wfdid="w3"></asp:HiddenField></TD><TD style="HEIGHT: 1px" vAlign=top rowSpan=1></TD></TR><TR><TD style="WIDTH: 21px" vAlign=top></TD><TD style="WIDTH: 129px" vAlign=top><asp:Label id="lblDecisionType" runat="server" Width="120px" Text="फैसलाको किसिम" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 251px" vAlign=top><asp:TextBox id="txtDecisionTypeName_RQD" runat="server" Width="240px" MaxLength="100"></asp:TextBox></TD><TD vAlign=top align=right rowSpan=3><asp:Panel id="Panel2" runat="server" Width="350px" Height="280px" __designer:wfdid="w1" HorizontalAlign="Left" ScrollBars="Auto"><asp:GridView id="grdOrganization" runat="server" Width="313px" SkinID="Unicodegrd" GridLines="None" CellPadding="4" ForeColor="#333333" OnRowDataBound="grdOrganization_RowDataBound" AutoGenerateColumns="False" __designer:wfdid="w2">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:TemplateField><EditItemTemplate>
<asp:TextBox runat="server" id="TextBox1"></asp:TextBox>
</EditItemTemplate>

<ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
<ItemTemplate>
<asp:CheckBox id="chkSelect" runat="server" __designer:wfdid="w4"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="ORGID" HeaderText="Org ID"></asp:BoundField>
<asp:BoundField DataField="ORGNAME" HeaderText="कार्यालय">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField HeaderText="Active"></asp:BoundField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView></asp:Panel></TD></TR><TR><TD style="WIDTH: 21px" vAlign=top></TD><TD style="WIDTH: 129px" vAlign=top></TD><TD style="WIDTH: 251px" vAlign=top></TD></TR><TR><TD style="WIDTH: 21px" vAlign=top colSpan=1></TD><TD vAlign=top colSpan=2><asp:Panel id="Panel1" runat="server" Width="380px" Height="260px" HorizontalAlign="Right" ScrollBars="Auto"><asp:ListBox id="lstDecisionType" runat="server" Width="100%" Height="250px" SkinID="Unicodelst" OnSelectedIndexChanged="lstDecisionType_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox></asp:Panel></TD></TR><TR><TD style="WIDTH: 21px" vAlign=top></TD><TD style="WIDTH: 129px" vAlign=top></TD><TD style="WIDTH: 251px" vAlign=top></TD><TD vAlign=top align=right><asp:Button id="btnSubmit" onclick="btnSubmit_Click" runat="server" Text="Submit" SkinID="Normal" OnClientClick="javascript:return validate(0);" ToolTip="फैसलाको किसिम"></asp:Button> <asp:Button id="btnCancel" onclick="btnCancel_Click" runat="server" Text="Cancel" SkinID="Cancel"></asp:Button> </TD></TR></TBODY></TABLE>
</contenttemplate>
    </asp:UpdatePanel>
    <br />
    <br />
</asp:Content>

