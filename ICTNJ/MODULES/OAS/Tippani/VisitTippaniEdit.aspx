<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true" CodeFile="VisitTippaniEdit.aspx.cs" Inherits="MODULES_OAS_Tippani_VisitTippaniEdit" Title="Untitled Page" %>

<%@ Register Src="../UserControls/VisitEntry.ascx" TagName="VisitEntry" TagPrefix="uc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <div style="width:100%; height:auto">
        <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
        <ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground" DropShadow="True" PopupControlID="programmaticPopup"
            PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForModalPopup">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none; width: 350px; padding: 10px">
            <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD; border: solid 1px Gray; color: Black; text-align: center;">
                Save Status
            </asp:Panel>
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label><br />
            <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click" Text="OK" Width="58px" />
            <br />
        </asp:Panel>
        <asp:HiddenField ID="hdnOrgID" runat="server" />
        <asp:HiddenField ID="hdnTippaniID" runat="server" />
        <asp:HiddenField ID="hdnProcessID" runat="server" />
        <br />
        <table width="640">
            <tr>
                <td align="center" style="width: 640px; height: 40px">
                    <asp:Label ID="lblEmployeeIdentity" runat="server" SkinID="UnicodeHeadlbl"></asp:Label></td>
            </tr>
        </table>
        <table width="640">
            <tr>
                <td style="width: 110px" valign="top">
                    <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="टिप्पणीको लेख:"></asp:Label></td>
                <td style="width: 515px">
                    <asp:TextBox ID="txtTippaniText" runat="server" Height="120px" SkinID="Unicodetxt" TextMode="MultiLine" Width="510px"></asp:TextBox></td>
            </tr>
        </table>
        <br />
        <uc1:VisitEntry ID="VisitTippani" runat="server" />
        <table width="500">
            <tr>
                <td style="width: 500px; height: 35px">
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" SkinID="Normal" Text="Submit" />
                    <asp:Button ID="btnCancel" runat="server" SkinID="Cancel" Text="Cancel" OnClick="btnCancel_Click" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

