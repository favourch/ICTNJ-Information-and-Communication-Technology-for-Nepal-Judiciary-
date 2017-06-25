<%@ Page AutoEventWireup="true" EnableEventValidation="false" CodeFile="CommitteeMember.aspx.cs"
    Inherits="MODULES_OAS_LookUp_CommitteeMember" Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master"
    Title="OAS | Committee Member" %>

<%@ Register Src="../UserControls/GroupMemberPersonSearch.ascx" TagName="GroupMemberPersonSearch"
    TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager ID="ScriptManager" runat="server">
    </asp:ScriptManager>

    <script language="javascript" src="../../COMMON/JS/Validation.js" type="text/javascript"></script>

    <script language="javascript" src="../../COMMON/JS/DateValidator.js" type="text/javascript"></script>

    <script language="javascript" src="../../COMMON/JS/EnglishDateValidator.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
        function ValidateForm()
        {
            var InputResult = validate(1);
            
            if(InputResult == true)
                return GetProcess();
            else
                return false;
        }
        
        function GetProcess()
        {
            //alert(tbl.rows[i].cells[0].innerText+" ::: "+tbl.rows[i].cells[3].children[0].value);
            try
            {
                var tbl = document.getElementById('<%= this.grdGrpMember.ClientID%>');
                if(tbl == null)
                {
                    alert('कृपया कमिटि छानि कमिटिमा सदस्य राख्नुहोस।');
                    return false;
                }
                
                if(tbl.rows.length <= 0)
                {
                    alert('कृपया कमिटि छानि कमिटिमा सदस्य राख्नुहोस।');
                    return false;
                }
                
                var rowCount=tbl.rows.length;
                
                var EmpID;
                var FromDate;
                var IsExit=false;
                
                for(var i=1; i<rowCount; i++)
                {
                    EmpID=tbl.rows[i].cells[0].innerHTML;
                    FromDate=tbl.rows[i].cells[2].children[0].value;
                    
                    for(var j=1; j<rowCount; j++)
                    {
                        if(i!=j)
                        {
                            if(EmpID==tbl.rows[j].cells[0].innerHTML && FromDate==tbl.rows[j].cells[2].children[0].value)
                            {
                                alert('EmployeeID:: '+EmpID +' and FromDate:: '+FromDate+' has been repeated.\nPlease change FromDate.');
                                IsExit=true;
                                tbl.rows[j].cells[2].children[0].focus();
                                tbl.rows[j].cells[2].children[0].select();
                                break;
                            }
                        }
                    }
                    if(IsExit==true)
                        break;    
                }
                
            if(IsExit==true)
                return false;
            else
                return true;
            }
            catch(err)
            {
                alert(err);
            }
        }
    </script>

    <div style="width: 100%; height: auto;">
        <asp:UpdatePanel id="UpdatePanel_whole" runat="server">
            <contenttemplate>
        <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
        <ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior"
            DropShadow="True" PopupControlID="programmaticPopup" PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
            TargetControlID="hiddenTargetControlForModalPopup">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none; width: 350px; padding: 10px">
            <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD; border: solid 1px Gray; color: Black; text-align: center;">
                Save Status
            </asp:Panel>
            <asp:UpdatePanel id="UpdatePanel3" runat="server">
                <contenttemplate>
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
</contenttemplate>
            </asp:UpdatePanel>
            <br />
            <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click" Text="OK" Width="58px" />
            <br />
        </asp:Panel>
        
        <div style ="padding-left:20px" >
        <table width="1000">
            <tr>
                <td align="left" colspan="2" rowspan="" style="width: 200px">
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2" rowspan="" style="width: 200px">
                    <asp:Label ID="lblHeading" runat="server" SkinID="UnicodeHeadlbl" Text="कमिटि सदस्य"></asp:Label></td>
            </tr>
            <tr>
                <td align="right" style="width: 200px">
                </td>
                <td style="width: 800px">
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 200px">
                    <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="संस्था"></asp:Label>
                    &nbsp;
                </td>
                <td style="width: 800px">
                    <asp:DropDownList ID="ddlOrg_Rqd" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlOrg_SelectedIndexChanged" SkinID="Unicodeddl" ToolTip="संस्था"
                        Width="250px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 200px" valign="top">
                    <asp:UpdatePanel id="UpdatePanel1" runat="server">
                        <contenttemplate>
