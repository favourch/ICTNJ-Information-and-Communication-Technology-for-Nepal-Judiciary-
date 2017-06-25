<%@ Page AutoEventWireup="true" CodeFile="PersonnelInfo.aspx.cs" Inherits="MODULES_OAS_Forms_PersonnelInfo" Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master"
    Title="OAS | Person Entry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script language="javascript" src="../../COMMON/JS/Validation.js" type="text/javascript"></script>
    <script language="javascript" src="../../COMMON/JS/DateValidator.js" type="text/javascript"></script>
    <script language="javascript" src="../../COMMON/JS/EnglishDateValidator.js" type="text/javascript"></script>
    <script language="javascript" src="../../COMMON/JS/Number.js" type="text/javascript"></script>
    <script language="javascript" src="../../COMMON/JS/UPanelValidation.js" type="text/javascript"></script>
    <script language="javascript" src="../../COMMON/JS/EmailValidator.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
        function ValidateEmailFR()
        {
            var ErrMsg = "";
            ErrMsg= ValidateEmail('<%=this.txtEMail_EMail.ClientID %>');
            if (ErrMsg != "")
               {
                   alert("सर्वप्रथम निम्न त्रुटिहरू सच्याउनुहोस।\n\n" + ErrMsg);
                    return false;
               }
             else
               return validateUpanelFields('_EMail','');
        }
    </script>

    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
        <ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior"
            DropShadow="True" PopupControlID="programmaticPopup" PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
            TargetControlID="hiddenTargetControlForModalPopup">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none; width: 350px; padding: 10px">
            <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD; border: solid 1px Gray; color: Black; text-align: center;">
                Status
            </asp:Panel>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click" Text="OK" Width="58px" />
            <br />
        </asp:Panel>
        <table cellspacing="2" style="width: 1000px">
            <tr>
                <td colspan="6" valign="top">
                    <asp:Label ID="lblPersonnelInfo" runat="server" Font-Bold="True" SkinID="UnicodeHeadlbl" Text="वैयक्तिक विवरण"></asp:Label></td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:Label ID="Label1" runat="server" Height="22px" SkinID="Unicodelbl" Text="पहिलो नाम" Width="81px"></asp:Label></td>
                <td valign="top">
                    <asp:TextBox ID="txtFName_Rqd" runat="server" MaxLength="35" SkinID="Unicodetxt" ToolTip="पहिलो नाम" Width="130px"></asp:TextBox>
                    <asp:TextBox ID="txtPersonID" runat="server" Visible="False"></asp:TextBox></td>
                <td valign="top">
                    <asp:Label ID="Label2" runat="server" Height="22px" SkinID="Unicodelbl" Text="बिचको नाम"></asp:Label></td>
                <td valign="top">
                    <asp:TextBox ID="txtMName" runat="server" MaxLength="15" SkinID="Unicodetxt" Width="130px"></asp:TextBox></td>
                <td valign="top">
                    <asp:Label ID="Label3" runat="server" Height="22px" SkinID="Unicodelbl" Text="थर" Width="110px"></asp:Label></td>
                <td valign="top">
                    <asp:TextBox ID="txtSurName_Rqd" runat="server" MaxLength="35" SkinID="Unicodetxt" ToolTip="थर" Width="130px"></asp:TextBox></td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:Label ID="Label4" runat="server" Height="22px" SkinID="Unicodelbl" Text="जन्म मिति" Width="90px"></asp:Label></td>
                <td valign="top">
                    <asp:TextBox ID="txtDOB_DT" runat="server" MaxLength="10" SkinID="Unicodetxt" ToolTip="जन्म मिति" Width="130px"></asp:TextBox>&nbsp;
                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AutoComplete="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtDOB_DT">
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
                    <asp:Label ID="Label6" runat="server" Height="22px" SkinID="Unicodelbl" Text="बैबाहिक सम्बन्ध" Width="115px"></asp:Label></td>
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
                <td style="height: 24px" valign="top">
                    <asp:Label ID="Label7" runat="server" Height="22px" SkinID="Unicodelbl" Text="देश"></asp:Label></td>
                <td style="height: 24px" valign="top">
                    <asp:DropDownList ID="ddlCountry" runat="server" SkinID="Unicodeddl" Width="135px">
                    </asp:DropDownList></td>
                <td style="height: 24px" valign="top">
                    <asp:Label ID="Label8" runat="server" Height="22px" SkinID="Unicodelbl" Text="घर भएको जिल्ला" Width="125px"></asp:Label></td>
                <td style="height: 24px" valign="top">
                    <asp:DropDownList ID="ddlBirthDistrict" runat="server" SkinID="Unicodeddl" Width="135px">
                    </asp:DropDownList></td>
                <td style="height: 24px" valign="top">
                    <asp:Label ID="Label9" runat="server" Height="22px" SkinID="Unicodelbl" Text="धर्म" Width="110px"></asp:Label></td>
                <td style="height: 24px" valign="top">
                    <asp:DropDownList ID="ddlReligion" runat="server" SkinID="Unicodeddl" Width="135px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="6" valign="top" align="left">
                    <hr width="100%" />
                    <table style="width: 950px">
                        <tr>
                            <td style="width: 950px">
