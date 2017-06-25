<%@ Page Language="C#" MasterPageFile="~/MODULES/COMMON/MasterPage.master" AutoEventWireup="true" CodeFile="Organization.aspx.cs" Inherits="Forms_Organization" Title="PMS | Organization" %>

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
    
  <%-- <script runat="server">txtOrgEmail.ClientID </script>--%>


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
                    <div style="padding: 10px; text-align: center">

            <asp:Panel runat="Server" ID="programmaticPopupDragHandle" Style="cursor: move;background-color:#DDDDDD;border:solid 1px Gray;color:Black;text-align:center;">
                Save Status
            </asp:Panel>
                        <asp:UpdatePanel id="UpdatePanel7" runat="server">
                            <contenttemplate>
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
</contenttemplate>
                        </asp:UpdatePanel>
<asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click" Width="58px" />           <br />
</div>
        </asp:Panel>
    <script language="javascript" type="text/javascript" src="../JS/Validation.js"></script>

    <script language="javascript" type="text/javascript" src="../JS/EmailValidator.js"></script>
    <script language="javascript" type="text/javascript">
        function ValidateEmailFR()
        {
            return ValidateEmail('<%=this.txtOrgEmail.ClientID %>');
        }
    </script>




<%--<script language="javascript">
    function textboxMultilineMaxNumber(txt,maxLen)
    {
        try{
            if(txt.value.length > (maxLen-1))return false;
           }catch(e){
        }
    }
</script>--%>
                




<div style="width:100%">
<table style="width: 100%" cellpadding="1" cellspacing="1">
    <tr>
        <td align="left" colspan="5" style="height: 21px; width:500px">
            <asp:Label ID="lblOrganization" runat="server" Text="Organization Information" Font-Bold="True" Width="236px" SkinID="UnicodeHeadlbl"></asp:Label>
            </td>
    </tr>
          <tr>
              <td align="left" rowspan="16" style="width: 150px" valign="top">
                    <asp:Label ID="lblOrgList" runat="server" Text="Organization List" Width="180px" Font-Bold="True" SkinID="Unicodelbl"></asp:Label><br />
                    <asp:ListBox ID="lstOrgList" runat="server" Height="400px" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="lstOrgList_SelectedIndexChanged" SkinID="Unicodelst"></asp:ListBox></td>
                <td style="width: 169px; height: 4px;">
                    <asp:Label ID="lblOrgName" runat="server" Text="Organization Name *" Height="13px" Width="169px" SkinID="Unicodelbl"></asp:Label></td>
              <td colspan="2" style="height: 4px">
                    <asp:TextBox ID="txtOrgName_Rqd" runat="server" Width="97%"  Height="16px" ToolTip="Organization Name" SkinID="Unicodetxt"></asp:TextBox>
                    </td>
          </tr>
                <tr>
                    <td style="width: 169px; height: 1px;" valign="top">
                        <asp:Label ID="lbOrgType" runat="server" Text="Type *" Width="59px" SkinID="Unicodelbl"></asp:Label></td>
                    <td style="width: 359px; height: 1px" valign="top">
                    <asp:DropDownList ID="ddlOrgType_Rqd" runat="server" Width="100%" ToolTip="Organization Type" OnSelectedIndexChanged="ddlOrgType_Rqd_SelectedIndexChanged" AutoPostBack="True" SkinID="Unicodeddl">
                    </asp:DropDownList></td>
                    <td style="width: 66px; height: 1px" valign="top">
                        <asp:Label ID="lblOrgSubType" runat="server" Text="Sub Type *" Width="77px" SkinID="Unicodelbl"></asp:Label></td>
                    <td style="width: 394px; height: 1px;" valign="top">
                        <asp:UpdatePanel id="UpdatePanel1" runat="server">
                            <contenttemplate>
<asp:DropDownList id="ddlOrgSubType_Rqd" runat="server" Width="99%" SkinID="Unicodeddl" OnSelectedIndexChanged="ddlOrgSubType_Rqd_SelectedIndexChanged" AutoPostBack="True" ToolTip="Organization Sub Type" AppendDataBoundItems="True"></asp:DropDownList> 
</contenttemplate>
                            <triggers>
