<%@ Page AutoEventWireup="true" CodeFile="Religion.aspx.cs" Inherits="MODULES_Common_LookUp_Religion" Language="C#" MasterPageFile="~/MODULES/COMMON/MasterPage.master" Title="Religion" %>
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
                    <div style="padding: 10px; text-align: center">

            <asp:Panel runat="Server" ID="programmaticPopupDragHandle" Style="cursor: move;background-color:#DDDDDD;border:solid 1px Gray;color:Black;text-align:center;">
                Save Status
            </asp:Panel>
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label><br />
<asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click" Width="58px" />           <br />
</div>
        </asp:Panel>
    <br />
    <asp:Label ID="Label3" runat="server" SkinID="UnicodeHeadlbl" Text="धर्म"></asp:Label>
    &nbsp;<br />
    <br />
    <table style="width: 94%; height: 456px;">
        <tr style="width:100%">
            <td align="left" valign="top" style="height: 500px">
                            <asp:UpdatePanel id="uPanelFields" runat="server">
                                <contenttemplate>
<TABLE style="WIDTH: 468px"><TBODY><TR><TD vAlign=top align=left><asp:Label id="Label1" runat="server" SkinID="Unicodelbl" Text="धर्मको नाम"></asp:Label> </TD><TD><asp:TextBox id="txtRelgNepName_rqd" runat="server" Width="182px" SkinID="Unicodetxt" ToolTip="धर्मको नाम" MaxLength="15"></asp:TextBox></TD></TR><TR><TD style="HEIGHT: 26px" vAlign=top align=left><asp:Label id="Label2" runat="server" Width="137px" SkinID="Unicodelbl" Text="धर्मको अंग्रेजी नाम"></asp:Label> </TD><TD style="HEIGHT: 26px"><asp:TextBox id="txtRelgEngName" runat="server" Width="182px" SkinID="Unicodetxt" MaxLength="15"></asp:TextBox></TD></TR></TBODY></TABLE>&nbsp; 
</contenttemplate>
                            </asp:UpdatePanel>
                <table style="width: 100%">
                    <tr>
                        <td align="left">
<asp:Button id="btnSave" runat="server" Text="Save" Width="59px" OnClick="btnSave_Click" OnClientClick="javascript:return validate();" SkinID="Normal"></asp:Button> <asp:Button id="btnCancel" runat="server" Text="Cancel" SkinID="Cancel"></asp:Button></td>
                    </tr>
                </table>
                <br />
                <asp:UpdatePanel ID="uPanelRelLists" runat="server">
                    <ContentTemplate>
<asp:Panel id="Panel2" runat="server" Width="464px" Height="236px" ScrollBars="Auto"><asp:GridView id="grdReligions" runat="server" Width="444px" Height="90px" SkinID="Unicodegrd" ForeColor="#333333" AutoGenerateColumns="False" GridLines="None" CellPadding="4" OnRowDataBound="grdReligions_RowDataBound" OnSelectedIndexChanged="grdReligions_SelectedIndexChanged">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="ReligionID" HeaderText="Religion ID">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ReligionNepName" HeaderText="नेपाली नाम">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ReligionEngName" HeaderText="अङर्गेजी नाम">
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
</asp:GridView> </asp:Panel> 
</ContentTemplate>
                </asp:UpdatePanel>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>

