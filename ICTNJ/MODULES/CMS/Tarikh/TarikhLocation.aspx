<%@ Page Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" AutoEventWireup="true" CodeFile="TarikhLocation.aspx.cs" Inherits="MODULES_CMS_Tarikh_TarikhLocation" Title="CMS | Tarikh Location" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../UserControls/CaseSearch.ascx" TagName="CaseSearch" TagPrefix="uc1" %>

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
        //obj.style.fontWeight="bold";
        obj.style.color="Blue";
        document.body.style.cursor='pointer';
        
     }
     function mouseOut(obj)
     {
        obj.style.fontWeight="normal";
        obj.style.color="Green";
        document.body.style.cursor='default';
     }
     
  </script> 

<script type="text/javascript" src="../Forms/jquery-1.3.2.js"></script>
<script type="text/javascript">
 $(document).ready(function() {
          $('#viewAllControl').click(function() {
               $('#viewAllDiv').toggle("slow");
               return false;
          });
          
          
     });


</script>
    <asp:ScriptManager id="scriptMNGR" runat="server">
    </asp:ScriptManager>
    <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display : none" />
    <ajaxtoolkit:modalpopupextender
        id="programmaticModalPopup" runat="server" backgroundcssclass="modalBackground"
        behaviorid="programmaticModalPopupBehavior" dropshadow="True" popupcontrolid="programmaticPopup"
        popupdraghandlecontrolid="programmaticPopupDragHandle" repositionmode="RepositionOnWindowScroll"
        targetcontrolid="hiddenTargetControlForModalPopup"> </ajaxtoolkit:modalpopupextender>
        <asp:UpdatePanel id="UpdatePanel3" runat="server">
                <contenttemplate>
        <asp:Panel
            ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="padding-right: 10px;
            display: none; padding-left: 10px; padding-bottom: 10px; width: 350px; padding-top: 10px">
            <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="border-right: gray 1px solid;
                border-top: gray 1px solid; border-left: gray 1px solid; cursor: move; color: black;
                border-bottom: gray 1px solid; background-color: #dddddd; text-align: center">
                <asp:Label ID="lblStatus" runat="server" Text="Status"></asp:Label>&nbsp;</asp:Panel>
            