<%--                                <ajaxToolkit:TabContainer ID="tabContainerEmpContact" runat="server" ActiveTabIndex="0" CssClass="ajax_tab_theme" Width="950px">
                                    <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                                        <ContentTemplate>--%>
                                            <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                                <ContentTemplate>
<TABLE style="WIDTH: 650px"><TBODY><TR><TD vAlign=top colSpan=6><asp:Label id="Label26" runat="server" Text="स्थायी ठेगाना" SkinID="Unicodelbl" Font-Bold="True"></asp:Label> </TD></TR><TR><TD style="WIDTH: 60px" vAlign=top><asp:Label id="Label82" runat="server" Width="50px" Height="19px" Text="जिल्ला" SkinID="Unicodelbl"></asp:Label> </TD><TD style="WIDTH: 170px" vAlign=top><asp:DropDownList id="ddlDistrict" runat="server" Width="154px" SkinID="Unicodeddl" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"></asp:DropDownList> </TD><TD style="WIDTH: 105px" vAlign=top><asp:Label id="Label84" runat="server" Width="95px" Height="19px" Text="गा.बि.स./न.पा." SkinID="Unicodelbl"></asp:Label> </TD><TD style="WIDTH: 170px" vAlign=top><asp:DropDownList id="ddlVDC" runat="server" Width="150px" SkinID="Unicodeddl" AutoPostBack="True" OnSelectedIndexChanged="ddlVDC_SelectedIndexChanged">
                                                                </asp:DropDownList> </TD><TD style="WIDTH: 60px" vAlign=top><asp:Label id="Label15" runat="server" Width="50px" Height="19px" Text="वडा नं." SkinID="Unicodelbl"></asp:Label> </TD><TD vAlign=top><asp:DropDownList id="ddlWard" runat="server" Width="70px" SkinID="Unicodeddl" AppendDataBoundItems="True">
                                                                </asp:DropDownList> </TD></TR><TR><TD style="WIDTH: 60px" vAlign=top><asp:Label id="Label83" runat="server" Height="19px" Text="टोल" SkinID="Unicodelbl"></asp:Label> </TD><TD style="WIDTH: 170px" vAlign=top><asp:TextBox id="txtTole" runat="server" Width="150px" SkinID="Unicodetxt" MaxLength="100" TextMode="MultiLine"></asp:TextBox></TD><TD style="WIDTH: 105px" vAlign=top><asp:ImageButton id="imgDelPerAddress" runat="server" ImageUrl="~/MODULES/COMMON/Images/bycat1.ico" Visible="False" OnClientClick="return confirm('यो ठेगाना हटाउने हो ?')" AlternateText="Delete This Address"></asp:ImageButton></TD><TD style="WIDTH: 170px" vAlign=top></TD><TD style="WIDTH: 60px" vAlign=top></TD><TD vAlign=top></TD></TR><TR><TD vAlign=top colSpan=6>
