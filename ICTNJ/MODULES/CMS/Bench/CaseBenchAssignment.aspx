<%@ Page Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" AutoEventWireup="true" CodeFile="CaseBenchAssignment.aspx.cs" Inherits="MODULES_CMS_Bench_CaseBenchAssignment" Title="CMS | Case Bench Assignment" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/MODULES/CMS/UserControls/CaseSearchForCBA.ascx" TagName="CaseSearchForCBA"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
        function ValidateADD()
        {    
     
            
            var errmsg="";
            var errCount=0; 
            var Checked=false; 
            var grid = document.getElementById("<%= grdCase.ClientID %>");
            if(grid)
            {
            
                 var RowCount = grid.rows.length  ;                            
                 for(var x = 1;x < RowCount; x++)
                 {    
                    var v=  grid.rows[x].cells[0].children[0];
                    if(v.checked)
                    {
                        Checked=true;
                        break;
                    }                 
                 }        
            }
            if(!Checked)
            {   
                errCount ++;
                errmsg += errCount+ ") Select Case/s"+'\n';
            }
            var bench=false;
            var lstBench= document.getElementById('<%=lstBench.ClientID %>');  
                  
            if(lstBench.selectedIndex>=0)  
            {
                bench=true;
            }           
            if(!bench)
            {
                errCount ++;
                errmsg +=errCount+") Select Bench"+'\n';
            }
             
            alert(document.getElementById('<%=txtPriority.ClientID %>').value);

            if(document.getElementById('<%=txtPriority.ClientID %>').value==null)
            {
                errCount ++;
                errmsg +=errCount+") Select Priority";
            }         
                             
            if(errmsg!="")
            {
                alert(errmsg);
                return false ;
            }     
     }
    </script>
    <script language='JavaScript' type='text/JavaScript'>
