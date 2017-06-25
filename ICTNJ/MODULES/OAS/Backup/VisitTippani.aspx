<%@ Page AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeFile="VisitTippani.aspx.cs" Inherits="MODULES_OAS_Tippani_VisitTippani" Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="DIV1" style="width: 100%; height: auto">
        <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
        <ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior"
            DropShadow="True" PopupControlID="programmaticPopup" PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
            TargetControlID="hiddenTargetControlForModalPopup">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none; width: 350px; padding: 10px">
            <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD; border: solid 1px Gray; color: Black; text-align: center;">
                Save Status
            </asp:Panel>
            <asp:UpdatePanel id="UpdatePanel3" runat="server">
                <contenttemplate>
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
</contenttemplate>
            </asp:UpdatePanel>
            <br />
            <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click" Text="OK" Width="58px" />
            <br />
        </asp:Panel>
        <asp:Label ID="Label22" runat="server" SkinID="UnicodeHeadlbl" Text="कर्मचारी खोज्नुहोस"></asp:Label><br />
        <table style="width: 939px">
            <tr>
                <td>
                    <asp:Label ID="Label30" runat="server" Height="22px" SkinID="Unicodelbl" Text="संकेत नं" Width="110px"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtSymbolNo" runat="server" MaxLength="15" SkinID="Unicodetxt" ToolTip="First Name" Width="130px"></asp:TextBox></td>
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
                    <asp:Label ID="Label1" runat="server" Height="22px" SkinID="Unicodelbl" Text="पहिलो नाम" Width="92px"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtFName" runat="server" MaxLength="35" SkinID="Unicodetxt" ToolTip="First Name" Width="130px"></asp:TextBox></td>
                <td>
                    <asp:Label ID="Label2" runat="server" Height="22px" SkinID="Unicodelbl" Text="बिचको नाम" Width="92px"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtMName" runat="server" MaxLength="15" SkinID="Unicodetxt" Width="130px"></asp:TextBox></td>
                <td>
                    <asp:Label ID="Label3" runat="server" Height="22px" SkinID="Unicodelbl" Text="थर" Width="92px"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtSurName" runat="server" MaxLength="35" SkinID="Unicodetxt" ToolTip="Surname" Width="130px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Height="22px" SkinID="Unicodelbl" Text="लिंग" Width="92px"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddlGender" runat="server" SkinID="Unicodeddl" Width="135px">
                        <asp:ListItem Value="SG">छान्नुहोस</asp:ListItem>
                        <asp:ListItem Value="M">पुरुष</asp:ListItem>
                        <asp:ListItem Value="F">महिला</asp:ListItem>
                        <asp:ListItem Value="O">अन्य</asp:ListItem>
                    </asp:DropDownList></td>
                <td>
                    <asp:Label ID="Label4" runat="server" Height="22px" SkinID="Unicodelbl" Text="जन्म मिति" Width="110px"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtDOB" runat="server" MaxLength="10" SkinID="Unicodetxt" Width="130px"></asp:TextBox></td>
                <td>
                    <asp:Label ID="Label6" runat="server" Height="22px" SkinID="Unicodelbl" Text="बैबाहिक सम्बन्ध" Width="114px"></asp:Label></td>
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
                    <asp:DropDownList ID="ddlOrganization" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlOrganization_SelectedIndexChanged" SkinID="Unicodeddl"
                        Width="478px">
                    </asp:DropDownList></td>
                <td>
                    <asp:Label ID="lblDesignation" runat="server" SkinID="Unicodelbl" Text="पद"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddlDesignation" runat="server" SkinID="Unicodeddl" Width="135px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" SkinID="Unicodelbl" Text="कमिटि"></asp:Label></td>
                <td>
                    <asp:UpdatePanel id="UpdatePanel2" runat="server">
                        <contenttemplate>
<asp:DropDownList id="ddlCommittee" runat="server" Width="135px"></asp:DropDownList> 
</contenttemplate>
                        <triggers>
