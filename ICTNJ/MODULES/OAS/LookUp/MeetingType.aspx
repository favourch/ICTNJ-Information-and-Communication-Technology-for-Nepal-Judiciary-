<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true" CodeFile="MeetingType.aspx.cs" Inherits="MODULES_OAS_LookUp_MeetingType" Title="OAS | Meeting Type" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="SM" runat="server">
    </asp:ScriptManager>
    <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
    <ajaxtoolkit:modalpopupextender id="programmaticModalPopup" runat="server" backgroundcssclass="modalBackground" behaviorid="programmaticModalPopupBehavior"
        dropshadow="True" popupcontrolid="programmaticPopup" popupdraghandlecontrolid="programmaticPopupDragHandle" repositionmode="RepositionOnWindowScroll"
        targetcontrolid="hiddenTargetControlForModalPopup">
    </ajaxtoolkit:modalpopupextender>
    <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="padding-right: 10px; display: none; padding-left: 10px; padding-bottom: 10px;
        width: 350px; padding-top: 10px">
        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="border-right: gray 1px solid; border-top: gray 1px solid; border-left: gray 1px solid;
            cursor: move; color: black; border-bottom: gray 1px solid; background-color: #dddddd; text-align: center">
            Save Status
        </asp:Panel>
        <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label><br />
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click" Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    <div style="width: 100%; height: 500px">
        <br />
        <table height="370" width="800">
            <tr>
                <td rowspan="2" style="width: 250px" valign="top">
                    <asp:ListBox ID="lstMeetingType" runat="server" AutoPostBack="True" Height="375px" SkinID="Unicodelst"
                        Width="230px" OnSelectedIndexChanged="lstMeetingType_SelectedIndexChanged"></asp:ListBox></td>
                <td height="340" style="width: 550px" valign="top">
                    <table width="500">
                        <tr>
                            <td style="width: 130px">
                                <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="मिटिङको प्रकार"></asp:Label></td>
                            <td style="width: 370px">
                                <asp:TextBox ID="txtMeetingType" runat="server" SkinID="Unicodetxt" Width="240px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 130px" valign="top">
                                <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="विवरण"></asp:Label></td>
                            <td style="width: 370px">
                                <asp:TextBox ID="txtDescription" runat="server" Height="100px" SkinID="Unicodetxt" TextMode="MultiLine" Width="360px"></asp:TextBox></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="30" style="width: 550px" valign="bottom">
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" SkinID="Normal" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" SkinID="Cancel" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

