<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="MODULES_LIS_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>LIS-Login</title>
</head>
<body bgcolor="#EAEDF4">
    <form id="form1" runat="server">
    <div>
        <script language="javascript" src="../COMMON/JS/Validation.js" type="text/javascript"></script>
           <table style="width: 100%; position: static; height: 100%">
                <tr>
                    <td align="center" style="width: 100%; height: 100%" valign="top">
                        <br />
                        <br />
                        <br />
                        <TABLE style="WIDTH: 280px; POSITION: static; BACKGROUND-COLOR: lightsteelblue"><TBODY><TR><TD align=left colSpan=2><asp:Label style="POSITION: static" id="lblStatus" runat="server" ForeColor="#400000" Font-Underline="True" Font-Italic="True" Font-Bold="False"></asp:Label></TD></TR><TR><TD style="WIDTH: 75px" align=left><asp:Label style="POSITION: static" id="Label1" runat="server" Text="Username"></asp:Label></TD><TD 
                            style="WIDTH: 205px" align=left><asp:TextBox style="POSITION: static" id="txtUsername_Rqd" tabIndex=1 runat="server" Width="200px" ToolTip="Username"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 75px" align=left><asp:Label style="POSITION: static" id="Label2" runat="server" Text="Password"></asp:Label></TD><TD 
                            style="WIDTH: 205px" align=left><asp:TextBox style="POSITION: static" id="txtpassword_Rqd" tabIndex=2 runat="server" Width="200px" ToolTip="Password" TextMode="Password"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 75px; HEIGHT: 18px" 
                            align=left><asp:Label style="POSITION: static" id="Label3" runat="server" Text="Organization"></asp:Label> 
                            </TD><TD style="WIDTH: 205px; HEIGHT: 18px" align=left><asp:DropDownList style="POSITION: static" id="ddlOrg" tabIndex=3 runat="server" Width="206px">
                                                                </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 75px; HEIGHT: 18px" 
                            align=left></TD><TD 
                            style="WIDTH: 205px; HEIGHT: 18px" align=left><asp:Button style="POSITION: static" id="btnLogin" tabIndex=4 onclick="btnLogin_Click" runat="server" Text="Login" OnClientClick="return validate();" Height="22px"></asp:Button> 
                            <asp:Button style="POSITION: static" id="btnCancel" tabIndex=5 runat="server" Text="Cancel" Width="50px" Height="22px" OnClick="btnCancel_Click"></asp:Button></TD></TR></TBODY></TABLE>
                    </td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>
