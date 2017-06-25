<%@ Page AutoEventWireup="true" CodeFile="Employee.aspx.cs" Inherits="MODULES_PMS_Forms_Employee"
    Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master" Theme="Default"
    Title="PMS | EMPLOYEE" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script language="javascript" src="../../COMMON/JS/Validation.js" type="text/javascript"></script>
    <script language="javascript" src="../../COMMON/JS/DateValidator.js" type="text/javascript"></script>
    <script language="javascript" src="../../COMMON/JS/EnglishDateValidator.js" type="text/javascript"></script>
    <script language="javascript" src="../../COMMON/JS/Number.js" type="text/javascript"></script>
   <script language="javascript" src="../../COMMON/JS/UPanelValidation.js" type="text/javascript"></script>
    <script language="javascript" src="../../COMMON/JS/EmailValidator.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../COMMON/JS/jquery.min.js"></script>
    <script type="text/javascript" src="../../COMMON/JS/scrolltopcontrol.js">
    <script language="javascript" type="text/javascript">

//    function resize(which, max) {
//      var elem = document.getElementById(which);
//      if (elem == undefined || elem == null) return false;
//      if (max == undefined) max = 100;
//      if (elem.width > elem.height) {
//        if (elem.width > max) elem.width = max;
//      } else {
//        if (elem.height > max) elem.height = max;
//      }
//    }

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

    alert("asd");
     //This works well on all platforms & browsers.
        w += 32;
        h += 96;

        alert("url");
        alert("name");
        alert("w");
        alert("h");

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
<asp:Label id="lblStatusMessage" runat="server" Text="Label"></asp:Label> 
</ContentTemplate>
        </asp:UpdatePanel>
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
            Text="OK" Width="58px" />
        <br />
        </asp:Panel>

    <table cellspacing="5" style="width: 1000px">
        <tr>
            <td colspan="6" rowspan="2" style="height: 196px" valign="top">
                <table width="600">
                    <tr>
                        <td style="width: 120px; height: 184px;">
                            <asp:Panel ID="Panel10" runat="server" GroupingText="कर्मचारी" Height="112px" Width="110px">
                            <asp:Image ID="imgEmp" runat="server" Height="112px" ImageUrl="~/MODULES/COMMON/Images/blank.png"
                                Width="110px" /></asp:Panel>
</td>
                        <td colspan="2" valign="bottom" style="height: 184px">
                            &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                <asp:FileUpload ID="photoUpload" runat="server" Width="325px" />
                <asp:Button ID="btnUpload" runat="server" SkinID="Normal" Text="Upload" OnClick="btnUpload_Click" Width="81px" /></td>
                    </tr>
                    <tr>
                        <td style="width: 120px; height: 24px;" valign="bottom">
                            </td>
                        <td colspan="2" style="height: 24px" valign="bottom">
                            &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                <asp:Label ID="Label114" runat="server" SkinID="Unicodelbl" Text='(".jpeg  ,  .jpg  ,  .bmp and .gif files".)'
                    Width="219px"></asp:Label></td>
                    </tr>
                </table>
                &nbsp;&nbsp;
                <br />
                <asp:Label ID="lblPersonnelInfo" runat="server" Font-Bold="True" SkinID="UnicodeHeadlbl"
                    Text="व्यक्तिगत विवरण"></asp:Label><br />
            </td>
        </tr>
        <tr>
        </tr>
        <tr>
            <td valign="top" style="width: 130px; height: 26px;">
                <asp:Label ID="Label30" runat="server" Height="22px" SkinID="Unicodelbl"
                    Text="संकेत नं"></asp:Label></td>
            <td valign="top" style="height: 26px">
                <asp:TextBox ID="txtSymbolNo" runat="server" MaxLength="15" SkinID="Unicodetxt" ToolTip="संकेत नम्बर"
                    Width="82px"></asp:TextBox></td>
            <td valign="top" style="height: 26px">
                <asp:Label ID="lblOfficeNo" runat="server" SkinID="Unicodelbl" Text="कार्यालय नं"></asp:Label></td>
            <td valign="top" style="height: 26px">
                <asp:TextBox ID="txtOfficeNo" runat="server" MaxLength="10" SkinID="Unicodetxt" Width="82px"></asp:TextBox>
                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                    FilterType="Numbers" TargetControlID="txtOfficeNo">
                </ajaxToolkit:FilteredTextBoxExtender>
            </td>
            <td valign="top" style="height: 26px">
            </td>
            <td valign="top" style="height: 26px">
                <asp:TextBox ID="txtEmployeeID" runat="server" SkinID="Unicodetxt" Visible="False"
                    Width="108px"></asp:TextBox></td>
        </tr>
        <tr>
            <td valign="top" style="width: 130px; height: 26px;">
                <asp:Label ID="lblFirstName" runat="server" Height="22px" SkinID="Unicodelbl" Text="पहिलो नाम" Width="82px"></asp:Label></td>
            <td valign="top" style="height: 26px">
                <asp:TextBox ID="txtFName_Rqd" runat="server" MaxLength="35" SkinID="Unicodetxt"
                    ToolTip="पहिलो नाम" Width="130px"></asp:TextBox>
                <asp:Label ID="LabelAtarik" runat="server" ForeColor="Red" Text="*" Width="15px"></asp:Label></td>
            <td valign="top" style="height: 26px">
                <asp:Label ID="Label2" runat="server" Height="22px" SkinID="Unicodelbl" Text="बिचको नाम"></asp:Label></td>
            <td valign="top" style="height: 26px">
                <asp:TextBox ID="txtMName" runat="server" MaxLength="15" SkinID="Unicodetxt" Width="130px"></asp:TextBox></td>
            <td valign="top" style="height: 26px">
                <asp:Label ID="Label3" runat="server" Height="22px" SkinID="Unicodelbl" Text="थर"
                    Width="110px"></asp:Label></td>
            <td valign="top" style="height: 26px">
                <asp:TextBox ID="txtSurName_Rqd" runat="server" MaxLength="35" SkinID="Unicodetxt"
                    ToolTip="थर" Width="130px"></asp:TextBox></td>
        </tr>
        <tr>
            <td valign="top" style="width: 130px">
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
               <asp:DropDownList ID="ddlGender" runat="server" SkinID="Unicodeddl" Width="135px">
                    <asp:ListItem Value="SG">छान्नुहोस</asp:ListItem>
                    <asp:ListItem Value="M">पुरुष</asp:ListItem>
                    <asp:ListItem Value="F">महिला</asp:ListItem>
                    <asp:ListItem Value="O">अन्य</asp:ListItem>
                </asp:DropDownList></td>
            <td valign="top">
                <asp:Label ID="Label6" runat="server" Height="22px" SkinID="Unicodelbl" Text="बैबाहिक स्थिति"
                    Width="115px"></asp:Label></td>
            <td valign="top">
                <asp:DropDownList ID="ddlMarStatus" runat="server" SkinID="Unicodeddl" Width="135px">
                    <asp:ListItem Value="SMS">छान्नुहोस</asp:ListItem>
                    <asp:ListItem Value="S">अबिबाहित</asp:ListItem>
                    <asp:ListItem Value="M">बिबाहित</asp:ListItem>
                    <asp:ListItem Value="W">बिधवा/बिदुर</asp:ListItem>
                    <asp:ListItem Value="D">छोडपत्र</asp:ListItem>
                    <asp:ListItem Value="O">अन्य</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td valign="top" style="width: 130px">
                <asp:Label ID="Label7" runat="server" Height="22px" SkinID="Unicodelbl" Text="देश"></asp:Label></td>
            <td valign="top">
                <asp:DropDownList ID="ddlCountry" runat="server" SkinID="Unicodeddl" Width="135px">
                </asp:DropDownList></td>
            <td valign="top">
                <asp:Label ID="Label8" runat="server" Height="22px" SkinID="Unicodelbl" Text="घर भएको जिल्ला" Width="125px"></asp:Label></td>
            <td valign="top">
                <asp:DropDownList ID="ddlBirthDistrict" runat="server" SkinID="PCSddl" Width="135px">
                </asp:DropDownList></td>
            <td valign="top">
                <asp:Label ID="Label9" runat="server" Height="22px" SkinID="Unicodelbl" Text="धर्म"
                    Width="110px"></asp:Label></td>
            <td valign="top">
                <asp:DropDownList ID="ddlReligion" runat="server" SkinID="Unicodeddl" Width="135px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td valign="top" style="height: 20px; width: 130px;">
                <asp:Label ID="Label29" runat="server" SkinID="Unicodelbl" Text="हुलिया" Width="77px"></asp:Label></td>
            <td valign="top" style="height: 20px">
                <asp:TextBox ID="txtIdentityMark" runat="server" MaxLength="30" SkinID="Unicodetxt"
                    Width="130px"></asp:TextBox></td>
            <td valign="top" style="height: 20px">
                <asp:Label ID="lblCtzNo" runat="server" SkinID="Unicodelbl" Text="ना.ल.को.नं" Width="77px"></asp:Label></td>
            <td valign="top" style="height: 20px">
                <asp:TextBox ID="txtCitizenNo" runat="server" Width="55px" MaxLength="10"></asp:TextBox></td>
            <td valign="top" style="height: 20px">
                <asp:Label ID="lblPF" runat="server" Text="संचय कोष नं" SkinID="Unicodelbl"></asp:Label></td>
            <td valign="top" style="height: 20px">
                <asp:TextBox ID="txtPFNo" runat="server" Width="55px" MaxLength="10"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="6" style="height: 20px" valign="top">
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="6" valign="top">
                <table style="width: 800px">
                    <tr>
                        <td style="width: 950px; height: 90px;">
                            <ajaxToolkit:TabContainer ID="tabContainerEmpContact" runat="server" ActiveTabIndex="7"
                                CssClass="ajax_tab_theme" Width="950px">
                                <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                                    <ContentTemplate>
                                        <br />
                                        <asp:UpdatePanel id="UpdatePanel15" runat="server">
                                            <contenttemplate>
<TABLE style="WIDTH: 650px"><TBODY><TR><TD vAlign=top colSpan=6><asp:Label id="Label26" runat="server" Text="स्थायी ठेगाना" SkinID="Unicodelbl" Font-Bold="True"></asp:Label> </TD></TR><TR><TD style="WIDTH: 60px; HEIGHT: 11px" vAlign=top><asp:Label id="Label82" runat="server" Width="50px" Height="19px" Text="जिल्ला" SkinID="Unicodelbl"></asp:Label> </TD><TD style="WIDTH: 170px; HEIGHT: 11px" vAlign=top><asp:DropDownList id="ddlDistrict" runat="server" Width="156px" SkinID="Unicodeddl" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"></asp:DropDownList> </TD><TD style="WIDTH: 105px; HEIGHT: 11px" vAlign=top><asp:Label id="Label84" runat="server" Width="95px" Height="19px" Text="गा.बि.स./न.पा." SkinID="Unicodelbl"></asp:Label> </TD><TD style="WIDTH: 170px; HEIGHT: 11px" vAlign=top><asp:DropDownList id="ddlVDC" runat="server" Width="150px" SkinID="Unicodeddl" AutoPostBack="True" OnSelectedIndexChanged="ddlVDC_SelectedIndexChanged"></asp:DropDownList> </TD><TD style="WIDTH: 60px; HEIGHT: 11px" vAlign=top><asp:Label id="Label15" runat="server" Width="50px" Height="19px" Text="वडा नं." SkinID="Unicodelbl"></asp:Label> </TD><TD style="HEIGHT: 11px" vAlign=top><asp:DropDownList id="ddlWard" runat="server" Width="70px" SkinID="Unicodeddl" AppendDataBoundItems="True"></asp:DropDownList> </TD></TR><TR><TD style="WIDTH: 60px" vAlign=top><asp:Label id="Label83" runat="server" Height="19px" Text="टोल" SkinID="Unicodelbl"></asp:Label> </TD><TD style="WIDTH: 170px" vAlign=top><asp:TextBox id="txtTole" runat="server" Width="150px" SkinID="Unicodetxt" MaxLength="100" TextMode="MultiLine"></asp:TextBox></TD><TD style="WIDTH: 105px" vAlign=top><asp:ImageButton id="imgDelPerAddress" onclick="imgDelPerAddress_Click" runat="server" ImageUrl="~/MODULES/COMMON/Images/bycat1.ico" Visible="False" OnClientClick="return confirm('यो ठेगाना हटाउने हो ?')" AlternateText="Delete This Address"></asp:ImageButton></TD><TD style="WIDTH: 170px" vAlign=top></TD><TD style="WIDTH: 60px" vAlign=top></TD><TD vAlign=top></TD></TR><TR><TD vAlign=top colSpan=6>
<HR />
</TD></TR></TBODY></TABLE><asp:HiddenField id="hdnPerAddress" runat="server"></asp:HiddenField> <asp:HiddenField id="hdnTempAddress" runat="server"></asp:HiddenField> <TABLE style="WIDTH: 650px"><TBODY><TR><TD vAlign=top colSpan=6><asp:Label id="Label85" runat="server" Text="अस्थायी ठेगाना" SkinID="Unicodelbl" Font-Bold="True"></asp:Label></TD></TR><TR><TD style="WIDTH: 60px; HEIGHT: 12px" vAlign=top><asp:Label id="Label86" runat="server" Width="50px" Height="19px" Text="जिल्ला" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 170px; HEIGHT: 12px" vAlign=top><asp:DropDownList id="ddlDistrictTemp" runat="server" Width="150px" SkinID="Unicodeddl" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrictTemp_SelectedIndexChanged"></asp:DropDownList></TD><TD style="WIDTH: 105px; HEIGHT: 12px" vAlign=top><asp:Label id="Label87" runat="server" Width="95px" Height="19px" Text="गा.बि.स./न.पा." SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 170px; HEIGHT: 12px" vAlign=top><asp:DropDownList id="ddlVDCTemp" runat="server" Width="150px" SkinID="Unicodeddl" AutoPostBack="True" OnSelectedIndexChanged="ddlVDCTemp_SelectedIndexChanged"></asp:DropDownList></TD><TD style="WIDTH: 60px; HEIGHT: 12px" vAlign=top><asp:Label id="Label88" runat="server" Width="50px" Height="19px" Text="वडा नं." SkinID="Unicodelbl"></asp:Label></TD><TD style="HEIGHT: 12px" vAlign=top><asp:DropDownList id="ddlWardTemp" runat="server" Width="70px" SkinID="Unicodeddl" AppendDataBoundItems="True"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 60px" vAlign=top><asp:Label id="Label89" runat="server" Height="19px" Text="टोल" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 170px" vAlign=top><asp:TextBox id="txtToleTemp" runat="server" Width="150px" SkinID="Unicodetxt" MaxLength="100" TextMode="MultiLine"></asp:TextBox></TD><TD style="WIDTH: 105px" vAlign=top><asp:ImageButton id="imgDelTempAddress" onclick="imgDelTempAddress_Click" runat="server" ImageUrl="~/MODULES/COMMON/Images/bycat1.ico" Visible="False" OnClientClick="return confirm('यो ठेगाना हटाउने हो ?')" AlternateText="Delete This Address"></asp:ImageButton></TD><TD style="WIDTH: 170px" vAlign=top></TD><TD style="WIDTH: 60px" vAlign=top></TD><TD vAlign=top></TD></TR><TR><TD vAlign=top colSpan=6>
<HR />
</TD></TR></TBODY></TABLE>
</contenttemplate>
                                        </asp:UpdatePanel>
                                        <asp:UpdatePanel id="UpdatePanel10" runat="server">
                                            <contenttemplate>
