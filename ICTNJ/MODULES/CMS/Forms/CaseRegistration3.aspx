<%@ Page Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" AutoEventWireup="true" CodeFile="CaseRegistration3.aspx.cs" Inherits="MODULES_CMS_Forms_CaseRegistration3" Title="CMS | Case Registration [Witness]" %>

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
                <asp:Label ID="Label8" runat="server" SkinID="UnicodeHeadlbl" Text="केशको विवरण"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="6" style="height: 37px">
                <hr />
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 26px;">
                <asp:Label ID="Label7" runat="server" Text="केश नं" SkinID="Unicodelbl"></asp:Label></td>
            <td style="width: 100px; height: 26px;">
                &nbsp;<asp:Label ID="lblCaseNo" runat="server" Text="lblCaseNo" SkinID="Unicodelbl"></asp:Label></td>
            <td style="width: 100px; height: 26px;">
                <asp:TextBox ID="txtCaseNo" runat="server" Visible="False"></asp:TextBox></td>
            <td style="width: 100px; height: 26px;">
                <asp:Label ID="lblIniUnit" runat="server" Text="3" Visible="False"></asp:Label></td>
            <td style="width: 100px; height: 26px;">
                <asp:Label ID="lblIniType" runat="server" Text="9" Visible="False"></asp:Label></td>
            <td style="width: 100px; height: 26px;">
                </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 31px">
                <asp:Label ID="Label1121" runat="server" SkinID="Unicodelbl" Text="मुद्दाको किसिम" Width="105px"></asp:Label></td>
            <td style="width: 100px; height: 31px">
                <asp:Label
                    ID="lblCaseType" runat="server" SkinID="UnicodeDisplaylbl" Text="Label"></asp:Label></td>
            <td style="width: 100px; height: 31px">
            <asp:Label
                        ID="Label18" runat="server" SkinID="Unicodelbl" Text="दर्ता किसिम" Width="90px"></asp:Label></td>
            <td style="width: 100px; height: 31px">
            <asp:Label
                            ID="lblRegType" runat="server" SkinID="UnicodeDisplaylbl" Text="Label"></asp:Label></td>
            <td style="width: 100px; height: 31px">
            </td>
            <td style="width: 100px; height: 31px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 31px">
            <asp:Label
                                ID="Label1" runat="server" SkinID="Unicodelbl" Text="दर्ता किताब" Width="87px"></asp:Label></td>
            <td style="width: 100px; height: 31px">
            <asp:Label
                                    ID="lblRegDiary" runat="server" SkinID="UnicodeDisplaylbl" Text="Label" Width="177px"></asp:Label></td>
            <td style="width: 100px; height: 31px">
            <asp:Label
                                        ID="Label21212" runat="server" SkinID="Unicodelbl" Text="मुद्दाको विषय" Width="95px"></asp:Label></td>
            <td style="width: 100px; height: 31px">
            <asp:Label
                                            ID="lblRegSubject" runat="server" SkinID="UnicodeDisplaylbl" Text="Label"></asp:Label></td>
            <td style="width: 100px; height: 31px">
            <asp:Label
                                                ID="Label2" runat="server" SkinID="Unicodelbl" Text="मुद्दाको नाम" Width="85px"></asp:Label></td>
            <td style="width: 100px; height: 31px">
            <asp:Label
                                                    ID="lblRegSubName" runat="server" SkinID="UnicodeDisplaylbl" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 31px;">
                <asp:Label
                                                        ID="Label42" runat="server" SkinID="Unicodelbl" Text="दर्ता मिति"></asp:Label></td>
            <td style="width: 100px; height: 31px;">
                <asp:Label
                                                            ID="lblRegDate" runat="server" SkinID="UnicodeDisplaylbl" Text="Label"></asp:Label></td>
            <td style="width: 100px; height: 31px;">
            <asp:Label
                                                                ID="Label43" runat="server" SkinID="Unicodelbl" Text="अगाडि बढ्ने विधि" Width="131px"></asp:Label></td>
            <td style="width: 100px; height: 31px;">
            <asp:Label
                                                                    ID="lblPreceedingType" runat="server" SkinID="UnicodeDisplaylbl" Text="Label"></asp:Label></td>
            <td style="width: 100px; height: 31px;">
            <asp:Label
                                                                        ID="Label6" runat="server" SkinID="Unicodelbl" Text="लेखा शाखामा पठाउने" Width="146px"></asp:Label></td>
            <td style="width: 100px; height: 31px;">
            <asp:Label
                                                                            ID="lblForwardToAccount" runat="server" SkinID="UnicodeDisplaylbl" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
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
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="6">
            
            
     
            
            
            
            
            </td>
        </tr>
        <tr>
            <td colspan="6">
            </td>
        </tr>
    </table>
    <table style="width: 930px">
        <tr>
            <td style="height: 21px;" align="center" colspan="6">
                <asp:Label ID="Label3" runat="server" SkinID="UnicodeHeadlbl" Text="साक्षी"></asp:Label>
                <hr />
            </td>
        </tr>
        <tr>
            <td style="width: 71px">
                </td>
            <td style="width: 100px">
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
            <td colspan="3" valign="top">
                <table>
                    <tr>
                        <td style="width: 74px">
                            <asp:Label ID="Label25" runat="server" SkinID="Unicodelbl" Text="सबै छान्नुहोस"></asp:Label></td>
                        <td style="width: 100px">
                            <asp:CheckBox ID="chkSelectAllAppellants" runat="server" AutoPostBack="True" OnCheckedChanged="chkSelectAllAppellants_CheckedChanged" /></td>
                    </tr>
                </table>
            </td>
            <td colspan="3" valign="top">
                <table>
                    <tr>
                        <td style="width: 74px">
                            <asp:Label ID="Label5" runat="server" SkinID="Unicodelbl" Text="सबै छान्नुहोस"></asp:Label></td>
                        <td style="width: 100px">
                            <asp:CheckBox ID="chkSelectAllRespondants" runat="server" AutoPostBack="True" OnCheckedChanged="chkSelectAllRespondants_CheckedChanged"
                                SkinID="smallChk" Enabled="False" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="3" valign="top">
                <asp:GridView ID="grdAppellant" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None" SkinID="Unicodegrd" Width="400px">
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
                    ForeColor="#333333" GridLines="None" SkinID="Unicodegrd" Width="400px" OnRowDataBound="grdRespondant_RowDataBound">
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
            <td style="width: 71px">
            </td>
            <td style="width: 100px">
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
            </td>
        </tr>
    </table>
    <table style="width: 928px">
        <tr>
            <td style="width: 900px; height: 21px;" align="left">
                
                
                
                                  <asp:Panel ID="pnlPersonSearch1" runat="server" CssClass="collapsePanelHeader" Height="25px"
        Width="950px">
        साक्षी खोज्नहोस
        <asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageAlign="Right"
            ImageUrl="~/MODULES/COMMON/Images/expand.jpg" Visible="False" />
    </asp:Panel>
    <ajaxToolkit:CollapsiblePanelExtender ID="colPersonSearch" runat="server" CollapseControlID="pnlPersonSearch1"
        Collapsed="True" CollapsedImage="../../COMMON/Images/expand_blue.jpg" ExpandControlID="pnlPersonSearch1"
        ExpandedImage="../../COMMON/Images/collapse_blue.jpg" ImageControlID="imgCol"
        SkinID="CollapsiblePanelDemo" SuppressPostBack="True" TargetControlID="pnlPersonContent">
    </ajaxToolkit:CollapsiblePanelExtender>
    <asp:Panel ID="pnlPersonContent" runat="server" CssClass="collapsePanel" Width="1024px">
        <table style="width: 929px">
            <tr>
                <td style="width: 100px; height: 26px;">
                    <asp:Label ID="Label2111" runat="server" Height="22px" SkinID="Unicodelbl" Text="पहिलो नाम"
                        Width="90px"></asp:Label></td>
                <td style="width: 100px; height: 26px;">
                    <asp:TextBox ID="txtSrcFName" runat="server" SkinID="Unicodetxt"></asp:TextBox></td>
                <td style="width: 100px; height: 26px;">
                    <asp:Label ID="Label222" runat="server" Height="22px" SkinID="Unicodelbl" Text="बिचको नाम"></asp:Label></td>
                <td style="width: 100px; height: 26px;">
                    <asp:TextBox ID="txtSrcMName" runat="server" SkinID="Unicodetxt"></asp:TextBox></td>
                <td style="width: 100px; height: 26px;">
                    <asp:Label ID="Label2001" runat="server" Height="22px" SkinID="Unicodelbl" Text="थर"
                        Width="110px"></asp:Label></td>
                <td style="width: 100px; height: 26px;">
                    <asp:TextBox ID="txtSrcSName" runat="server" SkinID="Unicodetxt"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Labe2011" runat="server" Height="22px" SkinID="Unicodelbl" Text="जन्म मिति"
                        Width="90px"></asp:Label></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtSrcDOB" runat="server" SkinID="Unicodetxt"></asp:TextBox></td>
                <td style="width: 100px">
                    <asp:Label ID="Labe2021" runat="server" Height="22px" SkinID="Unicodelbl" Text="लिंग"></asp:Label></td>
                <td style="width: 100px">
                    <asp:DropDownList ID="ddlSrcGender" runat="server" SkinID="Unicodeddl" Width="135px">
                        <asp:ListItem Value="SG">छान्नुहोस</asp:ListItem>
                        <asp:ListItem Value="M">पुरुष</asp:ListItem>
                        <asp:ListItem Value="F">महिला</asp:ListItem>
                        <asp:ListItem Value="O">अन्य</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 100px">
                    <asp:Label ID="Labe203w" runat="server" Height="22px" SkinID="Unicodelbl" Text="बैबाहिक सम्बन्ध"
                        Width="115px"></asp:Label></td>
                <td style="width: 100px">
                    <asp:DropDownList ID="ddlSrcMaritalStatus" runat="server" SkinID="Unicodeddl" Width="135px">
                        <asp:ListItem Value="SMS">छान्नुहोस</asp:ListItem>
                        <asp:ListItem Value="S">अबिबाहित</asp:ListItem>
                        <asp:ListItem Value="M">बिबाहित</asp:ListItem>
                        <asp:ListItem Value="W">बिधवा/बिदुर</asp:ListItem>
                        <asp:ListItem Value="D">छोडपत्र</asp:ListItem>
                        <asp:ListItem Value="O">अन्य</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Labe2051" runat="server" Height="22px" SkinID="Unicodelbl" Text="घर भएको जिल्ला"
                        Width="120px"></asp:Label></td>
                <td style="width: 100px">
                    <asp:DropDownList ID="ddlSrcBirthDistrict" runat="server" SkinID="Unicodeddl">
                    </asp:DropDownList></td>
                <td style="width: 100px">
                    <asp:Label ID="Label441" runat="server" SkinID="Unicodelbl" Text="कागज‍-पत्रको किसिम"
                        Width="143px"></asp:Label></td>
                <td style="width: 100px">
                    <asp:DropDownList ID="ddlSrcDocumentType" runat="server" SkinID="Unicodeddl">
                    </asp:DropDownList></td>
                <td style="width: 100px">
                    <asp:Label ID="lblDocumentType1" runat="server" SkinID="Unicodelbl" Text="कागज-पत्रको नं"></asp:Label></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtSrcDocumentNo" runat="server" SkinID="Unicodetxt"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px" align="right">
                    <asp:Button ID="btnSearchPerson" runat="server" SkinID="Search" Text="Search" OnClick="btnSearchPerson_Click" /></td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:Label ID="lblSearchx" runat="server" Text="Label"></asp:Label>&nbsp;
                    <asp:Panel ID="Panel3" runat="server" Height="200px" ScrollBars="Vertical" Width="950px">
                    <asp:GridView ID="grdPerson" runat="server" AutoGenerateColumns="False" CellPadding="0"
                        ForeColor="#333333" 
                        SkinID="Unicodegrd" Width="870px" OnRowDataBound="grdPerson_RowDataBound" OnSelectedIndexChanged="grdPerson_SelectedIndexChanged">
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="PersonID" HeaderText="आई डी" />
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
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
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
        </table>
        
    </asp:Panel>
                
            
            
            
                </td>
        </tr>
        <tr>
            <td align="center" style="width: 900px; height: 21px">
                <asp:Label ID="Label4" runat="server" Text="साक्षीको विवरण" SkinID="UnicodeHeadlbl" Width="219px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:Panel ID="pnlPersonnelInfo" runat="server" Height="700px" Width="900px">
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
                            &nbsp;</td>
                        <td colspan="2" valign="top">
                            </td>
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
                    <tr>
                        <td align="center" colspan="6" valign="top">
                            <asp:Label ID="Label15" runat="server" SkinID="UnicodeHeadlbl" Text="कागज-पत्रको विवरण"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="6" valign="top">
                            <table style="width: 619px">
                                <tr>
                                    <td style="width: 100px">
                                        <asp:Label ID="Label44" runat="server" SkinID="Unicodelbl" Text="कागज‍-पत्रको किसिम"
                                            Width="143px"></asp:Label></td>
                                    <td style="width: 100px">
                                        <asp:DropDownList ID="ddlDocumentType" runat="server" SkinID="Unicodeddl">
                                        </asp:DropDownList></td>
                                    <td style="width: 99px">
                                        <asp:Label ID="lblDocumentType" runat="server" SkinID="Unicodelbl" Text="कागज-पत्रको नं"></asp:Label></td>
                                    <td style="width: 100px">
                                        <asp:TextBox ID="txtDocNo" runat="server" MaxLength="20" SkinID="Unicodetxt"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 100px" valign="top">
                                        <asp:Label ID="Label47" runat="server" SkinID="Unicodelbl" Text="जारी गर्ने जल्ला"></asp:Label></td>
                                    <td style="width: 100px" valign="top">
                                        <asp:DropDownList ID="ddlIssuedFrom" runat="server" SkinID="Unicodeddl">
                                        </asp:DropDownList></td>
                                    <td style="width: 99px" valign="top">
                                        <asp:Label ID="Label45" runat="server" SkinID="Unicodelbl" Text="जारी गरेको मिति"
                                            Width="119px"></asp:Label></td>
                                    <td style="width: 100px">
                                        <asp:TextBox ID="txtIssuedDate" runat="server" Columns="11" SkinID="Unicodetxt"></asp:TextBox>
                                        <ajaxToolkit:MaskedEditExtender ID="medIssuedDate" runat="server" AutoComplete="False"
                                            Mask="9999/99/99" MaskType="Date" TargetControlID="txtIssuedDate">
                                        </ajaxToolkit:MaskedEditExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100px" valign="top">
                                        <asp:Label ID="Label46" runat="server" SkinID="Unicodelbl" Text="जारी गर्ने"></asp:Label></td>
                                    <td style="width: 100px" valign="top">
                                        <asp:TextBox ID="txtIssuedBy" runat="server" SkinID="Unicodetxt"></asp:TextBox></td>
                                    <td style="width: 99px" valign="top">
                                    </td>
                                    <td align="left" style="width: 100px">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 100px">
                                    </td>
                                    <td style="width: 100px">
                                    </td>
                                    <td style="width: 99px">
                                    </td>
                                    <td align="right" style="width: 100px">
                                        &nbsp;<asp:Button ID="btnAddPersonDocuments" runat="server" OnClick="btnAddPersonDocuments_Click"
                                            OnClientClick="return checkDupDocumentType();" SkinID="Add" Text="+" /></td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:GridView ID="grdPersonDoc" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                            ForeColor="#333333" GridLines="None" OnRowDataBound="grdPersonDoc_RowDataBound"
                                            OnRowDeleting="grdPersonDoc_RowDeleting" OnSelectedIndexChanged="grdPersonDoc_SelectedIndexChanged">
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="PID" HeaderText="PID" />
                                                <asp:BoundField DataField="DocTypeID" HeaderText="DocTypeID" />
                                                <asp:BoundField DataField="DocTypeName" HeaderText="कागज-पत्रको किसिम">
                                                    <HeaderStyle Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DocNumber" HeaderText="कागज-पत्रको नं">
                                                    <HeaderStyle Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="IssuedFrom" HeaderText="IssuedFrom">
                                                    <HeaderStyle Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="NepDistName" HeaderText="जारी गर्ने जिल्ला">
                                                    <HeaderStyle Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="IssuedOn" HeaderText="जारी मिति">
                                                    <HeaderStyle Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="IssuedBy" HeaderText="जारी गर्ने">
                                                    <HeaderStyle Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Active" HeaderText="सक्रिय" />
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
                                    <td style="width: 100px">
                                    </td>
                                    <td style="width: 100px">
                                    </td>
                                    <td style="width: 99px">
                                    </td>
                                    <td style="width: 100px">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <hr />
                            <asp:UpdatePanel id="UpdatePanel15" runat="server">
                                <contenttemplate>
