<%@ Page Language="C#" MasterPageFile="~/MODULES/Common/MasterPage.master" AutoEventWireup="true" CodeFile="Degree.aspx.cs" Inherits="MODULES_Common_LookUp_Degree" Title="PMS | Degrees" %>


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
                    <div style="padding: 10px; text-align: center">

            <asp:Panel runat="Server" ID="programmaticPopupDragHandle" Style="cursor: move;background-color:#DDDDDD;border:solid 1px Gray;color:Black;text-align:center;">
                Save Status
            </asp:Panel>
                        <asp:UpdatePanel id="UpdatePanel2" runat="server">
                            <contenttemplate>
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
</contenttemplate>
                        </asp:UpdatePanel>&nbsp;<br />
<asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click" Width="58px" />  
</div>
        </asp:Panel>  
        
 <script language="javascript" type="text/javascript" src="../JS/Validation.js"></script>

    <br />
    &nbsp;&nbsp;
    <asp:Label ID="Label3" runat="server" SkinID="UnicodeHeadlbl">शौक्षिक योग्यताको तह</asp:Label>&nbsp;<br />
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<TABLE style="WIDTH: 500px; HEIGHT: 238px"><TBODY><TR><TD style="WIDTH: 6920217px" vAlign=top align=left rowSpan=5></TD><TD style="WIDTH: 246px" vAlign=top rowSpan=4><asp:ListBox id="lstDegreeLevel" runat="server" Width="246px" Height="255px" SkinID="Unicodelst" OnSelectedIndexChanged="lstDegreeLevel_SelectedIndexChanged" AutoPostBack="True" __designer:wfdid="w19"></asp:ListBox></TD><TD style="WIDTH: 95px" vAlign=top><asp:Label id="lblDegreeLevelName" runat="server" Width="84px" SkinID="Unicodelbl" Text="डिग्रीको तह"></asp:Label></TD><TD style="WIDTH: 265px" vAlign=top><asp:TextBox id="txtDegreeLevelName_Rqd" runat="server" Width="194px" SkinID="Unicodetxt" ToolTip="Degree Level Name"></asp:TextBox></TD><TD vAlign=top><asp:CheckBox id="chkActiveDL" runat="server" Width="75px" SkinID="smallChk" Text="शक्रिय" TextAlign="Left"></asp:CheckBox></TD></TR><TR><TD style="WIDTH: 95px" vAlign=top><asp:Label id="Label2" runat="server" Width="93px" SkinID="Unicodelbl" Text="डिग्रीको नाम"></asp:Label></TD><TD style="WIDTH: 265px" vAlign=top><asp:TextBox id="txtDegreeName" runat="server" Width="262px" SkinID="Unicodetxt" ToolTip="Degree Name"></asp:TextBox></TD><TD vAlign=top><asp:CheckBox id="chkActiveDegree" runat="server" Width="75px" SkinID="smallChk" Text="शक्रिय" TextAlign="Left"></asp:CheckBox></TD></TR><TR><TD style="WIDTH: 95px" vAlign=top></TD><TD style="WIDTH: 265px" vAlign=top><asp:Button id="btnAddDegreeName" onclick="btnAddDegreeName_Click1" runat="server" SkinID="Add" Text="+"></asp:Button></TD><TD vAlign=top></TD></TR><TR><TD vAlign=top colSpan=3><asp:GridView id="grdDegree" runat="server" Width="550px" SkinID="Unicodegrd" ForeColor="#333333" OnSelectedIndexChanged="grdDegree_SelectedIndexChanged" OnRowDeleting="grdDegree_RowDeleting" OnRowCreated="grdDegree_RowCreated" GridLines="None" CellPadding="0" AutoGenerateColumns="False">
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:BoundField DataField="DegreeID" HeaderText="Degree ID" />
                        <asp:BoundField DataField="DegreeLevelID" HeaderText="Degree Level ID" />
                        <asp:BoundField DataField="DegreeName" HeaderText="डिग्रीको नाम" >
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
                        <asp:BoundField DataField="Active" HeaderText="शक्रिय" >
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
                        <asp:BoundField DataField="Flag" HeaderText="Flag" />
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:CommandField ShowDeleteButton="True" />
                    </Columns>
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <EditRowStyle BackColor="#999999" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView> </TD></TR><TR><TD style="WIDTH: 246px" vAlign=top align=left colSpan=1 rowSpan=1></TD><TD vAlign=top align=left colSpan=3 rowSpan=1><asp:Button id="btnSubmit" onclick="btnSubmit_Click" runat="server" SkinID="Normal" Text="Submit" OnClientClick="javascript:return validate();"></asp:Button><asp:Button id="btnCancel" onclick="btnCancel_Click" runat="server" Width="72px" SkinID="Cancel" Text="Cancel"></asp:Button></TD></TR></TBODY></TABLE>
</contenttemplate>
    </asp:UpdatePanel>
    <br />
    &nbsp;

</asp:Content>

