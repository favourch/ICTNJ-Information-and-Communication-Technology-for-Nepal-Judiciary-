<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" EnableEventValidation="false"
    AutoEventWireup="true" CodeFile="MessageLetterReply.aspx.cs" Inherits="MODULES_OAS_Forms_MessageReply"
    Title="OAS|Letter Reply" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>
    <%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <script language="javascript" type="text/javascript" src="../../COMMON/JS/Validation.js"></script>

    <script language="javascript" type="text/javascript" src="../../COMMON/JS/DateValidator.js"></script>

    <script language="javascript" type="text/javascript">
    
      
       function SetDivHeight(elem,val)
        {  
             objDiv = document.getElementById(elem);
             objDiv.style.height = val;
            
            
        }
    </script>

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
        <!-- end error status -->
        <table width="100%" cellpadding="0" cellspacing="0" border="0" style="border-color: Red">
            <tr>
                <td align="center">
                    <table width="80%" cellpadding="0" cellspacing="0" border="0" style="border-color: Red">
                        <tr>
                            <td style="height: 50px;" align="left">
                                <asp:Label ID="lblHeader" runat="server" SkinID="UnicodeHeadlbl" Text="Letter Reply"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" valign="middle" style="padding-left: 60px; height: 50px;">
                                <asp:Button ID="btnInbox" runat="server" OnClick="btnInbox_Click" SkinID="Normal"
                                    Text="InBox" Width="58px" />&nbsp;
                                <asp:Button ID="btnOutBox" runat="server" SkinID="Normal" Text="OutBox" Width="64px"
                                    OnClick="btnOutBox_Click" />&nbsp;
                                <asp:Button ID="btnNew" runat="server" SkinID="Normal" Text="New" Width="64px" OnClick="btnNew_Click" />&nbsp;
                                <asp:Button ID="btnSend" runat="server" SkinID="Normal" Text="Send" Width="64px"
                                    OnClick="btnSend_Click" />&nbsp;
                                <asp:Button ID="btnCancel" runat="server" SkinID="Normal" Text="Cancel" Width="53px"
                                    OnClick="btnCancel_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:UpdatePanel id="updEditor" runat="server">
                                    <contenttemplate>
