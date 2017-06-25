<%@ Page Language="C#" MasterPageFile="~/MODULES/LJMS/LJMSMasterPage.master" AutoEventWireup="true" CodeFile="DesignationLevel.aspx.cs" Inherits="MODULES_LJMS_LookUp_DesignationLevel" Title="LJMS | Designation Level" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
    <ajaxtoolkit:modalpopupextender id="programmaticModalPopup" runat="server" backgroundcssclass="modalBackground"
        behaviorid="programmaticModalPopupBehavior" dropshadow="True" popupcontrolid="programmaticPopup"
        popupdraghandlecontrolid="programmaticPopupDragHandle" repositionmode="RepositionOnWindowScroll"
        targetcontrolid="hiddenTargetControlForModalPopup">
    </ajaxtoolkit:modalpopupextender>
    <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none;
        width: 350px; padding: 10px">
        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD;
            border: solid 1px Gray; color: Black; text-align: center;">
            Status
        </asp:Panel>
        <contenttemplate></contenttemplate>
        <asp:UpdatePanel id="UpdatePanel3" runat="server">
            <contenttemplate>
            <br />
                    <asp:Label ID="lblStatusMessage" runat="server" Height="19px" Text="Label"></asp:Label>
                </contenttemplate>
        </asp:UpdatePanel>
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
            Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    <br />
    <asp:Label ID="Label3" runat="server" SkinID="UnicodeHeadlbl" Text="श्रेणीको विवरण"></asp:Label>
    <div style="width:100%; height:386px">
        <table width="900">
            <tr>
                <td rowspan="2" style="width: 110px" valign="top">
                    <asp:ListBox ID="lstDesignationLevel" runat="server" Height="210px" Width="100px" AutoPostBack="True" OnSelectedIndexChanged="lstDesignationLevel_SelectedIndexChanged" SkinID="Unicodelst"></asp:ListBox></td>
                <td style="width: 60px; height: 11px" valign="top">
                    <asp:Label ID="Label1" runat="server" Text="श्रेणी" Width="50px" SkinID="Unicodelbl"></asp:Label></td>
                <td style="height: 11px" valign="top">
                    <asp:TextBox ID="txtLevel" runat="server" SkinID="Unicodetxt" MaxLength="5" Width="113px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 60px; height: 162px">
                    &nbsp;</td>
                <td style="height: 162px" valign="top">
                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Width="59px" SkinID="Normal" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" SkinID="Cancel" />
                </td>
            </tr>
        </table>
    
    </div>
</asp:Content>


