<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MaagFaaramSearch.ascx.cs" Inherits="MODULES_OAS_UserControls_MaagFaaramSearch" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
<ajaxtoolkit:modalpopupextender id="programmaticModalPopup" runat="server" backgroundcssclass="modalBackground"
    dropshadow="True" popupcontrolid="programmaticPopup" popupdraghandlecontrolid="programmaticPopupDragHandle"
    repositionmode="RepositionOnWindowScroll" targetcontrolid="hiddenTargetControlForModalPopup">
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
<table style="width: 640px">
    <tr>
        <td style="width: 70px" valign="top">
            <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="शाखा" Width="60px"></asp:Label></td>
        <td style="width: 250px" valign="top">
            <asp:DropDownList ID="ddlOrgUnits" runat="server" AppendDataBoundItems="True" Width="170px">
            </asp:DropDownList></td>
        <td style="width: 70px" valign="top">
            <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="मिति"></asp:Label></td>
        <td valign="top">
            <asp:TextBox ID="txtReqDate" runat="server" Width="96px"></asp:TextBox>
            <ajaxtoolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AutoComplete="False"
                ClearMaskOnLostFocus="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtReqDate">
            </ajaxtoolkit:MaskedEditExtender>
        </td>
    </tr>
    <tr>
        <td style="width: 70px" valign="top">
        </td>
        <td style="width: 250px" valign="top">
            <asp:Button ID="btnMaagHeadSearch" runat="server" OnClick="btnMaagHeadSearch_Click"
                SkinID="Normal" Text="Search" />
            <asp:Button ID="btnMaagHeadCancel" runat="server" Text="Cancel" SkinID="Cancel" OnClick="btnMaagHeadCancel_Click" /></td>
        <td style="width: 70px" valign="top">
        </td>
        <td valign="top">
        </td>
    </tr>
</table>
<table style="width: 915px">
    <tr>
        <td valign="top">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td valign="top">
            <asp:Panel ID="pnlMaagHeadSearch" runat="server" Height="150px" ScrollBars="Auto" Width="1024px">
                <asp:GridView ID="grdMaagHead" runat="server" AutoGenerateColumns="False" OnRowDataBound="grdMaagHead_RowDataBound"
                    SkinID="Unicodegrd" Width="1000px" OnSelectedIndexChanged="grdMaagHead_SelectedIndexChanged">
                    <Columns>
                        <asp:TemplateField HeaderText="सि.नं.">
                            <ItemStyle Width="30px" />
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ORGID" HeaderText="का.आई.डी." />
                        <asp:BoundField DataField="ORGNAME" HeaderText="कार्यालय" />
                        <asp:BoundField DataField="UNITID" HeaderText="शा.आई.डी." />
                        <asp:BoundField DataField="UNITNAME" HeaderText="शाखा">
                        <itemstyle width="80px"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="REQNO" HeaderText="माग नं." >
                        <itemstyle width="70px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="REQDATE" HeaderText="माग मिति">
                        <itemstyle width="70px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="REQPERSON" HeaderText="माग गर्ने">
                        <itemstyle width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="REQPURPOSE" HeaderText="प्रयोजन">
                        <itemstyle width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="APPPERSON" HeaderText="आदेश दिने">
                        <itemstyle width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="APPDATE" HeaderText="आदेश मिति">
                        <itemstyle width="70px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="APPYESNO" HeaderText="AppYesNo" />
                        <asp:BoundField DataField="APPYESNODESC" HeaderText="जारी गर्ने ?" > 
                        <itemstyle width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ISSUEFLAG" HeaderText="IssueFlag" />
                        <asp:BoundField DataField="ISSUEFLAGDESC" HeaderText="जारी भएको">
                        <itemstyle width="60px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ISSUETYPE" HeaderText="IssueType" />
                        <asp:CommandField SelectText="Edit" ShowSelectButton="True">
                        <itemstyle width="60px" />
                        </asp:CommandField>
                        <asp:CommandField SelectText="Approve" ShowSelectButton="True">
                        <itemstyle width="60px" />
                        </asp:CommandField>
                        <asp:CommandField SelectText="Issue" ShowSelectButton="True">
                        <itemstyle width="60px" />
                        </asp:CommandField>
                        <asp:BoundField DataField="REQBY" HeaderText="ReqBy" />
                        <asp:BoundField DataField="APPBY" HeaderText="AppBy" />
                    </Columns>
                </asp:GridView>
            </asp:Panel>
        </td>
    </tr>
</table>