<TABLE style="WIDTH: 650px"><TBODY><TR><TD vAlign=top colSpan=4><asp:Label id="Label13" runat="server" Width="105px" Height="19px" Text="फोन" SkinID="Unicodelbl" Font-Bold="True"></asp:Label></TD></TR><TR><TD style="WIDTH: 105px" vAlign=top><asp:Label id="Label18" runat="server" Width="100px" Height="19px" Text="फोनको किसिम" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 150px" vAlign=top><asp:DropDownList id="ddlPhoneType_Phone" runat="server" Width="135px" SkinID="Unicodeddl" ToolTip="फोनको किसिम"><asp:ListItem Value="N">छान्नुहोस</asp:ListItem>
<asp:ListItem Value="M">मोबाईल</asp:ListItem>
<asp:ListItem Value="O">अफिस</asp:ListItem>
<asp:ListItem Value="R">घर</asp:ListItem>
<asp:ListItem Value="OT">अन्य</asp:ListItem>
</asp:DropDownList> <asp:Label id="Label22" runat="server" Width="11px" Text="*" ForeColor="Red"></asp:Label></TD><TD style="WIDTH: 53px" vAlign=top><asp:Label id="Label19" runat="server" Width="51px" Height="19px" Text="फोन नं." SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:TextBox id="txtPhoneNumber_Phone" runat="server" Width="137px" SkinID="Unicodetxt" ToolTip="फोन नं" MaxLength="15"></asp:TextBox> <asp:Label id="Label27" runat="server" Width="4px" Text="*" ForeColor="Red"></asp:Label> <ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender1" runat="server" TargetControlID="txtPhoneNumber_Phone" FilterType="Numbers"></ajaxToolkit:FilteredTextBoxExtender></TD></TR><TR><TD style="WIDTH: 105px" vAlign=top></TD><TD style="WIDTH: 150px" vAlign=top></TD><TD style="WIDTH: 53px" vAlign=top></TD><TD vAlign=top><asp:Button id="btnPhonePlus" onclick="btnPhonePlus_Click" runat="server" Width="50px" Text="Add" SkinID="Add" OnClientClick="javascript:return validateUpanelFields('_Phone',0);"></asp:Button></TD></TR><TR><TD vAlign=top colSpan=4><asp:GridView id="grdPhone" runat="server" SkinID="Unicodegrd" ForeColor="#333333" OnRowDeleting="grdPhone_RowDeleting" OnRowDataBound="grdPhone_RowDataBound" AutoGenerateColumns="False" CellPadding="0" GridLines="None" OnSelectedIndexChanged="grdPhone_SelectedIndexChanged">
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
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <contenttemplate>
<TABLE style="WIDTH: 650px"><TBODY><TR><TD vAlign=top colSpan=4><asp:Label id="LabelEmail" runat="server" Width="48px" Height="19px" Text="इमेल" SkinID="Unicodelbl" Font-Bold="True"></asp:Label></TD></TR><TR><TD style="WIDTH: 20px; HEIGHT: 29px" vAlign=top><asp:Label id="Label23" runat="server" Width="105px" Height="19px" Text="ईमेलको किसिम" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 156px; HEIGHT: 29px" vAlign=top><asp:DropDownList id="ddlEMailType_EMail" runat="server" Width="135px" SkinID="Unicodeddl" ToolTip="इमेलको किसिम"><asp:ListItem Value="N">छान्नुहोस</asp:ListItem>
<asp:ListItem Value="P">ब्यक्तिगत</asp:ListItem>
<asp:ListItem Value="O">अफिस</asp:ListItem>
<asp:ListItem Value="OT">अन्य</asp:ListItem>
</asp:DropDownList> <asp:Label id="Label12" runat="server" Width="15px" Text="*" ForeColor="Red"></asp:Label></TD><TD style="WIDTH: 85px; HEIGHT: 29px" vAlign=top><asp:Label id="Label24" runat="server" Width="82px" Height="19px" Text="ईमेल ठेगाना" SkinID="Unicodelbl"></asp:Label></TD><TD style="HEIGHT: 29px" vAlign=top><asp:TextBox id="txtEMail_EMail" runat="server" Width="130px" SkinID="Unicodetxt" ToolTip="इमेल ठेगाना" MaxLength="50"></asp:TextBox> <asp:Label id="Label21" runat="server" Text="*"></asp:Label></TD></TR><TR><TD style="WIDTH: 20px" vAlign=top></TD><TD style="WIDTH: 156px" vAlign=top></TD><TD style="WIDTH: 85px" vAlign=top></TD><TD vAlign=top><asp:Button id="btnEMailPlus" onclick="btnEMailPlus_Click" runat="server" Width="50px" Text="Add" SkinID="Add" OnClientClick="javascript:return ValidateEmailFR();"></asp:Button></TD></TR><TR><TD vAlign=top colSpan=4><asp:GridView id="grdEMail" runat="server" SkinID="Unicodegrd" ForeColor="#333333" OnRowDeleting="grdEMail_RowDeleting" OnRowDataBound="grdEMail_RowDataBound" AutoGenerateColumns="False" CellPadding="0" GridLines="None" OnSelectedIndexChanged="grdEMail_SelectedIndexChanged">
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
                                        <br />
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
                                        <br />
                                        <asp:UpdatePanel id="UpdatePanel5" runat="server">
                                            <contenttemplate>
