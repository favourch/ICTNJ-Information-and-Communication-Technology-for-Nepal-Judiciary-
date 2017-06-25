<%@ Page AutoEventWireup="true" CodeFile="PropertyDetails1.aspx.cs" Inherits="MODULES_PMS_PropertyDetails"
    Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master" Title="PMS | Employee Property Details" %>
<%@ Register 
    Assembly="AjaxControlToolkit" 
    Namespace="AjaxControlToolkit" 
    TagPrefix="ajaxToolkit" %>
        <script runat="server">

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <script language="javascript" type="text/javascript" src="../../COMMON/JS/Validation.js"></script>
  <script language="javascript" type="text/javascript" src="../../COMMON/JS/DateValidator.js"></script>
  <script language="javascript" type="text/javascript" src="../../COMMON/JS/Number.js"></script>
  <script language="javascript" type="text/javascript">
    var gridfocus ="";
    function totalValidate(val)
    { 
        if(val == 0)
        {
           if( validate())
           {
                 if(confirmValidate(val))
                    return true;
                 else
                    return false;
           }
           else
               return false;
        }
       else if((val == 1) || (val == 2))
       {
            if(confirmValidate(val))
                return true;
             else
                return false;
       }
       
                    
    }
    
    function confirmValidate(val)
    {
         var count = 0;
         count = validateGridTextBoxes(val);
        
          if (count == 0) 
             return true;
          else if(count == 1111)
             return false;
          else 
          {     if(val ==1)
                {
                    alert("The following errors were encountered.\n\n All fields for the property are required to be filled.");
                }
                else if(val ==2)
                {
                    alert("The following errors were encountered.\n\n All fields for amount and date are required to be filled.");
                }
                else
                {
                    alert("The following errors were encountered.\n\n All fields for the property are required to be filled.");
                }
                gridfocus.focus();
                gridfocus = "";
                return false;
          }
    }
    
    function validateGridTextBoxes(val)
    {
       
       var k = 0;
       var doc = document.forms[0];
       var objInputTxt = doc.getElementsByTagName("INPUT");
       
        for (var j = 0; j < objInputTxt.length; j++)
	    {
    	    if (objInputTxt[j].getAttribute("type") == "text" )
		    {   
		        if(val == 1)
		        {
		            if (objInputTxt[j].getAttribute("id").search(/_RDT/i) == -1 && objInputTxt[j].getAttribute("id").search(/_rqd/i) == -1 && objInputTxt[j].getAttribute("id").search(/_ad/i) == -1 && objInputTxt[j].getAttribute("id").search(/_DT/i) == -1)
		            { 
                         if(objInputTxt[j].value == "")
                         {	
	                        k = k + 1;
                            if(gridfocus == "")
                            {
                                gridfocus = objInputTxt[j];
                            }
		                }
		            }
		        }
		        else if(val == 2)
		        {
		            if (objInputTxt[j].getAttribute("id").search(/_ad/i) != -1  || objInputTxt[j].getAttribute("id").search(/_DT/i) != -1)
		            { 
		                
		            
                         if(objInputTxt[j].value == "")
                         {	
	                        k = k + 1;
                            if(gridfocus == "")
                            {
                                gridfocus = objInputTxt[j];
                            }
		                }
		                		                
		                if(k < 1)
		                {
		                    if(objInputTxt[j].getAttribute("id").search(/_ad/i) != -1)
		                    {   
                               if(checkRange(objInputTxt[j]) == false)
                               {  
                                 gridfocus.focus();
                                 return 1111; 
                               } 
	                           
                                
		                    }
		                }
		            }
		        }
		        else 
		        {
		            
		            if (objInputTxt[j].getAttribute("id").search(/_rqd/i) == -1)
		            { 
                         if(objInputTxt[j].value == "")
                         {	
	                        k = k + 1;
                            if(gridfocus == "")
                            {
                                gridfocus = objInputTxt[j];
                            }
		                }
		            }
		        }
		      
	        }
		    
	    }
	    return k;
    }
    
    function checkRange(obj)
    {
        if(obj.value.length > 10)
        { 
              alert("The following errors were encountered.\n\nAmount must be less than 10 numeric values.");
              gridfocus = obj;
              return false;
        }
        else
        {
            Amount = obj.value.split(".");
            
            if(Amount[1] != null)
            {
                if(Amount[1].length >3)
                {     
                      alert("The following errors were encountered.\n\nAmount supports only three values after decimal.");
                      gridfocus = obj;
                      return false;  
                }
                    
            }
           
        }
        
        return true;
    }
    
       
   </script>
