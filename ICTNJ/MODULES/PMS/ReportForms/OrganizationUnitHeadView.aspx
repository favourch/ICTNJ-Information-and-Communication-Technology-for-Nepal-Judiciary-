<%@ Page Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master" AutoEventWireup="true" CodeFile="OrganizationUnitHeadView.aspx.cs" Inherits="MODULES_PMS_ReportForms_OrganizationUnitHeadView" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="height: 396px" width="900">
        <tr>
            <td style="width: 100px" valign="top">
                &nbsp;<asp:Panel ID="Panel1" runat="server" Height="390px" Width="560px">
                    <asp:TreeView ID="TreeView1" runat="server" Height="369px" Width="555px">
                        <HoverNodeStyle BackColor="#C0C0FF" BorderColor="#8080FF" />
                        <LeafNodeStyle BackColor="Transparent" Font-Italic="True" />
                    </asp:TreeView>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>