<TABLE style="WIDTH: 900px"><TBODY><TR><TD style="WIDTH: 85px" vAlign=top><asp:Label id="Label37" runat="server" Text="शिर्षक" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top colSpan=3><asp:TextBox id="txtQualSubject_Qual" runat="server" Width="150px" SkinID="Unicodetxt" ToolTip="शिर्षक" MaxLength="50"></asp:TextBox> <asp:Label id="Label96" runat="server" Text="*" ForeColor="Red"></asp:Label></TD></TR><TR><TD style="WIDTH: 85px" vAlign=top><asp:Label id="Label38" runat="server" Text="डिग्री" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 250px" vAlign=top><asp:DropDownList id="ddlQualDegree_Qual" runat="server" Width="200px" SkinID="Unicodeddl" ToolTip="डिग्री"></asp:DropDownList> <asp:Label id="Label28" runat="server" Text="*" ForeColor="Red"></asp:Label></TD><TD style="WIDTH: 85px" vAlign=top><asp:Label id="Label39" runat="server" Text="संस्था" SkinID="Unicodelbl"></asp:Label> </TD><TD vAlign=top><asp:DropDownList id="ddlQualInstitution_Qual" runat="server" Width="264px" SkinID="Unicodeddl" ToolTip="संस्था" AppendDataBoundItems="True"></asp:DropDownList> <asp:ImageButton id="imgAddInstitution" runat="server" Width="20px" ImageUrl="~/MODULES/COMMON/Images/add-icon.png" Height="20px" ToolTip="Add/Update Institution" OnClientClick="window.open('../LookUp/InstitutionPopUp.aspx','popup','width=' + '800' + ',height=' + '600' + ',' + 'location=no, menubar=no,' + 'status=no, toolbar=no, scrollbars=no, resizable=no'); return false;" ImageAlign="AbsMiddle"></asp:ImageButton> <asp:ImageButton id="imgRefreshInstitution" onclick="imgRefreshInstitution_Click" runat="server" Width="20px" ImageUrl="~/MODULES/COMMON/Images/refresh.png" Height="20px" ToolTip="Refresh Institution" ImageAlign="AbsMiddle"></asp:ImageButton></TD></TR><TR><TD style="WIDTH: 85px; HEIGHT: 22px" vAlign=top><asp:Label id="Label40" runat="server" Width="80px" Text="अवधि देखि" SkinID="Unicodelbl"></asp:Label> </TD><TD style="WIDTH: 250px; HEIGHT: 22px" vAlign=top><asp:TextBox id="txtQualFromDate_UDTQual" runat="server" Width="75px" SkinID="Unicodetxt" ToolTip="अवधि देखी" MaxLength="10"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender2" runat="server" TargetControlID="txtQualFromDate_UDTQual" MaskType="Date" Mask="9999/99/99" AutoComplete="False"></ajaxToolkit:MaskedEditExtender></TD><TD style="WIDTH: 85px; HEIGHT: 22px" vAlign=top><asp:Label id="Label41" runat="server" Width="80px" Text="अवधि सम्म" SkinID="Unicodelbl"></asp:Label> </TD><TD style="HEIGHT: 22px" vAlign=top><asp:TextBox id="txtQualToDate_UDTQual" runat="server" Width="75px" SkinID="Unicodetxt" ToolTip="अवधि सम्म" MaxLength="10"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender3" runat="server" TargetControlID="txtQualToDate_UDTQual" MaskType="Date" Mask="9999/99/99" AutoComplete="False"></ajaxToolkit:MaskedEditExtender>&nbsp; </TD></TR><TR><TD style="WIDTH: 85px; HEIGHT: 22px" vAlign=top><asp:Label id="Label42" runat="server" Text="ग्रेड" SkinID="Unicodelbl"></asp:Label> </TD><TD style="WIDTH: 250px; HEIGHT: 22px" vAlign=top><asp:TextBox id="txtQualGrade" runat="server" Width="50px" SkinID="Unicodetxt" MaxLength="5"></asp:TextBox> </TD><TD style="WIDTH: 85px; HEIGHT: 22px" vAlign=top><asp:Label id="Label43" runat="server" Text="प्रतिशत" SkinID="Unicodelbl"></asp:Label> </TD><TD style="HEIGHT: 22px" vAlign=top><asp:TextBox id="txtQualPercentage" runat="server" Width="50px" SkinID="Unicodetxt" MaxLength="5"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender19" runat="server" TargetControlID="txtQualPercentage" MaskType="Number" Mask="99.999"></ajaxToolkit:MaskedEditExtender></TD></TR><TR><TD style="WIDTH: 85px" vAlign=top><asp:Label id="Label44" runat="server" Text="कैफियत" SkinID="Unicodelbl"></asp:Label> </TD><TD vAlign=top colSpan=3><asp:TextBox id="txtQualRemarks" runat="server" Width="239px" Height="100px" SkinID="Unicodetxt" MaxLength="50" TextMode="MultiLine"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 85px"></TD><TD style="WIDTH: 250px" vAlign=top><asp:Button id="btnQualificationPlus" onclick="btnQualificationPlus_Click" runat="server" Width="50px" Text="Add" SkinID="Add" OnClientClick="javascript:return validateUpanelFields('_Qual','Qual');"></asp:Button> </TD><TD style="WIDTH: 85px"></TD><TD></TD></TR><TR><TD style="HEIGHT: 21px" colSpan=4>
<HR />
<BR /><asp:Panel id="Panel5" runat="server" Width="850px" Height="150px" ScrollBars="Auto"><asp:GridView id="grdQualification" runat="server" Width="1500px" Height="0px" SkinID="Unicodegrd" ForeColor="#333333" OnRowDeleting="grdQualification_RowDeleting" GridLines="None" CellPadding="0" AutoGenerateColumns="False" OnSelectedIndexChanged="grdQualification_SelectedIndexChanged" OnRowDataBound="grdQualification_RowDataBound">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="EMPID" HeaderText="EmpId"></asp:BoundField>
<asp:BoundField DataField="SEQNO" HeaderText="क्र. सं.">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="SUBJECT" HeaderText="शिर्षक">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="DEGREEID" HeaderText="Degree Id"></asp:BoundField>
<asp:BoundField DataField="DEGREENAME" HeaderText="डिग्री">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="INSTITUTIONID" HeaderText="Institution Id"></asp:BoundField>
<asp:BoundField DataField="INSTITUTIONNAME" HeaderText="संस्था">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="FROMDATE" HeaderText="अवधि देखी">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="TODATE" HeaderText="अवधि सम्म">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="GRADE" HeaderText="ग्रेड">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="PERCENTAGE" HeaderText="प्रतिशत">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="REMARKS" HeaderText="कैफियत">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
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
                                <ajaxToolkit:TabPanel ID="TabPanel6" runat="server" HeaderText="TabPanel6">
                                    <HeaderTemplate>
                                        तालिम
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <br />
                                        <asp:UpdatePanel id="UpdatePanel6" runat="server">
                                            <contenttemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD vAlign=top><asp:Label id="Label45" runat="server" Text="शिर्षक" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top colSpan=3><asp:TextBox id="txtTrainSubject_Training" runat="server" Width="300px" SkinID="Unicodetxt" ToolTip="शिर्षक" MaxLength="100"></asp:TextBox> <asp:Label id="Label97" runat="server" Text="*" ForeColor="Red"></asp:Label></TD></TR><TR><TD style="HEIGHT: 31px" vAlign=top><asp:Label id="Label46" runat="server" Text="सर्टिफिकेट" SkinID="Unicodelbl"></asp:Label></TD><TD style="HEIGHT: 31px" vAlign=top><asp:TextBox id="txtTrainCertificate_Training" runat="server" Width="300px" SkinID="Unicodetxt" ToolTip="सर्टिफिकेट" MaxLength="100"></asp:TextBox> <asp:Label id="Label98" runat="server" Text="*" ForeColor="Red"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 31px" vAlign=top><asp:Label id="Label47" runat="server" Width="89px" Text="संस्थाको नाम" SkinID="Unicodelbl"></asp:Label> </TD><TD style="HEIGHT: 31px" vAlign=top><asp:DropDownList id="ddlTrainInstitution_Training" runat="server" Width="300px" SkinID="Unicodeddl" ToolTip="संस्था" AppendDataBoundItems="True"></asp:DropDownList> <asp:ImageButton id="imgTrainAddInstitution" runat="server" Width="20px" ImageUrl="~/MODULES/COMMON/Images/add-icon.png" Height="20px" ToolTip="Add/Update Institution" OnClientClick="window.open('../LookUp/InstitutionPopUp.aspx','popup','width=' + '800' + ',height=' + '600' + ',' + 'location=no, menubar=no,' + 'status=no, toolbar=no, scrollbars=no, resizable=no'); return false;" ImageAlign="AbsMiddle"></asp:ImageButton> <asp:ImageButton id="imgTrainRefreshInstitution" onclick="imgRefreshInstitution_Click" runat="server" Width="20px" ImageUrl="~/MODULES/COMMON/Images/refresh.png" Height="20px" ToolTip="Refresh Institution" ImageAlign="AbsMiddle"></asp:ImageButton> </TD></TR><TR><TD style="HEIGHT: 26px" vAlign=top><asp:Label id="Label48" runat="server" Text="अवधि देखि" SkinID="Unicodelbl"></asp:Label> </TD><TD style="HEIGHT: 26px" vAlign=top><asp:TextBox id="txtTrainFromDate_UDTTraining" runat="server" Width="73px" SkinID="Unicodetxt" ToolTip="अवधि देखि" MaxLength="10"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender4" runat="server" TargetControlID="txtTrainFromDate_UDTTraining" MaskType="Date" Mask="9999/99/99" AutoComplete="False"></ajaxToolkit:MaskedEditExtender></TD><TD style="WIDTH: 100px; HEIGHT: 26px" vAlign=top><asp:Label id="Label49" runat="server" Text="अवधि सम्म" SkinID="Unicodelbl"></asp:Label> </TD><TD style="HEIGHT: 26px" vAlign=top><asp:TextBox id="txtTrainToDate_UDTTraining" runat="server" Width="73px" SkinID="Unicodetxt" ToolTip="अवधि सम्म" MaxLength="10"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender5" runat="server" TargetControlID="txtTrainToDate_UDTTraining" MaskType="Date" Mask="9999/99/99" AutoComplete="False"></ajaxToolkit:MaskedEditExtender></TD></TR><TR><TD style="HEIGHT: 26px" vAlign=top><asp:Label id="Label50" runat="server" Text="ग्रेड" SkinID="Unicodelbl"></asp:Label> </TD><TD style="HEIGHT: 26px" vAlign=top><asp:TextBox id="txtTrainGrade" runat="server" Width="50px" SkinID="Unicodetxt" MaxLength="5"></asp:TextBox> </TD><TD style="WIDTH: 100px; HEIGHT: 26px" vAlign=top><asp:Label id="Label51" runat="server" Text="प्रतिशत" SkinID="Unicodelbl"></asp:Label> </TD><TD style="HEIGHT: 26px" vAlign=top><asp:TextBox id="txtTrainPercentage" onkeypress="return DecimalOnly(event,this)" runat="server" Width="50px" SkinID="Unicodetxt" MaxLength="5"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender18" runat="server" TargetControlID="txtTrainPercentage" MaskType="Number" Mask="99.999"></ajaxToolkit:MaskedEditExtender></TD></TR><TR><TD vAlign=top><asp:Label id="Label52" runat="server" Text="कैफियत" SkinID="Unicodelbl"></asp:Label> </TD><TD vAlign=top colSpan=3><asp:TextBox id="txtTrainRemarks" runat="server" Width="240px" Height="91px" SkinID="Unicodetxt" MaxLength="30" TextMode="MultiLine"></asp:TextBox> </TD></TR><TR><TD></TD><TD vAlign=top><asp:Button id="btnTrainPlus" onclick="btnTrainPlus_Click" runat="server" Width="50px" Text="Add" SkinID="Add" OnClientClick="javascript:return validateUpanelFields('_Training','Training');"></asp:Button> </TD><TD style="WIDTH: 100px"></TD><TD></TD></TR><TR><TD style="HEIGHT: 21px" colSpan=4>
<HR />
<BR /><asp:Panel id="Panel6" runat="server" Width="100%" Height="200px" ScrollBars="Auto">&nbsp;<asp:Panel id="Panel11" runat="server" Width="125px" Height="50px"><asp:GridView id="grdTraining" runat="server" Width="1000px" SkinID="Unicodegrd" ForeColor="#333333" OnRowDeleting="grdTraining_RowDeleting" OnRowDataBound="grdTraining_RowDataBound" AutoGenerateColumns="False" CellPadding="0" GridLines="None" OnSelectedIndexChanged="grdTraining_SelectedIndexChanged">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="EMPID" HeaderText="EmpId"></asp:BoundField>
<asp:BoundField DataField="SEQNO" HeaderText="क्र.सं.">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="SUBJECT" HeaderText="शिर्षक">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="CERTIFICATENAME" HeaderText="सर्टिफिकेट">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="INSTITUTIONID" HeaderText="Institution Id"></asp:BoundField>
<asp:BoundField DataField="INSTITUTIONNAME" HeaderText="संस्था">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="FROMDATE" HeaderText="अवधि देखि">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="TODATE" HeaderText="अवधि सम्म">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="GRADE" HeaderText="ग्रेड">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="PERCENTAGE" HeaderText="प्रतिशत">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="REMARKS" HeaderText="कैफियत">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
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
</asp:GridView></asp:Panel></asp:Panel> </TD></TR></TBODY></TABLE>
</contenttemplate>
                                        </asp:UpdatePanel>
                                    </ContentTemplate>
                                </ajaxToolkit:TabPanel>
                                <ajaxToolkit:TabPanel ID="TabPanel7" runat="server" HeaderText="TabPanel7">
                                    <ContentTemplate>
                                        <br />
                                        <asp:UpdatePanel id="UpdatePanel4" runat="server">
                                            <contenttemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD style="WIDTH: 75px; HEIGHT: 21px" vAlign=top><asp:Label id="Label32" runat="server" Text="स्थान" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 242px; HEIGHT: 21px" vAlign=top><asp:TextBox id="txtVisitLocation_Visit" runat="server" SkinID="Unicodetxt" ToolTip="स्थान" MaxLength="30"></asp:TextBox></TD><TD style="WIDTH: 90px; HEIGHT: 21px" vAlign=top><asp:Label id="Label33" runat="server" Text="देश" SkinID="Unicodelbl"></asp:Label></TD><TD style="HEIGHT: 21px" vAlign=top><asp:DropDownList id="ddlVisitCountry_Visit" runat="server" Width="156px" SkinID="Unicodeddl" ToolTip="देश"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 75px" vAlign=top><asp:Label id="Label34" runat="server" Width="74px" Text="अवधि देखी" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 242px" vAlign=top><asp:TextBox id="txtVisitFromDate_URDTVisit" runat="server" Width="73px" SkinID="Unicodetxt" ToolTip="अवधि देखी" MaxLength="10"></asp:TextBox> <asp:Label id="Label100" runat="server" Width="15px" Text="*" ForeColor="Red"></asp:Label> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender6" runat="server" TargetControlID="txtVisitFromDate_URDTVisit" MaskType="Date" Mask="9999/99/99" AutoComplete="False"></ajaxToolkit:MaskedEditExtender></TD><TD style="WIDTH: 90px" vAlign=top><asp:Label id="Label35" runat="server" Width="86px" Text="अवधि सम्म" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:TextBox id="txtVisitToDate_UDTVisit" runat="server" Width="73px" SkinID="Unicodetxt" ToolTip="अवधि सम्म" MaxLength="10"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender7" runat="server" TargetControlID="txtVisitToDate_UDTVisit" MaskType="Date" Mask="9999/99/99" AutoComplete="False"></ajaxToolkit:MaskedEditExtender></TD></TR><TR><TD style="WIDTH: 75px" vAlign=top><asp:Label id="Label31" runat="server" Text="शिर्षक" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 242px" vAlign=top><asp:TextBox id="txtVisitPurpose_Visit" runat="server" Width="198px" SkinID="Unicodetxt" ToolTip="शिर्षक"></asp:TextBox> <asp:Label id="Label99" runat="server" Text="*" ForeColor="Red"></asp:Label></TD><TD style="WIDTH: 90px" vAlign=top><asp:Label id="Label116" runat="server" Text="सवारी साधन" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:TextBox id="txtVehicle" runat="server" Width="196px" SkinID="Unicodetxt"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 75px; HEIGHT: 66px" vAlign=top>&nbsp;<asp:Label id="Label36" runat="server" Text="कैफियत" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 242px; HEIGHT: 66px" vAlign=top><asp:TextBox id="txtVisitRemarks" runat="server" Width="240px" Height="91px" SkinID="Unicodetxt" MaxLength="15" TextMode="MultiLine"></asp:TextBox> </TD><TD style="WIDTH: 90px; HEIGHT: 66px" vAlign=top><asp:Button id="btnVisitsPlus" onclick="btnVisitsPlus_Click" runat="server" Width="50px" Text="Add" SkinID="Add" OnClientClick="javascript:return validateUpanelFields('_Visit','Visit');"></asp:Button></TD><TD style="HEIGHT: 66px" vAlign=bottom>&nbsp;</TD></TR><TR><TD style="HEIGHT: 21px" colSpan=4>
