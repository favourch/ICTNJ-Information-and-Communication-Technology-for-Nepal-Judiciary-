<%@ Page Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" AutoEventWireup="true" CodeFile="WitnessPerson.aspx.cs" Inherits="MODULES_CMS_LookUp_WitnessPerson" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>

     <script language="javascript" type="text/javascript" src="../../COMMON/JS/Validation.js"></script>
    <script language="javascript" type="text/javascript" src="../../COMMON/JS/DateValidator.js"></script>
    <script language="javascript" type="text/javascript" src="../../COMMON/JS/EnglishDateValidator.js"></script>
  <script language="javascript" type="text/javascript">
        function BeginRequestHandler() 
        {
            var obj = document.getElementById("divGrid");
            document.getElementById('hdnScrollTop').value = obj.scrollTop;           
        }

        function EndRequestHandler()
        {
             var obj = document.getElementById("divGrid");
             obj.scrollTop = document.getElementById('hdnScrollTop').value;
           
        }
 </script>
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
    <br />
    <table width="900px">
        <tr>
            <td >
                <asp:Label ID="Label5s" runat="server" SkinID="Unicodelbl" Text="Litigant"></asp:Label></td>
        </tr>
        <tr>
            <td >
                <table width="100%">
                    <tr>
                        <td style="width: 8%" >
                            <asp:Label ID="Label1a" runat="server" SkinID="Unicodelbl" Text="मुदा नम्बर" Width="81px"></asp:Label></td>
                        <td style="width: 20%" >
                            <asp:TextBox ID="txtCaseNo" runat="server" SkinID="Unicodetxt"></asp:TextBox></td>
                        <td style="width: 5%">
                        </td>
                        <td style="width: 8%">
                            <asp:Label ID="Label2a" runat="server" SkinID="Unicodelbl" Text="दर्ता नम्बर" Width="73px"></asp:Label></td>
                        <td style="width: 20%">
                            <asp:TextBox ID="txtRegNo" runat="server" SkinID="Unicodetxt"></asp:TextBox></td>
                        <td style="width: 5%">
                        </td>
                        <td >
                            </td>
                    </tr>
                    <tr>
                        <td >
                        </td>
                        <td >
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" AutoComplete="False"
                                ClearMaskOnLostFocus="False" Mask="999-$9-9999" MaskType="Number" TargetControlID="txtCaseNo">
                            </ajaxToolkit:MaskedEditExtender>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td style="width: 6px">
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" AutoComplete="False"
                                ClearMaskOnLostFocus="False" Mask="99-999-99999" MaskType="Number" TargetControlID="txtRegNo">
                            </ajaxToolkit:MaskedEditExtender>
                        </td>
                        <td>
                        </td>
                        <td >
                            <asp:Button ID="btnSearchLitigants" runat="server" SkinID="Search" Text="Search" OnClick="btnSearchLitigants_Click" /></td>
                    </tr>
                    <tr>
                        <td colspan="7" style="height: 183px">
                            <asp:GridView ID="grdLitigants" runat="server" AutoGenerateColumns="False"
                                SkinID="Unicodegrd" OnRowDataBound="grdLitigants_RowDataBound" OnSelectedIndexChanged="grdLitigants_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <Columns>
                                    <asp:BoundField DataField="CaseID" HeaderText="Case ID" />
                                    <asp:BoundField DataField="LitigantID" HeaderText="Litigant ID" />
                                    <asp:BoundField DataField="SNo" HeaderText="S.No." />
                                    <asp:BoundField DataField="LitigantName" HeaderText="Name" />
                                    <asp:BoundField DataField="DisplayName" HeaderText="Display Name" />
                                    <asp:BoundField DataField="LitigantType" HeaderText="Type" />
                                    <asp:BoundField DataField="IsPrisoned" HeaderText="Is Prisioned" />
                                    <asp:CommandField ShowSelectButton="True" />
                                </Columns>
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <EditRowStyle BackColor="#999999" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                </td>
        </tr>
        <tr>
            <td style="height: 43px">
                <asp:Button ID="btnAddWitness" runat="server" OnClick="btnAddWitness_Click" SkinID="Normal"
                    Text="नया साक्षि थप्नुस" /></td>
        </tr>
        <tr>
            <td style="height: 21px">
            </td>
        </tr>
        <tr>
            <td style="height: 48px">
                <div id="upper" class="collapsePanelHeader" align="left" >
                    &nbsp; खोज्नुहोस् &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp;&nbsp;
                </div>
            </td>
        </tr>
        <tr>
            <td style="height: 1px" >
                <asp:Panel ID="Panel3" runat="server" Width="100%">
                    <asp:Panel ID="Panel2" runat="server" Height="50px" Width="1000px">
                        <table cellspacing="10" style="width: 900px">
                            <tr>
                                <td style="height: 26px">
                                    <asp:Label ID="Label1" runat="server" Height="22px" SkinID="Unicodelbl"
                                        Text="पहिलो नाम" Width="92px"></asp:Label></td>
                                <td style="width: 163px; height: 26px;">
                                    <asp:TextBox ID="txtFName" runat="server" MaxLength="35" SkinID="PCStxt" ToolTip="First Name"
                                        Width="130px"></asp:TextBox></td>
                                <td style="height: 26px">
                                    <asp:Label ID="Label2" runat="server" Height="22px" SkinID="Unicodelbl"
                                        Text="बिचको नाम" Width="92px"></asp:Label></td>
                                <td style="width: 163px; height: 26px">
                                    <asp:TextBox ID="txtMName" runat="server" MaxLength="15" SkinID="PCStxt" Width="130px"></asp:TextBox></td>
                                <td style="height: 26px">
                                    <asp:Label ID="Label3" runat="server" Height="22px" SkinID="Unicodelbl"
                                        Text="थर" Width="92px"></asp:Label></td>
                                <td style="width: 165px; height: 26px;">
                                    <asp:TextBox ID="txtSurName" runat="server" MaxLength="35" SkinID="PCStxt" ToolTip="Surname"
                                        Width="130px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="height: 24px">
                                    <asp:Label ID="Label5" runat="server" Height="22px" SkinID="Unicodelbl"
                                        Text="लिङग्" Width="92px"></asp:Label></td>
                                <td style="width: 163px; height: 24px;">
                                    <asp:DropDownList ID="ddlGender" runat="server" SkinID="PCSddl" Width="135px">
                                        <asp:ListItem Value="SG">लिङग् छान्नुस</asp:ListItem>
                                        <asp:ListItem Value="M">पुरुष</asp:ListItem>
                                        <asp:ListItem Value="F">महिला</asp:ListItem>
                                        <asp:ListItem Value="O">ञन्य</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td style="height: 24px">
                                    <asp:Label ID="Label8" runat="server" Height="22px" SkinID="Unicodelbl"
                                        Text="जिल्ला" Width="92px"></asp:Label></td>
                                <td style="width: 163px; height: 24px;">
                                    <asp:DropDownList ID="ddlDistrict" runat="server" SkinID="PCSddl" Width="135px">
                                    </asp:DropDownList></td>
                                <td style="height: 24px">
                                    </td>
                                <td style="width: 165px; height: 24px;">
                                    </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td style="width: 163px">
                                </td>
                                <td>
                                </td>
                                <td style="width: 163px">
                                </td>
                                <td>
                                </td>
                                <td style="width: 165px">
                                    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search"
                                        Width="68px" SkinID="Search" /><asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click"
                                            Text="Cancel" Width="68px" SkinID="Cancel" /></td>
                            </tr>
                            <tr>
                                <td colspan="6" valign="top">
                                    <hr />
                                    <asp:UpdatePanel id="UpdatePanel1" runat="server">
                                        <contenttemplate>
