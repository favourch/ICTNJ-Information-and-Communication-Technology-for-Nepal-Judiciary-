<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true" CodeFile="CommitteeTippani.aspx.cs"
 Inherits="MODULES_OAS_Tippani_CommitteeTippani" Title="OAS | Committee Tippani" ValidateRequest="false" MaintainScrollPositionOnPostback="true" %>

<%@ Register Src="../UserControls/CommitteeEntry.ascx" TagName="CommitteeEntry" TagPrefix="uc6" %>

<%@ Register Src="../UserControls/TippaniAttachment.ascx" TagName="TippaniAttachment" TagPrefix="uc5" %>
<%@ Register Src="../UserControls/VisitEntry.ascx" TagName="VisitEntry" TagPrefix="uc4" %>
<%@ Register Src="../UserControls/Tippani.ascx" TagName="Tippani" TagPrefix="uc3" %>
<%@ Register Src="../UserControls/ChannelPerson.ascx" TagName="ChannelPerson" TagPrefix="uc2" %>
<%@ Register Src="../UserControls/GroupMemberPersonSearch.ascx" TagName="GroupMemberPersonSearch" TagPrefix="uc1" %>
<%@ Register Assembly="Winthusiasm.HtmlEditor" Namespace="Winthusiasm.HtmlEditor" TagPrefix="SJ" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <script language="javascript" type="text/javascript">
        function ValidateTippani()
        {
            var tippaniText = document.getElementById('<%= this.Tippani.TippaniText.ClientID%>');
            var fileNo = document.getElementById('<%= this.Tippani.FileNo.ClientID%>');
            var priority = document.getElementById('<%= this.Tippani.TippaniPriority.ClientID%>');
            
            if(tippaniText.value.trim() == "")
            {
                alert('कृपया टिप्पणीको बिषय राख्नुहोस।');
                tippaniText.focus();
                return false;
            }
            
            if(fileNo.value.trim() == "")
            {
                alert('कृपया टिप्पणीको फाइल नं राख्नुहोस।');
                fileNo.focus();
                return false;
            }
            
            if(priority.selectedIndex <= 0)
            {
                alert('कृपया टिप्पणीको प्राथमिक्ता छन्नुहोस।');
                priority.focus();
                return false;
            }
            
            var table = document.getElementById('<%= this.CommitteeEntry.CommitteeMemberGrid.ClientID%>');
            if(table == null)
            {
                alert('कृपया भ्रमणको लागी कर्मचारी राख्नोहोस।');
                //var cntl = document.getElementById('<%= this.CommitteeEntry.CommitteeMemberGrid.ClientID%>');
                //cntl.focus();
                return false;
            }
            
//            var mode = document.getElementById('<%= this.hdnMode.ClientID%>');
//            if(mode.value == 'A')
//            {
//                var hdn = document.getElementById('<%= this.chnlPerson.ChkChannelPerson.ClientID%>');
//                if(hdn.value == '0')
//                {
//                    alert('कृपया टिप्पणीको सिफारिस कर्ता/प्रमाणित कर्ता छन्नुहोस।');
//                    return false;
//                }
//            }
        }
    </script>

    <div id="DIV1" style="width: 100%; height: auto">
        <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" /><ajaxToolkit:ModalPopupExtender
            ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior"
            DropShadow="True" PopupControlID="programmaticPopup" PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
            TargetControlID="hiddenTargetControlForModalPopup">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none; width: 350px; padding: 10px">
            <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD; border: solid 1px Gray;
                color: Black; text-align: center;">
                Save Status
            </asp:Panel>
            <asp:UpdatePanel id="UpdatePanel3" runat="server">
                <contenttemplate>
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
</contenttemplate>
            </asp:UpdatePanel>
            <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click" Text="OK" Width="58px" /></asp:Panel>
        <table style="width: 100%">
            <tr>
                <td style="width: 100%">
                    <asp:Label ID="Label1" runat="server" SkinID="UnicodeHeadlbl" Text="नया कमिटिको टिप्पणी"></asp:Label>
                    &nbsp; &nbsp;&nbsp;
                    <asp:Label ID="lblConfirmation" runat="server" SkinID="UnicodeHeadlbl"></asp:Label></td>
            </tr>
        </table>
        <asp:HiddenField ID="hdnMode" runat="server" Value="A" />
        <asp:HiddenField ID="hdnIDs" runat="server" />
        <asp:HiddenField ID="hdnMsgIDs" runat="server" />
        <asp:HiddenField ID="hdnDarIDs" runat="server" />
        <%--<asp:Label ID="Label22" runat="server" SkinID="UnicodeHeadlbl" Text="कर्मचारी खोज्नुहोस"></asp:Label><br />--%>
        <uc3:Tippani ID="Tippani" runat="server" TippaniSubjectID="9" TippaniSubjectType="Committee" />
        <hr align="left" width="100%" />
        <uc1:GroupMemberPersonSearch ID="ggrdMemberSearch" runat="server" ApplicationString="5, 3" TippaniSubjectID="9" />
        <hr />
        <uc6:CommitteeEntry ID="CommitteeEntry" runat="server" />
        <hr align="left" width="100%" />
        <uc5:TippaniAttachment ID="TippaniAttachment" runat="server" />
        <hr align="left" width="100%" />
        <uc2:ChannelPerson ID="chnlPerson" runat="server" ApplicationString="5, 3" TippaniSubjectID="9" />
        <br />
        <table width="100%">
            <tr>
                <td style="width: 100%">
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" OnClientClick="return ValidateTippani();" SkinID="Normal"
                        Text="Submit" />
                    <asp:Button ID="btnCancelSubmit" runat="server" OnClick="btnCancelSubmit_Click" SkinID="Cancel" Text="Cancel" />
                    &nbsp;<asp:Label ID="lblFinalStatus" runat="server" SkinID="UnicodeHeadlbl"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
