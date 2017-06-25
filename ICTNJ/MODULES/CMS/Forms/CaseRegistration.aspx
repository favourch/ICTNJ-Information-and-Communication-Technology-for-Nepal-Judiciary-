<%@ Page Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" AutoEventWireup="true" CodeFile="CaseRegistration.aspx.cs" Inherits="MODULES_CMS_Forms_CaseRegistration" Title="CMS | Case Registration 1 [Litigants, CheckList]" EnableEventValidation="false" %>

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
    
    <script type="text/javascript" language="javascript">
        function checkDupDocumentType()
        {
            var DocTypeIDGRD = document.getElementById('<%= this.grdPersonDoc.ClientID%>');
            var DocTypeIDFromDDL = document.getElementById('<%= this.ddlDocumentType.ClientID%>');
            for(var i = 1;i < DocTypeIDGRD.rows.length; i++)
            {
                var cell = DocTypeIDGRD.rows[i].cells[0];
                if(DocTypeIDFromDDL.options[DocTypeIDFromDDL.selectedIndex].text== cell.innerHTML)
                {
                    var result=confirm("Document Type Already Exists\n Do You Want to Add Another?");
                    return result;
                }
            }
        }

</script>



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
            <asp:UpdatePanel id="UpdatePanel7" runat="server">
                <contenttemplate>
            <asp:Panel runat="Server" ID="programmaticPopupDragHandle" Style="cursor: move;background-color:#DDDDDD;border:solid 1px Gray;color:Black;text-align:center;">
                Save Status
            </asp:Panel>
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
</contenttemplate>
                <triggers>
<asp:AsyncPostBackTrigger ControlID="btnAddPerson" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnAddOrganization" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
            </asp:UpdatePanel>
            <br />
<asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click" Width="58px" />           <br />
        </asp:Panel>
    <table>
        <tr>
            <td align="center" style="width: 950px">
                <asp:Label ID="Label37" runat="server" SkinID="UnicodeHeadlbl" Text="मुद्दाको विवरण"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 950px">
                <asp:UpdatePanel id="UpdatePanel12" runat="server">
                    <contenttemplate>
<TABLE><TBODY><TR><TD style="WIDTH: 100px"><asp:Label id="Label1" runat="server" Width="105px" Text="मुद्दाको किसिम" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 100px"><asp:DropDownList id="ddlCaseType_RQD" runat="server" Width="150px" SkinID="Unicodeddl" AutoPostBack="True" OnSelectedIndexChanged="ddlCaseType_RQD_SelectedIndexChanged" ToolTip="मद्दाको किसिम"></asp:DropDownList></TD><TD style="WIDTH: 100px"><asp:Label id="Label18" runat="server" Width="90px" Text="दर्ता किसिम" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 100px"><asp:DropDownList id="ddlOrgCaseRegType_RQD" runat="server" Width="150px" SkinID="Unicodeddl" AutoPostBack="True" OnSelectedIndexChanged="ddlOrgCaseRegType_RQD_SelectedIndexChanged" ToolTip="दर्ता किसिम"></asp:DropDownList></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 100px"><asp:Label id="Label3" runat="server" Width="87px" Text="दर्ता किताब" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 100px"><asp:DropDownList id="ddlRegistrationDiary_RQD" runat="server" Width="150px" SkinID="Unicodeddl" AutoPostBack="True" OnSelectedIndexChanged="ddlRegistrationDiary_RQD_SelectedIndexChanged" ToolTip="दर्ता किताब"></asp:DropDownList></TD><TD style="WIDTH: 100px"><asp:Label id="Label2" runat="server" Width="95px" Text="मुद्दाको विषय" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 100px"><asp:DropDownList id="ddlRegDiarySubject_RQD" runat="server" Width="150px" SkinID="Unicodeddl" AutoPostBack="True" OnSelectedIndexChanged="ddlRegDiarySubject_RQD_SelectedIndexChanged" ToolTip="मुद्दाको विषय"></asp:DropDownList></TD><TD style="WIDTH: 100px"><asp:Label id="Label4" runat="server" Width="85px" Text="मुद्दाको नाम" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 100px"><asp:DropDownList id="ddlRegDiaryName_RQD" runat="server" Width="150px" SkinID="Unicodeddl" ToolTip="मुद्दाको नाम"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Label42" runat="server" Text="दर्ता मिति" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 100px" vAlign=top><asp:TextBox id="txtCaseRegistrationDate_DT" runat="server" SkinID="Unicodetxt" ToolTip="दर्ता मिति" Columns="12"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="medCaseRegDate" runat="server" TargetControlID="txtCaseRegistrationDate_DT" AutoComplete="False" Mask="9999/99/99" MaskType="Date"></ajaxToolkit:MaskedEditExtender></TD><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Label43" runat="server" Width="131px" Text="अगाडि बढ्ने विधि" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 100px" vAlign=top><asp:DropDownList id="ddlCaseProceeding_RQD" runat="server" ToolTip="अगाडि बढ्ने विधि"></asp:DropDownList></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px" vAlign=top><asp:TextBox id="txtCaseNo" runat="server" Visible="False"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 41px" vAlign=top><asp:Label id="Label25" runat="server" Width="146px" Text="लेखा शाखामा पठाउने" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 41px" vAlign=top><asp:CheckBox id="chkForwardToAccount" runat="server" Width="186px" AutoPostBack="True" ToolTip="लेखा शाखामा पठाउने" OnCheckedChanged="chkForwardToAccount_CheckedChanged"></asp:CheckBox></TD><TD style="WIDTH: 100px; HEIGHT: 41px"></TD><TD style="WIDTH: 100px; HEIGHT: 41px"></TD><TD style="WIDTH: 100px; HEIGHT: 41px"><asp:Label id="lblIniUnit" runat="server" Text="3" __designer:dtid="3659174697238560" Visible="False" __designer:wfdid="w128"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 41px"><asp:Label id="lblIniType" runat="server" Text="9" __designer:dtid="3659174697238562" Visible="False" __designer:wfdid="w129"></asp:Label></TD></TR><TR><TD colSpan=6><asp:Panel id="pnlAccountForward" runat="server" Width="125px" Visible="False" __designer:wfdid="w1"><TABLE style="WIDTH: 642px"><TBODY><TR><TD style="WIDTH: 100px; HEIGHT: 21px"><asp:Label id="Label48" runat="server" Width="114px" Text="खाताको किसिम" SkinID="Unicodelbl" __designer:wfdid="w2"></asp:Label> </TD><TD style="WIDTH: 100px; HEIGHT: 21px"><asp:DropDownList id="ddlAccountType" runat="server" SkinID="Unicodeddl" __designer:wfdid="w2" ToolTip="खाताको किसिम"></asp:DropDownList></TD><TD style="WIDTH: 100px; HEIGHT: 21px"><asp:Label id="Label49" runat="server" Text="तिर्नु पर्ने रकम" SkinID="Unicodelbl" __designer:wfdid="w3"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 21px"><asp:TextBox id="txtAmount" runat="server" SkinID="Unicodetxt" __designer:wfdid="w4" ToolTip="तिर्नु पर्ने रकम"></asp:TextBox></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px" align=right></TD><TD style="WIDTH: 100px" align=left><asp:Button id="btnAddAmountToBePaid" onclick="btnAddAmountToBePaid_Click" runat="server" Text="+" SkinID="Add" __designer:wfdid="w5"></asp:Button></TD></TR><TR><TD colSpan=4><asp:GridView id="grdAccountFWD" runat="server" ForeColor="#333333" OnSelectedIndexChanged="grdAccountFWD_SelectedIndexChanged" __designer:wfdid="w7" OnRowDeleting="grdAccountFWD_RowDeleting" CellPadding="4" AutoGenerateColumns="False" GridLines="None">
<FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="AccountTypeID" HeaderText="AccountTypeID"></asp:BoundField>
<asp:BoundField DataField="AccountTypeName" HeaderText="खाताको किसिम"></asp:BoundField>
<asp:BoundField DataField="TotalAmount" HeaderText="तिर्नु पर्ने रकम"></asp:BoundField>
<asp:BoundField DataField="Action" HeaderText="Action"></asp:BoundField>
<asp:CommandField ShowSelectButton="True"></asp:CommandField>
<asp:CommandField ShowDeleteButton="True"></asp:CommandField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView></TD><TD colSpan=1></TD></TR></TBODY></TABLE></asp:Panel></TD></TR><TR><TD style="HEIGHT: 3px" align=left colSpan=6><asp:Panel id="pnlWrit" runat="server" Width="125px" Visible="False" __designer:wfdid="w2"><TABLE style="WIDTH: 913px"><TBODY><TR><TD align=center colSpan=4><asp:Label id="Label50" runat="server" Text="रिटको विवरण" SkinID="UnicodeHeadlbl" __designer:wfdid="w1"></asp:Label></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 22px"><asp:Label id="Label51" runat="server" Text="रिट विषय" SkinID="Unicodelbl" __designer:wfdid="w3"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 22px"><asp:DropDownList id="ddlWritSubject" runat="server" SkinID="Unicodeddl" AutoPostBack="True" OnSelectedIndexChanged="ddlWritSubject_SelectedIndexChanged" __designer:wfdid="w7"></asp:DropDownList>&nbsp;&nbsp; </TD><TD style="WIDTH: 100px; HEIGHT: 22px"><asp:Label id="Label52" runat="server" Text="रिट समूह" SkinID="Unicodelbl" __designer:wfdid="w3"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 22px"><asp:DropDownList id="ddlWritCategory" runat="server" SkinID="Unicodeddl" AutoPostBack="True" OnSelectedIndexChanged="ddlWritCategory_SelectedIndexChanged" __designer:wfdid="w8"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 100px"><asp:Label id="Label53" runat="server" Text="रिट शिर्षक" SkinID="Unicodelbl" __designer:wfdid="w3"></asp:Label></TD><TD style="WIDTH: 100px"><asp:DropDownList id="ddlWritTitle" runat="server" SkinID="Unicodeddl" AutoPostBack="True" OnSelectedIndexChanged="ddlWritTitle_SelectedIndexChanged" __designer:wfdid="w9"></asp:DropDownList></TD><TD style="WIDTH: 100px"><asp:Label id="Label54" runat="server" Text="रिट उप-शिर्षक" SkinID="Unicodelbl" __designer:wfdid="w3"></asp:Label></TD><TD style="WIDTH: 100px"><asp:DropDownList id="ddlWritSubTitle" runat="server" SkinID="Unicodeddl" __designer:wfdid="w10"></asp:DropDownList></TD></TR></TBODY></TABLE></asp:Panel></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 3px"></TD><TD style="WIDTH: 100px; HEIGHT: 3px"></TD><TD style="WIDTH: 100px; HEIGHT: 3px"></TD><TD style="WIDTH: 100px; HEIGHT: 3px"></TD><TD style="WIDTH: 100px; HEIGHT: 3px"></TD><TD style="WIDTH: 100px; HEIGHT: 3px"></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 3px"></TD><TD style="WIDTH: 100px; HEIGHT: 3px"></TD><TD style="WIDTH: 100px; HEIGHT: 3px"></TD><TD style="WIDTH: 100px; HEIGHT: 3px"></TD><TD style="WIDTH: 100px; HEIGHT: 3px"></TD><TD style="WIDTH: 100px; HEIGHT: 3px"></TD></TR></TBODY></TABLE>
</contenttemplate>
                </asp:UpdatePanel>
    <hr />
    </td>
        </tr>
    </table>
    <table style="width: 928px">
        <tr>
            <td style="width: 100px">
            
            
             <asp:Panel ID="pnlPersonSearch1" runat="server" CssClass="collapsePanelHeader" Height="25px"
        Width="950px">
        वादि / प्रतिवादि खोज्नहोस
        <asp:ImageButton ID="ImageButton2" runat="server" Height="25px" ImageAlign="Right"
            ImageUrl="~/MODULES/COMMON/Images/expand.jpg" Visible="False" />
    </asp:Panel>
    <ajaxToolkit:CollapsiblePanelExtender ID="colPersonSearch" runat="server" CollapseControlID="pnlPersonSearch1"
        Collapsed="True" CollapsedImage="../../COMMON/Images/expand_blue.jpg" ExpandControlID="pnlPersonSearch1"
        ExpandedImage="../../COMMON/Images/collapse_blue.jpg" ImageControlID="imgCol"
        SkinID="CollapsiblePanelDemo" SuppressPostBack="True" TargetControlID="pnlPersonContent">
    </ajaxToolkit:CollapsiblePanelExtender>
    <asp:Panel ID="pnlPersonContent" runat="server" CssClass="collapsePanel" Width="950px">
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
                    <asp:Label ID="lblSearchx" runat="server" Text="Label"></asp:Label>&nbsp;&nbsp;&nbsp;
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
            <td style="width: 100px">
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td style="width: 100px">
                <asp:UpdatePanel id="UpdatePanel1" runat="server">
                    <contenttemplate>
