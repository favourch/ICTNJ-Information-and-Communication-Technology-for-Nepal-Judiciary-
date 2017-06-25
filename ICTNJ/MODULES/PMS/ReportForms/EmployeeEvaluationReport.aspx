<%@ Page Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master" AutoEventWireup="true" CodeFile="EmployeeEvaluationReport.aspx.cs" Inherits="MODULES_PMS_ReportForms_EmployeeEvaluationReport" Title="PMS | Employee Evaluation Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="width:100%; height:700px">
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager><br />
        <asp:Label ID="Label3" runat="server" SkinID="UnicodeHeadlbl" Text="कर्मचारी मुल्यांकन विवरण"></asp:Label><br />
        <br />
        <div id="upper" style="width: 938px;
            cursor: hand; height: 27px">
            कर्मचारी खोज्नुहोस्
        </div>
        <asp:Panel ID="pnlEmployeeSearch" runat="server" Width="945px">
            <table style="width: 940px">
                <tr>
                    <td>
                        <asp:Label ID="Label30" runat="server" Font-Names="PCS NEPALI" Height="22px" SkinID="Unicodelbl" Text="संकेत नं" Width="110px"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtSymbolNo" runat="server" MaxLength="15" SkinID="Unicodetxt" ToolTip="First Name" Width="130px"></asp:TextBox></td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td style="width: 169px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label18" runat="server" Font-Names="PCS NEPALI" Height="22px" SkinID="Unicodelbl" Text="पहिलो नाम" Width="92px"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtFName" runat="server" MaxLength="35" SkinID="Unicodetxt" ToolTip="First Name" Width="130px"></asp:TextBox></td>
                    <td>
                        <asp:Label ID="Label19" runat="server" Font-Names="PCS NEPALI" Height="22px" SkinID="Unicodelbl" Text="बिचको नाम" Width="92px"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtMName" runat="server" MaxLength="15" SkinID="Unicodetxt" Width="130px"></asp:TextBox></td>
                    <td>
                        <asp:Label ID="Label20" runat="server" Font-Names="PCS NEPALI" Height="22px" SkinID="Unicodelbl" Text="थर" Width="92px"></asp:Label></td>
                    <td style="width: 169px">
                        <asp:TextBox ID="txtSurName" runat="server" MaxLength="35" SkinID="Unicodetxt" ToolTip="Surname" Width="130px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label21" runat="server" Font-Names="PCS NEPALI" Height="22px" SkinID="Unicodelbl" Text="लिंग" Width="92px"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddlGender" runat="server" SkinID="Unicodeddl" Width="135px">
                            <asp:ListItem Value="SG">छान्नुहोस</asp:ListItem>
                            <asp:ListItem Value="M">पुरुष</asp:ListItem>
                            <asp:ListItem Value="F">महिला</asp:ListItem>
                            <asp:ListItem Value="O">अन्य</asp:ListItem>
                        </asp:DropDownList></td>
                    <td>
                        <asp:Label ID="Label22" runat="server" Font-Names="PCS NEPALI" Height="22px" SkinID="Unicodelbl" Text="जन्म मिति" Width="110px"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtDOB" runat="server" MaxLength="10" SkinID="Unicodetxt" Width="130px"></asp:TextBox></td>
                    <td>
                        <asp:Label ID="Label23" runat="server" Font-Names="PCS NEPALI" Height="22px" SkinID="Unicodelbl" Text="बैबाहिक स्थिति" Width="114px"></asp:Label></td>
                    <td style="width: 169px">
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
                        <asp:Label ID="lblOrganization" runat="server" SkinID="Unicodelbl" Text="कार्यालय"></asp:Label></td>
                    <td colspan="3">
                        <asp:DropDownList ID="ddlOrganization" runat="server" SkinID="Unicodeddl" Width="466px">
                        </asp:DropDownList></td>
                    <td>
                        <asp:Label ID="lblDesignation" runat="server" SkinID="Unicodelbl" Text="पद"></asp:Label></td>
                    <td style="width: 169px">
                        <asp:DropDownList ID="ddlDesignation" runat="server" SkinID="Unicodeddl" Width="135px">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                        </td>
                    <td align="right">
                        </td>
                    <td style="width: 169px">
                        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" SkinID="Normal" />
                        <asp:Button ID="Button2" runat="server" OnClick="btnCancel_Click"
                            Text="Cancel" SkinID="Cancel" /></td>
                </tr>
                <tr>
                    <td colspan="6" style="height: 34px">
                        <hr />
                        <asp:UpdatePanel id="updSearch" runat="server">
                            <contenttemplate>
