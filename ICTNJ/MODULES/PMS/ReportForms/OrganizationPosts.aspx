﻿<%@ Page Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master" AutoEventWireup="true" CodeFile="OrganizationPosts.aspx.cs" Inherits="MODULES_PMS_ReportForms_OrganizationPosts" Title="Untitled Page" %>
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
                &nbsp;&nbsp;
                <asp:Label ID="lblStatus" runat="server" Text="Label"></asp:Label>&nbsp;</asp:Panel>
            <br />
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label><br />
            <br />
<asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click" Width="58px" />&nbsp;
            <br />
        </asp:Panel>
    &nbsp;&nbsp;
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <asp:Label ID="Label3" runat="server" SkinID="UnicodeHeadlbl" Text="कार्यालय पदको रिपोर्ट"></asp:Label><br />

    <div style="text-align: left">
        <table width="900">
            <tr>            
                <td style="height: 292px;" colspan="2">
                <div class="AccHeader" style=" font-size:larger;font-family:Arial Rounded MT Bold;font-style:normal;text-align:center;background-color:InfoBackground;color:Navy">कार्यालय</div> 
                     <asp:Panel ID="Panel1" runat="server" Height="250px" Width="287px" ScrollBars="Auto">
                        <asp:CheckBoxList ID="chkBoxListOffice" runat="server" Font-Size="Large">
                        </asp:CheckBoxList>
                     </asp:Panel>       
                </td>                 
                <td style="width: 10px;background-color:InactiveBorder; height: 292px;">
                </td>
                                 
                <td style="height: 292px;" colspan="2">
                <div class="AccHeader" style="font-size:larger;font-family:Arial Rounded MT Bold;font-style:normal;text-align:center;background-color:InfoBackground;color:Navy" >
                    पद</div>                               
                    <asp:Panel ID="Panel2" runat="server" Height="250px" Width="287px" ScrollBars="Auto">
                        <asp:CheckBoxList ID="chkBoxListPost" runat="server" Font-Size="Large">
                        </asp:CheckBoxList>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="5" style="height: 25px">
                    <hr />
                </td>
            </tr>
            <tr>
                <td style="width: 56px; height: 25px">
                                <asp:Label ID="lblGender" runat="server" Text="लिंग" SkinID="Unicodelbl"></asp:Label></td>
                <td style="width: 287px; height: 25px">
                    <asp:RadioButtonList ID="rdoGender" runat="server" RepeatDirection="Horizontal"
                        SkinID="Unicoderadio">
                        <asp:ListItem Selected="True" Value="F">महिला</asp:ListItem>
                        <asp:ListItem Value="M">पुरुष</asp:ListItem>
                        <asp:ListItem Value="O">अन्य</asp:ListItem>
                    </asp:RadioButtonList></td>
                <td style="width: 10px; height: 25px; background-color: inactiveborder">
                </td>
                <td style="width: 44px; height: 25px">
                                <asp:Label ID="Label1" runat="server" Text="जन्म मिति" Width="76px" SkinID="Unicodelbl"></asp:Label></td>
                <td style="width: 287px; height: 25px">
                                <asp:TextBox ID="txtDOB" runat="server" Width="101px" SkinID="Unicodetxt"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="7" style="height: 37px">
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <table width="500px">
                        <tr>
                            <td style="width:123px;" >
                 <asp:Label ID="lblReportType" runat="server" Text="रिपोर्ट को किसिम:" Font-Bold="False" Width="120px" Font-Size="12pt" SkinID="Unicodelbl"></asp:Label></td>
                            <td style="width:264px;" >
                    <asp:DropDownList ID="ddlReportType" runat="server" Width="179px" SkinID="Unicodeddl">
                            <asp:ListItem Value="0">-----------छान्नुहोस्---------------</asp:ListItem>
                            <asp:ListItem Value="1">कार्यालय बाट</asp:ListItem>
                            <asp:ListItem Value="2">पद बाट</asp:ListItem>
                            <asp:ListItem Value="3">कर्मचारी बाट</asp:ListItem>
                    </asp:DropDownList></td>
                        </tr>
                    </table>
                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AutoComplete="False"
                                    Mask="9999/99/99" MaskType="Date" TargetControlID="txtDOB">
                                </ajaxToolkit:MaskedEditExtender>
                </td>
            </tr>
            <tr>
                <td colspan="7" style="height: 37px">
                    <hr style="width: 895px" />
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 21px">
                    <asp:Button ID="btnGenerate" runat="server" OnClick="btnGenerate_Click" Text="View" Width="82px" SkinID="Normal" />
                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" Width="82px" SkinID="Cancel" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

