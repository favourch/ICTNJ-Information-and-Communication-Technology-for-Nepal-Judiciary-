<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JavascriptTest.aspx.cs" Inherits="MODULES_OAS_Test_JavascriptTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Javascript testing</title>
    
    <script language="javascript" type="text/javascript">
        function validate()
        {
            var result = '2065/01/01' > '2065/01/01';
            alert(result);
            return false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClientClick="return validate();"/>
    </div>
    </form>
</body>
</html>
