<%@ Page Language="C#" MasterPageFile="~/MODULES/COMMON/MasterPage.master" AutoEventWireup="true" CodeFile="MaterialCategory.aspx.cs" Inherits="MODULES_LIS_LookUp_MaterialCategory" Title="Mategory Category" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" type="text/javascript" src="../../COMMON/JS/Validation.js"></script>
    <script language="javascript" type="text/javascript" src="../../COMMON/JS/DateValidator.js"></script>
    <div style="width:100%; height: 441px">
         <table width ="100%" cellpadding ="0" cellspacing="0" border="0">
       <tr>
            <td>
                            <asp:ScriptManager id="ScriptManager1" runat="server">
                            </asp:ScriptManager>
            </td>
       </tr>
       <tr>
            <td align="center">
                <asp:Panel ID="pnlBorder" runat="server"  BorderColor="#c8cde4"
                BorderStyle="Solid" BorderWidth="1px" Width="90%" Height="350px" Style="position: static">
                    <table width ="90%"  border="0px" cellpadding="0" cellspacing="5" >
                     <tr>
                        <td  colspan="2" valign="middle" align="left" >
                           <table width="100%" height ="31px" cellpadding ="0" cellspacing="0" border="0" style="background:#c8cde4 ">
                                <tr>
                                    <td style="width: 227px"> 
                                         &nbsp;&nbsp;&nbsp;<asp:Label ID="lblTitle" runat="server" Text="Material Category" SkinID="UnicodeHeadlbl"></asp:Label>
                                    </td>
                                    <td valign ="middle"> 
                                        <asp:UpdatePanel ID="updStatus" runat="server">
                                        <ContentTemplate>
                                        <asp:Label id="lblStatus" runat="server" CssClass="errorlabel" ForeColor="Red" Font-Bold="True" __designer:wfdid="w1"></asp:Label> 
                                        </ContentTemplate>
                                                                                <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click"></asp:AsyncPostBackTrigger>
                                        <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click"></asp:AsyncPostBackTrigger>
                                        </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                           </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width ="100%">
                                 <tr>
                                    <td rowspan ="4" style="width: 705px" valign ="top">
                                        <asp:UpdatePanel id="updCategoryList" runat="server"><contenttemplate>
<asp:ListBox id="lstCategoryName" runat="server" Width="188px" Height="266px" SkinID="Unicodelst" ForeColor="Black" __designer:wfdid="w4" OnSelectedIndexChanged="lstMaterialType_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox> 
</contenttemplate>
                                                                                        <triggers>
<asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 523px; height: 26px;" align="right" >
                                        <asp:Label ID="Label2" runat="server" Text="Category Name" CssClass="simplelabel" SkinID="Unicodelbl"></asp:Label>
                                        <asp:Label ID="Label3" runat="server" ForeColor="red" Text="*" CssClass="simplelabel"></asp:Label>
                                     </td>
                                    <td align="left" style="width: 556px;padding-left:20px; height: 26px;" valign="top">
                                        <asp:UpdatePanel id="updCategoryName" runat="server">
                                            <contenttemplate>
<asp:TextBox id="txtCategoryName_rqd" runat="server" SkinID="Unicodetxt" __designer:wfdid="w2" ToolTip="Category Name"></asp:TextBox> 
</contenttemplate>
                                                                                            <triggers>
<asp:AsyncPostBackTrigger ControlID="lstCategoryName" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td style="width: 523px; height: 127px;" valign ="top" align="right" >
                                        <asp:Label ID="Label5" runat="server" Text="Category Description" CssClass="simplelabel" Width="167px" SkinID="Unicodelbl"></asp:Label>
                                    </td>
                                    <td align="left" style="width: 556px;padding-left:20px; height: 127px;" valign ="top">
                                        <asp:UpdatePanel id="updCategoryDescription" runat="server">
                                            <contenttemplate>
<asp:TextBox id="txtCategoryDescription" runat="server" Width="410px" Height="81px" SkinID="Unicodetxt" __designer:wfdid="w3" ToolTip="Category Description" MaxLength="100" TextMode="MultiLine"></asp:TextBox> 
</contenttemplate>
                                                                                            <triggers>
<asp:AsyncPostBackTrigger ControlID="lstCategoryName" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
                                        </asp:UpdatePanel></td>
                                </tr>
                                <tr>
                                    <td style="width: 705px; height: 62px;">&nbsp;</td>
                                    <td colspan="2" align="right" style="height: 62px" >
                                        <asp:Button ID="btnAdd" runat="server" OnClientClick ="return callvalidate();"  Text="Submit" OnClick="btnAdd_Click" SkinID="Normal" />
                                        <asp:Button ID="btnCancel" runat="server" OnClientClick =" clearForm();"  Text="Cancel" OnClick="btnCancel_Click" SkinID="Cancel"  /></td>
                                              </tr>
                            </table>
                        </td>
                    </tr>
                                   
                   
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                  </table>
                </asp:Panel>
               </td>
        </tr>  
        <tr>
               <td>&nbsp;</td>
        </tr>      
        <tr>
               <td align ="center">
                   &nbsp;<img src="../../../MODULES/COMMON/Images/pleasewait.gif" id = "pleasewait"  style="visibility:hidden;" />&nbsp;
                </td>
        </tr>
       </table>
      
     </div>
</asp:Content>

