<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PersonnelPropertyControl.ascx.cs" Inherits="MODULES_COMMON_UserControls_PersonnelPropertyControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<script runat="server">

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
</script>

    <script language="javascript" src="../../COMMON/JS/Validation.js" type="text/javascript"></script>

    <script language="javascript" src="../../COMMON/JS/DateValidator.js" type="text/javascript"></script>

    <script language="javascript" src="../../COMMON/JS/Number.js" type="text/javascript"></script>

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
        <asp:ScriptManager id="scrptManager" runat="server">
        </asp:ScriptManager>
        <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" style="display: none" />
        <ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground"
            BehaviorID="programmaticModalPopupBehavior" DropShadow="True" PopupControlID="programmaticPopup"
            PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
            TargetControlID="hiddenTargetControlForModalPopup">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" style="display: none;
            width: 350px; padding: 10px">
                &nbsp;&nbsp;
                <asp:UpdatePanel id="UpdatePanel1" runat="server">
                    <contenttemplate>
                    <asp:Panel style="BORDER-RIGHT: gray 1px solid; BORDER-TOP: gray 1px solid; BORDER-LEFT: gray 1px solid; CURSOR: move; COLOR: black; BORDER-BOTTOM: gray 1px solid; BACKGROUND-COLOR: #dddddd; TEXT-ALIGN: center" id="programmaticPopupDragHandle" runat="Server"><asp:Label id="lblStatusMessageTitle" runat="server" CssClass="simplelabel"></asp:Label></asp:Panel> <asp:Label id="lblStatusMessage" runat="server" CssClass="simplelabel"></asp:Label>
                 </contenttemplate>
                </asp:UpdatePanel>
            <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
                Text="OK" Width="58px" />           <br />
        </asp:Panel>
<table style="width: 1000px">
    <tr>
        <td rowspan="4" valign="top">
            <table style="width: 240px">
                <tr>
                    <td style="width: 240px; height: 71px" valign="top">
                                <asp:ListBox ID="lstProperty" runat="server" AutoPostBack="True" Height="150px" OnSelectedIndexChanged="lstProperty_SelectedIndexChanged"
                                    Width="230px" SkinID="Unicodelst"></asp:ListBox></td>
                </tr>
            </table>
        </td>
        <td style="width: 140px" valign="top">
                                            <asp:Label id="Label1" runat="server" SkinID="Unicodelbl" Text="कर्मचारीको संकेत नं"
                                                Width="135px"></asp:Label></td>
        <td style="width: 165px" valign="top">
            <asp:TextBox id="txtEmployeeNo_rqd" runat="server" MaxLength="9" onkeypress="javascript:return NumberOnly(event,this);"
                                                tabIndex="98" ToolTip="Employee ID" SkinID="Unicodetxt" Width="150px"></asp:TextBox></td>
        <td style="width: 195px" valign="top" align="right">
                                            <asp:Label id="Label5" runat="server" SkinID="Unicodelbl" Text="विवरण पेश गरको मिति" Width="166px"></asp:Label></td>
        <td style="width: 255px" valign="top">
            <asp:TextBox id="txtSubDate_RDT" runat="server" tabIndex="100" ToolTip="Submission Date" SkinID="Unicodetxt" Width="113px"></asp:TextBox><ajaxToolkit:MaskedEditExtender
                                                ID="MaskedEditExtender1" runat="server" AutoComplete="False" Mask="9999/99/99"
                                                MaskType="Date" TargetControlID="txtSubDate_RDT">
                                            </ajaxToolkit:MaskedEditExtender>
        </td>
    </tr>
    <tr>
        <td style="width: 140px" valign="top">
                                            <asp:Label id="Label2" runat="server" SkinID="Unicodelbl" Text="कर्मचारीको नाम" Width="107px"></asp:Label></td>
        <td style="width: 170px" valign="top">
            <asp:TextBox id="txtName_rqd" runat="server" ToolTip="Name" SkinID="Unicodetxt" Width="150px"></asp:TextBox></td>
        <td style="width: 195px" valign="top" align="right">
                                            <asp:Label id="Label6" runat="server" SkinID="Unicodelbl" Text="विवरण पेश गरको कार्यलय" Width="190px"></asp:Label></td>
        <td style="width: 310px" valign="top">
            <asp:DropDownList id="drpOrganisation_rqd" runat="server" tabIndex="101" ToolTip="Submission Office"
                                                Width="250px" SkinID="Unicodeddl"></asp:DropDownList></td>
    </tr>
    <tr>
        <td style="width: 140px" valign="top">
                                            <asp:Label id="Label4" runat="server" SkinID="Unicodelbl" Text="कार्यलय"></asp:Label></td>
        <td style="width: 170px" valign="top">
            <asp:TextBox id="txtOffice_rqd" runat="server" ToolTip="Office" SkinID="Unicodetxt" Width="150px"></asp:TextBox></td>
        <td style="width: 195px" valign="top" align="right">
                                            <asp:Label id="Label9" runat="server" SkinID="Unicodelbl" Text="ठेगाना"></asp:Label></td>
        <td style="width: 310px" valign="top">
            <asp:TextBox id="txtSubOffPlace_rqd" runat="server" MaxLength="20" tabIndex="102"
                                                ToolTip="Submission Place" SkinID="Unicodetxt"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="width: 140px" valign="top">
                                            <asp:Label id="Label3" runat="server" SkinID="Unicodelbl" Text="श्रेणी र पद"></asp:Label></td>
        <td style="width: 170px" valign="top">
            <asp:TextBox id="txtPost_rqd" runat="server" MaxLength="50" ToolTip="Rank/Desgination" SkinID="Unicodetxt" Width="150px"></asp:TextBox></td>
        <td style="width: 195px" valign="top">
        </td>
        <td style="width: 310px" valign="top">
                                            <asp:Label ID="Label12" runat="server" Width="193px"></asp:Label></td>
    </tr>
