
<%@ Page AutoEventWireup="true" CodeFile="Participants.aspx.cs" Inherits="MODULES_DLPDS_Forms_Participants" Language="C#" MasterPageFile="~/MODULES/DLPDS/DLPDSMasterPage.master"
    Title="DLPDS | Participants" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<script runat="server">

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
</script>

<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior"
        DropShadow="True" PopupControlID="programmaticPopup" PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
        TargetControlID="hiddenTargetControlForModalPopup">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none; width: 350px; padding: 10px">
        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD; border: solid 1px Gray; color: Black; text-align: center;">
            Save Status
        </asp:Panel>
        <asp:UpdatePanel id="UpdatePanel2" runat="server">
            <contenttemplate>
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
</contenttemplate>
        </asp:UpdatePanel>
        <br />
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click" Text="OK" Width="58px" />
        <br />
    </asp:Panel>

    <table style="width: 750px">
        <tr>
            <td align="left" colspan="2" style="height: 21px">
                <asp:Label ID="lblProgram" runat="server" Font-Bold="True" Text="Program List" Width="118px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 1px; height: 210px;" valign="top">
                <asp:ListBox ID="lstProgram" runat="server" AutoPostBack="True" Height="313px" OnSelectedIndexChanged="lstProgram_SelectedIndexChanged" Width="200px"></asp:ListBox></td>
            <td align="left" style="width: 1px; height: 210px;" valign="top">
                <table style="width: 635px">
                    <tr>
                        <td style="height: 1px;" colspan="2">
                            <asp:Button ID="btnAddParticipant" runat="server" Font-Bold="False" OnClick="btnAddParticipant_Click" Text="AddParticipant" Width="96px" />
                        </td>
                        <td align="left" style="height: 1px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Panel ID="Panel2" runat="server" CssClass="collapsePanelHeader" Height="10px" Width="720px">
                                <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                                    <div style="float: left;">
                                        Search Participants</div>
                                    <div style="float: right; vertical-align: middle;">
                                        <asp:ImageButton ID="Image1" runat="server" AlternateText="(Show Details...)" ImageUrl="../../COMMON/Images/expand_blue.jpg" />
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="Panel3" runat="server" CssClass="collapsePanel" Width="720px">
                                <table style="width: 100px">
                                    <tr>
                                        <td style="height: 26px">
                                            <asp:Label ID="Label1" runat="server" Font-Names="PCS NEPALI" SkinID="PCSlbl" Text="klxnf] gfd" Width="92px"></asp:Label></td>
                                        <td style="height: 26px">
                                            <asp:TextBox ID="txtFName" runat="server" MaxLength="35" SkinID="PCStxt" ToolTip="First Name" Width="130px"></asp:TextBox></td>
                                        <td style="height: 26px">
                                            <asp:Label ID="Label2" runat="server" Font-Names="PCS NEPALI" Height="22px" SkinID="PCSlbl" Text="ljrsf] gfd" Width="92px"></asp:Label></td>
                                        <td style="height: 26px">
                                            <asp:TextBox ID="txtMName" runat="server" MaxLength="15" SkinID="PCStxt" Width="130px"></asp:TextBox></td>
                                        <td style="height: 26px">
                                            <asp:Label ID="Label3" runat="server" Font-Names="PCS NEPALI" Height="22px" SkinID="PCSlbl" Text="y/" Width="92px"></asp:Label></td>
                                        <td style="height: 26px">
                                            <asp:TextBox ID="txtSurName" runat="server" MaxLength="35" SkinID="PCStxt" ToolTip="Surname" Width="130px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" Font-Names="PCS NEPALI" Height="22px" SkinID="PCSlbl" Text="ln" Width="92px"></asp:Label></td>
                                        <td>
                                            <asp:DropDownList ID="ddlGender" runat="server" SkinID="PCSddl" Width="135px">
                                                <asp:ListItem Value="SG">%fGg'xf];</asp:ListItem>
                                                <asp:ListItem Value="M">k'?if</asp:ListItem>
                                                <asp:ListItem Value="F">dlxnf</asp:ListItem>
                                                <asp:ListItem Value="O">cGo</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td>
                                            <asp:Label ID="Label8" runat="server" Font-Names="PCS NEPALI" Height="22px" SkinID="PCSlbl" Text="lhNnf" Width="92px"></asp:Label></td>
                                        <td>
                                            <asp:DropDownList ID="ddlDistrict" runat="server" SkinID="PCSddl" Width="135px">
                                            </asp:DropDownList></td>
                                        <td>
                                            </td>
                                        <td>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 26px">
                                        </td>
                                        <td style="height: 26px">
                                        </td>
                                        <td style="height: 26px">
                                        </td>
                                        <td style="height: 26px">
                                        </td>
                                        <td style="height: 26px">
                                        </td>
                                        <td style="height: 26px">
                                            <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" Width="68px" /><asp:Button ID="btnSearchCancel" runat="server" OnClick="btnSearchCancel_Click"
                                                Text="Cancel" Width="68px" /></td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="6" style="height: 37px" valign="top">
                                            <hr />
                                            <asp:UpdatePanel id="UpdatePanel1" runat="server">
                                                <contenttemplate>
