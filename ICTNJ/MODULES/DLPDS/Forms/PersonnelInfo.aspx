<%@ Page Language="C#" MasterPageFile="~/MODULES/DLPDS/DLPDSMasterPage.master" AutoEventWireup="true" CodeFile="PersonnelInfo.aspx.cs" Inherits="MODULES_DLPDS_Forms_PersonnelInfo" Title="DLPDS | Personnel Information" %>
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
    <script language="javascript" type="text/javascript" src="../../COMMON/JS/EmailValidator.js"></script>
    <script language="javascript" type="text/javascript" src ="../../COMMON/JS/Validation.js"></script>
        
    
<script language="javascript" type="text/javascript">
    function ValidateEmailFR()
    {
        return ValidateEmail('<%=this.txtEMail.ClientID %>');
    }
</script>
                <asp:ScriptManager id="ScriptManager1" runat="server">
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
            &nbsp;
            <asp:UpdatePanel id="UpdatePanel3" runat="server">
                <contenttemplate>
<asp:Label id="lblStatusMessage" runat="server" Text="Label" Height="19px"></asp:Label> 
</contenttemplate>
            </asp:UpdatePanel>
            <br />
<asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click" Width="58px" />           <br />
        </asp:Panel>
        
    <table cellspacing="5" style="width: 861px">
        <tr>
            <td colspan="6" valign="top">
                <asp:Label ID="lblHeader" runat="server" Font-Bold="True" ForeColor="#C00000" SkinID="jpt"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="6" valign="top">
                &nbsp;<asp:Label ID="Label26" runat="server" Font-Bold="True" Text="Personnel Information"></asp:Label></td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="Label1" runat="server" Text="पहिलो नाम" Height="19px"></asp:Label></td>
            <td valign="top">
                <asp:TextBox ID="txtFName_Rqd" runat="server" MaxLength="35" ToolTip="First Name"></asp:TextBox></td>
            <td valign="top">
                <asp:Label ID="Label2" runat="server" Text="बिचको नाम" Height="19px"></asp:Label></td>
            <td valign="top">
                <asp:TextBox ID="txtMName" runat="server" MaxLength="15"></asp:TextBox></td>
            <td valign="top">
                <asp:Label ID="Label3" runat="server" Text="थर" Height="19px"></asp:Label></td>
            <td valign="top">
                <asp:TextBox ID="txtSurName_Rqd" runat="server" MaxLength="35" ToolTip="Surname"></asp:TextBox></td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="Label4" runat="server" Text="जन्म मिति" Height="19px"></asp:Label></td>
            <td valign="top">
                <asp:TextBox ID="txtDOB" runat="server" MaxLength="10"></asp:TextBox></td>
            <td valign="top">
                <asp:Label ID="Label5" runat="server" Text="लिङ्ग" Height="19px"></asp:Label></td>
            <td valign="top">
                <asp:DropDownList ID="ddlGender" runat="server" Width="156px" Font-Size="11pt">
                    <asp:ListItem Value="SG">छान्नुहोस</asp:ListItem>
                    <asp:ListItem Value="M">पुरुष</asp:ListItem>
                    <asp:ListItem Value="F">महिला</asp:ListItem>
                    <asp:ListItem Value="O">अन्य</asp:ListItem>
                </asp:DropDownList></td>
            <td valign="top">
                <asp:Label ID="Label6" runat="server" Text="वबाहिक सम्बन्ध" Height="19px"></asp:Label></td>
            <td valign="top">
                <asp:DropDownList ID="ddlMarStatus" runat="server" Width="156px" Font-Size="11pt">
                    <asp:ListItem Value="SMS">छान्नुहोस</asp:ListItem>
                    <asp:ListItem Value="S">अविवाहित</asp:ListItem>
                    <asp:ListItem Value="M">विवाहित</asp:ListItem>
                    <asp:ListItem Value="W">विधवा/विदुर</asp:ListItem>
                    <asp:ListItem Value="D">छोडपत्र</asp:ListItem>
                    <asp:ListItem Value="O">अन्य</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="Label7" runat="server" Text="देश" Height="19px"></asp:Label></td>
            <td valign="top">
                <asp:DropDownList ID="ddlCountry" runat="server" Width="156px">
                </asp:DropDownList></td>
            <td valign="top">
                <asp:Label ID="Label8" runat="server" Text="जन्म जिल्ला" Height="19px"></asp:Label></td>
            <td valign="top">
                <asp:DropDownList ID="ddlBirthDistrict" runat="server" Width="156px" Font-Names="PCS NEPALI" SkinID="PCSddl">
                </asp:DropDownList></td>
            <td valign="top">
                </td>
            <td valign="top">
                <asp:TextBox ID="txtProgramID" runat="server" Visible="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="Label10" runat="server" Text="पिताको नाम" Height="19px"></asp:Label></td>
            <td valign="top">
                <asp:TextBox ID="txtFatherName" runat="server" MaxLength="50"></asp:TextBox></td>
            <td valign="top">
                <asp:Label ID="Label11" runat="server" Text="हजुरबुवाको नाम" Width="108px" Height="19px"></asp:Label></td>
            <td valign="top">
                <asp:TextBox ID="txtGFatherName" runat="server" MaxLength="50"></asp:TextBox></td>
            <td valign="top">
            </td>
            <td valign="top">
            </td>
        </tr>
        <tr>
            <td colspan="6" valign="top">
                <hr />
                <asp:Label ID="Label12" runat="server" Font-Bold="True" Text="ठेगाना"></asp:Label></td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="Label13" runat="server" Text="जिल्ला" Height="19px"></asp:Label></td>
            <td valign="top">
                <asp:UpdatePanel id="UpdatePanel6" runat="server">
                    <contenttemplate>
