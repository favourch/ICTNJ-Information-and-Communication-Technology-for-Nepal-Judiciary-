<%@ Page Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" AutoEventWireup="true" CodeFile="MisilProcess.aspx.cs" Inherits="MODULES_CMS_Misil_MisilProcess" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <br />
    <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
<ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground"
        BehaviorID="programmaticModalPopupBehavior" DropShadow="True" PopupControlID="programmaticPopup"
        PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
        TargetControlID="hiddenTargetControlForModalPopup">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none;
        width: 350px; padding: 10px">
        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD;
            border: solid 1px Gray; color: Black; text-align: center;">
            <asp:Label ID="lblStatus" runat="server" Text="Label"></asp:Label>&nbsp;</asp:Panel>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
        <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
            Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    
  
<ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server" CollapseControlID="pnlProcessMisil" ExpandControlID="pnlProcessMisil"
    TargetControlID="pnlMisilProcess">
</ajaxToolkit:CollapsiblePanelExtender>
<div style="min-height:700px ">
<asp:Panel ID="pnlProcessMisil" runat="server" CssClass="collapsePanelHeader" 
                Width="1000px">
                Process Misil                
            </asp:Panel>
<asp:Panel ID="pnlMisilProcess" runat="server">
    <table width="1000">
        <tr>
            <td valign="top">
                
                <asp:GridView ID="grdMisil" runat="server" AutoGenerateColumns="False" Width="1000px" OnRowDataBound="grdMisil_RowDataBound">
                    <Columns>
                        <asp:BoundField HeaderText="Case ID" DataField="CaseID" />
                        <asp:BoundField HeaderText="Case No" DataField="CaseNo" />
                        <asp:BoundField HeaderText="Case Reg No" DataField="RegNo" />                        
                        <asp:BoundField DataField="CaseName" HeaderText="Case" />
                        <asp:BoundField DataField="CaseTypeName" HeaderText="CaseType" />
                        <asp:BoundField HeaderText="Requesting Organisation" DataField="OrgName" />
                        <asp:BoundField HeaderText="Req Date" DataField="ReqDate" />
                        <asp:BoundField HeaderText="Req Org" DataField="ReqOrg" />
                        <asp:BoundField HeaderText="Doc Type ID" DataField="DocTypeID" />
                        <asp:BoundField HeaderText="Doc Type Name" DataField="DocTYpeName" />
                        <asp:BoundField HeaderText="Req Chalani No" DataField="ReqChalaniNo" />
                        <asp:BoundField HeaderText="Req Reply Chalani No" DataField="ReqReplyChalaniNo" />
                        <asp:BoundField HeaderText="Is Return" DataField="IsReturn" />
                        <asp:BoundField DataField="Appelant" HeaderText="Appelant" />
                        <asp:BoundField DataField="Respondant" HeaderText="Respondant" />
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkbtnSelect" runat="server" CausesValidation="False" CommandName="Select"
                                    Text="Select"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table width="1000">
                    <tr>
                        <td valign="top" style="width:150px">
                            <asp:Label ID="lblDate" runat="server" SkinID="Unicodelbl" Text=" Received Date" Width="147px"></asp:Label></td>
                        <td valign="top">
                            <asp:TextBox ID="txtReceivedDate" runat="server" SkinID="Unicodetxt" Width="150px"></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender ID="mskedt1" runat="server" AutoComplete="False"
                                ClearMaskOnLostFocus="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtReceivedDate">
                            </ajaxToolkit:MaskedEditExtender>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="height: 10px">
                            <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="Dartaa No" Width="98px"></asp:Label></td>
                        <td valign="top" style="height: 10px">
                            <asp:TextBox ID="txtDartaaNo" runat="server" SkinID="Unicodetxt" Width="150px" MaxLength="10"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td valign="top">
                        </td>
                        <td valign="top">
                            <asp:Button ID="btnSubmitMisilDarta" runat="server" OnClick="btnSubmit_Click" SkinID="Normal"
                                Text="Submit" /><asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click"
                                    SkinID="Cancel" Text="Cancel" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="top">
            </td>
        </tr>
    </table>
    </asp:Panel>
  <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender2" runat="server" CollapseControlID="PnlChalaani" ExpandControlID="PnlChalaani"
        TargetControlID="pnlMisilChalaani">
    </ajaxToolkit:CollapsiblePanelExtender>
    <asp:Panel ID="PnlChalaani" runat="server" CssClass="collapsePanelHeader" 
                Width="1000px">
        Chalaan Misil                
            </asp:Panel>
