<%@ Page AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeFile="LeaveTippaniRequestViewer.aspx.cs" Inherits="MODULES_OAS_Tippani_LeaveTippaniRequestViewer" Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master"
    Title="Untitled Page" %>

<%@ Register Src="../UserControls/ChannelPerson.ascx" TagName="ChannelPerson" TagPrefix="uc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <script language="javascript" type="text/javascript">
        function ConfirmSendBack()
        {
            var result = confirm('तपाई यो टिप्पनीलाइ फिर्ता पठाउन चहानुहुन्छ्।');
            return result;
        }
    </script>
    
    <div style="width: 100%; height: auto">
        <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
        <ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior"
            DropShadow="True" PopupControlID="programmaticPopup" PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
            TargetControlID="hiddenTargetControlForModalPopup">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none; width: 350px; padding: 10px">
            <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD; border: solid 1px Gray; color: Black; text-align: center;">
                Save Status
            </asp:Panel>
            <asp:UpdatePanel id="UpdatePanel1" runat="server">
                <contenttemplate>
<asp:Label id="lblStatusMessage" runat="server" Text="Label" __designer:wfdid="w131"></asp:Label> 
</contenttemplate>
            </asp:UpdatePanel>
            <br />
            <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click" Text="OK" Width="58px" />
            <br />
        </asp:Panel>
        <ajaxToolkit:MaskedEditExtender ID="mskFromDate" runat="server" AutoComplete="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtFromDate">
        </ajaxToolkit:MaskedEditExtender>
        <ajaxToolkit:MaskedEditExtender ID="mskToDate" runat="server" AutoComplete="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtToDate">
        </ajaxToolkit:MaskedEditExtender>
        <br />
        <table width="640">
            <tr>
                <td style="width: 158px;">
                    <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="कार्यालय"></asp:Label></td>
                <td style="width: 200px;">
                    <asp:DropDownList ID="ddlOrg" runat="server" Width="190px">
                    </asp:DropDownList></td>
                <td style="width: 120px; padding-left: 40px">
                    <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="स्थिति"></asp:Label></td>
                <td style="width: 200px; height: 24px;">
                    <asp:DropDownList ID="ddlStatus" runat="server" Width="190px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 158px">
                    <asp:Label ID="Label3" runat="server" SkinID="Unicodelbl" Text="अवधि देखि"></asp:Label></td>
                <td style="width: 200px">
                    <asp:TextBox ID="txtFromDate" runat="server" SkinID="Unicodetxt" Width="186px"></asp:TextBox></td>
                <td style="width: 120px; padding-left: 40px">
                    <asp:Label ID="Label4" runat="server" SkinID="Unicodelbl" Text="अवधि सम्म"></asp:Label></td>
                <td style="width: 200px">
                    <asp:TextBox ID="txtToDate" runat="server" SkinID="Unicodetxt" Width="186px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 158px">
                </td>
                <td colspan="2">
                    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" SkinID="Normal" Text="Search" />&nbsp;<asp:Button ID="btnCancel" runat="server" SkinID="Cancel"
                        Text="Cancel" /></td>
                <td style="width: 200px">
                </td>
            </tr>
        </table>
        <hr />
        <table width="100%">
            <tr>
                <td style="width: 7%" valign="top">
                    <br />
                    <table width="100" cellpadding="0" cellspacing="0">
                        <tr style="background-image: url(../../COMMON/Images/bar.jpg)">
                            <td align="center" style="width: 100px; height: 25px">
                                .:
                                <asp:Label ID="Label10" runat="server" SkinID="Unicodelbl" Text="मिनु लिस्ट" Font-Underline="True"></asp:Label></td>
                        </tr>
                        <tr style="background-image: url(../../COMMON/Images/bar.jpg)">
                            <td style="width: 100px; height: 25px">
                        <asp:LinkButton ID="lnkSender" runat="server" Width="100px" OnClick="lnkSender_Click" SkinID="Tippani">तपाइलाई पठाएको</asp:LinkButton></td>
                        </tr>
                        <tr style="background-image: url(../../COMMON/Images/bar.jpg)">
                            <td style="width: 100px; height: 25px">
                                <asp:LinkButton ID="lnkReceiver" runat="server" OnClick="lnkReceiver_Click" SkinID="Tippani" Width="100px">तपाईले पठाएको</asp:LinkButton></td>
                        </tr>
                        <tr style="background-image: url(../../COMMON/Images/bar.jpg)">
                            <td style="width: 100px; height: 25px;">
                                <asp:LinkButton ID="lnkDeleted" runat="server" SkinID="Tippani" Width="100px" OnClick="lnkDeleted_Click">हटाएको</asp:LinkButton></td>
                        </tr>
                    </table>
                </td>
                <td style="width: 93%">
        <asp:UpdatePanel id="UpdatePanel2" runat="server">
            <contenttemplate>
