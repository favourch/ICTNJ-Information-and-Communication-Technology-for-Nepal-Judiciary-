<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PersonnelSearchControl.ascx.cs" Inherits="MODULES_COMMON_UserControls_PersonnelSearchControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground"
    BehaviorID="programmaticModalPopupBehavior" DropShadow="True" PopupControlID="programmaticPopup"
    PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
    TargetControlID="hiddenTargetControlForModalPopup">
</ajaxToolkit:ModalPopupExtender>
<asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none;
    width: 350px; padding: 10px">
    <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD;
        border: solid 1px Gray; color: Black; text-align: center;">
        Status
    </asp:Panel>
    <contenttemplate></contenttemplate>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
            <br />
            <asp:Label ID="lblStatusMessage" runat="server" Height="19px" Text="Label"></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
        Text="OK" Width="58px" />
    <br />
</asp:Panel>
<table style="width: 939px">
    <tr>
        <td>
            <asp:Label ID="Label30" runat="server" Height="22px" SkinID="Unicodelbl" Text="संकेत नं"
                Width="110px"></asp:Label></td>
        <td>
            <asp:TextBox ID="txtSymbolNo" runat="server" MaxLength="15" SkinID="Unicodetxt" ToolTip="First Name"
                Width="130px"></asp:TextBox></td>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Height="22px" SkinID="Unicodelbl" Text="पहिलो नाम"
                Width="92px"></asp:Label></td>
        <td>
            <asp:TextBox ID="txtFName" runat="server" MaxLength="35" SkinID="Unicodetxt" ToolTip="First Name"
                Width="130px"></asp:TextBox></td>
        <td>
            <asp:Label ID="Label2" runat="server" Height="22px" SkinID="Unicodelbl" Text="बिचको नाम"
                Width="92px"></asp:Label></td>
        <td>
            <asp:TextBox ID="txtMName" runat="server" MaxLength="15" SkinID="Unicodetxt" Width="130px"></asp:TextBox></td>
        <td>
            <asp:Label ID="Label3" runat="server" Height="22px" SkinID="Unicodelbl" Text="थर"
                Width="92px"></asp:Label></td>
        <td>
            <asp:TextBox ID="txtSurName" runat="server" MaxLength="35" SkinID="Unicodetxt" ToolTip="Surname"
                Width="130px"></asp:TextBox></td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label5" runat="server" Height="22px" SkinID="Unicodelbl" Text="लिंग"
                Width="92px"></asp:Label></td>
        <td>
            <asp:DropDownList ID="ddlGender" runat="server" SkinID="Unicodeddl" Width="135px">
                <asp:ListItem Value="SG">छान्नुहोस</asp:ListItem>
                <asp:ListItem Value="M">पुरुष</asp:ListItem>
                <asp:ListItem Value="F">महिला</asp:ListItem>
                <asp:ListItem Value="O">अन्य</asp:ListItem>
            </asp:DropDownList></td>
        <td>
            <asp:Label ID="Label4" runat="server" Height="22px" SkinID="Unicodelbl" Text="जन्म मिति"
                Width="110px"></asp:Label></td>
        <td>
            <asp:TextBox ID="txtDOB" runat="server" MaxLength="10" SkinID="Unicodetxt" Width="130px"></asp:TextBox></td>
        <td>
            <asp:Label ID="Label6" runat="server" Height="22px" SkinID="Unicodelbl" Text="बैबाहिक सम्बन्ध"
                Width="114px"></asp:Label></td>
        <td>
            <asp:DropDownList ID="ddlMarStatus" runat="server" SkinID="Unicodeddl" Width="135px">
                <asp:ListItem Value="SMS">छान्नुहोस</asp:ListItem>
                <asp:ListItem Value="S">अबिबाहित</asp:ListItem>
                <asp:ListItem Value="M">बिबाहित</asp:ListItem>
                <asp:ListItem Value="W">बिधवा/बिदुर</asp:ListItem>
                <asp:ListItem Value="D">छोडपत्र</asp:ListItem>
                <asp:ListItem Value="O">अन्य</asp:ListItem>
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label7" runat="server" SkinID="Unicodelbl" Text="कार्यालय"></asp:Label></td>
        <td colspan="3">
            <asp:DropDownList ID="ddlOrganization" runat="server" SkinID="Unicodeddl" Width="478px">
            </asp:DropDownList></td>
        <td>
            <asp:Label ID="lblDesignation" runat="server" SkinID="Unicodelbl" Text="पद"></asp:Label></td>
        <td>
            <asp:DropDownList ID="ddlDesignation" runat="server" SkinID="Unicodeddl" Width="135px">
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td align="left" colspan="6">
            <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" SkinID="Normal"
                Text="Search" /><asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click"
                    SkinID="Cancel" Text="Cancel" /></td>
    </tr>
    <tr>
        <td colspan="6">
            <hr />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Label ID="lblSearch" runat="server" Font-Bold="True"></asp:Label><br />
                    <asp:Panel ID="Panel1" runat="server" Height="250px" Width="100%">
                        <asp:GridView ID="grdEmployee" runat="server" AutoGenerateColumns="False" CellPadding="0"
                            ForeColor="#333333" OnRowCreated="grdEmployee_RowCreated" OnRowDataBound="grdEmployee_RowDataBound"
                            OnRowEditing="grdEmployee_RowEditing" OnSelectedIndexChanged="grdEmployee_SelectedIndexChanged"
                            SkinID="Unicodegrd" Width="848px">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="EMPID" HeaderText="आई डी" />
                                <asp:BoundField DataField="SYMBOLNO" HeaderText="संकेत नं." />
                                <asp:BoundField DataField="FIRSTNAME" HeaderText="पहिलो नाम" />
                                <asp:BoundField DataField="MIDDLENAME" HeaderText="बिचको नाम" />
                                <asp:BoundField DataField="SURNAME" HeaderText="थर" />
                                <asp:BoundField DataField="RDFULLNAME" HeaderText="पुरा नाम थर" />
                                <asp:BoundField DataField="RDGENDER" HeaderText="लिंग" />
                                <asp:BoundField DataField="DOB" HeaderText="जन्म मिति">
                                    <ItemStyle Font-Names="Verdana" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RDMARITALSTATUS" HeaderText="बैबाहिक सम्बन्ध" />
                                <asp:CommandField ShowSelectButton="True">
                                    <ItemStyle Font-Names="Verdana" />
                                </asp:CommandField>
                                <asp:CommandField EditText="सम्पत्ति विवरण" SelectText="" ShowEditButton="True">
                                    <ItemStyle Font-Names="Verdana" />
                                </asp:CommandField>
                                <asp:BoundField DataField="DesName" />
                            </Columns>
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <EditRowStyle BackColor="#999999" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
                    </asp:Panel>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="grdEmployee" />
                    <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </td>
    </tr>
</table>
