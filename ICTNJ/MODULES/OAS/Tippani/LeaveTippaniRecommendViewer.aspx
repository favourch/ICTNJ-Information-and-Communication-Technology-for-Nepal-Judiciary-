<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true" CodeFile="LeaveTippaniRecommendViewer.aspx.cs" 
Inherits="MODULES_OAS_Tippani_LeaveTippaniRecommendViewer" Title="OAS | Leave Tippani Recommend VIewer" MaintainScrollPositionOnPostback="true"
ValidateRequest="false" %>


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

    <script language="javascript" src="../../COMMON/JS/Validation.js" type="text/javascript"></script>

    <script language="javascript" src="../../COMMON/JS/DateValidator.js" type="text/javascript"></script>

    <script language="javascript" src="../../COMMON/JS/EnglishDateValidator.js" type="text/javascript"></script>

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
            
            var leave = document.getElementById('<%= this.grdLeave.ClientID%>'); 
            var rec = document.getElementById('<%= this.grdRecommendation.ClientID%>');
            var fromDate = document.getElementById('<%= this.txtFromDate_Rdt.ClientID%>');
            
            if(leave == null || rec == null)
            {
                alert('कृपया बिदाको प्रमाण बिबरण राख्नुहोस ।');
                fromDate.focus();
                return false;
            }
            
            if(leave.rows.length != rec.rows.length)
            {
                alert('कृपया सबै कर्मचारीको लागी बिदाको प्रमाण बिबरण राख्नुहोस ।');
                fromDate.focus();
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
        
        function ClearOnUnCkecked(chk)
        {
             var fromDate = document.getElementById('<%= this.txtFromDate_Rdt.ClientID%>');
             var toDate = document.getElementById('<%= this.txtToDate_Rdt.ClientID%>');
             var totalDay = document.getElementById('<%= this.txtTotalDays_Rqd.ClientID%>');
             
             if(chk.checked == false)
             {
                fromDate.value = "";
                toDate.value = "";
                totalDay.value = "";
             }
        }
        
        function ValidateLeaveDetail()
        {
            try
            {
                var chk = document.getElementById('<%= this.chkRec.ClientID%>');
                var fromDate = document.getElementById('<%= this.txtFromDate_Rdt.ClientID%>');
                var toDate = document.getElementById('<%= this.txtToDate_Rdt.ClientID%>');
                            
                if(chk.checked == true)
                {
                    if(fromDate.value.trim() == "")
                    {
                        alert('कृपया बिदाको अवधि देखि मिति रख्नुहोस।');
                        fromDate.focus();
                        return false;
                    }
                    
                    if(toDate.value.trim() == "")
                    {
                        alert('कृपया बिदाको अवधि सम्स मिति रख्नुहोस।');
                        toDate.focus();
                        return false;
                    }
                    
                    if(validateDateByControl('<%= this.txtFromDate_Rdt.ClientID%>') == false)
                        return false;
                    
                    if(validateDateByControl('<%= this.txtToDate_Rdt.ClientID%>') == false)
                        return false;
                        
                    if(fromDate.value > toDate.value)
                    {
                        alert('बिदाको अवधि देखि मिति अवधि सम्म मिति भन्दा सानो हुनुपर्छ ।');
                        fromDate.focus();
                        return false;
                    }
                    
                    var hdnFromDate = document.getElementById('<%= this.hdnFromDate.ClientID%>');
                    var hdnTodate = document.getElementById('<%= this.hdnToDate.ClientID%>');
                    
                    if(hdnFromDate.value > fromDate.value)
                    {
                        alert('प्रमाणको अवधि देखि मिति सिफारिको अवधि देखि मिति भन्दा सानो हुन सक्दैन् ।');
                        fromDate.focus();
                        return false;
                    }
                    
                    if(hdnTodate.value < toDate.value)
                    {
                        alert('प्रमाणको अवधि सम्म मिति सिफारिको अवधि सम्म मिति भन्दा ठुलो हुन सक्दैन् ।');
                        toDate.focus();
                        return false;
                    }
                }
                
                return true;
            }
            catch(err)
            {
                alert(err);
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
            <asp:UpdatePanel id="UpdatePanel1" runat="server">
                <contenttemplate>
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
</contenttemplate>
            </asp:UpdatePanel>
            <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click" Text="OK" Width="58px" /></asp:Panel>
        <asp:Label ID="Label1" runat="server" SkinID="UnicodeHeadlbl" Text="बिदाको टिप्पणी चलानी"></asp:Label><br />
        <asp:HiddenField ID="hdnTippaniStatus" runat="server" />
        <br />
        <TRV:TippaniRequestViewer ID="TippaniRequestViewer" runat="server" TippaniSubjectType="Leave" />
        <br />
        <cc1:TabContainer ID="EvaluationTab" runat="server" ActiveTabIndex="0" CssClass="ajax_tab_theme" ScrollBars="Auto" Width="100%">
            <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                <headertemplate>
टिप्पणीको बिबरण 
</headertemplate>
                <contenttemplate>
<asp:Label id="Label451" runat="server" Text="कर्मचारीको बिदाको सिफारिस बिबरण" SkinID="UnicodeHeadlbl"></asp:Label> &nbsp;&nbsp; &nbsp;<asp:Label id="lblLeaveStatus" runat="server" SkinID="Unicodelbl" Font-Bold="True"></asp:Label> <BR /><asp:UpdatePanel id="updRecPanel" runat="server"><ContentTemplate>
<asp:GridView id="grdLeave" runat="server" Width="985px" SkinID="Unicodegrd" OnRowDataBound="grdLeave_RowDataBound" ForeColor="#333333" CellPadding="0" AutoGenerateColumns="False" OnSelectedIndexChanged="grdLeave_SelectedIndexChanged">
<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
<asp:BoundField DataField="OrgID" HeaderText="OrgID"></asp:BoundField>
<asp:BoundField DataField="TippaniID" HeaderText="TippaniID"></asp:BoundField>
<asp:BoundField DataField="EmpID" HeaderText="EmpID"></asp:BoundField>
<asp:BoundField DataField="EmpName" HeaderText="कर्मचारीको नाम"></asp:BoundField>
<asp:BoundField DataField="LeaveType" HeaderText="बिदाको किसिम"></asp:BoundField>
<asp:BoundField DataField="ApplicationDate" HeaderText="निबेदनको मिति"></asp:BoundField>
<asp:BoundField DataField="RecFromDate" HeaderText="अवधि देखि"></asp:BoundField>
<asp:BoundField DataField="RecToDate" HeaderText="अवधि सम्म"></asp:BoundField>
<asp:BoundField DataField="RecNoOfDays" HeaderText="जम्मा दिन"></asp:BoundField>
<asp:BoundField DataField="RecReason" HeaderText="कैफियत"></asp:BoundField>
<asp:CommandField ShowSelectButton="True"></asp:CommandField>
</Columns>

<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> <TABLE style="WIDTH: 985px"><TBODY><TR><TD style="WIDTH: 125px; HEIGHT: 5px"></TD><TD style="WIDTH: 110px; HEIGHT: 5px"></TD><TD style="WIDTH: 90px; HEIGHT: 5px"></TD><TD style="WIDTH: 110px; HEIGHT: 5px"></TD><TD style="WIDTH: 90px; HEIGHT: 5px"></TD><TD style="WIDTH: 460px; HEIGHT: 5px"></TD></TR><TR><TD style="WIDTH: 125px"><asp:Label id="Label3" runat="server" Text="प्रमाण बिबरण" SkinID="Unicodelbl" Font-Bold="True" Font-Overline="False" Font-Underline="True" Font-Italic="True"></asp:Label></TD><TD colSpan=5><asp:CheckBox id="chkRec" onclick="ClearOnUnCkecked(this);" runat="server" Text="सिफारिस गर्छु" SkinID="smallChk" Checked="True"></asp:CheckBox>&nbsp;&nbsp; &nbsp;<asp:Label id="lblDetail" runat="server" SkinID="Unicodelbl" Font-Bold="True"></asp:Label></TD></TR><TR><TD style="WIDTH: 125px"><asp:Label id="Label5" runat="server" Text="अवधि देखि" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 110px"><asp:TextBox id="txtFromDate_Rdt" runat="server" Width="100px" SkinID="Unicodetxt" ToolTip="बिदाको अवधि देखि"></asp:TextBox></TD><TD style="WIDTH: 90px"><asp:Label id="Label6" runat="server" Text="अवधि सम्म" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 110px"><asp:TextBox id="txtToDate_Rdt" runat="server" Width="100px" SkinID="Unicodetxt" ToolTip="बिदाको अवधि सम्म"></asp:TextBox></TD><TD style="WIDTH: 90px"><asp:Label id="Label2" runat="server" Text="जम्मा दिन" SkinID="Unicodelbl" Visible="False"></asp:Label></TD><TD style="WIDTH: 460px"><asp:TextBox id="txtTotalDays_Rqd" runat="server" Width="50px" SkinID="Unicodetxt" Visible="False" ToolTip="जम्मा दिन" MaxLength="2">0</asp:TextBox></TD></TR><TR><TD style="WIDTH: 125px" vAlign=top><asp:Label id="Label9" runat="server" Text="कैफियत" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top colSpan=5><asp:TextBox id="txtRemark" runat="server" Width="463px" Height="30px" SkinID="Unicodetxt" TextMode="MultiLine"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 125px"></TD><TD style="WIDTH: 110px"><asp:Button id="btnAdd" onclick="btnAdd_Click" runat="server" Text="Add" SkinID="Add" onclientclick="return ValidateLeaveDetail();"></asp:Button></TD><TD style="WIDTH: 90px"></TD><TD style="WIDTH: 110px"></TD><TD style="WIDTH: 90px"></TD><TD style="WIDTH: 460px"><ajaxToolkit:FilteredTextBoxExtender id="fltTotalDays" runat="server" TargetControlID="txtTotalDays_Rqd" FilterType="Numbers" InvalidChars="-, +">
                        </ajaxToolkit:FilteredTextBoxExtender><ajaxToolkit:MaskedEditExtender id="mskFromDate" runat="server" TargetControlID="txtFromDate_Rdt" AutoComplete="False" Mask="9999/99/99" MaskType="Date">
                        </ajaxToolkit:MaskedEditExtender><ajaxToolkit:MaskedEditExtender id="mskToDate" runat="server" TargetControlID="txtToDate_Rdt" AutoComplete="False" Mask="9999/99/99" MaskType="Date">
                        </ajaxToolkit:MaskedEditExtender> <asp:HiddenField id="hdnFromDate" runat="server"></asp:HiddenField> <asp:HiddenField id="hdnToDate" runat="server"></asp:HiddenField></TD></TR><TR><TD style="WIDTH: 125px; HEIGHT: 5px"></TD><TD style="WIDTH: 110px; HEIGHT: 5px"></TD><TD style="WIDTH: 90px; HEIGHT: 5px"></TD><TD style="WIDTH: 110px; HEIGHT: 5px"></TD><TD style="WIDTH: 90px; HEIGHT: 5px"></TD><TD style="WIDTH: 460px; HEIGHT: 5px"></TD></TR></TBODY></TABLE><asp:GridView id="grdRecommendation" runat="server" Width="985px" SkinID="Unicodegrd" OnRowDataBound="grdRecommendation_RowDataBound" ForeColor="#333333" CellPadding="0" AutoGenerateColumns="False" OnSelectedIndexChanged="grdRecommendation_SelectedIndexChanged" OnRowDeleting="grdRecommendation_RowDeleting">
<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
<asp:BoundField DataField="OrgID" HeaderText="OrgID"></asp:BoundField>
<asp:BoundField DataField="TippaniID" HeaderText="TippaniID"></asp:BoundField>
<asp:BoundField DataField="EmpID" HeaderText="EmpID"></asp:BoundField>
<asp:BoundField DataField="EmpName" HeaderText="कर्मचारीको नाम"></asp:BoundField>
<asp:BoundField DataField="AppFromDate" HeaderText="अवधि देखि"></asp:BoundField>
<asp:BoundField DataField="AppToDate" HeaderText="अवधि सम्म"></asp:BoundField>
<asp:BoundField DataField="AppNoOfDays" HeaderText="जम्मा दिन"></asp:BoundField>
<asp:BoundField DataField="AppReason" HeaderText="कैफियत"></asp:BoundField>
<asp:BoundField DataField="RDAppYesNo" HeaderText="सिफारिस"></asp:BoundField>
<asp:BoundField DataField="OldFromDate"></asp:BoundField>
<asp:BoundField DataField="OldToDate"></asp:BoundField>
<asp:CommandField ShowSelectButton="True"></asp:CommandField>
</Columns>

<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> 
</ContentTemplate>
</asp:UpdatePanel> <BR /><TABLE width=1000><TBODY><TR><TD style="WIDTH: 125px"><asp:Label id="Label8" runat="server" Text="तपांइको निर्णय:" SkinID="Unicodelbl"></asp:Label> </TD><TD style="WIDTH: 875px"><asp:DropDownList id="ddlDStatus_Rqd" runat="server" Width="190px"></asp:DropDownList> </TD></TR><TR><TD style="WIDTH: 125px" vAlign=top><asp:Label id="Label14" runat="server" Text="तपांइको नोट:" SkinID="Unicodelbl"></asp:Label> </TD><TD style="WIDTH: 875px" vAlign=top><FTB:FreeTextBox id="txtNote" language="en-US" tabIndex=-1 runat="server" Width="750px" Height="250px" Text="" AutoHideToolbar="True" ButtonPath="" HelperFilesPath="" HelperFilesParameters="" AutoConfigure="" AllowHtmlMode="False" ButtonDownImage="False" ButtonOverImage="False" HtmlModeCss="" DownLevelMessage="" DownLevelMode="TextArea" DownLevelRows="10" DownLevelCols="50" GutterBorderColorDark="Gray" GutterBorderColorLight="White" EditorBorderColorDark="Gray" EditorBorderColorLight="Gray" GutterBackColor="127, 157, 185" HtmlModeDefaultsToMonoSpaceFont="True" ButtonFileExtention="gif" StartMode="DesignMode" ReadOnly="False" ScriptMode="External" SupportFolder="/aspnet_client/FreeTextBox/" RenderMode="NotSet" EnableHtmlMode="True" TabMode="InsertSpaces" BreakMode="LineBreak" PasteMode="Default" ConvertHtmlSymbolsToHtmlCodes="False" RemoveScriptNameFromBookmarks="True" RemoveServerNameFromUrls="True" EnableSsl="False" DisableIEBackButton="False" FormatHtmlTagsToXhtml="True" StripAllScripting="False" TextDirection="LeftToRight" SslUrl="/." AutoParseStyles="True" ImageGalleryUrl="ftb.imagegallery.aspx?rif={0}&cif={0}" ImageGalleryPath="~/images/" Focus="False" ShowTagPath="False" AssemblyResourceHandlerPath="" ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline,Strikethrough;Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;InsertRule|Cut,Copy,Paste;Undo,Redo,Print" AutoGenerateToolbarsFromString="True" UseToolbarBackGroundImage="True" EnableToolbars="True" ToolbarBackColor="127, 157, 185" ToolbarBackgroundImage="True" UpdateToolbar="True" ToolbarStyleConfiguration="NotSet" ButtonHeight="20" ButtonWidth="21" ButtonFolder="Images" BackColor="127, 157, 185" DesignModeBodyTagCssClass="" DesignModeCss="" BaseUrl="" InstallationErrorMessage="InlineMessage" ButtonSet="NotSet" ToolbarImagesLocation="InternalResource" ButtonImagesLocation="InternalResource" JavaScriptLocation="InternalResource" ClientSideTextChanged=""></FTB:FreeTextBox> </TD></TR><TR><TD style="WIDTH: 125px" vAlign=top></TD><TD style="WIDTH: 875px" vAlign=top><asp:Button id="btnSaveAsDraft" onclick="btnSaveAsDraft_Click" runat="server" Width="120px" Text="Save as Draft (Text)" SkinID="Dynamic" Enabled="False" __designer:wfdid="w3"></asp:Button> </TD></TR></TBODY></TABLE><uc3:TippaniAttachment id="TippaniAttachment" runat="server"></uc3:TippaniAttachment> <TABLE width=300><TBODY><TR><TD style="WIDTH: 125px"></TD><TD style="WIDTH: 175px"><asp:Button id="btnSendBack" onclick="btnSendBack_Click" runat="server" Width="100px" Text="Send Back" SkinID="Dynamic" OnClientClick="return ConfirmSendBack();" Enabled="False" Visible="False"></asp:Button> </TD></TR></TBODY></TABLE><asp:HiddenField id="hdnForm" runat="server" Value="0"></asp:HiddenField> 
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
            <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
                <headertemplate>
बिदाको बिस्त्रित बिबरण
</headertemplate>
                <contenttemplate>
<asp:GridView id="grdLeaveDetail" runat="server" Width="985px" SkinID="Unicodegrd" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333">
<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
<asp:BoundField DataField="EmpName" HeaderText="कर्मचारीको नाम"></asp:BoundField>
<asp:BoundField DataField="LeaveType" HeaderText="बिदाको किसिम"></asp:BoundField>
<asp:TemplateField HeaderText="निबेदनको मिति"><EditItemTemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("RDApplicationDate") %>'></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label id="Label1" runat="server" Text='<%# Eval("RDApplicationDate") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="अवधि देखि"><EditItemTemplate>
<asp:TextBox id="TextBox2" runat="server" Text='<%# Bind("RDFromDate") %>'></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label id="Label2" runat="server" Text='<%# Eval("RDFromDate") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="अवधि सम्म"><EditItemTemplate>
<asp:TextBox id="TextBox3" runat="server" Text='<%# Bind("RDToDate") %>'></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label id="Label3" runat="server" Text='<%# Eval("RDToDate") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="जम्मा दिन"><EditItemTemplate>
<asp:TextBox id="TextBox4" runat="server" Text='<%# Bind("RDTotal") %>'></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label id="Label4" runat="server" Text='<%# Eval("RDTotal") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="सिफारिस / प्रमाणित"><EditItemTemplate>
<asp:TextBox id="TextBox5" runat="server"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label id="Label5" runat="server" Text='<%# Eval("RDLeaveStatus") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
</Columns>

<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> 
</contenttemplate>
            </ajaxToolkit:TabPanel>
        </cc1:TabContainer><br />
        <uc1:ChannelPerson ID="chnlPerson" runat="server" ApplicationString="5, 3" TippaniSubjectID="1" />
        <br />
        <table width="500">
            <tr>
                <td style="width: 500px">
                    <asp:Button ID="btnSubmit" runat="server" Enabled="False" OnClick="btnSubmit_Click" OnClientClick="return ValidateForm();"
                        SkinID="Normal" Text="Submit" />
                    <asp:Button ID="btnCancelSubmit" runat="server" OnClick="btnCancelSubmit_Click" SkinID="Cancel" Text="Cancel" /></td>
            </tr>
        </table>
    </div>
</asp:Content>