<TABLE><TBODY><TR><TD><asp:Panel id="colPnlAppOrResp" runat="server" CssClass="collapsePanelHeader" Width="950px" Height="25px">वादि / प्रतिवादि<asp:ImageButton ID="imgCol" runat="server" Height="25px" ImageAlign="Right" ImageUrl="~/MODULES/COMMON/Images/expand.jpg" Visible="False" />
                                    </asp:Panel> <asp:Panel id="pnlAppResp" runat="server" CssClass="collapsePanel" Width="950px" Height="50px"><TABLE><TBODY><TR><TD style="WIDTH: 110px" vAlign=top><asp:Label id="Label16" runat="server" Width="105px" Text="वादि / प्रतिवादि" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 350px" vAlign=top>&nbsp;<asp:DropDownList id="ddlAppOrResp" runat="server" Width="150px" SkinID="Unicodeddl">
                                    <asp:ListItem Value="0">छान्नुहोस</asp:ListItem>
                                    <asp:ListItem Value="A">वादि</asp:ListItem>
                                    <asp:ListItem Value="R">प्रतिवादि</asp:ListItem>
                                </asp:DropDownList></TD><TD style="WIDTH: 120px" vAlign=top><asp:Label id="Label17" runat="server" Width="155px" Text="वादि / प्रतिवादि किसिम" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 400px" vAlign=top>&nbsp;<asp:DropDownList id="ddlOrgOrPerson" runat="server" Width="150px" SkinID="Unicodeddl" OnSelectedIndexChanged="ddlOrgOrPerson_SelectedIndexChanged" AutoPostBack="True">
                                    <asp:ListItem Value="OT">छान्नुहोस</asp:ListItem>
                                    <asp:ListItem Value="P">व्यक्ति</asp:ListItem>
                                    <asp:ListItem Value="O">संस्था</asp:ListItem>
                                </asp:DropDownList></TD></TR></TBODY></TABLE><TABLE style="WIDTH: 950px"><TBODY><TR><TD style="WIDTH: 950px" colSpan=4><asp:Panel id="pnlPerson" runat="server" Width="950px" Visible="False"><TABLE style="WIDTH: 950px"><TBODY><TR><TD vAlign=top colSpan=6><asp:Label id="lblPersonnelInfo" runat="server" Text="वैयक्तिक विवरण" SkinID="UnicodeHeadlbl" Font-Bold="True"></asp:Label></TD></TR><TR><TD vAlign=top colSpan=6><asp:UpdatePanel id="UpdatePanel6" runat="server"><ContentTemplate>
<TABLE style="WIDTH: 950px"><TBODY><TR><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Label21" runat="server" Width="90px" Height="22px" Text="पहिलो नाम" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 100px" vAlign=top><asp:TextBox id="txtFName" runat="server" Width="130px" SkinID="Unicodetxt" ToolTip="पहिलो नाम" MaxLength="35"></asp:TextBox></TD><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Label22" runat="server" Height="22px" Text="बिचको नाम" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 100px" vAlign=top><asp:TextBox id="txtMName" runat="server" Width="130px" SkinID="Unicodetxt" MaxLength="15"></asp:TextBox></TD><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Label200" runat="server" Width="110px" Height="22px" Text="थर" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 100px" vAlign=top><asp:TextBox id="txtSurName" runat="server" Width="130px" SkinID="Unicodetxt" ToolTip="थर" MaxLength="35"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Labe201" runat="server" Width="90px" Height="22px" Text="जन्म मिति" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 100px" vAlign=top><asp:TextBox id="txtDOB" runat="server" Width="130px" SkinID="Unicodetxt" ToolTip="जन्म मिति" MaxLength="10"></asp:TextBox><ajaxToolkit:MaskedEditExtender id="MaskedEditExtender1" runat="server" TargetControlID="txtDOB" MaskType="Date" Mask="9999/99/99" AutoComplete="False" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True"></ajaxToolkit:MaskedEditExtender></TD><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Labe202" runat="server" Height="22px" Text="लिंग" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 100px" vAlign=top><asp:DropDownList id="ddlGender" runat="server" Width="135px" SkinID="Unicodeddl">
                                                    <asp:ListItem Value="SG">छान्नुहोस</asp:ListItem>
                                                    <asp:ListItem Value="M">पुरुष</asp:ListItem>
                                                    <asp:ListItem Value="F">महिला</asp:ListItem>
                                                    <asp:ListItem Value="O">अन्य</asp:ListItem>
                                                </asp:DropDownList></TD><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Labe203" runat="server" Width="115px" Height="22px" Text="बैबाहिक सम्बन्ध" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 100px" vAlign=top><asp:DropDownList id="ddlMarStatus" runat="server" Width="135px" SkinID="Unicodeddl"><asp:ListItem Value="SMS">छान्नुहोस</asp:ListItem>
