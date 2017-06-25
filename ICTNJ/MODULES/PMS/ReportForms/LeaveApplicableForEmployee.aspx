<%@ Page Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master" AutoEventWireup="true" CodeFile="LeaveApplicableForEmployee.aspx.cs" Inherits="MODULES_PMS_ReportForms_LeaveApplicableForEmployee" Title="PMS | EmployeeWise Applicable Leave Report Form" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %> 

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
            <asp:Panel runat="Server" ID="programmaticPopupDragHandle" Style="cursor: move;background-color:#DDDDDD;border:solid 1px Gray;color:Black;text-align:center;">
                Status
            </asp:Panel>
                
            <asp:UpdatePanel id="UpdatePanel3" runat="server">
                <contenttemplate>
                    <br />
                    <asp:Label ID="lblStatusMessage" runat="server" Height="19px" Text="Label"></asp:Label>
                </contenttemplate>
            </asp:UpdatePanel>
                <asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click" Width="58px" />    
             <br />
        </asp:Panel>
    <br />
    <asp:Label ID="Label6" runat="server" Text="बिदाहरुको विवरण" SkinID="UnicodeHeadlbl"></asp:Label><br />
    <br />
    <div id="upper" style="width: 938px; cursor: hand; height: 27px">
        कर्मचारी खोज्नुहोस्
    </div>
<table width="950" id="tblWrapper">
        <tr>
            <td >
                <asp:Panel ID="Panel3" runat="server" Width="900px" Height="500px">
                    <table style="width: 100%">
                        <tr>
                            <td>
                                <asp:Label ID="Label30" runat="server" Font-Bold="False" SkinID="Unicodelbl" Text="संकेत नं"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtSymbolNo" runat="server" SkinID="Unicodetxt" 
                                    Width="130px"></asp:TextBox></td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Font-Bold="False" SkinID="Unicodelbl" Text="पहिलो नाम"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtFName" runat="server" MaxLength="35" SkinID="Unicodetxt" ToolTip="First Name"
                                    Width="130px"></asp:TextBox></td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Font-Bold="False" SkinID="Unicodelbl" Text="बिचको नाम"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtMName" runat="server" MaxLength="15" SkinID="Unicodetxt" Width="130px"></asp:TextBox></td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Font-Bold="False" Height="22px" SkinID="Unicodelbl"
                                    Text="थर"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtSurName" runat="server" MaxLength="35" SkinID="Unicodetxt" ToolTip="Surname"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="height: 28px">
                                <asp:Label ID="Label5" runat="server" Font-Bold="False" SkinID="Unicodelbl" Text="लिंग"></asp:Label></td>
                            <td style="height: 28px">
                                <asp:DropDownList ID="ddlGender" runat="server" SkinID="Unicodeddl" Width="135px">
                                    <asp:ListItem Value="SG">छान्नुहोस</asp:ListItem>
                                    <asp:ListItem Value="M">पुरूष</asp:ListItem>
                                    <asp:ListItem Value="F">महिला</asp:ListItem>
                                    <asp:ListItem Value="O">अन्य</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="height: 28px">
                                <asp:Label ID="Label4" runat="server" Font-Bold="False" SkinID="Unicodelbl" Text="जन्म मिति"></asp:Label></td>
                            <td style="height: 28px">
                                <asp:TextBox ID="txtDOB" runat="server" MaxLength="10" Width="130px"></asp:TextBox>&nbsp;
                            </td>
                            <td style="height: 28px">
                                <asp:Label ID="lblMaritalStatus" runat="server" Height="22px" SkinID="Unicodelbl"
                                    Text="बैबाहिक स्थिति" Width="114px"></asp:Label></td>
                            <td style="height: 28px">
                                <asp:DropDownList ID="ddlMarStatus" runat="server" SkinID="Unicodeddl" Width="135px">
                                    <asp:ListItem Value="SMS">छान्नुहोस</asp:ListItem>
                                    <asp:ListItem Value="S">अबिबाहित</asp:ListItem>
                                    <asp:ListItem Value="M">बिबाहित</asp:ListItem>
                                    <asp:ListItem Value="W">बिधवा/बिदुर</asp:ListItem>
                                    <asp:ListItem Value="D">छोडपत्र</asp:ListItem>
                                    <asp:ListItem Value="O">अन्य</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="height: 28px">
                                <asp:Label ID="lblOrganization" runat="server" SkinID="Unicodelbl" Text="कार्यालय"></asp:Label></td>
                            <td colspan="3" style="height: 28px">
                                <asp:DropDownList ID="ddlOrganization" runat="server" SkinID="Unicodeddl" Width="427px">
                                </asp:DropDownList></td>
                            <td style="height: 28px">
                                <asp:Label ID="lblDesignation" runat="server" SkinID="Unicodelbl" Text="पद"></asp:Label></td>
                            <td style="height: 28px">
                                <asp:DropDownList ID="ddlDesignation" runat="server" SkinID="Unicodeddl" Width="135px">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="height: 28px">
                            </td>
                            <td style="height: 28px">
                            </td>
                            <td style="height: 28px">
                            </td>
                            <td style="height: 28px">
                            </td>
                            <td style="height: 28px">
                            </td>
                            <td style="height: 28px">
                                <asp:Button ID="btnEmpSearch" runat="server" OnClick="btnEmpSearch_Click" Text="Search"
                                    Width="68px" SkinID="Normal" /><asp:Button ID="btnEmpSearchCancel" runat="server" OnClick="btnEmpSearchCancel_Click"
                                        Text="Cancel" Width="68px" SkinID="Normal" /></td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <hr />
                                &nbsp;<asp:UpdatePanel id="UpdatePanel1" runat="server">
                                    <contenttemplate>
