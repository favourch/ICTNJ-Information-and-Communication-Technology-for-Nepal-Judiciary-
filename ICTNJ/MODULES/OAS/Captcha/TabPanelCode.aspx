<%@ Page Language="C#" MasterPageFile="~/MODULES/OAS/MasterPage.master" AutoEventWireup="true" CodeFile="TabPanelCode.aspx.cs" Inherits="MODULES_OAS_Captcha_TabPanelCode" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="width:100%; height:auto">
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Hide" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Show" /><br />
        &nbsp;<cc1:tabcontainer id="EvaluationTab" runat="server" activetabindex="2" cssclass="ajax_tab_theme" height="600px" width="950px">
            <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                <ContentTemplate>
Panel 1
</ContentTemplate>
                <HeaderTemplate>
                    कर्मचारीको कार्य
                
</HeaderTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                <ContentTemplate>
Panel 2
</ContentTemplate>
                <HeaderTemplate>
                    मुल्यांकन बिवरण
                
</HeaderTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
                <contenttemplate>
Panel 3&nbsp;<BR /> 
</contenttemplate>
                <HeaderTemplate>
                    मुल्यांकन कर्ता
                
</HeaderTemplate>
            </ajaxToolkit:TabPanel>
        </cc1:tabcontainer></div>
</asp:Content>

