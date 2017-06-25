<%@ Page Language="C#" EnableEventValidation="false" MaintainScrollPositionOnPostback="true"
    MasterPageFile="~/MODULES/OAS/MasterPage.master" ValidateRequest="false" AutoEventWireup="true"
    CodeFile="MessageLetter.aspx.cs" Inherits="MODULES_OAS_Forms_MessageLetter" Title="OAS|Letter New" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
     
    <script language="javascript" src="../../COMMON/JS/Validation.js" type="text/javascript"></script>

    <script language="javascript" src="../../COMMON/JS/DateValidator.js" type="text/javascript"></script>
   
    
    <script language="javascript" type="text/javascript">
    
    
        function GetID(obj)
        {
           BeginRequestHandler();
        }
    
        function SetDivHeight(elem,val)
        {  
             objDiv = document.getElementById(elem);
             objDiv.style.height = val;
        }
    
        function ShowDiv(val)
        {  
            if(val != "")
            {
                 var iframe;
                 var objTo = document.getElementById(val);
                 
                 objTo.style.width = "60%";
                 
                
                 
                 if(val == "dvReceipient")
                 {
                    objTo.className = "msgTo-visible";                
                    
                    iframe = document.getElementById('iframetop1');
                    iframe.style.height = objTo.offsetHeight-5 + 'px'
                   
                 }
                 else
                 {
                    objTo.className = "msgToCc1-visible";
                    
                    iframe = document.getElementById('iframetop2');
                    iframe.style.height = objTo.offsetHeight-5 + 20 + 'px'
                 }
                 
                 iframe.style.visibility="visible";
                 iframe.style.display = 'block';
                    
                 iframe.style.width = objTo.offsetWidth-5 + 'px';
                 
                 iframe.style.left = objTo.offsetLeft + 'px'
                 iframe.style.top = objTo.offsetTop + 'px'
                    
             }
        }
        
        function HideDiv(val)
        { 
            var iframe;
            
            var objDiv = document.getElementById(val);
            objDiv.className = "msgTo-invisible";
          
            
             if(val == "dvReceipient")
             {
               iframe = document.getElementById('iframetop1');
               iframe.style.display = 'none';
             }
             else
             {
               iframe = document.getElementById('iframetop2');
               iframe.style.display = 'none';
             }
           
        }
        
        function CheckUncheckAll(obj)
        {
            try
            {  
                if (obj.getAttribute("id").search(/chkAllPeople/i) != -1)
		        {   
                    var grid = document.getElementById("<%= grdPeople.ClientID %>");
                }
                else if (obj.getAttribute("id").search(/chkAllCategories/i) != -1)
                {   var grid = document.getElementById("<%= grdCategory.ClientID %>");
                }
                else if (obj.getAttribute("id").search(/chkAllGroups/i) != -1)
                {    var grid = document.getElementById("<%= grdGroup.ClientID %>");
                }
                else if (obj.getAttribute("id").search(/chkAllCcPeople/i) != -1)
		        {  
                    var grid = document.getElementById("<%= grdPeopleCc.ClientID %>");
                }
                else if (obj.getAttribute("id").search(/chkAllCcCategories/i) != -1)
                {   var grid = document.getElementById("<%= grdCategoryCc.ClientID %>");
                }
                else if (obj.getAttribute("id").search(/chkAllCcGroups/i) != -1)
                {    var grid = document.getElementById("<%= grdGroupCc.ClientID %>");
                }
                else if (obj.getAttribute("id").search(/chkAllPpl/i) != -1)
                {    var grid = document.getElementById("<%= grdTmp.ClientID %>");
                }
                else if (obj.getAttribute("id").search(/chkAllCcPpl/i) != -1)
                {    var grid = document.getElementById("<%= grdCcTmp.ClientID %>");
                }
                                               
                
                 var grdRowCount = grid.rows.length  ;        
                 
                 for(var x = 0;x < grdRowCount; x++)
                 {    
                   var v=  grid.rows[x].cells[0].children[0];
                
                   if(obj.checked)
                        v.checked=true;               
                    else
                        v.checked = false;
                 }
                 
            }
            catch(err)
            {
                alert(err);
            }
        }
        
        
        function SetDivScrollTop(val) 
        {
            var obj = document.getElementById(val);
            document.getElementById('hdnScrollTop').value = obj.scrollTop;
        }

        function ResetDivScrollTop(val)
        {
             var obj = document.getElementById(val);
             obj.scrollTop = document.getElementById('hdnScrollTop').value;
        }
        
          function hideTr(val)
          {
             objTR = document.getElementById(val);
             objTR.className = "invisible";
          }
          
          function showTr(val)
          {
             objTR = document.getElementById(val);
             objTR.className = "visible";
          }
    
    
function dvCcReceiver_onclick() {

}

    </script>

    <input id="hdnScrollTop" type="hidden" />
    <div style="width: 100%;">
        <!-- For Popup error status -->
        <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
        <ajaxToolKit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground"
            BehaviorID="programmaticModalPopupBehavior" DropShadow="True" PopupControlID="programmaticPopup"
            PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
            TargetControlID="hiddenTargetControlForModalPopup">
        </ajaxToolKit:ModalPopupExtender>
        <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none;
            width: 350px; padding: 10px">
            &nbsp;&nbsp;
            <asp:UpdatePanel id="UpdatePanelavc" runat="server">
                <contenttemplate>
<asp:Panel style="BORDER-RIGHT: gray 1px solid; BORDER-TOP: gray 1px solid; BORDER-LEFT: gray 1px solid; CURSOR: move; COLOR: black; BORDER-BOTTOM: gray 1px solid; BACKGROUND-COLOR: #dddddd; TEXT-ALIGN: center" id="programmaticPopupDragHandle" runat="Server"><asp:Label id="lblStatusMessageTitle" runat="server" CssClass="simplelabel"></asp:Label></asp:Panel> <asp:Label id="lblStatusMessage" runat="server" CssClass="simplelabel" EnableTheming="False" ForeColor="Black"></asp:Label> 
</contenttemplate>
            </asp:UpdatePanel>
            <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
                Text="OK" Width="58px" />
            <br />
        </asp:Panel>
        &nbsp;&nbsp;
        <!-- end error status -->
        <table width="100%" cellpadding="0" cellspacing="0" border="0" style="border-color: Red">
            <tr>
                <td align="center">
                    <table width="80%" cellpadding="0" cellspacing="0" border="0" style="border-color: Red">
                        <tr>
                            <td style="height: 50px;" align="left">
                                <asp:Label ID="lblHeader" runat="server" SkinID="UnicodeHeadlbl" Text="Letter"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" valign="middle" style="padding-left: 60px; height: 50px;">
                                <asp:UpdatePanel id="updBtns" runat="server">
                                    <contenttemplate>
