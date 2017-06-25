<%@ Page Language="C#" MasterPageFile="~/MODULES/COMMON/MasterPage.master" AutoEventWireup="true" CodeFile="DocumentUpdate.aspx.cs" Inherits="MODULES_OAS_Forms_DocumentUpate" Title="OAS Update" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <script language="javascript" type="text/javascript" src="../../COMMON/JS/Validation.js"></script>
   <script language="javascript" type="text/javascript" src="../../COMMON/JS/DateValidator.js"></script>
  <div  width = "100%">
       <table cellpadding ="0" cellspacing = "0" width = "100%">
         <tr>
               <td height ="5px">
                    &nbsp;
                   <asp:ScriptManager id="ScriptManager1" runat="server">
                   </asp:ScriptManager>
               </td>
           </tr>
        <tr>
            <td align ="center">
                  <asp:Panel ID="pnlBorder" runat="server"  BorderColor="#c8cde4"  BorderStyle="Solid" BorderWidth="1px" Width="90%"  Style="position: static">
                      <table width ="90%" cellpadding ="0" cellspacing ="0" border ="0" style ="border-color:Red">
                        <tr>
                            <td height ="5px"></td>
                        </tr>
                        <tr>
                           <td  colspan="4" valign="middle" align="left" style="height: 45px" >
                              <table width="100%" height ="31px" cellpadding ="0" cellspacing="0" border="0" style="background:#c8cde4 ">
                                    <tr>
                                        <td style="width: 227px"> 
                                             &nbsp;&nbsp;&nbsp;<asp:Label ID="lblTitle1" runat="server" CssClass="headerlabel" Text="Document Update ..."></asp:Label>
                                        </td>
                                        <td valign ="middle" > 
                                           
                                            <asp:Label id="lblStatus" runat="server" CssClass="errorlabel" ForeColor="Red" Font-Bold="True"></asp:Label> 
                                          
                                        </td>
                                    </tr>
                               </table>
                            </td>
                        </tr>
                        <tr>
                            <td height ="5px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td align= "right">
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click1" OnClientClick ="javascript: return validate()" />
                            </td>
                        </tr>
                        <tr>
                            <td align ="left" width ="100%" style="height: 275px">
                                <table cellpadding ="0" cellspacing ="0" border ="0" width ="100%">
                                    <tr>
                                        <td align ="left" >
                                            <table cellpadding ="0" cellspacing ="0" border ="0" width ="65%">
                                               <tr>
                                                   <td style="height: 32px"  class ="tblTDRight" >
                                                        <asp:Label ID="lblDocument" runat="server" Text="Document" CssClass="headerlabel" Font-Underline="True"></asp:Label>
                                                    </td>
                                                    <td colspan ="3" style="height: 32px">&nbsp;</td>
                                                </tr>
                                                 <tr>
                                                    <td class ="tblTDRight" style="height:25px">
                                                        <asp:Label ID="Label1" runat="server" Text="Organisation"></asp:Label>
                                                        &nbsp;<asp:Label id="Label48" runat="server" CssClass="simplelabel" ForeColor="red" Text="*"></asp:Label> 
                                                    </td>
                                                    <td  class ="tblTDLeft" style="width: 176px; height: 25px;">
                                                        &nbsp;<asp:TextBox ID="txtOrganisation" runat="server" ReadOnly="True"></asp:TextBox></td>
                                                    <td  class ="tblTDRight" style="width: 146px; height: 25px;">
                                                        &nbsp;</td>
                                                    <td  class ="tblTDLeft" style="height: 25px">
                                                        &nbsp;&nbsp;
                                                    </td>
                                                </tr>
                                                 <tr>
                                                   <td  class ="tblTDRight" style="height: 25px">
                                                        <asp:Label ID="Label3" runat="server" Text="Unit"></asp:Label>
                                                        &nbsp;<asp:Label id="Label9" runat="server" CssClass="simplelabel" ForeColor="red" Text="*"></asp:Label> 
                                                        </td>
                                                    <td  class ="tblTDLeft" style="width: 173px; height: 25px" >
                                                        &nbsp;<asp:DropDownList ID="drpUnit_rqd" runat="server" ToolTip="Unit" Width="137px">
                                                        </asp:DropDownList></td>
                                                   <td  class ="tblTDRight" style="width: 146px; height: 25px;">
                                                        <asp:Label ID="Label4" runat="server" Text="Document Flow Type"></asp:Label>
                                                        &nbsp;<asp:Label id="Label10" runat="server" CssClass="simplelabel" ForeColor="red" Text="*"></asp:Label> 
                                                    </td>
                                                    <td  class ="tblTDLeft" style="height: 25px">
                                                        &nbsp;<asp:DropDownList ID="drpFlowType_rqd" runat="server" ToolTip="Document Flow Type"
                                                            Width="137px">
                                                        </asp:DropDownList>&nbsp;</td>
                                                   
                                                </tr>
                                                <tr>
                                                     <td  class ="tblTDRight" style="height: 25px">
                                                        <asp:Label ID="Label8" runat="server" Text="Document Name"></asp:Label>
                                                        &nbsp;<asp:Label id="Label11" runat="server" CssClass="simplelabel" ForeColor="red" Text="*"></asp:Label> 
                                                    </td>
                                                    <td  class ="tblTDLeft" style="width: 173px; height: 25px"   >
                                                        &nbsp;<asp:TextBox ID="txtDocName_rqd" runat="server" MaxLength="25" ToolTip="Document Name"></asp:TextBox></td>
                                                       <td  class ="tblTDRight" style="width: 146px; height: 25px;">
                                                        <asp:Label ID="Label2" runat="server" Text="Document Category"></asp:Label>
                                                        &nbsp;<asp:Label id="Label12" runat="server" CssClass="simplelabel" ForeColor="red" Text="*"></asp:Label> 
                                                    </td>
                                                    <td  class ="tblTDLeft" style="height: 25px">
                                                        &nbsp;<asp:DropDownList ID="drpDocCategory_rqd" runat="server" ToolTip="Document Category"
                                                            Width="137px">
                                                        </asp:DropDownList>
                                                        &nbsp;&nbsp;</td>
                                                   
                                                </tr>
                                               
                                                
                                                <tr>
                                                    <td class ="tblTDRight">
                                                        <asp:Label ID="lblDocDesc" runat="server" Text="Documet Description"></asp:Label>
                                                    </td>
                                                    <td  class ="tblTDLeft" colspan ="3" valign ="top">
                                                        &nbsp;<asp:TextBox ID="txtDocDescription" runat="server" Height="60px" Width="451px" MaxLength="50" ToolTip="Document Description"></asp:TextBox>
                                                    </td>
                                                </tr>  
                                         
                                            </table>
                                        
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                    </tr>
     
                                    <tr>
                                        <td align ="left" >
                                            <asp:UpdatePanel runat="server" id ="updDocAttachment">
                                                <contenttemplate>
