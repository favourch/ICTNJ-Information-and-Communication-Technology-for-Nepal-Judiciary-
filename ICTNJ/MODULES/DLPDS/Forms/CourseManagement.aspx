<%@ Page Language="C#" MasterPageFile="~/MODULES/DLPDS/DLPDSMasterPage.master" AutoEventWireup="true" CodeFile="CourseManagement.aspx.cs" Inherits="MODULES_DLPDS_Forms_CourseManagement" Title="DLPDS | Course Management" %>

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
      

    &nbsp;<br />
    <table style="width: 886px">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Programs"></asp:Label></td>
            <td colspan="2">
                <asp:DropDownList ID="ddlPrograms" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPrograms_SelectedIndexChanged"
                    Width="549px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="height: 21px">
            </td>
            <td style="height: 21px">
            </td>
            <td style="height: 21px">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Session"></asp:Label></td>
            <td>
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Courses"></asp:Label></td>
        </tr>
        <tr>
            <td valign="top">
            </td>
            <td valign="top">
                <asp:ListBox ID="lstSession" runat="server" Height="225px" Width="367px" OnSelectedIndexChanged="lstSession_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox></td>
            <td valign="top">
                <asp:Panel ID="Panel1" runat="server" Height="225px" Width="97%" ScrollBars="Auto">
                    <asp:GridView ID="grdCourses" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        ForeColor="#333333" GridLines="None" OnRowDeleted="grdCourses_RowDeleted" OnRowDeleting="grdCourses_RowDeleting" OnSelectedIndexChanged="grdCourses_SelectedIndexChanged" OnRowDataBound="grdCourses_RowDataBound">
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="ChkSelect" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CourseID" HeaderText="Course ID" />
                            <asp:BoundField DataField="CourseTitle" HeaderText="Course Name">
                                <ItemStyle Wrap="False" />
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
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /><asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" /></td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>

