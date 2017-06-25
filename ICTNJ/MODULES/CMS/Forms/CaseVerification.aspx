<%@ Page Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" AutoEventWireup="true" CodeFile="CaseVerification.aspx.cs" Inherits="MODULES_CMS_Forms_CaseVerification" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../UserControls/CaseSearch.ascx" TagName="CaseSearch" TagPrefix="userControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 891px">
        <tr>
            <td style="width: 100px">
                
                 <asp:Panel ID="pnlCaseSearch" runat="server" CssClass="collapsePanelHeader" Height="25px"
        Width="1024px">
                     मुद्दा खोज्नहोस
                     <asp:ImageButton ID="ImageButton2" runat="server" Height="25px" ImageAlign="Right"
            ImageUrl="~/MODULES/COMMON/Images/expand.jpg" Visible="False" />
    </asp:Panel>
    <ajaxToolkit:CollapsiblePanelExtender ID="colCaseSearch" runat="server" CollapseControlID="pnlCaseSearch"
        Collapsed="True" CollapsedImage="../../COMMON/Images/expand_blue.jpg" ExpandControlID="pnlCaseSearch"
        ExpandedImage="../../COMMON/Images/collapse_blue.jpg" ImageControlID="imgCol"
        SkinID="CollapsiblePanelDemo" SuppressPostBack="True" TargetControlID="pnlCaseContent">
    </ajaxToolkit:CollapsiblePanelExtender>
    <asp:Panel ID="pnlCaseContent" runat="server" CssClass="collapsePanel" Width="1024px">
    
    <script runat="server">

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
    </script>
    <asp:ScriptManager id="ScriptManager1" runat="server">
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
            Save Status
        </asp:Panel>
        <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label><br />
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
            Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    
    <br />
    

        <table style="width: 898px">
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label3" runat="server" SkinID="Unicodelbl" Text="मुद्दाको प्रकार"
                        Width="105px"></asp:Label>
                </td>
                <td style="width: 100px">
                    <asp:DropDownList ID="ddlCaseType" runat="server" DataTextField="CaseTypeName" DataValueField="CaseTypeID"
                        SkinID="Unicodeddl" Width="150px">
                    </asp:DropDownList></td>
                <td style="width: 100px">
                    <asp:Label ID="Label5" runat="server" SkinID="Unicodelbl" Text="दर्ता मिति" Width="105px"></asp:Label></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtRegDate" runat="server" MaxLength="35" SkinID="PCStxt" ToolTip="First Name"
                        Width="130px"></asp:TextBox>
                    <ajaxToolkit:MaskedEditExtender ID="Maskededitextender4" runat="server" AutoComplete="False"
                        ClearMaskOnLostFocus="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtRegDate">
                    </ajaxToolkit:MaskedEditExtender>
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="वादिको नाम" Width="105px"></asp:Label></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtAppelantName" runat="server" MaxLength="35" SkinID="PCStxt" ToolTip="First Name"
                        Width="225px"></asp:TextBox></td>
                <td style="width: 100px">
                    <asp:Label ID="Label6" runat="server" SkinID="Unicodelbl" Text="प्रतिवादिको नाम"
                        Width="115px"></asp:Label></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtRespondantName" runat="server" MaxLength="35" SkinID="PCStxt"
                        ToolTip="First Name" Width="225px"></asp:TextBox></td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 26px;">
                </td>
                <td style="width: 100px; height: 26px;">
                </td>
                <td style="width: 100px; height: 26px;">
                </td>
                <td style="width: 100px; height: 26px;">
                </td>
                <td style="width: 100px; height: 26px;" align="right">
                    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" SkinID="Normal"
                        Text="Search" Width="68px" /></td>
                <td style="width: 100px; height: 26px;">
                    <asp:Button ID="btnCancelSearch" runat="server" OnClick="btnCancelSearch_Click" SkinID="Cancel"
                        Text="Cancel" Width="68px" /></td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:Label ID="lblSearch" runat="server" SkinID="Unicodelbl"></asp:Label><asp:Panel ID="pnlCase" runat="server" ScrollBars="Auto" Width="1000px" Height="150px">
                        <%--<div id="divGrid" style="border-width:5px; overflow: auto;width:1000px; height: 470px">--%>
                        <asp:GridView ID="grdCase" runat="server" AutoGenerateColumns="False" CellPadding="0"
                            ForeColor="#333333" Height="150px" OnRowDataBound="grdCase_RowDataBound" OnSelectedIndexChanged="grdCase_SelectedIndexChanged"
                            SkinID="Unicodegrd" Width="983px">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="CaseTypeID" HeaderText="Case Type ID" />
                                <asp:BoundField DataField="CaseRegDate" HeaderText="दर्ता मिति" />
                                <asp:BoundField DataField="CaseID" HeaderText="CaseID" />
                                <asp:BoundField DataField="RegNo" HeaderText="दर्ता नं" />
                                <asp:BoundField DataField="CaseNo" HeaderText="मुद्दा नं" />
                                <asp:BoundField DataField="CaseTypeName" HeaderText="मुद्दाको प्रकार" />
                                <asp:BoundField DataField="Appelant" HeaderText="वादिहारु" />
                                <asp:BoundField DataField="Respondant" HeaderText="प्रतिवादिहारु" />
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                                            Text="Select"></asp:LinkButton>
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
                        <%--</div>--%>
                    </asp:Panel>
                </td>
            </tr>
        </table>
   
        
    </asp:Panel>
                
                
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 21px;" align="center">
                </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:Panel ID="pnlCaseInfo" runat="server" Visible="False" Width="125px">
            
            
            
            
            
            
            
            <table style="width: 944px">
        <tr>
            <td style="width: 100px">
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
                            <asp:Label ID="Label4" runat="server" SkinID="Unicodelbl" Text="मुद्दाको किसिम" Width="105px"></asp:Label></td>
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
                            <asp:Label ID="Label7" runat="server" SkinID="Unicodelbl" Text="दर्ता किताब" Width="87px"></asp:Label></td>
                        <td style="width: 200px; height: 21px;">
                            <asp:Label ID="lblRegDiary" runat="server" Text="Label" SkinID="UnicodeDisplaylbl"></asp:Label></td>
                        <td style="width: 100px; height: 21px;">
                            <asp:Label ID="Label8" runat="server" SkinID="Unicodelbl" Text="मुद्दाको विषय" Width="95px"></asp:Label></td>
                        <td style="width: 150px; height: 21px;">
                            <asp:Label ID="lblRegSubject" runat="server" Text="Label" SkinID="UnicodeDisplaylbl"></asp:Label></td>
                        <td style="width: 100px; height: 21px;">
                            <asp:Label ID="Label200" runat="server" SkinID="Unicodelbl" Text="मुद्दाको नाम" Width="85px"></asp:Label></td>
                        <td style="width: 100px; height: 21px;">
                            <asp:Label ID="lblRegSubName" runat="server" Text="Label" SkinID="UnicodeDisplaylbl"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 100px;" valign="top">
                            <asp:Label ID="Label42" runat="server" SkinID="Unicodelbl" Text="दर्ता मिति" Width="77px"></asp:Label></td>
                        <td style="width: 150px;" valign="top">
                            <asp:Label ID="lblRegDate" runat="server" Text="Label" SkinID="UnicodeDisplaylbl"></asp:Label></td>
                        <td style="width: 100px;" valign="top">
                            <asp:Label ID="Label43" runat="server" SkinID="Unicodelbl" Text="अगाडि बढ्ने विधि"
                                Width="131px"></asp:Label></td>
                        <td style="width: 200px;" valign="top">
                            <asp:Label ID="lblPreceedingType" runat="server" Text="Label" SkinID="UnicodeDisplaylbl"></asp:Label></td>
                        <td style="width: 100px;" valign="top">
                            <asp:Label ID="Label25" runat="server" SkinID="Unicodelbl" Text="लेखा शाखामा पठाउने"
                                Width="146px"></asp:Label></td>
                        <td style="width: 100px;" valign="top">
                            <asp:Label ID="lblForwardToAccount" runat="server" Text="Label" SkinID="UnicodeDisplaylbl"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="6" style="height: 227px">
                            <asp:Panel ID="pnlAccountInfo" runat="server" Width="500px">
                                <table style="width: 931px">
                                    <tr>
                                        <td align="center" colspan="4">
                                            <asp:Label ID="Label17" runat="server" SkinID="UnicodeHeadlbl" Text="लेखाको विवरण"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:GridView ID="grdAccountFWD" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                ForeColor="#333333" GridLines="None" OnRowDataBound="grdAccountFWD_RowDataBound" >
                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <Columns>
                                                    <asp:BoundField DataField="AccountTypeID" HeaderText="AccountTypeID" />
                                                    <asp:BoundField DataField="AccountTypeName" HeaderText="खाताको किसिम" />
                                                    <asp:BoundField DataField="TotalAmount" HeaderText="तिर्नु पर्ने रकम" />
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkFeePaid" runat="server" Checked='<%# Eval("PaidYN") %>' Enabled="False"  />
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
                        <td colspan="6">
                            <asp:Panel ID="pnlCheckList" runat="server" Width="500px">
                                <table style="width: 931px">
                                    <tr>
                                        <td align="center" style="width: 950px">
                                            <asp:Label ID="Label19" runat="server" Text="चेक लिष्टको विवरण" SkinID="UnicodeHeadlbl"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px">
                                            <asp:GridView ID="grdCheckList" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                ForeColor="#333333" GridLines="None" 
                                                Width="450px" OnRowDataBound="grdCheckList_RowDataBound">
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
                        <td align="right" style="width: 236px">
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
                            <asp:Label ID="Label9" runat="server" SkinID="UnicodeHeadlbl" Text="वादिको विवरण"></asp:Label></td>
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
                        <td style="width: 100px" align="right"></td>
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
                            <asp:Label ID="Label10" runat="server" SkinID="UnicodeHeadlbl" Text="प्रतिवादिको विवरण"></asp:Label></td>
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
                        <td style="width: 436px; height: 21px;" align="right"></td>
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
                            <asp:Label ID="Label11" runat="server" SkinID="UnicodeHeadlbl" Text="वकिलको विवरण"></asp:Label></td>
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
                        <td style="width: 436px" align="right"></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 21px;">
                <table style="width: 934px">
                    <tr>
                        <td align="center" colspan="6">
                            <asp:Label ID="Label12" runat="server" SkinID="UnicodeHeadlbl" Text="साक्षीको विवरण"></asp:Label></td>
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
                        <td style="width: 436px" align="right"></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <table style="width: 936px">
                    <tr>
                        <td align="center" colspan="6" style="height: 21px">
                            <asp:Label ID="Label13" runat="server" SkinID="UnicodeHeadlbl" Text="सबुतको विवरण"></asp:Label></td>
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
                        <td style="width: 436px" align="right"></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <table style="width: 937px">
                    <tr>
                        <td align="center" colspan="6">
                            <asp:Label ID="Label14" runat="server" SkinID="UnicodeHeadlbl" Text="कागज-पत्रको विवरण"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <asp:GridView ID="grdLitDocument" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                ForeColor="#333333" GridLines="None" OnDataBound="grdLitDocument_DataBound" OnRowDataBound="grdLitDocument_RowDataBound"
                                OnRowDeleting="grdLitDocument_RowDeleting" SkinID="MergedGrid" Width="757px">
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
                        <td style="width: 436px" align="right"></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <table style="width: 937px">
                    <tr>
                        <td align="center" colspan="2" style="height: 21px">
                            <asp:Label ID="Label15" runat="server" SkinID="UnicodeHeadlbl" Text="केशको संक्षिप्त विवरण"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;<asp:Panel ID="Panel1" runat="server" BackColor="#E7E2E2" Width="757px">
                            <asp:Literal ID="litCaseSummary" runat="server"></asp:Literal></asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                        </td>
                        <td style="width: 836px" align="right"></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 21px;">
                <table style="width: 701px">
                    <tr>
                        <td style="width: 100px">
                            <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="प्रमाणित गर्ने / नगर्ने"
                                Width="143px"></asp:Label></td>
                        <td style="width: 100px">
                            <asp:DropDownList ID="ddlVerify" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlVerify_SelectedIndexChanged"
                                SkinID="Unicodeddl">
                                <asp:ListItem Value="0">छान्नहोस</asp:ListItem>
                                <asp:ListItem Value="Y">प्रमाणित गर्ने</asp:ListItem>
                                <asp:ListItem Value="N">प्रमाणित नगर्ने</asp:ListItem>
                            </asp:DropDownList></td>
                        <td style="width: 100px">
                        </td>
                        <td style="width: 100px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            <asp:Label ID="Label16" runat="server" SkinID="Unicodelbl" Text="प्रमाणित मिति"></asp:Label></td>
                        <td style="width: 100px">
                            <asp:TextBox ID="txtVerifiedDate" runat="server" Columns="12" SkinID="Unicodetxt"></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender ID="medVerifiedDate" runat="server" AutoComplete="False"
                                Mask="9999/99/99" MaskType="Date" TargetControlID="txtVerifiedDate">
                            </ajaxToolkit:MaskedEditExtender>
                        </td>
                        <td style="width: 100px">
                        </td>
                        <td style="width: 100px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px" valign="top">
                            <asp:Label ID="lblDarpit" runat="server" Text="दरपिट" Visible="False" SkinID="Unicodelbl"></asp:Label></td>
                        <td colspan="3">
                            <asp:TextBox ID="txtDarpit" runat="server" Height="122px" TextMode="MultiLine" Visible="False"
                                Width="748px" SkinID="Unicodetxt"></asp:TextBox></td>
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
                    </tr>
                </table>
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
        <tr>
            <td style="width: 950px" align="right">
                <table>
                    <tr>
                        <td style="width: 100px">
                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" SkinID="Cancel"
                                Text="Cancel" />
                        </td>
                        <td align="left" style="width: 100px">
                            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" SkinID="Normal"
                                Text="Submit" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
        </tr>
    </table>

</asp:Content>

