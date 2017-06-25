<%@ Page Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" AutoEventWireup="true" CodeFile="Tameli.aspx.cs" Inherits="MODULES_CMS_Tameli_Tameli" Title="CMS | Tameli" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/MODULES/CMS/UserControls/CaseSearch.ascx" TagName="CaseSearch" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



  
  
 <script type="text/javascript"> 
    
     function showHide(obj)
     {        
         if(obj.innerHTML == "Show Attorney")
         {   obj.innerHTML = "Hide Attorney"; 
             showSibling(obj);
         }
         else if(obj.innerHTML == "Hide Attorney")
         {
            obj.innerHTML = "Show Attorney";
            hideSibling(obj); 
         }
         else if(obj.innerHTML == "Show Witness")
         {
            obj.innerHTML = "Hide Witness";
            showSibling(obj); 
         }
         else if(obj.innerHTML == "Hide Witness")
         {
            obj.innerHTML = "Show Witness";
            hideSibling(obj); 
         }
     }    

     function hideSibling(obj)
     {                
        var nextElem = nextele(obj); 
        if (nextElem)                 
           nextElem.style.display = 'none'; 
       
     }
     function showSibling(obj)
     {                   
        var nextElem = nextele(obj);   
        if (nextElem)  
           nextElem.style.display = 'block'; 
     }

     function nextele(elem) { 
        do { 
            elem = elem.nextSibling; 
        } while (elem && elem.nodeType != 1 && elem.nodeName!="DIV" ); 
        return elem;                 
     } 
    
     function mouseOver(obj)
     {
        obj.style.cursor="pointer";
        obj.style.color="Green";
     }
     function mouseOut(obj)
     {        
        obj.style.color="Teal";
     }
     
     
     
  </script> 
   
   <script type="text/javascript">
  function CheckUncheck(AttCheckBox)
    { 
        var grid = document.getElementById("<%= grdLitigantsApp.ClientID %>");
        var grdAppRowCount = grid.rows.length  ;        
        var grida = document.getElementById("<%= grdLitigantRes.ClientID %>");  
        var grdResRowCount = grida.rows.length  ;
        
        var cApp=0;
        
        if( AttCheckBox == grid.rows[0].cells[0].children[0].getAttribute("id")    )
        {
             for(var x=1;x<grdAppRowCount;x++)
             {      
                var v=  grid.rows[x].cells[0].children[0]; 
                v.checked=grid.rows[0].cells[0].children[0].checked; 
             } 
        }    
        else if( AttCheckBox == grida.rows[0].cells[0].children[0].getAttribute("id")    )
        {
             for(var x=1;x<grdResRowCount;x++)
             {      
                var v=  grida.rows[x].cells[0].children[0]   ;
                v.checked=grida.rows[0].cells[0].children[0].checked;
             } 
        }
        else
        {        
            var ch1=true;
            for(var x=1;x<grdAppRowCount;x++)
            {  
                if(grid.rows[x].cells[0].children[0].checked==false)
                { ch1=false;}
               
                if( AttCheckBox == grid.rows[x].cells[0].children[0].getAttribute("id")    )
                { 
                   cApp=cApp+1;                             
                }                
            }
            if(cApp>0)
            {
                grid.rows[0].cells[0].children[0].checked=ch1;                           
            }            
            else
            {
                cRes=0;
                var ch2=true;
                for(var x=1;x<grdResRowCount;x++)
                {  
                    if(grida.rows[x].cells[0].children[0].checked==false)
                    { ch2=false;}
                   
                    if( AttCheckBox == grida.rows[x].cells[0].children[0].getAttribute("id")    )
                    { 
                       cRes=cRes+1;                             
                    }                
                }
                if(cRes>0)
                {
                    grida.rows[0].cells[0].children[0].checked=ch2;
                }  
            }        
        }         
     }  
     </script>
      
  <script type="text/javascript">
      
