<%@ Page AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="MODULES_DLPDS_Login" Language="C#" Title="ICT-NJ | Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script language="javascript" src="../../COMMON/JS/Validation.js" type="text/javascript"></script>
    <script language="javascript" src="../../COMMON/JS/DateValidator.js" type="text/javascript"></script>

    <link href="../Login-css/bee.css" media="screen" rel="stylesheet" type="text/css" />
    <style type="text/css"> 
		img, div { behavior: url(iepngfix.htc) }
    </style>
</head>
<%--<body bgcolor="#EAEDF4">
    <form id="form1" runat="server">
        <div>
            <table style="width: 100%; position: static; height: 100%">
                <tr>
                    <td align="center" style="width: 100%; height: 100%" valign="top">
                        <br />
                        <br />
                        <br />
                        <table style="width: 280px; position: static; background-color: lightsteelblue">
                            <tbody>
                                <tr>
                                    <td align="left" colspan="2">
                                        <asp:Label ID="lblStatus" runat="server" Font-Bold="False" Font-Italic="True" Font-Underline="True" ForeColor="#400000" Style="position: static"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 75px">
                                        <asp:Label ID="Label1" runat="server" Style="position: static" Text="Username"></asp:Label></td>
                                    <td align="left" style="width: 205px">
                                        <asp:TextBox ID="txtUsername_Rqd" runat="server" Style="position: static" TabIndex="1" ToolTip="Username" Width="200px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 75px">
                                        <asp:Label ID="Label2" runat="server" Style="position: static" Text="Password"></asp:Label></td>
                                    <td align="left" style="width: 205px">
                                        <asp:TextBox ID="txtpassword_Rqd" runat="server" Style="position: static" TabIndex="2" TextMode="Password" ToolTip="Password" Width="200px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 75px; height: 18px">
                                    </td>
                                    <td align="left" style="width: 205px; height: 18px">
                                        <asp:Button ID="btnLogin" runat="server" Height="22px" OnClick="btnLogin_Click" Style="position: static" TabIndex="4"
                                            Text="Login" /><asp:Button ID="btnCancel" runat="server" Height="22px" OnClick="btnCancel_Click" Style="position: static" TabIndex="5" Text="Cancel" Width="50px" /></td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>--%>
    <body id="login">
        <div id="header">
            <h2>
                <img border="0" src="../Login-image/ictnj-key-man.png">ICT-NJ Login</h2>
        </div>
        <form runat="server" id="loginFrm">
            <label>
                Username:   
            </label>
                <asp:TextBox ID="txtUsername_Rqd" runat="server" Style="position: static" TabIndex="1" ToolTip="Username" Width="200px"></asp:TextBox>
            <label>
                Password:
            </label>
                <asp:TextBox ID="txtpassword_Rqd" runat="server" Style="position: static" TabIndex="2" TextMode="Password" ToolTip="Password" Width="200px"></asp:TextBox>
                <asp:Button ID="btnLogin" runat="server" CssClass="button" OnClick="btnLogin_Click" Text="Login" Width="80px" Height="28px" />
            <br />
        </form>
        <br />
        <div id="footer">
            Information and Communication Technology for Nepal Judiciary (ICT-NJ)
            <br />
            <asp:Label ID="lblStatus" runat="server" Font-Bold="True" Font-Italic="True" Font-Underline="True" ForeColor="#400000" Style="position: static"></asp:Label>
        </div>
    </body>
</html>
