<%@ Page Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" AutoEventWireup="true" CodeFile="RegistrationDiary.aspx.cs" Inherits="MODULES_CMS_LookUp_RegistrationDiary" Title="CMS | Registration 
Diary" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

  

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" src="../../COMMON/JS/Validation.js" type="text/javascript"></script>
    <script language="javascript" src="../../COMMON/JS/DateValidator.js" type="text/javascript"></script>
    <script language="javascript" src="../../COMMON/JS/EnglishDateValidator.js" type="text/javascript"></script>
    <script language="javascript" src="../../COMMON/JS/Number.js" type="text/javascript"></script>
   <script language="javascript" src="../../COMMON/JS/UPanelValidation.js" type="text/javascript"></script>
    <script language="javascript" src="../../COMMON/JS/EmailValidator.js" type="text/javascript"></script>
    
    
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
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
    &nbsp;<br />
    
<TABLE style="WIDTH: 900px"><TBODY><TR><TD style="WIDTH: 20px; HEIGHT: 21px"></TD><TD style="WIDTH: 326px" vAlign=top rowSpan=2>&nbsp;<TABLE><TBODY><TR><TD style="WIDTH: 100px"><asp:Label id="Label7" runat="server" Width="99px" Text="मुदाको किसिम" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 100px"><asp:DropDownList id="DDLCaseType_RQD" runat="server" Width="210px" SkinID="Unicodeddl" AutoPostBack="True" OnSelectedIndexChanged="DDLCaseType_RQD_SelectedIndexChanged">
                            </asp:DropDownList></TD></TR><TR><TD colSpan=2></TD></TR><TR><TD colSpan=2><asp:Panel id="Panel2" runat="server" Width="315px" Height="300px">
                                <asp:GridView ID="grdOrganization" runat="server" AutoGenerateColumns="False" 
                                    Width="315px" OnSelectedIndexChanged="grdOrganization_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="grdOrganization_RowDataBound" SkinID="Unicodegrd">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSelect" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ORGID" HeaderText="Org ID" />
                                        <asp:BoundField DataField="OrgName" HeaderText="Org Name" />
                                        <asp:BoundField HeaderText="Active" DataField="ACTIVE" />
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
                            </asp:Panel> </TD></TR></TBODY></TABLE></TD><TD style="HEIGHT: 21px"></TD></TR><TR><TD style="HEIGHT: 411px" vAlign=top></TD><TD style="HEIGHT: 411px" vAlign=top><TABLE style="WIDTH: 346px"><TBODY><TR><TD vAlign=top><asp:Label id="Label2" runat="server" Width="100px" Text="दर्ता किताब" SkinID="Unicodelbl"></asp:Label></TD><TD><asp:TextBox id="txtRegistrationDiaryName" runat="server" Width="220px" SkinID="Unicodetxt" MaxLength="25"></asp:TextBox></TD><TD></TD></TR><TR><TD vAlign=top><asp:Label id="Label10" runat="server" Width="129px" Text="दर्ता किताब Code" SkinID="Unicodelbl"></asp:Label></TD><TD><asp:TextBox id="txtRegistrationDiaryCode" runat="server" Width="80px" SkinID="Unicodetxt" MaxLength="5"></asp:TextBox></TD><TD></TD></TR><TR><TD><asp:Label id="Label15" runat="server" Text="सक्रिय" SkinID="Unicodelbl"></asp:Label></TD><TD><asp:CheckBox id="chkRegistration" runat="server" Checked="True"></asp:CheckBox></TD><TD><asp:Button id="btnAddRegistrationDiary" onclick="btnAddRegistrationDiary_Click" runat="server" Text="+" SkinID="Add"></asp:Button></TD></TR><TR><TD></TD><TD vAlign=top><asp:GridView id="grdRegistrationDiary" runat="server" SkinID="Unicodegrd" GridLines="None" ForeColor="#333333" CellPadding="4" OnSelectedIndexChanging="grdRegistrationDiary_SelectedIndexChanging" OnRowDataBound="grdRegistrationDiary_RowDataBound" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="RegistrationDiaryID" HeaderText="आईडि" />
                        <asp:BoundField DataField="CaseTypeID" HeaderText="मुद्दाको प्रकारको आईडि" />
                        <asp:BoundField HeaderText="दर्ता किताब" DataField="RegistrationDiaryName" />
                        <asp:BoundField DataField="RegistrationDiaryCode" HeaderText="दर्ता किताब Code" />
                        <asp:BoundField DataField="Action" HeaderText="Action" />
                        <asp:BoundField DataField="Active" HeaderText="Active" />
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView> </TD><TD></TD></TR><TR><TD style="HEIGHT: 21px" colSpan=3>
<HR />
</TD></TR><TR><TD vAlign=top><asp:Label id="Label3" runat="server" Text="मुद्दाको बिषय" SkinID="Unicodelbl"></asp:Label></TD><TD><asp:TextBox id="txtCaseSubject" runat="server" Width="220px" SkinID="Unicodetxt" MaxLength="25"></asp:TextBox></TD><TD></TD></TR><TR><TD vAlign=top style="height: 48px">&nbsp;<asp:Label id="Label8" runat="server" Text="सक्रिय" SkinID="Unicodelbl"></asp:Label></TD><TD style="height: 48px"><asp:CheckBox id="chkSubject" runat="server" Checked="True"></asp:CheckBox></TD><TD style="height: 48px"><asp:Button id="btnAddCaseSubject" onclick="btnAddCaseSubject_Click" runat="server" Text="+" SkinID="Add"></asp:Button></TD></TR><TR><TD></TD><TD>&nbsp;<asp:GridView id="grdCaseSubject" runat="server" SkinID="Unicodegrd" GridLines="None" ForeColor="#333333" CellPadding="4" OnSelectedIndexChanging="grdCaseSubject_SelectedIndexChanging" OnRowDataBound="grdCaseSubject_RowDataBound" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="SubjectID" HeaderText="आईडि" />
                        <asp:BoundField DataField="CaseTypeID" HeaderText="मुद्दाको प्रकारको आईडि" />
                        <asp:BoundField DataField="RegistrationDiaryID" HeaderText="दर्ता किताबको आईडि" />
                        <asp:BoundField HeaderText="मुद्दाको बिषय" DataField="SubjectName" />
                        <asp:BoundField DataField="Action" HeaderText="Action" />
                        <asp:BoundField DataField="Active" HeaderText="Active" />
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <EditRowStyle BackColor="#999999" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView> </TD><TD></TD></TR><TR><TD colSpan=3>
<HR />
</TD></TR><TR><TD vAlign=top><asp:Label id="Label4" runat="server" Text="मुद्दाको नाम" SkinID="Unicodelbl"></asp:Label></TD><TD><asp:TextBox id="txtCaseName" runat="server" Width="220px" SkinID="Unicodetxt" MaxLength="25"></asp:TextBox></TD><TD></TD></TR><TR><TD vAlign=top><asp:Label id="Label6" runat="server" Text="पुष्ट्याई" SkinID="Unicodelbl"></asp:Label></TD><TD><asp:TextBox id="txtCaseNameDescription" runat="server" Width="300px" Height="50px" SkinID="Unicodetxt" MaxLength="150" TextMode="MultiLine"></asp:TextBox></TD><TD></TD></TR><TR><TD><asp:Label id="Label19" runat="server" Text="सक्रिय" SkinID="Unicodelbl"></asp:Label></TD><TD><asp:CheckBox id="chkName" runat="server" Checked="True"></asp:CheckBox></TD><TD><asp:Button id="btnAddCaseName" onclick="btnAddCaseName_Click" runat="server" Text="+" SkinID="Add"></asp:Button></TD></TR><TR><TD></TD><TD>&nbsp;<asp:GridView id="grdCaseName" runat="server" SkinID="Unicodegrd" GridLines="None" ForeColor="#333333" CellPadding="4" OnSelectedIndexChanging="grdCaseName_SelectedIndexChanging" OnRowDataBound="grdCaseName_RowDataBound" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="RegistrationDiaryNameID" HeaderText="आईडि" />
                        <asp:BoundField DataField="CaseTypeID" HeaderText="मुद्दाको प्रकारको आईडि" />
                        <asp:BoundField DataField="RegistrationDiaryID" HeaderText="दर्ता किताबको आईडि" />
                        <asp:BoundField DataField="RegistrationSubjectID" HeaderText="मुद्दाको बिषयको आईडि" />
                        <asp:BoundField HeaderText="मुद्दाको नाम" DataField="RegistrationDiaryName" />
                        <asp:BoundField DataField="RegistrationDiaryNameDescription" HeaderText="मुद्दाको नामको विवरण" />
                        <asp:BoundField DataField="Action" HeaderText="Action" />
                        <asp:BoundField DataField="Active" HeaderText="Active" />
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <EditRowStyle BackColor="#999999" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView> </TD><TD></TD></TR><TR><TD align=right colSpan=3><asp:Button id="btnSUbmit" onclick="btnSubmit_Click" runat="server" Text="Submit" SkinID="Normal"></asp:Button> <asp:Button id="btnCancel" onclick="btnCancel_Click" runat="server" Text="Cancel" SkinID="Cancel"></asp:Button></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>

    
    <br />
    <br />
    &nbsp;
</asp:Content>

