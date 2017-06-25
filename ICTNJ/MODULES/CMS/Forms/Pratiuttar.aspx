<%@ Page Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" AutoEventWireup="true" CodeFile="Pratiuttar.aspx.cs" Inherits="MODULES_CMS_Forms_Pratiuttar" Title="CMS | Pratiuttar" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../UserControls/CaseSearch.ascx" TagName="CaseSearch" TagPrefix="userControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" src="../../COMMON/JS/Validation.js" type="text/javascript"></script>
<script language="javascript" src="../../COMMON/JS/DateValidator.js" type="text/javascript"></script>
<script language="javascript" src="../../COMMON/JS/EnglishDateValidator.js" type="text/javascript"></script>

<script language="javascript" type="text/javascript">

 function CheckUncheck(AttCheckBox)
    {            
        
        
        var grid = document.getElementById("<%= grdLitigantRes.ClientID %>");
        var grdAppRowCount = grid.rows.length  ;        
        if( AttCheckBox == grid.rows[0].cells[0].children[0].getAttribute("id")    )
        {
             for(var x=1;x<grdAppRowCount;x++)
             {      
                var v=  grid.rows[x].cells[0].children[0]; 
                v.checked=grid.rows[0].cells[0].children[0].checked; 
             }           
             
        }         
        else
        {        
            for(var x=1;x<grdAppRowCount;x++)
            {  
				grid.rows[0].cells[0].children[0].checked=true;
                if(grid.rows[x].cells[0].children[0].checked==false)
                {
					grid.rows[0].cells[0].children[0].checked=false;
					break;
				}				
			}           
                       
            
        }        
    } 
