<%@ Page Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" AutoEventWireup="true" CodeFile="TameliFeedBack.aspx.cs" Inherits="MODULES_CMS_Tameli_TameliFeedBack" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<!-- required snowstorm JS, default behaviour -->
<script type="text/javascript" src="accessories/SnowStorm.js"></script>

<!-- now, we'll customize the snowStorm object -->
<script type="text/javascript">
snowStorm.snowColor = '#99ccff'; // blue-ish snow!?
snowStorm.flakesMaxActive = 196;  // show more snow on screen at once
snowStorm.useTwinkleEffect = true; // let the snow flicker in and out of view
snowStorm.followMouse = true;//Allows snow to move dynamically with the "wind", relative to the mouse's X (left/right) coordinates.
</script>


    <asp:ScriptManager runat="server" id="scrptmngr1">
    </asp:ScriptManager>
<asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />

<ajaxtoolkit:modalpopupextender
    id="programmaticModalPopup" runat="server" backgroundcssclass="modalBackground" 
     dropshadow="True" popupcontrolid="programmaticPopup"
    popupdraghandlecontrolid="programmaticPopupDragHandle" repositionmode="RepositionOnWindowScroll"
    targetcontrolid="hiddenTargetControlForModalPopup">
</ajaxtoolkit:modalpopupextender>
<asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="padding-right: 10px;
        display: none; padding-left: 10px; padding-bottom: 10px; width: 350px; padding-top: 10px">
        
        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="border-right: gray 1px solid;
            border-top: gray 1px solid; border-left: gray 1px solid; cursor: move; color: black;
            border-bottom: gray 1px solid; background-color: #dddddd; text-align: center">
            <asp:Label ID="lblStatus" runat="server" Text="Label"></asp:Label>&nbsp;</asp:Panel>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
            Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    <table width="1000">
        <tr>
            <td colspan="5">
                <asp:GridView ID="grdTameli" runat="server" AutoGenerateColumns="False" CellPadding="0"
                    ForeColor="#333333" 
                    SkinID="Unicodegrd" Width="983px" OnRowDataBound="grdTameli_RowDataBound" OnSelectedIndexChanged="grdTameli_SelectedIndexChanged">
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:BoundField DataField="CaseTypeID" HeaderText="Case Type ID" />
                        <asp:BoundField DataField="CaseRegDate" HeaderText="दर्ता मिति" />
                        <asp:BoundField DataField="CaseID" HeaderText="CaseID" />
                        <asp:BoundField DataField="RegNo" HeaderText="दर्ता नं" />
                        <asp:BoundField DataField="CaseNo" HeaderText="मुद्दा नं" />
                        <asp:BoundField DataField="CaseTypeName" HeaderText="मुद्दाको प्रकार" />
                        <asp:BoundField DataField="SubjectName" HeaderText="SubjectName" />
                        <asp:BoundField DataField="OrgName" HeaderText="Organisation" />
                        <asp:BoundField DataField="TameliTypeName" HeaderText="Tameli Type" />
                        <asp:BoundField DataField="WitnessFullName" HeaderText="Witness Person" />
                        <asp:BoundField DataField="LitigantName" HeaderText="Litigant " />
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                                    Text="Select"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <EditRowStyle BackColor="#999999" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 100px;" valign="top" >
                <asp:Label ID="Label4" runat="server" SkinID="Unicodelbl" Text="Tameli Date"></asp:Label></td>
            <td style="width: 200px; height: 19px" valign="top" >
                <asp:TextBox ID="txtTameliDate" runat="server" MaxLength="35" SkinID="Unicodetxt"
                    Width="130px"></asp:TextBox>
                <ajaxToolkit:maskededitextender id="Maskededitextender1" runat="server" autocomplete="False"
                            mask="9999/99/99" masktype="Date" targetcontrolid="txtTameliDate" ClearMaskOnLostFocus="False">
                </ajaxToolkit:MaskedEditExtender>
            </td>
            <td style="width: 100px; height: 19px" >
                </td>
            <td style="width: 80px; height: 19px" valign="top" >
                &nbsp;<asp:Label ID="Label3" runat="server" SkinID="Unicodelbl" Text="Section Clerk  Received Date" Width="192px"></asp:Label></td>
            <td style="width: 630px; height: 19px" valign="top" >
                <ajaxToolkit:maskededitextender id="Maskededitextender2" runat="server" autocomplete="False"
                            mask="9999/99/99" masktype="Date" targetcontrolid="txtSecClrkRcvdDate" ClearMaskOnLostFocus="False">
                </ajaxToolkit:MaskedEditExtender>
                <asp:TextBox ID="txtSecClrkRcvdDate" runat="server" MaxLength="35" SkinID="PCStxt"
                    Width="130px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px" valign="top">
                <asp:Label ID="Label2" runat="server" SkinID="Unicodelbl" Text="Successful"
                    Width="67px"></asp:Label></td>
            <td style="width: 200px; height: 19px" valign="top">
                <asp:RadioButtonList ID="rdblstTameliSuccess" runat="server" RepeatDirection="Horizontal" SkinID="Unicoderadio" AutoPostBack="True" OnSelectedIndexChanged="rdblstTameliSuccess_SelectedIndexChanged">
                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                    <asp:ListItem Value="N">No</asp:ListItem>
                </asp:RadioButtonList></td>
            <td style="width: 100px; height: 19px">
            </td>
            <td style="width: 66px; height: 19px" valign="top">
                <asp:Label ID="lblTameliStatus" runat="server" SkinID="Unicodelbl" Text="Tameli Status" Width="109px"></asp:Label></td>
            <td style="width: 630px; height: 19px" valign="top">
                <asp:DropDownList ID="ddlTameliStatus" runat="server" DataTextField="TameliStatusName"
                    DataValueField="TameliStatusID" SkinID="Unicodeddl" Width="150px" AutoPostBack="True">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="5" style="height: 19px" valign="top">
            <asp:Panel id="pnlTamWitPerson" runat="server" Width="100%">
                     <TABLE><TBODY><TR><TD style="WIDTH: 155px" vAlign=top><asp:Label id="Label6" runat="server" Width="146px" Text="Tameli Witness Person" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 100px" vAlign=top><asp:TextBox id="txtTameliWitnessPerson" runat="server" Width="250px" SkinID="Unicodetxt" MaxLength="100"></asp:TextBox></TD><TD style="WIDTH: 60px" vAlign=top></TD><TD style="WIDTH: 40px" vAlign=top><asp:Label id="Label8" runat="server" Width="42px" Height="16px" Text="पद" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 7px" vAlign=top><asp:TextBox id="txtPost" runat="server" Width="203px" SkinID="Unicodetxt" MaxLength="50"></asp:TextBox></TD>
                         <td style="width: 50px" valign="top">
                             <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="+" /></td>
                     </TR></TBODY></TABLE>
                <asp:GridView ID="grdWitPerson" runat="server" AutoGenerateColumns="False" OnRowDeleting="grdWitPerson_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="FullName" HeaderText="Name" />
                        <asp:BoundField DataField="Post" HeaderText="Post" />
                        <asp:CommandField ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
                     </asp:Panel>   
               
            </td>
        </tr>
        <tr>
            <td valign="top" >
                <asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="Remarks"></asp:Label></td>
            <td valign="top" >
                <asp:TextBox ID="txtTameliRemarks" runat="server" MaxLength="1000" SkinID="Unicodetxt" TextMode="MultiLine" Width="225px"></asp:TextBox></td>
            <td style="width: 100px" >
                </td>
            <td style="width: 66px" >
            </td>
            <td style="width: 150px" >
            </td>
        </tr>
        <tr>
            <td >
            </td>
            <td >
                <table>
                    <tr>
                        <td style="height: 26px" valign="top">
                            <asp:Button ID="Button1" runat="server" OnClick="btnSave_Click" SkinID="Normal" Text="Save" />
                        </td>
                        <td style="height: 26px" valign="top">
                            <asp:Button ID="Button2" runat="server" OnClick="btnCancel_Click" OnClientClick="return confirm('Are you sure you want to cancel ?');"
                                SkinID="Cancel" Text="Cancel" />
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 100px" >
            </td>
            <td style="width: 66px" >
            </td>
            <td style="width: 150px" >
            </td>
        </tr>
        <tr>
            <td colspan="5">
                &nbsp;<asp:Panel ID="pnlDelete" runat="server" CssClass="collapsePanelHeader" Width="1000px">
                    Delete Tameli Info Saved
                </asp:Panel>
                <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender2" runat="server"
                    CollapseControlID="pnlDelete" CollapsedImage="../../COMMON/Images/expand_blue.jpg"
                    ExpandControlID="pnlDelete" ExpandedImage="../../COMMON/Images/collapse_blue.jpg"
                    SkinID="CollapsiblePanelDemo" SuppressPostBack="True" TargetControlID="pnlDeleteIssuedTameli">
                </ajaxToolkit:CollapsiblePanelExtender>
                <asp:Panel ID="pnlDeleteIssuedTameli" runat="server" Width="1000px">
                    &nbsp;<asp:GridView ID="grdTam" runat="server" AutoGenerateColumns="False" CellPadding="0"
                        ForeColor="#333333" OnRowDataBound="grdTam_RowDataBound" SkinID="Unicodegrd"
                        Width="983px" OnRowDeleting="grdTam_RowDeleting">
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="CaseTypeID" HeaderText="Case Type ID" />
                            <asp:BoundField DataField="CaseRegDate" HeaderText="दर्ता मिति" />
                            <asp:BoundField DataField="CaseID" HeaderText="CaseID" />
                            <asp:BoundField DataField="RegNo" HeaderText="दर्ता नं" />
                            <asp:BoundField DataField="CaseNo" HeaderText="मुद्दा नं" />
                            <asp:BoundField DataField="CaseTypeName" HeaderText="मुद्दाको प्रकार" />
                            <asp:BoundField DataField="SubjectName" HeaderText="SubjectName" />
                            <asp:BoundField DataField="OrgName" HeaderText="Organisation" />
                            <asp:BoundField DataField="TamildaarName" HeaderText="Tamildaar Name" />
                            <asp:BoundField DataField="TameliDate" HeaderText="TameliDate" />
                            <asp:BoundField DataField="TameliTypeName" HeaderText="Tameli Type" />
                            <asp:BoundField DataField="WitnessFullName" HeaderText="Witness Person" />
                            <asp:BoundField DataField="LitigantName" HeaderText="Litigant " />
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                        Text="Delete"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <EditRowStyle BackColor="#999999" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
