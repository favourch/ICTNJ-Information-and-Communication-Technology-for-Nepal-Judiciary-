<%@ Control AutoEventWireup="true" CodeFile="DeputationEntry.ascx.cs" Inherits="MODULES_OAS_UserControls_DeputationEntry"
    Language="C#" %>
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
        <br />
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click" Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    <asp:Label ID="Label23" runat="server" SkinID="UnicodeHeadlbl" Text="काजको बिबरण"></asp:Label><asp:UpdatePanel ID="updDeputation" runat="server">
        <ContentTemplate>
            <ajaxToolkit:MaskedEditExtender ID="mskSendDate" runat="server" AutoComplete="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtSendDate_Rdt">
            </ajaxToolkit:MaskedEditExtender>
            <ajaxToolkit:MaskedEditExtender ID="mskDecisionDate" runat="server" AutoComplete="False" Mask="9999/99/99" MaskType="Date"
                TargetControlID="txtDecisionDate_Rdt">
            </ajaxToolkit:MaskedEditExtender>
            <ajaxToolkit:MaskedEditExtender ID="mskLeaveDate" runat="server" AutoComplete="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtLeaveDate_Rdt">
            </ajaxToolkit:MaskedEditExtender>
    <table width="1000">
        <tr>
            <td style="width: 125px">
                &nbsp;&nbsp;
                <asp:Label ID="Label4" runat="server" SkinID="Unicodelbl" Text="पठाउने मिति"></asp:Label></td>
            <td style="width: 200px">
                <asp:TextBox ID="txtSendDate_Rdt" runat="server" SkinID="Unicodetxt" Width="100px" ToolTip="काजमा पठाउने मिति"></asp:TextBox></td>
            <td style="width: 120px">
                &nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="निर्णय मिति"></asp:Label></td>
            <td style="width: 555px">
                <asp:TextBox ID="txtDecisionDate_Rdt" runat="server" SkinID="Unicodetxt" Width="100px" ToolTip="काजको निर्णय मिति"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 125px">
                &nbsp;&nbsp;
                <asp:Label ID="Label3" runat="server" SkinID="Unicodelbl" Text="कार्यालय"></asp:Label></td>
            <td style="width: 200px">
                <asp:DropDownList ID="ddlOrg_Rqd" runat="server" SkinID="Unicodeddl" Width="195px" ToolTip="काजको लागी कार्यालय">
                </asp:DropDownList></td>
            <td style="width: 120px">
                &nbsp;&nbsp;
                <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="रवाना मिति"></asp:Label></td>
            <td style="width: 555px">
                <asp:TextBox ID="txtLeaveDate_Rdt" runat="server" SkinID="Unicodetxt" Width="100px" ToolTip="काजको रवाना मिति"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 125px" valign="top">
                &nbsp;&nbsp;
                <asp:Label ID="Label5" runat="server" SkinID="Unicodelbl" Text="जिम्मेवारी"></asp:Label></td>
            <td colspan="3" valign="top">
                <asp:TextBox ID="txtResponsibility_Rqd" runat="server" Height="80px" SkinID="Unicodetxt" TextMode="MultiLine" Width="424px" ToolTip="कर्मचारीको जिम्मेवारी"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 125px">
            </td>
            <td style="width: 200px">
                <asp:Button ID="btnAdd" runat="server" OnClick="btnAddDeputation_Click" OnClientClick="return ValidateForm();" SkinID="Add"
                    Text="Add" /></td>
            <td style="width: 120px">
            </td>
            <td style="width: 555px">
            </td>
        </tr>
        <tr>
            <td colspan="4">
            <asp:GridView ID="grdDeputation" runat="server" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333"
                OnRowDataBound="grdDeputation_RowDataBound" Width="990px" OnRowDeleting="grdDeputation_RowDeleting" OnSelectedIndexChanged="grdDeputation_SelectedIndexChanged">
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <Columns>
                    <asp:BoundField DataField="EmpID" HeaderText="EmpID" />
                    <asp:BoundField DataField="EmpName" HeaderText="कर्मचारीको नाम" />
                    <asp:BoundField DataField="DepFromDate" HeaderText="पठाउने मिति" />
                    <asp:BoundField DataField="DepDecisionDate" HeaderText="निर्णय मिति" />
                    <asp:BoundField DataField="DepToOrgID" HeaderText="DepOrgID" />
                    <asp:BoundField DataField="DepToOrgName" HeaderText="कार्यालय" />
                    <asp:BoundField DataField="DepLeaveDate" HeaderText="रवाना मिति" />
                    <asp:BoundField DataField="DepResponsibility" HeaderText="जिम्मेवारी" />
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
                        <FTB:FreeTextBox ID="txtNote" runat="server" BackColor="127, 157, 185" BreakMode="LineBreak" GutterBackColor="127, 157, 185"
                            Height="250px" StartMode="DesignMode" ToolbarBackColor="127, 157, 185" ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline,Strikethrough;Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;InsertRule|Cut,Copy,Paste;Undo,Redo,Print"
                            Width="750px">
                        </FTB:FreeTextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 125px">
                <asp:Label ID="Label20" runat="server" Font-Underline="True" SkinID="Unicodelbl" Text="टिप्पणी को स्थिति"></asp:Label></td>
            <td style="width: 200px">
                <asp:DropDownList ID="ddlTippaniStatus" runat="server" SkinID="Unicodeddl" Width="194px" Enabled="False">
                </asp:DropDownList></td>
            <td style="width: 120px">
            </td>
            <td style="width: 555px">
            </td>
        </tr>
    </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</div>
