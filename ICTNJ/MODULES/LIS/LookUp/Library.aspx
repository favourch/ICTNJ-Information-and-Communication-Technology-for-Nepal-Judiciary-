<%@ Page Language="C#" MasterPageFile="~/MODULES/COMMON/MasterPage.master" AutoEventWireup="true" CodeFile="Library.aspx.cs" Inherits="MODULES_LIS_LookUp_Library" Title="LIS-Library" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="width:100%; height:500px;">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table height="280" style="position: static" width="570">
            <tr>
                <td colspan="2" style="height: 34px" valign="middle">
                    <asp:Label ID="Label1" runat="server" Font-Bold="False" SkinID="UnicodeHeadlbl" Style="position: static">Organization Library Setup</asp:Label></td>
            </tr>
            <tr>
                <td width="180" valign="top">
                    <asp:ListBox ID="lslLibrary" runat="server" Height="280px" Style="position: static"
                        Width="170px" AutoPostBack="True" OnSelectedIndexChanged="lslLibrary_SelectedIndexChanged" SkinID="Unicodelst"></asp:ListBox></td>
                <td width="390" valign="top">
                    <asp:Label ID="lblStatus" runat="server" Font-Bold="False" Style="position: static" SkinID="UnicodeHeadlbl"></asp:Label>
                    <table style="position: static" width="390">
                        <tr>
                            <td style="width: 95px" valign="top">
                    <asp:Label ID="lblOrg" runat="server" Style="position: static" Text="Organization" Width="90px" SkinID="Unicodelbl"></asp:Label></td>
                            <td style="width: 295px">
                                <asp:UpdatePanel ID="updOrg" runat="server">
                                    <ContentTemplate>
<asp:DropDownList style="POSITION: static" id="ddlOrg_Rqd" runat="server" Width="290px" SkinID="Unicodeddl"></asp:DropDownList> 
</ContentTemplate>
                                    <triggers>
<asp:AsyncPostBackTrigger ControlID="lslLibrary" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="lslLibrary" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="lslLibrary" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 95px" valign="top">
                    <asp:Label ID="lblLibrary" runat="server" Style="position: static" Text="Library name"
                        Width="90px" SkinID="Unicodelbl"></asp:Label></td>
                            <td style="width: 295px">
                                <asp:UpdatePanel ID="updLibraryName" runat="server">
                                    <ContentTemplate>
<asp:TextBox style="POSITION: static" id="txtLibraryName" runat="server" Width="290px" SkinID="Unicodetxt" __designer:wfdid="w19"></asp:TextBox> 
</ContentTemplate>
                                    <triggers>
<asp:AsyncPostBackTrigger ControlID="lslLibrary" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 95px" valign="top">
                    <asp:Label ID="lblLocation" runat="server" Style="position: static" Text="Location"
                        Width="90px" SkinID="Unicodelbl"></asp:Label></td>
                            <td style="width: 295px">
                                <asp:UpdatePanel ID="updLocation" runat="server">
                                    <ContentTemplate>
<asp:TextBox style="POSITION: static" id="txtLibraryLocation" runat="server" Width="290px" Height="112px" SkinID="Unicodetxt" __designer:wfdid="w20" TextMode="MultiLine"></asp:TextBox><BR />&nbsp; 
</ContentTemplate>
                                    <triggers>
<asp:AsyncPostBackTrigger ControlID="lslLibrary" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 95px" valign="top">
                            </td>
                            <td style="width: 295px">
                    <asp:Button ID="btnAddLibrary" runat="server" Style="position: static" Text="Submit" OnClick="btnAddLibrary_Click" SkinID="Normal" />
                    <asp:Button ID="btnCancel" runat="server" Style="position: static" Text="Cancel" OnClick="btnCancel_Click" SkinID="Cancel" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        
    </div>
</asp:Content>

