<%@ Page Language="C#" MasterPageFile="~/MODULES/LJMS/LJMSMasterPage.master" AutoEventWireup="true" CodeFile="JudgeDetailSearch.aspx.cs" Inherits="MODULES_LJMS_Forms_EmployeeDetailSearch" Title="LJMS | Judge Detail Search" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script language="javascript" type="text/javascript">
        function LoadImage()
        {
            document.getElementById("<%=this.LoadImageX.ClientID %>").style.width="28px";
            document.getElementById("<%=this.LoadImageX.ClientID %>").style.height="28px";
        }
        function UnloadImage()
        {
            document.getElementById("<%=this.LoadImageX.ClientID %>").style.display="none";
        }
    </script>
    
    <div style="width:100%; height:auto">
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
        <table id="TABLE1" width="900">
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label4" runat="server" SkinID="Unicodelbl" Text="कार्यालय"></asp:Label></td>
                <td colspan="5">
                    <asp:DropDownList ID="ddlOrganization" runat="server" SkinID="Unicodeddl" Width="796px" AutoPostBack="True" OnSelectedIndexChanged="ddlOrganization_SelectedIndexChanged">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label1" runat="server" Text="पहिलो नाम" SkinID="Unicodelbl"></asp:Label></td>
                <td style="width: 200px">
                    <asp:TextBox ID="txtFName" runat="server" SkinID="Unicodetxt" Width="180px"></asp:TextBox></td>
                <td style="width: 100px">
                    <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="बिचको नाम"></asp:Label></td>
                <td style="width: 200px">
                    <asp:TextBox ID="txtMName" runat="server" SkinID="Unicodetxt" Width="180px"></asp:TextBox></td>
                <td style="width: 100px">
                    <asp:Label ID="Label3" runat="server" SkinID="Unicodelbl" Text="थर"></asp:Label></td>
                <td style="width: 200px">
                    <asp:TextBox ID="txtSName" runat="server" SkinID="Unicodetxt" Width="180px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label9" runat="server" SkinID="Unicodelbl" Text="सेवा"></asp:Label></td>
                <td style="width: 200px">
                    <asp:DropDownList ID="ddlSewa" runat="server" Width="186px" AutoPostBack="True" OnSelectedIndexChanged="ddlSewa_SelectedIndexChanged" SkinID="Unicodeddl">
                    </asp:DropDownList></td>
                <td style="width: 100px">
                    <asp:Label ID="Label7" runat="server" SkinID="Unicodelbl" Text="समुह"></asp:Label></td>
                <td style="width: 200px">
                    <asp:UpdatePanel id="updSamuha" runat="server">
                        <contenttemplate>
<asp:DropDownList id="ddlSamuha" runat="server" Width="186px" SkinID="Unicodeddl" OnSelectedIndexChanged="ddlSamuha_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="True" __designer:wfdid="w11">
                    </asp:DropDownList> 
</contenttemplate>
                        <triggers>
<asp:AsyncPostBackTrigger ControlID="ddlSewa" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
                    </asp:UpdatePanel></td>
                <td style="width: 100px">
                    <asp:Label ID="Label8" runat="server" SkinID="Unicodelbl" Text="उप-समुह"></asp:Label></td>
                <td style="width: 200px">
                    <asp:UpdatePanel id="updUpaSamuha" runat="server">
                        <contenttemplate>
<asp:DropDownList id="ddlUpaSamuha" runat="server" Width="186px" SkinID="Unicodeddl" OnSelectedIndexChanged="ddlUpaSamuha_SelectedIndexChanged" __designer:wfdid="w13" AppendDataBoundItems="True">
                    </asp:DropDownList> 
</contenttemplate>
                        <triggers>
<asp:AsyncPostBackTrigger ControlID="ddlSamuha" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
                    </asp:UpdatePanel></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label5" runat="server" SkinID="Unicodelbl" Text="पद"></asp:Label></td>
                <td style="width: 200px">
                    <asp:UpdatePanel id="updPost" runat="server">
                        <contenttemplate>
