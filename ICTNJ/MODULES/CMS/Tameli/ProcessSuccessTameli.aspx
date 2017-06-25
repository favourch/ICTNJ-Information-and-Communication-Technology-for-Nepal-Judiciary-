<%@ Page Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" AutoEventWireup="true" CodeFile="ProcessSuccessTameli.aspx.cs" Inherits="MODULES_CMS_Tameli_ProcessSuccessTameli" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <asp:ScriptManager runat="server" id="scrptmngr1">
    </asp:ScriptManager>
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
    <table width="1000">
        <tr>
            <td colspan="5">
                <table width="1000px">
                <tr>
                    <td style="width: 105px" valign="top" >
                        <asp:Label ID="Label3" runat="server" SkinID="Unicodelbl" Text="मुद्दाको प्रकार"
                            Width="105px"></asp:Label></td>
                    <td style="width: 229px" valign="top" id="TD1" runat="server" >
                        <asp:DropDownList ID="ddlCaseType" runat="server" SkinID="Unicodeddl" Width="150px" DataTextField="CaseTypeName" DataValueField="CaseTypeID">
                        </asp:DropDownList></td>
                    <td style="width: 94px" >
                    </td>
                    <td style="width: 100px" valign="top" >
                        <asp:Label ID="Label5" runat="server" SkinID="Unicodelbl" Text="मुद्दा नं" Width="105px"></asp:Label></td>
                    <td valign="top" >
                        <asp:TextBox ID="txtCaseNo" runat="server" MaxLength="35" SkinID="PCStxt" ToolTip="First Name"
                            Width="130px"></asp:TextBox><ajaxToolkit:maskededitextender id="Maskededitextender2" runat="server"
                                autocomplete="False" clearmaskonlostfocus="False" mask="999-CC-9999" targetcontrolid="txtCaseNo"> </ajaxToolkit:maskededitextender></td>
                </tr>
                <tr>
                    <td style="width: 105px" valign="top" >
                        <asp:Label ID="Label6" runat="server" SkinID="Unicodelbl" Text="दर्ता नं" Width="105px"></asp:Label></td>
                    <td valign="top" style="width: 229px" >
                        <asp:TextBox ID="txtRegNo" runat="server" MaxLength="35" SkinID="PCStxt" ToolTip="First Name"
                            Width="130px"></asp:TextBox>
                        <ajaxToolkit:maskededitextender id="Maskededitextender3" runat="server" autocomplete="False"
                            mask="99-999-99999" targetcontrolid="txtRegNo" ClearMaskOnLostFocus="False">
                </ajaxToolkit:maskededitextender>
                    </td>
                    <td style="width: 94px" >
                    </td>
                    <td valign="top" >
                        <asp:Label ID="Label7" runat="server" SkinID="Unicodelbl" Text="दर्ता मिति" Width="105px"></asp:Label></td>
                    <td valign="top" >
                        <asp:TextBox ID="txtRegDate" runat="server" MaxLength="35" SkinID="PCStxt" ToolTip="First Name"
                            Width="130px"></asp:TextBox>
                        <ajaxToolkit:maskededitextender id="Maskededitextender4" runat="server" autocomplete="False"
                            mask="9999/99/99" masktype="Date" targetcontrolid="txtRegDate" ClearMaskOnLostFocus="False">
                </ajaxToolkit:maskededitextender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 105px" >
                        <asp:Label ID="Label8" runat="server" SkinID="Unicodelbl" Text="वादिको नाम"
                            Width="105px"></asp:Label></td>
                    <td style="width: 229px" >
                        <asp:TextBox ID="txtAppelantName" runat="server" MaxLength="35" SkinID="PCStxt" ToolTip="First Name"
                            Width="225px"></asp:TextBox></td>
                    <td style="width: 94px" >
                    </td>
                    <td >
                        <asp:Label ID="Label9" runat="server" SkinID="Unicodelbl" Text="प्रतिवादिको नाम"
                            Width="115px"></asp:Label></td>
                    <td valign="top" >
                        <asp:TextBox ID="txtRespondantName" runat="server" MaxLength="35" SkinID="PCStxt"
                            ToolTip="First Name" Width="225px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 105px; height: 26px;">
                    </td>
                    <td style="width: 229px; height: 26px;">
                    </td>
                    <td style="width: 94px; height: 26px;">
                    </td>
                    <td style="height: 26px">
                    </td>
                    <td style="height: 26px">
                        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" SkinID="Normal"
                            Text="Search" Width="68px" />
                        <asp:Button ID="btnCancelSearch" runat="server" OnClick="btnCancelSearch_Click" SkinID="Cancel"
                            Text="Cancel" Width="68px" /></td>
                </tr>
            </table>    
            </td>
        </tr>
        <tr>
            <td colspan="5">
                &nbsp;<asp:GridView ID="grdTameli" runat="server" AutoGenerateColumns="False" CellPadding="0"
                    ForeColor="#333333" 
                    SkinID="Unicodegrd" Width="983px" OnRowDataBound="grdTameli_RowDataBound">
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:BoundField DataField="CaseTypeID" HeaderText="Case Type ID" />
                        <asp:BoundField DataField="CaseRegDate" HeaderText="दर्ता मिति" />
                        <asp:BoundField DataField="CaseID" HeaderText="CaseID" />
                        <asp:BoundField DataField="RegNo" HeaderText="दर्ता नं" />
                        <asp:BoundField DataField="CaseNo" HeaderText="मुद्दा नं" />
                        <asp:BoundField DataField="CaseTypeName" HeaderText="मुद्दाको प्रकार" />
                        <asp:BoundField DataField="SubjectName" HeaderText="SubjectName" />
                        <asp:BoundField DataField="OrgName" HeaderText="Organisation" />
                        <asp:BoundField DataField="TamildaarName" HeaderText="Tamildaar Name" />
                        <asp:BoundField DataField="TameliDate" HeaderText="TameliDate" />
                        <asp:BoundField DataField="TameliTypeName" HeaderText="Tameli Type" />
                        <asp:BoundField DataField="WitnessFullName" HeaderText="Witness Person" />
                        <asp:BoundField DataField="LitigantName" HeaderText="Litigant " />
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                                    Text="Select"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <EditRowStyle BackColor="#999999" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 100px;" valign="top" >
                <asp:Label ID="Label4" runat="server" SkinID="Unicodelbl" Text="Verified Date"></asp:Label></td>
            <td style="width: 200px; height: 19px" valign="top" >
                <asp:TextBox ID="txtVerifiedDate" runat="server" MaxLength="35" SkinID="PCStxt"
                    Width="130px"></asp:TextBox>
                <ajaxToolkit:maskededitextender id="Maskededitextender1" runat="server" autocomplete="False"
                            mask="9999/99/99" masktype="Date" targetcontrolid="txtVerifiedDate" ClearMaskOnLostFocus="False">
                </ajaxToolkit:MaskedEditExtender>
            </td>
            <td style="width: 100px; height: 19px" >
                </td>
            <td style="width: 50px; height: 19px" valign="top" >
                <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="Verify"
                    Width="44px"></asp:Label></td>
            <td style="width: 630px; height: 19px" valign="top" >
                <asp:RadioButtonList ID="rdblstVerify" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                    <asp:ListItem Value="N">No</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td valign="top" >
                <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="Remarks"></asp:Label></td>
            <td valign="top" >
                <asp:TextBox ID="txtRemarks" runat="server" MaxLength="1000" SkinID="PCStxt" TextMode="MultiLine" Width="225px"></asp:TextBox></td>
            <td style="width: 100px" >
                </td>
            <td >
            </td>
            <td style="width: 150px" >
            </td>
        </tr>
        <tr>
            <td >
            </td>
            <td >
                <table>
                    <tr>
                        <td style="height: 26px" valign="top">
                            <asp:Button ID="Button1" runat="server" OnClick="btnSave_Click" SkinID="Normal" Text="Save" />
                        </td>
                        <td style="height: 26px" valign="top">
                            <asp:Button ID="Button2" runat="server" OnClick="btnCancel_Click" OnClientClick="return confirm('Are you sure you want to cancel ?');"
                                SkinID="Cancel" Text="Cancel" />
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 100px" >
            </td>
            <td >
            </td>
            <td style="width: 150px" >
            </td>
        </tr>
        <tr>
            <td >
            </td>
            <td >
            </td>
            <td style="width: 100px" >
            </td>
            <td >
            </td>
            <td style="width: 150px" >
            </td>
        </tr>
    </table>
</asp:Content>