<TABLE style="WIDTH: 650px"><TBODY><TR><TD style="HEIGHT: 2px" vAlign=top colSpan=6><asp:Label id="Label26" runat="server" Text="स्थायी ठेगाना" SkinID="Unicodelbl" Font-Bold="True" __designer:wfdid="w246"></asp:Label> </TD></TR><TR><TD style="WIDTH: 60px" vAlign=top><asp:Label id="Label82" runat="server" Width="50px" Height="19px" Text="जिल्ला" SkinID="Unicodelbl" __designer:wfdid="w247"></asp:Label> </TD><TD style="WIDTH: 170px" vAlign=top><asp:DropDownList id="ddlDistrict" runat="server" Width="150px" SkinID="Unicodeddl" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" __designer:wfdid="w248" AutoPostBack="True"></asp:DropDownList> </TD><TD style="WIDTH: 105px" vAlign=top><asp:Label id="Label84" runat="server" Width="95px" Height="19px" Text="गा.बि.स./न.पा." SkinID="Unicodelbl" __designer:wfdid="w249"></asp:Label> </TD><TD style="WIDTH: 170px" vAlign=top><asp:DropDownList id="ddlVDC" runat="server" Width="150px" SkinID="Unicodeddl" OnSelectedIndexChanged="ddlVDC_SelectedIndexChanged" __designer:wfdid="w250" AutoPostBack="True">
                                                                </asp:DropDownList> </TD><TD style="WIDTH: 60px" vAlign=top><asp:Label id="Label210" runat="server" Width="50px" Height="19px" Text="वडा नं." SkinID="Unicodelbl" __designer:wfdid="w251"></asp:Label> </TD><TD vAlign=top><asp:DropDownList id="ddlWard" runat="server" Width="70px" SkinID="Unicodeddl" OnSelectedIndexChanged="ddlWard_SelectedIndexChanged" __designer:wfdid="w252" AppendDataBoundItems="True">
                                                                </asp:DropDownList> </TD></TR><TR><TD style="WIDTH: 60px" vAlign=top><asp:Label id="Label83" runat="server" Height="19px" Text="टोल" SkinID="Unicodelbl" __designer:wfdid="w253"></asp:Label> </TD><TD style="WIDTH: 170px" vAlign=top><asp:TextBox id="txtTole" runat="server" Width="150px" SkinID="Unicodetxt" MaxLength="100" __designer:wfdid="w254" TextMode="MultiLine"></asp:TextBox></TD><TD style="WIDTH: 105px" vAlign=top><asp:ImageButton id="imgDelPerAddress" onclick="imgDelPerAddress_Click" runat="server" ImageUrl="~/MODULES/COMMON/Images/bycat1.ico" Visible="False" __designer:wfdid="w255" OnClientClick="return confirm('यो ठेगाना हटाउने हो ?')" AlternateText="Delete This Address"></asp:ImageButton></TD><TD style="WIDTH: 170px" vAlign=top><asp:TextBox id="txtPerAdd" runat="server" __designer:wfdid="w256"></asp:TextBox></TD><TD style="WIDTH: 60px" vAlign=top></TD><TD vAlign=top></TD></TR><TR><TD vAlign=top colSpan=6>
