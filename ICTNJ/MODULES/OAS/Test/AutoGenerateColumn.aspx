<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AutoGenerateColumn.aspx.cs" Inherits="MODULES_OAS_Test_AutoGenerateColumn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <span style="color: #0000ff; font-family: Arial"><strong><span style="text-decoration: underline">AutoGenetatedColumns Gridview<br />
            </span>
                <asp:Button ID="Button1" runat="server" Text="Student" OnClick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" Text="Teacher" OnClick="Button2_Click" />&nbsp;<asp:Button ID="Button5" runat="server"
                    OnClick="Button5_Click" Text="Class" /><br />
                <br />
            </strong></span>
            <asp:GridView ID="GridView1" runat="server" Width="350px" EnableTheming="False" AutoGenerateColumns="False">
            </asp:GridView>
            <br />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="First Student" />
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="First Teacher" />&nbsp;<asp:Button ID="Button6" runat="server"
                OnClick="Button6_Click" Text="First Class" /><br />
            <br />
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="11pt" ForeColor="#660033" Text="Label"></asp:Label><br />
        </div>
    </form>
</body>
</html>
