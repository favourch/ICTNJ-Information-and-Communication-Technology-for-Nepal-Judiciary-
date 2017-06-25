<%@ Page Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master" AutoEventWireup="true" CodeFile="PropertyDetailsReport.aspx.cs" Inherits="MODULES_PMS_ReportForms_PropertyDetailsReport" Title=" सम्पत्ति विवरण रिपोर्ट" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript" src="../../COMMON/JS/Validation.js"></script>
<script language="javascript" type="text/javascript" src="../../COMMON/JS/DateValidator.js"></script>
<div style="width:100%; height:auto">
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
        <div style="padding-left:50px">
        <table id="tblSearch" width="95%">
            <tr>
                <td style="height:5px; width: 100px;"></td>
            </tr>
            <tr>
                <td colspan ="2">
                    <asp:Label ID="lblTitle" runat="server" Text="सम्पत्ति वविरण रिपोर्ट" Font-Bold="True" Font-Underline="True" SkinID="Unicodelbl"></asp:Label></td>
            </tr>
            <tr>
                <td style="height:10px; width: 100px;"></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label4" runat="server" SkinID="Unicodelbl" Text="कार्यालय"></asp:Label></td>
                <td colspan="5">
                    <asp:DropDownList ID="ddlOrgName" runat="server" SkinID="Unicodeddl" Width="186px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label1" runat="server" Text="पहिलो नाम" SkinID="Unicodelbl"></asp:Label></td>
                <td style="width: 200px">
                    <asp:TextBox ID="txtFName" runat="server" SkinID="Unicodetxt" Width="180px"></asp:TextBox></td>
                <td style="width: 100px">
                    <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="बीचको नाम"></asp:Label></td>
                <td style="width: 200px">
                    <asp:TextBox ID="txtMName" runat="server" SkinID="Unicodetxt" Width="180px"></asp:TextBox></td>
                <td style="width: 100px">
                    <asp:Label ID="Label3" runat="server" SkinID="Unicodelbl" Text="थर"></asp:Label></td>
                <td style="width: 200px" align="left">
                    <asp:TextBox ID="txtSName" runat="server" SkinID="Unicodetxt" Width="180px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label5" runat="server" SkinID="Unicodelbl" Text="पद"></asp:Label></td>
                <td style="width: 200px"><asp:DropDownList ID="ddlPost" runat="server" Width="186px" SkinID="Unicodeddl">
                </asp:DropDownList></td>
                <td style="width: 100px">
                    <asp:Label ID="Label6" runat="server" SkinID="Unicodelbl" Text="श्रेणी"></asp:Label></td>
                <td style="width: 200px">
                    <asp:DropDownList ID="ddlLevel" runat="server" Width="186px" SkinID="Unicodeddl">
                    </asp:DropDownList></td>
                <td style="width: 100px">
                    </td>
                <td style="width: 200px"></td>
            </tr>
            
            <tr>
                <td style="width: 100px; height: 34px;">
                    <asp:Image ID="LoadImageX" runat="server" Height="0px" ImageUrl="~/MODULES/LIS/Images/Loading.gif" Style="position: static" Width="0px" /></td>
                <td style="height: 34px">
                    </td>
                <td style="height: 34px">
                </td>
                <td style="height: 34px">
                </td>
                <td colspan="2" valign="top" style="padding-right: 15px; height: 34px;" align="right">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" Width="70px" OnClick="btnSearch_Click"  /><asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="70px" OnClick="btnCancel_Click"  /></td>
            </tr>
        </table>
        </div>
        
        <hr  width="90%" style="padding-left: 50px" />
        <div style="padding-left:50px">
         <table width ="95%" cellpadding ="0" cellspacing ="0">
            <tr>
                <td> &nbsp;
                <asp:Label id="lblSearchResult" runat="server" Font-Bold="True"></asp:Label>
                </td>
                <td align ="right" style="padding-right:66px;"><asp:Button ID="btnGenerateRpt" runat="server" Text="रिपोर्ट हेर्नुहोस्" OnClick="btnGenerateRpt_Click" Visible="False" /></td>
            </tr>
        </table>
                  
        <asp:Panel ID="pnlSearch" runat="server" Height="300px" ScrollBars="Auto" Width="95%">
            &nbsp;<asp:UpdatePanel id="UpdatePanel1" runat="server"><contenttemplate>
<asp:GridView id="grdEmployeeSearch" runat="server" Width="400px" ForeColor="#333333" AutoGenerateColumns="False" GridLines="None" CellPadding="4" OnRowCreated="grdEmployeeSearch_RowCreated" OnRowDataBound="grdEmployeeSearch_RowDataBound" __designer:wfdid="w9">
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <EditRowStyle BackColor="#999999" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField>
                        <ItemStyle Width="5px" />
                        <ItemTemplate>
                            <asp:CheckBox ID="chkShowReport" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="EmpID" />
                    <asp:BoundField DataField="OrgName" HeaderText="कार्यलय">
                    </asp:BoundField>
                    <asp:BoundField DataField="RDFullName" HeaderText="नाम" >
                    </asp:BoundField>
                    <asp:BoundField DataField="Gender" HeaderText="लिङ्ग" />
                    <asp:BoundField DataField="PostName" HeaderText="पद">
                    </asp:BoundField>
                    <asp:BoundField DataField="LevelName" HeaderText="श्रेणी">
                    </asp:BoundField>
                    <asp:BoundField DataField="PostingTypeName" HeaderText="दर्बन्दि किसिम" />
                </Columns>
            </asp:GridView>
</contenttemplate>
            </asp:UpdatePanel>
        </asp:Panel> &nbsp;
          
        </div>    
    </div>
</asp:Content>

