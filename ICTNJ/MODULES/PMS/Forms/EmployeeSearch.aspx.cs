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
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.SECURITY.ATT;
using PCS.PMS.ATT;
using PCS.PMS.BLL;

public partial class MODULES_PMS_Forms_EmployeeSearch : System.Web.UI.Page
{
    internal string strEmpID
    {
        get { return this.grdEmployee.SelectedRow.Cells[0].Text; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        //block if without login
        if (Session["Login_User_Detail"] == null)
            Response.Redirect("~/MODULES/Login.aspx", true);

        //block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        Session["OrgID"] = user.OrgID;
        if (user.MenuList.ContainsKey("3,10,1") == true)
        {
            if (!IsPostBack)
            {
                ClearControls();
                LoadOrganizationWithChilds(int.Parse(Session["OrgID"].ToString()));
                LoadDesignations();
                Session["EmpID"] = null;
                Session.Remove("EmpID");
                Session["EmpFullName"] = null;
                Session.Remove("EmpFullName");
                Session["PropDetailsEmpID"] = null;
                Session.Remove("PropDetailsEmpID");
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }

    void LoadOrganizationWithChilds(int OrgID)
    {
        try
        {
            List<ATTOrganization> OrganizationList = BLLOrganization.GetOrgWithChilds(OrgID);
            OrganizationList.Insert(0, new ATTOrganization(0, "छान्नुहोस", "", "", 0));

            this.ddlOrganization.DataSource = OrganizationList;
            this.ddlOrganization.DataTextField = "ORGNAME";
            this.ddlOrganization.DataValueField = "ORGID";
            this.ddlOrganization.DataBind();

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return;
        }
    }

    void LoadDesignations()
    {
        try
        {
            List<ATTDesignation> LstDesignation = BLLDesignation.GetDesignation(null,"O");
            LstDesignation.Insert(0, new ATTDesignation(0, "छान्नुहोस", ""));
            this.ddlDesignation.DataSource = LstDesignation;
            this.ddlDesignation.DataTextField = "DesignationName";
            this.ddlDesignation.DataValueField = "DesignationID";
            this.ddlDesignation.DataBind();

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return;
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        List<ATTEmployeeSearch> lst;
        this.lblSearch.Text = "";
        if (this.txtSymbolNo.Text.Trim() == "" && this.txtFName.Text.Trim() == "" && this.txtMName.Text.Trim() == "" && this.txtSurName.Text.Trim() == ""
            && this.ddlGender.SelectedIndex == 0 && this.txtDOB.Text.Trim() == "" && this.ddlMarStatus.SelectedIndex == 0
            && this.ddlOrganization.SelectedIndex==0 && this.ddlDesignation.SelectedIndex==0)
        {
            this.lblStatusMessage.Text = "All Fields Cannot Be Empty.";
            this.programmaticModalPopup.Show();
            return;
        }
        else
        {
            try
            {
                //lst = BLLEmployeeSearch.SearchEmployee(GetFilter());
                Session["EmpSearchResult"] = BLLEmployeeSearch.SearchEmployee(GetFilter());
                lst = (List<ATTEmployeeSearch>)Session["EmpSearchResult"];
                this.lblSearch.Text = lst.Count.ToString() + " records found.";
                this.grdEmployee.DataSource = lst;
                this.grdEmployee.DataBind();
                this.grdEmployee.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                this.lblStatusMessage.Text = ex.Message;
                this.programmaticModalPopup.Show();
            }
        }
    }

    private ATTEmployeeSearch GetFilter()
    {
        ATTEmployeeSearch EmployeeSearch = new ATTEmployeeSearch();
        if (this.txtSymbolNo.Text.Trim() != "") EmployeeSearch.SymbolNo = this.txtSymbolNo.Text.Trim();
        if (this.txtFName.Text.Trim() != "") EmployeeSearch.FirstName = this.txtFName.Text.Trim();
        if (this.txtMName.Text.Trim() != "") EmployeeSearch.MiddleName = this.txtMName.Text.Trim();
        if (this.txtSurName.Text.Trim() != "") EmployeeSearch.SurName = this.txtSurName.Text.Trim();
        if (this.ddlGender.SelectedIndex > 0) EmployeeSearch.Gender = this.ddlGender.SelectedValue;
        if (this.txtDOB.Text.Trim() != "") EmployeeSearch.DOB = this.txtDOB.Text.Trim();
        if (this.ddlMarStatus.SelectedIndex > 0) EmployeeSearch.MaritalStatus = this.ddlMarStatus.SelectedValue;
        if (this.ddlOrganization.SelectedIndex > 0) EmployeeSearch.OrgID = int.Parse(this.ddlOrganization.SelectedValue);
        if (this.ddlDesignation.SelectedIndex > 0) EmployeeSearch.DesID = int.Parse(this.ddlDesignation.SelectedValue);
        EmployeeSearch.IsPosting = this.rdblstPosting.SelectedValue.Trim() == "Y" ? true : false;
        EmployeeSearch.IniUnit = ((ATTUserLogin)Session["Login_User_Detail"]).OrgID;
        //EmployeeSearch.DesType = "O";
        //EmployeeSearch.IniType = 3;

        return EmployeeSearch;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }

    void ClearControls()
    {
        this.txtSymbolNo.Text = "";
        this.txtFName.Text = "";
        this.txtMName.Text = "";
        this.txtSurName.Text = "";
        this.txtDOB.Text = "";
        this.ddlGender.SelectedIndex = 0;
        this.ddlMarStatus.SelectedIndex = 0;
        this.ddlOrganization.SelectedIndex = 0;
        this.ddlDesignation.SelectedIndex = 0;
        this.rdblstPosting.SelectedValue = "Y";
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    protected void grdEmployee_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[4].Visible = false;
        e.Row.Cells[13].Visible = false;


        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[13].Text == "" || e.Row.Cells[13].Text == "&nbsp;")
            {
                LinkButton b = (LinkButton)e.Row.Cells[12].Controls[0];
                b.Text = "";
            }

        }
    }

    protected void grdEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = grdEmployee.Rows[this.grdEmployee.SelectedIndex];
        Session["EmpID"] = row.Cells[0].Text;
        Session["EmpFullName"] = row.Cells[5].Text;
        Response.Redirect("Employee.aspx");
   
    }
    protected void grdEmployee_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewRow row = grdEmployee.Rows[e.NewEditIndex];
        Session["PropDetailsEmpID"] = row.Cells[0].Text;
        Response.Redirect("PropertyDetails.aspx");
    }
}