<asp:Label id="lblRequestCount" runat="server" Text="Request Count" SkinID="UnicodeHeadlbl" __designer:wfdid="w228"></asp:Label><asp:Panel id="pnlRequest" runat="server" Width="100%" __designer:wfdid="w229" ScrollBars="Auto"><asp:GridView id="grdRequest" runat="server" Width="100%" SkinID="Plaingrd" __designer:wfdid="w230" OnDataBound="grdRequest_DataBound" OnRowDataBound="grdRequest_RowDataBound" ForeColor="#333333" CellPadding="0" AutoGenerateColumns="False" OnSelectedIndexChanged="grdRequest_SelectedIndexChanged">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="TippaniFromOrgID" HeaderText="OrgID"></asp:BoundField>
<asp:BoundField DataField="TippaniFromOrgName" HeaderText="OrgName"></asp:BoundField>
<asp:BoundField DataField="TippaniID" HeaderText="TippaniID"></asp:BoundField>
<asp:BoundField DataField="TippaniProcessID" HeaderText="ProcessID"></asp:BoundField>
<asp:BoundField DataField="ProcessByID" HeaderText="ProcessByID"></asp:BoundField>
<asp:BoundField DataField="ProcessToID" HeaderText="ProcessToID"></asp:BoundField>
<asp:BoundField DataField="TippaniSubjectID"></asp:BoundField>
<asp:BoundField DataField="TippaniByOrgName" HeaderText="ब्यक्त्तिको कार्यालय"></asp:BoundField>
<asp:BoundField DataField="TippaniByDesName" HeaderText="ब्यक्त्तिको पद"></asp:BoundField>
<asp:BoundField DataField="ProcessBy" HeaderText="ब्यक्त्तिको नाम"></asp:BoundField>
<asp:BoundField DataField="ProcessOn" HeaderText="पठाएको मिति"></asp:BoundField>
<asp:BoundField DataField="ProcessTo" HeaderText="पाउने ब्यक्त्तिको नाम"></asp:BoundField>
<asp:BoundField DataField="StatusID" HeaderText="StatusID"></asp:BoundField>
<asp:BoundField DataField="StatusName" HeaderText="पाउने ब्यक्त्तिको निर्णय"></asp:BoundField>
<asp:CommandField ShowSelectButton="True"></asp:CommandField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView></asp:Panel>&nbsp;<BR /><DIV style="WIDTH: 100%; HEIGHT: auto"><cc1:tabcontainer id="EvaluationTab" runat="server" __designer:wfdid="w1" ScrollBars="Auto" width="100%" height="550px" cssclass="ajax_tab_theme" activetabindex="1"><ajaxToolkit:TabPanel runat="server" ID="TabPanel1" HeaderText="TabPanel1"><ContentTemplate>
<TABLE width=700><TBODY><TR><TD colSpan=2><asp:Label id="Label451" runat="server" Text="टिप्पणीको बिबरण" SkinID="UnicodeHeadlbl" __designer:wfdid="w775"></asp:Label> <asp:HiddenField id="hdnForm" runat="server" __designer:dtid="281474976710710" __designer:wfdid="w776" Value="0"></asp:HiddenField> </TD></TR><TR><TD style="BORDER-RIGHT: gainsboro thin solid; BORDER-TOP: gainsboro thin solid; BORDER-LEFT: gainsboro thin solid; BORDER-BOTTOM: gainsboro thin solid" colSpan=2><asp:Label id="lblTippaniText" runat="server" SkinID="Unicodelbl" __designer:wfdid="w777">टिप्पणी को लेख</asp:Label> </TD></TR><TR><TD style="BORDER-RIGHT: gainsboro thin solid; BORDER-TOP: gainsboro thin solid; BORDER-LEFT: gainsboro thin solid; WIDTH: 150px; BORDER-BOTTOM: gainsboro thin solid">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label id="lblEmpName" runat="server" Text="कर्मचारीको नाम: " SkinID="Unicodelbl" __designer:wfdid="w778"></asp:Label> </TD><TD style="BORDER-RIGHT: gainsboro thin solid; BORDER-TOP: gainsboro thin solid; BORDER-LEFT: gainsboro thin solid; BORDER-BOTTOM: gainsboro thin solid" width=550><asp:Label id="lblName" runat="server" SkinID="Unicodelbl" Font-Bold="True" __designer:wfdid="w779"></asp:Label> </TD></TR><TR><TD style="BORDER-RIGHT: gainsboro thin solid; BORDER-TOP: gainsboro thin solid; BORDER-LEFT: gainsboro thin solid; WIDTH: 150px; BORDER-BOTTOM: gainsboro thin solid">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label id="Label11" runat="server" Text="कार्यालय:" SkinID="Unicodelbl" __designer:wfdid="w780"></asp:Label> </TD><TD style="BORDER-RIGHT: gainsboro thin solid; BORDER-TOP: gainsboro thin solid; BORDER-LEFT: gainsboro thin solid; BORDER-BOTTOM: gainsboro thin solid" width=550><asp:Label id="lblOrgName" runat="server" SkinID="Unicodelbl" Font-Bold="False" __designer:wfdid="w781"></asp:Label> </TD></TR><TR><TD style="BORDER-RIGHT: gainsboro thin solid; BORDER-TOP: gainsboro thin solid; BORDER-LEFT: gainsboro thin solid; WIDTH: 150px; BORDER-BOTTOM: gainsboro thin solid">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label id="Label13" runat="server" Text="पद: " SkinID="Unicodelbl" __designer:wfdid="w782"></asp:Label> </TD><TD style="BORDER-RIGHT: gainsboro thin solid; BORDER-TOP: gainsboro thin solid; BORDER-LEFT: gainsboro thin solid; BORDER-BOTTOM: gainsboro thin solid" width=550><asp:Label id="lblDesName" runat="server" SkinID="Unicodelbl" Font-Bold="False" __designer:wfdid="w783"></asp:Label> </TD></TR><TR><TD style="BORDER-RIGHT: gainsboro thin solid; BORDER-TOP: gainsboro thin solid; BORDER-LEFT: gainsboro thin solid; WIDTH: 150px; BORDER-BOTTOM: gainsboro thin solid">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label id="Label5" runat="server" Text="बिषय: " SkinID="Unicodelbl" __designer:wfdid="w784"></asp:Label> </TD><TD style="BORDER-RIGHT: gainsboro thin solid; BORDER-TOP: gainsboro thin solid; BORDER-LEFT: gainsboro thin solid; BORDER-BOTTOM: gainsboro thin solid" width=550><asp:Label id="lblVisitSubject" runat="server" SkinID="Unicodelbl" Font-Bold="True" __designer:wfdid="w785"></asp:Label> </TD></TR><TR><TD style="BORDER-RIGHT: gainsboro thin solid; BORDER-TOP: gainsboro thin solid; BORDER-LEFT: gainsboro thin solid; WIDTH: 150px; BORDER-BOTTOM: gainsboro thin solid">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label id="Label6" runat="server" Text="ठाउ: " SkinID="Unicodelbl" __designer:wfdid="w786"></asp:Label> </TD><TD style="BORDER-RIGHT: gainsboro thin solid; BORDER-TOP: gainsboro thin solid; BORDER-LEFT: gainsboro thin solid; BORDER-BOTTOM: gainsboro thin solid" width=550><asp:Label id="lblVisitLocation" runat="server" SkinID="Unicodelbl" Font-Bold="False" __designer:wfdid="w787"></asp:Label> </TD></TR><TR><TD style="BORDER-RIGHT: gainsboro thin solid; BORDER-TOP: gainsboro thin solid; BORDER-LEFT: gainsboro thin solid; WIDTH: 150px; BORDER-BOTTOM: gainsboro thin solid">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label id="lbl" runat="server" Text="देश: " SkinID="Unicodelbl" __designer:wfdid="w788"></asp:Label> </TD><TD style="BORDER-RIGHT: gainsboro thin solid; BORDER-TOP: gainsboro thin solid; BORDER-LEFT: gainsboro thin solid; BORDER-BOTTOM: gainsboro thin solid" width=550><asp:Label id="lblVisitCountry" runat="server" SkinID="Unicodelbl" Font-Bold="False" __designer:wfdid="w789"></asp:Label> </TD></TR><TR><TD style="BORDER-RIGHT: gainsboro thin solid; BORDER-TOP: gainsboro thin solid; BORDER-LEFT: gainsboro thin solid; WIDTH: 150px; BORDER-BOTTOM: gainsboro thin solid">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label id="Label9" runat="server" Text="कैफियत: " SkinID="Unicodelbl" __designer:wfdid="w790"></asp:Label> </TD><TD style="BORDER-RIGHT: gainsboro thin solid; BORDER-TOP: gainsboro thin solid; BORDER-LEFT: gainsboro thin solid; BORDER-BOTTOM: gainsboro thin solid" width=550><asp:Label id="lblVisitRemark" runat="server" SkinID="Unicodelbl" Font-Bold="False" __designer:wfdid="w791"></asp:Label> </TD></TR><TR><TD style="BORDER-RIGHT: gainsboro thin solid; BORDER-TOP: gainsboro thin solid; BORDER-LEFT: gainsboro thin solid; WIDTH: 150px; BORDER-BOTTOM: gainsboro thin solid">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label id="Label7" runat="server" Text="अवधि देखि: " SkinID="Unicodelbl" __designer:wfdid="w792"></asp:Label> </TD><TD style="BORDER-RIGHT: gainsboro thin solid; BORDER-TOP: gainsboro thin solid; BORDER-LEFT: gainsboro thin solid; BORDER-BOTTOM: gainsboro thin solid" width=550><asp:Label id="lblVisitFromDate" runat="server" SkinID="Unicodelbl" Font-Bold="False" __designer:wfdid="w793"></asp:Label> </TD></TR><TR><TD style="BORDER-RIGHT: gainsboro thin solid; BORDER-TOP: gainsboro thin solid; BORDER-LEFT: gainsboro thin solid; WIDTH: 150px; BORDER-BOTTOM: gainsboro thin solid">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label id="Label12" runat="server" Text="अवधि सम्म: " SkinID="Unicodelbl" __designer:wfdid="w794"></asp:Label> </TD><TD style="BORDER-RIGHT: gainsboro thin solid; BORDER-TOP: gainsboro thin solid; BORDER-LEFT: gainsboro thin solid; BORDER-BOTTOM: gainsboro thin solid" width=550><asp:Label id="lblVisittoDate" runat="server" SkinID="Unicodelbl" Font-Bold="False" __designer:wfdid="w795"></asp:Label> </TD></TR><TR><TD style="BORDER-RIGHT: gainsboro thin solid; BORDER-TOP: gainsboro thin solid; BORDER-LEFT: gainsboro thin solid; WIDTH: 150px; BORDER-BOTTOM: gainsboro thin solid">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label id="Label8" runat="server" Text="तपांइको निर्णय:" SkinID="Unicodelbl" __designer:wfdid="w796"></asp:Label> </TD><TD style="BORDER-RIGHT: gainsboro thin solid; BORDER-TOP: gainsboro thin solid; BORDER-LEFT: gainsboro thin solid; BORDER-BOTTOM: gainsboro thin solid" width=550><asp:DropDownList id="ddlDStatus_Rqd" runat="server" Width="190px" __designer:wfdid="w797"></asp:DropDownList> </TD></TR><TR><TD style="BORDER-RIGHT: gainsboro thin solid; BORDER-TOP: gainsboro thin solid; BORDER-LEFT: gainsboro thin solid; WIDTH: 150px; BORDER-BOTTOM: gainsboro thin solid" vAlign=top>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label id="Label14" runat="server" Text="तपांइको नोट:" SkinID="Unicodelbl" __designer:wfdid="w798"></asp:Label> </TD><TD style="BORDER-RIGHT: gainsboro thin solid; BORDER-TOP: gainsboro thin solid; BORDER-LEFT: gainsboro thin solid; BORDER-BOTTOM: gainsboro thin solid" vAlign=top width=550><asp:TextBox id="txtNote" runat="server" Width="500px" Height="200px" SkinID="Unicodetxt" __designer:wfdid="w799" TextMode="MultiLine"></asp:TextBox> </TD></TR><TR><TD style="BORDER-RIGHT: gainsboro thin solid; BORDER-TOP: gainsboro thin solid; BORDER-LEFT: gainsboro thin solid; WIDTH: 150px; BORDER-BOTTOM: gainsboro thin solid; HEIGHT: 21px" vAlign=top></TD><TD style="BORDER-RIGHT: gainsboro thin solid; BORDER-TOP: gainsboro thin solid; BORDER-LEFT: gainsboro thin solid; BORDER-BOTTOM: gainsboro thin solid; HEIGHT: 21px" vAlign=top width=550><asp:Button id="btnSendBack" onclick="btnSendBack_Click" runat="server" Width="100px" Text="Send Back" SkinID="Dynamic" __designer:wfdid="w800" OnClientClick="return ConfirmSendBack();" Enabled="False"></asp:Button> </TD></TR></TBODY></TABLE>
</ContentTemplate>
<HeaderTemplate>
                    कर्मचारीको कार्य
                
