<%@ Page Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master" AutoEventWireup="true" CodeFile="EmployeeAttendance.aspx.cs" Inherits="MODULES_PMS_Forms_EmployeeAttendance" Title="PMS | Employee Attendance" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <asp:ScriptManager runat="server" ID="sct">
    </asp:ScriptManager>
    <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
    <ajaxtoolkit:modalpopupextender id="programmaticModalPopup" runat="server" backgroundcssclass="modalBackground"
        behaviorid="programmaticModalPopupBehavior" dropshadow="True" popupcontrolid="programmaticPopup"
        popupdraghandlecontrolid="programmaticPopupDragHandle" repositionmode="RepositionOnWindowScroll"
        targetcontrolid="hiddenTargetControlForModalPopup"></ajaxtoolkit:modalpopupextender>
    <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="padding-right: 10px;
        display: none; padding-left: 10px; padding-bottom: 10px; width: 350px; padding-top: 10px">
        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="border-right: gray 1px solid;
            border-top: gray 1px solid; border-left: gray 1px solid; cursor: move; color: black;
            border-bottom: gray 1px solid; background-color: #dddddd; text-align: center">
            Status
        </asp:Panel>
        <asp:UpdatePanel id="UpdatePanel3" runat="server">
            <contenttemplate>
<BR /><asp:Label id="lblStatusMessage" runat="server" Height="19px" Text="Label"></asp:Label> 
</contenttemplate>
        </asp:UpdatePanel>
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
            Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    &nbsp;&nbsp;&nbsp;&nbsp;<br />
    <table style="width: 900px">
        <tr>
            <td colspan="1" style="width: 346113px" valign="top">
            </td>
            <td colspan="2" valign="top">
                <asp:Label ID="Label3" runat="server" SkinID="UnicodeHeadlbl" Text="कर्मचारीको हाजिर, विदाको विवरण"></asp:Label></td>
            <td style="width: 55px" valign="top">
            </td>
            <td style="width: 170px" valign="top">
            </td>
            <td valign="top">
            </td>
            <td valign="top">
            </td>
        </tr>
        <tr>
            <td style="width: 346113px" valign="top">
            </td>
            <td style="width: 70px" valign="top">
                <asp:Label ID="Label7" runat="server" SkinID="Unicodelbl" Text="कार्यालय" Width="65px"></asp:Label></td>
            <td style="width: 331px" valign="top">
                <asp:DropDownList ID="ddlOrganization" runat="server" AutoPostBack="True" SkinID="Unicodeddl"
                    Width="290px">
                </asp:DropDownList></td>
            <td style="width: 55px" valign="top">
                <asp:Label ID="lblDesignation" runat="server" SkinID="Unicodelbl" Text="पद"></asp:Label></td>
            <td style="width: 170px" valign="top">
                <asp:DropDownList ID="ddlDesignation" runat="server" SkinID="Unicodeddl" Width="130px">
                </asp:DropDownList></td>
            <td valign="top">
                <asp:Label ID="lblOrgUnit" runat="server" SkinID="Unicodelbl" Text="शाखा" Width="36px"></asp:Label></td>
            <td valign="top">
                <asp:DropDownList ID="ddlorgUnit" runat="server" SkinID="Unicodeddl" Width="150px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 346113px; height: 24px" valign="top">
            </td>
            <td style="width: 70px; height: 24px" valign="top">
                <asp:Label ID="Label8" runat="server" SkinID="Unicodelbl" Text="बर्ष " Width="21px"></asp:Label></td>
            <td style="width: 331px; height: 24px" valign="top">
                <asp:UpdatePanel id="UpdatePanel2" runat="server">
                    <contenttemplate>
<asp:DropDownList id="ddlYear" runat="server" Width="100px" SkinID="Unicodeddl" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged1">
                                    </asp:DropDownList>
</contenttemplate>
                </asp:UpdatePanel></td>
            <td style="width: 55px; height: 24px" valign="top">
                <asp:Label ID="Label9" runat="server" SkinID="Unicodelbl" Text="महिना" Width="50px"></asp:Label></td>
            <td style="width: 170px; height: 24px" valign="top">
                <asp:UpdatePanel id="UpdatePanel5" runat="server">
                    <contenttemplate>
<asp:DropDownList id="ddlMonth" runat="server" Width="130px" SkinID="Unicodeddl" AutoPostBack="True" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
                        <asp:ListItem>छान्नुहोस्</asp:ListItem>
                        <asp:ListItem Value="01">बैशाख</asp:ListItem>
                        <asp:ListItem Value="02">जेष्ठ</asp:ListItem>
                        <asp:ListItem Value="03">असाढ</asp:ListItem>
                        <asp:ListItem Value="04">साउन</asp:ListItem>
                        <asp:ListItem Value="05">भाद्र</asp:ListItem>
                        <asp:ListItem Value="06">असोज</asp:ListItem>
                        <asp:ListItem Value="07">कात्तिक</asp:ListItem>
                        <asp:ListItem Value="08">मंसिर</asp:ListItem>
                        <asp:ListItem Value="09">पुष</asp:ListItem>
                        <asp:ListItem Value="10">माघ</asp:ListItem>
                        <asp:ListItem Value="11">फागुन</asp:ListItem>
                        <asp:ListItem Value="12">चैत</asp:ListItem>
                    </asp:DropDownList>
