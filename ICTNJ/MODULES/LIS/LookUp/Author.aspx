<%@ Page Language="C#" MasterPageFile="~/MODULES/COMMON/MasterPage.master" AutoEventWireup="true" CodeFile="Author.aspx.cs" Inherits="MODULES_LIS_LookUp_Author" Title="LIS-Author" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="width: 100%; position: static; height: 500px">
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table height="320" style="position: static" width="550">
            <tr>
                <td colspan="2" style="height: 34px" valign="middle">
                    <asp:Label ID="Label2" runat="server" Font-Bold="False" SkinID="UnicodeHeadlbl" Style="position: static">Author Setup</asp:Label></td>
            </tr>
            <tr>
                <td valign="top" width="200">
                    <asp:ListBox ID="lstAuthor" runat="server" AutoPostBack="True" Height="300px" OnSelectedIndexChanged="lstCurrency_SelectedIndexChanged"
                        Style="position: static" Width="180px" SkinID="Unicodelst"></asp:ListBox></td>
                <td width="350" valign="top">
        <asp:Label ID="lblStatus" runat="server" Font-Bold="False" Style="position: static" SkinID="UnicodeHeadlbl"></asp:Label>
                    <table style="position: static" width="350">
                        <tr>
                            <td style="height: 1px" width="100">
                                <asp:Label ID="Label1" runat="server" Style="position: static" Text="Author Name"
                                    Width="100px" SkinID="Unicodelbl"></asp:Label></td>
                            <td style="width: 250px; height: 1px">
                                <asp:UpdatePanel id="updAuthorName" runat="server">
                                    <contenttemplate>
<asp:TextBox style="POSITION: static" id="txtAuthorName_Rqd" runat="server" Width="230px" SkinID="Unicodetxt" __designer:wfdid="w23"></asp:TextBox> 
</contenttemplate>
                                    <triggers>
<asp:AsyncPostBackTrigger ControlID="lstAuthor" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
                                </asp:UpdatePanel></td>
                        </tr>
                        <tr>
                            <td width="100">
                            </td>
                            <td style="width: 250px">
                                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Style="position: static"
                                    Text="Submit" TabIndex="1" AccessKey="b" SkinID="Normal" />
                                <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Style="position: static"
                                    Text="Cancel" TabIndex="2" SkinID="Cancel" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

