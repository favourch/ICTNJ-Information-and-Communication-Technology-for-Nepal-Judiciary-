<%@ Page Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" AutoEventWireup="true" CodeFile="Bench.aspx.cs" Inherits="MODULES_CMS_Bench_Bench" Title="CMS | Bench" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   <script language="javascript" src="../../COMMON/JS/Validation.js" type="text/javascript"></script>
        <script language="javascript" src="../../COMMON/JS/Validation.js" type="text/javascript"></script>
    <script language="javascript" src="../../COMMON/JS/DateValidator.js" type="text/javascript"></script>
    <script language="javascript" src="../../COMMON/JS/EnglishDateValidator.js" type="text/javascript"></script>

    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
    <ajaxtoolkit:modalpopupextender id="programmaticModalPopup" runat="server" backgroundcssclass="modalBackground"
        behaviorid="programmaticModalPopupBehavior" dropshadow="True" popupcontrolid="programmaticPopup"
        popupdraghandlecontrolid="programmaticPopupDragHandle" repositionmode="RepositionOnWindowScroll"
        targetcontrolid="hiddenTargetControlForModalPopup">
        </ajaxtoolkit:modalpopupextender>
    <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none;
        width: 350px; padding: 10px">
        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD;
            border: solid 1px Gray; color: Black; text-align: center;">
            Save Status
        </asp:Panel>
        <asp:UpdatePanel id="UpdatePanel2" runat="server">
            <contenttemplate>
        <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
</contenttemplate>
        </asp:UpdatePanel>
        <br />
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
            Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    <br />
    <table style="width: 829px">
        <tr>
            <td style="width: 100px" valign="top">
            </td>
            <td colspan="3" valign="top">
            </td>
        </tr>
        <tr>
            <td rowspan="4" style="width: 100px" valign="top">
                <asp:Panel ID="Panel1" runat="server" Height="350px" ScrollBars="Auto" Width="300px">
                    <asp:ListBox ID="lstOrganization" runat="server" Height="350px" SkinID="Unicodelst"
                        Width="300px" AutoPostBack="True" OnSelectedIndexChanged="lstOrganization_SelectedIndexChanged"></asp:ListBox></asp:Panel>
            </td>
            <td align="left" colspan="3" rowspan="4" valign="top">
                &nbsp;<table style="width: 400px">
                    <tr>
                        <td valign="top" style="height: 6px">
                            <asp:Label ID="Label3" runat="server" SkinID="Unicodelbl" Text="बेन्च विवरण" Width="84px"></asp:Label></td>
                        <td style="width: 100px; height: 6px;" valign="top">
                            <asp:TextBox ID="txtBenchDesc_RQD" runat="server" SkinID="Unicodetxt" Width="350px" Height="48px" TextMode="MultiLine"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="सक्रिय"></asp:Label></td>
                        <td style="width: 100px" valign="top">
                            <asp:CheckBox ID="chkActive" runat="server" SkinID="smallChk" /></td>
                    </tr>
                    <tr>
                        <td valign="top">
                        </td>
                        <td align="right" style="width: 100px" valign="top">
                            <asp:HiddenField ID="hdnBenchID" runat="server" />
                            <asp:Button ID="btnAdd" runat="server" SkinID="Add" Text="+" OnClick="btnAdd_Click" Width="31px" /></td>
                    </tr>
                    <tr>
                        <td colspan="2" valign="top">
                            &nbsp;<asp:Panel ID="Panel2" runat="server" Height="100px" Width="400px">
                            <asp:GridView ID="grdBench" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                ForeColor="#333333" GridLines="None" SkinID="Unicodegrd" Width="400px" OnRowDataBound="grdBench_RowDataBound" OnRowDeleting="grdBench_RowDeleting" OnSelectedIndexChanged="grdBench_SelectedIndexChanged">
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="OrgID" HeaderText="Org ID" />
                                    <asp:BoundField DataField="BenchNO" HeaderText="बेन्च नं." />
                                    <asp:BoundField DataField="BenchDesc" HeaderText="विवरण" />
                                    <asp:BoundField DataField="Active" HeaderText="सक्रिय" />
                                    <asp:BoundField DataField="Action" HeaderText="Action" />
                                    <asp:CommandField ShowSelectButton="True" />
                                    <asp:CommandField ShowDeleteButton="True" DeleteText="Remove" />
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
                        <td align="right" colspan="2" valign="top">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="2" valign="top">
                            <asp:Button ID="btnSubmit" runat="server" SkinID="Normal" Text="Submit" OnClick="btnSubmit_Click" />
                            <asp:Button ID="btnCancel" runat="server" SkinID="Cancel" Text="Cancel" OnClick="btnCancel_Click" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
        </tr>
        <tr>
        </tr>
        <tr>
        </tr>
    </table>
</asp:Content>

