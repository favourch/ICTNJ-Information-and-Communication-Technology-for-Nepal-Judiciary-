<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true"
    CodeFile="ApproveMinaha.aspx.cs" Inherits="MODULES_OAS_Inventry_Forms_ApproveMinaha"
    Title="OAS | Write-Off(Minaaha) Approval" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
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
            <asp:Label ID="lblStatus" runat="server" SkinID="Unicodelbl" Text="Status"></asp:Label>
        </asp:Panel>
        <asp:UpdatePanel id="UpdatePanel3" runat="server">
            <contenttemplate>
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
</contenttemplate>
        </asp:UpdatePanel>
        <br />
        <asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click"
            Width="58px" />
        <br />
    </asp:Panel>
    &nbsp;&nbsp;&nbsp;<br />
    &nbsp; 
    <asp:Label ID="lblHeading" runat="server" SkinID="UnicodeHeadlbl" Text="मिनहा (खर्च नहुने सामान)स्विर्कति"
        Height="23px"></asp:Label><br />
    <br />
    <table width="900">
        <tr>
            <td style="width: 3px">
            </td>
            <td style="width: 75px">
                <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="मिनहा हुने मिति"
                    Width="118px"></asp:Label></td>
            <td style="width: 100px">
                &nbsp;
            </td>
            
            <td style="width: 100px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 3px">
            </td>
            <td colspan="4">
                <asp:Panel ID="pnlTop" runat="server" Height="150px" ScrollBars="Auto" Width="500px">
                    <asp:GridView ID="grdMinahaDetails" runat="server" AutoGenerateColumns="False" CellPadding="0"
                        ForeColor="#333333" GridLines="None" SkinID="Unicodegrd" Width="500px" OnSelectedIndexChanged="grdMinahaDetails_SelectedIndexChanged">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:BoundField DataField="WriteOffSEQ" HeaderText="क्र.सं">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="WriteoffDate" HeaderText="मिनहा मिति">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:CommandField ShowSelectButton="True" />
                        </Columns>
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                </asp:Panel>
                <hr />
            </td>
        </tr>
        <tr>
            <td style="width: 3px">
            </td>
            <td colspan="4">
                <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="मिनहा वस्तुको विवरण"
                    Width="193px"></asp:Label></td>
        </tr>
    </table>
    <table width="900">
        <tr>
            <td style="width: 27px">
            </td>
            <td colspan="6">
                <asp:Panel ID="PnlSecond" runat="server" Height="150px" Width="900px" ScrollBars="Auto">
                    <asp:GridView ID="grdApprove" runat="server" AutoGenerateColumns="False" CellPadding="0"
                        ForeColor="#333333" GridLines="None" SkinID="Unicodegrd" Width="800px" OnRowCreated="grdApprove_RowCreated">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:BoundField DataField="OrgID" HeaderText="OrgID" />
                            <asp:BoundField DataField="OrgName" HeaderText="र्कायालय">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="WriteOffSEQ" HeaderText="क्र.सं" />
                            <asp:BoundField DataField="ItemsCategoryID" HeaderText="ItemsCategoryID" />
                            <asp:BoundField DataField="ItemsCategoryName" HeaderText="समुह" />
                            <asp:BoundField DataField="ItemsSubCategoryID" HeaderText="ItemsSubCategoryID" />
                            <asp:BoundField DataField="ItemsSubCategoryName" HeaderText="उप-समुह" />
                            <asp:BoundField DataField="ItemsID" HeaderText="ItemsID" />
                            <asp:BoundField DataField="ItemsName" HeaderText="सामान" />
                            <asp:BoundField DataField="WriteOffDate" HeaderText="मिनहा मिति" />
                            <asp:BoundField DataField="Remarks" HeaderText="विवरण" />
                        </Columns>
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td style="width: 21px">
            </td>
            <td style="width: 138px" valign="top">
                <asp:Label ID="Label3" runat="server" SkinID="Unicodelbl" Text="स्विर्कति भएको/नभएको"
                    Width="163px"></asp:Label></td>
            <td style="width: 100px" valign="top">
                <asp:CheckBox ID="chkApprove" runat="server" SkinID="smallChk" Width="114px" /></td>
            <td style="width: 100px" valign="top">
                <asp:Label ID="Label12" runat="server" SkinID="Unicodelbl" Text="आजको मिति"></asp:Label></td>
            <td style="width: 100px" valign="top">
                <asp:TextBox ID="txtCurrentDate" runat="server" SkinID="Unicodetxt" Width="73px"></asp:TextBox>
                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="9999/99/99" TargetControlID="txtCurrentDate">
                </ajaxToolkit:MaskedEditExtender>
            </td>
        </tr>
        <tr>
            <td style="width: 21px">
            </td>
            <td style="width: 138px">
                <asp:Button ID="btnSubmit" runat="server" SkinID="Normal" Text="Submit" Width="63px" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnCancel" runat="server" SkinID="Cancel" Text="Cancel" Width="63px" OnClick="btnCancel_Click" /></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
</asp:Content>
