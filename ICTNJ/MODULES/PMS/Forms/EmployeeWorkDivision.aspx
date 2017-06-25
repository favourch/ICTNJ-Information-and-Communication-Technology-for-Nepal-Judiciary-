<%@ Page Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master" AutoEventWireup="true"
    CodeFile="EmployeeWorkDivision.aspx.cs" Inherits="MODULES_PMS_Forms_EmployeeWorkDivision"
    Title="PMS | Employee Work Assignment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                SaveStatus
            </asp:Panel>
            <asp:UpdatePanel id="UpdatePanel4" runat="server">
                <contenttemplate>
<BR /><asp:Label id="lblStatusMessage" runat="server" Text="Label"></asp:Label> 
</contenttemplate>
            </asp:UpdatePanel>
            <br />
<asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click" Width="58px" />           <br />
        </asp:Panel>

    &nbsp;&nbsp;<br />
            
        <asp:UpdatePanel id="UpdatePanel3" runat="server">
            <contenttemplate>
<TABLE style="WIDTH: 900px"><TBODY><TR><TD style="WIDTH: 70px; HEIGHT: 24px"><asp:Label id="Label30" runat="server" Width="110px" Height="22px" Text="संकेत नं" SkinID="Unicodelbl" __designer:dtid="1688849860263961" __designer:wfdid="w1"></asp:Label></TD><TD style="WIDTH: 299px; HEIGHT: 24px"><asp:TextBox id="txtSymbolNo" runat="server" Width="130px" SkinID="Unicodetxt" __designer:dtid="1688849860263963" __designer:wfdid="w2" MaxLength="15" ToolTip="First Name"></asp:TextBox></TD><TD style="WIDTH: 66px; HEIGHT: 24px"></TD><TD style="WIDTH: 171px; HEIGHT: 24px"></TD></TR><TR><TD style="WIDTH: 70px; HEIGHT: 24px"><asp:Label id="lblOrganizaion" runat="server" Width="75px" Text="कार्यालय" SkinID="Unicodelbl" __designer:wfdid="w5"></asp:Label></TD><TD style="WIDTH: 299px; HEIGHT: 24px"><asp:DropDownList id="ddlOrganization" runat="server" Width="280px" SkinID="Unicodeddl" __designer:wfdid="w6" AutoPostBack="True" OnSelectedIndexChanged="ddlOrganization_SelectedIndexChanged">
                    </asp:DropDownList></TD><TD style="WIDTH: 66px; HEIGHT: 24px"><asp:Label id="lblDesignation" runat="server" Text="पद" SkinID="Unicodelbl" __designer:dtid="1688849860264010" __designer:wfdid="w3"></asp:Label></TD><TD style="WIDTH: 171px; HEIGHT: 24px"><asp:DropDownList id="ddlDesignation" runat="server" Width="135px" SkinID="Unicodeddl" __designer:dtid="1688849860264012" __designer:wfdid="w4">
                </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 70px; HEIGHT: 24px"><asp:Label id="lblBranch" runat="server" Width="40px" Text="शाखा" SkinID="Unicodelbl" __designer:wfdid="w7"></asp:Label></TD><TD style="WIDTH: 299px; HEIGHT: 24px"><asp:DropDownList id="ddlBranch" runat="server" Width="280px" SkinID="Unicodeddl" __designer:wfdid="w8" AutoPostBack="True" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged"></asp:DropDownList></TD><TD style="WIDTH: 66px; HEIGHT: 24px"></TD><TD style="WIDTH: 171px; HEIGHT: 24px"></TD></TR><TR><TD style="WIDTH: 70px; HEIGHT: 24px"></TD><TD style="WIDTH: 299px; HEIGHT: 24px"></TD><TD style="WIDTH: 66px; HEIGHT: 24px"></TD><TD style="WIDTH: 171px; HEIGHT: 24px"></TD></TR><TR><TD style="WIDTH: 70px; HEIGHT: 26px"></TD><TD style="WIDTH: 299px; HEIGHT: 26px"></TD><TD style="WIDTH: 66px; HEIGHT: 26px"></TD><TD style="WIDTH: 171px; HEIGHT: 26px"><asp:Button id="btnSearch" onclick="btnSearch_Click" runat="server" Text="Search" SkinID="Normal" __designer:wfdid="w9"></asp:Button> <asp:Button id="btnSearchCancel" onclick="btnSearchCancel_Click" runat="server" Text="Cancel" SkinID="Cancel" __designer:wfdid="w10"></asp:Button></TD></TR><TR><TD colSpan=6><asp:Panel id="pnlUp" runat="server" Width="890px" Height="150px" __designer:wfdid="w11" ScrollBars="Auto"><asp:Label id="lblSearch" runat="server" SkinID="Unicodelbl" __designer:wfdid="w12"></asp:Label><BR /><asp:GridView id="grdEmpSearch" runat="server" Width="850px" __designer:wfdid="w13" OnSelectedIndexChanged="grdEmpSearch_SelectedIndexChanged" AutoGenerateColumns="False" CellPadding="0" GridLines="None" ForeColor="#333333" DataKeyNames="EmpID" OnRowCreated="grdEmpSearch_RowCreated">
