<%@ Page Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" AutoEventWireup="true" CodeFile="BenchType.aspx.cs" Inherits="MODULES_CMS_Bench_BenchType" Title="CMS | Bench Type" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

 <script runat="server">

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
    </script>
    
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
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
    <table style="width: 766px">
        <tr>
            <td style="width: 100px">
                <asp:Label ID="Label1" runat="server" SkinID="UnicodeHeadlbl" Text="ईजलास किसिमहरु" Width="142px"></asp:Label></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 192px" valign="top">
                <asp:ListBox ID="lstBenchType" runat="server" Height="338px" SkinID="Unicodelst"
                    Width="335px" AutoPostBack="True" OnSelectedIndexChanged="lstBenchType_SelectedIndexChanged"></asp:ListBox></td>
            <td style="width: 100px; height: 192px" valign="top">
                <table style="width: 362px">
                    <tr>
                        <td style="width: 100px" valign="top">
                            <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="ईजलास किसिम" Width="107px"></asp:Label></td>
                        <td style="width: 100px">
                            <asp:TextBox ID="txtBenchType" runat="server" Height="51px" TextMode="MultiLine" Width="443px" MaxLength="100"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            <asp:Label ID="Label3" runat="server" SkinID="Unicodelbl" Text="सक्रिय"></asp:Label></td>
                        <td style="width: 100px">
                            <asp:CheckBox ID="chkBenchTypeActive" runat="server" /></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <table>
                                <tr>
                                    <td style="width: 100px">
                            <asp:Button ID="btnSubmit" runat="server" SkinID="Normal" Text="Submit" OnClick="btnSubmit_Click" /></td>
                                    <td style="width: 100px">
                            <asp:Button ID="btnCancel" runat="server" SkinID="Cancel" Text="Cancel" OnClick="btnCancel_Click" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100px" valign="top">
            </td>
            <td style="width: 100px" valign="top">
            </td>
        </tr>
    </table>
    
</asp:Content>
