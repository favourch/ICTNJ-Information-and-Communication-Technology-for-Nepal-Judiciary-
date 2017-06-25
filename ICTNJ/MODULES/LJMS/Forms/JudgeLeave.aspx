<%@ Page Language="C#" MasterPageFile="~/MODULES/LJMS/LJMSMasterPage.master" AutoEventWireup="true" CodeFile="JudgeLeave.aspx.cs" Inherits="MODULES_LJMS_Forms_JudgeLeave" Title="LJMS | Judge Leave" %>

<%@ Register Src="../../COMMON/UserControls/PersonnelSearchControl.ascx" TagName="PersonnelSearchControl"
    TagPrefix="uc1" %>


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
                    <br />
                    <asp:Label ID="lblStatusMessage" runat="server" Height="19px" Text="Label"></asp:Label>
                </contenttemplate>
            </asp:UpdatePanel>
                <asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click" Width="58px" />    
             <br />
        </asp:Panel>
    <br />
    <br />
    <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server" Collapsed="true" ExpandControlID="upper" CollapseControlID="upper" TargetControlID="PanelSearch" SuppressPostBack="true" SkinID="CollapsiblePanelDemo">
    </ajaxToolkit:CollapsiblePanelExtender>
    <div id="upper" style="width: 938px; cursor: hand; height: 27px" class="collapsePanelHeader">
    कर्मचारी खिज्नुहोस्
    </div>
    &nbsp;
    &nbsp;&nbsp;<br />
    <asp:Panel ID="PanelSearch" runat="server" Height="50px" Width="900px">
        <table style="width: 950px">
        <tr>
            <td style="width: 126px">
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
            <td style="width: 126px">
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
            <td style="width: 126px">
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
            <td style="width: 126px; height: 24px;">
                <asp:Label ID="Label7" runat="server" SkinID="Unicodelbl" Text="कार्यालय"></asp:Label></td>
            <td colspan="3" style="height: 24px">
                <asp:DropDownList ID="ddlOrganization" runat="server" SkinID="Unicodeddl" Width="478px">
                </asp:DropDownList></td>
            <td style="height: 24px">
                <asp:Label ID="lblDesignation" runat="server" SkinID="Unicodelbl" Text="पद"></asp:Label></td>
            <td style="height: 24px">
                <asp:DropDownList ID="ddlDesignation" runat="server" SkinID="Unicodeddl" Width="135px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td align="left" colspan="6" style="height: 26px">
                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" SkinID="Normal"
                    Text="Search" /><asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click"
                        SkinID="Cancel" Text="Cancel" /></td>
        </tr>
        <tr>
            <td colspan="6" style="height: 306px">
                <hr />
                <br />
                <asp:UpdatePanel id="UpdatePanel2" runat="server">
                    <contenttemplate>
                

<asp:Label id="lblSearch" runat="server" Font-Bold="True"></asp:Label> <BR /><asp:Panel id="Panel1" runat="server" Width="890px" Height="150px" ScrollBars="Auto"><asp:GridView id="grdEmployee" runat="server" Width="848px" SkinID="Unicodegrd" ForeColor="#333333" CellPadding="0" AutoGenerateColumns="False" OnRowDataBound="grdEmployee_RowDataBound" OnSelectedIndexChanged="grdEmployee_SelectedIndexChanged">
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
                </asp:UpdatePanel>&nbsp;
