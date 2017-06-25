<%@ Page Language="C#" MasterPageFile="~/MODULES/COMMON/MasterPage.master" AutoEventWireup="true" CodeFile="LkLanguage.aspx.cs" Inherits="MODULES_LIS_LookUp_LkLanguage" Title="LIS-Language" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="width:300px; height:500px">
    <table style="position: static" width="700">
        <tr>
            <td colspan="2" style="height: 34px">
                <asp:Label ID="Label2" runat="server" Font-Bold="False" SkinID="UnicodeHeadlbl" Style="position: static">Language Setup</asp:Label></td>
        </tr>
        <tr>
            <td width="200">
                &nbsp;<asp:ListBox ID="LBLanguage" runat="server" Height="300px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="LBLanguage_SelectedIndexChanged" style="position: static" SkinID="Unicodelst"></asp:ListBox></td>
            <td valign="top" width="500">
    <table width="500" style="position: static">
        <tr>
            <td colspan="2" style="height: 10px">
                    <asp:Label ID="LblStatus" runat="server" Font-Bold="False" style="position: static" SkinID="UnicodeHeadlbl"></asp:Label></td>
        </tr>
            <tr>
                <td style="width: 150px; height: 10px;">
        <asp:Label ID="Label1" runat="server" Text="Language Name" style="position: static" SkinID="Unicodelbl"></asp:Label></td>
                <td style="width: 300px; height: 10px;">
        <asp:TextBox ID="txtLookupName_Rqd" runat="server" style="position: static" Width="290px" SkinID="Unicodetxt"></asp:TextBox></td>
            </tr>
        <tr>
            <td style="width: 150px; height: 10px">
            </td>
            <td style="width: 300px; height: 10px">
                    <asp:Button ID="btnSave" runat="server" Text="Submit" OnClick="btnSave_Click" style="position: static" SkinID="Normal" />
                <asp:Button
                        ID="BtnCancel" runat="server" OnClick="BtnCancel_Click" Text="Cancel" style="position: static" SkinID="Cancel" /><asp:Button ID="BtnDelete" runat="server" OnClick="BtnDelete_Click" Text="Delete" Visible="False" style="position: static" /></td>
        </tr>
        </table>
            </td>
        </tr>
    </table>
</div>
</asp:Content>

