<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AwardEntry.ascx.cs" Inherits="MODULES_OAS_UserControls_AwardEntry" %>
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
    <asp:Label ID="Label23" runat="server" SkinID="UnicodeHeadlbl" Text="बिभुषणको बिबरण"></asp:Label><br />
    <asp:UpdatePanel ID="updPunishment" runat="server">
        <ContentTemplate>
            <table width="1000">
                <tr>
                    <td style="width: 125px">
                        &nbsp;&nbsp;
                        <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="बिभुषणको मिति"></asp:Label></td>
                    <td style="width: 875px">
                        <asp:TextBox ID="txtAwardDate_Rdt" runat="server" SkinID="Unicodetxt" Width="100px" ToolTip="बिभुषणको मिति"></asp:TextBox>
                        <ajaxToolkit:MaskedEditExtender ID="mskAwdDate" runat="server" AutoComplete="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtAwardDate_Rdt">
                        </ajaxToolkit:MaskedEditExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 125px">
                        &nbsp;&nbsp;
                        <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="बिभुषण"></asp:Label></td>
                    <td style="width: 875px">
                        <asp:TextBox ID="txtAward_Rqd" runat="server" SkinID="Unicodetxt" Width="300px" ToolTip="बिभुषणको बिबरण"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 125px" valign="top">
                        &nbsp;&nbsp;
                        <asp:Label ID="Label3" runat="server" SkinID="Unicodelbl" Text="कैफियत"></asp:Label></td>
                    <td style="width: 875px" valign="top">
                        <asp:TextBox ID="txtRemark" runat="server" SkinID="Unicodetxt" TextMode="MultiLine" Width="300px" Height="60px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 125px">
                    </td>
                    <td style="width: 875px">
                        <asp:Button ID="btnAdd" runat="server" OnClick="btnAddAward_Click" OnClientClick="return ValidateForm();" SkinID="Add" Text="Add" /></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="grdAward" runat="server" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333" OnRowDataBound="grdAward_RowDataBound"
                            OnRowDeleting="grdAward_RowDeleting" SkinID="Unicodegrd" Width="825px" OnSelectedIndexChanged="grdAward_SelectedIndexChanged">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="EmpName" HeaderText="कर्मचारीको नाम" />
                                <asp:BoundField DataField="AwardDate" HeaderText="मिति" />
                                <asp:BoundField DataField="Award" HeaderText="बिभुषणको बिबरण" />
                                <asp:BoundField DataField="AwardRemark" HeaderText="कैफियत" />
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
                    <td style="width: 875px" valign="top">
                                <FTB:FreeTextBox ID="txtNote" runat="server" BackColor="127, 157, 185" BreakMode="LineBreak" GutterBackColor="127, 157, 185"
                                    Height="250px" StartMode="DesignMode" ToolbarBackColor="127, 157, 185" ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline,Strikethrough;Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;InsertRule|Cut,Copy,Paste;Undo,Redo,Print"
                                    Width="750px">
                                </FTB:FreeTextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 125px">
                        <asp:Label ID="Label20" runat="server" Font-Underline="True" SkinID="Unicodelbl" Text="टिप्पणी को स्थिति"></asp:Label></td>
                    <td style="width: 875px">
                        <asp:DropDownList ID="ddlTippaniStatus" runat="server" SkinID="Unicodeddl" Width="194px" Enabled="False">
                        </asp:DropDownList></td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
