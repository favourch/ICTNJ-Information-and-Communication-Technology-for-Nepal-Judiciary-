<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true"
    CodeFile="EmployeeDeputationTransferWork.aspx.cs" Inherits="MODULES_PMS_Forms_EmployeeDeputationTransferWork"
    Title="OAS | Employee Deputation Transfer Work" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server" >

    <script type="text/javascript" src="../../COMMON/JS/jquery.min.js"></script>

    <script type="text/javascript" src="../../COMMON/JS/scrolltopcontrol.js"></script>

    <script language="javascript" src="../../COMMON/JS/DateValidator.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript" defer="defer">
    
    function validateAppDate()
    
    {
     var date1='<%=txtAppdate_DT.ClientID%>';
        if(validateDateByControl(date1, true)==false)
        {
            return false;
        
        return true;
        
    }
    
    
    
    </script>

    <%--<script language="javascript" type="text/javascript" defer="defer">
    function validateTab1()
    {
        var date1='<%= this.txtRetirementAppDate.ClientID%>';
        if(validateDateByControl(date1, true)==false)
        {
            return false;
        }
        return true;
    }
    function validateTab2()
    {
        var date2='<%= this.txtDecDate.ClientID%>';
        if(validateDateByControl(date2, true)==false)
        {
            return false;
        }
        return true;
    }
    function validateTab3()
    {
        var date3='<%= this.txtApprDate.ClientID%>';
        if(validateDateByControl(date3, true)==false)
        {
            return false;
        }
        return true;
    }
    </script>--%>
    <div style="height:500px">
    <asp:ScriptManager runat="server" ID="sct">
    </asp:ScriptManager>
    <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="programmaticModalPopup" BehaviorID="programmaticModalPopupBehavior"
        TargetControlID="hiddenTargetControlForModalPopup" PopupControlID="programmaticPopup"
        BackgroundCssClass="modalBackground" DropShadow="True" PopupDragHandleControlID="programmaticPopupDragHandle"
        RepositionMode="RepositionOnWindowScroll">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel runat="server" CssClass="modalPopup" ID="programmaticPopup" Style="display: none;
        width: 350px; padding: 10px">
        <asp:Panel runat="Server" ID="programmaticPopupDragHandle" Style="cursor: move; background-color: #DDDDDD;
            border: solid 1px Gray; color: Black; text-align: center;">
            Save Status
        </asp:Panel>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click"
            Width="58px" />
        <br />
    </asp:Panel>
    <%--<asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>

    <asp:Panel id="Panel1" runat="server" Width="900px" Height="50px">--%>
    <asp:Label ID="lblStatus" runat="server" Font-Bold="True" SkinID="Unicodelbl"></asp:Label>
    <table width="900">
        <tbody>
            <tr>
                <td style="width: 126px; height: 26px">
                    <asp:Label ID="Label1" runat="server" Width="92px" Height="22px" Text=" नाम" SkinID="Unicodelbl">
                    </asp:Label></td>
                <td style="height: 26px">
                    <asp:TextBox ID="txtName" runat="server" Width="130px" SkinID="Unicodetxt" MaxLength="35"
                        ToolTip=" Name" ReadOnly="True"></asp:TextBox></td>
                <td style="height: 26px">
                    <asp:Label ID="Label2" runat="server" Width="137px" Height="22px" Text="वर्तमान कार्यालय"
                        SkinID="Unicodelbl"></asp:Label></td>
                <td style="height: 26px">
                    <asp:TextBox ID="txtCurrentOrg" runat="server" Width="130px" SkinID="Unicodetxt"
                        MaxLength="15" ReadOnly="True"></asp:TextBox></td>
                <td style="height: 26px">
                    <asp:Label ID="Label3" runat="server" Width="105px" Height="22px" Text="वर्तमान पद"
                        SkinID="Unicodelbl"></asp:Label></td>
                <td style="width: 153px; height: 26px">
                    <asp:TextBox ID="txtCurrentPost" runat="server" Width="130px" SkinID="Unicodetxt"
                        MaxLength="35" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 126px; height: 24px">
                    <asp:Label ID="Label7" runat="server" Text="कार्यालय" SkinID="Unicodelbl"></asp:Label>
                </td>
                <td style="height: 24px" colspan="3">
                    <asp:DropDownList ID="ddlOrganization" runat="server" Width="448px" SkinID="Unicodeddl">
                    </asp:DropDownList>
                </td>
                <td style="height: 24px">
                    <asp:Label ID="Label4" runat="server" Text="निवेदन मिति" SkinID="Unicodelbl"></asp:Label>
                </td>
                <td style="width: 153px; height: 24px">
                    <asp:TextBox ID="txtAppdate_DT" runat="server" Width="130px" SkinID="Unicodetxt"></asp:TextBox>
                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtAppdate_DT"
                        AutoComplete="False" Mask="9999/99/99" MaskType="Date">
                    </ajaxToolkit:MaskedEditExtender>
                </td>
            </tr>
            <tr>
                <td style="width: 126px; height: 50px">
                    <asp:Label ID="Labe27" runat="server" Text="विवरन" SkinID="Unicodelbl"></asp:Label>
                </td>
                <td style="height: 50px" colspan="3">
                    <asp:TextBox ID="txtdescription" runat="server" Width="330px" SkinID="Unicodetxt"
                        MaxLength="35" ToolTip="Description" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td style="height: 50px">
                </td>
                <td style="width: 153px; height: 50px">
                </td>
            </tr>
            <tr>
                <td style="height: 26px" align="left" colspan="6">
                    <asp:Button ID="btnAdd" runat="server" Text="Save" SkinID="Normal" OnClick="btnAdd_Click"
                        OnClientClick="return validateAppDate();"></asp:Button><asp:Button ID="btnCancel"
                            runat="server" Text="Cancel" SkinID="Cancel" OnClick="btnCancel_Click"></asp:Button></td>
            </tr>
        </tbody>
    </table>
    <table width="900">
        <tbody>
            <tr>
                <td>
                    <asp:GridView ID="grdDeputation" runat="server" SkinID="Unicodegrd" ForeColor="#333333"
                        CellPadding="0" AutoGenerateColumns="False" GridLines="None" Width="716px">
                        <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
                        <Columns>
                            <asp:BoundField DataField="DepOrgName" HeaderText="कार्यालय">
                                <ItemStyle Width="200px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Responsibilities" HeaderText="जिम्मेवारि कार्य विवरन"></asp:BoundField>
                            <asp:BoundField DataField="ApplicationDate" HeaderText="निवेदन मिति">
                                <ItemStyle Width="100px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="DecisionVerfiedByStatus" HeaderText="स्थीति">
                                <ItemStyle Width="100px"></ItemStyle>
                            </asp:BoundField>
                        </Columns>
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
                        <EditRowStyle BackColor="#999999"></EditRowStyle>
                        <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>
                        <HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                    </asp:GridView>
                </td>
            </tr>
        </tbody>
    </table>
    <%--</asp:Panel> 
    
    
    

</contenttemplate>
    </asp:UpdatePanel>--%>
    
    </div>
</asp:Content>
