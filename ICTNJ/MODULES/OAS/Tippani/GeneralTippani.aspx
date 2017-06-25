<%@ Page AutoEventWireup="true" CodeFile="GeneralTippani.aspx.cs" Inherits="MODULES_OAS_Tippani_GeneralTippani" Language="C#"
    MasterPageFile="~/MODULES/OAS/MasterPage.master" Title="OAS | General Tippani" ValidateRequest="false" %>

<%@ Register Src="../UserControls/TippaniAttachment.ascx" TagName="TippaniAttachment" TagPrefix="uc5" %>
<%@ Register Src="../UserControls/VisitEntry.ascx" TagName="VisitEntry" TagPrefix="uc4" %>
<%@ Register Src="../UserControls/Tippani.ascx" TagName="Tippani" TagPrefix="uc3" %>
<%@ Register Src="../UserControls/ChannelPerson.ascx" TagName="ChannelPerson" TagPrefix="uc2" %>
<%@ Register Src="../UserControls/GroupMemberPersonSearch.ascx" TagName="GroupMemberPersonSearch" TagPrefix="uc1" %>
<%@ Register Assembly="Winthusiasm.HtmlEditor" Namespace="Winthusiasm.HtmlEditor" TagPrefix="SJ" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <script language="javascript" type="text/javascript">
        function ValidateTippani()
        {
            var tippaniText = document.getElementById('<%= this.Tippani.TippaniText.ClientID%>');
            var fileNo = document.getElementById('<%= this.Tippani.FileNo.ClientID%>');
            var priority = document.getElementById('<%= this.Tippani.TippaniPriority.ClientID%>');
            
            if(tippaniText.value.trim() == "")
            {
                alert('कृपया टिप्पणीको बिषय राख्नुहोस।');
                tippaniText.focus();
                return false;
            }
            
            if(fileNo.value.trim() == "")
            {
                alert('कृपया टिप्पणीको फाइल नं राख्नुहोस।');
                fileNo.focus();
                return false;
            }
            
            if(priority.selectedIndex <= 0)
            {
                alert('कृपया टिप्पणीको प्राथमिक्ता छन्नुहोस।');
                priority.focus();
                return false;
            }
            
//            var mode = document.getElementById('<%= this.hdnMode.ClientID%>');
//            if(mode.value == 'A')
//            {
//                var hdn = document.getElementById('<%= this.chnlPerson.ChkChannelPerson.ClientID%>');
//                if(hdn.value == '0')
//                {
//                    alert('कृपया टिप्पणीको सिफारिस कर्ता/प्रमाणित कर्ता छन्नुहोस।');
//                    return false;
//                }
//            }
        }
    </script>
    
    <div id="DIV1" style="width: 100%; height: auto">
        <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" /><ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server"
            BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior" DropShadow="True" PopupControlID="programmaticPopup" PopupDragHandleControlID="programmaticPopupDragHandle"
            RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForModalPopup">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none; width: 350px; padding: 10px">
            <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD; border: solid 1px Gray; color: Black; text-align: center;">
                Save Status
            </asp:Panel>
            <asp:UpdatePanel id="UpdatePanel3" runat="server">
                <contenttemplate>
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
</contenttemplate>
            </asp:UpdatePanel>
            <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click" Text="OK" Width="58px" /></asp:Panel>
        <table style="width: 100%">
            <tr>
                <td style="width: 100%">
        <asp:Label ID="Label1" runat="server" SkinID="UnicodeHeadlbl" Text="साधारण टिप्पणी"></asp:Label>
                    &nbsp; &nbsp;&nbsp;
                    <asp:Label ID="lblConfirmation" runat="server" SkinID="UnicodeHeadlbl"></asp:Label></td>
            </tr>
        </table>
        <asp:HiddenField ID="hdnMode"
            runat="server" Value="A" />
        <asp:HiddenField ID="hdnIDs" runat="server" />
        <asp:HiddenField ID="hdnMsgIDs" runat="server" />
        <asp:HiddenField ID="hdnDarIDs" runat="server" />
        <%--<asp:Label ID="Label22" runat="server" SkinID="UnicodeHeadlbl" Text="कर्मचारी खोज्नुहोस"></asp:Label><br />--%>
        <uc3:Tippani ID="Tippani" runat="server" TippaniSubjectID="4" TippaniSubjectType="General" />
        <hr align="left" width="100%" />
        <table width="1000">
            <tr>
                <td style="width: 125px" valign="top">
                    <asp:Label ID="Label21" runat="server" Font-Underline="True" SkinID="Unicodelbl" Text="तपाईको आफ्नो नोट"></asp:Label></td>
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
                <td style="width: 125px">
                    <asp:Label ID="Label20" runat="server" Font-Underline="True" SkinID="Unicodelbl" Text="टिप्पणी को स्थिति"></asp:Label></td>
                <td style="width: 875px">
                    <asp:DropDownList ID="ddlTippaniStatus" runat="server" Enabled="False" SkinID="Unicodeddl" Width="194px">
                    </asp:DropDownList></td>
            </tr>
        </table>
        <hr align="left" width="100%" />
        <uc5:TippaniAttachment ID="TippaniAttachment" runat="server" />
        <hr align="left" width="100%" />
        <uc2:ChannelPerson ID="chnlPerson" runat="server" ApplicationString="5, 3" TippaniSubjectID="4" />
        <br />
        <table width="100%">
            <tr>
                <td style="width: 100%">
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" OnClientClick="return ValidateTippani();" SkinID="Normal"
                        Text="Submit" />
                    <asp:Button ID="btnCancelSubmit" runat="server" OnClick="btnCancelSubmit_Click" SkinID="Cancel" Text="Cancel" />
                    &nbsp;<asp:Label ID="lblFinalStatus" runat="server" SkinID="UnicodeHeadlbl"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
