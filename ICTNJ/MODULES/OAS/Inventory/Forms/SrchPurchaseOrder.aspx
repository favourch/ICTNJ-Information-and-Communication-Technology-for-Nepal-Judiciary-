<%@ Page Language="C#"  MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true" CodeFile="SrchPurchaseOrder.aspx.cs" Inherits="MODULES_OAS_Inventory_Forms_PurchaseOrder" Title=":.Search Purchase Order" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../../UserControls/InvPurchaseOrderDetail.ascx" TagName="PurposeOrderDetail" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <script language="javascript" src="../../../COMMON/JS/Validation.js" type="text/javascript"></script>

    <script language="javascript" src="../../../COMMON/JS/DateValidator.js" type="text/javascript"></script>
    <script language="javascript" src="../../../COMMON/JS/UPanelValidation.js" type="text/javascript"></script>
      
   <div style="width:100%; height:auto">
    <asp:UpdatePanel id="updPurchaseOrder" runat="server">
     <contenttemplate>
<!-- For Popup error status --><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup" runat="server"></asp:Button> <ajaxToolkit:ModalPopupExtender id="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior" DropShadow="True" PopupControlID="programmaticPopup" PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForModalPopup">
        </ajaxToolkit:ModalPopupExtender> <asp:Panel style="PADDING-RIGHT: 10px; DISPLAY: none; PADDING-LEFT: 10px; PADDING-BOTTOM: 10px; WIDTH: 350px; PADDING-TOP: 10px" id="programmaticPopup" runat="server" CssClass="modalPopup">&nbsp;&nbsp; <asp:UpdatePanel id="UpdatePanel1" runat="server"><ContentTemplate>
