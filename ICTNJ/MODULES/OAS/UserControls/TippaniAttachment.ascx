<%@ Control AutoEventWireup="true" CodeFile="TippaniAttachment.ascx.cs" Inherits="MODULES_OAS_UserControls_TippaniAttachment" Language="C#" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<div style="width: 100%; height: auto">
    <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground" DropShadow="True" PopupControlID="programmaticPopup"
        PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForModalPopup">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none; width: 350px; padding: 10px">
        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD; border: solid 1px Gray; color: Black; text-align: center;">
            Save Status
        </asp:Panel>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
        <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click" Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    <asp:Label ID="Label1" runat="server" SkinID="UnicodeHeadlbl" Text="टिप्पणीको कागजपत्र"></asp:Label>
    <br />
    <table width="725">
        <tr>
            <td style="width: 125px">
                &nbsp;&nbsp;
                <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="कगजपत्र"></asp:Label></td>
            <td style="width: 600px">
                <asp:FileUpload ID="fupAttachment" runat="server" Width="400px" /></td>
        </tr>
        <tr>
            <td style="width: 125px" valign="top">
                &nbsp;&nbsp;
                <asp:Label ID="Label3" runat="server" SkinID="Unicodelbl" Text="बिबरण"></asp:Label></td>
            <td style="width: 600px">
                <asp:TextBox ID="txtDescription" runat="server" Height="50px" SkinID="Unicodetxt" TextMode="MultiLine" Width="512px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 125px">
            </td>
            <td style="width: 600px">
                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" SkinID="Add" Text="Add" /></td>
        </tr>
        <tr>
            <td style="width: 125px">
            </td>
            <td style="width: 600px">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                <asp:GridView ID="grdAttachment" runat="server" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333" OnRowDataBound="grdAttachment_RowDataBound"
                    Width="525px" OnRowDeleting="grdAttachment_RowDeleting">
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:BoundField DataField="OrgID" HeaderText="OrgID" />
                        <asp:BoundField DataField="TippaniID" HeaderText="TippaniID" />
                        <asp:BoundField DataField="TippaniProcessID" HeaderText="TippaniProcessID" />
                        <asp:BoundField DataField="AttachmentID" HeaderText="AttachmentID" />
                        <asp:TemplateField HeaderText="कगजपत्रको नाम">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkFile" runat="server" SkinID="Tippani" Text='<%# Eval("DocumentName") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="बिबरण">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle Width="270px" Wrap="True" />
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowDeleteButton="True" />
                    </Columns>
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <EditRowStyle BackColor="#999999" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="grdAttachment" EventName="RowDeleting" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</div>
