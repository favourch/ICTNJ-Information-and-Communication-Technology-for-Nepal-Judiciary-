<%@ Page Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master" AutoEventWireup="true" CodeFile="AnnualHoliday.aspx.cs" Inherits="MODULES_PMS_LookUp_AnnualHoliday" Title="PMS | Annual Holiday" %>
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
<script type="text/javascript"></script>
<script type="text/javascript" src="../../COMMON/JS/jquery.min.js"></script>
<script type="text/javascript" src="../../COMMON/JS/scrolltopcontrol.js"></script>  
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
            <asp:UpdatePanel id="UpdatePanel2" runat="server">
                <contenttemplate>
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
</contenttemplate>
            </asp:UpdatePanel>
            <br />
<asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click" Width="58px" />           <br />
        </asp:Panel>    
            &nbsp;
    <br />
    &nbsp; &nbsp; &nbsp;
    <asp:Label ID="Label1" runat="server" SkinID="UnicodeHeadlbl" Text="वार्षिक बिदा"></asp:Label>
    <br />
    <br />
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<TABLE><TBODY><TR><TD style="WIDTH: 18px"></TD><TD style="WIDTH: 40px"><asp:Label id="lblFiscalYear" runat="server" Width="33px" Text="वर्ष" SkinID="Unicodelbl" __designer:wfdid="w1"></asp:Label></TD><TD><asp:DropDownList id="ddlYear2" runat="server" Width="136px" __designer:wfdid="w2" OnSelectedIndexChanged="ddlYear2_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList></TD></TR></TBODY></TABLE><asp:Panel id="Panel1" runat="server" Width="700px" Height="175px" __designer:wfdid="w3" ScrollBars="Auto"><BR />
                    <asp:GridView id="grdFixData" runat="server" Width="650px" SkinID="Unicodegrd" __designer:wfdid="w4" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333" GridLines="None" OnRowCreated="grdFixData_RowCreated">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:TemplateField ShowHeader="False">
