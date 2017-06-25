<%@ Page AutoEventWireup="true" CodeFile="F_11_FY.aspx.cs" Inherits="MODULES_CMS_ReportForms_F_11_FY"
    Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" Title="CMS | FY Wise Case Summary" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <script language="javascript" src="../../COMMON/JS/Validation.js" type="text/javascript"></script>

    <script language="javascript" src="../../COMMON/JS/DateValidator.js" type="text/javascript"></script>

    <script language="javascript" src="../../COMMON/JS/EnglishDateValidator.js" type="text/javascript"></script>

    <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground"
        BehaviorID="programmaticModalPopupBehavior" DropShadow="True" PopupControlID="programmaticPopup"
        PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
        TargetControlID="hiddenTargetControlForModalPopup">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none;
        width: 350px; padding: 10px">
        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD;
            border: solid 1px Gray; color: Black; text-align: center;">
            <asp:Label ID="lblStatus" runat="server" Text="Label"></asp:Label>&nbsp;</asp:Panel>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <contenttemplate>
        <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
            </contenttemplate>
        </asp:UpdatePanel>
        <asp:Button ID="OkButton" runat="server" Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    <br />
    <table style="width: 826px">
        <tr>
            <td align="left" rowspan="3" style="width: 253px" valign="top">
                <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Auto" Width="250px">
                    <asp:CheckBoxList ID="cbOrgWithChilds" runat="server">
                    </asp:CheckBoxList></asp:Panel>
            </td>
            <td align="left" rowspan="2" valign="top">
                <table>
                    <tr>
                        <td align="left" style="width: 70px; height: 21px;" valign="top">
                            <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="आ. व. "></asp:Label></td>
                        <td align="left" style="width: 100px; height: 21px;" valign="top">
                            <asp:TextBox ID="txtFY_RQD" runat="server" Width="60px"></asp:TextBox></td>
                    </tr>
                </table>
                &nbsp;<ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AutoComplete="False"
                    ClearMaskOnLostFocus="False" Mask="99/99" MaskType="Number" TargetControlID="txtFY_RQD">
                </ajaxToolkit:MaskedEditExtender>
            </td>
        </tr>
        <tr>
        </tr>
        <tr>
            <td align="left" valign="top">
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 253px" valign="top">
            </td>
            <td align="left" valign="top">
                <asp:Button ID="btnGenerate" runat="server" OnClick="btnGenerate_Click" SkinID="Normal"
                    Text="Generate" />
                <asp:Button ID="btnCancel" runat="server" SkinID="Cancel" Text="Cancel" /></td>
        </tr>
    </table>
    <br />
    <br />
</asp:Content>