<asp:Label id="Label2" runat="server" Text="कमिटि" SkinID="Unicodelbl" __designer:dtid="7036874417766425" __designer:wfdid="w20"></asp:Label><BR /><asp:ListBox id="lstCommittee" runat="server" Width="180px" Height="220px" SkinID="Unicodelst" OnSelectedIndexChanged="lstCommittee_SelectedIndexChanged" AutoPostBack="True" __designer:wfdid="w19"></asp:ListBox>
</contenttemplate>
                        <triggers>
<asp:AsyncPostBackTrigger ControlID="ddlOrg_Rqd" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
                    </asp:UpdatePanel></td>
                <td style="width: 800px" valign="top">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <contenttemplate>
<asp:Label id="Label3" runat="server" SkinID="Unicodelbl" Font-Bold="False" __designer:wfdid="w5">कमिटि सदस्य :::</asp:Label>&nbsp;<asp:Label id="lblSearch" runat="server" SkinID="Unicodelbl" Font-Bold="False" __designer:wfdid="w6"></asp:Label><BR /><asp:Panel id="pnlGroupMember" runat="server" Width="800px" Height="220px" __designer:wfdid="w7" ScrollBars="Auto"><asp:GridView id="grdGrpMember" runat="server" Width="750px" SkinID="Unicodegrd" __designer:wfdid="w8" OnDataBound="grdGrpMember_DataBound" GridLines="Vertical" OnRowCreated="grdGrpMember_RowCreated" AutoGenerateColumns="False" CellPadding="0" OnRowDeleting="grdGrpMember_RowDeleting" ForeColor="#333333">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="EMPID" HeaderText="आई डी"></asp:BoundField>
<asp:BoundField DataField="EmpName" HeaderText="पुरा नाम थर"></asp:BoundField>
<asp:TemplateField HeaderText="शुरु मिति"><ItemTemplate>
<asp:TextBox id="txxFromDate_Rdt" runat="server" Width="75px" Text='<%# Eval("FromDate") %>' SkinID="Unicodetxt" ToolTip='<%# Eval("EmpName")+" को शुरु मिति" %>' ReadOnly='<%# Eval("DateControlEnabled") %>' __designer:wfdid="w3" BackColor='<%# Eval("DateColor") %>'></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="mskFromDate" runat="server" TargetControlID="txxFromDate_Rdt" Mask="9999/99/99" MaskType="Date" AutoComplete="False" __designer:wfdid="w4"></ajaxToolkit:MaskedEditExtender> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="पदको नाम"><ItemTemplate>
<asp:DropDownList id="ddlPosition_Rqd" runat="server" Width="180px" SkinID="Unicodeddl" ToolTip='<%# Eval("EmpName")+" को पद" %>' DataValueField="PositionID" DataSourceID="odsMemPosition" DataTextField="PositionName" SelectedValue='<%# Eval("PositionID") %>'></asp:DropDownList><asp:ObjectDataSource id="odsMemPosition" runat="server" SelectMethod="GetMemberPositionList" TypeName="PCS.OAS.BLL.BLLMemberPosition"><SelectParameters>
<asp:Parameter Type="Int32" DefaultValue="" Name="positionID"></asp:Parameter>
<asp:Parameter Type="Boolean" DefaultValue="true" Name="containDefault"></asp:Parameter>
</SelectParameters>
</asp:ObjectDataSource> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="Action" HeaderText="Action"></asp:BoundField>
<asp:CommandField ShowDeleteButton="True"></asp:CommandField>
<asp:BoundField DataField="OFromDate" HeaderText="OFromDate"></asp:BoundField>
<asp:BoundField DataField="OToDate" HeaderText="OToDate"></asp:BoundField>
<asp:BoundField DataField="OPositionID" HeaderText="OPositionID"></asp:BoundField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView></asp:Panel> 
</contenttemplate>
                        <triggers>
<asp:AsyncPostBackTrigger ControlID="btnAddMember" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="lstCommittee" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="ddlOrg_Rqd" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
                    </asp:UpdatePanel></td>
            </tr>
        </table>
        <hr />
        <uc1:GroupMemberPersonSearch ID="EmployeeSearch" runat="server" EnableCommittee="false" ApplicationString="5, 3" />
   
    <br />
    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" OnClientClick="return ValidateForm();" Text="Submit" SkinID="Normal" />
    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click1" Text="Cancel" SkinID="Cancel" />
    <asp:Button ID="btnAddMember" runat="server" OnClick="btnAddMember_Click" SkinID="Dynamic" Text="Add Member to Group" Width="160px" />
         </div>
          </contenttemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
