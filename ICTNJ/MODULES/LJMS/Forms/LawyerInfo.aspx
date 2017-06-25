<%@ Page AutoEventWireup="true" CodeFile="LawyerInfo.aspx.cs" Inherits="MODULES_PMS_Forms_Employee"
    Language="C#" MasterPageFile="~/MODULES/LJMS/LJMSMasterPage.master" Theme="Default"
    Title="NBA | Lawyer Information" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script language="javascript" src="../../COMMON/JS/Validation.js" type="text/javascript"></script>
    <script language="javascript" src="../../COMMON/JS/DateValidator.js" type="text/javascript"></script>
    <script language="javascript" src="../../COMMON/JS/EnglishDateValidator.js" type="text/javascript"></script>
    <script language="javascript" src="../../COMMON/JS/Number.js" type="text/javascript"></script>
   <script language="javascript" src="../../COMMON/JS/UPanelValidation.js" type="text/javascript"></script>
    <script language="javascript" src="../../COMMON/JS/EmailValidator.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">

    function ValidateEmailFR()
    {
        var ErrMsg = "";
        ErrMsg= ValidateEmail('<%=this.txtEMail_EMail.ClientID %>');
        if (ErrMsg != "")
           {
               alert("सर्वप्रथम निम्न त्रुटिहरू सच्याउनुहोस।\n\n" + ErrMsg);
                return false;
           }
         else
           return validateUpanelFields('_EMail','');
    }
    
    function UnCheckOthersBeneficiary(BenCheckBox,RelativeCheckBox)
    {
        var doc = document.forms[0]        
        var objCheck = doc.getElementsByTagName("INPUT");
        for (var j = 0; j < objCheck.length; j++)
        {
        
            if(objCheck[j].getAttribute("type")=="checkbox")
            if (document.getElementById(RelativeCheckBox).checked)
                {
                    if (objCheck[j].getAttribute("id").search(/_chkIsBeneficiary/i) != -1)            
                    if (objCheck[j].getAttribute("id")!=BenCheckBox)	        
                        objCheck(j).checked=false;
                 }
              else
              {
                  alert('कृपया पहिले यो नातेदारलाई सक्रिय राख्नुहोस');
                  return false;
              }
        }
    } 
    
    function UnCheckBeneficiary(BenCheckBox,RelativeCheckBox)
    {
            if (document.getElementById(RelativeCheckBox).checked==false)
                document.getElementById(BenCheckBox).checked=false;
    
    }            
               
    
    
    function wopen(url, name, w, h)
    {
     //This works well on all platforms & browsers.
    w += 32;
    h += 96;
    var win = window.open(url,name,'width=' + w + ',height=' + h + ',' + 'location=no, menubar=no,' + 'status=no, toolbar=no, scrollbars=no, resizable=no');
    win.resizeTo(w, h);
    win.focus();
    }
    
    function ShowConfirmation()
   {
     if(confirm("Are you want to show the value?")== true)
    {

     //Calling the server side code after confirmation from the user
      document.getElementById("btnAlelrt").click();

      }
    }
    
    function ValidateLawyerWithSingleDate(validationfields,callDateValidator,val1)
    {
        if(validateUpanelFields(validationfields,callDateValidator))
        {
            if(val1 == "1")
            {
                if(chkDate(document.getElementById('<%=this.txtFromDate_nba.ClientID%>')))
                    return true;
                else
                    return false;
            }
            else if(val1 == "2")
            {
                if(chkDate(document.getElementById('<%=this.txtPrivateFromDate_pl.ClientID%>')))
                    return true;
                else
                    return false;
            }
            
            
            else
                return false;
        }
        else
            return false;
    }
    
    function ValidateLawyer(validationfields,callDateValidator,val1,val2)
    {
      
        if(validateUpanelFields(validationfields,callDateValidator))
        {
            if(val1 == "1")
            {
                if(compareDates('<%=this.txtRenewalDate_ren.ClientID %>','<%=this.txtRenewalUpto_ren.ClientID %>',val1))
                    return true;
                else 
                    return false;
            }
            else if(val1 == "2")
            {
                if(compareDates('<%=this.txtPrivateRenFrom_lpr.ClientID %>','<%=this.txtPrivateRenUpto_lpr.ClientID %>',val1))
                    return true;
                else 
                    return false;
            }
          /*  else if(val1 == "3")
            {
                if(compareDates('<%=this.txtPrivateFromDate_pl.ClientID %>','',val1))
                    return true;
                else 
                    return false;
            }*/
            
            //txtPrivateFromDate_pl
            else
                return false;
        }
        else
 
            return false;
    }
        
    function compareDates(val1,val2,val)
    { 
       var flag = true ; 
       var ErrorMsg = "";
       var DateArray =new Array();
       var ErrorControl=new Array();
       var objDate0;
       
       
       
       if(val == "1" || val == "3")
       {  
           objDate0 = document.getElementById('<%=this.hdnLDate.ClientID%>'); 
       }
       else if(val == "2")
          objDate0 = document.getElementById('<%=this.hdnPlDate.ClientID%>'); 

                
       
       var  objDate1 = document.getElementById(val1);
       

       DateArray[0] = objDate0;
       DateArray[1] =objDate1;
       
       if(val == "1" || val == "2")
       {    var  objDate2 = document.getElementById(val2);
            DateArray[2] = objDate2;
       }
       
        for(var k = 0; k < DateArray.length; k++)
        {
            if(chkDate(DateArray[k]) == false)
            { 
                flag = false;
                break;
            }
           
        }
        
        if(flag == true)
        {
            
            
            for(var i = 0; i < DateArray.length -1; i++)
            {
                var DateElement1 = DateArray[i].value.split("/");
                var DateElement2 = DateArray[i+1].value.split("/");
                
                if(i== 0)
                {  
                    if(DateElement1[0] > DateElement2[0])
                    {
                        if( val == "2")
                            ErrorMsg=ErrorMsg + "' " + DateArray[i+1].title+" 'को  वर्ष 'युनिट शुरु मिति'को भन्दा  बढी हुनुपर्छ।\n";
                        else
                            ErrorMsg=ErrorMsg + "' " + DateArray[i+1].title+" 'को  वर्ष 'शुरु मिति'को भन्दा  बढी हुनुपर्छ।\n";
                        
                        ErrorControl.push(DateArray[i+1]);
                        break;
                    }
                    else if(DateElement1[0] == DateElement2[0])
                    {  
                         if(DateElement1[1] > DateElement2[1])
                         {
                            if( val == "2")
                                ErrorMsg=ErrorMsg + "' " + DateArray[i+1].title+" 'को  वर्ष 'युनिट शुरु मिति'को भन्दा  बढी हुनुपर्छ।\n";
                            else
                                ErrorMsg=ErrorMsg + "' " + DateArray[i+1].title +" ' को   महिना 'शुरु मिति'को भन्दा बढी हुनुपर्छ।\n";
                            
                            ErrorControl.push(DateArray[i+1]);
                            break;
                         
                         }
                         else if(DateElement1[1] == DateElement2[1])
                         {
                             if(DateElement1[2] > DateElement2[2])
                             {
                                if( val == "2")
                                    ErrorMsg=ErrorMsg + "' " + DateArray[i+1].title+" 'को  वर्ष 'युनिट शुरु मिति'को भन्दा  बढी हुनुपर्छ।\n";
                                else
                                    ErrorMsg=ErrorMsg + "' " +  DateArray[i+1].title +"' को  दिन 'शुरु मिति'को भन्दा  बढी हुनुपर्छ।\n";
                                
                                ErrorControl.push(DateArray[i+1]);
                                break;
                             
                             }
                            
                         }
                    }
                }
                else
                {
                    if(DateElement1[0] > DateElement2[0])
                    {
                        ErrorMsg=ErrorMsg + "' " + DateArray[i+1].title +" ' को वर्ष ";
                        ErrorMsg=ErrorMsg + "' " + DateArray[i].title+" ' को भन्दा  बढी हुनुपर्छ।\n";
                        ErrorControl.push(DateArray[i+1]);
                        break;
                    }
                    else if(DateElement1[0] == DateElement2[0])
                    {  
                         if(DateElement1[1] > DateElement2[1])
                         {
                            ErrorMsg=ErrorMsg + "' " + DateArray[i+1].title +" ' को महिना";
                            ErrorMsg=ErrorMsg + "' " + DateArray[i].title+"' को भन्दा  बढी हुनुपर्छ।\n";
                            ErrorControl.push(DateArray[i+1]);
                            break;
                         
                         }
                         else if(DateElement1[1] == DateElement2[1])
                         {
                             if(DateElement1[2] > DateElement2[2])
                             {
                                ErrorMsg=ErrorMsg + "' " +  DateArray[i+1].title +" ' को दिन ";
                                ErrorMsg=ErrorMsg + "' " + DateArray[i].title+" ' को भन्दा  बढी हुनुपर्छ।\n";
                                ErrorControl.push(DateArray[i+1]);
                                break;
                             
                             }
                            
                         }
                    }
                }
                
                
                
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
        else
            return false;
           
           
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

    <asp:ScriptManager id="ScriptManager1" runat="server">
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
            Status
        </asp:Panel>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
<asp:Label id="lblStatusMessage" runat="server" Text="Label" Font-Size="Small" Font-Names="Verdana" EnableTheming="False" ForeColor="Black"></asp:Label> 
</ContentTemplate>
        </asp:UpdatePanel>
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
            Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    <table width="500">
        <tr>
            <td style="width: 100px">
                <asp:Image ID="imgEmp" runat="server" AlternateText="Loading ..." Height="105px" ImageUrl="~/MODULES/COMMON/Images/blank.PNG" Width="100px" /></td>
            <td style="width: 400px" valign="bottom">
                <asp:FileUpload ID="fupImage" runat="server" Width="315px" />
                <asp:Button ID="btnUpLoadImage" runat="server" OnClick="btnUpLoadImage_Click" SkinID="Normal" Text="Upload" /></td>
        </tr>
    </table>
    <table cellspacing="2" style="width: 1000px" class="2">
        <tr>
            <td colspan="6" valign="top">
                <asp:Label ID="lblPersonnelInfo" runat="server" Font-Bold="True" SkinID="UnicodeHeadlbl"
                    Text="व्यक्तिगत विवरण"></asp:Label>&nbsp;
            </td>
        </tr>
        <tr>
            <td valign="top" style="width: 105px">
                <asp:Label ID="Label1" runat="server" Height="22px" SkinID="Unicodelbl" Text="पहिलो नाम" Width="81px"></asp:Label></td>
            <td valign="top">
                <asp:TextBox ID="txtFName_Rqd" runat="server" MaxLength="35" SkinID="LJMStxt"
                    ToolTip="पहिलो नाम" Width="130px"></asp:TextBox></td>
            <td valign="top">
                <asp:Label ID="Label2" runat="server" Height="22px" SkinID="Unicodelbl" Text="बिचको नाम"></asp:Label></td>
            <td valign="top">
                <asp:TextBox ID="txtMName" runat="server" MaxLength="15" SkinID="LJMStxt" Width="130px"></asp:TextBox></td>
            <td valign="top">
                <asp:Label ID="Label3" runat="server" Height="22px" SkinID="Unicodelbl" Text="थर"
                    Width="110px"></asp:Label></td>
            <td valign="top">
                <asp:TextBox ID="txtSurName_Rqd" runat="server" MaxLength="35" SkinID="LJMStxt"
                    ToolTip="थर" Width="130px"></asp:TextBox></td>
        </tr>
        <tr>
            <td valign="top" style="width: 105px">
                <asp:Label ID="Label4" runat="server" Height="22px" SkinID="Unicodelbl" Text="जन्म मिति" Width="90px"></asp:Label></td>
            <td valign="top">
                <asp:TextBox ID="txtDOB_DT" runat="server" MaxLength="10" SkinID="Unicodetxt" ToolTip="जन्म मिति"
                    Width="130px"></asp:TextBox>&nbsp;
                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AutoComplete="False"
                    Mask="9999/99/99" MaskType="Date" TargetControlID="txtDOB_DT">
                </ajaxToolkit:MaskedEditExtender>
            </td>
            <td valign="top">
                <asp:Label ID="Label5" runat="server" Height="22px" SkinID="Unicodelbl" Text="लिंग"></asp:Label></td>
            <td valign="top">
                <asp:DropDownList ID="ddlGender" runat="server" SkinID="Ljmsddl" Width="135px">
                    <asp:ListItem Value="SG">छान्नुहोस</asp:ListItem>
                    <asp:ListItem Value="M">पुरुष</asp:ListItem>
                    <asp:ListItem Value="F">महिला</asp:ListItem>
                    <asp:ListItem Value="O">अन्य</asp:ListItem>
                </asp:DropDownList></td>
            <td valign="top">
                <asp:Label ID="Label6" runat="server" Height="22px" SkinID="Unicodelbl" Text="बैबाहिक सम्बन्ध"
                    Width="115px"></asp:Label></td>
            <td valign="top">
                <asp:DropDownList ID="ddlMarStatus" runat="server" SkinID="Ljmsddl" Width="135px">
                    <asp:ListItem Value="SMS">छान्नुहोस</asp:ListItem>
                    <asp:ListItem Value="S">अबिबाहित</asp:ListItem>
                    <asp:ListItem Value="M">बिबाहित</asp:ListItem>
                    <asp:ListItem Value="W">बिधवा/बिदुर</asp:ListItem>
                    <asp:ListItem Value="D">छोडपत्र</asp:ListItem>
                    <asp:ListItem Value="O">अन्य</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td valign="top" style="width: 105px">
                <asp:Label ID="Label7" runat="server" Height="22px" SkinID="Unicodelbl" Text="देश"></asp:Label></td>
            <td valign="top">
                <asp:DropDownList ID="ddlCountry" runat="server" SkinID="Ljmsddl" Width="135px">
                </asp:DropDownList></td>
            <td valign="top">
                <asp:Label ID="Label8" runat="server" Height="22px" SkinID="Unicodelbl" Text="घर भएको जिल्ला" Width="125px"></asp:Label></td>
            <td valign="top">
                <asp:DropDownList ID="ddlBirthDistrict" runat="server" SkinID="Ljmsddl" Width="135px">
                </asp:DropDownList></td>
            <td valign="top">
                <asp:Label ID="Label9" runat="server" Height="22px" SkinID="Unicodelbl" Text="धर्म"
                    Width="110px"></asp:Label></td>
            <td valign="top">
                <asp:DropDownList ID="ddlReligion" runat="server" SkinID="Ljmsddl" Width="135px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td valign="top" style="width: 105px">
                <asp:Label ID="Label29" runat="server" SkinID="Unicodelbl" Text="हुलिया" Width="77px"></asp:Label></td>
            <td valign="top">
                <asp:TextBox ID="txtIdentityMark" runat="server" MaxLength="30" SkinID="LJMStxt"
                    Width="130px"></asp:TextBox></td>
            <td valign="top">
                &nbsp;</td>
            <td valign="top">
                </td>
            <td valign="top">
                </td>
            <td valign="top">
                </td>
        </tr>
        <tr>
            <td colspan="6" valign="top" >
                <hr />
                <table style="width: 950px">
                    <tr>
                        <td style="width: 477px">
                            <ajaxToolkit:TabContainer ID="tabContainerEmpContact" runat="server" ActiveTabIndex="0"
                                CssClass="ajax_tab_theme" Width="950px">
                                <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                                    <ContentTemplate>
                                    <asp:UpdatePanel id="UpdatePanel15" runat="server">
                                            <contenttemplate>
<TABLE style="WIDTH: 650px"><TBODY><TR><TD vAlign=top colSpan=6><asp:Label id="Label26" runat="server" Text="स्थायी ठेगाना" SkinID="Unicodelbl" Font-Bold="True" __designer:wfdid="w166"></asp:Label> </TD></TR><TR><TD style="WIDTH: 60px" vAlign=top><asp:Label id="Label82" runat="server" Width="50px" Height="19px" Text="जिल्ला" SkinID="Unicodelbl" __designer:wfdid="w167"></asp:Label> </TD><TD style="WIDTH: 170px" vAlign=top><asp:DropDownList id="ddlDistrict" runat="server" Width="150px" SkinID="Ljmsddl" __designer:wfdid="w168" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> </TD><TD style="WIDTH: 105px" vAlign=top><asp:Label id="Label84" runat="server" Width="95px" Height="19px" Text="गा.बि.स./न.पा." SkinID="Unicodelbl" __designer:wfdid="w169"></asp:Label> </TD><TD style="WIDTH: 170px" vAlign=top><asp:DropDownList id="ddlVDC" runat="server" Width="150px" SkinID="Ljmsddl" __designer:wfdid="w170" OnSelectedIndexChanged="ddlVDC_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> </TD><TD style="WIDTH: 60px" vAlign=top><asp:Label id="Label15" runat="server" Width="50px" Height="19px" Text="वडा नं." SkinID="Unicodelbl" __designer:wfdid="w171"></asp:Label> </TD><TD vAlign=top><asp:DropDownList id="ddlWard" runat="server" Width="70px" SkinID="Ljmsddl" __designer:wfdid="w172" AppendDataBoundItems="True"></asp:DropDownList> </TD></TR><TR><TD style="WIDTH: 60px" vAlign=top><asp:Label id="Label83" runat="server" Height="19px" Text="टोल" SkinID="Unicodelbl" __designer:wfdid="w173"></asp:Label> </TD><TD style="WIDTH: 170px" vAlign=top><asp:TextBox id="txtTole" runat="server" Width="146px" SkinID="LJMStxt" MaxLength="100" __designer:wfdid="w174" TextMode="MultiLine"></asp:TextBox></TD><TD style="WIDTH: 105px" vAlign=top><asp:ImageButton id="imgDelPerAddress" onclick="imgDelPerAddress_Click" runat="server" ImageUrl="~/MODULES/COMMON/Images/bycat1.ico" AlternateText="Delete This Address" OnClientClick="return confirm('यो ठेगाना हटाउने हो ?')" __designer:wfdid="w175" Visible="False"></asp:ImageButton></TD><TD style="WIDTH: 170px" vAlign=top></TD><TD style="WIDTH: 60px" vAlign=top></TD><TD vAlign=top></TD></TR><TR><TD vAlign=top colSpan=6>
<HR />
</TD></TR></TBODY></TABLE><asp:HiddenField id="hdnPerAddress" runat="server" __designer:wfdid="w176"></asp:HiddenField> <asp:HiddenField id="hdnTempAddress" runat="server" __designer:wfdid="w177"></asp:HiddenField> <TABLE style="WIDTH: 650px"><TBODY><TR><TD vAlign=top colSpan=6><asp:Label id="Label85" runat="server" Text="अस्थायी ठेगाना" SkinID="Unicodelbl" Font-Bold="True" __designer:wfdid="w178"></asp:Label></TD></TR><TR><TD style="WIDTH: 60px" vAlign=top><asp:Label id="Label86" runat="server" Width="50px" Height="19px" Text="जिल्ला" SkinID="Unicodelbl" __designer:wfdid="w179"></asp:Label></TD><TD style="WIDTH: 170px" vAlign=top><asp:DropDownList id="ddlDistrictTemp" runat="server" Width="150px" SkinID="Ljmsddl" __designer:wfdid="w180" OnSelectedIndexChanged="ddlDistrictTemp_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD><TD style="WIDTH: 105px" vAlign=top><asp:Label id="Label87" runat="server" Width="95px" Height="19px" Text="गा.बि.स./न.पा." SkinID="Unicodelbl" __designer:wfdid="w181"></asp:Label></TD><TD style="WIDTH: 170px" vAlign=top><asp:DropDownList id="ddlVDCTemp" runat="server" Width="150px" SkinID="Ljmsddl" __designer:wfdid="w182" OnSelectedIndexChanged="ddlVDCTemp_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD><TD style="WIDTH: 60px" vAlign=top><asp:Label id="Label88" runat="server" Width="50px" Height="19px" Text="वडा नं." SkinID="Unicodelbl" __designer:wfdid="w183"></asp:Label></TD><TD vAlign=top><asp:DropDownList id="ddlWardTemp" runat="server" Width="70px" SkinID="Ljmsddl" __designer:wfdid="w184" AppendDataBoundItems="True"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 60px" vAlign=top><asp:Label id="Label89" runat="server" Height="19px" Text="टोल" SkinID="Unicodelbl" __designer:wfdid="w185"></asp:Label></TD><TD style="WIDTH: 170px" vAlign=top><asp:TextBox id="txtToleTemp" runat="server" Width="146px" SkinID="LJMStxt" MaxLength="100" __designer:wfdid="w186" TextMode="MultiLine"></asp:TextBox></TD><TD style="WIDTH: 105px" vAlign=top><asp:ImageButton id="imgDelTempAddress" onclick="imgDelTempAddress_Click" runat="server" ImageUrl="~/MODULES/COMMON/Images/bycat1.ico" AlternateText="Delete This Address" OnClientClick="return confirm('यो ठेगाना हटाउने हो ?')" __designer:wfdid="w187" Visible="False"></asp:ImageButton></TD><TD style="WIDTH: 170px" vAlign=top></TD><TD style="WIDTH: 60px" vAlign=top></TD><TD vAlign=top></TD></TR><TR><TD vAlign=top colSpan=6>
<HR />
</TD></TR></TBODY></TABLE>
</contenttemplate>
                                        </asp:UpdatePanel>
                                        <asp:UpdatePanel id="UpdatePanel10" runat="server">
                                            <contenttemplate>
<TABLE style="WIDTH: 650px"><TBODY><TR><TD vAlign=top colSpan=4><asp:Label id="Label13" runat="server" Width="105px" Height="19px" Text="फोन" SkinID="LJMSlbl" Font-Bold="True" __designer:wfdid="w189"></asp:Label><ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender1" runat="server" TargetControlID="txtPhoneNumber_Phone" __designer:wfdid="w190" FilterType="Numbers"></ajaxToolkit:FilteredTextBoxExtender></TD></TR><TR><TD style="WIDTH: 110px" vAlign=top><asp:Label id="Label18" runat="server" Width="105px" Height="19px" Text="फोनको किसिम" SkinID="LJMSlbl" __designer:wfdid="w191"></asp:Label> </TD><TD style="WIDTH: 135px" vAlign=top><asp:DropDownList id="ddlPhoneType_Phone" runat="server" Width="135px" SkinID="Ljmsddl" ToolTip="फोनको किसिम" __designer:wfdid="w192"><asp:ListItem Value="N">छान्नुहोस</asp:ListItem>
<asp:ListItem Value="M">मोबाईल</asp:ListItem>
<asp:ListItem Value="O">अफिस</asp:ListItem>
<asp:ListItem Value="R">घर</asp:ListItem>
<asp:ListItem Value="OT">अन्य</asp:ListItem>
</asp:DropDownList></TD><TD style="WIDTH: 90px" vAlign=top><asp:Label id="Label19" runat="server" Width="55px" Height="19px" Text="फोन न." SkinID="LJMSlbl" __designer:wfdid="w193"></asp:Label> </TD><TD style="WIDTH: 200px" vAlign=middle><asp:TextBox id="txtPhoneNumber_Phone" runat="server" Width="130px" SkinID="LJMStxt" ToolTip="फोन नं" MaxLength="15" __designer:wfdid="w194"></asp:TextBox> <asp:Button id="btnPhonePlus" onclick="btnPhonePlus_Click" runat="server" Text="Add" SkinID="Add" OnClientClick="javascript:return validateUpanelFields('_Phone',0);" __designer:wfdid="w195"></asp:Button> </TD></TR><TR><TD vAlign=top colSpan=4><asp:GridView id="grdPhone" runat="server" SkinID="LJMSgrd" ForeColor="#333333" __designer:wfdid="w196" OnSelectedIndexChanged="grdPhone_SelectedIndexChanged" CellPadding="0" AutoGenerateColumns="False" OnRowDataBound="grdPhone_RowDataBound" OnRowDeleting="grdPhone_RowDeleting">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="PID" HeaderText="PersonID"></asp:BoundField>
<asp:BoundField DataField="PTYPE" HeaderText="Phone Type"></asp:BoundField>
<asp:BoundField DataField="PHONETYPE" HeaderText="फोनको किसिम">
<ItemStyle Width="100px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="PSNO" HeaderText="PSNo"></asp:BoundField>
<asp:BoundField DataField="PHONE" HeaderText="फोन नं.">
<ItemStyle Width="200px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ACTIVE" HeaderText="Active"></asp:BoundField>
<asp:BoundField DataField="REMARKS" HeaderText="कैफियत"></asp:BoundField>
<asp:BoundField DataField="ACTION" HeaderText="Action"></asp:BoundField>
<asp:CommandField ShowSelectButton="True">
<ItemStyle Width="50px" Font-Names="Verdana"></ItemStyle>
</asp:CommandField>
<asp:CommandField ShowDeleteButton="True">
<ItemStyle Width="50px" Font-Names="Verdana"></ItemStyle>
</asp:CommandField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView></TD></TR><TR><TD vAlign=top colSpan=4>
<HR />
</TD></TR></TBODY></TABLE>
</contenttemplate>
                                        </asp:UpdatePanel>
                                        <asp:UpdatePanel id="UpdatePanel1" runat="server">
                                            <contenttemplate>
<TABLE style="WIDTH: 650px"><TBODY><TR><TD style="HEIGHT: 21px" vAlign=top colSpan=4><asp:Label id="LabelEmail" runat="server" Width="105px" Height="19px" Text="इमेल" SkinID="Unicodelbl" Font-Bold="True" __designer:wfdid="w198"></asp:Label></TD></TR><TR><TD style="WIDTH: 110px" vAlign=top><asp:Label id="Label23" runat="server" Width="105px" Height="19px" Text="ईमेलको किसिम" SkinID="Unicodelbl" __designer:wfdid="w199"></asp:Label></TD><TD style="WIDTH: 135px" vAlign=top><asp:DropDownList id="ddlEMailType_EMail" runat="server" Width="135px" SkinID="Ljmsddl" ToolTip="इमेलको किसिम" __designer:wfdid="w200"><asp:ListItem Value="N">छान्नुहोस</asp:ListItem>
<asp:ListItem Value="P">ब्यक्तिगत</asp:ListItem>
<asp:ListItem Value="O">अफिस</asp:ListItem>
<asp:ListItem Value="OT">अन्य</asp:ListItem>
</asp:DropDownList></TD><TD style="WIDTH: 90px" vAlign=top><asp:Label id="Label24" runat="server" Width="90px" Height="19px" Text="ईमेल ठेगाना" SkinID="Unicodelbl" __designer:wfdid="w201"></asp:Label></TD><TD style="WIDTH: 200px" vAlign=middle><asp:TextBox id="txtEMail_EMail" runat="server" Width="130px" SkinID="Unicodetxt" ToolTip="इमेल ठेगाना" MaxLength="50" __designer:wfdid="w202"></asp:TextBox>&nbsp;<asp:Button id="btnEMailPlus" onclick="btnEMailPlus_Click" runat="server" Text="Add" SkinID="Add" OnClientClick="javascript:return ValidateEmailFR();" __designer:wfdid="w203"></asp:Button></TD></TR><TR><TD vAlign=top colSpan=4><asp:GridView id="grdEMail" runat="server" SkinID="LJMSgrd" ForeColor="#333333" __designer:wfdid="w204" OnSelectedIndexChanged="grdEMail_SelectedIndexChanged" CellPadding="0" AutoGenerateColumns="False" OnRowDataBound="grdEMail_RowDataBound" OnRowDeleting="grdEMail_RowDeleting">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="PID" HeaderText="PersonID"></asp:BoundField>
<asp:BoundField DataField="ETYPE" HeaderText="EMail Type"></asp:BoundField>
<asp:BoundField DataField="EMAILTYPE" HeaderText="ईमेलको किसिम">
<ItemStyle Width="100px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ESNO" HeaderText="ESNo"></asp:BoundField>
<asp:BoundField DataField="EMAIL" HeaderText="ईमेल ठेगाना">
<ItemStyle Width="200px" Font-Names="Verdana"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ACTIVE" HeaderText="Active"></asp:BoundField>
<asp:BoundField DataField="REMARKS" HeaderText="कैफियत"></asp:BoundField>
<asp:BoundField DataField="ACTION" HeaderText="Action"></asp:BoundField>
<asp:CommandField ShowSelectButton="True">
<ItemStyle Width="50px" Font-Names="Verdana"></ItemStyle>
</asp:CommandField>
<asp:CommandField ShowDeleteButton="True">
<ItemStyle Width="50px" Font-Names="Verdana"></ItemStyle>
</asp:CommandField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView></TD></TR></TBODY></TABLE>
</contenttemplate>
                                        </asp:UpdatePanel>
                                    </ContentTemplate>
                                    <HeaderTemplate>
                                        सम्पर्क
                                    </HeaderTemplate>
                                </ajaxToolkit:TabPanel>
                                <ajaxToolkit:TabPanel ID="TabPanel5" runat="server" HeaderText="TabPanel5">
                                    <HeaderTemplate>
                                        योग्यता
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <asp:UpdatePanel id="UpdatePanel5" runat="server">
                                            <contenttemplate>
<TABLE style="WIDTH: 900px"><TBODY><TR><TD style="WIDTH: 85px" vAlign=top><asp:Label id="Label37" runat="server" Text="शिर्षक" SkinID="Unicodelbl" __designer:wfdid="w26"></asp:Label> </TD><TD vAlign=top colSpan=3><asp:TextBox id="txtQualSubject_Qual" runat="server" Width="150px" SkinID="LJMStxt" ToolTip="शिर्षक" MaxLength="50" __designer:wfdid="w27"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 85px" vAlign=top><asp:Label id="Label38" runat="server" Text="डिग्री" SkinID="Unicodelbl" __designer:wfdid="w28"></asp:Label> </TD><TD style="WIDTH: 200px" vAlign=top><asp:DropDownList id="ddlQualDegree_Qual" runat="server" Width="200px" SkinID="Ljmsddl" ToolTip="डिग्री" __designer:wfdid="w29"></asp:DropDownList> </TD><TD style="WIDTH: 85px" vAlign=top><asp:Label id="Label39" runat="server" Text="संस्था" SkinID="Unicodelbl" __designer:wfdid="w30"></asp:Label> </TD><TD vAlign=top><asp:DropDownList id="ddlQualInstitution_Qual" runat="server" Width="300px" SkinID="Ljmsddl" ToolTip="संस्था" __designer:wfdid="w31" AppendDataBoundItems="True"></asp:DropDownList> <asp:ImageButton id="imgAddInstitution" onclick="imgAddInstitution_Click" runat="server" Width="20px" ImageUrl="~/MODULES/COMMON/Images/add-icon.png" Height="20px" ToolTip="Add/Update Institution" OnClientClick="wopen('../../COMMON/LookUp/Institution.aspx', 'popup', 768, 600); return false;" __designer:wfdid="w32" ImageAlign="AbsMiddle"></asp:ImageButton> <asp:ImageButton id="imgRefreshInstitution" onclick="imgRefreshInstitution_Click" runat="server" Width="20px" ImageUrl="~/MODULES/COMMON/Images/refresh.png" Height="20px" ToolTip="Refresh Institution" __designer:wfdid="w33" ImageAlign="AbsMiddle"></asp:ImageButton></TD></TR><TR><TD style="WIDTH: 85px; HEIGHT: 22px" vAlign=top><asp:Label id="Label40" runat="server" Width="80px" Text="अवधि देखी" SkinID="Unicodelbl" __designer:wfdid="w34"></asp:Label> </TD><TD style="WIDTH: 200px; HEIGHT: 22px" vAlign=top><asp:TextBox id="txtQualFromDate_UDTQual" runat="server" Width="100px" SkinID="Unicodetxt" ToolTip="अवधि देखी" MaxLength="10" __designer:wfdid="w35"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender2" runat="server" TargetControlID="txtQualFromDate_UDTQual" MaskType="Date" Mask="9999/99/99" AutoComplete="False" __designer:wfdid="w36"></ajaxToolkit:MaskedEditExtender></TD><TD style="WIDTH: 85px; HEIGHT: 22px" vAlign=top><asp:Label id="Label41" runat="server" Width="80px" Text="अवधि सम्म" SkinID="Unicodelbl" __designer:wfdid="w37"></asp:Label> </TD><TD style="HEIGHT: 22px" vAlign=top><asp:TextBox id="txtQualToDate_UDTQual" runat="server" Width="100px" SkinID="Unicodetxt" ToolTip="अवधि सम्म" MaxLength="10" __designer:wfdid="w38"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender3" runat="server" TargetControlID="txtQualToDate_UDTQual" MaskType="Date" Mask="9999/99/99" AutoComplete="False" __designer:wfdid="w39"></ajaxToolkit:MaskedEditExtender>&nbsp; </TD></TR><TR><TD style="WIDTH: 85px; HEIGHT: 26px" vAlign=top><asp:Label id="Label42" runat="server" Text="ग्रेड" SkinID="Unicodelbl" __designer:wfdid="w40"></asp:Label> </TD><TD style="WIDTH: 200px; HEIGHT: 26px" vAlign=top><asp:TextBox id="txtQualGrade" runat="server" Width="50px" SkinID="Unicodetxt" MaxLength="5" __designer:wfdid="w41"></asp:TextBox> </TD><TD style="WIDTH: 85px; HEIGHT: 26px" vAlign=top><asp:Label id="Label43" runat="server" Text="प्रतिशत" SkinID="Unicodelbl" __designer:wfdid="w42"></asp:Label> </TD><TD style="HEIGHT: 26px" vAlign=top><asp:TextBox id="txtQualPercentage" runat="server" Width="50px" SkinID="Unicodetxt" MaxLength="5" __designer:wfdid="w43"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 85px" vAlign=top><asp:Label id="Label44" runat="server" Text="कैफियत" SkinID="Unicodelbl" __designer:wfdid="w44"></asp:Label> </TD><TD vAlign=top colSpan=3><asp:TextBox id="txtQualRemarks" runat="server" Width="150px" SkinID="Unicodetxt" MaxLength="50" __designer:wfdid="w45"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 85px"></TD><TD style="WIDTH: 200px" vAlign=top><asp:Button id="btnQualificationPlus" onclick="btnQualificationPlus_Click" runat="server" Text="Add" SkinID="Add" OnClientClick="javascript:return validateUpanelFields('_Qual','Qual');" __designer:wfdid="w46"></asp:Button> </TD><TD style="WIDTH: 85px"></TD><TD></TD></TR><TR><TD style="HEIGHT: 21px" colSpan=4><BR /><asp:Panel id="Panel5" runat="server" Width="100%" Height="200px" __designer:wfdid="w47" ScrollBars="Auto"><asp:GridView id="grdQualification" runat="server" Width="100%" SkinID="Unicodegrd" ForeColor="#333333" __designer:wfdid="w48" OnSelectedIndexChanged="grdQualification_SelectedIndexChanged" CellPadding="0" AutoGenerateColumns="False" OnRowDataBound="grdQualification_RowDataBound" OnRowDeleting="grdQualification_RowDeleting">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="EMPID" HeaderText="EmpId"></asp:BoundField>
<asp:BoundField DataField="SEQNO" HeaderText="क्र. सं."></asp:BoundField>
<asp:BoundField DataField="SUBJECT" HeaderText="शिर्षक"></asp:BoundField>
<asp:BoundField DataField="DEGREEID" HeaderText="Degree Id"></asp:BoundField>
<asp:BoundField DataField="DEGREENAME" HeaderText="डिग्री"></asp:BoundField>
<asp:BoundField DataField="INSTITUTIONID" HeaderText="Institution Id"></asp:BoundField>
<asp:BoundField DataField="INSTITUTIONNAME" HeaderText="संस्था"></asp:BoundField>
<asp:BoundField DataField="FROMDATE" HeaderText="अवधि देखी">
<ItemStyle Font-Names="Verdana"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="TODATE" HeaderText="अवधि सम्म">
<ItemStyle Font-Names="Verdana"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="GRADE" HeaderText="ग्रेड"></asp:BoundField>
<asp:BoundField DataField="PERCENTAGE" HeaderText="प्रतिशत"></asp:BoundField>
<asp:BoundField DataField="REMARKS" HeaderText="कैफियत"></asp:BoundField>
<asp:BoundField DataField="ACTION" HeaderText="Action"></asp:BoundField>
<asp:CommandField ShowSelectButton="True"></asp:CommandField>
<asp:CommandField ShowDeleteButton="True"></asp:CommandField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> </asp:Panel> </TD></TR></TBODY></TABLE>
</contenttemplate>
                                        </asp:UpdatePanel>
                                    </ContentTemplate>
                                </ajaxToolkit:TabPanel>
                                <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                                    <ContentTemplate>
                                        <asp:UpdatePanel id="UpdatePanel6" runat="server">
                                            <contenttemplate>
<TABLE style="WIDTH: 650px"><TBODY><TR><TD style="HEIGHT: 21px" vAlign=top colSpan=4><asp:Label id="Label10" runat="server" Height="19px" Text="काउण्सिलको बिबरण" SkinID="UnicodeHeadlbl" __designer:wfdid="w88"></asp:Label></TD></TR><TR><TD style="WIDTH: 110px" vAlign=top><asp:Label id="lblLawyerType" runat="server" Width="105px" Height="19px" Text="वकिलको प्रकार" SkinID="Unicodelbl" __designer:wfdid="w89"></asp:Label> </TD><TD style="WIDTH: 150px" vAlign=top><asp:DropDownList id="ddlLawyerType_nba" runat="server" Width="135px" SkinID="Ljmsddl" ToolTip="वकिलको प्रकार" __designer:wfdid="w90"></asp:DropDownList></TD><TD style="WIDTH: 174px" vAlign=top><asp:Label id="lblLicense" runat="server" Width="55px" Height="19px" Text="लाइसेन्स्" SkinID="Unicodelbl" __designer:wfdid="w91"></asp:Label> </TD><TD style="WIDTH: 243px" vAlign=top><asp:TextBox id="txtLicence_nba" runat="server" Width="100px" SkinID="LJMStxt" ToolTip="लाइसेन्स्" MaxLength="15" __designer:wfdid="w92"></asp:TextBox>&nbsp;<asp:Button id="btnAddNBA" onclick="btnAddNBA_Click" runat="server" Text="Add" SkinID="Add" OnClientClick="javascript:return ValidateLawyerWithSingleDate('_nba','_nba','1');" __designer:wfdid="w93"></asp:Button></TD></TR><TR><TD style="WIDTH: 110px; HEIGHT: 23px" vAlign=top><asp:Label id="lblFromDate" runat="server" Text="शुरु मिति" SkinID="LJMSlbl" __designer:wfdid="w94"></asp:Label></TD><TD style="WIDTH: 150px; HEIGHT: 23px" vAlign=top><asp:TextBox id="txtFromDate_nba" runat="server" Width="130px" SkinID="Unicodetxt" ToolTip="शुरु मिति" __designer:wfdid="w95"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender21" runat="server" TargetControlID="txtFromDate_nba" MaskType="Date" Mask="9999/99/99" AutoComplete="False" __designer:wfdid="w96"></ajaxToolkit:MaskedEditExtender></TD><TD style="WIDTH: 174px; HEIGHT: 23px" vAlign=top></TD><TD style="WIDTH: 243px; HEIGHT: 23px" vAlign=top>&nbsp;</TD></TR><TR><TD vAlign=top colSpan=4><asp:GridView id="grdNepalBarCouncil" runat="server" Width="645px" SkinID="LJMSgrd" ForeColor="#333333" __designer:wfdid="w97" OnSelectedIndexChanged="grdNepalBarCouncil_SelectedIndexChanged" CellPadding="0" AutoGenerateColumns="False" OnSelectedIndexChanging="grdNepalBarCouncil_SelectedIndexChanging" OnRowCreated="grdNepalBarCouncil_RowCreated">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="PID" HeaderText="PID"></asp:BoundField>
<asp:BoundField DataField="LAWYERTYPEID" HeaderText="LAWYERTYPEID"></asp:BoundField>
<asp:BoundField DataField="LAWYERTYPENAME" HeaderText="वकिलको प्रकार"></asp:BoundField>
<asp:BoundField DataField="LICENSENO" HeaderText="लाइसेन नं"></asp:BoundField>
<asp:BoundField DataField="FROMDATE" HeaderText="शुरु मिति">
<ItemStyle Font-Names="Verdana"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ACTION" HeaderText="ACTION"></asp:BoundField>
<asp:CommandField ShowSelectButton="True">
<ItemStyle Font-Names="Verdana"></ItemStyle>
</asp:CommandField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView></TD></TR><TR><TD style="HEIGHT: 8px" vAlign=top colSpan=4></TD></TR><TR><TD style="HEIGHT: 6px" vAlign=top><asp:Label id="lblRenewalDate" runat="server" Text="नविकरण गर्ने मिति" SkinID="LJMSlbl" __designer:wfdid="w98" Visible="False"></asp:Label></TD><TD style="HEIGHT: 6px" vAlign=top><asp:TextBox id="txtRenewalDate_ren" runat="server" Width="130px" SkinID="Unicodetxt" ToolTip="नविकरण गर्ने मिति" __designer:wfdid="w99" Visible="False"></asp:TextBox></TD><TD style="WIDTH: 174px; HEIGHT: 6px" vAlign=top><asp:Label id="lblRenewalUpTo" runat="server" Width="171px" Text="नविकरण रहने मिति" SkinID="LJMSlbl" __designer:wfdid="w100" Visible="False"></asp:Label></TD><TD style="WIDTH: 243px; HEIGHT: 6px" vAlign=top align=left><asp:TextBox id="txtRenewalUpto_ren" runat="server" Width="100px" SkinID="Unicodetxt" ToolTip="नविकरण रहने मिति" __designer:wfdid="w101" Visible="False"></asp:TextBox>&nbsp;<asp:Button id="btnAddRenewal" onclick="btnAddRenewal_Click" runat="server" Text="Add" SkinID="Add" OnClientClick="return ValidateLawyer('_ren','_ren','1','<%=this.txtRenewalUpto_ren.ClientID %>');" __designer:wfdid="w102" Visible="False"></asp:Button></TD></TR><TR><TD vAlign=top></TD><TD vAlign=top><ajaxToolkit:MaskedEditExtender id="MaskedEditExtender4" runat="server" TargetControlID="txtRenewalDate_ren" MaskType="Date" Mask="9999/99/99" AutoComplete="False" __designer:wfdid="w103"></ajaxToolkit:MaskedEditExtender></TD><TD style="WIDTH: 174px" vAlign=top></TD><TD style="WIDTH: 243px" vAlign=top><ajaxToolkit:MaskedEditExtender id="MaskedEditExtender5" runat="server" TargetControlID="txtRenewalUpto_ren" MaskType="Date" Mask="9999/99/99" AutoComplete="False" __designer:wfdid="w104"></ajaxToolkit:MaskedEditExtender></TD></TR><TR><TD style="HEIGHT: 6px" vAlign=top colSpan=4><asp:GridView id="grdLawyerRenewal" runat="server" Width="645px" SkinID="LJMSgrd" ForeColor="#333333" __designer:wfdid="w105" OnSelectedIndexChanged="grdLawyerRenewal_SelectedIndexChanged" CellPadding="0" AutoGenerateColumns="False" OnRowCreated="grdLawyerRenewal_RowCreated">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="PID" HeaderText="PID"></asp:BoundField>
<asp:BoundField DataField="LAWYERTYPEID" HeaderText="TYPEID"></asp:BoundField>
<asp:BoundField DataField="LAWYERTYPENAME" HeaderText="वकिलको प्रकार"></asp:BoundField>
<asp:BoundField DataField="LICENSENO" HeaderText="लाइसेन नं"></asp:BoundField>
<asp:BoundField DataField="RENEWALDATE" HeaderText="नविकरण मिति">
<ItemStyle Font-Names="Verdana"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="RENEWALUPTO" HeaderText="नविकरण रहनेमिति">
<ItemStyle Font-Names="Verdana"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ACTION" HeaderText="ACTION"></asp:BoundField>
<asp:CommandField ShowSelectButton="True">
<ItemStyle Font-Names="Verdana"></ItemStyle>
</asp:CommandField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView></TD></TR><TR><TD style="HEIGHT: 6px" vAlign=top colSpan=4><asp:Label id="Label11" runat="server" Height="19px" Text="एशोसिएशनको बिबरण" SkinID="UnicodeHeadlbl" __designer:wfdid="w106"></asp:Label></TD></TR><TR><TD vAlign=top colSpan=4><ajaxToolkit:MaskedEditExtender id="mskFrom" runat="server" TargetControlID="txtPrivateFromDate_pl" MaskType="Date" Mask="9999/99/99" AutoComplete="False" __designer:wfdid="w107"></ajaxToolkit:MaskedEditExtender></TD></TR><TR><TD style="HEIGHT: 6px" vAlign=top><asp:Label id="lblUnit" runat="server" Text="युनिट" SkinID="LJMSlbl" ToolTip="युनिट" __designer:wfdid="w108" Visible="False"></asp:Label></TD><TD style="HEIGHT: 6px" vAlign=top><asp:DropDownList id="ddlPrivateUnit_pl" runat="server" Width="134px" SkinID="Ljmsddl" ToolTip="युनिट" __designer:wfdid="w109" Visible="False"></asp:DropDownList></TD><TD style="WIDTH: 174px; HEIGHT: 6px" vAlign=top><asp:Label id="lblFromDate1" runat="server" Text="शुरु मिति" SkinID="LJMSlbl" ToolTip="शुरु मिति" __designer:wfdid="w110" Visible="False"></asp:Label></TD><TD style="WIDTH: 243px; HEIGHT: 6px" vAlign=top><asp:TextBox id="txtPrivateFromDate_pl" runat="server" Width="100px" SkinID="Unicodetxt" ToolTip="युनिट शुरु मिति" __designer:wfdid="w111" Visible="False"></asp:TextBox> <asp:Button id="btnAddPrivateLawyer" onclick="btnAddPrivateLawyer_Click" runat="server" Text="Add" SkinID="Add" OnClientClick="javascript:return ValidateLawyerWithSingleDate('_pl','_pl','2');" __designer:wfdid="w112" Visible="False"></asp:Button></TD></TR><TR><TD style="HEIGHT: 6px" vAlign=top colSpan=4><asp:GridView id="grdPrivateLawyer" runat="server" Width="645px" SkinID="LJMSgrd" ForeColor="#333333" __designer:wfdid="w113" OnSelectedIndexChanged="grdPrivateLawyer_SelectedIndexChanged" CellPadding="0" AutoGenerateColumns="False" OnRowDataBound="grdPrivateLawyer_RowDataBound">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="PersonID" HeaderText="PID"></asp:BoundField>
<asp:BoundField DataField="LawyerTypeID" HeaderText="Lawyer Type"></asp:BoundField>
<asp:BoundField DataField="Lisence" HeaderText="लाइसन नं."></asp:BoundField>
<asp:BoundField DataField="UnitID" HeaderText="UnitID"></asp:BoundField>
<asp:BoundField DataField="UnitName" HeaderText="युनिट"></asp:BoundField>
<asp:BoundField DataField="FromDate" HeaderText="शुरु मिति">
<ItemStyle Font-Names="Verdana"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ToDate" HeaderText="To Date"></asp:BoundField>
<asp:BoundField DataField="EntryBy" HeaderText="EntryBy"></asp:BoundField>
<asp:BoundField DataField="Action" HeaderText="Action"></asp:BoundField>
<asp:CommandField ShowSelectButton="True">
<ItemStyle Font-Names="Verdana"></ItemStyle>
</asp:CommandField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView></TD></TR><TR><TD style="HEIGHT: 6px" vAlign=top colSpan=4><ajaxToolkit:MaskedEditExtender id="mskPrivateRenFrom" runat="server" TargetControlID="txtPrivateRenFrom_lpr" MaskType="Date" Mask="9999/99/99" AutoComplete="False" __designer:wfdid="w114"></ajaxToolkit:MaskedEditExtender> <ajaxToolkit:MaskedEditExtender id="mskPrivateRenTo" runat="server" TargetControlID="txtPrivateRenUpto_lpr" MaskType="Date" Mask="9999/99/99" AutoComplete="False" __designer:wfdid="w115"></ajaxToolkit:MaskedEditExtender></TD></TR><TR><TD style="HEIGHT: 6px" vAlign=top><asp:Label id="Label411" runat="server" Text="नविकरण गर्ने मिति" SkinID="LJMSlbl" __designer:wfdid="w116" Visible="False"></asp:Label></TD><TD style="HEIGHT: 6px" vAlign=top><asp:TextBox id="txtPrivateRenFrom_lpr" runat="server" Width="130px" SkinID="Unicodetxt" ToolTip="नविकरण गर्ने मिति" __designer:wfdid="w117" Visible="False"></asp:TextBox></TD><TD style="WIDTH: 174px; HEIGHT: 6px" vAlign=top><asp:Label id="Label405" runat="server" Text="नविकरण रहने मिति" SkinID="LJMSlbl" __designer:wfdid="w118" Visible="False"></asp:Label></TD><TD style="WIDTH: 243px; HEIGHT: 6px" vAlign=top><asp:TextBox id="txtPrivateRenUpto_lpr" runat="server" Width="100px" SkinID="Unicodetxt" ToolTip="नविकरण रहने मिति" __designer:wfdid="w119" Visible="False"></asp:TextBox> <asp:Button id="btnAddPrivateRenewal" onclick="btnAddPrivateRenewal_Click" runat="server" Text="Add" SkinID="Add" OnClientClick="javascript:return ValidateLawyer('_lpr','_lpr','2','');" __designer:wfdid="w120" Visible="False"></asp:Button></TD></TR><TR><TD style="HEIGHT: 6px" vAlign=top colSpan=4><asp:GridView id="grdPrivateRenewal" runat="server" Width="645px" SkinID="LJMSgrd" ForeColor="#333333" __designer:wfdid="w121" OnSelectedIndexChanged="grdPrivateRenewal_SelectedIndexChanged" CellPadding="0" AutoGenerateColumns="False" OnRowDataBound="grdPrivateRenewal_RowDataBound">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="PersonID" HeaderText="PID"></asp:BoundField>
<asp:BoundField DataField="LawyerTypeID" HeaderText="Lawyer Type"></asp:BoundField>
<asp:BoundField DataField="Lisence" HeaderText="Lisence"></asp:BoundField>
<asp:BoundField DataField="UnitID" HeaderText="UnitID"></asp:BoundField>
<asp:BoundField DataField="UnitName" HeaderText="युनिट"></asp:BoundField>
<asp:BoundField DataField="RenewalDate" HeaderText="नविकरण गर्ने मिति">
<ItemStyle Font-Names="Verdana"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="RenewalUpto" HeaderText="नविकरण रहने मिति">
<ItemStyle Font-Names="Verdana"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="EntryBy" HeaderText="EntryBy"></asp:BoundField>
<asp:BoundField DataField="Action" HeaderText="Action"></asp:BoundField>
<asp:CommandField ShowSelectButton="True">
<ItemStyle Font-Names="Verdana"></ItemStyle>
</asp:CommandField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView></TD></TR></TBODY></TABLE><asp:HiddenField id="hdnPlDate" runat="server" __designer:wfdid="w122"></asp:HiddenField><asp:HiddenField id="hdnPID" runat="server" __designer:wfdid="w123"></asp:HiddenField><asp:HiddenField id="hdnLDate" runat="server" __designer:wfdid="w124"></asp:HiddenField> 
</ContentTemplate>
                                        </asp:UpdatePanel>
                                     </ContentTemplate>
                                    <HeaderTemplate>
                                        नेपाल बार काउण्सिल/एशोसिएशन
                                    </HeaderTemplate>
                                </ajaxToolkit:TabPanel>
                            </ajaxToolkit:TabContainer>
                        </td>
                    </tr>
                </table>
</td>
        </tr>
        <tr>
            <td align="right" colspan="6" valign="top" style="height: 19px; padding-right: 32px;">
                <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" OnClientClick="javascript:return validate(1);"
                    Text="Submit" SkinID="Normal" />
                <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" SkinID="Cancel" />&nbsp;</td>
        </tr>
    </table>
    &nbsp;
</asp:Content>
