<%@ Page Language="C#" MasterPageFile="~/MODULES/COMMON/MasterPage.master" AutoEventWireup="true" CodeFile="MaterialDetailSearch.aspx.cs" Inherits="MODULES_LIS_Forms_MaterialDetailSearch" Title="LIS | Library Material Detail Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="width:100%; height:550px">
        <table style="width: 625px">
            <tr>
                <td colspan="2" style="height: 34px">
                    <asp:Label ID="Label1" runat="server" SkinID="UnicodeHeadlbl" Text="Library Material Detail Report"></asp:Label>
                    <asp:Label ID="lblStatus" runat="server" SkinID="Unicodelbl"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 125px">
                    &nbsp;&nbsp;
                    <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="Organization"></asp:Label></td>
                <td style="width: 500px">
                    <asp:DropDownList ID="ddlOrg" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlOrg_SelectedIndexChanged" SkinID="Unicodeddl"
                        Width="200px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 125px">
                    &nbsp;&nbsp;
                    <asp:Label ID="Label3" runat="server" SkinID="Unicodelbl" Text="Library"></asp:Label></td>
                <td style="width: 500px">
                    <asp:DropDownList ID="ddlLibrary" runat="server" SkinID="Unicodeddl" Width="200px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 125px">
                    &nbsp;&nbsp;
                    <asp:Label ID="Label4" runat="server" SkinID="Unicodelbl" Text="Call No"></asp:Label></td>
                <td style="width: 500px">
                    <asp:TextBox ID="txtCallNo" runat="server" Width="194px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 125px">
                    &nbsp;&nbsp;
                    <asp:Label ID="Label5" runat="server" SkinID="Unicodelbl" Text="Category"></asp:Label></td>
                <td style="width: 500px">
                    <asp:DropDownList ID="ddlCategory" runat="server" SkinID="Unicodeddl" Width="200px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 125px">
                    &nbsp;&nbsp;
                    <asp:Label ID="Label6" runat="server" SkinID="Unicodelbl" Text="Type"></asp:Label></td>
                <td style="width: 500px">
                    <asp:DropDownList ID="ddlType" runat="server" SkinID="Unicodeddl" Width="200px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 125px">
                    &nbsp;&nbsp;
                    <asp:Label ID="Label7" runat="server" SkinID="Unicodelbl" Text="Publisher"></asp:Label></td>
                <td style="width: 500px">
                    <asp:DropDownList ID="ddlPublisherType" runat="server" Enabled="False" SkinID="Unicodeddl" Width="200px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 125px">
                </td>
                <td style="width: 500px">
                    <asp:Button ID="btnGenerate" runat="server" OnClick="btnGenerate_Click" SkinID="Dynamic" Text="Generate Report" Width="100px" /></td>
            </tr>
        </table>
        
    </div>
</asp:Content>