<%--<asp:Panel id="Panel4" runat="server" Width="800px" Height="200px" ScrollBars="Auto" __designer:wfdid="w19">--%><DIV style="OVERFLOW: auto; WIDTH: 800px; HEIGHT: 200px" id="divGrid"><asp:GridView id="grdPerson" runat="server" Width="795px" SkinID="Unicodegrd" ForeColor="#333333" CellPadding="0" OnSelectedIndexChanged="grdPerson_SelectedIndexChanged" OnRowDataBound="grdPerson_RowDataBound" AutoGenerateColumns="False" __designer:wfdid="w20">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="PERSONID" HeaderText="Person ID"></asp:BoundField>
<asp:BoundField DataField="FIRSTNAME" HeaderText="पहिलो नाम"></asp:BoundField>
<asp:BoundField DataField="MIDDLENAME" HeaderText="बिचको नाम"></asp:BoundField>
<asp:BoundField DataField="SURNAME" HeaderText="थर"></asp:BoundField>
<asp:BoundField DataField="RDFULLNAME" HeaderText="पूरा नाम"></asp:BoundField>
<asp:BoundField DataField="RDGENDER" HeaderText="लिङग्"></asp:BoundField>
<asp:BoundField DataField="DOB" HeaderText="जन्मदिन">
<ItemStyle Font-Names="Verdana"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DISTRICT" HeaderText="जिल्ला"></asp:BoundField>
<asp:BoundField DataField="FATHERNAME" HeaderText="वूञाको नाम"></asp:BoundField>
<asp:BoundField DataField="GFATHERNAME" HeaderText="बाजेको नाम"></asp:BoundField>
<asp:TemplateField ShowHeader="False">
<ItemStyle Font-Names="Verdana"></ItemStyle>
<ItemTemplate>
<asp:LinkButton runat="server" OnClientClick="BeginRequestHandler() " Text="Select" CommandName="Select" CausesValidation="False" id="LinkButton1"></asp:LinkButton>
</ItemTemplate>
</asp:TemplateField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView></DIV><%--</asp:Panel> --%>
</contenttemplate>
                                        <triggers>
<asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </asp:Panel>
                <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server" CollapseControlID="upper" ExpandControlID="upper" Collapsed="true" TargetControlID="Panel2">
                </ajaxToolkit:CollapsiblePanelExtender>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="height: 1px" valign="top">
                <table style="width: 900px">
                    <tr>
                        <td style="width: 100px">
                            <asp:Label ID="Label4" runat="server" SkinID="Unicodelbl" Text="From Date"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtFromDate_RQD" runat="server" SkinID="Unicodetxt" Width="100px" ToolTip="From Date"></asp:TextBox>&nbsp;
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="9999/99/99"
                                TargetControlID="txtFromDate_RQD" AutoComplete="False" MaskType="Date" ClearMaskOnLostFocus="False">
                            </ajaxToolkit:MaskedEditExtender>
                        </td>
                        <td align="right">
                            <asp:Button ID="btnAddPerson" runat="server" OnClick="btnAddPerson_Click" SkinID="Add"
                                Text="+" Width="40px" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" >
                                <asp:Panel ID="Panel1" runat="server" ScrollBars="auto" Width="800px" Height="250px">
                                    &nbsp;<asp:GridView ID="grdWitnesses" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        ForeColor="#333333" 
                                        SkinID="Unicodegrd" GridLines="None" OnRowCreated="grdWitnesses_RowCreated" OnRowDataBound="grdWitnesses_RowDataBound" OnRowDeleting="grdWitnesses_RowDeleting" Width="600px"  OnRowCancelingEdit="grdWitnesses_RowCancelingEdit" OnRowEditing="grdWitnesses_RowEditing" OnRowUpdating="grdWitnesses_RowUpdating">
                                        <Columns>
                                            <asp:BoundField DataField="CASEID" HeaderText="case ID" />
                                            <asp:BoundField DataField="LITIGANTID" HeaderText="Litigant ID" />
                                            <asp:BoundField DataField="PERSONID" HeaderText="Person ID" />
                                            <asp:BoundField DataField="WitnessID" HeaderText="Witness ID" />
                                            <asp:BoundField DataField="WitnessName" HeaderText="साक्षिको नाम" ReadOnly="True" />
                                            <asp:BoundField DataField="FromDate" HeaderText="From Date" />
                                            <asp:BoundField DataField="RDGender" HeaderText="लिंग" ReadOnly="True" />
                                            <asp:BoundField DataField="DOB" HeaderText="जन्म मिति" ReadOnly="True" />
                                            <asp:BoundField DataField="Action" HeaderText="Action" />
                                            <asp:CommandField ShowEditButton="True" />
                                            <asp:CommandField DeleteText="Remove" ShowDeleteButton="True" />
                                        </Columns>
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <EditRowStyle BackColor="#999999" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    </asp:GridView>
                                </asp:Panel>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;<asp:Button ID="btnSubmit" runat="server" SkinID="Normal" Text="Submit" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnCan" runat="server" SkinID="Cancel" Text="Cancel" OnClick="btnCan_Click" /></td>
       
            <input id="hdnScrollTop" type="hidden" /> </tr>
    </table>
</asp:Content>

