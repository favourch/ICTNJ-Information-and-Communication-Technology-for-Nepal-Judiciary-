<%@ Page Language="C#" MasterPageFile="~/MODULES/LJMS/LJMSMasterPage.master" AutoEventWireup="true" CodeFile="JudgeSearch.aspx.cs" Inherits="MODULES_LJMS_Forms_JudgeSearch" Title="LJMS | Judge Search" %>

<%@ Register Src="../../COMMON/UserControls/PersonnelSearchControl.ascx" TagName="PersonnelSearchControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <asp:Label ID="Label8" runat="server" SkinID="UnicodeHeadlbl" Text="न्यायाधिशको खोजी"></asp:Label><br />
    <br />
    <uc1:PersonnelSearchControl ID="PersonnelSearchControl1" runat="server" JudgeOrEmployee="J" JudgeOrEmployeeProp="Judge" GridViewPropertyURL="JudgePropertyDetails.aspx" GridViewSelectURL="JudgeEntry.aspx" ShowGridViewProperty="true" ShowGridViewSelect="true" />
</asp:Content>

