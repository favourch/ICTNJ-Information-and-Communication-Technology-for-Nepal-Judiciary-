<%@ Page AutoEventWireup="true" CodeFile="TippaniChannel.aspx.cs" Inherits="MODULES_OAS_Tippani_TippaniChannel" Language="C#" MaintainScrollPositionOnPostback="true"
    MasterPageFile="~/MODULES/OAS/MasterPage.master" Title="OAS | Tippani Channel" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script language="javascript" src="../../COMMON/JS/Validation.js" type="text/javascript"></script>
    <script language="javascript" src="../../COMMON/JS/DateValidator.js" type="text/javascript"></script>
    <script language="javascript" src="../../COMMON/JS/EnglishDateValidator.js" type="text/javascript"></script>
    
    <script language="javascript" type="text/javascript" defer="defer">
        function ProcessFinalApprover(chk)
        {
            var cntls = document.getElementsByTagName("INPUT");
            
            for(var i = 0; i < cntls.length; i++)
            {
                if(cntls[i].getAttribute("type") == "checkbox")
                    if(chk.id != cntls[i].id)
                        cntls[i].checked = false;
            }
        }
    </script>

    <div style="width:100%; height:auto">
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager>
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
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
</contenttemplate>
            </asp:UpdatePanel>
            <br />
            <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click" Text="OK" Width="58px" />
        </asp:Panel>
        <br />
        <table width="1000" height="250">
            <tr>
                <td colspan="2" rowspan="1" valign="top">
                    <asp:DropDownList ID="ddlTippaniOrg" runat="server" Width="200px">
                    </asp:DropDownList>
                    &nbsp; &nbsp;&nbsp;
                    <asp:Label ID="lblTippaniOrg" runat="server" SkinID="UnicodeHeadlbl" Text="सस्थांको टिप्पनि च्यानल"></asp:Label></td>
            </tr>
            <tr>
                <td height="250" rowspan="2" style="width: 220px" valign="top">
                    <asp:UpdatePanel id="UpdatePanel5" runat="server">
                        <contenttemplate>
<asp:ListBox id="lstTippaniSubject" runat="server" Width="200px" Height="250px" SkinID="Unicodelst" OnSelectedIndexChanged="lstTippaniSubject_SelectedIndexChanged" AutoPostBack="True" __designer:wfdid="w6"></asp:ListBox> 
</contenttemplate>
                        <triggers>
<asp:AsyncPostBackTrigger ControlID="btnSubmit" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
                    </asp:UpdatePanel></td>
                <td style="width: 780px" valign="top" height="220">
                    <asp:UpdatePanel id="UpdatePanel4" runat="server">
                        <contenttemplate>
