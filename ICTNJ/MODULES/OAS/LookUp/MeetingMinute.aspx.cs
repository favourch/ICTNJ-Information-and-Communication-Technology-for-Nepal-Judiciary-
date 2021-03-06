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

using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.COMMON.DLL;
using PCS.OAS.ATT;
using PCS.OAS.BLL;


public partial class MODULES_OAS_LookUp_MeetingMinute : System.Web.UI.Page
{
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }

        ////block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        if (user.MenuList.ContainsKey("5,8,1") == true)
        {
            if (Page.IsPostBack == false)
            {
                this.LoadOrganization();
                this.LoadMeetingType();
                this.LoadMeetingStatus();
                this.SetTemporaryMinuteSession();
                this.LoadCurrentMonthDate();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }

    void LoadCurrentMonthDate()
    {
        try
        {
            string dateString = BLLDate.GetDateString(0, 0, "_N");
            char[] token ={ '/' };

            string year = dateString.Split(token)[0];
            string month = dateString.Split(token)[1];
            string fday = dateString.Split(token)[2];
            string lday = dateString.Split(token)[4];

            string sDate = year + "/" + this.FormatString(month) + "/" + "01";
            string eDate = year + "/" + this.FormatString(month) + "/" + this.FormatString(lday);

            this.txtFromDate.Text = sDate;
            this.txtToDate.Text = eDate;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private string FormatString(string s)
    {
        s = "0000" + s;
        return s.Substring(s.Length - 2, 2);
    }

    void SetTemporaryMinuteSession()
    {
        Session["TempMinuteLst"] = new List<ATTMeetingMinute>();
    }

    void LoadOrganization()
    {
        try
        {
            List<ATTOrganization> lst = BLLOrganization.GetOrganizationNameList();
            lst.Insert(0, new ATTOrganization(0, "---------- छान्नुहोस् ----------"));
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

    void LoadCommittee()
    {
        try
        {
            this.ddlCommittee.DataSource = BLLGroup.GetGroupListWithMember(int.Parse(this.ddlOrganization.SelectedValue), true,'C');
            this.ddlCommittee.DataTextField = "GroupName";
            this.ddlCommittee.DataValueField = "GroupID";
            this.ddlCommittee.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void LoadMeetingType()
    {
        try
        {
            List<ATTMeetingType> lst = BLLMeetingType.GetMeetingTypeList();
            if (lst.Count > 0)
            {
                lst.Insert(0, new ATTMeetingType(0, "---- छान्नुहोस् ----", ""));
            }
            this.ddlMeetingType.DataSource = lst;
            this.ddlMeetingType.DataTextField = "MeetingTypeName";
            this.ddlMeetingType.DataValueField = "MeetingTypeID";
            this.ddlMeetingType.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void LoadMeetingStatus()
    {
        try
        {
            List<ATTMeetingStatus> lst = BLLMeetingStatus.GetMeetingStatusList(null, true);
            this.ddlStatus.DataSource = lst;
            this.ddlStatus.DataTextField = "MeetingStatusName";
            this.ddlStatus.DataValueField = "MeetingStatusID";
            this.ddlStatus.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void LoadVenue()
    {
        try
        {
            List<ATTMeetingVenue> lst = BLLMeetingVenue.GetMeetingVenueList(int.Parse(this.ddlOrganization.SelectedValue));
            if (lst.Count > 0)
            {
                lst.Insert(0, new ATTMeetingVenue(0, 0, "---- छान्नुहोस् ----", ""));
            }
            this.ddlVenue.DataSource = lst;
            this.ddlVenue.DataTextField = "VenueName";
            this.ddlVenue.DataValueField = "VenueID";
            this.ddlVenue.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void ddlOrganization_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.ddlOrganization.SelectedIndex == 0)
        {
            this.ddlCommittee.Items.Clear();
            this.ddlVenue.Items.Clear();
            return;
        }

        this.LoadCommittee();
        this.LoadVenue();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (this.ddlOrganization.SelectedIndex <= 0)
        {
            this.lblStatusMessage.Text = " कृपया पहिला कार्यलय छान्नुहोस्।";
            this.programmaticModalPopup.Show();
            return;
        }

        ATTMeetingInfo mInfo = new ATTMeetingInfo();

        mInfo.OrgID = int.Parse(this.ddlOrganization.SelectedValue);
        mInfo.FromDate = this.txtFromDate.Text;
        mInfo.ToDate = this.txtToDate.Text;
        mInfo.CalledBy = this.ddlCommittee.SelectedValue;
        mInfo.CalledBy = mInfo.CalledBy == "" ? "0" : mInfo.CalledBy;
        mInfo.Venue = this.ddlVenue.SelectedValue;
        mInfo.Venue = mInfo.Venue == "" ? "0" : mInfo.Venue;
        mInfo.Status = this.ddlStatus.SelectedValue;
        mInfo.MeetingTypeName = this.ddlMeetingType.SelectedValue;

        try
        {
            this.grdMeeting.DataSource = BLLMeetingInfo.GetMeetingInfoList(mInfo);
            this.grdMeeting.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void grdMeeting_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
    }

    protected void grdMeeting_DataBound(object sender, EventArgs e)
    {
        if (this.grdMeeting.Rows.Count > 0)
        {
            this.lblMeetingCount.Text = "Total meeting: " + this.grdMeeting.Rows.Count.ToString();
            this.grdMeeting.SelectedIndex = -1;
            this.pnlMeeting.Visible = true;
        }
        else
        {
            this.lblMeetingCount.Text = "कुनै पनि मिटिंङ्ग भेटिएन्न।";
            this.pnlMeeting.Visible = false;
            this.lblMeetingTitle.Text = "";
        }

        this.grdMinute.DataSource = "";
        this.grdMinute.DataBind();

        this.txtMin.Text = "";
        this.grdMinute.SelectedIndex = -1;
    }

    protected void grdMeeting_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.lblMeetingTitle.Text = "मिटिङको बिषय:: " + this.grdMeeting.SelectedRow.Cells[2].Text;

        int orgID = int.Parse(this.grdMeeting.SelectedRow.Cells[0].Text);
        int meetingID = int.Parse(this.grdMeeting.SelectedRow.Cells[1].Text);

        Session["TempMinuteLst"] = BLLMeetingMinute.CreateDeepCopy(BLLMeetingMinute.GetMeetingMinuteList(orgID, meetingID, null));

        this.grdMinute.DataSource = Session["TempMinuteLst"];
        this.grdMinute.DataBind();

        this.grdMeeting.SelectedRow.Focus();
    }

    protected void btnAddMinute_Click(object sender, EventArgs e)
    {
        if (this.grdMeeting.SelectedIndex < 0)
        {
            this.lblStatusMessage.Text = "कृपया कुनै मिटिङ्ग छान्नुहोस्।";
            this.programmaticModalPopup.Show();
            return;
        }

        List<ATTMeetingMinute> tmpList = (List<ATTMeetingMinute>)Session["TempMinuteLst"];

        ATTMeetingMinute minute = new ATTMeetingMinute();

        minute.OrgID = int.Parse(this.grdMeeting.SelectedRow.Cells[0].Text);
        minute.MeetingID = int.Parse(this.grdMeeting.SelectedRow.Cells[1].Text);
        minute.MinuteID = 0;
        minute.Minute = this.txtMin.Text;
        minute.EntryBy = ((ATTUserLogin)Session["Login_User_Detail"]).UserName;
        minute.Action = "A";

        ObjectValidation result = BLLMeetingMinute.Validate(minute);
        if (result.IsValid == false)
        {
            this.lblStatusMessage.Text = result.ErrorMessage;
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.grdMinute.SelectedIndex >= 0)
        {
            if (this.grdMinute.SelectedRow.Cells[5].Text == "A")
            {
                minute.MinuteID = int.Parse(this.grdMinute.SelectedRow.Cells[2].Text);
                minute.Action = this.grdMinute.SelectedRow.Cells[5].Text;
            }
            else
            {
                minute.MinuteID = int.Parse(this.grdMinute.SelectedRow.Cells[2].Text);
                minute.Action = "E";
            }
        }

        if (this.grdMinute.SelectedIndex < 0)
            tmpList.Add(minute);
        else
            tmpList[this.grdMinute.SelectedIndex] = minute;

        this.txtMin.Text = "";
        this.grdMinute.SelectedIndex = -1;

        this.grdMinute.DataSource = tmpList;
        this.grdMinute.DataBind();

        this.SetGridColor(5, 7, this.grdMinute);
    }

    protected void grdMinute_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.grdMinute.SelectedRow.Cells[5].Text == "D")
        {
            this.txtMin.Text = "";
            this.grdMinute.SelectedIndex = -1;
            return;
        }
        this.txtMin.Text = this.grdMinute.SelectedRow.Cells[3].Text;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (this.grdMinute.Rows.Count <= 0)
        {
            return;
        }

        try
        {
            BLLMeetingMinute.AddMeetingMinute((List<ATTMeetingMinute>)Session["TempMinuteLst"]);
            this.SetTemporaryMinuteSession();

            this.txtMin.Text = "";
            this.lblMeetingCount.Text = "";

            this.grdMinute.DataSource = "";
            this.grdMinute.SelectedIndex = -1;
            this.grdMinute.DataBind();

            this.grdMeeting.SelectedIndex = -1;
            
            this.lblStatusMessage.Text = "माइनुट सफलतापूर्वक सेब भयो।";
            this.programmaticModalPopup.Show();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void grdMinute_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[4].Visible = false;
        e.Row.Cells[5].Visible = false;
    }

    protected void grdMinute_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // need to set five parameter and include SetGridColor(x,y,z) function

        List<ATTMeetingMinute> lst = (List<ATTMeetingMinute>)Session["TempMinuteLst"];//param 1

        int ActIndex = 5;//param 2
        int DelCmdIndex = 7;//param 3
        GridView grd = this.grdMinute;//param 4
        GridViewRow CurrentRow = this.grdMinute.Rows[e.RowIndex];//param 5

        if (CurrentRow.Cells[ActIndex].Text == "A")
        {
            lst.RemoveAt(e.RowIndex);
            grd.DataSource = lst;
            grd.DataBind();
        }
        else if (CurrentRow.Cells[ActIndex].Text == "N" || CurrentRow.Cells[ActIndex].Text == "D" || CurrentRow.Cells[ActIndex].Text == "E")
        {
            if (((LinkButton)CurrentRow.Cells[DelCmdIndex].Controls[0]).Text == "Delete")
            {
                lst[e.RowIndex].Action = "D";
                grd.DataSource = lst;
                grd.DataBind();
            }
            else if (((LinkButton)CurrentRow.Cells[DelCmdIndex].Controls[0]).Text == "Undo")
            {
                lst[e.RowIndex].Action = "N";
                grd.DataSource = lst;
                grd.DataBind();
            }
        }
        this.SetGridColor(ActIndex, DelCmdIndex, grd);
    }

    void SetGridColor(int ActIndex, int DelCmdIndex, GridView grd)
    {
        foreach (GridViewRow row in grd.Rows)
        {
            if (row.Cells[ActIndex].Text == "D")
            {
                row.ForeColor = System.Drawing.Color.Red;
                ((LinkButton)row.Cells[DelCmdIndex].Controls[0]).Text = "Undo";
            }
            else if (row.Cells[ActIndex].Text == "N" || row.Cells[ActIndex].Text == "A" || row.Cells[ActIndex].Text == "E")
            {
                row.ForeColor = System.Drawing.Color.FromName("#1D2A5B");
                ((LinkButton)row.Cells[DelCmdIndex].Controls[0]).Text = "Delete";
            }
        }
    }

    protected void btnCancelSubmit_Click(object sender, EventArgs e)
    {
        this.txtMin.Text = "";
        
        this.grdMinute.DataSource = "";
        this.grdMinute.DataBind();
        this.grdMinute.SelectedIndex = -1;

        this.lblMeetingTitle.Text = "";
        
        this.SetTemporaryMinuteSession();
        this.grdMeeting.SelectedIndex = -1;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ddlOrganization.SelectedIndex = -1;
        ddlCommittee.SelectedIndex = -1;
        ddlMeetingType.SelectedIndex = -1;
        ddlStatus.SelectedIndex = -1;
        ddlVenue.SelectedIndex = -1;
        txtFromDate.Text = "";
        txtToDate.Text = "";

        lblMeetingCount.Text = "";
        grdMeeting.SelectedIndex = -1;
        grdMeeting.DataSource = "";
        grdMeeting.DataBind();

        lblMeetingTitle.Text = "";


    }
}