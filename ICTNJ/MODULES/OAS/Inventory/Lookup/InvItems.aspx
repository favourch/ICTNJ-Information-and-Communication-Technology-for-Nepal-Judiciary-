<%@ Page AutoEventWireup="true" CodeFile="InvItems.aspx.cs" Inherits="MODULES_OAS_Inventory_Forms_InvItems"
    Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" Title="OAS | Items " %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
<script language="javascript" src="../../../COMMON/JS/Validation.js" type="text/javascript" />
<asp:ScriptManager ID="SMInvTransaction" runat="server"></asp:ScriptManager>
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
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
            Text="OK" Width="58px" /></asp:Panel> 
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
<TABLE style="WIDTH: 739px"><TBODY><TR><TD style="WIDTH: 200px" vAlign=top></TD><TD vAlign=top><asp:Label id="lblStatus" runat="server" SkinID="UnicodeHeadlbl"></asp:Label></TD></TR><TR><TD style="WIDTH: 200px" vAlign=top><asp:ListBox id="lstInvItem" runat="server" Width="180px" Height="300px" SkinID="Unicodelst" AutoPostBack="True" OnSelectedIndexChanged="lstInvItem_SelectedIndexChanged"></asp:ListBox></TD><TD vAlign=top><TABLE style="WIDTH: 480px"><TBODY><TR><TD style="WIDTH: 110px" vAlign=top><asp:Label id="lblCategory" runat="server" Width="80px" Text="समुह" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:DropDownList id="DDLItemCategory_Rqd" runat="server" Width="230px" SkinID="Unicodeddl" AutoPostBack="True" OnSelectedIndexChanged="DDLCategory_SelectedIndexChanged" ToolTip="समुह"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 110px" vAlign=top><asp:Label id="lblSubcategory" runat="server" Text="ऊप समुह" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:DropDownList id="DDLItemsSubCategory_Rqd" runat="server" Width="230px" SkinID="Unicodeddl" AutoPostBack="True" OnSelectedIndexChanged="DDLItemsSubCategory_Rqd_SelectedIndexChanged" ToolTip="समुह २">
                                         </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 110px" vAlign=top><asp:Label id="lblItemCD" runat="server" Text="सामान कोड" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:TextBox id="txtItemCD" runat="server" Width="59px" SkinID="Unicodetxt" ToolTip="सामान कोड" MaxLength="5"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 110px" vAlign=top><asp:Label id="lblItemName" runat="server" Width="100px" Text="सामानको नाम" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:TextBox id="txtItemName_Rqd" runat="server" Width="223px" SkinID="Unicodetxt" ToolTip="सामानको नाम" MaxLength="30"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 110px" vAlign=top><asp:Label id="lblItemShortName" runat="server" Width="78px" Text="छोटो नाम" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:TextBox id="txtItemShortName" runat="server" Width="59px" SkinID="Unicodetxt" ToolTip="छोटो नाम" MaxLength="5"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 110px" vAlign=top><asp:Label id="lblItemType" runat="server" Text="प्रकार" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:DropDownList id="DDLItemType_Rqd" runat="server" Width="230px" SkinID="Unicodeddl" AutoPostBack="true" OnSelectedIndexChanged="DDLItemType_Rqd_SelectedIndexChanged" ToolTip="प्रकार"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 110px" vAlign=top><asp:Label id="lblItemUnit" runat="server" Text="ईकाई" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:DropDownList id="DDLItemUnit_Rqd" runat="server" Width="230px" SkinID="Unicodeddl" ToolTip="ईकाई"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 110px" vAlign=top><asp:Label id="lblActive" runat="server" Text="सकृय" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:CheckBox id="chkActive" runat="server" SkinID="smallChk"></asp:CheckBox></TD></TR><TR><TD style="WIDTH: 110px" vAlign=top></TD><TD vAlign=top><asp:Button id="btnSubmit" onclick="btnSubmit_Click" runat="server" Text="Submit" SkinID="Normal" OnClientClick="javascript:return validate(0);"></asp:Button> <asp:Button id="btnCancel" onclick="btnCancel_Click" runat="server" Text="Cancel" SkinID="Cancel"></asp:Button></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
</ContentTemplate>        
    </asp:UpdatePanel>
</asp:Content>
