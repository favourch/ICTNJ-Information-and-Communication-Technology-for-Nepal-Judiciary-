using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Collections.Generic;
using PCS.PMS.ATT;
using PCS.PMS.BLL;
using PCS.FRAMEWORK;
using PCS.SECURITY;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.REPORT;
using CrystalDecisions.Reporting;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.Enterprise;
using CrystalDecisions.ReportAppServer;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using PCS.SECURITY.ATT;


public partial class MODULES_PMS_ReportForms_RepOrgDesignationStatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }
        ////block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        //Session["OrgID"] = user.OrgID;
        Session["OrgID"] =user.OrgID;
        if (user.MenuList.ContainsKey("3,47,1") == true)
        {

            if (!Page.IsPostBack)
            {
                LoadOrganisation();
                LoadPost();
            }
        }
        else

            Response.Redirect("~/MODULES/Login.aspx", true);
    }

    public void LoadOrganisation()
    {
        //try
        //{
        //    Session["PmsRptOrgList"] = BLLOrganization.GetOrganizationNameList();
        //    this.ddlOrgName.DataSource = (List<ATTOrganization>)Session["PmsRptOrgList"];
        //    this.ddlOrgName.DataTextField = "OrgName";
        //    this.ddlOrgName.DataValueField = "OrgId";
        //    this.ddlOrgName.DataBind();

        //    ListItem a = new ListItem();
        //    a.Selected = true;
        //    a.Text = "कार्यालय छान्नुहोस्";
        //    a.Value = "0";
        //    ddlOrgName.Items.Insert(0, a);

        //}
        //catch (Exception ex)
        //{
        //    throw (ex);
        //}

     try
        {
            Session["PmsRptOrgList"] = BLLOrganization.GetOrganizationNameList();
            this.chkLstOrgName.DataSource = (List<ATTOrganization>)Session["PmsRptOrgList"];//session list data source
            this.chkLstOrgName.DataTextField = "OrgName";
            this.chkLstOrgName.DataValueField = "OrgId";
            this.chkLstOrgName.DataBind();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }
    public void LoadPost()
    {
        try
        {
            Session["PmsRptPostList"] = BLLOrganizationDesignation.GetOrganizationDesignation(null, null, "O");
            List<ATTOrganizationDesignation> lst = (List<ATTOrganizationDesignation>)Session["PmsRptPostList"];            
            this.chkLstPost.DataSource = lst;
            this.chkLstPost.DataTextField = "DesName";
            this.chkLstPost.DataValueField = "DesID";
            this.chkLstPost.DataBind();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }
    private string SetCriteria()//select checked values  only  
    {
        string strFormula = "";
        string strSelectedOrgName = "";
        string strSelectedPost = "";

        strSelectedOrgName = GetSelectedString(this.chkLstOrgName);
        if (strSelectedOrgName != "")
            strFormula += "{wv_org_designation_status.org_id} IN [" + strSelectedOrgName + "]";
        // for post 
        strSelectedPost = GetSelectedPost(this.chkLstPost);
        if (strSelectedPost != "")
            strFormula += " AND {wv_org_designation_status.des_id} IN [" + strSelectedPost + "]";

        return strFormula;

    }
    string GetSelectedString(CheckBoxList lst)
    {
        string strSelected = "";
        foreach (ListItem item in chkLstOrgName.Items)
        {
            if (item.Selected)
            {
                strSelected += item.Value + ","; // for comma seperated selected values like (1,2,3)
            }
        }
        if (strSelected != "")
            strSelected = strSelected.Remove(strSelected.LastIndexOf(','));

        return strSelected;
    }


    string GetSelectedPost(CheckBoxList lst)
    {
        string strSelected = "";
        foreach (ListItem item in chkLstPost.Items)
        {
            if (item.Selected)
            {
                strSelected += item.Value + ","; // for comma seperated selected values like (1,2,3)
            }
        }
        if (strSelected != "")
            strSelected = strSelected.Remove(strSelected.LastIndexOf(','));

        return strSelected;
    }


    //string SetCriteria()
    //{
       
    //    string strFormula = "1 = 1";

    //    if (this.ddlOrgName.SelectedIndex > 0)
    //        strFormula += " AND {wv_org_designation_status.org_id}=" + int.Parse(this.ddlOrgName.SelectedValue);
    //    if (this.ddlPost.SelectedIndex > 0)
    //        strFormula += " AND {wv_org_designation_status.des_id}=" + int.Parse(this.ddlPost.SelectedValue);
        
    //    return strFormula;
    //}
   

    protected void btnCreate_Click(object sender, EventArgs e)
    {
        try
        {
            CrystalReport report = new CrystalReport();
            report.ReportName = Server.MapPath("~") + "/MODULES/PMS/Reports/OrgdesignationStatusInfo.rpt";
            report.UserID = "PMS_ADMIN";
            report.Password = "PMS_ADMIN";

            report.SelectionCriteria = SetCriteria();

            if (report.SelectionCriteria != "")
            {
                Session["PMSReport"] = report;
                Session["PmsReportTitle"] = null;
                Session["PmsReportTitle"] = "PMS | Designation Status Report";

                string script = "";
                script += "<script language='javascript' type='text/javascript'>";
                script += "var win=window.open('./CommonReportViewer.aspx', 'popup','width=802,height=500,directories=no,location=no,menubar=no,resizable=1,scrollbars=1,status=no,toolbar=no');";
                script += "</script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "PCS", script);

            }
            else
            {
                this.lblStatusMessage.Text = "All Fields Cannot Be Empty.";
                this.programmaticModalPopup.Show();
            }
            


        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }
   
 
    //protected void ddlOrgName_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    this.ddlPost.DataSource = "";
    //    this.ddlPost.Items.Clear();//1st clear the dropdown list

    //    try
    //    {
    //        Session["PmsRptPostList"] = BLLOrganizationDesignation.GetOrganizationDesignation(null, null, "O");
    //        List<ATTOrganizationDesignation> lst = (List<ATTOrganizationDesignation>)Session["PmsRptPostList"];
    //        if (lst.Count > 0)
    //        {
    //            ATTOrganizationDesignation obj = new ATTOrganizationDesignation();
    //            obj.DesName = "पद छान्नुहोस्";
    //            lst.Insert(0, obj);
    //        }
    //        this.ddlPost.DataSource = lst;
    //        this.ddlPost.DataTextField = "DesName";
    //        this.ddlPost.DataValueField = "DesID";
    //        this.ddlPost.DataBind();

    //    }
    //    catch (Exception ex)
    //    {
    //        throw (ex);
    //    }
    //}
    protected void btnCancel_Click(object sender, EventArgs e)
    {

        chkLstOrgName.ClearSelection();
        chkLstPost.ClearSelection();
    }
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        programmaticModalPopup.Hide();
    }
}
