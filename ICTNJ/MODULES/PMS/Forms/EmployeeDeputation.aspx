<%@ Page Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master" AutoEventWireup="true" CodeFile="EmployeeDeputation.aspx.cs" Inherits="MODULES_PMS_Forms_EmployeeDeputation" Title="PMS | Employee Deputation" %>
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
            DropShadow="true"
            PopupDragHandleControlID="programmaticPopupDragHandle"
            RepositionMode="RepositionOnWindowScroll" >
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none;
        width: 350px; padding: 10px">
        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD;
            border: solid 1px Gray; color: Black; text-align: center;">
            Status
        </asp:Panel>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
<asp:Label id="lblStatusMessage" runat="server" Text="Label"></asp:Label> 
</ContentTemplate>
        </asp:UpdatePanel>
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
            Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    <br />
    <asp:Label ID="Label6" runat="server" SkinID="UnicodeHeadlbl" Text="काज "></asp:Label><br />
    <br />
    <asp:UpdatePanel id="UpdatePanel2" runat="server">
        <contenttemplate>
<TABLE style="HEIGHT: 582px" width=900><TBODY><TR><TD style="WIDTH: 60px"><asp:Label id="lblOrganization" runat="server" Width="60px" Text="कार्यालय" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 245px"><asp:DropDownList id="ddlOrganization" runat="server" Width="240px" SkinID="Unicodeddl" AutoPostBack="True" OnSelectedIndexChanged="ddlOrganization_SelectedIndexChanged"></asp:DropDownList></TD><TD style="WIDTH: 28px"><asp:Label id="lblDesignation" runat="server" Text=" पद" SkinID="Unicodelbl" Visible="False"></asp:Label></TD><TD><asp:DropDownList id="ddlPost" runat="server" Width="137px" SkinID="Unicodeddl" Visible="False">
                </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 60px; HEIGHT: 21px"><asp:Label id="lblUnit" runat="server" Text="शाखा" SkinID="Unicodelbl" Visible="False"></asp:Label></TD><TD style="WIDTH: 245px; HEIGHT: 21px"><asp:DropDownList id="ddlUnit" runat="server" Width="170px" SkinID="Unicodeddl" AutoPostBack="True" Visible="False">
                </asp:DropDownList></TD><TD style="WIDTH: 28px; HEIGHT: 21px"><asp:Label id="lblSection" runat="server" Width="28px" Text="फांट" SkinID="Unicodelbl" Visible="False"></asp:Label></TD><TD style="HEIGHT: 21px"><asp:DropDownList id="ddlSection" runat="server" Width="138px" SkinID="Unicodeddl" Visible="False">
                </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 60px; HEIGHT: 21px"></TD><TD style="WIDTH: 245px; HEIGHT: 21px"></TD><TD style="WIDTH: 28px; HEIGHT: 21px"></TD><TD style="HEIGHT: 21px"><asp:Button id="btnSearch" onclick="btnSearch_Click" runat="server" Text="Search" SkinID="Normal" __designer:wfdid="w7"></asp:Button> <asp:Button id="btnSearchCancel" onclick="btnSearchCancel_Click" runat="server" Text="Cancel" SkinID="Cancel" __designer:wfdid="w8"></asp:Button></TD></TR><TR><TD style="HEIGHT: 21px" colSpan=4>
