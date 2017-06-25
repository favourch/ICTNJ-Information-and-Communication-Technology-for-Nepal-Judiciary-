<%@ Page Language="C#" MasterPageFile="~/MODULES/COMMON/MasterPage.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeFile="LibraryMaterialEditor.aspx.cs" Inherits="MODULES_LIS_Forms_LibraryMaterialEditor" Title="LIS-Library Material Editor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <script language="javascript" type="text/javascript">
        function LoadImage()
        {
            document.getElementById("<%=this.LoadImageX.ClientID %>").style.width="28px";
            document.getElementById("<%=this.LoadImageX.ClientID %>").style.height="28px";
        }
        function UnloadImage()
        {
            document.getElementById("<%=this.LoadImageX.ClientID %>").style.display="none";
        }
    </script>

    <div style="width:100%; height:auto">
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager><asp:HiddenField ID="hdnPagingIndex" runat="server" />
        <table style="width: 630px; position: static" id="TABLE1">
            <tr>
                <td colspan="5" style="height: 34px">
                    <asp:Label ID="Label8" runat="server" SkinID="UnicodeHeadlbl" Style="position: static" Text="Library Material Search"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 90px">
                    <asp:Label ID="Label1" runat="server" Style="position: static" Text="Organization" SkinID="Unicodelbl"></asp:Label></td>
                <td colspan="4">
                    <asp:DropDownList ID="ddlOrg" runat="server" Style="position: static" Width="538px" SkinID="Unicodeddl">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 90px; height: 13px">
                    <asp:Label ID="Label2" runat="server" Style="position: static" Text="Library" SkinID="Unicodelbl"></asp:Label></td>
                <td style="width: 200px; height: 13px">
                    <asp:DropDownList ID="ddlLibrary" runat="server" Style="position: static" Width="195px" SkinID="Unicodeddl">
                    </asp:DropDownList></td>
                <td style="width: 50px; height: 13px">
                </td>
                <td style="width: 90px; height: 13px">
                    <asp:Label ID="Label4" runat="server" Style="position: static" Text="Category" SkinID="Unicodelbl"></asp:Label></td>
                <td style="width: 200px; height: 13px">
                    <asp:DropDownList ID="ddlCategory" runat="server" Style="position: static" Width="195px" SkinID="Unicodeddl">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 90px; height: 11px">
                    <asp:Label ID="Label3" runat="server" Style="position: static" Text="Type" SkinID="Unicodelbl"></asp:Label></td>
                <td style="width: 200px; height: 11px">
                    <asp:DropDownList ID="ddlType" runat="server" Style="position: static" Width="195px" SkinID="Unicodeddl">
                    </asp:DropDownList></td>
                <td style="width: 50px; height: 11px">
                </td>
                <td style="width: 90px; height: 11px">
                    <asp:Label ID="Label6" runat="server" Style="position: static" Text="Language" SkinID="Unicodelbl"></asp:Label></td>
                <td style="width: 200px; height: 11px">
                    <asp:DropDownList ID="ddlLanguage" runat="server" Style="position: static" Width="195px" SkinID="Unicodeddl">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 90px; height: 8px">
                    <asp:Label ID="Label5" runat="server" Style="position: static" Text="Publisher" SkinID="Unicodelbl"></asp:Label></td>
                <td style="width: 200px; height: 8px">
                    <asp:DropDownList ID="ddlPublisher" runat="server" Style="position: static" Width="195px" SkinID="Unicodeddl">
                    </asp:DropDownList></td>
                <td style="width: 50px; height: 8px">
                </td>
                <td style="width: 90px; height: 8px">
                    <asp:Label ID="Label7" runat="server" Style="position: static" Text="Call no" SkinID="Unicodelbl"></asp:Label></td>
                <td style="width: 200px; height: 8px">
                    <asp:TextBox ID="txtCallNo" runat="server" Style="position: static" Width="189px" SkinID="Unicodetxt"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 90px; height: 17px" valign="top">
                    <asp:Label ID="Label10" runat="server" Style="position: static" Text="Keyword<br>List" Font-Bold="True" Font-Italic="True" Font-Underline="False" SkinID="Unicodelbl"></asp:Label></td>
                <td style="width: 200px; height: 17px" valign="top">
                    <asp:Panel ID="Panel1" runat="server" Height="150px" ScrollBars="Auto" Style="position: static"
                        Width="195px">
                        <asp:CheckBoxList ID="lstKeyword" runat="server" Style="position: static">
                        </asp:CheckBoxList></asp:Panel>
                </td>
                <td style="width: 50px; height: 17px" valign="top">
                </td>
                <td style="width: 90px; height: 17px" valign="top">
                    <asp:Label ID="Label11" runat="server" Style="position: static" Text="Author<br>List" Font-Bold="True" Font-Italic="True" Font-Underline="False" SkinID="Unicodelbl"></asp:Label></td>
                <td style="width: 200px; height: 17px" valign="top">
                    <asp:Panel ID="Panel2" runat="server" Height="150px" ScrollBars="Auto" Style="position: static"
                        Width="195px">
                        <asp:CheckBoxList ID="lstAuthor" runat="server" Style="position: static">
                        </asp:CheckBoxList></asp:Panel>
                </td>
            </tr>
            <tr>
                <td style="width: 90px; height: 32px" align="center">
                    <asp:Image ID="LoadImageX" runat="server" Height="0px" ImageUrl="~/MODULES/LIS/Images/Loading.gif"
                        Style="position: static" Width="0px" />
                </td>
                <td style="height: 32px; width: 450px;" valign="middle" colspan="4">
                    <asp:Button ID="btnSearch" runat="server" Style="position: static" Text="Search" OnClick="btnSearch_Click" OnClientClick="LoadImage();" SkinID="Normal" />
                    <asp:Button ID="btnCancel" runat="server" Style="position: static" Text="Cancel" OnClick="btnCancel_Click" SkinID="Cancel" /></td>
            </tr>
            <tr>
                <td align="center" style="width: 90px; height: 6px">
                </td>
                <td colspan="4" style="width: 450px; height: 6px" valign="middle">
                </td>
            </tr>
        </table>
                        