<asp:ListItem Value="S">अबिबाहित</asp:ListItem>
<asp:ListItem Value="M">बिबाहित</asp:ListItem>
<asp:ListItem Value="W">बिधवा/बिदुर</asp:ListItem>
<asp:ListItem Value="D">छोडपत्र</asp:ListItem>
<asp:ListItem Value="O">अन्य</asp:ListItem>
</asp:DropDownList></TD></TR><TR><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Labe204" runat="server" Width="90px" Height="22px" Text="देश" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 100px" vAlign=top><asp:DropDownList id="ddlCountry" runat="server" Width="135px" SkinID="Unicodeddl">
                                                </asp:DropDownList></TD><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Labe205" runat="server" Width="120px" Height="22px" Text="घर भएको जिल्ला" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 100px" vAlign=top><asp:DropDownList id="ddlBirthDistrict" runat="server" Width="135px" SkinID="Unicodeddl">
                                                </asp:DropDownList></TD><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Labe206" runat="server" Width="110px" Height="22px" Text="धर्म" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 100px" vAlign=top><asp:DropDownList id="ddlReligion" runat="server" Width="135px" SkinID="Unicodeddl">
                                                </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Label29" runat="server" Width="90px" Text="हुलिया" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 100px" vAlign=top><asp:TextBox id="txtIdentityMark" runat="server" Width="130px" SkinID="Unicodetxt" MaxLength="30"></asp:TextBox></TD><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Label20" runat="server" Text="देखाउने नाम" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 100px" vAlign=top><asp:TextBox id="txtDisplayName" runat="server" Width="154px"></asp:TextBox></TD><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Label41" runat="server" Text="अवस्था" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 100px" vAlign=top><asp:DropDownList id="ddlLitigantSubType" runat="server" SkinID="Unicodeddl"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 24px" vAlign=top></TD><TD style="WIDTH: 100px; HEIGHT: 24px" vAlign=top></TD><TD style="WIDTH: 100px; HEIGHT: 24px" vAlign=top></TD><TD style="HEIGHT: 24px" vAlign=top colSpan=2></TD><TD style="WIDTH: 100px; HEIGHT: 24px" vAlign=top><asp:TextBox id="txtPersonID" runat="server" Width="67px" Visible="False"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 100px" vAlign=top>&nbsp;</TD><TD style="WIDTH: 100px" vAlign=top></TD><TD style="WIDTH: 100px" vAlign=top>&nbsp;</TD><TD vAlign=top colSpan=2>&nbsp;</TD><TD style="WIDTH: 100px" vAlign=top></TD></TR></TBODY></TABLE>
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="btnAddPerson" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnAddOrganization" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="grdAppellant" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</Triggers>
</asp:UpdatePanel></TD></TR></TBODY></TABLE><TABLE style="WIDTH: 950px"><TBODY><TR><TD style="WIDTH: 905px; HEIGHT: 512px" vAlign=top><ajaxToolkit:TabContainer id="tbContLitInfo" runat="server" CssClass="ajax_tab_theme" ActiveTabIndex="3"><ajaxToolkit:TabPanel runat="server" ID="tbPnlContact" HeaderText="TabPanel1"><ContentTemplate>
<asp:UpdatePanel id="UpdatePanel15" runat="server"><ContentTemplate>
<TABLE style="WIDTH: 675px"><TBODY><TR><TD style="HEIGHT: 2px" vAlign=top colSpan=6><asp:Label id="Label26" runat="server" Text="स्थायी ठेगाना" SkinID="Unicodelbl" Font-Bold="True"></asp:Label> </TD></TR><TR><TD style="WIDTH: 60px" vAlign=top><asp:Label id="Label82" runat="server" Width="50px" Height="19px" Text="जिल्ला" SkinID="Unicodelbl"></asp:Label> </TD><TD style="WIDTH: 170px" vAlign=top><asp:DropDownList id="ddlDistrict" runat="server" Width="150px" SkinID="Unicodeddl" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"></asp:DropDownList> </TD><TD style="WIDTH: 105px" vAlign=top><asp:Label id="Label84" runat="server" Width="95px" Height="19px" Text="गा.बि.स./न.पा." SkinID="Unicodelbl"></asp:Label> </TD><TD style="WIDTH: 170px" vAlign=top><asp:DropDownList id="ddlVDC" runat="server" Width="150px" SkinID="Unicodeddl" AutoPostBack="True" OnSelectedIndexChanged="ddlVDC_SelectedIndexChanged">
                                                                </asp:DropDownList> </TD><TD style="WIDTH: 60px" vAlign=top><asp:Label id="Label210" runat="server" Width="50px" Height="19px" Text="वडा नं." SkinID="Unicodelbl"></asp:Label> </TD><TD vAlign=top><asp:DropDownList id="ddlWard" runat="server" Width="70px" SkinID="Unicodeddl" OnSelectedIndexChanged="ddlWard_SelectedIndexChanged" AppendDataBoundItems="True">
                                                                </asp:DropDownList> </TD></TR><TR><TD style="WIDTH: 60px" vAlign=top><asp:Label id="Label83" runat="server" Height="19px" Text="टोल" SkinID="Unicodelbl"></asp:Label> </TD><TD style="WIDTH: 170px" vAlign=top><asp:TextBox id="txtTole" runat="server" Width="150px" SkinID="Unicodetxt" MaxLength="100" TextMode="MultiLine"></asp:TextBox></TD><TD style="WIDTH: 105px" vAlign=top><asp:ImageButton id="imgDelPerAddress" onclick="imgDelPerAddress_Click" runat="server" ImageUrl="~/MODULES/COMMON/Images/bycat1.ico" Visible="False" OnClientClick="return confirm('यो ठेगाना हटाउने हो ?')" AlternateText="Delete This Address"></asp:ImageButton></TD><TD style="WIDTH: 170px" vAlign=top><asp:TextBox id="txtPerAdd" runat="server" Visible="False"></asp:TextBox></TD><TD style="WIDTH: 60px" vAlign=top></TD><TD vAlign=top></TD></TR><TR><TD vAlign=top colSpan=6>
<HR />
</TD></TR></TBODY></TABLE><asp:HiddenField id="hdnPerAddress" runat="server"></asp:HiddenField> <asp:HiddenField id="hdnTempAddress" runat="server"></asp:HiddenField> <TABLE style="WIDTH: 650px"><TBODY><TR><TD style="HEIGHT: 21px" vAlign=top colSpan=6><asp:Label id="Label85" runat="server" Text="अस्थायी ठेगाना" SkinID="Unicodelbl" Font-Bold="True"></asp:Label></TD></TR><TR><TD style="WIDTH: 60px" vAlign=top><asp:Label id="Label86" runat="server" Width="50px" Height="19px" Text="जिल्ला" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 170px" vAlign=top><asp:DropDownList id="ddlDistrictTemp" runat="server" Width="150px" SkinID="Unicodeddl" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrictTemp_SelectedIndexChanged">
                                                                </asp:DropDownList></TD><TD style="WIDTH: 105px" vAlign=top><asp:Label id="Label87" runat="server" Width="95px" Height="19px" Text="गा.बि.स./न.पा." SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 170px" vAlign=top><asp:DropDownList id="ddlVDCTemp" runat="server" Width="150px" SkinID="Unicodeddl" AutoPostBack="True" OnSelectedIndexChanged="ddlVDCTemp_SelectedIndexChanged">
                                                                </asp:DropDownList></TD><TD style="WIDTH: 60px" vAlign=top><asp:Label id="Label88" runat="server" Width="50px" Height="19px" Text="वडा नं." SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:DropDownList id="ddlWardTemp" runat="server" Width="70px" SkinID="Unicodeddl" OnSelectedIndexChanged="ddlWardTemp_SelectedIndexChanged" AppendDataBoundItems="True">
                                                                </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 60px" vAlign=top><asp:Label id="Label89" runat="server" Height="19px" Text="टोल" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 170px" vAlign=top><asp:TextBox id="txtToleTemp" runat="server" Width="150px" SkinID="Unicodetxt" MaxLength="100" TextMode="MultiLine"></asp:TextBox></TD><TD style="WIDTH: 105px" vAlign=top><asp:ImageButton id="imgDelTempAddress" onclick="imgDelTempAddress_Click" runat="server" ImageUrl="~/MODULES/COMMON/Images/bycat1.ico" Visible="False" OnClientClick="return confirm('यो ठेगाना हटाउने हो ?')" AlternateText="Delete This Address"></asp:ImageButton></TD><TD style="WIDTH: 170px" vAlign=top><asp:TextBox id="txttempAdd" runat="server" Visible="False"></asp:TextBox></TD><TD style="WIDTH: 60px" vAlign=top></TD><TD vAlign=top></TD></TR><TR><TD vAlign=top colSpan=6>
