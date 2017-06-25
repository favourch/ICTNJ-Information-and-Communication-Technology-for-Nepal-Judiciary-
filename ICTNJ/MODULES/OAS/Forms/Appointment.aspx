<%@ Page AutoEventWireup="true" CodeFile="Appointment.aspx.cs" Inherits="MODULES_OAS_Forms_newCal"
    Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" Title="OAS | Appointment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <script language="javascript" src="../../COMMON/JS/Validation.js" type="text/javascript"></script>
    <script language="javascript" src="../../COMMON/JS/DateValidator.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">

    var drag=0;
    var xdif=0;
    var ydif=0;
    var initx="145px";
    var inity="147px";

    
    function chkObject (theVal)
    {
        if (document.getElementById(theVal) != null)
        {
            return true;
        }
        else
        {   alert("ERROR :: ");
            return false;
        }
    }

    function  begindrag(event)
    {
          if(drag==0)
          {    if(chkObject('dvMeeting'))
               {
                   floatingd = document.getElementById("dvMeeting");
                   
                   if(floatingd.style.left=="")
                   {
                        floatingd.style.left=initx;

                   }

                   if(floatingd.style.top=="")
                   {
                        floatingd.style.top=inity;
                   }

                   prex=floatingd.style.left.replace(/px/,"");
                   prey=floatingd.style.top.replace(/px/,"");

                  drag=1;

                  xdif=event.clientX-prex;
                  ydif=event.clientY-prey;
              
              }

         }
         else
         {
              drag=0;
         }
    }
      
    function mousepos(event)
    {
        var drag=0;
        var xdif=0;
        var ydif=0;
        var initx="145px";
        var inity="147px";
    }
    
    </script>

    <script language="javascript" type="text/javascript">
        
        
        function OnMouseOverX(cell)
        {
             
            if( cell.style.backgroundColor != "darkkhaki")
            {
                cell.style.backgroundColor = "#E8EEFA";
            }

        }
        
        function OnMouseOutX(cell)
        {
        
            if( cell.style.backgroundColor != "darkkhaki")
            {
                cell.style.backgroundColor = "white";
            } 
        
            
        }
              
        
        function GetCellIndex(Day)
        {
            if (Day >= 1 && Day <= 7)
                return Day;
            else if (Day >= 8 && Day <= 14)
                return Day - 7;
            else if (Day >= 15 && Day <= 21)
                return Day - 14;
            else if (Day >= 22 && Day <= 28)
                return Day - 21;
            else if (Day >= 29 && Day <= 35)
                return Day - 28;
            else if (Day >= 36 && Day <= 42)
                return Day - 35;

            return 0;
        }
        
        function setDate(cell)
        {
            var objEvntDetail = document.getElementById('<%=this.__EventDetail.ClientID%>');  
            
            //alert(objEvntDetail.value);
                        
            if(objEvntDetail.value != "yes" )
            {
                var day = cell.childNodes[0].innerHTML;
                var innerHtml = cell.innerHTML;
              
                var rqdCell;
                
                var rqdID = cell.id;
                
                rqdCell = rqdID.split("ctl00_ContentPlaceHolder1_TableCell")[1] - 7;
                
                var objYear = document.getElementById('<%=this.lblYear1.ClientID%>');  
                var objMonth = document.getElementById('<%=this.lblMonthText.ClientID%>'); 
                var objDay = document.getElementById('<%=this.hdnDay.ClientID%>'); 
                var objMDate = document.getElementById('<%=this.hdnMDate.ClientID%>'); 
                var objMeetingDate =document.getElementById('<%=this.txtMeetingDate_rqd.ClientID%>');
                var objDayText;
                
                objDay.value = day;
                              
                var dayCount = GetCellIndex(rqdCell);
                
                if(dayCount == 1)
                {
                    objDayText = document.getElementById('<%=this.sun.ClientID%>'); 
                }
                else if(dayCount == 2)
                {
                    objDayText = document.getElementById('<%=this.Mon.ClientID%>'); 
                }
                else if(dayCount == 3)
                {
                    objDayText = document.getElementById('<%=this.Tues.ClientID%>'); 
                }
                else if(dayCount == 4)
                {
                    objDayText = document.getElementById('<%=this.Wed.ClientID%>'); 
                }
                else if(dayCount == 5)
                {
                    objDayText = document.getElementById('<%=this.Thur.ClientID%>'); 
                }
                else if(dayCount == 6)
                {
                    objDayText = document.getElementById('<%=this.Fri.ClientID%>'); 
                }
                else if(dayCount == 7)
                {
                    objDayText = document.getElementById('<%=this.Sat.ClientID%>'); 
                }

                var year = objYear.innerHTML;
                var month = objMonth.innerHTML;
                var dayText = objDayText.innerHTML;
                                        
                objMeetingDate.value = dayText + ' , ' +  month + ' ' + day + ' , ' + year  ;
                objMDate.value = objMeetingDate.value;
                
               var objMonthVal = document.getElementById('<%=this.hdnMonth.ClientID%>'); 
               var objChkPopup = document.getElementById('<%=this.hdnChkPopup.ClientID%>'); 
                 
              if(objChkPopup.value == "Y")
               {   
                    objChkPopup.value = "";
                  
                    return 1;
               }
               else
               {
                    if(CheckDateRange(day,objMonthVal.value,year) == true)
                       return 2;
                    else
                        return 0;
                    
               }
               
               
           }

           
        }
         function CheckDateRange(nDay,nMonth,nYear)
        {    
                             
                var ErrMsg = "";
                var flag = true;
                
                var nDay = GetEnglishValue(nDay);
                var nMonth = GetEnglishValue(nMonth);
                var nYear = GetEnglishValue(nYear);
                
                var nDay = GetFormated(nDay);
                var nMonth = GetFormated(nMonth);

                 var objCurrentDate = document.getElementById('<%=this.hdnCurrentDate.ClientID%>'); 
                 var currentDate = objCurrentDate.value;
                 
                 //alert( "CurrentDate : " + objCurrentDate.value);
  
                 var val = currentDate.split("/");

                 if(val[0] > nYear)
                 { //alert("year :  " + val[0]);
                     flag = false;
                 }
                 else if (val[0] == nYear)
                 {  
                    if(val[1] > nMonth)
                    {  //alert("month :  " + val[1]);
                         flag = false;
                    }
                    else  if(val[1] == nMonth)
                    {  
                         if(val[2] > nDay)
                         {  //alert("day :  " + val[2]);
                           flag = false;
                         }
                         else
                         {
                            flag = true;
                         }
                         
                    }
                 }
                 
                if (flag == true)
                {// alert("1");
                    return true;
                }
                else 
                {
                    hideDiv();
                    
                     ErrMsg = " एपोइन्टमेन्ट बोलाउन खोजेको मिति नागिसक्यो । त्यसैले अर्को मिति छान्नुहोस् ।";
                    alert("निम्न त्रुटिहरू सच्याउनुहोस.\n\n" + ErrMsg);
                    
                    var objBtnPstBk = document.getElementById('<%=this.ImageButton1.ClientID%>');
                    objBtnPstBk.click();
                    
                    return false;
                }
                 
            
        }
        
        function CheckDateRange1(nDay,nMonth,nYear)
        {    
               // alert(" Day : " + nDay + " Month : " + nMonth + " Year : " + nYear);
                var ErrMsg = "";
                var flag = true;
                
                var nDay = GetEnglishValue(nDay);
                var nMonth = GetEnglishValue(nMonth);
                var nYear = GetEnglishValue(nYear);
                
                var nDay = GetFormated(nDay);
                var nMonth = GetFormated(nMonth);

                 var objCurrentDate = document.getElementById('<%=this.hdnCurrentDate.ClientID%>'); 
                 var currentDate = objCurrentDate.value;
                 
                 alert("currentDate : " + currentDate);
  
                 var val = currentDate.split("/");

                 if(val[0] > nYear)
                 {
                     flag = false;
                 }
                 else if (val[0] == nYear)
                 {  
                    if(flag)
                    {
                        if(val[1] > nMonth)
                        {  
                             flag = false;
                        }
                        else  if(val[1] == nMonth)
                        {  
                            if(flag)
                            {
                                 if(val[2] > nDay)
                                 { 
                                   flag = false;
                                 }
                                 else
                                 {
                                    flag = true;
                                 }
                            }
                             
                        }
                    }
                 }
                 
                if (flag == true)
                { alert("1");
                    return true;
                }
                else 
                {    alert("2");
                    hideDiv();
                    ErrMsg = " एपोइन्टमेन्ट बोलाउन खोजेको मिति नागिसक्यो । त्यसैले अर्को मिति छान्नुहोस् ।";
                    alert("निम्न त्रुटिहरू सच्याउनुहोस.\n\n" + ErrMsg);
                    
                    
                                    
                     var objBtnPstBk = document.getElementById('<%=this.ImageButton1.ClientID%>');
                     objBtnPstBk.click();
                                                                 
                     return false;
                }
                 
            
        }
        
              
        function GetFormated( value)
        {

            var value = "00" + value;
            value = value.substring(value.length - 2, value.length);

            return value;
        }
        
        function OnCellClick(cell)
        {
            try
            {
               /* var len = cell.childNodes.length; 
                if(setDate(cell))
                     setDiv(cell);
                     */
                     
               var val = setDate(cell);
               //alert(val);
               //alert(val);
               if(val == 2)
               {   setDiv(cell);
               }
            }
            catch(ex)
            {
                alert(ex);
            }
        }
        
        function setDiv(cell)
        {
                       
             objDiv = document.getElementById("dvMeeting");
             objDiv.style.width = "70%";
             objDiv.className = "loading-visible";
             objBody = document.getElementById( "bodyPage" );
             //alert(navigator.appName);
             if(navigator.appName == "Microsoft Internet Explorer")
             {
                 objBody.className = "modalBackground";
                 objBody.value = "read-only";
             }
             //objBody.ReadOnly = true;
             //$find('programmaticPersonModalPopupBehavior1').show();
      
        }
        
        function callDiv()
        {   
            //alert("call");      
             objDiv = document.getElementById("dvMeeting");
             objDiv.style.width = "70%";
             objDiv.className = "loading-visible";
             objBody = document.getElementById( "bodyPage" );
             //alert(navigator.appName);
             if(navigator.appName == "Microsoft Internet Explorer")
             {
                 objBody.className = "modalBackground";
                 objBody.value = "read-only";
             }
             //objBody.ReadOnly = true;
             //$find('programmaticPersonModalPopupBehavior1').show();
             
        }
        
        function hideDiv()
        {
            objDiv = document.getElementById("dvMeeting");
            objDiv.className = "loading-invisible";
            objBody = document.getElementById( "bodyPage" );
             
            if(navigator.appName == "Microsoft Internet Explorer")
            {
                objBody.className = "modalBackground1";
            }
            //$find('programmaticPersonModalPopupBehavior1').hide();
        }
        
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
                 var objSubject = document.getElementById('<%=this.txtSubject_rqd.ClientID%>');  
                 
                 var hr1 = GetEnglishValue(objHr1.value);
                 var hr2 = GetEnglishValue(objHr2.value);
                 var min1 = GetEnglishValue(objMin1.value);
                 var min2 = GetEnglishValue(objMin2.value);

                 if(hr1 > hr2)
                 {   
                     ErrMsg ="Appointment Start Time Should be less than End Time";
                     myfocus = objHr1;
                     flag = false;
                 }
                 else if (hr1 == hr2)
                 { 
                    if(min1 > min2)
                    {    ErrMsg = "Appointment Start Time Should be less than End Time";
                         myfocus = objMin1;
                         flag = false;
                    }
                    else  if(min1 == min2)
                    {    ErrMsg = "Appointment Start Time Should be less than End Time";
                         myfocus = objMin1;
                         flag = false;
                    }
                 }
                 

                if (ErrMsg == "")
                {
                   return true;
                }
                else 
                {
                    alert("The following errors were encountered.\n\n" + ErrMsg);
                    myfocus.focus();
                    return false;
                }
             }
            else
                return false;
            
        }
        
        function CheckOutdoorAppointeeName()
        {
            var objName =  document.getElementById('<%=this.txtOutDoorFullName.ClientID%>');
            var ErrMsg = "";
            if(objName.value == "")
            {
                ErrMsg = "- कृपया "+  objName.title + " राख्नुहोस।\n";
                alert("सर्वप्रथम निम्न त्रुटिहरू सच्याउनुहोस।\n\n" + ErrMsg);
                objName.focus();
                return false;
            }
            else
            {   return true;
            }
        }
        
        function chkPopup()
        {
             var objChkPopup = document.getElementById('<%=this.hdnChkPopup.ClientID%>'); 
             objChkPopup.value = "Y";
        }
               
        
        
    </script>

    <div onMouseMove="mousepos(event)">
    
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
        &nbsp;<!-- NB::  Code for Calendar------------------------------------------------------------ -->
        &nbsp;
        <br />
    <table border="0" cellpadding="0" cellspacing="0" style="width: 99%">
        <tr align="right">
            <td align="left">
                <asp:Label ID="lblHeading" runat="server" Text="एपोइन्टमेन्ट" SkinID="UnicodeHeadlbl"></asp:Label></td>
            <td style="width: 80%">
                <asp:DataList ID="dLstAppointmentStatus" runat="server" RepeatDirection="Horizontal">
                    <ItemTemplate>
                        &nbsp;<asp:Label ID="lblMeetingStatusName" runat="server" Text='<%# Eval("AppointmentStatusName") %>'></asp:Label>
                        <asp:Label ID="lblStatusColor" runat="server" BackColor='<%# Eval("RDStatusColor") %>'
                            Text='&nbsp;&nbsp;&nbsp;&nbsp;'></asp:Label>
                        &nbsp; &nbsp;
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
    </table>
    &nbsp;
    <div style="width: 100%; height: auto; background-color: White">
        <asp:UpdatePanel id="myCalendar" runat="server">
            <contenttemplate>
