<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true"
    CodeFile="OrganisationItemsPrice.aspx.cs" Inherits="MODULES_OAS_Inventory_LookUp_OrganisationItemsPrice"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager id="scriptMNGR" runat="server">
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
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>&nbsp;</asp:Panel>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <contenttemplate>
<asp:Label id="lblStatusMessage" runat="server" Text="Label"></asp:Label> 
</contenttemplate>
            <triggers>
<asp:AsyncPostBackTrigger ControlID="OkButton" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
        </asp:UpdatePanel>
        <br />
        <asp:Button ID="OkButton" runat="server" Text="OK" Width="58px" OnClientClick="javascript:$find('programmaticModalPopupBehavior').hide();"
            OnClick="hideModalPopupViaServer_Click" /></asp:Panel>
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<TABLE width=1000><TBODY><TR><TD><asp:Label id="lblStatus" runat="server" SkinID="Unicodelbl">समुह</asp:Label></TD><TD><asp:DropDownList id="ddlCategory" runat="server" Width="230px" SkinID="Unicodeddl" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="True" DataValueField="ItemsCategoryID" DataTextField="ItemsCategoryName">
                   </asp:DropDownList></TD><TD style="WIDTH: 50px"></TD><TD><asp:Label id="Label2" runat="server" Text="उपसमुह" SkinID="Unicodelbl"></asp:Label></TD><TD><asp:DropDownList id="ddlSubCategory" runat="server" Width="230px" SkinID="Unicodeddl" DataValueField="ItemsSubCategoryID" DataTextField="ItemsSubCategoryName">
                   </asp:DropDownList></TD></TR><TR><TD></TD><TD></TD><TD></TD><TD></TD><TD><asp:Button id="btnSearch" onclick="btnSearch_Click" runat="server" Text="खोज्नुहोस्" SkinID="Normal"></asp:Button></TD></TR><TR><TD colSpan=5><asp:GridView id="grdInvOrgItemsPrice" runat="server" SkinID="Unicodegrd" OnRowDataBound="grdInvOrgItemsPrice_RowDataBound" AutoGenerateColumns="False"><Columns>
<asp:BoundField DataField="ItemsCategoryID" HeaderText="Items Category Id"></asp:BoundField>
<asp:BoundField DataField="ItemsCategoryName" HeaderText="समुह"></asp:BoundField>
<asp:BoundField DataField="ItemsSubCategoryId" HeaderText="Items SubCategory Id"></asp:BoundField>
<asp:BoundField DataField="ItemsSubCategoryName" HeaderText="उपसमुह"></asp:BoundField>
<asp:BoundField DataField="ItemsID" HeaderText="Items ID"></asp:BoundField>
<asp:BoundField DataField="ItemCD" HeaderText="कोड नं"></asp:BoundField>
<asp:BoundField DataField="ItemName" HeaderText="नाम"></asp:BoundField>
<asp:BoundField DataField="FromDate" HeaderText="From Date"></asp:BoundField>
<asp:TemplateField HeaderText="दर"><ItemTemplate>
                                   <asp:TextBox ID="txtUnitPrice"   runat="server" Text='<%# Bind("UnitPrice") %>'></asp:TextBox>
                               
</ItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView> </TD></TR><TR><TD><asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Text="Save" SkinID="Normal"></asp:Button> </TD><TD></TD><TD></TD><TD></TD><TD></TD></TR></TBODY></TABLE>
</contenttemplate>
    </asp:UpdatePanel>
    <div style="min-height: 400px; height: 400px;">
    </div>
</asp:Content>
