<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true" CodeFile="ApproveDirectEntry.aspx.cs" Inherits="MODULES_OAS_Inventory_Forms_ApproveDirectEntry" Title=":.Approve Direct Entry" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager id="scrpMnger" runat="server">
</asp:ScriptManager>
     
<script language="javascript" src="../../../COMMON/JS/Validation.js" type="text/javascript"></script>
<script language="javascript" src="../../../COMMON/JS/DateValidator.js" type="text/javascript"></script>
<script language="javascript" src="../../../COMMON/JS/UPanelValidation.js" type="text/javascript"></script>
   
 <script language="javascript" type="text/javascript">
 
        function ApprvDeValidate()
        {
            var objChk = document.getElementById('<%=this.chk_appv.ClientID%>');
            
            if(objChk.checked == false)
            {
                var ErrMsg = "प्रमाणीकरणलाई चेक गर्नुहोस्";
                alert("सर्वप्रथम निम्न त्रुटिहरू सच्याउनुहोस।\n\n" + ErrMsg);
               
                objChk.focus();
                return false;
            }
              
            if(validateUpanelFields('_appv','_appv'))
            {
                var objDate1 = document.getElementById('<%=this.hdnDate.ClientID%>');
                var objDate2 = document.getElementById('<%=this.txtApproveDate_URDT_appv.ClientID%>');
                
                if(CompareDate(objDate1,objDate2))
                    return true;
                else
                    return false;
                   
                return true;
            }
            else
                return false;
        }
        
        function CompareDate(obj1,obj2)
        { 
                var myfocus ="";
                var ErrorMsg = "";
               
                var DateElement1 = obj1.value.split("/");
                var DateElement2 = obj2.value.split("/");
                var flag = false;
                
                
                
               if(DateElement1[0] > DateElement2[0])
                {   flag = true;
                                
                    if(myfocus == "")
                    {
                        myfocus = obj2;
                    }
                }
                else if(DateElement1[0] == DateElement2[0])
                {  
                     if(DateElement1[1] > DateElement2[1])
                     {
                        flag = true;
                                
                        if(myfocus == "")
                        {
                            myfocus = obj2;
                        }
                     
                     }
                     else if(DateElement1[1] == DateElement2[1])
                     {
                         if(DateElement1[2] > DateElement2[2])
                         {
                            flag = true;
                            
                                    
                            if(myfocus == "")
                            {
                                myfocus = obj2;
                            }
                            
                         }
                    }
                }
        
 
                if(flag)
                {   
                    ErrorMsg=ErrorMsg + "'दाखिला प्रमाणीकरण मिति'  'दाखिला भएको मिति'  भन्दा  बढी हुनुपर्छ।\n";
                        
                    alert("निम्न मितिको त्रुटिहरू सच्याउनुहोस::\n\n"+ErrorMsg);
                    myfocus.focus();
                    myfocus = "";
                    return false;
                }
                else
                {        
                    return true;
                }
       
        }
        
    </script>  
 <div style="width:100%; height:auto">
   
    <!-- For Popup error status -->
    <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground"
        BehaviorID="programmaticModalPopupBehavior" DropShadow="True" PopupControlID="programmaticPopup"
        PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
        TargetControlID="hiddenTargetControlForModalPopup">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none;
        width: 350px; padding: 10px">
        &nbsp;&nbsp;
        <asp:UpdatePanel id="UpdatePanel1" runat="server">
            <contenttemplate>
            <asp:Panel style="BORDER-RIGHT: gray 1px solid; BORDER-TOP: gray 1px solid; BORDER-LEFT: gray 1px solid; CURSOR: move; COLOR: black; BORDER-BOTTOM: gray 1px solid; BACKGROUND-COLOR: #dddddd; TEXT-ALIGN: center" id="programmaticPopupDragHandle" runat="Server"><asp:Label id="lblStatusMessageTitle" runat="server" CssClass="simplelabel"></asp:Label></asp:Panel> <asp:Label id="lblStatusMessage" runat="server" CssClass="simplelabel" EnableTheming="False" ForeColor="Black"></asp:Label> 
            </contenttemplate>
                    </asp:UpdatePanel>
                    <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
            Text="OK" Width="58px" />
        <br />
    </asp:Panel>
     <br />
     <asp:UpdatePanel id = "updApprove" runat="server">
     <contenttemplate>