<asp:Button id="btnInbox" onclick="btnInbox_Click" runat="server" Width="58px" Text="InBox" SkinID="Normal"></asp:Button>&nbsp;<asp:Button id="btnOutbox" onclick="btnOutbox_Click" runat="server" Width="58px" Text="OutBox" SkinID="Normal"></asp:Button>&nbsp;<asp:Button id="btnSend" onclick="btnSend_Click" runat="server" Width="64px" Text="Send" SkinID="Normal" OnClientClick="return validate();"></asp:Button>&nbsp;<asp:Button id="btnCancel" onclick="Cancel_Click" runat="server" Text="Cancel" SkinID="Cancel"></asp:Button>&nbsp;

 
</contenttemplate>
                                </asp:UpdatePanel>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:UpdatePanel id="updEditor" runat="server">
                                    <contenttemplate>
<FIELDSET><TABLE style="BORDER-LEFT-COLOR: blue; BORDER-BOTTOM-COLOR: blue; BORDER-TOP-COLOR: blue; BORDER-RIGHT-COLOR: blue" cellSpacing=0 cellPadding=0 width="80%" border=0><TBODY><TR><TD style="WIDTH: 70px" class="tblTDRight"><asp:Button id="btnTo" onclick="btnTo_Click" runat="server" Width="69px" Text="          To :" SkinID="Normal" OnClientClick='javascript:ShowDiv("dvReceipient");' __designer:wfdid="w38"></asp:Button></TD><TD style="WIDTH: 621px; PADDING-TOP: 10px" class="tblTDLeft" vAlign=top><DIV style="VERTICAL-ALIGN: top; OVERFLOW: auto; WIDTH: 600px; max-height: 48px" id="dvReceiver" border="0"><asp:DataList id="dlReceiver" runat="server" Width="581px" Font-Size="2px" BackColor="LightGoldenrodYellow" __designer:wfdid="w39" BorderWidth="1px" OnSelectedIndexChanged="dlReceiver_SelectedIndexChanged" RepeatColumns="4" BorderColor="Tan"><ItemTemplate>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <DIV style="BORDER-RIGHT: #d2b48c 1px solid; BORDER-TOP: #d2b48c 1px solid; BORDER-LEFT: #d2b48c 1px solid; BORDER-BOTTOM: #d2b48c 1px solid"><TABLE cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR><TD style="WIDTH: 80%; HEIGHT: 16px"><asp:Label id="lblReceiver" runat="server" Text='<%# Eval("DisplayName") %>' Font-Size="X-Small" Font-Names="Verdana" BackColor="White" EnableTheming="True" __designer:wfdid="w3" ToolTip='<%# Eval("DetailName") %>' CausesValidation="False"></asp:Label> </TD><TD style="PADDING-RIGHT: 2px; HEIGHT: 16px" align=right>&nbsp;&nbsp;<asp:ImageButton id="imgBtnRemove1" onclick="imgBtnRemove1_Click" runat="server" ImageUrl="~/MODULES/OAS/Images/bycat1.ico" BackColor="White" __designer:wfdid="w4" CommandName="Select" CommandArgument='<%# Eval("OtherReceiverID")  + "/" + Eval("ReceiverOrgID") + "/" + Eval("GroupID")+ "/" + Eval("ReceiverType") + "/" + Eval("ISCC") %>'></asp:ImageButton> </TD></TR></TBODY></TABLE></DIV>
</ItemTemplate>

<AlternatingItemStyle BorderColor="Tan"></AlternatingItemStyle>
</asp:DataList>&nbsp; </DIV></TD></TR><TR><TD style="WIDTH: 70px; HEIGHT: 32px" class="tblTDRight"><asp:Label id="lblFrom" runat="server" Text="From :" __designer:wfdid="w40"></asp:Label> </TD><TD style="WIDTH: 621px; HEIGHT: 32px" class="tblTDLeft"><asp:Label id="lblUserName" runat="server" __designer:wfdid="w41"></asp:Label> </TD></TR><TR><TD style="WIDTH: 70px" class="tblTDRight"><asp:Label id="lblSubject" runat="server" Text="Subject :" __designer:wfdid="w42"></asp:Label> </TD><TD style="WIDTH: 621px" class="tblTDLeft"><asp:TextBox id="txtSubject_rqd" runat="server" Width="594px" __designer:wfdid="w43" ToolTip="Subject"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 70px" class="tblTDRight"><asp:Label id="Label9" runat="server" Width="56px" Text=" Type :" __designer:wfdid="w44"></asp:Label></TD><TD style="WIDTH: 621px" class="tblTDLeft"><asp:DropDownList id="ddlLetterType" runat="server" Width="170px" __designer:wfdid="w45" OnSelectedIndexChanged="ddlFilterTo_SelectedIndexChanged" AutoPostBack="True"><asp:ListItem Value="-1">छान्नुहोस्</asp:ListItem>
<asp:ListItem Value="T">टिप्पणी</asp:ListItem>
<asp:ListItem Value="O">अरु</asp:ListItem>
</asp:DropDownList></TD></TR><TR><TD style="WIDTH: 70px" class="tblTDRight"><asp:Label id="Label4" runat="server" Text="To :" __designer:wfdid="w46"></asp:Label></TD><TD style="WIDTH: 621px" class="tblTDLeft"><TABLE style="WIDTH: 505px; HEIGHT: 69px"><TBODY><TR><TD style="WIDTH: 75px"><asp:Label id="Label21" runat="server" Width="69px" Text="पठाउनु पर्ने" __designer:wfdid="w47"></asp:Label> </TD><TD style="WIDTH: 150px" class="tblTDLeft"><asp:DropDownList id="ddlFilterTo" runat="server" __designer:wfdid="w48" OnSelectedIndexChanged="ddlFilterTo_SelectedIndexChanged" AutoPostBack="True"><asp:ListItem Value="-1">छान्नुहोस्</asp:ListItem>
<asp:ListItem Value="1">संस्था</asp:ListItem>
<asp:ListItem Value="2">शाखा</asp:ListItem>
<asp:ListItem Value="3">व्यक्ति</asp:ListItem>
</asp:DropDownList> </TD><TD style="WIDTH: 37px" vAlign=top><asp:Label id="lblOrganisation1" runat="server" Text="संस्था" __designer:wfdid="w49"></asp:Label> </TD><TD class="tblTDLeft"><asp:DropDownList id="ddlOrgTo" runat="server" Width="200px" __designer:wfdid="w50" OnSelectedIndexChanged="ddlOrgTo_SelectedIndexChanged" AutoPostBack="True" Enabled="False"></asp:DropDownList> </TD></TR><TR><TD style="WIDTH: 75px"><asp:Label id="lblUnit1" runat="server" Text="शाखा" __designer:wfdid="w51"></asp:Label></TD><TD style="WIDTH: 150px" class="tblTDLeft"><asp:DropDownList id="ddlUnitTo" runat="server" Width="122px" __designer:wfdid="w52" OnSelectedIndexChanged="ddlUnitTo_SelectedIndexChanged" AutoPostBack="True" Enabled="False"></asp:DropDownList></TD><TD style="WIDTH: 37px" vAlign=top>&nbsp;<asp:Label id="Label3" runat="server" Text="व्यक्ति" __designer:wfdid="w53"></asp:Label></TD><TD class="tblTDLeft"><asp:DropDownList id="ddlPersonTo" runat="server" Width="199px" __designer:wfdid="w54" OnSelectedIndexChanged="ddlPersonTo_SelectedIndexChanged" AutoPostBack="True" Enabled="False"></asp:DropDownList></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="WIDTH: 70px; HEIGHT: 31px" class="tblTDRight"><asp:Label id="lblAttach" runat="server" Text="Attach " __designer:wfdid="w55"></asp:Label> <asp:Image id="Image1" runat="server" ImageUrl="~/MODULES/OAS/Images/i_attach.gif" __designer:wfdid="w56"></asp:Image></TD><TD style="WIDTH: 621px; HEIGHT: 31px" class="tblTDLeft"><asp:FileUpload id="fupdAttach" runat="server" Width="272px" Font-Size="Small" Font-Names="Verdana" __designer:wfdid="w57"></asp:FileUpload>&nbsp;&nbsp;<asp:Button id="btnUpload" onclick="btnUpload_Click" runat="server" Width="35px" Text="Add" SkinID="Normal" __designer:wfdid="w58"></asp:Button></TD></TR><TR><TD style="WIDTH: 70px; HEIGHT: 31px" class="tblTDRight"></TD><TD style="PADDING-BOTTOM: 10px; WIDTH: 621px; HEIGHT: 37px" class="tblTDLeft"><DIV style="VERTICAL-ALIGN: top; OVERFLOW: auto; WIDTH: 610px; max-height: 50px" id="dvAttachment" border="0"><asp:DataList id="dlUpdAttachment" runat="server" Width="581px" Height="11px" Font-Size="2px" BackColor="LightGoldenrodYellow" ForeColor="Black" __designer:wfdid="w59" BorderWidth="1px" OnSelectedIndexChanged="dlUpdAttachment_SelectedIndexChanged" RepeatColumns="4" BorderColor="Tan" CellPadding="2">
<FooterStyle BackColor="Tan"></FooterStyle>

<SelectedItemStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite"></SelectedItemStyle>
<ItemTemplate>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <DIV style="BORDER-RIGHT: #d2b48c 1px solid; BORDER-TOP: #d2b48c 1px solid; BORDER-LEFT: #d2b48c 1px solid; BORDER-BOTTOM: #d2b48c 1px solid"><TABLE cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR><TD style="WIDTH: 80%; HEIGHT: 16px"><asp:Label id="lblAttachment" runat="server" Text='<%# Eval("DisplayName") %>' Font-Size="X-Small" Font-Names="Verdana" EnableTheming="True" BackColor="White" ToolTip='<%# Eval("FileName") %>' CausesValidation="False"></asp:Label> </TD><TD style="PADDING-RIGHT: 2px; HEIGHT: 16px" align=right>&nbsp;&nbsp;<asp:ImageButton id="imgBtnRemove" onclick="imgBtnRemove_Click" runat="server" ImageUrl="~/MODULES/OAS/Images/bycat1.ico" BackColor="White" CommandName="Select"></asp:ImageButton> </TD></TR><TR><TD colSpan=2><asp:Label id="Label1" runat="server" Text='<%# Eval("DateCreated") %>' BackColor="#CCCCCC" Visible="False"></asp:Label></TD></TR></TBODY></TABLE></DIV>
</ItemTemplate>

<AlternatingItemStyle BackColor="LightGoldenrodYellow" BorderColor="Tan"></AlternatingItemStyle>

<HeaderStyle BackColor="Tan" Font-Bold="True"></HeaderStyle>
</asp:DataList> </DIV></TD></TR><TR><TD style="WIDTH: 70px; HEIGHT: 31px" class="tblTDRight"></TD><TD style="PADDING-BOTTOM: 10px; MARGIN-LEFT: 20px; WIDTH: 621px; HEIGHT: 37px" class="tblTDLeft"><FTB:FreeTextBox id="HtmlEditor1" runat="server" Width="600px" Height="370px" BackColor="127, 157, 185" __designer:wfdid="w60" BreakMode="LineBreak" GutterBackColor="127, 157, 185" StartMode="DesignMode" ToolbarBackColor="127, 157, 185" ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline,Strikethrough;Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;InsertRule|Cut,Copy,Paste;Undo,Redo,Print">
                </FTB:FreeTextBox></TD></TR><TR><TD style="WIDTH: 70px" class="tblTDRight"><asp:Button id="btnCc" onclick="btnCc_Click" runat="server" Width="69px" Text="          Cc :" SkinID="Normal" OnClientClick='javascript:ShowDiv("dvReceipientCc");' __designer:wfdid="w61"></asp:Button></TD><TD style="WIDTH: 621px; PADDING-TOP: 10px" class="tblTDLeft"><DIV style="VERTICAL-ALIGN: top; OVERFLOW: auto; WIDTH: 600px; max-height: 48px" id="dvCcReceiver" onclick="return dvCcReceiver_onclick()" border="0"><asp:DataList id="dlReceiverCc" runat="server" Width="581px" Font-Size="2px" BackColor="LightGoldenrodYellow" __designer:wfdid="w62" BorderWidth="1px" OnSelectedIndexChanged="dlReceiverCc_SelectedIndexChanged" RepeatColumns="4" BorderColor="Tan"><ItemTemplate>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <DIV style="BORDER-RIGHT: #d2b48c 1px solid; BORDER-TOP: #d2b48c 1px solid; BORDER-LEFT: #d2b48c 1px solid; BORDER-BOTTOM: #d2b48c 1px solid"><TABLE cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR><TD style="WIDTH: 80%"><asp:Label id="lblReceiver" runat="server" Text='<%# Eval("DisplayName") %>' Font-Size="X-Small" Font-Names="Verdana" BackColor="White" EnableTheming="True" __designer:wfdid="w5" ToolTip='<%# Eval("DetailName") %>' CausesValidation="False"></asp:Label> </TD><TD style="PADDING-RIGHT: 2px" align=right>&nbsp;&nbsp;<asp:ImageButton id="imgBtnRemove1" onclick="imgBtnRemove1_Click" runat="server" ImageUrl="~/MODULES/OAS/Images/bycat1.ico" BackColor="White" __designer:wfdid="w6" CommandName="Select" CommandArgument='<%# Eval("OtherReceiverID")  + "/" + Eval("ReceiverOrgID") + "/" + Eval("GroupID")+ "/" + Eval("ReceiverType") + "/" + Eval("ISCc") %>'></asp:ImageButton> </TD></TR></TBODY></TABLE></DIV>
