<%@ Page AutoEventWireup="true" CodeFile="GeneralTippaniRequestViewer.aspx.cs" Inherits="MODULES_OAS_Tippani_GeneralTippaniRequestViewer"
    Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" Title="OAS | General Tippani Viewer" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../UserControls/TippaniRequestViewer.ascx" TagName="TippaniRequestViewer" TagPrefix="TRV" %>
<%@ Register Src="../UserControls/TippaniAttachment.ascx" TagName="TippaniAttachment" TagPrefix="uc3" %>
<%@ Register Src="../UserControls/TippaniHistory.ascx" TagName="TippaniHistory" TagPrefix="uc2" %>
<%@ Register Src="../UserControls/ChannelPerson.ascx" TagName="ChannelPerson" TagPrefix="uc1" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager ID="ScriptManager" runat="server">
    </asp:ScriptManager>

    <script language="javascript" type="text/javascript">
        function ConfirmSendBack()
        {
            var result = confirm('तपाई यो टिप्पनीलाइ फिर्ता पठाउन चहानुहुन्छ्।');
            if(result == false)
                return false;
            else
            {
                return ValidateForm();
            }
        }
        
        function ValidateForm()
        {
            var tippanStatus = document.getElementById('<%= this.hdnTippaniStatus.ClientID%>');
            if(tippanStatus.value == 3)
            {
                alert('Warning: फाइनल approve भएको टिप्पणीमा काम गर्न सक्नुहुन्न।');
                return false;
            }
        
            var status = document.getElementById('<%= this.ddlDStatus_Rqd.ClientID%>');
            if(status.selectedIndex == 0)
            {
                alert('कृपया टिप्पणीको स्तिथि छान्नुहोस।');
                status.focus();
                return false;
            }
            
            if(status.value != 3)
            {
                var hdn = document.getElementById('<%= this.chnlPerson.ChkChannelPerson.ClientID%>');
                if(hdn.value == '0')
                {
                    alert('कृपया प्रमाणित नगारेको टिप्पणीको लागी सिफारिस कर्ता/प्रमाणित कर्ता छन्नुहोस।');
                    return false;
                }
            }
            
            return true;
        }
    </script>

    <div style="width: 100%; height: auto">
        <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
        <ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground" DropShadow="True" PopupControlID="programmaticPopup"
            PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForModalPopup">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none; width: 350px; padding: 10px">
            <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD; border: solid 1px Gray; color: Black; text-align: center;">
                Save Status
            </asp:Panel>
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label><br />
            <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click" Text="OK" Width="58px" /></asp:Panel>
        <asp:Label ID="Label1" runat="server" SkinID="UnicodeHeadlbl" Text="साधारण टिप्पणी चलानी"></asp:Label><br />
        <asp:HiddenField ID="hdnTippaniStatus" runat="server" />
        <br />
        <TRV:TippaniRequestViewer ID="TippaniRequestViewer" runat="server" TippaniSubjectType="General" />
        <hr />
        <table width="1000">
            <tbody>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="Label2" runat="server" SkinID="UnicodeHeadlbl" Text="साधारण टिप्पणीको बिबरण"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 514px">
                    </td>
                    <td style="width: 780px">
                        <uc2:TippaniHistory ID="TippaniHistory" runat="server" />
                    </td>
                </tr>
            </tbody>
        </table>
        <table style="width: 1000px">
            <tr>
                <td style="width: 125px" valign="top">
                        <asp:Label ID="Label8" runat="server" SkinID="Unicodelbl" Text="तपांइको निर्णय:"></asp:Label></td>
                <td style="width: 875px" valign="top">
                        <asp:DropDownList ID="ddlDStatus_Rqd" runat="server" Width="190px">
                        </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 125px" valign="top">
                        <asp:Label ID="Label14" runat="server" SkinID="Unicodelbl" Text="तपांइको नोट:"></asp:Label></td>
                <td style="width: 875px" valign="top">
                    <FTB:FreeTextBox ID="txtNote" runat="server" AllowHtmlMode="False" AssemblyResourceHandlerPath="" AutoConfigure="" AutoGenerateToolbarsFromString="True"
                        AutoHideToolbar="True" AutoParseStyles="True" BackColor="127, 157, 185" BaseUrl="" BreakMode="LineBreak" ButtonDownImage="False"
                        ButtonFileExtention="gif" ButtonFolder="Images" ButtonHeight="20" ButtonImagesLocation="InternalResource" ButtonOverImage="False"
                        ButtonPath="" ButtonSet="NotSet" ButtonWidth="21" ClientSideTextChanged="" ConvertHtmlSymbolsToHtmlCodes="False" DesignModeBodyTagCssClass=""
                        DesignModeCss="" DisableIEBackButton="False" DownLevelCols="50" DownLevelMessage="" DownLevelMode="TextArea" DownLevelRows="10"
                        EditorBorderColorDark="Gray" EditorBorderColorLight="Gray" EnableHtmlMode="True" EnableSsl="False" EnableToolbars="True"
                        Focus="False" FormatHtmlTagsToXhtml="True" GutterBackColor="127, 157, 185" GutterBorderColorDark="Gray" GutterBorderColorLight="White"
                        Height="250px" HelperFilesParameters="" HelperFilesPath="" HtmlModeCss="" HtmlModeDefaultsToMonoSpaceFont="True" ImageGalleryPath="~/images/"
                        ImageGalleryUrl="ftb.imagegallery.aspx?rif={0}&cif={0}" InstallationErrorMessage="InlineMessage" JavaScriptLocation="InternalResource"
                        Language="en-US" PasteMode="Default" ReadOnly="False" RemoveScriptNameFromBookmarks="True" RemoveServerNameFromUrls="True"
                        RenderMode="NotSet" ScriptMode="External" ShowTagPath="False" SslUrl="/." StartMode="DesignMode" StripAllScripting="False"
                        SupportFolder="/aspnet_client/FreeTextBox/" TabIndex="-1" TabMode="InsertSpaces" Text="" TextDirection="LeftToRight"
                        ToolbarBackColor="127, 157, 185" ToolbarBackgroundImage="True" ToolbarImagesLocation="InternalResource" ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline,Strikethrough;Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;InsertRule|Cut,Copy,Paste;Undo,Redo,Print"
                        ToolbarStyleConfiguration="NotSet" UpdateToolbar="True" UseToolbarBackGroundImage="True" Width="750px">
                    </FTB:FreeTextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 125px" valign="top">
                </td>
                <td style="width: 875px" valign="top">
                    <asp:Button ID="btnSaveAsDraft" runat="server" Text="Save as Draft (Text)" OnClick="btnSaveAsDraft_Click" SkinID="Dynamic" Width="120px" Enabled="False" /></td>
            </tr>
        </table>
        <br />
        <uc3:TippaniAttachment ID="TippaniAttachment" runat="server" />
        <table width="500">
            <tr>
                <td style="width: 115px">
                </td>
                <td style="width: 350px">
                    <asp:Button ID="btnSendBack" runat="server" Enabled="False" OnClick="btnSendBack_Click" OnClientClick="return ConfirmSendBack();" SkinID="Dynamic" Text="Send Back"
                        Width="100px" />
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="hdnForm" runat="server" Value="0" />
        <hr />
        <uc1:ChannelPerson ID="chnlPerson" runat="server" ApplicationString="5, 3" TippaniSubjectID="4" />
        <br />
        <table width="500">
            <tr>
                <td style="width: 500px">
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" SkinID="Normal" Enabled="False" OnClientClick="return ValidateForm();" />
                    &nbsp;<asp:Button ID="btnCancelSubmit" runat="server" OnClick="btnCancelSubmit_Click" SkinID="Cancel" Text="Cancel" /></td>
            </tr>
        </table>
    </div>
</asp:Content>
