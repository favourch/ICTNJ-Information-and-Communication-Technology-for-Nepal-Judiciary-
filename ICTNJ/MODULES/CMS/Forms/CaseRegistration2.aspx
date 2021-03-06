<%@ Page Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" AutoEventWireup="true" CodeFile="CaseRegistration2.aspx.cs" Inherits="MODULES_CMS_Forms_CaseRegistration2" Title="CMS | Case Registration 2 [Lawyer]" %>

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

 <script language="javascript" src="../../COMMON/JS/Validation.js" type="text/javascript"></script>
    <script language="javascript" src="../../COMMON/JS/DateValidator.js" type="text/javascript"></script>
    <script language="javascript" src="../../COMMON/JS/EnglishDateValidator.js" type="text/javascript"></script>
    <script language="javascript" src="../../COMMON/JS/Number.js" type="text/javascript"></script>
    <script language="javascript" src="../../COMMON/JS/UPanelValidation.js" type="text/javascript"></script>
    <script language="javascript" src="../../COMMON/JS/EmailValidator.js" type="text/javascript"></script> 
       <asp:ScriptManager id="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Button runat="server" ID="hiddenTargetControlForModalPopup1" style="display:none"/>
        <ajaxToolkit:ModalPopupExtender runat="server" ID="programmaticModalPopup"
            BehaviorID="programmaticModalPopupBehavior1"
            TargetControlID="hiddenTargetControlForModalPopup1"
            PopupControlID="programmaticPopup" 
            BackgroundCssClass="modalBackground"
            DropShadow="True"
            PopupDragHandleControlID="programmaticPopupDragHandle"
            RepositionMode="RepositionOnWindowScroll" >
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel runat="server" CssClass="modalPopup" ID="programmaticPopup" style="display:none;width:350px;padding:10px">
            &nbsp;
            <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="border-right: gray 1px solid;
                border-top: gray 1px solid; border-left: gray 1px solid; cursor: move; color: black;
                border-bottom: gray 1px solid; background-color: #dddddd; text-align: center">
                Save Status
            </asp:Panel>
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>&nbsp;
            <br />
<asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click" Width="58px" />           <br />
        </asp:Panel>





    <table style="width: 932px">
        <tr>
            <td align="center" colspan="6">
                <asp:Label ID="Label6" runat="server" SkinID="UnicodeHeadlbl" Text="केशको विवरण"></asp:Label></td>
        </tr>
        <tr>
            <td align="left" colspan="6">
                <hr />
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:Label ID="Label7" runat="server" Text="केश नं" SkinID="Unicodelbl"></asp:Label></td>
            <td style="width: 100px">
                &nbsp;<asp:Label ID="lblCaseNo" runat="server" Text="lblCaseNo" SkinID="UnicodeDisplaylbl"></asp:Label></td>
            <td style="width: 100px">
                <asp:TextBox ID="txtCaseID" runat="server" Visible="False"></asp:TextBox></td>
            <td style="width: 100px">
                <asp:Label ID="lblIniUnit" runat="server" Text="3" Visible="False"></asp:Label></td>
            <td style="width: 100px">
                <asp:Label ID="lblIniType" runat="server" Text="9" Visible="False"></asp:Label></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 31px">
                <asp:Label ID="Label111" runat="server" SkinID="Unicodelbl" Text="मुद्दाको किसिम"
                    Width="105px"></asp:Label></td>
            <td style="width: 100px; height: 31px">
                <asp:Label ID="lblCaseType" runat="server" SkinID="UnicodeDisplaylbl" Text="Label"></asp:Label></td>
            <td style="width: 100px; height: 31px">
                <asp:Label ID="Label18" runat="server" SkinID="Unicodelbl" Text="दर्ता किसिम" Width="90px"></asp:Label></td>
            <td style="width: 100px; height: 31px">
                <asp:Label ID="lblRegType" runat="server" SkinID="UnicodeDisplaylbl" Text="Label"></asp:Label></td>
            <td style="width: 100px; height: 31px">
            </td>
            <td style="width: 100px; height: 31px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 31px;">
                <asp:Label ID="Label11111" runat="server" SkinID="Unicodelbl" Text="दर्ता किताब"
                    Width="87px"></asp:Label></td>
            <td style="width: 100px; height: 31px;">
                <asp:Label ID="lblRegDiary" runat="server" SkinID="UnicodeDisplaylbl" Text="Label"
                    Width="174px"></asp:Label></td>
            <td style="width: 100px; height: 31px;">
                <asp:Label ID="Label2e3" runat="server" SkinID="Unicodelbl" Text="मुद्दाको विषय"
                    Width="95px"></asp:Label></td>
            <td style="width: 100px; height: 31px;">
                <asp:Label ID="lblRegSubject" runat="server" SkinID="UnicodeDisplaylbl" Text="Label"></asp:Label></td>
            <td style="width: 100px; height: 31px;">
                <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="मुद्दाको नाम" Width="85px"></asp:Label></td>
            <td style="width: 100px; height: 31px;">
                <asp:Label ID="lblRegSubName" runat="server" SkinID="UnicodeDisplaylbl" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:Label ID="Label42" runat="server" SkinID="Unicodelbl" Text="दर्ता मिति"></asp:Label></td>
            <td style="width: 100px">
                <asp:Label ID="lblRegDate" runat="server" SkinID="UnicodeDisplaylbl" Text="Label"></asp:Label></td>
            <td style="width: 100px">
                <asp:Label ID="Label43" runat="server" SkinID="Unicodelbl" Text="अगाडि बढ्ने विधि"
                    Width="131px"></asp:Label></td>
            <td style="width: 100px">
                <asp:Label ID="lblPreceedingType" runat="server" SkinID="UnicodeDisplaylbl" Text="Label"></asp:Label></td>
            <td style="width: 100px">
                <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="लेखा शाखामा पठाउने"
                    Width="146px"></asp:Label></td>
            <td style="width: 100px">
                <asp:Label ID="lblForwardToAccount" runat="server" SkinID="UnicodeDisplaylbl" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="6">
                <hr />
            </td>
        </tr>
    </table>
    <table style="width: 930px">
        <tr>
            <td align="center" colspan="6">
                <asp:Label ID="Label3" runat="server" SkinID="UnicodeHeadlbl" Text="वकालतनामा"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="3">
                <table>
                    <tr>
                        <td style="width: 100px">
                <asp:Label ID="Label25" runat="server" SkinID="Unicodelbl" Text="सबै वादिहरू छान्नहोस" Width="151px"></asp:Label></td>
                        <td style="width: 100px">
                            <asp:CheckBox ID="chkAllApplicants" runat="server" AutoPostBack="True" OnCheckedChanged="chkAllApplicants_CheckedChanged" /></td>
                    </tr>
                </table>
            </td>
            <td colspan="3">
                <table>
                    <tr>
                        <td style="width: 100px">
                <asp:Label ID="Label37" runat="server" SkinID="Unicodelbl" Text="सवै प्रतिवादि छान्नहोस" Width="163px"></asp:Label></td>
                        <td style="width: 100px">
                            <asp:CheckBox ID="chkAllRespondants" runat="server" AutoPostBack="True" OnCheckedChanged="chkAllRespondants_CheckedChanged" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="3" valign="top">
                <asp:GridView ID="grdAppellant" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None" SkinID="Unicodegrd" Width="400px" OnRowDataBound="grdAppellant_RowDataBound">
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="LitigantID" HeaderText="LitigantID" />
                        <asp:BoundField DataField="LitigantName" HeaderText="वादि">
                            <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DisplayName" HeaderText="देखाउने नाम">
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="EntityTypeName" HeaderText="व्यक्ति/संस्था" />
                    </Columns>
                    <RowStyle BackColor="#EFF3FB" />
                    <EditRowStyle BackColor="#2461BF" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>
            <td colspan="3" valign="top">
                <asp:GridView ID="grdRespondant" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None" SkinID="Unicodegrd" Width="400px" OnDataBound="grdRespondant_DataBound" OnRowDataBound="grdRespondant_RowDataBound" OnSelectedIndexChanged="grdRespondant_SelectedIndexChanged1">
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="LitigantID" HeaderText="LitigantID" />
                        <asp:BoundField DataField="LitigantName" HeaderText="प्रतिवादि">
                            <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DisplayName" HeaderText="देखाउने नाम">
                            <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="EntityTypeName" HeaderText="व्यक्ति/संस्था" />
                    </Columns>
                    <RowStyle BackColor="#EFF3FB" />
                    <EditRowStyle BackColor="#2461BF" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <hr />
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:Panel ID="pnlPersonnelInfo" runat="server" Height="800px" Width="125px">
    <table style="width: 928px">
        <tr>
            <td style="width: 900px; height: 21px;" align="center">
                <asp:Label ID="Label4" runat="server" Text="वकिलको विवरण" SkinID="UnicodeHeadlbl" Width="219px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 900px">
                <table style="width: 942px">
                    <tr>
                        <td style="width: 100px" valign="top">
                            <asp:Label ID="Label21" runat="server" Height="22px" SkinID="Unicodelbl" Text="पहिलो नाम"
                                Width="90px"></asp:Label></td>
                        <td style="width: 100px" valign="top">
                            <asp:TextBox ID="txtFName_Rqd" runat="server" MaxLength="35" SkinID="Unicodetxt"
                                ToolTip="पहिलो नाम" Width="130px"></asp:TextBox></td>
                        <td style="width: 100px" valign="top">
                            <asp:Label ID="Label22" runat="server" Height="22px" SkinID="Unicodelbl" Text="बिचको नाम"></asp:Label></td>
                        <td style="width: 100px" valign="top">
                            <asp:TextBox ID="txtMName_RQD" runat="server" MaxLength="15" SkinID="Unicodetxt"
                                Width="130px"></asp:TextBox></td>
                        <td style="width: 100px" valign="top">
                            <asp:Label ID="Label200" runat="server" Height="22px" SkinID="Unicodelbl" Text="थर"
                                Width="110px"></asp:Label></td>
                        <td style="width: 100px" valign="top">
                            <asp:TextBox ID="txtSurName_Rqd" runat="server" MaxLength="35" SkinID="Unicodetxt"
                                ToolTip="थर" Width="130px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 100px" valign="top">
                            <asp:Label ID="Labe201" runat="server" Height="22px" SkinID="Unicodelbl" Text="जन्म मिति"
                                Width="90px"></asp:Label></td>
                        <td style="width: 100px" valign="top">
                            <asp:TextBox ID="txtDOB_DT" runat="server" MaxLength="10" SkinID="Unicodetxt" ToolTip="जन्म मिति"
                                Width="130px"></asp:TextBox><ajaxtoolkit:maskededitextender id="MaskedEditExtender1"
                                    runat="server" autocomplete="False" cultureampmplaceholder="" culturecurrencysymbolplaceholder=""
                                    culturedateformat="" culturedateplaceholder="" culturedecimalplaceholder="" culturethousandsplaceholder=""
                                    culturetimeplaceholder="" enabled="True" mask="9999/99/99" masktype="Date" targetcontrolid="txtDOB_DT"> </ajaxtoolkit:maskededitextender></td>
                        <td style="width: 100px" valign="top">
                            <asp:Label ID="Labe202" runat="server" Height="22px" SkinID="Unicodelbl" Text="लिंग"></asp:Label></td>
                        <td style="width: 100px" valign="top">
                            <asp:DropDownList ID="ddlGender" runat="server" SkinID="Unicodeddl" Width="135px">
                                <asp:ListItem Value="SG">छान्नुहोस</asp:ListItem>
                                <asp:ListItem Value="M">पुरुष</asp:ListItem>
                                <asp:ListItem Value="F">महिला</asp:ListItem>
                                <asp:ListItem Value="O">अन्य</asp:ListItem>
                            </asp:DropDownList></td>
                        <td style="width: 100px" valign="top">
                            <asp:Label ID="Labe203" runat="server" Height="22px" SkinID="Unicodelbl" Text="बैबाहिक सम्बन्ध"
                                Width="115px"></asp:Label></td>
                        <td style="width: 100px" valign="top">
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
                        <td style="width: 100px" valign="top">
                            <asp:Label ID="Labe204" runat="server" Height="22px" SkinID="Unicodelbl" Text="देश"
                                Width="90px"></asp:Label></td>
                        <td style="width: 100px" valign="top">
                            <asp:DropDownList ID="ddlCountry" runat="server" SkinID="Unicodeddl" Width="135px">
                            </asp:DropDownList></td>
                        <td style="width: 100px" valign="top">
                            <asp:Label ID="Labe205" runat="server" Height="22px" SkinID="Unicodelbl" Text="घर भएको जिल्ला"
                                Width="120px"></asp:Label></td>
                        <td style="width: 100px" valign="top">
                            <asp:DropDownList ID="ddlBirthDistrict" runat="server" SkinID="Unicodeddl" Width="135px">
                            </asp:DropDownList></td>
                        <td style="width: 100px" valign="top">
                            <asp:Label ID="Labe206" runat="server" Height="22px" SkinID="Unicodelbl" Text="धर्म"
                                Width="110px"></asp:Label></td>
                        <td style="width: 100px" valign="top">
                            <asp:DropDownList ID="ddlReligion" runat="server" SkinID="Unicodeddl" Width="135px">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td style="width: 100px" valign="top">
                            <asp:Label ID="Label29" runat="server" SkinID="Unicodelbl" Text="हुलिया" Width="90px"></asp:Label></td>
                        <td style="width: 100px" valign="top">
                            <asp:TextBox ID="txtIdentityMark" runat="server" MaxLength="30" SkinID="Unicodetxt"
                                Width="130px"></asp:TextBox></td>
                        <td style="width: 100px" valign="top">
                            <asp:Label ID="Label5" runat="server" Text="लाईसन्स नं" SkinID="Unicodelbl"></asp:Label>
                            </td>
                        <td colspan="2" valign="top">
                            <asp:TextBox ID="txtLicenceNo" runat="server" MaxLength="20"></asp:TextBox></td>
                        <td style="width: 100px" valign="top">
                            <asp:TextBox ID="txtPersonID" runat="server" Visible="False" Width="67px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 100px" valign="top">
                            </td>
                        <td style="width: 100px" valign="top">
                            </td>
                        <td style="width: 100px" valign="top">
                        </td>
                        <td colspan="2" valign="top">
                        </td>
                        <td style="width: 100px" valign="top">
                        </td>
                    </tr>
                </table>
                <hr />
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                            <asp:UpdatePanel id="UpdatePanel15" runat="server">
                                <contenttemplate>
