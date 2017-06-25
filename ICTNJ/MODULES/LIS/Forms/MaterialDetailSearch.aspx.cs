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

using PCS.FRAMEWORK;
using PCS.LIS.ATT;
using PCS.LIS.BLL;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.SECURITY.ATT;
using PCS.REPORT;
using System.Collections.Generic;

public partial class MODULES_LIS_Forms_MaterialDetailSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack == false)
        {
            this.LoadOrganization();
            this.LoadCategory();
            this.LoadMaterialType();
            this.LoadPublisher();
        }
    }

    void LoadOrganization()
    {
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        try
        {
            List<ATTOrganization> lst = BLLOrganization.GetOrganizationByID(user.OrgID);
            lst.Insert(0, new ATTOrganization(-1, "--- Select Organization ---"));
            this.ddlOrg.DataSource = lst;
            this.ddlOrg.DataTextField = "OrgName";
            this.ddlOrg.DataValueField = "OrgID";
            this.ddlOrg.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = ex.Message;
        }
    }

    void LoadCategory()
    {
        try
        {
            List<ATTMaterialCategory> l = BLLMaterialCategory.GetMaterialCategory();
            l.Insert(0, new ATTMaterialCategory(0, "--- Select Category ---", "", ""));

            this.ddlCategory.DataSource = l;
            this.ddlCategory.DataTextField = "CategoryName";
            this.ddlCategory.DataValueField = "CategoryID";
            this.ddlCategory.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = ex.Message;
        }
    }

    void LoadMaterialType()
    {
        try
        {
            List<ATTMaterialType> l = BLLMaterialType.GetMaterialType();
            l.Insert(0, new ATTMaterialType(0, "--- Select Type ---", "", ""));

            this.ddlType.DataSource = l;
            this.ddlType.DataTextField = "MaterialTypeName";
            this.ddlType.DataValueField = "MaterialID";
            this.ddlType.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = ex.Message;
        }
    }

    void LoadPublisher()
    {
        try
        {
            List<ATTPublisher> l = BLLPublisher.GetPublisherList();
            l.Insert(0, new ATTPublisher(0, "--- Select Publisher ---", "", "", ""));

            this.ddlPublisherType.DataSource = l;
            this.ddlPublisherType.DataTextField = "PublisherName";
            this.ddlPublisherType.DataValueField = "PublisherID";
            this.ddlPublisherType.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = ex.Message;
        }
    }

    protected void ddlOrg_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadLibrary();
    }

    void LoadLibrary()
    {
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        try
        {
            this.ddlLibrary.DataSource = BLLLibrary.GetLibraryList(int.Parse(this.ddlOrg.SelectedValue), null, 'Y');
            this.ddlLibrary.DataTextField = "LibraryName";
            this.ddlLibrary.DataValueField = "LibraryID";
            this.ddlLibrary.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = ex.Message;
        }
    }

    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        CrystalReport report = new CrystalReport(Server.MapPath("~/MODULES/LIS/REPORTS/Materail Detail Report.rpt"), "LIS_ADMIN", "LIS_ADMIN");
        report.SelectionCriteria = " 1 = 1 ";
        if (this.ddlOrg.SelectedIndex > 0)
        {
            report.SelectionCriteria += " and {VW_LIB_MATERIAL_MASTER_INFO.ORG_ID} = " + this.ddlOrg.SelectedValue;
        }

        if (this.ddlLibrary.SelectedIndex > 0)
        {
            report.SelectionCriteria += " and {VW_LIB_MATERIAL_MASTER_INFO.library_ID} = " + this.ddlLibrary.SelectedValue;
        }

        if (this.txtCallNo.Text.Trim() != "")
        {
            report.SelectionCriteria += " and {VW_LIB_MATERIAL_MASTER_INFO.call_no} = '" + this.txtCallNo.Text.Trim() + "'";
        }

        if (this.ddlCategory.SelectedIndex > 0)
        {
            report.SelectionCriteria += " and {VW_LIB_MATERIAL_MASTER_INFO.category_ID} = " + this.ddlCategory.SelectedValue;
        }

        if (this.ddlType.SelectedIndex > 0)
        {
            report.SelectionCriteria += " and {VW_LIB_MATERIAL_MASTER_INFO.mt_id} = " + this.ddlType.SelectedValue;
        }

        if (this.ddlPublisherType.SelectedIndex > 0)
        {
            //report.SelectionCriteria += " and {VW_LIB_MATERIAL_MASTER_INFO.publisher_ID} = " + this.ddlPublisherType.SelectedValue;
        }

        Session["LISReport"] = report;

        string script = "";
        script += "<script language='javascript' type='text/javascript'>";
        script += "var win=window.open('./CommonReportViewer.aspx', 'popup','width=1000,height=500,directories=no,location=no,menubar=no,resizable=1,scrollbars=1,status=yes,toolbar=no');";
        script += "</script>";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "PCS", script);
    }
}
