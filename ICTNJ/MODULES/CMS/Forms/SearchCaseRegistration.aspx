<%@ Page Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" AutoEventWireup="true" CodeFile="SearchCaseRegistration.aspx.cs" Inherits="MODULES_CMS_Forms_SearchCaseRegistration" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../UserControls/CaseSearch.ascx" TagName="CaseSearch" TagPrefix="userControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script runat="server">

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
    </script>
    <asp:ScriptManager id="ScriptManager1" runat="server">
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
            Save Status
        </asp:Panel>
        <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label><br />
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
            Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    
    <br />
    <asp:Panel ID="pnlCol" runat="server" CssClass="collapsePanelHeader" Height="25px"
        Width="1024px">
        मुद्दा खोज्नुहोस
        <asp:ImageButton ID="imgCol" runat="server" Height="25px" ImageAlign="Right" ImageUrl="~/MODULES/COMMON/Images/expand.jpg"
            Visible="False" />
    </asp:Panel>
    <ajaxtoolkit:collapsiblepanelextender id="colCaseSearch" runat="server" collapsecontrolid="pnlCol"
        collapsed="True" collapsedimage="../../COMMON/Images/expand_blue.jpg" expandcontrolid="pnlCol"
        expandedimage="../../COMMON/Images/collapse_blue.jpg" imagecontrolid="imgCol"
        skinid="CollapsiblePanelDemo" suppresspostback="True" targetcontrolid="pnlCaseSearch">
        </ajaxtoolkit:collapsiblepanelextender>
    <asp:Panel ID="pnlCaseSearch" runat="server" CssClass="collapsePanel" Width="1024px">
        <userControl:CaseSearch ID="CaseSearchControl" runat="server" OnLoad="CaseSearchControl_Load"/>
    </asp:Panel>
    &nbsp;<br />
    &nbsp; &nbsp;<br />
    &nbsp; &nbsp;<br />
    &nbsp; &nbsp;<br />
    &nbsp;

    <br />
</asp:Content>