<asp:Panel id="pnlChannelPerson" runat="server" Width="100%" Height="220px" __designer:wfdid="w7" ScrollBars="Auto"><asp:GridView id="grdChannelPerson" runat="server" Width="100%" SkinID="Unicodegrd" __designer:wfdid="w8" ForeColor="#333333" CellPadding="0" AutoGenerateColumns="False" OnRowDataBound="grdChannelPerson_RowDataBound" OnRowDeleting="grdChannelPerson_RowDeleting">
<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
<asp:BoundField DataField="TippaniSubjectID" HeaderText="TSI"></asp:BoundField>
<asp:BoundField DataField="ChannelPersonID" HeaderText="EmpID"></asp:BoundField>
<asp:BoundField HeaderText="क्रम."></asp:BoundField>
<asp:BoundField DataField="ChannelPersonName" HeaderText="पुरा नाम थर"></asp:BoundField>
<asp:BoundField DataField="OrgName" HeaderText="कार्यालय"></asp:BoundField>
<asp:BoundField DataField="DegName" HeaderText="पद"></asp:BoundField>
<asp:BoundField DataField="CommitteeName" HeaderText="कमिटि"></asp:BoundField>
<asp:BoundField DataField="PostName" HeaderText="पद"></asp:BoundField>
<asp:TemplateField HeaderText="शुरु मिति"><ItemTemplate>
<asp:TextBox id="txtFromDate_Rdt" runat="server" Width="75px" Text='<%# Eval("FromDate") %>' SkinID="Unicodetxt" ToolTip="शुरु मिति" __designer:wfdid="w1" ReadOnly='<%# Eval("EnableDate") %>' BackColor='<%# Eval("DateColor") %>' Enabled='<%# Eval("Enable") %>'></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="mskFromDate" runat="server" TargetControlID="txtFromDate_Rdt" MaskType="Date" Mask="9999/99/99" AutoComplete="False" __designer:wfdid="w2"></ajaxToolkit:MaskedEditExtender> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="क्रम"><ItemTemplate>
<asp:DropDownList id="ddlOrder_Rqd" runat="server" Width="40px" SkinID="Unicodeddl" ToolTip="क्रम." __designer:wfdid="w14" Enabled='<%# Eval("Enable") %>' SelectedValue='<%# Eval("ChannelPersonOrder") %>'><asp:ListItem Value="0">क्रम</asp:ListItem>
<asp:ListItem>1</asp:ListItem>
<asp:ListItem>2</asp:ListItem>
<asp:ListItem>3</asp:ListItem>
<asp:ListItem>4</asp:ListItem>
<asp:ListItem>5</asp:ListItem>
<asp:ListItem>6</asp:ListItem>
<asp:ListItem>7</asp:ListItem>
<asp:ListItem>8</asp:ListItem>
<asp:ListItem>9</asp:ListItem>
<asp:ListItem>10</asp:ListItem>
</asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="प्रकार"><ItemTemplate>
<asp:DropDownList id="ddlType_Rqd" runat="server" Width="55px" SkinID="Unicodeddl" ToolTip="प्रकार" Enabled='<%# Eval("Enable") %>' __designer:wfdid="w1" SelectedValue='<%# Eval("ChannelPersonType") %>'><asp:ListItem Selected="True" Value="0">प्रकार</asp:ListItem>
<asp:ListItem Value="INI">Init</asp:ListItem>
<asp:ListItem Value="REC">Rec</asp:ListItem>
<asp:ListItem Value="APP">App</asp:ListItem>
</asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="प्र.प्र.क"><ItemTemplate>
<asp:CheckBox id="chkApprover" runat="server" __designer:wfdid="w13" Enabled='<%# Eval("Enable") %>' Checked='<%# Eval("IsFinalApprover") %>'></asp:CheckBox> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="Action" HeaderText="Act"></asp:BoundField>
<asp:CommandField ShowDeleteButton="True"></asp:CommandField>
<asp:BoundField DataField="OldValue" HeaderText="oValue"></asp:BoundField>
<asp:BoundField DataField="OrgID" HeaderText="OrgID"></asp:BoundField>
<asp:BoundField DataField="DesID" HeaderText="DesIG"></asp:BoundField>
<asp:BoundField DataField="CreatedDate" HeaderText="Cdate"></asp:BoundField>
<asp:BoundField DataField="PostID" HeaderText="PostID"></asp:BoundField>
<asp:BoundField DataField="PostFromDate" HeaderText="PFromDate"></asp:BoundField>
<asp:BoundField DataField="ChannelSeqID" HeaderText="ChannelSeqID"></asp:BoundField>
<asp:BoundField DataField="OTOrgID" HeaderText="OTOrgID"></asp:BoundField>
</Columns>

<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView></asp:Panel> 
</contenttemplate>
                        <triggers>
<asp:AsyncPostBackTrigger ControlID="btnAddChannelPerson" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnSubmit" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="lstTippaniSubject" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnCancelSubmit" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td style="width: 780px; height: 21px" valign="top">
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" SkinID="Normal" Text="Submit" OnClientClick="return validate(1);" />
                    <asp:Button ID="btnCancelSubmit" runat="server" SkinID="Cancel" Text="Cancel" OnClick="btnCancelSubmit_Click" /></td>
            </tr>
        </table>
        <hr />
        <table style="width: 939px">
            <tr>
                <td>
                    <asp:Label ID="Label30" runat="server" SkinID="Unicodelbl" Text="संकेत नं" Width="110px"></asp:Label></td>
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
                    <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="पहिलो नाम" Width="92px"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtFName" runat="server" MaxLength="35" SkinID="Unicodetxt" ToolTip="First Name" Width="130px"></asp:TextBox></td>
                <td>
                    &nbsp; &nbsp; &nbsp;
                    <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="बिचको नाम" Width="92px"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtMName" runat="server" MaxLength="15" SkinID="Unicodetxt" Width="130px"></asp:TextBox></td>
                <td>
                    <asp:Label ID="Label3" runat="server" SkinID="Unicodelbl" Text="थर" Width="55px"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtSurName" runat="server" MaxLength="35" SkinID="Unicodetxt" ToolTip="Surname" Width="130px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" SkinID="Unicodelbl" Text="लिंग" Width="92px"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddlGender" runat="server" SkinID="Unicodeddl" Width="135px">
                        <asp:ListItem Value="SG">छान्नुहोस</asp:ListItem>
                        <asp:ListItem Value="M">पुरुष</asp:ListItem>
                        <asp:ListItem Value="F">महिला</asp:ListItem>
                        <asp:ListItem Value="O">अन्य</asp:ListItem>
                    </asp:DropDownList></td>
                <td>
                    &nbsp; &nbsp; &nbsp;
                    <asp:Label ID="Label4" runat="server" SkinID="Unicodelbl" Text="जन्म मिति" Width="91px"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtDOB" runat="server" MaxLength="10" SkinID="Unicodetxt" Width="130px"></asp:TextBox></td>
                <td>
                    <asp:Label ID="Label6" runat="server" SkinID="Unicodelbl" Text="बैबाहिक सम्बन्ध" Width="105px"></asp:Label></td>
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
                    <asp:Label ID="Label10" runat="server" SkinID="Unicodelbl" Text="शाखा"></asp:Label></td>
                <td>
                    <asp:UpdatePanel id="UpdatePanel6" runat="server">
                        <contenttemplate>
