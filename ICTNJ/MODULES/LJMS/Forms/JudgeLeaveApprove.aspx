<%@ Page Language="C#" MasterPageFile="~/MODULES/LJMS/LJMSMasterPage.master" AutoEventWireup="true" CodeFile="JudgeLeaveApprove.aspx.cs" Inherits="MODULES_LJMS_Forms_JudgeLeaveApprove" Title="LJMS | JudgeLeave Approve" %>
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
                <asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click" Width="58px" />    <br />
        </asp:Panel>
        
        
     <asp:Button runat="server" ID="hiddenTargetControlForModalPopup2" style="display:none"/>
        <ajaxToolkit:ModalPopupExtender runat="server" ID="programmaticModalPopup2"
            BehaviorID="programmaticModalPopupBehavior2"
            TargetControlID="hiddenTargetControlForModalPopup2"
            PopupControlID="programmaticPopup2" 
            BackgroundCssClass="modalBackground"
            DropShadow="True"
            PopupDragHandleControlID="programmaticPopupDragHandle2"
            RepositionMode="RepositionOnWindowScroll" >
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel runat="server" CssClass="modalPopup" ID="programmaticPopup2" style="display:none;width:350px;padding:10px">
            <asp:Panel runat="Server" ID="programmaticPopupDragHandle2" Style="cursor: move;background-color:#DDDDDD;border:solid 1px Gray;color:Black;text-align:center;">
                Status
            </asp:Panel>
			
			 <asp:UpdatePanel id="UpdatePanel4" runat="server">
                <contenttemplate>
                    <br />
                    <asp:Label ID="lblStatusMessage2" runat="server" Height="19px" Text="Label"></asp:Label>
                </contenttemplate>
            </asp:UpdatePanel>
                <asp:Button ID="OkButton2" runat="server" Text="OK"  Width="58px" OnClick="OkButton2_Click" />    
            <asp:Button ID="Button1" runat="server"  Text="Cancel" OnClick="Button1_Click" /><br />
        </asp:Panel>
    <br />
    <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server" Collapsed="true" CollapseControlID="upper" ExpandControlID="upper" TargetControlID="PanelSearch" SuppressPostBack="true">
    </ajaxToolkit:CollapsiblePanelExtender>
    <br />
    <div id="upper" class="collapsePanelHeader" style="width: 938px; cursor: hand; height: 27px">
        कर्मचारी खिज्नुहोस्
    </div>
    <asp:Panel ID="PanelSearch" runat="server" Height="50px" Width="900px">
    <table style="width: 900px">
        <tr>
            <td>
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
            <td>
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
            <td>
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
            <td>
                <asp:Label ID="Label7" runat="server" SkinID="Unicodelbl" Text="कार्यालय"></asp:Label></td>
            <td colspan="3">
                <asp:DropDownList ID="ddlOrganization" runat="server" SkinID="Unicodeddl" Width="454px">
                </asp:DropDownList></td>
            <td>
                <asp:Label ID="lblDesignation" runat="server" SkinID="Unicodelbl" Text="पद"></asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlDesignation" runat="server" SkinID="Unicodeddl" Width="135px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td align="left" colspan="6">
                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" SkinID="Normal"
                    Text="Search" /><asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click"
                        SkinID="Cancel" Text="Cancel" /></td>
        </tr>
        <tr>
            <td colspan="6">
                <hr />
                <asp:Label ID="lblSearch" runat="server" Font-Bold="True"></asp:Label><br />
                <br />
                &nbsp;<asp:Panel ID="Panel1" runat="server" Height="150px" Width="890px" ScrollBars="Auto">
                    &nbsp;<asp:GridView ID="grdEmployee" runat="server" AutoGenerateColumns="False" CellPadding="0"
                        ForeColor="#333333" OnRowCreated="grdEmployee_RowCreated"
                        OnSelectedIndexChanged="grdEmployee_SelectedIndexChanged" SkinID="Unicodegrd"
                        Width="890px" Height="150px">
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
            </td>
        </tr>
    </table>
    </asp:Panel>
    <br />
    <br />
    
        
        <%--OUTER TABLE--%>
    <div id=second_div style="float: left; width: 938px; height:20px" runat="server" Class="divHeader">
        प्रमाणित गरिएको विवरण<br />
    <asp:UpdatePanel runat="server" id="asd">
    <contenttemplate>