<HR />
</TD></TR></TBODY></TABLE><asp:HiddenField id="hdnPerAddress" runat="server" Value="0"></asp:HiddenField> <asp:HiddenField id="hdnTempAddress" runat="server" Value="0"></asp:HiddenField> <TABLE style="WIDTH: 650px"><TBODY><TR><TD style="HEIGHT: 21px" vAlign=top colSpan=6><asp:Label id="Label85" runat="server" Text="अस्थायी ठेगाना" SkinID="Unicodelbl" Font-Bold="True"></asp:Label></TD></TR><TR><TD style="WIDTH: 60px" vAlign=top><asp:Label id="Label86" runat="server" Width="50px" Height="19px" Text="जिल्ला" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 170px" vAlign=top><asp:DropDownList id="ddlDistrictTemp" runat="server" Width="154px" SkinID="Unicodeddl" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrictTemp_SelectedIndexChanged"></asp:DropDownList></TD><TD style="WIDTH: 105px" vAlign=top><asp:Label id="Label87" runat="server" Width="95px" Height="19px" Text="गा.बि.स./न.पा." SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 170px" vAlign=top><asp:DropDownList id="ddlVDCTemp" runat="server" Width="150px" SkinID="Unicodeddl" AutoPostBack="True" OnSelectedIndexChanged="ddlVDCTemp_SelectedIndexChanged">
                                                                </asp:DropDownList></TD><TD style="WIDTH: 60px" vAlign=top><asp:Label id="Label88" runat="server" Width="50px" Height="19px" Text="वडा नं." SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:DropDownList id="ddlWardTemp" runat="server" Width="70px" SkinID="Unicodeddl" AppendDataBoundItems="True">
                                                                </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 60px" vAlign=top><asp:Label id="Label89" runat="server" Height="19px" Text="टोल" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 170px" vAlign=top><asp:TextBox id="txtToleTemp" runat="server" Width="150px" SkinID="Unicodetxt" MaxLength="100" TextMode="MultiLine"></asp:TextBox></TD><TD style="WIDTH: 105px" vAlign=top><asp:ImageButton id="imgDelTempAddress" runat="server" ImageUrl="~/MODULES/COMMON/Images/bycat1.ico" Visible="False" OnClientClick="return confirm('यो ठेगाना हटाउने हो ?')" AlternateText="Delete This Address"></asp:ImageButton></TD><TD style="WIDTH: 170px" vAlign=top></TD><TD style="WIDTH: 60px" vAlign=top></TD><TD vAlign=top></TD></TR><TR><TD vAlign=top colSpan=6>
