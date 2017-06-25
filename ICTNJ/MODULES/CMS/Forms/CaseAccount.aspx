<%@ Page Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" AutoEventWireup="true" CodeFile="CaseAccount.aspx.cs" Inherits="MODULES_CMS_Forms_CaseAccount" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%--<script src="../../COMMON/CSS/StyleSheet.css">
</script>--%>
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
    <table style="width: 800px">
        <tr>
            <td valign="top">
            </td>
            <td valign="top" style="width: 75px">
            </td>
        </tr>
        <tr>
            <td valign="top">
            </td>
            <td valign="top" style="width: 75px">
            </td>
        </tr>
        <tr>
            <td style="height: 6px;" valign="top">
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Width="100%" Height="200px">
                    <asp:GridView ID="grdCaseAccount" runat="server" AutoGenerateColumns="False" CellPadding="4" 
                        ForeColor="#333333" GridLines="None" SkinID="Unicodegrd" Width="100%" OnSelectedIndexChanged="grdCaseAccount_SelectedIndexChanged" OnRowDataBound="grdCaseAccount_RowDataBound" >
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkPaid" runat="server" OnCheckedChanged="chkPaid_CheckedChanged" />
                                </ItemTemplate>
                                <ItemStyle Width="5%" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="CaseID" HeaderText="CaseID" >
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CaseName" HeaderText="मुद्दा" >
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Appellants" HeaderText="वादि" >
                                <ItemStyle Width="25%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Respondents" HeaderText="प्रतिवादि">
                                <ItemStyle Width="20%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AccountTypeID" HeaderText="Account Type ID" />
                            <asp:BoundField DataField="AccountTypeName" HeaderText="खाता" >
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TotalAmount" HeaderText="रकम" >
                                <ItemStyle Width="10%" />
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
            </td>
            <td valign="top" style="height: 6px; width: 75px;">
                <asp:Button ID="btnLoad" runat="server" OnClick="btnLoad_Click" SkinID="Normal" Text="लोड" /></td>
        </tr>
        <tr>
            <td valign="top" style="height: 219px">
                <asp:Panel ID="Panel2" runat="server" ScrollBars="Auto" Width="100%" Height="200px">
                    <asp:GridView ID="grdLitigants" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="grdLitigants_SelectedIndexChanged"
                        SkinID="Unicodegrd" Width="100%" OnRowDataBound="grdLitigants_RowDataBound">
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="CaseID" HeaderText="Case ID" />
                            <asp:BoundField DataField="LitigantID" HeaderText="Litigant ID" />
                            <asp:BoundField DataField="AttorneyID" HeaderText="Attorney ID" />
                            <asp:BoundField DataField="Name" HeaderText="नाम" />
                            <asp:BoundField DataField="RDGender" HeaderText="लिङ्ग" />
                            <asp:BoundField DataField="DOB" HeaderText="जन्म मिति" />
                            <asp:CommandField ShowSelectButton="True" />
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
            <td valign="top" style="width: 75px; height: 219px;">
            </td>
        </tr>
    </table>
    <table style="width: 800px">
        <tr>
            <td style="width: 64px" valign="top">
                <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="मिति" Width="55px"></asp:Label></td>
            <td style="width: 201px" valign="top">
                <asp:TextBox ID="txtTranDate_RQD" runat="server" SkinID="Unicodetxt" Width="130px"></asp:TextBox>
                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AutoComplete="False"
                    ClearMaskOnLostFocus="False" Mask="99/99/9999" TargetControlID="txtTranDate_RQD"
                    UserDateFormat="DayMonthYear">
                </ajaxToolkit:MaskedEditExtender>
            </td>
            <td style="width: 63px" valign="top">
                <asp:Label ID="Label4" runat="server" SkinID="Unicodelbl" Text="कैफियत" Width="60px"></asp:Label></td>
            <td valign="top">
                <asp:TextBox ID="txtRemarks" runat="server" Height="53px" SkinID="Unicodetxt" TextMode="MultiLine"
                    Width="332px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 64px" valign="top">
            </td>
            <td style="width: 201px" valign="top">
            </td>
            <td style="width: 63px" valign="top">
            </td>
            <td align="right" valign="top">
                <asp:Button ID="btnSubmit" runat="server" SkinID="Normal" Text="Submit" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnCancel" runat="server" SkinID="Cancel" Text="Cancel" OnClick="btnCancel_Click" /></td>
        </tr>
    </table>

</asp:Content>

