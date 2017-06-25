<%@ Page AutoEventWireup="true" CodeFile="TippaniDetailSearch.aspx.cs" Inherits="MODULES_OAS_Tippani_TippaniDetailSearch"
    Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" Title="OAS | Tippani Search" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager ID="sc1" runat="server">
    </asp:ScriptManager>
    <div style="width: 100%; height: 500px">
        <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
        <cc1:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior"
            DropShadow="True" PopupControlID="programmaticPopup" PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
            TargetControlID="hiddenTargetControlForModalPopup">
        </cc1:ModalPopupExtender>
        <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="padding-right: 10px; display: none; padding-left: 10px;
            padding-bottom: 10px; width: 350px; padding-top: 10px">
            <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="border-right: gray 1px solid; border-top: gray 1px solid;
                border-left: gray 1px solid; cursor: move; color: black; border-bottom: gray 1px solid; background-color: #dddddd; text-align: center">
                <asp:Label ID="lblStatus" runat="server" Text="Status"></asp:Label>&nbsp;</asp:Panel>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <asp:Label ID="lblStatusMessage" runat="server" Text=""></asp:Label>
                    <br />
                    <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click" Text="OK" Width="58px" />
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
        </asp:Panel>
        <br />
        <table>
            <tr>
                <td>
                    <asp:Label ID="orgNameLbl" runat="server" SkinID="Unicodelbl">Organisation</asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddlOrg_Rqd" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlOrg_Rqd_SelectedIndexChanged"
                        SkinID="Unicodeddl" Width="200px">
                    </asp:DropDownList><label style="color: Red">*</label></td>
                <td style="width: 100px">
                    &nbsp;</td>
                <td style="width: 100px">
                    &nbsp;</td>
                <td style="width: 100px">
                    </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="tippaniLbl" runat="server" SkinID="Unicodelbl">Tippani Subject:</asp:Label></td>
                <td>
                    <label style="color: Red">
                        <asp:UpdatePanel id="UpdatePanel1" runat="server">
                            <contenttemplate>
                    <asp:DropDownList ID="ddlTipaniSubject_Rqd" runat="server" SkinID="unicodeddl" Width="200px">
                    </asp:DropDownList>*
</contenttemplate>
                            <triggers>
<asp:AsyncPostBackTrigger ControlID="ddlOrg_Rqd" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
                        </asp:UpdatePanel></label></td>
                <td style="width: 100px;">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="fileNoLbl" runat="server" SkinID="Unicodelbl">File No:</asp:Label></td>
                <td>
                    <asp:TextBox ID="fileNoTxt" runat="server" SkinID="Unicodetxt" Width="200px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="fromDateLbl" runat="server" SkinID="Unicodelbl">From Date:</asp:Label></td>
                <td>
                    <asp:TextBox ID="fromDateTxt" runat="server" SkinID="Unicodetxt" Width="196px"></asp:TextBox>
                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AutoComplete="false" Mask="9999/99/99" MaskType="Date" TargetControlID="fromDateTxt">
                    </cc1:MaskedEditExtender>
                </td>
                <td style="width: 100px">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="toDateLbl" runat="server" SkinID="Unicodelbl">To Date:</asp:Label></td>
                <td>
                    <asp:TextBox ID="toDateTxt" runat="server" SkinID="Unicodetxt" Width="200px"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" AutoComplete="false" Mask="9999/99/99" MaskType="Date" TargetControlID="toDateTxt">
                </cc1:MaskedEditExtender>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="tippaniSubLbl" runat="server" SkinID="Unicodelbl">Tippani Status:</asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddlTippaniStatus" runat="server" SkinID="unicodeddl" Width="200px">
                    </asp:DropDownList></td>
                <td style="width: 100px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td style="text-align: right">
                    <asp:Button ID="searchBtn" runat="server" OnClick="searchBtn_Click" SkinID="Normal" Text="Search" />
                    <asp:Button ID="cancelBtn" runat="server" OnClick="cancelBtn_Click" SkinID="cancel" Text="Cancel" />
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
                <td style="height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
                <td style="height: 10px">
                </td>
                <td style="height: 10px; text-align: right">
                </td>
            </tr>
        </table>
        <div id="gridDiv" runat="server">
            <asp:GridView ID="tippaniDetailGrid" runat="server" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333" OnRowDataBound="tippaniDetailGrid_RowDataBound"
                OnSelectedIndexChanged="tippaniDetailGrid_SelectedIndexChanged" Width="95%" SkinID="Unicodegrd">
                <Columns>
                    <asp:BoundField DataField="OrgID" />
                    <asp:BoundField DataField="TippaniID" />
                    <asp:BoundField DataField="TippaniSubjectID" />
                    <asp:TemplateField HeaderText="S.N">
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="TippaniSubject" HeaderText="Tippani Subject" />
                    <asp:BoundField DataField="TippaniOn" HeaderText="Tippani On" />
                    <asp:BoundField DataField="TippaniText" HeaderText="Tippani Text" />
                    <asp:BoundField DataField="FileNo" HeaderText="File No" />
                    <asp:BoundField DataField="TippaniStatus" HeaderText="Status" />
                    <asp:CommandField SelectText="View Process" ShowSelectButton="True" Visible="False" >
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:CommandField>
                    <asp:TemplateField>
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkPrintableReport" runat="server" CommandName="Select" OnClick="lnkPrintableReport_Click" SkinID="Tippani">Template Report</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkTippaniText" runat="server" CommandName="Select" OnClick="lnkTippaniText_Click" SkinID="Tippani">View Process</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Select" OnClick="lnkEdit_Click" SkinID="Tippani">Edit Tippani</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <EditRowStyle BackColor="#999999" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
        </div>
        <br />
    </div>
</asp:Content>