<%-- <div style="width:900px; overflow:auto;" >--%>
     <div style ="width:100%">
 
     <asp:ScriptManager id ="scrptManager" runat="server">
     </asp:ScriptManager>
        
                <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" style="display:none"/>
        <ajaxToolkit:ModalPopupExtender runat="server" ID="programmaticModalPopup"
            BehaviorID="programmaticModalPopupBehavior"
            TargetControlID="hiddenTargetControlForModalPopup"
            PopupControlID="programmaticPopup" 
            BackgroundCssClass="modalBackground"
            DropShadow="True"
            PopupDragHandleControlID="programmaticPopupDragHandle"
            RepositionMode="RepositionOnWindowScroll" >
        </ajaxToolkit:ModalPopupExtender>
         <asp:Panel runat="server" CssClass="modalPopup" ID="programmaticPopup" style="display:none;width:350px;padding:10px">
                &nbsp;&nbsp;
                <asp:UpdatePanel id="UpdatePanel1" runat="server">
                 <contenttemplate>
                    <asp:Panel style="BORDER-RIGHT: gray 1px solid; BORDER-TOP: gray 1px solid; BORDER-LEFT: gray 1px solid; CURSOR: move; COLOR: black; BORDER-BOTTOM: gray 1px solid; BACKGROUND-COLOR: #dddddd; TEXT-ALIGN: center" id="programmaticPopupDragHandle" runat="Server" __designer:dtid="281474976710667" __designer:wfdid="w34"><asp:Label id="lblStatusMessageTitle" runat="server" CssClass="simplelabel"></asp:Label></asp:Panel> <asp:Label id="lblStatusMessage" runat="server" CssClass="simplelabel"></asp:Label>
                 </contenttemplate>
             </asp:UpdatePanel>
            <asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click" Width="58px" />           <br />
        </asp:Panel>
        
        <table border ="0px" style="border-color:Red;" cellpadding ="0" cellspacing = "0" width = "100%">
        <tr>
            <td style="height:10px; width: 1056px;"></td>
        </tr>
        <tr>
              <td align="left" style="width: 1056px">
                   <TABLE style="BORDER-LEFT-COLOR: green; BORDER-BOTTOM-COLOR: green;  BORDER-TOP-COLOR: green; BORDER-RIGHT-COLOR: green; width: 937px;" cellSpacing=0 cellPadding=0 border=0>
                             <TR>
                            <TD style="HEIGHT: 25px; padding-left: 12px;" align=left colSpan=2>
                            <asp:Label id="Label7" runat="server" CssClass="headerlabel" SkinID="Unicodelbl" Text="सम्पत्तिको विवरण" Font-Underline="True"></asp:Label> </TD>
                            <TD style="HEIGHT: 25px" colSpan=3><asp:Label id="lblStatus" runat="server" CssClass="errorlabel" ForeColor="Red" Font-Bold="True"></asp:Label> 
                            </TD>
                            <TD style="HEIGHT: 25px; width: 261px;" class="tblTDLeft">&nbsp;&nbsp; </TD>
                            </TR>
                            <TR>
                            <TD style="WIDTH: 150px; HEIGHT: 2px" colspan="2">
                            </TD>
                            </TR>
                            <tr>
                                <td style="height:7px;">&nbsp;</td>
                            </tr>
                    </TABLE>
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 1056px">
                  
                  <table border ="0px" style="border-color:Green;" cellpadding ="0" cellspacing = "0" width = "98%">
                      
                      <tr>
                        <td valign ="top"  style="padding-top:12px; height: 183px;">
                              <asp:ListBox ID="lstProperty" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lstProperty_SelectedIndexChanged" Height="150px" Width="310px">
                              </asp:ListBox>
                        </td>
                        <td  valign = "top" style="width: 668px; height: 183px;">
                            
                            <TABLE style="BORDER-LEFT-COLOR: green; BORDER-BOTTOM-COLOR: green;  BORDER-TOP-COLOR: green; BORDER-RIGHT-COLOR: green" cellSpacing=0 cellPadding=0 border=0>
                                                      
                            <TR>
                            <TD style="WIDTH: 219px; padding-left: 10px;" align="left"><asp:Label id="Label1" runat="server" SkinID="Unicodelbl" Text="कर्मचारीको संकेत नं" Width="132px"></asp:Label>
                             </TD>
                             <TD style="WIDTH: 198px;" HEIGHT: align="left" 26px?>&nbsp;<asp:TextBox id="txtEmployeeNo_rqd" tabIndex=98 onkeypress="javascript:return NumberOnly(event,this);" runat="server" MaxLength="9" ToolTip="Employee ID"></asp:TextBox> </TD>
                             <TD style="WIDTH: 190px; padding-left: 10px;" align="left"><asp:Label id="Label5" runat="server" SkinID="Unicodelbl" Text="विवरण पेश गरको मिति"></asp:Label>&nbsp;<asp:Label
                                     ID="Label10" runat="server" Text="*" CssClass="errorlabel"></asp:Label>&nbsp;</TD>
                             <TD style="width: 284px;" align="left">&nbsp;<asp:TextBox id="txtSubDate_RDT" tabIndex=100 runat="server" ToolTip="Submission Date"></asp:TextBox><ajaxToolkit:MaskedEditExtender id="MaskedEditExtender1" runat="server" TargetControlID="txtSubDate_RDT" MaskType="Date" Mask="9999/99/99" AutoComplete="False"></ajaxToolkit:MaskedEditExtender> </TD>
                             </TR>
                             <TR><TD style="padding-left: 10px; width: 219px" align="left"><asp:Label id="Label2" runat="server" SkinID="Unicodelbl" Text="कर्मचारीको नाम"></asp:Label> </TD>
                             <TD style="WIDTH: 198px; HEIGHT: 25px" align="left">&nbsp;<asp:TextBox id="txtName_rqd" runat="server" ToolTip="Name"></asp:TextBox></TD>
                             <TD style="WIDTH: 190px; padding-left: 10px;" align="left"><asp:Label id="Label6" runat="server" SkinID="Unicodelbl" Text="विवरण पेश गरको कार्यलय"></asp:Label>&nbsp;<asp:Label
                                     ID="Label8" runat="server" Text="*" CssClass="errorlabel"></asp:Label> </TD>
                             <TD style="HEIGHT: 25px; width: 284px;" align="left">&nbsp;<asp:DropDownList id="drpOrganisation_rqd" tabIndex=101 runat="server" Width="136px" ToolTip="Submission Office"></asp:DropDownList> </TD>
                             </TR>
                             <TR>
                             <TD style="padding-left: 10px; width: 219px; height: 25px" align="left"><asp:Label id="Label4" runat="server" SkinID="Unicodelbl" Text="कार्यलय"></asp:Label> </TD>
                             <TD style="WIDTH: 198px; HEIGHT: 25px" align="left">&nbsp;<asp:TextBox id="txtOffice_rqd" runat="server" ToolTip="Office"></asp:TextBox></TD>
                             <TD style="WIDTH: 190px; HEIGHT: 25px; padding-left: 10px;" align="left"><asp:Label id="Label9" runat="server" SkinID="Unicodelbl" Text="ठेगाना"></asp:Label>&nbsp;
                                 <asp:Label ID="Label11" runat="server" CssClass="errorlabel" Text="*"></asp:Label></TD>
                             <TD style="HEIGHT: 25px; width: 284px;" align="left">&nbsp;<asp:TextBox id="txtSubOffPlace_rqd" tabIndex=102 runat="server" MaxLength="20" ToolTip="Submission Place"></asp:TextBox>
                             </TD>
                             </TR>
                             <TR>
                             <TD style="WIDTH: 219px; padding-left: 10px; height: 25px;" align="left"><asp:Label id="Label3" runat="server" SkinID="Unicodelbl" Text="श्रेणी र पद"></asp:Label>  </TD>
                             <TD style="WIDTH: 198px; HEIGHT: 25px" align="left">&nbsp;<asp:TextBox id="txtPost_rqd" runat="server" ToolTip="Rank/Desgination" MaxLength="50"></asp:TextBox></TD>
                             <TD style="WIDTH: 190px; HEIGHT: 25px">
                                 <asp:Label ID="Label12" runat="server" Width="193px"></asp:Label><%--<asp:Label id="Label10" runat="server" SkinID="Unicodelbl" Text="ठेगाना"></asp:Label>&nbsp;&nbsp;--%></TD>
                             <TD style="HEIGHT: 25px; width: 284px;" class="tblTDLeft">&nbsp;
                             </TD>
                             </TR>

                             </TABLE>

                                
                        </td>
                      </tr>
                   </table>
                 
            </td>
        </tr>
        
        <tr>
            <td align="left" style="width: 1056px">
                <table border ="0px" style="border-color:Maroon;" cellpadding ="0" cellspacing = "0" width = "97%">
                     <tr>
                       
                        <td align="left" colspan ="5" valign ="top" style ="padding-left:12px;">
                               <asp:UpdatePanel id = "updPropCat" runat="server">
                                        <contenttemplate>
