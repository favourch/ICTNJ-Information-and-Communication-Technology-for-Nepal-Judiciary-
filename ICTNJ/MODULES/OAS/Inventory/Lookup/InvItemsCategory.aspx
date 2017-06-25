<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true"
    CodeFile="InvItemsCategory.aspx.cs" Inherits="MODULES_OAS_Inventory_LookUp_InvItemsCategory"
    Title="OAS | Inventory Category" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    &nbsp;
    <div style="width: 100%; position: static; height: 500px">
        <asp:ScriptManager runat="server" ID="sct">
        </asp:ScriptManager>
        <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" Style="display: none" />
        <ajaxToolkit:ModalPopupExtender runat="server" ID="programmaticModalPopup" BehaviorID="programmaticModalPopupBehavior"
            TargetControlID="hiddenTargetControlForModalPopup" PopupControlID="programmaticPopup"
            BackgroundCssClass="modalBackground" DropShadow="True" PopupDragHandleControlID="programmaticPopupDragHandle"
            RepositionMode="RepositionOnWindowScroll">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel runat="server" CssClass="modalPopup" ID="programmaticPopup" Style="display: none;
            width: 350px; padding: 10px">
            <asp:Panel runat="Server" ID="programmaticPopupDragHandle" Style="cursor: move; background-color: #DDDDDD;
                border: solid 1px Gray; color: Black; text-align: center;">
                Save Status
            </asp:Panel>
            <asp:UpdatePanel id="UpdatePanel3" runat="server">
                <contenttemplate>
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
</contenttemplate>
            </asp:UpdatePanel>
            <br />
            <asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click"
                Width="58px" />
            <br />
        </asp:Panel>
        <div style="width: 100%; height: auto">
            <asp:Label ID="lblStatus" runat="server" Font-Bold="True" SkinID="Unicodelbl"></asp:Label>
            <asp:UpdatePanel id="UpdatePanel1" runat="server">
                <contenttemplate>
<TABLE width=700><TBODY><TR><TD style="WIDTH: 250px" vAlign=top><asp:ListBox id="lstItemCategory" runat="server" Width="220px" Height="445px" SkinID="Unicodelst" OnSelectedIndexChanged="lstItemCategory_SelectedIndexChanged" AutoPostBack="True">
</asp:ListBox> </TD><TD style="WIDTH: 450px" vAlign=top><TABLE width=450><TBODY><TR><TD style="HEIGHT: 31px"><asp:Label id="Label2" runat="server" Text="सामान को प्रकार को नाम" SkinID="Unicodelbl"></asp:Label> </TD><TD style="WIDTH: 300px; HEIGHT: 31px"><asp:TextBox id="txtItemCategoryName_Rqd" runat="server" Width="250px" SkinID="Unicodetxt" MaxLength="48">
</asp:TextBox> </TD></TR><TR><TD style="HEIGHT: 26px"><asp:Label id="Label4" runat="server" Text="सक्रिय" SkinID="Unicodelbl" __designer:wfdid="w1">
</asp:Label></TD><TD style="WIDTH: 300px; HEIGHT: 26px">&nbsp; <asp:CheckBox id="chkICActive" runat="server" SkinID="smallChk" __designer:wfdid="w2"></asp:CheckBox> </TD></TR><TR><TD style="HEIGHT: 22px"></TD><TD style="WIDTH: 300px; HEIGHT: 22px"></TD></TR><TR><TD style="HEIGHT: 22px" colSpan=2><asp:Label id="Label5" runat="server" Width="250px" Text="सामान को उप-प्रकार को विवरण" SkinID="UnicodeHeadlbl" Font-Bold="True" Font-Underline="True"></asp:Label></TD></TR><TR><TD style="HEIGHT: 16px"><asp:Label id="Label6" runat="server" Width="146px" Text="उप-प्रकार को नाम" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 300px; HEIGHT: 16px"><asp:TextBox id="txSubCategory_Rqd" runat="server" Width="250px" SkinID="Unicodetxt" MaxLength="48">
</asp:TextBox>&nbsp; <asp:Button id="btnAddItemSubCategory" onclick="btnAddItemSubCategory_Click" runat="server" Width="30px" Text="+" SkinID="Add" Font-Bold="True" __designer:wfdid="w1">
</asp:Button> </TD></TR><TR><TD style="HEIGHT: 16px">&nbsp;<asp:Label id="Label3" runat="server" Text="सक्रिय" SkinID="Unicodelbl" __designer:wfdid="w3"></asp:Label></TD><TD style="WIDTH: 300px; HEIGHT: 16px"><asp:CheckBox id="chkISCActive" runat="server" SkinID="smallChk" __designer:wfdid="w4"></asp:CheckBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </TD></TR><TR><TD></TD><TD style="WIDTH: 300px">&nbsp;&nbsp; </TD></TR><TR><TD style="HEIGHT: 55px" colSpan=2><asp:Panel id="Panel1" runat="server" Width="450px" Height="130px" ScrollBars="Auto"><asp:GridView id="grdItemSubCategory" runat="server" Width="420px" SkinID="Unicodegrd" OnSelectedIndexChanged="grdItemSubCategory_SelectedIndexChanged" OnRowDeleting="grdItemSubCategory_RowDeleting" AutoGenerateColumns="False" GridLines="None" ForeColor="#333333" CellPadding="4" OnRowDataBound="grdItemSubCategory_RowDataBound">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="ItemsCategoryID"  HeaderText="ItemsCategoryID"></asp:BoundField>
<asp:BoundField DataField="ItemsSubCategoryID"  HeaderText="ItemsSubCategoryID"></asp:BoundField>
<asp:BoundField DataField="ItemsSubCategoryName" HeaderText="उप-प्रकार को नाम">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="Active" HeaderText="सक्रिय">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="Action"  HeaderText="Action"></asp:BoundField>
<asp:CommandField ShowSelectButton="True">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:CommandField>
<asp:CommandField ShowDeleteButton="True">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:CommandField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> </asp:Panel> </TD></TR></TBODY></TABLE><asp:Button id="btnSubmit" onclick="btnSubmit_Click" runat="server" Width="60px" Text="Submit" SkinID="Normal"></asp:Button> <asp:Button id="btnCancel" onclick="btnCancel_Click" runat="server" Width="60px" Text="Cancel" SkinID="Cancel"></asp:Button></TD></TR></TBODY></TABLE>
</contenttemplate>
            </asp:UpdatePanel><br />
            <br />
        </div>
</asp:Content>
