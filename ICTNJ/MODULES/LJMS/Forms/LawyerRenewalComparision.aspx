<%@ Page AutoEventWireup="true" CodeFile="LawyerRenewalComparision.aspx.cs" Inherits="MODULES_LJMS_Forms_LawyerRenewalComparision"
    Language="C#" MasterPageFile="~/MODULES/LJMS/LJMSMasterPage.master" Title="NBA | Private Lawyer Renew Date Comparision" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div style="width: 100%; height: 500px">
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager><br />
        <asp:Label ID="Label3" runat="server" SkinID="UnicodeHeadlbl">Lawyer Renewal Comparission</asp:Label><br />
        <asp:Label ID="lblStatus" runat="server" SkinID="UnicodeHeadlbl"></asp:Label><br />
        <table width="900">
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label4" runat="server" SkinID="LJMSlbl" Text="लाईसेन्स् नं"></asp:Label></td>
                <td style="width: 200px">
                    <asp:TextBox ID="txtLisenceNo" runat="server" SkinID="LJMStxt" Width="170px"></asp:TextBox></td>
                <td style="width: 100px">
                    <asp:Label ID="Label5" runat="server" SkinID="LJMSlbl" Text="प्रकार"></asp:Label></td>
                <td style="width: 200px">
                    <asp:DropDownList ID="ddlLawyerType" runat="server" SkinID="Ljmsddl" Width="174px">
                    </asp:DropDownList></td>
                <td style="width: 100px">
                    <asp:Label ID="Label6" runat="server" SkinID="LJMSlbl" Text="एकाई"></asp:Label></td>
                <td style="width: 200px">
                    <asp:DropDownList ID="ddlUnit" runat="server" SkinID="Ljmsddl" Width="174px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label1" runat="server" SkinID="LJMSlbl" Text="बर्ष देखि"></asp:Label></td>
                <td style="width: 200px">
                    <asp:TextBox ID="txtStartYear" runat="server" SkinID="LJMStxt" Width="60px" MaxLength="4"></asp:TextBox></td>
                <td style="width: 100px">
                </td>
                <td style="width: 200px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 200px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label2" runat="server" SkinID="LJMSlbl" Text="बर्ष सम्म"></asp:Label></td>
                <td style="width: 200px">
                    <asp:TextBox ID="txtEndYear" runat="server" SkinID="LJMStxt" Width="60px" MaxLength="4"></asp:TextBox></td>
                <td style="width: 100px">
                </td>
                <td style="width: 200px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 200px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 200px">
                    <asp:Button ID="btnGenerateReport" runat="server" OnClick="btnGenerateReport_Click" SkinID="Dynamic" Text="Compare Renew Date"
                        Width="144px" /></td>
                <td style="width: 100px">
                </td>
                <td style="width: 200px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 200px">
                </td>
            </tr>
        </table>
        <cc1:FilteredTextBoxExtender ID="fltEndYear" runat="server" FilterType="Numbers" TargetControlID="txtEndYear">
        </cc1:FilteredTextBoxExtender>
        <cc1:FilteredTextBoxExtender ID="fltStartYear" runat="server" FilterType="Numbers" TargetControlID="txtStartYear">
        </cc1:FilteredTextBoxExtender>
    </div>
</asp:Content>