<asp:Label id="lblSearch" runat="server" Font-Bold="True" __designer:wfdid="w10"></asp:Label> <BR /><asp:Panel id="Panel1" runat="server" Width="890px" Height="250px" ScrollBars="auto" __designer:wfdid="w11"><asp:GridView id="grdEmployee" runat="server" Width="890px" SkinID="Unicodegrd" OnRowCreated="grdEmployee_RowCreated" OnRowCommand="grdEmployee_RowCommand" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333" __designer:wfdid="w12">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="EMPID" HeaderText="EMPLOYEE ID"></asp:BoundField>
<asp:BoundField DataField="SYMBOLNO" HeaderText="संकेत नं"></asp:BoundField>
<asp:BoundField DataField="RDFULLNAME" HeaderText="पुरा नाम थर"></asp:BoundField>
<asp:BoundField DataField="RDGENDER" HeaderText="लिंग"></asp:BoundField>
<asp:BoundField DataField="DOB" HeaderText="जन्म मिति">
<ItemStyle Font-Names="Verdana"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="RDMARITALSTATUS" HeaderText="बैबाहिक सम्बन्ध"></asp:BoundField>
<asp:BoundField DataField="FATHERNAME" HeaderText="बाबुको नाम"></asp:BoundField>
<asp:BoundField DataField="GFATHERNAME" HeaderText="बबाजेको नाम"></asp:BoundField>
<asp:TemplateField><EditItemTemplate>
        <asp:LinkButton ID="Button1" runat="server" Text="रिपोर्ट हेर्नुहोस्" CommandArgument='<%# Bind("EMPID") %>' CommandName="Print" ></asp:LinkButton>
         
    
</EditItemTemplate>
<ItemTemplate>
        <asp:LinkButton ID="Button1" runat="server" Text="View Report" CommandArgument='<%# Bind("EMPID") %>' CommandName="Print" ></asp:LinkButton>
       
    
</ItemTemplate>
</asp:TemplateField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> </asp:Panel> 
</contenttemplate>
                                    <triggers>
<asp:PostBackTrigger ControlID="grdEmployee"></asp:PostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnEmpSearch" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" Mask="9999/99/99" MaskType="Date" runat="server" TargetControlID="txtDOB">
                                </ajaxToolkit:MaskedEditExtender>
                </asp:Panel>
                &nbsp;
                
            </td>
        </tr>
        </table>
</asp:Content>


