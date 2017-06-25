<%@ Page Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" AutoEventWireup="true" CodeFile="CauseListEntry.aspx.cs" Inherits="MODULES_CMS_LookUp_CauseListEntry" Title="CMS | Check List Entry" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

 <script runat="server">

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
    </script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager id="scriptManager1" runat="server"></asp:ScriptManager>
      <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
    <ajaxtoolkit:modalpopupextender id="programmaticModalPopup" runat="server" backgroundcssclass="modalBackground"
        behaviorid="programmaticModalPopupBehavior" dropshadow="True" popupcontrolid="programmaticPopup"
        popupdraghandlecontrolid="programmaticPopupDragHandle" repositionmode="RepositionOnWindowScroll"
        targetcontrolid="hiddenTargetControlForModalPopup">
        </ajaxtoolkit:modalpopupextender>
        <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none;
        width: 350px; padding: 10px">
        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD;
            border: solid 1px Gray; color: Black; text-align: center;">
            Save Status
        </asp:Panel>
        <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label><br />
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
            Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    <table style="width: 700px">
        <tr>
            <td style="width: 330px" valign="top">
                <table style="width: 320px">
                    <tr>
                        <td>
                            <div style="overflow: scroll; width: 290px; height: 400px">
                                <asp:ListBox style="width:330px" ID="lstCauseList" runat="server" AutoPostBack="True" Height="380px"
                                    SkinID="Unicodelst" OnSelectedIndexChanged="lstCauseList_SelectedIndexChanged"></asp:ListBox>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top">
                <table style="width: 340px">
                    <tr>
                        <td style="width: 65px" valign="top">
                            <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="केसलिष्ट" Width="60px"></asp:Label></td>
                        <td valign="top">
                            <asp:TextBox ID="txtCauseList" runat="server" Height="60px" SkinID="Unicodetxt" TextMode="MultiLine"
                                Width="240px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 65px" valign="top">
                            <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="सक्रिय" Width="46px"></asp:Label></td>
                        <td valign="top">
                            <asp:CheckBox ID="chkActive" runat="server" SkinID="smallChk" /></td>
                    </tr>
                    <tr>
                        <td style="width: 65px" valign="top">
                        </td>
                        <td valign="top">
                            <asp:Button ID="btnSubmit" runat="server" SkinID="Normal" Text="Submit" OnClick="btnSubmit_Click" />
                            <asp:Button ID="btnCancel" runat="server" SkinID="Cancel" Text="Cancel" OnClick="btnCancel_Click" /></td>
                    </tr>
                </table>
                <asp:HiddenField ID="hdnFldCauseListID" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>