<HR />
<asp:Panel id="Panel4" runat="server" Width="100%" Height="200px" ScrollBars="Auto"><asp:GridView id="grdVisits" runat="server" Width="1000px" SkinID="Unicodegrd" ForeColor="#333333" OnSelectedIndexChanged="grdVisits_SelectedIndexChanged" GridLines="None" CellPadding="0" AutoGenerateColumns="False" OnRowDataBound="grdVisits_RowDataBound" OnRowDeleting="grdVisits_RowDeleting">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="EMPID" HeaderText="EmpId"></asp:BoundField>
<asp:BoundField DataField="SEQNO" HeaderText="क्र.सं.">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="LOCATION" HeaderText="स्थान">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="COUNTRY" HeaderText="CountryId"></asp:BoundField>
<asp:BoundField DataField="COUNTRYNEPNAME" HeaderText="देश">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="FROMDATE" HeaderText="अवधि देखि">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="TODATE" HeaderText="अवधि सम्म">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="PURPOSE" HeaderText="शिर्षक">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="VEHICLE" HeaderText="सवारी साधन">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="REMARKS" HeaderText="कैफियत">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="ACTION" HeaderText="Action">
<ItemStyle Font-Names="Verdana"></ItemStyle>
</asp:BoundField>
<asp:CommandField ShowSelectButton="True">
<ItemStyle Font-Names="Verdana"></ItemStyle>
</asp:CommandField>
<asp:CommandField ShowDeleteButton="True">
<ItemStyle Font-Names="Verdana"></ItemStyle>
</asp:CommandField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView></asp:Panel></TD></TR></TBODY></TABLE>
</contenttemplate>
                                        </asp:UpdatePanel>
                                    </ContentTemplate>
                                    <HeaderTemplate>
                                        भ्रमण
                                    </HeaderTemplate>
                                </ajaxToolkit:TabPanel>
                                <ajaxToolkit:TabPanel ID="TabPanel8" runat="server" HeaderText="TabPanel8">
                                    <HeaderTemplate>
                                        कागजपत्र
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <br />
                                        <asp:UpdatePanel id="UpdatePanel7" runat="server">
                                            <contenttemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD style="WIDTH: 130px" vAlign=top><asp:Label id="Label53" runat="server" Text="कागजपत्र" SkinID="Unicodelbl" __designer:wfdid="w61"></asp:Label></TD><TD style="WIDTH: 250px" vAlign=top><asp:DropDownList id="ddlDocType_Documents" runat="server" Width="155px" SkinID="Unicodeddl" ToolTip="कागजपत्र" __designer:wfdid="w62"></asp:DropDownList>&nbsp;<asp:Label id="Label101" runat="server" Text="*" ForeColor="Red" __designer:wfdid="w63"></asp:Label> <asp:ImageButton id="imgAddDocuments" runat="server" Width="20px" ImageUrl="~/MODULES/COMMON/Images/add-icon.png" Height="20px" ToolTip="Add/Update Documents Type" OnClientClick="window.open('../LookUp/DocumentTypePopUp.aspx','popup','width=' + '800' + ',height=' + '600' + ',' + 'location=no, menubar=no,' + 'status=no, toolbar=no, scrollbars=no, resizable=no'); return false;" __designer:wfdid="w64" ImageAlign="AbsMiddle"></asp:ImageButton>&nbsp;<asp:ImageButton id="imgRefreshDocument" onclick="imgRefreshDocument_Click" runat="server" Width="20px" ImageUrl="~/MODULES/COMMON/Images/refresh.png" Height="20px" ToolTip="Refresh Documents Type" __designer:wfdid="w65" ImageAlign="AbsMiddle"></asp:ImageButton> </TD><TD style="WIDTH: 125px" vAlign=top><asp:Label id="Label54" runat="server" Width="1px" Text="नं" SkinID="Unicodelbl" __designer:wfdid="w66"></asp:Label>&nbsp;</TD><TD vAlign=top><asp:TextBox id="txtDocNumber_Documents" runat="server" SkinID="Unicodetxt" ToolTip="कागजपत्रको नं" MaxLength="20" __designer:wfdid="w67"></asp:TextBox> <asp:Label id="Label102" runat="server" Text="*" ForeColor="Red" __designer:wfdid="w68"></asp:Label></TD></TR><TR><TD style="WIDTH: 130px" vAlign=top><asp:Label id="Label55" runat="server" Width="123px" Text="जारी भएको स्थान" SkinID="Unicodelbl" __designer:wfdid="w69"></asp:Label></TD><TD style="WIDTH: 250px" vAlign=top><asp:DropDownList id="ddlDocIssuedFrom" runat="server" Width="155px" SkinID="Unicodeddl" __designer:wfdid="w70"></asp:DropDownList></TD><TD style="WIDTH: 125px" vAlign=top><asp:Label id="Label56" runat="server" Width="122px" Text="जारी भएको मिति" SkinID="Unicodelbl" __designer:wfdid="w71"></asp:Label></TD><TD vAlign=top><asp:TextBox id="txtDocIssuedOn_UDTDocuments" runat="server" Width="73px" SkinID="Unicodetxt" ToolTip="जारी भएको मिति" MaxLength="10" __designer:wfdid="w72"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender8" runat="server" TargetControlID="txtDocIssuedOn_UDTDocuments" MaskType="Date" Mask="9999/99/99" AutoComplete="False" __designer:wfdid="w73"></ajaxToolkit:MaskedEditExtender></TD></TR><TR><TD style="WIDTH: 130px" vAlign=top><asp:Label id="Label57" runat="server" Text="जारी गरेको संस्था" SkinID="Unicodelbl" __designer:wfdid="w74"></asp:Label></TD><TD style="WIDTH: 250px" vAlign=top><asp:TextBox id="txtDocIssuedBy" runat="server" Width="211px" SkinID="Unicodetxt" MaxLength="30" __designer:wfdid="w75"></asp:TextBox></TD><TD style="WIDTH: 125px" vAlign=top><asp:Button id="btnDocumentsPlus" onclick="btnDocumentsPlus_Click" runat="server" Width="50px" Text="Add" SkinID="Add" OnClientClick="javascript:return validateUpanelFields('_Documents','Documents');" __designer:wfdid="w76"></asp:Button></TD><TD></TD></TR><TR><TD style="HEIGHT: 21px" colSpan=4>
<HR />
</TD></TR><TR><TD vAlign=top colSpan=4><asp:Panel id="Panel7" runat="server" Width="900px" Height="150px" ScrollBars="Auto" __designer:wfdid="w77"><asp:GridView id="grdDocuments" runat="server" Width="1000px" SkinID="Unicodegrd" ForeColor="#333333" __designer:wfdid="w78" OnSelectedIndexChanged="grdDocuments_SelectedIndexChanged" OnRowDataBound="grdDocuments_RowDataBound" GridLines="None" AutoGenerateColumns="False" CellPadding="0" OnRowDeleting="grdDocuments_RowDeleting">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="PID" HeaderText="PersonId"></asp:BoundField>
<asp:BoundField DataField="DOCTYPEID" HeaderText="Doc Type Id"></asp:BoundField>
<asp:BoundField DataField="DOCTYPENAME" HeaderText="कागजपत्र">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="DOCNUMBER" HeaderText="नं.">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="ISSUEDFROM" HeaderText="Issued From ID"></asp:BoundField>
<asp:BoundField DataField="DISTUCODENAME" HeaderText="जारी भएको स्थान">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="ISSUEDON" HeaderText="जारी भएको मिति">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="ISSUEDBY" HeaderText="जारी गरेको संस्था">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="ACTIVE" HeaderText="Active"></asp:BoundField>
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
</asp:GridView></asp:Panel></TD></TR></TBODY></TABLE>
</contenttemplate>
                                        </asp:UpdatePanel>
                                    </ContentTemplate>
                                </ajaxToolkit:TabPanel>
                                <ajaxToolkit:TabPanel ID="TabPanel4" runat="server" HeaderText="TabPanel4">
                                    <HeaderTemplate>
                                        अनुभव
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <br />
                                        <asp:UpdatePanel id="UpdatePanel8" runat="server">
                                            <contenttemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD style="WIDTH: 125px; HEIGHT: 15px" vAlign=top><asp:Label id="Label58" runat="server" Width="118px" Text="पदस्थापना स्थान" SkinID="Unicodelbl" __designer:wfdid="w100"></asp:Label> </TD><TD style="WIDTH: 199px; HEIGHT: 15px" vAlign=top><asp:TextBox id="txtExpPostingLocation_Experience" runat="server" Width="172px" SkinID="Unicodetxt" ToolTip="पदस्थापना स्थान" MaxLength="20" __designer:wfdid="w101"></asp:TextBox> <asp:Label id="Label103" runat="server" Width="15px" Text="*" ForeColor="Red" __designer:wfdid="w102"></asp:Label></TD><TD style="WIDTH: 122px; HEIGHT: 15px" vAlign=top><asp:Label id="Label62" runat="server" Width="120px" Text="काम गरेको स्थान" SkinID="Unicodelbl" __designer:wfdid="w103"></asp:Label></TD><TD style="WIDTH: 277px; HEIGHT: 15px" vAlign=top><asp:TextBox id="txtExpJobLocation_Experience" runat="server" Width="203px" SkinID="Unicodetxt" ToolTip="काम गरेको स्थान" MaxLength="20" __designer:wfdid="w104"></asp:TextBox> <asp:Label id="Label1" runat="server" Text="*" ForeColor="Red" __designer:wfdid="w105"></asp:Label></TD></TR><TR><TD style="WIDTH: 125px; HEIGHT: 15px" vAlign=top><asp:Label id="Label59" runat="server" Text="अवधि देखि" SkinID="Unicodelbl" Font-Names="PCS NEPALI" __designer:wfdid="w106"></asp:Label></TD><TD style="WIDTH: 199px; HEIGHT: 15px" vAlign=top><asp:TextBox id="txtExpFromDate_UDTExperience" runat="server" Width="73px" SkinID="Unicodetxt" ToolTip="अवधि देखी" MaxLength="10" __designer:wfdid="w107"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender9" runat="server" TargetControlID="txtExpFromDate_UDTExperience" MaskType="Date" Mask="9999/99/99" AutoComplete="False" __designer:wfdid="w108"></ajaxToolkit:MaskedEditExtender></TD><TD style="WIDTH: 122px; HEIGHT: 15px" vAlign=top><asp:Label id="Label60" runat="server" Text="अवधि सम्म" SkinID="Unicodelbl" __designer:wfdid="w109"></asp:Label></TD><TD style="WIDTH: 277px; HEIGHT: 15px" vAlign=top><asp:TextBox id="txtExpToDate_UDTExperience" runat="server" Width="73px" SkinID="Unicodetxt" ToolTip="अवधि सम्म" MaxLength="10" __designer:wfdid="w110"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender10" runat="server" TargetControlID="txtExpToDate_UDTExperience" MaskType="Date" Mask="9999/99/99" AutoComplete="False" __designer:wfdid="w111"></ajaxToolkit:MaskedEditExtender></TD></TR><TR><TD style="WIDTH: 125px; HEIGHT: 21px" vAlign=top><asp:Label id="Label63" runat="server" Text="वर्ग" SkinID="Unicodelbl" __designer:wfdid="w112"></asp:Label></TD><TD style="WIDTH: 199px; HEIGHT: 21px" vAlign=top><asp:DropDownList id="ddlExpClassification" runat="server" Width="80px" SkinID="Unicodeddl" __designer:wfdid="w113"><asp:ListItem>छन्नुहोस</asp:ListItem>
<asp:ListItem>क</asp:ListItem>
<asp:ListItem>ख</asp:ListItem>
<asp:ListItem>ग</asp:ListItem>
<asp:ListItem>घ</asp:ListItem>
<asp:ListItem>ङ</asp:ListItem>
</asp:DropDownList></TD><TD style="WIDTH: 122px; HEIGHT: 21px" vAlign=top><asp:Label id="Label61" runat="server" Text="कैफियत" SkinID="Unicodelbl" __designer:wfdid="w114"></asp:Label></TD><TD style="WIDTH: 277px; HEIGHT: 21px" vAlign=top><asp:TextBox id="txtExpRemarks" runat="server" Width="234px" Height="90px" SkinID="Unicodetxt" MaxLength="30" __designer:wfdid="w115" TextMode="MultiLine"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 125px; HEIGHT: 21px"></TD><TD style="WIDTH: 199px; HEIGHT: 21px"></TD><TD style="WIDTH: 122px; HEIGHT: 21px"></TD><TD style="WIDTH: 277px; HEIGHT: 21px"><asp:Button id="btnExperiencesPlus" onclick="btnExperiencesPlus_Click" runat="server" Width="50px" Text="Add" SkinID="Add" OnClientClick="javascript:return validateUpanelFields('_Experience','Experience');" __designer:wfdid="w116"></asp:Button></TD></TR><TR><TD style="HEIGHT: 21px" colSpan=4>
<HR />
<BR /><asp:Panel id="Panel8" runat="server" Width="900px" Height="170px" ScrollBars="Auto" __designer:wfdid="w117"><asp:GridView id="grdExperiences" runat="server" Width="950px" SkinID="Unicodegrd" ForeColor="#333333" __designer:wfdid="w118" OnSelectedIndexChanged="grdExperiences_SelectedIndexChanged" OnRowDataBound="grdExperiences_RowDataBound" GridLines="None" AutoGenerateColumns="False" OnRowDeleting="grdExperiences_RowDeleting">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="EMPID" HeaderText="Emp ID"></asp:BoundField>
<asp:BoundField DataField="SEQNO" HeaderText="क्र.सं."></asp:BoundField>
<asp:BoundField DataField="FROMDATE" HeaderText="अवधि देखी"></asp:BoundField>
<asp:BoundField DataField="TODATE" HeaderText="अवधि सम्म"></asp:BoundField>
<asp:BoundField DataField="POSTINGLOCATION" HeaderText="पदस्थापना स्थान"></asp:BoundField>
<asp:BoundField DataField="JOBLOCATION" HeaderText="काम गरेको स्थान"></asp:BoundField>
<asp:BoundField DataField="CLASSIFICATION" HeaderText="वर्ग"></asp:BoundField>
<asp:BoundField DataField="REMARKS" HeaderText="कैफियत"></asp:BoundField>
<asp:BoundField DataField="ACTION" HeaderText="Action"></asp:BoundField>
<asp:CommandField ShowSelectButton="True">
<ItemStyle Font-Names="Verdana"></ItemStyle>
</asp:CommandField>
<asp:CommandField ShowDeleteButton="True">
<ItemStyle Font-Names="Verdana"></ItemStyle>
</asp:CommandField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView></asp:Panel></TD></TR></TBODY></TABLE>
</contenttemplate>
                                        </asp:UpdatePanel>
                                    </ContentTemplate>
                                </ajaxToolkit:TabPanel>
                                <ajaxToolkit:TabPanel ID="TabPanel9" runat="server" HeaderText="TabPanel9">
                                    <HeaderTemplate>
                                        प्रकाशन
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <br />
                                        <asp:UpdatePanel id="updPublication" runat="server">
                                            <contenttemplate>