</ItemTemplate>

<AlternatingItemStyle BorderColor="Tan"></AlternatingItemStyle>
</asp:DataList> </DIV></TD></TR><TR><TD style="WIDTH: 70px" class="tblTDRight" vAlign=top><asp:Label id="Label81" runat="server" Text="From :" __designer:wfdid="w63"></asp:Label></TD><TD style="WIDTH: 621px" class="tblTDLeft"><TABLE style="WIDTH: 505px; HEIGHT: 69px"><TBODY><TR><TD style="WIDTH: 75px"><asp:Label id="Label5" runat="server" Width="69px" Text="पठाउने" __designer:wfdid="w64"></asp:Label> </TD><TD style="WIDTH: 150px" class="tblTDLeft"><asp:DropDownList id="ddlFilterFrom" runat="server" __designer:wfdid="w65" OnSelectedIndexChanged="ddlFilterFrom_SelectedIndexChanged" AutoPostBack="True" Enabled="False"><asp:ListItem Value="-1">छान्नुहोस्</asp:ListItem>
<asp:ListItem Value="1">संस्था</asp:ListItem>
<asp:ListItem Value="2">शाखा</asp:ListItem>
<asp:ListItem Value="3">व्यक्ति</asp:ListItem>
</asp:DropDownList> </TD><TD style="WIDTH: 37px" vAlign=top><asp:Label id="Label6" runat="server" Text="संस्था" __designer:wfdid="w66"></asp:Label> </TD><TD class="tblTDLeft"><asp:DropDownList id="ddlOrgFrom" runat="server" Width="200px" __designer:wfdid="w67" OnSelectedIndexChanged="ddlOrgFrom_SelectedIndexChanged" AutoPostBack="True" Enabled="False"></asp:DropDownList> </TD></TR><TR><TD style="WIDTH: 75px"><asp:Label id="Label7" runat="server" Text="शाखा" __designer:wfdid="w68"></asp:Label></TD><TD style="WIDTH: 150px" class="tblTDLeft"><asp:DropDownList id="ddlUnitFrom" runat="server" Width="122px" __designer:wfdid="w69" OnSelectedIndexChanged="ddlUnitFrom_SelectedIndexChanged" AutoPostBack="True" Enabled="False"></asp:DropDownList></TD><TD style="WIDTH: 37px" vAlign=top>&nbsp;<asp:Label id="Label8" runat="server" Text="व्यक्ति" __designer:wfdid="w70"></asp:Label></TD><TD class="tblTDLeft"><asp:DropDownList id="ddlPersonFrom" runat="server" Width="199px" __designer:wfdid="w71" OnSelectedIndexChanged="ddlPersonFrom_SelectedIndexChanged" AutoPostBack="True" Enabled="False"></asp:DropDownList></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="WIDTH: 70px" class="tblTDRight"><asp:Label id="lblApprove" runat="server" Text="Approve :" __designer:wfdid="w72"></asp:Label></TD><TD style="WIDTH: 621px" class="tblTDLeft"><asp:CheckBox id="chkApprove" runat="server" __designer:wfdid="w73"></asp:CheckBox>&nbsp; <asp:Label id="lbltitle" runat="server" Text="( यस बमोजिम स्वीकार्थ पेश गरेको छु । )" SkinID="Unicodelbl" __designer:wfdid="w74"></asp:Label> </TD></TR></TBODY></TABLE></FIELDSET> 
</contenttemplate>
                                    <triggers>
