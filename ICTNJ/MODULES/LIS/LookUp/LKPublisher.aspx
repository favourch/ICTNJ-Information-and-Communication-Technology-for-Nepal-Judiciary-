<%@ Page Language="C#" MasterPageFile="~/MODULES/COMMON/MasterPage.master" AutoEventWireup="true" CodeFile="LKPublisher.aspx.cs" Inherits="MODULES_LIS_LookUp_LKPublisher" Title="LIS-Publisher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="width:100%; height:500px">
    <table style="position: static" width="700">
        <tr>
            <td colspan="2" style="height: 34px">
                <asp:Label ID="Label3" runat="server" Font-Bold="False" SkinID="UnicodeHeadlbl" Style="position: static">Publisher Setup</asp:Label></td>
        </tr>
        <tr>
            <td width="200">
                &nbsp;<asp:ListBox ID="LBPublisher" runat="server" Height="300px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="LBPublisher_SelectedIndexChanged" style="position: static" SkinID="Unicodelst"></asp:ListBox>
            </td>
            <td valign="top" width="500">
                    <asp:Label ID="LblStatus" runat="server" Font-Bold="False" style="position: static" SkinID="UnicodeHeadlbl"></asp:Label><br />
    <table width="500" style="position: static">
            <tr>
                <td style="height: 19px;" width="150">
        <asp:Label ID="Label1" runat="server" Text="Publisher Name" SkinID="Unicodelbl"></asp:Label></td>
                <td style="height: 19px;" width="350">
        <asp:TextBox ID="txtPublisherName_Rqd" runat="server" Width="250px" SkinID="Unicodetxt"></asp:TextBox></td>
            </tr>
        <tr>
            <td style="height: 19px" width="150" valign="top">
                    <asp:Label ID="Label2" runat="server" Text="Address" style="position: static" SkinID="Unicodelbl"></asp:Label></td>
            <td style="height: 19px" width="350">
                    <asp:TextBox ID="txtLookupAddress_Rqd" runat="server" style="position: static" Width="350px" Height="100px" TextMode="MultiLine" SkinID="Unicodetxt"></asp:TextBox></td>
        </tr>
            <tr>
                <td style="height: 6px;" width="150">
                    </td>
                <td style="height: 6px;" width="350">
                    <asp:Button ID="btnSave" runat="server" Text="Submit" OnClick="btnSave_Click" style="position: static" SkinID="Normal" />
                    <asp:Button ID="BtnCancel" runat="server" OnClick="BtnCancel_Click" Text="Cancel" style="position: static" SkinID="Cancel" /><asp:Button ID="BtnDelete" runat="server" Text="Delete" OnClick="BtnDelete_Click" Visible="False" style="position: static" /></td>
            </tr>
        </table>
            </td>
        </tr>
    </table>
</div>
</asp:Content>

