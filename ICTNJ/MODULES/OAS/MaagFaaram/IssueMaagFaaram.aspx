<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true" CodeFile="IssueMaagFaaram.aspx.cs" Inherits="MODULES_OAS_MaagFaaram_IssueMaagFaaram" Title="OAS | Maag Faaram Issue" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register Src="../UserControls/MaagFaaramSearch.ascx" TagName="MaagFaaramSearch"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" src="../../COMMON/JS/Validation.js" type="text/javascript"></script>
    <script language="javascript" src="../../COMMON/JS/DateValidator.js" type="text/javascript"></script>

    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup" runat="server"></asp:Button> <ajaxtoolkit:modalpopupextender id="programmaticModalPopup" runat="server" targetcontrolid="hiddenTargetControlForModalPopup" repositionmode="RepositionOnWindowScroll" popupdraghandlecontrolid="programmaticPopupDragHandle" popupcontrolid="programmaticPopup" dropshadow="True" behaviorid="programmaticModalPopupBehavior" backgroundcssclass="modalBackground">
        </ajaxtoolkit:modalpopupextender> <asp:Panel style="PADDING-RIGHT: 10px; DISPLAY: none; PADDING-LEFT: 10px; PADDING-BOTTOM: 10px; WIDTH: 350px; PADDING-TOP: 10px" id="programmaticPopup" runat="server" CssClass="modalPopup"><asp:Panel style="BORDER-RIGHT: gray 1px solid; BORDER-TOP: gray 1px solid; BORDER-LEFT: gray 1px solid; CURSOR: move; COLOR: black; BORDER-BOTTOM: gray 1px solid; BACKGROUND-COLOR: #dddddd; TEXT-ALIGN: center" id="programmaticPopupDragHandle" runat="Server">
            Status
        </asp:Panel> <asp:Label id="lblStatusMessage" runat="server" Text="Label"></asp:Label><BR /><asp:Button id="OkButton" onclick="hideModalPopupViaServer_Click" runat="server" Width="58px" Text="OK"></asp:Button> <BR /></asp:Panel><BR /><DIV style="HEIGHT: 700px" id="div1"><asp:Label id="Label1" runat="server" Text="मागको निकासा" SkinID="UnicodeHeadlbl" __designer:wfdid="w14"></asp:Label> <uc1:MaagFaaramSearch id="appMaagHeadControl" runat="server" __designer:wfdid="w15" Approve="false" Edit="false" Issue="true" DisplayAppDate="true" DisplayAppPerson="true" DisplayAppYesNo="true" DisplayIssueFlag="true" SelectApproval="true" SelectIssue="false" AppYesNo="Y"></uc1:MaagFaaramSearch><BR /><asp:Panel id="pnlMaagDetail" runat="server" Width="1000px" Height="250px" __designer:wfdid="w16"><TABLE style="WIDTH: 1024px"><TBODY><TR><TD style="WIDTH: 100px" vAlign=top><asp:Panel id="Panel1" runat="server" Width="1000px" Height="150px" __designer:wfdid="w17" ScrollBars="Auto"><asp:GridView id="grdIssueMaagDetails" runat="server" Width="800px" SkinID="Unicodegrd" __designer:wfdid="w18" OnRowDataBound="grdIssueMaagDetails_RowDataBound" AutoGenerateColumns="False"><Columns>
<asp:TemplateField HeaderText="सि.नं.">
<ItemStyle Width="30px"></ItemStyle>
<ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="ORGID" HeaderText="का.आई.डी."></asp:BoundField>
<asp:BoundField DataField="UNITID" HeaderText="ई.आई.डी."></asp:BoundField>
<asp:BoundField DataField="REQNO" HeaderText="माग आई.डी."></asp:BoundField>
<asp:BoundField DataField="ITEMSCATEGORYID" HeaderText="स.आई.डी."></asp:BoundField>
<asp:BoundField DataField="ITEMSCATEGORYNAME" HeaderText="समूह">
<ItemStyle Width="100px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ITEMSSUBCATEGORYID" HeaderText="उस.आई.डी."></asp:BoundField>
<asp:BoundField DataField="ITEMSSUBCATEGORYNAME" HeaderText="उप-समूह">
<ItemStyle Width="100px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ITEMSID" HeaderText="सा.आई.डी."></asp:BoundField>
<asp:BoundField DataField="ITEMSNAME" HeaderText="सामान">
<ItemStyle Width="100px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="REQQTY" HeaderText="माग परिमाण">
<ItemStyle Width="70px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="APPQTY" HeaderText="आदेश परिमाण"></asp:BoundField>
<asp:BoundField DataField="DELIVEREDQTY" HeaderText="निकासा परिमाण"></asp:BoundField>
<asp:TemplateField HeaderText="निकासा परिमाण">
<ItemStyle Width="100px"></ItemStyle>
<ItemTemplate>
<asp:TextBox id="txtDelQty" runat="server" Width="59px" __designer:wfdid="w3" AutoPostBack="True" OnTextChanged="txtDelQty_TextChanged"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="ITEMSUNITNAME" HeaderText="ईकाई">
<ItemStyle Width="70px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="JIKHAPANO" HeaderText="जि.खा.पा.नं.">
<ItemStyle Width="70px"></ItemStyle>
</asp:BoundField>
</Columns>
</asp:GridView> </asp:Panel> </TD></TR><TR><TD style="WIDTH: 100px" vAlign=top>&nbsp;<TABLE style="WIDTH: 958px"><TBODY><TR><TD style="WIDTH: 50px" vAlign=top><asp:Label id="Label2" runat="server" Width="40px" Text="मिति" SkinID="Unicodelbl" __designer:wfdid="w20"></asp:Label></TD><TD style="WIDTH: 200px" vAlign=top><asp:TextBox id="txtIssueDate_DT" runat="server" Width="90px" __designer:wfdid="w21" ToolTip="मिति"></asp:TextBox> <ajaxtoolkit:MaskedEditExtender id="MaskedEditExtender1" runat="server" __designer:wfdid="w22" TargetControlID="txtIssueDate_DT" MaskType="Date" Mask="9999/99/99" AutoComplete="False"></ajaxtoolkit:MaskedEditExtender></TD><TD style="WIDTH: 110px" vAlign=top><asp:Button id="btnSubmit" onclick="btnSubmit_Click" runat="server" Text="Submit" SkinID="Normal" __designer:wfdid="w23" OnClientClick="javascript:return validate(1);"></asp:Button></TD><TD vAlign=top>&nbsp; </TD><TD vAlign=top></TD></TR><TR><TD style="WIDTH: 50px" vAlign=top></TD><TD style="WIDTH: 200px" vAlign=top><asp:HiddenField id="hdnOrgID" runat="server" __designer:wfdid="w1"></asp:HiddenField> <asp:HiddenField id="hdnUnitID" runat="server" __designer:wfdid="w2"></asp:HiddenField> <asp:HiddenField id="hdnReqNo" runat="server" __designer:wfdid="w3"></asp:HiddenField> <asp:HiddenField id="hdnRcvdBy" runat="server" __designer:wfdid="w4"></asp:HiddenField></TD><TD style="WIDTH: 110px" vAlign=top></TD><TD vAlign=top></TD><TD vAlign=top></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></asp:Panel></DIV>
</contenttemplate>
    </asp:UpdatePanel>
</asp:Content>

