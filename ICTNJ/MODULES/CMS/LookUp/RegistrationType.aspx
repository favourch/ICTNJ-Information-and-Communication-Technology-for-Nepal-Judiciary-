<%@ Page Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" AutoEventWireup="true" CodeFile="RegistrationType.aspx.cs" Inherits="MODULES_CMS_LookUp_RegistrationType" Title="CMS | Registration Type" %>

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
        <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label><br />
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
            Text="OK" Width="58px" />
        <br />
    </asp:Panel>
<table style="width: 700px">
        <tr>
            <td valign="top" style="height: 347px">
                <table style="width: 320px">
                    <tr>
                        <td>
                            <div style="overflow: scroll; width: 300px; height: 300px">
                                <asp:ListBox ID="lstRegistrationType" runat="server" AutoPostBack="True" Height="281px"
                                    SkinID="Unicodelst" OnSelectedIndexChanged="lstRegistrationType_SelectedIndexChanged" Width="283px"></asp:ListBox>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top" style="height: 347px">
                <table style="width: 340px">
                    <tr>
                        <td style="width: 65px" valign="top">
                            <asp:Label ID="lblRegTypeName" runat="server" SkinID="Unicodelbl" Text="दर्ता" Width="60px"></asp:Label></td>
                        <td valign="top">
                            <asp:TextBox ID="txtRegTypeName_RQD" runat="server" Height="60px" SkinID="Unicodetxt"
                                Width="240px" TextMode="MultiLine" ToolTip="दर्ता"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 65px" valign="top">
                            <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="सक्रिय" Width="46px"></asp:Label></td>
                        <td valign="top">
                            <asp:CheckBox ID="chkActive" runat="server" SkinID="smallChk" /></td>
                    </tr>
                    <tr>
                        <td style="width: 65px" valign="top">
                        </td>
                        <td valign="top">
                            <asp:Button ID="btnSubmit" runat="server" SkinID="Normal" Text="Submit" OnClick="btnSubmit_Click" OnClientClick="javascript:return validate(0);" ToolTip="दर्ता" />
                            <asp:Button ID="btnCancel" runat="server" SkinID="Cancel" Text="Cancel" OnClick="btnCancel_Click" /></td>
                    </tr>
                </table>
                <asp:HiddenField ID="hdnFldRegTypeID" runat="server" />
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <br />
</asp:Content>