//        var grid = document.getElementById("<%= grdLitigantsApp.ClientID %>");
//        var grdAppRowCount = grid.rows.length  ;        
//        var grida = document.getElementById("<%= grdLitigantRes.ClientID %>");  
//        var grdResRowCount = grida.rows.length  ;
        
        function DDLChange()
        {
            var ddlMyaadType= document.getElementById('<%=ddlMyaadType.ClientID %>');  
            if(ddlMyaadType) 
            {     
                var ddlMyaadTypeSelectedValue= ddlMyaadType.options[ddlMyaadType.selectedIndex].value;        
                var ddlMyaadTypeSelectedText= ddlMyaadType.options[ddlMyaadType.selectedIndex].innerHTML;
                
                
                myArr=ddlMyaadTypeSelectedValue.split(",");

                litigant=myArr[0];
                attorney=myArr[1];
                witness=myArr[2];        
                
                if(litigant=="A")
                {
                    //alert("disable Respondant and enable Appelants");                
                    EnableDisableAppelant(false);
                    EnableDisableRespondant(true);
                    
                }
                else if(litigant=="R")
                {
                    //alert("disable Appelant and enable Respondant");
                    EnableDisableAppelant(true);
                    EnableDisableRespondant(false);
                }
                else if(litigant=="B")
                {
                    //alert("enable Appelant and Respondant ");
                    EnableDisableAppelant(false);
                    EnableDisableRespondant(false);
                }
                else
                {
                    //alert("disable Appelant and Respondant");
                    EnableDisableAppelant(true);
                    EnableDisableRespondant(true);
                }
                
                
                
                
                if(attorney=="A")
                {
                    //alert("disable Respondant's Attorneys and enable Appelant's Attorneys");
                    EnableDisableAppelantAttorney(false);
                    EnableDisableRespondantAttorney(true);
                }
                else if(attorney=="R")
                {
                    //alert("disable Appelant's Attorneys and enable Respondant's Attorneys");
                    EnableDisableAppelantAttorney(true);
                    EnableDisableRespondantAttorney(false);
                }
                else if(attorney=="B")
                {
                    //alert("enable Appelant's and Respondant's  Attorneys ");
                    EnableDisableAppelantAttorney(false);
                    EnableDisableRespondantAttorney(false);
                }
                
                else
                {
                    //alert("disable Appelant's and Respondant's  Attorneys");
                    EnableDisableAppelantAttorney(true);
                    EnableDisableRespondantAttorney(true);
                }
                
                
                if(witness=="A")
                {
                    //alert("disable Respondant's Witnesses and enable Appelant's Witnesses ");
                    EnableDisableAppelantWitness(false);
                    EnableDisableRespondantWitness(true);
                }
                else if(witness=="R")
                {
                    //alert("disable Appelant's Witnesses and enable Respondant's Witnesses");
                    EnableDisableAppelantWitness(true);
                    EnableDisableRespondantWitness(false);
                }
                else if(witness=="B")
                {
                    //alert("enable Appelant's and Respondant's  Witnesses ");
                    EnableDisableAppelantWitness(false);
                    EnableDisableRespondantWitness(false);
                }
                else
                {
                    //alert("disable Appelant's and Respondant's  Witnesses");
                    EnableDisableAppelantWitness(true);
                    EnableDisableRespondantWitness(true);
                }  
            }  
        }
        
        function EnableDisableAppelant(disable)
		 {   var grdLitigantsApp = document.getElementById("<%= grdLitigantsApp.ClientID %>");
		     if(grdLitigantsApp)
		     {
                 var grdAppRowCount = grdLitigantsApp.rows.length  ;             
                 for(var x = 0;x < grdAppRowCount; x++)
                 {    
                    var v=  grdLitigantsApp.rows[x].cells[0].children[0];
                    v.checked=false ;
				    v.disabled=disable;
                 }         
             }
         }		 
		 
		 function EnableDisableRespondant(disable)
		 {   
		     var grdLitigantRes = document.getElementById("<%= grdLitigantRes.ClientID %>");  
		     if(grdLitigantRes)
		     {
                 var grdResRowCount = grdLitigantRes.rows.length  ;            
                 for(var x=0;x<grdResRowCount;x++)
			     {     
                    var v=  grdLitigantRes.rows[x].cells[0].children[0]   ;
                    v.checked=false ;
				    v.disabled=disable;
                 }     
             }    
         }	 
		
		
		///////////////////////	
		
		
		 function EnableDisableAppelantAttorney(disable)
		 {   
		     var grdLitigantsApp = document.getElementById("<%= grdLitigantsApp.ClientID %>");
             if(grdLitigantsApp)
		     {
                 var grdAppRowCount = grdLitigantsApp.rows.length  ;
			     for(var x = 1;x < grdAppRowCount; x++)
	             {   
	                   var appelantAttorney = grdLitigantsApp.rows[x].cells[8].children[1].children[0];                         
                       if(appelantAttorney.innerHTML!="")
                       {
                            var node=appelantAttorney.children[0].children[0];                            
                            for(var a = 1; a < node.rows.length; a++)
                            {
                                node.children[a].children[0].children[0].checked = false;
							    node.children[a].children[0].children[0].disabled = disable;
                            }
                       }            
	             }
	         }
		 }		 
		 
		 ////////////////////////
		 function EnableDisableRespondantAttorney(disable)
		 {
		     var grdLitigantRes = document.getElementById("<%= grdLitigantRes.ClientID %>");  
             if(grdLitigantRes)
		     {
                 var grdResRowCount = grdLitigantRes.rows.length  ;
			     for(var x=1;x<grdResRowCount;x++)
			     {           
                     var respondantAttorney = grdLitigantRes.rows[x].cells[8].children[1].children[0];                 
                     if(respondantAttorney.innerHTML!="")
                     {
                        var node=respondantAttorney.children[0].children[0]; 
                        
                        for(var a = 1; a < node.rows.length; a++)
                        {
                            node.children[a].children[0].children[0].checked = false;
						    node.children[a].children[0].children[0].disabled = disable;
                        }
                     }
                 }
             }
		 }
		 
	/////////////////////////////
	
		 function EnableDisableAppelantWitness(disable)
		 {   
		     var grdLitigantsApp = document.getElementById("<%= grdLitigantsApp.ClientID %>");
             if(grdLitigantsApp)
		     {
                 var grdAppRowCount = grdLitigantsApp.rows.length  ;
			     for(var x = 1;x < grdAppRowCount; x++)
	             {   
					     var appelantWitness = grdLitigantsApp.rows[x].cells[9].children[1].children[0];                         
                         if(appelantWitness.innerHTML!="")
                         {
                            var node=appelantWitness.children[0].children[0];                            
                            for(var a = 1; a < node.rows.length; a++)
                            {
                                node.children[a].children[0].children[0].checked = false;
							    node.children[a].children[0].children[0].disabled = disable;
                            }
                         }      
	             }
	         }
		 }
		 
     /////////////////////////
	     function EnableDisableRespondantWitness(disable)
		 {
		     var grdLitigantRes = document.getElementById("<%= grdLitigantRes.ClientID %>");  
             if(grdLitigantRes)
		     {
                 var grdResRowCount = grdLitigantRes.rows.length  ;
			     for(var x=1;x<grdResRowCount;x++)
			     {           
                     var respondantWitness = grdLitigantRes.rows[x].cells[9].children[1].children[0];                 
                     if(respondantWitness.innerHTML!="")
                     {
                        var node=respondantWitness.children[0].children[0];                    
                        for(var a = 1; a < node.rows.length; a++)
                        {
                            node.children[a].children[0].children[0].checked = false;
						    node.children[a].children[0].children[0].disabled = disable;
                        }
                     }
                 }
             }
		 }
	
	
	
     
  </script>
  
  <script type="text/javascript">
    function disableAllCheckBoxes()
    {
        EnableDisableAppelant(true); 
	    EnableDisableRespondant(true);
	    EnableDisableAppelantAttorney(true);
	    EnableDisableRespondantAttorney(true);
	    EnableDisableAppelantWitness(true);
	    EnableDisableRespondantWitness(true);
	}
  </script>  

    <asp:ScriptManager id="scriptMNGR" runat="server">
    </asp:ScriptManager>
    <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground"
        BehaviorID="programmaticModalPopupBehavior" DropShadow="True" PopupControlID="programmaticPopup"
        PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
        TargetControlID="hiddenTargetControlForModalPopup">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none;
        width: 350px; padding: 10px">
        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD;
            border: solid 1px Gray; color: Black; text-align: center;">
            <asp:Label ID="lblStatus" runat="server" Text="Label"></asp:Label>&nbsp;</asp:Panel>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
