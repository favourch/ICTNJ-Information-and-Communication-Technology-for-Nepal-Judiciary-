<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CommitteeEntry.ascx.cs" Inherits="MODULES_OAS_UserControls_CommitteeEntry" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>

<script language="javascript" src="../../COMMON/JS/Validation.js" type="text/javascript"></script>

<script language="javascript" src="../../COMMON/JS/DateValidator.js" type="text/javascript"></script>

<script language="javascript" src="../../COMMON/JS/EnglishDateValidator.js" type="text/javascript"></script>

<script language="javascript" type="text/javascript">
    function ValidateForm()
    {
        var result = validate(1);
        if(result == false)
            return false;
        else
        {

        }
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
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click" Text="OK" Width="58px" /></asp:Panel>
    <asp:Label ID="Label23" runat="server" SkinID="UnicodeHeadlbl" Text="कमिटिको विवरण"></asp:Label>
    <asp:HiddenField ID="hdnIDs" runat="server" />
    <asp:UpdatePanel ID="updVisit" runat="server">
        <ContentTemplate>
            <table style="width: 1000px">
                <tr>
                    <td style="width: 125px">
                        &nbsp;&nbsp;
                        <asp:Label ID="Label13" runat="server" SkinID="Unicodelbl" Text="कार्यालय"></asp:Label></td>
                    <td style="width: 875px">
                        <asp:DropDownList ID="ddlOrg_Rqd" runat="server" Width="200px">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 125px">
                        &nbsp;&nbsp;
                        <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="कमिटिको नाम"></asp:Label></td>
                    <td style="width: 875px">
                        <asp:TextBox ID="txtCommittee_Rqd" runat="server" Width="400px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 125px" valign="top">
                        &nbsp;&nbsp;
                        <asp:Label ID="Label3" runat="server" SkinID="Unicodelbl" Text="विवरण"></asp:Label></td>
                    <td style="width: 875px">
                        <asp:TextBox ID="txtDesc" runat="server" Height="80px" TextMode="MultiLine" Width="400px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 125px" valign="top">
                    </td>
                    <td style="width: 875px">
                        <asp:Button ID="btnAddVisiter" runat="server" OnClick="btnAddMember_Click" OnClientClick="return ValidateForm();" SkinID="Add"
                            Text="Add" /></td>
                </tr>
                <tr>
                    <td style="width: 125px" valign="top">
                    </td>
                    <td style="width: 875px">
                        <asp:GridView ID="grdCommittee" runat="server" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333" OnRowDataBound="grdCommittee_RowDataBound"
                            OnRowDeleting="grdCommittee_RowDeleting" OnSelectedIndexChanged="grdCommittee_SelectedIndexChanged" Width="500px">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="EmpName" HeaderText="कर्मचारी" />
                                <asp:CommandField ShowSelectButton="True">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:CommandField>
                                <asp:CommandField ShowDeleteButton="True">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:CommandField>
                            </Columns>
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <EditRowStyle BackColor="#999999" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="width: 125px" valign="top">
                        <asp:Label ID="Label21" runat="server" Font-Underline="True" SkinID="Unicodelbl" Text="तपाईको आफ्नो नोट"></asp:Label></td>
                    <td style="width: 875px">
                        <FTB:FreeTextBox ID="txtNote" runat="server" AllowHtmlMode="False" AssemblyResourceHandlerPath="" AutoConfigure="" AutoGenerateToolbarsFromString="True"
                            AutoHideToolbar="True" AutoParseStyles="True" BackColor="127, 157, 185" BaseUrl="" BreakMode="LineBreak" ButtonDownImage="False"
                            ButtonFileExtention="gif" ButtonFolder="Images" ButtonHeight="20" ButtonImagesLocation="InternalResource" ButtonOverImage="False"
                            ButtonPath="" ButtonSet="NotSet" ButtonWidth="21" ClientSideTextChanged="" ConvertHtmlSymbolsToHtmlCodes="False" DesignModeBodyTagCssClass=""
                            DesignModeCss="" DisableIEBackButton="False" DownLevelCols="50" DownLevelMessage="" DownLevelMode="TextArea" DownLevelRows="10"
                            EditorBorderColorDark="Gray" EditorBorderColorLight="Gray" EnableHtmlMode="True" EnableSsl="False" EnableToolbars="True"
                            Focus="True" FormatHtmlTagsToXhtml="True" GutterBackColor="127, 157, 185" GutterBorderColorDark="Gray" GutterBorderColorLight="White"
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
                        <asp:Label ID="Label20" runat="server" Font-Underline="True" SkinID="Unicodelbl" Text="टिप्पणी को स्थिति"></asp:Label></td>
                    <td style="width: 875px">
                        <asp:DropDownList ID="ddlTippaniStatus" runat="server" Enabled="False" SkinID="Unicodeddl" Width="194px">
                        </asp:DropDownList></td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
