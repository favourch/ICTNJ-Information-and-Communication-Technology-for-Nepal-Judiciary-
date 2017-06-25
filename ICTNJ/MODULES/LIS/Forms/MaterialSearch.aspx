<%@ Page Language="C#" MasterPageFile="~/MODULES/COMMON/MasterPage.master" AutoEventWireup="true" CodeFile="MaterialSearch.aspx.cs" Inherits="MODULES_LIS_LookUp_MaterialSearch" Title="Search Material" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <script type="text/javascript"> 
    function SetHiddenStatus()
    {
        var HiddenValue = document.getElementById('<%= this.hfStatusHidden.ClientID%>').value;
        
        if(HiddenValue == "0")
            document.getElementById('<%= this.hfStatusHidden.ClientID%>').value = "1";
    }
    
//    function SetDiv()
//    {
//        obj = document.getElementById("raj");
//    
//        alert(obj.id);
//       // alert(document.getElementById("dvSearchResult").id);
//        
//       if (obj.style.visibility == "hidden")
//       {
//            obj.style.visibility = "";
//       
//            alert("hi");
//       }
//       else
//            obj.style.visibility ="hidden";
//    }
 </script>
 <script language="javascript" type="text/javascript" src="../../COMMON/JS/Validation.js"></script>

 <div style="width:100">
     &nbsp;<table width ="100%" cellpadding ="0" cellspacing="0" border="0 px" style="border-color:Red;">
       <tr>
            <td>
             &nbsp;
                    <asp:ScriptManager id="ScriptManager1" runat="server">
                    </asp:ScriptManager>
            </td>
       </tr>
       <tr>
            <td>&nbsp;</td>
       </tr>
       <tr>
            <td align ="center" valign ="top" >
                <table  width ="100%" cellpadding ="0" cellspacing="0" border="0px" style="border-color:green;">
                    <tr>
                        <td valign="middle">
                           <table width="95%" cellpadding ="0" cellspacing="0" border="0"  style="background:#c8cde4;border-color:black; position:static; ">
                                <tr>
                                    <td style="width: 36%" height ="25px" align= "left" >&nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" CssClass="headerlabel" Text="Material Search"></asp:Label></td>
                                    <td><asp:Label ID="lblStatus" runat="server" CssClass="errorlabel" ForeColor="Red"></asp:Label></td>
                                </tr>
                           </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 14px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <table width ="95%" cellpadding ="0" cellspacing="0" border="0"  style="border-color:red; ">
                                <tr>
                                    <td width ="30%" valign ="top">
                                        
                                        <table width ="100%"  cellpadding ="0" cellspacing ="0" border ="1px" style="border-color:black; ;">
                                            <tr>
                                                <td>
                                                   <table border ="0" cellpadding ="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td colspan ="2"  align ="left" style="padding-left:15px" height ="25px" valign ="top">
                                                           <asp:Label ID="lblSearchCriteria" runat="server" Text="Choose Search Criteria" CssClass="simplelabel" Font-Bold="True" ForeColor="Red"></asp:Label>
                                                            <hr />    
                                                         </td>
                                                    </tr>
                                                    <tr>
                                                         <td>
                                                           <asp:Label ID="lblLanguage" runat="server" Text="Choose Language" CssClass="simplelabel"></asp:Label>
                                                                    &nbsp;<asp:DropDownList ID="drpLanguage" runat="server" CssClass="simplelabel" Width="90px">
                                                                    </asp:DropDownList>
                                                         </td>
                                                         <td>
                                                                 <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="Searchbtn" Width="71px" OnClientClick ="callProgressbar();" OnClick="btnSearch_Click" />
                                                         </td>
                                                      </tr>
                                                      <tr>
                                                           <td valign ="top">
                                                                <table cellpadding ="0" cellspacing="0" border="0">
                                                                    <tr>
                                                                        <td style="width: 219px">&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                         <td style="background-color:lightslategray;height: 21px; width: 219px;">
                                                                            <asp:Label ID="lblSelectAuthorName" runat="server" Text="Select AuthorName" Font-Bold="True" Font-Names="Verdana" Font-Size="Small" ForeColor="White"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign ="top" style="width: 219px">
                                                                               <%-- <asp:Panel ID="pnlAuthor" runat="server" Height="195px" ScrollBars="Vertical" Width="200px" Style="position: static">--%>
                                                                                <DIV style="OVERFLOW: auto; HEIGHT: 195px" border ="0">
                                                                                <asp:GridView ID="grdAuthor" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnRowDataBound="grdAuthor_RowDataBound" CssClass="simplelabel" Width="200px" ShowHeader="False">
                                                                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                                                    <EditRowStyle BackColor="#999999" />
                                                                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                                    <Columns>
                                                                                        <asp:TemplateField>
                                                                                            <ItemTemplate>
                                                                                                <asp:CheckBox ID="chkAuthor" runat="server" />
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:BoundField DataField="AuthorID" HeaderText="Author ID" />
                                                                                        <asp:BoundField DataField="AuthorName" HeaderText=" Select Author Name" >
                                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                                        </asp:BoundField>
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                               <%--</asp:Panel>--%>
                                                                               </DIV>
                                                                               &nbsp;&nbsp;
                                                                                  
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                  
                                                           </td>
                                                           <td valign ="top">
                                                               <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="Navbtn" OnClientClick="SetHiddenStatus();clearCheckBox();clearDropDown();callProgressbar()" OnClick="btnCancel_Click" Width="70px" />
                                                           </td>
                                                      </tr>
                                                      <tr>
                                                           <td>
                                                                <table cellpadding ="0" cellspacing="0" border="0">
                                                                    <tr>
                                                                        <td style="background-color:lightslategray; height: 21px;width: 219px;">
                                                                            <asp:Label ID="lblSelectKeyword" runat="server" Text="Select Keyword" Font-Bold="True" Font-Names="Verdana" Font-Size="Small" ForeColor="White"></asp:Label>
                                                                         </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign ="top" style="width: 219px;" align ="left">
                                                                               <%-- <asp:Panel ID="pnlKeyword" runat="server" Height="190px" Width="205px" ScrollBars="Vertical" Style="position: static">--%>
                                                                                <DIV style="OVERFLOW: auto; HEIGHT: 205px;background-color:White;">
                                                                                    <asp:GridView ID="grdKeyword" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                                        CssClass="simplelabel" ForeColor="#333333" GridLines="None" OnRowDataBound="grdKeyword_RowDataBound" Width="200px" ShowHeader="False">
                                                                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                                        <Columns>
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <asp:CheckBox ID="chkKeyword" runat="server" />
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:BoundField DataField="KeywordID" HeaderText="Keyword ID" />
                                                                                            <asp:BoundField DataField="KeywordName" HeaderText="Select Keyword">
                                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                                            </asp:BoundField>
                                                                                        </Columns>
                                                                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                                                        <EditRowStyle BackColor="#999999" />
                                                                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                                    </asp:GridView>
                                                                              <%-- </asp:Panel>--%>
                                                                              </DIV>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                                                        
                                                           </td>
                                                      </tr>
                                                      <tr>
                                                            <td style="height: 69px">&nbsp;</td>
                                                        </tr>
                                                     </table>
                                                </td>
                                            </tr>
                                            
                                        </table>
                                                
                                    </td>
                                    <td width ="1px">&nbsp;</td>
                                    <td  valign ="top" style="width: 100%" >
                                          <table width ="100%"  cellpadding ="0" cellspacing ="0" border ="1px" style="border-color:black; height: 594px;">
                                            <tr>
                                                <td>
                                                        <table cellpadding ="0" cellspacing ="0" border="0px" width ="100%" style="height: 583px" >
                                                             <tr>
                                                                <td colspan ="2" align ="left" valign ="top" style="height: 45px">
                                                                      <asp:UpdatePanel id="updSearchStatus" runat="server">
                                                                          <contenttemplate>
                                                                        &nbsp;&nbsp; &nbsp;&nbsp; <asp:Label id="lblSearchStatus" runat="server" CssClass="simplelabel" ForeColor="Red" Font-Bold="True" Text="Proceed Search ..."></asp:Label>&nbsp;&nbsp;<asp:HiddenField id="hfStatusHidden" runat="server" Value="0"></asp:HiddenField> <IMG style="VISIBILITY: hidden" id="pleasewait" src="../../../MODULES/COMMON/Images/pleasewait.gif" />&nbsp; 
                                                                        <HR />
                                                                        </contenttemplate>
                                                                      </asp:UpdatePanel>
                                                                      
                                                                  </td>
                                                              </tr>
                                                              <tr>
                                                                <td valign ="top">
                                                                    <table cellpadding="0" cellspacing="0" border="0px" height ="430px"  >
                                                                         <tr >
                                                                            <td >
                                                                                 <asp:UpdatePanel id="updSearchHeader" runat="server"><contenttemplate>
                                                                                            <asp:Table id="tblSearchHeader" runat="server" CssClass="GridtblHeading" ForeColor="White" Font-Names="Verdana" Font-Bold="True" cellpadding="0" cellspacing="0" BackColor="LightSlateGray" border="1"></asp:Table> 
                                                                                            </contenttemplate><triggers>
                                                                                            <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click"></asp:AsyncPostBackTrigger>
                                                                                            </triggers>
                                                                                  </asp:UpdatePanel>
                                                                                                                                                                                                                                                                </td>
                                                                                                                                                                                                                                                            </tr>
                                                                                                                                                                                                                                                            <tr>
                                                                                                                                                                                                                                                                <td valign ="top" style="height: 487px">
                                                                                                                                                                                                                                                                        
                                                                                                                                                                                                                                                                        <asp:UpdatePanel id="updSearchResult" runat="server"><contenttemplate>
