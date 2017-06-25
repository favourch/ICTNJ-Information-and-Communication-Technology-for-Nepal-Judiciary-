<%@ Page Language="C#" MasterPageFile="~/MODULES/LJMS/LJMSMasterPage.master" AutoEventWireup="true" CodeFile="JudgeWork.aspx.cs" Inherits="MODULES_LJMS_LookUp_JudgeWork" Title="PMS | Judge Work List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 900px">
        <tr>
            <td colspan="2" valign="top">
                <asp:Label ID="Label1" runat="server" SkinID="UnicodeHeadlbl" Text="न्यायाधीशको कार्य सम्पादन निरीक्षणको विवरण"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 300px" valign="top">
            <div style="Height:400px;WIDTH: 290px; OVERFLOW: scroll">
                            <asp:ListBox ID="lstWorks" runat="server" AutoPostBack="True" Height="380px" OnSelectedIndexChanged="lstWorks_SelectedIndexChanged"
                    SkinID="Unicodelst"></asp:ListBox>
            </div>
</td>
            <td valign="top">
                <table style="width: 500px">
                    <tr>
                        <td style="width: 60px; height: 90px;" valign="top">
                            <asp:Label ID="lblDescription" runat="server" Text="विवरण" Width="50px"></asp:Label></td>
                        <td style="height: 90px;" valign="top">
                            <asp:TextBox ID="txtWork" runat="server" Height="162px" TextMode="MultiLine"
                                Width="320px" SkinID="Unicodetxt"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 60px" valign="top">
                            <asp:Label ID="lblActive" runat="server" Text="सक्रिय" Width="50px"></asp:Label></td>
                        <td valign="top">
                            <asp:CheckBox ID="chkActive" runat="server" /></td>
                    </tr>
                    <tr>
                        <td style="width: 60px; height: 21px">
                        </td>
                        <td style="height: 21px">
                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Submit" Width="65px" /><asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" Width="65px" /></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

