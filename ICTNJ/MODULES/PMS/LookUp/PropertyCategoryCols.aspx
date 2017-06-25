<%@ Page Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master" AutoEventWireup="true" CodeFile="PropertyCategoryCols.aspx.cs" Inherits="MODULES_PMS_LookUp_PropertyCategoryCols" Title="Untitled Page" %>
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
<div style=" width:100%;height:500px">
        <table width ="100%" cellpadding ="0"  cellspacing ="0" border ="0" style ="border-color:Red">
            <tr>
                <td align = "center">
                    <table width ="90%" cellpadding ="0"  cellspacing ="0" border ="0" style ="border-color:Red">
                        <tr>
                            <td style ="height:5px;"></td>
                        </tr>
                        <tr>
                            <td style="width: 242px" class="tblTDRight">
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Underline="True" Text="Property Category Columns"></asp:Label></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td style="width: 242px; height: 28px;" class="tblTDRight"></td>
                            <td style="height: 28px">
                                <asp:Label ID="lblStatus" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 242px; height: 32px;" class="tblTDRight">
                                <asp:Label ID="lblCategoryName" runat="server" Text="Category Name"></asp:Label></td>
                            <td style="width: 626px; height: 32px;" class="tblTDLeft">
                                <asp:DropDownList ID="dllPropCat" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dllPropCat_SelectedIndexChanged">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 242px" class="tblTDRight">
                                <asp:Label ID="lblColName" runat="server" Text="Column Name"></asp:Label></td>
                            <td style="width: 626px" class="tblTDLeft">
                                <asp:TextBox ID="txtColName" runat="server" Width="148px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 242px; height: 32px;" class="tblTDRight">
                                <asp:Label ID="lblColNo" runat="server" Text="Column No"></asp:Label></td>
                            <td style="width: 626px; height: 32px;" class="tblTDLeft">
                                <asp:DropDownList ID="dllColNo" runat="server" Width="154px">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 242px" class="tblTDRight">
                                <asp:Label ID="lblColDataType" runat="server" Text="Column Data Type"></asp:Label></td>
                            <td style="width: 626px" class="tblTDLeft">
                                <asp:DropDownList ID="dllColDType" runat="server" Width="154px">
                                    <asp:ListItem Value="0">Select DataType</asp:ListItem>
                                    <asp:ListItem Value="C">Character</asp:ListItem>
                                    <asp:ListItem Value="D">Decimal</asp:ListItem>
                                    <asp:ListItem Value="N">Numeric</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                       
                        <tr>
                            <td style="width: 242px; height: 22px" class="tblTDRight">
                                <asp:Label ID="lblActive" runat="server" Text="Active"></asp:Label></td>
                            <td style="width: 626px; height: 22px" class="tblTDLeft">
                            <asp:CheckBox ID="chkActive" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="width: 242px" class="tblTDRight">
                                </td>
                            <td style="width: 626px" class="tblTDLeft">
                               </td>
                        </tr>
                        <tr>
                            <td style="width: 242px; height: 24px;">
                            </td>
                             <td style="width: 626px; height: 24px;" class="tblTDLeft">
                                 <asp:Button ID="btnAdd" runat="server" CssClass="tblRight" Text="Add" Width="50px" OnClick="btnAdd_Click" SkinID="Add" />
                                 <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Submit" Visible="False"
                                     Width="74px" SkinID="Normal" /></td>
                        </tr>
                        <tr>
                            <td style ="height:5px;"></td>
                        </tr>
                         <tr>
                            <td style="width: 242px; height: 24px;">
                            </td>
                             <td style="width: 626px; height: 24px;" class="tblTDLeft">
                            <asp:GridView ID="grdPropCatCols" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <EditRowStyle BackColor="#999999" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No">
                                    <ItemStyle Width="5px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

                                    <HeaderStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                    <ItemTemplate>
                                         <%# Container.DataItemIndex + 1 %> 
                                    </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ColName" HeaderText="Column Name" >
                                        <ItemStyle Width="20%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ColNo" HeaderText="Column No" >
                                        <ItemStyle Width="17%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ColDataType" HeaderText="Data Type" >
                                        <ItemStyle Width="12%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Active" HeaderText="Active" >
                                        <ItemStyle Width="12%" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                        </tr>
                        
                    </table>
                </td>
            </tr>
             <tr>
                <td style ="height:5px;"></td>
            </tr>
        </table>
  </div>
</asp:Content>

