<%@ Page AutoEventWireup="true" CodeFile="F_11_M.aspx.cs" Inherits="MODULES_CMS_ReportForms_F_11_M"
    Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" Title="Untitled Page" %>

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
        <asp:Button ID="OkButton" runat="server"
            Text="OK" Width="58px" />
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
                        <td align="left" style="width: 70px" valign="top">
                            <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="साल"></asp:Label></td>
                        <td align="left" style="width: 100px" valign="top">
                            <asp:DropDownList ID="DDLYear" runat="server" SkinID="Unicodeddl" Width="100px">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 70px" valign="top">
                            <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="महिना"></asp:Label></td>
                        <td align="left" style="width: 100px" valign="top">
                            <asp:DropDownList ID="DDLMonth" runat="server" SkinID="Unicodeddl" Width="100px">
                                <asp:ListItem Value="0">--   महिना छान्नुस  --</asp:ListItem>
                                <asp:ListItem Value="01">बैसाख</asp:ListItem>
                                <asp:ListItem Value="02">जेस्ठ</asp:ListItem>
                                <asp:ListItem Value="03">असाढ</asp:ListItem>
                                <asp:ListItem Value="04">श्रावन</asp:ListItem>
                                <asp:ListItem Value="05">भदौ</asp:ListItem>
                                <asp:ListItem Value="06">आश्विन</asp:ListItem>
                                <asp:ListItem Value="07">कार्तिक</asp:ListItem>
                                <asp:ListItem Value="08">मंसिर</asp:ListItem>
                                <asp:ListItem Value="09">पौष</asp:ListItem>
                                <asp:ListItem Value="10">माघ</asp:ListItem>
                                <asp:ListItem Value="11">फाल्गुन</asp:ListItem>
                                <asp:ListItem Value="12">चैत्र</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                </table>
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

