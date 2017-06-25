<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MeetingVenueManagement_Popup.aspx.cs" Inherits="MODULES_OAS_Forms_MeetingVenueManagement_Popup" Title="OAS|Meeting Venue Management" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
</head>
 <link href="../../COMMON/CSS/StyleSheetSecurity.css" rel="stylesheet" type="text/css" />
<script language="javascript" src="../../COMMON/JS/Validation.js" type="text/javascript"></script>
<script language="javascript" src="../../COMMON/JS/DateValidator.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">

        function GetEnglishValue(val)
        {    
             var  englishVal = "";
             englishVal = val;
             
             for(var i = 0;i< val.length; i++)
             {
                 englishVal = englishVal.replace("०","0");
                 englishVal = englishVal.replace( "१","1");
                 englishVal = englishVal.replace("२","2");
                 englishVal = englishVal.replace("३","3");
                 englishVal = englishVal.replace("४","4");
                 englishVal = englishVal.replace("५", "5");
                 englishVal = englishVal.replace("६", "6");
                 englishVal = englishVal.replace("७", "7");
                 englishVal = englishVal.replace("८", "8");
                 englishVal = englishVal.replace("९", "9");
             
             }
            
             return englishVal;
        }
        
        function CheckTimeRange()
        {   
             if(validate())
             {
                 var ErrMsg = "";
                 var flag = true;
                 var objHr1 = document.getElementById('<%=this.drpHr1_rqd.ClientID%>');  
                 var objHr2 = document.getElementById('<%=this.drpHr2_rqd.ClientID%>');  
                 var objMin1 = document.getElementById('<%=this.drpMin1_rqd.ClientID%>');  
                 var objMin2 = document.getElementById('<%=this.drpMin2_rqd.ClientID%>');
                                 
                 var hr1 = GetEnglishValue(objHr1.value);
                 var hr2 = GetEnglishValue(objHr2.value);
                 var min1 = GetEnglishValue(objMin1.value);
                 var min2 = GetEnglishValue(objMin2.value);

                 if(hr1 > hr2)
                 {   
                     ErrMsg ="Booking Start Time Should be less than End Time";
                     myfocus = objHr1;
                     flag = false;
                 }
                 else if (hr1 == hr2)
                 { 
                    if(min1 > min2)
                    {    ErrMsg = " Start Time Minute should be less than End Time ";
                         myfocus = objMin1;
                         flag = false;
                    }
                    else  if(min1 == min2)
                    {    ErrMsg = "Booking Start Time Minute should be less than End Time ";
                         myfocus = objMin1;
                         flag = false;
                    }
                 }
                 
                 
                if (ErrMsg == "")
                {
                    if(validateDate())
                    {
                       if (checkGrid())
                            return true;
                        else
                            return false;
                    }
                    else
                        return false;
                }
                else 
                {
                    alert("सर्वप्रथम निम्न त्रुटिहरू सच्याउनुहोस।\n\n" + ErrMsg);
                     myfocus.focus();
                    return false;
                }
            }
            else
                return false;
            
        }
        
        function checkGrid()
        {
            try
            {    var myfocus ="";
                 var grid = document.getElementById("<%= grdResources.ClientID %>");
                                
                 var grdRowCount = grid.rows.length  ;        
                 //alert("len : " + grdRowCount);
                 for(var x = 1;x < grdRowCount; x++)
                 {    
                   var v=  grid.rows[x].cells[0].children[0];
                   var qty = grid.rows[x].cells[2].children[0];
                   
                   if(v.checked)
                   { 
                     if(qty.value < 0)
                     {
                        if(myfocus == "")
                            myfocus = qty;
                     }
                   }
                   
                 }
                 
                if (myfocus == "")
                {
                   return true;
                }
                else 
                {
                    alert("सर्वप्रथम निम्न त्रुटिहरू सच्याउनुहोस।\n\n छानिएको सामानहरुको परिणाम राख्न अनिवार्य छ ।");
                    myfocus.focus();
                    return false;
                }
            }
            catch(err)
            {
                alert(err);
            }
        }
        
        function Close()
        {
             var objFlag = document.getElementById('<%=this.hdnFlag.ClientID%>'); 
             
             if(objFlag.value == "Y")
             {
                //alert("yes");
                self.close();
             }
             else
             {
                alert("no");
             }    
             
        } 
