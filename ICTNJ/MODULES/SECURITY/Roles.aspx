<%@ Page Language="C#" MasterPageFile="~/MODULES/COMMON/MasterPage.master" AutoEventWireup="true" CodeFile="Roles.aspx.cs" Inherits="MODULES_SECURITY_Roles" Title="PMS | Roles" %>
<%@ Register 
    Assembly="AjaxControlToolkit" 
    Namespace="AjaxControlToolkit" 
    TagPrefix="ajaxToolkit" %>
    
    <script runat="server">

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
</script>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript" src="../COMMON/JS/Validation.js"></script>
<script language="javascript" type="text/javascript" src="../COMMON/JS/DateValidator.js"></script>


<script language="javascript">
    function textboxMultilineMaxNumber(txt,maxLen){
        try{
            if(txt.value.length > (maxLen-1))return false;
           }catch(e){
        }
    }
</script>
                <asp:ScriptManager id="ScriptManager1" runat="server">
                </asp:ScriptManager>

                <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" style="display:none"/>
        <ajaxToolkit:ModalPopupExtender runat="server" ID="programmaticModalPopup"
            BehaviorID="programmaticModalPopupBehavior"
            TargetControlID="hiddenTargetControlForModalPopup"
            PopupControlID="programmaticPopup" 
            BackgroundCssClass="modalBackground"
            DropShadow="True"
            PopupDragHandleControlID="programmaticPopupDragHandle"
            RepositionMode="RepositionOnWindowScroll" >
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel runat="server" CssClass="modalPopup" ID="programmaticPopup" style="display:none;width:350px;padding:10px">
            <asp:Panel runat="Server" ID="programmaticPopupDragHandle" Style="cursor: move;background-color:#DDDDDD;border:solid 1px Gray;color:Black;text-align:center;">
                Save Status
            </asp:Panel>
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label><br />
<asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click" Width="58px" />           <br />
        </asp:Panel>
    <table cellspacing="5">
        <tr>
            <td valign="top">
                <asp:Label ID="Label2" runat="server" Text="Application" SkinID="Unicodelbl"></asp:Label></td>
            <td colspan="3" valign="top" style="width: 518px">
                <asp:DropDownList ID="ddlApplication_Rqd" runat="server" Width="275px" AutoPostBack="True" OnSelectedIndexChanged="ddlApplication_Rqd_SelectedIndexChanged" ToolTip="Application" SkinID="Unicodeddl">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="Label3" runat="server" Text="Role Name" SkinID="Unicodelbl"></asp:Label></td>
            <td colspan="3" style="width: 518px" valign="top">
                <asp:TextBox ID="txtRoleName_Rqd" runat="server" MaxLength="20" ToolTip="Role Name" Width="268px" SkinID="Unicodetxt"></asp:TextBox><ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom, UppercaseLetters, LowercaseLetters"
                    TargetControlID="txtRoleName_Rqd" ValidChars='" "'>
                </ajaxToolkit:FilteredTextBoxExtender>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="Label4" runat="server" Text="Role Description" Width="103px" SkinID="Unicodelbl"></asp:Label></td>
            <td valign="top" style="width: 518px" colspan="3">
                <asp:TextBox ID="txtRoleDesc_Rqd" runat="server" MaxLength="100" Width="506px" Height="27px" TextMode="MultiLine" onkeypress="return textboxMultilineMaxNumber(this,50)" ToolTip="Role Description" SkinID="Unicodetxt"></asp:TextBox><ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom, UppercaseLetters, LowercaseLetters"
                    TargetControlID="txtRoleDesc_Rqd" ValidChars='" "'>
                </ajaxToolkit:FilteredTextBoxExtender>
            </td>
        </tr>
    </table>
    <hr />
    <br />
    <table style="width: 633px">
        <tr>
            <td style="width: 266px">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="List of Roles" Width="182px" SkinID="UnicodeHeadlbl"></asp:Label></td>
            <td style="width: 22540px">
            </td>
            <td style="width: 322px">
                <asp:Label ID="lblMenus" runat="server" Font-Bold="True" Text="List of Menus" SkinID="UnicodeHeadlbl" Width="124px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 266px">
                <asp:ListBox AutoPostBack="True" Height="304px" ID="lstRoles" OnSelectedIndexChanged="lstRoles_SelectedIndexChanged" runat="server" Width="250px" SkinID="Unicodelst">
            </asp:ListBox></td>
            <td style="width: 22540px">
            </td>
            <td style="width: 322px">
                <asp:Panel ID="Panel3" runat="server" Height="300px" Width="604px" ScrollBars="Auto">
                    <asp:GridView ID="grdApplMenus" runat="server" AutoGenerateColumns="False" CellPadding="1"
                        CellSpacing="2" ForeColor="#333333" GridLines="None" OnRowDataBound="grdApplMenus_RowDataBound" Style="position: static" Width="400px" SkinID="Unicodegrd">
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="ApplicationID" HeaderText="ApplID" />
                            <asp:BoundField DataField="FormID" HeaderText="FormID">
                                <ItemStyle HorizontalAlign="Left" Width="10px" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MenuID" HeaderText="MenuID">
                                <ItemStyle HorizontalAlign="Left" Width="10px" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MenuName" HeaderText="Menu Name">
                                <ItemStyle Width="280px" />
                                <HeaderStyle Width="200px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MenuDescription" HeaderText="MenuDescription" />
                           <asp:TemplateField HeaderText="Select">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelectMenu" runat="server" Enabled='<%# Eval("RDPSelect") %>' />
                                </ItemTemplate>
                           <ItemStyle HorizontalAlign="Center" />
                           <HeaderStyle Width="50px" HorizontalAlign="Center" />
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="OldSelect">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkOldSelectMenu" runat="server" Enabled='<%# Eval("RDPSelect") %>' />
                                </ItemTemplate>
                           <ItemStyle HorizontalAlign="Center" />
                           <HeaderStyle Width="50px" HorizontalAlign="Center" />
                            </asp:TemplateField>                            
                           <asp:TemplateField HeaderText="Add">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkAddMenu" runat="server" Enabled='<%# Eval("RDPAdd") %>' />
                                </ItemTemplate>
                           <ItemStyle HorizontalAlign="Center" />
                           <HeaderStyle Width="50px" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            
                           <asp:TemplateField HeaderText="OldAdd">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkOldAddMenu" runat="server" Enabled='<%# Eval("RDPAdd") %>' />
                                </ItemTemplate>
                           <ItemStyle HorizontalAlign="Center" />
                           <HeaderStyle Width="50px" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            
                                                        
                           <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkEditMenu" runat="server"  Enabled='<%# Eval("RDPEdit") %>' />
                                </ItemTemplate>
                           <ItemStyle HorizontalAlign="Center" />
                           <HeaderStyle Width="50px" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            
                           <asp:TemplateField HeaderText="OldEdit">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkOldEditMenu" runat="server" Enabled='<%# Eval("RDPEdit") %>' />
                                </ItemTemplate>
                           <ItemStyle HorizontalAlign="Center" />
                           <HeaderStyle Width="50px" HorizontalAlign="Center" />
                            </asp:TemplateField>
                                                        
                           <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkDelMenu" runat="server" Enabled='<%# Eval("RDPDelete") %>' />
                                </ItemTemplate>
                           <ItemStyle HorizontalAlign="Center" />
                           <HeaderStyle Width="50px" HorizontalAlign="Center" />
                           </asp:TemplateField>
                           
                           <asp:TemplateField HeaderText="OldDelete">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkOldDelMenu" runat="server" Enabled='<%# Eval("RDPDelete") %>' />
                                </ItemTemplate>
                           <ItemStyle HorizontalAlign="Center" />
                           <HeaderStyle Width="50px" HorizontalAlign="Center" />
                           </asp:TemplateField>                           




                        </Columns>
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                        <EditRowStyle BackColor="#999999" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                    &nbsp;</asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="width: 266px">
            </td>
            <td align="right" style="width: 22540px">
            </td>
            <td align="right" style="width: 322px">
            <asp:Button ID="btnOK" runat="server" Text="Submit" Width="65px" OnClick="btnOK_Click" OnClientClick="javascript:return validate();" SkinID="Normal"   /><asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" SkinID="Cancel"/></td>
        </tr>
    </table>
    <br />
</asp:Content>

