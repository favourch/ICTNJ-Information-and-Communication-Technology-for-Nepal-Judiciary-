<%@ Page Language="C#" MasterPageFile="~/MODULES/DLPDS/DLPDSMasterPage.master" AutoEventWireup="true" CodeFile="Program.aspx.cs" Inherits="MODULES_DLPDS_Forms_Program" Title="DLPDS | Program" %>

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
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
<script language="javascript" type="text/javascript" src="../../COMMON/JS/Validation.js"></script>
    <script language="javascript" type="text/javascript" src="../../COMMON/JS/DateValidator.js"></script>
    <script language="javascript" type="text/javascript" src="../../COMMON/JS/EnglishDateValidator.js"></script>
    <script language="javascript" type="text/javascript">
        function CallValidations()
        {
            if(validate()==false)
                return false;
            else
              return ValidateEnglishDate();
        }
function TABLE1_onclick() {

}

    </script>
    

<%--<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
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
                <asp:Label ID="lblStatus" runat="server" Text="Label"></asp:Label>&nbsp;</asp:Panel>
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label><br />
<asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click" Width="58px" />           <br />
        </asp:Panel>
      
    <table style="width: 655px">
        <tr>
            <td style="width: 100px; height: 21px;">
                <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Programs"></asp:Label></td>
            <td style="width: 100px; height: 21px;">
            </td>
            <td style="width: 100px; height: 21px;">
                <asp:Label ID="Label20" runat="server" Font-Bold="True" Text="Program Details" Width="135px"></asp:Label></td>
            <td style="width: 100px; height: 21px;">
            </td>
        </tr>
        <tr>
            <td style="width: 100px" rowspan="14" valign="top">
                <asp:ListBox ID="lstProgram" runat="server" Height="343px" Width="333px" AutoPostBack="True" OnSelectedIndexChanged="lstProgram_SelectedIndexChanged"></asp:ListBox></td>
            <td style="width: 100px">
                &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
            </td>
            <td colspan="2" rowspan="14" valign="top">
                <table>
                    <tr>
                        <td style="width: 100px">
                            <asp:Label ID="Label1" runat="server" Text="Program Name" Width="105px"></asp:Label></td>
                        <td colspan="4">
                            <asp:TextBox ID="txtProgramName_RQD" runat="server" ToolTip="Program Name" Columns="150" MaxLength="150" Width="463px"></asp:TextBox></td>
                        <td style="width: 100px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            <asp:Label ID="Label2" runat="server" Text="Program Type"></asp:Label></td>
                        <td colspan="2">
                            <asp:DropDownList ID="ddlProgramType" runat="server">
                            </asp:DropDownList></td>
                        <td style="width: 98px">
                        </td>
                        <td style="width: 100px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            <asp:Label ID="Label3" runat="server" Text="Active"></asp:Label></td>
                        <td colspan="2">
                            <asp:CheckBox ID="chkActive" runat="server" /></td>
                        <td style="width: 98px">
                        </td>
                        <td style="width: 100px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; height: 26px;">
                            <asp:Label ID="Label4" runat="server" Text="Description"></asp:Label></td>
                        <td colspan="4" style="height: 26px">
                            <asp:TextBox ID="txtPrgDescription" runat="server" Height="60px" MaxLength="250" TextMode="MultiLine" Width="464px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 100px; height: 26px;">
                            <asp:Label ID="Label5" runat="server" Text="Launch Date"></asp:Label></td>
                        <td colspan="2" style="height: 26px">
                            <asp:TextBox ID="txtLaunchDate_REQD" runat="server" Columns="12" MaxLength="10" ToolTip="Launch Date"></asp:TextBox></td>
                        <td style="width: 98px; height: 26px">
                        </td>
                        <td style="width: 100px; height: 26px;">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; height: 26px;">
                            <asp:Label ID="Label6" runat="server" Text="Duration"></asp:Label></td>
                        <td colspan="2" style="height: 26px">
                            <asp:TextBox ID="txtduration" runat="server" Columns="3" MaxLength="3"></asp:TextBox></td>
                        <td style="width: 98px; height: 26px">
                            <asp:Label ID="Label7" runat="server" Text="Duration Type"></asp:Label></td>
                        <td style="width: 100px; height: 26px;">
                            <asp:DropDownList ID="ddlDurationType" runat="server">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td style="width: 100px; height: 26px;">
                            <asp:Label ID="Label8" runat="server" Text="Location"></asp:Label></td>
                        <td colspan="3" style="height: 26px">
                            <asp:TextBox ID="txtLocation" runat="server" Height="67px" MaxLength="100" TextMode="MultiLine" Width="298px"></asp:TextBox></td>
                        <td style="width: 100px; height: 26px;">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            </td>
                        <td colspan="2">
                            </td>
                        <td style="width: 98px">
                        </td>
                        <td style="width: 100px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                        </td>
                        <td style="width: 100px">
                        </td>
                        <td style="width: 100px">
                        </td>
                        <td style="width: 98px">
                        </td>
                        <td style="width: 100px">
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Label ID="Label24" runat="server" Font-Bold="True" Text="Coordinators"></asp:Label><br />
                <hr />
                <table>
                    <tr>
                        <td style="width: 100px;" valign="top">
                            <table>
                                <tr>
                                    <td style="width: 100px">
                            <asp:Label ID="Label25" runat="server" Text="Coordinator Type" Width="118px"></asp:Label></td>
                                    <td style="width: 100px">
                            <asp:DropDownList ID="ddlCoordinatorType" runat="server">
                                <asp:ListItem Value="0">--- Select Coordinator Type ---</asp:ListItem>
                                <asp:ListItem Value="1">Coordinator</asp:ListItem>
                                <asp:ListItem Value="2">Sub Co-Ordinator</asp:ListItem>
                            </asp:DropDownList></td>
                            <td>
                            <asp:ImageButton ID="imgSearchPerson" runat="server" Height="29px" ImageUrl="~/MODULES/COMMON/Images/ListSearch.ico"
                                OnClick="imgSearchPerson_Click" Width="33px" /></td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 100px;" valign="top">
                            </td>
                        <td style="width: 100px;" valign="top">
                            </td>
                        <td style="width: 100px;">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:Label ID="Label26" runat="server" Text="Resource Persons" Width="157px"></asp:Label>
                            <asp:GridView ID="grdFacultyMember" runat="server" AutoGenerateColumns="False" CellPadding="2"
                                CellSpacing="1" ForeColor="#333333" GridLines="None" OnRowCreated="grdFacultymember_RowCreated"
                                Width="480px" OnSelectedIndexChanged="grdCoordinator_SelectedIndexChanged">
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelect" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Org_ID" HeaderText="OrgID">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Faculty_ID" HeaderText="FacultyID" />
                                    <asp:BoundField DataField="Faculty_Name" HeaderText="Faculty Name">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="P_ID" HeaderText="Person ID" />
                                    <asp:BoundField DataField="P_Name" HeaderText="Person Name">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="From_Date" HeaderText="From Date">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="To_Date" HeaderText="To Date">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Father_Name" HeaderText="Father Name">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Eng_DistName" HeaderText="District Name">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Exists" />
                                </Columns>
                                <RowStyle BackColor="#EFF3FB" />
                                <EditRowStyle BackColor="#2461BF" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Left" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                <AlternatingRowStyle BackColor="White" />
                            </asp:GridView>
                            <asp:Button ID="btnAddCoordinator" runat="server" OnClick="btnAddCoordinator_Click"
                                Text="Add" /></td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            <asp:Label ID="Label27" runat="server" Text="Coordinators"></asp:Label></td>
                        <td style="width: 100px">
                        </td>
                        <td style="width: 100px">
                        </td>
                        <td style="width: 100px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            <asp:GridView ID="grdProgramCoordinator" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="grdProgramCoordinator_SelectedIndexChanged" OnRowDataBound="grdProgramCoordinator_RowDataBound" Width="400px">
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelect" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ProgramCoordinatorID" HeaderText="ProgramCoordinatorID" />
                                    <asp:BoundField DataField="PID" HeaderText="PID" />
                                    <asp:BoundField DataField="CoordinatorName" HeaderText="Coordinator Name" >
                                        <ItemStyle Wrap="False" />
                                        <HeaderStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CoordinatorTypeID" HeaderText="Coordinator Type ID" />
                                    <asp:BoundField DataField="CoordinatorType" HeaderText="Coordinator Type" >
                                        <ItemStyle Wrap="False" />
                                        <HeaderStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Action" HeaderText="Action" />
                                    <asp:CommandField SelectText="Remove" ShowSelectButton="True" />
                                </Columns>
                                <RowStyle BackColor="#EFF3FB" />
                                <EditRowStyle BackColor="#2461BF" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle BackColor="White" />
                            </asp:GridView>
                        </td>
                        <td style="width: 100px">
                        </td>
                        <td style="width: 100px">
                        </td>
                        <td style="width: 100px">
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <br />
                <asp:Label ID="Label19" runat="server" Font-Bold="True" Text="Sponsor Details"></asp:Label>
                <hr />
                <table>
                    <tr>
                        <td style="width: 100px">
                            &nbsp;<asp:Label ID="Label10" runat="server" Text="Sponsor"></asp:Label></td>
                        <td style="width: 100px">
                            <asp:DropDownList ID="ddlSponsors" runat="server">
                            </asp:DropDownList></td>
                        <td style="width: 100px">
                        </td>
                        <td style="width: 100px">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 100px">
                            <asp:Label ID="Label17" runat="server" Text="Budget"></asp:Label></td>
                        <td style="width: 100px">
                            <asp:TextBox ID="txtBudget" runat="server" Columns="12" MaxLength="11"></asp:TextBox></td>
                        <td style="width: 100px">
                        <asp:Label ID="Label16" runat="server" Text="Currency"></asp:Label></td>
                        <td style="width: 100px">
                            <asp:DropDownList ID="ddlCurrency" runat="server">
                                <asp:ListItem Value="0">--- Select Currency ---</asp:ListItem>
                                <asp:ListItem Value="1">Rs.</asp:ListItem>
                                <asp:ListItem Value="2">Dollar</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            <asp:Label ID="Label18" runat="server" Text="From Date"></asp:Label></td>
                        <td style="width: 100px">
                            <asp:TextBox ID="txtFromDate" runat="server" Columns="12" MaxLength="10"></asp:TextBox></td>
                        <td style="width: 100px">
                            <asp:Button ID="btnAddSponsors" runat="server" Text="Add Sponsor" OnClick="btnAddSponsors_Click" /></td>
                        <td style="width: 100px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:GridView ID="grdSponsor" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="grdSponsor_SelectedIndexChanged">
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#EFF3FB" />
                                <EditRowStyle BackColor="#2461BF" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="SponsorID" HeaderText="SponsorID" />
                                    <asp:BoundField DataField="SponsorName" HeaderText="SponsorName" />
                                    <asp:BoundField DataField="Budget" HeaderText="Budget" />
                                    <asp:BoundField DataField="Currency" HeaderText="Currency" />
                                    <asp:BoundField DataField="FromDate" HeaderText="FromDate" />
                                    <asp:BoundField DataField="Action" HeaderText="Action" />
                                    <asp:CommandField ShowSelectButton="True" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                        </td>
                        <td style="width: 100px">
                        </td>
                        <td style="width: 100px">
                        </td>
                        <td style="width: 100px">
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Label ID="Label21" runat="server" Font-Bold="True" Text="Session Details"></asp:Label><br />
                <hr />
                <table>
                    <tr>
                        <td style="width: 100px">
                            <asp:Label ID="Label14" runat="server" Text="Session Name" Width="101px"></asp:Label></td>
                        <td colspan="3">
                            <asp:TextBox ID="txtSessionName" runat="server" Columns="52" MaxLength="50" Width="345px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            <asp:Label ID="Label23" runat="server" Text="From Date"></asp:Label></td>
                        <td style="width: 100px">
                            <asp:TextBox ID="txtSessionFromDate" runat="server" Columns="13" MaxLength="10"></asp:TextBox></td>
                        <td style="width: 100px">
                        </td>
                        <td style="width: 100px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            <asp:Label ID="Label11" runat="server" Text="Time"></asp:Label></td>
                        <td style="width: 100px">
                            <asp:TextBox ID="txtTime" runat="server" Columns="13" MaxLength="11"></asp:TextBox></td>
                        <td style="width: 100px">
                            </td>
                        <td style="width: 100px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; height: 26px;">
                        </td>
                        <td style="width: 100px; height: 26px;">
                        </td>
                        <td style="width: 100px; height: 26px;">
                            <asp:Button ID="btnAddSession" runat="server" Text="Add Session" OnClick="btnAddSession_Click" /></td>
                        <td style="width: 100px; height: 26px;">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:GridView ID="grdSession" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="grdSession_SelectedIndexChanged">
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#EFF3FB" />
                                <EditRowStyle BackColor="#2461BF" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="SessionID" HeaderText="SessionID" />
                                    <asp:BoundField DataField="SessionName" HeaderText="SessionName" />
                                    <asp:BoundField DataField="FromDate" HeaderText="FromDate" />
                                    <asp:BoundField DataField="Time" HeaderText="Time" />
                                    <asp:BoundField DataField="Action" HeaderText="Action" />
                                    <asp:CommandField ShowSelectButton="True" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Label ID="Label22" runat="server" Font-Bold="True" Text="Course Details"></asp:Label><br />
                <hr />
                <table>
                    <tr>
                        <td style="width: 100px">
                        </td>
                        <td style="width: 100px">
                        </td>
                        <td style="width: 100px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            <asp:Label ID="Label12" runat="server" Text="Course Title"></asp:Label></td>
                        <td colspan="2">
                            <asp:TextBox ID="txtCourseTitle" runat="server" Columns="102" MaxLength="100" Width="327px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 100px; height: 21px">
                            <asp:Label ID="Label13" runat="server" Text="Description"></asp:Label></td>
                        <td style="height: 21px" colspan="2">
                            <asp:TextBox ID="txtCourseDescription" runat="server" Height="78px" MaxLength="250" TextMode="MultiLine" Width="326px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            <asp:Label ID="Label15" runat="server" Text="Active"></asp:Label></td>
                        <td style="width: 100px">
                            <asp:CheckBox ID="chkCourseActive" runat="server" /></td>
                        <td style="width: 100px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                        </td>
                        <td style="width: 100px">
                        </td>
                        <td style="width: 100px">
                            <asp:Button ID="btnAddCourse" runat="server" Text="Add Course" OnClick="btnAddCourse_Click" /></td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:GridView ID="grdCourses" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="grdCourses_SelectedIndexChanged">
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#EFF3FB" />
                                <EditRowStyle BackColor="#2461BF" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="CourseID" HeaderText="CourseID" />
                                    <asp:BoundField DataField="CourseTitle" HeaderText="CourseTitle" />
                                    <asp:BoundField DataField="Description" HeaderText="Description" />
                                    <asp:BoundField DataField="Active" HeaderText="Active" />
                                    <asp:BoundField DataField="Action" HeaderText="Action" />
                                    <asp:CommandField ShowSelectButton="True" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                        </td>
                        <td style="width: 100px">
                        </td>
                        <td style="width: 100px">
                        </td>
                    </tr>
                </table>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 21px;">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td rowspan="1" style="width: 100px" valign="top">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" OnClientClick="return validate();" /></td>
            <td style="width: 100px">
                <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" /></td>
        </tr>
    </table>
</asp:Content>