<asp:Panel style="BORDER-RIGHT: gray 1px solid; BORDER-TOP: gray 1px solid; BORDER-LEFT: gray 1px solid; CURSOR: move; COLOR: black; BORDER-BOTTOM: gray 1px solid; BACKGROUND-COLOR: #dddddd; TEXT-ALIGN: center" id="programmaticPopupDragHandle" runat="Server"><asp:Label id="lblStatusMessageTitle" runat="server" CssClass="simplelabel"></asp:Label></asp:Panel> <asp:Label id="lblStatusMessage" runat="server" CssClass="simplelabel" ForeColor="Black" EnableTheming="False"></asp:Label> 
</ContentTemplate>
</asp:UpdatePanel> <asp:Button id="OkButton" onclick="hideModalPopupViaServer_Click" runat="server" Width="58px" Text="OK"></asp:Button> <BR /></asp:Panel> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender1" runat="server" TargetControlID="txtODate_DT" AutoComplete="False" Mask="9999/99/99" MaskType="Date" __designer:wfdid="w90"></ajaxToolkit:MaskedEditExtender>&nbsp;<!-- NB:: For Purchase Order --> <BR /><TABLE style="PADDING-LEFT: 20px; WIDTH: 640px" cellSpacing=2 cellPadding=0 border=0><TBODY><TR><TD style="HEIGHT: 19px" colSpan=2 rowSpan=1><asp:Label id="lblHeader" runat="server" Text="खरिद अर्डर खोज्" SkinID="UnicodeHeadlbl" ToolTip="खरिद अर्डर खोज्"></asp:Label></TD><TD style="WIDTH: 132px; HEIGHT: 19px"></TD></TR><TR><TD>&nbsp;<asp:DropDownList id="ddlUnit_rqd" runat="server" Width="167px" ToolTip="शाखा" Visible="False" AutoPostBack="True"></asp:DropDownList></TD></TR><TR><TD style="HEIGHT: 24px"><asp:Label id="lblOrder" runat="server" Width="83px" Text="अर्डर नं." SkinID="Unicodelbl" ToolTip="अर्डर नं."></asp:Label> </TD><TD style="WIDTH: 198px; HEIGHT: 24px"><asp:TextBox id="txtOrderNo_rqd" runat="server" ToolTip="अर्डर नं."></asp:TextBox> </TD><TD style="WIDTH: 132px; HEIGHT: 24px"><asp:Label id="lblOrderDate" runat="server" Width="88px" Text="अर्डर मिति" SkinID="Unicodelbl" ToolTip="अर्डर मिति"></asp:Label> </TD><TD style="WIDTH: 108px; HEIGHT: 24px"><asp:TextBox id="txtODate_DT" runat="server" Width="80px" ToolTip="अर्डर मिति"></asp:TextBox></TD></TR><TR><TD style="HEIGHT: 25px"><asp:Label id="lblSupplier" runat="server" Text="सप्लायर" SkinID="Unicodelbl" ToolTip="सप्लायर"></asp:Label> </TD><TD style="WIDTH: 198px; HEIGHT: 25px"><asp:DropDownList id="ddlSupplier_rqd" runat="server" Width="167px" ToolTip="सप्लायर"></asp:DropDownList> </TD><TD style="WIDTH: 132px; HEIGHT: 25px"></TD><TD style="WIDTH: 108px; HEIGHT: 25px"></TD></TR><TR><TD style="HEIGHT: 25px"></TD><TD style="WIDTH: 198px; HEIGHT: 25px"></TD><TD style="PADDING-LEFT: 115px" colSpan=2><asp:Button id="btnSearch" onclick="btnSearch_Click" runat="server" Text="Search" SkinID="Normal" ToolTip="Search" OnClientClick="return validateDate();"></asp:Button> <asp:Button id="btnCancel" onclick="btnCancel_Click" runat="server" Text="Cancel" SkinID="Cancel"></asp:Button></TD></TR><TR><TD style="HEIGHT: 25px" colSpan=4>
<HR />
&nbsp;</TD></TR></TBODY></TABLE><DIV style="PADDING-LEFT: 20px; OVERFLOW: auto; WIDTH: 95%" id="dvPurchaseOrder"><asp:Label id="lblCount" runat="server" SkinID="Unicodelbl"></asp:Label><BR /><BR /><asp:GridView id="grdSrchPurchaseOrder" runat="server" OnRowCreated="grdSrchPurchaseOrder_RowCreated" AutoGenerateColumns="False" GridLines="None" ForeColor="#333333" CellPadding="4" OnRowDataBound="grdSrchPurchaseOrder_RowDataBound" OnSelectedIndexChanged="grdSrchPurchaseOrder_SelectedIndexChanged">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:TemplateField HeaderText="सिनं.">
<ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
<ItemTemplate>
                         <%# Container.DataItemIndex + 1 %>.
                    
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="OrgID" HeaderText="OrgID"></asp:BoundField>
<asp:BoundField DataField="UnitID" HeaderText="UnitId"></asp:BoundField>
<asp:BoundField DataField="SectionID" HeaderText="SectionID"></asp:BoundField>
<asp:BoundField DataField="SupplierID" HeaderText="SupplierID"></asp:BoundField>
<asp:BoundField DataField="UnitName" HeaderText="शाखा"></asp:BoundField>
<asp:BoundField DataField="SectionName" HeaderText="Section Name"></asp:BoundField>
<asp:BoundField DataField="SupplierName" HeaderText="सप्लायरको नाम"></asp:BoundField>
<asp:BoundField DataField="OrderNo" HeaderText="अर्डर नं."></asp:BoundField>
<asp:BoundField DataField="OrderDate" HeaderText="अर्डर मिति"></asp:BoundField>
<asp:CommandField ShowSelectButton="True"></asp:CommandField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView><BR /><BR /></DIV>
</contenttemplate>
       <triggers>
<asp:AsyncPostBackTrigger ControlID="ddlUnit_rqd" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="OkButton" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
       </asp:UpdatePanel>
 <uc1:PurposeOrderDetail ID="PurposeOrderDetail" runat="server"   />
      <BR /><BR /><BR /><br /><BR />
 </div>
 
</asp:Content>

