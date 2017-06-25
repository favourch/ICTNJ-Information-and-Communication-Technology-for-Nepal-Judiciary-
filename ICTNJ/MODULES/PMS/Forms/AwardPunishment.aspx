<%@ Page Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master" AutoEventWireup="true"
    CodeFile="AwardPunishment.aspx.cs" Inherits="MODULES_PMS_Forms_AwardPunishment"
    Title="PMS | Award" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script language="javascript" src="../../COMMON/JS/DateValidator.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript" defer="defer">
    function validateSubPart()
    {
        var date1='<%= this.txtAwardDate.ClientID%>';
        if(validateDateByControl(date1, true)==false)
        {
            return false;
        }
    }
</script>
    
    <asp:ScriptManager runat="server" ID="sct">
    </asp:ScriptManager>
    <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="programmaticModalPopup" BehaviorID="programmaticModalPopupBehavior"
        TargetControlID="hiddenTargetControlForModalPopup" PopupControlID="programmaticPopup"
        BackgroundCssClass="modalBackground" DropShadow="True" PopupDragHandleControlID="programmaticPopupDragHandle"
        RepositionMode="RepositionOnWindowScroll">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel runat="server" CssClass="modalPopup" ID="programmaticPopup" Style="display: none;
        width: 350px; padding: 10px" Height="140px" Width="134px">
        <asp:Panel runat="Server" ID="programmaticPopupDragHandle" Style="cursor: move; background-color: #DDDDDD;
            border: solid 1px Gray; color: Black; text-align: center;">
            Status
        </asp:Panel>
        <asp:UpdatePanel id="UpdatePanel3" runat="server">
            <contenttemplate>
<BR /><asp:Label id="lblStatusMessage" runat="server" Height="19px" Text="Label" __designer:wfdid="w14"></asp:Label> 
</contenttemplate>
        </asp:UpdatePanel>
        <br />
        <asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click"
            Width="58px" />
        <br />
    </asp:Panel>
    <br />
    &nbsp; &nbsp; &nbsp;&nbsp;
    <asp:Label ID="Label12" runat="server" SkinID="UnicodeHeadlbl" Text="विभुषण"></asp:Label>
    &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<br />
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
       
        <contenttemplate>
