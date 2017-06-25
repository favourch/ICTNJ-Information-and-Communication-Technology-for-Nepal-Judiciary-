<%@ Page Language="C#" MasterPageFile="~/MODULES/CMS/CMSMasterPage.master" AutoEventWireup="true" CodeFile="OrganizationBenchType.aspx.cs" Inherits="MODULES_CMS_Bench_OrganizationBenchType" Title="CMS | Organization Bench Type" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none" />
    <ajaxtoolkit:modalpopupextender id="programmaticModalPopup" runat="server" backgroundcssclass="modalBackground"
        behaviorid="programmaticModalPopupBehavior" dropshadow="True" popupcontrolid="programmaticPopup"
        popupdraghandlecontrolid="programmaticPopupDragHandle" repositionmode="RepositionOnWindowScroll"
        targetcontrolid="hiddenTargetControlForModalPopup">
        </ajaxtoolkit:modalpopupextender>
    <asp:Panel ID="programmaticPopup" runat="server" CssClass="modalPopup" Style="display: none;
        width: 350px; padding: 10px">
        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Style="cursor: move; background-color: #DDDDDD;
            border: solid 1px Gray; color: Black; text-align: center;">
            Save Status
        </asp:Panel>
        <asp:Label ID="lblStatusMessage" runat="server"></asp:Label><br />
        <asp:Button ID="OkButton" runat="server" OnClick="hideModalPopupViaServer_Click"
            Text="OK" Width="58px" />
        <br />
    </asp:Panel>

    <asp:UpdatePanel runat="server" id="up">
    <contenttemplate>
<TABLE><TBODY><TR><TD vAlign=top align=center><asp:Label id="Label1" runat="server" Text="Bench Type" SkinID="Unicodelbl"></asp:Label></TD><TD style="WIDTH: 20px" vAlign=top></TD><TD vAlign=top align=center><TABLE width="100%"><TBODY><TR><TD style="WIDTH: 20px" align=center></TD><TD vAlign=top align=left>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label id="Label2" runat="server" Text="Organisations" SkinID="Unicodelbl"></asp:Label></TD></TR></TBODY></TABLE> </TD></TR><TR><TD vAlign=top><asp:ListBox id="lstBenchType" runat="server" Width="300px" Height="300px" SkinID="Unicodelst" OnSelectedIndexChanged="lstBenchType_SelectedIndexChanged" DataValueField="BenchTypeID" DataTextField="BenchTypeName" AutoPostBack="true"></asp:ListBox> </TD><TD style="WIDTH: 20px" vAlign=top></TD><TD vAlign=top><asp:Panel id="pnlOrganisation" runat="server" Width="400px" Height="300px" ScrollBars="Auto" HorizontalAlign="Left"><TABLE width="100%"><TBODY><TR><TD style="WIDTH: 20px" align=center></TD><TD vAlign=top align=left><asp:GridView id="grdOrganisation" runat="server" SkinID="Unicodegrd" OnRowDataBound="grdOrgBenchType_RowDataBound" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox ID="chkOrganisation" runat="server" OnCheckedChanged="chkHEADEROrganisation_CheckedChanged" AutoPostBack="true"  />                            
                            </HeaderTemplate>
                            <EditItemTemplate>
                                <asp:CheckBox ID="chkOrganisation" runat="server" OnCheckedChanged="chkOrganisation_CheckedChanged" AutoPostBack="true"  />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkOrganisation" runat="server" OnCheckedChanged="chkOrganisation_CheckedChanged" AutoPostBack="true"  />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="OrgID" HeaderText="OrgID" />
                        <asp:BoundField DataField="OrgName" HeaderText="Organisation" />
                        <asp:BoundField  HeaderText="ACTIVE" />
                    </Columns>
                </asp:GridView> </TD></TR></TBODY></TABLE></asp:Panel> &nbsp; </TD></TR><TR><TD vAlign=top></TD><TD style="WIDTH: 20px" vAlign=top></TD><TD vAlign=top></TD></TR><TR><TD vAlign=top></TD><TD style="WIDTH: 20px" vAlign=top></TD><TD vAlign=top align=center><TABLE width="100%"><TBODY><TR><TD style="WIDTH: 20px; HEIGHT: 26px" align=center></TD><TD style="HEIGHT: 26px" vAlign=top align=left><asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Text="Save" SkinID="Submit"></asp:Button>&nbsp;<asp:Button id="btnCancel" onclick="btnCancel_Click" runat="server" Text="Cancel" SkinID="Cancel"></asp:Button></TD></TR></TBODY></TABLE>&nbsp; </TD></TR></TBODY></TABLE>
</contenttemplate>
    </asp:UpdatePanel>
    
</asp:Content>