<TABLE style="WIDTH: 650px"><TBODY><TR><TD style="HEIGHT: 2px" vAlign=top colSpan=6><asp:Label id="Label26" runat="server" Text="स्थायी ठेगाना" SkinID="Unicodelbl" Font-Bold="True" __designer:wfdid="w164"></asp:Label> </TD></TR><TR><TD style="WIDTH: 60px; HEIGHT: 28px" vAlign=top><asp:Label id="Label82" runat="server" Width="50px" Height="19px" Text="जिल्ला" SkinID="Unicodelbl" __designer:wfdid="w165"></asp:Label> </TD><TD style="WIDTH: 170px; HEIGHT: 28px" vAlign=top><asp:DropDownList id="ddlDistrict" runat="server" Width="150px" SkinID="Unicodeddl" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" __designer:wfdid="w166"></asp:DropDownList> </TD><TD style="WIDTH: 105px; HEIGHT: 28px" vAlign=top><asp:Label id="Label84" runat="server" Width="95px" Height="19px" Text="गा.बि.स./न.पा." SkinID="Unicodelbl" __designer:wfdid="w167"></asp:Label> </TD><TD style="WIDTH: 170px; HEIGHT: 28px" vAlign=top><asp:DropDownList id="ddlVDC" runat="server" Width="150px" SkinID="Unicodeddl" AutoPostBack="True" OnSelectedIndexChanged="ddlVDC_SelectedIndexChanged" __designer:wfdid="w168">
                                                                </asp:DropDownList> </TD><TD style="WIDTH: 60px; HEIGHT: 28px" vAlign=top><asp:Label id="Label210" runat="server" Width="50px" Height="19px" Text="वडा नं." SkinID="Unicodelbl" __designer:wfdid="w169"></asp:Label> </TD><TD style="HEIGHT: 28px" vAlign=top><asp:DropDownList id="ddlWard" runat="server" Width="70px" SkinID="Unicodeddl" OnSelectedIndexChanged="ddlWard_SelectedIndexChanged" __designer:wfdid="w170" AppendDataBoundItems="True">
                                                                </asp:DropDownList> </TD></TR><TR><TD style="WIDTH: 60px" vAlign=top><asp:Label id="Label83" runat="server" Height="19px" Text="टोल" SkinID="Unicodelbl" __designer:wfdid="w171"></asp:Label> </TD><TD style="WIDTH: 170px" vAlign=top><asp:TextBox id="txtTole" runat="server" Width="150px" SkinID="Unicodetxt" MaxLength="100" __designer:wfdid="w172" TextMode="MultiLine"></asp:TextBox></TD><TD style="WIDTH: 105px" vAlign=top><asp:ImageButton id="imgDelPerAddress" onclick="imgDelPerAddress_Click" runat="server" ImageUrl="~/MODULES/COMMON/Images/bycat1.ico" Visible="False" __designer:wfdid="w173" OnClientClick="return confirm('यो ठेगाना हटाउने हो ?')" AlternateText="Delete This Address"></asp:ImageButton></TD><TD style="WIDTH: 170px" vAlign=top><asp:TextBox id="txtPerAdd" runat="server" Visible="False" __designer:wfdid="w174"></asp:TextBox></TD><TD style="WIDTH: 60px" vAlign=top></TD><TD vAlign=top></TD></TR><TR><TD vAlign=top colSpan=6>
