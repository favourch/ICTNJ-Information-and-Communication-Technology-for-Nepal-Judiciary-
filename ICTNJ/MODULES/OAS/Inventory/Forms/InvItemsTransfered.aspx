<%@ Page AutoEventWireup="true" CodeFile="InvItemsTransfered.aspx.cs" Inherits="MODULES_OAS_Inventory_Forms_InvItemsTransfered"
    Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" Title="Untitled Page" %>

<%@ Register Assembly="Winthusiasm.HtmlEditor" Namespace="Winthusiasm.HtmlEditor"
    TagPrefix="cc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<%--    <asp:UpdatePanel runat="server" id="up1">
        <contenttemplate>--%>
    <asp:Button Style="display: none" ID="hiddenTargetControlForModalPopup" runat="server">
    </asp:Button>
    <ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" TargetControlID="hiddenTargetControlForModalPopup"
        RepositionMode="RepositionOnWindowScroll" PopupDragHandleControlID="programmaticPopupDragHandle"
        PopupControlID="programmaticPopup" DropShadow="True" BehaviorID="programmaticModalPopupBehavior"
        BackgroundCssClass="modalBackground">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel Style="padding-right: 10px; display: none; padding-left: 10px; padding-bottom: 10px;
        width: 350px; padding-top: 10px" ID="programmaticPopup" runat="server" CssClass="modalPopup">
        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD;
            border: solid 1px Gray; color: Black; text-align: center;">
            <asp:Label ID="lblStatus" runat="server" SkinID="Unicodelbl" Text="Status"></asp:Label></asp:Panel>
        <asp:Label ID="lblStatusMessage" runat="server" SkinID="Unicodelbl" Text="Label"></asp:Label><br />
        <asp:Button ID="OkButton" runat="server" Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    &nbsp;
    <br />
    <table width="900">
        <tbody>
            <tr>
                <td style="width: 75px; height: 21px" valign="top">
                    <asp:Label ID="Label12" runat="server" Width="61px" Text="समुह" SkinID="Unicodelbl"
                        ToolTip="समुह"></asp:Label></td>
                <td style="height: 21px" valign="top">
                    <asp:DropDownList ID="ddlCategory" runat="server" Width="230px" SkinID="Unicodeddl"
                        AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                    </asp:DropDownList></td>
                <td style="height: 21px; width: 80px;" valign="top">
                    <asp:Label ID="Label13" runat="server" Width="71px" Text="उप-समूह" SkinID="Unicodelbl"
                        ToolTip="उप-समूह"></asp:Label></td>
                <td style="height: 21px" valign="top">
                    <asp:DropDownList ID="ddlSubCategory" runat="server" Width="230px" SkinID="Unicodeddl"
                        AutoPostBack="True" OnSelectedIndexChanged="ddlSubCategory_SelectedIndexChanged">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 75px; height: 21px" valign="top">
                    <asp:Label ID="Label1" runat="server" Width="60px" Text="समान" SkinID="Unicodelbl"
                        ToolTip="समान"></asp:Label></td>
                <td style="height: 21px" valign="top">
                    <asp:DropDownList ID="ddlItemsKNJ" runat="server" Width="230px" SkinID="Unicodeddl"
                        AutoPostBack="True" OnSelectedIndexChanged="ddlItemsKNJ_SelectedIndexChanged">
                    </asp:DropDownList></td>
                <td style="height: 21px; width: 80px;" valign="top">
                    <asp:Label ID="lblQuantity" runat="server" Width="70px" Text="परिमाण" SkinID="Unicodelbl"></asp:Label></td>
                <td style="height: 21px" valign="top">
                    <asp:TextBox ID="txtQuantiy" runat="server" Width="88px" SkinID="Unicodetxt" AutoPostBack="true"
                        OnTextChanged="txtQuantiy_TextChanged"></asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                        TargetControlID="txtQuantiy" FilterType="Numbers">
                    </ajaxToolkit:FilteredTextBoxExtender>
                </td>
            </tr>
            <tr>
                <td style="height: 21px" valign="top" colspan="4">
                    <asp:Panel ID="Panel1" runat="server" Width="950px" Height="150px" ScrollBars="Both">
                        <hr />
                        <asp:GridView ID="grdKNJItems" runat="server" Width="940px" SkinID="Unicodegrd" OnSelectedIndexChanged="grdItemsTrans_SelectedIndexChanged"
                            GridLines="None" ForeColor="#333333" CellPadding="0" AutoGenerateColumns="False"
                            EmptyDataText="रेकर्ड छैन" Height="83px" OnRowCreated="grdKNJItems_RowCreated">
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkItems" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="OrgID" HeaderText="कार्यलय आईडि">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="ItemsCategoryID" HeaderText="समुह आईडि">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="ItemsSubCategoryID" HeaderText="उप-समुह आईडि">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="ItemsID" HeaderText="समानको आईडि">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="ItemsTypeID" HeaderText="समानको प्रकार आईडि">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="ItemsName" HeaderText="समानको नाम">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="ItemsAttributes" HeaderText="Items Attributes">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="ItemsTypeName" HeaderText="समानको प्रकार नाम">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="SeqNo" HeaderText="सिक्वेन्स न.">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                            </Columns>
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>
                            <PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
                            <HeaderStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White">
                            </HeaderStyle>
                            <EditRowStyle BackColor="#999999"></EditRowStyle>
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                        </asp:GridView>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td style="width: 75px; height: 19px" valign="top">
                </td>
                <td style="height: 19px" valign="top" colspan="3">
                    <asp:Button ID="btnAdd" OnClick="btnAdd_Click" runat="server" Width="54px" Text="Add"
                        SkinID="Normal" Height="25px"></asp:Button></td>
            </tr>
            <tr>
                <td style="height: 21px" valign="top" colspan="4">
                    <hr />
                    <asp:Panel ID="Panel3" runat="server" Width="1000px" Height="100px" ScrollBars="Both">
                        <asp:GridView ID="grdItemsTrans" runat="server" AutoGenerateColumns="False" CellPadding="0"
                            ForeColor="#333333" GridLines="None" SkinID="Unicodegrd" Width="950px" OnSelectedIndexChanged="grdItemsTrans_SelectedIndexChanged"
                            OnRowCreated="grdItemsTrans_RowCreated">
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <Columns>
                                <asp:BoundField DataField="OrgID" HeaderText="कार्यलय आईडि">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ItemsCategoryID" HeaderText="समुह आईडि">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ItemsCategoryName" HeaderText="समुहको नाम">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ItemsSubCategoryID" HeaderText="उप-समुह आईडि">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ItemsSubCategoryName" HeaderText="उप-समुहको नाम">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ItemsID" HeaderText="समानको आईडि">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ItemsName" HeaderText="समानको नाम">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ItemsTypeID" HeaderText="समानको प्रकार आईडि">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ItemsTypeName" HeaderText="समानको प्रकार नाम">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Quantity" HeaderText="परिमाण">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Action" HeaderText="Action">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:CommandField ShowSelectButton="True" />
                            </Columns>
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td valign="top" style="width: 75px">
                    <asp:Label ID="Label3" runat="server" Width="121px" Text="हस्तान्तरण मिति" SkinID="Unicodelbl"></asp:Label></td>
                <td valign="top">
                    <asp:TextBox ID="txtTransferedDate" runat="server" Width="90px" SkinID="Unicodetxt"></asp:TextBox><ajaxToolkit:MaskedEditExtender
                        ID="MaskedEditExtender1" runat="server" TargetControlID="txtTransferedDate" MaskType="Date"
                        Mask="9999/99/99" AutoComplete="False">
                    </ajaxToolkit:MaskedEditExtender>
                </td>
                <td valign="top" style="width: 80px">
                    <asp:Label ID="Label16" runat="server" Width="115px" Text="निर्णय गर्ने मिति" SkinID="Unicodelbl"></asp:Label></td>
                <td valign="top">
                    <asp:TextBox ID="txtDecisionDate" runat="server" Width="90px" SkinID="Unicodetxt"></asp:TextBox>
                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtDecisionDate"
                        MaskType="Date" Mask="9999/99/99" AutoComplete="False">
                    </ajaxToolkit:MaskedEditExtender>
                </td>
            </tr>
            <tr>
                <td valign="top" style="width: 75px">
                    <asp:Label ID="Label2" runat="server" Width="173px" Text="हस्तान्तरण गर्ने कार्यालय"
                        SkinID="Unicodelbl"></asp:Label></td>
                <td valign="top">
                    <asp:DropDownList ID="ddlTransfdOrg" runat="server" Width="230px" OnSelectedIndexChanged="ddlTransfdOrg_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList></td>
                <td valign="top" style="width: 80px">
                    <asp:Label ID="Label14" runat="server" Text="हस्तान्तरण गर्ने शाखा" SkinID="Unicodelbl" Width="150px"></asp:Label></td>
                <td valign="top">
                    <asp:DropDownList ID="ddlTransOrgUnit" runat="server" Width="230px" SkinID="Unicodeddl" AutoPostBack="True" OnSelectedIndexChanged="ddlTransOrgUnit_SelectedIndexChanged">
                    </asp:DropDownList>
                    </td>
            </tr>
            <tr>
                <td style="width: 75px" valign="top">
                    <asp:Label ID="Label4" runat="server" Width="153px" Text="हस्तान्तरण गर्ने व्यक्ति"
                        SkinID="Unicodelbl"></asp:Label></td>
                <td valign="top">
                    <asp:TextBox ID="txtTransferedEmp" runat="server" ReadOnly="True" SkinID="Unicodetxt"
                        Width="230px"></asp:TextBox></td>
                <td style="width: 80px" valign="top">
                    <asp:Button ID="btnOrgUnitEmpSearch" runat="server" SkinID="Search" Text="खोज्नुहोस्" OnClick="btnOrgUnitEmpSearch_Click" /></td>
                <td valign="top">
                    &nbsp;<asp:Button ID="btnEmployeeSearch" OnClientClick="SetEmp()" runat="server"  Text="खोज्नुहोस्" OnClick="btnEmployeeSearch_Click" SkinID="Search" Visible="False">
                    </asp:Button></td>
            </tr>
            <tr>
                <td colspan="4" valign="top">
                    <asp:Panel ID="Panel6" runat="server" Height="150px" ScrollBars="Both" Width="850px">
                        <table>
                            <tr>
                                <td style="width: 100px">
                                    <asp:Label ID="lblEmpSearch" runat="server" Font-Bold="True"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                    <asp:GridView ID="grdOrgUnitEmp" runat="server" AutoGenerateColumns="False" CellPadding="0"
                                        ForeColor="#333333" OnRowDataBound="grdEmployee_RowDataBound" OnSelectedIndexChanged="grdOrgUnitEmp_SelectedIndexChanged"
                                        SkinID="Unicodegrd" Width="848px">
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <Columns>
                                            <asp:BoundField DataField="EmpID" HeaderText="आई डी" />
                                            <asp:BoundField DataField="FullName" HeaderText="पुरा नाम थर" />
                                            <asp:BoundField DataField="RDGender" HeaderText="लिंग" />
                                            <asp:BoundField DataField="DOB" HeaderText="जन्म मिति">
                                                <ItemStyle Font-Names="Verdana" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DesName" HeaderText="पद" />
                                            <asp:CommandField ShowSelectButton="True">
                                                <ItemStyle Font-Names="Verdana" />
                                            </asp:CommandField>
                                        </Columns>
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#999999" />
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td valign="top" style="width: 75px">
                    <asp:Label ID="Label15" runat="server" Text="हस्ते" SkinID="Unicodelbl"></asp:Label></td>
                <td valign="top">
                    <asp:UpdatePanel id="UpdatePanel3" runat="server">
                        <contenttemplate>
                    <asp:TextBox ID="txtMediatorEmp" runat="server" Width="230px" SkinID="Unicodetxt"></asp:TextBox>
