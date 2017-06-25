<%@ Page Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master" AutoEventWireup="true" CodeFile="DeputationHistory.aspx.cs" Inherits="MODULES_PMS_ReportForms_DeputationHistory" Title="PMS || Employee Deputation History" %>
<%@ Register 
    Assembly="AjaxControlToolkit" 
    Namespace="AjaxControlToolkit" 
    TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:Button runat="server" ID="hiddenTargetControlForModalPopup" style="display:none"/>
                 <asp:ScriptManager id="ScriptManager1" runat="server">
                </asp:ScriptManager>
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
                <contenttemplate></contenttemplate>
            <asp:UpdatePanel id="UpdatePanel3" runat="server">
                <contenttemplate>
            <br />
                    <asp:Label ID="lblStatusMessage" runat="server" Height="19px" Text="Label"></asp:Label>
                </contenttemplate>
            </asp:UpdatePanel>
<asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click" Width="58px" />           <br />
        </asp:Panel>
    <br />
<table Width="848">

 <tr>
            <td>
                <asp:Label ID="Label30" runat="server" Height="22px" SkinID="Unicodelbl"
                    Text="संकेत नं" Width="110px"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtSymbolNo" runat="server" MaxLength="15" SkinID="Unicodetxt" ToolTip="First Name"
                    Width="130px"></asp:TextBox></td>
            <td style="width:100px">
            </td>
            <td>
            </td>
            <td style="width:30px">
            </td>
            <td >
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Height="22px" SkinID="Unicodelbl"
                    Text="पहिलो नाम" Width="92px"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtFName" runat="server" MaxLength="35" SkinID="Unicodetxt" ToolTip="First Name"
                    Width="130px"></asp:TextBox></td>
            <td>
                <asp:Label ID="Label4" runat="server" Height="22px" SkinID="Unicodelbl"
                    Text="बिचको नाम" Width="92px"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtMName" runat="server" MaxLength="15" SkinID="Unicodetxt" Width="130px"></asp:TextBox></td>
            <td>
                <asp:Label ID="Label5" runat="server" Height="22px" SkinID="Unicodelbl"
                    Text="थर" Width="30px"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtSurName" runat="server" MaxLength="35" SkinID="Unicodetxt" ToolTip="Surname"
                    Width="130px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Height="22px" SkinID="Unicodelbl"
                    Text="लिंग" Width="92px"></asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlGender" runat="server" SkinID="Unicodeddl" Width="135px">
                    <asp:ListItem Value="SG">छान्नुहोस</asp:ListItem>
                    <asp:ListItem Value="M">पुरुष</asp:ListItem>
                    <asp:ListItem Value="F">महिला</asp:ListItem>
                    <asp:ListItem Value="O">अन्य</asp:ListItem>
                </asp:DropDownList></td>
            <td>
                <asp:Label ID="Label7" runat="server" Height="22px" SkinID="Unicodelbl"
                    Text="जन्म मिति" Width="110px"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtDOB" runat="server" MaxLength="10" SkinID="Unicodetxt" Width="130px"></asp:TextBox></td>
            <td>
               </td>
            <td>
               
               </td>
            <td>
               </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label9" runat="server" SkinID="Unicodelbl" Text="कार्यालय"></asp:Label></td>
            <td colspan="3">
                <asp:DropDownList ID="ddlOrganization" runat="server" SkinID="Unicodeddl" Width="350px">
                </asp:DropDownList></td>
            
        </tr>
         <tr>
            <td>
                <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="काज कार्यालय"></asp:Label></td>
            <td colspan="3">
                <asp:DropDownList ID="ddlDeputedOrgs" runat="server" SkinID="Unicodeddl" Width="350px">
                </asp:DropDownList></td>
            <td>
                </td>
            <td>
                </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="3">
            </td>
            <td>
            </td>
            <td>
                <asp:Button ID="btnSearch" runat="server"  Text="Search" SkinID="Normal" OnClick="btnSearch_Click" /><asp:Button ID="btnCancel" runat="server" 
                        Text="Cancel" SkinID="Cancel" OnClick="btnCancel_Click" /></td>
        </tr>
        
 <tr>
            <td align="left" colspan="6">
                </td>
        </tr>
        <tr>
            <td colspan="6">
                <hr />
                <asp:UpdatePanel id="UpdatePanel1" runat="server">
                    <contenttemplate>
<asp:Label id="lblSearch" runat="server" Font-Bold="True"></asp:Label><BR /><asp:Panel id="Panel1" runat="server" Width="100%" Height="177px"><DIV style="OVERFLOW-X: hidden; OVERFLOW: scroll; max-height: 200px" id="grdDiv" runat="server"><asp:GridView id="grdEmployee" runat="server" Width="848px" SkinID="Unicodegrd" ForeColor="#333333" CellPadding="0" AutoGenerateColumns="False" OnRowDataBound="grdEmployee_RowDataBound" OnRowCreated="grdEmployee_RowCreated">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:TemplateField><HeaderTemplate>
    <asp:CheckBox ID="selectAllCb" runat="server"/>
    
</HeaderTemplate>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
<ItemTemplate>
    <asp:CheckBox ID="selectCb" runat=server />
    
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="EmpID" HeaderText="आई डी"></asp:BoundField>
<asp:BoundField DataField="SymbolNo" HeaderText="संकेत नं."></asp:BoundField>
<asp:BoundField DataField="OrgEmpNo" HeaderText="कर्मचारी न.">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="EmpName" HeaderText="पुरा नाम थर">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Gender" HeaderText="लिंग">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DOB" HeaderText="जन्म मिति">
<ItemStyle HorizontalAlign="Center" Font-Names="Verdana" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView>&nbsp;<BR />&nbsp;</DIV></asp:Panel> 
</contenttemplate>
                    <triggers>
<asp:PostBackTrigger ControlID="grdEmployee"></asp:PostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
                </asp:UpdatePanel>
                <hr />
                &nbsp;
                <br />
                <asp:Button ID="viewDeputationRpt_Btn" OnClick="viewDeputationRpt_Btn_Click" Width="100px"  runat="server" Text="View Report" SkinID="Normal" />&nbsp;
            </td>
        </tr>
        
    </table>
    <script type="text/javascript">

        function SelectAll(id)
        {
            //get reference of GridView control
            var grid = document.getElementById("<%=grdEmployee.ClientID %>");
            //variable to contain the cell of the grid
            var cell;
            
            if (grid.rows.length > 0)
            {
                //loop starts from 1. rows[0] points to the header.
                for (i=1; i<grid.rows.length; i++)
                {
                    //get the reference of first column
                    cell = grid.rows[i].cells[0];
                    
                    //loop according to the number of childNodes in the cell
                    for (j=0; j<cell.childNodes.length; j++)
                    {           
                        //if childNode type is CheckBox                 
                        if (cell.childNodes[j].type =="checkbox")
                        {
                        //assign the status of the Select All checkbox to the cell checkbox within the grid
                            cell.childNodes[j].checked = document.getElementById(id).checked;
                        }
                    }
                }
            }
        }
        
       
    </script>	
</asp:Content>