</script>

    <script runat="server">

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
    </script>
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground"
        BehaviorID="programmaticModalPopupBehavior" DropShadow="True" PopupControlID="programmaticPopup"
        PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
        TargetControlID="hiddenTargetControlForModalPopup">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none;
        width: 350px; padding: 10px">
        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD;
            border: solid 1px Gray; color: Black; text-align: center;">
            Save Status
        </asp:Panel>
        <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label><br />
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
            Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    
    <br />
    <asp:Panel ID="pnlCol" runat="server" CssClass="collapsePanelHeader" Height="25px"
        Width="1024px">
        मुद्दा खोज्नुहोस
        <asp:ImageButton ID="imgCol" runat="server" Height="25px" ImageAlign="Right" ImageUrl="~/MODULES/COMMON/Images/expand.jpg"
            Visible="False" />
    </asp:Panel>
    <ajaxtoolkit:collapsiblepanelextender id="colCaseSearch" runat="server" collapsecontrolid="pnlCol"
        collapsed="True" collapsedimage="../../COMMON/Images/expand_blue.jpg" expandcontrolid="pnlCol"
        expandedimage="../../COMMON/Images/collapse_blue.jpg" imagecontrolid="imgCol"
        skinid="CollapsiblePanelDemo" suppresspostback="True" targetcontrolid="pnlCaseSearch">
        </ajaxtoolkit:collapsiblepanelextender>
    <asp:Panel ID="pnlCaseSearch" runat="server" CssClass="collapsePanel" Width="1024px">
        <userControl:CaseSearch ID="CaseSearchControl" runat="server"/>
    </asp:Panel>
    <br />
    <asp:Panel ID="pnlPratiuttar" runat="server" CssClass="collapsePanelHeader" Height="25px"
        Width="1024px">
        प्रतिउत्तर
        <asp:ImageButton ID="ImageButton4" runat="server" Height="25px" ImageAlign="Right"
            ImageUrl="~/MODULES/COMMON/Images/expand.jpg" Visible="False" />
    </asp:Panel>
    <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender2" runat="server"
        CollapseControlID="pnlPratiuttar" Collapsed="True" CollapsedImage="../../COMMON/Images/expand_blue.jpg"
        ExpandControlID="pnlPratiuttar" ExpandedImage="../../COMMON/Images/collapse_blue.jpg"
        ImageControlID="imgCol" SkinID="CollapsiblePanelDemo" SuppressPostBack="True"
        TargetControlID="pnlPratiuttarContent">
    </ajaxToolkit:CollapsiblePanelExtender>
    <asp:Panel ID="pnlPratiuttarContent" runat="server" CssClass="collapsePanel" Width="1024px">
        <asp:UpdatePanel id="UpdatePanel4" runat="server">
            <contenttemplate>
        </contenttemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <br />
    
    <asp:Panel ID="pnlResp" runat="server" CssClass="collapsePanelHeader" Height="25px"
        Width="1024px">
        प्रतिवादि
        <asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageAlign="Right"
            ImageUrl="~/MODULES/COMMON/Images/expand.jpg" Visible="False" />
    </asp:Panel>
    <ajaxToolkit:CollapsiblePanelExtender ID="colRespondent" runat="server" CollapseControlID="pnlResp"
        Collapsed="True" CollapsedImage="../../COMMON/Images/expand_blue.jpg" ExpandControlID="pnlResp"
        ExpandedImage="../../COMMON/Images/collapse_blue.jpg" ImageControlID="imgCol"
        SkinID="CollapsiblePanelDemo" SuppressPostBack="True" TargetControlID="pnlRespList">
    </ajaxToolkit:CollapsiblePanelExtender>
    <asp:Panel ID="pnlRespList" runat="server" Width="1024px">
        <asp:Panel ID="pnlRes" runat="server" BorderColor="#006EA2" BorderStyle="Solid" BorderWidth="1px"
            Height="150px" ScrollBars="Auto" Width="1015px">
            <asp:GridView ID="grdLitigantRes" runat="server" AutoGenerateColumns="False" OnRowDataBound="grdLitigantRes_RowDataBound"
                SkinID="Unicodegrd" Width="1000px">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:CheckBox ID="chkRes" runat="server" />
                        </HeaderTemplate>
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        <ItemTemplate>
                            <asp:CheckBox ID="chkRes" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CaseID" HeaderText="मुद्दाको आइडि">
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LitigantID" HeaderText="Litigant ID">
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CaseRegDate" HeaderText="दर्ता मिति">
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="RegNo" HeaderText="दर्ता नं">
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CaseNo" HeaderText="मुद्दा नं">
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LitigantName" HeaderText="पूरा नामथर">
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Gender" HeaderText="लिंग">
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="DOB" HeaderText="जन्म मिति">
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LitigantTypeName" HeaderText="वादि/प्रतिवादि">
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="DisplayName" HeaderText="देखाउने नाम">
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LitigantSubTypeName">
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SNo" HeaderText="प्राथमीकता">
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="IsPrisoned">
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="50px" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </asp:Panel>
    </asp:Panel>
    <br />

    <asp:Panel ID="pnlEvidence" runat="server" CssClass="collapsePanelHeader" Height="25px"
        Width="1024px">
        प्रमाण
        <asp:ImageButton ID="ImageButton2" runat="server" Height="25px" ImageAlign="Right"
            ImageUrl="~/MODULES/COMMON/Images/expand.jpg" Visible="False" />
    </asp:Panel>
    <ajaxToolkit:CollapsiblePanelExtender ID="colEvidence" runat="server" CollapseControlID="pnlEvidence"
        Collapsed="True" CollapsedImage="../../COMMON/Images/expand_blue.jpg" ExpandControlID="pnlEvidence"
        ExpandedImage="../../COMMON/Images/collapse_blue.jpg" ImageControlID="imgCol"
        SkinID="CollapsiblePanelDemo" SuppressPostBack="True" TargetControlID="pnlEvidenceContent">
    </ajaxToolkit:CollapsiblePanelExtender>
    <asp:Panel ID="pnlEvidenceContent" runat="server" CssClass="collapsePanel" Width="1024px">
        &nbsp;<asp:UpdatePanel id="UpdatePanel3" runat="server"><contenttemplate>
