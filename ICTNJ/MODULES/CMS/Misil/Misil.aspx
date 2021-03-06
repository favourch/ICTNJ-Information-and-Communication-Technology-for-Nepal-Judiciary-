<%@ Page AutoEventWireup="true" CodeFile="Misil.aspx.cs" Inherits="MODULES_CMS_Misil_Misil"
    Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" Title="CMS | Misil" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<%--<script language="javascript" type="text/javascript">

        function PassValues()
        {
            window.opener.document.forms[0].submit();
          
        }

        function ReloadClose()
        {                
                window.opener.document.forms[0].submit();
               this.close();
        }
</script>

</head>
<body onunload="PassValues()" >--%>

<asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>

     <script language="javascript" type="text/javascript" src="../../COMMON/JS/Validation.js"></script>
    <script language="javascript" type="text/javascript" src="../../COMMON/JS/DateValidator.js"></script>
    <script language="javascript" type="text/javascript" src="../../COMMON/JS/EnglishDateValidator.js"></script>
  
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
            <asp:Label ID="lblStatus" runat="server" Text="Label"></asp:Label>&nbsp;</asp:Panel>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
        <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
            Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    
    <br />
    <table style="width: 825px">
        <tr>
            <td style="height: 46px">
                <div class ="collapsePanelHeader" align ="left" id="SerachLitigants" style="width: 950px">
                वादी \ प्रतिवादीहरु
                </div>
            </td>
        </tr>
        <tr>
            <td style="width: 100px;">
                <asp:Panel ID="pnlLitigantSearch" runat="server" Width="900px">
                <table style="width: 900px" id="TABLE1">
                    <tr>
                        <td style="width: 19%; height: 26px;" valign="top">
                            <asp:Label ID="Label1" runat="server" Text="मुदा नम्बर" Width="75px" SkinID="Unicodelbl"></asp:Label></td>
                        <td valign="top" style="height: 26px">
                            <asp:TextBox ID="txtCaseNo" runat="server" Width="150px" SkinID="Unicodetxt"></asp:TextBox></td>
                        <td valign="top" style="height: 26px">
                            <asp:Label ID="Label2" runat="server" Text="दर्ता नम्बर" Width="75px" SkinID="Unicodelbl"></asp:Label></td>
                        <td style="width: 100%; height: 26px;" valign="top">
                            <asp:TextBox ID="txtRegNo" runat="server" Width="150px" SkinID="Unicodetxt"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td valign="top" style="height: 42px">
                        </td>
                        <td valign="top" style="height: 42px">
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" AutoComplete="False"
                                ClearMaskOnLostFocus="False" Mask="999-$9-9999" MaskType="Number" TargetControlID="txtCaseNo">
                            </ajaxToolkit:MaskedEditExtender>
                        </td>
                        <td valign="top" style="height: 42px">
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AutoComplete="False"
                                ClearMaskOnLostFocus="False" Mask="99-999-99999" MaskType="Number" TargetControlID="txtRegNo">
                            </ajaxToolkit:MaskedEditExtender>
                        </td>
                        <td align="center" valign="top" style="height: 42px">
                            <asp:Button ID="btnSearch" runat="server" SkinID="Normal" Text="Search" OnClick="btnSearch_Click" /></td>
                    </tr>
                    <tr>
                        <td colspan="2" valign="top" align="left">
                            <asp:Panel ID="Panel2" runat="server" Height="150px" Width="450px" ScrollBars="Auto">
                                <asp:GridView ID="grdAppellant" runat="server" AutoGenerateColumns="False" CellPadding="0"
                                    ForeColor="#333333" GridLines="None" SkinID="Unicodegrd" Width="450px" >
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="LitigantName" HeaderText="वादि" />
                                        <asp:BoundField DataField="Gender" HeaderText="लिङग्" />
                                        <asp:BoundField DataField="DOB" HeaderText="जन्ममिति" />
                                        <asp:BoundField DataField="IsPrisoned" HeaderText="थूनुवा" />
                                        <asp:BoundField DataField="LitigantSubTypeName" HeaderText="कैफियत" />
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
                        <td colspan="2" valign="top" align="left">
                            <asp:Panel ID="Panel6" runat="server" Height="150px" Width="450px" ScrollBars="Auto">
                                <asp:GridView ID="grdRespondent" runat="server" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333" GridLines="None" SkinID="Unicodegrd" Width="450px">
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"/>
                                    <Columns>
                                        <asp:BoundField DataField="LitigantName" HeaderText="प्रतिवादि" />
                                        <asp:BoundField DataField="Gender" HeaderText="लिङग्" />
                                        <asp:BoundField DataField="DOB" HeaderText="जन्म मिति" />
                                        <asp:BoundField DataField="IsPrisoned" HeaderText="थूनुवा" />
                                        <asp:BoundField DataField="LitigantSubTypeName" HeaderText="कैफियत" />
                                    </Columns>
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333"/>
                                    <EditRowStyle BackColor="#999999"/>
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"/>
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"/>
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"/>
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775"/>
                                </asp:GridView>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                </asp:Panel>
                <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server"
                    TargetControlID="pnlLitigantSearch" Collapsed="true" 
                    ExpandControlID ="SerachLitigants" CollapseControlID ="SerachLitigants">
                </ajaxToolkit:CollapsiblePanelExtender>
            </td>
        </tr>
        <tr>
            <td style="height: 21px;">
                <hr />
                <asp:Label ID="Label19" runat="server" SkinID="UnicodeHeadlbl" Text="Request" Width="200px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 103px;">
                <asp:Panel ID="pnlReqMisil" runat="server" Width="100%">
                <table style="width: 900px">
                    <tr>
                        <td style="width: 20%;" valign="top">
                            <asp:Label ID="Label5" runat="server" SkinID="Unicodelbl" Text="मिसिल प्रकार" Width="100px"></asp:Label></td>
                        <td style="width: 30%;" valign="top">
                            <asp:DropDownList ID="DDLMisilType" runat="server" SkinID="Unicodeddl" Width="159px">
                            </asp:DropDownList></td>
                        <td style="width: 32px;" valign="top">
                            <asp:Label ID="Label3" runat="server" SkinID="Unicodelbl" Text="ञाग्रह कार्यालय"
                                Width="106px"></asp:Label></td>
                        <td style="width: 30%;" valign="top">
                            <asp:DropDownList ID="DDLReqOrg" runat="server" SkinID="Unicodeddl" Width="266px" AutoPostBack="True" OnSelectedIndexChanged="DDLReqOrg_SelectedIndexChanged">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td style="width: 20%;" valign="middle">
                            <asp:Label ID="lblDate" runat="server" SkinID="Unicodelbl" Text="मिति" Width="62px"></asp:Label></td>
                        <td style="width: 30%;" valign="middle">
                            <asp:TextBox ID="txtReqDate" runat="server" SkinID="Unicodetxt" Width="100px"></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender5" runat="server" AutoComplete="False"
                                ClearMaskOnLostFocus="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtReqDate">
                            </ajaxToolkit:MaskedEditExtender>
                        </td>
                        <td align="left" colspan="2" valign="top">
                            &nbsp;
                            <asp:Panel ID="pnlChalaniNo" runat="server" Width="100%">
                                <table style="width: 359px">
                                    <tr>
                                        <td style="width: 50%" valign="top">
                                            <asp:Label ID="Label6" runat="server" SkinID="Unicodelbl" Text="चलानि नम्बर" Width="96px"></asp:Label></td>
                                        <td style="width: 100%" valign="top">
                                            <asp:TextBox ID="txtReqChalaniNo" runat="server" SkinID="Unicodetxt" Width="150px"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            &nbsp;</td>
                    </tr>
                </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <hr style="width: 947px" />
                <asp:Label ID="Label18" runat="server" SkinID="UnicodeHeadlbl" Text="Request Process"
                    Width="200px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:Panel ID="pnlProcessMisil" runat="server" Width="125px">
                <table style="width: 900px">
                    <tr>
                        <td style="width: 20%;" valign="top">
                            <asp:Label ID="Label9" runat="server" SkinID="Unicodelbl" Text="दर्ता नम्बर" Width="96px"></asp:Label></td>
                        <td style="width: 30%;" valign="top">
                            <asp:TextBox ID="txtReqRecRegNo" runat="server" SkinID="Unicodetxt" Width="150px"></asp:TextBox></td>
                        <td style="width: 20%;" valign="top">
                            <asp:Label ID="Label7" runat="server" SkinID="Unicodelbl" Text="बुझेको मिति" Width="103px"></asp:Label></td>
                        <td style="width: 100%;" valign="top">
                            <asp:TextBox ID="txtReqRecDate" runat="server" SkinID="Unicodetxt" Width="100px" ></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" AutoComplete="False"
                                ClearMaskOnLostFocus="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtReqRecDate">
                            </ajaxToolkit:MaskedEditExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20%" valign="top">
                            <asp:Label ID="Label11" runat="server" SkinID="Unicodelbl" Text="प्राप्त गर्ने व्यक्ति"
                                Width="109px"></asp:Label></td>
                        <td style="width: 30%" valign="top">
                            <asp:TextBox ID="txtReqRecPerson" runat="server" SkinID="Unicodetxt" Width="256px"></asp:TextBox>
                        </td>
                        <td style="width: 20%" valign="top">
                            <asp:Label ID="Label10" runat="server" SkinID="Unicodelbl" Text="पठाउने मिति" Width="103px"></asp:Label></td>
                        <td style="width: 100%" valign="top">
                            <asp:TextBox ID="txtReqReplyDate" runat="server" SkinID="Unicodetxt" Width="100px"></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender4" runat="server" AutoComplete="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtReqReplyDate" ClearMaskOnLostFocus="False">
                            </ajaxToolkit:MaskedEditExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20%" valign="top">
                            &nbsp;<asp:HiddenField ID="hdnReqRecPersonID" runat="server" />
                            </td>
                        <td colspan="1" valign="top">
                            <asp:Button ID="btnReqRecSearchPerson" runat="server" SkinID="Normal" Text="Search" OnClick="btnReqRecSearchPerson_Click" />
                            <asp:Button ID="btnReqRecNewPerson" runat="server" SkinID="Normal" Text="New" OnClick="btnReqRecNewPerson_Click" /></td>
                        <td colspan="1" valign="top">
                            <asp:Label ID="Label8" runat="server" SkinID="Unicodelbl" Text="चलानि नम्बर" Width="96px"></asp:Label></td>
                        <td valign="top" colspan="2">
                            <asp:TextBox ID="txtReqReplyChalaniNo" runat="server" SkinID="Unicodetxt" Width="150px"></asp:TextBox></td>
                    </tr>
                </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <hr style="width: 947px" />
                <asp:Label ID="lblReqRep" runat="server" SkinID="UnicodeHeadlbl" Text="Request Response"
                    Width="200px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:Panel ID="pnlReplyMisil" runat="server" Width="100%">
                    <table style="width: 900px">
                        <tr>
                            <td style="width: 20%" valign="top">
                                <asp:Label ID="Label12" runat="server" SkinID="Unicodelbl" Text="दर्ता नम्बर" Width="96px"></asp:Label></td>
                            <td style="width: 30%" valign="top">
                                <asp:TextBox ID="txtRecRegNo" runat="server" SkinID="Unicodetxt" Width="150px"></asp:TextBox></td>
                            <td style="width: 20%" valign="top">
                                <asp:Label ID="Label15" runat="server" SkinID="Unicodelbl" Text="फर्काऐको " Width="103px"></asp:Label></td>
                            <td style="width: 100%" valign="top">
                                <asp:CheckBox ID="chkIsReturned" runat="server" AutoPostBack="True" OnCheckedChanged="chkIsReturned_CheckedChanged" /></td>
                        </tr>
                        <tr>
                            <td style="width: 20%" valign="top">
                                <asp:Label ID="Label13" runat="server" SkinID="Unicodelbl" Text="बुझेको मिति" Width="103px"></asp:Label></td>
                            <td style="width: 30%" valign="top">
                                <asp:TextBox ID="txtRecDate" runat="server" SkinID="Unicodetxt" Width="100px"></asp:TextBox>
                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender6" runat="server" AutoComplete="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtRecDate" ClearMaskOnLostFocus="False">
                                </ajaxToolkit:MaskedEditExtender>
                            </td>
                            <td style="width: 20%" valign="top">
                                <asp:Label ID="lblReturnDate" runat="server" SkinID="Unicodelbl" Text="फर्काऐको मिति" Width="103px"></asp:Label></td>
                            <td style="width: 100%" valign="top">
                                <asp:TextBox ID="txtReturnDate" runat="server" SkinID="Unicodetxt" Width="100px"></asp:TextBox>
                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender7" runat="server" AutoComplete="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtReturnDate" ClearMaskOnLostFocus="False">
                                </ajaxToolkit:MaskedEditExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; height: 1px;" valign="top">
                                <asp:Label ID="lblRecPerson" runat="server" SkinID="Unicodelbl" Text="प्राप्त गर्ने व्यक्ति"
                                    Width="109px"></asp:Label></td>
                            <td valign="top" colspan="2" style="height: 1px">
                                <asp:TextBox ID="txtRecPerson" runat="server" SkinID="Unicodetxt" Width="350px"></asp:TextBox></td>
                            <td colspan="2" valign="top" style="height: 1px">
                                <asp:HiddenField ID="hdnRecPersonID" runat="server" />
                                <asp:Button ID="btnRecPersonSearch" runat="server" SkinID="Normal" Text="Search" OnClick="btnRecPersonSearch_Click" /><asp:Button ID="btnRecNewPerson" runat="server" SkinID="Normal" Text="New" OnClick="btnRecNewPerson_Click" /></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <table style="width: 950px">
                    <tr>
                        <td align="left" style="width: 19%; height: 72px;" valign="middle">
                            <asp:Label ID="lblRemarks" runat="server" SkinID="Unicodelbl" Text="कैफियत" Width="109px"></asp:Label></td>
                        <td align="left" style="width: 100%; height: 72px;" valign="top">
                            <asp:TextBox ID="txtRemarks" runat="server" Height="61px" SkinID="Unicodetxt" TextMode="MultiLine"
                                Width="406px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right" colspan="2" valign="top">
                            <asp:Button ID="btnSubmit" runat="server" SkinID="Normal" Text="Submit" OnClick="btnSubmit_Click" />
                            <asp:Button ID="btnCancel" runat="server" SkinID="Cancel" Text="Cancel" /></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:Button ID="hiddenTargetControlForPersonModalPopup" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="programmaticPersonModalPopup" runat="server"
        BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior1"
        DropShadow="True" PopupControlID="programmaticPersonPopup" PopupDragHandleControlID="programmaticPersonPopupDragHandle"
        RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForPersonModalPopup">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="programmaticPersonPopup" runat="server" CssClass="modalPopupPerson"
        Height="400px" Style="display: none;padding: 10px">
        <asp:Panel ID="programmaticPersonPopupDragHandle" runat="Server" Style="cursor: move;
            background-color: #DDDDDD; border: solid 1px Gray; color: Black; text-align: center;">
            मान्छे &nbsp;खोज्नुहोस</asp:Panel>
        <contenttemplate></contenttemplate>
        <asp:UpdatePanel id="UpdatePanelPersonSearch" runat="server">
            <contenttemplate>