<BR /><TABLE><TBODY><TR><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Label20" runat="server" Text="पुरा नाम" SkinID="Unicodelbl"></asp:Label> </TD><TD style="WIDTH: 100px" vAlign=top><asp:TextBox id="txtApprName" runat="server" Width="332px" SkinID="Unicodetxt" ReadOnly="True" AutoPostBack="True" __designer:wfdid="w140"></asp:TextBox> </TD><TD style="WIDTH: 100px" vAlign=top></TD><TD style="WIDTH: 100px" vAlign=top></TD></TR><TR><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Label21" runat="server" Width="152px" Text="प्रमाणित भएको मिति" SkinID="Unicodelbl"></asp:Label> </TD><TD style="WIDTH: 100px" vAlign=top><asp:TextBox id="txtApprDate" runat="server" Width="103px" SkinID="Unicodetxt" __designer:wfdid="w142"></asp:TextBox> </TD><TD style="WIDTH: 100px" vAlign=top></TD><TD style="WIDTH: 100px" vAlign=top></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 35px" vAlign=top><asp:Label id="Label22" runat="server" Text="अवधि देखि" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 35px" vAlign=top><asp:TextBox id="txtApprFrom" runat="server" Width="103px" SkinID="Unicodetxt" AutoPostBack="True" __designer:wfdid="w144" OnTextChanged="txtApprFrom_TextChanged"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 35px" vAlign=top><asp:Label id="Label23" runat="server" Text="अवधि सम्म" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 35px" vAlign=top><asp:TextBox id="txtApprTo" runat="server" Width="102px" SkinID="Unicodetxt" AutoPostBack="True" __designer:wfdid="w146" OnTextChanged="txtApprTo_TextChanged"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 23px" vAlign=top><asp:Label id="Label24" runat="server" Text="जम्मा दिनहरु" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 23px" vAlign=top><asp:TextBox id="txtApprDays" runat="server" Width="40px" SkinID="Unicodetxt" __designer:wfdid="w148"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 23px" vAlign=top><asp:Label id="Label8" runat="server" Width="145px" Text="प्रमाणित भएको/नभएको" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 23px" vAlign=top><asp:CheckBox id="chkbxAppr" runat="server" Width="32px" Height="1px" SkinID="smallChk" AutoPostBack="True" __designer:wfdid="w150" OnCheckedChanged="chkbxAppr_CheckedChanged"></asp:CheckBox></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 124px" vAlign=top><asp:Label id="Label26" runat="server" Text="कैफिएत" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 124px" vAlign=top><asp:TextBox id="txtApprReason" runat="server" Width="342px" Height="105px" SkinID="Unicodetxt" __designer:wfdid="w152" TextMode="MultiLine"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 124px" vAlign=baseline><asp:Button id="btnApprAdd" onclick="btnApprAdd_Click" runat="server" Text="‌‌+" SkinID="Add" __designer:wfdid="w153"></asp:Button></TD><TD style="WIDTH: 100px; HEIGHT: 124px" vAlign=top></TD></TR></TBODY></TABLE><asp:UpdatePanel id="UpdatePanel1" runat="server" __designer:wfdid="w54"><ContentTemplate>
<asp:Panel id="Panel3" runat="server" Width="890px" Height="150px" ScrollBars="Auto" __designer:wfdid="w55"><asp:GridView id="grdRecLeaveApplications" runat="server" Width="1387px" SkinID="Unicodegrd" OnSelectedIndexChanged="grdRecLeaveApplications_SelectedIndexChanged" ForeColor="#333333" CellPadding="0" AutoGenerateColumns="False" __designer:wfdid="w56" OnRowDataBound="grdRecLeaveApplications_RowDataBound" GridLines="None">
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
<asp:BoundField DataField="AppByName" HeaderText="स्विकृत गर्ने अधिकृत"></asp:BoundField>
<asp:BoundField DataField="AppDate" HeaderText="स्विकृत मिति"></asp:BoundField>
<asp:BoundField DataField="AppFrom" HeaderText="देखि"></asp:BoundField>
<asp:BoundField DataField="AppTo" HeaderText="सम्म"></asp:BoundField>
<asp:BoundField DataField="AppDays" HeaderText="जम्मा दिन"></asp:BoundField>
<asp:BoundField DataField="AppReason" HeaderText="कैफिएत"></asp:BoundField>
<asp:TemplateField><EditItemTemplate>
        <asp:LinkButton runat="server" CommandName="Select" id="lnkselect">Select</asp:LinkButton>
        
</EditItemTemplate>
<ItemTemplate>
        <asp:LinkButton id="lnkselect" runat="server" CommandName="Select">Select</asp:LinkButton> 
        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Delete" ShowHeader="False"><EditItemTemplate>
            <asp:LinkButton ID="lnkDelete" CommandName="Delete" runat="server" Text="Delete" />
        
</EditItemTemplate>
<ItemTemplate>
            <asp:LinkButton ID="lnkDelete" CommandName="Delete" runat="server" Text="Delete" />
        
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
</ContentTemplate>
</asp:UpdatePanel><BR /><asp:Panel id="Panel2" runat="server" Width="125px" Height="50px" __designer:wfdid="w171"><BR /><ajaxToolkit:MaskedEditExtender id="MaskedEditExtender2" runat="server" __designer:dtid="4222124650659967" TargetControlID="txtApprDate" __designer:wfdid="w175" AutoComplete="False" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="9999/99/99" MaskType="Date" Enabled="True">
        </ajaxToolkit:MaskedEditExtender> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender3" runat="server" __designer:dtid="4222124650659968" TargetControlID="txtApprFrom" __designer:wfdid="w176" AutoComplete="False" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="9999/99/99" MaskType="Date" Enabled="True">
        </ajaxToolkit:MaskedEditExtender> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender4" runat="server" __designer:dtid="4222124650659969" TargetControlID="txtApprTo" __designer:wfdid="w177" AutoComplete="False" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="9999/99/99" MaskType="Date" Enabled="True">
        </ajaxToolkit:MaskedEditExtender> </asp:Panel> 
</contenttemplate>
 </asp:UpdatePanel>

<table>
        <tr>
            <td style="width: 100px">
                <asp:Button ID="btnAppSubmit" runat="server" OnClick="btnAppSubmit_Click1" SkinID="Normal"
                    Text="Submit" /></td>
            <td style="width: 100px">
                <asp:Button ID="btnAppCancel" runat="server" OnClick="btnAppCancel_Click" SkinID="Cancel"
                    Text="Cancel" /></td>
        </tr>
    </table>
        &nbsp; &nbsp;&nbsp;<br />
        &nbsp; &nbsp;
        <br />
    </div>

</asp:Content>

