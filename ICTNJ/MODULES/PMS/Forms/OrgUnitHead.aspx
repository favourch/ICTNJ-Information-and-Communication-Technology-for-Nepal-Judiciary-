<%@ Page Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master" AutoEventWireup="true" CodeFile="OrgUnitHead.aspx.cs" Inherits="MODULES_PMS_Forms_OrgUnitHead" Title="PMS | Unit Head" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground"
        BehaviorID="programmaticModalPopupBehavior" DropShadow="True" PopupControlID="programmaticPopup"
        PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
        TargetControlID="hiddenTargetControlForModalPopup">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none;
        width: 350px; padding: 10px">
        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD;
            border: solid 1px Gray; color: Black; text-align: center;">
            SaveStatus
        </asp:Panel>
        <asp:UpdatePanel id="UpdatePanel4" runat="server">
            <contenttemplate>
<BR /><asp:Label id="lblStatusMessage" runat="server" Text="Label"></asp:Label> 
</contenttemplate>
        </asp:UpdatePanel>
        <br />
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
            Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    &nbsp;&nbsp;&nbsp;<br />
    <table style="width: 850px">
        <tr>
            <td align="left" colspan="3" valign="top" style="height: 325px">
                <table width="900">
                    <tr>
                        <td align="left" valign="top">
                            <asp:Label ID="Label30" runat="server" Height="22px" SkinID="Unicodelbl" Text="संकेत नं"
                                Width="110px"></asp:Label></td>
                        <td align="left" valign="top">
                            <asp:TextBox ID="txtSymbolNo" runat="server" MaxLength="15" SkinID="Unicodetxt" ToolTip="First Name"
                                Width="130px"></asp:TextBox></td>
                        <td align="left" valign="top">
                        </td>
                        <td align="left" valign="top">
                        </td>
                        <td align="left" valign="top">
                        </td>
                        <td align="left" style="width: 100px" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            <asp:Label ID="Label1" runat="server" Height="22px" SkinID="Unicodelbl" Text="पहिलो नाम"
                                Width="92px"></asp:Label></td>
                        <td align="left" valign="top">
                            <asp:TextBox ID="txtFName" runat="server" MaxLength="35" SkinID="Unicodetxt" ToolTip="First Name"
                                Width="130px"></asp:TextBox></td>
                        <td align="center" valign="top">
                            <asp:Label ID="Label6" runat="server" Height="22px" SkinID="Unicodelbl" Text="बिचको नाम"
                                Width="86px"></asp:Label></td>
                        <td align="left" valign="top">
                            <asp:TextBox ID="txtMName" runat="server" MaxLength="15" SkinID="Unicodetxt" Width="130px"></asp:TextBox></td>
                        <td align="left" valign="top">
                            <asp:Label ID="Label7" runat="server" Height="22px" SkinID="Unicodelbl" Text="थर"
                                Width="92px"></asp:Label></td>
                        <td align="left" style="width: 100px" valign="top">
                            <asp:TextBox ID="txtSurName" runat="server" MaxLength="35" SkinID="Unicodetxt" ToolTip="Surname"
                                Width="130px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            <asp:Label ID="Label8" runat="server" Height="22px" SkinID="Unicodelbl" Text="लिंग"
                                Width="92px"></asp:Label></td>
                        <td align="left" valign="top">
                            <asp:DropDownList ID="ddlGender" runat="server" SkinID="Unicodeddl" Width="135px">
                                <asp:ListItem Value="SG">छान्नुहोस</asp:ListItem>
                                <asp:ListItem Value="M">पुरुष</asp:ListItem>
                                <asp:ListItem Value="F">महिला</asp:ListItem>
                                <asp:ListItem Value="O">अन्य</asp:ListItem>
                            </asp:DropDownList></td>
                        <td align="center" valign="top">
                            <asp:Label ID="Label9" runat="server" Height="22px" SkinID="Unicodelbl" Text="जन्म मिति"
                                Width="88px"></asp:Label></td>
                        <td align="left" valign="top">
                            <asp:TextBox ID="txtDOB" runat="server" MaxLength="10" SkinID="Unicodetxt" Width="130px"></asp:TextBox></td>
                        <td align="left" valign="top">
                            <asp:Label ID="Label11" runat="server" SkinID="Unicodelbl" Text="कार्यालय"></asp:Label></td>
                        <td align="left" style="width: 100px" valign="top">
                            <asp:DropDownList ID="ddlOrganization" runat="server" SkinID="Unicodeddl" Width="250px">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td align="left" colspan="1" valign="top">
                        </td>
                        <td align="left" colspan="1" valign="top">
                        </td>
                        <td align="left" colspan="1" valign="top">
                        </td>
                        <td align="left" colspan="1" valign="top">
                        </td>
                        <td align="left" colspan="6" valign="top">
                            <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" SkinID="Normal"
                                Text="Search" />
                            <asp:Button ID="btnSearchCancel" runat="server" OnClick="btnSearchCancel_Click" SkinID="Cancel"
                                Text="Cancel" /></td>
                    </tr>
                    <tr>
                        <td align="left" colspan="10" valign="top">
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" Width="870px" Height="150px">
                <asp:GridView ID="grdEmployee" runat="server" AutoGenerateColumns="False" CellPadding="0"
                    ForeColor="#333333" GridLines="None" SkinID="Unicodegrd" Width="850px" OnSelectedIndexChanged="grdEmployee_SelectedIndexChanged" OnRowDataBound="grdEmployee_RowDataBound">
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:BoundField DataField="OrgID" HeaderText="OrgID" />
                        <asp:BoundField DataField="EmpID" HeaderText="EmpID" />
                        <asp:BoundField DataField="RDFullName" HeaderText="नाम" />
                        <asp:BoundField DataField="UnitID" HeaderText="UnitID" />
                        <asp:BoundField DataField="UnitName" HeaderText="शाखा" />
                        <asp:BoundField DataField="UnitHead" HeaderText="शाखा प्रमुख" />
                        <asp:BoundField DataField="OfficeHead" HeaderText="कार्यालय प्रमुख" />
                        <asp:BoundField DataField="FromDate" HeaderText="ञवधि देखि" />
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <EditRowStyle BackColor="#999999" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="1" valign="top">
                <asp:Label ID="Label3" runat="server" SkinID="Unicodelbl" Text="शाखा"></asp:Label></td>
                        <td align="left" colspan="1" valign="top">
                <asp:DropDownList ID="DDLUnit" runat="server" SkinID="Unicodeddl" Width="150px">
                </asp:DropDownList></td>
                        <td align="center" colspan="1" valign="top">
                            <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="शाखा प्रमुख" Width="86px"></asp:Label></td>
                        <td align="left" colspan="1" valign="top">
                            <asp:CheckBox ID="chkUnitHead" runat="server" SkinID="smallChk" Width="55px" /></td>
                        <td align="left" colspan="1" valign="top">
                            <asp:Label ID="Label4" runat="server" SkinID="Unicodelbl" Text="कार्यालय प्रमुख" Width="104px"></asp:Label></td>
                        <td align="left" colspan="6" valign="top">
                            <asp:CheckBox ID="chkOfficeHead" runat="server" SkinID="smallChk" Width="40px" /></td>
                    </tr>
                    <tr>
                        <td align="left" colspan="1" valign="top">
                <asp:Label ID="Label5" runat="server" SkinID="Unicodelbl" Text="मिति"></asp:Label></td>
                        <td align="left" colspan="1" valign="top">
                <asp:TextBox ID="txtFromDate" runat="server" SkinID="Unicodetxt" Width="100px"></asp:TextBox></td>
                        <td align="left" colspan="1" valign="top">
                        </td>
                        <td align="left" colspan="1" valign="top">
                        </td>
                        <td align="left" colspan="1" valign="top">
                        </td>
                        <td align="left" colspan="6" valign="top">
                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AutoComplete="False"
                    Mask="9999/99/99" MaskType="Date" TargetControlID="txtFromDate">
                </ajaxToolkit:MaskedEditExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3" valign="top">
                        </td>
                        <td align="left" colspan="1" valign="top">
                        </td>
                        <td align="left" colspan="7" valign="top">
                            &nbsp;<asp:Button ID="btnSubmit" runat="server" SkinID="Normal" Text="Submit" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnCancel" runat="server" SkinID="Cancel" Text="Cancel" OnClick="btnCancel_Click" /></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
        <contenttemplate>
</contenttemplate>
    <br />
</asp:Content>

