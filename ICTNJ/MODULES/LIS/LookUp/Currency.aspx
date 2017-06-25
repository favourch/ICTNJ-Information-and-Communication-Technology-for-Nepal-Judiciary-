<%@ Page Language="C#" MasterPageFile="~/MODULES/COMMON/MasterPage.master" AutoEventWireup="true" CodeFile="Currency.aspx.cs" Inherits="MODULES_LIS_LookUp_Currency" Title="LIS-Currency" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="width:100%; height:500px">
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table height="320" style="position: static" width="550">
            <tr>
                <td colspan="2" style="height: 34px" valign="middle">
                    <asp:Label ID="Label2" runat="server" Font-Bold="False" SkinID="UnicodeHeadlbl" Style="position: static">Currency Setup</asp:Label></td>
            </tr>
            <tr>
                <td valign="top" width="200">
                    <asp:ListBox ID="lstCurrency" runat="server" Height="300px" Style="position: static"
                        Width="180px" AutoPostBack="True" OnSelectedIndexChanged="lstCurrency_SelectedIndexChanged" SkinID="Unicodelst"></asp:ListBox></td>
                <td width="350" valign="top">
        <asp:Label ID="lblStatus" runat="server" Font-Bold="False" Style="position: static" SkinID="UnicodeHeadlbl"></asp:Label>
                    <table style="position: static" width="350">
                        <tr>
                            <td width="100" style="height: 1px">
                                <asp:Label ID="Label1" runat="server" Style="position: static" Text="Currency name"
                                    Width="100px" SkinID="Unicodelbl"></asp:Label></td>
                            <td style="width: 250px; height: 1px;">
                                <asp:UpdatePanel id="updCurrencyName" runat="server">
                                    <contenttemplate>
<asp:TextBox style="POSITION: static" id="txtCurrencyName_Rqd" runat="server" Width="230px" SkinID="Unicodetxt" __designer:wfdid="w16"></asp:TextBox> 
</contenttemplate>
                                    <triggers>
<asp:AsyncPostBackTrigger ControlID="lstCurrency" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
                                </asp:UpdatePanel></td>
                        </tr>
                        <tr>
                            <td width="100">
                            </td>
                            <td style="width: 250px">
                                <asp:Button ID="btnSubmit" runat="server" Style="position: static" Text="Submit" OnClick="btnSubmit_Click" SkinID="Normal" />
                                <asp:Button ID="btnCancel" runat="server" Style="position: static" Text="Cancel" OnClick="btnCancel_Click" SkinID="Cancel" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        
    </div>
</asp:Content>

