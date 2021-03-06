<%@ Page AutoEventWireup="true" CodeFile="LawyerSearch.aspx.cs" Inherits="MODULES_LJMS_Forms_LawyerSearch" Language="C#" MasterPageFile="~/MODULES/LJMS/LJMSMasterPage.master"
    Title="NBA | Lawyer Search - Report" %>

<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div style="width: 100%; height: auto">
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager><br />
        <asp:Label ID="lblSearchHeader" runat="server" Font-Bold="True" SkinID="UnicodeHeadlbl"
            Text="Search / Edit / Lawyer Reporting"></asp:Label>&nbsp;<br />
        <asp:Label ID="lblStatus" runat="server"></asp:Label><br />
        <table width="900">
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label1" runat="server" SkinID="LJMSlbl" Text="पहिलो नाम"></asp:Label></td>
                <td style="width: 200px">
                    <asp:TextBox ID="txtFName" runat="server" SkinID="LJMStxt" Width="170px"></asp:TextBox></td>
                <td style="width: 100px">
                    <asp:Label ID="Label2" runat="server" SkinID="LJMSlbl" Text="बिचको नाम"></asp:Label></td>
                <td style="width: 200px">
                    <asp:TextBox ID="txtMName" runat="server" SkinID="LJMStxt" Width="170px"></asp:TextBox></td>
                <td style="width: 100px">
                    <asp:Label ID="Label3" runat="server" SkinID="LJMSlbl" Text="थर"></asp:Label></td>
                <td style="width: 200px">
                    <asp:TextBox ID="txtSName" runat="server" SkinID="LJMStxt" Width="170px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label4" runat="server" SkinID="LJMSlbl" Text="लाईसेन्स् नं"></asp:Label></td>
                <td style="width: 200px">
                    <asp:TextBox ID="txtLisenceNo" runat="server" SkinID="LJMStxt" Width="170px"></asp:TextBox></td>
                <td style="width: 100px">
                    <asp:Label ID="Label5" runat="server" SkinID="LJMSlbl" Text="प्रकार"></asp:Label></td>
                <td style="width: 200px">
                    <asp:DropDownList ID="ddlLawyerType" runat="server" SkinID="Ljmsddl" Width="174px">
                    </asp:DropDownList></td>
                <td style="width: 100px">
                    <asp:Label ID="Label6" runat="server" SkinID="LJMSlbl" Text="एकाई"></asp:Label></td>
                <td style="width: 200px">
                    <asp:DropDownList ID="ddlUnit" runat="server" SkinID="Ljmsddl" Width="174px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 26px;">
                </td>
                <td style="width: 200px; height: 26px;">
                    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" SkinID="Normal" Text="Search" />
                    <asp:Button ID="btnCancel" runat="server" SkinID="Cancel" Text="Cancel" OnClick="btnCancel_Click" /></td>
                <td style="width: 100px; height: 26px;">
                    <asp:Label ID="Label7" runat="server" SkinID="LJMSlbl" Text="लिं"></asp:Label></td>
                <td style="width: 200px; height: 26px;">
                    <asp:DropDownList ID="ddlSex" runat="server" SkinID="Ljmsddl" Width="174px">
                        <asp:ListItem Value="0">%FGg'xF];\</asp:ListItem>
                        <asp:ListItem Value="F">dlxnF</asp:ListItem>
                        <asp:ListItem Value="M">k'?&#237;</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 100px; height: 26px;">
                    <asp:Label ID="lblInActive" runat="server" SkinID="LJMSlbl" Text="InActive"></asp:Label></td>
                <td style="width: 200px; height: 26px;">
                    <asp:CheckBox ID="chkInActive" runat="server" /></td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 200px">
                    <asp:Button ID="btnGenerateReport" runat="server" OnClick="btnGenerateReport_Click" SkinID="Dynamic" Text="Generate Report [General]" Width="144px" /></td>
                <td style="width: 100px"><asp:CheckBox ID="chkWP" runat="server" SkinID="smallChk" />
                    <asp:Label ID="Label8" runat="server" SkinID="LJMSlbl" Text="सम्पर्क"></asp:Label></td>
                <td style="width: 200px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 200px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 6px">
                </td>
                <td style="width: 200px; height: 6px">
                </td>
                <td style="width: 100px; height: 6px">
                </td>
                <td style="width: 200px; height: 6px">
                </td>
                <td style="width: 100px; height: 6px">
                </td>
                <td style="width: 200px; height: 6px">
                </td>
            </tr>
        </table>
        <asp:Label ID="lblCount" runat="server" SkinID="LJMSlbl"></asp:Label><br />
        <asp:Panel ID="Panel1" runat="server" Height="400px" Width="100%" ScrollBars="Auto">
            <asp:GridView ID="grdLawyer" runat="server" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333" OnDataBound="grdLawyer_DataBound" OnRowDataBound="grdLawyer_RowDataBound"
                OnSelectedIndexChanged="grdLawyer_SelectedIndexChanged" SkinID="LJMSgrd" Width="98%">
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <Columns>
                    <asp:BoundField DataField="PersonID" HeaderText="PersonID" />
                    <asp:BoundField DataField="RDFullName" HeaderText="पुरा नाम" />
                    <asp:BoundField DataField="RDGender" HeaderText="लिं" />
                    <asp:BoundField DataField="Lisence" HeaderText="लाईसेन्स नं" />
                    <asp:BoundField DataField="LawyerTypeName" HeaderText="वकिलको किसिम" />
                    <asp:BoundField DataField="LastRenewalDate" HeaderText="शुरु मिति" >
                        <ItemStyle Font-Names="Verdana" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LastRenewalUpto" HeaderText="रहने मिति" >
                        <ItemStyle Font-Names="Verdana" />
                    </asp:BoundField>
                    <asp:BoundField DataField="UnitName" HeaderText="एकाई" />
                    <asp:BoundField DataField="PvtLawyerLastRenewalDate" HeaderText="शुरु मिति" >
                        <ItemStyle Font-Names="Verdana" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PvtLawyerLastRenewalUpto" HeaderText="रहने मिति" >
                        <ItemStyle Font-Names="Verdana" />
                    </asp:BoundField>
                    <asp:CommandField ShowSelectButton="True" SelectText="Edit">
                        <ItemStyle HorizontalAlign="Center" Font-Names="Verdana" />
                    </asp:CommandField>
                    <asp:TemplateField>
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkViewBioData" runat="server" CommandName="Select" OnClick="lnkViewBioData_Click" SkinID="Tippani">View Bio-Data</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ACTIVE" HeaderText="ACTIVE" />
                </Columns>
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <EditRowStyle BackColor="#999999" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
        </asp:Panel>
        &nbsp;
    </div>
</asp:Content>
