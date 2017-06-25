<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true"
    CodeFile="InvMinaha.aspx.cs" Inherits="MODULES_OAS_Inventry_Forms_InvMinaha"
    Title="OAS | Write-Off (Minaaha)" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    <asp:ScriptManager runat="server" ID="sct">
    </asp:ScriptManager>
    <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="programmaticModalPopup" BehaviorID="programmaticModalPopupBehavior"
        TargetControlID="hiddenTargetControlForModalPopup" PopupControlID="programmaticPopup"
        BackgroundCssClass="modalBackground" DropShadow="True" PopupDragHandleControlID="programmaticPopupDragHandle"
        RepositionMode="RepositionOnWindowScroll">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel runat="server" CssClass="modalPopup" ID="programmaticPopup" Style="display: none;
        width: 350px; padding: 10px">
        <asp:Panel runat="Server" ID="programmaticPopupDragHandle" Style="cursor: move; background-color: #DDDDDD;
            border: solid 1px Gray; color: Black; text-align: center;">
            Save Status
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
    <asp:Label ID="lblStatus" runat="server" Font-Bold="True" SkinID="Unicodelbl"></asp:Label>
    <table width="900">
        <tr>
            <td style="width: 160px">
            </td>
            <td style="width: 100px" valign="top">
                <asp:Label ID="lblAuctionDate" runat="server" Text="मीनहा मिति" SkinID="Unicodelbl"
                    Width="99px"></asp:Label></td>
            <td colspan="5" valign="top">
                <table>
                    <tr>
                        <td style="width: 100px">
                            <asp:TextBox ID="txtMinahaDate" runat="server" SkinID="Unicodetxt" Width="73px"></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtMinahaDate"
                                AutoComplete="False" Mask="9999/99/99" MaskType="Date">
                            </ajaxToolkit:MaskedEditExtender>
                        </td>
                        <%--<td style="width: 100px">
                            <asp:Label ID="Label1" runat="server" Text="येपरबल मिति" SkinID="Unicodelbl" Width="99px"></asp:Label>
                        </td>--%>
                        <%--<td style="width: 100px">
                            <asp:TextBox ID="txtApprovalDate" runat="server" SkinID="Unicodetxt" Width="73px"></asp:TextBox>
                        </td>
                        <td style="width: 100px">
                            <asp:Label ID="Label5" runat="server" Text="येपरबल दिने मानिस" SkinID="Unicodelbl"
                                Width="99px"></asp:Label>
                        </td>
                        <td style="width: 100px">
                            <asp:TextBox ID="txtAppby" runat="server" SkinID="Unicodetxt" Width="73px"></asp:TextBox>
                        </td>
                        <td style="width: 100px">
                            <asp:Label ID="Label8" runat="server" Text="yes no" SkinID="Unicodelbl" Width="99px"></asp:Label>
                        </td>
                        <td style="width: 100px">
                            <asp:CheckBox ID="chkyesNo" runat="server" />
                        </td>--%>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 160px">
            </td>
            <td colspan="6">
                <hr />
            </td>
        </tr>
        <tr>
            <td style="width: 160px">
            </td>
            <td style="width: 100px" valign="top">
                <asp:Label ID="Label2" runat="server" Text="समुह" SkinID="Unicodelbl"></asp:Label></td>
            <td style="width: 100px" valign="top">
                <asp:DropDownList ID="ddlItemCategory" runat="server" AutoPostBack="True" SkinID="Unicodeddl"
                    Width="154px" OnSelectedIndexChanged="ddlItemCategory_SelectedIndexChanged">
                </asp:DropDownList></td>
            <td style="width: 100px" valign="top">
                <asp:Label ID="Label3" runat="server" Text="उप-समुह" SkinID="Unicodelbl"></asp:Label></td>
            <td style="width: 100px" valign="top">
                <asp:DropDownList ID="ddlItemSubCategory" runat="server" SkinID="Unicodeddl" Width="153px"
                    OnSelectedIndexChanged="ddlItemSubCategory_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList></td>
            <td style="width: 100px" valign="top">
                <asp:Label ID="Label4" runat="server" Text="सामान" SkinID="Unicodelbl"></asp:Label></td>
            <td valign="top">
                <asp:DropDownList ID="ddlItem" runat="server" SkinID="Unicodeddl" Width="155px" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 160px">
            </td>
            <td style="width: 100px" valign="top">
            </td>
            <td style="width: 100px" valign="top">
            </td>
            <td style="width: 100px" valign="top">
            </td>
            <td style="width: 100px" valign="top">
            </td>
            <td style="width: 100px" valign="top">
                <asp:Label ID="Label7" runat="server" Text="विवरण" SkinID="Unicodelbl"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtRemarks" runat="server" Height="83px" SkinID="Unicodetxt" TextMode="MultiLine"
                    Width="221px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 160px">
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
            <td valign="top">
                <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" SkinID="Add" /></td>
        </tr>
        <tr>
            <td style="width: 160px; height: 19px">
            </td>
            <td colspan="6" style="height: 19px">
                <hr />
                <asp:Panel ID="pblData" runat="server" Height="200px" ScrollBars="Auto" Width="900px">
                    <asp:GridView ID="grdMinahaList" runat="server" AutoGenerateColumns="False" CellPadding="0"
                        ForeColor="#333333" GridLines="None" Width="559px" OnSelectedIndexChanged="grdMinahaList_SelectedIndexChanged"
                        OnRowDeleting="grdMinahaList_RowDeleting">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:BoundField DataField="OrgID" HeaderText="OrgID" />
                            <asp:BoundField DataField="WriteOffSEQ" HeaderText="WriteOffSEQ" />
                            <asp:BoundField DataField="ItemsCategoryID" HeaderText="ItemsCategoryID" />
                            <%--<asp:BoundField DataField="ItemsCategoryName" HeaderText="CategoryName" />--%>
                            <asp:BoundField DataField="ItemsSubCategoryID" HeaderText="ItemsSubCategoryID" />
                            <asp:BoundField DataField="ItemsID" HeaderText="ItemsID" />
                            <asp:BoundField DataField="SeqNo" HeaderText="SeqNo" />
                            <%--<asp:BoundField DataField="AuctionDate" HeaderText="मिनहा मिति" />--%>
                            <asp:BoundField DataField="Remarks" HeaderText="विवरण" />
                            <asp:BoundField DataField="Action" HeaderText="Action"></asp:BoundField>
                            <asp:CommandField ShowSelectButton="True">
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                            </asp:CommandField>
                            <asp:CommandField ShowDeleteButton="True">
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                            </asp:CommandField>
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
        <tr>
            <td style="width: 160px">
            </td>
            <td style="width: 100px">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" SkinID="Normal" OnClick="btnSubmit_Click" /></td>
            <td style="width: 100px">
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                    SkinID="Cancel" /></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td>
            </td>
        </tr>
    </table>
    <br />
    &nbsp;
</asp:Content>
