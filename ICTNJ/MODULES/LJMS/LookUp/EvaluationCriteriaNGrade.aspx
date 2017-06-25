<%@ Page Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master" AutoEventWireup="true" CodeFile="EvaluationCriteriaNGrade.aspx.cs" Inherits="MODULES_PMS_LookUp_EvaluationCriteriaNGrade" Title="PMS | Evaluation Criteria" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script language="javascript" type="text/javascript" src="../../COMMON/JS/Number.js"></script>
    <script language="javascript" src="../../COMMON/JS/Validation.js" type="text/javascript"></script>
    <script language="javascript" src="../../COMMON/JS/DateValidator.js" type="text/javascript"></script>

    <div style="width:100%; height:auto">
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager><asp:Label ID="Label9" runat="server" SkinID="UnicodeHeadlbl"
            Text="मूल्यांकनको कार्य विवरण र भार"></asp:Label><br />
        <table width="800">
            <tr>
                <td width="250" style="height: 404px" valign="top">
                    <asp:ListBox ID="lstCriteria" runat="server" Height="400px" SkinID="Unicodelst" Width="230px" AutoPostBack="True" OnSelectedIndexChanged="lstCriteria_SelectedIndexChanged"></asp:ListBox></td>
                <td style="width: 550px; height: 404px;" valign="top">
                    <table width="550">
                        <tr>
                            <td style="width: 80px">
                                <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="समूह"></asp:Label></td>
                            <td style="width: 470px">
                                <asp:DropDownList ID="ddlGroup_rqd" runat="server" SkinID="Unicodeddl" Width="236px" AutoPostBack="True" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged" ToolTip="Evaluation Group">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td colspan="2"><hr />
                                </td>
                        </tr>
                        <tr>
                            <td style="width: 80px">
                                <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="विवरण"></asp:Label></td>
                            <td style="width: 470px">
                                <asp:TextBox ID="txtCriteria_rqd" runat="server" Width="230px" SkinID="Unicodetxt" ToolTip="Criteria Name" MaxLength="145"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 80px">
                                <asp:Label ID="Label5" runat="server" SkinID="Unicodelbl" Text="अवधि देखी"></asp:Label></td>
                            <td style="width: 470px">
                                <asp:TextBox ID="txtFromDate_rdt" runat="server" SkinID="Unicodetxt" Width="70px" ToolTip="From Date"></asp:TextBox>&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                <asp:Label ID="Label6" runat="server" SkinID="Unicodelbl" Text="अवधि सम्म"></asp:Label>
                                <asp:TextBox ID="txtToDate_rdt" runat="server" SkinID="Unicodetxt" Width="70px" ToolTip="To Date"></asp:TextBox>
                                &nbsp; &nbsp; &nbsp; &nbsp;
                                <asp:Label ID="Label7" runat="server" SkinID="Unicodelbl" Text="सक्रिय"></asp:Label>&nbsp;<asp:CheckBox ID="chkActive" runat="server" /></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <hr />
                                <ajaxToolkit:MaskedEditExtender ID="mskFromDate" runat="server" AutoComplete="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtFromDate_rdt">
                                </ajaxToolkit:MaskedEditExtender>
                                <ajaxToolkit:MaskedEditExtender ID="mskToDate" runat="server" AutoComplete="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtToDate_rdt">
                                </ajaxToolkit:MaskedEditExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 80px">
                                <asp:Label ID="Label3" runat="server" SkinID="Unicodelbl" Text="भारको नाम"></asp:Label></td>
                            <td style="width: 470px">
                                <asp:TextBox ID="txtGrade" runat="server" Width="230px" SkinID="Unicodetxt" MaxLength="145"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 80px; height: 21px">
                                <asp:Label ID="Label4" runat="server" SkinID="Unicodelbl" Text="भार"></asp:Label></td>
                            <td style="width: 470px; height: 21px">
                                <asp:TextBox ID="txtWeight" runat="server" onKeyPress="return DecimalOnly(event,this)" SkinID="Unicodetxt" Width="68px" MaxLength="4"></asp:TextBox>&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                <asp:Label ID="Label8" runat="server" SkinID="Unicodelbl" Text="सक्रिय"></asp:Label><asp:CheckBox ID="chkGrade" runat="server" SkinID="smallChk" />
                                &nbsp; &nbsp;<asp:Button ID="btnAddWeight" runat="server" Text="+" Width="48px" OnClick="btnAddWeight_Click" SkinID="Add" /></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 1px">
                                <asp:Panel ID="Panel1" runat="server" Height="200px" Width="500px" ScrollBars="Auto">
                                    <asp:GridView ID="grdGrade" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="470px" OnSelectedIndexChanged="grdGrade_SelectedIndexChanged" SkinID="Unicodegrd" OnRowCreated="grdGrade_RowCreated">
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <EditRowStyle BackColor="#999999" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:BoundField DataField="EvaluationCriteriaID" HeaderText="EvalCritID">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FromDate" HeaderText="देखी">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="EvaluationGradeID" HeaderText="EvalGradeID">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="EvaluationGradeName" HeaderText="भारको नाम">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TotalWeight" HeaderText="भार">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Active" HeaderText="सक्रिय" />
                                            <asp:BoundField DataField="Action" HeaderText="Action" />
                                            <asp:CommandField ShowSelectButton="True" />
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table><asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="65px" OnClick="btnSubmit_Click" OnClientClick="return validate(1)" SkinID="Normal" /><asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="65px" OnClick="btnCancel_Click" SkinID="Cancel" /></td>
            </tr>
        </table>
        
        <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
        <ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior"
            DropShadow="True" PopupControlID="programmaticPopup" PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
            TargetControlID="hiddenTargetControlForModalPopup">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none; width: 350px; padding: 10px">
            <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD; border: solid 1px Gray; color: Black; text-align: center;">
                Status
            </asp:Panel>
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label><br />
            <br />
            <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click" Text="OK" Width="58px" />
            <br />
        </asp:Panel>
    </div>
</asp:Content>