<TABLE style="WIDTH: 65%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="HEIGHT: 25px" class="tblTDRight"><asp:Label id="lblDocumentAttachment" runat="server" CssClass="headerlabel" Text="Document Attachment" Font-Underline="True" __designer:wfdid="w54"></asp:Label> </TD><TD colSpan=3>&nbsp;</TD></TR><TR><TD style="HEIGHT: 25px" class="tblTDRight"><asp:Label id="Label7" runat="server" Text="Change Attach File" __designer:wfdid="w55"></asp:Label> </TD><TD style="PADDING-LEFT: 25px; WIDTH: 176px; HEIGHT: 25px"><asp:FileUpload id="FileUpload1" runat="server" __designer:wfdid="w56"></asp:FileUpload></TD><TD style="WIDTH: 125px; HEIGHT: 25px" class="tblTDRight">&nbsp;</TD><TD style="HEIGHT: 25px" class="tblTDLeft">&nbsp;</TD></TR><TR><TD style="HEIGHT: 25px" class="tblTDRight"><asp:Label id="lblFileName" runat="server" Text="FileName" __designer:wfdid="w57"></asp:Label> </TD><TD style="WIDTH: 176px; HEIGHT: 25px" class="tblTDLeft">&nbsp;<asp:TextBox id="txtAttachFileName" runat="server" Width="149px" MaxLength="25" __designer:wfdid="w58"></asp:TextBox></TD><TD style="WIDTH: 125px; HEIGHT: 25px" class="tblTDRight">&nbsp;</TD><TD style="HEIGHT: 25px" class="tblTDLeft">&nbsp;&nbsp;<asp:Button id="btnChangeAttach" onclick="btnChangeAttach_Click" runat="server" Text="Change" __designer:wfdid="w59" Visible="False"></asp:Button>&nbsp;</TD></TR><TR><TD class="tblTDRight"><asp:Label id="lblFileDescription" runat="server" Text="File Description" __designer:wfdid="w60" OnClientClick ="javascript: return validate()"></asp:Label> </TD><TD class="tblTDLeft" colSpan=3>&nbsp;<asp:TextBox id="txtAttachFileDesc" runat="server" Width="451px" Height="60px" MaxLength="50" __designer:wfdid="w61"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 132px; HEIGHT: 35px" class="tblTDRight">&nbsp; </TD><TD class="tblTDLeft" colSpan=3><TABLE cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR><TD>&nbsp; <asp:GridView id="grdDocAttachment" runat="server" Width="95%" ForeColor="#333333" __designer:wfdid="w62" CellPadding="4" GridLines="None" AutoGenerateColumns="False" OnSelectedIndexChanging="grdDocAttachment_SelectedIndexChanging" OnRowCreated="grdDocAttachment_RowCreated">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:TemplateField HeaderText="S.No">
<ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
<ItemTemplate>
                                                                                   <%# Container.DataItemIndex + 1 %> 
                                                                                
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="AttachmentID" HeaderText="AttachID"></asp:BoundField>
<asp:BoundField DataField="FileName" HeaderText="FileName">
<ItemStyle Width="30%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DocSequence" HeaderText="Document Sequence"></asp:BoundField>
<asp:BoundField DataField="FileDescription" HeaderText="File Description">
<ItemStyle Width="55%"></ItemStyle>
</asp:BoundField>
<asp:CommandField ShowSelectButton="True">
<ItemStyle Width="10%"></ItemStyle>
</asp:CommandField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> </TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
</contenttemplate>
                                                <triggers>