<TABLE style="WIDTH: 648px"><TBODY><TR><TD style="WIDTH: 150px; HEIGHT: 21px"><asp:Label id="Label68" runat="server" Width="52px" Text="प्रकाशन" SkinID="Unicodelbl" __designer:wfdid="w139"></asp:Label></TD><TD style="HEIGHT: 21px"><asp:TextBox id="txtPublication_Publ" runat="server" Width="210px" SkinID="Unicodetxt" ToolTip="प्रकाशन" __designer:wfdid="w140"></asp:TextBox> <asp:Label id="Label104" runat="server" Text="*" ForeColor="Red" __designer:wfdid="w141"></asp:Label></TD></TR><TR><TD style="WIDTH: 150px; HEIGHT: 21px"><asp:Label id="Label10" runat="server" Width="125px" Text="प्रकाशनको किसिम" SkinID="Unicodelbl" __designer:wfdid="w142"></asp:Label></TD><TD style="HEIGHT: 21px"><asp:DropDownList id="ddlPubType" runat="server" Width="217px" SkinID="Unicodeddl" __designer:wfdid="w143"></asp:DropDownList> <asp:Label id="Label106" runat="server" Width="15px" Text="*" ForeColor="Red" __designer:wfdid="w144"></asp:Label></TD></TR><TR><TD style="WIDTH: 150px"><asp:Label id="Label75" runat="server" Width="110px" Text="प्रकाशक" SkinID="Unicodelbl" __designer:wfdid="w145"></asp:Label></TD><TD><asp:TextBox id="txtPublisher_Publ" runat="server" Width="209px" SkinID="Unicodetxt" ToolTip="प्रकाशक" __designer:wfdid="w146"></asp:TextBox> <asp:Label id="Label117" runat="server" Text="*" ForeColor="Red" __designer:wfdid="w147"></asp:Label></TD></TR><TR><TD style="WIDTH: 150px; HEIGHT: 21px"><asp:Label id="Label76" runat="server" Width="110px" Text="प्रकाशन मिति" SkinID="Unicodelbl" __designer:wfdid="w148"></asp:Label></TD><TD style="HEIGHT: 21px"><asp:TextBox id="txtPubDate_UDTPubl" runat="server" Width="73px" SkinID="Unicodetxt" ToolTip="प्रकाशन मिति" __designer:wfdid="w149"></asp:TextBox>&nbsp;<asp:Label id="Label105" runat="server" Text="*" ForeColor="Red" __designer:wfdid="w150"></asp:Label> <ajaxToolkit:MaskedEditExtender id="mskPublicationDate" runat="server" TargetControlID="txtPubDate_UDTPubl" MaskType="Date" Mask="9999/99/99" AutoComplete="False" __designer:wfdid="w151"></ajaxToolkit:MaskedEditExtender></TD></TR><TR><TD style="WIDTH: 150px; HEIGHT: 21px" vAlign=top><asp:Label id="Label115" runat="server" Text="कैफियत" SkinID="Unicodelbl" __designer:wfdid="w152"></asp:Label></TD><TD style="HEIGHT: 21px"><asp:TextBox id="txtPublicationRemarks" runat="server" Width="213px" Height="97px" __designer:wfdid="w153" TextMode="MultiLine"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 150px" height=20></TD><TD height=20><asp:Button id="btnAddPublication" onclick="btnAddPublication_Click" runat="server" Width="50px" Text="Add" SkinID="Add" OnClientClick="javascript:return validateUpanelFields('_Publ','Publ');" __designer:wfdid="w154"></asp:Button></TD></TR></TBODY></TABLE><TABLE style="WIDTH: 1px"><TBODY><TR><TD style="HEIGHT: 21px"><asp:Panel id="Panel9" runat="server" Width="100%" Height="200px" ScrollBars="Auto" __designer:wfdid="w155"><HR />
<asp:GridView id="grdPublication" runat="server" Width="882px" SkinID="Unicodegrd" ForeColor="#333333" __designer:wfdid="w156" OnSelectedIndexChanged="grdPublication_SelectedIndexChanged" GridLines="None" AutoGenerateColumns="False" CellPadding="0" OnRowDeleting="grdPublication_RowDeleting" OnRowCreated="grdPublication_RowCreated">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="EmpID" HeaderText="EmpID"></asp:BoundField>
<asp:BoundField DataField="PublicationID" HeaderText="PublicationID"></asp:BoundField>
<asp:BoundField DataField="PublicationName" HeaderText="प्रकाशनको नाम">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="PubTypeID" HeaderText="प्रकाशन किसिमको ID"></asp:BoundField>
<asp:BoundField DataField="PublicationTypeName" HeaderText="प्रकाशन किसिम">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="Publisher" HeaderText="प्रकाशन कर्त्ता">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="PublicationDate" HeaderText="प्रकाशन मिति">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="Remarks" HeaderText="कैफियत">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="Action" HeaderText="Action"></asp:BoundField>
<asp:CommandField ShowSelectButton="True"></asp:CommandField>
<asp:CommandField ShowDeleteButton="True"></asp:CommandField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView></asp:Panel></TD></TR></TBODY></TABLE>
</contenttemplate>
                                        </asp:UpdatePanel>
                                        <br />
                                    </ContentTemplate>
                                </ajaxToolkit:TabPanel>
                                                      <ajaxToolkit:TabPanel ID="TabPanel12" runat="server" HeaderText="TabPanel12">
                                    <ContentTemplate>
                                        <br />
                                        <asp:UpdatePanel id="UpdatePanel11" runat="server">
                                            <contenttemplate>
<TABLE width=900><TBODY><TR><TD style="WIDTH: 121px"><asp:Label id="lblCompanyName" runat="server" Width="100px" Text="कम्पनीको नाम" SkinID="Unicodelbl" __designer:wfdid="w17"></asp:Label></TD><TD style="WIDTH: 270px"><asp:TextBox id="txtCompanyName" runat="server" Width="243px" Height="15px" __designer:wfdid="w18"></asp:TextBox> <asp:Label id="Label107" runat="server" Width="15px" Text="*" ForeColor="Red" __designer:wfdid="w19"></asp:Label></TD><TD style="WIDTH: 90px"><asp:Label id="lblinsuranceNo" runat="server" Width="85px" Text="इन्सुरेन्स नं" SkinID="Unicodelbl" __designer:wfdid="w20"></asp:Label></TD><TD><asp:TextBox id="txtInsuranceNo" runat="server" Width="110px" SkinID="Unicodetxt" __designer:wfdid="w21"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 121px"><asp:Label id="lblFormDate" runat="server" Text="देखि" SkinID="Unicodelbl" __designer:wfdid="w22"></asp:Label></TD><TD style="WIDTH: 270px"><asp:TextBox id="txtFromDate" runat="server" Width="73px" SkinID="Unicodetxt" __designer:wfdid="w23"></asp:TextBox></TD><TD style="WIDTH: 90px"><asp:Label id="lblMaturityDate" runat="server" Text="सम्म" SkinID="Unicodelbl" __designer:wfdid="w24"></asp:Label></TD><TD><asp:TextBox id="txtMaturityDate" runat="server" Width="73px" SkinID="Unicodetxt" __designer:wfdid="w25"></asp:TextBox> <asp:Button id="btnAdd" onclick="btnAdd_Click" runat="server" Width="50px" Text="Add" SkinID="Add" __designer:wfdid="w26"></asp:Button></TD></TR><TR><TD colSpan=2><ajaxToolkit:MaskedEditExtender id="MaskedEditExtender16" runat="server" TargetControlID="txtFromDate" MaskType="Date" Mask="9999/99/99" AutoComplete="False" __designer:wfdid="w27"></ajaxToolkit:MaskedEditExtender></TD><TD colSpan=2><ajaxToolkit:MaskedEditExtender id="MaskedEditExtender17" runat="server" TargetControlID="txtMaturityDate" MaskType="Date" Mask="9999/99/99" AutoComplete="False" __designer:wfdid="w28"></ajaxToolkit:MaskedEditExtender></TD></TR><TR><TD style="HEIGHT: 155px" colSpan=4>
<HR />
<asp:Panel id="Panel3" runat="server" Width="600px" Height="150px" ScrollBars="Auto" __designer:wfdid="w29"><asp:GridView id="grdInsuranceData" runat="server" Width="560px" SkinID="Unicodegrd" ForeColor="#333333" __designer:wfdid="w30" GridLines="None" AutoGenerateColumns="False" CellPadding="0" OnRowCreated="grdInsuranceData_RowCreated">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="EmpID" HeaderText="EmpID"></asp:BoundField>
<asp:BoundField DataField="CompanyName" HeaderText="कम्पनीको नाम">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="InsuranceNo" HeaderText="इन्सुरेन्स नं">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="FromDate" HeaderText="देखि">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="MaturityDate" HeaderText="सम्म">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="EntryBy" HeaderText="Entry By"></asp:BoundField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView></asp:Panel><BR /></TD></TR><TR><TD style="HEIGHT: 155px" colSpan=4></TD></TR></TBODY></TABLE>
</contenttemplate>
                                        </asp:UpdatePanel>
                                    </ContentTemplate>
                                    <HeaderTemplate>
                                        बिमा
                                    </HeaderTemplate>
                                </ajaxToolkit:TabPanel>
                                <ajaxToolkit:TabPanel ID="TabPanel10" runat="server" HeaderText="TabPanel10">
                                    <ContentTemplate>
                                        <br />
                                        <asp:UpdatePanel id="UpdatePanel2" runat="server">
                                            <contenttemplate>