</script>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style=" width:100%;height:auto">
        
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
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click" OnClientClick = "javascript:Close();"
            Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    &nbsp;
    <!-- -->
    
   
    
 <table width ="100%" cellpadding ="0"  cellspacing ="0" border ="0" style ="border-color:Red">
       <tr>
            <td style="padding-left: 70px;" valign="bottom">
                &nbsp;<asp:Label ID="lblHeading" runat="server" Font-Size="Large" Font-Underline="True"
                    SkinID="Unicodelbl" Text="स्थल बुकिङ्ग"></asp:Label>
             </td>
       </tr>
       <tr>
            <td align ="left"  style="height: 572px" >
           
                <asp:UpdatePanel id="venueBooking" runat="server">
                <contenttemplate>
                 <asp:HiddenField ID="hdnFlag" runat="server" />
<TABLE style="BORDER-LEFT-COLOR: red; BORDER-BOTTOM-COLOR: red; BORDER-TOP-COLOR: red; BORDER-RIGHT-COLOR: red" cellSpacing=0 cellPadding=0 width="80%" border=0><TBODY><TR><TD style="PADDING-LEFT: 70px" vAlign=top><asp:Label id="lblOrganisation" runat="server" Text="कार्यलय" SkinID="Unicodelbl"></asp:Label> </TD><TD class="tblTDLeft" colSpan=3><asp:DropDownList id="ddlOrganisation_rqd" runat="server" Width="507px" ToolTip="कार्यलय" AutoPostBack="True" OnSelectedIndexChanged="ddlOrganisation_rqd_SelectedIndexChanged"></asp:DropDownList> </TD></TR>
                            
                            <TR><TD style="PADDING-LEFT: 70px; HEIGHT: 22px" vAlign=top><asp:Label id="lblVenue" runat="server" Text="स्थल" SkinID="Unicodelbl"></asp:Label> </TD><TD style="WIDTH: 30%" class="tblTDLeft"><asp:DropDownList id="ddlVenue_rqd" runat="server" Width="148px" ToolTip="स्थल" Enabled="False"></asp:DropDownList> </TD><TD style="WIDTH: 10%; HEIGHT: 22px" class="tblTDRight" vAlign=top><asp:Label id="lblBookedBy" runat="server" Width="126px" Text="बुकिङ्ग गर्ने व्यक्ति" SkinID="Unicodelbl"></asp:Label> </TD><TD class="tblTDLeft"><asp:DropDownList id="ddlBookingPerson_rqd" runat="server" Width="145px" ToolTip="बुकिङ्ग गर्ने व्यक्ति" Enabled="False"></asp:DropDownList> </TD></TR><TR><TD style="PADDING-LEFT: 70px; HEIGHT: 30px" vAlign=top><asp:Label id="lblStartTime" runat="server" Text="शुरु हुने समय" SkinID="Unicodelbl"></asp:Label> </TD><TD style="HEIGHT: 30px" class="tblTDLeft"><asp:DropDownList id="drpHr1_rqd" runat="server" Width="55px" ToolTip="घण्टा">
                                <asp:ListItem Value="0">घण्टा</asp:ListItem>
                                <asp:ListItem Value="01">०१</asp:ListItem>
                                <asp:ListItem Value="02">०२</asp:ListItem>
                                <asp:ListItem Value="03">०३</asp:ListItem>
                                <asp:ListItem Value="04">०४</asp:ListItem>
                                <asp:ListItem Value="05">०५</asp:ListItem>
                                <asp:ListItem Value="06">०६</asp:ListItem>
                                <asp:ListItem Value="07">०७</asp:ListItem>
                                <asp:ListItem Value="08">०८</asp:ListItem>
                                <asp:ListItem Value="09">०९</asp:ListItem>
                                <asp:ListItem Value="10">१०</asp:ListItem>
                                <asp:ListItem Value="11">११</asp:ListItem>
                                <asp:ListItem Value="12">१२</asp:ListItem>
                                <asp:ListItem Value="13">१३</asp:ListItem>
                                <asp:ListItem Value="14">१४</asp:ListItem>
                                <asp:ListItem Value="15">१५</asp:ListItem>
                                <asp:ListItem Value="16">१६</asp:ListItem>
                                <asp:ListItem Value="17">१७</asp:ListItem>
                                <asp:ListItem Value="18">१८</asp:ListItem>
                                <asp:ListItem Value="19">१९</asp:ListItem>
                                <asp:ListItem Value="20">२०</asp:ListItem>
                                <asp:ListItem Value="21">२१</asp:ListItem>
                                <asp:ListItem Value="22">२२</asp:ListItem>
                                <asp:ListItem Value="23">२३</asp:ListItem>
                            </asp:DropDownList> &nbsp;&nbsp; <asp:Label id="Label7" runat="server" Width="6px" Text="                   :" SkinID="Unicodelbl" Font-Bold="True"></asp:Label>&nbsp; &nbsp;<asp:DropDownList id="drpMin1_rqd" runat="server" Width="59px" ToolTip="मिनेट">
                                <asp:ListItem Value="0">मिनेट</asp:ListItem>
                                <asp:ListItem Value="00">००</asp:ListItem>
                                <asp:ListItem Value="05">०५</asp:ListItem>
                                <asp:ListItem Value="10">१०</asp:ListItem>
                                <asp:ListItem Value="15">१५</asp:ListItem>
                                <asp:ListItem Value="20">२०</asp:ListItem>
                                <asp:ListItem Value="25">२५</asp:ListItem>
                                <asp:ListItem Value="30">३०</asp:ListItem>
                                <asp:ListItem Value="35">३५</asp:ListItem>
                                <asp:ListItem Value="40">४०</asp:ListItem>
                                <asp:ListItem Value="45">४५</asp:ListItem>
                                <asp:ListItem Value="50">५०</asp:ListItem>
                                <asp:ListItem Value="55">५५</asp:ListItem>
                            </asp:DropDownList> </TD><TD style="WIDTH: 10%; HEIGHT: 30px" class="tblTDRight" vAlign=top><asp:Label id="lblEndTime" runat="server" Width="125px" Text="अन्त्य हुने समय" SkinID="Unicodelbl"></asp:Label> </TD><TD style="WIDTH: 30%; HEIGHT: 30px" class="tblTDLeft"><asp:DropDownList id="drpHr2_rqd" runat="server" Width="55px" ToolTip="घण्टा">
                           <asp:ListItem Value="0">घण्टा</asp:ListItem>
                                <asp:ListItem Value="01">०१</asp:ListItem>
                                <asp:ListItem Value="02">०२</asp:ListItem>
                                <asp:ListItem Value="03">०३</asp:ListItem>
                                <asp:ListItem Value="04">०४</asp:ListItem>
                                <asp:ListItem Value="05">०५</asp:ListItem>
                                <asp:ListItem Value="06">०६</asp:ListItem>
                                <asp:ListItem Value="07">०७</asp:ListItem>
                                <asp:ListItem Value="08">०८</asp:ListItem>
                                <asp:ListItem Value="09">०९</asp:ListItem>
                                <asp:ListItem Value="10">१०</asp:ListItem>
                                <asp:ListItem Value="11">११</asp:ListItem>
                                <asp:ListItem Value="12">१२</asp:ListItem>
                                <asp:ListItem Value="13">१३</asp:ListItem>
                                <asp:ListItem Value="14">१४</asp:ListItem>
                                <asp:ListItem Value="15">१५</asp:ListItem>
                                <asp:ListItem Value="16">१६</asp:ListItem>
                                <asp:ListItem Value="17">१७</asp:ListItem>
                                <asp:ListItem Value="18">१८</asp:ListItem>
                                <asp:ListItem Value="19">१९</asp:ListItem>
                                <asp:ListItem Value="20">२०</asp:ListItem>
                                <asp:ListItem Value="21">२१</asp:ListItem>
                                <asp:ListItem Value="22">२२</asp:ListItem>
                                <asp:ListItem Value="23">२३</asp:ListItem>
                        </asp:DropDownList> &nbsp;&nbsp; <asp:Label id="Label11" runat="server" Width="6px" Text="                   :" SkinID="Unicodelbl" Font-Bold="True"></asp:Label>&nbsp; &nbsp; <asp:DropDownList id="drpMin2_rqd" runat="server" Width="53px" ToolTip="मिनेट">
                                <asp:ListItem Value="0">मिनेट</asp:ListItem>
                                <asp:ListItem Value="00">००</asp:ListItem>
                                <asp:ListItem Value="05">०५</asp:ListItem>
                                <asp:ListItem Value="10">१०</asp:ListItem>
                                <asp:ListItem Value="15">१५</asp:ListItem>
                                <asp:ListItem Value="20">२०</asp:ListItem>
                                <asp:ListItem Value="25">२५</asp:ListItem>
                                <asp:ListItem Value="30">३०</asp:ListItem>
                                <asp:ListItem Value="35">३५</asp:ListItem>
                                <asp:ListItem Value="40">४०</asp:ListItem>
                                <asp:ListItem Value="45">४५</asp:ListItem>
                                <asp:ListItem Value="50">५०</asp:ListItem>
                                <asp:ListItem Value="55">५५</asp:ListItem>
                            </asp:DropDownList></TD></TR><TR><TD style="PADDING-LEFT: 70px; HEIGHT: 22px" vAlign=top><asp:Label id="lblPurpose" runat="server" Text="बुकिङ्गको विवरण" SkinID="Unicodelbl"></asp:Label>&nbsp;</TD><TD style="WIDTH: 30%" class="tblTDLeft" colSpan=3><asp:TextBox id="txtBookingPurpose" runat="server" Width="501px" MaxLength="49"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 62px; HEIGHT: 2px"></TD></TR><TR><TD style="PADDING-LEFT: 70px; HEIGHT: 21px" vAlign=top><asp:Label id="lblResources" runat="server" Text="सामान" SkinID="Unicodelbl"></asp:Label> </TD><TD style="WIDTH: 87px; HEIGHT: 21px" class="tblTDLeft" vAlign=bottom colSpan=3><BR /><DIV style="OVERFLOW: auto; WIDTH: 257px; HEIGHT: 284px" border="0"><asp:GridView id="grdResources" runat="server" Width="240px" Font-Size="Smaller" Font-Names="Verdana" ForeColor="#333333" EnableTheming="False" AutoGenerateColumns="False" CellPadding="4" GridLines="None" OnRowCreated="grdResources_RowCreated">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemStyle Width="5%" />
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkResource" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ResourceID" HeaderText="ResourcesID" >
                                        <ItemStyle Width="2%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ResourceName" HeaderText="सामानको नाम" >
                                        <ItemStyle Width="45%" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="परिमाण">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlQuantity" runat="server" Width="106px">
                                                <asp:ListItem Value="-1">Select</asp:ListItem>
                                                <asp:ListItem>1</asp:ListItem>
                                                <asp:ListItem>2</asp:ListItem>
                                                <asp:ListItem>3</asp:ListItem>
                                                <asp:ListItem>4</asp:ListItem>
                                                <asp:ListItem>5</asp:ListItem>
                                                <asp:ListItem>6</asp:ListItem>
                                                <asp:ListItem>7</asp:ListItem>
                                                <asp:ListItem>8</asp:ListItem>
                                                <asp:ListItem>9</asp:ListItem>
                                                <asp:ListItem>10</asp:ListItem>
                                                <asp:ListItem>11</asp:ListItem>
                                                <asp:ListItem>12</asp:ListItem>
                                                <asp:ListItem>13</asp:ListItem>
                                                <asp:ListItem>14</asp:ListItem>
                                                <asp:ListItem>15</asp:ListItem>
                                                <asp:ListItem>16</asp:ListItem>
                                                <asp:ListItem>17</asp:ListItem>
                                                <asp:ListItem>18</asp:ListItem>
                                                <asp:ListItem>19</asp:ListItem>
                                                <asp:ListItem>20</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <EditRowStyle BackColor="#999999" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            </asp:GridView> &nbsp; </DIV></TD></TR><TR><TD style="WIDTH: 62px">&nbsp;</TD></TR><TR><TD style="WIDTH: 62px; HEIGHT: 19px">&nbsp;</TD><TD style="PADDING-RIGHT: 70px; HEIGHT: 19px" align=right colSpan=3><asp:Button id="btnSubmit" onclick="btnSubmit_Click" runat="server" Text="Submit" SkinID="Normal" OnClientClick="return CheckTimeRange();"></asp:Button> <asp:Button id="btnCancel" onclick="btnCancel_Click" runat="server" Text="Cancel" SkinID="Cancel"></asp:Button></TD></TR></TBODY></TABLE>