<asp:AsyncPostBackTrigger ControlID="btnClose" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnTo" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnSend" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="OkButton" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:PostBackTrigger ControlID="btnUpload"></asp:PostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnCc" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="imgComment" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="imgPplCcClose" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="imgPplCcClose" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        
        <!-- NB::  Code for  Receipient Set------------------------------------------------------------  -->
        <div id="dragger">
            <div id="dvReceipient" class="loading-invisible">
                <asp:UpdatePanel id="updReceipient" runat="server">
                    <contenttemplate>
                        <TABLE style="BORDER-LEFT-COLOR: red; BORDER-BOTTOM-COLOR: red; BORDER-TOP-COLOR: red; BORDER-RIGHT-COLOR: red" cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR><TD>&nbsp;</TD><TD style="PADDING-RIGHT: 10px" align=right><asp:LinkButton id="btnClose" onclick="btnClose_Click" runat="server" Font-Size="Medium" Font-Names="Verdana" OnClientClick='avascript:HideDiv("dvReceipient");' Font-Underline="False">Close</asp:LinkButton> </TD></TR><TR><TD style="PADDING-LEFT: 0px" align=left colSpan=2><ajaxToolKit:TabContainer id="tabContainerReceiver" runat="server" CssClass="ajax_tab_theme" EnableTheming="False" ActiveTabIndex="0"><ajaxToolKit:TabPanel runat="server" ID="TabPanel1" HeaderText="TabPanel1"><ContentTemplate>
                        <TABLE cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR style="BACKGROUND-COLOR: #eeeeed"><TD style="PADDING-LEFT: 27px" align=left colSpan=2><TABLE style="WIDTH: 451px"><TBODY><TR><TD style="WIDTH: 75px"><asp:Label id="Label2" runat="server" Text="पठाउनु पर्ने"></asp:Label> </TD><TD style="WIDTH: 131px" class="tblTDLeft"><asp:DropDownList id="ddlFilterReceiver" runat="server" OnSelectedIndexChanged="ddlFilterReceiver_SelectedIndexChanged" AutoPostBack="True"><asp:ListItem Value="-1">छान्नुहोस्</asp:ListItem>
                        <asp:ListItem Value="1">संस्था</asp:ListItem>
                        <asp:ListItem Value="2">शाखा</asp:ListItem>
                        <asp:ListItem Value="3">व्यक्ति</asp:ListItem>
                        </asp:DropDownList> </TD><TD><asp:Label id="lblOrganisation" runat="server" Text="संस्था"></asp:Label> </TD><TD class="tblTDLeft"><asp:DropDownList id="ddlOrg" runat="server" Width="200px" OnSelectedIndexChanged="ddlOrg_SelectedIndexChanged" AutoPostBack="True" Enabled="False"></asp:DropDownList> </TD></TR><TR><TD style="WIDTH: 75px; HEIGHT: 32px"></TD><TD style="WIDTH: 131px; HEIGHT: 32px" class="tblTDLeft"></TD><TD style="HEIGHT: 32px"><asp:Label id="lblUnit" runat="server" Text="शाखा"></asp:Label> </TD><TD style="HEIGHT: 32px" class="tblTDLeft"><asp:DropDownList id="ddlUnit" runat="server" Width="122px" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged" AutoPostBack="True" Enabled="False"></asp:DropDownList> <asp:ImageButton id="imgPplBooking" onclick="imgPplBooking_Click" runat="server" ImageUrl="~/MODULES/OAS/Images/Book [1600x1200].jpg" ToolTip="नयाँ स्थल बुकिङ्ग"></asp:ImageButton></TD></TR></TBODY></TABLE></TD></TR><TR style="BACKGROUND-COLOR: #eeeeed"><TD style="PADDING-LEFT: 5px; HEIGHT: 24px" align=left colSpan=1><asp:UpdatePanel id="UpdatePanel111" runat="server"><ContentTemplate>
                        <asp:CheckBox id="chkAllPeople" runat="server"></asp:CheckBox> <asp:Label id="lblSelectAllPpl" runat="server" Text="Select All"></asp:Label> 
                        </ContentTemplate>
                        </asp:UpdatePanel> </TD><TD style="PADDING-RIGHT: 5px; HEIGHT: 24px" align=right><asp:TextBox id="txtSearchPeople" runat="server" CssClass="SearchTxt" Width="300px" AutoPostBack="True" OnTextChanged="txtSearchPeople_TextChanged"></asp:TextBox> </TD></TR><TR><TD align=left colSpan=2><asp:UpdatePanel id="updPeople" runat="server"><ContentTemplate>
                        <DIV style="OVERFLOW: auto; WIDTH: 100%; HEIGHT: 217px" id="divGridPpl" border="0"><asp:GridView id="grdPeople" runat="server" Width="300px" ForeColor="#333333" EnableTheming="False" CellPadding="4" OnRowCreated="grdPeople_RowCreated" ShowHeader="False" GridLines="None" OnRowDataBound="grdPeople_RowDataBound">
                        <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
                        <Columns>
                        <asp:TemplateField>
                        <ItemStyle Width="5%"></ItemStyle>
                        <ItemTemplate>
                        <asp:CheckBox id="chkPeople" runat="server"></asp:CheckBox> 
                        </ItemTemplate>
                        </asp:TemplateField>
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
                        <asp:AsyncPostBackTrigger ControlID="chkAllPeople" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="btnTo" EventName="Click"></asp:AsyncPostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="txtSearchPeople" EventName="TextChanged"></asp:AsyncPostBackTrigger>
                        </Triggers>
                        </asp:UpdatePanel> </TD></TR></TBODY></TABLE>
                        </ContentTemplate>
                        <HeaderTemplate>
                                                                    People
                                                                
                        </HeaderTemplate>
                        </ajaxToolKit:TabPanel>
                        <ajaxToolKit:TabPanel runat="server" ID="TabPanel2" HeaderText="TabPanel2"><ContentTemplate>
                        <TABLE cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR style="BACKGROUND-COLOR: #eeeeed"><TD style="PADDING-LEFT: 5px; HEIGHT: 24px" align=left><asp:UpdatePanel id="UpdatePanel11" runat="server"><ContentTemplate>
                        <asp:CheckBox id="chkAllCategories" runat="server"></asp:CheckBox> <asp:Label id="lblSelectAllCategories" runat="server" Text="Select All"></asp:Label> 
                        </ContentTemplate>
                        </asp:UpdatePanel> </TD><TD style="PADDING-RIGHT: 5px; HEIGHT: 24px" align=right><asp:TextBox id="txtSearchCategory" runat="server" CssClass="SearchTxt" Width="300px" AutoPostBack="True" OnTextChanged="txtSearchCategory_TextChanged"></asp:TextBox> </TD></TR><TR><TD align=left colSpan=2><asp:UpdatePanel id="updCategory" runat="server"><ContentTemplate>
                        <DIV style="OVERFLOW: auto; WIDTH: 100%; HEIGHT: 213px" id="divGridGrp" border="0"><asp:GridView id="grdCategory" runat="server" Width="249px" ForeColor="#333333" EnableTheming="False" CellPadding="4" OnRowCreated="grdCategory_RowCreated" ShowHeader="False" GridLines="None" OnRowDataBound="grdCategory_RowDataBound" AutoGenerateColumns="False">
                        <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
                        <Columns>
                        <asp:TemplateField>
                        <ItemStyle Width="5%"></ItemStyle>
                        <ItemTemplate>
                        <asp:CheckBox id="chkCategory" runat="server"></asp:CheckBox> 
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="GroupID">
                        <ItemStyle Width="5%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="OrgID" HeaderText="OrgID"></asp:BoundField>
                        <asp:BoundField DataField="GroupName">
                        <ItemStyle Width="90%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="GroupType" HeaderText="GroupType"></asp:BoundField>
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
                        <asp:AsyncPostBackTrigger ControlID="chkAllCategories" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="txtSearchCategory" EventName="TextChanged"></asp:AsyncPostBackTrigger>
                        </Triggers>
                        </asp:UpdatePanel> </TD></TR></TBODY></TABLE>
                        </ContentTemplate>
                        <HeaderTemplate>
                        Comittes&nbsp; 
                        </HeaderTemplate>
                        </ajaxToolKit:TabPanel>
                        <ajaxToolKit:TabPanel runat="server" ID="TabPanel3" HeaderText="TabPanel3"><ContentTemplate>
                        <TABLE cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR style="BACKGROUND-COLOR: #eeeeed"><TD style="PADDING-LEFT: 5px; HEIGHT: 24px" align=left><asp:UpdatePanel id="updChkGroup" runat="server"><ContentTemplate>
                        <asp:CheckBox id="chkAllGroups" runat="server"></asp:CheckBox> <asp:Label id="lblSelectAllGroups" runat="server" Text="Select All"></asp:Label> 
                        </ContentTemplate>
                        </asp:UpdatePanel> </TD><TD style="PADDING-RIGHT: 5px; HEIGHT: 24px" align=right>&nbsp;<asp:TextBox id="txtSearchGroup" runat="server" CssClass="SearchTxt" Width="300px" AutoPostBack="True" OnTextChanged="txtSearchGroup_TextChanged"></asp:TextBox> </TD></TR><TR><TD align=left colSpan=2><asp:UpdatePanel id="updGroup" runat="server"><ContentTemplate>
                        <DIV style="OVERFLOW: auto; WIDTH: 100%; HEIGHT: 213px" id="Div2" border="0"><asp:GridView id="grdGroup" runat="server" Width="249px" ForeColor="#333333" EnableTheming="False" CellPadding="4" OnRowCreated="grdGroup_RowCreated" ShowHeader="False" GridLines="None" AutoGenerateColumns="False">
                        <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
                        <Columns>
                        <asp:TemplateField>
                        <ItemStyle Width="5%"></ItemStyle>
                        <ItemTemplate>
                        <asp:CheckBox id="chkGroup" runat="server"></asp:CheckBox> 
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="GroupID">
                        <ItemStyle Width="5%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="OrgID" HeaderText="OrgID"></asp:BoundField>
                        <asp:BoundField DataField="GroupName">
                        <ItemStyle Width="90%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="GroupType" HeaderText="GroupType"></asp:BoundField>
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
                        <asp:AsyncPostBackTrigger ControlID="chkAllGroups" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="txtSearchGroup" EventName="TextChanged"></asp:AsyncPostBackTrigger>
                        </Triggers>
                        </asp:UpdatePanel> </TD></TR></TBODY></TABLE>
                        </ContentTemplate>
                        <HeaderTemplate>
                        Groups&nbsp; 
                        </HeaderTemplate>
                        </ajaxToolKit:TabPanel>
                        </ajaxToolKit:TabContainer> </TD></TR></TBODY></TABLE>
                        </contenttemplate>
                                <triggers>
                          
                               </triggers>
                            </asp:UpdatePanel>&nbsp;
                        </div>
                    </div>
                    
                    <!-- NB::  Code for  cc ------------------------------------------------------------  -->
                   
                    <iframe id="iframetop1" frameborder="0" height="0" scrolling="no"
                        style="background-color: navy; position:absolute;" width="0">
                    </iframe>
                    <iframe id="iframetop2" frameborder="0" height="0" scrolling="no" style="background-color: navy;
                        position: absolute;" width="0"></iframe>
                    <div id="draggerCc">
                        <div id="dvReceipientCc" class="loading-invisible">
                            <asp:UpdatePanel id="updReceipientCc" runat="server">
                                <contenttemplate>
            <TABLE style="BORDER-LEFT-COLOR: red; BORDER-BOTTOM-COLOR: red; BORDER-TOP-COLOR: red; BORDER-RIGHT-COLOR: red" cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR><TD>&nbsp;</TD><TD style="PADDING-RIGHT: 10px" align=right><asp:LinkButton id="btnCloseCc" onclick="btnCloseCc_Click" runat="server" Font-Size="Medium" Font-Names="Verdana" OnClientClick='avascript:HideDiv("dvReceipientCc");' Font-Underline="False">Close</asp:LinkButton> </TD></TR><TR><TD style="PADDING-LEFT: 0px" align=left colSpan=2><ajaxToolKit:TabContainer id="tabContainerCc" runat="server" CssClass="ajax_tab_theme" EnableTheming="False" ActiveTabIndex="0"><ajaxToolKit:TabPanel runat="server" ID="TabPanel41" HeaderText="TabPanel11"><ContentTemplate>
            <TABLE cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR style="BACKGROUND-COLOR: #eeeeed"><TD style="PADDING-LEFT: 27px; HEIGHT: 25px" align=left colSpan=2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </TD></TR><TR style="BACKGROUND-COLOR: #eeeeed"><TD style="PADDING-LEFT: 27px; HEIGHT: 24px" align=left colSpan=2><TABLE style="WIDTH: 451px"><TBODY><TR><TD style="WIDTH: 75px"><asp:Label id="Label22" runat="server" Text="पठाउनु पर्ने"></asp:Label> </TD><TD style="WIDTH: 131px" class="tblTDLeft"><asp:DropDownList id="ddlFilterCcReceiver" runat="server" OnSelectedIndexChanged="ddlFilterCcReceiver_SelectedIndexChanged" AutoPostBack="True"><asp:ListItem Value="-1">छान्नुहोस्</asp:ListItem>
            <asp:ListItem Value="1">संस्था</asp:ListItem>
            <asp:ListItem Value="2">शाखा</asp:ListItem>
            <asp:ListItem Value="3">व्यक्ति</asp:ListItem>
            </asp:DropDownList> </TD><TD>&nbsp;<asp:Label id="lblOrganisationCc" runat="server" Text="संस्था"></asp:Label> </TD><TD class="tblTDLeft"><asp:DropDownList id="ddlOrgCc" runat="server" Width="201px" OnSelectedIndexChanged="ddlOrgCc_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> </TD></TR><TR><TD style="WIDTH: 75px; HEIGHT: 32px"></TD><TD style="WIDTH: 131px; HEIGHT: 32px" class="tblTDLeft"></TD><TD style="HEIGHT: 32px">&nbsp;<asp:Label id="lblUnitCc" runat="server" Text="शाखा"></asp:Label> </TD><TD style="HEIGHT: 32px" class="tblTDLeft"><asp:DropDownList id="ddlUnitCc" runat="server" Width="122px" OnSelectedIndexChanged="ddlUnitCc_SelectedIndexChanged" AutoPostBack="True" Enabled="False"></asp:DropDownList> <asp:ImageButton id="imgPplBookingCc" runat="server" ImageUrl="~/MODULES/OAS/Images/Book [1600x1200].jpg" __designer:wfdid="w1" ToolTip="नयाँ स्थल बुकिङ्ग" OnClick="imgPplBookingCc_Click"></asp:ImageButton></TD></TR></TBODY></TABLE></TD></TR><TR style="BACKGROUND-COLOR: #eeeeed"><TD style="PADDING-LEFT: 5px; HEIGHT: 24px" align=left colSpan=1><asp:UpdatePanel id="UpdatePanel112" runat="server"><ContentTemplate>
            <asp:CheckBox id="chkAllCcPeople" runat="server"></asp:CheckBox> <asp:Label id="lblSelectAllPplCc" runat="server" Text="Select All"></asp:Label> 
            </ContentTemplate>
            <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlOrgCc" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
            <asp:AsyncPostBackTrigger ControlID="ddlUnitCc" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
            </Triggers>
            </asp:UpdatePanel> </TD><TD style="PADDING-RIGHT: 5px; HEIGHT: 24px" align=right><asp:TextBox id="txtSearchPeopleCc" runat="server" CssClass="SearchTxt" Width="300px" AutoPostBack="True" OnTextChanged="txtSearchPeopleCc_TextChanged"></asp:TextBox> </TD></TR><TR><TD align=left colSpan=2><asp:UpdatePanel id="updPeopleCc" runat="server"><ContentTemplate>
            <DIV style="OVERFLOW: auto; WIDTH: 100%; HEIGHT: 217px" id="Div7" border="0"><asp:GridView id="grdPeopleCc" runat="server" Width="249px" ForeColor="#333333" EnableTheming="False" CellPadding="4" GridLines="None" ShowHeader="False" OnRowCreated="grdPeopleCc_RowCreated">
            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
            <Columns>
            <asp:TemplateField>
            <ItemStyle Width="5%"></ItemStyle>
            <ItemTemplate>
            <asp:CheckBox id="chkPeople" runat="server"></asp:CheckBox> 
            </ItemTemplate>
            </asp:TemplateField>
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
            <asp:AsyncPostBackTrigger ControlID="ddlOrgCc" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
            <asp:AsyncPostBackTrigger ControlID="ddlUnitCc" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
            <asp:AsyncPostBackTrigger ControlID="txtSearchPeopleCc" EventName="TextChanged"></asp:AsyncPostBackTrigger>
            </Triggers>
            </asp:UpdatePanel> </TD></TR></TBODY></TABLE>
            </ContentTemplate>
            <HeaderTemplate>
                                                  People
                                        
            </HeaderTemplate>
            </ajaxToolKit:TabPanel>
            <ajaxToolKit:TabPanel runat="server" ID="TabPanel42" HeaderText="TabPanel12"><ContentTemplate>
            <TABLE cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR style="BACKGROUND-COLOR: #eeeeed"><TD style="PADDING-LEFT: 5px; HEIGHT: 24px" align=left><asp:UpdatePanel id="UpdatePanelCc" runat="server"><ContentTemplate>
            <asp:CheckBox id="chkAllCcCategories" runat="server"></asp:CheckBox> <asp:Label id="lblSelectAllCategoriesCc" runat="server" Text="Select All"></asp:Label> 
            </ContentTemplate>
            </asp:UpdatePanel> </TD><TD style="PADDING-RIGHT: 5px; HEIGHT: 24px" align=right><asp:TextBox id="txtSearchCategoryCc" runat="server" CssClass="SearchTxt" Width="300px" AutoPostBack="True" OnTextChanged="txtSearchCategoryCc_TextChanged"></asp:TextBox> </TD></TR><TR><TD align=left colSpan=2><asp:UpdatePanel id="updCategory1" runat="server"><ContentTemplate>
            <DIV style="OVERFLOW: auto; WIDTH: 100%; HEIGHT: 213px" id="div3" border="0"><asp:GridView id="grdCategoryCc" runat="server" Width="249px" ForeColor="#333333" EnableTheming="False" CellPadding="4" OnRowCreated="grdCategory_RowCreated" ShowHeader="False" GridLines="None" OnRowDataBound="grdCategory_RowDataBound" AutoGenerateColumns="False">
            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
            <Columns>
            <asp:TemplateField>
            <ItemStyle Width="5%"></ItemStyle>
            <ItemTemplate>
            <asp:CheckBox id="chkCategory" runat="server"></asp:CheckBox> 
            </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="GroupID">
            <ItemStyle Width="5%"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="OrgID" HeaderText="OrgID"></asp:BoundField>
            <asp:BoundField DataField="GroupName">
            <ItemStyle Width="90%"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="GroupType" HeaderText="GroupType"></asp:BoundField>
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
            <asp:AsyncPostBackTrigger ControlID="txtSearchCategoryCc" EventName="TextChanged"></asp:AsyncPostBackTrigger>
            </Triggers>
            </asp:UpdatePanel> </TD></TR></TBODY></TABLE>
            </ContentTemplate>
            <HeaderTemplate>
            Comittes&nbsp; 
            </HeaderTemplate>
            </ajaxToolKit:TabPanel>
            <ajaxToolKit:TabPanel runat="server" ID="TabPanel31" HeaderText="TabPanel31"><ContentTemplate>
            <TABLE cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR style="BACKGROUND-COLOR: #eeeeed"><TD style="PADDING-LEFT: 5px; HEIGHT: 24px" align=left><asp:UpdatePanel id="updChkGroupCc" runat="server"><ContentTemplate>
            <asp:CheckBox id="chkAllCcGroups" runat="server"></asp:CheckBox> <asp:Label id="lblSelectAllGroupsCc" runat="server" Text="Select All"></asp:Label> 
            </ContentTemplate>
            </asp:UpdatePanel> </TD><TD style="PADDING-RIGHT: 5px; HEIGHT: 24px" align=right>&nbsp;<asp:TextBox id="txtSearchGroupCc" runat="server" CssClass="SearchTxt" Width="300px" AutoPostBack="True" OnTextChanged="txtSearchGroupCc_TextChanged"></asp:TextBox> </TD></TR><TR><TD align=left colSpan=2><asp:UpdatePanel id="updGroup1" runat="server"><ContentTemplate>
            <DIV style="OVERFLOW: auto; WIDTH: 100%; HEIGHT: 213px" id="Div5" border="0"><asp:GridView id="grdGroupCc" runat="server" Width="249px" ForeColor="#333333" EnableTheming="False" CellPadding="4" OnRowCreated="grdGroup_RowCreated" ShowHeader="False" GridLines="None" AutoGenerateColumns="False">
            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
            <Columns>
            <asp:TemplateField>
            <ItemStyle Width="5%"></ItemStyle>
            <ItemTemplate>
            <asp:CheckBox id="chkGroup" runat="server"></asp:CheckBox> 
            </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="GroupID">
            <ItemStyle Width="5%"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="OrgID" HeaderText="OrgID"></asp:BoundField>
            <asp:BoundField DataField="GroupName">
            <ItemStyle Width="90%"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="GroupType" HeaderText="GroupType"></asp:BoundField>
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
            <asp:AsyncPostBackTrigger ControlID="txtSearchGroupCc" EventName="TextChanged"></asp:AsyncPostBackTrigger>
            </Triggers>
            </asp:UpdatePanel> </TD></TR></TBODY></TABLE>
            </ContentTemplate>
            <HeaderTemplate>
            Groups&nbsp; 
            </HeaderTemplate>
            </ajaxToolKit:TabPanel>
            </ajaxToolKit:TabContainer> </TD></TR></TBODY></TABLE>
            </contenttemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        
        <!-- for people -->
      
        <asp:Button ID="hiddenTargetControlForCommentPopup" runat="server" Style="display: none" />
        <ajaxToolKit:ModalPopupExtender ID="programmaticModalComment" runat="server" BackgroundCssClass=""
            BehaviorID="programmaticCommentModalPopupBehavior" DropShadow="false" PopupControlID="programmaticComment"
            PopupDragHandleControlID="programmaticCommentPopupDragHandle" RepositionMode="None"
            TargetControlID="hiddenTargetControlForCommentPopup">
        </ajaxToolKit:ModalPopupExtender>
        <asp:Panel ID="programmaticComment" runat="server" BackColor="whitesmoke" Height="350px"
            CssClass="modalPopup" Style="display: none; padding: 10px" Width="415px">
            <p style="width: 415px;">
                <asp:ImageButton ID="imgComment" runat="server" align="right" ImageUrl="~/MODULES/OAS/Images/btn_cancel.gif"
                    OnClick="imgComment_Click" Style="padding-right: 13px" /></p>
            <asp:Panel ID="programmaticCommentPopupDragHandle" runat="Server" Style="cursor: move;"
                Width="415px" Height="335px">
                <fieldset style="width: 391px; height: 300px;">
                    <legend>&nbsp;<asp:Label ID="Label51" runat="server" EnableTheming="False" ForeColor="Red"
                        SkinID="Unicodelbl">To : (संस्था/शाखा/व्यक्ति  )</asp:Label>
                    </legend>
                    <br />
                    


