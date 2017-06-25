<%@ Page Language="C#" MasterPageFile="~/MODULES/COMMON/MasterPage.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeFile="ApplicationForm.aspx.cs" Inherits="MODULES_SECURITY_ApplicationForm" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="width:100%; height:auto;">
        <asp:Label ID="lblStatus" runat="server" Font-Bold="True" Style="position: static" ForeColor="#400000" SkinID="Unicodelbl"></asp:Label><br />
        <table style="position: static" width="480">
            <tr>
                <td style="width: 100px; height: 25px" valign="middle">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Italic="False" SkinID="Unicodelbl"
                        Style="position: static" Text="Form"></asp:Label></td>
                <td style="height: 25px" width="325">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 25px" valign="middle">
                    <asp:Label ID="Label1" runat="server" Style="position: static" Text="Application" SkinID="Unicodelbl"></asp:Label></td>
                <td style="height: 25px" width="325">
                    <asp:DropDownList ID="ddlApplication_Rqd" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlApplication_Rqd_SelectedIndexChanged"
                        Style="position: static" Width="330px" SkinID="Unicodeddl">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 16px" valign="top">
                    <asp:Label ID="Label7" runat="server" Style="position: static" Text="Form name" SkinID="Unicodelbl"></asp:Label></td>
                <td style="height: 16px" width="325">
                    <asp:TextBox ID="txtFormName_Rqd" runat="server" Style="position: static" Width="325px" SkinID="Unicodetxt"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 16px" valign="top">
                    <asp:Label ID="Label8" runat="server" Style="position: static" Text="Description" SkinID="Unicodelbl"></asp:Label></td>
                <td style="height: 16px" width="325">
                    <asp:TextBox ID="txtFrmDesc" runat="server" Height="60px" Style="position: static"
                        TextMode="MultiLine" Width="325px" SkinID="Unicodetxt"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 5px" valign="top">
                </td>
                <td style="height: 5px" width="325">
                    <asp:Button ID="btnAddForm" runat="server" OnClick="btnAddForm_Click" Style="position: static"
                        Text="Add" Width="60px" SkinID="Normal" /><asp:Button ID="btnFrmCancel" runat="server" OnClick="btnFrmCancel_Click" Style="position: static"
                        Text="Cancel" Width="60px" SkinID="Cancel" /></td>
            </tr>
        </table>
        <table style="position: static" width="700">
            <tr>
                <td style="height: 12px; width: 480px;">
                    <asp:Label ID="lblApplicationName" runat="server" Font-Bold="True" Font-Italic="True"
                        Font-Underline="True" ForeColor="#400000" Style="position: static" Text="Form list" SkinID="UnicodeHeadlbl"></asp:Label></td>
            </tr>
            <tr>
                <td style="height: 68px; width: 480px;">
                    <asp:Panel ID="pnlForm" runat="server" Height="150px" ScrollBars="Auto" Style="position: static"
                        Width="690px">
                        <asp:GridView ID="grdForm" runat="server" AutoGenerateColumns="False" CellPadding="1"
                            CellSpacing="2" ForeColor="#333333" GridLines="None"
                            Style="position: static" Width="680px" OnSelectedIndexChanged="grdForm_SelectedIndexChanged" OnDataBound="grdForm_DataBound" SkinID="Unicodegrd">
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                            <Columns>
                                <asp:BoundField DataField="ApplicationID" HeaderText="AppID" Visible="False">
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FormID" HeaderText="FormID" Visible="False">
                                    <ItemStyle HorizontalAlign="Left" Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FormName" HeaderText="Form name" />
                                <asp:BoundField DataField="FormDescription" HeaderText="Form description" />
                                <asp:BoundField DataField="Action" >
                                    <ItemStyle Width="30px" />
                                </asp:BoundField>
                                <asp:CommandField ShowSelectButton="True" />
                            </Columns>
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <table style="position: static" width="480">
        <tr>
            <td style="width: 100px; height: 10px" valign="middle">
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Italic="False" SkinID="UnicodeHeadlbl"
                        Style="position: static" Text="Menu"></asp:Label></td>
            <td style="height: 10px" width="325">
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 6px" valign="middle">
                    <asp:Label ID="Label9" runat="server" Style="position: static" Text="Menu name" SkinID="Unicodelbl"></asp:Label></td>
            <td style="height: 6px" width="325">
                    <asp:TextBox ID="txtMenuName_Rqd" runat="server" Style="position: static" Width="193px" SkinID="Unicodetxt"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 3px" valign="middle">
                    <asp:Label ID="Label10" runat="server" Style="position: static" Text="Description" Width="71px" SkinID="Unicodelbl"></asp:Label></td>
            <td style="height: 3px" width="325"><asp:TextBox ID="txtMenuDesc" runat="server" Style="position: static"
                        Width="327px" SkinID="Unicodetxt"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 3px" valign="middle">
                <asp:Label ID="LabelFun" runat="server" Style="position: static" Text="Function"
                    Width="71px" SkinID="Unicodelbl"></asp:Label></td>
            <td style="height: 3px" width="325">
                <asp:CheckBox ID="chkSelect" runat="server" Style="position: static" Text="Select" SkinID="smallChk" />&nbsp;
                &nbsp;<asp:CheckBox ID="chkAdd" runat="server" Style="position: static" Text="Add" SkinID="smallChk" />&nbsp;
                &nbsp;<asp:CheckBox ID="chkEdit" runat="server" Style="position: static" Text="Edit" SkinID="smallChk" />&nbsp;
                &nbsp;<asp:CheckBox ID="chkDelete" runat="server" Style="position: static" Text="Delete" SkinID="smallChk" /></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 16px" valign="top">
            </td>
            <td style="height: 16px" width="325">
                    <asp:Button ID="btnAddMenu" runat="server" Style="position: static"
                        Text="Add" Width="60px" OnClick="btnAddMenu_Click" SkinID="Normal" /><asp:Button ID="btnCancelMenu" runat="server" Style="position: static" Text="Cancel"
                        Width="60px" OnClick="btnCancelMenu_Click" SkinID="Cancel" /></td>
        </tr>
    </table>
    <table style="position: static" width="700">
        <tr>
            <td style="width: 700px">
                    <asp:Label ID="lblFormName" runat="server" Font-Bold="True" Font-Italic="True" Font-Underline="True"
                        ForeColor="#400000" Style="position: static" SkinID="UnicodeHeadlbl">Menu list</asp:Label></td>
        </tr>
        <tr>
            <td style="width: 700px">
                    <asp:Panel ID="pnlMenu" runat="server" Height="150px" ScrollBars="Auto" Style="position: static"
                        Width="690px">
                        <asp:GridView ID="grdMenu" runat="server" AutoGenerateColumns="False" CellPadding="1"
                            CellSpacing="2" ForeColor="#333333" GridLines="None" SkinID="Unicodegrd" Style="position: static"
                            Width="680px" OnDataBound="grdMenu_DataBound">
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                            <Columns>
                                <asp:BoundField DataField="ApplicationID" HeaderText="AppID" Visible="False">
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FormID" HeaderText="FormID" Visible="False">
                                    <ItemStyle HorizontalAlign="Left" Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MenuID" HeaderText="MenuID" Visible="False" />
                                <asp:BoundField DataField="MenuName" HeaderText="Menu name" />
                                <asp:BoundField DataField="MenuDescription" HeaderText="Menu description" />
                                <asp:BoundField DataField="PSelect" HeaderText="Select">
                                    <ItemStyle Width="40px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PAdd" HeaderText="Add">
                                    <ItemStyle Width="40px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PEdit" HeaderText="Edit">
                                    <ItemStyle Width="40px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PDelete" HeaderText="Delete">
                                    <ItemStyle Width="40px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Action" Visible="False" >
                                    <ItemStyle Width="30px" />
                                </asp:BoundField>
                            </Columns>
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
                    </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="width: 700px">
                    <asp:Button ID="btnSubmit" runat="server" Style="position: static"
                        Text="Save" Width="60px" OnClick="btnSubmit_Click" SkinID="Normal" /><asp:Button ID="btnCancel" runat="server" Style="position: static"
                            Text="Cancel" SkinID="Cancel" /></td>
        </tr>
    </table>
</asp:Content>