</td>
        </tr>
    </table>
    </asp:Panel>
    <asp:Label ID="Label13" runat="server" SkinID="UnicodeHeadlbl" Text="कर्मचारीको बिदा निवेदनको विवरण"></asp:Label>
    <br />
    <br />
    <table style="width: 800px">
        <tr>
            <td style="width: 100px; height: 10px" valign="top">
                <asp:Label ID="LblApplicatn" runat="server" SkinID="Unicodelbl" Text="निवेदक" Width="60px"></asp:Label>
            </td>
            <td style="height: 10px" valign="top">
                <asp:TextBox ID="txtEmpName" runat="server" AutoPostBack="True" ReadOnly="True" SkinID="Unicodetxt"
                    Width="332px"></asp:TextBox>
            </td>
            <td style="width: 115px; height: 10px" valign="top">
                <asp:Label ID="Label8" runat="server" SkinID="Unicodelbl" Text="बिदाको किसिम" Width="105px"></asp:Label>
            </td>
            <td style="width: 165px; height: 10px" valign="top">
                <asp:DropDownList ID="ddlAppType" runat="server" SkinID="Unicodeddl" Width="160px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 100px" valign="top">
                <asp:Label ID="Label9" runat="server" SkinID="Unicodelbl" Text="अवधि देखि" Width="85px"></asp:Label>
            </td>
            <td valign="top">
                <asp:TextBox ID="txtEmpLvFrom" runat="server" AutoPostBack="True" OnTextChanged="txtEmpLvFrom_TextChanged"
                    SkinID="Unicodetxt" Width="106px"></asp:TextBox>
            </td>
            <td style="width: 115px" valign="top">
                <asp:Label ID="Label10" runat="server" SkinID="Unicodelbl" Text="अवधि सम्म" Width="93px"></asp:Label>
            </td>
            <td style="width: 165px" valign="top">
                <asp:TextBox ID="txtEmpLvTo" runat="server" AutoPostBack="True" OnTextChanged="txtEmpLvTo_TextChanged"
                    SkinID="Unicodetxt" Width="105px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 100px" valign="top">
                <asp:Label ID="lblApplDate" runat="server" SkinID="Unicodelbl" Text="निवेदन मिति"
                    Width="90px"></asp:Label>
            </td>
            <td valign="top">
                <asp:TextBox ID="txtEmpDate" runat="server" SkinID="Unicodetxt" Width="107px"></asp:TextBox>
            </td>
            <td style="width: 115px" valign="top">
                <asp:Label ID="Label11" runat="server" SkinID="Unicodelbl" Text="जम्मा दिन"></asp:Label>
            </td>
            <td style="width: 165px" valign="top">
                <asp:TextBox ID="txtEmpLvDays" runat="server" MaxLength="3" SkinID="Unicodetxt" Width="45px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 100px" valign="top">
                <asp:Label ID="Label12" runat="server" SkinID="Unicodelbl" Text="कैफियत"></asp:Label>
            </td>
            <td valign="top">
                <asp:TextBox ID="txtEmpLvResn" runat="server" Height="98px" SkinID="Unicodetxt" TextMode="MultiLine"
                    Width="342px"></asp:TextBox>
            </td>
            <td style="width: 115px" valign="baseline">
                <asp:Button ID="btnAddApplication" runat="server" OnClick="btnAddApplication_Click"
                    SkinID="Add" Text="+" />
            </td>
            <td style="width: 165px" valign="top">
            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:Label ID="Label18" runat="server" Font-Bold="True" SkinID="UnicodeHeadlbl" Text="निवेदनको विवरण:"></asp:Label><br />
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<asp:Panel id="Panel2" runat="server" Width="890px" Height="150px" ScrollBars="Auto"><asp:GridView id="grdLeaveApplications" runat="server" Width="890px" Height="150px" SkinID="Unicodegrd" OnSelectedIndexChanged="grdLeaveApplications_SelectedIndexChanged" OnRowDataBound="grdLeaveApplications_RowDataBound" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333" GridLines="None" OnRowDeleting="grdLeaveApplications_RowDeleting">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="EmpID" HeaderText="कर्मचारि नं"></asp:BoundField>
<asp:BoundField DataField="EmpFullName" HeaderText="पुरानाम र थर"></asp:BoundField>
<asp:BoundField DataField="LeaveTypeID" HeaderText="बिदा नं"></asp:BoundField>
<asp:BoundField DataField="LeaveType" HeaderText="बिदा"></asp:BoundField>
<asp:BoundField DataField="ApplDate" HeaderText="निवेदन मिति"></asp:BoundField>
<asp:BoundField DataField="ReqdFrom" HeaderText="देखि"></asp:BoundField>
<asp:BoundField DataField="ReqdTo" HeaderText="सम्म"></asp:BoundField>
<asp:BoundField DataField="EmpDays" HeaderText="जम्मा दिन"></asp:BoundField>
<asp:BoundField DataField="EmpReason" HeaderText="बिदाको कारण"></asp:BoundField>
<asp:BoundField DataField="Action" HeaderText="Action"></asp:BoundField>
<asp:BoundField DataField="RecYesNo" HeaderText="सिफारिस "></asp:BoundField>
<asp:BoundField DataField="RecByName" HeaderText="सिफारिस गर्ने अधिकृत"></asp:BoundField>
<asp:BoundField DataField="RecDate" HeaderText="सिफारिस मिति"></asp:BoundField>
<asp:BoundField DataField="RecFrom" HeaderText="देखि"></asp:BoundField>
<asp:BoundField DataField="RecTo" HeaderText="सम्म"></asp:BoundField>
<asp:BoundField DataField="RecDays" HeaderText="जम्मा दिन"></asp:BoundField>
<asp:BoundField DataField="RecReason" HeaderText="सिफारिसको कारण"></asp:BoundField>
<asp:BoundField DataField="ApprYesNo" HeaderText="स्विकृत "></asp:BoundField>
<asp:TemplateField><EditItemTemplate>
<asp:LinkButton runat="server" CommandName="Select" id="lnkselect">Select</asp:LinkButton>
</EditItemTemplate>
<ItemTemplate>
<asp:LinkButton id="lnkselect" runat="server" CommandName="Select">Select</asp:LinkButton> 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView></asp:Panel> 
</contenttemplate>
    </asp:UpdatePanel>
    <table>
        <tr>
            <td style="width: 100px">
                <asp:Button ID="btnApplSubmit" runat="server" OnClick="btnApplSubmit_Click" SkinID="Normal"
                    Text="Submit" /></td>
            <td style="width: 100px">
                <asp:Button ID="btnApplCancel" runat="server" OnClick="btnApplCancel_Click" SkinID="Cancel"
                    Text="Cancel" /></td>
        </tr>
    </table>
    <br />
    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender10" runat="server" AutoComplete="False"
        CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
        CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
        CultureTimePlaceholder="" Enabled="True" Mask="9999/99/99" MaskType="Date" TargetControlID="txtEmpDate">
    </ajaxToolkit:MaskedEditExtender>
    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender11" runat="server" AutoComplete="False"
        CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
        CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
        CultureTimePlaceholder="" Enabled="True" Mask="9999/99/99" MaskType="Date" TargetControlID="txtEmpLvFrom">
    </ajaxToolkit:MaskedEditExtender>
    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender12" runat="server" AutoComplete="False"
        CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
        CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
        CultureTimePlaceholder="" Enabled="True" Mask="9999/99/99" MaskType="Date" TargetControlID="txtEmpLvTo">
    </ajaxToolkit:MaskedEditExtender>
    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
        Enabled="True" FilterType="Numbers" TargetControlID="txtEmpLvDays">
    </ajaxToolkit:FilteredTextBoxExtender>
    <br />
    &nbsp;&nbsp;
    <br />
        
        <%--OUTER TABLE--%>
    
        <%--  Tab Container--%>
        
         
         
    <div style="text-align: left">
           <br />
        
     <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
Update in progress... <img src="../../../MODULES/COMMON/Images/pleasewait.gif" alt="Please wait" />
</ProgressTemplate>
    </asp:UpdateProgress>
    <br />
    </div>
</asp:Content>

