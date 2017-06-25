<%@ Page Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" AutoEventWireup="true" CodeFile="OrganizationCaseRegTypecheckList.aspx.cs" Inherits="MODULES_CMS_LookUp_OrganizationCaseRegTypecheckList" Title="CMS | Organization Case Registration Type Checklist" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" src="../../COMMON/JS/Validation.js" type="text/javascript"></script>
        <script language="javascript" src="../../COMMON/JS/Validation.js" type="text/javascript"></script>
    <script language="javascript" src="../../COMMON/JS/DateValidator.js" type="text/javascript"></script>
    <script language="javascript" src="../../COMMON/JS/EnglishDateValidator.js" type="text/javascript"></script>


    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
    <ajaxtoolkit:modalpopupextender id="programmaticModalPopup" runat="server" backgroundcssclass="modalBackground"
        behaviorid="programmaticModalPopupBehavior" dropshadow="True" popupcontrolid="programmaticPopup"
        popupdraghandlecontrolid="programmaticPopupDragHandle" repositionmode="RepositionOnWindowScroll"
        targetcontrolid="hiddenTargetControlForModalPopup">
        </ajaxtoolkit:modalpopupextender>
    <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none;
        width: 350px; padding: 10px">
        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD;
            border: solid 1px Gray; color: Black; text-align: center;">
            Save Status
        </asp:Panel>
        <br />
        <asp:UpdatePanel id="UpdatePanel2" runat="server">
            <contenttemplate>
        <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
</contenttemplate>
        </asp:UpdatePanel>
        <br />
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
            Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
<TABLE style="WIDTH: 825px"><TBODY><TR><TD style="WIDTH: 400px"><asp:Label id="Label1" runat="server" Text="कार्यालयहरु" SkinID="UnicodeHeadlbl"></asp:Label></TD><TD style="WIDTH: 403px"><asp:Label id="Label2" runat="server" Text="मुदाको किसिमहरु" SkinID="UnicodeHeadlbl"></asp:Label></TD><TD style="WIDTH: 403px"><asp:Label id="Label3" runat="server" Text="दर्ताको प्रकारहरु" SkinID="UnicodeHeadlbl"></asp:Label></TD><TD style="WIDTH: 405px"><asp:Label id="Label4" runat="server" Text="चेकलिसटहरु" SkinID="UnicodeHeadlbl"></asp:Label></TD></TR><TR><TD vAlign=top align=left><asp:ListBox id="lstOrganization" runat="server" Width="225px" Height="300px" SkinID="Unicodelst" OnSelectedIndexChanged="lstOrganization_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox></TD><TD vAlign=top align=left><asp:ListBox id="lstCaseType" runat="server" Width="225px" Height="300px" SkinID="Unicodelst" OnSelectedIndexChanged="lstCaseType_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox></TD><TD vAlign=top align=left><asp:Panel id="Panel1" runat="server" Width="225px" Height="300px"><asp:ListBox id="lstRegistrationType" runat="server" Width="225px" Height="300px" SkinID="Unicodelst" OnSelectedIndexChanged="lstRegistrationType_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox></asp:Panel> </TD><TD vAlign=top align=left><asp:Panel id="Panel2" runat="server" Width="225px" Height="300px"><asp:GridView id="grdCheckListType" runat="server" SkinID="Unicodegrd" GridLines="None" ForeColor="#333333" CellPadding="4" AutoGenerateColumns="False" OnRowDataBound="grdCheckListType_RowDataBound">
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelect" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="CheckListID" HeaderText="CheckList ID" />
                                    <asp:BoundField DataField="CheckListName" HeaderText="CheckList Name" />
                                    <asp:BoundField HeaderText="Active" />
                                </Columns>
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <EditRowStyle BackColor="#999999" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            </asp:GridView> </asp:Panel> &nbsp; </TD></TR><TR><TD style="WIDTH: 400px"></TD><TD style="WIDTH: 403px"></TD><TD style="WIDTH: 403px"></TD><TD style="WIDTH: 405px"><asp:Button id="btnSubmit" runat="server" Text="Submit" SkinID="Normal" OnClick="btnSubmit_Click"></asp:Button> <asp:Button id="btnCancel" runat="server" Text="Cancel" SkinID="Cancel" OnClick="btnCancel_Click"></asp:Button></TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <br />
</asp:Content>

