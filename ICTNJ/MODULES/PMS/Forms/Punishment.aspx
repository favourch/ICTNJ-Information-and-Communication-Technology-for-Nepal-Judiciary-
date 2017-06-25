<%@ Page Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master" AutoEventWireup="true" CodeFile="Punishment.aspx.cs" Inherits="MODULES_PMS_Forms_Punishment" Title="PMS | Punishment" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" src="../../COMMON/JS/DateValidator.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript" defer="defer">
    function validateSubPart()
    {
        var date1='<%= this.txtpunishmentDate.ClientID%>';
        if(validateDateByControl(date1, true)==false)
        {
            return false;
        }
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
                Status
            </asp:Panel>
                
            <asp:UpdatePanel id="UpdatePanel3" runat="server">
                <contenttemplate>
                    <br />
                    <asp:Label ID="lblStatusMessage" runat="server" Height="19px" Text="Label"></asp:Label>
                </contenttemplate>
            </asp:UpdatePanel>
            <br />
                <asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click" Width="58px" />    
             <br />
        </asp:Panel>
    <br />
    <asp:Label ID="Label8" runat="server" SkinID="UnicodeHeadlbl" Text="सजाय"></asp:Label><br />
    <br />
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<DIV style="WIDTH: 938px; CURSOR: hand; HEIGHT: 27px" id="upper" class="collapsePanelHeader">कर्मचारी खोज्नुहोस् </DIV><ajaxToolkit:CollapsiblePanelExtender id="CollapsiblePanelExtender1" runat="server" TargetControlID="PanelSearch" __designer:wfdid="w40" Collapsed="true" CollapseControlID="upper" ExpandControlID="upper"></ajaxToolkit:CollapsiblePanelExtender> <asp:Panel id="PanelSearch" runat="server" Width="900px" Height="350px" __designer:wfdid="w41"><TABLE width=900><TBODY><TR><TD style="WIDTH: 126px"><asp:Label id="Label30" runat="server" Width="89px" Height="22px" Text="संकेत नं" SkinID="Unicodelbl" __designer:wfdid="w42"></asp:Label></TD><TD><asp:TextBox id="txtSymbolNo" runat="server" Width="130px" SkinID="Unicodetxt" __designer:wfdid="w43" MaxLength="15" ToolTip="First Name"></asp:TextBox></TD><TD></TD><TD></TD><TD></TD><TD style="WIDTH: 153px"></TD></TR><TR><TD style="WIDTH: 126px"><asp:Label id="Label1" runat="server" Width="92px" Height="22px" Text="पहिलो नाम" SkinID="Unicodelbl" __designer:wfdid="w44"></asp:Label></TD><TD><asp:TextBox id="txtFName" runat="server" Width="130px" SkinID="Unicodetxt" __designer:wfdid="w45" MaxLength="35" ToolTip="First Name"></asp:TextBox></TD><TD><asp:Label id="Label2" runat="server" Width="92px" Height="22px" Text="बिचको नाम" SkinID="Unicodelbl" __designer:wfdid="w46"></asp:Label></TD><TD><asp:TextBox id="txtMName" runat="server" Width="130px" SkinID="Unicodetxt" __designer:wfdid="w47" MaxLength="15"></asp:TextBox></TD><TD><asp:Label id="Label3" runat="server" Width="92px" Height="22px" Text="थर" SkinID="Unicodelbl" __designer:wfdid="w48"></asp:Label></TD><TD style="WIDTH: 153px"><asp:TextBox id="txtSurName" runat="server" Width="130px" SkinID="Unicodetxt" __designer:wfdid="w49" MaxLength="35" ToolTip="Surname"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 126px"><asp:Label id="Label5" runat="server" Width="92px" Height="22px" Text="लिंग" SkinID="Unicodelbl" __designer:wfdid="w50"></asp:Label></TD><TD><asp:DropDownList id="ddlGender" runat="server" Width="135px" SkinID="Unicodeddl" __designer:wfdid="w51">
                    <asp:ListItem Value="SG">छान्नुहोस</asp:ListItem>
                    <asp:ListItem Value="M">पुरुष</asp:ListItem>
                    <asp:ListItem Value="F">महिला</asp:ListItem>
                    <asp:ListItem Value="O">अन्य</asp:ListItem>
                </asp:DropDownList></TD><TD><asp:Label id="Label4" runat="server" Width="110px" Height="22px" Text="जन्म मिति" SkinID="Unicodelbl" __designer:wfdid="w52"></asp:Label></TD><TD><asp:TextBox id="txtDOB" runat="server" Width="130px" SkinID="Unicodetxt" __designer:wfdid="w53" MaxLength="10"></asp:TextBox></TD><TD><asp:Label id="Label6" runat="server" Width="114px" Height="22px" Text="बैबाहिक स्थिति" SkinID="Unicodelbl" __designer:wfdid="w54"></asp:Label></TD><TD style="WIDTH: 153px"><asp:DropDownList id="ddlMarStatus" runat="server" Width="135px" SkinID="Unicodeddl" __designer:wfdid="w55">
                    <asp:ListItem Value="SMS">छान्नुहोस</asp:ListItem>
                    <asp:ListItem Value="S">अबिबाहित</asp:ListItem>
                    <asp:ListItem Value="M">बिबाहित</asp:ListItem>
                    <asp:ListItem Value="W">बिधवा/बिदुर</asp:ListItem>
                    <asp:ListItem Value="D">छोडपत्र</asp:ListItem>
                    <asp:ListItem Value="O">अन्य</asp:ListItem>
                </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 126px; HEIGHT: 24px"><asp:Label id="Label7" runat="server" Text="कार्यालय" SkinID="Unicodelbl" __designer:wfdid="w56"></asp:Label></TD><TD style="HEIGHT: 24px" colSpan=3><asp:DropDownList id="ddlOrganization" runat="server" Width="458px" SkinID="Unicodeddl" __designer:wfdid="w57">
                </asp:DropDownList></TD><TD style="HEIGHT: 24px"><asp:Label id="lblDesignation" runat="server" Text="पद" SkinID="Unicodelbl" __designer:wfdid="w58"></asp:Label></TD><TD style="WIDTH: 153px; HEIGHT: 24px"><asp:DropDownList id="ddlDesignation" runat="server" Width="135px" SkinID="Unicodeddl" __designer:wfdid="w59">
                </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 126px; HEIGHT: 24px"></TD><TD style="HEIGHT: 24px" colSpan=3></TD><TD style="HEIGHT: 24px"></TD><TD style="WIDTH: 153px; HEIGHT: 24px"><asp:Button id="btnSearch" onclick="btnSearch_Click" runat="server" Text="Search" SkinID="Normal" __designer:wfdid="w60"></asp:Button> <asp:Button id="btnCancel" onclick="btnCancel_Click" runat="server" Text="Cancel" SkinID="Cancel" __designer:wfdid="w61"></asp:Button></TD></TR><TR><TD style="HEIGHT: 306px" vAlign=top colSpan=6>
<HR />
&nbsp;<asp:Label id="lblSearch" runat="server" Font-Bold="True" __designer:wfdid="w62"></asp:Label><asp:Panel id="Panel1" runat="server" Width="890px" Height="208px" __designer:wfdid="w63" ScrollBars="Auto"><asp:GridView id="grdEmployee" runat="server" Width="848px" Height="93px" SkinID="Unicodegrd" __designer:wfdid="w64" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333" OnSelectedIndexChanged="grdEmployee_SelectedIndexChanged" OnRowCreated="grdEmployee_RowCreated">
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
                    </asp:GridView> </asp:Panel> </TD></TR></TBODY></TABLE>&nbsp; </asp:Panel> 
<HR />
&nbsp;<BR /><TABLE width=900><TBODY><TR><TD style="HEIGHT: 23px" colSpan=4><asp:Label id="Label11" runat="server" Text="कर्मचारी सजाय : :" SkinID="UnicodeHeadlbl" __designer:wfdid="w65"></asp:Label><asp:Label id="lblEmpName" runat="server" SkinID="UnicodeHeadlbl" __designer:wfdid="w66"></asp:Label></TD></TR><TR><TD style="WIDTH: 45px; HEIGHT: 35px" vAlign=top><asp:Label id="Label12" runat="server" Width="45px" Text="सजाय" SkinID="Unicodelbl" __designer:wfdid="w67"></asp:Label></TD><TD style="WIDTH: 311px; HEIGHT: 35px" vAlign=top><asp:TextBox id="txtPunishment" runat="server" Width="230px" Height="75px" SkinID="Unicodetxt" __designer:wfdid="w68" TextMode="MultiLine"></asp:TextBox></TD><TD style="WIDTH: 37px; HEIGHT: 35px" vAlign=top><asp:Label id="Label9" runat="server" Text="मिति" SkinID="Unicodelbl" __designer:wfdid="w69"></asp:Label></TD><TD style="HEIGHT: 35px" vAlign=top><asp:TextBox id="txtpunishmentDate" runat="server" Width="73px" __designer:wfdid="w70"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender1" runat="server" TargetControlID="txtpunishmentDate" __designer:wfdid="w71" AutoComplete="False" Mask="9999/99/99" MaskType="Date"></ajaxToolkit:MaskedEditExtender></TD></TR><TR><TD style="WIDTH: 45px; HEIGHT: 20px" vAlign=top><asp:Label id="Label14" runat="server" Text="कैफिएत" SkinID="Unicodelbl" __designer:wfdid="w72"></asp:Label></TD><TD style="WIDTH: 311px; HEIGHT: 20px" vAlign=top><asp:TextBox id="txtPunishmentRemarks" runat="server" Width="231px" Height="53px" SkinID="Unicodetxt" __designer:wfdid="w73" TextMode="MultiLine"></asp:TextBox> </TD><TD style="WIDTH: 37px; HEIGHT: 20px" vAlign=bottom><asp:Button id="btnPunishmentAdd" onclick="btnPunishmentAdd_Click" runat="server" Width="50px" Text="Add" SkinID="Add" __designer:wfdid="w74" OnClientClick="return validateSubPart();"></asp:Button></TD><TD style="HEIGHT: 20px" vAlign=top></TD></TR><TR><TD style="HEIGHT: 97px" vAlign=top colSpan=4>
<HR />
&nbsp;<asp:Panel id="Panel2" runat="server" Width="700px" Height="150px" __designer:wfdid="w75" ScrollBars="Auto"><asp:GridView id="grdpunishment" runat="server" Width="700px" Height="150px" SkinID="Unicodegrd" __designer:wfdid="w76" OnRowCreated="grdpunishment_RowCreated" OnSelectedIndexChanged="grdpunishment_SelectedIndexChanged" ForeColor="#333333" CellPadding="0" AutoGenerateColumns="False" GridLines="None" OnRowDataBound="grdpunishment_RowDataBound" OnRowDeleting="grdpunishment_RowDeleting">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="EmpID" HeaderText="EmpID"></asp:BoundField>
<asp:BoundField DataField="SequenceNo" HeaderText="क्र.सं"></asp:BoundField>
<asp:BoundField DataField="Punishment" HeaderText="सजाय"></asp:BoundField>
<asp:BoundField DataField="PunishmentDate" HeaderText="सजाय मिति"></asp:BoundField>
<asp:BoundField DataField="PunishmentRemarks" HeaderText="कैफियत"></asp:BoundField>
<asp:BoundField DataField="Action" HeaderText="Action"></asp:BoundField>
<asp:TemplateField ShowHeader="False"><ItemTemplate>
<asp:LinkButton runat="server" Text="Select" CommandName="Select" CausesValidation="False" id="btnSelect"></asp:LinkButton>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField><ItemTemplate>
                <asp:LinkButton ID="btnDeletePunishment" CommandName="Delete" runat="server">Delete</asp:LinkButton>
                            
</ItemTemplate>
</asp:TemplateField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView></asp:Panel></TD></TR><TR><TD style="HEIGHT: 26px" vAlign=top colSpan=4><asp:Button id="btnSubmit" onclick="btnSubmit_Click" runat="server" Text="Submit" SkinID="Normal" __designer:wfdid="w77"></asp:Button> <asp:Button id="btnCancelPunishment" onclick="btnCancelPunishment_Click" runat="server" Text="Cancel" SkinID="Cancel" __designer:wfdid="w78"></asp:Button></TD></TR></TBODY></TABLE>
</contenttemplate>
    </asp:UpdatePanel>
    <br />
    
    <br />
    &nbsp;
</asp:Content>