<TABLE style="WIDTH: 1000px"><TBODY><TR><TD style="WIDTH: 50px" vAlign=top><asp:Label id="Label3" runat="server" Width="44px" Text="प्रमाण" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 710px" vAlign=top><asp:TextBox id="txtPraEvidence" runat="server" Width="700px" Height="70px" TextMode="MultiLine"></asp:TextBox></TD><TD vAlign=top><asp:Button id="btnAddEvidence" onclick="btnAddEvidence_Click" runat="server" Text="+" SkinID="Add"></asp:Button></TD></TR><TR><TD style="WIDTH: 50px" vAlign=top></TD><TD style="WIDTH: 710px" vAlign=top><asp:GridView id="grdPraEvidence" runat="server" Width="450px" SkinID="Unicodegrd" OnRowDataBound="grdPraEvidence_RowDataBound" AutoGenerateColumns="False" OnSelectedIndexChanged="grdPraEvidence_SelectedIndexChanged" OnRowDeleting="grdPraEvidence_RowDeleting"><Columns>
<asp:BoundField DataField="CaseID" HeaderText="CaseID"></asp:BoundField>
<asp:BoundField DataField="PRATIUTTARID" HeaderText="PratiuttarID"></asp:BoundField>
<asp:BoundField DataField="EVIDENCEID" HeaderText="EvidenceID"></asp:BoundField>
<asp:BoundField DataField="EVIDENCE" HeaderText="प्रमाण">
<ItemStyle Width="350px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ACTION" HeaderText="Action"></asp:BoundField>
<asp:CommandField ShowSelectButton="True">
<ItemStyle Width="50px"></ItemStyle>
</asp:CommandField>
<asp:CommandField ShowDeleteButton="True">
<ItemStyle Width="50px"></ItemStyle>
</asp:CommandField>
</Columns>
</asp:GridView> </TD><TD vAlign=top></TD></TR></TBODY></TABLE>
</contenttemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <br />
    <asp:Panel ID="pnlDocuments" runat="server" CssClass="collapsePanelHeader" Height="25px"
        Width="1024px">
        कागजपत्र
        <asp:ImageButton ID="ImageButton3" runat="server" Height="25px" ImageAlign="Right"
            ImageUrl="~/MODULES/COMMON/Images/expand.jpg" Visible="False" />
    </asp:Panel>
    <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server"
        CollapseControlID="pnlDocuments" Collapsed="True" CollapsedImage="../../COMMON/Images/expand_blue.jpg"
        ExpandControlID="pnlDocuments" ExpandedImage="../../COMMON/Images/collapse_blue.jpg"
        ImageControlID="imgCol" SkinID="CollapsiblePanelDemo" SuppressPostBack="True"
        TargetControlID="pnlDocumentsContent">
    </ajaxToolkit:CollapsiblePanelExtender>
    <asp:Panel ID="pnlDocumentsContent" runat="server" CssClass="collapsePanel" Width="1024px">
        <table style="width: 900px">
            <tr>
                <td style="width: 70px" valign="top">
                    <asp:Label ID="Label4" runat="server" Text="कागजपत्र" Width="65px" SkinID="Unicodelbl"></asp:Label></td>
                <td style="width: 800px" valign="top">
                    <asp:FileUpload ID="fileUp" runat="server" Width="550px" /></td>
            </tr>
            <tr>
                <td style="width: 70px" valign="top">
                </td>
                <td style="width: 800px" valign="top">
                    <asp:Button ID="btnDocPlus" runat="server" OnClick="btnDocPlus_Click" SkinID="Add"
                        Text="+" /></td>
            </tr>
            <tr>
                <td style="width: 70px" valign="top">
                </td>
                <td style="width: 800px" valign="top">
                    <asp:GridView ID="grdPraDocument" runat="server" AutoGenerateColumns="False" OnRowDataBound="grdPraDocument_RowDataBound"
                        OnRowDeleting="grdPraDocument_RowDeleting" Width="550px" OnSelectedIndexChanged="grdPraDocument_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="CaseID" HeaderText="CaseID" />
                            <asp:BoundField DataField="PratiuttarID" HeaderText="PratiuttarID" />
                            <asp:BoundField DataField="DocumentID" HeaderText="DocumentID" />
                            <asp:TemplateField HeaderText="कागजपत्र">
                                <ItemStyle Width="200px" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkDocumentName" runat="server" OnClick="lnkDocumentName_Click"
                                        Text='<%# Eval("DocumentFileName") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Action" HeaderText="Action" />
                            <asp:CommandField ShowDeleteButton="True">
                                <ItemStyle Width="50px" />
                            </asp:CommandField>
                            <asp:CommandField ShowSelectButton="True">
                                <ItemStyle Width="50px" />
                            </asp:CommandField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>

    <br />
    <table style="width: 1022px">
        <tr>
            <td style="width: 110px" valign="top">
                <asp:Label ID="Label1" runat="server" Text="प्रतिउत्तर मिति" Width="100px" SkinID="Unicodelbl"></asp:Label></td>
            <td valign="top">
                <asp:TextBox ID="txtPraDate_DT" runat="server" Width="85px" ToolTip="प्रतिउत्तर मिति"></asp:TextBox>
                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AutoComplete="False"
                    Mask="9999/99/99" MaskType="Date" TargetControlID="txtPraDate_DT">
                </ajaxToolkit:MaskedEditExtender>
            </td>
        </tr>
        <tr>
            <td style="width: 110px" valign="top">
                <asp:Label ID="Label2" runat="server" Text="संक्षिप्त विवरण" Width="100px" SkinID="Unicodelbl"></asp:Label></td>
            <td valign="top">
                <asp:TextBox ID="txtPraSummary" runat="server" Height="150px" MaxLength="2000"
                    SkinID="Unicodetxt" TextMode="MultiLine" Width="883px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 110px" valign="top">
            </td>
            <td valign="top">
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" OnClientClick="javascript:return validate(1);" SkinID="Normal" /><asp:Button ID="btnCancel" runat="server" SkinID="Cancel" Text="Cancel" /></td>
        </tr>
    </table>
</asp:Content>

