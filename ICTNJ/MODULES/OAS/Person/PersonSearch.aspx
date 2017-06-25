<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true" CodeFile="PersonSearch.aspx.cs" Inherits="MODULES_OAS_Person_PersonSearch" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="width:100px; height:auto">
        <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <ajaxtoolkit:modalpopupextender id="programmaticModalPopup" runat="server" backgroundcssclass="modalBackground" behaviorid="programmaticModalPopupBehavior"
            dropshadow="True" popupcontrolid="programmaticPopup" popupdraghandlecontrolid="programmaticPopupDragHandle" repositionmode="RepositionOnWindowScroll"
            targetcontrolid="hiddenTargetControlForModalPopup"></ajaxtoolkit:modalpopupextender>
        <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="padding-right: 10px; display: none; padding-left: 10px; padding-bottom: 10px;
            width: 350px; padding-top: 10px">
            <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="border-right: gray 1px solid; border-top: gray 1px solid; border-left: gray 1px solid;
                cursor: move; color: black; border-bottom: gray 1px solid; background-color: #dddddd; text-align: center">
                Status
            </asp:Panel>
            <contenttemplate>
</contenttemplate>
            <asp:UpdatePanel id="UpdatePanel3" runat="server">
                <contenttemplate>
<BR /><asp:Label id="lblStatusMessage" runat="server" Height="19px" Text="Label"></asp:Label> 
</contenttemplate>
            </asp:UpdatePanel>
            <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click" Text="OK" Width="58px" />
            <br />
        </asp:Panel>
        <br />
        <table style="width: 939px">
            <tr>
                <td>
                    <asp:Label ID="Label30" runat="server" Height="22px" SkinID="Unicodelbl" Text="संकेत नं" Width="110px"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtSymbolNo" runat="server" MaxLength="15" SkinID="Unicodetxt" ToolTip="First Name" Width="130px"></asp:TextBox></td>
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
                    <asp:Label ID="Label1" runat="server" Height="22px" SkinID="Unicodelbl" Text="पहिलो नाम" Width="92px"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtFName" runat="server" MaxLength="35" SkinID="Unicodetxt" ToolTip="First Name" Width="130px"></asp:TextBox></td>
                <td>
                    <asp:Label ID="Label2" runat="server" Height="22px" SkinID="Unicodelbl" Text="बिचको नाम" Width="92px"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtMName" runat="server" MaxLength="15" SkinID="Unicodetxt" Width="130px"></asp:TextBox></td>
                <td>
                    <asp:Label ID="Label3" runat="server" Height="22px" SkinID="Unicodelbl" Text="थर" Width="92px"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtSurName" runat="server" MaxLength="35" SkinID="Unicodetxt" ToolTip="Surname" Width="130px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Height="22px" SkinID="Unicodelbl" Text="लिंग" Width="92px"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddlGender" runat="server" SkinID="Unicodeddl" Width="135px">
                        <asp:ListItem Value="SG">छान्नुहोस</asp:ListItem>
                        <asp:ListItem Value="M">पुरुष</asp:ListItem>
                        <asp:ListItem Value="F">महिला</asp:ListItem>
                        <asp:ListItem Value="O">अन्य</asp:ListItem>
                    </asp:DropDownList></td>
                <td>
                    <asp:Label ID="Label4" runat="server" Height="22px" SkinID="Unicodelbl" Text="जन्म मिति" Width="110px"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtDOB" runat="server" MaxLength="10" SkinID="Unicodetxt" Width="130px"></asp:TextBox></td>
                <td>
                    <asp:Label ID="Label6" runat="server" Height="22px" SkinID="Unicodelbl" Text="बैबाहिक सम्बन्ध" Width="114px"></asp:Label></td>
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
                    <asp:DropDownList ID="ddlOrganization" runat="server" SkinID="Unicodeddl" Width="478px" AutoPostBack="True" OnSelectedIndexChanged="ddlOrganization_SelectedIndexChanged">
                    </asp:DropDownList></td>
                <td>
                    <asp:Label ID="lblDesignation" runat="server" SkinID="Unicodelbl" Text="पद"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddlDesignation" runat="server" SkinID="Unicodeddl" Width="135px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" SkinID="Unicodelbl" Text="कमिटि"></asp:Label></td>
                <td>
                    <asp:UpdatePanel id="UpdatePanel2" runat="server">
                        <contenttemplate>
<asp:DropDownList id="ddlCommittee" runat="server" Width="135px"></asp:DropDownList>
</contenttemplate>
                        <triggers>
<asp:AsyncPostBackTrigger ControlID="ddlOrganization" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:Label ID="Label9" runat="server" Height="22px" SkinID="Unicodelbl" Text="कमिटिको पद" Width="110px"></asp:Label></td>
                <td colspan="2">
                    <asp:DropDownList ID="ddlCommitteePost" runat="server" Width="220px">
                    </asp:DropDownList></td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="6">
                    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" SkinID="Normal" Text="Search" />
                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click"
                        SkinID="Cancel" Text="Cancel" /><ajaxToolkit:MaskedEditExtender ID="MSKdob" runat="server" TargetControlID="txtDOB" AutoComplete="False" Mask="9999/99/99" MaskType="Date"></ajaxToolkit:MaskedEditExtender>
                </td>
            </tr>
        </table>
        
    </div>
    <hr />
                    <asp:UpdatePanel id="UpdatePanel1" runat="server">
                        <contenttemplate>
<asp:Label id="lblSearch" runat="server" SkinID="Unicodelbl" Font-Bold="True" __designer:wfdid="w2"></asp:Label><BR /><asp:Panel id="Panel1" runat="server" Width="100%" Height="350px" ScrollBars="Auto" __designer:wfdid="w3"><asp:GridView id="grdEmployee" runat="server" Width="100%" SkinID="Unicodegrd" OnSelectedIndexChanged="grdEmployee_SelectedIndexChanged" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333" OnRowDataBound="grdEmployee_RowDataBound" OnDataBound="grdEmployee_DataBound" __designer:wfdid="w4">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="PersonID" HeaderText="आई डी"></asp:BoundField>
<asp:BoundField DataField="RDFULLNAME" HeaderText="पुरा नाम थर"></asp:BoundField>
<asp:BoundField DataField="RDGENDER" HeaderText="लिंग"></asp:BoundField>
<asp:BoundField DataField="DOB" HeaderText="जन्म मिति">
<ItemStyle Font-Names="Verdana"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="RDMARITALSTATUS" HeaderText="बैबाहिक सम्बन्ध"></asp:BoundField>
<asp:BoundField DataField="District" HeaderText="जन्म स्थान"></asp:BoundField>
<asp:BoundField DataField="IniType" HeaderText="कार्यालय"></asp:BoundField>
<asp:BoundField DataField="PostName" HeaderText="पद"></asp:BoundField>
<asp:BoundField DataField="GroupName" HeaderText="कमिटि"></asp:BoundField>
<asp:BoundField DataField="GMPositionName" HeaderText="पद"></asp:BoundField>
<asp:CommandField ShowSelectButton="True">
<ItemStyle Font-Names="Verdana"></ItemStyle>
</asp:CommandField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> </asp:Panel> 
</contenttemplate>
                        <triggers>
<asp:PostBackTrigger ControlID="grdEmployee"></asp:PostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
                    </asp:UpdatePanel>
</asp:Content>

