<%@ Page Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master" AutoEventWireup="true" CodeFile="EmployeeSearch.aspx.cs" Inherits="MODULES_PMS_Forms_EmployeeSearch" Title="PMS | Employee Search" %>
<%@ Register 
    Assembly="AjaxControlToolkit" 
    Namespace="AjaxControlToolkit" 
    TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" style="display:none"/>
                 <asp:ScriptManager id="ScriptManager1" runat="server">
                </asp:ScriptManager>
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
                Status
            </asp:Panel>
                <contenttemplate></contenttemplate>
            <asp:UpdatePanel id="UpdatePanel3" runat="server">
                <contenttemplate>
            <br />
                    <asp:Label ID="lblStatusMessage" runat="server" Height="19px" Text="Label"></asp:Label>
                </contenttemplate>
            </asp:UpdatePanel>
<asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click" Width="58px" />           <br />
        </asp:Panel>
    &nbsp;<br />
    &nbsp; &nbsp; &nbsp;<asp:Label ID="Label8" runat="server" SkinID="UnicodeHeadlbl" Text="कर्मचारीको खोजी"></asp:Label><br />
    <br />
    <table style="width: 939px;">
        <tr>
            <td style="width: 19px">
            </td>
            <td>
                <asp:Label ID="Label30" runat="server" Height="22px" SkinID="Unicodelbl"
                    Text="संकेत नं" Width="110px"></asp:Label></td>
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
            <td style="width: 19px">
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Height="22px" SkinID="Unicodelbl"
                    Text="पहिलो नाम" Width="92px"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtFName" runat="server" MaxLength="35" SkinID="Unicodetxt" ToolTip="First Name"
                    Width="130px"></asp:TextBox></td>
            <td>
                <asp:Label ID="Label2" runat="server" Height="22px" SkinID="Unicodelbl"
                    Text="बिचको नाम" Width="92px"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtMName" runat="server" MaxLength="15" SkinID="Unicodetxt" Width="130px"></asp:TextBox></td>
            <td>
                <asp:Label ID="Label3" runat="server" Height="22px" SkinID="Unicodelbl"
                    Text="थर" Width="92px"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtSurName" runat="server" MaxLength="35" SkinID="Unicodetxt" ToolTip="Surname"
                    Width="130px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 19px">
            </td>
            <td>
                <asp:Label ID="Label5" runat="server" Height="22px" SkinID="Unicodelbl"
                    Text="लिंग" Width="92px"></asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlGender" runat="server" SkinID="Unicodeddl" Width="135px">
                    <asp:ListItem Value="SG">छान्नुहोस</asp:ListItem>
                    <asp:ListItem Value="M">पुरुष</asp:ListItem>
                    <asp:ListItem Value="F">महिला</asp:ListItem>
                    <asp:ListItem Value="O">अन्य</asp:ListItem>
                </asp:DropDownList></td>
            <td>
                <asp:Label ID="Label4" runat="server" Height="22px" SkinID="Unicodelbl"
                    Text="जन्म मिति" Width="110px"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtDOB" runat="server" MaxLength="10" SkinID="Unicodetxt" Width="130px"></asp:TextBox></td>
            <td>
                <asp:Label ID="Label6" runat="server" Height="22px" SkinID="Unicodelbl"
                    Text="बैबाहिक स्थिति" Width="114px"></asp:Label></td>
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
            <td style="width: 19px">
            </td>
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
            <td style="width: 19px">
            </td>
            <td>
            </td>
            <td colspan="3">
                <asp:RadioButtonList ID="rdblstPosting" runat="server" RepeatDirection="Horizontal"
                    SkinID="Unicoderadio" Width="331px">
                    <asp:ListItem Value="Y">नियुक्ती भएको</asp:ListItem>
                    <asp:ListItem Value="N">नियुक्ती नभएको</asp:ListItem>
                </asp:RadioButtonList></td>
            <td>
            </td>
            <td>
                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" SkinID="Normal" /><asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click"
                        Text="Cancel" SkinID="Cancel" /></td>
        </tr>
        <tr>
            <td align="left" colspan="1" style="width: 19px">
            </td>
            <td align="left" colspan="6">
                </td>
        </tr>
        <tr>
            <td colspan="1" style="width: 19px">
            </td>
            <td colspan="6">
                <hr />
                <asp:UpdatePanel id="UpdatePanel1" runat="server">
                    <contenttemplate>
<asp:Label id="lblSearch" runat="server" Font-Bold="True"></asp:Label><BR /><asp:Panel id="Panel1" runat="server" Width="900px" Height="300px" ScrollBars="Auto"><asp:GridView id="grdEmployee" runat="server" Width="848px" SkinID="Unicodegrd" ForeColor="#333333" OnSelectedIndexChanged="grdEmployee_SelectedIndexChanged" CellPadding="0" AutoGenerateColumns="False" OnRowDataBound="grdEmployee_RowDataBound" OnRowEditing="grdEmployee_RowEditing">
<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
<asp:BoundField DataField="EMPID" HeaderText="आई डी"></asp:BoundField>
<asp:BoundField DataField="SYMBOLNO" HeaderText="संकेत नं."></asp:BoundField>
<asp:BoundField DataField="FIRSTNAME" HeaderText="पहिलो नाम"></asp:BoundField>
<asp:BoundField DataField="MIDDLENAME" HeaderText="बिचको नाम"></asp:BoundField>
<asp:BoundField DataField="SURNAME" HeaderText="थर"></asp:BoundField>
<asp:BoundField DataField="RDFULLNAME" HeaderText="पुरा नाम थर"></asp:BoundField>
<asp:BoundField DataField="RDGENDER" HeaderText="लिंग"></asp:BoundField>
<asp:BoundField DataField="DOB" HeaderText="जन्म मिति">
<ItemStyle Font-Names="Verdana"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="RDMARITALSTATUS" HeaderText="बैबाहिक सम्बन्ध"></asp:BoundField>
<asp:BoundField DataField="FATHERNAME" HeaderText="पिताको नाम"></asp:BoundField>
<asp:BoundField DataField="GFATHERNAME" HeaderText="बाजेको नाम"></asp:BoundField>
<asp:CommandField ShowSelectButton="True">
<ItemStyle Font-Names="Verdana"></ItemStyle>
</asp:CommandField>
<asp:CommandField EditText="सम्पति विवरण" SelectText="" ShowEditButton="True">
<ItemStyle Font-Names="Verdana"></ItemStyle>
</asp:CommandField>
<asp:BoundField DataField="DesName"></asp:BoundField>
</Columns>

<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView></asp:Panel> 
</contenttemplate>
                    <triggers>
<asp:PostBackTrigger ControlID="grdEmployee"></asp:PostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
                </asp:UpdatePanel></td>
        </tr>
    </table>
</asp:Content>

