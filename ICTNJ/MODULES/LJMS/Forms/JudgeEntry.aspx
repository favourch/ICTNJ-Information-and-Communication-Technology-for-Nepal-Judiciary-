<%@ Page Language="C#" MasterPageFile="~/MODULES/LJMS/LJMSMasterPage.master" AutoEventWireup="true" CodeFile="JudgeEntry.aspx.cs" Inherits="MODULES_LJMS_Forms_JudgeEntry" Title="LJMS | Judge Entry" %>

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
            <contenttemplate>
        <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label>
            </contenttemplate>
        </asp:UpdatePanel>
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
            Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    <br />
                <asp:Label ID="lblPersonnelInfo" runat="server" Font-Bold="True" SkinID="UnicodeHeadlbl"
                    Text="वैयक्तिक विवरण"></asp:Label><br />
    <br />
    <table cellspacing="5" style="width: 1000px">
        <tr>
            <td valign="top">
                <asp:Label ID="Label30" runat="server" Height="22px" SkinID="Unicodelbl" Text="संकेत नं"></asp:Label></td>
            <td valign="top">
                <asp:TextBox ID="txtSymbolNo" runat="server" MaxLength="15" SkinID="Unicodetxt" ToolTip="संकेत नम्बर"
                    Width="130px"></asp:TextBox></td>
            <td valign="top">
                <asp:Label ID="Label10" runat="server" Text="कार्यालय नं"></asp:Label></td>
            <td valign="top">
                <asp:TextBox ID="txtEmpOrgNo" runat="server" Width="130px"></asp:TextBox></td>
            <td valign="top">
                <asp:TextBox ID="txtEmployeeID" runat="server" SkinID="Unicodetxt" Visible="False"
                    Width="108px"></asp:TextBox></td>
            <td valign="top">
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="Label1" runat="server" Height="22px" SkinID="Unicodelbl" Text="पहिलो नाम"
                    Width="81px"></asp:Label></td>
            <td valign="top">
                <asp:TextBox ID="txtFName_Rqd" runat="server" MaxLength="35" SkinID="Unicodetxt"
                    ToolTip="पहिलो नाम" Width="130px"></asp:TextBox></td>
            <td valign="top">
                <asp:Label ID="Label2" runat="server" Height="22px" SkinID="Unicodelbl" Text="बिचको नाम"></asp:Label></td>
            <td valign="top">
                <asp:TextBox ID="txtMName" runat="server" MaxLength="15" SkinID="Unicodetxt" Width="130px"></asp:TextBox></td>
            <td valign="top">
                <asp:Label ID="Label3" runat="server" Height="22px" SkinID="Unicodelbl" Text="थर"
                    Width="110px"></asp:Label></td>
            <td valign="top">
                <asp:TextBox ID="txtSurName_Rqd" runat="server" MaxLength="35" SkinID="Unicodetxt"
                    ToolTip="थर" Width="130px"></asp:TextBox></td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="Label4" runat="server" Height="22px" SkinID="Unicodelbl" Text="जन्म मिति"
                    Width="90px"></asp:Label></td>
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
                <asp:Label ID="Label6" runat="server" Height="22px" SkinID="Unicodelbl" Text="बैबाहिक सम्बन्ध"
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
            <td valign="top">
                <asp:Label ID="Label7" runat="server" Height="22px" SkinID="Unicodelbl" Text="देश"></asp:Label></td>
            <td valign="top">
                <asp:DropDownList ID="ddlCountry" runat="server" SkinID="Unicodeddl" Width="135px">
                </asp:DropDownList></td>
            <td valign="top">
                <asp:Label ID="Label8" runat="server" Height="22px" SkinID="Unicodelbl" Text="घर भएको जिल्ला"
                    Width="125px"></asp:Label></td>
            <td valign="top">
                <asp:DropDownList ID="ddlBirthDistrict" runat="server" SkinID="Unicodeddl" Width="135px">
                </asp:DropDownList></td>
            <td valign="top">
                <asp:Label ID="Label9" runat="server" Height="22px" SkinID="Unicodelbl" Text="धर्म"
                    Width="110px"></asp:Label></td>
            <td valign="top">
                <asp:DropDownList ID="ddlReligion" runat="server" SkinID="Unicodeddl" Width="135px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="Label29" runat="server" SkinID="Unicodelbl" Text="हुलिया" Width="77px"></asp:Label></td>
            <td valign="top">
                <asp:TextBox ID="txtIdentityMark" runat="server" MaxLength="30" SkinID="Unicodetxt"
                    Width="130px"></asp:TextBox></td>
            <td valign="top">
            </td>
            <td valign="top">
            </td>
            <td valign="top">
            </td>
            <td valign="top">
            </td>
        </tr>
        <tr>
            <td colspan="6" valign="top">
                <hr />
                <table style="width: 950px">
                    <tr>
                        <td style="width: 950px">
                            <ajaxToolkit:TabContainer ID="tabContainerEmpContact" runat="server" ActiveTabIndex="8"
                                CssClass="ajax_tab_theme" Width="950px">
                                <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                                    <ContentTemplate>
                                        <asp:UpdatePanel id="UpdatePanel15" runat="server">
                                            <contenttemplate>
<TABLE style="WIDTH: 650px"><TBODY><TR><TD vAlign=top colSpan=6><asp:Label id="Label26" runat="server" SkinID="Unicodelbl" Font-Bold="True" Text="स्थायी ठेगाना"></asp:Label> </TD></TR><TR><TD style="WIDTH: 60px" vAlign=top><asp:Label id="Label82" runat="server" Width="50px" Height="19px" SkinID="Unicodelbl" Text="जिल्ला"></asp:Label> </TD><TD style="WIDTH: 170px" vAlign=top><asp:DropDownList id="ddlDistrict" runat="server" Width="150px" SkinID="Unicodeddl" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> </TD><TD style="WIDTH: 105px" vAlign=top><asp:Label id="Label84" runat="server" Width="95px" Height="19px" SkinID="Unicodelbl" Text="गा.बि.स./न.पा."></asp:Label> </TD><TD style="WIDTH: 170px" vAlign=top><asp:DropDownList id="ddlVDC" runat="server" Width="150px" SkinID="Unicodeddl" OnSelectedIndexChanged="ddlVDC_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> </TD><TD style="WIDTH: 60px" vAlign=top><asp:Label id="Label15" runat="server" Width="50px" Height="19px" SkinID="Unicodelbl" Text="वडा नं."></asp:Label> </TD><TD vAlign=top><asp:DropDownList id="ddlWard" runat="server" Width="70px" SkinID="Unicodeddl" AppendDataBoundItems="True"></asp:DropDownList> </TD></TR><TR><TD style="WIDTH: 60px" vAlign=top><asp:Label id="Label83" runat="server" Height="19px" SkinID="Unicodelbl" Text="टोल"></asp:Label> </TD><TD style="WIDTH: 170px" vAlign=top><asp:TextBox id="txtTole" runat="server" Width="150px" SkinID="Unicodetxt" MaxLength="100" TextMode="MultiLine"></asp:TextBox></TD><TD style="WIDTH: 105px" vAlign=top><asp:ImageButton id="imgDelPerAddress" onclick="imgDelPerAddress_Click" runat="server" ImageUrl="~/MODULES/COMMON/Images/bycat1.ico" Visible="False" OnClientClick="return confirm('यो ठेगाना हटाउने हो ?')" AlternateText="Delete This Address"></asp:ImageButton></TD><TD style="WIDTH: 170px" vAlign=top></TD><TD style="WIDTH: 60px" vAlign=top></TD><TD vAlign=top></TD></TR><TR><TD vAlign=top colSpan=6>
<HR />
</TD></TR></TBODY></TABLE><asp:HiddenField id="hdnPerAddress" runat="server"></asp:HiddenField> <asp:HiddenField id="hdnTempAddress" runat="server"></asp:HiddenField> <TABLE style="WIDTH: 650px"><TBODY><TR><TD vAlign=top colSpan=6><asp:Label id="Label85" runat="server" SkinID="Unicodelbl" Font-Bold="True" Text="अस्थायी ठेगाना"></asp:Label></TD></TR><TR><TD style="WIDTH: 60px" vAlign=top><asp:Label id="Label86" runat="server" Width="50px" Height="19px" SkinID="Unicodelbl" Text="जिल्ला"></asp:Label></TD><TD style="WIDTH: 170px" vAlign=top><asp:DropDownList id="ddlDistrictTemp" runat="server" Width="150px" SkinID="Unicodeddl" OnSelectedIndexChanged="ddlDistrictTemp_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD><TD style="WIDTH: 105px" vAlign=top><asp:Label id="Label87" runat="server" Width="95px" Height="19px" SkinID="Unicodelbl" Text="गा.बि.स./न.पा."></asp:Label></TD><TD style="WIDTH: 170px" vAlign=top><asp:DropDownList id="ddlVDCTemp" runat="server" Width="150px" SkinID="Unicodeddl" OnSelectedIndexChanged="ddlVDCTemp_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD><TD style="WIDTH: 60px" vAlign=top><asp:Label id="Label88" runat="server" Width="50px" Height="19px" SkinID="Unicodelbl" Text="वडा नं."></asp:Label></TD><TD vAlign=top><asp:DropDownList id="ddlWardTemp" runat="server" Width="70px" SkinID="Unicodeddl" AppendDataBoundItems="True"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 60px" vAlign=top><asp:Label id="Label89" runat="server" Height="19px" SkinID="Unicodelbl" Text="टोल"></asp:Label></TD><TD style="WIDTH: 170px" vAlign=top><asp:TextBox id="txtToleTemp" runat="server" Width="150px" SkinID="Unicodetxt" MaxLength="100" TextMode="MultiLine"></asp:TextBox></TD><TD style="WIDTH: 105px" vAlign=top><asp:ImageButton id="imgDelTempAddress" onclick="imgDelTempAddress_Click" runat="server" ImageUrl="~/MODULES/COMMON/Images/bycat1.ico" Visible="False" OnClientClick="return confirm('यो ठेगाना हटाउने हो ?')" AlternateText="Delete This Address"></asp:ImageButton></TD><TD style="WIDTH: 170px" vAlign=top></TD><TD style="WIDTH: 60px" vAlign=top></TD><TD vAlign=top></TD></TR><TR><TD vAlign=top colSpan=6>
<HR />
</TD></TR></TBODY></TABLE>
</contenttemplate>
                                        </asp:UpdatePanel>
                                        <asp:UpdatePanel id="UpdatePanel10" runat="server">
                                            <contenttemplate>
