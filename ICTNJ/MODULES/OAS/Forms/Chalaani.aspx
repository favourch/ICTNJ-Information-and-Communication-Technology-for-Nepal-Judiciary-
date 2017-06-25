<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true" CodeFile="Chalaani.aspx.cs" Inherits="MODULES_OAS_Forms_Chalaani" Title="Untitled Page" %>
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
            <div style="width:100%; height:550px">
    <table width="1000">
        <tr>
            <td style="width: 150px" valign="top">
                <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="चलानी मिति" Width="100px"></asp:Label></td>
            <td style="width: 339px" valign="top">
                <asp:TextBox ID="txtRegDate" runat="server" MaxLength="10" SkinID="Unicodetxt" ToolTip="जन्म मिति"
                    Width="130px"></asp:TextBox><ajaxtoolkit:maskededitextender id="MaskedEditExtender1"
                        runat="server" autocomplete="False" mask="9999/99/99" masktype="Date" targetcontrolid="txtRegDate"> </ajaxtoolkit:maskededitextender></td>
            <td style="width: 50px" valign="top">
            </td>
            <td style="width: 150px" valign="top">
                <asp:Label ID="Label3" runat="server" SkinID="Unicodelbl" Text="बिषय" Width="80px"></asp:Label></td>
            <td valign="top">
                <asp:TextBox ID="txtSubject" runat="server" MaxLength="50"></asp:TextBox></td>
        </tr>
        <tr>
            <td valign="top" style="width: 150px">
                <asp:Label ID="Label5" runat="server" SkinID="Unicodelbl" Text="चलानी प्रकार" Width="101px"></asp:Label></td>
            <td valign="top" style="width: 339px">
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
            <td style="width: 150px;" valign="top">
                                <asp:Label ID="Label8" runat="server" SkinID="Unicodelbl" Text="कार्यलय" Width="80px"></asp:Label></td>
            <td style="width: 339px;" valign="top">
                <asp:UpdatePanel id="UpdatePanel3" runat="server"><contenttemplate>
                                <asp:DropDownList ID="ddlOrg" runat="server" AutoPostBack="True" DataTextField="OrgName"
                                    DataValueField="OrgID" OnSelectedIndexChanged="ddlOrg_SelectedIndexChanged" Width="193px">
                                </asp:DropDownList>
</contenttemplate>
                </asp:UpdatePanel></td>
            <td>
            </td>
            <td valign="top">
                                <asp:Label ID="Label9" runat="server" SkinID="Unicodelbl" Text="शाखा" Width="80px"></asp:Label></td>
            <td valign="top">
                <asp:UpdatePanel id="UpdatePanel1" runat="server">
                    <ContentTemplate>
<asp:DropDownList id="ddlSendUnit" runat="server" Width="193px" OnSelectedIndexChanged="ddlSendUnit_SelectedIndexChanged" DataValueField="UnitID" DataTextField="UnitName" AutoPostBack="True" AppendDataBoundItems="True" __designer:wfdid="w1">
                                </asp:DropDownList> 
</ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 150px" valign="top">
                <asp:Label ID="Label4" runat="server" SkinID="Unicodelbl" Text="बिबरण" Width="80px"></asp:Label></td>
            <td valign="top" colspan="4">
                <asp:TextBox ID="txtDescription" runat="server" Height="50px" MaxLength="1000" TextMode="MultiLine"
                    Width="550px"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:Panel ID="pnlChalaani" runat="server" Height="150px" ScrollBars="Auto" Visible="false"
                    Width="1000px">
                    <table style="width: 900px">
                        <tr>
                            <td colspan="2" style="height: 23px">
                                <asp:UpdatePanel id="UpdatePanel4" runat="server"><contenttemplate>
<asp:GridView id="grdSendEmp" runat="server" Width="850px" SkinID="Unicodegrd" ForeColor="#333333" DataKeyNames="EmpID" CellPadding="0" AutoGenerateColumns="False">
<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
<asp:BoundField DataField="EmpID" HeaderText="EmpID">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="FullName" HeaderText="पुरा नाम">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fullGender" HeaderText="लिंग">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="OrgID" HeaderText="OrgID">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="OrgName" HeaderText="कर्यालयको नाम">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DesID" HeaderText="DesID">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DesName" HeaderText="पद">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DesType" HeaderText="DesType">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="PostID" HeaderText="PostID">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="FromDate" HeaderText="FromDate">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="OrgUnitID" HeaderText="OrgUnitID">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="UnitName" HeaderText="शाखा">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:CommandField ShowSelectButton="True"></asp:CommandField>
</Columns>

<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView>
</contenttemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                    <br />
                    &nbsp;</asp:Panel>
                <br />
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" SkinID="Normal" Text="Submit" /></td>
        </tr>
    </table>
            </div>
</asp:Content>

