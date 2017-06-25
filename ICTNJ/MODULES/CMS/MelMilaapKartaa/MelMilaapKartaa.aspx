<%@ Page Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" AutoEventWireup="true" CodeFile="MelMilaapKartaa.aspx.cs" Inherits="MODULES_CMS_MelMilaapKartaa_MelMilaapKartaa" Title="CMS | Mel-Milaap Kartaa" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
<asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>

     <script language="javascript" type="text/javascript" src="../../COMMON/JS/Validation.js"></script>
    <script language="javascript" type="text/javascript" src="../../COMMON/JS/DateValidator.js"></script>
    <script language="javascript" type="text/javascript" src="../../COMMON/JS/EnglishDateValidator.js"></script>
  
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
            <asp:Label ID="lblStatus" runat="server" Text="Label"></asp:Label>&nbsp;</asp:Panel>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
        <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
            Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    <table>
        <tr>
            <td align="left" valign="top">
                <asp:Panel ID="Panel1" runat="server" Height="300px" ScrollBars="Auto" Width="250px">
                    <asp:ListBox ID="lstOrganization" runat="server" AutoPostBack="True" Height="300px"
                        Width="250px" SkinID="Unicodelst" OnSelectedIndexChanged="lstOrganization_SelectedIndexChanged"></asp:ListBox></asp:Panel>
            </td>
            <td align="left" style="width: 100px" valign="top">
                <table style="width: 600px">
                    <tr>
                        <td align="left" valign="top">
                            <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="मेलमिलाप कर्ता" Width="109px"></asp:Label></td>
                        <td align="left" valign="top">
                            <asp:TextBox ID="txtPerson_RQD" runat="server" Width="300px"></asp:TextBox></td>
                        <td align="left" style="width: 52px" valign="top">
                            <asp:Button ID="btnSearchPerson" runat="server" SkinID="Normal" Text="Search" OnClick="btnSearchPerson_Click" /></td>
                        <td align="left" style="width: 107px" valign="top">
                            <asp:Button ID="btnNewPerson" runat="server" SkinID="Normal" Text="New" OnClick="btnNewPerson_Click" /></td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="मिति"></asp:Label></td>
                        <td align="left" valign="top">
                            <asp:TextBox ID="txtFromDate_RQD" runat="server" SkinID="Unicodetxt" Width="100px"></asp:TextBox>
                <ajaxToolkit:MaskedEditExtender ID="mskFD" runat="server" AutoComplete="False" ClearMaskOnLostFocus="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtFromDate_RQD">
                </ajaxToolkit:MaskedEditExtender>
            </td>
                        <td align="left" colspan="2" valign="top">
                            <asp:HiddenField ID="hdnPersonID" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            <asp:Label ID="Label3" runat="server" SkinID="Unicodelbl" Text="पद"></asp:Label></td>
                        <td align="left" valign="top">
                            <asp:TextBox ID="txtPost" runat="server" SkinID="Unicodetxt"></asp:TextBox></td>
                        <td align="left" colspan="2" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            <asp:Label ID="Label4" runat="server" SkinID="Unicodelbl" Text="अनुभव"></asp:Label></td>
                        <td align="left" colspan="3" valign="top">
                            <asp:TextBox ID="txtExp" runat="server" SkinID="Unicodetxt" TextMode="MultiLine"
                                Width="450px" Height="50px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            <asp:Label ID="Label5" runat="server" SkinID="Unicodelbl" Text="सपथ न्यायधिश"></asp:Label></td>
                        <td align="left" colspan="3" valign="top">
                            <asp:DropDownList ID="ddlJudge" runat="server" DataTextField="JudgeName" DataValueField="JudgeId"
                                SkinID="Unicodeddl" Width="200px">
                            </asp:DropDownList>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                        </td>
                        <td align="right" colspan="3" valign="top">
                            <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" SkinID="Add" Text="+" /></td>
                    </tr>
                    <tr>
                        <td align="left" colspan="4" valign="top">
                            &nbsp;<asp:Panel ID="Panel2" runat="server" Height="200px" ScrollBars="Auto" Width="590px">
                                <asp:GridView ID="grdMMK" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    ForeColor="#333333" GridLines="None" Width="580px" SkinID="Unicodegrd" OnRowDeleting="grdMMK_RowDeleting" OnSelectedIndexChanged="grdMMK_SelectedIndexChanged" OnRowDataBound="grdMMK_RowDataBound">
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="PID" HeaderText="PID" />
                                        <asp:BoundField DataField="OrgID" HeaderText="OrgID" />
                                        <asp:BoundField DataField="FullName" HeaderText="नाम" />
                                        <asp:BoundField DataField="FromDate" HeaderText="मिति" />
                                        <asp:BoundField DataField="Post" HeaderText="पद" />
                                        <asp:BoundField DataField="Experience" HeaderText="ञनुभव" />
                                        <asp:BoundField HeaderText="Action" DataField="Action" />
                                        <asp:BoundField HeaderText="Sapath Judges" DataField="OathJudges" />
                                        
                                        <asp:CommandField ShowSelectButton="True" />
                                        <asp:CommandField ShowDeleteButton="True" />
                                    </Columns>
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <EditRowStyle BackColor="#999999" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                </asp:GridView>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="4" valign="top">
                            <asp:Button ID="btnSubmit" runat="server" SkinID="Normal" Text="Submit" OnClick="btnSubmit_Click" />
                            <asp:Button ID="btnCancel" runat="server" SkinID="Cancel" Text="Cancel" OnClick="btnCancel_Click" /></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <br />
   <asp:Button ID="hiddenTargetControlForPersonModalPopup" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="programmaticPersonModalPopup" runat="server"
        BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior1"
        DropShadow="True" PopupControlID="programmaticPersonPopup" PopupDragHandleControlID="programmaticPersonPopupDragHandle"
        RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForPersonModalPopup">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="programmaticPersonPopup" runat="server" CssClass="modalPopupPerson"
        Height="400px" Style="display: none;padding: 10px">
        <asp:Panel ID="programmaticPersonPopupDragHandle" runat="Server" Style="cursor: move;
            background-color: #DDDDDD; border: solid 1px Gray; color: Black; text-align: center;">
            मान्छे &nbsp;खोज्नुहोस</asp:Panel>
        <contenttemplate></contenttemplate>
        <asp:UpdatePanel id="UpdatePanelPersonSearch" runat="server">
            <contenttemplate>
