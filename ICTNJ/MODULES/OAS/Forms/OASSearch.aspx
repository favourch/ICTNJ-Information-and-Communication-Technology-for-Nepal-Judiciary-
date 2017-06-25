<%@ Page Language="C#" MasterPageFile="~/MODULES/COMMON/MasterPage.master" AutoEventWireup="true" CodeFile="OASSearch.aspx.cs" Inherits="MODULES_OAS_Forms_OASSearch" Title="Office Automation Search (OAS)" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" type="text/javascript" src="../../COMMON/JS/Validation.js"></script>
   <script language="javascript" type="text/javascript" src="../../COMMON/JS/DateValidator.js"></script>
   <script type="text/javascript"> 
    function SetHiddenStatus()
    {
        var HiddenValue = document.getElementById('<%= this.hfStatusHidden.ClientID%>').value;
        
        if(HiddenValue == "0")
            document.getElementById('<%= this.hfStatusHidden.ClientID%>').value = "1";
    }
    </script>
    <div style="width:100%; height:1250px">
        &nbsp;<asp:ScriptManager id="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:HiddenField ID="hfStatusHidden" runat="server" Value="0" />
        <table width ="100%" cellpadding="0" cellspacing="0" border="0" style ="border-color:Black;">
            <tr>
                <td height ="5px"></td>
            </tr>
            <tr>
                <td align="center" >
                    <asp:Panel ID="Panel1" runat="server"  Width="72%" Style="position: static" BorderColor="#c8cde4" BorderWidth="1px" BorderStyle="Solid" >
                    
                           <table width ="98%"   cellpadding ="0" cellspacing="0" border="0" style ="border-color:Black;">
                            <tr>
                                <td height ="5px"></td>
                            </tr>
                            <tr>
                                <td colspan = "5">
                                       <table width="100%" cellpadding ="0" cellspacing="0" border="0"  style="background:#c8cde4;border-color:black; position:static; ">
                                            <tr>
                                                <td style="width: 30%" height ="25px" align= "left" >&nbsp;&nbsp;&nbsp;<asp:Label ID="lblHeader" runat="server" CssClass="headerlabel" Text="OAS Search ..."></asp:Label></td>
                                                <td class = "tblTDLeft">
                                                    <asp:UpdatePanel id="UpdatePanel1" runat="server">
                                                    <contenttemplate>
                                                        <asp:Label id="lblStatus" runat="server" CssClass="errorlabel" ForeColor="Red" Font-Bold="True" __designer:wfdid="w68"></asp:Label> <IMG style="VISIBILITY: hidden" id="pleasewait" src="../../../MODULES/COMMON/Images/pleasewait.gif" /> 
                                                        </contenttemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                       </table>
                                   
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 26px" align ="right" valign ="bottom">
                                    <asp:Label ID="lblOrganisation" runat="server" Text="Organisation" Width="121px"></asp:Label>&nbsp;&nbsp;
                                </td>
                                <td style="height: 26px; width: 99px;" align ="left"> &nbsp;&nbsp;
                                    <asp:UpdatePanel id="updSearchOrg" runat="server">
                                        <contenttemplate>
<asp:DropDownList id="drpOrganisation" runat="server" Width="180px" ToolTip="Select Organisation" OnSelectedIndexChanged="drpOrganisation_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> 
</contenttemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td style="height: 26px" align ="right" valign ="bottom">
                                    <asp:Label ID="lblUnit" runat="server" Text="Unit"></asp:Label> &nbsp;&nbsp;
                                </td>
                                <td style="height: 26px; width: 99px;" align ="left"> &nbsp;&nbsp;
                                    <asp:UpdatePanel id="updSearchUnit" runat="server">
                                        <contenttemplate>
<asp:DropDownList id="drpUnit" runat="server" Width="180px" Font-Names="Verdana" OnSelectedIndexChanged="drpUnit_SelectedIndexChanged" AutoPostBack="True" ToolTip="Select Library" __designer:wfdid="w8" Enabled="False"></asp:DropDownList> 
</contenttemplate>
                                    <triggers>
