<%@ Page Language="C#" MasterPageFile="~/MODULES/LJMS/LJMSMasterPage.master" AutoEventWireup="true" CodeFile="Sewa.aspx.cs" Inherits="MODULES_LJMS_LookUp_Sewa" Title="LJMS | Sewa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="width:100%; height:auto">
        <asp:Label ID="lblStatus" runat="server" Font-Bold="True" SkinID="Unicodelbl"></asp:Label><br />
        <table width="700">
            <tr>
                <td style="width: 250px" valign="top">
                    <asp:ListBox ID="lstSewa" runat="server" Height="445px" Width="220px" AutoPostBack="True" OnSelectedIndexChanged="lstSewa_SelectedIndexChanged" SkinID="Unicodelst"></asp:ListBox></td>
                <td style="width: 450px" valign="top">
                    <table width="450">
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Label1" runat="server" Text="सेवा" Font-Bold="True" Font-Underline="True" SkinID="UnicodeHeadlbl"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 150px">
                                <asp:Label ID="Label2" runat="server" Text="सेवाको नाम" SkinID="Unicodelbl"></asp:Label></td>
                            <td style="width: 300px">
                                <asp:TextBox ID="txtSewaName" runat="server" Width="250px" MaxLength="48" SkinID="Unicodetxt"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 150px" height="30" valign="bottom">
                                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Underline="True" Text="समुह" SkinID="UnicodeHeadlbl"></asp:Label></td>
                            <td style="width: 300px" height="30">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 150px">
                                <asp:Label ID="Label4" runat="server" Text="समुहको नाम" SkinID="Unicodelbl"></asp:Label></td>
                            <td style="width: 300px">
                                <asp:TextBox ID="txtSamuha" runat="server" Width="250px" MaxLength="48" SkinID="Unicodetxt"></asp:TextBox>&nbsp;<asp:Button ID="btnAddSamuha" runat="server" Font-Bold="True" Text="+" Width="30px" OnClick="btnAddSamuha_Click" SkinID="Add" /></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 55px">
                                <asp:Panel ID="Panel1" runat="server" Height="130px" ScrollBars="Auto" Width="450px">
                                    <asp:GridView ID="grdSamuha" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" Width="420px" OnSelectedIndexChanged="grdSamuha_SelectedIndexChanged" SkinID="Unicodegrd">
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="SewaID" HeaderText="SewaID" Visible="False" />
                                            <asp:BoundField DataField="SamuhaID" HeaderText="SamuhaID" Visible="False" />
                                            <asp:BoundField DataField="SamuhaName" HeaderText="समुहको नाम">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="EntryBy" HeaderText="EntryBy" Visible="False" />
                                            <asp:BoundField DataField="Action" HeaderText="Action">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:CommandField ShowSelectButton="True">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:CommandField>
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
                            <td style="width: 150px; height: 30px;" valign="bottom">
                                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Underline="True" Text="उप समुह" SkinID="UnicodeHeadlbl"></asp:Label></td>
                            <td style="width: 300px; height: 30px;">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 150px; height: 16px;">
                                <asp:Label ID="Label6" runat="server" Text="उप समुहको नाम" SkinID="Unicodelbl"></asp:Label></td>
                            <td style="width: 300px; height: 16px;">
                                <asp:TextBox ID="txtUpaSamuha" runat="server" Width="250px" MaxLength="48" SkinID="Unicodetxt"></asp:TextBox>&nbsp;<asp:Button ID="btnAddUpaSamuha" runat="server" Font-Bold="True" Text="+" Width="30px" OnClick="btnAddUpaSamuha_Click" SkinID="Add" /></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Panel ID="Panel2" runat="server" Height="130px" ScrollBars="Auto" Width="450px">
                                    <asp:GridView ID="grdUpaSamuha" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" Width="420px" OnSelectedIndexChanged="grdUpaSamuha_SelectedIndexChanged" SkinID="Unicodegrd">
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="SewaID" HeaderText="SewaID" Visible="False" />
                                            <asp:BoundField DataField="SamuhaID" HeaderText="SamuhaID" Visible="False" />
                                            <asp:BoundField DataField="UpaSamuhaID" HeaderText="UpaSamuhaID" Visible="False" />
                                            <asp:BoundField DataField="UpaSamuhaName" HeaderText="उप-समुहको नाम">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="EntryBy" HeaderText="EntryBy" Visible="False" />
                                            <asp:BoundField DataField="Action" HeaderText="Action">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
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
                        </tr>
                    </table>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="60px" OnClick="btnSubmit_Click" SkinID="Normal" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="60px" OnClick="btnCancel_Click" SkinID="Cancel" /></td>
            </tr>
        </table>
        
    </div>
</asp:Content>

