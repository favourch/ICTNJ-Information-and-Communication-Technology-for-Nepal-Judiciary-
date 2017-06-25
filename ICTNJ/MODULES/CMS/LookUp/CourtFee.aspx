<%@ Page Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" AutoEventWireup="true" CodeFile="CourtFee.aspx.cs" Inherits="MODULES_CMS_LookUp_CourtFee" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

 <script runat="server">

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
    </script>
    
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
    <ajaxtoolkit:modalpopupextender id="programmaticModalPopup" runat="server" backgroundcssclass="modalBackground"
        behaviorid="programmaticModalPopupBehavior" dropshadow="True" popupcontrolid="programmaticPopup"
        popupdraghandlecontrolid="programmaticPopupDragHandle" repositionmode="RepositionOnWindowScroll"
        targetcontrolid="hiddenTargetControlForModalPopup">
        </ajaxtoolkit:modalpopupextender>
    <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none;
        width: 350px; padding: 10px">
        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD;
            border: solid 1px Gray; color: Black; text-align: center;">
            Save Status
        </asp:Panel>
        <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label><br />
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
            Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    <table style="width: 885px">
        <tr>
            <td style="width: 100px; height: 21px">
                <asp:GridView ID="grdCourtFee" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None" OnRowDataBound="grdCourtFee_RowDataBound"
                    ShowHeader="False" OnRowCreated="grdCourtFee_RowCreated" OnSelectedIndexChanged="grdCourtFee_SelectedIndexChanged" OnPreRender="grdCourtFee_PreRender" OnDataBound="grdCourtFee_DataBound" ShowFooter="True">
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblSNo" runat="server" Text="SNo" BackColor="#C0C0FF" Width="50px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemStyle Wrap="False" />
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" SkinID="Unicodelbl" Text="रुपैंयाँ"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                &nbsp;
                                <asp:TextBox ID="txtFromAmount" runat="server" Columns="14" MaxLength="12" SkinID="Unicodetxt" Text='<%# Eval("FromAmount") %>' ></asp:TextBox>
                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetCourtFee"
                                    TypeName="PCS.CMS.BLL.BLLCourtFee">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="0" Name="defaultFlag" Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemStyle Wrap="False" />
                            <ItemTemplate>
                                <asp:Label ID="Label7" runat="server" SkinID="Unicodelbl" Text="देखि रुपैयाँ "></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                &nbsp;<asp:TextBox ID="txtAmountTo" runat="server" Columns="14" MaxLength="12" SkinID="Unicodetxt" Text='<%# Eval("ToAmount") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemStyle Wrap="False" />
                            <ItemTemplate>
                                <asp:Label ID="Label8" runat="server" SkinID="Unicodelbl" Text="सम्मका लागि"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:TextBox ID="txtFee" runat="server" Columns="14" MaxLength="12" SkinID="Unicodetxt" Text='<%# Eval("AmtPer") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlAmtPerType" runat="server" SkinID="Unicodeddl" Width="80px" SelectedValue='<%# Eval("AmtPerType") %>'>
                                    <asp:ListItem Value="0">छान्नहोस</asp:ListItem>
                                    <asp:ListItem Value="F">रुपैयाँ</asp:ListItem>
                                    <asp:ListItem Value="P">प्रतिशत</asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                            <FooterTemplate>
                                &nbsp;
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                &nbsp;
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Button ID="btnAdd" runat="server" SkinID="Add" Text="+" OnClick="btnAdd_Click" />
                                <asp:Button ID="btnMinus" runat="server" OnClick="btnMinus_Click" SkinID="Add" Text="-" />
                            </FooterTemplate>
                            <FooterStyle Wrap="False" />
                            
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle BackColor="#EFF3FB" />
                    <EditRowStyle BackColor="#2461BF" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <table>
                    <tr>
                        <td style="width: 100px">
                            <asp:Button ID="btnSubmit" runat="server" SkinID="Normal" Text="Submit" OnClick="btnSubmit_Click" /></td>
                        <td style="width: 100px">
                            &nbsp;<asp:Button ID="btnCancel" runat="server" SkinID="Cancel" Text="Cancel" OnClick="btnCancel_Click" /></td>
                    </tr>
                </table>
                </td>
        </tr>
    </table>
    
    
    
    </asp:Content>