<asp:Label style="POSITION: static" id="lblRecordCount" runat="server" Font-Bold="True" Font-Underline="True" Font-Italic="True"></asp:Label><br />
                    <asp:Panel ID="pnlGrid" runat="server" Height="300px" ScrollBars="Auto" Style="position: static"
                        Width="100%">
                        
<asp:GridView style="POSITION: static" id="grdSearch" runat="server" ForeColor="#333333" Width="95%" OnSelectedIndexChanged="grdSearch_SelectedIndexChanged" AutoGenerateColumns="False" BorderColor="Navy" BorderStyle="Solid" BorderWidth="1px" CellPadding="0" SkinID="Unicodegrd">
<RowStyle HorizontalAlign="Left" BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
<asp:BoundField DataField="LMaterialID" HeaderText="Material ID">
<ItemStyle Width="80px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="CallNo" HeaderText="Call No">
<ItemStyle Width="100px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Title" HeaderText="Title">
<ItemStyle Width="150px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="BoardSubjectHeading" HeaderText="Board Subject Heading">
<ItemStyle Width="200px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="SeriesStatement" HeaderText="Series Statement">
<ItemStyle Width="200px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="CopyCount" HeaderText="Noc">
<ItemStyle Width="30px"></ItemStyle>
</asp:BoundField>
<asp:CommandField ShowSelectButton="True">
<ItemStyle Font-Bold="True" Font-Underline="True" Width="50px" HorizontalAlign="Center"></ItemStyle>
</asp:CommandField>
</Columns>

<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle HorizontalAlign="Left" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> 
                            
                        
                    </asp:Panel>
        
    </div>
</asp:Content>

