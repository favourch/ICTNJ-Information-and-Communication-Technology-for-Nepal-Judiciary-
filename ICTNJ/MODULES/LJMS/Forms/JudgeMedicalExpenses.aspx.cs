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
using PCS.SECURITY.ATT;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.COMMON.DLL;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.COREDL;
using PCS.FRAMEWORK;

public partial class MODULES_LJMS_Forms_MedicalExpenses : System.Web.UI.Page
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
        Session["OrgID"] = 9;
        if (user.MenuList.ContainsKey("2,20,1") == true)
        {
            if (!IsPostBack)
            {
                LoadOrganizationWithChilds(int.Parse(Session["OrgID"].ToString()));
                LoadDesignations();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }
    void LoadDesignations()
    {
        string desType = "J";
        try
        {
            List<ATTDesignation> LstDesignation = BLLDesignation.GetDesignation(null, desType);
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

    void LoadEmployeeMedicalExpenses(double empID)
    {
        try
        {
            List<ATTEmployeeMedicalExp> EmpMedExpList = BLLEmployeeMedicalExp.GetEmployeeMedicalExp(empID);
            Session["EmpMedExpList"] = EmpMedExpList;
            this.grdMedicalExp.DataSource = EmpMedExpList;
            this.grdMedicalExp.DataBind();
        }

        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void grdMedicalExp_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTEmployeeMedicalExp> EmpMedExpList = (List<ATTEmployeeMedicalExp>)Session["EmpMedExpList"];
        this.txtParticulars_Rqd.Text = EmpMedExpList[this.grdMedicalExp.SelectedIndex].Particulars;
        this.txtDateTaken_RDT.Text = EmpMedExpList[this.grdMedicalExp.SelectedIndex].DateTaken;
        this.txtAmountTaken_Rqd.Text = EmpMedExpList[this.grdMedicalExp.SelectedIndex].AmountTaken.ToString();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        List<ATTEmployeeMedicalExp> EmpMedExpList = (List<ATTEmployeeMedicalExp>)Session["EmpMedExpList"];
        string strAction = "";
        double empID = double.Parse(this.txtEmpID.Text.Trim());
        int seqNo = 0;
        if (this.grdMedicalExp.SelectedIndex > -1)
        {
            seqNo = int.Parse(this.grdMedicalExp.Rows[this.grdMedicalExp.SelectedIndex].Cells[1].Text);
            strAction = "E";
        }
        else
            strAction = "A";
        List<ATTEmployeeMedicalExp> lst = new List<ATTEmployeeMedicalExp>();
        try
        {
            ATTEmployeeMedicalExp obj = new ATTEmployeeMedicalExp(empID, seqNo, this.txtParticulars_Rqd.Text.Trim(), this.txtDateTaken_RDT.Text.Trim(), double.Parse(this.txtAmountTaken_Rqd.Text.Trim()));
            obj.EntryBy = Session["UserName"].ToString();
            obj.Action = strAction;
            lst.Add(obj);
            BLLEmployeeMedicalExp.SaveEmployeeMedicalExp(lst);
            if (this.grdMedicalExp.SelectedIndex <= -1)
                EmpMedExpList.Add(obj);
            else
                EmpMedExpList[this.grdMedicalExp.SelectedIndex] = obj;
            this.grdMedicalExp.DataSource = EmpMedExpList;
            this.grdMedicalExp.DataBind();
            if (this.grdMedicalExp.SelectedIndex <= -1)
                this.lblStatusMessage.Text = "Employee Medical Expenses Successfully Saved.";
            else
                this.lblStatusMessage.Text = "Employee Medical Expenses Successfully Modified.";
            this.programmaticModalPopup.Show();
            this.grdMedicalExp.SelectedIndex = -1;
            this.txtParticulars_Rqd.Text = "";
            this.txtDateTaken_RDT.Text = "";
            this.txtAmountTaken_Rqd.Text = "";
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void ClearControls()
    {
        this.txtEmpName_Rqd.Text = "";
        this.txtSymbolNo.Text = "";
        this.txtParticulars_Rqd.Text = "";
        this.txtDateTaken_RDT.Text = "";
        this.txtAmountTaken_Rqd.Text = "";
        this.grdMedicalExp.DataSource = "";
        this.grdMedicalExp.DataBind();
    }

    protected void grdEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.txtEmpName_Rqd.Text = "";
        this.txtSymbolNo.Text = "";
        this.txtEmpID.Text = "";
        this.txtParticulars_Rqd.Text = "";
        this.txtDateTaken_RDT.Text = "";
        this.txtAmountTaken_Rqd.Text = "";
        this.grdMedicalExp.DataSource = "";
        this.grdMedicalExp.DataBind();
        if (this.grdEmployee.SelectedIndex > -1)
        {
            this.txtEmpName_Rqd.Text = this.grdEmployee.Rows[this.grdEmployee.SelectedIndex].Cells[5].Text;
            this.txtSymbolNo.Text = this.grdEmployee.Rows[this.grdEmployee.SelectedIndex].Cells[1].Text;
            this.txtEmpID.Text = this.grdEmployee.Rows[this.grdEmployee.SelectedIndex].Cells[0].Text;
            LoadEmployeeMedicalExpenses(double.Parse(this.grdEmployee.Rows[this.grdEmployee.SelectedIndex].Cells[0].Text));
            this.colEmployee.Collapsed = true;
            this.colEmployee.ClientState = "True";
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.txtSearchSymbolNo.Text = "";
        this.txtFirstName.Text = "";
        this.txtMidName.Text = "";
        this.txtLastName.Text = "";
        this.ddlSex.SelectedIndex = 0;
        this.txtBirthDate.Text = "";
        this.ddlMarried.SelectedIndex = 0;
        this.ddlOrganization.SelectedIndex = 0;
        this.ddlDesignation.SelectedIndex = 0;
        this.grdEmployee.DataSource = null;
        this.grdEmployee.DataBind();
        this.lblSearch.Text = "";
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        List<ATTEmployeeSearch> lst;
        this.lblSearch.Text = "";
        if (this.txtSearchSymbolNo.Text.Trim() == "" && this.txtFirstName.Text.Trim() == "" && this.txtMidName.Text.Trim() == "" && this.txtLastName.Text.Trim() == ""
            && this.ddlSex.SelectedIndex == 0 && this.txtBirthDate.Text.Trim() == "" && this.ddlMarried.SelectedIndex == 0
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
        if (this.txtFirstName.Text.Trim() != "") EmployeeSearch.FirstName = this.txtFirstName.Text.Trim();
        if (this.txtMidName.Text.Trim() != "") EmployeeSearch.MiddleName = this.txtMidName.Text.Trim();
        if (this.txtLastName.Text.Trim() != "") EmployeeSearch.SurName = this.txtLastName.Text.Trim();
        if (this.ddlSex.SelectedIndex > 0) EmployeeSearch.Gender = this.ddlSex.SelectedValue;
        if (this.txtBirthDate.Text.Trim() != "") EmployeeSearch.DOB = this.txtBirthDate.Text.Trim();
        if (this.ddlMarried.SelectedIndex > 0) EmployeeSearch.MaritalStatus = this.ddlMarried.SelectedValue;
        if (this.ddlOrganization.SelectedIndex > 0) EmployeeSearch.OrgID = int.Parse(this.ddlOrganization.SelectedValue);
        if (this.ddlDesignation.SelectedIndex > 0) EmployeeSearch.DesID = int.Parse(this.ddlDesignation.SelectedValue);
        EmployeeSearch.DesType = "J";
        EmployeeSearch.IniType = 2;
        return EmployeeSearch;
    }
    protected void grdMedicalExp_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
    }
    protected void grdEmployee_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[4].Visible = false;
        e.Row.Cells[9].Visible = false;
        e.Row.Cells[10].Visible = false;
    }
}
