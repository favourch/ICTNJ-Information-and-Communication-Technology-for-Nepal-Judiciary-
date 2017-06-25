<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true" CodeFile="CommitteeTippaniViewer.aspx.cs" 
Inherits="MODULES_OAS_Tippani_CommitteeTippaniViewer" Title="OAS | Committee Tippani Viewer" MaintainScrollPositionOnPostback="true" ValidateRequest="false" %>

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
        <ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground" DropShadow="True"
            PopupControlID="programmaticPopup" PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
            TargetControlID="hiddenTargetControlForModalPopup">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none; width: 350px; padding: 10px">
            <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD; border: solid 1px Gray;
                color: Black; text-align: center;">
                Save Status
            </asp:Panel>
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label><br />
            <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click" Text="OK" Width="58px" /></asp:Panel>
        <asp:Label ID="Label1" runat="server" SkinID="UnicodeHeadlbl" Text="भ्रमणको टिप्पणी चलानी"></asp:Label><br />
        <asp:HiddenField ID="hdnTippaniStatus" runat="server" />
        <br />
        <TRV:TippaniRequestViewer ID="TippaniRequestViewer" runat="server" TippaniSubjectType="Committee" />
        <br />
        <cc1:TabContainer ID="EvaluationTab" runat="server" ActiveTabIndex="0" CssClass="ajax_tab_theme" ScrollBars="Auto" Width="100%">
            <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                <headertemplate>
टिप्पणीको बिबरण 
</headertemplate>
                <contenttemplate>