<asp:Label id="lblStatusMessage" runat="server" Text="Label" __designer:wfdid="w3"></asp:Label> 
</ContentTemplate>
            <triggers>
<asp:AsyncPostBackTrigger ControlID="OkButton" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
        </asp:UpdatePanel>
        &nbsp;
        <br />
        <asp:Button ID="OkButton" runat="server" 
            Text="OK" Width="58px" OnClientClick="javascript:$find('programmaticModalPopupBehavior').hide();" OnClick="hideModalPopupViaServer_Click"  /></asp:Panel>
   <div style="min-height:400px" >
    <table width="1000px">
        <tr>
            <td >
            <asp:Panel ID="pnlCase" runat="server" CssClass="collapsePanelHeader" 
                Width="1000px">
                मुद्दा खोज्नुहोस्                
            </asp:Panel>
                <ajaxToolkit:CollapsiblePanelExtender ID="collCasesearch" runat="server" CollapseControlID="pnlCase"
                    CollapsedImage="../../COMMON/Images/expand_blue.jpg" ExpandControlID="pnlCase"
                    ExpandedImage="../../COMMON/Images/collapse_blue.jpg" ImageControlID="imgCol"
                    SkinID="CollapsiblePanelDemo" SuppressPostBack="True" TargetControlID="pnlCaseSearch">
                </ajaxToolkit:CollapsiblePanelExtender>
            <asp:Panel ID="pnlCaseSearch" runat="server"  
                Width="1000px">
                    <uc1:CaseSearch ID="CaseSearch1" runat="server" DecisionYesNo="U" VerifiedYesNo="Y"  />
            </asp:Panel>
            </td>
        </tr>
    </table>
    <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server" 
        TargetControlID="pnlMain" >
    </ajaxToolkit:CollapsiblePanelExtender>
    <asp:Panel ID="pnlMain" runat="server">
     <table width="1000">
                    <tr>
                        <td colspan="2" valign="top">
                            <asp:UpdatePanel id="UpdatePanel1" runat="server">
                            
                                <contenttemplate>