<asp:DropDownList id="ddlUnit" runat="server" Width="135px" OnSelectedIndexChanged="ddlCommittee_SelectedIndexChanged"></asp:DropDownList>
</contenttemplate>
                        <triggers>
<asp:AsyncPostBackTrigger ControlID="ddlOrganization" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
                    </asp:UpdatePanel></td>
                <td>
                </td>
                <td colspan="2">
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" SkinID="Unicodelbl" Text="कमिटि"></asp:Label></td>
                <td>
                    <asp:UpdatePanel id="UpdatePanel2" runat="server">
                        <contenttemplate>
<asp:DropDownList id="ddlCommittee" runat="server" Width="135px" OnSelectedIndexChanged="ddlCommittee_SelectedIndexChanged" Enabled="False"></asp:DropDownList> 
</contenttemplate>
                        <triggers>
<asp:AsyncPostBackTrigger ControlID="ddlOrganization" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
                    </asp:UpdatePanel>
                </td>
                <td>
                    &nbsp; &nbsp; &nbsp;
                    <asp:Label ID="Label9" runat="server" SkinID="Unicodelbl" Text="कमिटिको पद" Width="83px"></asp:Label></td>
                <td colspan="2">
                    <asp:DropDownList ID="ddlCommitteePost" runat="server" Width="220px" Enabled="False">
                    </asp:DropDownList></td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td colspan="4">
                    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" SkinID="Normal" Text="Search" />
                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click"
                        SkinID="Cancel" Text="Cancel" />
                    <asp:Button ID="btnAddChannelPerson" runat="server" OnClick="btnAddChannelPerson_Click" SkinID="Dynamic" Text="Add Person To Channel" Width="150px" /><ajaxToolkit:MaskedEditExtender ID="MSKdob" runat="server" AutoComplete="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtDOB">
                        </ajaxToolkit:MaskedEditExtender>
                </td>
                <td>
                </td>
            </tr>
        </table>
                    <asp:UpdatePanel id="UpdatePanel3" runat="server">
                        <contenttemplate>
<asp:Label id="lblSearch" runat="server" SkinID="Unicodelbl" Font-Bold="True" __designer:wfdid="w36"></asp:Label><BR /><DIV class="ChnlPersonDynamicPanel"><asp:GridView id="grdEmployee" runat="server" Width="100%" SkinID="Unicodegrd" OnSelectedIndexChanged="grdEmployee_SelectedIndexChanged" __designer:wfdid="w1" OnRowDataBound="grdEmployee_RowDataBound" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333" OnDataBound="grdEmployee_DataBound">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:TemplateField>
<ItemStyle HorizontalAlign="Center"></ItemStyle>
<ItemTemplate>
<asp:CheckBox id="chkSelect" runat="server" SkinID="smallChk" __designer:wfdid="w44"></asp:CheckBox>
</ItemTemplate>
</asp:TemplateField>
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
<asp:BoundField DataField="UnitName" HeaderText="शाखा"></asp:BoundField>
<asp:CommandField ShowSelectButton="True">
<ItemStyle Font-Names="Verdana"></ItemStyle>
</asp:CommandField>
<asp:BoundField DataField="OrgID" HeaderText="OrgID"></asp:BoundField>
<asp:BoundField DataField="DesID" HeaderText="DesID"></asp:BoundField>
<asp:BoundField DataField="UnitID" HeaderText="UnitID"></asp:BoundField>
<asp:BoundField DataField="CreatedDate" HeaderText="Cdate"></asp:BoundField>
<asp:BoundField DataField="PostID" HeaderText="PostID"></asp:BoundField>
<asp:BoundField DataField="PostFromDate" HeaderText="PFromDate"></asp:BoundField>
<asp:BoundField DataField="UnitFromDate" HeaderText="UnitFromDate"></asp:BoundField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView></DIV>
</contenttemplate>
                        <triggers>
<asp:PostBackTrigger ControlID="grdEmployee"></asp:PostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
                    </asp:UpdatePanel>
    </div>
</asp:Content>

