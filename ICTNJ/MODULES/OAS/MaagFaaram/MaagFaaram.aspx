<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true" CodeFile="MaagFaaram.aspx.cs" Inherits="MODULES_OAS_MaagFaaram_MaagFaaram" Title="OAS | Maag Faaram" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>

<script runat="server">

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script language="javascript" src="../../COMMON/JS/Validation.js" type="text/javascript"></script>

    <script language="javascript" src="../../COMMON/JS/DateValidator.js" type="text/javascript"></script>

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
<asp:Label id="Label4" runat="server" Width="224px" Text="माग फाराम" SkinID="UnicodeHeadlbl" __designer:wfdid="w5"></asp:Label><BR /><BR /><TABLE style="WIDTH: 800px"><TBODY><TR><TD style="WIDTH: 60px" vAlign=top></TD><TD style="WIDTH: 250px" vAlign=top><asp:TextBox id="txtReqNo" runat="server" __designer:wfdid="w3" Visible="False"></asp:TextBox></TD><TD style="WIDTH: 70px" vAlign=top></TD><TD style="WIDTH: 404px" vAlign=top></TD></TR><TR><TD style="WIDTH: 60px" vAlign=top><asp:Label id="Label1" runat="server" Width="55px" Text="शाखा" SkinID="Unicodelbl" __designer:wfdid="w6"></asp:Label></TD><TD style="WIDTH: 250px" vAlign=top><asp:DropDownList id="ddlOrgUnits_Rqd" runat="server" Width="170px" __designer:wfdid="w7" AppendDataBoundItems="True" ToolTip="शाखा"></asp:DropDownList></TD><TD style="WIDTH: 70px" vAlign=top><asp:Label id="Label6" runat="server" Width="55px" Text="प्रयोजन" SkinID="Unicodelbl" __designer:wfdid="w10"></asp:Label></TD><TD style="WIDTH: 404px" vAlign=top><asp:TextBox id="txtPurpose" runat="server" Width="350px" __designer:wfdid="w11"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 60px" vAlign=top><asp:Label id="Label5" runat="server" Text="मिति" SkinID="Unicodelbl" __designer:wfdid="w8"></asp:Label></TD><TD style="WIDTH: 250px" vAlign=top><asp:TextBox id="txtMaagDate_RDT" runat="server" Width="88px" __designer:wfdid="w9" ToolTip="मिति"></asp:TextBox> <ajaxToolKit:MaskedEditExtender id="MaskedEditExtender1" runat="server" __designer:wfdid="w6" AutoComplete="False" Mask="9999/99/99" MaskType="Date" ClearMaskOnLostFocus="False" TargetControlID="txtMaagDate_RDT"></ajaxToolKit:MaskedEditExtender></TD><TD style="WIDTH: 70px" vAlign=top></TD><TD style="WIDTH: 404px" vAlign=top><asp:RadioButtonList id="rdblstIssueType" runat="server" Width="355px" SkinID="Unicoderadio" __designer:wfdid="w16" AutoPostBack="False" RepeatDirection="Horizontal"><asp:ListItem Selected="True" Value="P">बजारबाट खरिद गरी दिनु</asp:ListItem>
<asp:ListItem Value="S">मौज्दातबाट दिनु</asp:ListItem>
</asp:RadioButtonList></TD></TR><TR><TD vAlign=top colSpan=4>
<HR />
</TD></TR><TR><TD style="WIDTH: 60px" vAlign=top><asp:Label id="Label2" runat="server" Width="40px" Text="समूह" SkinID="Unicodelbl" __designer:wfdid="w12"></asp:Label></TD><TD style="WIDTH: 250px" vAlign=top><asp:DropDownList id="ddlItemsCategory_Rqd" runat="server" Width="170px" __designer:wfdid="w13" ToolTip="समूह" AutoPostBack="True" OnSelectedIndexChanged="ddlItemsCategory_Rqd_SelectedIndexChanged"></asp:DropDownList></TD><TD style="WIDTH: 70px" vAlign=top><asp:Label id="Label3" runat="server" Width="65px" Text="उप-समूह" SkinID="Unicodelbl" __designer:wfdid="w14"></asp:Label></TD><TD style="WIDTH: 404px" vAlign=top><asp:DropDownList id="ddlItemsSubCategory_Rqd" runat="server" Width="170px" __designer:wfdid="w15" AppendDataBoundItems="True" ToolTip="उप-समूह" AutoPostBack="True" OnSelectedIndexChanged="ddlItemsSubCategory_Rqd_SelectedIndexChanged"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 60px" vAlign=top><asp:Label id="lblItems" runat="server" Width="46px" Text="सामान" SkinID="Unicodelbl" __designer:wfdid="w31"></asp:Label></TD><TD style="WIDTH: 250px" vAlign=top><asp:DropDownList id="ddlItems_Rqd" runat="server" Width="170px" __designer:wfdid="w32" AppendDataBoundItems="True" ToolTip="सामान"></asp:DropDownList></TD><TD style="WIDTH: 70px" vAlign=top><asp:Label id="Label7" runat="server" Width="55px" Text="परिमाण" SkinID="Unicodelbl" __designer:wfdid="w33"></asp:Label></TD><TD style="WIDTH: 404px" vAlign=top><asp:TextBox id="txtReqQty_Rqd" runat="server" Width="65px" __designer:wfdid="w34" ToolTip="परिमाण" MaxLength="4"></asp:TextBox> <ajaxToolKit:FilteredTextBoxExtender id="FilteredTextBoxExtender2" runat="server" __designer:wfdid="w2" TargetControlID="txtReqQty_Rqd" FilterType="Numbers"></ajaxToolKit:FilteredTextBoxExtender></TD></TR><TR><TD style="WIDTH: 60px" vAlign=top><asp:Label id="Label8" runat="server" Width="55px" Text="कैफियत" SkinID="Unicodelbl" __designer:wfdid="w3"></asp:Label></TD><TD style="WIDTH: 250px" vAlign=top><asp:TextBox id="txtRemarks" runat="server" Width="240px" Height="69px" __designer:wfdid="w4" TextMode="MultiLine"></asp:TextBox></TD><TD style="WIDTH: 70px" vAlign=top></TD><TD style="WIDTH: 404px" vAlign=top><asp:Button id="btnAdd" onclick="btnAdd_Click" runat="server" Text="Add" SkinID="Normal" __designer:wfdid="w5" OnClientClick="javascript:return validate(1);"></asp:Button></TD></TR><TR><TD vAlign=top colSpan=4>
<HR />
<asp:Button id="btnSubmit" onclick="btnSubmit_Click" runat="server" Text="Submit" SkinID="Normal" __designer:dtid="562949953421323" __designer:wfdid="w17"></asp:Button> <asp:Button id="btnCancel" onclick="btnCancel_Click" runat="server" Text="Cancel" SkinID="Cancel" __designer:dtid="562949953421324" __designer:wfdid="w18"></asp:Button><BR />
<HR />
</TD></TR></TBODY></TABLE><TABLE style="WIDTH: 898px"><TBODY><TR><TD vAlign=top><asp:Panel id="Panel1" runat="server" Width="850px" Height="250px" __designer:dtid="562949953421320" __designer:wfdid="w19" ScrollBars="Auto"><asp:GridView id="grdItems" runat="server" Width="800px" SkinID="Unicodegrd" __designer:wfdid="w20" OnSelectedIndexChanged="grdItems_SelectedIndexChanged" AutoGenerateColumns="False" OnRowDataBound="grdItems_RowDataBound" OnRowDeleting="grdItems_RowDeleting"><Columns>
<asp:TemplateField HeaderText="सि.नं.">
<ItemStyle Width="30px"></ItemStyle>
<ItemTemplate>
<%# Container.DataItemIndex + 1 %> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="ITEMSCATEGORYID" HeaderText="ItemCategoryID"></asp:BoundField>
<asp:BoundField DataField="ITEMSCATEGORYNAME" HeaderText="समूह">
<ItemStyle Width="100px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ITEMSSUBCATEGORYID" HeaderText="ItemsSubCategoryID"></asp:BoundField>
<asp:BoundField DataField="ITEMSSUBCATEGORYNAME" HeaderText="उप-समूह">
<ItemStyle Width="100px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ITEMSID" HeaderText="ItemsID"></asp:BoundField>
<asp:BoundField DataField="ITEMSNAME" HeaderText="सामानको नाम">
<ItemStyle Width="150px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="SPECIFICATIONS" HeaderText="स्पेसिफिकेशन">
<ItemStyle Width="200px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="REQQTY" HeaderText="सामानको परिमाण"></asp:BoundField>
<asp:BoundField DataField="ITEMSUNITNAME" HeaderText="इकाई">
<ItemStyle Width="50px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="JIKHAPANO" HeaderText="जि.खा.पा.नं.">
<ItemStyle Width="70px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="REMARKS" HeaderText="कैफियत">
<ItemStyle Width="50px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ACTION" HeaderText="Action"></asp:BoundField>
<asp:CommandField ShowSelectButton="True">
<ItemStyle Width="50px"></ItemStyle>
</asp:CommandField>
<asp:CommandField ShowDeleteButton="True">
<ItemStyle Width="50px"></ItemStyle>
</asp:CommandField>
</Columns>
</asp:GridView></asp:Panel></TD></TR></TBODY></TABLE>
</contenttemplate>
                </asp:UpdatePanel>
</asp:Content>