<TABLE style="WIDTH: 650px"><TBODY><TR><TD vAlign=top colSpan=4><asp:Label id="Label13" runat="server" Width="105px" Height="19px" Text="फोन" SkinID="Unicodelbl" Font-Bold="True"></asp:Label></TD></TR><TR><TD style="WIDTH: 110px" vAlign=top><asp:Label id="Label18" runat="server" Width="105px" Height="19px" Text="फोनको किसिम" SkinID="Unicodelbl"></asp:Label> </TD><TD style="WIDTH: 150px" vAlign=top><asp:DropDownList id="ddlPhoneType_Phone" runat="server" Width="135px" SkinID="Unicodeddl" ToolTip="फोनको किसिम"><asp:ListItem Value="N">छान्नुहोस</asp:ListItem>
<asp:ListItem Value="M">मोबाईल</asp:ListItem>
<asp:ListItem Value="O">अफिस</asp:ListItem>
<asp:ListItem Value="R">घर</asp:ListItem>
<asp:ListItem Value="OT">अन्य</asp:ListItem>
</asp:DropDownList></TD><TD style="WIDTH: 40px" vAlign=top><asp:Label id="Label19" runat="server" Width="55px" Height="19px" Text="फोन न." SkinID="Unicodelbl"></asp:Label> </TD><TD vAlign=top><asp:TextBox id="txtPhoneNumber_Phone" runat="server" Width="130px" SkinID="Unicodetxt" ToolTip="फोन नं" MaxLength="15"></asp:TextBox> <ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender1" runat="server" TargetControlID="txtPhoneNumber_Phone" FilterType="Numbers"></ajaxToolkit:FilteredTextBoxExtender></TD></TR><TR><TD style="WIDTH: 110px" vAlign=top></TD><TD style="WIDTH: 150px" vAlign=top></TD><TD style="WIDTH: 40px" vAlign=top></TD><TD vAlign=top><asp:Button id="btnPhonePlus" onclick="btnPhonePlus_Click" runat="server" Text="+" SkinID="Add" OnClientClick="javascript:return validateUpanelFields('_Phone',0);"></asp:Button></TD></TR><TR><TD vAlign=top colSpan=4><asp:GridView id="grdPhone" runat="server" SkinID="Unicodegrd" OnSelectedIndexChanged="grdPhone_SelectedIndexChanged" AutoGenerateColumns="False" CellPadding="4" GridLines="None" OnRowDataBound="grdPhone_RowDataBound" OnRowDeleting="grdPhone_RowDeleting" ForeColor="#333333">
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
<TABLE style="WIDTH: 650px"><TBODY><TR><TD vAlign=top colSpan=4><asp:Label id="LabelEmail" runat="server" Width="105px" Height="19px" Text="इमेल" SkinID="Unicodelbl" Font-Bold="True"></asp:Label></TD></TR><TR><TD style="WIDTH: 110px" vAlign=top><asp:Label id="Label23" runat="server" Width="105px" Height="19px" Text="ईमेलको किसिम" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 150px" vAlign=top><asp:DropDownList id="ddlEMailType_EMail" runat="server" Width="135px" SkinID="Unicodeddl" ToolTip="इमेलको किसिम"><asp:ListItem Value="N">छान्नुहोस</asp:ListItem>
<asp:ListItem Value="P">ब्यक्तिगत</asp:ListItem>
<asp:ListItem Value="O">अफिस</asp:ListItem>
<asp:ListItem Value="OT">अन्य</asp:ListItem>
</asp:DropDownList></TD><TD style="WIDTH: 100px" vAlign=top><asp:Label id="Label24" runat="server" Width="90px" Height="19px" Text="ईमेल ठेगाना" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:TextBox id="txtEMail_EMail" runat="server" Width="130px" SkinID="Unicodetxt" ToolTip="इमेल ठेगाना" MaxLength="50"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 110px" vAlign=top></TD><TD style="WIDTH: 150px" vAlign=top></TD><TD style="WIDTH: 100px" vAlign=top></TD><TD vAlign=top><asp:Button id="btnEMailPlus" onclick="btnEMailPlus_Click" runat="server" Text="+" SkinID="Add" OnClientClick="javascript:return ValidateEmailFR();"></asp:Button></TD></TR><TR><TD vAlign=top colSpan=4><asp:GridView id="grdEMail" runat="server" SkinID="Unicodegrd" OnSelectedIndexChanged="grdEMail_SelectedIndexChanged" AutoGenerateColumns="False" CellPadding="4" GridLines="None" OnRowDataBound="grdEMail_RowDataBound" OnRowDeleting="grdEMail_RowDeleting" ForeColor="#333333">
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
                                        <asp:UpdatePanel id="UpdatePanel5" runat="server">
                                            <contenttemplate>
