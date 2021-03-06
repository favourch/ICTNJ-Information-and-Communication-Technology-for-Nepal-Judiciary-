<%@ Page Language="C#" MasterPageFile="~/MODULES/LJMS/LJMSMasterPage.master" AutoEventWireup="true" CodeFile="LeaveTypeJudge.aspx.cs" Inherits="MODULES_LJMS_LookUp_LeaveTypeJudge" Title="LJMS | Judgewise Leave" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
<asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
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
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
        <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
            Text="OK" Width="58px" />
        <br />
    </asp:Panel>
                                                <br />
    <br />
    <asp:Panel ID="pnlCol" runat="server" CssClass="collapsePanelHeader" Height="25px"
        Width="945px">
        कर्मचारी खोज्नुहोस</asp:Panel>
    <ajaxToolkit:CollapsiblePanelExtender ID="colEmployee" runat="server" CollapseControlID="pnlCol"
        Collapsed="True" CollapsedImage="../../COMMON/Images/expand_blue.jpg" ExpandControlID="pnlCol"
        ExpandedImage="../../COMMON/Images/collapse_blue.jpg" ImageControlID="imgCol"
        SkinID="CollapsiblePanelDemo" SuppressPostBack="True" TargetControlID="pnlEmployeeSearch">
    </ajaxToolkit:CollapsiblePanelExtender>
    <asp:Panel ID="pnlEmployeeSearch" runat="server" CssClass="collapsePanel" Width="945px">
        &nbsp;<table style="width: 950px">
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
                    <asp:DropDownList ID="ddlSearchGender" runat="server" SkinID="Unicodeddl" Width="135px">
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
                        Text="Search" /><asp:Button ID="btnSearchCancel" runat="server" OnClick="btnCancel_Click"
                            SkinID="Cancel" Text="Cancel" /></td>
            </tr>
            <tr>
                <td colspan="6" style="height: 306px">
                    <hr />
                    <asp:Label ID="lblSearch" runat="server" Font-Bold="True"></asp:Label><br />
                    <asp:Panel ID="Panel1" runat="server" Height="250px" Width="100%">
                        <asp:GridView ID="grdEmployee" runat="server" AutoGenerateColumns="False" CellPadding="0"
                            ForeColor="#333333" OnRowDataBound="grdEmployee_RowDataBound" OnSelectedIndexChanged="grdEmployee_SelectedIndexChanged"
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
                                <asp:BoundField DataField="FATHERNAME" HeaderText="पिताको नाम" />
                                <asp:BoundField DataField="GFATHERNAME" HeaderText="बाजेको नाम" />
                                <asp:BoundField DataField="DesName" HeaderText="पद" />
                                <asp:CommandField ShowSelectButton="True">
                                    <ItemStyle Font-Names="Verdana" />
                                </asp:CommandField>
                            </Columns>
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <EditRowStyle BackColor="#999999" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <hr />
    <br />
    <asp:Panel runat="server" ID="pnlContent" >
    <table style="width: 800px">
        <tr>
            <td style="width: 130px" valign="top">
                <asp:Label ID="lblEmployee" runat="server" Text="कर्मचारी" SkinID="Unicodelbl"></asp:Label></td>
            <td style="width: 220px" valign="top">
                <asp:TextBox ID="txtEmployee" runat="server" MaxLength="3" ReadOnly="True" SkinID="Unicodetxt" Width="195px"></asp:TextBox></td>
            <td style="width: 120px" valign="top">
                <asp:Label ID="lblLeaveType" runat="server" Text="बिदाको कसिम" SkinID="Unicodelbl" Width="107px"></asp:Label></td>
            <td valign="top">
                <asp:DropDownList ID="ddlLeaveTypes" runat="server" SkinID="Unicodeddl" Width="200px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 130px" valign="top">
                <asp:Label ID="lblDurationType" runat="server" Text="अवधिको किसिम" SkinID="Unicodelbl" Width="120px"></asp:Label></td>
            <td colspan="3" valign="top">
                <asp:RadioButtonList ID="rdblstPeriodTypes"  runat="server" RepeatDirection="Horizontal" AutoPostBack="true" SkinID="Unicoderadio" Width="525px" OnSelectedIndexChanged="rdblstPeriodTypes_SelectedIndexChanged">
                    <asp:ListItem Value="M">मासिक</asp:ListItem>
                    <asp:ListItem Value="Q">त्रैमासिक</asp:ListItem>
                    <asp:ListItem Value="H">अर्ध बार्षिक</asp:ListItem>
                    <asp:ListItem Value="Y">बार्षिक</asp:ListItem>
                    <asp:ListItem Value="O">अन्य</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td style="width: 130px" valign="top">
                <asp:Label ID="lblLeaveDuration" runat="server" Text="बिदाको अवधि" SkinID="Unicodelbl" Width="103px"></asp:Label></td>
            <td style="width: 220px" valign="top">
                <asp:TextBox ID="txtDays" runat="server" MaxLength="3" ReadOnly="True" SkinID="Unicodetxt" Width="30px"></asp:TextBox><ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterMode="ValidChars"  FilterType="Numbers" TargetControlID="txtDays">
                </ajaxToolkit:FilteredTextBoxExtender>
            </td>
            <td style="width: 120px" valign="top">
                <asp:Label ID="lblTimes" runat="server" Text="अवधि पटक" SkinID="Unicodelbl"></asp:Label></td>
            <td valign="top">
                <asp:TextBox ID="txtPeriodTimes" runat="server" SkinID="Unicodetxt" Width="30px"></asp:TextBox><ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterMode="ValidChars"  FilterType="Numbers" TargetControlID="txtPeriodTimes">
                </ajaxToolkit:FilteredTextBoxExtender>
            </td>
        </tr>        
        <tr>
            <td style="width: 130px" valign="top">
                <asp:Label ID="lblAccural" runat="server" Text="जम्मा हुने ?" SkinID="Unicodelbl"></asp:Label></td>
            <td style="width: 220px" valign="top">
                <asp:CheckBox ID="chkIsAccural" runat="server" BorderStyle="None" AutoPostBack="True" Checked="True" OnCheckedChanged="chkIsAccural_CheckedChanged" SkinID="smallChk" /></td>
            <td style="width: 120px" valign="top">
                <asp:Label ID="lblAccuralDays" runat="server" Text="जम्मा हुने दिन" SkinID="Unicodelbl" Width="109px"></asp:Label></td>
            <td valign="top">
                <asp:TextBox ID="txtAccuralDays" runat="server" SkinID="Unicodetxt" Width="30px"></asp:TextBox><ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterMode="ValidChars"  FilterType="Numbers" TargetControlID="txtAccuralDays">
                </ajaxToolkit:FilteredTextBoxExtender>
            </td>
        </tr>
        <tr>
            <td style="width: 130px" valign="top">
                <asp:Label ID="lblFrom" runat="server" Text="अवधि देखि" SkinID="Unicodelbl" Width="100px"></asp:Label></td>
            <td style="width: 220px" valign="top">
                <asp:TextBox ID="txtEffectiveFrom" runat="server" SkinID="Unicodetxt" Width="90px"></asp:TextBox><ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" MaskType="Date" Mask="9999/99/99" runat="server" TargetControlID="txtEffectiveFrom" AutoComplete="False">
                </ajaxToolkit:MaskedEditExtender>
            </td>
            <td style="width: 120px" valign="top">
                <asp:Label ID="lblActive" runat="server" Text="सक्रिय" SkinID="Unicodelbl"></asp:Label></td>
            <td valign="top">
                <asp:CheckBox ID="chkIsActive" runat="server" Checked="True" SkinID="smallChk" /></td>
        </tr>
        <tr>
            <td style="width: 130px" valign="top">
                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" OnClientClick="javascript:return ValidatePage();"  Text="+" SkinID="Add" /></td>
            <td style="width: 220px" valign="top">
            </td>
            <td style="width: 120px" valign="top">
            </td>
            <td valign="top">
            </td>
        </tr>
    </table>
    </asp:Panel>
    <br />
    <table style="width: 800px">
        <tr>
            <td style="width: 100px" valign="top">
                <asp:Panel ID="Panel4" runat="server" Height="150px" ScrollBars="Auto" Width="795px">
                <asp:GridView ID="grdLeaveDetails" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="grdLeaveDetails_SelectedIndexChanged" OnRowDataBound="grdLeaveDetails_RowDataBound">
                    <Columns>
                        <asp:BoundField HeaderText="LeaveTypeID" DataField="LeaveTypeID" />
                        <asp:BoundField DataField="LeaveType" HeaderText="बिदाको कसिम" />
                        <asp:BoundField DataField="EmpID" HeaderText="EmpID" />
                        <asp:BoundField DataField="Days" HeaderText="बिदाको अवधि" />
                        <asp:BoundField DataField="PeriodType" HeaderText="अवधिको कसिम" />
                        <asp:BoundField DataField="PeriodTimes" HeaderText="Period Times" />
                        <asp:BoundField DataField="IsAccural" HeaderText="Is Accural" />
                        <asp:BoundField DataField="AccuralDays" HeaderText="Accural Days" />
                        <asp:BoundField DataField="EffectiveFromDate" HeaderText="लागु हुने मिति" />
                        <asp:BoundField DataField="EffectiveTillDate" HeaderText="Effective Till Date" />
                        <asp:BoundField DataField="Active" HeaderText="Is Active" />
                        <asp:BoundField DataField="EntryBy" HeaderText="Entry By" />
                        <asp:BoundField DataField="EntryDate" HeaderText="Entry Date" />
                        <asp:BoundField DataField="Action" HeaderText="Action" />
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <br />
    <table style="width: 286px">
        <tr>
            <td colspan="2">
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" SkinID="Normal" /><asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" SkinID="Cancel" /></td>
        </tr>
    </table>
</asp:Content>

