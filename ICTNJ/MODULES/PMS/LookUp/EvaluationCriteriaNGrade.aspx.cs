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

public partial class MODULES_PMS_LookUp_EvaluationCriteriaNGrade : System.Web.UI.Page
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
        if (Session["Login_User_Detail"] == null)
            Response.Redirect("~/MODULES/Login.aspx", true);

        //block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        if (user.MenuList.ContainsKey("3,19,1") == true)
        {
            if (this.IsPostBack == false)
            {
                this.LoadEvaluationGroup();
                this.SetCriteriaSession();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }

    void SetCriteriaSession()
    {
        Session["Criteria"] = new ATTEvaluationCriteria();
    }

    void LoadEvaluationGroup()
    {
        try
        {
            Session["EvaluationGroupListSetup"] = BLLEvaluationGroup.GetEvaluationGroupList(Default.Yes, Default.No, Default.No, "A");
            this.ddlGroup_rqd.DataSource = Session["EvaluationGroupListSetup"];
            this.ddlGroup_rqd.DataTextField = "GroupName";
            this.ddlGroup_rqd.DataValueField = "GroupID";
            this.ddlGroup_rqd.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
    protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ClearCriteria();
        this.ClearGrade();
        this.grdGrade.SelectedIndex = -1;
        this.grdGrade.DataSource = "";        
        this.grdGrade.DataBind();
        List<ATTEvaluationGroup> lstGrp = (List<ATTEvaluationGroup>)Session["EvaluationGroupListSetup"];
        this.lstCriteria.DataSource = lstGrp[this.ddlGroup_rqd.SelectedIndex].LstEvaluationCriteria;
        this.lstCriteria.DataTextField = "EvaluationCriteriaName";
        this.lstCriteria.DataBind();
    }
    protected void lstCriteria_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTEvaluationGroup> lstGrp = (List<ATTEvaluationGroup>)Session["EvaluationGroupListSetup"];
        ATTEvaluationCriteria crit = lstGrp[this.ddlGroup_rqd.SelectedIndex].LstEvaluationCriteria[this.lstCriteria.SelectedIndex];
        
        this.txtCriteria_rqd.Text = crit.EvaluationCriteriaName;
        this.txtFromDate_rdt.Text = crit.FromDate;
        this.txtFromDate_rdt.Enabled = false;
        this.txtToDate_rdt.Text = crit.ToDate;
        this.chkActive.Checked = (crit.Active == "Y") ? true : false;

        List<ATTEvaluationCriteriaGrade> tempList = new List<ATTEvaluationCriteriaGrade>();
        foreach (ATTEvaluationCriteriaGrade obj in crit.LstEvaluationCriteriaGrade)
        {
            ATTEvaluationCriteriaGrade grade = new ATTEvaluationCriteriaGrade();
            grade.EvaluationCriteriaID = obj.EvaluationCriteriaID;
            grade.FromDate = obj.FromDate;
            grade.EvaluationGradeID = obj.EvaluationGradeID;
            grade.EvaluationGradeName = obj.EvaluationGradeName;
            grade.TotalWeight = obj.TotalWeight;
            grade.Active = obj.Active;
            grade.Action = obj.Action;
            tempList.Add(grade);
        }

        ((ATTEvaluationCriteria)Session["Criteria"]).LstEvaluationCriteriaGrade = tempList;

        this.grdGrade.DataSource = tempList;
        this.grdGrade.DataBind();
    }

    protected void btnAddWeight_Click(object sender, EventArgs e)
    {
        if (this.ddlGroup_rqd.SelectedIndex==0)
        {
            this.lblStatusMessage.Text = "Please select Evaluation group.";
            this.programmaticModalPopup.Show();
            this.ddlGroup_rqd.Focus();
            return;
        }

        if (this.txtCriteria_rqd.Text.Trim() == "")
        {
            this.lblStatusMessage.Text = "Please enter Criteria name.";
            this.programmaticModalPopup.Show();
            this.txtCriteria_rqd.Focus();
            return;
        }

        if (this.txtFromDate_rdt.Text.Trim() == "")
        {
            this.lblStatusMessage.Text = "Please enter From date.";
            this.programmaticModalPopup.Show();
            this.txtFromDate_rdt.Focus();
            return;
        }

        ATTEvaluationCriteria crit = (ATTEvaluationCriteria)Session["Criteria"];

        ATTEvaluationCriteriaGrade obj = new ATTEvaluationCriteriaGrade();
        if (this.grdGrade.SelectedIndex >= 0)
        {
            obj.EvaluationCriteriaID = int.Parse(this.grdGrade.SelectedRow.Cells[0].Text);
            obj.FromDate = this.grdGrade.SelectedRow.Cells[1].Text;
            obj.EvaluationGradeID = int.Parse(this.grdGrade.SelectedRow.Cells[2].Text);
            if (this.grdGrade.SelectedRow.Cells[6].Text == "A")
                obj.Action = "A";
            else
                obj.Action = "E";
        }
        else
        {
            obj.EvaluationCriteriaID = 0;
            obj.FromDate = this.txtFromDate_rdt.Text;
            obj.EvaluationGradeID = 0;
            obj.Action = "A";
        }
        
        obj.EvaluationGradeName = this.txtGrade.Text;
        obj.TotalWeight = float.Parse(this.txtWeight.Text);
        obj.Active = (this.chkGrade.Checked == true ? "Y" : "N");

        if (this.grdGrade.SelectedIndex >= 0)
            crit.LstEvaluationCriteriaGrade[this.grdGrade.SelectedIndex] = obj;
        else
            crit.LstEvaluationCriteriaGrade.Add(obj);

        this.grdGrade.DataSource = crit.LstEvaluationCriteriaGrade;
        this.grdGrade.DataBind();

        this.ClearGrade();
        this.grdGrade.SelectedIndex = -1;
    }

    void ClearGrade()
    {
        this.txtGrade.Text = "";
        this.txtWeight.Text = "";
        this.chkGrade.Checked = false;
    }

    void ClearCriteria()
    {
        this.txtCriteria_rqd.Text = "";
        this.txtFromDate_rdt.Enabled = true;
        this.txtFromDate_rdt.Text = "";
        this.txtToDate_rdt.Text = "";
        this.chkActive.Checked = false;
        
        this.SetCriteriaSession();
    }

    protected void grdGrade_SelectedIndexChanged(object sender, EventArgs e)
    {
        ATTEvaluationCriteria crit = (ATTEvaluationCriteria)Session["Criteria"];
        ATTEvaluationCriteriaGrade grade = crit.LstEvaluationCriteriaGrade[this.grdGrade.SelectedIndex];

        this.txtGrade.Text = grade.EvaluationGradeName;
        this.txtWeight.Text = grade.TotalWeight.ToString();
        this.chkGrade.Checked = (grade.Active == "Y") ? true : false;
    }

    protected void grdGrade_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (this.ddlGroup_rqd.SelectedIndex == 0)
        {
            this.lblStatusMessage.Text = "Please select Evaluation group.";
            this.programmaticModalPopup.Show();
            this.ddlGroup_rqd.Focus();
            return;
        }

        ATTEvaluationCriteria crit = (ATTEvaluationCriteria)Session["Criteria"];

        crit.GroupID = int.Parse(this.ddlGroup_rqd.SelectedValue);
        crit.EvaluationCriteriaName = this.txtCriteria_rqd.Text;
        crit.FromDate = this.txtFromDate_rdt.Text;
        crit.ToDate = this.txtToDate_rdt.Text;
        crit.Active = (this.chkActive.Checked == true) ? "Y" : "N";

        if (this.lstCriteria.SelectedIndex >= 0)
        {
            List<ATTEvaluationGroup> lstGrp = (List<ATTEvaluationGroup>)Session["EvaluationGroupListSetup"];
            ATTEvaluationCriteria critSess = lstGrp[this.ddlGroup_rqd.SelectedIndex].LstEvaluationCriteria[this.lstCriteria.SelectedIndex];
            crit.EvaluationCriteriaID = critSess.EvaluationCriteriaID;
            crit.Action = "E";
        }
        else
        {
            crit.Action = "A";
        }

        ObjectValidation result = BLLEvaluationCriteria.Validate(crit);
        if (result.IsValid == false)
        {
            this.lblStatusMessage.Text = result.ErrorMessage;
            this.programmaticModalPopup.Show();
            return;
        }

        try
        {
            BLLEvaluationCriteria.AddEvaluationCriteria(crit);

            List<ATTEvaluationGroup> lstGrp = (List<ATTEvaluationGroup>)Session["EvaluationGroupListSetup"];

            if (this.lstCriteria.SelectedIndex >= 0)
                lstGrp[this.ddlGroup_rqd.SelectedIndex].LstEvaluationCriteria[this.lstCriteria.SelectedIndex] = crit;
            else
                lstGrp[this.ddlGroup_rqd.SelectedIndex].LstEvaluationCriteria.Add(crit);

            this.ClearCriteria();
            this.ClearGrade();
            this.grdGrade.DataSource = "";
            this.grdGrade.DataBind();
            this.grdGrade.SelectedIndex = -1;
            this.lstCriteria.SelectedIndex = -1;
            //this.ddlGroup_rqd.SelectedIndex = 0;
            this.lstCriteria.DataSource = lstGrp[this.ddlGroup_rqd.SelectedIndex].LstEvaluationCriteria;
            this.lstCriteria.DataBind();
            this.lblStatusMessage.Text = "Evaluation Criteria and Grade Saved Sucessfully.";
            this.programmaticModalPopup.Show();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.ClearCriteria();
        this.ClearGrade();
        this.grdGrade.DataSource = "";
        this.grdGrade.DataBind();
        this.grdGrade.SelectedIndex = -1;
        this.lstCriteria.SelectedIndex = -1;
        //this.ddlGroup_rqd.SelectedIndex = 0;
    }
}