<HR />
</TD></TR></TBODY></TABLE>
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="btnAddPerson" EventName="Click"></asp:AsyncPostBackTrigger>
</Triggers>
</asp:UpdatePanel> <asp:UpdatePanel id="UpdatePanel10" runat="server"><ContentTemplate>
<TABLE style="WIDTH: 650px"><TBODY><TR><TD vAlign=top colSpan=4><asp:Label id="Label211" runat="server" Width="105px" Height="19px" Text="फोन" SkinID="Unicodelbl" Font-Bold="True"></asp:Label></TD><TD style="WIDTH: 19px" vAlign=top colSpan=1></TD></TR><TR><TD style="WIDTH: 110px" vAlign=top><asp:Label id="Label212" runat="server" Width="105px" Height="19px" Text="फोनको किसिम" SkinID="Unicodelbl"></asp:Label> </TD><TD style="WIDTH: 150px" vAlign=top><asp:DropDownList id="ddlPhoneType_Phone" runat="server" Width="135px" SkinID="Unicodeddl" OnSelectedIndexChanged="ddlPhoneType_Phone_SelectedIndexChanged1" ToolTip="फोनको किसिम"><asp:ListItem Value="N">छान्नुहोस</asp:ListItem>
<asp:ListItem Value="M">मोबाईल</asp:ListItem>
<asp:ListItem Value="O">अफिस</asp:ListItem>
<asp:ListItem Value="R">घर</asp:ListItem>
<asp:ListItem Value="OT">अन्य</asp:ListItem>
</asp:DropDownList></TD><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Label213" runat="server" Width="55px" Height="19px" Text="फोन न." SkinID="Unicodelbl"></asp:Label> </TD><TD vAlign=top><asp:TextBox id="txtPhoneNumber_Phone" runat="server" Width="130px" SkinID="Unicodetxt" ToolTip="फोन नं" MaxLength="15"></asp:TextBox> <ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender1" runat="server" TargetControlID="txtPhoneNumber_Phone" FilterType="Numbers">
                                                                </ajaxToolkit:FilteredTextBoxExtender> </TD><TD style="WIDTH: 19px" vAlign=top><asp:Button id="btnPhonePlus" onclick="btnPhonePlus_Click" runat="server" Text="+" SkinID="Add" OnClientClick="javascript:return validateUpanelFields('_Phone',0);"></asp:Button></TD></TR><TR><TD vAlign=top colSpan=4><asp:GridView id="grdPhone" runat="server" SkinID="Unicodegrd" ForeColor="#333333" OnSelectedIndexChanged="grdPhone_SelectedIndexChanged" OnRowDataBound="grdPhone_RowDataBound" AutoGenerateColumns="False" CellPadding="4" GridLines="None" OnRowDeleting="grdPhone_RowDeleting">
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
</ContentTemplate>
</asp:UpdatePanel> <asp:UpdatePanel id="UpdatePanel20" runat="server"><ContentTemplate>
<TABLE style="WIDTH: 650px"><TBODY><TR><TD vAlign=top colSpan=4><asp:Label id="LabelEmail" runat="server" Width="105px" Height="19px" Text="इमेल" SkinID="Unicodelbl" Font-Bold="True"></asp:Label></TD><TD vAlign=top colSpan=1></TD></TR><TR><TD style="WIDTH: 110px" vAlign=top><asp:Label id="Label23" runat="server" Width="105px" Height="19px" Text="ईमेलको किसिम" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 150px" vAlign=top><asp:DropDownList id="ddlEMailType_EMail" runat="server" Width="135px" SkinID="Unicodeddl" ToolTip="इमेलको किसिम"><asp:ListItem Value="N">छान्नुहोस</asp:ListItem>
<asp:ListItem Value="P">ब्यक्तिगत</asp:ListItem>
<asp:ListItem Value="O">अफिस</asp:ListItem>
<asp:ListItem Value="OT">अन्य</asp:ListItem>
</asp:DropDownList></TD><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Label24" runat="server" Width="90px" Height="19px" Text="ईमेल ठेगाना" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:TextBox id="txtEMail_EMail" runat="server" Width="130px" SkinID="Unicodetxt" ToolTip="इमेल ठेगाना" MaxLength="50"></asp:TextBox></TD><TD vAlign=top><asp:Button id="btnEMailPlus" onclick="btnEMailPlus_Click" runat="server" Text="+" SkinID="Add" OnClientClick="javascript:return ValidateEmailFR();"></asp:Button></TD></TR><TR><TD vAlign=top colSpan=4><asp:GridView id="grdEMail" runat="server" SkinID="Unicodegrd" ForeColor="#333333" OnSelectedIndexChanged="grdEMail_SelectedIndexChanged" OnRowDataBound="grdEMail_RowDataBound" AutoGenerateColumns="False" CellPadding="4" GridLines="None" OnRowDeleting="grdEMail_RowDeleting">
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
<HR />
</ContentTemplate>
</asp:UpdatePanel> 
</ContentTemplate>
<HeaderTemplate>
                                                            सम्पर्क
                                                        
</HeaderTemplate>
</ajaxToolkit:TabPanel>
<ajaxToolkit:TabPanel runat="server" ID="tbPnlRelatives" HeaderText="TabPanel2"><ContentTemplate>
<asp:UpdatePanel id="UpdatePanel2" runat="server"><ContentTemplate>
<TABLE style="WIDTH: 950px"><TBODY><TR><TD style="WIDTH: 125px" vAlign=top><asp:Label id="Label79" runat="server" Text="पहिलो नाम" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 198px" vAlign=top><asp:TextBox id="txtRelationFirstName_Relative" runat="server" Width="145px" SkinID="Unicodetxt" ToolTip="पहिलो नाम"></asp:TextBox></TD><TD style="WIDTH: 85px" vAlign=top><asp:Label id="Label80" runat="server" Width="80px" Text="बिचको नाम" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 199px" vAlign=top><asp:TextBox id="txtRelationMName" runat="server" Width="145px" SkinID="Unicodetxt"></asp:TextBox></TD><TD style="WIDTH: 115px" vAlign=top><asp:Label id="Label81" runat="server" Text="थर" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:TextBox id="txtRelationLastName_Relative" runat="server" Width="145px" SkinID="Unicodetxt" ToolTip="थर"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 125px" vAlign=top><asp:Label id="Label90" runat="server" Text="लिंग" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 198px" vAlign=top><asp:DropDownList id="ddlRelationGender" runat="server" Width="150px" SkinID="Unicodeddl"><asp:ListItem Value="SG">छान्नुहोस</asp:ListItem>
<asp:ListItem Value="M">पुरुष</asp:ListItem>
<asp:ListItem Value="F">महिला</asp:ListItem>
<asp:ListItem Value="O">अन्य</asp:ListItem>
</asp:DropDownList></TD><TD style="WIDTH: 85px" vAlign=top><asp:Label id="Label91" runat="server" Width="75px" Text="जन्म मिति" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 199px" vAlign=top><asp:TextBox id="txtRelationDOB_DTRelative" runat="server" Width="145px" SkinID="Unicodetxt" ToolTip="जन्म मिति"></asp:TextBox><ajaxToolkit:MaskedEditExtender id="MaskedEditExtender11" runat="server" TargetControlID="txtRelationDOB_DTRelative" Mask="9999/99/99" AutoComplete="False" MaskType="Date">
                                                                </ajaxToolkit:MaskedEditExtender></TD><TD style="WIDTH: 115px" vAlign=top><asp:Label id="Label92" runat="server" Width="110px" Text="बैबाहिक सम्बन्ध" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:DropDownList id="ddlRelationMarStatus" runat="server" Width="150px" SkinID="Unicodeddl"><asp:ListItem Value="SMS">छान्नुहोस</asp:ListItem>