<asp:AsyncPostBackTrigger ControlID="ddlOrgType_Rqd" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
                        </asp:UpdatePanel></td>
                </tr>
            <tr>
                <td style="width: 169px; height: 3px;" valign="top">
                        <asp:Label ID="lblOrgParent" runat="server" Text="Parent Organization" Width="103%" SkinID="Unicodelbl"></asp:Label></td>
                <td style="width: 359px; height: 3px;" valign="top">
                    <asp:UpdatePanel id="UpdatePanel2" runat="server">
                        <contenttemplate>
<asp:DropDownList id="ddlOrgParent" runat="server" Width="100%" SkinID="Unicodeddl" ToolTip="Parent Organization" AppendDataBoundItems="True"></asp:DropDownList> 
</contenttemplate>
                        <triggers>
<asp:AsyncPostBackTrigger ControlID="ddlOrgSubType_Rqd" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
                    </asp:UpdatePanel></td>
                <td style="width: 66px; height: 3px;" valign="top">
                    <asp:UpdatePanel id="UpdatePanel6" runat="server">
                        <contenttemplate>
<asp:Label id="lblCourtCode_Rqd" runat="server" Width="93px" SkinID="Unicodelbl" Text="Court Code *" Visible="False"></asp:Label> 
</contenttemplate>
                        <triggers>
<asp:AsyncPostBackTrigger ControlID="ddlOrgType_Rqd" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
                    </asp:UpdatePanel></td>
                <td style="width: 394px; height: 3px;" valign="top">
                    <asp:UpdatePanel id="UpdatePanel5" runat="server">
                        <contenttemplate>
<asp:TextBox id="txtCourtCode_Rqd" runat="server" Width="96%" Height="16px" SkinID="Unicodetxt" ToolTip="Organization Code" Visible="False"></asp:TextBox> 
</contenttemplate>
                        <triggers>
<asp:AsyncPostBackTrigger ControlID="ddlOrgType_Rqd" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
                    </asp:UpdatePanel></td>
            </tr>
    <tr>
        <td style="width: 169px; height: 5px;"></td>
        <td style="width: 66px; height: 5px;">
        </td>
    </tr>
    <tr>
        <td style="height: 29px" align="left" colspan="2" valign="top"><asp:Label ID="lblOrgAddress" runat="server" Text="Address " Font-Bold="True" Width="341px" SkinID="Unicodelbl"></asp:Label></td>
        <td style="width: 66px; height: 29px;" valign="top">
        </td>
        <td style="width: 394px; height: 29px" valign="top">
        </td>
    </tr>
    <tr>
        <td style="width: 169px; height: 8px" valign="top"><asp:Label ID="lblDistrict" runat="server" Text="District *" Width="62px" SkinID="Unicodelbl"></asp:Label></td>
        <td style="width: 359px; height: 8px"><asp:DropDownList ID="ddlOrgDistrict_Rqd" runat="server" Width="100%" ToolTip="Organization District" AutoPostBack="True" Font-Names="PCS NEPALI" OnSelectedIndexChanged="ddlOrgDistrict_Rqd_SelectedIndexChanged" SkinID="Unicodeddl">
        </asp:DropDownList></td>
        <td style="width: 66px; height: 8px" align="left"></td>
        <td style="width: 394px; height: 8px"></td>
    </tr>
    <tr>
        <td style="width: 169px;" valign="top">
            <asp:Label ID="lblVdcMun" runat="server" Text="VDC *" Width="80px" SkinID="Unicodelbl"></asp:Label></td>
        <td style="width: 359px;" valign="top">
            <asp:UpdatePanel id="UpdatePanel3" runat="server">
                <contenttemplate>
<asp:DropDownList id="ddlVdcMun_Rqd" runat="server" Width="100%" SkinID="Unicodeddl" Font-Names="PCS NEPALI" OnSelectedIndexChanged="ddlVdcMun_Rqd_SelectedIndexChanged" AutoPostBack="True" ToolTip="Organization VDC-Munciplity"></asp:DropDownList> 
</contenttemplate>
                <triggers>
