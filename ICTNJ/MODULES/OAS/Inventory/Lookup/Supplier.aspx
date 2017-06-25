<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true" CodeFile="Supplier.aspx.cs" Inherits="MODULES_OAS_Inventory_LookUp_Supplier" Title="Untitled Page" %>
 <%@ Register 
    Assembly="AjaxControlToolkit" 
    Namespace="AjaxControlToolkit" 
    TagPrefix="ajaxToolkit" %>
<%--<%@ Register Src="../../COMMON/UserControls/PersonnelSearchControl.ascx" TagName="PersonnelSearchControl"
    TagPrefix="uc1" %> --%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language ="javascript" type ="text/javascript" src ="../../../COMMON/JS/EmailValidator.js"></script>
<script language = "javascript" type ="text/javascript">
 function validateContactEmail()
    {

         var ErrMsg = "";
          ErrMsg= ValidateEmail('<%=this.txtEmail.ClientID %>');
            if (ErrMsg != "")
               {
                   alert("सर्वप्रथम निम्न त्रुटिहरू सच्याउनुहोस।\n\n" + ErrMsg);
                    return false;
               }
               else 
               return true;
       
    }
  </script>
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
<div style="width:100%; height:auto">
        <asp:Label ID="lblStatus" runat="server" Font-Bold="True" SkinID="Unicodelbl"></asp:Label>
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<TABLE width=700><TBODY><TR><TD style="WIDTH: 250px" vAlign=top><asp:ListBox id="lstSupplier" runat="server" Width="220px" Height="445px" SkinID="Unicodelst" OnSelectedIndexChanged="lstSupplier_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox> </TD><TD style="WIDTH: 450px" vAlign=top><TABLE width=450><TBODY><TR><TD style="WIDTH: 150px"><asp:Label id="Label2" runat="server" Text="बिक्रेता को नाम" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 300px"><asp:TextBox id="txtSupplierName_Rqd" runat="server" Width="250px" SkinID="Unicodetxt" MaxLength="48"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 150px; HEIGHT: 26px"><asp:Label id="Label3" runat="server" Text="बिक्रेता को ठेगाना" SkinID="Unicodelbl" Font-Bold="False" Font-Underline="False"></asp:Label></TD><TD style="WIDTH: 300px; HEIGHT: 26px"><asp:TextBox id="txtSupplierAddress" runat="server" Width="250px" SkinID="Unicodetxt" MaxLength="48"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 150px; HEIGHT: 26px"><asp:Label id="Label8" runat="server" Text="पयान न." SkinID="Unicodelbl" Font-Bold="False" Font-Underline="False"></asp:Label></TD><TD style="WIDTH: 300px; HEIGHT: 26px"><asp:TextBox id="txtPanNo" runat="server" Width="250px" SkinID="Unicodetxt" MaxLength="48"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 150px; HEIGHT: 22px"><asp:Label id="Label4" runat="server" Text="सक्रिय" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 300px; HEIGHT: 22px"><asp:CheckBox id="chkSActive" runat="server" SkinID="smallChk" Checked="True"></asp:CheckBox> </TD></TR><TR><TD style="WIDTH: 150px; HEIGHT: 30px" vAlign=bottom><asp:Label id="Label5" runat="server" Text="सम्पर्क बयक्ति को ठेगाना" SkinID="UnicodeHeadlbl" Font-Bold="True" Font-Underline="True"></asp:Label></TD><%--<td style="width: 300px; height: 30px;">
                            </td>--%></TR><TR><TD style="WIDTH: 150px; HEIGHT: 16px"><asp:Label id="Label6" runat="server" Text="सम्पर्क बयक्ति" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 300px; HEIGHT: 16px"><asp:TextBox id="txtContactPerson_Rqd" runat="server" Width="250px" SkinID="Unicodetxt" MaxLength="48"></asp:TextBox>&nbsp;</TD></TR><TR><TD style="WIDTH: 150px; HEIGHT: 16px"><asp:Label id="Label1" runat="server" Text="सम्पर्क न." SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 300px; HEIGHT: 16px"><asp:TextBox id="txtContactPhone" runat="server" Width="250px" SkinID="Unicodetxt" MaxLength="48"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 150px"><asp:Label id="Label7" runat="server" Text="ईमेल" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 300px"><asp:TextBox id="txtEmail" runat="server" Width="250px" SkinID="Unicodetxt" MaxLength="48"></asp:TextBox>&nbsp; <asp:Button id="btnAddSupplierContact" onclick="btnAddSupplierContact_Click" runat="server" Width="30px" Text="+" SkinID="Add" Font-Bold="True" OnClientClick="javascript:return validateContactEmail();"></asp:Button> </TD></TR><TR><TD style="HEIGHT: 55px" colSpan=2><asp:Panel id="Panel1" runat="server" Width="450px" Height="130px" ScrollBars="Auto">
                                    <asp:GridView ID="grdSupplierContact" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" Width="420px" SkinID="Unicodegrd" OnSelectedIndexChanged="grdSupplierContact_SelectedIndexChanged" OnRowDeleting="grdSupplierContact_RowDeleting" DataKeyNames = "SeqNo" OnRowDataBound="grdSupplierContact_RowDataBound">
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="SupplierID" HeaderText="SupplierID" />
                                            <asp:BoundField DataField="SeqNo" HeaderText="SeqNo" />
                                            <asp:BoundField DataField="ContactPerson" HeaderText="सम्पर्क बयक्ति">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ContactPhone" HeaderText="सम्पर्क न." />
                                            <asp:BoundField DataField="ContactEmail" HeaderText="ईमेल">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Action" HeaderText="Action" />
                                            <asp:CommandField ShowSelectButton="True">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:CommandField>
                                             <asp:CommandField ShowDeleteButton="True">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:CommandField>
                                        </Columns>
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <EditRowStyle BackColor="#999999" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    </asp:GridView>
                                </asp:Panel> </TD></TR></TBODY></TABLE><asp:Button id="btnSubmit" onclick="btnSubmit_Click" runat="server" Width="60px" Text="Submit" SkinID="Normal"></asp:Button> <asp:Button id="btnCancel" onclick="btnCancel_Click" runat="server" Width="60px" Text="Cancel" SkinID="Cancel"></asp:Button></TD></TR></TBODY></TABLE>
</contenttemplate>
    </asp:UpdatePanel><br />
    <br />
        
    </div>

</asp:Content>

