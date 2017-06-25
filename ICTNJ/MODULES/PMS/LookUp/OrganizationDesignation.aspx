<%@ Page Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master" AutoEventWireup="true" CodeFile="OrganizationDesignation.aspx.cs" Inherits="MODULES_PMS_LookUp_OrganizationDesignation" Title="PMS | Post" %>

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
<script language="javascript" type="text/javascript" src="../../COMMON/JS/Validation.js" ></script>
<script language="javascript" src="../../COMMON/JS/DateValidator.js" type="text/javascript"></script>

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
            <asp:UpdatePanel id="UpdatePanel1" runat="server">
                <contenttemplate>
<BR /><asp:Label id="lblStatusMessage" runat="server" Text="Label"></asp:Label> 
</contenttemplate>
            </asp:UpdatePanel>
<asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click" Width="58px" />           <br />
        </asp:Panel>
    &nbsp; &nbsp; &nbsp; &nbsp;
    <asp:Label ID="Label9" runat="server" SkinID="UnicodeHeadlbl" Text="पद"></asp:Label><br />
    <asp:UpdatePanel id="UpdatePanel2" runat="server">
        <contenttemplate>
<TABLE><TBODY><TR><TD style="WIDTH: 19px" vAlign=top></TD><TD vAlign=top><asp:Label id="Label3" runat="server" Width="70px" Text="कार्यालय" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top colSpan=3><asp:DropDownList id="ddlOrganization_Rqd" runat="server" Width="472px" SkinID="Unicodeddl" ToolTip="कार्यालय">
                </asp:DropDownList></TD><TD vAlign=top><asp:Label id="Label1" runat="server" Text="पद" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:DropDownList id="ddlDesignation_Rqd" runat="server" Width="200px" SkinID="Unicodeddl" ToolTip="पद">
                </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 19px" vAlign=top></TD><TD vAlign=top><asp:Label id="Label2" runat="server" Text="सेवा" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 222px" vAlign=top><asp:DropDownList id="ddlSewa_Rqd" runat="server" Width="200px" SkinID="Unicodeddl" ToolTip="सेवा" AutoPostBack="True" OnSelectedIndexChanged="ddlSewa_Rqd_SelectedIndexChanged">
                </asp:DropDownList></TD><TD style="WIDTH: 48px" vAlign=top><asp:Label id="Label4" runat="server" Width="43px" Text="समुह" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 280px" vAlign=top><asp:DropDownList id="ddlSamuha_Rqd" runat="server" Width="197px" SkinID="Unicodeddl" ToolTip="समुह" AutoPostBack="True" OnSelectedIndexChanged="ddlSamuha_Rqd_SelectedIndexChanged" AppendDataBoundItems="True">
                </asp:DropDownList></TD><TD vAlign=top><asp:Label id="Label7" runat="server" Width="65px" Text="उप-समुह" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:DropDownList id="ddlUpaSamuha_Rqd" runat="server" Width="200px" SkinID="Unicodeddl" ToolTip="उप-समुह" AppendDataBoundItems="True">
                </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 19px" vAlign=top></TD><TD vAlign=top><asp:Label id="Label6" runat="server" Text="श्रेणी" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 222px" vAlign=top><asp:DropDownList id="ddlDesignationLevel_Rqd" runat="server" Width="118px" SkinID="Unicodeddl" ToolTip="श्रेणी">
                </asp:DropDownList></TD><TD style="WIDTH: 48px" vAlign=top><asp:Label id="Label5" runat="server" Width="45px" Text="सख्या" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 280px" vAlign=top><asp:TextBox id="txtTotalSeats_Rqd" runat="server" Width="39px" SkinID="Unicodetxt" ToolTip="जम्मा संख्या" MaxLength="3"></asp:TextBox><ajaxToolkit:filteredtextboxextender id="FilteredTextBoxExtender1" runat="server" filtertype="Numbers" targetcontrolid="txtTotalSeats_Rqd"></ajaxToolkit:filteredtextboxextender> </TD><TD vAlign=top><asp:Label id="Label8" runat="server" Text="मिति" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:TextBox id="txtCreatedDate_DT" runat="server" Width="73px" SkinID="Unicodetxt" ToolTip="मिति" MaxLength="10"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender1" runat="server" TargetControlID="txtCreatedDate_DT" AutoComplete="False" Mask="9999/99/99" MaskType="Date">
                </ajaxToolkit:MaskedEditExtender> </TD></TR><TR><TD style="WIDTH: 19px" vAlign=top></TD><TD vAlign=top></TD><TD style="WIDTH: 222px" vAlign=top></TD><TD style="WIDTH: 48px" vAlign=top></TD><TD style="WIDTH: 280px" vAlign=top></TD><TD vAlign=top></TD><TD><asp:Button id="btnCreatePost" onclick="btnCreatePost_Click" runat="server" Width="75px" Text="Create Post" SkinID="Normal"></asp:Button></TD></TR><TR><TD style="WIDTH: 19px" vAlign=top></TD><TD vAlign=top><asp:Label id="Label10" runat="server" Width="77px" Text="Arrange By" SkinID="Unicodelbl" __designer:wfdid="w2"></asp:Label></TD><TD vAlign=top colSpan=2><asp:DropDownList id="ddlSortOrgDesignation" runat="server" Width="271px" AutoPostBack="True" OnSelectedIndexChanged="ddlSortOrgDesignation_SelectedIndexChanged" __designer:wfdid="w4"></asp:DropDownList></TD><TD style="WIDTH: 280px" vAlign=top><asp:Image id="Image1" runat="server" Width="36px" ImageUrl="~/MODULES/COMMON/Images/PF_Process_drawer_icon.jpg" Height="34px" __designer:wfdid="w2"></asp:Image></TD><TD vAlign=top></TD><TD></TD></TR></TBODY></TABLE><TABLE style="WIDTH: 958px"><TBODY><TR><TD style="HEIGHT: 256px"></TD><TD style="WIDTH: 900px; HEIGHT: 256px">
