<%@ Page Language="C#" MasterPageFile="~/MODULES/COMMON/MasterPage.master" MaintainScrollPositionOnPostback="true"     AutoEventWireup="true" CodeFile="LibraryMaterial.aspx.cs" Inherits="MODULES_LIS_Forms_LibraryMaterial" Title="LIS-Library Material" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../../COMMON/JS/Number.js"></script>

    <script language="javascript" type="text/javascript" src="../../COMMON/JS/Validation.js"></script>

    <script language="javascript" type="text/javascript" src="../../COMMON/JS/DateValidator.js"></script>

    <script language="javascript" type="text/javascript">
        function ValidateForm()
        {
            var result = validate(1);//true ot false
            if(result == false)
            {
                return false;
            }
            else if(document.getElementById("<%=this.hdnAction.ClientID%>").value == '')
            {
            var msg="";
           
            var pubDate=document.getElementById("<%=this.pubDateTxt.ClientID%>").value;
            var priceTxt=document.getElementById("<%=this.priceTxt.ClientID%>").value;
            var isbnTxt=document.getElementById("<%=this.isbnTxt.ClientID%>").value;
                if( pubDate== '')
                {
                    msg+="कृपया publication date राख्नुहोस।;"+"\n";
                   
                }
                if( priceTxt== '')
                {
                    msg+="कृपया price राख्नुहोस।;"+"\n";
                   
                }
                if(isbnTxt == '')
                {
                    msg+="कृपया  isbn no  राख्नुहोस।;"+"\n";
                   
                }
               
               if( msg!='')
               {
                alert("Error:\n"+msg);
                return false;
                }
                 if(!validateDefaultDate())
                 {
                 return false;
                 }
            
              
            }
          
        }
    
        function ViewFile()
        {
            window.open('FileViewer.aspx','popup','width=780,height=500,directories=no,location=no,menubar=no,resizable=1,scrollbars=1,status=yes,toolbar=no')
            return false;
        }
        
        function textboxMultilineMaxNumber(txt,maxLen)
        {
            try
            {
                if(txt.value.length > (maxLen-1))return false;
            }
            catch(e)
            {
            }
        }
        
        function NewWindow(path)
        {
            window.open(path,'popup','width=780,height=500,directories=no,location=no,menubar=no,resizable=1,scrollbars=1,status=yes,toolbar=no')
            return false;
        }
         function validateDefaultDate()
        {
            return validateDateByControl('<%=pubDateTxt.ClientID%>');
        }

    </script>

    <div style="width: 100%; height: auto;">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="updPnl">
            <ContentTemplate>
                <asp:Button Style="display: none" ID="hiddenTargetControlForModalPopup" runat="server">
                </asp:Button>
                <ajaxToolkit:ModalPopupExtender id="programmaticModalPopup" runat="server" BehaviorID="programmaticModalPopupBehavior"
                    TargetControlID="hiddenTargetControlForModalPopup" PopupControlID="programmaticPopup"
                    BackgroundCssClass="modalBackground" DropShadow="True" PopupDragHandleControlID="programmaticPopupDragHandle"
                    RepositionMode="RepositionOnWindowScroll">
                </ajaxToolkit:ModalPopupExtender>
                <asp:Panel Style="padding-right: 10px; display: none; padding-left: 10px; padding-bottom: 10px;
                    width: 350px; padding-top: 10px" ID="programmaticPopup" runat="server" CssClass="modalPopup">
                    <asp:Panel runat="Server" ID="programmaticPopupDragHandle" Style="cursor: move; background-color: #DDDDDD;
                        border: solid 1px Gray; color: Black; text-align: center;">
                        Save Status
                    </asp:Panel>
                    <asp:Label ID="lblStatusMessage" runat="server" Text="Label"></asp:Label><br />
                    <asp:Button ID="OkButton" runat="server" Text="OK" OnClick="hideModalPopupViaServer_Click"
                        Width="58px" />
                    <br />
                </asp:Panel>
                
                <table  cellspacing="3" width="500px" >
                    
                        <tr>
                            <td style="height: 34px" valign="middle" colspan="6">
                            <div style="padding-right: 5px; font-weight:bold; border-top: #006EA2 2px solid; padding-left: 5px;
                                                    padding-bottom: 5px; width:660px; color: #006EA2; font-family:Arial; padding-top: 5px; border-bottom: #006EA2 2px solid;
                                                    height: 20px; text-align: center">
                                                    Library Material Registration
                                                </div>
                                <asp:Label Style="position: static" ID="lblMaterialStatus" runat="server" SkinID="UnicodeHeadlbl"
                                    Font-Bold="False"></asp:Label>
                                <asp:HiddenField ID="hdnAction" runat="server"></asp:HiddenField>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label  ID="Label1" runat="server"  Text="Organization"
                                    SkinID="Unicodelbl"></asp:Label>
                            </td>
                            <td colspan="4">
                                <asp:DropDownList Style="position: static" ID="ddlOrg" runat="server" Width="535px"
                                    SkinID="Unicodeddl">
                                </asp:DropDownList>
                              </td>
                              <td>
                                <label style="font-size: large; margin-left: 3px; color: red">
                                    *</label>
                            </td>
                            
                        </tr>
                        <tr>
                            <td>
                                <asp:Label  ID="Label2" runat="server"  Text="Library"
                                    SkinID="Unicodelbl"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList  ID="ddlLibrary" runat="server" Width="200px"
                                    SkinID="Unicodeddl">
                                </asp:DropDownList>
                                </td>
                                <td  colspan="4">
                                <label style="font-size: large; margin-left: 3px; color: red">
                                    *</label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label  ID="Label4" runat="server"  Text="Category"
                                    SkinID="Unicodelbl"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList Style="position: static" ID="ddlCategory_Rqd" runat="server" Width="200px"
                                    SkinID="Unicodeddl" ToolTip="Category">
                                </asp:DropDownList>
                                </td>
                                <td>
                                <label style="font-size: large; margin-left: 3px; color: red">
                                    *</label>
                            </td>
                            <td >
                                <asp:Label Style="position: static" ID="Label3" runat="server" Width="85px" Text="Type"
                                    SkinID="Unicodelbl"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList Style="position: static" ID="ddlType_Rqd" runat="server" Width="210px"
                                    SkinID="Unicodeddl" ToolTip="Material type">
                                </asp:DropDownList>
                                </td>
                                <td>
                                <label style="font-size: large; margin-left: 3px; color: red">
                                    *</label>
                            </td>
                        </tr>
                        <tr>
                            <td >
                                <asp:Label  ID="Label5" runat="server"  Text="Call no"
                                    SkinID="Unicodelbl"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox Style="position: static" ID="txtCallNo_Rqd" runat="server" Width="192px"
                                    SkinID="Unicodetxt" ToolTip="Call no" MaxLength="20"></asp:TextBox>
                                    </td>
                                    <td>
                                <label style="font-size: large; margin-left: 3px; color: red">
                                    *</label>
                            </td>
                            <td >
                                <asp:Label Style="position: static" ID="Label13" runat="server"  Text="Language"
                                    SkinID="Unicodelbl"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList Style="position: static" ID="ddlLanguage_Rqd" runat="server" Width="210px"
                                    SkinID="Unicodeddl" ToolTip="Language">
                                </asp:DropDownList>
                                </td>
                                <td>
                                <label style="font-size: large; margin-left: 3px; color: red">
                                    *</label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label  ID="Label14" runat="server"  Text="Publisher"
                                    SkinID="Unicodelbl"></asp:Label>
                            </td>
                            <td >
                                <asp:UpdatePanel ID="updNewPublisher" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlPublisher_Rqd" runat="server" Style="position: static" Width="200px"
                                            ToolTip="Publisher" SkinID="Unicodeddl">
                                        </asp:DropDownList>
                                       
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnGetPublisher" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                             <label style="color: Red; font-size: large; margin-left: 3px">
                                            *</label>
                            </td>
                            <td colspan="3">
                               <asp:Button Style="position: static" ID="btnNewPublisher" OnClick="btnNewPublisher_Click"
                                    runat="server" Text="New" SkinID="Add" OnClientClick="return NewWindow('../lookup/LKPublisher.aspx?master=0');">
                                </asp:Button>
                                <asp:Button Style="position: static" ID="btnGetPublisher" OnClick="btnGetPublisher_Click"
                                    runat="server" Text="Get" SkinID="Add"></asp:Button>
                            </td>
                        </tr>
                        <tr>
                            <td >
                                <asp:Label Style="position: static" ID="Label16" runat="server" Width="106px" Text="Corporate body"
                                    SkinID="Unicodelbl"></asp:Label>
                            </td>
                            <td colspan="5">
                                <asp:TextBox Style="position: static" ID="txtCorporateBody" onkeypress="return textboxMultilineMaxNumber(this,149);"
                                    runat="server" Width="535px" SkinID="Unicodetxt" MaxLength="149" TextMode="MultiLine"></asp:TextBox>
                                      <label style="font-size: large; margin-left: 3px; color: red">
                                    *</label>
                            </td>
                        </tr>
                        <tr>
                            <td >
                                <asp:Label Style="position: static" ID="Label17" runat="server" Width="106px" Text="Title"
                                    SkinID="Unicodelbl"></asp:Label>
                            </td>
                            <td colspan="5">
                                <asp:TextBox Style="position: static" ID="txtTitle_Rqd" onkeypress="return textboxMultilineMaxNumber(this,149);"
                                    runat="server" Width="535px" SkinID="Unicodetxt" ToolTip="Title" MaxLength="149"
                                    TextMode="MultiLine"></asp:TextBox>
                                    <label style="font-size: large; margin-left: 3px; color: red">
                                    *</label>
                            </td>
                        </tr>
                        <tr>
                            <td >
                                <asp:Label Style="position: static" ID="Label18" runat="server" Width="106px" Text="Series statement"
                                    SkinID="Unicodelbl"></asp:Label>
                            </td>
                            <td  colspan="4">
                                <asp:TextBox Style="position: static" ID="txtSeriesState" onkeypress="return textboxMultilineMaxNumber(this,149);"
                                    runat="server" Width="535px" SkinID="Unicodetxt" MaxLength="149" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td >
                                <asp:Label Style="position: static" ID="Label19" runat="server" Width="106px" Text="Note"
                                    SkinID="Unicodelbl"></asp:Label>
                            </td>
                            <td  colspan="4">
                                <asp:TextBox Style="position: static" ID="txtNote" onkeypress="return textboxMultilineMaxNumber(this,149);"
                                    runat="server" Width="535px" SkinID="Unicodetxt" MaxLength="149" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td >
                                <asp:Label Style="position: static" ID="Label20" runat="server" Width="130px" Text="Broad subject  heading"
                                    SkinID="Unicodelbl"></asp:Label>
                            </td>
                            <td  colspan="4">
                                <asp:TextBox Style="position: static" ID="txtBrdSubHeading" onkeypress="return textboxMultilineMaxNumber(this,199);"
                                    runat="server" Width="535px" SkinID="Unicodetxt" MaxLength="199" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td >
                                <asp:Label Style="position: static" ID="Label21" runat="server" Width="106px" Text="Geographical description"
                                    SkinID="Unicodelbl"></asp:Label>
                            </td>
                            <td  colspan="4">
                                <asp:TextBox Style="position: static" ID="txtGeoDescription" onkeypress="return textboxMultilineMaxNumber(this,199);"
                                    runat="server" Width="535px" SkinID="Unicodetxt" MaxLength="199" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td >
                                <asp:Label Style="position: static" ID="Label22" runat="server" Width="106px" Text="Physical description"
                                    SkinID="Unicodelbl"></asp:Label>
                            </td>
                            <td  colspan="4">
                                <asp:TextBox Style="position: static" ID="txtPhyDescription" onkeypress="return textboxMultilineMaxNumber(this,199);"
                                    runat="server" Width="535px" SkinID="Unicodetxt" MaxLength="199" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td >
                                <asp:Label Style="position: static" ID="Label9" runat="server" Width="125px" Text=" (pdf, jpg, jpeg, gif)"
                                    SkinID="Unicodelbl"></asp:Label>
                            </td>
                            <td  colspan="4">
                                <asp:FileUpload Style="position: static" ID="fupAttachment" runat="server" Width="450px">
                                </asp:FileUpload>&nbsp;
                                <asp:LinkButton Style="position: static" ID="lnkViewFile" runat="server" SkinID="Tippani"
                                    Font-Bold="False" OnClientClick="return ViewFile();">View File</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td  colspan="2">
                                <asp:Label Style="position: static" ID="Label6" runat="server" Text="Keyword(s)"
                                    SkinID="Unicodelbl" Font-Bold="True" Font-Underline="True"></asp:Label>
                                &nbsp;<asp:Button Style="position: static" ID="btnNewKeyword" OnClick="btnAddKeyword_Click"
                                    runat="server" Text="New" SkinID="Add" OnClientClick="return NewWindow('../lookup/keyword.aspx?master=0');">
                                </asp:Button>
                                <asp:Button Style="position: static" ID="btnGetKeyword" OnClick="btnGetKeyword_Click"
                                    runat="server" Text="Get" SkinID="Add"></asp:Button>
                            </td>
                            <td style="width: 85px; height: 4px" valign="middle">
                            </td>
                            <td style="height: 4px" valign="middle" colspan="2">
                                <asp:Label Style="position: static" ID="lb" runat="server" Text="Author(s)" SkinID="Unicodelbl"
                                    Font-Bold="True" Font-Underline="True"></asp:Label>&nbsp;
                                <asp:Button Style="position: static" ID="btnNewAuthor" OnClick="btnAddKeyword_Click"
                                    runat="server" Text="New" SkinID="Add" OnClientClick="return NewWindow('../lookup/author.aspx?master=0');">
                                </asp:Button>
                                <asp:Button Style="position: static" ID="btnGetAuthor" OnClick="btnGetAuthor_Click"
                                    runat="server" Text="Get" SkinID="Add"></asp:Button>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px" valign="middle" width="350" colspan="2">
                                <asp:UpdatePanel ID="updNewKeyword" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList Style="position: static" ID="ddlKeyword" runat="server" Width="250px"
                                            SkinID="Unicodeddl">
                                        </asp:DropDownList>
                                        &nbsp;<asp:Button Style="position: static" ID="btnAddKeyword" OnClick="btnAddKeyword_Click"
                                            runat="server" Text="Add" SkinID="Add"></asp:Button>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnGetKeyword" EventName="Click"></asp:AsyncPostBackTrigger>
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="width: 85px; height: 7px" valign="middle">
                            </td>
                            <td style="height: 7px" valign="middle" width="350" colspan="2">
                                <asp:UpdatePanel ID="updNewAuthor" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList Style="position: static" ID="ddlAuthor" runat="server" Width="250px">
                                        </asp:DropDownList>
                                        &nbsp;<asp:Button Style="position: static" ID="btnAddAuthor" OnClick="btnAddAuthor_Click"
                                            runat="server" Text="Add" SkinID="Add"></asp:Button>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnGetAuthor" EventName="Click"></asp:AsyncPostBackTrigger>
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td style="valign="top" width="350" colspan="2">
                                <asp:Panel Style="overflow-x: hidden; overflow: auto; max-height: 70px" ID="pnlKeyword"
                                    runat="server" Width="300px">
                                    <asp:UpdatePanel ID="updKeyword" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView Style="position: static" ID="grdKeyword" runat="server" Width="280px"
                                                SkinID="Unicodegrd" ForeColor="#333333" CellPadding="0" AutoGenerateColumns="False">
                                                <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
                                                <Columns>
                                                    <asp:BoundField DataField="OrgID" Visible="False" HeaderText="OrgID"></asp:BoundField>
                                                    <asp:BoundField DataField="LibraryID" Visible="False" HeaderText="LibraryID"></asp:BoundField>
                                                    <asp:BoundField DataField="LMaterialID" Visible="False" HeaderText="LMaterialID">
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemStyle Width="20px" HorizontalAlign="Center"></ItemStyle>
                                                        <ItemTemplate>
                                                            <asp:CheckBox Style="position: static" ID="chkKeyword" runat="server" SkinID="smallChk"
                                                                Checked='<%# Eval("HasChecked") %>'></asp:CheckBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="KeywordID" Visible="False" HeaderText="Sno">
                                                        <ItemStyle Width="25px" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Keyword" HeaderText="Keyword">
                                                        <ItemStyle Width="235px" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="EntryBy" Visible="False" HeaderText="EntryBy"></asp:BoundField>
                                                    <asp:BoundField DataField="EntryOn" Visible="False" HeaderText="EntryOn"></asp:BoundField>
                                                    <asp:BoundField DataField="Action" Visible="False" HeaderText="Action"></asp:BoundField>
                                                </Columns>
                                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left"></RowStyle>
                                                <EditRowStyle BackColor="#999999"></EditRowStyle>
                                                <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>
                                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>
                                                <HeaderStyle BackColor="#5D7B9D" ForeColor="White" HorizontalAlign="Left" Font-Bold="True">
                                                </HeaderStyle>
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                                            </asp:GridView>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnAddKeyword" EventName="Click"></asp:AsyncPostBackTrigger>
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </asp:Panel>
                            </td>
                            <td style="width: 85px; height: 30px" valign="top">
                            </td>
                            <td style=" valign="top" width="350" colspan="2">
                                <asp:Panel Style="overflow-x: hidden; overflow: auto; position: static; max-height: 70px"
                                    ID="pnlAuthor" runat="server" Width="300px">
                                    <asp:UpdatePanel ID="updAuthor" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView Style="position: static" ID="grdAuthor" runat="server" Width="280px"
                                                SkinID="Unicodegrd" ForeColor="#333333" CellPadding="0" AutoGenerateColumns="False">
                                                <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
                                                <Columns>
                                                    <asp:BoundField DataField="OrgID" Visible="False" HeaderText="OrgID"></asp:BoundField>
                                                    <asp:BoundField DataField="LibraryID" Visible="False" HeaderText="LibraryID"></asp:BoundField>
                                                    <asp:BoundField DataField="LMaterialID" Visible="False" HeaderText="LMaterialID">
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemStyle Width="20px" HorizontalAlign="Center"></ItemStyle>
                                                        <ItemTemplate>
                                                            <asp:CheckBox Style="position: static" ID="chkAuthor" runat="server" SkinID="smallChk"
                                                                Checked='<%# Eval("HasChecked") %>'></asp:CheckBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="AuthorID" Visible="False" HeaderText="Sno">
                                                        <ItemStyle Width="25px" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Author" HeaderText="Author">
                                                        <ItemStyle Width="235px" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="EntryBy" Visible="False" HeaderText="EntryBy"></asp:BoundField>
                                                    <asp:BoundField DataField="EntryOn" Visible="False" HeaderText="EntryOn"></asp:BoundField>
                                                    <asp:BoundField DataField="Action" Visible="False" HeaderText="Action"></asp:BoundField>
                                                </Columns>
                                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left"></RowStyle>
                                                <EditRowStyle BackColor="#999999"></EditRowStyle>
                                                <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>
                                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>
                                                <HeaderStyle BackColor="#5D7B9D" ForeColor="White" HorizontalAlign="Left" Font-Bold="True">
                                                </HeaderStyle>
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                                            </asp:GridView>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnAddAuthor" EventName="Click"></asp:AsyncPostBackTrigger>
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </asp:Panel>
                            </td>
                        </tr>
                      
                        <tr>
                            <td style="height: 9px" valign="middle" colspan="5">
                                 <table width="100%" >
                                    <tbody>
                                        <tr>
                                            <td colspan="6">
                                                <div style="padding-right: 5px; border-top: #006EA2 2px solid; padding-left: 5px;
                                                    padding-bottom: 5px; width:660px; color: #006EA2; font-family:Arial; padding-top: 5px; border-bottom: #006EA2 2px solid;
                                                    height: 20px; text-align: center">
                                                    Library Material Copy
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <div style="overflow-x: hidden; overflow: auto; width: 102%; max-height: 150px">
                                                    <asp:GridView ID="libMatCopyGrd" runat="server" Width="100%" OnRowDataBound="libMatCopyGrd_RowDataBound"
                                                        AutoGenerateColumns="False" OnSelectedIndexChanged="libMatCopyGrd_SelectedIndexChanged"
                                                        PageSize="5">
                                                        <Columns>
                                                            <asp:BoundField DataField="Edition" HeaderText="Edition" />
                                                            <asp:BoundField DataField="PublicationDate" HeaderText="PublicationDate" />
                                                            <asp:BoundField DataField="RegistrationDate" HeaderText="RegistrationDate" />
                                                            <asp:BoundField DataField="IsbnIssnNo" HeaderText="ISBN No" />
                                                            <asp:BoundField DataField="Price" HeaderText="Price" />
                                                            <asp:BoundField DataField="CurrencyID" HeaderText="CurrencyID" />
                                                            <asp:TemplateField HeaderText="Currency">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="currLbl" runat="server" SkinID="UnicodeLbl"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:CommandField ShowSelectButton="True" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <div style="width: 100%; border-bottom: #006EA2 2px solid; height: 5px">
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label8" runat="server" Text="Edition:" SkinID="Unicodelbl"></asp:Label>
                                            </td>
                                            
                                            
                                            <td >
                                                <asp:TextBox ID="editionTxt" runat="server" SkinID="Unicodetxt" Width="220px"  ToolTip="Edition"></asp:TextBox>
                                            </td>
                                            <td>
                                            <asp:Label id="edtVal" runat="server" Text="*" style="font-size: large; margin-left: 3px; color: red">
                                            </asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 26px">
                                                <asp:Label ID="Label10" runat="server" Text="Publication Date:" SkinID="Unicodelbl"></asp:Label>
                                            </td>
                                            <td style="height: 26px">
                                                <asp:TextBox ID="pubDateTxt" runat="server" Width="220px" SkinID="Unicodetxt" ToolTip="Pub Date"></asp:TextBox>
                                                <ajaxToolkit:MaskedEditExtender id="mskPubDate" runat="server" TargetControlID="pubDateTxt"
                                                    AutoComplete="False" Mask="9999/99/99" MaskType="Date">
                                                </ajaxToolkit:MaskedEditExtender>
                                            </td>
                                            <td>
                                            <asp:Label id="pubDateVal" runat="server" Text="*" style="font-size: large; margin-left: 3px; color: red">
                                            </asp:Label>
                                            </td>
                                            <td style="height: 26px">
                                                <asp:Label ID="Label11" runat="server"  Text="Registration Date:" SkinID="Unicodelbl"></asp:Label>
                                            </td>
                                            <td style="height: 26px">
                                                <asp:TextBox ID="regDateTxt" runat="server" Width="180px" SkinID="Unicodetxt" Enabled="false"></asp:TextBox>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label12" runat="server" Text="Price:" SkinID="Unicodelbl"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="priceTxt" runat="server" Width="220px" SkinID="Unicodetxt" ToolTip="Price"></asp:TextBox>
                                            </td>
                                            <td>
                                            <asp:Label id="priceVal" runat="server" Text="*" style="font-size: large; margin-left: 3px; color: red">
                                            </asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label24" runat="server"  Text="ISBN No:" SkinID="Unicodelbl"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="isbnTxt" runat="server" Width="180px" SkinID="Unicodetxt" ToolTip="ISBN"></asp:TextBox>
                                            </td>
                                            <td>
                                            <asp:Label id="isbnVal" runat="server"  style="font-size: large; margin-left: 3px; color: red">*
                                            </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                              <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label23" runat="server" Text="Location" SkinID="Unicodelbl"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="locTxt" runat="server" Width="220px" SkinID="Unicodetxt" ToolTip="Location"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                &nbsp;<asp:Label ID="Label15" runat="server" Text="Currency:" SkinID="Unicodelbl"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList  Width="180px" ID="ddlCurrency" runat="server" >
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <div style="border-top: #006EA2 2px solid; width: 670px; color: #006EA2; border-bottom: #006EA2 2px solid;
                                                    height: 25px; text-align: right">
                                                    <asp:Button Style="position: static" ID="btnSubmit" OnClick="btnSubmit_Click" runat="server"
                                                        Text="Submit" SkinID="Normal" OnClientClick="return ValidateForm();"></asp:Button>
                                                    <asp:Button Style="position: static" ID="btnFullCancel" OnClick="btnFullCancel_Click"
                                                        runat="server" Text="Cancel" SkinID="Cancel"></asp:Button>
                                                </div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
          
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
