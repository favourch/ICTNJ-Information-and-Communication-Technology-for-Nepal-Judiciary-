<%@ Page Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master" AutoEventWireup="true" CodeFile="MedicalExpenses.aspx.cs" Inherits="MODULES_PMS_Forms_MedicalExpenses" Title="PMS | Medical Expenses" %>
<%@ Register 
    Assembly="AjaxControlToolkit" 
    Namespace="AjaxControlToolkit" 
    TagPrefix="ajaxToolkit" %>
    
    <script runat="server">

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
</script>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript" src="../../COMMON/JS/Validation.js" ></script>
<script language="javascript" type="text/javascript" src="../../COMMON/JS/DateValidator.js" ></script>
<script language="javascript" type="text/javascript" src="../../COMMON/JS/EnglishDateValidator.js" ></script>
<script language="javascript" type="text/javascript" src="../../COMMON/JS/Number.js" ></script>    
    <asp:ScriptManager id="ScriptManager1" runat="server" />

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
            <br />
            <asp:UpdatePanel id="UpdatePanel2" runat="server">
                <contenttemplate>
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
</contenttemplate>
            </asp:UpdatePanel>
            <br />
<asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click" Width="58px" />
<br />
        </asp:Panel>
    <br />
    <table width="1000">
        <tr>
            <td style="width: 16px">
            </td>
            <td style="width: 100px">
    <asp:Label ID="Label14" runat="server" SkinID="UnicodeHeadlbl" Text="औषधि खर्च"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 16px">
            </td>
            <td style="width: 100px">

        <asp:Panel ID="pnlCol" runat="server" CssClass="collapsePanelHeader" Height="25px" Width="900px">
            &nbsp; &nbsp;&nbsp;
            कर्मचारी खोज्नुहोस्</asp:Panel>
            </td>
        </tr>
    </table>