<asp:ListItem Value="S">अबिबाहित</asp:ListItem>
<asp:ListItem Value="M">बिबाहित</asp:ListItem>
<asp:ListItem Value="W">बिधवा/बिदुर</asp:ListItem>
<asp:ListItem Value="D">छोडपत्र</asp:ListItem>
<asp:ListItem Value="O">अन्य</asp:ListItem>
</asp:DropDownList></TD></TR><TR><TD style="WIDTH: 125px" vAlign=top><asp:Label id="Label93" runat="server" Width="120px" Text="घर भएको जिल्ला" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 198px" vAlign=top><asp:DropDownList id="ddlRelationHomeDistrict" runat="server" Width="150px" SkinID="Unicodeddl"></asp:DropDownList></TD><TD style="WIDTH: 85px" vAlign=top><asp:Label id="Label94" runat="server" Width="52px" Text="सम्बन्ध" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 199px" vAlign=top><asp:DropDownList id="ddlRelationType_Relative" runat="server" Width="150px" SkinID="Unicodeddl" ToolTip="सम्बन्ध"></asp:DropDownList></TD><TD style="WIDTH: 115px" vAlign=top><asp:Label id="Label95" runat="server" Text="पेशा" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:TextBox id="txtRelativeOcc" runat="server" Width="145px" SkinID="Unicodetxt"></asp:TextBox></TD></TR><TR><TD style="HEIGHT: 45px" vAlign=top colSpan=4><asp:Button id="btnAddRelatives" onclick="btnAddRelatives_Click" runat="server" Text="+" SkinID="Add" OnClientClick="javascript:return validateUpanelFields('_Relative','Relative');"></asp:Button><asp:Button id="btnClearRelatives" onclick="btnClearRelatives_Click" runat="server" Text="Clear" SkinID="Cancel"></asp:Button></TD><TD style="WIDTH: 115px; HEIGHT: 45px" vAlign=top></TD><TD style="HEIGHT: 45px" vAlign=top><asp:HiddenField id="hdnRelativeID" runat="server"></asp:HiddenField></TD></TR></TBODY></TABLE><TABLE style="WIDTH: 950px"><TBODY><TR><TD vAlign=top><asp:Panel id="Panel1" runat="server" Width="890px" Height="100px" ScrollBars="Auto"><asp:GridView id="grdRelatives" runat="server" Width="850px" Height="202px" SkinID="Unicodegrd" ForeColor="#333333" AutoGenerateColumns="False" CellPadding="4" GridLines="None" OnRowDataBound="grdRelatives_RowDataBound">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="PID" HeaderText="आईडि"></asp:BoundField>
<asp:BoundField DataField="RELATIVEID" HeaderText="ना.आईडी"></asp:BoundField>
<asp:BoundField DataField="FIRSTNAME" HeaderText="पहिलो नाम"></asp:BoundField>
<asp:BoundField DataField="MIDNAME" HeaderText="बिचको नाम"></asp:BoundField>
<asp:BoundField DataField="SURNAME" HeaderText="थर"></asp:BoundField>
<asp:BoundField DataField="RDFULLNAME" HeaderText="पुरा नाम थर">
<ItemStyle Wrap="False"></ItemStyle>

<HeaderStyle Wrap="False"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="GENDER" HeaderText="लि.आईडि"></asp:BoundField>
<asp:BoundField DataField="RDGENDER" HeaderText="लिंग"></asp:BoundField>
<asp:BoundField DataField="DOB" HeaderText="जन्म मिति"></asp:BoundField>
<asp:BoundField DataField="MARITALSTATUS" HeaderText="बैबाहिक"></asp:BoundField>
<asp:BoundField DataField="RDMARITALSTATUS" HeaderText="बैबाहिक सम्बन्ध"></asp:BoundField>
<asp:BoundField DataField="BIRTHDISTRICT" HeaderText="घर"></asp:BoundField>
<asp:BoundField DataField="NEPDISTNAME" HeaderText="घर जिल्ला"></asp:BoundField>
<asp:BoundField DataField="RELATIONTYPEID" HeaderText="सम्बन्ध"></asp:BoundField>
<asp:BoundField DataField="RELATIONTYPENAME" HeaderText="सम्बन्ध"></asp:BoundField>
<asp:BoundField DataField="OCCUPATION" HeaderText="पेशा"></asp:BoundField>
<asp:TemplateField HeaderText="सक्रिय">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
<ItemTemplate>
                                                                                    <asp:CheckBox ID="chkRelativeActive" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "ISACTIVE").ToString() == "True" %>'  />
                                                                                
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="ACTION" HeaderText="Action"></asp:BoundField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView></asp:Panel></TD></TR></TBODY></TABLE><BR />
</ContentTemplate>
</asp:UpdatePanel> 
</ContentTemplate>
<HeaderTemplate>
                                                            नातेदार
                                                        
</HeaderTemplate>
</ajaxToolkit:TabPanel>
<ajaxToolkit:TabPanel runat="server" ID="TabPanel1" HeaderText="TabPanel1"><ContentTemplate>
&nbsp;<asp:UpdatePanel id="UpdatePanel8" runat="server"><ContentTemplate>
<TABLE style="WIDTH: 916px"><TBODY><TR><TD><asp:Label id="Label19" runat="server" Text="थुनुवा" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 100px"><asp:CheckBox id="chkIsPrisoned" runat="server" AutoPostBack="True" OnCheckedChanged="chkIsPrisoned_CheckedChanged"></asp:CheckBox></TD><TD style="WIDTH: 100px"><asp:Label id="lblAddEditPrisionDet" runat="server"></asp:Label></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD colSpan=4><asp:Panel id="pnlPrisonDetails" runat="server" Width="125px" Height="50px"><TABLE style="WIDTH: 711px"><TBODY><TR><TD style="WIDTH: 100px"><asp:Label id="Label39" runat="server" Width="86px" Text="अवधि देखि" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 100px"><asp:TextBox id="txtPrisonedFromDate" runat="server" Columns="12"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="medPrisonedFromDate" runat="server" TargetControlID="txtPrisonedFromDate" Mask="9999/99/99" ClearMaskOnLostFocus="False" AutoComplete="False" MaskType="Date" Enabled="True" CultureTimePlaceholder="" CultureThousandsPlaceholder="" CultureDecimalPlaceholder="" CultureDatePlaceholder="" CultureDateFormat="" CultureCurrencySymbolPlaceholder="" CultureAMPMPlaceholder="" UserDateFormat="DayMonthYear">
                                                                                        </ajaxToolkit:MaskedEditExtender></TD><TD style="WIDTH: 100px"><asp:Label id="Label38" runat="server" Width="82px" Text="अवधि सम्म" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 100px"><asp:TextBox id="txtPrisonedToDate" runat="server" Columns="12"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="medPrisonedToDate" runat="server" TargetControlID="txtPrisonedToDate" Mask="9999/99/99" ClearMaskOnLostFocus="False" AutoComplete="False" Enabled="True" CultureTimePlaceholder="" CultureThousandsPlaceholder="" CultureDecimalPlaceholder="" CultureDatePlaceholder="" CultureDateFormat="" CultureCurrencySymbolPlaceholder="" CultureAMPMPlaceholder="">
                                                                                        </ajaxToolkit:MaskedEditExtender></TD></TR><TR><TD style="WIDTH: 100px"><asp:Label id="Label40" runat="server" Width="109px" Text="थानाको विवरण" SkinID="Unicodelbl"></asp:Label></TD><TD colSpan=3><asp:TextBox id="txtPrisonDescription" runat="server" Width="781px" SkinID="Unicodetxt" Columns="52" MaxLength="50"></asp:TextBox></TD></TR></TBODY></TABLE></asp:Panel>&nbsp;&nbsp; </TD></TR></TBODY></TABLE>
</ContentTemplate>
</asp:UpdatePanel> <BR /><BR /><BR /><BR /><BR /><BR /><BR /><BR /><BR /><BR />
</ContentTemplate>
<HeaderTemplate>
                                                            थुनुवा
                                                        
