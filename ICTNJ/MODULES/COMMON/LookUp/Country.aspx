<%@ Page AutoEventWireup="true" CodeFile="Country.aspx.cs" Inherits="MODULES_Common_LookUp_Country" Language="C#" MasterPageFile="~/MODULES/COMMON/MasterPage.master" Title="PMS | Country" %>
<%@ Register 
    Assembly="AjaxControlToolkit" 
    Namespace="AjaxControlToolkit" 
    TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript" src="../../COMMON/JS/Validation.js" ></script>
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
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label><br />
<asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click" Width="58px" />           <br />
        </asp:Panel>
    <br />
    <asp:Label ID="Label4" runat="server" SkinID="UnicodeHeadlbl" Text="देश"></asp:Label><br />
    <br />
<table style="width: 94%; height: 456px;">
        <tr style="width:100%">
            <td align="left" valign="top" style="height: 508px">
                            <asp:UpdatePanel id="uPanelFields" runat="server">
                                <contenttemplate>
<TABLE style="WIDTH: 468px" cellSpacing=5><TBODY><TR><TD vAlign=top align=left><asp:Label id="Label1" runat="server" SkinID="Unicodelbl" Text="देशको नाम"></asp:Label> </TD><TD><asp:TextBox id="txtCountryNepName_rqd" runat="server" Width="182px" SkinID="Unicodetxt" MaxLength="50" ToolTip="देशको नाम"></asp:TextBox></TD></TR><TR><TD style="HEIGHT: 26px" vAlign=top align=left><asp:Label id="Label2" runat="server" Width="130px" SkinID="Unicodelbl" Text="देशको अंग्रजी नाम"></asp:Label> </TD><TD style="HEIGHT: 26px"><asp:TextBox id="txtCountryEngName" runat="server" Width="182px" SkinID="Unicodetxt" MaxLength="50"></asp:TextBox></TD></TR><TR><TD style="HEIGHT: 26px" vAlign=top align=left><asp:Label id="Label3" runat="server" SkinID="Unicodelbl" Text="देशको कोड"></asp:Label></TD><TD style="HEIGHT: 26px"><asp:TextBox id="txtCountryCode" runat="server" Width="51px" SkinID="Unicodetxt" MaxLength="5"></asp:TextBox></TD></TR></TBODY></TABLE>&nbsp; &nbsp; 
</contenttemplate>
                            </asp:UpdatePanel>
                <table style="width: 100%">
                    <tr>
                        <td align="left">
<asp:Button id="btnSave" runat="server" Text="Save" Width="59px" OnClick="btnSave_Click" OnClientClick="javascript:return validate();" SkinID="Normal"></asp:Button> <asp:Button id="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" SkinID="Cancel"></asp:Button></td>
                    </tr>
                </table>
                <br />
                <asp:UpdatePanel ID="uPanelCountryLists" runat="server">
                    <ContentTemplate>
<asp:Panel id="Panel2" runat="server" Width="733px" Height="236px" ScrollBars="Auto"><asp:GridView id="grdCountries" runat="server" Width="671px" Height="90px" SkinID="Unicodegrd" ForeColor="#333333" AutoGenerateColumns="False" GridLines="None" CellPadding="4" OnRowDataBound="grdCountries_RowDataBound" OnSelectedIndexChanged="grdCountries_SelectedIndexChanged">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="CountryID" HeaderText="Country ID">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="CountryNepName" HeaderText="नेपाली नाम">
<ItemStyle HorizontalAlign="Left" Font-Names="PCS NEPAL"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="CountryEngName" HeaderText="अङर्गेजी नाम">
<ItemStyle HorizontalAlign="Left" Font-Names="Verdana"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="CountryCode" HeaderText="कोड">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:CommandField SelectText="छान्नुहोस" ShowSelectButton="True">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:CommandField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" HorizontalAlign="Left" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> <BR /></asp:Panel> 
</ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>

