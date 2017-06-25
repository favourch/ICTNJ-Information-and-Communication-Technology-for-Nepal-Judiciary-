<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true" CodeFile="InvItemsReceived.aspx.cs" Inherits="MODULES_OAS_Inventory_Forms_InvItemsReceived" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
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
            <asp:Label ID="lblStatus" runat="server" SkinID="Unicodelbl" Text="Status"></asp:Label></asp:Panel>
        <asp:Label ID="lblStatusMessage" runat="server" SkinID="Unicodelbl" Text="Label"></asp:Label><br />
        <asp:Button ID="OkButton" runat="server" Text="OK" Width="58px" />
        <br />
    </asp:Panel>
    <br />
  <script type = "text/javascript">  
    function checkAll(objRef)  
       {  
        var GridView = objRef.parentNode.parentNode.parentNode;  
        var inputList = GridView.getElementsByTagName("input");  
        for (var i=0;i<inputList.length;i++)  
        {  
            //Get the Cell To find out ColumnIndex  
            var row = inputList[i].parentNode.parentNode;  
            if(inputList[i].type == "checkbox"  && objRef != inputList[i])  
            {  
                if (objRef.checked)  
                {  
                    //If the header checkbox is checked  
                    //check all checkboxes  
                    //and highlight all rows  
                    row.style.backgroundColor = "#C2D69B";  
                    inputList[i].checked=true;  
                }  
                else  
                {  
                    //If the header checkbox is checked  
                    //uncheck all checkboxes  
                    //and change rowcolor back to original   
                    if(row.rowIndex % 2 == 0)  
                    {  
                       //Alternating Row Color  
                       row.style.backgroundColor = "#e7e2e2";  
                    }  
                    else  
                    {  
                       row.style.backgroundColor = "white";  
                    }  
                    inputList[i].checked=false;  
                }  
            }  
        }  
    }  
    function Check_Click(objRef)  
        {  
        //Get the Row based on checkbox  
        var row = objRef.parentNode.parentNode;  
        if(objRef.checked)  
        {  
            //If checked change color to Aqua  
            row.style.backgroundColor = "#C2D69B";  
        }  
        else  
        {      
            //If not checked change back to original color  
            if(row.rowIndex % 2 == 0)  
            {  
               //Alternating Row Color 
              
               row.style.backgroundColor ="#e7e2e2";
            }  
            else  
            {  
               row.style.backgroundColor = "white";  
            }  
        }  
        //Get the reference of GridView  
        var GridView = row.parentNode;  
        //Get all input elements in Gridview  
        var inputList = GridView.getElementsByTagName("input");  
        for (var i=0;i<inputList.length;i++)  
        {  
            //The First element is the Header Checkbox  
            var headerCheckBox = inputList[0];  
            //Based on all or none checkboxes  
            //are checked check/uncheck Header Checkbox  
            var checked = true;  
            if(inputList[i].type == "checkbox" && inputList[i] != headerCheckBox)  
            {  
                if(!inputList[i].checked)  
                {;  
                    break;  
                }  
            }  
        }  
        headerCheckBox.checked = "";  
    }  
</script>    

    <table>
        <tr>
            <td style="width: 100px" valign="top">
                <asp:Label ID="Label2" runat="server" Font-Size="11pt" SkinID="Unicodelbl" Text="समानको किसिम"
                    Width="107px"></asp:Label></td>
            <td style="width: 100px" valign="top">
                <asp:DropDownList ID="ddlItemsType" runat="server" SkinID="Unicodeddl" Width="238px" AutoPostBack="True" OnSelectedIndexChanged="ddlItemsType_SelectedIndexChanged">
                </asp:DropDownList></td>
            <td style="width: 100px" valign="top">
                <asp:Label ID="Label3" runat="server" SkinID="Unicodelbl" Text="बुझिलिएको मिति" Width="121px"></asp:Label></td>
            <td style="width: 100px" valign="top">
                <asp:TextBox ID="txtReceivedDate" runat="server" SkinID="Unicodetxt" Width="80px"></asp:TextBox><ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AutoComplete="False"
                    Mask="9999/99/99" MaskType="Date" TargetControlID="txtReceivedDate">
                </ajaxToolkit:MaskedEditExtender>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Panel ID="Panel2" runat="server" Height="250px" ScrollBars="Both" Width="900px">
    <asp:Label ID="Label1" runat="server" SkinID="UnicodeHeadlbl" Text="हस्तान्तरण गरिएको समानहरु" Font-Bold="False" Font-Size="11pt" Width="207px"></asp:Label>
                    <asp:GridView ID="grdItemsTransfRecv" runat="server" AutoGenerateColumns="False" CellPadding="2"
                        ForeColor="#333333" GridLines="None" HorizontalAlign="Center" OnRowCreated="grdItemsTransfRecv_RowCreated" OnSelectedIndexChanged="grdItemsTransfRecv_SelectedIndexChanged" Height="95px" Width="1500px">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:TemplateField>
                            <HeaderTemplate>
                                 <asp:CheckBox ID="chkAllItems" runat="server"  onclick = "checkAll(this);"/>
                            </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkItems" runat="server" onclick = "Check_Click(this)" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="OrgID" HeaderText="कार्यलय आईडि" >
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TransSEQ" HeaderText="क्र.सं" />
                            <asp:BoundField DataField="TransORG" HeaderText="हास्तान्तरण गर्ने कार्यलयको आईडि" />
                            <asp:BoundField DataField="TransfOrgName" HeaderText="हास्तान्तरण गर्ने कार्यलयको नाम" />
                            <asp:BoundField DataField="Quantity" HeaderText="परिमाण" />
                            <asp:BoundField DataField="DecisionDate" HeaderText="निर्णय गरिएको मिति" />
                            <asp:BoundField DataField="TransDate" HeaderText="हास्तान्तरण गरिएको मिति" />
                            <asp:BoundField DataField="TransVia" HeaderText="हस्ते" />
                            <asp:BoundField DataField="TransOrgUnit" HeaderText="हास्तान्तरण गर्ने शाखा" />
                            <asp:BoundField DataField="TransTo" HeaderText="हास्तान्तरण गर्ने ब्यक्ति" />
                            <asp:BoundField DataField="ItemsCategoryID" HeaderText="समुह आईडि" />
                            <asp:BoundField DataField="ItemsCategoryName" HeaderText="समुहको नाम" />
                            <asp:BoundField DataField="ItemsSubCategoryID" HeaderText="उप-समुह आईडि" />
                            <asp:BoundField DataField="ItemsSubCategoryName" HeaderText="उप-समुहको नाम" />
                            <asp:BoundField DataField="ItemsID" HeaderText="समानको आईडि" />
                            <asp:BoundField DataField="ItemsName" HeaderText="समानको नाम" />
                            <asp:BoundField DataField="ItemsTypeID" HeaderText="समानको प्रकार आईडि" />
                            <asp:BoundField DataField="ItemsTypeName" HeaderText="समानको प्रकार नाम" />
                            <asp:BoundField DataField="ItemsUnitID" HeaderText="समान प्रतिइकाई आईडि" />
                            <asp:BoundField DataField="ItemsUnitName" HeaderText="समानको प्रतिइकाई नाम" />
                            <asp:BoundField DataField="SeqNo" HeaderText="सिक्वेन्स न." />
                        </Columns>
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 100px">
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" SkinID="Normal"
                    Text="Submit" /></td>
            <td align="left" style="width: 100px">
                <asp:Button ID="btCancel" runat="server" OnClick="btCancel_Click" SkinID="Cancel"
                    Text="Cancel" /></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
</asp:Content>