<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
<asp:TemplateField ShowHeader="False">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:TemplateField>
<asp:BoundField DataField="EmpID" HeaderText="EmpID">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="FullName" HeaderText="पुरा नाम">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fullGender" HeaderText="लिंग">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="OrgID" HeaderText="OrgID">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="OrgName" HeaderText="कर्यालयको नाम">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DesID" HeaderText="DesID">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DesName" HeaderText="पद">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DesType" HeaderText="DesType">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="PostID" HeaderText="PostID">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="FromDate" HeaderText="FromDate">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="OrgUnitID" HeaderText="OrgUnitID">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="UnitName" HeaderText="शाखा">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="UnitType" HeaderText="UnitType">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="SectionID" HeaderText="SectionID">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="SectionName" HeaderText="फांट">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="UnitFromDate" HeaderText="देखि">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ToDate" HeaderText="ToDate">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Responsibility" HeaderText="जिम्मेवारी">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Action" HeaderText="Action">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:TemplateField><ItemTemplate>
<asp:LinkButton CommandName="Select" runat="server">Select</asp:LinkButton>
</ItemTemplate>
</asp:TemplateField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView></asp:Panel> 
<HR />
</TD></TR></TBODY></TABLE><BR /><ajaxToolkit:CollapsiblePanelExtender id="CollapsiblePnlSearch" runat="server" TargetControlID="pnlassignDiv" __designer:wfdid="w14">
                    </ajaxToolkit:CollapsiblePanelExtender> <asp:Panel id="pnlassignDiv" runat="server" __designer:wfdid="w15"><DIV style="WIDTH: 709%" id="lower" class="divHeader">&nbsp; कर्मचारिको कार्यविभाजन</DIV><TABLE style="WIDTH: 900px"><TBODY><TR><TD style="WIDTH: 80px; HEIGHT: 21px" vAlign=top><asp:Label id="Label3" runat="server" Width="39px" Text="शाखा" SkinID="Unicodelbl" __designer:wfdid="w16"></asp:Label></TD><TD style="WIDTH: 252px; HEIGHT: 21px" vAlign=top><asp:DropDownList id="ddlUnit" runat="server" Width="230px" SkinID="Unicodeddl" __designer:wfdid="w17" AutoPostBack="True" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged"></asp:DropDownList></TD><TD style="WIDTH: 79px; HEIGHT: 21px" vAlign=top><asp:Label id="Label6" runat="server" Width="79px" Text="शाखा प्रमुख" SkinID="Unicodelbl" __designer:wfdid="w18" Visible="False"></asp:Label></TD><TD style="HEIGHT: 21px" vAlign=top><asp:CheckBox id="chkUnitHead" runat="server" SkinID="smallChk" __designer:wfdid="w19" AutoPostBack="True" OnCheckedChanged="chkUnitHead_CheckedChanged" Visible="False"></asp:CheckBox></TD></TR><TR><TD style="WIDTH: 80px" vAlign=top><asp:Label id="Label4" runat="server" Width="75px" Text="जिम्मेवारी" SkinID="Unicodelbl" __designer:wfdid="w20"></asp:Label></TD><TD style="WIDTH: 252px" vAlign=top><asp:TextBox id="txtResponsibility" runat="server" Width="225px" Height="125px" SkinID="Unicodetxt" __designer:wfdid="w21" TextMode="MultiLine"></asp:TextBox></TD><TD style="WIDTH: 79px" vAlign=top><asp:Label id="lblFromDate" runat="server" Width="35px" Text="देखि" SkinID="Unicodelbl" __designer:wfdid="w22"></asp:Label></TD><TD vAlign=top><asp:TextBox id="txtFromDate" runat="server" Width="73px" SkinID="Unicodetxt" __designer:wfdid="w23"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender1" runat="server" TargetControlID="txtFromDate" __designer:wfdid="w25" AutoComplete="False" Mask="9999/99/99" MaskType="Date">
                    </ajaxToolkit:MaskedEditExtender></TD></TR><TR><TD style="WIDTH: 80px" vAlign=top></TD><TD style="WIDTH: 252px" vAlign=top><asp:Button id="btnAdd" onclick="btnAdd_Click" runat="server" Height="22px" Text="+" SkinID="Add" __designer:wfdid="w24"></asp:Button></TD><TD style="WIDTH: 79px" vAlign=top></TD><TD vAlign=top>&nbsp;</TD></TR><TR><TD vAlign=top colSpan=4><asp:Label id="Label1" runat="server" Text="कर्मचारी कार्यविभाजनको विवरण" SkinID="Unicodelbl" __designer:wfdid="w26"></asp:Label> 
