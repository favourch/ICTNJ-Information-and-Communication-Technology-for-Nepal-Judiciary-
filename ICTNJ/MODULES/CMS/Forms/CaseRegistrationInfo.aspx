<%@ Page Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" AutoEventWireup="true" CodeFile="CaseRegistrationInfo.aspx.cs" Inherits="MODULES_CMS_Forms_CaseRegistrationInfo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 944px">
        <tr>
            <td style="width: 100px; height: 1px;">
                <table style="width: 936px">
                    <tr>
                        <td align="center" colspan="6" style="height: 21px">
                            <asp:Label ID="Label100" runat="server" SkinID="UnicodeHeadlbl" Text="केशको विवरण"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="center" colspan="6" style="height: 21px">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="मुद्दाको किसिम" Width="105px"></asp:Label></td>
                        <td style="width: 150px">
                            <asp:Label ID="lblCaseType" runat="server" Text="Label" SkinID="UnicodeDisplaylbl"></asp:Label>
                            &nbsp; &nbsp; &nbsp;
                        </td>
                        <td style="width: 100px">
                            <asp:Label ID="Label18" runat="server" SkinID="Unicodelbl" Text="दर्ता किसिम" Width="90px"></asp:Label></td>
                        <td style="width: 150px">
                            <asp:Label ID="lblRegType" runat="server" Text="Label" SkinID="UnicodeDisplaylbl"></asp:Label></td>
                        <td style="width: 100px">
                        </td>
                        <td style="width: 100px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; height: 21px;">
                            <asp:Label ID="Label3" runat="server" SkinID="Unicodelbl" Text="दर्ता किताब" Width="87px"></asp:Label></td>
                        <td style="width: 200px; height: 21px;">
                            <asp:Label ID="lblRegDiary" runat="server" Text="Label" SkinID="UnicodeDisplaylbl"></asp:Label></td>
                        <td style="width: 100px; height: 21px;">
                            <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="मुद्दाको विषय" Width="95px"></asp:Label></td>
                        <td style="width: 150px; height: 21px;">
                            <asp:Label ID="lblRegSubject" runat="server" Text="Label" SkinID="UnicodeDisplaylbl"></asp:Label></td>
                        <td style="width: 100px; height: 21px;">
                            <asp:Label ID="Label200" runat="server" SkinID="Unicodelbl" Text="मुद्दाको नाम" Width="85px"></asp:Label></td>
                        <td style="width: 100px; height: 21px;">
                            <asp:Label ID="lblRegSubName" runat="server" Text="Label" SkinID="UnicodeDisplaylbl"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 100px; height: 21px">
                            <asp:Label ID="Label42" runat="server" SkinID="Unicodelbl" Text="दर्ता मिति"></asp:Label></td>
                        <td style="width: 150px; height: 21px">
                            <asp:Label ID="lblRegDate" runat="server" Text="Label" SkinID="UnicodeDisplaylbl"></asp:Label></td>
                        <td style="width: 100px; height: 21px">
                            <asp:Label ID="Label43" runat="server" SkinID="Unicodelbl" Text="अगाडि बढ्ने विधि"
                                Width="131px"></asp:Label></td>
                        <td style="width: 200px; height: 21px">
                            <asp:Label ID="lblPreceedingType" runat="server" Text="Label" SkinID="UnicodeDisplaylbl"></asp:Label></td>
                        <td style="width: 100px; height: 21px">
                            <asp:Label ID="Label25" runat="server" SkinID="Unicodelbl" Text="लेखा शाखामा पठाउने"
                                Width="146px"></asp:Label></td>
                        <td style="width: 100px; height: 21px">
                            <asp:Label ID="lblForwardToAccount" runat="server" Text="Label" SkinID="UnicodeDisplaylbl"></asp:Label></td>
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
                        <td style="width: 236px" align="right">
                            <asp:Button ID="btnEditCaseRegDet" runat="server" SkinID="Normal" Text="Edit" OnClick="btnEditCaseRegDet_Click" /></td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <asp:Panel ID="pnlAccountInfo" runat="server" Width="500px">
                                <table style="width: 931px">
                                    <tr>
                                        <td align="center" colspan="4">
                                            <asp:Label ID="Label17" runat="server" SkinID="UnicodeHeadlbl" Text="लेखाको विवरण"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:GridView ID="grdAccountFWD" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                ForeColor="#333333" GridLines="None" OnRowDataBound="grdAccountFWD_RowDataBound">
                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <Columns>
                                                    <asp:BoundField DataField="AccountTypeID" HeaderText="AccountTypeID" />
                                                    <asp:BoundField DataField="AccountTypeName" HeaderText="खाताको किसिम" />
                                                    <asp:BoundField DataField="TotalAmount" HeaderText="तिर्नु पर्ने रकम" />
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkFeePaid" runat="server" Checked='<%# Eval("PaidYN") %>' Enabled="False" />
                                                        </ItemTemplate>
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
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="6">
                            <asp:Button ID="btnEditAccountForward" runat="server" OnClick="btnEditAccountForward_Click"
                                SkinID="Normal" Text="Edit" /></td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <asp:Panel ID="pnlCheckList" runat="server" Width="500px">
                                <table style="width: 931px">
                                    <tr>
                                        <td align="center" style="width: 950px">
                                            <asp:Label ID="Label19" runat="server" SkinID="UnicodeHeadlbl" Text="चेक लिष्टको विवरण"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px">
                                            <asp:GridView ID="grdCheckList" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                ForeColor="#333333" GridLines="None" OnRowDataBound="grdCheckList_RowDataBound"
                                                Width="450px">
                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <Columns>
                                                    <asp:BoundField DataField="CheckListID" HeaderText="CheckListID" />
                                                    <asp:BoundField DataField="CheckListName" HeaderText="चेक लिष्ट">
                                                        <ItemStyle Wrap="False" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkSelect" runat="server" Checked='<%# Eval("CheckedYN") %>' Enabled="False" />
                                                        </ItemTemplate>
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
                                </table>
                                <br />
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 950px">
                <asp:Button ID="btnEditCheckList" runat="server" OnClick="btnEditCheckList_Click"
                    SkinID="Normal" Text="Edit" /></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 21px">
                <table style="width: 936px">
                    <tr>
                        <td align="center" colspan="6">
                            <asp:Label ID="Label4" runat="server" SkinID="UnicodeHeadlbl" Text="वादिको विवरण"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <asp:GridView ID="grdAppellant" runat="server" AutoGenerateColumns="False" Width="757px">
                                <Columns>
                                    <asp:BoundField DataField="LitigantName" HeaderText="वादिको नाम" />
                                    <asp:BoundField DataField="DisplayName" HeaderText="देखाउने नाम" />
                                </Columns>
                            </asp:GridView>
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
                        <td style="width: 436px">
                        </td>
                        <td style="width: 100px" align="right"><asp:Button ID="btnEditAppellant" runat="server" SkinID="Normal" Text="Edit" OnClick="btnEditAppellant_Click" /></td>
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
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <table style="width: 935px">
                    <tr>
                        <td align="center" colspan="6">
                            <asp:Label ID="Label5" runat="server" SkinID="UnicodeHeadlbl" Text="प्रतिवादिको विवरण"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <asp:GridView ID="grdRespondant" runat="server" AutoGenerateColumns="False" Width="757px">
                                <Columns>
                                    <asp:BoundField DataField="LitigantName" HeaderText="प्रतिदिको नाम" />
                                    <asp:BoundField DataField="DisplayName" HeaderText="देखाउने नाम" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; height: 21px;">
                        </td>
                        <td style="width: 100px; height: 21px;">
                        </td>
                        <td style="width: 100px; height: 21px;">
                        </td>
                        <td style="width: 100px; height: 21px;">
                        </td>
                        <td style="width: 100px; height: 21px;">
                        </td>
                        <td style="width: 436px; height: 21px;" align="right"><asp:Button ID="btnEditRespondant" runat="server" SkinID="Normal" Text="Edit" OnClick="btnEditRespondant_Click" /></td>
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
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 21px">
                <table style="width: 936px">
                    <tr>
                        <td align="center" colspan="6">
                            <asp:Label ID="Label6" runat="server" SkinID="UnicodeHeadlbl" Text="वकिलको विवरण"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <asp:GridView ID="grdLawyers" runat="server" AutoGenerateColumns="False" Width="766px">
                                <Columns>
                                    <asp:BoundField DataField="LawyerName" HeaderText="वकिलको नाम" />
                                    <asp:BoundField DataField="LicenceNo" HeaderText="लाइसन्स नं" />
                                </Columns>
                            </asp:GridView>
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
                        <td style="width: 436px" align="right"><asp:Button ID="btnEditLawyers" runat="server" SkinID="Normal" Text="Edit" OnClick="btnEditLawyers_Click" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 21px;">
                <table style="width: 934px">
                    <tr>
                        <td align="center" colspan="6">
                            <asp:Label ID="Label7" runat="server" SkinID="UnicodeHeadlbl" Text="साक्षीको विवरण"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <asp:GridView ID="grdWitness" runat="server" AutoGenerateColumns="False" Width="760px">
                                <Columns>
                                    <asp:BoundField DataField="WitnessName" HeaderText="साक्षीको नाम" />
                                </Columns>
                            </asp:GridView>
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
                        <td style="width: 436px" align="right"><asp:Button ID="btnEditWitness" runat="server" SkinID="Normal" Text="Edit" OnClick="btnEditWitness_Click" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <table style="width: 936px">
                    <tr>
                        <td align="center" colspan="6" style="height: 21px">
                            <asp:Label ID="Label8" runat="server" SkinID="UnicodeHeadlbl" Text="सबुतको विवरण"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <asp:GridView ID="grdEvidence" runat="server" AutoGenerateColumns="False" Width="757px">
                                <Columns>
                                    <asp:BoundField DataField="Evidence" HeaderText="सबुत" />
                                </Columns>
                            </asp:GridView>
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
                        <td style="width: 436px" align="right"><asp:Button ID="btnEditEvidence" runat="server" SkinID="Normal" Text="Edit" OnClick="btnEditEvidence_Click" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <table style="width: 937px">
                    <tr>
                        <td align="center" colspan="6">
                            <asp:Label ID="Label9" runat="server" SkinID="UnicodeHeadlbl" Text="कागज-पत्रको विवरण"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <asp:GridView ID="grdLitDocument" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                ForeColor="#333333" GridLines="None" OnDataBound="grdLitDocument_DataBound" OnRowDataBound="grdLitDocument_RowDataBound"
                                OnRowDeleting="grdLitDocument_RowDeleting" SkinID="MergedGrid" Width="920px">
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="CaseID" HeaderText="केश नं">
                                        <HeaderStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LitigantType" HeaderText="वादि / प्रतिवादि">
                                        <HeaderStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LitigantID" HeaderText="LitigantID" />
                                    <asp:BoundField DataField="LitigantName" HeaderText="वादि / प्रतिवादिको नाम">
                                        <ItemStyle Wrap="False" />
                                        <HeaderStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DocumentID" HeaderText="क्रम संख्या">
                                        <HeaderStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="कागज-पत्र">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkFileName" runat="server" OnClick="lnkFileName_Click" Text='<%# Eval("FileName") %>'></asp:LinkButton>
                                        </ItemTemplate>
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
                        <td style="width: 436px" align="right"><asp:Button ID="btnEditDocuments" runat="server" SkinID="Normal" Text="Edit" OnClick="btnEditDocuments_Click" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <table style="width: 937px">
                    <tr>
                        <td align="center" colspan="2" style="height: 21px">
                            <asp:Label ID="Label10" runat="server" SkinID="UnicodeHeadlbl" Text="केशको संक्षिप्त विवरण"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Literal ID="litCaseSummary" runat="server"></asp:Literal></td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                        </td>
                        <td style="width: 836px" align="right"><asp:Button ID="btnEditSummary" runat="server" SkinID="Normal" Text="Edit" OnClick="btnEditSummary_Click" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 21px;">
            </td>
        </tr>
    </table>
</asp:Content>