<HR />
 <asp:Label id="lblSortedData" runat="server" Width="269px" Font-Bold="True" __designer:wfdid="w1" ForeColor="Transparent"></asp:Label><BR /><asp:Panel id="pnlSearchDesignation" runat="server" Width="100%" Height="200px" ScrollBars="Auto">
                    <asp:GridView ID="grdOrgDesignation" runat="server" AutoGenerateColumns="False" CellPadding="0"
                        ForeColor="#333333" GridLines="None" OnRowDataBound="grdOrgDesignation_RowDataBound"
                        OnSelectedIndexChanged="grdOrgDesignation_SelectedIndexChanged" SkinID="Unicodegrd"
                        Width="850px">
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="ORGID" HeaderText="OrgId" />
                            <asp:BoundField DataField="DESID" HeaderText="DesId" />
                            <asp:BoundField DataField="ORGNAME" HeaderText="कार्यालय" >
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DESNAME" HeaderText="पद">
                                <HeaderStyle Width="20px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SEWANAME" HeaderText="सेवा" />
                            <asp:BoundField DataField="SAMUHANAME" HeaderText="समुह" />
                            <asp:BoundField DataField="UPASAMUHANAME" HeaderText="उप समुह" />
                            <asp:BoundField DataField="DESGLEVELNAME" HeaderText="श्रेणी" />
                            <asp:BoundField DataField="SEWAID" HeaderText="Sewa ID" />
                            <asp:BoundField DataField="SAMUHAID" HeaderText="Samuha ID" />
                            <asp:BoundField DataField="UPASAMUHAID" HeaderText="Upasamuha ID" />
                            <asp:BoundField DataField="DESGLEVELID" HeaderText="Desg Level ID" />
                            <asp:BoundField DataField="TotalSeats" HeaderText="सख्या" >
                                <ItemStyle Width="40px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CREATEDDATE" HeaderText="मिति" />
                            <asp:CommandField ShowSelectButton="True">
                                <ItemStyle Font-Names="Verdana" />
                            </asp:CommandField>
                        </Columns>
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <EditRowStyle BackColor="#999999" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                </asp:Panel> </TD></TR><TR><TD></TD><TD>
<HR />
<BR /><asp:Panel id="Panel2" runat="server" Width="100%" Height="150px" ScrollBars="Auto">
                    <asp:GridView ID="grdDesPost" runat="server" AutoGenerateColumns="False" CellPadding="0"
                        ForeColor="#333333" GridLines="None" SkinID="Unicodegrd" Width="812px" OnRowDataBound="grdDesPost_RowDataBound">
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="ORGID" HeaderText="Org Id" />
                            <asp:BoundField DataField="DESID" HeaderText="Des Id" />
                            <asp:BoundField DataField="POSTID" HeaderText="Post Id" />
                            <asp:BoundField DataField="ORGNAME" HeaderText="कार्यालय" />
                            <asp:BoundField DataField="DESNAME" HeaderText="पद" />
                            <asp:TemplateField HeaderText="पद">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPostName" runat="server" SkinID="PCStxt" Text='<%# Eval("POSTNAME") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="पद">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtOldPostName" runat="server" SkinID="PCStxt" Text='<%# Eval("POSTNAME") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="OCCUPIED" HeaderText="Occupied" />
                            <asp:BoundField DataField="CREATEDDATE" HeaderText="मिति" />
                            <asp:TemplateField HeaderText="Delete">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkPostSelect" runat="server" Enabled='<%# Eval("RDUNOCCUPIEDPOST") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <EditRowStyle BackColor="#999999" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                </asp:Panel> 
<HR />
</TD></TR><TR><TD></TD><TD><asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Width="60px" Text="Submit" SkinID="Normal"></asp:Button><asp:Button id="btnCancel" onclick="btnCancel_Click" runat="server" Width="60px" Text="Cancel" SkinID="Cancel"></asp:Button></TD></TR></TBODY></TABLE>
</contenttemplate>
    </asp:UpdatePanel>
    <br />
    <br />
</asp:Content>

