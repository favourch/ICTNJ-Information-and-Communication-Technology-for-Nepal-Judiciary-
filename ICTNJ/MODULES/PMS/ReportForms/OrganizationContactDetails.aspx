<%@ Page Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master" AutoEventWireup="true"
    CodeFile="OrganizationContactDetails.aspx.cs" Inherits="MODULES_PMS_ReportForms_OrganizationContactDetails"
    Title="PMS |Organization Contact Detail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="../../COMMON/JS/jquery.min.js"></script>

    <script type="text/javascript" src="../../COMMON/JS/scrolltopcontrol.js"></script>

    <script language="javascript" src="../../COMMON/JS/DateValidator.js" type="text/javascript"></script>

    <%-- <div style="height: 500px">--%>
    <div style="width: 100%">
        <asp:ScriptManager runat="server" ID="sct">
        </asp:ScriptManager>
        <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" Style="display: none" />
        <ajaxToolkit:ModalPopupExtender runat="server" ID="programmaticModalPopup" BehaviorID="programmaticModalPopupBehavior"
            TargetControlID="hiddenTargetControlForModalPopup" PopupControlID="programmaticPopup"
            BackgroundCssClass="modalBackground" DropShadow="True" PopupDragHandleControlID="programmaticPopupDragHandle"
            RepositionMode="RepositionOnWindowScroll">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel runat="server" CssClass="modalPopup" ID="programmaticPopup" Style="display: none;
            width: 350px; padding: 10px">
            <asp:Panel runat="Server" ID="programmaticPopupDragHandle" Style="cursor: move; background-color: #DDDDDD;
                border: solid 1px Gray; color: Black; text-align: center;">
                Save Status
            </asp:Panel>
            <asp:UpdatePanel ID="UpdatePanel31" runat="server">
                <contenttemplate>
                <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
            </contenttemplate>
            </asp:UpdatePanel>
            <asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click"
                Width="58px" />
            <br />
        </asp:Panel>
        <asp:Label ID="lblStatus" runat="server" Font-Bold="True" SkinID="Unicodelbl"></asp:Label>
        <table width="900">
            <tbody>
                <tr>
                    <td style="width: 168px; height: 24px">
                        <asp:Label ID="Label7" runat="server" Text="कार्यालय" SkinID="Unicodelbl"></asp:Label>
                    </td>
                    <td style="height: 24px" colspan="3">
                        <asp:DropDownList ID="ddlOrganization" runat="server" Width="372px" SkinID="Unicodeddl"
                            OnSelectedIndexChanged="ddlOrganization_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 168px; height: 24px">
                        <asp:Label ID="Label4" runat="server" Text="कार्यालय को नाम" SkinID="Unicodelbl"></asp:Label>
                    </td>
                    <td style="height: 24px" colspan="3">
                        <asp:Label ID="lblOrgName" runat="server" SkinID="Unicodelbl"></asp:Label>
                    </td>
                </tr>
                
                 <tr>
                    <td style="width: 168px; height: 24px">
                        <asp:Label ID="Label2" runat="server" Text="कार्यालय को कोड" SkinID="Unicodelbl"></asp:Label>
                    </td>
                    <td style="height: 24px" colspan="3">
                        <asp:Label ID="lblEquCode" runat="server" SkinID="Unicodelbl"></asp:Label>
                    </td>
                </tr>
                
                
                
                
                <tr>
                    <td style="width: 168px; height: 24px">
                        <asp:Label ID="OrgAddress" runat="server" Text="कार्यालय को ठेगाना" SkinID="Unicodelbl"
                            Width="145px"></asp:Label>
                    </td>
                    <td style="height: 24px" colspan="3">
                        <asp:Label ID="lblOrgAddress" runat="server" Text="" SkinID="Unicodelbl"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 168px; height: 24px">
                        <asp:Label ID="Label1" runat="server" Text="कार्यालय को जिल्ला" SkinID="Unicodelbl"
                            Width="145px"></asp:Label>
                    </td>
                    <td style="height: 24px" colspan="3">
                        <asp:Label ID="lblOrgDistrict" runat="server" SkinID="Unicodelbl"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 168px; height: 24px">
                        <asp:Label ID="Label5" runat="server" Text="सहर" SkinID="Unicodelbl" Width="145px"></asp:Label>
                    </td>
                    <td style="height: 24px" colspan="3">
                        <asp:Label ID="lblStreet" runat="server" Text="" SkinID="Unicodelbl"></asp:Label>
                    </td>
                </tr>
                <%--<tr>
                    <td style="width: 168px; height: 24px">
                        <asp:Label ID="Label2" runat="server" Text="नगरपालिका" SkinID="Unicodelbl"></asp:Label>
                    </td>
                    <td style="height: 24px" colspan="3">
                        <asp:Label ID="lblOrgVdcMuni" runat="server" SkinID="PCSlbl"></asp:Label>
                    </td>
                </tr>--%>
                <tr>
                    <td style="width: 168px; height: 24px">
                        <asp:Label ID="Label3" runat="server" Text="वडा न." SkinID="Unicodelbl"></asp:Label>
                    </td>
                    <td style="height: 24px" colspan="3">
                        <asp:Label ID="lblOrgWardNo" runat="server" Text="" SkinID="Unicodelbl"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 168px; height: 24px">
                        <asp:Label ID="Label8" runat="server" Text="गा.वि.स." SkinID="Unicodelbl"></asp:Label>
                    </td>
                    <td style="height: 24px" colspan="3">
                        <asp:Label ID="lblVdcName" runat="server" SkinID="Unicodelbl"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 168px; height: 24px">
                        <asp:Label ID="Url" runat="server" Text="वेब साईट" SkinID="Unicodelbl"></asp:Label>
                    </td>
                    <td style="height: 24px" colspan="3">
                        <asp:Label ID="lblUrl" runat="server" Text="" SkinID="Unicodelbl"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 168px; height: 24px">
                        <asp:Label ID="Label6" runat="server" Text="कार्यालय अणचल" SkinID="Unicodelbl" Width="145px" Visible="False"></asp:Label></td>
                    <td colspan="3" style="height: 24px">
                        <asp:Label ID="lblZone" runat="server" SkinID="PCSlbl" Visible="False"></asp:Label></td>
                </tr>
                <tr>
                    <%--<td style="height: 26px" colspan="3">
                        <asp:Button ID="btnShow" runat="server" Text="Show" SkinID="Normal"></asp:Button></td>--%>
                    <td style="height: 26px">
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" SkinID="Cancel" OnClick="btnCancel_Click">
                        </asp:Button></td>
                </tr>
            </tbody>
        </table>
        <table width="900">
            <tbody>
                <tr>
                    <td>
                        <asp:Label ID="Label9" runat="server" SkinID="UnicodeHeadlbl" Text="कर्यालयको फिन नं लिस्ट:"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <hr />
                        <br />
                        <asp:GridView ID="grdPhone" runat="server" SkinID="Unicodegrd" ForeColor="#333333"
                            CellPadding="0" AutoGenerateColumns="False" GridLines="None" Width="600px">
                            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
                            <Columns>
                                <asp:BoundField DataField="PSno" HeaderText="PSno" Visible="False"></asp:BoundField>
                                <asp:BoundField DataField="Phone" HeaderText="फोन नं">
                                    <ItemStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Phone_Type" HeaderText="फोनको किसिम">
                                    <ItemStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                            </Columns>
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
                            <EditRowStyle BackColor="#999999"></EditRowStyle>
                            <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>
                            <HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label10" runat="server" SkinID="UnicodeHeadlbl" Text="कार्यालयको ई-मेल लिस्ट:"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <hr />
                        <br />
                        <asp:GridView ID="grdEmail" runat="server" SkinID="Unicodegrd" ForeColor="#333333"
                            CellPadding="0" AutoGenerateColumns="False" GridLines="None" Width="600px">
                            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
                            <Columns>
                                <asp:BoundField DataField="ESNo" HeaderText="ESNo" Visible="False"></asp:BoundField>
                                <asp:BoundField DataField="Email" HeaderText="ईमेल">
                                    <ItemStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="EType" HeaderText="ईमेल को किसिम">
                                    <ItemStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                </asp:BoundField>
                            </Columns>
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
                            <EditRowStyle BackColor="#999999"></EditRowStyle>
                            <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>
                            <HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                        </asp:GridView>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</asp:Content>
