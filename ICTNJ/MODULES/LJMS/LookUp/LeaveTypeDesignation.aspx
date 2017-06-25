<%@ Page Language="C#" MasterPageFile="~/MODULES/LJMS/LJMSMasterPage.master" AutoEventWireup="true" CodeFile="LeaveTypeDesignation.aspx.cs" Inherits="MODULES_LJMS_LookUp_LeaveTypeDesignation" Title="LJMS | Designationwise Leave" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %> 


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
                Status
            </asp:Panel>
                
            <asp:UpdatePanel id="UpdatePanel3" runat="server">
                <contenttemplate>
                    <br />
                    <asp:Label ID="lblStatusMessage" runat="server" Height="19px" Text="Label"></asp:Label>
                </contenttemplate>
            </asp:UpdatePanel>
                <asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click" Width="58px" />    
             <br />
        </asp:Panel>
    <br />
    <br />
    <table style="width: 800px">
        <tr>
            <td style="width: 130px" valign="top">
                <asp:Label ID="Label1" runat="server" Text="पद" SkinID="Unicodelbl"></asp:Label></td>
            <td style="width: 220px" valign="top">
                <asp:DropDownList ID="ddlDesignation" runat="server" CssClass="Unicodeddl" OnSelectedIndexChanged="ddlDesignation_SelectedIndexChanged" AutoPostBack="True" Width="200px">
                </asp:DropDownList></td>
            <td style="width: 120px" valign="top">
                <asp:Label ID="Label2" runat="server" Text="बिदाको कसिम" SkinID="Unicodelbl" Width="106px"></asp:Label></td>
            <td valign="top">
                <asp:DropDownList ID="ddlLeaveTypes" runat="server" Width="200px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 130px" valign="top">
                <asp:Label ID="Label4" runat="server" Text="अवधिको किसिम" SkinID="Unicodelbl" Width="125px"></asp:Label></td>
            <td colspan="3" valign="top">
                <asp:RadioButtonList ID="rdblstPeriodTypes" runat="server" RepeatDirection="Horizontal" SkinID="Unicoderadio" Width="525px" AutoPostBack="True" OnSelectedIndexChanged="rdblstPeriodTypes_SelectedIndexChanged">
                    <asp:ListItem Value="M">मासिक</asp:ListItem>
                    <asp:ListItem Value="Q">त्रैमासिक</asp:ListItem>
                    <asp:ListItem Value="H">अर्ध बार्षिक</asp:ListItem>
                    <asp:ListItem Value="Y">बार्षिक</asp:ListItem>
                    <asp:ListItem Value="O">अन्य</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td style="width: 130px" valign="top">
                <asp:Label ID="Label3" runat="server" Text="बिदाको अवधि" SkinID="Unicodelbl"></asp:Label></td>
            <td style="width: 220px" valign="top">
                <asp:TextBox ID="txtDays" runat="server" MaxLength="3" SkinID="Unicodetxt" Width="30px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterMode="ValidChars"  FilterType="Numbers" TargetControlID="txtDays">
                </cc1:FilteredTextBoxExtender>
            </td>
            <td style="width: 120px" valign="top">
                <asp:Label ID="Label5" runat="server" Text="अवधि पटक" SkinID="Unicodelbl"></asp:Label></td>
            <td valign="top">
                <asp:TextBox ID="txtPeriodTimes" runat="server" SkinID="Unicodetxt" Width="30px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterMode="ValidChars"  FilterType="Numbers" TargetControlID="txtPeriodTimes">
                </cc1:FilteredTextBoxExtender>
            </td>
        </tr>        
        <tr>
            <td style="width: 130px" valign="top">
                <asp:Label ID="Label6" runat="server" Text="जम्मा हुने ?" SkinID="Unicodelbl"></asp:Label></td>
            <td style="width: 220px" valign="top">
                <asp:CheckBox ID="chkIsAccural" runat="server" BorderStyle="None" AutoPostBack="True" Checked="True" OnCheckedChanged="chkIsAccural_CheckedChanged" /></td>
            <td style="width: 120px" valign="top">
                <asp:Label ID="Label7" runat="server" Text="जम्मा हुने दिन" SkinID="Unicodelbl" Width="112px"></asp:Label></td>
            <td valign="top">
                <asp:TextBox ID="txtAccuralDays" runat="server" SkinID="Unicodetxt" Width="30px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterMode="ValidChars"  FilterType="Numbers" TargetControlID="txtAccuralDays">
                </cc1:FilteredTextBoxExtender>
            </td>
        </tr>
        <tr>
            <td style="width: 130px" valign="top">
                <asp:Label ID="Label9" runat="server" Text="लागु हुने मिति" SkinID="Unicodelbl"></asp:Label></td>
            <td style="width: 220px" valign="top">
                <asp:TextBox ID="txtEffectiveFrom" runat="server" SkinID="Unicodetxt" Width="90px"></asp:TextBox>
                <cc1:MaskedEditExtender ID="MaskedEditExtender1" MaskType="Date" Mask="9999/99/99" runat="server" TargetControlID="txtEffectiveFrom" AutoComplete="False">
                </cc1:MaskedEditExtender>
            </td>
            <td style="width: 120px" valign="top">
                <asp:Label ID="Label8" runat="server" Text="सक्रिय" SkinID="Unicodelbl"></asp:Label></td>
            <td valign="top">
                <asp:CheckBox ID="chkIsActive" runat="server" Checked="True" SkinID="smallChk" /></td>
        </tr>
        <tr>
            <td style="width: 130px" valign="top">
                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" OnClientClick="javascript:return ValidatePage();"
                    Text="+" SkinID="Add" /></td>
            <td style="width: 220px" valign="top">
            </td>
            <td align="right" style="width: 120px" valign="top">
            </td>
            <td valign="top">
            </td>
        </tr>
    </table>
    <br />
    <table style="width: 800px">
        <tr>
            <td style="width: 100px">
                <asp:Panel ID="Panel1" runat="server" Height="150px" ScrollBars="Auto" Width="790px">
                <asp:GridView ID="grdLeaveDetails" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="grdLeaveDetails_SelectedIndexChanged" OnRowDataBound="grdLeaveDetails_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="LeaveTypeID" HeaderText="LeaveTypeID" />
                        <asp:BoundField DataField="LeaveType" HeaderText="बिदाको कसिम" />
                        <asp:BoundField DataField="DesignationID" HeaderText="DesID" />
                        <asp:BoundField DataField="Days" HeaderText="बिदाको अवधि" />
                        <asp:BoundField DataField="PeriodType" HeaderText="अवधिको कसिम" />
                        <asp:BoundField DataField="PeriodTimes" HeaderText="Period Times" />
                        <asp:BoundField DataField="IsAccural" HeaderText="Is Accural" />
                        <asp:BoundField DataField="AccuralDays" HeaderText="Accural Days" />
                        <asp:BoundField DataField="EffectiveFromDate" HeaderText="लागु हुने मिति" />
                        <asp:BoundField DataField="EffectiveTillDate" HeaderText="Effective Till Date" />
                        <asp:BoundField DataField="Active" HeaderText="Is Active" />
                        <asp:BoundField DataField="EntryBy" HeaderText="Entry By" />
                        <asp:BoundField DataField="EntryDate" HeaderText="Entry Date" />
                        <asp:BoundField DataField="Action" HeaderText="Action" />
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <table style="width: 400px">
        <tr>
            <td colspan="2" style="width: 215px">
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" SkinID="Normal" /><asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" SkinID="Cancel" /></td>
        </tr>
    </table>
</asp:Content>