</contenttemplate>
                    </asp:UpdatePanel></td>
                <td valign="top" style="width: 80px">
                    
                    <asp:Button ID="btnMediatorSearch" OnClientClick="SetHaste()"  runat="server" Text="खोज्नुहोस्" SkinID="Search" OnClick="btnMediatorSearch_Click">
                    </asp:Button></td>
                <td valign="top">
                </td>
            </tr>
            <tr>
                <td valign="top" align="left" colspan="4">
                    <ajaxToolkit:ModalPopupExtender ID="ModalPopupEmployee" runat="server" OkControlID="btnOk"
                        PopupControlID="PanelPopUpEmployee" TargetControlID="btnEmployeeSearch">
                    </ajaxToolkit:ModalPopupExtender>
                    <br />
                    <ajaxToolkit:ModalPopupExtender ID="ModalPopupHaste" runat="server" OkControlID="btnOk"
                        PopupControlID="PanelPopUpEmployee" TargetControlID="btnMediatorSearch">
                    </ajaxToolkit:ModalPopupExtender>
                    <asp:Panel Style="padding-right: 10px; display: none; padding-left: 10px; padding-bottom: 10px;
                        width: 950px; padding-top: 10px" ID="PanelPopUpEmployee" runat="server" CssClass="modalPopup">
                        <br />
                        <asp:UpdatePanel id="UpdatePanel1" runat="server">
                            <contenttemplate>