</contenttemplate>
                </asp:UpdatePanel></td>
            <td style="height: 24px" valign="top">
            </td>
            <td style="height: 24px" valign="top">
            </td>
        </tr>
        <tr>
            <td style="width: 346113px; height: 24px" valign="top">
            </td>
            <td style="width: 70px; height: 24px" valign="top">
            </td>
            <td style="width: 331px; height: 24px" valign="top">
            </td>
            <td style="width: 55px; height: 24px" valign="top">
            </td>
            <td style="width: 170px; height: 24px" valign="top">
            </td>
            <td style="height: 24px" valign="top">
            </td>
            <td style="height: 24px" valign="top">
                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" SkinID="Normal"
                    Text="Search" /><asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click"
                        SkinID="Cancel" Text="Cancel" /></td>
        </tr>
        <tr>
            <td colspan="1" style="width: 346113px; height: 24px" valign="top">
            </td>
            <td colspan="6" style="height: 24px" valign="top">
                <hr />
            </td>
        </tr>
        <tr>
            <td style="width: 346113px; height: 24px" valign="top">
            </td>
            <td style="width: 70px; height: 24px" valign="top">
                <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="Export" Width="49px"></asp:Label></td>
            <td style="width: 331px; height: 24px" valign="top">
                <asp:DropDownList ID="ddlExportWhat" runat="server" SkinID="Unicodeddl" Width="182px">
                    <asp:ListItem Value="०">छान्नुहोस्</asp:ListItem>
                    <asp:ListItem Value="1">Employee Attendance</asp:ListItem>
                    <asp:ListItem Value="2">Attendance Summary</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 55px; height: 24px" valign="top">
                <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="Export To" Width="65px"></asp:Label></td>
            <td style="width: 170px; height: 24px" valign="top">
                <asp:DropDownList ID="ddlExportOption" runat="server" Height="25px" SkinID="Unicodeddl"
                    Width="130px">
                    <asp:ListItem Selected="True" Value="0">छान्नुहोस्</asp:ListItem>
                    <asp:ListItem Value="1">Export To Word</asp:ListItem>
                    <asp:ListItem Value="2">Export To Excel</asp:ListItem>
                </asp:DropDownList></td>
            <td colspan="2" style="height: 24px" valign="top">
                <asp:Button ID="btnExportData" runat="server" Height="25px" OnClick="btnExportData_Click"
                    SkinID="Normal" Text="Export" /></td>
        </tr>
        <tr>
            <td colspan="1" style="width: 346113px; height: 150px" valign="top">
            </td>
            <td colspan="2" style="height: 150px" valign="top">
                <asp:Panel ID="Panel2" runat="server" GroupingText="Symbols Used" Height="147px"
                    Width="178px">
                    <asp:Image ID="Image1" runat="server" Height="147px" ImageUrl="~/MODULES/COMMON/Images/menu.JPG"
                        Width="178px" /></asp:Panel>
                &nbsp;
            </td>
            <td style="width: 55px; height: 150px" valign="top">
            </td>
            <td colspan="3" style="height: 150px" valign="top">
                <table>
                    <tr>
                        <td style="width: 100px">
                            <asp:LinkButton ID="lnkSummary" runat="server" Font-Bold="True" Font-Size="Large"
                                OnClick="lnkSummary_Click" Width="127px">View Summary</asp:LinkButton></td>
                        <td style="width: 100px">
                            <asp:Image ID="Image2" runat="server" Height="32px" ImageUrl="~/MODULES/COMMON/Images/report_icon.gif"
                                Width="33px" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="1" style="width: 346113px; height: 24px" valign="top">
            </td>
            <td colspan="6" style="height: 24px" valign="top">
                <br />
                <hr />
                <asp:UpdatePanel id="UpdatePanel4" runat="server">
                    <contenttemplate>
