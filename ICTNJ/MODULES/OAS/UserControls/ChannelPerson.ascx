<%@ Control AutoEventWireup="true" CodeFile="ChannelPerson.ascx.cs" Inherits="MODULES_OAS_UserControls_ChannelPerson" Language="C#" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script language="javascript" type="text/javascript">
    function ManageChannelPerson(chk)
    {
        var hdn = document.getElementById('<%= this.hdnChannelPerson.ClientID%>');
        if(chk.checked == true)
        {
            hdn.value = '1';
        }
        else
        {
            hdn.value = '0';
        }
        
        var ctbl = document.getElementById('<%= this.grdChannelPerson.ClientID %>');
        var stbl = document.getElementById('<%= this.grdSEmployee.ClientID %>');
        var utbl = document.getElementById('<%= this.grdOrgUnitWithHead.ClientID %>');
        
        var hasCPerson = false;
        var hasSPerson = false;
        var hasUPerson = false;
        
        for(var i = 1;i < ctbl.rows.length; i++)
        {
            var cell = ctbl.rows[i].cells[0].children[0];
            if(chk.id != cell.id)
            {
                if(cell.checked == true)
                {
                    cell.checked = false;
                    hasCPerson = true;
                }
            }
        }
        
        if(stbl != null)
        {
            for(var i = 1;i < stbl.rows.length; i++)
            {
                var cell = stbl.rows[i].cells[0].children[0];
                if(chk.id != cell.id)
                {
                    if(cell.checked == true)
                    {
                        cell.checked = false;
                        hasSPerson = true;
                    }
                }
            }
        }
        
        if(utbl != null)
        {
            for(var i = 1;i < utbl.rows.length; i++)
            {
                var cell = utbl.rows[i].cells[0].children[0];
                if(chk.id != cell.id)
                {
                    if(cell.checked == true)
                    {
                        cell.checked = false;
                        hasUPerson = true;
                    }
                }
            }
        }
    }
</script>

