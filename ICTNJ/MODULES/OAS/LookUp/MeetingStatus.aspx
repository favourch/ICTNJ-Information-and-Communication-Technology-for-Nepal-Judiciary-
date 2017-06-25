<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true" CodeFile="MeetingStatus.aspx.cs" Inherits="MODULES_OAS_LookUp_MeetingStatus" Title="OAS | Meeting Status" %>

<%@ Register Assembly="Karpach.WebControls" Namespace="Karpach.WebControls" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="SM" runat="server">
    </asp:ScriptManager>
    <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior"
        DropShadow="True" PopupControlID="programmaticPopup" PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
        TargetControlID="hiddenTargetControlForModalPopup">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="padding-right: 10px; display: none; padding-left: 10px; padding-bottom: 10px;
        width: 350px; padding-top: 10px">
        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="border-right: gray 1px solid; border-top: gray 1px solid; border-left: gray 1px solid;
            cursor: move; color: black; border-bottom: gray 1px solid; background-color: #dddddd; text-align: center">
            Save Status
        </asp:Panel>
        <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label><br />
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click" Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    <div style="width: 100%; height: 500px">
        <br />
        <table height="370" width="800">
            <tr>
                <td rowspan="2" style="width: 250px" valign="top">
                    <asp:ListBox ID="lstMeetingStatus" runat="server" AutoPostBack="True" Height="375px" SkinID="Unicodelst"
                        Width="230px" OnSelectedIndexChanged="lstMeetingStatus_SelectedIndexChanged"></asp:ListBox></td>
                <td height="340" style="width: 550px" valign="top">
                    <table width="500">
                        <tr>
                            <td style="width: 130px">
                                <asp:Label ID="lblMeetingStatus" runat="server" SkinID="Unicodelbl" Text="मिटिङको स्टेटस"></asp:Label></td>
                            <td style="width: 370px">
                                <asp:TextBox ID="txtMeetingStatus" runat="server" SkinID="Unicodetxt" Width="260px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 130px; height: 21px">
                                <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="रङ छान्नुहोस"></asp:Label></td>
                            <td style="width: 370px; height: 21px">
                                <cc1:colorpicker id="ColorPicker" runat="server" Color="#006ea2"></cc1:colorpicker>
                                
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="30" style="width: 550px" valign="bottom">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" SkinID="Normal" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" SkinID="Cancel" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