<TABLE style="WIDTH: 700px"><TBODY><TR><TD style="WIDTH: 125px" vAlign=top align=left><asp:Label id="Label79" runat="server" Width="85px" Text="पहिलो नाम" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 182px" vAlign=top align=left><asp:TextBox id="txtRelationFirstName_Relative" runat="server" Width="174px" SkinID="Unicodetxt" ToolTip="पहिलो नाम" MaxLength="30"></asp:TextBox> <asp:Label id="Label108" runat="server" Text="*" ForeColor="Red"></asp:Label></TD><TD style="WIDTH: 80px" vAlign=top align=left><asp:Label id="Label80" runat="server" Width="80px" Text="बिचको नाम" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 220px" vAlign=top align=left><asp:TextBox id="txtRelationMName" runat="server" Width="135px" SkinID="Unicodetxt" MaxLength="30"></asp:TextBox></TD><TD style="WIDTH: 116px" vAlign=top align=left><asp:Label id="Label81" runat="server" Text="थर" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top align=left><asp:TextBox id="txtRelationLastName_Relative" runat="server" Width="149px" SkinID="Unicodetxt" ToolTip="थर" MaxLength="30"></asp:TextBox> <asp:Label id="Label118" runat="server" Text="*" ForeColor="Red"></asp:Label></TD></TR><TR><TD style="WIDTH: 125px; HEIGHT: 15px" vAlign=top align=left><asp:Label id="Label90" runat="server" Text="लिंग" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 182px; HEIGHT: 15px" vAlign=top align=left><asp:DropDownList id="ddlRelationGender" runat="server" Width="87px" SkinID="Unicodeddl"><asp:ListItem Value="SG">छान्नुहोस</asp:ListItem>
<asp:ListItem Value="M">पुरुष</asp:ListItem>
<asp:ListItem Value="F">महिला</asp:ListItem>
<asp:ListItem Value="O">अन्य</asp:ListItem>
</asp:DropDownList></TD><TD style="WIDTH: 80px; HEIGHT: 15px" vAlign=top align=left><asp:Label id="Label91" runat="server" Width="75px" Text="जन्म मिति" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 220px; HEIGHT: 15px" vAlign=top align=left><asp:TextBox id="txtRelationDOB_DTRelative" runat="server" Width="73px" SkinID="Unicodetxt" ToolTip="जन्म मिति"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender11" runat="server" TargetControlID="txtRelationDOB_DTRelative" MaskType="Date" Mask="9999/99/99" AutoComplete="False"></ajaxToolkit:MaskedEditExtender></TD><TD style="WIDTH: 116px; HEIGHT: 15px" vAlign=top align=left><asp:Label id="Label92" runat="server" Width="110px" Text="बैबाहिक सम्बन्ध" SkinID="Unicodelbl"></asp:Label></TD><TD style="HEIGHT: 15px" vAlign=top align=left><asp:DropDownList id="ddlRelationMarStatus" runat="server" Width="105px" SkinID="Unicodeddl"><asp:ListItem Value="SMS">छान्नुहोस</asp:ListItem>
<asp:ListItem Value="S">अबिबाहित</asp:ListItem>
<asp:ListItem Value="M">बिबाहित</asp:ListItem>
<asp:ListItem Value="W">बिधवा/बिदुर</asp:ListItem>
<asp:ListItem Value="D">छोडपत्र</asp:ListItem>
<asp:ListItem Value="O">अन्य</asp:ListItem>
</asp:DropDownList> <asp:HiddenField id="hdnRelativeID" runat="server"></asp:HiddenField></TD></TR><TR><TD style="WIDTH: 125px" vAlign=top align=left><asp:Label id="Label93" runat="server" Width="120px" Text="घर भएको जिल्ला" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 182px" vAlign=top align=left><asp:DropDownList id="ddlRelationHomeDistrict" runat="server" Width="176px" SkinID="Unicodeddl"></asp:DropDownList></TD><TD style="WIDTH: 80px" vAlign=top align=left><asp:Label id="Label94" runat="server" Width="55px" Text="सम्बन्ध" SkinID="Unicodelbl"></asp:Label><asp:Label id="Label109" runat="server" Width="15px" Text="*" ForeColor="Red"></asp:Label></TD><TD style="WIDTH: 220px" vAlign=top align=left><asp:DropDownList id="ddlRelationType_Relative" runat="server" Width="113px" SkinID="Unicodeddl" ToolTip="सम्बन्ध"></asp:DropDownList> </TD><TD style="WIDTH: 116px" vAlign=top align=left><asp:Label id="Label95" runat="server" Text="पेशा" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top align=left><asp:TextBox id="txtRelativeOcc" runat="server" SkinID="Unicodetxt"></asp:TextBox></TD></TR><TR><TD vAlign=top align=left colSpan=6><asp:Button id="btnSearchRelatives" onclick="btnSearchRelatives_Click" runat="server" Text="Relatives" SkinID="Normal"></asp:Button> <asp:Button id="btnAddRelatives" onclick="btnAddRelatives_Click" runat="server" Width="50px" Text="Add" SkinID="Normal" OnClientClick="javascript:return validateUpanelFields('_Relative','Relative');"></asp:Button> <asp:Button id="btnClearRelatives" onclick="btnClearRelatives_Click" runat="server" Text="Clear" SkinID="Cancel"></asp:Button></TD></TR><TR><TD style="HEIGHT: 19px" vAlign=top align=left colSpan=6>
<HR />
<BR /><asp:Panel id="Panel1" runat="server" Width="890px" Height="150px" ScrollBars="Auto"><asp:GridView id="grdEmpRelatives" runat="server" Width="1600px" SkinID="Unicodegrd" ForeColor="#333333" OnSelectedIndexChanged="grdEmpRelatives_SelectedIndexChanged" GridLines="None" CellPadding="0" AutoGenerateColumns="False" OnRowDataBound="grdEmpRelatives_RowDataBound">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="PID" HeaderText="आईडि">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="RELATIVEID" HeaderText="ना.आईडी">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="FIRSTNAME" HeaderText="पहिलो नाम"></asp:BoundField>
<asp:BoundField DataField="MIDNAME" HeaderText="बिचको नाम"></asp:BoundField>
<asp:BoundField DataField="SURNAME" HeaderText="थर"></asp:BoundField>
<asp:BoundField DataField="RDFULLNAME" HeaderText="पुरा नाम थर">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="GENDER" HeaderText="लि.आईडि">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="RDGENDER" HeaderText="लिंग">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="DOB" HeaderText="जन्म मिति">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="MARITALSTATUS" HeaderText="बैबाहिक">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="RDMARITALSTATUS" HeaderText="बैबाहिक सम्बन्ध">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="BIRTHDISTRICT" HeaderText="घर">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="NEPDISTNAME" HeaderText="घर भएको जिल्ला">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="RELATIONTYPEID" HeaderText="सम्बन्ध">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="RELATIONTYPENAME" HeaderText="सम्बन्ध">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="OCCUPATION" HeaderText="पेशा">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="ईच्छाइएको">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
<ItemTemplate>
<asp:CheckBox id="chkIsBeneficiary" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "ISBENEFICIARY").ToString() == "True" %>'></asp:CheckBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="सक्रिय">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
<ItemTemplate>
<asp:CheckBox id="chkRelativeActive" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "ISACTIVE").ToString() == "True" %>'></asp:CheckBox>
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="ACTION" HeaderText="Action"></asp:BoundField>
<asp:CommandField ShowSelectButton="True"></asp:CommandField>
<asp:CommandField ShowDeleteButton="True"></asp:CommandField>
<asp:TemplateField><ItemTemplate>
<asp:CheckBox id="chkWasBeneficiary" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "ISBENEFICIARY").ToString() == "True" %>'></asp:CheckBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField><ItemTemplate>
<asp:CheckBox id="chkWasRelative" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "ISACTIVE").ToString() == "True" %>'></asp:CheckBox>
</ItemTemplate>
</asp:TemplateField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> </asp:Panel></TD></TR><TR><TD style="HEIGHT: 20px" vAlign=top align=left colSpan=6></TD></TR></TBODY></TABLE>
</contenttemplate>
                                        </asp:UpdatePanel>
                                    </ContentTemplate>
                                    <HeaderTemplate>
                                        नातेदार
                                    </HeaderTemplate>
                                </ajaxToolkit:TabPanel>
                                <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                                    <ContentTemplate>
                                        <br />
                                        <asp:UpdatePanel id="UpdatePanel9" runat="server">
                                            <contenttemplate>
<TABLE width=900><TBODY><TR><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Label64" runat="server" Text="कार्यालय" SkinID="Unicodelbl" __designer:wfdid="w45"></asp:Label></TD><TD vAlign=top colSpan=5><asp:DropDownList id="ddlOrganization_Posting" runat="server" Width="252px" SkinID="Unicodeddl" ToolTip="कार्यालय" AutoPostBack="True" __designer:wfdid="w46" OnSelectedIndexChanged="ddlOrganization_Posting_SelectedIndexChanged">
                                                    </asp:DropDownList> <asp:Label id="Label110" runat="server" Text="*" ForeColor="Red" __designer:wfdid="w47"></asp:Label></TD></TR><TR><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Label65" runat="server" Width="24px" Text="पद" SkinID="Unicodelbl" __designer:wfdid="w48"></asp:Label> </TD><TD style="WIDTH: 200px" vAlign=top><asp:DropDownList id="ddlPost_Posting" runat="server" Width="150px" SkinID="Unicodeddl" ToolTip="पद" AutoPostBack="True" __designer:wfdid="w49" OnSelectedIndexChanged="ddlPost_Posting_SelectedIndexChanged" AppendDataBoundItems="True">
                                                    </asp:DropDownList> <asp:Label id="Label111" runat="server" Text="*" ForeColor="Red" __designer:wfdid="w50"></asp:Label></TD><TD style="WIDTH: 115px; COLOR: #000000" vAlign=top><asp:Label id="Label66" runat="server" Width="80px" Text="उपलब्ध पद" SkinID="Unicodelbl" __designer:wfdid="w51"></asp:Label> </TD><TD vAlign=top colSpan=3><asp:DropDownList id="ddlAvailablePost_Posting" runat="server" Width="225px" SkinID="Unicodeddl" ToolTip="उपलब्ध पद" __designer:wfdid="w52" AppendDataBoundItems="True">
                                                    </asp:DropDownList> <asp:Label id="Label113" runat="server" Width="15px" Text="*" ForeColor="Red" __designer:wfdid="w53"></asp:Label></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 15px" vAlign=top><asp:Label id="Label72" runat="server" Width="90px" Text="छनौट तरिका" SkinID="Unicodelbl" __designer:wfdid="w54"></asp:Label></TD><TD style="WIDTH: 200px; HEIGHT: 15px" vAlign=top><asp:DropDownList id="ddlPostingType_Posting" runat="server" Width="150px" SkinID="Unicodeddl" ToolTip="छनौट तरिका" __designer:wfdid="w55">
                                                    </asp:DropDownList></TD><TD style="WIDTH: 115px; HEIGHT: 15px" vAlign=top><asp:Label id="Label67" runat="server" Width="95px" Text="नियुक्ति मिति" SkinID="Unicodelbl" __designer:wfdid="w56"></asp:Label> </TD><TD style="WIDTH: 250px; HEIGHT: 15px" vAlign=top><asp:TextBox id="txtDate_UDTPosting" runat="server" Width="90px" SkinID="Unicodetxt" ToolTip="नियुक्ति मिति" MaxLength="10" __designer:wfdid="w57"></asp:TextBox> <asp:Label id="Label112" runat="server" Width="15px" Text="*" ForeColor="Red" __designer:wfdid="w58"></asp:Label> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender12" runat="server" TargetControlID="txtDate_UDTPosting" MaskType="Date" Mask="9999/99/99" AutoComplete="False" __designer:wfdid="w59">
                                                    </ajaxToolkit:MaskedEditExtender> </TD><TD style="WIDTH: 95px; HEIGHT: 15px" vAlign=top><asp:Label id="Label69" runat="server" Width="83px" Text="निर्णय मिति" SkinID="Unicodelbl" __designer:wfdid="w60"></asp:Label></TD><TD style="HEIGHT: 15px" vAlign=top><asp:TextBox id="txtDecisionDate_UDTPosting" runat="server" Width="103px" SkinID="Unicodetxt" ToolTip="निर्णय मिति" MaxLength="10" __designer:wfdid="w61"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender13" runat="server" TargetControlID="txtDecisionDate_UDTPosting" MaskType="Date" Mask="9999/99/99" AutoComplete="False" __designer:wfdid="w62">
                                                    </ajaxToolkit:MaskedEditExtender> </TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 15px" vAlign=top><asp:Label id="Label70" runat="server" Text="रवाना मिति" SkinID="Unicodelbl" __designer:wfdid="w63"></asp:Label></TD><TD style="WIDTH: 200px; HEIGHT: 15px" vAlign=top><asp:TextBox id="txtLeaveDate_UDTPosting" runat="server" Width="100px" SkinID="Unicodetxt" ToolTip="रवाना मिति" MaxLength="10" __designer:wfdid="w64"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender14" runat="server" TargetControlID="txtLeaveDate_UDTPosting" MaskType="Date" Mask="9999/99/99" AutoComplete="False" __designer:wfdid="w65">
                                                    </ajaxToolkit:MaskedEditExtender> </TD><TD style="WIDTH: 115px; HEIGHT: 15px" vAlign=top><asp:Label id="Label71" runat="server" Width="99px" Text="उपस्थित मिति" SkinID="Unicodelbl" __designer:wfdid="w66"></asp:Label></TD><TD style="WIDTH: 250px; HEIGHT: 15px" vAlign=top><asp:TextBox id="txtJoinDate_UDTPosting" runat="server" Width="86px" SkinID="Unicodetxt" ToolTip="उपस्थित मिति" MaxLength="10" __designer:wfdid="w67"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender15" runat="server" TargetControlID="txtJoinDate_UDTPosting" MaskType="Date" Mask="9999/99/99" AutoComplete="False" __designer:wfdid="w68">
                                                    </ajaxToolkit:MaskedEditExtender> </TD><TD style="WIDTH: 95px; HEIGHT: 15px" vAlign=top><asp:Label id="Label11" runat="server" Width="96px" Text="मिति सम्म" SkinID="Unicodelbl" __designer:wfdid="w69"></asp:Label></TD><TD style="HEIGHT: 15px" vAlign=top><asp:TextBox id="txtToDate" runat="server" Width="103px" SkinID="Unicodetxt" MaxLength="10" __designer:wfdid="w70"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender26" runat="server" TargetControlID="txtToDate" MaskType="Date" Mask="9999/99/99" AutoComplete="False" __designer:wfdid="w71"></ajaxToolkit:MaskedEditExtender> </TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 15px" vAlign=top><asp:Label id="Label73" runat="server" Text="तलब" SkinID="Unicodelbl" __designer:wfdid="w72"></asp:Label></TD><TD style="WIDTH: 200px; HEIGHT: 15px" vAlign=top><asp:TextBox id="txtSalary" runat="server" Width="90px" SkinID="Unicodetxt" MaxLength="10" __designer:wfdid="w73"></asp:TextBox> <ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender3" runat="server" TargetControlID="txtSalary" FilterType="Numbers" __designer:wfdid="w74">
                                                    </ajaxToolkit:FilteredTextBoxExtender> </TD><TD style="WIDTH: 115px; HEIGHT: 15px" vAlign=top><asp:Label id="Label123" runat="server" Text="भत्ता" SkinID="Unicodelbl" __designer:wfdid="w75"></asp:Label></TD><TD style="WIDTH: 250px; HEIGHT: 15px" vAlign=top><asp:TextBox id="txtAllowance" runat="server" Width="90px" SkinID="Unicodetxt" MaxLength="10" __designer:wfdid="w76"></asp:TextBox> <ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender4" runat="server" TargetControlID="txtAllowance" FilterType="Numbers" __designer:wfdid="w77">
                                                    </ajaxToolkit:FilteredTextBoxExtender> </TD><TD style="WIDTH: 95px; HEIGHT: 15px" vAlign=top><asp:Label id="Label124" runat="server" Width="98px" Text="किताब दर्ता नं" SkinID="Unicodelbl" __designer:wfdid="w78"></asp:Label></TD><TD style="HEIGHT: 15px" vAlign=top><asp:TextBox id="txtKitaabDartaNo" runat="server" Width="119px" SkinID="Unicodetxt" MaxLength="15" __designer:wfdid="w79"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 21px" vAlign=top><asp:Label id="Label74" runat="server" Text="कैफियत" SkinID="Unicodelbl" __designer:wfdid="w80"></asp:Label></TD><TD style="WIDTH: 200px; HEIGHT: 21px" vAlign=top><asp:TextBox id="txtPostingRemarks" runat="server" Width="223px" Height="85px" SkinID="Unicodetxt" __designer:wfdid="w81" TextMode="MultiLine"></asp:TextBox></TD><TD style="WIDTH: 115px; HEIGHT: 21px" vAlign=top>&nbsp;</TD><TD style="HEIGHT: 21px" vAlign=top colSpan=3>&nbsp;</TD></TR></TBODY></TABLE>