<asp:AsyncPostBackTrigger ControlID="ddlOrganization" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:Label ID="Label9" runat="server" Height="22px" SkinID="Unicodelbl" Text="कमिटिको पद" Width="110px"></asp:Label></td>
                <td colspan="2">
                    <asp:DropDownList ID="ddlCommitteePost" runat="server" Width="220px">
                    </asp:DropDownList></td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td colspan="5">
                    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" SkinID="Normal" Text="Search" />
                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" SkinID="Cancel" Text="Cancel" /><ajaxToolkit:MaskedEditExtender ID="MSKdob" runat="server"
                        AutoComplete="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtDOB">
                    </ajaxToolkit:MaskedEditExtender>
                </td>
            </tr>
        </table>
        <hr />
        <asp:UpdatePanel id="UpdatePanel1" runat="server">
            <contenttemplate>
<asp:Label id="lblSearch" runat="server" SkinID="Unicodelbl" Font-Bold="True"></asp:Label><BR /><asp:Panel id="pnlEmployee" runat="server" Width="100%" Height="250px" ScrollBars="Auto" Visible="False">
<asp:GridView id="grdEmployee" runat="server" Width="100%" SkinID="Unicodegrd" OnSelectedIndexChanged="grdEmployee_SelectedIndexChanged" OnDataBound="grdEmployee_DataBound" OnRowDataBound="grdEmployee_RowDataBound" ForeColor="#333333" CellPadding="0" AutoGenerateColumns="False">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="PersonID" HeaderText="आई डी"></asp:BoundField>
<asp:BoundField DataField="RDFULLNAME" HeaderText="पुरा नाम थर"></asp:BoundField>
<asp:BoundField DataField="RDGENDER" HeaderText="लिंग"></asp:BoundField>
<asp:BoundField DataField="DOB" HeaderText="जन्म मिति">
<ItemStyle Font-Names="Verdana"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="RDMARITALSTATUS" HeaderText="बैबाहिक सम्बन्ध"></asp:BoundField>
<asp:BoundField DataField="District" HeaderText="जन्म स्थान"></asp:BoundField>
<asp:BoundField DataField="IniType" HeaderText="कार्यालय"></asp:BoundField>
<asp:BoundField DataField="PostName" HeaderText="पद"></asp:BoundField>
<asp:BoundField DataField="GroupName" HeaderText="कमिटि"></asp:BoundField>
<asp:BoundField DataField="GMPositionName" HeaderText="पद"></asp:BoundField>
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
</asp:GridView> </asp:Panel> <asp:Label id="Label221" runat="server" Text="टिप्पनीको बिबरण" SkinID="UnicodeHeadlbl" __designer:dtid="844424930132124" __designer:wfdid="w11"></asp:Label>
</contenttemplate>
            <triggers>