<asp:AsyncPostBackTrigger ControlID="ddlOrgDistrict_Rqd" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
            </asp:UpdatePanel></td>
        <td align="left" style="width: 66px;">
            </td>
        <td style="width: 394px;">
            </td>
    </tr>
    <tr>
        <td style="width: 169px; height: 9px" valign="top">
            <asp:Label ID="lblWard" runat="server" Text="Ward *" Width="56px" SkinID="Unicodelbl"></asp:Label></td>
        <td style="width: 359px; height: 9px" valign="top">
            <asp:UpdatePanel id="UpdatePanel4" runat="server">
                <contenttemplate>
<asp:DropDownList id="ddlWard_Rqd" runat="server" Width="100%" SkinID="Unicodeddl" Font-Names="PCS NEPALI" ToolTip="Organization Ward" AppendDataBoundItems="True"></asp:DropDownList> 
</contenttemplate>
                <triggers>
<asp:AsyncPostBackTrigger ControlID="ddlVdcMun_Rqd" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
            </asp:UpdatePanel></td>
        <td align="left" style="width: 66px; height: 9px">
        </td>
        <td style="width: 394px; height: 9px">
        </td>
    </tr>
    <tr>
        <td style="width: 169px; height: 7px" valign="top">
            <asp:Label ID="lblAddress" runat="server" Text="Address *" Width="82px" SkinID="Unicodelbl"></asp:Label></td>
        <td colspan="2" style="height: 7px">
            <asp:TextBox ID="txtAddress_Rqd" runat="server" Height="16px" ToolTip="Organization Address"
                Width="97%" SkinID="Unicodetxt"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="width: 169px; height: 5px" valign="top">
            <asp:Label ID="lblStreet" runat="server" Text="Street" Width="81px" SkinID="Unicodelbl"></asp:Label></td>
        <td style="width: 359px; height: 5px">
            <asp:TextBox ID="txtStreet" runat="server" Height="16px" ToolTip="Organization Street"
                Width="97%" SkinID="Unicodetxt"></asp:TextBox></td>
        <td align="left" style="width: 66px; height: 5px">
        </td>
        <td style="width: 394px; height: 5px">
        </td>
    </tr>
    <tr>
        <td style="width: 169px; height: 9px" valign="top">
            <asp:Label ID="lblUrl" runat="server" Text="URL" Width="81px" SkinID="Unicodelbl"></asp:Label></td>
        <td style="width: 359px; height: 9px">
            <asp:TextBox ID="txtUrl" runat="server" Height="16px" ToolTip="Organization Name"
                Width="97%" SkinID="Unicodetxt"></asp:TextBox></td>
        <td align="left" style="width: 66px; height: 9px">
        </td>
        <td style="width: 394px; height: 9px">
        </td>
    </tr>
    <tr>
        <td style="width: 169px; height: 4px;" valign="top"><asp:Label ID="lblPhoneType" runat="server" Text="Phone Type" Width="86px" SkinID="Unicodelbl"></asp:Label></td>
        <td style="width: 359px; height: 4px;"><asp:DropDownList ID="ddlPhoneType" runat="server" Width="100%" ToolTip="Phone Type" Font-Names="Verdana" SkinID="Unicodeddl">
            <asp:ListItem Value="0">--Select Phone Type--</asp:ListItem>
            <asp:ListItem Value="M">Mobile</asp:ListItem>
            <asp:ListItem Value="R">Resident</asp:ListItem>
            <asp:ListItem Value="O">Office</asp:ListItem>
            <asp:ListItem Value="FX">Fax</asp:ListItem>
            <asp:ListItem Value="OT">Others</asp:ListItem>
        </asp:DropDownList></td>
        <td style="width: 66px; height: 4px;" align="left">
            <asp:Label ID="lblOrgPhone" runat="server" Text="Phone Number" Width="98px" SkinID="Unicodelbl"></asp:Label></td>
        <td style="width: 394px; height: 4px;">
            <asp:TextBox ID="txtOrgPhone" runat="server" Width="97%" ToolTip="Organization Phone" SkinID="Unicodetxt"></asp:TextBox></td>
        <td style="width: 300px; height: 4px;">
            <asp:Button ID="btnAddPhone" runat="server" Text="Add" OnClientClick="TellMeHello()" OnClick="btnAddPhone_Click" SkinID="Normal" /></td>
    </tr>
    <tr>
        <td style="width: 169px; height: 4px" valign="top">
        </td>
        <td align="left" colspan="2" style="height: 4px">
            <asp:GridView ID="grdPhone" runat="server" CellPadding="0" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnRowCreated="grdPhone_RowCreated" OnSelectedIndexChanged="grdPhone_SelectedIndexChanged" Width="300px" SkinID="Unicodegrd">
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <Columns>
                    <asp:BoundField DataField="Phone_Type" HeaderText="Phone Type" />
                    <asp:BoundField DataField="PhoneTypeID" HeaderText="PhoneTypeID" />
                    <asp:BoundField DataField="PHONE" HeaderText="Phone" />
                    <asp:BoundField DataField="ACTIVE" HeaderText="Active" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <EditRowStyle BackColor="#999999" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
        </td>
        <td style="width: 394px; height: 4px" valign="top">
            <asp:CheckBox ID="chkPhone" runat="server" Text ="Active" Width="160px" SkinID="smallChk"/></td>
        <td style="width: 300px; height: 4px">
        </td>
    </tr>
    <tr>
        <td style="width: 169px; height: 13px;" valign="top">
            <asp:Label ID="lblEmailType" runat="server" Text="Email Type" Width="79px" SkinID="Unicodelbl"></asp:Label></td>
        <td style="width: 359px; height: 13px;"><asp:DropDownList ID="ddlEmailType" runat="server" Width="100%" ToolTip="Email Type" Font-Names="Verdana" SkinID="Unicodeddl" >
            <asp:ListItem Value="0">--Select Email Type--</asp:ListItem>
            <asp:ListItem Value="P">Personal</asp:ListItem>
            <asp:ListItem Value="O">Office</asp:ListItem>
            <asp:ListItem Value="OT">Others</asp:ListItem>
        </asp:DropDownList></td>
        <td style="width: 66px; height: 13px;" align="left">
            <asp:Label ID="lblOrgEmail" runat="server" Text="Email Address" Width="99px" SkinID="Unicodelbl"></asp:Label></td>
        <td style="width: 394px; height: 13px;">
            <asp:TextBox ID="txtOrgEmail" runat="server" Width="97%" ToolTip="Organization Email" SkinID="Unicodetxt" ></asp:TextBox></td>
        <td style="width: 245px; height: 13px;">
            <asp:Button ID="btnAddEmail" runat="server" Text="Add" OnClick="btnAddEmail_Click" SkinID="Normal" /></td>
    </tr>
    <tr>
        <td style="width: 169px" valign="top">
        </td>
        <td align="left" colspan="2">
            <asp:GridView ID="grdEmail" runat="server" CellPadding="0" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnRowCreated="grdEmail_RowCreated" OnSelectedIndexChanged="grdEmail_SelectedIndexChanged" Width="300px" SkinID="Unicodegrd"  >
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <EditRowStyle BackColor="#999999" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="ETYPE" HeaderText="Email Type" />
                    <asp:BoundField DataField="EmailTypeID" HeaderText="EmailTypeID" />
                    <asp:BoundField DataField="EMAIL" HeaderText="Email" />
                    <asp:BoundField DataField="ACTIVE" HeaderText="Active" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </td>
        <td style="width: 394px" valign="top">
            <asp:CheckBox ID="chkEmail" Text="Active" runat="server" Width="155px" SkinID="smallChk" /></td>
        <td style="width: 245px">
        </td>
    </tr>
    <tr>
        <td style="width: 169px;">
        </td>
        <td colspan="2">
            &nbsp;</td>
        <td style="width: 394px;" valign="top">
            </td>
    </tr>
    <tr>
        <td align="left" rowspan="1" style="width: 150px" valign="top">
        </td>
        <td style="width: 169px;">
            </td>
        <td style="width: 359px;">
            <asp:Button ID="btnSave" runat="server" Text="Submit"  OnClick="btnSave_Click" OnClientClick="javascript:return validate();" Width="60px" SkinID="Normal" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" Width="60px" SkinID="Cancel" /></td>
        <td style="width: 66px;">
        </td>
        <td style="width: 394px;">
        </td>
    </tr>
        </table>
        </div>
</asp:Content>

