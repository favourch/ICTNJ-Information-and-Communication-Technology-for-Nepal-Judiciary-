<%@ Page Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master" AutoEventWireup="true" CodeFile="Retirement.aspx.cs" Inherits="MODULES_PMS_Forms_Retirement" Title="PMS | Retirement" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript" src="../../COMMON/JS/jquery.min.js"></script>
    <script type="text/javascript" src="../../COMMON/JS/scrolltopcontrol.js"></script>  
    <script language="javascript" src="../../COMMON/JS/DateValidator.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" defer="defer">
    function validateTab1()
    {
        var date1='<%= this.txtRetirementAppDate.ClientID%>';
        if(validateDateByControl(date1, true)==false)
        {
            return false;
        }
        return true;
    }
    function validateTab2()
    {
        var date2='<%= this.txtDecDate.ClientID%>';
        if(validateDateByControl(date2, true)==false)
        {
            return false;
        }
        return true;
    }
    function validateTab3()
    {
        var date3='<%= this.txtApprDate.ClientID%>';
        if(validateDateByControl(date3, true)==false)
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

<asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click" Width="58px" />           <br />
        </asp:Panel>

    <asp:Label ID="Label20" runat="server" SkinID="UnicodeHeadlbl" Text="अवकास" Width="54px"></asp:Label><br />

    <div id="upper" style="width: 938px; cursor: hand; height: 27px" class="collapsePanelHeader">
    कर्मचारी खोज्नुहोस्
    </div>
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<ajaxToolkit:CollapsiblePanelExtender id="CollapsiblePanelExtender1" runat="server" SkinID="CollapsiblePanelDemo" TargetControlID="PanelSearch" SuppressPostBack="true" ExpandControlID="upper" Collapsed="true" CollapseControlID="upper">
    </ajaxToolkit:CollapsiblePanelExtender> <asp:Panel id="PanelSearch" runat="server" Width="900px" Height="50px"><TABLE width=900><TBODY><TR><TD style="WIDTH: 126px; HEIGHT: 26px"><asp:Label id="Label1" runat="server" Width="92px" Height="22px" Text="पहिलो नाम" SkinID="Unicodelbl"></asp:Label></TD><TD style="HEIGHT: 26px"><asp:TextBox id="txtFName" runat="server" Width="130px" SkinID="Unicodetxt" ToolTip="First Name" MaxLength="35"></asp:TextBox></TD><TD style="HEIGHT: 26px"><asp:Label id="Label2" runat="server" Width="92px" Height="22px" Text="बिचको नाम" SkinID="Unicodelbl"></asp:Label></TD><TD style="HEIGHT: 26px"><asp:TextBox id="txtMName" runat="server" Width="130px" SkinID="Unicodetxt" MaxLength="15"></asp:TextBox></TD><TD style="HEIGHT: 26px"><asp:Label id="Label3" runat="server" Width="33px" Height="22px" Text="थर" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 153px; HEIGHT: 26px"><asp:TextBox id="txtSurName" runat="server" Width="130px" SkinID="Unicodetxt" ToolTip="Surname" MaxLength="35"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 126px"><asp:Label id="Label5" runat="server" Width="34px" Height="22px" Text="लिंग" SkinID="Unicodelbl"></asp:Label></TD><TD><asp:DropDownList id="ddlGender" runat="server" Width="135px" SkinID="Unicodeddl">
                    <asp:ListItem Value="SG">छान्नुहोस</asp:ListItem>
                    <asp:ListItem Value="M">पुरुष</asp:ListItem>
                    <asp:ListItem Value="F">महिला</asp:ListItem>
                    <asp:ListItem Value="O">अन्य</asp:ListItem>
                </asp:DropDownList></TD><TD><asp:Label id="Label4" runat="server" Width="84px" Height="22px" Text="जन्म मिति" SkinID="Unicodelbl"></asp:Label></TD><TD><asp:TextBox id="txtDOB" runat="server" Width="130px" SkinID="Unicodetxt" MaxLength="10"></asp:TextBox></TD><TD><asp:Label id="Label6" runat="server" Width="114px" Height="22px" Text="बैबाहिक स्थिति" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 153px"><asp:DropDownList id="ddlMarStatus" runat="server" Width="135px" SkinID="Unicodeddl">
                    <asp:ListItem Value="SMS">छान्नुहोस</asp:ListItem>
                    <asp:ListItem Value="S">अबिबाहित</asp:ListItem>
                    <asp:ListItem Value="M">बिबाहित</asp:ListItem>
                    <asp:ListItem Value="W">बिधवा/बिदुर</asp:ListItem>
                    <asp:ListItem Value="D">छोडपत्र</asp:ListItem>
                    <asp:ListItem Value="O">अन्य</asp:ListItem>
                </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 126px; HEIGHT: 24px"><asp:Label id="Label7" runat="server" Text="कार्यालय" SkinID="Unicodelbl"></asp:Label></TD><TD style="HEIGHT: 24px" colSpan=3><asp:DropDownList id="ddlOrganization" runat="server" Width="448px" SkinID="Unicodeddl"></asp:DropDownList></TD><TD style="HEIGHT: 24px"><asp:Label id="lblDesignation" runat="server" Text="पद" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 153px; HEIGHT: 24px"><asp:DropDownList id="ddlDesignation" runat="server" Width="135px" SkinID="Unicodeddl">
                </asp:DropDownList></TD></TR><TR><TD style="HEIGHT: 26px" align=left colSpan=6><asp:Button id="btnSearch" onclick="btnSearch_Click" runat="server" Text="Search" SkinID="Normal"></asp:Button><asp:Button id="btnCancel" onclick="btnCancel_Click" runat="server" Text="Cancel" SkinID="Cancel"></asp:Button></TD></TR><TR><TD style="HEIGHT: 202px" vAlign=top colSpan=6>
<HR />
&nbsp;<asp:Label id="lblSearch" runat="server" Font-Bold="True"></asp:Label><BR /><asp:Panel id="Panel1" runat="server" Width="890px" Height="150px" ScrollBars="Auto"><asp:GridView id="grdEmployee" runat="server" Width="848px" SkinID="Unicodegrd" ForeColor="#333333" CellPadding="0" AutoGenerateColumns="False" OnRowDataBound="grdEmployee_RowDataBound" OnSelectedIndexChanged="grdEmployee_SelectedIndexChanged">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="empID" HeaderText="आई डी">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="orgID" HeaderText="ORG ID"></asp:BoundField>
<asp:BoundField DataField="orgName" HeaderText="कार्यालय">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fullName" HeaderText="पुरा नाम थर">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="sex" HeaderText="लिंग">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="dob" HeaderText="जन्म मिति">
<ItemStyle HorizontalAlign="Center" Font-Names="Verdana" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="maritalStatus" HeaderText="बैबाहिक सम्बन्ध">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="desID" HeaderText="DES ID"></asp:BoundField>
<asp:BoundField DataField="desType" HeaderText="DES TYPE"></asp:BoundField>
<asp:BoundField DataField="desName" HeaderText="पद">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="postID" HeaderText="POST ID"></asp:BoundField>
<asp:BoundField DataField="createdDate" HeaderText="CREATED DATE"></asp:BoundField>
<asp:BoundField DataField="fromDate" HeaderText="FROM DATE"></asp:BoundField>
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
</asp:GridView></asp:Panel></TD></TR></TBODY></TABLE></asp:Panel> <TABLE width=900><TBODY><TR><TD style="WIDTH: 100px; HEIGHT: 10px"><TABLE><TBODY><TR><TD style="WIDTH: 180px"><asp:Label id="Label18" runat="server" Text="अवकास विवरण : :" SkinID="UnicodeHeadlbl" width="165px"></asp:Label></TD><TD style="WIDTH: 303px"><asp:Label id="lblEmpName" runat="server" Width="98px" SkinID="UnicodeHeadlbl"></asp:Label></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="WIDTH: 100px"><ajaxToolkit:TabContainer id="TabContainerRetirement" runat="server" CssClass="ajax_tab_theme" Width="900px" Height="200px" AutoPostBack="True" ActiveTabIndex="2" OnActiveTabChanged="TabContainerRetirement_ActiveTabChanged"><ajaxToolkit:TabPanel runat="server" ID="TabPanel1" HeaderText="TabPanel1"><ContentTemplate>
<TABLE width=900><TBODY><TR><TD style="WIDTH: 130px; HEIGHT: 25px" vAlign=top><asp:Label id="Label8" runat="server" Text="निवेदन मिति" SkinID="Unicodelbl"></asp:Label> </TD><TD style="WIDTH: 160px; HEIGHT: 25px" vAlign=top><asp:TextBox id="txtRetirementAppDate" runat="server" Width="73px" SkinID="Unicodetxt" ToolTip="अवकास लिने मिति भर्नुहोस्"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender1" runat="server" TargetControlID="txtRetirementAppDate" AutoComplete="False" CultureThousandsPlaceholder="" Mask="9999/99/99" CultureDecimalPlaceholder="" MaskType="Date" CultureCurrencySymbolPlaceholder="" Enabled="True" CultureAMPMPlaceholder="" CultureDateFormat="" CultureTimePlaceholder="" CultureDatePlaceholder=""></ajaxToolkit:MaskedEditExtender> </TD><TD style="WIDTH: 55px; HEIGHT: 25px" vAlign=top><asp:Label id="Label9" runat="server" Text="आफै" SkinID="Unicodelbl"></asp:Label> </TD><TD style="HEIGHT: 25px" vAlign=top><asp:RadioButtonList id="rdoRetSelfYesNo" runat="server" Width="137px" Height="23px" SkinID="Unicoderadio" AutoPostBack="True" OnSelectedIndexChanged="rdoRetSelfYesNo_SelectedIndexChanged" RepeatDirection="Horizontal"><asp:ListItem Selected="True" Value="0">हो</asp:ListItem>
<asp:ListItem Value="1">होइन</asp:ListItem>
</asp:RadioButtonList> </TD></TR><TR><TD style="WIDTH: 130px" vAlign=top><asp:Label id="Label10" runat="server" Width="126px" Text="अवकासको किसिम" SkinID="Unicodelbl"></asp:Label> </TD><TD style="WIDTH: 160px" vAlign=top><asp:DropDownList id="ddlEmpRetirementType" runat="server" Width="155px" SkinID="Unicodeddl"><asp:ListItem Value="०">छान्नुहोस्</asp:ListItem>
<asp:ListItem Value="1">By Age</asp:ListItem>
<asp:ListItem Value="2">By Service Period</asp:ListItem>
</asp:DropDownList> </TD><TD style="WIDTH: 55px" vAlign=top><asp:Label id="Label11" runat="server" Width="55px" Text="कैफियत" SkinID="Unicodelbl"></asp:Label> </TD><TD vAlign=top><asp:TextBox id="RetirementDescription" runat="server" Width="233px" Height="91px" SkinID="Unicodetxt" ToolTip="अवकासको कैफियत भर्नुहोस्" TextMode="MultiLine"></asp:TextBox> &nbsp; </TD></TR><TR><TD style="WIDTH: 130px" vAlign=top></TD><TD style="WIDTH: 160px" vAlign=top></TD><TD style="WIDTH: 55px" vAlign=top></TD><TD vAlign=top><asp:Button id="btnAddApplication" onclick="btnAddApplication_Click" runat="server" Text="Add" SkinID="Add" OnClientClick="validateTab1();"></asp:Button> .</TD></TR><TR><TD style="HEIGHT: 26px" vAlign=top colSpan=4><asp:Button id="btnSubmit" onclick="btnSubmit_Click" runat="server" Text="Submit" SkinID="Normal"></asp:Button> <asp:Button id="Button3" runat="server" Text="Cancel" SkinID="Cancel"></asp:Button> </TD></TR></TBODY></TABLE>
</ContentTemplate>
<HeaderTemplate>
                                अवकास निवेदन
                            
</HeaderTemplate>
</ajaxToolkit:TabPanel>
<ajaxToolkit:TabPanel runat="server" ID="TabPanel2" HeaderText="TabPanel2"><ContentTemplate>
<TABLE width=900><TBODY><TR><TD style="WIDTH: 125px" vAlign=top><asp:Label id="Label12" runat="server" Width="120px" Text="निर्णय गर्ने व्यक्ति" SkinID="Unicodelbl" __designer:wfdid="w259"></asp:Label> </TD><TD vAlign=top colSpan=3><asp:TextBox id="txtDecName" runat="server" Width="250px" SkinID="Unicodetxt" ReadOnly="True" __designer:wfdid="w260"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 125px" vAlign=top><asp:Label id="Label13" runat="server" Text="निर्णय मिति" SkinID="Unicodelbl" __designer:wfdid="w261"></asp:Label> </TD><TD style="WIDTH: 266px" vAlign=top><asp:TextBox id="txtDecDate" runat="server" Width="73px" SkinID="Unicodetxt" ToolTip="निर्णय मिति भर्नुहोस्" __designer:wfdid="w262"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender2" runat="server" TargetControlID="txtDecDate" AutoComplete="False" CultureThousandsPlaceholder="" Mask="9999/99/99" CultureDecimalPlaceholder="" MaskType="Date" CultureCurrencySymbolPlaceholder="" Enabled="True" CultureAMPMPlaceholder="" CultureDateFormat="" CultureTimePlaceholder="" CultureDatePlaceholder="" __designer:wfdid="w263"></ajaxToolkit:MaskedEditExtender> </TD><TD style="WIDTH: 60px" vAlign=top><asp:Label id="Label14" runat="server" Width="55px" Text="कैफियत" SkinID="Unicodelbl" __designer:wfdid="w264"></asp:Label> </TD><TD vAlign=top><asp:TextBox id="txtDecDexcription" runat="server" Width="233px" Height="91px" SkinID="Unicodetxt" ToolTip="कैफिएत भर्नुहोस्" TextMode="MultiLine" __designer:wfdid="w265"></asp:TextBox> &nbsp; </TD></TR><TR><TD style="WIDTH: 125px" vAlign=top><asp:Label id="Label19" runat="server" Width="140px" Text="निर्णय गरेको/नगरेको" SkinID="Unicodelbl" __designer:wfdid="w266"></asp:Label> </TD><TD style="WIDTH: 266px" vAlign=top><asp:CheckBox id="chkDecision" runat="server" SkinID="smallChk" __designer:wfdid="w267"></asp:CheckBox> </TD><TD style="WIDTH: 60px" vAlign=top></TD><TD vAlign=top><asp:Button id="btnAddDecision" onclick="btnAddDecision_Click" runat="server" Text="Add" SkinID="Add" OnClientClick="validateTab2();" __designer:wfdid="w268"></asp:Button> </TD></TR><TR><TD vAlign=top colSpan=4><asp:Button id="btnSubmit2" onclick="btnSubmit2_Click" runat="server" Text="Submit" SkinID="Normal" __designer:wfdid="w269"></asp:Button> <asp:Button id="btnCancel2" runat="server" Text="Cancel" SkinID="Cancel" __designer:wfdid="w270"></asp:Button> </TD></TR></TBODY></TABLE>
</ContentTemplate>
<HeaderTemplate>
                                अवकास निर्णय
                            
</HeaderTemplate>
</ajaxToolkit:TabPanel>
<ajaxToolkit:TabPanel runat="server" ID="TabPanel3" HeaderText="TabPanel3"><ContentTemplate>
<TABLE width=900><TBODY><TR><TD style="WIDTH: 135px" vAlign=top><asp:Label id="Label15" runat="server" Width="133px" Text="प्रमाणित गर्ने व्यक्ति" SkinID="Unicodelbl" __designer:wfdid="w283"></asp:Label> </TD><TD vAlign=top colSpan=3><asp:TextBox id="txtApprName" runat="server" Width="250px" SkinID="Unicodetxt" ReadOnly="True" __designer:wfdid="w284"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 135px" vAlign=top><asp:Label id="Label16" runat="server" Width="102px" Text="प्रमाणित मिति" SkinID="Unicodelbl" __designer:wfdid="w285"></asp:Label> </TD><TD style="WIDTH: 271px" vAlign=top><asp:TextBox id="txtApprDate" runat="server" Width="73px" SkinID="Unicodetxt" ToolTip="प्रमाणित भएको मिति भर्नुहोस्" __designer:wfdid="w286"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender3" runat="server" TargetControlID="txtApprDate" AutoComplete="False" CultureThousandsPlaceholder="" Mask="9999/99/99" CultureDecimalPlaceholder="" MaskType="Date" CultureCurrencySymbolPlaceholder="" Enabled="True" CultureAMPMPlaceholder="" CultureDateFormat="" CultureTimePlaceholder="" CultureDatePlaceholder="" __designer:wfdid="w287"></ajaxToolkit:MaskedEditExtender> </TD><TD style="WIDTH: 60px" vAlign=top><asp:Label id="Label17" runat="server" Width="55px" Text="कैफियत" SkinID="Unicodelbl" __designer:wfdid="w288"></asp:Label> </TD><TD vAlign=top><asp:TextBox id="txtApprDescription" runat="server" Width="233px" Height="91px" SkinID="Unicodetxt" ToolTip="कैफियत भर्नुहोस्" TextMode="MultiLine" __designer:wfdid="w289"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 135px" vAlign=top><asp:Label id="Label21" runat="server" Width="182px" Text="प्रमाणिकरण गरेको/नगरेको" SkinID="Unicodelbl" __designer:wfdid="w290"></asp:Label> </TD><TD style="WIDTH: 271px" vAlign=top><asp:CheckBox id="chkApprove" runat="server" SkinID="smallChk" __designer:wfdid="w291"></asp:CheckBox> </TD><TD style="WIDTH: 60px" vAlign=top></TD><TD vAlign=top><asp:Button id="btnAddApprove" onclick="btnAddApprove_Click" runat="server" Text="Add" SkinID="Add" OnClientClick="validateTab3();" __designer:wfdid="w292"></asp:Button> </TD></TR><TR><TD vAlign=top colSpan=4><asp:Button id="btnSubmit3" onclick="btnSubmit3_Click" runat="server" Text="Submit" SkinID="Normal" __designer:wfdid="w293"></asp:Button> <asp:Button id="btnCancel3" runat="server" Text="Cancel" SkinID="Cancel" __designer:wfdid="w294"></asp:Button> </TD></TR></TBODY></TABLE>
</ContentTemplate>
<HeaderTemplate>
                                अवकास प्रमाणिकरण
                            
</HeaderTemplate>
</ajaxToolkit:TabPanel>
</ajaxToolkit:TabContainer> 
<HR style="WIDTH: 893px" />
</TD></TR><TR><TD style="WIDTH: 100px"><asp:Panel id="PnlRetirementData" runat="server" Width="900px" Height="200px" ScrollBars="Auto"><asp:GridView id="grdRetirementData" runat="server" Width="900px" OnSelectedIndexChanged="grdRetirementData_SelectedIndexChanged" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333" GridLines="None">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:TemplateField ShowHeader="False"><HeaderTemplate>
                                    <asp:CheckBox id="chk" runat="server" OnCheckedChanged="chkHeader_CheckedChanged" AutoPostBack="true" ></asp:CheckBox> 
                                
</HeaderTemplate>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
<ItemTemplate>
                                    <asp:CheckBox id="chk" runat="server" OnCheckedChanged="chk_CheckedChanged" AutoPostBack="true" HorizontalAlign="Center" VerticalAlign="Middle"></asp:CheckBox> 
                                
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="empID" HeaderText="EmpID"></asp:BoundField>
<asp:BoundField DataField="orgID" HeaderText="OrgID">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="desID" HeaderText="DesID">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="postID" HeaderText="PostID">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="retirementDate" HeaderText="निवेदन मिति">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="YesNo" HeaderText="आफै(हो/होइन)">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="retirementType" HeaderText="अवकासको किसिम">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ApplDesc" HeaderText="कैफिएत"></asp:BoundField>
<asp:BoundField DataField="decisionDate" HeaderText="निर्णय मिति">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="decisionBy" HeaderText="निर्णय">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="decisionDesc" HeaderText="कैफियत">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DecidedYesNo" HeaderText="निर्णय भएको/नभएको">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="appDate" HeaderText="स्विर्कत मिति">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="appBy" HeaderText="स्विर्कति">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="appDesc" HeaderText="कैफियत">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ApprovedYesNo" HeaderText="स्विर्कति भएको/नभएको">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="action" HeaderText="Action">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:CommandField ShowSelectButton="True"></asp:CommandField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> </asp:Panel> 
<HR style="WIDTH: 901px" />
</TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 12px"></TD></TR></TBODY></TABLE>
</contenttemplate>
    </asp:UpdatePanel>
    <br />
    &nbsp;<br />
    <br />
</asp:Content>