</HeaderTemplate>
</ajaxToolkit:TabPanel>
<ajaxToolkit:TabPanel runat="server" ID="TabPanel2" HeaderText="TabPanel2"><ContentTemplate>
<TABLE style="WIDTH: 619px"><TBODY><TR><TD style="WIDTH: 100px"><asp:Label id="Label44" runat="server" Width="143px" Text="कागज‍-पत्रको किसिम" SkinID="Unicodelbl" __designer:wfdid="w8"></asp:Label> </TD><TD style="WIDTH: 100px"><asp:DropDownList id="ddlDocumentType" runat="server" SkinID="Unicodeddl" __designer:wfdid="w9"></asp:DropDownList> </TD><TD style="WIDTH: 99px"><asp:Label id="lblDocumentType" runat="server" Text="कागज-पत्रको नं" SkinID="Unicodelbl" __designer:wfdid="w10"></asp:Label> </TD><TD style="WIDTH: 100px"><asp:TextBox id="txtDocNo" runat="server" SkinID="Unicodetxt" __designer:wfdid="w11" MaxLength="20"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Label47" runat="server" Text="जारी गर्ने जल्ला" SkinID="Unicodelbl" __designer:wfdid="w12"></asp:Label> </TD><TD style="WIDTH: 100px" vAlign=top><asp:DropDownList id="ddlIssuedFrom" runat="server" SkinID="Unicodeddl" __designer:wfdid="w13"></asp:DropDownList> </TD><TD style="WIDTH: 99px" vAlign=top><asp:Label id="Label45" runat="server" Width="119px" Text="जारी गरेको मिति" SkinID="Unicodelbl" __designer:wfdid="w14"></asp:Label> </TD><TD style="WIDTH: 100px"><asp:TextBox id="txtIssuedDate" runat="server" SkinID="Unicodetxt" Columns="11" __designer:wfdid="w15"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="medIssuedDate" runat="server" TargetControlID="txtIssuedDate" MaskType="Date" Mask="9999/99/99" AutoComplete="False" __designer:wfdid="w16" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True"></ajaxToolkit:MaskedEditExtender> </TD></TR><TR><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Label46" runat="server" Text="जारी गर्ने" SkinID="Unicodelbl" __designer:wfdid="w17"></asp:Label> </TD><TD style="WIDTH: 100px" vAlign=top><asp:TextBox id="txtIssuedBy" runat="server" SkinID="Unicodetxt" __designer:wfdid="w18"></asp:TextBox> </TD><TD style="WIDTH: 99px" vAlign=top></TD><TD style="WIDTH: 100px" align=left>&nbsp;</TD></TR><TR><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 99px"></TD><TD style="WIDTH: 100px" align=right>&nbsp;<asp:Button id="btnAddPersonDocuments" onclick="btnAddPersonDocuments_Click" runat="server" Text="+" SkinID="Add" OnClientClick="return checkDupDocumentType();" __designer:wfdid="w19"></asp:Button> </TD></TR><TR><TD colSpan=4><asp:GridView id="grdPersonDoc" runat="server" OnSelectedIndexChanged="grdPersonDoc_SelectedIndexChanged" __designer:wfdid="w20" GridLines="None" AutoGenerateColumns="False" CellPadding="4" OnRowDeleting="grdPersonDoc_RowDeleting" ForeColor="#333333" OnRowDataBound="grdPersonDoc_RowDataBound">
<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>
<Columns>
<asp:BoundField DataField="PID" HeaderText="PID"></asp:BoundField>
<asp:BoundField DataField="DocTypeID" HeaderText="DocTypeID"></asp:BoundField>
<asp:BoundField DataField="DocTypeName" HeaderText="कागज-पत्रको किसिम">
<HeaderStyle Wrap="False"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="DocNumber" HeaderText="कागज-पत्रको नं">
<HeaderStyle Wrap="False"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="IssuedFrom" HeaderText="IssuedFrom">
<HeaderStyle Wrap="False"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="NepDistName" HeaderText="जारी गर्ने जिल्ला">
<HeaderStyle Wrap="False"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="IssuedOn" HeaderText="जारी मिति">
<HeaderStyle Wrap="False"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="IssuedBy" HeaderText="जारी गर्ने">
<HeaderStyle Wrap="False"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="Active" HeaderText="सक्रिय"></asp:BoundField>
<asp:BoundField DataField="Action" HeaderText="Action"></asp:BoundField>
<asp:CommandField ShowSelectButton="True"></asp:CommandField>
<asp:CommandField ShowDeleteButton="True"></asp:CommandField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>
</asp:GridView> </TD></TR><TR><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 99px"></TD><TD style="WIDTH: 100px"></TD></TR></TBODY></TABLE>
</ContentTemplate>
<HeaderTemplate>
कागज-पत्र
</HeaderTemplate>
</ajaxToolkit:TabPanel>
</ajaxToolkit:TabContainer> </TD></TR></TBODY></TABLE><asp:Button id="btnAddPerson" onclick="btnAddPerson_Click" runat="server" Text="+" SkinID="Add"></asp:Button> &nbsp; &nbsp; &nbsp;&nbsp; </asp:Panel> <asp:Panel id="pnlOrganization" runat="server" Visible="false">&nbsp;<asp:UpdatePanel id="UpdatePanel5" runat="server"><ContentTemplate>
<TABLE style="WIDTH: 990px"><TBODY><TR><TD vAlign=top colSpan=6><asp:Label id="Label27" runat="server" Text="संस्थाको विवरण" SkinID="UnicodeHeadlbl" Font-Bold="True"></asp:Label></TD></TR><TR><TD style="WIDTH: 105px" vAlign=top><asp:Label id="Label28" runat="server" Width="97px" Height="22px" Text="संस्थाको नाम" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top colSpan=3><asp:TextBox id="txtOrgName_RQD" runat="server" Width="485px" SkinID="Unicodetxt" ToolTip="संस्थाको नाम" Columns="102" MaxLength="100"></asp:TextBox></TD><TD style="WIDTH: 115px" vAlign=top><asp:TextBox id="txtOrgID" runat="server" Width="78px" Visible="False"></asp:TextBox></TD><TD vAlign=top></TD></TR><TR><TD style="WIDTH: 105px" vAlign=top><asp:Label id="Label30" runat="server" Width="95px" Text="रेजिष्ट्रेशन नं" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 179px" vAlign=top><asp:TextBox id="txtRegNo" runat="server" Width="150px" SkinID="Unicodetxt"></asp:TextBox></TD><TD style="WIDTH: 65px" vAlign=top><asp:Label id="Label31" runat="server" Width="60px" Text="प्यान नं" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 181px" vAlign=top><asp:TextBox id="txtPanNo" runat="server" Width="150px" SkinID="Unicodetxt"></asp:TextBox></TD><TD style="WIDTH: 115px" vAlign=top><asp:Label id="Label32" runat="server" Width="110px" Text="संस्थाको किसिम" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:DropDownList id="DropDownList1" runat="server" Width="155px"></asp:DropDownList></TD></TR><TR><TD vAlign=top colSpan=6><TABLE style="WIDTH: 990px"><TBODY><TR><TD vAlign=top colSpan=6>
<HR />
<asp:Label id="Label266" runat="server" Text="ठेगाना" SkinID="Unicodelbl" Font-Bold="True"></asp:Label></TD></TR><TR><TD style="WIDTH: 115px" vAlign=top><asp:Label id="Label826" runat="server" Width="61px" Height="19px" Text="जिल्ला" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 150px" vAlign=top><asp:DropDownList id="ddlOrgDistrict" runat="server" Width="150px" SkinID="Unicodeddl" OnSelectedIndexChanged="ddlOrgDistrict_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList></TD><TD style="WIDTH: 105px" vAlign=top><asp:Label id="Label846" runat="server" Width="100px" Height="19px" Text="गा.बि.स./न.पा." SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 260px" vAlign=top><asp:DropDownList id="ddlOrgVDC" runat="server" Width="150px" SkinID="Unicodeddl" OnSelectedIndexChanged="ddlOrgVDC_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList></TD><TD style="WIDTH: 55px" vAlign=top><asp:Label id="Label33" runat="server" Width="50px" Height="19px" Text="वडा नं." SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 100px" vAlign=top><asp:DropDownList id="ddlOrgWard" runat="server" Width="100px" SkinID="Unicodeddl" OnSelectedIndexChanged="ddlOrgWard_SelectedIndexChanged" AppendDataBoundItems="True">
                </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 115px" vAlign=top><asp:Label id="Label836" runat="server" Height="19px" Text="टोल" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 150px" vAlign=top><asp:TextBox id="txtOrgTole" runat="server" Width="145px" SkinID="Unicodetxt" MaxLength="100" TextMode="MultiLine"></asp:TextBox></TD><TD style="WIDTH: 105px" vAlign=baseline><asp:ImageButton id="imgDelOrgPerAddress" onclick="imgDelOrgPerAddress_Click" runat="server" ImageUrl="~/MODULES/COMMON/Images/bycat1.ico" Visible="False" OnClientClick="return confirm('यो ठेगाना हटाउने हो ?')" AlternateText="Delete This Address"></asp:ImageButton></TD><TD style="WIDTH: 260px" vAlign=top></TD><TD style="WIDTH: 55px" vAlign=top></TD><TD style="WIDTH: 100px" vAlign=top></TD></TR><TR><TD vAlign=top colSpan=6>
