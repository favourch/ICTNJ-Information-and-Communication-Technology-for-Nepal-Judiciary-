<%@ Control AutoEventWireup="true" CodeFile="VisitEntry.ascx.cs" Inherits="MODULES_OAS_UserControls_VisitEntry" Language="C#" %>
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
            var fromDate = document.getElementById('<%= this.txtFromDate_Rdt.ClientID%>');
            var toDate = document.getElementById('<%= this.txtToDate_Rdt.ClientID%>');
            
            if(fromDate.value >= toDate.value)
            {
                alert('भ्रमणको अवधि देखि मिति अवधि सम्म मिति भन्दा सानो हुनु पर्छ।');
                fromDate.focus();
                return false;
            } 
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
    <asp:Label ID="Label23" runat="server" SkinID="UnicodeHeadlbl" Text="भ्रमणको बिबरण"></asp:Label><br />
    <asp:UpdatePanel ID="updVisit" runat="server">
        <ContentTemplate>
            <table width="1000">
                <tr>
                    <td style="width: 125px">
                        &nbsp;&nbsp;
                        <asp:Label ID="Label13" runat="server" SkinID="Unicodelbl" Text="स्थान"></asp:Label></td>
                    <td style="width: 200px">
                        <asp:TextBox ID="txtLocation_Rqd" runat="server" SkinID="Unicodetxt" Width="190px" ToolTip="भ्रमणको स्थान"></asp:TextBox></td>
                    <td style="width: 115px">
                        <asp:Label ID="Label14" runat="server" SkinID="Unicodelbl" Text="देश"></asp:Label></td>
                    <td style="width: 565px">
                        <asp:DropDownList ID="ddlCountry_Rqd" runat="server" Width="194px" ToolTip="भ्रमण देश">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 125px">
                        &nbsp;&nbsp;
                        <asp:Label ID="Label15" runat="server" SkinID="Unicodelbl" Text="अवधि देखि"></asp:Label></td>
                    <td style="width: 200px">
                        <asp:TextBox ID="txtFromDate_Rdt" runat="server" SkinID="Unicodetxt" Width="190px" ToolTip="भ्रमणको अवधि देखि"></asp:TextBox><ajaxToolkit:MaskedEditExtender
                            ID="mskFromDate" runat="server" AutoComplete="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtFromDate_Rdt">
                        </ajaxToolkit:MaskedEditExtender>
                    </td>
                    <td style="width: 115px">
                        <asp:Label ID="Label16" runat="server" SkinID="Unicodelbl" Text="अवधि सम्म"></asp:Label></td>
                    <td style="width: 565px">
                        <asp:TextBox ID="txtToDate_Rdt" runat="server" SkinID="Unicodetxt" Width="190px" ToolTip="भ्रमणको अवधि सम्म"></asp:TextBox><ajaxToolkit:MaskedEditExtender
                            ID="mskToDate" runat="server" AutoComplete="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtToDate_Rdt">
                        </ajaxToolkit:MaskedEditExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 125px">
                        &nbsp;&nbsp;
                        <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="साधन"></asp:Label></td>
                    <td colspan="3">
                        <asp:TextBox ID="txtVehicle_Rqd" runat="server" SkinID="Unicodetxt" Width="515px" ToolTip="भ्रमणको साधन"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 125px">
                        &nbsp;&nbsp;
                        <asp:Label ID="Label17" runat="server" SkinID="Unicodelbl" Text="शिर्षक"></asp:Label></td>
                    <td colspan="3">
                        <asp:TextBox ID="txtSubject_Rqd" runat="server" SkinID="Unicodetxt" TextMode="MultiLine" Width="515px" ToolTip="भ्रमणको शिर्षक"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 125px">
                        &nbsp;&nbsp;
                        <asp:Label ID="Label18" runat="server" SkinID="Unicodelbl" Text="कैफियत"></asp:Label></td>
                    <td colspan="3">
                        <asp:TextBox ID="txtRemarks" runat="server" SkinID="Unicodetxt" TextMode="MultiLine" Width="515px" ToolTip="भ्रमणको कैफियत"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 125px">
                    </td>
                    <td colspan="3">
                        <asp:Button ID="btnAddVisiter" runat="server" OnClick="btnAddVisiter_Click" OnClientClick="return ValidateForm();" SkinID="Add"
                            Text="Add" /></td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="grdVisiterDetail" runat="server" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333" OnRowDataBound="grdVisiterDetail_RowDataBound"
                            OnRowDeleting="grdVisiterDetail_RowDeleting" Width="975px" OnSelectedIndexChanged="grdVisiterDetail_SelectedIndexChanged">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="EmpName" HeaderText="कर्मचारी" />
                                <asp:BoundField DataField="VisitPurpose" HeaderText="उद्देश्य" />
                                <asp:BoundField DataField="VisitLocation" HeaderText="ठाउ" />
                                <asp:BoundField DataField="VisitCountryName" HeaderText="देश" />
                                <asp:BoundField DataField="VisitFromDate" HeaderText="अवधि देखी" />
                                <asp:BoundField DataField="VisitToDate" HeaderText="अवधि सम्म" />
                                <asp:BoundField DataField="VisitVehicle" HeaderText="साधन" />
                                <asp:BoundField DataField="VisitRemark" HeaderText="कैफियत" />
                                <asp:CommandField ShowSelectButton="True">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:CommandField>
                                <asp:CommandField ShowDeleteButton="True" >
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
                    <td colspan="3" valign="top">
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
                    <td style="width: 125px">
                <asp:Label ID="Label20" runat="server" Font-Underline="True" SkinID="Unicodelbl" Text="टिप्पणी को स्थिति"></asp:Label></td>
                    <td colspan="3">
                <asp:DropDownList ID="ddlTippaniStatus" runat="server" Enabled="False" SkinID="Unicodeddl" Width="194px">
                </asp:DropDownList></td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