<asp:PostBackTrigger ControlID="grdEmployee"></asp:PostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
        </asp:UpdatePanel><table width="640">
            <tr>
                <td style="width: 125px">
                    &nbsp;&nbsp;
                    <asp:Label ID="Label10" runat="server" SkinID="Unicodelbl" Text="सस्थां"></asp:Label></td>
                <td style="width: 525px">
                    <asp:DropDownList ID="ddlOrg_Rqd" runat="server" SkinID="Unicodeddl" Width="250px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 125px">
                    &nbsp;&nbsp;
                    <asp:Label ID="Label11" runat="server" SkinID="Unicodelbl" Text="टिप्पणीको बिषय"></asp:Label></td>
                <td style="width: 525px">
                    <asp:DropDownList ID="ddlTippaniSubject_Rqd" runat="server" SkinID="Unicodeddl" Width="250px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 125px" valign="top">
                    &nbsp;&nbsp;
                    <asp:Label ID="Label12" runat="server" SkinID="Unicodelbl" Text="टिप्पणी खाता"></asp:Label></td>
                <td style="width: 525px">
                    <asp:TextBox ID="txtTippaniText" runat="server" Height="120px" SkinID="Unicodetxt" TextMode="MultiLine" Width="512px"></asp:TextBox></td>
            </tr>
        </table>
        <hr align="left" width="100%" />
        <asp:Label ID="Label23" runat="server" SkinID="UnicodeHeadlbl" Text="भ्रमणको बिबरण"></asp:Label><br />
        <table style="width: 641px">
            <tr>
                <td style="width: 125px">
                    &nbsp;&nbsp;
                    <asp:Label ID="Label13" runat="server" SkinID="Unicodelbl" Text="स्थान"></asp:Label></td>
                <td style="width: 200px">
                    <asp:TextBox ID="txtLocation_Rqd" runat="server" SkinID="Unicodetxt" Width="190px"></asp:TextBox></td>
                <td style="width: 115px">
                    &nbsp; &nbsp;
                    <asp:Label ID="Label14" runat="server" SkinID="Unicodelbl" Text="देश"></asp:Label></td>
                <td style="width: 200px">
                    <asp:DropDownList ID="ddlCountry_Rqd" runat="server" Width="194px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 125px">
                    &nbsp;&nbsp;
                    <asp:Label ID="Label15" runat="server" SkinID="Unicodelbl" Text="अवधि देखि"></asp:Label></td>
                <td style="width: 200px">
                    <asp:TextBox ID="txtFromDate_Rdt" runat="server" SkinID="Unicodetxt" Width="190px"></asp:TextBox>
                    <ajaxToolkit:MaskedEditExtender ID="mskFromDate" runat="server" AutoComplete="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtFromDate_Rdt">
                    </ajaxToolkit:MaskedEditExtender>
                </td>
                <td style="width: 115px">
                    &nbsp; &nbsp;
                    <asp:Label ID="Label16" runat="server" SkinID="Unicodelbl" Text="अवधि सम्म"></asp:Label></td>
                <td style="width: 200px">
                    <asp:TextBox ID="txtToDate_Rdt" runat="server" SkinID="Unicodetxt" Width="190px"></asp:TextBox>
                    <ajaxToolkit:MaskedEditExtender ID="mskToDate" runat="server" AutoComplete="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtToDate_Rdt">
                    </ajaxToolkit:MaskedEditExtender>
                </td>
            </tr>
            <tr>
                <td style="width: 125px" valign="top">
                    &nbsp;&nbsp;
                    <asp:Label ID="Label17" runat="server" SkinID="Unicodelbl" Text="शिर्षक"></asp:Label></td>
                <td colspan="3">
                    <asp:TextBox ID="txtSubject_Rqd" runat="server" SkinID="Unicodetxt" TextMode="MultiLine" Width="512px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 125px" valign="top">
                    &nbsp;&nbsp;
                    <asp:Label ID="Label18" runat="server" SkinID="Unicodelbl" Text="कैफियत"></asp:Label></td>
                <td colspan="3">
                    <asp:TextBox ID="txtRemarks_Rdt" runat="server" SkinID="Unicodetxt" TextMode="MultiLine" Width="512px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 125px" valign="top">
                </td>
                <td colspan="3">
                    <asp:Label ID="Label21" runat="server" Font-Underline="True" SkinID="Unicodelbl" Text="तपाईको आफ्नो नोट"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 125px" valign="top">
                    &nbsp;&nbsp;
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtNote" runat="server" SkinID="Unicodetxt" TextMode="MultiLine" Width="512px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 125px" valign="top">
                </td>
                <td colspan="3">
                    <asp:Label ID="Label20" runat="server" Font-Underline="True" SkinID="Unicodelbl" Text="टिप्पणी को स्थिति"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 125px" valign="top">
                </td>
                <td colspan="3">
                    <asp:DropDownList ID="ddlTippaniStatus" runat="server" SkinID="Unicodeddl" Width="194px">
                    </asp:DropDownList></td>
            </tr>
        </table>
        <hr align="left" width="100%" />
        <asp:Label ID="Label19" runat="server" SkinID="UnicodeHeadlbl" Text="सिफारीस कर्त्ता"></asp:Label><br />
        <cc1:TabContainer ID="EvaluationTab" runat="server" ActiveTabIndex="0" CssClass="ajax_tab_theme" Width="100%">
            <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                <contenttemplate>
