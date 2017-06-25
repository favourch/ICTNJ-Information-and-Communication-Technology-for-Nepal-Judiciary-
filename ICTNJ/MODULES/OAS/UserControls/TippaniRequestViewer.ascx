<%@ Control AutoEventWireup="true" CodeFile="TippaniRequestViewer.ascx.cs" Inherits="MODULES_OAS_UserControls_TippaniRequestViewer" Language="C#" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<div style="width: 100%; height: auto">
    <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground" DropShadow="True" PopupControlID="programmaticPopup"
        PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForModalPopup">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none; width: 350px; padding: 10px">
        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD; border: solid 1px Gray; color: Black; text-align: center;">
            Save Status
        </asp:Panel>
        <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label><br />
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click" Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    <table style="width: 925px">
        <tr>
            <td style="width: 100px">
                &nbsp;&nbsp; <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="कार्यालय"></asp:Label></td>
            <td style="width: 225px">
                <asp:DropDownList ID="ddlOrg" runat="server" SkinID="Unicodeddl" Width="220px" AutoPostBack="True" OnSelectedIndexChanged="ddlOrg_SelectedIndexChanged">
                </asp:DropDownList></td>
            <td style="width: 75px">
                &nbsp; &nbsp; <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="शाखा"></asp:Label></td>
            <td style="width: 155px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlUnit" runat="server" SkinID="Unicodeddl" Width="150px">
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlOrg" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td style="width: 60px">
                &nbsp; &nbsp; &nbsp; &nbsp;
            </td>
            <td style="width: 155px">
                </td>
            <td style="width: 135px">
                </td>
        </tr>
        <tr>
            <td style="width: 100px">
                &nbsp;&nbsp;
                <asp:Label ID="Label3" runat="server" SkinID="Unicodelbl" Text="स्तिथि"></asp:Label></td>
            <td style="width: 225px">
                <asp:DropDownList ID="ddlStatus" runat="server" SkinID="Unicodeddl" Width="220px">
                </asp:DropDownList></td>
            <td style="width: 75px">
                &nbsp;
                <asp:Label ID="Label4" runat="server" SkinID="Unicodelbl" Text="प्राथमिक्ता"></asp:Label></td>
            <td style="width: 155px">
                <asp:DropDownList ID="ddlPriority" runat="server" Width="150px">
                </asp:DropDownList></td>
            <td colspan="3">
                <asp:LinkButton ID="lnkSearch" runat="server" SkinID="Tippani" OnClick="lnkSearch_Click">Click here to Search</asp:LinkButton></td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td style="width: 7%">
            </td>
            <td style="width: 93%">
                <asp:Label ID="lblRequestCount" runat="server" SkinID="UnicodeHeadlbl" Text="Request Count"></asp:Label><asp:HiddenField ID="hdnForm" runat="server" Value="0" />
                <asp:HiddenField ID="hdnIndex" runat="server" Value="0" />
                <asp:HiddenField ID="hdnTotalRecord" runat="server" />
            </td>
        </tr>
        <tr>
            <td rowspan="2" style="width: 7%" valign="top">
                <table cellpadding="0" cellspacing="0" width="100">
                    <tr style="background-image: url(../../COMMON/Images/tree_green_bg.gif)">
                        <td align="center" style="width: 100px; height: 25px" valign="middle">
                            .:
                            <asp:Label ID="Label10" runat="server" Font-Underline="True" SkinID="Unicodelbl" Text="मिनु लिस्ट"></asp:Label></td>
                    </tr>
                    <tr style="background-image: url(../../COMMON/Images/tree_green_bg.gif)">
                        <td style="width: 100px; height: 25px" valign="middle">
                            &nbsp;<img src="../Images/inbox.jpeg" align="absMiddle" height="20" title="inbox" />
                            <asp:LinkButton ID="lnkSender" runat="server" SkinID="Tippani" Width="70px">Inbox</asp:LinkButton></td>
                    </tr>
                    <tr style="background-image: url(../../COMMON/Images/tree_green_bg.gif)">
                        <td style="width: 100px; height: 25px" valign="middle">
                            &nbsp;<img src="../Images/outbox.jpeg" align="absMiddle" height="18" title="outbox" />
                            <asp:LinkButton ID="lnkReceiver" runat="server" SkinID="Tippani" Width="70px">Sent</asp:LinkButton></td>
                    </tr>
                    <tr style="background-image: url(../../COMMON/Images/tree_green_bg.gif)">
                        <td style="width: 100px; height: 25px" valign="middle">
                        </td>
                    </tr>
                    <tr style="background-image: url(../../COMMON/Images/tree_green_bg.gif)">
                        <td style="width: 100px; height: 25px" valign="middle">
                        </td>
                    </tr>
                    <tr style="background-image: url(../../COMMON/Images/tree_green_bg.gif)">
                        <td style="width: 100px; height: 25px" valign="middle">
                        </td>
                    </tr>
                    <tr style="background-image: url(../../COMMON/Images/tree_green_bg.gif)">
                        <td style="width: 100px; height: 25px" valign="middle">
                        </td>
                    </tr>
                    <tr style="background-image: url(../../COMMON/Images/tree_green_bg.gif)">
                        <td style="width: 100px; height: 25px" valign="middle">
                        </td>
                    </tr>
                    <tr style="background-image: url(../../COMMON/Images/tree_green_bg.gif)">
                        <td style="width: 100px; height: 25px" valign="middle">
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 93%" valign="top">
                <asp:Panel ID="pnlRequest" runat="server" BackColor="WhiteSmoke" Height="200px" ScrollBars="Auto" Width="100%">
                    <asp:GridView ID="grdRequest" runat="server" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333" OnDataBound="grdRequest_DataBound" OnRowDataBound="grdRequest_RowDataBound"
                        SkinID="Plaingrd" Width="100%">
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="OrgID" HeaderText="OrgID" />
                            <asp:BoundField DataField="TippaniID" HeaderText="TippaniID" />
                            <asp:BoundField DataField="TippaniProcessID" HeaderText="ProcessID" />
                            <asp:BoundField DataField="ProcessByID" HeaderText="ProcessByID" />
                            <asp:BoundField DataField="ProcessToID" HeaderText="ProcessToID" />
                            <asp:BoundField DataField="TippaniSubjectID" HeaderText="TippaniSubjectID" />
                            <asp:BoundField DataField="IsChannelPerson" HeaderText="IsChannelPerson" />
                            <asp:BoundField DataField="ProcessStatusName" HeaderText="ProcessStatusName" />
                            <asp:BoundField DataField="TippaniSubject" HeaderText="टिप्पणी को बिषय" />
                            <asp:BoundField DataField="ProcessBy" HeaderText="पठाउने ब्यक्त्तिको नाम" />
                            <asp:BoundField DataField="ProcessOn" HeaderText="पठाएको मिति" />
                            <asp:BoundField DataField="ProcessTo" HeaderText="पाउने ब्यक्त्तिको नाम" />
                            <asp:BoundField DataField="TippaniStatusName" HeaderText="टिप्पणीको स्तिथि">
                                <ItemStyle Font-Bold="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TippaniStatusID" />
                            <asp:BoundField DataField="SenderOrgID" HeaderText="SenOrgID" />
                            <asp:BoundField DataField="SenderUnitID" HeaderText="SecUnitID" />
                            <asp:BoundField DataField="SenderOrgName" HeaderText="पठाउने कार्यालय" />
                            <asp:BoundField DataField="SenderUnitName" HeaderText="पठाउने शाखा" />
                            <asp:BoundField DataField="ReceiverOrgID" HeaderText="RecOrgID" />
                            <asp:BoundField DataField="ReceiverUnitID" HeaderText="RecUnitID" />
                            <asp:BoundField DataField="ReceiverOrgName" HeaderText="पाउने कार्यालय" />
                            <asp:BoundField DataField="ReceiverUnitName" HeaderText="पाउने शाखा" />
                            <asp:CommandField ShowSelectButton="True" />
                        </Columns>
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <EditRowStyle BackColor="#999999" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="width: 93%; height: 21px" valign="top">
                <asp:LinkButton ID="lnkBack" runat="server" OnClick="lnkBack_Click" SkinID="Tippani"><< Back</asp:LinkButton>
                &nbsp; &nbsp;
                <asp:LinkButton ID="lnkNext" runat="server" OnClick="lnkNext_Click" SkinID="Tippani">Next >></asp:LinkButton>
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                <asp:Label ID="lblPaging" runat="server" SkinID="Unicodelbl"></asp:Label></td>
        </tr>
    </table>
</div>