<TABLE width=400><TBODY><TR><TD style="WIDTH: 60px"><asp:Label id="Label1" runat="server" Text="साल" SkinID="Unicodelbl" __designer:wfdid="w94"></asp:Label></TD><TD style="WIDTH: 300px"><asp:DropDownList id="ddlYear" runat="server" Width="100px" __designer:wfdid="w95"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 60px"><asp:Label id="Label2" runat="server" Text="महिना" SkinID="Unicodelbl" __designer:wfdid="w96"></asp:Label></TD><TD style="WIDTH: 300px"><asp:DropDownList id="ddlMonth" runat="server" Width="100px" SkinID="Unicodeddl" __designer:wfdid="w97"></asp:DropDownList> <asp:ImageButton id="imgShow" onclick="imgShow_Click" runat="server" Width="20px" ImageUrl="~/MODULES/OAS/Images/Calendar.ico" Height="18px" __designer:wfdid="w98" ImageAlign="AbsMiddle" ToolTip="Display Calender"></asp:ImageButton>&nbsp;</TD></TR><TR><TD style="WIDTH: 60px" height=5></TD><TD style="WIDTH: 300px" height=5></TD></TR><TR><TD style="HEIGHT: 25px" vAlign=top colSpan=2><asp:ImageButton id="imgPrevious" onclick="imgPrevious_Click" runat="server" Width="25px" ImageUrl="~/MODULES/OAS/Images/arrowright.gif" Height="25px" __designer:wfdid="w99" ImageAlign="AbsMiddle" ToolTip="Previous Year"></asp:ImageButton> &nbsp;<asp:Label id="lblMonthText" runat="server" Text="Label" SkinID="Unicodelbl" Font-Bold="False" __designer:wfdid="w100"></asp:Label> <asp:Label id="Label4" runat="server" Width="11px" Text="," SkinID="Unicodelbl" __designer:wfdid="w101"></asp:Label> <asp:Label id="lblYear1" runat="server" Width="43px" Text="2065" SkinID="Unicodelbl" Font-Bold="False" __designer:wfdid="w102"></asp:Label> <asp:Label id="lblMonth" runat="server" Width="0px" Text="01" Font-Bold="False" __designer:wfdid="w103" Visible="False"></asp:Label><asp:ImageButton id="imgNext" onclick="imgNext_Click" runat="server" Width="25px" ImageUrl="~/MODULES/OAS/Images/arrowleft.gif" Height="25px" __designer:wfdid="w104" ImageAlign="AbsMiddle" ToolTip="Next Month"></asp:ImageButton> </TD></TR></TBODY></TABLE><asp:HiddenField id="__EventDetail" runat="server" __designer:dtid="281474976710677" __designer:wfdid="w1"></asp:HiddenField><asp:HiddenField id="hdnStatus" runat="server" __designer:dtid="562949953421326" __designer:wfdid="w1"></asp:HiddenField><asp:HiddenField id="hdnYear" runat="server" __designer:dtid="562949953421327" __designer:wfdid="w2"></asp:HiddenField><asp:HiddenField id="hdnMonth" runat="server" __designer:dtid="562949953421328" __designer:wfdid="w3"></asp:HiddenField><asp:HiddenField id="hdnDay" runat="server" __designer:dtid="562949953421329" __designer:wfdid="w4"></asp:HiddenField><asp:HiddenField id="hdnMDate" runat="server" __designer:dtid="562949953421330" __designer:wfdid="w5"></asp:HiddenField><asp:HiddenField id="hdnChkPopup" runat="server" __designer:dtid="562949953421331" __designer:wfdid="w6"></asp:HiddenField><asp:HiddenField id="hdnCurrentDate" runat="server" __designer:dtid="562949953421332" __designer:wfdid="w7"></asp:HiddenField> 
<HR />
<asp:Label id="lblYear" runat="server" Text="Label" __designer:wfdid="w105" Visible="False"></asp:Label> <asp:Table id="tblAM" runat="server" Width="100%" BackColor="White" __designer:wfdid="w106" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" CellSpacing="0" GridLines="Both" CellPadding="0"><asp:TableRow runat="server" BorderColor="Silver" BackColor="#307196" ToolTip="Days" Height="30px" ID="TableRow1"><asp:TableCell runat="server" HorizontalAlign="Left" VerticalAlign="Middle" Width="14%" ID="TableCell1"><asp:Label runat="server" SkinID="PNDay" Font-Bold="True" ForeColor="White" ID="sun">आईतबार</asp:Label>
</asp:TableCell>
<asp:TableCell runat="server" HorizontalAlign="Left" VerticalAlign="Middle" Width="14%" ID="TableCell2"><asp:Label runat="server" SkinID="PNDay" Font-Bold="True" ForeColor="White" ID="Mon">सोमबार</asp:Label>
</asp:TableCell>
<asp:TableCell runat="server" HorizontalAlign="Left" VerticalAlign="Middle" Width="14%" ID="TableCell3"><asp:Label runat="server" SkinID="PNDay" Font-Bold="True" ForeColor="White" ID="Tues">मंगलबार</asp:Label>
</asp:TableCell>
<asp:TableCell runat="server" HorizontalAlign="Left" VerticalAlign="Middle" Width="14%" ID="TableCell4"><asp:Label runat="server" SkinID="PNDay" Font-Bold="True" ForeColor="White" ID="Wed">बुधबार</asp:Label>
</asp:TableCell>
<asp:TableCell runat="server" HorizontalAlign="Left" VerticalAlign="Middle" Width="14%" ID="TableCell5"><asp:Label runat="server" SkinID="PNDay" Font-Bold="True" ForeColor="White" ID="Thur">बिहिबार</asp:Label>
</asp:TableCell>
<asp:TableCell runat="server" HorizontalAlign="Left" VerticalAlign="Middle" Width="14%" ID="TableCell6"><asp:Label runat="server" SkinID="PNDay" Font-Bold="True" ForeColor="White" ID="Fri">शुक्रबार</asp:Label>
</asp:TableCell>
<asp:TableCell runat="server" HorizontalAlign="Left" VerticalAlign="Middle" Width="16%" ID="TableCell7"><asp:Label runat="server" SkinID="PNDay" Font-Bold="True" ForeColor="White" ID="Sat">शनिबार</asp:Label>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow runat="server" Height="100px" ID="TableRow2"><asp:TableCell runat="server" HorizontalAlign="Left" BorderColor="Silver" VerticalAlign="Top" Width="14%" ID="TableCell8"><asp:Label runat="server" SkinID="Unicodelbl" Font-Bold="True" ID="Day1"></asp:Label>

<br />
                      <asp:Panel runat="server" Width="154px" Font-Names="Verdana" ForeColor="Red" Height="90px" ScrollBars="Auto" ID="Panel1">
                              <asp:DataList ID="DataList1" runat="server" CellPadding="4" Font-Size="2px" ForeColor="#333333"
                               RepeatColumns="1" Width="135px" >
                               <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                               <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                               <ItemStyle BackColor="White" ForeColor="#333333" />
                               <ItemTemplate>
                                   <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandArgument='<%# Eval("OrgID") + "/" + Eval("UnitID") + "/" + Eval("EventID") %>'
                                       OnClick="LinkEventHandler" SkinID="smalCalendarlLnk" Text='<%# Eval("Event") %>'
                                       ToolTip='<%# Eval("EventDetail") %>' ForeColor='<%# Eval("RDStatusColor") %>'></asp:LinkButton>
                               </ItemTemplate>
                               <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                           </asp:DataList>


                        </asp:Panel>
</asp:TableCell>
<asp:TableCell runat="server" HorizontalAlign="Left" BorderColor="Silver" VerticalAlign="Top" Width="14%" ID="TableCell9"><asp:Label runat="server" SkinID="Unicodelbl" Font-Bold="True" ID="Day2"></asp:Label>

<br />
                    <asp:Panel runat="server" Width="140px" Font-Names="Verdana" ForeColor="Red" Height="90px" ScrollBars="Auto" ID="Panel2">
                        <asp:DataList runat="server" Font-Size="2px" Width="123px" CellPadding="4" ID="DataList2" ForeColor="#333333" RepeatColumns="1">
<SelectedItemStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedItemStyle>

<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

<ItemStyle BackColor="White" ForeColor="#333333"></ItemStyle>
<ItemTemplate>
                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandArgument='<%# Eval("OrgID") + "/" + Eval("UnitID") + "/" + Eval("EventID") %>'
                                    OnClick="LinkEventHandler" SkinID="smalCalendarlLnk" Text='<%# Eval("Event") %>'
                                    ToolTip='<%# Eval("EventDetail") %>' ForeColor='<%# Eval("RDStatusColor") %>'></asp:LinkButton>
                               </ItemTemplate>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
</asp:DataList>


                    </asp:Panel>
</asp:TableCell>
<asp:TableCell runat="server" HorizontalAlign="Left" BorderColor="Silver" VerticalAlign="Top" Width="14%" ID="TableCell10"><asp:Label runat="server" SkinID="Unicodelbl" Font-Bold="True" ID="Day3"></asp:Label>

<br />
                    <asp:Panel runat="server" Width="140px" Font-Names="Verdana" ForeColor="Red" Height="90px" ScrollBars="Auto" ID="Panel3">
                        <asp:DataList runat="server" Font-Size="2px" Width="123px" CellPadding="4" ID="DataList3" ForeColor="#333333" RepeatColumns="1">
<SelectedItemStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedItemStyle>

<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

<ItemStyle BackColor="White" ForeColor="#333333"></ItemStyle>
<ItemTemplate>
                                <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandArgument='<%# Eval("OrgID") + "/" + Eval("UnitID") + "/" + Eval("EventID") %>'
                                    OnClick="LinkEventHandler" SkinID="smalCalendarlLnk" Text='<%# Eval("Event") %>'
                                    ToolTip='<%# Eval("EventDetail") %>' ForeColor='<%# Eval("RDStatusColor") %>'></asp:LinkButton>
                               </ItemTemplate>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
</asp:DataList>


                    </asp:Panel>
</asp:TableCell>
<asp:TableCell runat="server" HorizontalAlign="Left" BorderColor="Silver" VerticalAlign="Top" Width="14%" ID="TableCell11"><asp:Label runat="server" SkinID="Unicodelbl" Font-Bold="True" ID="Day4"></asp:Label>

<br />
                    <asp:Panel runat="server" Width="140px" Font-Names="Verdana" ForeColor="Red" Height="90px" ScrollBars="Auto" ID="Panel4">
                        <asp:DataList runat="server" Font-Size="2px" Width="123px" CellPadding="4"  ID="DataList4" ForeColor="#333333" RepeatColumns="1">
<SelectedItemStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedItemStyle>

<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

<ItemStyle BackColor="White" ForeColor="#333333"></ItemStyle>
<ItemTemplate>
                                <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandArgument='<%# Eval("OrgID") + "/" + Eval("UnitID") + "/" + Eval("EventID") %>'
                                    OnClick="LinkEventHandler" SkinID="smalCalendarlLnk" Text='<%# Eval("Event") %>'
                                   ToolTip='<%# Eval("EventDetail") %>' ForeColor='<%# Eval("RDStatusColor") %>'></asp:LinkButton>
                               </ItemTemplate>
<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
</asp:DataList>


                    </asp:Panel>
</asp:TableCell>
<asp:TableCell runat="server" HorizontalAlign="Left" BorderColor="Silver" VerticalAlign="Top" Width="14%" ID="TableCell12"><asp:Label runat="server" SkinID="Unicodelbl" Font-Bold="True" ID="Day5"></asp:Label>

<br />
                    <asp:Panel runat="server" Width="140px" Font-Names="Verdana" ForeColor="Red" Height="90px" ScrollBars="Auto" ID="Panel5">
                        <asp:DataList runat="server" Font-Size="2px" Width="123px" CellPadding="4" ID="DataList5" ForeColor="#333333" RepeatColumns="1">
<SelectedItemStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedItemStyle>

<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

<ItemStyle BackColor="White" ForeColor="#333333"></ItemStyle>
<ItemTemplate>
                                <asp:LinkButton ID="LinkButton5" runat="server" CausesValidation="False" CommandArgument='<%# Eval("OrgID") + "/" + Eval("UnitID") + "/" + Eval("EventID") %>'
                                    OnClick="LinkEventHandler" SkinID="smalCalendarlLnk" Text='<%# Eval("Event") %>'
                                    ToolTip='<%# Eval("EventDetail") %>' ForeColor='<%# Eval("RDStatusColor") %>'></asp:LinkButton>
                               </ItemTemplate>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
</asp:DataList>


                    </asp:Panel>
</asp:TableCell>
<asp:TableCell runat="server" HorizontalAlign="Left" BorderColor="Silver" VerticalAlign="Top" Width="14%" ID="TableCell13"><asp:Label runat="server" SkinID="Unicodelbl" Font-Bold="True" ID="Day6"></asp:Label>

<br />
                    <asp:Panel runat="server" Width="140px" Font-Names="Verdana" ForeColor="Red" Height="90px" ScrollBars="Auto" ID="Panel6">
                        <asp:DataList runat="server" Font-Size="2px" Width="123px" CellPadding="4" ID="DataList6" ForeColor="#333333" RepeatColumns="1">
<SelectedItemStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedItemStyle>

<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

<ItemStyle BackColor="White" ForeColor="#333333"></ItemStyle>
<ItemTemplate>
                                <asp:LinkButton ID="LinkButton6" runat="server" CausesValidation="False" CommandArgument='<%# Eval("OrgID") + "/" + Eval("UnitID") + "/" + Eval("EventID") %>'
                                    OnClick="LinkEventHandler" SkinID="smalCalendarlLnk" Text='<%# Eval("Event") %>'
                                    ToolTip='<%# Eval("EventDetail") %>' ForeColor='<%# Eval("RDStatusColor") %>'></asp:LinkButton>
                               </ItemTemplate>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
</asp:DataList>


                    </asp:Panel>
</asp:TableCell>
<asp:TableCell runat="server" HorizontalAlign="Left" BorderColor="Silver" VerticalAlign="Top" Width="16%" ID="TableCell14"><asp:Label runat="server" SkinID="Unicodelbl" Font-Bold="True" ID="Day7"></asp:Label>

