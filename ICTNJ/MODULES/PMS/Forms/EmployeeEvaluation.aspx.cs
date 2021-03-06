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
using PCS.PMS.ATT;
using PCS.PMS.BLL;
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;
using System.Collections.Generic;


public partial class MODULES_PMS_Forms_EmployeeEvaluation : System.Web.UI.Page
{
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        //block if without login
        if (Session["Login_User_Detail"] == null) Response.Redirect("~/MODULES/Login.aspx", true);

        //block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        Session["OrgID"] = user.OrgID;
        if (user.MenuList.ContainsKey("3,17,1") == true)
        {
            if (this.IsPostBack == false)
            {
                this.SetSessionForEmployeeEvaluation();
                this.LoadEvaluationGroup();

                this.LoadDistricts();
                this.LoadOrganizationsType();

                LoadOrganizationWithChilds(int.Parse(Session["OrgID"].ToString()));
                LoadDesignations();


                this.EvaluationTab.ActiveTabIndex = 0;
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }

    void LoadDistricts()
    {
        List<ATTDistrict> lstDistricts;
        try
        {
            lstDistricts = BLLDistrict.GetDistrictList(null);
            lstDistricts.Insert(0, new ATTDistrict(0, "%fGg'xf];", "Select District", 0));

            this.ddlDistrict.DataSource = lstDistricts;
            this.ddlDistrict.DataTextField = "NepDistName";
            this.ddlDistrict.DataValueField = "DistCode";
            this.ddlDistrict.SelectedIndex = 0;
            this.ddlDistrict.DataBind();

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void LoadOrganizationsType()
    {
        List<ATTOrganizationType> lstOrgType;
        try
        {
            lstOrgType = BLLOrganizationType.GetOrgType();
            lstOrgType.Insert(0, new ATTOrganizationType("0", "%fGg'xf];"));
            this.ddlOrgType.DataSource = lstOrgType;
            this.ddlOrgType.DataTextField = "OrgTypeDesc";
            this.ddlOrgType.DataValueField = "OrgTypeCode";
            this.ddlOrgType.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void LoadEvaluationGroup()
    {
        try
        {
            Session["EvaluationGroupList"] = BLLEvaluationGroup.GetEvaluationGroupList(Default.Yes, Default.Yes, Default.Yes, "Y");
            this.ddlGroup.DataSource = Session["EvaluationGroupList"];
            this.ddlGroup.DataTextField = "GroupName";
            this.ddlGroup.DataValueField = "GroupID";
            this.ddlGroup.DataBind();

            this.ddlEvaluatorGroup.DataSource = Session["EvaluationGroupList"];
            this.ddlEvaluatorGroup.DataTextField = "GroupName";
            this.ddlEvaluatorGroup.DataValueField = "GroupID";
            this.ddlEvaluatorGroup.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void SetSessionForEmployeeEvaluation()
    {
        Session["EmployeeEvaluation"] = new ATTEmployeeEvaluation();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (this.grdEmployee.SelectedIndex < 0)
        {
            this.lblStatusMessage.Text = "Please select any employee from list.";
            this.programmaticModalPopup.Show();
            return;
        }
        ATTEmployeeEvaluation eval = (ATTEmployeeEvaluation)Session["EmployeeEvaluation"];

        eval.EmpID = int.Parse(this.lblEmpID.Text);
        eval.EvalFromDate = this.txtFromDate_rdt.Text;
        eval.EvalToDate = this.txtToDate_rdt.Text;
        eval.RegistrationNo = double.Parse(this.txtRegNO_rqd.Text);
        eval.Organization = this.txtOrganization_rqd.Text;
        eval.SubmitedDate = this.txtSubmitedDate_rdt.Text;
        if (this.hdnMode.Value == "E")
        {
            eval.Action = "E";
            eval.OldEvalFromDate = this.hdnOldDate.Value;
        }
        else
            eval.Action = "A";

        eval.EntryBy = ((ATTUserLogin)Session["Login_User_Detail"]).UserName;

        ObjectValidation evalResult = BLLEmployeeEvaluation.Validate(eval);
        if (evalResult.IsValid == false)
        {
            this.lblStatusMessage.Text = evalResult.ErrorMessage;
            this.programmaticModalPopup.Show();
            return;
        }

        try
        {
            BLLEmployeeEvaluation.AddEmployeeEvaluation(eval);
            //eval.LstEvaluationDetail.RemoveAll
            //                                    (
            //                                        delegate(ATTEmployeeEvaluationDetail de)
            //                                        {
            //                                            return de.Action == "D";
            //                                        }
            //                                    );
            this.ClearWork();
            this.grdEmployeeWork.SelectedIndex = -1;
            this.grdEvaluaitonDetail.SelectedIndex = -1;
            this.grdEmployee.SelectedIndex = -1;
            this.grdEvaluator.SelectedIndex = -1;
            this.ClearEvaluation();
            this.EvaluationTab.ActiveTabIndex = 0;
            this.lblPersonName.Text = "";
            this.colEmployee.Collapsed = true;
            this.colEmployee.ClientState = "true";

            this.lblStatusMessage.Text = "Employee Evaluation Saved Successfully.";
            this.programmaticModalPopup.Show();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void ClearEvaluation()
    {
        this.txtFromDate_rdt.Text = "";
        this.txtToDate_rdt.Text = "";
        this.txtRegNO_rqd.Text = "";
        this.txtOrganization_rqd.Text = "";
        this.txtSubmitedDate_rdt.Text = "";
        this.hdnOldDate.Value = "";

        this.dlstEvaluation.DataSource = "";
        this.dlstEvaluation.DataBind();

        this.pnlEvaluationList.GroupingText = "";

        this.grdEmployeeWork.DataSource = "";
        this.grdEmployeeWork.DataBind();

        this.grdEvaluaitonDetail.DataSource = "";
        this.grdEvaluaitonDetail.DataBind();

        this.grdEvaluator.DataSource = "";
        this.grdEvaluator.DataBind();

        this.hdnMode.Value = "A";
        this.SetSessionForEmployeeEvaluation();

        this.lblEmpID.Text = "";
        this.lblEmpName.Text = "";
        this.lblComma.Text = "";
        this.txtFromDate_rdt.Enabled = true;
    }

    protected void btnAddWork_Click(object sender, EventArgs e)
    {
        if (this.grdEmployee.SelectedIndex < 0)
        {
            this.lblStatusMessage.Text = "Please select any employee from list.";
            this.programmaticModalPopup.Show();
            return;
        }
        ATTEmployeeEvaluation eval = (ATTEmployeeEvaluation)Session["EmployeeEvaluation"];
        List<ATTEmployeeWork> empWorkLst = eval.LstEmployeeWork;

        string mode = "A";
        if (this.grdEmployeeWork.SelectedIndex > -1)
            mode = this.grdEmployeeWork.SelectedRow.Cells[10].Text;

        ATTEmployeeWork work = new ATTEmployeeWork();
        work.EmpID = int.Parse(this.lblEmpID.Text);
        work.EvalFromDate = this.txtFromDate_rdt.Text;
        if (mode == "A")
            work.WorkID = 0;
        else
            work.WorkID = int.Parse(this.grdEmployeeWork.SelectedRow.Cells[2].Text);
        work.WorkDescription = this.txtWorkDesc.Text;
        work.Unit = this.txtUnit.Text;
        work.HalfYearTarget = this.txtHalfYearTarget.Text;
        work.FullYearTarget = this.txtFullYearTarget.Text;
        work.WorkProgress = this.txtWorkProgress.Text;
        work.AssignByOffice = (this.chkByOffice.Checked == true) ? "Y" : "N";
        work.Remark = this.txtRemarks.Text;
        work.Action = "A";
        work.EntryBy = ((ATTUserLogin)Session["Login_User_Detail"]).UserName;

        ObjectValidation result = BLLEmployeeWork.Validate(work);
        if (result.IsValid==false)
        {
            this.lblStatusMessage.Text = result.ErrorMessage;
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.grdEmployeeWork.SelectedIndex < 0)
            empWorkLst.Add(work);
        else
        {
            if (mode == "A")
                work.Action = "A";
            else if (mode == "N" || mode == "E")
                work.Action = "E";

            empWorkLst[this.grdEmployeeWork.SelectedIndex] = work;
        }

        this.grdEmployeeWork.DataSource = empWorkLst;
        this.grdEmployeeWork.DataBind();
        this.grdEmployeeWork.SelectedIndex = -1;
        this.ClearWork();
    }

    void ClearWork()
    {
        this.txtWorkDesc.Text = "";
        this.txtUnit.Text = "";
        this.txtHalfYearTarget.Text = "";
        this.txtFullYearTarget.Text = "";
        this.txtWorkProgress.Text = "";
        this.txtRemarks.Text = "";
        this.chkByOffice.Checked = false;
    }

    protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.ddlGroup.SelectedIndex < 0)
            return;
        this.ddlCriteria.DataSource = ((List<ATTEvaluationGroup>)Session["EvaluationGroupList"])[this.ddlGroup.SelectedIndex].LstEvaluationCriteria;
        this.ddlCriteria.DataTextField = "EvaluationCriteriaName";
        this.ddlCriteria.DataBind();

        this.ddlGrade.Items.Clear();
    }

    protected void ddlCriteria_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.ddlCriteria.SelectedIndex < 0)
            return;
        this.ddlGrade.DataSource = ((List<ATTEvaluationGroup>)Session["EvaluationGroupList"])[this.ddlGroup.SelectedIndex].LstEvaluationCriteria[this.ddlCriteria.SelectedIndex].LstEvaluationCriteriaGrade;
        this.ddlGrade.DataTextField = "RDGradeNameWithWeight";
        this.ddlGrade.DataBind();
    }

    protected void btnAddEvalDetail_Click(object sender, EventArgs e)
    {
        if (this.grdEmployee.SelectedIndex < 0)
        {
            this.lblStatusMessage.Text = "Please select any employee from list.";
            this.programmaticModalPopup.Show();
            return;
        }
        if (this.ddlGroup.SelectedIndex <= 0)
        {
            this.lblStatusMessage.Text = "Please select group from list.";
            this.programmaticModalPopup.Show();
            this.ddlGroup.Focus();
            return;
        }

        if (this.ddlCriteria.SelectedIndex <= 0)
        {
            this.lblStatusMessage.Text = "Please select criteria from list.";
            this.programmaticModalPopup.Show();
            this.ddlGroup.Focus();
            return;
        }

        if (this.ddlGrade.SelectedIndex <= 0)
        {
            this.lblStatusMessage.Text = "Please select grade from list.";
            this.programmaticModalPopup.Show();
            this.ddlGroup.Focus();
            return;
        }

        ATTEmployeeEvaluation eval = (ATTEmployeeEvaluation)Session["EmployeeEvaluation"];

        ATTEvaluationCriteriaGrade grade = ((List<ATTEvaluationGroup>)Session["EvaluationGroupList"])[this.ddlGroup.SelectedIndex].LstEvaluationCriteria[this.ddlCriteria.SelectedIndex].LstEvaluationCriteriaGrade[this.ddlGrade.SelectedIndex];

        bool exist = eval.LstEvaluationDetail.Exists
                                                    (
                                                        delegate(ATTEmployeeEvaluationDetail de)
                                                        {
                                                            return
                                                                de.EmpID == int.Parse(this.lblEmpID.Text) &&
                                                                de.EvalFromDate == this.txtFromDate_rdt.Text.Trim() &&
                                                                de.EvaluationCriteriaID == grade.EvaluationCriteriaID &&
                                                                de.FromDate == grade.FromDate;
                                                            //de.EvaluationGradeID == grade.EvaluationGradeID;
                                                        }
                                                    );

        if (exist == true)
        {
            this.lblStatusMessage.Text = "This Grade has been already added for selected Group and Criteria.";
            this.programmaticModalPopup.Show();
            return;
        }

        ATTEmployeeEvaluationDetail evalDetail = new ATTEmployeeEvaluationDetail();
        evalDetail.EmpID = int.Parse(this.lblEmpID.Text);
        evalDetail.EvalFromDate = this.txtFromDate_rdt.Text;
        evalDetail.EvaluationCriteriaID = grade.EvaluationCriteriaID;
        evalDetail.FromDate = grade.FromDate;
        evalDetail.EvaluationGradeID = grade.EvaluationGradeID;
        evalDetail.Action = "A";
        evalDetail.EntryBy = ((ATTUserLogin)Session["Login_User_Detail"]).UserName;

        evalDetail.GroupName = this.ddlGroup.SelectedItem.Text;
        evalDetail.EvaluationCriteriaName = this.ddlCriteria.SelectedItem.Text;
        evalDetail.EvaluationGradeName = this.ddlGrade.SelectedItem.Text;

        eval.LstEvaluationDetail.Add(evalDetail);

        this.grdEvaluaitonDetail.DataSource = eval.LstEvaluationDetail;
        this.grdEvaluaitonDetail.DataBind();
        this.SetEvaluationDetailGridColor();
    }

    void SetEvaluationDetailGridColor()
    {
        foreach (GridViewRow row in this.grdEvaluaitonDetail.Rows)
        {
            if (row.Cells[8].Text == "D")
            {
                row.ForeColor = System.Drawing.Color.Red;
                ((LinkButton)row.Cells[9].Controls[0]).Text = "Undo";
            }
            else if (row.Cells[8].Text == "N" || row.Cells[8].Text == "A")
            {
                row.ForeColor = System.Drawing.Color.FromName("#1D2A5B");
                ((LinkButton)row.Cells[9].Controls[0]).Text = "Delete";
            }
        }
    }

    protected void grdEmployeeWork_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ClearWork();
        ATTEmployeeEvaluation eval = (ATTEmployeeEvaluation)Session["EmployeeEvaluation"];

        ATTEmployeeWork work = eval.LstEmployeeWork[this.grdEmployeeWork.SelectedIndex];
        this.txtWorkDesc.Text = work.WorkDescription;
        this.txtUnit.Text = work.Unit;
        this.txtHalfYearTarget.Text = work.HalfYearTarget;
        this.txtFullYearTarget.Text = work.FullYearTarget;
        this.txtWorkProgress.Text = work.WorkProgress;
        this.txtRemarks.Text = work.Remark;
        this.chkByOffice.Checked = (work.AssignByOffice == "Y" ? true : false);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
    }

    void LoadEmployeeEvaluation(double empID, string fromDate)
    {
        try
        {
            ATTEmployeeEvaluation eval = BLLEmployeeEvaluation.GetEmployeeEvaluation(empID, fromDate);

            if (eval == null)
                return;

            this.txtFromDate_rdt.Text = eval.EvalFromDate;
            this.txtToDate_rdt.Text = eval.EvalToDate;
            this.txtRegNO_rqd.Text = eval.RegistrationNo.ToString();
            this.txtOrganization_rqd.Text = eval.Organization;
            this.txtSubmitedDate_rdt.Text = eval.SubmitedDate;
            this.hdnOldDate.Value = eval.OldEvalFromDate; 

            this.grdEmployeeWork.DataSource = eval.LstEmployeeWork;
            this.grdEmployeeWork.DataBind();

            this.grdEvaluaitonDetail.DataSource=eval.LstEvaluationDetail;
            this.grdEvaluaitonDetail.DataBind();

            this.grdEvaluator.DataSource = eval.LstEmployeeEvaluator;
            this.grdEvaluator.DataBind();

            Session["EmployeeEvaluation"] = eval;
            this.hdnMode.Value = "E";
            this.txtFromDate_rdt.Enabled = false;
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void btnCancelWork_Click(object sender, EventArgs e)
    {
        this.ClearWork();
        this.grdEmployeeWork.SelectedIndex = -1;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.ClearWork();
        this.grdEmployeeWork.SelectedIndex = -1;
        this.grdEvaluaitonDetail.SelectedIndex = -1;
        this.grdEmployee.SelectedIndex = -1;
        this.grdEvaluator.SelectedIndex = -1;
        this.ClearEvaluation();
        this.lblPersonName.Text = "";
        this.colEmployee.Collapsed = true;
        this.colEmployee.ClientState = "true";
        this.EvaluationTab.ActiveTabIndex = 0;
    }

    protected void grdEvaluaitonDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ATTEmployeeEvaluation eval = (ATTEmployeeEvaluation)Session["EmployeeEvaluation"];

        if (this.grdEvaluaitonDetail.Rows[e.RowIndex].Cells[8].Text == "A")
        {
            eval.LstEvaluationDetail.RemoveAt(e.RowIndex);
            this.grdEvaluaitonDetail.DataSource = eval.LstEvaluationDetail;
            this.grdEvaluaitonDetail.DataBind();
        }
        else if (this.grdEvaluaitonDetail.Rows[e.RowIndex].Cells[8].Text == "N" || this.grdEvaluaitonDetail.Rows[e.RowIndex].Cells[8].Text == "D")
        {
            if (((LinkButton)this.grdEvaluaitonDetail.Rows[e.RowIndex].Cells[9].Controls[0]).Text == "Delete")
            {
                eval.LstEvaluationDetail[e.RowIndex].Action = "D";
                this.grdEvaluaitonDetail.DataSource = eval.LstEvaluationDetail;
                this.grdEvaluaitonDetail.DataBind();
                this.grdEvaluaitonDetail.Rows[e.RowIndex].ForeColor = System.Drawing.Color.Red;
                ((LinkButton)this.grdEvaluaitonDetail.Rows[e.RowIndex].Cells[9].Controls[0]).Text = "Undo";
            }
            else if (((LinkButton)this.grdEvaluaitonDetail.Rows[e.RowIndex].Cells[9].Controls[0]).Text == "Undo")
            {
                eval.LstEvaluationDetail[e.RowIndex].Action = "N";
                this.grdEvaluaitonDetail.DataSource = eval.LstEvaluationDetail;
                this.grdEvaluaitonDetail.DataBind();
                this.grdEvaluaitonDetail.Rows[e.RowIndex].ForeColor = System.Drawing.Color.FromName("#1D2A5B");
                ((LinkButton)this.grdEvaluaitonDetail.Rows[e.RowIndex].Cells[9].Controls[0]).Text = "Delete";
            }
        }

        this.SetEvaluationDetailGridColor();
    }

    protected void grdEvaluaitonDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        
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
        EmployeeSearch.DesType = "O";
        EmployeeSearch.IniType = 3;

        return EmployeeSearch;
    }

    protected void grdEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ClearWork();
        this.grdEmployeeWork.SelectedIndex = -1;
        this.grdEvaluaitonDetail.SelectedIndex = -1;
        this.ClearEvaluation();

        this.lblEmpID.Text = this.grdEmployee.SelectedRow.Cells[0].Text;
        this.lblComma.Text = ", ";
        this.lblEmpName.Text = "कर्मचारीको पुरा नाम::: " + this.grdEmployee.SelectedRow.Cells[5].Text;
        this.grdEmployee.SelectedRow.Focus();

        this.LoadEmployeeEvaluationList();
        this.EvaluationTab.ActiveTabIndex = 0;
    }

    void LoadEmployeeEvaluationList()
    {
        try
        {
            List<ATTEmployeeEvaluation> lst = BLLEmployeeEvaluation.GetEmployeeEvaluationList(double.Parse(this.lblEmpID.Text), "");
            if (lst.Count > 0)
            {
                this.pnlEvaluationList.GroupingText = "हाल सम्मको मुल्यांकनहरु";
                this.dlstEvaluation.DataSource = lst;
                this.dlstEvaluation.DataBind();
            }
            else
            {
                this.pnlEvaluationList.GroupingText = "यस कर्मचारीको हाल सम्म कुनै पनि मुल्यांकन गरिएको छैन! क्रिपया नया मुल्यांकन गर्नुहोस!";
                this.dlstEvaluation.DataSource = "";
                this.dlstEvaluation.DataBind();
            }
            
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void grdEmployeeWork_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[10].Visible = false;
    }

    protected void btnSearchPerson_Click(object sender, EventArgs e)
    {
        if ((this.txtPersonFName.Text.Trim() == "") && (this.txtPersonMName.Text.Trim() == "") && (this.txtCast.Text.Trim() == "") &&
            (this.ddlPersonSex.SelectedIndex == 0) && (this.ddlDistrict.SelectedIndex == 0) && (this.ddlOrgType.SelectedIndex == 0))
        {
            this.lblStatusMessage.Text = "Please Enter (Or) Select Atleast One Field.";
            this.programmaticModalPopup.Show();
            return;
        }
        List<ATTPersonSearch> lst;
        this.lblSearch.Text = "";
        try
        {
            lst = BLLEmployeeSearch.SearchPersonWithPostIF(this.GetFilterPerson());
            this.lblSearch.Text = lst.Count.ToString() + " records found.";
            this.grdPerson.DataSource = lst;
            this.grdPerson.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    private ATTPersonSearch GetFilterPerson()
    {
        ATTPersonSearch SearchPerson = new ATTPersonSearch();
        if (this.txtFName.Text.Trim() != "") SearchPerson.FirstName = this.txtFName.Text.Trim();
        if (this.txtMName.Text.Trim() != "") SearchPerson.MiddleName = this.txtMName.Text.Trim();
        if (this.txtSurName.Text.Trim() != "") SearchPerson.SurName = this.txtSurName.Text.Trim();
        if (this.ddlGender.SelectedIndex > 0) SearchPerson.Gender = this.ddlGender.SelectedValue;
        if (this.ddlDistrict.SelectedIndex > 0) SearchPerson.District = this.ddlDistrict.SelectedItem.Text;
        if (this.ddlOrgType.SelectedIndex > 0) SearchPerson.IniType = "3";
        return SearchPerson;
    }

    protected void grdPerson_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }

    string previousCat = "";
    int firstRow = -1;
    protected void grdPerson_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[3].Visible = false;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (previousCat == e.Row.Cells[0].Text)
            {
                if (this.grdPerson.Rows[firstRow].Cells[0].RowSpan == 0)
                    this.grdPerson.Rows[firstRow].Cells[0].RowSpan = 2;
                else
                    this.grdPerson.Rows[firstRow].Cells[0].RowSpan += 1;

                if (this.grdPerson.Rows[firstRow].Cells[4].RowSpan == 0)
                    this.grdPerson.Rows[firstRow].Cells[4].RowSpan = 2;
                else
                    this.grdPerson.Rows[firstRow].Cells[4].RowSpan += 1;

                if (this.grdPerson.Rows[firstRow].Cells[5].RowSpan == 0)
                    this.grdPerson.Rows[firstRow].Cells[5].RowSpan = 2;
                else
                    this.grdPerson.Rows[firstRow].Cells[5].RowSpan += 1;

                if (this.grdPerson.Rows[firstRow].Cells[6].RowSpan == 0)
                    this.grdPerson.Rows[firstRow].Cells[6].RowSpan = 2;
                else
                    this.grdPerson.Rows[firstRow].Cells[6].RowSpan += 1;

                if (this.grdPerson.Rows[firstRow].Cells[7].RowSpan == 0)
                    this.grdPerson.Rows[firstRow].Cells[7].RowSpan = 2;
                else
                    this.grdPerson.Rows[firstRow].Cells[7].RowSpan += 1;

                if (this.grdPerson.Rows[firstRow].Cells[8].RowSpan == 0)
                    this.grdPerson.Rows[firstRow].Cells[8].RowSpan = 2;
                else
                    this.grdPerson.Rows[firstRow].Cells[8].RowSpan += 1;

                if (this.grdPerson.Rows[firstRow].Cells[9].RowSpan == 0)
                    this.grdPerson.Rows[firstRow].Cells[9].RowSpan = 2;
                else
                    this.grdPerson.Rows[firstRow].Cells[9].RowSpan += 1;

                //if (this.grdPerson.Rows[firstRow].Cells[10].RowSpan == 0)
                //    this.grdPerson.Rows[firstRow].Cells[10].RowSpan = 2;
                //else
                //    this.grdPerson.Rows[firstRow].Cells[10].RowSpan += 1;


                e.Row.Cells[0].Visible = false;
                e.Row.Cells[4].Visible = false;
                e.Row.Cells[5].Visible = false;
                e.Row.Cells[6].Visible = false;
                e.Row.Cells[7].Visible = false;
                e.Row.Cells[8].Visible = false;
                e.Row.Cells[9].Visible = false;
                e.Row.Cells[10].Visible = false;
            }

            else //It's a new category
            {
                e.Row.VerticalAlign = VerticalAlign.Middle;
                previousCat = e.Row.Cells[0].Text;
                firstRow = e.Row.RowIndex;
            }
        }
        foreach (TableCell tc in e.Row.Cells)
        {
            tc.Attributes["style"] = "border-color:#5D7B9D";
        }

    }

    protected void grdPerson_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.grdPerson.SelectedRow.Focus();
        this.lblPersonName.Text = "ब्यक्तिको नाम::: " + this.grdPerson.SelectedRow.Cells[4].Text;
        string post = this.grdPerson.SelectedRow.Cells[10].Text;
        if (post == ".")
        {
            this.txtDesignation.Enabled = true;
            this.txtDesignation.Text = "";
        }
        else
        {
            this.txtDesignation.Enabled = false;
            this.txtDesignation.Text = post;
        }
        this.ddlEvaluatorGroup.Focus();
    }

    protected void btnAddEvaluator_Click(object sender, EventArgs e)
    {
        if (this.grdEmployee.SelectedIndex <= -1)
        {
            this.lblStatusMessage.Text = "Please select any employee from list.";
            this.programmaticModalPopup.Show();
            this.grdEmployee.Focus();
            return;
        }

        if (this.grdPerson.SelectedIndex <= -1)
        {
            this.lblStatusMessage.Text = "Please select any person from list.";
            this.programmaticModalPopup.Show();
            this.grdPerson.Focus();
            return;
        }

        if (this.ddlEvaluatorGroup.SelectedIndex == 0)
        {
            this.lblStatusMessage.Text = "Please select evaluation group.";
            this.programmaticModalPopup.Show();
            this.ddlEvaluatorGroup.Focus();
            return;
        }

        ATTEmployeeEvaluation eval = (ATTEmployeeEvaluation)Session["EmployeeEvaluation"];
        List<ATTEmployeeEvaluator> empEvaluatorLst = eval.LstEmployeeEvaluator;

        bool exist = empEvaluatorLst.Exists
                                            (
                                                delegate(ATTEmployeeEvaluator at)
                                                {
                                                    return
                                                        at.EmpID == int.Parse(this.lblEmpID.Text) &&
                                                        at.EvalFromDate == this.txtFromDate_rdt.Text &&
                                                        at.GroupID == int.Parse(this.ddlEvaluatorGroup.SelectedValue) &&
                                                        at.PersonID == double.Parse(this.grdPerson.SelectedRow.Cells[0].Text);
                                                }
                                            );

        if (exist==true)
        {
            this.lblStatusMessage.Text = "This Person has been already added for selected group.";
            this.programmaticModalPopup.Show();
            return;
        }

        string mode = "A";
        if (this.grdEvaluator.SelectedIndex > -1)
            mode = this.grdEvaluator.SelectedRow.Cells[11].Text;

        ATTEmployeeEvaluator evaluator = new ATTEmployeeEvaluator();
        evaluator.EmpID = int.Parse(this.lblEmpID.Text);
        evaluator.EvalFromDate = this.txtFromDate_rdt.Text;
        evaluator.GroupID = int.Parse(this.ddlEvaluatorGroup.SelectedValue);
        evaluator.GroupName = this.ddlEvaluatorGroup.SelectedItem.Text;
        evaluator.PersonID = double.Parse(this.grdPerson.SelectedRow.Cells[0].Text);
        evaluator.PersonName = this.grdPerson.SelectedRow.Cells[4].Text;
        evaluator.Designation = this.txtDesignation.Text;
        evaluator.SymbolNo = double.Parse(this.txtEvaluatorSymbol.Text);
        evaluator.Date = this.txtEvaluatorDate.Text;
        evaluator.Remark = this.txtEvaluatorRemark.Text;
        evaluator.Action = "A";
        evaluator.EntryBy = ((ATTUserLogin)Session["Login_User_Detail"]).UserName;

        if (this.grdEvaluator.SelectedIndex < 0)
            empEvaluatorLst.Add(evaluator);
        else
        {
            if (mode == "A")
                evaluator.Action = "A";
            else if (mode == "N" || mode == "E")
                evaluator.Action = "E";

            empEvaluatorLst[this.grdEvaluator.SelectedIndex] = evaluator;
        }

        this.grdEvaluator.DataSource = empEvaluatorLst;
        this.grdEvaluator.DataBind();
        this.grdEvaluator.SelectedIndex = -1;
        this.grdPerson.SelectedIndex = -1;
        this.ClearEvaluator();
        this.SetEvaluatorGridColor();
    }

    void ClearEvaluator()
    {
        this.ddlEvaluatorGroup.SelectedIndex = 0;
        this.txtDesignation.Enabled = false;
        this.txtDesignation.Text = "";
        this.txtEvaluatorDate.Text = "";
        this.txtEvaluatorSymbol.Text = "";
        this.txtEvaluatorRemark.Text = "";
        this.lblPersonName.Text = "";
    }

    protected void grdEvaluator_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[4].Visible = false;
        e.Row.Cells[10].Visible = false;
        e.Row.Cells[11].Visible = false;
    }

    protected void grdEvaluator_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ATTEmployeeEvaluation eval = (ATTEmployeeEvaluation)Session["EmployeeEvaluation"];

        if (this.grdEvaluator.Rows[e.RowIndex].Cells[11].Text == "A")
        {
            eval.LstEmployeeEvaluator.RemoveAt(e.RowIndex);
            this.grdEvaluator.DataSource = eval.LstEmployeeEvaluator;
            this.grdEvaluator.DataBind();
        }
        else if (this.grdEvaluator.Rows[e.RowIndex].Cells[11].Text == "N" || this.grdEvaluator.Rows[e.RowIndex].Cells[11].Text == "D")
        {
            if (((LinkButton)this.grdEvaluator.Rows[e.RowIndex].Cells[12].Controls[0]).Text == "Delete")
            {
                eval.LstEmployeeEvaluator[e.RowIndex].Action = "D";
                this.grdEvaluator.DataSource = eval.LstEmployeeEvaluator;
                this.grdEvaluator.DataBind();
                this.grdEvaluator.Rows[e.RowIndex].ForeColor = System.Drawing.Color.Red;
                ((LinkButton)this.grdEvaluator.Rows[e.RowIndex].Cells[12].Controls[0]).Text = "Undo";
            }
            else if (((LinkButton)this.grdEvaluator.Rows[e.RowIndex].Cells[12].Controls[0]).Text == "Undo")
            {
                eval.LstEmployeeEvaluator[e.RowIndex].Action = "N";
                this.grdEvaluator.DataSource = eval.LstEmployeeEvaluator;
                this.grdEvaluator.DataBind();
                this.grdEvaluator.Rows[e.RowIndex].ForeColor = System.Drawing.Color.FromName("#1D2A5B");
                ((LinkButton)this.grdEvaluator.Rows[e.RowIndex].Cells[12].Controls[0]).Text = "Delete";
            }
        }
        this.SetEvaluatorGridColor();
    }

