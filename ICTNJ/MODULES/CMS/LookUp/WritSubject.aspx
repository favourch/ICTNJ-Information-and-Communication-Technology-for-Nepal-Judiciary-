<%@ Page Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" AutoEventWireup="true" CodeFile="WritSubject.aspx.cs" Inherits="MODULES_CMS_LookUp_WritSubject" Title="CMS | Writ Subject" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

  <script runat="server">

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
</script>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" src="../../COMMON/JS/Validation.js" type="text/javascript"></script>
    <script language="javascript" src="../../COMMON/JS/DateValidator.js" type="text/javascript"></script>
    <script language="javascript" src="../../COMMON/JS/EnglishDateValidator.js" type="text/javascript"></script>
    <script language="javascript" src="../../COMMON/JS/Number.js" type="text/javascript"></script>
   <script language="javascript" src="../../COMMON/JS/UPanelValidation.js" type="text/javascript"></script>
    <script language="javascript" src="../../COMMON/JS/EmailValidator.js" type="text/javascript"></script>
    
    
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
    <table style="width: 827px">
        <tr>
            <td style="width: 30px">
                <asp:Label ID="Label1" runat="server" SkinID="UnicodeHeadlbl" Text="रिट विषय" Width="116px"></asp:Label></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 30px" valign="top">
                <asp:ListBox ID="lstWritSubject" runat="server" Height="433px" Width="305px" AutoPostBack="True" OnSelectedIndexChanged="lstWritSubject_SelectedIndexChanged"></asp:ListBox></td>
            <td style="width: 100px" valign="top">
                <table style="width: 346px">
                    <tr>
                        <td style="width: 34px; height: 62px;" valign="top">
                <asp:Label ID="Label2" runat="server" Width="78px" SkinID="Unicodelbl">रिट विषय</asp:Label></td>
                        <td style="width: 100px; height: 62px;">
                <asp:TextBox ID="txtWritSubject_RQD" runat="server" Height="52px" TextMode="MultiLine"
                    Width="423px"></asp:TextBox></td>
                        <td style="width: 100px; height: 62px;">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 34px">
                <asp:Label ID="Label3" runat="server" Text="सक्रिय" SkinID="Unicodelbl"></asp:Label></td>
                        <td style="width: 100px">
                <asp:CheckBox ID="chkWritActive" runat="server" /></td>
                        <td style="width: 100px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 34px" valign="top">
                            <asp:Label ID="Label4" runat="server" Text="रिट समूह" Width="81px" SkinID="Unicodelbl"></asp:Label></td>
                        <td style="width: 100px">
                            <asp:TextBox ID="txtWritSubjectCategory" runat="server" Height="52px" TextMode="MultiLine"
                                Width="423px"></asp:TextBox></td>
                        <td style="width: 100px" valign="bottom">
                            </td>
                    </tr>
                    <tr>
                        <td style="width: 34px">
                            <asp:Label ID="Label5" runat="server" SkinID="Unicodelbl" Text="सक्रिय" Visible="False"></asp:Label></td>
                        <td style="width: 100px">
                            <asp:CheckBox ID="chkWritSubCatActive" runat="server" /></td>
                        <td style="width: 100px">
                            <asp:Button ID="btnAddWritSubjectCategory" runat="server" Text="+" OnClick="btnAddWritSubjectCategory_Click" SkinID="Add" /></td>
                    </tr>
                    <tr>
                        <td style="width: 34px; height: 21px">
                        </td>
                        <td style="width: 100px; height: 21px">
                            <asp:GridView ID="grdWritCategory" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="grdWritCategory_SelectedIndexChanged" OnRowCreated="grdWritCategory_RowCreated" Width="423px">
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="WritSubjectID" HeaderText="WritSubID" />
                                    <asp:BoundField DataField="WritSubjectCatID" HeaderText="WritSubCatID" />
                                    <asp:BoundField DataField="WritSubjectCatName" HeaderText="रिट विषय समूहको नाम">
                                        <ItemStyle Wrap="True" />
                                        <HeaderStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Active" HeaderText="सक्रिय" />
                                    <asp:BoundField DataField="Action" HeaderText="Action" />
                                    <asp:CommandField ShowSelectButton="True" />
                                </Columns>
                                <RowStyle BackColor="#EFF3FB" />
                                <EditRowStyle BackColor="#2461BF" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle BackColor="White" />
                            </asp:GridView>
                        </td>
                        <td style="width: 100px; height: 21px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 21px">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 34px" valign="top">
                            <asp:Label ID="Label6" runat="server" Text="रिट शिर्षक" SkinID="Unicodelbl"></asp:Label></td>
                        <td style="width: 100px">
                            <asp:TextBox ID="txtWritSubCatTitle" runat="server" Height="53px" TextMode="MultiLine"
                                Width="423px"></asp:TextBox></td>
                        <td style="width: 100px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 34px; height: 25px;" valign="top">
                            <asp:Label ID="Label7" runat="server" SkinID="Unicodelbl" Text="सक्रिय"></asp:Label></td>
                        <td style="width: 100px; height: 25px;">
                            <asp:CheckBox ID="chkWritSubCatTitleActive" runat="server" /></td>
                        <td style="width: 100px; height: 25px;">
                            <asp:Button ID="btnAddWritSubCatTitle" runat="server" OnClick="btnAddWritSubCatTitle_Click"
                                SkinID="Add" Text="+" /></td>
                    </tr>
                    <tr>
                        <td style="width: 34px">
                        </td>
                        <td style="width: 100px">
                            <asp:GridView ID="grdWritSubCatTitle" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="grdWritSubCatTitle_SelectedIndexChanged" OnRowCreated="grdWritSubCatTitle_RowCreated" Width="423px">
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="WritSubjectID" HeaderText="WritSubjectID" />
                                    <asp:BoundField DataField="WritSubjectCatID" HeaderText="WritSubjectCatID" />
                                    <asp:BoundField DataField="WritSubjectCatTitleID" HeaderText="WritSubjectCatTitleID" />
                                    <asp:BoundField DataField="WritSubjectCatTitleName" HeaderText="रिट विषय समूहको शिर्षक">
                                        <HeaderStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Active" HeaderText="सक्रिय" />
                                    <asp:BoundField DataField="Action" HeaderText="Action" />
                                    <asp:CommandField ShowSelectButton="True" />
                                </Columns>
                                <RowStyle BackColor="#EFF3FB" />
                                <EditRowStyle BackColor="#2461BF" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle BackColor="White" />
                            </asp:GridView>
                        </td>
                        <td style="width: 100px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 34px" valign="top">
                            <asp:Label ID="Label8" runat="server" SkinID="Unicodelbl" Text="रिट उप शिर्षक" Width="108px"></asp:Label></td>
                        <td style="width: 100px">
                            <asp:TextBox ID="txtWritSubCatSubTitle" runat="server" Height="51px" TextMode="MultiLine"
                                Width="423px"></asp:TextBox></td>
                        <td style="width: 100px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 34px; height: 21px;">
                            <asp:Label ID="Label9" runat="server" Text="सक्रिय" SkinID="Unicodelbl"></asp:Label></td>
                        <td style="width: 100px; height: 21px;">
                            <asp:CheckBox ID="chkWritSubCatSubTitleActive" runat="server" /></td>
                        <td style="width: 100px; height: 21px;">
                            <asp:Button ID="btnAddWritSubCatSubTitle" runat="server" OnClick="btnAddWritSubCatSubTitle_Click"
                                SkinID="Add" Text="+" /></td>
                    </tr>
                    <tr>
                        <td style="width: 34px; height: 21px;">
                        </td>
                        <td style="width: 100px; height: 21px;"><asp:GridView ID="grdWritSubCatSubTitle" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="grdWritSubCatSubTitle_SelectedIndexChanged" OnRowCreated="grdWritSubCatSubTitle_RowCreated" Width="423px">
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="WritSubjectID" HeaderText="WritSubjectID" />
                                <asp:BoundField DataField="WritSubjectCatID" HeaderText="WritSubjectCatID" />
                                <asp:BoundField DataField="WritSubjectCatTitleID" HeaderText="WritSubjectCatTitleID" />
                                <asp:BoundField DataField="WritSubjectCatSubTitleID" HeaderText="WritSubjectCatSubTitleID" />
                                <asp:BoundField DataField="WritSubjectCatSubTitleName" HeaderText="रिट विषय समूहको उप-समूह">
                                    <HeaderStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Active" HeaderText="सक्रिय" />
                                <asp:BoundField DataField="Action" HeaderText="Action" />
                                <asp:CommandField ShowSelectButton="True" />
                            </Columns>
                            <RowStyle BackColor="#EFF3FB" />
                            <EditRowStyle BackColor="#2461BF" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                        </td>
                        <td style="width: 100px; height: 21px;">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 34px">
                        </td>
                        <td style="width: 100px">
                        </td>
                        <td style="width: 100px">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 30px">
                <table>
                    <tr>
                        <td style="width: 100px">
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" SkinID="Normal"
                    Text="Submit" /></td>
                        <td style="width: 100px">
                <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" SkinID="Cancel"
                    Text="Cancel" /></td>
                    </tr>
                </table>
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
    
    
    
    
    
</asp:Content>

