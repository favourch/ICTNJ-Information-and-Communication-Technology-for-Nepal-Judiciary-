<%@ Page Language="C#" MasterPageFile="~/MODULES/LJMS/LJMSMasterPage.master" AutoEventWireup="true" CodeFile="JudgePropertyDetails.aspx.cs" Inherits="MODULES_LJMS_Forms_JudgePropertyDetails" Title="LJMS | Judge Property Details" %>

<%@ Register Src="../../COMMON/UserControls/PersonnelPropertyControl.ascx" TagName="PersonnelPropertyControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <asp:Label ID="Label1" runat="server" Text="न्यायाधिशको सम्पत्ति विवरण" Width="235px" SkinID="UnicodeHeadlbl"></asp:Label><br />
    <br />
    <uc1:PersonnelPropertyControl ID="PersonnelPropertyControl1" runat="server" JudgeOrEmployeeProp="Judge" />
</asp:Content>

