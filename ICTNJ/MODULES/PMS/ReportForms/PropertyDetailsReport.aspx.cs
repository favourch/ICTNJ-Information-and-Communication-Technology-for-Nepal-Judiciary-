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


using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.REPORT;
using PCS.PMS.ATT;
using PCS.PMS.BLL;
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;
using System.Collections.Generic;

public partial class MODULES_PMS_ReportForms_PropertyDetailsReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        //block if without login
        if (Session["Login_User_Detail"] == null) Response.Redirect("~/MODULES/Login.aspx", true);

        //block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        if (user.MenuList.ContainsKey("3,29,1") == true)
        {
            if (!IsPostBack)
            {
                LoadOrganisation();
                LoadOrganizationAvailablePosts();
                LoadLevel();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            ATTEmployeeDetailSearch objSearch = new ATTEmployeeDetailSearch();

            if (this.ddlOrgName.SelectedIndex > 0)
                objSearch.OrgID = int.Parse(this.ddlOrgName.SelectedValue);

            if (this.txtFName.Text.Trim() != "")
                objSearch.FirstName = this.txtFName.Text;

            if (this.txtMName.Text.Trim() != "")
                objSearch.MiddleName = this.txtMName.Text;

            if (this.txtSName.Text.Trim() != "")
                objSearch.SurName = this.txtSName.Text;

                     
            if (this.ddlPost.SelectedIndex > 0)
                objSearch.PostID = int.Parse(this.ddlPost.SelectedValue);

            if (this.ddlLevel.SelectedIndex > 0)
                objSearch.LevelID = int.Parse(this.ddlLevel.SelectedValue);

            Session["propertyReportSearch"] = BLLEmployeeDetailSearch.PropertyReportSearchList(objSearch);

            List<ATTEmployeeDetailSearch> lst = (List<ATTEmployeeDetailSearch>)Session["propertyReportSearch"];

            if (lst.Count > 0)
            {
                string count = "";

                count = lst.Count.ToString().Replace("0", "०");
                count = count.ToString().Replace("1", "१");
                count = count.ToString().Replace("2", "२");
                count = count.ToString().Replace("3", "३");
                count = count.ToString().Replace("4", "४");
                count = count.ToString().Replace("5", "५");
                count = count.ToString().Replace("6", "६");
                count = count.ToString().Replace("7", "७");
                count = count.ToString().Replace("8", "८");
                count = count.ToString().Replace("9", "९");

                lblSearchResult.Text = count + " वटा  रेकर्ड भेटिए ... ";

                this.grdEmployeeSearch.DataSource = Session["propertyReportSearch"];
                this.grdEmployeeSearch.DataBind();
            }
            else
            {
                lblSearchResult.Text = "कुनै पनि रेकर्ड भेटिएनन् ... ";

                this.grdEmployeeSearch.DataSource ="";
                this.grdEmployeeSearch.DataBind();

                this.btnGenerateRpt.Visible = false;
            }


        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }

    public void LoadOrganisation()
    {
        try
        {
            Session["PmsRptOrgList"] = BLLOrganization.GetOrganizationNameList();
            this.ddlOrgName.DataSource = (List<ATTOrganization>)Session["PmsRptOrgList"];
            this.ddlOrgName.DataTextField = "OrgName";
            this.ddlOrgName.DataValueField = "OrgId";
            this.ddlOrgName.DataBind();

            ListItem a = new ListItem();
            a.Selected = true;
            a.Text = "कार्यालय छान्नुहोस्";
            a.Value = "0";
            ddlOrgName.Items.Insert(0, a);

            //Session["PmsEmpList"] = BLLVwEmployeeOrganisationInfo.GetEmployeeOrganisationInfoList(null);


        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }

    public void LoadOrganizationAvailablePosts()
    {
        this.ddlPost.DataSource = "";
        this.ddlPost.Items.Clear();

        try
        {
            string desType = "";
            if (Session["ApplicationID"].ToString() == "2")
                desType = "J";
            else if (Session["ApplicationID"].ToString() == "3")
                desType = "O";
            Session["PmsRptPostList"] = BLLOrganizationDesignation.GetOrganizationDesignation(null, null, desType);
            List<ATTOrganizationDesignation> lst = (List<ATTOrganizationDesignation>)Session["PmsRptPostList"];
            if (lst.Count > 0)
            {
                ATTOrganizationDesignation obj = new ATTOrganizationDesignation();
                obj.DesName = "पद छान्नुहोस्";
                lst.Insert(0, obj);
            }
            this.ddlPost.DataSource = lst;
            this.ddlPost.DataTextField = "DesName";
            this.ddlPost.DataValueField = "DesID";
            this.ddlPost.DataBind();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }

    public void LoadLevel()
    {
        try
        {
            Session["PmsRptLevelList"] = BLLDesignationLevel.GetDesignationLevelList();
            List<ATTDesignationLevel> lst = (List<ATTDesignationLevel>)Session["PmsRptLevelList"];
         
            if (lst.Count > 0)
            {
                lst.Insert(0, new ATTDesignationLevel(0, "तह छान्नुहोस्"));
            }
            this.ddlLevel.DataSource = lst;
            this.ddlLevel.DataTextField = "LevelName";
            this.ddlLevel.DataValueField = "LevelID";
            this.ddlLevel.DataBind();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }
    
    protected void btnGenerateRpt_Click(object sender, EventArgs e)
    {
        try
        {

            CrystalReport report = new CrystalReport();
            report.ReportName = Server.MapPath("~") + "/MODULES/PMS/Reports/PropertyDetailsReport.rpt";
            report.UserID = "PMS_ADMIN";
            report.Password = "PMS_ADMIN";

            report.SelectionCriteria = setCriteria();

            if (report.SelectionCriteria != "")
            {
                Session["PMSReport"] = report;
                Session["PmsReportTitle"] = null;
                Session["PmsReportTitle"] = "PMS | Property Details Report";

                string script = "";
                script += "<script language='javascript' type='text/javascript'>";
                script += "var win=window.open('./CommonReportViewer.aspx', 'popup','width=802,height=500,directories=no,location=no,menubar=no,resizable=1,scrollbars=1,status=no,toolbar=no');";
                script += "</script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "PCS", script);

            }
            else
            {
                lblSearchResult.Text = " कृपया  चेकबक्समा कि्ल्क गर्नुहोस् ... ";
            }

            
        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }

    public string setCriteria()
    {
        try
        {
            string criteria = "";
            
            CheckBox cb = new CheckBox();

            foreach (GridViewRow gvrow in this.grdEmployeeSearch.Rows)
            {
                cb = (CheckBox)(gvrow.Cells[0].FindControl("chkShowReport"));
                if (cb.Checked)
                {
                    criteria += " {VW_PROP_DETAILS.EMP_ID} = " + int.Parse(gvrow.Cells[1].Text.ToString()) +" OR ";
                }
                
            }


            if (criteria.Length > 0)
                criteria = criteria.Substring(0, criteria.Length - 3);

            return criteria;

        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }

    public int[] getChecked()
    {
        try
        {
            CheckBox cbKeyword = new CheckBox();
            int[] CheckedKeywords = new int[20];
            int j = 0;

            foreach (GridViewRow gvrow in this.grdEmployeeSearch.Rows)
            {
                cbKeyword = (CheckBox)(gvrow.Cells[0].FindControl("chkShowReport"));
                if (cbKeyword.Checked)
                {
                    CheckedKeywords[j] = int.Parse(gvrow.Cells[1].Text.ToString());
                   
                }
                j++;
            }

            return CheckedKeywords;

        }
        catch (Exception ex)
        {
            throw (ex);
        }

    }

    protected void grdEmployeeSearch_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;

        if (this.grdEmployeeSearch.Rows.Count <= 0)
        {
            btnGenerateRpt.Visible = false;
        }
        else
        {
            btnGenerateRpt.Visible = true;
        }
    }

    protected void grdEmployeeSearch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[4].Text == "M")
            {
                e.Row.Cells[4].Text = "पुरुष";
            }
            else if (e.Row.Cells[4].Text == "F")
            {
                e.Row.Cells[4].Text = "महिला";
            }
            else
            {
                e.Row.Cells[4].Text = "";
            }
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            lblSearchResult.Text = "";

            this.btnGenerateRpt.Visible = false;

            this.grdEmployeeSearch.DataSource = "";
            this.grdEmployeeSearch.DataBind();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "ClearForm", "javascript:clearForm();", true);


        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }
}
