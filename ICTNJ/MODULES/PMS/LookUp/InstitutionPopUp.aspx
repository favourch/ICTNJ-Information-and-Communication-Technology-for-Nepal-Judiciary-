<%@ Page Language="C#" MasterPageFile="~/MODULES/PMS/PMSPopUpMasterPage.master" AutoEventWireup="true" CodeFile="InstitutionPopUp.aspx.cs" Inherits="MODULES_PMS_LookUp_InstitutionPopUp" Title="Untitled Page" %>
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
                    <div style="padding: 10px; text-align: center">

            <asp:Panel runat="Server" ID="programmaticPopupDragHandle" Style="cursor: move;background-color:#DDDDDD;border:solid 1px Gray;color:Black;text-align:center;">
                Save Status
            </asp:Panel>
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label><br />
<asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click" Width="58px" />  
</div>
        </asp:Panel>     
    <br />
    <asp:Label ID="Label3" runat="server" SkinID="UnicodeHeadlbl" Text="तालिम केन्द्र"></asp:Label>
    <br />
    <br />
    <table style="width: 750px; height: 300px">
        <tr>
            <td colspan="4">
            </td>
        </tr>
        <tr>
            <td rowspan="7" style="width: 260px" valign="top">
                <asp:ListBox ID="lstInstitution" runat="server" OnSelectedIndexChanged="lstInstitution_SelectedIndexChanged"
                    Width="250px" Height="245px" AutoPostBack="True" SkinID="Unicodelst"></asp:ListBox></td>
            <td style="width: 27px">
            </td>
            <td style="width: 154px" valign="top">
                <asp:Label ID="lblInstitutionName" runat="server" Text="Institution Name" SkinID="Unicodelbl"></asp:Label></td>
            <td style="width: 483px" valign="top">
                <asp:TextBox ID="txtInstitutionName_Rqd" runat="server" ToolTip="Institution Name"
                    Width="250px" MaxLength="100" SkinID="Unicodetxt"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 27px">
            </td>
            <td style="width: 154px" valign="top">
                <asp:Label ID="lblBoardname" runat="server" Text="Board Name" SkinID="Unicodelbl"></asp:Label></td>
            <td style="width: 483px" valign="top">
                <asp:TextBox ID="txtBoardName_Rqd" runat="server" ToolTip="Board Name" Width="250px" MaxLength="100" SkinID="Unicodetxt"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 27px; height: 26px">
            </td>
            <td style="width: 154px; height: 26px" valign="top">
                <asp:Label ID="lblLocation" runat="server" Text="Location" SkinID="Unicodelbl"></asp:Label></td>
            <td style="width: 483px; height: 26px" valign="top">
                <asp:TextBox ID="txtLocation_Rqd" runat="server" ToolTip="Location" Width="250px" MaxLength="100" SkinID="Unicodetxt"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 27px">
            </td>
            <td style="width: 154px" valign="top">
                <asp:Label ID="lblCountry" runat="server" Text="Country" SkinID="Unicodelbl"></asp:Label></td>
            <td style="width: 483px" valign="top">
                <asp:DropDownList ID="ddlCountry_Rqd" runat="server" ToolTip="Country Name" Width="41%" SkinID="Unicodeddl">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 27px">
            </td>
            <td style="width: 154px" valign="top">
                <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="Institution Type"></asp:Label></td>
            <td style="width: 483px" valign="top">
                <asp:DropDownList ID="ddlInstitutionType" runat="server" SkinID="Unicodeddl" Width="41%">
                    <asp:ListItem Selected="True" Value="0">छान्नुहोस्</asp:ListItem>
                    <asp:ListItem Value="1">Academic</asp:ListItem>
                    <asp:ListItem Value="2">Training</asp:ListItem>
                    <asp:ListItem Value="3">Both</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 27px">
            </td>
            <td style="width: 154px" valign="top">
                <asp:Label ID="Label1" runat="server" Text="Active" SkinID="Unicodelbl"></asp:Label></td>
            <td style="width: 483px" valign="top">
                <asp:CheckBox ID="chkActive" runat="server" SkinID="smallChk" /></td>
        </tr>
        <tr>
            <td style="width: 27px">
            </td>
            <td colspan="2" valign="top">
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" OnClientClick="javascript:return validate();" Width="60px" SkinID="Normal"  />
                <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" SkinID="Normal" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" SkinID="Cancel" /></td>
        </tr>
    </table>
    <br />

        <script language="javascript" type="text/javascript" src="../JS/Validation.js"></script>

    &nbsp;
 

</asp:Content>

