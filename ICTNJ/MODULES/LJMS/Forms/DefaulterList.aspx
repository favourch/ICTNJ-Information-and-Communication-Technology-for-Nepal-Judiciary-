<%@ Page AutoEventWireup="true" EnableEventValidation = "false"  CodeFile="DefaulterList.aspx.cs" Inherits="MODULES_LJMS_Forms_DefaulterList" Language="C#" MasterPageFile="~/MODULES/LJMS/LJMSMasterPage.master"
    Title="NBA | Defaulter List" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager id="scrptManagerDefaulterList" runat="server">
    </asp:ScriptManager>
    
    <script language="javascript" type="text/javascript">
    function DisplayFields(txt)
    {
        if (txt=="optNBA")
        {
        
            document.getElementById("ctl00_ContentPlaceHolder1_lblType").style.visibility="visible";
            document.getElementById("ctl00_ContentPlaceHolder1_lblUnit").style.visibility="visible";
            document.getElementById("ctl00_ContentPlaceHolder1_ddlType").style.visibility="visible";
            document.getElementById("ctl00_ContentPlaceHolder1_ddlUnit").style.visibility="visible";
            
            //document.getElementById("ctl00_ContentPlaceHolder1_ddlType").selectedIndex=0;
            //document.getElementById("ctl00_ContentPlaceHolder1_ddlUnit").selectedIndex=0;   
        }
        else if(txt=="optNBC")
        {
            document.getElementById("ctl00_ContentPlaceHolder1_lblType").style.visibility="visible";
            document.getElementById("ctl00_ContentPlaceHolder1_lblUnit").style.visibility="hidden";
            document.getElementById("ctl00_ContentPlaceHolder1_ddlType").style.visibility="visible";
            document.getElementById("ctl00_ContentPlaceHolder1_ddlUnit").style.visibility="hidden";
            
            //document.getElementById("ctl00_ContentPlaceHolder1_ddlType").selectedIndex=0;
            //document.getElementById("ctl00_ContentPlaceHolder1_ddlUnit").selectedIndex=0;      
        }
    }
    
    function compareFromToDates()
    {
        var flag = true;
        var ErrorMsg = "";
        var ErrorControl=new Array();
        var objFromDate = document.getElementById('<%=this.txtDate.ClientID%>'); 
        var objToDate = document.getElementById('<%=this.txtToDate.ClientID%>'); 
        
        if(objFromDate.value != "")
        {   
            if(objToDate.value == "")
            {   
                ErrorMsg=ErrorMsg + "' " + objToDate.title+ " ' खालि छ। ";
                ErrorControl.push(objToDate);
            }
            else
            {            
               
                if(chkDate(objFromDate) == false)
                    return false;
                    
                if(chkDate(objToDate) == false)
                    return false;
                    

                if(flag == true)
                {
                    var DateElement1 = objFromDate.value.split("/");
                    var DateElement2 = objToDate.value.split("/");

                    if(DateElement1[0] > DateElement2[0])
                    {
                        ErrorMsg=ErrorMsg + "' " + objToDate.title +" ' को वर्ष ";
                        ErrorMsg=ErrorMsg + "' " + objFromDate.title+" ' को भन्दा  बढी हुनुपर्छ।\n";
                        ErrorControl.push(objToDate);
                       // break;
                    }
                    else if(DateElement1[0] == DateElement2[0])
                    {  
                         if(DateElement1[1] > DateElement2[1])
                         {
                            ErrorMsg=ErrorMsg + "' " + objToDate.title +" ' को महिना  ";
                            ErrorMsg=ErrorMsg + "' " + objFromDate.title+" ' को भन्दा  बढी हुनुपर्छ।\n";
                            ErrorControl.push(objToDate);
                         
                         }
                         else if(DateElement1[1] == DateElement2[1])
                         {
                             if(DateElement1[2] > DateElement2[2])
                             {
                                ErrorMsg=ErrorMsg + "' " + objToDate.title +" ' को दिन ";
                                ErrorMsg=ErrorMsg + "' " + objFromDate.title+" ' को भन्दा  बढी हुनुपर्छ।\n";
                                ErrorControl.push(objToDate);
                             
                             }
                            
                         }
                    }
                    
                }
                else
                    return false;
           }
          
                    
           
        }
        else
        { 
            
            ErrorMsg=ErrorMsg + "' " + objFromDate.title+ " ' खालि छ। ";
            ErrorControl.push(objFromDate);
           
            //return true;
        }
        
        
       if(ErrorMsg != "")
       {
            alert("निम्न मितिको त्रुटिहरू सच्याउनुहोस::\n\n"+ErrorMsg);
            ErrorControl[0].focus();
            ErrorControl[0].select();
            return false;
       }
       else
       {        
            return true;
       }
       
        
    }
    
    function chkDate(objDate)
    {  
       var DateElement = objDate.value.split("/");
       var Day;
       var Month;
       var Year;
       var ErrorMsg="";
       var ErrorControl=new Array();
       
       if(DateElement.length==3)
       {
            Day=DateElement[2];
            Month=DateElement[1];
            Year=DateElement[0];
            if((Year.length!=4) || (Month.length!=2) || (Day.length!=2)  || (Month<1 || Month>12) || (Day<1 || Day>32) || (isNaN(Year)==true) || (isNaN(Month)==true) || (isNaN(Day)==true))
            {
                ErrorMsg=ErrorMsg + objDate.title+":  -  गलत मिति. मितिको प्रकार YYYY/MM/DD मा राख्नुहोस।\n";
                ErrorControl.push(objDate);
                
            }
        }
        else
        {
            ErrorMsg=ErrorMsg + objDate.title+":  -  मितिको प्रकार YYYY/MM/DD मा राख्नुहोस।\n";
            ErrorControl.push(objDate);
        }
        
        if(ErrorMsg!="")
        {
            alert("निम्न मितिको त्रुटिहरू सच्याउनुहोस::\n\n"+ErrorMsg);
            ErrorControl[0].focus();
            ErrorControl[0].select();
            return false;
        }
        else
        {
            return true;
        }
    }
    
    </script>

    <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior"
        DropShadow="True" PopupControlID="programmaticPopup" PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
        TargetControlID="hiddenTargetControlForModalPopup">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none; width: 350px; padding: 10px">
        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD; border: solid 1px Gray; color: Black; text-align: center;">
            Status
        </asp:Panel>
        <asp:UpdatePanel ID="UpdatePanel301" runat="server">
            <contenttemplate>