<asp:DropDownList id="ddlDistrict" runat="server" SkinID="PCSddl" Font-Names="PCS NEPAL" Width="156px" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> 
</contenttemplate>
                </asp:UpdatePanel>

            </td>
            <td valign="top">
                <asp:Label ID="Label14" runat="server" Text="गा.बि.स./न.पा." Height="19px"></asp:Label></td>
            <td valign="top">
                <asp:UpdatePanel id="UpdatePanel1" runat="server">
                    <contenttemplate>
<asp:DropDownList id="ddlVDC" runat="server" Width="156px" SkinID="PCSddl" Font-Names="PCS NEPAL" OnSelectedIndexChanged="ddlVDC_SelectedIndexChanged" AutoPostBack="True" __designer:wfdid="w23"></asp:DropDownList> 
</contenttemplate>
                    <triggers>
<asp:AsyncPostBackTrigger ControlID="ddlDistrict" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
                </asp:UpdatePanel>
            </td>
            <td valign="top">
                <asp:Label ID="Label15" runat="server" Text="वडा न." Height="19px"></asp:Label></td>
            <td valign="top">
                <asp:UpdatePanel id="UpdatePanel2" runat="server">
                    <contenttemplate>
<asp:DropDownList id="ddlWard" runat="server" Font-Names="PCS NEPAL" Width="156px" OnSelectedIndexChanged="ddlWard_SelectedIndexChanged" AppendDataBoundItems="True"></asp:DropDownList> 
</contenttemplate>
                    <triggers>
<asp:AsyncPostBackTrigger ControlID="ddlVDC" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="Label16" runat="server" Text="टोल" Height="19px"></asp:Label></td>
            <td valign="top" colspan="3">
                <asp:UpdatePanel id="UpdatePanel8" runat="server">
                    <contenttemplate>
                <asp:TextBox ID="txtTole" runat="server" TextMode="MultiLine" Width="477px"></asp:TextBox>
</contenttemplate>
                </asp:UpdatePanel></td>
                <td valign="top">
                    <asp:Label ID="Label17" runat="server" Text="ठेगानाको किसिम" Height="19px"></asp:Label></td>
                <td valign="top">
                    <asp:UpdatePanel id="UpdatePanel7" runat="server">
                        <contenttemplate>
