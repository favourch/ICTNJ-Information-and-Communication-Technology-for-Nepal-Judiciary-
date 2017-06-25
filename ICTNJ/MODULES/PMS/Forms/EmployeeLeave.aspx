<%@ Page Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master" AutoEventWireup="true" CodeFile="EmployeeLeave.aspx.cs" Inherits="MODULES_PMS_Forms_EmployeeLeave" Title="PMS | Employee Leave" %>

<%@ Register Src="../../COMMON/UserControls/PersonnelSearchControl.ascx" TagName="PersonnelSearchControl"
    TagPrefix="uc1" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript" src="../../COMMON/JS/jquery.min.js"></script>
    <script type="text/javascript" src="../../COMMON/JS/scrolltopcontrol.js">
   <script language="javascript" src="../../COMMON/JS/DateValidator.js" type="text/javascript"></script>
   <script language="javascript" type="text/javascript" defer="defer">
    function validateSubPart()
    {
        var date1='<%= this.txtEmpLvFrom.ClientID%>';
        var date2='<%= this.txtEmpLvTo.ClientID%>';
        var date3='<%= this.txtEmpDate.ClientID%>';
        if(validateDateByControl(date1, true)==false)
        {
            return false;
        }
        else if(validateDateByControl(date2, true)==false)
        {
            return false;
        }
        else if(validateDateByControl(date3, true)==false)
        {
            return false;
        }
        return true;
    }
    function validateRecDate()
    {
        var date1='<%= this.txtRecDate.ClientID%>';
        var date2='<%= this.txtRecFrom.ClientID%>';
        var date3='<%= this.txtRecTo.ClientID%>';
        if(validateDateByControl(date1, true)==false)
        {
            return false;
        }
        else if(validateDateByControl(date2, true)==false)
        {
            return false;
        }
        else if(validateDateByControl(date3, true)==false)
        {
            return false;
        }
        return true;
    }
   </script>
   
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
                Save Status
            </asp:Panel>
            <asp:UpdatePanel id="UpdatePanel3" runat="server">
                <contenttemplate>
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
</contenttemplate>
            </asp:UpdatePanel>
            <br />
<asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click" Width="58px" />           <br />
        </asp:Panel>

    &nbsp;&nbsp;<br />
    <asp:Label ID="Label20" runat="server" SkinID="UnicodeHeadlbl" Text="बिदा"></asp:Label><br />
    <br />
    <div id="upper" style="width: 938px; cursor: hand; height: 27px" class="collapsePanelHeader">
    कर्मचारी खोज्नुहोस्
    </div><ajaxToolkit:CollapsiblePanelExtender id="CollapsiblePanelExtender1" CollapseControlID="upper" Collapsed="true" ExpandControlID="upper" runat="server" SkinID="CollapsiblePanelDemo" SuppressPostBack="true" TargetControlID="PanelSearch">
    </ajaxToolkit:CollapsiblePanelExtender>
    <br />
    <asp:Panel ID="PanelSearch" runat="server" Height="50px" Width="900px">
        <table width="900">
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
            <td style="width: 153px">
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
            <td style="width: 153px">
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
                <asp:Label ID="Label6" runat="server" Height="22px" SkinID="Unicodelbl" Text="बैबाहिक स्थिति"
                    Width="114px"></asp:Label></td>
            <td style="width: 153px">
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
                <asp:DropDownList ID="ddlOrganization" runat="server" SkinID="Unicodeddl" Width="446px">
                </asp:DropDownList></td>
            <td style="height: 24px">
                <asp:Label ID="lblDesignation" runat="server" SkinID="Unicodelbl" Text="पद"></asp:Label></td>
            <td style="height: 24px; width: 153px;">
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
            <td colspan="6" style="height: 160px" valign="top">
                <hr />
                <asp:UpdatePanel id="UpdatePanel2" runat="server">
                    <contenttemplate>
&nbsp;<asp:Label id="lblSearch" runat="server" Font-Bold="True" __designer:wfdid="w133"></asp:Label><BR /><asp:Panel id="Panel1" runat="server" Width="890px" Height="150px" __designer:wfdid="w134" ScrollBars="Auto"><asp:GridView id="grdEmployee" runat="server" Width="848px" SkinID="Unicodegrd" __designer:wfdid="w135" ForeColor="#333333" CellPadding="0" AutoGenerateColumns="False" OnRowDataBound="grdEmployee_RowDataBound" OnSelectedIndexChanged="grdEmployee_SelectedIndexChanged">
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
                    <triggers>
<asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
                </asp:UpdatePanel></td>
        </tr>
    </table>
    </asp:Panel>
        <%--OUTER TABLE--%>
    
        <%--  Tab Container--%>
        
         
         
    <div style="text-align: left">
           <asp:UpdatePanel id="UpdatePanel1" runat="server">
            <contenttemplate>
<DIV><ajaxToolkit:TabContainer id="tabContainerEmpLeave" runat="server" CssClass="ajax_tab_theme" Width="900px" __designer:wfdid="w136" ActiveTabIndex="1" OnActiveTabChanged="tabContainerEmpLeave_ActiveTabChanged" AutoPostBack="True"><ajaxToolkit:TabPanel runat="server" ID="TabPanel2" HeaderText=" कर्मचारिको विवरण"><ContentTemplate>
<BR /><TABLE style="WIDTH: 800px"><TBODY><TR><TD style="WIDTH: 100px; HEIGHT: 10px" vAlign=top><asp:Label id="LblApplicatn" runat="server" Width="60px" Text="निवेदक" SkinID="Unicodelbl" __designer:wfdid="w97"></asp:Label> </TD><TD style="WIDTH: 290px; HEIGHT: 10px" vAlign=top><asp:TextBox id="txtEmpName" runat="server" Width="288px" SkinID="Unicodetxt" __designer:wfdid="w98" AutoPostBack="True" ReadOnly="True"></asp:TextBox> </TD><TD style="WIDTH: 115px; HEIGHT: 10px" vAlign=top><asp:Label id="Label8" runat="server" Width="105px" Text="बिदाको किसिम" SkinID="Unicodelbl" __designer:wfdid="w99"></asp:Label> </TD><TD style="WIDTH: 165px; HEIGHT: 10px" vAlign=top><asp:DropDownList id="ddlAppType" runat="server" Width="160px" SkinID="Unicodeddl" __designer:wfdid="w100"></asp:DropDownList> </TD></TR><TR><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Label9" runat="server" Width="85px" Text="अवधि देखि" SkinID="Unicodelbl" __designer:wfdid="w101"></asp:Label> </TD><TD style="WIDTH: 290px" vAlign=top><asp:TextBox id="txtEmpLvFrom" runat="server" Width="73px" SkinID="Unicodetxt" ToolTip="बिदा लिने मिति भर्नुहोस्" __designer:wfdid="w102"></asp:TextBox> <asp:Label id="Label22" runat="server" Text="*" __designer:wfdid="w103"></asp:Label> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender11" runat="server" TargetControlID="txtEmpLvFrom" __designer:wfdid="w104" AutoComplete="False" CultureThousandsPlaceholder="" Mask="9999/99/99" CultureDecimalPlaceholder="" MaskType="Date" CultureCurrencySymbolPlaceholder="" Enabled="True" CultureAMPMPlaceholder="" CultureDateFormat="" CultureTimePlaceholder="" CultureDatePlaceholder=""></ajaxToolkit:MaskedEditExtender> </TD><TD style="WIDTH: 115px" vAlign=top><asp:Label id="Label10" runat="server" Width="93px" Text="अवधि सम्म" SkinID="Unicodelbl" __designer:wfdid="w105"></asp:Label> </TD><TD style="WIDTH: 165px" vAlign=top><asp:TextBox id="txtEmpLvTo" runat="server" Width="73px" SkinID="Unicodetxt" ToolTip="बिदा चाहिने दिन सम्मको मिति भर्नुहोस्" __designer:wfdid="w106" AutoPostBack="True" OnTextChanged="txtEmpLvTo_TextChanged"></asp:TextBox> <asp:Label id="Label23" runat="server" Text="*" __designer:wfdid="w107"></asp:Label> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender12" runat="server" TargetControlID="txtEmpLvTo" __designer:wfdid="w108" AutoComplete="False" CultureThousandsPlaceholder="" Mask="9999/99/99" CultureDecimalPlaceholder="" MaskType="Date" CultureCurrencySymbolPlaceholder="" Enabled="True" CultureAMPMPlaceholder="" CultureDateFormat="" CultureTimePlaceholder="" CultureDatePlaceholder=""></ajaxToolkit:MaskedEditExtender> </TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 20px" vAlign=top>&nbsp;<asp:Label id="Label11" runat="server" Text="जम्मा दिन" SkinID="Unicodelbl" __designer:wfdid="w109"></asp:Label> </TD><TD style="WIDTH: 290px; HEIGHT: 20px" vAlign=top><asp:UpdatePanel id="UpdatePanel4" runat="server" __designer:wfdid="w110"><ContentTemplate>
<asp:TextBox id="txtEmpLvDays" runat="server" Width="45px" SkinID="Unicodetxt" ToolTip="जम्मा दिन" MaxLength="3" __designer:wfdid="w111"></asp:TextBox> <ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender3" runat="server" TargetControlID="txtEmpLvDays" __designer:wfdid="w112" Enabled="True" FilterType="Numbers"></ajaxToolkit:FilteredTextBoxExtender> 
</ContentTemplate>
</asp:UpdatePanel> &nbsp; </TD><TD style="WIDTH: 115px; HEIGHT: 20px" vAlign=top>&nbsp;<asp:Label id="lblApplDate" runat="server" Width="90px" Text="निवेदन मिति" SkinID="Unicodelbl" __designer:wfdid="w113"></asp:Label> </TD><TD style="WIDTH: 165px; HEIGHT: 20px" vAlign=top><asp:TextBox id="txtEmpDate" runat="server" Width="73px" SkinID="Unicodetxt" ToolTip="निवेदन दिएको मिति भर्नुहोस्" __designer:wfdid="w114"></asp:TextBox> <asp:Label id="Label24" runat="server" Text="*" __designer:wfdid="w115"></asp:Label> &nbsp;&nbsp; </TD></TR><TR><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Label12" runat="server" Text="कैफियत" SkinID="Unicodelbl" __designer:wfdid="w116"></asp:Label> </TD><TD style="WIDTH: 290px" vAlign=top><asp:TextBox id="txtEmpLvResn" runat="server" Width="278px" Height="98px" SkinID="Unicodetxt" ToolTip="बिदाको कैफिएत भर्नुहोस्" __designer:wfdid="w117" TextMode="MultiLine"></asp:TextBox> </TD><TD style="WIDTH: 115px" vAlign=baseline>&nbsp;</TD><TD style="WIDTH: 165px" vAlign=top></TD></TR><TR><TD style="WIDTH: 100px" vAlign=top></TD><TD style="WIDTH: 290px" vAlign=top><asp:Button id="btnAddApplication" onclick="btnAddApplication_Click" runat="server" Width="50px" Text="Add" SkinID="Add" __designer:wfdid="w118" OnClientClick="return validateSubPart();"></asp:Button> </TD><TD style="WIDTH: 115px" vAlign=baseline></TD><TD style="WIDTH: 165px" vAlign=top></TD></TR><TR><TD style="WIDTH: 100px" vAlign=top></TD><TD style="WIDTH: 290px" vAlign=top><asp:Button id="btnApplSubmit" onclick="btnApplSubmit_Click" runat="server" Text="Submit" SkinID="Normal" __designer:wfdid="w119"></asp:Button> <asp:Button id="btnApplCancel" onclick="btnApplCancel_Click" runat="server" Text="Cancel" SkinID="Cancel" __designer:wfdid="w120"></asp:Button> </TD><TD style="WIDTH: 115px" vAlign=top></TD><TD style="WIDTH: 165px" vAlign=top></TD></TR></TBODY></TABLE><ajaxToolkit:MaskedEditExtender id="MaskedEditExtender10" runat="server" TargetControlID="txtEmpDate" __designer:wfdid="w121" AutoComplete="False" CultureThousandsPlaceholder="" Mask="9999/99/99" CultureDecimalPlaceholder="" MaskType="Date" CultureCurrencySymbolPlaceholder="" Enabled="True" CultureAMPMPlaceholder="" CultureDateFormat="" CultureTimePlaceholder="" CultureDatePlaceholder=""></ajaxToolkit:MaskedEditExtender> &nbsp;&nbsp;&nbsp;&nbsp; 
</ContentTemplate>
<HeaderTemplate>
निवेदन
</HeaderTemplate>
</ajaxToolkit:TabPanel>
<ajaxToolkit:TabPanel runat="server" ID="TabPanel1" HeaderText="सिफारिस गरिएको विवरण"><ContentTemplate>
<BR /><TABLE style="WIDTH: 800px"><TBODY><TR><TD style="WIDTH: 115px" vAlign=top><asp:Label id="Label13" runat="server" Width="102px" Text="जाच्ने कर्मचारी" SkinID="Unicodelbl" __designer:wfdid="w102"></asp:Label> </TD><TD vAlign=top><asp:TextBox id="txtRecName" runat="server" Width="275px" SkinID="Unicodetxt" __designer:wfdid="w103" ReadOnly="True"></asp:TextBox> </TD><TD style="WIDTH: 165px" vAlign=top></TD><TD style="WIDTH: 156px" vAlign=top></TD></TR><TR><TD style="WIDTH: 115px" vAlign=top><asp:Label id="Label14" runat="server" Width="110px" Text="सिफारिस मिति" SkinID="Unicodelbl" __designer:wfdid="w104"></asp:Label> </TD><TD vAlign=top><asp:TextBox id="txtRecDate" runat="server" Width="73px" SkinID="Unicodetxt" ToolTip="सिफारीस गरीएको मिति भर्नुहोस्" __designer:wfdid="w105"></asp:TextBox> <asp:Label id="Label25" runat="server" Text="*" __designer:wfdid="w106"></asp:Label> </TD><TD style="WIDTH: 165px" vAlign=top></TD><TD style="WIDTH: 156px" vAlign=top></TD></TR><TR><TD style="WIDTH: 115px" vAlign=top><asp:Label id="Label15" runat="server" Text="अवधि देखी" SkinID="Unicodelbl" __designer:wfdid="w107"></asp:Label> </TD><TD vAlign=top><asp:TextBox id="txtRecFrom" runat="server" Width="73px" SkinID="Unicodetxt" ToolTip="बिदा सिफारीस देखि भर्नुहोस्" __designer:wfdid="w108"></asp:TextBox> <asp:Label id="Label26" runat="server" Text="*" __designer:wfdid="w109"></asp:Label> </TD><TD style="WIDTH: 165px" vAlign=top><asp:Label id="Label16" runat="server" Text="अवधि सम्म" SkinID="Unicodelbl" __designer:wfdid="w110"></asp:Label> </TD><TD style="WIDTH: 156px" vAlign=top><asp:TextBox id="txtRecTo" runat="server" Width="73px" SkinID="Unicodetxt" ToolTip="बिदा सिफारिस सम्म भर्नुहोस्" __designer:wfdid="w111" AutoPostBack="True" OnTextChanged="txtRecTo_TextChanged"></asp:TextBox> <asp:Label id="Label27" runat="server" Text="*" __designer:wfdid="w112"></asp:Label> </TD></TR><TR><TD style="WIDTH: 115px; HEIGHT: 113px" vAlign=top><asp:Label id="Label17" runat="server" Text="जम्मा दिन" SkinID="Unicodelbl" __designer:wfdid="w113"></asp:Label> </TD><TD style="HEIGHT: 113px" vAlign=top><asp:UpdatePanel id="UpdatePanel5" runat="server" __designer:wfdid="w114"><ContentTemplate>
<asp:TextBox id="txtRecDays" runat="server" Width="35px" SkinID="Unicodetxt" ToolTip="जम्मा दिन" MaxLength="3" __designer:wfdid="w115"></asp:TextBox> <ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender4" runat="server" TargetControlID="txtRecDays" __designer:wfdid="w116" Enabled="True" FilterType="Numbers"></ajaxToolkit:FilteredTextBoxExtender> 
</ContentTemplate>
</asp:UpdatePanel> &nbsp; </TD><TD style="WIDTH: 165px; HEIGHT: 113px" vAlign=top><asp:Label id="Label21" runat="server" Width="160px" Text="सिफारिस गरेको/नगरेको" SkinID="Unicodelbl" __designer:wfdid="w117"></asp:Label> </TD><TD style="WIDTH: 156px; HEIGHT: 113px" vAlign=top><asp:CheckBox id="chkbxRec" runat="server" SkinID="smallChk" __designer:wfdid="w118" OnCheckedChanged="chkbxRec_CheckedChanged"></asp:CheckBox> </TD></TR><TR><TD style="WIDTH: 115px" vAlign=top><asp:Label id="Label19" runat="server" Text="कैफिएत" SkinID="Unicodelbl" __designer:wfdid="w119"></asp:Label> </TD><TD vAlign=top><asp:TextBox id="txtRecReason" runat="server" Width="279px" Height="111px" SkinID="Unicodetxt" ToolTip="बिदा सिफारीसको कैफिएत भर्नुहोस्" __designer:wfdid="w120" TextMode="MultiLine"></asp:TextBox> &nbsp; </TD><TD style="WIDTH: 165px" vAlign=baseline>&nbsp;</TD><TD style="WIDTH: 156px" vAlign=top></TD></TR><TR><TD style="WIDTH: 115px" vAlign=top></TD><TD vAlign=top><asp:Button id="btnAddRecommendation" onclick="btnAddRecommendation_Click" runat="server" Width="50px" Text="Add" SkinID="Add" __designer:wfdid="w121" OnClientClick="return validateRecDate();"></asp:Button> </TD><TD style="WIDTH: 165px" vAlign=baseline></TD><TD style="WIDTH: 156px" vAlign=top></TD></TR><TR><TD style="WIDTH: 115px" vAlign=top></TD><TD vAlign=top><asp:Button id="btnRecSubmit" onclick="btnRecSubmit_Click" runat="server" Text="Submit" SkinID="Normal" __designer:wfdid="w122"></asp:Button> <asp:Button id="btnRecCancel" onclick="btnRecCancel_Click" runat="server" Text="Cancel" SkinID="Cancel" __designer:wfdid="w123"></asp:Button> </TD><TD style="WIDTH: 165px" vAlign=top></TD><TD style="WIDTH: 156px" vAlign=top></TD></TR></TBODY></TABLE><ajaxToolkit:MaskedEditExtender id="MaskedEditExtender7" runat="server" TargetControlID="txtRecFrom" __designer:wfdid="w124" AutoComplete="False" CultureThousandsPlaceholder="" Mask="9999/99/99" CultureDecimalPlaceholder="" MaskType="Date" CultureCurrencySymbolPlaceholder="" Enabled="True" CultureAMPMPlaceholder="" CultureDateFormat="" CultureTimePlaceholder="" CultureDatePlaceholder=""></ajaxToolkit:MaskedEditExtender> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender6" runat="server" TargetControlID="txtRecDate" __designer:wfdid="w125" AutoComplete="False" CultureThousandsPlaceholder="" Mask="9999/99/99" CultureDecimalPlaceholder="" MaskType="Date" CultureCurrencySymbolPlaceholder="" Enabled="True" CultureAMPMPlaceholder="" CultureDateFormat="" CultureTimePlaceholder="" CultureDatePlaceholder=""></ajaxToolkit:MaskedEditExtender> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender8" runat="server" TargetControlID="txtRecTo" __designer:wfdid="w126" AutoComplete="False" CultureThousandsPlaceholder="" Mask="9999/99/99" CultureDecimalPlaceholder="" MaskType="Date" CultureCurrencySymbolPlaceholder="" Enabled="True" CultureAMPMPlaceholder="" CultureDateFormat="" CultureTimePlaceholder="" CultureDatePlaceholder=""></ajaxToolkit:MaskedEditExtender> &nbsp; 
</ContentTemplate>
<HeaderTemplate>
सिफारिस
</HeaderTemplate>
</ajaxToolkit:TabPanel>
</ajaxToolkit:TabContainer> </DIV><BR /><asp:Label id="Label18" runat="server" Text="निवेदनको विवरण:" SkinID="UnicodeHeadlbl" Font-Bold="True" __designer:wfdid="w162"></asp:Label><BR /><BR /><asp:Panel id="Panel2" runat="server" Width="890px" Height="150px" __designer:wfdid="w163" ScrollBars="Auto"><asp:GridView id="grdLeaveApplications" runat="server" Width="1700px" Height="0px" SkinID="Unicodegrd" __designer:wfdid="w164" OnSelectedIndexChanged="grdLeaveApplications_SelectedIndexChanged" OnRowDataBound="grdLeaveApplications_RowDataBound" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333" GridLines="None" OnRowDeleting="grdLeaveApplications_RowDeleting">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:TemplateField ShowHeader="False"><HeaderTemplate>
<asp:CheckBox id="chk" runat="server" OnCheckedChanged="chkHeader_CheckedChanged" AutoPostBack="true" ></asp:CheckBox> 
</HeaderTemplate>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
<ItemTemplate>
<asp:CheckBox id="chk" runat="server" OnCheckedChanged="chk_CheckedChanged" AutoPostBack="true" ></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
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
               <triggers>
<asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
        </asp:UpdatePanel><br />
        &nbsp;<br />
    </div>
</asp:Content>

