<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true" CodeFile="XMLDataSource.aspx.cs" Inherits="MODULES_OAS_Test_XMLDataSource" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:XmlDataSource ID="XmlDataSource" runat="server" DataFile="~/MODULES/OAS/Test/Country.xml" XPath="/countries/continent"></asp:XmlDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="0" DataSourceID="XmlDataSource" ForeColor="#333333" GridLines="None"
        SkinID="Plaingrd" Width="168px">
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <EditRowStyle BackColor="#999999" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <br />
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="XmlDataSource">
        <ItemTemplate>
            <strong>
                <%#XPath("Continent")%>
                <br />
            </strong>
         <%--   <%#XPath("Country")%>
            <br />--%>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>

