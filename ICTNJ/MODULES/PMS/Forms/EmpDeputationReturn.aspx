<%@ Page Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master" AutoEventWireup="true" CodeFile="EmpDeputationReturn.aspx.cs" Inherits="MODULES_PMS_Forms_EmpDeputationReturn" Title="PMS | DEPUTATION RETURN" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" style="display:none"/>
        <ajaxToolkit:ModalPopupExtender runat="server" ID="programmaticModalPopup"
            BehaviorID="programmaticModalPopupBehavior"
            TargetControlID="hiddenTargetControlForModalPopup"
            PopupControlID="programmaticPopup" 
            BackgroundCssClass="modalBackground"
            DropShadow="true"
            PopupDragHandleControlID="programmaticPopupDragHandle"
            RepositionMode="RepositionOnWindowScroll" >
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none;
        width: 350px; padding: 10px">
        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD;
            border: solid 1px Gray; color: Black; text-align: center;">
            Status
        </asp:Panel>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
<asp:Label id="lblStatusMessage" runat="server" Text="Label"></asp:Label> 
</ContentTemplate>
        </asp:UpdatePanel>
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
            Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    <br />
    <asp:Label ID="Label2" runat="server" SkinID="UnicodeHeadlbl" Text="काज फिर्ति"></asp:Label><br />
    <br />
    <table width="900" style="height: 450px">
        <tr>
            <td colspan="3" style="height: 7px">
                <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="काजमा गऐका कर्मचारीहरु"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="3" style="height: 160px" valign="top">
                <hr />
                &nbsp;<br />
                <asp:UpdatePanel id="UpdatePanel1" runat="server">
                    <contenttemplate>
<asp:Panel id="pnlEmpDepRetrun" runat="server" Width="900px" Height="150px" ScrollBars="Auto"><asp:GridView id="grdEmpDepReturn" runat="server" Width="600px" Height="150px" SkinID="Unicodegrd" OnRowCreated="grdEmpDepReturn_RowCreated" AutoGenerateColumns="False" GridLines="None" ForeColor="#333333" CellPadding="0">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="EmpID" HeaderText="EmpID">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="EmpName" HeaderText="कर्मचारीको नाम">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="GenderDesc" HeaderText="लिंग">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="OrgID" HeaderText="OrgID">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="OrgName" HeaderText="कार्यालय">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DesID" HeaderText="DesID">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DesName" HeaderText="पद">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="PostID" HeaderText="PostID">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="PostFromDate" HeaderText="FromDate">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DecisionDate" HeaderText="काज मिति">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DepOrgID" HeaderText="DepOrgID">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DepOrgName" HeaderText="काज कार्यालय">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="LeaveDate" HeaderText="काज गएको मिति">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="फिर्ति मिति">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
<ItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ReturnDate") %>' Width="82px"></asp:TextBox>
                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AutoComplete="False"
                                    Mask="9999/99/99" MaskType="Date" TargetControlID="TextBox1">
                                </ajaxToolkit:MaskedEditExtender>
                            
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="Responsibilities" HeaderText="कैफिएत">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
</Columns>

<RowStyle BackColor="#F7F6F3" Height="10px" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> </asp:Panel> 
</contenttemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Button ID="btnSubmit" runat="server" SkinID="Normal" Text="Submit" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnCancel" runat="server" SkinID="Cancel" Text="Cancel" /></td>
        </tr>
    </table>
</asp:Content>

