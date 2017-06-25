<%@ Page Language="C#"  MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true" CodeFile="RecomendPurchaseOrder.aspx.cs" Inherits="MODULES_OAS_Inventory_Forms_PurchaseOrder" Title=":.Recomend Purchase Order" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../../UserControls/InvPurchaseOrderDetail.ascx" TagName="PurposeOrderDetail" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <script language="javascript" src="../../../COMMON/JS/Validation.js" type="text/javascript"></script>

    <script language="javascript" src="../../../COMMON/JS/DateValidator.js" type="text/javascript"></script>
    <script language="javascript" src="../../../COMMON/JS/UPanelValidation.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function validateSrchDate(val)
        {
          
            var objDate = document.getElementById('<%=this.txtODate_DT.ClientID%>');  
                 
            if(objDate.value != "")
            {  
                if(chkDate(objDate))
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return true;
        }
        
        function chkDate(objDate)
        {
           var DateElement = objDate.value.split("/");
           var Day;
           var Month;
           var Year;
           var ErrorMsg="";
           var ErrorControl=new Array();
           
            
           if(DateElement.length==3)
           {
                Day=DateElement[2];
                Month=DateElement[1];
                Year=DateElement[0];
                if((Year.length!=4) || (Month.length!=2) || (Day.length!=2)  || (Month<1 || Month>12) || (Day<1 || Day>32) || (isNaN(Year)==true) || (isNaN(Month)==true) || (isNaN(Day)==true))
                {
                    ErrorMsg=ErrorMsg + objDate.title+":  -  गलत मिति. मितिको प्रकार YYYY/MM/DD मा राख्नुहोस।\n";
                    ErrorControl.push(objDate);
                    
                }
            }
            else
            {
                ErrorMsg=ErrorMsg + objDate.title+":  -  मितिको प्रकार YYYY/MM/DD मा राख्नुहोस।\n";
                ErrorControl.push(objDate);
            }
            
            if(ErrorMsg!="")
            {
                alert("निम्न मितिको त्रुटिहरू सच्याउनुहोस::\n\n"+ErrorMsg);
                ErrorControl[0].focus();
                ErrorControl[0].select();
                return false;
            }
            else
            {
                return true;
            }
        }
    
    </script>
      
   <div style="width:100%; height:auto">
    <asp:UpdatePanel id="updPurchaseOrder" runat="server">
     <contenttemplate>
<!-- For Popup error status --><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup" runat="server" __designer:wfdid="w1"></asp:Button> <ajaxToolkit:ModalPopupExtender id="programmaticModalPopup" runat="server" __designer:wfdid="w2" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior" DropShadow="True" PopupControlID="programmaticPopup" PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForModalPopup">
        </ajaxToolkit:ModalPopupExtender> <asp:Panel style="PADDING-RIGHT: 10px; DISPLAY: none; PADDING-LEFT: 10px; PADDING-BOTTOM: 10px; WIDTH: 350px; PADDING-TOP: 10px" id="programmaticPopup" runat="server" CssClass="modalPopup" __designer:wfdid="w3">&nbsp;&nbsp; <asp:UpdatePanel id="UpdatePanel1" runat="server" __designer:wfdid="w4"><ContentTemplate>
<asp:Panel style="BORDER-RIGHT: gray 1px solid; BORDER-TOP: gray 1px solid; BORDER-LEFT: gray 1px solid; CURSOR: move; COLOR: black; BORDER-BOTTOM: gray 1px solid; BACKGROUND-COLOR: #dddddd; TEXT-ALIGN: center" id="programmaticPopupDragHandle" runat="Server" __designer:wfdid="w5"><asp:Label id="lblStatusMessageTitle" runat="server" CssClass="simplelabel" __designer:wfdid="w6"></asp:Label></asp:Panel> <asp:Label id="lblStatusMessage" runat="server" CssClass="simplelabel" __designer:wfdid="w7" ForeColor="Black" EnableTheming="False"></asp:Label> 
</ContentTemplate>
</asp:UpdatePanel> <asp:Button id="OkButton" onclick="hideModalPopupViaServer_Click" runat="server" Width="58px" Text="OK" __designer:wfdid="w8"></asp:Button> <BR /></asp:Panel> <!-- NB:: For Purchase Order --><ajaxToolkit:MaskedEditExtender id="MaskedEditExtender1" runat="server" __designer:wfdid="w9" TargetControlID="txtODate_DT" MaskType="Date" Mask="9999/99/99" AutoComplete="False"></ajaxToolkit:MaskedEditExtender>&nbsp; <BR /><TABLE style="PADDING-LEFT: 20px; WIDTH: 676px" cellSpacing=2 cellPadding=0 border=0><TBODY><TR><TD style="HEIGHT: 19px" colSpan=2 rowSpan=1><asp:Label id="lblMainHeader" runat="server" Text="खरिद अर्डर सिफारिस" SkinID="UnicodeHeadlbl" __designer:wfdid="w10" ToolTip="खरिद अर्डर सिफारिस" Font-Underline="True"></asp:Label></TD><TD style="HEIGHT: 19px"></TD></TR><TR><TD style="HEIGHT: 19px" colSpan=2 rowSpan=1><asp:DropDownList id="ddlUnit_rqd" runat="server" Width="167px" __designer:wfdid="w13" ToolTip="शाखा" Visible="False" AutoPostBack="True"></asp:DropDownList></TD><TD style="HEIGHT: 19px"></TD></TR><TR><TD>&nbsp;</TD></TR><TR><TD style="HEIGHT: 24px"><asp:Label id="lblOrder" runat="server" Width="83px" Text="अर्डर नं." SkinID="Unicodelbl" __designer:wfdid="w14" ToolTip="अर्डर नं."></asp:Label> </TD><TD style="HEIGHT: 24px"><asp:TextBox id="txtOrderNo" runat="server" __designer:wfdid="w15" ToolTip="अर्डर नं."></asp:TextBox> </TD><TD style="HEIGHT: 24px"><asp:Label id="lblOrderDate" runat="server" Width="88px" Text="अर्डर मिति" SkinID="Unicodelbl" __designer:wfdid="w16" ToolTip="अर्डर मिति"></asp:Label> </TD><TD style="HEIGHT: 24px"><asp:TextBox id="txtODate_DT" runat="server" Width="80px" __designer:wfdid="w17" ToolTip="अर्डर मिति"></asp:TextBox></TD></TR><TR><TD style="HEIGHT: 25px"><asp:Label id="lblSupplier" runat="server" Text="सप्लायर" SkinID="Unicodelbl" __designer:wfdid="w18" ToolTip="सप्लायर"></asp:Label> </TD><TD style="HEIGHT: 25px"><asp:DropDownList id="ddlSupplier" runat="server" Width="167px" __designer:wfdid="w19" ToolTip="सप्लायर"></asp:DropDownList> </TD><TD style="HEIGHT: 25px"></TD><TD style="HEIGHT: 25px"></TD></TR><TR><TD style="HEIGHT: 24px"></TD><TD style="HEIGHT: 24px"></TD><TD style="PADDING-LEFT: 105px; HEIGHT: 24px" colSpan=2 rowSpan=2><asp:Button id="btnSearch" onclick="btnSearch_Click" runat="server" Text="Search" SkinID="Normal" __designer:wfdid="w20" ToolTip="Search" OnClientClick="return validateSrchDate('txtODate_DT');"></asp:Button> <asp:Button id="btnCancel" onclick="btnCancel_Click" runat="server" Text="Cancel" SkinID="Cancel" __designer:wfdid="w21"></asp:Button></TD></TR></TBODY></TABLE>
<HR style="PADDING-LEFT: 20px; WIDTH: 1000px" />
<DIV style="PADDING-LEFT: 20px; OVERFLOW: auto; WIDTH: 95%" id="dvPurchaseOrder"><asp:Label id="lblCount" runat="server" SkinID="Unicodelbl" __designer:wfdid="w22"></asp:Label><BR /><BR /><asp:GridView id="grdSrchPurchaseOrder" runat="server" __designer:wfdid="w23" OnRowCreated="grdSrchPurchaseOrder_RowCreated" AutoGenerateColumns="False" GridLines="None" ForeColor="#333333" CellPadding="4" OnRowDataBound="grdSrchPurchaseOrder_RowDataBound" OnSelectedIndexChanged="grdSrchPurchaseOrder_SelectedIndexChanged">
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
<asp:BoundField DataField="UnitName" HeaderText="युनिट"></asp:BoundField>
<asp:BoundField DataField="SectionName" HeaderText="Section Name"></asp:BoundField>
<asp:BoundField DataField="SupplierName" HeaderText="सप्लायर"></asp:BoundField>
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
</asp:GridView> <BR /><BR /></DIV>
</contenttemplate>
       <triggers>
<asp:AsyncPostBackTrigger ControlID="OkButton" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
       </asp:UpdatePanel>
 <uc1:PurposeOrderDetail ID="PurposeOrderDetail" runat="server" OnLoad="PurposeOrderDetail_Load"   />
    <BR /><BR /><BR /><BR />
 </div>
 
</asp:Content>

