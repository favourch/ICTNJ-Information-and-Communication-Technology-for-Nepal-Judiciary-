<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GroupMemberSearch.ascx.cs" Inherits="MODULES_OAS_UserControls_GroupMemberSearch" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<div style="width:100%; height:auto">

    <script type="text/javascript">
        var scrollTop;
        
        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

        function BeginRequestHandler(sender, args)
        {
            var elem = document.getElementById('<%= this.pnlEmployee.ClientID%>');
            if(elem != null)
                scrollTop=elem.scrollTop;
        }

        function EndRequestHandler(sender, args)
        {
            var elem = document.getElementById('<%= this.pnlEmployee.ClientID%>');
            if(elem != null)
                elem.scrollTop = scrollTop;
        }
        
        function SetCheckedRow(index, orgiginalColor, chk)
        {
            var tbl = document.getElementById('<%= this.grdEmployee.ClientID %>');
            if(chk.checked == true)
                tbl.rows[index+1].style.backgroundColor = "#578caa";
            else
                tbl.rows[index+1].style.backgroundColor = orgiginalColor;
        }
    </script>
    <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground"
        DropShadow="True" PopupControlID="programmaticPopup" PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
        TargetControlID="hiddenTargetControlForModalPopup">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none; width: 350px; padding: 10px">
        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD; border: solid 1px Gray; color: Black; text-align: center;">
            Save Status
        </asp:Panel>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
        <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click" Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    <asp:Label ID="Label22" runat="server" SkinID="UnicodeHeadlbl" Text="कर्मचारी खोज्नुहोस"></asp:Label><table style="width: 939px">
        <tr>
            <td>
                <asp:Label ID="Label30" runat="server" Height="22px" SkinID="Unicodelbl" Text="संकेत नं" Width="110px" Visible="False"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtSymbolNo" runat="server" MaxLength="15" SkinID="Unicodetxt" ToolTip="First Name" Width="130px" Visible="False"></asp:TextBox></td>
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
                <asp:Label ID="Label1" runat="server" Height="22px" SkinID="Unicodelbl" Text="पहिलो नाम" Width="92px"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtFName" runat="server" MaxLength="35" SkinID="Unicodetxt" ToolTip="First Name" Width="130px"></asp:TextBox></td>
            <td>
                <asp:Label ID="Label2" runat="server" Height="22px" SkinID="Unicodelbl" Text="बिचको नाम" Width="92px"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtMName" runat="server" MaxLength="15" SkinID="Unicodetxt" Width="130px"></asp:TextBox></td>
            <td>
                <asp:Label ID="Label3" runat="server" Height="22px" SkinID="Unicodelbl" Text="थर" Width="92px"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtSurName" runat="server" MaxLength="35" SkinID="Unicodetxt" ToolTip="Surname" Width="130px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Height="22px" SkinID="Unicodelbl" Text="लिंग" Width="92px"></asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlGender" runat="server" SkinID="Unicodeddl" Width="135px">
                    <asp:ListItem Value="SG">छान्नुहोस</asp:ListItem>
                    <asp:ListItem Value="M">पुरुष</asp:ListItem>
                    <asp:ListItem Value="F">महिला</asp:ListItem>
                    <asp:ListItem Value="O">अन्य</asp:ListItem>
                </asp:DropDownList></td>
            <td>
                <asp:Label ID="Label4" runat="server" Height="22px" SkinID="Unicodelbl" Text="जन्म मिति" Width="110px"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtDOB" runat="server" MaxLength="10" SkinID="Unicodetxt" Width="130px"></asp:TextBox></td>
            <td>
                <asp:Label ID="Label6" runat="server" Height="22px" SkinID="Unicodelbl" Text="बैबाहिक सम्बन्ध" Width="114px"></asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlMarStatus" runat="server" SkinID="Unicodeddl" Width="135px">
                    <asp:ListItem Value="SMS">छान्नुहोस</asp:ListItem>
                    <asp:ListItem Value="S">अबिबाहित</asp:ListItem>
                    <asp:ListItem Value="M">बिबाहित</asp:ListItem>
                    <asp:ListItem Value="W">बिधवा/बिदुर</asp:ListItem>
                    <asp:ListItem Value="D">छोडपत्र</asp:ListItem>
                    <asp:ListItem Value="O">अन्य</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" SkinID="Unicodelbl" Text="कार्यालय"></asp:Label></td>
            <td colspan="3">
                <asp:DropDownList ID="ddlOrganization" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlOrganization_SelectedIndexChanged" SkinID="Unicodeddl"
                    Width="478px">
                </asp:DropDownList></td>
            <td>
                <asp:Label ID="lblDesignation" runat="server" SkinID="Unicodelbl" Text="पद"></asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlDesignation" runat="server" SkinID="Unicodeddl" Width="135px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label8" runat="server" SkinID="Unicodelbl" Text="समुह" Visible="False"></asp:Label></td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlCommittee" runat="server" Width="135px" AutoPostBack="False" Visible="False">
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlOrganization" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td>
                </td>
            <td colspan="2">
                
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="5">
                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" SkinID="Normal" Text="Search" />
                <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" SkinID="Cancel" Text="Cancel" /><ajaxtoolkit:maskededitextender id="MSKdob" runat="server"
                    autocomplete="False" mask="9999/99/99" masktype="Date" targetcontrolid="txtDOB"> </ajaxtoolkit:maskededitextender></td>
        </tr>
    </table>
</div>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:Label ID="lblSearch" runat="server" Font-Bold="False" SkinID="Unicodelbl">Please search employee</asp:Label><br />
        <asp:Panel ID="pnlEmployee" runat="server" Height="250px" ScrollBars="Auto" Visible="False" Width="100%">
            <asp:GridView ID="grdEmployee" runat="server" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333" OnDataBound="grdEmployee_DataBound" OnRowDataBound="grdEmployee_RowDataBound"
                OnSelectedIndexChanged="grdEmployee_SelectedIndexChanged" SkinID="Unicodegrd" Width="100%">
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <Columns>
                    <asp:BoundField DataField="PersonID" HeaderText="आई डी" />
                    <asp:TemplateField>
                        <ItemStyle HorizontalAlign="Center" Width="40px" />
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" SkinID="smallChk" />
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
                    <asp:BoundField DataField="GroupName" HeaderText="समुह" />
                    <asp:BoundField DataField="GMPositionName" HeaderText="समुहको पद" />
                    <asp:CommandField ShowSelectButton="True">
                        <ItemStyle Font-Names="Verdana" />
                    </asp:CommandField>
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
        <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="grdEmployee" EventName="SelectedIndexChanged" />
    </Triggers>
</asp:UpdatePanel>
