<%@ Page AutoEventWireup="true" CodeFile="MeetingMinute.aspx.cs" Inherits="MODULES_OAS_LookUp_MeetingMinute" Language="C#" MaintainScrollPositionOnPostback="true"
    MasterPageFile="~/MODULES/OAS/MasterPage.master" Title="OAS | Meeting Minute" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <br />
    <div style="width: 100%; height: auto">
       <div style="padding-left:20px;">
        <table width="660">
            <tr>
                <td colspan="2" width="140">
                    <asp:Label ID="lblHeading" runat="server" SkinID="UnicodeHeadlbl" Text="मिटिङ्ग माइनुट"></asp:Label></td>
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td width="140">
                </td>
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td width="140">
                    <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="कार्यालय"></asp:Label></td>
                <td colspan="3">
                    <asp:UpdatePanel id="UpdatePanel5" runat="server">
                        <contenttemplate>
                    <asp:DropDownList ID="ddlOrganization" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlOrganization_SelectedIndexChanged" SkinID="Unicodeddl"
                        Width="416px">
                    </asp:DropDownList>
</contenttemplate>
                    </asp:UpdatePanel></td>
            </tr>
            <tr>
                <td width="140">
                    <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="शुरु मिति"></asp:Label></td>
                <td width="200">
                    <asp:UpdatePanel id="UpdatePanel3" runat="server">
                        <contenttemplate>
                    <asp:TextBox ID="txtFromDate" runat="server" SkinID="Unicodetxt" Width="72px"></asp:TextBox>
        <ajaxToolkit:MaskedEditExtender ID="mskFromDate" runat="server" AutoComplete="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtFromDate">
        </ajaxToolkit:MaskedEditExtender></contenttemplate>
                    </asp:UpdatePanel></td>
                <td style="width: 120px; padding-left: 40px">
                    <asp:Label ID="Label3" runat="server" SkinID="Unicodelbl" Text="सम्म मिति"></asp:Label></td>
                <td width="200">
                    <asp:UpdatePanel id="UpdatePanel4" runat="server">
                        <contenttemplate>
        <ajaxToolkit:MaskedEditExtender ID="mskToDate" runat="server" AutoComplete="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtToDate">
        </ajaxToolkit:MaskedEditExtender>
                    <asp:TextBox ID="txtToDate" runat="server" SkinID="Unicodetxt" Width="72px"></asp:TextBox>
</contenttemplate>
                    </asp:UpdatePanel></td>
            </tr>
            <tr>
                <td style="height: 38px" width="140">
                    <asp:Label ID="Label4" runat="server" SkinID="Unicodelbl" Text="कमिटि"></asp:Label></td>
                <td style="height: 38px" width="200">
                    <asp:UpdatePanel id="updCommitte" runat="server">
                        <contenttemplate>
<asp:DropDownList id="ddlCommittee" runat="server" Width="200px" SkinID="Unicodeddl" __designer:wfdid="w53">
                    </asp:DropDownList> 
</contenttemplate>
                        <triggers>
<asp:AsyncPostBackTrigger ControlID="ddlOrganization" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
                    </asp:UpdatePanel></td>
                <td style="width: 120px; height: 38px; padding-left: 40px">
                    <asp:Label ID="Label7" runat="server" SkinID="Unicodelbl" Text="स्थान"></asp:Label></td>
                <td style="height: 38px" width="200">
                    <asp:UpdatePanel id="updVenue" runat="server">
                        <contenttemplate>
<asp:DropDownList id="ddlVenue" runat="server" Width="200px" SkinID="Unicodeddl" __designer:wfdid="w54">
                    </asp:DropDownList> 
</contenttemplate>
                        <triggers>
<asp:AsyncPostBackTrigger ControlID="ddlOrganization" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
                    </asp:UpdatePanel></td>
            </tr>
            <tr>
                <td width="140">
                    <asp:Label ID="Label6" runat="server" SkinID="Unicodelbl" Text="मिटिङको किसिम"></asp:Label></td>
                <td width="200">
                    <asp:UpdatePanel id="UpdatePanel6" runat="server">
                        <contenttemplate>
                    <asp:DropDownList ID="ddlMeetingType" runat="server" SkinID="Unicodeddl" Width="200px">
                    </asp:DropDownList>
</contenttemplate>
                    </asp:UpdatePanel></td>
                <td style="width: 120px; padding-left: 40px">
                    <asp:Label ID="Label5" runat="server" SkinID="Unicodelbl" Text="स्थिति"></asp:Label></td>
                <td width="200">
                    <asp:UpdatePanel id="UpdatePanel7" runat="server">
                        <contenttemplate>
                    <asp:DropDownList ID="ddlStatus" runat="server" SkinID="Unicodeddl" Width="200px">
                    </asp:DropDownList>
</contenttemplate>
                    </asp:UpdatePanel></td>
            </tr>
            <tr>
                <td width="140">
                </td>
                <td width="200">
                </td>
                <td style="padding-left: 40px; width: 120px">
                </td>
                <td width="200">
                    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" SkinID="Normal" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" SkinID="Cancel" OnClick="btnCancel_Click" /></td>
            </tr>
        </table>
        <hr />
        <asp:UpdatePanel id="updMeetingList" runat="server">
            <contenttemplate>