</contenttemplate>
                                        </asp:UpdatePanel>
                                        <table width="900">
                                            <tr>
                                                <td style="width: 100px">
                                                    <asp:Label ID="Label125" runat="server" SkinID="Unicodelbl" Text="फाइल" Width="30px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:FileUpload ID="uploadPostingDocuments" runat="server" Width="296px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100px">
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnPostingPlus" runat="server" OnClick="btnPostingPlus_Click" OnClientClick="javascript:return validateUpanelFields('_Posting','Posting');"
                                                        SkinID="Add" Text="Add" Width="50px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <hr />
                                                    <asp:Panel ID="Panel2" runat="server" Height="150px" ScrollBars="Auto" Width="900px">
                                                        <br />
                                                        <asp:GridView ID="grdEmpPostings" runat="server" AutoGenerateColumns="False" CellPadding="0"
                                                            ForeColor="#333333" GridLines="None" OnRowDataBound="grdEmpPostings_RowDataBound"
                                                            OnSelectedIndexChanged="grdEmpPostings_SelectedIndexChanged" SkinID="Unicodegrd"
                                                            Width="1700px">
                                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                            <EditRowStyle BackColor="#999999" />
                                                            <Columns>
                                                                <asp:BoundField DataField="EMPID" HeaderText="Emp ID" />
                                                                <asp:BoundField DataField="OrgID" HeaderText="कार्यालय" />
                                                                <asp:BoundField DataField="OrgName" HeaderText="कार्यालय">
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="DESID" HeaderText="पद" />
                                                                <asp:BoundField DataField="DESNAME" HeaderText="पद">
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="POSTID" HeaderText="पद" />
                                                                <asp:BoundField DataField="CREATEDDATE" HeaderText="Created Date" />
                                                                <asp:BoundField DataField="POSTNAME" HeaderText="पद">
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="POSTINGTYPEID" HeaderText="छनौट तरिका" />
                                                                <asp:BoundField DataField="POSTINGTYPENAME" HeaderText="छनौट तरिका">
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="FROMDATE" HeaderText="नियुक्ति मिति">
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="TODATE" HeaderText="नियुक्ति सम्म" />
                                                                <asp:BoundField DataField="DECISIONDATE" HeaderText="निर्णय मिति">
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="LEAVEDATE" HeaderText="रवाना मिति">
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="JOININGDATE" HeaderText="उपस्थित मिति">
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="EMPSALARY" HeaderText="तलब">
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="EMPALLOWANCE" HeaderText="भत्ता">
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="EMPKITAABDARTANO" HeaderText="किताब दर्ता नं">
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="EMPPOSTINGREMARKS" HeaderText="कैफियत">
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="ACTION" HeaderText="Action" />
                                                                <asp:TemplateField HeaderText="फाइल">
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkPostingAttDisplay" runat="server" OnClick="lnkPostingAttDisplay_Click"
                                                                            Text='<%#Eval("PostingAttachmentContent") %>'></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="ToDate" HeaderText="मिति सम्म" />
                                                                <asp:CommandField ShowSelectButton="True" />
                                                            </Columns>
                                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                    <HeaderTemplate>
                                        नियुक्ति
                                    </HeaderTemplate>
                                </ajaxToolkit:TabPanel>
                                <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
                                    <ContentTemplate>
                                        <br />
                                        <asp:UpdatePanel id="UpdatePanel17" runat="server">
                                            <contenttemplate>
                                        <table width="900">
                                            <tr>
                                                <td style="width: 44px" valign="top">
                                                    <asp:Label ID="Label119" runat="server" SkinID="Unicodelbl" Text="शिर्षक" Width="42px"></asp:Label>
                                                </td>
                                                <td style="width: 330px" valign="top">
                                                    <asp:TextBox ID="txtAttachment_Title" runat="server" MaxLength="100" SkinID="Unicodetxt"
                                                        ToolTip="Title of File to Attach"></asp:TextBox>
                                                </td>
                                                <td style="width: 55px" valign="top">
                                                    <asp:Label ID="Label120" runat="server" SkinID="Unicodelbl" Text="मिति" ToolTip="Attachment Date "
                                                        Width="35px"></asp:Label>
                                                </td>
                                                <td valign="top">
                                                    <asp:TextBox ID="txtAttachment_Date" runat="server" SkinID="Unicodetxt" ToolTip="Date of File Attachment"
                                                        Width="73px"></asp:TextBox>
                                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender21" runat="server" AutoComplete="False"
                                                        CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                        CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                        CultureTimePlaceholder="" Enabled="True" Mask="9999/99/99" MaskType="Date" TargetControlID="txtAttachment_Date">
                                                    </ajaxToolkit:MaskedEditExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 44px" valign="top">
                                                    <asp:Label ID="Label121" runat="server" SkinID="Unicodelbl" Text="फाइल"></asp:Label>
                                                </td>
                                                <td style="width: 330px" valign="top">
                                                    <asp:FileUpload ID="UpLoadAttachment_File" runat="server" Width="326px" />&nbsp;&nbsp;
                                                    <asp:TextBox ID="txtFileName" runat="server"></asp:TextBox>
                                                    <asp:Button ID="btnAttachmentUpload" runat="server" OnClick="btnAttachmentUpload_Click"
                                                        SkinID="Normal" Text="Upload" />
                                                    &nbsp;
                                                </td>
                                                <td style="width: 55px" valign="top">
                                                    <asp:Label ID="Label122" runat="server" SkinID="Unicodelbl" Text="कैफिएत" Width="54px"></asp:Label>
                                                </td>
                                                <td valign="top">
                                                    <asp:TextBox ID="txtAttachment_Description" runat="server" Height="77px" MaxLength="150"
                                                        SkinID="Unicodetxt" TextMode="MultiLine" ToolTip="Description of Attachment"
                                                        Width="218px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 44px" valign="top">
                                                </td>
                                                <td style="width: 330px" valign="top">
                                                </td>
                                                <td style="width: 55px" valign="top">
                                                </td>
                                                <td valign="top">
                                                    <asp:Button ID="btnAttachment_Add" runat="server" OnClick="btnAttachment_Add_Click"
                                                        SkinID="Normal" Text="Add" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <hr />
                                                    <asp:Panel ID="PnlAttachment" runat="server" Height="150px" Width="800px">
                                                        <asp:GridView ID="grdAttachment" runat="server" AutoGenerateColumns="False"
                                                        CellPadding="0" ForeColor="#333333" GridLines="None" OnRowCreated="grdAttachment_RowCreated" OnSelectedIndexChanged="grdAttachment_SelectedIndexChanged"
                                                        SkinID="Unicodegrd" Width="800px">
                                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                        <Columns>
                                                            <asp:BoundField DataField="EmpID" HeaderText="EmpID" />
                                                            <asp:BoundField DataField="AttSeq" HeaderText="क्र.सं">
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="AttachmentTitle" HeaderText="शिर्षक">
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="फाइल">
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnlAttDisplay" runat="server" OnClick="lnlAttDisplay_Click"
                                                                        Text='<%#Eval("AttachmentContent") %>'></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="AttachmentDate" HeaderText="मिति">
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="AttachmentDesc" HeaderText="कैफिएत">
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="EntryBy" HeaderText="EntryBy" />
                                                            <asp:BoundField DataField="Action" HeaderText="Action" />
                                                            <asp:CommandField ShowSelectButton="True" />
                                                            <asp:CommandField ShowDeleteButton="True" />
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
                                        </table></contenttemplate>
                                        </asp:UpdatePanel>
                                        <br />
                                    </ContentTemplate>
                                    <HeaderTemplate>
                                        संलग्न कागजात
                                    </HeaderTemplate>
                                </ajaxToolkit:TabPanel>
                                <ajaxToolkit:TabPanel ID="TabPanel11" runat="server" HeaderText="TabPanel11">
                                    <ContentTemplate>
                                        <br />
                                        <asp:UpdatePanel id="UpdatePanel14" runat="server">
                                            <contenttemplate>
<TABLE width=900><TBODY><TR><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Label126" runat="server" Width="114px" Text="नियुक्ति कार्यालय" SkinID="Unicodelbl" __designer:wfdid="w115"></asp:Label> </TD><TD style="WIDTH: 100px" vAlign=top><asp:DropDownList id="ddlDeputationCurrentOrganization" runat="server" Width="242px" SkinID="Unicodeddl" AutoPostBack="True" __designer:wfdid="w116" OnSelectedIndexChanged="ddlDeputationCurrentOrganization_SelectedIndexChanged"></asp:DropDownList> <asp:TextBox id="txtDeputaionCurrentOrg" runat="server" Width="235px" Height="25px" SkinID="Unicodetxt" Visible="False" ForeColor="Black" __designer:wfdid="w117" BackColor="Gainsboro" ReadOnly="True"></asp:TextBox></TD><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Label127" runat="server" Text="पद" SkinID="Unicodelbl" __designer:wfdid="w118"></asp:Label> <BR /></TD><TD style="WIDTH: 100px" vAlign=top><asp:DropDownList id="ddlDeputaionCurrentPost" runat="server" Width="224px" __designer:wfdid="w119"></asp:DropDownList><BR /><asp:TextBox id="txtDeputationCurrentPost" runat="server" Width="216px" Height="25px" SkinID="Unicodetxt" Visible="False" __designer:wfdid="w120" BackColor="Gainsboro" ReadOnly="True"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Label128" runat="server" Width="93px" Text="निवेदन मिति" SkinID="Unicodelbl" __designer:wfdid="w121"></asp:Label> </TD><TD style="WIDTH: 100px" vAlign=top><asp:TextBox id="txtDeputaionApplicationDate" runat="server" Width="73px" SkinID="Unicodetxt" __designer:wfdid="w122"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender22" runat="server" TargetControlID="txtDeputaionApplicationDate" MaskType="Date" Mask="9999/99/99" AutoComplete="False" __designer:wfdid="w123"></ajaxToolkit:MaskedEditExtender> </TD><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Label129" runat="server" Width="87px" Text="निर्णय मिति" SkinID="Unicodelbl" __designer:wfdid="w124"></asp:Label> </TD><TD style="WIDTH: 100px" vAlign=top><asp:TextBox id="txtDeputaionDecisionDate" runat="server" Width="73px" __designer:wfdid="w125"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender23" runat="server" TargetControlID="txtDeputaionDecisionDate" MaskType="Date" Mask="9999/99/99" AutoComplete="False" __designer:wfdid="w126"></ajaxToolkit:MaskedEditExtender> </TD></TR><TR><TD style="WIDTH: 100px" vAlign=top><asp:Label id="lblDeputationOrganization" runat="server" Width="99px" Text="काज कार्यालय" SkinID="Unicodelbl" __designer:wfdid="w127"></asp:Label> </TD><TD style="WIDTH: 100px" vAlign=top><asp:DropDownList id="ddlDeputationOrganization" runat="server" Width="242px" SkinID="Unicodeddl" __designer:wfdid="w128">
                                                    </asp:DropDownList> </TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Label131" runat="server" Text="देखि" SkinID="Unicodelbl" __designer:wfdid="w129"></asp:Label> </TD><TD style="WIDTH: 100px" vAlign=top><asp:TextBox id="txtDeputationFromDate" runat="server" Width="73px" SkinID="Unicodetxt" __designer:wfdid="w130"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender24" runat="server" TargetControlID="txtDeputationFromDate" MaskType="Date" Mask="9999/99/99" AutoComplete="False" __designer:wfdid="w131"></ajaxToolkit:MaskedEditExtender> </TD><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Label132" runat="server" Text="सम्म" SkinID="Unicodelbl" __designer:wfdid="w132"></asp:Label> </TD><TD style="WIDTH: 100px" vAlign=top><asp:TextBox id="txtDeputationToDate" runat="server" Width="73px" SkinID="Unicodetxt" __designer:wfdid="w133"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender25" runat="server" TargetControlID="txtDeputationToDate" MaskType="Date" Mask="9999/99/99" AutoComplete="False" __designer:wfdid="w134"></ajaxToolkit:MaskedEditExtender> </TD></TR><TR><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Label133" runat="server" Width="72px" Text="जिम्मेवारी" SkinID="Unicodelbl" __designer:wfdid="w135"></asp:Label> </TD><TD style="WIDTH: 100px" vAlign=top><asp:TextBox id="txtDeputaionResponsibility" runat="server" Width="233px" Height="77px" SkinID="Unicodetxt" __designer:wfdid="w136" TextMode="MultiLine"></asp:TextBox> </TD><TD style="WIDTH: 100px" vAlign=top>&nbsp;</TD><TD style="WIDTH: 100px" vAlign=top>&nbsp; </TD></TR><TR><TD colSpan=4></TD></TR></TBODY></TABLE>
</contenttemplate>
                                        </asp:UpdatePanel>
                                        <table width="900">
                                            <tr>
                                                <td style="width: 100px">
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                                    <asp:Button ID="btnAddDeputaion" runat="server" OnClick="btnAddDeputaion_Click"
                                                        SkinID="Normal" Text="Add" /></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100px">
                                                    <table width="900">
                                                        <tr>
                                                            <td colspan="4">
                                                                <hr />
                                                                <asp:UpdatePanel id="UpdatePanel16" runat="server">
                                                                    <contenttemplate>