<asp:Label id="lblStatusMessage" runat="server" Text=""></asp:Label> 

            <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
                Text="OK" Width="58px" />
            <br />
        </asp:Panel>
        </contenttemplate>
            </asp:UpdatePanel>
   <div style="min-height:400px">
    <table width="100px">
        <tr>
            <td style="width: 796px; height: 21px" >
                <uc1:CaseSearch ID="CaseSearch1" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 796px; height: 21px;" >
                </td>
        </tr>
    </table>
    
    <div runat="server" id="displayAllControlDiv" style="width:100%; margin:0 auto; height:25px; border:solid 1px Black;background-image:url('../../../MODULES/COMMON/Images/headerbg.png'); background-repeat:repeat-x; color:White">
    <a href="#" style="color:White; font-weight:bold" id="viewAllControl">तारिख स्थान हेर्नुहोस् </a>
  
    </div>
    
    <div id="viewAllDiv" style="display:none;width:100%; margin:0 auto; ">
    <hr />
  <asp:GridView ID="tarikhLocationGrid" SkinID="Unicodegrd" Width="100%" runat="server" AutoGenerateColumns="False" DataKeyNames="CourtID,PersonID,CaseID" OnRowDeleting="tarikhLocationGrid_RowDeleting">
  <Columns>
  <asp:BoundField DataField="Name" HeaderText="पूरा नामथर" >
      <HeaderStyle Width="200px" />
  </asp:BoundField>
  <asp:BoundField DataField="Court" HeaderText="अदालत"  >
      <HeaderStyle Width="200px" />
  </asp:BoundField>
  <asp:BoundField DataField="FromDate" HeaderText="जारी मिति" />
      
    
    <asp:TemplateField>
    <ItemTemplate>
        <asp:LinkButton runat="server" ID="deleteBtn" CommandName="Delete" OnClientClick='return confirm("Are you sure you want to delete this entry");'>Delete</asp:LinkButton>
    </ItemTemplate>
    </asp:TemplateField>
  </Columns>
        </asp:GridView>
  
   <hr /> 
    </div>
    
    <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server" 
        TargetControlID="pnlMain" >
    </ajaxToolkit:CollapsiblePanelExtender>
    <asp:Panel ID="pnlMain" runat="server">
    <table width="1000px">
        <tr>
            <td  >
                <asp:Label ID="Label4sa" runat="server" Height="22px" SkinID="Unicodelbl" Text="वादि"
                    Width="92px" Font-Bold="True"></asp:Label>&nbsp;
                <asp:Panel ID="pnlApp" runat="server" style="height:auto" ScrollBars="Auto" Width="1000px">
                <asp:GridView ID="grdLitigantsApp" runat="server" AutoGenerateColumns="False" OnRowDataBound="grdLitigantsApp_RowDataBound"
                    SkinID="Unicodegrd" Width="1000px" >
                    
                    <Columns>
                         <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left">
                            <HeaderTemplate>
                                <asp:CheckBox ID="chk" runat="server" OnCheckedChanged="chkHEADER_CheckedChanged"  />                            
                            </HeaderTemplate>                           
                            <ItemTemplate>
                                <asp:CheckBox ID="chk"  runat="server" OnCheckedChanged="chk_CheckedChanged"/>
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
                        <asp:BoundField DataField="IsPrisoned" Visible="false" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"/>  
                       <asp:TemplateField  ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left" >
                            <HeaderTemplate >
                            वारिश                             
                            </HeaderTemplate> 
                            <HeaderStyle HorizontalAlign="center" Width="350px" />                           
                            <ItemTemplate >                            
                                    <div id="divShow" onmouseover="mouseOver(this)" onmouseout="mouseOut(this)"  onclick="showHide(this)" style="color:Green;font-size:11px;" >Show Attorney</div>
                                <%--<asp:Panel id="pnlAttorney1" runat="server" Width="300px" ScrollBars="Auto">--%>
                                 <div style="max-width:300px;max-height:80px;overflow:scroll;display:none" id="divContent">   
                                    <asp:GridView ID="grdAttorney1" runat="server" AutoGenerateColumns="False" CellPadding="0" OnRowDataBound="grdAttorney_RowDataBound"
                                        ForeColor="#333333" SkinID="Unicodegrd" Width="300px" >
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333"  />
                                        
                                        <Columns>
                                            <asp:BoundField DataField="CaseID" HeaderText="CaseID" ></asp:BoundField>
                                            <asp:BoundField DataField="LitigantID" HeaderText="LitigantID" ></asp:BoundField>
                                            <asp:BoundField DataField="PersonID" HeaderText="Person ID" ></asp:BoundField>
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
                        
                    </Columns>
                </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
     
        <tr>
            <td style="height: 193px" >
                <asp:Label ID="Label5a" runat="server" Height="22px" SkinID="Unicodelbl" Text="प्रतिवादि"
                    Width="92px" Font-Bold="True"></asp:Label>
                <asp:Panel ID="pnlRes" runat="server" style="height:auto" ScrollBars="Auto" Width="1000px">
                <asp:GridView ID="grdLitigantRes" runat="server" AutoGenerateColumns="False" 
                    OnRowDataBound="grdLitigantsRes_RowDataBound" SkinID="Unicodegrd" Width="1000px">                   
                    <Columns>
                   
                        <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left">
                            <HeaderTemplate >
                                <asp:CheckBox ID="chkRes" runat="server"  OnCheckedChanged="chkHEADERRes_CheckedChanged" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkRes" runat="server"  OnCheckedChanged="chkRes_CheckedChanged" />
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
                        <asp:BoundField DataField="IsPrisoned" Visible="false" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateField  ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left">
                            <HeaderTemplate >
                            वारिश                             
                            </HeaderTemplate> 
                            <HeaderStyle HorizontalAlign="center" Width="350px" />                           
                            <ItemTemplate >                            
                                    <div id="divShow" onmouseover="mouseOver(this)" onmouseout="mouseOut(this)"    onclick="showHide(this)" style="color:Green; font-size:11px;" >Show Attorney</div>
                                    
                               <%-- <asp:Panel id="pnlAttorney"  runat="server" Width="300px" ScrollBars="Auto">--%>
                                <div style="max-width:100%;max-height:60px;overflow:scroll;display:none" id="divAttorney">
                                    <asp:GridView ID="grdAttorney" runat="server" AutoGenerateColumns="False" CellPadding="0" OnRowDataBound="grdAttorney_RowDataBound"
                                        ForeColor="#333333" SkinID="Unicodegrd" Width="300px" >
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333"  />
                                        
                                        <Columns>
                                            <asp:BoundField DataField="CaseID" HeaderText="CaseID" ></asp:BoundField>
                                            <asp:BoundField DataField="LitigantID" HeaderText="LitigantID" ></asp:BoundField>
                                            <asp:BoundField DataField="PersonID" HeaderText="Person ID" ></asp:BoundField>
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
                      
                        
                    </Columns>
                </asp:GridView>
                </asp:Panel>
                
            </td>
        </tr>
      
    </table>
    
     </asp:Panel>
     
    
</div>
  <asp:Panel ID="panel1" runat="server">
<table>
     <tr>
                          <td> <asp:Label ID="courtLbl" SkinID="Unicodelbl"  runat="server">Select Court:</asp:Label></td>
                          <td><asp:DropDownList ID="ddlCourt"  runat="server" 
                                    SkinID="Unicodeddl" >
                                </asp:DropDownList></td>
              
         
                                   
                            <td><asp:Label ID="Label1" SkinID="Unicodelbl"  runat="server" Text="From Date:"></asp:Label></td>
                            <td><asp:TextBox ID="fromDateTxt" runat="server"></asp:TextBox></td>
                                       <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AutoComplete="False"
                    Mask="9999/99/99" MaskType="Date" TargetControlID="fromDateTxt">
                </ajaxToolkit:MaskedEditExtender>
                </tr>
                <tr>
                <td>&nbsp;</td>
              <td>&nbsp;</td>
                </tr>
                          
                                                   
                           <tr>
                                        <td><asp:Button ID="Button1" runat="server" OnClick="btnSave_Click" SkinID="Normal" Text="Save" /></td>
                              
                                        <td><asp:Button ID="Button2" runat="server" OnClick="btnCancel_Click" OnClientClick="return confirm('Are you sure you want to cancel ?');"
                                            SkinID="Cancel" Text="Cancel" />
                                            </td>
                                            </tr>
                             </table>
                              </asp:Panel>
</asp:Content>

