<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true" CodeFile="EditMaagFaaram.aspx.cs" Inherits="MODULES_OAS_MaagFaaram_EditMaagFaaram" Title="OAS | Maag Faaram Edit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register Src="../UserControls/MaagFaaramSearch.ascx" TagName="MaagFaaramSearch"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
&nbsp;<asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
    <ajaxtoolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground"
        BehaviorID="programmaticModalPopupBehavior" DropShadow="True" PopupControlID="programmaticPopup"
        PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
        TargetControlID="hiddenTargetControlForModalPopup">
    </ajaxtoolkit:ModalPopupExtender>
    <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="padding-right: 10px;
        display: none; padding-left: 10px; padding-bottom: 10px; width: 350px; padding-top: 10px">
        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="border-right: gray 1px solid;
            border-top: gray 1px solid; border-left: gray 1px solid; cursor: move; color: black;
            border-bottom: gray 1px solid; background-color: #dddddd; text-align: center">
            Status
        </asp:Panel>
        <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
        &nbsp;&nbsp;
        <br />
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
            Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    <br />
    <div id="div1" style="height: 800px">
    
        <asp:Label ID="Label1" runat="server" SkinID="UnicodeHeadlbl" Text="माग फारामको सच्याउने"></asp:Label><br />
        <br />
        <uc1:maagfaaramsearch id="appMaagHeadControl" runat="server" approve="false" displayappyesno="false"
            displayissueflag="false" edit="true" selectissue="true" Issue="false" SelectApproval="true">
    </uc1:maagfaaramsearch>

        <asp:Panel ID="pnlMaagDetail" runat="server" Height="250px" Width="1000px">
            <table style="width: 1024px">
                <tr>
                    <td style="width: 100px" valign="top">
                        <table style="width: 800px">
                            <tr>
                                <td style="width: 60px" valign="top">
                                </td>
                                <td style="width: 250px" valign="top">
                                    <asp:TextBox ID="txtReqNo" runat="server" Visible="False"></asp:TextBox></td>
                                <td style="width: 70px" valign="top">
                                </td>
                                <td style="width: 404px" valign="top">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 60px" valign="top">
                                    <asp:Label ID="Label3" runat="server" SkinID="Unicodelbl" Text="शाखा" Width="55px"></asp:Label></td>
                                <td style="width: 250px" valign="top">
                                    <asp:DropDownList ID="ddlOrgUnits_Rqd" runat="server" AppendDataBoundItems="True"
                                        ToolTip="शाखा" Width="170px">
                                    </asp:DropDownList></td>
                                <td style="width: 70px" valign="top">
                                    <asp:Label ID="Label6" runat="server" SkinID="Unicodelbl" Text="प्रयोजन" Width="55px"></asp:Label></td>
                                <td style="width: 404px" valign="top">
                                    <asp:TextBox ID="txtPurpose" runat="server" Width="350px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="width: 60px" valign="top">
                                    <asp:Label ID="Label5" runat="server" SkinID="Unicodelbl" Text="मिति"></asp:Label></td>
                                <td style="width: 250px" valign="top">
                                    <asp:TextBox ID="txtMaagDate_RDT" runat="server" ToolTip="मिति" Width="88px"></asp:TextBox>
                                    <ajaxtoolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" AutoComplete="False"
                                        ClearMaskOnLostFocus="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtMaagDate_RDT">
                                    </ajaxtoolkit:MaskedEditExtender>
                                </td>
                                <td style="width: 70px" valign="top">
                                </td>
                                <td style="width: 404px" valign="top">
                                    <asp:RadioButtonList ID="rdblstIssueType" runat="server" AutoPostBack="False" RepeatDirection="Horizontal"
                                        SkinID="Unicoderadio" Width="355px">
                                        <asp:ListItem Selected="True" Value="P">बजारबाट खरिद गरी दिनु</asp:ListItem>
                                        <asp:ListItem Value="S">मौज्दातबाट दिनु</asp:ListItem>
                                    </asp:RadioButtonList></td>
                            </tr>
                            <tr>
                                <td colspan="4" valign="top">
                                    <hr />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 60px" valign="top">
                                    <asp:Label ID="Label4" runat="server" SkinID="Unicodelbl" Text="समूह" Width="40px"></asp:Label></td>
                                <td style="width: 250px" valign="top">
                                    <asp:DropDownList ID="ddlItemsCategory_Rqd" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlItemsCategory_Rqd_SelectedIndexChanged"
                                        ToolTip="समूह" Width="170px">
                                    </asp:DropDownList></td>
                                <td style="width: 70px" valign="top">
                                    <asp:Label ID="Label9" runat="server" SkinID="Unicodelbl" Text="उप-समूह" Width="58px"></asp:Label></td>
                                <td style="width: 404px" valign="top">
                                    <asp:DropDownList ID="ddlItemsSubCategory_Rqd" runat="server" AppendDataBoundItems="True"
                                        AutoPostBack="True" OnSelectedIndexChanged="ddlItemsSubCategory_Rqd_SelectedIndexChanged"
                                        ToolTip="उप-समूह" Width="170px">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td style="width: 60px" valign="top">
                                    <asp:Label ID="lblItems" runat="server" SkinID="Unicodelbl" Text="सामान" Width="46px"></asp:Label></td>
                                <td style="width: 250px" valign="top">
                                    <asp:DropDownList ID="ddlItems_Rqd" runat="server" AppendDataBoundItems="True" ToolTip="सामान"
                                        Width="170px">
                                    </asp:DropDownList></td>
                                <td style="width: 70px" valign="top">
                                    <asp:Label ID="Label7" runat="server" SkinID="Unicodelbl" Text="परिमाण" Width="55px"></asp:Label></td>
                                <td style="width: 404px" valign="top">
                                    <asp:TextBox ID="txtReqQty_Rqd" runat="server" MaxLength="4" ToolTip="परिमाण" Width="65px"></asp:TextBox>
                                    <ajaxtoolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                        FilterType="Numbers" TargetControlID="txtReqQty_Rqd">
                                    </ajaxtoolkit:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 60px" valign="top">
                                    <asp:Label ID="Label8" runat="server" SkinID="Unicodelbl" Text="कैफियत" Width="55px"></asp:Label></td>
                                <td style="width: 250px" valign="top">
                                    <asp:TextBox ID="txtRemarks" runat="server" Height="69px" TextMode="MultiLine" Width="240px"></asp:TextBox></td>
                                <td style="width: 70px" valign="top">
                                </td>
                                <td style="width: 404px" valign="top">
                                    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" OnClientClick="javascript:return validate(1);"
                                        SkinID="Normal" Text="Add" /></td>
                            </tr>
                            <tr>
                                <td colspan="4" valign="top">
                                    <hr />
                                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" SkinID="Normal"
                                        Text="Submit" />
                                    <br />
                                    <hr />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px" valign="top">
                        <asp:Panel ID="Panel1" runat="server" Height="150px" ScrollBars="Auto" Width="1000px">
                            <asp:GridView ID="grdItems" runat="server" AutoGenerateColumns="False" OnRowDataBound="grdItems_RowDataBound"
                                OnRowDeleting="grdItems_RowDeleting" OnSelectedIndexChanged="grdItems_SelectedIndexChanged"
                                SkinID="Unicodegrd" Width="800px">
                                <Columns>
                                    <asp:TemplateField HeaderText="सि.नं.">
                                        <ItemStyle Width="30px" />
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ITEMSCATEGORYID" HeaderText="ItemCategoryID" />
                                    <asp:BoundField DataField="ITEMSCATEGORYNAME" HeaderText="समूह">
                                        <ItemStyle Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ITEMSSUBCATEGORYID" HeaderText="ItemsSubCategoryID" />
                                    <asp:BoundField DataField="ITEMSSUBCATEGORYNAME" HeaderText="उप-समूह">
                                        <ItemStyle Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ITEMSID" HeaderText="ItemsID" />
                                    <asp:BoundField DataField="ITEMSNAME" HeaderText="सामानको नाम">
                                        <ItemStyle Width="150px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SPECIFICATIONS" HeaderText="स्पेसिफिकेशन">
                                        <ItemStyle Width="200px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="REQQTY" HeaderText="सामानको परिमाण" />
                                    <asp:BoundField DataField="ITEMSUNITNAME" HeaderText="इकाई">
                                        <ItemStyle Width="50px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="JIKHAPANO" HeaderText="जि.खा.पा.नं.">
                                        <ItemStyle Width="70px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="REMARKS" HeaderText="कैफियत">
                                        <ItemStyle Width="50px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ACTION" HeaderText="Action" />
                                    <asp:CommandField ShowSelectButton="True">
                                        <ItemStyle Width="50px" />
                                    </asp:CommandField>
                                    <asp:CommandField ShowDeleteButton="True">
                                        <ItemStyle Width="50px" />
                                    </asp:CommandField>
                                </Columns>
                            </asp:GridView>
                            &nbsp;</asp:Panel>
                    </td>
                </tr>
            </table>
            &nbsp;</asp:Panel>
    </div></contenttemplate>
    </asp:UpdatePanel>
</asp:Content>