<br />
                    <asp:Panel runat="server" Width="140px" Font-Names="Verdana" ForeColor="Red" Height="90px" ScrollBars="Auto" ID="Panel7">
                        <asp:DataList runat="server" Font-Size="2px" Width="123px" CellPadding="4" ID="DataList7" ForeColor="#333333" RepeatColumns="1">
<SelectedItemStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedItemStyle>

<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

<ItemStyle BackColor="White" ForeColor="#333333"></ItemStyle>
<ItemTemplate>
                                <asp:LinkButton ID="LinkButton7" runat="server" CausesValidation="False" CommandArgument='<%# Eval("OrgID") + "/" + Eval("UnitID") + "/" + Eval("EventID") %>'
                                    OnClick="LinkEventHandler" SkinID="smalCalendarlLnk" Text='<%# Eval("Event") %>'
                                    ToolTip='<%# Eval("EventDetail") %>' ForeColor='<%# Eval("RDStatusColor") %>'></asp:LinkButton>
                               </ItemTemplate>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
</asp:DataList>


                    </asp:Panel>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow runat="server" Height="100px" ID="TableRow3"><asp:TableCell runat="server" HorizontalAlign="Left" BorderColor="Silver" VerticalAlign="Top" Width="14%" ID="TableCell15"><asp:Label runat="server" SkinID="Unicodelbl" Font-Bold="True" ID="Day8"></asp:Label>

<br />
                    <br />
                    <asp:Panel runat="server" Width="140px" Font-Names="Verdana" ForeColor="Red" Height="90px" ScrollBars="Auto" ID="Panel8">
                        <asp:DataList runat="server" Font-Size="2px" Width="123px" CellPadding="4" ID="DataList8" ForeColor="#333333" RepeatColumns="1">
<SelectedItemStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedItemStyle>

<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

<ItemStyle BackColor="White" ForeColor="#333333"></ItemStyle>
<ItemTemplate>
                                <asp:LinkButton ID="LinkButton8" runat="server" CausesValidation="False" CommandArgument='<%# Eval("OrgID") + "/" + Eval("UnitID") + "/" + Eval("EventID") %>'
                                    OnClick="LinkEventHandler" SkinID="smalCalendarlLnk" Text='<%# Eval("Event") %>'
                                    ToolTip='<%# Eval("EventDetail") %>' ForeColor='<%# Eval("RDStatusColor") %>'></asp:LinkButton>
                               </ItemTemplate>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
</asp:DataList>


                    </asp:Panel>
</asp:TableCell>
<asp:TableCell runat="server" HorizontalAlign="Left" BorderColor="Silver" VerticalAlign="Top" Width="14%" ID="TableCell16"><asp:Label runat="server" SkinID="Unicodelbl" Font-Bold="True" ID="Day9"></asp:Label>

<br />
                    <br />
                    <asp:Panel runat="server" Width="140px" Font-Names="Verdana" ForeColor="Red" Height="90px" ScrollBars="Auto" ID="Panel9">
                        <asp:DataList runat="server" Font-Size="2px" Width="123px" CellPadding="4" ID="DataList9" ForeColor="#333333" RepeatColumns="1">
<SelectedItemStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedItemStyle>

<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

<ItemStyle BackColor="White" ForeColor="#333333"></ItemStyle>
<ItemTemplate>
                                <asp:LinkButton ID="LinkButton9" runat="server" CausesValidation="False" CommandArgument='<%# Eval("OrgID") + "/" + Eval("UnitID") + "/" + Eval("EventID") %>'
                                    OnClick="LinkEventHandler" SkinID="smalCalendarlLnk" Text='<%# Eval("Event") %>'
                                    ToolTip='<%# Eval("EventDetail") %>' ForeColor='<%# Eval("RDStatusColor") %>'></asp:LinkButton>
                               </ItemTemplate>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
</asp:DataList>


                    </asp:Panel>
</asp:TableCell>
<asp:TableCell runat="server" HorizontalAlign="Left" BorderColor="Silver" VerticalAlign="Top" Width="14%" ID="TableCell17"><asp:Label runat="server" SkinID="Unicodelbl" Font-Bold="True" ID="Day10"></asp:Label>

<br />
                    <br />
                    <asp:Panel runat="server" Width="140px" Font-Names="Verdana" ForeColor="Red" Height="90px" ScrollBars="Auto" ID="Panel10">
                        <asp:DataList runat="server" Font-Size="2px" Width="123px" CellPadding="4" ID="DataList10" ForeColor="#333333" RepeatColumns="1">
<SelectedItemStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedItemStyle>

<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

<ItemStyle BackColor="White" ForeColor="#333333"></ItemStyle>
<ItemTemplate>
                                <asp:LinkButton ID="LinkButton10" runat="server" CausesValidation="False" CommandArgument='<%# Eval("OrgID") + "/" + Eval("UnitID") + "/" + Eval("EventID") %>'
                                    OnClick="LinkEventHandler" SkinID="smalCalendarlLnk" Text='<%# Eval("Event") %>'
                                    ToolTip='<%# Eval("EventDetail") %>' ForeColor='<%# Eval("RDStatusColor") %>'></asp:LinkButton>
                               </ItemTemplate>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
</asp:DataList>


                    </asp:Panel>
</asp:TableCell>
<asp:TableCell runat="server" HorizontalAlign="Left" BorderColor="Silver" VerticalAlign="Top" Width="14%" ID="TableCell18"><asp:Label runat="server" SkinID="Unicodelbl" Font-Bold="True" ID="Day11"></asp:Label>

<br />
                    <br />
                    <asp:Panel runat="server" Width="140px" Font-Names="Verdana" ForeColor="Red" Height="90px" ScrollBars="Auto" ID="Panel11">
                        <asp:DataList runat="server" Font-Size="2px" Width="123px" CellPadding="4" ID="DataList11" ForeColor="#333333" RepeatColumns="1">
<SelectedItemStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedItemStyle>

<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

<ItemStyle BackColor="White" ForeColor="#333333"></ItemStyle>
<ItemTemplate>
                                <asp:LinkButton ID="LinkButton11" runat="server" CausesValidation="False" CommandArgument='<%# Eval("OrgID") + "/" + Eval("UnitID") + "/" + Eval("EventID") %>'
                                    OnClick="LinkEventHandler" SkinID="smalCalendarlLnk" Text='<%# Eval("Event") %>'
                                    ToolTip='<%# Eval("EventDetail") %>' ForeColor='<%# Eval("RDStatusColor") %>'></asp:LinkButton>
                               </ItemTemplate>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
</asp:DataList>


                    </asp:Panel>
</asp:TableCell>
<asp:TableCell runat="server" HorizontalAlign="Left" BorderColor="Silver" VerticalAlign="Top" Width="14%" ID="TableCell19"><asp:Label runat="server" SkinID="Unicodelbl" Font-Bold="True" ID="Day12"></asp:Label>

<br />
                    <br />
                    <asp:Panel runat="server" Width="140px" Font-Names="Verdana" ForeColor="Red" Height="90px" ScrollBars="Auto" ID="Panel12">
                        <asp:DataList runat="server" Font-Size="2px" Width="123px" CellPadding="4" ID="DataList12" ForeColor="#333333" RepeatColumns="1">
<SelectedItemStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedItemStyle>

<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

<ItemStyle BackColor="White" ForeColor="#333333"></ItemStyle>
<ItemTemplate>
                                <asp:LinkButton ID="LinkButton12" runat="server" CausesValidation="False" CommandArgument='<%# Eval("OrgID") + "/" + Eval("UnitID") + "/" + Eval("EventID") %>'
                                    OnClick="LinkEventHandler" SkinID="smalCalendarlLnk" Text='<%# Eval("Event") %>'
                                    ToolTip='<%# Eval("EventDetail") %>' ForeColor='<%# Eval("RDStatusColor") %>'></asp:LinkButton>
                               </ItemTemplate>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
</asp:DataList>


                    </asp:Panel>
</asp:TableCell>
<asp:TableCell runat="server" HorizontalAlign="Left" BorderColor="Silver" VerticalAlign="Top" Width="14%" ID="TableCell20"><asp:Label runat="server" SkinID="Unicodelbl" Font-Bold="True" ID="Day13"></asp:Label>

<br />
                    <br />
                    <asp:Panel runat="server" Width="140px" Font-Names="Verdana" ForeColor="Red" Height="90px" ScrollBars="Auto" ID="Panel13">
                        <asp:DataList runat="server" Font-Size="2px" Width="123px" CellPadding="4" ID="DataList13" ForeColor="#333333" RepeatColumns="1">
<SelectedItemStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedItemStyle>

<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

<ItemStyle BackColor="White" ForeColor="#333333"></ItemStyle>
<ItemTemplate>
                                <asp:LinkButton ID="LinkButton13" runat="server" CausesValidation="False" CommandArgument='<%# Eval("OrgID") + "/" + Eval("UnitID") + "/" + Eval("EventID") %>'
                                    OnClick="LinkEventHandler" SkinID="smalCalendarlLnk" Text='<%# Eval("Event") %>'
                                    ToolTip='<%# Eval("EventDetail") %>' ForeColor='<%# Eval("RDStatusColor") %>'></asp:LinkButton>
                               </ItemTemplate>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
</asp:DataList>


                    </asp:Panel>
</asp:TableCell>
<asp:TableCell runat="server" HorizontalAlign="Left" BorderColor="Silver" VerticalAlign="Top" Width="16%" ID="TableCell21"><asp:Label runat="server" SkinID="Unicodelbl" Font-Bold="True" ID="Day14"></asp:Label>

<br />
                    <br />
                    <asp:Panel runat="server" Width="140px" Font-Names="Verdana" ForeColor="Red" Height="90px" ScrollBars="Auto" ID="Panel14">
                        <asp:DataList runat="server" Font-Size="2px" Width="123px" CellPadding="4" ID="DataList14" ForeColor="#333333" RepeatColumns="1">
<SelectedItemStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedItemStyle>

<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

<ItemStyle BackColor="White" ForeColor="#333333"></ItemStyle>
<ItemTemplate>
                                <asp:LinkButton ID="LinkButton14" runat="server" CausesValidation="False" CommandArgument='<%# Eval("OrgID") + "/" + Eval("UnitID") + "/" + Eval("EventID") %>'
                                    OnClick="LinkEventHandler" SkinID="smalCalendarlLnk" Text='<%# Eval("Event") %>'
                                    ToolTip='<%# Eval("EventDetail") %>' ForeColor='<%# Eval("RDStatusColor") %>'></asp:LinkButton>
                               </ItemTemplate>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
</asp:DataList>


                    </asp:Panel>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow runat="server" Height="100px" ID="TableRow4"><asp:TableCell runat="server" BackColor="#E8EEFA" HorizontalAlign="Left" BorderColor="Silver" VerticalAlign="Top" Width="16%" ID="TableCell22"><asp:Label runat="server" SkinID="Unicodelbl" Font-Bold="True" ID="Day15"></asp:Label>

<br />
                    <br />
                    <asp:Panel runat="server" Width="140px" Font-Names="Verdana" ForeColor="Red" Height="90px" ScrollBars="Auto" ID="Panel15">
                        <asp:DataList runat="server" Font-Size="2px" Width="123px" CellPadding="4" ID="DataList15" ForeColor="#333333" RepeatColumns="1">
<SelectedItemStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedItemStyle>

<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

<ItemStyle BackColor="White" ForeColor="#333333"></ItemStyle>
<ItemTemplate>
                                <asp:LinkButton ID="LinkButton15" runat="server" CausesValidation="False" CommandArgument='<%# Eval("OrgID") + "/" + Eval("UnitID") + "/" + Eval("EventID") %>'
                                    OnClick="LinkEventHandler" SkinID="smalCalendarlLnk" Text='<%# Eval("Event") %>'
                                    ToolTip='<%# Eval("EventDetail") %>' ForeColor='<%# Eval("RDStatusColor") %>'></asp:LinkButton>
                               </ItemTemplate>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
</asp:DataList>


                    </asp:Panel>
</asp:TableCell>
<asp:TableCell runat="server" HorizontalAlign="Left" BorderColor="Silver" VerticalAlign="Top" Width="14%" ID="TableCell23"><asp:Label runat="server" SkinID="Unicodelbl" Font-Bold="True" ID="Day16"></asp:Label>

<br />
                    <br />
                    <asp:Panel runat="server" Width="140px" Font-Names="Verdana" ForeColor="Red" Height="90px" ScrollBars="Auto" ID="Panel16">
                        <asp:DataList runat="server" Font-Size="2px" Width="123px" CellPadding="4" ID="DataList16" ForeColor="#333333" RepeatColumns="1">
<SelectedItemStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedItemStyle>

<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

<ItemStyle BackColor="White" ForeColor="#333333"></ItemStyle>
<ItemTemplate>
                                <asp:LinkButton ID="LinkButton16" runat="server" CausesValidation="False" CommandArgument='<%# Eval("OrgID") + "/" + Eval("UnitID") + "/" + Eval("EventID") %>'
                                    OnClick="LinkEventHandler" SkinID="smalCalendarlLnk" Text='<%# Eval("Event") %>'
                                    ToolTip='<%# Eval("EventDetail") %>' ForeColor='<%# Eval("RDStatusColor") %>'></asp:LinkButton>
                               </ItemTemplate>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
</asp:DataList>


                    </asp:Panel>
</asp:TableCell>
<asp:TableCell runat="server" HorizontalAlign="Left" BorderColor="Silver" VerticalAlign="Top" Width="14%" ID="TableCell24"><asp:Label runat="server" SkinID="Unicodelbl" Font-Bold="True" ID="Day17"></asp:Label>

<br />
                    <br />
                    <asp:Panel runat="server" Width="140px" Font-Names="Verdana" ForeColor="Red" Height="90px" ScrollBars="Auto" ID="Panel17">
                        <asp:DataList runat="server" Font-Size="2px" Width="123px" CellPadding="4" ID="DataList17" ForeColor="#333333" RepeatColumns="1">
<SelectedItemStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedItemStyle>

<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