<BR /><TABLE style="WIDTH: 700px; TEXT-ALIGN: left"><TBODY><TR><TD style="WIDTH: 120px" vAlign=top><asp:Label id="Label14" runat="server" Width="75px" Text="पहिलो नाम" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 140px" vAlign=top><asp:TextBox id="txtSFirstName" runat="server" Width="100px" SkinID="Unicodetxt"></asp:TextBox></TD><TD style="WIDTH: 85px" vAlign=top><asp:Label id="Label16" runat="server" Width="80px" Text="बिचको नाम" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 140px" vAlign=top><asp:TextBox id="txtSMName" runat="server" Width="100px" SkinID="Unicodetxt"></asp:TextBox></TD><TD style="WIDTH: 115px" vAlign=top><asp:Label id="Label17" runat="server" Text="थर" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:TextBox id="txtSLastName" runat="server" Width="100px" SkinID="Unicodetxt"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 120px" vAlign=top><asp:Label id="Label78" runat="server" Text="लिंग" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 140px" vAlign=top><asp:DropDownList id="ddlSGender" runat="server" Width="105px" SkinID="Unicodeddl"><asp:ListItem Value="SG">छान्नुहोस</asp:ListItem>
<asp:ListItem Value="M">पुरुष</asp:ListItem>
<asp:ListItem Value="F">महिला</asp:ListItem>
<asp:ListItem Value="O">अन्य</asp:ListItem>
</asp:DropDownList></TD><TD style="WIDTH: 85px" vAlign=top><asp:Label id="Label20" runat="server" Width="75px" Text="जन्म मिति" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 140px" vAlign=top><asp:TextBox id="txtSDOB_DT" runat="server" Width="100px" SkinID="Unicodetxt"></asp:TextBox></TD><TD style="WIDTH: 115px" vAlign=top><asp:Label id="Label25" runat="server" Width="110px" Text="बैबाहिक सम्बन्ध" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:DropDownList id="ddlSMarStatus" runat="server" Width="105px" SkinID="Unicodeddl"><asp:ListItem Value="SMS">छान्नुहोस</asp:ListItem>
<asp:ListItem Value="S">अबिबाहित</asp:ListItem>
<asp:ListItem Value="M">बिबाहित</asp:ListItem>
<asp:ListItem Value="W">बिधवा/बिदुर</asp:ListItem>
<asp:ListItem Value="D">छोडपत्र</asp:ListItem>
<asp:ListItem Value="O">अन्य</asp:ListItem>
</asp:DropDownList></TD></TR><TR><TD style="WIDTH: 120px" vAlign=top><asp:Label id="Label77" runat="server" Width="120px" Text="घर भएको जिल्ला" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 140px" vAlign=top><asp:DropDownList id="ddlSHomeDistrict" runat="server" Width="105px" SkinID="Unicodeddl"></asp:DropDownList></TD><TD style="WIDTH: 85px" vAlign=top></TD><TD style="WIDTH: 140px" vAlign=top></TD><TD style="WIDTH: 115px" vAlign=top></TD><TD vAlign=top></TD></TR><TR><TD vAlign=top colSpan=2><asp:Button id="btnPersonSearch" onclick="btnPersonSearch_Click" runat="server" Text="Search"></asp:Button> <asp:Button id="btnCancelPersonSearch" onclick="btnCancelPersonSearch_Click" runat="server" Text="Cancel"></asp:Button> </TD><TD style="WIDTH: 85px" vAlign=top></TD><TD style="WIDTH: 140px" vAlign=top></TD><TD vAlign=top align=right colSpan=2>&nbsp;</TD></TR><TR><TD vAlign=top colSpan=6><asp:Panel id="pnlPersonSearch" runat="server" Width="680" Height="250px" ScrollBars="Auto"><asp:GridView id="grdPersonSearch" runat="server" Width="650px" SkinID="Unicodegrd" ForeColor="#333333" AutoGenerateColumns="False" CellPadding="4" GridLines="None" OnRowDataBound="grdPersonSearch_RowDataBound" OnSelectedIndexChanged="grdPersonSearch_SelectedIndexChanged">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField HeaderText="क्र.सं.">
<ItemStyle Width="25px" Font-Names="PCS NEPALI"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="PERSONID" HeaderText="आईडी"></asp:BoundField>
<asp:BoundField DataField="RDFULLNAME" HeaderText="पुरा नाम थर"></asp:BoundField>
<asp:BoundField DataField="RDGENDER" HeaderText="लिंग"></asp:BoundField>
<asp:BoundField DataField="DOB" HeaderText="जन्म मिति"></asp:BoundField>
<asp:BoundField DataField="RDMARITALSTATUS" HeaderText="बैबाहिक सम्बन्ध"></asp:BoundField>
<asp:BoundField DataField="BIRTHDISTRICT" HeaderText="घर भएको जिल्ला"></asp:BoundField>
<asp:CommandField ShowSelectButton="True"></asp:CommandField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView></asp:Panel></TD></TR></TBODY></TABLE> 
</contenttemplate>
        </asp:UpdatePanel>
        <asp:Button ID="btnOKPersonSearch" runat="server" OnClick="OkPersonButton_Click" Text="OK"
            Width="58px" />
    </asp:Panel>
</asp:Content>