<asp:Panel style="BORDER-RIGHT: gray 1px solid; BORDER-TOP: gray 1px solid; BORDER-LEFT: gray 1px solid; CURSOR: move; COLOR: black; BORDER-BOTTOM: gray 1px solid; BACKGROUND-COLOR: #dddddd; TEXT-ALIGN: center" id="Panel5" runat="server" __designer:wfdid="w56"><TABLE width=900><TBODY><TR><TD style="WIDTH: 126px; HEIGHT: 26px"><asp:Label id="Label30" runat="server" Width="110px" Height="22px" Text="संकेत नं" SkinID="Unicodelbl" __designer:wfdid="w57"></asp:Label></TD><TD style="HEIGHT: 26px"><asp:TextBox id="txtSymbolNo" runat="server" Width="130px" SkinID="Unicodetxt" ToolTip="First Name" __designer:wfdid="w58" MaxLength="15"></asp:TextBox></TD><TD style="HEIGHT: 26px"></TD><TD style="HEIGHT: 26px"></TD><TD style="HEIGHT: 26px"></TD><TD style="WIDTH: 153px; HEIGHT: 26px"></TD></TR><TR><TD style="WIDTH: 126px; HEIGHT: 26px"><asp:Label id="Label5" runat="server" Width="92px" Height="22px" Text="पहिलो नाम" SkinID="Unicodelbl" __designer:wfdid="w59"></asp:Label></TD><TD style="HEIGHT: 26px"><asp:TextBox id="txtFName" runat="server" Width="130px" SkinID="Unicodetxt" ToolTip="First Name" __designer:wfdid="w60" MaxLength="35"></asp:TextBox></TD><TD style="HEIGHT: 26px"><asp:Label id="Label6" runat="server" Width="92px" Height="22px" Text="बिचको नाम" SkinID="Unicodelbl" __designer:wfdid="w61"></asp:Label></TD><TD style="HEIGHT: 26px"><asp:TextBox id="txtMName" runat="server" Width="130px" SkinID="Unicodetxt" __designer:wfdid="w62" MaxLength="15"></asp:TextBox></TD><TD style="HEIGHT: 26px"><asp:Label id="Label7" runat="server" Width="92px" Height="22px" Text="थर" SkinID="Unicodelbl" __designer:wfdid="w63"></asp:Label></TD><TD style="WIDTH: 153px; HEIGHT: 26px"><asp:TextBox id="txtSurName" runat="server" Width="130px" SkinID="Unicodetxt" ToolTip="Surname" __designer:wfdid="w64" MaxLength="35"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 126px; HEIGHT: 68px" vAlign=top><asp:Label id="Label8" runat="server" Width="92px" Height="22px" Text="लिंग" SkinID="Unicodelbl" __designer:wfdid="w65"></asp:Label></TD><TD style="HEIGHT: 68px" vAlign=top><asp:DropDownList id="ddlGender" runat="server" Width="135px" SkinID="Unicodeddl" __designer:wfdid="w66">
                                                <asp:ListItem Value="SG">छान्नुहोस</asp:ListItem>
                                                <asp:ListItem Value="M">पुरुष</asp:ListItem>
                                                <asp:ListItem Value="F">महिला</asp:ListItem>
                                                <asp:ListItem Value="O">अन्य</asp:ListItem>
                                            </asp:DropDownList></TD><TD style="HEIGHT: 68px" vAlign=top><asp:Label id="Label9" runat="server" Width="110px" Height="22px" Text="जन्म मिति" SkinID="Unicodelbl" __designer:wfdid="w67"></asp:Label></TD><TD style="HEIGHT: 68px"><asp:TextBox id="txtDOB" runat="server" Width="90px" SkinID="Unicodetxt" __designer:wfdid="w68" MaxLength="10"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender2" runat="server" TargetControlID="txtDOB" AutoComplete="False" Mask="9999/99/99" MaskType="Date" __designer:wfdid="w69">
                                            </ajaxToolkit:MaskedEditExtender> </TD><TD style="HEIGHT: 68px" vAlign=top><asp:Label id="Label10" runat="server" Width="114px" Height="22px" Text="बैबाहिक स्थिति" SkinID="Unicodelbl" __designer:wfdid="w70"></asp:Label></TD><TD style="WIDTH: 153px; HEIGHT: 68px" vAlign=top><asp:DropDownList id="ddlMarStatus" runat="server" Width="135px" SkinID="Unicodeddl" __designer:wfdid="w71">
                                                <asp:ListItem Value="SMS">छान्नुहोस</asp:ListItem>
                                                <asp:ListItem Value="S">अबिबाहित</asp:ListItem>
                                                <asp:ListItem Value="M">बिबाहित</asp:ListItem>
                                                <asp:ListItem Value="W">बिधवा/बिदुर</asp:ListItem>
                                                <asp:ListItem Value="D">छोडपत्र</asp:ListItem>
                                                <asp:ListItem Value="O">अन्य</asp:ListItem>
                                            </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 126px; HEIGHT: 24px"><asp:Label id="Label11" runat="server" Text="कार्यालय" SkinID="Unicodelbl" __designer:wfdid="w72"></asp:Label></TD><TD style="HEIGHT: 24px" colSpan=3><asp:DropDownList id="ddlOrganization" runat="server" Width="446px" SkinID="Unicodeddl" __designer:wfdid="w73">
                                            </asp:DropDownList></TD><TD style="HEIGHT: 24px"><asp:Label id="lblDesignation" runat="server" Text="पद" SkinID="Unicodelbl" __designer:wfdid="w74"></asp:Label></TD><TD style="WIDTH: 153px; HEIGHT: 24px"><asp:DropDownList id="ddlDesignation" runat="server" Width="135px" SkinID="Unicodeddl" __designer:wfdid="w75">
                                            </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 126px; HEIGHT: 24px" align=right><asp:Button id="btnSearch" onclick="btnSearch_Click" runat="server" Text="Search" SkinID="Normal" __designer:wfdid="w76"></asp:Button></TD><TD style="HEIGHT: 24px" align=left colSpan=3><asp:Button id="btnCancel" onclick="btnCancel_Click" runat="server" Text="Cancel" SkinID="Cancel" __designer:wfdid="w77"></asp:Button></TD><TD style="HEIGHT: 24px"></TD><TD style="WIDTH: 153px; HEIGHT: 24px"></TD></TR><TR><TD style="HEIGHT: 26px" align=left colSpan=6>&nbsp;</TD></TR><TR><TD style="HEIGHT: 260px" vAlign=top align=left colSpan=6>
