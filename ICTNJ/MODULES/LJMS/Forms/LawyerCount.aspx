<%@ Page AutoEventWireup="true" CodeFile="LawyerCount.aspx.cs" EnableEventValidation="false" Inherits="MODULES_LJMS_Forms_LawyerCount" Language="C#" MasterPageFile="~/MODULES/LJMS/LJMSMasterPage.master"
    Title="NBA | Lawyer Count" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground" DropShadow="True" PopupControlID="programmaticPopup"
        PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForModalPopup">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none; width: 350px; padding: 10px">
        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD; border: solid 1px Gray; color: Black; text-align: center;">
            Save Status
        </asp:Panel>
        <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label><br />
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click" Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    <br />
    <div style="width: 100%; min-height: 550px; padding-left: 10px">
        <table width="650">
            <tr>
                <td style="width: 350px; height: 26px;" valign="top">
                    <asp:Label ID="Label4" runat="server" SkinID="UnicodeHeadlbl" Text="नेपाल बार एशोसिएशन"></asp:Label></td>
                <td style="width: 300px; height: 26px;" valign="top">
                    <asp:Label ID="Label5" runat="server" SkinID="UnicodeHeadlbl" Text="नेपाल बार काउन्सिल"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 350px" valign="top">
                    <table width="300">
                        <tr>
                            <td style="width: 100px;">
                                <asp:Label ID="Label1" runat="server" SkinID="LJMSlbl" Text="प्रकार"></asp:Label></td>
                            <td style="width: 200px">
                                <asp:DropDownList ID="ddlLawyerType" runat="server" SkinID="Ljmsddl" Width="200px">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 200px" align="right">
                                <asp:Button ID="btnSearchLawyer" runat="server" OnClick="btnSearchLawyer_Click" SkinID="Normal" Text="Search" />
                                <asp:Button ID="btnPreview" runat="server" OnClick="btnPreview_Click" SkinID="Normal" Text="Preview" /></td>
                        </tr>
                    </table>
                </td>
                <td style="width: 300px" valign="top">
                    <table width="300">
                        <tr>
                            <td style="width: 100px;">
                                <asp:Label ID="Label3" runat="server" SkinID="LJMSlbl" Text="एकाई"></asp:Label></td>
                            <td style="width: 200px">
                                <asp:DropDownList ID="ddlUnit" runat="server" SkinID="Ljmsddl" Width="200px">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                                <asp:Label ID="Label2" runat="server" SkinID="LJMSlbl" Text="प्रकार"></asp:Label></td>
                            <td style="width: 200px">
                                <asp:DropDownList ID="ddlPLawyerType" runat="server" SkinID="Ljmsddl" Width="200px">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 200px" align="right">
                                <asp:Button ID="btnPSearch" runat="server" OnClick="btnPSearch_Click" SkinID="Normal" Text="Search" />
                                <asp:Button ID="btnPrivatePreview" runat="server" OnClick="btnPrivatePreview_Click" SkinID="Normal" Text="Preview" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <asp:Panel ID="pnlRecord" runat="server" Height="300px" Width="700px">
            <table width="650">
                <tr>
                    <td style="width: 200px">
                        <asp:Label ID="lblCount" runat="server" SkinID="LJMSlbl"></asp:Label></td>
                    <td align="right" style="width: 450px">
                        <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" SkinID="Dynamic" Text="Export to Excel" Visible="False" Width="120px" /></td>
                </tr>
            </table>
            <asp:GridView ID="grdCount" runat="server" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333" OnDataBound="grdCount_DataBound"
                OnRowDataBound="grdCount_RowDataBound" SkinID="LJMSgrd" Width="650px">
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <Columns>
                    <asp:BoundField DataField="UnitName" HeaderText="एकाई" />
                    <asp:BoundField DataField="LawyerTypeName" HeaderText="वकिलको किसिम" />
                    <asp:BoundField DataField="RDGender" HeaderText="लिं" >
                    </asp:BoundField>
                    <asp:BoundField DataField="Total" HeaderText="जम्मा वकिल">
                        <ItemStyle Width="120px" />
                    </asp:BoundField>
                </Columns>
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <EditRowStyle BackColor="#999999" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
        </asp:Panel>
    </div>
</asp:Content>