<HeaderTemplate>
<asp:CheckBox id="chk" runat="server"  OnCheckedChanged="chkHeader_CheckedChanged" AutoPostBack="true" ></asp:CheckBox> 
</HeaderTemplate>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
<ItemTemplate>
<asp:CheckBox id="chk" runat="server" OnCheckedChanged="chk_CheckedChanged" HorizontalAlign="Center" VerticalAlign="Middle" AutoPostBack="true"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="FromMonth" HeaderText="महिना देखि">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="ToMonth" HeaderText="महिना सम्म">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="FromDay" HeaderText="दिन देखि">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="ToDay" HeaderText="दिन सम्म">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="DateFullType" HeaderText="मितिको किसिम">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="HolidayDescription" HeaderText="कैफियत">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="Action" HeaderText="Action"></asp:BoundField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView></asp:Panel><TABLE style="HEIGHT: 250px" width=800><TBODY><TR><TD style="WIDTH: 21px; HEIGHT: 10px" vAlign=top colSpan=1></TD><TD style="HEIGHT: 10px" vAlign=top colSpan=4>
<HR />
</TD></TR><TR><TD style="WIDTH: 21px; HEIGHT: 30px" vAlign=top colSpan=1></TD><TD style="HEIGHT: 30px" vAlign=top colSpan=4><asp:Button id="btnPrevYear" onclick="btnPrevYear_Click" runat="server" Width="348px" Text="Load Holiday's of Previous Year" SkinID="Submit" __designer:wfdid="w5"></asp:Button></TD></TR><TR><TD style="WIDTH: 21px; HEIGHT: 30px" vAlign=top colSpan=1></TD><TD style="HEIGHT: 30px" vAlign=top colSpan=4><asp:UpdatePanel id="UpdatePanel3" runat="server" __designer:dtid="562949953421331" __designer:wfdid="w218"><ContentTemplate __designer:dtid="562949953421332">
<asp:Label id="lblRecordNoPopUp" runat="server" __designer:dtid="562949953421331" __designer:wfdid="w23"></asp:Label><BR /><asp:GridView id="grdPrevData" runat="server" Width="502px" SkinID="Unicodegrd" __designer:wfdid="w24" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333" GridLines="None">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:TemplateField ShowHeader="False"><HeaderTemplate>
<asp:CheckBox id="chk1" runat="server" OnCheckedChanged="chkHeader1_CheckedChanged" AutoPostBack="true" ></asp:CheckBox> 
</HeaderTemplate>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
<ItemTemplate>
<asp:CheckBox id="chk1" runat="server" OnCheckedChanged="chk1_CheckedChanged" AutoPostBack="true" HorizontalAlign="Center" VerticalAlign="Middle"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="FY" HeaderText="वर्ष">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="FromDate" HeaderText="बिदा देखि">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ToDate" HeaderText="बिदा सम्म">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="HolidayDescription" HeaderText="कैफिएत">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> 
</ContentTemplate>
</asp:UpdatePanel></TD></TR><TR><TD style="WIDTH: 21px; HEIGHT: 7px" vAlign=top colSpan=1></TD><TD style="HEIGHT: 7px" vAlign=top colSpan=4>
<HR />
</TD></TR><TR><TD style="WIDTH: 21px; HEIGHT: 30px" vAlign=top></TD><TD style="WIDTH: 87px; HEIGHT: 30px" vAlign=top><asp:Label id="lblAnnFromMonth" runat="server" Text="देखि" SkinID="Unicodelbl" __designer:wfdid="w9"></asp:Label></TD><TD style="WIDTH: 266px; HEIGHT: 30px" vAlign=top><asp:TextBox id="txtAnnFromDate" runat="server" Width="73px" __designer:wfdid="w10"></asp:TextBox> <ajaxtoolkit:maskededitextender id="MaskedEditExtender5" runat="server" __designer:wfdid="w11" AutoComplete="False" targetcontrolid="txtAnnFromDate" masktype="Date" mask="9999/99/99"></ajaxtoolkit:maskededitextender></TD><TD style="WIDTH: 40px; HEIGHT: 30px" vAlign=top><asp:Label id="lblAnnToMonth" runat="server" Width="37px" Text="सम्म" SkinID="Unicodelbl" __designer:wfdid="w12"></asp:Label></TD><TD style="HEIGHT: 30px" vAlign=top><asp:TextBox id="txtAnnToDate" runat="server" Width="73px" __designer:wfdid="w13"></asp:TextBox> <ajaxtoolkit:maskededitextender id="MaskedEditExtender6" runat="server" __designer:wfdid="w14" AutoComplete="False" targetcontrolid="txtAnnToDate" masktype="Date" mask="9999/99/99"></ajaxtoolkit:maskededitextender></TD></TR><TR><TD style="WIDTH: 21px" vAlign=top></TD><TD style="WIDTH: 87px" vAlign=top><asp:Label id="lblAppDescription" runat="server" Width="94px" Text="कैफियत" SkinID="Unicodelbl" __designer:wfdid="w15"></asp:Label></TD><TD style="WIDTH: 266px" vAlign=top><asp:TextBox id="txtAnnDescription" runat="server" Width="225px" Height="80px" SkinID="Unicodetxt" __designer:wfdid="w16" TextMode="MultiLine"></asp:TextBox></TD><TD style="WIDTH: 40px" vAlign=top><asp:Label id="Label2" runat="server" Width="111px" Text="मितिको किसिम" SkinID="Unicodelbl" __designer:wfdid="w1"></asp:Label></TD><TD vAlign=top><asp:RadioButtonList id="rdoDateType" runat="server" SkinID="Unicoderadio" __designer:wfdid="w2" RepeatDirection="Horizontal"><asp:ListItem Selected="True" Value="0">नेपाली</asp:ListItem>
<asp:ListItem Value="1">अँग्रेजी</asp:ListItem>
</asp:RadioButtonList></TD></TR><TR><TD style="WIDTH: 21px" vAlign=top></TD><TD style="WIDTH: 87px" vAlign=top></TD><TD style="WIDTH: 266px" vAlign=top><asp:Button id="btnAppAdd" onclick="btnAppAdd_Click" runat="server" Width="50px" Text="Add" SkinID="Add" __designer:wfdid="w17"></asp:Button></TD><TD style="WIDTH: 40px" vAlign=bottom></TD><TD vAlign=top></TD></TR><TR><TD style="WIDTH: 21px; HEIGHT: 21px" colSpan=1></TD><TD style="HEIGHT: 21px" colSpan=4>
<HR />
</TD></TR><TR><TD style="WIDTH: 21px; HEIGHT: 160px" colSpan=1></TD><TD style="HEIGHT: 160px" colSpan=4><asp:Label id="lblStatus" runat="server" Width="190px" SkinID="UnicodeHeadlbl" __designer:wfdid="w18"></asp:Label> <asp:Panel id="pnlAnnGrd" runat="server" Width="700px" Height="150px" __designer:wfdid="w19" ScrollBars="Auto"><asp:GridView id="grdAnnualData" runat="server" Width="650px" SkinID="Unicodegrd" __designer:wfdid="w20" OnRowCreated="grdAnnualData_RowCreated" GridLines="None" ForeColor="#333333" CellPadding="0" AutoGenerateColumns="False" OnRowDeleting="grdAnnualData_RowDeleting" OnRowDataBound="grdAnnualData_RowDataBound">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="OrgID" HeaderText="OrgID"></asp:BoundField>
<asp:BoundField DataField="FY" HeaderText="वर्ष"></asp:BoundField>
<asp:TemplateField HeaderText="देखि">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
<ItemTemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("FromDate") %>' __designer:wfdid="w3" width="73px" HorizontalAlign="Center" VerticalAlign="Middle"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender1" runat="server" TargetControlID="TextBox1" __designer:wfdid="w4" AutoComplete="False" MaskType="Date" Mask="9999/99/99"></ajaxToolkit:MaskedEditExtender> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="सम्म">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
<ItemTemplate>
<asp:TextBox id="TextBox2" runat="server" Text='<%# Bind("ToDate") %>' __designer:wfdid="w6" width="73px" HorizontalAlign="Center" VerticalAlign="Middle"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender2" runat="server" TargetControlID="TextBox2" __designer:wfdid="w7" Mask="9999/99/99" MaskType="Date" AutoComplete="False"></ajaxToolkit:MaskedEditExtender>
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="HolidayDescription" HeaderText="बिदाको कैफियत">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="DateType" HeaderText="Date Type">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Action" HeaderText="Action"></asp:BoundField>
<asp:TemplateField>
<ItemStyle Width="73px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
<ItemTemplate>
       <asp:LinkButton ID="btnDeleteAnn" runat="server" CommandName="Delete">Delete</asp:LinkButton>
                                    
</ItemTemplate>
</asp:TemplateField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> </asp:Panel> <BR /></TD></TR></TBODY></TABLE>
<HR />
<TABLE><TBODY><TR><TD>&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button id="btnSubmit" onclick="btnSubmit_Click" runat="server" Text="Submit" SkinID="Normal" __designer:wfdid="w21"></asp:Button> <asp:Button id="btnCancel" onclick="btnCancel_Click" runat="server" Text="Cancel" SkinID="Cancel" __designer:wfdid="w22"></asp:Button></TD></TR></TBODY></TABLE>
</contenttemplate>
    </asp:UpdatePanel>
    <br />
</asp:Content>