<ItemStyle BackColor="White" ForeColor="#333333"></ItemStyle>
<ItemTemplate>
                                <asp:LinkButton ID="LinkButton17" runat="server" CausesValidation="False" CommandArgument='<%# Eval("OrgID") + "/" + Eval("UnitID") + "/" + Eval("EventID") %>'
                                    OnClick="LinkEventHandler" SkinID="smalCalendarlLnk" Text='<%# Eval("Event") %>'
                                    ToolTip='<%# Eval("EventDetail") %>' ForeColor='<%# Eval("RDStatusColor") %>'></asp:LinkButton>
                               </ItemTemplate>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
</asp:DataList>


                    </asp:Panel>
</asp:TableCell>
<asp:TableCell runat="server" HorizontalAlign="Left" BorderColor="Silver" VerticalAlign="Top" Width="14%" ID="TableCell25"><asp:Label runat="server" SkinID="Unicodelbl" Font-Bold="True" ID="Day18"></asp:Label>

<br />
                    <br />
                    <asp:Panel runat="server" Width="140px" Font-Names="Verdana" ForeColor="Red" Height="90px" ScrollBars="Auto" ID="Panel18">
                        <asp:DataList runat="server" Font-Size="2px" Width="123px" CellPadding="4" ID="DataList18" ForeColor="#333333" RepeatColumns="1">
<SelectedItemStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedItemStyle>

<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

<ItemStyle BackColor="White" ForeColor="#333333"></ItemStyle>
<ItemTemplate>
                                <asp:LinkButton ID="LinkButton18" runat="server" CausesValidation="False" CommandArgument='<%# Eval("OrgID") + "/" + Eval("UnitID") + "/" + Eval("EventID") %>'
                                    OnClick="LinkEventHandler" SkinID="smalCalendarlLnk" Text='<%# Eval("Event") %>'
                                    ToolTip='<%# Eval("EventDetail") %>' ForeColor='<%# Eval("RDStatusColor") %>'></asp:LinkButton>
                               </ItemTemplate>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
</asp:DataList>


                    </asp:Panel>
</asp:TableCell>
<asp:TableCell runat="server" HorizontalAlign="Left" BorderColor="Silver" VerticalAlign="Top" Width="14%" ID="TableCell26"><asp:Label runat="server" SkinID="Unicodelbl" Font-Bold="True" ID="Day19"></asp:Label>

<br />
                    <br />
                    <asp:Panel runat="server" Width="140px" Font-Names="Verdana" ForeColor="Red" Height="90px" ScrollBars="Auto" ID="Panel19">
                        <asp:DataList runat="server" Font-Size="2px" Width="123px" CellPadding="4" ID="DataList19" ForeColor="#333333" RepeatColumns="1">
<SelectedItemStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedItemStyle>

<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

<ItemStyle BackColor="White" ForeColor="#333333"></ItemStyle>
<ItemTemplate>
                                <asp:LinkButton ID="LinkButton19" runat="server" CausesValidation="False" CommandArgument='<%# Eval("OrgID") + "/" + Eval("UnitID") + "/" + Eval("EventID") %>'
                                    OnClick="LinkEventHandler" SkinID="smalCalendarlLnk" Text='<%# Eval("Event") %>'
                                    ToolTip='<%# Eval("EventDetail") %>' ForeColor='<%# Eval("RDStatusColor") %>'></asp:LinkButton>
                               </ItemTemplate>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
</asp:DataList>


                    </asp:Panel>
</asp:TableCell>
<asp:TableCell runat="server" HorizontalAlign="Left" BorderColor="Silver" VerticalAlign="Top" Width="14%" ID="TableCell27"><asp:Label runat="server" SkinID="Unicodelbl" Font-Bold="True" ID="Day20"></asp:Label>

<br />
                    <br />
                    <asp:Panel runat="server" Width="140px" Font-Names="Verdana" ForeColor="Red" Height="90px" ScrollBars="Auto" ID="Panel20">
                        <asp:DataList runat="server" Font-Size="2px" Width="123px" CellPadding="4" ID="DataList20" ForeColor="#333333" RepeatColumns="1">
<SelectedItemStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedItemStyle>

<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

<ItemStyle BackColor="White" ForeColor="#333333"></ItemStyle>
<ItemTemplate>
                                <asp:LinkButton ID="LinkButton20" runat="server" CausesValidation="False" CommandArgument='<%# Eval("OrgID") + "/" + Eval("UnitID") + "/" + Eval("EventID") %>'
                                    OnClick="LinkEventHandler" SkinID="smalCalendarlLnk" Text='<%# Eval("Event") %>'
                                    ToolTip='<%# Eval("EventDetail") %>' ForeColor='<%# Eval("RDStatusColor") %>'></asp:LinkButton>
                               </ItemTemplate>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
</asp:DataList>


                    </asp:Panel>
</asp:TableCell>
<asp:TableCell runat="server" HorizontalAlign="Left" BorderColor="Silver" VerticalAlign="Top" Width="16%" ID="TableCell28"><asp:Label runat="server" SkinID="Unicodelbl" Font-Bold="True" ID="Day21"></asp:Label>

<br />
                    <br />
                    <asp:Panel runat="server" Width="140px" Font-Names="Verdana" ForeColor="Red" Height="90px" ScrollBars="Auto" ID="Panel21">
                        <asp:DataList runat="server" Font-Size="2px" Width="123px" CellPadding="4" ID="DataList21" ForeColor="#333333" RepeatColumns="1">
<SelectedItemStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedItemStyle>

<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

<ItemStyle BackColor="White" ForeColor="#333333"></ItemStyle>
<ItemTemplate>
                                <asp:LinkButton ID="LinkButton21" runat="server" CausesValidation="False" CommandArgument='<%# Eval("OrgID") + "/" + Eval("UnitID") + "/" + Eval("EventID") %>'
                                    OnClick="LinkEventHandler" SkinID="smalCalendarlLnk" Text='<%# Eval("Event") %>'
                                   ToolTip='<%# Eval("EventDetail") %>' ForeColor='<%# Eval("RDStatusColor") %>'></asp:LinkButton>
                               </ItemTemplate>
<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
</asp:DataList>


                    </asp:Panel>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow runat="server" Height="100px" ID="TableRow5"><asp:TableCell runat="server" HorizontalAlign="Left" BorderColor="Silver" VerticalAlign="Top" Width="14%" ID="TableCell29"><asp:Label runat="server" SkinID="Unicodelbl" Font-Bold="True" ID="Day22"></asp:Label>

<br />
                    <br />
                    <asp:Panel runat="server" Width="140px" Font-Names="Verdana" ForeColor="Red" Height="90px" ScrollBars="Auto" ID="Panel22">
                        <asp:DataList runat="server" Font-Size="2px" Width="123px" CellPadding="4" ID="DataList22" ForeColor="#333333" RepeatColumns="1">
<SelectedItemStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedItemStyle>

<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

<ItemStyle BackColor="White" ForeColor="#333333"></ItemStyle>
<ItemTemplate>
                                <asp:LinkButton ID="LinkButton22" runat="server" CausesValidation="False" CommandArgument='<%# Eval("OrgID") + "/" + Eval("UnitID") + "/" + Eval("EventID") %>'
                                    OnClick="LinkEventHandler" SkinID="smalCalendarlLnk" Text='<%# Eval("Event") %>'
                                    ToolTip='<%# Eval("EventDetail") %>' ForeColor='<%# Eval("RDStatusColor") %>'></asp:LinkButton>
                               </ItemTemplate>
<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
</asp:DataList>


                    </asp:Panel>
</asp:TableCell>
<asp:TableCell runat="server" HorizontalAlign="Left" BorderColor="Silver" VerticalAlign="Top" Width="14%" ID="TableCell30"><asp:Label runat="server" SkinID="Unicodelbl" Font-Bold="True" ID="Day23"></asp:Label>

<br />
                    <br />
                    <asp:Panel runat="server" Width="140px" Font-Names="Verdana" ForeColor="Red" Height="90px" ScrollBars="Auto" ID="Panel23">
                        <asp:DataList runat="server" Font-Size="2px" Width="123px" CellPadding="4" ID="DataList23" ForeColor="#333333" RepeatColumns="1">
<SelectedItemStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedItemStyle>

<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

<ItemStyle BackColor="White" ForeColor="#333333"></ItemStyle>
<ItemTemplate>
                                <asp:LinkButton ID="LinkButton23" runat="server" CausesValidation="False" CommandArgument='<%# Eval("OrgID") + "/" + Eval("UnitID") + "/" + Eval("EventID") %>'
                                    OnClick="LinkEventHandler" SkinID="smalCalendarlLnk" Text='<%# Eval("Event") %>'
                                    ToolTip='<%# Eval("EventDetail") %>' ForeColor='<%# Eval("RDStatusColor") %>'></asp:LinkButton>
                               </ItemTemplate>
<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
</asp:DataList>


                    </asp:Panel>
</asp:TableCell>
<asp:TableCell runat="server" HorizontalAlign="Left" BorderColor="Silver" VerticalAlign="Top" Width="14%" ID="TableCell31"><asp:Label runat="server" SkinID="Unicodelbl" Font-Bold="True" ID="Day24"></asp:Label>

<br />
                    <br />
                    <asp:Panel runat="server" Width="140px" Font-Names="Verdana" ForeColor="Red" Height="90px" ScrollBars="Auto" ID="Panel24">
                        <asp:DataList runat="server" Font-Size="2px" Width="123px" CellPadding="4" ID="DataList24" ForeColor="#333333" RepeatColumns="1">
<SelectedItemStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedItemStyle>

<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

<ItemStyle BackColor="White" ForeColor="#333333"></ItemStyle>
<ItemTemplate>
                                <asp:LinkButton ID="LinkButton24" runat="server" CausesValidation="False" CommandArgument='<%# Eval("OrgID") + "/" + Eval("UnitID") + "/" + Eval("EventID") %>'
                                    OnClick="LinkEventHandler" SkinID="smalCalendarlLnk" Text='<%# Eval("Event") %>'
                                    ToolTip='<%# Eval("EventDetail") %>' ForeColor='<%# Eval("RDStatusColor") %>'></asp:LinkButton>
                               </ItemTemplate>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
</asp:DataList>


                    </asp:Panel>
</asp:TableCell>
<asp:TableCell runat="server" HorizontalAlign="Left" BorderColor="Silver" VerticalAlign="Top" Width="14%" ID="TableCell32"><asp:Label runat="server" SkinID="Unicodelbl" Font-Bold="True" ID="Day25"></asp:Label>

<br />
                    <br />
                    <asp:Panel runat="server" Width="140px" Font-Names="Verdana" ForeColor="Red" Height="90px" ScrollBars="Auto" ID="Panel25">
                        <asp:DataList runat="server" Font-Size="2px" Width="123px" CellPadding="4" ID="DataList25" ForeColor="#333333" RepeatColumns="1">
<SelectedItemStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedItemStyle>

<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

<ItemStyle BackColor="White" ForeColor="#333333"></ItemStyle>
<ItemTemplate>
                                <asp:LinkButton ID="LinkButton25" runat="server" CausesValidation="False" CommandArgument='<%# Eval("OrgID") + "/" + Eval("UnitID") + "/" + Eval("EventID") %>'
                                    OnClick="LinkEventHandler" SkinID="smalCalendarlLnk" Text='<%# Eval("Event") %>'
                                    ToolTip='<%# Eval("EventDetail") %>' ForeColor='<%# Eval("RDStatusColor") %>'></asp:LinkButton>
                               </ItemTemplate>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
</asp:DataList>


                    </asp:Panel>
</asp:TableCell>
<asp:TableCell runat="server" HorizontalAlign="Left" BorderColor="Silver" VerticalAlign="Top" Width="14%" ID="TableCell33"><asp:Label runat="server" SkinID="Unicodelbl" Font-Bold="True" ID="Day26"></asp:Label>

<br />
                    <br />
                    <asp:Panel runat="server" Width="140px" Font-Names="Verdana" ForeColor="Red" Height="90px" ScrollBars="Auto" ID="Panel26">
                        <asp:DataList runat="server" Font-Size="2px" Width="123px" CellPadding="4" ID="DataList26" ForeColor="#333333" RepeatColumns="1">
<SelectedItemStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedItemStyle>

<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

<ItemStyle BackColor="White" ForeColor="#333333"></ItemStyle>
<ItemTemplate>
                                <asp:LinkButton ID="LinkButton26" runat="server" CausesValidation="False" CommandArgument='<%# Eval("OrgID") + "/" + Eval("UnitID") + "/" + Eval("EventID") %>'
                                    OnClick="LinkEventHandler" SkinID="smalCalendarlLnk" Text='<%# Eval("Event") %>'
                                    ToolTip='<%# Eval("EventDetail") %>' ForeColor='<%# Eval("RDStatusColor") %>'></asp:LinkButton>
                               </ItemTemplate>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
</asp:DataList>


                    </asp:Panel>
</asp:TableCell>
<asp:TableCell runat="server" HorizontalAlign="Left" BorderColor="Silver" VerticalAlign="Top" Width="14%" ID="TableCell34"><asp:Label runat="server" SkinID="Unicodelbl" Font-Bold="True" ID="Day27"></asp:Label>

<br />
                    <br />
                    <asp:Panel runat="server" Width="140px" Font-Names="Verdana" ForeColor="Red" Height="90px" ScrollBars="Auto" ID="Panel27">
                        <asp:DataList runat="server" Font-Size="2px" Width="123px" CellPadding="4" ID="DataList27" ForeColor="#333333" RepeatColumns="1">
<SelectedItemStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedItemStyle>

<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

<ItemStyle BackColor="White" ForeColor="#333333"></ItemStyle>
<ItemTemplate>
                                <asp:LinkButton ID="LinkButton27" runat="server" CausesValidation="False" CommandArgument='<%# Eval("OrgID") + "/" + Eval("UnitID") + "/" + Eval("EventID") %>'
                                    OnClick="LinkEventHandler" SkinID="smalCalendarlLnk" Text='<%# Eval("Event") %>'
                                    ToolTip='<%# Eval("EventDetail") %>' ForeColor='<%# Eval("RDStatusColor") %>'></asp:LinkButton>
                               </ItemTemplate>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
