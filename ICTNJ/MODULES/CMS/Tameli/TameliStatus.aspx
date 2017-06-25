<%@ Page Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" AutoEventWireup="true" CodeFile="TameliStatus.aspx.cs" Inherits="MODULES_CMS_Tameli_TameliStatus" Title="CMS | Tameli Status" %>
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
            <asp:Label ID="lblStatus" runat="server" Text="Label"></asp:Label>&nbsp;</asp:Panel>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
        <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
            Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    
     <asp:UpdatePanel runat="server" id="up">
        <contenttemplate>
<TABLE style="WIDTH: 950px"><TBODY><TR><TD style="WIDTH: 20px"></TD><TD width=340><asp:Label id="Label5" runat="server" Text="तामेली स्थीतिका प्रकारहरु" SkinID="Unicodelbl"></asp:Label></TD><TD></TD></TR><TR><TD style="HEIGHT: 301px" vAlign=top></TD><TD style="HEIGHT: 301px" vAlign=top><asp:ListBox id="lstTameliStatus" runat="server" Width="300px" Height="300px" OnSelectedIndexChanged="lstTameliStatus_SelectedIndexChanged" DataValueField="TameliStatusID" DataTextField="TameliStatusName" AutoPostBack="True"></asp:ListBox></TD><TD style="HEIGHT: 301px" vAlign=top><TABLE style="WIDTH: 346px"><TBODY><TR><TD vAlign=top><asp:Label id="Label2" runat="server" Width="127px" Text="तामेली स्थीतिको प्रकार" SkinID="Unicodelbl"></asp:Label></TD><TD><asp:TextBox id="txTameliStatusName" runat="server" Width="450px" SkinID="Unicodetxt" MaxLength="50"></asp:TextBox></TD></TR><TR><TD><asp:Label id="Label15" runat="server" Text="सक्रिय" SkinID="Unicodelbl"></asp:Label></TD><TD><asp:CheckBox id="chkTameliStatus" runat="server" Checked="True"></asp:CheckBox></TD></TR><TR><TD vAlign=middle colSpan=2><TABLE><TBODY><TR><TD style="HEIGHT: 28px"><asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Text="Save" SkinID="Submit"></asp:Button></TD><TD style="WIDTH: 63px; HEIGHT: 28px"><asp:Button id="btnCancel" onclick="btnCancel_Click" runat="server" Text="Cancel" SkinID="Cancel"></asp:Button></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></TD></TR><TR><TD></TD><TD></TD><TD></TD></TR></TBODY></TABLE>
</contenttemplate>
        </asp:UpdatePanel>
</asp:Content>

