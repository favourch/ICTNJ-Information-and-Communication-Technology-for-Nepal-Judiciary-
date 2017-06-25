<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true" CodeFile="AuctionApprove.aspx.cs" Inherits="MODULES_OAS_Inventory_Forms_AuctionApprove" Title="OAS | Auction(Lilaam) Approve" %>
<%@ Register 
    Assembly="AjaxControlToolkit" 
    Namespace="AjaxControlToolkit" 
    TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
            <asp:Label ID="lblStatus" runat="server" SkinID="Unicodelbl" Text="Status"></asp:Label></asp:Panel>
        <asp:Label ID="lblStatusMessage" runat="server" SkinID="Unicodelbl" Text="Label"></asp:Label><br />
        <asp:Button ID="OkButton" runat="server" 
            Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    &nbsp;&nbsp;<br />
    &nbsp; &nbsp; &nbsp;&nbsp;
    <asp:Label ID="lblHeading" runat="server" SkinID="UnicodeHeadlbl" Text="निलामी (खर्च नहुने सामान)स्विर्कति" Height="23px"></asp:Label><br /><br />
    <table width="900">
        <tr>
            <td style="width: 11px">
            </td>
            <td style="width: 75px">
                <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="निलामीहुने मिति" Width="118px"></asp:Label></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 11px">
            </td>
            <td colspan="4">
                <asp:Panel ID="pnlTop" runat="server" Height="150px" ScrollBars="Auto" Width="500px">
                    <asp:GridView ID="grdAuctionDateDetails" runat="server" AutoGenerateColumns="False"
                        CellPadding="0" ForeColor="#333333" GridLines="None" SkinID="Unicodegrd" Width="500px" OnSelectedIndexChanged="grdAuctionDateDetails_SelectedIndexChanged">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:BoundField DataField="AuctionSeq" HeaderText="क्र.सं">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AuctionDate" HeaderText="निलामी मिति">
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
    </table>
    <table width="900">
        <tr>
            <td style="width: 10px">
            </td>
            <td colspan="2" valign="top">
                <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="निलामीहुने वस्तुको विवरण" Width="193px"></asp:Label></td>
            <td style="width: 175px" valign="top">
            </td>
            <td style="width: 100px" valign="top">
            </td>
            <td style="width: 100px" valign="top">
            </td>
            <td valign="top">
            </td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td style="width: 100px" valign="top">
                <asp:Label ID="lblAuctionDate" runat="server" SkinID="Unicodelbl" Text="निलामी मिति"
                    Width="99px"></asp:Label></td>
            <td style="width: 100px" valign="top">
                <asp:TextBox ID="txtAuctionDate" runat="server" Height="15px" SkinID="Unicodetxt"
                    Width="73px"></asp:TextBox>
                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AutoComplete="False"
                    Mask="9999/99/99" MaskType="Date" TargetControlID="txtAuctionDate">
                </ajaxToolkit:MaskedEditExtender>
            </td>
            <td style="width: 175px" valign="top">
            </td>
            <td style="width: 100px" valign="top">
            </td>
            <td style="width: 100px" valign="top">
            </td>
            <td valign="top">
            </td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td style="width: 100px" valign="top">
                <asp:Label ID="Label4" runat="server" SkinID="Unicodelbl" Text="समुह"></asp:Label></td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddlItemCategory" runat="server" AutoPostBack="True"
                    SkinID="Unicodeddl" Width="154px">
                </asp:DropDownList></td>
            <td style="width: 175px" valign="top">
                <asp:Label ID="Label5" runat="server" SkinID="Unicodelbl" Text="उप-समुह"></asp:Label></td>
            <td style="width: 100px" valign="top">
                <asp:DropDownList ID="ddlItemSubCategory" runat="server" AutoPostBack="True"
                    SkinID="Unicodeddl" Width="153px">
                </asp:DropDownList></td>
            <td style="width: 100px" valign="top">
                <asp:Label ID="Label6" runat="server" SkinID="Unicodelbl" Text="सामान"></asp:Label></td>
            <td valign="top">
                <asp:DropDownList ID="ddlItem" runat="server" SkinID="Unicodeddl" Width="200px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td style="width: 100px" valign="top">
                <asp:Label ID="Label9" runat="server" SkinID="Unicodelbl" Text="निलामी मुल्य" Width="94px"></asp:Label></td>
            <td style="width: 100px" valign="top">
                <asp:TextBox ID="txtAuctionPrice" runat="server" SkinID="Unicodetxt" Width="103px"></asp:TextBox>
                <asp:Label ID="Label7" runat="server" SkinID="Unicodelbl" Text="रु."></asp:Label>
                <asp:Label ID="Label8" runat="server" SkinID="Unicodelbl" Text="/-"></asp:Label>
                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                    FilterType="Numbers" TargetControlID="txtAuctionPrice">
                </ajaxToolkit:FilteredTextBoxExtender>
            </td>
            <td style="width: 175px" valign="top">
                <asp:Label ID="Label10" runat="server" SkinID="Unicodelbl" Text="निलामी जित्ने व्यक्ति/संस्था"
                    Width="175px"></asp:Label></td>
            <td style="width: 100px" valign="top">
                <asp:TextBox ID="txtAuctionWinner" runat="server" SkinID="Unicodetxt"></asp:TextBox></td>
            <td style="width: 100px" valign="top">
                <asp:Label ID="Label11" runat="server" SkinID="Unicodelbl" Text="विवरण"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtDescription" runat="server" Height="82px" MaxLength="300" SkinID="Unicodetxt"
                    TextMode="MultiLine" Width="197px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 175px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td valign="top">
                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" SkinID="Add" Text="Add"
                    Width="37px" /></td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td colspan="6">
                <hr />
                <br />
                <asp:Panel ID="PnlSecond" runat="server" Height="150px" Width="900px" ScrollBars="Auto">
                <asp:GridView ID="grdAuctionDetails" runat="server" AutoGenerateColumns="False" CellPadding="0"
                    ForeColor="#333333" GridLines="None" SkinID="Unicodegrd" Width="800px" OnSelectedIndexChanged="grdAuctionDetails_SelectedIndexChanged" OnRowCreated="grdAuctionDetails_RowCreated">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="OrgID" HeaderText="OrgID" />
                        <asp:BoundField DataField="OrgName" HeaderText="कार्यालय" />
                        <asp:BoundField DataField="AuctionSequence" HeaderText="क्र.सं" />
                        <asp:BoundField DataField="ItemsCategoryID" HeaderText="ItemsCategoryID" />
                        <asp:BoundField DataField="ItemsCategoryName" HeaderText="समुह" />
                        <asp:BoundField DataField="ItemsSubCategoryID" HeaderText="ItemsSubCategoryID" />
                        <asp:BoundField DataField="ItemsSubCategoryName" HeaderText="उप-समुह" />
                        <asp:BoundField DataField="ItemsID" HeaderText="ItemsID" />
                        <asp:BoundField DataField="ItemsName" HeaderText="सामान" />
                        <asp:BoundField DataField="AuctionDate" HeaderText="निलामी मिति" />
                        <asp:BoundField DataField="AuctionAmount" HeaderText="निलामी मुल्य" />
                        <asp:BoundField DataField="AuctionWinner" HeaderText="निलामी जित्ने व्यक्ति/संस्था" />
                        <asp:BoundField DataField="Remarks" HeaderText="विवरण" />
                        <asp:BoundField DataField="Action" HeaderText="Action" />
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
                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" AutoComplete="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtCurrentDate">
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

