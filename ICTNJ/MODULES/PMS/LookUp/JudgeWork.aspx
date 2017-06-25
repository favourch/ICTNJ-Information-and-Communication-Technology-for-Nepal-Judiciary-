<%@ Page Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master" AutoEventWireup="true" CodeFile="JudgeWork.aspx.cs" Inherits="MODULES_PMS_LookUp_JudgeWork" Title="PMS | Judge Work List" %>
<%@ Register Src="../../COMMON/UserControls/PersonnelSearchControl.ascx" TagName="PersonnelSearchControl"
    TagPrefix="uc1" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager runat="server" ID="sct">
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
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>

    <table style="width: 900px">
        <tr><TD style="WIDTH: 19px" vAlign=top colSpan=1></TD>
            <td colspan="2" valign="top">
                <asp:Label ID="Label1" runat="server" SkinID="UnicodeHeadlbl" Text="न्यायाधीशको कार्य सम्पादन निरीक्षणको विवरण"></asp:Label></td>
        </tr>
        <tr><TD style="WIDTH: 19px" vAlign=top></TD>
            <td style="width: 300px" valign="top">
            <div style="Height:400px;WIDTH: 290px; OVERFLOW: scroll">
                            <asp:ListBox ID="lstWorks" runat="server" AutoPostBack="True" Height="380px" OnSelectedIndexChanged="lstWorks_SelectedIndexChanged"
                    SkinID="Unicodelst" Width="271px"></asp:ListBox>
            </div>
</td>
            <td valign="top">
                <table style="width: 500px">
                    <tr>
                        <td style="width: 60px; height: 90px;" valign="top">
                            <asp:Label ID="lblDescription" runat="server" Text="विवरण" Width="50px" SkinID="Unicodelbl"></asp:Label></td>
                        <td style="height: 90px;" valign="top">
                            <asp:TextBox ID="txtWork" runat="server" Height="162px" TextMode="MultiLine"
                                Width="320px" SkinID="Unicodetxt"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 60px" valign="top">
                            <asp:Label ID="lblActive" runat="server" Text="सक्रिय" Width="50px" SkinID="Unicodelbl"></asp:Label></td>
                        <td valign="top">
                            <asp:CheckBox ID="chkActive" runat="server" /></td>
                    </tr>
                    <tr>
                        <td style="width: 60px; height: 21px">
                        </td>
                        <td style="height: 21px">
                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Submit" Width="65px" SkinID="Normal" /><asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" Width="65px" SkinID="Cancel" /></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table></contenttemplate>
    </asp:UpdatePanel>
    <br />
    &nbsp;
</asp:Content>

