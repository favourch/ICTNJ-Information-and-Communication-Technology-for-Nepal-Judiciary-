<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="InvReturnOrder.ascx.cs" Inherits="MODULES_OAS_UserControls_InvReturnOrder" %>
    <script language="javascript" src="../../../COMMON/JS/Validation.js" type="text/javascript"></script>
    <script language="javascript" src="../../../COMMON/JS/UPanelValidation.js" type="text/javascript"></script>
    <script language="javascript" src="../../../COMMON/JS/DateValidator.js" type="text/javascript"></script>
    <script language="javascript" src="../../../COMMON/JS/Number.js" type="text/javascript"></script>
  <div style="width:100%; height:auto">
  
  <TABLE style="PADDING-LEFT: 20px; WIDTH: 676px" cellSpacing=2 cellPadding=0 border=0>
      <tr>
          <td colspan="2" rowspan="1" style="height: 19px">
              <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Underline="True"
                  SkinID="UnicodeHeadlbl" Text="डेलिभरी सामान फिर्ता"></asp:Label></td>
          <td style="height: 19px">
              <asp:HiddenField ID="hdnReceivedDate" runat="server" />
          </td>
      </tr>
      <TR><TD style="HEIGHT: 19px" colSpan=2 rowSpan=1></TD><TD style="HEIGHT: 19px"></TD>
      </TR>
      <TR><TD style="HEIGHT: 19px" colSpan=2 rowSpan=1><asp:Label id="Label1" runat="server" Text="डेलिभरी खोज" SkinID="Unicodelbl" Font-Names="Verdana" Font-Bold="True" Font-Underline="True"></asp:Label></TD><TD style="HEIGHT: 19px"></TD>
      </TR>
      <TR><TD>&nbsp;</TD>
      </TR>
      <TR><TD style="HEIGHT: 25px"><asp:Label id="lblUnit" runat="server" Width="78px" Text="शाखा" SkinID="Unicodelbl" ToolTip="शाखा"></asp:Label> </TD>
          <TD style="HEIGHT: 25px"><asp:DropDownList id="ddlUnit_srch" runat="server" Width="167px" ToolTip="शाखा" AutoPostBack="True"></asp:DropDownList> </TD>
          <TD style="HEIGHT: 25px"><asp:Label id="lblOrder" runat="server" Width="101px" Text="अर्डर नं." SkinID="Unicodelbl" ToolTip="अर्डर नं."></asp:Label></TD><TD style="HEIGHT: 25px"><asp:TextBox id="txtOrderNo_srch" runat="server" ToolTip="अर्डर नं."></asp:TextBox></TD>
       </TR>
      <TR><TD style="HEIGHT: 24px">&nbsp;</TD>
          <TD style="HEIGHT: 24px">&nbsp;</TD><TD style="HEIGHT: 24px">&nbsp;</TD><TD style="HEIGHT: 24px"></TD>
      </TR>
      <TR><TD>&nbsp;</TD><TD></TD>
          <TD style="PADDING-LEFT: 173px" colSpan=2 rowSpan=2><asp:Button id="btnSearch" runat="server" Text="Search" SkinID="Dynamic" ToolTip="Search" OnClick="btnSearch_Click" OnClientClick=" javascript:return validateUpanelFields('_srch','_srch');"></asp:Button> <asp:Button id="btnCancel" onclick="btnCancel_Click" runat="server" Text="Cancel" SkinID="Cancel"></asp:Button></TD>
      </TR>
  </TABLE>
    <HR style="PADDING-LEFT: 20px; WIDTH: 1000px" />
    
    <DIV style="PADDING-LEFT: 20px; OVERFLOW: auto; WIDTH: 95%" id="DIV1">
        <asp:Label id="lblDeliveryCount" runat="server" SkinID="Unicodelbl"></asp:Label><BR /><BR />
        <asp:GridView id="grdDelivery" runat="server" AutoGenerateColumns="False" GridLines="None" ForeColor="#333333" CellPadding="4" OnSelectedIndexChanged="grdDelivery_SelectedIndexChanged" OnRowDataBound="grdDelivery_RowDataBound">
            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
            <Columns>
            <asp:TemplateField HeaderText="सिनं.">
            <ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

            <HeaderStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
            <ItemTemplate>
                                     <%# Container.DataItemIndex + 1 %>.
                                
            </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="DeliveryPerson" HeaderText="डेलिभरी गर्ने व्यक्ति"></asp:BoundField>
            <asp:BoundField DataField="DeliveryDate" HeaderText="डेलिभरी मिति"></asp:BoundField>
            <asp:BoundField DataField="ReceiverName" HeaderText="पाउने व्यक्तिको नाम"></asp:BoundField>
            <asp:BoundField DataField="ReceivedDate" HeaderText="पाएको मिति"></asp:BoundField>
                <asp:BoundField DataField="OrderNo" HeaderText="अर्डर नं." />
                <asp:BoundField HeaderText="इनभोइस् नं." DataField="InvoiceNo" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>

            <RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

            <EditRowStyle BackColor="#999999"></EditRowStyle>

            <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

            <HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

            <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
        </asp:GridView>
         <BR />
    </DIV>
    <BR /><BR />
    <DIV style="PADDING-LEFT: 20px; OVERFLOW: auto; WIDTH: 95%" id="dvDeliveryOrder">
        <asp:Label id="lblItemCount" runat="server" SkinID="Unicodelbl"></asp:Label><BR /><BR />
        <asp:GridView id="grdDeliveryDetails" runat="server" AutoGenerateColumns="False" GridLines="None" ForeColor="#333333" CellPadding="4" OnRowDataBound="grdDeliveryDetails_DataBound" OnRowCreated="grdDeliveryDetails_RowCreated">
            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
            <Columns>
            <asp:TemplateField HeaderText="सिनं.">
            <ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

            <HeaderStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
            <ItemTemplate>
                                     <%# Container.DataItemIndex + 1 %>.
                                
            </ItemTemplate>
            </asp:TemplateField>
                <asp:BoundField DataField="OrgID" HeaderText="OrgID" />
                <asp:BoundField DataField="UnitID" HeaderText="UnitID" />
                <asp:BoundField DataField="OrderNo" HeaderText="अर्डर नं." />
                <asp:BoundField DataField="DeliverySeq" HeaderText="डेलिभरी क्रम" />
                <asp:BoundField DataField="ItemsCategoryID" HeaderText="ItemsCategoryID" />
                <asp:BoundField DataField="ItemsSubCategoryID" HeaderText="ItemsSubCategoryID" />
                <asp:BoundField DataField="ItemsID" HeaderText="ItemsID" />
            <asp:BoundField DataField="ItemsCategoryName" HeaderText="समूह"></asp:BoundField>
            <asp:BoundField DataField="ItemsSubCategoryName" HeaderText="उप-समूह"></asp:BoundField>
            <asp:BoundField DataField="ItemsName" HeaderText="सामान"></asp:BoundField>
            <asp:BoundField DataField="DeliveredQty" HeaderText="डेलिभरी भएको परिमाण"></asp:BoundField>
                <asp:BoundField DataField="ReturnedQty" HeaderText="फिर्ता भएको परिमाण" />
            <asp:TemplateField HeaderText="अब फिर्ता हुने परिमाण"><ItemTemplate>
            <asp:TextBox id="txtReturnQty" runat="server" AutoPostBack="True" OnTextChanged="txtReturnQty_TextChanged"></asp:TextBox> 
            </ItemTemplate>
            </asp:TemplateField>
            </Columns>

            <RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

            <EditRowStyle BackColor="#999999"></EditRowStyle>

            <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

            <HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

            <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
        </asp:GridView>
         <BR />
    </DIV>
      <!-- For Popup error status -->
    <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground"
        DropShadow="True" PopupControlID="programmaticPopup"
        PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
        TargetControlID="hiddenTargetControlForModalPopup">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none;
        width: 350px; padding: 10px">
        &nbsp;&nbsp;
        <asp:UpdatePanel id="UpdatePanel1" runat="server">
            <contenttemplate>
<asp:Panel style="BORDER-RIGHT: gray 1px solid; BORDER-TOP: gray 1px solid; BORDER-LEFT: gray 1px solid; CURSOR: move; COLOR: black; BORDER-BOTTOM: gray 1px solid; BACKGROUND-COLOR: #dddddd; TEXT-ALIGN: center" id="programmaticPopupDragHandle" runat="Server"><asp:Label id="lblStatusMessageTitle" runat="server" CssClass="simplelabel"></asp:Label></asp:Panel> <asp:Label id="lblStatusMessage" runat="server" CssClass="simplelabel" ForeColor="Black" EnableTheming="False"></asp:Label> 
</contenttemplate>
        </asp:UpdatePanel>
        <asp:Button ID="OkButton" runat="server"
            Text="OK" Width="58px" OnClick="OkButton_Click" />
        <br />
    </asp:Panel>
</div>