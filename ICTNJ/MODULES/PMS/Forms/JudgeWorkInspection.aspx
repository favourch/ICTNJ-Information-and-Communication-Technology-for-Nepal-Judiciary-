<%@ Page Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master" AutoEventWireup="true" CodeFile="JudgeWorkInspection.aspx.cs" Inherits="MODULES_PMS_Forms_JudgeWorkInspection" Title="PMS | Judge Work Inspection" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
         <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" style="display:none"/>
    
        <ajaxToolkit:ModalPopupExtender runat="server" ID="programmaticModalPopup"
            BehaviorID="programmaticModalPopupBehavior"
            TargetControlID="hiddenTargetControlForModalPopup"
            PopupControlID="programmaticPopup" 
            BackgroundCssClass="modalBackground"
            DropShadow="True"
            PopupDragHandleControlID="programmaticPopupDragHandle"
            RepositionMode="RepositionOnWindowScroll" >
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel runat="server" CssClass="modalPopup" ID="programmaticPopup" style="display:none;width:350px;padding:10px">
            <asp:Panel runat="Server" ID="programmaticPopupDragHandle" Style="cursor: move;background-color:#DDDDDD;border:solid 1px Gray;color:Black;text-align:center;">
                Save Status
            </asp:Panel>
            <asp:UpdatePanel id="UpdatePanel3" runat="server">
                <contenttemplate>
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
</contenttemplate>
            </asp:UpdatePanel>
            <br />
<asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click" Width="58px" />           <br />
        </asp:Panel>
    <br />
    &nbsp; &nbsp; &nbsp;
    <asp:Label ID="Label7" runat="server" SkinID="UnicodeHeadlbl" Text="न्यायाधिशको मुल्यांकन"></asp:Label>
    <br />
    <br />
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<TABLE width=1000><TBODY><TR><TD style="WIDTH: 19px"></TD><TD style="WIDTH: 200px"><asp:Label id="Label6" runat="server" Width="128px" Text="कार्यालय" SkinID="Unicodelbl" Font-Bold="False"></asp:Label></TD><TD><asp:DropDownList id="ddlCourt" runat="server" Width="336px" SkinID="Unicodeddl" AutoPostBack="true" OnSelectedIndexChanged="ddlCourt_SelectedIndexChanged">
                </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 19px"></TD><TD><asp:Label id="lblJudgeName" runat="server" Width="128px" Text="न्यायाधिशको नाम" SkinID="Unicodelbl" Font-Bold="False"></asp:Label></TD><TD><asp:DropDownList id="ddlJudgeList" runat="server" Width="338px" SkinID="Unicodeddl" AutoPostBack="true" OnSelectedIndexChanged="ddlJudgeList_SelectedIndexChanged">
                </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 19px"></TD><TD></TD><TD></TD></TR><TR><TD style="WIDTH: 19px"></TD><TD></TD><TD></TD></TR><TR><TD style="WIDTH: 19px" colSpan=1></TD><TD colSpan=2><asp:Panel id="Panel2" runat="server" CssClass="collapsePanelHeader" Width="85%" Height="30px">
                    <div style="cursor: pointer; vertical-align: middle;">
                        <div style="float: left;width:620px">
                            निरीक्षणकर्ता खोज्नुहोस
                        </div>
                    </div>
                </asp:Panel> </TD></TR><TR><TD style="WIDTH: 19px" vAlign=top colSpan=1></TD><TD vAlign=top colSpan=2><asp:Panel id="Panel3" runat="server" Width="100%"><TABLE width="100%"><TBODY><TR><TD style="WIDTH: 90px" vAlign=top><asp:Label id="Label30" runat="server" Text="संकेत नं" SkinID="Unicodelbl" Font-Bold="False">
                        </asp:Label></TD><TD style="WIDTH: 150px" vAlign=top><asp:TextBox id="txtSymbolNo" runat="server" Width="130px" SkinID="Unicodetxt" MaxLength="15" ToolTip="First Name"></asp:TextBox> </TD><TD style="WIDTH: 85px"></TD><TD style="WIDTH: 135px"></TD><TD style="WIDTH: 26px"></TD><TD style="WIDTH: 150px"></TD></TR><TR><TD style="WIDTH: 90px" vAlign=top><asp:Label id="Label1" runat="server" Width="81px" Text="पहिलो नाम" SkinID="Unicodelbl" Font-Bold="False"></asp:Label> </TD><TD vAlign=top><asp:TextBox id="txtFName" runat="server" Width="130px" SkinID="Unicodetxt" MaxLength="35" ToolTip="First Name"></asp:TextBox> </TD><TD style="WIDTH: 85px" vAlign=top><asp:Label id="Label2" runat="server" Width="81px" Text="बिचको नाम" SkinID="Unicodelbl" Font-Bold="False"></asp:Label> </TD><TD style="WIDTH: 135px" vAlign=top><asp:TextBox id="txtMName" runat="server" Width="130px" SkinID="Unicodetxt" MaxLength="15"></asp:TextBox> </TD><TD style="WIDTH: 26px" vAlign=top align=center><asp:Label id="Label3" runat="server" Width="23px" Height="22px" Text="थर" SkinID="Unicodelbl" Font-Bold="False"></asp:Label> </TD><TD vAlign=top><asp:TextBox id="txtSurName" runat="server" SkinID="Unicodetxt" MaxLength="35" ToolTip="Surname"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 90px" vAlign=top><asp:Label id="Label5" runat="server" Text="लिंग" SkinID="Unicodelbl" Font-Bold="False"></asp:Label> </TD><TD vAlign=top><asp:DropDownList id="ddlGender" runat="server" Width="135px" SkinID="Unicodeddl">
                                <asp:ListItem Value="SG">छान्नुहोस</asp:ListItem>
                                <asp:ListItem Value="M">पुरूष</asp:ListItem>
                                <asp:ListItem Value="F">महिला</asp:ListItem>
                                <asp:ListItem Value="O">अन्य</asp:ListItem>
                            </asp:DropDownList> </TD><TD style="WIDTH: 85px" vAlign=top><asp:Label id="Label4" runat="server" Text="जन्म मिति" SkinID="Unicodelbl" Font-Bold="False"></asp:Label> </TD><TD style="WIDTH: 135px" vAlign=top><asp:TextBox id="txtdOB" runat="server" Width="130px" MaxLength="10"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender2" runat="server" TargetControlID="txtdOB" AutoComplete="False" Mask="9999/99/99" MaskType="Date">
                            </ajaxToolkit:MaskedEditExtender> </TD><TD style="WIDTH: 26px"></TD><TD vAlign=top><asp:Button id="btnSearch" onclick="btnSearch_Click" runat="server" Width="68px" Text="Search" SkinID="Normal"></asp:Button> <asp:Button id="btnSearchCancel" onclick="btnSearchCancel_Click" runat="server" Width="68px" Text="Cancel" SkinID="Cancel"></asp:Button> </TD></TR><TR><TD colSpan=6>
