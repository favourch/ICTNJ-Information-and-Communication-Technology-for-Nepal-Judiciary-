<%@ Page AutoEventWireup="true" CodeFile="Unit.aspx.cs" Inherits="MODULES_LJMS_LookUp_Unit" Language="C#" MasterPageFile="~/MODULES/LJMS/LJMSMasterPage.master"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div style="width: 100%; height: auto">
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
        <ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground" DropShadow="True" PopupControlID="programmaticPopup"
            PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForModalPopup">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none; width: 350px; padding: 10px">
            <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD; border: solid 1px Gray; color: Black; text-align: center;">
                Save Status
            </asp:Panel>
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label><br />
            <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click" Text="OK" Width="58px" />
            <br />
        </asp:Panel>
        <br />
        <table width="400">
            <tr>
                <td colspan="2" style="height: 26px">
                    <asp:Label ID="Label5" runat="server" SkinID="UnicodeHeadlbl" Text="Unit Registration"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label1" runat="server" SkinID="LJMSlbl" Text="एकाईको नाम"></asp:Label></td>
                <td style="width: 300px">
                    <asp:TextBox ID="txtName_Rqd" runat="server" SkinID="LJMStxt" Width="250px" MaxLength="49"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label2" runat="server" SkinID="LJMSlbl" Text="ठेगाना"></asp:Label></td>
                <td style="width: 300px">
                    <asp:TextBox ID="txtAddress_Rqd" runat="server" SkinID="LJMStxt" Width="250px" MaxLength="49"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label3" runat="server" SkinID="LJMSlbl" Text="फोन नं"></asp:Label></td>
                <td style="width: 300px">
                    <asp:TextBox ID="txtPhone_Rqd" runat="server" SkinID="LJMStxt" Width="250px" MaxLength="29"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label4" runat="server" SkinID="LJMSlbl" Text="Active"></asp:Label></td>
                <td style="width: 300px">
                    <asp:CheckBox ID="cnkActive" runat="server" SkinID="smallChk" /></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 300px; height: 21px">
                    <asp:Button ID="btnSubmit" runat="server" SkinID="Normal" Text="Submit" OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnCancel" runat="server" SkinID="Cancel" Text="Cancel" OnClick="btnCancel_Click" /></td>
            </tr>
        </table>
        <asp:Label ID="lblCount" runat="server" SkinID="LJMSlbl"></asp:Label><br />
        <asp:Panel ID="Panel1" runat="server" Height="300px" Width="700px" ScrollBars="Auto">
            <asp:GridView ID="grdUnit" runat="server" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333" GridLines="None" OnDataBound="grdUnit_DataBound"
                OnRowDataBound="grdUnit_RowDataBound" OnSelectedIndexChanged="grdUnit_SelectedIndexChanged" Width="670px" SkinID="LJMSgrd">
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <Columns>
                    <asp:BoundField DataField="UnitID" HeaderText="युनिट कोड" />
                    <asp:BoundField DataField="UnitName" HeaderText="युनिटको नाम" />
                    <asp:BoundField DataField="UnitAddress" HeaderText="ठेगाना" />
                    <asp:BoundField DataField="UnitPhone" HeaderText="फोन नं" />
                    <asp:BoundField DataField="Active" HeaderText="सक्रिय" >
                        <ItemStyle Font-Names="Verdana" />
                    </asp:BoundField>
                    <asp:CommandField ShowSelectButton="True" >
                        <ItemStyle Font-Names="Verdana" />
                    </asp:CommandField>
                </Columns>
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <EditRowStyle BackColor="#999999" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
        </asp:Panel>
    </div>
</asp:Content>
