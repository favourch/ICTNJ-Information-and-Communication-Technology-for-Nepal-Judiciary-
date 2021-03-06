<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true" CodeFile="InvDonationPurchases.aspx.cs" Inherits="MODULES_OAS_Inventory_Forms_InvDonationPurchases" Title="OAS | Donation Purchase" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" src="../../../COMMON/JS/Validation.js" type="text/javascript"/>
<script language="javascript" src="../../../COMMON/JS/DateValidator.js" type="text/javascript"/>
<asp:ScriptManager ID="SMInvTransaction" runat="server"></asp:ScriptManager>
  <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground"
        BehaviorID="programmaticModalPopupBehavior" DropShadow="True" PopupControlID="programmaticPopup"
        PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
        TargetControlID="hiddenTargetControlForModalPopup">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="padding-right: 10px;
        display: none; padding-left: 10px; padding-bottom: 10px; width: 350px; padding-top: 10px">
        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="border-right: gray 1px solid;
            border-top: gray 1px solid; border-left: gray 1px solid; cursor: move; color: black;
            border-bottom: gray 1px solid; background-color: #dddddd; text-align: center">
            Save Status
        </asp:Panel>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
            Text="OK" Width="58px" /></asp:Panel> 

    <table style="width: 940px">
        <tr>
            <td colspan="6" style="height: 21px" valign="top">
                <asp:Label ID="lblStatus" runat="server" SkinID="Unicodelbl"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 40px" valign="top">
                <asp:Label ID="lblCategoryItems" runat="server" SkinID="Unicodelbl" Text="समुह" Width="45px"></asp:Label></td>
            <td valign="top" style="width: 290px">
                <asp:DropDownList ID="DDLItemsCategory_Rqd" runat="server" AutoPostBack="True" SkinID="Unicodeddl"
                    ToolTip="समुह" Width="140px" OnSelectedIndexChanged="DDLItemsCategory_Rqd_SelectedIndexChanged">
                </asp:DropDownList></td>
            <td style="width: 80px" valign="top">
                <asp:Label ID="lblItemsSubCategory" runat="server" SkinID="Unicodelbl" Text="ऊप समुह" Width="66px"></asp:Label></td>
            <td valign="top">
                <asp:DropDownList ID="DDLItemsSubCategory_Rqd" runat="server" AutoPostBack="True"
                    SkinID="Unicodeddl" ToolTip="ऊप समुह" Width="140px" OnSelectedIndexChanged="DDLItemsSubCategory_Rqd_SelectedIndexChanged">
                </asp:DropDownList></td>
            <td style="width: 60px" valign="top">
                <asp:Label ID="lblItems" runat="server" SkinID="Unicodelbl" Text="सामान" Width="48px"></asp:Label></td>
            <td valign="top">
                <asp:DropDownList ID="DDLItems_Rqd" runat="server" SkinID="Unicodeddl" ToolTip="सामान"
                    Width="230px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 40px" valign="top">
                <asp:Label ID="lblQuantity" runat="server" SkinID="Unicodelbl" Text="संख्या" Width="45px"></asp:Label></td>
            <td valign="top" style="width: 290px">
                <asp:TextBox ID="txtQuantity_Rqd" runat="server" SkinID="Unicodetxt" ToolTip="संख्या"
                    Width="78px" MaxLength="5"></asp:TextBox>
                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtQuantity_Rqd" FilterType="Numbers">
                </ajaxToolkit:FilteredTextBoxExtender>
            </td>
            <td style="width: 80px" valign="top">
                <asp:Label ID="lblDonation" runat="server" SkinID="Unicodelbl" Text="डोनेसन" Width="54px"></asp:Label></td>
            <td valign="top">
                <asp:CheckBox ID="chkDonation" runat="server" SkinID="smallChk" ToolTip="डोनेसन" OnCheckedChanged="chkDonation_CheckedChanged" AutoPostBack="True" /></td>
            <td style="width: 60px" valign="top">
                <asp:Label ID="lblPrice" runat="server" Text="मू्ल्य" SkinID="Unicodelbl" Width="45px"></asp:Label></td>
            <td valign="top">
                <asp:TextBox ID="txtPrice" runat="server" MaxLength="10" ToolTip="मू्ल्य" Width="89px"></asp:TextBox>
                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                    TargetControlID="txtPrice" FilterType="Numbers">
                </ajaxToolkit:FilteredTextBoxExtender>
            </td>
        </tr>
        <tr>
            <td style="width: 40px" valign="top">
                <asp:Label ID="lblOrganization" runat="server" SkinID="Unicodelbl" Text="कार्यालय"
                    Width="59px"></asp:Label></td>
            <td valign="top" style="width: 290px">
                <asp:TextBox ID="txtOrganization_Rqd" runat="server" SkinID="Unicodetxt" ToolTip="कार्यालय" Width="240px"></asp:TextBox></td>
            <td style="width: 80px" valign="top">
                <asp:Label ID="lblDonationPurchaseDate" runat="server" SkinID="Unicodelbl" Text="डोनेसन मिति" Width="96px"></asp:Label></td>
            <td valign="top">
                <asp:TextBox ID="txtDonationPurchaseDate_RDT" runat="server" SkinID="Unicodetxt"
                    Width="100px" ToolTip="डोनेसन/खरिद मिति"></asp:TextBox>
                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="9999/99/99"
                    MaskType="Date" TargetControlID="txtDonationPurchaseDate_RDT" AutoComplete="False">
                </ajaxToolkit:MaskedEditExtender>
                &nbsp;
            </td>
            <td style="width: 60px" valign="top">
            </td>
            <td valign="top">
            </td>
        </tr>
        <tr>
            <td style="width: 40px" valign="top">
                <asp:Label ID="lblReceivedBy" runat="server" SkinID="Unicodelbl" Text="लिने को नाम"
                    Width="91px"></asp:Label></td>
            <td valign="top" style="width: 290px">
                <asp:TextBox ID="txtReceivedBy_Rqd" runat="server" SkinID="Unicodetxt" ToolTip="लिने को नाम"
                    Width="227px"></asp:TextBox></td>
            <td style="width: 80px" valign="top">
                <asp:Label ID="lblReceivedDate" runat="server" Text="लिएको मिति" SkinID="Unicodelbl" Width="90px"></asp:Label></td>
            <td valign="top">
                <asp:TextBox ID="txtReceivedDate_RDT" runat="server" SkinID="Unicodetxt" ToolTip="लिएको मिति" Width="100px"></asp:TextBox>
                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="9999/99/99"
                    MaskType="Date" TargetControlID="txtReceivedDate_RDT" AutoComplete="False">
                </ajaxToolkit:MaskedEditExtender>
            </td>
            <td style="width: 60px" valign="top">
            </td>
            <td valign="top">
                <asp:TextBox ID="txtEmpID" runat="server" Visible="False" Width="93px"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="6" valign="top">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" SkinID="Normal" OnClick="btnSubmit_Click" OnClientClick="javascript:return validate(1);" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" SkinID="Cancel" OnClick="btnCancel_Click" /></td>
        </tr>
        <tr>
            <td colspan="6" valign="top" style="height: 251px">            
             <div id="addressGridHeader" class="headerDiv" style="height: 20px; -moz-border-radius: 5px;
                    background-color: #307196">
                    <asp:Label ID="addGridLbl" runat="server" Style="color: #fff;
                        font-weight: bold; text-decoration: underline">कार्यलय छानुहोस</asp:Label></div>
                <div class="contentDivAddress" style="display: none">
                    &nbsp; &nbsp;
                    <br />
                    <table style="width: 569px">
                        <tr>
                            <td style="width: 95px" valign="top">
                                <asp:Label ID="lblFirstName" runat="server" Text="पहिलो नाम" SkinID="Unicodelbl" Width="86px"></asp:Label></td>
                            <td style="width: 320px" valign="top">
                                <asp:TextBox ID="txtFirstName" runat="server" SkinID="Unicodetxt" ToolTip="पहिलो नाम" Width="115px"></asp:TextBox></td>
                            <td style="width: 100px" valign="top">
                                <asp:Label ID="lblMiddleName" runat="server" Text="बिचको नाम" SkinID="Unicodelbl" Width="89px"></asp:Label></td>
                            <td valign="top" style="width: 175px">
                                <asp:TextBox ID="txtMiddleName" runat="server" SkinID="Unicodetxt" ToolTip="बिचको नाम" Width="139px"></asp:TextBox></td>
                            <td valign="top" style="width: 45px">
                                <asp:Label ID="lblLastName" runat="server" Text="थर" SkinID="Unicodelbl" Width="26px"></asp:Label></td>
                            <td valign="top" style="width: 160px">
                                <asp:TextBox ID="txtSurname" runat="server" SkinID="Unicodetxt" ToolTip="थर"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 95px" valign="top">
                                <asp:Label ID="lblDOB" runat="server" Text="जन्म मिति" SkinID="Unicodelbl" Width="84px"></asp:Label></td>
                            <td style="width: 320px" valign="top">
                                <asp:TextBox ID="txtDOB" runat="server" SkinID="Unicodetxt" ToolTip="जन्म मिति" Width="116px"></asp:TextBox></td>
                            <td style="width: 100px" valign="top">
                                <asp:Label ID="lblGender" runat="server" Text="लिंग" SkinID="Unicodelbl"></asp:Label></td>
                            <td valign="top" style="width: 175px">
                                <asp:DropDownList ID="DDLGender" runat="server" SkinID="Unicodeddl" Width="146px">
                    <asp:ListItem Value="SG">छान्नुहोस</asp:ListItem>
                    <asp:ListItem Value="M">पुरुष</asp:ListItem>
                    <asp:ListItem Value="F">महिला</asp:ListItem>
                    <asp:ListItem Value="O">अन्य</asp:ListItem>
                </asp:DropDownList></td>
                            <td valign="top" style="width: 45px">
                            </td>
                            <td valign="top" style="width: 160px">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" SkinID="Normal" /></td>
                        </tr>
                        <tr>
                            <td colspan="6" valign="top">
                    <asp:GridView ID="grdViewEmployees" runat="server" AutoGenerateColumns="False" OnRowDataBound="grdViewEmployees_RowDataBound" Width="783px">
                    <Columns>
                     <asp:BoundField DataField="EMPID" HeaderText="आई डी"></asp:BoundField>
                    <asp:BoundField DataField="SYMBOLNO" HeaderText="संकेत नं."></asp:BoundField>
                    <asp:BoundField DataField="FIRSTNAME" HeaderText="पहिलो नाम"></asp:BoundField>
                    <asp:BoundField DataField="MIDDLENAME" HeaderText="बिचको नाम"></asp:BoundField>
                    <asp:BoundField DataField="SURNAME" HeaderText="थर"></asp:BoundField>
                    <asp:BoundField DataField="RDFULLNAME" HeaderText="पुरा नाम थर"></asp:BoundField>
                    <asp:BoundField DataField="RDGENDER" HeaderText="लिंग"></asp:BoundField>
                    <asp:BoundField DataField="DOB" HeaderText="जन्म मिति" />                    
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                    </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 95px" valign="top">
                    <asp:Button ID="btnOK" runat="server" Text="OK" OnClick="btnOK_Click" SkinID="Normal" /></td>
                            <td style="width: 320px" valign="top">
                            </td>
                            <td style="width: 100px" valign="top">
                            </td>
                            <td valign="top" style="width: 175px">
                            </td>
                            <td valign="top" style="width: 45px">
                            </td>
                            <td valign="top" style="width: 160px">
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <br />
    
     <script src="../../../COMMON/JS/jquery.min.js" type="text/javascript"></script>

    <script type="text/javascript">
    
    
    var firstLoad='<%=!IsPostBack%>';
    
    if(firstLoad=="True")
    {
    
        $(".contentDivAddress").slideToggle();
    }
    
    $(document).ready(function()
     {
     $(".contentDivAddress").slideToggle('slow');
     
        $(".headerDiv").hover(function()
                                 {
                                    $(this).addClass("pretty-hover"),function() {
         $(this).addClass("pretty-hover");
     }
    
    });
    
    $("#addressGridHeader").click(function() {
    $(".contentDivAddress").slideToggle('slow');
    
    });
      $("#prtcpntQualfnDiv").click(function() {
    $(".contentDivQualification").slideToggle('slow');
    
    });
      $("#prtcpntTrainingDiv").click(function() {
    $(".contentDivTraining").slideToggle('slow');
    
    });
     $("#prtcpntEmailDiv").click(function() {
    $(".contentDivEmail").slideToggle('slow');
    
    });
    });
  
    
    
    function FuncCheckSelect(chkbox)
    {    
        
        var doc = document.forms[0] ;       
        var grid = document.getElementById("<%= grdViewEmployees.ClientID %>");
        var grdAppRowCount = grid.rows.length  ;        
               var SenderID=chkbox.getAttribute("id"); 
              
               
             for(var x=1;x<grdAppRowCount;x++)
             {   
                 var chk=grid.rows[x].cells[0].children[0];
                   
                                
                 var chkID=  chk.getAttribute("id");
                 
                    if(SenderID!=chkID)
                    {
                   
                        chk.checked=false;
                    }
             } 
    } 
    
    
    
    
    
//    function FuncCheckSelect(chkbox)
//    {
//        var doc = document.forms[0] ;       
//        var objCheck = doc.getElementsByTagName("INPUT");
//        for (var j = 0; j < objCheck.length; j++)
//        {
//        
//            if(objCheck[j].getAttribute("type")=="checkbox")

//                    if (objCheck[j].getAttribute("id").search(/_chkSelection/i) != -1)            
//                    if (objCheck[j].getAttribute("id")!=chkbox)	        
//                        objCheck(j).checked=false;                   
//        }
//    } 
    </script>
</asp:Content>