<HR />
</TD></TR><TR><TD vAlign=top colSpan=6><asp:Label id="lblSearch" runat="server" Font-Bold="true">
                </asp:Label> <asp:Panel id="Panel1" runat="server" Width="90%" Height="200px" ScrollBars="auto"><asp:GridView id="grdEmployee" runat="server" SkinID="Unicodegrd" OnSelectedIndexChanged="grdEmployee_SelectedIndexChanged" OnRowDataBound="grdEmployee_RowDataBound" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333" GridLines="None">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="EMPID" HeaderText="EMPLOYEE ID"></asp:BoundField>
<asp:BoundField DataField="SYMBOLNO" HeaderText="संकेत नं"></asp:BoundField>
<asp:BoundField DataField="FIRSTNAME" HeaderText="FIRST NAME"></asp:BoundField>
<asp:BoundField DataField="MIDDLENAME" HeaderText="MIDDLE NAME"></asp:BoundField>
<asp:BoundField DataField="SURNAME" HeaderText="SURNAME"></asp:BoundField>
<asp:BoundField DataField="RDFULLNAME" HeaderText="पुरा नाम थर"></asp:BoundField>
<asp:BoundField DataField="RDGENDER" HeaderText="लिंग"></asp:BoundField>
<asp:BoundField DataField="DOB" HeaderText="जन्म मिति"></asp:BoundField>
<asp:BoundField DataField="RDMARITALSTATUS" HeaderText="बैबाहिक सम्बन्ध"></asp:BoundField>
<asp:BoundField DataField="FATHERNAME" HeaderText="बाबुको नाम"></asp:BoundField>
<asp:BoundField DataField="GFATHERNAME" HeaderText="बबाजेको नाम"></asp:BoundField>
<asp:CommandField ShowSelectButton="True"></asp:CommandField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> </asp:Panel> </TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR><TD style="WIDTH: 19px" colSpan=1></TD><TD colSpan=2><ajaxToolkit:CollapsiblePanelExtender id="cpeDemo" runat="Server" SkinID="CollapsiblePanelDemo" TargetControlID="Panel3" CollapseControlID="Panel2" Collapsed="true" ExpandControlID="Panel2" SuppressPostBack="true" TextLabelID="Label1">
                            </ajaxToolkit:CollapsiblePanelExtender> </TD></TR><TR><TD style="WIDTH: 19px"></TD><TD></TD><TD></TD></TR><TR><TD style="WIDTH: 19px"></TD><TD><asp:Label id="lblInspector" runat="server" Width="139px" SkinID="Unicodelbl" Font-Bold="False">निरीक्षणकर्ताको नाम</asp:Label></TD><TD><asp:TextBox id="txtInspection" runat="server" Width="410px" SkinID="Unicodetxt" ReadOnly="true"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 19px"></TD><TD><asp:Label id="lblInspectionDate" runat="server" Width="40px" Text="मिति" SkinID="Unicodelbl" Font-Bold="False"></asp:Label> </TD><TD><asp:TextBox id="txtInspectionDate" runat="server" Width="110px" SkinID="Unicodetxt"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender1" runat="server" TargetControlID="txtInspectionDate" MaskType="Date" Mask="9999/99/99" AutoComplete="False">
                </ajaxToolkit:MaskedEditExtender> </TD></TR><TR><TD style="WIDTH: 19px; HEIGHT: 26px"></TD><TD style="HEIGHT: 26px"><asp:Label id="lblFiscalYear" runat="server" Width="40px" SkinID="Unicodelbl" Font-Bold="False">आ. व.</asp:Label></TD><TD style="HEIGHT: 26px"><asp:TextBox id="txtFiscalYear" runat="server" Width="53px" SkinID="Unicodetxt" AutoPostBack="true" OnTextChanged="txtFiscalYear_TextChanged" MaxLength="5"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 19px"></TD><TD><asp:Label id="lblWork" runat="server" Width="170px" Text="सम्पादित कामको स्थिति" SkinID="Unicodelbl" Font-Bold="False"></asp:Label></TD><TD><asp:DropDownList id="ddlWorkList" runat="server" Width="100%" SkinID="Unicodeddl">
                </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 19px" colSpan=1></TD><TD colSpan=2><TABLE width="100%"><TBODY><TR><TD style="WIDTH: 19%"><asp:Label id="lblDone" runat="server" Width="170px" Text="भएको छ वा छैन" SkinID="Unicodelbl" Font-Bold="False"></asp:Label></TD><TD style="WIDTH: 25%"><asp:CheckBox id="chkDone" runat="server" Width="90px" AutoPostBack="true" Checked="true" OnCheckedChanged="chkDone_CheckedChanged"></asp:CheckBox></TD><TD style="WIDTH: 25%"><asp:Label id="lblNoOfCases" runat="server" Width="245px" Text="नभएकोमा कतिवटा मद्दामा त्यस्तो देखिएको" SkinID="Unicodelbl" Font-Bold="False"></asp:Label></TD><TD style="WIDTH: 25%"><asp:TextBox id="txtNoOfCases" runat="server" Width="80px" SkinID="Unicodetxt" MaxLength="4"></asp:TextBox> <ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender1" runat="server" TargetControlID="txtNoOfCases" FilterMode="ValidChars" FilterType="Numbers">
                            </ajaxToolkit:FilteredTextBoxExtender> </TD></TR><TR><TD><asp:Label id="lblInspectionCaseNo" runat="server" Width="199px" Text="निरीक्षण गरिएको मिसिल वा मुद्दा नं" SkinID="Unicodelbl" Font-Bold="False"></asp:Label></TD><TD><asp:TextBox id="txtInspectionCaseNo" runat="server" Width="85px" SkinID="Unicodetxt" MaxLength="10"></asp:TextBox></TD><TD><asp:Label id="lblNoDoneReason" runat="server" Width="190px" Text="नभएकोमा देखाईएको कारण" SkinID="Unicodelbl" Font-Bold="False"></asp:Label></TD><TD><asp:TextBox id="txtNoDoneReason" runat="server" Width="275px" SkinID="Unicodetxt" MaxLength="300" TextMode="MultiLine"></asp:TextBox></TD></TR><TR><TD><asp:Label id="lblIsReasonValid" runat="server" Width="152px" Text="कारण उचित छ / छैन" SkinID="Unicodelbl" Font-Bold="False"></asp:Label></TD><TD><asp:CheckBox id="chkIsReasonValid" runat="server" Width="50px"></asp:CheckBox></TD><TD><asp:Label id="lblRemarks" runat="server" Text="कैफियत" SkinID="Unicodelbl" Font-Bold="False"></asp:Label></TD><TD><asp:TextBox id="txtremarks" runat="server" Width="277px" SkinID="Unicodetxt" MaxLength="300" TextMode="MultiLine"></asp:TextBox></TD></TR></TBODY></TABLE><asp:Button id="btnAdd" onclick="btnAdd_Click" runat="server" Width="50px" Text="Add" SkinID="Add"></asp:Button></TD></TR><TR><TD style="WIDTH: 19px" colSpan=1></TD><TD colSpan=2>
