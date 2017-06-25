<%@ Page Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master" AutoEventWireup="true" CodeFile="EmployeeLeaveDetails.aspx.cs" Inherits="MODULES_PMS_ReportForms_EmployeeLeaveDetails" Title="PMS | Employee Leave Details Report Form" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                Status
            </asp:Panel>
                
            <asp:UpdatePanel id="UpdatePanel3" runat="server">
                <contenttemplate>
                    <br />
                    <asp:Label ID="lblStatusMessage" runat="server" Height="19px" Text="Label"></asp:Label>
                </contenttemplate>
            </asp:UpdatePanel>
                <asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click" Width="58px" />    
             <br />
        </asp:Panel>
    <br />
    <asp:Label ID="Label7" runat="server" SkinID="UnicodeHeadlbl" Text="कर्मचारीले लिएका बिदाहरुको विवरण"></asp:Label><br />
    <br />
    <div id="upper" style="width: 938px; cursor: hand; height: 27px">
        कर्मचारी खोज्नुहोस्
    </div>
<table width="900" id="tblWrapper">
        <tr>
            <td>
                <asp:Panel ID="Panel3" runat="server" Width="900px">
                    <table width="900">
                        <tr>
                            <td style="height: 31px">
                                <asp:Label ID="Label30" runat="server" Font-Bold="False" SkinID="Unicodelbl" Text="संकेत नं"></asp:Label></td>
                            <td style="height: 31px; width: 206px;">
                                <asp:TextBox ID="txtSymbolNo" runat="server" SkinID="Unicodetxt" 
                                    Width="130px"></asp:TextBox></td>
                            <td style="height: 31px">
                            </td>
                            <td style="height: 31px; width: 196px;">
                            </td>
                            <td style="height: 31px">
                            </td>
                            <td style="height: 31px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Font-Bold="False" SkinID="Unicodelbl" Text="पहिलो नाम" Width="77px"></asp:Label></td>
                            <td style="width: 206px">
                                <asp:TextBox ID="txtFName" runat="server" MaxLength="35" SkinID="Unicodetxt" ToolTip="First Name"
                                    Width="130px"></asp:TextBox></td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Font-Bold="False" SkinID="Unicodelbl" Text="बिचको नाम"></asp:Label></td>
                            <td style="width: 196px">
                                <asp:TextBox ID="txtMName" runat="server" MaxLength="15" SkinID="Unicodetxt" Width="130px"></asp:TextBox></td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Font-Bold="False" Height="22px" SkinID="Unicodelbl"
                                    Text="थर"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtSurName" runat="server" MaxLength="35" SkinID="Unicodetxt" ToolTip="Surname"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="height: 28px">
                                <asp:Label ID="Label5" runat="server" Font-Bold="False" SkinID="Unicodelbl" Text="लिंग"></asp:Label></td>
                            <td style="height: 28px; width: 206px;">
                                <asp:DropDownList ID="ddlGender" runat="server" SkinID="Unicodeddl" Width="135px">
                                    <asp:ListItem Value="SG">छान्नुहोस</asp:ListItem>
                                    <asp:ListItem Value="M">पुरूष</asp:ListItem>
                                    <asp:ListItem Value="F">महिला</asp:ListItem>
                                    <asp:ListItem Value="O">अन्य</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="height: 28px">
                                <asp:Label ID="Label4" runat="server" Font-Bold="False" SkinID="Unicodelbl" Text="जन्म मिति"></asp:Label></td>
                            <td style="height: 28px; width: 196px;">
                                <asp:TextBox ID="txtDOB" runat="server" MaxLength="10" Width="130px"></asp:TextBox>&nbsp;
                            </td>
                            <td style="height: 28px">
                                <asp:Label ID="lblMaritalStatus" runat="server" Height="22px" SkinID="Unicodelbl"
                                    Text="बैबाहिक स्थिति" Width="114px"></asp:Label></td>
                            <td style="height: 28px">
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
                            <td style="height: 28px">
                                <asp:Label ID="lblOrganization" runat="server" SkinID="Unicodelbl" Text="कार्यालय"></asp:Label></td>
                            <td colspan="3" style="height: 28px">
                                <asp:DropDownList ID="ddlOrganization" runat="server" SkinID="Unicodeddl" Width="425px">
                                </asp:DropDownList></td>
                            <td style="height: 28px">
                                <asp:Label ID="lblDesignation" runat="server" SkinID="Unicodelbl" Text="पद"></asp:Label></td>
                            <td style="height: 28px">
                                <asp:DropDownList ID="ddlDesignation" runat="server" SkinID="Unicodeddl" Width="135px">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="height: 28px">
                            </td>
                            <td colspan="3" style="height: 28px">
                            </td>
                            <td style="height: 28px">
                            </td>
                            <td style="height: 28px">
                                <asp:Button ID="btnEmpSearch" runat="server" OnClick="btnEmpSearch_Click" Text="Search"
                                    Width="68px" SkinID="Normal" /><asp:Button ID="btnEmpSearchCancel" runat="server" OnClick="btnEmpSearchCancel_Click"
                                        Text="Cancel" Width="68px" SkinID="Cancel" /></td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <hr />
                                &nbsp;<asp:UpdatePanel id="UpdatePanel1" runat="server">
                                    <contenttemplate>