<asp:Label id="lblMeetingCount" runat="server">Please search meeting ...</asp:Label><BR /><asp:Panel id="pnlMeeting" runat="server" Width="100%" Height="250px" ScrollBars="Auto" BorderStyle="None" Visible="False"><asp:GridView id="grdMeeting" runat="server" Width="950px" SkinID="Unicodegrd" ForeColor="#333333" OnSelectedIndexChanged="grdMeeting_SelectedIndexChanged" AutoGenerateColumns="False" GridLines="Vertical" CellPadding="0" OnRowCreated="grdMeeting_RowCreated" OnDataBound="grdMeeting_DataBound">
<FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="OrgID" HeaderText="OrgID"></asp:BoundField>
<asp:BoundField DataField="MeetingID" HeaderText="MeetingID"></asp:BoundField>
<asp:BoundField DataField="Subject" HeaderText="मिटिङको विषय"></asp:BoundField>
<asp:BoundField DataField="MeetingTypeName" HeaderText="मिटिङको किसिम"></asp:BoundField>
<asp:BoundField DataField="Venue" HeaderText="स्थान"></asp:BoundField>
<asp:BoundField DataField="MeetingDate" HeaderText="मिति"></asp:BoundField>
<asp:BoundField DataField="CalledBy" HeaderText="कमिटि"></asp:BoundField>
<asp:BoundField DataField="StartTime" HeaderText="शुरु समय"></asp:BoundField>
<asp:BoundField DataField="EndTime" HeaderText="समाप्ति समय"></asp:BoundField>
<asp:BoundField DataField="Status" HeaderText="स्थिति"></asp:BoundField>
<asp:BoundField DataField="CalledPID" HeaderText="बोलाउने वैयक्ति"></asp:BoundField>
<asp:CommandField ShowSelectButton="True"></asp:CommandField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView></asp:Panel> 
</contenttemplate>
            <triggers>
<asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnSubmit" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
        </asp:UpdatePanel><hr />
        <asp:UpdatePanel id="updMeetingTitle" runat="server">
            <contenttemplate>
<asp:Label id="lblMeetingTitle" runat="server" SkinID="UnicodeHeadlbl" Font-Bold="False"></asp:Label> 
</contenttemplate>
            <triggers>
<asp:AsyncPostBackTrigger ControlID="grdMeeting" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
        </asp:UpdatePanel>
        <asp:UpdatePanel id="UpdatePanel2" runat="server">
            <contenttemplate>
<TABLE width=700><TBODY><TR><TD style="WIDTH: 110px" vAlign=top><asp:Label id="Label8" runat="server" Text="मिटिङ माइनुट" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 580px" vAlign=top>&nbsp;<asp:TextBox id="txtMin" runat="server" Width="380px" Height="60px" TextMode="MultiLine" __designer:wfdid="w51"></asp:TextBox> <asp:Button id="btnAddMinute" onclick="btnAddMinute_Click" runat="server" Text="Add" SkinID="Normal"></asp:Button></TD></TR><TR><TD colSpan=2><asp:Panel id="pnlMinute" runat="server" Width="540px" Height="150px" ScrollBars="Auto"><asp:GridView id="grdMinute" runat="server" Width="500px" SkinID="Unicodegrd" ForeColor="#333333" OnSelectedIndexChanged="grdMinute_SelectedIndexChanged" OnRowCreated="grdMinute_RowCreated" CellPadding="0" GridLines="Vertical" AutoGenerateColumns="False" OnRowDeleting="grdMinute_RowDeleting">
<FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="OrgID" HeaderText="OrgID"></asp:BoundField>
<asp:BoundField DataField="MeetingID" HeaderText="MeetingID"></asp:BoundField>
<asp:BoundField DataField="MinuteID" HeaderText="MinuteID"></asp:BoundField>
<asp:BoundField DataField="Minute" HeaderText="मिटिङको माइनट"></asp:BoundField>
<asp:BoundField DataField="EntryBy" HeaderText="EntryBy"></asp:BoundField>
<asp:BoundField DataField="Action" HeaderText="Action"></asp:BoundField>
<asp:CommandField ShowSelectButton="True">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:CommandField>
<asp:CommandField ShowDeleteButton="True">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:CommandField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </asp:Panel> </TD></TR></TBODY></TABLE>
</contenttemplate>
            <triggers>
<asp:AsyncPostBackTrigger ControlID="grdMeeting" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="grdMeeting" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
        </asp:UpdatePanel><br />
        &nbsp;<asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" SkinID="Normal" />
        <asp:Button ID="btnCancelSubmit" runat="server" OnClick="btnCancelSubmit_Click" Text="Cancel" SkinID="Cancel" /><br />
        <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
        <ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior"
            DropShadow="True" PopupControlID="programmaticPopup" PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
            TargetControlID="hiddenTargetControlForModalPopup">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none; width: 350px; padding: 10px">
            <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD; border: solid 1px Gray; color: Black; text-align: center;">
                Save Status
            </asp:Panel>
            <asp:UpdatePanel id="UpdatePanel1" runat="server">
                <contenttemplate>
<asp:Label id="lblStatusMessage" runat="server" CssClass="simplelabel" Text="Label" ForeColor="Black" EnableTheming="False"></asp:Label> 
</contenttemplate>
            </asp:UpdatePanel>
            <br />
            <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click" Text="OK" Width="58px" />
            <br />
        </asp:Panel>
        </div>
    </div>
</asp:Content>
