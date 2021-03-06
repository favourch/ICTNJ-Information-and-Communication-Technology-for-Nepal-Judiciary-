<%@ Page AutoEventWireup="true" CodeFile="EmployeeEvaluation.aspx.cs" Inherits="MODULES_PMS_Forms_EmployeeEvaluation" Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master"
    Title="Employee Evaluation" %>
    

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">

    <script language="javascript" type="text/javascript" src="../../COMMON/JS/Validation.js"></script>
    <script language="javascript" src="../../COMMON/JS/DateValidator.js" type="text/javascript"></script>

    <script language="javascript">
        function textboxMultilineMaxNumber(txt,maxLen)
        {
            try
            {
                if(txt.value.length > (maxLen-1))
                    return false;
            }
            catch(e)
            {
            }
        }
    </script>

    <div style="width: 100%; height: auto">
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager><asp:HiddenField ID="hdnMode" runat="server" />
        <br />
                    <asp:Label ID="Label6" runat="server" SkinID="UnicodeHeadlbl" Text="कर्मचारी मुल्यांकन"></asp:Label>
        <br />
        <br />
        <asp:Panel ID="pnlCol" runat="server" CssClass="collapsePanelHeader" Height="25px" Width="945px">
            कर्मचारी खोज्नुहोस</asp:Panel>
        <ajaxToolkit:CollapsiblePanelExtender ID="colEmployee" runat="server" CollapseControlID="pnlCol" Collapsed="True" CollapsedImage="../../COMMON/Images/expand_blue.jpg"
            ExpandControlID="pnlCol" ImageControlID="imgCol" SkinID="CollapsiblePanelDemo" SuppressPostBack="True" TargetControlID="pnlEmployeeSearch" ExpandedImage="../../COMMON/Images/collapse_blue.jpg">
        </ajaxToolkit:CollapsiblePanelExtender>
        <asp:Panel ID="pnlEmployeeSearch" runat="server" Width="945px" CssClass="collapsePanel">
        <table style="width: 940px">
            <tr>
                <td style="width: 25px">
                </td>
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
                <td style="width: 25px">
                </td>
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
                <td style="width: 25px">
                </td>
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
                <td style="width: 25px">
                </td>
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
                <td style="width: 25px">
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td style="width: 169px">
                    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" Width="68px" SkinID="Normal" /><asp:Button ID="Button2" runat="server" OnClick="btnCancel_Click"
                        Text="Cancel" Width="68px" SkinID="Cancel" /></td>
            </tr>
            <tr>
                <td colspan="1" style="width: 25px">
                </td>
                <td colspan="6">
                    <hr />
                    <asp:UpdatePanel id="UpdatePanel1" runat="server">
                        <contenttemplate>
