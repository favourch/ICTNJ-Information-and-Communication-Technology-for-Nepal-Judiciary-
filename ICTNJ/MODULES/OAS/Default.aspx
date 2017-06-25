<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="MODULES_OAS_Default" Title="OAS | Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="width:100%; height:550px">
        <br />
        <br />
        <table width="500">
            <tr>
                <td style="width: 500px; height: 30px">
        <asp:Label ID="Label1" runat="server" Text="Unread Tippani" SkinID="UnicodeHeadlbl"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 500px">
                    <asp:DataList ID="dlstUnreadTippani" runat="server" BackColor="White" BorderColor="#999999"
                        BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <AlternatingItemStyle BackColor="#DCDCDC" />
                        <ItemStyle BackColor="#EEEEEE" ForeColor="Black" />
                        <SelectedItemStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                        <ItemTemplate>
                            <table width="300">
                                <tr>
                                    <td style="width: 170px">
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                        <asp:LinkButton ID="lnkUnreadTippani" runat="server" PostBackUrl='<%# Eval("URL") %>'
                                            SkinID="Tippani" Text='<%# Eval("TippaniName") +"  ::  " %>'></asp:LinkButton></td>
                                    <td align="center" style="width: 130px" valign="middle">
                                        <asp:Label ID="lblTippaniNumber" runat="server" SkinID="Unicodelbl" Text='<%# Eval("Number") %>'></asp:Label></td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList></td>
            </tr>
        </table>
    </div>
</asp:Content>

