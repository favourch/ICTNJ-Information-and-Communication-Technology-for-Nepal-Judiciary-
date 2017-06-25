<%@ Page Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" AutoEventWireup="true" CodeFile="Application.aspx.cs" Inherits="MODULES_CMS_LookUp_Application" Title="Untitled Page" %>
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
    <table style="width: 838px">
        <tr>
            <td colspan="2">
                <table style="width: 448px">
                    <tr>
                        <td style="width: 100px" valign="top">
                            <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="निवेदनको नाम"></asp:Label></td>
                        <td style="width: 100px" valign="top">
                            <asp:TextBox ID="txtApplication_RQD" runat="server" Height="64px" MaxLength="200" 
                                TextMode="MultiLine" Width="631px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 100px; height: 41px;" valign="top">
                            <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="सक्रिय"></asp:Label></td>
                        <td style="width: 100px; height: 41px;">
                            <asp:CheckBox ID="chkApplicationActive" runat="server" /></td>
                    </tr>
                    <tr>
                        <td style="width: 100px; height: 24px;">
                            <asp:Label ID="Label3" runat="server" SkinID="Unicodelbl" Text="निवेदनको किसिम" Width="129px"></asp:Label></td>
                        <td style="width: 100px; height: 24px;">
                            <asp:DropDownList ID="ddlApplicationType" runat="server" SkinID="Unicodeddl" OnSelectedIndexChanged="ddlApplicationType_SelectedIndexChanged" Width="210px">
                                <asp:ListItem Value="0">छान्नुहोस</asp:ListItem>
                                <asp:ListItem Value="B">ईजलास</asp:ListItem>
                                <asp:ListItem Value="O">अन्य</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:Label ID="Label4" runat="server" SkinID="UnicodeHeadlbl" Text="निवेदनहरू"></asp:Label></td>
            <td style="width: 100px">
                <asp:Label ID="Label5" runat="server" SkinID="UnicodeHeadlbl" Text="कार्यलयहरू"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 135px;" valign="top">
                <asp:ListBox ID="lstApplication" runat="server" Height="291px" SkinID="Unicodelst"
                    Width="367px" AutoPostBack="True" OnSelectedIndexChanged="lstApplication_SelectedIndexChanged"></asp:ListBox>
            </td>
            <td style="width: 100px; height: 135px;" valign="top">
                <asp:Panel ID="Panel1" runat="server" Height="291px" ScrollBars="Vertical" Width="425px">
                <asp:GridView ID="grdOrganization" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None" Width="400px" OnRowCreated="grdOrganization_RowCreated">
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="OrgID" HeaderText="OrgID" />
                        <asp:BoundField DataField="OrgName" HeaderText="कार्यलयको नाम" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Active" />
                    </Columns>
                    <RowStyle BackColor="#EFF3FB" />
                    <EditRowStyle BackColor="#2461BF" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <table>
                    <tr>
                        <td style="width: 100px">
                            <asp:Button ID="btnSubmit" runat="server" SkinID="Normal" Text="Submit" OnClick="btnSubmit_Click" />
                        </td>
                        <td style="width: 100px">
                            <asp:Button ID="btnCancel" runat="server" SkinID="Cancel" Text="Cancel" OnClick="btnCancel_Click" /></td>
                    </tr>
                </table>
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
    
    
</asp:Content>

