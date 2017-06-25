<%@ Page Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master" AutoEventWireup="true" CodeFile="OrganizationDesignation.aspx.cs" Inherits="MODULES_PMS_LookUp_OrganizationDesignation" Title="PMS | Post" %>

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
<script language="javascript" type="text/javascript" src="../../COMMON/JS/Validation.js" ></script>
<script language="javascript" src="../../COMMON/JS/DateValidator.js" type="text/javascript"></script>

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
    <table>
        <tr>
            <td valign="top">
                <asp:Label ID="Label3" runat="server" Text="कार्यालय" SkinID="Unicodelbl" Width="70px"></asp:Label></td>
            <td colspan="3" valign="top">
                <asp:DropDownList ID="ddlOrganization_Rqd" runat="server" Width="329px" SkinID="Unicodeddl" ToolTip="कार्यालय">
                </asp:DropDownList></td>
            <td valign="top">
                <asp:Label ID="Label1" runat="server" Text="पद" SkinID="Unicodelbl"></asp:Label></td>
            <td valign="top">
                <asp:DropDownList ID="ddlDesignation_Rqd" runat="server" Width="200px" SkinID="Unicodeddl" ToolTip="पद">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="Label2" runat="server" Text="सेवा" SkinID="Unicodelbl"></asp:Label></td>
            <td valign="top">
                <asp:DropDownList ID="ddlSewa_Rqd" runat="server" SkinID="Unicodeddl" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddlSewa_Rqd_SelectedIndexChanged" ToolTip="सेवा">
                </asp:DropDownList></td>
            <td valign="top">
                <asp:Label ID="Label4" runat="server" Text="समुह" SkinID="Unicodelbl" Width="43px"></asp:Label></td>
            <td valign="top">
                <asp:DropDownList ID="ddlSamuha_Rqd" runat="server" SkinID="Unicodeddl" Width="200px" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddlSamuha_Rqd_SelectedIndexChanged" ToolTip="समुह">
                </asp:DropDownList></td>
            <td valign="top">
                <asp:Label ID="Label7" runat="server" Text="उप-समुह" SkinID="Unicodelbl" Width="65px"></asp:Label></td>
            <td valign="top">
                <asp:DropDownList ID="ddlUpaSamuha_Rqd" runat="server" AppendDataBoundItems="True"
                    SkinID="Unicodeddl" ToolTip="उप-समुह" Width="200px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="Label6" runat="server" Text="श्रेणी" SkinID="Unicodelbl"></asp:Label></td>
            <td valign="top">
                <asp:DropDownList ID="ddlDesignationLevel_Rqd" runat="server" Width="118px" SkinID="Unicodeddl" ToolTip="श्रेणी">
                </asp:DropDownList></td>
            <td valign="top">
                <asp:Label ID="Label5" runat="server" Text="सख्या" SkinID="Unicodelbl" Width="45px"></asp:Label></td>
            <td valign="top">
                <asp:TextBox ID="txtTotalSeats_Rqd" runat="server" MaxLength="3" Width="39px" SkinID="Unicodetxt" ToolTip="जम्मा संख्या"></asp:TextBox><ajaxToolkit:filteredtextboxextender id="FilteredTextBoxExtender1" runat="server" filtertype="Numbers"
                    targetcontrolid="txtTotalSeats_Rqd"></ajaxToolkit:filteredtextboxextender>
            </td>
            <td valign="top">
                <asp:Label ID="Label8" runat="server" Text="मिति" SkinID="Unicodelbl"></asp:Label></td>
            <td valign="top">
                <asp:TextBox ID="txtCreatedDate_DT" runat="server" MaxLength="10" Width="89px" SkinID="Unicodetxt" ToolTip="मिति"></asp:TextBox>
                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AutoComplete="False"
                    Mask="9999/99/99" MaskType="Date" TargetControlID="txtCreatedDate_DT">
                </ajaxToolkit:MaskedEditExtender>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Button ID="btnCreatePost" runat="server" Text="Create Post" Width="75px" OnClick="btnCreatePost_Click" OnClientClick="javascript:return validate(1);" SkinID="Normal" /></td>
            <td valign="top">
            </td>
            <td valign="top">
            </td>
            <td valign="top">
            </td>
            <td valign="top">
            </td>
            <td>
            </td>
        </tr>
    </table>
    <br />
    <table style="width: 958px">
        <tr>
            <td style="width: 900px">
                
                <asp:Panel ID="pnlSearchDesignation" runat="server" Height="200px" ScrollBars="Auto" Width="100%">
                    <asp:GridView ID="grdOrgDesignation" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        ForeColor="#333333" GridLines="None" OnRowDataBound="grdOrgDesignation_RowDataBound"
                        OnSelectedIndexChanged="grdOrgDesignation_SelectedIndexChanged" SkinID="Unicodegrd"
                        Width="881px">
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="ORGID" HeaderText="OrgId" />
                            <asp:BoundField DataField="DESID" HeaderText="DesId" />
                            <asp:BoundField DataField="ORGNAME" HeaderText="कार्यालय" >
                            </asp:BoundField>
                            <asp:BoundField DataField="DESNAME" HeaderText="पद">
                                <HeaderStyle Width="20px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SEWANAME" HeaderText="सेवा" />
                            <asp:BoundField DataField="SAMUHANAME" HeaderText="समुह" />
                            <asp:BoundField DataField="UPASAMUHANAME" HeaderText="उप समुह" />
                            <asp:BoundField DataField="DESGLEVELNAME" HeaderText="श्रेणी" />
                            <asp:BoundField DataField="SEWAID" HeaderText="Sewa ID" />
                            <asp:BoundField DataField="SAMUHAID" HeaderText="Samuha ID" />
                            <asp:BoundField DataField="UPASAMUHAID" HeaderText="Upasamuha ID" />
                            <asp:BoundField DataField="DESGLEVELID" HeaderText="Desg Level ID" />
                            <asp:BoundField DataField="TotalSeats" HeaderText="सख्या" >
                                <ItemStyle Width="40px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CREATEDDATE" HeaderText="मिति" />
                            <asp:CommandField ShowSelectButton="True">
                                <ItemStyle Font-Names="Verdana" />
                            </asp:CommandField>
                        </Columns>
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <EditRowStyle BackColor="#999999" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                </asp:Panel>
            </td>

        </tr>
        <tr>
            <td>
                <asp:Panel ID="Panel2" runat="server" Height="150px" ScrollBars="Auto" Width="100%">
                    <asp:GridView ID="grdDesPost" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        ForeColor="#333333" GridLines="None" SkinID="Unicodegrd" Width="650px" OnRowDataBound="grdDesPost_RowDataBound">
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="ORGID" HeaderText="Org Id" />
                            <asp:BoundField DataField="DESID" HeaderText="Des Id" />
                            <asp:BoundField DataField="POSTID" HeaderText="Post Id" />
                            <asp:BoundField DataField="ORGNAME" HeaderText="कार्यालय" />
                            <asp:BoundField DataField="DESNAME" HeaderText="पद" />
                            <asp:TemplateField HeaderText="पद">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPostName" runat="server" SkinID="PCStxt" Text='<%# Eval("POSTNAME") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="पद">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtOldPostName" runat="server" SkinID="PCStxt" Text='<%# Eval("POSTNAME") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="OCCUPIED" HeaderText="Occupied" />
                            <asp:BoundField DataField="CREATEDDATE" HeaderText="मिति" />
                            <asp:TemplateField HeaderText="Delete">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkPostSelect" runat="server" Enabled='<%# Eval("RDUNOCCUPIEDPOST") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <EditRowStyle BackColor="#999999" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Width="60px" OnClientClick="javascript:return validate();" SkinID="Normal" /><asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel"
                    Width="60px" SkinID="Cancel" /></td>
        </tr>
    </table>
</asp:Content>