<asp:DropDownList id="ddlPost" runat="server" Width="186px" SkinID="Unicodeddl" __designer:wfdid="w12">
                    </asp:DropDownList> 
</contenttemplate>
                        <triggers>
<asp:AsyncPostBackTrigger ControlID="ddlOrganization" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
                    </asp:UpdatePanel></td>
                <td style="width: 100px">
                    <asp:Label ID="Label6" runat="server" SkinID="Unicodelbl" Text="श्रेणी"></asp:Label></td>
                <td style="width: 200px">
                    <asp:DropDownList ID="ddlLevel" runat="server" Width="186px" SkinID="Unicodeddl">
                    </asp:DropDownList></td>
                <td style="width: 100px">
                    <asp:Label ID="Label16" runat="server" SkinID="Unicodelbl" Text="नियुत्तिको प्रकार"></asp:Label></td>
                <td style="width: 200px"><asp:DropDownList ID="ddlPostingType" runat="server" Width="186px" SkinID="Unicodeddl">
                </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label10" runat="server" SkinID="Unicodelbl" Text="लिं"></asp:Label></td>
                <td style="width: 200px">
                    <asp:DropDownList ID="ddlSex" runat="server" Width="186px" SkinID="Unicodeddl">
                        <asp:ListItem Value="SG">छान्नुहोस</asp:ListItem>
                        <asp:ListItem Value="M">पुरुष</asp:ListItem>
                        <asp:ListItem Value="F">महिला</asp:ListItem>
                        <asp:ListItem Value="O">अन्य</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 100px">
                    <asp:Label ID="Label11" runat="server" SkinID="Unicodelbl" Text="जिल्ला"></asp:Label></td>
                <td style="width: 200px">
                    <asp:DropDownList ID="ddlDistrict" runat="server" Width="186px" SkinID="Unicodeddl">
                    </asp:DropDownList></td>
                <td style="width: 100px">
                </td>
                <td style="width: 200px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px;" valign="top">
                    <asp:Label ID="Label14" runat="server" SkinID="Unicodelbl" Text="तालिम"></asp:Label></td>
                <td style="width: 200px;" valign="top">
                    <asp:TextBox ID="txtTraining" runat="server" SkinID="Unicodetxt" Width="180px"></asp:TextBox></td>
                <td style="width: 100px;" valign="top">
                    <asp:Label ID="Label15" runat="server" SkinID="Unicodelbl" Text="अवकाशको मिति"></asp:Label></td>
                <td style="width: 200px;" valign="top">
                    <asp:DropDownList ID="ddlROperator" runat="server" SkinID="Unicodeddl" Width="56px">
                        <asp:ListItem>&lt;=</asp:ListItem>
                        <asp:ListItem>=</asp:ListItem>
                        <asp:ListItem Value="&gt;="></asp:ListItem>
                    </asp:DropDownList><asp:TextBox ID="txtRetirementDate" runat="server" SkinID="Unicodetxt" Width="124px"></asp:TextBox></td>
                <td valign="top" colspan="2">
                    <asp:Label ID="Label17" runat="server" Font-Bold="True" SkinID="Unicodelbl" Text="नियुत्तिको मिति बाट"></asp:Label>
                    <ajaxToolkit:MaskedEditExtender ID="mskRetirement" runat="server" AutoComplete="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtRetirementDate">
                    </ajaxToolkit:MaskedEditExtender>
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 31px" valign="top">
                    <asp:Label ID="Label12" runat="server" SkinID="Unicodelbl" Text="शैक्षिक योग्यता"></asp:Label></td>
                <td style="height: 31px" valign="top" colspan="2">
                    <asp:Panel ID="Panel1" runat="server" Height="150px" ScrollBars="Auto" Style="position: static" Width="285px">
                        <asp:CheckBoxList ID="lstQualification" runat="server" Style="position: static">
                        </asp:CheckBoxList></asp:Panel>
                </td>
                <td style="width: 200px; height: 31px" valign="top" align="right">
                    &nbsp;<asp:Label ID="Label13" runat="server" SkinID="Unicodelbl" Text="भ्रमन गएको&nbsp;&nbsp;&nbsp;<br>देश"></asp:Label>
                    &nbsp;&nbsp;
                </td>
                <td colspan="2" style="height: 31px" valign="top">
                    <asp:Panel ID="Panel2" runat="server" Height="150px" ScrollBars="Auto" Style="position: static" Width="285px">
                        <asp:CheckBoxList ID="lstVisit" runat="server" Style="position: static">
                        </asp:CheckBoxList></asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Image ID="LoadImageX" runat="server" Height="0px" ImageUrl="~/MODULES/LIS/Images/Loading.gif" Style="position: static" Width="0px" /></td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" Width="70px" OnClick="btnSearch_Click" OnClientClick="LoadImage();" SkinID="Normal" /><asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="70px" OnClick="btnCancel_Click" SkinID="Cancel" /></td>
                <td>
                </td>
                <td>
                </td>
                <td colspan="2" valign="top" height="32">
                </td>
            </tr>
        </table>
        <hr align="left" width="95%" />
        <asp:Label ID="lblRecordCount" runat="server" Font-Bold="True" Font-Italic="True" SkinID="Unicodelbl"></asp:Label>
        <asp:Panel ID="pnlSearch" runat="server" Height="300px" ScrollBars="Auto" Width="100%">
            <asp:GridView ID="grdEmployee" runat="server" CellPadding="0" ForeColor="#333333" GridLines="None" SkinID="Unicodegrd" OnDataBound="grdEmployee_DataBound" OnRowDataBound="grdEmployee_RowDataBound" AutoGenerateColumns="False" Width="2300px">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#EFF3FB" />
                <EditRowStyle BackColor="#2461BF" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="EmpID" />
                    <asp:BoundField HeaderText="क.न" DataField="EmpID">
                        <ItemStyle HorizontalAlign="Center" Width="35px" />
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="RDFullName" HeaderText="कर्मचारीको नाम">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SewaName" HeaderText="सेवा">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SamuhaName" HeaderText="समुह">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="UpaSamuhaName" HeaderText="उप-समुह">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PostName" HeaderText="पद">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LevelName" HeaderText="तह">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PostingTypeName" HeaderText="नियुत्ति प्रकार">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="RDGender" HeaderText="लिं">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="DistrictName" HeaderText="जन्म स्थान">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="तालिम">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Training") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text='<%# Eval("Training") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="JoiningDate" HeaderText="नियुत्ति मिति">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="RetirementDate" HeaderText="अवकाश मिति">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="शैक्षिक योग्यता">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("QualificationName") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text='<%# Eval("QualificationName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="भ्रमण गएको देश">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("VisitCountryName") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" SkinID="Unicodelbl" Text='<%# Eval("VisitCountryName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="SubjectID" />
                    <asp:BoundField DataField="DegreeID" />
                    <asp:BoundField DataField="VisitCountryID" />
                    <asp:BoundField DataField="VisitPurpose" HeaderText="उद्देश्य" />
                    <asp:BoundField DataField="VisitFromDate" HeaderText="गएको मिति" />
                    <asp:BoundField DataField="VisitToDate" HeaderText="फर्केको मिति" />
                </Columns>
            </asp:GridView>
        </asp:Panel>
        &nbsp;<br />
        <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
        <ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior"
            DropShadow="True" PopupControlID="programmaticPopup" PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
            TargetControlID="hiddenTargetControlForModalPopup">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none; width: 350px; padding: 10px">
            <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD; border: solid 1px Gray; color: Black; text-align: center;">
                Save Status
            </asp:Panel>
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label><br />
            <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click" Text="OK" Width="58px" />
            <br />
        </asp:Panel>
    </div>
</asp:Content>