<asp:DropDownList id="ddlAddressType" runat="server" Font-Size="11pt" Width="157px"><asp:ListItem Value="O">छान्नुहोस</asp:ListItem>
<asp:ListItem Value="P">स्थायी</asp:ListItem>
<asp:ListItem Value="T">अस्थायी</asp:ListItem>
</asp:DropDownList> 
</contenttemplate>
                    </asp:UpdatePanel>
                <asp:Button ID="btnAddressPlus" runat="server" Text="+" Width="25px" OnClick="btnAddressPlus_Click" /></td>
        </tr>
        <tr>
            <td colspan="6" valign="top">
                <asp:UpdatePanel id="uPanelAddress" runat="server">
                    <contenttemplate>
<asp:GridView id="grdAddress" runat="server" SkinID="PCSGridView" ForeColor="#333333" Height="9px" Width="574px" OnSelectedIndexChanged="grdAddress_SelectedIndexChanged" OnRowDataBound="grdAddress_RowDataBound" AutoGenerateColumns="False" CellPadding="4" GridLines="None">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="PERSONID" HeaderText="Person ID"></asp:BoundField>
<asp:BoundField DataField="ADTYPEID" HeaderText="Address Type ID"></asp:BoundField>
<asp:BoundField DataField="ADDRESSTYPE" HeaderText="ठेगानाको किसिम"></asp:BoundField>
<asp:BoundField DataField="DISTRICT" HeaderText="जिल्ला"></asp:BoundField>
<asp:BoundField DataField="VDCMUNICIPALITY" HeaderText="गा.वि.स. / न.पा."></asp:BoundField>
<asp:BoundField DataField="WARD" HeaderText="वडा न."></asp:BoundField>
<asp:BoundField DataField="TOLE" HeaderText="टोल"></asp:BoundField>
<asp:BoundField DataField="DISTCODE" HeaderText="District Code"></asp:BoundField>
<asp:BoundField DataField="VDCCODE" HeaderText="VDC Code"></asp:BoundField>
<asp:BoundField DataField="ACTIVE" HeaderText="Active"></asp:BoundField>
<asp:BoundField DataField="ACTION" HeaderText="Action"></asp:BoundField>
<asp:BoundField DataField="ADSNO" HeaderText="AdSNo"></asp:BoundField>
<asp:CommandField SelectText="छान्नुहोस" ShowSelectButton="True"></asp:CommandField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" HorizontalAlign="Left" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> 
</contenttemplate>
                    <triggers>
<asp:AsyncPostBackTrigger ControlID="btnAddressPlus" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
                </asp:UpdatePanel></td>
        </tr>
        <tr>
            <td colspan="6" valign="top">
                <hr />
                <asp:Label ID="Label21" runat="server" Font-Bold="True" Text="Phone"></asp:Label></td>
        </tr>
        
                <tr>
            <td valign="top">
                <asp:Label ID="Label18" runat="server" Text="फोनको किसिम" Height="19px"></asp:Label></td>
            <td valign="top">
                <asp:UpdatePanel id="UpdatePanel9" runat="server">
                    <contenttemplate>
<asp:DropDownList id="ddlPhoneType" runat="server" Font-Size="11pt" Width="157px"><asp:ListItem Value="N">छान्नुहोस</asp:ListItem>
<asp:ListItem Value="M">मोबाइल</asp:ListItem>
<asp:ListItem Value="O">अफिस</asp:ListItem>
<asp:ListItem Value="R">घर</asp:ListItem>
<asp:ListItem Value="OT">अन्य</asp:ListItem>
</asp:DropDownList> 
</contenttemplate>
                </asp:UpdatePanel></td>
            <td valign="top">
                <asp:Label ID="Label19" runat="server" Text="फोन न." Width="108px" Height="19px"></asp:Label></td>
            <td valign="top">
                <asp:UpdatePanel id="UpdatePanel10" runat="server">
                    <contenttemplate>
