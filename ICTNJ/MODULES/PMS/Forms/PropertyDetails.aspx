<%@ Page Language="C#" MasterPageFile="~/MODULES/PMS/PMSMasterPage.master" AutoEventWireup="true" CodeFile="PropertyDetails.aspx.cs" Inherits="MODULES_PMS_Forms_PropertyDetails" Title="PMS | Employee Property Details" %>

<%@ Register Src="../../COMMON/UserControls/PersonnelPropertyControl.ascx" TagName="PersonnelPropertyControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <asp:Label ID="Label1" runat="server" SkinID="UnicodeHeadlbl" Text="कर्मचारीको सम्पत्ति विवरण"
        Width="493px"></asp:Label><br />
    <br />
    <uc1:PersonnelPropertyControl ID="PersonnelPropertyControl1" runat="server" JudgeOrEmployeeProp="OtherEmployee" />
</asp:Content>

