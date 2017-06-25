<%@ Page AutoEventWireup="true" CodeFile="Default.aspx.cs" EnableEventValidation="false" Inherits="MODULES_Default" Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ICT-NJ | Home</title>
    <link href="COMMON/Images/pcslogo.ico" rel="SHORTCUT ICON">

    <script language="javascript" type="text/javascript">
        function ShowBorder(img)
        {
            img.style.borderStyle="solid";
            img.style.borderWidth="3px";
            img.style.borderColor="#400000";
        }
        
        function HideBorder(img)
        {
            img.style.borderStyle="none";
            img.style.borderWidth="0px";
        }
    </script>

</head>
<body style="margin: 0px 0px 0px 0px">
    <form id="form1" runat="server">
        <div style="width: 100%; height: auto;">
            <table style="width: 100%; height: auto">
                <tr>
                    <td align="left" style="width: 100%; height: auto" valign="top">
                        <br />
                        <table>
                            <tr>
                                <td style="width: 30px">
                                </td>
                                <td style="width: 3px">
                                    <asp:DataList ID="dListUserApplication" runat="server" CellPadding="0" CellSpacing="0" OnItemDataBound="dListUserApplication_ItemDataBound" RepeatColumns="1">
                                        <ItemTemplate>
                                            <table width="860">
                                                <tr>
                                                    <td align="center" height="145" valign="middle" width="50">
                                                        <asp:Label ID="lblSeq" runat="server" Font-Bold="False" Width="25px" SkinID="Unicodelbl"></asp:Label></td>
                                                    <td align="left" height="145" style="width: 240px;" valign="middle">
                                                        <asp:ImageButton ID="imgApplicaiton" runat="server" AlternateText='<%# Eval("ApplicationShortName") %>' CommandArgument='<%# Eval("ApplicationID") %>'
                                                            ImageUrl='<%# "~/MODULES/COMMON/IMAGES/APPLICATIONS/"+Eval("ApplicationShortName")+".gif" %>' OnClick="Application_Click" onmouseout="HideBorder(this)"
                                                            onmouseover="ShowBorder(this)" /></td>
                                                    <td align="left" height="145" style="width: 70px;" valign="middle">
                                                        <asp:Label ID="lblApplShortName" runat="server" Font-Bold="False" SkinID="Unicodelbl" Text='<%# Eval("ApplicationShortName") %>'></asp:Label></td>
                                                    <td align="left" height="145" style="width: 500px;" valign="middle">
                                                        <asp:Label ID="lblApplDesc" runat="server" Font-Bold="False" SkinID="Unicodelbl" Text='<%# Eval("ApplicationDescription") %>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="height: 21px">
                                                        <hr />
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                        <HeaderTemplate>
                                            <table width="860">
                                                <tr>
                                                    <td align="center" style="height: 21px" valign="middle" width="50">
                                                        <asp:Label ID="Label4" runat="server" Font-Bold="False" SkinID="Unicodelbl" Text="S. No"></asp:Label></td>
                                                    <td align="left" style="width: 230px; height: 21px" valign="middle">
                                                        <asp:Label ID="Label3" runat="server" Font-Bold="False" SkinID="Unicodelbl" Text="Application Logo"></asp:Label></td>
                                                    <td align="left" style="width: 70px; height: 21px" valign="middle">
                                                        &nbsp;
                                                        <asp:Label ID="Label2" runat="server" Font-Bold="False" SkinID="Unicodelbl" Text="Name"></asp:Label></td>
                                                    <td align="left" style="width: 500px; height: 21px" valign="middle">
                                                        &nbsp;
                                                        <asp:Label ID="Label1" runat="server" Font-Bold="False" SkinID="Unicodelbl" Text="Description"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="height: 21px">
                                                        <hr />
                                                    </td>
                                                </tr>
                                            </table>
                                        </HeaderTemplate>
                                    </asp:DataList></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
