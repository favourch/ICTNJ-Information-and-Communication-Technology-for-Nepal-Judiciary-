<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Control Language="C#" AutoEventWireup="true"  CodeFile="InvPurchaseOrderDetail.ascx.cs" Inherits="MODULES_OAS_UserControls_InvPurchaseOrderDetail" %>
    <script language="javascript" src="../../../COMMON/JS/Validation.js" type="text/javascript"></script>
    <script language="javascript" src="../../../COMMON/JS/DateValidator.js" type="text/javascript"></script>
    <script language="javascript" src="../../../COMMON/JS/UPanelValidation.js" type="text/javascript"></script>
    <script language="javascript" src="../../../COMMON/JS/Number.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
       
    function validateRecmApprv()
    {
        var ErrMsg = "";
        var objChk = document.getElementById('<%=this.chkRecomend_rqd.ClientID%>');
        var objType = document.getElementById('<%=this.hdnType.ClientID%>');
          
        var objDate1 = document.getElementById('<%=this.hdnDate.ClientID%>');
        var objDate2 = document.getElementById('<%=this.txtRecomendDate_RDT.ClientID%>');
        
         
        if(objChk.checked)
        {
            if(validateDate())
            {   
                if(CompareDate(objDate1,objDate2,objType.value))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        else
        {   
             if(objType.value == "1")
                ErrMsg = "- कृपया सिफारिस चेक गर्नुहोस् ।\n";
             else
               ErrMsg = "- कृपया प्रमाणिकरण चेक गर्नुहोस् ।\n";
               
             alert("सर्वप्रथम निम्न त्रुटिहरू सच्याउनुहोस।\n\n" + ErrMsg); 
             objChk.focus();
             return false;
        }
    
    
        
    }
     
    
    function CompareDate(obj1,obj2,type)
    {                    
        var myfocus ="";
        var ErrorMsg = "";
        var flag = false;
       
        var DateElement1 = obj1.value.split("/");
        var DateElement2 = obj2.value.split("/");
              
        
       if(DateElement1[0] > DateElement2[0])
       {   
            flag = true;
            //ErrorMsg=ErrorMsg + "'प्रमाणीकरण मिति'   'सिफारिस मिति'  भन्दा  बढी हुनुपर्छ।\n";
                        
            if(myfocus == "")
            {
                myfocus = obj2;
            }
        }
        else if(DateElement1[0] == DateElement2[0])
        {  
             if(DateElement1[1] > DateElement2[1])
             {
                flag = true;
                //ErrorMsg=ErrorMsg + "'प्रमाणीकरण मिति'   'सिफारिस मिति'  भन्दा  बढी हुनुपर्छ।\n";
                        
                if(myfocus == "")
                {
                    myfocus = obj2;
                }
             
             }
             else if(DateElement1[1] == DateElement2[1])
             {
                 if(DateElement1[2] > DateElement2[2])
                 {
                     //ErrorMsg=ErrorMsg + "'प्रमाणीकरण मिति'   'सिफारिस मिति'  भन्दा  बढी हुनुपर्छ।\n";
                     flag = true;
                            
                    if(myfocus == "")
                    {
                        myfocus = obj2;
                    }
                    
                 }
            }
        }

       
    
        if(flag)
        {
            if(type == "1")
                ErrorMsg=ErrorMsg + "'सिफारिस मिति'   'अर्डर मिति'  भन्दा  बढी हुनुपर्छ।\n";
            else
                ErrorMsg=ErrorMsg + "'प्रमाणीकरण मिति'   'सिफारिस मिति'  भन्दा  बढी हुनुपर्छ।\n";
        
            alert("निम्न मितिको त्रुटिहरू सच्याउनुहोस::\n\n"+ErrorMsg);
            myfocus.focus();
            myfocus = "";
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
          
        <asp:Panel ID="pnlPoDetail" runat="server" Width ="100%" >
             <!-- NB:: For Purchase Order -->
            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AutoComplete="False"
                Mask="9999/99/99" MaskType="Date" TargetControlID="txtOrderDate" ClearMaskOnLostFocus="False">
            </ajaxToolkit:MaskedEditExtender><ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" AutoComplete="False"
                Mask="9999/99/99" MaskType="Date" TargetControlID="txtRecomendDate_RDT">
            </ajaxToolkit:MaskedEditExtender>
            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                FilterType="Numbers" TargetControlID="txtQty_cat" ValidChars='.'>
            </ajaxToolkit:FilteredTextBoxExtender>
            <asp:HiddenField ID="hdnType" runat="server" /><asp:HiddenField ID="hdnDate" runat="server" />

<BR />
<asp:Panel ID="pnlPurchase" runat="server"  Width="100%">

<TABLE style="PADDING-LEFT: 20px; WIDTH: 676px" cellSpacing=2 cellPadding=0 border=0><TBODY><TR><TD colspan="2" style="height: 19px"><asp:Label id="lblHeader" runat="server" Text="खरिद अर्डर विवरण" SkinID="Unicodelbl" Font-Underline="True" Font-Bold="True" Font-Names="Verdana" ToolTip="खरिद अर्डर विवरण"></asp:Label></TD></TR><TR><TD>&nbsp;</TD></TR>
    <tr>
        <td>
        </td>
    </tr>
    <TR><TD style="HEIGHT: 24px">
    &nbsp;<asp:Label id="lblOrderDate" runat="server" Width="88px" Text="अर्डर मिति" SkinID="Unicodelbl" ToolTip="अर्डर मिति"></asp:Label></TD><TD style="HEIGHT: 24px"><asp:TextBox id="txtOrderDate" runat="server" ToolTip="अर्डर मिति" Width="80px"></asp:TextBox></TD><TD style="HEIGHT: 24px">
    &nbsp;<asp:Label id="lblSupplier" runat="server" Text="सप्लायर" SkinID="Unicodelbl" ToolTip="सप्लायर"></asp:Label></TD><TD style="HEIGHT: 24px">
               <asp:DropDownList ID="ddlSupplier" runat="server" Width="167px" ToolTip="सप्लायर">
               </asp:DropDownList></TD></TR><TR><TD><asp:Label id="lblCategory" runat="server" Text="समूह" SkinID="Unicodelbl" ToolTip="समूह"></asp:Label> </TD><TD><asp:DropDownList id="ddlCategory_cat" runat="server" Width="167px" ToolTip="समूह" OnSelectedIndexChanged="ddlCategory_cat_SelectedIndexChanged" AutoPostBack="True">
         </asp:DropDownList> </TD><TD><asp:Label id="lblSubCategory" runat="server" Text="उप-समूह" SkinID="Unicodelbl" ToolTip="उप-समूह"></asp:Label> </TD><TD><asp:DropDownList id="ddlSubCategory_cat" runat="server" Width="167px" ToolTip="उप-समूह" OnSelectedIndexChanged="ddlSubCategory_cat_SelectedIndexChanged" AutoPostBack="True" Enabled="False">
        </asp:DropDownList> </TD></TR><TR><TD style="HEIGHT: 25px"><asp:Label id="lblItem" runat="server" Text="सामान" SkinID="Unicodelbl" ToolTip="सामान"></asp:Label> </TD><TD style="HEIGHT: 25px" colspan="3"><asp:DropDownList id="ddlItems_cat" runat="server" Width="472px" ToolTip="सामान" AutoPostBack="True">
        </asp:DropDownList> </TD></TR>
    <tr>
        <td style="height: 25px">
            <asp:Label id="lblQuantity" runat="server" Text="परिमाण" SkinID="Unicodelbl" ToolTip="परिमाण"></asp:Label></td>
        <td style="height: 25px">
            <asp:TextBox id="txtQty_cat" runat="server" ToolTip="परिमाण" MaxLength="4" Width="60px"></asp:TextBox></td>
        <td style="height: 25px">
        </td>
        <td style="height: 25px">
        </td>
    </tr>
    </TBODY></TABLE>
    <table style="width: 613px">
        <tr>
            <td style="width: 3px; height: 26px;">
            </td>
            <td style="height: 26px" align="right">
                <asp:Button id="btnAdd" onclick="btnAdd_Click" runat="server" Width="45px" Text="Add" SkinID="Normal" ToolTip="Add" OnClientClick=" javascript:return validateUpanelFields('_cat','_cat');"></asp:Button> <asp:Button id="btnSubmit" onclick="btnSubmit_Click" runat="server" Text="Submit" SkinID="Normal" ToolTip="Submit" ></asp:Button> <asp:Button id="btnCancel" runat="server" Text="Cancel" SkinID="Cancel" OnClick="btnCancel_Click1" ToolTip="Cancel"></asp:Button></td>
            <td style="width: 3px; height: 26px;">
            </td>
        </tr>
    </table>
<HR style="PADDING-LEFT: 20px; WIDTH: 1000px" />
  </asp:Panel>

<DIV style="PADDING-LEFT: 20px; OVERFLOW: auto; WIDTH: 95%" id="dvPurchaseOrder">
    <asp:Label ID="lblCount" runat="server" SkinID="Unicodelbl"></asp:Label><br />
    <br />
    <asp:GridView id="grdPurchaseOrderDetail" runat="server" AutoGenerateColumns="False" GridLines="None" ForeColor="#333333" CellPadding="4" OnSelectedIndexChanged="grdPurchaseOrderDetail_SelectedIndexChanged" OnRowCreated="grdPurchaseOrderDetail_RowCreated" OnRowDataBound="grdPurchaseOrderDetail_RowDataBound" OnRowDeleting="grdPurchaseOrderDetail_RowDeleting">
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <EditRowStyle BackColor="#999999" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="सिनं.">
                    <ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

                    <HeaderStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                    <ItemTemplate>
                         <%# Container.DataItemIndex + 1 %>.
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="CatID" DataField="ItemsCategoryID" />
                    <asp:BoundField DataField="ItemsSubCategoryID" HeaderText="SubCatID" />
                    <asp:BoundField DataField="ItemsID" HeaderText="ItemsID" />
                    <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" />
                    <asp:BoundField HeaderText="समूह" DataField="ItemsCategoryName" />
                    <asp:BoundField HeaderText="उप-समूह" DataField="ItemsSubCategoryName" />
                    <asp:BoundField HeaderText="सामान" DataField="ItemsName" />
                    <asp:TemplateField HeaderText="रूपैयाँ (रु)">
                        <ItemTemplate>
                            <asp:TextBox ID="txtUnitPrice" runat="server" Width="106px" AutoPostBack="True" OnTextChanged="txtUnitPrice_TextChanged" MaxLength="8"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="परिमाण" DataField="TotalQty" />
                    <asp:TemplateField HeaderText="जम्मा रुपैयाँ (रू)">
                        <ItemTemplate>
                            <asp:Label ID="lblTotalPrice" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:CommandField ShowDeleteButton="True" DeleteText="Remove" />
                    <asp:BoundField DataField="Action" HeaderText="Action" />
                </Columns>
             </asp:GridView> <BR /><BR /></DIV>
             
             
        
            
    <asp:Panel ID="pnlRecmAndApprv" runat="server" Height="50px" Width="125px">
       
    <!-- NB: For Recomendation/approval -->    
    <TABLE style="PADDING-LEFT: 20px; WIDTH: 676px" cellSpacing=2 cellPadding=0 border=0><TBODY><TR><TD colspan="2" style="height: 19px"><asp:Label id="lblRecmApprv" runat="server" Text="सिफारिस विवरण" SkinID="Unicodelbl" Font-Underline="True" Font-Bold="True" Font-Names="Verdana" ToolTip="सिफारिस विवरण"></asp:Label></TD></TR>
    <tr>
        <td style="height: 25px; width: 90px;">
            <asp:Label ID="lblRecomend" runat="server" SkinID="Unicodelbl" Text="सिफारिस" Width="61px"></asp:Label>&nbsp;
            <asp:Label ID="Label1" runat="server" CssClass="simplelabel" EnableTheming="False"
                ForeColor="Red" Text="*"></asp:Label></td>
        <td style="height: 25px; width: 97px;">
            <br />
            <asp:CheckBox ID="chkRecomend_rqd" runat="server" ToolTip="सिफारिस" Height="39px" Width="157px" /></td>
        <td style="height: 25px; width: 115px;">
            <asp:Label ID="lblRecomendDate" runat="server" SkinID="Unicodelbl" Text="सिफारिस मिति"></asp:Label>
            <asp:Label ID="Label2" runat="server" CssClass="simplelabel" EnableTheming="False"
                ForeColor="Red" Text="*"></asp:Label></td>
        <td style="height: 25px">
            <asp:TextBox ID="txtRecomendDate_RDT" runat="server" Width="80px"></asp:TextBox></td>
    </tr>
    <TR><TD style="HEIGHT: 31px; width: 90px;"></TD><TD style="HEIGHT: 31px; width: 97px;"></TD><TD style="HEIGHT: 31px; padding-left: 57px;" colSpan=2 rowSpan=2> <asp:Button id="btnSubmit1" onclick="btnSubmit_Click" runat="server" Text="Submit" SkinID="Normal" ToolTip="Submit" OnClientClick="return validateRecmApprv();" ></asp:Button> <asp:Button id="btnCancel1" runat="server" Text="Cancel" SkinID="Cancel" OnClick="btnCancel1_Click" ToolTip="Cancel"></asp:Button></TD>
    </TR>
    </TBODY>
    </TABLE>
   </asp:Panel>            
 </asp:Panel>
</contenttemplate>
       <triggers>
<asp:AsyncPostBackTrigger ControlID="ddlUnit_rqd" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="ddlCategory_cat" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="ddlSubCategory_cat" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnSubmit" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="OkButton" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click"></asp:AsyncPostBackTrigger>
           <asp:AsyncPostBackTrigger ControlID="chkRecomend_rqd" EventName="CheckedChanged" />
</triggers>
       </asp:UpdatePanel>
        <BR /><BR /> <BR /><br /><br />
        
        
        
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