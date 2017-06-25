<%@ Page Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master" AutoEventWireup="true" CodeFile="EmployeeWorkDistribution.aspx.cs" Inherits="MODULES_PMS_ReportForms_EmployeeWorkDistribution" Title="PMS | Employee Work Distribution" %>


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
            RepositionMode="RepositionOnWindowScroll">
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
    <asp:Label ID="Label5" runat="server" SkinID="UnicodeHeadlbl" Text="कर्मचारी कार्यविभाजनको विवरण"></asp:Label><br />
    <br />
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<DIV style="WIDTH: 938px; CURSOR: hand; HEIGHT: 27px" id="upper" class="collapsePanelHeader">कर्मचारी खोज्नुहोस् </DIV><asp:Panel id="MainPanelSearch" runat="server" Width="900px" Height="185px">
            <TABLE style="WIDTH: 900px"><TBODY><TR><TD style="WIDTH: 126px"><asp:Label id="lblSymbNo" runat="server" Width="110px" Height="22px" Text="संकेत नं" SkinID="Unicodelbl"></asp:Label></TD><TD><asp:TextBox id="txtSymbolNo" runat="server" Width="130px" SkinID="Unicodetxt" ToolTip="First Name" MaxLength="15"></asp:TextBox></TD><TD></TD><TD></TD><TD></TD><TD></TD></TR><TR><TD style="WIDTH: 126px"><asp:Label id="lblFirstName" runat="server" Width="92px" Height="22px" Text="पहिलो नाम" SkinID="Unicodelbl"></asp:Label></TD><TD><asp:TextBox id="txtFName" runat="server" Width="130px" SkinID="Unicodetxt" ToolTip="First Name" MaxLength="35"></asp:TextBox></TD><TD><asp:Label id="lblSecondName" runat="server" Width="92px" Height="22px" Text="बिचको नाम" SkinID="Unicodelbl"></asp:Label></TD><TD><asp:TextBox id="txtMName" runat="server" Width="130px" SkinID="Unicodetxt" MaxLength="15"></asp:TextBox></TD><TD><asp:Label id="lblLastName" runat="server" Width="27px" Height="22px" Text="थर" SkinID="Unicodelbl"></asp:Label></TD><TD><asp:TextBox id="txtSurName" runat="server" Width="130px" SkinID="Unicodetxt" ToolTip="Surname" MaxLength="35"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 126px"><asp:Label id="lblGender" runat="server" Width="41px" Height="22px" Text="लिंग" SkinID="Unicodelbl"></asp:Label></TD><TD><asp:DropDownList id="ddlGender" runat="server" Width="135px" SkinID="Unicodeddl">
                    <asp:ListItem Value="SG">छान्नुहोस</asp:ListItem>
                    <asp:ListItem Value="M">पुरुष</asp:ListItem>
                    <asp:ListItem Value="F">महिला</asp:ListItem>
                    <asp:ListItem Value="O">अन्य</asp:ListItem>
                </asp:DropDownList></TD><TD><asp:Label id="lblDOB" runat="server" Width="91px" Height="22px" Text="जन्म मिति" SkinID="Unicodelbl"></asp:Label></TD><TD><asp:TextBox id="txtDOB" runat="server" Width="130px" SkinID="Unicodetxt" MaxLength="10"></asp:TextBox></TD><TD><asp:Label id="lblMaritalStatus" runat="server" Width="114px" Height="22px" Text="बैबाहिक स्थिति" SkinID="Unicodelbl"></asp:Label></TD><TD><asp:DropDownList id="ddlMarStatus" runat="server" Width="135px" SkinID="Unicodeddl">
                    <asp:ListItem Value="SMS">छान्नुहोस</asp:ListItem>
                    <asp:ListItem Value="S">अबिबाहित</asp:ListItem>
                    <asp:ListItem Value="M">बिबाहित</asp:ListItem>
                    <asp:ListItem Value="W">बिधवा/बिदुर</asp:ListItem>
                    <asp:ListItem Value="D">छोडपत्र</asp:ListItem>
                    <asp:ListItem Value="O">अन्य</asp:ListItem>
                </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 126px; HEIGHT: 24px"><asp:Label id="lblOrganization" runat="server" Text="कार्यालय" SkinID="Unicodelbl"></asp:Label></TD><TD 
