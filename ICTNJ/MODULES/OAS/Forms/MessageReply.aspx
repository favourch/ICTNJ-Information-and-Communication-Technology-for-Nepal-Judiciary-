<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true" CodeFile="MessageReply.aspx.cs" Inherits="MODULES_OAS_Forms_MessageReply" Title="OAS|Message Reply" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
<div style=" width:100%;">

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
    
     <table width ="100%" cellpadding ="0"  cellspacing ="0" border ="0" style ="border-color:Red">
       <tr>
            <td align = "center">
                <table width ="80%" cellpadding ="0"  cellspacing ="0" border ="0" style ="border-color:Red">
                   <tr>
                        <td style ="height: 50px;" align="left">
                            <asp:Label ID="lblHeader" runat="server" SkinID="UnicodeHeadlbl" Text="Message Reply"></asp:Label></td>
                   </tr>
                    <tr>
                        <td align="left" valign ="middle" style="padding-left:60px;height: 50px;">
                            <asp:Button ID="btnInbox" runat="server" OnClick="btnInbox_Click" SkinID="Normal" Text="InBox" Width="58px" />&nbsp;
                             <asp:Button ID="btnOutBox" runat="server" SkinID="Normal" Text="OutBox" Width="64px" OnClick="btnOutBox_Click"  />&nbsp;
                            
                             <asp:Button ID="btnNew" runat="server" SkinID="Normal" Text="New" Width="64px" OnClick="btnNew_Click"  />&nbsp;
                            <asp:Button ID="btnSend" runat="server" SkinID="Normal" Text="Send" Width="64px" OnClick="btnSend_Click" />&nbsp;
                            <asp:Button ID="btnCancel" runat="server" SkinID="Normal" Text="Cancel" Width="53px" OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td align = "center">
                             <asp:UpdatePanel id="updEditor" runat="server">
                                    <contenttemplate>
<FIELDSET><TABLE style="BORDER-LEFT-COLOR: blue; BORDER-BOTTOM-COLOR: blue; BORDER-TOP-COLOR: blue; BORDER-RIGHT-COLOR: blue" cellSpacing=0 cellPadding=0 width="80%" border=0><TBODY><TR><TD style="WIDTH: 10%" class="tblTDRight"><asp:Label id="lblFrom" runat="server" Text="From :" __designer:wfdid="w13"></asp:Label> </TD><TD style="WIDTH: 169px; HEIGHT: 32px" class="tblTDLeft"><asp:Label id="lblFromData" runat="server" Text="" __designer:wfdid="w14"></asp:Label> </TD></TR><TR><TD style="WIDTH: 10%" class="tblTDRight"><asp:Label id="lblSent" runat="server" Text="To :" __designer:wfdid="w15"></asp:Label> </TD><TD style="WIDTH: 169px; HEIGHT: 32px" class="tblTDLeft"><asp:Label id="lblSentData" runat="server" Text="" __designer:wfdid="w16"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label id="lblGroup" runat="server" Text="Group :" __designer:wfdid="w2" Visible="False"></asp:Label>&nbsp;&nbsp; <asp:CheckBox id="chkGroup" runat="server" __designer:wfdid="w1" Visible="False" Checked="True"></asp:CheckBox></TD></TR><TR><TD style="WIDTH: 10%" class="tblTDRight"><asp:Label id="lblSubject" runat="server" Text="Subject :" __designer:wfdid="w17"></asp:Label> </TD><TD style="WIDTH: 169px" class="tblTDLeft"><asp:TextBox id="txtSubject_rqd" runat="server" Width="594px" __designer:wfdid="w18"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 70px" class="tblTDRight"><asp:Label id="lblAttach" runat="server" Text="Attach " __designer:wfdid="w19"></asp:Label> <asp:Image id="Image1" runat="server" ImageUrl="~/MODULES/OAS/Images/i_attach.gif" __designer:wfdid="w20"></asp:Image></TD><TD class="tblTDLeft"><asp:FileUpload id="fupdAttach" runat="server" Width="272px" Font-Size="Small" Font-Names="Verdana" __designer:wfdid="w21"></asp:FileUpload>&nbsp;&nbsp;<asp:Button id="btnUpload" onclick="btnUpload_Click" runat="server" Width="37px" Text="Add" SkinID="Normal" __designer:wfdid="w22"></asp:Button></TD></TR><TR id="trForAttach"><TD style="WIDTH: 70px" class="tblTDRight">&nbsp;</TD><TD style="WIDTH: 169px; HEIGHT: 37px" class="tblTDLeft" vAlign=bottom><DIV style="VERTICAL-ALIGN: top; OVERFLOW: auto; WIDTH: 600px; HEIGHT: 55px" id="dvAttachment" border="0"><asp:DataList id="dlUpdAttachment" runat="server" Width="581px" Height="26px" Font-Size="2px" ForeColor="Black" __designer:wfdid="w23" BorderColor="Tan" RepeatColumns="4" CellPadding="2" BackColor="LightGoldenrodYellow" OnSelectedIndexChanged="dlUpdAttachment_SelectedIndexChanged" BorderWidth="1px">
<FooterStyle BackColor="Tan"></FooterStyle>

<SelectedItemStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite"></SelectedItemStyle>
<ItemTemplate>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <DIV style="BORDER-RIGHT: #d2b48c 1px solid; BORDER-TOP: #d2b48c 1px solid; BORDER-LEFT: #d2b48c 1px solid; BORDER-BOTTOM: #d2b48c 1px solid"><TABLE cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR><TD style="WIDTH: 80%; HEIGHT: 16px"><asp:Label id="lblAttachment" runat="server" Text='<%# Eval("DisplayName") %>' Font-Size="X-Small" Font-Names="Verdana" EnableTheming="True" __designer:wfdid="w1" BackColor="White" CausesValidation="False" ToolTip='<%# Eval("FileName") %>'></asp:Label> </TD><TD style="PADDING-RIGHT: 2px; HEIGHT: 16px" align=right>&nbsp;&nbsp;<asp:ImageButton id="imgBtnRemove" runat="server" ImageUrl="~/MODULES/OAS/Images/bycat1.ico" __designer:wfdid="w2" BackColor="White" CommandName="Select"></asp:ImageButton> </TD></TR><TR><TD colSpan=2><asp:Label id="Label1" runat="server" Text='<%# Eval("DateCreated") %>' __designer:wfdid="w3" BackColor="#CCCCCC" Visible="False"></asp:Label></TD></TR></TBODY></TABLE></DIV>
</ItemTemplate>

<AlternatingItemStyle BackColor="LightGoldenrodYellow" BorderColor="Tan"></AlternatingItemStyle>

<HeaderStyle BackColor="Tan" Font-Bold="True"></HeaderStyle>
</asp:DataList> </DIV></TD></TR><TR><TD style="WIDTH: 70px" class="tblTDRight"></TD><TD style="PADDING-LEFT: 20px; WIDTH: 169px; HEIGHT: 37px" class="tblTDLeft" vAlign=bottom><FTB:FreeTextBox id="HtmlEditor" runat="server" Width="600px" Height="250px" __designer:wfdid="w24" BackColor="127, 157, 185" BreakMode="LineBreak" GutterBackColor="127, 157, 185" StartMode="DesignMode" ToolbarBackColor="127, 157, 185" ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline,Strikethrough;Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;InsertRule|Cut,Copy,Paste;Undo,Redo,Print">
                                        </FTB:FreeTextBox></TD></TR></TBODY></TABLE></FIELDSET> 
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
            <td>&nbsp;</td>
       </tr>
      
     </table>    
</asp:Content>

