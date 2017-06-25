<%@ Page Language="C#" MasterPageFile="~/MODULES/LJMS/LJMSMasterPage.master" AutoEventWireup="true" CodeFile="JudgeWorkInspection.aspx.cs" Inherits="MODULES_LJMS_Forms_JudgeWorkInspection" Title="LJMS | Judge Work Inspection" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <%--<asp:UpdatePanel id="UpdatePanel3" runat="server">
            <triggers>
                <asp:AsyncPostBacktrigger ControlID="btnSearch" EventName="Click" />
                <asp:PostBacktrigger ControlID="grdEmployee"/>
            </triggers>
                <contenttemplate>--%>
    <asp:UpdatePanel runat="server">
    
    </asp:UpdatePanel>
<asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup" runat="server"></asp:Button><ajaxtoolkit:modalpopupextender id="programmaticModalPopup" runat="server" backgroundcssclass="modalBackground" behaviorid="programmaticModalPopupBehavior" dropshadow="true" popupcontrolid="programmaticPopup" popupdraghandlecontrolid="programmaticPopupDragHandle" repositionmode="RepositionOnWindowScroll" targetcontrolid="hiddenTargetControlForModalPopup"> </ajaxtoolkit:modalpopupextender> <asp:Panel style="PADDING-RIGHT: 10px; DISPLAY: none; PADDING-LEFT: 10px; PADDING-BOTTOM: 10px; WIDTH: 350px; PADDING-TOP: 10px" id="programmaticPopup" runat="server" CssClass="modalPopup">
            
            <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="border-right: gray 1px solid;
                border-top: gray 1px solid; border-left: gray 1px solid; cursor: move; color: black;
                border-bottom: gray 1px solid; background-color: #dddddd; text-align: center">
                Status
            </asp:Panel>
            
        <br />