<TABLE style="WIDTH: 900px"><TBODY><TR><TD style="WIDTH: 85px" vAlign=top><asp:Label id="Label37" runat="server" Text="शिर्षक" SkinID="Unicodelbl"></asp:Label> </TD><TD vAlign=top colSpan=3><asp:TextBox id="txtQualSubject_Qual" runat="server" Width="150px" SkinID="Unicodetxt" ToolTip="शिर्षक" MaxLength="50"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 85px" vAlign=top><asp:Label id="Label38" runat="server" Text="डिग्री" SkinID="Unicodelbl"></asp:Label> </TD><TD style="WIDTH: 200px" vAlign=top><asp:DropDownList id="ddlQualDegree_Qual" runat="server" Width="200px" SkinID="Unicodeddl" ToolTip="डिग्री"></asp:DropDownList> </TD><TD style="WIDTH: 85px" vAlign=top><asp:Label id="Label39" runat="server" Text="संस्था" SkinID="Unicodelbl"></asp:Label> </TD><TD vAlign=top><asp:DropDownList id="ddlQualInstitution_Qual" runat="server" Width="300px" SkinID="Unicodeddl" ToolTip="संस्था" AppendDataBoundItems="True"></asp:DropDownList> <asp:ImageButton id="imgAddInstitution" runat="server" Width="20px" ImageUrl="~/MODULES/COMMON/Images/add-icon.png" Height="20px" ToolTip="Add/Update Institution" OnClientClick="wopen('../../COMMON/LookUp/Institution.aspx', 'popup', 768, 600); return false;" ImageAlign="AbsMiddle"></asp:ImageButton> <asp:ImageButton id="imgRefreshInstitution" onclick="imgRefreshInstitution_Click" runat="server" Width="20px" ImageUrl="~/MODULES/COMMON/Images/refresh.png" Height="20px" ToolTip="Refresh Institution" ImageAlign="AbsMiddle"></asp:ImageButton></TD></TR><TR><TD style="WIDTH: 85px; HEIGHT: 22px" vAlign=top><asp:Label id="Label40" runat="server" Width="80px" Text="अवधि देखी" SkinID="Unicodelbl"></asp:Label> </TD><TD style="WIDTH: 200px; HEIGHT: 22px" vAlign=top><asp:TextBox id="txtQualFromDate_UDTQual" runat="server" Width="100px" SkinID="Unicodetxt" ToolTip="अवधि देखी" MaxLength="10"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender2" runat="server" TargetControlID="txtQualFromDate_UDTQual" MaskType="Date" Mask="9999/99/99" AutoComplete="False"></ajaxToolkit:MaskedEditExtender></TD><TD style="WIDTH: 85px; HEIGHT: 22px" vAlign=top><asp:Label id="Label41" runat="server" Width="80px" Text="अवधि सम्म" SkinID="Unicodelbl"></asp:Label> </TD><TD style="HEIGHT: 22px" vAlign=top><asp:TextBox id="txtQualToDate_UDTQual" runat="server" Width="100px" SkinID="Unicodetxt" ToolTip="अवधि सम्म" MaxLength="10"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender3" runat="server" TargetControlID="txtQualToDate_UDTQual" MaskType="Date" Mask="9999/99/99" AutoComplete="False"></ajaxToolkit:MaskedEditExtender>&nbsp; </TD></TR><TR><TD style="WIDTH: 85px; HEIGHT: 26px" vAlign=top><asp:Label id="Label42" runat="server" Text="ग्रेड" SkinID="Unicodelbl"></asp:Label> </TD><TD style="WIDTH: 200px; HEIGHT: 26px" vAlign=top><asp:TextBox id="txtQualGrade" runat="server" Width="50px" SkinID="Unicodetxt" MaxLength="5"></asp:TextBox> </TD><TD style="WIDTH: 85px; HEIGHT: 26px" vAlign=top><asp:Label id="Label43" runat="server" Text="प्रतिशत" SkinID="Unicodelbl"></asp:Label> </TD><TD style="HEIGHT: 26px" vAlign=top><asp:TextBox id="txtQualPercentage" runat="server" Width="50px" SkinID="Unicodetxt" MaxLength="5"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 85px" vAlign=top><asp:Label id="Label44" runat="server" Text="कैफियत" SkinID="Unicodelbl"></asp:Label> </TD><TD vAlign=top colSpan=3><asp:TextBox id="txtQualRemarks" runat="server" Width="150px" SkinID="Unicodetxt" MaxLength="50"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 85px"></TD><TD style="WIDTH: 200px" vAlign=top><asp:Button id="btnQualificationPlus" onclick="btnQualificationPlus_Click" runat="server" Text="+" SkinID="Add" OnClientClick="javascript:return validateUpanelFields('_Qual','Qual');"></asp:Button> </TD><TD style="WIDTH: 85px"></TD><TD></TD></TR><TR><TD style="HEIGHT: 21px" colSpan=4><BR /><asp:Panel id="Panel5" runat="server" Width="100%" Height="200px" ScrollBars="Auto"><asp:GridView id="grdQualification" runat="server" Width="100%" SkinID="Unicodegrd" OnSelectedIndexChanged="grdQualification_SelectedIndexChanged" AutoGenerateColumns="False" CellPadding="4" GridLines="None" OnRowDataBound="grdQualification_RowDataBound" OnRowDeleting="grdQualification_RowDeleting" ForeColor="#333333">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="EMPID" HeaderText="EmpId"></asp:BoundField>
<asp:BoundField DataField="SEQNO" HeaderText="क्र. सं."></asp:BoundField>
<asp:BoundField DataField="SUBJECT" HeaderText="शिर्षक"></asp:BoundField>
<asp:BoundField DataField="DEGREEID" HeaderText="Degree Id"></asp:BoundField>
<asp:BoundField DataField="DEGREENAME" HeaderText="डिग्री"></asp:BoundField>
<asp:BoundField DataField="INSTITUTIONID" HeaderText="Institution Id"></asp:BoundField>
<asp:BoundField DataField="INSTITUTIONNAME" HeaderText="संस्था"></asp:BoundField>
<asp:BoundField DataField="FROMDATE" HeaderText="अवधि देखी"></asp:BoundField>
<asp:BoundField DataField="TODATE" HeaderText="अवधि सम्म"></asp:BoundField>
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
                                <ajaxToolkit:TabPanel ID="TabPanel6" runat="server" HeaderText="TabPanel6">
                                    <HeaderTemplate>
                                        तालिम
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <asp:UpdatePanel id="UpdatePanel6" runat="server">
                                            <contenttemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD vAlign=top><asp:Label id="Label45" runat="server" Text="शिर्षक" SkinID="Unicodelbl"></asp:Label> </TD><TD vAlign=top colSpan=3><asp:TextBox id="txtTrainSubject_Training" runat="server" Width="150px" SkinID="Unicodetxt" ToolTip="शिर्षक" MaxLength="50"></asp:TextBox> </TD></TR><TR><TD vAlign=top><asp:Label id="Label46" runat="server" Text="सर्टिफिकेट" SkinID="Unicodelbl"></asp:Label> </TD><TD vAlign=top><asp:TextBox id="txtTrainCertificate_Training" runat="server" Width="150px" SkinID="Unicodetxt" ToolTip="सर्टिफिकेट"></asp:TextBox> </TD><TD vAlign=top><asp:Label id="Label47" runat="server" Text="संस्थाको नाम" SkinID="Unicodelbl"></asp:Label> </TD><TD vAlign=top><asp:DropDownList id="ddlTrainInstitution_Training" runat="server" Width="300px" SkinID="Unicodeddl" ToolTip="संस्था" AppendDataBoundItems="True"></asp:DropDownList> <asp:ImageButton id="imgTrainAddInstitution" runat="server" Width="20px" ImageUrl="~/MODULES/COMMON/Images/add-icon.png" Height="20px" ToolTip="Add/Update Institution" OnClientClick="wopen('../../COMMON/LookUp/Institution.aspx', 'popup', 768, 600); return false;" ImageAlign="AbsMiddle"></asp:ImageButton> <asp:ImageButton id="imgTrainRefreshInstitution" onclick="imgRefreshInstitution_Click" runat="server" Width="20px" ImageUrl="~/MODULES/COMMON/Images/refresh.png" Height="20px" ToolTip="Refresh Institution" ImageAlign="AbsMiddle"></asp:ImageButton> </TD></TR><TR><TD style="HEIGHT: 26px" vAlign=top><asp:Label id="Label48" runat="server" Text="अवधि देखि" SkinID="Unicodelbl"></asp:Label> </TD><TD style="HEIGHT: 26px" vAlign=top><asp:TextBox id="txtTrainFromDate_UDTTraining" runat="server" Width="100px" SkinID="Unicodetxt" ToolTip="अवधि देखि" MaxLength="10"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender4" runat="server" TargetControlID="txtTrainFromDate_UDTTraining" MaskType="Date" Mask="9999/99/99" AutoComplete="False"></ajaxToolkit:MaskedEditExtender></TD><TD style="HEIGHT: 26px" vAlign=top><asp:Label id="Label49" runat="server" Text="अवधि सम्म" SkinID="Unicodelbl"></asp:Label> </TD><TD style="HEIGHT: 26px" vAlign=top><asp:TextBox id="txtTrainToDate_UDTTraining" runat="server" Width="100px" SkinID="Unicodetxt" ToolTip="अवधि सम्म" MaxLength="10"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender5" runat="server" TargetControlID="txtTrainToDate_UDTTraining" MaskType="Date" Mask="9999/99/99" AutoComplete="False"></ajaxToolkit:MaskedEditExtender></TD></TR><TR><TD style="HEIGHT: 26px" vAlign=top><asp:Label id="Label50" runat="server" Text="ग्रेड" SkinID="Unicodelbl"></asp:Label> </TD><TD style="HEIGHT: 26px" vAlign=top><asp:TextBox id="txtTrainGrade" runat="server" Width="50px" SkinID="Unicodetxt" MaxLength="5"></asp:TextBox> </TD><TD style="HEIGHT: 26px" vAlign=top><asp:Label id="Label51" runat="server" Text="प्रतिशत" SkinID="Unicodelbl"></asp:Label> </TD><TD style="HEIGHT: 26px" vAlign=top><asp:TextBox id="txtTrainPercentage" onkeypress="return DecimalOnly(event,this)" runat="server" Width="50px" SkinID="Unicodetxt" MaxLength="5"></asp:TextBox> </TD></TR><TR><TD vAlign=top><asp:Label id="Label52" runat="server" Text="कैफियत" SkinID="Unicodelbl"></asp:Label> </TD><TD vAlign=top colSpan=3><asp:TextBox id="txtTrainRemarks" runat="server" Width="150px" SkinID="Unicodetxt" MaxLength="50"></asp:TextBox> </TD></TR><TR><TD></TD><TD vAlign=top><asp:Button id="btnTrainPlus" onclick="btnTrainPlus_Click" runat="server" Text="+" SkinID="Add" OnClientClick="javascript:return validateUpanelFields('_Training','Training');"></asp:Button> </TD><TD></TD><TD></TD></TR><TR><TD style="HEIGHT: 21px" colSpan=4><BR /><asp:Panel id="Panel6" runat="server" Width="100%" Height="200px"><asp:GridView id="grdTraining" runat="server" Width="100%" SkinID="Unicodegrd" OnSelectedIndexChanged="grdTraining_SelectedIndexChanged" AutoGenerateColumns="False" CellPadding="4" GridLines="None" OnRowDataBound="grdTraining_RowDataBound" OnRowDeleting="grdTraining_RowDeleting" ForeColor="#333333">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="EMPID" HeaderText="EmpId"></asp:BoundField>
