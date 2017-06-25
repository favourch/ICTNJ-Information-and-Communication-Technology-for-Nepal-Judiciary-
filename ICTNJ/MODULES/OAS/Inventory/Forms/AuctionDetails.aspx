<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true" CodeFile="AuctionDetails.aspx.cs" Inherits="MODULES_OAS_Inventory_Forms_AuctionDetails" Title="OAS | Auction(Lilaam)" %>

<%@ Register 
    Assembly="AjaxControlToolkit" 
    Namespace="AjaxControlToolkit" 
    TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />    
    
    <ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground"
        BehaviorID="programmaticModalPopupBehavior" DropShadow="True" PopupControlID="programmaticPopup"
        PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
        TargetControlID="hiddenTargetControlForModalPopup">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none;
        width: 350px; padding: 10px">
        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD;
            border: solid 1px Gray; color: Black; text-align: center;">
            <asp:Label ID="lblStatus" runat="server" SkinID="Unicodelbl" Text="Status"></asp:Label></asp:Panel>
        <asp:UpdatePanel id="UpdatePanel2" runat="server">
            <contenttemplate>
        <asp:Label ID="lblStatusMessage" runat="server" SkinID="Unicodelbl" Text="Label"></asp:Label>
</contenttemplate>
        </asp:UpdatePanel>
        <br />
        <asp:Button ID="OkButton" runat="server" 
            Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    &nbsp;&nbsp;&nbsp;&nbsp;<br />
    &nbsp; 
    <asp:Label ID="lblHeading" runat="server" SkinID="UnicodeHeadlbl" Text="निलामी (खर्च नहुने सामान)" Height="23px"></asp:Label><br />
    <br />
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<TABLE width=900><TBODY><TR><TD style="WIDTH: 160px"></TD><TD style="WIDTH: 100px" vAlign=top><asp:Label id="lblAuctionDate" runat="server" Width="99px" Text="निलामी मिति" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top colSpan=5><asp:TextBox id="txtAuctionDate" runat="server" Width="73px" SkinID="Unicodetxt"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender1" runat="server" TargetControlID="txtAuctionDate" MaskType="Date" Mask="9999/99/99" AutoComplete="False">
                </ajaxToolkit:MaskedEditExtender> </TD></TR><TR><TD style="WIDTH: 160px"></TD><TD colSpan=6>
<HR />
</TD></TR><TR><TD style="WIDTH: 160px"></TD><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Label2" runat="server" Text="समुह" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 100px" vAlign=top><asp:DropDownList id="ddlItemCategory" runat="server" Width="154px" SkinID="Unicodeddl" OnSelectedIndexChanged="ddlItemCategory_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList></TD><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Label3" runat="server" Text="उप-समुह" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 100px" vAlign=top><asp:DropDownList id="ddlItemSubCategory" runat="server" Width="153px" SkinID="Unicodeddl" OnSelectedIndexChanged="ddlItemSubCategory_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList></TD><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Label4" runat="server" Text="सामान" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:DropDownList id="ddlItem" runat="server" Width="200px" SkinID="Unicodeddl">
                </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 160px"></TD><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Label5" runat="server" Text="निलामी मुल्य" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 100px" vAlign=top><asp:TextBox id="txtAuctionPrice" runat="server" Width="103px" SkinID="Unicodetxt"></asp:TextBox> <asp:Label id="Label1" runat="server" Text="रु." SkinID="Unicodelbl"></asp:Label> <asp:Label id="Label7" runat="server" Text="/-" SkinID="Unicodelbl"></asp:Label> <ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender1" runat="server" TargetControlID="txtAuctionPrice" FilterType="Numbers">
                </ajaxToolkit:FilteredTextBoxExtender> </TD><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Label6" runat="server" Width="175px" Text="निलामी जित्ने व्यक्ति/संस्था" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 100px" vAlign=top><asp:TextBox id="txtAuctionWinner" runat="server" SkinID="Unicodetxt"></asp:TextBox></TD><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Label8" runat="server" Text="विवरण" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:TextBox id="txtDescription" runat="server" Width="197px" Height="82px" SkinID="Unicodetxt" TextMode="MultiLine" MaxLength="300"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 160px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD vAlign=top><asp:Button id="btnAdd" onclick="btnAdd_Click" runat="server" Width="37px" Text="Add" SkinID="Add"></asp:Button></TD></TR><TR><TD style="WIDTH: 160px; HEIGHT: 19px"></TD><TD style="HEIGHT: 19px" colSpan=6>
<HR />
<asp:Panel id="pblData" runat="server" Width="900px" Height="200px" ScrollBars="Auto"><asp:GridView id="grdAuctionList" runat="server" Width="559px" OnSelectedIndexChanged="grdAuctionList_SelectedIndexChanged" GridLines="None" ForeColor="#333333" CellPadding="0" AutoGenerateColumns="False" OnRowCreated="grdAuctionList_RowCreated">
<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
<asp:BoundField DataField="AuctionSequence" HeaderText="AuctionSeqNo"></asp:BoundField>
<asp:BoundField DataField="OrgID" HeaderText="OrgID"></asp:BoundField>
<asp:BoundField DataField="ItemsCategoryID" HeaderText="ItemsCatagoryID"></asp:BoundField>
<asp:BoundField DataField="ItemsCategoryName" HeaderText="सामान को समुह">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ItemsSubCategoryID" HeaderText="ItemsSubCategoryID"></asp:BoundField>
<asp:BoundField DataField="ItemsSubCategoryName" HeaderText="सामानको उप-समुह">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ItemsID" HeaderText="ItemsID"></asp:BoundField>
<asp:BoundField DataField="ItemsName" HeaderText="सामान">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="SeqNo" HeaderText="SeqNo"></asp:BoundField>
<asp:BoundField DataField="AuctionDate" HeaderText="निलामी मिति"></asp:BoundField>
<asp:BoundField DataField="AuctionAmount" HeaderText="निलामी मुल्य (रू)"></asp:BoundField>
<asp:BoundField DataField="AuctionWinner" HeaderText="निलामि जितने व्यक्ति/कार्यालय"></asp:BoundField>
<asp:BoundField DataField="Remarks" HeaderText="विवरण"></asp:BoundField>
<asp:BoundField DataField="Action" HeaderText="Action"></asp:BoundField>
<asp:CommandField ShowSelectButton="True"></asp:CommandField>
</Columns>

<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> </asp:Panel> </TD></TR><TR><TD style="WIDTH: 160px"></TD><TD style="WIDTH: 100px"><asp:Button id="btnSubmit" onclick="btnSubmit_Click" runat="server" Text="Submit" SkinID="Normal"></asp:Button></TD><TD style="WIDTH: 100px"><asp:Button id="btnCancel" onclick="btnCancel_Click" runat="server" Text="Cancel" SkinID="Cancel"></asp:Button></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD></TD></TR></TBODY></TABLE>
</contenttemplate>
    </asp:UpdatePanel>
    <br />
    <br />
    &nbsp;
</asp:Content>

    