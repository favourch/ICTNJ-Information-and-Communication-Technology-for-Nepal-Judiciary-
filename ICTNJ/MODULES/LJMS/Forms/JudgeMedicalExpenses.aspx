<%@ Page Language="C#" MasterPageFile="~/MODULES/LJMS/LJMSMasterPage.master" AutoEventWireup="true" CodeFile="JudgeMedicalExpenses.aspx.cs" Inherits="MODULES_LJMS_Forms_MedicalExpenses" Title="LJMS | Judge Medical Expenses" %>
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
<script language="javascript" type="text/javascript" src="../../COMMON/JS/DateValidator.js" ></script>
<script language="javascript" type="text/javascript" src="../../COMMON/JS/EnglishDateValidator.js" ></script>
<script language="javascript" type="text/javascript" src="../../COMMON/JS/Number.js" ></script>    
    <asp:ScriptManager id="ScriptManager1" runat="server" />

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
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label><br />
<asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click" Width="58px" />
<br />
        </asp:Panel>
<br />

        <asp:Panel ID="pnlCol" runat="server" CssClass="collapsePanelHeader" Height="25px" Width="900px">
            न्यायाधिश खोज्नुहोस
            <asp:ImageButton ID="imgCol" runat="server" ImageUrl="~/MODULES/COMMON/Images/expand.jpg" Height="25px" ImageAlign="Right" Visible="False" />
        </asp:Panel>
                
        <ajaxToolkit:CollapsiblePanelExtender ID="colEmployee" runat="server" CollapseControlID="pnlCol" Collapsed="True" CollapsedImage="../../COMMON/Images/expand_blue.jpg"
            ExpandControlID="pnlCol" ImageControlID="imgCol" SkinID="CollapsiblePanelDemo" SuppressPostBack="True" TargetControlID="pnlEmployeeSearch" ExpandedImage="../../COMMON/Images/collapse_blue.jpg">
        </ajaxToolkit:CollapsiblePanelExtender>
        <asp:Panel ID="pnlEmployeeSearch" runat="server" Width="1000px" CssClass="collapsePanel">
            <table style="width: 1000px">
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Height="22px" SkinID="Unicodelbl" Text="संकेत नं"
                            Width="110px"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtSearchSymbolNo" runat="server" MaxLength="15" SkinID="Unicodetxt" ToolTip="First Name"
                            Width="130px"></asp:TextBox></td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td style="width: 163px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" Height="22px" SkinID="Unicodelbl" Text="पहिलो नाम"
                            Width="92px"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtFirstName" runat="server" MaxLength="35" SkinID="Unicodetxt" ToolTip="First Name"
                            Width="130px"></asp:TextBox></td>
                    <td>
                        <asp:Label ID="Label8" runat="server" Height="22px" SkinID="Unicodelbl" Text="बिचको नाम"
                            Width="92px"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtMidName" runat="server" MaxLength="15" SkinID="Unicodetxt" Width="130px"></asp:TextBox></td>
                    <td>
                        <asp:Label ID="Label9" runat="server" Height="22px" SkinID="Unicodelbl" Text="थर"
                            Width="92px"></asp:Label></td>
                    <td style="width: 163px">
                        <asp:TextBox ID="txtLastName" runat="server" MaxLength="35" SkinID="Unicodetxt" ToolTip="Surname"
                            Width="130px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label10" runat="server" Height="22px" SkinID="Unicodelbl" Text="लिंग"
                            Width="92px"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddlSex" runat="server" SkinID="Unicodeddl" Width="135px">
                            <asp:ListItem Value="SG">छान्नुहोस</asp:ListItem>
                            <asp:ListItem Value="M">पुरुष</asp:ListItem>
                            <asp:ListItem Value="F">महिला</asp:ListItem>
                            <asp:ListItem Value="O">अन्य</asp:ListItem>
                        </asp:DropDownList></td>
                    <td>
                        <asp:Label ID="Label11" runat="server" Height="22px" SkinID="Unicodelbl" Text="जन्म मिति"
                            Width="110px"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtBirthDate" runat="server" MaxLength="10" SkinID="Unicodetxt" Width="130px"></asp:TextBox></td>
                    <td>
                        <asp:Label ID="Label12" runat="server" Height="22px" SkinID="Unicodelbl" Text="बैबाहिक सम्बन्ध"
                            Width="114px"></asp:Label></td>
                    <td style="width: 163px">
                        <asp:DropDownList ID="ddlMarried" runat="server" SkinID="Unicodeddl" Width="135px">
                            <asp:ListItem Value="SMS">छान्नुहोस</asp:ListItem>
                            <asp:ListItem Value="S">अबिबाहित</asp:ListItem>
                            <asp:ListItem Value="M">बिबाहित</asp:ListItem>
                            <asp:ListItem Value="W">बिधवा/बिदुर</asp:ListItem>
                            <asp:ListItem Value="D">छोडपत्र</asp:ListItem>
                            <asp:ListItem Value="O">अन्य</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="height: 24px">
                        <asp:Label ID="Label13" runat="server" SkinID="Unicodelbl" Text="कार्यालय"></asp:Label></td>
                    <td colspan="3" style="height: 24px">
                        <asp:DropDownList ID="ddlOrganization" runat="server" SkinID="Unicodeddl" Width="500px">
                        </asp:DropDownList></td>
                    <td style="height: 24px">
                        <asp:Label ID="lblDesignation" runat="server" SkinID="Unicodelbl" Text="पद"></asp:Label></td>
                    <td style="width: 163px; height: 24px;">
                        <asp:DropDownList ID="ddlDesignation" runat="server" SkinID="Unicodeddl" Width="135px">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td align="left" colspan="6">
                        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" SkinID="Normal"
                            Text="Search" /><asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click"
                                SkinID="Cancel" Text="Cancel" /></td>
                </tr>
                <tr>
                    <td colspan="6" style="height: 306px">
                        <hr />
                        <asp:Label ID="lblSearch" runat="server" Font-Bold="True"></asp:Label><br />
                        <asp:Panel ID="Panel2" runat="server" Height="250px" Width="100%">
                            <asp:GridView ID="grdEmployee" runat="server" AutoGenerateColumns="False" CellPadding="0"
                                ForeColor="#333333" OnRowDataBound="grdEmployee_RowDataBound" OnSelectedIndexChanged="grdEmployee_SelectedIndexChanged"
                                SkinID="Unicodegrd" Width="900px">
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="EMPID" HeaderText="आई डी" />
                                    <asp:BoundField DataField="SYMBOLNO" HeaderText="संकेत नं." />
                                    <asp:BoundField DataField="FIRSTNAME" HeaderText="पहिलो नाम" />
                                    <asp:BoundField DataField="MIDDLENAME" HeaderText="बिचको नाम" />
                                    <asp:BoundField DataField="SURNAME" HeaderText="थर" />
                                    <asp:BoundField DataField="RDFULLNAME" HeaderText="पुरा नाम थर" />
                                    <asp:BoundField DataField="RDGENDER" HeaderText="लिंग" />
                                    <asp:BoundField DataField="DOB" HeaderText="जन्म मिति">
                                        <ItemStyle Font-Names="Verdana" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RDMARITALSTATUS" HeaderText="बैबाहिक सम्बन्ध" />
                                    <asp:BoundField DataField="FATHERNAME" HeaderText="पिताको नाम" />
                                    <asp:BoundField DataField="GFATHERNAME" HeaderText="बाजेको नाम" />
                                    <asp:BoundField DataField="DesName" HeaderText="पद" />
                                    <asp:CommandField ShowSelectButton="True">
                                        <ItemStyle Font-Names="Verdana" />
                                    </asp:CommandField>
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
            </table>
        </asp:Panel>
    
    <table style="width: 1000px">
        <tr>
            <td colspan="4" valign="top">
                <hr />
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 180px" valign="top">
                <asp:Label ID="Label5" runat="server" SkinID="Unicodelbl" Text="पुरा नाम थर"
                    Width="170px"></asp:Label></td>
            <td style="width: 270px" valign="top">
                <asp:TextBox ID="txtEmpName_Rqd" runat="server" SkinID="Unicodetxt" Width="250px" ReadOnly="True" ToolTip="कर्मचारीको पुरा नाम थर"></asp:TextBox></td>
            <td style="width: 80px" valign="top">
                <asp:Label ID="Label6" runat="server" SkinID="Unicodelbl" Text="संकेत नं" Width="60px"></asp:Label></td>
            <td valign="top">
                <asp:TextBox ID="txtSymbolNo" runat="server" SkinID="Unicodetxt" ToolTip="संकेत नं"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 180px" valign="top">
                            <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="विवरण"></asp:Label></td>
            <td colspan="3" valign="top">
                            <asp:TextBox ID="txtParticulars_Rqd" runat="server" ToolTip="विबरण" Width="250px" MaxLength="100" SkinID="Unicodetxt"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 180px;" valign="top">
                            <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="लिएको मिति" Width="95px"></asp:Label></td>
            <td style="width: 270px;" valign="top">
                            <asp:TextBox ID="txtDateTaken_RDT" runat="server" ToolTip="लिएको मिति" SkinID="Unicodetxt" Width="100px"></asp:TextBox>
                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AutoComplete="False"
                    Mask="9999/99/99" MaskType="Date" TargetControlID="txtDateTaken_RDT">
                </ajaxToolkit:MaskedEditExtender>
            </td>
            <td style="width: 80px;" valign="top">
                            <asp:Label ID="Label3" runat="server" SkinID="Unicodelbl" Text="रकम"></asp:Label></td>
            <td valign="top">
                            <asp:TextBox ID="txtAmountTaken_Rqd" runat="server" ToolTip="रकम" MaxLength="10" SkinID="Unicodetxt" Width="100px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 180px" valign="top">
                            <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" OnClientClick="javascript:return validate(1);"
                                Text="Submit" Width="60px" SkinID="Normal" /></td>
            <td style="width: 270px">
            </td>
            <td style="width: 80px">
            </td>
            <td>
                <asp:TextBox ID="txtEmpID" runat="server" Visible="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="4">
                <hr />
                <table style="width: 800px">
                    <tr>
                        <td colspan="3" style="height: 21px">
                            <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Auto" Width="100%">
                                <asp:GridView ID="grdMedicalExp" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="grdMedicalExp_SelectedIndexChanged"
                                    SkinID="Unicodegrd" Width="785px" OnRowDataBound="grdMedicalExp_RowDataBound">
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <Columns>
                                        <asp:BoundField>
                                            <ItemStyle Width="20px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EMPID" HeaderText="EmpID" />
                                        <asp:BoundField DataField="SEQNO" HeaderText="SeqNo" />
                                        <asp:BoundField DataField="Particulars" HeaderText="विवरण" >
                                            <ItemStyle Width="280px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DATETAKEN" HeaderText="लिएको मिति" >
                                            <ItemStyle Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="AMOUNTTAKEN" HeaderText="रकम" >
                                            <ItemStyle Width="100px" />
                                        </asp:BoundField>
                                        <asp:CommandField ShowSelectButton="True" >
                                            <ItemStyle Width="100px" />
                                        </asp:CommandField>
                                        <asp:CommandField ShowDeleteButton="True" >
                                            <ItemStyle Width="100px" />
                                        </asp:CommandField>
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
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

