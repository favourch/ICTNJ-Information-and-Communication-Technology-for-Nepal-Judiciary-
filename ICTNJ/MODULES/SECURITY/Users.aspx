<%@ Page AutoEventWireup="true" CodeFile="Users.aspx.cs" Inherits="MODULES_Security_Users" Language="C#" MasterPageFile="~/MODULES/COMMON/MasterPage.master" Title="PMS | Users" %>
<%--<%@ Page Language="C#" MasterPageFile="~/MODULES/COMMON/MasterPage.master" MaintainScrollPositionOnPostback="true"AutoEventWireup="true" CodeFile="Users.aspx.cs" Inherits="MODULES_SECURITY_Forms_Users" Title="Untitled Page" %>
--%>

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

    <script language="javascript" type="text/javascript" src="../../COMMON/JS/Validation.js"></script>
    <script language="javascript" type="text/javascript" src="../../COMMON/JS/DateValidator.js"></script>
    <script language="javascript" type="text/javascript" src="../../COMMON/JS/EnglishDateValidator.js"></script>
    <script language="javascript" type="text/javascript">
        function CallValidations()
        {
            if(validate()==false)
                return false;
            else
              return ValidateEnglishDate();
        }
function TABLE1_onclick() {

}

    </script>
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
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
        
        
        
                
        <table style="position: static" width="700" id="TABLE1" onclick="return TABLE1_onclick()">
            <tr>
                <td valign="top" width="200">
    <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Italic="False"
            SkinID="aa" Style="position: static" Text="User List"></asp:Label></td>
                <td valign="top" style="width: 500px">
                    </td>
            </tr>
            <tr>
                <td valign="top" width="200">
                    <asp:ListBox ID="lstUsers" runat="server" Height="457px" Style="position: static"
                        Width="180px" AutoPostBack="True" OnSelectedIndexChanged="lstUsers_SelectedIndexChanged" OnPreRender="lstUsers_PreRender" SkinID="Unicodelst" >
                    </asp:ListBox></td>
                <td valign="top" align="left" style="width: 500px">
        <table style="position: static">
            <tr>
                <td style="width: 140px; height: 27px;" align="left">
                    <asp:Label ID="lblOrganization" runat="server" Style="position: static" Width="86px" SkinID="Unicodelbl">Organization</asp:Label></td>
                <td style="width: 193px; height: 27px; color: red;">
                    <asp:DropDownList ID="DDLOgranization" runat="server" SkinID="Unicodeddl" Style="position: static"
                        Width="200px" AutoPostBack="True" OnSelectedIndexChanged="DDLOgranization_RQD_SelectedIndexChanged" ToolTip="Organization">
                    </asp:DropDownList>*</td>
                <td rowspan="1" style="width: 50px" valign="top" align="right">
                    <asp:Label ID="lblTransferTo" runat="server" Text="Transfer To" Width="91px" Visible="False" SkinID="Unicodelbl"></asp:Label></td>
                
                <td align="left" rowspan="1" style="width: 150px" valign="top">
                    <asp:DropDownList ID="DDLTransferTo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLTransferTo_SelectedIndexChanged"
                        Width="188px" Visible="False" SkinID="Unicodeddl">
                    </asp:DropDownList>
                        
                </td>
                <td align="left" rowspan="1" style="width: 193px" valign="top">
                </td>
                <td align="left" rowspan="1" style="width: 193px" valign="top">
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 140px; height: 27px">
                    <asp:Label ID="lblPersonID" runat="server" Text="Person ID" SkinID="Unicodelbl"></asp:Label></td>
                <td style="width: 193px; color: red; height: 27px">
                    <asp:TextBox ID="txtPersonID" runat="server" MaxLength="10" Width="193px" ToolTip="Person ID" SkinID="Unicodetxt"></asp:TextBox></td>
                <td style="width: 193px; color: red; height: 27px">
                    </td>
                <td style="width: 193px; color: red; height: 27px">
                    </td>
                <td style="width: 193px; color: red; height: 27px">
                    </td>
                <td style="width: 193px; color: red; height: 27px">
                    </td>
            </tr>
            <tr>
                <td style="width: 140px; height: 24px;" align="left">
                    <asp:Label ID="lblUsername" runat="server" Style="position: static" Text="Username" SkinID="Unicodelbl"></asp:Label></td>
                <td style="width: 193px; height: 24px; color: red;">
                    <asp:TextBox ID="txtUserName_RQD" runat="server" SkinID="Unicodetxt" Style="position: static" Width="193px" MaxLength="15" ToolTip="Username"></asp:TextBox>*</td>
                <td rowspan="5" colspan="4" style="height: 24px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 140px" align="left">
                    <asp:Label ID="lblPassword" runat="server" Style="position: static" Text="Password" SkinID="Unicodelbl"></asp:Label></td>
                <td style="width: 193px; color: red;">
                    <asp:TextBox ID="txtPassword_RQD" runat="server" SkinID="Unicodetxt" Style="position: static" Width="193px" TextMode="Password" MaxLength="15" ToolTip="Password"></asp:TextBox>*</td>
            </tr>
            <tr>
                <td style="width: 140px; height: 26px;" align="left">
                    <asp:Label ID="lblRePassword" runat="server" Style="position: static" Text="Re-password" SkinID="Unicodelbl"></asp:Label></td>
                <td style="width: 193px; color: red; height: 26px;">
                    <asp:TextBox ID="txtRePassword_RQD" runat="server" SkinID="Unicodetxt" Style="position: static" Width="193px" TextMode="Password" MaxLength="15" ToolTip="Re-password"></asp:TextBox>*</td>
            </tr>
            <tr>
                <td style="width: 140px; height: 2px;" align="left">
                    <asp:Label ID="lblValidUpto" runat="server" Style="position: static" Text="Valid upto" SkinID="Unicodelbl"></asp:Label></td>
                <td style="width: 193px; height: 2px; color: red;">
                    &nbsp;<asp:TextBox ID="txtValidUpto_REDT" runat="server" SkinID="Unicodetxt" Style="position: static" Width="190px" ToolTip="Valid upto" MaxLength="10"></asp:TextBox>*<ajaxToolkit:MaskedEditExtender
                        ID="MaskedEditExtender1" runat="server" AutoComplete="False" Mask="99/99/9999" MaskType="Date" TargetControlID="txtValidUpto_REDT" UserDateFormat="DayMonthYear">
                    </ajaxToolkit:MaskedEditExtender>
                    <br />
                </td>
            </tr>
            <tr>
                <td style="width: 140px">
                    <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="Active"></asp:Label></td>
                <td style="width: 193px">
                    <asp:CheckBox ID="chkActive" runat="server" SkinID="smallChk" /></td>
            </tr>
        </table>
                    <br />
                    <table width="600">
                        <tr>
                            <td style="width: 270px;">
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Applications" SkinID="UnicodeHeadlbl"></asp:Label></td>
                            <td style="width: 280px;">
                                <asp:Label ID="lblRoles" runat="server" Font-Bold="True" Text="Roles" Visible="False" SkinID="UnicodeHeadlbl"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 270px; height: 43px;" valign="top">
                                <asp:ListBox ID="lstApplications" runat="server" OnSelectedIndexChanged="lstApplications_SelectedIndexChanged" Width="300px" AutoPostBack="True" Height="163px" OnPreRender="lstApplications_PreRender" SkinID="Unicodelst">
                                </asp:ListBox></td>
                            <td style="width: 280px; height: 43px;" valign="top" align="left">
                                <asp:Panel ID="pnlRoles" runat="server" BackColor="White" BorderColor="LightSteelBlue"
                                    BorderStyle="Solid" BorderWidth="1px" Height="148px" ScrollBars="Vertical" Visible="False"
                                    Width="270px">
                                <asp:CheckBoxList ID="chklstRoles" runat="server" Width="249px">
                                </asp:CheckBoxList>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 270px; height: 1px;">
                            </td>
                            <td style="width: 280px; height: 1px;" align="right">
                                <asp:Button ID="btnAddRolesToGrid" runat="server" OnClick="btnAddRolesToGrid_Click"
                                    Text="Add Roles" Visible="False" SkinID="Normal" /></td>
                        </tr>
                    </table>
        <table style="position: static">
            <tr>
                <td style="width: 100px; height: 21px;">
                    <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Italic="False" SkinID="UnicodeHeadlbl"
                        Style="position: static" Text="Role Granted" Width="141px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 19px;">
                    <asp:GridView ID="grdRoles" runat="server" AutoGenerateColumns="False" CellPadding="1"
                        ForeColor="#333333" GridLines="None" SkinID="Unicodegrd" Style="position: static"
                        Width="500px" CellSpacing="2" OnRowDeleting="grdRoles_RowDeleting" OnSelectedIndexChanged="grdRoles_SelectedIndexChanged" OnRowCreated="grdRoles_RowCreated" OnRowDataBound="grdRoles_RowDataBound" OnSelectedIndexChanging="grdRoles_SelectedIndexChanging" OnRowCommand="grdRoles_RowCommand" AllowSorting="True" OnSorting="grdRoles_Sorting" BorderStyle="None">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                        <Columns>
                            <asp:BoundField DataField="RoleID" HeaderText="RoleID" />
                            <asp:BoundField DataField="RoleName" HeaderText="RoleName" ConvertEmptyStringToNull="False">
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="applID" HeaderText="applID">
                                <ItemStyle HorizontalAlign="Left" Width="300px" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ApplicationName" HeaderText="Application Name">
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FromDate" HeaderText="FromDate" />
                            <asp:BoundField DataField="Action" HeaderText="Action" />
                            <asp:CommandField SelectText="Remove" ShowSelectButton="True" />
                        </Columns>
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <table style="position: static" width="200">
            <tr>
                <td style="height: 21px" colspan="2" width="200">
                    <asp:Button ID="btn_Save" runat="server" Style="position: static" Text="Save" Width="60px" OnClick="btn_Save_Click" OnClientClick="return validate();" SkinID="Normal"/>
                    <asp:Button ID="btnCancel" runat="server" Style="position: static" Text="Cancel" OnClick="btnCancel_Click" SkinID="Cancel" /></td>
            </tr>
        </table>
                </td>
            </tr>
        </table>
</asp:Content>

