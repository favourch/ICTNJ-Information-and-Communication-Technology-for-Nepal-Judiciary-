<%@ Page Language="C#" MasterPageFile="~/MODULES/LJMS/LJMSMasterPage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="DuplicateEntry.aspx.cs" Inherits="MODULES_LJMS_Forms_DuplicateEntry" Title="NBA | Duplicate Entry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
    <ajaxtoolkit:modalpopupextender id="programmaticModalPopup" runat="server" backgroundcssclass="modalBackground" dropshadow="True"
        popupcontrolid="programmaticPopup" popupdraghandlecontrolid="programmaticPopupDragHandle" repositionmode="RepositionOnWindowScroll"
        targetcontrolid="hiddenTargetControlForModalPopup">
    </ajaxtoolkit:modalpopupextender>
    <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none; width: 350px; padding: 10px">
        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD; border: solid 1px Gray;
            color: Black; text-align: center;">
            Save Status
        </asp:Panel>
        <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label><br />
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click" Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    <br />
    <div style="width:100%; height:auto">
        <table style="width: 650px; position: static; height: 96px">
            <tr>
                <td style="width: 6px; height: 26px">
                </td>
                <td style="width: 289px; height: 26px">
                    <asp:Label ID="Label1" runat="server" SkinID="UnicodeHeadlbl" Text="Duplicate Entry"></asp:Label></td>
                <td style="width: 90px; height: 26px">
                </td>
                <td style="height: 26px">
                </td>
            </tr>
            <tr>
                <td style="width: 6px">
                </td>
                <td style="width: 289px">
                    <asp:CheckBox ID="chkLicenseNo" runat="server" Text="लाईसेन्स नं" SkinID="smallChk" /></td>
                <td style="width: 90px">
                    <asp:Label ID="Label2" runat="server" Text="इकाई" SkinID="LJMSlbl"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddlUnit" runat="server" SkinID="Ljmsddl" Width="225px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 6px">
                </td>
                <td style="width: 289px">
                    <asp:CheckBox ID="chkLType" runat="server" Text="वकिलको प्रकार" SkinID="smallChk" /></td>
                <td style="width: 90px">
                    <asp:Label ID="Label3" runat="server" Text="प्रकार" SkinID="LJMSlbl"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddlType" runat="server" SkinID="Ljmsddl" Width="225px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 6px">
                </td>
                <td style="width: 289px">
                    <asp:CheckBox ID="chkUnit" runat="server" Text="एकाई" SkinID="smallChk" /></td>
                <td style="width: 90px">
                </td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" SkinID="Normal" Text="Search" />
                    <asp:Button ID="btnCancel"
                        runat="server" OnClick="btnCancel_Click" SkinID="Cancel" Text="Cancel" /></td>
            </tr>
            <tr>
                <td style="width: 6px">
                </td>
                <td style="width: 289px">
                    <asp:CheckBox ID="chkLawyerName" runat="server" Text="वकिलको नाम" SkinID="smallChk" Visible="False" /></td>
                <td style="width: 90px">
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <asp:Label ID="lblMessage" runat="server" Font-Names="Arial" Font-Size="12pt" SkinID="UnicodeHeadlbl" Style="position: static"></asp:Label><asp:Panel
            ID="Panel1" runat="server" Height="300px" Width="100%" ScrollBars="Auto">
            <asp:GridView ID="grdDisplay" runat="server" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333" HorizontalAlign="Left"
                OnRowDataBound="grdDisplay_RowDataBound" SkinID="LJMSgrd" Width="97%">
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="सि.नं.">
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                            .
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="RDFullName" HeaderText="पुरा नाम">
                        <ItemStyle Wrap="False" />
                        <HeaderStyle Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LTYPE" HeaderText="वकिलको प्रकार">
                        <ItemStyle Wrap="False" />
                        <HeaderStyle Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LICENSENO" HeaderText="लाइसन नं.">
                        <ItemStyle Wrap="False" />
                        <HeaderStyle Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LRENEWALUPTO" HeaderText="नविकरण मिति">
                        <ItemStyle Font-Names="Verdana" Wrap="False" />
                        <HeaderStyle Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="UNITNAME" HeaderText="युनिट">
                        <ItemStyle Wrap="False" />
                        <HeaderStyle Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PLRENEWALUPTO" HeaderText="नविकरण मिति">
                        <ItemStyle Font-Names="Verdana" Wrap="False" />
                        <HeaderStyle Wrap="False" />
                    </asp:BoundField>
                </Columns>
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <EditRowStyle BackColor="#999999" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" HorizontalAlign="Left" VerticalAlign="Middle" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
        </asp:Panel>
        <br />
        <asp:Button ID="btnPrint" runat="server" OnClick="btnPrint_Click" Style="position: static" Text="Export" Width="70px" SkinID="Normal" /></div>
</asp:Content>