</asp:DataList>


                    </asp:Panel>
</asp:TableCell>
<asp:TableCell runat="server" HorizontalAlign="Left" BorderColor="Silver" VerticalAlign="Top" Width="16%" ID="TableCell35"><asp:Label runat="server" SkinID="Unicodelbl" Font-Bold="True" ID="Day28"></asp:Label>

<br />
                    <br />
                    <asp:Panel runat="server" Width="140px" Font-Names="Verdana" ForeColor="Red" Height="90px" ScrollBars="Auto" ID="Panel28">
                        <asp:DataList runat="server" Font-Size="2px" Width="123px" CellPadding="4" ID="DataList28" ForeColor="#333333" RepeatColumns="1">
<SelectedItemStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedItemStyle>

<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

<ItemStyle BackColor="White" ForeColor="#333333"></ItemStyle>
<ItemTemplate>
                                <asp:LinkButton ID="LinkButton28" runat="server" CausesValidation="False" CommandArgument='<%# Eval("OrgID") + "/" + Eval("UnitID") + "/" + Eval("EventID") %>'
                                    OnClick="LinkEventHandler" SkinID="smalCalendarlLnk" Text='<%# Eval("Event") %>'
                                    ToolTip='<%# Eval("EventDetail") %>' ForeColor='<%# Eval("RDStatusColor") %>'></asp:LinkButton>
                               </ItemTemplate>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
</asp:DataList>


                    </asp:Panel>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow runat="server" Height="100px" ID="TableRow6"><asp:TableCell runat="server" HorizontalAlign="Left" BorderColor="Silver" VerticalAlign="Top" Width="14%" ID="TableCell36"><asp:Label runat="server" SkinID="Unicodelbl" Font-Bold="True" ID="Day29"></asp:Label>

<br />
                    <br />
                    <asp:Panel runat="server" Width="140px" Font-Names="Verdana" ForeColor="Red" Height="90px" ScrollBars="Auto" ID="Panel29">
                        <asp:DataList runat="server" Font-Size="2px" Width="123px" CellPadding="4" ID="DataList29" ForeColor="#333333" RepeatColumns="1">
<SelectedItemStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedItemStyle>

<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

<ItemStyle BackColor="White" ForeColor="#333333"></ItemStyle>
<ItemTemplate>
                                <asp:LinkButton ID="LinkButton29" runat="server" CausesValidation="False" CommandArgument='<%# Eval("OrgID") + "/" + Eval("UnitID") + "/" + Eval("EventID") %>'
                                    OnClick="LinkEventHandler" SkinID="smalCalendarlLnk" Text='<%# Eval("Event") %>'
                                    ToolTip='<%# Eval("EventDetail") %>' ForeColor='<%# Eval("RDStatusColor") %>'></asp:LinkButton>
                               </ItemTemplate>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
</asp:DataList>


                    </asp:Panel>
</asp:TableCell>
<asp:TableCell runat="server" HorizontalAlign="Left" BorderColor="Silver" VerticalAlign="Top" Width="14%" ID="TableCell37"><asp:Label runat="server" SkinID="Unicodelbl" Font-Bold="True" ID="Day30"></asp:Label>

<br />
                    <br />
                    <asp:Panel runat="server" Width="140px" Font-Names="Verdana" ForeColor="Red" Height="90px" ScrollBars="Auto" ID="Panel30">
                        <asp:DataList runat="server" Font-Size="2px" Width="123px" CellPadding="4" ID="DataList30" ForeColor="#333333" RepeatColumns="1">
<SelectedItemStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedItemStyle>

<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

<ItemStyle BackColor="White" ForeColor="#333333"></ItemStyle>
<ItemTemplate>
                                <asp:LinkButton ID="LinkButton30" runat="server" CausesValidation="False" CommandArgument='<%# Eval("OrgID") + "/" + Eval("UnitID") + "/" + Eval("EventID") %>'
                                    OnClick="LinkEventHandler" SkinID="smalCalendarlLnk" Text='<%# Eval("Event") %>'
                                    ToolTip='<%# Eval("EventDetail") %>' ForeColor='<%# Eval("RDStatusColor") %>'></asp:LinkButton>
                               </ItemTemplate>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
</asp:DataList>


                    </asp:Panel>
</asp:TableCell>
<asp:TableCell runat="server" HorizontalAlign="Left" BorderColor="Silver" VerticalAlign="Top" Width="14%" ID="TableCell38"><asp:Label runat="server" SkinID="&quot;Unicodelbl&quot;&quot;" Font-Bold="True" ID="Day31"></asp:Label>

<br />
                    <br />
                    <asp:Panel runat="server" Width="140px" Font-Names="Verdana" ForeColor="Red" Height="90px" ScrollBars="Auto" ID="Panel31">
                        <asp:DataList runat="server" Font-Size="2px" Width="123px" CellPadding="4" ID="DataList31" ForeColor="#333333" RepeatColumns="1">
<SelectedItemStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedItemStyle>

<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

<ItemStyle BackColor="White" ForeColor="#333333"></ItemStyle>
<ItemTemplate>
                                <asp:LinkButton ID="LinkButton31" runat="server" CausesValidation="False" CommandArgument='<%# Eval("OrgID") + "/" + Eval("UnitID") + "/" + Eval("EventID") %>'
                                    OnClick="LinkEventHandler" SkinID="smalCalendarlLnk" Text='<%# Eval("Event") %>'
                                    ToolTip='<%# Eval("EventDetail") %>' ForeColor='<%# Eval("RDStatusColor") %>'></asp:LinkButton>
                               </ItemTemplate>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
</asp:DataList>


                    </asp:Panel>
</asp:TableCell>
<asp:TableCell runat="server" HorizontalAlign="Left" BorderColor="Silver" VerticalAlign="Top" Width="14%" ID="TableCell39"><asp:Label runat="server" SkinID="&quot;Unicodelbl&quot;&quot;" Font-Bold="True" ID="Day32"></asp:Label>

<br />
                    <br />
                    <asp:Panel runat="server" Width="140px" Font-Names="Verdana" ForeColor="Red" Height="90px" ScrollBars="Auto" ID="Panel32">
                        <asp:DataList runat="server" Font-Size="2px" Width="123px" CellPadding="4" ID="DataList32" ForeColor="#333333" RepeatColumns="1">
<SelectedItemStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedItemStyle>

<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

<ItemStyle BackColor="White" ForeColor="#333333"></ItemStyle>
<ItemTemplate>
                                <asp:LinkButton ID="LinkButton32" runat="server" CausesValidation="False" CommandArgument='<%# Eval("OrgID") + "/" + Eval("UnitID") + "/" + Eval("EventID") %>'
                                    OnClick="LinkEventHandler" SkinID="smalCalendarlLnk" Text='<%# Eval("Event") %>'
                                    ToolTip='<%# Eval("EventDetail") %>' ForeColor='<%# Eval("RDStatusColor") %>'></asp:LinkButton>
                               </ItemTemplate>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
</asp:DataList>


                    </asp:Panel>
</asp:TableCell>
<asp:TableCell runat="server" HorizontalAlign="Left" BorderColor="Silver" VerticalAlign="Top" Width="14%" ID="TableCell40"><asp:Label runat="server" SkinID="&quot;Unicodelbl&quot;&quot;" Font-Bold="True" ID="Day33"></asp:Label>

<br />
                    <br />
                    <asp:Panel runat="server" Width="140px" Font-Names="Verdana" ForeColor="Red" Height="90px" ScrollBars="Auto" ID="Panel33">
                        <asp:DataList runat="server" Font-Size="2px" Width="123px" CellPadding="4" ID="DataList33" ForeColor="#333333" RepeatColumns="1">
<SelectedItemStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedItemStyle>

<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

<ItemStyle BackColor="White" ForeColor="#333333"></ItemStyle>
<ItemTemplate>
                                <asp:LinkButton ID="LinkButton33" runat="server" CausesValidation="False" CommandArgument='<%# Eval("OrgID") + "/" + Eval("UnitID") + "/" + Eval("EventID") %>'
                                    OnClick="LinkEventHandler" SkinID="smalCalendarlLnk" Text='<%# Eval("Event") %>'
                                    ToolTip='<%# Eval("EventDetail") %>' ForeColor='<%# Eval("RDStatusColor") %>'></asp:LinkButton>
                               </ItemTemplate>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
</asp:DataList>


                    </asp:Panel>
</asp:TableCell>
<asp:TableCell runat="server" HorizontalAlign="Left" BorderColor="Silver" VerticalAlign="Top" Width="14%" ID="TableCell41"><asp:Label runat="server" SkinID="&quot;Unicodelbl&quot;&quot;" Font-Bold="True" ID="Day34"></asp:Label>

<br />
                    <br />
                    <asp:Panel runat="server" Width="140px" Font-Names="Verdana" ForeColor="Red" Height="90px" ScrollBars="Auto" ID="Panel34">
                        <asp:DataList runat="server" Font-Size="2px" Width="123px" CellPadding="4" ID="DataList34" ForeColor="#333333" RepeatColumns="1">
<SelectedItemStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedItemStyle>

<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

<ItemStyle BackColor="White" ForeColor="#333333"></ItemStyle>
<ItemTemplate>
                                <asp:LinkButton ID="LinkButton34" runat="server" CausesValidation="False" CommandArgument='<%# Eval("OrgID") + "/" + Eval("UnitID") + "/" + Eval("EventID") %>'
                                    OnClick="LinkEventHandler" SkinID="smalCalendarlLnk" Text='<%# Eval("Event") %>'
                                    ToolTip='<%# Eval("EventDetail") %>' ForeColor='<%# Eval("RDStatusColor") %>'></asp:LinkButton>
                               </ItemTemplate>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
</asp:DataList>


                    </asp:Panel>
</asp:TableCell>
<asp:TableCell runat="server" HorizontalAlign="Left" BorderColor="Silver" VerticalAlign="Top" Width="16%" ID="TableCell42"><asp:Label runat="server" SkinID="&quot;Unicodelbl&quot;&quot;" Font-Bold="True" ID="Day35"></asp:Label>

<br />
                    <br />
                    <asp:Panel runat="server" Width="140px" Font-Names="Verdana" ForeColor="Red" Height="90px" ScrollBars="Auto" ID="Panel35">
                        <asp:DataList runat="server" Font-Size="2px" Width="123px" CellPadding="4" ID="DataList35" ForeColor="#333333" RepeatColumns="1">
<SelectedItemStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedItemStyle>

<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

<ItemStyle BackColor="White" ForeColor="#333333"></ItemStyle>
<ItemTemplate>
                                <asp:LinkButton ID="LinkButton35" runat="server" CausesValidation="False" CommandArgument='<%# Eval("OrgID") + "/" + Eval("UnitID") + "/" + Eval("EventID") %>'
                                    OnClick="LinkEventHandler" SkinID="smalCalendarlLnk" Text='<%# Eval("Event") %>'
                                    ToolTip='<%# Eval("EventDetail") %>' ForeColor='<%# Eval("RDStatusColor") %>'></asp:LinkButton>
                               </ItemTemplate>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
</asp:DataList>


                    </asp:Panel>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow runat="server" Height="100px" ID="TableRow7"><asp:TableCell runat="server" HorizontalAlign="Left" BorderColor="Silver" VerticalAlign="Top" Width="14%" ID="TableCell43"><asp:Label runat="server" SkinID="&quot;Unicodelbl&quot;&quot;" Font-Bold="True" ID="Day36"></asp:Label>

<br />
                    <br />
                    <asp:Panel runat="server" Width="140px" Font-Names="Verdana" ForeColor="Red" Height="90px" ScrollBars="Auto" ID="Panel36">
                        <asp:DataList runat="server" Font-Size="2px" Width="123px" CellPadding="4" ID="DataList36" ForeColor="#333333" RepeatColumns="1">
<SelectedItemStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedItemStyle>

<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

<ItemStyle BackColor="White" ForeColor="#333333"></ItemStyle>
<ItemTemplate>
                                <asp:LinkButton ID="LinkButton36" runat="server" CausesValidation="False" CommandArgument='<%# Eval("OrgID") + "/" + Eval("UnitID") + "/" + Eval("EventID") %>'
                                    OnClick="LinkEventHandler" SkinID="smalCalendarlLnk" Text='<%# Eval("Event") %>'
                                    ToolTip='<%# Eval("EventDetail") %>' ForeColor='<%# Eval("RDStatusColor") %>'></asp:LinkButton>
                               </ItemTemplate>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
</asp:DataList>


                    </asp:Panel>
</asp:TableCell>
<asp:TableCell runat="server" HorizontalAlign="Left" BorderColor="Silver" VerticalAlign="Top" Width="14%" ID="TableCell44"><asp:Label runat="server" SkinID="&quot;Unicodelbl&quot;&quot;" Font-Bold="True" ID="Day37"></asp:Label>

<br />
                    <br />
                    <asp:Panel runat="server" Width="140px" Font-Names="Verdana" ForeColor="Red" Height="90px" ScrollBars="Auto" ID="Panel37">
                        <asp:DataList runat="server" Font-Size="2px" Width="123px" CellPadding="4" ID="DataList37" ForeColor="#333333" RepeatColumns="1">
<SelectedItemStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedItemStyle>

<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

<ItemStyle BackColor="White" ForeColor="#333333"></ItemStyle>
<ItemTemplate>
                                <asp:LinkButton ID="LinkButton37" runat="server" CausesValidation="False" CommandArgument='<%# Eval("OrgID") + "/" + Eval("UnitID") + "/" + Eval("EventID") %>'
                                    OnClick="LinkEventHandler" SkinID="smalCalendarlLnk" Text='<%# Eval("Event") %>'
                                    ToolTip='<%# Eval("EventDetail") %>' ForeColor='<%# Eval("RDStatusColor") %>'></asp:LinkButton>
                               </ItemTemplate>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
</asp:DataList>


                    </asp:Panel>