<asp:Panel ID="pnlMisilChalaani" runat="server">
    <table width="1000">
        <tr>
            <td valign="top">
                
                <asp:GridView ID="grdMisilChalaani" runat="server" AutoGenerateColumns="False" Width="1000px" OnRowDataBound="grdMisilChalaani_RowDataBound">
                    <Columns>
                        <asp:BoundField HeaderText="Case ID" DataField="CaseID" />
                        <asp:BoundField HeaderText="Case No" DataField="CaseNo" />
                        <asp:BoundField HeaderText="Case Reg No" DataField="RegNo" />                        
                        <asp:BoundField DataField="CaseName" HeaderText="Case" />
                        <asp:BoundField DataField="CaseTypeName" HeaderText="CaseType" />
                        <asp:BoundField HeaderText="Requesting Organisation" DataField="OrgName" />
                        <asp:BoundField HeaderText="Req Date" DataField="ReqDate" />
                        <asp:BoundField HeaderText="Req Org" DataField="ReqOrg" />
                        <asp:BoundField HeaderText="Doc Type ID" DataField="DocTypeID" />
                        <asp:BoundField HeaderText="Doc Type Name" DataField="DocTYpeName" />
                        <asp:BoundField HeaderText="Req Chalani No" DataField="ReqChalaniNo" />
                        <asp:BoundField HeaderText="Req Reply Chalani No" DataField="ReqReplyChalaniNo" />
                        <asp:BoundField HeaderText="Is Return" DataField="IsReturn" />
                        <asp:BoundField DataField="Appelant" HeaderText="Appelant" />
                        <asp:BoundField DataField="Respondant" HeaderText="Respondant" />
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkbtnSelect" runat="server" CausesValidation="False" CommandName="Select"
                                    Text="Select"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table width="1000">
                    <tr>
                        <td valign="top" style="width: 150px">
                            <asp:Label ID="Label7" runat="server" SkinID="Unicodelbl" Text="Chalaani No" Width="95px"></asp:Label></td>
                        <td valign="top">
                            <asp:TextBox ID="txtChalaaniNo" runat="server" SkinID="Unicodetxt" Width="150px" MaxLength="10"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td valign="top">
                            &nbsp;<asp:Label ID="Label6" runat="server" SkinID="Unicodelbl" Text="Reply Date" Width="95px"></asp:Label></td>
                        <td valign="top">
                            <asp:TextBox ID="txtReplyDate" runat="server" SkinID="Unicodetxt" Width="150px"></asp:TextBox>&nbsp;
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AutoComplete="False"
                                ClearMaskOnLostFocus="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtReplyDate">
                            </ajaxToolkit:MaskedEditExtender>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                        </td>
                        <td valign="top">
                            <asp:Button ID="btnMisilChalaani" runat="server" OnClick="btnSubmitMisilChalaani_Click" SkinID="Normal"
                                Text="Submit" /><asp:Button ID="Button2" runat="server" OnClick="btnCancelMisilChalaani_Click"
                                    SkinID="Cancel" Text="Cancel" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="top">
            </td>
        </tr>
    </table>
    </asp:Panel>
 
   <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender3" runat="server" CollapseControlID="pnlReply" ExpandControlID="pnlReply"
        TargetControlID="pnlMisilReply">
    </ajaxToolkit:CollapsiblePanelExtender>
    <asp:Panel ID="pnlReply" runat="server" CssClass="collapsePanelHeader" 
                Width="1000px">
        Reply Misil                
            </asp:Panel>
<asp:Panel ID="pnlMisilReply" runat="server">
    <table width="1000">
        <tr>
            <td valign="top">
                
                <asp:GridView ID="grdReply" runat="server" AutoGenerateColumns="False" Width="1000px" OnRowDataBound="grdReply_RowDataBound">
                    <Columns>
                        <asp:BoundField HeaderText="Case ID" DataField="CaseID" />
                        <asp:BoundField HeaderText="Case No" DataField="CaseNo" />
                        <asp:BoundField HeaderText="Case Reg No" DataField="RegNo" />                        
                        <asp:BoundField DataField="CaseName" HeaderText="Case" />
                        <asp:BoundField DataField="CaseTypeName" HeaderText="CaseType" />
                        <asp:BoundField HeaderText="Requesting Organisation" DataField="OrgName" />
                        <asp:BoundField HeaderText="Req Date" DataField="ReqDate" />
                        <asp:BoundField HeaderText="Req Org" DataField="ReqOrg" />
                        <asp:BoundField HeaderText="Doc Type ID" DataField="DocTypeID" />
                        <asp:BoundField HeaderText="Doc Type Name" DataField="DocTYpeName" />
                        <asp:BoundField HeaderText="Req Chalani No" DataField="ReqChalaniNo" />
                        <asp:BoundField HeaderText="Req Reply Chalani No" DataField="ReqReplyChalaniNo" />
                        <asp:BoundField HeaderText="Is Return" DataField="IsReturn" />
                        <asp:BoundField DataField="Appelant" HeaderText="Appelant" />
                        <asp:BoundField DataField="Respondant" HeaderText="Respondant" />
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkbtnSelect" runat="server" CausesValidation="False" CommandName="Select"
                                    Text="Select"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table width="1000">
                    <tr>
                        <td valign="top" style="width: 150px">
                            <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="Received Date" Width="95px"></asp:Label></td>
                        <td valign="top">
                            <asp:TextBox ID="txtReqReplyReceivedDate" runat="server" SkinID="Unicodetxt" Width="150px"></asp:TextBox>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            &nbsp;<asp:Label ID="Label3" runat="server" SkinID="Unicodelbl" Text="Dartaa No" Width="95px"></asp:Label></td>
                        <td valign="top">
                            <asp:TextBox ID="txtReqReplyDartaaNo" runat="server" SkinID="Unicodetxt" Width="150px" MaxLength="10"></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" AutoComplete="False"
                                ClearMaskOnLostFocus="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtReqReplyReceivedDate">
                            </ajaxToolkit:MaskedEditExtender>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                        </td>
                        <td valign="top">
                            <asp:Button ID="btnReplyMisil" runat="server" OnClick="btnSubmitMisilReply_Click" SkinID="Normal"
                                Text="Submit" /><asp:Button ID="Button3" runat="server" OnClick="btnCancelMisilReply_Click"
                                    SkinID="Cancel" Text="Cancel" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="top">
            </td>
        </tr>
    </table>
    </asp:Panel>
 
    </div>
</asp:Content>