<br />
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<ajaxToolkit:CollapsiblePanelExtender id="colEmployee" runat="server" SkinID="CollapsiblePanelDemo" TargetControlID="pnlEmployeeSearch" ExpandedImage="../../COMMON/Images/collapse_blue.jpg" SuppressPostBack="True" ImageControlID="imgCol" ExpandControlID="pnlCol" CollapsedImage="../../COMMON/Images/expand_blue.jpg" Collapsed="True" CollapseControlID="pnlCol">
        </ajaxToolkit:CollapsiblePanelExtender><asp:Panel id="pnlEmployeeSearch" runat="server" Width="950px" Height="387px"><TABLE><TBODY><TR><TD style="WIDTH: 16px"></TD><TD colSpan=6></TD></TR><TR><TD style="WIDTH: 16px"></TD><TD style="WIDTH: 110px"><asp:Label id="Label4" runat="server" Width="110px" Height="22px" Text="संकेत नं" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 135px"><asp:TextBox id="txtSearchSymbolNo" runat="server" Width="130px" SkinID="Unicodetxt" ToolTip="First Name" MaxLength="15"></asp:TextBox></TD><TD style="WIDTH: 110px"></TD><TD style="WIDTH: 130px"></TD><TD style="WIDTH: 115px"></TD><TD></TD></TR><TR><TD style="WIDTH: 16px"></TD><TD style="WIDTH: 110px"><asp:Label id="Label7" runat="server" Width="92px" Height="22px" Text="पहिलो नाम" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 135px"><asp:TextBox id="txtFirstName" runat="server" Width="130px" SkinID="Unicodetxt" ToolTip="First Name" MaxLength="35"></asp:TextBox></TD><TD style="WIDTH: 110px"><asp:Label id="Label8" runat="server" Width="92px" Height="22px" Text="बिचको नाम" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 130px"><asp:TextBox id="txtMidName" runat="server" Width="130px" SkinID="Unicodetxt" MaxLength="15"></asp:TextBox></TD><TD style="WIDTH: 115px"><asp:Label id="Label9" runat="server" Width="92px" Height="22px" Text="थर" SkinID="Unicodelbl"></asp:Label></TD><TD><asp:TextBox id="txtLastName" runat="server" Width="130px" SkinID="Unicodetxt" ToolTip="Surname" MaxLength="35"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 16px"></TD><TD style="WIDTH: 110px"><asp:Label id="Label10" runat="server" Width="92px" Height="22px" Text="लिंग" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 135px"><asp:DropDownList id="ddlSex" runat="server" Width="135px" SkinID="Unicodeddl">
                            <asp:ListItem Value="SG">छान्नुहोस</asp:ListItem>
                            <asp:ListItem Value="M">पुरुष</asp:ListItem>
                            <asp:ListItem Value="F">महिला</asp:ListItem>
                            <asp:ListItem Value="O">अन्य</asp:ListItem>
                        </asp:DropDownList></TD><TD style="WIDTH: 110px"><asp:Label id="Label11" runat="server" Width="110px" Height="22px" Text="जन्म मिति" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 130px"><asp:TextBox id="txtBirthDate" runat="server" Width="130px" SkinID="Unicodetxt" MaxLength="10"></asp:TextBox></TD><TD style="WIDTH: 115px"><asp:Label id="Label12" runat="server" Width="114px" Height="22px" Text="बैबाहिक स्थिति" SkinID="Unicodelbl"></asp:Label></TD><TD><asp:DropDownList id="ddlMarried" runat="server" Width="135px" SkinID="Unicodeddl">
                            <asp:ListItem Value="SMS">छान्नुहोस</asp:ListItem>
                            <asp:ListItem Value="S">अबिबाहित</asp:ListItem>
                            <asp:ListItem Value="M">बिबाहित</asp:ListItem>
                            <asp:ListItem Value="W">बिधवा/बिदुर</asp:ListItem>
                            <asp:ListItem Value="D">छोडपत्र</asp:ListItem>
                            <asp:ListItem Value="O">अन्य</asp:ListItem>
                        </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 16px; HEIGHT: 24px"></TD><TD style="WIDTH: 110px; HEIGHT: 24px"><asp:Label id="Label13" runat="server" Text="कार्यालय" SkinID="Unicodelbl"></asp:Label></TD><TD style="HEIGHT: 24px" colSpan=3><asp:DropDownList id="ddlOrganization" runat="server" Width="474px" SkinID="Unicodeddl"></asp:DropDownList></TD><TD style="WIDTH: 115px; HEIGHT: 24px"><asp:Label id="lblDesignation" runat="server" Text="पद" SkinID="Unicodelbl"></asp:Label></TD><TD style="HEIGHT: 24px"><asp:DropDownList id="ddlDesignation" runat="server" Width="135px" SkinID="Unicodeddl">
                        </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 16px; HEIGHT: 24px"></TD><TD style="WIDTH: 110px; HEIGHT: 24px"></TD><TD style="HEIGHT: 24px" colSpan=3></TD><TD style="WIDTH: 115px; HEIGHT: 24px"></TD><TD style="HEIGHT: 24px"><asp:Button id="btnSearch" onclick="btnSearch_Click" runat="server" Text="Search" SkinID="Normal"></asp:Button><asp:Button id="btnCancel" onclick="btnCancel_Click" runat="server" Text="Cancel" SkinID="Cancel"></asp:Button></TD></TR><TR><TD style="WIDTH: 16px; HEIGHT: 306px" vAlign=top colSpan=1></TD><TD style="HEIGHT: 306px" vAlign=top colSpan=6>
<HR />
<asp:Label id="lblSearch" runat="server" Font-Bold="True"></asp:Label><BR /><asp:Panel id="Panel2" runat="server" Width="900px" Height="150px" ScrollBars="Auto">
                            <asp:GridView ID="grdEmployee" runat="server" AutoGenerateColumns="False" CellPadding="0"
                                ForeColor="#333333" OnRowDataBound="grdEmployee_RowDataBound" OnSelectedIndexChanged="grdEmployee_SelectedIndexChanged"
                                SkinID="Unicodegrd" Width="900px">
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
                        </asp:Panel> </TD></TR></TBODY></TABLE></asp:Panel><BR /><TABLE style="WIDTH: 1000px"><TBODY><TR><TD style="WIDTH: 15px" vAlign=top colSpan=1></TD><TD vAlign=top colSpan=4>
