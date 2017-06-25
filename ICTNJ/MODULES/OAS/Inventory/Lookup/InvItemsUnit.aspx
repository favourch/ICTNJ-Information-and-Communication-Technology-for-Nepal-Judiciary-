<%@ Page AutoEventWireup="true" CodeFile="InvItemsUnit.aspx.cs" Inherits="MODULES_OAS_Inventory_LookUp_InvItemsUnit"
    Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" Title="OAS | Items Unit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="ContentInvItems" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground"
        BehaviorID="programmaticModalPopupBehavior" DropShadow="True" PopupControlID="programmaticPopup"
        PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
        TargetControlID="hiddenTargetControlForModalPopup">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="padding-right: 10px;
        display: none; padding-left: 10px; padding-bottom: 10px; width: 350px; padding-top: 10px">
        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="border-right: gray 1px solid;
            border-top: gray 1px solid; border-left: gray 1px solid; cursor: move; color: black;
            border-bottom: gray 1px solid; background-color: #dddddd; text-align: center">
            Save Status
        </asp:Panel>
        <asp:UpdatePanel id="UpdatePanel1" runat="server">
            <contenttemplate>
<asp:Label id="lblStatusMessage" runat="server" Text="Label"></asp:Label>
</contenttemplate>
        </asp:UpdatePanel>
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
            Text="OK" Width="58px" /></asp:Panel>
    &nbsp;
    <asp:UpdatePanel ID="UP" runat="server">
        <contenttemplate>
<SCRIPT language="javascript" src="../../../COMMON/JS/Validation.js" type="text/javascript"></SCRIPT>
<DIV style="WIDTH: 100%; POSITION: static; HEIGHT: 500px"><%--<asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager>--%><BR /><asp:Label id="Label1" runat="server" Text="ईकाईहरू" SkinID="UnicodeHeadlbl">
        </asp:Label><BR /><TABLE style="POSITION: static" height=320 width=550><TBODY><TR><TD vAlign=top width=200></TD><TD vAlign=top width=350><asp:Label style="POSITION: static" id="lblStatus" runat="server" SkinID="UnicodeHeadlbl" Font-Bold="False"></asp:Label> </TD></TR><TR><TD vAlign=top width=200><asp:ListBox style="POSITION: static" id="lstInvItems" runat="server" Width="180px" Height="300px" SkinID="Unicodelst" OnSelectedIndexChanged="lstInvItems_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox> </TD><TD vAlign=top width=350><TABLE style="WIDTH: 344px"><TBODY><TR><TD style="WIDTH: 89px" vAlign=top><asp:Label style="POSITION: static" id="lblInvItemName" runat="server" Width="80px" Text="ईकाई" SkinID="Unicodelbl"></asp:Label> </TD><TD vAlign=top><asp:TextBox style="POSITION: static" id="txtInvItem_Rqd" runat="server" Width="230px" SkinID="Unicodetxt" ToolTip="ईकाई"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 89px; HEIGHT: 22px" vAlign=top><asp:Label id="lblActive" runat="server" Text="सकृय" SkinID="Unicodelbl"></asp:Label></TD><TD style="HEIGHT: 22px" vAlign=top><asp:CheckBox id="chkActive" runat="server" Width="92px"></asp:CheckBox></TD></TR><TR><TD style="WIDTH: 89px" vAlign=top></TD><TD vAlign=top><asp:Button accessKey="b" style="POSITION: static" id="btnSubmit" tabIndex=1 onclick="btnSubmit_Click" runat="server" Text="Submit" SkinID="Normal" OnClientClick="javascript:return validate(0);"></asp:Button> <asp:Button style="POSITION: static" id="btnCancel" tabIndex=2 onclick="btnCancel_Click" runat="server" Text="Cancel" SkinID="Cancel"></asp:Button> </TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></DIV>
</contenttemplate>
    </asp:UpdatePanel>
</asp:Content>