</table>
                                <asp:UpdatePanel id="updPropCat" runat="server">
                                    <contenttemplate>
                                        <table style="width: 1000px">
                                            <tr>
                                                <td style="width: 100px" valign="top">
<DIV style="OVERFLOW: auto; WIDTH: 980px"><asp:gridview id="grdPropertyDetails" runat="server" ForeColor="#333333" GridLines="None" CellPadding="4" OnRowDataBound="grdPropertyDetails_RowDataBound" OnRowCreated="grdPropertyDetails_RowCreated1" AutoGenerateColumns="False" ShowFooter="True" SkinID="Unicodegrd">
<FooterStyle BackColor="White" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="1" HeaderText="Row Number">
<FooterStyle BackColor="White"></FooterStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Header 1"><FooterTemplate>
                                            <asp:Button id="btnAddRow" tabIndex=104 onclick="btnAddRow_Click" runat="server" Text="थप्नुहोस्" OnClientClick="javascript: return totalValidate(1);"></asp:Button> 
                                            
</FooterTemplate>
<ItemTemplate>
                                            <asp:TextBox id="TextBox1" runat="server" SkinID="Unicodetxt"></asp:TextBox> 
                                            
</ItemTemplate>

<FooterStyle BackColor="White" HorizontalAlign="Left"></FooterStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Header 2"><ItemTemplate>
                                            <asp:TextBox id="TextBox2" runat="server" SkinID="Unicodetxt"></asp:TextBox> 
                                            
</ItemTemplate>

<FooterStyle BackColor="White"></FooterStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Header 3"><ItemTemplate>
                                            <asp:TextBox id="TextBox3" runat="server" SkinID="Unicodetxt"></asp:TextBox> 
                                            
</ItemTemplate>

<FooterStyle BackColor="White"></FooterStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Header 4"><ItemTemplate>
                                            <asp:TextBox id="TextBox4" runat="server" SkinID="Unicodetxt"></asp:TextBox> 
                                            
</ItemTemplate>

<FooterStyle BackColor="White"></FooterStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Header 5"><ItemTemplate>

                                                                                                             <asp:TextBox ID="TextBox5" runat="server" SkinID="Unicodetxt"></asp:TextBox>

                                                                                                        
                                                                                                    
                                            
</ItemTemplate>

<FooterStyle BackColor="White"></FooterStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Header 6"><ItemTemplate>
                                                                                                                                                                     <asp:TextBox ID="TextBox6" runat="server" SkinID="Unicodetxt"></asp:TextBox>
                                                                                                                                                                
                                                                                                    
                                            
</ItemTemplate>

<FooterStyle BackColor="White"></FooterStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Header 7"><ItemTemplate>
                                                                                                                                                                     <asp:TextBox ID="TextBox7" runat="server" SkinID="Unicodetxt"></asp:TextBox>
                                                                                                                                                                
                                                                                                    
                                            
</ItemTemplate>

<FooterStyle BackColor="White"></FooterStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Header 8"><ItemTemplate>
                                                                                                                                                                     <asp:TextBox ID="TextBox8" runat="server" SkinID="Unicodetxt"></asp:TextBox>
                                                                                                                                                                
                                                                                                    
                                            
</ItemTemplate>

<FooterStyle BackColor="White"></FooterStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Header 9"><ItemTemplate>
                                                                                                                                                                     <asp:TextBox ID="TextBox9" runat="server" SkinID="Unicodetxt"></asp:TextBox>
                                                                                                                                                                
                                                                                                    
                                            