<ajaxToolkit:MaskedEditExtender id="MaskedEditExtender1" runat="server" TargetControlID="txtDakhilaDate_RDT" __designer:wfdid="w2" AutoComplete="False" ClearMaskOnLostFocus="False" Mask="9999/99/99" MaskType="Date">
     </ajaxToolkit:MaskedEditExtender> <asp:HiddenField id="hdnDate" runat="server" __designer:wfdid="w3"></asp:HiddenField> <TABLE style="PADDING-LEFT: 20px; WIDTH: 720px" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 17px; HEIGHT: 21px" colSpan=2><asp:Label id="lblDakhila" runat="server" Width="178px" Text="दाखिला खोज" SkinID="UnicodeHeadlbl" __designer:wfdid="w4"></asp:Label></TD><TD style="WIDTH: 101px; HEIGHT: 21px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </TD><TD style="WIDTH: 30px; HEIGHT: 21px"></TD></TR><TR><TD style="WIDTH: 15px; HEIGHT: 19px"></TD><TD style="WIDTH: 150px; HEIGHT: 19px"></TD><TD style="WIDTH: 101px; HEIGHT: 19px"></TD><TD style="WIDTH: 229px; HEIGHT: 19px"></TD></TR><TR><TD style="WIDTH: 15px"></TD><TD style="WIDTH: 150px"></TD><TD style="WIDTH: 101px"></TD><TD style="WIDTH: 229px"></TD></TR><TR><TD style="WIDTH: 15px; HEIGHT: 30px"><asp:Label id="lblCategory" runat="server" Text="समूह" SkinID="Unicodelbl" __designer:wfdid="w5"></asp:Label></TD><TD style="WIDTH: 150px; HEIGHT: 30px"><asp:DropDownList id="ddlCategory_rqd" tabIndex=1 runat="server" Width="162px" __designer:wfdid="w6" ToolTip="समूह" OnSelectedIndexChanged="ddlCategory_rqd_SelectedIndexChanged" AutoPostBack="True">
            </asp:DropDownList></TD><TD style="WIDTH: 101px; HEIGHT: 30px"><asp:Label id="lblSubCategory" runat="server" Width="63px" Text="उप-समूह" SkinID="Unicodelbl" __designer:wfdid="w7"></asp:Label></TD><TD style="WIDTH: 229px; HEIGHT: 30px"><asp:DropDownList id="ddlSubCategory_rqd" tabIndex=2 runat="server" Width="155px" __designer:wfdid="w8" ToolTip="उप-समूह" OnSelectedIndexChanged="ddlSubCategory_rqd_SelectedIndexChanged" AutoPostBack="True" Enabled="False">
            </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 15px; HEIGHT: 38px"><asp:Label id="lblItem" runat="server" Text="सामान" SkinID="Unicodelbl" __designer:wfdid="w9"></asp:Label></TD><TD style="WIDTH: 150px; HEIGHT: 38px" colSpan=3><asp:DropDownList id="ddlItems_rqd" tabIndex=3 runat="server" Width="503px" __designer:wfdid="w10" ToolTip="सामान" AutoPostBack="True" Enabled="False"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 15px; HEIGHT: 28px"><asp:Label id="lblDate" runat="server" Width="89px" Text="दाखिला मिति" SkinID="Unicodelbl" __designer:wfdid="w11"></asp:Label></TD><TD style="WIDTH: 150px; HEIGHT: 28px"><asp:TextBox id="txtDakhilaDate_RDT" runat="server" Width="76px" __designer:wfdid="w12" ToolTip="दाखिला मिति" MaxLength="4"></asp:TextBox></TD><TD style="WIDTH: 101px; HEIGHT: 28px"></TD><TD style="WIDTH: 229px; HEIGHT: 28px" align=left>&nbsp; &nbsp;<asp:Button id="btnSearch" onclick="btnSearch_Click" runat="server" Text="Search" SkinID="Normal" __designer:wfdid="w13"></asp:Button> <asp:Button id="btnCancel" onclick="btnCancel_Click" runat="server" Text="Cancel" SkinID="Cancel" __designer:wfdid="w14"></asp:Button></TD></TR><TR><TD style="HEIGHT: 28px" align=left colSpan=4>