<asp:Label id="lblSearch" runat="server" Font-Bold="True" __designer:wfdid="w14"></asp:Label> <BR /><asp:Panel id="Panel1" runat="server" Width="890px" Height="150px" __designer:wfdid="w15" ScrollBars="Auto"><asp:GridView id="grdEmployee" runat="server" Width="890px" Height="150px" SkinID="Unicodegrd" __designer:wfdid="w16" OnRowCreated="grdEmployee_RowCreated" ForeColor="#333333" CellPadding="0" AutoGenerateColumns="False" OnSelectedIndexChanged="grdEmployee_SelectedIndexChanged">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="EMPID" HeaderText="EMPLOYEE ID"></asp:BoundField>
<asp:BoundField DataField="SYMBOLNO" HeaderText="संकेत नं"></asp:BoundField>
<asp:BoundField DataField="RDFULLNAME" HeaderText="पुरा नाम थर"></asp:BoundField>
<asp:BoundField DataField="RDGENDER" HeaderText="लिंग"></asp:BoundField>
<asp:BoundField DataField="DOB" HeaderText="जन्म मिति">
<ItemStyle Font-Names="Verdana"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="RDMARITALSTATUS" HeaderText="बैबाहिक सम्बन्ध"></asp:BoundField>
<asp:BoundField DataField="FATHERNAME" HeaderText="बाबुको नाम"></asp:BoundField>
<asp:BoundField DataField="GFATHERNAME" HeaderText="बबाजेको नाम"></asp:BoundField>
<asp:CommandField ShowSelectButton="True"></asp:CommandField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
</asp:GridView><BR /><BR /><BR /> 
<HR /></asp:Panel> <asp:Panel id="pnlSelection" runat="server" Width="500px" __designer:wfdid="w17"><TABLE><TBODY><TR><TD style="WIDTH: 91px; HEIGHT: 24px"><asp:Label id="Label6" runat="server" Text="Select Criteria" SkinID="Unicodelbl" __designer:wfdid="w18"></asp:Label></TD><TD style="HEIGHT: 24px"><asp:DropDownList id="ddlCriteria" runat="server" Width="317px" SkinID="Unicodeddl" __designer:wfdid="w19"><asp:ListItem Value="0">--छान्नुहोस्--</asp:ListItem>
<asp:ListItem Value="1">निवेदन दिएको तर सिफारिस हुनबाँकी</asp:ListItem>
<asp:ListItem Value="2">निवेदन दिएको तर सिफारिस नभएको</asp:ListItem>
<asp:ListItem Value="3">सिफारिस भएको तर स्विर्कत हुना बाँकी</asp:ListItem>
<asp:ListItem Value="4">सिफारिस भएको तर स्विर्कत नभएको</asp:ListItem>
<asp:ListItem Value="5">Approved</asp:ListItem>
</asp:DropDownList></TD></TR><TR><TD style="WIDTH: 91px"></TD><TD></TD></TR></TBODY></TABLE></asp:Panel> 
</contenttemplate>
<triggers>
<asp:PostBackTrigger ControlID="grdEmployee"></asp:PostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnEmpSearch" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
                                </asp:UpdatePanel>
                               <%-- <ajaxToolkit:CollapsiblePanelExtender ID="cpeDemo" runat="Server" CollapseControlID="Panel2"
                                    Collapsed="True" CollapsedImage="../../COMMON/Images/expand_blue.jpg" ExpandControlID="Panel2"
                                    ExpandedImage="../../COMMON/Images/collapse_blue.jpg" ImageControlID="Image1"
                                    SkinID="CollapsiblePanelDemo" SuppressPostBack="true" TargetControlID="Panel3"
                                    TextLabelID="Label1">
                            </ajaxtoolkit:collapsiblepanelextender>--%>
                            </td>
                        </tr>
                    </table>
                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" Mask="9999/99/99" MaskType="Date" runat="server" TargetControlID="txtDOB" AutoComplete="False">
                                </ajaxToolkit:MaskedEditExtender>
                </asp:Panel>
                <asp:Button ID="btnViewReport" runat="server" OnClick="btnViewReport_Click" SkinID="Normal"
                    Text="View Report" />
                <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" SkinID="Cancel"
                    Text="Cancel" /></td>
        </tr>
        </table>
</asp:Content>