<asp:Panel id="PanelSrch" runat="server" Width="900px" Height="150px" ScrollBars="Auto"><asp:Label id="lblSearchx" runat="server" Font-Bold="True"></asp:Label><asp:GridView id="grdEmployee" runat="server" Width="848px" SkinID="Unicodegrd" AutoGenerateColumns="False" CellPadding="0" OnSelectedIndexChanged="grdEmployee_SelectedIndexChanged" ForeColor="#333333" OnRowDataBound="grdEmployee_RowDataBound">
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
</asp:GridView></asp:Panel>
</contenttemplate>
                    </asp:UpdatePanel></td>
            </tr>
            <tr>
                <td colspan="1" style="width: 25px; height: 34px">
                </td>
                <td colspan="6" style="height: 34px">
                    <hr />
                    <asp:Panel ID="pnlEvaluationList" runat="server" Width="910px" BackColor="#FFFFC0" Height="50px">
                        <asp:DataList ID="dlstEvaluation" runat="server" CaptionAlign="Left" RepeatColumns="2">
                        <ItemTemplate>
                            <table width="450">
                                <tr>
                                    <td style="width: 450px; height: 28px">
                                        <asp:Label ID="Label35" runat="server" SkinID="Unicodelbl" Text="कर्मचारी नं:: "></asp:Label>
                                        <asp:Label ID="lblDlstEmpID" runat="server" SkinID="Unicodelbl" Text='<%# Eval("EmpID") %>'></asp:Label>&nbsp;|
                                        <asp:Label ID="Label37" runat="server" SkinID="Unicodelbl" Text="मुल्यंकन मिति::"></asp:Label>
                                        <asp:Label ID="Label36" runat="server" SkinID="Unicodelbl" Text='<%# Eval("EvalFromDate") %>'></asp:Label>
                                        &nbsp;|&nbsp;
                                        <asp:LinkButton ID="lnkSelectEvaluation" runat="server" CommandArgument='<%# Eval("EmpID") %>' CommandName='<%# Eval("EvalFromDate") %>' Font-Names="Verdana"
                                            Font-Size="15px" OnClick="lnkSelectEvaluation_Click" SkinID="AA">छान्नुहोस</asp:LinkButton></td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList></asp:Panel>
                </td>
            </tr>
        </table>
        </asp:Panel>
        <table width="800">
            <tr>
                <td align="center" colspan="1" style="width: 25px; height: 25px">
                </td>
                <td align="center" colspan="4" style="height: 25px">
        <asp:Label
            ID="lblEmpName" runat="server" SkinID="UnicodeHeadlbl"></asp:Label><asp:Label ID="lblComma" runat="server" SkinID="PCSHeadlbl"></asp:Label><asp:Label ID="lblEmpID" runat="server" SkinID="UnicodeHeadlbl"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="1" style="width: 25px; height: 10px">
                </td>
                <td colspan="2" style="height: 10px">
                    <asp:HiddenField ID="hdnOldDate" runat="server" />
                    </td>
                <td style="height: 10px; width: 114px;">
                    &nbsp;</td>
                <td style="height: 10px; width: 216px;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 25px; height: 6px">
                </td>
                <td style="height: 6px; width: 200px;" valign="top">
                    <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="मुल्यांकन अवधि देखि"></asp:Label></td>
                <td style="height: 6px; width: 106px;" valign="top">
                    <asp:TextBox ID="txtFromDate_rdt" runat="server" SkinID="Unicodetxt" Width="100px" ToolTip="मुल्यांकन अवधि देखि"></asp:TextBox>
                    <ajaxToolkit:MaskedEditExtender ID="mskEvalFrom" runat="server" AutoComplete="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtFromDate_rdt">
                    </ajaxToolkit:MaskedEditExtender>
                </td>
                <td style="height: 6px; width: 114px;" align="right" valign="top">
                    <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="सम्म"></asp:Label></td>
                <td style="height: 6px; width: 216px;" valign="top">
                    <asp:TextBox ID="txtToDate_rdt" runat="server" SkinID="Unicodetxt" Width="100px" ToolTip="सम्म"></asp:TextBox>
                    <ajaxToolkit:MaskedEditExtender ID="mskEvalToDate" runat="server" AutoComplete="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtToDate_rdt">
                    </ajaxToolkit:MaskedEditExtender>
                </td>
            </tr>
            <tr>
                <td style="width: 25px; height: 4px">
                </td>
                <td style="height: 4px; width: 200px;" valign="top">
                    <asp:Label ID="Label5" runat="server" SkinID="Unicodelbl" Text="दर्ता नं"></asp:Label></td>
                <td style="height: 4px; width: 106px;" valign="top">
                    <asp:TextBox ID="txtRegNO_rqd" runat="server" SkinID="Unicodetxt" Width="100px" ToolTip="दर्ता नं" MaxLength="9"></asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="mskRegNo" runat="server" FilterType="Numbers" TargetControlID="txtRegNO_rqd">
                    </ajaxToolkit:FilteredTextBoxExtender>
                </td>
                <td style="height: 4px; width: 114px;" valign="top" align="right">
                    <asp:Label ID="Label4" runat="server" SkinID="Unicodelbl" Text="मुल्यांकन मिति" Width="112px"></asp:Label></td>
                <td style="height: 4px; width: 216px;" valign="top">
                    <asp:TextBox ID="txtSubmitedDate_rdt" runat="server" SkinID="Unicodetxt" Width="100px" ToolTip="मुल्यांकन मिति"></asp:TextBox>
                    <ajaxToolkit:MaskedEditExtender ID="mskEvalDate" runat="server" AutoComplete="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtSubmitedDate_rdt">
                    </ajaxToolkit:MaskedEditExtender>
                </td>
            </tr>
            <tr>
                <td style="width: 25px; height: 26px">
                </td>
                <td style="height: 26px; width: 200px;" valign="top">
                    <asp:Label ID="Label3" runat="server" SkinID="Unicodelbl" Text="विवरण पेश गरेको कार्यालय" Width="200px"></asp:Label></td>
                <td colspan="3" style="height: 26px" valign="top">
                    <asp:TextBox ID="txtOrganization_rqd" runat="server" SkinID="Unicodetxt" Width="216px" ToolTip="कार्यालय" MaxLength="145"></asp:TextBox></td>
            </tr>
        </table>
        <hr />
        <cc1:TabContainer ID="EvaluationTab" runat="server" ActiveTabIndex="1" CssClass="ajax_tab_theme" Height="600px" Width="950px">
            <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                <ContentTemplate>
