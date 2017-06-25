<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MeetingVenueBookingSearch_Popup.aspx.cs" Inherits="MODULES_OAS_Forms_MeetingVenueBookingSearch_Popup" Title="OAS|Meeting Booked Venue Search" %>
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
                 var objHr1 = document.getElementById('<%=this.ddlHr1_rqd.ClientID%>');  
                 var objHr2 = document.getElementById('<%=this.ddlHr2_rqd.ClientID%>');  
                 var objMin1 = document.getElementById('<%=this.ddlMin1_rqd.ClientID%>');  
                 var objMin2 = document.getElementById('<%=this.ddlMin2_rqd.ClientID%>');
                                 
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
    </script>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <!-- NB:: For Popup error status -->
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
     <!-- End Popup error status -->
     
     <table width ="100%" cellpadding ="0" cellspacing ="0" border ="0">
        <tr>
            <td  style ="padding-left:30px;">
             <asp:UpdatePanel id="updBookedVenueSearch" runat="server">
                  <contenttemplate>
<TABLE width=660><TBODY><TR><TD style="HEIGHT: 21px" colSpan=2>&nbsp;<asp:Label id="lblHeading" runat="server" Text="Booked Venue Search / Update" SkinID="Unicodelbl" Font-Size="Large" Font-Underline="True"></asp:Label></TD></TR><TR><TD></TD></TR><TR><TD></TD></TR><TR><TD></TD></TR><TR><TD width=140><asp:Label id="Label1" runat="server" Text="कार्यालय" SkinID="Unicodelbl"></asp:Label></TD><TD colSpan=3><asp:DropDownList id="ddlOrganization" runat="server" Width="208px" SkinID="Unicodeddl" ToolTip="कार्यलय" AutoPostBack="True" OnSelectedIndexChanged="ddlOrganization_SelectedIndexChanged"></asp:DropDownList> </TD></TR><TR><TD style="HEIGHT: 21px" width=140><asp:Label id="Label4" runat="server" Text="कर्मचारीको नाम" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 221px; HEIGHT: 21px"><asp:DropDownList id="ddlPerson" runat="server" Width="208px" SkinID="Unicodeddl" ToolTip="कर्मचारीको नाम" Enabled="False"></asp:DropDownList></TD><TD style="PADDING-LEFT: 40px; WIDTH: 40px; HEIGHT: 21px"><asp:Label id="Label71" runat="server" Text="स्थान" SkinID="Unicodelbl"></asp:Label></TD><TD style="HEIGHT: 21px" width=200><asp:DropDownList id="ddlVenue" runat="server" Width="200px" SkinID="Unicodeddl" ToolTip="स्थान" Enabled="False"></asp:DropDownList> </TD></TR><TR><TD width=140><asp:Label id="Label2" runat="server" Text="बुकिंङ्ग मिति" SkinID="Unicodelbl"></asp:Label></TD><TD><asp:TextBox id="txtBookingDate" runat="server" Width="201px" ToolTip="बुकिङ्ग मिति"></asp:TextBox></TD><TD style="PADDING-LEFT: 40px; WIDTH: 40px; HEIGHT: 21px" TD><asp:Label id="lblBookingID" runat="server" Width="74px" Text="बुकिङ्ग नं." SkinID="Unicodelbl"></asp:Label></TD><TD><asp:TextBox id="txtBookingID" runat="server" Width="193px" ToolTip="बुकिङ्ग नं."></asp:TextBox></TD></TR><TR><TD width=140></TD><TD width=200></TD><TD style="PADDING-LEFT: 40px; WIDTH: 120px"></TD><TD align=right width=200>&nbsp;&nbsp; <asp:Button id="btnSearch" onclick="btnSearch_Click" runat="server" Text="Search" SkinID="Normal"></asp:Button> <asp:Button id="btnCancel" onclick="btnCancel_Click" runat="server" Text="Cancel" SkinID="Cancel"></asp:Button></TD></TR></TBODY></TABLE><ajaxToolkit:MaskedEditExtender id="MaskedEditExtender1" runat="server" TargetControlID="txtBookingDate" MaskType="Date" Mask="9999/99/99" AutoComplete="False"></ajaxToolkit:MaskedEditExtender> <ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender2" runat="server" TargetControlID="txtBookingID" FilterType="Numbers"></ajaxToolkit:FilteredTextBoxExtender> 
</contenttemplate>
                 <triggers>
<asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="ddlOrganization" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="imbBtnClose2" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="OkButton" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
              </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <hr />
            </td>
        </tr>
        <tr>
            <td>
                
                <table width="100%">
                    <tr>
                       <td style ="padding-left:30px;">
                             <asp:UpdatePanel id="updBookedVenue" runat="server">
                               <contenttemplate>