<DIV style="WIDTH: 100%; HEIGHT: 500px"><asp:Panel id="pnlForChannelPerson" runat="server" Width="100%" Height="480px" ScrollBars="Auto" __designer:wfdid="w422"><asp:Label id="lblChannelPersonCount" runat="server" SkinID="Unicodelbl" __designer:dtid="844424930132104" Font-Underline="True" __designer:wfdid="w423"></asp:Label> <BR /><asp:GridView id="grdChannelPerson" runat="server" Width="100%" __designer:wfdid="w424" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333" OnRowDataBound="grdChannelPerson_RowDataBound1" OnDataBound="grdChannelPerson_DataBound" GridLines="None">
<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>
<Columns>
<asp:TemplateField>
<ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
<ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" />
                        
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="ChannelSeqID" HeaderText="CSID"></asp:BoundField>
<asp:BoundField DataField="ChannelPersonName" HeaderText="पुरा नाम"></asp:BoundField>
<asp:BoundField DataField="OrgName" HeaderText="सस्थां"></asp:BoundField>
<asp:BoundField DataField="DegName" HeaderText="पद"></asp:BoundField>
<asp:BoundField DataField="ChannelPersonOrder" HeaderText="तह"></asp:BoundField>
<asp:BoundField DataField="RDPersonType" HeaderText="प्रकार"></asp:BoundField>
<asp:BoundField DataField="RDIsFinalApprover" HeaderText="प्र. प्र. क"></asp:BoundField>
<asp:BoundField DataField="ChannelPersonID" HeaderText="Person"></asp:BoundField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>
</asp:GridView></asp:Panel> </DIV>
</contenttemplate>
                <headertemplate>