<FIELDSET><TABLE style="BORDER-LEFT-COLOR: blue; BORDER-BOTTOM-COLOR: blue; BORDER-TOP-COLOR: blue; BORDER-RIGHT-COLOR: blue" cellSpacing=0 cellPadding=0 width="80%" border=0><TBODY><TR><TD style="WIDTH: 10%" class="tblTDRight"><asp:Label id="lblFrom" runat="server" Text="From :" __designer:wfdid="w10"></asp:Label> </TD><TD style="WIDTH: 169px; HEIGHT: 32px" class="tblTDLeft"><asp:Label id="lblFromData" runat="server" Text="" __designer:wfdid="w11"></asp:Label> </TD></TR><TR><TD style="WIDTH: 10%" class="tblTDRight"><asp:Label id="lblSent" runat="server" Text="To :" __designer:wfdid="w12"></asp:Label> </TD><TD style="WIDTH: 169px; HEIGHT: 32px" class="tblTDLeft"><asp:Label id="lblSentData" runat="server" Text="" __designer:wfdid="w13"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label id="lblGroup" runat="server" Text="Group :" __designer:wfdid="w14" Visible="False"></asp:Label>&nbsp;&nbsp; <asp:CheckBox id="chkGroup" runat="server" __designer:wfdid="w15" Visible="False" Checked="True"></asp:CheckBox></TD></TR><TR><TD style="WIDTH: 10%" class="tblTDRight"><asp:Label id="lblSubject" runat="server" Text="Subject :" __designer:wfdid="w16"></asp:Label> </TD><TD style="WIDTH: 169px" class="tblTDLeft"><asp:TextBox id="txtSubject_rqd" runat="server" Width="594px" __designer:wfdid="w17"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 70px" class="tblTDRight"><asp:Label id="Label9" runat="server" Width="56px" Text=" Type :" __designer:wfdid="w18"></asp:Label></TD><TD class="tblTDLeft"><asp:DropDownList id="ddlLetterType" runat="server" Width="170px" __designer:wfdid="w19"><asp:ListItem Value="-1">छान्नुहोस्</asp:ListItem>
<asp:ListItem Value="T">टिप्पणी</asp:ListItem>
<asp:ListItem Value="O">अरु</asp:ListItem>
</asp:DropDownList></TD></TR><TR><TD style="WIDTH: 70px" class="tblTDRight"><asp:Label id="Label4" runat="server" Text="To :" __designer:wfdid="w29"></asp:Label></TD><TD class="tblTDLeft"><TABLE style="WIDTH: 505px; HEIGHT: 69px"><TBODY><TR><TD style="WIDTH: 75px"><asp:Label id="Label21" runat="server" Width="69px" Text="पठाउनु पर्ने" __designer:wfdid="w30"></asp:Label> </TD><TD style="WIDTH: 150px" class="tblTDLeft"><asp:DropDownList id="ddlFilterTo" runat="server" __designer:wfdid="w31" OnSelectedIndexChanged="ddlFilterTo_SelectedIndexChanged" AutoPostBack="True"><asp:ListItem Value="-1">छान्नुहोस्</asp:ListItem>
<asp:ListItem Value="1">संस्था</asp:ListItem>
<asp:ListItem Value="2">शाखा</asp:ListItem>
<asp:ListItem Value="3">व्यक्ति</asp:ListItem>
</asp:DropDownList> </TD><TD style="WIDTH: 37px" vAlign=top><asp:Label id="lblOrganisation1" runat="server" Text="संस्था" __designer:wfdid="w32"></asp:Label> </TD><TD style="WIDTH: 222px" class="tblTDLeft"><asp:DropDownList id="ddlOrgTo" runat="server" Width="200px" __designer:wfdid="w33" OnSelectedIndexChanged="ddlOrgTo_SelectedIndexChanged" AutoPostBack="True" Enabled="False"></asp:DropDownList> </TD></TR><TR><TD style="WIDTH: 75px"><asp:Label id="lblUnit1" runat="server" Text="शाखा" __designer:wfdid="w34"></asp:Label></TD><TD style="WIDTH: 150px" class="tblTDLeft"><asp:DropDownList id="ddlUnitTo" runat="server" Width="122px" __designer:wfdid="w35" OnSelectedIndexChanged="ddlUnitTo_SelectedIndexChanged" AutoPostBack="True" Enabled="False"></asp:DropDownList></TD><TD style="WIDTH: 37px" vAlign=top>&nbsp;<asp:Label id="Label3" runat="server" Text="व्यक्ति" __designer:wfdid="w36"></asp:Label></TD><TD style="WIDTH: 222px" class="tblTDLeft"><asp:DropDownList id="ddlPersonTo" runat="server" Width="199px" __designer:wfdid="w37" OnSelectedIndexChanged="ddlPersonTo_SelectedIndexChanged" AutoPostBack="True" Enabled="False"></asp:DropDownList></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="WIDTH: 70px" class="tblTDRight"><asp:Label id="lblAttach" runat="server" Text="Attach " __designer:wfdid="w20"></asp:Label> <asp:Image id="Image1" runat="server" ImageUrl="~/MODULES/OAS/Images/i_attach.gif" __designer:wfdid="w21"></asp:Image></TD><TD class="tblTDLeft"><asp:FileUpload id="fupdAttach" runat="server" Width="272px" Font-Size="Small" Font-Names="Verdana" __designer:wfdid="w22"></asp:FileUpload>&nbsp;&nbsp;<asp:Button id="btnUpload" onclick="btnUpload_Click" runat="server" Width="37px" Text="Add" SkinID="Normal" __designer:wfdid="w23"></asp:Button></TD></TR><TR id="trForAttach"><TD style="WIDTH: 70px" class="tblTDRight">&nbsp;</TD><TD style="WIDTH: 169px; HEIGHT: 37px" class="tblTDLeft" vAlign=bottom><DIV style="VERTICAL-ALIGN: top; OVERFLOW: auto; WIDTH: 600px; HEIGHT: 55px" id="dvAttachment" border="0"><asp:DataList id="dlUpdAttachment" runat="server" Width="581px" Height="26px" Font-Size="2px" ForeColor="Black" __designer:wfdid="w24" OnSelectedIndexChanged="dlUpdAttachment_SelectedIndexChanged" BorderColor="Tan" RepeatColumns="4" CellPadding="2" BackColor="LightGoldenrodYellow" BorderWidth="1px">
<FooterStyle BackColor="Tan"></FooterStyle>

<SelectedItemStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite"></SelectedItemStyle>
<ItemTemplate>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <DIV style="BORDER-RIGHT: #d2b48c 1px solid; BORDER-TOP: #d2b48c 1px solid; BORDER-LEFT: #d2b48c 1px solid; BORDER-BOTTOM: #d2b48c 1px solid"><TABLE cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR><TD style="WIDTH: 80%; HEIGHT: 16px"><asp:Label id="lblAttachment" runat="server" Text='<%# Eval("DisplayName") %>' Font-Size="X-Small" Font-Names="Verdana" EnableTheming="True" __designer:wfdid="w1" BackColor="White" CausesValidation="False" ToolTip='<%# Eval("FileName") %>'></asp:Label> </TD><TD style="PADDING-RIGHT: 2px; HEIGHT: 16px" align=right>&nbsp;&nbsp;<asp:ImageButton id="imgBtnRemove" runat="server" ImageUrl="~/MODULES/OAS/Images/bycat1.ico" __designer:wfdid="w2" BackColor="White" CommandName="Select"></asp:ImageButton> </TD></TR><TR><TD colSpan=2><asp:Label id="Label1" runat="server" Text='<%# Eval("DateCreated") %>' __designer:wfdid="w3" BackColor="#CCCCCC" Visible="False"></asp:Label></TD></TR></TBODY></TABLE></DIV>
</ItemTemplate>

