<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true" CodeFile="Dartaa.aspx.cs" Inherits="MODULES_OAS_Forms_Dartaa" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager id="SMInvTransaction" runat="server">
    </asp:ScriptManager>
    <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
    <ajaxtoolkit:modalpopupextender id="programmaticModalPopup" runat="server" backgroundcssclass="modalBackground"
        behaviorid="programmaticModalPopupBehavior" dropshadow="True" popupcontrolid="programmaticPopup"
        popupdraghandlecontrolid="programmaticPopupDragHandle" repositionmode="RepositionOnWindowScroll"
        targetcontrolid="hiddenTargetControlForModalPopup"></ajaxtoolkit:modalpopupextender>
    <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="padding-right: 10px;
        display: none; padding-left: 10px; padding-bottom: 10px; width: 350px; padding-top: 10px">
        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="border-right: gray 1px solid;
            border-top: gray 1px solid; border-left: gray 1px solid; cursor: move; color: black;
            border-bottom: gray 1px solid; background-color: #dddddd; text-align: center">
            Save Status
        </asp:Panel>
        <asp:UpdatePanel id="UpdatePanel2" runat="server">
            <contenttemplate>
<asp:Label id="lblStatusMessage" runat="server" Text="Label"></asp:Label> 
</contenttemplate>
        </asp:UpdatePanel>
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
            Text="OK" Width="58px" /></asp:Panel>
    <br />
    <table width="1000">
        <tr>
            <td style="width: 150px" valign="top" >
                <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="दर्ता मिति" Width="80px"></asp:Label></td>
            <td style="width: 250px" valign="top">
                <asp:TextBox ID="txtRegDate" runat="server" MaxLength="10" SkinID="Unicodetxt" ToolTip="जन्म मिति"
                    Width="130px"></asp:TextBox><ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1"
                        runat="server" AutoComplete="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtRegDate">
                    </ajaxToolkit:MaskedEditExtender>
            </td>
            <td style="width: 50px" valign="top">
            </td>
            <td style="width: 150px" valign="top">
                <asp:Label ID="Label3" runat="server" SkinID="Unicodelbl" Text="बिषय" Width="80px"></asp:Label></td>
            <td valign="top">
                <asp:TextBox ID="txtSubject" runat="server" MaxLength="50"></asp:TextBox></td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="Label5" runat="server" SkinID="Unicodelbl" Text="दर्ता प्रकार" Width="80px"></asp:Label></td>
            <td valign="top">
                <asp:RadioButtonList ID="rdbPhyDig" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="P">Physical</asp:ListItem>
                <asp:ListItem Value="D">Digital</asp:ListItem>
            </asp:RadioButtonList></td>
            <td>
            </td>
            <td valign="top">
                <asp:Label ID="Label6" runat="server" SkinID="Unicodelbl" Text="फाईल" Width="80px"></asp:Label></td>
            <td valign="top">
                <asp:FileUpload ID="fupRegFile" runat="server" /></td>
        </tr>
        <tr>
            <td valign="top">
                                <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="शाखा" Width="80px"></asp:Label></td>
            <td valign="top">
                <asp:UpdatePanel id="UpdatePanel1" runat="server"><contenttemplate>
                                <asp:DropDownList ID="ddlUnit" runat="server" DataTextField="UnitName" DataValueField="UnitID"
                    Width="193px" AutoPostBack="True" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged">
                                </asp:DropDownList>
</contenttemplate>
                </asp:UpdatePanel></td>
            <td>
            </td>
            <td valign="top">
                <asp:Label ID="Label4" runat="server" SkinID="Unicodelbl" Text="बिबरण" Width="80px"></asp:Label></td>
            <td valign="top">
                <asp:TextBox ID="txtDescription" runat="server" Height="50px" MaxLength="1000" TextMode="MultiLine"
                    Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td valign="top">
                                </td>
            <td>
                                </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:Panel ID="pnlDartaa" runat="server" Height="150px" ScrollBars="Auto" Width="1000px">
                    <table style="widh: 900px">
                        <tr>
                            <td colspan="2" style="height: 184px">
                                <br />
                                <asp:UpdatePanel id="UpdatePanel3" runat="server">
                                    <contenttemplate>
                                <asp:GridView ID="grdEmpSearch" runat="server" AutoGenerateColumns="False" CellPadding="0"
                        DataKeyNames="EmpID" ForeColor="#333333" GridLines="None" 
                        Width="850px" OnRowDataBound="grdEmpSearch_RowDataBound">
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="EmpID" HeaderText="EmpID">
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FullName" HeaderText="पुरा नाम">
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="fullGender" HeaderText="लिंग">
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="OrgID" HeaderText="OrgID">
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="OrgName" HeaderText="कर्यालयको नाम">
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DesID" HeaderText="DesID">
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DesName" HeaderText="पद">
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DesType" HeaderText="DesType">
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate">
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PostID" HeaderText="PostID">
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FromDate" HeaderText="FromDate">
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="OrgUnitID" HeaderText="OrgUnitID">
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="UnitName" HeaderText="शाखा">
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:CommandField ShowSelectButton="True" />
                                    </Columns>
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <EditRowStyle BackColor="#999999" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                </asp:GridView></contenttemplate>
                                </asp:UpdatePanel>&nbsp;
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    &nbsp;</asp:Panel>
                &nbsp;<br />
                <br />
                <asp:Button ID="btnSave" runat="server" SkinID="Normal" Text="Submit" OnClick="btnSave_Click" /></td>
        </tr>
    </table>
</asp:Content>