<HR />
<asp:Label id="lblSearch" runat="server" Font-Bold="True" __designer:wfdid="w78"></asp:Label> <asp:Panel id="Panel2" runat="server" Width="890px" Height="150px" ScrollBars="Auto" __designer:wfdid="w79"><asp:GridView id="grdEmployee" runat="server" Width="848px" SkinID="Unicodegrd" OnSelectedIndexChanged="grdEmployee_SelectedIndexChanged" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333" __designer:wfdid="w80" OnRowDataBound="grdEmployee_RowDataBound">
<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
<asp:BoundField DataField="EMPID" HeaderText="आई डी"></asp:BoundField>
<asp:BoundField DataField="SYMBOLNO" HeaderText="संकेत नं."></asp:BoundField>
<asp:BoundField DataField="FIRSTNAME" HeaderText="पहिलो नाम"></asp:BoundField>
<asp:BoundField DataField="MIDDLENAME" HeaderText="बिचको नाम"></asp:BoundField>
<asp:BoundField DataField="SURNAME" HeaderText="थर"></asp:BoundField>
<asp:BoundField DataField="RDFULLNAME" HeaderText="पुरा नाम थर"></asp:BoundField>
<asp:BoundField DataField="RDGENDER" HeaderText="लिंग"></asp:BoundField>
<asp:BoundField DataField="DOB" HeaderText="जन्म मिति">
<ItemStyle Font-Names="Verdana"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="RDMARITALSTATUS" HeaderText="बैबाहिक सम्बन्ध"></asp:BoundField>
<asp:BoundField DataField="DesName" HeaderText="पद"></asp:BoundField>
<asp:CommandField ShowSelectButton="True">
<ItemStyle Font-Names="Verdana"></ItemStyle>
</asp:CommandField>
</Columns>