<asp:TextBox id="txtPhoneNumber" runat="server" MaxLength="15"></asp:TextBox> 
</contenttemplate>
                </asp:UpdatePanel></td>
            <td valign="top">
                <asp:Label ID="Label20" runat="server" Text="कफियत" Width="108px" Height="19px"></asp:Label></td>
            <td valign="top">
                <asp:UpdatePanel id="UpdatePanel11" runat="server">
                    <contenttemplate>
                <asp:TextBox ID="txtPhoneRemarks" runat="server" MaxLength="30"></asp:TextBox>
</contenttemplate>
                </asp:UpdatePanel>
                <asp:Button ID="btnPhonePlus" runat="server" Text="+" Width="25px" OnClick="btnPhonePlus_Click" /></td>
        </tr>
        <tr>
            <td valign="top">
            </td>
            <td valign="top">
            </td>
            <td valign="top">
            </td>
            <td valign="top">
            </td>
            <td valign="top">
            </td>
            <td valign="top">
                </td>
        </tr>
        <tr>
            <td colspan="6" valign="top">
                <asp:UpdatePanel id="UpdatePanel4" runat="server">
                    <contenttemplate>
<asp:GridView id="grdPhone" runat="server" ForeColor="#333333" OnSelectedIndexChanged="grdPhone_SelectedIndexChanged" OnRowDataBound="grdPhone_RowDataBound" AutoGenerateColumns="False" CellPadding="4" GridLines="None">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="PERSONID" HeaderText="PersonID"></asp:BoundField>
<asp:BoundField DataField="PTYPE" HeaderText="Phone Type"></asp:BoundField>
<asp:BoundField DataField="PHONETYPE" HeaderText="फोनको किसिम"></asp:BoundField>
<asp:BoundField DataField="PSNO" HeaderText="PSNo"></asp:BoundField>
<asp:BoundField DataField="PHONE" HeaderText="फोन न."></asp:BoundField>
<asp:BoundField DataField="ACTIVE" HeaderText="Active"></asp:BoundField>
<asp:BoundField DataField="REMARKS" HeaderText="कफियत"></asp:BoundField>
<asp:BoundField DataField="ACTION" HeaderText="Action"></asp:BoundField>
<asp:CommandField ShowSelectButton="True"></asp:CommandField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> 
</contenttemplate>
                    <triggers>
<asp:AsyncPostBackTrigger ControlID="btnPhonePlus" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
                </asp:UpdatePanel></td>
        </tr>
        <tr>
            <td colspan="6" valign="top">
                <hr />
                <asp:Label ID="Label22" runat="server" Font-Bold="True" Text="EMail"></asp:Label></td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="Label23" runat="server" Text="ईमेलको किसिम" Height="19px"></asp:Label></td>
            <td valign="top">
                <asp:UpdatePanel id="UpdatePanel12" runat="server">
                    <contenttemplate>
<asp:DropDownList id="ddlEMailType" runat="server" Font-Size="11pt" Width="157px"><asp:ListItem Value="N">छान्नुहोस</asp:ListItem>
<asp:ListItem Value="P">ब्यक्तिगत</asp:ListItem>
<asp:ListItem Value="O">अफिस</asp:ListItem>
<asp:ListItem Value="OT">अन्य</asp:ListItem>
</asp:DropDownList> 
</contenttemplate>
                </asp:UpdatePanel></td>
            <td valign="top">
                <asp:Label ID="Label24" runat="server" Text="ईमेल ठेगाना" Width="108px" Height="19px"></asp:Label></td>
            <td valign="top">
                <asp:UpdatePanel id="UpdatePanel13" runat="server">
                    <contenttemplate>
