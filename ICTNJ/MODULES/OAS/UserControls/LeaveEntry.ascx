<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LeaveEntry.ascx.cs" Inherits="MODULES_OAS_UserControls_LeaveEntry" %>
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
            if(fromDate.value > toDate.value)
            {
                alert('बिदाको अवधि देखि मिति अवधि सम्म मिति भन्दा सानो हुनुपर्छ ।');
                fromDate.focus();
                return false;
            }
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
    <asp:Label ID="Label23" runat="server" SkinID="UnicodeHeadlbl" Text="बिदाको बिबरण"></asp:Label>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
             <table style="width: 1000px">
                <tr>
                    <td style="width: 130px">
                        &nbsp;&nbsp;
                        <asp:Label ID="Label4" runat="server" SkinID="Unicodelbl" Text="बिदाको किसिम"></asp:Label></td>
                    <td style="width: 205px">
                        <asp:DropDownList ID="ddlLeaveType_Rqd" runat="server" SkinID="Unicodeddl" Width="180px" ToolTip="बिदाको किसिम">
                        </asp:DropDownList></td>
                    <td style="width: 100px">
                        <asp:Label ID="Label7" runat="server" SkinID="Unicodelbl" Text="निबेदनको मिति"></asp:Label></td>
                    <td style="width: 205px">
                        <asp:TextBox ID="txtApplicationDate_Rdt" runat="server" SkinID="Unicodetxt" Width="176px" ToolTip="बिदाको निबेदनको मिति"></asp:TextBox></td>
                    <td style="width: 365px">
                        <ajaxToolkit:FilteredTextBoxExtender ID="fltTotalDays" runat="server" FilterType="Numbers" InvalidChars="-, +" TargetControlID="txtTotalDays_Rqd">
                        </ajaxToolkit:FilteredTextBoxExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 130px">
                        &nbsp;&nbsp;
                        <asp:Label ID="Label5" runat="server" SkinID="Unicodelbl" Text="अवधि देखि"></asp:Label></td>
                    <td style="width: 205px">
                        <asp:TextBox ID="txtFromDate_Rdt" runat="server" SkinID="Unicodetxt" Width="176px" ToolTip="बिदाको अवधि देखि"></asp:TextBox></td>
                    <td style="width: 100px">
                        <asp:Label ID="Label6" runat="server" SkinID="Unicodelbl" Text="अवधि सम्म"></asp:Label></td>
                    <td style="width: 205px">
                        <asp:TextBox ID="txtToDate_Rdt" runat="server" SkinID="Unicodetxt" Width="176px" ToolTip="बिदाको अवधि सम्म"></asp:TextBox></td>
                    <td style="width: 365px">
                </tr>
                <tr>
                    <td style="width: 130px" valign="top">
                        &nbsp;&nbsp;
                        <asp:Label ID="Label9" runat="server" SkinID="Unicodelbl" Text="कैफियत"></asp:Label></td>
                    <td colspan="3" valign="top">
                        <asp:TextBox ID="txtRemark" runat="server" Height="54px" SkinID="Unicodetxt" TextMode="MultiLine" Width="488px">
</asp:TextBox></td>
                    <td style="width: 365px" valign="top">
                        <ajaxToolkit:MaskedEditExtender ID="mskFromDate" runat="server" AutoComplete="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtFromDate_Rdt">
                        </ajaxToolkit:MaskedEditExtender>
                        <ajaxToolkit:MaskedEditExtender ID="mskToDate" runat="server" AutoComplete="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtToDate_Rdt">
                        </ajaxToolkit:MaskedEditExtender>
                        <ajaxToolkit:MaskedEditExtender ID="mskAppDate" runat="server" AutoComplete="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtApplicationDate_Rdt">
                        </ajaxToolkit:MaskedEditExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 130px">
                    </td>
                    <td style="width: 205px">
                        <asp:Button ID="btnAdd" runat="server" OnClick="btnAddAward_Click" OnClientClick="return ValidateForm();" SkinID="Add" Text="Add" /></td>
                    <td style="width: 100px">
                        <asp:Label ID="Label8" runat="server" SkinID="Unicodelbl" Text="जम्मा दिन" Visible="False"></asp:Label></td>
                    <td style="width: 205px">
                        <asp:TextBox ID="txtTotalDays_Rqd" runat="server" MaxLength="2" SkinID="Unicodetxt" ToolTip="जम्मा दिन" Width="176px" Visible="False">0</asp:TextBox></td>
                    <td style="width: 365px">
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <asp:GridView ID="grdLeave" runat="server" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333" OnRowDataBound="grdLeave_RowDataBound"
                            OnRowDeleting="grdLeave_RowDeleting" SkinID="Unicodegrd" Width="985px" OnSelectedIndexChanged="grdLeave_SelectedIndexChanged">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="EmpName" HeaderText="कर्मचारीको नाम" />
                                <asp:BoundField DataField="LeaveType" HeaderText="बिदाको किसिम" />
                                <asp:BoundField DataField="ApplicationDate" HeaderText="निबेदनको मिति" />
                                <asp:BoundField DataField="ReqFromDate" HeaderText="अवधि देखि" />
                                <asp:BoundField DataField="ReqToDate" HeaderText="अवधि सम्म" />
                                <asp:BoundField DataField="ReqNoOfDays" HeaderText="जम्मा दिन" />
                                <asp:BoundField DataField="ReqReason" HeaderText="कैफियत" />
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
                    <td style="width: 130px" valign="top">
                        <asp:Label ID="Label21" runat="server" Font-Underline="True" SkinID="Unicodelbl" Text="तपाईको आफ्नो नोट"></asp:Label></td>
                    <td colspan="4" valign="top">
                        <FTB:FreeTextBox ID="txtNote" runat="server" BackColor="127, 157, 185" BreakMode="LineBreak" GutterBackColor="127, 157, 185"
                            Height="250px" StartMode="DesignMode" ToolbarBackColor="127, 157, 185" ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline,Strikethrough;Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;InsertRule|Cut,Copy,Paste;Undo,Redo,Print"
                            Width="750px">
                        </FTB:FreeTextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 130px" valign="top">
                        <asp:Label ID="Label20" runat="server" Font-Underline="True" SkinID="Unicodelbl" Text="टिप्पणी को स्थिति"></asp:Label></td>
                    <td style="width: 205px" valign="top">
                        <asp:DropDownList ID="ddlTippaniStatus" runat="server" Enabled="False" SkinID="Unicodeddl" Width="194px">
                        </asp:DropDownList></td>
                    <td style="width: 100px" valign="top">
                    </td>
                    <td style="width: 205px" valign="top">
                    </td>
                    <td style="width: 365px" valign="top">
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