टिप्पणी च्यानल बाट&nbsp; 
</headertemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                <contenttemplate>
<DIV style="WIDTH: 100%; HEIGHT: 500px"><asp:Label id="lblChannelPersonCountX" runat="server" SkinID="Unicodelbl" __designer:dtid="844424930132104" Font-Underline="True" __designer:wfdid="w393">साधारण कर्मचारी खोज्नुहोस</asp:Label> <BR /><TABLE style="WIDTH: 939px" __designer:dtid="562949953421325"><TBODY><TR __designer:dtid="562949953421326"><TD __designer:dtid="562949953421327"><asp:Label id="Label24" runat="server" Width="110px" Height="22px" Text="संकेत नं" SkinID="Unicodelbl" __designer:dtid="562949953421328" __designer:wfdid="w394"></asp:Label> </TD><TD __designer:dtid="562949953421329"><asp:TextBox id="TextBox2" runat="server" Width="130px" SkinID="Unicodetxt" __designer:dtid="562949953421330" ToolTip="First Name" MaxLength="15" __designer:wfdid="w395"></asp:TextBox> </TD><TD __designer:dtid="562949953421331"></TD><TD __designer:dtid="562949953421332"></TD><TD __designer:dtid="562949953421333"></TD><TD __designer:dtid="562949953421334"></TD></TR><TR __designer:dtid="562949953421335"><TD __designer:dtid="562949953421336"><asp:Label id="Label25" runat="server" Width="92px" Height="22px" Text="पहिलो नाम" SkinID="Unicodelbl" __designer:dtid="562949953421337" __designer:wfdid="w396"></asp:Label> </TD><TD __designer:dtid="562949953421338"><asp:TextBox id="txtSFname" runat="server" Width="130px" SkinID="Unicodetxt" __designer:dtid="562949953421339" ToolTip="First Name" MaxLength="35" __designer:wfdid="w397"></asp:TextBox> </TD><TD __designer:dtid="562949953421340"><asp:Label id="Label26" runat="server" Width="92px" Height="22px" Text="बिचको नाम" SkinID="Unicodelbl" __designer:dtid="562949953421341" __designer:wfdid="w398"></asp:Label> </TD><TD __designer:dtid="562949953421342"><asp:TextBox id="txtSMname" runat="server" Width="130px" SkinID="Unicodetxt" __designer:dtid="562949953421343" MaxLength="15" __designer:wfdid="w399"></asp:TextBox> </TD><TD __designer:dtid="562949953421344"><asp:Label id="Label27" runat="server" Width="92px" Height="22px" Text="थर" SkinID="Unicodelbl" __designer:dtid="562949953421345" __designer:wfdid="w400"></asp:Label> </TD><TD __designer:dtid="562949953421346"><asp:TextBox id="txtSLname" runat="server" Width="130px" SkinID="Unicodetxt" __designer:dtid="562949953421347" ToolTip="Surname" MaxLength="35" __designer:wfdid="w401"></asp:TextBox> </TD></TR><TR __designer:dtid="562949953421348"><TD __designer:dtid="562949953421349"><asp:Label id="Label28" runat="server" Width="92px" Height="22px" Text="लिंग" SkinID="Unicodelbl" __designer:dtid="562949953421350" __designer:wfdid="w402"></asp:Label> </TD><TD __designer:dtid="562949953421351"><asp:DropDownList id="ddlSSex" runat="server" Width="135px" SkinID="Unicodeddl" __designer:dtid="562949953421352" __designer:wfdid="w403"><asp:ListItem Value="SG" __designer:dtid="562949953421353">छान्नुहोस</asp:ListItem>
<asp:ListItem Value="M" __designer:dtid="562949953421354">पुरुष</asp:ListItem>
<asp:ListItem Value="F" __designer:dtid="562949953421355">महिला</asp:ListItem>
<asp:ListItem Value="O" __designer:dtid="562949953421356">अन्य</asp:ListItem>
</asp:DropDownList> </TD><TD __designer:dtid="562949953421357"><asp:Label id="Label29" runat="server" Width="110px" Height="22px" Text="जन्म मिति" SkinID="Unicodelbl" __designer:dtid="562949953421358" __designer:wfdid="w404"></asp:Label> </TD><TD __designer:dtid="562949953421359"><asp:TextBox id="txtSDob" runat="server" Width="130px" SkinID="Unicodetxt" __designer:dtid="562949953421360" MaxLength="10" __designer:wfdid="w405"></asp:TextBox> </TD><TD __designer:dtid="562949953421361"><asp:Label id="Label31" runat="server" Width="114px" Height="22px" Text="बैबाहिक सम्बन्ध" SkinID="Unicodelbl" __designer:dtid="562949953421362" __designer:wfdid="w406"></asp:Label> </TD><TD __designer:dtid="562949953421363"><asp:DropDownList id="ddlSMaritalStatus" runat="server" Width="135px" SkinID="Unicodeddl" __designer:dtid="562949953421364" __designer:wfdid="w407"><asp:ListItem Value="SMS" __designer:dtid="562949953421365">छान्नुहोस</asp:ListItem>
<asp:ListItem Value="S" __designer:dtid="562949953421366">अबिबाहित</asp:ListItem>
<asp:ListItem Value="M" __designer:dtid="562949953421367">बिबाहित</asp:ListItem>
<asp:ListItem Value="W" __designer:dtid="562949953421368">बिधवा/बिदुर</asp:ListItem>
<asp:ListItem Value="D" __designer:dtid="562949953421369">छोडपत्र</asp:ListItem>
<asp:ListItem Value="O" __designer:dtid="562949953421370">अन्य</asp:ListItem>
</asp:DropDownList> </TD></TR><TR __designer:dtid="562949953421371"><TD __designer:dtid="562949953421372"><asp:Label id="Label32" runat="server" Text="कार्यालय" SkinID="Unicodelbl" __designer:dtid="562949953421373" __designer:wfdid="w408"></asp:Label> </TD><TD colSpan=3 __designer:dtid="562949953421374"><asp:DropDownList id="ddlSOrg" runat="server" Width="478px" SkinID="Unicodeddl" __designer:dtid="562949953421375" OnSelectedIndexChanged="ddlOrganization_SelectedIndexChanged" AutoPostBack="True" __designer:wfdid="w409"></asp:DropDownList> </TD><TD __designer:dtid="562949953421376"><asp:Label id="Label33" runat="server" Text="पद" SkinID="Unicodelbl" __designer:dtid="562949953421377" __designer:wfdid="w410"></asp:Label> </TD><TD __designer:dtid="562949953421378"><asp:DropDownList id="ddlSDesgination" runat="server" Width="135px" SkinID="Unicodeddl" __designer:dtid="562949953421379" __designer:wfdid="w411"></asp:DropDownList> </TD></TR><TR __designer:dtid="562949953421392"><TD align=left colSpan=6 __designer:dtid="562949953421393"><asp:Button id="btnSearchGeneral" onclick="btnSearchGeneral_Click" runat="server" Text="Search" SkinID="Normal" __designer:dtid="562949953421394" __designer:wfdid="w412"></asp:Button> <asp:Button id="btnCancelGeneral" onclick="btnCancelGeneral_Click" runat="server" Text="Cancel" SkinID="Cancel" __designer:dtid="562949953421395" __designer:wfdid="w413"></asp:Button> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender1" runat="server" __designer:dtid="562949953421396" TargetControlID="txtDOB" MaskType="Date" Mask="9999/99/99" AutoComplete="False" __designer:wfdid="w414" CultureThousandsPlaceholder="" CultureDecimalPlaceholder="" CultureCurrencySymbolPlaceholder="" Enabled="True" CultureAMPMPlaceholder="" CultureDateFormat="" CultureTimePlaceholder="" CultureDatePlaceholder=""></ajaxToolkit:MaskedEditExtender> </TD></TR></TBODY></TABLE><asp:UpdatePanel id="UpdatePanel4" runat="server" __designer:dtid="562949953421398" __designer:wfdid="w415"><ContentTemplate __designer:dtid="562949953421399">
<asp:Label id="lblSearchX" runat="server" SkinID="Unicodelbl" Font-Bold="False" __designer:wfdid="w416"></asp:Label><BR /><asp:Panel id="pnlGeneralEmployee" runat="server" Width="100%" Height="300px" ScrollBars="Auto" __designer:wfdid="w417"><asp:GridView id="grdSEmployee" runat="server" Width="100%" SkinID="Unicodegrd" __designer:wfdid="w418" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333" OnRowDataBound="grdEmployee_RowDataBound" OnDataBound="grdSEmployee_DataBound" GridLines="None">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="PersonID" HeaderText="EmpID"></asp:BoundField>
<asp:TemplateField>
<ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
<ItemTemplate>
<asp:CheckBox id="chkGSelect" runat="server" __designer:wfdid="w598"></asp:CheckBox>
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="RDFULLNAME" HeaderText="पुरा नाम थर"></asp:BoundField>
<asp:BoundField DataField="RDGENDER" HeaderText="लिंग"></asp:BoundField>
<asp:BoundField DataField="DOB" HeaderText="जन्म मिति">
<ItemStyle Font-Names="Verdana"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="RDMARITALSTATUS" HeaderText="बैबाहिक सम्बन्ध"></asp:BoundField>
<asp:BoundField DataField="District" HeaderText="जन्म स्थान"></asp:BoundField>
<asp:BoundField DataField="IniType" HeaderText="कार्यालय"></asp:BoundField>
<asp:BoundField DataField="PostName" HeaderText="पद"></asp:BoundField>
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
<asp:AsyncPostBackTrigger ControlID="btnSearchGeneral" EventName="Click"></asp:AsyncPostBackTrigger>
</Triggers>
</asp:UpdatePanel> </DIV>
</contenttemplate>
                <headertemplate>