<HR />
&nbsp;</TD></TR></TBODY></TABLE><BR /><DIV style="PADDING-LEFT: 20px; OVERFLOW: auto; WIDTH: 95%" id="DIV1"><asp:Label id="lblEntryCount" runat="server" SkinID="Unicodelbl" __designer:wfdid="w15"></asp:Label><BR /></DIV><DIV style="PADDING-LEFT: 20px; OVERFLOW: auto; WIDTH: 95%" id="dvDakhila"><asp:GridView id="grdDakhila" runat="server" ForeColor="#333333" __designer:wfdid="w16" OnSelectedIndexChanged="grdDakhila_SelectedIndexChanged" AutoGenerateColumns="False" GridLines="None" CellPadding="4" OnRowCreated="grdDakhila_RowCreated" OnRowDataBound="grdDakhila_RowDataBound">
         <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
         <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
         <EditRowStyle BackColor="#999999" />
         <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
         <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
         <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
         <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
         <Columns>
            <asp:TemplateField HeaderText="सिनं.">
            <ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

            <HeaderStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
            </asp:TemplateField>
             <asp:BoundField DataField="OrgID" HeaderText="OrgID" />
             <asp:BoundField DataField="ItemsCategoryID" HeaderText="ItemsCategoryID" />
             <asp:BoundField DataField="ItemsSubCategoryID" HeaderText="ItemsSubCategoryID" />
             <asp:BoundField DataField="ItemsID" HeaderText="ItemsID" />
             <asp:BoundField DataField="ItemsTypeID" HeaderText="ItemsTypeID" />
             <asp:BoundField DataField="ItemsCategoryName" HeaderText="समूह" />
             <asp:BoundField DataField="ItemsSubCategoryName" HeaderText="उप-समूह" />
             <asp:BoundField DataField="ItemsName" HeaderText="सामान" />
             <asp:BoundField DataField="DirectEntryDate" HeaderText="दाखिला मिति" />
             <asp:BoundField HeaderText="सामानको प्रकार" />
             <asp:BoundField HeaderText="डोनेसन(हो / होइन)" />
             <asp:BoundField DataField="DonationOrg" HeaderText="डोनेसन गर्ने संस्था" />
             <asp:BoundField DataField="UnitPrice" HeaderText="दर(रु)" />
             <asp:BoundField DataField="Quantity" HeaderText="परिमाण" />
             <asp:TemplateField HeaderText="जम्मा रुपैया (रू)"></asp:TemplateField>
             <asp:CommandField ShowSelectButton="True" />
             <asp:TemplateField>
                 <ItemTemplate>
                     <asp:Button ID="btnKnj" runat="server"  SkinID="Normal" Text="Enter Data" />
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:BoundField DataField="DirectEntryType" HeaderText="DirectEntryType" />
             <asp:BoundField DataField="Action" HeaderText="Action" />
         </Columns>
     </asp:GridView> </DIV><ajaxToolkit:MaskedEditExtender id="MaskedEditExtender2" runat="server" TargetControlID="txtApproveDate_URDT_appv" __designer:wfdid="w17" AutoComplete="False" Mask="9999/99/99" MaskType="Date">
    </ajaxToolkit:MaskedEditExtender> <BR /><BR /><asp:Panel id="pnlApprove" runat="server" Width="191px" Height="50px" __designer:wfdid="w18" Visible="False"><TABLE style="PADDING-LEFT: 20px; WIDTH: 746px" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 17px; HEIGHT: 15px" colSpan=3><asp:Label id="Label1" runat="server" Width="316px" Text="दाखिला प्रमाणीकरण विवरण" SkinID="UnicodeHeadlbl" __designer:wfdid="w19"></asp:Label></TD><TD style="WIDTH: 37px; HEIGHT: 15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </TD><TD style="WIDTH: 339px; HEIGHT: 15px"></TD></TR><TR><TD style="WIDTH: 14px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </TD><TD style="WIDTH: 92px"></TD><TD style="WIDTH: 109px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </TD><TD style="WIDTH: 37px"></TD></TR><TR><TD style="WIDTH: 14px; HEIGHT: 30px"><asp:Label id="Label2" runat="server" Width="137px" Text="प्रमाणीकरण गर्नहोस्" SkinID="Unicodelbl" __designer:wfdid="w20"></asp:Label> </TD><TD style="WIDTH: 92px; HEIGHT: 30px"><asp:CheckBox id="chk_appv" runat="server" Width="47px" __designer:wfdid="w21" Checked="True"></asp:CheckBox></TD><TD style="WIDTH: 109px; HEIGHT: 30px"><asp:Label id="Label5" runat="server" Width="122px" Text="प्रमाणीकरण मिति" SkinID="Unicodelbl" __designer:wfdid="w22"></asp:Label></TD><TD style="WIDTH: 37px; HEIGHT: 30px"><asp:TextBox id="txtApproveDate_URDT_appv" runat="server" Width="76px" __designer:wfdid="w23" ToolTip="प्रमाणीकरण मिति" MaxLength="4"></asp:TextBox></TD><TD style="WIDTH: 339px; HEIGHT: 30px"><asp:Button id="btnSubmit" onclick="btnSubmit_Click" runat="server" Text="Submit" SkinID="Normal" __designer:wfdid="w24" OnClientClick="javascript: return ApprvDeValidate();"></asp:Button> <asp:Button id="btnCancel1" onclick="btnCancel1_Click" runat="server" Text="Cancel" SkinID="Cancel" __designer:wfdid="w25"></asp:Button></TD></TR><TR><TD style="WIDTH: 14px; HEIGHT: 28px"></TD><TD style="WIDTH: 92px; HEIGHT: 28px"></TD><TD style="WIDTH: 109px; HEIGHT: 28px"></TD><TD style="WIDTH: 37px; HEIGHT: 28px">&nbsp;</TD></TR></TBODY></TABLE></asp:Panel> <BR /><BR /><BR /><BR /><BR /><BR /><BR /><BR /><BR /><BR />
</contenttemplate>
         <triggers>
<asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnSubmit" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnCancel1" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="ddlCategory_rqd" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="ddlSubCategory_rqd" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="ddlItems_rqd" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="OkButton" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
     </asp:UpdatePanel>
    

  
 </div>
</asp:Content>

