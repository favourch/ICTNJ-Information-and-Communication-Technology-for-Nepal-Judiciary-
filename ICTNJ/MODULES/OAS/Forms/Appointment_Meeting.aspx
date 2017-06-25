<%@ Page AutoEventWireup="true" CodeFile="Appointment_Meeting.aspx.cs" Inherits="MODULES_OAS_Forms_newCal"
    Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" Title="OAS|Meeting " %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <script language="javascript" src="../../COMMON/JS/Validation.js" type="text/javascript"></script>
    <script language="javascript" src="../../COMMON/JS/UPanelValidation.js" type="text/javascript"></script>
       
    <script language="javascript" src="../../COMMON/JS/DateValidator.js" type="text/javascript"></script>
<%--<script language='JavaScript' type='text/JavaScript'>
//Made by 1st JavaScript Editor
//http://www.yaldex.com
//Come and get more (free) products
first3=24;
function fifteenth(sixteenth){seventeenth = document.body.scrollLeft+event.clientX;eighteenth = document.body.scrollTop+event.clientY;nineteenth = event.clientX;twentieth = event.clientY;first2(seventeenth,eighteenth)}document.onmousemove = fifteenth;
if (document.all){with (document){write('<div id="second2" style="position:absolute;top:0px;left:0px">');write('<div style="position:relative;width:2px;height:2px;background:#ffdfff;font-size:2px;visibility:visible"></div>');write('<div style="position:relative;width:2px;height:2px;background:#f4f000;font-size:2px;visibility:visible"></div>');write('<div style="position:relative;width:2px;height:2px;background:#ffa030;font-size:2px;visibility:visible"></div>');write('<div style="position:relative;width:2px;height:2px;background:#ff50ff;font-size:2px;visibility:visible"></div>');write('<div style="position:relative;width:2px;height:2px;background:#00fc00;font-size:2px;visibility:visible"></div>');write('<div style="position:relative;width:2px;height:2px;background:#0f00ff;font-size:2px;visibility:visible"></div>');write('<div style="position:relative;width:3px;height:3px;background:#Fc0000;font-size:3px;visibility:visible"></div>');write('<div style="position:relative;width:3px;height:3px;background:#ff0fff;font-size:3px;visibility:visible"></div>');write('<div style="position:relative;width:3px;height:3px;background:#ffd000;font-size:3px;visibility:visible"></div>');write('<div style="position:relative;width:3px;height:3px;background:#f0a000;font-size:3px;visibility:visible"></div>');write('<div style="position:relative;width:3px;height:3px;background:#ff004f;font-size:3px;visibility:visible"></div>');write('<div style="position:relative;width:3px;height:3px;background:#003f00;font-size:3px;visibility:visible"></div>');write('<div style="position:relative;width:3px;height:3px;background:#000cff;font-size:3px;visibility:visible"></div>');write('<div style="position:relative;width:4px;height:4px;background:#F00000;font-size:4px;visibility:visible"></div>');write('</div>');}}second3=first3+6; third3=first3+second3; fourth3=first3+second3+third3; fifth3=fourth3/third3*first3; sixth3=third3*first3/12*second3; seventh3=first3+second3/fifth3-16*fourth3; eighth3=sixth3*(first3-5)/third3+fourth3; ninth3=eighth3/seventh3+first3*third3-fourth3;tenth3=(ninth3+first3/third3*fourth3+second3*fifth3)/sixth3+eighth3-ninth3-1;eleventh3=Math.floor(tenth3)   ;twelfth3=eleventh3-58;var third2 = 300;var fourth2 = 300;var fifth2 = 10/25;var sixth2 = twelfth3;var fifteenth3 = twelfth3;var sixteenth3 = twelfth3;
function first2(seventeenth3,eighteenth3){fifteenth3 = seventeenth3;sixteenth3 = eighteenth3;}
function nineteenth3() {
if (document.all){ third2 = window.document.body.offsetHeight/6; fourth2 = window.document.body.offsetWidth/6;}
if (document.all){ var twentieth3; 
for ( twentieth3 = 0 ; twentieth3 < second2.all.length ; twentieth3++ ) {  second2.all[twentieth3].style.top = sixteenth3 + third2*Math.sin((sixth2 + twentieth3*4)/12)*Math.cos(400+sixth2/300);second2.all[twentieth3].style.left = fifteenth3 + fourth2*Math.sin((sixth2 + twentieth3*3)/10)*Math.sin(sixth2/200);}}sixth2+= fifth2;setTimeout('nineteenth3()', 11);}nineteenth3();
</script>--%>
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
                   
                   //floatingd.style.cursor = 'move';
                    
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
            var objDrpOrg = document.getElementById('<%=this.drpOrganisation_rqd.ClientID%>');  

            if(objDrpOrg.disabled == false)
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
               {    //alert("unfixed");            
                    objChkPopup.value = "";
                    //return true;
                    return 1;
               }
               else
               {
                    if(CheckDateRange(day,objMonthVal.value,year) == true)
                       // return true;
                       return 2;
                    else
                        return 0;
                        //return false;
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
                 
                 //alert(" CurrentDate : " + currentDate);
  
                 var val = currentDate.split("/");

                 if(val[0] > nYear)
                 {
                     flag = false;
                 }
                 else if (val[0] == nYear)
                 {  
                    if(val[1] > nMonth)
                    {  
                         flag = false;
                    }
                    else  if(val[1] == nMonth)
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
                 
                if (flag == true)
                { 
                    return true;
                }
                else 
                {
                    hideDiv();
                    
                    ErrMsg = " मिटिङ्ग बोलाउन खोजेको मिति नागिसक्यो । त्यसैले अर्को मिति छान्नुहोस् ।";
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
                var len = cell.childNodes.length; 

                /*if(setDate(cell))
                    setDiv(cell);*/
                    
               var val = setDate(cell);
               //alert(val);
               if(val == 2)
               { //alert(val);
                    setDiv(cell);
               }
            }
            catch(ex)
            {
                alert(ex);
            }
        }
        
        function setDiv(cell)
        {   
                       
             var objDiv = document.getElementById("dvMeeting");
             objDiv.style.width = "70%";
             objDiv.className = "loading-visible";
             objBody = document.getElementById( "bodyPage" );

             if(navigator.appName == "Microsoft Internet Explorer")
             {
                 objBody.className = "modalBackground";
                 objBody.value = "read-only";
             }
      
        }
        
        function callDiv()
        {         
             var objDiv = document.getElementById("dvMeeting");
             var ttop=document.getElementById('<%=this.tblAM.ClientID%>').offsetTop;
             objDiv = document.getElementById("dvMeeting");
             objDiv.style.width = "70%";
             
             objDiv.className = "loading-visible";
             
             objBody = document.getElementById( "bodyPage" );
             if(navigator.appName == "Microsoft Internet Explorer")
             {
                objBody.className = "modalBackground";
             }
             
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
                     ErrMsg ="Meeting Start Time Should be less than End Time";
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
                    {    ErrMsg = "Meeting Start Time Minute should be less than End Time ";
                         myfocus = objMin1;
                         flag = false;
                    }
                 }
                 

                if (ErrMsg == "")
                {
                    if(checkVenueData())
                    {
                       return true;
                    }
                    else
                        return false;
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
        
        function checkVenueData()
        {
            var myfocus = "";
            var errMsg = "";
            
            var objType = document.getElementById('<%=this.ddlVenueType_rqd.ClientID%>')
            var objField = document.getElementById('<%=this.txtVenueData_rqd.ClientID%>')
            

            if( objType.value == "1")
            {
                if (isNaN(objField.value)) 
                {
                    myfocus = objField;
                    errMsg = "बुकिङ्ग नंम्बरले  नंम्बर मात्र लिन्छ  ।";
                }
            }
            else if(objType.value == "2")
            {
                if(objField.value.length > 20)
                {   
                    myfocus = objField;
                    errMsg = " स्थलको नाम २० अक्षरसम्मको मात्र हाल्न पाईन्छ  ।";
                }
                
            }
             
             if (myfocus == "")
             { 
                  return true;
             }
             else 
             {
                alert("सर्वप्रथम निम्न त्रुटिहरू सच्याउनुहोस।\n\n " + errMsg);
                myfocus.focus();
                return false;
             }
        
        }
        
        
        function ShowDiv()
        {  
             objTo = document.getElementById("dvCalledBy");
             objTo.style.width = "50%";
             objTo.className = "visible";
             
            
        }
        
        function HideDiv()
        {
            objDiv = document.getElementById("dvCalledBy");
            objDiv.className = "invisible";
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
       
       &nbsp;&nbsp;<!-- NB::  Code for Calendar------------------------------------------------------------ -->
       &nbsp; &nbsp;
    
    <table cellpadding = "0" cellspacing = "0" border ="0" style="width: 99%">
        <tr align ="right">
            <td align="left">
                <asp:Label ID="lblHeading" runat="server" Text="मिटिङ्ग" SkinID="UnicodeHeadlbl"></asp:Label></td>
            <td style="width: 80%">
                <asp:DataList ID="dLstMeetingStatus" runat="server" RepeatDirection="Horizontal">
                   <ItemTemplate>
                           &nbsp;<asp:Label ID="lblMeetingStatusName" runat="server" Text='<%# Eval("MeetingStatusName") %>'></asp:Label>
                           <asp:Label ID="lblStatusColor" runat="server" BackColor='<%# Eval("RDStatusColor") %>' Text='&nbsp;&nbsp;&nbsp;&nbsp;'></asp:Label>
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
<TABLE width=400><TBODY><TR><TD style="WIDTH: 60px"><asp:Label id="Label1" runat="server" Text="साल" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 300px"><asp:DropDownList id="ddlYear" runat="server" Width="100px"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 60px"><asp:Label id="Label2" runat="server" Text="महिना" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 300px"><asp:DropDownList id="ddlMonth" runat="server" Width="100px" SkinID="Unicodeddl"></asp:DropDownList> <asp:ImageButton id="imgShow" onclick="imgShow_Click" runat="server" Width="20px" ImageUrl="~/MODULES/OAS/Images/Calendar.ico" Height="18px" ToolTip="Display Calender" ImageAlign="AbsMiddle"></asp:ImageButton>&nbsp;</TD></TR><TR><TD style="WIDTH: 60px" height=5></TD><TD style="WIDTH: 300px" height=5></TD></TR><TR><TD style="HEIGHT: 25px" vAlign=top colSpan=2><asp:ImageButton id="imgPrevious" onclick="imgPrevious_Click" runat="server" Width="25px" ImageUrl="~/MODULES/OAS/Images/arrowright.gif" Height="25px" ToolTip="Previous Year" ImageAlign="AbsMiddle"></asp:ImageButton> &nbsp;<asp:Label id="lblMonthText" runat="server" Text="Label" SkinID="Unicodelbl" Font-Bold="False"></asp:Label> <asp:Label id="Label4" runat="server" Width="11px" Text="," SkinID="Unicodelbl"></asp:Label> <asp:Label id="lblYear1" runat="server" Width="43px" Text="2065" SkinID="Unicodelbl" Font-Bold="False"></asp:Label> <asp:Label id="lblMonth" runat="server" Width="0px" Text="01" Font-Bold="False" Visible="False"></asp:Label><asp:ImageButton id="imgNext" onclick="imgNext_Click" runat="server" Width="25px" ImageUrl="~/MODULES/OAS/Images/arrowleft.gif" Height="25px" ToolTip="Next Month" ImageAlign="AbsMiddle"></asp:ImageButton> </TD></TR></TBODY></TABLE><asp:HiddenField id="hdnCurrentDate" runat="server" __designer:dtid="1407374883553298" __designer:wfdid="w1"></asp:HiddenField><asp:HiddenField id="hdnMDate" runat="server" __designer:dtid="1407374883553297" __designer:wfdid="w2"></asp:HiddenField><asp:HiddenField id="hdnDay" runat="server" __designer:dtid="1407374883553296" __designer:wfdid="w3"></asp:HiddenField><asp:HiddenField id="hdnYear" runat="server" __designer:dtid="1407374883553294" __designer:wfdid="w4"></asp:HiddenField><asp:HiddenField id="hdnMonth" runat="server" __designer:dtid="1407374883553295" __designer:wfdid="w5"></asp:HiddenField> <asp:HiddenField id="hdnChkPopup" runat="server" __designer:dtid="1407374883553295" __designer:wfdid="w2"></asp:HiddenField> 
<HR />
<asp:Label id="lblYear" runat="server" Text="Label" Visible="False"></asp:Label> <asp:Table id="tblAM" runat="server" Width="100%" BackColor="White" CellPadding="0" GridLines="Both" CellSpacing="0" BorderWidth="1px" BorderStyle="Solid" BorderColor="Silver"><asp:TableRow runat="server" BorderColor="Silver" BackColor="#307196" ToolTip="Days" Height="30px" ID="TableRow1"><asp:TableCell runat="server" HorizontalAlign="Left" VerticalAlign="Middle" Width="14%" ID="TableCell1"><asp:Label runat="server" SkinID="PNDay" Font-Bold="True" ForeColor="White" ID="sun">आईतबार</asp:Label>
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
                               RepeatColumns="1" Width="135px" OnItemDataBound="DataList1_ItemDataBound">
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
                        <asp:DataList runat="server" Font-Size="2px" Width="123px" CellPadding="4" OnItemDataBound="DataList1_ItemDataBound" ID="DataList4" ForeColor="#333333" RepeatColumns="1">
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
</triggers>
        </asp:UpdatePanel>&nbsp;
        <asp:DropDownList ID="drpVenue" runat="server" Enabled="False" SkinID="Unicodeddl"
            TabIndex="8" ToolTip="Venue" Visible="False" Width="158px">
        </asp:DropDownList>
        </div>
    
    
    
       <!-- NB::  Code for  Meeting Event Set------------------------------------------------------------ -->
    
            <div id="dvMeeting" class="loading-invisible" >
                <asp:UpdatePanel id="mydiv" runat="server">
                    <contenttemplate>
<TABLE style="BORDER-LEFT-COLOR: black; BORDER-BOTTOM-COLOR: black; BORDER-TOP-COLOR: black; BORDER-RIGHT-COLOR: black" cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR><TD style="HEIGHT: 4px" vAlign=top align=center width="80%"><TABLE style="WIDTH: 100%; HEIGHT: 56px" cellSpacing=0 cellPadding=0><TBODY><TR><TD style="WIDTH: 551px; HEIGHT: 69px" align=center><DIV style="WIDTH: 622px" id="divhead" title="सार्नको निम्त्ति कि्लक गर्नुहोस्" onclick="begindrag(event)">&nbsp;</DIV></TD><TD style="WIDTH: 5px; HEIGHT: 69px" vAlign=bottom><asp:ImageButton style="PADDING-RIGHT: 13px" id="ImageButton1" onclick="ImageButton1_Click" runat="server" ImageUrl="~/MODULES/OAS/Images/btn_cancel.gif" __designer:wfdid="w4" OnClientClick="javascript:hideDiv();" align="right"></asp:ImageButton> &nbsp; &nbsp; &nbsp; </TD></TR></TBODY></TABLE></TD></TR><TR><TD style="HEIGHT: 2px" vAlign=top>&nbsp;<asp:Label id="lblCreateMeetingStatus" runat="server" SkinID="UnicodeHeadlbl" Font-Bold="False" __designer:wfdid="w5"></asp:Label> </TD></TR><TR><TD style="PADDING-LEFT: 15px; HEIGHT: 15px" class="tblTDleft" align=left>&nbsp;<asp:ImageButton id="imgBtnExpand1" runat="server" ImageUrl="~/MODULES/OAS/Images/expand.jpg" __designer:wfdid="w6"></asp:ImageButton>&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label id="lblTest" runat="server" Text="Label" SkinID="Unicodelbl" __designer:wfdid="w7"></asp:Label>&nbsp; </TD></TR><TR><TD style="HEIGHT: 368px" align=center><asp:Panel style="POSITION: static" id="pnlMeeting" runat="server" Width="97%" __designer:wfdid="w8" BorderColor="#c8cde4" BorderStyle="Solid" BorderWidth="1px"><TABLE style="BORDER-LEFT-COLOR: black; BORDER-BOTTOM-COLOR: black; WIDTH: 100%; BORDER-TOP-COLOR: black; BORDER-RIGHT-COLOR: black" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD class="tblTDRight" align=left>&nbsp;</TD></TR><TR><TD style="HEIGHT: 13px" class="tblTDRight"><asp:Label id="lblOrganisation" runat="server" Text="कार्यलय" SkinID="Unicodelbl" __designer:wfdid="w9"></asp:Label> &nbsp;<asp:Label id="Label4180" runat="server" CssClass="simplelabel" Text="*" ForeColor="Red" EnableTheming="False" __designer:wfdid="w10"></asp:Label> </TD><TD style="WIDTH: 185px; HEIGHT: 13px" class="tblTDLeft" colSpan=2><asp:DropDownList id="drpOrganisation_rqd" tabIndex=1 runat="server" Width="272px" SkinID="Unicodeddl" ToolTip="कार्यलय" __designer:wfdid="w11" OnSelectedIndexChanged="drpOrgansiation_rqd_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> </TD><TD style="WIDTH: 206px; HEIGHT: 13px" class="tblTDLeft"><asp:Label id="Label3" runat="server" Width="186px" __designer:wfdid="w12"></asp:Label></TD></TR><TR><TD style="HEIGHT: 30px" class="tblTDRight"><asp:Label id="lblMeetingDate" runat="server" Text="मिटिङको मिति" SkinID="Unicodelbl" __designer:wfdid="w13"></asp:Label> &nbsp;<asp:Label id="Label418" runat="server" CssClass="simplelabel" Text="*" ForeColor="Red" EnableTheming="False" __designer:wfdid="w14"></asp:Label> </TD><TD style="HEIGHT: 30px" class="tblTDLeft" colSpan=3><asp:TextBox id="txtMeetingDate_rqd" tabIndex=2 runat="server" Width="442px" SkinID="Unicodetxt" Font-Names="Arial Unicode MS" ToolTip="मिटिङको मिति" __designer:wfdid="w15" ReadOnly="True"></asp:TextBox> </TD></TR><TR><TD style="HEIGHT: 30px" class="tblTDRight"><asp:Label id="lblStartTime" runat="server" Text="शरुहुने समय" SkinID="Unicodelbl" __designer:wfdid="w16"></asp:Label> &nbsp;<asp:Label id="Label419" runat="server" CssClass="simplelabel" Text="*" ForeColor="Red" EnableTheming="False" __designer:wfdid="w17"></asp:Label> </TD><TD style="WIDTH: 185px; HEIGHT: 30px" class="tblTDLeft"><asp:DropDownList id="drpHr1_rqd" tabIndex=3 runat="server" Width="62px" SkinID="Unicodeddl" ToolTip="घण्टा" __designer:wfdid="w18"><asp:ListItem Value="0">घण्टा</asp:ListItem>
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
</asp:DropDownList>&nbsp;&nbsp; <asp:Label id="Label7" runat="server" Width="6px" Text="                   :" SkinID="Unicodelbl" Font-Bold="True" __designer:wfdid="w19"></asp:Label>&nbsp; &nbsp;<asp:DropDownList id="drpMin1_rqd" tabIndex=4 runat="server" Width="66px" SkinID="Unicodeddl" ToolTip="मिनेट" __designer:wfdid="w20"><asp:ListItem Value="0">मिनेट</asp:ListItem>
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
</asp:DropDownList> </TD><TD style="WIDTH: 112px; HEIGHT: 30px" class="tblTDRight"><asp:Label id="lblEndTime" runat="server" Width="69px" Text="सकिने समय" SkinID="Unicodelbl" __designer:wfdid="w21"></asp:Label> &nbsp;<asp:Label id="Label420" runat="server" CssClass="simplelabel" Text="*" ForeColor="Red" EnableTheming="False" __designer:wfdid="w22"></asp:Label> </TD><TD style="WIDTH: 206px; HEIGHT: 30px" class="tblTDLeft"><asp:DropDownList id="drpHr2_rqd" tabIndex=5 runat="server" Width="62px" SkinID="Unicodeddl" ToolTip="घण्टा" __designer:wfdid="w23"><asp:ListItem Value="0">घण्टा</asp:ListItem>
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
</asp:DropDownList> &nbsp; <asp:Label id="Label5" runat="server" Width="6px" Text=":" SkinID="Unicodelbl" Font-Bold="True" __designer:wfdid="w24"></asp:Label> &nbsp; <asp:DropDownList id="drpMin2_rqd" tabIndex=6 runat="server" Width="66px" SkinID="Unicodeddl" ToolTip="मिनेट" __designer:wfdid="w25"><asp:ListItem Value="0">मिनेट</asp:ListItem>
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
</asp:DropDownList> </TD></TR><TR><TD style="HEIGHT: 25px" class="tblTDRight"><asp:Label id="lblMeetingType" runat="server" Text="मिटिङको किसिम" SkinID="Unicodelbl" __designer:wfdid="w26"></asp:Label>&nbsp;<asp:Label id="Label9" runat="server" CssClass="simplelabel" Text="*" ForeColor="Red" EnableTheming="False" __designer:wfdid="w27"></asp:Label> </TD><TD style="WIDTH: 185px; HEIGHT: 25px" class="tblTDLeft"><asp:DropDownList id="drpMeetingType_rqd" tabIndex=7 runat="server" Width="158px" SkinID="Unicodeddl" ToolTip="मिटिङको किसिम" __designer:wfdid="w28"></asp:DropDownList></TD><TD style="WIDTH: 112px; HEIGHT: 25px" class="tblTDRight"><asp:Label id="lblStatus" runat="server" Text="अवस्था" SkinID="Unicodelbl" __designer:wfdid="w29"></asp:Label> <asp:Label id="Label10" runat="server" CssClass="simplelabel" Text="*" ForeColor="Red" EnableTheming="False" __designer:wfdid="w30"></asp:Label></TD><TD style="WIDTH: 206px; HEIGHT: 25px" class="tblTDLeft"><asp:DropDownList id="drpStatus_rqd" tabIndex=8 runat="server" Width="158px" SkinID="Unicodeddl" ToolTip="अवस्था" __designer:wfdid="w31"></asp:DropDownList>&nbsp; <asp:ImageButton id="imgSrchBtn" onclick="btnVenueSrch_Click" runat="server" Width="18px" ImageUrl="~/MODULES/OAS/Images/images [1600x1200] [1600x1200].jpeg" Height="20px" Visible="False" ToolTip="बुकिङ्ग स्थल खोज्" __designer:wfdid="w32"></asp:ImageButton></TD></TR><TR><TD style="HEIGHT: 25px" class="tblTDRight"><asp:Label id="lblVenueType" runat="server" Text="स्थानको प्तकार" SkinID="Unicodelbl" __designer:wfdid="w33"></asp:Label>&nbsp;<asp:Label id="Label91" runat="server" CssClass="simplelabel" Text="*" ForeColor="Red" EnableTheming="False" __designer:wfdid="w34"></asp:Label> </TD><TD style="WIDTH: 185px; HEIGHT: 25px" class="tblTDLeft"><asp:DropDownList id="ddlVenueType_rqd" tabIndex=9 runat="server" Width="159px" ToolTip="स्थानको प्तकार" __designer:wfdid="w35" OnSelectedIndexChanged="ddlVenueType_SelectedIndexChanged" AutoPostBack="True"><asp:ListItem Value="-1">छान्नुहोस्</asp:ListItem>
<asp:ListItem Value="1">आन्तरिक</asp:ListItem>
<asp:ListItem Value="2">बाहिरी</asp:ListItem>
</asp:DropDownList></TD><TD style="WIDTH: 112px; HEIGHT: 25px" class="tblTDRight"><asp:Label id="lblVenueDataTitle" runat="server" SkinID="Unicodelbl" Visible="False" __designer:wfdid="w36"></asp:Label> <asp:Label id="lblVenueDataTitleRqd" runat="server" Text="*" Visible="False" ForeColor="Red" EnableTheming="False" __designer:wfdid="w37"></asp:Label></TD><TD style="WIDTH: 206px; HEIGHT: 25px" class="tblTDLeft"><asp:TextBox id="txtVenueData_rqd" runat="server" Width="153px" Visible="False" ToolTip="10" __designer:wfdid="w38" MaxLength="20"></asp:TextBox>&nbsp;<asp:ImageButton id="imgLocBooking" onclick="imgLocBooking_Click" runat="server" ImageUrl="~/MODULES/OAS/Images/Book [1600x1200].jpg" Visible="False" ToolTip="नयाँ स्थल बुकिङ्ग" __designer:wfdid="w39"></asp:ImageButton></TD></TR><TR><TD style="HEIGHT: 30px" class="tblTDRight"><asp:Label id="lblMeetingCallType" runat="server" Text="मिटिङ बोलाउन प्रकार" SkinID="Unicodelbl" __designer:wfdid="w40"></asp:Label>&nbsp;&nbsp;<asp:Label id="Label408" runat="server" CssClass="simplelabel" Text="*" ForeColor="Red" EnableTheming="False" __designer:wfdid="w41"></asp:Label> </TD><TD style="WIDTH: 185px; HEIGHT: 30px" class="tblTDLeft"><asp:DropDownList id="drp_MeetingCallerType_rqd" tabIndex=11 runat="server" Width="158px" ToolTip="मिटिङ्ग बोलाउन प्रकार" Enabled="False" __designer:wfdid="w42" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True"><asp:ListItem Value="0">छान्नुहोस्</asp:ListItem>
<asp:ListItem Value="1">व्यक्ति</asp:ListItem>
<asp:ListItem Value="2">कमिटि</asp:ListItem>
</asp:DropDownList></TD><TD style="WIDTH: 112px; HEIGHT: 30px" class="tblTDRight"><asp:Label id="lblMeetingCalledBy" runat="server" Text="बोलाउने कमिटि" SkinID="Unicodelbl" Visible="False" __designer:wfdid="w43"></asp:Label>&nbsp;&nbsp;<asp:Label id="lblIsRqdCalledBy" runat="server" CssClass="simplelabel" Text="*" Visible="False" ForeColor="Red" EnableTheming="False" __designer:wfdid="w44"></asp:Label></TD><TD style="WIDTH: 206px; HEIGHT: 30px" class="tblTDLeft"><asp:DropDownList id="drpCalledBy_rqd" tabIndex=12 runat="server" Width="158px" SkinID="Unicodeddl" Visible="False" ToolTip="बोलाउने कमिटि" __designer:wfdid="w45" OnSelectedIndexChanged="drpCalledBy_rqd_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> </TD></TR><TR></TR><TR><TD style="HEIGHT: 25px" class="tblTDRight"><asp:Label id="lblMeetingSubject" runat="server" Width="80px" Text="बिषय" SkinID="Unicodelbl" __designer:wfdid="w46"></asp:Label> &nbsp;<asp:Label id="Label48" runat="server" CssClass="simplelabel" Text="*" ForeColor="Red" EnableTheming="False" __designer:wfdid="w47"></asp:Label> </TD><TD style="HEIGHT: 25px" class="tblTDLeft" vAlign=middle colSpan=3><asp:TextBox id="txtSubject_rqd" tabIndex=13 runat="server" Width="446px" SkinID="Unicodetxt" ToolTip="बिषय" __designer:wfdid="w48" MaxLength="53"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 81px" height=1>&nbsp;</TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR><TD style="HEIGHT: 3px"></TD></TR><TR><TD style="PADDING-LEFT: 12px; HEIGHT: 4px" class="tblTDleft" align=left>&nbsp;&nbsp;<asp:ImageButton id="imgBtnExpand2" runat="server" ImageUrl="~/MODULES/OAS/Images/collapse.jpg" __designer:wfdid="w49"></asp:ImageButton>&nbsp; <asp:Label id="lblExpandStatus2" runat="server" Text="Label" SkinID="Unicodelbl" __designer:wfdid="w50"></asp:Label></TD></TR><TR><TD align=center><asp:Panel style="POSITION: static" id="pnlMeetingAgenda" runat="server" Width="97%" __designer:wfdid="w51" BorderColor="#c8cde4" BorderStyle="Solid" BorderWidth="1px"><TABLE style="BORDER-LEFT-COLOR: black; BORDER-BOTTOM-COLOR: black; BORDER-TOP-COLOR: black; BORDER-RIGHT-COLOR: black" cellSpacing=0 cellPadding=0 width="98%" border=0><TBODY><TR><TD style="HEIGHT: 33px" class="tblTDRight" align=left colSpan=1></TD><TD style="HEIGHT: 33px" align=left colSpan=4>&nbsp;</TD></TR><TR><TD style="HEIGHT: 38px" class="tblTDRight"><asp:Label id="lblAgenda" runat="server" Text="एजेन्डा" SkinID="Unicodelbl" __designer:wfdid="w52"></asp:Label> &nbsp;<asp:Label id="Label4145" runat="server" CssClass="simplelabel" Text="*" ForeColor="Red" EnableTheming="False" __designer:wfdid="w53"></asp:Label> </TD><TD style="WIDTH: 366px; HEIGHT: 38px" class="tblTDLeft" colSpan=3><asp:TextBox id="txtAgenda" tabIndex=14 runat="server" Width="254px" SkinID="Unicodetxt" ToolTip="एजेन्डा" __designer:wfdid="w54" MaxLength="30"></asp:TextBox> <asp:Button id="btnUpdAgenda" tabIndex=15 onclick="btnUpdAgenda_Click" runat="server" Text="Change" SkinID="Normal" ToolTip="Make Change" __designer:wfdid="w55"></asp:Button>&nbsp; <asp:Button id="btnAdd" tabIndex=16 onclick="btnAdd_Click" runat="server" Text="Add" SkinID="Normal" Visible="False" __designer:wfdid="w56"></asp:Button></TD><TD style="WIDTH: 17px; HEIGHT: 38px">&nbsp;</TD></TR><TR><TD style="HEIGHT: 79px">&nbsp;</TD><TD style="WIDTH: 366px; HEIGHT: 79px" class="tblTDLeft" vAlign=top align=left colSpan=3><asp:UpdatePanel id="updAgenda" runat="server" __designer:wfdid="w57"><ContentTemplate>
<DIV style="OVERFLOW: auto; WIDTH: 100%; max-height: 107px" border="0">

<asp:GridView id="grdAgenda" runat="server" SkinID="Unicodegrd" ForeColor="#333333" __designer:wfdid="w58" GridLines="Vertical" CellPadding="0" OnRowDataBound="grdAgenda_RowDataBound" OnRowDeleting="grdAgenda_RowDeleting" OnSelectedIndexChanging="grdAgenda_SelectedIndexChanging" OnRowCreated="grdAgenda_RowCreated" AutoGenerateColumns="False">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:TemplateField HeaderText="S.No">
<ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
<ItemTemplate>
                                     <%# Container.DataItemIndex + 1 %>.
                                           
                                                                            
                                
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="AgendaID" HeaderText="AgendaID"></asp:BoundField>
<asp:BoundField DataField="Agenda" HeaderText="Agenda">
<ItemStyle Width="50%"></ItemStyle>
</asp:BoundField>
<asp:CommandField ShowSelectButton="True">
<ItemStyle Width="10%"></ItemStyle>
</asp:CommandField>
<asp:CommandField SelectText="Remove" ShowDeleteButton="True" DeleteText="Remove">
<ItemStyle Width="10%"></ItemStyle>
</asp:CommandField>
<asp:BoundField DataField="Action"></asp:BoundField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> </DIV>
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click"></asp:AsyncPostBackTrigger>
</Triggers>
</asp:UpdatePanel> </TD></TR><TR><TD height=1>&nbsp;</TD></TR></TBODY></TABLE><ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender2" runat="server" TargetControlID="txtAgenda" __designer:wfdid="w59" FilterType="Custom, Numbers, UppercaseLetters, LowercaseLetters" ValidChars='" "'></ajaxToolkit:FilteredTextBoxExtender></asp:Panel> </TD></TR><TR><TD height=5>&nbsp;</TD></TR><TR><TD style="PADDING-LEFT: 17px; HEIGHT: 1px" class="tblleft" align=left>&nbsp;<asp:ImageButton id="imgBtnExpand3" runat="server" ImageUrl="~/MODULES/OAS/Images/collapse.jpg" __designer:wfdid="w60"></asp:ImageButton>&nbsp; <asp:Label id="lblExpandStatus3" runat="server" Text="Label" SkinID="Unicodelbl" __designer:wfdid="w61"></asp:Label></TD></TR><TR><TD align=center><asp:Panel style="POSITION: static" id="pnlParticipant" runat="server" Width="97%" __designer:wfdid="w62" BorderColor="#c8cde4" BorderStyle="Solid" BorderWidth="1px"><TABLE style="BORDER-LEFT-COLOR: black; BORDER-BOTTOM-COLOR: black; WIDTH: 96%; BORDER-TOP-COLOR: black; BORDER-RIGHT-COLOR: black" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 25%" class="tblTDRight">&nbsp;</TD></TR><TR><TD style="WIDTH: 25%; HEIGHT: 30px" class="tblTDRight">&nbsp;&nbsp; </TD><TD style="WIDTH: 363px; HEIGHT: 30px" class="tblTDLeft" colSpan=3><asp:Button id="btnAddOthers" tabIndex=17 onclick="btnAddOthers_Click" runat="server" Width="90px" Text="Add Others " SkinID="Dynamic" Visible="False" ToolTip="Add Other Members" __designer:wfdid="w63"></asp:Button> </TD></TR><TR><TD style="WIDTH: 25%" class="tblTDRight">&nbsp;&nbsp; </TD><TD style="WIDTH: 363px" class="tblTDLeft" vAlign=top colSpan=3>&nbsp; <asp:UpdatePanel id="updParticipant" runat="server" __designer:wfdid="w64"><ContentTemplate>
<DIV style="OVERFLOW: auto; WIDTH: 100%; HEIGHT: 119px; max-height: 182px" border="0"><asp:GridView id="grdParticipant" runat="server" SkinID="Unicodegrd" ForeColor="#333333" __designer:wfdid="w65" GridLines="Vertical" CellPadding="0" AutoGenerateColumns="False" OnRowCreated="grdParticipant_RowCreated" OnRowDeleting="grdParticipant_RowDeleting" OnRowDataBound="grdParticipant_RowDataBound">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:TemplateField><ItemTemplate>
<asp:CheckBox id="chkParticipant" runat="server" AutoPostBack="True" OnCheckedChanged="chkParticipant_CheckedChanged1"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="ParticipantID" HeaderText="ParticipantID"></asp:BoundField>
<asp:BoundField DataField="Participant" HeaderText="सहभागी">
<ItemStyle Width="50%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="PositionName" HeaderText="पोजिसन">
<ItemStyle Width="25%"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="सभापति"><ItemTemplate>
<asp:CheckBox id="chkMeetingHead" runat="server" AutoPostBack="True" OnCheckedChanged="chkMeetingHead_CheckedChanged"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="उपस्थिति"><ItemTemplate>
<asp:CheckBox id="chkPresence" runat="server" AutoPostBack="True" OnCheckedChanged="chkPresence_CheckedChanged"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="Action"></asp:BoundField>
<asp:BoundField DataField="PositionID"></asp:BoundField>
<asp:BoundField DataField="MeetingMemPosID"></asp:BoundField>
<asp:BoundField DataField="IsGrpParticipant"></asp:BoundField>
<asp:CommandField ShowDeleteButton="True" DeleteText="Remove">
<ItemStyle Width="5%"></ItemStyle>
</asp:CommandField>
<asp:BoundField DataField="IsPresent"></asp:BoundField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> </DIV>
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="imgBtnExpand3" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="imgBtnExpand2" EventName="Click"></asp:AsyncPostBackTrigger>
</Triggers>
</asp:UpdatePanel></TD><TD style="WIDTH: 17px">&nbsp;</TD></TR><TR><TD>&nbsp;</TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR><TD align=center></TD></TR><TR><TD align=center></TD></TR><TR><TD style="PADDING-LEFT: 17px; HEIGHT: 1px" class="tblleft" align=left>&nbsp;<asp:ImageButton id="imgBtnExpand4" runat="server" ImageUrl="~/MODULES/OAS/Images/collapse.jpg" __designer:wfdid="w66"></asp:ImageButton>&nbsp; <asp:Label id="lblMinuteStatus" runat="server" Text="Label" SkinID="Unicodelbl" __designer:wfdid="w67"></asp:Label> </TD></TR><TR><TD align=center><asp:Panel style="POSITION: static" id="pnlMinute" runat="server" Width="95%" __designer:wfdid="w68" BorderColor="#c8cde4" BorderStyle="Solid" BorderWidth="1px"><TABLE style="BORDER-LEFT-COLOR: black; BORDER-BOTTOM-COLOR: black; WIDTH: 96%; BORDER-TOP-COLOR: black; HEIGHT: 198px; BORDER-RIGHT-COLOR: black" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 118px" align=left>&nbsp;&nbsp;&nbsp;</TD><TD align=left colSpan=6>&nbsp;<asp:Label id="lblMinuteTitle" runat="server" SkinID="UnicodeHeadlbl" Font-Bold="False" __designer:wfdid="w69"></asp:Label> <BR /><asp:Label id="lblMinuteTiming" runat="server" SkinID="Unicodelbl" Font-Size="Small" Font-Names="Verdana" __designer:wfdid="w70" Font-Italic="True"></asp:Label> 
<HR />
</TD></TR><TR><TD style="WIDTH: 118px">&nbsp;</TD><TD align=left colSpan=5><asp:DataList id="dlstMinute" runat="server" __designer:wfdid="w71" RepeatColumns="1" OnItemDataBound="dlstMinute_ItemDataBound1"><ItemTemplate>
<asp:Label id="lblSN" runat="server" SkinID="Unicodelbl"></asp:Label> <asp:Label id="lblMinuteData" runat="server" Text='<%# Eval("Minute") %>' SkinID="Unicodelbl"></asp:Label> 
</ItemTemplate>
</asp:DataList></TD></TR><TR><TD style="WIDTH: 118px">&nbsp;</TD></TR><TR><TD style="WIDTH: 118px; HEIGHT: 11px">&nbsp;</TD><TD style="HEIGHT: 11px" align=left colSpan=5><asp:TextBox id="txtComment_cmt" tabIndex=18 runat="server" Width="293px" Height="88px" SkinID="Unicodetxt" ToolTip="कमेन्ट" __designer:wfdid="w72" MaxLength="75" TextMode="MultiLine"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 118px; HEIGHT: 6px">&nbsp;</TD><TD style="HEIGHT: 6px" align=left colSpan=5>&nbsp;<asp:CheckBox id="chkAgree" tabIndex=19 runat="server" Text="Agree" SkinID="smallChk" __designer:wfdid="w73" Checked="True"></asp:CheckBox>&nbsp; </TD></TR><TR><TD style="WIDTH: 118px; HEIGHT: 5px"></TD><TD style="HEIGHT: 5px" align=left>&nbsp;<asp:Button id="btnNewPost" tabIndex=20 onclick="btnNewPost_Click" runat="server" Text="Submit" SkinID="Normal" __designer:wfdid="w74" OnClientClick="javascript:return validateUpanelFields('_cmt','_cmt');"></asp:Button>&nbsp;<asp:Button id="btnPreviousPost" tabIndex=21 onclick="btnPreviousPost_Click" runat="server" Text="View Post" SkinID="Normal" __designer:wfdid="w75"></asp:Button></TD></TR><TR><TD style="WIDTH: 118px; HEIGHT: 5px"></TD><TD style="HEIGHT: 5px" align=left></TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><!-- --><TR><TD style="PADDING-RIGHT: 15px" align=right><asp:Button id="btnUpdate" tabIndex=22 onclick="btnUpdate_Click" runat="server" Text="Update" SkinID="Normal" ToolTip="Update Event" __designer:wfdid="w76" OnClientClick="return CheckTimeRange();"></asp:Button>&nbsp;<asp:Button id="btnDelete" tabIndex=23 onclick="btnDelete_Click" runat="server" Text="Delete" SkinID="Cancel" ToolTip="Delete Event" __designer:wfdid="w77"></asp:Button> <asp:Button id="btnCreateEvent" tabIndex=24 onclick="btnCreateEvent_Click" runat="server" Width="100px" Text="Create Event" SkinID="Dynamic" Visible="False" ToolTip="Create Event" __designer:wfdid="w78" OnClientClick="return CheckTimeRange();"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;</TD></TR></TBODY></TABLE><ajaxToolkit:CollapsiblePanelExtender id="CollapsiblePanelExtender1" runat="server" TargetControlID="pnlMeeting" __designer:wfdid="w79" SuppressPostBack="True" CollapsedText="मिटिङ्ग हेर्नुहोस्..." ExpandedText="मिटिङ्ग लुकाउनुहोस्..." ExpandedSize="325" CollapsedSize="0" CollapseControlID="imgBtnExpand1" ExpandControlID="imgBtnExpand1" ImageControlID="imgBtnExpand1" CollapsedImage="~/MODULES/OAS/Images/expand.jpg" ExpandedImage="~/MODULES/OAS/Images/collapse.jpg" TextLabelID="lblTest"></ajaxToolkit:CollapsiblePanelExtender> <ajaxToolkit:CollapsiblePanelExtender id="CollapsiblePanelExtender2" runat="server" TargetControlID="pnlMeetingAgenda" __designer:wfdid="w80" CollapsedText="मिटिङ्गको एजेन्डा हेर्नुहोस्..." ExpandedText="मिटिङ्गको एजेन्डा लुकाउनुहोस्..." ExpandedSize="210" CollapsedSize="0" CollapseControlID="imgBtnExpand2" ExpandControlID="imgBtnExpand2" ImageControlID="imgBtnExpand2" CollapsedImage="~/MODULES/OAS/Images/expand.jpg" ExpandedImage="~/MODULES/OAS/Images/collapse.jpg" TextLabelID="lblExpandStatus2" Collapsed="True"></ajaxToolkit:CollapsiblePanelExtender> <ajaxToolkit:CollapsiblePanelExtender id="CollapsiblePanelExtender3" runat="server" TargetControlID="pnlParticipant" __designer:wfdid="w81" CollapsedText="मिटिङ्गको सहभागीहरु हेर्नुहोस्..." ExpandedText="मिटिङ्गको सहभागीहरु लुकाउनुहोस्..." ExpandedSize="360" CollapsedSize="0" CollapseControlID="imgBtnExpand3" ExpandControlID="imgBtnExpand3" ImageControlID="imgBtnExpand3" CollapsedImage="~/MODULES/OAS/Images/expand.jpg" ExpandedImage="~/MODULES/OAS/Images/collapse.jpg" TextLabelID="lblExpandStatus3" Collapsed="True"></ajaxToolkit:CollapsiblePanelExtender> <ajaxToolkit:CollapsiblePanelExtender id="CollapsiblePanelExtender4" runat="server" TargetControlID="pnlMinute" __designer:wfdid="w82" CollapsedText="मिटिङ्गको माइनुतहरु हेर्नुहोस्..." ExpandedText="मिटिङ्गको माइनुतहरु लुकाउनुहोस्..." ExpandedSize="310" CollapsedSize="0" CollapseControlID="imgBtnExpand4" ExpandControlID="imgBtnExpand4" ImageControlID="imgBtnExpand4" CollapsedImage="~/MODULES/OAS/Images/expand.jpg" ExpandedImage="~/MODULES/OAS/Images/collapse.jpg" TextLabelID="lblMinuteStatus" Collapsed="True"></ajaxToolkit:CollapsiblePanelExtender>&nbsp; 
</contenttemplate>
                    <triggers>
<asp:AsyncPostBackTrigger ControlID="btnCreateEvent" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="OkButton" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnAddMember" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="imgBtnClose" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="imbBtnClose2" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="imgBtnExpand4" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="drpOrganisation_rqd" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="drp_MeetingCallerType_rqd" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="ddlVenueType_rqd" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:PostBackTrigger ControlID="imgSrchBtn"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="imgLocBooking"></asp:PostBackTrigger>
</triggers>
                </asp:UpdatePanel>
           
    </div>
    
    
    
    
    
    
    
    <!-- NB::  Code for External Meeting Participant Starts from Here -->
    <asp:Button ID="hiddenTargetControlForPersonModalPopup" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="programmaticPersonModalPopup" runat="server"
        BackgroundCssClass="modalBackground" BehaviorID="programmaticPersonModalPopupBehavior"
        DropShadow="false" PopupControlID="programmaticPersonPopup" PopupDragHandleControlID="programmaticPersonPopupDragHandle"
        RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForPersonModalPopup">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="programmaticPersonPopup" runat="server" BackColor="whitesmoke"
        Style="display: none;overflow:auto;width:90%;height:500px; padding: 10px">
        <p style="width: 100%;">
            <asp:ImageButton ID="imgBtnClose" runat="server" align="right" ImageUrl="~/MODULES/OAS/Images/btn_cancel.gif"
                OnClick="imgBtnClose_Click" Style="padding-right: 13px" />
          </p>
        <br />
        <asp:Panel ID="programmaticPersonPopupDragHandle" runat="Server" Style="cursor: move;">
            <fieldset>
                <legend>
                    <asp:Label ID="Label6" runat="server" Text="सहभागीहरु खोज्नुहोस" SkinID="Unicodelbl"></asp:Label>
                </legend>
                <asp:UpdatePanel ID="updSearchCriteria" runat="server">
                 <contenttemplate>
                    <TABLE style="WIDTH: 800px; TEXT-ALIGN: left"><TBODY><TR><TD style="WIDTH: 120px" vAlign=top><asp:Label id="Label14" runat="server" Width="75px" Text="पहिलो नाम" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 140px" vAlign=top><asp:TextBox id="txtSFirstName" runat="server" Width="100px" SkinID="Unicodetxt"></asp:TextBox></TD><TD style="WIDTH: 85px" vAlign=top><asp:Label id="Label16" runat="server" Width="80px" Text="बिचको नाम" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 140px" vAlign=top><asp:TextBox id="txtSMName" runat="server" Width="100px" SkinID="Unicodetxt"></asp:TextBox></TD><TD style="WIDTH: 115px" vAlign=top><asp:Label id="Label17" runat="server" Text="थर" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 110px" vAlign=top><asp:TextBox id="txtSLastName" runat="server" Width="100px" SkinID="Unicodetxt"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 120px" vAlign=top><asp:Label id="Label78" runat="server" Text="लिंग" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 140px" vAlign=top><asp:DropDownList id="ddlSGender" runat="server" Width="105px" SkinID="Unicodeddl"><asp:ListItem Value="SG">छान्नुहोस</asp:ListItem>
                    <asp:ListItem Value="M">पुरुष</asp:ListItem>
                    <asp:ListItem Value="F">महिला</asp:ListItem>
                    <asp:ListItem Value="O">अन्य</asp:ListItem>
                    </asp:DropDownList></TD><TD style="WIDTH: 85px" vAlign=top><asp:Label id="Label20" runat="server" Width="75px" Text="जन्म मिति" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 140px" vAlign=top><asp:TextBox id="txtSDOB_DT" runat="server" Width="100px" SkinID="Unicodetxt"></asp:TextBox></TD><TD style="WIDTH: 115px" vAlign=top><asp:Label id="Label25" runat="server" Width="110px" Text="बैबाहिक सम्बन्ध" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 110px" vAlign=top><asp:DropDownList id="ddlSMarStatus" runat="server" Width="105px" SkinID="Unicodeddl"><asp:ListItem Value="SMS">छान्नुहोस</asp:ListItem>
                    <asp:ListItem Value="S">अबिबाहित</asp:ListItem>
                    <asp:ListItem Value="M">बिबाहित</asp:ListItem>
                    <asp:ListItem Value="W">बिधवा/बिदुर</asp:ListItem>
                    <asp:ListItem Value="D">छोडपत्र</asp:ListItem>
                    <asp:ListItem Value="O">अन्य</asp:ListItem>
                    </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 120px" vAlign=top><asp:Label id="lblOrgSrch" runat="server" Text="संस्था" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 140px" vAlign=top colSpan=2><asp:DropDownList id="dllOrgSrch" tabIndex=15 runat="server" Width="214px" SkinID="Unicodeddl" OnSelectedIndexChanged="dllOrgSrch_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD><TD></TD><TD><asp:Label id="lblDesignation" runat="server" Text="पद" SkinID="Unicodelbl"></asp:Label></TD><TD><asp:DropDownList id="ddlDesignation" runat="server" Width="158px"></asp:DropDownList></TD><TD></TD></TR><TR vAlign=top><TD style="WIDTH: 120px" vAlign=top><asp:Label id="lblCommitte" runat="server" Text="कमिटि" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 140px" vAlign=top colSpan=2><asp:UpdatePanel id="updCommitteSrch" runat="server"><ContentTemplate>
                    <asp:DropDownList id="ddlCommittee" tabIndex=15 runat="server" Width="214px" SkinID="Unicodeddl" AutoPostBack="True"></asp:DropDownList> 
                    </ContentTemplate>
                    </asp:UpdatePanel> </TD><TD></TD><TD><asp:Label id="lblCommittePost" runat="server" Text="कमिटिको पद" SkinID="Unicodelbl"></asp:Label></TD><TD><asp:DropDownList id="ddlCommitteePost" runat="server" Width="158px"></asp:DropDownList>
                    </TD><TD></TD></TR></TBODY></TABLE><ajaxToolkit:MaskedEditExtender id="MaskedEditExtender1" runat="server" TargetControlID="txtSDOB_DT" AutoComplete="False" Mask="9999/99/99" MaskType="Date">
                                    </ajaxToolkit:MaskedEditExtender> 
                    </contenttemplate>
                                        <triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnAddMember" EventName="Click"></asp:AsyncPostBackTrigger>
                    </triggers>
                </asp:UpdatePanel>
                <table style="width: 787px; text-align: left">
                    <tr>
                        <td colspan = "2" style="height: 27px">&nbsp;</td>
                        <td colspan="4" style="height: 27px; width: 695px;" valign="top" align="right">
                            <asp:Button ID="btnPersonSearch" runat="server" OnClick="btnPersonSearch_Click"
                                Text="Search" SkinID="Normal" TabIndex="26" />
                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancelPersonSearch_Click"
                                Text="Cancel" SkinID="Cancel" TabIndex="27" />
                            <asp:Button ID="btnAddMember" runat="server" OnClick="btnAddMember_Click"
                                Text="Add Member" Width="100px" SkinID="Dynamic" TabIndex="28" />&nbsp;</td>
                    </tr>
                </table>
            </fieldset>
            &nbsp;
        </asp:Panel>
        <asp:UpdatePanel ID="UpdatePanelPersonSearch" runat="server">
            <contenttemplate>
<asp:Label id="lblSearchStatus" runat="server" SkinID="Unicodelbl" Font-Bold="True"></asp:Label><BR /><BR /><%--<asp:Panel ID="pnlPersonSearch" runat="server" Style="overflow: auto;  height: 161px; WIDTH: 100%">--%>

<DIV style="OVERFLOW: auto; HEIGHT: 200px;width:95%" border="0">
<asp:GridView id="grdPersonSearch" runat="server" Width="100%" ForeColor="#333333" GridLines="Vertical" CellPadding="0" AutoGenerateColumns="False" OnRowDataBound="grdPersonSearch_RowDataBound">
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
    

    <!-- NB::  Code for  Meeting Comments Starts from Here -->
    <asp:Button ID="hiddenTargetControlForCommentModalPopup" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="programmaticCommentModalPopup" runat="server"
        BackgroundCssClass="modalBackground" BehaviorID="programmaticCommentModalPopupBehavior"
        DropShadow="false" PopupControlID="programmaticCommentPopup" PopupDragHandleControlID="programmaticCommentPopupDragHandle"
        RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForCommentModalPopup">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="programmaticCommentPopup" runat="server" BackColor="whitesmoke" Height="400px"
        Style="display: none; padding: 10px">
        <p style="width: 380px;">
        <asp:ImageButton ID="imbBtnClose2" runat="server" align="right" ImageUrl="~/MODULES/OAS/Images/btn_cancel.gif"
                OnClick="imbBtnClose2_Click" Style="padding-right: 13px" />
        </p>
        <br />
        <asp:Panel ID="programmaticCommentPopupDragHandle" runat="Server">
         <fieldset>
            <legend>
                <asp:UpdatePanel id="updCommentCount" runat="server">
                    <contenttemplate>
<asp:Label id="lblComment" runat="server" SkinID="Unicodelbl"></asp:Label> 
</contenttemplate>
                </asp:UpdatePanel>
                
            </legend>
             <table style="width: 340px; text-align: left" border ="0">
                <tr>
                    <td align="center">
                        &nbsp;<asp:UpdatePanel id="updMeetingCommentsList" runat="server"><contenttemplate>
<DIV style="OVERFLOW: auto" border="0"><asp:DataList id="dlstComments" runat="server" Width="369px" BackColor="Gainsboro" RepeatColumns="1"><ItemTemplate>
<asp:Label id="lblMeetingCommentBy" runat="server" Text='<%# Eval("ResponseBy") %>' SkinID="Unicodelbl"></asp:Label><BR /><asp:Label id="lblMeetingCommentDate" runat="server" Text='<%# Eval("NoteOn") %>' SkinID="Unicodelbl"></asp:Label><BR /><asp:Label id="lblMeetingComments" runat="server" Text='<%# Eval("Response") %>' SkinID="Unicodelbl"></asp:Label> <BR />
</ItemTemplate>

<AlternatingItemStyle BackColor="WhiteSmoke"></AlternatingItemStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>

<SeparatorStyle Height="5px"></SeparatorStyle>
<SeparatorTemplate>
                    <TABLE style="WIDTH: 100%; HEIGHT: 3px"><TBODY><TR><TD style="WIDTH: 100%; HEIGHT: 3px"></TD></TR></TBODY></TABLE>
                    
</SeparatorTemplate>
</asp:DataList> </DIV>
</contenttemplate>
                        </asp:UpdatePanel>
                        </td>
                </tr>
             </table>
        </fieldset>
        </asp:Panel>
       
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
&nbsp;<asp:Panel id="programmaticBookedVenuePopupDragHandle" runat="Server" __designer:wfdid="w23"><FIELDSET><LEGEND><asp:Label id="lblTitle" runat="server" Text="यहि समय तालिकामा अरू कार्यहरु छन्" EnableTheming="False" __designer:wfdid="w24"></asp:Label> </LEGEND><BR /><DIV border="0"><asp:GridView id="grdChkEvents" runat="server" SkinID="Unicodegrd" ForeColor="#333333" __designer:wfdid="w25" GridLines="None" CellPadding="4" OnRowDataBound="grdChkEvents_RowDataBound" AutoGenerateColumns="False">
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
</asp:GridView> </DIV><BR /><TABLE cellSpacing=2 cellPadding=0 border=0><TBODY><TR><TD><asp:Button id="btnChkEOk" onclick="btnChkEOk_Click" runat="server" Width="29px" Text="OK" SkinID="Normal"></asp:Button></TD><TD><asp:Button id="btnChkEUpdate" onclick="btnChkUpdate_Click" runat="server" Text="Update" SkinID="Normal"></asp:Button></TD><TD><asp:Button id="btnChkECancel" onclick="btnChkECancel_Click" runat="server" Text="Cancel" SkinID="Cancel"></asp:Button></TD></TR></TBODY></TABLE><asp:Label id="lblNote" runat="server" Width="530px" Text="(नोट : यदि Event क्रियत गर्न चाहनुहुन्छ भने OK किल्क गर्नुहोस्, नत्र Cancel किल्क गर्नहोस्।)" Font-Size="Small" Font-Names="Verdana" ForeColor="Red" EnableTheming="False" __designer:wfdid="w1"></asp:Label> <BR /><BR /></FIELDSET><BR /></asp:Panel>&nbsp; 
</ContentTemplate>
     </asp:UpdatePanel>
    </asp:Panel>
   </div>
    &nbsp;
        

           
   
</asp:Content>