साधारण कर्मचारी&nbsp; 
</headertemplate>
            </ajaxToolkit:TabPanel>
        </cc1:TabContainer>&nbsp;<br />
        <%--<asp:Panel ID="pnlChannelPerson" runat="server" Height="220px" ScrollBars="Auto" Width="100%">
            <asp:GridView ID="grdChannelPerson" runat="server" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333" OnRowDataBound="grdChannelPerson_RowDataBound"
                SkinID="Unicodegrd" Width="100%">
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <EditRowStyle BackColor="#999999" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField>
                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ChannelSeqID" HeaderText="CSID" />
                    <asp:BoundField DataField="ChannelPersonName" HeaderText="पुरा नाम" />
                    <asp:BoundField DataField="OrgName" HeaderText="सस्थां" />
                    <asp:BoundField DataField="DegName" HeaderText="पद" />
                    <asp:BoundField DataField="ChannelPersonOrder" HeaderText="तह" />
                    <asp:BoundField DataField="RDPersonType" HeaderText="प्रकार" />
                    <asp:BoundField DataField="RDIsFinalApprover" HeaderText="प्र. प्र. क" />
                    <asp:BoundField DataField="ChannelPersonID" HeaderText="Person" />
                </Columns>
            </asp:GridView>
        </asp:Panel>--%>
        <table width="640">
            <tr>
                <td style="width: 640px">
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" SkinID="Normal" Text="Submit" />
                    <asp:Button ID="btnCancelSubmit" runat="server" SkinID="Cancel" Text="Cancel" OnClick="btnCancelSubmit_Click" /></td>
            </tr>
        </table>
    </div>
</asp:Content>