<HR />
&nbsp;</TD></TR><TR><TD style="WIDTH: 15px; HEIGHT: 10px" vAlign=top></TD><TD style="WIDTH: 170px; HEIGHT: 10px" vAlign=top><asp:Label id="Label5" runat="server" Width="170px" Text="कर्मचारीको पुरा नाम थर" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 244px; HEIGHT: 10px" vAlign=top><asp:TextBox id="txtEmpName_Rqd" runat="server" Width="244px" SkinID="Unicodetxt" ToolTip="कर्मचारीको पुरा नाम थर" ReadOnly="True"></asp:TextBox></TD><TD style="WIDTH: 80px; HEIGHT: 10px" vAlign=top><asp:Label id="Label6" runat="server" Width="60px" Text="संकेत नं" SkinID="Unicodelbl"></asp:Label></TD><TD style="HEIGHT: 10px" vAlign=top><asp:TextBox id="txtSymbolNo" runat="server" Width="74px" SkinID="Unicodetxt" ToolTip="संकेत नं" ReadOnly="True"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 15px; HEIGHT: 111px" vAlign=top></TD><TD style="WIDTH: 170px; HEIGHT: 111px" vAlign=top><asp:Label id="Label1" runat="server" Text="विवरण" SkinID="Unicodelbl"></asp:Label></TD><TD style="HEIGHT: 111px" vAlign=top colSpan=3><asp:TextBox id="txtParticulars_Rqd" runat="server" Width="242px" Height="101px" SkinID="Unicodetxt" ToolTip="विबरण" TextMode="MultiLine" MaxLength="100"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 15px; HEIGHT: 10px" vAlign=top></TD><TD style="WIDTH: 170px; HEIGHT: 10px" vAlign=top><asp:Label id="Label2" runat="server" Width="95px" Text="लिएको मिति" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 244px; HEIGHT: 10px" vAlign=top><asp:TextBox id="txtDateTaken_RDT" runat="server" Width="73px" SkinID="Unicodetxt" ToolTip="लिएको मिति"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender1" runat="server" TargetControlID="txtDateTaken_RDT" MaskType="Date" Mask="9999/99/99" AutoComplete="False">
                </ajaxToolkit:MaskedEditExtender> </TD><TD style="WIDTH: 80px; HEIGHT: 10px" vAlign=top><asp:Label id="Label3" runat="server" Text="रकम" SkinID="Unicodelbl"></asp:Label></TD><TD style="HEIGHT: 10px" vAlign=top><asp:TextBox id="txtAmountTaken_Rqd" runat="server" Width="100px" SkinID="Unicodetxt" ToolTip="रकम" MaxLength="10"></asp:TextBox> <ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender1" runat="server" TargetControlID="txtAmountTaken_Rqd" __designer:wfdid="w3" FilterType="Numbers"></ajaxToolkit:FilteredTextBoxExtender></TD></TR><TR><TD style="WIDTH: 15px" vAlign=top></TD><TD style="WIDTH: 170px" vAlign=top><asp:Button id="btnAdd" onclick="btnAdd_Click" runat="server" Width="60px" Text="Submit" SkinID="Normal"></asp:Button> <asp:Button id="btnCancelbtm" onclick="btnCancelbtm_Click" runat="server" Text="Cancel" SkinID="Cancel"></asp:Button></TD><TD style="WIDTH: 244px"></TD><TD style="WIDTH: 80px"></TD><TD><asp:TextBox id="txtEmpID" runat="server" Visible="False"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 15px" colSpan=1></TD><TD colSpan=4>
<HR />
<TABLE style="WIDTH: 800px"><TBODY><TR><TD style="HEIGHT: 21px" colSpan=3><asp:Panel id="Panel1" runat="server" Width="100%" Height="150px" ScrollBars="Auto"><asp:GridView id="grdMedicalExp" runat="server" Width="785px" SkinID="Unicodegrd" OnSelectedIndexChanged="grdMedicalExp_SelectedIndexChanged" OnRowDataBound="grdMedicalExp_RowDataBound" ForeColor="#333333" CellPadding="0" AutoGenerateColumns="False" GridLines="None">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="EMPID" HeaderText="EmpID"></asp:BoundField>
<asp:BoundField DataField="SEQNO" HeaderText="SeqNo">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="Particulars" HeaderText="विवरण">
<ItemStyle Width="280px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="DATETAKEN" HeaderText="लिएको मिति">
<ItemStyle Width="100px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="AMOUNTTAKEN" HeaderText="रकम">
<ItemStyle Width="100px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:CommandField ShowSelectButton="True">
<ItemStyle Width="100px"></ItemStyle>
</asp:CommandField>
<asp:CommandField ShowDeleteButton="True">
<ItemStyle Width="100px"></ItemStyle>
</asp:CommandField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> </asp:Panel> </TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
</contenttemplate>
    </asp:UpdatePanel>
    &nbsp;<br />
</asp:Content>

