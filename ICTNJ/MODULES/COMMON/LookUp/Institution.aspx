<%@ Page Language="C#" MasterPageFile="~/MODULES/COMMON/MasterPage.master" AutoEventWireup="true" CodeFile="Institution.aspx.cs" Inherits="MODULES_COMMON_LookUp_Institution" Title="PMS | Institution" %>

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
            <asp:Panel runat="Server" ID="programmaticPopupDragHandle" Style="cursor: move;background-color:#DDDDDD;border:solid 1px Gray;color:Black;text-align:center;">
                Save Status
            </asp:Panel>
            <asp:UpdatePanel id="UpdatePanel3" runat="server">
                <contenttemplate>
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
</contenttemplate>
            </asp:UpdatePanel>
            <br />
<asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click" Width="58px" />           <br />
        </asp:Panel>

    <br />
    &nbsp; &nbsp;&nbsp;
    <asp:Label ID="Label3" runat="server" SkinID="UnicodeHeadlbl" Text="तालिम केन्द्र"></asp:Label>
    <br />
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
    <table style="width: 750px; height: 300px">
        <tr><TD style="WIDTH: 57px" vAlign=top rowSpan=7></TD>
            <td rowspan="7" style="width: 260px" valign="top">
                <asp:ListBox ID="lstInstitution" runat="server" OnSelectedIndexChanged="lstInstitution_SelectedIndexChanged"
                    Width="250px" Height="245px" AutoPostBack="True" SkinID="Unicodelst"></asp:ListBox></td>
            <td style="width: 27px">
            </td>
            <td style="width: 154px" valign="top">
                <asp:Label ID="lblInstitutionName" runat="server" Text="तालिम केन्द्र" SkinID="Unicodelbl" Width="90px"></asp:Label></td>
            <td style="width: 483px" valign="top">
                <asp:TextBox ID="txtInstitutionName_Rqd" runat="server" ToolTip="तालिम केन्द्रको नाम"
                    Width="250px" MaxLength="100" SkinID="Unicodetxt"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 27px">
            </td>
            <td style="width: 154px" valign="top">
                <asp:Label ID="lblBoardname" runat="server" Text="बोर्ड" SkinID="Unicodelbl"></asp:Label></td>
            <td style="width: 483px" valign="top">
                <asp:TextBox ID="txtBoardName_Rqd" runat="server" ToolTip="बोर्डको नाम" Width="250px" MaxLength="100" SkinID="Unicodetxt"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 27px; height: 26px">
            </td>
            <td style="width: 154px; height: 26px" valign="top">
                <asp:Label ID="lblLocation" runat="server" Text="ठेगाना" SkinID="Unicodelbl"></asp:Label></td>
            <td style="width: 483px; height: 26px" valign="top">
                <asp:TextBox ID="txtLocation_Rqd" runat="server" ToolTip="ठेगाना" Width="250px" MaxLength="100" SkinID="Unicodetxt"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 27px">
            </td>
            <td style="width: 154px" valign="top">
                <asp:Label ID="lblCountry" runat="server" Text="देश" SkinID="Unicodelbl"></asp:Label></td>
            <td style="width: 483px" valign="top">
                <asp:DropDownList ID="ddlCountry_Rqd" runat="server" ToolTip="Country Name" Width="41%" SkinID="Unicodeddl">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 27px">
            </td>
            <td style="width: 154px" valign="top">
                <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="तालिम केन्द्रको किसिम" Width="159px"></asp:Label></td>
            <td style="width: 483px" valign="top">
                <asp:DropDownList ID="ddlInstitutionType" runat="server" SkinID="Unicodeddl" Width="41%">
                    <asp:ListItem Selected="True" Value="0">छान्नुहोस्</asp:ListItem>
                    <asp:ListItem Value="A">Academic</asp:ListItem>
                    <asp:ListItem Value="T">Training</asp:ListItem>
                    <asp:ListItem Value="B">Both</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 27px">
            </td>
            <td style="width: 154px" valign="top">
                <asp:Label ID="Label1" runat="server" Text="शक्रिय" SkinID="Unicodelbl"></asp:Label></td>
            <td style="width: 483px" valign="top">
                <asp:CheckBox ID="chkActive" runat="server" SkinID="smallChk" /></td>
        </tr>
        <tr>
            <td style="width: 27px">
            </td>
            <td colspan="2" valign="top">
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" Width="60px" SkinID="Normal"  />
                <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" SkinID="Normal" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" SkinID="Cancel" /></td>
        </tr>
    </table></contenttemplate>
    </asp:UpdatePanel>
    <br />
    <br />

        <script language="javascript" type="text/javascript" src="../JS/Validation.js"></script>

    &nbsp;
 

</asp:Content>

