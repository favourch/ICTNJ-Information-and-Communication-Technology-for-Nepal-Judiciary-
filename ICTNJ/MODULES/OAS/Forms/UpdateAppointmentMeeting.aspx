<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true" CodeFile="UpdateAppointmentMeeting.aspx.cs" Inherits="MODULES_OAS_Forms_UpdateAppointMeeting" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style ="width:100%">
    <br />
   
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>&nbsp;
    <div id="dvMeeting"  style="overflow: auto; width: 100%">
        <asp:UpdatePanel id="mydiv" runat="server">
            <contenttemplate>
<TABLE style="BORDER-LEFT-COLOR: black; BORDER-BOTTOM-COLOR: black; BORDER-TOP-COLOR: black; BORDER-RIGHT-COLOR: black" cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR><TD style="HEIGHT: 5px" vAlign=top align=center width="80%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </TD></TR><TR><TD style="HEIGHT: 2px" vAlign=top>&nbsp;<asp:Label id="lblCreateMeetingStatus" runat="server" CssClass="errorlabel" Font-Bold="True" __designer:wfdid="w21"></asp:Label></TD></TR><TR><TD style="PADDING-LEFT: 30px; HEIGHT: 19px" class="tblTDleft" align=left>&nbsp;<asp:ImageButton id="imgBtnExpand1" runat="server" ImageUrl="~/MODULES/OAS/Images/expand.jpg" __designer:wfdid="w22"></asp:ImageButton>&nbsp; <asp:Label id="lblTest" runat="server" Text="Label" __designer:wfdid="w23"></asp:Label></TD></TR><TR><TD align=center><asp:Panel style="POSITION: static" id="pnlMeeting" runat="server" Width="95%" __designer:wfdid="w24" BorderColor="#c8cde4" BorderStyle="Solid" BorderWidth="1px"><TABLE style="BORDER-LEFT-COLOR: black; BORDER-BOTTOM-COLOR: black; BORDER-TOP-COLOR: black; BORDER-RIGHT-COLOR: black" cellSpacing=0 cellPadding=0 width="98%" border=0><TBODY><TR><TD style="WIDTH: 81px; HEIGHT: 5px"></TD></TR><TR><TD style="WIDTH: 81px"></TD></TR><TR><TD style="HEIGHT: 25px" class="tblTDRight" align=left><asp:Label id="lblMeeting" runat="server" Text="Meeting" Font-Bold="True" __designer:wfdid="w25" Font-Underline="True"></asp:Label> </TD></TR><TR><TD style="HEIGHT: 13px" class="tblTDRight"><asp:Label id="lblOrganisation" runat="server" Text="Organisation" __designer:wfdid="w26"></asp:Label> &nbsp;<asp:Label id="Label4180" runat="server" CssClass="simplelabel" Text="*" ForeColor="red" __designer:wfdid="w27"></asp:Label> </TD><TD style="HEIGHT: 13px" class="tblTDLeft"><asp:DropDownList id="drpOrganisation_rqd" tabIndex=1 runat="server" Width="158px" __designer:wfdid="w28" ToolTip="Organisation" AutoPostBack="True"></asp:DropDownList> </TD><TD style="WIDTH: 108px; HEIGHT: 13px" class="tblTDRight"><asp:Label id="lblUnit" runat="server" Text="Unit" __designer:wfdid="w29"></asp:Label> <asp:Label id="Label3" runat="server" CssClass="simplelabel" Text="*" ForeColor="red" __designer:wfdid="w30"></asp:Label></TD><TD style="HEIGHT: 13px" class="tblTDLeft"><asp:DropDownList id="drpUnit_rqd" tabIndex=2 runat="server" Width="158px" __designer:wfdid="w31" ToolTip="Unit"></asp:DropDownList></TD></TR><TR><TD style="HEIGHT: 25px" class="tblTDRight"><asp:Label id="lblMeetingDate" runat="server" Text=" Meeting Date" __designer:wfdid="w32"></asp:Label> &nbsp;<asp:Label id="Label418" runat="server" CssClass="simplelabel" Text="*" ForeColor="red" __designer:wfdid="w33"></asp:Label> </TD><TD class="tblTDLeft" colSpan=3><asp:TextBox id="txtMeetingDate_rqd" tabIndex=3 runat="server" Width="436px" SkinID="PNYM" Font-Names="PCS NEPALI" __designer:wfdid="w34" ToolTip="Meeting Date"></asp:TextBox> </TD></TR><TR><TD style="HEIGHT: 25px" class="tblTDRight"><asp:Label id="lblStartTime" runat="server" Text="Start Time" __designer:wfdid="w35"></asp:Label> &nbsp;<asp:Label id="Label419" runat="server" CssClass="simplelabel" Text="*" ForeColor="red" __designer:wfdid="w36"></asp:Label> </TD><TD class="tblTDLeft"><asp:DropDownList id="drpHr1_rqd" tabIndex=4 runat="server" Width="42px" __designer:wfdid="w37" ToolTip="Hour"><asp:ListItem Value="0"> HR:</asp:ListItem>
            <asp:ListItem>01</asp:ListItem>
            <asp:ListItem>02</asp:ListItem>
            <asp:ListItem>03</asp:ListItem>
            <asp:ListItem Value="4">04</asp:ListItem>
            <asp:ListItem>05</asp:ListItem>
            <asp:ListItem>06</asp:ListItem>
            <asp:ListItem>07</asp:ListItem>
            <asp:ListItem>08</asp:ListItem>
            <asp:ListItem>09</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>11</asp:ListItem>
            <asp:ListItem>12</asp:ListItem>
            </asp:DropDownList>&nbsp;&nbsp;<asp:Label id="lblSep1" runat="server" Width="1px" Height="14px" Text=":" Font-Bold="True" __designer:wfdid="w38"></asp:Label> &nbsp; <asp:DropDownList id="drpMin1_rqd" tabIndex=5 runat="server" Width="44px" __designer:wfdid="w39" ToolTip="Minute"><asp:ListItem Value="0">Min:</asp:ListItem>
            <asp:ListItem>00</asp:ListItem>
            <asp:ListItem>05</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem Value="15"></asp:ListItem>
            <asp:ListItem>20</asp:ListItem>
            <asp:ListItem>25</asp:ListItem>
            <asp:ListItem>30</asp:ListItem>
            <asp:ListItem>35</asp:ListItem>
            <asp:ListItem>40</asp:ListItem>
            <asp:ListItem>45</asp:ListItem>
            <asp:ListItem>50</asp:ListItem>
            <asp:ListItem>55</asp:ListItem>
            <asp:ListItem>60</asp:ListItem>
            </asp:DropDownList> <asp:DropDownList id="drpAmPm1" tabIndex=6 runat="server" Width="46px" __designer:wfdid="w40" ToolTip="AM or PM"><asp:ListItem Value="0">AM</asp:ListItem>
            <asp:ListItem Value="1">PM</asp:ListItem>
            </asp:DropDownList></TD><TD style="WIDTH: 108px; HEIGHT: 25px" class="tblTDRight"><asp:Label id="lblEndTime" runat="server" Text="End Time" __designer:wfdid="w41"></asp:Label> &nbsp;<asp:Label id="Label420" runat="server" CssClass="simplelabel" Text="*" ForeColor="red" __designer:wfdid="w42"></asp:Label> </TD><TD class="tblTDLeft"><asp:DropDownList id="drpHr2_rqd" tabIndex=7 runat="server" Width="40px" __designer:wfdid="w43" ToolTip="Hour"><asp:ListItem Value="0"> HR:</asp:ListItem>
            <asp:ListItem>01</asp:ListItem>
            <asp:ListItem>02</asp:ListItem>
            <asp:ListItem>03</asp:ListItem>
            <asp:ListItem Value="4">04</asp:ListItem>
            <asp:ListItem>05</asp:ListItem>
            <asp:ListItem>06</asp:ListItem>
            <asp:ListItem>07</asp:ListItem>
            <asp:ListItem>08</asp:ListItem>
            <asp:ListItem>09</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>11</asp:ListItem>
            <asp:ListItem>12</asp:ListItem>
            </asp:DropDownList> &nbsp; <asp:Label id="Label5" runat="server" Width="0px" Height="14px" Text=":" Font-Bold="True" __designer:wfdid="w44"></asp:Label> &nbsp; <asp:DropDownList id="drpMin2_rqd" tabIndex=8 runat="server" Width="44px" __designer:wfdid="w45" ToolTip="Minute"><asp:ListItem Value="0">Min:</asp:ListItem>
            <asp:ListItem Value="00">00</asp:ListItem>
            <asp:ListItem>05</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem Value="15"></asp:ListItem>
            <asp:ListItem>20</asp:ListItem>
            <asp:ListItem>25</asp:ListItem>
            <asp:ListItem>30</asp:ListItem>
            <asp:ListItem>35</asp:ListItem>
            <asp:ListItem>40</asp:ListItem>
            <asp:ListItem>45</asp:ListItem>
            <asp:ListItem>50</asp:ListItem>
            <asp:ListItem>55</asp:ListItem>
            <asp:ListItem>60</asp:ListItem>
            </asp:DropDownList> <asp:DropDownList id="drpAmPm2" tabIndex=9 runat="server" Width="46px" __designer:wfdid="w46" ToolTip="AM or PM"><asp:ListItem Value="0">AM</asp:ListItem>
            <asp:ListItem Value="1">PM</asp:ListItem>
            </asp:DropDownList></TD></TR><TR><TD style="HEIGHT: 25px" class="tblTDRight"><asp:Label id="lblMeetingType" runat="server" Text="Meeting Type" __designer:wfdid="w47"></asp:Label>&nbsp;<asp:Label id="Label9" runat="server" CssClass="simplelabel" Text="*" ForeColor="red" __designer:wfdid="w48"></asp:Label> </TD><TD style="WIDTH: 173px; HEIGHT: 25px" class="tblTDLeft"><asp:DropDownList id="drpMeetingType_rqd" tabIndex=11 runat="server" Width="158px" __designer:wfdid="w49" ToolTip="Meeting Type"></asp:DropDownList></TD><TD style="WIDTH: 108px; HEIGHT: 25px" class="tblTDRight"><asp:Label id="lblVenue" runat="server" Text="Venue" __designer:wfdid="w50"></asp:Label> &nbsp;<asp:Label id="Label10" runat="server" CssClass="simplelabel" Text="*" ForeColor="red" __designer:wfdid="w51"></asp:Label> </TD><TD style="HEIGHT: 25px" class="tblTDLeft"><asp:DropDownList id="drpVenue_rqd" tabIndex=12 runat="server" Width="158px" __designer:wfdid="w52" ToolTip="Venue"></asp:DropDownList>&nbsp; </TD></TR><TR><TD style="HEIGHT: 25px" class="tblTDRight"><asp:Label id="lblMeetingCalledBy" runat="server" Text="Called By" __designer:wfdid="w53"></asp:Label> &nbsp;<asp:Label id="Label408" runat="server" CssClass="simplelabel" Text="*" ForeColor="red" __designer:wfdid="w54"></asp:Label> </TD><TD style="WIDTH: 176px; HEIGHT: 25px" class="tblTDLeft" colSpan=3><asp:DropDownList id="drpCalledBy_rqd" tabIndex=13 runat="server" Width="158px" __designer:wfdid="w55" ToolTip="Called By"></asp:DropDownList></TD></TR><TR></TR><TR><TD style="HEIGHT: 25px" class="tblTDRight"><asp:Label id="lblMeetingSubject" runat="server" Width="80px" Text=" Subject" __designer:wfdid="w56"></asp:Label> &nbsp;<asp:Label id="Label48" runat="server" CssClass="simplelabel" Text="*" ForeColor="red" __designer:wfdid="w57"></asp:Label> </TD><TD style="HEIGHT: 25px" class="tblTDLeft" vAlign=middle colSpan=3><asp:TextBox id="txtSubject_rqd" tabIndex=14 runat="server" Width="436px" __designer:wfdid="w58" ToolTip="Meeting Subject"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 81px" height=1>&nbsp;</TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR><TD style="PADDING-LEFT: 26px; HEIGHT: 19px" class="tblTDleft" align=left>&nbsp;&nbsp;<asp:ImageButton id="imgBtnExpand2" runat="server" ImageUrl="~/MODULES/OAS/Images/collapse.jpg" __designer:wfdid="w59"></asp:ImageButton>&nbsp; <asp:Label id="lblExpandStatus2" runat="server" Text="Label" __designer:wfdid="w60"></asp:Label></TD></TR><TR><TD></TD></TR><TR><TD align=center><asp:Panel style="POSITION: static" id="pnlMeetingAgenda" runat="server" Width="95%" __designer:wfdid="w61" BorderColor="#c8cde4" BorderStyle="Solid" BorderWidth="1px"><TABLE style="BORDER-LEFT-COLOR: black; BORDER-BOTTOM-COLOR: black; BORDER-TOP-COLOR: black; BORDER-RIGHT-COLOR: black" cellSpacing=0 cellPadding=0 width="98%" border=0><TBODY><TR><TD style="HEIGHT: 25px" class="tblTDRight" align=left colSpan=1><asp:Label id="lblMeetingAgenda" runat="server" Text="Meeting Agenda" Font-Bold="True" __designer:wfdid="w62" Font-Underline="True"></asp:Label></TD><TD style="HEIGHT: 25px" align=left colSpan=4>&nbsp;</TD></TR><TR><TD style="HEIGHT: 25px" class="tblTDRight"><asp:Label id="lblAgenda" runat="server" Text="Agenda" __designer:wfdid="w63"></asp:Label> &nbsp;<asp:Label id="Label4145" runat="server" CssClass="simplelabel" Text="*" ForeColor="red" __designer:wfdid="w64"></asp:Label> </TD><TD class="tblTDLeft" colSpan=3><asp:TextBox id="txtAgenda" tabIndex=15 runat="server" Width="330px" __designer:wfdid="w65"></asp:TextBox> </TD><TD><asp:ImageButton id="btnAdd" tabIndex=16 runat="server" ImageUrl="~/MODULES/OAS/Images/add.png" __designer:wfdid="w66"></asp:ImageButton> </TD></TR><TR><TD>&nbsp;</TD><TD class="tblTDLeft" vAlign=top align=left colSpan=3><asp:UpdatePanel id="updAgenda" runat="server" __designer:wfdid="w67"><ContentTemplate>
            <DIV style="OVERFLOW: auto" border="0"><asp:GridView id="grdAgenda" runat="server" Width="336px" ForeColor="#333333" AutoGenerateColumns="False" CellPadding="4" GridLines="None" __designer:wfdid="w68">
            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
            <Columns>
            <asp:TemplateField HeaderText="S.No">
            <ItemStyle Width="5px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

            <HeaderStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
            <ItemTemplate>
                <%# Container.DataItemIndex + 1 %> 
                       
                                                        
            </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Agenda" HeaderText="Agenda"></asp:BoundField>
            </Columns>

            <RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

            <EditRowStyle BackColor="#999999"></EditRowStyle>

            <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

            <HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

            <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
            </asp:GridView> </DIV>
            </ContentTemplate>
            </asp:UpdatePanel> </TD></TR><TR><TD height=1>&nbsp;</TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR><TD style="PADDING-LEFT: 30px; HEIGHT: 1px" class="tblleft" align=left>&nbsp;<asp:ImageButton id="imgBtnExpand3" runat="server" ImageUrl="~/MODULES/OAS/Images/collapse.jpg" __designer:wfdid="w69"></asp:ImageButton>&nbsp; <asp:Label id="lblExpandStatus3" runat="server" Text="Label" __designer:wfdid="w70"></asp:Label></TD></TR><TR><TD style="HEIGHT: 19px"></TD></TR><TR><TD align=center><asp:Panel style="POSITION: static" id="pnlParticipant" runat="server" Width="95%" __designer:wfdid="w71" BorderColor="#c8cde4" BorderStyle="Solid" BorderWidth="1px"><TABLE style="BORDER-LEFT-COLOR: black; BORDER-BOTTOM-COLOR: black; WIDTH: 96%; BORDER-TOP-COLOR: black; BORDER-RIGHT-COLOR: black" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="HEIGHT: 5px" colSpan=4></TD></TR><TR><TD style="HEIGHT: 25px" class="tblTDRight" align=left><asp:Label id="lblMeetingParticipant" runat="server" Text="Meeting Participant" Font-Bold="True" __designer:wfdid="w72" Font-Underline="True"></asp:Label> </TD></TR><TR><TD style="HEIGHT: 25px" class="tblTDRight"><asp:Label id="lblParticipant" runat="server" Text="Participant" __designer:wfdid="w73"></asp:Label> &nbsp;<asp:Label id="Label4182" runat="server" CssClass="simplelabel" Text="*" ForeColor="red" __designer:wfdid="w74"></asp:Label> </TD><TD class="tblTDLeft" colSpan=3><asp:DropDownList id="drpParticipant" tabIndex=17 runat="server" Width="158px" __designer:wfdid="w75"><asp:ListItem Value="0">select</asp:ListItem>
            <asp:ListItem Value="1">Raj</asp:ListItem>
            <asp:ListItem Value="2">Rush</asp:ListItem>
            <asp:ListItem Value="3">Rosh</asp:ListItem>
            <asp:ListItem Value="4">Sus</asp:ListItem>
            </asp:DropDownList> </TD></TR><TR><TD style="HEIGHT: 25px" class="tblTDRight"><asp:Label id="lblNote" runat="server" Text="Note" __designer:wfdid="w76"></asp:Label> &nbsp;<asp:Label id="Label4183" runat="server" CssClass="simplelabel" Text="*" ForeColor="red" __designer:wfdid="w77"></asp:Label> </TD><TD class="tblTDLeft" colSpan=3><asp:TextBox id="txtNote" tabIndex=18 runat="server" Width="330px" __designer:wfdid="w78"></asp:TextBox> </TD><TD><asp:ImageButton id="btnParitcipantAdd" tabIndex=19 runat="server" ImageUrl="~/MODULES/OAS/Images/add.png" __designer:wfdid="w79"></asp:ImageButton> </TD></TR><TR><TD>&nbsp;</TD><TD class="tblTDLeft" vAlign=top align=left colSpan=3><asp:UpdatePanel id="updParticipant" runat="server" __designer:wfdid="w80"><ContentTemplate>
            <DIV style="OVERFLOW: auto" border="0"><asp:GridView id="grdParticipant" runat="server" Width="336px" ForeColor="#333333" AutoGenerateColumns="False" CellPadding="4" GridLines="None" __designer:wfdid="w81">
            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
            <Columns>
            <asp:TemplateField HeaderText="S.No">
            <ItemStyle Width="5px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

            <HeaderStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
            <ItemTemplate>
                <%# Container.DataItemIndex + 1 %> 
                       
                                                        
            </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ParticipantID" HeaderText="ParticipantID"></asp:BoundField>
            <asp:BoundField DataField="Participant" HeaderText="Participant">
            <ItemStyle Width="25%"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Note" HeaderText="Note"></asp:BoundField>
            </Columns>

            <RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

            <EditRowStyle BackColor="#999999"></EditRowStyle>

            <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

            <HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

            <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
            </asp:GridView> </DIV>
            </ContentTemplate>
            </asp:UpdatePanel> </TD></TR><TR><TD height=1>&nbsp; </TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR><TD height=1>&nbsp;</TD></TR><TR><TD style="PADDING-RIGHT: 15px" align=right><asp:Button id="btnRedirect" onclick="btnRedirect_Click" runat="server" Text="Update" __designer:dtid="844424930131972" __designer:wfdid="w1"></asp:Button> <asp:Button id="btnDelete" runat="server" Text="Delete" __designer:wfdid="w82"></asp:Button>&nbsp;&nbsp;</TD></TR><TR><TD style="HEIGHT: 187px">&nbsp;</TD></TR></TBODY></TABLE><cc1:CollapsiblePanelExtender id="CollapsiblePanelExtender1" runat="server" __designer:wfdid="w84" SuppressPostBack="True" CollapsedText="Show Meeting ..." ExpandedText="Hide Meeting ..." ExpandedSize="250" CollapsedSize="0" TargetControlID="pnlMeeting" CollapseControlID="imgBtnExpand1" ExpandControlID="imgBtnExpand1" ImageControlID="imgBtnExpand1" CollapsedImage="~/MODULES/OAS/Images/expand.jpg" ExpandedImage="~/MODULES/OAS/Images/collapse.jpg" TextLabelID="lblTest"></cc1:CollapsiblePanelExtender> <cc1:CollapsiblePanelExtender id="CollapsiblePanelExtender2" runat="server" __designer:wfdid="w85" CollapsedText="Show Meeting Agenda ..." ExpandedText="Hide Meeting Agenda ..." ExpandedSize="140" CollapsedSize="0" TargetControlID="pnlMeetingAgenda" CollapseControlID="imgBtnExpand2" ExpandControlID="imgBtnExpand2" ImageControlID="imgBtnExpand2" CollapsedImage="~/MODULES/OAS/Images/expand.jpg" ExpandedImage="~/MODULES/OAS/Images/collapse.jpg" TextLabelID="lblExpandStatus2" Collapsed="True"></cc1:CollapsiblePanelExtender> <cc1:CollapsiblePanelExtender id="CollapsiblePanelExtender3" runat="server" __designer:wfdid="w86" CollapsedText="Show Participant ..." ExpandedText="Hide Participants ..." ExpandedSize="200" CollapsedSize="0" TargetControlID="pnlParticipant" CollapseControlID="imgBtnExpand3" ExpandControlID="imgBtnExpand3" ImageControlID="imgBtnExpand3" CollapsedImage="~/MODULES/OAS/Images/expand.jpg" ExpandedImage="~/MODULES/OAS/Images/collapse.jpg" TextLabelID="lblExpandStatus3" Collapsed="True"></cc1:CollapsiblePanelExtender> 
</contenttemplate>
        </asp:UpdatePanel>
    </div>
    </div>
</asp:Content>