<asp:Label id="lblSearch" runat="server" Font-Bold="True" __designer:wfdid="w1"></asp:Label><asp:Panel id="pnlSearch" runat="server" Width="900px" Height="200px" ScrollBars="Auto" __designer:wfdid="w2"><asp:GridView id="grdEmployee" runat="server" Width="870px" SkinID="Unicodegrd" ForeColor="#333333" OnRowCreated="grdEmployee_RowCreated" OnSelectedIndexChanged="grdEmployee_SelectedIndexChanged" CellPadding="0" AutoGenerateColumns="False" __designer:wfdid="w3">
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
</asp:GridView></asp:Panel><asp:Label id="lblEmpName" runat="server" SkinID="UnicodeHeadlbl" __designer:wfdid="w4"></asp:Label><asp:Label id="lblComma" runat="server" SkinID="PCSHeadlbl" __designer:wfdid="w5"></asp:Label><asp:Label id="lblEmpID" runat="server" SkinID="UnicodeHeadlbl" __designer:wfdid="w6"></asp:Label> 
</contenttemplate>
                            <triggers>
<asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:PostBackTrigger ControlID="grdEmployee"></asp:PostBackTrigger>
</triggers>
                        </asp:UpdatePanel><asp:Panel ID="pnlEvaluationList" runat="server" Width="910px" Height="300px" ScrollBars="Auto">
                            <asp:DataList ID="dlstEvaluation" runat="server" CaptionAlign="Left" RepeatColumns="1">
                                <ItemTemplate>
                                    <table width="650">
                                        <tr>
                                            <td style="width: 650px; height: 28px">
                                                <asp:Label ID="Label35" runat="server" SkinID="Unicodelbl" Text="कर्मचारी नं:: "></asp:Label>
                                                <asp:Label ID="lblDlstEmpID" runat="server" SkinID="Unicodelbl" Text='<%# Eval("EmpID") %>'></asp:Label>&nbsp;|
                                                <asp:Label ID="Label37" runat="server" SkinID="Unicodelbl" Text="मुल्यंकन मिति देखि::"></asp:Label>
                                                <asp:Label ID="Label36" runat="server" SkinID="Unicodelbl" Text='<%# Eval("EvalFromDate") %>'></asp:Label>
                                                &nbsp;|
                                                <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="सम्म::"></asp:Label>
                                                <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text='<%# Eval("EvalToDate") %>'></asp:Label>
                                                &nbsp; &nbsp; &nbsp;&nbsp;
                                                <asp:LinkButton ID="lnkSelectEvaluation" runat="server" CommandArgument='<%# Eval("EmpID") %>' CommandName='<%# Eval("EvalFromDate")+":"+Eval("EvalToDate") %>' Font-Names="Verdana"
                                                    Font-Size="15px" OnClick="lnkSelectEvaluation_Click" SkinID="AA">रिर्पट हर्नुहोस</asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:DataList></asp:Panel>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
        <ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior"
            DropShadow="True" PopupControlID="programmaticPopup" PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
            TargetControlID="hiddenTargetControlForModalPopup">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="padding-right: 10px; display: none; padding-left: 10px; padding-bottom: 10px;
            width: 350px; padding-top: 10px">
            <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="border-right: gray 1px solid; border-top: gray 1px solid; border-left: gray 1px solid;
                cursor: move; color: black; border-bottom: gray 1px solid; background-color: #dddddd; text-align: center">
                Save Status
            </asp:Panel>
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label><br />
            <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click" Text="OK" Width="58px" />
            <br />
        </asp:Panel>
    </div>
</asp:Content>