<TABLE cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR style="BACKGROUND-COLOR: #eeeeed"><TD style="PADDING-LEFT: 2px; HEIGHT: 24px" align=left><asp:UpdatePanel id="UpdatePanelCc1" runat="server"><ContentTemplate>
<asp:CheckBox id="chkAllPpl" runat="server" Checked="True"></asp:CheckBox>&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label id="lblSelectAllCategoriesCc1" runat="server" Text="Select All" SkinID="Unicodelbl"></asp:Label> 
</ContentTemplate>
</asp:UpdatePanel> </TD><TD style="PADDING-RIGHT: 5px; HEIGHT: 24px" align=right><asp:TextBox id="txtSearchCategoryCc1" runat="server" CssClass="SearchTxt" Width="300px" AutoPostBack="True" OnTextChanged="txtSearchCategoryCc_TextChanged" Visible="False"></asp:TextBox> </TD></TR><TR><TD align=left colSpan=2>


<asp:UpdatePanel id="updComment" runat="server"><ContentTemplate>
<DIV style="OVERFLOW: auto; WIDTH: 100%;max-height:217px" id="dvPpl"><asp:GridView id="grdTmp" runat="server" Width="390px" ForeColor="#333333" EnableTheming="True" __designer:wfdid="w85" CellPadding="4" OnRowCreated="grdTmp_RowCreated" ShowHeader="False" GridLines="None" AutoGenerateColumns="False">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:TemplateField>
<ItemStyle Width="10%"></ItemStyle>
<ItemTemplate>
<asp:CheckBox id="chkTmp" runat="server" Checked="True"></asp:CheckBox>
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="OtherOrgID" HeaderText="OtherOrgID"></asp:BoundField>
<asp:BoundField DataField="OtherUnitID" HeaderText="OtherUnitID"></asp:BoundField>
<asp:BoundField DataField="OtherReceiverID" HeaderText="OtherReceiverID"></asp:BoundField>
<asp:BoundField DataField="DetailName" HeaderText="DetailName"></asp:BoundField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> </DIV>
</ContentTemplate>
</asp:UpdatePanel> </TD></TR></TBODY></TABLE>





                </fieldset>
                &nbsp;
            </asp:Panel>
            &nbsp;
            <br />
        </asp:Panel>
        
        
                
        <!-- for people/Organisation/Unit Cc -->
      
        <asp:Button ID="hiddenTargetControlForPplCcPopup" runat="server" Style="display: none" />
        <ajaxToolKit:ModalPopupExtender ID="programmaticModalPplCc" runat="server" BackgroundCssClass=""
            BehaviorID="programmaticModalPplCcPopupBehavior" DropShadow="false" PopupControlID="programmaticPplCc"
            PopupDragHandleControlID="programmaticPplCcPopupDragHandle" RepositionMode="None"
            TargetControlID="hiddenTargetControlForPplCcPopup">
        </ajaxToolKit:ModalPopupExtender>
        <asp:Panel ID="programmaticPplCc" runat="server" BackColor="whitesmoke" Height="350px"
            CssClass="modalPopup" Style="display: none; padding: 10px" Width="415px">
            <p style="width: 415px;">
                <asp:ImageButton ID="imgPplCcClose" runat="server" align="right" ImageUrl="~/MODULES/OAS/Images/btn_cancel.gif"
                    OnClick="imgPplCcClose_Click" Style="padding-right: 13px" /></p>
            <asp:Panel ID="programmaticPplCcPopupDragHandle" runat="Server" Style="cursor: move;"
                Width="415px" Height="335px">
                <fieldset style="width: 391px; height: 300px;">
                    <legend>&nbsp;<asp:Label ID="Label10" runat="server" EnableTheming="False" ForeColor="Red"
                        SkinID="Unicodelbl">Cc : (संस्था/शाखा/व्यक्ति  )</asp:Label>
                    </legend>
                    <br />
                    


