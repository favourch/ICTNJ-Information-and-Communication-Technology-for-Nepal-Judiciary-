<%@ Control AutoEventWireup="true" CodeFile="TrainingEntry.ascx.cs" Inherits="MODULES_OAS_UserControls_TrainingEntry" Language="C#" %>
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
        <br />
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click" Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    <asp:Label ID="Label23" runat="server" SkinID="UnicodeHeadlbl" Text="तालिमको बिबरण"></asp:Label>
    <asp:UpdatePanel ID="updTraininglst" runat="server">
        <ContentTemplate>
    <ajaxToolkit:MaskedEditExtender ID="mskFromDate" runat="server" AutoComplete="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtFromDate_Rdt">
    </ajaxToolkit:MaskedEditExtender>
    <ajaxToolkit:MaskedEditExtender ID="mskToDate" runat="server" AutoComplete="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtToDate_Rdt">
    </ajaxToolkit:MaskedEditExtender>
    <table width="1000">
        <tr>
            <td style="width: 125px">
                &nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="शिर्षक"></asp:Label></td>
            <td style="width: 200px">
                <asp:TextBox ID="txtSubject_Rqd" runat="server" SkinID="Unicodetxt" Width="190px" ToolTip="तालिमको शिर्षक"></asp:TextBox></td>
            <td style="width: 125px">
            </td>
            <td style="width: 550px">
            </td>
        </tr>
        <tr>
            <td style="width: 125px">
                &nbsp;&nbsp;
                <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="संस्थाको नाम"></asp:Label></td>
            <td colspan="2">
                <asp:DropDownList ID="ddlInstitution_Rqd" runat="server" Width="284px" SkinID="Unicodeddl" ToolTip="तालिमको संस्था">
                </asp:DropDownList></td>
            <td style="width: 550px">
            </td>
        </tr>
        <tr>
            <td style="width: 125px">
                &nbsp;&nbsp;
                <asp:Label ID="Label4" runat="server" SkinID="Unicodelbl" Text="अवधि देखि"></asp:Label></td>
            <td style="width: 200px">
                <asp:TextBox ID="txtFromDate_Rdt" runat="server" Width="100px" SkinID="Unicodetxt" ToolTip="तालिमको अवधि देखि"></asp:TextBox></td>
            <td style="width: 125px">
                <asp:Label ID="Label3" runat="server" SkinID="Unicodelbl" Text="अवधि सम्म"></asp:Label></td>
            <td style="width: 550px">
                <asp:TextBox ID="txtToDate_Rdt" runat="server" Width="100px" SkinID="Unicodetxt" ToolTip="तालिमको अवधि सम्म"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 125px" valign="top">
                &nbsp;&nbsp;
                <asp:Label ID="Label5" runat="server" SkinID="Unicodelbl" Text="कैफियत"></asp:Label></td>
            <td colspan="3" valign="top">
                <asp:TextBox ID="txtRemark" runat="server" Height="60px" SkinID="Unicodetxt" TextMode="MultiLine" Width="430px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 125px">
            </td>
            <td style="width: 200px">
                <asp:Button ID="btnAddTraining" runat="server" OnClick="btnAddTraining_Click" OnClientClick="return ValidateForm();" SkinID="Add"
                    Text="Add" /></td>
            <td style="width: 125px">
            </td>
            <td style="width: 550px">
            </td>
        </tr>
        <tr>
            <td colspan="4">
            <asp:GridView ID="grdTraining" runat="server" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333" Width="925px" OnRowDataBound="grdTraining_RowDataBound" OnRowDeleting="grdTraining_RowDeleting" SkinID="Unicodegrd" OnSelectedIndexChanged="grdTraining_SelectedIndexChanged">
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <Columns>
                    <asp:BoundField DataField="EmpID" HeaderText="EmpID" />
                    <asp:BoundField DataField="EmpName" HeaderText="कर्मचारीको नाम" />
                    <asp:BoundField DataField="TrnInstitutionID" HeaderText="InstitutionID" />
                    <asp:BoundField DataField="TrnInstitutionName" HeaderText="संस्थाको नाम" />
                    <asp:BoundField DataField="TrnSubject" HeaderText="शिर्षक" />
                    <asp:BoundField DataField="TrnFromDate" HeaderText="अवधि देखि" />
                    <asp:BoundField DataField="TrnToDate" HeaderText="अवधि सम्म" />
                    <asp:BoundField DataField="TrnRemark" HeaderText="कैफियत" />
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
            <td style="width: 125px">
            </td>
            <td style="width: 550px">
            </td>
        </tr>
    </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAddTraining" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</div>