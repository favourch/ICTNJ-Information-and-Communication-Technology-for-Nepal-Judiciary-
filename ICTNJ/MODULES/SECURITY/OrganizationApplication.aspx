<%@ Page Language="C#" MasterPageFile="~/MODULES/COMMON/MasterPage.master" AutoEventWireup="true" CodeFile="OrganizationApplication.aspx.cs" Inherits="MODULES_SECURITY_Forms_OrganizationApplication" Title="PMS | Organization Application" %>
<%@ Register 
    Assembly="AjaxControlToolkit" 
    Namespace="AjaxControlToolkit" 
    TagPrefix="ajaxToolkit" %>
    
    <script runat="server">

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                    <div style="padding: 10px; text-align: center">

            <asp:Panel runat="Server" ID="programmaticPopupDragHandle" Style="cursor: move;background-color:#DDDDDD;border:solid 1px Gray;color:Black;text-align:center;">
                Save Status
            </asp:Panel>
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label><br />
<asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click" Width="58px" />           <br />
</div>
        </asp:Panel>

    <table>
        <tr>
            <td style="width: 100px">
                <asp:Label ID="Label1" runat="server" Text="Organization" SkinID="Unicodelbl"></asp:Label>
            </td>
            <td style="width: 41px">
                <asp:DropDownList ID="ddlOrganization" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlOrganization_SelectedIndexChanged" SkinID="Unicodeddl" Width="226px">
                </asp:DropDownList>
                </td>
            <td style="width: 100px">
                </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 32px;">
            </td>
            <td style="width: 41px; height: 32px;">
                <br />
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Applications" SkinID="UnicodeHeadlbl"></asp:Label></td>
            <td style="width: 100px; height: 32px;">
            </td>
            <td style="width: 100px; height: 32px;">
            </td>
            <td style="width: 100px; height: 32px;">
            </td>
        </tr>
        <tr>
            <td colspan="1" style="width: 100px">
            </td>
            <td colspan="2">
            <asp:Panel ID="Panel1" runat="server" BackColor="White" Height="250px" Width="300px">
                <asp:CheckBoxList ID="chklstApplications" runat="server" OnSelectedIndexChanged="chklstApplications_SelectedIndexChanged" AutoPostBack="True" Width="276px">
                </asp:CheckBoxList></asp:Panel>
            </td>
            <td colspan="1">
                <br />
                </td>
            <td colspan="1" style="width: 100px" valign="top">
                
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 41px; height: 16px">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            </td>
            <td style="width: 100px; height: 16px">
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" /></td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
        </tr>
        <tr>
            <td colspan="1" style="width: 100px">
            </td>
            <td colspan="2">
                
            </td>
            <td colspan="1">
            </td>
            <td colspan="1" style="width: 100px">
            </td>
        </tr>
        <tr>
            <td colspan="1" style="width: 100px; height: 16px;">
            </td>
            <td colspan="2" style="height: 16px">
            </td>
            <td colspan="1" style="height: 16px">
            </td>
            <td colspan="1" style="width: 100px; height: 16px;">
            </td>
        </tr>
    </table>
</asp:Content>

