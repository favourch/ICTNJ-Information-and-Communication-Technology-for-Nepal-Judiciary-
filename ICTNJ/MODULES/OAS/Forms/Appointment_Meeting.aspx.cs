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
using PCS.PMS.ATT;
using PCS.PMS.BLL;



public partial class MODULES_OAS_Forms_newCal : System.Web.UI.Page
{
    public int orgID, unitID, meetingID;
    public string alreadyCheckedList1;
    public string entryBy;
    public string inOut;
    public int loginID;

    public int year;
    public int month;

    public ATTMeeting ObjMeeting
    {
        get
        {
            return (Session["ObjMeeting"] == null) ? new ATTMeeting() : (ATTMeeting)Session["ObjMeeting"];
        }
        set { Session["ObjMeeting"] = value; }
    }

    public String Action
    {
        get
        {
            return (Session["M_Action"].ToString()) ;
        }
        set { Session["M_Action"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }

        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        entryBy = user.UserName;
        loginID = int.Parse(user.PID.ToString());

        if (user.MenuList.ContainsKey("5,7,1") == true)
        {
            if (Page.IsPostBack == false)
            {
                Session["CurrentDate"] = null;
                LoadControls();
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                drpOrganisation_rqd.Enabled = true;
                btnUpdAgenda.Visible = false;

                if (user.MenuList["5,7,1"].PAdd == "Y")
                {
                    this.btnCreateEvent.Visible = true;
                }
 
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);

        if (user.MenuList["5,7,1"].PAdd == "Y")
        {
            if (btnCreateEvent.Visible == true)
            {
                btnAdd.Visible = true;

            }
        }

        LoadPostBackControls();


    }

    public void LoadYear()
    {
        this.ddlYear.Items.Add(new ListItem("साल", "0"));

        DataTable tbl = BLLDate.GetMaxMinYear();

        for (int i = int.Parse(tbl.Rows[0]["Min_Year"].ToString()); i <= int.Parse(tbl.Rows[0]["Max_Year"].ToString()); i++)
        {
            string year = GetNepaliValue(i);

            this.ddlYear.Items.Add(new ListItem(year, i.ToString()));
        }

    }

    public void LoadMonth()
    {
        this.ddlMonth.Items.Add(new ListItem("महिना", "0"));
        int value = 0;
        foreach (string month in PCS.FRAMEWORK.Utilities.NepaliMonthList)
        {
            value = value + 1;
            this.ddlMonth.Items.Add(new ListItem(month, value.ToString()));
        }
    }

    public void LoadNepaliCalender(int year, int month, string LP)
    {
        try
        {

            string dateString = BLLDate.GetDateString(year, month, "_N");

            if (Session["CurrentDate"] == null)
            {
                Session["CurrentDate"] = dateString;
                int len = Session["CurrentDate"].ToString().Length;
                string currentDate = Session["CurrentDate"].ToString().Substring(0, len - 5);

                hdnCurrentDate.Value = currentDate;
            }

            char[] token ={ '/' };

            int Year = int.Parse(dateString.Split(token)[0]);
            int Month = int.Parse(dateString.Split(token)[1]);
            int Day = int.Parse(dateString.Split(token)[2]);
            int SDay = int.Parse(dateString.Split(token)[3]);
            int TDay = int.Parse(dateString.Split(token)[4]);

            this.lblYear.Text = Year.ToString();
            this.lblYear1.Text = GetNepaliValue(int.Parse(Year.ToString()));

            //this.lblYear.Text = GetNepaliValue(int.Parse(Year.ToString()));
            hdnMonth.Value = Month.ToString();
            this.lblMonth.Text = Month.ToString();
            this.lblMonthText.Text = PCS.FRAMEWORK.Utilities.NepaliMonthList[Month - 1];

            Label lbl;


            this.ClearDayEvent();

            int day = 0;
            int lastRowIndex = 0;
            for (int i = SDay; i < TDay + SDay; i++)
            {
                day = day + 1;
                lbl = ((Label)this.tblAM.Rows[this.GetRowIndex(i)].Cells[this.GetCellIndex(i) - 1].FindControl("Day" + i.ToString()));

                //lbl.Text = day.ToString();

                lbl.Text = GetNepaliValue(day);

                lastRowIndex = GetRowIndex(i);

                this.tblAM.Rows[this.GetRowIndex(i)].Cells[this.GetCellIndex(i) - 1].Attributes.Add("onclick", "OnCellClick(this)");

                this.tblAM.Rows[this.GetRowIndex(i)].Cells[this.GetCellIndex(i) - 1].Style.Add("cursor", "hand");

                if (this.GetCellIndex(i) != 7)
                {
                    this.tblAM.Rows[this.GetRowIndex(i)].Cells[this.GetCellIndex(i) - 1].Attributes.Add("onmouseover", "OnMouseOverX(this)"); ;
                    this.tblAM.Rows[this.GetRowIndex(i)].Cells[this.GetCellIndex(i) - 1].Attributes.Add("onmouseout", "OnMouseOutX(this)"); ;
                    this.tblAM.Rows[this.GetRowIndex(i)].Cells[this.GetCellIndex(i) - 1].BackColor = System.Drawing.Color.White;

                }
                else
                {
                    this.tblAM.Rows[this.GetRowIndex(i)].Cells[this.GetCellIndex(i) - 1].Attributes.Add("onmouseover", "OnMouseOverX(this)"); ;
                    this.tblAM.Rows[this.GetRowIndex(i)].Cells[this.GetCellIndex(i) - 1].Attributes.Add("onmouseout", "OnMouseOutX(this)"); ;
                    this.tblAM.Rows[this.GetRowIndex(i)].Cells[this.GetCellIndex(i) - 1].BackColor = System.Drawing.Color.White;


                    //this.tblAM.Rows[this.GetRowIndex(i)].Cells[this.GetCellIndex(i) - 1].BackColor = System.Drawing.Color.FromName("#c6d8e2");
                    ((Label)this.tblAM.Rows[this.GetRowIndex(i)].Cells[this.GetCellIndex(i) - 1].Controls[0]).ForeColor = System.Drawing.Color.Red;
                }

            }

            if (lastRowIndex == 5)
                this.tblAM.Rows[6].Visible = false;
            else
                this.tblAM.Rows[6].Visible = true;


            LoadEvents();
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    public string GetEnglisValue(string value)
    {
        try
        {
            string englishVal;
            englishVal = value;
            englishVal = englishVal.Replace("०", "0");
            englishVal = englishVal.Replace("१", "1");
            englishVal = englishVal.Replace("२", "2");
            englishVal = englishVal.Replace("३", "3");
            englishVal = englishVal.Replace("४", "4");
            englishVal = englishVal.Replace("५", "5");
            englishVal = englishVal.Replace("६", "6");
            englishVal = englishVal.Replace("७", "7");
            englishVal = englishVal.Replace("८", "8");
            englishVal = englishVal.Replace("९", "9");

            return englishVal;
        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }

    public string GetNepaliValue(int value)
    {
        try
        {
            string nepaliVal;

            nepaliVal = value.ToString();
            nepaliVal = nepaliVal.Replace("0", "०");
            nepaliVal = nepaliVal.Replace("1", "१");
            nepaliVal = nepaliVal.Replace("2", "२");
            nepaliVal = nepaliVal.Replace("3", "३");
            nepaliVal = nepaliVal.Replace("4", "४");
            nepaliVal = nepaliVal.Replace("5", "५");
            nepaliVal = nepaliVal.Replace("6", "६");
            nepaliVal = nepaliVal.Replace("7", "७");
            nepaliVal = nepaliVal.Replace("8", "८");
            nepaliVal = nepaliVal.Replace("9", "९");

            return nepaliVal;


        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }

    public string GetFormated(string value)
    {
        value = "00" + value;
        return value.Substring(value.Length - 2, 2);
    }

    public int GetRowIndex(int Day)
    {
        if (Day >= 1 && Day <= 7)
            return 1;
        else if (Day >= 8 && Day <= 14)
            return 2;
        else if (Day >= 15 && Day <= 21)
            return 3;
        else if (Day >= 22 && Day <= 28)
            return 4;
        else if (Day >= 29 && Day <= 35)
            return 5;
        else if (Day >= 36 && Day <= 42)
            return 6;

        return 0;
    }

    public int GetCellIndex(int Day)
    {
        if (Day >= 1 && Day <= 7)
            return Day;
        else if (Day >= 8 && Day <= 14)
            return Day - 7;
        else if (Day >= 15 && Day <= 21)
            return Day - 14;
        else if (Day >= 22 && Day <= 28)
            return Day - 21;
        else if (Day >= 29 && Day <= 35)
            return Day - 28;
        else if (Day >= 36 && Day <= 42)
            return Day - 35;

        return 0;
    }

    public void ClearDayEvent()
    {
        Label lbl;
        DataList dLst;

        for (int i = 1; i <= 42; i++)
        {
            this.tblAM.Rows[this.GetRowIndex(i)].Cells[this.GetCellIndex(i) - 1].Attributes.Remove("onmouseover");
            this.tblAM.Rows[this.GetRowIndex(i)].Cells[this.GetCellIndex(i) - 1].Attributes.Remove("onmouseout");
            this.tblAM.Rows[this.GetRowIndex(i)].Cells[this.GetCellIndex(i) - 1].Attributes.Remove("onclick");
            this.tblAM.Rows[this.GetRowIndex(i)].Cells[this.GetCellIndex(i) - 1].Style.Add("cursor", "default");

            lbl = ((Label)this.tblAM.Rows[this.GetRowIndex(i)].Cells[this.GetCellIndex(i) - 1].FindControl("Day" + i.ToString()));
            lbl.Text = "";

            //if (i < 4)
            //{

            dLst = ((DataList)this.tblAM.Rows[this.GetRowIndex(i)].Cells[this.GetCellIndex(i) - 1].FindControl("DataList" + i.ToString()));
            dLst.DataSource = "";
            dLst.DataBind();
            // }


        }
    }

    public string GetNextYearNMonth()
    {
        //int month = int.Parse(this.lblMonth.Text);
        //int year = int.Parse(this.lblYear.Text);

        month = int.Parse(this.lblMonth.Text);
        year = int.Parse(this.lblYear.Text);


        month = month + 1;

        if (month > 12)
        {
            month = 1;
            year = year + 1;
        }
        string maxYear = GetEnglisValue(this.ddlYear.Items[this.ddlYear.Items.Count - 1].Text);
        string minYear = GetEnglisValue(this.ddlYear.Items[1].Text);

        if (year > int.Parse(maxYear))
            year = int.Parse(minYear);

        //if (year > int.Parse(this.ddlYear.val[this.ddlYear.Items.Count - 1].Text))

        return year.ToString() + "/" + month.ToString();
    }

    public string GetPreviousYearNMonth()
    {
        int month = int.Parse(this.lblMonth.Text);
        int year = int.Parse(this.lblYear.Text);

        month = month - 1;

        if (month == 0)
        {
            month = 12;
            year = year - 1;
        }

        string maxYear = GetEnglisValue(this.ddlYear.Items[this.ddlYear.Items.Count - 1].Text);
        string minYear = GetEnglisValue(this.ddlYear.Items[1].Text);

        if (year < int.Parse(minYear))
            year = int.Parse(maxYear);

        return year.ToString() + "/" + month.ToString();
    }

    protected void imgPrevious_Click(object sender, ImageClickEventArgs e)
    {
        string s = this.GetPreviousYearNMonth();

        char[] token ={ '/' };

        //int year = int.Parse(s.Split(token)[0]);
        //int month = int.Parse(s.Split(token)[1]);

        year = int.Parse(s.Split(token)[0]);
        month = int.Parse(s.Split(token)[1]);

        try
        {
            this.LoadNepaliCalender(year, month, "_N");
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void imgNext_Click(object sender, ImageClickEventArgs e)
    {
        string s = this.GetNextYearNMonth();

        char[] token ={ '/' };

        int year = int.Parse(s.Split(token)[0]);
        int month = int.Parse(s.Split(token)[1]);

        try
        {
            this.LoadNepaliCalender(year, month, "_N");
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void imgShow_Click(object sender, ImageClickEventArgs e)
    {
        ShowCalendar();
    }

    public void ShowCalendar()
    {
        if (this.ddlYear.SelectedIndex <= 0)
            return;
        if (this.ddlMonth.SelectedIndex <= 0)
            return;

        try
        {
            year = int.Parse(this.ddlYear.SelectedValue.ToString());
            month = int.Parse(this.ddlMonth.SelectedValue);

            this.LoadNepaliCalender(year,month,"_N");

        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    public void LoadEvents()
    {
        try
        {

            string dateString = BLLDate.GetDateString(int.Parse(lblYear.Text), int.Parse(lblMonth.Text), "_N");

            ArrayList arrEventLst = new ArrayList();

            List<ATTEvent> lstEvent = new List<ATTEvent>();
            ATTUserLogin objUserLogin = (ATTUserLogin)Session["Login_User_Detail"];
            Session["MeetingEvents"] = BLLEvent.GetEventList(dateString, objUserLogin);

            lstEvent = (List<ATTEvent>)Session["MeetingEvents"];
            char[] token ={ '/' };

            int year = int.Parse(dateString.Split(token)[0]);
            int month = int.Parse(dateString.Split(token)[1]);
            int SDay = int.Parse(dateString.Split(token)[3]);
            int tDay = int.Parse(dateString.Split(token)[4]);

            for (int i = 1; i <= tDay; i++)
            {

                List<ATTEvent> lst = new List<ATTEvent>();

                lst = lstEvent.FindAll(
                                            delegate(ATTEvent objEvent)
                                            {
                                                return objEvent.Day == i;
                                            }

                                      );

                DataList dLst;

                dLst = ((DataList)this.tblAM.Rows[this.GetRowIndex(SDay)].Cells[this.GetCellIndex(SDay) - 1].FindControl("DataList" + SDay.ToString()));
               
                if (lst.Count > 0)
                {
                    if (dLst != null)
                    {
                        arrEventLst.Add(i.ToString());
                        dLst.Attributes.Add("onclick", "chkPopup()");

                        dLst.DataSource = lst;
                        dLst.DataBind();


                     
                    }


                }
                else
                {
                    if (dLst != null)
                    {
                        dLst.DataSource = "";
                        dLst.DataBind();
                    }
                }

                SDay++;
            }

            if (arrEventLst.Count > 0)
            {

                Session["arrMeetEventLst"] = (object)arrEventLst;
            }
            else
            {
                Session["arrMeetEventLst"] = null;
            }

        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    public void ReLoadEvents()
    {
        try
        {

            string dateString = BLLDate.GetDateString(int.Parse(lblYear.Text), int.Parse(lblMonth.Text), "_N");

            List<ATTEvent> lstEvent = new List<ATTEvent>();
            ATTUserLogin objUserLogin = (ATTUserLogin)Session["Login_User_Detail"];
           
            lstEvent = (List<ATTEvent>)Session["MeetingEvents"];

            char[] token ={ '/' };

            int year = int.Parse(dateString.Split(token)[0]);
            int month = int.Parse(dateString.Split(token)[1]);
            int SDay = int.Parse(dateString.Split(token)[3]);
            int tDay = int.Parse(dateString.Split(token)[4]);

            ArrayList arrEventLst = new ArrayList();

            if (Session["arrMeetEventLst"] != null)
                arrEventLst = (ArrayList)Session["arrMeetEventLst"];

            int j = 0;

            int tmpSDay = SDay;

            /* for (int i = 1; i <= tDay; i++)
             {*/

            int i = 0;
            while (arrEventLst.Count > j)
            {
                i = int.Parse(arrEventLst[j].ToString());
                SDay = tmpSDay + (i - 1);

                List<ATTEvent> lst = new List<ATTEvent>();

                lst = lstEvent.FindAll(
                                                            delegate(ATTEvent objEvent)
                                                            {
                                                                return objEvent.Day == i;
                                                            }

                                                         );
                DataList dLst;

                dLst = ((DataList)this.tblAM.Rows[this.GetRowIndex(SDay)].Cells[this.GetCellIndex(SDay) - 1].FindControl("DataList" + SDay.ToString()));

                if (lst.Count > 0)
                {
                    if (dLst != null)
                    {
                        dLst.Attributes.Add("onclick", "chkPopup()");

                        dLst.DataSource = lst;
                        dLst.DataBind();
                    }
                }
                else
                {
                    if (dLst != null)
                    {
                        dLst.DataSource = "";
                        dLst.DataBind();
                    }
                }




                j++;
            }
            /*SDay++;
            }*/
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    public void LoadControls()
    {
        try
        {
            Session["arrMeetEventLst"] = null;
            Session["chkInOut"] = null;
            Session["ObjMeeting"] = null;
            Session["M_Action"] = null;

            this.LoadYear();
            this.LoadMonth();
            this.LoadNepaliCalender(0, 0, "_N");
            this.LoadMeetingType();
            this.LoadOrganisation();
            this.LoadStatus();
            this.LoadGroup();
            this.LoadGroupMembers();
            this.LoadDesignations();
            this.LoadCommitteePost();
            LoadPerson();
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    public void LoadCommitteePost()
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

    public void LoadDesignations()
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

    public void LoadOrganisation()
    {
        try
        {
            Session["meetingOrgList"] = BLLOrganization.GetOrganizationNameList();

            if (Session["meetingOrgList"] != null)
            {
                this.drpOrganisation_rqd.DataSource = (List<ATTOrganization>)Session["meetingOrgList"];
                this.drpOrganisation_rqd.DataTextField = "OrgName";
                this.drpOrganisation_rqd.DataValueField = "OrgId";
                this.drpOrganisation_rqd.DataBind();

                ListItem a = new ListItem();
                a.Selected = true;
                a.Text = "छान्नुहोस्";
                a.Value = "0";
                drpOrganisation_rqd.Items.Insert(0, a);


                this.dllOrgSrch.DataSource = (List<ATTOrganization>)Session["meetingOrgList"];
                this.dllOrgSrch.DataTextField = "OrgName";
                this.dllOrgSrch.DataValueField = "OrgId";
                this.dllOrgSrch.DataBind();

                dllOrgSrch.Items.Insert(0, a);

            }

        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }

    }
    
    public void LoadVenue()
    {
        try
        {
            Session["MeetingVenueList"] = BLLMeetingVenue.GetMeetingVenueList(null);
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    public void LoadMeetingType()
    {
        try
        {
            Session["MeetingMeetingTypeList"] = BLLMeetingType.GetMeetingTypeList();
            if (Session["MeetingMeetingTypeList"] != null)
            {
                this.drpMeetingType_rqd.DataSource = (List<ATTMeetingType>)Session["MeetingMeetingTypeList"];
                this.drpMeetingType_rqd.DataTextField = "MeetingTypeName";
                this.drpMeetingType_rqd.DataValueField = "MeetingTypeID";
                this.drpMeetingType_rqd.DataBind();

                ListItem a = new ListItem();
                a.Selected = true;
                a.Text = "छान्नुहोस्";
                a.Value = "0";
                drpMeetingType_rqd.Items.Insert(0, a);
            }

        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    public void LoadGroup()
    {
        try
        {
            Session["MeetingGroupList"] = BLLGroup.GetGroupList(null, false,'C');

        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    public void LoadPerson()
    {
        try
        {
            //Session["MeetingPersonList"] = BLLPerson.GetPersonList(null);

            Session["MeetingPersonList"] = BLLEmployeePosting.GetEmployeeWithPostingList(null);
        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }
    
    public void LoadGroupMembers()
    {
        try
        {
            Session["MeetingGroupMembersList"] = BLLGroupMember.GetGroupMemberList(null);
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    public void LoadStatus()
    {
        try
        {
            Session["MeetingStatus"] = BLLMeetingStatus.GetMeetingStatusList(null, false);

            if (Session["MeetingStatus"] != null)
            {
                drpStatus_rqd.DataSource = (List<ATTMeetingStatus>)Session["MeetingStatus"];
                drpStatus_rqd.DataTextField = "MeetingStatusName";
                drpStatus_rqd.DataValueField = "MeetingStatusID";
                drpStatus_rqd.DataBind();

                ListItem a = new ListItem();
                a.Selected = true;
                a.Text = "छान्नुहोस्";
                a.Value = "0";
                drpStatus_rqd.Items.Insert(0, a);

                dLstMeetingStatus.DataSource = (List<ATTMeetingStatus>)Session["MeetingStatus"];
                dLstMeetingStatus.DataBind();

            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void btnCreateEvent_Click(object sender, EventArgs e)
    {
        try
        {
            string day = GetEnglisValue(hdnDay.Value.ToString());
            string currentDate = "";

            currentDate = GetCurrentDate();

            string meetingSetDate = "";
            if (this.txtMeetingDate_rqd.Text != "")
            {

                meetingSetDate = int.Parse(lblYear.Text.ToString()) + "/" + GetFormated(lblMonth.Text.ToString()) + "/" + GetFormated(day);
            }

            if(CompareDate(currentDate,meetingSetDate))
            {
                if (Session["lstMeetingParticipant"] == null)
                {
                    this.lblStatusMessageTitle.Text = "Meeting Event";
                    this.lblStatusMessage.Text = "Event requires to involve at least one participant !!!";
                    this.programmaticModalPopup.Show();
                }
                else
                {
                     string time = "00:00:00";
                   
                     if (this.drpHr1_rqd.SelectedIndex > 0 && this.drpMin1_rqd.SelectedIndex > 0)
                     {
                         time = drpHr1_rqd.SelectedValue.ToString()
                                              + ":" + drpMin1_rqd.SelectedValue.ToString();

                     }

                     if (CompareTime(time,currentDate, meetingSetDate))
                     {
                          ATTMeeting objMeeting = new ATTMeeting();

                         if (this.drpOrganisation_rqd.SelectedIndex > 0)
                             objMeeting.OrgID = int.Parse(drpOrganisation_rqd.SelectedValue);

                         if (this.drpMeetingType_rqd.SelectedIndex > 0)
                             objMeeting.MeetingTypeID = int.Parse(drpMeetingType_rqd.SelectedValue);

                         if (this.drpVenue.SelectedIndex > 0)
                             objMeeting.VenueID = int.Parse(drpVenue.SelectedValue);

                         if (int.Parse(drp_MeetingCallerType_rqd.SelectedValue) == 1)
                         {
                             objMeeting.IsGrpCaller = "N";

                             if (this.drpCalledBy_rqd.SelectedIndex > 0)
                                 objMeeting.CalledByPID = int.Parse(drpCalledBy_rqd.SelectedValue);

                             objMeeting.CalledBy = null;
                         }
                         else if (int.Parse(drp_MeetingCallerType_rqd.SelectedValue) == 2)
                         {
                             objMeeting.IsGrpCaller = "Y";

                             if (this.drpCalledBy_rqd.SelectedIndex > 0)
                                 objMeeting.CalledBy = int.Parse(drpCalledBy_rqd.SelectedValue);

                             objMeeting.CalledByPID = null;
                         }



                         if (this.drpStatus_rqd.SelectedIndex > 0)
                             objMeeting.Status = int.Parse(drpStatus_rqd.SelectedValue);


                         if (this.txtMeetingDate_rqd.Text != "")
                         {

                             objMeeting.MeetingDate = int.Parse(lblYear.Text.ToString()) + "/" + GetFormated(lblMonth.Text.ToString()) + "/" + GetFormated(day);


                         }

                         if (this.drpHr1_rqd.SelectedIndex > 0 && this.drpMin1_rqd.SelectedIndex > 0)
                         {
                             objMeeting.StartTime = drpHr1_rqd.SelectedValue.ToString()
                                                  + ":" + drpMin1_rqd.SelectedValue.ToString();

                         }

                         if (this.drpHr2_rqd.SelectedIndex > 0 && this.drpMin2_rqd.SelectedIndex > 0)
                         {
                             objMeeting.EndTime = drpHr2_rqd.SelectedValue.ToString()
                                                     + ":" + drpMin2_rqd.SelectedValue.ToString();

                         }

                         if (ddlVenueType_rqd.SelectedIndex > 0)
                         {
                             if (int.Parse(ddlVenueType_rqd.SelectedValue.ToString()) == 1)
                             {
                                 objMeeting.VenueType = "INS";

                                 if (txtVenueData_rqd.Text != "")
                                     objMeeting.VenueBookingID = int.Parse(txtVenueData_rqd.Text);
                             }
                             else if (int.Parse(ddlVenueType_rqd.SelectedValue.ToString()) == 2)
                             {
                                 objMeeting.VenueType = "EX";

                                 if (txtVenueData_rqd.Text != "")
                                     objMeeting.VenueData = txtVenueData_rqd.Text;
                             }

                         }


                         objMeeting.Subject = txtSubject_rqd.Text;

                         objMeeting.EntryBy = entryBy;

                         
                     
                         ObjectValidation OV = BLLMeeting.ValidateMeetingEntry(objMeeting);

                         if (OV.IsValid == false)
                         {
                             this.lblStatusMessageTitle.Text = "मिटिङ्ग";
                             this.lblStatusMessage.Text = OV.ErrorMessage;
                             this.programmaticModalPopup.Show();
                             return;
                         }

                         if (Session["lstMeetingAgenda"] != null)
                             objMeeting.LstMeetingAgenda = (List<ATTMeetingAgenda>)Session["lstMeetingAgenda"];

                         if (Session["lstMeetingParticipant"] != null)
                             objMeeting.LstMeetingParticipant = SetParticipantValuesToList();

                         // Set object to property
                         ObjMeeting = objMeeting;
                         Action = "A";

                         // NB: ---------------//
                         ATTUserLogin objUserLogin = (ATTUserLogin)Session["Login_User_Detail"];



                         List<ATTCheckEvents> lst = new List<ATTCheckEvents>();
                         lst = BLLCheckEvents.CheckEvents(objUserLogin, objMeeting.MeetingDate, objMeeting.StartTime, objMeeting.EndTime);


                         if (lst.Count > 0)
                         {
                             grdChkEvents.DataSource = lst;
                             grdChkEvents.DataBind();

                             

                             ScriptManager.RegisterStartupScript(this, this.GetType(), "HideDiv", "javascript:hideDiv();", true);
                             programmaticBookedVenueModalPopup.Show();
                         }
                         else
                         {   SaveEvent();
                         }
                         
                     }
                     else
                     {
                         this.lblStatusMessageTitle.Text = "मिटिङ्ग";
                         this.lblStatusMessage.Text = "मिटिङ्गको शुरु समय नागीसक्यो !!! <br> त्यसैले अर्को शुरु समयमा मिटिङ्ग बनाउनुहोस्";
                         this.programmaticModalPopup.Show();
                     }
                }
             }
             else
             {


                 this.lblStatusMessageTitle.Text = "मिटिङ्ग";
                 this.lblStatusMessage.Text = "मिटिङ्गको मिति नागीसक्यो !!! <br> त्यसैले अर्को मितिमा मिटिङ्ग बनाउनुहोस्";
                 this.programmaticModalPopup.Show();
             }

        }

        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    public List<ATTMeetingParticipant> SetParticipantValuesToList()
    {
        try
        {
            List<ATTMeetingParticipant> lst = new List<ATTMeetingParticipant>();

            int i = 0;
            string action;
            ArrayList arrAction = new ArrayList();
            ArrayList arrMeetingHead = new ArrayList();
            ArrayList arrIsGrpParticipant = new ArrayList();
            ArrayList arrISPresent = new ArrayList();
            CheckBox chkMeetingHead, chkParticipant, chkPresence;

            if (grdParticipant.Rows.Count > 0)
            {

                foreach (GridViewRow gvr in grdParticipant.Rows)
                {
                    chkParticipant = (CheckBox)gvr.FindControl("chkParticipant");
                    chkMeetingHead = (CheckBox)gvr.Cells[4].FindControl("chkMeetingHead");
                    chkPresence = (CheckBox)gvr.Cells[5].FindControl("chkPresence");

                    action = gvr.Cells[6].Text;
                    arrAction.Add(action);
                    arrIsGrpParticipant.Add(gvr.Cells[9].Text);

                    if (chkMeetingHead.Checked)
                        arrMeetingHead.Add("1");
                    else
                    {
                        if (gvr.Cells[8].Text == "-1")
                            arrMeetingHead.Add("-1");
                        else
                        {
                            if (chkParticipant.Checked == false && ((gvr.Cells[8].Text.Trim() == "0") || (gvr.Cells[9].Text.Trim() == "O")))
                                arrMeetingHead.Add("-1");
                            else if (gvr.Cells[9].Text.Trim() == "N" || gvr.Cells[9].Text.Trim() == "OT")
                                arrMeetingHead.Add("2");
                            else if (chkParticipant.Checked == true && ((gvr.Cells[8].Text.Trim() == "0") || (gvr.Cells[9].Text.Trim() == "O")))
                                arrMeetingHead.Add("0");
                            else
                                arrMeetingHead.Add("2");
                        }
                    }

                    if (chkParticipant.Checked)
                    {
                        if (chkPresence.Checked)
                        {
                            arrISPresent.Add("Y");
                        }
                        else
                        {
                            arrISPresent.Add("N");
                        }
                    }
                    else
                    {
                        arrISPresent.Add("N");
                    }

                }


                foreach (ATTMeetingParticipant objMP in (List<ATTMeetingParticipant>)Session["lstMeetingParticipant"])
                {
                    if (i < arrAction.Count)
                    {
                        objMP.Action = arrAction[i].ToString();
                        //objMP.MeetingHead = arrMeetingHead[i].ToString();
                        objMP.MeetingMemPosID = int.Parse(arrMeetingHead[i].ToString());
                        objMP.IsGrpParticipant = arrIsGrpParticipant[i].ToString();
                        objMP.EntryBy = entryBy;

                        if (objMP.IsGrpParticipant.Trim() == "O")
                        {
                            objMP.ParticipantOrgID = int.Parse(drpOrganisation_rqd.SelectedValue);
                            
                        }
                        else
                        {
                            objMP.ParticipantOrgID = null;

                        }
                        //if (int.Parse(drp_MeetingCallerType_rqd.SelectedValue) == 2)
                        //{
                        //    objMP.ParticipantOrgID = int.Parse(drpOrganisation_rqd.SelectedValue);
                        //}
                        //else
                        //    objMP.ParticipantOrgID = null;

                        objMP.IsPresent = arrISPresent[i].ToString();
                    }


                    i++;
                }
            }

            lst = (List<ATTMeetingParticipant>)Session["lstMeetingParticipant"];

            return lst;
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return new List<ATTMeetingParticipant>();
        }
    }

    public int ResetMeetingAgenda(int startID, string[] IDs)
    {
        try
        {
            int i = startID;

            if (Session["lstMeetingAgenda"] != null)
            {
                List<ATTMeetingAgenda> lst = (List<ATTMeetingAgenda>)Session["lstMeetingAgenda"];


                foreach (ATTMeetingAgenda objAgenda in lst)
                {
                    if (objAgenda.AgendaID == 0)
                    {
                        objAgenda.AgendaID = int.Parse(IDs[i]);
                        i++;
                    }

                }


            }
            return i;
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return 0;
        }
    }

    public void ResetMeetingParticipant(int startID, string[] IDs)
    {
        try
        {
            int i = startID;
            if (Session["lstMeetingParticipant"] != null)
            {
                List<ATTMeetingParticipant> lst = (List<ATTMeetingParticipant>)Session["lstMeetingParticipant"];


                foreach (ATTMeetingParticipant objParticipant in lst)
                {
                    if (objParticipant.ParticipantID == 0)
                    {
                        objParticipant.ParticipantID = int.Parse(IDs[i]);
                        i++;
                    }
                }
            }

        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void drpOrgansiation_rqd_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //MakeSelectedChanged();
           

            if (this.drpOrganisation_rqd.SelectedIndex > 0)
            {
                drp_MeetingCallerType_rqd.Enabled = true;
            }
            else
            {
                drp_MeetingCallerType_rqd.SelectedIndex = -1;
            }

            drpCalledBy_rqd.Items.Clear();
            drpCalledBy_rqd.Visible = false;
            lblMeetingCalledBy.Visible = false;
            lblIsRqdCalledBy.Visible = false;

        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    public void MakeSelectedChanged()
    {
        try
        {
            if (this.drpOrganisation_rqd.SelectedIndex > 0)
            {
                this.drpVenue.Items.Clear();
                
                if (Session["MeetingVenueList"] != null)
                {
                    List<ATTMeetingVenue> lstVenue = (List<ATTMeetingVenue>)Session["MeetingVenueList"];
                    ATTMeetingVenue objVenue = new ATTMeetingVenue();
                    objVenue.LstVenue = lstVenue.FindAll(delegate(ATTMeetingVenue objMeetingVenue)
                                                            {
                                                                return (objMeetingVenue.OrgID == int.Parse(drpOrganisation_rqd.SelectedValue)
                                                                        || (objMeetingVenue.OrgID == -1));
                                                            }

                                                         );


                    this.drpVenue.DataSource = objVenue.LstVenue;
                    this.drpVenue.DataTextField = "VenueName";
                    this.drpVenue.DataValueField = "VenueID";
                    this.drpVenue.DataBind();

                    drpVenue.Enabled = true;
                    drp_MeetingCallerType_rqd.Enabled = true;

                }


            }
            else
            {
                drpVenue.Enabled = false;
                //drpCalledBy_rqd.Enabled = false;
                //drp_MeetingCallerType_rqd.Enabled = false;

                drpVenue.SelectedIndex = -1;
                drp_MeetingCallerType_rqd.SelectedIndex = -1;
            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    public bool LoadMeetingCaller(int? callerType)
    {
        try
        {

            if (callerType == 2)
            {

                if (Session["MeetingGroupList"] != null)
                {

                    List<ATTGroup> lstGroup = (List<ATTGroup>)Session["MeetingGroupList"];

                    if (lstGroup.Count > 0)
                    {
                        List<ATTGroup> lstRqdGroup = new List<ATTGroup>();

                        lstRqdGroup = lstGroup.FindAll(delegate(ATTGroup objGroup)
                                                            {
                                                                return objGroup.OrgID == int.Parse(drpOrganisation_rqd.SelectedValue);
                                                            }

                                                       );


                        this.drpCalledBy_rqd.DataSource = lstRqdGroup;
                        this.drpCalledBy_rqd.DataTextField = "GroupName";
                        this.drpCalledBy_rqd.DataValueField = "GroupID";
                        this.drpCalledBy_rqd.DataBind();

                        ListItem a = new ListItem();
                        a.Selected = true;
                        a.Text = " छान्नुहोस्";
                        a.Value = "0";
                        drpCalledBy_rqd.Items.Insert(0, a);

                        drpCalledBy_rqd.Visible = true;
                        //drpCalledBy_rqd.Enabled = Visible;
                        lblIsRqdCalledBy.Visible = true;
                        lblMeetingCalledBy.Visible = true;



                        lblMeetingCalledBy.Text = "बोलाउने कमिटि";
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowDiv", "javascript:ShowDiv();", true);
                        return true;
                    }
                    else
                        return false;
                }
            }
            else if (callerType == 1)
            {

                if (Session["MeetingPersonList"] != null)
                {
                    List<ATTEmployeePosting> lstPerson = (List<ATTEmployeePosting>)Session["MeetingPersonList"];

                    if (lstPerson.Count > 0)
                    {
                        this.drpCalledBy_rqd.DataSource = (List<ATTEmployeePosting>)Session["MeetingPersonList"];
                        this.drpCalledBy_rqd.DataTextField = "EmpName";
                        this.drpCalledBy_rqd.DataValueField = "EmpID";

                        this.drpCalledBy_rqd.DataBind();

                        ListItem a = new ListItem();
                        a.Selected = true;
                        //a.Text = "Select Person";
                        a.Text = " छान्नुहोस्";
                        a.Value = "0";
                        drpCalledBy_rqd.Items.Insert(0, a);

                        //drpCalledBy_rqd.Enabled = true;

                        //drpCalledBy_rqd.Enabled = Visible;
                        lblIsRqdCalledBy.Visible = true;
                        lblMeetingCalledBy.Visible = true;
                        drpCalledBy_rqd.Visible = true;
                        //drpCalledBy_rqd.Enabled = Visible;

                        lblMeetingCalledBy.Text = "बोलाउने व्यक्ति";

                        //this.drpCalledBy_rqd.SelectedValue = ((ATTUserLogin)Session["Login_User_Detail"]).PID.ToString();

                        return true;

                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowDiv", "javascript:ShowDiv();", true);
                    }
                    else
                        return false;
                }

            }
            else
                return false;


            return true;

        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();

            return false;
        }
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            drpOrganisation_rqd.SelectedIndex = -1;
            drpOrganisation_rqd.Enabled = true;

            grdAgenda.DataSource = "";
            grdAgenda.DataBind();

            grdParticipant.DataSource = "";
            grdParticipant.DataBind();

            Session["lstMeetingAgenda"] = null;
            Session["lstMeetingParticipant"] = null;
            Session["RqdGroupMembers"] = null;
            Session["AgendaDelCount"] = null;
            Session["MeetingSubject"] = null;

            Session["InOut"] = null;
            Session["RqdEvent"] = null;

            btnUpdAgenda.Visible = false;
            btnAdd.Visible = true;

            imgBtnExpand4.Visible = false;
            lblMinuteStatus.Visible = false;
            pnlMinute.Visible = false;

            lblCreateMeetingStatus.Text = "";

            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnCreateEvent.Visible = true;
            btnAddOthers.Visible = false;

            drp_MeetingCallerType_rqd.SelectedIndex = -1;
            drpCalledBy_rqd.SelectedIndex = -1;
            drp_MeetingCallerType_rqd.Enabled = false;
            drpCalledBy_rqd.Enabled = false;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "ClearForm", "javascript:clearForm();", true);
            ddlMonth.SelectedIndex = -1;
            ddlYear.SelectedIndex = -1;

            LoadEvents();
            //ResetLinkColor();

        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void LinkEventHandler(object sender, EventArgs e)
    {
        try
        {
            string arguments = ((LinkButton)sender).CommandArgument.ToString();

            if (CalculateIDs(arguments))
            {

                List<ATTEvent> lstRqdEvent = new List<ATTEvent>();

                lstRqdEvent = SearchRqdLst();
                Session["RqdEvent"] = lstRqdEvent;

                if (lstRqdEvent.Count > 0)
                {
                    if (LoadEventDatas(lstRqdEvent, (LinkButton)sender))
                    {
                        Session["arguments"] = arguments;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "javascript:callDiv();", true);
                    }

                }

            }


        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }

    }

    public bool CalculateIDs(string arguments)
    {
        try
        {
            string[] IDs = arguments.Split(new char[] { '/' });

            orgID = Convert.ToInt32(IDs[0]);
            unitID = Convert.ToInt32(IDs[1]);
            meetingID = Convert.ToInt32(IDs[2]);

            Session["meetingAgruments"] = null;

            return true;
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return false;
        }

    }

    public List<ATTEvent> SearchRqdLst()
    {
        try
        {
            List<ATTEvent> lstEvent = new List<ATTEvent>();
            List<ATTEvent> lst = new List<ATTEvent>();

            lstEvent = (List<ATTEvent>)Session["MeetingEvents"];


            lst = lstEvent.FindAll(
                                    delegate(ATTEvent objEvent)
                                    {
                                        return ((objEvent.OrgID == orgID) && (objEvent.EventID == meetingID));
                                    }

                                   );
            return lst;

        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return new List<ATTEvent>();
        }
    }

    public bool LoadEventDatas(List<ATTEvent> lstRqdEvent, LinkButton lnk)
    {
        try
        {
            foreach (ATTEvent objEvent in lstRqdEvent)
            {
                if (objEvent.InOut == "IN")
                {
                    //btnUpdate.Visible = true;
                    //btnDelete.Visible = true;

                    inOut = "IN";

                }
                else
                {
                    //btnUpdate.Visible = false;
                    //btnDelete.Visible = false;

                    inOut = "OUT";
                }

                Session["chkInOut"] = inOut;

                //lnk.ForeColor = objEvent.RDStatusColor;
                foreach (ATTMeeting objMeeting in objEvent.LstMeeting)
                {
                    drpOrganisation_rqd.SelectedValue = objMeeting.OrgID.ToString();

                    //MakeSelectedChanged();

                    if (objMeeting.IsGrpCaller == "N")
                    {
                        drp_MeetingCallerType_rqd.SelectedValue = "1";
                        if (LoadMeetingCaller(1))
                        {

                            drpCalledBy_rqd.SelectedValue = objMeeting.CalledByPID.ToString();
                            drpCalledBy_rqd.Enabled = true;
                            lblMeetingCalledBy.Visible = true;
                            lblIsRqdCalledBy.Visible = true;
                        }
                        else
                        {
                            drpCalledBy_rqd.Visible = false;
                            lblMeetingCalledBy.Visible = false;
                            lblIsRqdCalledBy.Visible = false;
                        }
                        
                    }
                    else
                    {
                        drp_MeetingCallerType_rqd.SelectedValue = "2";

                        if (LoadMeetingCaller(2))
                        {

                            drpCalledBy_rqd.SelectedValue = objMeeting.CalledBy.ToString();
                            drpCalledBy_rqd.Enabled = false;
                            lblMeetingCalledBy.Visible = true;
                            lblIsRqdCalledBy.Visible = true;
                        }
                        else
                        {
                            drpCalledBy_rqd.Visible = false;
                            lblMeetingCalledBy.Visible = false;
                            lblIsRqdCalledBy.Visible = false;
                        }
                    }

                    drpVenue.SelectedValue = objMeeting.VenueID.ToString();
                   
                    drpStatus_rqd.SelectedValue = objMeeting.Status.ToString();
                    drpMeetingType_rqd.SelectedValue = objMeeting.MeetingTypeID.ToString();

                    txtSubject_rqd.Text = objMeeting.Subject;

                    string startTime = objMeeting.StartTime;

                    string hr1, min1;


                    hr1 = startTime.Substring(0, startTime.Length - 3).ToString();


                    if (startTime.Length == 4)
                    {
                        min1 = startTime.Substring(2, startTime.Length - 2).ToString();
                    }
                    else
                        min1 = startTime.Substring(3, startTime.Length - 3).ToString();

                    drpHr1_rqd.SelectedValue = hr1;
                    drpMin1_rqd.SelectedValue = min1;



                    string endTime = objMeeting.EndTime;

                    string hr2, min2;

                    hr2 = endTime.Substring(0, endTime.Length - 3).ToString();

                    if (endTime.Length == 4)
                    {
                        min2 = endTime.Substring(2, endTime.Length - 2).ToString();
                    }
                    else
                        min2 = endTime.Substring(3, endTime.Length - 3).ToString();

                    drpHr2_rqd.SelectedValue = hr2;
                    drpMin2_rqd.SelectedValue = min2;

                    txtMeetingDate_rqd.Text = hdnMDate.Value;

                    if (objMeeting.VenueType.Trim() == "INS")
                    {
                        ddlVenueType_rqd.SelectedValue = "1";
                        lblVenueDataTitle.Text = "बुकिङ्ग नं.";

                        if (objMeeting.VenueBookingID  != null)
                        {
                            lblVenueDataTitle.Visible = true;
                            lblVenueDataTitleRqd.Visible = true;
                            txtVenueData_rqd.Visible = true;
                            txtVenueData_rqd.Text = objMeeting.VenueBookingID.ToString();
                        }
                    }
                    else if (objMeeting.VenueType.Trim() == "EX")
                    {
                        ddlVenueType_rqd.SelectedValue = "2";
                        lblVenueDataTitle.Text = "स्थानको नाम";

                        if (objMeeting.VenueData != "")
                        {
                            lblVenueDataTitle.Visible = true;
                            lblVenueDataTitleRqd.Visible = true;
                            txtVenueData_rqd.Visible = true;
                            txtVenueData_rqd.Text = objMeeting.VenueData;
                        }
                    }

                    if (objMeeting.VenueData != "")
                    {
                        lblVenueDataTitle.Visible = true;
                        lblVenueDataTitleRqd.Visible = true;
                        txtVenueData_rqd.Visible = true;
                        txtVenueData_rqd.Text = objMeeting.VenueData;
                    }
                    

                    if (objMeeting.LstMeetingAgenda.Count > 0)
                    {
                        grdAgenda.DataSource = objMeeting.LstMeetingAgenda;
                        grdAgenda.DataBind();

                        Session["lstMeetingAgenda"] = objMeeting.LstMeetingAgenda;
                        grdAgenda.SelectedIndex = -1;
                    }

                    if (objMeeting.LstMeetingParticipant.Count > 0)
                    {
                        Session["lstMeetingParticipant"] = null;


                        grdParticipant.DataSource = objMeeting.LstMeetingParticipant;
                        grdParticipant.DataBind();

                        Session["lstMeetingParticipant"] = objMeeting.LstMeetingParticipant;




                        ChkMeetingHead();

                        //SetParticipantValuesToGrid();

                    }

                    List<ATTMeetingMinute> lst = BLLMeetingMinute.GetMeetingMinuteList(objMeeting.OrgID, objMeeting.MeetingID, null);
                    if (lst.Count > 0)
                    {
                        string minuteTiming = "From " + startTime + " to " + endTime;
                        lblMinuteTitle.Text = objMeeting.Subject;
                        lblMinuteTiming.Text = minuteTiming;

                        dlstMinute.DataSource = lst;
                        dlstMinute.DataBind();

                        Session["MeetingSubject"] = lblMinuteTitle.Text;

                        imgBtnExpand4.Visible = true;
                        lblMinuteStatus.Visible = true;
                        pnlMinute.Visible = true;
                    }
                    else
                    {
                        imgBtnExpand4.Visible = false;
                        lblMinuteStatus.Visible = false;
                        pnlMinute.Visible = false;
                        Session["MeetingSubject"] = null;
                    }



                    drpOrganisation_rqd.Enabled = false;
                    drp_MeetingCallerType_rqd.Enabled = false;
                    //drpCalledBy_rqd.Enabled = false;
                    //btnUpdate.Visible = true;
                    //btnDelete.Visible = true;

                    ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);

                    if (user.MenuList["5,7,1"].PEdit == "Y")
                    {
                        if (inOut == "IN")
                        {
                            btnUpdate.Visible = true;
                            btnAdd.Visible = true;
                            //btnParitcipantAdd.Visible = true;
                            btnAddOthers.Visible = true;
                            //drpParticipant.Enabled = true;
                        }

                    }


                    if (user.MenuList["5,7,1"].PDelete == "Y")
                    {
                        if (inOut == "IN")
                        {
                            btnDelete.Visible = true;
                        }
                    }

                    btnCreateEvent.Visible = false;

                    if (objEvent.InOut == "IN")
                    {
                        if (objMeeting.Status == 2)
                        {
                            btnUpdate.Visible = false;
                        }
                    }
                }

                Session["InOut"] = objEvent.InOut;
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "setDiv", "javascript:setDiv();", true);
                  
            }


            return true;
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return false;
        }
    }

    public void ChkMeetingHead()
    {
        try
        {
            bool flag = false;
            CheckBox chk, chkParticipant;

            foreach (GridViewRow gvr in grdParticipant.Rows)
            {
                chkParticipant = (CheckBox)gvr.FindControl("chkParticipant");
                chk = (CheckBox)gvr.FindControl("chkMeetingHead");
                if ((chkParticipant.Checked) && (chkParticipant.Enabled == true))
                {
                    if (chk.Checked)
                    {
                        flag = true;
                    }
                }
            }

            if (!flag)
            {
                foreach (GridViewRow gvr in grdParticipant.Rows)
                {
                    chkParticipant = (CheckBox)gvr.FindControl("chkParticipant");
                    chk = (CheckBox)gvr.FindControl("chkMeetingHead");
                    if ((chkParticipant.Checked) && (chkParticipant.Enabled == true))
                    {
                        chk.Enabled = true;
                    }
                }
            }

        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }

    public void SetParticipantValuesToGrid()
    {
        try
        {
            List<ATTMeetingParticipant> lst = new List<ATTMeetingParticipant>();
            int i = 0;


            ArrayList arrNote = new ArrayList();

            foreach (ATTMeetingParticipant objMP in (List<ATTMeetingParticipant>)Session["lstMeetingParticipant"])
            {
                arrNote.Add(objMP.Note.ToString());
            }


            foreach (GridViewRow gvr in grdParticipant.Rows)
            {
                TextBox box = new TextBox();
                box = ((TextBox)gvr.Cells[3].FindControl("txtNote"));
                box.Text = arrNote[i].ToString();
                i++;
            }

        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            bool flag = false;
            List<ATTEvent> lstEvent = new List<ATTEvent>();
            List<ATTEvent> lstEventToRemove = new List<ATTEvent>();

            CalculateIDs(Session["arguments"].ToString());

            string dateString = BLLDate.GetDateString(int.Parse(lblYear.Text), int.Parse(lblMonth.Text), "_N");

            char[] token ={ '/' };

            int year = int.Parse(dateString.Split(token)[0]);
            int month = int.Parse(dateString.Split(token)[1]);
            int SDay = int.Parse(dateString.Split(token)[3]);
            string day = GetEnglisValue(hdnDay.Value.ToString());

            int i = SDay + int.Parse(day) - 1;

            DataList dLst;

            lstEvent = (List<ATTEvent>)Session["MeetingEvents"];

            lstEventToRemove = SearchRqdLst();

            if (lstEventToRemove.Count > 0)
            {
                foreach (ATTEvent objEvent in lstEventToRemove)
                {
                    foreach (ATTMeeting objMeeting in objEvent.LstMeeting)
                    {
                        if (BLLMeeting.DeleteMeetingEvent(objMeeting))
                        {
                            flag = true;
                        }
                    }

                    if (flag)
                    {
                        lstEvent.Remove(objEvent);

                        dLst = ((DataList)this.tblAM.Rows[this.GetRowIndex(i)].Cells[this.GetCellIndex(i) - 1].FindControl("DataList" + i.ToString()));

                        if (dLst != null)
                        {
                            dLst.DataSource = "";
                            dLst.DataBind();
                        }


                        if (lstEvent.Count > 0)
                        {
                            List<ATTEvent> lst = new List<ATTEvent>();

                            lst = lstEvent.FindAll(
                                                        delegate(ATTEvent obj)
                                                        {
                                                            return obj.Day == int.Parse(day);
                                                        }

                                                   );

                            if (lst.Count > 0)
                            {

                                if (dLst != null)
                                {
                                    dLst.DataSource = lst;
                                    dLst.DataBind();
                                }

                            }

                            Session["MeetingEvents"] = lstEvent;

                            this.grdAgenda.DataSource = null;
                            this.grdAgenda.DataBind();

                            this.grdParticipant.DataSource = null;
                            this.grdParticipant.DataBind();

                            Session["lstMeetingAgenda"] = null;
                            Session["lstMeetingParticipant"] = null;

                            drpOrganisation_rqd.SelectedIndex = -1;

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ClearForm", "javascript:clearForm();", true);


                        }
                    }

                }
            }

            if (flag)
            {
                drpOrganisation_rqd.Enabled = true;
                btnCreateEvent.Visible = true;
                btnDelete.Visible = false;
                btnUpdate.Visible = false;

                drp_MeetingCallerType_rqd.SelectedIndex = -1;
                drpCalledBy_rqd.SelectedIndex = -1;
                drp_MeetingCallerType_rqd.Enabled = false;
                drpCalledBy_rqd.Enabled = false;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "HideDiv", "javascript:hideDiv();", true);

                LoadEvents();

                this.lblStatusMessageTitle.Text = "मिटिङ्ग";
                this.lblStatusMessage.Text = "मिटिङ्ग हटाउने कार्य सफलतापूर्वक भयो !!!";
                this.programmaticModalPopup.Show();

            }
            else
            {
                this.lblStatusMessageTitle.Text = "मिटिङ्ग";
                this.lblStatusMessage.Text = "मिटिङ्ग हटाउने कार्यमा वाधा  उत्पन्न भयो!!!";
                this.programmaticModalPopup.Show();
            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    public bool LoadNewEvents()
    {
        try
        {

            string dateString = BLLDate.GetDateString(int.Parse(lblYear.Text), int.Parse(lblMonth.Text), "_N");

            List<ATTEvent> lstEvent = new List<ATTEvent>();

            lstEvent = (List<ATTEvent>)Session["MeetingEvents"];

            char[] token ={ '/' };

            int year = int.Parse(dateString.Split(token)[0]);
            int month = int.Parse(dateString.Split(token)[1]);
            int SDay = int.Parse(dateString.Split(token)[3]);

            List<ATTEvent> lst = new List<ATTEvent>();

            string day = GetEnglisValue(hdnDay.Value.ToString());

            lst = lstEvent.FindAll(
                                        delegate(ATTEvent objEvent)
                                        {
                                            return objEvent.Day == int.Parse(day);
                                        }

                                     );

            int i = SDay + int.Parse(day) - 1;

            if (lst.Count > 0)
            {
                DataList dLst;

                dLst = ((DataList)this.tblAM.Rows[this.GetRowIndex(i)].Cells[this.GetCellIndex(i) - 1].FindControl("DataList" + i.ToString()));
                dLst.BackColor = System.Drawing.Color.DarkKhaki;

                if (dLst != null)
                {
                    dLst.DataSource = lst;
                    dLst.DataBind();
                }
                //this.tblAM.Rows[this.GetRowIndex(i)].Cells[this.GetCellIndex(i) - 1].BackColor = System.Drawing.Color.DarkKhaki;
            }

            return true;


        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return false;
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string day = GetEnglisValue(hdnDay.Value.ToString());
            string currentDate = "";

            currentDate = GetCurrentDate();

            string meetingSetDate = "";
            if (this.txtMeetingDate_rqd.Text != "")
            {
                meetingSetDate = int.Parse(lblYear.Text.ToString()) + "/" + GetFormated(lblMonth.Text.ToString()) + "/" + GetFormated(day);
            }

            string time = "00:00:00";

            if (this.drpHr1_rqd.SelectedIndex > 0 && this.drpMin1_rqd.SelectedIndex > 0)
            {
                time = drpHr1_rqd.SelectedValue.ToString()
                       + ":" + drpMin1_rqd.SelectedValue.ToString();
            }


            if (CompareTime(time, currentDate, meetingSetDate))
            {
             

                if (Session["RqdEvent"] != null)
                {
                    if (Session["lstMeetingParticipant"] == null)
                    {
                        this.lblStatusMessageTitle.Text = "मिटिङ्ग";
                        this.lblStatusMessage.Text = " मिटिङ्गमा कम्तिमा एकजना सहभागी राख्न अनिवार्य छ ।";
                        this.programmaticModalPopup.Show();

                    }


                    foreach (ATTEvent objEvent in (List<ATTEvent>)Session["RqdEvent"])
                    {
                        foreach (ATTMeeting objMeeting in objEvent.LstMeeting)
                        {
                            //string day = GetEnglisValue(hdnDay.Value.ToString());

                            if (this.drpMeetingType_rqd.SelectedIndex > 0)
                                objMeeting.MeetingTypeID = int.Parse(drpMeetingType_rqd.SelectedValue);

                            if (this.drpVenue.SelectedIndex > 0)
                                objMeeting.VenueID = int.Parse(drpVenue.SelectedValue);

                            if (int.Parse(drp_MeetingCallerType_rqd.SelectedValue) == 1)
                            {
                                objMeeting.IsGrpCaller = "N";

                                if (this.drpCalledBy_rqd.SelectedIndex > 0)
                                    objMeeting.CalledByPID = int.Parse(drpCalledBy_rqd.SelectedValue);

                                objMeeting.CalledBy = null;
                            }
                            else if (int.Parse(drp_MeetingCallerType_rqd.SelectedValue) == 2)
                            {
                                objMeeting.IsGrpCaller = "Y";

                                if (this.drpCalledBy_rqd.SelectedIndex > 0)
                                    objMeeting.CalledBy = int.Parse(drpCalledBy_rqd.SelectedValue);

                                objMeeting.CalledByPID = null;
                            }

                            if (this.txtMeetingDate_rqd.Text != "")
                            {
                                objMeeting.MeetingDate = int.Parse(lblYear.Text.ToString()) + "/" + GetFormated(lblMonth.Text.ToString()) + "/" + GetFormated(day);

                            }

                            if (this.drpHr1_rqd.SelectedIndex > 0 && this.drpMin1_rqd.SelectedIndex > 0)
                            {
                                objMeeting.StartTime = drpHr1_rqd.SelectedValue.ToString()
                                                        + ":" + drpMin1_rqd.SelectedValue.ToString();

                            }

                            if (this.drpHr2_rqd.SelectedIndex > 0 && this.drpMin2_rqd.SelectedIndex > 0)
                            {
                                objMeeting.EndTime = drpHr2_rqd.SelectedValue.ToString()
                                                       + ":" + drpMin2_rqd.SelectedValue.ToString();

                            }

                            if (this.drpStatus_rqd.SelectedIndex > 0)
                                objMeeting.Status = int.Parse(drpStatus_rqd.SelectedValue.ToString());


                            objMeeting.Subject = txtSubject_rqd.Text;

                            if (objMeeting.Subject.Length > 15)
                                objEvent.Event = objMeeting.Subject.Substring(0, 15) + ".....";
                            else
                                objEvent.Event = objMeeting.Subject;

                            if (drp_MeetingCallerType_rqd.SelectedIndex != 0)
                            {

                                if (ddlVenueType_rqd.SelectedIndex > 0)
                                {
                                    if (int.Parse(ddlVenueType_rqd.SelectedValue.ToString()) == 1)
                                    {
                                        objMeeting.VenueType = "INS";

                                        if (txtVenueData_rqd.Text != "")
                                            objMeeting.VenueBookingID = int.Parse(txtVenueData_rqd.Text);
                                    }
                                    else if (int.Parse(ddlVenueType_rqd.SelectedValue.ToString()) == 2)
                                    {
                                        objMeeting.VenueType = "EX";

                                        if (txtVenueData_rqd.Text != "")
                                            objMeeting.VenueData = txtVenueData_rqd.Text;
                                    }

                                }
                            }


                            objEvent.EventDetail = "(" + objMeeting.StartTime + " - " + objMeeting.EndTime + ") \n " + objMeeting.Subject;


                            if (Session["lstMeetingAgenda"] != null)
                            {
                                objMeeting.LstMeetingAgenda = (List<ATTMeetingAgenda>)Session["lstMeetingAgenda"];

                                foreach (ATTMeetingAgenda objAgenda in objMeeting.LstMeetingAgenda)
                                {
                                    objAgenda.OrgID = objMeeting.OrgID;
                                    objAgenda.MeetingID = objMeeting.MeetingID;
                                }
                            }

                            if (Session["lstMeetingParticipant"] != null)
                            {
                                objMeeting.LstMeetingParticipant = SetParticipantValuesToList();

                                foreach (ATTMeetingParticipant objParticipant in objMeeting.LstMeetingParticipant)
                                {
                                    objParticipant.OrgID = objMeeting.OrgID;
                                    objParticipant.MeetingID = objMeeting.MeetingID;
                                }
                            }

                            ObjectValidation OV = BLLMeeting.ValidateMeetingEntry(objMeeting);

                            if (OV.IsValid == false)
                            {
                                this.lblStatusMessageTitle.Text = "मिटिङ्ग";
                                this.lblStatusMessage.Text = OV.ErrorMessage;
                                this.programmaticModalPopup.Show();
                                return;
                            }

                            ObjMeeting = objMeeting;
                            Action = "E";

                            // NB: Chk Events
                            ATTUserLogin objUserLogin = (ATTUserLogin)Session["Login_User_Detail"];

                            

                            List<ATTCheckEvents> lst = new List<ATTCheckEvents>();
                            lst = BLLCheckEvents.CheckEvents(objUserLogin, objMeeting.MeetingDate, objMeeting.StartTime, objMeeting.EndTime);

                            lst.RemoveAll(
                                            (delegate(ATTCheckEvents obj)
                                            {
                                                return objMeeting.OrgID == obj.OrgID && objMeeting.MeetingID == obj.ID ;
                                            }
                                            )
                                        );

                            if (lst.Count > 0)
                            {
                                grdChkEvents.DataSource = lst;
                                grdChkEvents.DataBind();



                                ScriptManager.RegisterStartupScript(this, this.GetType(), "HideDiv", "javascript:hideDiv();", true);
                                programmaticBookedVenueModalPopup.Show();
                            }
                            else
                            {
                                UpdateEvent();
                            }
                         

                            //string eventIDs = "";
                            //eventIDs = BLLMeeting.UpdateMeetingEvents(objMeeting);

                            //if (eventIDs != "" && eventIDs == "-1")
                            //{
                            //    venueFlag = true;
                            //    this.lblStatusMessageTitle.Text = "Meeting Event";
                            //    this.lblStatusMessage.Text = "यो स्थलको बुकिङ्ग नं. उपलब्ध  छैन ।\n कृपया अर्को बुकिङ्ग नं. राख्नुहोस् !!! ";
                            //    this.programmaticModalPopup.Show();
                            //}
                            //else if (eventIDs != "")
                            //{

                            //    string[] IDs = eventIDs.Split(new char[] { '/' });
                            //    int startID = 0;
                            //    startID = ResetMeetingAgenda(0, IDs);
                            //}

                            //if (!venueFlag)
                            //{
                            //    flag = true;
                            //}


                        }


                    }
                }

                //if (flag)
                //{

                //    this.grdAgenda.DataSource = null;
                //    this.grdAgenda.DataBind();

                //    this.grdParticipant.DataSource = null;
                //    this.grdParticipant.DataBind();

                //    Session["lstMeetingAgenda"] = null;
                //    Session["lstMeetingParticipant"] = null;

                //    drpOrganisation_rqd.SelectedIndex = -1;
                //    drpOrganisation_rqd.Enabled = true;
                //    btnCreateEvent.Visible = true;
                //    btnUpdate.Visible = false;
                //    btnDelete.Visible = false;

                //    drp_MeetingCallerType_rqd.SelectedIndex = -1;
                //    drpCalledBy_rqd.SelectedIndex = -1;

                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ClearForm", "javascript:clearForm();", true);
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "HideDiv", "javascript:hideDiv();", true);

                //    LoadEvents();

                //    this.lblStatusMessageTitle.Text = "मिटिङ्ग";
                //    this.lblStatusMessage.Text = " मिटिङ्गको परिवर्तन सफलतापूर्वक भयो !!!";
                //    this.programmaticModalPopup.Show();

                //}

            }
            else
            {   this.lblStatusMessageTitle.Text = "मिटिङ्ग";
                this.lblStatusMessage.Text = "मिटिङ्गको शुरु समय नागीसक्यो !!! <br> त्यसैले अर्को शुरु समयमा मिटिङ्ग बनाउनुहोस्";
                this.programmaticModalPopup.Show();
            }


           
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }

    }

    public void RemoveDeletedAgenda()
    {
        try
        {
            if (Session["lstMeetingAgenda"] != null)
            {
                List<ATTMeetingAgenda> lstMeetingAgenda = new List<ATTMeetingAgenda>();
                lstMeetingAgenda = (List<ATTMeetingAgenda>)Session["lstMeetingAgenda"];

                lstMeetingAgenda.RemoveAll(
                                           (delegate(ATTMeetingAgenda objAgenda)
                                           {
                                               return objAgenda.Action == "D";
                                           }
                                           )
                                       );
                Session["lstMeetingAgenda"] = lstMeetingAgenda;


            }

        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }

    public void RemoveDeletedParticipant()
    {
        try
        {
            if (Session["lstMeetingParticipant"] != null)
            {
                List<ATTMeetingParticipant> lstMeetingParticipant = new List<ATTMeetingParticipant>();
                lstMeetingParticipant = (List<ATTMeetingParticipant>)Session["lstMeetingParticipant"];

                lstMeetingParticipant.RemoveAll(
                                               (delegate(ATTMeetingParticipant objMP)
                                               {
                                                   return (objMP.Action == "D" && (objMP.IsGrpParticipant == "N" || objMP.MeetingMemPosID != -1));
                                                   //return (objMP.Action == "D");
                                               })

                                       );
                Session["lstMeetingParticipant"] = lstMeetingParticipant;


            }

        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }

    }

    public void ResetGroupMember()
    {
        try
        {
            List<ATTMeetingParticipant> lstMeetingParticipant = new List<ATTMeetingParticipant>();
            lstMeetingParticipant = (List<ATTMeetingParticipant>)Session["lstMeetingParticipant"];

            foreach (ATTMeetingParticipant objMP in lstMeetingParticipant)
            {
                if (objMP.Action == "A")
                {
                    objMP.Action = "N";
                    objMP.MeetingMemPosID = 0;

                }
                else if (objMP.Action == "D")
                {
                    objMP.Action = "";
                    objMP.MeetingMemPosID = -1;
                }
            }

            Session["lstMeetingParticipant"] = lstMeetingParticipant;
        }
        catch (Exception ex)
        {

            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void btnUpdAgenda_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["updAgendaID"].ToString() != "")
            {
                List<ATTMeeting> lst = new List<ATTMeeting>();

                if (Session["RqdEvent"] != null)
                {
                    foreach (ATTEvent objEvent in (List<ATTEvent>)Session["RqdEvent"])
                    {
                        foreach (ATTMeeting objMeeting in objEvent.LstMeeting)
                        {
                            foreach (ATTMeetingAgenda objAgenda in objMeeting.LstMeetingAgenda)
                            {
                                if (objAgenda.AgendaID == int.Parse(Session["updAgendaID"].ToString()))
                                {
                                    objAgenda.Agenda = txtAgenda.Text;
                                    objAgenda.Action = "E";
                                }
                            }

                            if (objMeeting.LstMeetingAgenda.Count > 0)
                            {
                                grdAgenda.DataSource = objMeeting.LstMeetingAgenda;
                                grdAgenda.DataBind();

                                Session["lstMeetingAgenda"] = objMeeting.LstMeetingAgenda;

                                btnUpdAgenda.Visible = false;
                                //btnAdd.Visible = true;

                                if (btnUpdAgenda.Visible == false)
                                    btnAdd.Visible = true;

                                txtAgenda.Text = "";

                            }


                        }
                    }
                }
                else
                {
                    List<ATTMeetingAgenda> lstMeetingAgenda = new List<ATTMeetingAgenda>();

                    if (Session["lstMeetingAgenda"] != null)
                    {
                        lstMeetingAgenda = (List<ATTMeetingAgenda>)Session["lstMeetingAgenda"];
                    }

                    int i = 0;
                    foreach (ATTMeetingAgenda objAgenda in lstMeetingAgenda)
                    {
                        if (i == int.Parse(Session["updAgendaRowID"].ToString()))
                        {
                            objAgenda.Agenda = txtAgenda.Text;
                        }

                        i++;

                    }

                    if (lstMeetingAgenda.Count > 0)
                    {
                        grdAgenda.DataSource = lstMeetingAgenda;
                        grdAgenda.DataBind();

                        Session["lstMeetingAgenda"] = lstMeetingAgenda;

                        btnUpdAgenda.Visible = false;

                        if(btnUpdAgenda.Visible == false)
                            btnAdd.Visible = true;

                        txtAgenda.Text = "";
                    }
                }

                grdAgenda.SelectedIndex = -1;

            }

        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }

    protected void grdAgenda_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        GridViewRow row = grdAgenda.Rows[e.NewSelectedIndex];

        txtAgenda.Text = row.Cells[2].Text.ToString();

        Session["updAgendaRowID"] = e.NewSelectedIndex;

        Session["updAgendaID"] = row.Cells[1].Text.ToString();

        btnUpdAgenda.Visible = true;

        if (btnUpdAgenda.Visible == true)
            btnAdd.Visible = false;
       // btnAdd.Visible = false;



    }

    public string GetFilterGroupMembers()
    {
        try
        {
            string alreadyCheckedList = "";

            if ((Session["lstMeetingParticipant"] != null))
            {

                if (Session["checkedValue"] != null)
                {
                    ArrayList checkedValue = new ArrayList();
                    ArrayList checkedItem = new ArrayList();
                    checkedValue = (ArrayList)Session["checkedValue"];
                    checkedItem = (ArrayList)Session["checkedItem"];

                    foreach (ATTMeetingParticipant objMP in (List<ATTMeetingParticipant>)Session["lstMeetingParticipant"])
                    {
                        for (int i = 0; i < checkedValue.Count; i++)
                        {

                            if (objMP.ParticipantID == int.Parse(checkedValue[i].ToString()))
                            {
                                alreadyCheckedList += "                   ->  " + checkedItem[i].ToString() + " <br>";

                            }
                        }

                    }
                }
                else if (Session["CheckedOtherMemberValue"] != null)
                {
                    ArrayList checkedOtherMemberValue = new ArrayList();
                    ArrayList checkedOtherMemberItem = new ArrayList();
                    checkedOtherMemberValue = (ArrayList)Session["CheckedOtherMemberValue"];
                    checkedOtherMemberItem = (ArrayList)Session["CheckedOtherMemberItem"];

                    foreach (ATTMeetingParticipant objMP in (List<ATTMeetingParticipant>)Session["lstMeetingParticipant"])
                    {
                        for (int j = 0; j < checkedOtherMemberValue.Count; j++)
                        {
                            if ((objMP.ParticipantID == int.Parse(checkedOtherMemberValue[j].ToString())))
                            {
                                alreadyCheckedList += "                   ->  " + checkedOtherMemberItem[j].ToString() + " <br>";

                            }
                        }
                    }
                }

                if (alreadyCheckedList.Length > 0)
                {
                    alreadyCheckedList = " Following members : <br><br> " + alreadyCheckedList;
                    alreadyCheckedList += " <br> already added. ";
                }



            }

            Session["checkedValue"] = null;
            Session["checkedItem"] = null;
            Session["CheckedOtherMemberValue"] = null;
            Session["CheckedOtherMemberItem"] = null;

            return alreadyCheckedList;

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return "";
        }
    }

    public List<int> GetCheckedValueList(CheckBoxList lst)
    {
        List<int> chkLst = new List<int>();

        foreach (ListItem li in lst.Items)
        {
            if (li.Selected == true)
                chkLst.Add(int.Parse(li.Value));
        }
        return chkLst;
    }

    public List<string> GetCheckedItemList(CheckBoxList lst)
    {
        List<string> chkLst = new List<string>();

        foreach (ListItem li in lst.Items)
        {
            if (li.Selected == true)
                chkLst.Add(li.Text);
        }
        return chkLst;
    }

    protected void btnAddOthers_Click(object sender, EventArgs e)
    {
        this.programmaticPersonModalPopup.Show();
    }
    protected void btnPersonSearch_Click(object sender, EventArgs e)
    {
        try
        {
            List<ATTGroupPersonSearch> lstPersonSearch;
            List<ATTGroupPersonSearch> lst;


            lstPersonSearch = BLLGroupPersonSearch.GetGroupPersonWithEmployee(GetFilter(), "5, 3");

            lst = GetFilteredSrchLst(lstPersonSearch);
            Session["PopupPersonSearch"] = lst;

            if (lst.Count > 0)
            {
                this.grdPersonSearch.DataSource = lst;
                this.grdPersonSearch.DataBind();
            }
            else
            {
                this.grdPersonSearch.DataSource = "";
                this.grdPersonSearch.DataBind();
                lblSearchStatus.Text = " No Records Found !!!! ";
            }
            this.programmaticPersonModalPopup.Show();
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }


    }

    public List<ATTGroupPersonSearch> GetFilteredSrchLst(List<ATTGroupPersonSearch> lst)
    {
        try
        {
           

            if (Session["lstMeetingParticipant"] != null)
            {
                List<ATTMeetingParticipant> lstMeetingParticipant = new List<ATTMeetingParticipant>();
                lstMeetingParticipant = (List<ATTMeetingParticipant>)Session["lstMeetingParticipant"];

                foreach (ATTMeetingParticipant obj in lstMeetingParticipant)
                {

                    lst.Remove(
                                    lst.Find(delegate(ATTGroupPersonSearch objPSrch)
                                                  {
                                                      return (objPSrch.PersonID == obj.ParticipantID);
                                                  }

                                            )
                               );
                }
            }

            return lst;


           

        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }

    private ATTGroupPersonSearch GetFilter()
    {
        ATTGroupPersonSearch SearchPerson = new ATTGroupPersonSearch();

        SearchPerson.Gender = "";
        SearchPerson.MaritalStatus = "";
        SearchPerson.IniType = "";
        SearchPerson.PostName = "";

        SearchPerson.FirstName = this.txtSFirstName.Text.Trim();
        SearchPerson.MiddleName = this.txtSMName.Text.Trim();
        SearchPerson.SurName = this.txtSLastName.Text.Trim();

        if (this.txtMeetingDate_rqd.Text.Trim() != "") SearchPerson.DOB = this.txtSDOB_DT.Text.Trim();
        if (this.ddlSGender.SelectedIndex > 0) SearchPerson.Gender = this.ddlSGender.SelectedValue;
        if (this.ddlSMarStatus.SelectedIndex > 0) SearchPerson.MaritalStatus = this.ddlSMarStatus.SelectedValue;
        if (this.dllOrgSrch.SelectedIndex > 0) SearchPerson.IniType = this.dllOrgSrch.SelectedValue;
        if (this.ddlDesignation.SelectedIndex > 0) SearchPerson.PostName = this.ddlDesignation.SelectedValue;
        if (this.ddlCommittee.SelectedIndex > 0) SearchPerson.GroupID = int.Parse(this.ddlCommittee.SelectedValue);
        if (this.ddlCommitteePost.SelectedIndex > 0) SearchPerson.GMPositionID = int.Parse(this.ddlCommitteePost.SelectedValue);

        return SearchPerson;
    }

    protected void btnCancelPersonSearch_Click(object sender, EventArgs e)
    {
        ClearPersonSearchFields();
        //this.programmaticPersonModalPopup.Hide();

    }

    public void ClearPersonSearchFields()
    {
        this.txtSFirstName.Text = "";
        this.txtSMName.Text = "";
        this.txtSLastName.Text = "";
        this.ddlSGender.SelectedIndex = -1;
        this.txtSDOB_DT.Text = "";
        this.ddlSMarStatus.SelectedIndex = -1;

        //this.ddlCommittee.SelectedIndex = -1;
        this.ddlCommittee.DataSource = "";
        this.ddlCommittee.DataBind();

        this.ddlCommitteePost.SelectedIndex = -1;
        this.dllOrgSrch.SelectedIndex = -1;
        this.ddlDesignation.SelectedIndex = -1;

        lblSearchStatus.Text = "";

        grdPersonSearch.DataSource = "";
        grdPersonSearch.DataBind();

    }
    protected void grdPersonSearch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;

        if (this.grdPersonSearch.Rows.Count > 0)
        {
            this.lblSearchStatus.Text = "Total person: " + this.grdPersonSearch.Rows.Count.ToString();
        }
        else
        {
            this.lblSearchStatus.Text = "";
        }

    }
    protected void btnAddOther_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void imgBtnClose_Click(object sender, ImageClickEventArgs e)
    {
        ClearPersonSearchFields();
        this.programmaticPersonModalPopup.Hide();
    }

    protected void btnAddMember_Click(object sender, EventArgs e)
    {
        try
        {
            CheckBox cb = new CheckBox();
            int? participantOrgID = null;
            int? groupID = null;
            int participantID;
            string participant;
            string isGrpParticipant = "N";

            List<ATTMeetingParticipant> lstMeetingParticipant = new List<ATTMeetingParticipant>();


            if (Session["lstMeetingParticipant"] != null)
            {
                lstMeetingParticipant = (List<ATTMeetingParticipant>)Session["lstMeetingParticipant"];

            }

            string alreadyCheckedList;
            bool flag = false;

            GetOtherMemberCheckedList();


            alreadyCheckedList = GetFilterGroupMembers();

            if (alreadyCheckedList.Length == 0)
            {
                foreach (GridViewRow gvrow in this.grdPersonSearch.Rows)
                {
                    cb = (CheckBox)(gvrow.Cells[0].FindControl("chkMember"));

                    if (cb.Checked)
                    {
                        participantID = int.Parse(gvrow.Cells[1].Text);
                        participant = gvrow.Cells[2].Text;

                        if (dllOrgSrch.SelectedIndex > 0 && ddlCommittee.SelectedIndex > 0)
                        {
                            participantOrgID = int.Parse(dllOrgSrch.SelectedValue);
                            groupID = int.Parse(ddlCommittee.SelectedValue);
                            isGrpParticipant = "OT";
                        }

                        lstMeetingParticipant.Add(new ATTMeetingParticipant(participantOrgID, participantID, participant, groupID, isGrpParticipant, null, "", 2, "आमन्त्रित", "A", ((ATTUserLogin)Session["Login_User_Detail"]).UserName,""));

                        flag = true;
                    }

                }

                if (flag)
                {

                    Session["lstMeetingParticipant"] = lstMeetingParticipant;

                    List<ATTMeetingParticipant> lstMeetingParticipantToSetBack = SetParticipantValuesToList();

                    this.grdParticipant.DataSource = lstMeetingParticipantToSetBack;
                    this.grdParticipant.DataBind();

                    this.grdPersonSearch.DataSource = "";
                    this.grdPersonSearch.DataBind();

                    chkMeetingHead_CheckedChanged(new object(), new EventArgs());

                    //this.drpParticipant.SelectedIndex = -1;
                    ClearPersonSearchFields();

                    this.programmaticPersonModalPopup.Hide();
                }
                else
                {
                    this.lblStatusMessageTitle.Text = "Committee Members";
                    this.lblStatusMessage.Text = "Please Select Committe members !!!!";
                    this.programmaticModalPopup.Show();
                }
            }
            else
            {
                this.lblStatusMessageTitle.Text = "Committee Members";
                this.lblStatusMessage.Text = alreadyCheckedList;
                this.programmaticModalPopup.Show();


                Session["CommitteErrorCheck"] = "y";
            }


        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    public void GetOtherMemberCheckedList()
    {
        try
        {
            ArrayList checkedOtherMemberValue = new ArrayList();
            ArrayList checkedOtherMemberItem = new ArrayList();
            CheckBox cb = new CheckBox();
            foreach (GridViewRow gvrow in this.grdPersonSearch.Rows)
            {
                cb = (CheckBox)(gvrow.Cells[0].FindControl("chkMember"));

                if (cb.Checked)
                {
                    string memberID = gvrow.Cells[1].Text;
                    checkedOtherMemberValue.Add(memberID);
                    checkedOtherMemberItem.Add(gvrow.Cells[2].Text);
                }

            }
            Session["CheckedOtherMemberValue"] = (object)checkedOtherMemberValue;
            Session["CheckedOtherMemberItem"] = (object)checkedOtherMemberItem;
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtAgenda.Text != "")
            {
                List<ATTMeetingAgenda> lstMeetingAgenda = new List<ATTMeetingAgenda>();

                if (Session["lstMeetingAgenda"] != null)
                {
                    lstMeetingAgenda = (List<ATTMeetingAgenda>)Session["lstMeetingAgenda"];
                }

                lstMeetingAgenda.Add(new ATTMeetingAgenda(txtAgenda.Text, "A", entryBy));

                this.grdAgenda.DataSource = lstMeetingAgenda;
                this.grdAgenda.DataBind();
                txtAgenda.Text = "";
                Session["lstMeetingAgenda"] = lstMeetingAgenda;

            }
            else
            {
                //this.lblCreateMeetingStatus.Text = " Plz Enter the Agenda !!! ";
                this.lblStatusMessageTitle.Text = "Committee Members";
                this.lblStatusMessage.Text = "Please Enter the Agenda !!!";
                this.programmaticModalPopup.Show();
            }

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }

    }


    protected void dlstMinute_ItemDataBound1(object sender, DataListItemEventArgs e)
    {
        ((Label)e.Item.FindControl("lblSN")).Text = (e.Item.ItemIndex + 1).ToString() + " .";
    }

    protected void btnNewPost_Click(object sender, EventArgs e)
    {
        try
        {
            ATTMeetingResponse objMResponse = new ATTMeetingResponse();

            ATTUserLogin objUserLogin = (ATTUserLogin)Session["Login_User_Detail"];

            int pID = int.Parse(objUserLogin.PID.ToString());

            List<ATTEvent> lstRqdEvent = new List<ATTEvent>();
            lstRqdEvent = (List<ATTEvent>)Session["RqdEvent"];

            foreach (ATTEvent objEvent in lstRqdEvent)
            {
                int? groupID = null;

                objMResponse.OrgID = objEvent.OrgID;
                objMResponse.MeetingID = objEvent.EventID;

                foreach (ATTMeetingParticipant objPar in objEvent.LstMeeting[0].LstMeetingParticipant)
                {
                    if (pID == objPar.ParticipantID)
                    {
                        objMResponse.ParticipantID = pID;
                    }

                    groupID = objPar.GroupID;
                }

                if (objMResponse.ParticipantID == 0)
                {
                    if (groupID != null)
                    {
                        objMResponse.ParticipantID = pID;
                    }
                    else
                    {   objMResponse.ParticipantID = int.Parse(drpCalledBy_rqd.SelectedValue);

                    }
                }
              
            }


            //ATTUserLogin objUserLogin = (ATTUserLogin)Session["Login_User_Detail"];

            //objMResponse.ParticipantID = int.Parse(objUserLogin.PID.ToString());

            

            objMResponse.Response = txtComment_cmt.Text;

            if (chkAgree.Checked)
            {
                objMResponse.IsAgree = "Y";
            }
            else
            {
                objMResponse.IsAgree = "N";
            }

            ObjectValidation OV = BLLMeetingResponse.ValidateMeetingResponse(objMResponse);

            if (OV.IsValid == false)
            {
                this.lblStatusMessageTitle.Text = "Comment Post Error";
                this.lblStatusMessage.Text = OV.ErrorMessage;
                this.programmaticModalPopup.Show();
            }
            else
            {

                if (BLLMeetingResponse.SaveMeetingResponse(objMResponse))
                {
                    txtComment_cmt.Text = "";
                    chkAgree.Checked = false;
                    this.lblStatusMessageTitle.Text = "माइनुट";
                    this.lblStatusMessage.Text = "कमेन्ट पोष्ट सफलतापूर्वक भयो !!!";
                    this.programmaticModalPopup.Show();
                }
                else
                {
                    this.lblStatusMessageTitle.Text = "माइनुट";
                    this.lblStatusMessage.Text = "कमेन्ट पोष्टमा वाधा उत्पन्न भयो !!!";
                    this.programmaticModalPopup.Show();
                }
            }
        }
        catch (Exception ex)
        {

            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void btnPreviousPost_Click(object sender, EventArgs e)
    {
        try
        {
            ATTMeetingResponse objMResponse = new ATTMeetingResponse();

            List<ATTEvent> lstRqdEvent = new List<ATTEvent>();
            lstRqdEvent = (List<ATTEvent>)Session["RqdEvent"];

            foreach (ATTEvent objEvent in lstRqdEvent)
            {
                objMResponse.OrgID = objEvent.OrgID;
                objMResponse.MeetingID = objEvent.EventID;
            }

            objMResponse.ParticipantID = 213;
            objMResponse.ResponseID = null;

            List<ATTMeetingResponse> lst = BLLMeetingResponse.GetMeetingResponseListTable(objMResponse);

            lblComment.Text = "<b>" + lst.Count.ToString() + "</b> Comments to [ " + Session["MeetingSubject"].ToString() + " ]";

            dlstComments.DataSource = lst;
            dlstComments.DataBind();

            programmaticCommentModalPopup.Show();

        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void imbBtnClose2_Click(object sender, ImageClickEventArgs e)
    {

        programmaticCommentModalPopup.Hide();
    }
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    { 
        this.programmaticModalPopup.Hide();
    }

    protected void grdParticipant_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow row = e.Row;


        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkBtn = (LinkButton)row.Cells[10].Controls[0];
            CheckBox chkParticipant = (CheckBox)row.FindControl("chkParticipant");
            CheckBox chkMeetingHead = (CheckBox)row.FindControl("chkMeetingHead");
            CheckBox chkPresence = (CheckBox)row.FindControl("chkPresence");

            if (row.Cells[6].Text == "D")
            {

                lnkBtn.Text = "Undo";
                row.ForeColor = System.Drawing.Color.Red;
            }





            if (row.Cells[6].Text == "A")
            {
                chkParticipant.Checked = true;
            }

            if (chkParticipant.Checked)
            {
                if (row.Cells[8].Text == "1")
                {
                    chkMeetingHead.Checked = true;
                    chkMeetingHead.Enabled = true;
                }
                else if (row.Cells[8].Text == "0")
                {
                    chkMeetingHead.Enabled = false;
                }

                chkPresence.Enabled = true;

                if (row.Cells[11].Text == "Y")
                {
                    chkPresence.Checked = true;
                }

            }
            else
            {
                chkMeetingHead.Enabled = false;

                chkPresence.Enabled = false;
            }


            if (row.Cells[8].Text == "1")
            {
                chkParticipant.Checked = true;
                chkMeetingHead.Checked = true;
                chkMeetingHead.Enabled = true;
                chkPresence.Enabled = true;
                lnkBtn.Text = "";

                if (row.Cells[11].Text == "Y")
                {
                    chkPresence.Checked = true;
                }
            }
            else if (row.Cells[8].Text == "2")
            {
                chkParticipant.Checked = true;
                chkMeetingHead.Enabled = false;

                if (row.Cells[9].Text.Trim() != "O")
                {
                    if ((row.Cells[3].Text == ""))
                    {
                        row.Cells[3].Text = "आमन्त्रित";
                        
                    }
                    else if (row.Cells[3].Text.ToString() == "&nbsp;")
                    {
                        row.Cells[3].Text = "आमन्त्रित";
                    }

                    //chkParticipant.Enabled = false;
                    

                }
                else
                {
                    lnkBtn.Text = "";
                    chkParticipant.Enabled = true;
                }
            }
            else if (row.Cells[8].Text == "-1")
            {

                lnkBtn.Text = "";
            }

            if (row.Cells[9].Text.Trim() == "O")
            {
                lnkBtn.Text = "";

                if (row.Cells[8].Text == "0")
                {
                    chkParticipant.Checked = true;

                    chkMeetingHead.Enabled = false;

                    chkPresence.Enabled = true;

                    if (row.Cells[11].Text == "Y")
                    {
                        chkPresence.Checked = true;
                    }

                }

            }

            if (lnkBtn.Text != "")
            {
                if (row.Cells[3].Text == "आमन्त्रित")
                {
                    chkParticipant.Checked = true;
                    chkParticipant.Enabled = false;
                    chkMeetingHead.Enabled = false;
                    chkPresence.Enabled = true;

                    if (row.Cells[11].Text == "Y")
                    {
                        chkPresence.Checked = true;
                    }
                }
                else
                {
                    lnkBtn.Text = "";
                    chkPresence.Enabled = true;

                }
            }

        }

        if (inOut == "OUT")
        {
            row.Cells[10].Visible = false;
        }
        else
        {
            row.Cells[10].Visible = true;
        }
    }

    protected void grdParticipant_RowCreated(object sender, GridViewRowEventArgs e)
    {
        GridViewRow row = e.Row;

        //ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        //if (user.MenuList["5,7,1"].PEdit != "Y")
        //{
        //    row.Cells[10].Visible = false;
        //}


        row.Cells[1].Visible = false;
        row.Cells[6].Visible = false;
        row.Cells[7].Visible = false;
        row.Cells[8].Visible = false;
        row.Cells[9].Visible = false;
        row.Cells[11].Visible = false;

        if (Session["InOut"] == "OUT")
        {
            row.Cells[10].Visible = false;
        }
        else
        {
            row.Cells[10].Visible = true;
        }

        

    }

    protected void grdParticipant_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            GridViewRow row = grdParticipant.Rows[e.RowIndex];
            LinkButton lnkBtn = (LinkButton)row.Cells[10].Controls[0];

            int participantID = int.Parse(row.Cells[1].Text.ToString());
            bool flag = false;

            if (lnkBtn.Text == "Remove")
            {
                foreach (ATTMeetingParticipant objMP in (List<ATTMeetingParticipant>)Session["lstMeetingParticipant"])
                {
                    if (objMP.ParticipantID == participantID)
                    {
                        if (objMP.Action == "A")
                        {
                            break;
                        }
                        else
                        {
                            objMP.Action = "D";
                            flag = true;
                            break;
                        }
                    }
                }
            }
            else
            {
                foreach (ATTMeetingParticipant objMP in (List<ATTMeetingParticipant>)Session["lstMeetingParticipant"])
                {
                    if (objMP.ParticipantID == participantID)
                    {

                        objMP.Action = "";
                        flag = true;
                        break;
                    }

                }
            }


            if (flag)
            {
                if (lnkBtn.Text == "Remove")
                {
                    lnkBtn.Text = "Undo";
                    row.Cells[6].Text = "D";

                    row.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lnkBtn.Text = "Remove";
                    row.Cells[6].Text = "";
                    row.ForeColor = System.Drawing.Color.Black;
                }
            }
            else
            {
                List<ATTMeetingParticipant> lst = new List<ATTMeetingParticipant>();

                lst = SetParticipantValuesToList();

                lst.Remove(
                                  lst.Find(delegate(ATTMeetingParticipant objP)
                                  {
                                      return objP.ParticipantID == participantID;
                                  })

                              );

                Session["lstMeetingParticipant"] = lst;

                grdParticipant.DataSource = lst;
                grdParticipant.DataBind();

                foreach (GridViewRow gvr in grdParticipant.Rows)
                {
                    if (gvr.Cells[6].Text == "D")
                    {
                        LinkButton lnkBtn1 = (LinkButton)gvr.Cells[10].Controls[0];
                        lnkBtn1.Text = "Undo";
                        gvr.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }

        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }

    }

    protected void grdAgenda_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = grdAgenda.Rows[e.RowIndex];
        LinkButton lnkBtn = (LinkButton)row.Cells[4].Controls[0];
        bool flag = false;

        int agendaID = int.Parse(row.Cells[1].Text.ToString());
        //int agendaRowID = e.RowIndex; 


        if (lnkBtn.Text == "Remove")
        {
            if (agendaID != 0)
            {
                foreach (ATTMeetingAgenda objAgenda in (List<ATTMeetingAgenda>)Session["lstMeetingAgenda"])
                {
                    if (objAgenda.AgendaID == agendaID)
                    {
                        if (objAgenda.Action == "A")
                        {
                            break;
                        }
                        else
                        {
                            objAgenda.Action = "D";
                            flag = true;
                            break;
                        }
                    }
                }
            }
            else
            {
                int i = 0;
                foreach (ATTMeetingAgenda objAgenda in (List<ATTMeetingAgenda>)Session["lstMeetingAgenda"])
                {
                    if (i == e.RowIndex)
                    {
                        if (objAgenda.Action == "A")
                        {
                            Session["objAgendaToRemove"] = objAgenda;
                            break;
                        }
                        else
                        {
                            objAgenda.Action = "D";
                            flag = true;
                            break;
                        }

                    }
                    i++;
                }

            }
        }
        else
        {
            foreach (ATTMeetingAgenda objAgenda in (List<ATTMeetingAgenda>)Session["lstMeetingAgenda"])
            {
                if (objAgenda.AgendaID == agendaID)
                {

                    objAgenda.Action = "";
                    flag = true;
                    break;

                }
            }
        }


        if (flag)
        {

            if (lnkBtn.Text == "Remove")
            {
                lnkBtn.Text = "Undo";
                row.Cells[5].Text = "D";

                row.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lnkBtn.Text = "Remove";
                row.Cells[5].Text = "";
                row.ForeColor = System.Drawing.Color.Black;
            }

        }
        else
        {
            List<ATTMeetingAgenda> lst = new List<ATTMeetingAgenda>();
            lst = (List<ATTMeetingAgenda>)Session["lstMeetingAgenda"];

            if (agendaID != 0)
            {
                lst.Remove(
                                    lst.Find(delegate(ATTMeetingAgenda objAgenda)
                                    {
                                        return objAgenda.AgendaID == agendaID;
                                    })

                                );
            }
            else
            {
                if (Session["objAgendaToRemove"] != null)
                {
                    ATTMeetingAgenda objAgendaToRemove = ((ATTMeetingAgenda)Session["objAgendaToRemove"]);
                    lst.Remove(objAgendaToRemove);
                }
            }

            Session["lstMeetingAgenda"] = lst;
            Session["objAgendaToRemove"] = null;
            grdAgenda.DataSource = lst;
            grdAgenda.DataBind();


            txtAgenda.Text = "";

            foreach (GridViewRow gvr in grdAgenda.Rows)
            {
                if (gvr.Cells[5].Text == "D")
                {
                    LinkButton lnkBtn1 = (LinkButton)gvr.Cells[4].Controls[0];
                    lnkBtn1.Text = "Undo";
                    gvr.ForeColor = System.Drawing.Color.Red;
                }
            }

        }

        grdAgenda.SelectedIndex = -1;

    }

    protected void grdAgenda_RowCreated(object sender, GridViewRowEventArgs e)
    {
        GridViewRow row = e.Row;
        row.Cells[1].Visible = false;
        row.Cells[5].Visible = false;

        //ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);

        //if (user.MenuList["5,7,1"].PEdit != "Y")
        //{
        //    row.Cells[3].Visible = false;
        //    row.Cells[4].Visible = false;
        //}

        if (Session["InOut"] == "OUT")
        {
            row.Cells[3].Visible = false;
            row.Cells[4].Visible = false;
            //btnUpdAgenda.Visible = false;
            btnAdd.Visible = false; 
        }
        else
        {
            row.Cells[3].Visible = true;
            row.Cells[4].Visible = true;
            //btnUpdAgenda.Visible = true;
            btnAdd.Visible = true;
        }


    }
    protected void grdAgenda_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow row = e.Row;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (row.Cells[5].Text == "D")
            {
                LinkButton lnkBtn = (LinkButton)row.Cells[4].Controls[0];

                lnkBtn.Text = "Undo";
                row.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        ((LinkButton)sender).ForeColor = System.Drawing.Color.Red;
    }

    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {

    }
    protected void drpCalledBy_rqd_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (drpCalledBy_rqd.SelectedIndex > 0)
            {
                if (int.Parse(drp_MeetingCallerType_rqd.SelectedValue) == 2)
                {
                    if (Session["MeetingGroupMembersList"] != null)
                    {
                        Session["RqdGroupMembers"] = "";

                        string day = GetEnglisValue(hdnDay.Value.ToString());
                        string currentDate = int.Parse(lblYear.Text.ToString()) + "/" + int.Parse(lblMonth.Text.ToString()) + "/" + int.Parse(day);

                        List<ATTGroupMember> lstGroupMembers = (List<ATTGroupMember>)Session["MeetingGroupMembersList"];
                        List<ATTGroupMember> lstRqdGroupMembers = new List<ATTGroupMember>();

                        lstRqdGroupMembers = lstGroupMembers.FindAll(delegate(ATTGroupMember objGM)
                                                                   {
                                                                       return (objGM.GroupID == int.Parse(drpCalledBy_rqd.SelectedValue) && (objGM.ToDate == ""));
                                                                   }

                                                            );

                        Session["RqdGroupMembers"] = lstRqdGroupMembers;
                        Session["lstMeetingParticipant"] = null;
                        LoadParticipant();

                    }
                }
                else if (int.Parse(drp_MeetingCallerType_rqd.SelectedValue) == 1)
                {

                    List<ATTMeetingParticipant> lstMeetingParticipant = new List<ATTMeetingParticipant>();

                    Session["lstMeetingParticipant"] = null;

                    List<ATTEmployeePosting> lst = (List<ATTEmployeePosting>)Session["MeetingPersonList"];

                    ATTEmployeePosting objPerson = lst.Find(delegate(ATTEmployeePosting obj)
                                                          {
                                                              return ((int.Parse(obj.EmpID.ToString()) == int.Parse(drpCalledBy_rqd.SelectedValue)) && (obj.OrgID == int.Parse(drpOrganisation_rqd.SelectedValue)));
                                                          }

                                                   );

                    if (objPerson != null)
                    {
                        lstMeetingParticipant.Add(new ATTMeetingParticipant(null, int.Parse(drpCalledBy_rqd.SelectedValue), drpCalledBy_rqd.SelectedItem.ToString(),
                                                                              null, "N", objPerson.DesID, objPerson.DesName, null, "", "", entryBy,"N"));

                        Session["lstMeetingParticipant"] = lstMeetingParticipant;

                        this.grdParticipant.DataSource = lstMeetingParticipant;
                        this.grdParticipant.DataBind();

                        if (lstMeetingParticipant.Count > 0)
                        {
                            btnAddOthers.Visible = true;
                        }
                        else
                            btnAddOthers.Visible = false;
                    }
                }
            }

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    public void LoadParticipant()
    {
        try
        {
            List<ATTGroupMember> lstRqdGroupMembers = (List<ATTGroupMember>)Session["RqdGroupMembers"];
            List<ATTMeetingParticipant> lstMeetingParticipant = new List<ATTMeetingParticipant>();

            if (Session["lstMeetingParticipant"] != null)
            {
                lstMeetingParticipant = (List<ATTMeetingParticipant>)Session["lstMeetingParticipant"];
            }

            foreach (ATTGroupMember obj in lstRqdGroupMembers)
            {


                lstMeetingParticipant.Add(new ATTMeetingParticipant(obj.OrgID, int.Parse(obj.EmpID.ToString()), obj.EmpName,
                                            int.Parse(drpCalledBy_rqd.SelectedValue), "O", obj.PositionID, obj.PositionName, null, "", "", entryBy,"Y"));
            }

            Session["lstMeetingParticipant"] = lstMeetingParticipant;

            // List<ATTMeetingParticipant> lstMeetingParticipantToSetBack = SetParticipantValuesToList();

            this.grdParticipant.DataSource = lstMeetingParticipant;
            this.grdParticipant.DataBind();



            //this.drpParticipant.SelectedIndex = -1;
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "ClearForm", "javascript:clearCheckBox();", true);
            if (lstMeetingParticipant.Count > 0)
            {
                btnAddOthers.Visible = true;
            }
            else
                btnAddOthers.Visible = false;
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void chkMeetingHead_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            int i = 0;
            int j = 0;
            CheckBox chk, chkParticipant;

            foreach (GridViewRow gvr in grdParticipant.Rows)
            {
                chkParticipant = (CheckBox)gvr.FindControl("chkParticipant");
                chk = (CheckBox)gvr.FindControl("chkMeetingHead");
                if ((chkParticipant.Checked) && (chkParticipant.Enabled == true))
                {
                    if (!chk.Checked)
                    {

                        if (gvr.Cells[6].Text == "N" && gvr.Cells[8].Text == "1")
                            gvr.Cells[6].Text = "E";

                        chk.Enabled = false;
                        gvr.Cells[8].Text = "0";

                        i++;
                    }
                    else
                    {
                        if (gvr.Cells[6].Text == "N")
                            gvr.Cells[6].Text = "E";

                        gvr.Cells[8].Text = "1";
                    }


                    j++;
                }

            }

            if (i == j)
            {
                foreach (GridViewRow gvr in grdParticipant.Rows)
                {
                    chkParticipant = (CheckBox)gvr.FindControl("chkParticipant");
                    chk = (CheckBox)gvr.FindControl("chkMeetingHead");
                    if ((chkParticipant.Checked) && (chkParticipant.Enabled == true))
                    {
                        chk.Enabled = true;
                    }

                }

            }
        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }

    protected void chkParticipant_CheckedChanged1(object sender, EventArgs e)
    {
        try
        {
            CheckBox checkbox = (CheckBox)sender;

            GridViewRow row = (GridViewRow)checkbox.NamingContainer;

            CheckBox chkParticipant = (CheckBox)row.FindControl("chkParticipant");
            CheckBox chkMeetingHead = (CheckBox)row.FindControl("chkMeetingHead");
            CheckBox chkPresence = (CheckBox)row.FindControl("chkPresence");

            CheckBox chkParticipant1;
            CheckBox chkMeetingHead1;
            bool flag = false;
            bool chkflag = false;
            bool chkHeadflag = false;

            if (chkParticipant.Checked)
            {
                if (row.Cells[6].Text == "D")
                    row.Cells[6].Text = "E";
                else if (row.Cells[6].Text == "E")
                    row.Cells[6].Text = "E";
                else
                {
                    row.Cells[6].Text = "A";

                }
                row.Cells[8].Text = "0";

                if (row.Cells[9].Text.Trim() != "N")
                {
                    row.Cells[9].Text = "O";
                }

                chkflag = true;
                chkPresence.Enabled = true;

            }
            else
            {

                chkMeetingHead.Enabled = false;
                chkPresence.Enabled = false;
                chkPresence.Checked = false;

                row.Cells[11].Text = "N";


                if (row.Cells[6].Text == "N" || row.Cells[6].Text == "E")
                    row.Cells[6].Text = "D";
                else
                {
                    row.Cells[6].Text = "";
                    row.Cells[8].Text = "-1";

                    if (row.Cells[9].Text.Trim() != "N")
                    {
                        row.Cells[9].Text = "";
                    }
                }


                if (chkMeetingHead.Checked)
                {
                    chkMeetingHead.Checked = false;
                    //chkMeetingHead.Enabled = true;
                    flag = true;
                }
            }


            if (chkflag)
            {
                foreach (GridViewRow gvr in grdParticipant.Rows)
                {
                    chkParticipant1 = (CheckBox)gvr.FindControl("chkParticipant");
                    chkMeetingHead1 = (CheckBox)gvr.FindControl("chkMeetingHead");
                    if ((chkParticipant1.Checked) && (chkParticipant1.Enabled == true))
                    {

                        if (chkMeetingHead1.Checked)
                        {
                            chkHeadflag = true;
                        }

                    }
                }

                if (!chkHeadflag)
                {
                    chkMeetingHead.Enabled = true;
                    row.Cells[8].Text = "0";
                }
            }


            if (flag)
            {
                foreach (GridViewRow gvr in grdParticipant.Rows)
                {
                    chkParticipant1 = (CheckBox)gvr.FindControl("chkParticipant");
                    chkMeetingHead1 = (CheckBox)gvr.FindControl("chkMeetingHead");
                    if ((chkParticipant1.Checked) && (chkParticipant1.Enabled == true))
                    {

                        chkMeetingHead1.Enabled = true;

                    }
                }
            }


        }
        catch (Exception ex)
        {

            throw (ex);
        }

    }
    protected void dllOrgSrch_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            List<ATTGroup> lstGroup = (List<ATTGroup>)Session["MeetingGroupList"];
            List<ATTGroup> lstRqdGroup = new List<ATTGroup>();

            lstRqdGroup = lstGroup.FindAll(delegate(ATTGroup objGroup)
                                                {
                                                    return (objGroup.OrgID == int.Parse(dllOrgSrch.SelectedValue) && objGroup.GroupID != int.Parse(drpCalledBy_rqd.SelectedValue));
                                                }

                                           );


            this.ddlCommittee.DataSource = lstRqdGroup;
            this.ddlCommittee.DataTextField = "GroupName";
            this.ddlCommittee.DataValueField = "GroupID";
            this.ddlCommittee.DataBind();

            ListItem a = new ListItem();
            a.Selected = true;
            a.Text = " छान्नुहोस्";
            a.Value = "0";
            ddlCommittee.Items.Insert(0, a);

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
        }

    }

    protected void chkPresence_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        GridViewRow row = (GridViewRow)checkbox.NamingContainer;
        CheckBox chkPresence = (CheckBox)row.FindControl("chkPresence");

        if (chkPresence.Checked)
        {
            row.Cells[11].Text = "Y";
        }
        else
        {
            row.Cells[11].Text = "N";
        }

        if (row.Cells[6].Text == "D")
            row.Cells[6].Text = "E";
        else if (row.Cells[6].Text == "E")
            row.Cells[6].Text = "E";
        else if (row.Cells[6].Text == "N")
            row.Cells[6].Text = "E";

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (drp_MeetingCallerType_rqd.SelectedIndex != 0)
            {
                this.drpCalledBy_rqd.Items.Clear();
                drpCalledBy_rqd.Enabled = true;
                LoadMeetingCaller(int.Parse(drp_MeetingCallerType_rqd.SelectedValue.ToString()));
            }
            else
            {
                //drpCalledBy_rqd.Enabled = Visible;
                lblIsRqdCalledBy.Visible = false;
                lblMeetingCalledBy.Visible = false;
                drpCalledBy_rqd.Enabled = false;
                drp_MeetingCallerType_rqd.SelectedIndex = -1;
                drpCalledBy_rqd.SelectedIndex = -1;

                //drp_MeetingCallerType_rqd.Visible = false;  
                drpCalledBy_rqd.Visible = false;

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "HideDiv", "javascript:hideDiv();", true);

            }

        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }
    protected void ddlVenueType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlVenueType_rqd.SelectedIndex != 0)
            {
                if (int.Parse(ddlVenueType_rqd.SelectedValue) == 1)
                {
                    lblVenueDataTitle.Text = "बुकिङ्ग नं.";
                    txtVenueData_rqd.ToolTip = " बुकिङ्ग नं.";
                    //txtVenueData_rqd.MaxLength = 4;

                    imgSrchBtn.Visible = true;
                    imgLocBooking.Visible = true;
                }
                else
                {
                    lblVenueDataTitle.Text = "स्थानको नाम";
                    txtVenueData_rqd.ToolTip = "स्थानको नाम";
                    //txtVenueData_rqd.MaxLength = 20;
                    imgSrchBtn.Visible = false;
                    imgLocBooking.Visible = false;
                }

                txtVenueData_rqd.Text = "";

                txtVenueData_rqd.Visible = true;
                lblVenueDataTitleRqd.Visible = true;
                lblVenueDataTitle.Visible = true;
            }
            else
            {
                txtVenueData_rqd.Visible = false;
                lblVenueDataTitleRqd.Visible = false;
                lblVenueDataTitle.Visible = false;

                imgSrchBtn.Visible = false;
                imgLocBooking.Visible = false;
            }
            
        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }

    public void LoadPostBackControls()
    {
        try
        {
            //LoadEvents();

            ReLoadEvents();

            txtMeetingDate_rqd.Text = hdnMDate.Value;

            if (Session["MeetingSubject"] == null)
            {
                imgBtnExpand4.Visible = false;
                lblMinuteStatus.Visible = false;
                pnlMinute.Visible = false;
            }
            else
            {
                imgBtnExpand4.Visible = true;
                lblMinuteStatus.Visible = true;
                pnlMinute.Visible = true;

            }


            string scrpt = "function mousepos(event){" +
                                 "if(chkObject('dvMeeting')) {" +
                                 "floatingd = document.getElementById('dvMeeting');" +
                                 "if(drag==1){" +
                                 "floatingd.style.left = event.clientX-xdif+'px';" +
                                 "floatingd.style.top = event.clientY-ydif+'px';" +
                                 "}}}";

            ScriptManager.RegisterStartupScript(this, this.GetType(), "MyScript", scrpt, true);

        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }

    public bool CompareDate(string date1,string date2)
    {
        try
        {
            string[] d1 = date1.Split('/');
            string[] d2 = date2.Split('/');

            int year1 = int.Parse(d1[0].ToString());
            int month1 = int.Parse(d1[1].ToString());
            int day1 = int.Parse(d1[2].ToString());

            int year2 = int.Parse(d2[0].ToString());
            int month2 = int.Parse(d2[1].ToString());
            int day2 = int.Parse(d2[2].ToString());

            if (year2 > year1)
            {
                return true;
            }
            else if (year1 == year2)
            {
                if (month2 > month1)
                {
                    return true;
                }
                else if (month1 == month2)
                {
                    if (day2 >= day1)
                    {
                        return true;
                    }
                    else if(day2 < day1)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;   
                }

            }
            else
            {
                return false;
            }



            return true;

        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }

    public bool CompareTime(string time, string date1, string date2)
    {
        try
        {
            if (date1.Trim() == date2.Trim())
            {
                string currentTime = BLLTime.GetCurrentTime();


                string[] t1 = currentTime.Split('/');
                string[] t2 = time.Split(':');

                int hr1 = int.Parse(t1[0].ToString());
                int min1 = int.Parse(t1[1].ToString());

                int hr2 = int.Parse(t2[0].ToString());
                int min2 = int.Parse(t2[1].ToString());

                if (hr2 > hr1)
                {
                    return true;
                }
                else
                {
                    if (min2 > min1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                return false;
            }
            else
            {
                return true;
            }

           
        }
        catch (Exception ex)
        {

            throw (ex);
        }


    }

    public string GetCurrentDate()
    {
        try
        {
            string day = GetEnglisValue(hdnDay.Value.ToString());
            int len = Session["CurrentDate"].ToString().Length;
            string currentDate = Session["CurrentDate"].ToString().Substring(0, len - 5);

            return currentDate;
        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }
    
    public void UpdateEvent()
    {
        try
        {
            bool flag = false;
            bool venueFlag = false;

            string eventIDs = "";

            ATTMeeting objMeeting = ObjMeeting;
            eventIDs = BLLMeeting.UpdateMeetingEvents(objMeeting);

            if (eventIDs != "" && eventIDs == "-1")
            {
                venueFlag = true;
                this.lblStatusMessageTitle.Text = "Meeting Event";
                this.lblStatusMessage.Text = "यो स्थलको बुकिङ्ग नं. उपलब्ध  छैन ।\n कृपया अर्को बुकिङ्ग नं. राख्नुहोस् !!! ";
                this.programmaticModalPopup.Show();
            }
            else if (eventIDs != "")
            {

                string[] IDs = eventIDs.Split(new char[] { '/' });
                int startID = 0;
                startID = ResetMeetingAgenda(0, IDs);
            }

            if (!venueFlag)
            {
                flag = true;
            }


            if (flag)
            {
                SaveClearControls();

                drpOrganisation_rqd.Enabled = true;
                btnCreateEvent.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;

                LoadEvents();

                this.lblStatusMessageTitle.Text = "मिटिङ्ग";
                this.lblStatusMessage.Text = " मिटिङ्गको परिवर्तन सफलतापूर्वक भयो !!!";
                this.programmaticModalPopup.Show();

            }


        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }

    public void SaveEvent()
    {
        try
        {
             ATTMeeting objMeeting = ObjMeeting;

             bool flag = false;
             bool venueFlag = false;

             string eventIDs = "";
             eventIDs = BLLMeeting.SaveMeetingEvents(objMeeting);

             if (eventIDs != "" && (eventIDs == "-1" || eventIDs == "-2"))
             {
                 venueFlag = true;
                 this.lblStatusMessageTitle.Text = "मिटिङ्ग";

                 if (eventIDs == "-1")
                     this.lblStatusMessage.Text = "बुकिङ्ग नं. उपलब्ध  छैन ।\n कृपया अर्को बुकिङ्ग नं. राख्नुहोस् !!! ";
                 else if (eventIDs == "-2")
                     this.lblStatusMessage.Text = "यो बुकिङ्ग  प्रयोगमा आईसक्यो ।\n कृपया अर्को बुकिङ्ग नं. राख्नुहोस् !!! ";

                 this.programmaticModalPopup.Show();
             }
             else if (eventIDs != "")
             {
                 flag = true;
             }

             if (flag)
             {
                 SaveClearControls();
                 LoadEvents();

                 this.lblStatusMessageTitle.Text = "मिटिङ्ग";
                 this.lblStatusMessage.Text = "नयाँ मिटिङ्ग सफलतापूर्वक बन्यो !!!";
                 this.programmaticModalPopup.Show();
             }
             else if (!venueFlag)
             {
                 this.lblStatusMessageTitle.Text = "मिटिङ्ग";
                 this.lblStatusMessage.Text = "नयाँ मिटिङ्ग बनाउँदा वाधा उत्पन्न भयो!!!";
                 this.programmaticModalPopup.Show();
             }
        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }

    public void SaveClearControls()
    {
        try
        {
            this.grdAgenda.DataSource = null;
            this.grdAgenda.DataBind();

            this.grdParticipant.DataSource = null;
            this.grdParticipant.DataBind();

            Session["lstMeetingAgenda"] = null;
            Session["lstMeetingParticipant"] = null;

            drpOrganisation_rqd.SelectedIndex = -1;
            drp_MeetingCallerType_rqd.SelectedIndex = -1;
            drpCalledBy_rqd.SelectedIndex = -1;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "ClearForm", "javascript:clearForm();", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "HideDiv", "javascript:hideDiv();", true);

        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }

    protected void btnChkEOk_Click(object sender, EventArgs e)
    {
        programmaticBookedVenueModalPopup.Hide();

        if (Action == "A")
            SaveEvent();
        else
            UpdateEvent();

    }
    protected void btnChkECancel_Click(object sender, EventArgs e)
    {
        programmaticBookedVenueModalPopup.Hide();
        SaveClearControls();
    }
    protected void grdChkEvents_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow gvRow = e.Row;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (gvRow.Cells[2].Text == "M")
            {
                gvRow.Cells[2].Text = "मिटिङ्ग";
            }
            else
            {
                gvRow.Cells[2].Text = "एपोइन्टमेन्ट";
            }
        }


    }
    protected void btnChkUpdate_Click(object sender, EventArgs e)
    {
        programmaticBookedVenueModalPopup.Hide();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "callDiv", "javascript:callDiv();", true);
    }
    protected void btnVenueSrch_Click(object sender, ImageClickEventArgs e)
    {
        string script = "";
        script += "<script language='javascript' type='text/javascript'>";
        script += "var win=window.open('./MeetingVenueBookingSearch_PopUp.aspx', 'popup','width=822,height=500,directories=no,location=no,menubar=no,resizable=1,scrollbars=1,status=no,toolbar=no');";
        script += "</script>";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "callDiv", "javascript:callDiv();", true);

        ClientScript.RegisterClientScriptBlock(this.GetType(), "PCS", script);

        LoadStatus();
    }
    protected void imgLocBooking_Click(object sender, ImageClickEventArgs e)
    {


        string meetingSetDate = "";

        bool flag = false;
        if (this.txtMeetingDate_rqd.Text != "")
        {
            string day = GetEnglisValue(hdnDay.Value.ToString());
            meetingSetDate = int.Parse(lblYear.Text.ToString()) + "/" + GetFormated(lblMonth.Text.ToString()) + "/" + GetFormated(day);

            Session["meetingSetDate"] = meetingSetDate;

            flag = true;
        }

        if (flag)
        {


            string script = "";
            script += "<script language='javascript' type='text/javascript'>";
            script += "var win=window.open('./MeetingVenueManagement_PopUp.aspx', 'popup','width=822,height=500,directories=no,location=no,menubar=no,resizable=1,scrollbars=1,status=no,toolbar=no');";
            script += "</script>";

            ScriptManager.RegisterStartupScript(this, this.GetType(), "callDiv", "javascript:callDiv();", true);

            ClientScript.RegisterClientScriptBlock(this.GetType(), "PCS", script);

            LoadStatus();
        }
    }
}
   
