<%@ Page AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Language="C#" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>
            Slide Show Extender Control</h2>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div>
            <br />
            <br />
            <asp:Image ID="Image1" runat="server" Height="316px" Width="388px" /><br />
            <br />
            <asp:Label ID="lblImageDescription" runat="server"></asp:Label><br />
            <cc1:SlideShowExtender ID="SlideShowExtender1" runat="server" AutoPlay="true" ImageDescriptionLabelID="lblImageDescription"
                Loop="true" PlayInterval="2000" SlideShowServiceMethod="GetSlides" TargetControlID="Image1">
            </cc1:SlideShowExtender>
        </div>
    </form>
</body>
</html>