<HR />
</TD></TR><TR><TD style="HEIGHT: 21px" vAlign=top colSpan=4><asp:Label id="lblSearch" runat="server" SkinID="Unicodelbl"></asp:Label><BR /><asp:UpdatePanel id="UpdatePanel1" runat="server"><ContentTemplate>
<asp:Panel id="pnlEmployee" runat="server" Width="900px" Height="150px" __designer:wfdid="w14" ScrollBars="Auto"><asp:GridView id="grdEmployee" runat="server" Width="890px" SkinID="Unicodegrd" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333" GridLines="None" OnRowCreated="grdEmployee_RowCreated" __designer:wfdid="w15">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="EmpID" HeaderText="EmpID">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="EmpName" HeaderText="कर्मचारीको नाम">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="GenderDesc" HeaderText="लिँग">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="OrgID" HeaderText="OrgID">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="OrgName" HeaderText="कार्यालयको नाम">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DesID" HeaderText="DesID">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DesName" HeaderText="पद">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="PostID" HeaderText="PostID">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="FromDate" HeaderText="FromDate">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:CommandField ShowSelectButton="True">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:CommandField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView></asp:Panel> 
</ContentTemplate>
</asp:UpdatePanel> <BR />
<HR />
<BR /><TABLE width=900><TBODY><TR><TD style="WIDTH: 151px" vAlign=top><asp:Label id="Label1" runat="server" Text="काज कार्यालय" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 280px" vAlign=top><asp:DropDownList id="ddlDeputationOrganization" runat="server" Width="240px" SkinID="Unicodeddl"></asp:DropDownList></TD><TD style="WIDTH: 86px" vAlign=top><asp:Label id="lblDecisionDate" runat="server" Width="95px" Text="निर्णय मिति" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:TextBox id="txtDecisionDate" runat="server" Width="73px" SkinID="Unicodetxt"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender1" runat="server" TargetControlID="txtDecisionDate" Mask="9999/99/99" MaskType="Date" AutoComplete="False">
                            </ajaxToolkit:MaskedEditExtender> </TD></TR><TR><TD style="WIDTH: 151px" vAlign=top><asp:Label id="lblResponsibility" runat="server" Text="कैफियत" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 280px" vAlign=top><asp:TextBox id="txtResponsibility" runat="server" Width="233px" Height="89px" TextMode="MultiLine"></asp:TextBox></TD><TD style="WIDTH: 86px" vAlign=top><asp:Label id="lblVerifiedBy" runat="server" Width="151px" Text="प्रमाणित गर्ने कर्मचारी" SkinID="Unicodelbl" Visible="False"></asp:Label></TD><TD vAlign=top><asp:TextBox id="txtVerifiedBy" runat="server" Width="150px" SkinID="Unicodetxt" Visible="False"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 151px" vAlign=top></TD><TD style="WIDTH: 280px" vAlign=top><asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Text="Submit" SkinID="Normal"></asp:Button> <asp:Button id="btnCancel" onclick="btnCancel_Click" runat="server" Text="Cancel" SkinID="Cancel"></asp:Button></TD><TD style="WIDTH: 86px" vAlign=top></TD><TD>&nbsp;</TD></TR><TR><TD vAlign=top colSpan=4>
