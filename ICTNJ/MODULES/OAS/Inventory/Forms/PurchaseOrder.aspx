<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true" CodeFile="PurchaseOrder.aspx.cs" Inherits="MODULES_OAS_Inventory_Forms_PurchaseOrder" Title=":.Purchase Order" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
   
 
    
     <script language="javascript" src="../../../COMMON/JS/Validation.js" type="text/javascript"></script>

    <script language="javascript" src="../../../COMMON/JS/DateValidator.js" type="text/javascript"></script>
    <script language="javascript" src="../../../COMMON/JS/UPanelValidation.js" type="text/javascript"></script>
    <script language="javascript" src="../../../COMMON/JS/Number.js" type="text/javascript"></script>
    <script language="javascript" src="../../../COMMON/JS/jquery.min.js" type="text/javascript"></script>
 
 
   <div style="width:100%; height:auto">
    <asp:UpdatePanel id="updPurchaseOrder" runat="server">
     <contenttemplate>
<!-- NB:: For Popup error status --><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup" runat="server" __designer:wfdid="w5"></asp:Button> <ajaxToolkit:ModalPopupExtender id="programmaticModalPopup" runat="server" __designer:wfdid="w6" TargetControlID="hiddenTargetControlForModalPopup" RepositionMode="RepositionOnWindowScroll" PopupDragHandleControlID="programmaticPopupDragHandle" PopupControlID="programmaticPopup" DropShadow="True" BehaviorID="programmaticModalPopupBehavior" BackgroundCssClass="modalBackground">
    </ajaxToolkit:ModalPopupExtender> <asp:Panel style="PADDING-RIGHT: 10px; DISPLAY: none; PADDING-LEFT: 10px; PADDING-BOTTOM: 10px; WIDTH: 350px; PADDING-TOP: 10px" id="programmaticPopup" runat="server" CssClass="modalPopup" __designer:wfdid="w7">&nbsp;&nbsp; <asp:UpdatePanel id="UpdatePanel1" runat="server" __designer:wfdid="w8"><ContentTemplate>
<asp:Panel style="BORDER-RIGHT: gray 1px solid; BORDER-TOP: gray 1px solid; BORDER-LEFT: gray 1px solid; CURSOR: move; COLOR: black; BORDER-BOTTOM: gray 1px solid; BACKGROUND-COLOR: #dddddd; TEXT-ALIGN: center" id="programmaticPopupDragHandle" runat="Server" __designer:wfdid="w9"><asp:Label id="lblStatusMessageTitle" runat="server" CssClass="simplelabel" __designer:wfdid="w10"></asp:Label></asp:Panel> <asp:Label id="lblStatusMessage" runat="server" CssClass="simplelabel" ForeColor="Black" EnableTheming="False" __designer:wfdid="w11"></asp:Label> 
</ContentTemplate>
</asp:UpdatePanel> <asp:Button id="OkButton" onclick="hideModalPopupViaServer_Click" runat="server" Width="58px" Text="OK" __designer:wfdid="w12"></asp:Button> <BR /></asp:Panel> <!-- NB:: For Purchase Order --><ajaxToolkit:MaskedEditExtender id="MaskedEditExtender1" runat="server" __designer:wfdid="w13" TargetControlID="txtODate_RDT" ClearMaskOnLostFocus="False" MaskType="Date" Mask="9999/99/99" AutoComplete="False"></ajaxToolkit:MaskedEditExtender> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender2" runat="server" __designer:wfdid="w14" TargetControlID="txtManuDate" ClearMaskOnLostFocus="False" MaskType="Date" Mask="9999/99/99" AutoComplete="False"></ajaxToolkit:MaskedEditExtender>&nbsp; <ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender2" runat="server" __designer:wfdid="w15" TargetControlID="txtQty_cat" ValidChars='" "' FilterType="Custom, Numbers">
       </ajaxToolkit:FilteredTextBoxExtender><BR /><TABLE style="PADDING-LEFT: 20px; WIDTH: 676px" cellSpacing=2 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 141px"><asp:Label id="lblHeader" runat="server" Text="खरिद अर्डर " SkinID="UnicodeHeadlbl" __designer:wfdid="w16" ToolTip="खरिद अर्डर "></asp:Label></TD></TR><TR><TD style="WIDTH: 141px">&nbsp;</TD></TR><TR><TD style="WIDTH: 141px; HEIGHT: 24px"><asp:Label id="lblOrder" runat="server" Width="55px" Text="अर्डर नं." SkinID="Unicodelbl" __designer:wfdid="w17" ToolTip="अर्डर नं."></asp:Label><asp:Label id="Label2" runat="server" CssClass="simplelabel" Text="*" __designer:dtid="8162782914543720" __designer:wfdid="w18" EnableTheming="False" ForeColor="Red"></asp:Label></TD><TD style="WIDTH: 192px; HEIGHT: 24px"><asp:TextBox id="txtOrderNo_rqd" tabIndex=2 runat="server" __designer:wfdid="w19" ToolTip="अर्डर नं." MaxLength="10"></asp:TextBox> </TD><TD style="WIDTH: 94px; HEIGHT: 24px"><asp:Label id="lblOrderDate" runat="server" Width="74px" Text="अर्डर मिति" SkinID="Unicodelbl" __designer:wfdid="w20" ToolTip="अर्डर मिति"></asp:Label><asp:Label id="Label3" runat="server" CssClass="simplelabel" Text="*" __designer:dtid="8162782914543720" __designer:wfdid="w21" EnableTheming="False" ForeColor="Red"></asp:Label></TD><TD style="HEIGHT: 24px"><asp:TextBox id="txtODate_RDT" tabIndex=3 runat="server" Width="80px" __designer:wfdid="w22" ToolTip="अर्डर मिति"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 141px; HEIGHT: 25px"><asp:Label id="lblSupplier" runat="server" Width="54px" Text="सप्लायर" SkinID="Unicodelbl" __designer:wfdid="w23" ToolTip="सप्लायर"></asp:Label><asp:Label id="Label4" runat="server" CssClass="simplelabel" Text="*" __designer:dtid="8162782914543720" __designer:wfdid="w24" EnableTheming="False" ForeColor="Red"></asp:Label></TD><TD style="WIDTH: 192px; HEIGHT: 25px"><asp:DropDownList id="ddlSupplier_rqd" tabIndex=4 runat="server" Width="167px" __designer:wfdid="w25" ToolTip="सप्लायर"></asp:DropDownList> </TD><TD style="WIDTH: 94px; HEIGHT: 25px"></TD><TD style="HEIGHT: 25px"></TD></TR><TR><TD style="HEIGHT: 25px" colSpan=4>
