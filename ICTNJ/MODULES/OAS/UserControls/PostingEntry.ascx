<%@ Control AutoEventWireup="true" CodeFile="PostingEntry.ascx.cs" Inherits="MODULES_OAS_UserControls_PostingEntry" Language="C#" %>
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
            return true;
        }
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
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click" Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    <asp:Label ID="Label1" runat="server" SkinID="UnicodeHeadlbl" Text="नियुक्तिको बिबरण"></asp:Label>
    &nbsp; &nbsp;<asp:Label ID="Label74" runat="server" SkinID="Unicodelbl" Text="कैफियत" Visible="False"></asp:Label>
    <asp:TextBox ID="txtPostingRemarks" runat="server" Height="1px" SkinID="Unicodetxt" TextMode="MultiLine" Visible="False" Width="449px"></asp:TextBox>
    <asp:UpdatePanel ID="updDetail" runat="server">
        <ContentTemplate>
            <table width="1000">
                <tr>
                    <td style="width: 125px">
                        &nbsp;&nbsp;
                        <asp:Label ID="Label64" runat="server" SkinID="Unicodelbl" Text="कार्यालय"></asp:Label></td>
                    <td colspan="3">
                        <asp:DropDownList ID="ddlOrg_Rqd" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlOrg_Rqd_SelectedIndexChanged" Width="300px" ToolTip="नियुक्तिको कार्यालय">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 125px">
                        &nbsp;&nbsp;
                        <asp:Label ID="Label65" runat="server" SkinID="Unicodelbl" Text="पद"></asp:Label></td>
                    <td colspan="3">
                        <asp:UpdatePanel ID="updPost" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlPost_Rqd" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddlPost_Rqd_SelectedIndexChanged"
                                    SkinID="Unicodeddl" Width="300px" ToolTip="नियुक्तिको पद">
                                </asp:DropDownList>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlOrg_Rqd" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td style="width: 125px">
                        &nbsp;&nbsp;
                        <asp:Label ID="Label66" runat="server" SkinID="Unicodelbl" Text="उपलब्ध पद"></asp:Label></td>
                    <td colspan="3">
                        <asp:UpdatePanel ID="updAvailablePost" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlAvailablePost_Rqd" runat="server" AppendDataBoundItems="True" SkinID="Unicodeddl" ToolTip="उपलब्ध पद" Width="452px">
                                </asp:DropDownList>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlPost_Rqd" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td style="width: 125px">
                        &nbsp;&nbsp;
                        <asp:Label ID="Label72" runat="server" SkinID="Unicodelbl" Text="छनौट तरिका"></asp:Label></td>
                    <td style="width: 200px">
                        <asp:DropDownList ID="ddlPostingType_rqd" runat="server" AppendDataBoundItems="True" SkinID="Unicodeddl" ToolTip="छनौट तरिका" Width="150px">
                        </asp:DropDownList></td>
                    <td style="width: 100px">
                        &nbsp;&nbsp;
                        <asp:Label ID="Label67" runat="server" SkinID="Unicodelbl" Text="नियुक्ति मिति"></asp:Label></td>
                    <td style="width: 575px">
                        <asp:TextBox ID="txtPostingDate_Rdt" runat="server" MaxLength="10" SkinID="Unicodetxt" ToolTip="नियुक्ति मिति" Width="146px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 125px">
                        &nbsp;&nbsp;
                        <asp:Label ID="Label69" runat="server" SkinID="Unicodelbl" Text="निर्णय मिति"></asp:Label></td>
                    <td style="width: 200px">
                        <asp:TextBox ID="txtDecisionDate_Dt" runat="server" MaxLength="10" SkinID="Unicodetxt" ToolTip="निर्णय मिति" Width="146px"></asp:TextBox></td>
                    <td style="width: 100px">
                        &nbsp;&nbsp;
                        <asp:Label ID="Label70" runat="server" SkinID="Unicodelbl" Text="रवाना मिति"></asp:Label></td>
                    <td style="width: 575px">
                        <asp:TextBox ID="txtLeaveDate_Dt" runat="server" MaxLength="10" SkinID="Unicodetxt" ToolTip="रवाना मिति" Width="146px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 125px">
                        &nbsp;&nbsp;
                        <asp:Label ID="Label71" runat="server" SkinID="Unicodelbl" Text="उपस्थित मिति"></asp:Label></td>
                    <td style="width: 200px">
                        <asp:TextBox ID="txtJoiningDate_Dt" runat="server" MaxLength="10" SkinID="Unicodetxt" ToolTip="उपस्थित मिति" Width="146px"></asp:TextBox></td>
                    <td style="width: 100px">
                        &nbsp;&nbsp;
                        <asp:Label ID="Label73" runat="server" SkinID="Unicodelbl" Text="तलब" Visible="False"></asp:Label></td>
                    <td style="width: 575px">
                        <asp:TextBox ID="txtSalary" runat="server" SkinID="Unicodetxt" Width="146px" Visible="False"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 125px" valign="top">
                    </td>
                    <td colspan="3" valign="top">
                        <asp:Button ID="btnAddPostingDetail" runat="server" OnClick="btnAddPostingDetail_Click" OnClientClick="return ValidateForm();"
                            SkinID="Add" Text="Add" /></td>
                </tr>
                <tr>
                    <td colspan="4" valign="top">
    <asp:UpdatePanel ID="updPosting" runat="server">
        <ContentTemplate>
            <asp:GridView ID="grdPostList" runat="server" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333" OnRowDataBound="grdPostList_RowDataBound"
                Width="100%" OnRowDeleting="grdPostList_RowDeleting" OnSelectedIndexChanged="grdPosting_SelectedIndexChanged">
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <Columns>
                    <asp:BoundField DataField="EmpID" HeaderText="EmpID" />
                    <asp:BoundField DataField="EmpName" HeaderText="कर्मचारीको नाम" />
                    <asp:BoundField DataField="PostOrgID" HeaderText="OrgID" />
                    <asp:BoundField DataField="DesID" HeaderText="DesID" />
                    <asp:BoundField DataField="PostID" HeaderText="PostID" />
                    <asp:BoundField DataField="PostingTypeID" HeaderText="PostingTypeID" />
                    <asp:BoundField DataField="PostOrgName" HeaderText="कार्यालय" />
                    <asp:BoundField DataField="PostDesName" HeaderText="पद" />
                    <asp:BoundField DataField="PostName" HeaderText="पोस्ट" />
                    <asp:BoundField DataField="PostingTypeName" HeaderText="छनौट तरिका" />
                    <asp:BoundField DataField="FromDate" HeaderText="नियुत्ति मिति" />
                    <asp:BoundField DataField="DecisionDate" HeaderText="निर्णय मिति" />
                    <asp:BoundField DataField="LeaveDate" HeaderText="रवाना मिति" />
                    <asp:BoundField DataField="JoiningDate" HeaderText="उपस्थित मिति" />
                    <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" />
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <EditRowStyle BackColor="#999999" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAddPostingDetail" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td style="width: 125px" valign="top">
                <asp:Label ID="Label21" runat="server" Font-Underline="True" SkinID="Unicodelbl" Text="तपाईको आफ्नो नोट"></asp:Label></td>
                    <td colspan="3" valign="top">
                <FTB:FreeTextBox ID="txtNote" runat="server" BackColor="127, 157, 185" BreakMode="LineBreak" GutterBackColor="127, 157, 185"
                    Height="250px" StartMode="DesignMode" ToolbarBackColor="127, 157, 185" ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline,Strikethrough;Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;InsertRule|Cut,Copy,Paste;Undo,Redo,Print"
                    Width="750px">
                </FTB:FreeTextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 125px" valign="top">
                <asp:Label ID="Label20" runat="server" Font-Underline="True" SkinID="Unicodelbl" Text="टिप्पणी को स्थिति"></asp:Label></td>
                    <td colspan="3" valign="top">
                <asp:DropDownList ID="ddlTippaniStatus" runat="server" SkinID="Unicodeddl" Width="194px" Enabled="False">
                </asp:DropDownList></td>
                </tr>
            </table>
            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AutoComplete="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtPostingDate_Rdt">
            </ajaxToolkit:MaskedEditExtender>
            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" AutoComplete="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtDecisionDate_Dt">
            </ajaxToolkit:MaskedEditExtender>
            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" AutoComplete="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtLeaveDate_Dt">
            </ajaxToolkit:MaskedEditExtender>
            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender4" runat="server" AutoComplete="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtJoiningDate_Dt">
            </ajaxToolkit:MaskedEditExtender>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