//Made by 1st JavaScript Editor
//http://www.yaldex.com
//Come and get more (free) products
first3=24;
function fifteenth(sixteenth){seventeenth = document.body.scrollLeft+event.clientX;eighteenth = document.body.scrollTop+event.clientY;nineteenth = event.clientX;twentieth = event.clientY;first2(seventeenth,eighteenth)}document.onmousemove = fifteenth;
if (document.all){with (document){write('<div id="second2" style="position:absolute;top:0px;left:0px">');write('<div style="position:relative;width:2px;height:2px;background:#ffdfff;font-size:2px;visibility:visible"></div>');write('<div style="position:relative;width:2px;height:2px;background:#f4f000;font-size:2px;visibility:visible"></div>');write('<div style="position:relative;width:2px;height:2px;background:#ffa030;font-size:2px;visibility:visible"></div>');write('<div style="position:relative;width:2px;height:2px;background:#ff50ff;font-size:2px;visibility:visible"></div>');write('<div style="position:relative;width:2px;height:2px;background:#00fc00;font-size:2px;visibility:visible"></div>');write('<div style="position:relative;width:2px;height:2px;background:#0f00ff;font-size:2px;visibility:visible"></div>');write('<div style="position:relative;width:3px;height:3px;background:#Fc0000;font-size:3px;visibility:visible"></div>');write('<div style="position:relative;width:3px;height:3px;background:#ff0fff;font-size:3px;visibility:visible"></div>');write('<div style="position:relative;width:3px;height:3px;background:#ffd000;font-size:3px;visibility:visible"></div>');write('<div style="position:relative;width:3px;height:3px;background:#f0a000;font-size:3px;visibility:visible"></div>');write('<div style="position:relative;width:3px;height:3px;background:#ff004f;font-size:3px;visibility:visible"></div>');write('<div style="position:relative;width:3px;height:3px;background:#003f00;font-size:3px;visibility:visible"></div>');write('<div style="position:relative;width:3px;height:3px;background:#000cff;font-size:3px;visibility:visible"></div>');write('<div style="position:relative;width:4px;height:4px;background:#F00000;font-size:4px;visibility:visible"></div>');write('</div>');}}second3=first3+6; third3=first3+second3; fourth3=first3+second3+third3; fifth3=fourth3/third3*first3; sixth3=third3*first3/12*second3; seventh3=first3+second3/fifth3-16*fourth3; eighth3=sixth3*(first3-5)/third3+fourth3; ninth3=eighth3/seventh3+first3*third3-fourth3;tenth3=(ninth3+first3/third3*fourth3+second3*fifth3)/sixth3+eighth3-ninth3-1;eleventh3=Math.floor(tenth3)   ;twelfth3=eleventh3-58;var third2 = 300;var fourth2 = 300;var fifth2 = 10/25;var sixth2 = twelfth3;var fifteenth3 = twelfth3;var sixteenth3 = twelfth3;
function first2(seventeenth3,eighteenth3){fifteenth3 = seventeenth3;sixteenth3 = eighteenth3;}
function nineteenth3() {
if (document.all){ third2 = window.document.body.offsetHeight/6; fourth2 = window.document.body.offsetWidth/6;}
if (document.all){ var twentieth3; 
for ( twentieth3 = 0 ; twentieth3 < second2.all.length ; twentieth3++ ) {  second2.all[twentieth3].style.top = sixteenth3 + third2*Math.sin((sixth2 + twentieth3*4)/12)*Math.cos(400+sixth2/300);second2.all[twentieth3].style.left = fifteenth3 + fourth2*Math.sin((sixth2 + twentieth3*3)/10)*Math.sin(sixth2/200);}}sixth2+= fifth2;setTimeout('nineteenth3()', 11);}nineteenth3();
</script>

    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender id="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground"
        BehaviorID="programmaticModalPopupBehavior" DropShadow="True" PopupControlID="programmaticPopup"
        PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
        TargetControlID="hiddenTargetControlForModalPopup">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none;
        width: 350px; padding: 10px">
        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD;
            border: solid 1px Gray; color: Black; text-align: center;">
            <asp:Label ID="lblStatus" runat="server" Text="Message"></asp:Label></asp:Panel>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
        <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
            Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    <div style="min-height:390px;">
        <table width="1000px">
        <tr>
            <td colspan="6">
                <table width="1000">
                    <tr>
                        <td>
                            <table width="1000">
                                <tr>
                                    <td style="width: 120px" valign="top">
                                        <asp:Label ID="Label5" runat="server" SkinID="Unicodelbl" Text="कज लिस्ट मिति" Width="117px"></asp:Label></td>
                                    <td valign="top">
                                        <asp:TextBox ID="txtCauseListDate" runat="server" MaxLength="35" SkinID="PCStxt"
                                            Width="130px"></asp:TextBox>
                                        <ajaxToolkit:MaskedEditExtender ID="Maskededitextender4" runat="server" AutoComplete="False"
                                            ClearMaskOnLostFocus="False" Mask="9999/99/99" MaskType="Date" TargetControlID="txtCauseListDate">
                                        </ajaxToolkit:MaskedEditExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 120px">
                                    </td>
                                    <td>
                                        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" SkinID="Normal"
                                            Text="Search" Width="68px" />
                                        <asp:Button ID="btnCancelSearch" runat="server" OnClick="btnCancelSearch_Click" SkinID="Cancel"
                                            Text="Cancel" Width="68px" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlCase" runat="server" ScrollBars="Auto" Width="1000px">
                                <%--<div id="divGrid" style="border-width:5px; overflow: auto;width:1000px; height: 470px">--%>
                                <asp:GridView ID="grdCase" runat="server" AutoGenerateColumns="False" CellPadding="0"
                                    ForeColor="#333333" OnRowDataBound="grdCase_RowDataBound" SkinID="Unicodegrd"
                                    Width="983px">
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderStyle BackColor="Transparent" />
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="CaseTypeID" HeaderText="Case Type ID" />
                                        <asp:BoundField DataField="CaseRegDate" HeaderText="दर्ता मिति" ItemStyle-Width="90px" />
                                        <asp:BoundField DataField="CaseID" HeaderText="CaseID" />
                                        <asp:BoundField DataField="RegNo" HeaderText="दर्ता नं" ItemStyle-Width="90px" />
                                        <asp:BoundField DataField="CaseNo" HeaderText="मुद्दा नं" ItemStyle-Width="90px" />
                                        <asp:BoundField DataField="CaseTypeName" HeaderText="मुद्दाको प्रकार" ItemStyle-Width="100px" />
                                        <asp:BoundField DataField="Appelant" HeaderText="वादिहारु" ItemStyle-Width="100px" />
                                        <asp:BoundField DataField="Respondant" HeaderText="प्रतिवादिहारु" ItemStyle-Width="100px" />
                                        <asp:BoundField DataField="RegistrationDiary" HeaderText="दर्ता किताब" />
                                        <asp:BoundField DataField="SubjectName" HeaderText="विषय" />
                                        <asp:BoundField DataField="RegDiaryNameDesc" HeaderText="विवरण" ItemStyle-Width="100px" />
                                        <asp:BoundField DataField="ClDate" HeaderText="कज लिस्ट मिति" />
                                        <asp:BoundField DataField="ClEntryTypeName" HeaderText="कज लिस्ट प्रकार" />
                                        
                                        
                                        
                                    </Columns>
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#999999" />
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                </asp:GridView>
                                <%--</div>--%>
                            </asp:Panel>
                            <%--<input id="hdnFld" type="hidden" />--%>
                        </td>
                    </tr>
                </table>
               
                
            </td>
            
        </tr>
        
        
        <tr>
            <td colspan="6">
                <asp:UpdatePanel id="UP1" runat="server">
                    <contenttemplate>