<HR />
</TD></TR></TBODY></TABLE><asp:HiddenField id="hdnPerAddress" runat="server" __designer:wfdid="w175"></asp:HiddenField> <asp:HiddenField id="hdnTempAddress" runat="server" __designer:wfdid="w176"></asp:HiddenField> <TABLE style="WIDTH: 650px"><TBODY><TR><TD style="HEIGHT: 21px" vAlign=top colSpan=6><asp:Label id="Label85" runat="server" Text="अस्थायी ठेगाना" SkinID="Unicodelbl" Font-Bold="True" __designer:wfdid="w177"></asp:Label></TD></TR><TR><TD style="WIDTH: 60px" vAlign=top><asp:Label id="Label86" runat="server" Width="50px" Height="19px" Text="जिल्ला" SkinID="Unicodelbl" __designer:wfdid="w178"></asp:Label></TD><TD style="WIDTH: 170px" vAlign=top><asp:DropDownList id="ddlDistrictTemp" runat="server" Width="150px" SkinID="Unicodeddl" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrictTemp_SelectedIndexChanged" __designer:wfdid="w179">
                                                                </asp:DropDownList></TD><TD style="WIDTH: 105px" vAlign=top><asp:Label id="Label87" runat="server" Width="95px" Height="19px" Text="गा.बि.स./न.पा." SkinID="Unicodelbl" __designer:wfdid="w180"></asp:Label></TD><TD style="WIDTH: 170px" vAlign=top><asp:DropDownList id="ddlVDCTemp" runat="server" Width="150px" SkinID="Unicodeddl" AutoPostBack="True" OnSelectedIndexChanged="ddlVDCTemp_SelectedIndexChanged" __designer:wfdid="w181">
                                                                </asp:DropDownList></TD><TD style="WIDTH: 60px" vAlign=top><asp:Label id="Label88" runat="server" Width="50px" Height="19px" Text="वडा नं." SkinID="Unicodelbl" __designer:wfdid="w182"></asp:Label></TD><TD vAlign=top><asp:DropDownList id="ddlWardTemp" runat="server" Width="70px" SkinID="Unicodeddl" OnSelectedIndexChanged="ddlWardTemp_SelectedIndexChanged" __designer:wfdid="w183" AppendDataBoundItems="True">
                                                                </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 60px" vAlign=top><asp:Label id="Label89" runat="server" Height="19px" Text="टोल" SkinID="Unicodelbl" __designer:wfdid="w184"></asp:Label></TD><TD style="WIDTH: 170px" vAlign=top><asp:TextBox id="txtToleTemp" runat="server" Width="150px" SkinID="Unicodetxt" MaxLength="100" __designer:wfdid="w185" TextMode="MultiLine"></asp:TextBox></TD><TD style="WIDTH: 105px" vAlign=top><asp:ImageButton id="imgDelTempAddress" onclick="imgDelTempAddress_Click" runat="server" ImageUrl="~/MODULES/COMMON/Images/bycat1.ico" Visible="False" __designer:wfdid="w186" OnClientClick="return confirm('यो ठेगाना हटाउने हो ?')" AlternateText="Delete This Address"></asp:ImageButton></TD><TD style="WIDTH: 170px" vAlign=top><asp:TextBox id="txtTempAdd" runat="server" Visible="False" __designer:wfdid="w187" ReadOnly="True"></asp:TextBox></TD><TD style="WIDTH: 60px" vAlign=top></TD><TD vAlign=top></TD></TR><TR><TD style="HEIGHT: 37px" vAlign=top colSpan=6>