<HR />
</TD></TR></TBODY></TABLE><asp:HiddenField id="hdnPerAddress" runat="server" __designer:wfdid="w257"></asp:HiddenField> <asp:HiddenField id="hdnTempAddress" runat="server" __designer:wfdid="w258"></asp:HiddenField> <TABLE style="WIDTH: 650px"><TBODY><TR><TD style="HEIGHT: 21px" vAlign=top colSpan=6><asp:Label id="Label85" runat="server" Text="अस्थायी ठेगाना" SkinID="Unicodelbl" Font-Bold="True" __designer:wfdid="w259"></asp:Label></TD></TR><TR><TD style="WIDTH: 60px" vAlign=top><asp:Label id="Label86" runat="server" Width="50px" Height="19px" Text="जिल्ला" SkinID="Unicodelbl" __designer:wfdid="w260"></asp:Label></TD><TD style="WIDTH: 170px" vAlign=top><asp:DropDownList id="ddlDistrictTemp" runat="server" Width="150px" SkinID="Unicodeddl" OnSelectedIndexChanged="ddlDistrictTemp_SelectedIndexChanged" __designer:wfdid="w261" AutoPostBack="True">
                                                                </asp:DropDownList></TD><TD style="WIDTH: 105px" vAlign=top><asp:Label id="Label87" runat="server" Width="95px" Height="19px" Text="गा.बि.स./न.पा." SkinID="Unicodelbl" __designer:wfdid="w262"></asp:Label></TD><TD style="WIDTH: 170px" vAlign=top><asp:DropDownList id="ddlVDCTemp" runat="server" Width="150px" SkinID="Unicodeddl" OnSelectedIndexChanged="ddlVDCTemp_SelectedIndexChanged" __designer:wfdid="w263" AutoPostBack="True">
                                                                </asp:DropDownList></TD><TD style="WIDTH: 60px" vAlign=top><asp:Label id="Label88" runat="server" Width="50px" Height="19px" Text="वडा नं." SkinID="Unicodelbl" __designer:wfdid="w264"></asp:Label></TD><TD vAlign=top><asp:DropDownList id="ddlWardTemp" runat="server" Width="70px" SkinID="Unicodeddl" OnSelectedIndexChanged="ddlWardTemp_SelectedIndexChanged" __designer:wfdid="w265" AppendDataBoundItems="True">
                                                                </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 60px" vAlign=top><asp:Label id="Label89" runat="server" Height="19px" Text="टोल" SkinID="Unicodelbl" __designer:wfdid="w266"></asp:Label></TD><TD style="WIDTH: 170px" vAlign=top><asp:TextBox id="txtToleTemp" runat="server" Width="150px" SkinID="Unicodetxt" MaxLength="100" __designer:wfdid="w267" TextMode="MultiLine"></asp:TextBox></TD><TD style="WIDTH: 105px" vAlign=top><asp:ImageButton id="imgDelTempAddress" onclick="imgDelTempAddress_Click" runat="server" ImageUrl="~/MODULES/COMMON/Images/bycat1.ico" Visible="False" __designer:wfdid="w268" OnClientClick="return confirm('यो ठेगाना हटाउने हो ?')" AlternateText="Delete This Address"></asp:ImageButton></TD><TD style="WIDTH: 170px" vAlign=top><asp:TextBox id="txtTempAdd" runat="server" __designer:wfdid="w269"></asp:TextBox></TD><TD style="WIDTH: 60px" vAlign=top></TD><TD vAlign=top></TD></TR><TR><TD style="HEIGHT: 37px" vAlign=top colSpan=6>