<TABLE width=1000><TBODY><TR><TD style="WIDTH: 183px" vAlign=top><asp:Label id="Label7" runat="server" Width="115px" Text="तामेलीका किसिम" SkinID="Unicodelbl"></asp:Label> </TD><TD style="WIDTH: 1000px" vAlign=top><asp:DropDownList id="ddlTameliType" runat="server" Width="573px" SkinID="Unicodeddl" DataValueField="TameliTypeID" DataTextField="TameliTypeName" OnSelectedIndexChanged="ddlTameliType_SelectedIndexChanged" AutoPostBack="True">
</asp:DropDownList> </TD></TR><TR><TD vAlign=top></TD><TD style="WIDTH: 1000px" vAlign=top><asp:Panel id="pnlEmpSearch" runat="server" Width="650px" GroupingText="Tamildaars"><asp:GridView id="grdEmpSearch" runat="server" Width="600px" SkinID="Unicodegrd" CellPadding="0" DataKeyNames="EmpID" ForeColor="#333333" GridLines="None" OnRowCreated="grdEmpSearch_RowCreated" AutoGenerateColumns="False">
<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
<asp:BoundField DataField="SymbolNo" HeaderText="संकेत नं"></asp:BoundField>
<asp:BoundField DataField="EmpID" HeaderText="EmpID"></asp:BoundField>
<asp:BoundField DataField="FullName" HeaderText="पुरा नाम"></asp:BoundField>
<asp:BoundField DataField="fullGender" HeaderText="लिंग"></asp:BoundField>
<asp:BoundField DataField="OrgID" HeaderText="OrgID"></asp:BoundField>
<asp:BoundField DataField="OrgName" HeaderText="कर्यालयको नाम"></asp:BoundField>
<asp:BoundField DataField="OrgEmpNo" HeaderText="OrgEmpNo"></asp:BoundField>
<asp:BoundField DataField="OrgUnitID" HeaderText="UnitID"></asp:BoundField>
<asp:BoundField DataField="UnitName" HeaderText="शाखा"></asp:BoundField>
<asp:BoundField DataField="Post" HeaderText="पद"></asp:BoundField>
<asp:BoundField DataField="DesType" HeaderText="DesType"></asp:BoundField>
<asp:BoundField DataField="FromDate" HeaderText="देखि"></asp:BoundField>
<asp:BoundField DataField="Responsibility" HeaderText="जिम्मेवारी"></asp:BoundField>
<asp:BoundField HeaderText="जन्म मिति"></asp:BoundField>
<asp:CommandField ShowSelectButton="True"></asp:CommandField>
</Columns>

<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView><asp:Label id="Label3" runat="server" Width="182px" Text="Tamildaar Received Date" SkinID="Unicodelbl" __designer:wfdid="w8"></asp:Label> <asp:TextBox id="txtTamildaarReceivedDate" runat="server" SkinID="Unicodetxt" __designer:wfdid="w9" MaxLength="100"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender2" runat="server" TargetControlID="txtTamildaarReceivedDate" __designer:wfdid="w10" ClearMaskOnLostFocus="False" MaskType="Date" Mask="9999/99/99" AutoComplete="False"></ajaxToolkit:MaskedEditExtender></asp:Panel> <asp:Panel id="pnlCourts" runat="server" Width="400px" GroupingText="Courts">
 <asp:DropDownList id="ddlCourt" runat="server" Width="336px" SkinID="Unicodeddl">
    </asp:DropDownList> 
    </asp:Panel> <asp:Panel id="pnlTameliMedia" runat="server" Width="400px" GroupingText="Tameli Media">
                    <table>
                    <tr>
                    <td valign="top">
                    <asp:Label id="Label4as" runat="server" Width="146px" Text="तामेलि माद्यम" SkinID="Unicodelbl" ></asp:Label>
                    </td>
                    <td valign="top">
                    <asp:TextBox id="txtTameliMedia" runat="server" SkinID="Unicodetxt"  MaxLength="100"></asp:TextBox>
                    </td>
                    </tr>
                    <tr>
                    <td valign="top"><asp:Label id="Label2asd" runat="server" Width="146px" Text="प्रकाशन मिति" SkinID="Unicodelbl" ></asp:Label>
                    </td>
                    <td valign="top">
                    <asp:TextBox id="txtPublicationDate" runat="server" Width="90px" SkinID="Unicodetxt"></asp:TextBox>
                    <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender1asd" runat="server"  TargetControlID="txtPublicationDate" ClearMaskOnLostFocus="False" MaskType="Date" Mask="9999/99/99" AutoComplete="False" ></ajaxToolkit:MaskedEditExtender>
                    </td>
                    </tr>
                    
                    </table>
                    </asp:Panel> </TD></TR></TBODY></TABLE><%--<asp:Panel id="pnlTamWitPerson" runat="server" Width="100%">
                     <TABLE><TBODY><TR><TD style="WIDTH: 155px" vAlign=top><asp:Label id="Label4" runat="server" Width="146px" Text="Tameli Witness Person" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 100px" vAlign=top><asp:TextBox id="txtTameliWitnessPerson" runat="server" Width="250px" SkinID="Unicodetxt" MaxLength="100"></asp:TextBox></TD><TD style="WIDTH: 60px" vAlign=top></TD><TD style="WIDTH: 40px" vAlign=top><asp:Label id="Label8" runat="server" Width="42px" Height="16px" Text="पद" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 7px" vAlign=top><asp:TextBox id="txtPost" runat="server" Width="203px" SkinID="Unicodetxt" MaxLength="50"></asp:TextBox></TD></TR></TBODY></TABLE>
                     </asp:Panel>--%>
