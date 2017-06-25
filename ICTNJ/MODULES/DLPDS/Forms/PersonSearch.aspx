<%@ Page Language="C#" MasterPageFile="~/MODULES/DLPDS/DLPDSMasterPage.master" AutoEventWireup="true" CodeFile="PersonSearch.aspx.cs" Inherits="MODULES_DLPDS_Forms_PersonSearch" Title="Person Search" %>
<%@ Register 
    Assembly="AjaxControlToolkit" 
    Namespace="AjaxControlToolkit" 
    TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" style="display:none"/>
                 <asp:ScriptManager id="ScriptManager1" runat="server">
                </asp:ScriptManager>
        <ajaxToolkit:ModalPopupExtender runat="server" ID="programmaticModalPopup"
            BehaviorID="programmaticModalPopupBehavior"
            TargetControlID="hiddenTargetControlForModalPopup"
            PopupControlID="programmaticPopup" 
            BackgroundCssClass="modalBackground"
            DropShadow="True"
            PopupDragHandleControlID="programmaticPopupDragHandle"
            RepositionMode="RepositionOnWindowScroll" >
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel runat="server" CssClass="modalPopup" ID="programmaticPopup" style="display:none;width:350px;padding:10px">
            <asp:Panel runat="Server" ID="programmaticPopupDragHandle" Style="cursor: move;background-color:#DDDDDD;border:solid 1px Gray;color:Black;text-align:center;">
                Status
            </asp:Panel>
                <contenttemplate></contenttemplate>
            <asp:UpdatePanel id="UpdatePanel3" runat="server">
                <contenttemplate>
            <br />
                    <asp:Label ID="lblStatusMessage" runat="server" Height="19px" Text="Label"></asp:Label>
                </contenttemplate>
            </asp:UpdatePanel>
<asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click" Width="58px" />           <br />
        </asp:Panel>
        
    <table cellspacing="10" style="width: 900px">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Font-Names="PCS NEPALI" Height="22px" SkinID="PCSlbl"
                    Text="klxnf] gfd" Width="92px"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtFName" runat="server" MaxLength="35" SkinID="PCStxt" ToolTip="First Name"
                    Width="130px"></asp:TextBox></td>
            <td>
                <asp:Label ID="Label2" runat="server" Font-Names="PCS NEPALI" Height="22px" SkinID="PCSlbl"
                    Text="ljrsf] gfd" Width="92px"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtMName" runat="server" MaxLength="15" SkinID="PCStxt" Width="130px"></asp:TextBox></td>
            <td>
                <asp:Label ID="Label3" runat="server" Font-Names="PCS NEPALI" Height="22px" SkinID="PCSlbl"
                    Text="y/" Width="92px"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtSurName" runat="server" MaxLength="35" SkinID="PCStxt" ToolTip="Surname"
                    Width="130px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Font-Names="PCS NEPALI" Height="22px" SkinID="PCSlbl"
                    Text="ln" Width="92px"></asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlGender" runat="server" SkinID="PCSddl" Width="135px">
                    <asp:ListItem Value="SG">%fGg'xf];</asp:ListItem>
                    <asp:ListItem Value="M">k'?if</asp:ListItem>
                    <asp:ListItem Value="F">dlxnf</asp:ListItem>
                    <asp:ListItem Value="O">cGo</asp:ListItem>
                </asp:DropDownList></td>
            <td>
                <asp:Label ID="Label8" runat="server" Font-Names="PCS NEPALI" Height="22px" SkinID="PCSlbl"
                    Text="lhNnf" Width="92px"></asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlDistrict" runat="server" Width="135px" SkinID="PCSddl">
                </asp:DropDownList></td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Registration"></asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlOrgType" runat="server" SkinID="PCSddl" Width="135px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search"
                    Width="68px" /><asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel"
                    Width="68px" /></td>
        </tr>
        <tr>
            <td style="height: 37px" colspan="6" valign="bottom">
                <hr />
            <asp:UpdatePanel id="UpdatePanel1" runat="server"><contenttemplate>
<asp:Panel id="Panel1" runat="server" Width="100%" Height="350px" ScrollBars="Auto"><asp:Label id="lblSearch" runat="server" Font-Bold="True"></asp:Label><BR />

<asp:GridView id="grdPerson" runat="server" Width="848px" SkinID="PCSGridView" ForeColor="#333333" CellPadding="0" AutoGenerateColumns="False" OnRowDataBound="grdPerson_RowDataBound" OnRowCreated="grdPerson_RowCreated" OnSelectedIndexChanged="grdPerson_SelectedIndexChanged">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="PERSONID" HeaderText="g+="></asp:BoundField>
<asp:BoundField DataField="FIRSTNAME" HeaderText="klxnf] gfd"></asp:BoundField>
<asp:BoundField DataField="MIDDLENAME" HeaderText="ljrsf] gfd"></asp:BoundField>
<asp:BoundField DataField="SURNAME" HeaderText="y/"></asp:BoundField>
<asp:BoundField DataField="RDFULLNAME" HeaderText="k'/f gfd y/"></asp:BoundField>
<asp:BoundField DataField="RDGENDER" HeaderText="ln"></asp:BoundField>
<asp:BoundField DataField="DOB" HeaderText="hGd ldlt">
<ItemStyle Font-Names="Verdana"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DISTRICT" HeaderText="lhNnf"></asp:BoundField>
<asp:BoundField DataField="FATHERNAME" HeaderText="afa'sf] gfd"></asp:BoundField>
<asp:BoundField DataField="GFATHERNAME" HeaderText="afh]sf] gfd"></asp:BoundField>
<asp:CommandField ShowSelectButton="True">
<ItemStyle Font-Names="Verdana"></ItemStyle>
</asp:CommandField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> </asp:Panel> 
</contenttemplate>
                    <triggers>
<asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>

