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

public partial class MODULES_OAS_Tippani_VisitTippani : System.Web.UI.Page
{
    new private ATTUserLogin User
    {
        get
        {
            return (ATTUserLogin)Session["Login_User_Detail"];
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        Session["OrgID"] = this.User.OrgID;
        if (!IsPostBack)
        {
            this.LoadOrganizationWithChilds(int.Parse(Session["OrgID"].ToString()));
            this.ddlOrg_Rqd.SelectedValue = this.User.OrgID.ToString();

            this.LoadTippaniStatus();

            this.LoadTippaniSubject();
            this.ddlTippaniSubject_Rqd.SelectedValue = "2";

            List<ATTOrganizationTippaniSubject> lst = (List<ATTOrganizationTippaniSubject>)Session["TippaniSubjectLst"];
            lst[this.ddlTippaniSubject_Rqd.SelectedIndex].LstTippaniChannel.RemoveAll
                        (
                            delegate(ATTTippaniChannel c)
                            {
                                return c.ChannelPersonID == this.User.PID;
                            }
                        );
            this.grdChannelPerson.DataSource = lst[this.ddlTippaniSubject_Rqd.SelectedIndex].LstTippaniChannel;
            this.grdChannelPerson.DataBind();

            this.LoadDesignations();
            this.LoadCommitteePost();
            
            this.LoadCountry();
            
            Session["EmpID"] = null;
            Session.Remove("EmpID");
            Session["EmpFullName"] = null;
            Session.Remove("EmpFullName");
            Session["PropDetailsEmpID"] = null;
            Session.Remove("PropDetailsEmpID");
        }
    }

    void LoadCountry()
    {
        try
        {
            this.ddlCountry_Rqd.DataSource = BLLCountry.GetCountries(null, 0);
            this.ddlCountry_Rqd.DataTextField = "CountryNepName";
            this.ddlCountry_Rqd.DataValueField = "COuntryID";
            this.ddlCountry_Rqd.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void LoadTippaniStatus()
    {
        try
        {
            this.ddlTippaniStatus.DataSource = BLLTippaniStatus.GetTippaniStatusList(false);
            this.ddlTippaniStatus.DataTextField = "TippaniStatusName";
            this.ddlTippaniStatus.DataValueField = "TippaniStatusID";
            this.ddlTippaniStatus.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void LoadTippaniSubject()
    {
        try
        {
            ATTUserLogin user = (ATTUserLogin)Session["Login_User_Detail"];
            Session["TippaniSubjectLst"] = BLLOrganizationTippaniSubject.GetOrganizaionTippaniSubjectList(this.User.OrgID, null, false);
            //Session["TippaniSubjectLst"] = BLLOrganizationTippaniSubject.GetOrganizaionTippaniSubjectList(9, 2, false);
            this.ddlTippaniSubject_Rqd.DataSource = Session["TippaniSubjectLst"];
            this.ddlTippaniSubject_Rqd.DataTextField = "TippaniSubjectName";
            this.ddlTippaniSubject_Rqd.DataValueField = "TippaniSubjectID";
            this.ddlTippaniSubject_Rqd.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
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

            this.ddlOrg_Rqd.DataSource = OrganizationList;
            this.ddlOrg_Rqd.DataTextField = "ORGNAME";
            this.ddlOrg_Rqd.DataValueField = "ORGID";
            this.ddlOrg_Rqd.DataBind();

            this.ddlSOrg.DataSource = OrganizationList;
            this.ddlSOrg.DataTextField = "ORGNAME";
            this.ddlSOrg.DataValueField = "ORGID";
            this.ddlSOrg.DataBind();

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

            this.ddlSDesgination.DataSource = LstDesignation;
            this.ddlSDesgination.DataTextField = "DesignationName";
            this.ddlSDesgination.DataValueField = "DesignationID";
            this.ddlSDesgination.DataBind();
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
            lstPersonSearch = BLLGroupPersonSearch.GetEmployeeWithPosting(GetFilter(), "5, 3");
            Session["PopupPersonSearch"] = lstPersonSearch;
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

        //if (e.Row.RowType == DataControlRowType.DataRow)
        //    if (((ATTPersonSearch)e.Row.DataItem).ApplicationID != 5)
        //        ((LinkButton)e.Row.Cells[10].Controls[0]).Enabled = false;
    }

    protected void grdEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = grdEmployee.Rows[this.grdEmployee.SelectedIndex];
        //Session["EmpID"] = row.Cells[0].Text;
        //Session["EmpFullName"] = row.Cells[2].Text;
        //Response.Redirect("~/modules/oas/person/personnelinfo.aspx");
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
    protected void ddlOrganization_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (this.ddlOrganization.SelectedIndex <= 0)
        //{
        //    return;
        //}

        //try
        //{
        //    this.ddlCommittee.DataSource = BLLGroup.GetGroupListWithMember(int.Parse(this.ddlOrganization.SelectedValue), true);
        //    this.ddlCommittee.DataTextField = "GroupName";
        //    this.ddlCommittee.DataValueField = "GroupID";
        //    this.ddlCommittee.DataBind();
        //}
        //catch (Exception ex)
        //{
        //    this.lblStatusMessage.Text = "Error Status";
        //    this.lblStatusMessage.Text = ex.Message;
        //}
    }

    protected void grdChannelPerson_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[8].Visible = false;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        #region Validation
        if (this.grdEmployee.SelectedIndex < 0)
        {
            this.lblStatusMessage.Text = "क्रिपया कर्मचारी छन्नुहोस ।";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.txtLocation_Rqd.Text.Trim() == "")
        {
            this.lblStatusMessage.Text = "क्रिपया भ्रमणको स्थना छन्नुहोस ।";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.ddlCountry_Rqd.SelectedIndex == 0)
        {
            this.lblStatusMessage.Text = "क्रिपया भ्रमणको देश छन्नुहोस ।";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.txtFromDate_Rdt.Text.Trim() == "")
        {
            this.lblStatusMessage.Text = "क्रिपया अवधि देखि को मिति राख्न्नुहोस ।";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.txtToDate_Rdt.Text.Trim() == "")
        {
            this.lblStatusMessage.Text = "क्रिपया अवधि सम्म को मिति राख्न्नुहोस ।";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.txtSubject_Rqd.Text.Trim() == "")
        {
            this.lblStatusMessage.Text = "क्रिपया भ्रमणको बिषय राख्न्नुहोस ।";
            this.programmaticModalPopup.Show();
            return;
        }
        #endregion

        double EmpID = double.Parse(this.grdEmployee.SelectedRow.Cells[0].Text);

        ATTGeneralTippani tippani = new ATTGeneralTippani();

        tippani.TippaniName = TippaniSubject.Visit;
        tippani.OrgID = int.Parse(this.ddlOrg_Rqd.SelectedValue);
        tippani.TippaniID = 0;
        tippani.TippaniSubjectID = int.Parse(this.ddlTippaniSubject_Rqd.SelectedValue);
        tippani.TippaniBy = this.User.UserName;
        tippani.TippaniOn = "";
        tippani.TippaniText = this.txtTippaniText.Text;
        tippani.FinalStatus = 1;
        tippani.Action = "A";

        tippani.TippaniDetail.OrgID = tippani.OrgID;
        tippani.TippaniDetail.TippaniID = tippani.TippaniID;
        tippani.TippaniDetail.TippaniSNO = 0;
        tippani.TippaniDetail.EmpID = EmpID;
        tippani.TippaniDetail.VisitLocation = this.txtLocation_Rqd.Text;
        tippani.TippaniDetail.VisitCountryID = int.Parse(this.ddlCountry_Rqd.SelectedValue);
        tippani.TippaniDetail.VisitFromDate = this.txtFromDate_Rdt.Text;
        tippani.TippaniDetail.VisitToDate = this.txtToDate_Rdt.Text;
        tippani.TippaniDetail.VisitPurpose = this.txtSubject_Rqd.Text;
        tippani.TippaniDetail.VisitRemark = this.txtRemarks_Rdt.Text;
        tippani.TippaniDetail.VisitEntryBy = this.User.UserName;
        tippani.TippaniDetail.Action = "A";

        /****************** extra added later ******************/
        ATTGeneralTippaniProcess self = new ATTGeneralTippaniProcess();
        self.OrgID = tippani.OrgID;
        self.TippaniID = tippani.TippaniID;
        self.TippaniProcessID = 0;
        self.SendBy = null;
        self.SendOn = "";
        self.SendTo = (int)this.User.PID;
        self.Note = this.txtDOB.Text;
        self.Status = int.Parse(this.ddlTippaniStatus.SelectedValue);
        self.SendType = "F";
        self.IsChannelPerson = "Y";
        self.Action = "A";

        tippani.LstTippaniProcess.Add(self);
        /************************************/

        foreach (GridViewRow row in this.grdChannelPerson.Rows)
        {
            CheckBox box = (CheckBox)row.FindControl("chkSelect");
            if (box.Checked == true)
            {
                ATTGeneralTippaniProcess process = new ATTGeneralTippaniProcess();
                
                /*process.OrgID = tippani.OrgID;
                process.TippaniID = tippani.TippaniID;
                process.TippaniProcessID = 0;
                process.ProcessBy = this.User.PID;
                process.ProcessOn = "";
                process.ProcessTo = int.Parse(row.Cells[1].Text);
                process.Status = null;
                process.SendType = "F";
                process.Action = "A";*/

                process.OrgID = tippani.OrgID;
                process.TippaniID = tippani.TippaniID;
                process.TippaniProcessID = 0;
                process.SendBy = this.User.PID;
                process.SendOn = "";
                process.SendTo = int.Parse(row.Cells[8].Text);
                process.Note = "";
                process.Status = null;
                process.SendType = "F";
                process.IsChannelPerson = "Y";
                process.Action = "A";

                tippani.LstTippaniProcess.Add(process);

                //box.Checked = false;
            }
        }

        foreach (GridViewRow row in this.grdSEmployee.Rows)
        {
            CheckBox box = (CheckBox)row.FindControl("chkGSelect");
            if (box.Checked == true)
            {
                ATTGeneralTippaniProcess process = new ATTGeneralTippaniProcess();

                process.OrgID = tippani.OrgID;
                process.TippaniID = tippani.TippaniID;
                process.TippaniProcessID = 0;
                process.SendBy = this.User.PID;
                process.SendOn = "";
                process.SendTo = int.Parse(row.Cells[0].Text);
                process.Note = "";
                process.Status = null;
                process.SendType = "F";
                process.IsChannelPerson = "N";
                process.Action = "A";

                tippani.LstTippaniProcess.Add(process);

                //box.Checked = false;
            }
        }

        try
        {
            BLLGeneralTippani.AddGeneralTippani(tippani);
            
            this.ClearME();

            this.lblStatusMessage.Text = "Visit Tippani has been saved successfully.";
            this.programmaticModalPopup.Show();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void ClearME()
    {
        this.txtLocation_Rqd.Text = "";
        this.ddlCommittee.SelectedIndex = 0;
        this.txtFromDate_Rdt.Text = "";
        this.txtToDate_Rdt.Text = "";
        this.txtSubject_Rqd.Text = "";
        this.txtRemarks_Rdt.Text = "";

        this.txtNote.Text = "";
        this.ddlTippaniStatus.SelectedIndex = 0;

        this.grdEmployee.SelectedIndex = -1;

        foreach (GridViewRow row in this.grdChannelPerson.Rows)
        {
            CheckBox box = (CheckBox)row.FindControl("chkSelect");
            box.Checked = false;
        }

        this.grdSEmployee.DataSource = "";
        this.grdSEmployee.DataBind();
    }

    protected void grdChannelPerson_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[8].Visible = false;
    }

    protected void grdChannelPerson_DataBound(object sender, EventArgs e)
    {
        if (this.grdChannelPerson.Rows.Count > 0)
        {
            this.lblChannelPersonCount.Text = "Total channel person for visit: " + this.grdChannelPerson.Rows.Count.ToString();
        }
        else
        {
            this.lblChannelPersonCount.Text = "No Channel person";
        }
    }

    protected void btnSearchGeneral_Click(object sender, EventArgs e)
    {
        try
        {
            List<ATTGroupPersonSearch> lstPersonSearch;
            lstPersonSearch = BLLGroupPersonSearch.GetEmployeeWithPosting(GetFilterGeneral(), "5, 3");

            lstPersonSearch.RemoveAll
                                        (
                                            delegate(ATTGroupPersonSearch s)
                                            {
                                                return s.PersonID == this.User.PID;
                                            }
                                        );

            double empID;
            foreach (GridViewRow row in this.grdChannelPerson.Rows)
            {
                empID = double.Parse(row.Cells[8].Text);
                lstPersonSearch.RemoveAll
                                        (
                                            delegate(ATTGroupPersonSearch s)
                                            {
                                                return s.PersonID == empID;
                                            }
                                        );
            }

            //Session["PopupPersonSearch"] = lstPersonSearch;
            this.grdSEmployee.DataSource = lstPersonSearch;
            this.grdSEmployee.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    private ATTGroupPersonSearch GetFilterGeneral()
    {
        ATTGroupPersonSearch SearchPerson = new ATTGroupPersonSearch();

        SearchPerson.Gender = "";
        SearchPerson.MaritalStatus = "";
        SearchPerson.IniType = "";
        SearchPerson.PostName = "";

        SearchPerson.FirstName = this.txtSFname.Text.Trim();
        SearchPerson.MiddleName = this.txtSMname.Text.Trim();
        SearchPerson.SurName = this.txtSLname.Text.Trim();

        if (this.ddlSSex.SelectedIndex > 0) SearchPerson.Gender = this.ddlSSex.SelectedValue;

        SearchPerson.DOB = this.txtSDob.Text.Trim();

        if (this.ddlSMaritalStatus.SelectedIndex > 0) SearchPerson.MaritalStatus = this.ddlSMaritalStatus.SelectedValue;

        if (this.ddlSOrg.SelectedIndex > 0) SearchPerson.IniType = this.ddlSOrg.SelectedValue;

        if (this.ddlSDesgination.SelectedIndex > 0) SearchPerson.PostName = this.ddlSDesgination.SelectedValue;

        return SearchPerson;
    }

    protected void btnCancelGeneral_Click(object sender, EventArgs e)
    {

    }

    protected void btnCancelSubmit_Click(object sender, EventArgs e)
    {
        this.ClearME();
    }

    protected void grdSEmployee_DataBound(object sender, EventArgs e)
    {
        if (this.grdSEmployee.Rows.Count > 0)
        {
            this.lblSearchX.Text = "Total person: " + this.grdSEmployee.Rows.Count.ToString();
        }
        else
        {
            this.lblSearchX.Text = "No person found.";
        }
    }
}
