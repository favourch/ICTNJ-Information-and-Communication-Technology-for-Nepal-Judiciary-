<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NoScriptTest.aspx.cs" Inherits="MODULES_OAS_Captcha_NoScriptTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <noscript>
        <meta content="5; URL=NoScript.aspx" http-equiv="refresh" >
    </noscript>
    <form id="form1" runat="server">
    <div>
        This page cannot be serve without javascript ...
        <br />
        <input type="button" id="test" value="Click me" onclick="alert('Hi, Sj Shrestha !')" />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" /></div>
    </form>
</body>
</html>