<asp:Label id="lblStatusMessage" runat="server" Text="Label" Font-Size="Small" Font-Names="Verdana" ForeColor="Red" EnableTheming="False"></asp:Label> 
</contenttemplate>
        </asp:UpdatePanel>
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click" Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<ajaxToolkit:MaskedEditExtender id="MaskedEditExtender1" runat="server" TargetControlID="txtDate" AutoComplete="False" Mask="9999/99/99" MaskType="Date" __designer:wfdid="w92"></ajaxToolkit:MaskedEditExtender> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender2" runat="server" TargetControlID="txtToDate" AutoComplete="False" Mask="9999/99/99" MaskType="Date" __designer:wfdid="w4"></ajaxToolkit:MaskedEditExtender><BR /> <TABLE width=800><TBODY><TR><TD colSpan=5><asp:Label id="Label1" runat="server" Text="Defaulter List According To" SkinID="UnicodeHeadlbl" __designer:wfdid="w93"></asp:Label><BR /></TD></TR><TR><TD style="WIDTH: 230px"><asp:RadioButton id="optNBA" onclick="DisplayFields('optNBA')" runat="server" Text="नेपाल बार एशोसिएशन" SkinID="LJMSRdo" __designer:wfdid="w82" Checked="True" GroupName="grp1"></asp:RadioButton></TD><TD style="WIDTH: 100px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label id="lblType" runat="server" Text="प्रकार" SkinID="LJMSlbl" __designer:wfdid="w83"></asp:Label></TD><TD style="WIDTH: 201px"><asp:DropDownList id="ddlType" runat="server" Width="180px" SkinID="Ljmsddl" __designer:wfdid="w84"></asp:DropDownList></TD><TD style="WIDTH: 70px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label id="lblUnit" runat="server" Text="एकाई" SkinID="LJMSlbl" __designer:wfdid="w85"></asp:Label></TD><TD style="WIDTH: 200px"><asp:DropDownList id="ddlUnit" runat="server" Width="180px" SkinID="Ljmsddl" __designer:wfdid="w86"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 230px"><asp:RadioButton id="optNBC" onclick="DisplayFields('optNBC')" runat="server" Text="नेपाल बार काउन्सिल" SkinID="LJMSRdo" __designer:wfdid="w87" GroupName="grp1"></asp:RadioButton></TD><TD style="WIDTH: 100px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label id="Label2" runat="server" Text="शुरु मिति" SkinID="LJMSlbl" __designer:wfdid="w88"></asp:Label></TD><TD style="WIDTH: 201px"><asp:TextBox id="txtDate" runat="server" Width="176px" SkinID="Unicodetxt" __designer:wfdid="w89" ToolTip="शुरू मिति"></asp:TextBox></TD><TD style="WIDTH: 70px"><asp:Label id="lblToDate" runat="server" Text="सम्म मिति" SkinID="LJMSlbl" __designer:wfdid="w2"></asp:Label></TD><TD style="WIDTH: 200px"><asp:TextBox id="txtToDate" runat="server" Width="176px" SkinID="Unicodetxt" __designer:wfdid="w1" ToolTip="अन्तिम मिति"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 230px; HEIGHT: 15px"></TD><TD style="WIDTH: 100px; HEIGHT: 15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label id="lblInRange" runat="server" Text="In Range" SkinID="LJMSlbl" __designer:wfdid="w2"></asp:Label></TD><TD style="WIDTH: 201px; HEIGHT: 15px"><asp:CheckBox id="chkInRange" runat="server" __designer:wfdid="w1"></asp:CheckBox></TD><TD style="WIDTH: 70px; HEIGHT: 15px"></TD><TD style="WIDTH: 200px; HEIGHT: 15px"></TD></TR><TR><TD style="WIDTH: 230px; HEIGHT: 15px"></TD><TD style="WIDTH: 100px; HEIGHT: 15px"></TD><TD style="WIDTH: 201px; HEIGHT: 15px"></TD><TD style="WIDTH: 70px; HEIGHT: 15px"></TD><TD style="WIDTH: 200px; HEIGHT: 15px"><asp:Button id="btnDisplay" onclick="btnDisplay_Click" runat="server" Text="Display" SkinID="Normal" __designer:wfdid="w90" OnClientClick="return compareFromToDates();"></asp:Button> <asp:Button id="btnCancel" onclick="btnCancel_Click" runat="server" Text="Cancel" SkinID="Normal" __designer:wfdid="w91"></asp:Button></TD></TR></TBODY></TABLE>
</contenttemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <contenttemplate>
&nbsp;&nbsp; <asp:Button id="btnExport" onclick="btnExport_Click" runat="server" Text="Export" SkinID="Normal" Visible="False"></asp:Button><BR />&nbsp;&nbsp; <asp:Label id="lblSearchStatus" runat="server" SkinID="LJMSlbl"></asp:Label> <DIV style="PADDING-LEFT: 10px; OVERFLOW: auto; WIDTH: 100%; HEIGHT: 310px" border="0"><asp:GridView id="grdDisplay" runat="server" Width="97%" SkinID="LJMSgrd" ForeColor="#333333" OnRowDeleting="grdDisplay_RowDeleting" OnRowDataBound="grdDisplay_RowDataBound" OnRowCreated="grdDisplay_RowCreated" HorizontalAlign="Left" CellPadding="0" AutoGenerateColumns="False" BorderWidth="1px" BorderStyle="Solid">
<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="सि.नं."><ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>.
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="PERSONID" HeaderText="PID"></asp:BoundField>
<asp:BoundField DataField="RDFullName" HeaderText="पुरा नाम">
<HeaderStyle Wrap="False"></HeaderStyle>