<TABLE><TBODY><TR><TD style="WIDTH: 120px" vAlign=top>&nbsp;<asp:Label id="Label4as" runat="server" Text="बेन्चहरु" SkinID="Unicodelbl" __designer:wfdid="w1"></asp:Label></TD><TD style="WIDTH: 170px" vAlign=top>&nbsp;<asp:ListBox id="lstBench" runat="server" Width="160px" Height="150px" __designer:wfdid="w2" OnSelectedIndexChanged="lstBench_SelectedIndexChanged" AutoPostBack="True">
                        </asp:ListBox></TD><TD style="WIDTH: 15px"></TD><TD style="WIDTH: 50px" vAlign=top>
                        <asp:Label id="Label2" runat="server" Text="न्यायधिश" SkinID="Unicodelbl" __designer:wfdid="w3"></asp:Label></TD><TD><asp:ListBox id="lstJudges" runat="server" Width="160px" Height="150px" __designer:wfdid="w4" DataTextField="JUDGENAME" DataValueField="JUDGE_ID"></asp:ListBox></TD><TD></TD></TR><TR><TD style="HEIGHT: 48px">&nbsp;<asp:Label id="Label1" runat="server" Text="प्राथमिक" SkinID="Unicodelbl" __designer:wfdid="w5"></asp:Label></TD><TD style="HEIGHT: 48px">&nbsp;<asp:TextBox id="txtPriority" runat="server" Width="30px" MaxLength="2" __designer:wfdid="w1"></asp:TextBox>
                         <%--<asp:DropDownList id="ddlPriority" runat="server" Width="160px" SkinID="Unicodeddl">
                    <asp:ListItem Value="0">छान्नुहोस्</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                </asp:DropDownList>--%>
                 <asp:Button id="btnAddCaseBenchAssignment" onclick="btnAddCaseBenchAssignment_Click" runat="server" Text="+" SkinID="Add" OnClientClick="return ValidateADD();" __designer:wfdid="w7" Visible="False"></asp:Button> <ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender1" runat="server" TargetControlID="txtPriority" __designer:wfdid="w2" FilterType="Numbers"></ajaxToolkit:FilteredTextBoxExtender></TD><TD style="WIDTH: 7px; HEIGHT: 48px"></TD><TD style="HEIGHT: 48px"></TD><TD style="WIDTH: 10px; HEIGHT: 48px"></TD><TD style="HEIGHT: 48px"></TD></TR></TBODY></TABLE>
                <asp:GridView id="grdCaseBenchAssignment" runat="server" Width="983px" SkinID="Unicodegrd" __designer:dtid="281474976710718" OnRowDataBound="grdCaseBenchAssignment_RowDataBound" ForeColor="#333333" CellPadding="0" AutoGenerateColumns="False" __designer:wfdid="w1">
<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
<asp:BoundField DataField="CaseID" HeaderText="CaseID"></asp:BoundField>
<asp:BoundField DataField="RegNo" HeaderText="दर्ता नं" ItemStyle-Width="90px"></asp:BoundField>
<asp:BoundField DataField="CaseNo" HeaderText="मुद्दा नं" ItemStyle-Width="90px"></asp:BoundField>
<asp:BoundField DataField="CaseTypeName" HeaderText="मुद्दाको प्रकार" ItemStyle-Width="100px"></asp:BoundField>
<asp:BoundField DataField="RegistrationDiary" HeaderText="दर्ता किताब" />
<asp:BoundField DataField="SubjectName" HeaderText="विषय" />
<asp:BoundField DataField="RegDiaryNameDesc" HeaderText="विवरण" ItemStyle-Width="100px" />
<asp:BoundField DataField="Priority" HeaderText="प्राथमिकता" />
<asp:BoundField DataField="Appelant" HeaderText="वादिहारु" ItemStyle-Width="100px"></asp:BoundField>
<asp:BoundField DataField="Respondant" HeaderText="प्रतिवादिहारु" ItemStyle-Width="100px"></asp:BoundField>
<asp:BoundField DataField="ClDate" HeaderText="सुनवाई मिति"></asp:BoundField>
<asp:BoundField DataField="ClEntryTypeName" HeaderText="कज लिस्ट प्रकार"></asp:BoundField>
</Columns>

<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> 
</contenttemplate>
                </asp:UpdatePanel></td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="4">
                <table>
                    <tr>
                        <td style="height: 29px">
                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" SkinID="Normal" Text="Save" OnClientClick="return ValidateADD();" /></td>
                        <td style="height: 29px">
                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" SkinID="Cancel"
                                Text="Cancel" /></td>
                    </tr>
                </table>
            </td>
            <td>
            </td>
        </tr>
    </table>
    </div>
</asp:Content>