</HeaderTemplate>
</ajaxToolkit:TabPanel>
<ajaxToolkit:TabPanel runat="server" ID="TabPanel2" HeaderText="TabPanel2"><HeaderTemplate>
                    मुल्यांकन बिवरण
                
</HeaderTemplate>
</ajaxToolkit:TabPanel>
</cc1:tabcontainer> </DIV>
</contenttemplate>
            <triggers>
<asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="lnkSender" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="lnkReceiver" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="lnkDeleted" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnSubmit" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
        </asp:UpdatePanel></td>
            </tr>
        </table>
        <hr />
        <uc1:ChannelPerson ID="chnlPerson" runat="server" ApplicationString="5, 3" TippaniSubjectID="2" />
        <br />
        <%--<asp:Label ID="Label19" runat="server" SkinID="UnicodeHeadlbl" Text="सिफारीस कर्त्ता"></asp:Label>
        <cc1:tabcontainer id="EvaluationTab" runat="server" activetabindex="1"
            cssclass="ajax_tab_theme" width="100%"><ajaxToolkit:TabPanel id="TabPanel1" runat="server" HeaderText="TabPanel1"><ContentTemplate>
<DIV style="WIDTH: 100%; HEIGHT: 500px"><asp:Panel id="pnlForChannelPerson" runat="server" Width="100%" Height="480px" __designer:wfdid="w120" ScrollBars="Auto"><asp:Label id="lblChannelPersonCount" runat="server" SkinID="Unicodelbl" __designer:dtid="844424930132104" Font-Underline="True" __designer:wfdid="w121"></asp:Label> <BR /><asp:GridView id="grdChannelPerson" runat="server" Width="100%" __designer:wfdid="w122" OnDataBound="grdChannelPerson_DataBound" OnRowDataBound="grdChannelPerson_RowDataBound" ForeColor="#333333" CellPadding="0" GridLines="None" AutoGenerateColumns="False">
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
</ContentTemplate>
<HeaderTemplate>
टिप्पणी च्यानल बाट&nbsp; 
</HeaderTemplate>
</ajaxToolkit:TabPanel> <ajaxToolkit:TabPanel id="TabPanel2" runat="server" HeaderText="TabPanel2"><ContentTemplate>
<DIV style="WIDTH: 100%; HEIGHT: 500px"><asp:Label id="lblChannelPersonCountX" runat="server" SkinID="Unicodelbl" __designer:dtid="844424930132104" Font-Underline="True" __designer:wfdid="w199">साधारण कर्मचारी खोज्नुहोस</asp:Label> <BR /><TABLE style="WIDTH: 939px" __designer:dtid="562949953421325"><TBODY><TR __designer:dtid="562949953421326"><TD __designer:dtid="562949953421327"><asp:Label id="Label24" runat="server" Width="110px" Height="22px" Text="संकेत नं" SkinID="Unicodelbl" __designer:dtid="562949953421328" __designer:wfdid="w200"></asp:Label> </TD><TD __designer:dtid="562949953421329"><asp:TextBox id="TextBox2" runat="server" Width="130px" SkinID="Unicodetxt" __designer:dtid="562949953421330" __designer:wfdid="w201" MaxLength="15" ToolTip="First Name"></asp:TextBox> </TD><TD __designer:dtid="562949953421331"></TD><TD __designer:dtid="562949953421332"></TD><TD __designer:dtid="562949953421333"></TD><TD __designer:dtid="562949953421334"></TD></TR><TR __designer:dtid="562949953421335"><TD __designer:dtid="562949953421336"><asp:Label id="Label25" runat="server" Width="92px" Height="22px" Text="पहिलो नाम" SkinID="Unicodelbl" __designer:dtid="562949953421337" __designer:wfdid="w202"></asp:Label> </TD><TD __designer:dtid="562949953421338"><asp:TextBox id="txtSFname" runat="server" Width="130px" SkinID="Unicodetxt" __designer:dtid="562949953421339" __designer:wfdid="w203" MaxLength="35" ToolTip="First Name"></asp:TextBox> </TD><TD __designer:dtid="562949953421340"><asp:Label id="Label26" runat="server" Width="92px" Height="22px" Text="बिचको नाम" SkinID="Unicodelbl" __designer:dtid="562949953421341" __designer:wfdid="w204"></asp:Label> </TD><TD __designer:dtid="562949953421342"><asp:TextBox id="txtSMname" runat="server" Width="130px" SkinID="Unicodetxt" __designer:dtid="562949953421343" __designer:wfdid="w205" MaxLength="15"></asp:TextBox> </TD><TD __designer:dtid="562949953421344"><asp:Label id="Label27" runat="server" Width="92px" Height="22px" Text="थर" SkinID="Unicodelbl" __designer:dtid="562949953421345" __designer:wfdid="w206"></asp:Label> </TD><TD __designer:dtid="562949953421346"><asp:TextBox id="txtSLname" runat="server" Width="130px" SkinID="Unicodetxt" __designer:dtid="562949953421347" __designer:wfdid="w207" MaxLength="35" ToolTip="Surname"></asp:TextBox> </TD></TR><TR __designer:dtid="562949953421348"><TD __designer:dtid="562949953421349"><asp:Label id="Label28" runat="server" Width="92px" Height="22px" Text="लिंग" SkinID="Unicodelbl" __designer:dtid="562949953421350" __designer:wfdid="w208"></asp:Label> </TD><TD __designer:dtid="562949953421351"><asp:DropDownList id="ddlSSex" runat="server" Width="135px" SkinID="Unicodeddl" __designer:dtid="562949953421352" __designer:wfdid="w209"><asp:ListItem Value="SG" __designer:dtid="562949953421353">छान्नुहोस</asp:ListItem>
<asp:ListItem Value="M">पुरुष</asp:ListItem>
<asp:ListItem Value="F">महिला</asp:ListItem>
<asp:ListItem Value="O">अन्य</asp:ListItem>
</asp:DropDownList> </TD><TD><asp:Label id="Label29" runat="server" Width="110px" Height="22px" Text="जन्म मिति" SkinID="Unicodelbl" __designer:dtid="562949953421358" __designer:wfdid="w210"></asp:Label> </TD><TD __designer:dtid="562949953421359"><asp:TextBox id="txtSDob" runat="server" Width="130px" SkinID="Unicodetxt" __designer:dtid="562949953421360" __designer:wfdid="w211" MaxLength="10"></asp:TextBox> </TD><TD __designer:dtid="562949953421361"><asp:Label id="Label31" runat="server" Width="114px" Height="22px" Text="बैबाहिक सम्बन्ध" SkinID="Unicodelbl" __designer:dtid="562949953421362" __designer:wfdid="w212"></asp:Label> </TD><TD __designer:dtid="562949953421363"><asp:DropDownList id="ddlSMaritalStatus" runat="server" Width="135px" SkinID="Unicodeddl" __designer:dtid="562949953421364" __designer:wfdid="w213"><asp:ListItem Value="SMS" __designer:dtid="562949953421365">छान्नुहोस</asp:ListItem>
<asp:ListItem Value="S">अबिबाहित</asp:ListItem>
<asp:ListItem Value="M">बिबाहित</asp:ListItem>
<asp:ListItem Value="W">बिधवा/बिदुर</asp:ListItem>
<asp:ListItem Value="D">छोडपत्र</asp:ListItem>
<asp:ListItem Value="O">अन्य</asp:ListItem>
</asp:DropDownList> </TD></TR><TR><TD><asp:Label id="Label32" runat="server" Text="कार्यालय" SkinID="Unicodelbl" __designer:dtid="562949953421373" __designer:wfdid="w214"></asp:Label> </TD><TD colSpan=3 __designer:dtid="562949953421374"><asp:DropDownList id="ddlSOrg" runat="server" Width="478px" SkinID="Unicodeddl" __designer:dtid="562949953421375" __designer:wfdid="w215" AutoPostBack="True"></asp:DropDownList> </TD><TD __designer:dtid="562949953421376"><asp:Label id="Label33" runat="server" Text="पद" SkinID="Unicodelbl" __designer:dtid="562949953421377" __designer:wfdid="w216"></asp:Label> </TD><TD __designer:dtid="562949953421378"><asp:DropDownList id="ddlSDesgination" runat="server" Width="135px" SkinID="Unicodeddl" __designer:dtid="562949953421379" __designer:wfdid="w217"></asp:DropDownList> </TD></TR><TR __designer:dtid="562949953421392"><TD align=left colSpan=6 __designer:dtid="562949953421393"><asp:Button id="btnSearchGeneral" onclick="btnSearchGeneral_Click" runat="server" Text="Search" SkinID="Normal" __designer:dtid="562949953421394" __designer:wfdid="w218"></asp:Button> <asp:Button id="btnCancelGeneral" onclick="btnCancelGeneral_Click" runat="server" Text="Cancel" SkinID="Cancel" __designer:dtid="562949953421395" __designer:wfdid="w219"></asp:Button> <ajaxToolkit:MaskedEditExtender id="mskSDob" runat="server" __designer:dtid="562949953421396" TargetControlID="txtSDob" MaskType="Date" Mask="9999/99/99" AutoComplete="False" __designer:wfdid="w220" Enabled="True" CultureThousandsPlaceholder="" CultureDecimalPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureAMPMPlaceholder="" CultureDateFormat="" CultureTimePlaceholder="" CultureDatePlaceholder=""></ajaxToolkit:MaskedEditExtender> </TD></TR></TBODY></TABLE><asp:UpdatePanel id="UpdatePanel4" runat="server" __designer:dtid="562949953421398" __designer:wfdid="w221"><ContentTemplate __designer:dtid="562949953421399">
<asp:Label id="lblSearchX" runat="server" SkinID="Unicodelbl" Font-Bold="False" __designer:wfdid="w225"></asp:Label><BR /><asp:Panel id="pnlGeneralEmployee" runat="server" Width="100%" Height="300px" __designer:wfdid="w226" ScrollBars="Auto"><asp:GridView id="grdSEmployee" runat="server" Width="100%" SkinID="Unicodegrd" __designer:wfdid="w227" OnDataBound="grdSEmployee_DataBound" OnRowDataBound="grdEmployee_RowDataBound" ForeColor="#333333" CellPadding="0" GridLines="None" AutoGenerateColumns="False">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="PersonID" HeaderText="EmpID"></asp:BoundField>
<asp:TemplateField>
<ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
<ItemTemplate>
<asp:CheckBox id="chkGSelect" runat="server" ></asp:CheckBox>
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
</ContentTemplate>
<HeaderTemplate>
साधारण कर्मचारी&nbsp; 
</HeaderTemplate>
</ajaxToolkit:TabPanel> </cc1:tabcontainer>
<br /> --%>
        <table width="500">
            <tr>
                <td style="width: 500px">
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" SkinID="Normal" Text="Submit" />
                    <asp:Button ID="btnCancelSubmit" runat="server" SkinID="Cancel" Text="Cancel" OnClick="btnCancelSubmit_Click" /></td>
            </tr>
        </table>
    </div>
</asp:Content>