</asp:TableCell>
<asp:TableCell runat="server" HorizontalAlign="Left" BorderColor="Silver" VerticalAlign="Top" Width="14%" ID="TableCell45"><asp:Label runat="server" SkinID="&quot;Unicodelbl&quot;&quot;" Font-Bold="True" ID="Day38"></asp:Label>

<br />
                    <br />
                    <asp:Panel runat="server" Width="140px" Font-Names="Verdana" ForeColor="Red" Height="90px" ScrollBars="Auto" ID="Panel38">
                        <asp:DataList runat="server" Font-Size="2px" Width="123px" CellPadding="4" ID="DataList38" ForeColor="#333333" RepeatColumns="1">
<SelectedItemStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedItemStyle>

<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

<ItemStyle BackColor="White" ForeColor="#333333"></ItemStyle>
<ItemTemplate>
                                <asp:LinkButton ID="LinkButton38" runat="server" CausesValidation="False" CommandArgument='<%# Eval("OrgID") + "/" + Eval("UnitID") + "/" + Eval("EventID") %>'
                                    OnClick="LinkEventHandler" SkinID="smalCalendarlLnk" Text='<%# Eval("Event") %>'
                                    ToolTip='<%# Eval("EventDetail") %>' ForeColor='<%# Eval("RDStatusColor") %>'></asp:LinkButton>
                               </ItemTemplate>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
</asp:DataList>


                    </asp:Panel>
</asp:TableCell>
<asp:TableCell runat="server" HorizontalAlign="Left" BorderColor="Silver" VerticalAlign="Top" Width="14%" ID="TableCell46"><asp:Label runat="server" SkinID="&quot;Unicodelbl&quot;&quot;" Font-Bold="True" ID="Day39"></asp:Label>

<br />
                    <br />
                    <asp:Panel runat="server" Width="140px" Font-Names="Verdana" ForeColor="Red" Height="90px" ScrollBars="Auto" ID="Panel39">
                        <asp:DataList runat="server" Font-Size="2px" Width="123px" CellPadding="4" ID="DataList39" ForeColor="#333333" RepeatColumns="1">
<SelectedItemStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedItemStyle>

<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

<ItemStyle BackColor="White" ForeColor="#333333"></ItemStyle>
<ItemTemplate>
                                <asp:LinkButton ID="LinkButton39" runat="server" CausesValidation="False" CommandArgument='<%# Eval("OrgID") + "/" + Eval("UnitID") + "/" + Eval("EventID") %>'
                                    OnClick="LinkEventHandler" SkinID="smalCalendarlLnk" Text='<%# Eval("Event") %>'
                                    ToolTip='<%# Eval("EventDetail") %>' ForeColor='<%# Eval("RDStatusColor") %>'></asp:LinkButton>
                               </ItemTemplate>
<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
</asp:DataList>


                    </asp:Panel>
</asp:TableCell>
<asp:TableCell runat="server" HorizontalAlign="Left" BorderColor="Silver" VerticalAlign="Top" Width="14%" ID="TableCell47"><asp:Label runat="server" SkinID="&quot;Unicodelbl&quot;&quot;" Font-Bold="True" ID="Day40"></asp:Label>

<br />
                    <br />
                    <asp:Panel runat="server" Width="140px" Font-Names="Verdana" ForeColor="Red" Height="90px" ScrollBars="Auto" ID="Panel40">
                        <asp:DataList runat="server" Font-Size="2px" Width="123px" CellPadding="4" ID="DataList40" ForeColor="#333333" RepeatColumns="1">
<SelectedItemStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedItemStyle>

<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

<ItemStyle BackColor="White" ForeColor="#333333"></ItemStyle>
<ItemTemplate>
                                <asp:LinkButton ID="LinkButton40" runat="server" CausesValidation="False" CommandArgument='<%# Eval("OrgID") + "/" + Eval("UnitID") + "/" + Eval("EventID") %>'
                                    OnClick="LinkEventHandler" SkinID="smalCalendarlLnk" Text='<%# Eval("Event") %>'
                                    ToolTip='<%# Eval("EventDetail") %>' ForeColor='<%# Eval("RDStatusColor") %>'></asp:LinkButton>
                               </ItemTemplate>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
</asp:DataList>


                    </asp:Panel>
</asp:TableCell>
<asp:TableCell runat="server" HorizontalAlign="Left" BorderColor="Silver" VerticalAlign="Top" Width="14%" ID="TableCell48"><asp:Label runat="server" SkinID="&quot;Unicodelbl&quot;&quot;" Font-Bold="True" ID="Day41"></asp:Label>

<br />
                    <br />
                    <asp:Panel runat="server" Width="140px" Font-Names="Verdana" ForeColor="Red" Height="90px" ScrollBars="Auto" ID="Panel41">
                        <asp:DataList runat="server" Font-Size="2px" Width="123px" CellPadding="4" ID="DataList41" ForeColor="#333333" RepeatColumns="1">
<SelectedItemStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedItemStyle>

<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

<ItemStyle BackColor="White" ForeColor="#333333"></ItemStyle>
<ItemTemplate>
                                <asp:LinkButton ID="LinkButton41" runat="server" CausesValidation="False" CommandArgument='<%# Eval("OrgID") + "/" + Eval("UnitID") + "/" + Eval("EventID") %>'
                                    OnClick="LinkEventHandler" SkinID="smalCalendarlLnk" Text='<%# Eval("Event") %>'
                                    ToolTip='<%# Eval("EventDetail") %>' ForeColor='<%# Eval("RDStatusColor") %>'></asp:LinkButton>
                               </ItemTemplate>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
</asp:DataList>


                    </asp:Panel>
</asp:TableCell>
<asp:TableCell runat="server" HorizontalAlign="Left" BorderColor="Silver" VerticalAlign="Top" Width="16%" ID="TableCell49"><asp:Label runat="server" SkinID="&quot;Unicodelbl&quot;&quot;" Font-Bold="True" ID="Day42"></asp:Label>

<br />
                    <br />
                    <asp:Panel runat="server" Width="140px" Font-Names="Verdana" ForeColor="Red" Height="90px" ScrollBars="Auto" ID="Panel42">
                        <asp:DataList runat="server" Font-Size="2px" Width="123px" CellPadding="4" ID="DataList42" ForeColor="#333333" RepeatColumns="1">
<SelectedItemStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedItemStyle>

<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

<ItemStyle BackColor="White" ForeColor="#333333"></ItemStyle>
<ItemTemplate>
                                <asp:LinkButton ID="LinkButton42" runat="server" CausesValidation="False" CommandArgument='<%# Eval("OrgID") + "/" + Eval("UnitID") + "/" + Eval("EventID") %>'
                                    OnClick="LinkEventHandler" SkinID="smalCalendarlLnk" Text='<%# Eval("Event") %>'
                                    ToolTip='<%# Eval("EventDetail") %>' ForeColor='<%# Eval("RDStatusColor") %>'></asp:LinkButton>
                               </ItemTemplate>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
</asp:DataList>


                    </asp:Panel>
</asp:TableCell>
</asp:TableRow>
</asp:Table> 
</contenttemplate>
            <triggers>
<asp:AsyncPostBackTrigger ControlID="OkButton" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="ImageButton1" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="imgBtnClose" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnOutDoorClose" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="imgComment" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
        </asp:UpdatePanel>
    </div>
    
    <!-- NB::  Code for  Meeting Event Set------------------------------------------------------------ -->

    <div id="dvMeeting" style="OVERFLOW: auto; WIDTH: 561px;" class="loading-invisible" >
                        
                        <asp:UpdatePanel id="mydiv" runat="server">
                            <contenttemplate>