<DIV style="OVERFLOW: auto; WIDTH: 877px"><asp:gridview id="grdPropertyDetails" runat="server" ForeColor="#333333" __designer:wfdid="w1" GridLines="None" CellPadding="4" OnRowDataBound="grdPropertyDetails_RowDataBound" OnRowCreated="grdPropertyDetails_RowCreated1" AutoGenerateColumns="False" ShowFooter="True">
<FooterStyle BackColor="White" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="1" HeaderText="Row Number">
<FooterStyle BackColor="White"></FooterStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Header 1"><FooterTemplate>
                                            <asp:Button id="btnAddRow" tabIndex=104 onclick="btnAddRow_Click" runat="server" Text="Add"  __designer:wfdid="w6" OnClientClick="javascript: return totalValidate(1);"></asp:Button> 
                                            
</FooterTemplate>
<ItemTemplate>
                                            <asp:TextBox id="TextBox1" runat="server" __designer:wfdid="w5"></asp:TextBox> 
                                            
</ItemTemplate>

<FooterStyle BackColor="White" HorizontalAlign="Left"></FooterStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Header 2"><ItemTemplate>
                                            <asp:TextBox id="TextBox2" runat="server" __designer:wfdid="w2"></asp:TextBox> 
                                            
</ItemTemplate>

