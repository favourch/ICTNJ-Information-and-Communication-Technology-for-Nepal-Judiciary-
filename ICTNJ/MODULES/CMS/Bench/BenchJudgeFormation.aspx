<%@ Page Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" AutoEventWireup="true" CodeFile="BenchJudgeFormation.aspx.cs" Inherits="MODULES_CMS_Bench_BenchJudgeFormation" Title="CMS | Bench Judge Formation" %>

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
    <table style="width: 833px">
        <tr>
            <td colspan="1" valign="top">
                <asp:Label ID="Label5" runat="server" Text="बेन्च" SkinID="Unicodelbl"></asp:Label></td>
            <td colspan="2" valign="top" align="left"><asp:DropDownList ID="DDLBench_RQD" runat="server" SkinID="Unicodeddl" Width="500px">
            </asp:DropDownList></td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="Label1" runat="server" Text="बेन्च किसिम" SkinID="Unicodelbl"></asp:Label></td>
            <td valign="top" align="left">
                <asp:DropDownList ID="DDLBenchType_RQD" runat="server" SkinID="Unicodeddl" Width="200px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="Label2" runat="server" Text="मिति" SkinID="Unicodelbl"></asp:Label></td>
            <td valign="top">
                <asp:TextBox ID="txtFromDate" runat="server" SkinID="Unicodetxt" Width="100px"></asp:TextBox>
                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtFromDate" AutoComplete="False" ClearMaskOnLostFocus="False" Mask="9999/99/99" MaskType="Date">
                </ajaxToolkit:MaskedEditExtender>
            </td>
        </tr>
        <tr>
            <td colspan="2" valign="top">
            </td>
        </tr>
        <tr>
            <td colspan="2" valign="top">
                <table style="width: 831px">
                    <tr>
                        <td valign="top" align="left" style="width: 400px">
                            <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Auto" Width="400px">
                                <asp:GridView ID="grdJudge" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" SkinID="Unicodegrd" Width="400px" OnRowDataBound="grdJudge_RowDataBound">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelect" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Emp ID" DataField="EmpID" />
                                <asp:BoundField HeaderText="नाम" DataField="RDFullName" />
                                <asp:BoundField DataField="RDGender" HeaderText="लिङ्ग" />
                                <asp:BoundField DataField="DOB" HeaderText="जन्म मिति" />
                            </Columns>
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <EditRowStyle BackColor="#999999" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <EmptyDataTemplate>
                                        <asp:CheckBox ID="chkSelect" runat="server" />
                                    </EmptyDataTemplate>
                        </asp:GridView>
                            </asp:Panel>
                        </td>
                        <td align="left" colspan="2" valign="top">
                            <table>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="Label3" runat="server" Text="मिति देखि" Width="82px" SkinID="Unicodelbl"></asp:Label></td>
                                    <td valign="top">
                                        <asp:TextBox ID="txtBJFromDate" runat="server" SkinID="Unicodetxt" Width="100px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                    </td>
                                    <td valign="top" align="left">
                            </td>
                                </tr>
                            </table>
                            <ajaxToolkit:MaskedEditExtender ID="mskBJFromDate" runat="server" AutoComplete="False"
                                ClearMaskOnLostFocus="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtBJFromDate">
                            </ajaxToolkit:MaskedEditExtender>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="top" align="right" colspan="2">
                <asp:Button ID="btnSubmit" runat="server" SkinID="Normal" Text="Submit" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnCancel" runat="server" SkinID="Cancel" Text="Cancel" OnClick="btnCancel_Click" /></td>
        </tr>
    </table>

</asp:Content>

