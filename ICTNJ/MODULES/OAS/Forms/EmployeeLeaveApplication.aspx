<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true" CodeFile="EmployeeLeaveApplication.aspx.cs" Inherits="MODULES_PMS_Forms_EmployeeLeaveApplication" Title="OAS|Employee Leave Application" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script language="javascript" src="../../COMMON/JS/Validation.js" type="text/javascript"></script>

    <script language="javascript" src="../../COMMON/JS/DateValidator.js" type="text/javascript"></script>

    <script language="javascript" src="../../COMMON/JS/EnglishDateValidator.js" type="text/javascript"></script>

    <script language="javascript" src="../../COMMON/JS/Number.js" type="text/javascript"></script>

    <script language="javascript" src="../../COMMON/JS/UPanelValidation.js" type="text/javascript"></script>

    <script language="javascript" src="../../COMMON/JS/EmailValidator.js" type="text/javascript"></script>

    <script src="../../COMMON/JS/jquery.min.js" type="text/javascript"></script>

    <script src="../../COMMON/JS/scrolltopcontrol.js" type="text/javascript">
    <script language="javascript" type="text/javascript">
    
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
    <div style="height:450px"> 
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
<asp:Label id="lblStatusMessage" runat="server" Text="Label"></asp:Label> 
</contenttemplate>
        </asp:UpdatePanel>
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
            Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    <br />
    <table style="width: 800px">
        <tr>
            <td style="width: 100px; height: 10px" valign="top">
                <asp:Label ID="LblApplicatn" runat="server" SkinID="Unicodelbl" Text="निवेदक" Width="60px"></asp:Label>
            </td>
            <td style="width: 290px; height: 10px" valign="top">
                <asp:TextBox ID="txtEmpName" runat="server" AutoPostBack="True" ReadOnly="True" SkinID="Unicodetxt"
                    Width="288px" BackColor="White" BorderColor="White" BorderStyle="None"></asp:TextBox>
            </td>
            <td style="width: 115px; height: 10px" valign="top">
                <asp:Label ID="Label8" runat="server" SkinID="Unicodelbl" Text="बिदाको किसिम" Width="105px"></asp:Label>
            </td>
            <td style="width: 165px; height: 10px" valign="top">
                <asp:DropDownList ID="ddlAppType" runat="server" SkinID="Unicodeddl" Width="160px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 100px" valign="top">
                <asp:Label ID="Label9" runat="server" SkinID="Unicodelbl" Text="अवधि देखि" Width="85px"></asp:Label>
            </td>
            <td style="width: 290px" valign="top">
                <asp:TextBox ID="txtEmpLvFrom" runat="server" SkinID="Unicodetxt" ToolTip="बिदा लिने मिति भर्नुहोस्"
                    Width="73px"></asp:TextBox>
                <asp:Label ID="Label22" runat="server" Text="*"></asp:Label>
                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender11" runat="server" AutoComplete="False"
                    CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                    CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                    CultureTimePlaceholder="" Enabled="True" Mask="9999/99/99" MaskType="Date" TargetControlID="txtEmpLvFrom">
                </ajaxToolkit:MaskedEditExtender>
            </td>
            <td style="width: 115px" valign="top">
                <asp:Label ID="Label10" runat="server" SkinID="Unicodelbl" Text="अवधि सम्म" Width="93px"></asp:Label>
            </td>
            <td style="width: 165px" valign="top">
                <asp:TextBox ID="txtEmpLvTo" runat="server" AutoPostBack="True" OnTextChanged="txtEmpLvTo_TextChanged"
                    SkinID="Unicodetxt" ToolTip="बिदा चाहिने दिन सम्मको मिति भर्नुहोस्" Width="73px"></asp:TextBox>
                <asp:Label ID="Label23" runat="server" Text="*"></asp:Label>
                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender12" runat="server" AutoComplete="False"
                    CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                    CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                    CultureTimePlaceholder="" Enabled="True" Mask="9999/99/99" MaskType="Date" TargetControlID="txtEmpLvTo">
                </ajaxToolkit:MaskedEditExtender>
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 20px" valign="top">
                &nbsp;<asp:Label ID="Label11" runat="server" SkinID="Unicodelbl" Text="जम्मा दिन"></asp:Label>
            </td>
            <td style="width: 290px; height: 20px" valign="top">
                <asp:UpdatePanel id="UpdatePanel4" runat="server">
                    <contenttemplate>
<asp:TextBox id="txtEmpLvDays" runat="server" Width="45px" SkinID="Unicodetxt" ToolTip="जम्मा दिन" MaxLength="3"></asp:TextBox> <ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender3" runat="server" TargetControlID="txtEmpLvDays" Enabled="True" FilterType="Numbers"></ajaxToolkit:FilteredTextBoxExtender> 
</contenttemplate>
                </asp:UpdatePanel>
                &nbsp;
            </td>
            <td style="width: 115px; height: 20px" valign="top">
                &nbsp;<asp:Label ID="lblApplDate" runat="server" SkinID="Unicodelbl" Text="निवेदन मिति"
                    Width="90px"></asp:Label>
            </td>
            <td style="width: 165px; height: 20px" valign="top">
                <asp:TextBox ID="txtEmpDate" runat="server" SkinID="Unicodetxt" ToolTip="निवेदन दिएको मिति भर्नुहोस्"
                    Width="73px"></asp:TextBox>
                <asp:Label ID="Label24" runat="server" Text="*"></asp:Label>
                &nbsp;&nbsp;
                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AutoComplete="False"
                    Mask="9999/99/99" MaskType="Date" TargetControlID="txtEmpDate">
                </ajaxToolkit:MaskedEditExtender>
            </td>
        </tr>
        <tr>
            <td style="width: 100px" valign="top">
                <asp:Label ID="Label12" runat="server" SkinID="Unicodelbl" Text="कैफियत"></asp:Label>
            </td>
            <td valign="top" colspan="3">
                <asp:TextBox ID="txtEmpLvResn" runat="server" Height="80px" SkinID="Unicodetxt" TextMode="MultiLine"
                    ToolTip="बिदाको कैफिएत भर्नुहोस्" Width="525px"></asp:TextBox>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100px" valign="top">
            </td>
            <td valign="top" align="right" colspan="3">
                <asp:Button ID="btnApplSubmit" runat="server" OnClick="btnApplSubmit_Click" SkinID="Normal"
                    Text="Submit" />
                <asp:Button ID="btnApplCancel" runat="server" OnClick="btnApplCancel_Click" SkinID="Cancel"
                    Text="Cancel" /></td>
        </tr>
        <tr>
            <td style="width: 100px" valign="top">
            </td>
            <td style="width: 290px" valign="top">
                &nbsp;
            </td>
            <td style="width: 115px" valign="top">
            </td>
            <td style="width: 165px" valign="top">
            </td>
        </tr>
    </table>
    
    </div>
</asp:Content>

