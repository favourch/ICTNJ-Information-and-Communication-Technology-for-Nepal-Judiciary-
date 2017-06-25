<%@ Page Language="C#" MasterPageFile="~/MODULES/LJMS/LJMSMasterPage.master" AutoEventWireup="true" CodeFile="JudgeWorkEvaluation.aspx.cs" Inherits="MODULES_LJMS_ReportForms_JudgeWorkEvaluation" Title="PMS | Judge Work Evaluation Report Form" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground"
        BehaviorID="programmaticModalPopupBehavior" DropShadow="True" PopupControlID="programmaticPopup"
        PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
        TargetControlID="hiddenTargetControlForModalPopup">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none;
        width: 350px; padding: 10px">
        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD;
            border: solid 1px Gray; color: Black; text-align: center;">
            Status
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
    <asp:Label ID="Label3" runat="server" SkinID="UnicodeHeadlbl" Text="न्यायाधिशको कार्य सम्पादन रिपोर्ट"></asp:Label><br />
    <asp:Panel ID="Panel1" runat="server" Height="400px" Width="500px">
        <asp:UpdatePanel id="UpdatePanel1" runat="server">
            <contenttemplate>
<TABLE style="WIDTH: 786px"><TBODY><TR><TD style="WIDTH: 70px" vAlign=top><asp:Label id="Label1" runat="server" Width="60px" Text="कार्यालय" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:DropDownList id="ddlOrganization" runat="server" Width="440px" SkinID="Unicodeddl" AutoPostBack="True" OnSelectedIndexChanged="ddlOrganization_SelectedIndexChanged"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 70px" vAlign=top><asp:Label id="Label2" runat="server" Text="आ.व." SkinID="Unicodelbl" __designer:wfdid="w1"></asp:Label></TD><TD vAlign=top><asp:TextBox id="txtFiscalYear" runat="server" Width="37px" __designer:wfdid="w2"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender1" runat="server" TargetControlID="txtFiscalYear" __designer:wfdid="w3" ClearMaskOnLostFocus="False" Mask="99/99" AutoComplete="False"></ajaxToolkit:MaskedEditExtender></TD></TR></TBODY></TABLE><TABLE style="WIDTH: 512px"><TBODY><TR><TD style="WIDTH: 100px"><asp:Panel id="Panel2" runat="server" Width="400px" Height="200px" ScrollBars="Auto"><asp:CheckBoxList id="chklstJudges" runat="server"></asp:CheckBoxList></asp:Panel></TD></TR><TR><TD style="WIDTH: 100px">&nbsp;</TD></TR></TBODY></TABLE>
</contenttemplate>
        </asp:UpdatePanel>
        <asp:Button ID="btnView" runat="server" OnClick="btnView_Click" Text="View" Width="65px" /><asp:Button
            ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" Width="65px" /></asp:Panel>
</asp:Content>