<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="LTYPE" HeaderText="वकिलको प्रकार">
<HeaderStyle Wrap="False"></HeaderStyle>

<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="LICENSENO" HeaderText="लाइसन नं.">
<HeaderStyle Wrap="False"></HeaderStyle>

<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DISPLAYDATE" HeaderText="नविकरण रहने मिति">
<HeaderStyle Wrap="False"></HeaderStyle>

<ItemStyle Wrap="False" Font-Names="Verdana"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="UNITNAME" HeaderText="युनिट">
<HeaderStyle Wrap="False"></HeaderStyle>

<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="PLRENEWALUPTO" HeaderText="निजी वकिल नविकरण मिति">
<HeaderStyle Wrap="False"></HeaderStyle>

<ItemStyle Wrap="False" Font-Names="Verdana"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ACTIVE"></asp:BoundField>
<asp:CommandField ShowDeleteButton="True"></asp:CommandField>
<asp:BoundField DataField="LTYPEID" HeaderText="LTypeID"></asp:BoundField>
<asp:BoundField DataField="LICENSENO" HeaderText="LicenceNo"></asp:BoundField>
</Columns>

<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

<SelectedRowStyle HorizontalAlign="Left" VerticalAlign="Middle" BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> <%--</asp:Panel>--%></DIV>&nbsp; 
</contenttemplate>
        <triggers>
<asp:PostBackTrigger ControlID="btnExport"></asp:PostBackTrigger>
</triggers>
    </asp:UpdatePanel>
</asp:Content>