<HR />
&nbsp;</TD></TR><TR><TD style="WIDTH: 141px; HEIGHT: 25px" vAlign=baseline align=left colSpan=4><asp:Label id="Label1" runat="server" Text="सामान विवरण" SkinID="UnicodeHeadlbl" __designer:wfdid="w16" ToolTip="सामान विवरण"></asp:Label></TD></TR><TR><TD style="HEIGHT: 22px"><asp:Label id="lblCategory" runat="server" Text="समूह" SkinID="Unicodelbl" ToolTip="समूह"></asp:Label> </TD><TD style="WIDTH: 211px; HEIGHT: 22px"><asp:DropDownList id="ddlCategory_cat" tabIndex=5 runat="server" Width="167px" ToolTip="समूह" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> </TD><TD style="HEIGHT: 22px"><asp:Label id="lblSubCategory" runat="server" Text="उप-समूह" SkinID="Unicodelbl" ToolTip="उप-समूह"></asp:Label> </TD><TD style="WIDTH: 217px; HEIGHT: 22px"><asp:DropDownList id="ddlSubCategory_cat" tabIndex=6 runat="server" Width="162px" ToolTip="उप-समूह" OnSelectedIndexChanged="ddlSubCategory_SelectedIndexChanged" AutoPostBack="True" Enabled="False"></asp:DropDownList> </TD></TR><TR><TD style="HEIGHT: 25px"><asp:Label id="lblItem" runat="server" Text="सामान" SkinID="Unicodelbl" ToolTip="सामान"></asp:Label> </TD><TD style="HEIGHT: 25px" colSpan=3><asp:DropDownList id="ddlItems_cat" tabIndex=7 runat="server" Width="479px" ToolTip="सामान" AutoPostBack="True" Enabled="False"></asp:DropDownList> </TD></TR><TR><TD style="HEIGHT: 25px"><asp:Label id="lblQuantity" runat="server" Text="परिमाण" SkinID="Unicodelbl" ToolTip="परिमाण"></asp:Label></TD><TD style="WIDTH: 211px; HEIGHT: 25px"><asp:TextBox id="txtQty_cat" tabIndex=8 runat="server" Width="60px" ToolTip="परिमाण" MaxLength="5"></asp:TextBox></TD><TD style="HEIGHT: 25px"></TD><TD style="WIDTH: 217px; HEIGHT: 25px"></TD></TR><TR><TD style="HEIGHT: 25px"><asp:Label id="lblManuComp" runat="server" Width="115px" Text="निर्माण कम्पनी" SkinID="Unicodelbl" ToolTip="निर्माण कम्पनी"></asp:Label></TD><TD style="WIDTH: 211px; HEIGHT: 25px"><asp:TextBox id="txtManuCom" tabIndex=9 runat="server" ToolTip="निर्माण कम्पनी"></asp:TextBox></TD><TD style="HEIGHT: 25px"><asp:Label id="lblManuDate" runat="server" Text="निर्माण मिति" SkinID="Unicodelbl" ToolTip="निर्माण मिति"></asp:Label></TD><TD style="WIDTH: 217px; HEIGHT: 25px"><asp:TextBox id="txtManuDate" tabIndex=10 runat="server" Width="80px" ToolTip="निर्माण मिति"></asp:TextBox></TD></TR><TR><TD style="HEIGHT: 25px"><asp:Label id="lblBrand" runat="server" Text="ब्राण्ड" SkinID="Unicodelbl" ToolTip="ब्राण्ड"></asp:Label></TD><TD style="WIDTH: 211px; HEIGHT: 25px"><asp:TextBox id="txtBrand" tabIndex=11 runat="server" ToolTip="ब्राण्ड"></asp:TextBox></TD><TD style="HEIGHT: 25px"></TD><TD style="WIDTH: 217px; HEIGHT: 25px"></TD></TR><TR><TD style="HEIGHT: 28px"></TD><TD style="PADDING-LEFT: 242px; WIDTH: 211px; HEIGHT: 28px" colSpan=3><asp:Button id="btnAdd" tabIndex=13 onclick="btnAdd_Click" runat="server" Width="45px" Text="Add" SkinID="Normal" ToolTip="Add Item" OnClientClick=" javascript:return validateUpanelFields('_cat','_cat');"></asp:Button> <asp:Button id="btnSubmit" tabIndex=14 onclick="btnSubmit_Click" runat="server" Text="Submit" SkinID="Normal" ToolTip="Submit" OnClientClick="javascript: return validate(1);"></asp:Button> <asp:Button id="btnCancel" tabIndex=15 onclick="btnCancel_Click" runat="server" Text="Cancel" SkinID="Cancel"></asp:Button></TD></TR><TR><TD style="HEIGHT: 28px" colSpan=4>
<HR />
&nbsp;</TD></TR></TBODY></TABLE><DIV style="PADDING-LEFT: 20px; OVERFLOW: auto; WIDTH: 95%" id="dvPurchaseOrder"><asp:GridView id="grdPurchaseOrder" runat="server" __designer:wfdid="w43" ForeColor="#333333" OnSelectedIndexChanged="grdPurchaseOrder_SelectedIndexChanged" OnRowDeleting="grdPurchaseOrder_RowDeleting" OnRowCreated="grdPurchaseOrder_RowCreated" OnRowDataBound="grdPurchaseOrder_RowDataBound" AutoGenerateColumns="False" GridLines="None" CellPadding="4">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:TemplateField HeaderText="सिनं.">
<ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
<ItemTemplate>
                         <%# Container.DataItemIndex + 1 %>.
                    
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="ItemsCategoryID" HeaderText="CatID"></asp:BoundField>
<asp:BoundField DataField="ItemsSubCategoryID" HeaderText="SubCatID"></asp:BoundField>
<asp:BoundField DataField="ItemsID" HeaderText="ItemsID"></asp:BoundField>
<asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice"></asp:BoundField>
<asp:BoundField DataField="ItemsCategoryName" HeaderText="समूह"></asp:BoundField>
<asp:BoundField DataField="ItemsSubCategoryName" HeaderText="उप-समूह"></asp:BoundField>
<asp:BoundField DataField="ItemsName" HeaderText="सामान"></asp:BoundField>
<asp:TemplateField HeaderText="रुपैया (रु)"><ItemTemplate>
                            <asp:TextBox ID="txtUnitPrice" runat="server" Width="106px" AutoPostBack="True" OnTextChanged="txtUnitPrice_TextChanged"></asp:TextBox>
                        
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="TotalQty" HeaderText="परिमाण"></asp:BoundField>
<asp:TemplateField HeaderText="जम्मा रुपैया (रू)"><ItemTemplate>
                            <asp:Label ID="lblTotalPrice" runat="server"></asp:Label>
                        
</ItemTemplate>
</asp:TemplateField>
<asp:CommandField ShowSelectButton="True"></asp:CommandField>
<asp:CommandField ShowDeleteButton="True"></asp:CommandField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> <BR /><BR /></DIV>
</contenttemplate>
       <triggers>
<asp:AsyncPostBackTrigger ControlID="ddlCategory_cat" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="ddlSubCategory_cat" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnSubmit" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="OkButton" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
       </asp:UpdatePanel>
        <BR /><BR /> <BR /><br /><br />
 </div>
 
  <script type="text/javascript">
    $(document).ready(function() {
    $(".headerDiv").hover(function() {
    $(this).addClass("pretty-hover"),function() {
     $(this).addClass("pretty-hover");
     }
    
    });
      
    $("#dvExpCollap").click(function() {
    alert("hi");
    $(this).toggleClass("active");
    $("#dvCategory").slideToggle('slow');
    
    });
    });
 </script>
</asp:Content>