<asp:Label id="lblSearchCount" runat="server" SkinID="Unicodelbl"></asp:Label><BR /><BR /><DIV style="OVERFLOW: auto; WIDTH: 100%; HEIGHT: 250px" border="0"><asp:GridView id="grdBookedVenue" runat="server" ForeColor="#333333" GridLines="None" CellPadding="4" OnRowDataBound="grdBookedVenue_RowDataBound" AutoGenerateColumns="False" OnSelectedIndexChanging="grdBookedVenue_SelectedIndexChanging">
                                <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
                                <Columns>
                                <asp:TemplateField HeaderText="सि नं.">
                                <ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

                                <HeaderStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>.
                                                                           
                                                                                                            
                                                                
                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="OrgID"></asp:BoundField>
                                <asp:BoundField DataField="VenueID"></asp:BoundField>
                                <asp:BoundField DataField="OrgName" HeaderText="कार्यलयको नाम">
                                <ItemStyle Width="23%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="VenueName" HeaderText="स्थलको नाम">
                                <ItemStyle Width="23%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="BookedByName" HeaderText="बुकिङ्ग गर्नेको नाम">
                                <ItemStyle Width="25%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="BookingDate" HeaderText="बुकिङ्ग मिति">
                                <ItemStyle Width="15%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="BookingID" HeaderText="बुकिङ्ग नं.">
                                <ItemStyle Width="8%"></ItemStyle>
                                </asp:BoundField>
                                <asp:CommandField ShowSelectButton="True"></asp:CommandField>
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
<asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="ddlOrganization" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="imbBtnClose2" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnCancel1" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="OkButton" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
                             </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
   </table>
      
   <asp:Button ID="hiddenTargetControlForBookedVenueModalPopup" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="programmaticBookedVenueModalPopup" runat="server"
        BackgroundCssClass="modalBackground" BehaviorID="programmaticBookedVenueModalPopupBehavior"
        DropShadow="false" PopupControlID="programmaticBookedVenuePopup" PopupDragHandleControlID="programmaticBookedVenuePopup"
        RepositionMode="None"  TargetControlID="hiddenTargetControlForBookedVenueModalPopup">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="programmaticBookedVenuePopup" runat="server" BackColor="white" Height="670px" Style="display: none; padding: 10px">
        <br />
        <asp:UpdatePanel id="updVenueDetails" runat="server">
                <ContentTemplate>
