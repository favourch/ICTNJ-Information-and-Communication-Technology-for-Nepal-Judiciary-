<%@ Page Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" AutoEventWireup="true" CodeFile="BenchOrders.aspx.cs" Inherits="MODULES_CMS_Bench_BenchOrders" Title="CMS | Bench Orders" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
    <cc1:ModalPopupExtender ID="programmaticModalPopup" runat="server" BackgroundCssClass="modalBackground"
        BehaviorID="programmaticModalPopupBehavior" DropShadow="True" PopupControlID="programmaticPopup"
        PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
        TargetControlID="hiddenTargetControlForModalPopup">
    </cc1:ModalPopupExtender>
   
        <asp:Panel
            ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="padding-right: 10px;
            display: none; padding-left: 10px; padding-bottom: 10px; width: 350px; padding-top: 10px">
            <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="border-right: gray 1px solid;
                border-top: gray 1px solid; border-left: gray 1px solid; cursor: move; color: black;
                border-bottom: gray 1px solid; background-color: #dddddd; text-align: center">
                <asp:Label ID="lblStatus" runat="server" Text="Status"></asp:Label>&nbsp;</asp:Panel>
            

 <asp:UpdatePanel id="UpdatePanel3"   runat="server">
        <contenttemplate>
        <asp:Label id="lblStatusMessage" runat="server" Text=""></asp:Label> <br />
            <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
                Text="OK" Width="58px" />
                  </contenttemplate>
                  
    </asp:UpdatePanel>
            <br />
        </asp:Panel>
<asp:UpdatePanel id="UpdatePanel4"   runat="server">
        <contenttemplate>
<TABLE cellSpacing=10><TBODY><TR><TD><asp:Label id="orgLbl" runat="server" SkinID="Unicodelbl">कार्यलय छान्नुहोस्:</asp:Label> </TD><TD><asp:DropDownList id="organisationddl_Rqd" runat="server" Width="200px" SkinID="Unicodeddl" AppendDataBoundItems="true">
<asp:ListItem>---कार्यलय छान्नुहोस्---</asp:ListItem>
</asp:DropDownList> </TD></TR><TR><TD><asp:Label id="Label1" runat="server" SkinID="Unicodelbl">बेन्च किसिम:</asp:Label> </TD><TD><asp:DropDownList id="benchtypeddl" runat="server" Width="200px" SkinID="Unicodeddl"></asp:DropDownList> </TD></TR>
<TR><TD><asp:Label id="Label2" runat="server" SkinID="Unicodelbl">बेन्च मिती:</asp:Label> </TD><TD><asp:TextBox id="benchdateTxt" runat="server" Width="200px" SkinID="Unicodetxt"></asp:TextBox> <cc1:MaskedEditExtender id="MaskedEditExtender1" runat="server" TargetControlID="benchdateTxt" AutoComplete="False" MaskType="Date" Mask="9999/99/99">
    </cc1:MaskedEditExtender> </TD><TD><asp:Button id="searchBtn" onclick="searchBtn_Click" runat="server" Text="Search" SkinID="Normal"></asp:Button> </TD><TD><asp:Button id="cancelBtn" onclick="cancelBtn_Click" runat="server" Text="Cancel" SkinID="Cancel"></asp:Button></TD></TR></TBODY></TABLE>
<HR />
<DIV id="assignmentDiv" runat="server"><asp:GridView id="benchAssignmentGrid" runat="server" Width="100%" SkinID="Unicodegrd" OnRowDataBound="benchAssignmentGrid_RowDataBound" OnSelectedIndexChanged="benchAssignmentGrid_SelectedIndexChanged" AutoGenerateColumns="False">
        <Columns>
         <asp:BoundField DataField="CaseID" HeaderText="CaseID" />
            <asp:BoundField DataField="CaseNumber" HeaderText="मुद्दा नं" />
            <asp:BoundField DataField="CaseReg" HeaderText="दर्ता नं" />
            <asp:BoundField DataField="BenchNo" HeaderText="बेन्च न" />
            <asp:BoundField DataField="FromDate" HeaderText="FromDate" />
            <asp:BoundField DataField="SeqNo" HeaderText="SeqNo" />
            <asp:BoundField DataField="AssignmentDate" HeaderText="मिती" />
             <asp:BoundField DataField="Appelant" HeaderText="वादि" />
            <asp:BoundField DataField="Respondent" HeaderText="प्रतिवादि" />
            <asp:CommandField ShowSelectButton="True" SelectText="Select"  />
        </Columns>
     
    </asp:GridView>
    <HR style="FLOAT: left; WIDTH: 30%" />
<BR />   
     </DIV>
    
    <DIV><asp:GridView id="orderGrid" runat="server" Width="30%" SkinID="Unicodegrd" OnRowDataBound="orderGrid_RowDataBound" OnSelectedIndexChanged="benchAssignmentGrid_SelectedIndexChanged" AutoGenerateColumns="False">
        <Columns>
        <asp:TemplateField HeaderStyle-Width="25px">
        <ItemTemplate>
        <asp:CheckBox ID="selectCb" runat="server" />
        </ItemTemplate>
        </asp:TemplateField>
         <asp:BoundField DataField="OrdersID" HeaderText="OrderID" />
            <asp:BoundField DataField="OrdersName" HeaderText="आदेश" />
            
        </Columns>
    </asp:GridView> </DIV>
<HR style="FLOAT: left; WIDTH: 30%" />
<BR /><asp:Label id="othersLbl" runat="server" Text="अन्य:" SkinID="Unicodelbl">
</asp:Label> <asp:TextBox id="othersTxt" runat="server" SkinID="Unicodetxt" width="200px"></asp:TextBox> 
<asp:Button id="addBtn" onclick="addBtn_Click" runat="server" Width="30px" Text="+" SkinID="Normal"></asp:Button>
<asp:Button id="delBtn" onclick="delBtn_Click" runat="server" Text="-" Width="30px" SkinID="Normal"></asp:Button>

 <asp:GridView id="remarksGrid" runat="server" Width="30%" SkinID="Unicodegrd" OnRowDataBound="remarksGrid_RowDataBound" OnSelectedIndexChanged="remarksGrid_SelectedIndexChanged" AutoGenerateColumns="False" ShowHeader="False"><Columns>
<asp:BoundField DataField="BoSeqNo" HeaderText="SeqNo"></asp:BoundField>
<asp:BoundField DataField="Remarks" HeaderText="Remarks"></asp:BoundField>
<asp:CommandField ShowSelectButton="True"  ItemStyle-Width="65px"></asp:CommandField>
</Columns>
</asp:GridView> 
<HR style="FLOAT: left; WIDTH: 30%" />
<BR /><asp:Button id="saveBtn" onclick="saveBtn_Click" runat="server" Text="Save" SkinID="Normal"></asp:Button> <asp:Button id="cancelOrderBtn" onclick="cancelOrderBtn_Click" runat="server" Text="Cancel" SkinID="Cancel"></asp:Button> 
</contenttemplate>
    
    </asp:UpdatePanel>

</asp:Content>

