<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true" CodeFile="Captcha.aspx.cs" Inherits="MODULES_OAS_LookUp_Captcha" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager runat="server" ID="SM">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript">
        function popx()
        {
            window.showModalDialog('committee.aspx');
        }
    </script>
    <%--<link href="../../../MODULES/COMMON/CSS/StyleSheet.css" rel="stylesheet" type="text/css" />--%>
    <div style="width:100%; height:450px">
        <asp:Image ID="ImageButton1" runat="server" ImageUrl="~/MODULES/OAS/LookUp/capthanew.aspx" Height="35px" Width="105px" />&nbsp;<br />
        <asp:Button ID="Button2" runat="server" OnClientClick="popx()" Text="Button" /><br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="New Captcha" OnClientClick="popx" /><br />
        <asp:DataList ID="DataList1" runat="server" CellPadding="4" ForeColor="#333333">
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <AlternatingItemStyle BackColor="White" />
            <ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        </asp:DataList></div>
    
    <asp:Panel ID="PopupMenu" runat="server" CssClass="popupMenu" >
        <asp:LinkButton ID="LinkButton1" runat="server" SkinID="aa" CommandName="Edit" Text="Edit" Font-Names="Verdana" Font-Size="8pt"></asp:LinkButton>
        <br />
        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete" Font-Names="Verdana" Font-Size="8pt" SkinID="aa" Text="Delete"></asp:LinkButton>
    </asp:Panel>
    
    <cc1:HoverMenuExtender id="hme2" runat="Server" offsetx="0" offsety="0" popdelay="50" popupcontrolid="PopupMenu" popupposition="right" targetcontrolid="Button1">
    </cc1:hovermenuextender>
</asp:Content>