<asp:PostBackTrigger ControlID="btnChangeAttach"></asp:PostBackTrigger>
</triggers>
                                            </asp:UpdatePanel>   
                                              
                                        </td>
                                    </tr>
                                     <tr>
                                        <td>&nbsp;</td>
                                     </tr>  
                                     <tr>
                                        <td align ="left" >
                                            <asp:UpdatePanel runat="server" id ="updDocProcess">
                                                <contenttemplate>
<TABLE style="WIDTH: 65%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="HEIGHT: 22px" class="tblTDRight"><asp:Label id="Label5" runat="server" CssClass="headerlabel" Text="Document Process" Font-Underline="True" __designer:wfdid="w1"></asp:Label> </TD><TD colSpan=3>&nbsp; </TD></TR><TR><TD style="HEIGHT: 25px" class="tblTDRight"><asp:Label id="Label6" runat="server" Text="Sent To" __designer:wfdid="w2"></asp:Label> </TD><TD style="WIDTH: 176px; HEIGHT: 25px" class="tblTDLeft">&nbsp;<asp:TextBox id="txtSentTo" runat="server" MaxLength="25" __designer:wfdid="w3"></asp:TextBox></TD><TD style="WIDTH: 125px; HEIGHT: 25px" class="tblTDRight"><asp:Label id="lblSentType" runat="server" Text="Sent Type" __designer:wfdid="w4"></asp:Label> </TD><TD style="HEIGHT: 25px" class="tblTDLeft">&nbsp;<asp:DropDownList id="drpSentType" runat="server" Width="135px" ToolTip="Sent Type" __designer:wfdid="w5">
 <asp:ListItem Value="0">Select Sent Type</asp:ListItem>
