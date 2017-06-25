<%@ Page Language="C#" MasterPageFile="~/MODULES/COMMON/MasterPage.master" AutoEventWireup="true" CodeFile="Application.aspx.cs" Inherits="MODULES_SECURITY_Application" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="width:100%; height:450px">
        <br />
        &nbsp;<asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Italic="False"
            SkinID="UnicodeHeadlbl" Style="position: static" Text="Application List"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Label ID="lblStatus" runat="server" Font-Bold="True" Style="position: static"
            Width="475px" SkinID="Unicodelbl"></asp:Label>
        <table style="position: static" width="800">
            <tr>
                <td valign="top" width="200">
                    <asp:ListBox ID="lstApplication" runat="server" AutoPostBack="True" Height="238px"
                        Style="position: static" Width="280px" OnSelectedIndexChanged="lstApplication_SelectedIndexChanged" SkinID="Unicodelst"></asp:ListBox></td>
                <td valign="top" style="width: 450px">
        <table style="position: static" width="480">
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label1" runat="server" Style="position: static" Text="Short name" SkinID="Unicodelbl"></asp:Label></td>
                <td width="325">
                    <asp:TextBox ID="txtShortName_Rqd" runat="server" Style="position: static" Width="193px" SkinID="Unicodetxt"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label5" runat="server" Style="position: static" Text="Application" SkinID="Unicodelbl"></asp:Label></td>
                <td width="325">
                    <asp:TextBox ID="txtApplication_Rqd" runat="server" Style="position: static" Width="193px" SkinID="Unicodetxt"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 70px;" valign="top">
                    <asp:Label ID="Label2" runat="server" Style="position: static" Text="Description" SkinID="Unicodelbl"></asp:Label></td>
                <td style="height: 70px;" width="325">
                    <asp:TextBox ID="txtAppDesc" runat="server" Style="position: static" Width="327px" Height="60px" TextMode="MultiLine" SkinID="Unicodetxt"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 25px" valign="middle">
                    </td>
                <td style="height: 25px" width="325">
                    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Style="position: static"
                        Text="Submit" Width="60px" SkinID="Normal" />
                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Style="position: static"
                        Text="Cancel" Width="60px" SkinID="Cancel" /></td>
            </tr>
        </table>
                </td>
            </tr>
        </table>
        
    </div>
</asp:Content>

