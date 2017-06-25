<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CaseSearchForCBA.ascx.cs" Inherits="MODULES_CMS_UserControls_CaseSearchForCBA" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />

<ajaxtoolkit:modalpopupextender
    id="programmaticModalPopup" runat="server" backgroundcssclass="modalBackground" 
     dropshadow="True" popupcontrolid="programmaticPopup"
    popupdraghandlecontrolid="programmaticPopupDragHandle" repositionmode="RepositionOnWindowScroll"
    targetcontrolid="hiddenTargetControlForModalPopup">
</ajaxtoolkit:modalpopupextender>
<asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="padding-right: 10px;
        display: none; padding-left: 10px; padding-bottom: 10px; width: 350px; padding-top: 10px">
        
        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="border-right: gray 1px solid;
            border-top: gray 1px solid; border-left: gray 1px solid; cursor: move; color: black;
            border-bottom: gray 1px solid; background-color: #dddddd; text-align: center">
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
<table width="1000px">
    <tr>
        <td >
            <table width="1000px">
                <tr>
                    <td valign="top" style="width: 329px" >
                        <asp:Label ID="Label5" runat="server" SkinID="Unicodelbl" Text="कज लिस्ट मिति" Width="117px"></asp:Label></td>
                    <td valign="top" >
                        <asp:TextBox ID="txtCauseListDate" runat="server" MaxLength="35" SkinID="PCStxt" 
                            Width="130px"></asp:TextBox>
                        <ajaxToolkit:maskededitextender id="Maskededitextender4" runat="server" autocomplete="False"
                            mask="9999/99/99" masktype="Date" targetcontrolid="txtCauseListDate" ClearMaskOnLostFocus="False">
                </ajaxToolkit:maskededitextender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 329px">
                    </td>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" SkinID="Normal"
                            Text="Search" Width="68px" />
                        <asp:Button ID="btnCancelSearch" runat="server" OnClick="btnCancelSearch_Click" SkinID="Cancel"
                            Text="Cancel" Width="68px" /></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td style="height: 171px" >
            <asp:Panel ID="pnlCase" runat="server" Height="150px" ScrollBars="Auto" Width="1000px">
           
            <%--<div id="divGrid" style="border-width:5px; overflow: auto;width:1000px; height: 470px">--%>
            <asp:GridView ID="grdCase" runat="server" AutoGenerateColumns="False" CellPadding="0"
                ForeColor="#333333" SkinID="Unicodegrd" Width="983px" OnRowDataBound="grdCase_RowDataBound" >
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <Columns>
                    <asp:TemplateField>   
                    <HeaderStyle BackColor="Transparent" />                                                
                            <ItemTemplate>
                                <asp:CheckBox ID="chk"  runat="server"  />
                            </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        </asp:TemplateField>
                    <asp:BoundField DataField="CaseTypeID" HeaderText="Case Type ID" />
                    <asp:BoundField DataField="CaseRegDate" HeaderText="दर्ता मिति" />
                    <asp:BoundField DataField="CaseID" HeaderText="CaseID" />
                    <asp:BoundField DataField="RegNo" HeaderText="दर्ता नं" />
                    <asp:BoundField DataField="CaseNo" HeaderText="मुद्दा नं" />
                    <asp:BoundField DataField="CaseTypeName" HeaderText="मुद्दाको प्रकार" />
                    <asp:BoundField DataField="Appelant" HeaderText="वादिहारु" />
                    <asp:BoundField DataField="Respondant" HeaderText="प्रतिवादिहारु" />
                    <asp:BoundField DataField="ClDate" HeaderText="कज लिस्ट मिति" />
                    <asp:BoundField DataField="ClEntryTypeName" HeaderText="कज लिस्ट प्रकार" />
                   <%-- <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1"  runat="server" CausesValidation="False" CommandName="Select"
                                Text="Select"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                </Columns>
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
            <%--</div>--%>
            </asp:Panel>
            <%--<input id="hdnFld" type="hidden" />--%>
        </td>
    </tr>
</table>