<asp:TextBox id="txtEMail" runat="server" MaxLength="50"></asp:TextBox> 
</contenttemplate>
                </asp:UpdatePanel></td>
            <td valign="top">
                <asp:Label ID="Label25" runat="server" Text="कफियत" Width="108px" Height="19px"></asp:Label></td>
            <td valign="top">
                <asp:UpdatePanel id="UpdatePanel14" runat="server">
                    <contenttemplate>
                <asp:TextBox ID="txtEMailRemarks" runat="server" MaxLength="30"></asp:TextBox>
</contenttemplate>
                </asp:UpdatePanel>
                <asp:Button ID="btnEMailPlus" runat="server" Text="+" Width="25px" OnClick="btnEMailPlus_Click" OnClientClick="return ValidateEmailFR();" /></td>
        </tr>
        <tr>
            <td valign="top">
            </td>
            <td valign="top">
            </td>
            <td valign="top">
            </td>
            <td valign="top">
            </td>
            <td valign="top">
            </td>
            <td valign="top">
                </td>
        </tr>
        <tr>
            <td colspan="6" valign="top">
                <asp:UpdatePanel id="UpdatePanel5" runat="server">
                    <contenttemplate>
<asp:GridView id="grdEMail" runat="server" ForeColor="#333333" OnSelectedIndexChanged="grdEMail_SelectedIndexChanged" OnRowDataBound="grdEMail_RowDataBound" AutoGenerateColumns="False" CellPadding="4" GridLines="None">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="PERSONID" HeaderText="PersonID"></asp:BoundField>
<asp:BoundField DataField="ETYPE" HeaderText="EMail Type"></asp:BoundField>
<asp:BoundField DataField="EMAILTYPE" HeaderText="ईमेलको किसिम"></asp:BoundField>
<asp:BoundField DataField="ESNO" HeaderText="ESNo"></asp:BoundField>
<asp:BoundField DataField="EMAIL" HeaderText="ईमेल ठेगाना"></asp:BoundField>
<asp:BoundField DataField="ACTIVE" HeaderText="Active"></asp:BoundField>
<asp:BoundField DataField="REMARK" HeaderText="कफियत"></asp:BoundField>
<asp:BoundField DataField="ACTION" HeaderText="Action"></asp:BoundField>
<asp:CommandField ShowSelectButton="True"></asp:CommandField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> 
</contenttemplate>
                    <triggers>
<asp:AsyncPostBackTrigger ControlID="btnEMailPlus" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
                </asp:UpdatePanel></td>
        </tr>
        <tr>
            <td align="left" colspan="6" valign="top">
                <hr />
            </td>
        </tr>
        <tr>
            <td align="left" colspan="6" valign="top">
                &nbsp;<table style="width: 100%">
                    <tr>
                        <td style="width: 100px; height: 16px">
                            &nbsp;
                            <asp:Label ID="Label9" runat="server" Text="तह"></asp:Label>
                            <asp:DropDownList ID="ddlPost" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPost_SelectedIndexChanged" ToolTip="Post">
                            </asp:DropDownList></td>
                        <td style="width: 100px; height: 16px">
                        </td>
                        <td style="width: 150px; height: 16px">
                            <asp:UpdatePanel id="UpdatePanel16" runat="server">
                                <contenttemplate>
&nbsp;<asp:Label id="Label27" runat="server" Text="समुह"></asp:Label> <asp:DropDownList id="ddlPostLevel" runat="server" ToolTip="Post Level" Width="180px" AppendDataBoundItems="True"></asp:DropDownList> 
</contenttemplate>
                                <triggers>
<asp:AsyncPostBackTrigger ControlID="ddlPost" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
                            </asp:UpdatePanel></td>
                        <td style="width: 100px; height: 16px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="height: 16px">
                            </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="6" valign="top">
                <asp:Button ID="btnOK" runat="server" Text="OK" Width="65px" OnClientClick="javascript:return validate();" OnClick="btnOK_Click"/>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="65px" OnClick="btnCancel_Click" />&nbsp;</td>
        </tr>
    </table>
</asp:Content>