<HR />
</TD></TR><TR><TD style="WIDTH: 19px" colSpan=1></TD><TD colSpan=2><asp:Panel id="Panel4" runat="server" Width="100%" Height="250px" ScrollBars="Auto"><asp:GridView id="grdWorkInspectionDetails" runat="server" SkinID="Unicodegrd" OnSelectedIndexChanged="grdWorkInspectionDetails_SelectedIndexChanged" OnRowDataBound="grdWorkInspectionDetails_RowDataBound" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333" OnRowDeleting="grdWorkInspectionDetails_RowDeleting" GridLines="None">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="EmployeeID" HeaderText="Employee ID"></asp:BoundField>
<asp:BoundField DataField="FiscalYear" HeaderText="आ. व."></asp:BoundField>
<asp:BoundField DataField="JwcID" HeaderText="JwcID"></asp:BoundField>
<asp:BoundField DataField="JwcName" HeaderText="सम्पादित कामको स्थिति"></asp:BoundField>
<asp:CheckBoxField DataField="WorkDone" HeaderText="भएको छ वा छैन"></asp:CheckBoxField>
<asp:BoundField DataField="NoOfCase" HeaderText="नभएको कतिवटा मुद्दामा त्यस्तो देखिएको"></asp:BoundField>
<asp:BoundField DataField="InspectionCaseNo" HeaderText="निरीक्षण गरिएको मिसिल वा मद्दा नं"></asp:BoundField>
<asp:BoundField DataField="NoDoneReason" HeaderText="नभएकोमा देखाइएको कारण"></asp:BoundField>
<asp:CheckBoxField DataField="IsReasonValid" HeaderText="कारण उचित छ / छैन"></asp:CheckBoxField>
<asp:BoundField DataField="Remarks" HeaderText="कैफियत"></asp:BoundField>
<asp:BoundField DataField="Action" HeaderText="Action"></asp:BoundField>
<asp:CommandField ShowSelectButton="True"></asp:CommandField>
<asp:TemplateField><EditItemTemplate>
                                    <asp:Button ID="btnDelete" CommandName="Delete" runat="server" Text="Delete" />
                                
</EditItemTemplate>
<ItemTemplate>
                                    <asp:Button ID="btnDelete" CommandName="Delete" runat="server" Text="Delete" />
                                
</ItemTemplate>
</asp:TemplateField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> </asp:Panel> </TD></TR><TR><TD style="WIDTH: 19px"></TD><TD><asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Width="57px" Text="Save" Visible="False"></asp:Button><asp:Button id="btnCancel" onclick="btnCancel_Click" runat="server" Text="Cancel" Visible="False"></asp:Button></TD><TD></TD></TR><TR><TD style="WIDTH: 19px"></TD><TD></TD><TD></TD></TR><TR><TD style="WIDTH: 19px"></TD><TD></TD><TD></TD></TR></TBODY></TABLE>
</contenttemplate>
    </asp:UpdatePanel>
    <br />
<%--</contenttemplate>
    </asp:UpdatePanel>--%>
</asp:Content>