<TABLE style="WIDTH: 700px"><TBODY><TR><TD style="WIDTH: 700px"><asp:Label id="Label2" runat="server" Text="बनाउन लागेको कमिटिको नाम :: " SkinID="Unicodelbl" __designer:wfdid="w1"></asp:Label> &nbsp; <asp:Label id="lblCommitteeName" runat="server" Text="कमिटिको विवरण :: " SkinID="Unicodelbl" Font-Bold="True" __designer:wfdid="w1"></asp:Label> </TD></TR><TR><TD style="WIDTH: 700px" vAlign=top><asp:Label id="Label3" runat="server" Text="कमिटिको विवरण :: " SkinID="Unicodelbl" __designer:wfdid="w1"></asp:Label> &nbsp; <asp:Label id="lblDescription" runat="server" SkinID="Unicodelbl" __designer:wfdid="w1"></asp:Label> </TD></TR><TR><TD style="WIDTH: 700px; HEIGHT: 6px"></TD></TR></TBODY></TABLE><asp:Label id="Label451" runat="server" Text="कमिटिको लागी छानिएको कर्मचारीहरु" SkinID="UnicodeHeadlbl"></asp:Label> <BR /><asp:GridView id="grdDetail" runat="server" Width="600px" OnRowDataBound="grdVisiterDetail_RowDataBound" ForeColor="#333333" CellPadding="0" AutoGenerateColumns="False">
<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
<Columns>
<asp:BoundField DataField="OrgName" HeaderText="कार्यालय"></asp:BoundField>
<asp:BoundField DataField="DesName" HeaderText="पद"></asp:BoundField>
<asp:BoundField DataField="EmpName" HeaderText="कर्मचारी"></asp:BoundField>
</Columns>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
</asp:GridView> <BR /><TABLE width=1000><TBODY><TR><TD style="WIDTH: 125px"><asp:Label id="Label8" runat="server" Text="तपांइको निर्णय:" SkinID="Unicodelbl"></asp:Label> </TD><TD style="WIDTH: 875px"><asp:DropDownList id="ddlDStatus_Rqd" runat="server" Width="190px"></asp:DropDownList> </TD></TR><TR><TD style="WIDTH: 125px" vAlign=top><asp:Label id="Label14" runat="server" Text="तपांइको नोट:" SkinID="Unicodelbl"></asp:Label> </TD><TD style="WIDTH: 875px" vAlign=top><FTB:FreeTextBox id="txtNote" language="en-US" tabIndex=-1 runat="server" Width="750px" Height="250px" Text="" AutoHideToolbar="True" ButtonPath="" HelperFilesPath="" HelperFilesParameters="" AutoConfigure="" AllowHtmlMode="False" ButtonDownImage="False" ButtonOverImage="False" HtmlModeCss="" DownLevelMessage="" DownLevelMode="TextArea" DownLevelRows="10" DownLevelCols="50" GutterBorderColorDark="Gray" GutterBorderColorLight="White" EditorBorderColorDark="Gray" EditorBorderColorLight="Gray" GutterBackColor="127, 157, 185" HtmlModeDefaultsToMonoSpaceFont="True" ButtonFileExtention="gif" StartMode="DesignMode" ReadOnly="False" ScriptMode="External" SupportFolder="/aspnet_client/FreeTextBox/" RenderMode="NotSet" EnableHtmlMode="True" TabMode="InsertSpaces" BreakMode="LineBreak" PasteMode="Default" ConvertHtmlSymbolsToHtmlCodes="False" RemoveScriptNameFromBookmarks="True" RemoveServerNameFromUrls="True" EnableSsl="False" DisableIEBackButton="False" FormatHtmlTagsToXhtml="True" StripAllScripting="False" TextDirection="LeftToRight" SslUrl="/." AutoParseStyles="True" ImageGalleryUrl="ftb.imagegallery.aspx?rif={0}&cif={0}" ImageGalleryPath="~/images/" Focus="False" ShowTagPath="False" AssemblyResourceHandlerPath="" ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline,Strikethrough;Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;InsertRule|Cut,Copy,Paste;Undo,Redo,Print" AutoGenerateToolbarsFromString="True" UseToolbarBackGroundImage="True" EnableToolbars="True" ToolbarBackColor="127, 157, 185" ToolbarBackgroundImage="True" UpdateToolbar="True" ToolbarStyleConfiguration="NotSet" ButtonHeight="20" ButtonWidth="21" ButtonFolder="Images" BackColor="127, 157, 185" DesignModeBodyTagCssClass="" DesignModeCss="" BaseUrl="" InstallationErrorMessage="InlineMessage" ButtonSet="NotSet" ToolbarImagesLocation="InternalResource" ButtonImagesLocation="InternalResource" JavaScriptLocation="InternalResource" ClientSideTextChanged=""></FTB:FreeTextBox> </TD></TR><TR><TD style="WIDTH: 125px" vAlign=top></TD><TD style="WIDTH: 875px" vAlign=top><asp:Button id="btnSaveAsDraft" onclick="btnSaveAsDraft_Click" runat="server" Width="120px" Text="Save as Draft (Text)" SkinID="Dynamic" Enabled="False"></asp:Button> </TD></TR></TBODY></TABLE><uc3:TippaniAttachment id="TippaniAttachment" runat="server"></uc3:TippaniAttachment> <TABLE width=300><TBODY><TR><TD style="WIDTH: 125px"></TD><TD style="WIDTH: 175px"><asp:Button id="btnSendBack" onclick="btnSendBack_Click" runat="server" Width="100px" Text="Send Back" SkinID="Dynamic" OnClientClick="return ConfirmSendBack();" Enabled="False"></asp:Button> </TD></TR></TBODY></TABLE><asp:HiddenField id="hdnForm" runat="server" Value="0"></asp:HiddenField> 
</contenttemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                <headertemplate>
टिप्पनीको इतिहास
</headertemplate>
                <contenttemplate>
<uc2:TippaniHistory id="TippaniHistory" runat="server"></uc2:TippaniHistory> 
</contenttemplate>
            </ajaxToolkit:TabPanel>
        </cc1:TabContainer><br />
        <uc1:ChannelPerson ID="chnlPerson" runat="server" ApplicationString="5, 3" TippaniSubjectID="9" />
        <br />
        <table width="500">
            <tr>
                <td style="width: 500px">
                    <asp:Button ID="btnSubmit" runat="server" Enabled="False" OnClick="btnSubmit_Click" SkinID="Normal" Text="Submit" OnClientClick="return ValidateForm();" />
                    <asp:Button ID="btnCancelSubmit" runat="server" OnClick="btnCancelSubmit_Click" SkinID="Cancel" Text="Cancel" /></td>
            </tr>
        </table>
    </div>
</asp:Content>
