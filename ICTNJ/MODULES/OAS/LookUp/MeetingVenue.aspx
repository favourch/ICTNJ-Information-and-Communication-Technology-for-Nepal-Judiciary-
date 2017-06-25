<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true" CodeFile="MeetingVenue.aspx.cs" Inherits="MODULES_OAS_LookUp_MeetingVenue" Title="OAS | Meeting Venue" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager ID="ScriptManager" runat="server">
    </asp:ScriptManager>
    <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
    <ajaxtoolkit:modalpopupextender id="programmaticModalPopup" runat="server" backgroundcssclass="modalBackground" behaviorid="programmaticModalPopupBehavior"
        dropshadow="True" popupcontrolid="programmaticPopup" popupdraghandlecontrolid="programmaticPopupDragHandle" repositionmode="RepositionOnWindowScroll"
        targetcontrolid="hiddenTargetControlForModalPopup">
    </ajaxtoolkit:modalpopupextender>
    <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none; width: 350px; padding: 10px">
        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD; border: solid 1px Gray; color: Black; text-align: center;">
            Save Status
        </asp:Panel>
        <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label><br />
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click" Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    <br />
    <div style="width: 100%; min-height: 450px;">
        <table height="400" width="700">
            <tr>
                <td rowspan="2" style="width: 250px">
                    <asp:ListBox ID="lstVenue" runat="server" AutoPostBack="True" Height="400px" OnSelectedIndexChanged="lstVenue_SelectedIndexChanged" Width="230px" SkinID="Unicodelst">
                    </asp:ListBox></td>
                <td height="370" style="width: 450px" valign="top">
                    <table width="450">
                        <tr>
                            <td style="width: 100px">
                                <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="संस्था"></asp:Label></td>
                            <td style="width: 350px">
                                <asp:DropDownList ID="ddlOrg" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlOrg_SelectedIndexChanged" SkinID="Unicodeddl" Width="340px">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                                <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="स्थान"></asp:Label></td>
                            <td style="width: 350px">
                                <asp:TextBox ID="txtVenue" runat="server" SkinID="Unicodetxt" Width="334px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px" valign="top">
                                <asp:Label ID="Label3" runat="server" SkinID="Unicodelbl" Text="ठेगाना"></asp:Label></td>
                            <td style="width: 350px">
                                <asp:TextBox ID="txtLocation" runat="server" Height="130px" SkinID="Unicodetxt" TextMode="MultiLine" Width="334px"></asp:TextBox></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="30" style="width: 450px" valign="bottom">
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" SkinID="Normal" />
                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click"
                        Text="Cancel" SkinID="Cancel" /></td>
            </tr>
        </table>
    </div>
</asp:Content>
