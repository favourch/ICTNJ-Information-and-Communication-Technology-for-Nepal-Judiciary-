<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true" CodeFile="ApproveMaagFaaram.aspx.cs" Inherits="MODULES_OAS_MaagFaaram_ApproveMaagFaaram" Title="OAS | Maag Faaram Approve" %>

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
<asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup" runat="server"></asp:Button> <ajaxtoolkit:modalpopupextender id="programmaticModalPopup" runat="server" backgroundcssclass="modalBackground" behaviorid="programmaticModalPopupBehavior" dropshadow="True" popupcontrolid="programmaticPopup" popupdraghandlecontrolid="programmaticPopupDragHandle" repositionmode="RepositionOnWindowScroll" targetcontrolid="hiddenTargetControlForModalPopup">
        </ajaxtoolkit:modalpopupextender> <asp:Panel style="PADDING-RIGHT: 10px; DISPLAY: none; PADDING-LEFT: 10px; PADDING-BOTTOM: 10px; WIDTH: 350px; PADDING-TOP: 10px" id="programmaticPopup" runat="server" CssClass="modalPopup">
        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD;
            border: solid 1px Gray; color: Black; text-align: center;">
            Status
        </asp:Panel>
        <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label><br />
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
            Text="OK" Width="58px" />
        <br />
    </asp:Panel> <BR /><DIV style="HEIGHT: 550px" id="div1"><asp:Label id="Label1" runat="server" Text="माग फारामको आदेश" SkinID="UnicodeHeadlbl"></asp:Label><BR /><BR /><uc1:MaagFaaramSearch id="appMaagHeadControl" runat="server" Approve="true" DisplayAppYesNo="true" DisplayIssueFlag="false" Edit="false" SelectIssue="true" DisplayAppDate="true" DisplayAppPerson="true">
    </uc1:MaagFaaramSearch> <asp:Panel id="pnlMaagDetail" runat="server" Width="1000px" Height="250px"><TABLE style="WIDTH: 1024px"><TBODY><TR><TD style="WIDTH: 100px" vAlign=top><asp:Panel id="Panel1" runat="server" Width="1000px" Height="150px" ScrollBars="Auto"><asp:GridView id="grdApproveMaagDetails" runat="server" Width="800px" SkinID="Unicodegrd" OnRowDataBound="grdApproveMaagDetails_RowDataBound" AutoGenerateColumns="False"><Columns>
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
<asp:TemplateField HeaderText="आदेश परिमाण">
<ItemStyle Width="100px"></ItemStyle>
<ItemTemplate>
<asp:TextBox id="txtAppQty" runat="server" Width="59px" Text='<%# Eval("APPQTY"==null?"":"APPQTY") %>' AutoPostBack="True" __designer:wfdid="w2" OnTextChanged="txtAppQty_TextChanged"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="ITEMSUNITNAME" HeaderText="ईकाई">
<ItemStyle Width="70px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="JIKHAPANO" HeaderText="जि.खा.पा.नं.">
<ItemStyle Width="70px"></ItemStyle>
</asp:BoundField>
</Columns>
</asp:GridView> </asp:Panel> </TD></TR><TR><TD style="WIDTH: 100px" vAlign=top>&nbsp;<TABLE style="WIDTH: 958px"><TBODY><TR><TD style="WIDTH: 350px" vAlign=top><asp:RadioButtonList id="rdblstAppYesNo" runat="server" Width="300px" SkinID="Unicoderadio" AutoPostBack="False" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="Y">माग स्विकृत</asp:ListItem>
                    <asp:ListItem Value="N">माग अस्विकृत</asp:ListItem>
                </asp:RadioButtonList></TD><TD style="WIDTH: 45px" vAlign=top><asp:Label id="Label2" runat="server" Width="35px" Text="मिति" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 160px" vAlign=top><asp:TextBox id="txtAppDate_DT" runat="server" Width="90px" ToolTip="मिति"></asp:TextBox> <ajaxtoolkit:MaskedEditExtender id="MaskedEditExtender1" runat="server" AutoComplete="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtAppDate_DT"></ajaxtoolkit:MaskedEditExtender> </TD><TD vAlign=top><asp:Button id="btnSubmit" onclick="btnSubmit_Click" runat="server" Text="Submit" SkinID="Normal" OnClientClick="javascript:return validate(1);"></asp:Button></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></asp:Panel> </DIV>
</contenttemplate>
    </asp:UpdatePanel>
</asp:Content>

