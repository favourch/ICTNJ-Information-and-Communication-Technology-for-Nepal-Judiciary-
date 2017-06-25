<%@ Page Language="C#" MasterPageFile="~/MODULES/COMMON/MasterPage.master" AutoEventWireup="true" CodeFile="Document.aspx.cs" Inherits="MODULES_OAS_Forms_Document" Title="Document" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <script language="javascript" type="text/javascript" src="../../COMMON/JS/Validation.js"></script>
     <script language="javascript" type="text/javascript" src="../../COMMON/JS/DateValidator.js"></script>
     <script language="javascript" type="text/javascript">
        function ValidateUploadFile()
        {   
            var ObjFileUpload = document.getElementById('<%= this.FileUpload1.ClientID%>');
                                
            if (ObjFileUpload.value == "")
            {  
                alert("The following errors were encountered.\n\n Browse the file to Attach.");
                ObjFileUpload.focus();
                return false;
            }
            else
                return true;
           
        }
        
        function ValidateDocProcess()
        {
            var ErrMsg = "";
            var myfocus = "";
            var ObjSentTo = document.getElementById('<%= this.txtSendTo.ClientID%>');
            var ObjSentType = document.getElementById('<%= this.drpSentType.ClientID%>');
            var ObjSentStatus = document.getElementById('<%= this.drpSentStatus.ClientID%>');
            
            if (ObjSentTo.value == "")
            {  
                ErrMsg += "- Please Select The "+ ObjSentTo.title +".\n";
                myfocus = ObjSentTo;
                
            }
            
            if (ObjSentType.selectedIndex <= 0)
            {  
                ErrMsg += "- Please Select The "+ ObjSentType.title +".\n";
                
                if(myfocus == "")
                {
                    myfocus = ObjSentType;
                }
               
            }
            
            if (ObjSentStatus.selectedIndex <= 0)
            {  
                ErrMsg += "- Please Select The " + ObjSentStatus.title + ".\n";
                
                if(myfocus == "")
                {
                    myfocus = ObjSentStatus;
                }
               
            }
            
            if (ErrMsg == "") 
                return true;
            else 
            {
                alert("The following errors were encountered.\n\n" + ErrMsg);
               
                myfocus.focus();
                return false;
            }
                       
        }
        
     </script>
     
    <div style=" width:100%">
        <table width ="100%" cellpadding ="0"  cellspacing ="0" border ="0" style ="border-color:Red">
            <tr>
               <td height ="5px">
                    &nbsp;
                   <asp:ScriptManager id="ScriptManager1" runat="server">
                   </asp:ScriptManager>
               </td>
           </tr>
           <tr>
                <td align ="right" style ="padding-right:115px;">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click1" OnClientClick ="javascript: return validate()" />
                </td>
           </tr>
            <tr>
                <td>
                    <asp:UpdatePanel id ="updMasterDoc" runat="server">
                        <contenttemplate>
