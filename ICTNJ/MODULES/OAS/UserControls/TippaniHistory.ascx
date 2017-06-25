<%@ Control AutoEventWireup="true" CodeFile="TippaniHistory.ascx.cs" Inherits="MODULES_OAS_UserControls_TippaniHistory" Language="C#" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<script language="javascript" src="../../COMMON/Collapse Panel/jquery.js"></script>

<script type="text/javascript">
$(document).ready(function(){
	//hide the all of the element with class msg_body
	$(".msg_body").hide();
	//toggle the componenet with class msg_body
	$(".msg_head").click(function(){
		$(this).next(".msg_body").slideToggle(600);
	});
});
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
    <asp:DataList ID="dLstHistory" runat="server" DataKeyField="TippaniProcessID" OnItemDataBound="dLstHistory_ItemDataBound"
        RepeatColumns="1">
        <ItemTemplate>
            <table width="900">
                <tr>
                    <td style="width: 700px" valign="top">
                        <table width="850">
                            <tr>
                                <td align="center" style="width: 50px" valign="top">
                                    <asp:Label ID="lblHistoryCount" runat="server" SkinID="Unicodelbl"></asp:Label></td>
                                <td style="width: 200px" valign="top">
                                    <asp:Label ID="lblTo" runat="server" SkinID="Unicodelbl" Text="कर्मचारी ::"></asp:Label><br />
                                    <asp:Label ID="lblHisTo" runat="server" Font-Italic="True" SkinID="Unicodelbl" Text='<%# Eval("ProcessTo") %>'></asp:Label></td>
                                <td style="width: 120px" valign="top">
                                    <asp:Label ID="lblStatus" runat="server" SkinID="Unicodelbl" Text="स्थिति ::"></asp:Label><br />
                                    <asp:Label ID="lblHisStatus" runat="server" Font-Italic="True" SkinID="Unicodelbl" Text='<%# Eval("ProcessStatusName") %>'></asp:Label></td>
                                <td style="width: 120px" valign="top">
                                    <asp:Label ID="lblDate" runat="server" SkinID="Unicodelbl" Text="मिति ::"></asp:Label><br />
                                    <asp:Label ID="lblHisDate" runat="server" Font-Italic="True" SkinID="Unicodelbl" Text='<%# Eval("ProcessOn") %>'></asp:Label></td>
                                <td style="width: 360px" valign="top">
                                    <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="कार्यालय / शाखा ::"></asp:Label><br />
                                    <asp:Label ID="lblOrgUnit" runat="server" Font-Italic="True" SkinID="Unicodelbl"
                                        Text='<%# Eval("ReceiverOrgName")+" / " +Eval("ReceiverUnitName") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="center" style="width: 50px" valign="top">
                                </td>
                                <td colspan="4" valign="top">
                                    <div class="msg_list">
                                        <p class="msg_head">
                                            <asp:Label ID="tippaniText" runat="server" SkinID="Unicodelbl" Text='<%# Eval("NoteTitle") %>'></asp:Label>&nbsp;</p>
                                        <div class="msg_body">
                                            <div style="height:auto; text-align:left; vertical-align:top">
                                                <%# Eval("Note") %>
                                            </div>
                                            <%--<asp:Label ID="lblNote" runat="server" BackColor="WhiteSmoke" Text='<%# Eval("Note") %>' Width="690px"></asp:Label>--%>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 200px" valign="top">
                        <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="पठाउने ब्यक्तिको कागजपत्र ::"></asp:Label><br />
                        <asp:Panel ID="pnlFiles" runat="server" ScrollBars="Auto" Width="150px">
                            <asp:DataList ID="dLstAttachment" runat="server" DataSource='<%# Eval("LstAttachment") %>' OnItemDataBound="dLstAttachment_ItemDataBound"
                                RepeatColumns="1">
                                <ItemTemplate>
                                    <asp:Label ID="lblCount" runat="server" SkinID="Unicodelbl"></asp:Label>
                                    <asp:LinkButton ID="lnkFile" runat="server" CommandArgument='<%# Eval("OrgID")+"/"+Eval("TippaniID")+"/"+Eval("TippaniProcessID")+"/"+Eval("AttachmentID") %>'
                                        OnClick="lnkFile_Click" SkinID="Tippani" Text='<%# Eval("DocumentName") %>' ToolTip='<%# Eval("Description") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:DataList></asp:Panel>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
        <SelectedItemStyle ForeColor="#400000" />
        <SelectedItemTemplate>
            <table style="width: 900px">
                <tr>
                    <td style="width: 700px" valign="top">
                        <table width="850">
                            <tr>
                                <td align="center" valign="top" width="50">
                                    <asp:Label ID="lblHistoryCount" runat="server" ForeColor="Red" SkinID="Unicodelbl"></asp:Label></td>
                                <td style="width: 200px" valign="top">
                                    <asp:Label ID="lblFrom" runat="server" ForeColor="Red" SkinID="Unicodelbl" Text="पठाउने ब्यक्ति ::"></asp:Label><br />
                                    <asp:Label ID="lblHisFrom" runat="server" Font-Italic="True" SkinID="Unicodelbl" Text='<%# Eval("ProcessBy") %>'></asp:Label></td>
                                <td style="width: 200px" valign="top">
                                    <asp:Label ID="lblTo" runat="server" ForeColor="Red" SkinID="Unicodelbl" Text="पाउने ब्यक्ति ::"></asp:Label><br />
                                    <asp:Label ID="lblHisTo" runat="server" Font-Italic="True" SkinID="Unicodelbl" Text='<%# Eval("ProcessTo") %>'></asp:Label></td>
                                <td style="width: 110px" valign="top">
                                    <asp:Label ID="lblDate" runat="server" ForeColor="Red" SkinID="Unicodelbl" Text="पठाएको मिति ::"></asp:Label><br />
                                    <asp:Label ID="lblHisDate" runat="server" Font-Italic="True" SkinID="Unicodelbl" Text='<%# Eval("ProcessOn") %>'></asp:Label></td>
                                <td style="width: 100px" valign="top">
                                    <asp:Label ID="lblStatus" runat="server" ForeColor="Red" SkinID="Unicodelbl" Text="स्थिति ::"></asp:Label><br />
                                    <asp:Label ID="lblHisStatus" runat="server" Font-Italic="True" SkinID="Unicodelbl" Text='<%# Eval("StatusName") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="center" valign="top" width="50">
                                </td>
                                <td colspan="4" valign="top">
                                    <asp:Label ID="lblNote" runat="server" BackColor="WhiteSmoke" Text='<%# Eval("Note") %>' Width="700px"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 200px" valign="top">
                        <asp:Label ID="Label1" runat="server" ForeColor="Red" SkinID="Unicodelbl" Text="पठाउने ब्यक्तिको कागजपत्र ::"></asp:Label><br />
                        <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Width="150px">
                            <asp:DataList ID="dLstAttachment" runat="server" DataSource='<%# Eval("LstAttachment") %>' OnItemDataBound="dLstAttachment_ItemDataBound"
                                RepeatColumns="1">
                                <ItemTemplate>
                                    <asp:Label ID="lblCount" runat="server" SkinID="Unicodelbl"></asp:Label>
                                    <asp:LinkButton ID="lnkFile" runat="server" CommandArgument='<%# Eval("OrgID")+"/"+Eval("TippaniID")+"/"+Eval("TippaniProcessID")+"/"+Eval("AttachmentID") %>'
                                        OnClick="lnkFile_Click" SkinID="Tippani" Text='<%# Eval("DocumentName") %>' ToolTip='<%# Eval("Description") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:DataList></asp:Panel>
                    </td>
                </tr>
            </table>
        </SelectedItemTemplate>
    </asp:DataList></div>
