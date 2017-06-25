<%@ Page Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" AutoEventWireup="true" CodeFile="CaseRegistration4.aspx.cs" Inherits="MODULES_CMS_Forms_CaseRegistration4" Title="Untitled Page" %>

<%@ Register
    Assembly="AjaxControlToolkit" 
    Namespace="AjaxControlToolkit" 
    TagPrefix="ajaxToolkit" %>
    
    <%@ Register Assembly="Winthusiasm.HtmlEditor" Namespace="Winthusiasm.HtmlEditor" TagPrefix="cc1" %>

    
    
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
                <asp:Label ID="Label1" runat="server" SkinID="UnicodeHeadlbl" Text="केशको विवरण"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="6">
                <hr />
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:Label ID="Label7" runat="server" Text="केश नं" SkinID="Unicodelbl"></asp:Label></td>
            <td style="width: 100px">
                &nbsp;<asp:Label ID="lblCaseNo" runat="server" Text="lblCaseNo" SkinID="Unicodelbl"></asp:Label></td>
            <td style="width: 100px">
                <asp:TextBox ID="txtCaseNo" runat="server" Visible="False"></asp:TextBox></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
                </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 31px">
                <asp:Label ID="Label111" runat="server" SkinID="Unicodelbl" Text="मुद्दाको किसिम" Width="105px"></asp:Label></td>
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
                                ID="Label11111" runat="server" SkinID="Unicodelbl" Text="दर्ता किताब" Width="87px"></asp:Label></td>
            <td style="width: 100px; height: 31px">
                <asp:Label
                                    ID="lblRegDiary" runat="server" SkinID="UnicodeDisplaylbl" Text="Label" Width="174px"></asp:Label></td>
            <td style="width: 100px; height: 31px">
            <asp:Label
                                        ID="Label2e3" runat="server" SkinID="Unicodelbl" Text="मुद्दाको विषय" Width="95px"></asp:Label></td>
            <td style="width: 100px; height: 31px">
            <asp:Label
                                            ID="lblRegSubject" runat="server" SkinID="UnicodeDisplaylbl" Text="Label"></asp:Label></td>
            <td style="width: 100px; height: 31px">
            <asp:Label
                                                ID="Label200" runat="server" SkinID="Unicodelbl" Text="मुद्दाको नाम" Width="85px"></asp:Label></td>
            <td style="width: 100px; height: 31px">
            <asp:Label
                                                    ID="lblRegSubName" runat="server" SkinID="UnicodeDisplaylbl" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100px">
            <asp:Label
                                                        ID="Label42" runat="server" SkinID="Unicodelbl" Text="दर्ता मिति"></asp:Label></td>
            <td style="width: 100px">
            <asp:Label
                                                            ID="lblRegDate" runat="server" SkinID="UnicodeDisplaylbl" Text="Label"></asp:Label></td>
            <td style="width: 100px">
            <asp:Label
                                                                ID="Label43" runat="server" SkinID="Unicodelbl" Text="अगाडि बढ्ने विधि" Width="131px"></asp:Label></td>
            <td style="width: 100px">
            <asp:Label
                                                                    ID="lblPreceedingType" runat="server" SkinID="UnicodeDisplaylbl" Text="Label"></asp:Label></td>
            <td style="width: 100px">
            <asp:Label
                                                                        ID="Label25" runat="server" SkinID="Unicodelbl" Text="लेखा शाखामा पठाउने" Width="146px"></asp:Label></td>
            <td style="width: 100px">
            <asp:Label
                                                                            ID="lblForwardToAccount" runat="server" SkinID="UnicodeDisplaylbl" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="6" align="center">
                <hr />
                <asp:Label ID="Label3" runat="server" SkinID="UnicodeHeadlbl" Text="सबुतको विवरण"></asp:Label></td>
        </tr>
    </table>
    <table style="width: 930px">
        <tr>
            <td align="center" colspan="6" style="height: 21px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px" valign="top">
                <asp:Label ID="Label4" runat="server" Text="सबुत" SkinID="Unicodelbl"></asp:Label></td>
            <td colspan="5">
                <asp:TextBox ID="txtEvidence" runat="server" Height="91px" MaxLength="10" TextMode="MultiLine"
                    Width="869px"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="3" valign="top" style="height: 26px">
                &nbsp;</td>
            <td colspan="3" valign="top" style="height: 26px" align="right">
                &nbsp;<asp:Button ID="btnAddEvidence" runat="server" Text="+" OnClick="btnAddEvidence_Click" SkinID="Add" /></td>
        </tr>
        <tr>
            <td style="height: 21px" colspan="6">
                <asp:GridView ID="grdEvidence" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None" Width="921px" OnSelectedIndexChanged="grdEvidence_SelectedIndexChanged" OnRowCreated="grdEvidence_RowCreated">
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:BoundField DataField="EvidenceID" HeaderText="EvidenceID" />
                        <asp:BoundField DataField="Evidence" HeaderText="सबुत" >
                            <ControlStyle Width="870px" />
                            <ItemStyle Width="850px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Action" HeaderText="Action" />
                        <asp:CommandField SelectText="छान्नुहोस" ShowSelectButton="True" >
                            <ControlStyle Width="50px" />
                        </asp:CommandField>
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
    </table>
    <table style="width: 928px">
        <tr>
            <td align="center" style="width: 900px; height: 26px">
                <hr />
                <asp:Label ID="Label5" runat="server" SkinID="UnicodeHeadlbl" Text="कगज-पत्रको विवरण"></asp:Label></td>
        </tr>
        <tr>
            <td align="center" style="width: 900px; height: 37px;">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" style="width: 100px;">
                <table style="width: 920px">
                    <tr>
                        <td style="width: 100px" valign="top">
                            <table style="width: 200px">
                                <tr>
                                    <td style="width: 74px">
                                        <asp:Label ID="Label9" runat="server" SkinID="Unicodelbl" Text="सबै छान्नुहोस"></asp:Label></td>
                                    <td style="width: 100px">
                                        <asp:CheckBox ID="cbSelectAllAppellantss" runat="server" AutoPostBack="True" OnCheckedChanged="cbSelectAllAppellantss_CheckedChanged" /></td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 100px" valign="top">
                            <table style="width: 200px">
                                <tr>
                                    <td style="width: 74px">
                                        <asp:Label ID="Label8" runat="server" SkinID="Unicodelbl" Text="सबै छान्नहोस" Width="103px"></asp:Label></td>
                                    <td style="width: 100px">
                                        <asp:CheckBox ID="cbSelectAllRespondants" runat="server" AutoPostBack="True" OnCheckedChanged="cbSelectAllRespondants_CheckedChanged"
                                            SkinID="smallChk" Enabled="False" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px" valign="top">
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
                        <td style="width: 100px" valign="top">
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
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 100px;" valign="top">
                <asp:GridView ID="grdDocuments" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None" OnDataBound="grdCourtFee_DataBound" OnRowDataBound="grdDocuments_RowDataBound"
                    OnSelectedIndexChanged="grdCourtFee_SelectedIndexChanged" ShowFooter="True" Width="851px">
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemStyle Wrap="False" />
                            <ItemTemplate>
                                <asp:Label ID="lblSNo" runat="server" SkinID="Unicodelbl" Text="कगज-पत्र"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:FileUpload ID="fupDocuments" runat="server" Width="517px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="FileName" HeaderText="कागज-पत्र">
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:TemplateField></asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="imgDelDocuments" runat="server" ImageUrl="~/MODULES/COMMON/Images/bycat1.ico"
                                    OnClick="imgDelDocuments_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <FooterTemplate>
                                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" SkinID="Normal" Text="Upload" />&nbsp;
                            </FooterTemplate>
                            <FooterStyle Wrap="False" />
                        </asp:TemplateField>
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
            <td align="right" style="width: 900px; height: 26px">
                <asp:Button ID="btnAddLitDoc" runat="server" OnClick="btnAddLitDoc_Click" SkinID="Add"
                    Text="+" /></td>
        </tr>
        <tr>
            <td align="left" style="width: 100px; height: 26px">
                <asp:GridView ID="grdLitDocument" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None" OnDataBound="grdLitDocument_DataBound" SkinID="MergedGrid" Width="920px" OnRowDeleting="grdLitDocument_RowDeleting" OnRowDataBound="grdLitDocument_RowDataBound">
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:BoundField DataField="CaseID" HeaderText="केश नं" >
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="LitigantType" HeaderText="वादि / प्रतिवादि" >
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="LitigantID" HeaderText="LitigantID" />
                        <asp:BoundField DataField="LitigantName" HeaderText="वादि / प्रतिवादिको नाम" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DocumentID" HeaderText="क्रम संख्या" >
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FileName" HeaderText="कागज-पत्र" >
                            <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="कागज-पत्र">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkFileName" runat="server" Text='<%# Eval("FileName") %>' OnClick="lnkFileName_Click"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Action" HeaderText="Action" />
                        <asp:CommandField DeleteText="हटाउनुहोस" ShowDeleteButton="True" />
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
            <td align="center" style="width: 900px; height: 26px">
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 900px; height: 26px">
                <hr />
                <asp:Label ID="Label6" runat="server" SkinID="UnicodeHeadlbl" Text="केशको संक्षिप्त विवरण" Width="181px"></asp:Label></td>
        </tr>
        <tr>
            <td align="center" style="width: 900px; height: 26px">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" style="width: 100px; height: 30px">
                <asp:UpdatePanel id="UpdatePanel2" runat="server">
                    <contenttemplate>
<cc1:HtmlEditor id="heCaseSummary" runat="server" Width="910px" Height="400px" ToolbarColor="127, 157, 185" BackColor="White"></cc1:HtmlEditor> 
</contenttemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 26px">
                <asp:Button ID="btnNext" runat="server" OnClick="btnNext_Click" SkinID="Normal" Text="Finish" /></td>
        </tr>
        <tr>
            <td align="left" style="width: 100px; height: 26px">
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 100px; height: 26px">
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 900px; height: 26px">
                </td>
        </tr>
    </table>
    &nbsp;
</asp:Content>