<asp:BoundField DataField="SEQNO" HeaderText="क्र.सं."></asp:BoundField>
<asp:BoundField DataField="SUBJECT" HeaderText="शिर्षक"></asp:BoundField>
<asp:BoundField DataField="CERTIFICATENAME" HeaderText="सर्टिफिकेट"></asp:BoundField>
<asp:BoundField DataField="INSTITUTIONID" HeaderText="Institution Id"></asp:BoundField>
<asp:BoundField DataField="INSTITUTIONNAME" HeaderText="संस्था"></asp:BoundField>
<asp:BoundField DataField="FROMDATE" HeaderText="अवधि देखी"></asp:BoundField>
<asp:BoundField DataField="TODATE" HeaderText="अवधि सम्म"></asp:BoundField>
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
                                <ajaxToolkit:TabPanel ID="TabPanel7" runat="server" HeaderText="TabPanel7">
                                    <ContentTemplate>
                                        <asp:UpdatePanel id="UpdatePanel4" runat="server">
                                            <contenttemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD style="HEIGHT: 21px" vAlign=top><asp:Label id="Label32" runat="server" Text="स्थान" SkinID="Unicodelbl"></asp:Label></TD><TD style="HEIGHT: 21px" vAlign=top><asp:TextBox id="txtVisitLocation_Visit" runat="server" SkinID="Unicodetxt" ToolTip="स्थान" MaxLength="30"></asp:TextBox></TD><TD style="HEIGHT: 21px" vAlign=top><asp:Label id="Label33" runat="server" Text="देश" SkinID="Unicodelbl"></asp:Label></TD><TD style="HEIGHT: 21px" vAlign=top><asp:DropDownList id="ddlVisitCountry_Visit" runat="server" Width="156px" SkinID="Unicodeddl" ToolTip="देश"></asp:DropDownList></TD></TR><TR><TD vAlign=top><asp:Label id="Label34" runat="server" Text="अवधि देखी" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:TextBox id="txtVisitFromDate_URDTVisit" runat="server" Width="90px" SkinID="Unicodetxt" ToolTip="अवधि देखी" MaxLength="10"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender6" runat="server" TargetControlID="txtVisitFromDate_URDTVisit" MaskType="Date" Mask="9999/99/99" AutoComplete="False"></ajaxToolkit:MaskedEditExtender></TD><TD vAlign=top><asp:Label id="Label35" runat="server" Text="अवधि सम्म" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:TextBox id="txtVisitToDate_UDTVisit" runat="server" Width="90px" SkinID="Unicodetxt" ToolTip="अवधि सम्म" MaxLength="10"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender7" runat="server" TargetControlID="txtVisitToDate_UDTVisit" MaskType="Date" Mask="9999/99/99" AutoComplete="False"></ajaxToolkit:MaskedEditExtender></TD></TR><TR><TD style="HEIGHT: 21px" vAlign=top><asp:Label id="Label31" runat="server" Text="शिर्षक" SkinID="Unicodelbl"></asp:Label></TD><TD style="HEIGHT: 21px" vAlign=top><asp:TextBox id="txtVisitPurpose_Visit" runat="server" SkinID="Unicodetxt" ToolTip="शिर्षक"></asp:TextBox></TD><TD style="HEIGHT: 21px" vAlign=top><asp:Label id="Label36" runat="server" Text="कैफियत" SkinID="PCSlbl"></asp:Label></TD><TD style="HEIGHT: 21px" vAlign=top><asp:TextBox id="txtVisitRemarks" runat="server" SkinID="Unicodetxt" MaxLength="15"></asp:TextBox></TD></TR><TR><TD style="HEIGHT: 21px"></TD><TD style="HEIGHT: 21px"></TD><TD style="HEIGHT: 21px"></TD><TD style="HEIGHT: 21px"><asp:Button id="btnVisitsPlus" onclick="btnVisitsPlus_Click" runat="server" Text="+" SkinID="Add" OnClientClick="javascript:return validateUpanelFields('_Visit','Visit');"></asp:Button></TD></TR><TR><TD style="HEIGHT: 21px" colSpan=4><BR /><asp:Panel id="Panel4" runat="server" Width="100%" Height="200px" ScrollBars="Auto"><asp:GridView id="grdVisits" runat="server" Width="100%" SkinID="Unicodegrd" OnSelectedIndexChanged="grdVisits_SelectedIndexChanged" AutoGenerateColumns="False" CellPadding="4" GridLines="None" OnRowDataBound="grdVisits_RowDataBound" OnRowDeleting="grdVisits_RowDeleting" ForeColor="#333333">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="EMPID" HeaderText="EmpId"></asp:BoundField>