<HR />
<asp:Label id="Label34" runat="server" Width="105px" Height="19px" Text="फोन" SkinID="Unicodelbl" Font-Bold="True"></asp:Label>&nbsp;</TD></TR><TR><TD style="WIDTH: 115px; HEIGHT: 60px" vAlign=top><asp:Label id="Label35" runat="server" Width="112px" Height="19px" Text="फोनको किसिम" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 150px; HEIGHT: 60px" vAlign=top><asp:DropDownList id="ddlOrgPhoneType_Phone" runat="server" Width="150px" SkinID="Unicodeddl" ToolTip="फोनको किसिम"><asp:ListItem Value="N">छान्नुहोस</asp:ListItem>
<asp:ListItem Value="M">मोबाईल</asp:ListItem>
<asp:ListItem Value="O">अफिस</asp:ListItem>
<asp:ListItem Value="R">घर</asp:ListItem>
<asp:ListItem Value="OT">अन्य</asp:ListItem>
</asp:DropDownList></TD><TD style="WIDTH: 105px; HEIGHT: 60px" vAlign=top><asp:Label id="Label36" runat="server" Width="55px" Height="19px" Text="फोन न." SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 260px; HEIGHT: 60px" vAlign=top><asp:TextBox id="txtOrgPhoneNumber_Phone" runat="server" Width="180px" SkinID="Unicodetxt" ToolTip="फोन नं" MaxLength="15"></asp:TextBox> <ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender11" runat="server" TargetControlID="txtOrgPhoneNumber_Phone" FilterType="Numbers">
                </ajaxToolkit:FilteredTextBoxExtender> </TD><TD style="WIDTH: 55px; HEIGHT: 60px" vAlign=top><asp:Button id="btnOrgPhonePlus" onclick="btnOrgPhonePlus_Click" runat="server" Text="+" SkinID="Add" OnClientClick="javascript:return validateUpanelFields('_Phone',0);"></asp:Button></TD><TD style="WIDTH: 100px; HEIGHT: 60px" vAlign=top></TD></TR><TR><TD style="HEIGHT: 21px" vAlign=top colSpan=4><asp:GridView id="grdOrgPhone" runat="server" SkinID="Unicodegrd" OnSelectedIndexChanged="grdOrgPhone_SelectedIndexChanged" GridLines="None" AutoGenerateColumns="False" CellPadding="4" OnRowDeleting="grdOrgPhone_RowDeleting" ForeColor="#333333" OnRowDataBound="grdPhone_RowDataBound">
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
                </asp:GridView> </TD><TD style="WIDTH: 55px; HEIGHT: 21px" vAlign=top></TD><TD style="WIDTH: 100px; HEIGHT: 21px" vAlign=top></TD></TR><TR><TD style="HEIGHT: 21px" vAlign=top colSpan=6>
<HR />
<asp:Label id="LblEmail" runat="server" Width="105px" Height="19px" Text="इमेल" SkinID="Unicodelbl" Font-Bold="True"></asp:Label>&nbsp;</TD></TR><TR><TD style="WIDTH: 115px; HEIGHT: 21px" vAlign=top><asp:Label id="Label236" runat="server" Width="110px" Text="ईमेलको किसिम" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 150px; HEIGHT: 21px" vAlign=top><asp:DropDownList id="ddlOrgEMailType_EMail" runat="server" Width="150px" SkinID="Unicodeddl" ToolTip="इमेलको किसिम">
                    <asp:ListItem Value="N">छान्नुहोस</asp:ListItem>
                    <asp:ListItem Value="P">ब्यक्तिगत</asp:ListItem>
                    <asp:ListItem Value="O">अफिस</asp:ListItem>
                    <asp:ListItem Value="OT">अन्य</asp:ListItem>
                </asp:DropDownList></TD><TD style="WIDTH: 105px; HEIGHT: 21px" vAlign=top><asp:Label id="Label246" runat="server" Width="101px" Height="19px" Text="ईमेल ठेगाना" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 260px; HEIGHT: 21px" vAlign=top><asp:TextBox id="txtOrgEMail_EMail" runat="server" Width="250px" SkinID="Unicodetxt" ToolTip="इमेल ठेगाना" MaxLength="50"></asp:TextBox></TD><TD style="WIDTH: 55px; HEIGHT: 21px" vAlign=top><asp:Button id="btnOrgEMailPlus" onclick="btnOrgEMailPlus_Click" runat="server" Text="+" SkinID="Add" OnClientClick="javascript:return ValidateEmailFR();"></asp:Button></TD><TD style="WIDTH: 100px; HEIGHT: 21px" vAlign=top></TD></TR><TR><TD style="HEIGHT: 21px" vAlign=top colSpan=4><asp:GridView id="grdOrgEMail" runat="server" SkinID="Unicodegrd" OnSelectedIndexChanged="grdOrgEMail_SelectedIndexChanged" GridLines="None" AutoGenerateColumns="False" CellPadding="4" OnRowDeleting="grdOrgEMail_RowDeleting" ForeColor="#333333" OnRowDataBound="grdEMail_RowDataBound">
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:BoundField DataField="PID" HeaderText="PersonID" />
                        <asp:BoundField DataField="ETYPE" HeaderText="EMail Type" />
                        <asp:BoundField DataField="EMAILTYPE" HeaderText="ईमेलको किसिम">
                        </asp:BoundField>
                        <asp:BoundField DataField="ESNO" HeaderText="ESNo" />
                        <asp:BoundField DataField="EMAIL" HeaderText="ईमेल ठेगाना">
                        </asp:BoundField>
                        <asp:BoundField DataField="ACTIVE" HeaderText="Active" />
                        <asp:BoundField DataField="REMARKS" HeaderText="कैफियत" />
                        <asp:BoundField DataField="ACTION" HeaderText="Action" />
                        <asp:CommandField ShowSelectButton="True">
                        </asp:CommandField>
                        <asp:CommandField ShowDeleteButton="True">
                        </asp:CommandField>
                    </Columns>
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <EditRowStyle BackColor="#999999" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView> </TD><TD style="WIDTH: 55px; HEIGHT: 21px" vAlign=top></TD><TD style="WIDTH: 100px; HEIGHT: 21px" vAlign=top></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
</ContentTemplate>
</asp:UpdatePanel> <asp:Button id="btnAddOrganization" onclick="btnAddOrganization_Click" runat="server" Text="+" SkinID="Add"></asp:Button></asp:Panel>&nbsp; <TABLE><TBODY><TR><TD style="WIDTH: 500px" vAlign=top><asp:GridView id="grdAppellant" runat="server" Width="400px" SkinID="Unicodegrd" OnSelectedIndexChanged="grdAppellant_SelectedIndexChanged" GridLines="None" AutoGenerateColumns="False" CellPadding="4" OnRowDeleting="grdAppellant_RowDeleting" ForeColor="#333333" OnRowDataBound="grdAppellant_RowDataBound" OnDataBound="grdAppellant_DataBound">
<FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="LitigantID" HeaderText="LitigantID"></asp:BoundField>
<asp:BoundField DataField="LitigantName" HeaderText="वादि">
<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DisplayName" HeaderText="देखाउने नाम">
<ItemStyle Wrap="False"></ItemStyle>