<asp:Panel id="Panel12" runat="server" Width="900px" Height="150px" __designer:wfdid="w139" ScrollBars="Auto">&nbsp;<asp:GridView id="grdEmployeeDeputaion" runat="server" Width="1200px" SkinID="Unicodegrd" ForeColor="#333333" __designer:wfdid="w113" OnSelectedIndexChanged="grdEmployeeDeputaion_SelectedIndexChanged" GridLines="None" AutoGenerateColumns="False" CellPadding="0" OnRowCreated="grdEmployeeDeputaion_RowCreated">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="EmpID" HeaderText="EmpId"></asp:BoundField>
<asp:BoundField DataField="OrgID" HeaderText="OrgID"></asp:BoundField>
<asp:BoundField DataField="OrgName" HeaderText="नियुक्ति कार्यालय">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="DesID" HeaderText="DesID"></asp:BoundField>
<asp:BoundField DataField="DepOrgName" HeaderText="काज कार्यालय">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="DesName" HeaderText="पद">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="ApplicationDate" HeaderText="निवेदन मिति">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="DecisionDate" HeaderText="निर्णय मिति">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="DepOrgID" HeaderText="DepOrgID"></asp:BoundField>
<asp:BoundField DataField="LeaveDate" HeaderText="देखि">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="LeaveDate" HeaderText="सम्म">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="Responsibilities" HeaderText="जिम्मेवारी">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="Active" HeaderText="Active"></asp:BoundField>
<asp:BoundField DataField="Action" HeaderText="Action"></asp:BoundField>
<asp:CommandField ShowSelectButton="True">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
</asp:CommandField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> </asp:Panel> 
</contenttemplate>
                                                                </asp:UpdatePanel>&nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                    </ContentTemplate>
                                    <HeaderTemplate>
                                        काज
                                    </HeaderTemplate>
                                </ajaxToolkit:TabPanel>
                                <ajaxToolkit:TabPanel ID="TabPanel13" runat="server" HeaderText="TabPanel13">
                                    <ContentTemplate>
                                        <br />
                                        <asp:UpdatePanel id="UpdatePanel20" runat="server">
                                            <contenttemplate>
<TABLE width=900><TBODY><TR><TD style="WIDTH: 100px" vAlign=top><asp:Label id="lbl11" runat="server" Width="108px" Text="मनोनयन मिति" SkinID="Unicodelbl" __designer:wfdid="w105"></asp:Label></TD><TD style="WIDTH: 100px" vAlign=top><asp:TextBox id="txtManonanDate" runat="server" Width="100px" SkinID="Unicodetxt" __designer:wfdid="w106"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExt26" runat="server" TargetControlID="txtManonanDate" MaskType="Date" Mask="9999/99/99" AutoComplete="False" __designer:wfdid="w107" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True">
                                                    </ajaxToolkit:MaskedEditExtender></TD><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Label134" runat="server" Width="82px" Text="ञवधि देखि" SkinID="Unicodelbl" __designer:wfdid="w108"></asp:Label></TD><TD style="WIDTH: 100px" vAlign=top><asp:TextBox id="txtManonaynFromDate" runat="server" Width="100px" SkinID="Unicodetxt" __designer:wfdid="w109"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender27" runat="server" TargetControlID="txtManonaynFromDate" MaskType="Date" Mask="9999/99/99" AutoComplete="False" __designer:wfdid="w110" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True">
                                                    </ajaxToolkit:MaskedEditExtender></TD><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Label135" runat="server" Width="82px" Text="ञवधि सम्म" SkinID="Unicodelbl" __designer:wfdid="w111"></asp:Label></TD><TD style="WIDTH: 100px" vAlign=top><asp:TextBox id="txtManonayanToDate" runat="server" Width="100px" SkinID="Unicodetxt" __designer:wfdid="w112"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender28" runat="server" TargetControlID="txtManonayanToDate" MaskType="Date" Mask="9999/99/99" AutoComplete="False" __designer:wfdid="w113" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True">
                                                    </ajaxToolkit:MaskedEditExtender></TD></TR><TR><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Label130" runat="server" Text="शिर्षक" SkinID="Unicodelbl" __designer:wfdid="w114"></asp:Label></TD><TD style="WIDTH: 100px"><asp:TextBox id="txtManonayanDescription" runat="server" Width="227px" Height="70px" SkinID="Unicodetxt" __designer:wfdid="w115" TextMode="MultiLine"></asp:TextBox></TD><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Label136" runat="server" Text="कैफियत" SkinID="Unicodelbl" __designer:wfdid="w116"></asp:Label></TD><TD style="WIDTH: 100px" vAlign=top><asp:TextBox id="txtManoyanPurpose" runat="server" Width="228px" Height="70px" SkinID="Unicodetxt" __designer:wfdid="w117" TextMode="MultiLine"></asp:TextBox></TD><TD style="WIDTH: 100px" vAlign=top><asp:Button id="btnAddManonayan" onclick="btnAddManonayan_Click" runat="server" Text="Add" SkinID="Normal" __designer:wfdid="w118" OnClientClick="javascript:return validateUpanelFields('_Manonayan','Manonayan');"></asp:Button></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD colSpan=6><asp:Panel id="Panel13" runat="server" Width="900px" Height="150px" __designer:wfdid="w119" ScrollBars="Auto"><HR />
<asp:GridView id="grdManonayan" runat="server" Width="800px" SkinID="Unicodegrd" ForeColor="#333333" __designer:wfdid="w120" OnRowDeleting="grdManonayan_RowDeleting" OnRowDataBound="grdManonayan_RowDataBound" CellPadding="0" AutoGenerateColumns="False" GridLines="None" OnSelectedIndexChanged="grdManonayan_SelectedIndexChanged">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="EmpID" HeaderText="EmpID"></asp:BoundField>
<asp:BoundField DataField="ManonayanDate" HeaderText="मनोनयन मिति"></asp:BoundField>
<asp:BoundField DataField="ManonayanDescription" HeaderText="शिर्षक"></asp:BoundField>
<asp:BoundField DataField="ManonayanFromDate" HeaderText="ञवधि देखि"></asp:BoundField>
<asp:BoundField DataField="ManonayanToDate" HeaderText="ञवधि सम्म"></asp:BoundField>
<asp:BoundField DataField="ManonayanPurpose" HeaderText="कैफयत"></asp:BoundField>
<asp:BoundField DataField="ManonayanApprovedYesNo" HeaderText="VerifiedYN"></asp:BoundField>
<asp:BoundField DataField="Action" HeaderText="Action"></asp:BoundField>
<asp:CommandField ShowSelectButton="True"></asp:CommandField>
<asp:CommandField Visible="False" ShowDeleteButton="True"></asp:CommandField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView></asp:Panel></TD></TR></TBODY></TABLE>
</contenttemplate>
                                        </asp:UpdatePanel>
                                    </ContentTemplate>
                                    <HeaderTemplate>
                                        मनोनयन<br />
                                    </HeaderTemplate>
                                </ajaxToolkit:TabPanel>

                            </ajaxToolkit:TabContainer>
                        </td>
                    </tr>
                </table>
</td>
        </tr>
        <tr>
            <td align="right" colspan="6" valign="middle" style="height: 8px">
                <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click"
                    Text="Submit" SkinID="Normal" />
                <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" SkinID="Cancel" />&nbsp;</td>
        </tr>
    </table>
    <asp:Button ID="hiddenTargetControlForPersonModalPopup" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="programmaticPersonModalPopup" runat="server"
        BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior1"
        DropShadow="True" PopupControlID="programmaticPersonPopup" PopupDragHandleControlID="programmaticPersonPopupDragHandle"
        RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForPersonModalPopup">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="programmaticPersonPopup" runat="server" CssClass="modalPopupPerson"
        Height="400px" Style="display: none;padding: 10px">
        <asp:Panel ID="programmaticPersonPopupDragHandle" runat="Server" Style="cursor: move;
            background-color: #DDDDDD; border: solid 1px Gray; color: Black; text-align: center;">
            नातेदार खोज्नुहोस</asp:Panel>
        <contenttemplate></contenttemplate>
        <asp:UpdatePanel id="UpdatePanelPersonSearch" runat="server">
            <contenttemplate>
<BR /><TABLE style="WIDTH: 700px; TEXT-ALIGN: left"><TBODY><TR><TD style="WIDTH: 120px" vAlign=top><asp:Label id="Label14" runat="server" Width="75px" Text="पहिलो नाम" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 140px" vAlign=top><asp:TextBox id="txtSFirstName" runat="server" Width="100px" SkinID="Unicodetxt" MaxLength="30"></asp:TextBox></TD><TD style="WIDTH: 85px" vAlign=top><asp:Label id="Label16" runat="server" Width="80px" Text="बिचको नाम" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 140px" vAlign=top><asp:TextBox id="txtSMName" runat="server" Width="100px" SkinID="Unicodetxt" MaxLength="30"></asp:TextBox></TD><TD style="WIDTH: 115px" vAlign=top><asp:Label id="Label17" runat="server" Text="थर" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:TextBox id="txtSLastName" runat="server" Width="100px" SkinID="Unicodetxt" MaxLength="30"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 120px" vAlign=top><asp:Label id="Label78" runat="server" Text="लिंग" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 140px" vAlign=top><asp:DropDownList id="ddlSGender" runat="server" Width="105px" SkinID="Unicodeddl"><asp:ListItem Value="SG">छान्नुहोस</asp:ListItem>
<asp:ListItem Value="M">पुरुष</asp:ListItem>
<asp:ListItem Value="F">महिला</asp:ListItem>
<asp:ListItem Value="O">अन्य</asp:ListItem>
</asp:DropDownList></TD><TD style="WIDTH: 85px" vAlign=top><asp:Label id="Label20" runat="server" Width="75px" Text="जन्म मिति" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 140px" vAlign=top><asp:TextBox id="txtSDOB_DT" runat="server" Width="73px" SkinID="Unicodetxt"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender20" runat="server" TargetControlID="txtSDOB_DT" MaskType="Date" Mask="9999/99/99" AutoComplete="False"></ajaxToolkit:MaskedEditExtender></TD><TD style="WIDTH: 115px" vAlign=top><asp:Label id="Label25" runat="server" Width="110px" Text="बैबाहिक सम्बन्ध" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:DropDownList id="ddlSMarStatus" runat="server" Width="105px" SkinID="Unicodeddl"><asp:ListItem Value="SMS">छान्नुहोस</asp:ListItem>
<asp:ListItem Value="S">अबिबाहित</asp:ListItem>
<asp:ListItem Value="M">बिबाहित</asp:ListItem>
<asp:ListItem Value="W">बिधवा/बिदुर</asp:ListItem>
<asp:ListItem Value="D">छोडपत्र</asp:ListItem>
<asp:ListItem Value="O">अन्य</asp:ListItem>
</asp:DropDownList></TD></TR><TR><TD style="WIDTH: 120px" vAlign=top><asp:Label id="Label77" runat="server" Width="120px" Text="घर भएको जिल्ला" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 140px" vAlign=top><asp:DropDownList id="ddlSHomeDistrict" runat="server" Width="105px" SkinID="PCSddl"></asp:DropDownList></TD><TD style="WIDTH: 85px" vAlign=top></TD><TD style="WIDTH: 140px" vAlign=top></TD><TD style="WIDTH: 115px" vAlign=top></TD><TD vAlign=top></TD></TR><TR><TD style="HEIGHT: 23px" vAlign=top colSpan=2><asp:Button id="btnPersonSearch" onclick="btnPersonSearch_Click" runat="server" Text="Search" SkinID="Normal"></asp:Button> <asp:Button id="btnCancelPersonSearch" onclick="btnCancelPersonSearch_Click" runat="server" Text="Cancel" SkinID="Cancel"></asp:Button> </TD><TD style="WIDTH: 85px; HEIGHT: 23px" vAlign=top></TD><TD style="WIDTH: 140px; HEIGHT: 23px" vAlign=top></TD><TD style="HEIGHT: 23px" vAlign=top align=right colSpan=2>&nbsp;</TD></TR><TR><TD style="HEIGHT: 23px" vAlign=top colSpan=6><asp:Panel id="pnlPersonSearch" runat="server" Width="680" Height="150px" ScrollBars="Auto"><asp:GridView id="grdPersonSearch" runat="server" Width="650px" SkinID="Unicodegrd" ForeColor="#333333" OnSelectedIndexChanged="grdPersonSearch_SelectedIndexChanged" AutoGenerateColumns="False" GridLines="None" OnRowDataBound="grdPersonSearch_RowDataBound" CellPadding="0" CaptionAlign="Top">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField HeaderText="क्र.सं.">
<ItemStyle Width="25px" Font-Names="PCS NEPALI"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="PERSONID" HeaderText="आईडी"></asp:BoundField>
<asp:BoundField DataField="RDFULLNAME" HeaderText="पुरा नाम थर"></asp:BoundField>
<asp:BoundField DataField="RDGENDER" HeaderText="लिंग"></asp:BoundField>
<asp:BoundField DataField="DOB" HeaderText="जन्म मिति"></asp:BoundField>
<asp:BoundField DataField="RDMARITALSTATUS" HeaderText="बैबाहिक सम्बन्ध"></asp:BoundField>
<asp:BoundField DataField="BIRTHDISTRICT" HeaderText="घर भएको जिल्ला"></asp:BoundField>
<asp:CommandField ShowSelectButton="True"></asp:CommandField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView></asp:Panel></TD></TR></TBODY></TABLE><asp:Button id="btnOKPersonSearch" onclick="OkPersonButton_Click" runat="server" Width="58px" Text="OK" SkinID="Normal"></asp:Button><BR />&nbsp;
</contenttemplate>
        </asp:UpdatePanel>
        &nbsp;&nbsp;&nbsp;&nbsp;<br />
    </asp:Panel>
 </asp:Content>