<asp:BoundField DataField="SEQNO" HeaderText="क्र.सं."></asp:BoundField>
<asp:BoundField DataField="LOCATION" HeaderText="स्थान"></asp:BoundField>
<asp:BoundField DataField="COUNTRY" HeaderText="CountryId"></asp:BoundField>
<asp:BoundField DataField="COUNTRYNEPNAME" HeaderText="देश"></asp:BoundField>
<asp:BoundField DataField="FROMDATE" HeaderText="अवधि देखी"></asp:BoundField>
<asp:BoundField DataField="TODATE" HeaderText="अवधि सम्म"></asp:BoundField>
<asp:BoundField DataField="PURPOSE" HeaderText="शिर्षक"></asp:BoundField>
<asp:BoundField DataField="REMARKS" HeaderText="कैफियत"></asp:BoundField>
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
                                        <asp:UpdatePanel id="UpdatePanel7" runat="server">
                                            <contenttemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD vAlign=top><asp:Label id="Label53" runat="server" Text="कागजपत्र" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:DropDownList id="ddlDocType_Documents" runat="server" Width="155px" SkinID="Unicodeddl" ToolTip="कागजपत्र"></asp:DropDownList>&nbsp;<asp:ImageButton id="imgAddDocuments" runat="server" Width="20px" ImageUrl="~/MODULES/COMMON/Images/add-icon.png" Height="20px" ToolTip="Add/Update Documents Type" OnClientClick="wopen('../../PMS/LookUp/DocumentsType.aspx', 'popup', 768, 400); return false;" ImageAlign="AbsMiddle"></asp:ImageButton>&nbsp;<asp:ImageButton id="imgRefreshDocument" onclick="imgRefreshDocument_Click" runat="server" Width="20px" ImageUrl="~/MODULES/COMMON/Images/refresh.png" Height="20px" ToolTip="Refresh Documents Type" ImageAlign="AbsMiddle"></asp:ImageButton></TD><TD vAlign=top><asp:Label id="Label54" runat="server" Text="नं" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:TextBox id="txtDocNumber_Documents" runat="server" SkinID="Unicodetxt" ToolTip="कागजपत्रको नं" MaxLength="20"></asp:TextBox></TD></TR><TR><TD vAlign=top><asp:Label id="Label55" runat="server" Text="जारी भएको स्थान" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:DropDownList id="ddlDocIssuedFrom" runat="server" Width="155px" SkinID="Unicodeddl"></asp:DropDownList></TD><TD vAlign=top><asp:Label id="Label56" runat="server" Text="जारी भएको मिति" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:TextBox id="txtDocIssuedOn_UDTDocuments" runat="server" Width="90px" SkinID="Unicodetxt" ToolTip="जारी भएको मिति" MaxLength="10"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender8" runat="server" TargetControlID="txtDocIssuedOn_UDTDocuments" MaskType="Date" Mask="9999/99/99" AutoComplete="False"></ajaxToolkit:MaskedEditExtender></TD></TR><TR><TD vAlign=top><asp:Label id="Label57" runat="server" Text="जारी गरेको संस्था" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:TextBox id="txtDocIssuedBy" runat="server" Width="150px" SkinID="Unicodetxt" MaxLength="30"></asp:TextBox></TD><TD vAlign=top><asp:Button id="btnDocumentsPlus" onclick="btnDocumentsPlus_Click" runat="server" Text="+" SkinID="Add" OnClientClick="javascript:return validateUpanelFields('_Documents','Documents');"></asp:Button></TD><TD></TD></TR><TR><TD style="HEIGHT: 21px"></TD><TD style="HEIGHT: 21px"></TD><TD style="HEIGHT: 21px"></TD><TD style="HEIGHT: 21px"></TD></TR><TR><TD vAlign=top colSpan=4><asp:Panel id="Panel7" runat="server" Width="100%" Height="200px" ScrollBars="Auto"><asp:GridView id="grdDocuments" runat="server" Width="100%" SkinID="Unicodegrd" OnSelectedIndexChanged="grdDocuments_SelectedIndexChanged" AutoGenerateColumns="False" CellPadding="4" GridLines="None" OnRowDataBound="grdDocuments_RowDataBound" OnRowDeleting="grdDocuments_RowDeleting" ForeColor="#333333">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="PID" HeaderText="PersonId"></asp:BoundField>
<asp:BoundField DataField="DOCTYPEID" HeaderText="Doc Type Id"></asp:BoundField>
<asp:BoundField DataField="DOCTYPENAME" HeaderText="कागजपत्र"></asp:BoundField>
<asp:BoundField DataField="DOCNUMBER" HeaderText="नं."></asp:BoundField>
<asp:BoundField DataField="ISSUEDFROM" HeaderText="Issued From ID"></asp:BoundField>
<asp:BoundField DataField="NEPDISTNAME" HeaderText="जारी भएको स्थान"></asp:BoundField>
<asp:BoundField DataField="ISSUEDON" HeaderText="जारी भएको मिति"></asp:BoundField>
<asp:BoundField DataField="ISSUEDBY" HeaderText="जारी गरेको संस्था"></asp:BoundField>
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
                                        <asp:UpdatePanel id="UpdatePanel8" runat="server">
                                            <contenttemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD style="WIDTH: 125px; HEIGHT: 21px" vAlign=top><asp:Label id="Label58" runat="server" Width="120px" Text="पदस्थपना स्थान" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 200px; HEIGHT: 21px" vAlign=top><asp:TextBox id="txtExpPostingLocation_Experience" runat="server" Width="160px" SkinID="Unicodetxt" ToolTip="पदस्थापना स्थान" MaxLength="20"></asp:TextBox></TD><TD style="WIDTH: 125px; HEIGHT: 21px" vAlign=top><asp:Label id="Label62" runat="server" Width="120px" Text="काम गरेको स्थान" SkinID="Unicodelbl"></asp:Label></TD><TD style="HEIGHT: 21px" vAlign=top><asp:TextBox id="txtExpJobLocation_Experience" runat="server" Width="160px" SkinID="Unicodetxt" ToolTip="काम गरेको स्थान" MaxLength="10"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 125px" vAlign=top><asp:Label id="Label59" runat="server" Text="अवधि देखी" SkinID="Unicodelbl" Font-Names="PCS NEPALI"></asp:Label></TD><TD style="WIDTH: 200px" vAlign=top><asp:TextBox id="txtExpFromDate_UDTExperience" runat="server" Width="90px" SkinID="Unicodetxt" ToolTip="अवधि देखी" MaxLength="10"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender9" runat="server" TargetControlID="txtExpFromDate_UDTExperience" MaskType="Date" Mask="9999/99/99" AutoComplete="False"></ajaxToolkit:MaskedEditExtender></TD><TD style="WIDTH: 125px" vAlign=top><asp:Label id="Label60" runat="server" Text="अवधि सम्म" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:TextBox id="txtExpToDate_UDTExperience" runat="server" Width="90px" SkinID="Unicodetxt" ToolTip="अवधि सम्म" MaxLength="10"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender10" runat="server" TargetControlID="txtExpToDate_UDTExperience" MaskType="Date" Mask="9999/99/99" AutoComplete="False"></ajaxToolkit:MaskedEditExtender></TD></TR><TR><TD style="WIDTH: 125px; HEIGHT: 21px" vAlign=top><asp:Label id="Label63" runat="server" Text="वर्ग" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 200px; HEIGHT: 21px" vAlign=top><asp:DropDownList id="ddlExpClassification" runat="server" Width="80px" SkinID="Unicodeddl"><asp:ListItem>छन्नुहोस</asp:ListItem>
<asp:ListItem>क</asp:ListItem>
<asp:ListItem>ख</asp:ListItem>
<asp:ListItem>ग</asp:ListItem>
<asp:ListItem>घ</asp:ListItem>
<asp:ListItem>ङ</asp:ListItem>
</asp:DropDownList></TD><TD style="WIDTH: 125px; HEIGHT: 21px" vAlign=top><asp:Label id="Label61" runat="server" Text="कैफियत" SkinID="Unicodelbl"></asp:Label></TD><TD style="HEIGHT: 21px" vAlign=top><asp:TextBox id="txtExpRemarks" runat="server" Width="160px" SkinID="Unicodetxt" MaxLength="15"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 125px; HEIGHT: 21px"></TD><TD style="WIDTH: 200px; HEIGHT: 21px"></TD><TD style="WIDTH: 125px; HEIGHT: 21px"></TD><TD style="HEIGHT: 21px"><asp:Button id="btnExperiencesPlus" onclick="btnExperiencesPlus_Click" runat="server" Text="+" SkinID="Add" OnClientClick="javascript:return validateUpanelFields('_Experience','Experience');"></asp:Button></TD></TR><TR><TD style="HEIGHT: 21px" colSpan=4><asp:Panel id="Panel8" runat="server" Width="100%" Height="200px" ScrollBars="Auto"><asp:GridView id="grdExperiences" runat="server" Width="100%" SkinID="Unicodegrd" OnSelectedIndexChanged="grdExperiences_SelectedIndexChanged" AutoGenerateColumns="False" GridLines="None" OnRowDataBound="grdExperiences_RowDataBound" OnRowDeleting="grdExperiences_RowDeleting" ForeColor="#333333">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="EMPID" HeaderText="Emp ID"></asp:BoundField>
<asp:BoundField DataField="SEQNO" HeaderText="क्र.सं."></asp:BoundField>
<asp:BoundField DataField="FROMDATE" HeaderText="अवधि दखी"></asp:BoundField>
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
                                        <asp:UpdatePanel id="updPublication" runat="server">
                                            <contenttemplate>