<asp:Label id="lblStatusMessage" runat="server" Height="19px" Text="Label"></asp:Label> 

            <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
                Text="OK" Width="58px" />
            <br />
        </asp:Panel> <br />
        
        <table width="1000">
        <tr>
        <td style="WIDTH: 200px"><asp:Label id="Label6" runat="server" Width="128px" SkinID="Unicodelbl" Font-Bold="False" Text="कार्यालय"></asp:Label></td><td><asp:DropDownList id="ddlCourt" runat="server" Width="336px" SkinID="Unicodeddl" AutoPostBack="true" OnSelectedIndexChanged="ddlCourt_SelectedIndexChanged">
                </asp:DropDownList></td></tr><tr><td><asp:Label id="lblJudgeName" runat="server" Width="128px" SkinID="Unicodelbl" Font-Bold="False" Text="न्यायाधिशको नाम"></asp:Label></td><td><asp:DropDownList id="ddlJudgeList" runat="server" Width="338px" SkinID="Unicodeddl" AutoPostBack="true" OnSelectedIndexChanged="ddlJudgeList_SelectedIndexChanged">
                </asp:DropDownList></td></tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr><td colspan=2>
                
                
                <asp:Panel id="Panel2" runat="server" CssClass="collapsePanelHeader" Width="85%" Height="30px">
                    <div style="cursor: pointer; vertical-align: middle;">
                        <div style="float: left;width:620px">
                            निरीक्षणकर्ता खोज्नुहोस
                        </div>
                    </div>
                </asp:Panel>
                
                
                 </td>
                 </tr>
                 <tr>
                 <td colspan="2"  valign="top"> 
                <asp:Panel id="Panel3" runat="server" Width="100%" >
                <table width="100%" >
                
                    <tr>
                        <td style="WIDTH: 150px;">
                        <asp:Label id="Label30" runat="server" SkinID="Unicodelbl" Font-Bold="False" Text="संकेत नं">
                        </asp:Label></td>
                        <td style="WIDTH: 150px;">
                        <asp:TextBox id="txtSymbolNo" runat="server" Width="130px" SkinID="Unicodetxt" MaxLength="15" ToolTip="First Name"></asp:TextBox>
                        </td>
                        <td style="WIDTH: 50px;">
                        </td>
                        <td style="WIDTH: 150px;">
                        </td>
                        <td style="WIDTH: 150px;">
                        </td>
                        <td style="WIDTH: 50px">
                        </td>
                        <td style="WIDTH: 150px">
                        </td>
                        <td style="WIDTH: 150px">
                        </td>
                        </tr>
                        <tr>
                        <td style="WIDTH: 150px">
                        <asp:Label id="Label1" runat="server" SkinID="Unicodelbl" Font-Bold="False" Text="पहिलो नाम">
                        </asp:Label>
                        </td>
                        <td>
                        <asp:TextBox id="txtFName" runat="server" Width="130px" SkinID="Unicodetxt" MaxLength="35" ToolTip="First Name"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                        <td>
                        <asp:Label id="Label2" runat="server" SkinID="Unicodelbl" Font-Bold="False" Text="बिचको नाम"></asp:Label>
                        </td>
                        <td>
                        <asp:TextBox id="txtMName" runat="server" Width="130px" SkinID="Unicodetxt" MaxLength="15"></asp:TextBox>
                        </td>
                        <td align="center">
                        </td>
                        <td align="center">
                        <asp:Label id="Label3" runat="server" Height="22px" SkinID="Unicodelbl" Font-Bold="False" Text="थर"></asp:Label>
                        </td>
                        <td>
                        <asp:TextBox id="txtSurName" runat="server" SkinID="Unicodetxt" MaxLength="35" ToolTip="Surname"></asp:TextBox>
                        </td>
                        </tr>
                        <tr>
                        <td style="WIDTH: 150px">
                        <asp:Label id="Label5" runat="server" SkinID="Unicodelbl" Font-Bold="False" Text="लिंग"></asp:Label>
                        </td>
                        <td>
                        <asp:DropDownList id="ddlGender" runat="server" Width="135px" SkinID="Unicodeddl">
                                <asp:ListItem Value="SG">छान्नुहोस</asp:ListItem>
                                <asp:ListItem Value="M">पुरूष</asp:ListItem>
                                <asp:ListItem Value="F">महिला</asp:ListItem>
                                <asp:ListItem Value="O">अन्य</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                            <td>
                            </td>
                            <td>
                            <asp:Label id="Label4" runat="server" SkinID="Unicodelbl" Font-Bold="False" Text="जन्म मिति"></asp:Label>
                            </td>
                            <td>
                            <asp:TextBox id="txtdOB" runat="server" Width="130px" MaxLength="10"></asp:TextBox>
                             <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender2" runat="server" TargetControlID="txtdOB" MaskType="Date" Mask="9999/99/99" AutoComplete="False">
                            </ajaxToolkit:MaskedEditExtender> 
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            <asp:Button id="btnSearch" onclick="btnSearch_Click" runat="server" Width="68px" Text="Search"></asp:Button> 
                            <asp:Button id="btnSearchCancel" onclick="btnSearchCancel_Click" runat="server" Width="68px" Text="Cancel"></asp:Button>
                            </td>
                            </tr>
                         <tr>
                            <td colspan="8">
                               <asp:Label id="lblSearch" runat="server" Font-Bold="true">
                </asp:Label> 
               <asp:Panel id="Panel1" runat="server" Width="90%" ScrollBars="auto" >
                    <asp:GridView id="grdEmployee" runat="server" SkinID="Unicodegrd" ForeColor="#333333" OnSelectedIndexChanged="grdEmployee_SelectedIndexChanged" CellPadding="0" AutoGenerateColumns="False" OnRowDataBound="grdEmployee_RowDataBound">
                        <Columns>
                        <asp:BoundField DataField="EMPID" HeaderText="EMPLOYEE ID"></asp:BoundField>
                        <asp:BoundField DataField="SYMBOLNO" HeaderText="संकेत नं"></asp:BoundField>
                        <asp:BoundField DataField="FIRSTNAME" HeaderText="FIRST NAME"></asp:BoundField>
                        <asp:BoundField DataField="MIDDLENAME" HeaderText="MIDDLE NAME"></asp:BoundField>
                        <asp:BoundField DataField="SURNAME" HeaderText="SURNAME"></asp:BoundField>
                        <asp:BoundField DataField="RDFULLNAME" HeaderText="पुरा नाम थर"></asp:BoundField>
                        <asp:BoundField DataField="RDGENDER" HeaderText="लिंग"></asp:BoundField>
                        <asp:BoundField DataField="DOB" HeaderText="जन्म मिति">                        
                        </asp:BoundField>
                        <asp:BoundField DataField="RDMARITALSTATUS" HeaderText="बैबाहिक सम्बन्ध"></asp:BoundField>
                        <asp:BoundField DataField="FATHERNAME" HeaderText="बाबुको नाम"></asp:BoundField>
                        <asp:BoundField DataField="GFATHERNAME" HeaderText="बबाजेको नाम"></asp:BoundField>
                        <asp:CommandField ShowSelectButton="true">                       
                        </asp:CommandField>
                        </Columns>
                        
                        </asp:GridView> 
                </asp:Panel>  
                            </td>
                         </tr>
                            </table>
                 </asp:Panel>
                           </td>
                           </tr>
                           <tr>
                           <td  colspan="2">
                           
                
                           <ajaxToolkit:CollapsiblePanelExtender id="cpeDemo" 
                           runat="Server" 
                           SkinID="CollapsiblePanelDemo" 
                           CollapseControlID="Panel2" 
                           Collapsed="true" 
                           ExpandControlID="Panel2" 
                            SuppressPostBack="true" 
                           TextLabelID="Label1" 
                           TargetControlID="Panel3">
                            </ajaxToolkit:CollapsiblePanelExtender>
                              </td>
                              </tr>
                              <tr>
                              <td></td><td></td></tr><tr><td><asp:Label id="lblInspector" runat="server" Width="139px" SkinID="Unicodelbl" Font-Bold="False">निरीक्षणकर्ताको नाम</asp:Label></td><td><asp:TextBox id="txtInspection" runat="server" Width="410px" SkinID="Unicodetxt" ReadOnly="true"></asp:TextBox></td></tr><tr><td><asp:Label id="lblInspectionDate" runat="server" Width="40px" SkinID="Unicodelbl" Font-Bold="False" Text="मिति"></asp:Label> </td><td><asp:TextBox id="txtInspectionDate" runat="server" Width="110px" SkinID="Unicodetxt"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender1" runat="server" TargetControlID="txtInspectionDate" MaskType="Date" Mask="9999/99/99" AutoComplete="False">
                </ajaxToolkit:MaskedEditExtender> </td></tr><tr><td style="height: 26px"><asp:Label id="lblFiscalYear" runat="server" Width="40px" SkinID="Unicodelbl" Font-Bold="False">आ. व.</asp:Label></td><td style="height: 26px"><asp:TextBox id="txtFiscalYear" runat="server" Width="53px" SkinID="Unicodetxt" AutoPostBack="true" OnTextChanged="txtFiscalYear_TextChanged" MaxLength="5"></asp:TextBox></td></tr><tr><td><asp:Label id="lblWork" runat="server" Width="170px" SkinID="Unicodelbl" Font-Bold="False" Text="सम्पादित कामको स्थिति"></asp:Label></td><td><asp:DropDownList id="ddlWorkList" runat="server" Width="100%" SkinID="Unicodeddl">
                </asp:DropDownList></td></tr><tr><td colspan="2"><table width="100%"><tr><td style="WIDTH: 19%"><asp:Label id="lblDone" runat="server" Width="170px" SkinID="Unicodelbl" Font-Bold="False" Text="भएको छ वा छैन"></asp:Label></td><td style="WIDTH: 25%"><asp:CheckBox id="chkDone" runat="server" Width="90px" AutoPostBack="true" Checked="true" OnCheckedChanged="chkDone_CheckedChanged"></asp:CheckBox></td><td style="WIDTH: 25%"><asp:Label id="lblNoOfCases" runat="server" Width="245px" SkinID="Unicodelbl" Font-Bold="False" Text="नभएकोमा कतिवटा मद्दामा त्यस्तो देखिएको"></asp:Label></td><td style="WIDTH: 25%"><asp:TextBox id="txtNoOfCases" runat="server" Width="80px" SkinID="Unicodetxt" MaxLength="4"></asp:TextBox> <ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender1" runat="server" TargetControlID="txtNoOfCases" FilterMode="ValidChars" FilterType="Numbers">
                            </ajaxToolkit:FilteredTextBoxExtender>
                             </td></tr><tr><td><asp:Label id="lblInspectionCaseNo" runat="server" Width="199px" SkinID="Unicodelbl" Font-Bold="False" Text="निरीक्षण गरिएको मिसिल वा मुद्दा नं"></asp:Label></td><td><asp:TextBox id="txtInspectionCaseNo" runat="server" Width="85px" SkinID="Unicodetxt" MaxLength="10"></asp:TextBox></td><td><asp:Label id="lblNoDoneReason" runat="server" Width="190px" SkinID="Unicodelbl" Font-Bold="False" Text="नभएकोमा देखाईएको कारण"></asp:Label></td><td><asp:TextBox id="txtNoDoneReason" runat="server" Width="275px" SkinID="Unicodetxt" MaxLength="300" TextMode="MultiLine"></asp:TextBox></td></tr><tr><td><asp:Label id="lblIsReasonValid" runat="server" Width="152px" SkinID="Unicodelbl" Font-Bold="False" Text="कारण उचित छ / छैन"></asp:Label></td><td><asp:CheckBox id="chkIsReasonValid" runat="server" Width="50px"></asp:CheckBox></td><td><asp:Label id="lblRemarks" runat="server" SkinID="Unicodelbl" Font-Bold="False" Text="कैफियत"></asp:Label></td><td><asp:TextBox id="txtremarks" runat="server" Width="277px" SkinID="Unicodetxt" MaxLength="300" TextMode="MultiLine"></asp:TextBox></td></tr></table><asp:Button id="btnAdd" onclick="btnAdd_Click" runat="server" Text="Add"></asp:Button></td></tr><tr><td colspan="2">
                            <asp:Panel id="Panel4" runat="server" Width="100%" Height="250px" ScrollBars="Auto">    
                    <asp:GridView ID="grdWorkInspectionDetails" runat="server" 
                         AutoGenerateColumns="False" OnSelectedIndexChanged="grdWorkInspectionDetails_SelectedIndexChanged"
                         OnRowDataBound="grdWorkInspectionDetails_RowDataBound"
                         SkinID="Unicodegrd" 
                         CellPadding="4" 
                         ForeColor="#333333" 
                         GridLines="None" OnRowDeleting="grdWorkInspectionDetails_RowDeleting">
                        <Columns>
                            <asp:BoundField DataField="EmployeeID" HeaderText="Employee ID" />
                            <asp:BoundField DataField="FiscalYear" HeaderText="आ. व." />
                            <asp:BoundField DataField="JwcID" HeaderText="JwcID" />
                            <asp:BoundField DataField="JwcName" HeaderText="सम्पादित कामको स्थिति" />
                            <asp:CheckBoxField DataField="WorkDone" HeaderText="भएको छ वा छैन" />
                            <asp:BoundField DataField="NoOfCase" HeaderText="नभएको कतिवटा मुद्दामा त्यस्तो देखिएको" />
                            <asp:BoundField DataField="InspectionCaseNo" HeaderText="निरीक्षण गरिएको मिसिल वा मद्दा नं" />
                            <asp:BoundField DataField="NoDoneReason" HeaderText="नभएकोमा देखाइएको कारण" />
                            <asp:CheckBoxField DataField="IsReasonValid" HeaderText="कारण उचित छ / छैन" />
                            <asp:BoundField DataField="Remarks" HeaderText="कैफियत" />
                            <asp:BoundField DataField="Action" HeaderText="Action" />
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:TemplateField>
                                <EditItemTemplate>
                                    <asp:Button ID="btnDelete" CommandName="Delete" runat="server" Text="Delete" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Button ID="btnDelete" CommandName="Delete" runat="server" Text="Delete" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                     
                    </asp:GridView>
                </asp:Panel> </td></tr><tr><td><asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Text="Save" Visible="False"></asp:Button><asp:Button id="btnCancel" onclick="btnCancel_Click" runat="server" Text="Cancel" Visible="False"></asp:Button></td><td></td></tr><tr><td></td><td></td></tr><tr><td></td><td></td></tr></table>
<%--</contenttemplate>
    </asp:UpdatePanel>--%>
</asp:Content>

