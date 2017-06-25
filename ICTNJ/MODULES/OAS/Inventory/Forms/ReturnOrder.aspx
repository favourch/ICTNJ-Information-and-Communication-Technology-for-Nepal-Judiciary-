<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true" CodeFile="ReturnOrder.aspx.cs" Inherits="MODULES_OAS_Inventory_Forms_ReturnOrder" Title=".:Return Order" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../../UserControls/InvReturnOrder.ascx" TagName="ReturnOrder" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
     
    <script language="javascript" src="../../../COMMON/JS/Validation.js" type="text/javascript"></script>
    <script language="javascript" src="../../../COMMON/JS/DateValidator.js" type="text/javascript"></script>
    <script language="javascript" src="../../../COMMON/JS/UPanelValidation.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
       
    function validateReturnOrder()
    { 
        var obj1 = document.getElementById('<%=this.hdnDate.ClientID%>');
        var obj2 = document.getElementById('<%=this.txtReturnDate_RDT.ClientID%>');
       
    
        if(validate(1))
        {
            if(CompareDate(obj1,obj2))
            {
                return true;
            }
            else
                return false;
        }
        else
            return false;
    }
       
       
    function CompareDate(obj1,obj2)
    {                    
        var myfocus ="";
        var ErrorMsg = "";
        var flag = false;
       
        var DateElement1 = obj1.value.split("/");
        var DateElement2 = obj2.value.split("/");
              
        
       if(DateElement1[0] > DateElement2[0])
       {   
            flag = true;
                                   
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
                                     
                if(myfocus == "")
                {
                    myfocus = obj2;
                }
             
             }
             else if(DateElement1[1] == DateElement2[1])
             {
                 if(DateElement1[2] > DateElement2[2])
                 {
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
           
            ErrorMsg=ErrorMsg + "'सामान फिर्ता गर्ने मिति' 'सामान पाएको  मिति'  भन्दा  बढी हुनुपर्छ।\n";
           
        
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
<asp:Panel style="BORDER-RIGHT: gray 1px solid; BORDER-TOP: gray 1px solid; BORDER-LEFT: gray 1px solid; CURSOR: move; COLOR: black; BORDER-BOTTOM: gray 1px solid; BACKGROUND-COLOR: #dddddd; TEXT-ALIGN: center" id="programmaticPopupDragHandle" runat="Server"><asp:Label id="lblStatusMessageTitle" runat="server" CssClass="simplelabel">
    </asp:Label>
    </asp:Panel> <asp:Label id="lblStatusMessage" runat="server" CssClass="simplelabel" EnableTheming="False" ForeColor="Black"></asp:Label> 
</contenttemplate>
        </asp:UpdatePanel>
        <asp:Button ID="OkButton" runat="server" Text="OK" Width="58px" OnClick="OkButton_Click" />
        <br />
    </asp:Panel>
    
    <!-- End of error Popup status -->
    <BR />
 
    <asp:UpdatePanel id="updReturnOrder" runat="server">
     <contenttemplate>
<uc1:ReturnOrder id="ReturnOrder1" runat="server"></uc1:ReturnOrder> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender1" runat="server" TargetControlID="txtReturnDate_RDT" MaskType="Date" Mask="9999/99/99" ClearMaskOnLostFocus="False" AutoComplete="False">
           </ajaxToolkit:MaskedEditExtender> <asp:HiddenField id="hdnDate" runat="server" __designer:wfdid="w4"></asp:HiddenField><BR /><asp:Panel id="pnlReturnOrder" runat="server" Visible="False"><TABLE style="PADDING-LEFT: 20px; WIDTH: 676px" cellSpacing=2 cellPadding=0 border=0><TBODY><TR><TD style="HEIGHT: 19px" colSpan=2><asp:Label id="lblHeader" runat="server" Text="सामान फिर्ता विवरण" SkinID="Unicodelbl" Font-Names="Verdana" Font-Bold="True" Font-Underline="True"></asp:Label></TD></TR><TR><TD style="WIDTH: 440px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </TD></TR><TR><TD style="WIDTH: 440px; HEIGHT: 41px"><asp:Label id="lblReturnDate" runat="server" Width="74px" Text="फिर्ता मिति" SkinID="Unicodelbl"></asp:Label><asp:Label id="Label2" runat="server" CssClass="simplelabel" Text="*" __designer:dtid="1970333426909294" ForeColor="Red" EnableTheming="False" __designer:wfdid="w1"></asp:Label></TD><TD style="HEIGHT: 41px"><asp:TextBox id="txtReturnDate_RDT" runat="server" Width="80px" ToolTip="फिर्ता मिति"></asp:TextBox></TD><TD style="PADDING-LEFT: 20px; WIDTH: 161px; HEIGHT: 41px"></TD><TD style="PADDING-LEFT: 20px; WIDTH: 161px; HEIGHT: 41px"></TD></TR><TR><TD style="VERTICAL-ALIGN: top; WIDTH: 440px; HEIGHT: 20px"><asp:Label id="lblReturnRemark" runat="server" Width="89px" Text="फिर्ता विवरण" SkinID="Unicodelbl"></asp:Label><asp:Label id="Label1" runat="server" CssClass="simplelabel" Text="*" __designer:dtid="1970333426909294" ForeColor="Red" EnableTheming="False" __designer:wfdid="w2"></asp:Label></TD><TD style="HEIGHT: 20px" colSpan=3 rowSpan=1><asp:TextBox id="txtReturnRemark_rqd" runat="server" Width="499px" Height="70px" ToolTip="फिर्ता विवरण" MaxLength="50"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 440px; HEIGHT: 19px">&nbsp;</TD><TD style="HEIGHT: 19px">&nbsp;</TD><TD style="WIDTH: 161px; HEIGHT: 19px">&nbsp;</TD><TD style="WIDTH: 202px; HEIGHT: 19px">&nbsp;</TD></TR><TR><TD style="WIDTH: 440px; HEIGHT: 25px">&nbsp;</TD><TD style="HEIGHT: 25px">&nbsp;</TD><TD style="WIDTH: 161px; HEIGHT: 25px">&nbsp;</TD><TD style="PADDING-LEFT: 90px; WIDTH: 202px; HEIGHT: 25px"><asp:Button id="btnSubmit" onclick="btnSubmit_Click" runat="server" Text="Submit" SkinID="Normal" ToolTip="Submit" OnClientClick="javascript: return validateReturnOrder();"></asp:Button> <asp:Button id="btnCancel" onclick="btnCancel_Click" runat="server" Text="Cancel" SkinID="Cancel" ToolTip="Cancel"></asp:Button></TD></TR></TBODY></TABLE></asp:Panel> 
</contenttemplate>
    </asp:UpdatePanel>
    <br /><br /><br />
   </div>
</asp:Content>

