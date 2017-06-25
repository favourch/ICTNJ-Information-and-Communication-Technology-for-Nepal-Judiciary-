<%@ Page AutoEventWireup="true" CodeFile="TippaniSearch.aspx.cs" Inherits="MODULES_OAS_Tippani_TippaniSearch" Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="Winthusiasm.HtmlEditor" Namespace="Winthusiasm.HtmlEditor" TagPrefix="SJ" %>

<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager id="SM" runat="server">
    </asp:ScriptManager>

    <script language="javascript" src="../../COMMON/JS/Validation.js"></script>

    <script language="javascript" src="../../COMMON/JS/DateValidator.js"></script>

    <div style="width: 100%; height: auto">
        <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
        <ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground" DropShadow="True" PopupControlID="programmaticPopup"
            PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForModalPopup">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none; width: 350px; padding: 10px">
            <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD; border: solid 1px Gray; color: Black; text-align: center;">
                Save Status
            </asp:Panel>
            <asp:UpdatePanel id="UpdatePanel1" runat="server">
                <contenttemplate>
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
</contenttemplate>
            </asp:UpdatePanel>
            <br />
            <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click" Text="OK" Width="58px" />
            <br />
        </asp:Panel>
        <ajaxToolkit:MaskedEditExtender ID="mskFromDate" runat="server" AutoComplete="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtFromDate">
        </ajaxToolkit:MaskedEditExtender>
        <ajaxToolkit:MaskedEditExtender ID="mskToDate" runat="server" AutoComplete="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtToDate">
        </ajaxToolkit:MaskedEditExtender>
        <br />
        <table cellpadding="2" cellspacing="2" width="600">
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="कार्यालय"></asp:Label></td>
                <td colspan="3">
                    <asp:DropDownList ID="ddlOrg_Rqd" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlOrg_Rqd_SelectedIndexChanged" SkinID="Unicodeddl" ToolTip="कार्यालय"
                        Width="250px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label5" runat="server" SkinID="Unicodelbl" Text="पद"></asp:Label></td>
                <td colspan="3">
                    <asp:UpdatePanel id="updPost" runat="server">
                        <contenttemplate>
<asp:DropDownList id="ddlPost" runat="server" Width="250px" SkinID="Unicodeddl" AppendDataBoundItems="True"></asp:DropDownList> 
</contenttemplate>
                        <triggers>
<asp:AsyncPostBackTrigger ControlID="ddlOrg_Rqd" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
                    </asp:UpdatePanel></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="टिप्पणीको प्रकार"></asp:Label></td>
                <td colspan="3">
                    <asp:UpdatePanel id="updTippaniType" runat="server">
                        <contenttemplate>
                    <asp:DropDownList ID="ddlTipaniSubject_Rqd" runat="server" SkinID="Unicodeddl" ToolTip="टिप्पणीको प्रकार" Width="250px">
                    </asp:DropDownList>
</contenttemplate>
                        <triggers>
<asp:AsyncPostBackTrigger ControlID="ddlOrg_Rqd" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
                    </asp:UpdatePanel></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label3" runat="server" SkinID="Unicodelbl" Text="अवधि देखि"></asp:Label></td>
                <td style="width: 200px">
                    <asp:TextBox ID="txtFromDate" runat="server" SkinID="Unicodetxt" Width="120px"></asp:TextBox></td>
                <td style="width: 100px">
                    <asp:Label ID="Label4" runat="server" SkinID="Unicodelbl" Text="अवधि सम्म"></asp:Label></td>
                <td style="width: 200px">
                    <asp:TextBox ID="txtToDate" runat="server" SkinID="Unicodetxt" Width="120px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label7" runat="server" SkinID="Unicodelbl" Text="स्थिति"></asp:Label></td>
                <td style="width: 200px">
                    <asp:DropDownList ID="ddlStatus" runat="server" SkinID="Unicodeddl" Width="124px">
                    </asp:DropDownList></td>
                <td style="width: 100px">
                    <asp:Label ID="Label6" runat="server" SkinID="Unicodelbl" Text="पहिलो नाम"></asp:Label></td>
                <td style="width: 200px">
                    <asp:TextBox ID="txtFirstName" runat="server" SkinID="Unicodetxt" Width="120px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 200px">
                    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" OnClientClick="return validate(1);" SkinID="Normal" Text="Search" />&nbsp;<asp:Button
                        ID="Button1" runat="server" OnClick="Button1_Click" SkinID="Cancel" Text="Test" /></td>
                <td style="width: 100px">
                </td>
                <td style="width: 200px">
                    &nbsp;</td>
            </tr>
        </table>
        <asp:UpdatePanel id="updTippaniList" runat="server">
            <contenttemplate>
<TABLE width=800><TBODY><TR><TD style="WIDTH: 400px"><asp:Label id="lblTippaniCount" runat="server" SkinID="Unicodelbl"></asp:Label> <asp:HiddenField id="hdnIndex" runat="server" Value="0"></asp:HiddenField> <asp:HiddenField id="hdnTotalRecord" runat="server"></asp:HiddenField></TD><TD style="WIDTH: 400px" align=right><asp:LinkButton id="lnkBack" onclick="lnkBack_Click" runat="server" SkinID="Tippani" Visible="False"><< Back</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:LinkButton id="lnkNext" onclick="lnkNext_Click" runat="server" SkinID="Tippani" Visible="False">Next >></asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label id="lblPaging" runat="server" SkinID="Unicodelbl"></asp:Label></TD></TR></TBODY></TABLE><asp:GridView id="grdTippaniLst" runat="server" Width="800px" SkinID="Unicodegrd" OnSelectedIndexChanged="grdTippaniLst_SelectedIndexChanged" AutoGenerateColumns="False" GridLines="None" CellPadding="0" ForeColor="#333333" OnRowDataBound="grdTippaniLst_RowDataBound" OnDataBound="grdTippaniLst_DataBound" OnRowDeleted="grdTippaniLst_RowDeleted">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="TippaniFromOrgID" HeaderText="OrgID"></asp:BoundField>
<asp:BoundField DataField="TippaniID" HeaderText="TipID"></asp:BoundField>
<asp:BoundField DataField="ProcessByID" HeaderText="ProcessByID"></asp:BoundField>
<asp:BoundField DataField="ProcessOn" HeaderText="टिप्पणीको मिति"></asp:BoundField>
<asp:BoundField DataField="TippaniByOrgName" HeaderText="ब्यक्तिको कार्यालय"></asp:BoundField>
<asp:BoundField DataField="TippaniByDesName" HeaderText="ब्यक्तिको पद"></asp:BoundField>
<asp:BoundField DataField="ProcessBy" HeaderText="ब्यक्तिको नाम"></asp:BoundField>
<asp:BoundField DataField="StatusName" HeaderText="स्थिति"></asp:BoundField>
<asp:CommandField ShowSelectButton="True"></asp:CommandField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> 
</contenttemplate>
            <triggers>
<asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