<BR /><TABLE style="WIDTH: 700px; TEXT-ALIGN: left"><TBODY><TR><TD style="WIDTH: 120px" vAlign=top><asp:Label id="Label14" runat="server" Width="75px" Text="पहिलो नाम" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 140px" vAlign=top><asp:TextBox id="txtSFirstName" runat="server" Width="100px" SkinID="Unicodetxt"></asp:TextBox></TD><TD style="WIDTH: 85px" vAlign=top><asp:Label id="Label16" runat="server" Width="80px" Text="बिचको नाम" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 140px" vAlign=top><asp:TextBox id="txtSMName" runat="server" Width="100px" SkinID="Unicodetxt"></asp:TextBox></TD><TD style="WIDTH: 115px" vAlign=top><asp:Label id="Label17" runat="server" Text="थर" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:TextBox id="txtSLastName" runat="server" Width="100px" SkinID="Unicodetxt"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 120px" vAlign=top><asp:Label id="Label78" runat="server" Text="लिंग" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 140px" vAlign=top><asp:DropDownList id="ddlSGender" runat="server" Width="105px" SkinID="Unicodeddl"><asp:ListItem Value="SG">छान्नुहोस</asp:ListItem>
<asp:ListItem Value="M">पुरुष</asp:ListItem>
<asp:ListItem Value="F">महिला</asp:ListItem>
<asp:ListItem Value="O">अन्य</asp:ListItem>
</asp:DropDownList></TD><TD style="WIDTH: 85px" vAlign=top><asp:Label id="Label20" runat="server" Width="75px" Text="जन्म मिति" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 140px" vAlign=top><asp:TextBox id="txtSDOB_DT" runat="server" Width="100px" SkinID="Unicodetxt"></asp:TextBox></TD><TD style="WIDTH: 115px" vAlign=top><asp:Label id="Label25" runat="server" Width="110px" Text="बैबाहिक सम्बन्ध" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:DropDownList id="ddlSMarStatus" runat="server" Width="105px" SkinID="Unicodeddl"><asp:ListItem Value="SMS">छान्नुहोस</asp:ListItem>
<asp:ListItem Value="S">अबिबाहित</asp:ListItem>
<asp:ListItem Value="M">बिबाहित</asp:ListItem>
<asp:ListItem Value="W">बिधवा/बिदुर</asp:ListItem>
<asp:ListItem Value="D">छोडपत्र</asp:ListItem>
<asp:ListItem Value="O">अन्य</asp:ListItem>
</asp:DropDownList></TD></TR><TR><TD style="WIDTH: 120px" vAlign=top><asp:Label id="Label77" runat="server" Width="120px" Text="घर भएको जिल्ला" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 140px" vAlign=top><asp:DropDownList id="ddlSHomeDistrict" runat="server" Width="105px" SkinID="Unicodeddl"></asp:DropDownList></TD><TD style="WIDTH: 85px" vAlign=top></TD><TD style="WIDTH: 140px" vAlign=top></TD><TD style="WIDTH: 115px" vAlign=top></TD><TD vAlign=top></TD></TR><TR><TD vAlign=top colSpan=2><asp:Button id="btnPersonSearch" onclick="btnPersonSearch_Click" runat="server" Text="Search"></asp:Button> <asp:Button id="btnCancelPersonSearch" onclick="btnCancelPersonSearch_Click" runat="server" Text="Cancel"></asp:Button> </TD><TD style="WIDTH: 85px" vAlign=top></TD><TD style="WIDTH: 140px" vAlign=top></TD><TD vAlign=top align=right colSpan=2>&nbsp;</TD></TR><TR><TD vAlign=top colSpan=6><asp:Panel id="pnlPersonSearch" runat="server" Width="680" Height="250px" ScrollBars="Auto"><asp:GridView id="grdPersonSearch" runat="server" Width="650px" SkinID="Unicodegrd" ForeColor="#333333" AutoGenerateColumns="False" CellPadding="4" GridLines="None" OnRowDataBound="grdPersonSearch_RowDataBound" OnSelectedIndexChanged="grdPersonSearch_SelectedIndexChanged">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField HeaderText="क्र.सं.">
<ItemStyle Width="25px" Font-Names="PCS NEPALI"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="PERSONID" HeaderText="आईडी"></asp:BoundField>
<asp:BoundField DataField="RDFULLNAME" HeaderText="पुरा नाम थर"></asp:BoundField>
<asp:BoundField DataField="RDGENDER" HeaderText="लिंग"></asp:BoundField>
<asp:BoundField DataField="DOB" HeaderText="जन्म मिति"></asp:BoundField>
<asp:BoundField DataField="RDMARITALSTATUS" HeaderText="बैबाहिक सम्बन्ध"></asp:BoundField>
<asp:BoundField DataField="BIRTHDISTRICT" HeaderText="घर भएको जिल्ला"></asp:BoundField>
<asp:CommandField ShowSelectButton="True"></asp:CommandField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView></asp:Panel></TD></TR></TBODY></TABLE> 
</contenttemplate>
        </asp:UpdatePanel>
        <asp:Button ID="btnOKPersonSearch" runat="server" OnClick="OkPersonButton_Click" Text="OK"
            Width="58px" />
        </asp:Panel>
    <br />
    <br />
    <br />
</asp:Content>

