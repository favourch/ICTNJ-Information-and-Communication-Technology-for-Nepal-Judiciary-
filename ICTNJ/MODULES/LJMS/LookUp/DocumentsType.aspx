<%@ Page Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master" AutoEventWireup="true" CodeFile="DocumentsType.aspx.cs" Inherits="MODULES_PMS_LookUp_DocumentsType" Title="PMS | Document Type" %>
<%@ Register 
    Assembly="AjaxControlToolkit" 
    Namespace="AjaxControlToolkit" 
    TagPrefix="ajaxToolkit" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript" src="../../COMMON/JS/Validation.js"></script>

    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
                    <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" style="display:none"/>
        <ajaxToolkit:ModalPopupExtender runat="server" ID="programmaticModalPopup"
            BehaviorID="programmaticModalPopupBehavior"
            TargetControlID="hiddenTargetControlForModalPopup"
            PopupControlID="programmaticPopup" 
            BackgroundCssClass="modalBackground"
            DropShadow="True"
            PopupDragHandleControlID="programmaticPopupDragHandle"
            RepositionMode="RepositionOnWindowScroll" >
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel runat="server" CssClass="modalPopup" ID="programmaticPopup" style="display:none;width:350px;padding:10px">
            <asp:Panel runat="Server" ID="programmaticPopupDragHandle" Style="cursor: move;background-color:#DDDDDD;border:solid 1px Gray;color:Black;text-align:center;">
                Save Status
            </asp:Panel>
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label><br />
<asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click" Width="58px" />           <br />
        </asp:Panel>
    <asp:Label ID="Label3" runat="server" SkinID="UnicodeHeadlbl" Text="कागजपत्रको विवरण"></asp:Label><br />
    <table style="width: 700px">
        <tr>
            <td style="width: 190px; height: 350px" valign="top">
                <asp:ListBox ID="DocumentsTypeList" runat="server" Height="150px" OnSelectedIndexChanged="DocumentsTypeList_SelectedIndexChanged"
                    SkinID="Unicodelst" Width="170px" AutoPostBack="True"></asp:ListBox></td>
            <td valign="top" style="height: 350px">
                <table style="width: 350px">
                    <tr>
                        <td style="width: 95px" valign="top">
                            <asp:Label ID="Label1" runat="server" Text="कागज-पत्र" Width="85px" SkinID="Unicodelbl"></asp:Label></td>
                        <td align="left" valign="top">
                            <asp:TextBox ID="txtDocTypeName_rqd" runat="server" MaxLength="20" SkinID="Unicodetxt" Width="197px" ToolTip="Document Type"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 95px">
                        </td>
                        <td align="left" valign="top">
                            <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" Text="OK" Width="60px" OnClientClick="javascript:return validate();" SkinID="Normal" /><asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel"
                                Width="60px" SkinID="Cancel" /></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

