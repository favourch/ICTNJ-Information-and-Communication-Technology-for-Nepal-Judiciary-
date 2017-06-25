<%@ Page Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master" AutoEventWireup="true" CodeFile="OrganizationUnit.aspx.cs" Inherits="MODULES_PMS_LookUp_OrganizationUnit" Title="PMS | Organization Unit" %>
<%@ Register 
    Assembly="AjaxControlToolkit" 
    Namespace="AjaxControlToolkit" 
    TagPrefix="ajaxToolkit" %>
    
  <script runat="server">

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" type="text/javascript" src ="../../COMMON/JS/Validation.js"></script>
<asp:ScriptManager id="ScriptManager1" runat="server">
                </asp:ScriptManager>

                <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" style="display:none"/>
        <ajaxToolkit:ModalPopupExtender runat="server" ID="programmaticModalPopup"
            BehaviorID="programmaticModalPopupBehavior"
            TargetControlID="hiddenTargetControlForModalPopup"
            PopupControlID="programmaticPopup" 
            BackgroundCssClass="modalBackground"
            DropShadow="True"
            PopupDragHandleControlID="programmaticPopupDragHandle"
            RepositionMode="RepositionOnWindowScroll" >
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel runat="server" CssClass="modalPopup" ID="programmaticPopup" style="display:none;width:350px;padding:10px">
            <asp:Panel runat="Server" ID="programmaticPopupDragHandle" Style="cursor: move;background-color:#DDDDDD;border:solid 1px Gray;color:Black;text-align:center;">
                Save Status
            </asp:Panel>
            <br />
            <asp:UpdatePanel id="UpdatePanel2" runat="server">
                <contenttemplate>
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
</contenttemplate>
            </asp:UpdatePanel>
            <br />
<asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click" Width="58px" />           <br />
        </asp:Panel>   
    <br />
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<TABLE style="WIDTH: 940px"><TBODY><TR><TD style="WIDTH: 16px; HEIGHT: 21px"></TD><TD style="HEIGHT: 21px"><asp:Label id="Label6" runat="server" Text="कार्यालय शाखा" SkinID="UnicodeHeadlbl"></asp:Label></TD></TR><TR><TD style="WIDTH: 16px" vAlign=top rowSpan=2></TD><TD style="WIDTH: 276px" vAlign=top rowSpan=2><asp:ListBox id="lstOrgUnits" runat="server" Width="271px" Height="376px" SkinID="Unicodelst" OnSelectedIndexChanged="lstOrgUnits_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox></TD><TD vAlign=top rowSpan=2><TABLE style="WIDTH: 335px"><TBODY><TR><TD style="WIDTH: 117px; HEIGHT: 22px"><asp:Label id="Label3" runat="server" Width="58px" Text="कार्यालय" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 424px; HEIGHT: 22px"><asp:DropDownList id="ddlOrganization" runat="server" Width="217px" SkinID="Unicodeddl" OnSelectedIndexChanged="ddlOrganization_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList> <asp:Label id="Label8" runat="server" Text="*" __designer:wfdid="w1" ForeColor="Red"></asp:Label></TD></TR><TR><TD style="WIDTH: 117px"><asp:Label id="Label1" runat="server" Text="शाखा" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 424px"><asp:TextBox id="txtUnitName_Rqd" runat="server" Width="215px" SkinID="Unicodetxt" ToolTip="शाखाको नाम यहाँ राख्नुहोस्" MaxLength="100"></asp:TextBox> <asp:Label id="Label9" runat="server" Text="*" __designer:wfdid="w2" ForeColor="Red"></asp:Label></TD></TR><TR><TD style="WIDTH: 117px"><asp:Label id="Label4" runat="server" Width="117px" Text="मातहत कार्यालय" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 424px"><asp:DropDownList id="ddlParentOrganizatin" runat="server" Width="217px" SkinID="Unicodeddl">
                            </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 117px"><asp:Label id="Label2" runat="server" Width="93px" Text="मातहत शाखा" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 424px"><asp:DropDownList id="ddlParentUnits" runat="server" Width="217px" SkinID="Unicodeddl" AppendDataBoundItems="True">
                            </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 117px"><asp:Label id="Label5" runat="server" Width="110px" Text="शाखाको किसिम" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 424px"><asp:DropDownList id="ddlUnitType" runat="server" Width="107px"><asp:ListItem Selected="True" Value="0">छान्नुहोस्</asp:ListItem>
<asp:ListItem Value="CA">मुद्दा</asp:ListItem>
<asp:ListItem Value="ST">जिन्सी</asp:ListItem>
<asp:ListItem Value="WR">रिट</asp:ListItem>
<asp:ListItem Value="AP">निवेदन</asp:ListItem>
<asp:ListItem Value="MY">म्याद</asp:ListItem>
<asp:ListItem Value="LE">लेखा</asp:ListItem>
<asp:ListItem Value="OT">अन्य</asp:ListItem>
</asp:DropDownList> <asp:Label id="Label10" runat="server" Text="*" __designer:wfdid="w3" ForeColor="Red"></asp:Label></TD></TR><TR><TD style="WIDTH: 117px"></TD><TD style="WIDTH: 424px"><asp:Button id="btnAddUnits" onclick="btnAddUnits_Click" runat="server" Width="50px" Text="Add" SkinID="Normal" OnClientClick="javascript:return validate();"></asp:Button></TD></TR><TR><TD colSpan=2 rowSpan=2>
<HR />
<asp:Panel id="pnlGrd" runat="server" Width="595px" Height="150px" ScrollBars="Auto"><asp:GridView id="grdUnits" runat="server" Width="588px" OnSelectedIndexChanged="grdUnits_SelectedIndexChanged" OnRowCreated="grdUnits_RowCreated" AutoGenerateColumns="False" GridLines="None" ForeColor="#333333" CellPadding="0">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="OrgID" HeaderText="कार्यालय"></asp:BoundField>
<asp:BoundField DataField="UnitID" HeaderText="शाखा"></asp:BoundField>
<asp:BoundField DataField="UnitName" HeaderText="शाखाको नाम">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="ParentOrgID" HeaderText="मातहत कार्यालय">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="ParentUnitID" HeaderText="मातहत शाखा">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="UnitType" HeaderText="शाखाको किसिम">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="Action" HeaderText="Action"></asp:BoundField>
<asp:CommandField ShowSelectButton="True"></asp:CommandField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> </asp:Panel> </TD></TR><TR></TR><TR><TD style="HEIGHT: 26px" colSpan=2><asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Width="60px" Text="Submit" SkinID="Normal"></asp:Button> <asp:Button id="btnCancel" onclick="btnCancel_Click" runat="server" Width="60px" Text="Cancel" SkinID="Cancel"></asp:Button></TD></TR></TBODY></TABLE></TD></TR><TR></TR></TBODY></TABLE>
</contenttemplate>
    </asp:UpdatePanel>
    <br />
    <br />
    <br />
    <br />
</asp:Content>