<HR />
</TD></TR></TBODY></TABLE>
</contenttemplate>
                            </asp:UpdatePanel></td>
        </tr>
        <tr>
            <td style="width: 100px">
                            <asp:UpdatePanel id="UpdatePanel10" runat="server">
                                <contenttemplate>
<TABLE style="WIDTH: 650px"><TBODY><TR><TD style="HEIGHT: 21px" vAlign=top colSpan=4><asp:Label id="Label211" runat="server" Width="105px" Height="19px" Text="फोन" SkinID="Unicodelbl" Font-Bold="True" __designer:wfdid="w188"></asp:Label></TD><TD style="WIDTH: 19px; HEIGHT: 21px" vAlign=top colSpan=1></TD></TR><TR><TD style="WIDTH: 110px" vAlign=top><asp:Label id="Label212" runat="server" Width="105px" Height="19px" Text="फोनको किसिम" SkinID="Unicodelbl" __designer:wfdid="w189"></asp:Label> </TD><TD style="WIDTH: 150px" vAlign=top><asp:DropDownList id="ddlPhoneType_Phone" runat="server" Width="135px" SkinID="Unicodeddl" ToolTip="फोनको किसिम" __designer:wfdid="w190"><asp:ListItem Value="N">छान्नुहोस</asp:ListItem>
<asp:ListItem Value="M">मोबाईल</asp:ListItem>
<asp:ListItem Value="O">अफिस</asp:ListItem>
<asp:ListItem Value="R">घर</asp:ListItem>
<asp:ListItem Value="OT">अन्य</asp:ListItem>
</asp:DropDownList></TD><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Label213" runat="server" Width="55px" Height="19px" Text="फोन न." SkinID="Unicodelbl" __designer:wfdid="w191"></asp:Label> </TD><TD vAlign=top><asp:TextBox id="txtPhoneNumber_Phone" runat="server" Width="130px" SkinID="Unicodetxt" ToolTip="फोन नं" MaxLength="15" __designer:wfdid="w192"></asp:TextBox> <ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender1" runat="server" TargetControlID="txtPhoneNumber_Phone" __designer:wfdid="w193" FilterType="Numbers">
                                                                </ajaxToolkit:FilteredTextBoxExtender> </TD><TD style="WIDTH: 19px" vAlign=top><asp:Button id="btnPhonePlus" onclick="btnPhonePlus_Click" runat="server" Text="+" SkinID="Add" __designer:wfdid="w194" OnClientClick="javascript:return validateUpanelFields('_Phone',0);"></asp:Button></TD></TR><TR><TD vAlign=top colSpan=4><asp:GridView id="grdPhone" runat="server" SkinID="Unicodegrd" ForeColor="#333333" GridLines="None" CellPadding="4" AutoGenerateColumns="False" OnRowDataBound="grdPhone_RowDataBound" OnSelectedIndexChanged="grdPhone_SelectedIndexChanged" OnRowDeleting="grdPhone_RowDeleting" __designer:wfdid="w195">
                                                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"  />
                                                                    <Columns>
                                                                        <asp:BoundField DataField="PID" HeaderText="PersonID" ></asp:BoundField>
                                                                        <asp:BoundField DataField="PTYPE" HeaderText="Phone Type" ></asp:BoundField>
                                                                        <asp:BoundField DataField="PHONETYPE" HeaderText="फोनको किसिम">
                                                                            <ItemStyle Width="100px"  />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="PSNO" HeaderText="PSNo" ></asp:BoundField>
                                                                        <asp:BoundField DataField="PHONE" HeaderText="फोन नं.">
                                                                            <ItemStyle Width="200px"  />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="ACTIVE" HeaderText="Active" ></asp:BoundField>
                                                                        <asp:BoundField DataField="REMARKS" HeaderText="कैफियत" ></asp:BoundField>
                                                                        <asp:BoundField DataField="ACTION" HeaderText="Action" ></asp:BoundField>
                                                                        <asp:CommandField ShowSelectButton="True">
                                                                            <ItemStyle Font-Names="Verdana" Width="50px"  />
                                                                        </asp:CommandField>
                                                                        <asp:CommandField ShowDeleteButton="True">
                                                                            <ItemStyle Font-Names="Verdana" Width="50px"  />
                                                                        </asp:CommandField>
                                                                    </Columns>
                                                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333"  />
                                                                    <EditRowStyle BackColor="#999999"  />
                                                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"  />
                                                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"  />
                                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"  />
                                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775"  />
                                                                </asp:GridView> </TD><TD style="WIDTH: 19px" vAlign=top colSpan=1></TD></TR><TR><TD style="HEIGHT: 37px" vAlign=top colSpan=5>