<TABLE style="BORDER-LEFT-COLOR: red; BORDER-BOTTOM-COLOR: red; BORDER-TOP-COLOR: red; BORDER-RIGHT-COLOR: red" cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR><TD height=5></TD></TR><TR><TD align=center><asp:Panel style="POSITION: static" id="pnlBorder" runat="server" Width="90%" __designer:wfdid="w335" BorderColor="#c8cde4" BorderStyle="Solid" BorderWidth="1px"><TABLE style="BORDER-LEFT-COLOR: red; BORDER-BOTTOM-COLOR: red; BORDER-TOP-COLOR: red; BORDER-RIGHT-COLOR: red" cellSpacing=0 cellPadding=0 width="90%" border=0><TBODY><TR><TD height=5></TD></TR><TR><TD style="HEIGHT: 45px" vAlign=middle align=left colSpan=4><TABLE style="BACKGROUND: #c8cde4" height=31 cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR><TD style="WIDTH: 227px">&nbsp;&nbsp;&nbsp;<asp:Label id="lblTitle1" runat="server" CssClass="headerlabel" Text="Document" __designer:wfdid="w336"></asp:Label> </TD><TD vAlign=middle><asp:Label id="lblStatus" runat="server" CssClass="errorlabel" ForeColor="Red" Font-Bold="True" __designer:wfdid="w337"></asp:Label> </TD></TR></TBODY></TABLE></TD></TR><TR><TD height=5>&nbsp;</TD></TR><TR><TD align=left width="100%"><TABLE cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR><TD align=left><asp:UpdatePanel id="updDoc" runat="server" __designer:wfdid="w338"><ContentTemplate>
<TABLE cellSpacing=0 cellPadding=0 width="65%" border=0><TBODY><TR><TD style="HEIGHT: 25px" class="tblTDRight"><asp:Label id="lblOrganisation" runat="server" Text="Organisation" __designer:wfdid="w339"></asp:Label> <asp:Label id="Label33" runat="server" CssClass="simplelabel" ForeColor="red" Text="*"></asp:Label> </TD><TD style="WIDTH: 176px; HEIGHT: 25px" class="tblTDLeft"><asp:DropDownList id="drpOrganisation_rqd" runat="server" Width="135px" __designer:wfdid="w340" AutoPostBack="True" OnSelectedIndexChanged="drpOrganisation_SelectedIndexChanged" ToolTip="Organisation"></asp:DropDownList> </TD><TD style="WIDTH: 95px; HEIGHT: 25px" class="tblTDRight">&nbsp;</TD><TD style="HEIGHT: 25px" class="tblTDLeft">&nbsp; </TD></TR><TR><TD style="HEIGHT: 35px" class="tblTDRight"><asp:Label id="Label3" runat="server" Text="Unit" __designer:wfdid="w341"></asp:Label> &nbsp;<asp:Label id="Label34" runat="server" CssClass="simplelabel" ForeColor="red" Text="*"></asp:Label></TD><TD style="WIDTH: 176px; HEIGHT: 35px" class="tblTDLeft" vAlign=top>&nbsp;<asp:UpdatePanel id="updUnit" runat="server" __designer:wfdid="w342"><ContentTemplate>
<asp:DropDownList id="drpUnit_rqd" runat="server" Width="135px" __designer:wfdid="w1" Enabled="False" ToolTip="Unit"></asp:DropDownList> 
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="drpOrganisation_rqd" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</Triggers>
</asp:UpdatePanel></TD><TD style="WIDTH: 130px; HEIGHT: 25px" class="tblTDRight"><asp:Label id="Label4" runat="server" Text="Document Flow Type" __designer:wfdid="w346"></asp:Label>&nbsp;<asp:Label id="Label36" runat="server" CssClass="simplelabel" ForeColor="red" Text="*"></asp:Label> </TD><TD style="HEIGHT: 25px" class="tblTDLeft"><asp:DropDownList id="drpFlowType_rqd" runat="server" Width="135px" __designer:wfdid="w347" ToolTip="Document Flow Type"></asp:DropDownList> </TD></TR><TR><TD style="HEIGHT: 35px" class="tblTDRight"><asp:Label id="Label8" runat="server" Text="Document Name" __designer:wfdid="w348"></asp:Label>&nbsp;<asp:Label id="Label35" runat="server" CssClass="simplelabel" ForeColor="red" Text="*"></asp:Label> </TD><TD style="WIDTH: 176px; HEIGHT: 35px" class="tblTDLeft"><asp:TextBox id="txtDocName_rqd" runat="server" __designer:wfdid="w349" ToolTip="Document Name" MaxLength="25"></asp:TextBox> </TD><TD style="WIDTH: 130px; HEIGHT: 25px" class="tblTDRight"><asp:Label id="lblDocCategory" runat="server" Text="Document Category"></asp:Label>&nbsp;<asp:Label id="Label48" runat="server" CssClass="simplelabel" ForeColor="red" Text="*"></asp:Label> </TD><TD style="HEIGHT: 25px" class="tblTDLeft"><asp:DropDownList id="drpDocCategory_rqd" runat="server" Width="135px" ToolTip="Document Category"></asp:DropDownList> </TD></TR><TR><TD class="tblTDRight"><asp:Label id="lblDocDesc" runat="server" Text="Documet Description" __designer:wfdid="w350"></asp:Label> </TD><TD style="HEIGHT: 131px" class="tblTDLeft" colSpan=3><asp:TextBox id="txtDocDesc" runat="server" Width="387px" Height="97px" __designer:wfdid="w351" MaxLength="100"></asp:TextBox> </TD></TR></TBODY></TABLE>
</ContentTemplate>
</asp:UpdatePanel> </TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR><TD height=1>&nbsp;</TD></TR><TR><TD align=center><asp:Panel style="POSITION: static" id="Panel1" runat="server" Width="90%" __designer:wfdid="w352" BorderColor="#c8cde4" BorderStyle="Solid" BorderWidth="1px"><asp:UpdatePanel id="updDocAttachment" runat="server" __designer:wfdid="w353"><ContentTemplate>
<TABLE style="BORDER-LEFT-COLOR: red; BORDER-BOTTOM-COLOR: red; BORDER-TOP-COLOR: red; BORDER-RIGHT-COLOR: red" cellSpacing=0 cellPadding=0 width="90%" border=0><TBODY><TR><TD height=5></TD></TR><TR><TD style="HEIGHT: 39px" vAlign=middle align=left colSpan=2><TABLE style="BACKGROUND: #c8cde4" height=25 cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR><TD style="WIDTH: 227px">&nbsp;&nbsp;&nbsp;<asp:Label id="Label1" runat="server" CssClass="headerlabel" Text="Document Attachment" __designer:wfdid="w354"></asp:Label> </TD><TD vAlign=middle><asp:Label id="lblDocAttachementStatus" runat="server" CssClass="errorlabel" ForeColor="Red" Font-Bold="True" __designer:wfdid="w355"></asp:Label> </TD></TR></TBODY></TABLE></TD></TR><TR><TD height=5>&nbsp;</TD></TR><TR><TD align=left width="100%"><TABLE cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR><TD align=left><TABLE cellSpacing=0 cellPadding=0 width="65%" border=0><TBODY><TR><TD style="HEIGHT: 25px" class="tblTDRight"><asp:Label id="lblAttachFile" runat="server" Text="Attach File" __designer:wfdid="w356"></asp:Label>&nbsp;<asp:Label id="Label42" runat="server" CssClass="simplelabel" ForeColor="red" Text="*"></asp:Label> </TD><TD style="PADDING-LEFT: 17px; HEIGHT: 25px" align=left>&nbsp;<asp:FileUpload id="FileUpload1" runat="server" __designer:wfdid="w357"></asp:FileUpload> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button id="btnAdd" onclick="btnAdd_Click" runat="server" CssClass="simplebtn" Width="76px" Text="Add" OnClientClick="javascript:return ValidateUploadFile()" __designer:wfdid="w358"></asp:Button> </TD></TR><TR><TD style="HEIGHT: 132px" class="tblTDRight"><asp:Label id="lblFileDescription" runat="server" Text="File Description" __designer:wfdid="w359"></asp:Label> </TD><TD style="WIDTH: 406px; HEIGHT: 132px" class="tblTDLeft"><asp:TextBox id="txtFileDescription" runat="server" Width="385px" Height="97px" __designer:wfdid="w360" MaxLength="100"></asp:TextBox> </TD></TR></TBODY></TABLE></TD></TR><TR><TD style="PADDING-LEFT: 63px" align="middle"><TABLE cellSpacing=0 cellPadding=0 width="80%" border=0><TBODY><TR><TD align=left><DIV style="OVERFLOW: auto" width="100% height:800px" border="0"><asp:GridView id="gvFiles" runat="server" Width="430px" ForeColor="#333333" __designer:wfdid="w361" OnRowDataBound="gvFiles_RowDataBound" OnRowDeleting="gvFiles_RowDeleting" CellPadding="4" GridLines="None" AutoGenerateColumns="False">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:TemplateField HeaderText="S.No">
<ItemStyle Width="5px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
<ItemTemplate>
                                                                                                                                            <%# Container.DataItemIndex + 1 %> 
                                                                                                                                         
                                                                                                                                        
                                                                
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="FileName" HeaderText="File Name">
<ItemStyle Width="150px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="FileDescription" HeaderText="File Description">
<ItemStyle Width="250px"></ItemStyle>
</asp:BoundField>
<asp:CommandField SelectText="" ShowDeleteButton="True" DeleteText="Remove">
<ItemStyle Width="25px"></ItemStyle>
</asp:CommandField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> </DIV></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></TD></TR><TR><TD height=5></TD></TR></TBODY></TABLE>
</ContentTemplate>
<Triggers>
<asp:PostBackTrigger ControlID="btnAdd"></asp:PostBackTrigger>
</Triggers>
</asp:UpdatePanel> </asp:Panel> </TD></TR><TR><TD height=1>&nbsp;</TD></TR><TR><TD align=center><asp:Panel style="POSITION: static" id="Panel2" runat="server" Width="90%" __designer:wfdid="w362" BorderColor="#c8cde4" BorderStyle="Solid" BorderWidth="1px"><asp:UpdatePanel id="updDocProcess" runat="server" __designer:wfdid="w363"><ContentTemplate>
<TABLE style="BORDER-LEFT-COLOR: red; BORDER-BOTTOM-COLOR: red; BORDER-TOP-COLOR: red; BORDER-RIGHT-COLOR: red" cellSpacing=0 cellPadding=0 width="90%" border=0><TBODY><TR><TD height=10></TD></TR><TR><TD vAlign=middle align=left colSpan=4><TABLE style="BACKGROUND: #c8cde4" height=25 cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR><TD style="WIDTH: 227px; HEIGHT: 25px">&nbsp;&nbsp;&nbsp;<asp:Label id="Label5" runat="server" CssClass="headerlabel" Text="Document Processing" __designer:wfdid="w364"></asp:Label> </TD><TD style="HEIGHT: 25px" vAlign=middle><asp:Label id="lblDocProcessStatus" runat="server" CssClass="errorlabel" ForeColor="Red" Font-Bold="True" __designer:wfdid="w365"></asp:Label> </TD></TR></TBODY></TABLE></TD></TR><TR><TD height=10>&nbsp;</TD></TR><TR><TD align=left><TABLE cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR><TD><TABLE cellSpacing=0 cellPadding=0 width="65%" border=0><TBODY><TR><TD class="tblTDRight"><asp:Label id="lblSendTo" runat="server" Text="Send To" __designer:wfdid="w366"></asp:Label>&nbsp;<asp:Label id="Label37" runat="server" CssClass="simplelabel" ForeColor="red" Text="*"></asp:Label> </TD><TD style="WIDTH: 176px; HEIGHT: 25px" class="tblTDLeft"><asp:TextBox id="txtSendTo" runat="server" __designer:wfdid="w367" ToolTip="Sent To" MaxLength="15"></asp:TextBox> </TD><TD style="WIDTH: 95px; HEIGHT: 25px" class="tblTDRight"><asp:Label id="Label9" runat="server" Text="Send Type" __designer:wfdid="w368"></asp:Label>&nbsp;<asp:Label id="Label41" runat="server" CssClass="simplelabel" ForeColor="red" Text="*"></asp:Label> </TD><TD class="tblTDLeft"><asp:DropDownList id="drpSentType" runat="server" Width="135px" __designer:wfdid="w369" ToolTip="Sent Type"><asp:ListItem Value="0">Select Sent Type</asp:ListItem>
<asp:ListItem Value="F">Forward</asp:ListItem>
<asp:ListItem Value="B">Backward</asp:ListItem>
</asp:DropDownList> </TD></TR><TR><TD class="tblTDRight"><asp:Label id="lblStatus1" runat="server" Text="Status" __designer:wfdid="w370"></asp:Label>&nbsp;<asp:Label id="Label40" runat="server" CssClass="simplelabel" ForeColor="red" Text="*"></asp:Label> </TD><TD class="tblTDLeft"><asp:DropDownList id="drpSentStatus" runat="server" Width="135px" __designer:wfdid="w371" ToolTip="Status"><asp:ListItem Value="0">Select Status</asp:ListItem>
<asp:ListItem Value="A">Approved</asp:ListItem>
<asp:ListItem Value="P">Pending</asp:ListItem>
<asp:ListItem Value="C">Cancel</asp:ListItem>
</asp:DropDownList> </TD><TD align=center colSpan=2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button id="btnAdd1" onclick="btnAdd1_Click" runat="server" Width="76px" Text="Add" OnClientClick="javascript: return ValidateDocProcess();" __designer:wfdid="w372"></asp:Button> </TD></TR><TR><TD class="tblTDRight"><asp:Label id="lblNote" runat="server" Text="Note" __designer:wfdid="w373"></asp:Label> </TD><TD style="HEIGHT: 131px" class="tblTDLeft" colSpan=3><asp:TextBox id="txtNote" runat="server" Width="385px" Height="97px" __designer:wfdid="w374" MaxLength="100"></asp:TextBox> </TD></TR></TBODY></TABLE></TD></TR><TR><TD style="PADDING-LEFT: 95px" align="middle"><TABLE cellSpacing=0 cellPadding=0 width="80%" border=0><TBODY><TR><TD style="HEIGHT: 14px" align=left>&nbsp;</TD></TR></TBODY></TABLE><asp:GridView id="grdDocProcess" runat="server" ForeColor="#333333" __designer:wfdid="w375" OnRowDataBound="grdDocProcess_RowDataBound" OnRowDeleting="grdDocProcess_RowDeleting" CellPadding="4" GridLines="None" AutoGenerateColumns="False">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:TemplateField HeaderText="S.No">
<ItemStyle Width="5px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
<ItemTemplate>
                                                                                                                    <%# Container.DataItemIndex + 1 %> 
                                                                                                                 
                                            
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="SentTo" HeaderText="Sent To">
<ItemStyle Width="150px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="SentType" HeaderText="Sent Type">
<ItemStyle Width="90px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Status" HeaderText="Status">
<ItemStyle Width="90px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Note" HeaderText="Note">
<ItemStyle Width="200px"></ItemStyle>
</asp:BoundField>
<asp:CommandField ShowDeleteButton="True" DeleteText="Remove">
<ItemStyle Width="25px"></ItemStyle>
</asp:CommandField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView></TD></TR></TBODY></TABLE></TD></TR><TR><TD height=5></TD></TR></TBODY></TABLE>
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="btnAdd1" EventName="Click"></asp:AsyncPostBackTrigger>
</Triggers>
</asp:UpdatePanel> </asp:Panel> </TD></TR><TR><TD height=5></TD></TR></TBODY></TABLE>
</contenttemplate>
                        <triggers>
<asp:AsyncPostBackTrigger ControlID="btnSubmit" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnSubmit1" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
                    </asp:UpdatePanel>
                
                </td>
            </tr>
            <tr>
                <td align ="right" style ="padding-right:115px;">
                    <asp:Button ID="btnSubmit1" runat="server" Text="Submit" OnClick="btnSubmit1_Click" OnClientClick ="javascript: return validate()" />
                </td>
           </tr>
           
            <tr>
                <td height ="10px">&nbsp;</td>
            </tr>
        </table>
        
     
   </div>
</asp:Content>

