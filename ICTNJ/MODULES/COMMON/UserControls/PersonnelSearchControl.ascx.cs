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
using System.IO;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.SECURITY.ATT;
using PCS.PMS.ATT;
using PCS.PMS.BLL;

public enum JudgeOrEmployee
{
    Judge,
    OtherEmployee
}
public partial class MODULES_COMMON_UserControls_PersonnelSearchControl : System.Web.UI.UserControl
{
    private bool _ShowGridViewSelect;
    public bool ShowGridViewSelect
    {
        get { return this._ShowGridViewSelect; }
        set { this._ShowGridViewSelect = value; }
    }

    private bool _ShowGridViewProperty;
    public bool ShowGridViewProperty
    {
        get { return this._ShowGridViewProperty; }
        set { this._ShowGridViewProperty = value; }
    }

    private string _GridViewSelectURL;
    public string GridViewSelectURL
    {
        get { return this._GridViewSelectURL; }
        set { this._GridViewSelectURL = value; }
    }

    private string _GridViewPropertyURL;
    public string GridViewPropertyURL
    {
        get { return this._GridViewPropertyURL; }
        set { this._GridViewPropertyURL = value; }
    }

    private JudgeOrEmployee _JudgeOrEmployeeProp;
    public JudgeOrEmployee JudgeOrEmployeeProp
    {
        get { return this._JudgeOrEmployeeProp; }
        set { this._JudgeOrEmployeeProp = value; }
    }


    internal string strEmpID
    {
        get { return this.grdEmployee.SelectedRow.Cells[0].Text; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        Session["OrgID"] = 9;//user.OrgID;
        if (!IsPostBack)
        {
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
        string desType = "";
        if (this.JudgeOrEmployeeProp == JudgeOrEmployee.Judge)
            desType = "J";
        if (this.JudgeOrEmployeeProp == JudgeOrEmployee.OtherEmployee)
            desType = "O";
        try
        {
            List<ATTDesignation> LstDesignation = BLLDesignation.GetDesignation(null,desType);
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
            && this.ddlOrganization.SelectedIndex == 0 && this.ddlDesignation.SelectedIndex == 0)
        {
            this.lblStatusMessage.Text = "All Fields Cannot Be Empty.";
            this.programmaticModalPopup.Show();
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
        if (this.JudgeOrEmployeeProp == JudgeOrEmployee.Judge)
            EmployeeSearch.DesType = "J";
        if (this.JudgeOrEmployeeProp == JudgeOrEmployee.OtherEmployee)
            EmployeeSearch.DesType = "O";

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
        e.Row.Cells[9].Visible = ShowGridViewSelect;
        e.Row.Cells[10].Visible = ShowGridViewProperty;
        e.Row.Cells[11].Visible = false;


        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[11].Text == "" || e.Row.Cells[11].Text == "&nbsp;")
            {
                LinkButton b = (LinkButton)e.Row.Cells[10].Controls[0];
                b.Text = "";
            }

        }
    }

    protected void grdEmployee_RowCreated(object sender, GridViewRowEventArgs e)
    {


    }

    protected void grdEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = grdEmployee.Rows[this.grdEmployee.SelectedIndex];
        Session["EmpID"] = row.Cells[0].Text;
        Session["EmpFullName"] = row.Cells[5].Text;
        if (this.GridViewSelectURL != null)
        {
            string strUrl = this.GridViewSelectURL.Trim();
            Response.Redirect(strUrl);
        }

    }
    protected void grdEmployee_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewRow row = grdEmployee.Rows[e.NewEditIndex];
        Session["PropDetailsEmpID"] = row.Cells[0].Text;
        if (this.GridViewPropertyURL != null)
        {
            string strUrl = this.GridViewPropertyURL.Trim();
            Response.Redirect(strUrl);
        }

    }
}
