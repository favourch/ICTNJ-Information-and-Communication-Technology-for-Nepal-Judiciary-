<%@ Page AutoEventWireup="true" CodeFile="ScrollPosition.aspx.cs" Inherits="MODULES_OAS_Test_ScrollPosition" Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master"
    Title="Untitled Page" %>

<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager id="ScriptManager1" runat="server">
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
    </script>

    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
            <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Auto" Width="500px">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField HeaderText="name" />
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
            </asp:Panel>
        </contenttemplate>
    </asp:UpdatePanel>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:UpdatePanel id="UpdatePanel2" runat="server">
        <contenttemplate>
<asp:TextBox id="TextBox2" runat="server"></asp:TextBox> 
</contenttemplate>
        <triggers>
<asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
    </asp:UpdatePanel>
    <input id="Submit1" type="submit" value="submit" /><br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" UseSubmitBehavior="False" />
</asp:Content>