</contenttemplate>
                            </asp:UpdatePanel>
                            </td>
                    </tr>
                    <tr>
                        <td valign="top" style="width: 79px">
                            &nbsp;<asp:Label ID="Label6" runat="server" SkinID="Unicodelbl" Text="जारी मिति"></asp:Label></td>
                        <td valign="top">
                            <asp:TextBox ID="txtIssuedDate" runat="server" SkinID="Unicodetxt" Width="90px"></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AutoComplete="False"
                                Mask="9999/99/99" MaskType="Date" TargetControlID="txtIssuedDate" ClearMaskOnLostFocus="False">
                            </ajaxToolkit:MaskedEditExtender>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="width: 79px">
                            &nbsp;<asp:Label ID="Label1" runat="server" SkinID="Unicodelbl" Text="म्यादका किसिम" Width="105px"></asp:Label></td>
                        <td valign="top">
                            <asp:DropDownList ID="ddlMyaadType"  onchange="DDLChange();"   runat="server" DataTextField="MyaadTypeName"
                                DataValueField="LitAttWit" SkinID="Unicodeddl" Width="573px">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td valign="top" style="width: 79px">
                        </td>
                        <td valign="top">
                            
                        </td>
                    </tr>
                </table>
    <table width="1000px">
        <tr>
            <td >
                <asp:Label ID="Label4sa" runat="server" Height="22px" SkinID="Unicodelbl" Text="वादि"
                    Width="92px" Font-Bold="True"></asp:Label>&nbsp;
                <asp:Panel ID="pnlApp" runat="server" Height="150px" ScrollBars="Auto" Width="1000px">
                <asp:GridView ID="grdLitigantsApp" runat="server" AutoGenerateColumns="False" OnRowDataBound="grdLitigantsApp_RowDataBound"
                    SkinID="Unicodegrd" Width="1000px" >
                    
                    <Columns>
                         <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left">
                            <%--<HeaderTemplate>
                                <asp:CheckBox ID="chk" runat="server" OnCheckedChanged="chkHEADER_CheckedChanged" AutoPostBack="true"  />                            
                            </HeaderTemplate>                           
                            <ItemTemplate>
                                <asp:CheckBox ID="chk"  runat="server" OnCheckedChanged="chk_CheckedChanged" AutoPostBack="true"  />
                            </ItemTemplate>--%>
                            <HeaderTemplate>
                                <asp:CheckBox ID="chk" runat="server"   />                            
                            </HeaderTemplate>                           
                            <ItemTemplate>
                                <asp:CheckBox ID="chk"  runat="server"  />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CaseID" HeaderText="मुद्दाको आइडि" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="LitigantID" HeaderText="Litigant ID" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"/>
                        <asp:BoundField DataField="CaseRegDate" HeaderText="दर्ता मिति" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"/>
                        <asp:BoundField DataField="RegNo" HeaderText="दर्ता नं" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"/>
                        <asp:BoundField DataField="CaseNo" HeaderText="मुद्दा नं" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"/>
                        <asp:BoundField DataField="LitigantName" HeaderText="पूरा नामथर" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"/>   
                        <asp:BoundField DataField="Gender" HeaderText="लिंग" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"/>
                        <asp:BoundField DataField="DOB" HeaderText="जन्म मिति" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"/>
                        <asp:BoundField DataField="LitigantTypeName" HeaderText="वादि/प्रतिवादि" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"/>
                        <asp:BoundField DataField="DisplayName" HeaderText="देखाउने नाम" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"/>
                        <asp:BoundField DataField="LitigantSubTypeName" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"/>
                        <asp:BoundField DataField="SNo" HeaderText="प्राथमीकता" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"/>
                        <asp:BoundField DataField="IsPrisoned" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"/>  
                       <asp:TemplateField  ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left">
                            <HeaderTemplate >
                            वारिश                             
                            </HeaderTemplate> 
                            <HeaderStyle HorizontalAlign="center" />                           
                            <ItemTemplate >                            
                                    <div id="divShow" onmouseover="mouseOver(this)" onmouseout="mouseOut(this)"  onclick="showHide(this)" style="color:Teal;font-size:11px;" >Show Attorney</div>
                                <%--<asp:Panel id="pnlAttorney1" runat="server" Width="300px" ScrollBars="Auto">--%>
                                 <div id="Childa" style="max-width:300px;max-height:60px;overflow:scroll;display:none">  
                                    <asp:GridView ID="grdAttorney1" runat="server" AutoGenerateColumns="False" CellPadding="0" OnRowDataBound="grdAttorney_RowDataBound"
                                        ForeColor="#333333" SkinID="Unicodegrd" Width="300px" >
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333"  />
                                        
                                        <Columns>
                                            <asp:BoundField DataField="CaseID" HeaderText="CaseID" ></asp:BoundField>
                                            <asp:BoundField DataField="LitigantID" HeaderText="LitigantID" ></asp:BoundField>
                                            <asp:BoundField DataField="AttorneyID" HeaderText="Attorney ID" ></asp:BoundField>
                                            <asp:BoundField DataField="AttorneyTypeID" HeaderText="AttorneyTypeID" ></asp:BoundField>                        
                                            
                                            <asp:BoundField DataField="RegistrationNo" HeaderText="दर्ता नं" ></asp:BoundField>
                                            <asp:BoundField DataField="CaseNo" HeaderText="मुद्दा नं" ></asp:BoundField>
                                            <asp:BoundField DataField="LitigantName" HeaderText="वादि्/प्रतिवादिको नाम" ></asp:BoundField>
                                            <asp:TemplateField>                                                                      
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chk"  runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="AttorneyName"  HeaderText="वारिशको नाम"  ></asp:BoundField>
                                           
                                            <asp:BoundField DataField="AttorneyType" HeaderText="वारिशको प्रकार"  ></asp:BoundField>
                                            <asp:BoundField DataField="FromDate" HeaderText="देखि"  ></asp:BoundField>
                                            <asp:BoundField DataField="ToDate" HeaderText="सम्म" ></asp:BoundField>
                                            <asp:BoundField DataField="Active" HeaderText="सक्रिय" ></asp:BoundField>
                                            <asp:BoundField DataField="Action" HeaderText="Action" ></asp:BoundField>                                            
                                        </Columns>
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"  />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"  />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"  />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"  />
                                        <EditRowStyle BackColor="#999999"  />
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775"  />
                                        
                                    </asp:GridView>
                                    </div>
                              <%--   </asp:Panel>--%>
                                 
                            </ItemTemplate>
                            
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Witness" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left">
                            <HeaderTemplate >
                            साक्षी                               
                            </HeaderTemplate>     
                            <HeaderStyle HorizontalAlign="center" />                              
                            <ItemTemplate>
                                <div id="divShow" onmouseover="mouseOver(this)" onmouseout="mouseOut(this)"   onclick="showHide(this)" style="color:Teal;font-size:11px;" >Show Witness</div>
                                <%--<asp:Panel id="pnlTameliWitPerson1" runat="server" Width="300px" ScrollBars="Auto">--%>
                                      <div id="childa" style="max-width:300px;max-height:60px;overflow:scroll;display:none">  
                                    <asp:GridView ID="grdTamWitPerson1" runat="server" AutoGenerateColumns="False" Width="300px" SkinID="Unicodegrd" OnRowDataBound="grdTamWitPerson_RowDataBound" >
                                    <Columns>
                                        <asp:BoundField DataField="CaseID" HeaderText="CaseID" ></asp:BoundField>
                                        <asp:BoundField DataField="LitigantID" HeaderText="LitigantID" ></asp:BoundField>
                                        <asp:BoundField DataField="WitnessID" HeaderText="WitnessID" ></asp:BoundField>
                                        <asp:TemplateField>                                                                      
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chk"  runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                         <asp:BoundField DataField="WitnessName" HeaderText="साक्षीको नाम " ></asp:BoundField>
                                        <asp:BoundField DataField="WitnessGender" HeaderText="लिंग" ></asp:BoundField>
                                        <asp:BoundField DataField="WitnessDOB" HeaderText="जन्म मिति" ></asp:BoundField>
                                    </Columns>
                                    </asp:GridView>
                                </div>
                               <%-- </asp:Panel>   --%>                             
                            </ItemTemplate> 
                        </asp:TemplateField>                    
                    </Columns>
                </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="height: 193px" >
                <asp:Label ID="Label5a" runat="server" Height="22px" SkinID="Unicodelbl" Text="प्रतिवादि"
                    Width="92px" Font-Bold="True"></asp:Label>
                <asp:Panel ID="pnlRes" runat="server" Height="150px" ScrollBars="Auto" Width="1000px">
                <asp:GridView ID="grdLitigantRes" runat="server" AutoGenerateColumns="False" 
                    OnRowDataBound="grdLitigantsRes_RowDataBound" SkinID="Unicodegrd" Width="1000px">                   
                    <Columns>
                   
                        <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left">
                            <%--<HeaderTemplate >
                                <asp:CheckBox ID="chkRes" runat="server" AutoPostBack="true" OnCheckedChanged="chkHEADERRes_CheckedChanged" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkRes" runat="server" AutoPostBack="true" OnCheckedChanged="chkRes_CheckedChanged" />
                            </ItemTemplate>--%>
                            <HeaderTemplate >
                                <asp:CheckBox ID="chkRes" runat="server" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkRes" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CaseID" HeaderText="मुद्दाको आइडि" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="LitigantID" HeaderText="Litigant ID" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="CaseRegDate" HeaderText="दर्ता मिति"  ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"/>
                        <asp:BoundField DataField="RegNo" HeaderText="दर्ता नं" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="CaseNo" HeaderText="मुद्दा नं" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"/>
                        <asp:BoundField DataField="LitigantName" HeaderText="पूरा नामथर" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"> 
                        </asp:BoundField>
                        <asp:BoundField DataField="Gender" HeaderText="लिंग" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"/>
                        <asp:BoundField DataField="DOB" HeaderText="जन्म मिति" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"/>
                        <asp:BoundField DataField="LitigantTypeName" HeaderText="वादि/प्रतिवादि" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"/>
                        <asp:BoundField DataField="DisplayName" HeaderText="देखाउने नाम" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"/>
                         <asp:BoundField DataField="LitigantSubTypeName" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"/>
                        <asp:BoundField DataField="SNo" HeaderText="प्राथमीकता" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"/>
                        <asp:BoundField DataField="IsPrisoned" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateField  ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left">
                            <HeaderTemplate >
                            वारिश                             
                            </HeaderTemplate> 
                            <HeaderStyle HorizontalAlign="center" />                           
                            <ItemTemplate >                            
                                    <div id="divShow" onmouseover="mouseOver(this)" onmouseout="mouseOut(this)"    onclick="showHide(this)" style="color:Teal;font-size:11px;" >Show Attorney</div>
                                    
                               <%-- <asp:Panel id="pnlAttorney"  runat="server" Width="300px" ScrollBars="Auto">--%>
                                <div style="max-width:300px;max-height:60px;overflow:scroll;display:none">
                                    <asp:GridView ID="grdAttorney" runat="server" AutoGenerateColumns="False" CellPadding="0" OnRowDataBound="grdAttorney_RowDataBound"
                                        ForeColor="#333333" SkinID="Unicodegrd" Width="300px" >
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333"  />
                                        
                                        <Columns>
                                            <asp:BoundField DataField="CaseID" HeaderText="CaseID" ></asp:BoundField>
                                            <asp:BoundField DataField="LitigantID" HeaderText="LitigantID" ></asp:BoundField>
                                            <asp:BoundField DataField="AttorneyID" HeaderText="Attorney ID" ></asp:BoundField>
                                            <asp:BoundField DataField="AttorneyTypeID" HeaderText="AttorneyTypeID" ></asp:BoundField>                        
                                            
                                            <asp:BoundField DataField="RegistrationNo" HeaderText="दर्ता नं" ></asp:BoundField>
                                            <asp:BoundField DataField="CaseNo" HeaderText="मुद्दा नं" ></asp:BoundField>
                                            <asp:BoundField DataField="LitigantName" HeaderText="वादि्/प्रतिवादिको नाम" ></asp:BoundField>
                                            <asp:TemplateField>                                                                      
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chk"  runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="AttorneyName"  HeaderText="वारिशको नाम"  ></asp:BoundField>
                                           
                                            <asp:BoundField DataField="AttorneyType" HeaderText="वारिशको प्रकार"  ></asp:BoundField>
                                            <asp:BoundField DataField="FromDate" HeaderText="देखि"  ></asp:BoundField>
                                            <asp:BoundField DataField="ToDate" HeaderText="सम्म" ></asp:BoundField>
                                            <asp:BoundField DataField="Active" HeaderText="सक्रिय" ></asp:BoundField>
                                            <asp:BoundField DataField="Action" HeaderText="Action" ></asp:BoundField>                                            
                                        </Columns>
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"  />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"  />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"  />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"  />
                                        <EditRowStyle BackColor="#999999"  />
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775"  />
                                        
                                    </asp:GridView>
                                    </div>
                                <%-- </asp:Panel>--%>
                                 
                            </ItemTemplate>
                            
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Witness" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left">
                            <HeaderTemplate >
                            साक्षी                               
                            </HeaderTemplate>     
                            <HeaderStyle HorizontalAlign="center" />                              
                            <ItemTemplate>
                                <div id="divShow" onmouseover="mouseOver(this)" onmouseout="mouseOut(this)"   onclick="showHide(this)" style="color:Teal;font-size:11px;" >Show Witness</div>
                               <%-- <asp:Panel id="pnlTameliWitPerson" runat="server" Width="300px" ScrollBars="Auto">--%>
                                  <div style="max-width:300px;max-height:60px;overflow:scroll;display:none">   
                                    <asp:GridView ID="grdTamWitPerson" runat="server" AutoGenerateColumns="False" Width="300px" SkinID="Unicodegrd" OnRowDataBound="grdTamWitPerson_RowDataBound" >
                                    <Columns>
                                        <asp:BoundField DataField="CaseID" HeaderText="CaseID" ></asp:BoundField>
                                        <asp:BoundField DataField="LitigantID" HeaderText="LitigantID" ></asp:BoundField>
                                        <asp:BoundField DataField="WitnessID" HeaderText="WitnessID" ></asp:BoundField>
                                        <asp:TemplateField>                                                                      
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chk"  runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                         <asp:BoundField DataField="WitnessName" HeaderText="साक्षीको नाम " ></asp:BoundField>
                                        <asp:BoundField DataField="WitnessGender" HeaderText="लिंग" ></asp:BoundField>
                                        <asp:BoundField DataField="WitnessDOB" HeaderText="जन्म मिति" ></asp:BoundField>
                                    </Columns>
                                    </asp:GridView>
                                </div>
                               <%-- </asp:Panel>--%>                                
                            </ItemTemplate> 
                        </asp:TemplateField>
                        
                    </Columns>
                </asp:GridView>
                </asp:Panel>
                
            </td>
        </tr>
        <tr>
            <td  >
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
        </tr>
        <tr>
            <td valign="top">
               
                </td>
        </tr>
    </table>
     </asp:Panel>
     <asp:Panel ID="pnlassign" runat="server" CssClass="collapsePanelHeader" 
                Width="1000px">
                    Assign Tamildaar To Tameli Issued To This Organisation&nbsp;</asp:Panel>
                <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender3" runat="server" CollapseControlID="pnlassign"
                    CollapsedImage="../../COMMON/Images/expand_blue.jpg" ExpandControlID="pnlassign"
                    ExpandedImage="../../COMMON/Images/collapse_blue.jpg" 
                    SkinID="CollapsiblePanelDemo" SuppressPostBack="True" TargetControlID="pnlAssignTamildaar">
                </ajaxToolkit:CollapsiblePanelExtender>
            
            <asp:Panel ID="pnlAssignTamildaar" runat="server"  
                Width="1000px">
                <table width="1000">
                    <tr>
                        <td >
                <asp:GridView ID="grdAssignTamildaar" runat="server" AutoGenerateColumns="False" CellPadding="0"
                    ForeColor="#333333" OnRowDataBound="grdAssignTamildaar_RowDataBound"
                    SkinID="Unicodegrd" Width="983px">
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
                        <td >
                            <asp:Label ID="Label8" runat="server" Font-Bold="True" Height="22px" SkinID="Unicodelbl"
                                Text="Tamildaar" Width="92px"></asp:Label></td>
                    </tr>
                    <tr>
                        <td >
                            <asp:GridView ID="grdTamilDaar" runat="server" AutoGenerateColumns="False" CellPadding="0"
                                DataKeyNames="EmpID" ForeColor="#333333" GridLines="None" OnRowCreated="grdTamilDaar_RowCreated"
                                SkinID="Unicodegrd" Width="600px">
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="SymbolNo" HeaderText="संकेत नं" />
                                    <asp:BoundField DataField="EmpID" HeaderText="EmpID" />
                                    <asp:BoundField DataField="FullName" HeaderText="पुरा नाम" />
                                    <asp:BoundField DataField="fullGender" HeaderText="लिंग" />
                                    <asp:BoundField DataField="OrgID" HeaderText="OrgID" />
                                    <asp:BoundField DataField="OrgName" HeaderText="कर्यालयको नाम" />
                                    <asp:BoundField DataField="OrgEmpNo" HeaderText="OrgEmpNo" />
                                    <asp:BoundField DataField="OrgUnitID" HeaderText="UnitID" />
                                    <asp:BoundField DataField="UnitName" HeaderText="शाखा" />
                                    <asp:BoundField DataField="Post" HeaderText="पद" />
                                    <asp:BoundField DataField="DesType" HeaderText="DesType" />
                                    <asp:BoundField DataField="FromDate" HeaderText="देखि" />
                                    <asp:BoundField DataField="Responsibility" HeaderText="जिम्मेवारी" />
                                    <asp:BoundField HeaderText="जन्म मिति" />
                                    <asp:CommandField ShowSelectButton="True" />
                                </Columns>
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <EditRowStyle BackColor="#999999" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td style="height: 26px; width: 7px;" valign="top">
                                        <asp:Label ID="Labela3" runat="server" SkinID="Unicodelbl" Text="Tamildaar Received Date"
                                            Width="182px"></asp:Label></td>
                                    <td style="height: 26px; width: 63px;" valign="top">
                                        <asp:TextBox ID="txtamilDaarReceivedDate1" runat="server" SkinID="Unicodetxt" Width="90px"></asp:TextBox><br />
                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" AutoComplete="False"
                                Mask="9999/99/99" MaskType="Date" TargetControlID="txtamilDaarReceivedDate1" ClearMaskOnLostFocus="False">
                                        </ajaxToolkit:MaskedEditExtender>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td style="height: 26px" valign="top">
                                        <asp:Button ID="btnAssign" runat="server" OnClick="btnAssign_Click" SkinID="Normal" Text="Save" />
                                    </td>
                                    <td style="height: 26px; width: 63px;" valign="top">
                                        <asp:Button ID="btnCancelAssign" runat="server" OnClick="btnCancelAssign_Click" OnClientClick="return confirm('Are you sure you want to cancel ?');"
                                            SkinID="Cancel" Text="Cancel" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                </asp:Panel> 
     <asp:Panel ID="pnlDelete" runat="server" CssClass="collapsePanelHeader" 
                Width="1000px">
                Delete Tameli Issued                
            </asp:Panel>
                <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender2" runat="server" CollapseControlID="pnlDelete"
                    CollapsedImage="../../COMMON/Images/expand_blue.jpg" ExpandControlID="pnlDelete"
                    ExpandedImage="../../COMMON/Images/collapse_blue.jpg" 
                    SkinID="CollapsiblePanelDemo" SuppressPostBack="True" TargetControlID="pnlDeleteIssuedTameli">
                </ajaxToolkit:CollapsiblePanelExtender>
            <asp:Panel ID="pnlDeleteIssuedTameli" runat="server"  
                Width="1000px"><asp:GridView ID="grdTameli" runat="server" AutoGenerateColumns="False" CellPadding="0"
                    ForeColor="#333333" OnRowDataBound="grdTameli_RowDataBound" SkinID="Unicodegrd"
                    Width="983px" OnRowDeleting="grdTameli_RowDeleting">
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
       
    <br />
     
       
</ div>

</asp:Content>

