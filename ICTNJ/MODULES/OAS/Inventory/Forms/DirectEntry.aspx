<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true" CodeFile="DirectEntry.aspx.cs" Inherits="MODULES_OAS_Inventory_Forms_DirectEntry" Title=":.Direct Entry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <asp:ScriptManager id="scrpMnger" runat="server">
     </asp:ScriptManager>
     
    <script language="javascript" src="../../../COMMON/JS/Validation.js" type="text/javascript"></script>
    <script language="javascript" src="../../../COMMON/JS/DateValidator.js" type="text/javascript"></script>
    
   
 <div style="width:100%; height:auto">

 <!-- For Popup error status -->
    <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground"
        BehaviorID="programmaticModalPopupBehavior" DropShadow="True" PopupControlID="programmaticPopup"
        PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
        TargetControlID="hiddenTargetControlForModalPopup">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none;
        width: 350px; padding: 10px">
        &nbsp;&nbsp;
        <asp:UpdatePanel id="UpdatePanel1" runat="server">
            <contenttemplate>
<asp:Panel style="BORDER-RIGHT: gray 1px solid; BORDER-TOP: gray 1px solid; BORDER-LEFT: gray 1px solid; CURSOR: move; COLOR: black; BORDER-BOTTOM: gray 1px solid; BACKGROUND-COLOR: #dddddd; TEXT-ALIGN: center" id="programmaticPopupDragHandle" runat="Server"><asp:Label id="lblStatusMessageTitle" runat="server" CssClass="simplelabel"></asp:Label></asp:Panel> <asp:Label id="lblStatusMessage" runat="server" CssClass="simplelabel" EnableTheming="False" ForeColor="Black"></asp:Label> 
</contenttemplate>
        </asp:UpdatePanel>
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
            Text="OK" Width="58px" />
        <br />
    </asp:Panel>
 <br />
 
    <asp:UpdatePanel id="updDirectEntry" runat="server">
            <contenttemplate>
