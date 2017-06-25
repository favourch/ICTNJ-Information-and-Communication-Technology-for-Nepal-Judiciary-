<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrganizationInfo.aspx.cs" Inherits="MODULES_CMS_Forms_OrganizationInfo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<script runat="server">

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
        
        
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body onunload="PassValues()">
   

        <script language="javascript" type="text/javascript">

function PassValues()
{
    window.opener.document.forms(0).submit();
    self.close();
}
        </script>

        <form id="form1" runat="server">
            <div>
            
             <asp:ScriptManager ID="ScriptManager1" runat="server">
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
            Status
        </asp:Panel>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
        <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
            </ContentTemplate></asp:UpdatePanel>
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
            Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    
    
    
        <table cellspacing="5" style="width: 1000px">
            <tr>
                <td colspan="6" valign="top">
                    <asp:Label ID="lblPersonnelInfo" runat="server" Font-Bold="True" SkinID="UnicodeHeadlbl"
                        Text="वैयक्तिक विवरण"></asp:Label></td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:Label ID="Label1" runat="server" Height="22px" SkinID="Unicodelbl" Text="संस्थाको नाम"
                        Width="110px"></asp:Label></td>
                <td valign="top" colspan="3">
                    <asp:TextBox ID="txtOrgName_RQD" runat="server" MaxLength="100" SkinID="Unicodetxt"
                        ToolTip="पहिलो नाम" Width="607px" Columns="102"></asp:TextBox>
                    <asp:TextBox ID="txtOrgID" runat="server" Visible="False"></asp:TextBox></td>
                <td valign="top">
                    </td>
                <td valign="top">
                    </td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:Label ID="Label2" runat="server" Text="रेजिष्ट्रेशन नं" SkinID="Unicodelbl"></asp:Label></td>
                <td valign="top">
                    <asp:TextBox ID="txtRegNo" runat="server"></asp:TextBox></td>
                <td valign="top">
                    <asp:Label ID="Label3" runat="server" Text="प्यान नं" SkinID="Unicodelbl"></asp:Label></td>
                <td valign="top">
                    <asp:TextBox ID="txtPanNo" runat="server"></asp:TextBox></td>
                <td valign="top">
                    <asp:Label ID="Label4" runat="server" Text="संस्थाको किसिम" Width="121px" SkinID="Unicodelbl"></asp:Label></td>
                <td valign="top">
                    <asp:DropDownList ID="ddlOrgType" runat="server">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="6" valign="top">
                    <hr />
                    &nbsp;<asp:Label ID="Label26" runat="server" Font-Bold="True" SkinID="Unicodelbl" Text="ठेगाना"></asp:Label></td>
            </tr>
            <tr>
                <td valign="top">
                                                                <asp:Label ID="Label82" runat="server" Height="19px" SkinID="Unicodelbl" Text="जिल्ला"
                                                                    Width="50px"></asp:Label></td>
                <td valign="top">
                                                                <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"
                                                                    SkinID="Unicodeddl" Width="150px">
                                                                </asp:DropDownList></td>
                <td valign="top">
                                                                <asp:Label ID="Label84" runat="server" Height="19px" SkinID="Unicodelbl" Text="गा.बि.स./न.पा."
                                                                    Width="95px"></asp:Label></td>
                <td valign="top">
                                                                <asp:DropDownList ID="ddlVDC" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlVDC_SelectedIndexChanged"
                                                                    SkinID="Unicodeddl" Width="150px">
                                                                </asp:DropDownList></td>
                <td valign="top">
                                                                <asp:Label ID="Label15" runat="server" Height="19px" SkinID="Unicodelbl" Text="वडा नं."
                                                                    Width="50px"></asp:Label></td>
                <td valign="top">
                                                                <asp:DropDownList ID="ddlWard" runat="server" AppendDataBoundItems="True" SkinID="Unicodeddl"
                                                                    Width="70px" OnSelectedIndexChanged="ddlWard_SelectedIndexChanged">
                                                                </asp:DropDownList></td>
            </tr>
            <tr>
                <td valign="top">
                                                                <asp:Label ID="Label83" runat="server" Height="19px" SkinID="Unicodelbl" Text="टोल"></asp:Label></td>
                <td valign="top">
                                                                <asp:TextBox ID="txtTole" runat="server" MaxLength="100" SkinID="Unicodetxt" TextMode="MultiLine"
                                                                    Width="150px"></asp:TextBox></td>
                <td valign="top">
                                                                <asp:ImageButton ID="imgDelPerAddress" runat="server" AlternateText="Delete This Address"
                                                                    ImageUrl="~/MODULES/COMMON/Images/bycat1.ico" OnClick="imgDelPerAddress_Click"
                                                                    OnClientClick="return confirm('यो ठेगाना हटाउने हो ?')" Visible="False" /></td>
                <td valign="top">
                </td>
                <td valign="top">
                </td>
                <td valign="top">
                </td>
            </tr>
            <tr>
                <td colspan="6" valign="top">
                    <hr />
                    &nbsp;<asp:Label ID="Label13" runat="server" Font-Bold="True" Height="19px" SkinID="Unicodelbl"
                                                                    Text="फोन" Width="105px"></asp:Label></td>
            </tr>
            <tr>
                <td valign="top">
                                                                <asp:Label ID="Label18" runat="server" Height="19px" SkinID="Unicodelbl" Text="फोनको किसिम"
                                                                    Width="105px"></asp:Label></td>
                <td valign="top">
                                                                <asp:DropDownList ID="ddlPhoneType_Phone" runat="server" SkinID="Unicodeddl" ToolTip="फोनको किसिम"
                                                                    Width="135px">
                                                                    <asp:ListItem Value="N">छान्नुहोस</asp:ListItem>
                                                                    <asp:ListItem Value="M">मोबाईल</asp:ListItem>
                                                                    <asp:ListItem Value="O">अफिस</asp:ListItem>
                                                                    <asp:ListItem Value="R">घर</asp:ListItem>
                                                                    <asp:ListItem Value="OT">अन्य</asp:ListItem>
                                                                </asp:DropDownList></td>
                <td valign="top">
                                                                <asp:Label ID="Label19" runat="server" Height="19px" SkinID="Unicodelbl" Text="फोन न."
                                                                    Width="55px"></asp:Label></td>
                <td valign="top">
                                                                <asp:TextBox ID="txtPhoneNumber_Phone" runat="server" MaxLength="15" SkinID="Unicodetxt"
                                                                    ToolTip="फोन नं" Width="130px"></asp:TextBox>
                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                                    FilterType="Numbers" TargetControlID="txtPhoneNumber_Phone">
                                                                </ajaxToolkit:FilteredTextBoxExtender>
                </td>
                <td valign="top">
                                                                <asp:Button ID="btnPhonePlus" runat="server" OnClick="btnPhonePlus_Click" OnClientClick="javascript:return validateUpanelFields('_Phone',0);"
                                                                    SkinID="Add" Text="+" /></td>
                <td valign="top">
                </td>
            </tr>
            <tr>
                <td colspan="4" valign="top">
                                                                <asp:GridView ID="grdPhone" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                    ForeColor="#333333" GridLines="None" OnRowDataBound="grdPhone_RowDataBound" OnRowDeleting="grdPhone_RowDeleting"
                                                                    OnSelectedIndexChanged="grdPhone_SelectedIndexChanged" SkinID="Unicodegrd">
                                                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                    <Columns>
                                                                        <asp:BoundField DataField="PID" HeaderText="PersonID" />
                                                                        <asp:BoundField DataField="PTYPE" HeaderText="Phone Type" />
                                                                        <asp:BoundField DataField="PHONETYPE" HeaderText="फोनको किसिम">
                                                                            <ItemStyle Width="100px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="PSNO" HeaderText="PSNo" />
                                                                        <asp:BoundField DataField="PHONE" HeaderText="फोन नं.">
                                                                            <ItemStyle Width="200px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="ACTIVE" HeaderText="Active" />
                                                                        <asp:BoundField DataField="REMARKS" HeaderText="कैफियत" />
                                                                        <asp:BoundField DataField="ACTION" HeaderText="Action" />
                                                                        <asp:CommandField ShowSelectButton="True">
                                                                            <ItemStyle Font-Names="Verdana" Width="50px" />
                                                                        </asp:CommandField>
                                                                        <asp:CommandField ShowDeleteButton="True">
                                                                            <ItemStyle Font-Names="Verdana" Width="50px" />
                                                                        </asp:CommandField>
                                                                    </Columns>
                                                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                                    <EditRowStyle BackColor="#999999" />
                                                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                </asp:GridView>
                </td>
                <td valign="top">
                </td>
                <td valign="top">
                </td>
            </tr>
            <tr>
                <td colspan="6" valign="top">
                    <hr />
                    &nbsp;<asp:Label ID="LabelEmail" runat="server" Font-Bold="True" Height="19px" SkinID="Unicodelbl"
                                                                    Text="इमेल" Width="105px"></asp:Label></td>
            </tr>
            <tr>
                <td valign="top">
                                                                <asp:Label ID="Label23" runat="server" Height="19px" SkinID="Unicodelbl" Text="ईमेलको किसिम"
                                                                    Width="105px"></asp:Label></td>
                <td valign="top">
                                                                <asp:DropDownList ID="ddlEMailType_EMail" runat="server" SkinID="Unicodeddl" ToolTip="इमेलको किसिम"
                                                                    Width="135px">
                                                                    <asp:ListItem Value="N">छान्नुहोस</asp:ListItem>
                                                                    <asp:ListItem Value="P">ब्यक्तिगत</asp:ListItem>
                                                                    <asp:ListItem Value="O">अफिस</asp:ListItem>
                                                                    <asp:ListItem Value="OT">अन्य</asp:ListItem>
                                                                </asp:DropDownList></td>
                <td valign="top">
                                                                <asp:Label ID="Label24" runat="server" Height="19px" SkinID="Unicodelbl" Text="ईमेल ठेगाना"
                                                                    Width="90px"></asp:Label></td>
                <td valign="top">
                                                                <asp:TextBox ID="txtEMail_EMail" runat="server" MaxLength="50" SkinID="Unicodetxt"
                                                                    ToolTip="इमेल ठेगाना" Width="130px"></asp:TextBox></td>
                <td valign="top">
                                                                <asp:Button ID="btnEMailPlus" runat="server" OnClick="btnEMailPlus_Click" OnClientClick="javascript:return ValidateEmailFR();"
                                                                    SkinID="Add" Text="+" /></td>
                <td valign="top">
                </td>
            </tr>
            <tr>
                <td colspan="4" valign="top">
                                                                <asp:GridView ID="grdEMail" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                    ForeColor="#333333" GridLines="None" OnRowDataBound="grdEMail_RowDataBound" OnRowDeleting="grdEMail_RowDeleting"
                                                                    OnSelectedIndexChanged="grdEMail_SelectedIndexChanged" SkinID="Unicodegrd">
                                                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                    <Columns>
                                                                        <asp:BoundField DataField="PID" HeaderText="PersonID" />
                                                                        <asp:BoundField DataField="ETYPE" HeaderText="EMail Type" />
                                                                        <asp:BoundField DataField="EMAILTYPE" HeaderText="ईमेलको किसिम">
                                                                            <ItemStyle Width="100px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="ESNO" HeaderText="ESNo" />
                                                                        <asp:BoundField DataField="EMAIL" HeaderText="ईमेल ठेगाना">
                                                                            <ItemStyle Font-Names="Verdana" Width="200px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="ACTIVE" HeaderText="Active" />
                                                                        <asp:BoundField DataField="REMARKS" HeaderText="कैफियत" />
                                                                        <asp:BoundField DataField="ACTION" HeaderText="Action" />
                                                                        <asp:CommandField ShowSelectButton="True">
                                                                            <ItemStyle Font-Names="Verdana" Width="50px" />
                                                                        </asp:CommandField>
                                                                        <asp:CommandField ShowDeleteButton="True">
                                                                            <ItemStyle Font-Names="Verdana" Width="50px" />
                                                                        </asp:CommandField>
                                                                    </Columns>
                                                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                                    <EditRowStyle BackColor="#999999" />
                                                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                </asp:GridView>
                </td>
                <td valign="top">
                </td>
                <td valign="top">
                </td>
            </tr>
            <tr>
                <td colspan="6" valign="top">
                    <hr />
                    &nbsp;</td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:Button ID="btnAddPerson" runat="server" OnClick="btnAddPerson_Click" SkinID="Add"
                        Text="+" /></td>
                <td colspan="5" valign="top">
                </td>
            </tr>
            <tr>
                <td colspan="4" valign="top">
                    <asp:UpdatePanel ID="upnlPerson" runat="server">
                        <ContentTemplate>
                    <asp:GridView ID="grdPerson" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        ForeColor="#333333" GridLines="None" Width="500px">
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <RowStyle BackColor="#EFF3FB" />
                        <EditRowStyle BackColor="#2461BF" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField HeaderText="PID" DataField="PId" />
                            <asp:BoundField DataField="FullName" HeaderText="संस्थाको नाम" >
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="RegdNo" HeaderText="रेजिष्ट्रेशन नं" />
                            <asp:BoundField DataField="PanNo" HeaderText="प्यान नं" />
                            <asp:BoundField DataField="EntityTypeName" HeaderText="व्यक्ति वा संस्था" />
                        </Columns>
                    </asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnAddPerson" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                <td valign="top">
                </td>
                <td valign="top">
                </td>
            </tr>
            <tr>
                <td valign="top">
                </td>
                <td valign="top">
                </td>
                <td valign="top">
                </td>
                <td valign="top">
                </td>
                <td valign="top">
                </td>
                <td valign="top">
                </td>
            </tr>
            <tr>
                <td style="height: 21px" valign="top">
                </td>
                <td style="height: 21px" valign="top">
                </td>
                <td style="height: 21px" valign="top">
                </td>
                <td style="height: 21px" valign="top">
                </td>
                <td style="height: 21px" valign="top">
                </td>
                <td style="height: 21px" valign="top">
                </td>
            </tr>
            <tr>
                <td align="right" colspan="6" valign="top">
                    <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" OnClientClick="javascript:return validate(1);"
                        SkinID="Normal" Text="Submit" />
                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" SkinID="Cancel"
                        Text="Cancel" />&nbsp;</td>
            </tr>
        </table>
            
            </div>
        </form>
  
</body>
</html>
