<%@ Page Language="C#" MasterPageFile="~/MODULES/LJMS/LJMSMasterPage.master" AutoEventWireup="true" CodeFile="JudgePosting.aspx.cs" Inherits="MODULES_LJMS_Report_Forms_JudgePosting" Title="LJMS | Judge Posting Report" %>

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
                &nbsp;&nbsp;
                <asp:Label ID="lblStatus" runat="server" Text="Label"></asp:Label>&nbsp;</asp:Panel>
            <br />
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label><br />
            <br />
<asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click" Width="58px" />&nbsp;
            <br />
        </asp:Panel>
   
<div style="text-align: left">
    <table width="900" >
        <tr>
            <td style="width:287px;">
                <div class="AccHeader" style="font-size:larger;font-family:Arial Rounded MT Bold;font-style:normal;text-align:center;background-color:InfoBackground;color:Navy" >
                    संस्थाको नाम</div> 
            </td>
            <td rowspan="2" style="width: 287px;background-color:InactiveBorder">
            </td>
            <td style="width:287px;">
               <div class="AccHeader" style="font-size:larger;font-family:Arial Rounded MT Bold;font-style:normal;text-align:center;background-color:InfoBackground;color:Navy">पद</div> 
            </td>
            <td rowspan="2" style="width: 255px ;background-color:InactiveBorder">
            </td>
            <td style="width:287px;">
                <div class="AccHeader" style="font-size:larger;font-family:Arial Rounded MT Bold;font-style:normal;text-align:center;background-color:InfoBackground;color:Navy">तह</div> 
            </td>
        </tr>
        <tr>
            <td style="width:287px;">
                <asp:Panel ID="Panel1" runat="server" Height="275px" Width="287px" ScrollBars="Auto">
                    <asp:CheckBoxList ID="chkBoxListOffice" runat="server">
                    </asp:CheckBoxList>
                </asp:Panel>               
            </td>
            <td style="width:287px;">
                <asp:Panel ID="Panel2" runat="server" Height="275px" Width="287px" ScrollBars="Auto">
                        <asp:CheckBoxList ID="chkBoxListPost" runat="server">
                        </asp:CheckBoxList>
                 </asp:Panel>
             </td>
            <td style="width:287px;">               
               <asp:Panel ID="Panel6" runat="server" Height="275px" Width="287px" ScrollBars="Auto">
                <asp:CheckBoxList ID="chkBoxListLevel" runat="server">
                </asp:CheckBoxList>
               </asp:Panel>  
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <hr />
            </td>
        </tr>
        <tr>
            <td style="width:287px;"> 
                <div class="AccHeader" style="font-size:larger;font-family:Arial Rounded MT Bold;font-style:normal;text-align:center;background-color:InfoBackground;color:Navy">सेवा</div>
            </td>
            <td rowspan="2" style="width: 287px;background-color:InactiveBorder">
            </td>
           <td style="width:287px;"> 
                <div class="AccHeader" style="font-size:larger;font-family:Arial Rounded MT Bold;font-style:normal;text-align:center;background-color:InfoBackground;color:Navy">समुह</div>
            </td>
            <td rowspan="2" style="width: 255px;background-color:InactiveBorder">
            </td>
            <td style="width:287px;"> 
                <div class="AccHeader" style="font-size:larger;font-family:Arial Rounded MT Bold;font-style:normal;text-align:center;background-color:InfoBackground;color:Navy">उपसमुह</div>
            </td>
        </tr>
        <tr>
            <td style="width: 287px; height: 71px;">
                <asp:DropDownList ID="ddlSewa" runat="server" Width="154px" AutoPostBack="True" OnSelectedIndexChanged="ddlSewa_SelectedIndexChanged" SkinID="Unicodeddl">
                </asp:DropDownList></td>
            <td style="width: 9px; height: 71px">
                <asp:DropDownList ID="ddlSamuha" runat="server" Width="154px" OnSelectedIndexChanged="ddlSamuha_SelectedIndexChanged" AutoPostBack="True" SkinID="Unicodeddl">
                </asp:DropDownList></td>
            <td style="width: 100px; height: 71px;">
                <asp:DropDownList ID="ddlUpaSamuha" runat="server" Width="154px" SkinID="Unicodeddl">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="5" style="height: 15px">
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="5" style="height: 12px">
            </td>
        </tr>
        <tr>
            <td colspan="5" style="height: 12px">
                <asp:Label ID="lblSelectReportType" runat="server" Font-Bold="False" Width="120px" Font-Size="12pt"
                    Text="रिपोर्ट को किसिम:" SkinID="Unicodelbl"></asp:Label>
                &nbsp; &nbsp;
                <asp:DropDownList ID="ddlReportType" runat="server" Width="179px" SkinID="Unicodeddl">
                    <asp:ListItem Value="0">-----------छान्नुहोस्---------------</asp:ListItem>
                    <asp:ListItem Value="1">कार्यालय बाट</asp:ListItem>
                    <asp:ListItem Value="2">सेवा बाट</asp:ListItem>
                    <asp:ListItem Value="3">तह बात</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="5" style="height: 12px">
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="5" style="height: 12px">
                &nbsp;
                <asp:Button ID="btnGenerateReport" runat="server" OnClick="Button1_Click" Text="View" ToolTip="Generates Employee Posting Report" Width="60px" SkinID="Normal" />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Cancel" Width="60px" SkinID="Cancel" /></td>
        </tr>
    </table>
 </div>
    <div style="width: 100px; height: 100px">
    </div>
</asp:Content>