<ajaxToolkit:MaskedEditExtender id="MaskedEditExtender1" runat="server" TargetControlID="txtDakhilaDate_RDT" AutoComplete="False" ClearMaskOnLostFocus="False" Mask="9999/99/99" MaskType="Date">
    </ajaxToolkit:MaskedEditExtender> <ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender2" runat="server" TargetControlID="txtQty_rqd" FilterType="Custom, Numbers" ValidChars='" "'>
    </ajaxToolkit:FilteredTextBoxExtender> <ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender1" runat="server" TargetControlID="txtUnitPrice_rqd" FilterType="Custom, Numbers" ValidChars='" ", .'>
    </ajaxToolkit:FilteredTextBoxExtender> <TABLE style="PADDING-LEFT: 20px; WIDTH: 720px" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 17px; HEIGHT: 21px" colSpan=2><asp:Label id="lblDakhila" runat="server" Text="दाखिला" SkinID="UnicodeHeadlbl"></asp:Label></TD><TD style="WIDTH: 101px; HEIGHT: 21px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </TD><TD style="WIDTH: 30px; HEIGHT: 21px"></TD></TR><TR><TD style="WIDTH: 15px; HEIGHT: 19px"></TD><TD style="WIDTH: 150px; HEIGHT: 19px"></TD><TD style="WIDTH: 101px; HEIGHT: 19px"></TD><TD style="WIDTH: 229px; HEIGHT: 19px"></TD></TR><TR><TD style="WIDTH: 15px"></TD><TD style="WIDTH: 150px"></TD><TD style="WIDTH: 101px"></TD><TD style="WIDTH: 229px"></TD></TR><TR><TD style="WIDTH: 15px; HEIGHT: 30px"><asp:Label id="lblCategory" runat="server" Text="समूह" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 150px; HEIGHT: 30px"><asp:DropDownList id="ddlCategory_rqd" tabIndex=1 runat="server" Width="162px" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" ToolTip="समूह">
            </asp:DropDownList></TD><TD style="WIDTH: 101px; HEIGHT: 30px"><asp:Label id="lblSubCategory" runat="server" Width="63px" Text="उप-समूह" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 229px; HEIGHT: 30px"><asp:DropDownList id="ddlSubCategory_rqd" tabIndex=2 runat="server" Width="155px" AutoPostBack="True" OnSelectedIndexChanged="ddlSubCategory_SelectedIndexChanged" ToolTip="उप-समूह" Enabled="False">
            </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 15px; HEIGHT: 38px"><asp:Label id="lblItem" runat="server" Text="सामान" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 150px; HEIGHT: 38px" colSpan=3><asp:DropDownList id="ddlItems_rqd" tabIndex=3 runat="server" Width="495px" AutoPostBack="True" OnSelectedIndexChanged="ddlItems_SelectedIndexChanged" ToolTip="सामान" Enabled="False"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 15px; HEIGHT: 28px"><asp:Label id="lblDate" runat="server" Width="89px" Text="दाखिला मिति" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 150px; HEIGHT: 28px"><asp:TextBox id="txtDakhilaDate_RDT" runat="server" Width="76px" ToolTip="दाखिला मिति" MaxLength="4"></asp:TextBox></TD><TD style="WIDTH: 101px; HEIGHT: 28px"><asp:Label id="lblJelaaKhataNo" runat="server" Text="जि.खा.पा.नं." SkinID="Unicodelbl" Visible="False"></asp:Label></TD><TD style="WIDTH: 229px; HEIGHT: 28px"><asp:TextBox id="txtJelaaKhataNo_rqd" runat="server" Width="148px" ToolTip="जि.खा.पा.नं." MaxLength="5" Visible="False"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 15px; HEIGHT: 31px"><asp:Label id="lblEntryType" runat="server" Width="103px" Text="अनुदान" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 150px; HEIGHT: 31px"><asp:CheckBox id="chkDonation" tabIndex=6 runat="server" AutoPostBack="True" ToolTip="अनुदान" OnCheckedChanged="CheckBox1_CheckedChanged"></asp:CheckBox></TD><TD style="WIDTH: 101px; HEIGHT: 31px"><asp:Label id="lblDonOrg" runat="server" Width="123px" Text="अनुदान गर्ने संस्था" SkinID="Unicodelbl" Visible="False"></asp:Label></TD><TD style="WIDTH: 229px; HEIGHT: 31px"><asp:TextBox id="txtDonOrg_rqd" tabIndex=7 runat="server" Width="148px" ToolTip="अनुदान गर्ने संस्था" Visible="False"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 15px; HEIGHT: 32px"><asp:Label id="lblUnitPrice" runat="server" Text="दर" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 150px; HEIGHT: 32px"><asp:TextBox id="txtUnitPrice_rqd" tabIndex=8 runat="server" Width="64px" ToolTip="दर" MaxLength="8"></asp:TextBox></TD><TD style="WIDTH: 101px; HEIGHT: 32px"><asp:Label id="lblQuantity" runat="server" Text="परिमाण" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 229px; HEIGHT: 32px"><asp:TextBox id="txtQty_rqd" tabIndex=9 runat="server" Width="64px" ToolTip="परिमाण" MaxLength="6"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 15px"></TD><TD style="WIDTH: 150px"></TD><TD style="WIDTH: 101px"></TD><TD style="WIDTH: 229px"></TD></TR><TR><TD style="WIDTH: 15px; HEIGHT: 26px"></TD><TD style="WIDTH: 150px; HEIGHT: 26px"></TD><TD style="WIDTH: 101px; HEIGHT: 26px"></TD><TD style="WIDTH: 229px; HEIGHT: 26px"><asp:Button id="btnAdd" tabIndex=10 onclick="btnAdd_Click" runat="server" Text="Add" SkinID="Normal" OnClientClick="javascript: return validate(1);"></asp:Button> <asp:Button id="btnSubmit" tabIndex=11 onclick="btnSubmit_Click" runat="server" Text="Submit" SkinID="Normal"></asp:Button> <asp:Button id="btnCancel" tabIndex=13 onclick="btnCancel_Click" runat="server" Text="Cancel" SkinID="Cancel"></asp:Button></TD></TR><TR><TD style="HEIGHT: 26px" colSpan=4>