<HR />
</TD></TR></TBODY></TABLE>
</contenttemplate>
                            </asp:UpdatePanel>
                            <asp:UpdatePanel id="UpdatePanel10" runat="server">
                                <contenttemplate>
<TABLE style="WIDTH: 650px"><TBODY><TR><TD vAlign=top colSpan=4><asp:Label id="Label211" runat="server" Width="105px" Height="19px" Text="फोन" SkinID="Unicodelbl" Font-Bold="True" __designer:wfdid="w270"></asp:Label></TD><TD style="WIDTH: 19px" vAlign=top colSpan=1></TD></TR><TR><TD style="WIDTH: 110px" vAlign=top><asp:Label id="Label212" runat="server" Width="105px" Height="19px" Text="फोनको किसिम" SkinID="Unicodelbl" __designer:wfdid="w271"></asp:Label> </TD><TD style="WIDTH: 150px" vAlign=top><asp:DropDownList id="ddlPhoneType_Phone" runat="server" Width="135px" SkinID="Unicodeddl" ToolTip="फोनको किसिम" __designer:wfdid="w272"><asp:ListItem Value="N">छान्नुहोस</asp:ListItem>
<asp:ListItem Value="M">मोबाईल</asp:ListItem>
<asp:ListItem Value="O">अफिस</asp:ListItem>
<asp:ListItem Value="R">घर</asp:ListItem>
<asp:ListItem Value="OT">अन्य</asp:ListItem>
</asp:DropDownList></TD><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Label213" runat="server" Width="55px" Height="19px" Text="फोन न." SkinID="Unicodelbl" __designer:wfdid="w273"></asp:Label> </TD><TD vAlign=top><asp:TextBox id="txtPhoneNumber_Phone" runat="server" Width="130px" SkinID="Unicodetxt" ToolTip="फोन नं" MaxLength="15" __designer:wfdid="w274"></asp:TextBox> <ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender1" runat="server" TargetControlID="txtPhoneNumber_Phone" __designer:wfdid="w275" FilterType="Numbers">
                                                                </ajaxToolkit:FilteredTextBoxExtender> </TD><TD style="WIDTH: 19px" vAlign=top><asp:Button id="btnPhonePlus" onclick="btnPhonePlus_Click" runat="server" Text="+" SkinID="Add" __designer:wfdid="w276" OnClientClick="javascript:return validateUpanelFields('_Phone',0);"></asp:Button></TD></TR><TR><TD vAlign=top colSpan=4><asp:GridView id="grdPhone" runat="server" SkinID="Unicodegrd" ForeColor="#333333" GridLines="None" CellPadding="4" AutoGenerateColumns="False" OnRowDeleting="grdPhone_RowDeleting" OnSelectedIndexChanged="grdPhone_SelectedIndexChanged" OnRowDataBound="grdPhone_RowDataBound" __designer:wfdid="w277">
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
                            </asp:UpdatePanel>
                            <asp:UpdatePanel id="UpdatePanel20" runat="server">
                                <contenttemplate>
