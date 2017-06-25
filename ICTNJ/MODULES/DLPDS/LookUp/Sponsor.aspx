<%@ Page Language="C#" MasterPageFile="~/MODULES/DLPDS/DLPDSMasterPage.master" AutoEventWireup="true" CodeFile="Sponsor.aspx.cs" Inherits="MODULES_DLPDS_LookUp_Sponsor" Title="DLPDS | Sponsor" %>

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

<asp:ScriptManager ID="ScriptManager1" runat="server">
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
    <br />
    <table style="width: 729px">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Sponsors"></asp:Label></td>
            <td>
            </td>
        </tr>
        <tr>
            <td rowspan="2" valign="top">
                <asp:ListBox ID="lstSponsors" runat="server" Height="328px" Width="302px" AutoPostBack="True" OnSelectedIndexChanged="lstSponsors_SelectedIndexChanged"></asp:ListBox></td>
            <td valign="top">
                <table>
                    <tr>
                        <td style="width: 132px" valign="top">
                            <asp:Label ID="Label2" runat="server" Text="Sponsor's Name" Width="108px"></asp:Label></td>
                        <td style="width: 125px" valign="top">
                            <asp:TextBox ID="txtSponsorName_RQD" runat="server" Width="262px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 132px">
                        </td>
                        <td align="right" style="width: 125px" valign="bottom">
                            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" /><asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>

