<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true" CodeFile="Committee.aspx.cs" Inherits="MODULES_OAS_LookUp_Committee" Title="OAS | Committee" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager runat="server" ID="ScriptManager">
    </asp:ScriptManager>
    <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior"
        DropShadow="True" PopupControlID="programmaticPopup" PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
        TargetControlID="hiddenTargetControlForModalPopup">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none; width: 350px; padding: 10px">
        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD; border: solid 1px Gray; color: Black; text-align: center;">
            Save Status
        </asp:Panel>
        <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label><br />
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click" Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    <br />
    <div style="width:100%; min-height:450px;">
        <table width="700" height="400">
            <tr>
                <td style="width: 250px" rowspan="2">
                    <asp:ListBox ID="lstCommittee" runat="server" Height="400px" Width="230px" AutoPostBack="True" OnSelectedIndexChanged="lstCommittee_SelectedIndexChanged" SkinID="Unicodelst"></asp:ListBox></td>
                <td style="width: 450px" valign="top" height="370">
                    <table width="450">
                        <tr>
                            <td style="width: 100px">
                                <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="संस्था"></asp:Label></td>
                            <td style="width: 350px">
                                <asp:DropDownList ID="ddlOrg" runat="server" SkinID="Unicodeddl" Width="340px" AutoPostBack="True" OnSelectedIndexChanged="ddlOrg_SelectedIndexChanged">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                                <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="कमिटि"></asp:Label></td>
                            <td style="width: 350px">
                                <asp:TextBox ID="txtCommittee" runat="server" SkinID="Unicodetxt" Width="334px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px" valign="top">
                                <asp:Label ID="Label3" runat="server" SkinID="Unicodelbl" Text="विवरण"></asp:Label></td>
                            <td style="width: 350px">
                                <asp:TextBox ID="txtDescription" runat="server" Height="130px" SkinID="Unicodetxt" TextMode="MultiLine" Width="334px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px" valign="top">
                                <asp:Label ID="Label4" runat="server" SkinID="Unicodelbl" Text="सक्रिय"></asp:Label></td>
                            <td style="width: 350px">
                                <asp:CheckBox ID="chkActive" runat="server" SkinID="smallChk" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="30" style="width: 450px" valign="bottom">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" SkinID="Normal" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" SkinID="Cancel" /></td>
            </tr>
        </table>
        
    </div>
</asp:Content>

