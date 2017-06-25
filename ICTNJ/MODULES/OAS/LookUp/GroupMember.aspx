<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true"
    CodeFile="GroupMember.aspx.cs"  Inherits="MODULES_OAS_LookUp_GroupMember" Title="OAS|Group Member" %>

<%@ Register Src="../UserControls/GroupMemberSearch.ascx" TagName="GroupMemberSearch"
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
                    alert('कृपया समुह छानि समुहमा सदस्य राख्नुहोस।');
                    return false;
                }
                
                if(tbl.rows.length <= 0)
                {
                    alert('कृपया समुह छानि समुहमा सदस्य राख्नुहोस।');
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
<asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup" runat="server"></asp:Button> <ajaxToolkit:ModalPopupExtender id="programmaticModalPopup" runat="server" TargetControlID="hiddenTargetControlForModalPopup" RepositionMode="RepositionOnWindowScroll" PopupDragHandleControlID="programmaticPopupDragHandle" PopupControlID="programmaticPopup" DropShadow="True" BehaviorID="programmaticModalPopupBehavior" BackgroundCssClass="modalBackground">
        </ajaxToolkit:ModalPopupExtender> <asp:Panel style="PADDING-RIGHT: 10px; DISPLAY: none; PADDING-LEFT: 10px; PADDING-BOTTOM: 10px; WIDTH: 350px; PADDING-TOP: 10px" id="programmaticPopup" runat="server" CssClass="modalPopup">
            <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD;
                border: solid 1px Gray; color: Black; text-align: center;">
                Save Status
            </asp:Panel>
            <asp:UpdatePanel id="UpdatePanel3" runat="server">
                <contenttemplate>
            <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
</contenttemplate>
            </asp:UpdatePanel>
            <br />
            <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
                Text="OK" Width="58px" />
            <br />
        </asp:Panel> <DIV style="PADDING-LEFT: 20px"><TABLE width=1000><TBODY><TR><TD style="WIDTH: 200px" align=left colSpan=2 rowSpan=1></TD></TR><TR><TD style="WIDTH: 200px" align=left colSpan=2 rowSpan=1><asp:Label id="lblHeading" runat="server" Text="समुह सदस्य" SkinID="UnicodeHeadlbl"></asp:Label></TD></TR><TR><TD style="WIDTH: 200px" align=right></TD><TD style="WIDTH: 800px"></TD></TR><TR><TD style="WIDTH: 200px" align=right><asp:Label id="Label1" runat="server" Text="संस्था" SkinID="Unicodelbl"></asp:Label> &nbsp; </TD><TD style="WIDTH: 800px"><asp:DropDownList id="ddlOrg_Rqd" runat="server" Width="250px" SkinID="Unicodeddl" ToolTip="संस्था" OnSelectedIndexChanged="ddlOrg_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 200px" vAlign=top><asp:UpdatePanel id="UpdatePanel1" runat="server">
                            <contenttemplate>
<asp:Label id="Label2" runat="server" Text="समुह" SkinID="Unicodelbl"></asp:Label><BR /><asp:ListBox id="lstCommittee" runat="server" Width="180px" Height="220px" SkinID="Unicodelst" OnSelectedIndexChanged="lstCommittee_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox>
</contenttemplate>
                            
                        </asp:UpdatePanel></TD><TD style="WIDTH: 800px" vAlign=top><asp:UpdatePanel id="UpdatePanel2" runat="server"><ContentTemplate>
<asp:Label id="Label3" runat="server" SkinID="Unicodelbl" Font-Bold="False">समुह सदस्य :::</asp:Label>&nbsp;<asp:Label id="lblSearch" runat="server" SkinID="Unicodelbl" Font-Bold="False"></asp:Label><BR /><asp:Panel id="pnlGroupMember" runat="server" Width="800px" Height="220px" ScrollBars="Auto"><asp:GridView id="grdGrpMember" runat="server" Width="607px" SkinID="Unicodegrd" ForeColor="#333333" OnRowDeleting="grdGrpMember_RowDeleting" CellPadding="0" AutoGenerateColumns="False" OnRowCreated="grdGrpMember_RowCreated" GridLines="Vertical" OnDataBound="grdGrpMember_DataBound">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="EMPID" HeaderText="आई डी"></asp:BoundField>
<asp:BoundField DataField="EmpName" HeaderText="पुरा नाम थर"></asp:BoundField>
<asp:TemplateField HeaderText="शुरु मिति"><ItemTemplate>
<asp:TextBox id="txxFromDate_Rdt" runat="server" Width="75px" Text='<%# Eval("FromDate") %>' SkinID="Unicodetxt" ToolTip='<%# Eval("EmpName")+" को शुरु मिति" %>' ReadOnly='<%# Eval("DateControlEnabled") %>' BackColor='<%# Eval("DateColor") %>'></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="mskFromDate" runat="server" TargetControlID="txxFromDate_Rdt" Mask="9999/99/99" MaskType="Date" AutoComplete="False"></ajaxToolkit:MaskedEditExtender> 
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
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="btnAddMember" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="lstCommittee" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="ddlOrg_Rqd" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</Triggers>
</asp:UpdatePanel></TD></TR></TBODY></TABLE>
<HR />
<uc1:GroupMemberSearch id="EmployeeSearch" runat="server" ApplicationString="5, 3" EnableCommittee="false"></uc1:GroupMemberSearch> <BR /><asp:Button id="btnSubmit" onclick="btnSubmit_Click" runat="server" Text="Submit" SkinID="Normal" OnClientClick="return ValidateForm();"></asp:Button> <asp:Button id="btnCancel" onclick="btnCancel_Click1" runat="server" Text="Cancel" SkinID="Cancel"></asp:Button> <asp:Button id="btnAddMember" onclick="btnAddMember_Click" runat="server" Width="160px" Text="Add Member to Group" SkinID="Dynamic"></asp:Button> </DIV>
</contenttemplate>
    
                </asp:UpdatePanel>
    </div>
</asp:Content>