<TABLE width=1000><TBODY><TR><TD style="WIDTH: 17px"></TD><TD style="WIDTH: 100px"><DIV style="WIDTH: 938px; CURSOR: hand; HEIGHT: 27px" id="upper" class="collapsePanelHeader">कर्मचारी खोज्नुहोस् </DIV></TD></TR></TBODY></TABLE><BR /><ajaxToolkit:CollapsiblePanelExtender id="CollapsiblePanelExtender1" runat="server" TargetControlID="PanelSearch" __designer:wfdid="w1" CollapseControlID="upper" ExpandControlID="upper" Collapsed="true">
    </ajaxToolkit:CollapsiblePanelExtender> <asp:Panel id="PanelSearch" runat="server" Width="900px" Height="350px" __designer:wfdid="w2"><TABLE width=1000><TBODY><TR><TD style="WIDTH: 17px"></TD><TD style="WIDTH: 126px"><asp:Label id="Label30" runat="server" Width="110px" Height="22px" Text="संकेत नं" SkinID="Unicodelbl" __designer:wfdid="w3"></asp:Label></TD><TD><asp:TextBox id="txtSymbolNo" runat="server" Width="130px" SkinID="Unicodetxt" __designer:wfdid="w4" ToolTip="First Name" MaxLength="15"></asp:TextBox></TD><TD></TD><TD></TD><TD></TD><TD style="WIDTH: 153px"></TD></TR><TR><TD style="WIDTH: 17px"></TD><TD style="WIDTH: 126px"><asp:Label id="Label1" runat="server" Width="92px" Height="22px" Text="पहिलो नाम" SkinID="Unicodelbl" __designer:wfdid="w5"></asp:Label></TD><TD><asp:TextBox id="txtFName" runat="server" Width="130px" SkinID="Unicodetxt" __designer:wfdid="w6" ToolTip="First Name" MaxLength="35"></asp:TextBox></TD><TD><asp:Label id="Label2" runat="server" Width="92px" Height="22px" Text="बिचको नाम" SkinID="Unicodelbl" __designer:wfdid="w7"></asp:Label></TD><TD><asp:TextBox id="txtMName" runat="server" Width="130px" SkinID="Unicodetxt" __designer:wfdid="w8" MaxLength="15"></asp:TextBox></TD><TD><asp:Label id="Label3" runat="server" Width="28px" Height="22px" Text="थर" SkinID="Unicodelbl" __designer:wfdid="w9"></asp:Label></TD><TD style="WIDTH: 153px"><asp:TextBox id="txtSurName" runat="server" Width="130px" SkinID="Unicodetxt" __designer:wfdid="w10" ToolTip="Surname" MaxLength="35"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 17px"></TD><TD style="WIDTH: 126px"><asp:Label id="Label5" runat="server" Width="38px" Height="22px" Text="लिंग" SkinID="Unicodelbl" __designer:wfdid="w11"></asp:Label></TD><TD><asp:DropDownList id="ddlGender" runat="server" Width="135px" SkinID="Unicodeddl" __designer:wfdid="w12">
                    <asp:ListItem Value="SG">छान्नुहोस</asp:ListItem>
                    <asp:ListItem Value="M">पुरुष</asp:ListItem>
                    <asp:ListItem Value="F">महिला</asp:ListItem>
                    <asp:ListItem Value="O">अन्य</asp:ListItem>
                </asp:DropDownList></TD><TD><asp:Label id="Label4" runat="server" Width="110px" Height="22px" Text="जन्म मिति" SkinID="Unicodelbl" __designer:wfdid="w13"></asp:Label></TD><TD><asp:TextBox id="txtDOB" runat="server" Width="130px" SkinID="Unicodetxt" __designer:wfdid="w14" MaxLength="10"></asp:TextBox></TD><TD><asp:Label id="Label6" runat="server" Width="114px" Height="22px" Text="बैबाहिक स्थिति" SkinID="Unicodelbl" __designer:wfdid="w15"></asp:Label></TD><TD style="WIDTH: 153px"><asp:DropDownList id="ddlMarStatus" runat="server" Width="135px" SkinID="Unicodeddl" __designer:wfdid="w16">
                    <asp:ListItem Value="SMS">छान्नुहोस</asp:ListItem>
                    <asp:ListItem Value="S">अबिबाहित</asp:ListItem>
                    <asp:ListItem Value="M">बिबाहित</asp:ListItem>
                    <asp:ListItem Value="W">बिधवा/बिदुर</asp:ListItem>
                    <asp:ListItem Value="D">छोडपत्र</asp:ListItem>
                    <asp:ListItem Value="O">अन्य</asp:ListItem>
                </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 17px; HEIGHT: 24px"></TD><TD style="WIDTH: 126px; HEIGHT: 24px"><asp:Label id="Label7" runat="server" Text="कार्यालय" SkinID="Unicodelbl" __designer:wfdid="w17"></asp:Label></TD><TD style="HEIGHT: 24px" colSpan=3><asp:DropDownList id="ddlOrganization" runat="server" Width="322px" SkinID="Unicodeddl" __designer:wfdid="w18"></asp:DropDownList></TD><TD style="HEIGHT: 24px"><asp:Label id="lblDesignation" runat="server" Text="पद" SkinID="Unicodelbl" __designer:wfdid="w19"></asp:Label></TD><TD style="WIDTH: 153px; HEIGHT: 24px"><asp:DropDownList id="ddlDesignation" runat="server" Width="135px" SkinID="Unicodeddl" __designer:wfdid="w20">
                </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 17px; HEIGHT: 24px"></TD><TD style="WIDTH: 126px; HEIGHT: 24px"></TD><TD style="HEIGHT: 24px" colSpan=3></TD><TD style="HEIGHT: 24px"></TD><TD style="WIDTH: 153px; HEIGHT: 24px"><asp:Button id="btnSearch" onclick="btnSearch_Click" runat="server" Text="Search" SkinID="Normal" __designer:wfdid="w21"></asp:Button><asp:Button id="btnCancel" onclick="btnCancel_Click" runat="server" Text="Cancel" SkinID="Cancel" __designer:wfdid="w22"></asp:Button></TD></TR><TR><TD style="WIDTH: 17px; HEIGHT: 225px" vAlign=top colSpan=1></TD><TD style="HEIGHT: 225px" vAlign=top colSpan=6>
