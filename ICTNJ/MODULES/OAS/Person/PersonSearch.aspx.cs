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
using PCS.OAS.ATT;
using PCS.OAS.BLL;
using PCS.PMS.ATT;
using PCS.PMS.BLL;

public partial class MODULES_OAS_Person_PersonSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        Session["OrgID"] = 9;//user.OrgID;
        if (!IsPostBack)
        {
            LoadOrganizationWithChilds(int.Parse(Session["OrgID"].ToString()));
            LoadDesignations();
            this.LoadCommitteePost();
            Session["EmpID"] = null;
            Session.Remove("EmpID");
            Session["EmpFullName"] = null;
            Session.Remove("EmpFullName");
            Session["PropDetailsEmpID"] = null;
            Session.Remove("PropDetailsEmpID");
        }
    }

    void LoadCommitteePost()
    {
        try
        {
            this.ddlCommitteePost.DataSource = BLLMemberPosition.GetMemberPositionList(null, true);
            this.ddlCommitteePost.DataTextField = "PositionName";
            this.ddlCommitteePost.DataValueField = "PositionID";
            this.ddlCommitteePost.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            List<ATTGroupPersonSearch> lstPersonSearch;
            lstPersonSearch = BLLGroupPersonSearch.GetGroupPersonWithEmployee(GetFilter(), "5, 3");
            Session["PopupPersonSearch"] = lstPersonSearch;
            this.grdEmployee.DataSource = lstPersonSearch;
            this.grdEmployee.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    private ATTGroupPersonSearch GetFilter()
    {
        ATTGroupPersonSearch SearchPerson = new ATTGroupPersonSearch();

        SearchPerson.Gender = "";
        SearchPerson.MaritalStatus = "";
        SearchPerson.IniType = "";
        SearchPerson.PostName = "";

        SearchPerson.FirstName = this.txtFName.Text.Trim();
        SearchPerson.MiddleName = this.txtMName.Text.Trim();
        SearchPerson.SurName = this.txtSurName.Text.Trim();

        if (this.ddlGender.SelectedIndex > 0) SearchPerson.Gender = this.ddlGender.SelectedValue;
        
        SearchPerson.DOB = this.txtDOB.Text.Trim();      
        
        if (this.ddlMarStatus.SelectedIndex > 0) SearchPerson.MaritalStatus = this.ddlMarStatus.SelectedValue;

        if (this.ddlOrganization.SelectedIndex > 0) SearchPerson.IniType = this.ddlOrganization.SelectedValue;

        if (this.ddlDesignation.SelectedIndex > 0) SearchPerson.PostName = this.ddlDesignation.SelectedValue;

        if (this.ddlCommittee.SelectedIndex > 0)
            SearchPerson.GroupID = int.Parse(this.ddlCommittee.SelectedValue);

        if (this.ddlCommitteePost.SelectedIndex > 0)
        SearchPerson.GMPositionID = int.Parse(this.ddlCommitteePost.SelectedValue);

        return SearchPerson;
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

        this.grdEmployee.DataSource = "";
        this.grdEmployee.DataBind();
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    protected void grdEmployee_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        //e.Row.Cells[1].Visible = false;
        //e.Row.Cells[2].Visible = false;
        //e.Row.Cells[3].Visible = false;

        if (e.Row.RowType == DataControlRowType.DataRow)
            if (((ATTPersonSearch)e.Row.DataItem).ApplicationID != 5)
                ((LinkButton)e.Row.Cells[10].Controls[0]).Enabled = false;
    }

    protected void grdEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = grdEmployee.Rows[this.grdEmployee.SelectedIndex];
        Session["EmpID"] = row.Cells[0].Text;
        Session["EmpFullName"] = row.Cells[2].Text;
        Response.Redirect("~/modules/oas/person/personnelinfo.aspx");
    }

    protected void grdEmployee_DataBound(object sender, EventArgs e)
    {
        if (this.grdEmployee.Rows.Count > 0)
        {
            this.lblSearch.Text = "Total person: " + this.grdEmployee.Rows.Count.ToString();
        }
        else
        {
            this.lblSearch.Text = "";
        }
    }
    protected void ddlOrganization_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (this.ddlOrganization.SelectedIndex <= 0)
        //{
        //    return;
        //}

        try
        {
            this.ddlCommittee.DataSource = BLLGroup.GetGroupListWithMember(int.Parse(this.ddlOrganization.SelectedValue), true, 'C');
            this.ddlCommittee.DataTextField = "GroupName";
            this.ddlCommittee.DataValueField = "GroupID";
            this.ddlCommittee.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
        }
    }
}
