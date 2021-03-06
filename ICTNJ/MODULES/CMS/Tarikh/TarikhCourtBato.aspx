<%@ Page Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" AutoEventWireup="true" CodeFile="TarikhCourtBato.aspx.cs" Inherits="MODULES_CMS_Tarikh_TarikhCourtBato" Title="CMS | Court Bato" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" src="../../COMMON/JS/Validation.js" type="text/javascript"></script>
        <script language="javascript" src="../../COMMON/JS/Validation.js" type="text/javascript"></script>
    <script language="javascript" src="../../COMMON/JS/DateValidator.js" type="text/javascript"></script>
    <script language="javascript" src="../../COMMON/JS/EnglishDateValidator.js" type="text/javascript"></script>

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
            Save Status
        </asp:Panel>
        <asp:UpdatePanel id="UpdatePanel2" runat="server">
            <contenttemplate>
        <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
</contenttemplate>
        </asp:UpdatePanel>
        <br />
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
            Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    <br />
    <table style="width: 850px">
        <tr>
            <td align="left" rowspan="3" style="width: 270px" valign="top">
                <asp:Panel ID="Panel1" runat="server" Height="325px" ScrollBars="Auto" Width="250px">
                    <asp:ListBox ID="lstCourt" runat="server" Height="300px" SkinID="Unicodelst" Width="250px" AutoPostBack="True" OnSelectedIndexChanged="lstCourt_SelectedIndexChanged">
                    </asp:ListBox></asp:Panel>
            </td>
            <td align="left" colspan="2" rowspan="3" valign="top">
                <table style="width: 400px">
                    <tr>
                        <td align="left" style="width: 28px;" valign="top">
                            <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="मिति"></asp:Label></td>
                        <td align="left" valign="top">
                            <asp:TextBox ID="txtFromDate_RQD" runat="server" SkinID="Unicodetxt" Width="75px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 28px" valign="top">
                            <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="दिन"></asp:Label></td>
                        <td align="left" valign="top">
                            <asp:TextBox ID="txtTotalDays_RQD" runat="server" SkinID="Unicodetxt" Width="50px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 28px" valign="top">
                            <asp:Label ID="Label3" runat="server" SkinID="Unicodelbl" Text="बाटोको म्याद" Width="95px"></asp:Label></td>
                        <td align="left" valign="top">
                            <asp:TextBox ID="txtBatoKoMyaad_RQD" runat="server" SkinID="Unicodetxt" Width="50px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right" colspan="2" valign="top">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" SkinID="Normal" />
                            <asp:Button ID="btnCancel" runat="server" SkinID="Cancel" Text="Cancel" OnClick="btnCancel_Click" /></td>
                    </tr>
                </table>
                <ajaxToolkit:MaskedEditExtender ID="mskFromDate" runat="server" AutoComplete="False"
                    ClearMaskOnLostFocus="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtFromDate_RQD">
                </ajaxToolkit:MaskedEditExtender>
            </td>
        </tr>
        <tr>
        </tr>
        <tr>
        </tr>
    </table>
</asp:Content>