<DIV style="OVERFLOW: auto; HEIGHT: 426px" id="dvSearchResult"><asp:GridView id="grdSearchResult" runat="server" CssClass="simplelabel" Width="807px" ForeColor="#333333" ShowHeader="False" AutoGenerateColumns="False" GridLines="None" CellPadding="4" __designer:wfdid="w1" OnDataBound="grdSearchResult_DataBound" BorderColor="White" BorderWidth="1px" HorizontalAlign="Left">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:TemplateField HeaderText="S.No">
<ItemStyle Width="20px" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
<ItemTemplate>
                                                                                                 &nbsp;<%# Container.DataItemIndex + 1 %> 
                                                                                                                                                                                                                                                                                                                                                      					                                             
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      
                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
                                                                                                                                                                                                                                                                                                                                                                        
                                                                                                                                                                                                                                                                                        
                                                                                                                                                                                                                                                                                            
                                                                                                                                                                                            
                                                                                                
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="CallNO" HeaderText="Call No">
<ItemStyle Width="120px" HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="CategoryName" HeaderText="Category Name">
<ItemStyle Width="125px" HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="CategoryDescription" HeaderText="Category Description">
<ItemStyle Width="130px" HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Language" HeaderText="Language">
<ItemStyle Width="75px" HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="PublisherName" HeaderText="Publisher Name">
<ItemStyle Width="150px" HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="CorporateBody" HeaderText="Corporate Body">
<ItemStyle Width="130px" HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView>&nbsp; </DIV>
</contenttemplate>
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                <triggers>
                                                                                            <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click"></asp:AsyncPostBackTrigger>
                                                                                            </triggers>
                                                                                             </asp:UpdatePanel>
                                                                                    &nbsp;
                                                                            
                                                                            </td>
                                                                        </tr>
                                                                      
                                                                    </table>
                                                                  
                                                                </td>
                                                              </tr>
                                                            </table>
                                                           
                                                         </td>
                                                      </tr>
                                                      
                                                  </table>
                                                
                                              </td>
                                          </tr>
                                                                                    
                                     </table>   
                                           
                                </td> 
                            </tr>
                     </table>
                </td>
           </tr>
           <tr>
                <td>
                &nbsp;
               </td>
          </tr>
     </table>
  </div>
</asp:Content>