<TABLE style="BORDER-LEFT-COLOR: black; BORDER-BOTTOM-COLOR: black; BORDER-TOP-COLOR: black; BORDER-RIGHT-COLOR: black" cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR><TD style="HEIGHT: 4px" vAlign=top align=center width="80%"><TABLE style="WIDTH: 100%; HEIGHT: 56px" cellSpacing=0 cellPadding=0><TBODY><TR><TD style="WIDTH: 551px; HEIGHT: 69px" align=center><DIV style="WIDTH: 529px" id="divhead" title="सार्नको निम्त्ति कि्लक गर्नुहोस्" onclick="begindrag(event)">&nbsp;</DIV></TD><TD style="WIDTH: 5px; HEIGHT: 69px" vAlign=bottom><asp:ImageButton style="PADDING-RIGHT: 13px" id="ImageButton1" onclick="ImageButton1_Click" runat="server" ImageUrl="~/MODULES/OAS/Images/btn_cancel.gif" __designer:wfdid="w3" align="right" OnClientClick="javascript:hideDiv();"></asp:ImageButton> &nbsp; &nbsp; &nbsp; </TD></TR></TBODY></TABLE></TD></TR><TR><TD style="HEIGHT: 2px" vAlign=top>&nbsp;<asp:Label id="lblCreateMeetingStatus" runat="server" SkinID="UnicodeHeadlbl" Font-Bold="False" __designer:wfdid="w4"></asp:Label></TD></TR><TR><TD style="PADDING-LEFT: 30px; HEIGHT: 19px" class="tblTDleft" align=left>&nbsp;<asp:ImageButton id="imgBtnExpand1" runat="server" ImageUrl="~/MODULES/OAS/Images/expand.jpg" __designer:wfdid="w5"></asp:ImageButton>&nbsp; <asp:Label id="lblTest" runat="server" Text="Label" SkinID="Unicodelbl" __designer:wfdid="w6"></asp:Label></TD></TR><TR><TD align=center><asp:Panel style="POSITION: static" id="pnlMeeting" runat="server" Width="95%" __designer:wfdid="w7" BorderWidth="1px" BorderStyle="Solid" BorderColor="#c8cde4"><TABLE style="BORDER-LEFT-COLOR: black; BORDER-BOTTOM-COLOR: black; WIDTH: 100%; BORDER-TOP-COLOR: black; BORDER-RIGHT-COLOR: black" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD class="tblTDRight" align=left>&nbsp;</TD></TR><TR><TD style="HEIGHT: 30px" class="tblTDRight"><asp:Label id="lblMeetingDate" runat="server" Text="एपोइन्टमेन्ट मिति" SkinID="Unicodelbl" __designer:wfdid="w8"></asp:Label> &nbsp;<asp:Label id="Label418" runat="server" CssClass="simplelabel" Text="*" ForeColor="Red" EnableTheming="False" __designer:wfdid="w9"></asp:Label> </TD><TD style="HEIGHT: 30px" class="tblTDLeft" colSpan=3><asp:TextBox id="txtMeetingDate_rqd" tabIndex=2 runat="server" Width="445px" SkinID="Unicodetxt" Font-Names="Arial Unicode MS" __designer:wfdid="w10" ToolTip="Meeting Date" ReadOnly="True"></asp:TextBox> </TD></TR><TR><TD style="HEIGHT: 30px" class="tblTDRight"><asp:Label id="lblStartTime" runat="server" Text="शरुहुने समय" SkinID="Unicodelbl" __designer:wfdid="w11"></asp:Label> &nbsp;<asp:Label id="Label419" runat="server" CssClass="simplelabel" Text="*" ForeColor="Red" EnableTheming="False" __designer:wfdid="w12"></asp:Label> </TD><TD style="WIDTH: 169px; HEIGHT: 30px" class="tblTDLeft"><asp:DropDownList id="drpHr1_rqd" tabIndex=3 runat="server" Width="62px" SkinID="Unicodeddl" __designer:wfdid="w13" ToolTip="घण्टा"><asp:ListItem Value="0">घण्टा</asp:ListItem>
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
</asp:DropDownList>&nbsp;&nbsp; <asp:Label id="Label7" runat="server" Width="6px" Text="                   :" SkinID="Unicodelbl" Font-Bold="True" __designer:wfdid="w14"></asp:Label>&nbsp; &nbsp;<asp:DropDownList id="drpMin1_rqd" tabIndex=4 runat="server" Width="66px" SkinID="Unicodeddl" __designer:wfdid="w15" ToolTip="मिनेट"><asp:ListItem Value="0">मिनेट</asp:ListItem>
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
</asp:DropDownList> </TD><TD style="WIDTH: 128px; HEIGHT: 30px" class="tblTDRight"><asp:Label id="lblEndTime" runat="server" Width="91px" Text="सकिने समय" SkinID="Unicodelbl" __designer:wfdid="w3"></asp:Label>&nbsp; <asp:Label id="Label6" runat="server" CssClass="simplelabel" Text="*" ForeColor="Red" EnableTheming="False" __designer:wfdid="w7"></asp:Label>&nbsp; &nbsp; </TD><TD style="WIDTH: 206px; HEIGHT: 30px" class="tblTDLeft"><asp:DropDownList id="drpHr2_rqd" tabIndex=5 runat="server" Width="62px" SkinID="Unicodeddl" __designer:wfdid="w4" ToolTip="घण्टा"><asp:ListItem Value="0">घण्टा</asp:ListItem>
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
</asp:DropDownList>&nbsp; <asp:Label id="Label5" runat="server" Width="6px" Text=":" SkinID="Unicodelbl" Font-Bold="True" __designer:wfdid="w5"></asp:Label>&nbsp; <asp:DropDownList id="drpMin2_rqd" tabIndex=6 runat="server" Width="66px" SkinID="Unicodeddl" __designer:wfdid="w6" ToolTip="मिनेट"><asp:ListItem Value="0">मिनेट</asp:ListItem>
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
</asp:DropDownList></TD></TR><TR><TD style="HEIGHT: 25px" class="tblTDRight"><asp:Label id="lblStatus" runat="server" Text="अवस्था" SkinID="Unicodelbl" __designer:wfdid="w16"></asp:Label>&nbsp;&nbsp;<asp:Label id="Label9" runat="server" CssClass="simplelabel" Text="*" ForeColor="Red" EnableTheming="False" __designer:wfdid="w17"></asp:Label> </TD><TD style="WIDTH: 169px; HEIGHT: 25px" class="tblTDLeft"><asp:DropDownList id="drpStatus_rqd" tabIndex=10 runat="server" Width="158px" SkinID="Unicodeddl" __designer:wfdid="w18" ToolTip="अवस्था"></asp:DropDownList></TD><TD style="WIDTH: 128px; HEIGHT: 25px" class="tblTDRight"><asp:Label id="Label10" runat="server" Width="124px" Text="Label" __designer:wfdid="w8" Visible="False"></asp:Label>&nbsp; </TD><TD style="WIDTH: 206px; HEIGHT: 25px" class="tblTDLeft"><asp:Label id="Label8" runat="server" Width="164px" Text="Label" __designer:wfdid="w8" Visible="False"></asp:Label></TD></TR><TR><TD style="HEIGHT: 25px" class="tblTDRight"><asp:Label id="lblVenue" runat="server" Text="स्थान" SkinID="Unicodelbl" __designer:wfdid="w19"></asp:Label>&nbsp;&nbsp;<asp:Label id="Label408" runat="server" CssClass="simplelabel" Text="*" ForeColor="Red" EnableTheming="False" __designer:wfdid="w20"></asp:Label> </TD><TD style="WIDTH: 169px; HEIGHT: 25px" class="tblTDLeft"><asp:TextBox id="txtVenue_rqd" tabIndex=11 runat="server" Width="153px" __designer:wfdid="w21" ToolTip="स्थल" MaxLength="25"></asp:TextBox></TD></TR><TR></TR><TR><TD style="HEIGHT: 29px" class="tblTDRight"><asp:Label id="lblMeetingSubject" runat="server" Width="80px" Text="बिषय" SkinID="Unicodelbl" __designer:wfdid="w22"></asp:Label> <asp:Label id="Label48" runat="server" CssClass="simplelabel" Text="*" ForeColor="Red" EnableTheming="False" __designer:wfdid="w23"></asp:Label> </TD><TD style="HEIGHT: 29px" class="tblTDLeft" vAlign=middle colSpan=3><asp:TextBox id="txtSubject_rqd" tabIndex=12 runat="server" Width="445px" Height="64px" SkinID="Unicodetxt" __designer:wfdid="w24" ToolTip="विषय" MaxLength="120" TextMode="MultiLine"></asp:TextBox>&nbsp; <ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender2" runat="server" TargetControlID="txtVenue_rqd" __designer:wfdid="w26" ValidChars='" "' FilterType="Custom, Numbers, UppercaseLetters, LowercaseLetters"></ajaxToolkit:FilteredTextBoxExtender></TD></TR><TR><TD style="HEIGHT: 27px" class="tblTDRight"><asp:Label id="lblComment" runat="server" Text="कमेन्ट  " SkinID="Unicodelbl" __designer:wfdid="w27" Visible="False"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label id="Label3" runat="server" CssClass="simplelabel" Text="*" ForeColor="Red" EnableTheming="False" __designer:wfdid="w28" Visible="False"></asp:Label></TD><TD style="HEIGHT: 27px" class="tblTDLeft" vAlign=middle colSpan=3><asp:TextBox id="txtComment" runat="server" Width="445px" Height="63px" __designer:wfdid="w29" ToolTip="कमेन्ट" Visible="False" MaxLength="75" TextMode="MultiLine" AutoPostBack="True"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 81px" height=1>&nbsp;</TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR><TD style="PADDING-LEFT: 30px; HEIGHT: 1px" class="tblleft" align=left>&nbsp;<asp:ImageButton id="imgBtnExpand3" tabIndex=13 runat="server" ImageUrl="~/MODULES/OAS/Images/collapse.jpg" __designer:wfdid="w30"></asp:ImageButton>&nbsp; <asp:Label id="lblExpandStatus3" runat="server" Text="Label" SkinID="Unicodelbl" __designer:wfdid="w31"></asp:Label></TD></TR><TR><TD align=center><asp:Panel style="POSITION: static" id="pnlParticipant" runat="server" Width="95%" __designer:wfdid="w32" BorderWidth="1px" BorderStyle="Solid" BorderColor="#c8cde4"><TABLE style="BORDER-LEFT-COLOR: black; BORDER-BOTTOM-COLOR: black; WIDTH: 96%; BORDER-TOP-COLOR: black; BORDER-RIGHT-COLOR: black" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 128px" class="tblTDRight">&nbsp;</TD></TR><TR><TD style="WIDTH: 128px; HEIGHT: 24px" class="tblTDRight">&nbsp;&nbsp; </TD><TD style="WIDTH: 363px; HEIGHT: 24px" class="tblTDRight" colSpan=3>&nbsp;<asp:Button id="btnIndoor" tabIndex=14 onclick="btnIndoor_Click" runat="server" Text="Indoor" SkinID="Normal" __designer:wfdid="w33"></asp:Button> <asp:Button id="btnOutdoor" tabIndex=15 onclick="btnOutdoor_Click" runat="server" Text="Outdoor" SkinID="Normal" __designer:wfdid="w34"></asp:Button></TD></TR><TR><TD style="WIDTH: 128px; HEIGHT: 269px" class="tblTDRight">&nbsp;&nbsp; </TD><TD style="WIDTH: 363px; HEIGHT: 269px" class="tblTDLeft" vAlign=top colSpan=3>&nbsp;&nbsp; <DIV style="OVERFLOW: auto; WIDTH: 100%; HEIGHT: 230px" border="0"><asp:GridView id="grdAppointee" tabIndex=16 runat="server" ForeColor="#333333" __designer:wfdid="w35" CellPadding="4" GridLines="None" AutoGenerateColumns="False" OnRowDataBound="grdAppointee_RowDataBound" OnRowDeleting="grdAppointee_RowDeleting" OnRowCreated="grdAppointee_RowCreated" OnSelectedIndexChanged="grdAppointee_SelectedIndexChanged">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:TemplateField HeaderText="सि.नं.">
<ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
<ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>.
                                           
                                                                            
                                
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="appointeeID"></asp:BoundField>
<asp:BoundField DataField="Appointee" HeaderText="सहभागीको नाम"></asp:BoundField>
<asp:BoundField DataField="IsIndoorAppointee" HeaderText="सहभागीको प्रकार"></asp:BoundField>
<asp:TemplateField HeaderText="स्थिति"><ItemTemplate>
<asp:CheckBox id="chkStatus" runat="server" __designer:wfdid="w82" AutoPostBack="True" OnCheckedChanged="chkStatus_CheckedChanged"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="Action"></asp:BoundField>
<asp:BoundField DataField="EntryOn" HeaderText="EntryOn"></asp:BoundField>
<asp:CommandField ShowDeleteButton="True" DeleteText="Remove"></asp:CommandField>
<asp:BoundField DataField="Flag" HeaderText="flag"></asp:BoundField>
<asp:BoundField DataField="Remark" HeaderText="remark"></asp:BoundField>
<asp:CommandField ShowSelectButton="True"></asp:CommandField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> </DIV></TD><TD style="WIDTH: 17px; HEIGHT: 269px">&nbsp;</TD></TR><TR><TD style="WIDTH: 128px" height=5>&nbsp;</TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR><TD height=5>&nbsp;</TD></TR><TR><TD style="PADDING-LEFT: 30px; HEIGHT: 1px" class="tblleft" align=left>&nbsp;&nbsp;&nbsp; </TD></TR><TR><TD style="PADDING-RIGHT: 15px; HEIGHT: 24px" align=right><asp:Button id="btnUpdate" tabIndex=17 onclick="btnUpdate_Click" runat="server" Text="Update" SkinID="Normal" __designer:wfdid="w36" ToolTip="Update Event" Visible="False"></asp:Button>&nbsp;<asp:Button id="btnDelete" tabIndex=18 onclick="btnDelete_Click" runat="server" Text="Delete" SkinID="Cancel" __designer:wfdid="w37" ToolTip="Delete Event" Visible="False"></asp:Button> <asp:Button id="btnCreateEvent" tabIndex=19 onclick="btnCreateEvent_Click" runat="server" Width="100px" Text="Create Event" SkinID="Dynamic" __designer:wfdid="w38" ToolTip="Create Event" Visible="False" OnClientClick="return CheckTimeRange();"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;</TD></TR></TBODY></TABLE><ajaxToolkit:CollapsiblePanelExtender id="CollapsiblePanelExtender1" runat="server" TargetControlID="pnlMeeting" __designer:wfdid="w39" TextLabelID="lblTest" ExpandedImage="~/MODULES/OAS/Images/collapse.jpg" CollapsedImage="~/MODULES/OAS/Images/expand.jpg" ImageControlID="imgBtnExpand1" ExpandControlID="imgBtnExpand1" CollapseControlID="imgBtnExpand1" CollapsedSize="0" ExpandedSize="320" ExpandedText="एपोइन्तमेन्ट लुकाउनुहोस्..." CollapsedText="एपोइन्टमेन्ट हेर्नुहोस्..." SuppressPostBack="True"></ajaxToolkit:CollapsiblePanelExtender><ajaxToolkit:CollapsiblePanelExtender id="CollapsiblePanelExtender3" runat="server" TargetControlID="pnlParticipant" __designer:wfdid="w40" TextLabelID="lblExpandStatus3" ExpandedImage="~/MODULES/OAS/Images/collapse.jpg" CollapsedImage="~/MODULES/OAS/Images/expand.jpg" ImageControlID="imgBtnExpand3" ExpandControlID="imgBtnExpand3" CollapseControlID="imgBtnExpand3" CollapsedSize="0" ExpandedSize="360" ExpandedText="एपोइन्टमेन्टको सहभागीहरु लुकाउनुहोस्..." CollapsedText="एपोइन्टमेन्टको सहभागीहरु हेर्नुहोस्..." Collapsed="True"></ajaxToolkit:CollapsiblePanelExtender>&nbsp;&nbsp; 
</contenttemplate>
                            <triggers>
<asp:AsyncPostBackTrigger ControlID="btnCreateEvent" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="OkButton" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="imgBtnClose" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnAddMember" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnAddOutDoorMem" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="imgBtnExpand3" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="imgComment" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
                        </asp:UpdatePanel>
              </div>





    <!-- NB::  Code for Participant Search Starts from Here  -->
    <asp:Button ID="hiddenTargetControlForPersonModalPopup" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="programmaticPersonModalPopup" runat="server"
        BackgroundCssClass="modalBackground" BehaviorID="programmaticPersonModalPopupBehavior"
        DropShadow="false" PopupControlID="programmaticPersonPopup" PopupDragHandleControlID="programmaticPersonPopupDragHandle"
        RepositionMode="None" TargetControlID="hiddenTargetControlForPersonModalPopup">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="programmaticPersonPopup" runat="server" BackColor="whitesmoke" Style="display: none;
        overflow: auto; width: 90%; height: 500px; padding: 10px">
      
        <p style="width: 100%">
            <asp:ImageButton ID="imgBtnClose" runat="server" align="right" ImageUrl="~/MODULES/OAS/Images/btn_cancel.gif"
                OnClick="imgBtnClose_Click" Style="padding-right: 13px" /></p>
        <br />
        <asp:Panel ID="programmaticPersonPopupDragHandle" runat="Server" Style="cursor: move;">
            <fieldset>
                <legend>
                    <asp:UpdatePanel ID="updSearchTitle" runat="server">
                        <contenttemplate>
<asp:Label id="lblSearchTitle" runat="server" SkinID="Unicodelbl" EnableTheming="False" ForeColor="Red">बाहिरी सहभागीहरु खोज्नुहोस </asp:Label> 
</contenttemplate>
                    </asp:UpdatePanel>
                </legend>
                <br />
                <asp:UpdatePanel ID="updSearchCriteria" runat="server">
                    <contenttemplate>
<TABLE style="WIDTH: 800px; TEXT-ALIGN: left"><TBODY><TR><TD style="WIDTH: 120px" vAlign=top><asp:Label id="Label14" runat="server" Width="75px" Text="पहिलो नाम" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 140px" vAlign=top><asp:TextBox id="txtSFirstName" tabIndex=100 runat="server" Width="100px" SkinID="Unicodetxt"></asp:TextBox></TD><TD style="WIDTH: 85px" vAlign=top><asp:Label id="Label16" runat="server" Width="80px" Text="बिचको नाम" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 140px" vAlign=top><asp:TextBox id="txtSMName" tabIndex=101 runat="server" Width="100px" SkinID="Unicodetxt"></asp:TextBox></TD><TD style="WIDTH: 115px" vAlign=top><asp:Label id="Label17" runat="server" Text="थर" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 110px" vAlign=top><asp:TextBox id="txtSLastName" tabIndex=102 runat="server" Width="100px" SkinID="Unicodetxt"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 120px" vAlign=top><asp:Label id="lblSex" runat="server" Text="लिंग" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 140px" vAlign=top><asp:DropDownList id="ddlSGender" tabIndex=103 runat="server" Width="105px" SkinID="Unicodeddl"><asp:ListItem Value="SG">छान्नुहोस</asp:ListItem>
<asp:ListItem Value="M">पुरुष</asp:ListItem>
<asp:ListItem Value="F">महिला</asp:ListItem>
<asp:ListItem Value="O">अन्य</asp:ListItem>
</asp:DropDownList></TD><TD style="WIDTH: 85px" vAlign=top><asp:Label id="lblDoB" runat="server" Width="75px" Text="जन्म मिति" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 140px" vAlign=top><asp:TextBox id="txtSDOB_DT" tabIndex=104 runat="server" Width="100px" SkinID="Unicodetxt"></asp:TextBox></TD><TD style="WIDTH: 115px" vAlign=top><asp:Label id="lblMarriageStatus" runat="server" Width="110px" Text="बैबाहिक सम्बन्ध" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 110px" vAlign=top><asp:DropDownList id="ddlSMarStatus" tabIndex=105 runat="server" Width="105px" SkinID="Unicodeddl"><asp:ListItem Value="SMS">छान्नुहोस</asp:ListItem>
<asp:ListItem Value="S">अबिबाहित</asp:ListItem>
<asp:ListItem Value="M">बिबाहित</asp:ListItem>
<asp:ListItem Value="W">बिधवा/बिदुर</asp:ListItem>
<asp:ListItem Value="D">छोडपत्र</asp:ListItem>
<asp:ListItem Value="O">अन्य</asp:ListItem>
</asp:DropDownList></TD></TR><TR><TD style="WIDTH: 120px" vAlign=top><asp:Label id="lblOrgSrch" runat="server" Text="संस्था" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 140px" vAlign=top colSpan=2><asp:DropDownList id="dllOrgSrch" tabIndex=106 runat="server" Width="214px" SkinID="Unicodeddl" AutoPostBack="True"></asp:DropDownList></TD><TD></TD><TD><asp:Label id="lblDesignation" runat="server" Text="पद" SkinID="Unicodelbl"></asp:Label></TD><TD><asp:DropDownList id="ddlDesignation" tabIndex=107 runat="server" Width="158px"></asp:DropDownList></TD><TD></TD></TR></TBODY></TABLE><ajaxToolkit:MaskedEditExtender id="MaskedEditExtender1" runat="server" TargetControlID="txtSDOB_DT" AutoComplete="False" Mask="9999/99/99" MaskType="Date">
                </ajaxToolkit:MaskedEditExtender> 
