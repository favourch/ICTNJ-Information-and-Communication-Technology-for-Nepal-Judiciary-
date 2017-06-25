<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="InvDeliveryOrder.ascx.cs" Inherits="MODULES_OAS_UserControls_InvDeliveryOrder" %>
 <script language="javascript" src="../../../COMMON/JS/Validation.js" type="text/javascript"></script>
    <script language="javascript" src="../../../COMMON/JS/UPanelValidation.js" type="text/javascript"></script>
    <script language="javascript" src="../../../COMMON/JS/DateValidator.js" type="text/javascript"></script>
    <script language="javascript" src="../../../COMMON/JS/Number.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function DeliveryValidate()
        {
              
            if(validateUpanelFields('_delv','_delv'))
            {
                if(validateDate())
                {
                    var obj1 = document.getElementById('<%=this.txtApproveDate.ClientID%>');
                    var obj2 = document.getElementById('<%=this.txtDeliveryDate_RDT.ClientID%>');
                    var obj3 = document.getElementById('<%=this.txtReceivedDate_RDT.ClientID%>');
                   
                    
                    if(CompareDate(obj1,obj2,"1"))
                    {
                         if(CompareDate(obj2,obj3,"2"))
                            return true;
                         else
                            return false;
                    }
                    else
                        return false;
                }               
                else
                    return false;
            }
            else
                return false;
        }
        
        function CompareDate(obj1,obj2,type)
        { 
                var myfocus ="";
                var ErrorMsg = "";
               
                var DateElement1 = obj1.value.split("/");
                var DateElement2 = obj2.value.split("/");
                var flag = false;
                
                
                
               if(DateElement1[0] > DateElement2[0])
                {   flag = true;
                    //ErrorMsg=ErrorMsg + "'डेलिभरी पाएको मिति'   'डेलिभरी गरेको मिति'  भन्दा  बढी हुनुपर्छ।\n";
                                
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
                        //ErrorMsg=ErrorMsg + "'डेलिभरी पाएको मिति'   'डेलिभरी गरेको मिति'  भन्दा  बढी हुनुपर्छ।\n";
                                
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
        
               
            
                //if(ErrorMsg != "")
                if(flag)
                {   
                    if(type == "1")
                        ErrorMsg=ErrorMsg + "'डेलिभरी मिति'   'प्रमाणीकरण मिति'  भन्दा  बढी हुनुपर्छ।\n";
                    else if(type == "2")
                        ErrorMsg=ErrorMsg + "'डेलिभरी पाएको मिति'   'डेलिभरी गरेको मिति'  भन्दा  बढी हुनुपर्छ।\n";
                        
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
     <asp:UpdatePanel id="updDeliveryOrder" runat="server">
     <contenttemplate>
        <asp:Panel ID="pnlDeliveryOrder" runat="server" Width ="100%" >
            &nbsp;
            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AutoComplete="False"
                ClearMaskOnLostFocus="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtDeliveryDate_RDT">
            </ajaxToolkit:MaskedEditExtender>
            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" AutoComplete="False"
                ClearMaskOnLostFocus="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtReceivedDate_RDT">
            </ajaxToolkit:MaskedEditExtender>
    <TABLE style="PADDING-LEFT: 20px; WIDTH:720px" cellSpacing=2 cellPadding=0 border=0>
    <TR><TD colspan="2" style="height: 19px"><asp:Label id="lblHeader" runat="server" Text="डेलिभरी विवरण" SkinID="Unicodelbl" Font-Underline="True" Font-Bold="True" Font-Names="Verdana"></asp:Label></TD></TR>
    <TR><TD style="width: 186px">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
        &nbsp;
    </TD></TR>
    <TR><TD style="HEIGHT: 21px; width: 186px;">
        <asp:Label ID="lblOrder" runat="server" SkinID="Unicodelbl" Text="अर्डर नं." Width="53px"></asp:Label></TD><TD style="HEIGHT: 21px; width: 226px;">
           <asp:TextBox id="txtOrderNo" runat="server" ToolTip="अर्डर नं." ReadOnly="True"></asp:TextBox></TD><TD style="HEIGHT: 21px; width: 297px;">
               &nbsp;&nbsp;
               <asp:Label ID="Label5" runat="server" SkinID="Unicodelbl" Text="प्रमाणीकरण मिति" Width="125px"></asp:Label></TD><TD style="HEIGHT: 21px; width: 202px;">
               <asp:TextBox ID="txtApproveDate" runat="server" ReadOnly="True" ToolTip="प्रमाणीकरण मिति" Width="80px"></asp:TextBox></TD></TR>
           <TR><TD style="HEIGHT: 21px; width: 186px;"><asp:Label id="lblDeliveryPerson" runat="server" Width="126px" Text="डेलिभरी गर्ने व्यक्ति" SkinID="Unicodelbl"></asp:Label><asp:Label
                   ID="Label1" runat="server" CssClass="simplelabel" EnableTheming="False" ForeColor="Red"
                   Text="*"></asp:Label></TD><TD style="HEIGHT: 21px; width: 226px;">
           <asp:TextBox id="txtDeliveryPer_delv" runat="server" ToolTip="डेलिभरी गर्ने व्यक्ति" MaxLength="15"></asp:TextBox></TD><TD style="HEIGHT: 21px; width: 297px;">
               &nbsp; &nbsp;<asp:Label id="lblDeliveryDate" runat="server" Text="डेलिभरी मिति" SkinID="Unicodelbl" Width="93px"></asp:Label><asp:Label
                   ID="Label3" runat="server" CssClass="simplelabel" EnableTheming="False" ForeColor="Red"
                   Text="*"></asp:Label></TD><TD style="HEIGHT: 21px; width: 202px;">
           <asp:TextBox ID="txtDeliveryDate_RDT" runat="server" MaxLength="10" ToolTip="डेलिभरी मिति" Width="80px"></asp:TextBox></TD></TR><TR><TD style="HEIGHT: 21px; width: 186px;"><asp:Label id="lblInvoiceNo" runat="server" Width="82px" Text="इनभोइस् नं." SkinID="Unicodelbl"></asp:Label><asp:Label
                   ID="Label2" runat="server" CssClass="simplelabel" EnableTheming="False" ForeColor="Red"
                   Text="*"></asp:Label></TD><TD style="HEIGHT: 21px; width: 226px;">
               <asp:TextBox ID="txtInvoiceNo_delv" runat="server" MaxLength="8" ToolTip="इनभोइस् नं."></asp:TextBox></TD><TD style="HEIGHT: 21px; width: 297px;">
                   &nbsp;&nbsp;
                   <asp:Label id="lblReceivedDate" runat="server" Text="पाएको मिति" SkinID="Unicodelbl" Width="82px"></asp:Label><asp:Label
                       ID="Label4" runat="server" CssClass="simplelabel" EnableTheming="False" ForeColor="Red"
                       Text="*"></asp:Label></TD><TD style="HEIGHT: 21px; width: 202px;">
               <asp:TextBox ID="txtReceivedDate_RDT" runat="server" MaxLength="10" ToolTip="पाएको मिति" Width="80px"></asp:TextBox></TD></TR>
     <TR><TD style="width: 186px; height: 19px">
         &nbsp;</TD><TD style="height: 19px; width: 226px;">
         &nbsp;</TD><TD style="width: 297px; height: 19px;">
         &nbsp;</TD><TD style="width: 202px; height: 19px;">
         &nbsp;</TD></TR>
     <TR><TD style="HEIGHT: 25px; width: 186px;">
         &nbsp;</TD><TD style="HEIGHT: 25px; width: 226px;">
         &nbsp;</TD><TD style="HEIGHT: 25px; width: 297px; padding-left: 140px;" colspan="2">
         &nbsp;<asp:Button ID="btnSubmit" runat="server" Text="Submit" SkinID="Normal" OnClick="btnSubmit_Click"  OnClientClick="javascript: return DeliveryValidate();" ToolTip="Submit"  />
         <asp:Button ID="btnCancel" runat="server" Text="Cancel" SkinID="Cancel" OnClick="btnCancel_Click" ToolTip="Cancel"  /></TD></TR>
   </TABLE>
   </asp:Panel>
   </contenttemplate>
   </asp:UpdatePanel>
   
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