<TABLE cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR style="BACKGROUND-COLOR: #eeeeed"><TD style="PADDING-LEFT: 2px; HEIGHT: 24px" align=left><asp:UpdatePanel id="updPplCcChk" runat="server"><ContentTemplate>
<asp:CheckBox id="chkAllCcPpl" runat="server" Checked="True"></asp:CheckBox>&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label id="lblSelectAllCategoriesPplCc" runat="server" Text="Select All" SkinID="Unicodelbl"></asp:Label> 
</ContentTemplate>
</asp:UpdatePanel> </TD><TD style="PADDING-RIGHT: 5px; HEIGHT: 24px" align=right><asp:TextBox id="TextBox1" runat="server" CssClass="SearchTxt" Width="300px" AutoPostBack="True" OnTextChanged="txtSearchCategoryCc_TextChanged" Visible="False"></asp:TextBox> </TD></TR><TR><TD align=left colSpan=2>


<asp:UpdatePanel id="updPplCc" runat="server"><ContentTemplate>
<DIV style="OVERFLOW: auto; WIDTH: 100%; max-height: 217px" id="DIV1"><asp:GridView id="grdCcTmp" runat="server" Width="390px" ForeColor="#333333" EnableTheming="True" CellPadding="4" OnRowCreated="grdTmp_RowCreated" ShowHeader="False" GridLines="None" AutoGenerateColumns="False">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:TemplateField>
<ItemStyle Width="10%"></ItemStyle>
<ItemTemplate>
<asp:CheckBox id="chkTmp" runat="server" __designer:wfdid="w2" Checked="True"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="OtherOrgID" HeaderText="OtherOrgID"></asp:BoundField>
<asp:BoundField DataField="OtherUnitID" HeaderText="OtherUnitID"></asp:BoundField>
<asp:BoundField DataField="OtherReceiverID" HeaderText="OtherReceiverID"></asp:BoundField>
<asp:BoundField DataField="DetailName" HeaderText="DetailName"></asp:BoundField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> </DIV>
</ContentTemplate>
</asp:UpdatePanel> </TD></TR></TBODY></TABLE>



                </fieldset>
                &nbsp;
            </asp:Panel>
            &nbsp;
            <br />
        </asp:Panel>
       
        
    </div>
</asp:Content>
