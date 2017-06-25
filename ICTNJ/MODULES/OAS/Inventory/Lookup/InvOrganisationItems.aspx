<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true"
    CodeFile="InvOrganisationItems.aspx.cs" Inherits="MODULES_OAS_Inventory_LookUp_InvOrganisationItems"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager id="scriptMNGR" runat="server">
    </asp:ScriptManager>
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
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>&nbsp;</asp:Panel>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <contenttemplate>
<asp:Label id="lblStatusMessage" runat="server" Text="Label"></asp:Label> 
</contenttemplate>
            <triggers>
<asp:AsyncPostBackTrigger ControlID="OkButton" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
        </asp:UpdatePanel>
        <br />
        <asp:Button ID="OkButton" runat="server" Text="OK" Width="58px" OnClientClick="javascript:$find('programmaticModalPopupBehavior').hide();"
            OnClick="hideModalPopupViaServer_Click" /></asp:Panel>
    <div style="min-height: 400px; height: 400px; width:100%; margin-left:auto;margin-right:auto" >
       <asp:UpdatePanel id="UpdatePanel1" runat="server">
       <contenttemplate>
<TABLE width=1000>
<TBODY><TR><TD style="WIDTH: 62px" vAlign=top><asp:Label id="lblStatus" runat="server" Text="समुह" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 50px" vAlign=top><asp:DropDownList id="DDLItemCategory" runat="server" Width="230px" SkinID="Unicodeddl" AutoPostBack="True" OnSelectedIndexChanged="DDLItemCategory_SelectedIndexChanged"></asp:DropDownList></TD><TD style="WIDTH: 50px"></TD><TD vAlign=top><asp:Label id="Label2" runat="server" Text="उपसमुह" SkinID="Unicodelbl" __designer:wfdid="w9"></asp:Label></TD><TD style="WIDTH: 200px"><TABLE><TBODY><TR><TD style="WIDTH: 100px"><asp:DropDownList id="ddlSubCategory" runat="server" Width="230px" SkinID="Unicodeddl" __designer:wfdid="w10" DataTextField="ItemsSubCategoryName" DataValueField="ItemsSubCategoryID">
                   </asp:DropDownList></TD><TD style="WIDTH: 50px"></TD><TD style="WIDTH: 100px"><asp:Button id="btnSearch" onclick="btnSearch_Click" runat="server" Text="खोज्नुहोस्" SkinID="Normal"></asp:Button></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="WIDTH: 62px"></TD><TD style="HEIGHT: 26px"></TD><TD style="WIDTH: 200px; HEIGHT: 26px"></TD><TD></TD><TD style="WIDTH: 600px; HEIGHT: 26px"></TD></TR><TR><TD colSpan=5><asp:GridView id="grdInvOrgItems" runat="server" OnRowDataBound="grdInvOrgItems_RowDataBound" AutoGenerateColumns="False">
        <HeaderStyle HorizontalAlign="Center" />
                    
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkItems" AutoPostBack="True"  OnCheckedChanged="chkItems_CheckedChanged"  runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ItemsCategoryID" HeaderText="Items Category Id" />
                        <asp:BoundField DataField="ItemsSubCategoryId" HeaderText="Items SubCategory Id" />
                        <asp:BoundField DataField="ItemsID" HeaderText="Items ID" />
                        <asp:BoundField DataField="ItemsShortName" HeaderText="Items Short Name" />
                        <asp:BoundField DataField="ItemsName" HeaderText="नाम" />
                        <asp:BoundField DataField="ItemsTypeID" HeaderText="Items Type ID" />
                        <asp:BoundField DataField="ItemsUnitID" HeaderText="Items Unit ID" />
                        <asp:BoundField DataField="IssuedTo" HeaderText="Issued To" />
                        <asp:BoundField HeaderText="PrevState" />
                        <asp:TemplateField HeaderText="जी.खा.पा.नं">                            
                            <ItemTemplate>
                                <asp:TextBox ID="txtJiKhaPaNo"   runat="server" MaxLength="15" Height="15px" Width="125px"></asp:TextBox>                                
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="जी.खा.पा.नं" />
                    </Columns>
                </asp:GridView> </TD></TR><TR><TD style="WIDTH: 62px"><asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Text="Save" SkinID="Normal"></asp:Button></TD><TD></TD><TD></TD><TD></TD><TD style="WIDTH: 200px"></TD></TR></TBODY></TABLE>
</contenttemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
