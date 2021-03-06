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

public partial class MODULES_OAS_UserControls_GroupMemberPersonSearch : System.Web.UI.UserControl
{
    public ATTUserLogin User
    {
        get
        {
            return Session["Login_User_Detail"] as ATTUserLogin;
        }
    }

    public GridView GrdMemberEmployee
    {
        get
        {
            return this.grdEmployee;
        }
    }

    private bool _EnableCommittee = false;
    public bool EnableCommittee
    {
        get { return this._EnableCommittee; }
        set { this._EnableCommittee = value; }
    }

    private int _TippaniSubjectID;
    public int TippaniSubjectID
    {
        get { return this._TippaniSubjectID; }
        set { this._TippaniSubjectID = value; }
    }

    private string _ApplicationString;
    public string ApplicationString
    {
        get { return this._ApplicationString.Trim(); }
        set { this._ApplicationString = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack == false)
        {
            this.LoadOrganization();
            this.LoadDesignation();
            this.LoadCommitteePost();

            this.ddlCommittee.Enabled = this.EnableCommittee;
            this.ddlCommitteePost.Enabled = this.EnableCommittee;
        }
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    void LoadOrganization()
    {
        try
        {
            List<ATTOrganization> lst = new List<ATTOrganization>();
            lst = BLLOrganization.GetOrganizationNameList();
            lst.Insert(0, new ATTOrganization(-1, "---- कार्यालय छन्नुहोस ----"));
            this.ddlOrganization.DataSource = lst;
            this.ddlOrganization.DataTextField = "OrgName";
            this.ddlOrganization.DataValueField = "OrgID";
            this.ddlOrganization.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void LoadDesignation()
    {
        try
        {
            List<ATTDesignation> LstDesignation = BLLDesignation.GetDesignation(null, "");
            LstDesignation.Insert(0, new ATTDesignation(0, "--- पद छान्नुहोस ---", ""));

            this.ddlDesignation.DataSource = LstDesignation;
            this.ddlDesignation.DataTextField = "DesignationName";
            this.ddlDesignation.DataValueField = "DesignationID";
            this.ddlDesignation.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    public void ClearControls()
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

    public List<double> GetSelectedEmployeeList()
    {
        List<double> lst = new List<double>();

        foreach (GridViewRow row in this.grdEmployee.Rows)
        {
            CheckBox chk = row.FindControl("chkSelect") as CheckBox;
            if (chk.Checked == true)
            {
                lst.Add(double.Parse(row.Cells[0].Text));
            }
        }

        return lst;
    }

    protected void grdEmployee_DataBound(object sender, EventArgs e)
    {
        if (this.grdEmployee.Rows.Count > 0)
        {
            this.lblSearch.Text = "Total person: " + this.grdEmployee.Rows.Count.ToString();
            this.pnlEmployee.Visible = true;
        }
        else
        {
            this.lblSearch.Text = "";
            this.pnlEmployee.Visible = false;
        }
    }

    protected void grdEmployee_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[4].Visible = false;
        e.Row.Cells[5].Visible = false;
    }

    protected void grdEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.grdEmployee.SelectedRow.Focus();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.ClearControls();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            List<ATTGroupPersonSearch> lstPersonSearch;
            lstPersonSearch = BLLGroupPersonSearch.GetEmployeeWithPosting(GetFilter(), this.ApplicationString);
            //Session["PopupPersonSearch"] = lstPersonSearch;
            this.grdEmployee.DataSource = lstPersonSearch;
            this.grdEmployee.DataBind();

            this.grdEmployee.SelectedIndex = -1;
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
        
        if(this.txtSymbolNo.Text.Trim()!="")
            SearchPerson.SymbolNo = txtSymbolNo.Text.ToString().Trim();

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

    protected void ddlOrganization_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlOrganization.SelectedIndex > 0)
            {
                this.ddlCommittee.DataSource = BLLGroup.GetGroupListWithMember(int.Parse(this.ddlOrganization.SelectedValue), true,'C');
                this.ddlCommittee.DataTextField = "GroupName";
                this.ddlCommittee.DataValueField = "GroupID";
                this.ddlCommittee.DataBind();

                this.EnableCommittee = true;
                this.ddlCommittee.Enabled = this.EnableCommittee;


            }
            else
            {

                this.EnableCommittee = false;
                this.ddlCommittee.Enabled = this.EnableCommittee;
            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
        }
    }
    protected void ddlCommittee_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlCommittee.SelectedIndex > 0)
            {
                this.ddlCommitteePost.DataSource = BLLGroupMember.GetGroupMemberList(int.Parse(this.ddlCommittee.SelectedValue));
                this.ddlCommitteePost.DataTextField = "MemberPosition";
                this.ddlCommitteePost.DataValueField = "OPositionID";
                this.ddlCommitteePost.DataBind();

                this.ddlCommitteePost.Enabled = this.EnableCommittee;


            }
            else
            {
               this.ddlCommitteePost.Enabled = this.EnableCommittee;
            }

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
        }
    }
}