<HR />
&nbsp;</TD></TR></TBODY></TABLE><DIV style="PADDING-LEFT: 20px; OVERFLOW: auto; WIDTH: 95%" id="DIV1"><asp:Label id="lblEntryCount" runat="server" SkinID="Unicodelbl"></asp:Label><BR /></DIV><DIV style="PADDING-LEFT: 20px; OVERFLOW: auto; WIDTH: 95%; HEIGHT: 300px" id="dvDakhila"><asp:GridView id="grdDakhila" runat="server" ForeColor="#333333" OnSelectedIndexChanged="grdDakhila_SelectedIndexChanged" CellPadding="4" GridLines="None" AutoGenerateColumns="False" OnRowCreated="grdDakhila_RowCreated" OnRowDataBound="grdDakhila_RowDataBound" OnRowDeleting="grdDakhila_RowDeleting">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:TemplateField HeaderText="सिनं.">
<ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
<ItemTemplate>
<%# Container.DataItemIndex + 1 %>
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="OrgID" HeaderText="OrgID"></asp:BoundField>
<asp:BoundField DataField="ItemsCategoryID" HeaderText="ItemsCategoryID"></asp:BoundField>
<asp:BoundField DataField="ItemsSubCategoryID" HeaderText="ItemsSubCategoryID"></asp:BoundField>
<asp:BoundField DataField="ItemsID" HeaderText="ItemsID"></asp:BoundField>
<asp:BoundField DataField="ItemsTypeID" HeaderText="ItemsTypeID"></asp:BoundField>
<asp:BoundField DataField="ItemsCategoryName" HeaderText="समूह"></asp:BoundField>
<asp:BoundField DataField="ItemsSubCategoryName" HeaderText="उप-समूह"></asp:BoundField>
<asp:BoundField DataField="ItemsName" HeaderText="सामान"></asp:BoundField>
<asp:BoundField DataField="DirectEntryDate" HeaderText="दाखिला मिति"></asp:BoundField>
<asp:BoundField HeaderText="सामानको प्रकार"></asp:BoundField>
<asp:BoundField HeaderText="अनुदान(हो / होइन)"></asp:BoundField>
<asp:BoundField DataField="DonationOrg" HeaderText="अनुदान गर्ने संस्था"></asp:BoundField>
<asp:BoundField DataField="UnitPrice" HeaderText="दर(रु)"></asp:BoundField>
<asp:BoundField DataField="Quantity" HeaderText="परिमाण"></asp:BoundField>
<asp:TemplateField HeaderText="जम्मा रुपैया (रू)"></asp:TemplateField>
<asp:CommandField ShowSelectButton="True"></asp:CommandField>
<asp:CommandField ShowDeleteButton="True"></asp:CommandField>
<asp:TemplateField><ItemTemplate>
                     <asp:Button ID="btnKnj" runat="server" OnClick="btnKnj_Click" SkinID="Normal" Text="Enter Data" />
                 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="DirectEntryType" HeaderText="DirectEntryType"></asp:BoundField>
<asp:BoundField DataField="Action" HeaderText="Action"></asp:BoundField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> </DIV>
</contenttemplate>
        <triggers>
<asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnSubmit" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="ddlCategory_rqd" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="ddlSubCategory_rqd" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="ddlItems_rqd" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="OkButton" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="chkDonation" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="imbBtnClose2" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
     </asp:UpdatePanel>
     
        <!-- NB::  Code for  Meeting Comments Starts from Here -->
    <asp:Button ID="hiddenTargetControlForCommentModalPopup" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="programmaticCommentModalPopup" runat="server"
        BackgroundCssClass="modalBackground" BehaviorID="programmaticCommentModalPopupBehavior"
        DropShadow="false" PopupControlID="programmaticCommentPopup" PopupDragHandleControlID="programmaticCommentPopupDragHandle"
        RepositionMode="None" TargetControlID="hiddenTargetControlForCommentModalPopup">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="programmaticCommentPopup" runat="server" BackColor="whitesmoke" Height="500px"
        Style="display: none; padding: 10px">
        <p style="width: 748px;">
        <asp:ImageButton ID="imbBtnClose2" runat="server" align="right" ImageUrl="~/MODULES/OAS/Images/btn_cancel.gif"
                OnClick="imbBtnClose2_Click" Style="padding-right: 13px" />
        </p>
        <br />
        <asp:Panel ID="programmaticCommentPopupDragHandle" runat="Server" Height="592px">
        
             <asp:UpdatePanel id="UpdatePanel2" runat="server">
                 <contenttemplate>
<FIELDSET style="HEIGHT: 396px"><LEGEND><asp:Label id="lblComment" runat="server" SkinID="Unicodelbl">     खर्च नभईजाने</asp:Label> </LEGEND><DIV style="PADDING-LEFT: 20px; OVERFLOW: auto; WIDTH: 724px; HEIGHT: 310px" id="dvKharcBhaiNajaane"><asp:GridView id="grdNonExpendible" runat="server" Width="692px" ForeColor="#333333" CellPadding="4" GridLines="None" AutoGenerateColumns="False" OnRowDataBound="grdNonExpendible_RowDataBound">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:TemplateField HeaderText="सिनं.">
<ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
<ItemTemplate>
<%# Container.DataItemIndex + 1 %>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="सामान विवरण"><ItemTemplate>
                     <asp:TextBox ID="txtBox1" runat="server" Width="470px"></asp:TextBox>
                 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="सवारी भए दर्ता नं. राख्नुहोस्"><ItemTemplate>
                     <asp:TextBox ID="txtBox2" runat="server"></asp:TextBox>
                 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> </DIV><BR /><TABLE style="WIDTH: 712px" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="HEIGHT: 37px" align=right><asp:Button id="btnKNJ" onclick="btnKNJ_Click" runat="server" Width="40px" Text="OK" SkinID="Normal"></asp:Button> <asp:Button id="Button1" onclick="Button1_Click" runat="server" Text="Cancel" SkinID="Cancel"></asp:Button> </TD></TR><TR><TD style="HEIGHT: 24px" align=right></TD></TR></TBODY></TABLE></FIELDSET> 
</contenttemplate>
   </asp:UpdatePanel>
   
     

        </asp:Panel>
       
    </asp:Panel>
 </div>
</asp:Content>