<asp:AsyncPostBackTrigger ControlID="drpOrganisation" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
                                    </asp:UpdatePanel>
                                </td>
                                <td style="height: 26px" valign ="bottom">
                                    &nbsp; &nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search"  Width="80px" Font-Names="Verdana" ToolTip="Search" OnClientClick ="callProgressbar();" CssClass="Searchbtn" OnClick="btnSearch_Click"   />
                                    <asp:Button ID="btnCancel" runat="server" CssClass="Navbtn" OnClick="btnCancel_Click" OnClientClick="SetHiddenStatus();clearCheckBox();callProgressbar()"  Text="Cancel" /></td>
                            </tr>
                                                      
                             <tr>
                                <td align ="right" valign ="middle" style ="height:26px">
                                    <asp:Label ID="lblDocName" runat="server" Text="Doccument Name"></asp:Label> &nbsp;&nbsp;
                                </td>
                                <td align ="left" style="width: 99px" valign ="bottom"> &nbsp;
                                    <asp:UpdatePanel id="updSearchDocName" runat="server">
                                        <contenttemplate>
                                    <asp:DropDownList ID="drpDocName" runat="server" Font-Names="Verdana" ToolTip="Select Library"
                                        Width="180px" Enabled="False">
                                    </asp:DropDownList>
</contenttemplate>
                                        <triggers>
<asp:AsyncPostBackTrigger ControlID="drpUnit" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
                                    </asp:UpdatePanel>&nbsp;&nbsp;
                                  
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            
                            <%-- <tr>
                                <td align ="right" valign ="bottom" style ="height:26px">
                                    <asp:Label ID="lblDocStatus" runat="server" Text="Status"></asp:Label> &nbsp;&nbsp;
                                </td>
                                <td align ="left" style="width: 99px" valign ="bottom"> &nbsp;
                                    <asp:DropDownList ID="drpDocStatus" runat="server" Font-Names="Verdana" ToolTip="Select Library"
                                        Width="180px">
                                        <asp:ListItem>Select</asp:ListItem>
                                        <asp:ListItem Value="A">Approved</asp:ListItem>
                                        <asp:ListItem Value="P">Pending</asp:ListItem>
                                        <asp:ListItem Value="C">Cancel</asp:ListItem>
                                    </asp:DropDownList>&nbsp;
                                  
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>--%>
                          
                            <tr>
                                <td height = "10px"></td>
                            </tr>
                        </table>
                   </asp:Panel>         
                 </td>
            </tr>
            <tr>
                <td height ="5px">
                    
                </td>
            </tr>
            <tr>
                <td align ="center">
                    <table width ="90%" cellpadding="0" cellspacing="0">
                     <tr>
                        <td style="height: 5px"></td>
                     </tr>
                 
                     <tr>
                        <td style="height: 54px" width ="62%" colspan ="3">
                         <asp:UpdatePanel id="updSearchDocResult" runat="server">
                            <contenttemplate>
<DIV style="OVERFLOW: auto" id="dvSearchDocResult"><asp:GridView id="grdDocSearchResult" runat="server" Width="80%" ForeColor="#333333" __designer:wfdid="w7" OnSelectedIndexChanging="grdDocSearchResult_SelectedIndexChanging" OnRowUpdating="grdDocSearchResult_RowUpdating" OnRowEditing="grdDocSearchResult_RowEditing" OnDataBound="grdDocSearchResult_DataBound" CellPadding="4" GridLines="None" AutoGenerateColumns="False" OnRowCreated="grdDocSearchResult_RowCreated">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:TemplateField HeaderText="S.No">
<ItemStyle Width="20px" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
<ItemTemplate>
                                                                    &nbsp;<%# Container.DataItemIndex + 1 %> 
                                                                                                                                                                                                                                                                                                                                                          					                                             
                                                                      
                                                    
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="OrgID" HeaderText="OrgID"></asp:BoundField>
<asp:BoundField DataField="UnitID" HeaderText="UnitID"></asp:BoundField>
<asp:BoundField DataField="DocID" HeaderText="DocID"></asp:BoundField>
<asp:BoundField DataField="DocumentName" HeaderText="DocumentName"></asp:BoundField>
<asp:BoundField DataField="DocDescription" HeaderText="Description"></asp:BoundField>
<asp:BoundField DataField="DocCategoryName" HeaderText="Category Name"></asp:BoundField>
<asp:BoundField DataField="DocFlowTypeName" HeaderText="DocFlowType"></asp:BoundField>
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
</triggers>
                         </asp:UpdatePanel>
                            
                     </td>
                     </tr>
                    </table>
                </td>
             </tr>
             <tr>
                <td height ="12px"></td>
            </tr>
        </table>
    </div>
</asp:Content>