</ItemTemplate>

<FooterStyle BackColor="White"></FooterStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Header 10"><ItemTemplate>
                                                                                                                                                                     <asp:TextBox ID="TextBox10" runat="server" SkinID="Unicodetxt"></asp:TextBox>
                                                                                                                                                                
                                                                                                    
                                            
</ItemTemplate>

<FooterStyle BackColor="White"></FooterStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Header 11"><ItemTemplate>
                                                                                                                                                                     <asp:TextBox ID="TextBox11" runat="server" SkinID="Unicodetxt"></asp:TextBox>
                                                                                                                                                                
                                                                                                    
                                            
</ItemTemplate>

<FooterStyle BackColor="White"></FooterStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Header 12"><ItemTemplate>
                                                                                                                                                                     <asp:TextBox ID="TextBox12" runat="server" SkinID="Unicodetxt"></asp:TextBox>
                                                                                                                                                                
                                                                                                    
                                            
</ItemTemplate>

<FooterStyle BackColor="White"></FooterStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Header 13"><ItemTemplate>
                                                                                                                                                                     <asp:TextBox ID="TextBox13" runat="server" SkinID="Unicodetxt"></asp:TextBox>
                                                                                                                                                                
                                                                                                    
                                            
</ItemTemplate>

<FooterStyle BackColor="White"></FooterStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Header 14"><ItemTemplate>
                                                                                                                                                                     <asp:TextBox ID="TextBox14" runat="server" SkinID="Unicodetxt"></asp:TextBox>
                                                                                                                                                                
                                                                                                    
                                            
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
</asp:gridview>
<p height ="20px">
</p>

 </DIV>
                                                </td>
                                            </tr>
                                        </table>
                                        <table style="width: 1000px">
                                            <tr>
                                                <td style="width: 227px">
                                                    <asp:GridView id="grdAmountDate" runat="server" OnRowDataBound="grdAmountDate_RowDataBound" OnRowCreated="grdAmountDate_RowCreated" AutoGenerateColumns="False" ShowFooter="True" BorderStyle="None" ShowHeader="False" SkinID="Unicodegrd">
                                            <FooterStyle BackColor="White"></FooterStyle>
                                            <Columns>
                                            <asp:TemplateField HeaderText="Header 1">
                                            <ItemStyle Width="25px"></ItemStyle>
                                            <ItemTemplate>
                                            <asp:Label id="lblAmount" runat="server" Text="रु" SkinID="Unicodelbl"></asp:Label> 
                                            </ItemTemplate>

                                            <FooterStyle BackColor="White"></FooterStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Header 2"><FooterTemplate>
                                            <asp:Button id="btnAdd" tabIndex=104 onclick="btnAdd_Click" runat="server" Text="थप्नुहोस्" OnClientClick="return totalValidate(2)"></asp:Button> 
                                            </FooterTemplate>
                                            <ItemTemplate>
                                            <asp:TextBox id="txtAmount_ad" runat="server" MaxLength="10" SkinID="Unicodetxt"></asp:TextBox> 
                                            </ItemTemplate>

                                            <FooterStyle BackColor="White" HorizontalAlign="Left"></FooterStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Header 3">
                                            <ItemStyle BackColor="White"></ItemStyle>
                                            <ItemTemplate>
                                                                                                    <asp:TextBox id="txtDate_DT" runat="server" ToolTip="Property Date" SkinID="Unicodetxt"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender2" runat="server" TargetControlID="txtDate_DT" AutoComplete="False" Mask="9999/99/99" MaskType="Date"></ajaxToolkit:MaskedEditExtender> 
                                                                                                    
                                            </ItemTemplate>

                                            <FooterStyle BackColor="White" ForeColor="White"></FooterStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Header 4">
                                            <ItemStyle BackColor="White" Width="30px"></ItemStyle>
                                            <ItemTemplate>
                                                                                                                                        <asp:Label id="lblDate" runat="server" Text="साल" SkinID="Unicodelbl"></asp:Label> 
                                                                                                                                        
                                                                                                    
                                            </ItemTemplate>

                                            <FooterStyle BackColor="White" ForeColor="White"></FooterStyle>
                                            </asp:TemplateField>
                                            </Columns>
                                            </asp:GridView> 
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:Button id="btnSave" tabIndex=105 onclick="btnSave_Click" runat="server" Text="Submit" OnClientClick="javascript: return totalValidate(0);" Visible="False" SkinID="Normal"></asp:Button> 
</contenttemplate>
                                    <triggers>
<asp:AsyncPostBackTrigger ControlID="lstProperty" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
                                </asp:UpdatePanel>