<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> </asp:Panel> <BR />
<HR />
</TD></TR></TBODY></TABLE></asp:Panel> 
</contenttemplate>
                            <triggers>
<asp:AsyncPostBackTrigger ControlID="grdEmployee" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
                        </asp:UpdatePanel>
                       <br />
                                            <asp:Button ID="btnOk" runat="server" Text="Ok" Height="31px" Width="64px" /><br />
                    </asp:Panel>
                </td>
            </tr>
        </tbody>
    </table>
    <table style="width: 137px">
        <tr>
            <td style="width: 61px">
                    <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="Submit"
                        SkinID="Normal" Width="61px"></asp:Button></td>
            <td style="width: 100px">
                    <asp:Button ID="btCancel" OnClick="btCancel_Click" runat="server" Text="Cancel" SkinID="Cancel">
                    </asp:Button></td>
        </tr>
    </table>
    <br />

    
    <asp:HiddenField ID="HiddenField1" runat="server" />
    
    <%--<input id="HiddenField1" runat="server"  type="hidden"  />--%>
    <br />
    
    
    
    <script type="text/javascript">
    
    function SetEmp()
    {    
         document.getElementById('<%=HiddenField1.ClientID%>').value="emp";
    }

    function SetHaste()
    {    
        document.getElementById('<%=HiddenField1.ClientID%>').value="haste";
    }
    
    </script>

  <%--  </contenttemplate> 
    </asp:UpdatePanel>--%>
</asp:Content>



