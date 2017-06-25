<%@ Page Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master" AutoEventWireup="true"
    CodeFile="RepOrgDesignationStatus.aspx.cs" Inherits="MODULES_PMS_ReportForms_RepOrgDesignationStatus"
    Title="PMS | Designation Status Of Organization" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<asp:ScriptManager runat="server" ID="sct">
    </asp:ScriptManager>

    <div style="width: 100%; height: auto">
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
           <%-- <asp:Label ID="lblStatusMessage" runat="server" Height="19px" Text="Label"></asp:Label>--%>
                <asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click" Width="58px" />    
             <br />
        </asp:Panel>
    <br />
        <div style="width: 100%; height: auto">
            <table width="800">
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblTitle" runat="server" Text="कार्यालयको पद सम्बधि विवरण" Font-Bold="True" Font-Underline="True"
                            SkinID="UnicodeHeadlbl" Width="406px"></asp:Label></td>
                </tr>
               
                <tr>
                    <td valign="top">
                        <asp:Label ID="Label1" runat="server" Text="कार्यालय" SkinID="Unicodelbl" Font-Bold="True" Width="80px"></asp:Label></td>
                    <td valign="top">
                       <%-- <asp:DropDownList ID="ddlOrgName" runat="server" Width="186px" SkinID="Unicodeddl" AutoPostBack="True" OnSelectedIndexChanged="ddlOrgName_SelectedIndexChanged">
                        </asp:DropDownList>--%>
                        <asp:Panel ID="Panel1" runat="server" Height="250px" ScrollBars="Auto" Width="250px">
                        <asp:CheckBoxList ID="chkLstOrgName" runat="server" SkinID="smallChkList">
                        </asp:CheckBoxList></asp:Panel>
                        </td>
                        <td style="width: 100px; height: 47px;" valign="top">
                        <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="पद" Width="45px" Font-Bold="True"></asp:Label></td>
                        <td valign="top">
                       <%-- <asp:DropDownList ID="ddlOrgName" runat="server" Width="186px" SkinID="Unicodeddl" AutoPostBack="True" OnSelectedIndexChanged="ddlOrgName_SelectedIndexChanged">
                        </asp:DropDownList>--%>
                            <asp:Panel ID="Panel2" runat="server" Height="150px" ScrollBars="Auto" Width="175px">
                        <asp:CheckBoxList ID="chkLstPost" runat="server" SkinID="smallChkList">
                        </asp:CheckBoxList></asp:Panel>
                        </td>
                    
                </tr>
                <%--<tr>
                    <td style="width: 100px">
                        <asp:Label ID="Label5" runat="server" SkinID="Unicodelbl" Text="पद" Width="45px"></asp:Label></td>
                    <td style="width: 200px">
                        <asp:DropDownList ID="ddlPost" runat="server" Width="186px" SkinID="Unicodeddl">
                        </asp:DropDownList></td>
                    <td colspan="1">
                    </td>
                </tr>--%>
                <tr>
                    <td colspan="4" style="height: 13px" valign="top">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Image ID="LoadImageX" runat="server" Height="0px" ImageUrl="~/MODULES/LIS/Images/Loading.gif"
                            Style="position: static" Width="0px" /></td>
                    <td style="height: 34px;">
                        <asp:Button ID="btnCreate" runat="server" SkinID="Normal" Text="View Report" Width="98px"
                            OnClick="btnCreate_Click" /><asp:Button ID="btnCancel" runat="server" SkinID="Cancel"
                                Text="Cancel" Width="60px" OnClick="btnCancel_Click" /></td>
                    <td colspan="1" valign="top" style="width: 100px;" align="right">
                    </td>
                </tr>
            </table>
        </div>
       
    </div>
</asp:Content>
