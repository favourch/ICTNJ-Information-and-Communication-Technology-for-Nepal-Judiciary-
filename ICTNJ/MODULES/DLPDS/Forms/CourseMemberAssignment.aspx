<%@ Page AutoEventWireup="true" CodeFile="CourseMemberAssignment.aspx.cs" Inherits="MODULES_DLPDS_Forms_CourseMemberAssignment" Language="C#" MasterPageFile="~/MODULES/DLPDS/DLPDSMasterPage.master"
    Title="Course-Material attachment and Member assignment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">

    <script language="javascript" type="text/javascript" src="../../COMMON/JS/Validation.js"></script>

    <script language="javascript" type="text/javascript">
        function ActivateFup(fup)
        {
            document.getElementById(fup).disabled=!document.getElementById(fup).disabled;
        }
function TABLE1_onclick() {

}

    </script>

    <div style="width: 100%; height: auto">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
        <ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior"
            DropShadow="True" PopupControlID="programmaticPopup" PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
            TargetControlID="hiddenTargetControlForModalPopup">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="padding-right: 10px; display: none; padding-left: 10px; padding-bottom: 10px;
            width: 350px; padding-top: 10px">
            <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="border-right: gray 1px solid; border-top: gray 1px solid; border-left: gray 1px solid;
                cursor: move; color: black; border-bottom: gray 1px solid; background-color: #dddddd; text-align: center">
                <asp:Label ID="lblStatus" runat="server" Text="Label"></asp:Label>&nbsp;</asp:Panel>
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label><br />
            <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click" Text="OK" Width="58px" />
            <br />
        </asp:Panel>
        <br />
        <table width="950" id="TABLE1" onclick="return TABLE1_onclick()">
            <tr>
                <td colspan="2">
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Underline="True" Text="Course-Resource Person assignment"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 120px">
                    <asp:Label ID="Label1" runat="server" Text="Program"></asp:Label></td>
                <td style="width: 480px">
                    <asp:DropDownList ID="ddlProgram_Rqd" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProgram_Rqd_SelectedIndexChanged" Width="450px" ToolTip="Program">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 120px">
                    <asp:Label ID="Label2" runat="server" Text="Session"></asp:Label></td>
                <td style="width: 480px">
                    <asp:DropDownList ID="ddlSession_Rqd" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSession_Rqd_SelectedIndexChanged" Width="450px" ToolTip="Session">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 120px">
                    <asp:Label ID="Label3" runat="server" Text="Course"></asp:Label></td>
                <td style="width: 480px">
                    <asp:DropDownList ID="ddlCourse_Rqd" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCourse_Rqd_SelectedIndexChanged" Width="450px" ToolTip="Course">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="2" height="30" valign="bottom">
                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Underline="True" Text="Course material"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 120px">
                    <asp:Label ID="Label6" runat="server" Text="Material(File 1)"></asp:Label></td>
                <td style="width: 480px">
                    <asp:FileUpload ID="fup1" runat="server" Width="450px" />&nbsp; &nbsp;<asp:Image ID="Image1" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/MODULES/COMMON/Images/bycat1.ico" Visible="False" /></td>
                <td style="width: 350px">
                    <asp:CheckBox ID="chk1" runat="server" Font-Bold="True" SkinID="smallChk" />
                    <asp:LinkButton ID="lnkFile1" runat="server" OnClick="lnkFile1_Click" Enabled="False">Filename</asp:LinkButton></td>
            </tr>
            <tr>
                <td style="width: 120px; height: 23px;">
                    <asp:Label ID="Label7" runat="server" Text="Material(File 2)"></asp:Label></td>
                <td style="width: 480px; height: 23px;">
                    <asp:FileUpload ID="fup2" runat="server" Width="450px" />
                    &nbsp;
                    <asp:Image ID="Image2" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/MODULES/COMMON/Images/bycat1.ico" Visible="False" /></td>
                <td style="width: 350px; height: 23px;">
                    <asp:CheckBox ID="chk2" runat="server" Font-Bold="True" SkinID="smallChk" />
                    <asp:LinkButton ID="lnkFile2" runat="server" OnClick="lnkFile2_Click" Enabled="False">Filename</asp:LinkButton></td>
            </tr>
            <tr>
                <td style="width: 120px; height: 25px;">
                    <asp:Label ID="Label8" runat="server" Text="Material(File 3)"></asp:Label></td>
                <td style="width: 480px; height: 25px;">
                    <asp:FileUpload ID="fup3" runat="server" Width="450px" />
                    &nbsp;
                    <asp:Image ID="Image3" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/MODULES/COMMON/Images/bycat1.ico" Visible="False" /></td>
                <td style="width: 350px; height: 25px">
                    <asp:CheckBox ID="chk3" runat="server" Font-Bold="True" SkinID="smallChk" />
                    <asp:LinkButton ID="lnkFile3" runat="server" OnClick="lnkFile3_Click" Enabled="False">Filename</asp:LinkButton></td>
            </tr>
            <tr>
                <td style="width: 120px">
                    <asp:Label ID="Label9" runat="server" Text="Material(File 4)"></asp:Label></td>
                <td style="width: 480px">
                    <asp:FileUpload ID="fup4" runat="server" Width="450px" />
                    &nbsp;
                    <asp:Image ID="Image4" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/MODULES/COMMON/Images/bycat1.ico" Visible="False" /></td>
                <td style="width: 350px">
                    <asp:CheckBox ID="chk4" runat="server" Font-Bold="True" SkinID="smallChk" />
                    <asp:LinkButton ID="lnkFile4" runat="server" OnClick="lnkFile4_Click" Enabled="False">Filename</asp:LinkButton></td>
            </tr>
            <tr>
                <td style="width: 120px">
                    <asp:Label ID="Label10" runat="server" Text="Material(File 5)"></asp:Label></td>
                <td style="width: 480px">
                    <asp:FileUpload ID="fup5" runat="server" Width="450px" />
                    &nbsp;
                    <asp:Image ID="Image5" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/MODULES/COMMON/Images/bycat1.ico" Visible="False" /></td>
                <td style="width: 350px">
                    <asp:CheckBox ID="chk5" runat="server" Font-Bold="True" SkinID="smallChk" />
                    <asp:LinkButton ID="lnkFile5" runat="server" OnClick="lnkFile5_Click" Enabled="False">Filename</asp:LinkButton></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 30px" valign="bottom">
                    <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Underline="True" Text="Resource Person"></asp:Label></td>
            </tr>
        </table>
        <table width="700">
            <tr>
                <td style="width: 120px">
                    <asp:Label ID="Label12" runat="server" Text="Organization"></asp:Label></td>
                <td style="width: 580px">
                    <asp:DropDownList ID="ddlOrg" runat="server" SkinID="PCSddl" Width="450px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 120px">
                    <asp:Label ID="Label13" runat="server" Text="Facullty"></asp:Label></td>
                <td style="width: 580px">
                    <asp:DropDownList ID="ddlFaculty" runat="server" SkinID="PCSddl" Width="450px">
                    </asp:DropDownList>
                    <asp:ImageButton ID="imgSearch" runat="server" Height="25px" ImageAlign="AbsMiddle" ImageUrl="~/MODULES/COMMON/Images/ListSearch.ico" OnClick="ImageButton1_Click" ToolTip="Search Member" /></td>
            </tr>
        </table>
        <hr />
        <asp:UpdatePanel id="updFacultyMember" runat="server">
            <contenttemplate>