    void SetEvaluatorGridColor()
    {
        foreach (GridViewRow row in this.grdEvaluator.Rows)
        {
            if (row.Cells[11].Text == "D")
            {
                row.ForeColor = System.Drawing.Color.Red;
                ((LinkButton)row.Cells[12].Controls[0]).Text = "Undo";
            }
            else if (row.Cells[11].Text == "N" || row.Cells[11].Text == "A")
            {
                row.ForeColor = System.Drawing.Color.FromName("#1D2A5B");
                ((LinkButton)row.Cells[12].Controls[0]).Text = "Delete";
            }
        }
    }

    protected void btnCancelEvaluator_Click(object sender, EventArgs e)
    {
        this.ClearEvaluator();
    }

    protected void lnkSelectEvaluation_Click(object sender, EventArgs e)
    {
        double empID = double.Parse(((LinkButton)sender).CommandArgument);
        string fromDate = ((LinkButton)sender).CommandName;

        this.LoadEmployeeEvaluation(empID, fromDate);

        this.colEmployee.Collapsed = true;
        this.colEmployee.ClientState = "true";
    }
    protected void grdEvaluaitonDetail_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //e.Row.Cells[8].Visible = false;
    }
    protected void grdEvaluator_SelectedIndexChanged(object sender, EventArgs e)
    {

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

    void LoadDesignations()
    {
        string desType = "O";
        try
        {
            List<ATTDesignation> LstDesignation = BLLDesignation.GetDesignation(null, desType);
            LstDesignation.Insert(0, new ATTDesignation(0, "छान्नुहोस", "",0,0));
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
}