<FooterStyle BackColor="White"></FooterStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Header 3"><ItemTemplate>
                                            <asp:TextBox id="TextBox3" runat="server" __designer:wfdid="w3"></asp:TextBox> 
                                            
</ItemTemplate>

<FooterStyle BackColor="White"></FooterStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Header 4"><ItemTemplate>
                                            <asp:TextBox id="TextBox4" runat="server" __designer:wfdid="w4"></asp:TextBox> 
                                            
</ItemTemplate>

<FooterStyle BackColor="White"></FooterStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Header 5"><ItemTemplate>

                                                                                                             <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>

                                                                                                        
                                                                                                    
                                            
</ItemTemplate>

<FooterStyle BackColor="White"></FooterStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Header 6"><ItemTemplate>
                                                                                                                                                                     <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                                                                                                                                                                
                                                                                                    
                                            
</ItemTemplate>

<FooterStyle BackColor="White"></FooterStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Header 7"><ItemTemplate>
                                                                                                                                                                     <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                                                                                                                                                                
                                                                                                    
                                            
</ItemTemplate>

<FooterStyle BackColor="White"></FooterStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Header 8"><ItemTemplate>
                                                                                                                                                                     <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                                                                                                                                                                
                                                                                                    
                                            
</ItemTemplate>

<FooterStyle BackColor="White"></FooterStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Header 9"><ItemTemplate>
                                                                                                                                                                     <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                                                                                                                                                                
                                                                                                    
                                            
</ItemTemplate>

<FooterStyle BackColor="White"></FooterStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Header 10"><ItemTemplate>
                                                                                                                                                                     <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                                                                                                                                                                
                                                                                                    
                                            
