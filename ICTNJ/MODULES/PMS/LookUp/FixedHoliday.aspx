<%@ Page Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master" AutoEventWireup="true" CodeFile="FixedHoliday.aspx.cs" Inherits="MODULES_PMS_LookUp_FixedHoliday" Title="PMS | Holiday" %>

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
<script type="text/javascript">
   </script>
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
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp;
    <asp:Label ID="Label1" runat="server" SkinID="UnicodeHeadlbl" Text="नियमित बिदा"></asp:Label><br />
    <br />
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<TABLE width=800><TBODY><TR><TD style="WIDTH: 22px; HEIGHT: 28px" colSpan=1></TD><TD style="HEIGHT: 28px" colSpan=2><asp:Label id="Label2" runat="server" Width="86px" Height="20px" Text="अवधि देखि" SkinID="UnicodeHeadlbl" Font-Underline="True" __designer:wfdid="w221"></asp:Label></TD><TD style="HEIGHT: 28px" colSpan=2><asp:Label id="Label3" runat="server" Width="87px" Text="अवधि सम्म" SkinID="UnicodeHeadlbl" Font-Underline="True" __designer:wfdid="w222"></asp:Label></TD></TR><TR><TD style="WIDTH: 22px; HEIGHT: 24px" vAlign=top></TD><TD style="WIDTH: 100px; HEIGHT: 24px" vAlign=top><asp:Label id="lblFromMonth" runat="server" Width="119px" Text="महिना/ दिन देखि" SkinID="Unicodelbl" __designer:wfdid="w20"></asp:Label></TD><TD style="WIDTH: 210px; HEIGHT: 24px" vAlign=top><asp:TextBox id="txtFxFromMonth" runat="server" Width="35px" __designer:wfdid="w21"></asp:TextBox> <asp:Label id="Label4" runat="server" Width="5px" Text="/" SkinID="Unicodelbl" __designer:wfdid="w224"></asp:Label> <asp:TextBox id="txtFxFromDay" runat="server" Width="35px" __designer:wfdid="w27"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender1" runat="server" TargetControlID="txtFxFromMonth" __designer:wfdid="w22" MaskType="Number" Mask="99">
                                </ajaxToolkit:MaskedEditExtender> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender3" runat="server" TargetControlID="txtFxFromDay" __designer:wfdid="w28" Mask="99">
                                </ajaxToolkit:MaskedEditExtender></TD><TD style="WIDTH: 84px; HEIGHT: 24px" vAlign=top><asp:Label id="lblToMonth" runat="server" Width="118px" Text="महिना/दिन सम्म" SkinID="Unicodelbl" __designer:wfdid="w23"></asp:Label></TD><TD style="HEIGHT: 24px" vAlign=top><asp:TextBox id="txtFxToMonth" runat="server" Width="35px" __designer:wfdid="w24"></asp:TextBox>&nbsp; <asp:Label id="Label5" runat="server" Text="/" __designer:wfdid="w225"></asp:Label> <asp:TextBox id="txtFxToDay" runat="server" Width="35px" __designer:wfdid="w30"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender2" runat="server" TargetControlID="txtFxToMonth" __designer:wfdid="w25" MaskType="Number" Mask="99">
                                </ajaxToolkit:MaskedEditExtender> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender4" runat="server" TargetControlID="txtFxToDay" __designer:wfdid="w31" Mask="99">
                                </ajaxToolkit:MaskedEditExtender></TD></TR><TR><TD style="WIDTH: 22px; HEIGHT: 84px" vAlign=top></TD><TD style="WIDTH: 100px; HEIGHT: 84px" vAlign=top><asp:Label id="lblDateType" runat="server" Width="113px" Text="मितिको किसिम" SkinID="Unicodelbl" __designer:wfdid="w32"></asp:Label></TD><TD style="WIDTH: 210px; HEIGHT: 84px" vAlign=top><asp:RadioButtonList id="rdoFixDateType" runat="server" Width="130px" Height="13px" SkinID="Unicoderadio" __designer:wfdid="w33" RepeatDirection="Horizontal"><asp:ListItem Value="N">नेपाली</asp:ListItem>
<asp:ListItem Value="E">अंग्रेजी</asp:ListItem>
</asp:RadioButtonList></TD><TD style="WIDTH: 84px; HEIGHT: 84px" vAlign=top><asp:Label id="lblDescription" runat="server" Width="71px" Text="कैफियत" SkinID="Unicodelbl" __designer:wfdid="w34"></asp:Label></TD><TD style="HEIGHT: 84px" vAlign=top><asp:TextBox id="txtFixDescription" runat="server" Width="223px" Height="79px" SkinID="Unicodetxt" __designer:wfdid="w35" TextMode="MultiLine" MaxLength="150"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 22px; HEIGHT: 22px" vAlign=top></TD><TD style="WIDTH: 100px; HEIGHT: 22px" vAlign=top></TD><TD style="WIDTH: 210px; HEIGHT: 22px" vAlign=top></TD><TD style="WIDTH: 84px; HEIGHT: 22px" vAlign=top></TD><TD style="HEIGHT: 22px" vAlign=top><asp:Button id="btnFixedAdd" onclick="btnFixedAdd_Click" runat="server" Width="50px" Text="Add" SkinID="Add" __designer:wfdid="w36"></asp:Button></TD></TR><TR><TD style="WIDTH: 22px" colSpan=1></TD><TD colSpan=4>
<HR />
</TD></TR><TR><TD style="WIDTH: 22px; HEIGHT: 200px" vAlign=top colSpan=1></TD><TD style="HEIGHT: 200px" vAlign=top colSpan=4><asp:Panel id="PnlGrd" runat="server" Width="700px" Height="200px" __designer:wfdid="w37" ScrollBars="Auto"><asp:GridView id="grdFixData" runat="server" Width="650px" SkinID="Unicodegrd" __designer:wfdid="w38" OnRowDataBound="grdFixData_RowDataBound" OnRowDeleting="grdFixData_RowDeleting" AutoGenerateColumns="False" GridLines="None" ForeColor="#333333" CellPadding="0" OnRowCreated="grdFixData_RowCreated">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
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
<asp:TemplateField><ItemTemplate>
    <asp:LinkButton ID="btnDelete" CommandName="Delete" runat="server">Delete</asp:LinkButton>                              
</ItemTemplate>
</asp:TemplateField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> </asp:Panel> </TD></TR></TBODY></TABLE><TABLE style="WIDTH: 154px"><TBODY><TR><TD style="WIDTH: 210px">&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button id="btnSubmit" onclick="btnSubmit_Click" runat="server" Text="Submit" SkinID="Normal" __designer:wfdid="w27"></asp:Button> <asp:Button id="btnCancel" onclick="btnCancel_Click" runat="server" Text="Cancel" SkinID="Cancel" __designer:wfdid="w28"></asp:Button></TD></TR></TBODY></TABLE>
</contenttemplate>
    </asp:UpdatePanel>
    <br />
    <br />
</asp:Content>