<asp:Label id="lblMemberCount" runat="server" Font-Bold="True" Font-Underline="True" Font-Italic="True"></asp:Label> <asp:Panel id="Panel1" runat="server" Width="900px" Height="240px" ScrollBars="Auto"><asp:GridView id="grdFacultymember" runat="server" Width="880px" ForeColor="#333333" GridLines="None" CellSpacing="1" CellPadding="2" AutoGenerateColumns="False" OnRowCreated="grdFacultymember_RowCreated">
<FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:TemplateField><ItemTemplate>
<asp:CheckBox id="chkSelect" runat="server"></asp:CheckBox>
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="Org_ID" HeaderText="OrgID">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="Faculty_ID" HeaderText="FacultyID"></asp:BoundField>
<asp:BoundField DataField="Faculty_Name" HeaderText="Faculty Name">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="P_ID" HeaderText="Person ID"></asp:BoundField>
<asp:BoundField DataField="P_Name" HeaderText="Person Name">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="From_Date" HeaderText="From Date">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="To_Date" HeaderText="To Date">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="Father_Name" HeaderText="Father Name">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="Eng_DistName" HeaderText="District Name">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:BoundField>
<asp:BoundField HeaderText="Exists"></asp:BoundField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Left"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" HorizontalAlign="Left" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView></asp:Panel> 
</contenttemplate>
            <triggers>
<asp:AsyncPostBackTrigger ControlID="imgSearch" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
        </asp:UpdatePanel><br />
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" Width="60px" /><asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click"
            Text="Cancel" Width="60px" /><%--<asp:GridView ID="grdAttachment" runat="server" AutoGenerateColumns="False" CellPadding="2" CellSpacing="1" ForeColor="#333333" GridLines="None" Width="560px">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:BoundField DataField="OrgID" HeaderText="OrgID" Visible="False" />
                <asp:BoundField DataField="ProgramID" HeaderText="ProgramID" Visible="False" />
                <asp:BoundField DataField="SessionID" HeaderText="SessionID" Visible="False" />
                <asp:BoundField DataField="CourseID" HeaderText="CourseID" Visible="False" />
                <asp:BoundField DataField="MaterialID" HeaderText="Material ID">
                    <ItemStyle Width="160px" />
                </asp:BoundField>
                <asp:BoundField DataField="MaterialName" HeaderText="Material Name">
                    <ItemStyle Width="350px" />
                </asp:BoundField>
                <asp:BoundField DataField="MaterialTypeID" HeaderText="Material Type ID" Visible="False" />
                <asp:BoundField DataField="Action" HeaderText="Action" />
                <asp:TemplateField HeaderText="Remove">
                    <ItemStyle Width="50px" />
                    <ItemTemplate>
                        <asp:CheckBox ID="chkRemove" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <RowStyle BackColor="#EFF3FB" />
            <EditRowStyle BackColor="#2461BF" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>--%></div>
</asp:Content>