<HR />
</TD></TR></TBODY></TABLE>
</ContentTemplate>
                                            </asp:UpdatePanel>
                                            <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                <ContentTemplate>
                                                    <table style="width: 650px">
                                                        <tr>
                                                            <td colspan="4" valign="top">
                                                                <asp:Label ID="Label13" runat="server" Font-Bold="True" Height="19px" SkinID="Unicodelbl" Text="फोन" Width="105px"></asp:Label></td>
                                                            <td colspan="1" valign="top">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 110px" valign="top">
                                                                <asp:Label ID="Label18" runat="server" Height="19px" SkinID="Unicodelbl" Text="फोनको किसिम" Width="105px"></asp:Label>
                                                            </td>
                                                            <td style="width: 150px" valign="top">
                                                                <asp:DropDownList ID="ddlPhoneType_Phone" runat="server" SkinID="Unicodeddl" ToolTip="फोनको किसिम" Width="135px">
                                                                    <asp:ListItem Value="N">छान्नुहोस</asp:ListItem>
                                                                    <asp:ListItem Value="M">मोबाईल</asp:ListItem>
                                                                    <asp:ListItem Value="O">अफिस</asp:ListItem>
                                                                    <asp:ListItem Value="R">घर</asp:ListItem>
                                                                    <asp:ListItem Value="OT">अन्य</asp:ListItem>
                                                                </asp:DropDownList></td>
                                                            <td style="width: 80px" valign="top">
                                                                <asp:Label ID="Label19" runat="server" Height="19px" SkinID="Unicodelbl" Text="फोन न." Width="55px"></asp:Label>
                                                            </td>
                                                            <td valign="top" width="250">
                                                                &nbsp;&nbsp;
                                                                <asp:TextBox ID="txtPhoneNumber_Phone" runat="server" MaxLength="15" SkinID="Unicodetxt" ToolTip="फोन नं" Width="130px"></asp:TextBox>
                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers" TargetControlID="txtPhoneNumber_Phone">
                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                            </td>
                                                            <td valign="top" width="60">
                                                                <asp:Button ID="btnPhonePlus" runat="server" OnClick="btnPhonePlus_Click" OnClientClick="javascript:return validateUpanelFields('_Phone',0);" SkinID="Add"
                                                                    Text="+" /></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" valign="top">
                                                                <asp:GridView ID="grdPhone" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="grdPhone_RowDataBound"
                                                                    OnRowDeleting="grdPhone_RowDeleting" OnSelectedIndexChanged="grdPhone_SelectedIndexChanged" SkinID="Unicodegrd">
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
                                                            <td colspan="1" valign="top">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="5" valign="top">
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
                                                                <asp:Label ID="LabelEmail" runat="server" Font-Bold="True" Height="19px" SkinID="Unicodelbl" Text="इमेल" Width="105px"></asp:Label></td>
                                                            <td colspan="1" valign="top" width="60">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 110px" valign="top">
                                                                <asp:Label ID="Label23" runat="server" Height="19px" SkinID="Unicodelbl" Text="ईमेलको किसिम" Width="105px"></asp:Label></td>
                                                            <td style="width: 150px" valign="top">
                                                                <asp:DropDownList ID="ddlEMailType_EMail" runat="server" SkinID="Unicodeddl" ToolTip="इमेलको किसिम" Width="135px">
                                                                    <asp:ListItem Value="N">छान्नुहोस</asp:ListItem>
                                                                    <asp:ListItem Value="P">ब्यक्तिगत</asp:ListItem>
                                                                    <asp:ListItem Value="O">अफिस</asp:ListItem>
                                                                    <asp:ListItem Value="OT">अन्य</asp:ListItem>
                                                                </asp:DropDownList></td>
                                                            <td style="width: 80px" valign="top">
                                                                <asp:Label ID="Label24" runat="server" Height="19px" SkinID="Unicodelbl" Text="ईमेल ठेगाना" Width="90px"></asp:Label></td>
                                                            <td valign="top" width="250">
                                                                <asp:TextBox ID="txtEMail_EMail" runat="server" MaxLength="50" SkinID="Unicodetxt" ToolTip="इमेल ठेगाना" Width="130px"></asp:TextBox></td>
                                                            <td valign="top" width="60">
                                                                <asp:Button ID="btnEMailPlus" runat="server" OnClick="btnEMailPlus_Click" OnClientClick="javascript:return ValidateEmailFR();" SkinID="Add" Text="+" /></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" valign="top">
                                                                <asp:GridView ID="grdEMail" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="grdEMail_RowDataBound"
                                                                    OnRowDeleting="grdEMail_RowDeleting" OnSelectedIndexChanged="grdEMail_SelectedIndexChanged" SkinID="Unicodegrd">
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
                                                            <td colspan="1" valign="top" width="60">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
<%--                                        </ContentTemplate>
                                        <HeaderTemplate>
                                            सम्पर्क
                                        </HeaderTemplate>
                                    </ajaxToolkit:TabPanel>
                                </ajaxToolkit:TabContainer>--%>
                            </td>
                        </tr>
                    </table>
                    <hr />
                </td>
            </tr>
            <tr>
                <td align="left" colspan="6" valign="top">
                </td>
            </tr>
            <tr>
                <td align="left" colspan="6" valign="top">
                    <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" OnClientClick="javascript:return validate(1);" SkinID="Normal" Text="Submit" />
                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" SkinID="Cancel" Text="Cancel" />&nbsp;</td>
            </tr>
        </table>
    </div>
</asp:Content>