<HeaderStyle Wrap="False"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="EntityTypeName" HeaderText="व्यक्ति/संस्था"></asp:BoundField>
<asp:BoundField DataField="Action" HeaderText="Action"></asp:BoundField>
<asp:CommandField SelectText="छान्नहोस" ShowSelectButton="True"></asp:CommandField>
    <asp:CommandField DeleteText="हटाउनुहोस" ShowDeleteButton="True" Visible="False" />
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView></TD><TD style="WIDTH: 500px" vAlign=top><asp:GridView id="grdRespondant" runat="server" Width="400px" SkinID="Unicodegrd" OnSelectedIndexChanged="grdRespondant_SelectedIndexChanged" GridLines="None" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" OnRowDataBound="grdRespondant_RowDataBound">
<FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="LitigantID" HeaderText="LitigantID"></asp:BoundField>
<asp:BoundField DataField="LitigantName" HeaderText="प्रतिवादि">
<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DisplayName" HeaderText="देखाउने नाम">
<ItemStyle Wrap="False"></ItemStyle>

<HeaderStyle Wrap="False"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="EntityTypeName" HeaderText="व्यक्ति/संस्था"></asp:BoundField>
<asp:BoundField DataField="Action" HeaderText="Action"></asp:BoundField>
<asp:CommandField SelectText="छान्नुहोस" ShowSelectButton="True"></asp:CommandField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView></TD></TR></TBODY></TABLE>&nbsp; </TD></TR></TBODY></TABLE></asp:Panel> <ajaxToolkit:CollapsiblePanelExtender id="colAppOrResp" runat="server" SkinID="CollapsiblePanelDemo" TargetControlID="pnlAppResp" SuppressPostBack="True" ImageControlID="imgCol" ExpandedImage="../../COMMON/Images/collapse_blue.jpg" ExpandControlID="colPnlAppOrResp" CollapsedImage="../../COMMON/Images/expand_blue.jpg" Collapsed="True" CollapseControlID="colPnlAppOrResp">
                </ajaxToolkit:CollapsiblePanelExtender> </TD><TD></TD><TD></TD><TD style="WIDTH: 100px"></TD><TD></TD><TD></TD></TR><TR><TD style="WIDTH: 950px; HEIGHT: 21px">&nbsp;</TD><TD style="WIDTH: 100px; HEIGHT: 21px"></TD><TD style="WIDTH: 100px; HEIGHT: 21px"></TD><TD style="WIDTH: 100px; HEIGHT: 21px"></TD><TD style="WIDTH: 100px; HEIGHT: 21px"></TD><TD style="WIDTH: 100px; HEIGHT: 21px"></TD></TR></TBODY></TABLE>
</contenttemplate>
                </asp:UpdatePanel></td>
        </tr>
    </table>
    <table style="width: 950px">
        <tr>
            <td valign="top">
                <br />
               

               </td>
        </tr>
    </table>
    <table style="width: 950px">
        <tr>
            <td style="width: 950px" valign="top">
                <hr />
                &nbsp;<br />
                <asp:Panel ID="colPnlCheckList" runat="server" CssClass="collapsePanelHeader"
                    Width="950px">
                    चेक लिष्ट
                    <asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageAlign="Right"
                        ImageUrl="~/MODULES/COMMON/Images/expand.jpg" Visible="False" />
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="width: 100px" valign="top">
                <asp:Panel ID="pnlCheckList" runat="server" CssClass="collapsePanel" Width="950px">
                    <table style="width: 939px">
                        <tr>
                            <td style="width: 100px" valign="top">
                                </td>
                        </tr>
                        <tr>
                            <td style="width: 600px" valign="top">
                                <asp:UpdatePanel id="UpdatePanel3" runat="server">
                                    <contenttemplate>
<asp:Panel id="Panel2" runat="server" Width="950px" Height="200px" ScrollBars="Auto"><asp:GridView id="grdCheckList" runat="server" Width="950px" ForeColor="#333333" GridLines="None" CellPadding="4" AutoGenerateColumns="False" OnRowDataBound="grdCheckList_RowDataBound">
<FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:TemplateField><ItemTemplate>
<asp:CheckBox id="chkSelect" runat="server"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="CheckListID" HeaderText="CheckListID"></asp:BoundField>
<asp:BoundField DataField="CheckListName" HeaderText="चेक लिष्ट">
<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:TemplateField><ItemTemplate>
<asp:TextBox id="txtCLRemarks" runat="server" MaxLength="50" Columns="52"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="Action" HeaderText="Action"></asp:BoundField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView></asp:Panel> 
</contenttemplate>
                                    <triggers>
<asp:AsyncPostBackTrigger ControlID="ddlOrgCaseRegType_RQD" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
                                </asp:UpdatePanel></td>
                        </tr>
                    </table>
                </asp:Panel>
            <ajaxToolkit:CollapsiblePanelExtender ID="colCheckList" runat="server" CollapseControlID="colPnlCheckList"
                Collapsed="True" CollapsedImage="../../COMMON/Images/expand_blue.jpg" ExpandControlID="ColPnlCheckList"
                ExpandedImage="../../COMMON/Images/collapse_blue.jpg" ImageControlID="ImageButton1"
                SkinID="CollapsiblePanelDemo" SuppressPostBack="True" TargetControlID="pnlCheckList">
                </ajaxToolkit:CollapsiblePanelExtender>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <table style="width: 950px">
        <tr>
            <td style="width: 100px" valign="top">
                &nbsp;</td>
        </tr>
    </table>    
    
    <table style="width: 950px">
       <tr>
            <td colspan="7">

                <asp:Panel ID="PnlPersonSearch" runat="server" Height="100px" Visible="False" Width="125px">
                                    <table style="width: 932px">
                                        <tr>
                                            <td style="width: 100px; height: 26px">
                                                </td>
                                            <td style="width: 100px; height: 26px">
                                                </td>
                                            <td style="width: 100px; height: 26px">
                                                </td>
                                            <td style="width: 100px; height: 26px">
                                                </td>
                                            <td style="width: 100px; height: 26px">
                                                </td>
                                            <td style="width: 100px; height: 26px">
                                                </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px; height: 14px;">
                                                </td>
                                            <td style="width: 100px; height: 14px;">
                                                </td>
                                            <td style="width: 100px; height: 14px;">
                                                </td>
                                            <td style="width: 100px; height: 14px;">
                                                </td>
                                            <td style="width: 100px; height: 14px;">
                                                </td>
                                            <td style="width: 100px; height: 14px;">
                                                </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px">
                                                </td>
                                            <td colspan="3">
                                                </td>
                                            <td style="width: 100px">
                                            </td>
                                            <td style="width: 100px">
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <table style="width: 931px">
                                </table>
                                    <tr>
                                    
                                        <td colspan="4">
                                       
                                            <asp:Panel ID="pnlOrgSearch" runat="server" Height="100px" Visible="false" Width="125px">
                                                <table style="width: 921px">
                                                    <tr>
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
                                                        <td colspan="4">
                                                            <table>
                                                                <tr>
                                                                    <td style="width: 126px; height: 31px">
                                                                        </td>
                                                                    <td style="width: 100px; height: 31px">
                                                                        </td>
                                                                    <td style="width: 100px; height: 31px">
                                                                        </td>
                                                                    <td style="width: 100px; height: 31px">
                                                                        </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px; height: 24px;">
                                                            </td>
                                                        <td style="width: 100px; height: 24px;">
                                                            &nbsp;
                                                        </td>
                                                        <td style="width: 100px; height: 24px;">
                                                        </td>
                                                        <td style="width: 100px; height: 24px;">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                             </td>
                </tr>
                <tr>
                    <td align="right" colspan="4">
                        <table>
                            <tr>
                                <td style="width: 100px">
                                    <asp:Button ID="btnCancel" runat="server" SkinID="Cancel" Text="Cancel" OnClick="btnCancel_Click1" /></td>
                                <td align="left" style="width: 100px">
                        <asp:Button ID="btnNext" runat="server" SkinID="Normal" Text="Next" OnClick="btnNext_Click" OnClientClick="return validate(1);" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
         </table>       
    <br />
    <div style="width: 945px; height: 327px">
        <br />
        <table style="width: 940px; height: 79px">
            <tr>
                <td style="width: 53px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 53px">
                    <asp:Label ID="Label55" runat="server" Text="कोर्ट"></asp:Label></td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 53px">
                    <asp:Label ID="Label57" runat="server" Text="फैसला"></asp:Label></td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 53px">
                    <asp:Label ID="Label56" runat="server" Text="Label"></asp:Label></td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 53px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 53px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 53px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
        </table>
    </div>
    <br />
                
</asp:Content>

