<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true" CodeFile="StockReport.aspx.cs" Inherits="MODULES_OAS_ReportForms_StockReport" Title=":.सामान रिपोर्ट" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="width:100%; height:auto">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <br />
    <div style ="PADDING-LEFT: 20px;">
    <table  style="PADDING-LEFT: 20px; WIDTH: 750px" border ="0" cellpadding ="1" cellspacing="1">
        <TR>
          <TD style="WIDTH: 141px; HEIGHT: 25px" vAlign=baseline align=left colSpan=4>
           <asp:Label id="Label2" runat="server" Text="सामान विवरण रिपोर्ट" SkinID="UnicodeHeadlbl" Width="455px"></asp:Label></TD></TR>
      
        <tr>
            <td style="width: 351px; height: 68px;" valign="top">
                <table>
                    <tr>
                        <td style="background-color:lightslategray;height: 21px; width: 219px;">
                            &nbsp;<asp:Label ID="lblOrgName" runat="server" Font-Bold="True" style ="color:White;" Text="कार्यलय"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="height: 231px">
                            <div id="dvOrgLst" style=" OVERFLOW: auto;height:224px">
                                <asp:GridView ID="grdOrgList" runat="server" AutoGenerateColumns="False" ShowHeader="False" OnRowCreated="grdOrgList_RowCreated" Width="199px" EnableTheming="True">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkOrg" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="OrgID" HeaderText="OrgID" />
                                    <asp:BoundField DataField="OrgName" HeaderText="OrgName" />
                                </Columns>
                            </asp:GridView>
                            </div>
                        </td>
                    </tr>
                </table>
                
            </td>
            <td style="height: 68px" valign="top">
                <table border ="0" style="PADDING-LEFT: 20px" cellpadding="0" cellspacing="0" >
                    <tr>
                        <td style="width: 50px;">
                            <asp:Label ID="lblCategory" runat="server" SkinID="Unicodelbl" Text="समूह" ToolTip="समूह"></asp:Label></td>
                        <td>
                            <asp:DropDownList ID="ddlCategory_cat" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"
                                TabIndex="5" ToolTip="समूह" Width="167px">
                            </asp:DropDownList></td>
                        <td style="width: 4px;">
                            <asp:Label ID="lblSubCategory" runat="server" SkinID="Unicodelbl" Text="उप-समूह"
                                ToolTip="उप-समूह" Width="62px"></asp:Label></td>
                        <td style="width: 50px;">
                            <asp:DropDownList ID="ddlSubCategory_cat" runat="server" AutoPostBack="True" Enabled="False"
                                OnSelectedIndexChanged="ddlSubCategory_SelectedIndexChanged" TabIndex="6" ToolTip="उप-समूह"
                                Width="162px">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td style="width: 50px; height: 40px">
                            <asp:Label ID="lblItem" runat="server" SkinID="Unicodelbl" Text="सामान" ToolTip="सामान"></asp:Label></td>
                        <td colspan ="3" style="height: 40px">
                            <asp:DropDownList ID="ddlItems_cat" runat="server" AutoPostBack="True" Enabled="False"
                                TabIndex="7" ToolTip="सामान" Width="435px">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td style="width: 50px; height: 21px">
                        </td>
                        <td align="right" colspan="3" style="height: 21px">
                            <asp:Button ID="btnReport" runat="server" OnClick="btnReport_Click" SkinID="Normal"
                                Text="रिपोर्ट हेनुहोस्" />
                            <asp:Button ID="btnCancel" runat="server" SkinID="Cancel" Text="Cancel" OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                    
                
                </table>
            </td>
        </tr>
       
    </table>
    <br /><br /><br /><br /><br /><br />



</asp:Content>

