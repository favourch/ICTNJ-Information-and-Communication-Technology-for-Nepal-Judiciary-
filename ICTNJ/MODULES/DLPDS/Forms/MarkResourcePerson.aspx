<%@ Page Language="C#" MasterPageFile="~/MODULES/DLPDS/DLPDSMasterPage.master" AutoEventWireup="true" CodeFile="MarkResourcePerson.aspx.cs" Inherits="MODULES_DLPDS_Forms_MarkResourcePerson" Title="Untitled Page" %>

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
      



    <table width="950">
        <tr>
            <td colspan="2">
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Underline="True" Text="Course-Resource Person assignment"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 120px">
                <asp:Label ID="Label1" runat="server" Text="Program"></asp:Label></td>
            <td style="width: 480px">
                <asp:DropDownList ID="ddlProgram_Rqd" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProgram_Rqd_SelectedIndexChanged"
                    ToolTip="Program" Width="450px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 120px">
                <asp:Label ID="Label2" runat="server" Text="Session"></asp:Label></td>
            <td style="width: 480px">
                <asp:DropDownList ID="ddlSession_Rqd" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSession_Rqd_SelectedIndexChanged"
                    ToolTip="Session" Width="450px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 120px">
                <asp:Label ID="Label3" runat="server" Text="Course"></asp:Label></td>
            <td style="width: 480px">
                <asp:DropDownList ID="ddlCourse_Rqd" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCourse_Rqd_SelectedIndexChanged"
                    ToolTip="Course" Width="450px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="2" height="30" valign="bottom">
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 30px" valign="bottom">
                <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Underline="True" Text="Resource Person"></asp:Label><br />
                <asp:GridView ID="grdFacultymember" runat="server" AutoGenerateColumns="False" CellPadding="2"
                    CellSpacing="1" ForeColor="#333333" GridLines="None" OnRowCreated="grdFacultymember_RowCreated"
                    Width="880px">
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:BoundField DataField="FacultyID" HeaderText="FacultyID" />
                        <asp:BoundField DataField="PID" HeaderText="Person ID" />
                        <asp:BoundField DataField="PersonName" HeaderText="Person Name">
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Action" DataField="Action" />
                        <asp:BoundField DataField="MarksObtained" HeaderText="Marks Obtained">
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Marks Obtained">
                            <ItemTemplate>
                                <asp:TextBox ID="txtMarksObtained" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle BackColor="#EFF3FB" />
                    <EditRowStyle BackColor="#2461BF" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Left" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 30px" valign="bottom">
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
                <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" /></td>
        </tr>
    </table>
</asp:Content>

