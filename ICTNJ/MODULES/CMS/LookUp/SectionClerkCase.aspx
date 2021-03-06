<%@ Page Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" AutoEventWireup="true" CodeFile="SectionClerkCase.aspx.cs" Inherits="MODULES_CMS_LookUp_SectionClerkCase" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../UserControls/CaseSearch.ascx" TagName="CaseSearch" TagPrefix="uc1" %>


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
    <table style="width: 840px">
        <tr>
            <td align="left" valign="top" colspan="4" style="height: 1px">
                <uc1:CaseSearch id="CaseSearch1" runat="server" OnLoad="CaseSearch1_Load" DecisionYesNo="U" VerifiedYesNo="Y" >
                </uc1:CaseSearch></td>
        </tr>
        <tr>
            <td align="left" colspan="1" valign="top">
                <asp:Label ID="Label2" runat="server" SkinID="UnicodeHeadlbl" Text="शाखाहरु"></asp:Label></td>
            <td align="left" colspan="1" valign="top">
            </td>
            <td align="left" colspan="1" valign="top">
            </td>
            <td align="left" colspan="4" valign="top">
                <asp:Label ID="Label3" runat="server" SkinID="UnicodeHeadlbl" Text="कलर्कहरु"></asp:Label></td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Auto" Width="280px">
                    <asp:ListBox ID="lstOrgUnits" runat="server" AutoPostBack="True" Height="240px" OnSelectedIndexChanged="lstOrgUnits_SelectedIndexChanged"
                        SkinID="Unicodelst" Width="275px"></asp:ListBox></asp:Panel>
            </td>
            <td align="left" valign="top">
                <asp:Label ID="Label1" runat="server" Text="मिति" SkinID="Unicodelbl"></asp:Label></td>
            <td align="left" valign="top">
                <asp:TextBox ID="txtClrkFromDate_RQD" runat="server" SkinID="Unicodetxt" Width="100px"></asp:TextBox></td>
            <td align="left" valign="top">
                <asp:Panel ID="Panel2" runat="server" Height="200px" ScrollBars="Auto" Width="450px">
                    <asp:GridView ID="grdClerk" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" SkinID="Unicodegrd" Width="440px" OnRowDataBound="grdClerk_RowDataBound">
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="EMPID" HeaderText="Clerk ID" />
                            <asp:BoundField DataField="FullName" HeaderText="नाम" />
                            <asp:BoundField HeaderText="लिङ्ग" DataField="RDGender" />
                            <asp:BoundField DataField="DOB" HeaderText="जन्म मिति" />
                            <asp:BoundField HeaderText="Action" />
                        </Columns>
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <EditRowStyle BackColor="#999999" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                </asp:Panel>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" colspan="1" valign="top">
                <ajaxToolkit:MaskedEditExtender ID="mskCFD" runat="server" TargetControlID="txtClrkFromDate_RQD" AutoComplete="False" ClearMaskOnLostFocus="False" Mask="9999/99/99" MaskType="Date">
                </ajaxToolkit:MaskedEditExtender>
            </td>
            <td align="center" colspan="1" valign="top">
            </td>
            <td align="center" colspan="1" valign="top">
            </td>
            <td align="right" colspan="4" valign="top">
                <asp:Button ID="btnSubmit" runat="server" SkinID="Normal" Text="Submit" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnCancel" runat="server" SkinID="Cancel" Text="Cancel" OnClick="btnCancel_Click" /></td>
        </tr>
    </table>
    <br />

</asp:Content>