<AlternatingItemStyle BackColor="LightGoldenrodYellow" BorderColor="Tan"></AlternatingItemStyle>

<HeaderStyle BackColor="Tan" Font-Bold="True"></HeaderStyle>
</asp:DataList> </DIV></TD></TR><TR><TD style="WIDTH: 70px" class="tblTDRight"></TD><TD style="MARGIN-LEFT: 20px; WIDTH: 169px; HEIGHT: 37px" class="tblTDLeft" vAlign=bottom><FTB:FreeTextBox id="HtmlEditor" runat="server" Width="600px" Height="370px" __designer:wfdid="w25" BackColor="127, 157, 185" BreakMode="LineBreak" GutterBackColor="127, 157, 185" StartMode="DesignMode" ToolbarBackColor="127, 157, 185" ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline,Strikethrough;Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;InsertRule|Cut,Copy,Paste;Undo,Redo,Print">
                                        </FTB:FreeTextBox></TD></TR><TR><TD style="WIDTH: 70px; PADDING-TOP: 10px" class="tblTDRight"><asp:Label id="Label81" runat="server" Text="From :" __designer:wfdid="w38"></asp:Label></TD><TD style="WIDTH: 169px; PADDING-TOP: 10px; HEIGHT: 32px" class="tblTDLeft"><TABLE style="WIDTH: 505px; HEIGHT: 69px"><TBODY><TR><TD style="WIDTH: 75px"><asp:Label id="Label5" runat="server" Width="69px" Text="पठाउने" __designer:wfdid="w39"></asp:Label> </TD><TD style="WIDTH: 150px" class="tblTDLeft"><asp:DropDownList id="ddlFilterFrom" runat="server" __designer:wfdid="w40" OnSelectedIndexChanged="ddlFilterFrom_SelectedIndexChanged" AutoPostBack="True" Enabled="False"><asp:ListItem Value="-1">छान्नुहोस्</asp:ListItem>
<asp:ListItem Value="1">संस्था</asp:ListItem>
<asp:ListItem Value="2">शाखा</asp:ListItem>
<asp:ListItem Value="3">व्यक्ति</asp:ListItem>
</asp:DropDownList> </TD><TD style="WIDTH: 37px" vAlign=top><asp:Label id="Label6" runat="server" Text="संस्था" __designer:wfdid="w41"></asp:Label> </TD><TD style="WIDTH: 222px" class="tblTDLeft"><asp:DropDownList id="ddlOrgFrom" runat="server" Width="200px" __designer:wfdid="w42" OnSelectedIndexChanged="ddlOrgFrom_SelectedIndexChanged" AutoPostBack="True" Enabled="False"></asp:DropDownList> </TD></TR><TR><TD style="WIDTH: 75px"><asp:Label id="Label7" runat="server" Text="शाखा" __designer:wfdid="w43"></asp:Label></TD><TD style="WIDTH: 150px" class="tblTDLeft"><asp:DropDownList id="ddlUnitFrom" runat="server" Width="122px" __designer:wfdid="w44" OnSelectedIndexChanged="ddlUnitFrom_SelectedIndexChanged" AutoPostBack="True" Enabled="False"></asp:DropDownList></TD><TD style="WIDTH: 37px" vAlign=top>&nbsp;<asp:Label id="Label8" runat="server" Text="व्यक्ति" __designer:wfdid="w45"></asp:Label></TD><TD style="WIDTH: 222px" class="tblTDLeft"><asp:DropDownList id="ddlPersonFrom" runat="server" Width="199px" __designer:wfdid="w46" OnSelectedIndexChanged="ddlPersonFrom_SelectedIndexChanged" AutoPostBack="True" Enabled="False"></asp:DropDownList></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="WIDTH: 70px" class="tblTDRight"><asp:Label id="lblApprove" runat="server" Text="Approve :" __designer:wfdid="w26"></asp:Label>&nbsp;</TD><TD style="WIDTH: 169px; HEIGHT: 32px" class="tblTDLeft">&nbsp;<asp:CheckBox id="chkApprove" runat="server" __designer:wfdid="w27"></asp:CheckBox><asp:Label id="lbltitle" runat="server" Width="336px" Text="( यस बमोजिम स्वीकार्थ पेश गरेको छु । )" SkinID="Unicodelbl" __designer:wfdid="w28"></asp:Label></TD></TR></TBODY></TABLE></FIELDSET> 
</contenttemplate>
                                    <triggers>
<asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnSend" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="OkButton" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:PostBackTrigger ControlID="btnUpload"></asp:PostBackTrigger>
</triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
</asp:Content>