style="HEIGHT: 24px" colSpan=3><asp:DropDownList id="ddlSearchOrganization" runat="server" Width="466px" SkinID="Unicodeddl">
                </asp:DropDownList></TD><TD style="HEIGHT: 24px"><asp:Label id="lblDesignation" runat="server" Text="पद" SkinID="Unicodelbl"></asp:Label></TD><TD 
style="HEIGHT: 24px"><asp:DropDownList id="ddlDesignation" runat="server" Width="135px" SkinID="Unicodeddl">
                </asp:DropDownList></TD></TR>
                <tr>
                    <td style="width: 126px; height: 24px">
                    </td>
                    <td colspan="3" style="height: 24px">
                <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server" Collapsed="true" CollapseControlID="upper" TargetControlID="MainPanelSearch" ExpandControlID="upper">
                </ajaxToolkit:CollapsiblePanelExtender>
                    </td>
                    <td style="height: 24px">
                    </td>
                    <td style="height: 24px">
                        <asp:Button id="btnSearch" onclick="btnSearch_Click" runat="server" Text="Search" SkinID="Normal"></asp:Button><asp:Button id="btnSearchCancel" onclick="btnSearchCancel_Click" runat="server" Text="Cancel" SkinID="Cancel"></asp:Button></td>
                </tr>
                <TR><TD style="HEIGHT: 306px" colSpan=6>
<HR />
<asp:Label id="lblSearch" runat="server" Font-Bold="True"></asp:Label>
                    <asp:Panel ID="Panel1" runat="server" Height="150px" ScrollBars="Auto" Width="890px">
                        <asp:GridView ID="grdEmployee" runat="server" AutoGenerateColumns="False" CellPadding="0"
                            ForeColor="#333333" OnRowCreated="grdEmployee_RowCreated" OnSelectedIndexChanged="grdEmployee_SelectedIndexChanged"
                            SkinID="Unicodegrd" Width="890px">
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
                </TD></TR></TBODY>
</TABLE>
</asp:Panel> <TABLE width=900><TBODY><TR><TD style="WIDTH: 65px"><asp:Label id="Label1" runat="server" Width="55px" Text="कार्यलय" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 100px"><asp:DropDownList id="ddlOrganization" runat="server" Width="265px" SkinID="Unicodeddl" AutoPostBack="True" OnSelectedIndexChanged="ddlOrganization_SelectedIndexChanged">
                </asp:DropDownList></TD><TD style="WIDTH: 40px"><asp:Label id="Label2" runat="server" Width="35px" Text="शाखा" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 100px"><asp:DropDownList id="ddlOrgUnit" runat="server" Width="265px" SkinID="Unicodeddl">
                </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 65px"><asp:Label id="Label3" runat="server" Text="देखि" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 100px"><asp:TextBox id="txtFromDate" runat="server" Width="95px" SkinID="Unicodetxt"></asp:TextBox></TD><TD style="WIDTH: 40px"><asp:Label id="Label4" runat="server" Text="सम्म" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 100px"><asp:TextBox id="txtToDate" runat="server" Width="95px" SkinID="Unicodetxt"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 65px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 40px"></TD><TD style="WIDTH: 100px">&nbsp;<asp:Button id="btnCancel" onclick="btnCancel_Click" runat="server" Text="Cancel" SkinID="Cancel"></asp:Button></TD></TR></TBODY></TABLE><ajaxToolkit:MaskedEditExtender id="MaskedEditExtender1" runat="server" TargetControlID="txtFromDate" MaskType="Date" Mask="9999/99/99" AutoComplete="False">
                </ajaxToolkit:MaskedEditExtender> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender2" runat="server" TargetControlID="txtToDate" MaskType="Date" Mask="9999/99/99" AutoComplete="False">
                </ajaxToolkit:MaskedEditExtender>
</contenttemplate>
    </asp:UpdatePanel>
    <asp:Button ID="btnView" runat="server" OnClick="btnView_Click" SkinID="Normal" Text="View Report" /><br />
    <div id="lower" style="min-height:500px">
        &nbsp;<br />
        <br />
        <br />
        &nbsp;</div>
</asp:Content>

