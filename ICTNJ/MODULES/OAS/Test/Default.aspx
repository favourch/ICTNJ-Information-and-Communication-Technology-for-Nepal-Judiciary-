<%@ Page AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="MODULES_OAS_Test_Default" Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server" action="ScrollPosition.aspx" method="post">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>

            <script type="text/javascript">
        var scrollTop;
        
        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

        function BeginRequestHandler(sender, args)
        {
            var elem = document.getElementById('<%= this.Panel1.ClientID%>');
            scrollTop=elem.scrollTop;
        }

        function EndRequestHandler(sender, args)
        {
            var elem = document.getElementById('<%= this.Panel1.ClientID%>');
            elem.scrollTop = scrollTop;
        }
        
        function gettext()
        {
            var ddl = document.getElementById('<%= this.DropDownList1.ClientID%>');
            
            alert(ddl.options[ddl.selectedIndex].text);
        }
            </script>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Auto" Width="500px">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField HeaderText="name" />
                                <asp:CommandField ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
            <input id="Submit1" type="submit" value="submit" /><br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" UseSubmitBehavior="False" />
            <asp:Button ID="Button2" runat="server" CommandArgument="1" CommandName="Select" OnClick="Button1_Click" Text="New button" /><br />
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" onchange="gettext()">
                <asp:ListItem>qqq</asp:ListItem>
                <asp:ListItem>www</asp:ListItem>
            </asp:DropDownList></div>
    </form>
</body>
</html>