<HR />
</TD></TR></TBODY></TABLE>
</contenttemplate>
                            </asp:UpdatePanel></td>
        </tr>
        <tr>
            <td style="width: 900px">
                            <asp:UpdatePanel id="UpdatePanel20" runat="server">
                                <contenttemplate>
<TABLE style="WIDTH: 650px"><TBODY><TR><TD vAlign=top colSpan=4><asp:Label id="LabelEmail" runat="server" Width="105px" Height="19px" Text="इमेल" SkinID="Unicodelbl" Font-Bold="True" __designer:wfdid="w196"></asp:Label></TD><TD vAlign=top colSpan=1></TD></TR><TR><TD style="WIDTH: 110px" vAlign=top><asp:Label id="Label23" runat="server" Width="105px" Height="19px" Text="ईमेलको किसिम" SkinID="Unicodelbl" __designer:wfdid="w197"></asp:Label></TD><TD style="WIDTH: 150px" vAlign=top><asp:DropDownList id="ddlEMailType_EMail" runat="server" Width="135px" SkinID="Unicodeddl" ToolTip="इमेलको किसिम" __designer:wfdid="w198"><asp:ListItem Value="N">छान्नुहोस</asp:ListItem>
<asp:ListItem Value="P">ब्यक्तिगत</asp:ListItem>
<asp:ListItem Value="O">अफिस</asp:ListItem>
<asp:ListItem Value="OT">अन्य</asp:ListItem>
</asp:DropDownList></TD><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Label24" runat="server" Width="90px" Height="19px" Text="ईमेल ठेगाना" SkinID="Unicodelbl" __designer:wfdid="w199"></asp:Label></TD><TD vAlign=top><asp:TextBox id="txtEMail_EMail" runat="server" Width="130px" SkinID="Unicodetxt" ToolTip="इमेल ठेगाना" MaxLength="50" __designer:wfdid="w200"></asp:TextBox></TD><TD vAlign=top><asp:Button id="btnEMailPlus" onclick="btnEMailPlus_Click" runat="server" Text="+" SkinID="Add" __designer:wfdid="w201" OnClientClick="javascript:return ValidateEmailFR();"></asp:Button></TD></TR><TR><TD vAlign=top colSpan=4><asp:GridView id="grdEMail" runat="server" SkinID="Unicodegrd" ForeColor="#333333" GridLines="None" CellPadding="4" AutoGenerateColumns="False" OnRowDataBound="grdEMail_RowDataBound" OnSelectedIndexChanged="grdEMail_SelectedIndexChanged" OnRowDeleting="grdEMail_RowDeleting" __designer:wfdid="w202">
                                                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"  />
                                                                    <Columns>
                                                                        <asp:BoundField DataField="PID" HeaderText="PersonID" ></asp:BoundField>
                                                                        <asp:BoundField DataField="ETYPE" HeaderText="EMail Type" ></asp:BoundField>
                                                                        <asp:BoundField DataField="EMAILTYPE" HeaderText="ईमेलको किसिम">
                                                                            <ItemStyle Width="100px"  />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="ESNO" HeaderText="ESNo" ></asp:BoundField>
                                                                        <asp:BoundField DataField="EMAIL" HeaderText="ईमेल ठेगाना">
                                                                            <ItemStyle Font-Names="Verdana" Width="200px"  />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="ACTIVE" HeaderText="Active" ></asp:BoundField>
                                                                        <asp:BoundField DataField="REMARKS" HeaderText="कैफियत" ></asp:BoundField>
                                                                        <asp:BoundField DataField="ACTION" HeaderText="Action" ></asp:BoundField>
                                                                        <asp:CommandField ShowSelectButton="True">
                                                                            <ItemStyle Font-Names="Verdana" Width="50px"  />
                                                                        </asp:CommandField>
                                                                        <asp:CommandField ShowDeleteButton="True">
                                                                            <ItemStyle Font-Names="Verdana" Width="50px"  />
                                                                        </asp:CommandField>
                                                                    </Columns>
                                                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333"  />
                                                                    <EditRowStyle BackColor="#999999"  />
                                                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"  />
                                                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"  />
                                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"  />
                                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775"  />
                                                                </asp:GridView> </TD><TD vAlign=top colSpan=1></TD></TR></TBODY></TABLE>
