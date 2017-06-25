<%@ Page AutoEventWireup="true" CodeFile="MyaadType.aspx.cs" Inherits="MODULES_CMS_Tameli_MyaadType"  Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" Title="CMS | Tameli Myaad Type" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<br />
    <asp:ScriptManager id="scriptMNGR" runat="server">
    </asp:ScriptManager>
    <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground"
        BehaviorID="programmaticModalPopupBehavior" DropShadow="True" PopupControlID="programmaticPopup"
        PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
        TargetControlID="hiddenTargetControlForModalPopup">
    </ajaxToolkit:ModalPopupExtender>
   
        <asp:Panel
            ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="padding-right: 10px;
            display: none; padding-left: 10px; padding-bottom: 10px; width: 350px; padding-top: 10px">
            <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="border-right: gray 1px solid;
                border-top: gray 1px solid; border-left: gray 1px solid; cursor: move; color: black;
                border-bottom: gray 1px solid; background-color: #dddddd; text-align: center">
                <asp:Label ID="lblStatus" runat="server" Text="Status"></asp:Label>&nbsp;</asp:Panel>
            

 <asp:UpdatePanel id="UpdatePanel3"   runat="server">
        <contenttemplate>
        <asp:Label id="lblStatusMessage" runat="server" Text=""></asp:Label> <br />
            <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
                Text="OK" Width="58px" />
                  </contenttemplate>
    </asp:UpdatePanel>
            <br />
        </asp:Panel>
    
    <table style="width: 700px" >
        <tr>
            <td style="width: 330px; height: 446px;" valign="top">
                <table style="width: 320px">
                    <tr>
                        <td>
                            <div style="overflow: auto; width: 100%; height: 400px">
                                <asp:ListBox Style="width: 330px" ID="lstMyaadType" runat="server" AutoPostBack="True"
                                    Height="380px" SkinID="Unicodelst" OnSelectedIndexChanged="lstMyaadType_SelectedIndexChanged">
                                </asp:ListBox>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top" style="height: 446px">
                <table style="width: 540px">
                    <tr>
                        <td style="width: 105px; text-align:right" valign="top">
                           &nbsp;</td>
                        <td valign="top">
                        <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="म्याद:" Width="50px"></asp:Label>
                            <asp:TextBox ID="myaadTxt_Rqd" Width="325px" SkinID="PCStxt"  runat="server"/>
                                
                        </td>
                    </tr>
                      <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                           <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl">सक्रिय:</asp:Label>
                                <asp:CheckBox ID="isActiveCb" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="Label3" runat="server" SkinID="Unicodelbl">प्रतिउत्तर:</asp:Label>
                                    <asp:CheckBox ID="pratiuttarCb" runat="server" /></td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                        <div id="myTable">
                        <table>
                        <tr>
                        <th>&nbsp;</th><th><asp:Label runat="server" ID="Label6" SkinID="UnicodeLbl">Litigants</asp:Label></th>
                        <th><asp:Label runat="server" ID="Label7" SkinID="UnicodeLbl">Attorney</asp:Label></th>
                        <th><asp:Label runat="server" ID="Label8" SkinID="UnicodeLbl">Witness</asp:Label></th>
                        
                        </tr>
                        <tr>
                        <td><asp:Label runat="server" ID="badiLbl" SkinID="UnicodeLbl">वादि</asp:Label></td>
                        <td><asp:RadioButton ID="rb_Lit_A" runat="server" GroupName="LitigantGrp" /></td>
                        <td><asp:RadioButton ID="rb_Att_A" runat="server" GroupName="AttorneyGrp" /></td>
                        <td><asp:RadioButton ID="rb_Witt_A" runat="server" GroupName="WittnessGrp" /></td>
                            </tr>
                        <tr>
                        <td><asp:Label runat="server" ID="Label4" SkinID="UnicodeLbl">प्रतिवादि</asp:Label></td>
                        <td><asp:RadioButton ID="rb_Lit_R" runat="server" GroupName="LitigantGrp"/></td>
                        <td><asp:RadioButton ID="rb_Att_R" runat="server" GroupName="AttorneyGrp" /></td>
                        <td><asp:RadioButton ID="rb_Witt_R" runat="server" GroupName="WittnessGrp" /></td>
                        </tr>
                        <tr>
                        <td><asp:Label runat="server" ID="Label5" SkinID="UnicodeLbl">दुवै:</asp:Label></td>
                        <td><asp:RadioButton ID="rb_Lit_B" runat="server" GroupName="LitigantGrp"/></td>
                        <td><asp:RadioButton ID="rb_Att_B" runat="server" GroupName="AttorneyGrp"/></td>
                        <td><asp:RadioButton ID="rb_Witt_B" runat="server" GroupName="WittnessGrp" /></td>
                        </tr>
                        
                        </table>
                        </div>
                        
                        
                           </td>
                    </tr>
                     <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td valign="top" style="height: 26px">
                        </td>
                        <td valign="top" style="height: 26px">
                            <asp:Button ID="btnSubmit" runat="server" SkinID="Normal" Text="Submit" OnClick="btnSubmit_Click" />
                            <asp:Button ID="btnCancel" runat="server" SkinID="Cancel" Text="Cancel" OnClick="btnCancel_Click" /></td>
                    </tr>
                    <tr>
                    <td style="height: 40px">&nbsp;</td><td style="height: 40px">
                        <br />
                        &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

