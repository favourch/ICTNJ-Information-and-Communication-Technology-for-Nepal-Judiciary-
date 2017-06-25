<%@ Page Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master" AutoEventWireup="true" CodeFile="EmployeeMedicalExpenses.aspx.cs" Inherits="MODULES_PMS_ReportForms_EmployeeMedicalExpenses" Title="PMS | Employee Medical Expenses" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager runat="server" ID="sct">
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
                Status
            </asp:Panel>
             <asp:UpdatePanel id="UpdatePanel3" runat="server">
                <contenttemplate>
<BR /><asp:Label id="lblStatusMessage" runat="server" Height="19px"></asp:Label> 
</contenttemplate>
            </asp:UpdatePanel>
                <asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click" Width="58px" />    
             <br />
        </asp:Panel>
    <br />
    <asp:Label ID="Label1" runat="server" SkinID="UnicodeHeadlbl" Text="औषधि खर्चको विवरण"></asp:Label><br />
    <br />
    <div id="upper" style="width: 938px; cursor: hand; height: 27px">
        कर्मचारी खोज्नुहोस्
    </div>
    <div id="lower" style="min-height:500px">
            <TABLE style="WIDTH: 900px"><TBODY><TR><TD style="WIDTH: 126px"><asp:Label id="lblSymbNo" runat="server" Width="110px" Height="22px" Text="संकेत नं" SkinID="Unicodelbl"></asp:Label></TD><TD><asp:TextBox id="txtSymbolNo" runat="server" Width="130px" SkinID="Unicodetxt" ToolTip="First Name" MaxLength="15"></asp:TextBox></TD><TD></TD><TD></TD><TD></TD><TD style="width: 147px"></TD></TR><TR><TD style="WIDTH: 126px"><asp:Label id="lblFirstName" runat="server" Width="92px" Height="22px" Text="पहिलो नाम" SkinID="Unicodelbl"></asp:Label></TD><TD><asp:TextBox id="txtFName" runat="server" Width="130px" SkinID="Unicodetxt" ToolTip="First Name" MaxLength="35"></asp:TextBox></TD><TD><asp:Label id="lblSecondName" runat="server" Width="92px" Height="22px" Text="बिचको नाम" SkinID="Unicodelbl"></asp:Label></TD><TD><asp:TextBox id="txtMName" runat="server" Width="130px" SkinID="Unicodetxt" MaxLength="15"></asp:TextBox></TD><TD><asp:Label id="lblLastName" runat="server" Width="27px" Height="22px" Text="थर" SkinID="Unicodelbl"></asp:Label></TD><TD style="width: 147px"><asp:TextBox id="txtSurName" runat="server" Width="130px" SkinID="Unicodetxt" ToolTip="Surname" MaxLength="35"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 126px"><asp:Label id="lblGender" runat="server" Width="41px" Height="22px" Text="लिंग" SkinID="Unicodelbl"></asp:Label></TD><TD><asp:DropDownList id="ddlGender" runat="server" Width="135px" SkinID="Unicodeddl">
                    <asp:ListItem Value="SG">छान्नुहोस</asp:ListItem>
                    <asp:ListItem Value="M">पुरुष</asp:ListItem>
                    <asp:ListItem Value="F">महिला</asp:ListItem>
                    <asp:ListItem Value="O">अन्य</asp:ListItem>
                </asp:DropDownList></TD><TD><asp:Label id="lblDOB" runat="server" Width="91px" Height="22px" Text="जन्म मिति" SkinID="Unicodelbl"></asp:Label></TD><TD><asp:TextBox id="txtDOB" runat="server" Width="130px" SkinID="Unicodetxt" MaxLength="10"></asp:TextBox></TD><TD><asp:Label id="lblMaritalStatus" runat="server" Width="114px" Height="22px" Text="बैबाहिक स्थिति" SkinID="Unicodelbl"></asp:Label></TD><TD style="width: 147px"><asp:DropDownList id="ddlMarStatus" runat="server" Width="135px" SkinID="Unicodeddl">
                    <asp:ListItem Value="SMS">छान्नुहोस</asp:ListItem>
                    <asp:ListItem Value="S">अबिबाहित</asp:ListItem>
                    <asp:ListItem Value="M">बिबाहित</asp:ListItem>
                    <asp:ListItem Value="W">बिधवा/बिदुर</asp:ListItem>
                    <asp:ListItem Value="D">छोडपत्र</asp:ListItem>
                    <asp:ListItem Value="O">अन्य</asp:ListItem>
                </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 126px; HEIGHT: 24px"><asp:Label id="lblOrganization" runat="server" Text="कार्यालय" SkinID="Unicodelbl"></asp:Label></TD><TD 
style="HEIGHT: 24px" colSpan=3><asp:DropDownList id="ddlOrganization" runat="server" Width="466px" SkinID="Unicodeddl">
                </asp:DropDownList></TD><TD style="HEIGHT: 24px"><asp:Label id="lblDesignation" runat="server" Text="पद" SkinID="Unicodelbl"></asp:Label></TD><TD 
style="HEIGHT: 24px; width: 147px;"><asp:DropDownList id="ddlDesignation" runat="server" Width="135px" SkinID="Unicodeddl">
                </asp:DropDownList></TD></TR>
                <tr>
                    <td style="width: 126px; height: 24px">
                    </td>
                    <td colspan="3" style="height: 24px">
                    </td>
                    <td style="height: 24px">
                    </td>
                    <td style="width: 147px; height: 24px">
                        <asp:Button id="btnSearch" onclick="btnSearch_Click" runat="server" Text="Search" SkinID="Normal"></asp:Button><asp:Button id="btnSearchCancel" onclick="btnSearchCancel_Click" runat="server" Text="Cancel" SkinID="Cancel"></asp:Button></td>
                </tr>
                <TR><TD colSpan=6>
<HR />
<asp:Label id="lblSearch" runat="server" Font-Bold="True"></asp:Label><BR /><BR /><asp:Panel id="Panel1" runat="server" Width="890px" Height="100px" ScrollBars="Auto"><asp:GridView id="grdEmployee" runat="server" Width="848px" SkinID="Unicodegrd" ForeColor="#333333" CellPadding="0" AutoGenerateColumns="False" OnSelectedIndexChanged="grdEmployee_SelectedIndexChanged" OnRowCreated="grdEmployee_RowCreated" Height="104px">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
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
<asp:BoundField DataField="DesName" HeaderText="पद"></asp:BoundField>
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
</asp:GridView>
</asp:Panel> 
                    <hr />
                </TD></TR>
                <tr>
                    <td colspan="6" style="height: 150px" valign="bottom">
                     <asp:Button ID="btnView" runat="server" OnClick="btnView_Click" SkinID="Normal" Text="View Report" /><asp:Button
                         ID="btnCancel" runat="server" OnClick="btnCancel_Click" SkinID="Cancel" Text="Cancel" /></td>
                </tr>
            </TBODY>
</TABLE>
</div>
</asp:Content>