<TABLE style="WIDTH: 648px"><TBODY><TR><TD style="WIDTH: 120px; HEIGHT: 21px"><asp:Label id="Label68" runat="server" Width="110px" Text="प्रकाशन" SkinID="Unicodelbl"></asp:Label></TD><TD style="HEIGHT: 21px"><asp:TextBox id="txtPublication_Publ" runat="server" Width="300px" SkinID="Unicodetxt" ToolTip="प्रकाशन"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 120px"><asp:Label id="Label75" runat="server" Width="110px" Text="प्रकाशक" SkinID="Unicodelbl"></asp:Label></TD><TD><asp:TextBox id="txtPublisher_Publ" runat="server" Width="300px" SkinID="Unicodetxt" ToolTip="प्रकाशक"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 120px; HEIGHT: 21px"><asp:Label id="Label76" runat="server" Width="110px" Text="प्रकाशन मिति" SkinID="Unicodelbl"></asp:Label></TD><TD style="HEIGHT: 21px"><asp:TextBox id="txtPubDate_UDTPubl" runat="server" Width="75px" SkinID="Unicodetxt" ToolTip="प्रकाशन मिति"></asp:TextBox>&nbsp;<asp:Button id="btnAddPublication" onclick="btnAddPublication_Click" runat="server" Text="+" SkinID="Add" OnClientClick="javascript:return validateUpanelFields('_Publ','Publ');"></asp:Button></TD></TR><TR><TD style="WIDTH: 120px" height=20></TD><TD height=20><ajaxToolkit:MaskedEditExtender id="mskPublicationDate" runat="server" TargetControlID="txtPubDate_UDTPubl" MaskType="Date" Mask="9999/99/99" AutoComplete="False"></ajaxToolkit:MaskedEditExtender></TD></TR></TBODY></TABLE><TABLE style="WIDTH: 1px"><TBODY><TR><TD style="HEIGHT: 21px"><asp:Panel id="Panel9" runat="server" Width="100%" Height="200px" ScrollBars="Auto"><asp:GridView id="grdPublication" runat="server" Width="882px" SkinID="Unicodegrd" OnSelectedIndexChanged="grdPublication_SelectedIndexChanged" AutoGenerateColumns="False" CellPadding="2" GridLines="None" OnRowDeleting="grdPublication_RowDeleting" ForeColor="#333333" OnRowCreated="grdPublication_RowCreated" CellSpacing="1">
<FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="EmpID" HeaderText="EmpID"></asp:BoundField>
<asp:BoundField DataField="PublicationID" HeaderText="PublicationID"></asp:BoundField>
<asp:BoundField DataField="PublicationName" HeaderText="प्रकाशनको नाम">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="Publisher" HeaderText="प्रकाशन कर्त्ता">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="PublicationDate" HeaderText="प्रकाशन मिति">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="Action" HeaderText="Action"></asp:BoundField>
<asp:CommandField ShowSelectButton="True"></asp:CommandField>
<asp:CommandField ShowDeleteButton="True"></asp:CommandField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView></asp:Panel></TD></TR></TBODY></TABLE>
</contenttemplate>
                                        </asp:UpdatePanel>
                                        <br />
                                    </ContentTemplate>
                                </ajaxToolkit:TabPanel>
                                <ajaxToolkit:TabPanel ID="TabPanel10" runat="server" HeaderText="TabPanel10">
                                    <ContentTemplate>
                                        <asp:UpdatePanel id="UpdatePanel2" runat="server">
                                            <contenttemplate>