<asp:Panel id="Panel1" runat="server" Width="100%" Height="200px" ScrollBars="Auto" HorizontalAlign="Left" __designer:wfdid="w1"><asp:Label id="lblSearch" runat="server" Font-Bold="True" __designer:wfdid="w2"></asp:Label> <BR /><asp:GridView id="grdPerson" runat="server" Width="650px" SkinID="PCSGridView" ForeColor="#333333" HorizontalAlign="Left" OnRowCreated="grdPerson_RowCreated" AutoGenerateColumns="False" CellPadding="0" OnRowDataBound="grdPerson_RowDataBound" __designer:wfdid="w3">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:TemplateField>
<ItemStyle HorizontalAlign="Center"></ItemStyle>

<HeaderStyle Width="50px" HorizontalAlign="Center"></HeaderStyle>
<ItemTemplate>
<asp:CheckBox ID="chkSelectPerson" runat="server" />
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="PARTICIPANTID" HeaderText="g+="></asp:BoundField>
<asp:BoundField DataField="FIRSTNAME" HeaderText="klxnf] gfd"></asp:BoundField>
<asp:BoundField DataField="MIDDLENAME" HeaderText="ljrsf] gfd"></asp:BoundField>
<asp:BoundField DataField="SURNAME" HeaderText="y/"></asp:BoundField>
<asp:BoundField DataField="RDFULLNAME" HeaderText="k'/f gfd y/"></asp:BoundField>
<asp:BoundField DataField="RDGENDER" HeaderText="ln"></asp:BoundField>
<asp:BoundField DataField="DOB" HeaderText="hGd ldlt">
<ItemStyle Font-Names="Verdana"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DISTRICT" HeaderText="lhNnf"></asp:BoundField>
<asp:BoundField DataField="FATHERNAME" HeaderText="afa'sf] gfd"></asp:BoundField>
<asp:BoundField DataField="GFATHERNAME" HeaderText="afh]sf] gfd"></asp:BoundField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> </asp:Panel> 
</contenttemplate>
                                                <triggers>
<asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
                                            </asp:UpdatePanel>&nbsp;</td>
                                    </tr>
                                    <tr>
                                    </tr>
                                </table>
                                <br />
                                <p>
                                    &nbsp;</p>
                            </asp:Panel>
                            <ajaxToolkit:CollapsiblePanelExtender ID="cpeDemo" runat="Server" CollapseControlID="Panel2" Collapsed="True" CollapsedImage="../../COMMON/Images/expand_blue.jpg"
                                ExpandControlID="Panel2" ExpandedImage="../../COMMON/Images/collapse_blue.jpg" ImageControlID="Image1"
                                SkinID="CollapsiblePanelDemo" SuppressPostBack="true" TargetControlID="Panel3" TextLabelID="Label1">
                            </ajaxToolkit:CollapsiblePanelExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" /><asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click"
                    Text="Cancel" /></td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Panel ID="Panel4" runat="server" Height="150px" ScrollBars="Auto" Width="100%">
                            <asp:GridView ID="grdParticipant" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="grdParticipant_RowDataBound"
                                Width="495px">
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <EditRowStyle BackColor="#999999" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:BoundField DataField="OrgID" HeaderText="Organization ID" />
                                    <asp:BoundField DataField="ProgramID" HeaderText="Program ID" />
                                    <asp:BoundField DataField="PID" HeaderText="PID" />
                                    <asp:BoundField DataField="ParticipantName" HeaderText="Participant Name" />
                                    <asp:BoundField DataField="JoiningDate" HeaderText="Joining Date" />
                                    <asp:BoundField DataField="Flag" HeaderText="Flag" />
                                </Columns>
                            </asp:GridView>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                </td>
        </tr>
    </table>
    <br />
</asp:Content>