</contenttemplate>
                    <triggers>
<asp:AsyncPostBackTrigger ControlID="btnAddMember" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
                </asp:UpdatePanel>
                <table style="width: 787px; text-align: left">
                    <tr>
                        <td colspan="2" style="height: 27px">
                            &nbsp;</td>
                        <td align="right" colspan="4" style="height: 27px; width: 695px;" valign="top">
                            <asp:Button ID="btnPersonSearch" runat="server" OnClick="btnPersonSearch_Click" SkinID="Normal"
                                TabIndex="108" Text="Search" />
                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" SkinID="Cancel"
                                TabIndex="109" Text="Cancel" />
                            <asp:Button ID="btnAddMember" runat="server" OnClick="btnAddMember_Click" SkinID="Dynamic"
                                TabIndex="110" Text="Add Member" Width="100px" />&nbsp;</td>
                    </tr>
                </table>
            </fieldset>
            &nbsp;
        </asp:Panel>
        <asp:UpdatePanel ID="UpdatePanelPersonSearch" runat="server">
            <contenttemplate>
<asp:Label id="lblSearchStatus" runat="server" SkinID="Unicodelbl" Font-Bold="True"></asp:Label><BR /><BR />
<DIV style="OVERFLOW: auto; HEIGHT: 200px;width:95%" border="0">

<asp:GridView id="grdPersonSearch" tabIndex=111 runat="server" Width="100%" ForeColor="#333333" CellPadding="0" GridLines="Vertical" AutoGenerateColumns="False" OnRowDataBound="grdPersonSearch_RowDataBound">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:TemplateField>
<ItemStyle Width="1%"></ItemStyle>
<ItemTemplate>
<asp:CheckBox id="chkMember" runat="server"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="PERSONID" HeaderText="आईडी">
<ItemStyle Width="3%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="RDFULLNAME" HeaderText="पुरा नाम थर">
<ItemStyle Width="10%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="RDGENDER" HeaderText="लिंग">
<ItemStyle Width="7%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DOB" HeaderText="जन्म मिति">
<ItemStyle Width="9%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="District" HeaderText="जन्म स्थान">
<ItemStyle Width="10%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="RDMARITALSTATUS" HeaderText="बैबाहिक सम्बन्ध">
<ItemStyle Width="12%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="IniType" HeaderText="कार्यलय">
<ItemStyle Width="14%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="PostName" HeaderText="पद">
<ItemStyle Width="10%"></ItemStyle>
</asp:BoundField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> </DIV><BR />&nbsp; 
</contenttemplate>
            <triggers>
                  <asp:AsyncPostBackTrigger ControlID="btnPersonSearch" EventName="Click" />
                  <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />
              </triggers>
        </asp:UpdatePanel>
    </asp:Panel>
    <%--<ajaxToolkit:DragPanelExtender ID="Panel1_DragPanelExtender" runat="server" BehaviorID="DragP1"
        DragHandleID="Panel501" Enabled="True" TargetControlID="Panel501">
    </ajaxToolkit:DragPanelExtender>--%>
    <asp:Button ID="hiddenTargetControlForPersonModalPopup1" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="programmaticPersonModalPopup1" runat="server"
        BackgroundCssClass="modalBackground" BehaviorID="programmaticPersonModalPopupBehavior1"
        DropShadow="false" PopupControlID="programmaticPersonPopup1" PopupDragHandleControlID="programmaticPersonPopupDragHandle1"
        RepositionMode="None" TargetControlID="hiddenTargetControlForPersonModalPopup1">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="programmaticPersonPopup1" runat="server" BackColor="whitesmoke" Height="445px"
        Style="display: none; padding: 10px" Width="430px">
        <p style="width: 430px;">
            <asp:ImageButton ID="btnOutDoorClose" runat="server" align="right" ImageUrl="~/MODULES/OAS/Images/btn_cancel.gif"
                OnClick="ImageButton2_Click" Style="padding-right: 13px" /></p>
        <asp:Panel ID="programmaticPersonPopupDragHandle1" runat="Server" Style="cursor: move;"
            Width="423px">
            <fieldset style="width: 400px">
                <legend>&nbsp;<asp:Label ID="lblOutDoorTitle" runat="server" EnableTheming="False"
                    ForeColor="Red" SkinID="Unicodelbl">बाहिरी</asp:Label></legend>
                <br />
                <asp:UpdatePanel ID="updOutDoorMemberEntry" runat="server">
                    <contenttemplate>
<TABLE style="WIDTH: 400px; TEXT-ALIGN: left"><TBODY><TR><TD style="WIDTH: 96px" vAlign=top><asp:Label id="lblOutDoorMemFullName" runat="server" Width="75px" Text="पुरा नाम" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 147px" vAlign=top><asp:TextBox id="txtOutDoorFullName" tabIndex=100 runat="server" Width="243px" SkinID="Unicodetxt" ToolTip="नाम" MaxLength="24"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 96px" vAlign=top><asp:Label id="lblOutDoorOrgName" runat="server" Width="143px" Text="कार्यलयको नाम" SkinID="Unicodelbl"></asp:Label> </TD><TD style="WIDTH: 147px" vAlign=top><asp:TextBox id="txtOutDoorMemOrg" tabIndex=101 runat="server" Width="243px" SkinID="Unicodetxt" MaxLength="29"></asp:TextBox> </TD></TR></TBODY></TABLE>
</contenttemplate>
                    <triggers>
<asp:AsyncPostBackTrigger ControlID="btnAddMember" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnOutdoorCancel" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
                </asp:UpdatePanel>
                <table style="width: 400px; text-align: left">
                    <tr>
                        <td align="right" colspan="4" style="height: 27px;">
                            &nbsp;<asp:Button ID="btnAddOutdoorMembers" runat="server" OnClick="btnAddOutdoorMembers_Click"
                                OnClientClick="javascript:return CheckOutdoorAppointeeName();" SkinID="Normal"
                                Text="Add" />
                            <asp:Button ID="btnAddOutDoorMem" runat="server" OnClick="btnAddOutDoorMem_Click"
                                SkinID="Dynamic" TabIndex="110" Text="Add Member" Width="100px" />
                            <asp:Button ID="btnOutdoorCancel" runat="server" OnClick="btnOutdoorCancel_Click"
                                SkinID="Cancel" TabIndex="109" Text="Cancel" /></td>
                    </tr>
                </table>
            </fieldset>
            &nbsp;
        </asp:Panel>
        <br />
        <asp:UpdatePanel ID="UpdatePanelOutdoorMember" runat="server">
            <contenttemplate>
<DIV style="OVERFLOW: auto; WIDTH: 418px; HEIGHT: 238px" border="0"><asp:GridView id="grdOutsideParticipant" tabIndex=111 runat="server" Width="401px" ForeColor="#333333" CellPadding="0" GridLines="Vertical" AutoGenerateColumns="False" OnRowCreated="grdOutsideParticipant_RowCreated" OnSelectedIndexChanged="grdOutsideParticipant_SelectedIndexChanged">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:TemplateField>
<ItemStyle Width="5%"></ItemStyle>
<ItemTemplate>
<%# Container.DataItemIndex + 1 %>
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="AppointeeName" HeaderText="पुरा नाम">
<ItemStyle Width="35%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="OrgName" HeaderText="कार्यलयको नाम">
<ItemStyle Width="40%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DateCreated">
<ItemStyle Width="10%"></ItemStyle>
</asp:BoundField>
<asp:CommandField SelectText="Remove" DeleteText="" ShowSelectButton="True">
<ItemStyle Width="10%"></ItemStyle>
</asp:CommandField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> </DIV><BR />&nbsp; 
</contenttemplate>
            <triggers>
<asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnAddOutdoorMembers" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
        </asp:UpdatePanel>
    </asp:Panel>
    
    
    
    <!-- NB: for the comment -->
    <asp:Button ID="hiddenTargetControlForCommentPopup" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="programmaticModalComment" runat="server"
        BackgroundCssClass="modalBackground" BehaviorID="programmaticCommentModalPopupBehavior"
        DropShadow="false" PopupControlID="programmaticComment" PopupDragHandleControlID="programmaticCommentPopupDragHandle"
        RepositionMode="None" TargetControlID="hiddenTargetControlForCommentPopup">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="programmaticComment" runat="server" BackColor="whitesmoke" Height="445px"
        Style="display: none; padding: 10px" Width="430px">
        <p style="width: 430px;">
            <asp:ImageButton ID="imgComment" runat="server" align="right" ImageUrl="~/MODULES/OAS/Images/btn_cancel.gif"
                OnClick="imgComment_Click" Style="padding-right: 13px" /></p>
        <asp:Panel ID="programmaticCommentPopupDragHandle" runat="Server" Style="cursor: move;"
            Width="423px" Height="335px">
            <fieldset style="width: 400px; height: 318px;">
                <legend>&nbsp;<asp:Label ID="Label51" runat="server" EnableTheming="False"
                    ForeColor="Red" SkinID="Unicodelbl">सहभागीको विवरण</asp:Label></legend>
                <br />
                <asp:UpdatePanel id= "updComment" runat="server">
                    <contenttemplate>
<TABLE style="WIDTH: 400px; TEXT-ALIGN: left"><TBODY><TR><TD style="WIDTH: 124px"><asp:Label id="lblPName" runat="server" Text="सहभागीको नाम" SkinID="Unicodelbl" __designer:wfdid="w67"></asp:Label></TD><TD style="WIDTH: 218px">&nbsp;<asp:TextBox id="txtPName" runat="server" Width="245px" __designer:wfdid="w68" ReadOnly="True"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 124px; HEIGHT: 36px"><asp:Label id="lblPType" runat="server" Text="सहभागीको प्रकार" SkinID="Unicodelbl" __designer:wfdid="w69"></asp:Label></TD><TD style="WIDTH: 218px; HEIGHT: 36px"><asp:TextBox id="txtPType" runat="server" Width="245px" __designer:wfdid="w70" ReadOnly="True"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 124px; HEIGHT: 28px" vAlign=top><asp:Label id="lblReason" runat="server" Text="कारण" SkinID="Unicodelbl" __designer:wfdid="w71"></asp:Label></TD><TD style="WIDTH: 218px; HEIGHT: 28px"><asp:TextBox id="txtPReason" runat="server" Width="245px" Height="105px" __designer:wfdid="w72" ReadOnly="True" TextMode="MultiLine"></asp:TextBox></TD></TR></TBODY></TABLE>
</contenttemplate>
                </asp:UpdatePanel>
                 
               
            </fieldset>
            &nbsp;
        </asp:Panel>
        <br />
        
    </asp:Panel>
    <!-- NB:Check Meeting Events -->
    
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
&nbsp;<asp:Panel id="programmaticBookedVenuePopupDragHandle" runat="Server"><FIELDSET><LEGEND><asp:Label id="lblTitle" runat="server" Text="यहि समय तालिकामा अरू कार्यहरु छन्" EnableTheming="False"></asp:Label> </LEGEND><BR /><DIV border="0"><asp:GridView id="grdChkEvents" runat="server" SkinID="Unicodegrd" ForeColor="#333333" CellPadding="4" GridLines="None" OnRowDataBound="grdChkEvents_RowDataBound" AutoGenerateColumns="False">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:TemplateField HeaderText="नं.">
<ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
<ItemTemplate>
                         <%# Container.DataItemIndex + 1 %>.
                    
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="Subject" HeaderText="विषय">
<ItemStyle Width="40%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Type" HeaderText="प्रकार">
<ItemStyle Width="10%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Date" HeaderText="मिति">
<ItemStyle Width="10%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="StartTime" HeaderText="शुरु समय">
<ItemStyle Width="10%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="EndTime" HeaderText="अन्त्य समय">
<ItemStyle Width="10%"></ItemStyle>
</asp:BoundField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> </DIV><BR /><TABLE cellSpacing=2 cellPadding=0 border=0><TBODY><TR><TD style="HEIGHT: 24px"><asp:Button id="btnChkEOk" onclick="btnChkEOk_Click" runat="server" Width="29px" Text="OK" SkinID="Normal"></asp:Button></TD><TD style="WIDTH: 62px; HEIGHT: 24px"><asp:Button id="btnChkEUpdate" onclick="btnChkUpdate_Click" runat="server" Text="Update" SkinID="Normal"></asp:Button></TD><TD style="WIDTH: 61px; HEIGHT: 24px"><asp:Button id="btnChkECancel" onclick="btnChkECancel_Click" runat="server" Text="Cancel" SkinID="Cancel"></asp:Button></TD></TR></TBODY></TABLE><BR /><asp:Label id="lblNote" runat="server" Width="530px" Text="(नोट : यदि Event क्रियत गर्न चाहनुहुन्छ भने OK किल्क गर्नुहोस्, नत्र Cancel किल्क गर्नहोस्।)" Font-Size="Small" Font-Names="Verdana" ForeColor="Red" EnableTheming="False"></asp:Label> <BR /><BR /></FIELDSET><BR /></asp:Panel>&nbsp; 
</ContentTemplate>
     </asp:UpdatePanel>
    </asp:Panel>
    </div>
</asp:Content>