<TABLE style="WIDTH: 700px"><TBODY><TR><TD style="WIDTH: 125px" vAlign=top align=left><asp:Label id="Label79" runat="server" Text="पहिलो नाम" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 120px" vAlign=top align=left><asp:TextBox id="txtRelationFirstName_Relative" runat="server" Width="100px" SkinID="Unicodetxt" ToolTip="पहिलो नाम"></asp:TextBox></TD><TD style="WIDTH: 85px" vAlign=top align=left><asp:Label id="Label80" runat="server" Width="80px" Text="बिचको नाम" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 120px" vAlign=top align=left><asp:TextBox id="txtRelationMName" runat="server" Width="100px" SkinID="Unicodetxt"></asp:TextBox></TD><TD style="WIDTH: 116px" vAlign=top align=left><asp:Label id="Label81" runat="server" Text="थर" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top align=left><asp:TextBox id="txtRelationLastName_Relative" runat="server" Width="100px" SkinID="Unicodetxt" ToolTip="थर"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 125px" vAlign=top align=left><asp:Label id="Label90" runat="server" Text="लिंग" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 120px" vAlign=top align=left><asp:DropDownList id="ddlRelationGender" runat="server" Width="105px" SkinID="Unicodeddl"><asp:ListItem Value="SG">छान्नुहोस</asp:ListItem>
<asp:ListItem Value="M">पुरुष</asp:ListItem>
<asp:ListItem Value="F">महिला</asp:ListItem>
<asp:ListItem Value="O">अन्य</asp:ListItem>
</asp:DropDownList></TD><TD style="WIDTH: 85px" vAlign=top align=left><asp:Label id="Label91" runat="server" Width="75px" Text="जन्म मिति" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 120px" vAlign=top align=left><asp:TextBox id="txtRelationDOB_DTRelative" runat="server" Width="100px" SkinID="Unicodetxt" ToolTip="जन्म मिति"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender11" runat="server" TargetControlID="txtRelationDOB_DTRelative" MaskType="Date" Mask="9999/99/99" AutoComplete="False"></ajaxToolkit:MaskedEditExtender></TD><TD style="WIDTH: 116px" vAlign=top align=left><asp:Label id="Label92" runat="server" Width="110px" Text="बैबाहिक सम्बन्ध" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top align=left><asp:DropDownList id="ddlRelationMarStatus" runat="server" Width="105px" SkinID="Unicodeddl"><asp:ListItem Value="SMS">छान्नुहोस</asp:ListItem>
<asp:ListItem Value="S">अबिबाहित</asp:ListItem>
<asp:ListItem Value="M">बिबाहित</asp:ListItem>
<asp:ListItem Value="W">बिधवा/बिदुर</asp:ListItem>
<asp:ListItem Value="D">छोडपत्र</asp:ListItem>
<asp:ListItem Value="O">अन्य</asp:ListItem>
</asp:DropDownList> <asp:HiddenField id="hdnRelativeID" runat="server"></asp:HiddenField></TD></TR><TR><TD style="WIDTH: 125px" vAlign=top align=left><asp:Label id="Label93" runat="server" Width="120px" Text="घर भएको जिल्ला" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 120px" vAlign=top align=left><asp:DropDownList id="ddlRelationHomeDistrict" runat="server" Width="105px" SkinID="Unicodeddl"></asp:DropDownList></TD><TD style="WIDTH: 85px" vAlign=top align=left><asp:Label id="Label94" runat="server" Width="52px" Text="सम्बन्ध" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 120px" vAlign=top align=left><asp:DropDownList id="ddlRelationType_Relative" runat="server" Width="105px" SkinID="Unicodeddl" ToolTip="सम्बन्ध"></asp:DropDownList> </TD><TD style="WIDTH: 116px" vAlign=top align=left><asp:Label id="Label95" runat="server" Text="पेशा" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top align=left><asp:TextBox id="txtRelativeOcc" runat="server" SkinID="Unicodetxt"></asp:TextBox></TD></TR><TR><TD vAlign=top align=left colSpan=6><asp:Button id="btnSearchRelatives" onclick="btnSearchRelatives_Click" runat="server" Text="Relatives" SkinID="Normal"></asp:Button> <asp:Button id="btnAddRelatives" onclick="btnAddRelatives_Click" runat="server" Text="+" SkinID="Add" OnClientClick="javascript:return validateUpanelFields('_Relative','Relative');"></asp:Button> <asp:Button id="btnClearRelatives" onclick="btnClearRelatives_Click" runat="server" Text="Clear" SkinID="Cancel"></asp:Button></TD></TR><TR><TD style="HEIGHT: 19px" vAlign=top align=left colSpan=6><asp:Panel id="Panel1" runat="server" Width="100%" Height="200px" ScrollBars="Auto"><asp:GridView id="grdEmpRelatives" runat="server" Width="850px" SkinID="Unicodegrd" AutoGenerateColumns="False" CellPadding="4" GridLines="None" OnRowDataBound="grdEmpRelatives_RowDataBound" ForeColor="#333333">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="PID" HeaderText="आईडि"></asp:BoundField>
<asp:BoundField DataField="RELATIVEID" HeaderText="ना.आईडी"></asp:BoundField>
<asp:BoundField DataField="FIRSTNAME" HeaderText="पहिलो नाम"></asp:BoundField>
<asp:BoundField DataField="MIDNAME" HeaderText="बिचको नाम"></asp:BoundField>
<asp:BoundField DataField="SURNAME" HeaderText="थर"></asp:BoundField>
<asp:BoundField DataField="RDFULLNAME" HeaderText="पुरा नाम थर"></asp:BoundField>
<asp:BoundField DataField="GENDER" HeaderText="लि.आईडि"></asp:BoundField>
<asp:BoundField DataField="RDGENDER" HeaderText="लिंग"></asp:BoundField>
<asp:BoundField DataField="DOB" HeaderText="जन्म मिति"></asp:BoundField>
<asp:BoundField DataField="MARITALSTATUS" HeaderText="बैबाहिक"></asp:BoundField>
<asp:BoundField DataField="RDMARITALSTATUS" HeaderText="बैबाहिक सम्बन्ध"></asp:BoundField>
<asp:BoundField DataField="BIRTHDISTRICT" HeaderText="घर"></asp:BoundField>
<asp:BoundField DataField="NEPDISTNAME" HeaderText="घर जिल्ला"></asp:BoundField>
<asp:BoundField DataField="RELATIONTYPEID" HeaderText="सम्बन्ध"></asp:BoundField>
<asp:BoundField DataField="RELATIONTYPENAME" HeaderText="सम्बन्ध"></asp:BoundField>
<asp:BoundField DataField="OCCUPATION" HeaderText="पेशा"></asp:BoundField>
<asp:TemplateField HeaderText="ईच्छाइएको">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
<ItemTemplate>
<asp:CheckBox id="chkIsBeneficiary" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "ISBENEFICIARY").ToString() == "True" %>'></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="सक्रिय">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
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
</asp:GridView> </asp:Panel></TD></TR><TR><TD vAlign=top align=left colSpan=6></TD></TR></TBODY></TABLE>
</contenttemplate>
                                        </asp:UpdatePanel>
                                    </ContentTemplate>
                                    <HeaderTemplate>
                                        नातेदार
                                    </HeaderTemplate>
                                </ajaxToolkit:TabPanel>
                                <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                                    <ContentTemplate>
                                        <asp:UpdatePanel id="UpdatePanel9" runat="server">
                                            <contenttemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD vAlign=top><asp:Label id="Label64" runat="server" Text="कार्यालय" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top colSpan=5><asp:DropDownList id="ddlOrganization_Posting" runat="server" Width="417px" SkinID="Unicodeddl" ToolTip="कार्यालय" OnSelectedIndexChanged="ddlOrganization_Posting_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD></TR><TR><TD vAlign=top><asp:Label id="Label65" runat="server" Text="पद" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top><asp:DropDownList id="ddlPost_Posting" runat="server" Width="150px" SkinID="Unicodeddl" ToolTip="पद" OnSelectedIndexChanged="ddlPost_Posting_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="True"></asp:DropDownList></TD><TD vAlign=top><asp:Label id="Label66" runat="server" Text="उपलब्ध पद" SkinID="Unicodelbl"></asp:Label></TD><TD vAlign=top colSpan=3><asp:DropDownList id="ddlAvailablePost_Posting" runat="server" Width="92%" SkinID="Unicodeddl" ToolTip="उपलब्ध पद" AppendDataBoundItems="True"></asp:DropDownList></TD></TR><TR><TD style="HEIGHT: 21px" vAlign=top><asp:Label id="Label72" runat="server" Text="छनौट तरिका" SkinID="Unicodelbl"></asp:Label></TD><TD style="HEIGHT: 21px" vAlign=top><asp:DropDownList id="ddlPostingType_Posting" runat="server" Width="150px" SkinID="Unicodeddl" ToolTip="छनौट तरिका"></asp:DropDownList></TD><TD style="HEIGHT: 21px" vAlign=top><asp:Label id="Label67" runat="server" Text="नियुक्ति मिति" SkinID="Unicodelbl"></asp:Label></TD><TD style="HEIGHT: 21px" vAlign=top><asp:TextBox id="txtDate_UDTPosting" runat="server" Width="100px" SkinID="Unicodetxt" ToolTip="नियुक्ति मिति" MaxLength="10"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender12" runat="server" TargetControlID="txtDate_UDTPosting" MaskType="Date" Mask="9999/99/99" AutoComplete="False"></ajaxToolkit:MaskedEditExtender></TD><TD style="HEIGHT: 21px" vAlign=top><asp:Label id="Label69" runat="server" Text="निर्णय मिति" SkinID="Unicodelbl"></asp:Label></TD><TD style="HEIGHT: 21px" vAlign=top><asp:TextBox id="txtDecisionDate_UDTPosting" runat="server" Width="100px" SkinID="Unicodetxt" ToolTip="निर्णय मिति" MaxLength="10"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender13" runat="server" TargetControlID="txtDecisionDate_UDTPosting" MaskType="Date" Mask="9999/99/99" AutoComplete="False"></ajaxToolkit:MaskedEditExtender></TD></TR><TR><TD style="HEIGHT: 21px" vAlign=top><asp:Label id="Label70" runat="server" Text="रवाना मिति" SkinID="Unicodelbl"></asp:Label></TD><TD style="HEIGHT: 21px" vAlign=top><asp:TextBox id="txtLeaveDate_UDTPosting" runat="server" Width="100px" SkinID="Unicodetxt" ToolTip="रवाना मिति" MaxLength="10"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender14" runat="server" TargetControlID="txtLeaveDate_UDTPosting" MaskType="Date" Mask="9999/99/99" AutoComplete="False"></ajaxToolkit:MaskedEditExtender></TD><TD style="HEIGHT: 21px" vAlign=top><asp:Label id="Label71" runat="server" Text="उपस्थित मिति" SkinID="Unicodelbl"></asp:Label></TD><TD style="HEIGHT: 21px" vAlign=top><asp:TextBox id="txtJoinDate_UDTPosting" runat="server" Width="100px" SkinID="Unicodetxt" ToolTip="उपस्थित मिति" MaxLength="10"></asp:TextBox> <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender15" runat="server" TargetControlID="txtJoinDate_UDTPosting" MaskType="Date" Mask="9999/99/99" AutoComplete="False"></ajaxToolkit:MaskedEditExtender></TD><TD style="HEIGHT: 21px" vAlign=top></TD><TD style="HEIGHT: 21px" vAlign=top></TD></TR><TR><TD style="HEIGHT: 21px" vAlign=top><asp:Label id="Label73" runat="server" Text="तलब" SkinID="Unicodelbl" Visible="False"></asp:Label></TD><TD style="HEIGHT: 21px" vAlign=top><asp:TextBox id="txtSalary" runat="server" Width="100px" SkinID="Unicodetxt" Visible="False"></asp:TextBox></TD><TD style="HEIGHT: 21px" vAlign=top><asp:Label id="Label74" runat="server" Text="कैफियत" Visible="False"></asp:Label></TD><TD style="HEIGHT: 21px" vAlign=top colSpan=3><asp:TextBox id="txtPostingRemarks" runat="server" Width="145px" SkinID="Unicodetxt" Visible="False"></asp:TextBox></TD></TR><TR><TD style="HEIGHT: 21px" vAlign=top></TD><TD style="HEIGHT: 21px" vAlign=top></TD><TD style="HEIGHT: 21px" vAlign=top></TD><TD style="HEIGHT: 21px" vAlign=top colSpan=3><asp:Button id="btnPostingPlus" onclick="btnPostingPlus_Click" runat="server" Width="30px" Text="+" Visible="False" OnClientClick="javascript:return validateUpanelFields('_Posting','Posting');"></asp:Button></TD></TR><TR><TD style="HEIGHT: 21px" vAlign=top colSpan=6><asp:Panel id="Panel2" runat="server" Width="900px" Height="100px" ScrollBars="Auto"><asp:GridView id="grdEmpPostings" runat="server" Width="900px" SkinID="Unicodegrd" OnRowDataBound="grdEmpPostings_RowDataBound" AutoGenerateColumns="False" OnRowDeleting="grdEmpPostings_RowDeleting"><Columns>