<div style="width: 100%; height: auto">
    <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground" DropShadow="True"
        PopupControlID="programmaticPopup" PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
        TargetControlID="hiddenTargetControlForModalPopup">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none; width: 350px; padding: 10px">
        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD; border: solid 1px Gray;
            color: Black; text-align: center;">
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
    <asp:Label ID="Label19" runat="server" SkinID="UnicodeHeadlbl" Text="सिफारीस कर्त्ता / प्रमाणित कर्ता"></asp:Label><asp:HiddenField ID="hdnChannelPerson" runat="server" Value="0" />
    <ajaxToolkit:TabContainer ID="EvaluationTab" runat="server" ActiveTabIndex="0" CssClass="ajax_tab_theme" Width="100%">
        <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
            <ContentTemplate>
                <div style="width: 100%;">
                    <asp:Panel ID="pnlForChannelPerson" runat="server" ScrollBars="Auto" Width="100%">
                        <asp:Label ID="lblChannelPersonCount" runat="server" Font-Underline="True" SkinID="Unicodelbl"></asp:Label>
                        <br />
                        <asp:GridView ID="grdChannelPerson" runat="server" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333"
                            OnDataBound="grdChannelPerson_DataBound" OnRowDataBound="grdChannelPerson_RowDataBound" Width="95%">
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <EditRowStyle BackColor="#999999" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelect" runat="server" onclick="ManageChannelPerson(this);" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ChannelSeqID" HeaderText="CSID" />
                                <asp:BoundField DataField="ChannelPersonName" HeaderText="पुरा नाम" />
                                <asp:BoundField DataField="OrgName" HeaderText="सस्थां" />
                                <asp:BoundField DataField="DegName" HeaderText="पद" />
                                <asp:BoundField DataField="ChannelPersonOrder" HeaderText="तह" />
                                <asp:BoundField DataField="RDPersonType" HeaderText="प्रकार" />
                                <asp:BoundField DataField="RDIsFinalApprover" HeaderText="प्र. प्र. क" />
                                <asp:BoundField DataField="ChannelPersonID" HeaderText="Person" />
                                <asp:BoundField DataField="UnitOrgID" HeaderText="UnitOrgID" />
                                <asp:BoundField DataField="UnitID" HeaderText="UnitID" />
                                <asp:BoundField DataField="UnitName" HeaderText="शाखा" />
                            </Columns>
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        </asp:GridView>
                    </asp:Panel>
                </div>
            </ContentTemplate>
            <HeaderTemplate>
                टिप्पणी च्यानल बाट&nbsp;
            </HeaderTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
            <ContentTemplate>
                <div style="width: 100%;">
                    <asp:Label ID="lblChannelPersonCountX" runat="server" Font-Underline="True" SkinID="Unicodelbl">साधारण कर्मचारी खोज्नुहोस</asp:Label>
                    <br />
                    <table style="width: 939px">
                        <tbody>
                            <tr>
                                <td>
                                    <asp:Label ID="Label24" runat="server" Height="22px" SkinID="Unicodelbl" Text="संकेत नं" Width="110px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox2" runat="server" MaxLength="15" SkinID="Unicodetxt" ToolTip="First Name" Width="130px"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label25" runat="server" Height="22px" SkinID="Unicodelbl" Text="पहिलो नाम" Width="92px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSFname" runat="server" MaxLength="35" SkinID="Unicodetxt" ToolTip="First Name" Width="130px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label26" runat="server" Height="22px" SkinID="Unicodelbl" Text="बिचको नाम" Width="92px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSMname" runat="server" MaxLength="15" SkinID="Unicodetxt" Width="130px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label27" runat="server" Height="22px" SkinID="Unicodelbl" Text="थर" Width="92px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSLname" runat="server" MaxLength="35" SkinID="Unicodetxt" ToolTip="Surname" Width="130px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label28" runat="server" Height="22px" SkinID="Unicodelbl" Text="लिंग" Width="92px"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSSex" runat="server" SkinID="Unicodeddl" Width="135px">
                                        <asp:ListItem Value="SG">छान्नुहोस</asp:ListItem>
                                        <asp:ListItem Value="M">पुरुष</asp:ListItem>
                                        <asp:ListItem Value="F">महिला</asp:ListItem>
                                        <asp:ListItem Value="O">अन्य</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label29" runat="server" Height="22px" SkinID="Unicodelbl" Text="जन्म मिति" Width="110px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSDob" runat="server" MaxLength="10" SkinID="Unicodetxt" Width="130px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label31" runat="server" Height="22px" SkinID="Unicodelbl" Text="बैबाहिक सम्बन्ध" Width="114px"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSMaritalStatus" runat="server" SkinID="Unicodeddl" Width="135px">
                                        <asp:ListItem Value="SMS">छान्नुहोस</asp:ListItem>
                                        <asp:ListItem Value="S">अबिबाहित</asp:ListItem>
                                        <asp:ListItem Value="M">बिबाहित</asp:ListItem>
                                        <asp:ListItem Value="W">बिधवा/बिदुर</asp:ListItem>
                                        <asp:ListItem Value="D">छोडपत्र</asp:ListItem>
                                        <asp:ListItem Value="O">अन्य</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label32" runat="server" SkinID="Unicodelbl" Text="कार्यालय"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:DropDownList ID="ddlSOrg" runat="server" AutoPostBack="True" SkinID="Unicodeddl" Width="478px" OnSelectedIndexChanged="ddlSOrg_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label33" runat="server" SkinID="Unicodelbl" Text="पद"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSDesgination" runat="server" SkinID="Unicodeddl" Width="135px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblUnit" runat="server" SkinID="Unicodelbl" Text="शाखा"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlUnit" runat="server" SkinID="Unicodeddl" Width="135px">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlSOrg" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="6">
                                    <asp:Button ID="btnSearchGeneral" runat="server" OnClick="btnSearchGeneral_Click" SkinID="Normal" Text="Search" />
                                    <asp:Button ID="btnCancelGeneral" runat="server" OnClick="btnCancelGeneral_Click" SkinID="Cancel" Text="Cancel" />
                                    <ajaxToolkit:MaskedEditExtender ID="mskSDob" runat="server" AutoComplete="False" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                        Enabled="True" Mask="9999/99/99" MaskType="Date" TargetControlID="txtSDob">
                                    </ajaxToolkit:MaskedEditExtender>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblSearchX" runat="server" Font-Bold="False" SkinID="Unicodelbl"></asp:Label><br />
                            <asp:Panel ID="pnlGeneralEmployee" runat="server" ScrollBars="Auto" Width="100%">
                                <asp:GridView ID="grdSEmployee" runat="server" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333"
                                    OnDataBound="grdSEmployee_DataBound" OnRowDataBound="grdEmployee_RowDataBound" SkinID="Unicodegrd" Width="95%">
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="PersonID" HeaderText="EmpID" />
                                        <asp:TemplateField>
                                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkGSelect" runat="server" onclick="ManageChannelPerson(this);" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="RDFULLNAME" HeaderText="पुरा नाम थर" />
                                        <asp:BoundField DataField="RDGENDER" HeaderText="लिंग" />
                                        <asp:BoundField DataField="DOB" HeaderText="जन्म मिति">
                                            <ItemStyle Font-Names="Verdana" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="RDMARITALSTATUS" HeaderText="बैबाहिक सम्बन्ध" />
                                        <asp:BoundField DataField="District" HeaderText="जन्म स्थान" />
                                        <asp:BoundField DataField="IniType" HeaderText="कार्यालय" />
                                        <asp:BoundField DataField="PostName" HeaderText="पद" />
                                        <asp:BoundField DataField="UnitName" HeaderText="शाखा" />
                                        <asp:BoundField DataField="OrgID" HeaderText="OrgID" />
                                        <asp:BoundField DataField="UnitID" HeaderText="UnitID" />
                                    </Columns>
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <EditRowStyle BackColor="#999999" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                </asp:GridView>
                            </asp:Panel>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnSearchGeneral" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </ContentTemplate>
            <HeaderTemplate>
                साधारण कर्मचारी&nbsp;
            </HeaderTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
            <HeaderTemplate>
                कार्यालय शाखा
            </HeaderTemplate>
            <ContentTemplate>
                <asp:Label ID="lblChannelPersonCountXX" runat="server" Font-Underline="True" SkinID="Unicodelbl">कार्यालय शाखा खोज्नुहोस्</asp:Label><br />
                <table style="width: 700px">
                    <tr>
                        <td style="width: 125px">
                            <asp:Label ID="Label1" runat="server" Text="कार्यालय" SkinID="Unicodelbl"></asp:Label></td>
                        <td style="width: 575px">
                            <asp:DropDownList ID="ddlUOrg" runat="server" AutoPostBack="True" Width="200px" OnSelectedIndexChanged="ddlUOrg_SelectedIndexChanged">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:UpdatePanel ID="updUnitHead" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="grdOrgUnitWithHead" runat="server" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333" SkinID="Unicodegrd"
                                        Width="675px" OnRowDataBound="grdOrgUnitWithHead_RowDataBound">
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemStyle HorizontalAlign="Center" Width="40px" />
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkUnitSelect" runat="server" onclick="ManageChannelPerson(this);" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="OrgID" DataField="OrgID" />
                                            <asp:BoundField HeaderText="UnitID" DataField="UnitID" />
                                            <asp:BoundField HeaderText="EmpID" DataField="EmpID" />
                                            <asp:BoundField HeaderText="शाखा" DataField="UnitName" />
                                            <asp:BoundField HeaderText="शाखा प्रमुख" DataField="EmpName" />
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
                                    <asp:AsyncPostBackTrigger ControlID="ddlUOrg" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>
</div>