<HR />
</TD></TR><TR><TD style="HEIGHT: 21px" vAlign=top colSpan=4><asp:Label id="lblRamana" runat="server" Text="रमाना" SkinID="UnicodeHeadlbl"></asp:Label></TD></TR><TR><TD style="WIDTH: 151px; HEIGHT: 21px" vAlign=top><asp:Label id="Label2" runat="server" Text="काज कार्यालय" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 280px; HEIGHT: 21px" vAlign=top><asp:DropDownList id="ddlDeputaionOrgEdit" runat="server" Width="238px" SkinID="Unicodeddl">
                            </asp:DropDownList></TD><TD style="WIDTH: 86px; HEIGHT: 21px" vAlign=top><asp:Label id="Label3" runat="server" Width="85px" Text="निर्णय मिति" SkinID="Unicodelbl"></asp:Label></TD><TD style="HEIGHT: 21px"><asp:TextBox id="txtDecisionDateEdit" runat="server" Width="73px" SkinID="Unicodetxt"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender3" runat="server" TargetControlID="txtDecisionDateEdit" Mask="9999/99/99" MaskType="Date" AutoComplete="False">
                            </ajaxToolkit:MaskedEditExtender> </TD></TR><TR><TD style="WIDTH: 151px; HEIGHT: 89px" vAlign=top><asp:Label id="Label5" runat="server" Text="कैफियत" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 280px; HEIGHT: 89px" vAlign=top><asp:TextBox id="txtResponsibilityEdit" runat="server" Width="233px" Height="89px" SkinID="Unicodetxt" TextMode="MultiLine"></asp:TextBox></TD><TD style="WIDTH: 86px; HEIGHT: 89px" vAlign=top><asp:Label id="Label4" runat="server" Width="148px" Text="प्रमाणित गर्ने कर्मचारी" SkinID="Unicodelbl" Visible="False"></asp:Label></TD><TD style="HEIGHT: 89px" vAlign=top><asp:TextBox id="txtDecision" runat="server" SkinID="Unicodetxt" Visible="False"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 151px; HEIGHT: 21px" vAlign=top></TD><TD style="WIDTH: 280px; HEIGHT: 21px" vAlign=top><asp:Button id="btnAddEdited" onclick="btnAddEdited_Click" runat="server" Width="50px" Text="Add" SkinID="Add"></asp:Button></TD><TD style="WIDTH: 86px; HEIGHT: 21px" vAlign=top></TD><TD style="HEIGHT: 21px" vAlign=top></TD></TR><TR><TD style="HEIGHT: 31px" vAlign=top colSpan=4>
<HR />
</TD></TR><TR><TD style="HEIGHT: 21px" vAlign=top colSpan=4><asp:GridView id="grdEmpDepRamana" runat="server" Width="900px" SkinID="Unicodegrd" OnSelectedIndexChanged="grdEmpDepRamana_SelectedIndexChanged" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333" GridLines="None" OnRowDeleting="grdEmpDepRamana_RowDeleting" OnRowDataBound="grdEmpDepRamana_RowDataBound" OnRowCreated="grdEmpDepRamana_RowCreated">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="EmpID" HeaderText="PID">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="EmpName" HeaderText="कर्मचारीको नाम">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="GenderDesc" HeaderText="लिंग">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="OrgID" HeaderText="OrgID">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="OrgName" HeaderText="कार्यालयको नाम">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DesID" HeaderText="DesID">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DesName" HeaderText="पद">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="PostID" HeaderText="PostID">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="FromDate" HeaderText="FromDate">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DecisionDate" HeaderText="काज सिफारिस मिति">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Responsibilities" HeaderText="कैफियत">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DepOrgID" HeaderText="DepOrgID">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DepOrgName" HeaderText="काज कार्यालय">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="जाने/नजाने">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
<ItemTemplate>
             <asp:CheckBox ID="chkBox" checked="true" runat="server" Text='<%# Bind("Active") %>' />
                                        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="रमानी मिति">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
<ItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("LeaveDate") %>' Width="82px"></asp:TextBox>
                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" AutoComplete="False" Mask="9999/99/99" MaskType="Date" TargetControlID="TextBox1">
                </ajaxToolkit:MaskedEditExtender>
                                        
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="Action" HeaderText="Action">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:TemplateField ShowHeader="False">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
<ItemTemplate>
<asp:LinkButton runat="server" Text="Select" CommandName="Select" CausesValidation="False" id="btnSelect"></asp:LinkButton>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField><ItemTemplate>
          <asp:LinkButton ID="btnDeleteRamana" CommandName="Delete" runat="server">Delete</asp:LinkButton>                              
</ItemTemplate>
</asp:TemplateField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR><TD style="HEIGHT: 21px" vAlign=top colSpan=4><asp:Button id="btnRawanaSave" onclick="btnRawanaSave_Click" runat="server" Text="Submit" SkinID="Normal"></asp:Button> <asp:Button id="btnSaveCancel" onclick="btnSaveCancel_Click" runat="server" Text="Cancel" SkinID="Cancel"></asp:Button></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
</contenttemplate>
    </asp:UpdatePanel>
    <br />
</asp:Content>