<BR /><BR /><P style="WIDTH: 670px"><asp:ImageButton style="PADDING-RIGHT: 13px" id="imbBtnClose2" onclick="imbBtnClose2_Click" runat="server" ImageUrl="~/MODULES/OAS/Images/btn_cancel.gif" align="right"></asp:ImageButton> </P><asp:Panel id="programmaticBookedVenuePopupDragHandle" runat="Server"><FIELDSET><LEGEND><asp:Label id="Label6" runat="server" Text="बुकिङ्ग गरिएको स्थलको विवरण" SkinID="Unicodelbl"></asp:Label> </LEGEND><TABLE style="WIDTH: 665px"><TBODY><TR><TD style="WIDTH: 162px">&nbsp;</TD></TR><TR><TD style="WIDTH: 162px"><asp:Label id="lblOrganisation" runat="server" Text="कार्यालय" SkinID="Unicodelbl"></asp:Label></TD><TD colSpan=3><asp:DropDownList id="ddlUpdOrganization_rqd" runat="server" Width="233px" Enabled="False"></asp:DropDownList> </TD></TR><TR><TD style="WIDTH: 162px"><asp:Label id="Label5" runat="server" Width="111px" Text="कर्मचारीको नाम" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 572px"><asp:DropDownList id="ddlUpdPerson_rqd" runat="server" Width="147px" Enabled="False"></asp:DropDownList></TD><TD style="WIDTH: 90px"><asp:Label id="Label8" runat="server" Text="स्थान" SkinID="Unicodelbl"></asp:Label> </TD><TD style="WIDTH: 243px"><asp:DropDownList id="ddlUpdVenue_rqd" runat="server" Width="147px"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 162px"><asp:Label id="Label3" runat="server" Text="बुकिंङ्ग मिति" SkinID="Unicodelbl"></asp:Label></TD><TD><asp:TextBox id="txtUpdBookingDate_RDT" runat="server" Width="141px"></asp:TextBox> </TD><TD><asp:Label id="Label12" runat="server" Text="बुकिङ्ग नं." SkinID="Unicodelbl"></asp:Label></TD><TD><asp:TextBox id="txtUpdBookingNo_rqd" runat="server" Width="140px" ReadOnly="True"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 162px; HEIGHT: 24px"><asp:Label id="Label9" runat="server" Text="शुरु हुने समय" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 572px; HEIGHT: 24px"><asp:DropDownList id="ddlHr1_rqd" runat="server" Width="55px" ToolTip="घण्टा"><asp:ListItem Value="0">घण्टा</asp:ListItem>
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
</asp:DropDownList> &nbsp;&nbsp; <asp:Label id="Label7" runat="server" Width="6px" Text="                   :" SkinID="Unicodelbl" Font-Bold="True"></asp:Label>&nbsp; &nbsp;<asp:DropDownList id="ddlMin1_rqd" runat="server" Width="59px" ToolTip="मिनेट"><asp:ListItem Value="0">मिनेट</asp:ListItem>
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
</asp:DropDownList> </TD><TD style="WIDTH: 90px; HEIGHT: 24px"><asp:Label id="Label10" runat="server" Width="120px" Text="अन्त्य हुने समय" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 243px; HEIGHT: 24px"><asp:DropDownList id="ddlHr2_rqd" runat="server" Width="55px" ToolTip="घण्टा"><asp:ListItem Value="0">घण्टा</asp:ListItem>
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
</asp:DropDownList> &nbsp;&nbsp; <asp:Label id="Label11" runat="server" Width="6px" Text="                   :" SkinID="Unicodelbl" Font-Bold="True"></asp:Label>&nbsp; &nbsp; <asp:DropDownList id="ddlMin2_rqd" runat="server" Width="53px" ToolTip="मिनेट"><asp:ListItem Value="0">मिनेट</asp:ListItem>
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
</asp:DropDownList></TD></TR><TR><TD style="WIDTH: 162px"><asp:Label id="Label14" runat="server" Width="124px" Text="बुकिङ्गको विवरण" SkinID="Unicodelbl"></asp:Label></TD><TD colSpan=3><asp:TextBox id="txtUpdPurpose" runat="server" Width="501px" MaxLength="49"></asp:TextBox></TD></TR><TR><TD style="HEIGHT: 2px"></TD></TR><TR><TD vAlign=top><BR /><asp:Label id="Label13" runat="server" Text="सामान" SkinID="Unicodelbl"></asp:Label></TD><TD colSpan=3><BR /><DIV style="OVERFLOW: auto; WIDTH: 257px; HEIGHT: 285px" border="0"><asp:GridView id="grdResources" runat="server" Width="240px" Font-Size="Smaller" Font-Names="Verdana" ForeColor="#333333" EnableTheming="False" AutoGenerateColumns="False" CellPadding="4" GridLines="None" OnRowCreated="grdResources_RowCreated">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:TemplateField>
<ItemStyle Width="5%"></ItemStyle>
<ItemTemplate>
<asp:CheckBox id="chkResource" runat="server"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="ResourceID" HeaderText="ResourcesID">
<ItemStyle Width="2%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ResourceName" HeaderText="सामानको नाम">
<ItemStyle Width="45%"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="परिमाण"><ItemTemplate>
<asp:DropDownList id="ddlQuantity" runat="server" Width="106px">
                                                <asp:ListItem Value="-1">छान्नुहोस्</asp:ListItem>
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
<asp:BoundField DataField="Action" HeaderText="Action"></asp:BoundField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> &nbsp; </DIV></TD></TR><TR><TD></TD><TD style="PADDING-RIGHT: 10px" align=right colSpan=3>&nbsp;<asp:Button id="btnUpdate" onclick="btnUpdate_Click" runat="server" Text="Update" SkinID="Normal" OnClientClick="return CheckTimeRange();"></asp:Button> <asp:Button id="btnDelete" onclick="btnDelete_Click" runat="server" Text="Delete" SkinID="Normal"></asp:Button> <asp:Button id="btnCancel1" onclick="btnCancel1_Click" runat="server" Text="Cancel" SkinID="Cancel"></asp:Button></TD></TR></TBODY></TABLE><ajaxToolkit:MaskedEditExtender id="MaskedEditExtender2" runat="server" TargetControlID="txtUpdBookingDate_RDT" AutoComplete="False" Mask="9999/99/99" MaskType="Date"></ajaxToolkit:MaskedEditExtender></FIELDSET> <BR /><BR /></asp:Panel> 
</ContentTemplate>
            <triggers>
<asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
     </asp:UpdatePanel>
    </asp:Panel>

    </div>
    </form>
</body>
</html>
