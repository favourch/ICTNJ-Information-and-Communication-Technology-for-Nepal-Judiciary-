<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WitnessInfo.aspx.cs" Inherits="MODULES_CMS_Forms_WitnessInfo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<script runat="server">

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
        
        
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CMS | Personnel Info</title>

</head>
<body onunload="PassValues()" >
    <script language="javascript" type="text/javascript">

function PassValues()
{
    window.opener.document.forms(0).submit();
    self.close();
}
</script>
<form id="form1"  runat="server">

    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground"
        BehaviorID="programmaticModalPopupBehavior" DropShadow="True" PopupControlID="programmaticPopup"
        PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
        TargetControlID="hiddenTargetControlForModalPopup">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none;
        width: 350px; padding: 10px">
        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD;
            border: solid 1px Gray; color: Black; text-align: center;">
            Status
        </asp:Panel>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
        <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
            </ContentTemplate></asp:UpdatePanel>
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
            Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    
    
    
        <table cellspacing="5" style="width: 1000px">
            <tr>
                <td colspan="6" valign="top">
                    <asp:Label ID="lblPersonnelInfo" runat="server" Font-Bold="True" SkinID="UnicodeHeadlbl"
                        Text="वैयक्तिक विवरण"></asp:Label></td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:Label ID="Label1" runat="server" Height="22px" SkinID="Unicodelbl" Text="पहिलो नाम"
                        Width="81px"></asp:Label></td>
                <td valign="top">
                    <asp:TextBox ID="txtFName_Rqd" runat="server" MaxLength="35" SkinID="Unicodetxt"
                        ToolTip="पहिलो नाम" Width="130px"></asp:TextBox>
                    <asp:TextBox ID="txtPersonID" runat="server" Visible="False"></asp:TextBox></td>
                <td valign="top">
                    <asp:Label ID="Label2" runat="server" Height="22px" SkinID="Unicodelbl" Text="बिचको नाम"></asp:Label></td>
                <td valign="top">
                    <asp:TextBox ID="txtMName" runat="server" MaxLength="15" SkinID="Unicodetxt" Width="130px"></asp:TextBox></td>
                <td valign="top">
                    <asp:Label ID="Label3" runat="server" Height="22px" SkinID="Unicodelbl" Text="थर"
                        Width="110px"></asp:Label></td>
                <td valign="top">
                    <asp:TextBox ID="txtSurName_Rqd" runat="server" MaxLength="35" SkinID="Unicodetxt"
                        ToolTip="थर" Width="130px"></asp:TextBox></td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:Label ID="Label4" runat="server" Height="22px" SkinID="Unicodelbl" Text="जन्म मिति"
                        Width="90px"></asp:Label></td>
                <td valign="top">
                    <asp:TextBox ID="txtDOB_DT" runat="server" MaxLength="10" SkinID="Unicodetxt" ToolTip="जन्म मिति"
                        Width="130px"></asp:TextBox>&nbsp;
                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AutoComplete="False"
                        Mask="9999/99/99" MaskType="Date" TargetControlID="txtDOB_DT">
                    </ajaxToolkit:MaskedEditExtender>
                </td>
                <td valign="top">
                    <asp:Label ID="Label5" runat="server" Height="22px" SkinID="Unicodelbl" Text="लिंग"></asp:Label></td>
                <td valign="top">
                    <asp:DropDownList ID="ddlGender" runat="server" SkinID="Unicodeddl" Width="135px">
                        <asp:ListItem Value="SG">छान्नुहोस</asp:ListItem>
                        <asp:ListItem Value="M">पुरुष</asp:ListItem>
                        <asp:ListItem Value="F">महिला</asp:ListItem>
                        <asp:ListItem Value="O">अन्य</asp:ListItem>
                    </asp:DropDownList></td>
                <td valign="top">
                    <asp:Label ID="Label6" runat="server" Height="22px" SkinID="Unicodelbl" Text="बैबाहिक सम्बन्ध"
                        Width="115px"></asp:Label></td>
                <td valign="top">
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
                <td valign="top">
                    <asp:Label ID="Label7" runat="server" Height="22px" SkinID="Unicodelbl" Text="देश"></asp:Label></td>
                <td valign="top">
                    <asp:DropDownList ID="ddlCountry" runat="server" SkinID="Unicodeddl" Width="135px">
                    </asp:DropDownList></td>
                <td valign="top">
                    <asp:Label ID="Label8" runat="server" Height="22px" SkinID="Unicodelbl" Text="घर भएको जिल्ला"
                        Width="125px"></asp:Label></td>
                <td valign="top">
                    <asp:DropDownList ID="ddlBirthDistrict" runat="server" SkinID="Unicodeddl" Width="135px">
                    </asp:DropDownList></td>
                <td valign="top">
                    <asp:Label ID="Label9" runat="server" Height="22px" SkinID="Unicodelbl" Text="धर्म"
                        Width="110px"></asp:Label></td>
                <td valign="top">
                    <asp:DropDownList ID="ddlReligion" runat="server" SkinID="Unicodeddl" Width="135px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:Label ID="Label29" runat="server" SkinID="Unicodelbl" Text="हुलिया" Width="77px"></asp:Label></td>
                <td valign="top">
                    <asp:TextBox ID="txtIdentityMark" runat="server" MaxLength="30" SkinID="Unicodetxt"
                        Width="130px"></asp:TextBox></td>
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
                    <hr />
                    <table style="width: 950px">
                        <tr>
                            <td style="width: 950px">
                                <ajaxToolkit:TabContainer ID="tabContainerEmpContact" runat="server" ActiveTabIndex="0"
                                    CssClass="ajax_tab_theme" Width="950px">
                                    <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                                        <ContentTemplate>
                                            <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                                <ContentTemplate>
                                                    <table style="width: 650px">
                                                        <tr>
                                                            <td colspan="6" valign="top">
                                                                <asp:Label ID="Label26" runat="server" Font-Bold="True" SkinID="Unicodelbl" Text="स्थायी ठेगाना"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 60px" valign="top">
                                                                <asp:Label ID="Label82" runat="server" Height="19px" SkinID="Unicodelbl" Text="जिल्ला"
                                                                    Width="50px"></asp:Label>
                                                            </td>
                                                            <td style="width: 170px" valign="top">
                                                                <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"
                                                                    SkinID="Unicodeddl" Width="150px">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="width: 105px" valign="top">
                                                                <asp:Label ID="Label84" runat="server" Height="19px" SkinID="Unicodelbl" Text="गा.बि.स./न.पा."
                                                                    Width="95px"></asp:Label>
                                                            </td>
                                                            <td style="width: 170px" valign="top">
                                                                <asp:DropDownList ID="ddlVDC" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlVDC_SelectedIndexChanged"
                                                                    SkinID="Unicodeddl" Width="150px">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="width: 60px" valign="top">
                                                                <asp:Label ID="Label15" runat="server" Height="19px" SkinID="Unicodelbl" Text="वडा नं."
                                                                    Width="50px"></asp:Label>
                                                            </td>
                                                            <td valign="top">
                                                                <asp:DropDownList ID="ddlWard" runat="server" AppendDataBoundItems="True" SkinID="Unicodeddl"
                                                                    Width="70px" OnSelectedIndexChanged="ddlWard_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 60px" valign="top">
                                                                <asp:Label ID="Label83" runat="server" Height="19px" SkinID="Unicodelbl" Text="टोल"></asp:Label>
                                                            </td>
                                                            <td style="width: 170px" valign="top">
                                                                <asp:TextBox ID="txtTole" runat="server" MaxLength="100" SkinID="Unicodetxt" TextMode="MultiLine"
                                                                    Width="150px"></asp:TextBox></td>
                                                            <td style="width: 105px" valign="top">
                                                                <asp:ImageButton ID="imgDelPerAddress" runat="server" AlternateText="Delete This Address"
                                                                    ImageUrl="~/MODULES/COMMON/Images/bycat1.ico" OnClick="imgDelPerAddress_Click"
                                                                    OnClientClick="return confirm('यो ठेगाना हटाउने हो ?')" Visible="False" /></td>
                                                            <td style="width: 170px" valign="top">
                                                            </td>
                                                            <td style="width: 60px" valign="top">
                                                            </td>
                                                            <td valign="top">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" valign="top">
                                                                <hr />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <asp:HiddenField ID="hdnPerAddress" runat="server" />
                                                    <asp:HiddenField ID="hdnTempAddress" runat="server" />
                                                    <table style="width: 650px">
                                                        <tr>
                                                            <td colspan="6" valign="top" style="height: 21px">
                                                                <asp:Label ID="Label85" runat="server" Font-Bold="True" SkinID="Unicodelbl" Text="अस्थायी ठेगाना"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 60px" valign="top">
                                                                <asp:Label ID="Label86" runat="server" Height="19px" SkinID="Unicodelbl" Text="जिल्ला"
                                                                    Width="50px"></asp:Label></td>
                                                            <td style="width: 170px" valign="top">
                                                                <asp:DropDownList ID="ddlDistrictTemp" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrictTemp_SelectedIndexChanged"
                                                                    SkinID="Unicodeddl" Width="150px">
                                                                </asp:DropDownList></td>
                                                            <td style="width: 105px" valign="top">
                                                                <asp:Label ID="Label87" runat="server" Height="19px" SkinID="Unicodelbl" Text="गा.बि.स./न.पा."
                                                                    Width="95px"></asp:Label></td>
                                                            <td style="width: 170px" valign="top">
                                                                <asp:DropDownList ID="ddlVDCTemp" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlVDCTemp_SelectedIndexChanged"
                                                                    SkinID="Unicodeddl" Width="150px">
                                                                </asp:DropDownList></td>
                                                            <td style="width: 60px" valign="top">
                                                                <asp:Label ID="Label88" runat="server" Height="19px" SkinID="Unicodelbl" Text="वडा नं."
                                                                    Width="50px"></asp:Label></td>
                                                            <td valign="top">
                                                                <asp:DropDownList ID="ddlWardTemp" runat="server" AppendDataBoundItems="True" SkinID="Unicodeddl"
                                                                    Width="70px" OnSelectedIndexChanged="ddlWardTemp_SelectedIndexChanged">
                                                                </asp:DropDownList></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 60px" valign="top">
                                                                <asp:Label ID="Label89" runat="server" Height="19px" SkinID="Unicodelbl" Text="टोल"></asp:Label></td>
                                                            <td style="width: 170px" valign="top">
                                                                <asp:TextBox ID="txtToleTemp" runat="server" MaxLength="100" SkinID="Unicodetxt"
                                                                    TextMode="MultiLine" Width="150px"></asp:TextBox></td>
                                                            <td style="width: 105px" valign="top">
                                                                <asp:ImageButton ID="imgDelTempAddress" runat="server" AlternateText="Delete This Address"
                                                                    ImageUrl="~/MODULES/COMMON/Images/bycat1.ico" OnClick="imgDelTempAddress_Click"
                                                                    OnClientClick="return confirm('यो ठेगाना हटाउने हो ?')" Visible="False" /></td>
                                                            <td style="width: 170px" valign="top">
                                                            </td>
                                                            <td style="width: 60px" valign="top">
                                                            </td>
                                                            <td valign="top">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" valign="top">
                                                                <hr />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                <ContentTemplate>
                                                    <table style="width: 650px">
                                                        <tr>
                                                            <td colspan="4" valign="top">
                                                                <asp:Label ID="Label13" runat="server" Font-Bold="True" Height="19px" SkinID="Unicodelbl"
                                                                    Text="फोन" Width="105px"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 110px" valign="top">
                                                                <asp:Label ID="Label18" runat="server" Height="19px" SkinID="Unicodelbl" Text="फोनको किसिम"
                                                                    Width="105px"></asp:Label>
                                                            </td>
                                                            <td style="width: 150px" valign="top">
                                                                <asp:DropDownList ID="ddlPhoneType_Phone" runat="server" SkinID="Unicodeddl" ToolTip="फोनको किसिम"
                                                                    Width="135px">
                                                                    <asp:ListItem Value="N">छान्नुहोस</asp:ListItem>
                                                                    <asp:ListItem Value="M">मोबाईल</asp:ListItem>
                                                                    <asp:ListItem Value="O">अफिस</asp:ListItem>
                                                                    <asp:ListItem Value="R">घर</asp:ListItem>
                                                                    <asp:ListItem Value="OT">अन्य</asp:ListItem>
                                                                </asp:DropDownList></td>
                                                            <td style="width: 40px" valign="top">
                                                                <asp:Label ID="Label19" runat="server" Height="19px" SkinID="Unicodelbl" Text="फोन न."
                                                                    Width="55px"></asp:Label>
                                                            </td>
                                                            <td valign="top">
                                                                <asp:TextBox ID="txtPhoneNumber_Phone" runat="server" MaxLength="15" SkinID="Unicodetxt"
                                                                    ToolTip="फोन नं" Width="130px"></asp:TextBox>
                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                                    FilterType="Numbers" TargetControlID="txtPhoneNumber_Phone">
                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 110px" valign="top">
                                                            </td>
                                                            <td style="width: 150px" valign="top">
                                                            </td>
                                                            <td style="width: 40px" valign="top">
                                                            </td>
                                                            <td valign="top" align="right">
                                                                <asp:Button ID="btnPhonePlus" runat="server" OnClick="btnPhonePlus_Click" OnClientClick="javascript:return validateUpanelFields('_Phone',0);"
                                                                    SkinID="Add" Text="+" /></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" valign="top">
                                                                <asp:GridView ID="grdPhone" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                    ForeColor="#333333" GridLines="None" OnRowDataBound="grdPhone_RowDataBound" OnRowDeleting="grdPhone_RowDeleting"
                                                                    OnSelectedIndexChanged="grdPhone_SelectedIndexChanged" SkinID="Unicodegrd">
                                                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                    <Columns>
                                                                        <asp:BoundField DataField="PID" HeaderText="PersonID" />
                                                                        <asp:BoundField DataField="PTYPE" HeaderText="Phone Type" />
                                                                        <asp:BoundField DataField="PHONETYPE" HeaderText="फोनको किसिम">
                                                                            <ItemStyle Width="100px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="PSNO" HeaderText="PSNo" />
                                                                        <asp:BoundField DataField="PHONE" HeaderText="फोन नं.">
                                                                            <ItemStyle Width="200px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="ACTIVE" HeaderText="Active" />
                                                                        <asp:BoundField DataField="REMARKS" HeaderText="कैफियत" />
                                                                        <asp:BoundField DataField="ACTION" HeaderText="Action" />
                                                                        <asp:CommandField ShowSelectButton="True">
                                                                            <ItemStyle Font-Names="Verdana" Width="50px" />
                                                                        </asp:CommandField>
                                                                        <asp:CommandField ShowDeleteButton="True">
                                                                            <ItemStyle Font-Names="Verdana" Width="50px" />
                                                                        </asp:CommandField>
                                                                    </Columns>
                                                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                                    <EditRowStyle BackColor="#999999" />
                                                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" valign="top">
                                                                <hr />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <table style="width: 650px">
                                                        <tr>
                                                            <td colspan="4" valign="top">
                                                                <asp:Label ID="LabelEmail" runat="server" Font-Bold="True" Height="19px" SkinID="Unicodelbl"
                                                                    Text="इमेल" Width="105px"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 110px" valign="top">
                                                                <asp:Label ID="Label23" runat="server" Height="19px" SkinID="Unicodelbl" Text="ईमेलको किसिम"
                                                                    Width="105px"></asp:Label></td>
                                                            <td style="width: 150px" valign="top">
                                                                <asp:DropDownList ID="ddlEMailType_EMail" runat="server" SkinID="Unicodeddl" ToolTip="इमेलको किसिम"
                                                                    Width="135px">
                                                                    <asp:ListItem Value="N">छान्नुहोस</asp:ListItem>
                                                                    <asp:ListItem Value="P">ब्यक्तिगत</asp:ListItem>
                                                                    <asp:ListItem Value="O">अफिस</asp:ListItem>
                                                                    <asp:ListItem Value="OT">अन्य</asp:ListItem>
                                                                </asp:DropDownList></td>
                                                            <td style="width: 100px" valign="top">
                                                                <asp:Label ID="Label24" runat="server" Height="19px" SkinID="Unicodelbl" Text="ईमेल ठेगाना"
                                                                    Width="90px"></asp:Label></td>
                                                            <td valign="top">
                                                                <asp:TextBox ID="txtEMail_EMail" runat="server" MaxLength="50" SkinID="Unicodetxt"
                                                                    ToolTip="इमेल ठेगाना" Width="130px"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 110px" valign="top">
                                                            </td>
                                                            <td style="width: 150px" valign="top">
                                                            </td>
                                                            <td style="width: 100px" valign="top">
                                                            </td>
                                                            <td valign="top" align="right">
                                                                <asp:Button ID="btnEMailPlus" runat="server" OnClick="btnEMailPlus_Click" OnClientClick="javascript:return ValidateEmailFR();"
                                                                    SkinID="Add" Text="+" /></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" valign="top">
                                                                <asp:GridView ID="grdEMail" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                    ForeColor="#333333" GridLines="None" OnRowDataBound="grdEMail_RowDataBound" OnRowDeleting="grdEMail_RowDeleting"
                                                                    OnSelectedIndexChanged="grdEMail_SelectedIndexChanged" SkinID="Unicodegrd">
                                                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                    <Columns>
                                                                        <asp:BoundField DataField="PID" HeaderText="PersonID" />
                                                                        <asp:BoundField DataField="ETYPE" HeaderText="EMail Type" />
                                                                        <asp:BoundField DataField="EMAILTYPE" HeaderText="ईमेलको किसिम">
                                                                            <ItemStyle Width="100px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="ESNO" HeaderText="ESNo" />
                                                                        <asp:BoundField DataField="EMAIL" HeaderText="ईमेल ठेगाना">
                                                                            <ItemStyle Font-Names="Verdana" Width="200px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="ACTIVE" HeaderText="Active" />
                                                                        <asp:BoundField DataField="REMARKS" HeaderText="कैफियत" />
                                                                        <asp:BoundField DataField="ACTION" HeaderText="Action" />
                                                                        <asp:CommandField ShowSelectButton="True">
                                                                            <ItemStyle Font-Names="Verdana" Width="50px" />
                                                                        </asp:CommandField>
                                                                        <asp:CommandField ShowDeleteButton="True">
                                                                            <ItemStyle Font-Names="Verdana" Width="50px" />
                                                                        </asp:CommandField>
                                                                    </Columns>
                                                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                                    <EditRowStyle BackColor="#999999" />
                                                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <br />
                                        </ContentTemplate>
                                        <HeaderTemplate>
                                            सम्पर्क
                                        </HeaderTemplate>
                                    </ajaxToolkit:TabPanel>
                                    <ajaxToolkit:TabPanel ID="TabPanel10" runat="server" HeaderText="TabPanel10">
                                        <ContentTemplate>
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                                    <table style="width: 700px">
                                                        <tr>
                                                            <td align="left" style="width: 125px; height: 26px" valign="top">
                                                                <asp:Label ID="Label79" runat="server" SkinID="Unicodelbl" Text="पहिलो नाम"></asp:Label></td>
                                                            <td align="left" style="width: 120px; height: 26px" valign="top">
                                                                <asp:TextBox ID="txtRelationFirstName_Relative" runat="server" SkinID="Unicodetxt"
                                                                    ToolTip="पहिलो नाम" Width="100px"></asp:TextBox></td>
                                                            <td align="left" style="width: 85px; height: 26px" valign="top">
                                                                <asp:Label ID="Label80" runat="server" SkinID="Unicodelbl" Text="बिचको नाम" Width="80px"></asp:Label></td>
                                                            <td align="left" style="width: 120px; height: 26px" valign="top">
                                                                <asp:TextBox ID="txtRelationMName" runat="server" SkinID="Unicodetxt" Width="100px"></asp:TextBox></td>
                                                            <td align="left" style="width: 116px; height: 26px" valign="top">
                                                                <asp:Label ID="Label81" runat="server" SkinID="Unicodelbl" Text="थर"></asp:Label></td>
                                                            <td align="left" style="height: 26px" valign="top">
                                                                <asp:TextBox ID="txtRelationLastName_Relative" runat="server" SkinID="Unicodetxt"
                                                                    ToolTip="थर" Width="100px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 125px" valign="top">
                                                                <asp:Label ID="Label90" runat="server" SkinID="Unicodelbl" Text="लिंग"></asp:Label></td>
                                                            <td align="left" style="width: 120px" valign="top">
                                                                <asp:DropDownList ID="ddlRelationGender" runat="server" SkinID="Unicodeddl" Width="105px">
                                                                    <asp:ListItem Value="SG">छान्नुहोस</asp:ListItem>
                                                                    <asp:ListItem Value="M">पुरुष</asp:ListItem>
                                                                    <asp:ListItem Value="F">महिला</asp:ListItem>
                                                                    <asp:ListItem Value="O">अन्य</asp:ListItem>
                                                                </asp:DropDownList></td>
                                                            <td align="left" style="width: 85px" valign="top">
                                                                <asp:Label ID="Label91" runat="server" SkinID="Unicodelbl" Text="जन्म मिति" Width="75px"></asp:Label></td>
                                                            <td align="left" style="width: 120px" valign="top">
                                                                <asp:TextBox ID="txtRelationDOB_DTRelative" runat="server" SkinID="Unicodetxt" ToolTip="जन्म मिति"
                                                                    Width="100px"></asp:TextBox>
                                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender11" runat="server" AutoComplete="False"
                                                                    Mask="9999/99/99" MaskType="Date" TargetControlID="txtRelationDOB_DTRelative">
                                                                </ajaxToolkit:MaskedEditExtender>
                                                            </td>
                                                            <td align="left" style="width: 116px" valign="top">
                                                                <asp:Label ID="Label92" runat="server" SkinID="Unicodelbl" Text="बैबाहिक सम्बन्ध"
                                                                    Width="110px"></asp:Label></td>
                                                            <td align="left" valign="top">
                                                                <asp:DropDownList ID="ddlRelationMarStatus" runat="server" SkinID="Unicodeddl" Width="105px">
                                                                    <asp:ListItem Value="SMS">छान्नुहोस</asp:ListItem>
                                                                    <asp:ListItem Value="S">अबिबाहित</asp:ListItem>
                                                                    <asp:ListItem Value="M">बिबाहित</asp:ListItem>
                                                                    <asp:ListItem Value="W">बिधवा/बिदुर</asp:ListItem>
                                                                    <asp:ListItem Value="D">छोडपत्र</asp:ListItem>
                                                                    <asp:ListItem Value="O">अन्य</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:HiddenField ID="hdnRelativeID" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 125px" valign="top">
                                                                <asp:Label ID="Label93" runat="server" SkinID="Unicodelbl" Text="घर भएको जिल्ला"
                                                                    Width="120px"></asp:Label></td>
                                                            <td align="left" style="width: 120px" valign="top">
                                                                <asp:DropDownList ID="ddlRelationHomeDistrict" runat="server" SkinID="Unicodeddl"
                                                                    Width="105px">
                                                                </asp:DropDownList></td>
                                                            <td align="left" style="width: 85px" valign="top">
                                                                <asp:Label ID="Label94" runat="server" SkinID="Unicodelbl" Text="सम्बन्ध" Width="52px"></asp:Label></td>
                                                            <td align="left" style="width: 120px" valign="top">
                                                                <asp:DropDownList ID="ddlRelationType_Relative" runat="server" SkinID="Unicodeddl"
                                                                    ToolTip="सम्बन्ध" Width="105px">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left" style="width: 116px" valign="top">
                                                                <asp:Label ID="Label95" runat="server" SkinID="Unicodelbl" Text="पेशा"></asp:Label></td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtRelativeOcc" runat="server" SkinID="Unicodetxt"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" colspan="6" valign="top">
                                                                <asp:Button ID="btnSearchRelatives" runat="server" OnClick="btnSearchRelatives_Click"
                                                                    SkinID="Normal" Text="Relatives" />
                                                                <asp:Button ID="btnAddRelatives" runat="server" OnClick="btnAddRelatives_Click" OnClientClick="javascript:return validateUpanelFields('_Relative','Relative');"
                                                                    SkinID="Add" Text="+" />
                                                                <asp:Button ID="btnClearRelatives" runat="server" OnClick="btnClearRelatives_Click"
                                                                    SkinID="Cancel" Text="Clear" /></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" colspan="6" style="height: 19px" valign="top">
                                                                <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Auto" Width="100%">
                                                                    <asp:GridView ID="grdEmpRelatives" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                        ForeColor="#333333" GridLines="None" OnRowDataBound="grdEmpRelatives_RowDataBound"
                                                                        SkinID="Unicodegrd" Width="850px">
                                                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                        <Columns>
                                                                            <asp:BoundField DataField="PID" HeaderText="आईडि" />
                                                                            <asp:BoundField DataField="RELATIVEID" HeaderText="ना.आईडी" />
                                                                            <asp:BoundField DataField="FIRSTNAME" HeaderText="पहिलो नाम" />
                                                                            <asp:BoundField DataField="MIDNAME" HeaderText="बिचको नाम" />
                                                                            <asp:BoundField DataField="SURNAME" HeaderText="थर" />
                                                                            <asp:BoundField DataField="RDFULLNAME" HeaderText="पुरा नाम थर" />
                                                                            <asp:BoundField DataField="GENDER" HeaderText="लि.आईडि" />
                                                                            <asp:BoundField DataField="RDGENDER" HeaderText="लिंग" />
                                                                            <asp:BoundField DataField="DOB" HeaderText="जन्म मिति" />
                                                                            <asp:BoundField DataField="MARITALSTATUS" HeaderText="बैबाहिक" />
                                                                            <asp:BoundField DataField="RDMARITALSTATUS" HeaderText="बैबाहिक सम्बन्ध" />
                                                                            <asp:BoundField DataField="BIRTHDISTRICT" HeaderText="घर" />
                                                                            <asp:BoundField DataField="NEPDISTNAME" HeaderText="घर जिल्ला" />
                                                                            <asp:BoundField DataField="RELATIONTYPEID" HeaderText="सम्बन्ध" />
                                                                            <asp:BoundField DataField="RELATIONTYPENAME" HeaderText="सम्बन्ध" />
                                                                            <asp:BoundField DataField="OCCUPATION" HeaderText="पेशा" />
                                                                            <asp:TemplateField HeaderText="ईच्छाइएको">
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="chkIsBeneficiary" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "ISBENEFICIARY").ToString() == "True" %>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="सक्रिय">
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="chkRelativeActive" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "ISACTIVE").ToString() == "True" %>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="ACTION" HeaderText="Action" />
                                                                            <asp:CommandField ShowSelectButton="True" />
                                                                            <asp:CommandField ShowDeleteButton="True" />
                                                                            <asp:TemplateField>
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="chkWasBeneficiary" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "ISBENEFICIARY").ToString() == "True" %>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField>
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="chkWasRelative" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "ISACTIVE").ToString() == "True" %>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
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
                                                        <tr>
                                                            <td align="left" colspan="6" valign="top">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </ContentTemplate>
                                        <HeaderTemplate>
                                            नातेदार
                                        </HeaderTemplate>
                                    </ajaxToolkit:TabPanel>
                                </ajaxToolkit:TabContainer>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="6" valign="top">
                    <table>
                        <tr>
                            <td style="width: 100px">
                                <asp:Label ID="Label10" runat="server" SkinID="Unicodelbl" Text="From Date" Width="72px"></asp:Label></td>
                            <td style="width: 123px">
                                <asp:TextBox ID="txtFromDate_RQD" runat="server" SkinID="Unicodetxt" Width="200px"></asp:TextBox>
                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" AutoComplete="False"
                                    Mask="99/99/9999" TargetControlID="txtFromDate_RQD" UserDateFormat="DayMonthYear" MaskType="Date">
                                </ajaxToolkit:MaskedEditExtender>
                            </td>
                            <td align="right" style="width: 748px">
                    <asp:Button ID="btnAddPerson" runat="server" OnClick="btnAddPerson_Click" SkinID="Add"
                        Text="+" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="6" valign="top" style="height: 210px">
                    <asp:UpdatePanel ID="upnlPerson" runat="server">
                        <ContentTemplate>
                    <asp:GridView ID="grdPerson" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        ForeColor="#333333" GridLines="None" Width="500px">
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <RowStyle BackColor="#EFF3FB" />
                        <EditRowStyle BackColor="#2461BF" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField HeaderText="Witness Name" DataField="WitnessName" />
                            <asp:BoundField DataField="FromDate" HeaderText="From Date" >
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnAddPerson" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="6" valign="top" style="height: 42px">
                    <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" OnClientClick="javascript:return validate(1);"
                        SkinID="Normal" Text="Submit" />
                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" SkinID="Cancel"
                        Text="Cancel" />&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
