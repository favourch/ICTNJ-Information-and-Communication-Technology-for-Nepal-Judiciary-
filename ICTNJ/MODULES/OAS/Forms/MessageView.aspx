<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="MessageView.aspx.cs" Inherits="MODULES_OAS_Forms_MessageView" Title=":.Message View" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>
 <%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
 
  <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript" src="../../COMMON/JS/Validation.js"></script>
     <script language="javascript" type="text/javascript" src="../../COMMON/JS/DateValidator.js"></script>
     <script language="javascript" type="text/javascript">
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
      
      function setDivDimension()
      {  objDiv = document.getElementById("dvForOutBox");
         objDiv.style.height = "40px" ;
      }
      </script>
      
<div style=" width:100%;height:660px">
    
     <table width ="100%" cellpadding ="0"  cellspacing ="0" border ="0" style ="border-color:Red">
       <tr>
            <td align = "center">
                <table width ="80%" cellpadding ="0"  cellspacing ="0" border ="0" style ="border-color:Red">
                   <tr>
                        <td style ="height: 50px;" align="left">
                            <asp:Label ID="lblHeader" runat="server" SkinID="UnicodeHeadlbl" Text="Message View "></asp:Label></td>
                   </tr>
                    <tr>
                        <td align="left" valign ="middle" style="padding-left:60px;height: 50px;">
                            <asp:Button ID="btnInbox" runat="server" OnClick="btnInbox_Click" SkinID="Normal"
                                Text="InBox" Width="58px" />&nbsp;
                                <asp:Button ID="btnOutBox" runat="server" SkinID="Normal" Text="OutBox" Width="64px" OnClick="btnOutBox_Click"  />&nbsp;
                            <asp:Button ID="btnNew" runat="server" SkinID="Normal" Text="New" Width="64px" OnClick="btnNew_Click" />&nbsp;<asp:Button
                                ID="btnReply" runat="server" SkinID="Normal" Text="Reply" Width="53px" OnClick="btnReply_Click" />
                            <asp:Button ID="btnForward" runat="server" OnClick="btnForward_Click" SkinID="Normal"
                                Text="Forward" /></td>
                    </tr>
                    <tr>
                        <td align = "left">
                            <fieldset>
                            <table width ="80%" cellpadding ="0"  cellspacing ="0" border ="0" style ="border-color:blue">
                               <tr>
                                    <td style="width: 10%; height: 34px;" class="tblTDRight">
                                        <asp:Label ID="lblFrom" runat="server" Text="From :"></asp:Label>
                                    </td>
                                    <td  class="tblTDLeft" style="width: 169px; height: 34px">
                                        <asp:Label ID="lblFromData" runat="server" Text=""></asp:Label>
                                    </td>
                               </tr>
                                 <tr>
                                    <td style="width: 10%;" class="tblTDRight">
                                        <asp:Label ID="lblSent" runat="server" Text="Sent :"></asp:Label>
                                    </td>
                                    <td  class="tblTDLeft" style="width: 169px; height: 32px">
                                        <asp:Label ID="lblSentData" runat="server" Text=""></asp:Label>
                                    </td>
                               </tr>
                                <tr id = "trForOutBox">
                                    <td style="width: 10%; height: 36px;" class="tblTDRight" valign="baseline">
                                        <asp:Label ID="lblTo" runat="server" Text="To :"></asp:Label>
                                    </td>
                                    <td  class="tblTDLeft" style="width: 169px; height: 36px" valign ="bottom">
                                        <br />
                                        <DIV id = "dvForOutBox" style="OVERFLOW: auto; WIDTH: 600px;" border="0">
                                            &nbsp;<asp:Label ID="lblToData" runat="server" Width="500px"></asp:Label></DIV>
                                    </td>
                               </tr>
                              
                               <tr>
                                    <td style="width: 10%" class="tblTDRight">
                                        <asp:Label ID="lblSubject" runat="server" Text="Subject :" ></asp:Label>
                                    </td>
                                     <td  class="tblTDLeft" style="width: 169px; height: 32px">
                                        <asp:Label ID="lblSubjectData" runat="server" Text=""></asp:Label>
                                    </td>
                               </tr>
                                <tr id = "trForAttach">
                                    <td style="width: 10%; height: 36px;" class="tblTDRight" valign="baseline">
                                        <asp:Label ID="lblAttachment" runat="server" Text="Attachment"></asp:Label>&nbsp;<asp:Image ID="Image1"
                                            runat="server" ImageUrl="~/MODULES/OAS/Images/i_attach.gif" />
                                    </td>
                                    <td  class="tblTDLeft" style="width: 169px;" valign ="top">
                                          <DIV id = "dvAttachment" style="OVERFLOW: auto; WIDTH: 600px;height:44px;vertical-align:top;"  border="0">
                                           <asp:DataList id="dlUpdAttachment" runat="server" Width="200px" Font-Size="XX-Small" ForeColor="#333333" BackColor="Transparent" CellPadding="4" RepeatColumns="4" CellSpacing="2" EnableTheming="False" Font-Names="Verdana" Height="45px" ShowFooter="False" ShowHeader="False" SkinID="smalCalendarlLnk">
                                                    <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

                                                    <SelectedItemStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedItemStyle>
                                                    <ItemTemplate>
                                                    &nbsp;<asp:LinkButton id="LinkButton2" runat="server" Text='<%# Eval("FileName") %>' Font-Size="Small" Font-Names="Verdana" EnableTheming="True" BackColor="Transparent" ToolTip='<%# Eval("FileName") %>' CausesValidation="False" OnClick="LinkButton2_Click" CommandArgument='<%# Eval("OrgID")+ "/" + Eval("MessageID") + "/"  +Eval("AttachmentID") %>' SkinID="smalCalendarlLnk"></asp:LinkButton> 
                                                    </ItemTemplate>
                                                    <ItemStyle BackColor="White" ForeColor="#333333"></ItemStyle>

                                                    <HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
                                                    </asp:DataList>
                                         </DIV>
                                    </td>
                               </tr>
                                <tr>
                                    <td class="tblTDRight" style="width: 10%; height: 36px" valign="baseline">
                                    </td>
                                    <td class="tblTDLeft" style="padding-left: 20px; width: 169px" valign="top">
                                         <FTB:FreeTextBox ID="HtmlEditor" runat="server" BackColor="127, 157, 185" BreakMode="LineBreak" GutterBackColor="127, 157, 185"
                                             StartMode="DesignMode" ToolbarBackColor="127, 157, 185" ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline,Strikethrough;Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;InsertRule|Cut,Copy,Paste;Undo,Redo,Print"
                                            Width="600px" Height="250px">
                                        </FTB:FreeTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblTDRight">                 <asp:Label ID="lblApprove" runat="server" Text="Approve :"></asp:Label>
                                        </td>
                                    <td class="tblTDLeft">
                                        <asp:CheckBox ID="chkApprove" runat="server" />
                                     </td>
                                </tr>
                             </table>       
                             </fieldset>
                        </td>
                    </tr>
                 </table>
            </td>
       </tr>
      
     </table>
     
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
</asp:Content>