<asp:BoundField DataField="EMPID" HeaderText="Emp ID"></asp:BoundField>
<asp:BoundField DataField="ORGID" HeaderText="कार्यालय"></asp:BoundField>
<asp:BoundField DataField="ORGNAME" HeaderText="कार्यालय"></asp:BoundField>
<asp:BoundField DataField="DESID" HeaderText="पद"></asp:BoundField>
<asp:BoundField DataField="DESNAME" HeaderText="पद"></asp:BoundField>
<asp:BoundField DataField="POSTID" HeaderText="पद"></asp:BoundField>
<asp:BoundField DataField="CREATEDDATE" HeaderText="Created Date"></asp:BoundField>
<asp:BoundField DataField="POSTNAME" HeaderText="पद"></asp:BoundField>
<asp:BoundField DataField="POSTINGTYPEID" HeaderText="छनौट तरीका"></asp:BoundField>
<asp:BoundField DataField="POSTINGTYPENAME" HeaderText="छनौट तरीका"></asp:BoundField>
<asp:BoundField DataField="FROMDATE" HeaderText="नियुक्ति मिति"></asp:BoundField>
<asp:BoundField DataField="TODATE" HeaderText="To Date"></asp:BoundField>
<asp:BoundField DataField="DECISIONDATE" HeaderText="निर्णय मिति"></asp:BoundField>
<asp:BoundField DataField="LEAVEDATE" HeaderText="रवाना मिति"></asp:BoundField>
<asp:BoundField DataField="JOININGDATE" HeaderText="उपस्थित मिति"></asp:BoundField>
<asp:BoundField DataField="ACTION" HeaderText="Action"></asp:BoundField>
<asp:CommandField ShowDeleteButton="True"></asp:CommandField>
</Columns>
</asp:GridView></asp:Panel></TD></TR></TBODY></TABLE>
</contenttemplate>
                                        </asp:UpdatePanel>
                                    </ContentTemplate>
                                    <HeaderTemplate>
                                        नियुक्ति
                                    </HeaderTemplate>
                                </ajaxToolkit:TabPanel>
                            </ajaxToolkit:TabContainer>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="6" valign="top">
                <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" OnClientClick="javascript:return validate(1);"
                    SkinID="Normal" Text="Submit" />
                <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" SkinID="Cancel"
                    Text="Cancel" />&nbsp;</td>
        </tr>
    </table>
    <asp:Button ID="hiddenTargetControlForPersonModalPopup" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="programmaticPersonModalPopup" runat="server"
        BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior1"
        DropShadow="True" PopupControlID="programmaticPersonPopup" PopupDragHandleControlID="programmaticPersonPopupDragHandle"
        RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForPersonModalPopup">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="programmaticPersonPopup" runat="server" CssClass="modalPopupPerson"
        Height="400px" Style="display: none; padding: 10px">
        <asp:Panel ID="programmaticPersonPopupDragHandle" runat="Server" Style="cursor: move;
            background-color: #DDDDDD; border: solid 1px Gray; color: Black; text-align: center;">
            नातेदार खोज्नुहोस</asp:Panel>
        <contenttemplate></contenttemplate>
        <asp:UpdatePanel id="UpdatePanelPersonSearch" runat="server">
            <contenttemplate>
<BR /><TABLE style="WIDTH: 700px; TEXT-ALIGN: left"><TBODY><TR><TD style="WIDTH: 120px" vAlign=top><asp:Label id="Label14" runat="server" Width="75px" SkinID="Unicodelbl" Text="पहिलो नाम"></asp:Label></TD><TD style="WIDTH: 140px" vAlign=top><asp:TextBox id="txtSFirstName" runat="server" Width="100px" SkinID="Unicodetxt"></asp:TextBox></TD><TD style="WIDTH: 85px" vAlign=top><asp:Label id="Label16" runat="server" Width="80px" SkinID="Unicodelbl" Text="बिचको नाम"></asp:Label></TD><TD style="WIDTH: 140px" vAlign=top><asp:TextBox id="txtSMName" runat="server" Width="100px" SkinID="Unicodetxt"></asp:TextBox></TD><TD style="WIDTH: 115px" vAlign=top><asp:Label id="Label17" runat="server" SkinID="Unicodelbl" Text="थर"></asp:Label></TD><TD vAlign=top><asp:TextBox id="txtSLastName" runat="server" Width="100px" SkinID="Unicodetxt"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 120px" vAlign=top><asp:Label id="Label78" runat="server" SkinID="Unicodelbl" Text="लिंग"></asp:Label></TD><TD style="WIDTH: 140px" vAlign=top><asp:DropDownList id="ddlSGender" runat="server" Width="105px" SkinID="Unicodeddl"><asp:ListItem Value="SG">छान्नुहोस</asp:ListItem>
<asp:ListItem Value="M">पुरुष</asp:ListItem>
<asp:ListItem Value="F">महिला</asp:ListItem>
<asp:ListItem Value="O">अन्य</asp:ListItem>
</asp:DropDownList></TD><TD style="WIDTH: 85px" vAlign=top><asp:Label id="Label20" runat="server" Width="75px" SkinID="Unicodelbl" Text="जन्म मिति"></asp:Label></TD><TD style="WIDTH: 140px" vAlign=top><asp:TextBox id="txtSDOB_DT" runat="server" Width="100px" SkinID="Unicodetxt"></asp:TextBox></TD><TD style="WIDTH: 115px" vAlign=top><asp:Label id="Label25" runat="server" Width="110px" SkinID="Unicodelbl" Text="बैबाहिक सम्बन्ध"></asp:Label></TD><TD vAlign=top><asp:DropDownList id="ddlSMarStatus" runat="server" Width="105px" SkinID="Unicodeddl"><asp:ListItem Value="SMS">छान्नुहोस</asp:ListItem>
<asp:ListItem Value="S">अबिबाहित</asp:ListItem>
<asp:ListItem Value="M">बिबाहित</asp:ListItem>
<asp:ListItem Value="W">बिधवा/बिदुर</asp:ListItem>
<asp:ListItem Value="D">छोडपत्र</asp:ListItem>
<asp:ListItem Value="O">अन्य</asp:ListItem>
</asp:DropDownList></TD></TR><TR><TD style="WIDTH: 120px" vAlign=top><asp:Label id="Label77" runat="server" Width="120px" SkinID="Unicodelbl" Text="घर भएको जिल्ला"></asp:Label></TD><TD style="WIDTH: 140px" vAlign=top><asp:DropDownList id="ddlSHomeDistrict" runat="server" Width="105px" SkinID="Unicodeddl"></asp:DropDownList></TD><TD style="WIDTH: 85px" vAlign=top></TD><TD style="WIDTH: 140px" vAlign=top></TD><TD style="WIDTH: 115px" vAlign=top></TD><TD vAlign=top></TD></TR><TR><TD style="HEIGHT: 23px" vAlign=top colSpan=2><asp:Button id="btnPersonSearch" onclick="btnPersonSearch_Click" runat="server" Text="Search"></asp:Button> <asp:Button id="btnCancelPersonSearch" onclick="btnCancelPersonSearch_Click" runat="server" Text="Cancel"></asp:Button> </TD><TD style="WIDTH: 85px; HEIGHT: 23px" vAlign=top></TD><TD style="WIDTH: 140px; HEIGHT: 23px" vAlign=top></TD><TD style="HEIGHT: 23px" vAlign=top align=right colSpan=2>&nbsp;</TD></TR><TR><TD style="HEIGHT: 23px" vAlign=top colSpan=6><asp:Panel id="pnlPersonSearch" runat="server" Width="680" Height="250px" ScrollBars="Auto"><asp:GridView id="grdPersonSearch" runat="server" Width="650px" SkinID="Unicodegrd" ForeColor="#333333" AutoGenerateColumns="False" CellPadding="4" GridLines="None" OnRowDataBound="grdPersonSearch_RowDataBound" OnSelectedIndexChanged="grdPersonSearch_SelectedIndexChanged">
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
</asp:GridView></asp:Panel></TD></TR></TBODY></TABLE><BR />&nbsp; 
</contenttemplate>
        </asp:UpdatePanel>
        <asp:Button ID="btnOKPersonSearch" runat="server" OnClick="OkPersonButton_Click"
            Text="OK" Width="58px" />
        <br />
    </asp:Panel>
</asp:Content>
