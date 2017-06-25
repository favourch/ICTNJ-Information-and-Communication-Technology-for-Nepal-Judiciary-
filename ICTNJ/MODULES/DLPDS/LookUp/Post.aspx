<%@ Page Language="C#" MasterPageFile="~/MODULES/DLPDS/DLPDSMasterPage.master" AutoEventWireup="true" CodeFile="Post.aspx.cs" Inherits="MODULES_DLPDS_LookUp_Post" Title="DLPDS | Post/Post Level" %>

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
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label><br />
<asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click" Width="58px" />           <br />
        </asp:Panel>  
    <table style="width: 737px">
        <tr>
            <td style="width: 149px; height: 21px;">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Post List"></asp:Label></td>
            <td style="width: 252px; height: 21px;">
            </td>
        </tr>
        <tr>
            <td style="width: 149px">
                    <asp:ListBox ID="lstPost" runat="server" AutoPostBack="True" Width="200px" Height="250px" OnSelectedIndexChanged="lstPost_SelectedIndexChanged"></asp:ListBox></td>
            <td style="width: 252px" valign="top">
                <table style="width: 556px">
                    <tr>
                        <td>
                    <asp:Label ID="lblPostName" runat="server" Text="Post Name" Width="74px"></asp:Label></td>
                        <td>
                    <asp:TextBox ID="txtPostName_Rqd" runat="server" Width="213px" ToolTip="Post Name"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                    <asp:Label ID="lblPostLevel" runat="server" Text="Post Level" Width="75px"></asp:Label></td>
                        <td>
                    <asp:TextBox ID="txtPostLevelName" runat="server" Width="212px"></asp:TextBox>
                            <asp:Button ID="btnAddPostLevel" runat="server" Text="+" Font-Bold="True" OnClick="btnAddPostLevel_Click" Width="30px" /></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Panel ID="Panel1" runat="server" Height="150px" ScrollBars="Auto" Width="100%">
                    <asp:GridView ID="grdPostLevel" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        ForeColor="#333333" GridLines="None" Width="500px" OnRowDeleting="grdPostLevel_RowDeleting" OnSelectedIndexChanged="grdPostLevel_SelectedIndexChanged" OnRowCreated="grdPostLevel_RowCreated">
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="PostID" HeaderText="Post  ID" />
                            <asp:BoundField DataField="PostLevelID" HeaderText="Post Level ID" />
                            <asp:BoundField DataField="PostLevelName" HeaderText="Post Level Name" />
                            <asp:BoundField DataField="Flag" HeaderText="Flag" />
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:CommandField ShowDeleteButton="True" />
                        </Columns>
                        <RowStyle BackColor="#EFF3FB" />
                        <EditRowStyle BackColor="#2461BF" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" OnClientClick="javascript:return validate();"/><asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" /></td>
                        <td style="height: 15px">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
         
    <br />
    <div style="text-align: left">
                    &nbsp;</div>

</asp:Content>