<HR />
</TD></TR><TR><TD vAlign=top colSpan=4><ajaxToolkit:CollapsiblePanelExtender id="CollapsiblePanelExtender1" runat="server" TargetControlID="PnlDown" __designer:wfdid="w27">
                    </ajaxToolkit:CollapsiblePanelExtender> <asp:Panel id="PnlDown" runat="server" Width="890px" Height="150px" __designer:wfdid="w28" ScrollBars="Auto"><asp:GridView id="grdEmployeeWork" runat="server" Width="890px" SkinID="Unicodegrd" __designer:wfdid="w29" OnSelectedIndexChanged="grdEmployeeWork_SelectedIndexChanged" AutoGenerateColumns="False" CellPadding="0" GridLines="None" ForeColor="#333333" OnRowCreated="grdEmployeeWork_RowCreated" OnRowDataBound="grdEmployeeWork_RowDataBound">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
                            <Columns>
                                <asp:BoundField DataField="EmpID" HeaderText="EmpID">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="FullName" HeaderText="कर्मचारीको नाम">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="OrgID" HeaderText="OrgID">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="OrgName" HeaderText="कार्यालय">
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
                                <asp:BoundField DataField="FromDate" HeaderText="देखि">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="OrgUnitID" HeaderText="UnitID">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="UnitName" HeaderText="शाखा">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="SectionID" HeaderText="SectionID">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="SectionName" HeaderText="फाँट">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="UnitFromDate" HeaderText="UnitFromDate">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Responsibility" HeaderText="जिम्मेवारी">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="IsHeadOfUnit" HeaderText="शाखा प्रमुख">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="IsHeadOfSection" HeaderText="फाँट प्रमुख">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="EntryBy" HeaderText="Entry By">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Action" HeaderText="Action">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                </asp:BoundField>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" Text="Select" CommandName="Select" CausesValidation="False"
                                            ID="lnkSelectEmpWrkDiv"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
                            <HeaderStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White">
                            </HeaderStyle>
                            <EditRowStyle BackColor="#999999"></EditRowStyle>
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                        </asp:GridView> </asp:Panel> </TD></TR><TR><TD style="HEIGHT: 21px" vAlign=top colSpan=4><asp:Button id="btnSubmit" onclick="btnSubmit_Click" runat="server" Text="Submit" SkinID="Normal" __designer:wfdid="w30"></asp:Button> <asp:Button id="btnCancel" onclick="btnCancel_Click" runat="server" Text="Cancel" SkinID="Cancel" __designer:wfdid="w31"></asp:Button></TD></TR></TBODY></TABLE></asp:Panel> 
</contenttemplate> 
    </asp:UpdatePanel>
</asp:Content>