<TABLE style="WIDTH: 650px"><TBODY><TR><TD vAlign=top colSpan=4><asp:Label id="LabelEmail" runat="server" Width="105px" Height="19px" Text="इमेल" SkinID="Unicodelbl" Font-Bold="True" __designer:wfdid="w278"></asp:Label></TD><TD vAlign=top colSpan=1></TD></TR><TR><TD style="WIDTH: 110px" vAlign=top><asp:Label id="Label23" runat="server" Width="105px" Height="19px" Text="ईमेलको किसिम" SkinID="Unicodelbl" __designer:wfdid="w279"></asp:Label></TD><TD style="WIDTH: 150px" vAlign=top><asp:DropDownList id="ddlEMailType_EMail" runat="server" Width="135px" SkinID="Unicodeddl" ToolTip="इमेलको किसिम" __designer:wfdid="w280"><asp:ListItem Value="N">छान्नुहोस</asp:ListItem>
<asp:ListItem Value="P">ब्यक्तिगत</asp:ListItem>
<asp:ListItem Value="O">अफिस</asp:ListItem>
<asp:ListItem Value="OT">अन्य</asp:ListItem>
</asp:DropDownList></TD><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Label24" runat="server" Width="90px" Height="19px" Text="ईमेल ठेगाना" SkinID="Unicodelbl" __designer:wfdid="w281"></asp:Label></TD><TD vAlign=top><asp:TextBox id="txtEMail_EMail" runat="server" Width="130px" SkinID="Unicodetxt" ToolTip="इमेल ठेगाना" MaxLength="50" __designer:wfdid="w282"></asp:TextBox></TD><TD vAlign=top><asp:Button id="btnEMailPlus" onclick="btnEMailPlus_Click" runat="server" Text="+" SkinID="Add" __designer:wfdid="w283" OnClientClick="javascript:return ValidateEmailFR();"></asp:Button></TD></TR><TR><TD vAlign=top colSpan=4><asp:GridView id="grdEMail" runat="server" SkinID="Unicodegrd" ForeColor="#333333" GridLines="None" CellPadding="4" AutoGenerateColumns="False" OnRowDeleting="grdEMail_RowDeleting" OnSelectedIndexChanged="grdEMail_SelectedIndexChanged" OnRowDataBound="grdEMail_RowDataBound" __designer:wfdid="w284">
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
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="width: 900px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100px">
                            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                            </td>
        </tr>
        <tr>
            <td style="width: 900px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100px">
                <table style="width: 250px">
                    <tr>
                        <td style="width: 50px">
                            <asp:Label ID="Label39" runat="server" SkinID="Unicodelbl" Text="अवधि देखि"
                                                            Width="86px" Visible="False"></asp:Label></td>
                        <td style="width: 50px">
                                                        <asp:TextBox ID="txtWitnessFromDate" runat="server" Columns="12" SkinID="Unicodetxt" Visible="False"></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender ID="medWitnessFromDate" runat="server" AutoComplete="False"
                                Mask="9999/99/99" MaskType="Date" TargetControlID="txtWitnessFromDate">
                            </ajaxToolkit:MaskedEditExtender>
                            &nbsp;
                        </td>
                        <td style="width: 60px">
                                                        <asp:Label ID="Label38" runat="server" SkinID="Unicodelbl" Text="अवधि सम्म" Width="82px" Visible="False"></asp:Label></td>
                        <td style="width: 100px">
                                                        <asp:TextBox ID="txtWitnessToDate" runat="server" Columns="12" SkinID="Unicodetxt" Visible="False"></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender ID="medWitnessToDate" runat="server" AutoComplete="False"
                                Mask="9999/99/99" MaskType="Date" TargetControlID="txtWitnessToDate">
                            </ajaxToolkit:MaskedEditExtender>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 900px">
                <hr />
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 26px;">
                <asp:Button ID="btnAddWitness" runat="server" OnClick="btnAddLawyer_Click" Text="+" SkinID="Add" />
                </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 183px;">
                &nbsp;&nbsp;
                <asp:GridView ID="grdLitigantWitness" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None" OnRowDataBound="grdLitigantWitness_RowDataBound" OnSelectedIndexChanged="grdLitigantWitness_SelectedIndexChanged" OnDataBound="grdLitigantWitness_DataBound" OnRowDeleted="grdLitigantWitness_RowDeleted" OnRowDeleting="grdLitigantWitness_RowDeleting" SkinID="MergedGrid">
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:BoundField DataField="CaseID" HeaderText="CaseID" />
                        <asp:BoundField DataField="AppOrResp" HeaderText="वादि /  प्रतिवादि" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="LitigantID" HeaderText="LitigantID" />
                        <asp:BoundField DataField="LitigantName" HeaderText="वादि / प्रतिवादिको नाम" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="WitnessID" HeaderText="WitnessID" />
                        <asp:BoundField DataField="WitnessName" HeaderText="साक्षीको नाम" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FromDate" HeaderText="अवधि देखि">
                            <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ToDate" HeaderText="अवधि सम्म">
                            <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Action" HeaderText="Action" />
                        <asp:CommandField SelectText="Edit" ShowSelectButton="True" />
                        <asp:CommandField ShowDeleteButton="True" />
                        <asp:BoundField DataField="PersonID" HeaderText="PersonID" />
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
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 21px;">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" style="width: 900px; height: 26px;">
                <table>
                    <tr>
                        <td style="width: 100px">
                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" SkinID="Cancel"
                                Text="Cancel" /></td>
                        <td style="width: 100px" align="left">
                <asp:Button ID="btnNext" runat="server" OnClick="btnNext_Click" SkinID="Normal" Text="Next" /></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    &nbsp;
</asp:Content>

