<%@ Page Language="C#"  MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true" CodeFile="DeliveryOrder.aspx.cs" Inherits="MODULES_OAS_Inventory_Forms_PurchaseOrder" Title=":.Delivery Order" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../../UserControls/InvDeliveryOrder.ascx" TagName="DeliveryOrder" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <script language="javascript" src="../../../COMMON/JS/Validation.js" type="text/javascript"></script>

    <script language="javascript" src="../../../COMMON/JS/DateValidator.js" type="text/javascript"></script>
    <script language="javascript" src="../../../COMMON/JS/UPanelValidation.js" type="text/javascript"></script>
      
   <div style="width:100%; height:auto">
    <asp:UpdatePanel id="updPurchaseOrder" runat="server">
     <contenttemplate>
<!-- For Popup error status --><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup" runat="server"></asp:Button> <ajaxToolkit:ModalPopupExtender id="programmaticModalPopup" runat="server" TargetControlID="hiddenTargetControlForModalPopup" RepositionMode="RepositionOnWindowScroll" PopupDragHandleControlID="programmaticPopupDragHandle" PopupControlID="programmaticPopup" DropShadow="True" BehaviorID="programmaticModalPopupBehavior" BackgroundCssClass="modalBackground">
        </ajaxToolkit:ModalPopupExtender> <asp:Panel style="PADDING-RIGHT: 10px; DISPLAY: none; PADDING-LEFT: 10px; PADDING-BOTTOM: 10px; WIDTH: 350px; PADDING-TOP: 10px" id="programmaticPopup" runat="server" CssClass="modalPopup">&nbsp;&nbsp; <asp:UpdatePanel id="UpdatePanel1" runat="server"><ContentTemplate>
<asp:Panel style="BORDER-RIGHT: gray 1px solid; BORDER-TOP: gray 1px solid; BORDER-LEFT: gray 1px solid; CURSOR: move; COLOR: black; BORDER-BOTTOM: gray 1px solid; BACKGROUND-COLOR: #dddddd; TEXT-ALIGN: center" id="programmaticPopupDragHandle" runat="Server"><asp:Label id="lblStatusMessageTitle" runat="server" CssClass="simplelabel"></asp:Label></asp:Panel> <asp:Label id="lblStatusMessage" runat="server" CssClass="simplelabel" ForeColor="Black" EnableTheming="False"></asp:Label> 
</ContentTemplate>
</asp:UpdatePanel> <asp:Button id="OkButton" onclick="hideModalPopupViaServer_Click" runat="server" Width="58px" Text="OK"></asp:Button> <BR /></asp:Panel>&nbsp;&nbsp;<!-- NB:: For Purchase Order --> <BR /><TABLE style="PADDING-LEFT: 20px; WIDTH: 676px" cellSpacing=2 cellPadding=0 border=0><TBODY><TR><TD style="HEIGHT: 19px" colSpan=2 rowSpan=1><asp:Label id="lblHeader" runat="server" Text="डेलिभरी अर्डर" SkinID="UnicodeHeadlbl"></asp:Label></TD><TD style="HEIGHT: 19px"></TD></TR><TR><TD style="HEIGHT: 19px" colSpan=2 rowSpan=1><asp:DropDownList id="ddlUnit_rqd" runat="server" Width="91px" Visible="False" AutoPostBack="True" ToolTip="शाखा"></asp:DropDownList></TD><TD style="HEIGHT: 19px"></TD></TR><TR><TD style="WIDTH: 87px">&nbsp;</TD></TR><TR><TD style="WIDTH: 87px; HEIGHT: 25px">&nbsp;<asp:Label id="lblOrder" runat="server" Width="55px" Text="अर्डर नं." SkinID="Unicodelbl" ToolTip="अर्डर नं."></asp:Label> <asp:Label id="Label1" runat="server" CssClass="simplelabel" Text="*" __designer:dtid="3940658263883905" __designer:wfdid="w102" EnableTheming="False" ForeColor="Red"></asp:Label></TD><TD style="WIDTH: 184px; HEIGHT: 25px"><asp:TextBox id="txtOrderNo_rqd" runat="server" ToolTip="अर्डर नं."></asp:TextBox>&nbsp;</TD><TD style="HEIGHT: 25px">&nbsp; <asp:Button id="btnSearch" onclick="btnSearch_Click" runat="server" Text="Search" SkinID="Normal" ToolTip="Search" OnClientClick="return validate(0);"></asp:Button> <asp:Button id="btnCancel" onclick="btnCancel_Click" runat="server" Text="Cancel" SkinID="Cancel"></asp:Button></TD></TR><TR><TD style="WIDTH: 87px; HEIGHT: 24px">&nbsp;</TD><TD style="WIDTH: 184px; HEIGHT: 24px">&nbsp;</TD><TD style="HEIGHT: 24px">&nbsp;</TD></TR><TR><TD style="WIDTH: 87px"></TD><TD style="WIDTH: 184px"></TD><TD style="PADDING-LEFT: 175px" colSpan=2 rowSpan=2>&nbsp;</TD></TR></TBODY></TABLE>
<HR style="PADDING-LEFT: 20px; WIDTH: 1000px" />
<DIV style="PADDING-LEFT: 20px; OVERFLOW: auto; WIDTH: 95%" id="dvDeliveryOrder"><asp:Label id="lblCount" runat="server" SkinID="Unicodelbl"></asp:Label><BR /><BR /><asp:GridView id="grdDeliveryDetails" runat="server" ForeColor="#333333" OnRowDataBound="grdDeliveryDetails_RowDataBound" CellPadding="4" GridLines="None" AutoGenerateColumns="False">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:TemplateField HeaderText="सिनं.">
<ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
<ItemTemplate>
                         <%# Container.DataItemIndex + 1 %>.
                    
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="ItemsCategoryName" HeaderText="समूह"></asp:BoundField>
<asp:BoundField DataField="ItemsSubCategoryName" HeaderText="उप-समूह"></asp:BoundField>
<asp:BoundField DataField="ItemsName" HeaderText="सामान"></asp:BoundField>
<asp:BoundField DataField="RequiredQty" HeaderText="चाहिने परिमाण"></asp:BoundField>
<asp:BoundField DataField="DeliveredQty" HeaderText="डेलिभरी भएको परिमाण"></asp:BoundField>
<asp:TemplateField HeaderText="डेलिभरी हुने लागेको परिमाण"><ItemTemplate>
<asp:TextBox id="txtCurrentQty" runat="server" __designer:wfdid="w4" AutoPostBack="True" OnTextChanged="txtCurrentQty_TextChanged"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> <BR /><BR /><BR /></DIV>
</contenttemplate>
       <triggers>
<asp:AsyncPostBackTrigger ControlID="ddlUnit_rqd" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="OkButton" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
       </asp:UpdatePanel>
  <uc1:DeliveryOrder ID="DeliveryOrder1" runat="server" />
   <BR /><BR /> <BR /><BR /> <BR /><BR /><BR /> <BR /><BR /> <BR />
 </div>
 
</asp:Content>