</contenttemplate>
                    <triggers>
<asp:AsyncPostBackTrigger ControlID="btnSubmit" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="ddlOrganisation_rqd" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="OkButton" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
                </asp:UpdatePanel>
           <%--    </fieldset>--%>
                </td>
        </tr>
        <tr>
            <td style ="height:50px;">
                &nbsp;
            </td>
       </tr>
  </table>

</div>


<asp:Button ID="hiddenTargetControlForBookedVenueModalPopup" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="programmaticBookedVenueModalPopup" runat="server"
        BackgroundCssClass="modalBackground" BehaviorID="programmaticBookedVenueModalPopupBehavior"
        DropShadow="false" PopupControlID="programmaticBookedVenuePopup" PopupDragHandleControlID="programmaticBookedVenuePopup"
        RepositionMode="None"  TargetControlID="hiddenTargetControlForBookedVenueModalPopup">
      
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="programmaticBookedVenuePopup" runat="server" BackColor="white"  Style="display: none; padding: 10px">
        <br />
        <asp:UpdatePanel id="updVenueDetails" runat="server">
                <ContentTemplate>
<P style="WIDTH: 650px"><asp:ImageButton style="PADDING-RIGHT: 13px" id="imbBtnClose2" onclick="imbBtnClose2_Click" runat="server" Width="17px" ImageUrl="~/MODULES/OAS/Images/btn_cancel.gif" align="right"></asp:ImageButton> </P><asp:Panel id="programmaticBookedVenuePopupDragHandle" runat="Server" Width="660px" Height="259px"><FIELDSET style="WIDTH: 633px"><LEGEND><asp:Label id="lblTitle" runat="server" Text="स्थान तल दिएको समयमा बुकिङ्ग भइक्यो , त्यसैले अर्को समय छान्नुहोस्" EnableTheming="False"></asp:Label> </LEGEND><DIV style="OVERFLOW: auto; WIDTH: 623px; HEIGHT: 186px" border="0"><asp:GridView id="grdBooked" runat="server" Font-Size="Smaller" Font-Names="Verdana" ForeColor="#333333" EnableTheming="True" AutoGenerateColumns="False" CellPadding="4" GridLines="None">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:TemplateField HeaderText="सि.नं.">
<ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
<ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>.
                                           
                                                                            
                                
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="OrgName" HeaderText="कार्यलय"></asp:BoundField>
<asp:BoundField DataField="VenueName" HeaderText="स्थन"></asp:BoundField>
<asp:BoundField DataField="BookerName" HeaderText="बुकिङ्ग गर्नेको नाम"></asp:BoundField>
<asp:BoundField DataField="BookingDate" HeaderText="बुकिङ्ग मिति"></asp:BoundField>
<asp:BoundField DataField="StartTime" HeaderText="शुरू समय"></asp:BoundField>
<asp:BoundField DataField="EndTime" HeaderText="अन्त्य समय"></asp:BoundField>
<asp:BoundField DataField="Purpose" HeaderText="विषय"></asp:BoundField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> &nbsp; </DIV></FIELDSET> <BR /></asp:Panel> 
</ContentTemplate>
     </asp:UpdatePanel>
    </asp:Panel>

    </form>
</body>
</html>
