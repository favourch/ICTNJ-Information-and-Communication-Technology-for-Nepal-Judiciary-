<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CallBack.aspx.cs" Inherits="MODULES_OAS_Test_CallBack" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>

    <script type="text/javascript">
        function ReceiveServerData(arg, context)
        {
            Message.innerText = 'Processed callback.';
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input onclick="CallServer(5, '')" type="button" value="Callback" />
        <br />
        <span id="Message"></span>
    </div>
    </form>
</body>
</html>