<asp:ListItem Value="F">Forward</asp:ListItem>
<asp:ListItem Value="B">Backward</asp:ListItem>
</asp:DropDownList>&nbsp; </TD></TR><TR><TD style="HEIGHT: 25px" class="tblTDRight"><asp:Label id="lblStatus1" runat="server" Text="Status" __designer:wfdid="w6"></asp:Label>&nbsp; </TD><TD style="WIDTH: 176px; HEIGHT: 25px" class="tblTDLeft">&nbsp;<asp:DropDownList id="drpSentStatus" runat="server" Width="135px" ToolTip="Status" __designer:wfdid="w7"><asp:ListItem Value="0">Select Status</asp:ListItem>
<asp:ListItem Value="A">Approved</asp:ListItem>
<asp:ListItem Value="P">Pending</asp:ListItem>
<asp:ListItem Value="C">Cancel</asp:ListItem>
</asp:DropDownList> </TD><TD style="WIDTH: 125px; HEIGHT: 25px" class="tblTDRight">&nbsp; </TD><TD style="HEIGHT: 25px" class="tblTDLeft">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <asp:Button id="btnChangeProcess" onclick="btnChangeProcess_Click" runat="server" Text="Change" __designer:wfdid="w8" Visible="False"></asp:Button></TD></TR><TR><TD class="tblTDRight"><asp:Label id="lblNote" runat="server" Text="Note" __designer:wfdid="w9"></asp:Label> </TD><TD class="tblTDLeft" colSpan=3>&nbsp;<asp:TextBox id="txtNote" runat="server" Width="451px" Height="60px" MaxLength="50" __designer:wfdid="w10"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 132px; HEIGHT: 25px" class="tblTDRight">&nbsp; </TD><TD style="WIDTH: 294px" class="tblTDLeft" colSpan=3><TABLE cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR><TD>&nbsp; <asp:GridView id="grdDocProcess" runat="server" Width="467px" ForeColor="#333333" __designer:wfdid="w11" OnRowCreated="grdDocProcess_RowCreated" OnSelectedIndexChanging="grdDocProcess_SelectedIndexChanging" AutoGenerateColumns="False" GridLines="None" CellPadding="4" OnRowDataBound="grdDocProcess_RowDataBound">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:TemplateField HeaderText="S.No">
<ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
<ItemTemplate>
                                                                                   <%# Container.DataItemIndex + 1 %> 
                                                                                
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="DocSequence" HeaderText="DocSequence"></asp:BoundField>
<asp:BoundField DataField="SentTo" HeaderText="Sent To">
<ItemStyle Width="20%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="SentType" HeaderText="Sent Type">
<ItemStyle Width="10%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Status" HeaderText="Status">
<ItemStyle Width="10%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="HasReceived" HeaderText="Has Received"></asp:BoundField>
<asp:BoundField DataField="Note" HeaderText="Note">
<ItemStyle Width="35%"></ItemStyle>
</asp:BoundField>
<asp:CommandField ShowSelectButton="True">
<ItemStyle Width="10%"></ItemStyle>
</asp:CommandField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> </TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
</contenttemplate>
                                                <triggers>
<asp:AsyncPostBackTrigger ControlID="btnChangeProcess" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
                                            </asp:UpdatePanel>
                                             
                                        </td>
                                    </tr>
                               </table>
                            </td>
                        </tr>
                        <tr>
                            <td align= "right">
                                <asp:Button ID="btnUpdate1" runat="server" Text="Update" OnClick="btnUpdate1_Click1" />
                            </td>
                        </tr>
                         <tr>
                                <td height = "3px" style="width: 132px">&nbsp;</td>
                            </tr>
                    </table>
                   </asp:Panel> 
            </td>
        </tr>
      
        <tr>
            <td height ="5px">&nbsp;</td>
        </tr>
    </table>
         
    </div>
    
</asp:Content>