<asp:UpdatePanel id="UpdatePanel31" runat="server" __designer:wfdid="w225"><ContentTemplate>
<TABLE width=800><TBODY><TR><TD colSpan=2 height=30><asp:Label id="Label7" runat="server" Text="कार्यको बिवरण" SkinID="UnicodeHeadlbl" __designer:wfdid="w226"></asp:Label></TD><TD style="WIDTH: 150px" height=30></TD><TD style="WIDTH: 250px" height=30></TD></TR><TR><TD style="WIDTH: 150px" vAlign=top><asp:Label id="Label8" runat="server" Text="सम्पादित काम" SkinID="Unicodelbl" __designer:wfdid="w227"></asp:Label></TD><TD colSpan=3><asp:TextBox id="txtWorkDesc" onkeypress="return textboxMultilineMaxNumber(this,245)" runat="server" Width="630px" SkinID="Unicodetxt" __designer:wfdid="w228" TextMode="MultiLine"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 150px" vAlign=top><asp:Label id="Label9" runat="server" Text="एकाई" SkinID="Unicodelbl" __designer:wfdid="w229"></asp:Label></TD><TD colSpan=3><asp:TextBox id="txtUnit" onkeypress="return textboxMultilineMaxNumber(this,150)" runat="server" Width="630px" SkinID="Unicodetxt" __designer:wfdid="w230" TextMode="MultiLine"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 150px; HEIGHT: 40px" vAlign=top><asp:Label id="Label10" runat="server" Text="अर्ध बार्षिक लछ्य" SkinID="Unicodelbl" __designer:wfdid="w231"></asp:Label></TD><TD style="WIDTH: 250px; HEIGHT: 40px"><asp:TextBox id="txtHalfYearTarget" onkeypress="return textboxMultilineMaxNumber(this,99)" runat="server" Width="225px" SkinID="Unicodetxt" __designer:wfdid="w232" TextMode="MultiLine"></asp:TextBox></TD><TD style="WIDTH: 150px; HEIGHT: 40px" vAlign=top>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label id="Label11" runat="server" Text="बर्षिक लछ्य" SkinID="Unicodelbl" __designer:wfdid="w233"></asp:Label></TD><TD style="WIDTH: 250px; HEIGHT: 40px"><asp:TextBox id="txtFullYearTarget" onkeypress="return textboxMultilineMaxNumber(this,99)" runat="server" Width="225px" SkinID="Unicodetxt" __designer:wfdid="w234" TextMode="MultiLine"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 150px" vAlign=top><asp:Label id="Label13" runat="server" Text="कार्यको प्रगति" SkinID="Unicodelbl" __designer:wfdid="w235"></asp:Label></TD><TD style="WIDTH: 250px" vAlign=top><asp:TextBox id="txtWorkProgress" onkeypress="return textboxMultilineMaxNumber(this,99)" runat="server" Width="225px" SkinID="Unicodetxt" __designer:wfdid="w236" TextMode="MultiLine"></asp:TextBox></TD><TD style="WIDTH: 150px" vAlign=top>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label id="Label12" runat="server" Text="कैफियत" SkinID="Unicodelbl" __designer:wfdid="w237"></asp:Label></TD><TD style="WIDTH: 250px"><asp:TextBox id="txtRemarks" onkeypress="return textboxMultilineMaxNumber(this,149)" runat="server" Width="224px" Height="111px" SkinID="Unicodetxt" __designer:wfdid="w238" TextMode="MultiLine"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 150px" vAlign=top><asp:Label id="Label14" runat="server" Text="कार्यलयले दिएको" SkinID="Unicodelbl" __designer:wfdid="w239"></asp:Label></TD><TD style="WIDTH: 250px"><asp:CheckBox id="chkByOffice" runat="server" __designer:wfdid="w240" Checked="True"></asp:CheckBox></TD><TD style="WIDTH: 150px" vAlign=top></TD><TD style="WIDTH: 250px"></TD></TR><TR><TD vAlign=top colSpan=2><asp:Button id="btnAddWork" onclick="btnAddWork_Click" runat="server" Width="65px" Text="Add" SkinID="Normal" __designer:wfdid="w241"></asp:Button><asp:Button id="btnCancelWork" onclick="btnCancelWork_Click" runat="server" Width="65px" Text="Cancel" SkinID="Cancel" __designer:wfdid="w242"></asp:Button></TD><TD style="WIDTH: 150px" vAlign=top></TD><TD style="WIDTH: 250px"></TD></TR></TBODY></TABLE>
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="grdEmployeeWork" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</Triggers>
</asp:UpdatePanel> <asp:UpdatePanel id="updWork" runat="server" __designer:wfdid="w243"><ContentTemplate>
<asp:Panel id="Panel221" runat="server" Width="930px" Height="250px" ScrollBars="Auto" __designer:wfdid="w244"><asp:GridView id="grdEmployeeWork" runat="server" Width="900px" SkinID="Unicodegrd" ForeColor="#333333" OnSelectedIndexChanged="grdEmployeeWork_SelectedIndexChanged" CellPadding="0" AutoGenerateColumns="False" __designer:wfdid="w224" OnRowCreated="grdEmployeeWork_RowCreated" GridLines="None">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="EmpID" Visible="False" HeaderText="EmpID"></asp:BoundField>
<asp:BoundField DataField="EvalFromDate" Visible="False" HeaderText="EvalFromDate"></asp:BoundField>
<asp:BoundField DataField="WorkID" HeaderText="WorkID"></asp:BoundField>
<asp:BoundField DataField="WorkDescription" HeaderText="सम्पादित काम">
<ItemStyle HorizontalAlign="Left"></ItemStyle>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="Unit" HeaderText="एकाई">
<ItemStyle HorizontalAlign="Left"></ItemStyle>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="HalfYearTarget" HeaderText="अर्ध बार्षिक लछ्य">
<ItemStyle HorizontalAlign="Left"></ItemStyle>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="FullYearTarget" HeaderText="बार्षिक लछ्य">
<ItemStyle HorizontalAlign="Left"></ItemStyle>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="WorkProgress" HeaderText="कार्य प्रगति">
<ItemStyle HorizontalAlign="Left"></ItemStyle>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="AssignByOffice" HeaderText="Official"></asp:BoundField>
<asp:BoundField DataField="Remark" HeaderText="कैफियत">
<ItemStyle HorizontalAlign="Left"></ItemStyle>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="Action" HeaderText="Action"></asp:BoundField>
<asp:BoundField DataField="EntryBy" Visible="False" HeaderText="EntryBy"></asp:BoundField>
<asp:BoundField DataField="EntryOn" Visible="False" HeaderText="EntryOn"></asp:BoundField>
<asp:CommandField ShowSelectButton="True"></asp:CommandField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> </asp:Panel> 
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="btnAddWork" EventName="Click"></asp:AsyncPostBackTrigger>
</Triggers>
</asp:UpdatePanel> 
</ContentTemplate>
                <HeaderTemplate>
                    कर्मचारीको कार्य
                
</HeaderTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                <ContentTemplate>
<TABLE width=600><TBODY><TR><TD style="WIDTH: 118px" height=25></TD><TD style="WIDTH: 320px" height=25></TD></TR><TR><TD style="WIDTH: 118px" vAlign=top><asp:Label id="Label15" runat="server" Text="मुल्यांकन समुह" SkinID="Unicodelbl" __designer:wfdid="w258"></asp:Label> </TD><TD style="WIDTH: 320px" vAlign=top><asp:DropDownList id="ddlGroup" runat="server" Width="300px" SkinID="Unicodeddl" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged" __designer:wfdid="w259" AutoPostBack="True"></asp:DropDownList> </TD></TR><TR><TD style="WIDTH: 118px" vAlign=top><asp:Label id="Label16" runat="server" Width="117px" Text="मुल्यांकन बिवरण" SkinID="Unicodelbl" __designer:wfdid="w248"></asp:Label> </TD><TD style="WIDTH: 320px" vAlign=top><asp:UpdatePanel id="updCriteria" runat="server" __designer:wfdid="w261"><ContentTemplate>
<asp:DropDownList id="ddlCriteria" runat="server" Width="300px" SkinID="Unicodeddl" OnSelectedIndexChanged="ddlCriteria_SelectedIndexChanged" __designer:wfdid="w262" AutoPostBack="True"></asp:DropDownList> 
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="ddlGroup" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</Triggers>
</asp:UpdatePanel> </TD></TR><TR><TD style="WIDTH: 118px" vAlign=top><asp:Label id="Label17" runat="server" Text="मुल्यांकन भार" SkinID="Unicodelbl" __designer:wfdid="w263"></asp:Label> </TD><TD style="WIDTH: 320px" vAlign=top><asp:UpdatePanel id="updGrade" runat="server" __designer:wfdid="w264"><ContentTemplate>
<asp:DropDownList id="ddlGrade" runat="server" Width="300px" SkinID="Unicodeddl" __designer:wfdid="w265"></asp:DropDownList> 
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="ddlCriteria" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="ddlGroup" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</Triggers>
</asp:UpdatePanel> </TD></TR><TR><TD style="WIDTH: 118px"></TD><TD style="WIDTH: 320px"><asp:Button id="btnAddEvalDetail" onclick="btnAddEvalDetail_Click" runat="server" Width="60px" Text="Add" SkinID="Normal" __designer:wfdid="w266"></asp:Button> </TD></TR></TBODY></TABLE><asp:UpdatePanel id="updDetail" runat="server" __designer:wfdid="w267"><ContentTemplate>
<asp:Panel id="Panel2" runat="server" Width="900px" Height="300px" ScrollBars="Auto" __designer:wfdid="w268"><asp:GridView id="grdEvaluaitonDetail" runat="server" Width="870px" SkinID="Unicodegrd" ForeColor="#333333" OnSelectedIndexChanged="grdEvaluaitonDetail_SelectedIndexChanged" CellPadding="0" AutoGenerateColumns="False" __designer:wfdid="w269" OnRowCreated="grdEvaluaitonDetail_RowCreated" GridLines="None" OnRowDeleting="grdEvaluaitonDetail_RowDeleting">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="EmpID" Visible="False" HeaderText="EmpID"></asp:BoundField>
<asp:BoundField DataField="EvalFromDate" Visible="False" HeaderText="EvalFromDate"></asp:BoundField>
<asp:BoundField DataField="EvaluationCriteriaID" Visible="False" HeaderText="EvaluationCriteriaID"></asp:BoundField>
<asp:BoundField DataField="FromDate" Visible="False" HeaderText="FromDate"></asp:BoundField>
<asp:BoundField DataField="EvaluationGradeID" Visible="False" HeaderText="EvaluationGradeID"></asp:BoundField>
<asp:BoundField DataField="GroupName" HeaderText="मुल्यांकन समुह">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="EvaluationCriteriaName" HeaderText="मुल्यांकनको बिवरण">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="EvaluationGradeName" HeaderText="भार">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="Action" HeaderText="Action"></asp:BoundField>
<asp:CommandField ShowDeleteButton="True"></asp:CommandField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> </asp:Panel> 
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="btnAddEvalDetail" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="grdEvaluaitonDetail" EventName="RowDeleting"></asp:AsyncPostBackTrigger>
</Triggers>
</asp:UpdatePanel> 
</ContentTemplate>
                <HeaderTemplate>
                    मुल्यांकन बिवरण
                
</HeaderTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
                <ContentTemplate>
<TABLE style="WIDTH: 900px"><TBODY><TR><TD style="WIDTH: 25px"></TD><TD><asp:Label id="Label24" runat="server" Width="92px" Height="22px" Text="पहिलो नाम" SkinID="PCSlbl" Font-Names="PCS NEPALI" __designer:wfdid="w438"></asp:Label> </TD><TD><asp:TextBox id="txtPersonFName" runat="server" Width="130px" SkinID="PCStxt" ToolTip="First Name" MaxLength="35" __designer:wfdid="w439"></asp:TextBox> </TD><TD><asp:Label id="Label25" runat="server" Width="92px" Height="22px" Text="बिचको नाम" SkinID="PCSlbl" Font-Names="PCS NEPALI" __designer:wfdid="w440"></asp:Label> </TD><TD style="WIDTH: 165px"><asp:TextBox id="txtPersonMName" runat="server" Width="130px" SkinID="PCStxt" MaxLength="15" __designer:wfdid="w441"></asp:TextBox> </TD><TD><asp:Label id="Label26" runat="server" Width="92px" Height="22px" Text="थर" SkinID="PCSlbl" Font-Names="PCS NEPALI" __designer:wfdid="w442"></asp:Label> </TD><TD><asp:TextBox id="txtCast" runat="server" Width="130px" SkinID="PCStxt" ToolTip="Surname" MaxLength="35" __designer:wfdid="w443"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 25px"></TD><TD><asp:Label id="Label27" runat="server" Width="92px" Height="22px" Text="लिंग" SkinID="PCSlbl" Font-Names="PCS NEPALI" __designer:wfdid="w444"></asp:Label> </TD><TD><asp:DropDownList id="ddlPersonSex" runat="server" Width="135px" SkinID="PCSddl" __designer:wfdid="w445"><asp:ListItem Value="SG">%fGg'xf];</asp:ListItem>
<asp:ListItem Value="M">k'?if</asp:ListItem>
<asp:ListItem Value="F">dlxnf</asp:ListItem>
<asp:ListItem Value="O">cGo</asp:ListItem>
</asp:DropDownList> </TD><TD><asp:Label id="Label88" runat="server" Width="92px" Height="22px" Text="जिल्ला" SkinID="PCSlbl" Font-Names="PCS NEPALI" __designer:wfdid="w446"></asp:Label> </TD><TD style="WIDTH: 165px"><asp:DropDownList id="ddlDistrict" runat="server" Width="135px" SkinID="PCSddl" __designer:wfdid="w447"></asp:DropDownList> </TD><TD><asp:Label id="Label28" runat="server" Text="Registration" __designer:wfdid="w448" Visible="False"></asp:Label> </TD><TD><asp:DropDownList id="ddlOrgType" runat="server" Width="135px" SkinID="PCSddl" __designer:wfdid="w449" Visible="False"></asp:DropDownList> </TD></TR><TR><TD style="WIDTH: 25px"></TD><TD></TD><TD></TD><TD></TD><TD style="WIDTH: 165px"></TD><TD></TD><TD><asp:Button id="btnSearchPerson" onclick="btnSearchPerson_Click" runat="server" Width="68px" Text="Search" SkinID="Normal" __designer:wfdid="w450"></asp:Button> <asp:Button id="btnCancelPerson" onclick="btnCancel_Click" runat="server" Width="68px" Text="Cancel" SkinID="Cancel" __designer:wfdid="w451"></asp:Button> </TD></TR><TR><TD style="WIDTH: 25px; HEIGHT: 37px" vAlign=bottom colSpan=1></TD><TD style="HEIGHT: 37px" vAlign=bottom colSpan=6>
<HR />
<asp:UpdatePanel id="updPerson" runat="server" __designer:wfdid="w452"><ContentTemplate>
<asp:Label id="lblSearch" runat="server" Font-Bold="True" __designer:wfdid="w453"></asp:Label> <asp:Panel id="Panel1" runat="server" Width="100%" Height="200px" ScrollBars="Auto" __designer:wfdid="w454" BorderStyle="None"><asp:GridView id="grdPerson" runat="server" Width="848px" SkinID="Unicodegrd" OnRowDataBound="grdPerson_RowDataBound" ForeColor="#333333" OnSelectedIndexChanged="grdPerson_SelectedIndexChanged" CellPadding="0" AutoGenerateColumns="False" __designer:wfdid="w455" OnRowCreated="grdPerson_RowCreated">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="PERSONID" HeaderText=" नं"></asp:BoundField>
<asp:BoundField DataField="FIRSTNAME" HeaderText="पहिलो नाम"></asp:BoundField>
<asp:BoundField DataField="MIDDLENAME" HeaderText="बिचको नाम"></asp:BoundField>
<asp:BoundField DataField="SURNAME" HeaderText="थर"></asp:BoundField>
<asp:BoundField DataField="RDFULLNAME" HeaderText="पुरा नाम"></asp:BoundField>
<asp:BoundField DataField="RDGENDER" HeaderText="लि"></asp:BoundField>
<asp:BoundField DataField="DOB" HeaderText="जन्म मिति">
<ItemStyle Font-Names="Verdana"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DISTRICT" HeaderText="जिल्ला"></asp:BoundField>
<asp:BoundField DataField="FATHERNAME" HeaderText="बाबुको नाम"></asp:BoundField>
<asp:BoundField DataField="GFATHERNAME" HeaderText="बाजेको नाम"></asp:BoundField>
<asp:BoundField DataField="PostName" HeaderText="पद"></asp:BoundField>
<asp:CommandField ShowSelectButton="True"></asp:CommandField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> </asp:Panel> 
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="btnSearchPerson" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="grdPerson" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</Triggers>
</asp:UpdatePanel> </TD></TR></TBODY></TABLE><asp:UpdatePanel id="updEvaluatorControl" runat="server" __designer:wfdid="w456"><ContentTemplate>
<TABLE width=900><TBODY><TR><TD style="WIDTH: 25px"></TD><TD style="WIDTH: 150px"><asp:Label id="Label29" runat="server" Text="मुल्यांकन समुह" SkinID="Unicodelbl" __designer:wfdid="w457"></asp:Label> </TD><TD colSpan=2><asp:DropDownList id="ddlEvaluatorGroup" runat="server" Width="310px" SkinID="Unicodeddl" __designer:wfdid="w458">
                                </asp:DropDownList> </TD><TD style="WIDTH: 400px"><asp:Label id="lblPersonName" runat="server" SkinID="aa" Font-Size="12pt" Font-Bold="True" __designer:wfdid="w459"></asp:Label></TD></TR><TR><TD style="WIDTH: 25px"></TD><TD style="WIDTH: 150px"><asp:Label id="Label31" runat="server" Text="पद" SkinID="Unicodelbl" __designer:wfdid="w460"></asp:Label></TD><TD style="WIDTH: 200px"><asp:TextBox id="txtDesignation" runat="server" Width="180px" SkinID="Unicodetxt" MaxLength="99" __designer:wfdid="w461" Enabled="False"></asp:TextBox></TD><TD style="WIDTH: 150px">&nbsp; &nbsp; &nbsp; &nbsp; <asp:Label id="Label32" runat="server" Text="संकेत नं" SkinID="Unicodelbl" __designer:wfdid="w462"></asp:Label></TD><TD style="WIDTH: 400px"><asp:TextBox id="txtEvaluatorSymbol" runat="server" Width="180px" SkinID="Unicodetxt" MaxLength="9" __designer:wfdid="w463"></asp:TextBox> <ajaxToolkit:FilteredTextBoxExtender id="fltSymbolNo" runat="server" TargetControlID="txtEvaluatorSymbol" FilterType="Numbers" __designer:wfdid="w464"></ajaxToolkit:FilteredTextBoxExtender></TD></TR><TR><TD style="WIDTH: 25px" vAlign=top></TD><TD style="WIDTH: 150px" vAlign=top><asp:Label id="Label33" runat="server" Text="मिति" SkinID="Unicodelbl" __designer:wfdid="w465"></asp:Label></TD><TD style="WIDTH: 200px" vAlign=top><asp:TextBox id="txtEvaluatorDate" runat="server" Width="180px" SkinID="Unicodetxt" __designer:wfdid="w466"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="mskEvaluatorDate" runat="server" TargetControlID="txtEvaluatorDate" MaskType="Date" Mask="9999/99/99" AutoComplete="False" __designer:wfdid="w467"></ajaxToolkit:MaskedEditExtender></TD><TD style="WIDTH: 150px" vAlign=top>&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; <asp:Label id="Label34" runat="server" Text="कैफियत" SkinID="Unicodelbl" __designer:wfdid="w468"></asp:Label></TD><TD style="WIDTH: 400px" vAlign=top><asp:TextBox id="txtEvaluatorRemark" onkeypress="return textboxMultilineMaxNumber(this,149)" runat="server" Width="300px" Height="140px" SkinID="Unicodetxt" MaxLength="149" __designer:wfdid="w469" TextMode="MultiLine"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 25px" colSpan=1></TD><TD colSpan=2><asp:Button id="btnAddEvaluator" onclick="btnAddEvaluator_Click" runat="server" Width="50px" Text="Add" SkinID="Add" __designer:wfdid="w470"></asp:Button><asp:Button id="btnCancelEvaluator" onclick="btnCancelEvaluator_Click" runat="server" Width="65px" Text="Cancel" SkinID="Cancel" __designer:wfdid="w471"></asp:Button></TD><TD style="WIDTH: 150px"></TD><TD style="WIDTH: 400px"></TD></TR></TBODY></TABLE>
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="grdEvaluator" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</Triggers>
</asp:UpdatePanel> <asp:UpdatePanel id="updEvaluator" runat="server" __designer:wfdid="w472"><ContentTemplate>
<asp:Panel id="Panel3" runat="server" Width="900px" Height="100px" ScrollBars="Auto" __designer:wfdid="w473"><asp:GridView id="grdEvaluator" runat="server" Width="870px" Height="150px" SkinID="Unicodegrd" ForeColor="#333333" OnSelectedIndexChanged="grdEvaluator_SelectedIndexChanged" CellPadding="4" AutoGenerateColumns="False" __designer:wfdid="w474" OnRowCreated="grdEvaluator_RowCreated" OnRowDeleting="grdEvaluator_RowDeleting" GridLines="None">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="EmpID" HeaderText="EmpID"></asp:BoundField>
<asp:BoundField DataField="EvalFromDate" HeaderText="EvalFromDate"></asp:BoundField>
<asp:BoundField DataField="GroupID" HeaderText="GroupID"></asp:BoundField>
<asp:BoundField DataField="GroupName" HeaderText="मुल्यांकन समुह">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="PersonID" HeaderText="PersonID"></asp:BoundField>
<asp:BoundField DataField="PersonName" HeaderText="मुल्यांकन कर्त्ता">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="Designation" HeaderText="पद">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="SymbolNo" HeaderText="सकेंत नं">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="Date" HeaderText="मिति">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="Remark" HeaderText="कैफियत">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="EntryBy" HeaderText="EntryBy"></asp:BoundField>
<asp:BoundField DataField="Action" HeaderText="Action"></asp:BoundField>
<asp:CommandField ShowDeleteButton="True"></asp:CommandField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> </asp:Panel> 
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="btnAddEvaluator" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnCancelEvaluator" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="grdEvaluator" EventName="RowDeleting"></asp:AsyncPostBackTrigger>
</Triggers>
</asp:UpdatePanel> 
</ContentTemplate>
                <HeaderTemplate>
                    मुल्यांकन कर्ता
                
</HeaderTemplate>
            </ajaxToolkit:TabPanel>
        </cc1:TabContainer></div>
    <br />
    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" Width="65px" OnClientClick="return validate(1)" SkinID="Normal" /><asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click"
        Text="Cancel" Width="65px" SkinID="Cancel" />
        
    <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
    <ajaxtoolkit:modalpopupextender id="programmaticModalPopup" runat="server" backgroundcssclass="modalBackground" behaviorid="programmaticModalPopupBehavior"
        dropshadow="True" popupcontrolid="programmaticPopup" popupdraghandlecontrolid="programmaticPopupDragHandle" repositionmode="RepositionOnWindowScroll"
        targetcontrolid="hiddenTargetControlForModalPopup">
        </ajaxtoolkit:modalpopupextender>
    <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none; width: 350px; padding: 10px">
        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD; border: solid 1px Gray; color: Black; text-align: center;">
            Status
        </asp:Panel>
        <asp:UpdatePanel id="updMessage" runat="server">
            <contenttemplate>
        <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
</contenttemplate>
        </asp:UpdatePanel>
        <br />
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click" Text="OK" Width="58px" />
        <br />
    </asp:Panel>
</asp:Content>
