<%@ Page Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master" AutoEventWireup="true" CodeFile="PropertyCategory.aspx.cs" Inherits="MODULES_PMS_LookUp_PropertyCategory" Title="Property Category" %>
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

 <script language="javascript" type="text/javascript" src="../../COMMON/JS/Validation.js"></script>
  <script language="javascript" type="text/javascript" src="../../COMMON/JS/DateValidator.js"></script>

 <div style=" width:100%;height:400px">
        <table width ="100%" cellpadding ="0"  cellspacing ="0" border ="0" style ="border-color:Red">
            <tr>
                <td align = "center">
                    <table width ="90%" cellpadding ="0"  cellspacing ="0" border ="0" style ="border-color:Red">
                        <tr>
                            <td style="height:5px; width: 273px;"></td>
                        </tr>
                        <tr>
                            <td style="width: 273px" class="tblTDRight">
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Underline="True" Text="Property Cateogry"></asp:Label></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td style="width: 273px" class="tblTDRight"></td>
                            <td>
                                <asp:Label ID="lblStatus" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 273px; height: 30px;" class="tblTDRight">
                                <asp:Label ID="lblCategoryName" runat="server" Text="Category Name"></asp:Label></td>
                            <td style="width: 626px; height: 30px;" class="tblTDLeft">
                                <asp:TextBox ID="txtCatName" runat="server" MaxLength="50" Width="258px"></asp:TextBox></td>
                        </tr>
                            <tr>
                            <td style="width: 273px; height: 19px" class="tblTDRight">
                                <asp:Label ID="lblNoOfCols" runat="server" Text="No Of Columns"></asp:Label></td>
                            <td style="width: 626px; height: 19px" class="tblTDLeft">
                                <asp:DropDownList ID="dllNoOfCols" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dllNoOfCols_SelectedIndexChanged" Width="67px">
                                    <asp:ListItem Value="-1">छान्नुहोस्</asp:ListItem>
                                    <asp:ListItem>0</asp:ListItem>
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                                    <asp:ListItem>6</asp:ListItem>
                                    <asp:ListItem>7</asp:ListItem>
                                    <asp:ListItem>8</asp:ListItem>
                                    <asp:ListItem>9</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem Value="11"></asp:ListItem>
                                    <asp:ListItem>12</asp:ListItem>
                                    <asp:ListItem>13</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                            <tr>
                            <td style="width: 273px; height: 22px" class="tblTDRight">
                                <asp:Label ID="lblActive" runat="server" Text="Active"></asp:Label></td>
                            <td style="width: 626px; height: 22px" class="tblTDLeft">
                                <asp:CheckBox ID="chkActive" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="width: 273px" class="tblTDRight">
                                <asp:Label ID="Label4" runat="server" Text="Income"></asp:Label></td>
                            <td style="width: 626px" class="tblTDLeft">
                               <asp:CheckBox ID="chkIncome" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="tblTDRight" style="width: 273px">
                                <asp:Label ID="Type" runat="server" Text="Type"></asp:Label></td>
                            <td class="tblTDLeft" style="width: 626px">
                                &nbsp;<asp:DropDownList ID="dllType" runat="server" Width="142px">
                                    <asp:ListItem Value="0">छान्नुहोस्</asp:ListItem>
                                    <asp:ListItem Value="J">न्यायदिश</asp:ListItem>
                                    <asp:ListItem Value="L">वकिल</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td class="tblTDRight" style="width: 273px">
                                <asp:Label ID="lblMasterType" runat="server" Text="Master Type"></asp:Label></td>
                            <td class="tblTDLeft" style="width: 626px">
                                &nbsp;<asp:DropDownList ID="dllMasterType" runat="server" Width="142px">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                    <asp:ListItem Value="1">Current</asp:ListItem>
                                    <asp:ListItem Value="2">Fixed</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 273px; height: 24px;">
                            </td>
                             <td style="width: 626px; height: 24px;" class="tblTDLeft">
                                 <asp:Button ID="btnAdd" runat="server" CssClass="tblRight" Text="Add" Width="50px" OnClick="btnAdd_Click" SkinID="Add" />
                                 <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Submit" Visible="False"
                                     Width="74px" SkinID="Normal" /></td>
                        </tr>
                        <tr>
                            <td style="height:5px; width: 273px;"></td>
                        </tr>
                         <tr>
                            <td style="width: 273px; height: 24px;">
                            </td>
                             <td style="width: 626px; height: 24px;" class="tblTDLeft">
                            <asp:GridView ID="grdPropCat" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
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
                                    <asp:BoundField DataField="PCategoryName" HeaderText="Category Name" >
                                        <ItemStyle Width="20%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NoOfCols" HeaderText="Total Columns" >
                                        <ItemStyle Width="17%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Active" HeaderText="Active" >
                                        <ItemStyle Width="12%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Income" HeaderText="Income" >
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

