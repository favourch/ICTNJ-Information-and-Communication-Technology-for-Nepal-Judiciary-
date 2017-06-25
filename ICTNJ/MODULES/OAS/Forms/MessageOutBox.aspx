<%@ Page Language="C#" EnableEventValidation = "false"   MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true" CodeFile="MessageOutBox.aspx.cs" Inherits="MODULES_OAS_Forms_MessageOutBox" Title="OAS|Message OutBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>
  
<asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <script language="javascript" type="text/javascript" src="../../COMMON/JS/Validation.js"></script>
     <script language="javascript" type="text/javascript" src="../../COMMON/JS/DateValidator.js"></script>
     <script language="javascript" type="text/javascript">
               
        function CheckUncheckAll(obj)
        {
            try
            {   
                 var grid = document.getElementById("<%= grdMessageOutBox.ClientID %>");
                                
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
    </script>
     <div style=" width:100%;height:650px">
           
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
<asp:Panel style="BORDER-RIGHT: gray 1px solid; BORDER-TOP: gray 1px solid; BORDER-LEFT: gray 1px solid; CURSOR: move; COLOR: black; BORDER-BOTTOM: gray 1px solid; BACKGROUND-COLOR: #dddddd; TEXT-ALIGN: center" id="programmaticPopupDragHandle" runat="Server"><asp:Label id="lblStatusMessageTitle" runat="server" CssClass="simplelabel"></asp:Label></asp:Panel> <asp:Label id="lblStatusMessage" runat="server" CssClass="simplelabel" ForeColor="Red" EnableTheming="False"></asp:Label> 
</contenttemplate>
        </asp:UpdatePanel>
        <asp:Button ID="OkButton" runat="server" 
            Text="OK" Width="58px" OnClick="OkButton_Click" />
        <br />
    </asp:Panel>
    
    <!-- end error status -->
    
     
      <table width ="100%" cellpadding ="0"  cellspacing ="0" border ="0" style ="border-color:Red">
       <tr>
            <td align = "center">
                <table width ="80%" cellpadding ="0"  cellspacing ="0" border ="0" style ="border-color:Red">
                   <tr>
                        <td style ="height: 50px;" align="left">
                            <asp:Label ID="lblHeader" runat="server" SkinID="UnicodeHeadlbl" Text="Outbox"></asp:Label></td>
                   </tr>
                    <tr>
                        <td align="left" valign ="middle" style="padding-left:60px;height: 50px;">
                           <asp:Button ID="btnInbox" runat="server"  SkinID="Normal" Text="InBox" Width="58px" OnClick="btnInbox_Click" />
                            <asp:Button ID="btnOutbox" runat="server"  SkinID="Normal" Text="OutBox" Width="58px" OnClick="btnOutbox_Click" />
                          
                            &nbsp;<asp:Button ID="btnNew" runat="server" SkinID="Normal" Text="New" Width="64px" OnClick="btnNew_Click"  />
                            &nbsp;<asp:Button ID="btnDelete" runat="server"  SkinID="Normal"   Text="Delete" Width="58px" OnClick="btnDelete_Click" Visible="False" />
                            &nbsp;<asp:Button ID="Cancel" runat="server" SkinID="Cancel" Text="Cancel" OnClick="Cancel_Click" />
                       </td>
                    </tr>
                    <tr>
                        <td align = "left">
                            <fieldset>
                         
                            <table width ="100%" cellpadding ="0"  cellspacing ="0" border ="0" style ="border-color:blue">
                                <TR style="BACKGROUND-COLOR: #eeeeed"><TD style="PADDING-LEFT: 48px" align=left>
                                 <asp:CheckBox id="chkAllOutBox" runat="server"  AutoPostBack="True"></asp:CheckBox> <asp:Label id="lblSelectAllOutBox" runat="server" Text="Select All"></asp:Label> </TD>
                                 <TD style="PADDING-RIGHT: 5px; WIDTH: 312px" align="left" valign = "bottom"><asp:TextBox id="txtSearch" runat="server" CssClass="SearchTxt" Width="300px" AutoPostBack="True" OnTextChanged="txtSearch_TextChanged" ></asp:TextBox> &nbsp; </TD>
                                 </TR>
                                 <tr>
                                    <td  colspan = "2" align ="left" style="padding-left:44px;">
                                               <asp:UpdatePanel id="updMsgOutBox" runat="server">
                                            <contenttemplate>
<DIV style="OVERFLOW: auto; WIDTH: 100%; HEIGHT: 400px" border="0"><asp:GridView id="grdMessageOutBox" runat="server" Width="80%" Font-Size="Smaller" Font-Names="Verdana" EnableTheming="False" ForeColor="#333333" OnSelectedIndexChanged="grdMessageOutBox_SelectedIndexChanged" OnRowCreated="grdMessageOutBox_RowCreated" ShowHeader="False" GridLines="None" CellPadding="4" AutoGenerateColumns="False">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:TemplateField>
<ItemStyle Width="2%"></ItemStyle>
<ItemTemplate>
                                                    <asp:CheckBox id="chkInboxMsg" runat="server" ></asp:CheckBox> 
                                                    
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="OrgID">
<ItemStyle Width="2%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="MessageID">
<ItemStyle Width="2%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Sender">
<ItemStyle Width="10%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Subject">
<ItemStyle Width="20%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="EntryOn">
<ItemStyle Width="20%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="MessageTypeID" HeaderText="MessageTypeID"></asp:BoundField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> </DIV>
</contenttemplate>
                                         </asp:UpdatePanel>
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
      
      
   </div>
</asp:Content>