</ItemTemplate>

<FooterStyle BackColor="White"></FooterStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Header 11"><ItemTemplate>
                                                                                                                                                                     <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                                                                                                                                                                
                                                                                                    
                                            
</ItemTemplate>

<FooterStyle BackColor="White"></FooterStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Header 12"><ItemTemplate>
                                                                                                                                                                     <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
                                                                                                                                                                
                                                                                                    
                                            
</ItemTemplate>

<FooterStyle BackColor="White"></FooterStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Header 13"><ItemTemplate>
                                                                                                                                                                     <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
                                                                                                                                                                
                                                                                                    
                                            
</ItemTemplate>

<FooterStyle BackColor="White"></FooterStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Header 14"><ItemTemplate>
                                                                                                                                                                     <asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
                                                                                                                                                                
                                                                                                    
                                            
</ItemTemplate>

<FooterStyle BackColor="White"></FooterStyle>
</asp:TemplateField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:gridview> <P height="20px"></P></DIV><BR /><asp:GridView id="grdAmountDate" runat="server" __designer:wfdid="w2" OnRowDataBound="grdAmountDate_RowDataBound" OnRowCreated="grdAmountDate_RowCreated" AutoGenerateColumns="False" ShowFooter="True" BorderStyle="None" ShowHeader="False">
                                            <FooterStyle BackColor="White"></FooterStyle>
                                            <Columns>
                                            <asp:TemplateField HeaderText="Header 1">
                                            <ItemStyle Width="25px"></ItemStyle>
                                            <ItemTemplate>
                                            <asp:Label id="lblAmount" runat="server" Text="रु" __designer:wfdid="w8"></asp:Label> 
                                            </ItemTemplate>

                                            <FooterStyle BackColor="White"></FooterStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Header 2"><FooterTemplate>
                                            <asp:Button id="btnAdd" tabIndex=104 onclick="btnAdd_Click" runat="server" Text="Add" __designer:wfdid="w10" OnClientClick="return totalValidate(2)"></asp:Button> 
                                            </FooterTemplate>
                                            <ItemTemplate>
                                            <asp:TextBox id="txtAmount_ad" runat="server" MaxLength="10" __designer:wfdid="w9"></asp:TextBox> 
                                            </ItemTemplate>

                                            <FooterStyle BackColor="White" HorizontalAlign="Left"></FooterStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Header 3">
                                            <ItemStyle BackColor="White"></ItemStyle>
                                            <ItemTemplate>
                                                                                                    <asp:TextBox id="txtDate_DT" runat="server" __designer:wfdid="w7" ToolTip="Property Date"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender2" runat="server" TargetControlID="txtDate_DT" __designer:wfdid="w8" AutoComplete="False" Mask="9999/99/99" MaskType="Date"></ajaxToolkit:MaskedEditExtender> 
                                                                                                    
                                            </ItemTemplate>

                                            <FooterStyle BackColor="White" ForeColor="White"></FooterStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Header 4">
                                            <ItemStyle BackColor="White" Width="30px"></ItemStyle>
                                            <ItemTemplate>
                                                                                                                                        <asp:Label id="lblDate" runat="server" Text="साल"></asp:Label> 
                                                                                                                                        
                                                                                                    
                                            </ItemTemplate>

                                            <FooterStyle BackColor="White" ForeColor="White"></FooterStyle>
                                            </asp:TemplateField>
                                            </Columns>
                                            </asp:GridView> <BR /><asp:Button id="btnSave" tabIndex=105 onclick="btnSave_Click" runat="server" Text="Submit" SkinID="Normal" __designer:wfdid="w3" OnClientClick="javascript: return totalValidate(0);" Visible="False"></asp:Button> 
</contenttemplate>
                                                                                                                                                                                           <triggers>
<asp:AsyncPostBackTrigger ControlID="lstProperty" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
                                                    </asp:UpdatePanel>  
                                                     
                                                        
                              
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                               </tr>
                                
                                <tr>
                                    <td style="height:97px; width: 1056px;"></td>
                                </tr>
                              </table>
                           
                              
                           
                         </div>
                        </asp:Content>