</contenttemplate>
                            </asp:UpdatePanel><hr />
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 21px;">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" style="width: 900px">
                </td>
        </tr>
    </table>
                </asp:Panel>
                <table style="width: 250px">
                    <tr>
                        <td style="width: 50px" valign="top">
                            <asp:Label ID="Label39" runat="server" SkinID="Unicodelbl" Text="अवधि देखि"
                                                            Width="86px" Visible="False"></asp:Label></td>
                        <td style="width: 50px">
                                                        <asp:TextBox ID="txtLawyerFromDate" runat="server" Columns="12" SkinID="Unicodetxt" Visible="False"></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender ID="medLawyerFromDate" runat="server" AutoComplete="False"
                                Mask="9999/99/99" MaskType="Date" TargetControlID="txtLawyerFromDate">
                            </ajaxToolkit:MaskedEditExtender>
                            &nbsp;
                        </td>
                        <td style="width: 60px" align="right" valign="top">
                                                        <asp:Label ID="Label38" runat="server" SkinID="Unicodelbl" Text="अवधि सम्म" Width="82px" Visible="False"></asp:Label></td>
                        <td style="width: 100px">
                                                        <asp:TextBox ID="txtLawyerToDate" runat="server" Columns="12" SkinID="Unicodetxt" Visible="False"></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender ID="medLawyerToDate" runat="server" AutoComplete="False"
                                Mask="9999/99/99" MaskType="Date" TargetControlID="txtLawyerToDate">
                            </ajaxToolkit:MaskedEditExtender>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <table style="width: 934px">
                    <tr>
                        <td style="width: 100px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                <asp:Button ID="btnAddLawyer" runat="server" OnClick="btnAddLawyer_Click" Text="+" SkinID="Add" /></td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                <asp:GridView ID="grdLitigantLawyer" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None" OnRowDataBound="grdLitigantLawyer_RowDataBound" OnSelectedIndexChanged="grdLitigantLawyer_SelectedIndexChanged" OnDataBound="grdLitigantLawyer_DataBound" OnRowDeleted="grdLitigantLawyer_RowDeleted" OnRowDeleting="grdLitigantLawyer_RowDeleting" SkinID="MergedGrid">
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:BoundField DataField="CaseID" HeaderText="CaseID" />
                        <asp:BoundField DataField="AppOrResp" HeaderText="AppOrResp" />
                        <asp:BoundField DataField="LitigantID" HeaderText="LitigantID" />
                        <asp:BoundField DataField="LitigantName" HeaderText="LitigantName" >
                            <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="LawyerID" HeaderText="LawyerID" />
                        <asp:BoundField DataField="LawyerName" HeaderText="LawyerName" >
                            <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="LicenceNo" HeaderText="Licence No">
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FromDate" HeaderText="From Date">
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ToDate" HeaderText="To Date">
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Action" HeaderText="Action" />
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:CommandField ShowDeleteButton="True" />
                    </Columns>
                    <RowStyle BackColor="#EFF3FB" />
                    <EditRowStyle BackColor="#2461BF" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 900px">
                <asp:Button ID="btnNext" runat="server" OnClick="btnNext_Click" SkinID="Normal" Text="Next" /></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    &nbsp;
</asp:Content>