<HR />
&nbsp;<asp:Label id="lblSearch" runat="server" Font-Bold="True" __designer:wfdid="w23"></asp:Label><BR /><asp:Panel id="Panel1" runat="server" Width="900px" Height="150px" __designer:wfdid="w24" ScrollBars="Auto"><asp:GridView id="grdEmployee" runat="server" Width="848px" Height="156px" SkinID="Unicodegrd" __designer:wfdid="w25" OnSelectedIndexChanged="grdEmployee_SelectedIndexChanged" ForeColor="#333333" CellPadding="0" AutoGenerateColumns="False" OnRowCreated="grdEmployee_RowCreated">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="EMPID" HeaderText="आई डी">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="SYMBOLNO" HeaderText="संकेत नं.">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="FIRSTNAME" HeaderText="पहिलो नाम">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="MIDDLENAME" HeaderText="बिचको नाम">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="SURNAME" HeaderText="थर">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="RDFULLNAME" HeaderText="पुरा नाम थर">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="RDGENDER" HeaderText="लिंग">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DOB" HeaderText="जन्म मिति">
<ItemStyle HorizontalAlign="Center" Font-Names="Verdana" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="RDMARITALSTATUS" HeaderText="बैबाहिक सम्बन्ध">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="FATHERNAME" HeaderText="पिताको नाम">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="GFATHERNAME" HeaderText="बाजेको नाम">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DesName" HeaderText="पद">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:CommandField ShowSelectButton="True">
<ItemStyle HorizontalAlign="Center" Font-Names="Verdana" VerticalAlign="Middle"></ItemStyle>
</asp:CommandField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView></asp:Panel><BR />&nbsp;</TD></TR></TBODY></TABLE>
<HR /></asp:Panel><BR /><TABLE width=900><TBODY><TR><TD style="WIDTH: 17px; HEIGHT: 21px" vAlign=top colSpan=1></TD><TD style="HEIGHT: 21px" vAlign=top colSpan=4><asp:Label id="Label10" runat="server" Text="कर्मचारी विभुषण : :" SkinID="UnicodeHeadlbl" __designer:wfdid="w26"></asp:Label> <asp:Label id="lblEmpName" runat="server" SkinID="UnicodeHeadlbl" __designer:wfdid="w27"></asp:Label></TD></TR><TR><TD style="WIDTH: 17px; HEIGHT: 24px" vAlign=top></TD><TD style="WIDTH: 100px; HEIGHT: 24px" vAlign=top><asp:Label id="Label8" runat="server" Text="विभुषण" SkinID="Unicodelbl" __designer:wfdid="w28"></asp:Label></TD><TD style="WIDTH: 280px; HEIGHT: 24px"><asp:TextBox id="txtAwardDesc" runat="server" Width="224px" Height="81px" SkinID="Unicodetxt" __designer:wfdid="w29" TextMode="MultiLine" MaxLength="150"></asp:TextBox></TD><TD style="WIDTH: 40px; HEIGHT: 24px" vAlign=top><asp:Label id="Label11" runat="server" Width="36px" Text="मिति" SkinID="Unicodelbl" __designer:wfdid="w30"></asp:Label> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; </TD><TD style="WIDTH: 464px; HEIGHT: 24px" vAlign=top><asp:TextBox id="txtAwardDate" runat="server" Width="73px" SkinID="Unicodetxt" __designer:wfdid="w31"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender1" runat="server" TargetControlID="txtAwardDate" __designer:wfdid="w32" MaskType="Date" Mask="9999/99/99" AutoComplete="False"></ajaxToolkit:MaskedEditExtender></TD></TR><TR><TD style="WIDTH: 17px; HEIGHT: 27px" vAlign=top></TD><TD style="WIDTH: 100px; HEIGHT: 27px" vAlign=top><asp:Label id="Label9" runat="server" Text="कै‍फिएत" SkinID="Unicodelbl" __designer:wfdid="w33"></asp:Label></TD><TD style="WIDTH: 280px; HEIGHT: 27px" vAlign=top><asp:TextBox id="txtAwardRemarks" runat="server" Width="225px" Height="53px" SkinID="Unicodetxt" __designer:wfdid="w34" TextMode="MultiLine"></asp:TextBox></TD><TD style="WIDTH: 40px; HEIGHT: 27px" vAlign=bottom><asp:Button id="btnAwardAdd" onclick="btnAwardAdd_Click" runat="server" Width="50px" Text="Add" SkinID="Add" __designer:wfdid="w35" OnClientClick="return validateSubPart();"></asp:Button></TD><TD style="WIDTH: 464px; HEIGHT: 27px"></TD></TR><TR><TD style="WIDTH: 17px" colSpan=1></TD><TD colSpan=4>
<HR />
</TD></TR><TR><TD style="WIDTH: 17px; HEIGHT: 99px" vAlign=top colSpan=1></TD><TD style="HEIGHT: 99px" vAlign=top colSpan=4><asp:Panel id="Panel2" runat="server" Width="700px" Height="150px" __designer:wfdid="w36" ScrollBars="Auto"><asp:GridView id="grdAward" runat="server" Width="700px" Height="50px" SkinID="Unicodegrd" __designer:wfdid="w37" OnRowCreated="grdAward_RowCreated" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333" OnSelectedIndexChanged="grdAward_SelectedIndexChanged" OnRowDeleting="grdAward_RowDeleting" GridLines="None" OnRowDataBound="grdAward_RowDataBound">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="EmpID" HeaderText="EmpID">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="SequenceNo" HeaderText="क्र.सं">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="EmpName" HeaderText="कर्मचारीको नाम">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Award" HeaderText="विभुषण">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="AwardDate" HeaderText="विभुषण मिति">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Remarks" HeaderText="विभुषण कैफिएत">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Action" HeaderText="Action">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:TemplateField ShowHeader="False">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
<ItemTemplate>
<asp:LinkButton runat="server" Text="Select" CommandName="Select" CausesValidation="False" id="btnSelect"></asp:LinkButton>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField ShowHeader="False"><ItemTemplate>
<asp:LinkButton runat="server" Text="Delete" CommandName="Delete" CausesValidation="False" id="btnDeleteAward"></asp:LinkButton>
</ItemTemplate>
</asp:TemplateField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView></asp:Panel> </TD></TR><TR><TD style="WIDTH: 17px" colSpan=1></TD><TD colSpan=4><asp:Button id="btnSubmit" onclick="btnSubmit_Click" runat="server" Text="Submit" SkinID="Normal" __designer:wfdid="w38"></asp:Button> <asp:Button id="Cancel" onclick="Cancel_Click" runat="server" Text="Cancel" SkinID="Cancel" __designer:wfdid="w39"></asp:Button></TD></TR></TBODY></TABLE>
</contenttemplate>
        <triggers>
<asp:PostBackTrigger ControlID="grdAward"></asp:PostBackTrigger>
</triggers>
    </asp:UpdatePanel>
    <br />
    &nbsp;<br />
    <br />
</asp:Content>