<asp:Panel id="Panel1" runat="server" Width="900px" Height="200px" ScrollBars="Auto"><asp:GridView id="grdAttendance" runat="server" Width="1350px" SkinID="Unicodegrd" AutoGenerateColumns="False" GridLines="None" CellPadding="0" ForeColor="#333333" OnRowDataBound="grdAttendance_RowDataBound">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:TemplateField><HeaderTemplate>
क्र.सं.
</HeaderTemplate>
<ItemTemplate>
<%# Container.DataItemIndex + 1 %>
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="FullName" HeaderText="कर्मचारीको पुरा नाम थर">
<ItemStyle Width="250px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="250px"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="01" HeaderText="१">
<ItemStyle Width="20px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="20px" HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="02" HeaderText="२">
<ItemStyle Width="20px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="20px" HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="03" HeaderText="३">
<ItemStyle Width="20px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="20px" HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="04" HeaderText="४">
<ItemStyle Width="20px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="20px" HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="05" HeaderText="५">
<ItemStyle Width="20px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="20px" HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="06" HeaderText="६">
<ItemStyle Width="20px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="20px" HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="07" HeaderText="७">
<ItemStyle Width="20px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="20px" HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="08" HeaderText="८">
<ItemStyle Width="20px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="20px" HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="09" HeaderText="९">
<ItemStyle Width="20px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="20px" HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="10" HeaderText="१०">
<ItemStyle Width="20px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="20px" HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="11" HeaderText="११">
<ItemStyle Width="20px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="20px" HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="12" HeaderText="१२">
<ItemStyle Width="20px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="20px" HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="13" HeaderText="१३">
<ItemStyle Width="20px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="20px" HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="14" HeaderText="१४">
<ItemStyle Width="20px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="20px" HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="15" HeaderText="१५">
<ItemStyle Width="20px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="20px" HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="16" HeaderText="१६">
<ItemStyle Width="20px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="20px" HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="17" HeaderText="१७">
<ItemStyle Width="20px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="20px" HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="18" HeaderText="१८">
<ItemStyle Width="20px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="20px" HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="19" HeaderText="१९">
<ItemStyle Width="20px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="20px" HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="20" HeaderText="२०">
<ItemStyle Width="20px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="20px" HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="21" HeaderText="२१">
<ItemStyle Width="20px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="20px" HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="22" HeaderText="२२">
<ItemStyle Width="20px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="20px" HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="23" HeaderText="२३">
<ItemStyle Width="20px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="20px" HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="24" HeaderText="२४">
<ItemStyle Width="20px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="20px" HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="25" HeaderText="२५">
<ItemStyle Width="20px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="20px" HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="26" HeaderText="२६">
<ItemStyle Width="20px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="20px" HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="27" HeaderText="२७">
<ItemStyle Width="20px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="20px" HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="28" HeaderText="२८">
<ItemStyle Width="20px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="20px" HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="29" HeaderText="२९">
<ItemStyle Width="20px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="20px" HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="30" HeaderText="३०">
<ItemStyle Width="20px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="20px" HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="31" HeaderText="३१">
<ItemStyle Width="20px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="20px" HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="32" HeaderText="३२">
<ItemStyle Width="20px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="20px" HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="WorkingDays" HeaderText="काम गर्ने दिन">
<ItemStyle Width="100px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="100px"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="Leave" HeaderText="विदा ">
<ItemStyle Width="100px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="100px"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="Holiday" HeaderText="साधारण विदा">
<ItemStyle Width="100px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="100px"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="Weekend" HeaderText="शनिवार">
<ItemStyle Width="100px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="100px"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="Absent" HeaderText="अनुपस्थित"></asp:BoundField>
<asp:BoundField DataField="Present" HeaderText="उपस्थित"></asp:BoundField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView></asp:Panel> 
</contenttemplate>
                    <triggers>
<asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
                </asp:UpdatePanel>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="1" style="width: 346113px; height: 24px" valign="top">
            </td>
            <td colspan="2" style="height: 24px" valign="top">
            </td>
            <td style="width: 55px; height: 24px" valign="top">
            </td>
            <td colspan="3" style="height: 24px" valign="top">
            </td>
        </tr>
        <tr>
            <td colspan="1" style="width: 346113px; height: 24px" valign="top">
            </td>
            <td colspan="6" style="height: 24px" valign="top">
                <asp:UpdatePanel id="UpdatePanel1" runat="server">
                    <contenttemplate>
<asp:Panel id="PnlSummary" runat="server" Width="900px" Height="200px" ScrollBars="Auto"><asp:GridView id="grdAttendanceSummary" runat="server" Width="900px" ForeColor="#333333" CellPadding="0" GridLines="None" AutoGenerateColumns="False">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:TemplateField><HeaderTemplate>
क्र.सं.
</HeaderTemplate>
<ItemTemplate>
<%# Container.DataItemIndex + 1 %>
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="EmpFullName" HeaderText="र्कमचारीको पुरा नाम">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="TotDays" HeaderText="जम्मा दिन">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="WorkingDays" HeaderText="काम गर्ने दिन">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Present" HeaderText="काम गरेको दिन">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Saturday" HeaderText="शनिबार">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Leave" HeaderText="जम्मा बिदा लिएको">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="AnnualHoliday" HeaderText="जम्मा बिदा">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Absent" HeaderText="अनुपस्थित">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView></asp:Panel> 
</contenttemplate>
                    <triggers>
<asp:AsyncPostBackTrigger ControlID="lnkSummary" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
                </asp:UpdatePanel></td>
        </tr>
    </table>
    <br />
    &nbsp;<br />
</asp:Content>

